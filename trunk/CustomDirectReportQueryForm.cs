using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryHelper
{
    public partial class CustomDirectReportQueryForm : ActiveDirectoryHelper.CustomManagerQueryForm
    {
        
        public CustomDirectReportQueryForm()
        {
            base.type = CustomQueryType.DirectReportSearch;
            InitializeComponent();
            base.chkComposite.Checked = Properties.Settings.Default.CustomDirectReportSearchIsComposite;
        }

        protected new void btnSave_Click(object sender, EventArgs e)
        {
            if(type == CustomQueryType.DirectReportSearch)
                Properties.Settings.Default.CustomDirectReportSearchIsComposite = chkComposite.Checked;
            
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}

