using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRdd : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_RDD";
		public const int PrimaryKeyCount = 4;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOOKING_ID", "TCN", "START_DELAY_DT", "ACTIVITY_CODE" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_RDD";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_IDMax = 30;
		public const int TcnMax = 50;
		public const int Activity_CodeMax = 10;
		public const int Processed_FlgMax = 1;
		public const int Create_UserMax = 20;
		public const int Modify_UserMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_ID;
		protected string _Tcn;
		protected DateTime? _Start_Delay_Dt;
		protected string _Activity_Code;
		protected DateTime? _Orig_Rdd_Dt;
		protected DateTime? _End_Delay_Dt;
		protected Int64? _Activity_ID;
		protected string _Processed_Flg;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Booking_ID
		{
			get { return _Booking_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_IDMax )
					_Booking_ID = val.Substring(0, (int)Booking_IDMax);
				else
					_Booking_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_ID");
			}
		}
		public string Tcn
		{
			get { return _Tcn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tcn, val, false) == 0 ) return;
		
				if( val != null && val.Length > TcnMax )
					_Tcn = val.Substring(0, (int)TcnMax);
				else
					_Tcn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tcn");
			}
		}
		public DateTime? Start_Delay_Dt
		{
			get { return _Start_Delay_Dt; }
			set
			{
				if( _Start_Delay_Dt == value ) return;
		
				_Start_Delay_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Start_Delay_Dt");
			}
		}
		public string Activity_Code
		{
			get { return _Activity_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CodeMax )
					_Activity_Code = val.Substring(0, (int)Activity_CodeMax);
				else
					_Activity_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Code");
			}
		}
		public DateTime? Orig_Rdd_Dt
		{
			get { return _Orig_Rdd_Dt; }
			set
			{
				if( _Orig_Rdd_Dt == value ) return;
		
				_Orig_Rdd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Rdd_Dt");
			}
		}
		public DateTime? End_Delay_Dt
		{
			get { return _End_Delay_Dt; }
			set
			{
				if( _End_Delay_Dt == value ) return;
		
				_End_Delay_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("End_Delay_Dt");
			}
		}
		public Int64? Activity_ID
		{
			get { return _Activity_ID; }
			set
			{
				if( _Activity_ID == value ) return;
		
				_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_ID");
			}
		}
		public string Processed_Flg
		{
			get { return _Processed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_FlgMax )
					_Processed_Flg = val.Substring(0, (int)Processed_FlgMax);
				else
					_Processed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Flg");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingRdd() : base() {}
		public ClsBookingRdd(DataRow dr) : base(dr) {}
		public ClsBookingRdd(ClsBookingRdd src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_ID = null;
			Tcn = null;
			Start_Delay_Dt = null;
			Activity_Code = null;
			Orig_Rdd_Dt = null;
			End_Delay_Dt = null;
			Activity_ID = null;
			Processed_Flg = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
		}

		public void CopyFrom(ClsBookingRdd src)
		{
			Booking_ID = src._Booking_ID;
			Tcn = src._Tcn;
			Start_Delay_Dt = src._Start_Delay_Dt;
			Activity_Code = src._Activity_Code;
			Orig_Rdd_Dt = src._Orig_Rdd_Dt;
			End_Delay_Dt = src._End_Delay_Dt;
			Activity_ID = src._Activity_ID;
			Processed_Flg = src._Processed_Flg;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingRdd tmp = ClsBookingRdd.GetUsingKey(Booking_ID, Tcn, Start_Delay_Dt.Value, Activity_Code);
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

			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[1] = Connection.GetParameter
				("@TCN", Tcn);
			p[2] = Connection.GetParameter
				("@START_DELAY_DT", Start_Delay_Dt);
			p[3] = Connection.GetParameter
				("@ACTIVITY_CODE", Activity_Code);
			p[4] = Connection.GetParameter
				("@ORIG_RDD_DT", Orig_Rdd_Dt);
			p[5] = Connection.GetParameter
				("@END_DELAY_DT", End_Delay_Dt);
			p[6] = Connection.GetParameter
				("@ACTIVITY_ID", Activity_ID);
			p[7] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_BOOKING_RDD
					(BOOKING_ID, TCN, START_DELAY_DT,
					ACTIVITY_CODE, ORIG_RDD_DT, END_DELAY_DT,
					ACTIVITY_ID, PROCESSED_FLG)
				VALUES
					(@BOOKING_ID, @TCN, @START_DELAY_DT,
					@ACTIVITY_CODE, @ORIG_RDD_DT, @END_DELAY_DT,
					@ACTIVITY_ID, @PROCESSED_FLG)
				RETURNING
					CREATE_DT, CREATE_USER, MODIFY_DT,
					MODIFY_USER
				INTO
					@CREATE_DT, @CREATE_USER, @MODIFY_DT,
					@MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Create_User = ClsConvert.ToString(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@ORIG_RDD_DT", Orig_Rdd_Dt);
			p[1] = Connection.GetParameter
				("@END_DELAY_DT", End_Delay_Dt);
			p[2] = Connection.GetParameter
				("@ACTIVITY_ID", Activity_ID);
			p[3] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[4] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[6] = Connection.GetParameter
				("@TCN", Tcn);
			p[7] = Connection.GetParameter
				("@START_DELAY_DT", Start_Delay_Dt);
			p[8] = Connection.GetParameter
				("@ACTIVITY_CODE", Activity_Code);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_BOOKING_RDD SET
					ORIG_RDD_DT = @ORIG_RDD_DT,
					END_DELAY_DT = @END_DELAY_DT,
					ACTIVITY_ID = @ACTIVITY_ID,
					PROCESSED_FLG = @PROCESSED_FLG,
					MODIFY_DT = @MODIFY_DT
				WHERE
					BOOKING_ID = @BOOKING_ID AND
					TCN = @TCN AND
					START_DELAY_DT = @START_DELAY_DT AND
					ACTIVITY_CODE = @ACTIVITY_CODE
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
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

			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Start_Delay_Dt = ClsConvert.ToDateTimeNullable(dr["START_DELAY_DT"]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE"]);
			Orig_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ORIG_RDD_DT"]);
			End_Delay_Dt = ClsConvert.ToDateTimeNullable(dr["END_DELAY_DT"]);
			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Start_Delay_Dt = ClsConvert.ToDateTimeNullable(dr["START_DELAY_DT", v]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE", v]);
			Orig_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ORIG_RDD_DT", v]);
			End_Delay_Dt = ClsConvert.ToDateTimeNullable(dr["END_DELAY_DT", v]);
			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["START_DELAY_DT"] = ClsConvert.ToDbObject(Start_Delay_Dt);
			dr["ACTIVITY_CODE"] = ClsConvert.ToDbObject(Activity_Code);
			dr["ORIG_RDD_DT"] = ClsConvert.ToDbObject(Orig_Rdd_Dt);
			dr["END_DELAY_DT"] = ClsConvert.ToDbObject(End_Delay_Dt);
			dr["ACTIVITY_ID"] = ClsConvert.ToDbObject(Activity_ID);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
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

		public static ClsBookingRdd GetUsingKey(string Booking_ID, string Tcn, DateTime Start_Delay_Dt, string Activity_Code)
		{
			object[] vals = new object[] {Booking_ID, Tcn, Start_Delay_Dt, Activity_Code};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingRdd(dr);
		}

		#endregion		// #region Static Methods
	}
}