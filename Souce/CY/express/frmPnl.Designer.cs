namespace CY
{
    partial class frmPnl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.cobPageSize = new bxyztSkin.CControls.CCombox();
            this.winFormPager1 = new Tony.Controls.Winform.WinFormPager();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.cobPageSize);
            this.panel1.Controls.Add(this.winFormPager1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 488);
            this.panel1.TabIndex = 0;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(759, 466);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 15);
            this.label20.TabIndex = 91;
            this.label20.Text = "每页数据行数：";
            // 
            // cobPageSize
            // 
            this.cobPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cobPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobPageSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cobPageSize.FormattingEnabled = true;
            this.cobPageSize.Items.AddRange(new object[] {
            "30",
            "80",
            "150",
            "500"});
            this.cobPageSize.Location = new System.Drawing.Point(884, 461);
            this.cobPageSize.Margin = new System.Windows.Forms.Padding(4);
            this.cobPageSize.Name = "cobPageSize";
            this.cobPageSize.Size = new System.Drawing.Size(91, 23);
            this.cobPageSize.TabIndex = 90;
            // 
            // winFormPager1
            // 
            this.winFormPager1.BackColor = System.Drawing.SystemColors.Control;
            this.winFormPager1.BtnTextNext = "下页";
            this.winFormPager1.BtnTextPrevious = "上页";
            this.winFormPager1.DisplayStyle = Tony.Controls.Winform.WinFormPager.DisplayStyleEnum.文字;
            this.winFormPager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.winFormPager1.Location = new System.Drawing.Point(0, 449);
            this.winFormPager1.Margin = new System.Windows.Forms.Padding(5);
            this.winFormPager1.Name = "winFormPager1";
            this.winFormPager1.PageSize = 20;
            this.winFormPager1.RecordCount = 0;
            this.winFormPager1.Size = new System.Drawing.Size(1370, 39);
            this.winFormPager1.TabIndex = 89;
            this.winFormPager1.TextImageRalitions = Tony.Controls.Winform.WinFormPager.TextImageRalitionEnum.图片显示在文字前方;
            // 
            // frmPnl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 488);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPnl";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private bxyztSkin.CControls.CCombox cobPageSize;
        private Tony.Controls.Winform.WinFormPager winFormPager1;
    }
}