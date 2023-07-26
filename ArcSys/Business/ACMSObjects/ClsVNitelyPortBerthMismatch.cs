using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVNitelyPortBerthMismatch : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_NITELY_PORT_BERTH_MISMATCH";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_NITELY_PORT_BERTH_MISMATCH";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_IDMax = 30;
		public const int Partner_Request_CdMax = 30;
		public const int Voyage_NoMax = 10;
		public const int Poe_Location_CdMax = 10;
		public const int Poe_Terminal_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Pod_Terminal_CdMax = 10;
		public const int Error_MsgMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_ID;
		protected string _Partner_Request_Cd;
		protected DateTime? _Request_Dt;
		protected string _Voyage_No;
		protected string _Poe_Location_Cd;
		protected string _Poe_Terminal_Cd;
		protected string _Pod_Location_Cd;
		protected string _Pod_Terminal_Cd;
		protected decimal? _Pcs;
		protected decimal? _Vd_Count;
		protected string _Error_Msg;

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
		public DateTime? Request_Dt
		{
			get { return _Request_Dt; }
			set
			{
				if( _Request_Dt == value ) return;
		
				_Request_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Request_Dt");
			}
		}
		public string Voyage_No
		{
			get { return _Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_NoMax )
					_Voyage_No = val.Substring(0, (int)Voyage_NoMax);
				else
					_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_No");
			}
		}
		public string Poe_Location_Cd
		{
			get { return _Poe_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Location_CdMax )
					_Poe_Location_Cd = val.Substring(0, (int)Poe_Location_CdMax);
				else
					_Poe_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Location_Cd");
			}
		}
		public string Poe_Terminal_Cd
		{
			get { return _Poe_Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Terminal_CdMax )
					_Poe_Terminal_Cd = val.Substring(0, (int)Poe_Terminal_CdMax);
				else
					_Poe_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Terminal_Cd");
			}
		}
		public string Pod_Location_Cd
		{
			get { return _Pod_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Location_CdMax )
					_Pod_Location_Cd = val.Substring(0, (int)Pod_Location_CdMax);
				else
					_Pod_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Location_Cd");
			}
		}
		public string Pod_Terminal_Cd
		{
			get { return _Pod_Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Terminal_CdMax )
					_Pod_Terminal_Cd = val.Substring(0, (int)Pod_Terminal_CdMax);
				else
					_Pod_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Terminal_Cd");
			}
		}
		public decimal? Pcs
		{
			get { return _Pcs; }
			set
			{
				if( _Pcs == value ) return;
		
				_Pcs = value;
				_IsDirty = true;
				NotifyPropertyChanged("Pcs");
			}
		}
		public decimal? Vd_Count
		{
			get { return _Vd_Count; }
			set
			{
				if( _Vd_Count == value ) return;
		
				_Vd_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vd_Count");
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

		public ClsVNitelyPortBerthMismatch() : base() {}
		public ClsVNitelyPortBerthMismatch(DataRow dr) : base(dr) {}
		public ClsVNitelyPortBerthMismatch(ClsVNitelyPortBerthMismatch src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_ID = null;
			Partner_Request_Cd = null;
			Request_Dt = null;
			Voyage_No = null;
			Poe_Location_Cd = null;
			Poe_Terminal_Cd = null;
			Pod_Location_Cd = null;
			Pod_Terminal_Cd = null;
			Pcs = null;
			Vd_Count = null;
			Error_Msg = null;
		}

		public void CopyFrom(ClsVNitelyPortBerthMismatch src)
		{
			Booking_ID = src._Booking_ID;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Request_Dt = src._Request_Dt;
			Voyage_No = src._Voyage_No;
			Poe_Location_Cd = src._Poe_Location_Cd;
			Poe_Terminal_Cd = src._Poe_Terminal_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pod_Terminal_Cd = src._Pod_Terminal_Cd;
			Pcs = src._Pcs;
			Vd_Count = src._Vd_Count;
			Error_Msg = src._Error_Msg;
		}

		public override bool ReloadFromDB()
		{
			ClsVNitelyPortBerthMismatch tmp = null;	//No primary key can't refresh;
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
				("@BOOKING_ID", Booking_ID);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[3] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[4] = Connection.GetParameter
				("@POE_LOCATION_CD", Poe_Location_Cd);
			p[5] = Connection.GetParameter
				("@POE_TERMINAL_CD", Poe_Terminal_Cd);
			p[6] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[7] = Connection.GetParameter
				("@POD_TERMINAL_CD", Pod_Terminal_Cd);
			p[8] = Connection.GetParameter
				("@PCS", Pcs);
			p[9] = Connection.GetParameter
				("@VD_COUNT", Vd_Count);
			p[10] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);

			const string sql = @"
				INSERT INTO V_NITELY_PORT_BERTH_MISMATCH
					(BOOKING_ID, PARTNER_REQUEST_CD, REQUEST_DT,
					VOYAGE_NO, POE_LOCATION_CD, POE_TERMINAL_CD,
					POD_LOCATION_CD, POD_TERMINAL_CD, PCS,
					VD_COUNT, ERROR_MSG)
				VALUES
					(@BOOKING_ID, @PARTNER_REQUEST_CD, @REQUEST_DT,
					@VOYAGE_NO, @POE_LOCATION_CD, @POE_TERMINAL_CD,
					@POD_LOCATION_CD, @POD_TERMINAL_CD, @PCS,
					@VD_COUNT, @ERROR_MSG)
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

			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD"]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD"]);
			Pcs = ClsConvert.ToDecimalNullable(dr["PCS"]);
			Vd_Count = ClsConvert.ToDecimalNullable(dr["VD_COUNT"]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD", v]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD", v]);
			Pcs = ClsConvert.ToDecimalNullable(dr["PCS", v]);
			Vd_Count = ClsConvert.ToDecimalNullable(dr["VD_COUNT", v]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["POE_LOCATION_CD"] = ClsConvert.ToDbObject(Poe_Location_Cd);
			dr["POE_TERMINAL_CD"] = ClsConvert.ToDbObject(Poe_Terminal_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POD_TERMINAL_CD"] = ClsConvert.ToDbObject(Pod_Terminal_Cd);
			dr["PCS"] = ClsConvert.ToDbObject(Pcs);
			dr["VD_COUNT"] = ClsConvert.ToDbObject(Vd_Count);
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