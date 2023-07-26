using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUser
    {
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2}", User_Login, First_Nm, Last_Nm);
		}
		#endregion		// #region ToString Overrides

		#region Fields/Properties

		public string Full_Nm { get { return First_Nm + " " + Last_Nm; } }

		public DateTime LocalDate
		{
			get
			{
				//string s_sql = "select PKG_ARCSYS_UTILITY.F_GET_LOCAL_TIME('@LOGIN') from dual";
				//s_sql = s_sql.Replace("@LOGIN", User_Login);
				//object result = Connection.GetScalar(s_sql, System.Data.CommandType.Text);
				//DateTime? local_date = ClsConvert.ToDateTimeNullable(result);
				//return local_date.GetValueOrDefault(DateTime.Now);

				string sql = "SELECT SYSDATE FROM DUAL";
				object result = Connection.GetScalar(sql);
				DateTime? local_date = ClsConvert.ToDateTimeNullable(result);
				return local_date.GetValueOrDefault(DateTime.Now);
			}
		}
		#endregion		// #region Fields/Properties

		#region User Setup

		public void AddUser()
		{
			bool newTx = !Connection.IsInTransaction;
			try
			{//TODO: JROMAN revisit this section after security is discussed
				if (newTx == true) Connection.TransactionBegin();

				Insert();

				string sqlSecUser = string.Format(@"
				insert into r_security_user(user_id, user_nm)
				values(user_id_seq.nextval, '{0}')", User_Login);
				Connection.RunSQL(sqlSecUser);

				string sqlGetID = string.Format(@"
				select user_id from r_security_user where user_nm = '{0}'", User_Login);
				object sID = Connection.GetScalar(sqlGetID);
				long? suID = ClsConvert.ToInt64Nullable(sID);
				if (suID.GetValueOrDefault(0) > 0)
				{	// put all users into the ARC_USER group (GROUP_ID = 2)
					string sqlUserGroup = string.Format(@"
				insert into r_user_group(user_group_id, user_id, group_id)
				values(user_group_id_seq.nextval, {0}, 2)", suID);
					Connection.RunSQL(sqlUserGroup);
				}

				string sqlOracleUser = string.Format(@"
				create user {0}
					identified by {1}
					default tablespace USERS
					temporary tablespace TEMP
					profile DEFAULT", User_Login, ClsEnvironment.Password);
				Connection.RunSQL(sqlOracleUser);

				string sqlRole = string.Format("grant arc_user to {0} with admin option", User_Login);
				Connection.RunSQL(sqlRole);

				if (newTx == true) Connection.TransactionCommit();
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public void UpdateUser()
		{
			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@USER_LOGIN", User_Login));
			p.Add(Connection.GetParameter("@USER_PASSWORD", ClsEnvironment.Password));
			p.Add(Connection.GetParameter("@FIRST_NM", First_Nm));
			p.Add(Connection.GetParameter("@LAST_NM", Last_Nm));
			p.Add(Connection.GetParameter("@EMAIL", Email));

			Connection.RunSQL("PKG_ARCSYS_SECURITY.P_UPD_ARCSYS_USER",
				CommandType.StoredProcedure, p.ToArray());
		}

		public void DropUser()
		{
			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				Delete();

				string sqlGetID = string.Format(@"
				select user_id from r_security_user where user_nm = '{0}'", User_Login);
				object sID = Connection.GetScalar(sqlGetID);
				long? suID = ClsConvert.ToInt64Nullable(sID);
				if (suID.GetValueOrDefault(0) > 0)
				{	// put all users into the ARC_USER group (GROUP_ID = 2)
					string sqlUserGroup = string.Format(@"
				delete from r_user_group where user_id = {0}", suID);
					Connection.RunSQL(sqlUserGroup);

					string sqlSecUser = string.Format(@"
				delete from r_security_user where user_id = {0}", suID);
					Connection.RunSQL(sqlSecUser);
				}

				string sql = string.Format("DROP USER {0}", User_Login);
				Connection.RunSQL(sql);

				if (newTx == true) Connection.TransactionCommit();
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region User Setup
	}

	#region Static Methods/Properties of ClsUser

	partial class ClsUser
	{
		#region Fields/Properties

		public static ClsUser CurrentUser { get; set; }

		#endregion		// #region Fields/Properties

		#region Public Methods

		public static ClsUser GetUsingLogin(string login)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(USER_LOGIN)=UPPER(@USER_LOGIN)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@USER_LOGIN", login);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr == null) ? null : new ClsUser(dr);
		}

		public DataTable GetUserTradingPartners()
		{
			string sql = string.Format(@"
				select tp.*  from r_user_trading_partner utp
                 inner join t_trading_partner tp on utp.trading_partner_cd = tp.trading_partner_cd
				 where user_login = '{0}' ", this.User_Login);
			return Connection.GetDataTable(sql);
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsUser
}
