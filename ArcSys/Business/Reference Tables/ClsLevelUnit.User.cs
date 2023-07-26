using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLevelUnit
	{
		#region Fields/Properties

		public bool IsAll { get { return (Level != null) ? Level.IsAll : false; } }
		public bool IsPCFN { get { return (Level != null) ? Level.IsPCFN : false; } }
		public bool IsTCN { get { return (Level != null) ? Level.IsTCN : false; } }
		public bool IsConvoy { get { return (Level != null) ? Level.IsConvoy : false; } }
		public bool IsConveyance { get { return (Level != null) ? Level.IsConveyance : false; } }

		public bool RequiresUnits { get { return (Unit_Type != null) ? Unit_Type.RequiresUnits : true; } }
		public bool IsCFT { get { return (Unit_Type != null) ? Unit_Type.IsCFT : true; } }
		public bool IsMTONs { get { return (Unit_Type != null) ? Unit_Type.IsMTONs : true; } }
		public bool IsPounds { get { return (Unit_Type != null) ? Unit_Type.IsPounds : true; } }

		public bool IsAverage { get { return Average_Flg == null || ClsConvert.YNToBool(Average_Flg); } }

		public string CargoAttributeColName { get { return (Unit_Type != null) ? Unit_Type.Db_Column_Nm : null; } }

		/// <summary>This determines whether we will compute the exact amount for a TCN and
		/// consequently default the Level_Count field to 1 (essentially ignoring it). This is
		/// similar to the Units_Required_Flg and the Unit_Qty field. When required is N we
		/// default Unit_Qty to 1.</summary>
		public bool IsComputeExact
		{
			get
			{	// If we are averaging the TCN amount, we don't need the exact amount, return false
				if (IsAverage) return false;
				// If we are here, we want the exact TCN amount, but the only way we can do that is
				// if we know which cargo attribute the amount is based on.
				// So if CargoAttributeColName is blank, we cannot compute exact, return false
				if (string.IsNullOrWhiteSpace(CargoAttributeColName)) return false;

				return true;	// Not an average and we have the attribute column name, return true
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			_Active_Flg = "Y";
			_Average_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}-{3}",
				Level_Unit_ID, Level_Unit_Dsc, Level_Cd, Unit_Type_Cd);
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
			if (string.IsNullOrEmpty(Level_Unit_Dsc) == true)
				_Errors["Level_Unit_Dsc"] = "Missing or invalid description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}
}