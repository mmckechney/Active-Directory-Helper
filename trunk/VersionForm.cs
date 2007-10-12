using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryHelper.Collections;
namespace ActiveDirectoryHelper
{
    public partial class VersionForm : Form
    {
        VersionData verData = null;
        public VersionForm()
        {
            InitializeComponent();
        }
        public VersionForm(VersionData verData): this()
        {
            this.verData = verData;
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {
            lblContact.Text = verData.Contact;
            lnkContactEMail.Text = verData.ContactEMail;

            lblLatestNum.Text = verData.LatestVersion.ToString();
            lnlYourNum.Text = verData.YourVersion.ToString();
            lnkUpdatePath.Text = string.Format(lnkUpdatePath.Text, verData.UpdateFolder);
            rtbReleaseNotes.Text = verData.ReleaseNotes;

            if (verData.UpdateFileReadError)
                lblVersionStatus.Text = "Unable to open version check file";
            else
                if (verData.YourVersion < verData.LatestVersion)
                    lblVersionStatus.Text = "A Newer version is available for download";
        }

        private void lnkUpdatePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "explorer.exe";
            prc.StartInfo.Arguments = lnkUpdatePath.Text;
            prc.Start();
        }

        private void lnkContactEMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:"+lnkContactEMail.Text);
        }

     

    }
}