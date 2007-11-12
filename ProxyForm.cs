using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class ProxyForm : Form
    {
        public ProxyForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
                Properties.Settings.Default.ProxyPassword = Encryption.Crypter.Encrypt(txtPassword.Text);

            if(txtUserName.Text.Length > 0)
                Properties.Settings.Default.ProxyUserName = Encryption.Crypter.Encrypt(txtUserName.Text);

            Properties.Settings.Default.ProxyUseProxy = chkUseProxy.Checked;

            Properties.Settings.Default.Save();

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProxyForm_Load(object sender, EventArgs e)
        {

                if(Properties.Settings.Default.ProxyPassword.Length > 0)
                    txtPassword.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyPassword);

                if (Properties.Settings.Default.ProxyUserName.Length > 0)
                    txtUserName.Text = Encryption.Crypter.Decrypt(Properties.Settings.Default.ProxyUserName);

                chkUseProxy.Checked = Properties.Settings.Default.ProxyUseProxy;
        }
    }
}