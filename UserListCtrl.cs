using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using ActiveDirectoryHelper.Tables;
using System.Collections.Generic;
namespace ActiveDirectoryHelper
{
    /// <summary>
    /// Summary description for UserListCtrl.
    /// </summary>
    public class UserListCtrl : System.Windows.Forms.UserControl
    {
        private static bool subscribedToLdapEvent = false;
        private static bool subscribedToCompilerEvent = false;
       // private bool showManagerColumn = false;

        //public bool ShowManagerColumn
        //{
        //    get { return showManagerColumn; }
        //    set
        //    {
        //        showManagerColumn = value;
        //        if (value) colManager.Width = 60;
        //    }
        //}
        private System.Windows.Forms.ContextMenu ctxClipBoard;
        private System.Windows.Forms.MenuItem mnuCopyUserId;
        private System.Windows.Forms.MenuItem mnuCopyNameAndId;
        private System.Windows.Forms.MenuItem mnuGetUserGroups;
        private System.Windows.Forms.MenuItem mnuManagers;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuClipBoard;
        private System.Windows.Forms.MenuItem mnuCopyforSql;
        private System.Windows.Forms.MenuItem mnuSpreadSheet;
        private System.Windows.Forms.MenuItem mnuDirectReports;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuCopyNameAndNumber;
        private System.Windows.Forms.MenuItem mnuCopyNameAndEMail;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuListProperties;
        private MenuItem mnuCopyIdAndGroups;
        private DataGridView dataGridView1;
        private BindingSource aDGroupMembersTableBindingSource;
        private ContextMenuStrip ctxActions;
        private ToolStripMenuItem getUsersGroupsToolStripMenuItem;
        private ToolStripMenuItem copyIDAndGroupsToolStripMenuItem;
        private ToolStripMenuItem getUsersManagerToolStripMenuItem;
        private ToolStripMenuItem getUsersDirectReportsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem listUsersPropertiesToolStripMenuItem;
        private ToolStripMenuItem copyValueToolStripMenuItem;
        private ToolStripMenuItem copyIDsWithDomainPrefixToolStripMenuItem;
        private ToolStripMenuItem copyIDsAsUserdomainToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem viewOnLineDirectoryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eMailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn business2PhoneDataGridViewTextBoxColumn;
        private ToolStripMenuItem customizeLdapPropertiesRetrievedToolStripMenuItem;
        private DataGridViewTextBoxColumn snDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn givennameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn samaccountnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telephonenumberDataGridViewTextBoxColumn;
        private IContainer components;

        public UserListCtrl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            if (UserListCtrl.subscribedToLdapEvent == false)
            {
                ADHelper.InvalidLdapQuery += new EventHandler(ADHelper_InvalidLdapQuery);
                UserListCtrl.subscribedToLdapEvent = true;
            }
            if (UserListCtrl.subscribedToCompilerEvent == false)
            {
                ADHelper.CSharpSnippetCompileError += new EventHandler(ADHelper_CSharpSnippetCompileError);
                UserListCtrl.subscribedToCompilerEvent = true;
            }
        }

