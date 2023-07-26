using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoStatus
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} - {2} {3}", Sequence_Nbr, Cargo_Status_Cd,
				Cargo_Status_Dsc, ClsConvert.YNToActiveInactive(Active_Flg));
		}
		#endregion		// #region ToString Overrides

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
			if (string.IsNullOrEmpty(Cargo_Status_Cd) == true)
				_Errors["Cargo_Status_Cd"] = "Missing cargo status code";
			if (string.IsNullOrEmpty(Cargo_Status_Dsc) == true)
				_Errors["Cargo_Status_Dsc"] = "Missing cargo status description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}

	#region Static

	partial class ClsCargoStatus
	{
		public static DataTable GetStatuses()
		{
			string sql = "SELECT * FROM R_CARGO_STATUS ORDER BY sequence_nbr, cargo_status_cd";
			return Connection.GetDataTable(sql);
		}
	}
	#endregion		// #region Static
}