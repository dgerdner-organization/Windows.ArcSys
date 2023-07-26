using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUser : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
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

		public const string SelectSQL = "SELECT * FROM R_USER";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int User_LoginMax = 30;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int First_NmMax = 15;
		public const int Last_NmMax = 30;
		public const int Active_FlgMax = 1;
		public const int EmailMax = 50;
		public const int Vendor_IndMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _User_Login;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _First_Nm;
		protected string _Last_Nm;
		protected string _Active_Flg;
		protected string _Email;
		protected string _Vendor_Ind;

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
		public string First_Nm
		{
			get { return _First_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_First_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > First_NmMax )
					_First_Nm = val.Substring(0, (int)First_NmMax);
				else
					_First_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("First_Nm");
			}
		}
		public string Last_Nm
		{
			get { return _Last_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Last_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Last_NmMax )
					_Last_Nm = val.Substring(0, (int)Last_NmMax);
				else
					_Last_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Last_Nm");
			}
		}
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
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
		public string Vendor_Ind
		{
			get { return _Vendor_Ind; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Ind, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_IndMax )
					_Vendor_Ind = val.Substring(0, (int)Vendor_IndMax);
				else
					_Vendor_Ind = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Ind");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



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
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			First_Nm = null;
			Last_Nm = null;
			Active_Flg = null;
			Email = null;
			Vendor_Ind = null;
		}

		public void CopyFrom(ClsUser src)
		{
			User_Login = src._User_Login;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			First_Nm = src._First_Nm;
			Last_Nm = src._Last_Nm;
			Active_Flg = src._Active_Flg;
			Email = src._Email;
			Vendor_Ind = src._Vendor_Ind;
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

		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@USER_LOGIN", User_Login);
			p[1] = Connection.GetParameter
				("@FIRST_NM", First_Nm);
			p[2] = Connection.GetParameter
				("@LAST_NM", Last_Nm);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@EMAIL", Email);
			p[5] = Connection.GetParameter
				("@VENDOR_IND", Vendor_Ind);
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
					(USER_LOGIN, FIRST_NM, LAST_NM,
					ACTIVE_FLG, EMAIL, VENDOR_IND)
				VALUES
					(@USER_LOGIN, @FIRST_NM, @LAST_NM,
					@ACTIVE_FLG, @EMAIL, @VENDOR_IND)
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
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@FIRST_NM", First_Nm);
			p[2] = Connection.GetParameter
				("@LAST_NM", Last_Nm);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@EMAIL", Email);
			p[5] = Connection.GetParameter
				("@VENDOR_IND", Vendor_Ind);
			p[6] = Connection.GetParameter
				("@USER_LOGIN", User_Login);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_USER SET
					MODIFY_DT = @MODIFY_DT,
					FIRST_NM = @FIRST_NM,
					LAST_NM = @LAST_NM,
					ACTIVE_FLG = @ACTIVE_FLG,
					EMAIL = @EMAIL,
					VENDOR_IND = @VENDOR_IND
				WHERE
					USER_LOGIN = @USER_LOGIN
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
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
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			First_Nm = ClsConvert.ToString(dr["FIRST_NM"]);
			Last_Nm = ClsConvert.ToString(dr["LAST_NM"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Email = ClsConvert.ToString(dr["EMAIL"]);
			Vendor_Ind = ClsConvert.ToString(dr["VENDOR_IND"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			User_Login = ClsConvert.ToString(dr["USER_LOGIN", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			First_Nm = ClsConvert.ToString(dr["FIRST_NM", v]);
			Last_Nm = ClsConvert.ToString(dr["LAST_NM", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Email = ClsConvert.ToString(dr["EMAIL", v]);
			Vendor_Ind = ClsConvert.ToString(dr["VENDOR_IND", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USER_LOGIN"] = ClsConvert.ToDbObject(User_Login);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["FIRST_NM"] = ClsConvert.ToDbObject(First_Nm);
			dr["LAST_NM"] = ClsConvert.ToDbObject(Last_Nm);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["EMAIL"] = ClsConvert.ToDbObject(Email);
			dr["VENDOR_IND"] = ClsConvert.ToDbObject(Vendor_Ind);
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

		#endregion		// #region Static Methods
	}
}