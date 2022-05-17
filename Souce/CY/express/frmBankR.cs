using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CY.express
{
    public partial class frmBankR : UserControl
    {
        public frmBankR()
        {
            InitializeComponent();
        }
        private void BindDataWithPage(int Index)
        {
            //string exp_no = txtExpNo.Text.Trim();
            //string UName = txtUName.Text.Trim();
            string op = cobAction.Text.Trim();
            DateTime iStart = DateTime.Now.AddYears(-50);
            DateTime iEnd = DateTime.Now.AddYears(50);

            if (dtpStart.Checked)
            {
                iStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd ") + " 00:00:00"); ;
            }

            if (this.dtpEnd.Checked)
            {
                iEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd ") + " 23:59:59"); ;
            }

            int iSize = Convert.ToInt32(cobPageSize.Text);
            int iIndex = Convert.ToInt32(winFormPager1.PageIndex);
            int isModify = 0;
            //isModify = cobModify.SelectedIndex;
            if (cobBank.SelectedValue == null)
                return;
            string strBankIds = GetSelectedValue(this.cobBank, "bid");
            string strActions = GetSelectedValue(this.cobAction, "bid");

            DataTable dt = DA.Express.getBank("", strBankIds, "", strActions,
                "0", isModify, iStart, iEnd, iIndex, iSize, "");

            dgvResult.DataSource = dt;

            double dIn = 0;
            double dOut = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dIn += Convert.ToDouble(dt.Rows[i]["debit"]);
                dOut += Convert.ToDouble(dt.Rows[i]["credit"]);
            }
            //lblIn.Text = "进账："+dIn.ToString("0.00");
            //lblOut.Text = "出账：" + dOut.ToString("0.00");

            winFormPager1.PageIndex = Index;
            //获取并设置总记录数
            if (Index == 1)
            {
                if (dt.Rows.Count < 1)
                    winFormPager1.RecordCount = 0;
                else
                    winFormPager1.RecordCount = Convert.ToInt32(dt.TableName);
            }
            winFormPager1.Refresh();

            if (dt == null || dt.Rows.Count < 1)
            {
                dgvResult.DataSource = null;
                winFormPager1.ResetText();
            }

        }

        public void FillCheckBoxComboBox(PresentationControls.CheckBoxComboBox cboCheckBoxComboBox, DataTable dt, string vcDisplyName, bool bSelectAll)
        {
            if (dt != null)
            {
                cboCheckBoxComboBox.DataSource =
                new PresentationControls.ListSelectionWrapper<DataRow>(
                dt.Rows,
                vcDisplyName
                );
                cboCheckBoxComboBox.DisplayMemberSingleItem = "Name";
                cboCheckBoxComboBox.DisplayMember = "NameConcatenated";
                cboCheckBoxComboBox.ValueMember = "Selected";
                if (bSelectAll)
                {
                    for (int i = 0; i < cboCheckBoxComboBox.CheckBoxItems.Count; i++)
                    {
                        cboCheckBoxComboBox.CheckBoxItems[i].Checked = true;
                    }
                }
            }
        }


        //this method return selected value of a special column that you want
        public string GetSelectedValue(PresentationControls.CheckBoxComboBox cboCheckBoxComboBox, string vcSelectedValueColumn)
        {
            string dcidSelectedSource = string.Empty;
            for (int i = 0; i < cboCheckBoxComboBox.Items.Count; i++)
            {
                if (cboCheckBoxComboBox.CheckBoxItems[i].Checked == true)
                {
                    ControlBindingsCollection b = cboCheckBoxComboBox.CheckBoxItems[i].DataBindings;
                    if (b != null)
                    {

                        PresentationControls.ObjectSelectionWrapper<DataRow> DataRowSelected = ((b.Control as PresentationControls.CheckBoxComboBoxItem).ComboBoxItem as PresentationControls.ObjectSelectionWrapper<DataRow>);
                        if (DataRowSelected != null && DataRowSelected.Item[0] != null && DataRowSelected.Item[0].ToString() != string.Empty)
                            dcidSelectedSource += DataRowSelected.Item[vcSelectedValueColumn] + ",";
                    }
                }
            }
            if (dcidSelectedSource.Contains(","))
            {
                dcidSelectedSource = dcidSelectedSource.Remove(dcidSelectedSource.Length - 1, 1);
            }
            return dcidSelectedSource;
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataWithPage(1);
        }

        private void frmBank_Load(object sender, EventArgs e)
        {
            cobPageSize.SelectedIndex = 0;
            dgvResult.AutoGenerateColumns = false;
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
            dtpStart.Checked = false;
            dtpEnd.Checked = false;
            DataTable dt = DA.Express.getBankName("");
            DataTable dt1 = dt.Copy();
            DataTable dt2 = dt.Copy();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "全部";
            dt.Rows.InsertAt(dr, 0);

            cobBank2.DataSource = dt1;
            cobBank2.DisplayMember = "bankname";
            cobBank2.ValueMember = "bid";

            cobBank3.DataSource = dt2;
            cobBank3.DisplayMember = "bankname";
            cobBank3.ValueMember = "bid";

            FillCheckBoxComboBox(cobBank, dt, "bankname", false);


            DataTable dtBank = DA.Express.getAction();
            DataRow drBank = dtBank.NewRow();
            drBank[0] = 0;
            drBank[1] = "全部";
            dtBank.Rows.InsertAt(drBank, 0);

            FillCheckBoxComboBox(cobAction, dtBank, "bankactionname", false);


            //cobAction.DataSource = dtBank;
            //cobAction.DisplayMember = "bankactionname";
            //cobAction.ValueMember = "bid";

            cobPageSize.SelectedIndex = 0;
        }
        
        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ServiceReference4.ExpressSoapClient exp = new ServiceReference4.ExpressSoapClient();
            exp.Express exp = new exp.Express();
            if (dgvResult.Columns[e.ColumnIndex].Name == "edit")
            {
                edits(e.RowIndex);
            }
            else if (dgvResult.Columns[e.ColumnIndex].Name == "receipturl")
            {
                string receipturl = dgvResult.Rows[e.RowIndex].Cells["receipturl"].FormattedValue.ToString();
                string filename = Application.StartupPath + "\\" + receipturl;
                if (!System.IO.File.Exists(receipturl))
                {
                    try
                    {
                        byte[] byteImge = exp.downfilebyte(ref receipturl);
                        Image img = BytesToImage(byteImge);
                        if (img == null)
                            return;
                        img.Save(filename);
                        img.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (System.IO.File.Exists(filename))
                {
                    System.Diagnostics.Process.Start(filename);
                }
            }
        }
        public static Image BytesToImage(byte[] buffer)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer);
                Image image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            catch
            {
                return null;
            }
        }
        private void ubtn1_Click(object sender, EventArgs e)
        {
            //express.frmNewBank frm = new express.frmNewBank("");
            //frm.frm = this;
            //frm.Show();
            //btnQuery_Click(null, null);

        }

        private void ubtn2_Click(object sender, EventArgs e)
        {
            express.frmBalance frm = new frmBalance();
            frm.ShowDialog();
            btnQuery_Click(null, null);
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //edits(e.RowIndex);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void requery()
        {
            btnQuery_Click(null, null);
        }
        private void edits(int iRow)
        {
            try
            {
                string bid = dgvResult.Rows[iRow].Cells["bid"].FormattedValue.ToString();
                string isclose = dgvResult.Rows[iRow].Cells["isclose"].FormattedValue.ToString();
                if (isclose == "Y")
                {
                    MessageBox.Show("该信息已经关帐，不能修改！");
                    return;
                }
                //express.frmNewBank frm = new express.frmNewBank(bid);
                //frm.frm = this;
                //frm.Show();
                //DialogResult dr = frm.ShowDialog();
                //if (dr == DialogResult.Yes)
                //    btnQuery_Click(null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void winFormPager1_PageIndexChanged(object sender, EventArgs e)
        {
            winFormPager1.PageSize = Convert.ToInt32(cobPageSize.Text);
            BindDataWithPage(winFormPager1.PageIndex);
        }

        private void cobPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            winFormPager1.ResetText();
            winFormPager1.PageIndex = 1;
            winFormPager1.PageSize = Convert.ToInt32(cobPageSize.Text);
            BindDataWithPage(1);
        }

        private void cPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(string.Format("是否确定对{0}日以及之前的{1}银行数据执行关账？", dateTimePicker2.Text, cobBank2.Text), "确定关账", MessageBoxButtons.YesNo))
                {
                    string dates = dateTimePicker2.Value.Year.ToString("0000-")+dateTimePicker2.Value.Month.ToString("00-")+dateTimePicker2.Value.Day.ToString("00");
                    bool bResult = DA.Express.CloseBank(dates,cobBank2.SelectedValue.ToString());
                    if (bResult)
                    {
                        MessageBox.Show("关账成功！");
                    }
                    else
                    {
                        MessageBox.Show("关账失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show(string.Format("是否确定对{0}银行数据执行刷新？", cobBank3.Text), "确定刷新", MessageBoxButtons.YesNo))
                {
                    bool bResult = DA.Express.RefreshBank(cobBank3.SelectedValue.ToString());
                    if (bResult)
                    {
                        MessageBox.Show("刷新成功！");
                    }
                    else
                    {
                        MessageBox.Show("刷新失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
