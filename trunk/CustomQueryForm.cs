using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class CustomQueryForm : Form
    {
        protected CustomQueryType type;
        protected CustomQueryForm()
        {
            InitializeComponent();
        }
        public CustomQueryForm(CustomQueryType type): this()
        {
            this.type = type;
        }

        protected void OnlineDirectoryForm_Load(object sender, EventArgs e)
        {
            lstProps.Items.Clear();
            ActiveDirectoryHelper.Tables.ADGroupMembersTable tmp = new ActiveDirectoryHelper.Tables.ADGroupMembersTable();
            foreach (System.Data.DataColumn col in tmp.Columns)
            {
                if (col.ColumnName != "ManagerRow" && col.ColumnName != "Rank")
                {
                    ListViewItem item = new ListViewItem(new string[] { col.ColumnName });
                    lstProps.Items.Add(item);
                    lstProps.Sort();
                }
            }

            try
            {
                switch (type)
                {
                    case CustomQueryType.OnLineDirectory:
                        txtFormat.Text = Properties.Settings.Default.OnLineDirectoryFormat;
                        break;
                    case CustomQueryType.ManagerSearch:
                        txtFormat.Text = Properties.Settings.Default.CustomManagerSearch;
                        break;
                    case CustomQueryType.DirectReportSearch:
                        txtFormat.Text = Properties.Settings.Default.CustomDirectReportSearch;
                        break;
                }
            }
            catch { }

            if(type == CustomQueryType.OnLineDirectory)
            {
                    lblMain.Text = "URL format to use to link to on-line directory:";
                    lblExample.Text = "Example: http://myonlinedirectory.com/search.aspx?lname={LastName}&&fname={FirstName}";
                    this.Text = "Online Directory Link Set-up";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case CustomQueryType.DirectReportSearch:
                    Properties.Settings.Default.CustomDirectReportSearch = txtFormat.Text;
                    break;
                case CustomQueryType.ManagerSearch:
                    Properties.Settings.Default.CustomManagerSearch = txtFormat.Text;
                    break;
                case CustomQueryType.OnLineDirectory:
                    Properties.Settings.Default.OnLineDirectoryFormat = txtFormat.Text;
                    break;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void lstProps_DoubleClick(object sender, EventArgs e)
        {
            if (lstProps.SelectedItems.Count == 0)
                return;

            string property = lstProps.SelectedItems[0].Text;
            txtFormat.Text = txtFormat.Text + "{" + property + "}";
        }

       
    }

    public enum CustomQueryType
    {
        None,
        OnLineDirectory,
        ManagerSearch,
        DirectReportSearch
    }
}