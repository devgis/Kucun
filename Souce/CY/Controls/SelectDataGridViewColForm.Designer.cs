namespace CY.Controls
{
    partial class SelectDataGridViewColForm
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
            this.lvCols = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCols
            // 
            this.lvCols.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title});
            this.lvCols.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvCols.Location = new System.Drawing.Point(0, 0);
            this.lvCols.Name = "lvCols";
            this.lvCols.ShowGroups = false;
            this.lvCols.Size = new System.Drawing.Size(226, 278);
            this.lvCols.TabIndex = 0;
            this.lvCols.UseCompatibleStateImageBehavior = false;
            this.lvCols.View = System.Windows.Forms.View.Details;
            // 
            // title
            // 
            this.title.Text = "列名";
            this.title.Width = 226;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(232, 38);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 21);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "上移";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(232, 88);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 21);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "下移";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(233, 134);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(40, 21);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SelectDataGridViewColForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 278);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lvCols);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(300, 314);
            this.MinimumSize = new System.Drawing.Size(300, 314);
            this.Name = "SelectDataGridViewColForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择列";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvCols;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOk;

    }
}