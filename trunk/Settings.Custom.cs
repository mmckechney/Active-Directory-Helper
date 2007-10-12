using System.Collections.Generic;
using ActiveDirectoryHelper.Collections;
namespace ActiveDirectoryHelper.Properties
{
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
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
        public event System.EventHandler PropertyMonitorChanged;
    }
    
}
