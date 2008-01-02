using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveDirectoryHelper
{
    public class CustomPropertyConfig
    {
        public CustomPropertyConfig()
        {
        }
        public CustomPropertyConfig(string ldapPropertyName, string displayName, bool displayColumn, int sortOrder)
        {
            this.ldapPropertyName = ldapPropertyName;
            this.displayName = displayName;
            this.displayColumn = displayColumn;
            this.sortOrder = sortOrder;
        }
        public CustomPropertyConfig(string ldapPropertyName, string displayName, bool displayColumn, int sortOrder, string columnName, int columnWidth) :this(ldapPropertyName,displayName,displayColumn,sortOrder)
        {
            this.columnName = columnName;
            this.columnWidth = columnWidth;
        }
        private string ldapPropertyName = string.Empty;

        public string LdapPropertyName
        {
            get { return ldapPropertyName; }
            set { ldapPropertyName = value; }
        }
        private string displayName = string.Empty;

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        private bool displayColumn = false;

        public bool DisplayColumn
        {
            get { return displayColumn; }
            set { displayColumn = value; }
        }
        private int sortOrder = 100;

        [System.ComponentModel.Browsable(false)]
        public int SortOrder
        {
            get { return sortOrder; }
            set { sortOrder = value; }
        }

        private string columnName = string.Empty;

        [System.ComponentModel.Browsable(false)]
        public string ColumnName
        {
            get
            {
                if (this.columnName.Length == 0)
                {
                    return this.ldapPropertyName + "DataGridViewTextBoxColumn";
                }
                return columnName;
            }
            set { columnName = value; }
        }
        private int columnWidth = 100;
        [System.ComponentModel.Browsable(false)]
        public int ColumnWidth
        {
            get { return columnWidth; }
            set { columnWidth = value; }
        }
    }
}
