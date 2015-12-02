using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.DirectoryServices;
using ActiveDirectoryHelper.Tables;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;
using ActiveDirectoryHelper.Collections;
using System.Net;
using System.Configuration;
namespace ActiveDirectoryHelper
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private DateTime searchStartTime;

        private ADHelper helper;
        private System.Windows.Forms.ComboBox ddMixType;
        private System.Collections.SortedList groupList;
        private System.Windows.Forms.ComboBox cmbGroupList1;
        private System.Windows.Forms.ComboBox cmbGroupList2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSapId;
        private System.Windows.Forms.LinkLabel lnkClearAllItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private ActiveDirectoryHelper.UserListCtrl userList;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenu1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.GroupBox grpAccounts;
        private System.Windows.Forms.CheckBox chkClearResults;
        private Button btnFindAccount;
        private Button btnGetGroup;
        private Button btnGroupComparison;
        public BackgroundWorker bgGetGroupList;
        private Panel pnlSearchCriteria;
        private Panel pnlUserList;
        private ComboBox ddGroup1Join;
        private ComboBox ddGroup2Join;
        private DataGridView dgGroups1;
        private GroupListTable groupListTable1;
        private GroupListTable groupListTable2;
        private DataGridView dgGroup2;
        private Label label4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statRecordCount;
        private ToolStripStatusLabel statExecuteTime;
        private ToolStripStatusLabel statGeneral;
        private ToolStripProgressBar statGroupProgress;
        private BackgroundWorker bgFindAccount;
        private GroupBox groupBox2;
        private Button btnAddDomain;
        private ListView lstDomains;
        private ColumnHeader colGroupName;
        private BackgroundWorker bgCheckDomain;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel statDomain;
        private ContextMenuStrip ctxDomainList;
        private ToolStripMenuItem removeDomainToolStripMenuItem;
        private Button btnRefreshGroupList;
        private BackgroundWorker bgCheckForUpdates;
        private LinkLabel lnkMultipleAccounts;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem monitorUserPropertiesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem configureOrganizationalUnitHighlightingToolStripMenuItem;
        private Panel pnlGroupList;
        private UserGroupsCtrl userGroupsCtrl1;
        private Label label5;
        private Label label6;
        private UserPropertiesCtrl userPropertiesCtrl1;
        private CheckBox chkDisplayDisabled;
        private BackgroundWorker bgFindGroupMembers;
        private BackgroundWorker bgFindGroupComparison;
        private BackgroundWorker bgFindMultiple;
        private PropertyMonitorHelper propHelper;
        private bool startQuiet = false;
        private ToolStripMenuItem proxyCredentialsToolStripMenuItem;
        private ToolStripMenuItem configureOnLineDirectoryLinkFormatToolStripMenuItem;
        private ToolStripMenuItem customSearchFormatsToolStripMenuItem;
        private ToolStripMenuItem managerHierarchySearchToolStripMenuItem;
        private ToolStripMenuItem directReportSearchToolStripMenuItem;
        private ToolStripMenuItem revalidateDomainToolStripMenuItem;
        private ToolStripMenuItem activeDirectoryBindingCredentialsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem importExportSettingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private LinkLabel lnkGenericQuery;
        private BackgroundWorker bgGeneric;
        private bool proxyAuthAcknowledged = false;
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
        public MainForm(string[] args) : this()
        {
            //TODO: add custom properties to the Group member table at runtime....
            if (args.Length > 0)
            {
                string quiet = args[0].Trim().ToLower();
                if (quiet == "/q" || quiet == "/quiet" || quiet == "/quietstart")
                    this.startQuiet = true;
            }
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ddMixType = new System.Windows.Forms.ComboBox();
            this.cmbGroupList1 = new System.Windows.Forms.ComboBox();
            this.cmbGroupList2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgGroup2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupListTable2 = new ActiveDirectoryHelper.Tables.GroupListTable();
            this.dgGroups1 = new System.Windows.Forms.DataGridView();
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupListTable1 = new ActiveDirectoryHelper.Tables.GroupListTable();
            this.ddGroup2Join = new System.Windows.Forms.ComboBox();
            this.ddGroup1Join = new System.Windows.Forms.ComboBox();
            this.btnGroupComparison = new System.Windows.Forms.Button();
            this.btnGetGroup = new System.Windows.Forms.Button();
            this.lnkClearAllItems = new System.Windows.Forms.LinkLabel();
            this.grpAccounts = new System.Windows.Forms.GroupBox();
            this.lnkGenericQuery = new System.Windows.Forms.LinkLabel();
            this.chkDisplayDisabled = new System.Windows.Forms.CheckBox();
            this.lnkMultipleAccounts = new System.Windows.Forms.LinkLabel();
            this.btnFindAccount = new System.Windows.Forms.Button();
            this.chkClearResults = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSapId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bgGetGroupList = new System.ComponentModel.BackgroundWorker();
            this.pnlSearchCriteria = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRefreshGroupList = new System.Windows.Forms.Button();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statDomain = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstDomains = new System.Windows.Forms.ListView();
            this.colGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxDomainList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.revalidateDomainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDomainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDomain = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statGeneral = new System.Windows.Forms.ToolStripStatusLabel();
            this.statGroupProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.statExecuteTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importExportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.monitorUserPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureOrganizationalUnitHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customSearchFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerHierarchySearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directReportSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.proxyCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeDirectoryBindingCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlUserList = new System.Windows.Forms.Panel();
            this.userList = new ActiveDirectoryHelper.UserListCtrl();
            this.bgFindAccount = new System.ComponentModel.BackgroundWorker();
            this.bgCheckDomain = new System.ComponentModel.BackgroundWorker();
            this.bgCheckForUpdates = new System.ComponentModel.BackgroundWorker();
            this.pnlGroupList = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.userPropertiesCtrl1 = new ActiveDirectoryHelper.UserPropertiesCtrl();
            this.label5 = new System.Windows.Forms.Label();
            this.userGroupsCtrl1 = new ActiveDirectoryHelper.UserGroupsCtrl();
            this.bgFindGroupMembers = new System.ComponentModel.BackgroundWorker();
            this.bgFindGroupComparison = new System.ComponentModel.BackgroundWorker();
            this.bgFindMultiple = new System.ComponentModel.BackgroundWorker();
            this.bgGeneric = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable1)).BeginInit();
            this.grpAccounts.SuspendLayout();
            this.contextMenu1.SuspendLayout();
            this.pnlSearchCriteria.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.ctxDomainList.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlUserList.SuspendLayout();
            this.pnlGroupList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddMixType
            // 
            this.ddMixType.BackColor = System.Drawing.Color.Ivory;
            this.ddMixType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddMixType.Items.AddRange(new object[] {
            "Members not in -->",
            "Members not in  <--",
            "Intersection"});
            this.ddMixType.Location = new System.Drawing.Point(304, 40);
            this.ddMixType.Name = "ddMixType";
            this.ddMixType.Size = new System.Drawing.Size(136, 21);
            this.ddMixType.TabIndex = 2;
            // 
            // cmbGroupList1
            // 
            this.cmbGroupList1.BackColor = System.Drawing.Color.Ivory;
            this.cmbGroupList1.Items.AddRange(new object[] {
            "<getting groups>"});
            this.cmbGroupList1.Location = new System.Drawing.Point(16, 17);
            this.cmbGroupList1.MaxDropDownItems = 15;
            this.cmbGroupList1.Name = "cmbGroupList1";
            this.cmbGroupList1.Size = new System.Drawing.Size(280, 21);
            this.cmbGroupList1.TabIndex = 0;
            this.cmbGroupList1.DoubleClick += new System.EventHandler(this.cmbGroupList1_DoubleClick);
            this.cmbGroupList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGroupList1_KeyDown);
            // 
            // cmbGroupList2
            // 
            this.cmbGroupList2.BackColor = System.Drawing.Color.Ivory;
            this.cmbGroupList2.Items.AddRange(new object[] {
            "<getting groups>"});
            this.cmbGroupList2.Location = new System.Drawing.Point(448, 17);
            this.cmbGroupList2.MaxDropDownItems = 15;
            this.cmbGroupList2.Name = "cmbGroupList2";
            this.cmbGroupList2.Size = new System.Drawing.Size(280, 21);
            this.cmbGroupList2.TabIndex = 3;
            this.cmbGroupList2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbGroupList2_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgGroup2);
            this.groupBox1.Controls.Add(this.dgGroups1);
            this.groupBox1.Controls.Add(this.ddGroup2Join);
            this.groupBox1.Controls.Add(this.ddGroup1Join);
            this.groupBox1.Controls.Add(this.btnGroupComparison);
            this.groupBox1.Controls.Add(this.btnGetGroup);
            this.groupBox1.Controls.Add(this.lnkClearAllItems);
            this.groupBox1.Controls.Add(this.cmbGroupList1);
            this.groupBox1.Controls.Add(this.ddMixType);
            this.groupBox1.Controls.Add(this.cmbGroupList2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(3, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Groups (hit <enter> to add to list)";
            this.toolTip1.SetToolTip(this.groupBox1, "Use this section to get information about one or more groups");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(304, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Comparison Type";
            // 
            // dgGroup2
            // 
            this.dgGroup2.AutoGenerateColumns = false;
            this.dgGroup2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGroup2.ColumnHeadersVisible = false;
            this.dgGroup2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgGroup2.DataSource = this.groupListTable2;
            this.dgGroup2.Location = new System.Drawing.Point(448, 40);
            this.dgGroup2.Name = "dgGroup2";
            this.dgGroup2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgGroup2.RowHeadersWidth = 10;
            this.dgGroup2.Size = new System.Drawing.Size(280, 94);
            this.dgGroup2.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "GroupName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Group Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 268;
            // 
            // groupListTable2
            // 
            this.groupListTable2.TableName = "GroupListTable";
            // 
            // dgGroups1
            // 
            this.dgGroups1.AutoGenerateColumns = false;
            this.dgGroups1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgGroups1.ColumnHeadersVisible = false;
            this.dgGroups1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupNameDataGridViewTextBoxColumn});
            this.dgGroups1.DataSource = this.groupListTable1;
            this.dgGroups1.Location = new System.Drawing.Point(16, 40);
            this.dgGroups1.Name = "dgGroups1";
            this.dgGroups1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Format = "#";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGroups1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgGroups1.RowHeadersWidth = 10;
            this.dgGroups1.Size = new System.Drawing.Size(280, 94);
            this.dgGroups1.TabIndex = 13;
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "Group Name";
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            this.groupNameDataGridViewTextBoxColumn.Width = 268;
            // 
            // groupListTable1
            // 
            this.groupListTable1.TableName = "GroupListTable";
            // 
            // ddGroup2Join
            // 
            this.ddGroup2Join.BackColor = System.Drawing.Color.Ivory;
            this.ddGroup2Join.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddGroup2Join.Items.AddRange(new object[] {
            "OR",
            "AND"});
            this.ddGroup2Join.Location = new System.Drawing.Point(448, 142);
            this.ddGroup2Join.Name = "ddGroup2Join";
            this.ddGroup2Join.Size = new System.Drawing.Size(79, 21);
            this.ddGroup2Join.TabIndex = 12;
            // 
            // ddGroup1Join
            // 
            this.ddGroup1Join.BackColor = System.Drawing.Color.Ivory;
            this.ddGroup1Join.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddGroup1Join.Items.AddRange(new object[] {
            "OR",
            "AND"});
            this.ddGroup1Join.Location = new System.Drawing.Point(16, 142);
            this.ddGroup1Join.Name = "ddGroup1Join";
            this.ddGroup1Join.Size = new System.Drawing.Size(79, 21);
            this.ddGroup1Join.TabIndex = 11;
            // 
            // btnGroupComparison
            // 
            this.btnGroupComparison.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGroupComparison.Location = new System.Drawing.Point(533, 141);
            this.btnGroupComparison.Name = "btnGroupComparison";
            this.btnGroupComparison.Size = new System.Drawing.Size(126, 23);
            this.btnGroupComparison.TabIndex = 4;
            this.btnGroupComparison.Text = "Group Comparison";
            this.btnGroupComparison.UseVisualStyleBackColor = true;
            this.btnGroupComparison.Click += new System.EventHandler(this.btnGroupComparison_Click);
            // 
            // btnGetGroup
            // 
            this.btnGetGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetGroup.Location = new System.Drawing.Point(101, 140);
            this.btnGetGroup.Name = "btnGetGroup";
            this.btnGetGroup.Size = new System.Drawing.Size(98, 23);
            this.btnGetGroup.TabIndex = 1;
            this.btnGetGroup.Text = "Get Group";
            this.btnGetGroup.UseVisualStyleBackColor = true;
            this.btnGetGroup.Click += new System.EventHandler(this.btnGetGroup_Click);
            // 
            // lnkClearAllItems
            // 
            this.lnkClearAllItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkClearAllItems.Location = new System.Drawing.Point(310, 141);
            this.lnkClearAllItems.Name = "lnkClearAllItems";
            this.lnkClearAllItems.Size = new System.Drawing.Size(125, 16);
            this.lnkClearAllItems.TabIndex = 10;
            this.lnkClearAllItems.TabStop = true;
            this.lnkClearAllItems.Text = "Clear all  list items";
            this.lnkClearAllItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.lnkClearAllItems, "Click to clear all items from both lists");
            this.lnkClearAllItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClearAllItems_LinkClicked);
            // 
            // grpAccounts
            // 
            this.grpAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAccounts.Controls.Add(this.lnkGenericQuery);
            this.grpAccounts.Controls.Add(this.chkDisplayDisabled);
            this.grpAccounts.Controls.Add(this.lnkMultipleAccounts);
            this.grpAccounts.Controls.Add(this.btnFindAccount);
            this.grpAccounts.Controls.Add(this.chkClearResults);
            this.grpAccounts.Controls.Add(this.label3);
            this.grpAccounts.Controls.Add(this.txtSapId);
            this.grpAccounts.Controls.Add(this.label2);
            this.grpAccounts.Controls.Add(this.label1);
            this.grpAccounts.Controls.Add(this.txtFirstName);
            this.grpAccounts.Controls.Add(this.txtLastName);
            this.grpAccounts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAccounts.Location = new System.Drawing.Point(3, 6);
            this.grpAccounts.Name = "grpAccounts";
            this.grpAccounts.Size = new System.Drawing.Size(1076, 55);
            this.grpAccounts.TabIndex = 0;
            this.grpAccounts.TabStop = false;
            this.grpAccounts.Text = "Accounts";
            this.toolTip1.SetToolTip(this.grpAccounts, "Use this section to get information about a single user");
            this.grpAccounts.Enter += new System.EventHandler(this.grpAccounts_Enter);
            // 
            // lnkGenericQuery
            // 
            this.lnkGenericQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkGenericQuery.AutoSize = true;
            this.lnkGenericQuery.Location = new System.Drawing.Point(683, 33);
            this.lnkGenericQuery.Name = "lnkGenericQuery";
            this.lnkGenericQuery.Size = new System.Drawing.Size(124, 13);
            this.lnkGenericQuery.TabIndex = 12;
            this.lnkGenericQuery.TabStop = true;
            this.lnkGenericQuery.Text = "Generic LDAP Query";
            this.lnkGenericQuery.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGenericQuery_LinkClicked);
            // 
            // chkDisplayDisabled
            // 
            this.chkDisplayDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDisplayDisabled.Location = new System.Drawing.Point(821, 28);
            this.chkDisplayDisabled.Name = "chkDisplayDisabled";
            this.chkDisplayDisabled.Size = new System.Drawing.Size(246, 24);
            this.chkDisplayDisabled.TabIndex = 11;
            this.chkDisplayDisabled.Text = "Display Disabled Accounts";
            this.chkDisplayDisabled.CheckedChanged += new System.EventHandler(this.chkDisplayDisabled_CheckedChanged);
            // 
            // lnkMultipleAccounts
            // 
            this.lnkMultipleAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkMultipleAccounts.AutoSize = true;
            this.lnkMultipleAccounts.Location = new System.Drawing.Point(682, 12);
            this.lnkMultipleAccounts.Name = "lnkMultipleAccounts";
            this.lnkMultipleAccounts.Size = new System.Drawing.Size(132, 13);
            this.lnkMultipleAccounts.TabIndex = 10;
            this.lnkMultipleAccounts.TabStop = true;
            this.lnkMultipleAccounts.Text = "Find Multiple Accounts";
            this.lnkMultipleAccounts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMultipleAccounts_LinkClicked);
            // 
            // btnFindAccount
            // 
            this.btnFindAccount.BackColor = System.Drawing.Color.Ivory;
            this.btnFindAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFindAccount.Location = new System.Drawing.Point(474, 26);
            this.btnFindAccount.Name = "btnFindAccount";
            this.btnFindAccount.Size = new System.Drawing.Size(98, 23);
            this.btnFindAccount.TabIndex = 3;
            this.btnFindAccount.Text = "Find Account";
            this.btnFindAccount.UseVisualStyleBackColor = false;
            this.btnFindAccount.Click += new System.EventHandler(this.btnFindAccount_Click);
            // 
            // chkClearResults
            // 
            this.chkClearResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClearResults.Location = new System.Drawing.Point(821, 12);
            this.chkClearResults.Name = "chkClearResults";
            this.chkClearResults.Size = new System.Drawing.Size(246, 16);
            this.chkClearResults.TabIndex = 4;
            this.chkClearResults.Text = "Clear search after successful retrieval";
            this.chkClearResults.CheckedChanged += new System.EventHandler(this.chkClearResults_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(368, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Account Id";
            // 
            // txtSapId
            // 
            this.txtSapId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSapId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSapId.BackColor = System.Drawing.Color.Ivory;
            this.txtSapId.Location = new System.Drawing.Point(368, 28);
            this.txtSapId.Name = "txtSapId";
            this.txtSapId.Size = new System.Drawing.Size(96, 21);
            this.txtSapId.TabIndex = 2;
            this.txtSapId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grpAccounts_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFirstName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFirstName.BackColor = System.Drawing.Color.Ivory;
            this.txtFirstName.Location = new System.Drawing.Point(192, 28);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(168, 21);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grpAccounts_KeyDown);
            // 
            // txtLastName
            // 
            this.txtLastName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLastName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLastName.BackColor = System.Drawing.Color.Ivory;
            this.txtLastName.Location = new System.Drawing.Point(16, 28);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(168, 21);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grpAccounts_KeyDown);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Active Directory Helper";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.mnuOpen_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuExit});
            this.contextMenu1.Name = "contextMenu1";
            this.contextMenu1.Size = new System.Drawing.Size(104, 48);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(103, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // bgGetGroupList
            // 
            this.bgGetGroupList.WorkerReportsProgress = true;
            this.bgGetGroupList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGetGroupList_DoWork);
            this.bgGetGroupList.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgGetGroupList_ProgressChanged);
            this.bgGetGroupList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGetGroupList_RunWorkerCompleted);
            // 
            // pnlSearchCriteria
            // 
            this.pnlSearchCriteria.Controls.Add(this.groupBox2);
            this.pnlSearchCriteria.Controls.Add(this.statusStrip1);
            this.pnlSearchCriteria.Controls.Add(this.groupBox1);
            this.pnlSearchCriteria.Controls.Add(this.grpAccounts);
            this.pnlSearchCriteria.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSearchCriteria.Location = new System.Drawing.Point(0, 403);
            this.pnlSearchCriteria.Name = "pnlSearchCriteria";
            this.pnlSearchCriteria.Size = new System.Drawing.Size(1082, 285);
            this.pnlSearchCriteria.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnRefreshGroupList);
            this.groupBox2.Controls.Add(this.statusStrip2);
            this.groupBox2.Controls.Add(this.lstDomains);
            this.groupBox2.Controls.Add(this.btnAddDomain);
            this.groupBox2.Location = new System.Drawing.Point(855, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 193);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domains to Search";
            // 
            // btnRefreshGroupList
            // 
            this.btnRefreshGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshGroupList.Enabled = false;
            this.btnRefreshGroupList.Location = new System.Drawing.Point(96, 140);
            this.btnRefreshGroupList.Name = "btnRefreshGroupList";
            this.btnRefreshGroupList.Size = new System.Drawing.Size(122, 21);
            this.btnRefreshGroupList.TabIndex = 4;
            this.btnRefreshGroupList.Text = "Refresh Group List";
            this.btnRefreshGroupList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshGroupList.UseVisualStyleBackColor = true;
            this.btnRefreshGroupList.Click += new System.EventHandler(this.btnRefreshGroupList_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statDomain});
            this.statusStrip2.Location = new System.Drawing.Point(3, 168);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(218, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statDomain
            // 
            this.statDomain.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statDomain.Name = "statDomain";
            this.statDomain.Size = new System.Drawing.Size(203, 17);
            this.statDomain.Spring = true;
            this.statDomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstDomains
            // 
            this.lstDomains.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDomains.BackColor = System.Drawing.Color.Ivory;
            this.lstDomains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstDomains.CheckBoxes = true;
            this.lstDomains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroupName});
            this.lstDomains.ContextMenuStrip = this.ctxDomainList;
            this.lstDomains.FullRowSelect = true;
            this.lstDomains.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstDomains.Location = new System.Drawing.Point(9, 19);
            this.lstDomains.MultiSelect = false;
            this.lstDomains.Name = "lstDomains";
            this.lstDomains.ShowItemToolTips = true;
            this.lstDomains.Size = new System.Drawing.Size(206, 115);
            this.lstDomains.TabIndex = 2;
            this.lstDomains.UseCompatibleStateImageBehavior = false;
            this.lstDomains.View = System.Windows.Forms.View.Details;
            this.lstDomains.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstDomains_ItemChecked);
            // 
            // colGroupName
            // 
            this.colGroupName.Text = "Group Name";
            this.colGroupName.Width = 202;
            // 
            // ctxDomainList
            // 
            this.ctxDomainList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revalidateDomainToolStripMenuItem,
            this.removeDomainToolStripMenuItem});
            this.ctxDomainList.Name = "contextMenuStrip1";
            this.ctxDomainList.Size = new System.Drawing.Size(191, 48);
            this.ctxDomainList.Opening += new System.ComponentModel.CancelEventHandler(this.ctxDomainList_Opening);
            // 
            // revalidateDomainToolStripMenuItem
            // 
            this.revalidateDomainToolStripMenuItem.Name = "revalidateDomainToolStripMenuItem";
            this.revalidateDomainToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.revalidateDomainToolStripMenuItem.Text = "Re-validate domain(s)";
            this.revalidateDomainToolStripMenuItem.Click += new System.EventHandler(this.revalidateDomainToolStripMenuItem_Click);
            // 
            // removeDomainToolStripMenuItem
            // 
            this.removeDomainToolStripMenuItem.Name = "removeDomainToolStripMenuItem";
            this.removeDomainToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeDomainToolStripMenuItem.Text = "Remove domain";
            this.removeDomainToolStripMenuItem.Click += new System.EventHandler(this.removeDomainToolStripMenuItem_Click);
            // 
            // btnAddDomain
            // 
            this.btnAddDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDomain.Location = new System.Drawing.Point(9, 140);
            this.btnAddDomain.Name = "btnAddDomain";
            this.btnAddDomain.Size = new System.Drawing.Size(86, 21);
            this.btnAddDomain.TabIndex = 1;
            this.btnAddDomain.Text = "Add Domain";
            this.btnAddDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddDomain.UseVisualStyleBackColor = true;
            this.btnAddDomain.Click += new System.EventHandler(this.btnAddDomain_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statGeneral,
            this.statGroupProgress,
            this.statRecordCount,
            this.statExecuteTime,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1082, 24);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statGeneral
            // 
            this.statGeneral.AutoSize = false;
            this.statGeneral.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statGeneral.Name = "statGeneral";
            this.statGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.statGeneral.Size = new System.Drawing.Size(665, 19);
            this.statGeneral.Spring = true;
            this.statGeneral.Text = "Ready.";
            this.statGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statGroupProgress
            // 
            this.statGroupProgress.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.statGroupProgress.Name = "statGroupProgress";
            this.statGroupProgress.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.statGroupProgress.Size = new System.Drawing.Size(120, 18);
            // 
            // statRecordCount
            // 
            this.statRecordCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statRecordCount.Name = "statRecordCount";
            this.statRecordCount.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.statRecordCount.Size = new System.Drawing.Size(146, 19);
            this.statRecordCount.Text = "Record Count: 0";
            this.statRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statExecuteTime
            // 
            this.statExecuteTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statExecuteTime.Name = "statExecuteTime";
            this.statExecuteTime.Size = new System.Drawing.Size(134, 19);
            this.statExecuteTime.Text = "Execution Time (ms) : 0";
            this.statExecuteTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importExportSettingsToolStripMenuItem,
            this.toolStripSeparator4,
            this.monitorUserPropertiesToolStripMenuItem,
            this.configureOrganizationalUnitHighlightingToolStripMenuItem,
            this.toolStripSeparator2,
            this.customSearchFormatsToolStripMenuItem,
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem,
            this.toolStripSeparator1,
            this.proxyCredentialsToolStripMenuItem,
            this.activeDirectoryBindingCredentialsToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(59, 17);
            this.toolStripDropDownButton1.Text = "Settings";
            // 
            // importExportSettingsToolStripMenuItem
            // 
            this.importExportSettingsToolStripMenuItem.Name = "importExportSettingsToolStripMenuItem";
            this.importExportSettingsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.importExportSettingsToolStripMenuItem.Text = "Import/Export Settings";
            this.importExportSettingsToolStripMenuItem.Visible = false;
            this.importExportSettingsToolStripMenuItem.Click += new System.EventHandler(this.importExportSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // monitorUserPropertiesToolStripMenuItem
            // 
            this.monitorUserPropertiesToolStripMenuItem.Name = "monitorUserPropertiesToolStripMenuItem";
            this.monitorUserPropertiesToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.monitorUserPropertiesToolStripMenuItem.Text = "Monitor User Properties";
            this.monitorUserPropertiesToolStripMenuItem.Click += new System.EventHandler(this.monitorUserPropertiesToolStripMenuItem_Click);
            // 
            // configureOrganizationalUnitHighlightingToolStripMenuItem
            // 
            this.configureOrganizationalUnitHighlightingToolStripMenuItem.Name = "configureOrganizationalUnitHighlightingToolStripMenuItem";
            this.configureOrganizationalUnitHighlightingToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.configureOrganizationalUnitHighlightingToolStripMenuItem.Text = "Organizational Unit Highlighting";
            this.configureOrganizationalUnitHighlightingToolStripMenuItem.Click += new System.EventHandler(this.configureOrganizationalUnitHighlightingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // customSearchFormatsToolStripMenuItem
            // 
            this.customSearchFormatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managerHierarchySearchToolStripMenuItem,
            this.directReportSearchToolStripMenuItem});
            this.customSearchFormatsToolStripMenuItem.Name = "customSearchFormatsToolStripMenuItem";
            this.customSearchFormatsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.customSearchFormatsToolStripMenuItem.Text = "Custom Search Formats";
            // 
            // managerHierarchySearchToolStripMenuItem
            // 
            this.managerHierarchySearchToolStripMenuItem.Name = "managerHierarchySearchToolStripMenuItem";
            this.managerHierarchySearchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.managerHierarchySearchToolStripMenuItem.Text = "Manager Hierarchy Search";
            this.managerHierarchySearchToolStripMenuItem.Click += new System.EventHandler(this.managerHierarchySearchToolStripMenuItem_Click);
            // 
            // directReportSearchToolStripMenuItem
            // 
            this.directReportSearchToolStripMenuItem.Name = "directReportSearchToolStripMenuItem";
            this.directReportSearchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.directReportSearchToolStripMenuItem.Text = "Direct Report Search";
            this.directReportSearchToolStripMenuItem.Click += new System.EventHandler(this.directReportSearchToolStripMenuItem_Click);
            // 
            // configureOnLineDirectoryLinkFormatToolStripMenuItem
            // 
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem.Name = "configureOnLineDirectoryLinkFormatToolStripMenuItem";
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem.Text = "On-Line Directory Link Format";
            this.configureOnLineDirectoryLinkFormatToolStripMenuItem.Click += new System.EventHandler(this.configureOnLineDirectoryLinkFormatToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // proxyCredentialsToolStripMenuItem
            // 
            this.proxyCredentialsToolStripMenuItem.Name = "proxyCredentialsToolStripMenuItem";
            this.proxyCredentialsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.proxyCredentialsToolStripMenuItem.Text = "Proxy Credentials";
            this.proxyCredentialsToolStripMenuItem.Click += new System.EventHandler(this.proxyCredentialsToolStripMenuItem_Click);
            // 
            // activeDirectoryBindingCredentialsToolStripMenuItem
            // 
            this.activeDirectoryBindingCredentialsToolStripMenuItem.Name = "activeDirectoryBindingCredentialsToolStripMenuItem";
            this.activeDirectoryBindingCredentialsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.activeDirectoryBindingCredentialsToolStripMenuItem.Text = "Active Directory Binding Credentials";
            this.activeDirectoryBindingCredentialsToolStripMenuItem.Click += new System.EventHandler(this.activeDirectoryBindingCredentialsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlUserList
            // 
            this.pnlUserList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlUserList.Controls.Add(this.userList);
            this.pnlUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlUserList.Location = new System.Drawing.Point(0, 0);
            this.pnlUserList.Name = "pnlUserList";
            this.pnlUserList.Size = new System.Drawing.Size(1082, 73);
            this.pnlUserList.TabIndex = 6;
            // 
            // userList
            // 
            this.userList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userList.Location = new System.Drawing.Point(3, 3);
            this.userList.Name = "userList";
            this.userList.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.userList.Size = new System.Drawing.Size(1079, 67);
            this.userList.TabIndex = 3;
            this.userList.StatusEvent += new ActiveDirectoryHelper.StatusEventHandler(this.userList_StatusEvent);
            // 
            // bgFindAccount
            // 
            this.bgFindAccount.WorkerReportsProgress = true;
            this.bgFindAccount.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFindAccount_DoWork);
            this.bgFindAccount.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Searchers_ProgressChanged);
            this.bgFindAccount.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFindAccount_RunWorkerCompleted);
            // 
            // bgCheckDomain
            // 
            this.bgCheckDomain.WorkerReportsProgress = true;
            this.bgCheckDomain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCheckDomain_DoWork);
            this.bgCheckDomain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgCheckDomain_ProgressChanged);
            this.bgCheckDomain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCheckDomain_RunWorkerCompleted);
            // 
            // bgCheckForUpdates
            // 
            this.bgCheckForUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCheckForUpdates_DoWork);
            this.bgCheckForUpdates.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCheckForUpdates_RunWorkerCompleted);
            // 
            // pnlGroupList
            // 
            this.pnlGroupList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlGroupList.Controls.Add(this.label6);
            this.pnlGroupList.Controls.Add(this.userPropertiesCtrl1);
            this.pnlGroupList.Controls.Add(this.label5);
            this.pnlGroupList.Controls.Add(this.userGroupsCtrl1);
            this.pnlGroupList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGroupList.Location = new System.Drawing.Point(0, 73);
            this.pnlGroupList.Name = "pnlGroupList";
            this.pnlGroupList.Size = new System.Drawing.Size(1082, 330);
            this.pnlGroupList.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "User Properties:";
            // 
            // userPropertiesCtrl1
            // 
            this.userPropertiesCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPropertiesCtrl1.Location = new System.Drawing.Point(331, 24);
            this.userPropertiesCtrl1.Name = "userPropertiesCtrl1";
            this.userPropertiesCtrl1.Size = new System.Drawing.Size(748, 300);
            this.userPropertiesCtrl1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Group Memberships:";
            // 
            // userGroupsCtrl1
            // 
            this.userGroupsCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userGroupsCtrl1.Location = new System.Drawing.Point(3, 24);
            this.userGroupsCtrl1.Name = "userGroupsCtrl1";
            this.userGroupsCtrl1.Size = new System.Drawing.Size(328, 303);
            this.userGroupsCtrl1.TabIndex = 0;
            // 
            // bgFindGroupMembers
            // 
            this.bgFindGroupMembers.WorkerReportsProgress = true;
            this.bgFindGroupMembers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFindGroupMembers_DoWork);
            this.bgFindGroupMembers.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Searchers_ProgressChanged);
            this.bgFindGroupMembers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFindGroupMembers_RunWorkerCompleted);
            // 
            // bgFindGroupComparison
            // 
            this.bgFindGroupComparison.WorkerReportsProgress = true;
            this.bgFindGroupComparison.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFindGroupComparison_DoWork);
            this.bgFindGroupComparison.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Searchers_ProgressChanged);
            this.bgFindGroupComparison.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFindGroupComparison_RunWorkerCompleted);
            // 
            // bgFindMultiple
            // 
            this.bgFindMultiple.WorkerReportsProgress = true;
            this.bgFindMultiple.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFindMultiple_DoWork);
            this.bgFindMultiple.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Searchers_ProgressChanged);
            this.bgFindMultiple.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFindMultiple_RunWorkerCompleted);
            // 
            // bgGeneric
            // 
            this.bgGeneric.WorkerReportsProgress = true;
            this.bgGeneric.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGeneric_DoWork);
            this.bgGeneric.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Searchers_ProgressChanged);
            this.bgGeneric.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGeneric_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1082, 688);
            this.Controls.Add(this.pnlUserList);
            this.Controls.Add(this.pnlGroupList);
            this.Controls.Add(this.pnlSearchCriteria);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Active Directory Group and Membership Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroups1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable1)).EndInit();
            this.grpAccounts.ResumeLayout(false);
            this.grpAccounts.PerformLayout();
            this.contextMenu1.ResumeLayout(false);
            this.pnlSearchCriteria.ResumeLayout(false);
            this.pnlSearchCriteria.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ctxDomainList.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlUserList.ResumeLayout(false);
            this.pnlGroupList.ResumeLayout(false);
            this.pnlGroupList.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string mutexName = "{F0A29702-15E6-4d56-B9A2-D50382248BC9}";
            bool grantedOwnership;
            Mutex singleInstanceMutex = new Mutex(true, mutexName, out grantedOwnership);
            try
            {
                if (!grantedOwnership)
                {
                    MessageBox.Show("An instance of the Active Directory Helper is already running", "Unable to start another instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                /*
                 * If this is an version upgrade, grab the user.config from the last version for a smoother upgrade!
                 */
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                string appConfigFile = config.FilePath;
                string appConfigPath = Path.GetDirectoryName(appConfigFile);
                if (!File.Exists(appConfigFile))
                {
                    Properties.Settings.Default.Upgrade();
                }

                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
            finally
            {
                singleInstanceMutex.Close();
            }
        
        }

        private void SetExecuteTime(DateTime endTime)
        {
            TimeSpan span1 = DateTime.Now.Subtract(this.searchStartTime);
            this.statExecuteTime.Text = "Execution Time (ms): " + Math.Round(span1.TotalMilliseconds,0).ToString();
        }
        private void SetRecords(int numRecords)
        {
            this.statRecordCount.Text = "Record Count: " + numRecords.ToString();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

            if (this.startQuiet)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            pnlGroupList.Height = 0;
            this.Cursor = Cursors.AppStarting;
            this.cmbGroupList1.SelectedIndex = 0;
            this.cmbGroupList2.SelectedIndex = 0;
            string toolTipText = "Retrieving group list from Active Directory\r\nYou may still type in a group name";
            this.toolTip1.SetToolTip(cmbGroupList1, toolTipText);
            this.toolTip1.SetToolTip(cmbGroupList2, toolTipText);
            chkClearResults.Checked = Properties.Settings.Default.ClearAfterSuccessfulSearch;
            chkDisplayDisabled.Checked = Properties.Settings.Default.DisplayDisabledAccounts;

            //Set the app setting values
            if (Properties.Settings.Default.LastNameList == null) Properties.Settings.Default.LastNameList = new AutoCompleteStringCollection();
            if (Properties.Settings.Default.FirstNameList == null) Properties.Settings.Default.FirstNameList = new AutoCompleteStringCollection();
            if (Properties.Settings.Default.IdList == null) Properties.Settings.Default.IdList = new AutoCompleteStringCollection();
            if (Properties.Settings.Default.DomainList == null) Properties.Settings.Default.DomainList = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.SelectedDomains == null) Properties.Settings.Default.SelectedDomains = new System.Collections.Specialized.StringCollection();

            //Set the autocomplete object sources
            txtLastName.AutoCompleteCustomSource = Properties.Settings.Default.LastNameList;
            txtFirstName.AutoCompleteCustomSource = Properties.Settings.Default.FirstNameList;
            txtSapId.AutoCompleteCustomSource = Properties.Settings.Default.IdList;

            //Bind the domain list...
            StringEnumerator enumer = Properties.Settings.Default.DomainList.GetEnumerator();
            while (enumer.MoveNext())
            {
                bool selected = Properties.Settings.Default.SelectedDomains.Contains(enumer.Current);
                ListViewItem item = new ListViewItem(enumer.Current);
                if (selected)
                    item.Checked = true;

                lstDomains.Items.Add(item);

                if (selected && ADHelper.GlobalCatalogURL.Contains(enumer.Current) == false)
                    ADHelper.GlobalCatalogURL.Add(enumer.Current);
            }

            ddGroup1Join.SelectedIndex = 0;
            ddGroup2Join.SelectedIndex = 0;

            if (Properties.Settings.Default.OUHighlightSetting == null)
            {
                
                List<HighlightSetting> highlight = new List<HighlightSetting>();
                highlight.Add(new HighlightSetting("Groups", Color.Blue));
                highlight.Add(new HighlightSetting("DistributionGroups", Color.Gray));
                Properties.Settings.Default.OUHighlightSetting = highlight;
                Properties.Settings.Default.Save();
            }


            if (Properties.Settings.Default.PropertyMonitorSettings == null)
            {
                List<PropertyMonitorSetting> statMonitors = new List<PropertyMonitorSetting>();
                Properties.Settings.Default.PropertyMonitorSettings = statMonitors;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.CustomPropertyList == null)
            {
                List<CustomPropertyConfig> custProps = new List<CustomPropertyConfig>();
                Properties.Settings.Default.CustomPropertyList = custProps;
                Properties.Settings.Default.Save();
            }

            propHelper = new PropertyMonitorHelper();

            this.helper = new ADHelper();
            bgGetGroupList.RunWorkerAsync();

            bgCheckDomain.RunWorkerAsync();

            try
            {
                KeyValuePair<bool, int> checkVals = new KeyValuePair<bool, int>(false, -10);
                bgCheckForUpdates.RunWorkerAsync(checkVals);
            }
            catch { }
           
        }
        private void StartPropertyMonitoring()
        {
            propHelper = new PropertyMonitorHelper();
        }

        private void cmbGroupList1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.groupListTable1.AddGroupListTableRow(this.cmbGroupList1.Text);
            }
        }

        private void cmbGroupList2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.groupListTable2.AddGroupListTableRow(this.cmbGroupList2.Text);
            }
        }

        private void lnkClearAllItems_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.groupListTable1.Rows.Clear();
            this.groupListTable2.Rows.Clear();
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuOpen_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void grpAccounts_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFindAccount_Click(null, EventArgs.Empty);
        }

        private void cmbGroupList1_DoubleClick(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.cmbGroupList1.Items.Count; i++)
            {
                sb.Append(this.cmbGroupList1.Items[i].ToString() + "\r\n");
            }
            sb.Length = sb.Length - 2;
            Clipboard.SetDataObject(sb.ToString(), true);
            this.Cursor = Cursors.Default;
        }

        private void mnuPasteGroupList_Click(object sender, System.EventArgs e)
        {
            ListBox lstBox = (ListBox)((ContextMenu)((MenuItem)sender).Parent).SourceControl;
            IDataObject clipboard = Clipboard.GetDataObject();
            string clipString = (string)clipboard.GetData(typeof(string));
            string[] groups = clipString.Split('\r');
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i].ToString().Trim().Length > 0)
                    lstBox.Items.Add(groups[i].ToString().Trim());
            }

        }

        private void mnuCopyGroupList_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.cmbGroupList1.Items.Count; i++)
            {
                sb.Append(this.cmbGroupList1.Items[i].ToString() + "\r\n");
            }
            sb.Length = sb.Length - 2;
            Clipboard.SetDataObject(sb.ToString(), true);
            this.Cursor = Cursors.Default;
        }

        private void mnuDeleteGroups_Click(object sender, System.EventArgs e)
        {
            ListBox lstBox = (ListBox)((ContextMenu)((MenuItem)sender).Parent).SourceControl;
            while (lstBox.SelectedItems.Count > 0)
                lstBox.Items.Remove(lstBox.SelectedItems[0]);
        }

        private void btnFindAccount_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text.Trim().Length == 0 && txtFirstName.Text.Trim().Length == 0 && txtSapId.Text.Trim().Length == 0)
                return;

            if (Properties.Settings.Default.SelectedDomains == null || Properties.Settings.Default.SelectedDomains.Count == 0)
            {
                MessageBox.Show("A search can not be performed without a domain. Please select a valid domain or use the \"Add Domain\" button to add one", "Missing Domain Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            this.searchStartTime = DateTime.Now;
            bgFindAccount.RunWorkerAsync();
            CheckForUpdatesViaSearch();


        }
        private void CheckForUpdatesViaSearch()
        {
            try
            {
                KeyValuePair<bool, int> checkVals = new KeyValuePair<bool, int>(false, -60);
                bgCheckForUpdates.RunWorkerAsync(checkVals);
            }
            catch { }
        }
        private void btnGetGroup_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SelectedDomains == null || Properties.Settings.Default.SelectedDomains.Count == 0)
            {
                MessageBox.Show("A search can not be performed without a domain. Please select a valid domain or use the \"Add Domain\" button to add one", "Missing Domain Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (this.groupListTable1.Rows.Count == 0)
            {
                MessageBox.Show("Please add a group to the list by selecting a group from the drop-down and hitting the <enter> key", "Please select a group", MessageBoxButtons.OK);
                return;
            }

            List<string> groups = new List<string>();
            for (short i = 0; i < groupListTable1.Rows.Count; i++)
                if (!this.groupListTable1[i].IsNull(groupListTable1.GroupNameColumn.ColumnName) &&
                    this.groupListTable1[i].GroupName.Trim().Length > 0)
                    groups.Add(this.groupListTable1[i].GroupName);

            if (groups.Count == 0)
            {
                MessageBox.Show("Please add a group to the list by selecting a group from the drop-down and hitting the <enter> key", "Please select a group", MessageBoxButtons.OK);
                return;
            }

            string joinType = ddGroup1Join.SelectedItem.ToString().ToLower();
            bgFindGroupMembers.RunWorkerAsync(new KeyValuePair<List<string>, string>(groups, joinType));

        }    
        

        private void btnGroupComparison_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SelectedDomains == null || Properties.Settings.Default.SelectedDomains.Count == 0)
            {
                MessageBox.Show("A search can not be performed without a domain. Please select a valid domain or use the \"Add Domain\" button to add one", "Missing Domain Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (this.groupListTable1.Rows.Count == 0 ||
                this.groupListTable2.Rows.Count == 0)
            {
                MessageBox.Show("Please add a groups to both lists by selecting a group from the drop-down and hitting the <enter> key.", "Please select a group", MessageBoxButtons.OK);
                return;
            }

            if (ddMixType.SelectedItem == null)
            {
                MessageBox.Show("Please select a comparison type.", "Missing Comparison Type", MessageBoxButtons.OK);
                return;

            }

            List<string> groups1 = new List<string>();
            for (short i = 0; i < groupListTable1.Rows.Count; i++)
                if (!this.groupListTable1[i].IsNull(groupListTable1.GroupNameColumn.ColumnName) &&
                     this.groupListTable1[i].GroupName.Trim().Length > 0)
                    groups1.Add(this.groupListTable1[i].GroupName);

            List<string> groups2 = new List<string>();
            for (short i = 0; i < groupListTable2.Rows.Count; i++)
                if (!this.groupListTable2[i].IsNull(groupListTable2.GroupNameColumn.ColumnName) &&
                     this.groupListTable2[i].GroupName.Trim().Length > 0)
                    groups2.Add(this.groupListTable2[i].GroupName);


            if (groups1.Count == 0 || groups2.Count == 0)
            {
                MessageBox.Show("Please add a groups to both lists by selecting a group from the drop-down and hitting the <enter> key.", "Please select a group", MessageBoxButtons.OK);
                return;
            }

            GroupCompareInstructions inst = new GroupCompareInstructions(
                groups1,
                ddGroup1Join.SelectedItem.ToString().ToLower(),
                groups2,
                ddGroup2Join.SelectedItem.ToString().ToLower(),
                ddMixType.SelectedItem.ToString());

            bgFindGroupComparison.RunWorkerAsync(inst);
            
        }

        private void chkClearResults_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClearAfterSuccessfulSearch = chkClearResults.Checked;
            Properties.Settings.Default.Save();
        }


        private void SetUserDisplay(ref ADGroupMembersTable usertable)
        {
            SetUserDisplay(ref usertable, new List<ADGroup>());
        }
        private void SetUserDisplay(ref ADGroupMembersTable usertable,List<ADGroup> groups)
        {
            //If only 1 user, get the groups
            if (usertable.Rows.Count == 1)
            {
                pnlGroupList.Height = 330; // +(pnlUserList.Height - 67);
                // pnlUserList.Height = 67;

                pnlUserList.SendToBack();
                pnlUserList.Dock = DockStyle.Top;
                pnlGroupList.BringToFront();
                pnlGroupList.Dock = DockStyle.Fill;

                if (groups != null && groups.Count > 0)
                {
                    userGroupsCtrl1.InitializeData(usertable[0].FirstName + " " + usertable[0].LastName, groups);
                    this.userPropertiesCtrl1.InitializeData("", usertable[0]);
                }
                else
                {
                    groups = ADHelper.GetGroups(usertable[0].DistinguishedName, usertable[0].ObjectSID, usertable[0].SearchedDomain);
                    userGroupsCtrl1.InitializeData(usertable[0].FirstName + " " + usertable[0].LastName, groups);
                    this.userPropertiesCtrl1.InitializeData("", usertable[0]);
                }
            }
            else
            {
                this.SizeForUserList();
            }
        }
        private void SizeForUserList()
        {
            pnlGroupList.Height = 0;
            //pnlUserList.Height += subHeight;
            pnlGroupList.SendToBack();
            pnlGroupList.Dock = DockStyle.Bottom;

            pnlUserList.BringToFront();
            pnlUserList.Dock = DockStyle.Fill;
        }
 
      

        private void chkLstDomains_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (sender is CheckedListBox)
            {
                CheckedListBox chk = (CheckedListBox)sender;
                if (chk.SelectedItem != null && chk.SelectedItem.ToString().Trim().Length > 0)
                {
                    string val = chk.SelectedItem.ToString();
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        if (ADHelper.GlobalCatalogURL.Contains(val))
                            ADHelper.GlobalCatalogURL.Remove(val);

                        if (Properties.Settings.Default.SelectedDomains.Contains(val))
                            Properties.Settings.Default.SelectedDomains.Remove(val);

                    }
                    else
                    {
                        if (!ADHelper.GlobalCatalogURL.Contains(val))
                            ADHelper.GlobalCatalogURL.Add(val);

                        if (!Properties.Settings.Default.SelectedDomains.Contains(val))
                            Properties.Settings.Default.SelectedDomains.Add(val);
                    }
                    Properties.Settings.Default.Save();

                }

            }
        }

        private void btnAddDomain_Click(object sender, EventArgs e)
        {
            AddDomainForm frmAdd = new AddDomainForm();
            if (DialogResult.OK == frmAdd.ShowDialog())
            {
                if (!Properties.Settings.Default.DomainList.Contains(frmAdd.DomainName))
                {
                    Properties.Settings.Default.DomainList.Add(frmAdd.DomainName);
                    Properties.Settings.Default.Save();
                    ListViewItem item = new ListViewItem(frmAdd.DomainName);
                    item.Checked = true;
                    lstDomains.Items.Add(item);
                    lstDomains.Sort();


                        

                    bgCheckDomain.RunWorkerAsync();
                }
            }
        }

        private void lstDomains_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            string val = e.Item.Text;
            if (!e.Item.Checked)
            {
                if (ADHelper.GlobalCatalogURL.Contains(val))
                    ADHelper.GlobalCatalogURL.Remove(val);

                if (Properties.Settings.Default.SelectedDomains.Contains(val))
                    Properties.Settings.Default.SelectedDomains.Remove(val);

            }
            else
            {
                if (e.Item.ForeColor == Color.LightGray)
                {
                    e.Item.Checked = false;
                    return;
                }

                if (!ADHelper.GlobalCatalogURL.Contains(val))
                    ADHelper.GlobalCatalogURL.Add(val);

                if (!Properties.Settings.Default.SelectedDomains.Contains(val))
                    Properties.Settings.Default.SelectedDomains.Add(val);
            }

            //if it wasn't added manually,then get rid of it altogether
            if (Properties.Settings.Default.SelectedDomains.Contains("mydomain.com") &&
                !Properties.Settings.Default.DomainList.Contains("mydomain.com"))
                Properties.Settings.Default.SelectedDomains.Remove("mydomain.com");

            Properties.Settings.Default.Save();



        }

        private void ctxDomainList_Opening(object sender, CancelEventArgs e)
        {
            if (lstDomains.SelectedItems.Count == 0)
            {
                ctxDomainList.Close();
                return;
            }

            removeDomainToolStripMenuItem.Text = "Remove domain \"" + lstDomains.SelectedItems[0].Text + "\"";
        }

        private void removeDomainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string domain = lstDomains.SelectedItems[0].Text;
            lstDomains.Items.Remove(lstDomains.SelectedItems[0]);

            if (ADHelper.GlobalCatalogURL.Contains(domain))
                ADHelper.GlobalCatalogURL.Remove(domain);


            if (Properties.Settings.Default.DomainList.Contains(domain))
            {
                Properties.Settings.Default.DomainList.Remove(domain);
                Properties.Settings.Default.Save();
            }

        }

        private void btnRefreshGroupList_Click(object sender, EventArgs e)
        {
            btnRefreshGroupList.Enabled = false;
            bgGetGroupList.RunWorkerAsync();
        }

        private void userList_StatusEvent(string status)
        {
            this.statGeneral.Text = status;

        }

        private void lnkMultipleAccounts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FindMultipleForm frmMult = new FindMultipleForm();
            if (DialogResult.OK == frmMult.ShowDialog())
            {
                List<string> users = frmMult.UserList;
                bgFindMultiple.RunWorkerAsync(users);
                frmMult.Dispose();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<bool, int> checkVals = new KeyValuePair<bool, int>(true, 1);
                statGeneral.Text = "Accessing release notes and update data...";
                this.Cursor = Cursors.AppStarting;
                bgCheckForUpdates.RunWorkerAsync(checkVals);
            }
            catch {
                MessageBox.Show("Unable to access release notes. Please try again.", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statGeneral.Text = "Ready.";
                this.Cursor = Cursors.Default;
            }
        }

        private void monitorUserPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PropertyMonitorSetting> lst = (List<PropertyMonitorSetting>)Properties.Settings.Default.PropertyMonitorSettings;
            if (lst == null) lst = new List<PropertyMonitorSetting>();
            PropertyMonitorForm frmProp = new PropertyMonitorForm(lst);
            frmProp.ShowDialog();

            Properties.Settings.Default.PropertyMonitorSettings = frmProp.PropMonitors;
            Properties.Settings.Default.Save();
            List<PropertyMonitorSetting> setting = Properties.Settings.Default.PropertyMonitorSettings;
        }

        private void configureOrganizationalUnitHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void grpAccounts_Enter(object sender, EventArgs e)
        {

        }

        private void chkDisplayDisabled_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DisplayDisabledAccounts = chkDisplayDisabled.Checked;
            Properties.Settings.Default.Save();
        }

        #region Background handlers for Domain Checking/Validating
        private void bgCheckDomain_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            btnAddDomain.Enabled = false;

            //If reported, the domain fails...
            if (e.UserState is string)
            {
                for (int i = 0; i < lstDomains.Items.Count; i++)
                {
                    if (lstDomains.Items[i].Text == e.UserState.ToString())
                    {
                        if (e.ProgressPercentage == 0)
                        {
                            lstDomains.Items[i].ForeColor = Color.LightGray;
                            lstDomains.Items[i].Checked = false;
                            lstDomains.Items[i].ToolTipText = "The " + e.UserState.ToString() + " domain is currently unreachable";

                            if (ADHelper.GlobalCatalogURL.Contains(e.UserState.ToString()))
                                ADHelper.GlobalCatalogURL.Remove(e.UserState.ToString());
                        }
                        else if (e.ProgressPercentage == 20)
                        {
                            lstDomains.Items[i].ForeColor = Color.Black;
                            lstDomains.Items[i].Checked = true;
                            lstDomains.Items[i].ToolTipText = "";

                            if (!ADHelper.GlobalCatalogURL.Contains(e.UserState.ToString()))
                                ADHelper.GlobalCatalogURL.Add(e.UserState.ToString());
                        }

                    }
                }
            }
            else if (e.ProgressPercentage == 10 && e.UserState is string)
                statDomain.Text = "Validating " + e.UserState.ToString() + "...";
        }
        private void bgCheckDomain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statDomain.Text = "Validation Complete.";
            btnAddDomain.Enabled = true;
        }
        private void bgCheckDomain_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bg = (BackgroundWorker)sender;
            bg.ReportProgress(10);

            for (int i = 0; i < Properties.Settings.Default.DomainList.Count; i++)
            {
                if (i < Properties.Settings.Default.DomainList.Count)
                {
                    string domain = Properties.Settings.Default.DomainList[i];
                    bg.ReportProgress(10, domain);
                    if (!ADHelper.DomainIsReachable(domain))
                    {
                        bg.ReportProgress(0, domain);
                    }
                    else
                    {
                        bg.ReportProgress(20, domain);
                    }
                }
            }
        }
        #endregion

        #region Background handlers for Find Group Members
        private void bgFindGroupMembers_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is KeyValuePair<List<string>, string>)
            {
                ((BackgroundWorker)sender).ReportProgress(0);
                this.searchStartTime = DateTime.Now;
                List<string> groups = ((KeyValuePair<List<string>, string>)e.Argument).Key;
                string joinType = ((KeyValuePair<List<string>, string>)e.Argument).Value;
                ADGroupMembersTable memTable = ADHelper.GetGroupMembers(groups, joinType);
                e.Result = memTable;
            }

        }

        private void bgFindGroupMembers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is ADGroupMembersTable)
                {
                    ADGroupMembersTable memTable = (ADGroupMembersTable)e.Result;
                    DataView view = memTable.DefaultView;
                    view.Sort = memTable.LastNameColumn.ColumnName;
                    this.userList.PopulateMemberList(view);
                    SetUserDisplay(ref memTable);
                    SetExecuteTime(DateTime.Now);
                    SetRecords(view.Count);
                }
            }
            catch (System.Runtime.InteropServices.COMException exe)
            {
                if (exe.Message.IndexOf("The server is not operational") > -1)
                    MessageBox.Show("Unable to retrieve data. Can not connect to specified domain");
            }
            finally
            {
                this.EnableButtons();

            }
            CheckForUpdatesViaSearch();
        }
        #endregion

        #region Background handlers for Retrieving Group list from domains
        private void bgGetGroupList_DoWork(object sender, DoWorkEventArgs e)
        {
            ((BackgroundWorker)sender).ReportProgress(0);
            GroupLoadedEventArgs groups = this.helper.GetGroupsList();
            e.Result = groups;
        }

        private void bgGetGroupList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GroupLoadedEventArgs groups = (GroupLoadedEventArgs)e.Result;

            this.groupList = groups.FullGroupList;
            if (cmbGroupList1.Text == "<getting groups>")
                this.cmbGroupList1.Text = "";

            if (cmbGroupList2.Text == "<getting groups>")
                this.cmbGroupList2.Text = "";

            cmbGroupList1.Items.Clear();
            cmbGroupList2.Items.Clear();
            IDictionaryEnumerator enumer = groups.FullGroupList.GetEnumerator();
            while (enumer.MoveNext())
            {
                cmbGroupList1.Items.Add(enumer.Key);
                cmbGroupList2.Items.Add(enumer.Key);
            }
            string toolTipText = "Select or type in an Active Directory Group Name.\r\nHit <enter> to add it to the list below";
            toolTip1.SetToolTip(cmbGroupList1, toolTipText);
            toolTip1.SetToolTip(cmbGroupList2, toolTipText);

            this.EnableButtons();
        }


        private void bgGetGroupList_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            statGeneral.Text = "Retrieving groups for selected domains...";
            statGroupProgress.Style = ProgressBarStyle.Marquee;

        }
        #endregion

        private void Searchers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.DisableButtons();
            this.statGeneral.Text = "Searching for Accounts...";
            this.Cursor = Cursors.WaitCursor;
            this.statGroupProgress.Style = ProgressBarStyle.Marquee;
        }
        private void EnableButtons()
        {
            if (!this.bgFindMultiple.IsBusy && !this.bgFindAccount.IsBusy && !this.bgFindGroupComparison.IsBusy && !this.bgFindGroupMembers.IsBusy &&
                !this.bgGetGroupList.IsBusy)
            {
                this.btnFindAccount.Enabled = true;
                this.btnGetGroup.Enabled = true;
                this.btnGroupComparison.Enabled = true;
                this.lnkMultipleAccounts.Enabled = true;
                this.btnRefreshGroupList.Enabled = true;
                this.lnkGenericQuery.Enabled = true; 


                this.Cursor = Cursors.Default;
                this.statGroupProgress.Style = ProgressBarStyle.Blocks;
                this.statGeneral.Text = "Ready.";
            }
            
        }
        private void DisableButtons()
        {
            this.btnFindAccount.Enabled = false;
            this.btnGetGroup.Enabled = false;
            this.btnGroupComparison.Enabled = false;
            this.lnkMultipleAccounts.Enabled = false;
            this.lnkGenericQuery.Enabled = false;
        }
        
        #region Background handlers for Finding an individual account
        private void bgFindAccount_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is BackgroundWorker)
                ((BackgroundWorker)sender).ReportProgress(0);

            try
            {
                ADGroupMembersTable usertable = ADHelper.GetAccount(txtLastName.Text.Trim(), txtFirstName.Text.Trim(), txtSapId.Text.Trim());
                if (usertable.Rows.Count == 1)
                {
                    System.Collections.Generic.List<ADGroup> groups = ADHelper.GetGroups(usertable[0].DistinguishedName, usertable[0].ObjectSID, usertable[0].SearchedDomain);
                    KeyValuePair<ADGroupMembersTable, List<ADGroup>> set = new KeyValuePair<ADGroupMembersTable, List<ADGroup>>(usertable, groups);
                    e.Result = set;
                    return;
                }
                else
                {
                    e.Result = usertable;
                }
            }
            catch (Exception exe)
            {
                e.Result = exe;
            }
        }

        private void bgFindAccount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e == null || e.Result == null)
                return;

            ADGroupMembersTable usertable = null;
            List<ADGroup> groups = new List<ADGroup>();
            if (e.Result is ADGroupMembersTable)
                usertable = (ADGroupMembersTable)e.Result;
            else if (e.Result is KeyValuePair<ADGroupMembersTable, List<ADGroup>>)
            {
                usertable = ((KeyValuePair<ADGroupMembersTable, List<ADGroup>>)e.Result).Key;
                groups = ((KeyValuePair<ADGroupMembersTable, List<ADGroup>>)e.Result).Value;
            }
            else if (e.Result is Exception)
            {
                Exception exe = (Exception)e.Result;
                if (exe.Message.IndexOf("The server is not operational") > -1)
                    MessageBox.Show("Unable to retrieve data. Can not connect to specified domain");
                else
                    MessageBox.Show("Unable to retrieve data.\r\n"+exe.Message);
            }

            if (usertable != null)
            {
                DataView view = usertable.DefaultView;
                view.Sort = usertable.LastNameColumn.ColumnName;
                this.userList.PopulateMemberList(view);
                this.userList.PopulateMemberList(usertable);
                SetRecords(view.Count);

                if (view.Count > 0)
                {
                    if (txtLastName.Text.Length > 0 && !Properties.Settings.Default.LastNameList.Contains(txtLastName.Text))
                        Properties.Settings.Default.LastNameList.Add(txtLastName.Text);

                    if (txtFirstName.Text.Length > 0 && !Properties.Settings.Default.FirstNameList.Contains(txtFirstName.Text))
                        Properties.Settings.Default.FirstNameList.Add(txtFirstName.Text);

                    if (txtSapId.Text.Length > 0 && !Properties.Settings.Default.IdList.Contains(txtSapId.Text))
                        Properties.Settings.Default.IdList.Add(txtSapId.Text);

                    Properties.Settings.Default.Save();
                }


                if (chkClearResults.Checked && view.Count > 0)
                {
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtSapId.Text = string.Empty;
                }

                SetUserDisplay(ref usertable, groups);
            }
            SetExecuteTime(DateTime.Now);

            this.EnableButtons();
        }
        #endregion

        #region Background handlers for Program Update checking
        private void bgCheckForUpdates_DoWork(object sender, DoWorkEventArgs e)
        {

            VersionData verData = new VersionData();
            string filePath = string.Empty;
            try
            {
                verData.ManualCheck = ((KeyValuePair<bool, int>)e.Argument).Key;
                //Get the path to the update text file
                filePath = Properties.Settings.Default.ProgramVersionCheckURL;
                verData.UpdateFolder = Properties.Settings.Default.ProgramUpdateURL;
                verData.Contact = Properties.Settings.Default.ProgramUpdateContact;
                verData.ContactEMail = Properties.Settings.Default.ProgramUpdateContactEmail;
                verData.YourVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
            catch
            {
            }
            try
            {

                if (verData.ManualCheck || Properties.Settings.Default.LastProgramUpdateCheck < DateTime.Now.AddMinutes(((KeyValuePair<bool, int>)e.Argument).Value))
                {
                    verData.CheckIntervalElapsed = true;
                    try
                    {
                        //try the basic defauld credentials...
                        System.Net.WebRequest req = System.Net.WebRequest.Create(filePath);
                        req.Proxy = System.Net.WebRequest.DefaultWebProxy;
                        req.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                        req.Timeout = 5000;

                        System.Net.WebResponse resp = null;
                        System.IO.StreamReader sr = null;
                        string versionFile = string.Empty;

                        try
                        {
                            resp = req.GetResponse();
                            sr = new System.IO.StreamReader(resp.GetResponseStream());
                            versionFile = sr.ReadToEnd();
                            sr.Close();

                        }
                        catch
                        {
                            try
                            {
                                //If the basic don't work, go for the explicit credentials...
                                string pw = string.Empty;
                                string un = string.Empty;
                                if (Properties.Settings.Default.ProxyUseProxy)
                                {
                                    if (Properties.Settings.Default.ProxyPassword.Length > 0)
                                        pw = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyPassword);

                                    if (Properties.Settings.Default.ProxyUserName.Length > 0)
                                        un = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyUserName);


                                    NetworkCredential cred = new NetworkCredential(un, pw);
                                    req.Proxy = WebRequest.DefaultWebProxy;
                                    req.Proxy.Credentials = cred;

                                    resp = req.GetResponse();
                                    sr = new System.IO.StreamReader(resp.GetResponseStream());
                                    versionFile = sr.ReadToEnd();
                                    sr.Close();
                                }
                            }
                            catch (WebException we)
                            {
                                if (we.Message.ToLower().IndexOf("proxy authentication required") > -1)
                                {
                                    verData.ProxyFailure = true;
                                    verData.UpdateFileReadError = true;
                                }
                                else if (we.Message.ToLower().IndexOf("The operation has timed out") > -1)
                                {
                                    verData.ProxyFailure = false;
                                    verData.UpdateFileReadError = true;
                                }
                            }
                        }


                        if (versionFile.Length > 0)
                        {
                            string[] versions = versionFile.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                            verData.LatestVersion = new Version(versions[0]);
                            if (versions.Length > 1)
                                verData.ReleaseNotes = String.Join("\r\n", versions, 1, versions.Length - 1);
                        }
                    }
                 
                    catch (Exception exe)
                    {
                        verData.UpdateFileReadError = true;
                        System.Diagnostics.EventLog.WriteEntry("ActiveDirectoryHelper", "Unable to read update file.\r\n" + exe.ToString(), EventLogEntryType.Error, 901);
                    }

                    Properties.Settings.Default.LastProgramUpdateCheck = DateTime.Now;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    verData.CheckIntervalElapsed = false;
                }

                e.Result = verData;
            }
            catch (Exception exe)
            {
                verData.UpdateFileReadError = true;
                verData.CheckIntervalElapsed = true;
                System.Diagnostics.EventLog.WriteEntry("ActiveDirectoryHelper", "Error Checking for updates.\r\n" + exe.ToString(), EventLogEntryType.Error, 902);

            }
            finally
            {
                e.Result = verData;
            }

        }

        private void bgCheckForUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                try
                {
                    if (e.Result is VersionData)
                    {

                        VersionData verData = (VersionData)e.Result;

                        if (verData.ManualCheck)
                        {
                            this.statGeneral.Text = "Ready.";
                            this.Cursor = Cursors.Default;
                        }

                        if (verData.CheckIntervalElapsed || verData.ManualCheck)
                        {
                            if (verData.ProxyFailure && !this.proxyAuthAcknowledged)
                            {
                                MessageBox.Show("A proxy error was detected. In order to check for updates, you will need to provide your web proxy credentials.\r\nPlease enter your " +
                                    "proxy user name and password under \"Settings > Proxy Credentials\"", "Proxy Credentials Needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.proxyAuthAcknowledged = true;

                            }

                            if (verData.LatestVersion == null || verData.LatestVersion > verData.YourVersion || verData.ManualCheck)
                            {
                                VersionForm frmVersion = new VersionForm(verData);
                                frmVersion.ShowDialog();
                            }
                        }
                      
                    }
                }
                catch (Exception exe)
                {
                    System.Diagnostics.EventLog.WriteEntry("ActiveDirectoryHelper", "Unable to display New Version alert window.\r\n" + exe.ToString(), EventLogEntryType.Error, 901);

                }
                finally
                {
                }
            }
        }
        #endregion

        #region Background handlers for Retrieving Group membership comparisons
        private void bgFindGroupComparison_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument is GroupCompareInstructions)
                {
                    ((BackgroundWorker)sender).ReportProgress(0);
                    this.searchStartTime = DateTime.Now;
                    GroupCompareInstructions inst = (GroupCompareInstructions)e.Argument;
                    ADGroupMembersTable mem1 = null;
                    DataView view = null;
                    DateTime time1 = DateTime.Now;

                    mem1 = ADHelper.GetGroupMembers(inst.Group1List, inst.Group1Comparison);
                    ADGroupMembersTable mem2 = ADHelper.GetGroupMembers(inst.Group2List, inst.Group2Comparison);
                    StringBuilder sb = new StringBuilder();
                    string colName = mem1.AccountIdColumn.ColumnName;
                    switch (inst.GroupMixtype)
                    {
                        case "Members not in -->":
                            for (int i = 0; i < mem2.Rows.Count; i++)
                            {
                                sb.Append("'" + mem2[i].AccountId + "',");
                            }
                            sb.Length = sb.Length - 1;
                            view = mem1.DefaultView;
                            view.RowFilter = colName + " NOT IN (" + sb.ToString() + ")";
                            break;
                        case "Members not in  <--":
                            for (int i = 0; i < mem1.Rows.Count; i++)
                            {
                                sb.Append("'" + mem1[i].AccountId + "',");
                            }
                            view = mem2.DefaultView;
                            view.RowFilter = colName + " NOT IN (" + sb.ToString() + ")";
                            break;
                        case "Intersection":
                            for (int i = 0; i < mem1.Rows.Count; i++)
                            {
                                sb.Append("'" + mem1[i].AccountId + "',");
                            }
                            view = mem2.DefaultView;
                            view.RowFilter = colName + " IN (" + sb.ToString() + ")";
                            break;

                    }
                    view.RowStateFilter = DataViewRowState.CurrentRows;
                    KeyValuePair<DataView, ADGroupMembersTable> data = new KeyValuePair<DataView, ADGroupMembersTable>(view, mem1);
                    e.Result = data;
                }
            }
                catch(Exception exe)
            {
                    e.Result = exe;
                }
        }
        private void bgFindGroupComparison_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try{

                if (e.Result is KeyValuePair<DataView, ADGroupMembersTable>)
                {

                    DataView view = ((KeyValuePair<DataView, ADGroupMembersTable>)e.Result).Key;
                    ADGroupMembersTable mem1 = ((KeyValuePair<DataView, ADGroupMembersTable>)e.Result).Value;
                    view.Sort = mem1.LastNameColumn.ColumnName;
                    this.userList.PopulateMemberList(view);


                    SetUserDisplay(ref mem1);
                    SetExecuteTime(DateTime.Now);
                    SetRecords(view.Count);
                }
            }
            catch (System.Runtime.InteropServices.COMException exe)
            {
                if (exe.Message.IndexOf("The server is not operational") > -1)
                    MessageBox.Show("Unable to retrieve data. Can not connect to specified domain");
            }
            finally
            {
                this.EnableButtons();
            }
            CheckForUpdatesViaSearch();
        }
        #endregion

        #region Background handlers for Retrieving Finding Multiple accounts at once
        private void bgFindMultiple_DoWork(object sender, DoWorkEventArgs e)
        {
            ADGroupMembersTable tblConsolidated = new ADGroupMembersTable();
            if (e.Argument is List<string>)
            {
                ((BackgroundWorker)sender).ReportProgress(0);
                List<string> users = (List<string>)e.Argument;
               
                ADGroupMembersTable tblTmp = new ADGroupMembersTable();
                this.searchStartTime = DateTime.Now;

                for (int i = 0; i < users.Count; i++)
                {
                    tblTmp = ADHelper.GetAccountFromString(users[i]);
                    foreach (ADGroupMembersTableRow row in tblTmp)
                        tblConsolidated.ImportRow(row);

                    tblTmp.Rows.Clear();
                }

            }
            e.Result = tblConsolidated;
        }


        private void bgFindMultiple_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is ADGroupMembersTable)
            {
                ADGroupMembersTable tblConsolidated = (ADGroupMembersTable)e.Result;
                DataView view = tblConsolidated.DefaultView;
                view.Sort = tblConsolidated.LastNameColumn.ColumnName;
                this.userList.PopulateMemberList(view);
                SetUserDisplay(ref tblConsolidated);
                SetExecuteTime(DateTime.Now);
                SetRecords(tblConsolidated.Rows.Count);
                this.EnableButtons();
            }
        }
        #endregion

        private void proxyCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialsForm frmProx = new CredentialsForm(CredentialType.Proxy);
            frmProx.ShowDialog();
        }

        private void configureOnLineDirectoryLinkFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomQueryForm frmOL = new CustomQueryForm(CustomQueryType.OnLineDirectory);
            frmOL.ShowDialog();
        }



        private void managerHierarchySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomManagerQueryForm frmOL = new CustomManagerQueryForm();
            frmOL.ShowDialog();
        }

        private void directReportSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomDirectReportQueryForm frmOL = new CustomDirectReportQueryForm();
            frmOL.ShowDialog();
        }

        private void revalidateDomainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bgCheckDomain.IsBusy)
                bgCheckDomain.RunWorkerAsync();
            else
                MessageBox.Show("Domain validation is already in progress", "Currently Validating", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void activeDirectoryBindingCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CredentialsForm frmAD = new CredentialsForm(CredentialType.ADBinding);
            frmAD.ShowDialog();
        }

        private void importExportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportImportForm frmExp = new ExportImportForm();
            frmExp.ShowDialog();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void lnkGenericQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GenericUserQueryForm frmGeneric = new GenericUserQueryForm();
            if (DialogResult.OK == frmGeneric.ShowDialog())
            {
                this.searchStartTime = DateTime.Now;
                string ldapQuery= frmGeneric.Query;
                bgGeneric.RunWorkerAsync(ldapQuery);
                frmGeneric.Dispose();
            }
        }

        private void bgGeneric_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is BackgroundWorker)
                ((BackgroundWorker)sender).ReportProgress(0);

            var results =  ADHelper.GetAccountByQuery(e.Argument.ToString());
            e.Result = results;
        }

        private void bgGeneric_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgFindMultiple_RunWorkerCompleted(sender, e);

        }
    }
}