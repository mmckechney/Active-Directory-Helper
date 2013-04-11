using System;
using ActiveDirectoryHelper.Tables;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;

namespace ActiveDirectoryHelper
{
    /// <summary>
    /// Summary description for ADHelper.
    /// </summary>
    public class ADHelper
    {
        public static List<string> AvailableLdapProps = new List<string>();
        private static List<string> globalCatalogURL = new List<string>();

        public static List<string> GlobalCatalogURL
        {
            get { return globalCatalogURL; }
            set { globalCatalogURL = value; }
        }

        private static Hashtable _countryNames;

        internal static Hashtable CountryNames
        {
            get
            {
                if (_countryNames == null)
                {

                }
                return _countryNames;
            }
        }

        static ADHelper()
        {
            Hashtable ht = new Hashtable();
            ht.Add("AD", "ANDORRA");
            ht.Add("AE", "UNITED ARAB EMIRATES");
            ht.Add("AF", "AFGHANISTAN");
            ht.Add("AG", "ANTIGUA AND BARBUDA");
            ht.Add("AI", "ANGUILLA");
            ht.Add("AL", "ALBANIA");
            ht.Add("AM", "ARMENIA");
            ht.Add("AN", "NETHERLANDS ANTILLES");
            ht.Add("AO", "ANGOLA");
            ht.Add("AQ", "ANTARCTICA");
            ht.Add("AR", "ARGENTINA");
            ht.Add("AS", "AMERICAN SAMOA");
            ht.Add("AT", "AUSTRIA");
            ht.Add("AU", "AUSTRALIA");
            ht.Add("AW", "ARUBA");
            ht.Add("AX", "ÅLAND ISLANDS");
            ht.Add("AZ", "AZERBAIJAN");
            ht.Add("BA", "BOSNIA AND HERZEGOVINA");
            ht.Add("BB", "BARBADOS");
            ht.Add("BD", "BANGLADESH");
            ht.Add("BE", "BELGIUM");
            ht.Add("BF", "BURKINA FASO");
            ht.Add("BG", "BULGARIA");
            ht.Add("BH", "BAHRAIN");
            ht.Add("BI", "BURUNDI");
            ht.Add("BJ", "BENIN");
            ht.Add("BM", "BERMUDA");
            ht.Add("BN", "BRUNEI DARUSSALAM");
            ht.Add("BO", "BOLIVIA");
            ht.Add("BR", "BRAZIL");
            ht.Add("BS", "BAHAMAS");
            ht.Add("BT", "BHUTAN");
            ht.Add("BV", "BOUVET ISLAND");
            ht.Add("BW", "BOTSWANA");
            ht.Add("BY", "BELARUS");
            ht.Add("BZ", "BELIZE");
            ht.Add("CA", "CANADA");
            ht.Add("CC", "COCOS (KEELING) ISLANDS");
            ht.Add("CD", "CONGO  THE DEMOCRATIC REPUBLIC OF THE");
            ht.Add("CF", "CENTRAL AFRICAN REPUBLIC");
            ht.Add("CG", "CONGO");
            ht.Add("CH", "SWITZERLAND");
            ht.Add("CI", "COTE D'IVOIRE");
            ht.Add("CK", "COOK ISLANDS");
            ht.Add("CL", "CHILE");
            ht.Add("CM", "CAMEROON");
            ht.Add("CN", "CHINA");
            ht.Add("CO", "COLOMBIA");
            ht.Add("CR", "COSTA RICA");
            ht.Add("CS", "SERBIA AND MONTENEGRO");
            ht.Add("CU", "CUBA");
            ht.Add("CV", "CAPE VERDE");
            ht.Add("CX", "CHRISTMAS ISLAND");
            ht.Add("CY", "CYPRUS");
            ht.Add("CZ", "CZECH REPUBLIC");
            ht.Add("DE", "GERMANY");
            ht.Add("DJ", "DJIBOUTI");
            ht.Add("DK", "DENMARK");
            ht.Add("DM", "DOMINICA");
            ht.Add("DO", "DOMINICAN REPUBLIC");
            ht.Add("DZ", "ALGERIA");
            ht.Add("EC", "ECUADOR");
            ht.Add("EE", "ESTONIA");
            ht.Add("EG", "EGYPT");
            ht.Add("EH", "WESTERN SAHARA");
            ht.Add("ER", "ERITREA");
            ht.Add("ES", "SPAIN");
            ht.Add("ET", "ETHIOPIA");
            ht.Add("FI", "FINLAND");
            ht.Add("FJ", "FIJI");
            ht.Add("FK", "FALKLAND ISLANDS (MALVINAS)");
            ht.Add("FM", "MICRONESIA  FEDERATED STATES OF");
            ht.Add("FO", "FAROE ISLANDS");
            ht.Add("FR", "FRANCE");
            ht.Add("GA", "GABON");
            ht.Add("GB", "UNITED KINGDOM");
            ht.Add("GD", "GRENADA");
            ht.Add("GE", "GEORGIA");
            ht.Add("GF", "FRENCH GUIANA");
            ht.Add("GH", "GHANA");
            ht.Add("GI", "GIBRALTAR");
            ht.Add("GL", "GREENLAND");
            ht.Add("GM", "GAMBIA");
            ht.Add("GN", "GUINEA");
            ht.Add("GP", "GUADELOUPE");
            ht.Add("GQ", "EQUATORIAL GUINEA");
            ht.Add("GR", "GREECE");
            ht.Add("GS", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS");
            ht.Add("GT", "GUATEMALA");
            ht.Add("GU", "GUAM");
            ht.Add("GW", "GUINEA-BISSAU");
            ht.Add("GY", "GUYANA");
            ht.Add("HK", "HONG KONG");
            ht.Add("HM", "HEARD ISLAND AND MCDONALD ISLANDS");
            ht.Add("HN", "HONDURAS");
            ht.Add("HR", "CROATIA");
            ht.Add("HT", "HAITI");
            ht.Add("HU", "HUNGARY");
            ht.Add("ID", "INDONESIA");
            ht.Add("IE", "IRELAND");
            ht.Add("IL", "ISRAEL");
            ht.Add("IN", "INDIA");
            ht.Add("IO", "BRITISH INDIAN OCEAN TERRITORY");
            ht.Add("IQ", "IRAQ");
            ht.Add("IR", "IRAN  ISLAMIC REPUBLIC OF");
            ht.Add("IS", "ICELAND");
            ht.Add("IT", "ITALY");
            ht.Add("JM", "JAMAICA");
            ht.Add("JO", "JORDAN");
            ht.Add("JP", "JAPAN");
            ht.Add("KE", "KENYA");
            ht.Add("KG", "KYRGYZSTAN");
            ht.Add("KH", "CAMBODIA");
            ht.Add("KI", "KIRIBATI");
            ht.Add("KM", "COMOROS");
            ht.Add("KN", "SAINT KITTS AND NEVIS");
            ht.Add("KP", "KOREA  DEMOCRATIC PEOPLE'S REPUBLIC OF");
            ht.Add("KR", "KOREA  REPUBLIC OF");
            ht.Add("KW", "KUWAIT");
            ht.Add("KY", "CAYMAN ISLANDS");
            ht.Add("KZ", "KAZAKHSTAN");
            ht.Add("LA", "LAO PEOPLE'S DEMOCRATIC REPUBLIC");
            ht.Add("LB", "LEBANON");
            ht.Add("LC", "SAINT LUCIA");
            ht.Add("LI", "LIECHTENSTEIN");
            ht.Add("LK", "SRI LANKA");
            ht.Add("LR", "LIBERIA");
            ht.Add("LS", "LESOTHO");
            ht.Add("LT", "LITHUANIA");
            ht.Add("LU", "LUXEMBOURG");
            ht.Add("LV", "LATVIA");
            ht.Add("LY", "LIBYAN ARAB JAMAHIRIYA");
            ht.Add("MA", "MOROCCO");
            ht.Add("MC", "MONACO");
            ht.Add("MD", "MOLDOVA  REPUBLIC OF");
            ht.Add("MG", "MADAGASCAR");
            ht.Add("MH", "MARSHALL ISLANDS");
            ht.Add("MK", "MACEDONIA  THE FORMER YUGOSLAV REPUBLIC OF");
            ht.Add("ML", "MALI");
            ht.Add("MM", "MYANMAR");
            ht.Add("MN", "MONGOLIA");
            ht.Add("MO", "MACAO");
            ht.Add("MP", "NORTHERN MARIANA ISLANDS");
            ht.Add("MQ", "MARTINIQUE");
            ht.Add("MR", "MAURITANIA");
            ht.Add("MS", "MONTSERRAT");
            ht.Add("MT", "MALTA");
            ht.Add("MU", "MAURITIUS");
            ht.Add("MV", "MALDIVES");
            ht.Add("MW", "MALAWI");
            ht.Add("MX", "MEXICO");
            ht.Add("MY", "MALAYSIA");
            ht.Add("MZ", "MOZAMBIQUE");
            ht.Add("NA", "NAMIBIA");
            ht.Add("NC", "NEW CALEDONIA");
            ht.Add("NE", "NIGER");
            ht.Add("NF", "NORFOLK ISLAND");
            ht.Add("NG", "NIGERIA");
            ht.Add("NI", "NICARAGUA");
            ht.Add("NL", "NETHERLANDS");
            ht.Add("NO", "NORWAY");
            ht.Add("NP", "NEPAL");
            ht.Add("NR", "NAURU");
            ht.Add("NU", "NIUE");
            ht.Add("NZ", "NEW ZEALAND");
            ht.Add("OM", "OMAN");
            ht.Add("PA", "PANAMA");
            ht.Add("PE", "PERU");
            ht.Add("PF", "FRENCH POLYNESIA");
            ht.Add("PG", "PAPUA NEW GUINEA");
            ht.Add("PH", "PHILIPPINES");
            ht.Add("PK", "PAKISTAN");
            ht.Add("PL", "POLAND");
            ht.Add("PM", "SAINT PIERRE AND MIQUELON");
            ht.Add("PN", "PITCAIRN");
            ht.Add("PR", "PUERTO RICO");
            ht.Add("PS", "PALESTINIAN TERRITORY  OCCUPIED");
            ht.Add("PT", "PORTUGAL");
            ht.Add("PW", "PALAU");
            ht.Add("PY", "PARAGUAY");
            ht.Add("QA", "QATAR");
            ht.Add("RE", "REUNION");
            ht.Add("RO", "ROMANIA");
            ht.Add("RU", "RUSSIAN FEDERATION");
            ht.Add("RW", "RWANDA");
            ht.Add("SA", "SAUDI ARABIA");
            ht.Add("SB", "SOLOMON ISLANDS");
            ht.Add("SC", "SEYCHELLES");
            ht.Add("SD", "SUDAN");
            ht.Add("SE", "SWEDEN");
            ht.Add("SG", "SINGAPORE");
            ht.Add("SH", "SAINT HELENA");
            ht.Add("SI", "SLOVENIA");
            ht.Add("SJ", "SVALBARD AND JAN MAYEN");
            ht.Add("SK", "SLOVAKIA");
            ht.Add("SL", "SIERRA LEONE");
            ht.Add("SM", "SAN MARINO");
            ht.Add("SN", "SENEGAL");
            ht.Add("SO", "SOMALIA");
            ht.Add("SR", "SURINAME");
            ht.Add("ST", "SAO TOME AND PRINCIPE");
            ht.Add("SV", "EL SALVADOR");
            ht.Add("SY", "SYRIAN ARAB REPUBLIC");
            ht.Add("SZ", "SWAZILAND");
            ht.Add("TC", "TURKS AND CAICOS ISLANDS");
            ht.Add("TD", "CHAD");
            ht.Add("TF", "FRENCH SOUTHERN TERRITORIES");
            ht.Add("TG", "TOGO");
            ht.Add("TH", "THAILAND");
            ht.Add("TJ", "TAJIKISTAN");
            ht.Add("TK", "TOKELAU");
            ht.Add("TL", "TIMOR-LESTE");
            ht.Add("TM", "TURKMENISTAN");
            ht.Add("TN", "TUNISIA");
            ht.Add("TO", "TONGA");
            ht.Add("TR", "TURKEY");
            ht.Add("TT", "TRINIDAD AND TOBAGO");
            ht.Add("TV", "TUVALU");
            ht.Add("TW", "TAIWAN  PROVINCE OF CHINA");
            ht.Add("TZ", "TANZANIA  UNITED REPUBLIC OF");
            ht.Add("UA", "UKRAINE");
            ht.Add("UG", "UGANDA");
            ht.Add("UM", "UNITED STATES MINOR OUTLYING ISLANDS");
            ht.Add("US", "UNITED STATES");
            ht.Add("UY", "URUGUAY");
            ht.Add("UZ", "UZBEKISTAN");
            ht.Add("VA", "HOLY SEE (VATICAN CITY STATE)");
            ht.Add("VC", "SAINT VINCENT AND THE GRENADINES");
            ht.Add("VE", "VENEZUELA");
            ht.Add("VG", "VIRGIN ISLANDS  BRITISH");
            ht.Add("VI", "VIRGIN ISLANDS  U.S.");
            ht.Add("VN", "VIET NAM");
            ht.Add("VU", "VANUATU");
            ht.Add("WF", "WALLIS AND FUTUNA");
            ht.Add("WS", "SAMOA");
            ht.Add("YE", "YEMEN");
            ht.Add("YT", "MAYOTTE");
            ht.Add("ZA", "SOUTH AFRICA");
            ht.Add("ZM", "ZAMBIA");
            ht.Add("ZW", "ZIMBABWE");
            ht.Add("ZZ", "N/A");

            _countryNames = ht;

        }

        public ADHelper()
        {

        }

        internal GroupLoadedEventArgs GetGroupsList()
        {
            SortedList fullGroupList = new SortedList();
            for (int idx = 0; idx < globalCatalogURL.Count; idx++)
            {
                DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[idx]);

                DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                searcher1.PageSize = 1000;
                searcher1.SizeLimit = 100000;
                searcher1.Filter = "(objectClass=group)";
                searcher1.PropertiesToLoad.Add("name");
                searcher1.PropertiesToLoad.Add("distinguishedname");
                SearchResultCollection collAllGroups = null;
                try
                {
                    collAllGroups = searcher1.FindAll();
                }
                catch
                {
                    continue;
                }
                string[] allGroups = new string[collAllGroups.Count];
                for (int i = 0; i < collAllGroups.Count; i++)
                {
                    if (collAllGroups[i].Properties["name"] != null && collAllGroups[i].Properties["name"][0] != null)
                    {
                        if (fullGroupList.ContainsKey(collAllGroups[i].Properties["name"][0]) == false)
                            fullGroupList.Add(collAllGroups[i].Properties["name"][0],
                                              collAllGroups[i].Properties["distinguishedname"][0]);

                    }
                }
            }

            return new GroupLoadedEventArgs(fullGroupList);
        }

