using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMoveType
	{
		#region Fields/Properties

		public bool IsDoorInOnly
		{
			get { return Move_Type_Cd == "F5" || Move_Type_Cd == "F6"; }
		}

		public bool IsDoorOutOnly
		{
			get { return Move_Type_Cd == "F7" || Move_Type_Cd == "F8"; }
		}

		public bool IsDoorToDoor
		{
			get { return Move_Type_Cd == "F9"; }
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";

			Door_In_Flg = "Y";
			Door_Out_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1} {2}, In: {3} Out: {4}",
				Move_Type_Cd, Move_Type_Dsc, ClsConvert.YNToActiveInactive(Active_Flg), Door_In_Flg, Door_Out_Flg);
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
			if (string.IsNullOrEmpty(Move_Type_Cd) == true)
				_Errors["Move_Type_Cd"] = "Missing or invalid move type code";
			if (string.IsNullOrEmpty(Move_Type_Dsc) == true)
				_Errors["Move_Type_Dsc"] = "Missing or invalid move type description";
			if( !ClsConvert.ValidateYN(Door_In_Flg))
				_Errors["Door_In_Flg"] = "Missing or invalid Door-In flag";
			if (!ClsConvert.ValidateYN(Door_Out_Flg))
				_Errors["Door_Out_Flg"] = "Missing or invalid Door-Out flag";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}