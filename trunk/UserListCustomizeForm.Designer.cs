namespace ActiveDirectoryHelper
{
    partial class UserListCustomizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListCustomizeForm));
            this.lstColumns = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.groupListTable1 = new ActiveDirectoryHelper.Tables.GroupListTable();
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstColumns
            // 
            this.lstColumns.CheckBoxes = true;
            this.lstColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstColumns.FullRowSelect = true;
            this.lstColumns.GridLines = true;
            this.lstColumns.Location = new System.Drawing.Point(26, 24);
            this.lstColumns.Name = "lstColumns";
            this.lstColumns.Size = new System.Drawing.Size(234, 260);
            this.lstColumns.TabIndex = 0;
            this.lstColumns.UseCompatibleStateImageBehavior = false;
            this.lstColumns.View = System.Windows.Forms.View.Details;
            this.lstColumns.SelectedIndexChanged += new System.EventHandler(this.lstColumns_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column";
            this.columnHeader1.Width = 211;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(61, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::ActiveDirectoryHelper.Properties.Resources.move_up;
            this.btnMoveUp.Location = new System.Drawing.Point(266, 50);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(27, 23);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::ActiveDirectoryHelper.Properties.Resources.move_down;
            this.btnMoveDown.Location = new System.Drawing.Point(266, 80);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(27, 23);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // groupListTable1
            // 
            this.groupListTable1.TableName = "GroupListTable";
            // 
            // UserListCustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 330);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstColumns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserListCustomizeForm";
            this.Text = "UserListCustomizeForm";
            this.Load += new System.EventHandler(this.UserListCustomizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupListTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstColumns;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private ActiveDirectoryHelper.Tables.GroupListTable groupListTable1;
    }
}