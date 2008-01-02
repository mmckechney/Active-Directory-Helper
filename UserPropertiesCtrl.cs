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
	public class UserPropertiesCtrl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private ActiveDirectoryHelper.Tables.ADGroupMembersTableRow userProperties;
		private System.Windows.Forms.ListView lstProps;
		private string name;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuCopyValues;
		private System.Windows.Forms.MenuItem mnuCopyProps;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserPropertiesCtrl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}
		public void InitializeData(string name, ActiveDirectoryHelper.Tables.ADGroupMembersTableRow userProperties)
		{
            this.lstProps.Items.Clear();
			this.userProperties = userProperties;
			this.name = name;
            this.Text = string.Format(this.Text, this.name);
            if (this.userProperties != null)
            {
                foreach (System.Data.DataColumn col in this.userProperties.Table.Columns)
                {
                    if (col.ColumnName != "ManagerRow" && col.ColumnName != "Rank")
                    {
                        ListViewItem item = new ListViewItem(new string[] { col.ColumnName, this.userProperties[col.ColumnName].ToString() });
                        lstProps.Items.Add(item);
                    }
                }
            }
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
            this.lstProps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuCopyValues = new System.Windows.Forms.MenuItem();
            this.mnuCopyProps = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // lstProps
            // 
            this.lstProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstProps.ContextMenu = this.contextMenu1;
            this.lstProps.FullRowSelect = true;
            this.lstProps.GridLines = true;
            this.lstProps.Location = new System.Drawing.Point(3, 3);
            this.lstProps.Name = "lstProps";
            this.lstProps.Size = new System.Drawing.Size(680, 399);
            this.lstProps.TabIndex = 0;
            this.lstProps.UseCompatibleStateImageBehavior = false;
            this.lstProps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 485;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCopyValues,
            this.mnuCopyProps});
            // 
            // mnuCopyValues
            // 
            this.mnuCopyValues.Index = 0;
            this.mnuCopyValues.Text = "Copy Value(s)";
            this.mnuCopyValues.Click += new System.EventHandler(this.mnuCopyValues_Click);
            // 
            // mnuCopyProps
            // 
            this.mnuCopyProps.Index = 1;
            this.mnuCopyProps.Text = "Copy Property/Value Set(s)";
            this.mnuCopyProps.Click += new System.EventHandler(this.mnuCopyProps_Click);
            // 
            // UserPropertiesCtrl
            // 
            this.Controls.Add(this.lstProps);
            this.Name = "UserPropertiesCtrl";
            this.Size = new System.Drawing.Size(686, 405);
            this.ResumeLayout(false);

		}
		#endregion


		private void mnuCopyValues_Click(object sender, System.EventArgs e)
		{
			if(this.lstProps.SelectedItems != null)
			{
				StringBuilder sb = new StringBuilder();
				for(int i=0;i<this.lstProps.SelectedItems.Count;i++)
				{
					sb.Append(this.lstProps.SelectedItems[i].SubItems[1].Text+"\r\n");
				}
				sb.Length = sb.Length-2;
				Clipboard.SetDataObject(sb.ToString(),true);
			}
		}

		private void mnuCopyProps_Click(object sender, System.EventArgs e)
		{
			if(this.lstProps.SelectedItems != null)
			{
				StringBuilder sb = new StringBuilder();
				for(int i=0;i<this.lstProps.SelectedItems.Count;i++)
				{
					sb.Append(this.lstProps.SelectedItems[i].SubItems[0].Text+"\t"+this.lstProps.SelectedItems[i].SubItems[1].Text+"\r\n");
				}
				sb.Length = sb.Length-2;
				Clipboard.SetDataObject(sb.ToString(),true);
			}
		}
	}
}
