using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInbound322 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_INBOUND_322";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_INBOUND_322_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI_INBOUND_322 
				LEFT OUTER JOIN T_EDI_INBOUND_LOG
				ON T_EDI_INBOUND_322.EDI_INBOUND_LOG_ID=T_EDI_INBOUND_LOG.EDI_INBOUND_LOG_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 25;
		public const int Serial_NoMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Receipt_NoMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Inbound_322_ID;
		protected Int64? _Edi_Inbound_Log_ID;
		protected string _Booking_No;
		protected string _Serial_No;
		protected DateTime? _Cargo_Rcvd_Dt;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Receipt_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Inbound_322_ID
		{
			get { return _Edi_Inbound_322_ID; }
			set
			{
				if( _Edi_Inbound_322_ID == value ) return;
		
				_Edi_Inbound_322_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_322_ID");
			}
		}
		public Int64? Edi_Inbound_Log_ID
		{
			get { return _Edi_Inbound_Log_ID; }
			set
			{
				if( _Edi_Inbound_Log_ID == value ) return;
		
				_Edi_Inbound_Log_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Log_ID");
			}
		}
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
		public DateTime? Cargo_Rcvd_Dt
		{
			get { return _Cargo_Rcvd_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Cargo_Rcvd_Dt == val ) return;
		
				_Cargo_Rcvd_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Rcvd_Dt");
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
		public string Receipt_No
		{
			get { return _Receipt_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Receipt_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Receipt_NoMax )
					_Receipt_No = val.Substring(0, (int)Receipt_NoMax);
				else
					_Receipt_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Receipt_No");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsEdiInboundLog _Edi_Inbound_Log;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEdiInboundLog Edi_Inbound_Log
		{
			get
			{
				if( Edi_Inbound_Log_ID == null )
					_Edi_Inbound_Log = null;
				else if( _Edi_Inbound_Log == null ||
					_Edi_Inbound_Log.Edi_Inbound_Log_ID != Edi_Inbound_Log_ID )
					_Edi_Inbound_Log = ClsEdiInboundLog.GetUsingKey(Edi_Inbound_Log_ID.Value);
				return _Edi_Inbound_Log;
			}
			set
			{
				if( _Edi_Inbound_Log == value ) return;
		
				_Edi_Inbound_Log = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiInbound322() : base() {}
		public ClsEdiInbound322(DataRow dr) : base(dr) {}
		public ClsEdiInbound322(ClsEdiInbound322 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Inbound_322_ID = null;
			Edi_Inbound_Log_ID = null;
			Booking_No = null;
			Serial_No = null;
			Cargo_Rcvd_Dt = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Receipt_No = null;
		}

		public void CopyFrom(ClsEdiInbound322 src)
		{
			Edi_Inbound_322_ID = src._Edi_Inbound_322_ID;
			Edi_Inbound_Log_ID = src._Edi_Inbound_Log_ID;
			Booking_No = src._Booking_No;
			Serial_No = src._Serial_No;
			Cargo_Rcvd_Dt = src._Cargo_Rcvd_Dt;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Receipt_No = src._Receipt_No;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiInbound322 tmp = ClsEdiInbound322.GetUsingKey(Edi_Inbound_322_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Edi_Inbound_Log = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@EDI_INBOUND_LOG_ID", Edi_Inbound_Log_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[3] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[4] = Connection.GetParameter
				("@RECEIPT_NO", Receipt_No);
			p[5] = Connection.GetParameter
				("@EDI_INBOUND_322_ID", Edi_Inbound_322_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_INBOUND_322
					(EDI_INBOUND_322_ID, EDI_INBOUND_LOG_ID, BOOKING_NO,
					SERIAL_NO, CARGO_RCVD_DT, RECEIPT_NO)
				VALUES
					(EDI_INBOUND_322_ID_SEQ.NEXTVAL, @EDI_INBOUND_LOG_ID, @BOOKING_NO,
					@SERIAL_NO, @CARGO_RCVD_DT, @RECEIPT_NO)
				RETURNING
					EDI_INBOUND_322_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_INBOUND_322_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Inbound_322_ID = ClsConvert.ToInt64Nullable(p[5].Value);
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
				("@EDI_INBOUND_LOG_ID", Edi_Inbound_Log_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[3] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[4] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@RECEIPT_NO", Receipt_No);
			p[6] = Connection.GetParameter
				("@EDI_INBOUND_322_ID", Edi_Inbound_322_ID);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_INBOUND_322 SET
					EDI_INBOUND_LOG_ID = @EDI_INBOUND_LOG_ID,
					BOOKING_NO = @BOOKING_NO,
					SERIAL_NO = @SERIAL_NO,
					CARGO_RCVD_DT = @CARGO_RCVD_DT,
					MODIFY_DT = @MODIFY_DT,
					RECEIPT_NO = @RECEIPT_NO
				WHERE
					EDI_INBOUND_322_ID = @EDI_INBOUND_322_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
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

			Edi_Inbound_322_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_322_ID"]);
			Edi_Inbound_Log_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_LOG_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Receipt_No = ClsConvert.ToString(dr["RECEIPT_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Inbound_322_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_322_ID", v]);
			Edi_Inbound_Log_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_LOG_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Receipt_No = ClsConvert.ToString(dr["RECEIPT_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_INBOUND_322_ID"] = ClsConvert.ToDbObject(Edi_Inbound_322_ID);
			dr["EDI_INBOUND_LOG_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Log_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["CARGO_RCVD_DT"] = ClsConvert.ToDbObject(Cargo_Rcvd_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["RECEIPT_NO"] = ClsConvert.ToDbObject(Receipt_No);
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

		public static ClsEdiInbound322 GetUsingKey(Int64 Edi_Inbound_322_ID)
		{
			object[] vals = new object[] {Edi_Inbound_322_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiInbound322(dr);
		}
		public static DataTable GetAll(Int64? Edi_Inbound_Log_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi_Inbound_Log_ID != null && Edi_Inbound_Log_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI_INBOUND_LOG_ID", Edi_Inbound_Log_ID));
				sb.Append(" WHERE T_EDI_INBOUND_322.EDI_INBOUND_LOG_ID=@EDI_INBOUND_LOG_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}