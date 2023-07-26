using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoChange : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_CHANGE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_CHANGE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO_CHANGE 
				INNER JOIN T_CARGO_ACTIVITY
				ON T_CARGO_CHANGE.CARGO_ACTIVITY_ID=T_CARGO_ACTIVITY.CARGO_ACTIVITY_ID
				INNER JOIN T_ESTIMATE
				ON T_CARGO_CHANGE.ESTIMATE_ID=T_ESTIMATE.ESTIMATE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Serial_NoMax = 50;
		public const int Column_NmMax = 50;
		public const int Old_ValueMax = 500;
		public const int New_ValueMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Change_ID;
		protected Int64? _Estimate_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Cargo_Activity_ID;
		protected string _Serial_No;
		protected string _Column_Nm;
		protected string _Old_Value;
		protected string _New_Value;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_Change_ID
		{
			get { return _Cargo_Change_ID; }
			set
			{
				if( _Cargo_Change_ID == value ) return;
		
				_Cargo_Change_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Change_ID");
			}
		}
		public Int64? Estimate_ID
		{
			get { return _Estimate_ID; }
			set
			{
				if( _Estimate_ID == value ) return;
		
				_Estimate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_ID");
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
		public Int64? Cargo_Activity_ID
		{
			get { return _Cargo_Activity_ID; }
			set
			{
				if( _Cargo_Activity_ID == value ) return;
		
				_Cargo_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Activity_ID");
			}
		}
		public string Serial_No
		{
			get { return _Serial_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Serial_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Serial_NoMax )
					_Serial_No = val.Substring(0, (int)Serial_NoMax);
				else
					_Serial_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Serial_No");
			}
		}
		public string Column_Nm
		{
			get { return _Column_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Column_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Column_NmMax )
					_Column_Nm = val.Substring(0, (int)Column_NmMax);
				else
					_Column_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Column_Nm");
			}
		}
		public string Old_Value
		{
			get { return _Old_Value; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Old_Value, val, false) == 0 ) return;
		
				if( val != null && val.Length > Old_ValueMax )
					_Old_Value = val.Substring(0, (int)Old_ValueMax);
				else
					_Old_Value = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Old_Value");
			}
		}
		public string New_Value
		{
			get { return _New_Value; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_New_Value, val, false) == 0 ) return;
		
				if( val != null && val.Length > New_ValueMax )
					_New_Value = val.Substring(0, (int)New_ValueMax);
				else
					_New_Value = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("New_Value");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsCargoActivity _Cargo_Activity;
		protected ClsEstimate _Estimate;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCargoActivity Cargo_Activity
		{
			get
			{
				if( Cargo_Activity_ID == null )
					_Cargo_Activity = null;
				else if( _Cargo_Activity == null ||
					_Cargo_Activity.Cargo_Activity_ID != Cargo_Activity_ID )
					_Cargo_Activity = ClsCargoActivity.GetUsingKey(Cargo_Activity_ID.Value);
				return _Cargo_Activity;
			}
			set
			{
				if( _Cargo_Activity == value ) return;
		
				_Cargo_Activity = value;
			}
		}
		public ClsEstimate Estimate
		{
			get
			{
				if( Estimate_ID == null )
					_Estimate = null;
				else if( _Estimate == null ||
					_Estimate.Estimate_ID != Estimate_ID )
					_Estimate = ClsEstimate.GetUsingKey(Estimate_ID.Value);
				return _Estimate;
			}
			set
			{
				if( _Estimate == value ) return;
		
				_Estimate = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoChange() : base() {}
		public ClsCargoChange(DataRow dr) : base(dr) {}
		public ClsCargoChange(ClsCargoChange src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Change_ID = null;
			Estimate_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Cargo_Activity_ID = null;
			Serial_No = null;
			Column_Nm = null;
			Old_Value = null;
			New_Value = null;
		}

		public void CopyFrom(ClsCargoChange src)
		{
			Cargo_Change_ID = src._Cargo_Change_ID;
			Estimate_ID = src._Estimate_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Serial_No = src._Serial_No;
			Column_Nm = src._Column_Nm;
			Old_Value = src._Old_Value;
			New_Value = src._New_Value;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoChange tmp = ClsCargoChange.GetUsingKey(Cargo_Change_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Cargo_Activity = null;
			_Estimate = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[2] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[3] = Connection.GetParameter
				("@COLUMN_NM", Column_Nm);
			p[4] = Connection.GetParameter
				("@OLD_VALUE", Old_Value);
			p[5] = Connection.GetParameter
				("@NEW_VALUE", New_Value);
			p[6] = Connection.GetParameter
				("@CARGO_CHANGE_ID", Cargo_Change_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_CHANGE
					(CARGO_CHANGE_ID, ESTIMATE_ID, CARGO_ACTIVITY_ID,
					SERIAL_NO, COLUMN_NM, OLD_VALUE,
					NEW_VALUE)
				VALUES
					(CARGO_CHANGE_ID_SEQ.NEXTVAL, @ESTIMATE_ID, @CARGO_ACTIVITY_ID,
					@SERIAL_NO, @COLUMN_NM, @OLD_VALUE,
					@NEW_VALUE)
				RETURNING
					CARGO_CHANGE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_CHANGE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Change_ID = ClsConvert.ToInt64Nullable(p[6].Value);
			Create_User = ClsConvert.ToString(p[7].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[3] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[4] = Connection.GetParameter
				("@COLUMN_NM", Column_Nm);
			p[5] = Connection.GetParameter
				("@OLD_VALUE", Old_Value);
			p[6] = Connection.GetParameter
				("@NEW_VALUE", New_Value);
			p[7] = Connection.GetParameter
				("@CARGO_CHANGE_ID", Cargo_Change_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_CHANGE SET
					ESTIMATE_ID = @ESTIMATE_ID,
					MODIFY_DT = @MODIFY_DT,
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID,
					SERIAL_NO = @SERIAL_NO,
					COLUMN_NM = @COLUMN_NM,
					OLD_VALUE = @OLD_VALUE,
					NEW_VALUE = @NEW_VALUE
				WHERE
					CARGO_CHANGE_ID = @CARGO_CHANGE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_CHANGE_ID", Cargo_Change_ID);

			const string sql = @"
				DELETE FROM T_CARGO_CHANGE WHERE
				CARGO_CHANGE_ID=@CARGO_CHANGE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Change_ID = ClsConvert.ToInt64Nullable(dr["CARGO_CHANGE_ID"]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Column_Nm = ClsConvert.ToString(dr["COLUMN_NM"]);
			Old_Value = ClsConvert.ToString(dr["OLD_VALUE"]);
			New_Value = ClsConvert.ToString(dr["NEW_VALUE"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Change_ID = ClsConvert.ToInt64Nullable(dr["CARGO_CHANGE_ID", v]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Column_Nm = ClsConvert.ToString(dr["COLUMN_NM", v]);
			Old_Value = ClsConvert.ToString(dr["OLD_VALUE", v]);
			New_Value = ClsConvert.ToString(dr["NEW_VALUE", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_CHANGE_ID"] = ClsConvert.ToDbObject(Cargo_Change_ID);
			dr["ESTIMATE_ID"] = ClsConvert.ToDbObject(Estimate_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["COLUMN_NM"] = ClsConvert.ToDbObject(Column_Nm);
			dr["OLD_VALUE"] = ClsConvert.ToDbObject(Old_Value);
			dr["NEW_VALUE"] = ClsConvert.ToDbObject(New_Value);
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

		public static ClsCargoChange GetUsingKey(Int64 Cargo_Change_ID)
		{
			object[] vals = new object[] {Cargo_Change_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoChange(dr);
		}
		public static DataTable GetAll(Int64? Cargo_Activity_ID, Int64? Estimate_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Cargo_Activity_ID != null && Cargo_Activity_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_ACTIVITY_ID", Cargo_Activity_ID));
				sb.Append(" WHERE T_CARGO_CHANGE.CARGO_ACTIVITY_ID=@CARGO_ACTIVITY_ID");
			}
			if( Estimate_ID != null && Estimate_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_ID", Estimate_ID));
				sb.AppendFormat(" {0} T_CARGO_CHANGE.ESTIMATE_ID=@ESTIMATE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}