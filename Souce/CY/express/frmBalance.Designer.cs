namespace CY.express
{
    partial class frmBalance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cobYM = new System.Windows.Forms.ComboBox();
            this.dgvResult = new CY.express.DataGridViewEx();
            this.ubtn1 = new CY.Controls.ubtn();
            this.btnQuery = new CY.Controls.ubtn();
            this.cobBank = new bxyztSkin.CControls.CCombox();
            this.label11 = new System.Windows.Forms.Label();
            this.banknames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(513, 58);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "关帐前，关帐月份的数据应该和账户结余一致。\n关帐后，关帐月份的数据不再可以调整，";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(22, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "关帐月份";
            // 
            // cobYM
            // 
            this.cobYM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobYM.Font = new System.Drawing.Font("宋体", 12F);
            this.cobYM.FormattingEnabled = true;
            this.cobYM.Location = new System.Drawing.Point(100, 85);
            this.cobYM.Name = "cobYM";
            this.cobYM.Size = new System.Drawing.Size(182, 24);
            this.cobYM.TabIndex = 28;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeight = 26;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.banknames,
            this.bid,
            this.bankname,
            this.addtime,
            this.adminname});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvResult.Location = new System.Drawing.Point(12, 180);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvResult.Size = new System.Drawing.Size(500, 285);
            this.dgvResult.TabIndex = 87;
            // 
            // ubtn1
            // 
            this.ubtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ubtn1.Caption = "退出";
            this.ubtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ubtn1.Location = new System.Drawing.Point(455, 122);
            this.ubtn1.Name = "ubtn1";
            this.ubtn1.Size = new System.Drawing.Size(57, 30);
            this.ubtn1.TabIndex = 27;
            this.ubtn1.Text = "退出";
            this.ubtn1.Click += new System.EventHandler(this.ubtn1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.Caption = "开始";
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(368, 122);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(57, 30);
            this.btnQuery.TabIndex = 27;
            this.btnQuery.Text = "开始";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cobBank
            // 
            this.cobBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cobBank.Font = new System.Drawing.Font("宋体", 12F);
            this.cobBank.FormattingEnabled = true;
            this.cobBank.Location = new System.Drawing.Point(100, 124);
            this.cobBank.Name = "cobBank";
            this.cobBank.Size = new System.Drawing.Size(182, 24);
            this.cobBank.TabIndex = 135;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.Location = new System.Drawing.Point(19, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 134;
            this.label11.Text = "银行账户";
            // 
            // banknames
            // 
            this.banknames.DataPropertyName = "bankname";
            this.banknames.HeaderText = "银行账户";
            this.banknames.Name = "banknames";
            // 
            // bid
            // 
            this.bid.DataPropertyName = "ym";
            this.bid.HeaderText = "月份";
            this.bid.Name = "bid";
            // 
            // bankname
            // 
            this.bankname.DataPropertyName = "balance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bankname.DefaultCellStyle = dataGridViewCellStyle3;
            this.bankname.HeaderText = "结帐金额";
            this.bankname.Name = "bankname";
            this.bankname.Width = 120;
            // 
            // addtime
            // 
            this.addtime.DataPropertyName = "addtime";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.addtime.DefaultCellStyle = dataGridViewCellStyle4;
            this.addtime.HeaderText = "结帐日期";
            this.addtime.Name = "addtime";
            // 
            // adminname
            // 
            this.adminname.DataPropertyName = "adminname";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.adminname.DefaultCellStyle = dataGridViewCellStyle5;
            this.adminname.FillWeight = 70F;
            this.adminname.HeaderText = "操作员";
            this.adminname.Name = "adminname";
            this.adminname.Width = 70;
            // 
            // frmBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 477);
            this.Controls.Add(this.cobBank);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.cobYM);
            this.Controls.Add(this.ubtn1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Name = "frmBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关帐";
            this.Load += new System.EventHandler(this.frmBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private Controls.ubtn btnQuery;
        private Controls.ubtn ubtn1;
        private System.Windows.Forms.ComboBox cobYM;
        private DataGridViewEx dgvResult;
        private bxyztSkin.CControls.CCombox cobBank;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn banknames;
        private System.Windows.Forms.DataGridViewTextBoxColumn bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankname;
        private System.Windows.Forms.DataGridViewTextBoxColumn addtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminname;
    }
}