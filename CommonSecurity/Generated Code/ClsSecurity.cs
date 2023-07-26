using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	public partial class ClsSecurity : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["Security"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "SECURITY.R_SECURITY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "SECURITY_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM SECURITY.R_SECURITY 
				INNER JOIN SECURITY.R_SECURITY_GROUP
				ON SECURITY.R_SECURITY.GROUP_ID=SECURITY.R_SECURITY_GROUP.GROUP_ID
				INNER JOIN SECURITY.R_SECURITY_OBJECT
				ON SECURITY.R_SECURITY.OBJECT_ID=SECURITY.R_SECURITY_OBJECT.OBJECT_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Enabled_FlgMax = 1;
		public const int Visible_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Security_ID;
		protected Int64? _Group_ID;
		protected Int64? _Object_ID;
		protected Int64? _Application_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Enabled_Flg;
		protected string _Visible_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Security_ID
		{
			get { return _Security_ID; }
			set
			{
				if( _Security_ID == value ) return;
		
				_Security_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Security_ID");
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
		public Int64? Object_ID
		{
			get { return _Object_ID; }
			set
			{
				if( _Object_ID == value ) return;
		
				_Object_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Object_ID");
			}
		}
		public Int64? Application_ID
		{
			get { return _Application_ID; }
			set
			{
				if( _Application_ID == value ) return;
		
				_Application_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Application_ID");
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
		public string Enabled_Flg
		{
			get { return _Enabled_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Enabled_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Enabled_FlgMax )
					_Enabled_Flg = val.Substring(0, (int)Enabled_FlgMax);
				else
					_Enabled_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Enabled_Flg");
			}
		}
		public string Visible_Flg
		{
			get { return _Visible_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Visible_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Visible_FlgMax )
					_Visible_Flg = val.Substring(0, (int)Visible_FlgMax);
				else
					_Visible_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Visible_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsSecurityGroup _Group;
		protected ClsSecurityObject _Object;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

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
		public ClsSecurityObject Object
		{
			get
			{
				if( Object_ID == null )
					_Object = null;
				else if( _Object == null ||
					_Object.Object_ID != Object_ID )
					_Object = ClsSecurityObject.GetUsingKey(Object_ID.Value);
				return _Object;
			}
			set
			{
				if( _Object == value ) return;
		
				_Object = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsSecurity() : base() {}
		public ClsSecurity(DataRow dr) : base(dr) {}
		public ClsSecurity(ClsSecurity src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Security_ID = null;
			Group_ID = null;
			Object_ID = null;
			Application_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Enabled_Flg = null;
			Visible_Flg = null;
		}

		public void CopyFrom(ClsSecurity src)
		{
			Security_ID = src._Security_ID;
			Group_ID = src._Group_ID;
			Object_ID = src._Object_ID;
			Application_ID = src._Application_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Enabled_Flg = src._Enabled_Flg;
			Visible_Flg = src._Visible_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsSecurity tmp = ClsSecurity.GetUsingKey(Security_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Group = null;
			_Object = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@GROUP_ID", Group_ID);
			p[1] = Connection.GetParameter
				("@OBJECT_ID", Object_ID);
			p[2] = Connection.GetParameter
				("@APPLICATION_ID", Application_ID);
			p[3] = Connection.GetParameter
				("@ENABLED_FLG", Enabled_Flg);
			p[4] = Connection.GetParameter
				("@VISIBLE_FLG", Visible_Flg);
			p[5] = Connection.GetParameter
				("@SECURITY_ID", Security_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO SECURITY.R_SECURITY
					(SECURITY_ID, GROUP_ID, OBJECT_ID,
					APPLICATION_ID, ENABLED_FLG, VISIBLE_FLG)
				VALUES
					(SECURITY_ID_SEQ.NEXTVAL, @GROUP_ID, @OBJECT_ID,
					@APPLICATION_ID, @ENABLED_FLG, @VISIBLE_FLG)
				RETURNING
					SECURITY_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@SECURITY_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Security_ID = ClsConvert.ToInt64Nullable(p[5].Value);
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
				("@GROUP_ID", Group_ID);
			p[1] = Connection.GetParameter
				("@OBJECT_ID", Object_ID);
			p[2] = Connection.GetParameter
				("@APPLICATION_ID", Application_ID);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@ENABLED_FLG", Enabled_Flg);
			p[5] = Connection.GetParameter
				("@VISIBLE_FLG", Visible_Flg);
			p[6] = Connection.GetParameter
				("@SECURITY_ID", Security_ID);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE SECURITY.R_SECURITY SET
					GROUP_ID = @GROUP_ID,
					OBJECT_ID = @OBJECT_ID,
					APPLICATION_ID = @APPLICATION_ID,
					MODIFY_DT = @MODIFY_DT,
					ENABLED_FLG = @ENABLED_FLG,
					VISIBLE_FLG = @VISIBLE_FLG
				WHERE
					SECURITY_ID = @SECURITY_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@SECURITY_ID", Security_ID);

			const string sql = @"
				DELETE FROM SECURITY.R_SECURITY WHERE
				SECURITY_ID=@SECURITY_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Security_ID = ClsConvert.ToInt64Nullable(dr["SECURITY_ID"]);
			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID"]);
			Object_ID = ClsConvert.ToInt64Nullable(dr["OBJECT_ID"]);
			Application_ID = ClsConvert.ToInt64Nullable(dr["APPLICATION_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Enabled_Flg = ClsConvert.ToString(dr["ENABLED_FLG"]);
			Visible_Flg = ClsConvert.ToString(dr["VISIBLE_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Security_ID = ClsConvert.ToInt64Nullable(dr["SECURITY_ID", v]);
			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID", v]);
			Object_ID = ClsConvert.ToInt64Nullable(dr["OBJECT_ID", v]);
			Application_ID = ClsConvert.ToInt64Nullable(dr["APPLICATION_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Enabled_Flg = ClsConvert.ToString(dr["ENABLED_FLG", v]);
			Visible_Flg = ClsConvert.ToString(dr["VISIBLE_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["SECURITY_ID"] = ClsConvert.ToDbObject(Security_ID);
			dr["GROUP_ID"] = ClsConvert.ToDbObject(Group_ID);
			dr["OBJECT_ID"] = ClsConvert.ToDbObject(Object_ID);
			dr["APPLICATION_ID"] = ClsConvert.ToDbObject(Application_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ENABLED_FLG"] = ClsConvert.ToDbObject(Enabled_Flg);
			dr["VISIBLE_FLG"] = ClsConvert.ToDbObject(Visible_Flg);
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

		public static ClsSecurity GetUsingKey(Int64 Security_ID)
		{
			object[] vals = new object[] {Security_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsSecurity(dr);
		}
		public static DataTable GetAll(Int64? Group_ID, Int64? Object_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Group_ID != null && Group_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@GROUP_ID", Group_ID));
				sb.Append(" WHERE SECURITY.R_SECURITY.GROUP_ID=@GROUP_ID");
			}
			if( Object_ID != null && Object_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@OBJECT_ID", Object_ID));
				sb.AppendFormat(" {0} SECURITY.R_SECURITY.OBJECT_ID=@OBJECT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}