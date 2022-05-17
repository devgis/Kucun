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
    public partial class frmExpEdit : Form
    {
        DataRow m_dr ;
        string m_preExpress = "";
        string m_preType = "";
        string m_preMg = "";
        
        public frmExpEdit(string kid)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F9FF");
            this.groupBox1.ForeColor =  System.Drawing.ColorTranslator.FromHtml("#014F8A");
            LoadData(kid);
        }

        private void LoadData(string kid)
        {
            DataTable dt = DA.Express.getExp(kid, "", "", "",0, 0, 0, 1, 1);
            m_dr = dt.Rows[0];
            this.txtawb.Text = m_dr["awb"].ToString();
            this.txtcbm.Text = m_dr["cbm"].ToString();
            this.txtctns.Text = m_dr["ctns"].ToString();
            this.txtgwkg.Text = m_dr["gwkg"].ToString();
            this.txth.Text = m_dr["h"].ToString();

            DataTable dtExp = DA.Express.GetExpressType();
            cobExpress.DataSource = dtExp;
            cobExpress.DisplayMember = "kdname";
            cobExpress.ValueMember = "kdnameid";
            cobExpress.SelectedValue = m_dr["kdnameid"].ToString();
            m_preExpress = cobExpress.Text;

            this.txtl.Text = m_dr["l"].ToString();
            this.txtnwkg.Text = m_dr["nwkg"].ToString();
            this.txtplace.Text = m_dr["place"].ToString();
            this.txtchakg.Text = m_dr["chakg"].ToString();
            this.txtavgkg.Text = m_dr["avgkg"].ToString();

            txtrevise.Text = "否";
            if (m_dr["revise"].ToString().ToLower() == "true")
            {
                txtrevise.Text = "是";
            }

            string type = m_dr["type"].ToString().ToLower();
            if (type == "false")
                type = "0";
            else if (type == "true")
                type = "1";

            cobType.SelectedIndex = Convert.ToInt32(type);
            m_preType = cobType.Text;

            this.txtCust.Text = m_dr["uid"].ToString();
            this.txtcustname.Text = m_dr["custname"].ToString();
            this.txtw.Text = m_dr["w"].ToString();

            //radioButton1.Checked = false;
            //radioButton2.Checked = false;
            //radioButton3.Checked = false;
            //radioButton4.Checked = false;

            //string mg = "";
            //if (m_dr["mg"].ToString().ToLower() == "false")
            //{
            //    mg = "0";
            //}
            //else if (m_dr["mg"].ToString().ToLower() == "true")
            //{
            //    mg = "1";
            //}
            //else
            //{
            //    mg = m_dr["mg"].ToString().ToLower();
            //}

            //if (mg == "0")
            //{
            //    radioButton1.Checked = true;
            //}
            //else if (mg == "1")
            //{
            //    radioButton2.Checked = true;

            //}
            //else if (mg == "2")
            //{
            //    radioButton3.Checked = true;

            //}
            //else if (mg == "3")
            //{
            //    radioButton4.Checked = true;

            //}

            //m_preMg = mg;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_bSave)
                this.DialogResult = DialogResult.Yes;
            else
                this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void frmExpEdit_Load(object sender, EventArgs e)
        {
            this.dgvResult.AutoGenerateColumns = false;
            LoadHis();
        }

        private void LoadHis()
        {
            DataTable dt=DA.Express.GetHis(m_dr["kid"].ToString());
            this.dgvResult.DataSource = dt;
        }

        bool m_bSave = false;

        private string getV(string str1,string str2, string str3)
        { 
            return str1+":"+str2+"->"+str3+";";
        }
        private bool log()
        {
            try
            {
                string content = "";

                if (m_dr["avgkg"].ToString() != txtavgkg.Text)
                {
                    content += getV("平均重量", m_dr["avgkg"].ToString(), txtavgkg.Text);
                }

                if (m_dr["awb"].ToString() != this.txtawb.Text)
                {
                    content += getV("快递号", m_dr["awb"].ToString(), txtawb.Text);
                }

                if (m_dr["ctns"].ToString() != this.txtctns.Text)
                {
                    content += getV("箱件", m_dr["ctns"].ToString(), txtctns.Text);
                }
                if (m_dr["uid"].ToString() != this.txtCust.Text)
                {
                    content += getV("会员注册号", m_dr["uid"].ToString(), txtCust.Text);
                }
                if (m_dr["custname"].ToString() != this.txtcustname.Text)
                {
                    content += getV("会员", m_dr["custname"].ToString(), txtcustname.Text);
                }


                if (m_dr["l"].ToString() != this.txtl.Text)
                {
                    content += getV("长", m_dr["l"].ToString(), txtl.Text);

                }
                if (m_dr["w"].ToString() != this.txtw.Text)
                {
                    content += getV("宽", m_dr["w"].ToString(), txtw.Text);
                }
                if (m_dr["h"].ToString() != this.txth.Text)
                {
                    content += getV("高", m_dr["h"].ToString(), txth.Text);
                }
                if (m_dr["cbm"].ToString() != this.txtcbm.Text)
                {
                    content += getV("立方", m_dr["cbm"].ToString(), txtcbm.Text);
                }
                if (m_dr["gwkg"].ToString() != this.txtgwkg.Text)
                {
                    content += getV("实重", m_dr["gwkg"].ToString(), txtgwkg.Text);
                }
                if (m_dr["chakg"].ToString() != this.txtchakg.Text)
                {
                    content += getV("收费重量", m_dr["chakg"].ToString(), txtchakg.Text);
                }
                if (m_dr["nwkg"].ToString() != this.txtnwkg.Text)
                {
                    content += getV("泡重", m_dr["nwkg"].ToString(), txtnwkg.Text);
                }
                if (m_dr["place"].ToString() != this.txtplace.Text)
                {
                    content += getV("位置", m_dr["place"].ToString(), txtnwkg.Text);
                }



                if (m_preExpress != this.cobExpress.Text)
                {
                    content += getV("快递公司", m_preExpress, cobExpress.Text);

                }
                if (m_preType != this.cobType.Text)
                {
                    content += getV("渠道", m_preType, cobType.Text);
                }

                //string mg = "";
                //if (radioButton1.Checked)
                //    mg = "0";
                //else if (radioButton2.Checked)
                //    mg = "1";
                //else if (radioButton3.Checked)
                //{
                //    mg = "2";
                //}
                //else if (radioButton4.Checked)
                //{
                //    mg = "3";
                //}

                //if (mg != m_preMg)
                //{
                //    content += getV("敏感", m_preType, cobType.Text);

                //}
                bool bResult = false;
                if (content == "")
                    return true;
                bResult=DA.Express.InsertHis(pub.username, content, txtReamark.Text, m_dr["kid"].ToString());
                return bResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }

         
        }
        private bool chk()
        {
            try
            {
                txtCust.Text = txtCust.Text.Trim();
                if (string.IsNullOrEmpty(txtCust.Text))
                {
                    MessageBox.Show("注册号不能为空！");
                    txtCust.Focus();
                    return false;
                }

                this.txtctns.Text = txtctns.Text.Trim();
                if (string.IsNullOrEmpty(txtctns.Text.Trim()))
                {
                    MessageBox.Show("快递件数不能为空！");
                    txtctns.Focus();
                    return false;
                }

                this.txtgwkg.Text = txtgwkg.Text.Trim();
                if (string.IsNullOrEmpty(txtgwkg.Text.Trim()))
                {
                    MessageBox.Show("实重不能为空！");
                    txtgwkg.Focus();
                    return false;
                }

                txtl.Text = txtl.Text.Trim();
                if (string.IsNullOrEmpty(txtl.Text.Trim()))
                {
                    MessageBox.Show("长不能为空！");
                    txtl.Focus();
                    return false;
                }

                txtw.Text = txtw.Text.Trim();
                if (string.IsNullOrEmpty(txtw.Text.Trim()))
                {
                    MessageBox.Show("宽不能为空！");
                    txtw.Focus();
                    return false;
                }

                txth.Text = txth.Text.Trim();
                if (string.IsNullOrEmpty(txth.Text.Trim()))
                {
                    MessageBox.Show("高不能为空！");
                    txth.Focus();
                    return false;
                }

                this.txtnwkg.Text = txtnwkg.Text.Trim();
                if (string.IsNullOrEmpty(txtnwkg.Text.Trim()))
                {
                    MessageBox.Show("泡重不能为空！");
                    txtnwkg.Focus();
                    return false;
                }

                this.txtawb.Text = txtawb.Text.Trim();
                if (string.IsNullOrEmpty(txtawb.Text.Trim()))
                {
                    MessageBox.Show("单号不能为空！");
                    txtawb.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(this.txtReamark.Text.Trim()))
                {
                    MessageBox.Show("修改原因不能为空！");
                    txtReamark.Focus();
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtgwkg_TextChanged(null, null);
                if (!chk())
                    return;

                getValue();
                //string mg = "";
                //if (radioButton1.Checked)
                //    mg = "0";
                //else if (radioButton2.Checked)
                //    mg = "1";
                //else if (radioButton3.Checked)
                //{
                //    mg = "2";
                //}
                //else if (radioButton4.Checked)
                //{
                //    mg = "3";
                //}
                string utype = (cobType.SelectedIndex).ToString();
                bool bResult = DA.Express.InsertExp(txtawb.Text, txtcbm.Text, this.txtctns.Text, txtgwkg.Text, txtl.Text,
                    txtw.Text, txth.Text, this.cobExpress.Text, this.cobExpress.SelectedValue.ToString(),
                    txtnwkg.Text, txtplace.Text, "1", "", utype, txtCust.Text, txtavgkg.Text, txtchakg.Text, txtcustname.Text, txtReamark.Text, m_dr["kid"].ToString());
                if (bResult && log())
                {
                    MessageBox.Show("保存成功！");
                    this.Close();
                    //LoadHis();
                    //LoadData(m_dr["kid"].ToString());
                }
                //string sql = string.Format("insert air_awb(" +
                //                            "username,custname,uid," +
                //                            "type,mg,adddate,kdname," +
                //                            "kdnameid,awb,ctns,nwkg,gwkg," +
                //                            "cbm,l,w,h) " +
                //                            "values('{0}','{1}','{2}','{3}','{4}'," +
                //                            "'{5}','{6}','{7}','{8}','{9}'," +
                //                            "'{10}','{11}','{12}','{13}','{14}'," +
                //                            "'{15}') ",
                //                            pub.uname, custname, uid,
                //                            "1", mg, time, kdname,
                //                            kdnameid, awb, ctns, nwkg, gwkg,
                //                            cbm, l, w, h);


                m_bSave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtl_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }


        void Cal_V()
        {
            try
            {
                if (txtl.Text.Length < 1 || txth.Text.Length < 1 || txtw.Text.Length < 1)
                {
                    return;
                }
                txtl.Text = txtl.Text.Trim();
                txth.Text = txth.Text.Trim();
                txtw.Text = txtw.Text.Trim();
                double vol = Convert.ToDouble(txtl.Text) * Convert.ToDouble(txtw.Text) * Convert.ToDouble(txth.Text) / 1000000;
                double volweight = Convert.ToDouble(txtl.Text) * Convert.ToDouble(txtw.Text) * Convert.ToDouble(txth.Text) / 5000;
                txtchakg.Text = System.Math.Round(volweight, 4).ToString();
                txtcbm.Text = System.Math.Round(vol, 4).ToString();
            }
            catch (Exception ex)
            {
                

            }
        }

        private void txtw_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }

        private void txth_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }

        void getValue()
        {
            if (txtCust.Text.Trim() == m_dr["uid"].ToString())
                return;
            string cust = "";
            if (txtCust.Text.Trim() == "0")
            {
                cust = "疑问件";
            }
            else if (txtCust.Text.Trim() == "1")
            {
                cust = "查无此人";
            }
            else
            {

                cust = CY.DA.user.GetUname(txtCust.Text.Trim());
            }
            txtcustname.Text = cust;
        }
        private void txtuid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
            
                getValue();
           
          
            }
            catch (Exception ex)
            {
                //new msg(ex.Message).ShowDialog();

            }
        }

        private void txtuid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCust_Leave(object sender, EventArgs e)
        {
            
                getValue();
        }

        private void txtgwkg_TextChanged(object sender, EventArgs e)
        {
            if (txtgwkg.Text == "")
                txtgwkg.Text = "0";
            if (txtnwkg.Text == "")
                txtnwkg.Text = "0";
            double gwkg = Convert.ToDouble(txtgwkg.Text);
            double nwkg = Convert.ToDouble(txtnwkg.Text);
            double avgkg=0;
            double maxavg = 0;

            if (gwkg == 0)
                avgkg = nwkg;
            else if (nwkg == 0)
                avgkg = gwkg;
            else
            {
                avgkg = (gwkg + nwkg) / 2;
            }

            if (gwkg > nwkg)
                maxavg = gwkg;
            else
                maxavg = nwkg;
            txtavgkg.Text = avgkg.ToString();
            txtchakg.Text = maxavg.ToString();


        }
    }
}
