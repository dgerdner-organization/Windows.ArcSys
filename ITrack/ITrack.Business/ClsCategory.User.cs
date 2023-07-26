using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsCategory
	{
		#region Overrides

		public override void SetDefaults()
		{
			Active_Flg = "Y";
		}

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

		public override string ToString()
		{
			return string.Format("{0} - {1}", Category_Cd, Category_Nm);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(Category_Cd) == true )
				_Errors["Category_Cd"] = "Missing category";
			if( string.IsNullOrEmpty(Category_Nm) == true )
				_Errors["Category_Nm"] = "Missing category name";
		}
		#endregion		// #region Helper Methods
	}

	#region Static Methods/Properties of ClsCategory

	partial class ClsCategory
	{
		#region Public Methods

		public static ClsCategory GetUsingCategoryNm(string categoryNm)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(CATEGORY_NM)=UPPER(@CATEGORY_NM)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CATEGORY_NM", categoryNm);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsCategory(dr);
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsCategory
}