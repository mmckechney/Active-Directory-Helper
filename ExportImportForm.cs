using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ActiveDirectoryHelper
{
    public partial class ExportImportForm : Form
    {
        public ExportImportForm()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == dlgFile.ShowDialog())
            {
                txtFileName.Text = dlgFile.FileName;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            //if (txtFileName.Text.Length > 0)
            //{
            //    try
            //    {
                    
            //        XmlSerializer xmls = new XmlSerializer(typeof(ICollection));
            //        XmlTextWriter tw = new XmlTextWriter(txtFileName.Text,new UTF8Encoding());


            //        xmls.Serialize(tw, ActiveDirectoryHelper.Properties.Settings.);

            //    }
            //    catch 
            //    {
                  

            //    }
            //}
        }

    

       
    }
}