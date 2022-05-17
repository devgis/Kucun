namespace CY
{
    partial class frmPerm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerm));
            this.cTabControl1 = new bxyztSkin.CControls.CTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMenu = new bxyztSkin.Editors.CDataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPanel1 = new bxyztSkin.CControls.CPanel(this.components);
            this.txtUser = new bxyztSkin.CControls.CTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new CY.Controls.ubtn();
            this.cTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.cPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cTabControl1
            // 
            this.cTabControl1.Controls.Add(this.tabPage1);
            this.cTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTabControl1.Location = new System.Drawing.Point(0, 0);
            this.cTabControl1.myBackColor = System.Drawing.SystemColors.Control;
            this.cTabControl1.Name = "cTabControl1";
            this.cTabControl1.SelectedIndex = 0;
            this.cTabControl1.Size = new System.Drawing.Size(854, 473);
            this.cTabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvMenu);
            this.tabPage1.Controls.Add(this.cPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(846, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户权限";
            // 
            // dgvMenu
            // 
            this.dgvMenu.AllowUserToAddRows = false;
            this.dgvMenu.AllowUserToDeleteRows = false;
            this.dgvMenu.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.dgvMenu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMenu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMenu.ColumnHeadersHeight = 26;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column6,
            this.Column1,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMenu.EnableHeadersVisualStyles = false;
            this.dgvMenu.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvMenu.Location = new System.Drawing.Point(3, 42);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenu.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMenu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMenu.RowTemplate.Height = 23;
            this.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenu.Size = new System.Drawing.Size(840, 398);
            this.dgvMenu.TabIndex = 35;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "chk";
            this.Column2.HeaderText = "选择";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "menu2";
            this.Column1.HeaderText = "菜单名称";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "menu1";
            this.Column3.HeaderText = "一级菜单";
            this.Column3.Name = "Column3";
            // 
            // cPanel1
            // 
            this.cPanel1.BackColor = System.Drawing.Color.Transparent;
            this.cPanel1.Controls.Add(this.txtUser);
            this.cPanel1.Controls.Add(this.label1);
            this.cPanel1.Controls.Add(this.btnSave);
            this.cPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cPanel1.Location = new System.Drawing.Point(3, 3);
            this.cPanel1.Name = "cPanel1";
            this.cPanel1.Size = new System.Drawing.Size(840, 39);
            this.cPanel1.TabIndex = 34;
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(54, 6);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(78, 21);
            this.txtUser.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "用户名";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Caption = "保存";
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Location = new System.Drawing.Point(148, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 30);
            this.btnSave.TabIndex = 36;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // frmPerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 473);
            this.Controls.Add(this.cTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPerm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户权限";
            this.Load += new System.EventHandler(this.frmPerm_Load);
            this.cTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.cPanel1.ResumeLayout(false);
            this.cPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private bxyztSkin.CControls.CTabControl cTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private bxyztSkin.Editors.CDataGridView dgvMenu;
        private bxyztSkin.CControls.CPanel cPanel1;
        private bxyztSkin.CControls.CTextBox txtUser;
        private System.Windows.Forms.Label label1;
        private CY.Controls.ubtn btnSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    }
}