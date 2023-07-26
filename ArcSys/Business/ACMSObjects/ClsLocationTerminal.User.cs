using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	partial class ClsLocationTerminal
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Delete_Fl = "N";
			Default_Fl = "N";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1}, Loc {2}, Default: {3}, Other Code: {4}, {5}Active",
				Terminal_Cd, Terminal_Dsc, Location_Cd, Default_Fl, Other1_Cd,
				(Delete_Fl == "Y" ? "In" : null));
		}
		#endregion		// #region ToString Overrides

		#region Properties
		public string MilStamp_Cd
		{
			get
			{
				// Either returns the terminal other1_cd or, if its null,
				// returns the location's other1_cd.
				if (!string.IsNullOrEmpty(this.Other1_Cd))
					return this.Other1_Cd;
				if (this.Location == null)
					return null;
				return Location.Other1_Cd;
			}
		}
		#endregion

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			if (!string.IsNullOrWhiteSpace(Terminal_Cd))
			{
				ClsLocationTerminal dup = GetUsingKey(Terminal_Cd);
				if (dup != null)
					_Errors["Terminal_Dup"] = Terminal_Cd + " already exists";
			}

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
			if (string.IsNullOrWhiteSpace(Terminal_Cd) == true)
				_Errors["Terminal_Cd"] = "Missing terminal code";
			if (string.IsNullOrWhiteSpace(Terminal_Dsc) == true)
				_Errors["Terminal_Dsc"] = "Missing terminal description";
			if (string.IsNullOrWhiteSpace(Location_Cd) == true)
				_Errors["Location_Cd"] = "Missing or invalid location code";
			if (!ClsConvert.ValidateYN(Delete_Fl))
				_Errors["Delete_Fl"] = "Missing or invalid Delete flag";
			if (!ClsConvert.ValidateYN(Default_Fl))
				_Errors["Default_Fl"] = "Missing or invalid Default flag";

			if (!string.IsNullOrWhiteSpace(Location_Cd) && string.Compare(Default_Fl, "Y", true) == 0 )
			{
				long defCount = CountDefaults(true);
				if (defCount > 0)
					_Errors["Default_Fl"] = "Another terminal is already marked as default";
			}
		}

		public long CountDefaults(bool excludeCurrent)
		{
			if (string.IsNullOrWhiteSpace(Location_Cd) ||
				string.Compare(Default_Fl, "Y", true) != 0) return 0;

			string sql = @"
			SELECT	COUNT('X')
			FROM	r_location_terminal term
			WHERE	term.location_cd = @LOC_CD
			AND		upper(term.default_fl) = 'Y' ";

			int paramCount = 1;
			if (excludeCurrent && !string.IsNullOrWhiteSpace(Terminal_Cd))
			{
				sql = sql + @"
			AND		term.terminal_cd <> @TERM_CD ";
				paramCount++;
			}

			DbParameter[] p = new DbParameter[paramCount];
			p[0] = Connection.GetParameter("@LOC_CD", Location_Cd);
			if (excludeCurrent && !string.IsNullOrWhiteSpace(Terminal_Cd))
				p[1] = Connection.GetParameter("@TERM_CD", Terminal_Cd);

			object o = Connection.GetScalar(sql, p);
			long? count = ClsConvert.ToInt64Nullable(o);

			return count.GetValueOrDefault(0);
		}
		#endregion		// #region Validation
	}

	#region Static Section

	partial class ClsLocationTerminal
	{
		public static DataTable GetAllTerminals()
		{
			string sql = @"
			SELECT	term.*
			FROM	r_location_terminal term
			ORDER BY	term.location_cd, term.default_fl desc, term.terminal_cd ";

			return Connection.GetDataTable(sql);
		}
	}
	#endregion		// #region Static Section
}