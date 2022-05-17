﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;

namespace CY.express
{
    public partial class frmWithDrawDetail : Form
    {

        exp.Express exp = new exp.Express();
        //System.Collections.Hashtable m_hs = new System.Collections.Hashtable();
        string m_bid = "";
        double m_pre_amt = 0;
        string m_filename = "";
        double m_dBalance = 0;
        DateTime m_preDateTime;
        string m_prebankid = "";

        //string m_uid;
        //string m_uname;
        string m_moneysg;
        string m_no;
        string m_wdid;

        public frmWithDrawDetail(string wdid,string moneysg,string no,string uname)
        {
            if (moneysg == "")
            {
                moneysg = "0";
            }
            m_wdid = wdid;
            m_moneysg = moneysg;
            m_no = no;

            InitializeComponent();

            txtAmt.Text = (Convert.ToDouble(m_moneysg) - 1).ToString();
            txtpayid.Text = no + "-" + uname; ;

            DataTable dt = DA.Express.getBankName(pub.userid);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            cobBank.DataSource = dt; 
            cobBank.DisplayMember = "bankname";
            cobBank.ValueMember = "bid";
          

            DataTable dtBank = DA.Express.getAction();

            DataRow drBank = dtBank.NewRow();
            drBank[0] = 0;
            drBank[1] = "";
            dtBank.Rows.InsertAt(drBank, 0);

            cobAction.DataSource = dtBank;
            cobAction.DisplayMember = "bankactionname";
            cobAction.ValueMember = "bid";
            cobAction.SelectedValue = "59";

            //for (int i = 0; i < dtBank.Rows.Count; i++)
            //{
            //    m_hs.Add(dtBank.Rows[i]["bid"].ToString(), dtBank.Rows[i]["actiontype"].ToString());
            //}


            //if (!string.IsNullOrEmpty(bid))
            //{
            //    cobBank.Enabled = false;
            //    this.Text = "修改银行记录";
            //    DataTable dtB = DA.Express.getBank("","", bid, "", "", 0, DateTime.Now.AddYears(-50), DateTime.Now.AddYears(50), 1, 1,"");
            //    DataRow drB = dtB.Rows[0];
            //    dateTimePicker1.Value = Convert.ToDateTime(drB["transfertime"]);
            //    txtDate.Text = Convert.ToString(drB["transfertime"]);
            //    m_preDateTime=Convert.ToDateTime(drB["transfertime"]);
            //    cobBank.SelectedValue = drB["banknameid"].ToString();
            //    cobAction.SelectedValue = drB["action"].ToString();
            //    m_prebankid = drB["banknameid"].ToString(); 
            //    double dValue = Convert.ToDouble(drB["debit"]);
            //    m_pre_amt = Convert.ToDouble(drB["debit"])-Convert.ToDouble(drB["credit"]);
            //    if (this.lblIn.Text == "出账金额")
            //    {
            //        dValue = Convert.ToDouble(drB["credit"]);
            //    }
            //    txtAmt.Text = dValue.ToString();
            //    txtpayid.Text = drB["payid"].ToString();
            //    txtremark.Text = drB["adminmark"].ToString();
            //    m_dBalance=Convert.ToDouble(drB["balance"]);
            //    string receipturl = drB["receipturl"].ToString();
            //    m_filename = receipturl;

            //    string filename = Application.StartupPath + "\\" + receipturl;
            //    byte[] byteImge = exp.downfilebyte(ref receipturl);
            //    if (byteImge != null)
            //    {
            //        Image img = BytesToImage(byteImge);
            //        pictureBox1.Image = img;
            //    }
            //}
            txtAdmin.Text = pub.username;
        
        }

        public void showimg(Image imgs)
        {
            //pictureBox1.Image.Dispose();
            pictureBox1.Image = imgs;
            this.Visible = true;
            frm.ParentForm.Visible = true;
        }

