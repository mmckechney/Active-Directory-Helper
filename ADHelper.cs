using System;
using ActiveDirectoryHelper.Tables;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace ActiveDirectoryHelper
{
	/// <summary>
	/// Summary description for ADHelper.
	/// </summary>
	public class ADHelper
	{
        private static List<string> globalCatalogURL = new List<string>();

        public static List<string> GlobalCatalogURL
        {
            get { return globalCatalogURL; }
            set
            {
                globalCatalogURL = value;
            }
        }

		private static Hashtable _countryNames;
		internal static Hashtable CountryNames
		{
			get
			{
				if(_countryNames == null)
				{

				}
				return _countryNames;
			}
		}
		static ADHelper()
		{
			Hashtable ht = new Hashtable();
			ht.Add("AD","ANDORRA");
			ht.Add("AE","UNITED ARAB EMIRATES");
			ht.Add("AF","AFGHANISTAN");
			ht.Add("AG","ANTIGUA AND BARBUDA");
			ht.Add("AI","ANGUILLA");
			ht.Add("AL","ALBANIA");
			ht.Add("AM","ARMENIA");
			ht.Add("AN","NETHERLANDS ANTILLES");
			ht.Add("AO","ANGOLA");
			ht.Add("AQ","ANTARCTICA");
			ht.Add("AR","ARGENTINA");
			ht.Add("AS","AMERICAN SAMOA");
			ht.Add("AT","AUSTRIA");
			ht.Add("AU","AUSTRALIA");
			ht.Add("AW","ARUBA");
			ht.Add("AX","ÅLAND ISLANDS");
			ht.Add("AZ","AZERBAIJAN");
			ht.Add("BA","BOSNIA AND HERZEGOVINA");
			ht.Add("BB","BARBADOS");
			ht.Add("BD","BANGLADESH");
			ht.Add("BE","BELGIUM");
			ht.Add("BF","BURKINA FASO");
			ht.Add("BG","BULGARIA");
			ht.Add("BH","BAHRAIN");
			ht.Add("BI","BURUNDI");
			ht.Add("BJ","BENIN");
			ht.Add("BM","BERMUDA");
			ht.Add("BN","BRUNEI DARUSSALAM");
			ht.Add("BO","BOLIVIA");
			ht.Add("BR","BRAZIL");
			ht.Add("BS","BAHAMAS");
			ht.Add("BT","BHUTAN");
			ht.Add("BV","BOUVET ISLAND");
			ht.Add("BW","BOTSWANA");
			ht.Add("BY","BELARUS");
			ht.Add("BZ","BELIZE");
			ht.Add("CA","CANADA");
			ht.Add("CC","COCOS (KEELING) ISLANDS");
			ht.Add("CD","CONGO  THE DEMOCRATIC REPUBLIC OF THE");
			ht.Add("CF","CENTRAL AFRICAN REPUBLIC");
			ht.Add("CG","CONGO");
			ht.Add("CH","SWITZERLAND");
			ht.Add("CI","COTE D'IVOIRE");
			ht.Add("CK","COOK ISLANDS");
			ht.Add("CL","CHILE");
			ht.Add("CM","CAMEROON");
			ht.Add("CN","CHINA");
			ht.Add("CO","COLOMBIA");
			ht.Add("CR","COSTA RICA");
			ht.Add("CS","SERBIA AND MONTENEGRO");
			ht.Add("CU","CUBA");
			ht.Add("CV","CAPE VERDE");
			ht.Add("CX","CHRISTMAS ISLAND");
			ht.Add("CY","CYPRUS");
			ht.Add("CZ","CZECH REPUBLIC");
			ht.Add("DE","GERMANY");
			ht.Add("DJ","DJIBOUTI");
			ht.Add("DK","DENMARK");
			ht.Add("DM","DOMINICA");
			ht.Add("DO","DOMINICAN REPUBLIC");
			ht.Add("DZ","ALGERIA");
			ht.Add("EC","ECUADOR");
			ht.Add("EE","ESTONIA");
			ht.Add("EG","EGYPT");
			ht.Add("EH","WESTERN SAHARA");
			ht.Add("ER","ERITREA");
			ht.Add("ES","SPAIN");
			ht.Add("ET","ETHIOPIA");
			ht.Add("FI","FINLAND");
			ht.Add("FJ","FIJI");
			ht.Add("FK","FALKLAND ISLANDS (MALVINAS)");
			ht.Add("FM","MICRONESIA  FEDERATED STATES OF");
			ht.Add("FO","FAROE ISLANDS");
			ht.Add("FR","FRANCE");
			ht.Add("GA","GABON");
			ht.Add("GB","UNITED KINGDOM");
			ht.Add("GD","GRENADA");
			ht.Add("GE","GEORGIA");
			ht.Add("GF","FRENCH GUIANA");
			ht.Add("GH","GHANA");
			ht.Add("GI","GIBRALTAR");
			ht.Add("GL","GREENLAND");
			ht.Add("GM","GAMBIA");
			ht.Add("GN","GUINEA");
			ht.Add("GP","GUADELOUPE");
			ht.Add("GQ","EQUATORIAL GUINEA");
			ht.Add("GR","GREECE");
			ht.Add("GS","SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS");
			ht.Add("GT","GUATEMALA");
			ht.Add("GU","GUAM");
			ht.Add("GW","GUINEA-BISSAU");
			ht.Add("GY","GUYANA");
			ht.Add("HK","HONG KONG");
			ht.Add("HM","HEARD ISLAND AND MCDONALD ISLANDS");
			ht.Add("HN","HONDURAS");
			ht.Add("HR","CROATIA");
			ht.Add("HT","HAITI");
			ht.Add("HU","HUNGARY");
			ht.Add("ID","INDONESIA");
			ht.Add("IE","IRELAND");
			ht.Add("IL","ISRAEL");
			ht.Add("IN","INDIA");
			ht.Add("IO","BRITISH INDIAN OCEAN TERRITORY");
			ht.Add("IQ","IRAQ");
			ht.Add("IR","IRAN  ISLAMIC REPUBLIC OF");
			ht.Add("IS","ICELAND");
			ht.Add("IT","ITALY");
			ht.Add("JM","JAMAICA");
			ht.Add("JO","JORDAN");
			ht.Add("JP","JAPAN");
			ht.Add("KE","KENYA");
			ht.Add("KG","KYRGYZSTAN");
			ht.Add("KH","CAMBODIA");
			ht.Add("KI","KIRIBATI");
			ht.Add("KM","COMOROS");
			ht.Add("KN","SAINT KITTS AND NEVIS");
			ht.Add("KP","KOREA  DEMOCRATIC PEOPLE'S REPUBLIC OF");
			ht.Add("KR","KOREA  REPUBLIC OF");
			ht.Add("KW","KUWAIT");
			ht.Add("KY","CAYMAN ISLANDS");
			ht.Add("KZ","KAZAKHSTAN");
			ht.Add("LA","LAO PEOPLE'S DEMOCRATIC REPUBLIC");
			ht.Add("LB","LEBANON");
			ht.Add("LC","SAINT LUCIA");
			ht.Add("LI","LIECHTENSTEIN");
			ht.Add("LK","SRI LANKA");
			ht.Add("LR","LIBERIA");
			ht.Add("LS","LESOTHO");
			ht.Add("LT","LITHUANIA");
			ht.Add("LU","LUXEMBOURG");
			ht.Add("LV","LATVIA");
			ht.Add("LY","LIBYAN ARAB JAMAHIRIYA");
			ht.Add("MA","MOROCCO");
			ht.Add("MC","MONACO");
			ht.Add("MD","MOLDOVA  REPUBLIC OF");
			ht.Add("MG","MADAGASCAR");
			ht.Add("MH","MARSHALL ISLANDS");
			ht.Add("MK","MACEDONIA  THE FORMER YUGOSLAV REPUBLIC OF");
			ht.Add("ML","MALI");
			ht.Add("MM","MYANMAR");
			ht.Add("MN","MONGOLIA");
			ht.Add("MO","MACAO");
			ht.Add("MP","NORTHERN MARIANA ISLANDS");
			ht.Add("MQ","MARTINIQUE");
			ht.Add("MR","MAURITANIA");
			ht.Add("MS","MONTSERRAT");
			ht.Add("MT","MALTA");
			ht.Add("MU","MAURITIUS");
			ht.Add("MV","MALDIVES");
			ht.Add("MW","MALAWI");
			ht.Add("MX","MEXICO");
			ht.Add("MY","MALAYSIA");
			ht.Add("MZ","MOZAMBIQUE");
			ht.Add("NA","NAMIBIA");
			ht.Add("NC","NEW CALEDONIA");
			ht.Add("NE","NIGER");
			ht.Add("NF","NORFOLK ISLAND");
			ht.Add("NG","NIGERIA");
			ht.Add("NI","NICARAGUA");
			ht.Add("NL","NETHERLANDS");
			ht.Add("NO","NORWAY");
			ht.Add("NP","NEPAL");
			ht.Add("NR","NAURU");
			ht.Add("NU","NIUE");
			ht.Add("NZ","NEW ZEALAND");
			ht.Add("OM","OMAN");
			ht.Add("PA","PANAMA");
			ht.Add("PE","PERU");
			ht.Add("PF","FRENCH POLYNESIA");
			ht.Add("PG","PAPUA NEW GUINEA");
			ht.Add("PH","PHILIPPINES");
			ht.Add("PK","PAKISTAN");
			ht.Add("PL","POLAND");
			ht.Add("PM","SAINT PIERRE AND MIQUELON");
			ht.Add("PN","PITCAIRN");
			ht.Add("PR","PUERTO RICO");
			ht.Add("PS","PALESTINIAN TERRITORY  OCCUPIED");
			ht.Add("PT","PORTUGAL");
			ht.Add("PW","PALAU");
			ht.Add("PY","PARAGUAY");
			ht.Add("QA","QATAR");
			ht.Add("RE","REUNION");
			ht.Add("RO","ROMANIA");
			ht.Add("RU","RUSSIAN FEDERATION");
			ht.Add("RW","RWANDA");
			ht.Add("SA","SAUDI ARABIA");
			ht.Add("SB","SOLOMON ISLANDS");
			ht.Add("SC","SEYCHELLES");
			ht.Add("SD","SUDAN");
			ht.Add("SE","SWEDEN");
			ht.Add("SG","SINGAPORE");
			ht.Add("SH","SAINT HELENA");
			ht.Add("SI","SLOVENIA");
			ht.Add("SJ","SVALBARD AND JAN MAYEN");
			ht.Add("SK","SLOVAKIA");
			ht.Add("SL","SIERRA LEONE");
			ht.Add("SM","SAN MARINO");
			ht.Add("SN","SENEGAL");
			ht.Add("SO","SOMALIA");
			ht.Add("SR","SURINAME");
			ht.Add("ST","SAO TOME AND PRINCIPE");
			ht.Add("SV","EL SALVADOR");
			ht.Add("SY","SYRIAN ARAB REPUBLIC");
			ht.Add("SZ","SWAZILAND");
			ht.Add("TC","TURKS AND CAICOS ISLANDS");
			ht.Add("TD","CHAD");
			ht.Add("TF","FRENCH SOUTHERN TERRITORIES");
			ht.Add("TG","TOGO");
			ht.Add("TH","THAILAND");
			ht.Add("TJ","TAJIKISTAN");
			ht.Add("TK","TOKELAU");
			ht.Add("TL","TIMOR-LESTE");
			ht.Add("TM","TURKMENISTAN");
			ht.Add("TN","TUNISIA");
			ht.Add("TO","TONGA");
			ht.Add("TR","TURKEY");
			ht.Add("TT","TRINIDAD AND TOBAGO");
			ht.Add("TV","TUVALU");
			ht.Add("TW","TAIWAN  PROVINCE OF CHINA");
			ht.Add("TZ","TANZANIA  UNITED REPUBLIC OF");
			ht.Add("UA","UKRAINE");
			ht.Add("UG","UGANDA");
			ht.Add("UM","UNITED STATES MINOR OUTLYING ISLANDS");
			ht.Add("US","UNITED STATES");
			ht.Add("UY","URUGUAY");
			ht.Add("UZ","UZBEKISTAN");
			ht.Add("VA","HOLY SEE (VATICAN CITY STATE)");
			ht.Add("VC","SAINT VINCENT AND THE GRENADINES");
			ht.Add("VE","VENEZUELA");
			ht.Add("VG","VIRGIN ISLANDS  BRITISH");
			ht.Add("VI","VIRGIN ISLANDS  U.S.");
			ht.Add("VN","VIET NAM");
			ht.Add("VU","VANUATU");
			ht.Add("WF","WALLIS AND FUTUNA");
			ht.Add("WS","SAMOA");
			ht.Add("YE","YEMEN");
			ht.Add("YT","MAYOTTE");
			ht.Add("ZA","SOUTH AFRICA");
			ht.Add("ZM","ZAMBIA");
			ht.Add("ZW","ZIMBABWE");
			ht.Add("ZZ","N/A");

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
                DirectoryEntry entry1 = new DirectoryEntry("GC://"+globalCatalogURL[idx]);
                DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                searcher1.Filter = "(objectClass=group)";
                searcher1.PropertiesToLoad.Add("name");
                searcher1.PropertiesToLoad.Add("distinguishedname");
                SearchResultCollection collAllGroups = null;
                try
                {
                    collAllGroups = searcher1.FindAll();
                }
                catch { continue; }
                string[] allGroups = new string[collAllGroups.Count];
                for (int i = 0; i < collAllGroups.Count; i++)
                {
                    if (collAllGroups[i].Properties["name"] != null && collAllGroups[i].Properties["name"][0] != null)
                    {
                        if (fullGroupList.ContainsKey(collAllGroups[i].Properties["name"][0]) == false)
                            fullGroupList.Add(collAllGroups[i].Properties["name"][0], collAllGroups[i].Properties["distinguishedname"][0]);

                    }
                }
            }
			
            return new GroupLoadedEventArgs(fullGroupList);
		}

		internal static ADGroupMembersTableRow GetUsersManagers(string distinguishedName)
		{
            ADGroupMembersTableRow firstUser = GetAccountByDN(distinguishedName);
			return GetUsersManagers(firstUser);
		}
		internal static ADGroupMembersTableRow GetUsersManagers( ADGroupMembersTableRow memberRow)
		{
			if(memberRow.ManagerDN.Length == 0)
				return memberRow;

			//ADGroupMembersTableRow manager = GetAccount(string.Empty,string.Empty,string.Empty,memberRow.ManagerDN)[0];
			//memberRow.Manager = manager;
            memberRow.Manager = GetUsersManagers(GetAccountByDN(memberRow.ManagerDN));
			return memberRow;
		}
        internal static ADGroupMembersTable GetDirectReports(string distinguishedName)
        {
            ADGroupMembersTable memTable = new ADGroupMembersTable();
            StringBuilder sb = new StringBuilder("(&(objectCategory=person)(objectClass=user)");
            sb.Append("(manager=" + distinguishedName + ")");
            sb.Append(")");
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                DirectoryEntry entry1 = new DirectoryEntry("GC://" + globalCatalogURL[j]);
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

		internal static System.Collections.Generic.List<ADGroup> GetGroups(string distinguishedName,string sid, string searchDomain)
		{
            System.Collections.Generic.List<ADGroup> grps = new System.Collections.Generic.List<ADGroup>();
			//Make a Connection with the Global Catalog Server
            for (int j = 0; j < globalCatalogURL.Count; j++)
            {
                System.DirectoryServices.DirectoryEntry Root = new System.DirectoryServices.DirectoryEntry("GC://" + globalCatalogURL[j]);
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

                        for (int i = 0; i < Groups.Count; i++)
                        {
                            grps.Add(new ADGroup((System.String)Groups[i].Properties["name"][0], (System.String)Groups[i].Properties["distinguishedname"][0]));
                            grps.AddRange(GetNestedGroups((System.String)Groups[i].Properties["distinguishedname"][0], globalCatalogURL[j]));
                        }
                    }
                }
            }

			return grps;
        }
        internal static System.Collections.Generic.List<ADGroup> GetNestedGroups(string parentGroupDN, string parentCatalogURL)
        {
            System.Collections.Generic.List<ADGroup> nested = new System.Collections.Generic.List<ADGroup>();
            //Make a Connection with the Global Catalog Server
            System.DirectoryServices.DirectoryEntry Root = new System.DirectoryServices.DirectoryEntry("GC://" + parentCatalogURL);
            //Create a directory searcher based on the root catalog server
            using (System.DirectoryServices.DirectorySearcher GSearch = new System.DirectoryServices.DirectorySearcher(Root))
            {

                //Create a filter that gets all of the users for the group excluding the disabled accounts
                GSearch.Filter = "(&(objectClass=group)(distinguishedname=" + parentGroupDN + "))";//(&(objectclass=user)(objectsid=" + sid + ")) (&(objectclass=foreignSecurityPrincipal)(objectsid=" + sid + "))) ";
                GSearch.PropertiesToLoad.Add("distinguishedname");
                System.DirectoryServices.SearchResultCollection ResultGroup = GSearch.FindAll();
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

                    //Dispose of the CUrrent Result Group 
                    ResultGroup.Dispose();
                    //Grab all the Users for the Group 
                    System.DirectoryServices.SearchResultCollection Groups = GSearch.FindAll();
                    //Get the number of members in this group
                    int MaxGroups = Groups.Count;

                    for (int i = 0; i < Groups.Count; i++)
                    {
                        nested.Add(new ADGroup((System.String)Groups[i].Properties["name"][0], (System.String)Groups[i].Properties["distinguishedname"][0], true));

                        if (Groups[i].Properties["distinguishedname"][0].ToString().IndexOf("OU=Distribution Groups") == -1)
                            nested.AddRange(GetNestedGroups((System.String)Groups[i].Properties["distinguishedname"][0], parentCatalogURL));
                    }

                }
            }


            return nested;
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
                    DirectoryEntry entry1 = new DirectoryEntry("GC://"+globalCatalogURL[j]);
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
                    System.DirectoryServices.DirectoryEntry Root = new System.DirectoryServices.DirectoryEntry("GC://" + globalCatalogURL[idx]);

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


        #region Get Accounts 
        internal static ADGroupMembersTableRow GetAccountBySID(string sid)
        {
                ADGroupMembersTable memTable = new ADGroupMembersTable();
                for (int j = 0; j < globalCatalogURL.Count; j++)
                {
                    DirectoryEntry entry1 = new DirectoryEntry("GC://" + globalCatalogURL[j]);
                    DirectorySearcher searcher1 = new DirectorySearcher(entry1);
                    searcher1.Filter = "(&(objectclass=user)(objectsid=" + sid + "))";
                    AddSearchProperties(ref searcher1);
                    SearchResultCollection collection = null;
                    try
                    {
                        collection = searcher1.FindAll();
                    }
                    catch (Exception e)
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
                DirectoryEntry entry1 = new DirectoryEntry("GC://" + globalCatalogURL[j]);
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
                DirectoryEntry entry1 = new DirectoryEntry("GC://" + globalCatalogURL[j]);
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
        #endregion

        public static bool DomainIsReachable(string domainName)
        {
            DirectoryEntry entry1 = new DirectoryEntry("GC://" + domainName);
            DirectorySearcher searcher1 = new DirectorySearcher(entry1);
            searcher1.Filter = "(&(objectClass=user)(objectGuid=506FA7DB-EF07-4ca1-9634-F080ED120212))";
            searcher1.PropertiesToLoad.Add("distinguishedname");
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
                0,
                memTable.NewADGroupMembersTableRow());

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
