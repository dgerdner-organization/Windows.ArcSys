using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscOceanRoute
	{
		#region Fields/Properties

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
			Carrier_Cd = "AROF";
			Oto_Flg = "N";
			Rate_Amt = 0;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3:c} {4} {5} {6}",
				Usc_Ocean_Route_ID, Route, From_To, Rate_Amt, Commodity, Rate_Type,
				ClsConvert.YNToActiveInactive(Active_Flg));
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
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
			if (!ClsConvert.ValidateYN(Oto_Flg))
				_Errors["Oto_Flg"] = "Missing or invalid OTO flag";
		}
		#endregion		// #region Validation

		#region Computed Columns

		#endregion		// #region Computed Columns
	}
}