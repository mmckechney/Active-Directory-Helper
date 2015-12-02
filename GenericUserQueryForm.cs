using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class GenericUserQueryForm : Form
    {
        const string disabledAccount = "(userAccountControl:1.2.840.113556.1.4.803:=2)";
        public string Query = string.Empty;
        public GenericUserQueryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Query = richTextBox1.Text;
            if (chkDisplayDisabled.Checked)
                this.Query += disabledAccount;

            this.Query += "(whenChanged>=" + dateTimePicker1.Value.ToString("yyyyMMdd000000.0Z") +")";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
