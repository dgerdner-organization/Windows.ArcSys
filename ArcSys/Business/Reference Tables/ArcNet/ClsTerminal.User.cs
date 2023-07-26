using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsTerminal
	{
		#region Fields/Properties

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

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
				return string.Format("{0}: {1} {2} {3}",
					Terminal_Cd, Terminal_Dsc, (Location != null ? Location.Location_Dsc : null),
					ClsConvert.YNToActiveInactive(Active_Flg));
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

			CommonValidation(true);

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation(false);

			return _Errors.Count == 0;
		}

		private void CommonValidation(bool checkTermDup)
		{
			if (string.IsNullOrEmpty(Terminal_Cd) == true)
				_Errors["Terminal_Cd"] = "Missing terminal code";
			else
			{
				if (checkTermDup)
				{
					ClsTerminal term = ClsTerminal.GetUsingKey(Terminal_Cd);
					if (term != null)
						_Errors["Terminal_Cd"] = Terminal_Cd + " terminal code already exists ";
				}
			}

			if (string.IsNullOrEmpty(Terminal_Dsc) == true)
				_Errors["Terminal_Dsc"] = "Missing terminal description";
			if (string.IsNullOrWhiteSpace(Location_Cd))
				_Errors["Location_Cd"] = "Missing port";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid active flag";
		}
		#endregion		// #region Validation
	}

	#region Static Methods/Properties of ClsTerminal

	partial class ClsTerminal
	{
		public static DataTable GetTerminals(string locCd)
		{
			string sql = @"
			SELECT	rt.*
			FROM	R_TERMINAL rt
			WHERE	rt.LOCATION_CD=@LOC_CD ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@LOC_CD", locCd);

			return Connection.GetDataTable(sql, p);
		}
	}
	#endregion		// 	#region Static Methods/Properties of ClsTerminal
}