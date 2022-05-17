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
    public partial class frmEditWithDraw : Form
    {
        string m_wdid;
        string m_uid;
        string m_uname;
        string m_moneysg;
        string m_no;
        string m_menu;
        public frmEditWithDraw(string wdid,string uid, string uname, string moneysg,string no,string menu="withdraw")
        {
            m_wdid = wdid;
            m_uid = uid;
            m_uname = uname;
            m_moneysg = moneysg;
            m_no = no;
            InitializeComponent();
            int iIndex = 1;
            int iSize = 100;
            txtUname.Text = uname;
            dgvResult.AutoGenerateColumns = false;
            cobPageSize.SelectedIndex = 0;
            BindDataWithPage(1);
            DataTable dtUser = DA.Express.getUserMoney(uid);
            this.txtMoneySg.Text = dtUser.Rows[0]["moneysg"].ToString();
            this.txtSgdIn.Text = dtUser.Rows[0]["sgdin"].ToString();
            this.txtSgdOut.Text = dtUser.Rows[0]["sgdout"].ToString();
            this.txtSgdBalance.Text = dtUser.Rows[0]["sgdbalance"].ToString();
            m_menu = menu;
            
        }

        private void BindDataWithPage(int Index)
        {
            

            int iSize = Convert.ToInt32(cobPageSize.Text);
            int iIndex = Convert.ToInt32(winFormPager1.PageIndex);

            DataTable dt = DA.Express.getRecord("", "", m_uid,
             "", "", "", iIndex, iSize, "");
            dgvResult.DataSource = dt;

            //DataTable dt = DA.Express.getWithDraw(this.txtId.Text, cobState.SelectedIndex, txtName.Text, cobWebSite.SelectedValue.ToString(), iStart, iEnd, iIndex, iSize);
            //dgvResult.DataSource = dt;

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




        private void frmEditWithDraw_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if(m_menu=="daifu")
            {
                frmDaifuDetail frm = new frmDaifuDetail(m_wdid,m_moneysg,m_no,m_uname);
                frm.ShowDialog();
            }
            else
            {
                frmWithDrawDetail frm = new frmWithDrawDetail(m_wdid, m_moneysg, m_no, m_uname);
                frm.ShowDialog();
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
    }
}
