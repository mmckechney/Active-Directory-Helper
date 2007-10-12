using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class FindMultipleForm : Form
    {
        public FindMultipleForm()
        {
            InitializeComponent();
        }
        private List<String> userList = new List<string>();

        public List<String> UserList
        {
            get { return userList; }
            set { userList = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.userList.AddRange(txtMultiple.Lines);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

     
    }
}