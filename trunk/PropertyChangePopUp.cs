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
    public partial class PropertyChangePopUp : Form
    {
        List<Collections.PropertyMonitorSetting> list;
        public PropertyChangePopUp()
        {
            InitializeComponent();
        }
        public PropertyChangePopUp(List<Collections.PropertyMonitorSetting> list) :this()
        {
            this.list = list;
        }

        private void PropertyChangePopUp_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                if (this.list[i].NewValue.Length > 0)
                {
                    ListViewItem item = new ListViewItem(new string[]{this.list[i].IDToMonitor,
                    this.list[i].PropertyToMonitor,
                    this.list[i].PreviousCheckTime.ToString(),
                    this.list[i].PreviousValue,
                    this.list[i].NewValue,
                    this.list[i].LastCheck.ToString()});

                    this.lstSettings.Items.Add(item);
                }
            }
        }
    }
}