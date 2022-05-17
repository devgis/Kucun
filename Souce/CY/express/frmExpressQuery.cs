using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CY
{
    public partial class frmExpressQuery : UserControl
    {
         const string CAPTION="快递查询";
         const string FILENAME = "dgv.xml";
        public frmExpressQuery()
        {
            InitializeComponent();
            this.dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpStart.Checked = false;
            
        }

        private void frmExpressQuery_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F9FF");

            this.cPanel1.BackColor = this.BackColor;
            this.cPanel2.BackColor = this.BackColor;
            //this.groupBox6.BackColor = this.BackColor;


            this.cPanel1.ForeColor = this.cPanel2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#014F8A");
            this.dgvResult.AutoGenerateColumns = false;
            //CY.Controls.pubCtr.setcmb(ref cobCust, true);
            DataTable dt= DA.Express.getOp();
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            cobOp.DataSource = dt;
            cobOp.DisplayMember = "adminname";
            cobOp.ValueMember = "aid";
            cobPageSize.SelectedIndex = 0;


            if (System.IO.File.Exists(FILENAME))
            {
                DataSet ds = new DataSet("ds");
                ds.ReadXml(FILENAME);
                DataTable dtCol = ds.Tables[0];
                for (int i = 0; i < dgvResult.Columns.Count; i++)
                {
                    for (int j = 0; j < dtCol.Rows.Count; j++)
                    {
                        if (dgvResult.Columns[i].Name == dtCol.Rows[j]["key"].ToString())
                        {
                            dgvResult.Columns[i].Width = Convert.ToInt32(dtCol.Rows[j]["width"]);
                            dgvResult.Columns[i].DisplayIndex = Convert.ToInt32(dtCol.Rows[j]["index"]);
                            continue;
                        }
                    }
                }
            }
            this.dgvResult.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvResult_ColumnWidthChanged);
            this.dgvResult.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvResult_ColumnDisplayIndexChanged);

            btnQuery_Click(null, null);
           //aid,adminname
        }
        public static int GetTime()
        {
            System.DateTime time = DateTime.Now;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindDataWithPage(1);

            
        }



        private void btnDel_Click(object sender, EventArgs e)
        {
          
        }


        private void txtCust_MouseClick(object sender, MouseEventArgs e)
        {
            
           
        }

        private void txtCust_TextChanged(object sender, EventArgs e)
        {

        }
        private void cPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void U_SelCol_Load(object sender, EventArgs e)
        {

        }

        

        private void ubtn1_Click(object sender, EventArgs e)
        {
             

        }

        private void winFormPager1_PageIndexChanged(object sender, EventArgs e)
        {
            winFormPager1.PageSize = Convert.ToInt32(cobPageSize.Text);
            BindDataWithPage(winFormPager1.PageIndex);
        }

        /// <summary>
        /// 绑定第Index页的数据
        /// </summary>
        /// <param name="Index"></param>
        private void BindDataWithPage(int Index)
        {
            string exp_no = txtExpNo.Text.Trim();
            string UName = txtUName.Text.Trim();
            string op = cobOp.Text.Trim();
            int iStart = 0;
            int iEnd = 0;
            if (dtpStart.Checked)
            {
                iStart = DA.Express.GetTime(dtpStart.Value);
            }

            if (this.dtpEnd.Checked)
            {
                iEnd = DA.Express.GetTime(dtpEnd.Value);
            }

            int iSize = Convert.ToInt32(cobPageSize.Text);
            int iIndex = Convert.ToInt32(winFormPager1.PageIndex);
            int isModify = 0;
            isModify = cobModify.SelectedIndex;
            
            DataTable dt = DA.Express.getExp("",exp_no, UName, op,isModify, iStart, iEnd, iIndex, iSize);
            dt.Columns.Add("adddate1",typeof(DateTime));
            dt.Columns.Add("revise1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime date = new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt32(dt.Rows[i]["adddate"]));
                dt.Rows[i]["adddate1"] = date;
                if (dt.Rows[i]["revise"].ToString().ToUpper() == "TRUE")
                {
                    dt.Rows[i]["revise1"] = "是";
                }
                else
                {
                    dt.Rows[i]["revise1"] = "否";
                }
            }

            dgvResult.DataSource = dt;

            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                if (dgvResult.Rows[i].Cells["revise"].Value.ToString() == "是")
                {
                    dgvResult.Rows[i].Cells["revise"].Style.BackColor = Color.Red;
                }
            }

            winFormPager1.PageIndex = Index;
            //获取并设置总记录数
            if (Index == 1)
            {
                winFormPager1.RecordCount = Convert.ToInt32(dt.TableName);
            }
            winFormPager1.Refresh();

            if (dt == null || dt.Rows.Count < 1)
            {
                dgvResult.DataSource = null;
                winFormPager1.ResetText();
            }

        }

        private void cobPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            winFormPager1.ResetText();
            winFormPager1.PageIndex = 1;
            winFormPager1.PageSize = Convert.ToInt32(cobPageSize.Text);
            BindDataWithPage(1);
        }
      
        

        private void dgvResult_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
              
        }

        private void dgvResult_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            save();
        }

        private void dgvResult_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            save();
        }

        private void save()
        {
            DataSet ds = new DataSet("dgv");
            DataTable dt = new DataTable("dt");

            dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("width");
            dt.Columns.Add("index");
            for (int i = 0; i < dgvResult.Columns.Count; i++)
            {
                dt.Rows.Add(dgvResult.Columns[i].Name, dgvResult.Columns[i].Width, dgvResult.Columns[i].DisplayIndex);
            }
            ds.Tables.Add(dt);

            if (System.IO.File.Exists(FILENAME))
            {
                System.IO.File.Delete(FILENAME);
            }
            ds.WriteXml(FILENAME);
        }

        private void dgvResult_ColumnWidthChanged_1(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int iRow = dgvResult.CurrentCell.RowIndex;
            string kid = dgvResult.Rows[iRow].Cells["kid"].FormattedValue.ToString();
            express.frmExpEdit frm = new express.frmExpEdit(kid);
            DialogResult dr=frm.ShowDialog();
            if(dr==DialogResult.Yes)
                btnQuery_Click(null, null);

        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResult.Columns[e.ColumnIndex].Name == "edit")
            {
                string kid = dgvResult.Rows[e.RowIndex].Cells["kid"].FormattedValue.ToString();
                express.frmExpEdit frm = new express.frmExpEdit(kid);
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.Yes)
                    btnQuery_Click(null, null);
            }
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string kid = dgvResult.Rows[e.RowIndex].Cells["kid"].FormattedValue.ToString();
            express.frmExpEdit frm = new express.frmExpEdit(kid);
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Yes)
                btnQuery_Click(null, null);
        }
    }
}
