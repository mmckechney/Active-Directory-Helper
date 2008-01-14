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
        
        public CustomDirectReportQueryForm() :base()
        {
            base.type = CustomQueryType.DirectReportSearch;
            InitializeComponent();

            SearchType search = (SearchType)Enum.Parse(typeof(SearchType), Properties.Settings.Default.CustomDirectReportSearchType);

            switch (search)
            {
                case SearchType.CustomCode:
                    rbtCustom.Checked = true;
                    break;
                case SearchType.GenericText:
                    rbtGeneric.Checked = true;
                    break;
                case SearchType.StandardLdap:
                    rbtStandard.Checked = true;
                    break;
            }
        }

       
    }
}

