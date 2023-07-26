using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	partial class ClsSecurityObject
	{
        public void RenameObject(string newName)
        {
            if (newName == null || newName.Length < 1)
                throw new Exception("New Name Was Not Supplied");
            bool inTrans = Connection.IsInTransaction;
            if (!inTrans)
                Connection.TransactionBegin();
            try
            {
                Object_Nm = newName;
                Update();
                if (!inTrans)
                    Connection.TransactionCommit();
            }
            catch
            {
                if (!inTrans)
                    Connection.TransactionRollback();
                throw;
            }        
        }

		#region Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} ({2}) {3}",
				Object_ID, Parent_Nm, Collection_Dsc, Object_Nm);
		}

        public override void SetDefaults()
        {
            base.SetDefaults();
            this.Finance_Flg = "N";
            this.Vendor_Control_Flg = "N";
         }
		#endregion		// #region Overrides
	}

	#region Static Methods/Properties of ClsSecurityObject

	partial class ClsSecurityObject
	{
		#region Public Methods

		public static void DeleteObject(ClsSecurityObject obj)
		{
			bool inTrans = Connection.IsInTransaction;
			if( !inTrans )
				Connection.TransactionBegin();
			try
			{
				DataTable dt = ClsSecurity.GetSecurityForObject((long)obj.Object_ID);
				foreach( DataRow dr in dt.Rows )
				{
					ClsSecurity s = new ClsSecurity(dr);
					s.Delete();
				}
				obj.Delete();
				if( !inTrans )
					Connection.TransactionCommit();
			}
			catch
			{
				if( !inTrans )
					Connection.TransactionRollback();
				throw;
			}
		}

		public static DataTable GetDistinctForms()
		{
			return Connection.GetDataTable
				("SELECT DISTINCT Parent_Nm, Parent_Dsc FROM SECURITY.R_SECURITY_OBJECT");
		}

		public static List<ClsSecurityObject> GetAllList()
		{
			List<ClsSecurityObject> objects = new List<ClsSecurityObject>();
			DataTable dt = GetAll();
			foreach( DataRow dr in dt.Rows )
			{
				ClsSecurityObject obj = new ClsSecurityObject(dr);
				objects.Add(obj);
			}
			return objects;
		}

		public static ClsSecurityObject GetObject(string parentName,
			string objectName)
		{
			string sql = string.Format(
				" SELECT * FROM {0} " +
				" WHERE Parent_Nm=@ParentName AND Object_Nm=@ObjectName",
				TableName);

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@ParentName", parentName);
			p[1] = Connection.GetParameter("@ObjectName", objectName);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsSecurityObject(dr);
		}

		public static DataTable GetObjects(string parentName)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE Parent_Nm=@ParentName", TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ParentName", parentName);

			return Connection.GetDataTable(sql, p);
		}

		public static List<ClsSecurityObject> GetObjects(string parentNm,
			string objectNm, string collectionNm)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	so.*
			FROM	SECURITY.R_SECURITY_OBJECT so
			WHERE	so.PARENT_NM = @PAR_NM AND so.Object_Nm = @OBJ_NM ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@PAR_NM", parentNm));
			p.Add(Connection.GetParameter("@OBJ_NM", objectNm));
			Connection.AppendEqualClause(sb, p, "AND",
				"so.COLLECTION_DSC", "@COLL_NM", collectionNm);

			return Connection.GetList<ClsSecurityObject>(sb.ToString(), p.ToArray());
		}

		public static DataTable GetDistinctParents()
		{
			string sql = @"
                    select parent_nm, parent_dsc from security.r_security_object t
                     group by parent_nm, parent_dsc
                     order by parent_nm ";
			return Connection.GetDataTable(sql);
		}

		public static string GetParentDesc(string parentName)
		{
			string sql =
				" SELECT Max(Parent_Dsc) " +
				" FROM SECURITY.R_SECURITY_OBJECT WHERE Parent_Nm=@ParentName ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ParentName", parentName);

			return ClsConvert.ToString(Connection.GetScalar(sql, p));
		}

		public static int UpdateParentDsc(string parentName, string newDesc)
		{
			bool inTrans = Connection.IsInTransaction;
			if( !inTrans )
				Connection.TransactionBegin();
			try
			{
				string sql =
					" UPDATE SECURITY.R_SECURITY_OBJECT SET Parent_Dsc=@ParentDesc " +
					" WHERE Parent_Nm=@ParentName";

				DbParameter[] p = new DbParameter[2];
				p[0] = Connection.GetParameter("@ParentDesc", newDesc);
				p[1] = Connection.GetParameter("@ParentName", parentName);
				if( !inTrans )
					Connection.TransactionCommit();
				return Connection.RunSQL(sql, p);
			}
			catch
			{
				if( !inTrans )
					Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsSecurityObject
}