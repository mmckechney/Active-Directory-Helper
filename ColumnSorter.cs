using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
namespace ActiveDirectoryHelper
{
    public class ColumnSorter : IComparer
    {
        private int currentColumn = 0;
        private int lastColumn = -1;
        private Type expectedType = null;
        private int clickCount = 0;
        public int CurrentColumn
        {
            set
            {
                if (currentColumn != lastColumn)
                {
                    expectedType = null;
                    sort = SortOrder.Ascending;
                }
                else if (sort == SortOrder.Ascending)
                    sort = SortOrder.Descending;
                else
                    sort = SortOrder.Ascending;


                lastColumn = currentColumn;
                currentColumn = value;
                clickCount++;

            }

        }
        private SortOrder sort = SortOrder.Ascending;

        public SortOrder Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        public int Compare(object x, object y)
        {
            string strX;
            string strY;
            int returnVal = -1;
            if (this.clickCount % 2 == 0)
            {
                strX = ((ListViewItem)x).SubItems[currentColumn].ForeColor.Name;
                strY = ((ListViewItem)y).SubItems[currentColumn].ForeColor.Name;

            }
            else
            {
                strX = ((ListViewItem)x).SubItems[currentColumn].Text.ToString();
                strY = ((ListViewItem)y).SubItems[currentColumn].Text.ToString();

             }

  
            returnVal = string.Compare(strX, strY);

            //if (sort == SortOrder.Descending)
            //    returnVal *= -1;

            return returnVal;

        }

        //private int CompareDates(string x, string y)
        //{
        //    try
        //    {
        //        // Parse the two objects passed as a parameter as a DateTime.
        //        System.DateTime firstDate = DateTime.Parse(x);
        //        System.DateTime secondDate = DateTime.Parse(y);
        //        // Compare the two dates.
        //        return DateTime.Compare(firstDate, secondDate);
        //    }
        //    catch
        //    {
        //        return String.Compare(x, y);
        //    }

        //}
        //private int CompareNumbers(string x, string y)
        //{
        //    try
        //    {
        //        Decimal first = Decimal.Parse(x);
        //        Decimal second = Decimal.Parse(y);
        //        if (first < second)
        //            return -1;
        //        else if (first == second)
        //            return 0;
        //        else if (first > second)
        //            return 1;
        //    }
        //    catch
        //    {
        //        return String.Compare(x, y);
        //    }
        //    return -1;
        //}

        public ColumnSorter()
        {

        }

    }

}
