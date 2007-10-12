using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using ActiveDirectoryHelper.Collections;
using ActiveDirectoryHelper.Tables;
namespace ActiveDirectoryHelper
{
    public partial class PropertyMonitorHelper :Component
    {
        Timer propertyCheckTimer = new Timer();
        public PropertyMonitorHelper()
        {
            Properties.Settings.Default.PropertyMonitorChanged += new EventHandler(Default_PropertyMonitorChanged);
            propertyCheckTimer.Interval = 60000;
            propertyCheckTimer.Tick += new EventHandler(propertyCheckTimer_Tick);
            propertyCheckTimer.Start();
        }

        public void Start()
        {
            propertyCheckTimer.Start();
        }
        void propertyCheckTimer_Tick(object sender, EventArgs e)
        {
            bool foundChange = false;
            DateTime checkDate = DateTime.Now;
            List<PropertyMonitorSetting> setting = (List<PropertyMonitorSetting>)Properties.Settings.Default.PropertyMonitorSettings;
            for (int i = 0; i < setting.Count; i++)
            {
                if (checkDate >= setting[i].LastCheck.AddMinutes(setting[i].IntervalMinutes))
                {
                    try
                    {
                        ADGroupMembersTable user = ADHelper.GetAccount("", "", setting[i].IDToMonitor);
                        if (user.Count == 0)
                            continue;

                        if (user.Columns.Contains(setting[i].PropertyToMonitor))
                        {
                            if (user[0][setting[i].PropertyToMonitor].ToString() != setting[i].CurrentValue)
                            {
                                if (setting[i].LastCheck != DateTime.MinValue)
                                    foundChange = true;

                                setting[i].PreviousCheckTime = setting[i].LastCheck;
                                setting[i].PreviousValue = setting[i].CurrentValue;
                                setting[i].NewValue = user[0][setting[i].PropertyToMonitor].ToString();
                                setting[i].CurrentValue = user[0][setting[i].PropertyToMonitor].ToString();
                            }
                            else
                            {
                                setting[i].NewValue = "";
                            }
                            setting[i].LastCheck = DateTime.Now;
                        }
                    }
                    catch (Exception)
                    {
                        //Catch in case the directory is not available
                    }

                }
            }

            Properties.Settings.Default.PropertyMonitorChanged -= new EventHandler(Default_PropertyMonitorChanged);
            Properties.Settings.Default.PropertyMonitorSettings = setting;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.PropertyMonitorChanged += new EventHandler(Default_PropertyMonitorChanged);
            if (foundChange)
            {
                PropertyChangePopUp pop = new PropertyChangePopUp(setting);
                pop.Show();
            }
        }

        void Default_PropertyMonitorChanged(object sender, EventArgs e)
        {
            propertyCheckTimer_Tick(null, EventArgs.Empty);
        }

      
    }
}
