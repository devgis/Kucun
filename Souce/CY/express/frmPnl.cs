using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CY
{
    public partial class frmPnl : Form
    {
        public frmPnl()
        {
            InitializeComponent();
        }
        public void setPnl(UserControl frm)
        {
            this.Size = frm.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panel1.Controls.Add(frm);
        }
    }
}
