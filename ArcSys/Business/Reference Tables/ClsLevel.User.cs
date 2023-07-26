using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLevel
	{
		public struct Codes
		{
			public const string ALL = "ALL";
			public const string PCFN = "PCFN";
			public const string ConveyanceCon = "CONVEY";
			public const string ConveyanceTrk = "TRUCK";
			public const string Convoy = "CONVOY";
			public const string TCN = "TCN";

			public static bool IsAll(string levCd) { return levCd == ALL; }
			public static bool IsPCFN(string levCd) { return levCd == PCFN; }
			public static bool IsConvoy(string levCd) { return levCd == Convoy; }
			public static bool IsTCN(string levCd) { return levCd == TCN; }
			public static bool IsConveyance(string levCd)
			{
				return (levCd == ConveyanceCon || levCd == ConveyanceTrk);
			}

			public static string LevelText(string s)
			{
				if (IsPCFN(s)) return "PCFNs";
				if (IsTCN(s)) return "TCNs";
				if (IsConveyance(s)) return "Trucks";
				if (IsConvoy(s)) return "Convoys";
				return "Count";
			}

			public static string PerLevelText(string s)
			{
				if (IsPCFN(s)) return "per PCFN";
				if (IsTCN(s)) return "per TCN";
				if (IsConveyance(s)) return "per Truck";
				if (IsConvoy(s)) return "per Convoy";
				return null;
			}
		}

		#region Fields/Properties

		public bool IsAll { get { return Codes.IsAll(Level_Cd); } }
		public bool IsPCFN { get { return Codes.IsPCFN(Level_Cd); } }
		public bool IsTCN { get { return Codes.IsTCN(Level_Cd); } }
		public bool IsConvoy { get { return Codes.IsConvoy(Level_Cd); } }
		public bool IsConveyance { get { return Codes.IsConveyance(Level_Cd); } }
		public string LevelText { get { return Codes.LevelText(Level_Cd); } }

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
			return string.Format("{0} - {1}", Level_Cd, Level_Dsc);
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
			if (string.IsNullOrEmpty(Level_Cd) == true)
				_Errors["Level_Cd"] = "Missing or invalid level code";
			if (string.IsNullOrEmpty(Level_Dsc) == true)
				_Errors["Level_Dsc"] = "Missing or invalid level description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}