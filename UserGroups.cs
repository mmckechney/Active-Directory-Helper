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
	public class UserGroups : System.Windows.Forms.Form
    {
        private List<ADGroup> groupList;
        private List<HighlightSetting> highlightSettings;
        private string name;
        private UserGroupsCtrl userGroupsCtrl1;
        private IContainer components;

        public UserGroups(string name, List<ADGroup> groupList)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.groupList = groupList;
            this.name = name;
            this.groupList = groupList;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userGroupsCtrl1 = new ActiveDirectoryHelper.UserGroupsCtrl();
            this.SuspendLayout();
            // 
            // userGroupsCtrl1
            // 
            this.userGroupsCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userGroupsCtrl1.Location = new System.Drawing.Point(10, 13);
            this.userGroupsCtrl1.Name = "userGroupsCtrl1";
            this.userGroupsCtrl1.Size = new System.Drawing.Size(327, 386);
            this.userGroupsCtrl1.TabIndex = 7;
            // 
            // UserGroups
            // 
            this.ClientSize = new System.Drawing.Size(346, 411);
            this.Controls.Add(this.userGroupsCtrl1);
            this.Name = "UserGroups";
            this.Text = "UserGroups";
            this.Load += new System.EventHandler(this.UserGroups_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void UserGroups_Load(object sender, System.EventArgs e)
        {
            this.userGroupsCtrl1.InitializeData(this.name, this.groupList);
            this.Text = this.name;
        }

        //private void mnuCopy_Click(object sender, System.EventArgs e)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < this.lstResults.Items.Count; i++)
        //    {
        //        for (int j = 0; j < this.lstResults.Items[i].SubItems.Count; j++)
        //        {
        //            sb.Append("\"" + this.lstResults.Items[i].SubItems[j].Text + "\"");
        //            sb.Append(",");
        //        }
        //        sb.Length = sb.Length - 1;
        //        sb.Append("\r\n");
        //    }
        //    Clipboard.SetDataObject(sb.ToString(), true);
        //}

        //private void UserGroups_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        this.Close();
        //    }
        //}

        //private void mnuCopyName_Click(object sender, System.EventArgs e)
        //{
        //    if (this.lstResults.SelectedItems != null)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i < this.lstResults.SelectedItems.Count; i++)
        //        {
        //            sb.Append(this.lstResults.SelectedItems[i].Text + "\r\n");
        //        }
        //        sb.Length = sb.Length - 2;
        //        Clipboard.SetDataObject(sb.ToString(), true);
        //    }
        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    List<HighlightSetting> lst = (List<HighlightSetting>)Properties.Settings.Default.OUHighlightSetting;
        //    OrgUnitHighlightForm frmHighlight = new OrgUnitHighlightForm(lst);
        //    if (DialogResult.OK == frmHighlight.ShowDialog())
        //    {
        //        Properties.Settings.Default.OUHighlightSetting = frmHighlight.HighlightSettings;
        //        Properties.Settings.Default.Save();
        //    }
        //    frmHighlight.Dispose();
        //}

        //private void menuItem2_Click(object sender, EventArgs e)
        //{
        //    if (lstResults.SelectedItems.Count > 0)
        //    {
        //        if (lstResults.SelectedItems[0].Text == ((ADGroup)lstResults.SelectedItems[0].Tag).GroupName)
        //            lstResults.SelectedItems[0].Text = ((ADGroup)lstResults.SelectedItems[0].Tag).DistinguishedName;
        //        else
        //            lstResults.SelectedItems[0].Text = ((ADGroup)lstResults.SelectedItems[0].Tag).GroupName;
        //    }
        //}
	}
}
