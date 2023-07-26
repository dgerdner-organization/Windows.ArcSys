using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsGroup
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
			return string.Format("{0} - {1}", Group_Cd, Group_Dsc);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(Group_Cd) == true )
				_Errors["Group_Cd"] = "Missing group";
			if( string.IsNullOrEmpty(Group_Dsc) == true )
				_Errors["Group_Dsc"] = "Missing group name";
		}
		#endregion		// #region Helper Methods
	}

	#region Static Methods/Properties of ClsGroup

	partial class ClsGroup
	{
		#region Public Methods

		public static ClsGroup GetUsingGroupDsc(string groupDsc)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(Group_Dsc)=UPPER(@GroupDsc)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@GroupDsc", groupDsc);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsGroup(dr);
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsGroup
}