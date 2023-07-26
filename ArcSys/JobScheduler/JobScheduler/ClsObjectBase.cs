using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.Common;

namespace JobScheduler
{
	public class ClsObjectBase
	{
		private static DbConnection connection
		{
			get
			{
				return Program.ArcSysConn;
			}
		}

		public static Object GetByPrimaryKey(string sql, Object obj)
		{
			DbCommand cmd = connection.CreateCommand();
			cmd.CommandText = sql;
			DbDataReader dr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(dr);
			if (dt == null)
				return null;
			if (dt.Rows.Count == 0)
				return null;
			DataRow drow = dt.Rows[0];
			LoadFromDataRow(drow, obj);
			return obj;
		}
		public static Object LoadFromDataRow(DataRow drow, Object p_obj)
		{
			LoadFromDROW(drow, p_obj);
			return p_obj;
		}
		public static DataTable GetAll(string sql)
		{
			DbCommand cmd = connection.CreateCommand();
			cmd.CommandText = sql;
			DbDataReader dr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(dr);
			return dt;
		}
		private static void LoadFromDROW( DataRow p_dr, Object p_object)
		{
			DataColumnCollection p_dcc = p_dr.Table.Columns;
			//This is used to do the reflection
			Type t = p_object.GetType();
			for (Int32 i = 0; i <= p_dcc.Count - 1; i++)
			{
				//Don't ask it just works
				try
				{
					//NOTE the datarow column names must match exactly 
					//(including case) to the object property names
					t.InvokeMember(p_dcc[i].ColumnName,
								  BindingFlags.SetProperty, null,
								  p_object,
								  new object[] { p_dr[p_dcc[i].ColumnName] });
				}
				catch (Exception ex)
				{
					//Usually you are getting here because a column 
					//doesn't exist or it is null
					if (ex.ToString() != null)
					{ }
				}
			};//for i
		}
	}
}
