using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsStenaBookingAudit : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_STENA_BOOKING_AUDIT";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM T_STENA_BOOKING_AUDIT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 20;
		public const int Serial_NoMax = 50;
		public const int Trailer_NoMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Stena_Error_CdMax = 20;
		public const int Stena_Error_MsgMax = 500;
		public const int Route_CdMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;
		protected string _Serial_No;
		protected string _Trailer_No;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected string _Stena_Error_Cd;
		protected string _Stena_Error_Msg;
		protected string _Route_Cd;
		protected DateTime? _Depart_Dt;

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
		public string Stena_Error_Cd
		{
			get { return _Stena_Error_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Stena_Error_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Stena_Error_CdMax )
					_Stena_Error_Cd = val.Substring(0, (int)Stena_Error_CdMax);
				else
					_Stena_Error_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Stena_Error_Cd");
			}
		}
		public string Stena_Error_Msg
		{
			get { return _Stena_Error_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Stena_Error_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Stena_Error_MsgMax )
					_Stena_Error_Msg = val.Substring(0, (int)Stena_Error_MsgMax);
				else
					_Stena_Error_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Stena_Error_Msg");
			}
		}
		public string Route_Cd
		{
			get { return _Route_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Route_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Route_CdMax )
					_Route_Cd = val.Substring(0, (int)Route_CdMax);
				else
					_Route_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Route_Cd");
			}
		}
		public DateTime? Depart_Dt
		{
			get { return _Depart_Dt; }
			set
			{
				if( _Depart_Dt == value ) return;
		
				_Depart_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Depart_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsStenaBookingAudit() : base() {}
		public ClsStenaBookingAudit(DataRow dr) : base(dr) {}
		public ClsStenaBookingAudit(ClsStenaBookingAudit src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
			Serial_No = null;
			Trailer_No = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Stena_Error_Cd = null;
			Stena_Error_Msg = null;
			Route_Cd = null;
			Depart_Dt = null;
		}

		public void CopyFrom(ClsStenaBookingAudit src)
		{
			Booking_No = src._Booking_No;
			Serial_No = src._Serial_No;
			Trailer_No = src._Trailer_No;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Stena_Error_Cd = src._Stena_Error_Cd;
			Stena_Error_Msg = src._Stena_Error_Msg;
			Route_Cd = src._Route_Cd;
			Depart_Dt = src._Depart_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsStenaBookingAudit tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@TRAILER_NO", Trailer_No);
			p[3] = Connection.GetParameter
				("@STENA_ERROR_CD", Stena_Error_Cd);
			p[4] = Connection.GetParameter
				("@STENA_ERROR_MSG", Stena_Error_Msg);
			p[5] = Connection.GetParameter
				("@ROUTE_CD", Route_Cd);
			p[6] = Connection.GetParameter
				("@DEPART_DT", Depart_Dt);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_STENA_BOOKING_AUDIT
					(BOOKING_NO, SERIAL_NO, TRAILER_NO,
					STENA_ERROR_CD, STENA_ERROR_MSG, ROUTE_CD,
					DEPART_DT)
				VALUES
					(@BOOKING_NO, @SERIAL_NO, @TRAILER_NO,
					@STENA_ERROR_CD, @STENA_ERROR_MSG, @ROUTE_CD,
					@DEPART_DT)
				RETURNING
					CREATE_DT, CREATE_USER, MODIFY_DT,
					MODIFY_USER
				INTO
					@CREATE_DT, @CREATE_USER, @MODIFY_DT,
					@MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Create_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			Modify_User = ClsConvert.ToString(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			int ret = -1;


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
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Stena_Error_Cd = ClsConvert.ToString(dr["STENA_ERROR_CD"]);
			Stena_Error_Msg = ClsConvert.ToString(dr["STENA_ERROR_MSG"]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD"]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT"]);
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
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Stena_Error_Cd = ClsConvert.ToString(dr["STENA_ERROR_CD", v]);
			Stena_Error_Msg = ClsConvert.ToString(dr["STENA_ERROR_MSG", v]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD", v]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["TRAILER_NO"] = ClsConvert.ToDbObject(Trailer_No);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["STENA_ERROR_CD"] = ClsConvert.ToDbObject(Stena_Error_Cd);
			dr["STENA_ERROR_MSG"] = ClsConvert.ToDbObject(Stena_Error_Msg);
			dr["ROUTE_CD"] = ClsConvert.ToDbObject(Route_Cd);
			dr["DEPART_DT"] = ClsConvert.ToDbObject(Depart_Dt);
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



		#endregion		// #region Static Methods
	}
}