using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	partial class ClsUserGroup
	{
		public static ClsUserGroup GetUsingFK(long? User_ID, long? Group_ID)
		{
			DataTable dt = GetAll(User_ID, Group_ID);
			if( dt == null || dt.Rows.Count <= 0 ) return null;
			return new ClsUserGroup(dt.Rows[0]);
		}

		public static int CountUsersInGroup(long? grpID)
		{
			string sql =
				"SELECT Count(*) FROM R_USER_GROUP WHERE Group_ID=@GroupID";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@GroupID", grpID);

			return ClsConvert.ToInt32(Connection.GetScalar(sql, p));
		}
        public static List<ClsUserGroup> GetUserGroupList()
        {
            List<ClsUserGroup> users = new List<ClsUserGroup>();
            DataTable dt = GetAll(true);
            foreach (DataRow dr in dt.Rows)
            {
                ClsUserGroup u = new ClsUserGroup(dr);
                users.Add(u);
            }
            return users;
        }

        public static ClsUserGroup CloneUserGroup(ClsUserGroup ug)
        {
            ClsUserGroup newUG = new ClsUserGroup();
            newUG.CopyFrom(ug);
            newUG._User_Group_ID = null;
            newUG.Insert();
            return newUG;
        }
	}
}