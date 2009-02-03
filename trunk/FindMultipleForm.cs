using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class FindMultipleForm : Form
    {
        public FindMultipleForm()
        {
            InitializeComponent();
        }
        private List<String> userList = new List<string>();

        public List<String> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MultipleSearchRecent == null)
                Properties.Settings.Default.MultipleSearchRecent = new System.Collections.Specialized.StringCollection();
            
            if(!Properties.Settings.Default.MultipleSearchRecent.Contains(txtMultiple.Text))
                Properties.Settings.Default.MultipleSearchRecent.Insert(0, txtMultiple.Text);
            
            while (Properties.Settings.Default.MultipleSearchRecent.Count > 5)
            {
                Properties.Settings.Default.MultipleSearchRecent.RemoveAt(5);
            }
            Properties.Settings.Default.Save();
            this.userList.AddRange(txtMultiple.Lines);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtMultiple_TextChanged(object sender, EventArgs e)
        {
            statLines.Text = "Items Added : " + String.Join("\r\n", txtMultiple.Lines).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Length; //only count populated lines
        }

        private void FindMultipleForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MultipleSearchRecent != null)
            {
                for (int i = 0; i < Properties.Settings.Default.MultipleSearchRecent.Count; i++)
                {
                    string value = Properties.Settings.Default.MultipleSearchRecent[i];
                    string menuText = value.Replace("\r\n", "~").Substring(0, ((value.Length <= 40) ? value.Length - 1 : 40)) + "...";
                    ToolStripMenuItem item = new ToolStripMenuItem(menuText, null, RecentSearches_EventHandler);

                    item.Tag = value;
                    ddRecent.DropDownItems.Add(item);
                }
            }

            if (ddRecent.DropDownItems.Count <= 2)
                ddRecent.Enabled = false;
            else
                ddRecent.Enabled = true;


        }

        private void RecentSearches_EventHandler(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                string value = (string)((ToolStripMenuItem)sender).Tag;
                txtMultiple.Lines = value.Split(new string[] { "\n","\r" },StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private void clearRecentSearchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MultipleSearchRecent.Clear();
            Properties.Settings.Default.Save();
            while (ddRecent.DropDownItems.Count > 2)
            {
                ddRecent.DropDownItems.RemoveAt(2);
            }
            ddRecent.Enabled = false;
        }

    }
}