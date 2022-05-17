using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using CY.DA;
 

namespace CY.Controls
{
    public partial class SelectDataGridViewColForm : Form
    {
        private IList<Col> Cols;
        private string _Caption;
        private IList<string> currentCols=new List<string>();
        public SelectDataGridViewColForm(IList<Col> cols, String Caption)
        {
            InitializeComponent();
            lvCols.CheckBoxes = true;
            Cols = cols;
            _Caption = Caption;
            var nCol=SQLHelper.ExecuteDt(String.Format(@"
select Cols from UserColSet where UserId='{0}' and Caption='{1}'", pub.userid, _Caption));
            if (nCol != null && nCol.Rows.Count > 0)
            {
                currentCols = nCol.Rows[0]["Cols"].ToString().Split('、');
            }
            else
            {
                foreach (var item in Cols)
                {
                    currentCols.Add(item.Key);
                }
            }
            BindLv();
        }

        private void BindLv()
        {
            Cols = Cols.AsEnumerable().OrderBy(p => p.Index).ToList();
            lvCols.Items.Clear();
            var seCol = from p in currentCols where Cols.SingleOrDefault(_ => _.Key == p) != null select Cols.SingleOrDefault(_ => _.Key == p);
            foreach (var item in seCol)
            {
                if (item.Visible)
                {
                    ListViewItem lvi = new ListViewItem(item.Title);
                    lvi.Tag = item;
                    if (currentCols.Contains(item.Key))
                        lvi.Checked = true;
                    lvCols.Items.Add(lvi);
                }
            }
            for (int i = 0; i < Cols.Count; i++)
            {
                if (Cols[i].Visible)
                {
                    if (seCol.Contains(Cols[i]))
                        continue;
                    ListViewItem lvi = new ListViewItem(Cols[i].Title);
                    lvi.Tag = Cols[i];
                    if (currentCols.Contains(Cols[i].Key))
                        lvi.Checked = true;
                    lvCols.Items.Add(lvi);
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var selectCol = lvCols.SelectedItems;
            lvCols.BeginUpdate();
            for (int i = 0; i < selectCol.Count; i++)
            {
                ListViewItem lvi = selectCol[i];
                var col = lvi.Tag as Col;
                var pCol = Cols.SingleOrDefault(_ => { return _.Index == col.Index - 1;});
                if(col.Index>0)
                    col.Index--;
                if(pCol!=null)
                    pCol.Index++;

                int indexSelectedItem = lvi.Index;
                if (indexSelectedItem > 0)
                {
                    lvCols.Items.RemoveAt(indexSelectedItem);
                    lvCols.Items.Insert(indexSelectedItem - 1, lvi);
                }
            }

            lvCols.EndUpdate();

            if (lvCols.Items.Count > 0 && lvCols.SelectedItems.Count > 0)
            {
                lvCols.Focus();
                lvCols.SelectedItems[0].Focused = true;
                lvCols.SelectedItems[0].EnsureVisible();
            }
            Cols = Cols.AsEnumerable().OrderBy(p => p.Index).ToList();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var selectCol = lvCols.SelectedItems;
            lvCols.BeginUpdate();
            for (int i = 0; i < selectCol.Count; i++)
            {
                ListViewItem lvi = selectCol[i];
                var col = lvi.Tag as Col;
                var pCol = Cols.SingleOrDefault(_ => { return _.Index == col.Index + 1; });
                if (col.Index < lvCols.Items.Count)
                    col.Index++;
                if (pCol != null)
                    pCol.Index--;

                int indexSelectedItem = lvi.Index;
                if (indexSelectedItem >= 0)
                {
                    lvCols.Items.RemoveAt(indexSelectedItem);
                    lvCols.Items.Insert(indexSelectedItem + 1, lvi);
                }
            }

            lvCols.EndUpdate();

            if (lvCols.Items.Count > 0 && lvCols.SelectedItems.Count > 0)
            {
                lvCols.Focus();
                lvCols.SelectedItems[lvCols.SelectedItems.Count - 1].Focused = true;
                lvCols.SelectedItems[lvCols.SelectedItems.Count - 1].EnsureVisible();
            }
            Cols = Cols.AsEnumerable().OrderBy(p => p.Index).ToList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var show= (from ListViewItem item in lvCols.Items where item.Checked select item.Tag as Col).ToList();
            show.AddRange((from item in Cols where !item.Visible select item).ToList());
            //show = show.AsEnumerable().OrderBy(p => p.Index).ToList();
            var keys = show.Aggregate("", (current, item) => current + ("、" + item.Key));
            SQLHelper.ExecuteSql(String.Format(@"
delete from UserColSet where UserId='{0}' and Caption='{1}';
insert into UserColSet(UserId,Caption,Cols) values('{0}','{1}','{2}')
", pub.userid, _Caption,keys.Length>0?keys.Remove(0,1):""));
            MessageBox.Show("保存成功");
            this.Close();
        }
    }
}
