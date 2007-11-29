namespace ActiveDirectoryHelper
{
    partial class VersionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionForm));
            this.rtbReleaseNotes = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblYourVersion = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkUpdatePath = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVersionStatus = new System.Windows.Forms.Label();
            this.lnkContactEMail = new System.Windows.Forms.LinkLabel();
            this.lblLatestNum = new System.Windows.Forms.Label();
            this.lnlYourNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbReleaseNotes
            // 
            this.rtbReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbReleaseNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbReleaseNotes.Location = new System.Drawing.Point(12, 205);
            this.rtbReleaseNotes.Name = "rtbReleaseNotes";
            this.rtbReleaseNotes.Size = new System.Drawing.Size(788, 165);
            this.rtbReleaseNotes.TabIndex = 18;
            this.rtbReleaseNotes.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Release Notes:";
            // 
            // lblLatestVersion
            // 
            this.lblLatestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLatestVersion.AutoSize = true;
            this.lblLatestVersion.Location = new System.Drawing.Point(18, 47);
            this.lblLatestVersion.Name = "lblLatestVersion";
            this.lblLatestVersion.Size = new System.Drawing.Size(77, 13);
            this.lblLatestVersion.TabIndex = 20;
            this.lblLatestVersion.Text = "Latest Version:";
            // 
            // lblYourVersion
            // 
            this.lblYourVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYourVersion.AutoSize = true;
            this.lblYourVersion.Location = new System.Drawing.Point(20, 65);
            this.lblYourVersion.Name = "lblYourVersion";
            this.lblYourVersion.Size = new System.Drawing.Size(70, 13);
            this.lblYourVersion.TabIndex = 19;
            this.lblYourVersion.Text = "Your Version:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(32, 146);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(54, 13);
            this.lblContact.TabIndex = 24;
            this.lblContact.Text = "lblContact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "If you are unable to access this path, please contact:";
            // 
            // lnkUpdatePath
            // 
            this.lnkUpdatePath.AutoSize = true;
            this.lnkUpdatePath.Location = new System.Drawing.Point(32, 103);
            this.lnkUpdatePath.Name = "lnkUpdatePath";
            this.lnkUpdatePath.Size = new System.Drawing.Size(21, 13);
            this.lnkUpdatePath.TabIndex = 22;
            this.lnkUpdatePath.TabStop = true;
            this.lnkUpdatePath.Text = "{0}";
            this.lnkUpdatePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdatePath_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "You can download the latest executable version from here:";
            // 
            // lblVersionStatus
            // 
            this.lblVersionStatus.AutoSize = true;
            this.lblVersionStatus.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionStatus.Location = new System.Drawing.Point(21, 13);
            this.lblVersionStatus.Name = "lblVersionStatus";
            this.lblVersionStatus.Size = new System.Drawing.Size(309, 17);
            this.lblVersionStatus.TabIndex = 26;
            this.lblVersionStatus.Text = "You are already running the latest version.";
            // 
            // lnkContactEMail
            // 
            this.lnkContactEMail.AutoSize = true;
            this.lnkContactEMail.Location = new System.Drawing.Point(32, 159);
            this.lnkContactEMail.Name = "lnkContactEMail";
            this.lnkContactEMail.Size = new System.Drawing.Size(84, 13);
            this.lnkContactEMail.TabIndex = 27;
            this.lnkContactEMail.TabStop = true;
            this.lnkContactEMail.Text = "lnkContactEMail";
            this.lnkContactEMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkContactEMail_LinkClicked);
            // 
            // lblLatestNum
            // 
            this.lblLatestNum.AutoSize = true;
            this.lblLatestNum.Location = new System.Drawing.Point(104, 47);
            this.lblLatestNum.Name = "lblLatestNum";
            this.lblLatestNum.Size = new System.Drawing.Size(40, 13);
            this.lblLatestNum.TabIndex = 28;
            this.lblLatestNum.Text = "0.0.0.0";
            // 
            // lnlYourNum
            // 
            this.lnlYourNum.AutoSize = true;
            this.lnlYourNum.Location = new System.Drawing.Point(104, 65);
            this.lnlYourNum.Name = "lnlYourNum";
            this.lnlYourNum.Size = new System.Drawing.Size(40, 13);
            this.lnlYourNum.TabIndex = 29;
            this.lnlYourNum.Text = "1.1.1.1";
            // 
            // VersionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 382);
            this.Controls.Add(this.lnlYourNum);
            this.Controls.Add(this.lblLatestNum);
            this.Controls.Add(this.lnkContactEMail);
            this.Controls.Add(this.lblVersionStatus);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkUpdatePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLatestVersion);
            this.Controls.Add(this.lblYourVersion);
            this.Controls.Add(this.rtbReleaseNotes);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About:  Active Directory Helper";
            this.Load += new System.EventHandler(this.VersionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReleaseNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblYourVersion;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkUpdatePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVersionStatus;
        private System.Windows.Forms.LinkLabel lnkContactEMail;
        private System.Windows.Forms.Label lblLatestNum;
        private System.Windows.Forms.Label lnlYourNum;
    }
}