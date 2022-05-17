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
    public partial class frmBank : UserControl
    {
        public frmBank()
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

            DataTable dt = DA.Express.getBank(txtPayId.Text.Trim(), cobBank.SelectedValue.ToString(), txtBid.Text.Trim(), cobAction.SelectedValue.ToString(),
                cobOp.SelectedValue.ToString(), isModify, iStart, iEnd, iIndex, iSize, pub.userid);

            dgvResult.DataSource = dt;

            double dIn = 0;
            double dOut = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dIn += Convert.ToDouble(dt.Rows[i]["debit"]);
                dOut += Convert.ToDouble(dt.Rows[i]["credit"]);
            }
            lblIn.Text = "进账："+dIn.ToString("0.00");
            lblOut.Text = "出账：" + dOut.ToString("0.00");

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
            DataTable dt = DA.Express.getBankName(pub.userid);
            if (dt == null||dt.Rows.Count<1)
            {
                MessageBox.Show("您还没有查看银行账目的权限，请联系管理员！");
                return;
            }
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "全部";
            dt.Rows.InsertAt(dr, 0);
            cobBank.DataSource = dt;
            cobBank.DisplayMember = "bankname";
            cobBank.ValueMember = "bid";

            DataTable dtBank = DA.Express.getAction();
            DataRow drBank = dtBank.NewRow();
            drBank[0] = 0;
            drBank[1] = "全部";
            dtBank.Rows.InsertAt(drBank, 0);
            cobAction.DataSource = dtBank;
            cobAction.DisplayMember = "bankactionname";
            cobAction.ValueMember = "bid";



            DataTable dtOP = DA.Express.getOp();
            DataRow drOP = dtOP.NewRow();
            drOP[0] = 0;
            drOP[1] = "全部";
            dtOP.Rows.InsertAt(drOP, 0);
            cobOp.DataSource = dtOP;
            cobOp.DisplayMember = "adminname";
            cobOp.ValueMember = "aid";

            
            cobPageSize.SelectedIndex = 0;

        


            //btnQuery_Click(null, null);

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
                if (!string.IsNullOrEmpty(receipturl))
                {
                    receipturl = @"http://photo.ea-ex.com/" + receipturl;
                    System.Diagnostics.Process.Start(receipturl);
                }
                
                //string filename = Application.StartupPath + "\\" + receipturl;
                //if (!System.IO.File.Exists(receipturl))
                //{
                ////    try
                //    {
                //        byte[] byteImge = exp.downfilebyte(ref receipturl);
                //        Image img = BytesToImage(byteImge);
                //        if (img == null)
                //            return;
                //        img.Save(filename);
                //        img.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
                //if (System.IO.File.Exists(filename))
                //{
                //    System.Diagnostics.Process.Start(filename);
                //}
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
            express.frmNewBank frm = new express.frmNewBank("");
            frm.frm = this;
            frm.Show();
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
                express.frmNewBank frm = new express.frmNewBank(bid);
                frm.frm = this;
                frm.Show();
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
    }
}
