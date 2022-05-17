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
    public partial class frmUser : UserControl
    {
        public frmUser()
        {
            InitializeComponent();
            dgvUser.AutoGenerateColumns = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        { 
            DataTable dt = DA.user.GetUser(txtUser.Text,"");
            dt.Columns.Add("sta");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["state"].ToString() == "1")
                {
                    dt.Rows[i]["sta"] = "在职";
                }
                else
                {
                    dt.Rows[i]["sta"] = "离职";
                    
                }
            }
            dgvUser.DataSource = dt;
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnQuery_Click(null, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewUser frm = new frmNewUser();
            frm.Show();
            btnQuery_Click(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int iRow = this.dgvUser.CurrentCell.RowIndex;
            string str = dgvUser.Rows[iRow].Cells[0].Value.ToString();
            frmNewUser frm = new frmNewUser(str,false);
            frm.Show();
            btnQuery_Click(null, null);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int iRow = dgvUser.CurrentCell.RowIndex;
            string strId = dgvUser.Rows[iRow].Cells[0].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2))
            {
                bool bResult = DA.user.DelUser(strId);
                if (bResult)
                {
                    MessageBox.Show("删除成功！");
                    btnQuery_Click(null, null);
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
      
        private void btnPerm_Click(object sender, EventArgs e)
        {
            if (this.dgvUser.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行数据！");
                return;
            }
            string strID = dgvUser.CurrentRow.Cells["id"].Value.ToString();
            string strName = dgvUser.CurrentRow.Cells["user_name"].Value.ToString();
            frmPerm frm = new frmPerm(strID,strName);
            frm.Show();
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}
