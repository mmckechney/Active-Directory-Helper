namespace ActiveDirectoryHelper
{
    partial class OnlineDirectoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineDirectoryForm));
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(238, 50);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(500, 21);
            this.txtFormat.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Example: http://myonlinedirectory.com/search.aspx?lname={LastName}&&fname={FirstN" +
                "ame}\r\n";
            // 
            // lstProps
            // 
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
            this.label2.Size = new System.Drawing.Size(308, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "To include a property, double click property name in list \r\nor use the format {Pr" +
                "opertyName} to include value.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(238, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "URL format to use to link to on-line directory:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(585, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(676, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OnlineDirectoryForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(760, 291);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstProps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFormat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OnlineDirectoryForm";
            this.Text = "Online Directory Link Setup";
            this.Load += new System.EventHandler(this.OnlineDirectoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstProps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}