namespace CY.Controls
{
    partial class U_SelectDataDataGridViewCol
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lilSelectCol = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lilSelectCol
            // 
            this.lilSelectCol.AutoSize = true;
            this.lilSelectCol.Location = new System.Drawing.Point(4, 4);
            this.lilSelectCol.Name = "lilSelectCol";
            this.lilSelectCol.Size = new System.Drawing.Size(41, 12);
            this.lilSelectCol.TabIndex = 0;
            this.lilSelectCol.TabStop = true;
            this.lilSelectCol.Text = "选择列";
            this.lilSelectCol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lilSelectCol_LinkClicked);
            // 
            // U_SelectDataDataGridViewCol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lilSelectCol);
            this.Name = "U_SelectDataDataGridViewCol";
            this.Size = new System.Drawing.Size(50, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lilSelectCol;
    }
}
