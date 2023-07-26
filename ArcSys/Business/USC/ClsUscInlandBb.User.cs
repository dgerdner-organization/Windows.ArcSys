using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscInlandBb
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
			Service = "USC-S";
			Unit_Type = "Conveyance";
			Inland_Type = "Linehaul";
		}

		protected override void OnReload()
		{
			_RateBasis = null;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3:c} {4} {5} {6}",
				Usc_Inland_Bb_ID, Port, Point, Rate_Amt, Container, Commodity,
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

		public void RecomputeConveyanceType()
		{
			string fb_flg, dd_flg, o_flg;
			ClsUscMgr.ComputeConveyanceType(Container, Commodity, out fb_flg, out dd_flg, out o_flg);
			Flatbed_Flg = fb_flg;
			Double_Drop_Flg = dd_flg;
			Oog_Flg = o_flg;
		}
		#endregion		// #region Computed Columns
	}
}