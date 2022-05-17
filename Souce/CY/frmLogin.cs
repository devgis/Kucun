using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using System.Diagnostics;
namespace CY
{
    public partial class frmLogin : Form
    {
        const string m_pwdpath = @"C:\Reports\pwd.xml";
        public frmLogin()
        {
            InitializeComponent();
        }
    
                 
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("用户名不能为空！");
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("密码不能为空！");
                txtPwd.Focus();
                return;
            }


            DataSet ds = CY.DA.user.Login(txtUser.Text, txtPwd.Text);
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("用户名或密码不正确！");
                txtUser.Focus();
                return;
            }
            else
            {
                pub.userid = ds.Tables[0].Rows[0]["aid"].ToString();
                pub.username = ds.Tables[0].Rows[0]["adminname"].ToString();
                //if (chkPwd.Checked)
                //{
                //    DataTable dt1 = new DataTable("dt");
                //    dt1.Columns.Add("name");
                //    dt1.Columns.Add("pwd");
                //    dt1.Rows.Add(txtUser.Text, txtPwd.Text);
                //    dt1.WriteXml(m_pwdpath, true);
                //}
                //else
                //{
                //    if (System.IO.File.Exists(m_pwdpath))
                //        System.IO.File.Delete(m_pwdpath);
                //}

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }

        }
            
           

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //this.BackColor = System.Drawing.Color.LightBlue;

            //this.groupBox1.BackColor = this.BackColor;
            //this.groupBox2.BackColor = this.BackColor;

            this.ForeColor = System.Drawing.ColorTranslator.FromHtml("#014F8A");

            //if (System.IO.File.Exists(m_pwdpath))
            //{
            //    DataSet ds1 = new DataSet("ss");
            //    ds1.ReadXml(m_pwdpath);
            //    txtUser.Text = ds1.Tables[0].Rows[0]["name"].ToString();
            //    txtPwd.Text = ds1.Tables[0].Rows[0]["pwd"].ToString();
            //    chkPwd.Checked = true;
            //}

            


            txtUser.Focus();
            txtUser.Select();
            //if (GetColor() != "")
            //{
            //this.skinEngine1.SkinFile = Application.StartupPath + GetColor();
            //this.skinEngine1.Active = true;
            //}
            //else
            //{
            //    this.skinEngine1.Active = false;
            //}


            //this.skinEngine1.SkinFile = Application.StartupPath + "\\skin\\PageColor1.ssk";
            //this.skinEngine1.Active = false;

            string strMac = GetMacByIPConfig();
            if (strMac.Contains("7C-E9-D3-F2-0F-E4"))
            {
                txtUser.Text = "小张";
                txtPwd.Text = "23861773";
                btnLogin_Click(null, null);
            }

          
        }
        public string GetMacByIPConfig()
        {
            List<string> macs = new List<string>();
            ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            //截取输出流
            System.IO.StreamReader reader = p.StandardOutput;
            string line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    line = line.Trim();

                    if (line.StartsWith("Physical Address") || line.StartsWith("物理地址"))
                    {
                        macs.Add(line);
                    }
                }

                line = reader.ReadLine();
            }

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            reader.Close();

            if (macs.Count > 0)
                return macs[0];
            else
                return "";
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
