namespace CY
{
    partial class frmUser
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
            this.cTabControl1 = new bxyztSkin.CControls.CTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvUser = new bxyztSkin.Editors.CDataGridView();
            this.cPanel1 = new bxyztSkin.CControls.CPanel(this.components);
            this.btnPerm = new CY.Controls.ubtn();
            this.btnDel = new CY.Controls.ubtn();
            this.btnEdit = new CY.Controls.ubtn();
            this.btnAdd = new CY.Controls.ubtn();
            this.txtUser = new bxyztSkin.CControls.CTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new CY.Controls.ubtn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
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
            this.cTabControl1.Size = new System.Drawing.Size(954, 552);
            this.cTabControl1.TabIndex = 34;
            this.cTabControl1.SelectedIndexChanged += new System.EventHandler(this.cTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.dgvUser);
            this.tabPage1.Controls.Add(this.cPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(946, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户信息";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.dgvUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.ColumnHeadersHeight = 26;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.user_name,
            this.status});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvUser.Location = new System.Drawing.Point(3, 42);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(940, 477);
            this.dgvUser.TabIndex = 35;
            this.dgvUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellContentClick);
            this.dgvUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellDoubleClick);
            // 
            // cPanel1
            // 
            this.cPanel1.BackColor = System.Drawing.Color.Transparent;
            this.cPanel1.Controls.Add(this.btnPerm);
            this.cPanel1.Controls.Add(this.btnDel);
            this.cPanel1.Controls.Add(this.btnEdit);
            this.cPanel1.Controls.Add(this.btnAdd);
            this.cPanel1.Controls.Add(this.txtUser);
            this.cPanel1.Controls.Add(this.label1);
            this.cPanel1.Controls.Add(this.btnQuery);
            this.cPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cPanel1.Location = new System.Drawing.Point(3, 3);
            this.cPanel1.Name = "cPanel1";
            this.cPanel1.Size = new System.Drawing.Size(940, 39);
            this.cPanel1.TabIndex = 34;
            this.cPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.cPanel1_Paint);
            // 
            // btnPerm
            // 
            this.btnPerm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPerm.Caption = "权限";
            this.btnPerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerm.Location = new System.Drawing.Point(400, 3);
            this.btnPerm.Name = "btnPerm";
            this.btnPerm.Size = new System.Drawing.Size(59, 30);
            this.btnPerm.TabIndex = 62;
            this.btnPerm.Text = "权限";
            this.btnPerm.Click += new System.EventHandler(this.btnPerm_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.Caption = "删除";
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(335, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(59, 30);
            this.btnDel.TabIndex = 62;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Caption = "修改";
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(272, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 30);
            this.btnEdit.TabIndex = 61;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Caption = "添加";
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(209, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 30);
            this.btnAdd.TabIndex = 60;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(54, 6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(78, 21);
            this.txtUser.TabIndex = 59;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "用户名";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.Caption = "查询";
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(148, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(57, 30);
            this.btnQuery.TabIndex = 36;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "aid";
            this.id.HeaderText = "Column6";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "aid";
            this.Column1.HeaderText = "用户ID";
            this.Column1.Name = "Column1";
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "adminname";
            this.user_name.HeaderText = "用户名称";
            this.user_name.Name = "user_name";
            // 
            // status
            // 
            this.status.DataPropertyName = "sta";
            this.status.HeaderText = "在职";
            this.status.Name = "status";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cTabControl1);
            this.Name = "frmUser";
            this.Size = new System.Drawing.Size(954, 552);
            this.cTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.cPanel1.ResumeLayout(false);
            this.cPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private bxyztSkin.CControls.CTabControl cTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private bxyztSkin.Editors.CDataGridView dgvUser;
        private bxyztSkin.CControls.CPanel cPanel1;
        private System.Windows.Forms.Label label1;
        private CY.Controls.ubtn btnQuery;
        private bxyztSkin.CControls.CTextBox txtUser;
        private CY.Controls.ubtn btnDel;
        private CY.Controls.ubtn btnEdit;
        private CY.Controls.ubtn btnAdd;
        private CY.Controls.ubtn btnPerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;

    }
}