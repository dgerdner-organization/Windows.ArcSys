using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsTerminalAddress
	{
		#region Fields/Properties

		public string Section_Dsc
		{
			get { return (Terminal_Section != null) ? Terminal_Section.Terminal_Section_Dsc : null; }
		}

		public string Description
		{
			get
			{
				string sec = Section_Dsc;
				bool blankTerm = string.IsNullOrWhiteSpace(Terminal_Cd),
					blankSec = string.IsNullOrWhiteSpace(sec);
				string sep1 = (!blankTerm && !blankSec) ? " " : null;
				string sep2 = (!blankTerm || !blankSec) ? " " : null;
				return string.Format("{0}{1}{2}{3}Address",
					Terminal_Cd, sep1, sec, sep2);
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public ClsTerminalAddress(string sectionCd)
		{
			ResetColumns();
			SetDefaults();
			Terminal_Section_Cd = sectionCd;
		}

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString

		public override string ToString()
		{
			try { return string.Format("{0} {1}", Description, AddressBoxExtra()); }
			catch { return null; }
		}
		#endregion		// #region ToString

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			string s = null;
			if (string.IsNullOrEmpty(Terminal_Section_Cd) == true)
				_Errors["Terminal_Section_Cd"] = "Missing section";
			else
				s = Description;

			StringBuilder sb = new StringBuilder();
			if (Address.ValidateAddress(this, sb) == false)
				_Errors["Address"] = string.Format("{0}\r\n{1}", s, sb.ToString());
		}
		#endregion		// #region Validation

		#region Helper Methods

		public string AddressBox()
		{
			return GetAddress(true, false);
		}

		public string AddressBoxExtra()
		{
			bool blankDsc = string.IsNullOrWhiteSpace(Contact_Dsc),
				blankNm = string.IsNullOrWhiteSpace(Contact_Nm);
			string sep1 = (!blankDsc && !blankNm) ? " " : null;
			return string.Format("{0}\r\n{1}{2}{3}{4}", Addressee_Nm, GetAddress(true, false),
				Contact_Dsc, sep1, Contact_Nm);
		}

		public bool Equals(ClsTerminalAddress taddr)
		{
			try
			{
				if (taddr == null) return false;
				if (Object.ReferenceEquals(this, taddr)) return true;

				if (taddr.Terminal_Address_ID != this.Terminal_Address_ID) return false;

				if (
					string.Compare(taddr.Terminal_Cd, this.Terminal_Cd, false) != 0 ||
					string.Compare(taddr.Terminal_Section_Cd, this.Terminal_Section_Cd, false) != 0 ||
					string.Compare(taddr.Addressee_Nm, this.Addressee_Nm, false) != 0 ||
					string.Compare(taddr.Addr1, this.Addr1, false) != 0 ||
					string.Compare(taddr.Addr2, this.Addr2, false) != 0 ||
					string.Compare(taddr.Addr3, this.Addr3, false) != 0 ||
					string.Compare(taddr.City, this.City, false) != 0 ||
					string.Compare(taddr.State_Prov_Cd, this.State_Prov_Cd, false) != 0 ||
					string.Compare(taddr.Postal_Cd, this.Postal_Cd, false) != 0 ||
					string.Compare(taddr.Country_Cd, this.Country_Cd, false) != 0 ||
					string.Compare(taddr.Active_Flg, this.Active_Flg, false) != 0) return false;

				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		#endregion		// #region Helper Methods

		#region Save

		public bool SaveAddress()
		{
			if (Terminal_Address_ID == null)
			{
				if (!ValidateInsert()) return false;
				Insert();
			}
			else
			{
				if (!ValidateUpdate()) return false;
				Update();
			}
			return true;
		}
		#endregion		// #region Save
	}

	#region Static Methods/Properties of ClsTerminalAddress

	partial class ClsTerminalAddress
	{
		public static ClsTerminalAddress GetAddress(string termCD, string termSection)
		{
			string sql = @"
			SELECT	*
			FROM	R_TERMINAL_ADDRESS
			WHERE	TERMINAL_CD=@TERM_CD AND TERMINAL_SECTION_CD=@TRM_SEC";

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@TERM_CD", termCD);
			p[1] = Connection.GetParameter("@TRM_SEC", termSection);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr == null) ? null : new ClsTerminalAddress(dr);
		}

		public static List<ClsTerminalAddress> GetAddressesBySection(string termSection)
		{
			string sql = @"
			SELECT	*
			FROM	R_TERMINAL_ADDRESS
			WHERE	TERMINAL_SECTION_CD=@TRM_SEC";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@TRM_SEC", termSection);

			return Connection.GetList<ClsTerminalAddress>(sql, p);
		}

		public static DataTable GetTerminalAddresses(string termCD)
		{
			string sql = @"
			SELECT	*
			FROM	R_TERMINAL_ADDRESS
			WHERE	TERMINAL_CD=@TERM_CD ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@TERM_CD", termCD);

			return Connection.GetDataTable(sql, p);
		}

		public static List<ClsTerminalAddress> GetAddressList(string termCD)
		{
			List<ClsTerminalAddress> lst = new List<ClsTerminalAddress>();
			DataTable dt = GetTerminalAddresses(termCD);
			if (dt != null)
				foreach (DataRow dr in dt.Rows)
					lst.Add(new ClsTerminalAddress(dr));
			return lst;
		}
	}
	#endregion		// #region Static Methods/Properties of ClsTerminalAddress
}