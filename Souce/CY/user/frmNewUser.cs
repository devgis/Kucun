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
    public partial class frmNewUser : Form
    {
        string m_id;
        string m_prePWD;
        public frmNewUser()
        {
            InitializeComponent();
            cobStatus.SelectedIndex = 0;
            txtUserID.Enabled = false;
        }

        public frmNewUser(string id,bool bSelf)
        {
            InitializeComponent();
            m_id = id;
            DataTable dt = DA.user.GetUser("", id);
            DataRow dr = dt.Rows[0];
            txtPwd.Text = dr["adminpwd"].ToString();
            m_prePWD = txtPwd.Text;
            txtUserID.Text = dr["aid"].ToString();
            txtUserName.Text = dr["adminname"].ToString();
            if (dr["state"] != null && dr["state"].ToString() == "1")
                cobStatus.SelectedIndex =0;
            else
                cobStatus.SelectedIndex = 1;
            //if (bSelf)
            //{
            //    txtUserID.Enabled = false;
            //    txtUserName.Enabled = false;
            //}
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Chk()
        {
            if (txtUserID.Text == "" && !string.IsNullOrEmpty(m_id))
            {
                MessageBox.Show("用户ID不得为空！");
                txtUserID.Focus();
                return false;
            }
            if (this.txtUserName.Text == "")
            {
                MessageBox.Show("用户名不得为空！");
                txtUserName.Focus();
                return false;
            }
            if (this.txtPwd.Text == "")
            {
                MessageBox.Show("用户密码不得为空！");
                txtPwd.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Chk())
                return;
            bool bResult = false;
           
            string strSta = "1";
            if (cobStatus.SelectedIndex == 1)
            {
                strSta = "0";
            }
            
            if (string.IsNullOrEmpty(m_id))
            {
                bResult = DA.user.InsertUser(txtUserName.Text, txtPwd.Text);
            }
            else
            {
                string pwd = txtPwd.Text;
                if (m_prePWD != txtPwd.Text)
                {
                    pwd = DA.user.getMd5(pwd);
                }
                bResult = DA.user.UpdateUser(txtUserName.Text, pwd, strSta, m_id);
                
            }
            if (bResult)
            {
                this.Close();
            }

        }

        private void chkSale_CheckedChanged(object sender, EventArgs e)
        {
             

        }

        private void chkFenHuo_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
            
        }
    }
}
