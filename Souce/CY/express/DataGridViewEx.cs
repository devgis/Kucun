using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CY.express
{
    class DataGridViewEx : bxyztSkin.Editors.CDataGridView
    {
        //SolidBrush solidBrush;
        public DataGridViewEx()
        {
            //solidBrush = new SolidBrush(this.RowHeadersDefaultCellStyle.ForeColor);
        }
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            //e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
            //base.OnRowPostPaint(e);
        }
    }
}
