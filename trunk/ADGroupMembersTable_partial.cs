using System;
using System.Data;
using System.Runtime.Serialization;
using System.Drawing;
namespace ActiveDirectoryHelper.Tables
{


    public partial class ADGroupMembersTable 
    {

        internal void AddCustomColumns()
        {
            try
            {
                if (Properties.Settings.Default.CustomPropertyList == null)
                    return;

                for (int i = 0; i < Properties.Settings.Default.CustomPropertyList.Count; i++)
                {
                    CustomPropertyConfig cfg = Properties.Settings.Default.CustomPropertyList[i];
                    if(!this.Columns.Contains(cfg.LdapPropertyName))
                    {
                    DataColumn col = new DataColumn(cfg.LdapPropertyName, typeof(string));
                    this.Columns.Add(col);
                    }
                }
            }
            catch { }
        }
    }
}
