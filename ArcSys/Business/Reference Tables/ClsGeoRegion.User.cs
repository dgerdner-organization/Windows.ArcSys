using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsGeoRegion
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
			return string.Format("{0} - {1} {2}Active", Geo_Region_Cd, Geo_Region_Dsc,
				(Active_Flg != "Y" ? "In" : null));
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
			if (string.IsNullOrEmpty(Geo_Region_Cd) == true)
				_Errors["Geo_Region_Cd"] = "Missing or invalid geographic region code";
			if (string.IsNullOrEmpty(Geo_Region_Dsc) == true)
				_Errors["Geo_Region_Dsc"] = "Missing or invalid geographic region description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}