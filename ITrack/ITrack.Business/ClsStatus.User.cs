using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsStatus
	{
		#region Overrides

		public override void SetDefaults()
		{
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
			return string.Format("{0} - {1}", Status_Cd, Status_Dsc);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(Status_Cd) == true )
				_Errors["Status_Cd"] = "Missing status";
			if( string.IsNullOrEmpty(Status_Dsc) == true )
				_Errors["Status_Dsc"] = "Missing status description";
		}
		#endregion		// #region Helper Methods
	}

	#region Static Methods/Properties of ClsStatus

	partial class ClsStatus
	{
		#region Public Methods

		public static ClsStatus GetUsingStatusDsc(string statusDsc)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(STATUS_DSC)=UPPER(@STATUS_DSC)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@STATUS_DSC", statusDsc);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsStatus(dr);
		}

		public static List<ClsStatus> GetAllStatuses()
		{
			return Connection.GetList<ClsStatus>("SELECT * FROM R_STATUS");
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsStatus
}