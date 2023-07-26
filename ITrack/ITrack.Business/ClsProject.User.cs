using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsProject
	{
		#region Overrides

		public override void SetDefaults()
		{
			Active_Flg = "Y";
			Dev_Only_Flg = "N";
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
			return string.Format("{0} - {1}", Project_Cd, Project_Nm);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(Project_Cd) == true )
				_Errors["Project_Cd"] = "Missing project";
			if( string.IsNullOrEmpty(Project_Nm) == true )
				_Errors["Project_Nm"] = "Missing project name";
			if( string.IsNullOrEmpty(Next_Version_No) == true )
				_Errors["Next_Version_No"] = "Missing version";
		}
		#endregion		// #region Helper Methods
	}

	#region Static Methods/Properties of ClsProject

	partial class ClsProject
	{
		#region Public Methods

		public static ClsProject GetUsingProjectNm(string projectNm)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(PROJECT_NM)=UPPER(@PROJECT_NM)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@PROJECT_NM", projectNm);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsProject(dr);
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsProject
}