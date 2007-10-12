using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using ActiveDirectoryHelper.Collections;
namespace ActiveDirectoryHelper
{
	/// <summary>
	/// Summary description for UserGroups.
	/// </summary>
	public class UserGroupsCtrl : System.Windows.Forms.UserControl
	{
        private List<string> itemsAdded = new List<string>();
		private System.Windows.Forms.ListView lstResults;
        private List<ADGroup> groupList;
        private List<HighlightSetting> highlightSettings;
		private string name;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.ColumnHeader colGroupName;
		private System.Windows.Forms.MenuItem mnuCopyList;
        private System.Windows.Forms.MenuItem mnuCopyName;
        private BindingSource bindingSource1;
        private LinkLabel linkLabel1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private IContainer components;
        private Label label1;
        ColumnSorter sorter = new ColumnSorter();

        public UserGroupsCtrl()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

        }
     
        internal void InitializeData(string name, List<ADGroup> groupList)
        {
            itemsAdded.Clear();
            this.highlightSettings = (List<HighlightSetting>)Properties.Settings.Default.OUHighlightSetting;
            if (this.highlightSettings == null) this.highlightSettings = new List<HighlightSetting>();

            this.lstResults.Items.Clear();
            if (groupList == null)
                return;
            this.groupList = groupList;
            this.name = name;
            this.Text = this.name;
            for (int i = 0; i < this.groupList.Count; i++)
            {
                if (itemsAdded.Contains(this.groupList[i].GroupName + this.groupList[i].IsInherited.ToString()))
                    continue;

                ListViewItem item = new ListViewItem(this.groupList[i].GroupName);
                item.Tag = this.groupList[i];
                if (this.groupList[i].IsInherited)
                    item.Font = new Font(item.Font, FontStyle.Italic);
                for (int j = 0; j < this.highlightSettings.Count; j++)
                {
                    if (this.groupList[i].DistinguishedName.IndexOf("OU=" + this.highlightSettings[j].OrgUnit) > -1)
                    {
                        item.ForeColor = this.highlightSettings[j].HighlightColor;
                        break;
                    }
                }
                this.lstResults.Items.Add(item);
                itemsAdded.Add(this.groupList[i].GroupName + this.groupList[i].IsInherited.ToString());



            }
            this.lstResults.Sorting = SortOrder.Ascending;
            this.lstResults.Sort();
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lstResults = new System.Windows.Forms.ListView();
            this.colGroupName = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuCopyName = new System.Windows.Forms.MenuItem();
            this.mnuCopyList = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroupName});
            this.lstResults.ContextMenu = this.contextMenu1;
            this.lstResults.FullRowSelect = true;
            this.lstResults.GridLines = true;
            this.lstResults.Location = new System.Drawing.Point(3, 3);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(316, 399);
            this.lstResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstResults.TabIndex = 1;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstResults_ColumnClick);
            // 
            // colGroupName
            // 
            this.colGroupName.Text = "Group Name";
            this.colGroupName.Width = 293;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCopyName,
            this.mnuCopyList,
            this.menuItem1,
            this.menuItem2});
            // 
            // mnuCopyName
            // 
            this.mnuCopyName.Index = 0;
            this.mnuCopyName.Text = "Copy Group Name(s)";
            this.mnuCopyName.Click += new System.EventHandler(this.mnuCopyName_Click);
            // 
            // mnuCopyList
            // 
            this.mnuCopyList.Index = 1;
            this.mnuCopyList.Text = "Copy List to Clipboard";
            this.mnuCopyList.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "Toggle Distinguished Name";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(206, 405);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(111, 14);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Configure Highlighting";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7F);
            this.label1.Location = new System.Drawing.Point(3, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "*Items in italics are inherited memberships";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserGroupsCtrl
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lstResults);
            this.Name = "UserGroupsCtrl";
            this.Size = new System.Drawing.Size(322, 423);
            this.Load += new System.EventHandler(this.UserGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void UserGroups_Load(object sender, System.EventArgs e)
		{
           
		}

        private void mnuCopy_Click(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for(int i=0;i<this.lstResults.Items.Count;i++)
			{
				for(int j=0;j<this.lstResults.Items[i].SubItems.Count;j++)
				{
					sb.Append("\""+this.lstResults.Items[i].SubItems[j].Text+"\"");
					sb.Append(",");
				}
				sb.Length=sb.Length-1;
				sb.Append("\r\n");
			}
			Clipboard.SetDataObject(sb.ToString(),true);
		}

		private void mnuCopyName_Click(object sender, System.EventArgs e)
		{
			if(this.lstResults.SelectedItems != null)
			{
				StringBuilder sb = new StringBuilder();
				for(int i=0;i<this.lstResults.SelectedItems.Count;i++)
				{
					sb.Append(this.lstResults.SelectedItems[i].Text+"\r\n");
				}
				sb.Length = sb.Length-2;
				Clipboard.SetDataObject(sb.ToString(),true);
			}
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<HighlightSetting> lst = (List<HighlightSetting>)Properties.Settings.Default.OUHighlightSetting;
            OrgUnitHighlightForm frmHighlight = new OrgUnitHighlightForm(lst);
            if (DialogResult.OK == frmHighlight.ShowDialog())
            {
                Properties.Settings.Default.OUHighlightSetting = frmHighlight.HighlightSettings;
                Properties.Settings.Default.Save();
            }
            frmHighlight.Dispose();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItems.Count > 0)
            {
                if( lstResults.SelectedItems[0].Text == ((ADGroup)lstResults.SelectedItems[0].Tag).GroupName)
                    lstResults.SelectedItems[0].Text = ((ADGroup)lstResults.SelectedItems[0].Tag).DistinguishedName;
                else
                    lstResults.SelectedItems[0].Text = ((ADGroup)lstResults.SelectedItems[0].Tag).GroupName;
            }
        }

        private void lstResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sorter.CurrentColumn = e.Column;
            lstResults.ListViewItemSorter = sorter;
            lstResults.Sort();
        }


	}
}
