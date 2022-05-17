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
    public partial class country : bxyztSkin.CControls.CCombox
    {
        public country()
        {
            InitializeComponent();
            //Build();
            
        }
        public void Build()
        {
            DataTable dt = CY.DA.basicData.GetCountry();
            this.comboBox1.DataSource = dt;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "country_name";
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnSelectedIndexChanged(e);
        }
        public new string SelectedValue
        {
            get
            {
                if (comboBox1.SelectedValue == null)
                    return "";

                return comboBox1.SelectedValue.ToString();
            }
            set
            {
                comboBox1.SelectedValue = value;
            }
        }



        public override string Text
        {
            get
            {
                return comboBox1.Text;
            }
        }



    }
}