        void ADHelper_CSharpSnippetCompileError(object sender, EventArgs e)
        {
            string message = "Failed to compile/execute custom hierarchy C# code snippet:\r\n\r\n" + sender.ToString();
            MessageBox.Show(message, "Custom Code Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        void ADHelper_InvalidLdapQuery(object sender, EventArgs e)
        {
            MessageBox.Show("The requested LDAP query is invalid. Please check your custom search settings via the \"Setting --> Custom Search Formats\" menu option",
                "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.MenuItem mnuCopyHighlightGroups;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctxClipBoard = new System.Windows.Forms.ContextMenu();
            this.mnuCopyUserId = new System.Windows.Forms.MenuItem();
            this.mnuCopyNameAndId = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuCopyNameAndNumber = new System.Windows.Forms.MenuItem();
            this.mnuCopyNameAndEMail = new System.Windows.Forms.MenuItem();
            this.mnuCopyIdAndGroups = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuGetUserGroups = new System.Windows.Forms.MenuItem();
            this.mnuManagers = new System.Windows.Forms.MenuItem();
            this.mnuDirectReports = new System.Windows.Forms.MenuItem();
            this.mnuListProperties = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuClipBoard = new System.Windows.Forms.MenuItem();
            this.mnuCopyforSql = new System.Windows.Forms.MenuItem();
            this.mnuSpreadSheet = new System.Windows.Forms.MenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.snDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.givennameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.samaccountnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephonenumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getUsersGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getUsersManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getUsersDirectReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUsersPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewOnLineDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDAndGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDsWithDomainPrefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIDsAsUserdomainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.customizeLdapPropertiesRetrievedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDGroupMembersTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            mnuCopyHighlightGroups = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ctxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aDGroupMembersTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuCopyHighlightGroups
            // 
            mnuCopyHighlightGroups.Index = 2;
            mnuCopyHighlightGroups.Text = "";
            // 
            // ctxClipBoard
            // 
            this.ctxClipBoard.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCopyUserId,
            this.mnuCopyNameAndId,
            this.menuItem1,
            this.menuItem3,
            this.mnuGetUserGroups,
            this.mnuManagers,
            this.mnuDirectReports,
            this.mnuListProperties,
            this.menuItem2,
            this.mnuClipBoard,
            this.mnuCopyforSql,
            this.mnuSpreadSheet});
            // 
            // mnuCopyUserId
            // 
            this.mnuCopyUserId.Index = 0;
            this.mnuCopyUserId.Text = "Copy Account Id(s)";
            // 
            // mnuCopyNameAndId
            // 
            this.mnuCopyNameAndId.Index = 1;
            this.mnuCopyNameAndId.Text = "Copy Name(s) and Account Id(s)";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCopyNameAndNumber,
            this.mnuCopyNameAndEMail,
            mnuCopyHighlightGroups,
            this.mnuCopyIdAndGroups});
            this.menuItem1.Text = "Copy...";
            // 
            // mnuCopyNameAndNumber
            // 
            this.mnuCopyNameAndNumber.Index = 0;
            this.mnuCopyNameAndNumber.Text = "Name(s) and Phone Number(s)";
            // 
            // mnuCopyNameAndEMail
            // 
            this.mnuCopyNameAndEMail.Index = 1;
            this.mnuCopyNameAndEMail.Text = "Name(s) and E-Mail Adddres(s)";
            // 
            // mnuCopyIdAndGroups
            // 
            this.mnuCopyIdAndGroups.Index = 3;
            this.mnuCopyIdAndGroups.Text = "ID(s) and All Groups";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // mnuGetUserGroups
            // 
            this.mnuGetUserGroups.Index = 4;
            this.mnuGetUserGroups.Text = "Get User\'s Groups";
            // 
            // mnuManagers
            // 
            this.mnuManagers.Index = 5;
            this.mnuManagers.Text = "Get User\'s Managers";
            // 
            // mnuDirectReports
            // 
            this.mnuDirectReports.Index = 6;
            this.mnuDirectReports.Text = "Get User\'s Direct Reports";
            // 
            // mnuListProperties
            // 
            this.mnuListProperties.Index = 7;
            this.mnuListProperties.Text = "List User\'s Properties";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Text = "-";
            // 
            // mnuClipBoard
            // 
            this.mnuClipBoard.Index = 9;
            this.mnuClipBoard.Text = "Copy List to Clip Board";
            // 
            // mnuCopyforSql
            // 
            this.mnuCopyforSql.Index = 10;
            this.mnuCopyforSql.Text = "Copy Account Ids for Sql";
            // 
            // mnuSpreadSheet
            // 
            this.mnuSpreadSheet.Index = 11;
            this.mnuSpreadSheet.Text = "Copy Account Ids for Spread Sheet";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.snDataGridViewTextBoxColumn,
            this.givennameDataGridViewTextBoxColumn,
            this.samaccountnameDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.telephonenumberDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.ctxActions;
            this.dataGridView1.DataSource = this.aDGroupMembersTableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1075, 336);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnDisplayIndexChanged);
            // 
            // snDataGridViewTextBoxColumn
            // 
            this.snDataGridViewTextBoxColumn.DataPropertyName = "sn";
            this.snDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.snDataGridViewTextBoxColumn.Name = "snDataGridViewTextBoxColumn";
            this.snDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // givennameDataGridViewTextBoxColumn
            // 
            this.givennameDataGridViewTextBoxColumn.DataPropertyName = "givenname";
            this.givennameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.givennameDataGridViewTextBoxColumn.Name = "givennameDataGridViewTextBoxColumn";
            this.givennameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // samaccountnameDataGridViewTextBoxColumn
            // 
            this.samaccountnameDataGridViewTextBoxColumn.DataPropertyName = "samaccountname";
            this.samaccountnameDataGridViewTextBoxColumn.HeaderText = "Acct ID";
            this.samaccountnameDataGridViewTextBoxColumn.Name = "samaccountnameDataGridViewTextBoxColumn";
            this.samaccountnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "EMail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            this.mailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telephonenumberDataGridViewTextBoxColumn
            // 
            this.telephonenumberDataGridViewTextBoxColumn.DataPropertyName = "telephonenumber";
            this.telephonenumberDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.telephonenumberDataGridViewTextBoxColumn.Name = "telephonenumberDataGridViewTextBoxColumn";
            this.telephonenumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ctxActions
            // 
            this.ctxActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getUsersGroupsToolStripMenuItem,
            this.getUsersManagerToolStripMenuItem,
            this.getUsersDirectReportsToolStripMenuItem,
            this.listUsersPropertiesToolStripMenuItem,
            this.toolStripSeparator2,
            this.viewOnLineDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyValueToolStripMenuItem,
            this.copyIDAndGroupsToolStripMenuItem,
            this.copyIDsWithDomainPrefixToolStripMenuItem,
            this.copyIDsAsUserdomainToolStripMenuItem,
            this.toolStripSeparator3,
            this.customizeLdapPropertiesRetrievedToolStripMenuItem});
            this.ctxActions.Name = "ctxActions";
            this.ctxActions.Size = new System.Drawing.Size(281, 264);
            this.ctxActions.Opening += new System.ComponentModel.CancelEventHandler(this.ctxActions_Opening);
            // 
            // getUsersGroupsToolStripMenuItem
            // 
            this.getUsersGroupsToolStripMenuItem.Name = "getUsersGroupsToolStripMenuItem";
            this.getUsersGroupsToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.getUsersGroupsToolStripMenuItem.Text = "Get User\'s Groups";
            this.getUsersGroupsToolStripMenuItem.Click += new System.EventHandler(this.getUsersGroupsToolStripMenuItem_Click);
            // 
            // getUsersManagerToolStripMenuItem
            // 
            this.getUsersManagerToolStripMenuItem.Name = "getUsersManagerToolStripMenuItem";
            this.getUsersManagerToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.getUsersManagerToolStripMenuItem.Text = "Get User\'s Management";
            this.getUsersManagerToolStripMenuItem.Click += new System.EventHandler(this.getUsersManagerToolStripMenuItem_Click);
            // 
            // getUsersDirectReportsToolStripMenuItem
            // 
            this.getUsersDirectReportsToolStripMenuItem.Name = "getUsersDirectReportsToolStripMenuItem";
            this.getUsersDirectReportsToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.getUsersDirectReportsToolStripMenuItem.Text = "Get User\'s Direct Reports";
            this.getUsersDirectReportsToolStripMenuItem.Click += new System.EventHandler(this.getUsersDirectReportsToolStripMenuItem_Click);
            // 
            // listUsersPropertiesToolStripMenuItem
            // 
            this.listUsersPropertiesToolStripMenuItem.Name = "listUsersPropertiesToolStripMenuItem";
            this.listUsersPropertiesToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.listUsersPropertiesToolStripMenuItem.Text = "List User\'s Properties";
            this.listUsersPropertiesToolStripMenuItem.Click += new System.EventHandler(this.listUsersPropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(277, 6);
            // 
            // viewOnLineDirectoryToolStripMenuItem
            // 
            this.viewOnLineDirectoryToolStripMenuItem.Enabled = false;
            this.viewOnLineDirectoryToolStripMenuItem.Name = "viewOnLineDirectoryToolStripMenuItem";
            this.viewOnLineDirectoryToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.viewOnLineDirectoryToolStripMenuItem.Text = "View On-Line Directory";
            this.viewOnLineDirectoryToolStripMenuItem.Click += new System.EventHandler(this.viewOnLineDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.copyValueToolStripMenuItem.Text = "Copy Value";
            this.copyValueToolStripMenuItem.Click += new System.EventHandler(this.copyValueToolStripMenuItem_Click);
            // 
            // copyIDAndGroupsToolStripMenuItem
            // 
            this.copyIDAndGroupsToolStripMenuItem.Name = "copyIDAndGroupsToolStripMenuItem";
            this.copyIDAndGroupsToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.copyIDAndGroupsToolStripMenuItem.Text = "Copy IDs and Groups";
            this.copyIDAndGroupsToolStripMenuItem.Click += new System.EventHandler(this.copyIDAndGroupsToolStripMenuItem_Click);
            // 
            // copyIDsWithDomainPrefixToolStripMenuItem
            // 
            this.copyIDsWithDomainPrefixToolStripMenuItem.Name = "copyIDsWithDomainPrefixToolStripMenuItem";
            this.copyIDsWithDomainPrefixToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.copyIDsWithDomainPrefixToolStripMenuItem.Text = "Copy IDs with Domain Prefix";
            this.copyIDsWithDomainPrefixToolStripMenuItem.Click += new System.EventHandler(this.copyIDsWithDomainPrefixToolStripMenuItem_Click);
            // 
            // copyIDsAsUserdomainToolStripMenuItem
            // 
            this.copyIDsAsUserdomainToolStripMenuItem.Name = "copyIDsAsUserdomainToolStripMenuItem";
            this.copyIDsAsUserdomainToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.copyIDsAsUserdomainToolStripMenuItem.Text = "Copy IDs as user@domain";
            this.copyIDsAsUserdomainToolStripMenuItem.Click += new System.EventHandler(this.copyIDsAsUserdomainToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(277, 6);
            // 
            // customizeLdapPropertiesRetrievedToolStripMenuItem
            // 
            this.customizeLdapPropertiesRetrievedToolStripMenuItem.Name = "customizeLdapPropertiesRetrievedToolStripMenuItem";
            this.customizeLdapPropertiesRetrievedToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.customizeLdapPropertiesRetrievedToolStripMenuItem.Text = "Customize Properties/Columns Retrieved";
            this.customizeLdapPropertiesRetrievedToolStripMenuItem.Click += new System.EventHandler(this.customizeLdapPropertiesRetrievedToolStripMenuItem_Click);
            // 
            // aDGroupMembersTableBindingSource
            // 
            this.aDGroupMembersTableBindingSource.DataSource = typeof(ActiveDirectoryHelper.Tables.ADGroupMembersTable);
            // 
            // UserListCtrl
            // 
            this.Controls.Add(this.dataGridView1);
            this.Name = "UserListCtrl";
            this.Size = new System.Drawing.Size(1075, 336);
            this.Load += new System.EventHandler(this.UserListCtrl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ctxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aDGroupMembersTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

      



        
        internal void PopulateMemberList(DataView view)
        {
            if (!Properties.Settings.Default.DisplayDisabledAccounts)
            {
                string disabledFilter = ((ADGroupMembersTable)view.Table).AccountIdColumn.ColumnName + " NOT LIKE 'term_%' AND " +
                       ((ADGroupMembersTable)view.Table).AccountStatusColumn.ColumnName + " NOT IN ('Disabled','PW Exp')";
                
                if (view.RowFilter.Length > 0)
                    view.RowFilter = view.RowFilter + " AND " + disabledFilter;
                else
                    view.RowFilter = disabledFilter;

            }
            this.aDGroupMembersTableBindingSource.DataSource = view;

            if (this.RecordCount != null)
                this.RecordCount(view.Count);
           
        }
        internal void PopulateMemberList(ADGroupMembersTable memTable)
        {
            PopulateMemberList(memTable.DefaultView);
        }




        //private void AddListItem(ADGroupMembersTableRow row, int rank)
        //{
        //    this.lstResults.Items.Add(new ListViewItem(new string[] { row.LastName, row.FirstName, row.AccountId, row.Title, row.Country, row.EMail, row.Phone, rank.ToString(), row.DistinguishedName }));
        //}
        public void BindRecursiveRows(ADGroupMembersTableRow memberRow)
        {

            ADGroupMembersTable tbl = new ADGroupMembersTable();
            tbl.ImportRow(memberRow);
            int rank = 0;

            ADGroupMembersTableRow manager = memberRow.ManagerRow;
            try
            {
                while (manager.LastName.Length > 0)
                {
                    rank++;
                    manager.Rank = rank;
                    tbl.ImportRow(manager);
                    manager = manager.ManagerRow;
                }
            }
            catch { }
            this.aDGroupMembersTableBindingSource.DataSource = tbl;

            if (this.RecordCount != null)
                this.RecordCount(tbl.Rows.Count);
        }

        private void getUsersGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;

            ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
            string userId = row.AccountId;
            string firstName = row.FirstName;
            string lastName = row.LastName;
            string distinguishedName = row.DistinguishedName;
            System.Collections.Generic.List<ADGroup> groups = ADHelper.GetGroups(distinguishedName, row.ObjectSID,row.SearchedDomain);
            UserGroups frmGrps = new UserGroups("  " + firstName + " " + lastName + " (" + userId + ")", groups);
            frmGrps.Show();


        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {   if(e.RowIndex >= 0)
                    if (this.dataGridView1[e.ColumnIndex, e.RowIndex].Selected == false)
                    {
                        this.dataGridView1.ClearSelection();
                        this.dataGridView1[e.ColumnIndex, e.RowIndex].Selected = true;
                    }
            }
        }

        private void copyIDAndGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.StatusEvent != null)
                this.StatusEvent("Copying Groups for selected IDs");
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;
            System.Collections.Generic.List<int> usedRows = new System.Collections.Generic.List<int>();
            StringBuilder sb = new StringBuilder();
            sb.Append("User ID\tGroup Memberships\r\n");
            for (int i = this.dataGridView1.SelectedCells.Count-1; i > -1 ; i--)
            {
                if (usedRows.Contains(i))
                    continue;

                ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[i].OwningRow.DataBoundItem).Row;
                string id = row.AccountId;
                string distinguishedName = row.DistinguishedName;
                System.Collections.Generic.List<ADGroup> grps = ADHelper.GetGroups(distinguishedName,row.ObjectSID,row.SearchedDomain);
                grps.Sort();
                sb.Append(id + "\t");
                for (int j = 0; j < grps.Count; j++)
                    sb.Append(grps[j].GroupName + ", ");
                sb.Length = sb.Length - 2;
                sb.Append("\r\n");

                usedRows.Add(i);

            }
            Clipboard.SetDataObject(sb.ToString(), true);

            if (this.StatusEvent != null)
                this.StatusEvent("ID and Group List copied to Clipboard. Ready.");

            this.Cursor = Cursors.Default;

        }

        private void getUsersManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;
            this.Cursor = Cursors.AppStarting;
            ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;

            //string distinguishedName = row.DistinguishedName;
            ADGroupMembersTableRow memberRow = ADHelper.GetUsersManagers(row);
            UserManagers frmManagers = new UserManagers(memberRow);
            this.Cursor = Cursors.Default;
            frmManagers.ShowDialog();
        }

        private void getUsersDirectReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;
            this.Cursor = Cursors.AppStarting;
            ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;

            string distinguishedName = row.DistinguishedName;
            string lastName = row.LastName;
            string firstName = row.FirstName;
            string userId = row.AccountId;

            ADGroupMembersTable memberTable = ADHelper.GetDirectReports(row);
            UserManagers frmReports = new UserManagers(memberTable);
            frmReports.Text = firstName + " " + lastName + " (" + userId + ") :: Direct Reports";
            this.Cursor = Cursors.Default;
            frmReports.ShowDialog();
        }

        private void listUsersPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;

            ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;


            string distinguishedName = row.DistinguishedName;
            string lastName = row.LastName;
            string firstName = row.FirstName;
            string userId = row.AccountId;
            ADGroupMembersTableRow user = ADHelper.GetAccountByDN(distinguishedName);
            UserProperties frmProps = new UserProperties("  " + firstName + " " + lastName + " (" + userId + ")", user);
            frmProps.Show();
        }
        public event StatusEventHandler StatusEvent;
        public event RecordCountEventHandler RecordCount;

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.dataGridView1.SelectedCells.Count; i++)
            {
                sb.Append(this.dataGridView1.SelectedCells[i].Value.ToString() + "\r\n");
            }
            sb.Length = sb.Length - 2;
            Clipboard.SetDataObject(sb.ToString(), true);
        }

        private void copyIDsWithDomainPrefixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.StatusEvent != null)
                this.StatusEvent("Copying ID's with Domain Prefix");

            if (this.dataGridView1.SelectedCells.Count == 0)
                return;
            System.Collections.Generic.List<int> usedRows = new System.Collections.Generic.List<int>();
            StringBuilder sb = new StringBuilder();
            for (int i = this.dataGridView1.SelectedCells.Count - 1; i > -1; i--)
            {
                if (usedRows.Contains(i))
                    continue;

                ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[i].OwningRow.DataBoundItem).Row;
                sb.Append(ParseDNForDomain(row.DistinguishedName) + @"\" + row.AccountId + "\r\n");
            }
            Clipboard.SetDataObject(sb.ToString(), true);

            if (this.StatusEvent != null)
                this.StatusEvent("Domain Prefixed ID's copied to Clipboard. Ready.");

            this.Cursor = Cursors.Default;

        }
        private string ParseDNForDomain(string DN)
        {

            string[] commaSplit = DN.Split(',');
            for (int i = 0; i < commaSplit.Length; i++)
            {
                if (commaSplit[i].StartsWith("DC="))
                {
                    string[] equalSplit = commaSplit[i].Split('=');
                    if (equalSplit.Length > 1)
                        return equalSplit[1];
                }
            }
            return "unknown";
        }

        private void copyIDsAsUserdomainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.StatusEvent != null)
                this.StatusEvent("Copying ID's with @Domain");

            if (this.dataGridView1.SelectedCells.Count == 0)
                return;
            System.Collections.Generic.List<int> usedRows = new System.Collections.Generic.List<int>();
            StringBuilder sb = new StringBuilder();
            for (int i = this.dataGridView1.SelectedCells.Count - 1; i > -1; i--)
            {
                if (usedRows.Contains(i))
                    continue;

                ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[i].OwningRow.DataBoundItem).Row;
                sb.Append(row.AccountId +"@"+ParseDNForAtDomain(row.DistinguishedName) +"\r\n");
            }
            Clipboard.SetDataObject(sb.ToString(), true);

            if (this.StatusEvent != null)
                this.StatusEvent("Domain ID's copied to Clipboard. Ready.");

            this.Cursor = Cursors.Default;
        }
        private string ParseDNForAtDomain(string DN)
        {
            string domain = string.Empty;
            string[] commaSplit = DN.Split(',');
            for (int i = 0; i < commaSplit.Length; i++)
            {
                if (commaSplit[i].StartsWith("DC="))
                {
                    string[] equalSplit = commaSplit[i].Split('=');
                    if (equalSplit.Length > 1)
                        domain += equalSplit[1] + ".";
                }
            }
            return domain.Substring(0, domain.Length - 1);
        }

        private void ctxActions_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.OnLineDirectoryFormat.Length > 0)
                    viewOnLineDirectoryToolStripMenuItem.Enabled = true;
                else
                    viewOnLineDirectoryToolStripMenuItem.Enabled = false;
            }
            catch { }
        }

        private void viewOnLineDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
                return;

            try
            {
                string url = Properties.Settings.Default.OnLineDirectoryFormat;
                ADGroupMembersTableRow row = (ADGroupMembersTableRow)((DataRowView)this.dataGridView1.SelectedCells[0].OwningRow.DataBoundItem).Row;
                url = ADHelper.PerformTokenReplacement(url, row);
                System.Diagnostics.Process.Start(url);
            }
            catch
            {
            }
        }

        //private void customizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetCustomPropertyColumns();
        //    DataGridViewColumnCollection coll = this.dataGridView1.Columns;
        //    UserListCustomizeForm frmCustom = new UserListCustomizeForm(ref coll);
        //    frmCustom.ShowDialog();
        //}

        private void dataGridView1_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void UserListCtrl_Load(object sender, EventArgs e)
        {
            SetCustomPropertyColumns();
            //SetColumnDefaults();
        }

        private void SaveColumnDefaults()
        {
            //Save re-ordering to the default config
            List<CustomPropertyConfig> cfg;
            if (Properties.Settings.Default.CustomPropertyList == null)
                cfg = GetPropertyDefaults();
            else
                cfg = Properties.Settings.Default.CustomPropertyList;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                 DataGridViewColumn col = dataGridView1.Columns[i];
                for (int j = 0; j < cfg.Count; j++)
                {
                    if (col.Name == cfg[j].ColumnName)
                    {
                        cfg[j].SortOrder = col.DisplayIndex;
                        cfg[j].ColumnWidth = col.Width;
                        break;
                    }
                }
            }
            Properties.Settings.Default.CustomPropertyList = cfg;
            Properties.Settings.Default.Save();
        }
        private void SetCustomPropertyColumns()
        {
            List<CustomPropertyConfig> cfgs;
            if (Properties.Settings.Default.CustomPropertyList == null)
                cfgs = GetPropertyDefaults();
            else
                cfgs = Properties.Settings.Default.CustomPropertyList;

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                this.dataGridView1.Columns[i].Visible = false;

            for (int i = 0; i < cfgs.Count; i++)
            {
                CustomPropertyConfig cfg = cfgs[i];
                if (!this.dataGridView1.Columns.Contains(cfg.ColumnName))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = cfg.ColumnName;
                    col.HeaderText = cfg.DisplayName;
                    col.DataPropertyName = cfg.LdapPropertyName;
                    col.Visible = cfg.DisplayColumn;
                    col.Width = cfg.ColumnWidth;
                    col.DisplayIndex = cfg.SortOrder;
                    this.dataGridView1.Columns.Add(col);
                }
                else
                {
                    this.dataGridView1.Columns[cfg.ColumnName].HeaderText = cfg.DisplayName;
                    this.dataGridView1.Columns[cfg.ColumnName].DisplayIndex = ((cfg.SortOrder >= this.dataGridView1.Columns.Count) ? this.dataGridView1.Columns.Count-1 :cfg.SortOrder);
                    this.dataGridView1.Columns[cfg.ColumnName].Width = cfg.ColumnWidth;
                    this.dataGridView1.Columns[cfg.ColumnName].Visible = cfg.DisplayColumn;
                }
            }

            ADGroupMembersTable tmp = new ADGroupMembersTable();
            for (int i = 0; i < tmp.Columns.Count; i++)
            {
                if (!this.dataGridView1.Columns.Contains(tmp.Columns[i].ColumnName + "DataGridViewTextBoxColumn"))
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = tmp.Columns[i].ColumnName + "DataGridViewTextBoxColumn";
                    col.HeaderText = tmp.Columns[i].ColumnName;
                    col.DataPropertyName = tmp.Columns[i].ColumnName;
                    col.Visible = false;
                    this.dataGridView1.Columns.Add(col);
                }
            }



            
        }
        //private void SetColumnDefaults()
        //{
        //    List<CustomPropertyConfig> cfg = null;
        //    //Load the custom column configuration if it exists
        //    if (Properties.Settings.Default.CustomPropertyList == null)
        //        cfg = GetPropertyDefaults();
        //    else
        //        cfg = Properties.Settings.Default.CustomPropertyList;
        //    bool found = false;
        //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //    {
        //        for (int j = 0; j < cfg.Count; j++)
        //        {
        //            if (dataGridView1.Columns[i].Name == cfg[j].ColumnName)
        //            {
        //                dataGridView1.Columns[i].Visible = cfg[j].DisplayColumn;
        //                dataGridView1.Columns[i].DisplayIndex = cfg[j].SortOrder;
        //                dataGridView1.Columns[i].Width = cfg[j].ColumnWidth;
        //                found = true;
        //                break;
        //            }
        //        }
        //        if (!found)
        //            dataGridView1.Columns[i].Visible = false;

        //        found = false;
        //    }

        //}
        private List<CustomPropertyConfig> GetPropertyDefaults()
        {

            List<CustomPropertyConfig> cfgs = new List<CustomPropertyConfig>();
            CustomPropertyConfig cfg = new CustomPropertyConfig("sn","Last Name",true,0,"snDataGridViewTextBoxColumn", 144);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("givenname","First Name",true,1,"givennameDataGridViewTextBoxColumn", 103);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("samaccountname","Account ID",true,2,"samaccountnameDataGridViewTextBoxColumn", 93);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("title","Title",true,3,"titleDataGridViewTextBoxColumn", 198);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("mail","EMail",true,4,"mailDataGridViewTextBoxColumn", 171);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("telephonenumber","Phone",true,5,"telephonenumberDataGridViewTextBoxColumn", 100);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("AccountStatus", "AcctStat", true, 6, "AccountStatusDataGridViewTextBoxColumn", 75);
            cfgs.Add(cfg);

            cfg = new CustomPropertyConfig("SearchedDomain", "Domain", true, 6, "SearchedDomainDataGridViewTextBoxColumn", 100);
            cfgs.Add(cfg);


            Properties.Settings.Default.CustomPropertyList = cfgs;
            Properties.Settings.Default.Save();
            return cfgs;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveColumnDefaults();
        }

        private void customizeLdapPropertiesRetrievedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomPropertyForm frmProps = new CustomPropertyForm();
            frmProps.ShowDialog();
            SetCustomPropertyColumns();
        }

    }
    public delegate void StatusEventHandler(string status);
    public delegate void RecordCountEventHandler(int count);
}

