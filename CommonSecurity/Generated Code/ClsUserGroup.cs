using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	public partial class ClsUserGroup : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["Security"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "SECURITY.R_USER_GROUP";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USER_GROUP_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM SECURITY.R_USER_GROUP 
				INNER JOIN R_SECURITY_USER
				ON SECURITY.R_USER_GROUP.USER_ID=R_SECURITY_USER.USER_ID
				INNER JOIN R_SECURITY_GROUP
				ON SECURITY.R_USER_GROUP.GROUP_ID=R_SECURITY_GROUP.GROUP_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _User_Group_ID;
		protected Int64? _User_ID;
		protected Int64? _Group_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Priority_Nbr;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? User_Group_ID
		{
			get { return _User_Group_ID; }
			set
			{
				if( _User_Group_ID == value ) return;
		
				_User_Group_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("User_Group_ID");
			}
		}
		public Int64? User_ID
		{
			get { return _User_ID; }
			set
			{
				if( _User_ID == value ) return;
		
				_User_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("User_ID");
			}
		}
		public Int64? Group_ID
		{
			get { return _Group_ID; }
			set
			{
				if( _Group_ID == value ) return;
		
				_Group_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Group_ID");
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
		public Int64? Priority_Nbr
		{
			get { return _Priority_Nbr; }
			set
			{
				if( _Priority_Nbr == value ) return;
		
				_Priority_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Priority_Nbr");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsSecurityUser _User;
		protected ClsSecurityGroup _Group;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsSecurityUser User
		{
			get
			{
				if( User_ID == null )
					_User = null;
				else if( _User == null ||
					_User.User_ID != User_ID )
					_User = ClsSecurityUser.GetUsingKey(User_ID.Value);
				return _User;
			}
			set
			{
				if( _User == value ) return;
		
				_User = value;
			}
		}
		public ClsSecurityGroup Group
		{
			get
			{
				if( Group_ID == null )
					_Group = null;
				else if( _Group == null ||
					_Group.Group_ID != Group_ID )
					_Group = ClsSecurityGroup.GetUsingKey(Group_ID.Value);
				return _Group;
			}
			set
			{
				if( _Group == value ) return;
		
				_Group = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsUserGroup() : base() {}
		public ClsUserGroup(DataRow dr) : base(dr) {}
		public ClsUserGroup(ClsUserGroup src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			User_Group_ID = null;
			User_ID = null;
			Group_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Priority_Nbr = null;
		}

		public void CopyFrom(ClsUserGroup src)
		{
			User_Group_ID = src._User_Group_ID;
			User_ID = src._User_ID;
			Group_ID = src._Group_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Priority_Nbr = src._Priority_Nbr;
		}

		public override bool ReloadFromDB()
		{
			ClsUserGroup tmp = ClsUserGroup.GetUsingKey(User_Group_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_User = null;
			_Group = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@USER_ID", User_ID);
			p[1] = Connection.GetParameter
				("@GROUP_ID", Group_ID);
			p[2] = Connection.GetParameter
				("@PRIORITY_NBR", Priority_Nbr);
			p[3] = Connection.GetParameter
				("@USER_GROUP_ID", User_Group_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO SECURITY.R_USER_GROUP
					(USER_GROUP_ID, USER_ID, GROUP_ID,
					PRIORITY_NBR)
				VALUES
					(USER_GROUP_ID_SEQ.NEXTVAL, @USER_ID, @GROUP_ID,
					@PRIORITY_NBR)
				RETURNING
					USER_GROUP_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USER_GROUP_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			User_Group_ID = ClsConvert.ToInt64Nullable(p[3].Value);
			Create_User = ClsConvert.ToString(p[4].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@USER_ID", User_ID);
			p[1] = Connection.GetParameter
				("@GROUP_ID", Group_ID);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@PRIORITY_NBR", Priority_Nbr);
			p[4] = Connection.GetParameter
				("@USER_GROUP_ID", User_Group_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE SECURITY.R_USER_GROUP SET
					USER_ID = @USER_ID,
					GROUP_ID = @GROUP_ID,
					MODIFY_DT = @MODIFY_DT,
					PRIORITY_NBR = @PRIORITY_NBR
				WHERE
					USER_GROUP_ID = @USER_GROUP_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@USER_GROUP_ID", User_Group_ID);

			const string sql = @"
				DELETE FROM SECURITY.R_USER_GROUP WHERE
				USER_GROUP_ID=@USER_GROUP_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			User_Group_ID = ClsConvert.ToInt64Nullable(dr["USER_GROUP_ID"]);
			User_ID = ClsConvert.ToInt64Nullable(dr["USER_ID"]);
			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Priority_Nbr = ClsConvert.ToInt64Nullable(dr["PRIORITY_NBR"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			User_Group_ID = ClsConvert.ToInt64Nullable(dr["USER_GROUP_ID", v]);
			User_ID = ClsConvert.ToInt64Nullable(dr["USER_ID", v]);
			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Priority_Nbr = ClsConvert.ToInt64Nullable(dr["PRIORITY_NBR", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USER_GROUP_ID"] = ClsConvert.ToDbObject(User_Group_ID);
			dr["USER_ID"] = ClsConvert.ToDbObject(User_ID);
			dr["GROUP_ID"] = ClsConvert.ToDbObject(Group_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["PRIORITY_NBR"] = ClsConvert.ToDbObject(Priority_Nbr);
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

		public static ClsUserGroup GetUsingKey(Int64 User_Group_ID)
		{
			object[] vals = new object[] {User_Group_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUserGroup(dr);
		}
		public static DataTable GetAll(Int64? User_ID, Int64? Group_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( User_ID != null && User_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@USER_ID", User_ID));
				sb.Append(" WHERE SECURITY.R_USER_GROUP.USER_ID=@USER_ID");
			}
			if( Group_ID != null && Group_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@GROUP_ID", Group_ID));
				sb.AppendFormat(" {0} SECURITY.R_USER_GROUP.GROUP_ID=@GROUP_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}