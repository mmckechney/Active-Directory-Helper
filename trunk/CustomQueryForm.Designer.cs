namespace ActiveDirectoryHelper
{
    partial class CustomQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomQueryForm));
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.lstProps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFormat
            // 
            this.txtFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormat.Location = new System.Drawing.Point(238, 50);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(564, 21);
            this.txtFormat.TabIndex = 0;
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(238, 27);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(512, 15);
            this.lblExample.TabIndex = 1;
            this.lblExample.Text = "Example: http://myonlinedirectory.com/search.aspx?lname={LastName}&&fname={FirstN" +
                "ame}\r\n";
            // 
            // lstProps
            // 
            this.lstProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstProps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProps.FullRowSelect = true;
            this.lstProps.GridLines = true;
            this.lstProps.Location = new System.Drawing.Point(14, 14);
            this.lstProps.Name = "lstProps";
            this.lstProps.Size = new System.Drawing.Size(209, 262);
            this.lstProps.TabIndex = 2;
            this.lstProps.UseCompatibleStateImageBehavior = false;
            this.lstProps.View = System.Windows.Forms.View.Details;
            this.lstProps.DoubleClick += new System.EventHandler(this.lstProps_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property Name";
            this.columnHeader1.Width = 187;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "To include a property\'s value at runtime, double click property name in list \r\nor" +
                " use the format {PropertyName} to include value.";
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(238, 14);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(263, 13);
            this.lblMain.TabIndex = 4;
            this.lblMain.Text = "URL format to use to link to on-line directory:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(643, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(727, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CustomQueryForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(811, 291);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstProps);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.txtFormat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomQueryForm";
            this.Text = "Online Directory Link Setup";
            this.Load += new System.EventHandler(this.OnlineDirectoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.TextBox txtFormat;
        public System.Windows.Forms.Label lblExample;
        public System.Windows.Forms.ListView lstProps;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblMain;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnCancel;
    }
}