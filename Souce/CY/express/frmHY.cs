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
    public partial class frmHY : UserControl
    {
        string m_usersite = "";
        public frmHY()
        {
            InitializeComponent();
        }

        private bool chk()
        {
            try
            {
                txtCust.Text = txtCust.Text.Trim();
                if (string.IsNullOrEmpty(txtCust.Text))
                {
                    lblMsg.Text = "注册号不能为空！";
                    txtCust.Focus();
                    return false;
                }

                txtPcs.Text = txtPcs.Text.Trim();
                if (string.IsNullOrEmpty(txtPcs.Text.Trim()))
                {
                    lblMsg.Text = "快递件数不能为空！";
                    txtPcs.Focus();
                    return false;
                }
                

                //if (string.IsNullOrEmpty(txtPackPCS.Text.Trim()))
                //{
                //    lblMsg.Text="包裹数不能为空！";
                //    txtPackPCS.Focus();
                //    return false;
                //} 
                 double dvalues=0;

                txtL.Text = txtL.Text.Trim();
                if (string.IsNullOrEmpty(txtL.Text.Trim()))
                {
                    lblMsg.Text = "长不能为空！";
                    txtL.Focus();
                    return false;
                }
                if(double.TryParse(txtL.Text,out dvalues))
                {
                    if(dvalues<1)
                    {
                        lblMsg.Text = "长必须大于等于1！";
                        txtL.Focus();
                        return false;
                    }
                }
                else
                {
                    lblMsg.Text = "长必须输入数字！";
                    txtL.Focus();
                    return false;
                }

               

                txtW.Text = txtW.Text.Trim();
                if (string.IsNullOrEmpty(txtW.Text.Trim()))
                {
                    lblMsg.Text = "宽不能为空！";
                    txtW.Focus();
                    return false;
                }
                if(double.TryParse(txtW.Text,out dvalues))
                {
                    if(dvalues<1)
                    {
                        lblMsg.Text = "宽必须大于等于1！";
                        txtW.Focus();
                        return false;
                    }
                }
                else
                {
                    lblMsg.Text = "宽必须输入数字！";
                        txtW.Focus();
                        return false;
                }

                txtH.Text = txtH.Text.Trim();
                if (string.IsNullOrEmpty(txtH.Text.Trim()))
                {
                    lblMsg.Text = "高不能为空！";
                    txtH.Focus();
                    return false;
                }

                if(double.TryParse(txtH.Text,out dvalues))
                {
                    if(dvalues<1)
                    {
                        lblMsg.Text = "高必须大于等于1！";
                        txtH.Focus();
                        return false;
                    }
                }
                else
                {
                    lblMsg.Text = "高必须输入数字！";
                    txtH.Focus();
                    return false;
                }




                lblgwkg.Text = lblgwkg.Text.Trim();
                if (string.IsNullOrEmpty(lblgwkg.Text.Trim()))
                {
                    lblMsg.Text = "泡重不能为空！";
                    lblgwkg.Focus();
                    return false;
                }

                txtNo.Text = txtNo.Text.Trim();
                if (string.IsNullOrEmpty(txtNo.Text.Trim()))
                {
                    lblMsg.Text = "单号不能为空！";
                    txtNo.Focus();
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Rset()
        {
            txtCust.Text = "";
            txtPcs.Text = "    1";
            txtL.Text = "";
            txtW.Text = "";
            txtH.Text = "";
            lblgwkg.Text = "";
            txtNo.Text = "";
            lblCust.Text = "";
            txtCust.Focus();
            lblV.Text = "";
            cobExpress.SelectedIndex = 0;
            txtCust.Focus();


        }
        DataTable m_dt = new DataTable();
        private void frmSGAir_Load(object sender, EventArgs e)
        {
            txtCust.Focus();
            m_dt = DA.Express.GetExpressType1();


            cobExpress.DataSource = m_dt;
            cobExpress.DisplayMember = "kdname";
            cobExpress.ValueMember = "kdnameid";
        }

        private void txtCust_Leave(object sender, EventArgs e)
        {
            try
            {
                string cust = "";
                if (txtCust.Text.Trim() == "0")
                {
                    cust = "疑问件";
                }
                //else if (txtCust.Text.Trim() == "1")
                //{
                //    cust = "查无此人";
                //}
                else
                {
                    DataRow dr = DA.Express.GetUname(txtCust.Text.Trim());
                    if (dr != null)
                    {
                        cust = dr[0].ToString();
                        m_usersite = dr[1].ToString();
                    }
                    else
                    {
                        cust = "查无此人";
                    }

                }
                lblCust.Text = cust;
                //cobExpress.Focus();
                 txtNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private double getVol(double aa)
        {
            string str = aa.ToString();
            int count = str.LastIndexOf(".");
            if (count > 0 && count + 3 < str.Length)
            {
                string str1 = str.Substring(0, count + 3);
                string str2 = str.Substring(count + 3);
                if (Convert.ToDouble(str2) > 0)
                {
                    aa = Convert.ToDouble(str1) + 0.01;
                    aa = Math.Round(aa, 2);
                }
            }
            if (aa <= 0)
            {
                aa = 0.01;
            }
            return aa;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cal_V();
                lblMsg.Text = "";
                if (!chk())
                {
                    return;
                }
                string volwiehgt = lblV.Text;
             

                bool bResult = DA.Express.Insert_HY(lblCust.Text.Trim(), txtCust.Text.Trim(), cobExpress.SelectedValue.ToString(), cobExpress.Text, txtNo.Text.Trim(),
                    txtPcs.Text.Trim(), "0", lblgwkg.Text.Trim(), volwiehgt, txtL.Text.Trim(), txtW.Text.Trim(), txtH.Text.Trim(), m_usersite, pub.username);
                //string strMsg = company + ":" + txtNo.Text + "\r\n" + "重量：" + txtgnKG + "\r\n" + "已成功提交。";
                string strMsg = string.Format("快递号：{0}\r\n共{1}件\r\n重量{2}kg  泡重{3}kg\r\n提交已经成功！", this.txtNo.Text, txtPcs.Text, "0", this.lblgwkg.Text);
                MessageBox.Show(strMsg);
                Rset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txtCust_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && txtCust.Text.Trim().Length > 0)
            {
                txtCust_Leave(null, null);

            }
        }

        private void cobExpress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNo.Focus();
            }
        }

        private void txtPcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                int iPcs = 1;
                try
                {
                    if (int.Parse(txtPcs.Text) >= 0)
                    {

                    }
                }
                catch
                {
                    lblMsg.Text = "件数请输入数字！";
                }
                txtL.Focus();
            }
            
        }

        private void txtgnKG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtL.Focus();
            }
        }

        private void txtL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtL.Text == "")
                    txtL.Text = "0";
                this.txtW.Focus();

            }
        }

        private void txtW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtW.Text == "")
                    txtW.Text = "0";
                this.txtH.Focus();
            }
    
        }

        private void txtH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtH.Text == "")
                    txtH.Text = "0";
                this.btnSave.Focus();
            }

        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label6.Text = "";
                if (txtNo.Text.Trim().Length > 0 && cobExpress.SelectedIndex == 0)
                {
                    KdApiOrderDistinguish orderapi = new KdApiOrderDistinguish();
                    KdApiOrderDistinguish.Shippers shipps = null;
                    shipps = orderapi.orderTracesSubByJson(txtNo.Text);
                    if (shipps != null)
                    {
                        string shipname = shipps.ShipperName;
                        label6.Text = shipname;
                        if (shipname.Length > 0)
                        {

                            for (int i = 0; i < m_dt.Rows.Count; i++)
                            {
                                if (shipname == m_dt.Rows[i]["kdname"].ToString())
                                {
                                    cobExpress.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }

                }
                this.txtL.Focus();

                 

            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSave_Click(null, null);
            }
        }

        void Cal_V()
        {
            try
            {
                if (txtL.Text.Length < 1 || txtH.Text.Length < 1 || txtW.Text.Length < 1)
                {
                    return;
                }
                txtL.Text = txtL.Text.Trim();
                txtH.Text = txtH.Text.Trim();
                txtW.Text = txtW.Text.Trim();
                double vol = Convert.ToDouble(txtL.Text) * Convert.ToDouble(txtW.Text) * Convert.ToDouble(txtH.Text) / 1000000;
                double volweight = Convert.ToDouble(txtL.Text) * Convert.ToDouble(txtW.Text) * Convert.ToDouble(txtH.Text) / 5000;
                lblV.Text = getVol(vol).ToString();
                lblgwkg.Text = getVol(volweight).ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Rset();  
        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }

        private void txtW_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }

        private void txtL_TextChanged(object sender, EventArgs e)
        {
            Cal_V();
        }
    }
}
