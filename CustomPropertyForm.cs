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
    public partial class CustomPropertyForm : Form
    {
        private LdapPropertyMapping map = new LdapPropertyMapping();
        public CustomPropertyForm()
        {
            InitializeComponent();
        }
        private List<CustomPropertyConfig> propertyConfigs = new List<CustomPropertyConfig>();

        public List<CustomPropertyConfig> PropertyConfigs
        {
            get { return propertyConfigs; }
            set { propertyConfigs = value; }
        }

        private void CustomPropertyForm_Load(object sender, EventArgs e)
        {
            this.lstProps.Items.Clear();
            this.lstAvailable.Items.Clear();

            //Add the configured custom Properties...
            this.propertyConfigs = Properties.Settings.Default.CustomPropertyList;
            for (int i = 0; i < this.propertyConfigs.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { this.propertyConfigs[i].LdapPropertyName, this.propertyConfigs[i].DisplayName, this.propertyConfigs[i].DisplayColumn.ToString()});
                item.Tag = this.propertyConfigs[i];
                lstProps.Items.Add(item);
            }

            //Set the list of available properties
            Tables.ADGroupMembersTable tbl = new ActiveDirectoryHelper.Tables.ADGroupMembersTable();
            for (int i = 0; i < ADHelper.AvailableLdapProps.Count; i++)
            {
                ListViewItem item;
                if(ADHelper.AvailableLdapProps[i] !=  map[ADHelper.AvailableLdapProps[i]])
                    item = new ListViewItem(new string[] { ADHelper.AvailableLdapProps[i] + " (" + map[ADHelper.AvailableLdapProps[i]]  +")"});
                else
                    item = new ListViewItem(new string[] { ADHelper.AvailableLdapProps[i] });

                item.Tag = ADHelper.AvailableLdapProps[i];
                if (tbl.Columns.Contains(ADHelper.AvailableLdapProps[i]))
                    tbl.Columns.Remove(ADHelper.AvailableLdapProps[i]);

                lstAvailable.Items.Add(item);
            }

            //Add calculated, default properties to available list
            for(int i=0;i<tbl.Columns.Count;i++)
            {
                ListViewItem item;
                if (tbl.Columns[i].ColumnName != map[tbl.Columns[i].ColumnName])
                    item = new ListViewItem(new string[] { tbl.Columns[i].ColumnName + " (" + map[tbl.Columns[i].ColumnName] + ")" });
                else
                    item = new ListViewItem(new string[] { tbl.Columns[i].ColumnName });
                item.Tag = tbl.Columns[i].ColumnName;
                lstAvailable.Items.Add(item);

            }
            lstAvailable.Sorting = SortOrder.Ascending;
            lstAvailable.Sort();

            if (lstAvailable.Items.Count == 0)
            {
                lstAvailable.Visible = false;
                lblWarning.Visible = true;
            }

        }

        private void lstProps_Click(object sender, EventArgs e)
        {
            //if (lstProps.SelectedItems.Count > 0)
            //    propertyGrid1.SelectedObject = lstProps.SelectedItems[0].Tag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomPropertyConfig setting = new CustomPropertyConfig();
            propertyGrid1.SelectedObject = setting;
            propertyGrid1.Focus();
            this.propertyConfigs.Add(setting);
            ListViewItem item = new ListViewItem(new string[] { "<new>", "","true"});
            item.Selected = true;
            item.Tag = "";
            lstProps.Items.Add(item);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstProps.SelectedItems.Count > 0)
            {
                try
                {
                    if (this.propertyConfigs.Contains((CustomPropertyConfig)lstProps.SelectedItems[0].Tag))
                        this.propertyConfigs.Remove((CustomPropertyConfig)lstProps.SelectedItems[0].Tag);
                }
                catch { }
            }

            CustomPropertyForm_Load(null, EventArgs.Empty);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (lstProps.SelectedItems.Count > 0)
            {
                if (s is PropertyGrid && ((PropertyGrid)s).SelectedObject is CustomPropertyConfig)
                {
                    CustomPropertyConfig cfg = (CustomPropertyConfig)((PropertyGrid)s).SelectedObject;
                    lstProps.SelectedItems[0].SubItems[0].Text = cfg.LdapPropertyName;
                    lstProps.SelectedItems[0].SubItems[1].Text = cfg.DisplayName;
                    lstProps.SelectedItems[0].SubItems[2].Text = cfg.DisplayColumn.ToString();
                 }
            }
        }

        private void CustomPropertyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void CustomPropertyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.CustomPropertyList = this.propertyConfigs;
                Properties.Settings.Default.Save();
            }
        }

        private void lstAvailable_DoubleClick(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedItems.Count == 0)
                return;

            string ldapname = lstAvailable.SelectedItems[0].Tag.ToString();
            for (int i = 0; i < lstProps.Items.Count; i++)
            {
                if (lstProps.Items[i].SubItems[0].Text == ldapname)
                {
                    lstProps.Items[i].Selected = true;
                    lstProps.Items[i].EnsureVisible();
                    lstProps.Focus();
                    return;
                }
            }

            CustomPropertyConfig cfg = new CustomPropertyConfig(ldapname, map[ldapname], true, 100);
            cfg.LdapPropertyName = lstAvailable.SelectedItems[0].Tag.ToString();

            propertyGrid1.SelectedObject = cfg;
            propertyGrid1.Focus();
            this.propertyConfigs.Add(cfg);
            ListViewItem item = new ListViewItem(new string[] { ldapname, map[ldapname], "true" });
            item.Selected = true;
            item.EnsureVisible();
            item.Tag = cfg;
            lstProps.Items.Add(item);

            

        }

        private void lstProps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProps.SelectedItems.Count > 0)
                propertyGrid1.SelectedObject = lstProps.SelectedItems[0].Tag;
        }
    }
}