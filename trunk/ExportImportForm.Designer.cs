namespace ActiveDirectoryHelper
{
    partial class ExportImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportImportForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkOnLine = new System.Windows.Forms.CheckBox();
            this.chkDirectReport = new System.Windows.Forms.CheckBox();
            this.chkManager = new System.Windows.Forms.CheckBox();
            this.chkOU = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.dlgFile = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkOnLine);
            this.groupBox1.Controls.Add(this.chkDirectReport);
            this.groupBox1.Controls.Add(this.chkManager);
            this.groupBox1.Controls.Add(this.chkOU);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings to Export";
            // 
            // chkOnLine
            // 
            this.chkOnLine.AutoSize = true;
            this.chkOnLine.Location = new System.Drawing.Point(18, 88);
            this.chkOnLine.Name = "chkOnLine";
            this.chkOnLine.Size = new System.Drawing.Size(166, 17);
            this.chkOnLine.TabIndex = 3;
            this.chkOnLine.Text = "On-Line Directory Link Format";
            this.chkOnLine.UseVisualStyleBackColor = true;
            // 
            // chkDirectReport
            // 
            this.chkDirectReport.AutoSize = true;
            this.chkDirectReport.Location = new System.Drawing.Point(18, 65);
            this.chkDirectReport.Name = "chkDirectReport";
            this.chkDirectReport.Size = new System.Drawing.Size(174, 17);
            this.chkDirectReport.TabIndex = 2;
            this.chkDirectReport.Text = "Direct Report Hierarchy Search";
            this.chkDirectReport.UseVisualStyleBackColor = true;
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Location = new System.Drawing.Point(18, 42);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(153, 17);
            this.chkManager.TabIndex = 1;
            this.chkManager.Text = "Manager Hierarchy Search";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // chkOU
            // 
            this.chkOU.AutoSize = true;
            this.chkOU.Location = new System.Drawing.Point(18, 19);
            this.chkOU.Name = "chkOU";
            this.chkOU.Size = new System.Drawing.Size(173, 17);
            this.chkOU.TabIndex = 0;
            this.chkOU.Text = "Organizational Unit Highlighting";
            this.chkOU.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(12, 185);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(508, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Path:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(526, 185);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(28, 21);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(465, 215);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(89, 21);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Export";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // dlgFile
            // 
            this.dlgFile.DefaultExt = "exp";
            this.dlgFile.Filter = "AD Export File|*.exp|Xml File|*.xml|All Files|*.*";
            // 
            // ExportImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 248);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportImportForm";
            this.Text = "Import / Export Settings Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkManager;
        private System.Windows.Forms.CheckBox chkDirectReport;
        private System.Windows.Forms.CheckBox chkOnLine;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.SaveFileDialog dlgFile;
    }
}