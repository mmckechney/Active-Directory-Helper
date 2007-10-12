using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveDirectoryHelper.Collections
{
    class GroupCompareInstructions
    {
        public GroupCompareInstructions(List<string> group1List, string group1Comparison, List<string> group2List, string group2Comparison, string groupMixtype)
        {
            this.group1List = group1List;
            this.group1Comparison = group1Comparison;
            this.group2List = group2List;
            this.group2Comparison = group2Comparison;
            this.groupMixtype = groupMixtype;
        }
        List<string> group1List;

        public List<string> Group1List
        {
            get { return group1List; }
            set { group1List = value; }
        }
        string group1Comparison;

        public string Group1Comparison
        {
            get { return group1Comparison; }
            set { group1Comparison = value; }
        }

        List<string> group2List;

        public List<string> Group2List
        {
            get { return group2List; }
            set { group2List = value; }
        }
        string group2Comparison;

        public string Group2Comparison
        {
            get { return group2Comparison; }
            set { group2Comparison = value; }
        }

        string groupMixtype;

        public string GroupMixtype
        {
            get { return groupMixtype; }
            set { groupMixtype = value; }
        }
    }
}