        private static ADGroupMembersTableRow GetUsersManagers(string distinguishedName)
        {
            ADGroupMembersTableRow firstUser = GetAccountByDN(distinguishedName);
            return GetUsersManagers(firstUser);
        }

        internal static ADGroupMembersTableRow GetUsersManagers(ADGroupMembersTableRow memberRow)
        {
            return GetUsersManagers(memberRow, "");
        }

        /// <summary>
        /// Retrieves a user's manager by building a nested hierarchy of ADGroupMembersTableRows via the ManagerRow property
        /// </summary>
        /// <param name="memberRow">Group Members Table row for the current user to be searched</param>
        /// <param name="lastQuery">The LDAP query used in the last recursive call -- used to halt endless loops, especially when the custom C# code is used.</param>
        /// <returns></returns>
        internal static ADGroupMembersTableRow GetUsersManagers(ADGroupMembersTableRow memberRow, string lastQuery)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.CustomManagerSearch))
            {
                bool searchByquery = false;
                SearchType search =
                    (SearchType) Enum.Parse(typeof (SearchType), Properties.Settings.Default.CustomManagerSearchType);
                string query = string.Empty;
                ;
                switch (search)
                {
                    case SearchType.CustomCode:
                        query = ADHelper.PerformTokenReplacement(Properties.Settings.Default.CustomManagerSearch,
                                                                 memberRow);
                        if (query.Length > 0)
                            query = Eval(query);
                        else
                            return memberRow;

                        searchByquery = true;
                        break;
                    case SearchType.StandardLdap:
                        query = ADHelper.PerformTokenReplacement(Properties.Settings.Default.CustomManagerSearch,
                                                                 memberRow);
                        searchByquery = true;
                        break;
                    case SearchType.GenericText:
                        query = ADHelper.PerformTokenReplacement(Properties.Settings.Default.CustomManagerSearch,
                                                                 memberRow);
                        searchByquery = false;
                        break;

                }
                if (query == lastQuery)
                    return memberRow;

                ADGroupMembersTable tmp;
                if (!searchByquery)
                    tmp = GetAccountFromString(query);
                else
                    tmp = GetAccountByQuery(query);

                if (tmp != null && tmp.Rows.Count > 0)
                {
                    memberRow.ManagerRow = GetUsersManagers(tmp[0], query);
                }

                return memberRow;
            }
            else
            {
                if (memberRow.ManagerDN.Length == 0)
                    return memberRow;

                memberRow.ManagerRow = GetUsersManagers(GetAccountByDN(memberRow.ManagerDN));
                return memberRow;
            }
        }

        internal static ADGroupMembersTable GetDirectReports(ADGroupMembersTableRow row)
        {
            ADGroupMembersTable memTable = new ADGroupMembersTable();
            try
            {
                StringBuilder sb = new StringBuilder("(&(objectCategory=person)(objectClass=user)");
                if (string.IsNullOrEmpty(Properties.Settings.Default.CustomDirectReportSearch))
                {
                    sb.Append("(manager=" + row.DistinguishedName + ")");
                }
                else
                {
                    SearchType search =
                        (SearchType)
                        Enum.Parse(typeof (SearchType), Properties.Settings.Default.CustomDirectReportSearchType);
                    switch (search)
                    {
                        case SearchType.GenericText:
                            return
                                GetAccountFromString(
                                    PerformTokenReplacement(Properties.Settings.Default.CustomDirectReportSearch, row));
                        case SearchType.CustomCode:
                            string query = PerformTokenReplacement(
                                Properties.Settings.Default.CustomDirectReportSearch, row);
                            query = Eval(query);
                            sb.Append(ADHelper.PerformTokenReplacement(query, row));
                            break;
                        case SearchType.StandardLdap:
                            sb.Append("(" +
                                      PerformTokenReplacement(Properties.Settings.Default.CustomDirectReportSearch, row) +
                                      ")");
                            break;
                    }
                }
                sb.Append(")");
                for (int j = 0; j < globalCatalogURL.Count; j++)
                {
                    DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);

                    DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                    searcher1.Filter = sb.ToString();
                    AddSearchProperties(ref searcher1);
                    SearchResultCollection collection2 = null;
                    try
                    {
                        collection2 = searcher1.FindAll();
                    }
                    catch
                    {
                        continue;
                    }
                    int num1 = collection2.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        if (collection2[num2] != null)
                        {
                            SearchResult result = collection2[num2];
                            AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);
                        }
                    }
                }

            }
            catch (ArgumentException)
            {
                if (ADHelper.InvalidLdapQuery != null)
                    ADHelper.InvalidLdapQuery(null, EventArgs.Empty);
            }

            string[] colNames = new string[memTable.Columns.Count];
            for (int i = 0; i < memTable.Columns.Count; i++)
            {
                colNames[i] = memTable.Columns[i].ColumnName;
            }
            DataTable distinct = memTable.SelectDistinct(colNames);
            ADGroupMembersTable tbl = new ADGroupMembersTable(distinct);
            return ConvertToCountryName(tbl);
        }

        internal static ADGroupMembersTable GetAllReports(ADGroupMembersTableRow row)
        {
            ADGroupMembersTable masterTable = new ADGroupMembersTable();

            ADGroupMembersTable firstLine = GetDirectReports(row);

            if (firstLine.Rows.Count > 0)
            {
                DataRow[] tmp = new DataRow[firstLine.Rows.Count];
                firstLine.Rows.CopyTo(tmp, 0);
                masterTable.ImportRows(tmp);
            }

            Parallel.ForEach<DataRow>(firstLine.AsEnumerable(), dRow =>
                {
                    ADGroupMembersTable sub = GetAllReports((ADGroupMembersTableRow)dRow);
                    if (sub.Rows.Count > 0)
                    {

                        DataRow[] tmpSub = new DataRow[sub.Rows.Count];
                        sub.Rows.CopyTo(tmpSub, 0);
                        masterTable.ImportRows(tmpSub);
                    }
                });
            //foreach (ADGroupMembersTableRow dRow in firstLine.Rows)
            //{
            //    ADGroupMembersTable sub = GetAllReports(dRow);
            //    if (sub.Rows.Count == 0) 
            //        continue;
                
            //    DataRow[] tmpSub = new DataRow[sub.Rows.Count];
            //    sub.Rows.CopyTo(tmpSub,0);
            //    masterTable.ImportRows(tmpSub);
            //}

            return masterTable;
        }

        internal static System.Collections.Generic.List<ADGroup> GetGroups(string distinguishedName,string sid, string searchDomain)
		{
            System.Collections.Generic.List<ADGroup> grps = new System.Collections.Generic.List<ADGroup>();
			//Make a Connection with the Global Catalog Server
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                System.DirectoryServices.DirectoryEntry Root = GetDirectoryEntry(globalCatalogURL[j]); 
                //Create a directory searcher based on the root catalog server
                using (System.DirectoryServices.DirectorySearcher GSearch = new System.DirectoryServices.DirectorySearcher(Root))
                {

                    //Create a filter that finds the user
                    GSearch.Filter = "(&(objectClass=user)(distinguishedname=" + distinguishedName + "))";//(&(objectclass=user)(objectsid=" + sid + ")) (&(objectclass=foreignSecurityPrincipal)(objectsid=" + sid + "))) ";
                    GSearch.PropertiesToLoad.Add("distinguishedname"); 
    				System.DirectoryServices.SearchResultCollection ResultGroup = GSearch.FindAll();
                    if (ResultGroup.Count == 0) //if no results by DN, try the SID
                    {
                        GSearch.Filter = "(|(&(objectclass=user)(objectsid=" + sid + ")) (&(objectclass=foreignSecurityPrincipal)(objectsid=" + sid + "))) ";
                        GSearch.PropertiesToLoad.Add("distinguishedname");
                        ResultGroup = GSearch.FindAll();
                    }
				    //Check to make sure a group is actually returned
                    if (ResultGroup.Count != 0)
                    {
                        for (int k = 0; k < ResultGroup[0].Properties["objectclass"].Count; k++)
                            System.Diagnostics.Debug.WriteLine((string)ResultGroup[0].Properties["objectclass"][k]);

                        //Get the Distinguished name of the group
                        string memberDN = (string)ResultGroup[0].Properties["distinguishedname"][0];

                        //Now Create a filter that gets all of the users for the group excluding the disabled accounts
                        GSearch.Filter = "(&(objectClass=group)(Member=" + memberDN + "))";

                        //Only load the properties that we really need
                        GSearch.PropertiesToLoad.Add("name");
                        GSearch.PropertiesToLoad.Add("distinguishedname");

                        //Dispose of the Current Result Group 
                        ResultGroup.Dispose();
                        //Grab all the Users for the Group 
                        System.DirectoryServices.SearchResultCollection Groups = GSearch.FindAll();
                        //Get the number of members in this group
                        int MaxGroups = Groups.Count;

                        string tmpName;
                        string tmpDN;
                        for (int i = 0; i < Groups.Count; i++)
                        {
                            tmpName = (System.String)Groups[i].Properties["name"][0];
                            tmpDN = (System.String)Groups[i].Properties["distinguishedname"][0];
                            grps.Add(new ADGroup(tmpName, tmpDN));
                            grps.AddRange(GetNestedGroups(tmpName,tmpDN, globalCatalogURL[j]));
                        }
                    }
                }
            }

			return grps;
        }
        internal static System.Collections.Generic.List<ADGroup> GetNestedGroups(string parentName, string parentGroupDN, string parentCatalogURL)
        {
            System.Collections.Generic.List<ADGroup> nested = new System.Collections.Generic.List<ADGroup>();
            //Make a Connection with the Global Catalog Server
            System.DirectoryServices.DirectoryEntry Root = GetDirectoryEntry(parentCatalogURL);

            //Create a directory searcher based on the root catalog server
            using (System.DirectoryServices.DirectorySearcher GSearch = new System.DirectoryServices.DirectorySearcher(Root))
            {

                //Create a filter that gets all of the users for the group excluding the disabled accounts
                GSearch.Filter = "(&(objectClass=group)(distinguishedname=" + parentGroupDN + "))";//(&(objectclass=user)(objectsid=" + sid + ")) (&(objectclass=foreignSecurityPrincipal)(objectsid=" + sid + "))) ";
                GSearch.PropertiesToLoad.Add("distinguishedname");
                System.DirectoryServices.SearchResultCollection ResultGroup = GSearch.FindAll();
               
                 //Check to make sure a group is actually returned
                if (ResultGroup != null && ResultGroup.Count != 0)
                {
                    for (int k = 0; k < ResultGroup[0].Properties["objectclass"].Count; k++)
                        System.Diagnostics.Debug.WriteLine((string)ResultGroup[0].Properties["objectclass"][k]);

                    //Get the Distinguished name of the group
                    string memberDN = (string)ResultGroup[0].Properties["distinguishedname"][0];

                    //Now Create a filter that gets all of the users for the group excluding the disabled accounts
                    GSearch.Filter = "(&(objectClass=group)(Member=" + memberDN + "))";

                    //Only load the properties that we really need
                    GSearch.PropertiesToLoad.Add("name");
                    GSearch.PropertiesToLoad.Add("distinguishedname");

                    //Dispose of the CUrrent Result Group 
                    ResultGroup.Dispose();
                    //Grab all the Users for the Group 
                    System.DirectoryServices.SearchResultCollection Groups = GSearch.FindAll();
                    //Get the number of members in this group
                    int MaxGroups = Groups.Count;

                    string tmpName;
                    string tmpDN;
                    for (int i = 0; i < Groups.Count; i++)
                    {
                        tmpName = (System.String)Groups[i].Properties["name"][0];
                        tmpDN = (System.String)Groups[i].Properties["distinguishedname"][0];
                        nested.Add(new ADGroup(tmpName, tmpDN,parentName, true));

                        if (Groups[i].Properties["distinguishedname"][0].ToString().IndexOf("OU=Distribution Groups") == -1 
                            && tmpDN != parentGroupDN) //added DN check to account for recursive relationships that would cause stack overflow
                            nested.AddRange(GetNestedGroups(tmpName, tmpDN, parentCatalogURL));
                    }

                }
            }


            return nested;
        }

        internal static DirectoryEntry GetDirectoryEntry(string catalogURL)
        {

            DirectoryEntry entry = new DirectoryEntry("GC://" + catalogURL);
            entry.AuthenticationType = AuthenticationTypes.Secure;
            if (Properties.Settings.Default.AdAuthenticationID != null && Properties.Settings.Default.AdAuthenticationPW != null &&
                Properties.Settings.Default.AdAuthenticationID.Length > 0 && Properties.Settings.Default.AdAuthenticationPW.Length > 0 && Properties.Settings.Default.AdAuthenticationUseCustom)
            {
                entry.Password = Encryption.Crypter.Decrypt(Properties.Settings.Default.AdAuthenticationPW);
                entry.Username = Encryption.Crypter.Decrypt(Properties.Settings.Default.AdAuthenticationID);
            }
            
            return entry;
            
        }
        #region Get Group Memberships
        internal static ADGroupMembersTable GetGroupMembers(List<string> groupNames, string joinType)
		{
            try
            {
                //Create the query to get the group(s) distinguished names
                StringBuilder sb = new StringBuilder("(&(objectclass=group)(|");
                for (short i = 0; i < groupNames.Count; i++)
                {
                    if (groupNames[i] != null && groupNames[i].Length > 0)
                        sb.Append("(name=" + groupNames[i] + ")");
                }
                sb.Append("))");

                ADGroupMembersTable memTable = new ADGroupMembersTable();
                for (int j = 0; j < globalCatalogURL.Count; j++)
                {
                    DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);
                    DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                    searcher1.Filter = sb.ToString();
                    searcher1.PropertiesToLoad.Add("distinguishedname");
                    //Run the query to get the group DNs
                    SearchResultCollection groupCollection = searcher1.FindAll();

                    if (groupCollection.Count == 0)
                        continue;
                    //Create the filter string for the group(s) members query
                    sb.Length = 0;
                    sb.Append("(&(objectClass=user)");
                    if (joinType.ToLower() == "or")
                        sb.Append("(|");

                    for (short i = 0; i < groupCollection.Count; i++)
                        sb.Append("(memberOf=" + groupCollection[i].Properties["distinguishedname"][0] + ")");

                    if (joinType.ToLower() == "or")
                        sb.Append(")");

                    sb.Append(")");

                    searcher1.Filter = sb.ToString(); //"(&(objectClass=user)(memberOf=" + text1 + ")(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";
                    AddSearchProperties(ref searcher1);
                    SearchResultCollection userCollection = null;
                    try
                    {
                        userCollection = searcher1.FindAll();
                    }
                    catch { continue; }
                    int num1 = userCollection.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        if (userCollection[num2] != null)
                        {
                            SearchResult result = userCollection[num2];
                            AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);
                        }
                    }
                    groupCollection.Dispose();

                    ADGroupMembersTable foreign =  GetGroupsForeignMembers(groupNames,joinType);
                    for (int i = 0; i < foreign.Rows.Count; i++)
                        memTable.ImportRow(foreign[i]);
                    
                }
                string[] colNames = new string[memTable.Columns.Count];
                for (int i = 0; i < memTable.Columns.Count; i++)
                {
                    colNames[i] = memTable.Columns[i].ColumnName;
                }
                DataTable distinct = memTable.SelectDistinct(colNames);
                ADGroupMembersTable tbl = new ADGroupMembersTable(distinct);
                return ConvertToCountryName(tbl);
            }
            catch (ArgumentException exe)
            {
                if (exe.Message.IndexOf("search filter is invalid.") > -1)
                {
                   
                }

            }
            return new ADGroupMembersTable();
		}
        internal static ADGroupMembersTable GetGroupsForeignMembers(List<string> groupNames, string joinType)
        {
            //Collection to Return 
            ADGroupMembersTable masterMemTable = new ADGroupMembersTable();


            //If the Group Collection is Null, Simply Return an Empty Collection
            if (groupNames == null || groupNames.Count == 0)
                return masterMemTable;


            //check every catalog
            for (int idx = 0; idx < globalCatalogURL.Count; idx++)
            {
                ADGroupMembersTable gcMemTable = new ADGroupMembersTable();
                try
                {
                    //Make a Connection with the Global Catalog Server
                    System.DirectoryServices.DirectoryEntry Root = GetDirectoryEntry(globalCatalogURL[idx]);
                    //Create a directory searcher based on the root catalog server
                    using (System.DirectoryServices.DirectorySearcher GSearch = new System.DirectoryServices.DirectorySearcher(Root))
                    {
                        //foreach (string group in groups)
                        for (int i = 0; i < groupNames.Count; i++)
                        {
                            GSearch.Filter = "(SAMAccountName=" + groupNames[i] + ")";
                            GSearch.PropertiesToLoad.Add("member");
                            System.DirectoryServices.SearchResult searchResult = GSearch.FindOne();
                            try
                            {
                                ResultPropertyValueCollection valcol = searchResult.Properties["member"];
                                if (valcol != null)
                                {
                                    foreach (Object prop in valcol)
                                    {
                                        if (prop.ToString().IndexOf("CN=ForeignSecurityPrincipals") > -1)
                                        {
                                            string sid = prop.ToString().Substring(0, prop.ToString().IndexOf(",")).Remove(0, 3);
                                            ADGroupMembersTableRow foreign = GetAccountBySID(sid);
                                            if (foreign != null)
                                                gcMemTable.ImportRow(foreign);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }

                    } //using

                    //We need to pare out items that aren't in all groups
                    if(joinType.ToLower() == "and")
                    {
                        DataView mainView = gcMemTable.DefaultView;
                        mainView.RowStateFilter = DataViewRowState.OriginalRows;
                        for (int i = 0; i < mainView.Count; i++)
                        {
                            mainView.RowFilter = gcMemTable.AccountIdColumn.ColumnName + "='" + ((ADGroupMembersTableRow)mainView[i].Row).AccountId + "'";
                            if (mainView.Count != groupNames.Count)
                                mainView.Delete(0);
                            mainView.RowFilter = "";
                        }
                            gcMemTable.AcceptChanges();
                    }
                    masterMemTable.Merge(gcMemTable);



                }
                catch
                {
                    continue;
                }
            }
            return masterMemTable;
        }
        #endregion

        #region Get Account(s )
        internal static ADGroupMembersTableRow GetAccountBySID(string sid)
        {
                ADGroupMembersTable memTable = new ADGroupMembersTable();
                for (int j = 0; j < globalCatalogURL.Count; j++)
                {
                    DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);
                    DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                    searcher1.Filter = "(&(objectclass=user)(objectsid=" + sid + "))";
                    AddSearchProperties(ref searcher1);
                    SearchResultCollection collection = null;
                    try
                    {
                        collection = searcher1.FindAll();
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    //If nothing found, check next domain..
                    if (collection.Count == 0)
                        continue;

                    SearchResult result = collection[0];
                    AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);
                }

            memTable = ConvertToCountryName(memTable);
            if (memTable.Count > 0)
                return memTable[0];
            else
                return null;

        }
        internal static ADGroupMembersTableRow GetAccountByDN(string distinguishedName)
        {
            ADGroupMembersTable memTable = new ADGroupMembersTable();
           
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);
 

                DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                searcher1.Filter = "(&(objectClass=user)(distinguishedname=" + distinguishedName + "))";
                AddSearchProperties(ref searcher1);
                SearchResultCollection collection = null;
                try
                {
                    collection = searcher1.FindAll();
                }
                catch { continue; }
                //If nothing found, check next domain..
                if (collection.Count == 0)
                    continue;

                SearchResult result = collection[0];
                AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);



            }
            memTable = ConvertToCountryName(memTable);
            if (memTable.Count > 0)
                return memTable[0];
            else
                return null;

        }
        internal static ADGroupMembersTable GetAccount(string lastName, string firstName, string accountId, string eMailAddress)
        {
            ADGroupMembersTable memTable = new ADGroupMembersTable();
            StringBuilder sb = new StringBuilder("(&(objectCategory=person)(objectClass=user)");
            if (firstName.Length > 0)
                sb.Append("(givenName=" + firstName + "*)");
            if (lastName.Length > 0)
                sb.Append("(sn=" + lastName + "*)");
            if (accountId.Length > 0)
                sb.Append("(samaccountname=" + accountId + "*)");
            if (eMailAddress.Length > 0)
                sb.Append("(mail=" + eMailAddress + "*)");

            sb.Append(")");
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);

                DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                searcher1.Filter = sb.ToString();
                AddSearchProperties(ref searcher1);
                SearchResultCollection collection2 = null;
                try
                {
                    collection2 = searcher1.FindAll();
                }
                catch { continue; }
                int num1 = collection2.Count;
                //If nothing found, check next domain..
                if (num1 == 0)
                    continue;

                for (int num2 = 0; num2 < num1; num2++)
                {
                    if (collection2[num2] != null)
                    {
                        SearchResult result = collection2[num2];
                        AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);
                    }
                }


            }
            string[] colNames = new string[memTable.Columns.Count];
            for (int i = 0; i < memTable.Columns.Count; i++)
            {
                colNames[i] = memTable.Columns[i].ColumnName;
            }
            DataTable distinct = memTable.SelectDistinct(colNames);
            ADGroupMembersTable tbl = new ADGroupMembersTable(distinct);
            return ConvertToCountryName(tbl);
        }
		internal static ADGroupMembersTable GetAccount(string lastName, string firstName, string accountId)
		{
            return GetAccount(lastName, firstName, accountId, string.Empty);
        }
        internal static ADGroupMembersTable GetAccountFromString(string input)
        {
            if (input.Trim().Length > 0)
            {
                ADGroupMembersTable tblTmp = new ADGroupMembersTable();
                if (input.IndexOf("@") > -1) //e-mail address
                {
                    tblTmp = ADHelper.GetAccount("", "", "", input);
                }
                else if (input.IndexOf(",") > -1)  //Last,First
                {
                    string[] name = input.Split(new char[] { ',' }, 2, StringSplitOptions.None);
                    tblTmp = ADHelper.GetAccount(name[0], name[1], "");
                }
                else if (input.Trim().IndexOf(' ') > -1)  //First Last or odd combinations there-of
                {
                    string[] name = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (name.Length > 2) //Assume that there must be a middle name or inital
                    {
                        tblTmp = ADHelper.GetAccount(name[2], name[0], "");
                    }

                    //If nothing is returned, need to account for multi-part last names "Van Dekamp" for instance, try joining that.
                    // this will also catch plain "First Last" entries as well.
                    if (tblTmp.Count == 0)
                    {
                        tblTmp = ADHelper.GetAccount(String.Join(" ", name, 1, name.Length - 1), name[0], "");
                    }

                    //If there's still nothing, try to account for multipart first names "Mary Ellen" for instance.
                    if (tblTmp.Count == 0)
                    {
                        tblTmp = ADHelper.GetAccount(name[name.Length - 1], String.Join(" ", name, 0, name.Length - 1), "");
                    }

                    //If there's still nothing, last ditch effor to account for both multipart first and last names "Mary Ellen Van Dekamp" for instance.
                    if (tblTmp.Count == 0 && name.Length == 4)
                    {
                        tblTmp = ADHelper.GetAccount(String.Join(" ", name, 2, 2), String.Join(" ", name, 0, 2), "");
                    }

                    //OK, the real last ditch effort... try first initial, last name search...
                    if (tblTmp.Count == 0 && name.Length >= 2)
                    {
                        string first = name[0].Substring(0,1);
                        string last = name[name.Length-1];
                        tblTmp =  ADHelper.GetAccount(last, first, "");
                    }

                }
                else //user id
                {
                    tblTmp = ADHelper.GetAccount("", "", input.Trim());
                }
                return tblTmp;
            }

            return new ADGroupMembersTable();
        }
        internal static ADGroupMembersTable GetAccountByQuery(string userLdapQuery)
        {
            ADGroupMembersTable memTable = new ADGroupMembersTable();

            try
            {
                for (int j = 0; j < globalCatalogURL.Count; j++)
                {
                    DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);

                    DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                    searcher1.Filter = "(&(objectClass=user)(" + userLdapQuery + "))";
                    AddSearchProperties(ref searcher1);
                    SearchResultCollection collection = null;
                    try
                    {
                        collection = searcher1.FindAll();
                    }
                    catch { continue; }
                    //If nothing found, check next domain..
                    if (collection.Count == 0)
                        continue;

                    SearchResult result = collection[0];
                    AddMemberTableRow(ref memTable, ref result, globalCatalogURL[j]);



                }
                memTable = ConvertToCountryName(memTable);
                if (memTable.Count > 0)
                    return memTable;
                else
                    return null;
            }
            catch(ArgumentException arg)
            {
                if (ADHelper.InvalidLdapQuery != null)
                    ADHelper.InvalidLdapQuery(null, EventArgs.Empty);
            }

            return null;

        }
        #endregion

        public static bool DomainIsReachable(string domainName)
        {
            DirectoryEntry entry1 = GetDirectoryEntry(domainName);

            DirectorySearcher searcher1 = new DirectorySearcher(entry1);
            searcher1.Filter = "(&(objectClass=user)(objectGuid=506FA7DB-EF07-4ca1-9634-F080ED120212))";
            searcher1.PropertiesToLoad.Add("distinguishedname");
            searcher1.ClientTimeout = new TimeSpan(0, 0, 5);
            try
            {
                SearchResultCollection collection = searcher1.FindAll();
                return true;
            }
            catch
            {
                return false;
            }


        }
        internal static ADGroupMembersTable ConvertToCountryName(ADGroupMembersTable memTable)
		{
			foreach(ADGroupMembersTableRow row in memTable)
			{
				row.Country = (CountryNames[row.Country] != null)? CountryNames[row.Country].ToString() : row.Country;
			}
			memTable.AcceptChanges();
			return memTable;

		}

        //Used for SID conversion into a real string.
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool ConvertSidToStringSid([MarshalAs(UnmanagedType.LPArray)] byte[] pSID, out IntPtr ptrSid); 

        private static void AddSearchProperties(ref DirectorySearcher searcher)
        {
            searcher.PropertiesToLoad.Add("givenname");
            searcher.PropertiesToLoad.Add("sn");
            searcher.PropertiesToLoad.Add("samaccountname");
            searcher.PropertiesToLoad.Add("title");
            searcher.PropertiesToLoad.Add("mail");
            searcher.PropertiesToLoad.Add("telephonenumber");
            searcher.PropertiesToLoad.Add("c");
            searcher.PropertiesToLoad.Add("manager");
            searcher.PropertiesToLoad.Add("distinguishedname");
            searcher.PropertiesToLoad.Add("otherTelephone");
            searcher.PropertiesToLoad.Add("badPwdCount");
            searcher.PropertiesToLoad.Add("badPasswordTime");
            searcher.PropertiesToLoad.Add("msDS-User-Account-Control-Computed");
            searcher.PropertiesToLoad.Add("lastLogon");
            searcher.PropertiesToLoad.Add("objectSID");
            searcher.PropertiesToLoad.Add("objectGUID");
            searcher.PropertiesToLoad.Add("userAccountControl");
            searcher.PropertiesToLoad.Add("userprincipalname");
            searcher.PropertiesToLoad.Add("objectclass");

            searcher.PropertiesToLoad.Add("st");
            searcher.PropertiesToLoad.Add("postalCode");
            searcher.PropertiesToLoad.Add("streetAddress");
            searcher.PropertiesToLoad.Add("l");
            searcher.PropertiesToLoad.Add("whenCreated");
            searcher.PropertiesToLoad.Add("whenChanged");
            searcher.PropertiesToLoad.Add("physicalDeliveryOfficeName");
            searcher.PropertiesToLoad.Add("description");
            searcher.PropertiesToLoad.Add("department");
            searcher.PropertiesToLoad.Add("homephone");

            if (Properties.Settings.Default.CustomPropertyList != null)
            {
                for (int i = 0; i < Properties.Settings.Default.CustomPropertyList.Count; i++)
                {
                    searcher.PropertiesToLoad.Add(Properties.Settings.Default.CustomPropertyList[i].LdapPropertyName);
                }
            }
        }
        private static void AddMemberTableRow(ref ADGroupMembersTable memTable, ref SearchResult result, string owningDomain)
        {
            bool keepLooking = true;
            int flagVal = -1;
            string status = "";
            string accountFlagsComputed = string.Empty;
            string accountFlags = string.Empty;
            if (result.Properties.Contains("msDS-User-Account-Control-Computed"))
            {
                //Method from:http://www.awprofessional.com/articles/article.asp?p=474649&seqNum=3&rl=1
                flagVal = (int)result.Properties["msDS-User-Account-Control-Computed"][0];

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.AccountDisabled))
                    status = "Disabled";

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.AccountLockedOut))
                    status = "Locked";

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.PasswordExpired))
                    status = "PW Exp";

                if (status != "") keepLooking = false;
                accountFlagsComputed = AdsUserFlagsListed.GetTextList(flagVal);

            }
            if (result.Properties.Contains("userAccountControl"))
            {
                flagVal = (int)result.Properties["userAccountControl"][0];
                accountFlags = AdsUserFlagsListed.GetTextList(flagVal);
            }
            //If we found a status in the computed property, skip this one
            if (keepLooking && result.Properties.Contains("userAccountControl"))
            {
                flagVal = (int)result.Properties["userAccountControl"][0];

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.AccountDisabled))
                    status = "Disabled";

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.AccountLockedOut))
                    status = "Locked";

                if (Convert.ToBoolean(flagVal & (int)AdsUserFlags.PasswordExpired))
                    status = "PW Exp";

                //If there a status here, don't look any farther.
                if (status != "") keepLooking = false;

            }

            if (keepLooking && result.Properties.Contains("badPwdCount"))
            {
                status = "Bad PW:" + result.Properties["badPwdCount"][0].ToString();
            }
            else
            {
                if (status == "" && result.Properties.Contains("userAccountControl"))
                    status = "OK";
                else if (status == "")
                    status = "?";
            }

            string sidValue = string.Empty;
            if (result.Properties.Contains("ObjectSID"))
            {
                IntPtr ptrSid;
                ConvertSidToStringSid((byte[])(result.Properties["ObjectSID"][0]), out ptrSid);
                sidValue = Marshal.PtrToStringAuto(ptrSid);
            }

            



            DateTime created = (result.Properties.Contains("whenCreated")) ? DateTime.Parse(result.Properties["whenCreated"][0].ToString()) : DateTime.MinValue;
            DateTime modified = (result.Properties.Contains("whenChanged")) ? DateTime.Parse(result.Properties["whenChanged"][0].ToString()) : DateTime.MinValue;

            memTable.AddADGroupMembersTableRow(
                (string)(result.Properties.Contains("sn") ? result.Properties["sn"][0] : ""),
                (string)(result.Properties.Contains("givenname") ? result.Properties["givenname"][0] : ""),
                (string)(result.Properties.Contains("samaccountname") ? result.Properties["samaccountname"][0] : ""),
                (string)(result.Properties.Contains("title") ? result.Properties["title"][0] : ""),
                (string)(result.Properties.Contains("mail") ? result.Properties["mail"][0] : ""),
                (string)(result.Properties.Contains("telephonenumber") ? result.Properties["telephonenumber"][0] : ""),
                (string)(result.Properties.Contains("distinguishedname") ? result.Properties["distinguishedname"][0] : ""),
                (string)(result.Properties.Contains("c") ? result.Properties["c"][0] : ""), //country
                (string)(result.Properties.Contains("st") ? result.Properties["st"][0] : ""), //state
                (string)(result.Properties.Contains("l") ? result.Properties["l"][0] : ""), //city
                (string)(result.Properties.Contains("streetAddress") ? result.Properties["streetAddress"][0] : ""),
                (string)(result.Properties.Contains("postalCode") ? result.Properties["postalCode"][0] : ""),
                (string)(result.Properties.Contains("otherTelephone") ? result.Properties["otherTelephone"][0] : ""),
                (string)(result.Properties.Contains("manager") ? result.Properties["manager"][0] : ""),
                //(int)(result.Properties.Contains("badPwdCount") ? result.Properties["badPwdCount"][0] : 0),
                //(DateTime)(result.Properties.Contains("badPasswordTime") ? result.Properties["badPasswordTime"][0] : DateTime.MinValue),
                //(DateTime)(result.Properties.Contains("lastLogon") ? result.Properties["lastLogon"][0] : DateTime.MinValue),
                (int)(result.Properties.Contains("userAccountControl") ? result.Properties["userAccountControl"][0] : 0),
                accountFlags,
                (int)(result.Properties.Contains("msDS-User-Account-Control-Computed") ? result.Properties["msDS-User-Account-Control-Computed"][0] : 0),
                accountFlagsComputed,
                sidValue,
                (string)(result.Properties.Contains("ObjectGUID") ? new Guid((byte[])(result.Properties["ObjectGUID"][0])).ToString() : ""),
                created,
                modified,
                owningDomain,
                status,
                (string)(result.Properties.Contains("physicalDeliveryOfficeName") ? result.Properties["physicalDeliveryOfficeName"][0] : ""),
                (string)(result.Properties.Contains("description") ? result.Properties["description"][0] : ""),
                (string)(result.Properties.Contains("department") ? result.Properties["department"][0] : ""),
                (string)(result.Properties.Contains("homephone") ? result.Properties["homephone"][0] : ""),
                0,
                memTable.NewADGroupMembersTableRow());

            if (Properties.Settings.Default.CustomPropertyList != null)
            {
                string prop;
                ADGroupMembersTableRow row = (ADGroupMembersTableRow)memTable.Rows[memTable.Rows.Count - 1];
                for (int i = 0; i < Properties.Settings.Default.CustomPropertyList.Count; i++)
                {
                    prop = Properties.Settings.Default.CustomPropertyList[i].LdapPropertyName;
                    if (row[prop].ToString().Length == 0)
                    {
                        if (result.Properties[prop].Count > 0)
                        {
                            switch (prop)
                            {
                                case "lastlogontimestamp":
                                case "pwdlastset":
                                case "usncreated":
                                case "usnchanged":
                                    row[prop] = DateTime.FromFileTime((long)result.Properties[prop][0]).ToString();
                                    break;
                                default:
                                    row[prop] = (string)(result.Properties.Contains(prop) ? result.Properties[prop][0].ToString() : "");
                                    break;
                            }
                        }
                        else
                        {
                            row[prop] = "<Not found>";
                        }
                    }
                }
            }

            if (ADHelper.AvailableLdapProps.Count == 0 && memTable.Rows.Count > 0)
            {
                SetLdapPropertyList(memTable[0].DistinguishedName);
            }
        }
        public static void SetLdapPropertyList(string distinguishedName)
        {
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                DirectoryEntry entry1 = GetDirectoryEntry(globalCatalogURL[j]);
                entry1.AuthenticationType = AuthenticationTypes.Secure;

                DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                searcher1.Filter = "(&(objectClass=user)(distinguishedname=" + distinguishedName + "))";
                SearchResultCollection collection = null;
                try
                {
                    collection = searcher1.FindAll();
                    ICollection coll = collection[0].Properties.PropertyNames;
                    List<string> tmp = new List<string>();
                    IEnumerator enumer =  coll.GetEnumerator();
                    while(enumer.MoveNext())
                    {
                        tmp.Add(enumer.Current.ToString());
                    }
                    tmp.Sort();
                    ADHelper.AvailableLdapProps = tmp;
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

        }
       

        internal static string PerformTokenReplacement(string tokenedString, ADGroupMembersTableRow row)
        {
            ADGroupMembersTable tmp = (ADGroupMembersTable)row.Table;
            foreach (System.Data.DataColumn col in tmp.Columns)
            {
                tokenedString = tokenedString.Replace("{" + col.ColumnName + "}", row[col.ColumnName].ToString());
            }
            return tokenedString;
        }

        internal static string Eval(string sCSCode)
        {

            CSharpCodeProvider c = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();

            cp.ReferencedAssemblies.Add("system.dll");
            
            cp.CompilerOptions = "/t:library";
            cp.GenerateInMemory = true;

            StringBuilder sb = new StringBuilder("");
            sb.Append("using System;\n");
            sb.Append("using System.Text;\n");
            sb.Append("namespace ActiveDirectoryHelper{ \n");
            sb.Append("\tpublic class CSCodeEvaler{ \n");
            sb.Append("\t\tpublic string EvalCode(){\n");
            sb.Append("\t\t\treturn " + sCSCode + "; \n");
            sb.Append("\t\t} \n");
            sb.Append("\t} \n");
            sb.Append("}\n");

            CompilerResults cr = c.CompileAssemblyFromSource(cp, sb.ToString());
            if (cr.Errors.Count > 0)
            {
                if (CSharpSnippetCompileError != null)
                    CSharpSnippetCompileError(sCSCode, EventArgs.Empty);

                foreach (CompilerError err in cr.Errors)
                    sb.Append("\r\n" + err.ErrorText);

                System.Diagnostics.EventLog.WriteEntry("ActiveDirectoryHelper", "Error compiling CS Code:\r\n" + sb.ToString(),System.Diagnostics.EventLogEntryType.Error);
                return sCSCode;
            }

            System.Reflection.Assembly a = cr.CompiledAssembly;
            object o = a.CreateInstance("ActiveDirectoryHelper.CSCodeEvaler");

            Type t = o.GetType();
            MethodInfo mi = t.GetMethod("EvalCode");

            try
            {
                object s = mi.Invoke(o, null);
                return s.ToString();
            }
            catch (Exception exe)
            {
                if (CSharpSnippetCompileError != null)
                    CSharpSnippetCompileError(sCSCode, EventArgs.Empty);

                sb.Append("\r\n" + exe.ToString());
                System.Diagnostics.EventLog.WriteEntry("ActiveDirectoryHelper", "Error compiling CS Code:\r\n" + sb.ToString(), System.Diagnostics.EventLogEntryType.Error);

                
                return string.Empty;
            }

        }

        public static event EventHandler InvalidLdapQuery;
        public static event EventHandler CSharpSnippetCompileError;
    }
    public class LdapPropertyMapping
    {
        
        public string this[string val]
        {
            get
            {
                switch (val)
                {
                    case "l":
                        return "City";
                    case "c":
                        return "Country";
                    case "st":
                        return "State/Prov";
                    case "mail":
                        return "EMail";
                    case "physicalDeliveryOfficeName":
                        return "Office";
                    case "sn":
                        return "Last Name";
                    case "givenname":
                        return "First Name";
                    case "samaccountname":
                        return "Account ID";
                    default:
                        return val;
                }
            }
        }
    }
	public class GroupLoadedEventArgs : EventArgs
	{
		public readonly SortedList FullGroupList;
		public GroupLoadedEventArgs(SortedList fullGroupList)
		{
			this.FullGroupList = fullGroupList;
		}
	}

}
