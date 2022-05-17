namespace CY.express
{
    partial class frmSGAir
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
            this.lblV = new System.Windows.Forms.Label();
            this.lblgwkg = new System.Windows.Forms.Label();
            this.cobExpress = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblVol = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCust = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPcs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtgnKG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblV
            // 
            this.lblV.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblV.Location = new System.Drawing.Point(421, 320);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(127, 37);
            this.lblV.TabIndex = 80;
            this.lblV.Text = "0";
            // 
            // lblgwkg
            // 
            this.lblgwkg.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgwkg.Location = new System.Drawing.Point(195, 320);
            this.lblgwkg.Name = "lblgwkg";
            this.lblgwkg.Size = new System.Drawing.Size(91, 37);
            this.lblgwkg.TabIndex = 82;
            this.lblgwkg.Text = "0";
            // 
            // cobExpress
            // 
            this.cobExpress.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobExpress.Location = new System.Drawing.Point(199, 77);
            this.cobExpress.Name = "cobExpress";
            this.cobExpress.Size = new System.Drawing.Size(400, 45);
            this.cobExpress.TabIndex = 91;
            this.cobExpress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cobExpress_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(50, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 40);
            this.label5.TabIndex = 92;
            this.label5.Text = "快递公司";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 28F);
            this.btnClear.Location = new System.Drawing.Point(919, 256);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(233, 51);
            this.btnClear.TabIndex = 90;
            this.btnClear.Text = "清空刷新";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("宋体", 22F);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(53, 439);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(604, 57);
            this.lblMsg.TabIndex = 93;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 28F);
            this.btnSave.Location = new System.Drawing.Point(248, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(233, 51);
            this.btnSave.TabIndex = 81;
            this.btnSave.Text = "确定提交";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // lblVol
            // 
            this.lblVol.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVol.Location = new System.Drawing.Point(292, 320);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(123, 37);
            this.lblVol.TabIndex = 94;
            this.lblVol.Text = "体积m³:";
            // 
            // txtH
            // 
            this.txtH.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtH.Location = new System.Drawing.Point(394, 244);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(87, 50);
            this.txtH.TabIndex = 89;
            this.txtH.TextChanged += new System.EventHandler(this.txtH_TextChanged);
            this.txtH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtH_KeyDown);
            // 
            // txtW
            // 
            this.txtW.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtW.Location = new System.Drawing.Point(297, 244);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(87, 50);
            this.txtW.TabIndex = 88;
            this.txtW.TextChanged += new System.EventHandler(this.txtW_TextChanged);
            this.txtW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtW_KeyDown);
            // 
            // txtL
            // 
            this.txtL.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtL.Location = new System.Drawing.Point(199, 244);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(87, 50);
            this.txtL.TabIndex = 87;
            this.txtL.TextChanged += new System.EventHandler(this.txtL_TextChanged);
            this.txtL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtL_KeyDown);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(23, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 40);
            this.label10.TabIndex = 95;
            this.label10.Text = "长宽高(cm)";
            // 
            // lblCust
            // 
            this.lblCust.Font = new System.Drawing.Font("宋体", 22F);
            this.lblCust.ForeColor = System.Drawing.Color.Red;
            this.lblCust.Location = new System.Drawing.Point(606, 17);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(246, 37);
            this.lblCust.TabIndex = 96;
            this.lblCust.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNo
            // 
            this.txtNo.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNo.Location = new System.Drawing.Point(199, 128);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(400, 50);
            this.txtNo.TabIndex = 85;
            this.txtNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNo_KeyDown);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 40);
            this.label8.TabIndex = 97;
            this.label8.Text = "中国快递号";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 37);
            this.label1.TabIndex = 98;
            this.label1.Text = "泡重(KG):";
            // 
            // txtPcs
            // 
            this.txtPcs.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPcs.Location = new System.Drawing.Point(483, 188);
            this.txtPcs.Name = "txtPcs";
            this.txtPcs.Size = new System.Drawing.Size(116, 50);
            this.txtPcs.TabIndex = 83;
            this.txtPcs.Text = "1";
            this.txtPcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPcs_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(384, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 40);
            this.label3.TabIndex = 100;
            this.label3.Text = "件数";
            // 
            // txtCust
            // 
            this.txtCust.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCust.Location = new System.Drawing.Point(200, 10);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(400, 50);
            this.txtCust.TabIndex = 86;
            this.txtCust.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCust_KeyDown);
            this.txtCust.Leave += new System.EventHandler(this.txtCust_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(54, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 40);
            this.label2.TabIndex = 101;
            this.label2.Text = "会员编号";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(877, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 464);
            this.panel1.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1006, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 213);
            this.label4.TabIndex = 103;
            this.label4.Text = "空运入库";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 22F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(605, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 37);
            this.label6.TabIndex = 104;
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtgnKG
            // 
            this.txtgnKG.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtgnKG.Location = new System.Drawing.Point(200, 188);
            this.txtgnKG.Name = "txtgnKG";
            this.txtgnKG.Size = new System.Drawing.Size(116, 50);
            this.txtgnKG.TabIndex = 105;
            this.txtgnKG.Text = "1";
            this.txtgnKG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgnKG_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(101, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 40);
            this.label7.TabIndex = 106;
            this.label7.Text = "实重";
            // 
            // frmSGAir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtgnKG);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblV);
            this.Controls.Add(this.lblgwkg);
            this.Controls.Add(this.cobExpress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblVol);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtW);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCust);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPcs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCust);
            this.Controls.Add(this.label2);
            this.Name = "frmSGAir";
            this.Size = new System.Drawing.Size(1213, 585);
            this.Load += new System.EventHandler(this.frmSGAir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblgwkg;
        private System.Windows.Forms.ComboBox cobExpress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblVol;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPcs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtgnKG;
        private System.Windows.Forms.Label label7;

    }
}