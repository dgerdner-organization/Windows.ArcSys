using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsFinance
	{
		public struct Codes
		{
			public const string AP = "AP";
			public const string AR = "AR";

			public static bool IsAP(string finCd) { return finCd == AP; }
			public static bool IsAR(string finCd) { return finCd == AR; }
			public static bool IsValid(string finCd)
			{
				return IsAP(finCd) || IsAR(finCd);
			}

			public static string ToText(string finCd, byte mode)
			{
				string txt = null;
				switch (finCd)
				{
					case AP: txt = "Cost"; break;
					case AR: txt = "Revenue"; break;
					default: txt = "Invalid"; break;
				}

				switch (mode)
				{
					case 1: return txt;

					case 0:
					default:
						return string.Format("{0} {1}", finCd, txt);
				}
			}
		}

		#region Fields/Properties

		public bool IsAP { get { return Codes.IsAP(Finance_Cd); } }
		public bool IsAR { get { return Codes.IsAR(Finance_Cd); } }
		public bool IsCodeValid { get { return Codes.IsValid(Finance_Cd); } }
		public string FinanceText { get { return Codes.ToText(Finance_Cd, 0); } }

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
			return string.Format("{0} - {1}", Finance_Cd, Finance_Dsc);
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
			if (string.IsNullOrEmpty(Finance_Cd) == true)
				_Errors["Finance_Cd"] = "Missing finance code";
			else if( !IsCodeValid )
				_Errors["Finance_Cd"] = "Invalid finance code";
			if (string.IsNullOrEmpty(Finance_Dsc) == true)
				_Errors["Finance_Dsc"] = "Missing or invalid finance description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}