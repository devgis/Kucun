namespace CY.express
{
    partial class frmWithDrawDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new bxyztSkin.CControls.CTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cobAction = new bxyztSkin.CControls.CCombox();
            this.cobBank = new bxyztSkin.CControls.CCombox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ubtn1 = new CY.Controls.ubtn();
            this.ubtn3 = new CY.Controls.ubtn();
            this.ubtn2 = new CY.Controls.ubtn();
            this.txtAmt = new bxyztSkin.CControls.CTextBox();
            this.txtpayid = new bxyztSkin.CControls.CTextBox();
            this.txtAdmin = new bxyztSkin.CControls.CTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIn = new System.Windows.Forms.Label();
            this.txtremark = new bxyztSkin.CControls.CTextBox();
            this.lblIn9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cobAction);
            this.groupBox1.Controls.Add(this.cobBank);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.ubtn1);
            this.groupBox1.Controls.Add(this.ubtn3);
            this.groupBox1.Controls.Add(this.ubtn2);
            this.groupBox1.Controls.Add(this.txtAmt);
            this.groupBox1.Controls.Add(this.txtpayid);
            this.groupBox1.Controls.Add(this.txtAdmin);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblIn);
            this.groupBox1.Controls.Add(this.txtremark);
            this.groupBox1.Controls.Add(this.lblIn9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("宋体", 12F);
            this.txtDate.Location = new System.Drawing.Point(113, 89);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(170, 26);
            this.txtDate.TabIndex = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(328, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 16);
            this.label5.TabIndex = 137;
            this.label5.Text = "(截图后，点击显示图片即可)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(322, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 136;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(289, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(18, 26);
            this.dateTimePicker1.TabIndex = 135;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cobAction
            // 
            this.cobAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobAction.Enabled = false;
            this.cobAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cobAction.Font = new System.Drawing.Font("宋体", 12F);
            this.cobAction.FormattingEnabled = true;
            this.cobAction.Location = new System.Drawing.Point(113, 159);
            this.cobAction.Name = "cobAction";
            this.cobAction.Size = new System.Drawing.Size(192, 24);
            this.cobAction.TabIndex = 134;
            this.cobAction.SelectedIndexChanged += new System.EventHandler(this.cobAction_SelectedIndexChanged);
            // 
            // cobBank
            // 
            this.cobBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cobBank.Font = new System.Drawing.Font("宋体", 12F);
            this.cobBank.FormattingEnabled = true;
            this.cobBank.Location = new System.Drawing.Point(113, 124);
            this.cobBank.Name = "cobBank";
            this.cobBank.Size = new System.Drawing.Size(192, 24);
            this.cobBank.TabIndex = 133;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(325, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 132;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // ubtn1
            // 
            this.ubtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ubtn1.Caption = "退出";
            this.ubtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ubtn1.Location = new System.Drawing.Point(437, 357);
            this.ubtn1.Name = "ubtn1";
            this.ubtn1.Size = new System.Drawing.Size(78, 30);
            this.ubtn1.TabIndex = 131;
            this.ubtn1.Text = "退出";
            this.ubtn1.Click += new System.EventHandler(this.ubtn1_Click);
            // 
            // ubtn3
            // 
            this.ubtn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ubtn3.Caption = "显示图片";
            this.ubtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ubtn3.Location = new System.Drawing.Point(552, 315);
            this.ubtn3.Name = "ubtn3";
            this.ubtn3.Size = new System.Drawing.Size(78, 25);
            this.ubtn3.TabIndex = 131;
            this.ubtn3.Text = "显示图片";
            this.ubtn3.Click += new System.EventHandler(this.ubtn3_Click);
            // 
            // ubtn2
            // 
            this.ubtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ubtn2.Caption = "保存";
            this.ubtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ubtn2.Location = new System.Drawing.Point(325, 357);
            this.ubtn2.Name = "ubtn2";
            this.ubtn2.Size = new System.Drawing.Size(78, 30);
            this.ubtn2.TabIndex = 131;
            this.ubtn2.Text = "保存";
            this.ubtn2.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmt
            // 
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt.Enabled = false;
            this.txtAmt.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAmt.Location = new System.Drawing.Point(113, 194);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(192, 26);
            this.txtAmt.TabIndex = 120;
            // 
            // txtpayid
            // 
            this.txtpayid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpayid.Enabled = false;
            this.txtpayid.Font = new System.Drawing.Font("宋体", 12F);
            this.txtpayid.Location = new System.Drawing.Point(113, 231);
            this.txtpayid.Name = "txtpayid";
            this.txtpayid.Size = new System.Drawing.Size(192, 26);
            this.txtpayid.TabIndex = 120;
            // 
            // txtAdmin
            // 
            this.txtAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdmin.Enabled = false;
            this.txtAdmin.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAdmin.Location = new System.Drawing.Point(113, 50);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(192, 26);
            this.txtAdmin.TabIndex = 117;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F);
            this.label13.Location = new System.Drawing.Point(64, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 109;
            this.label13.Text = "备注";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.Location = new System.Drawing.Point(32, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 97;
            this.label12.Text = "转账用途";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F);
            this.label11.Location = new System.Drawing.Point(32, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 98;
            this.label11.Text = "银行账户";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(465, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 99;
            this.label1.Text = "转帐凭证预览";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(64, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 99;
            this.label4.Text = "操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(32, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 102;
            this.label3.Text = "转帐日期";
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Font = new System.Drawing.Font("宋体", 12F);
            this.lblIn.Location = new System.Drawing.Point(32, 199);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(72, 16);
            this.lblIn.TabIndex = 107;
            this.lblIn.Text = "进账金额";
            // 
            // txtremark
            // 
            this.txtremark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtremark.Font = new System.Drawing.Font("宋体", 12F);
            this.txtremark.Location = new System.Drawing.Point(113, 268);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(192, 93);
            this.txtremark.TabIndex = 115;
            // 
            // lblIn9
            // 
            this.lblIn9.AutoSize = true;
            this.lblIn9.Font = new System.Drawing.Font("宋体", 12F);
            this.lblIn9.Location = new System.Drawing.Point(32, 234);
            this.lblIn9.Name = "lblIn9";
            this.lblIn9.Size = new System.Drawing.Size(72, 16);
            this.lblIn9.TabIndex = 107;
            this.lblIn9.Text = "提现编号";
            // 
            // frmWithDrawDetail
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 443);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmWithDrawDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帐目添加";
            this.Load += new System.EventHandler(this.frmNewBank_Load);
            this.Shown += new System.EventHandler(this.frmNewBank_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmNewBank_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNewBank_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private bxyztSkin.CControls.CTextBox txtpayid;
        private bxyztSkin.CControls.CTextBox txtAdmin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private bxyztSkin.CControls.CTextBox txtremark;
        private System.Windows.Forms.Label lblIn9;
        private Controls.ubtn ubtn1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controls.ubtn ubtn2;
        private bxyztSkin.CControls.CCombox cobBank;
        private bxyztSkin.CControls.CCombox cobAction;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private bxyztSkin.CControls.CTextBox txtAmt;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.Label label2;
        private Controls.ubtn ubtn3;
        private System.Windows.Forms.Label label5;
        private bxyztSkin.CControls.CTextBox txtDate;
    }
}