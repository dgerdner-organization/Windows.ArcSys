using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVStenaUnbooked : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_STENA_UNBOOKED";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_STENA_UNBOOKED";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 30;
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Serial_NoMax = 30;
		public const int Trailer_NoMax = 10;
		public const int Vessel_CdMax = 4;
		public const int Vessel_DscMax = 50;
		public const int Route_CdMax = 10;
		public const int Vehicle_Type_CdMax = 10;
		public const int Error_MsgMax = 23;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Serial_No;
		protected string _Trailer_No;
		protected string _Vessel_Cd;
		protected string _Vessel_Dsc;
		protected DateTime? _Depart_Dt;
		protected string _Route_Cd;
		protected string _Vehicle_Type_Cd;
		protected string _Error_Msg;

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
		public string Partner_Cd
		{
			get { return _Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_CdMax )
					_Partner_Cd = val.Substring(0, (int)Partner_CdMax);
				else
					_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Cd");
			}
		}
		public string Partner_Request_Cd
		{
			get { return _Partner_Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_Request_CdMax )
					_Partner_Request_Cd = val.Substring(0, (int)Partner_Request_CdMax);
				else
					_Partner_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Request_Cd");
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
		public string Vessel_Cd
		{
			get { return _Vessel_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_CdMax )
					_Vessel_Cd = val.Substring(0, (int)Vessel_CdMax);
				else
					_Vessel_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Cd");
			}
		}
		public string Vessel_Dsc
		{
			get { return _Vessel_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_DscMax )
					_Vessel_Dsc = val.Substring(0, (int)Vessel_DscMax);
				else
					_Vessel_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Dsc");
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
		public string Vehicle_Type_Cd
		{
			get { return _Vehicle_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vehicle_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vehicle_Type_CdMax )
					_Vehicle_Type_Cd = val.Substring(0, (int)Vehicle_Type_CdMax);
				else
					_Vehicle_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vehicle_Type_Cd");
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

		public ClsVStenaUnbooked() : base() {}
		public ClsVStenaUnbooked(DataRow dr) : base(dr) {}
		public ClsVStenaUnbooked(ClsVStenaUnbooked src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Serial_No = null;
			Trailer_No = null;
			Vessel_Cd = null;
			Vessel_Dsc = null;
			Depart_Dt = null;
			Route_Cd = null;
			Vehicle_Type_Cd = null;
			Error_Msg = null;
		}

		public void CopyFrom(ClsVStenaUnbooked src)
		{
			Booking_No = src._Booking_No;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Serial_No = src._Serial_No;
			Trailer_No = src._Trailer_No;
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Dsc = src._Vessel_Dsc;
			Depart_Dt = src._Depart_Dt;
			Route_Cd = src._Route_Cd;
			Vehicle_Type_Cd = src._Vehicle_Type_Cd;
			Error_Msg = src._Error_Msg;
		}

		public override bool ReloadFromDB()
		{
			ClsVStenaUnbooked tmp = null;	//No primary key can't refresh;
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
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[3] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[4] = Connection.GetParameter
				("@TRAILER_NO", Trailer_No);
			p[5] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[6] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[7] = Connection.GetParameter
				("@DEPART_DT", Depart_Dt);
			p[8] = Connection.GetParameter
				("@ROUTE_CD", Route_Cd);
			p[9] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);
			p[10] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);

			const string sql = @"
				INSERT INTO V_STENA_UNBOOKED
					(BOOKING_NO, PARTNER_CD, PARTNER_REQUEST_CD,
					SERIAL_NO, TRAILER_NO, VESSEL_CD,
					VESSEL_DSC, DEPART_DT, ROUTE_CD,
					VEHICLE_TYPE_CD, ERROR_MSG)
				VALUES
					(@BOOKING_NO, @PARTNER_CD, @PARTNER_REQUEST_CD,
					@SERIAL_NO, @TRAILER_NO, @VESSEL_CD,
					@VESSEL_DSC, @DEPART_DT, @ROUTE_CD,
					@VEHICLE_TYPE_CD, @ERROR_MSG)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


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
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Trailer_No = ClsConvert.ToString(dr["TRAILER_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT"]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD"]);
			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD"]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Trailer_No = ClsConvert.ToString(dr["TRAILER_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT", v]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD", v]);
			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD", v]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["TRAILER_NO"] = ClsConvert.ToDbObject(Trailer_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["DEPART_DT"] = ClsConvert.ToDbObject(Depart_Dt);
			dr["ROUTE_CD"] = ClsConvert.ToDbObject(Route_Cd);
			dr["VEHICLE_TYPE_CD"] = ClsConvert.ToDbObject(Vehicle_Type_Cd);
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



		#endregion		// #region Static Methods
	}
}