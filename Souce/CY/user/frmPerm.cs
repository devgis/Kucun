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
    public partial class frmPerm : Form
    {
        string m_UserId;
  

        public frmPerm(string strID,string strName)
        {
            InitializeComponent();
            m_UserId = strID;
            txtUser.Text = strName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmPerm_Load(object sender, EventArgs e)
        {
            dgvMenu.AutoGenerateColumns = false;
            DataTable dt = DA.user.GetMenu(m_UserId);
            dgvMenu.DataSource = dt;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDetail = (DataTable)dgvMenu.DataSource;
                DataTable dtSel = dtDetail.Clone();
                for (int i = 0; i < dgvMenu.Rows.Count; i++)
                {
                    if (dgvMenu.Rows[i].Cells[0].EditedFormattedValue != null && dgvMenu.Rows[i].Cells[0].EditedFormattedValue.ToString().ToLower() == "true")
                    {
                        dtSel.Rows.Add(dtDetail.Rows[i].ItemArray);
                    }
                }

                if (dtSel.Rows.Count < 1)
                {
                    MessageBox.Show("请至少选择一行数据！");
                    return;
                }
                
                bool bSave = DA.user.SavePerm(m_UserId, dtSel);
                if (bSave)
                    MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败，" + ex.Message);
            }
        }
    }
}
