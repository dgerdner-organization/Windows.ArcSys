using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsTerminalLink
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
				return string.Format("{0}{1}{2}{3}Link",
					Terminal_Cd, sep1, sec, sep2);
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public ClsTerminalLink(string sectionCd)
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
			try
			{
				return string.Format("{0} {1}: {2} {3} {4} (id{5})",
					Description, Sequence_Nbr, Link_Dsc, Link_Url,
					ClsConvert.YNToActiveInactive(Active_Flg), Terminal_Link_ID);
			}
			catch
			{
				return base.ToString();
			}
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
			if (string.IsNullOrEmpty(Terminal_Cd) == true)
				_Errors["Terminal_Cd"] = "Missing terminal code";
			if (string.IsNullOrEmpty(Terminal_Section_Cd) == true)
				_Errors["Terminal_Section_Cd"] = "Missing section";
			if( Sequence_Nbr.GetValueOrDefault(0) < 1 )
				_Errors["Sequence_Nbr"] = "Missing or invalid sequence number (must be > 0)";
			if (string.IsNullOrWhiteSpace(Link_Dsc))
				_Errors["Phone_Dsc"] = "Missing link description";
			if (string.IsNullOrWhiteSpace(Link_Url))
				_Errors["Link_Url"] = "Missing URL";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid active flag";
		}
		#endregion		// #region Validation
	}

	#region Static Methods/Properties of ClsTerminalLink

	partial class ClsTerminalLink
	{
		public static DataTable GetTerminalLinks(string termCD, string termSection)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	rtl.*
			FROM	R_TERMINAL_LINK rtl
			WHERE	rtl.TERMINAL_CD=@TERM_CD ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@TERM_CD", termCD));
			Connection.AppendInClause(sb, p, "AND", "rtl.terminal_section_cd", "@TRM_SECT", termSection);

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}
	}
	#endregion		// 	#region Static Methods/Properties of ClsTerminalLink
}