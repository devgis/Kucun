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
    public partial class U_SelectDataDataGridViewCol : UserControl
    {
        public Action<DataGridView> onChangeSource;
        private DataGridView _Source;
        public DataGridView Source {
            get { return _Source; }
            set
            {
                _Source = value;
                if (onChangeSource != null&&_Source!=null)
                    onChangeSource(value);
            }
        }

        private IList<Col> Cols=new List<Col>(); 
        public String Caption;
        public U_SelectDataDataGridViewCol()
        {
            this.BackColor = Color.Transparent;
            onChangeSource=new Action<DataGridView>(_ =>
            {
                Cols.Clear();
                for (int i = 0; i < _Source.ColumnCount; i++)
                {
                    var _col = _Source.Columns[i];
                    Col col=new Col(){Index=i,Visible = _col.Visible,Title =_col.HeaderText,Key = _col.Name};
                    Cols.Add(col);
                }
            });
            InitializeComponent();
        }

        private void lilSelectCol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectDataGridViewColForm sdgvc = new SelectDataGridViewColForm(Cols, Caption);
            sdgvc.ShowDialog();
        }
    }

    public class Col
    {
        public string Key = "";
        public int Index;
        public Boolean Visible;
        public string Title;
    }
}
