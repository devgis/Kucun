namespace CY
{
    partial class frmMain
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
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWeek = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outlookBar1 = new CY.Controls.OutlookBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlRight = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(148, 17);
            this.lblUser.Text = " 当前用户：曾祥武          ";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(68, 17);
            this.lblTime.Text = "时间         ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.lblUser,
            this.lblTime,
            this.lblWeek});
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 53;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel2.Text = "<<隐藏菜单    ";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel1.Text = "物流后台系统";
            // 
            // lblWeek
            // 
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(32, 17);
            this.lblWeek.Text = "星期";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.outlookBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 584);
            this.panel1.TabIndex = 54;
            // 
            // outlookBar1
            // 
            this.outlookBar1.ButtonHeight = 40;
            this.outlookBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBar1.Font = new System.Drawing.Font("宋体", 11F);
            this.outlookBar1.Location = new System.Drawing.Point(0, 0);
            this.outlookBar1.Name = "outlookBar1";
            this.outlookBar1.SelectedBand = 0;
            this.outlookBar1.Size = new System.Drawing.Size(211, 584);
            this.outlookBar1.TabIndex = 51;
            this.outlookBar1.Tag = "9999";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(245)))));
            this.pnlRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(211, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(797, 584);
            this.pnlRight.TabIndex = 58;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 120000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(74, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1008, 25);
            this.miniToolStrip.TabIndex = 32;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 606);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "国际物流系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblWeek;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private Controls.OutlookBar outlookBar1;
        //private System.Windows.Forms.LinkLabel linkLabel1;
    
        
    }
}