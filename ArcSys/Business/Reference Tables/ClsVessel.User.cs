using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVessel
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
			return string.Format("{0} - {1}, ARC: {2}, IRCS: {3}, HFO: {4} MDO: {5}, {6}Active",
				Vessel_Cd, Vessel_Nm, Arc_Flg, Ircs_Cd, Avg_Hfo_Per_Hr, Avg_Mdo_Per_Hr,
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
			if (string.IsNullOrEmpty(Vessel_Cd) == true)
				_Errors["Vessel_Cd"] = "Missing or invalid vessel code";
			if (string.IsNullOrEmpty(Vessel_Nm) == true)
				_Errors["Vessel_Nm"] = "Missing or invalid vessel name";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";

			if (!ClsConvert.ValidateYN(Arc_Flg))
				_Errors["Arc_Flg"] = "Missing or invalid ARC flag";

			if (Avg_Hfo_Per_Hr != null)
			{
				if (Avg_Hfo_Per_Hr < 0)
					_Errors["Avg_Hfo_Per_Hr"] = "Average HFO per hour must be greater than or equal to zero";
			}

			if (Avg_Mdo_Per_Hr != null)
			{
				if (Avg_Mdo_Per_Hr < 0)
					_Errors["Avg_Mdo_Per_Hr"] = "Average MDO per hour must be greater than or equal to zero";
			}
		}
		#endregion		// #region Validation

		#region Static Methods
		public static DataTable GetVoyages(int days)
		{
			// Get voyages that have sailed within the last "days" number of days
			string sql = string.Format(@"
				select voyage_cd, sail_dt,  voyage_cd || '-' || vessel_cd as voyage_dsc
				from mv_voyage
				 where sail_dt > sysdate - {0} ", days);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		#endregion
	}
}