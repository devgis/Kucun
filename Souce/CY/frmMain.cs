using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using System.Threading;
using CY.Controls;


namespace CY
{
    public partial class frmMain : Form
    {
        DataTable dt = new DataTable();
        public frmMain()
        {
            InitializeComponent();
            lblTime.Text = DateTime.Now.ToString();
            //if (Users.bExistApp)
            //{
            //    timer1.Enabled = false;
            //}
        }
        //private string GetColor()
        //{
        //    return AppSettings.GetAppSettingValue("Color");
        //}
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            lblUser.Text = string.Format(" 当前用户：{0}       ",pub.username);
            int n = (int)DateTime.Now.DayOfWeek;
            string[] weekDays = { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            lblWeek.Text = "   " + weekDays[n] + "   ";
            //lblTitle1.ForeColor = lblTtile2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C60001");
            //lblTitle1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#C60001");
            
            //dt.Columns.Add("menu1");
            //dt.Columns.Add("menu2");
            //dt.Rows.Add("运单信息", "快递记录");
            //dt.Rows.Add("运单信息", "仓库记录");
            //dt.Rows.Add("系统设置", "用户信息");
            if (pub.username == "allen9")
            {
                dt = DA.user.GetUserPer("");
            }
            else
            {
                dt = DA.user.GetUserPer(pub.userid);
            }
            List<string> lstMenu = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string menu1 = dt.Rows[i]["menu1"].ToString().Trim();
                if (!lstMenu.Contains(menu1))
                    lstMenu.Add(menu1);
            }

            IconPanel ip1 = new IconPanel();
            IconPanel ip2 = new IconPanel();
            IconPanel ip3 = new IconPanel();
            IconPanel ip4 = new IconPanel();
            IconPanel ip5 = new IconPanel();
            IconPanel ip6 = new IconPanel();
            IconPanel ip7 = new IconPanel();
            if (lstMenu.Contains("运单信息"))
                outlookBar1.AddBand("运单信息", ip1);
            if (lstMenu.Contains("包裹信息"))
                outlookBar1.AddBand("包裹信息", ip7);
            if (lstMenu.Contains("财务信息"))
                outlookBar1.AddBand("财务信息", ip2);
            if (lstMenu.Contains("客户和服务商"))
                outlookBar1.AddBand("客户和服务商", ip3);
            if (lstMenu.Contains("基础资料维护"))
                outlookBar1.AddBand("基础资料维护", ip4);
            if (lstMenu.Contains("统计分析"))
                outlookBar1.AddBand("统计分析", ip5);
        

            List<string> lstMenu2 = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Menu1 = dt.Rows[i]["Menu1"].ToString().Trim();
                string Menu2 = dt.Rows[i]["Menu2"].ToString().Trim();
                string icon = @"icon\" + dt.Rows[i]["Menuicon"].ToString().Trim() + ".ico";
                if (!lstMenu2.Contains(Menu2))
                    lstMenu2.Add(Menu2);
                else
                    continue;
                if (icon.Length == 0)
                    icon = @"icon\credit_card.ico";



                if (Menu1 == "运单信息")
                {

                    ip1.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));

                }
                else if (Menu1 == "财务信息")
                {
                    ip2.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));
                }
                else if (Menu1 == "客户和服务商")
                {
                    ip3.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));
                }
                else if (Menu1 == "基础资料维护")
                {
                    ip4.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));
                }
                else if (Menu1 == "统计分析")
                {
                    ip5.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));
                }
                else if (Menu1 == "包裹信息")
                {
                    ip7.AddIcon(Menu2, Image.FromFile(icon), new EventHandler(PanelEvent));
                }

            }
            pub.lstmenu2 = lstMenu2;
            outlookBar1.SelectBand(0);
        }
        public void PanelEvent(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            CY.Controls.PanelIcon panelIcon = ctrl.Tag as CY.Controls.PanelIcon;
            string strMenuName = panelIcon.pMenu;

            this.Text = strMenuName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["menu2"].ToString() == strMenuName)
                {
                    Loads(dt.Rows[i]["url"].ToString());
                    break;
                }
            }
            


             
        }
        System.Collections.Hashtable hsForm = new System.Collections.Hashtable();
        private void Loads(string strFrm)
        {
            UserControl frm;
            if (pnlRight.Controls.Count > 0)
            {
                this.pnlRight.Controls.RemoveAt(0);
                this.pnlRight.Controls.Clear();
            }

            if (!hsForm.ContainsKey(strFrm))
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly(); // 获取当前程序集 
                object obj = assembly.CreateInstance(strFrm); // 创建类的实例，返回为 object 类型，需要强制类型转换 
                frm = (UserControl)obj;
                hsForm.Add(strFrm, frm);
            }
            else
            {
                frm = (UserControl)hsForm[strFrm];
            }
            pnlRight.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
        }


        private void Loads(UserControl frm)
        {
            if (pnlRight.Controls.Count > 0)
            {
                this.pnlRight.Controls.RemoveAt(0);
                this.pnlRight.Controls.Clear();
            }
           
            pnlRight.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Application.Exit();
            }
            else
                e.Cancel = true;
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "当前时间："+DateTime.Now.ToString();
            if (DateTime.Now.Second % 30 == 0)
            {
                DA.user.Login("1", "123456"); 
            }
            
            
        }


        private void picSign_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确定退出吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                Application.Exit();
            //}
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

       
    

        private void picSign_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmNewUser frm = new frmNewUser(pub.userid,true);
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel2.Text.Contains("隐藏"))
            {
                toolStripStatusLabel2.Text = "展开菜单>>";
             
                panel1.Visible = false;
            }
            else
            {
                toolStripStatusLabel2.Text = "<<隐藏菜单";
               
                panel1.Visible = true;


            }
        }

         
        

    }
}
