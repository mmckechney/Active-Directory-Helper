using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class CustomManagerQueryForm : ActiveDirectoryHelper.CustomQueryForm
    {
        public CustomManagerQueryForm()
        {
            base.type = CustomQueryType.ManagerSearch;
            InitializeComponent();

            this.chkComposite.Checked = Properties.Settings.Default.CustomManagerSearchIsComposite;
        }

        protected new void btnSave_Click(object sender, EventArgs e)
        {
            if(type == CustomQueryType.ManagerSearch)
                Properties.Settings.Default.CustomManagerSearchIsComposite = chkComposite.Checked;

            Properties.Settings.Default.Save();
            this.Close();
        }

       
    }
}

