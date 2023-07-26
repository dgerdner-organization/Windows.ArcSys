using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	public partial class ClsSecurity
	{
		public static ClsSecurity GetUsingFK(long Group_ID, long Object_ID)
		{
			DataTable dt = GetAll(Group_ID, Object_ID);
			if( dt == null || dt.Rows.Count <= 0 ) return null;
			return new ClsSecurity(dt.Rows[0]);
		}

        /// <summary>
        /// Returns the security object for the user and application object 
        /// </summary>
        /// <param name="user_nm">The user login</param>
        /// <param name="object_dsc">The application object</param>
        /// <returns></returns>
        public static ClsSecurity GetUsingFKAlt(string user_nm, string object_dsc)
        {
            try
            {
                string sql = @"Select s.*
                                from r_security s
                                where 1=1
                                    and s.object_id = (Select so.object_id from r_security_object so where so.object_dsc = @OBJECT_DSC)
                                    and s.group_id = (Select ug.group_id 
                                                     from r_user_group ug 
                                                     where ug.user_id = (Select su.user_id 
                                                        from r_security_user su 
                                                        where su.user_nm = @USER_NM))";
                DbParameter[] p = new DbParameter[2];
                p[0] = Connection.GetParameter("@OBJECT_DSC", object_dsc.Trim());
                p[1] = Connection.GetParameter("@USER_NM", user_nm.Trim());

                DataRow dr = Connection.GetDataRow(sql, p);

                return new ClsSecurity(dr);
            }
            catch 
            {
                return null;
            }
        }


        public const string ExtendedSelect =
            @"  SELECT * FROM SECURITY.R_SECURITY  R_SECURITY INNER JOIN SECURITY.R_USER_GROUP  R_USER_GROUP
                 ON R_SECURITY.Group_ID = 
                 R_USER_GROUP.Group_ID  
                 INNER JOIN SECURITY.R_SECURITY_OBJECT R_SECURITY_OBJECT
                  ON R_SECURITY.Object_ID = R_SECURITY_OBJECT.Object_ID  
                  INNER JOIN SECURITY.R_SECURITY_GROUP R_GROUP  ON R_SECURITY.Group_ID = R_GROUP.Group_ID  
                  AND R_USER_GROUP.Group_ID = R_GROUP.Group_ID ";

		public static DataTable GetSecurityForUserObject(long userID, string ObjectName)
		{
			string sql = string.Format
				("{0} where user_id = {1} and object_nm = '{2}'  and r_security.visible_flg = 'Y' ",
				   ExtendedSelect, userID, ObjectName);
			return Connection.GetDataTable(sql);
		}

		public static DataTable GetSecurityForUser(long userID, string parentName)
		{
			string sql = string.Format
				("{0} WHERE User_ID = @userID AND Parent_Nm=@ParentName",
				ExtendedSelect);

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@userID", userID);
			p[1] = Connection.GetParameter("@ParentName", parentName);

			return Connection.GetDataTable(sql, p);
		}

		public static DataTable GetSecurityForObject(long objID)
		{
            //string sql =
            //    string.Format("{0} WHERE Object_ID = @objID", ExtendedSelect);

            //DbParameter[] p = new DbParameter[1];
            //p[0] = Connection.GetParameter("@objID", objID);
            string sql = @"select * from security.r_security
                            where object_id = @OBJID";
            sql = sql.Replace("@OBJID", objID.ToString());
			return Connection.GetDataTable(sql);
		}

        public static List<ClsSecurity> GetAllList()
        {
            DataTable dt = ClsSecurity.GetAll();
            List<ClsSecurity> list = new List<ClsSecurity>();
            foreach (DataRow dr in dt.Rows)
            {
                ClsSecurity s = new ClsSecurity(dr);
                list.Add(s);
            }
            return list;
        }

        public static List<ClsSecurity> GetSecurityForGroup(long groupID)
        {
            string sql = string.Format
                ("{0} WHERE Group_ID = @groupID",
                ExtendedSelect);

            DbParameter[] p = new DbParameter[1];
            p[0] = Connection.GetParameter("@groupID", groupID);

            return Connection.GetList<ClsSecurity>(sql, p);
        }

        public static List<ClsSecurity> GetSecurityForGroupSimple(long groupID)
        {
            // This one does no joins, just gets all security objects for a group
            string sql = string.Format(
                        @"select * from SECURITY.r_security a
                           where a.group_id = {0} ", groupID);
            return Connection.GetList<ClsSecurity>(sql);
        }

		public static Dictionary<string, bool> GetObjectVisibility(string parent_nm, string obj_nms)
		{
			StringBuilder sb = new StringBuilder(@"
			select obj.object_nm, sec.visible_flg
			from r_user_group ug
				inner join SECURITY.r_security sec on sec.group_id = ug.group_id
				inner join SECURITY.r_security_object obj on obj.object_id = sec.object_id
			where ug.user_id = @USER_ID and lower(obj.parent_nm) = lower(@PARENT_NM)
				and lower(obj.object_nm) in (@OBJ_NM)");

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@USER_ID", ClsEnvironment.User_Id.Value);
			p[1] = Connection.GetParameter("@PARENT_NM", parent_nm.ToLower());

			sb.Replace("@OBJ_NM", obj_nms.ToLower());

			Dictionary<string, bool> lst = new Dictionary<string, bool>();
			DataTable dt = Connection.GetDataTable(sb.ToString(), p);
			if( dt != null && dt.Rows.Count > 0 )
			{
				foreach( DataRow dr in dt.Rows )
				{
					string key = ClsConvert.ToString(dr["OBJECT_NM"]);
					string ynVal = ClsConvert.ToString(dr["VISIBLE_FLG"]);
					lst.Add(key.ToLower(), ClsConvert.YNToBool(ynVal));
				}
			}
			return lst;
		}

		public static void SetSecurityDefault(ClsSecurityObject objSO)
		{
			string SQL = @"
				Insert into SECURITY.r_security
					Select 
						security_id_seq.nextval,
						sg.group_id,
						@SECURITY_OBJECT,
						1,
						user,
						sysdate,
						user,
						sysdate,
						'N',
						'N'
						from SECURITY.r_security_group sg
			";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@SECURITY_OBJECT", objSO.Object_ID);

			Connection.RunSQL(SQL, p);

		}
	}
}