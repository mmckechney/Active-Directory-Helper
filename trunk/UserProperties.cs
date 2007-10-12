using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
namespace ActiveDirectoryHelper
{
	/// <summary>
	/// Summary description for UserProperties.
	/// </summary>
	public class UserProperties : System.Windows.Forms.Form
    {
        private ActiveDirectoryHelper.Tables.ADGroupMembersTableRow userProperties;
        private string name;
        private UserPropertiesCtrl userPropertiesCtrl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserProperties()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}
		public UserProperties(string name, ActiveDirectoryHelper.Tables.ADGroupMembersTableRow userProperties)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.userProperties = userProperties;
			this.name = name;
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
            this.userPropertiesCtrl1 = new ActiveDirectoryHelper.UserPropertiesCtrl();
            this.SuspendLayout();
            // 
            // userPropertiesCtrl1
            // 
            this.userPropertiesCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userPropertiesCtrl1.Location = new System.Drawing.Point(6, 7);
            this.userPropertiesCtrl1.Name = "userPropertiesCtrl1";
            this.userPropertiesCtrl1.Size = new System.Drawing.Size(693, 384);
            this.userPropertiesCtrl1.TabIndex = 1;
            // 
            // UserProperties
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(705, 398);
            this.Controls.Add(this.userPropertiesCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UserProperties";
            this.Text = "User Properties {0}";
            this.Load += new System.EventHandler(this.UserProperties_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void UserProperties_Load(object sender, System.EventArgs e)
		{
            this.userPropertiesCtrl1.InitializeData(this.name, this.userProperties);
            this.Text = String.Format(this.Text, this.name);
		
		}

	
	}
}
