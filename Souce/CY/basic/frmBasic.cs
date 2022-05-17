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
    public partial class frmBasic :UserControl
    {
        public frmBasic()
        {
            InitializeComponent();
            cTabControl1_SelectedIndexChanged(null, null);
        }

        private void dgvPayMode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvPayMode.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvPayMode.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelMode(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void cTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cTabControl1.SelectedIndex == 0)
            {
                dgvPayMode.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetPayMode();
                dgvPayMode.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 1)
            {
                this.dgvIncomtype.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetInComType();
                dgvIncomtype.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 2)
            {
                this.dgvFeeType.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetFeeType();
                dgvFeeType.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 3)
            {
                this.dgvDelivery.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetDelivery();
                dgvDelivery.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 4)
            {
                this.dgvCustfrom.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetCustform();
                dgvCustfrom.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 5)
            {
                this.dgvCurrency.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetCoin();
                dgvCurrency.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 6)
            {
                this.dgvCountry.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetCountry();
                dgvCountry.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 7)
            {
                this.dgvProduct.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetProduct();
                dgvProduct.DataSource = dt;
            }
            else if (cTabControl1.SelectedIndex == 8)
            {
                this.dgvProduct.AutoGenerateColumns = false;
                DataTable dt = DA.basicData.GetBankInfo();
                this.dgvBankinfo.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cTabControl1.SelectedIndex == 0)
            {
                dgvPayMode.CurrentCell = dgvPayMode.Rows[dgvPayMode.Rows.Count - 1].Cells[2];
                for(int i=0;i<dgvPayMode.Rows.Count-1;i++)
                {
                    string id = dgvPayMode.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult=DA.basicData.InsertMode(dgvPayMode.Rows[i].Cells[1].Value.ToString(),
                            dgvPayMode.Rows[i].Cells[2].Value.ToString(), dgvPayMode.Rows[i].Cells[3].Value.ToString());
                    }
                    else
                    {
                        bResult=DA.basicData.EditMode(dgvPayMode.Rows[i].Cells[1].Value.ToString(),
                            dgvPayMode.Rows[i].Cells[2].Value.ToString(), dgvPayMode.Rows[i].Cells[3].Value.ToString(),id);
                    }

                }
               
            }
            else if (cTabControl1.SelectedIndex == 1)
            {
                dgvIncomtype.CurrentCell = dgvIncomtype.Rows[dgvIncomtype.Rows.Count - 1].Cells[2];
                for (int i = 0; i < dgvIncomtype.Rows.Count - 1; i++)
                {
                    string id = this.dgvIncomtype.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertInComType(dgvIncomtype.Rows[i].Cells[1].Value.ToString(),
                            dgvIncomtype.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditInComType(dgvIncomtype.Rows[i].Cells[1].Value.ToString(),
                            dgvIncomtype.Rows[i].Cells[2].Value.ToString(), id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 2)
            {
                dgvFeeType.CurrentCell = dgvFeeType.Rows[dgvFeeType.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvFeeType.Rows.Count - 1; i++)
                {
                    string id = this.dgvFeeType.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertFeeType(dgvFeeType.Rows[i].Cells[1].Value.ToString(),
                            dgvFeeType.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditFeeType(dgvFeeType.Rows[i].Cells[1].Value.ToString(),
                            dgvFeeType.Rows[i].Cells[2].Value.ToString(), id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 3)
            {
                dgvDelivery.CurrentCell = dgvDelivery.Rows[dgvDelivery.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvDelivery.Rows.Count - 1; i++)
                {
                    string id = this.dgvDelivery.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertDelivery(dgvDelivery.Rows[i].Cells[1].Value.ToString(),
                            dgvDelivery.Rows[i].Cells["orderid"].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditDelivery(dgvDelivery.Rows[i].Cells[1].Value.ToString(),
                            dgvDelivery.Rows[i].Cells["orderid"].Value.ToString(), id);
                    }

                }
            }
            
            else if (cTabControl1.SelectedIndex == 4)
            {
                dgvCustfrom.CurrentCell = dgvCustfrom.Rows[dgvCustfrom.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvCustfrom.Rows.Count - 1; i++)
                {
                    string id = this.dgvCustfrom.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertCustfrom(dgvCustfrom.Rows[i].Cells[1].Value.ToString(),
                            dgvCustfrom.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditCustfrom(dgvCustfrom.Rows[i].Cells[1].Value.ToString(),
                            dgvCustfrom.Rows[i].Cells[2].Value.ToString(), id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 5)
            {
                dgvCurrency.CurrentCell = dgvCurrency.Rows[dgvCurrency.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvCurrency.Rows.Count - 1; i++)
                {
                    string id = this.dgvCurrency.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertCoin(dgvCurrency.Rows[i].Cells[1].Value.ToString(),
                            dgvCurrency.Rows[i].Cells[2].Value.ToString(),dgvCurrency.Rows[i].Cells[3].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditCoin(dgvCurrency.Rows[i].Cells[1].Value.ToString(),
                            dgvCurrency.Rows[i].Cells[2].Value.ToString(), dgvCurrency.Rows[i].Cells[3].Value.ToString(), id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 6)
            {
                dgvCountry.CurrentCell = dgvCountry.Rows[dgvCountry.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvCountry.Rows.Count - 1; i++)
                {
                    string id = this.dgvCountry.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertCountry(dgvCountry.Rows[i].Cells[1].Value.ToString(),
                            dgvCountry.Rows[i].Cells[2].Value.ToString(), dgvCountry.Rows[i].Cells[3].Value.ToString(), dgvCountry.Rows[i].Cells[4].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditCountry(dgvCountry.Rows[i].Cells[1].Value.ToString(),
                            dgvCountry.Rows[i].Cells[2].Value.ToString(), dgvCountry.Rows[i].Cells[3].Value.ToString(), dgvCountry.Rows[i].Cells[4].Value.ToString(), id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 7)
            {
                dgvProduct.CurrentCell = dgvProduct.Rows[dgvProduct.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvProduct.Rows.Count - 1; i++)
                {
                    string id = this.dgvProduct.Rows[i].Cells[0].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertProduct(dgvProduct.Rows[i].Cells[1].Value.ToString(),
                            dgvProduct.Rows[i].Cells[2].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditProduct(dgvProduct.Rows[i].Cells[1].Value.ToString(),
                            dgvProduct.Rows[i].Cells[2].Value.ToString(),id);
                    }

                }
            }
            else if (cTabControl1.SelectedIndex == 8)
            {
                dgvBankinfo.CurrentCell = dgvBankinfo.Rows[dgvBankinfo.Rows.Count - 1].Cells[2];
                for (int i = 0; i < this.dgvBankinfo.Rows.Count - 1; i++)
                {
                    DataTable dt = (DataTable)dgvBankinfo.DataSource;
                    string id = dgvBankinfo.Rows[i].Cells["idb"].Value.ToString();
                    bool bResult = false;
                    if (id == "")
                    {
                        bResult = DA.basicData.InsertBankInfo(dgvBankinfo.Rows[i].Cells["bank"].Value.ToString(),
                            dgvBankinfo.Rows[i].Cells["bankno"].Value.ToString(), dgvBankinfo.Rows[i].Cells["orderidb"].Value.ToString());
                    }
                    else
                    {
                        bResult = DA.basicData.EditBankInfo(dgvBankinfo.Rows[i].Cells["bank"].Value.ToString(),
                            dgvBankinfo.Rows[i].Cells["bankno"].Value.ToString(), dgvBankinfo.Rows[i].Cells["orderidb"].Value.ToString(), id);
                    }

                }
            }
            MessageBox.Show("保存成功！");
            cTabControl1_SelectedIndexChanged(null, null);
        }

        private void frmBasic_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F9FF");


            this.ForeColor =  System.Drawing.ColorTranslator.FromHtml("#014F8A");
        }

        private void dgvIncomtype_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvIncomtype.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvIncomtype.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelInComType(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvDelivery.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvDelivery.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelDelivery(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvCustfrom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvCustfrom.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvCustfrom.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelCustfrom(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvCurrency.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvCurrency.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelCoin(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvCountry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvCountry.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvCountry.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelCountry(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvFeeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvFeeType.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvFeeType.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelFeeType(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvProduct.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelProduct(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

        private void dgvBankinfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvBankinfo.Columns[e.ColumnIndex].HeaderText == "删除")
            {
                string id = dgvBankinfo.Rows[e.RowIndex].Cells["idb"].Value.ToString();
                if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool bResult = DA.basicData.DelBankInfo(id);
                    cTabControl1_SelectedIndexChanged(null, null);
                }
            }
        }

      
    }
}
