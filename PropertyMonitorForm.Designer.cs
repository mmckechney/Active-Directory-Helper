namespace ActiveDirectoryHelper
{
    partial class PropertyMonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyMonitorForm));
            this.lstSettings = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.MaskedTextBox();
            this.ddProperties = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.grpEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSettings
            // 
            this.lstSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4});
            this.lstSettings.FullRowSelect = true;
            this.lstSettings.GridLines = true;
            this.lstSettings.Location = new System.Drawing.Point(12, 29);
            this.lstSettings.Name = "lstSettings";
            this.lstSettings.Size = new System.Drawing.Size(746, 120);
            this.lstSettings.TabIndex = 0;
            this.lstSettings.UseCompatibleStateImageBehavior = false;
            this.lstSettings.View = System.Windows.Forms.View.Details;
            this.lstSettings.Click += new System.EventHandler(this.lstSettings_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User ID to monitor";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "AD Property";
            this.columnHeader2.Width = 214;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Check Interval (min)";
            this.columnHeader3.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Current Value";
            this.columnHeader5.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Checked";
            this.columnHeader4.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Monitor Settings:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(15, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpEdit.Controls.Add(this.btnCancel);
            this.grpEdit.Controls.Add(this.btnSave);
            this.grpEdit.Controls.Add(this.label4);
            this.grpEdit.Controls.Add(this.txtInterval);
            this.grpEdit.Controls.Add(this.ddProperties);
            this.grpEdit.Controls.Add(this.label3);
            this.grpEdit.Controls.Add(this.label2);
            this.grpEdit.Controls.Add(this.txtUserID);
            this.grpEdit.Enabled = false;
            this.grpEdit.Location = new System.Drawing.Point(15, 186);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(528, 118);
            this.grpEdit.TabIndex = 3;
            this.grpEdit.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(436, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Check Interval (min):";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(123, 73);
            this.txtInterval.Mask = "0";
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 4;
            // 
            // ddProperties
            // 
            this.ddProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddProperties.FormattingEnabled = true;
            this.ddProperties.Location = new System.Drawing.Point(123, 45);
            this.ddProperties.Name = "ddProperties";
            this.ddProperties.Size = new System.Drawing.Size(201, 21);
            this.ddProperties.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Property:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID:";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(123, 16);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 0;
            // 
            // PropertyMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 316);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertyMonitorForm";
            this.Text = "Property Monitor";
            this.Load += new System.EventHandler(this.StatusMonitorForm_Load);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstSettings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.MaskedTextBox txtInterval;
        private System.Windows.Forms.ComboBox ddProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;

    }
}