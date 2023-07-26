using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscAssessorial
	{
		#region Fields/Properties

		private ClsLevelUnit _RateBasis;
		public ClsLevelUnit RateBasis
		{
			get
			{
				if (_RateBasis == null) _RateBasis = ClsUscMgr.ComputeRateBasis(Unit_Type);
				return _RateBasis;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
			Carrier_Cd = "AROF";
			Container_Size = "(Not applicable)";
			Container_Type = "(Not applicable)";
			Oto_Flg = "N";
			Rate_Amt = 0;
			Rfp = "0012";
			Route = "00 - (Not applicable)";
			Service = "USC-S";
		}

		protected override void OnReload()
		{
			_RateBasis = null;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3} {4:c} {5}",
				Usc_Assessorial_ID, Assessorial_Type, Origin, Destination, Rate_Amt,
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
	}
}