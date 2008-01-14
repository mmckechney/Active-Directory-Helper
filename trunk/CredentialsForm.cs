using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class CredentialsForm : Form
    {
        private CredentialType type;
        public CredentialsForm(CredentialType type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.type == CredentialType.Proxy)
            {
                if (txtPassword.Text.Length > 0)
                    Properties.Settings.Default.ProxyPassword = Encryption.Crypter.Encrypt(txtPassword.Text);
                else
                    Properties.Settings.Default.ProxyPassword = string.Empty;

                if (txtUserName.Text.Length > 0)
                    Properties.Settings.Default.ProxyUserName = Encryption.Crypter.Encrypt(txtUserName.Text);
                else
                    Properties.Settings.Default.ProxyUserName = string.Empty;

                Properties.Settings.Default.ProxyUseProxy = chkUse.Checked;
            }
            else if (this.type == CredentialType.ADBinding)
            {
                if (txtPassword.Text.Length > 0)
                    Properties.Settings.Default.AdAuthenticationPW = Encryption.Crypter.Encrypt(txtPassword.Text);
                else
                    Properties.Settings.Default.AdAuthenticationPW = string.Empty;

                if (txtUserName.Text.Length > 0)
                    Properties.Settings.Default.AdAuthenticationID = Encryption.Crypter.Encrypt(txtUserName.Text);
                else
                    Properties.Settings.Default.AdAuthenticationID = string.Empty;

                Properties.Settings.Default.AdAuthenticationUseCustom = chkUse.Checked;
            }

            Properties.Settings.Default.Save();

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CredentialsForm_Load(object sender, EventArgs e)
        {
            if(this.type == CredentialType.Proxy)
            {
                if(Properties.Settings.Default.ProxyPassword.Length > 0)
                    txtPassword.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyPassword);

                if (Properties.Settings.Default.ProxyUserName.Length > 0)
                    txtUserName.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyUserName);

                chkUse.Checked = Properties.Settings.Default.ProxyUseProxy;
            }
            else if(this.type == CredentialType.ADBinding)
            {
                this.Text = "Active Directory Binding Credentials";
                this.chkUse.Text = "Use supplied credentials (vs. Windows login credentials)";
                if(Properties.Settings.Default.AdAuthenticationPW.Length > 0)
                    txtPassword.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.AdAuthenticationPW);

                if (Properties.Settings.Default.AdAuthenticationID.Length > 0)
                    txtUserName.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.AdAuthenticationID);

                chkUse.Checked = Properties.Settings.Default.AdAuthenticationUseCustom;
            }
        }
    }
    public enum CredentialType
    {
        Proxy,
        ADBinding
    }
}