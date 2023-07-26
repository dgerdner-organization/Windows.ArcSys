using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsV304OutputOcean : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_304_OUTPUT_OCEAN";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_304_OUTPUT_OCEAN";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Booking_IDMax = 30;
		public const int Project_CdMax = 30;
		public const int Contract_NoMax = 30;
		public const int Tac_NoMax = 30;
		public const int Fms_Case_NoMax = 30;
		public const int Vessel_CdMax = 4;
		public const int Voyage_NoMax = 10;
		public const int Location_Poe_CdMax = 10;
		public const int Location_Pod_CdMax = 10;
		public const int Delivery_DscMax = 120;
		public const int Cargo_CdMax = 2;
		public const int Iso_Eqp_Type_CdMax = 2;
		public const int Orig_Terms_CdMax = 10;
		public const int Dest_Terms_CdMax = 10;
		public const int Req_NameMax = 30;
		public const int Req_AddressMax = 30;
		public const int Req_CityMax = 30;
		public const int Req_StateMax = 30;
		public const int Req_ZipMax = 20;
		public const int Shipper_NameMax = 30;
		public const int Shipper_AddressMax = 30;
		public const int Shipper_CityMax = 30;
		public const int Shipper_StateMax = 30;
		public const int Shipper_ZipMax = 20;
		public const int Shipper_ContactMax = 30;
		public const int Shipper_PhoneMax = 30;
		public const int Shipper_FaxMax = 30;
		public const int Shipper_EmailMax = 30;
		public const int Booker_NameMax = 30;
		public const int Booker_AddressMax = 30;
		public const int Booker_CityMax = 30;
		public const int Booker_StateMax = 30;
		public const int Booker_ZipMax = 20;
		public const int Booker_PhoneMax = 30;
		public const int Booker_FaxMax = 30;
		public const int Booker_EmailMax = 30;
		public const int Rcvr_NameMax = 30;
		public const int Rcvr_AddressMax = 30;
		public const int Rcvr_CityMax = 30;
		public const int Rcvr_StateMax = 30;
		public const int Rcvr_ZipMax = 20;
		public const int Rcvr_PhoneMax = 30;
		public const int Rcvr_FaxMax = 30;
		public const int Rcvr_EmailMax = 30;
		public const int Rcvr_CountryMax = 2;
		public const int Poe_Terminal_CdMax = 10;
		public const int Pod_Terminal_CdMax = 10;
		public const int Adj_Rdd_ReasonMax = 200;
		public const int Acms_Status_CdMax = 2;
		public const int IrcsMax = 15;
		public const int Vessel_DscMax = 50;
		public const int Poe_CensusMax = 30;
		public const int Poe_DscMax = 50;
		public const int Pod_CensusMax = 30;
		public const int Pod_DscMax = 50;
		public const int Shipper_IDMax = 9;
		public const int Consignee_IDMax = 9;
		public const int Notify_IDMax = 9;
		public const int Us_Or_ForeignMax = 2;
		public const int East_Or_WestMax = 1;
		public const int Clause_7Max = 1;
		public const int Clause_19Max = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Booking_ID;
		protected string _Project_Cd;
		protected string _Contract_No;
		protected string _Tac_No;
		protected string _Fms_Case_No;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Location_Poe_Cd;
		protected string _Location_Pod_Cd;
		protected DateTime? _Cargo_Avail_Dt;
		protected DateTime? _Rdd_Dt;
		protected string _Delivery_Dsc;
		protected Double? _Ship_Units_Nbr;
		protected string _Cargo_Cd;
		protected string _Iso_Eqp_Type_Cd;
		protected string _Orig_Terms_Cd;
		protected string _Dest_Terms_Cd;
		protected Double? _Totals_Stopoffs_Nbr;
		protected string _Req_Name;
		protected string _Req_Address;
		protected string _Req_City;
		protected string _Req_State;
		protected string _Req_Zip;
		protected string _Shipper_Name;
		protected string _Shipper_Address;
		protected string _Shipper_City;
		protected string _Shipper_State;
		protected string _Shipper_Zip;
		protected string _Shipper_Contact;
		protected string _Shipper_Phone;
		protected string _Shipper_Fax;
		protected string _Shipper_Email;
		protected string _Booker_Name;
		protected string _Booker_Address;
		protected string _Booker_City;
		protected string _Booker_State;
		protected string _Booker_Zip;
		protected string _Booker_Phone;
		protected string _Booker_Fax;
		protected string _Booker_Email;
		protected string _Rcvr_Name;
		protected string _Rcvr_Address;
		protected string _Rcvr_City;
		protected string _Rcvr_State;
		protected string _Rcvr_Zip;
		protected string _Rcvr_Phone;
		protected string _Rcvr_Fax;
		protected string _Rcvr_Email;
		protected string _Rcvr_Country;
		protected string _Poe_Terminal_Cd;
		protected string _Pod_Terminal_Cd;
		protected DateTime? _Adj_Rdd_Dt;
		protected string _Adj_Rdd_Reason;
		protected string _Acms_Status_Cd;
		protected string _Ircs;
		protected string _Vessel_Dsc;
		protected string _Poe_Census;
		protected string _Poe_Dsc;
		protected string _Pod_Census;
		protected string _Pod_Dsc;
		protected string _Shipper_ID;
		protected string _Consignee_ID;
		protected string _Notify_ID;
		protected decimal? _Cur_Ctl_No;
		protected string _Us_Or_Foreign;
		protected string _East_Or_West;
		protected string _Clause_7;
		protected string _Clause_19;

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
		public string Project_Cd
		{
			get { return _Project_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Project_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Project_CdMax )
					_Project_Cd = val.Substring(0, (int)Project_CdMax);
				else
					_Project_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Project_Cd");
			}
		}
		public string Contract_No
		{
			get { return _Contract_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contract_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contract_NoMax )
					_Contract_No = val.Substring(0, (int)Contract_NoMax);
				else
					_Contract_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contract_No");
			}
		}
		public string Tac_No
		{
			get { return _Tac_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tac_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Tac_NoMax )
					_Tac_No = val.Substring(0, (int)Tac_NoMax);
				else
					_Tac_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tac_No");
			}
		}
		public string Fms_Case_No
		{
			get { return _Fms_Case_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fms_Case_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Fms_Case_NoMax )
					_Fms_Case_No = val.Substring(0, (int)Fms_Case_NoMax);
				else
					_Fms_Case_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fms_Case_No");
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
		public string Location_Poe_Cd
		{
			get { return _Location_Poe_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Poe_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_Poe_CdMax )
					_Location_Poe_Cd = val.Substring(0, (int)Location_Poe_CdMax);
				else
					_Location_Poe_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Poe_Cd");
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
		public DateTime? Cargo_Avail_Dt
		{
			get { return _Cargo_Avail_Dt; }
			set
			{
				if( _Cargo_Avail_Dt == value ) return;
		
				_Cargo_Avail_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Avail_Dt");
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
		public string Delivery_Dsc
		{
			get { return _Delivery_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_DscMax )
					_Delivery_Dsc = val.Substring(0, (int)Delivery_DscMax);
				else
					_Delivery_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dsc");
			}
		}
		public Double? Ship_Units_Nbr
		{
			get { return _Ship_Units_Nbr; }
			set
			{
				if( _Ship_Units_Nbr == value ) return;
		
				_Ship_Units_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Units_Nbr");
			}
		}
		public string Cargo_Cd
		{
			get { return _Cargo_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_CdMax )
					_Cargo_Cd = val.Substring(0, (int)Cargo_CdMax);
				else
					_Cargo_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Cd");
			}
		}
		public string Iso_Eqp_Type_Cd
		{
			get { return _Iso_Eqp_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Iso_Eqp_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Iso_Eqp_Type_CdMax )
					_Iso_Eqp_Type_Cd = val.Substring(0, (int)Iso_Eqp_Type_CdMax);
				else
					_Iso_Eqp_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Iso_Eqp_Type_Cd");
			}
		}
		public string Orig_Terms_Cd
		{
			get { return _Orig_Terms_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Terms_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_Terms_CdMax )
					_Orig_Terms_Cd = val.Substring(0, (int)Orig_Terms_CdMax);
				else
					_Orig_Terms_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Terms_Cd");
			}
		}
		public string Dest_Terms_Cd
		{
			get { return _Dest_Terms_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Terms_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_Terms_CdMax )
					_Dest_Terms_Cd = val.Substring(0, (int)Dest_Terms_CdMax);
				else
					_Dest_Terms_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Terms_Cd");
			}
		}
		public Double? Totals_Stopoffs_Nbr
		{
			get { return _Totals_Stopoffs_Nbr; }
			set
			{
				if( _Totals_Stopoffs_Nbr == value ) return;
		
				_Totals_Stopoffs_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Totals_Stopoffs_Nbr");
			}
		}
		public string Req_Name
		{
			get { return _Req_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_NameMax )
					_Req_Name = val.Substring(0, (int)Req_NameMax);
				else
					_Req_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Name");
			}
		}
		public string Req_Address
		{
			get { return _Req_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_AddressMax )
					_Req_Address = val.Substring(0, (int)Req_AddressMax);
				else
					_Req_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Address");
			}
		}
		public string Req_City
		{
			get { return _Req_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_CityMax )
					_Req_City = val.Substring(0, (int)Req_CityMax);
				else
					_Req_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_City");
			}
		}
		public string Req_State
		{
			get { return _Req_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_StateMax )
					_Req_State = val.Substring(0, (int)Req_StateMax);
				else
					_Req_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_State");
			}
		}
		public string Req_Zip
		{
			get { return _Req_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_ZipMax )
					_Req_Zip = val.Substring(0, (int)Req_ZipMax);
				else
					_Req_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Zip");
			}
		}
		public string Shipper_Name
		{
			get { return _Shipper_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_NameMax )
					_Shipper_Name = val.Substring(0, (int)Shipper_NameMax);
				else
					_Shipper_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Name");
			}
		}
		public string Shipper_Address
		{
			get { return _Shipper_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_AddressMax )
					_Shipper_Address = val.Substring(0, (int)Shipper_AddressMax);
				else
					_Shipper_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Address");
			}
		}
		public string Shipper_City
		{
			get { return _Shipper_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_CityMax )
					_Shipper_City = val.Substring(0, (int)Shipper_CityMax);
				else
					_Shipper_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_City");
			}
		}
		public string Shipper_State
		{
			get { return _Shipper_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_StateMax )
					_Shipper_State = val.Substring(0, (int)Shipper_StateMax);
				else
					_Shipper_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_State");
			}
		}
		public string Shipper_Zip
		{
			get { return _Shipper_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_ZipMax )
					_Shipper_Zip = val.Substring(0, (int)Shipper_ZipMax);
				else
					_Shipper_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Zip");
			}
		}
		public string Shipper_Contact
		{
			get { return _Shipper_Contact; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Contact, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_ContactMax )
					_Shipper_Contact = val.Substring(0, (int)Shipper_ContactMax);
				else
					_Shipper_Contact = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Contact");
			}
		}
		public string Shipper_Phone
		{
			get { return _Shipper_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_PhoneMax )
					_Shipper_Phone = val.Substring(0, (int)Shipper_PhoneMax);
				else
					_Shipper_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Phone");
			}
		}
		public string Shipper_Fax
		{
			get { return _Shipper_Fax; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Fax, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_FaxMax )
					_Shipper_Fax = val.Substring(0, (int)Shipper_FaxMax);
				else
					_Shipper_Fax = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Fax");
			}
		}
		public string Shipper_Email
		{
			get { return _Shipper_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_EmailMax )
					_Shipper_Email = val.Substring(0, (int)Shipper_EmailMax);
				else
					_Shipper_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Email");
			}
		}
		public string Booker_Name
		{
			get { return _Booker_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_NameMax )
					_Booker_Name = val.Substring(0, (int)Booker_NameMax);
				else
					_Booker_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Name");
			}
		}
		public string Booker_Address
		{
			get { return _Booker_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_AddressMax )
					_Booker_Address = val.Substring(0, (int)Booker_AddressMax);
				else
					_Booker_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Address");
			}
		}
		public string Booker_City
		{
			get { return _Booker_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_CityMax )
					_Booker_City = val.Substring(0, (int)Booker_CityMax);
				else
					_Booker_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_City");
			}
		}
		public string Booker_State
		{
			get { return _Booker_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_StateMax )
					_Booker_State = val.Substring(0, (int)Booker_StateMax);
				else
					_Booker_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_State");
			}
		}
		public string Booker_Zip
		{
			get { return _Booker_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_ZipMax )
					_Booker_Zip = val.Substring(0, (int)Booker_ZipMax);
				else
					_Booker_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Zip");
			}
		}
		public string Booker_Phone
		{
			get { return _Booker_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_PhoneMax )
					_Booker_Phone = val.Substring(0, (int)Booker_PhoneMax);
				else
					_Booker_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Phone");
			}
		}
		public string Booker_Fax
		{
			get { return _Booker_Fax; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Fax, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_FaxMax )
					_Booker_Fax = val.Substring(0, (int)Booker_FaxMax);
				else
					_Booker_Fax = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Fax");
			}
		}
		public string Booker_Email
		{
			get { return _Booker_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_EmailMax )
					_Booker_Email = val.Substring(0, (int)Booker_EmailMax);
				else
					_Booker_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Email");
			}
		}
		public string Rcvr_Name
		{
			get { return _Rcvr_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_NameMax )
					_Rcvr_Name = val.Substring(0, (int)Rcvr_NameMax);
				else
					_Rcvr_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Name");
			}
		}
		public string Rcvr_Address
		{
			get { return _Rcvr_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_AddressMax )
					_Rcvr_Address = val.Substring(0, (int)Rcvr_AddressMax);
				else
					_Rcvr_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Address");
			}
		}
		public string Rcvr_City
		{
			get { return _Rcvr_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_CityMax )
					_Rcvr_City = val.Substring(0, (int)Rcvr_CityMax);
				else
					_Rcvr_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_City");
			}
		}
		public string Rcvr_State
		{
			get { return _Rcvr_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_StateMax )
					_Rcvr_State = val.Substring(0, (int)Rcvr_StateMax);
				else
					_Rcvr_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_State");
			}
		}
		public string Rcvr_Zip
		{
			get { return _Rcvr_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_ZipMax )
					_Rcvr_Zip = val.Substring(0, (int)Rcvr_ZipMax);
				else
					_Rcvr_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Zip");
			}
		}
		public string Rcvr_Phone
		{
			get { return _Rcvr_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_PhoneMax )
					_Rcvr_Phone = val.Substring(0, (int)Rcvr_PhoneMax);
				else
					_Rcvr_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Phone");
			}
		}
		public string Rcvr_Fax
		{
			get { return _Rcvr_Fax; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Fax, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_FaxMax )
					_Rcvr_Fax = val.Substring(0, (int)Rcvr_FaxMax);
				else
					_Rcvr_Fax = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Fax");
			}
		}
		public string Rcvr_Email
		{
			get { return _Rcvr_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_EmailMax )
					_Rcvr_Email = val.Substring(0, (int)Rcvr_EmailMax);
				else
					_Rcvr_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Email");
			}
		}
		public string Rcvr_Country
		{
			get { return _Rcvr_Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_CountryMax )
					_Rcvr_Country = val.Substring(0, (int)Rcvr_CountryMax);
				else
					_Rcvr_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Country");
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
		public DateTime? Adj_Rdd_Dt
		{
			get { return _Adj_Rdd_Dt; }
			set
			{
				if( _Adj_Rdd_Dt == value ) return;
		
				_Adj_Rdd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Adj_Rdd_Dt");
			}
		}
		public string Adj_Rdd_Reason
		{
			get { return _Adj_Rdd_Reason; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Adj_Rdd_Reason, val, false) == 0 ) return;
		
				if( val != null && val.Length > Adj_Rdd_ReasonMax )
					_Adj_Rdd_Reason = val.Substring(0, (int)Adj_Rdd_ReasonMax);
				else
					_Adj_Rdd_Reason = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Adj_Rdd_Reason");
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
		public string Ircs
		{
			get { return _Ircs; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ircs, val, false) == 0 ) return;
		
				if( val != null && val.Length > IrcsMax )
					_Ircs = val.Substring(0, (int)IrcsMax);
				else
					_Ircs = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ircs");
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
		public string Poe_Census
		{
			get { return _Poe_Census; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Census, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_CensusMax )
					_Poe_Census = val.Substring(0, (int)Poe_CensusMax);
				else
					_Poe_Census = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Census");
			}
		}
		public string Poe_Dsc
		{
			get { return _Poe_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_DscMax )
					_Poe_Dsc = val.Substring(0, (int)Poe_DscMax);
				else
					_Poe_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Dsc");
			}
		}
		public string Pod_Census
		{
			get { return _Pod_Census; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Census, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_CensusMax )
					_Pod_Census = val.Substring(0, (int)Pod_CensusMax);
				else
					_Pod_Census = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Census");
			}
		}
		public string Pod_Dsc
		{
			get { return _Pod_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_DscMax )
					_Pod_Dsc = val.Substring(0, (int)Pod_DscMax);
				else
					_Pod_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Dsc");
			}
		}
		public string Shipper_ID
		{
			get { return _Shipper_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_IDMax )
					_Shipper_ID = val.Substring(0, (int)Shipper_IDMax);
				else
					_Shipper_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_ID");
			}
		}
		public string Consignee_ID
		{
			get { return _Consignee_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Consignee_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Consignee_IDMax )
					_Consignee_ID = val.Substring(0, (int)Consignee_IDMax);
				else
					_Consignee_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Consignee_ID");
			}
		}
		public string Notify_ID
		{
			get { return _Notify_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Notify_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Notify_IDMax )
					_Notify_ID = val.Substring(0, (int)Notify_IDMax);
				else
					_Notify_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Notify_ID");
			}
		}
		public decimal? Cur_Ctl_No
		{
			get { return _Cur_Ctl_No; }
			set
			{
				if( _Cur_Ctl_No == value ) return;
		
				_Cur_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cur_Ctl_No");
			}
		}
		public string Us_Or_Foreign
		{
			get { return _Us_Or_Foreign; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Us_Or_Foreign, val, false) == 0 ) return;
		
				if( val != null && val.Length > Us_Or_ForeignMax )
					_Us_Or_Foreign = val.Substring(0, (int)Us_Or_ForeignMax);
				else
					_Us_Or_Foreign = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Us_Or_Foreign");
			}
		}
		public string East_Or_West
		{
			get { return _East_Or_West; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_East_Or_West, val, false) == 0 ) return;
		
				if( val != null && val.Length > East_Or_WestMax )
					_East_Or_West = val.Substring(0, (int)East_Or_WestMax);
				else
					_East_Or_West = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("East_Or_West");
			}
		}
		public string Clause_7
		{
			get { return _Clause_7; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Clause_7, val, false) == 0 ) return;
		
				if( val != null && val.Length > Clause_7Max )
					_Clause_7 = val.Substring(0, (int)Clause_7Max);
				else
					_Clause_7 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Clause_7");
			}
		}
		public string Clause_19
		{
			get { return _Clause_19; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Clause_19, val, false) == 0 ) return;
		
				if( val != null && val.Length > Clause_19Max )
					_Clause_19 = val.Substring(0, (int)Clause_19Max);
				else
					_Clause_19 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Clause_19");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsV304OutputOcean() : base() {}
		public ClsV304OutputOcean(DataRow dr) : base(dr) {}
		public ClsV304OutputOcean(ClsV304OutputOcean src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Booking_ID = null;
			Project_Cd = null;
			Contract_No = null;
			Tac_No = null;
			Fms_Case_No = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Location_Poe_Cd = null;
			Location_Pod_Cd = null;
			Cargo_Avail_Dt = null;
			Rdd_Dt = null;
			Delivery_Dsc = null;
			Ship_Units_Nbr = null;
			Cargo_Cd = null;
			Iso_Eqp_Type_Cd = null;
			Orig_Terms_Cd = null;
			Dest_Terms_Cd = null;
			Totals_Stopoffs_Nbr = null;
			Req_Name = null;
			Req_Address = null;
			Req_City = null;
			Req_State = null;
			Req_Zip = null;
			Shipper_Name = null;
			Shipper_Address = null;
			Shipper_City = null;
			Shipper_State = null;
			Shipper_Zip = null;
			Shipper_Contact = null;
			Shipper_Phone = null;
			Shipper_Fax = null;
			Shipper_Email = null;
			Booker_Name = null;
			Booker_Address = null;
			Booker_City = null;
			Booker_State = null;
			Booker_Zip = null;
			Booker_Phone = null;
			Booker_Fax = null;
			Booker_Email = null;
			Rcvr_Name = null;
			Rcvr_Address = null;
			Rcvr_City = null;
			Rcvr_State = null;
			Rcvr_Zip = null;
			Rcvr_Phone = null;
			Rcvr_Fax = null;
			Rcvr_Email = null;
			Rcvr_Country = null;
			Poe_Terminal_Cd = null;
			Pod_Terminal_Cd = null;
			Adj_Rdd_Dt = null;
			Adj_Rdd_Reason = null;
			Acms_Status_Cd = null;
			Ircs = null;
			Vessel_Dsc = null;
			Poe_Census = null;
			Poe_Dsc = null;
			Pod_Census = null;
			Pod_Dsc = null;
			Shipper_ID = null;
			Consignee_ID = null;
			Notify_ID = null;
			Cur_Ctl_No = null;
			Us_Or_Foreign = null;
			East_Or_West = null;
			Clause_7 = null;
			Clause_19 = null;
		}

		public void CopyFrom(ClsV304OutputOcean src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Booking_ID = src._Booking_ID;
			Project_Cd = src._Project_Cd;
			Contract_No = src._Contract_No;
			Tac_No = src._Tac_No;
			Fms_Case_No = src._Fms_Case_No;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Location_Poe_Cd = src._Location_Poe_Cd;
			Location_Pod_Cd = src._Location_Pod_Cd;
			Cargo_Avail_Dt = src._Cargo_Avail_Dt;
			Rdd_Dt = src._Rdd_Dt;
			Delivery_Dsc = src._Delivery_Dsc;
			Ship_Units_Nbr = src._Ship_Units_Nbr;
			Cargo_Cd = src._Cargo_Cd;
			Iso_Eqp_Type_Cd = src._Iso_Eqp_Type_Cd;
			Orig_Terms_Cd = src._Orig_Terms_Cd;
			Dest_Terms_Cd = src._Dest_Terms_Cd;
			Totals_Stopoffs_Nbr = src._Totals_Stopoffs_Nbr;
			Req_Name = src._Req_Name;
			Req_Address = src._Req_Address;
			Req_City = src._Req_City;
			Req_State = src._Req_State;
			Req_Zip = src._Req_Zip;
			Shipper_Name = src._Shipper_Name;
			Shipper_Address = src._Shipper_Address;
			Shipper_City = src._Shipper_City;
			Shipper_State = src._Shipper_State;
			Shipper_Zip = src._Shipper_Zip;
			Shipper_Contact = src._Shipper_Contact;
			Shipper_Phone = src._Shipper_Phone;
			Shipper_Fax = src._Shipper_Fax;
			Shipper_Email = src._Shipper_Email;
			Booker_Name = src._Booker_Name;
			Booker_Address = src._Booker_Address;
			Booker_City = src._Booker_City;
			Booker_State = src._Booker_State;
			Booker_Zip = src._Booker_Zip;
			Booker_Phone = src._Booker_Phone;
			Booker_Fax = src._Booker_Fax;
			Booker_Email = src._Booker_Email;
			Rcvr_Name = src._Rcvr_Name;
			Rcvr_Address = src._Rcvr_Address;
			Rcvr_City = src._Rcvr_City;
			Rcvr_State = src._Rcvr_State;
			Rcvr_Zip = src._Rcvr_Zip;
			Rcvr_Phone = src._Rcvr_Phone;
			Rcvr_Fax = src._Rcvr_Fax;
			Rcvr_Email = src._Rcvr_Email;
			Rcvr_Country = src._Rcvr_Country;
			Poe_Terminal_Cd = src._Poe_Terminal_Cd;
			Pod_Terminal_Cd = src._Pod_Terminal_Cd;
			Adj_Rdd_Dt = src._Adj_Rdd_Dt;
			Adj_Rdd_Reason = src._Adj_Rdd_Reason;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Ircs = src._Ircs;
			Vessel_Dsc = src._Vessel_Dsc;
			Poe_Census = src._Poe_Census;
			Poe_Dsc = src._Poe_Dsc;
			Pod_Census = src._Pod_Census;
			Pod_Dsc = src._Pod_Dsc;
			Shipper_ID = src._Shipper_ID;
			Consignee_ID = src._Consignee_ID;
			Notify_ID = src._Notify_ID;
			Cur_Ctl_No = src._Cur_Ctl_No;
			Us_Or_Foreign = src._Us_Or_Foreign;
			East_Or_West = src._East_Or_West;
			Clause_7 = src._Clause_7;
			Clause_19 = src._Clause_19;
		}

		public override bool ReloadFromDB()
		{
			ClsV304OutputOcean tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[70];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[3] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[4] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[5] = Connection.GetParameter
				("@TAC_NO", Tac_No);
			p[6] = Connection.GetParameter
				("@FMS_CASE_NO", Fms_Case_No);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[9] = Connection.GetParameter
				("@LOCATION_POE_CD", Location_Poe_Cd);
			p[10] = Connection.GetParameter
				("@LOCATION_POD_CD", Location_Pod_Cd);
			p[11] = Connection.GetParameter
				("@CARGO_AVAIL_DT", Cargo_Avail_Dt);
			p[12] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[13] = Connection.GetParameter
				("@DELIVERY_DSC", Delivery_Dsc);
			p[14] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[15] = Connection.GetParameter
				("@CARGO_CD", Cargo_Cd);
			p[16] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[17] = Connection.GetParameter
				("@ORIG_TERMS_CD", Orig_Terms_Cd);
			p[18] = Connection.GetParameter
				("@DEST_TERMS_CD", Dest_Terms_Cd);
			p[19] = Connection.GetParameter
				("@TOTALS_STOPOFFS_NBR", Totals_Stopoffs_Nbr);
			p[20] = Connection.GetParameter
				("@REQ_NAME", Req_Name);
			p[21] = Connection.GetParameter
				("@REQ_ADDRESS", Req_Address);
			p[22] = Connection.GetParameter
				("@REQ_CITY", Req_City);
			p[23] = Connection.GetParameter
				("@REQ_STATE", Req_State);
			p[24] = Connection.GetParameter
				("@REQ_ZIP", Req_Zip);
			p[25] = Connection.GetParameter
				("@SHIPPER_NAME", Shipper_Name);
			p[26] = Connection.GetParameter
				("@SHIPPER_ADDRESS", Shipper_Address);
			p[27] = Connection.GetParameter
				("@SHIPPER_CITY", Shipper_City);
			p[28] = Connection.GetParameter
				("@SHIPPER_STATE", Shipper_State);
			p[29] = Connection.GetParameter
				("@SHIPPER_ZIP", Shipper_Zip);
			p[30] = Connection.GetParameter
				("@SHIPPER_CONTACT", Shipper_Contact);
			p[31] = Connection.GetParameter
				("@SHIPPER_PHONE", Shipper_Phone);
			p[32] = Connection.GetParameter
				("@SHIPPER_FAX", Shipper_Fax);
			p[33] = Connection.GetParameter
				("@SHIPPER_EMAIL", Shipper_Email);
			p[34] = Connection.GetParameter
				("@BOOKER_NAME", Booker_Name);
			p[35] = Connection.GetParameter
				("@BOOKER_ADDRESS", Booker_Address);
			p[36] = Connection.GetParameter
				("@BOOKER_CITY", Booker_City);
			p[37] = Connection.GetParameter
				("@BOOKER_STATE", Booker_State);
			p[38] = Connection.GetParameter
				("@BOOKER_ZIP", Booker_Zip);
			p[39] = Connection.GetParameter
				("@BOOKER_PHONE", Booker_Phone);
			p[40] = Connection.GetParameter
				("@BOOKER_FAX", Booker_Fax);
			p[41] = Connection.GetParameter
				("@BOOKER_EMAIL", Booker_Email);
			p[42] = Connection.GetParameter
				("@RCVR_NAME", Rcvr_Name);
			p[43] = Connection.GetParameter
				("@RCVR_ADDRESS", Rcvr_Address);
			p[44] = Connection.GetParameter
				("@RCVR_CITY", Rcvr_City);
			p[45] = Connection.GetParameter
				("@RCVR_STATE", Rcvr_State);
			p[46] = Connection.GetParameter
				("@RCVR_ZIP", Rcvr_Zip);
			p[47] = Connection.GetParameter
				("@RCVR_PHONE", Rcvr_Phone);
			p[48] = Connection.GetParameter
				("@RCVR_FAX", Rcvr_Fax);
			p[49] = Connection.GetParameter
				("@RCVR_EMAIL", Rcvr_Email);
			p[50] = Connection.GetParameter
				("@RCVR_COUNTRY", Rcvr_Country);
			p[51] = Connection.GetParameter
				("@POE_TERMINAL_CD", Poe_Terminal_Cd);
			p[52] = Connection.GetParameter
				("@POD_TERMINAL_CD", Pod_Terminal_Cd);
			p[53] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[54] = Connection.GetParameter
				("@ADJ_RDD_REASON", Adj_Rdd_Reason);
			p[55] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[56] = Connection.GetParameter
				("@IRCS", Ircs);
			p[57] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[58] = Connection.GetParameter
				("@POE_CENSUS", Poe_Census);
			p[59] = Connection.GetParameter
				("@POE_DSC", Poe_Dsc);
			p[60] = Connection.GetParameter
				("@POD_CENSUS", Pod_Census);
			p[61] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[62] = Connection.GetParameter
				("@SHIPPER_ID", Shipper_ID);
			p[63] = Connection.GetParameter
				("@CONSIGNEE_ID", Consignee_ID);
			p[64] = Connection.GetParameter
				("@NOTIFY_ID", Notify_ID);
			p[65] = Connection.GetParameter
				("@CUR_CTL_NO", Cur_Ctl_No);
			p[66] = Connection.GetParameter
				("@US_OR_FOREIGN", Us_Or_Foreign);
			p[67] = Connection.GetParameter
				("@EAST_OR_WEST", East_Or_West);
			p[68] = Connection.GetParameter
				("@CLAUSE_7", Clause_7);
			p[69] = Connection.GetParameter
				("@CLAUSE_19", Clause_19);

			const string sql = @"
				INSERT INTO V_304_OUTPUT_OCEAN
					(PARTNER_CD, PARTNER_REQUEST_CD, BOOKING_ID,
					PROJECT_CD, CONTRACT_NO, TAC_NO,
					FMS_CASE_NO, VESSEL_CD, VOYAGE_NO,
					LOCATION_POE_CD, LOCATION_POD_CD, CARGO_AVAIL_DT,
					RDD_DT, DELIVERY_DSC, SHIP_UNITS_NBR,
					CARGO_CD, ISO_EQP_TYPE_CD, ORIG_TERMS_CD,
					DEST_TERMS_CD, TOTALS_STOPOFFS_NBR, REQ_NAME,
					REQ_ADDRESS, REQ_CITY, REQ_STATE,
					REQ_ZIP, SHIPPER_NAME, SHIPPER_ADDRESS,
					SHIPPER_CITY, SHIPPER_STATE, SHIPPER_ZIP,
					SHIPPER_CONTACT, SHIPPER_PHONE, SHIPPER_FAX,
					SHIPPER_EMAIL, BOOKER_NAME, BOOKER_ADDRESS,
					BOOKER_CITY, BOOKER_STATE, BOOKER_ZIP,
					BOOKER_PHONE, BOOKER_FAX, BOOKER_EMAIL,
					RCVR_NAME, RCVR_ADDRESS, RCVR_CITY,
					RCVR_STATE, RCVR_ZIP, RCVR_PHONE,
					RCVR_FAX, RCVR_EMAIL, RCVR_COUNTRY,
					POE_TERMINAL_CD, POD_TERMINAL_CD, ADJ_RDD_DT,
					ADJ_RDD_REASON, ACMS_STATUS_CD, IRCS,
					VESSEL_DSC, POE_CENSUS, POE_DSC,
					POD_CENSUS, POD_DSC, SHIPPER_ID,
					CONSIGNEE_ID, NOTIFY_ID, CUR_CTL_NO,
					US_OR_FOREIGN, EAST_OR_WEST, CLAUSE_7,
					CLAUSE_19)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @BOOKING_ID,
					@PROJECT_CD, @CONTRACT_NO, @TAC_NO,
					@FMS_CASE_NO, @VESSEL_CD, @VOYAGE_NO,
					@LOCATION_POE_CD, @LOCATION_POD_CD, @CARGO_AVAIL_DT,
					@RDD_DT, @DELIVERY_DSC, @SHIP_UNITS_NBR,
					@CARGO_CD, @ISO_EQP_TYPE_CD, @ORIG_TERMS_CD,
					@DEST_TERMS_CD, @TOTALS_STOPOFFS_NBR, @REQ_NAME,
					@REQ_ADDRESS, @REQ_CITY, @REQ_STATE,
					@REQ_ZIP, @SHIPPER_NAME, @SHIPPER_ADDRESS,
					@SHIPPER_CITY, @SHIPPER_STATE, @SHIPPER_ZIP,
					@SHIPPER_CONTACT, @SHIPPER_PHONE, @SHIPPER_FAX,
					@SHIPPER_EMAIL, @BOOKER_NAME, @BOOKER_ADDRESS,
					@BOOKER_CITY, @BOOKER_STATE, @BOOKER_ZIP,
					@BOOKER_PHONE, @BOOKER_FAX, @BOOKER_EMAIL,
					@RCVR_NAME, @RCVR_ADDRESS, @RCVR_CITY,
					@RCVR_STATE, @RCVR_ZIP, @RCVR_PHONE,
					@RCVR_FAX, @RCVR_EMAIL, @RCVR_COUNTRY,
					@POE_TERMINAL_CD, @POD_TERMINAL_CD, @ADJ_RDD_DT,
					@ADJ_RDD_REASON, @ACMS_STATUS_CD, @IRCS,
					@VESSEL_DSC, @POE_CENSUS, @POE_DSC,
					@POD_CENSUS, @POD_DSC, @SHIPPER_ID,
					@CONSIGNEE_ID, @NOTIFY_ID, @CUR_CTL_NO,
					@US_OR_FOREIGN, @EAST_OR_WEST, @CLAUSE_7,
					@CLAUSE_19)
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
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO"]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Location_Poe_Cd = ClsConvert.ToString(dr["LOCATION_POE_CD"]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD"]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC"]);
			Ship_Units_Nbr = ClsConvert.ToDoubleNullable(dr["SHIP_UNITS_NBR"]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD"]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD"]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD"]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD"]);
			Totals_Stopoffs_Nbr = ClsConvert.ToDoubleNullable(dr["TOTALS_STOPOFFS_NBR"]);
			Req_Name = ClsConvert.ToString(dr["REQ_NAME"]);
			Req_Address = ClsConvert.ToString(dr["REQ_ADDRESS"]);
			Req_City = ClsConvert.ToString(dr["REQ_CITY"]);
			Req_State = ClsConvert.ToString(dr["REQ_STATE"]);
			Req_Zip = ClsConvert.ToString(dr["REQ_ZIP"]);
			Shipper_Name = ClsConvert.ToString(dr["SHIPPER_NAME"]);
			Shipper_Address = ClsConvert.ToString(dr["SHIPPER_ADDRESS"]);
			Shipper_City = ClsConvert.ToString(dr["SHIPPER_CITY"]);
			Shipper_State = ClsConvert.ToString(dr["SHIPPER_STATE"]);
			Shipper_Zip = ClsConvert.ToString(dr["SHIPPER_ZIP"]);
			Shipper_Contact = ClsConvert.ToString(dr["SHIPPER_CONTACT"]);
			Shipper_Phone = ClsConvert.ToString(dr["SHIPPER_PHONE"]);
			Shipper_Fax = ClsConvert.ToString(dr["SHIPPER_FAX"]);
			Shipper_Email = ClsConvert.ToString(dr["SHIPPER_EMAIL"]);
			Booker_Name = ClsConvert.ToString(dr["BOOKER_NAME"]);
			Booker_Address = ClsConvert.ToString(dr["BOOKER_ADDRESS"]);
			Booker_City = ClsConvert.ToString(dr["BOOKER_CITY"]);
			Booker_State = ClsConvert.ToString(dr["BOOKER_STATE"]);
			Booker_Zip = ClsConvert.ToString(dr["BOOKER_ZIP"]);
			Booker_Phone = ClsConvert.ToString(dr["BOOKER_PHONE"]);
			Booker_Fax = ClsConvert.ToString(dr["BOOKER_FAX"]);
			Booker_Email = ClsConvert.ToString(dr["BOOKER_EMAIL"]);
			Rcvr_Name = ClsConvert.ToString(dr["RCVR_NAME"]);
			Rcvr_Address = ClsConvert.ToString(dr["RCVR_ADDRESS"]);
			Rcvr_City = ClsConvert.ToString(dr["RCVR_CITY"]);
			Rcvr_State = ClsConvert.ToString(dr["RCVR_STATE"]);
			Rcvr_Zip = ClsConvert.ToString(dr["RCVR_ZIP"]);
			Rcvr_Phone = ClsConvert.ToString(dr["RCVR_PHONE"]);
			Rcvr_Fax = ClsConvert.ToString(dr["RCVR_FAX"]);
			Rcvr_Email = ClsConvert.ToString(dr["RCVR_EMAIL"]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY"]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD"]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD"]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT"]);
			Adj_Rdd_Reason = ClsConvert.ToString(dr["ADJ_RDD_REASON"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Ircs = ClsConvert.ToString(dr["IRCS"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Poe_Census = ClsConvert.ToString(dr["POE_CENSUS"]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC"]);
			Pod_Census = ClsConvert.ToString(dr["POD_CENSUS"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Shipper_ID = ClsConvert.ToString(dr["SHIPPER_ID"]);
			Consignee_ID = ClsConvert.ToString(dr["CONSIGNEE_ID"]);
			Notify_ID = ClsConvert.ToString(dr["NOTIFY_ID"]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO"]);
			Us_Or_Foreign = ClsConvert.ToString(dr["US_OR_FOREIGN"]);
			East_Or_West = ClsConvert.ToString(dr["EAST_OR_WEST"]);
			Clause_7 = ClsConvert.ToString(dr["CLAUSE_7"]);
			Clause_19 = ClsConvert.ToString(dr["CLAUSE_19"]);
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
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO", v]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Location_Poe_Cd = ClsConvert.ToString(dr["LOCATION_POE_CD", v]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD", v]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC", v]);
			Ship_Units_Nbr = ClsConvert.ToDoubleNullable(dr["SHIP_UNITS_NBR", v]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD", v]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD", v]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD", v]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD", v]);
			Totals_Stopoffs_Nbr = ClsConvert.ToDoubleNullable(dr["TOTALS_STOPOFFS_NBR", v]);
			Req_Name = ClsConvert.ToString(dr["REQ_NAME", v]);
			Req_Address = ClsConvert.ToString(dr["REQ_ADDRESS", v]);
			Req_City = ClsConvert.ToString(dr["REQ_CITY", v]);
			Req_State = ClsConvert.ToString(dr["REQ_STATE", v]);
			Req_Zip = ClsConvert.ToString(dr["REQ_ZIP", v]);
			Shipper_Name = ClsConvert.ToString(dr["SHIPPER_NAME", v]);
			Shipper_Address = ClsConvert.ToString(dr["SHIPPER_ADDRESS", v]);
			Shipper_City = ClsConvert.ToString(dr["SHIPPER_CITY", v]);
			Shipper_State = ClsConvert.ToString(dr["SHIPPER_STATE", v]);
			Shipper_Zip = ClsConvert.ToString(dr["SHIPPER_ZIP", v]);
			Shipper_Contact = ClsConvert.ToString(dr["SHIPPER_CONTACT", v]);
			Shipper_Phone = ClsConvert.ToString(dr["SHIPPER_PHONE", v]);
			Shipper_Fax = ClsConvert.ToString(dr["SHIPPER_FAX", v]);
			Shipper_Email = ClsConvert.ToString(dr["SHIPPER_EMAIL", v]);
			Booker_Name = ClsConvert.ToString(dr["BOOKER_NAME", v]);
			Booker_Address = ClsConvert.ToString(dr["BOOKER_ADDRESS", v]);
			Booker_City = ClsConvert.ToString(dr["BOOKER_CITY", v]);
			Booker_State = ClsConvert.ToString(dr["BOOKER_STATE", v]);
			Booker_Zip = ClsConvert.ToString(dr["BOOKER_ZIP", v]);
			Booker_Phone = ClsConvert.ToString(dr["BOOKER_PHONE", v]);
			Booker_Fax = ClsConvert.ToString(dr["BOOKER_FAX", v]);
			Booker_Email = ClsConvert.ToString(dr["BOOKER_EMAIL", v]);
			Rcvr_Name = ClsConvert.ToString(dr["RCVR_NAME", v]);
			Rcvr_Address = ClsConvert.ToString(dr["RCVR_ADDRESS", v]);
			Rcvr_City = ClsConvert.ToString(dr["RCVR_CITY", v]);
			Rcvr_State = ClsConvert.ToString(dr["RCVR_STATE", v]);
			Rcvr_Zip = ClsConvert.ToString(dr["RCVR_ZIP", v]);
			Rcvr_Phone = ClsConvert.ToString(dr["RCVR_PHONE", v]);
			Rcvr_Fax = ClsConvert.ToString(dr["RCVR_FAX", v]);
			Rcvr_Email = ClsConvert.ToString(dr["RCVR_EMAIL", v]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY", v]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD", v]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD", v]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT", v]);
			Adj_Rdd_Reason = ClsConvert.ToString(dr["ADJ_RDD_REASON", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Ircs = ClsConvert.ToString(dr["IRCS", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Poe_Census = ClsConvert.ToString(dr["POE_CENSUS", v]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC", v]);
			Pod_Census = ClsConvert.ToString(dr["POD_CENSUS", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Shipper_ID = ClsConvert.ToString(dr["SHIPPER_ID", v]);
			Consignee_ID = ClsConvert.ToString(dr["CONSIGNEE_ID", v]);
			Notify_ID = ClsConvert.ToString(dr["NOTIFY_ID", v]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO", v]);
			Us_Or_Foreign = ClsConvert.ToString(dr["US_OR_FOREIGN", v]);
			East_Or_West = ClsConvert.ToString(dr["EAST_OR_WEST", v]);
			Clause_7 = ClsConvert.ToString(dr["CLAUSE_7", v]);
			Clause_19 = ClsConvert.ToString(dr["CLAUSE_19", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["PROJECT_CD"] = ClsConvert.ToDbObject(Project_Cd);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["TAC_NO"] = ClsConvert.ToDbObject(Tac_No);
			dr["FMS_CASE_NO"] = ClsConvert.ToDbObject(Fms_Case_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["LOCATION_POE_CD"] = ClsConvert.ToDbObject(Location_Poe_Cd);
			dr["LOCATION_POD_CD"] = ClsConvert.ToDbObject(Location_Pod_Cd);
			dr["CARGO_AVAIL_DT"] = ClsConvert.ToDbObject(Cargo_Avail_Dt);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["DELIVERY_DSC"] = ClsConvert.ToDbObject(Delivery_Dsc);
			dr["SHIP_UNITS_NBR"] = ClsConvert.ToDbObject(Ship_Units_Nbr);
			dr["CARGO_CD"] = ClsConvert.ToDbObject(Cargo_Cd);
			dr["ISO_EQP_TYPE_CD"] = ClsConvert.ToDbObject(Iso_Eqp_Type_Cd);
			dr["ORIG_TERMS_CD"] = ClsConvert.ToDbObject(Orig_Terms_Cd);
			dr["DEST_TERMS_CD"] = ClsConvert.ToDbObject(Dest_Terms_Cd);
			dr["TOTALS_STOPOFFS_NBR"] = ClsConvert.ToDbObject(Totals_Stopoffs_Nbr);
			dr["REQ_NAME"] = ClsConvert.ToDbObject(Req_Name);
			dr["REQ_ADDRESS"] = ClsConvert.ToDbObject(Req_Address);
			dr["REQ_CITY"] = ClsConvert.ToDbObject(Req_City);
			dr["REQ_STATE"] = ClsConvert.ToDbObject(Req_State);
			dr["REQ_ZIP"] = ClsConvert.ToDbObject(Req_Zip);
			dr["SHIPPER_NAME"] = ClsConvert.ToDbObject(Shipper_Name);
			dr["SHIPPER_ADDRESS"] = ClsConvert.ToDbObject(Shipper_Address);
			dr["SHIPPER_CITY"] = ClsConvert.ToDbObject(Shipper_City);
			dr["SHIPPER_STATE"] = ClsConvert.ToDbObject(Shipper_State);
			dr["SHIPPER_ZIP"] = ClsConvert.ToDbObject(Shipper_Zip);
			dr["SHIPPER_CONTACT"] = ClsConvert.ToDbObject(Shipper_Contact);
			dr["SHIPPER_PHONE"] = ClsConvert.ToDbObject(Shipper_Phone);
			dr["SHIPPER_FAX"] = ClsConvert.ToDbObject(Shipper_Fax);
			dr["SHIPPER_EMAIL"] = ClsConvert.ToDbObject(Shipper_Email);
			dr["BOOKER_NAME"] = ClsConvert.ToDbObject(Booker_Name);
			dr["BOOKER_ADDRESS"] = ClsConvert.ToDbObject(Booker_Address);
			dr["BOOKER_CITY"] = ClsConvert.ToDbObject(Booker_City);
			dr["BOOKER_STATE"] = ClsConvert.ToDbObject(Booker_State);
			dr["BOOKER_ZIP"] = ClsConvert.ToDbObject(Booker_Zip);
			dr["BOOKER_PHONE"] = ClsConvert.ToDbObject(Booker_Phone);
			dr["BOOKER_FAX"] = ClsConvert.ToDbObject(Booker_Fax);
			dr["BOOKER_EMAIL"] = ClsConvert.ToDbObject(Booker_Email);
			dr["RCVR_NAME"] = ClsConvert.ToDbObject(Rcvr_Name);
			dr["RCVR_ADDRESS"] = ClsConvert.ToDbObject(Rcvr_Address);
			dr["RCVR_CITY"] = ClsConvert.ToDbObject(Rcvr_City);
			dr["RCVR_STATE"] = ClsConvert.ToDbObject(Rcvr_State);
			dr["RCVR_ZIP"] = ClsConvert.ToDbObject(Rcvr_Zip);
			dr["RCVR_PHONE"] = ClsConvert.ToDbObject(Rcvr_Phone);
			dr["RCVR_FAX"] = ClsConvert.ToDbObject(Rcvr_Fax);
			dr["RCVR_EMAIL"] = ClsConvert.ToDbObject(Rcvr_Email);
			dr["RCVR_COUNTRY"] = ClsConvert.ToDbObject(Rcvr_Country);
			dr["POE_TERMINAL_CD"] = ClsConvert.ToDbObject(Poe_Terminal_Cd);
			dr["POD_TERMINAL_CD"] = ClsConvert.ToDbObject(Pod_Terminal_Cd);
			dr["ADJ_RDD_DT"] = ClsConvert.ToDbObject(Adj_Rdd_Dt);
			dr["ADJ_RDD_REASON"] = ClsConvert.ToDbObject(Adj_Rdd_Reason);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["IRCS"] = ClsConvert.ToDbObject(Ircs);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["POE_CENSUS"] = ClsConvert.ToDbObject(Poe_Census);
			dr["POE_DSC"] = ClsConvert.ToDbObject(Poe_Dsc);
			dr["POD_CENSUS"] = ClsConvert.ToDbObject(Pod_Census);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["SHIPPER_ID"] = ClsConvert.ToDbObject(Shipper_ID);
			dr["CONSIGNEE_ID"] = ClsConvert.ToDbObject(Consignee_ID);
			dr["NOTIFY_ID"] = ClsConvert.ToDbObject(Notify_ID);
			dr["CUR_CTL_NO"] = ClsConvert.ToDbObject(Cur_Ctl_No);
			dr["US_OR_FOREIGN"] = ClsConvert.ToDbObject(Us_Or_Foreign);
			dr["EAST_OR_WEST"] = ClsConvert.ToDbObject(East_Or_West);
			dr["CLAUSE_7"] = ClsConvert.ToDbObject(Clause_7);
			dr["CLAUSE_19"] = ClsConvert.ToDbObject(Clause_19);
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