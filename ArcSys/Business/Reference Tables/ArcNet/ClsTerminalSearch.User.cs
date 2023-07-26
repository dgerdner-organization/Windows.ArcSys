using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public class ClsTerminalSearch
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields

		public string Port_CDs;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public ClsTerminalSearch()
		{
			Clear();
		}

		public ClsTerminalSearch(ClsTerminalSearch aSearch)
		{
			Clear();
			CopyFrom(aSearch);
		}

		public void CopyFrom(ClsTerminalSearch aSearch)
		{
			Port_CDs = aSearch.Port_CDs;
		}

		public void Clear()
		{
			Port_CDs = null;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (!string.IsNullOrEmpty(Port_CDs)) sb.AppendFormat(" PLOR {0} ", Port_CDs);

			return sb.ToString();
		}
		#endregion		// #region ToString Overrides

		#region Search Methods

		public DataSet SearchTerminalDS()
		{
			DataSet ds = new DataSet();

			DataTable dtTerminals = SearchTerminals();
			ds.Tables.Add(dtTerminals);

			DataTable dtAddr = SearchAddresses();
			ds.Tables.Add(dtAddr);

			DataColumn[] dcPK = new DataColumn[1];
			dcPK[0] = dtTerminals.Columns["TERMINAL_CD"];

			DataColumn[] dcAddrFK = new DataColumn[1];
			dcAddrFK[0] = dtAddr.Columns["TERMINAL_CD"];

			DataTable dtContacts = SearchContacts();
			ds.Tables.Add(dtContacts);

			DataColumn[] dcContactFK = new DataColumn[1];
			dcContactFK[0] = dtContacts.Columns["TERMINAL_CD"];

			DataTable dtLinks = SearchLinks();
			ds.Tables.Add(dtLinks);

			DataColumn[] dcLinksFK = new DataColumn[1];
			dcLinksFK[0] = dtLinks.Columns["TERMINAL_CD"];

			if (dtTerminals.Rows.Count > 0)
			{
				ds.Relations.Add("TerminalAddress", dcPK, dcAddrFK, false);
				ds.Relations.Add("TerminalContact", dcPK, dcContactFK, false);
				ds.Relations.Add("TerminalLink", dcPK, dcLinksFK, false);
			}

			return ds;
		}

		public DataTable SearchTerminals()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	loc.location_dsc, trm.*
			from	r_terminal trm
					inner join r_location loc on loc.location_cd = trm.location_cd
			where	1 = 1 ");

			AppendWhere(sb, p, true);

			sb.Append(@"
			order by loc.location_dsc, trm.terminal_cd ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Terminal";
			}
			return dt;
		}

		public DataTable SearchAddresses()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	sct.terminal_section_dsc, tadr.*,
					tadr.addr1 || NVL2(tadr.addr2, ', ', NULL) || tadr.addr2 ||
					NVL2(tadr.addr3, ', ', NULL) || tadr.addr3 ||
					NVL2(tadr.city, ', ', NULL) || tadr.city ||
					NVL2(tadr.state_prov_cd, ', ', NULL) || tadr.state_prov_cd ||
					NVL2(tadr.postal_cd, ', ', NULL) || tadr.postal_cd ||
					NVL2(tadr.country_cd, ', ', NULL) || tadr.country_cd AS addr_one_line
			FROM	r_terminal_address tadr
				INNER JOIN r_terminal trm			ON trm.terminal_cd = tadr.terminal_cd
				INNER JOIN r_terminal_section sct	ON sct.terminal_section_cd = tadr.terminal_section_cd
			");

			AppendWhere(sb, p, false);

			sb.Append(@"
			order by	trm.terminal_cd, sct.terminal_section_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Address";
			}
			return dt;
		}

		public DataTable SearchContacts()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	sct.terminal_section_dsc, tct.*
			FROM	r_terminal_contact tct
				INNER JOIN r_terminal trm			ON trm.terminal_cd = tct.terminal_cd
				INNER JOIN r_terminal_section sct	ON sct.terminal_section_cd = tct.terminal_section_cd
			");

			AppendWhere(sb, p, false);

			sb.Append(@"
			order by	trm.terminal_cd, sct.terminal_section_dsc, tct.sequence_nbr ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Contact";
			}
			return dt;
		}

		public DataTable SearchLinks()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	sct.terminal_section_dsc, tlk.*
			FROM	r_terminal_link tlk
				INNER JOIN r_terminal trm			ON trm.terminal_cd = tlk.terminal_cd
				INNER JOIN r_terminal_section sct	ON sct.terminal_section_cd = tlk.terminal_section_cd
			");

			AppendWhere(sb, p, false);

			sb.Append(@"
			order by	trm.terminal_cd, sct.terminal_section_dsc, tlk.sequence_nbr ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Link";
			}
			return dt;
		}

		public void AppendWhere(StringBuilder sb, List<DbParameter> p, bool isParent)
		{
			Connection.AppendInClause(sb, p, "AND",
				"trm.location_cd", "@LOC_CD", ClsConvert.AddQuotes(Port_CDs));

			if (isParent)
			{
			}
		}
		#endregion		// #region Search Methods
	}
}