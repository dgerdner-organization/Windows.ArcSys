using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using CS2010.Common;
using System.Data.Common;

namespace CS2010.CommonSecurity
{
	partial class ClsSecurityUser
	{
        private bool AdminDefined = false;
        private bool _IsAdmin;
        public bool IsAdmin
        {
            get
            {
                if (AdminDefined)
                    return _IsAdmin;
                ClsSecurityGroup grp = ClsSecurityGroup.GetUsingName("ADMIN");
                DataTable dt = ( grp != null ) ? ClsUserGroup.GetAll(this.User_ID, grp.Group_ID) : null;
                if (dt == null || dt.Rows.Count < 1)
                    _IsAdmin = false;
                else
                    _IsAdmin = true;
                AdminDefined = true;
                return _IsAdmin;
            }

        }

		private bool SuperDefined = false;
		private bool _IsSuper;
		public bool IsSuper
		{
			get
			{
				if( SuperDefined )
					return _IsSuper;
				ClsSecurityGroup grp = ClsSecurityGroup.GetUsingName("SUPER_USER");
				DataTable dt = ( grp != null ) ? ClsUserGroup.GetAll(this.User_ID, grp.Group_ID) : null;
				if( dt == null || dt.Rows.Count < 1 )
					_IsSuper = false;
				else
					_IsSuper = true;
				SuperDefined = true;
				return _IsSuper;
			}

		}
		private ClsSecurityGroup _DefaultGroup;
		public ClsSecurityGroup DefaultGroup
		{
			get
			{
				if (_DefaultGroup == null)
					_DefaultGroup = GetUserDefaultGroup();
				return _DefaultGroup;
			}
		}
		public static ClsSecurityUser GetUsingName(string name)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE USER_NM=@USER_NAME", TableName);

			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter("@USER_NAME", name);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsSecurityUser(dr);
		}

        public static List<ClsSecurityUser> GetUserList()
        {
            List<ClsSecurityUser> users = new List<ClsSecurityUser>();
            DataTable dt = GetAll();
            foreach (DataRow dr in dt.Rows)
            {
                ClsSecurityUser u = new ClsSecurityUser(dr);
                users.Add(u);
            }
            return users;
        }
        /// <summary>
        /// A list of all users that have not been assigned to a group
        /// </summary>
        /// <returns></returns>
        public static List<ClsSecurityUser> GetUnassignedUsers()
        {
            string sql = @"
                select * from SECURITY.r_security_user a
                 where not exists (
                 select * from r_user_group b 
                  where a.user_id = b.user_id)";
            return Connection.GetList<ClsSecurityUser>(sql);
        }

		public  List<ClsUserGroup> GetUserGroups()
		{
			ClsUserGroup.GetUserGroupList();
			string sql = string.Format(@"
				select * from r_user_group
                   where user_id = {0}
					order by priority_nbr", this.User_ID);
			DataTable dt = Connection.GetDataTable(sql);
			List<ClsUserGroup> _UserGroups = new List<ClsUserGroup>();
			foreach (DataRow drow in dt.Rows)
			{
				ClsUserGroup ug = new ClsUserGroup(drow);
				_UserGroups.Add(ug);
			}
			return _UserGroups;
		}

		public ClsSecurityGroup GetUserDefaultGroup()
		{
			List<ClsUserGroup> UserGroups = GetUserGroups();
			ClsUserGroup ug = UserGroups[0];
			return ug.Group;
		}
	}
}