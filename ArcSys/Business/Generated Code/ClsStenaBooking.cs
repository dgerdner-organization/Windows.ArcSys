using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsStenaBooking : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_STENA_BOOKING";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOOKING_NO", "SERIAL_NO" };
		}

		public const string SelectSQL = "SELECT * FROM T_STENA_BOOKING";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 20;
		public const int Serial_NoMax = 50;
		public const int Trailer_NoMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;
		protected string _Serial_No;
		protected string _Trailer_No;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Stena_ID;
		protected DateTime? _Sailing_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Booking_No
		{
			get { return _Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_NoMax )
					_Booking_No = val.Substring(0, (int)Booking_NoMax);
				else
					_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_No");
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
		public string Trailer_No
		{
			get { return _Trailer_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trailer_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trailer_NoMax )
					_Trailer_No = val.Substring(0, (int)Trailer_NoMax);
				else
					_Trailer_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trailer_No");
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
		public Int64? Stena_ID
		{
			get { return _Stena_ID; }
			set
			{
				if( _Stena_ID == value ) return;
		
				_Stena_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Stena_ID");
			}
		}
		public DateTime? Sailing_Dt
		{
			get { return _Sailing_Dt; }
			set
			{
				if( _Sailing_Dt == value ) return;
		
				_Sailing_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Sailing_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsStenaBooking() : base() {}
		public ClsStenaBooking(DataRow dr) : base(dr) {}
		public ClsStenaBooking(ClsStenaBooking src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
			Serial_No = null;
			Trailer_No = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Stena_ID = null;
			Sailing_Dt = null;
		}

		public void CopyFrom(ClsStenaBooking src)
		{
			Booking_No = src._Booking_No;
			Serial_No = src._Serial_No;
			Trailer_No = src._Trailer_No;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Stena_ID = src._Stena_ID;
			Sailing_Dt = src._Sailing_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsStenaBooking tmp = ClsStenaBooking.GetUsingKey(Booking_No, Serial_No);
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

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@TRAILER_NO", Trailer_No);
			p[3] = Connection.GetParameter
				("@STENA_ID", Stena_ID);
			p[4] = Connection.GetParameter
				("@SAILING_DT", Sailing_Dt);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_STENA_BOOKING
					(BOOKING_NO, SERIAL_NO, TRAILER_NO,
					STENA_ID, SAILING_DT)
				VALUES
					(@BOOKING_NO, @SERIAL_NO, @TRAILER_NO,
					@STENA_ID, @SAILING_DT)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[5].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@TRAILER_NO", Trailer_No);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@STENA_ID", Stena_ID);
			p[3] = Connection.GetParameter
				("@SAILING_DT", Sailing_Dt);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_STENA_BOOKING SET
					TRAILER_NO = @TRAILER_NO,
					MODIFY_DT = @MODIFY_DT,
					STENA_ID = @STENA_ID,
					SAILING_DT = @SAILING_DT
				WHERE
					BOOKING_NO = @BOOKING_NO AND
					SERIAL_NO = @SERIAL_NO
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
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

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Trailer_No = ClsConvert.ToString(dr["TRAILER_NO"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Stena_ID = ClsConvert.ToInt64Nullable(dr["STENA_ID"]);
			Sailing_Dt = ClsConvert.ToDateTimeNullable(dr["SAILING_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Trailer_No = ClsConvert.ToString(dr["TRAILER_NO", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Stena_ID = ClsConvert.ToInt64Nullable(dr["STENA_ID", v]);
			Sailing_Dt = ClsConvert.ToDateTimeNullable(dr["SAILING_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["TRAILER_NO"] = ClsConvert.ToDbObject(Trailer_No);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["STENA_ID"] = ClsConvert.ToDbObject(Stena_ID);
			dr["SAILING_DT"] = ClsConvert.ToDbObject(Sailing_Dt);
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

		public static ClsStenaBooking GetUsingKey(string Booking_No, string Serial_No)
		{
			object[] vals = new object[] {Booking_No, Serial_No};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsStenaBooking(dr);
		}

		#endregion		// #region Static Methods
	}
}