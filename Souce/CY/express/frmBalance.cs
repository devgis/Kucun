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
    public partial class frmBalance : Form
    {
        DateTime dt1 = DateTime.Now.AddMonths(-1);
        DateTime dt2 = DateTime.Now.AddMonths(-2);
        public frmBalance()
        {
            InitializeComponent();
            //DateTime dt3 = DateTime.Now.AddMonths(-3);
            string str1 = dt1.Year.ToString() + dt1.Month.ToString("-00");
            string str2 = dt2.Year.ToString() + dt2.Month.ToString("-00");
            //string str3 = dt3.Year.ToString() + dt3.Month.ToString("00");
            cobYM.Items.Add("");
            cobYM.Items.Add(str1);
            cobYM.Items.Add(str2);
            //cobYM.Items.Add(str3);
            cobYM.SelectedIndex = 0;

        }

        private void ubtn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {
            this.dgvResult.AutoGenerateColumns = false;
            DataTable dt = DA.Express.getBalance();
            this.dgvResult.DataSource = dt;


            DataTable dts = DA.Express.getBankName(pub.userid);
            DataRow dr = dts.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dts.Rows.InsertAt(dr, 0);
            cobBank.DataSource = dts;
            cobBank.DisplayMember = "bankname";
            cobBank.ValueMember = "bid";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (cobYM.SelectedIndex == 0)
                {
                    MessageBox.Show("请先选择关账月份！");
                    cobYM.Focus();
                    return;
                }

                if (this.cobBank.SelectedIndex == 0)
                {
                    MessageBox.Show("请先选择银行账户！");
                    cobBank.Focus();
                    return;
                }

                string ym_last = "";
                string ym_next = "";
                if (cobYM.SelectedIndex == 1)
                {
                    ym_last = dt1.AddMonths(-1).Year.ToString() + dt1.AddMonths(-1).Month.ToString("-00");
                    ym_next = dt1.AddMonths(1).Year.ToString() + dt1.AddMonths(1).Month.ToString("-00");
                }
                else if (cobYM.SelectedIndex == 2)
                {
                    ym_last = dt2.AddMonths(-1).Year.ToString() + dt2.AddMonths(-1).Month.ToString("-00");
                    ym_next = dt2.AddMonths(1).Year.ToString() + dt2.AddMonths(1).Month.ToString("-00");
                }
                bool bSave = DA.Express.InsertBalance(ym_last, cobYM.Text, cobYM.Text + "-01", ym_next + "-01",pub.userid,cobBank.SelectedValue.ToString());
                if (bSave)
                {
                    MessageBox.Show("结帐成功！");
                    frmBalance_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("dup"))
                    MessageBox.Show("该月已经月结过！");
                else
                    MessageBox.Show(ex.Message);
            }
        }
    }
}
