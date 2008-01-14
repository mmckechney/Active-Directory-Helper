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

            SearchType search = (SearchType)Enum.Parse(typeof(SearchType), Properties.Settings.Default.CustomManagerSearchType);

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

        protected new void btnSave_Click(object sender, EventArgs e)
        {

            SearchType search = SearchType.StandardLdap;
            if (rbtGeneric.Checked)
                search = SearchType.GenericText;
            else if (rbtCustom.Checked)
                search = SearchType.CustomCode;

            switch(type)
            {
                case CustomQueryType.ManagerSearch:
                    Properties.Settings.Default.CustomManagerSearchType = search.ToString();
                    break;
                case CustomQueryType.DirectReportSearch:
                   Properties.Settings.Default.CustomDirectReportSearchType = search.ToString();
                   break;
            }

            Properties.Settings.Default.Save();
            this.Close();
        }

       
    }
    public enum SearchType
    {
        StandardLdap, 
        GenericText,
        CustomCode
    }
}

