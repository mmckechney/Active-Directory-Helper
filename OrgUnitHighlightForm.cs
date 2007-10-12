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
    public partial class OrgUnitHighlightForm : Form
    {
        public OrgUnitHighlightForm()
        {
            InitializeComponent();
        }
        private List<HighlightSetting> highlightSettings = new List<HighlightSetting>();

        public List<HighlightSetting> HighlightSettings
        {
            get { return highlightSettings; }
            set { highlightSettings = value; }
        }
        public OrgUnitHighlightForm(List<HighlightSetting> highlightSettings) : this()
        {
            this.highlightSettings = highlightSettings;
        }

        private void OrgUnitHighlightForm_Load(object sender, EventArgs e)
        {
            this.lstOU.Items.Clear();
            for (int i = 0; i < this.highlightSettings.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { this.highlightSettings[i].OrgUnit, this.highlightSettings[i].HighlightColor.Name });
                item.Tag = this.highlightSettings[i];
                lstOU.Items.Add(item);
            }
        }

        private void lstOU_Click(object sender, EventArgs e)
        {
            if (lstOU.SelectedItems.Count > 0)
                propertyGrid1.SelectedObject = lstOU.SelectedItems[0].Tag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HighlightSetting setting = new HighlightSetting();
            propertyGrid1.SelectedObject = setting;
            propertyGrid1.Focus();
            this.highlightSettings.Add(setting);
            ListViewItem item = new ListViewItem(new string[] { "<new>", "" });
            item.Selected = true;
            lstOU.Items.Add(item);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstOU.SelectedItems.Count > 0)
                if (this.highlightSettings.Contains((HighlightSetting) lstOU.SelectedItems[0].Tag))
                    this.highlightSettings.Remove((HighlightSetting)lstOU.SelectedItems[0].Tag);

            OrgUnitHighlightForm_Load(null, EventArgs.Empty);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (lstOU.SelectedItems.Count > 0)
            {
                if (e.ChangedItem.Value.GetType() == typeof(Color))
                    lstOU.SelectedItems[0].SubItems[1].Text = ((Color)e.ChangedItem.Value).Name;
                else
                    lstOU.SelectedItems[0].Text = e.ChangedItem.Value.ToString();
            }
        }

    

    }
}