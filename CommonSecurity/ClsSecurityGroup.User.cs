using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CS2010.CommonSecurity
{
	partial class ClsSecurityGroup
	{
        public void ClearGroupSecurity()
        {
            // Sets all objects invisible for this group
            bool bInTrans = Connection.IsInTransaction;

            if (!bInTrans)
                Connection.TransactionBegin();
            try
            {
                List<ClsSecurity> lst = ClsSecurity.GetSecurityForGroupSimple((long)this._Group_ID);
                foreach (ClsSecurity sec in lst)
                {
                    if (sec.Visible_Flg == "Y")
                    {
                        sec.Visible_Flg = "N";
                        sec.Update();
                    }
                }
                if (!bInTrans)
                    Connection.TransactionCommit();
            }
            catch (Exception ex)
            {
                if (!bInTrans)
                    Connection.TransactionRollback();
                throw ex;
            }
        }

		public static ClsSecurityGroup GetUsingName(string groupName)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE Group_Dsc=@GroupDsc", TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@GroupDsc", groupName);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsSecurityGroup(dr);
		}

        public static List<ClsSecurityGroup> GetGroupByUser(string userName)
        {
            string sql = @"
                     
                select g.* from SECURITY.r_user_group ug, SECURITY.r_security_user u, SECURITY.r_security_group g
                 where u.user_id = ug.user_id   
                   and g.group_id = ug.group_id
                   and user_nm = '@USER'";
            sql = sql.Replace("@USER", userName);

            List<ClsSecurityGroup> gList = Connection.GetList<ClsSecurityGroup>(sql);
            return gList;
        }

        public static List<ClsSecurityGroup> GetGroupList()
        {
            List<ClsSecurityGroup> groups = new List<ClsSecurityGroup>();
            DataTable dt = GetAll();
            foreach (DataRow dr in dt.Rows)
            {
                ClsSecurityGroup g = new ClsSecurityGroup(dr);
                groups.Add(g);
            }
            return groups;
        }
	}
}