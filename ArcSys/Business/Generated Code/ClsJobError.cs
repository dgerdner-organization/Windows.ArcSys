using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsJobError : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_JOB_ERROR";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "JOB_ERROR_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_JOB_ERROR";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Job_NmMax = 100;
		public const int Error_MsgMax = 1000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Job_Error_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Job_Nm;
		protected string _Error_Msg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Job_Error_ID
		{
			get { return _Job_Error_ID; }
			set
			{
				if( _Job_Error_ID == value ) return;
		
				_Job_Error_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Job_Error_ID");
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
		public string Job_Nm
		{
			get { return _Job_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Job_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Job_NmMax )
					_Job_Nm = val.Substring(0, (int)Job_NmMax);
				else
					_Job_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Job_Nm");
			}
		}
		public string Error_Msg
		{
			get { return _Error_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_MsgMax )
					_Error_Msg = val.Substring(0, (int)Error_MsgMax);
				else
					_Error_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Msg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsJobError() : base() {}
		public ClsJobError(DataRow dr) : base(dr) {}
		public ClsJobError(ClsJobError src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Job_Error_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Job_Nm = null;
			Error_Msg = null;
		}

		public void CopyFrom(ClsJobError src)
		{
			Job_Error_ID = src._Job_Error_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Job_Nm = src._Job_Nm;
			Error_Msg = src._Error_Msg;
		}

		public override bool ReloadFromDB()
		{
			ClsJobError tmp = ClsJobError.GetUsingKey(Job_Error_ID.Value);
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

			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@JOB_NM", Job_Nm);
			p[1] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);
			p[2] = Connection.GetParameter
				("@JOB_ERROR_ID", Job_Error_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[3] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[4] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[6] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_JOB_ERROR
					(JOB_ERROR_ID, JOB_NM, ERROR_MSG)
				VALUES
					(JOB_ERROR_ID_SEQ.NEXTVAL, @JOB_NM, @ERROR_MSG)
				RETURNING
					JOB_ERROR_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@JOB_ERROR_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Job_Error_ID = ClsConvert.ToInt64Nullable(p[2].Value);
			Create_User = ClsConvert.ToString(p[3].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@JOB_NM", Job_Nm);
			p[2] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);
			p[3] = Connection.GetParameter
				("@JOB_ERROR_ID", Job_Error_ID);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_JOB_ERROR SET
					MODIFY_DT = @MODIFY_DT,
					JOB_NM = @JOB_NM,
					ERROR_MSG = @ERROR_MSG
				WHERE
					JOB_ERROR_ID = @JOB_ERROR_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[4].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot delete rows from this table");

			return -1;
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Job_Error_ID = ClsConvert.ToInt64Nullable(dr["JOB_ERROR_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Job_Nm = ClsConvert.ToString(dr["JOB_NM"]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Job_Error_ID = ClsConvert.ToInt64Nullable(dr["JOB_ERROR_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Job_Nm = ClsConvert.ToString(dr["JOB_NM", v]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["JOB_ERROR_ID"] = ClsConvert.ToDbObject(Job_Error_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["JOB_NM"] = ClsConvert.ToDbObject(Job_Nm);
			dr["ERROR_MSG"] = ClsConvert.ToDbObject(Error_Msg);
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

		public static ClsJobError GetUsingKey(Int64 Job_Error_ID)
		{
			object[] vals = new object[] {Job_Error_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsJobError(dr);
		}

		#endregion		// #region Static Methods
	}
}