using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsUser : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_USER";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USER_LOGIN" };
		}

		public const string SelectSQL = @"SELECT * FROM R_USER 
				INNER JOIN R_GROUP
				ON R_USER.GROUP_CD=R_GROUP.GROUP_CD
				LEFT OUTER JOIN R_CATEGORY
				ON R_USER.DEF_CATEGORY_CD=R_CATEGORY.CATEGORY_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int User_LoginMax = 30;
		public const int User_NmMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Admin_FlgMax = 1;
		public const int Group_CdMax = 10;
		public const int Def_Category_CdMax = 10;
		public const int EmailMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _User_Login;
		protected string _User_Nm;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Admin_Flg;
		protected string _Group_Cd;
		protected string _Def_Category_Cd;
		protected string _Email;

		#endregion	// #region Column Fields

		#region Column Properties

		public string User_Login
		{
			get { return _User_Login; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_User_Login, val, false) == 0 ) return;
		
				if( val != null && val.Length > User_LoginMax )
					_User_Login = val.Substring(0, (int)User_LoginMax);
				else
					_User_Login = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("User_Login");
			}
		}
		public string User_Nm
		{
			get { return _User_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_User_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > User_NmMax )
					_User_Nm = val.Substring(0, (int)User_NmMax);
				else
					_User_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("User_Nm");
			}
		}
		public string Create_User
		{
			get { return _Create_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Create_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Create_UserMax )
					_Create_User = val.Substring(0, (int)Create_UserMax);
				else
					_Create_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Create_User");
			}
		}
		public DateTime? Create_Dt
		{
			get { return _Create_Dt; }
			set
			{
				if( _Create_Dt == value ) return;
		
				_Create_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Create_Dt");
			}
		}
		public string Modify_User
		{
			get { return _Modify_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Modify_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Modify_UserMax )
					_Modify_User = val.Substring(0, (int)Modify_UserMax);
				else
					_Modify_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Modify_User");
			}
		}
		public DateTime? Modify_Dt
		{
			get { return _Modify_Dt; }
			set
			{
				if( _Modify_Dt == value ) return;
		
				_Modify_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Modify_Dt");
			}
		}
		public string Admin_Flg
		{
			get { return _Admin_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Admin_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Admin_FlgMax )
					_Admin_Flg = val.Substring(0, (int)Admin_FlgMax);
				else
					_Admin_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Admin_Flg");
			}
		}
		public string Group_Cd
		{
			get { return _Group_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Group_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Group_CdMax )
					_Group_Cd = val.Substring(0, (int)Group_CdMax);
				else
					_Group_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Group_Cd");
			}
		}
		public string Def_Category_Cd
		{
			get { return _Def_Category_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Def_Category_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Def_Category_CdMax )
					_Def_Category_Cd = val.Substring(0, (int)Def_Category_CdMax);
				else
					_Def_Category_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Def_Category_Cd");
			}
		}
		public string Email
		{
			get { return _Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > EmailMax )
					_Email = val.Substring(0, (int)EmailMax);
				else
					_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsGroup _Group;
		protected ClsCategory _Def_Category;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsGroup Group
		{
			get
			{
				if( Group_Cd == null )
					_Group = null;
				else if( _Group == null ||
					_Group.Group_Cd != Group_Cd )
					_Group = ClsGroup.GetUsingKey(Group_Cd);
				return _Group;
			}
			set
			{
				if( _Group == value ) return;
		
				_Group = value;
			}
		}
		public ClsCategory Def_Category
		{
			get
			{
				if( Def_Category_Cd == null )
					_Def_Category = null;
				else if( _Def_Category == null ||
					_Def_Category.Category_Cd != Def_Category_Cd )
					_Def_Category = ClsCategory.GetUsingKey(Def_Category_Cd);
				return _Def_Category;
			}
			set
			{
				if( _Def_Category == value ) return;
		
				_Def_Category = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsUser() : base() {}
		public ClsUser(DataRow dr) : base(dr) {}
		public ClsUser(ClsUser src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			User_Login = null;
			User_Nm = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Admin_Flg = null;
			Group_Cd = null;
			Def_Category_Cd = null;
			Email = null;
		}

		public void CopyFrom(ClsUser src)
		{
			User_Login = src._User_Login;
			User_Nm = src._User_Nm;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Admin_Flg = src._Admin_Flg;
			Group_Cd = src._Group_Cd;
			Def_Category_Cd = src._Def_Category_Cd;
			Email = src._Email;
		}

		public override bool ReloadFromDB()
		{
			ClsUser tmp = ClsUser.GetUsingKey(User_Login);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Group = null;
			_Def_Category = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@USER_LOGIN", User_Login);
			p[1] = Connection.GetParameter
				("@USER_NM", User_Nm);
			p[2] = Connection.GetParameter
				("@ADMIN_FLG", Admin_Flg);
			p[3] = Connection.GetParameter
				("@GROUP_CD", Group_Cd);
			p[4] = Connection.GetParameter
				("@DEF_CATEGORY_CD", Def_Category_Cd);
			p[5] = Connection.GetParameter
				("@EMAIL", Email);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_USER
					(USER_LOGIN, USER_NM, ADMIN_FLG,
					GROUP_CD, DEF_CATEGORY_CD, EMAIL)
				VALUES
					(@USER_LOGIN, @USER_NM, @ADMIN_FLG,
					@GROUP_CD, @DEF_CATEGORY_CD, @EMAIL)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[6].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@USER_NM", User_Nm);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ADMIN_FLG", Admin_Flg);
			p[3] = Connection.GetParameter
				("@GROUP_CD", Group_Cd);
			p[4] = Connection.GetParameter
				("@DEF_CATEGORY_CD", Def_Category_Cd);
			p[5] = Connection.GetParameter
				("@EMAIL", Email);
			p[6] = Connection.GetParameter
				("@USER_LOGIN", User_Login);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_USER SET
					USER_NM = @USER_NM,
					MODIFY_DT = @MODIFY_DT,
					ADMIN_FLG = @ADMIN_FLG,
					GROUP_CD = @GROUP_CD,
					DEF_CATEGORY_CD = @DEF_CATEGORY_CD,
					EMAIL = @EMAIL
				WHERE
					USER_LOGIN = @USER_LOGIN
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@USER_LOGIN", User_Login);

			const string sql = @"
				DELETE FROM R_USER WHERE
				USER_LOGIN=@USER_LOGIN";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			User_Login = ClsConvert.ToString(dr["USER_LOGIN"]);
			User_Nm = ClsConvert.ToString(dr["USER_NM"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Admin_Flg = ClsConvert.ToString(dr["ADMIN_FLG"]);
			Group_Cd = ClsConvert.ToString(dr["GROUP_CD"]);
			Def_Category_Cd = ClsConvert.ToString(dr["DEF_CATEGORY_CD"]);
			Email = ClsConvert.ToString(dr["EMAIL"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			User_Login = ClsConvert.ToString(dr["USER_LOGIN", v]);
			User_Nm = ClsConvert.ToString(dr["USER_NM", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Admin_Flg = ClsConvert.ToString(dr["ADMIN_FLG", v]);
			Group_Cd = ClsConvert.ToString(dr["GROUP_CD", v]);
			Def_Category_Cd = ClsConvert.ToString(dr["DEF_CATEGORY_CD", v]);
			Email = ClsConvert.ToString(dr["EMAIL", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USER_LOGIN"] = ClsConvert.ToDbObject(User_Login);
			dr["USER_NM"] = ClsConvert.ToDbObject(User_Nm);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ADMIN_FLG"] = ClsConvert.ToDbObject(Admin_Flg);
			dr["GROUP_CD"] = ClsConvert.ToDbObject(Group_Cd);
			dr["DEF_CATEGORY_CD"] = ClsConvert.ToDbObject(Def_Category_Cd);
			dr["EMAIL"] = ClsConvert.ToDbObject(Email);
		}
		#endregion		// #region Conversion methods

		#region Static Methods

		public static DataTable GetAll()
		{
			return Connection.GetTable(TableName);
		}

		public static DataTable GetAll(bool withJoins)
		{
			if( withJoins == false ) return Connection.GetTable(TableName);

			return Connection.GetDataTable(SelectSQL);
		}

		public static ClsUser GetUsingKey(string User_Login)
		{
			object[] vals = new object[] {User_Login};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUser(dr);
		}
		public static DataTable GetAll(string Group_Cd, string Def_Category_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Group_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@GROUP_CD", Group_Cd));
				sb.Append(" WHERE R_USER.GROUP_CD=@GROUP_CD");
			}
			if( string.IsNullOrEmpty(Def_Category_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@DEF_CATEGORY_CD", Def_Category_Cd));
				sb.AppendFormat(" {0} R_USER.DEF_CATEGORY_CD=@DEF_CATEGORY_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}