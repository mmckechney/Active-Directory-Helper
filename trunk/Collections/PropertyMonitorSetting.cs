using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
namespace ActiveDirectoryHelper.Collections
{
    public class PropertyMonitorSetting
    {

        private string iDToMonitor = string.Empty;
        public string IDToMonitor
        {
            get { return iDToMonitor; }
            set { iDToMonitor = value; }
        }

        private string propertyToMonitor = string.Empty;
        public string PropertyToMonitor
        {
            get { return propertyToMonitor; }
            set { propertyToMonitor = value; }
        }
        
        private int intervalMinutes = 1;
        
        public int IntervalMinutes
        {
            get { return intervalMinutes; }
            set { intervalMinutes = value; }
        }
       
        private string currentValue = string.Empty;
        public string CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        private DateTime lastCheck = DateTime.MinValue;
        public DateTime LastCheck
        {
            get { return lastCheck; }
            set { lastCheck = value; }
        }

        private string newValue = string.Empty;
        [XmlIgnore()]
        public string NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }
        
        private string previousValue = string.Empty;
        [XmlIgnore()]
        public string PreviousValue
        {
            get { return previousValue; }
            set { previousValue = value; }
        }

       
        private DateTime previousCheckTime = DateTime.MinValue;
        [XmlIgnore()]
        public DateTime PreviousCheckTime
        {
            get { return previousCheckTime; }
            set { previousCheckTime = value; }
        }
    }
}
