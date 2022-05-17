namespace CY
{
    partial class frmNewUser
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
            this.cPanel1 = new bxyztSkin.CControls.CPanel(this.components);
            this.cobStatus = new bxyztSkin.CControls.CCombox();
            this.btnClose = new CY.Controls.ubtn();
            this.btnSave = new CY.Controls.ubtn();
            this.txtUserName = new bxyztSkin.CControls.CTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new bxyztSkin.CControls.CTextBox();
            this.txtUserID = new bxyztSkin.CControls.CTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cPanel1
            // 
            this.cPanel1.BackColor = System.Drawing.Color.Transparent;
            this.cPanel1.Controls.Add(this.cobStatus);
            this.cPanel1.Controls.Add(this.btnClose);
            this.cPanel1.Controls.Add(this.btnSave);
            this.cPanel1.Controls.Add(this.txtUserName);
            this.cPanel1.Controls.Add(this.label6);
            this.cPanel1.Controls.Add(this.label2);
            this.cPanel1.Controls.Add(this.label3);
            this.cPanel1.Controls.Add(this.txtPwd);
            this.cPanel1.Controls.Add(this.txtUserID);
            this.cPanel1.Controls.Add(this.label4);
            this.cPanel1.Location = new System.Drawing.Point(6, 2);
            this.cPanel1.Name = "cPanel1";
            this.cPanel1.Size = new System.Drawing.Size(324, 239);
            this.cPanel1.TabIndex = 31;
            // 
            // cobStatus
            // 
            this.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobStatus.FormattingEnabled = true;
            this.cobStatus.Items.AddRange(new object[] {
            "在职",
            "离职"});
            this.cobStatus.Location = new System.Drawing.Point(64, 88);
            this.cobStatus.Name = "cobStatus";
            this.cobStatus.Size = new System.Drawing.Size(175, 20);
            this.cobStatus.TabIndex = 66;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Caption = "退出";
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(240, 133);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 30);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Caption = "保存";
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(169, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 30);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(64, 36);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(175, 21);
            this.txtUserName.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "用户ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "用户名";
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Location = new System.Drawing.Point(64, 62);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(175, 21);
            this.txtPwd.TabIndex = 58;
            // 
            // txtUserID
            // 
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserID.Location = new System.Drawing.Point(64, 10);
            this.txtUserID.MaxLength = 30;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(175, 21);
            this.txtUserID.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "密码";
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 246);
            this.Controls.Add(this.cPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.cPanel1.ResumeLayout(false);
            this.cPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private bxyztSkin.CControls.CPanel cPanel1;
        private CY.Controls.ubtn btnClose;
        private CY.Controls.ubtn btnSave;
        private bxyztSkin.CControls.CTextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private bxyztSkin.CControls.CTextBox txtPwd;
        private bxyztSkin.CControls.CTextBox txtUserID;
        private System.Windows.Forms.Label label4;
        private bxyztSkin.CControls.CCombox cobStatus;
        private System.Windows.Forms.Label label6;
    }
}