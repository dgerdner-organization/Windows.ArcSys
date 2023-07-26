using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	public partial class ClsSecurityGroup : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["Security"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "SECURITY.R_SECURITY_GROUP";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "GROUP_ID" };
		}

		public const string SelectSQL = "SELECT * FROM SECURITY.R_SECURITY_GROUP";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Group_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Group_ID;
		protected string _Group_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Group_Dsc
		{
			get { return _Group_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Group_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Group_DscMax )
					_Group_Dsc = val.Substring(0, (int)Group_DscMax);
				else
					_Group_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Group_Dsc");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsSecurityGroup() : base() {}
		public ClsSecurityGroup(DataRow dr) : base(dr) {}
		public ClsSecurityGroup(ClsSecurityGroup src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Group_ID = null;
			Group_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
		}

		public void CopyFrom(ClsSecurityGroup src)
		{
			Group_ID = src._Group_ID;
			Group_Dsc = src._Group_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsSecurityGroup tmp = ClsSecurityGroup.GetUsingKey(Group_ID.Value);
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

			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@GROUP_DSC", Group_Dsc);
			p[1] = Connection.GetParameter
				("@GROUP_ID", Group_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[2] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[3] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO SECURITY.R_SECURITY_GROUP
					(GROUP_ID, GROUP_DSC)
				VALUES
					(GROUP_ID_SEQ.NEXTVAL, @GROUP_DSC)
				RETURNING
					GROUP_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@GROUP_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Group_ID = ClsConvert.ToInt64Nullable(p[1].Value);
			Create_User = ClsConvert.ToString(p[2].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[4].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@GROUP_DSC", Group_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@GROUP_ID", Group_ID);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE SECURITY.R_SECURITY_GROUP SET
					GROUP_DSC = @GROUP_DSC,
					MODIFY_DT = @MODIFY_DT
				WHERE
					GROUP_ID = @GROUP_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[3].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@GROUP_ID", Group_ID);

			const string sql = @"
				DELETE FROM SECURITY.R_SECURITY_GROUP WHERE
				GROUP_ID=@GROUP_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID"]);
			Group_Dsc = ClsConvert.ToString(dr["GROUP_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Group_ID = ClsConvert.ToInt64Nullable(dr["GROUP_ID", v]);
			Group_Dsc = ClsConvert.ToString(dr["GROUP_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["GROUP_ID"] = ClsConvert.ToDbObject(Group_ID);
			dr["GROUP_DSC"] = ClsConvert.ToDbObject(Group_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
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

		public static ClsSecurityGroup GetUsingKey(Int64 Group_ID)
		{
			object[] vals = new object[] {Group_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsSecurityGroup(dr);
		}

		#endregion		// #region Static Methods
	}
}