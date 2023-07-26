using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscOceanBb
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
			Oto_Flg = "N";
			Rate_Amt = 0;
			Rfp = "0012";
			Ocean_Type = "Ocean Breakbulk";
			Service = "USC-S";
			Container_Type = "(Not applicable)";
			Container_Size = "(Not applicable)";
			Unit_Type = "Measurement Ton";
		}

		protected override void OnReload()
		{
			_RateBasis = null;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3:c} {4} {5} {6} {7}",
				Usc_Ocean_Bb_ID, Origin, Destination, Rate_Amt, Route, Direction, Commodity,
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