using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimateStatus
	{
		public struct Codes
		{
			public const string InComplete = "INCOMPLETE";
			public const string Complete = "COMPLETE";

			public static bool IsInComplete(string stCode) { return stCode == InComplete; }
			public static bool IsComplete(string stCode) { return stCode == Complete; }
		}

		#region Fields/Properties

		public bool IsInComplete { get { return Codes.IsInComplete(Estimate_Status_Cd); } }
		public bool IsComplete { get { return Codes.IsComplete(Estimate_Status_Cd); } }

		#endregion		// #region Fields/Properties

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
			return string.Format("{0} - {1}", Estimate_Status_Cd, Estimate_Status_Dsc);
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
			if (string.IsNullOrEmpty(Estimate_Status_Cd) == true)
				_Errors["Estimate_Status_Cd"] = "Missing or invalid status code";
			if (string.IsNullOrEmpty(Estimate_Status_Dsc) == true)
				_Errors["Estimate_Status_Dsc"] = "Missing or invalid status description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}