        public static Image BytesToImage(byte[] buffer)
        {
            try
            {
                MemoryStream ms = new MemoryStream(buffer);
                Image image = System.Drawing.Image.FromStream(ms);
                return image;
            }
            catch
            {
                return null;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        public Image img;

        private bool chk()
        {
            if (this.txtDate.Text.Trim()=="")
            {
                MessageBox.Show("请选择正确的转帐日期！");
                txtDate.Focus();
                return false;
            }
           
            

            if (cobBank.SelectedIndex == 0)
            {
                MessageBox.Show("银行账户不能为空！");
                cobBank.Focus();
                return false;
            }
             
            DateTime dts=DA.Express.getMaxTranTime(cobBank.SelectedValue.ToString());
            if (this.dateTimePicker1.Value < dts)
            {
                MessageBox.Show("转帐日期不得大于选择已关账日期之前！");
                return false;
            }
            if (cobAction.SelectedIndex == 0)
            {
                MessageBox.Show("转账用途不能为空！");
                cobAction.Focus();
                return false;
            }

            if (txtAmt.Text == "")
            {
                MessageBox.Show("进/出账金额不能为空！");
                txtAmt.Focus();
                return false;
            }
            double dAmt = 0;
            if (!Double.TryParse(txtAmt.Text,out dAmt))
            {
                MessageBox.Show("进/出账金额必须是数字！");
                txtAmt.Focus();
                return false;
            }
            if (txtpayid.Text == "")
            {
                MessageBox.Show("交易编号不能为空！");
                txtpayid.Focus();
                return false;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("必须要上传转账凭证！");
                return false;
            }
            return true;
        }
        private string getV(string str1, string str2, string str3)
        {
            return str1 + ":" + str2 + "->" + str3 + ";";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chk())
                    return;

                double debit = 0;
                double credit = 0;
                //if (lblIn.Text == "进账金额")
                //{
                //    debit = Double.Parse(txtAmt.Text);
                //}
                //else
                //{
                credit = Double.Parse(txtAmt.Text);
                //}

                string filename = m_filename;
                if (this.bChange)
                {
                    filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    filename = filename + ".png";
                    string path = Application.StartupPath + "//" + filename;
                    string path1 = Application.StartupPath + "//t_" + filename;
                    pictureBox1.Image.Save(path);
                    Image img = pic.GetPicThumbnail(path, path1);
                    try
                    {
                        byte[] byteImg = ImageToBytes(img);
                        string str = exp.upfilebyte(byteImg, ref filename);
                        if (!str.Contains("上传成功"))
                        {
                            MessageBox.Show("上传图片失败，" + str);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("上传图片失败，" + ex.Message);
                        return;
                    }
                    System.IO.File.Delete(path);
                }
                bool bResult = false;
                
                if (!string.IsNullOrEmpty(m_bid))
                {
                    double dChange = debit - credit - m_pre_amt;
                    if (m_preDateTime > dateTimePicker1.Value)
                        m_preDateTime = dateTimePicker1.Value;
                    bResult = DA.Express.UpdateBank(m_bid,cobBank.SelectedValue.ToString(), pub.userid,
                       this.dateTimePicker1.Value, debit.ToString(), credit.ToString(), m_dBalance, txtpayid.Text, filename,
                       cobAction.SelectedValue.ToString(), txtremark.Text, "1", dChange, m_preDateTime, m_prebankid);
                }
                else
                {
                    
                    bResult = DA.Express.InsertBank(cobBank.SelectedValue.ToString(), pub.userid,
                        this.dateTimePicker1.Value, debit.ToString(), credit.ToString(), "0", txtpayid.Text, filename,
                        cobAction.SelectedValue.ToString(), txtremark.Text, "0");
                    if (bResult)
                    {
                        DA.Express.InsertWithDraw(filename, txtpayid.Text, txtremark.Text, pub.username, m_wdid);
                    }
                }

                if (bResult)
                {
                    MessageBox.Show("保存成功！");
                    System.IO.File.Delete(filename);
                    //frm.requery();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public  byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                //if (format.Equals(ImageFormat.Jpeg))
                //{
                //    image.Save(ms, ImageFormat.Jpeg);
                //}
                //else if (format.Equals(ImageFormat.Png))
                //{
                image.Save(ms, ImageFormat.Png);
                //}
                //else if (format.Equals(ImageFormat.Bmp))
                //{
                //    image.Save(ms, ImageFormat.Bmp);
                //}
                //else if (format.Equals(ImageFormat.Gif))
                //{
                //    image.Save(ms, ImageFormat.Gif);
                //}
                //else if (format.Equals(ImageFormat.Icon))
                //{
                //    image.Save(ms, ImageFormat.Icon);
                //}
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        private void ubtn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewBank_Load(object sender, EventArgs e)
        {
        
        }

        private void cobAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cobAction.SelectedIndex >= 0)
            //{
            //    string str=cobAction.SelectedValue.ToString();
            //    if (!m_hs.Contains(str))
            //        return;
            //    if(m_hs[str].ToString().ToLower()=="true")
            //    {
            //        lblIn.Text = "进账金额";
            //    }
            //    else 
            //    {
            //        lblIn.Text = "出账金额";
            //    }
            //}
        }
        public frmBank frm = new frmBank();
        private void btnUp_Click(object sender, EventArgs e)
        {
            //ScreenCutter.MainForm m = new ScreenCutter.MainForm();
            //m.frmbanks = this;
            //this.Visible = false;
            //frm.ParentForm.Visible = false;
            //m.ShowDialog();
            //m.Close();

            //frm.ParentForm.Hide();
            //this.Hide();
            //Form2 form1 = new Form2();
            //form1.InstanceRef = this;
            //form1.ShowDialog();
            //pictureBox1.Image = pub.img;
            
          
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void frmNewBank_Shown(object sender, EventArgs e)
        {
             
        }

        private void frmNewBank_VisibleChanged(object sender, EventArgs e)
        {
            //if (pictureBox1.Image != null)
            {

                //pictureBox1.Image = Clipboard.GetImage();
                //System.Diagnostics.Process.Start("tmp.png");
            }
        }

        private void frmNewBank_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        bool bChange = false;
        private void ubtn3_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image=Clipboard.GetImage();
            Clipboard.Clear();
            bChange = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = dateTimePicker1.Text;
        }
    }
}
