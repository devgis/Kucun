using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CY.Controls
{
    public partial class ubtn : System.Windows.Forms.Button
    {
        public ubtn()
        {
            InitializeComponent();
            //this.BackColor = System.Drawing.Color.FromArgb(255, 238, 166);
            this.FlatStyle = FlatStyle.Flat;
            this.BackgroundImage = null;
        }

        public override System.Drawing.Color BackColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(255, 238, 166);
            }
            set
            { 
                //this.BackColor= value;
            }
        }

        public string Caption
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public override System.Drawing.Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            { 
            
            }
        }
         
    }
}
