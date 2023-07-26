using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsChargeType
	{
		#region Fields/Properties

		public bool IsLineHaul
		{
			get { return ClsChargeCategory.Codes.IsLineHaul(Charge_Category_Cd); }
		}
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
			return string.Format("{0} - {1} {2}Active, Category {3}", Charge_Type_Cd, Charge_Type_Dsc,
				( Active_Flg != "Y" ? "In" : null ), Charge_Category_Cd);
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
			if (string.IsNullOrEmpty(Charge_Type_Cd) == true)
				_Errors["Charge_Type_Cd"] = "Missing or invalid charge type code";
			if (string.IsNullOrEmpty(Charge_Type_Dsc) == true)
				_Errors["Charge_Type_Dsc"] = "Missing or invalid charge type description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation
	}

	#region Static Methods of ClsChargeType

	partial class ClsChargeType
	{
		public static DataTable GetAllCharges(string catCd)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	cht.*, aplu.level_unit_dsc AS ap_def_dsc, arlu.level_unit_dsc AS ar_def_dsc
			FROM	r_charge_type cht
				LEFT OUTER JOIN r_level_unit aplu ON aplu.level_unit_id = cht.ap_level_unit_id
				LEFT OUTER JOIN r_level_unit arlu ON arlu.level_unit_id = cht.ar_level_unit_id
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendLikeClause(sb, p, "AND", "cht.charge_category_cd", "@CAT_CD", catCd);

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}
	}
	#endregion		// #region Static Methods of ClsChargeType
}