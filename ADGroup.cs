using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveDirectoryHelper
{
    public class ADGroup : IComparable  
    {
        string groupName = string.Empty;
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        
        string distinguishedName = string.Empty;
        public string DistinguishedName
        {
            get { return distinguishedName; }
            set { distinguishedName = value; }
        }

        bool isInherited = false;

        public bool IsInherited
        {
            get { return isInherited; }
            set { isInherited = value; }
        }

        
        public ADGroup()
        {
        }
        public ADGroup(string groupName, string distinguishedName)
        {
            this.distinguishedName = distinguishedName;
            this.groupName = groupName;
        }
        public ADGroup(string groupName, string distinguishedName, bool isInherited) : this(groupName,distinguishedName)
        {
            this.isInherited = isInherited;
        }

        public int CompareTo(object x)
        {
            if (x is ADGroup)
            {
                return this.groupName.CompareTo(((ADGroup)x).groupName);
            }
            else return 0;
        }
       
    }
 

}
