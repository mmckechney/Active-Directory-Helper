using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryHelper.Collections;
namespace ActiveDirectoryHelper
{
    public partial class PropertyMonitorForm : Form
    {
        bool addingNew = false;
        List<PropertyMonitorSetting> propMonitors;

        internal List<PropertyMonitorSetting> PropMonitors
        {
            get { return propMonitors; }
            set { propMonitors = value; }
        }
        public PropertyMonitorForm()
        {
            InitializeComponent();
        }
        public PropertyMonitorForm(List<PropertyMonitorSetting> list) : this()
        {
            this.propMonitors = list;
        }

        private void StatusMonitorForm_Load(object sender, EventArgs e)
        {
            lstSettings.Items.Clear();
           //propMonitors = (List<PropertyMonitorSetting>)Properties.Settings.Default.PropertyMonitorSettings;
           for (int i = 0; i < propMonitors.Count; i++)
           {
               ListViewItem item = new ListViewItem(new string[]{propMonitors[i].IDToMonitor,propMonitors[i].PropertyToMonitor,propMonitors[i].IntervalMinutes.ToString(),propMonitors[i].CurrentValue,propMonitors[i].LastCheck.ToString()});
               item.Tag = propMonitors[i];
               lstSettings.Items.Add(item);
           }

           Tables.ADGroupMembersTable tmp = new ActiveDirectoryHelper.Tables.ADGroupMembersTable();
           foreach (DataColumn column in tmp.Columns)
               ddProperties.Items.Add(column.ColumnName);

        }

        
    


        private void btnAdd_Click(object sender, EventArgs e)
        {
            addingNew = true;
            grpEdit.Enabled = true; ;
            txtInterval.Text = string.Empty;
            txtUserID.Text = string.Empty;
        }

        private void lstSettings_Click(object sender, EventArgs e)
        {
            if (lstSettings.SelectedItems.Count == 0)
                return;

            grpEdit.Enabled = true;
            PropertyMonitorSetting setting = (PropertyMonitorSetting)lstSettings.SelectedItems[0].Tag;
            addingNew = false;
            txtUserID.Text = setting.IDToMonitor;
            txtInterval.Text = setting.IntervalMinutes.ToString();
            for (int i = 0; i < ddProperties.Items.Count; i++)
            {
                if (ddProperties.Items[i].ToString() == setting.PropertyToMonitor)
                {
                    ddProperties.SelectedIndex = i;
                    break;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addingNew)
            {
                PropertyMonitorSetting setting = new PropertyMonitorSetting();
                setting.PropertyToMonitor = ddProperties.SelectedItem.ToString();
                setting.IDToMonitor = txtUserID.Text;
                setting.IntervalMinutes = Int32.Parse(txtInterval.Text);

                propMonitors.Add(setting);
  
            }
            else
            {
                if (lstSettings.SelectedItems.Count != 0)
                {
                    PropertyMonitorSetting setting = (PropertyMonitorSetting)lstSettings.SelectedItems[0].Tag;
                    setting.PropertyToMonitor = ddProperties.SelectedItem.ToString();
                    setting.IDToMonitor = txtUserID.Text;
                    setting.IntervalMinutes = Int32.Parse(txtInterval.Text);
                }
            }
            StatusMonitorForm_Load(null, EventArgs.Empty);
            grpEdit.Enabled = false;
        }
    }
}