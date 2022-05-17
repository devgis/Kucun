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
    public partial class frmDaifu : UserControl
    {
        public frmDaifu()
        {
            InitializeComponent();
        }
        private void BindDataWithPage(int Index)
        {
            if (cobWebSite.SelectedValue == null)
                return;
            //string exp_no = txtExpNo.Text.Trim();
            //string UName = txtUName.Text.Trim();
            string op = cobWebSite.Text.Trim();
            long iStart = 0;
            long iEnd = 99999999999999;//1473704493
                       
            if (dtpStart.Checked)
            {
                iStart = pub.ConvertDateTimeInt(Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd ") + " 00:00:00"));// ; ;
            }

            if (this.dtpEnd.Checked)
            {
                iEnd = pub.ConvertDateTimeInt(Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd ") + " 23:59:59"));
            }

            int iSize = Convert.ToInt32(cobPageSize.Text);
            int iIndex = Convert.ToInt32(winFormPager1.PageIndex);
            //isModify = cobModify.SelectedIndex;
            //if (cobBank.SelectedValue == null)
                //return;

            //DataTable dt = DA.Express.getBank(txtIdName.Text.Trim(), cobBank.SelectedValue.ToString(), txtBid.Text.Trim(), cobAction.SelectedValue.ToString(),
            //    cobOp.SelectedValue.ToString(), isModify, iStart, iEnd, iIndex, iSize, pub.userid);
            DataTable dt = DA.Express.getDaifu(this.txtId.Text, cobState.SelectedIndex, txtName.Text, cobWebSite.SelectedValue.ToString(), this.cobDFSite.SelectedValue.ToString(),this.cobDaifuAction.SelectedValue.ToString(),
                iStart, iEnd, iIndex, iSize);
            dgvResult.DataSource = dt;
            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                if (dgvResult.Rows[i].Cells["state"].FormattedValue.ToString() == "已处理")
                {
                    dgvResult.Rows[i].Cells["state"].Style.BackColor = Color.Green;
                    dgvResult.Rows[i].Cells["edit"].Value = "";
                }
                else
                {
                    dgvResult.Rows[i].Cells["state"].Style.BackColor = Color.Red;
                
                }
            }
            double dIn = 0;
            double dOut = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dIn += Convert.ToDouble(dt.Rows[i]["moneysg"]);
                dOut += Convert.ToDouble(dt.Rows[i]["moneyrmb"]);
            }
            lblIn.Text = "新币收入：" + dIn.ToString("0.00");
            lblOut.Text = "人民币支出：" + dOut.ToString("0.00");

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
            DataTable dt = DA.Express.getWebsite();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "全部";
            dt.Rows.InsertAt(dr, 0);
            cobWebSite.DataSource = dt;
            cobWebSite.DisplayMember = "cnname";
            cobWebSite.ValueMember = "uwid";
            cobWebSite.SelectedIndex = 0;

            cobDFSite.DataSource = dt.Copy();
            cobDFSite.DisplayMember = "cnname";
            cobDFSite.ValueMember = "uwid";
            cobDFSite.SelectedIndex = 0;


            DataTable dtT = DA.Express.getDaifuAction();
            DataRow drt = dtT.NewRow();
            drt[0] = 0;
            drt[1] = "全部";
            dtT.Rows.InsertAt(drt, 0);
            cobDaifuAction.DataSource = dtT;
            cobDaifuAction.DisplayMember = "cnname";
            cobDaifuAction.ValueMember = "dfno";
            cobDaifuAction.SelectedIndex = 0;

            for (int i = 0; i < dgvResult.Columns.Count; i++)
            {
                dgvResult.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvResult.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ServiceReference4.ExpressSoapClient exp = new ServiceReference4.ExpressSoapClient();
            exp.Express exp = new exp.Express();
            if (dgvResult.Columns[e.ColumnIndex].Name == "edit")
            {
                edits(e.RowIndex);
            }
            else if (dgvResult.Columns[e.ColumnIndex].Name == "withdrawphoto" )
            {
                string receipturl = dgvResult.Rows[e.RowIndex].Cells["withdrawphoto"].FormattedValue.ToString();
                if (!string.IsNullOrEmpty(receipturl))
                {
                    System.Diagnostics.Process.Start(receipturl);
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
                string wdid = dgvResult.Rows[iRow].Cells["wdid"].FormattedValue.ToString();
                string uid = dgvResult.Rows[iRow].Cells["uid"].FormattedValue.ToString();
                string uname = dgvResult.Rows[iRow].Cells["uname"].FormattedValue.ToString();
                string moneysg = dgvResult.Rows[iRow].Cells["moneysg"].FormattedValue.ToString();
                string id = dgvResult.Rows[iRow].Cells["id"].FormattedValue.ToString();
                string edit = dgvResult.Rows[iRow].Cells["edit"].FormattedValue.ToString();
                if (edit.Trim() == "")
                {
                    return;
                }
                frmEditWithDraw frm = new frmEditWithDraw(wdid,uid, uname, moneysg,id,"daifu");
                frm.ShowDialog();
                
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
