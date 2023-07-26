using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVShippingInstructionList : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_SHIPPING_INSTRUCTION_LIST";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_SHIPPING_INSTRUCTION_LIST";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Acms_Status_CdMax = 2;
		public const int Booking_IDMax = 30;
		public const int Voyage_VesselMax = 30;
		public const int Location_Pol_CdMax = 10;
		public const int Location_Pod_CdMax = 10;
		public const int Liner_SystemMax = 4000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Acms_Status_Cd;
		protected DateTime? _Request_Dt;
		protected DateTime? _Rdd_Dt;
		protected string _Booking_ID;
		protected string _Voyage_Vessel;
		protected string _Location_Pol_Cd;
		protected string _Location_Pod_Cd;
		protected decimal? _Liner_Count;
		protected decimal? _Rcvd_Count;
		protected string _Liner_System;

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
		public string Acms_Status_Cd
		{
			get { return _Acms_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Status_CdMax )
					_Acms_Status_Cd = val.Substring(0, (int)Acms_Status_CdMax);
				else
					_Acms_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Status_Cd");
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
		public DateTime? Rdd_Dt
		{
			get { return _Rdd_Dt; }
			set
			{
				if( _Rdd_Dt == value ) return;
		
				_Rdd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rdd_Dt");
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
		public string Voyage_Vessel
		{
			get { return _Voyage_Vessel; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_Vessel, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_VesselMax )
					_Voyage_Vessel = val.Substring(0, (int)Voyage_VesselMax);
				else
					_Voyage_Vessel = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_Vessel");
			}
		}
		public string Location_Pol_Cd
		{
			get { return _Location_Pol_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Pol_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_Pol_CdMax )
					_Location_Pol_Cd = val.Substring(0, (int)Location_Pol_CdMax);
				else
					_Location_Pol_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Pol_Cd");
			}
		}
		public string Location_Pod_Cd
		{
			get { return _Location_Pod_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Pod_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_Pod_CdMax )
					_Location_Pod_Cd = val.Substring(0, (int)Location_Pod_CdMax);
				else
					_Location_Pod_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Pod_Cd");
			}
		}
		public decimal? Liner_Count
		{
			get { return _Liner_Count; }
			set
			{
				if( _Liner_Count == value ) return;
		
				_Liner_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Liner_Count");
			}
		}
		public decimal? Rcvd_Count
		{
			get { return _Rcvd_Count; }
			set
			{
				if( _Rcvd_Count == value ) return;
		
				_Rcvd_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rcvd_Count");
			}
		}
		public string Liner_System
		{
			get { return _Liner_System; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Liner_System, val, false) == 0 ) return;
		
				if( val != null && val.Length > Liner_SystemMax )
					_Liner_System = val.Substring(0, (int)Liner_SystemMax);
				else
					_Liner_System = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Liner_System");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVShippingInstructionList() : base() {}
		public ClsVShippingInstructionList(DataRow dr) : base(dr) {}
		public ClsVShippingInstructionList(ClsVShippingInstructionList src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Acms_Status_Cd = null;
			Request_Dt = null;
			Rdd_Dt = null;
			Booking_ID = null;
			Voyage_Vessel = null;
			Location_Pol_Cd = null;
			Location_Pod_Cd = null;
			Liner_Count = null;
			Rcvd_Count = null;
			Liner_System = null;
		}

		public void CopyFrom(ClsVShippingInstructionList src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Request_Dt = src._Request_Dt;
			Rdd_Dt = src._Rdd_Dt;
			Booking_ID = src._Booking_ID;
			Voyage_Vessel = src._Voyage_Vessel;
			Location_Pol_Cd = src._Location_Pol_Cd;
			Location_Pod_Cd = src._Location_Pod_Cd;
			Liner_Count = src._Liner_Count;
			Rcvd_Count = src._Rcvd_Count;
			Liner_System = src._Liner_System;
		}

		public override bool ReloadFromDB()
		{
			ClsVShippingInstructionList tmp = null;	//No primary key can't refresh;
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
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[3] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[4] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[5] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[6] = Connection.GetParameter
				("@VOYAGE_VESSEL", Voyage_Vessel);
			p[7] = Connection.GetParameter
				("@LOCATION_POL_CD", Location_Pol_Cd);
			p[8] = Connection.GetParameter
				("@LOCATION_POD_CD", Location_Pod_Cd);
			p[9] = Connection.GetParameter
				("@LINER_COUNT", Liner_Count);
			p[10] = Connection.GetParameter
				("@RCVD_COUNT", Rcvd_Count);
			p[11] = Connection.GetParameter
				("@LINER_SYSTEM", Liner_System);

			const string sql = @"
				INSERT INTO V_SHIPPING_INSTRUCTION_LIST
					(PARTNER_CD, PARTNER_REQUEST_CD, ACMS_STATUS_CD,
					REQUEST_DT, RDD_DT, BOOKING_ID,
					VOYAGE_VESSEL, LOCATION_POL_CD, LOCATION_POD_CD,
					LINER_COUNT, RCVD_COUNT, LINER_SYSTEM)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @ACMS_STATUS_CD,
					@REQUEST_DT, @RDD_DT, @BOOKING_ID,
					@VOYAGE_VESSEL, @LOCATION_POL_CD, @LOCATION_POD_CD,
					@LINER_COUNT, @RCVD_COUNT, @LINER_SYSTEM)
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
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Voyage_Vessel = ClsConvert.ToString(dr["VOYAGE_VESSEL"]);
			Location_Pol_Cd = ClsConvert.ToString(dr["LOCATION_POL_CD"]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD"]);
			Liner_Count = ClsConvert.ToDecimalNullable(dr["LINER_COUNT"]);
			Rcvd_Count = ClsConvert.ToDecimalNullable(dr["RCVD_COUNT"]);
			Liner_System = ClsConvert.ToString(dr["LINER_SYSTEM"]);
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
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Voyage_Vessel = ClsConvert.ToString(dr["VOYAGE_VESSEL", v]);
			Location_Pol_Cd = ClsConvert.ToString(dr["LOCATION_POL_CD", v]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD", v]);
			Liner_Count = ClsConvert.ToDecimalNullable(dr["LINER_COUNT", v]);
			Rcvd_Count = ClsConvert.ToDecimalNullable(dr["RCVD_COUNT", v]);
			Liner_System = ClsConvert.ToString(dr["LINER_SYSTEM", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["VOYAGE_VESSEL"] = ClsConvert.ToDbObject(Voyage_Vessel);
			dr["LOCATION_POL_CD"] = ClsConvert.ToDbObject(Location_Pol_Cd);
			dr["LOCATION_POD_CD"] = ClsConvert.ToDbObject(Location_Pod_Cd);
			dr["LINER_COUNT"] = ClsConvert.ToDbObject(Liner_Count);
			dr["RCVD_COUNT"] = ClsConvert.ToDbObject(Rcvd_Count);
			dr["LINER_SYSTEM"] = ClsConvert.ToDbObject(Liner_System);
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