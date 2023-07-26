using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingActivityReceived : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_ACTIVITY_RECEIVED";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_ACTIVITY_RECEIVED";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Activity_CdMax = 2;
		public const int Voyage_NoMax = 10;
		public const int Booking_IDMax = 30;
		public const int Item_IdentificationMax = 50;
		public const int Bill_Of_Lading_NoMax = 30;
		public const int Processed_FlgMax = 1;
		public const int Activity_DatetimeMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected decimal? _Trans_Ctl_No;
		protected string _Activity_Cd;
		protected DateTime? _Activity_Dt;
		protected string _Voyage_No;
		protected string _Booking_ID;
		protected string _Item_Identification;
		protected string _Bill_Of_Lading_No;
		protected DateTime? _Received_Dt;
		protected string _Processed_Flg;
		protected string _Activity_Datetime;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public decimal? Trans_Ctl_No
		{
			get { return _Trans_Ctl_No; }
			set
			{
				if( _Trans_Ctl_No == value ) return;
		
				_Trans_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Ctl_No");
			}
		}
		public string Activity_Cd
		{
			get { return _Activity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CdMax )
					_Activity_Cd = val.Substring(0, (int)Activity_CdMax);
				else
					_Activity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Cd");
			}
		}
		public DateTime? Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				if( _Activity_Dt == value ) return;
		
				_Activity_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
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
		public string Item_Identification
		{
			get { return _Item_Identification; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Identification, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_IdentificationMax )
					_Item_Identification = val.Substring(0, (int)Item_IdentificationMax);
				else
					_Item_Identification = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Identification");
			}
		}
		public string Bill_Of_Lading_No
		{
			get { return _Bill_Of_Lading_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bill_Of_Lading_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bill_Of_Lading_NoMax )
					_Bill_Of_Lading_No = val.Substring(0, (int)Bill_Of_Lading_NoMax);
				else
					_Bill_Of_Lading_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bill_Of_Lading_No");
			}
		}
		public DateTime? Received_Dt
		{
			get { return _Received_Dt; }
			set
			{
				if( _Received_Dt == value ) return;
		
				_Received_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Received_Dt");
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
		public string Activity_Datetime
		{
			get { return _Activity_Datetime; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Datetime, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_DatetimeMax )
					_Activity_Datetime = val.Substring(0, (int)Activity_DatetimeMax);
				else
					_Activity_Datetime = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Datetime");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingActivityReceived() : base() {}
		public ClsBookingActivityReceived(DataRow dr) : base(dr) {}
		public ClsBookingActivityReceived(ClsBookingActivityReceived src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Trans_Ctl_No = null;
			Activity_Cd = null;
			Activity_Dt = null;
			Voyage_No = null;
			Booking_ID = null;
			Item_Identification = null;
			Bill_Of_Lading_No = null;
			Received_Dt = null;
			Processed_Flg = null;
			Activity_Datetime = null;
		}

		public void CopyFrom(ClsBookingActivityReceived src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Trans_Ctl_No = src._Trans_Ctl_No;
			Activity_Cd = src._Activity_Cd;
			Activity_Dt = src._Activity_Dt;
			Voyage_No = src._Voyage_No;
			Booking_ID = src._Booking_ID;
			Item_Identification = src._Item_Identification;
			Bill_Of_Lading_No = src._Bill_Of_Lading_No;
			Received_Dt = src._Received_Dt;
			Processed_Flg = src._Processed_Flg;
			Activity_Datetime = src._Activity_Datetime;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingActivityReceived tmp = null;	//No primary key can't refresh;
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
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[3] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[4] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[5] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[6] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[7] = Connection.GetParameter
				("@ITEM_IDENTIFICATION", Item_Identification);
			p[8] = Connection.GetParameter
				("@BILL_OF_LADING_NO", Bill_Of_Lading_No);
			p[9] = Connection.GetParameter
				("@RECEIVED_DT", Received_Dt);
			p[10] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[11] = Connection.GetParameter
				("@ACTIVITY_DATETIME", Activity_Datetime);

			const string sql = @"
				INSERT INTO T_BOOKING_ACTIVITY_RECEIVED
					(PARTNER_CD, PARTNER_REQUEST_CD, TRANS_CTL_NO,
					ACTIVITY_CD, ACTIVITY_DT, VOYAGE_NO,
					BOOKING_ID, ITEM_IDENTIFICATION, BILL_OF_LADING_NO,
					RECEIVED_DT, PROCESSED_FLG, ACTIVITY_DATETIME)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @TRANS_CTL_NO,
					@ACTIVITY_CD, @ACTIVITY_DT, @VOYAGE_NO,
					@BOOKING_ID, @ITEM_IDENTIFICATION, @BILL_OF_LADING_NO,
					@RECEIVED_DT, @PROCESSED_FLG, @ACTIVITY_DATETIME)
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

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Trans_Ctl_No = ClsConvert.ToDecimalNullable(dr["TRANS_CTL_NO"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Item_Identification = ClsConvert.ToString(dr["ITEM_IDENTIFICATION"]);
			Bill_Of_Lading_No = ClsConvert.ToString(dr["BILL_OF_LADING_NO"]);
			Received_Dt = ClsConvert.ToDateTimeNullable(dr["RECEIVED_DT"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Activity_Datetime = ClsConvert.ToString(dr["ACTIVITY_DATETIME"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Trans_Ctl_No = ClsConvert.ToDecimalNullable(dr["TRANS_CTL_NO", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Item_Identification = ClsConvert.ToString(dr["ITEM_IDENTIFICATION", v]);
			Bill_Of_Lading_No = ClsConvert.ToString(dr["BILL_OF_LADING_NO", v]);
			Received_Dt = ClsConvert.ToDateTimeNullable(dr["RECEIVED_DT", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Activity_Datetime = ClsConvert.ToString(dr["ACTIVITY_DATETIME", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["ITEM_IDENTIFICATION"] = ClsConvert.ToDbObject(Item_Identification);
			dr["BILL_OF_LADING_NO"] = ClsConvert.ToDbObject(Bill_Of_Lading_No);
			dr["RECEIVED_DT"] = ClsConvert.ToDbObject(Received_Dt);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["ACTIVITY_DATETIME"] = ClsConvert.ToDbObject(Activity_Datetime);
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