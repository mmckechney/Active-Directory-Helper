﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActiveDirectoryHelper.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ClearAfterSuccessfulSearch {
            get {
                return ((bool)(this["ClearAfterSuccessfulSearch"]));
            }
            set {
                this["ClearAfterSuccessfulSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Windows.Forms.AutoCompleteStringCollection LastNameList {
            get {
                return ((global::System.Windows.Forms.AutoCompleteStringCollection)(this["LastNameList"]));
            }
            set {
                this["LastNameList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Windows.Forms.AutoCompleteStringCollection IdList {
            get {
                return ((global::System.Windows.Forms.AutoCompleteStringCollection)(this["IdList"]));
            }
            set {
                this["IdList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Windows.Forms.AutoCompleteStringCollection FirstNameList {
            get {
                return ((global::System.Windows.Forms.AutoCompleteStringCollection)(this["FirstNameList"]));
            }
            set {
                this["FirstNameList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>mydomain.com</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection DomainList {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["DomainList"]));
            }
            set {
                this["DomainList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>mydomain.com</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection SelectedDomains {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SelectedDomains"]));
            }
            set {
                this["SelectedDomains"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Michael McKechney")]
        public string ProgramUpdateContact {
            get {
                return ((string)(this["ProgramUpdateContact"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2007-01-01")]
        public global::System.DateTime LastProgramUpdateCheck {
            get {
                return ((global::System.DateTime)(this["LastProgramUpdateCheck"]));
            }
            set {
                this["LastProgramUpdateCheck"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DisplayDisabledAccounts {
            get {
                return ((bool)(this["DisplayDisabledAccounts"]));
            }
            set {
                this["DisplayDisabledAccounts"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://adhelper.sourceforge.net/current_version.txt")]
        public string ProgramVersionCheckURL {
            get {
                return ((string)(this["ProgramVersionCheckURL"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://sourceforge.net/project/showfiles.php?group_id=207498")]
        public string ProgramUpdateURL {
            get {
                return ((string)(this["ProgramUpdateURL"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Michael@McKechney.com")]
        public string ProgramUpdateContactEmail {
            get {
                return ((string)(this["ProgramUpdateContactEmail"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ProxyUserName {
            get {
                return ((string)(this["ProxyUserName"]));
            }
            set {
                this["ProxyUserName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ProxyPassword {
            get {
                return ((string)(this["ProxyPassword"]));
            }
            set {
                this["ProxyPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ProxyUseProxy {
            get {
                return ((bool)(this["ProxyUseProxy"]));
            }
            set {
                this["ProxyUseProxy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string OnLineDirectoryFormat {
            get {
                return ((string)(this["OnLineDirectoryFormat"]));
            }
            set {
                this["OnLineDirectoryFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection MultipleSearchRecent {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MultipleSearchRecent"]));
            }
            set {
                this["MultipleSearchRecent"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CustomManagerSearch {
            get {
                return ((string)(this["CustomManagerSearch"]));
            }
            set {
                this["CustomManagerSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CustomDirectReportSearch {
            get {
                return ((string)(this["CustomDirectReportSearch"]));
            }
            set {
                this["CustomDirectReportSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AdAuthenticationID {
            get {
                return ((string)(this["AdAuthenticationID"]));
            }
            set {
                this["AdAuthenticationID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AdAuthenticationPW {
            get {
                return ((string)(this["AdAuthenticationPW"]));
            }
            set {
                this["AdAuthenticationPW"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AdAuthenticationUseCustom {
            get {
                return ((bool)(this["AdAuthenticationUseCustom"]));
            }
            set {
                this["AdAuthenticationUseCustom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("StandardLdap")]
        public string CustomManagerSearchType {
            get {
                return ((string)(this["CustomManagerSearchType"]));
            }
            set {
                this["CustomManagerSearchType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("StandardLdap")]
        public string CustomDirectReportSearchType {
            get {
                return ((string)(this["CustomDirectReportSearchType"]));
            }
            set {
                this["CustomDirectReportSearchType"] = value;
            }
        }
    }
}
