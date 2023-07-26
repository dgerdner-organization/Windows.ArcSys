using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsUser
	{
		#region Properties

		public bool IsDeveloper
		{
			get { return ClsEnvironment.CheckDeveloper(User_Login); }
		}
		#endregion		// #region Properties

		#region Overrides

		public override void SetDefaults()
		{
			Admin_Flg = "N";
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
			return string.Format("{0} - {1}", User_Login, User_Nm);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(User_Login) == true )
				_Errors["User_Login"] = "Missing user login";
			if( string.IsNullOrEmpty(User_Nm) == true )
				_Errors["User_Nm"] = "Missing user's name";
			if( string.IsNullOrEmpty(Admin_Flg) == true )
				_Errors["Admin_Flg"] = "Missing admin flag";
			if( string.IsNullOrEmpty(Email) == true )
			    _Errors["Email"] = "Missing email";
			else if( Contact.ValidateEmail(Email) == false )
			    _Errors["Email"] = Contact.Error;
		}
		#endregion		// #region Helper Methods

		#region Public Methods

		public void AddUser()
		{
			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@I_USER_LOGIN", User_Login));
			p.Add(Connection.GetParameter("@I_USER_NM", User_Nm));
			p.Add(Connection.GetParameter("@I_EMAIL", Email));
			p.Add(Connection.GetParameter("@I_GROUP_CD", Group_Cd));
			p.Add(Connection.GetParameter("@I_DEF_CATEGORY_CD", Def_Category_Cd));
			p.Add(Connection.GetParameter("@I_USER_PASSWD", ClsEnvironment.Password));
			p.Add(Connection.GetParameter("@I_ADMIN_FLG", Admin_Flg));

			Connection.RunSQL("ITRACK_OWNER.PKG_ITRACK_UTILITY.P_ADD_USER",
				CommandType.StoredProcedure, p.ToArray());
		}

		public void RemoveUser()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter("@I_USER_LOGIN", User_Login);

			Connection.RunSQL("ITRACK_OWNER.PKG_ITRACK_UTILITY.P_DROP_USER",
				CommandType.StoredProcedure, p);
		}
		#endregion		// #region Public Methods
	}

	public enum UserType
	{
		/// <summary>All Users</summary>
		All,
		/// <summary>Business users</summary>
		Biz,
		/// <summary>IT Users</summary>
		IT
	};

	#region Static Methods/Properties of ClsUser

	partial class ClsUser
	{
		#region Fields

		private static ClsUser _CurrentUser;		// Current User logged in
		private static string[] ITOwners = { "JDORNEY", "DGERDNER", "JROMAN", "ITRACK_OWNER",
			"SNARBOROUGH", "BMINOGUE", "CIBARRA", "JBOGLE", "MPAN" };
		private static string[] Developers = { "JDORNEY", "DGERDNER", "JROMAN", "JDORNEY2",
			"ITRACK_OWNER", "DGERDNER2", "JROMAN2" };
		#endregion		// #region Fields

		#region Properties

		public static ClsUser CurrentUser
		{
			get { return _CurrentUser; }
			set { _CurrentUser = value; }
		}
		#endregion		// #region Properties

		#region Public Methods

		public static ClsUser GetUsingLogin(string login)
		{
			string sql = string.Format
				("SELECT * FROM {0} WHERE UPPER(USER_LOGIN)=UPPER(@USER_LOGIN)",
				TableName);

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@USER_LOGIN", login);

			DataRow dr = Connection.GetDataRow(sql, p);
			return ( dr == null ) ? null : new ClsUser(dr);
		}

		public static string GetITOwners()
		{
			StringBuilder sb = new StringBuilder();
			foreach( string s in ITOwners )
				sb.AppendFormat("{0}'{1}'", sb.Length > 0 ? ", " : null, s);
			return sb.ToString();
		}

		public static string GetDevelopers()
		{
			StringBuilder sb = new StringBuilder();
			foreach( string s in Developers )
				sb.AppendFormat("{0}'{1}'", sb.Length > 0 ? ", " : null, s);
			return sb.ToString();
		}

		public static List<string> GetEmailList()
		{
			string sql = @"
			SELECT		DISTINCT ru.EMAIL
			FROM		R_USER ru WHERE ru.EMAIL IS NOT NULL
			ORDER BY	ru.EMAIL ";
			DataTable dt = Connection.GetDataTable(sql);

			List<string> result = new List<string>();
			if( dt != null )
			{
				foreach( DataRow dr in dt.Rows )
				{
					string s = ClsConvert.ToString(dr["EMAIL"]);
					string s1 = string.IsNullOrEmpty(s) ? null : s.Trim();
					if( string.IsNullOrEmpty(s1) == false ) result.Add(s1);
				}
			}
			return result;
		}
		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsUser
}