using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class UserListCustomizeForm : Form
    {
        DataGridViewColumnCollection cols = null;
        public UserListCustomizeForm()
        {
            InitializeComponent();
        }
        public UserListCustomizeForm(ref DataGridViewColumnCollection colls) : this()
        {
            this.cols = colls;
        }

        private void UserListCustomizeForm_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in cols)
            {
                ListViewItem item = new ListViewItem(col.HeaderText);
                item.Checked = col.Displayed;
                item.Tag = col;
                lstColumns.Items.Add(item);
            }
            lstColumns.ListViewItemSorter = new UserListCustomizeForm.UserListColumnSort();
            lstColumns.Sort();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ColumnConfig> cfg = new List<ColumnConfig>();
            for (int i = 0; i < lstColumns.Items.Count; i++)
            {
                DataGridViewColumn col = (DataGridViewColumn)lstColumns.Items[i].Tag;
                col.DisplayIndex = i;
                col.Visible = lstColumns.Items[i].Checked;
                ColumnConfig c = new ColumnConfig(col.Name, i, col.Visible,col.Width);
                cfg.Add(c);
            }

            Properties.Settings.Default.CustomizedColumnsList = cfg;
            Properties.Settings.Default.Save();
            this.Close();


        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItems.Count == 0)
                return;

            int index = lstColumns.SelectedItems[0].Index;
            if (index > 0)
            {
                ListViewItem item = (ListViewItem) lstColumns.SelectedItems[0].Clone();
                lstColumns.Items.Insert(index - 1,item);

                lstColumns.Items.Remove(lstColumns.SelectedItems[0]);
                lstColumns.Items[index - 1].Selected = true;
                lstColumns.Items[index - 1].EnsureVisible();
            }
            
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItems.Count == 0)
                return;

            int index = lstColumns.SelectedItems[0].Index;
            if (index < lstColumns.Items.Count - 1)
            {
                ListViewItem item = (ListViewItem)lstColumns.SelectedItems[0].Clone();
                lstColumns.Items.Insert(index + 2, item);

                lstColumns.Items.Remove(lstColumns.SelectedItems[0]);
                lstColumns.Items[index + 1].Selected = true;
                lstColumns.Items[index + 1].EnsureVisible();
            }
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstColumns.SelectedItems.Count == 0)
                return;

            this.lstColumns.SelectedItems[0].BackColor = Color.LightBlue;
            for (int i = 0; i < this.lstColumns.Items.Count; i++)
                if (!this.lstColumns.Items[i].Selected)
                    this.lstColumns.Items[i].BackColor = Color.White;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class UserListColumnSort : IComparer
        {
            private SortOrder sort = SortOrder.Ascending;

            public SortOrder Sort
            {
                get { return sort; }
                set { sort = value; }
            }

            public int Compare(object x, object y)
            {
                if (x is ListViewItem && y is ListViewItem)
                {
                    DataGridViewColumn colX = (DataGridViewColumn)((ListViewItem)x).Tag;
                    DataGridViewColumn colY = (DataGridViewColumn)((ListViewItem)y).Tag;

                    if (colX.DisplayIndex > colY.DisplayIndex)
                        return 1;
                    else if (colX.DisplayIndex < colY.DisplayIndex)
                        return -1;
                    else if (colX.DisplayIndex == colY.DisplayIndex)
                        return 0;
                }

                return 0;

            }
        }

    }
}