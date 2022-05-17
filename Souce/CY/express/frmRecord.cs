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
    public partial class frmRecord : UserControl
    {
        public frmRecord()
        {
            InitializeComponent();
        }
        private void BindDataWithPage(int Index)
        {
            //string exp_no = txtExpNo.Text.Trim();
            //string UName = txtUName.Text.Trim();
         
            DateTime iStart = DateTime.Now.AddYears(-50);
            DateTime iEnd = DateTime.Now.AddYears(50);

            if (dtpStart.Checked)
            {
                iStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd")); ;
            }

            if (this.dtpEnd.Checked)
            {
                iEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd")) ;
                iEnd = iEnd.AddDays(1);
            }

            long lstart = pub.ConvertDateTimeInt(iStart);
            long lend = pub.ConvertDateTimeInt(iEnd);
            winFormPager1.PageIndex = Index;
            int iSize = Convert.ToInt32(cobPageSize.Text);
            int iIndex = Convert.ToInt32(winFormPager1.PageIndex);
 

            //getRecord(string recordid, string uname, string uid, string website, string addtimes, string addtimee, int pageNow, int pageSize)

            DataTable dt = DA.Express.getRecord(this.txtRecordid.Text.Trim(),this.txtUname.Text.Trim(),txtUid.Text.Trim(),
                this.cobWebsite.SelectedValue.ToString(), lstart.ToString(), lend.ToString(), iIndex, iSize,cobAction.SelectedValue.ToString());

            dgvResult.DataSource = dt;
            lbl0.Text = "";
            if (pub.lstmenu2.Contains("交易记录汇总"))
            { 
                double dIn = 0;
                double dOut = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strIn = dt.Rows[i]["moneysg1"].ToString();
                    if (!string.IsNullOrEmpty(strIn.Trim()))
                        dIn += Convert.ToDouble(strIn.Trim());
                    string strOut = dt.Rows[i]["moneysg0"].ToString();
                    if (!string.IsNullOrEmpty(strOut.Trim()))
                        dOut += Convert.ToDouble(strOut.Trim());
                
                }
                lbl0.Text = "合计   进账:" + dIn.ToString("F2") + "" + "   出账:" + dOut.ToString("F2");
            }
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dIn += Convert.ToDouble(dt.Rows[i]["debit"]);
            //    dOut += Convert.ToDouble(dt.Rows[i]["credit"]);
            //}
            
           
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
            if (pub.lstmenu2.Contains("交易记录汇总"))
            {
                cPanel1.Height = 55;
            }
            else
            {
                cPanel1.Height = 39;
            }
            this.cobPageSize.SelectedIndexChanged -= new System.EventHandler(this.cobPageSize_SelectedIndexChanged);
            cobPageSize.SelectedIndex = 0;
            winFormPager1.PageSize = Convert.ToInt32(cobPageSize.Text);
            this.cobPageSize.SelectedIndexChanged += new System.EventHandler(this.cobPageSize_SelectedIndexChanged);
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
            cobWebsite.DataSource = dt;
            cobWebsite.DisplayMember = "cnname";
            cobWebsite.ValueMember = "uwno";

            DataTable dtAction = DA.Express.getrecordaction();
            DataRow drAction = dtAction.NewRow();
            drAction[0] = 0;
            drAction[1] = "全部";
            dtAction.Rows.InsertAt(drAction, 0);
            cobAction.DataSource = dtAction;
            cobAction.DisplayMember = "cnname";
            cobAction.ValueMember = "actionno";
        


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
