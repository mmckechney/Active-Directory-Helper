using System.Collections.Generic;
using ActiveDirectoryHelper.Collections;
namespace ActiveDirectoryHelper.Properties
{
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        static Settings()
        {
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public List<HighlightSetting> OUHighlightSetting
        {
            get
            {
                return ((List<HighlightSetting>)(this["OUHighlightSetting"]));
            }
            set
            {
                this["OUHighlightSetting"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public List<PropertyMonitorSetting> PropertyMonitorSettings
        {
            get
            {
                return ((List<PropertyMonitorSetting>)(this["PropertyMonitorSettings"]));
            }
            set
            {
                this["PropertyMonitorSettings"] = value;

                if (PropertyMonitorChanged != null)
                    PropertyMonitorChanged(null, System.EventArgs.Empty);
            }
        }

        //[global::System.Configuration.UserScopedSettingAttribute()]
        //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //public List<ColumnConfig> CustomizedColumnsList
        //{
        //    get
        //    {
        //        return ((List<ColumnConfig>)(this["CustomizedColumnsList"]));
        //    }
        //    set
        //    {
        //        this["CustomizedColumnsList"] = value;
        //    }
        //}
        public event System.EventHandler PropertyMonitorChanged;
    
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public List<CustomPropertyConfig> CustomPropertyList
        {
            get
            {
                try
                {
                    return ((List<CustomPropertyConfig>)(this["CustomPropertyList"]));
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                this["CustomPropertyList"] = value;
            }
        }
    }
}
