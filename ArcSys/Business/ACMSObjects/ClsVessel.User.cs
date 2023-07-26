using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	partial class ClsVessel
	{
		#region Fields/Properties


		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Delete_Fl = "N";
		}

		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1}, Flag {2}, Ircs: {3}, {4}Active",
				Vessel_Cd, Vessel_Dsc, Flag, Ircs, (Delete_Fl == "Y" ? "In" : null));
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();
			if (VesselAlreadyExists())
				_Errors["Vessel_Cd"] = "Specified vessel code already exists";

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
			if (string.IsNullOrWhiteSpace(Vessel_Cd) == true)
				_Errors["Vessel_Cd"] = "Missing vessel code";
			if (string.IsNullOrWhiteSpace(Vessel_Dsc) == true)
				_Errors["Vessel_Dsc"] = "Missing vessel description";
			if (!ClsConvert.ValidateYN(Delete_Fl))
				_Errors["Delete_Fl"] = "Missing or invalid Delete flag";
		}

		private bool VesselAlreadyExists()
		{
			string vs = Vessel_Cd.NullTrim();
			if (string.IsNullOrWhiteSpace(vs)) return false;

			ClsVessel vess = ClsVessel.GetUsingKey(vs);
			return (vess != null);
		}
		#endregion		// #region Validation
	}

	#region Static Section

	partial class ClsVessel
	{
		public static DataTable GetAllVessels()
		{
			string sql = @"
			select a.* from v_vessel a
			ORDER BY	a.vessel_cd ";

			return Connection.GetDataTable(sql);
		}
	}
	#endregion		// #region Static Section
}