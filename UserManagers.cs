using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using ActiveDirectoryHelper.Tables;
namespace ActiveDirectoryHelper
{
	/// <summary>
	/// Summary description for UserGroups.
	/// </summary>
	public class UserManagers : System.Windows.Forms.Form
	{

		private ADGroupMembersTableRow memberRow;
		private ADGroupMembersTable memberTable;
		internal ActiveDirectoryHelper.UserListCtrl userListCtrl1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statCount;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserManagers(ADGroupMembersTableRow memberRow)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.memberRow = memberRow;
		}
		public UserManagers(ADGroupMembersTable memberTable)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.memberTable = memberTable;
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.userListCtrl1 = new ActiveDirectoryHelper.UserListCtrl();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1025, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statCount
            // 
            this.statCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statCount.Name = "statCount";
            this.statCount.Size = new System.Drawing.Size(52, 17);
            this.statCount.Text = "Count : 0";
            this.statCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userListCtrl1
            // 
            this.userListCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userListCtrl1.Location = new System.Drawing.Point(6, 11);
            this.userListCtrl1.Name = "userListCtrl1";
            this.userListCtrl1.Size = new System.Drawing.Size(1013, 342);
            this.userListCtrl1.TabIndex = 0;
            this.userListCtrl1.RecordCount += new ActiveDirectoryHelper.RecordCountEventHandler(this.userListCtrl1_RecordCount);
            // 
            // UserManagers
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1025, 381);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.userListCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "UserManagers";
            this.Text = "User Managers";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserGroups_KeyDown);
            this.Load += new System.EventHandler(this.UserManagers_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	



		private void UserGroups_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void UserManagers_Load(object sender, System.EventArgs e)
		{
			if(this.memberRow != null)
			{
                //this.userListCtrl1.ShowManagerColumn = true;
				this.userListCtrl1.BindRecursiveRows(this.memberRow);
			}
			else if(this.memberTable != null)
			{
				System.Data.DataView view = this.memberTable.DefaultView; 
				view.Sort = this.memberTable.LastNameColumn.ColumnName +" ASC";
				this.userListCtrl1.PopulateMemberList(view);
			}
		}

        private void userListCtrl1_RecordCount(int count)
        {
            this.statCount.Text = "Count: " + count.ToString();
        }




	

	
	}
}
