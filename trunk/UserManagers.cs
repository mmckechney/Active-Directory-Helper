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
			this.userListCtrl1 = new ActiveDirectoryHelper.UserListCtrl();
			this.SuspendLayout();
			// 
			// userListCtrl1
			// 
			this.userListCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.userListCtrl1.Location = new System.Drawing.Point(8, 8);
			this.userListCtrl1.Name = "userListCtrl1";
            //this.userListCtrl1.ShowManagerColumn = false;
			this.userListCtrl1.Size = new System.Drawing.Size(1000, 336);
			this.userListCtrl1.TabIndex = 0;
			// 
			// UserManagers
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 358);
			this.Controls.Add(this.userListCtrl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.Name = "UserManagers";
			this.Text = "User Managers";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserGroups_KeyDown);
			this.Load += new System.EventHandler(this.UserManagers_Load);
			this.ResumeLayout(false);

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




	

	
	}
}
