using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUnitType
	{
		public struct Codes
		{
			public const string CFT = "CFT";
			public const string MTONs = "MTONS";
			public const string Pounds = "POUNDS";
			public const string DimWgt = "DIMWGT";
			public const string Days = "DAYS";
			public const string Miles = "MILES";

			public static bool IsCFT(string unitCd) { return unitCd == CFT; }
			public static bool IsMTONs(string unitCd) { return unitCd == MTONs; }
			public static bool IsPounds(string unitCd) { return unitCd == Pounds; }
			public static bool IsDimWgt(string unitCd) { return unitCd == DimWgt; }
			public static bool IsDays(string unitCd) { return unitCd == Days; }
			public static bool IsMiles(string unitCd) { return unitCd == Miles; }
		}

		#region Fields/Properties

		public bool IsCFT { get { return Codes.IsCFT(Unit_Type_Cd); } }
		public bool IsMTONs { get { return Codes.IsMTONs(Unit_Type_Cd); } }
		public bool IsPounds { get { return Codes.IsPounds(Unit_Type_Cd); } }
		public bool IsDimWgt { get { return Codes.IsDimWgt(Unit_Type_Cd); } }
		public bool IsDays { get { return Codes.IsDays(Unit_Type_Cd); } }
		public bool IsMiles { get { return Codes.IsMiles(Unit_Type_Cd); } }
		public bool IsDimensionBased { get { return IsCFT || IsMTONs || IsPounds || IsDimWgt; } }

		public bool RequiresUnits
		{
			get
			{	// If its null then, return true
				if (string.IsNullOrWhiteSpace(Units_Required_Flg)) return true;
				return ClsConvert.YNToBool(Units_Required_Flg);
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
			Units_Required_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1} Units Required {2} {3}Active", Unit_Type_Cd,
				Unit_Type_Dsc, Units_Required_Flg, (Active_Flg != "Y" ? "In" : null));
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
			if (string.IsNullOrEmpty(Unit_Type_Cd) == true)
				_Errors["Unit_Type_Cd"] = "Missing or invalid unit type code";
			if (string.IsNullOrEmpty(Unit_Type_Dsc) == true)
				_Errors["Unit_Type_Dsc"] = "Missing or invalid unit type description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
			if (!ClsConvert.ValidateYN(Units_Required_Flg))
				_Errors["Units_Required_Flg"] = "Missing or invalid Units Required Flag";
		}
		#endregion		// #region Validation
	}
}