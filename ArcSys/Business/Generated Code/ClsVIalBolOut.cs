using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVIalBolOut : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_IAL_BOL_OUT";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_IAL_BOL_OUT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Customer_Order_NoMax = 20;
		public const int VinMax = 30;
		public const int Cargo_Bol_NoMax = 25;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Booking_NoMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Customer_Order_No;
		protected string _Vin;
		protected string _Cargo_Bol_No;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected DateTime? _Pol_Ets;
		protected DateTime? _Pod_Eta;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected decimal? _Freight_Amt;
		protected string _Booking_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Customer_Order_No
		{
			get { return _Customer_Order_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Order_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_Order_NoMax )
					_Customer_Order_No = val.Substring(0, (int)Customer_Order_NoMax);
				else
					_Customer_Order_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Order_No");
			}
		}
		public string Vin
		{
			get { return _Vin; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vin, val, false) == 0 ) return;
		
				if( val != null && val.Length > VinMax )
					_Vin = val.Substring(0, (int)VinMax);
				else
					_Vin = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vin");
			}
		}
		public string Cargo_Bol_No
		{
			get { return _Cargo_Bol_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Bol_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Bol_NoMax )
					_Cargo_Bol_No = val.Substring(0, (int)Cargo_Bol_NoMax);
				else
					_Cargo_Bol_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Bol_No");
			}
		}
		public string Pol_Location_Cd
		{
			get { return _Pol_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Location_CdMax )
					_Pol_Location_Cd = val.Substring(0, (int)Pol_Location_CdMax);
				else
					_Pol_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Location_Cd");
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
		public DateTime? Pol_Ets
		{
			get { return _Pol_Ets; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Pol_Ets == val ) return;
		
				_Pol_Ets = val;
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Ets");
			}
		}
		public DateTime? Pod_Eta
		{
			get { return _Pod_Eta; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Pod_Eta == val ) return;
		
				_Pod_Eta = val;
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Eta");
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
		public decimal? Freight_Amt
		{
			get { return _Freight_Amt; }
			set
			{
				if( _Freight_Amt == value ) return;
		
				_Freight_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Freight_Amt");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVIalBolOut() : base() {}
		public ClsVIalBolOut(DataRow dr) : base(dr) {}
		public ClsVIalBolOut(ClsVIalBolOut src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Customer_Order_No = null;
			Vin = null;
			Cargo_Bol_No = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Pol_Ets = null;
			Pod_Eta = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Freight_Amt = null;
			Booking_No = null;
		}

		public void CopyFrom(ClsVIalBolOut src)
		{
			Customer_Order_No = src._Customer_Order_No;
			Vin = src._Vin;
			Cargo_Bol_No = src._Cargo_Bol_No;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pol_Ets = src._Pol_Ets;
			Pod_Eta = src._Pod_Eta;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Freight_Amt = src._Freight_Amt;
			Booking_No = src._Booking_No;
		}

		public override bool ReloadFromDB()
		{
			ClsVIalBolOut tmp = null;	//No primary key can't refresh;
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
				("@CUSTOMER_ORDER_NO", Customer_Order_No);
			p[1] = Connection.GetParameter
				("@VIN", Vin);
			p[2] = Connection.GetParameter
				("@CARGO_BOL_NO", Cargo_Bol_No);
			p[3] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[4] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[5] = Connection.GetParameter
				("@POL_ETS", Pol_Ets);
			p[6] = Connection.GetParameter
				("@POD_ETA", Pod_Eta);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[9] = Connection.GetParameter
				("@FREIGHT_AMT", Freight_Amt);
			p[10] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);

			const string sql = @"
				INSERT INTO V_IAL_BOL_OUT
					(CUSTOMER_ORDER_NO, VIN, CARGO_BOL_NO,
					POL_LOCATION_CD, POD_LOCATION_CD, POL_ETS,
					POD_ETA, VESSEL_CD, VOYAGE_NO,
					FREIGHT_AMT, BOOKING_NO)
				VALUES
					(@CUSTOMER_ORDER_NO, @VIN, @CARGO_BOL_NO,
					@POL_LOCATION_CD, @POD_LOCATION_CD, @POL_ETS,
					@POD_ETA, @VESSEL_CD, @VOYAGE_NO,
					@FREIGHT_AMT, @BOOKING_NO)
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

			Customer_Order_No = ClsConvert.ToString(dr["CUSTOMER_ORDER_NO"]);
			Vin = ClsConvert.ToString(dr["VIN"]);
			Cargo_Bol_No = ClsConvert.ToString(dr["CARGO_BOL_NO"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pol_Ets = ClsConvert.ToDateTimeNullable(dr["POL_ETS"]);
			Pod_Eta = ClsConvert.ToDateTimeNullable(dr["POD_ETA"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Freight_Amt = ClsConvert.ToDecimalNullable(dr["FREIGHT_AMT"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Customer_Order_No = ClsConvert.ToString(dr["CUSTOMER_ORDER_NO", v]);
			Vin = ClsConvert.ToString(dr["VIN", v]);
			Cargo_Bol_No = ClsConvert.ToString(dr["CARGO_BOL_NO", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pol_Ets = ClsConvert.ToDateTimeNullable(dr["POL_ETS", v]);
			Pod_Eta = ClsConvert.ToDateTimeNullable(dr["POD_ETA", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Freight_Amt = ClsConvert.ToDecimalNullable(dr["FREIGHT_AMT", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CUSTOMER_ORDER_NO"] = ClsConvert.ToDbObject(Customer_Order_No);
			dr["VIN"] = ClsConvert.ToDbObject(Vin);
			dr["CARGO_BOL_NO"] = ClsConvert.ToDbObject(Cargo_Bol_No);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POL_ETS"] = ClsConvert.ToDbObject(Pol_Ets);
			dr["POD_ETA"] = ClsConvert.ToDbObject(Pod_Eta);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["FREIGHT_AMT"] = ClsConvert.ToDbObject(Freight_Amt);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
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