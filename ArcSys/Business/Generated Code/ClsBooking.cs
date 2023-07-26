using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBooking : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOOKING_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_BOOKING 
				INNER JOIN R_LOCATION
				ON T_BOOKING.PLOD_LOCATION_CD=R_LOCATION.LOCATION_CD
				INNER JOIN R_LOCATION r_loc2
				ON T_BOOKING.PLOR_LOCATION_CD=r_loc2.LOCATION_CD
				INNER JOIN R_LOCATION r_loc3
				ON T_BOOKING.POD_LOCATION_CD=r_loc3.LOCATION_CD
				INNER JOIN R_LOCATION r_loc4
				ON T_BOOKING.POL_LOCATION_CD=r_loc4.LOCATION_CD
				LEFT OUTER JOIN R_CUSTOMER
				ON T_BOOKING.CUSTOMER_CD=R_CUSTOMER.CUSTOMER_CD
				LEFT OUTER JOIN R_VESSEL
				ON T_BOOKING.VESSEL_CD=R_VESSEL.VESSEL_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Plor_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Plod_Location_CdMax = 10;
		public const int Booking_NoMax = 25;
		public const int Booking_RefMax = 25;
		public const int Bol_NoMax = 25;
		public const int Edi_RefMax = 25;
		public const int Customer_RefMax = 25;
		public const int Customer_CdMax = 10;
		public const int Match_CdMax = 15;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Delivery_TxtMax = 250;
		public const int Cargo_Notes_TxtMax = 250;
		public const int Rcvr_DodaacMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Booking_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Plor_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Plod_Location_Cd;
		protected string _Booking_No;
		protected string _Booking_Ref;
		protected string _Bol_No;
		protected string _Edi_Ref;
		protected string _Customer_Ref;
		protected string _Customer_Cd;
		protected string _Match_Cd;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Delivery_Txt;
		protected string _Cargo_Notes_Txt;
		protected DateTime? _Sail_Dt;
		protected DateTime? _Required_Dlvy_Dt;
		protected string _Rcvr_Dodaac;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Booking_ID
		{
			get { return _Booking_ID; }
			set
			{
				if( _Booking_ID == value ) return;
		
				_Booking_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_ID");
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
		public string Plor_Location_Cd
		{
			get { return _Plor_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_Location_CdMax )
					_Plor_Location_Cd = val.Substring(0, (int)Plor_Location_CdMax);
				else
					_Plor_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Location_Cd");
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
		public string Plod_Location_Cd
		{
			get { return _Plod_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_Location_CdMax )
					_Plod_Location_Cd = val.Substring(0, (int)Plod_Location_CdMax);
				else
					_Plod_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Location_Cd");
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
		public string Booking_Ref
		{
			get { return _Booking_Ref; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_Ref, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_RefMax )
					_Booking_Ref = val.Substring(0, (int)Booking_RefMax);
				else
					_Booking_Ref = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Ref");
			}
		}
		public string Bol_No
		{
			get { return _Bol_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_NoMax )
					_Bol_No = val.Substring(0, (int)Bol_NoMax);
				else
					_Bol_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_No");
			}
		}
		public string Edi_Ref
		{
			get { return _Edi_Ref; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Ref, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_RefMax )
					_Edi_Ref = val.Substring(0, (int)Edi_RefMax);
				else
					_Edi_Ref = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Ref");
			}
		}
		public string Customer_Ref
		{
			get { return _Customer_Ref; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Ref, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_RefMax )
					_Customer_Ref = val.Substring(0, (int)Customer_RefMax);
				else
					_Customer_Ref = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Ref");
			}
		}
		public string Customer_Cd
		{
			get { return _Customer_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_CdMax )
					_Customer_Cd = val.Substring(0, (int)Customer_CdMax);
				else
					_Customer_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Cd");
			}
		}
		public string Match_Cd
		{
			get { return _Match_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Match_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Match_CdMax )
					_Match_Cd = val.Substring(0, (int)Match_CdMax);
				else
					_Match_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Match_Cd");
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
		public string Delivery_Txt
		{
			get { return _Delivery_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_TxtMax )
					_Delivery_Txt = val.Substring(0, (int)Delivery_TxtMax);
				else
					_Delivery_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Txt");
			}
		}
		public string Cargo_Notes_Txt
		{
			get { return _Cargo_Notes_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Notes_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Notes_TxtMax )
					_Cargo_Notes_Txt = val.Substring(0, (int)Cargo_Notes_TxtMax);
				else
					_Cargo_Notes_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Notes_Txt");
			}
		}
		public DateTime? Sail_Dt
		{
			get { return _Sail_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Sail_Dt == val ) return;
		
				_Sail_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}
		public DateTime? Required_Dlvy_Dt
		{
			get { return _Required_Dlvy_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Required_Dlvy_Dt == val ) return;
		
				_Required_Dlvy_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Required_Dlvy_Dt");
			}
		}
		public string Rcvr_Dodaac
		{
			get { return _Rcvr_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_DodaacMax )
					_Rcvr_Dodaac = val.Substring(0, (int)Rcvr_DodaacMax);
				else
					_Rcvr_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Dodaac");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsLocation _Plod_Location;
		protected ClsLocation _Plor_Location;
		protected ClsLocation _Pod_Location;
		protected ClsLocation _Pol_Location;
		protected ClsCustomer _Customer;
		protected ClsVessel _Vessel;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsLocation Plod_Location
		{
			get
			{
				if( Plod_Location_Cd == null )
					_Plod_Location = null;
				else if( _Plod_Location == null ||
					_Plod_Location.Location_Cd != Plod_Location_Cd )
					_Plod_Location = ClsLocation.GetUsingKey(Plod_Location_Cd);
				return _Plod_Location;
			}
			set
			{
				if( _Plod_Location == value ) return;
		
				_Plod_Location = value;
			}
		}
		public ClsLocation Plor_Location
		{
			get
			{
				if( Plor_Location_Cd == null )
					_Plor_Location = null;
				else if( _Plor_Location == null ||
					_Plor_Location.Location_Cd != Plor_Location_Cd )
					_Plor_Location = ClsLocation.GetUsingKey(Plor_Location_Cd);
				return _Plor_Location;
			}
			set
			{
				if( _Plor_Location == value ) return;
		
				_Plor_Location = value;
			}
		}
		public ClsLocation Pod_Location
		{
			get
			{
				if( Pod_Location_Cd == null )
					_Pod_Location = null;
				else if( _Pod_Location == null ||
					_Pod_Location.Location_Cd != Pod_Location_Cd )
					_Pod_Location = ClsLocation.GetUsingKey(Pod_Location_Cd);
				return _Pod_Location;
			}
			set
			{
				if( _Pod_Location == value ) return;
		
				_Pod_Location = value;
			}
		}
		public ClsLocation Pol_Location
		{
			get
			{
				if( Pol_Location_Cd == null )
					_Pol_Location = null;
				else if( _Pol_Location == null ||
					_Pol_Location.Location_Cd != Pol_Location_Cd )
					_Pol_Location = ClsLocation.GetUsingKey(Pol_Location_Cd);
				return _Pol_Location;
			}
			set
			{
				if( _Pol_Location == value ) return;
		
				_Pol_Location = value;
			}
		}
		public ClsCustomer Customer
		{
			get
			{
				if( Customer_Cd == null )
					_Customer = null;
				else if( _Customer == null ||
					_Customer.Customer_Cd != Customer_Cd )
					_Customer = ClsCustomer.GetUsingKey(Customer_Cd);
				return _Customer;
			}
			set
			{
				if( _Customer == value ) return;
		
				_Customer = value;
			}
		}
		public ClsVessel Vessel
		{
			get
			{
				if( Vessel_Cd == null )
					_Vessel = null;
				else if( _Vessel == null ||
					_Vessel.Vessel_Cd != Vessel_Cd )
					_Vessel = ClsVessel.GetUsingKey(Vessel_Cd);
				return _Vessel;
			}
			set
			{
				if( _Vessel == value ) return;
		
				_Vessel = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBooking() : base() {}
		public ClsBooking(DataRow dr) : base(dr) {}
		public ClsBooking(ClsBooking src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Plor_Location_Cd = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Plod_Location_Cd = null;
			Booking_No = null;
			Booking_Ref = null;
			Bol_No = null;
			Edi_Ref = null;
			Customer_Ref = null;
			Customer_Cd = null;
			Match_Cd = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Delivery_Txt = null;
			Cargo_Notes_Txt = null;
			Sail_Dt = null;
			Required_Dlvy_Dt = null;
			Rcvr_Dodaac = null;
		}

		public void CopyFrom(ClsBooking src)
		{
			Booking_ID = src._Booking_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Booking_No = src._Booking_No;
			Booking_Ref = src._Booking_Ref;
			Bol_No = src._Bol_No;
			Edi_Ref = src._Edi_Ref;
			Customer_Ref = src._Customer_Ref;
			Customer_Cd = src._Customer_Cd;
			Match_Cd = src._Match_Cd;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Delivery_Txt = src._Delivery_Txt;
			Cargo_Notes_Txt = src._Cargo_Notes_Txt;
			Sail_Dt = src._Sail_Dt;
			Required_Dlvy_Dt = src._Required_Dlvy_Dt;
			Rcvr_Dodaac = src._Rcvr_Dodaac;
		}

		public override bool ReloadFromDB()
		{
			ClsBooking tmp = ClsBooking.GetUsingKey(Booking_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Plod_Location = null;
			_Plor_Location = null;
			_Pod_Location = null;
			_Pol_Location = null;
			_Customer = null;
			_Vessel = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[1] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[2] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[3] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@BOOKING_REF", Booking_Ref);
			p[6] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[7] = Connection.GetParameter
				("@EDI_REF", Edi_Ref);
			p[8] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[9] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[10] = Connection.GetParameter
				("@MATCH_CD", Match_Cd);
			p[11] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[12] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[13] = Connection.GetParameter
				("@DELIVERY_TXT", Delivery_Txt);
			p[14] = Connection.GetParameter
				("@CARGO_NOTES_TXT", Cargo_Notes_Txt);
			p[15] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[16] = Connection.GetParameter
				("@REQUIRED_DLVY_DT", Required_Dlvy_Dt);
			p[17] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[18] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[19] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[20] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[22] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_BOOKING
					(BOOKING_ID, PLOR_LOCATION_CD, POL_LOCATION_CD,
					POD_LOCATION_CD, PLOD_LOCATION_CD, BOOKING_NO,
					BOOKING_REF, BOL_NO, EDI_REF,
					CUSTOMER_REF, CUSTOMER_CD, MATCH_CD,
					VESSEL_CD, VOYAGE_NO, DELIVERY_TXT,
					CARGO_NOTES_TXT, SAIL_DT, REQUIRED_DLVY_DT,
					RCVR_DODAAC)
				VALUES
					(BOOKING_ID_SEQ.NEXTVAL, @PLOR_LOCATION_CD, @POL_LOCATION_CD,
					@POD_LOCATION_CD, @PLOD_LOCATION_CD, @BOOKING_NO,
					@BOOKING_REF, @BOL_NO, @EDI_REF,
					@CUSTOMER_REF, @CUSTOMER_CD, @MATCH_CD,
					@VESSEL_CD, @VOYAGE_NO, @DELIVERY_TXT,
					@CARGO_NOTES_TXT, @SAIL_DT, @REQUIRED_DLVY_DT,
					@RCVR_DODAAC)
				RETURNING
					BOOKING_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@BOOKING_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Booking_ID = ClsConvert.ToInt64Nullable(p[18].Value);
			Create_User = ClsConvert.ToString(p[19].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[20].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[21];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[2] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[3] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[4] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[5] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[6] = Connection.GetParameter
				("@BOOKING_REF", Booking_Ref);
			p[7] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[8] = Connection.GetParameter
				("@EDI_REF", Edi_Ref);
			p[9] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[10] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[11] = Connection.GetParameter
				("@MATCH_CD", Match_Cd);
			p[12] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[13] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[14] = Connection.GetParameter
				("@DELIVERY_TXT", Delivery_Txt);
			p[15] = Connection.GetParameter
				("@CARGO_NOTES_TXT", Cargo_Notes_Txt);
			p[16] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[17] = Connection.GetParameter
				("@REQUIRED_DLVY_DT", Required_Dlvy_Dt);
			p[18] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[19] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[20] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_BOOKING SET
					MODIFY_DT = @MODIFY_DT,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					BOOKING_NO = @BOOKING_NO,
					BOOKING_REF = @BOOKING_REF,
					BOL_NO = @BOL_NO,
					EDI_REF = @EDI_REF,
					CUSTOMER_REF = @CUSTOMER_REF,
					CUSTOMER_CD = @CUSTOMER_CD,
					MATCH_CD = @MATCH_CD,
					VESSEL_CD = @VESSEL_CD,
					VOYAGE_NO = @VOYAGE_NO,
					DELIVERY_TXT = @DELIVERY_TXT,
					CARGO_NOTES_TXT = @CARGO_NOTES_TXT,
					SAIL_DT = @SAIL_DT,
					REQUIRED_DLVY_DT = @REQUIRED_DLVY_DT,
					RCVR_DODAAC = @RCVR_DODAAC
				WHERE
					BOOKING_ID = @BOOKING_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[20].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);

			const string sql = @"
				DELETE FROM T_BOOKING WHERE
				BOOKING_ID=@BOOKING_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Booking_Ref = ClsConvert.ToString(dr["BOOKING_REF"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Edi_Ref = ClsConvert.ToString(dr["EDI_REF"]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
			Match_Cd = ClsConvert.ToString(dr["MATCH_CD"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT"]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Required_Dlvy_Dt = ClsConvert.ToDateTimeNullable(dr["REQUIRED_DLVY_DT"]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Booking_Ref = ClsConvert.ToString(dr["BOOKING_REF", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Edi_Ref = ClsConvert.ToString(dr["EDI_REF", v]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
			Match_Cd = ClsConvert.ToString(dr["MATCH_CD", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT", v]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Required_Dlvy_Dt = ClsConvert.ToDateTimeNullable(dr["REQUIRED_DLVY_DT", v]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOOKING_REF"] = ClsConvert.ToDbObject(Booking_Ref);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["EDI_REF"] = ClsConvert.ToDbObject(Edi_Ref);
			dr["CUSTOMER_REF"] = ClsConvert.ToDbObject(Customer_Ref);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
			dr["MATCH_CD"] = ClsConvert.ToDbObject(Match_Cd);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["DELIVERY_TXT"] = ClsConvert.ToDbObject(Delivery_Txt);
			dr["CARGO_NOTES_TXT"] = ClsConvert.ToDbObject(Cargo_Notes_Txt);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["REQUIRED_DLVY_DT"] = ClsConvert.ToDbObject(Required_Dlvy_Dt);
			dr["RCVR_DODAAC"] = ClsConvert.ToDbObject(Rcvr_Dodaac);
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

		public static ClsBooking GetUsingKey(Int64 Booking_ID)
		{
			object[] vals = new object[] {Booking_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBooking(dr);
		}
		public static DataTable GetAll(string Plod_Location_Cd, string Plor_Location_Cd,
			string Pod_Location_Cd, string Pol_Location_Cd,
			string Customer_Cd, string Vessel_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Plod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOD_LOCATION_CD", Plod_Location_Cd));
				sb.Append(" WHERE T_BOOKING.PLOD_LOCATION_CD=@PLOD_LOCATION_CD");
			}
			if( string.IsNullOrEmpty(Plor_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOR_LOCATION_CD", Plor_Location_Cd));
				sb.AppendFormat(" {0} T_BOOKING.PLOR_LOCATION_CD=@PLOR_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POD_LOCATION_CD", Pod_Location_Cd));
				sb.AppendFormat(" {0} T_BOOKING.POD_LOCATION_CD=@POD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pol_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POL_LOCATION_CD", Pol_Location_Cd));
				sb.AppendFormat(" {0} T_BOOKING.POL_LOCATION_CD=@POL_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Customer_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CUSTOMER_CD", Customer_Cd));
				sb.AppendFormat(" {0} T_BOOKING.CUSTOMER_CD=@CUSTOMER_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vessel_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VESSEL_CD", Vessel_Cd));
				sb.AppendFormat(" {0} T_BOOKING.VESSEL_CD=@VESSEL_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}