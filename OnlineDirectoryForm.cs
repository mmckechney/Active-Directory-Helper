using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class OnlineDirectoryForm : Form
    {
        public OnlineDirectoryForm()
        {
            InitializeComponent();
        }

        private void OnlineDirectoryForm_Load(object sender, EventArgs e)
        {
            ActiveDirectoryHelper.Tables.ADGroupMembersTable tmp = new ActiveDirectoryHelper.Tables.ADGroupMembersTable();
            foreach (System.Data.DataColumn col in tmp.Columns)
            {
                if (col.ColumnName != "Manager" && col.ColumnName != "Rank")
                {
                    ListViewItem item = new ListViewItem(new string[] { col.ColumnName });
                    lstProps.Items.Add(item);
                    lstProps.Sort();
                }
            }

            try
            {
                txtFormat.Text = Properties.Settings.Default.OnLineDirectoryFormat;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OnLineDirectoryFormat = txtFormat.Text;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstProps_DoubleClick(object sender, EventArgs e)
        {
            if (lstProps.SelectedItems.Count == 0)
                return;

            string property = lstProps.SelectedItems[0].Text;
            txtFormat.Text = txtFormat.Text + "{" + property + "}";
        }
    }
}