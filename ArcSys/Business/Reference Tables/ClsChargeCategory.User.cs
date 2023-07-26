using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsChargeCategory
	{
		public struct Codes
		{
			public const string LineHaul = "LINEHAUL";

			public static bool IsLineHaul(string catCd) { return catCd == LineHaul; }
		}

		#region Fields/Properties

		public bool IsLineHaul { get { return Codes.IsLineHaul(Charge_Category_Cd); } }

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
			return string.Format("{0} - {1} {2}Active", Charge_Category_Cd, Charge_Category_Dsc,
				( Active_Flg != "Y" ? "In" : null ));
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
			if (string.IsNullOrEmpty(Charge_Category_Cd) == true)
				_Errors["Charge_Category_Cd"] = "Missing or invalid charge category code";
			if (string.IsNullOrEmpty(Charge_Category_Dsc) == true)
				_Errors["Charge_Category_Dsc"] = "Missing or invalid charge category description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}