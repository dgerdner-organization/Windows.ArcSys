using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequest : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_REQUEST";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TRANS_CTL_NO", "TRANS_SEQ_NO" };
		}

		public const string SelectSQL = @"SELECT * FROM T_BOOKING_REQUEST 
				LEFT OUTER JOIN R_ACMS_STATUS
				ON T_BOOKING_REQUEST.ACMS_STATUS_CD=R_ACMS_STATUS.ACMS_STATUS_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Acms_Status_CdMax = 2;
		public const int Confirm_CdMax = 2;
		public const int Booking_IDMax = 30;
		public const int Project_CdMax = 30;
		public const int Contract_NoMax = 30;
		public const int Tac_NoMax = 30;
		public const int Fms_Case_NoMax = 30;
		public const int Vessel_IrccMax = 20;
		public const int Vessel_DscMax = 30;
		public const int Vessel_QualifierMax = 2;
		public const int Voyage_NoMax = 10;
		public const int Mil_Voyage_NoMax = 10;
		public const int Poe_CdMax = 10;
		public const int Poe_DscMax = 30;
		public const int Poe_QualifierMax = 2;
		public const int Pod_CdMax = 10;
		public const int Pod_DscMax = 30;
		public const int Pod_QualifierMax = 2;
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
		public const int Vessel_CdMax = 4;
		public const int Pod_Location_CdMax = 10;
		public const int Poe_Location_CdMax = 10;
		public const int Rcvr_CountryMax = 2;
		public const int Delivery_Dsc2Max = 60;
		public const int Hazmat_CdMax = 10;
		public const int Hazmat_Cd_QualifierMax = 2;
		public const int Hazmat_Class_CdMax = 10;
		public const int Hazmat_DscMax = 50;
		public const int Hazmat_ContactMax = 50;
		public const int Special_Handling_CdMax = 250;
		public const int Shipper_DodaacMax = 20;
		public const int Rcvr_DodaacMax = 20;
		public const int Req_DodaacMax = 20;
		public const int Booker_DodaacMax = 20;
		public const int Port_To_Door_FlgMax = 1;
		public const int Move_Type_CdMax = 5;
		public const int Sea_Air_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Trans_Ctl_No;
		protected Int64? _Trans_Seq_No;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Acms_Status_Cd;
		protected string _Confirm_Cd;
		protected string _Booking_ID;
		protected DateTime? _Request_Dt;
		protected string _Project_Cd;
		protected string _Contract_No;
		protected string _Tac_No;
		protected string _Fms_Case_No;
		protected string _Vessel_Ircc;
		protected string _Vessel_Dsc;
		protected string _Vessel_Qualifier;
		protected string _Voyage_No;
		protected string _Mil_Voyage_No;
		protected DateTime? _Sail_Dt;
		protected string _Poe_Cd;
		protected string _Poe_Dsc;
		protected string _Poe_Qualifier;
		protected string _Pod_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Qualifier;
		protected DateTime? _Cargo_Avail_Dt;
		protected DateTime? _Rdd_Dt;
		protected string _Delivery_Dsc;
		protected Int32? _Ship_Units_Nbr;
		protected string _Cargo_Cd;
		protected string _Iso_Eqp_Type_Cd;
		protected string _Orig_Terms_Cd;
		protected string _Dest_Terms_Cd;
		protected Int32? _Totals_Stopoffs_Nbr;
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
		protected string _Vessel_Cd;
		protected string _Pod_Location_Cd;
		protected string _Poe_Location_Cd;
		protected string _Rcvr_Country;
		protected string _Delivery_Dsc2;
		protected string _Hazmat_Cd;
		protected string _Hazmat_Cd_Qualifier;
		protected string _Hazmat_Class_Cd;
		protected string _Hazmat_Dsc;
		protected string _Hazmat_Contact;
		protected string _Special_Handling_Cd;
		protected string _Shipper_Dodaac;
		protected string _Rcvr_Dodaac;
		protected string _Req_Dodaac;
		protected string _Booker_Dodaac;
		protected string _Port_To_Door_Flg;
		protected string _Move_Type_Cd;
		protected string _Sea_Air_Flg;
		protected DateTime? _Modify_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Trans_Ctl_No
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
		public Int64? Trans_Seq_No
		{
			get { return _Trans_Seq_No; }
			set
			{
				if( _Trans_Seq_No == value ) return;
		
				_Trans_Seq_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Seq_No");
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
		public string Confirm_Cd
		{
			get { return _Confirm_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Confirm_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Confirm_CdMax )
					_Confirm_Cd = val.Substring(0, (int)Confirm_CdMax);
				else
					_Confirm_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Confirm_Cd");
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
		public string Vessel_Ircc
		{
			get { return _Vessel_Ircc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Ircc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_IrccMax )
					_Vessel_Ircc = val.Substring(0, (int)Vessel_IrccMax);
				else
					_Vessel_Ircc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Ircc");
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
		public string Vessel_Qualifier
		{
			get { return _Vessel_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_QualifierMax )
					_Vessel_Qualifier = val.Substring(0, (int)Vessel_QualifierMax);
				else
					_Vessel_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Qualifier");
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
		public string Mil_Voyage_No
		{
			get { return _Mil_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mil_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Mil_Voyage_NoMax )
					_Mil_Voyage_No = val.Substring(0, (int)Mil_Voyage_NoMax);
				else
					_Mil_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mil_Voyage_No");
			}
		}
		public DateTime? Sail_Dt
		{
			get { return _Sail_Dt; }
			set
			{
				if( _Sail_Dt == value ) return;
		
				_Sail_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}
		public string Poe_Cd
		{
			get { return _Poe_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_CdMax )
					_Poe_Cd = val.Substring(0, (int)Poe_CdMax);
				else
					_Poe_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Cd");
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
		public string Poe_Qualifier
		{
			get { return _Poe_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_QualifierMax )
					_Poe_Qualifier = val.Substring(0, (int)Poe_QualifierMax);
				else
					_Poe_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Qualifier");
			}
		}
		public string Pod_Cd
		{
			get { return _Pod_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_CdMax )
					_Pod_Cd = val.Substring(0, (int)Pod_CdMax);
				else
					_Pod_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Cd");
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
		public string Pod_Qualifier
		{
			get { return _Pod_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_QualifierMax )
					_Pod_Qualifier = val.Substring(0, (int)Pod_QualifierMax);
				else
					_Pod_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Qualifier");
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
		public Int32? Ship_Units_Nbr
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
		public Int32? Totals_Stopoffs_Nbr
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
		public string Delivery_Dsc2
		{
			get { return _Delivery_Dsc2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Dsc2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_Dsc2Max )
					_Delivery_Dsc2 = val.Substring(0, (int)Delivery_Dsc2Max);
				else
					_Delivery_Dsc2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dsc2");
			}
		}
		public string Hazmat_Cd
		{
			get { return _Hazmat_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_CdMax )
					_Hazmat_Cd = val.Substring(0, (int)Hazmat_CdMax);
				else
					_Hazmat_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Cd");
			}
		}
		public string Hazmat_Cd_Qualifier
		{
			get { return _Hazmat_Cd_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Cd_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_Cd_QualifierMax )
					_Hazmat_Cd_Qualifier = val.Substring(0, (int)Hazmat_Cd_QualifierMax);
				else
					_Hazmat_Cd_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Cd_Qualifier");
			}
		}
		public string Hazmat_Class_Cd
		{
			get { return _Hazmat_Class_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Class_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_Class_CdMax )
					_Hazmat_Class_Cd = val.Substring(0, (int)Hazmat_Class_CdMax);
				else
					_Hazmat_Class_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Class_Cd");
			}
		}
		public string Hazmat_Dsc
		{
			get { return _Hazmat_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_DscMax )
					_Hazmat_Dsc = val.Substring(0, (int)Hazmat_DscMax);
				else
					_Hazmat_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Dsc");
			}
		}
		public string Hazmat_Contact
		{
			get { return _Hazmat_Contact; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Contact, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_ContactMax )
					_Hazmat_Contact = val.Substring(0, (int)Hazmat_ContactMax);
				else
					_Hazmat_Contact = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Contact");
			}
		}
		public string Special_Handling_Cd
		{
			get { return _Special_Handling_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Special_Handling_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Special_Handling_CdMax )
					_Special_Handling_Cd = val.Substring(0, (int)Special_Handling_CdMax);
				else
					_Special_Handling_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Special_Handling_Cd");
			}
		}
		public string Shipper_Dodaac
		{
			get { return _Shipper_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_DodaacMax )
					_Shipper_Dodaac = val.Substring(0, (int)Shipper_DodaacMax);
				else
					_Shipper_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Dodaac");
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
		public string Req_Dodaac
		{
			get { return _Req_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_DodaacMax )
					_Req_Dodaac = val.Substring(0, (int)Req_DodaacMax);
				else
					_Req_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Dodaac");
			}
		}
		public string Booker_Dodaac
		{
			get { return _Booker_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_DodaacMax )
					_Booker_Dodaac = val.Substring(0, (int)Booker_DodaacMax);
				else
					_Booker_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Dodaac");
			}
		}
		public string Port_To_Door_Flg
		{
			get { return _Port_To_Door_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Port_To_Door_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Port_To_Door_FlgMax )
					_Port_To_Door_Flg = val.Substring(0, (int)Port_To_Door_FlgMax);
				else
					_Port_To_Door_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Port_To_Door_Flg");
			}
		}
		public string Move_Type_Cd
		{
			get { return _Move_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Move_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Move_Type_CdMax )
					_Move_Type_Cd = val.Substring(0, (int)Move_Type_CdMax);
				else
					_Move_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Move_Type_Cd");
			}
		}
		public string Sea_Air_Flg
		{
			get { return _Sea_Air_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Sea_Air_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Sea_Air_FlgMax )
					_Sea_Air_Flg = val.Substring(0, (int)Sea_Air_FlgMax);
				else
					_Sea_Air_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Sea_Air_Flg");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsAcmsStatus _Acms_Status;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsAcmsStatus Acms_Status
		{
			get
			{
				if( Acms_Status_Cd == null )
					_Acms_Status = null;
				else if( _Acms_Status == null ||
					_Acms_Status.Acms_Status_Cd != Acms_Status_Cd )
					_Acms_Status = ClsAcmsStatus.GetUsingKey(Acms_Status_Cd);
				return _Acms_Status;
			}
			set
			{
				if( _Acms_Status == value ) return;
		
				_Acms_Status = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingRequest() : base() {}
		public ClsBookingRequest(DataRow dr) : base(dr) {}
		public ClsBookingRequest(ClsBookingRequest src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trans_Ctl_No = null;
			Trans_Seq_No = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Acms_Status_Cd = null;
			Confirm_Cd = null;
			Booking_ID = null;
			Request_Dt = null;
			Project_Cd = null;
			Contract_No = null;
			Tac_No = null;
			Fms_Case_No = null;
			Vessel_Ircc = null;
			Vessel_Dsc = null;
			Vessel_Qualifier = null;
			Voyage_No = null;
			Mil_Voyage_No = null;
			Sail_Dt = null;
			Poe_Cd = null;
			Poe_Dsc = null;
			Poe_Qualifier = null;
			Pod_Cd = null;
			Pod_Dsc = null;
			Pod_Qualifier = null;
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
			Vessel_Cd = null;
			Pod_Location_Cd = null;
			Poe_Location_Cd = null;
			Rcvr_Country = null;
			Delivery_Dsc2 = null;
			Hazmat_Cd = null;
			Hazmat_Cd_Qualifier = null;
			Hazmat_Class_Cd = null;
			Hazmat_Dsc = null;
			Hazmat_Contact = null;
			Special_Handling_Cd = null;
			Shipper_Dodaac = null;
			Rcvr_Dodaac = null;
			Req_Dodaac = null;
			Booker_Dodaac = null;
			Port_To_Door_Flg = null;
			Move_Type_Cd = null;
			Sea_Air_Flg = null;
			Modify_Dt = null;
		}

		public void CopyFrom(ClsBookingRequest src)
		{
			Trans_Ctl_No = src._Trans_Ctl_No;
			Trans_Seq_No = src._Trans_Seq_No;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Confirm_Cd = src._Confirm_Cd;
			Booking_ID = src._Booking_ID;
			Request_Dt = src._Request_Dt;
			Project_Cd = src._Project_Cd;
			Contract_No = src._Contract_No;
			Tac_No = src._Tac_No;
			Fms_Case_No = src._Fms_Case_No;
			Vessel_Ircc = src._Vessel_Ircc;
			Vessel_Dsc = src._Vessel_Dsc;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Voyage_No = src._Voyage_No;
			Mil_Voyage_No = src._Mil_Voyage_No;
			Sail_Dt = src._Sail_Dt;
			Poe_Cd = src._Poe_Cd;
			Poe_Dsc = src._Poe_Dsc;
			Poe_Qualifier = src._Poe_Qualifier;
			Pod_Cd = src._Pod_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Qualifier = src._Pod_Qualifier;
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
			Vessel_Cd = src._Vessel_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Poe_Location_Cd = src._Poe_Location_Cd;
			Rcvr_Country = src._Rcvr_Country;
			Delivery_Dsc2 = src._Delivery_Dsc2;
			Hazmat_Cd = src._Hazmat_Cd;
			Hazmat_Cd_Qualifier = src._Hazmat_Cd_Qualifier;
			Hazmat_Class_Cd = src._Hazmat_Class_Cd;
			Hazmat_Dsc = src._Hazmat_Dsc;
			Hazmat_Contact = src._Hazmat_Contact;
			Special_Handling_Cd = src._Special_Handling_Cd;
			Shipper_Dodaac = src._Shipper_Dodaac;
			Rcvr_Dodaac = src._Rcvr_Dodaac;
			Req_Dodaac = src._Req_Dodaac;
			Booker_Dodaac = src._Booker_Dodaac;
			Port_To_Door_Flg = src._Port_To_Door_Flg;
			Move_Type_Cd = src._Move_Type_Cd;
			Sea_Air_Flg = src._Sea_Air_Flg;
			Modify_Dt = src._Modify_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingRequest tmp = ClsBookingRequest.GetUsingKey(Trans_Ctl_No.Value, Trans_Seq_No.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Acms_Status = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[82];

			p[0] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[1] = Connection.GetParameter
				("@TRANS_SEQ_NO", Trans_Seq_No);
			p[2] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[3] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[4] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[5] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[6] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[7] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[8] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[9] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[10] = Connection.GetParameter
				("@TAC_NO", Tac_No);
			p[11] = Connection.GetParameter
				("@FMS_CASE_NO", Fms_Case_No);
			p[12] = Connection.GetParameter
				("@VESSEL_IRCC", Vessel_Ircc);
			p[13] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[14] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[15] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[16] = Connection.GetParameter
				("@MIL_VOYAGE_NO", Mil_Voyage_No);
			p[17] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[18] = Connection.GetParameter
				("@POE_CD", Poe_Cd);
			p[19] = Connection.GetParameter
				("@POE_DSC", Poe_Dsc);
			p[20] = Connection.GetParameter
				("@POE_QUALIFIER", Poe_Qualifier);
			p[21] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[22] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[23] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[24] = Connection.GetParameter
				("@CARGO_AVAIL_DT", Cargo_Avail_Dt);
			p[25] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[26] = Connection.GetParameter
				("@DELIVERY_DSC", Delivery_Dsc);
			p[27] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[28] = Connection.GetParameter
				("@CARGO_CD", Cargo_Cd);
			p[29] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[30] = Connection.GetParameter
				("@ORIG_TERMS_CD", Orig_Terms_Cd);
			p[31] = Connection.GetParameter
				("@DEST_TERMS_CD", Dest_Terms_Cd);
			p[32] = Connection.GetParameter
				("@TOTALS_STOPOFFS_NBR", Totals_Stopoffs_Nbr);
			p[33] = Connection.GetParameter
				("@REQ_NAME", Req_Name);
			p[34] = Connection.GetParameter
				("@REQ_ADDRESS", Req_Address);
			p[35] = Connection.GetParameter
				("@REQ_CITY", Req_City);
			p[36] = Connection.GetParameter
				("@REQ_STATE", Req_State);
			p[37] = Connection.GetParameter
				("@REQ_ZIP", Req_Zip);
			p[38] = Connection.GetParameter
				("@SHIPPER_NAME", Shipper_Name);
			p[39] = Connection.GetParameter
				("@SHIPPER_ADDRESS", Shipper_Address);
			p[40] = Connection.GetParameter
				("@SHIPPER_CITY", Shipper_City);
			p[41] = Connection.GetParameter
				("@SHIPPER_STATE", Shipper_State);
			p[42] = Connection.GetParameter
				("@SHIPPER_ZIP", Shipper_Zip);
			p[43] = Connection.GetParameter
				("@SHIPPER_CONTACT", Shipper_Contact);
			p[44] = Connection.GetParameter
				("@SHIPPER_PHONE", Shipper_Phone);
			p[45] = Connection.GetParameter
				("@SHIPPER_FAX", Shipper_Fax);
			p[46] = Connection.GetParameter
				("@SHIPPER_EMAIL", Shipper_Email);
			p[47] = Connection.GetParameter
				("@BOOKER_NAME", Booker_Name);
			p[48] = Connection.GetParameter
				("@BOOKER_ADDRESS", Booker_Address);
			p[49] = Connection.GetParameter
				("@BOOKER_CITY", Booker_City);
			p[50] = Connection.GetParameter
				("@BOOKER_STATE", Booker_State);
			p[51] = Connection.GetParameter
				("@BOOKER_ZIP", Booker_Zip);
			p[52] = Connection.GetParameter
				("@BOOKER_PHONE", Booker_Phone);
			p[53] = Connection.GetParameter
				("@BOOKER_FAX", Booker_Fax);
			p[54] = Connection.GetParameter
				("@BOOKER_EMAIL", Booker_Email);
			p[55] = Connection.GetParameter
				("@RCVR_NAME", Rcvr_Name);
			p[56] = Connection.GetParameter
				("@RCVR_ADDRESS", Rcvr_Address);
			p[57] = Connection.GetParameter
				("@RCVR_CITY", Rcvr_City);
			p[58] = Connection.GetParameter
				("@RCVR_STATE", Rcvr_State);
			p[59] = Connection.GetParameter
				("@RCVR_ZIP", Rcvr_Zip);
			p[60] = Connection.GetParameter
				("@RCVR_PHONE", Rcvr_Phone);
			p[61] = Connection.GetParameter
				("@RCVR_FAX", Rcvr_Fax);
			p[62] = Connection.GetParameter
				("@RCVR_EMAIL", Rcvr_Email);
			p[63] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[64] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[65] = Connection.GetParameter
				("@POE_LOCATION_CD", Poe_Location_Cd);
			p[66] = Connection.GetParameter
				("@RCVR_COUNTRY", Rcvr_Country);
			p[67] = Connection.GetParameter
				("@DELIVERY_DSC2", Delivery_Dsc2);
			p[68] = Connection.GetParameter
				("@HAZMAT_CD", Hazmat_Cd);
			p[69] = Connection.GetParameter
				("@HAZMAT_CD_QUALIFIER", Hazmat_Cd_Qualifier);
			p[70] = Connection.GetParameter
				("@HAZMAT_CLASS_CD", Hazmat_Class_Cd);
			p[71] = Connection.GetParameter
				("@HAZMAT_DSC", Hazmat_Dsc);
			p[72] = Connection.GetParameter
				("@HAZMAT_CONTACT", Hazmat_Contact);
			p[73] = Connection.GetParameter
				("@SPECIAL_HANDLING_CD", Special_Handling_Cd);
			p[74] = Connection.GetParameter
				("@SHIPPER_DODAAC", Shipper_Dodaac);
			p[75] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[76] = Connection.GetParameter
				("@REQ_DODAAC", Req_Dodaac);
			p[77] = Connection.GetParameter
				("@BOOKER_DODAAC", Booker_Dodaac);
			p[78] = Connection.GetParameter
				("@PORT_TO_DOOR_FLG", Port_To_Door_Flg);
			p[79] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[80] = Connection.GetParameter
				("@SEA_AIR_FLG", Sea_Air_Flg);
			p[81] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_BOOKING_REQUEST
					(TRANS_CTL_NO, TRANS_SEQ_NO, PARTNER_CD,
					PARTNER_REQUEST_CD, ACMS_STATUS_CD, CONFIRM_CD,
					BOOKING_ID, REQUEST_DT, PROJECT_CD,
					CONTRACT_NO, TAC_NO, FMS_CASE_NO,
					VESSEL_IRCC, VESSEL_DSC, VESSEL_QUALIFIER,
					VOYAGE_NO, MIL_VOYAGE_NO, SAIL_DT,
					POE_CD, POE_DSC, POE_QUALIFIER,
					POD_CD, POD_DSC, POD_QUALIFIER,
					CARGO_AVAIL_DT, RDD_DT, DELIVERY_DSC,
					SHIP_UNITS_NBR, CARGO_CD, ISO_EQP_TYPE_CD,
					ORIG_TERMS_CD, DEST_TERMS_CD, TOTALS_STOPOFFS_NBR,
					REQ_NAME, REQ_ADDRESS, REQ_CITY,
					REQ_STATE, REQ_ZIP, SHIPPER_NAME,
					SHIPPER_ADDRESS, SHIPPER_CITY, SHIPPER_STATE,
					SHIPPER_ZIP, SHIPPER_CONTACT, SHIPPER_PHONE,
					SHIPPER_FAX, SHIPPER_EMAIL, BOOKER_NAME,
					BOOKER_ADDRESS, BOOKER_CITY, BOOKER_STATE,
					BOOKER_ZIP, BOOKER_PHONE, BOOKER_FAX,
					BOOKER_EMAIL, RCVR_NAME, RCVR_ADDRESS,
					RCVR_CITY, RCVR_STATE, RCVR_ZIP,
					RCVR_PHONE, RCVR_FAX, RCVR_EMAIL,
					VESSEL_CD, POD_LOCATION_CD, POE_LOCATION_CD,
					RCVR_COUNTRY, DELIVERY_DSC2, HAZMAT_CD,
					HAZMAT_CD_QUALIFIER, HAZMAT_CLASS_CD, HAZMAT_DSC,
					HAZMAT_CONTACT, SPECIAL_HANDLING_CD, SHIPPER_DODAAC,
					RCVR_DODAAC, REQ_DODAAC, BOOKER_DODAAC,
					PORT_TO_DOOR_FLG, MOVE_TYPE_CD, SEA_AIR_FLG)
				VALUES
					(@TRANS_CTL_NO, @TRANS_SEQ_NO, @PARTNER_CD,
					@PARTNER_REQUEST_CD, @ACMS_STATUS_CD, @CONFIRM_CD,
					@BOOKING_ID, @REQUEST_DT, @PROJECT_CD,
					@CONTRACT_NO, @TAC_NO, @FMS_CASE_NO,
					@VESSEL_IRCC, @VESSEL_DSC, @VESSEL_QUALIFIER,
					@VOYAGE_NO, @MIL_VOYAGE_NO, @SAIL_DT,
					@POE_CD, @POE_DSC, @POE_QUALIFIER,
					@POD_CD, @POD_DSC, @POD_QUALIFIER,
					@CARGO_AVAIL_DT, @RDD_DT, @DELIVERY_DSC,
					@SHIP_UNITS_NBR, @CARGO_CD, @ISO_EQP_TYPE_CD,
					@ORIG_TERMS_CD, @DEST_TERMS_CD, @TOTALS_STOPOFFS_NBR,
					@REQ_NAME, @REQ_ADDRESS, @REQ_CITY,
					@REQ_STATE, @REQ_ZIP, @SHIPPER_NAME,
					@SHIPPER_ADDRESS, @SHIPPER_CITY, @SHIPPER_STATE,
					@SHIPPER_ZIP, @SHIPPER_CONTACT, @SHIPPER_PHONE,
					@SHIPPER_FAX, @SHIPPER_EMAIL, @BOOKER_NAME,
					@BOOKER_ADDRESS, @BOOKER_CITY, @BOOKER_STATE,
					@BOOKER_ZIP, @BOOKER_PHONE, @BOOKER_FAX,
					@BOOKER_EMAIL, @RCVR_NAME, @RCVR_ADDRESS,
					@RCVR_CITY, @RCVR_STATE, @RCVR_ZIP,
					@RCVR_PHONE, @RCVR_FAX, @RCVR_EMAIL,
					@VESSEL_CD, @POD_LOCATION_CD, @POE_LOCATION_CD,
					@RCVR_COUNTRY, @DELIVERY_DSC2, @HAZMAT_CD,
					@HAZMAT_CD_QUALIFIER, @HAZMAT_CLASS_CD, @HAZMAT_DSC,
					@HAZMAT_CONTACT, @SPECIAL_HANDLING_CD, @SHIPPER_DODAAC,
					@RCVR_DODAAC, @REQ_DODAAC, @BOOKER_DODAAC,
					@PORT_TO_DOOR_FLG, @MOVE_TYPE_CD, @SEA_AIR_FLG)
				RETURNING
					MODIFY_DT
				INTO
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[81].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[82];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[3] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[4] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[5] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[6] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[7] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[8] = Connection.GetParameter
				("@TAC_NO", Tac_No);
			p[9] = Connection.GetParameter
				("@FMS_CASE_NO", Fms_Case_No);
			p[10] = Connection.GetParameter
				("@VESSEL_IRCC", Vessel_Ircc);
			p[11] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[12] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[13] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[14] = Connection.GetParameter
				("@MIL_VOYAGE_NO", Mil_Voyage_No);
			p[15] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[16] = Connection.GetParameter
				("@POE_CD", Poe_Cd);
			p[17] = Connection.GetParameter
				("@POE_DSC", Poe_Dsc);
			p[18] = Connection.GetParameter
				("@POE_QUALIFIER", Poe_Qualifier);
			p[19] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[20] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[21] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[22] = Connection.GetParameter
				("@CARGO_AVAIL_DT", Cargo_Avail_Dt);
			p[23] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[24] = Connection.GetParameter
				("@DELIVERY_DSC", Delivery_Dsc);
			p[25] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[26] = Connection.GetParameter
				("@CARGO_CD", Cargo_Cd);
			p[27] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[28] = Connection.GetParameter
				("@ORIG_TERMS_CD", Orig_Terms_Cd);
			p[29] = Connection.GetParameter
				("@DEST_TERMS_CD", Dest_Terms_Cd);
			p[30] = Connection.GetParameter
				("@TOTALS_STOPOFFS_NBR", Totals_Stopoffs_Nbr);
			p[31] = Connection.GetParameter
				("@REQ_NAME", Req_Name);
			p[32] = Connection.GetParameter
				("@REQ_ADDRESS", Req_Address);
			p[33] = Connection.GetParameter
				("@REQ_CITY", Req_City);
			p[34] = Connection.GetParameter
				("@REQ_STATE", Req_State);
			p[35] = Connection.GetParameter
				("@REQ_ZIP", Req_Zip);
			p[36] = Connection.GetParameter
				("@SHIPPER_NAME", Shipper_Name);
			p[37] = Connection.GetParameter
				("@SHIPPER_ADDRESS", Shipper_Address);
			p[38] = Connection.GetParameter
				("@SHIPPER_CITY", Shipper_City);
			p[39] = Connection.GetParameter
				("@SHIPPER_STATE", Shipper_State);
			p[40] = Connection.GetParameter
				("@SHIPPER_ZIP", Shipper_Zip);
			p[41] = Connection.GetParameter
				("@SHIPPER_CONTACT", Shipper_Contact);
			p[42] = Connection.GetParameter
				("@SHIPPER_PHONE", Shipper_Phone);
			p[43] = Connection.GetParameter
				("@SHIPPER_FAX", Shipper_Fax);
			p[44] = Connection.GetParameter
				("@SHIPPER_EMAIL", Shipper_Email);
			p[45] = Connection.GetParameter
				("@BOOKER_NAME", Booker_Name);
			p[46] = Connection.GetParameter
				("@BOOKER_ADDRESS", Booker_Address);
			p[47] = Connection.GetParameter
				("@BOOKER_CITY", Booker_City);
			p[48] = Connection.GetParameter
				("@BOOKER_STATE", Booker_State);
			p[49] = Connection.GetParameter
				("@BOOKER_ZIP", Booker_Zip);
			p[50] = Connection.GetParameter
				("@BOOKER_PHONE", Booker_Phone);
			p[51] = Connection.GetParameter
				("@BOOKER_FAX", Booker_Fax);
			p[52] = Connection.GetParameter
				("@BOOKER_EMAIL", Booker_Email);
			p[53] = Connection.GetParameter
				("@RCVR_NAME", Rcvr_Name);
			p[54] = Connection.GetParameter
				("@RCVR_ADDRESS", Rcvr_Address);
			p[55] = Connection.GetParameter
				("@RCVR_CITY", Rcvr_City);
			p[56] = Connection.GetParameter
				("@RCVR_STATE", Rcvr_State);
			p[57] = Connection.GetParameter
				("@RCVR_ZIP", Rcvr_Zip);
			p[58] = Connection.GetParameter
				("@RCVR_PHONE", Rcvr_Phone);
			p[59] = Connection.GetParameter
				("@RCVR_FAX", Rcvr_Fax);
			p[60] = Connection.GetParameter
				("@RCVR_EMAIL", Rcvr_Email);
			p[61] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[62] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[63] = Connection.GetParameter
				("@POE_LOCATION_CD", Poe_Location_Cd);
			p[64] = Connection.GetParameter
				("@RCVR_COUNTRY", Rcvr_Country);
			p[65] = Connection.GetParameter
				("@DELIVERY_DSC2", Delivery_Dsc2);
			p[66] = Connection.GetParameter
				("@HAZMAT_CD", Hazmat_Cd);
			p[67] = Connection.GetParameter
				("@HAZMAT_CD_QUALIFIER", Hazmat_Cd_Qualifier);
			p[68] = Connection.GetParameter
				("@HAZMAT_CLASS_CD", Hazmat_Class_Cd);
			p[69] = Connection.GetParameter
				("@HAZMAT_DSC", Hazmat_Dsc);
			p[70] = Connection.GetParameter
				("@HAZMAT_CONTACT", Hazmat_Contact);
			p[71] = Connection.GetParameter
				("@SPECIAL_HANDLING_CD", Special_Handling_Cd);
			p[72] = Connection.GetParameter
				("@SHIPPER_DODAAC", Shipper_Dodaac);
			p[73] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[74] = Connection.GetParameter
				("@REQ_DODAAC", Req_Dodaac);
			p[75] = Connection.GetParameter
				("@BOOKER_DODAAC", Booker_Dodaac);
			p[76] = Connection.GetParameter
				("@PORT_TO_DOOR_FLG", Port_To_Door_Flg);
			p[77] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[78] = Connection.GetParameter
				("@SEA_AIR_FLG", Sea_Air_Flg);
			p[79] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[80] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[81] = Connection.GetParameter
				("@TRANS_SEQ_NO", Trans_Seq_No);

			const string sql = @"
				UPDATE T_BOOKING_REQUEST SET
					PARTNER_CD = @PARTNER_CD,
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD,
					ACMS_STATUS_CD = @ACMS_STATUS_CD,
					CONFIRM_CD = @CONFIRM_CD,
					BOOKING_ID = @BOOKING_ID,
					REQUEST_DT = @REQUEST_DT,
					PROJECT_CD = @PROJECT_CD,
					CONTRACT_NO = @CONTRACT_NO,
					TAC_NO = @TAC_NO,
					FMS_CASE_NO = @FMS_CASE_NO,
					VESSEL_IRCC = @VESSEL_IRCC,
					VESSEL_DSC = @VESSEL_DSC,
					VESSEL_QUALIFIER = @VESSEL_QUALIFIER,
					VOYAGE_NO = @VOYAGE_NO,
					MIL_VOYAGE_NO = @MIL_VOYAGE_NO,
					SAIL_DT = @SAIL_DT,
					POE_CD = @POE_CD,
					POE_DSC = @POE_DSC,
					POE_QUALIFIER = @POE_QUALIFIER,
					POD_CD = @POD_CD,
					POD_DSC = @POD_DSC,
					POD_QUALIFIER = @POD_QUALIFIER,
					CARGO_AVAIL_DT = @CARGO_AVAIL_DT,
					RDD_DT = @RDD_DT,
					DELIVERY_DSC = @DELIVERY_DSC,
					SHIP_UNITS_NBR = @SHIP_UNITS_NBR,
					CARGO_CD = @CARGO_CD,
					ISO_EQP_TYPE_CD = @ISO_EQP_TYPE_CD,
					ORIG_TERMS_CD = @ORIG_TERMS_CD,
					DEST_TERMS_CD = @DEST_TERMS_CD,
					TOTALS_STOPOFFS_NBR = @TOTALS_STOPOFFS_NBR,
					REQ_NAME = @REQ_NAME,
					REQ_ADDRESS = @REQ_ADDRESS,
					REQ_CITY = @REQ_CITY,
					REQ_STATE = @REQ_STATE,
					REQ_ZIP = @REQ_ZIP,
					SHIPPER_NAME = @SHIPPER_NAME,
					SHIPPER_ADDRESS = @SHIPPER_ADDRESS,
					SHIPPER_CITY = @SHIPPER_CITY,
					SHIPPER_STATE = @SHIPPER_STATE,
					SHIPPER_ZIP = @SHIPPER_ZIP,
					SHIPPER_CONTACT = @SHIPPER_CONTACT,
					SHIPPER_PHONE = @SHIPPER_PHONE,
					SHIPPER_FAX = @SHIPPER_FAX,
					SHIPPER_EMAIL = @SHIPPER_EMAIL,
					BOOKER_NAME = @BOOKER_NAME,
					BOOKER_ADDRESS = @BOOKER_ADDRESS,
					BOOKER_CITY = @BOOKER_CITY,
					BOOKER_STATE = @BOOKER_STATE,
					BOOKER_ZIP = @BOOKER_ZIP,
					BOOKER_PHONE = @BOOKER_PHONE,
					BOOKER_FAX = @BOOKER_FAX,
					BOOKER_EMAIL = @BOOKER_EMAIL,
					RCVR_NAME = @RCVR_NAME,
					RCVR_ADDRESS = @RCVR_ADDRESS,
					RCVR_CITY = @RCVR_CITY,
					RCVR_STATE = @RCVR_STATE,
					RCVR_ZIP = @RCVR_ZIP,
					RCVR_PHONE = @RCVR_PHONE,
					RCVR_FAX = @RCVR_FAX,
					RCVR_EMAIL = @RCVR_EMAIL,
					VESSEL_CD = @VESSEL_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					POE_LOCATION_CD = @POE_LOCATION_CD,
					RCVR_COUNTRY = @RCVR_COUNTRY,
					DELIVERY_DSC2 = @DELIVERY_DSC2,
					HAZMAT_CD = @HAZMAT_CD,
					HAZMAT_CD_QUALIFIER = @HAZMAT_CD_QUALIFIER,
					HAZMAT_CLASS_CD = @HAZMAT_CLASS_CD,
					HAZMAT_DSC = @HAZMAT_DSC,
					HAZMAT_CONTACT = @HAZMAT_CONTACT,
					SPECIAL_HANDLING_CD = @SPECIAL_HANDLING_CD,
					SHIPPER_DODAAC = @SHIPPER_DODAAC,
					RCVR_DODAAC = @RCVR_DODAAC,
					REQ_DODAAC = @REQ_DODAAC,
					BOOKER_DODAAC = @BOOKER_DODAAC,
					PORT_TO_DOOR_FLG = @PORT_TO_DOOR_FLG,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					SEA_AIR_FLG = @SEA_AIR_FLG,
					MODIFY_DT = @MODIFY_DT
				WHERE
					TRANS_CTL_NO = @TRANS_CTL_NO AND
					TRANS_SEQ_NO = @TRANS_SEQ_NO
				RETURNING
					MODIFY_DT
				INTO
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[79].Value);
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

			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO"]);
			Trans_Seq_No = ClsConvert.ToInt64Nullable(dr["TRANS_SEQ_NO"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO"]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO"]);
			Vessel_Ircc = ClsConvert.ToString(dr["VESSEL_IRCC"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Mil_Voyage_No = ClsConvert.ToString(dr["MIL_VOYAGE_NO"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Poe_Cd = ClsConvert.ToString(dr["POE_CD"]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC"]);
			Poe_Qualifier = ClsConvert.ToString(dr["POE_QUALIFIER"]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER"]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC"]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR"]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD"]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD"]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD"]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD"]);
			Totals_Stopoffs_Nbr = ClsConvert.ToInt32Nullable(dr["TOTALS_STOPOFFS_NBR"]);
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
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD"]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY"]);
			Delivery_Dsc2 = ClsConvert.ToString(dr["DELIVERY_DSC2"]);
			Hazmat_Cd = ClsConvert.ToString(dr["HAZMAT_CD"]);
			Hazmat_Cd_Qualifier = ClsConvert.ToString(dr["HAZMAT_CD_QUALIFIER"]);
			Hazmat_Class_Cd = ClsConvert.ToString(dr["HAZMAT_CLASS_CD"]);
			Hazmat_Dsc = ClsConvert.ToString(dr["HAZMAT_DSC"]);
			Hazmat_Contact = ClsConvert.ToString(dr["HAZMAT_CONTACT"]);
			Special_Handling_Cd = ClsConvert.ToString(dr["SPECIAL_HANDLING_CD"]);
			Shipper_Dodaac = ClsConvert.ToString(dr["SHIPPER_DODAAC"]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC"]);
			Req_Dodaac = ClsConvert.ToString(dr["REQ_DODAAC"]);
			Booker_Dodaac = ClsConvert.ToString(dr["BOOKER_DODAAC"]);
			Port_To_Door_Flg = ClsConvert.ToString(dr["PORT_TO_DOOR_FLG"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Sea_Air_Flg = ClsConvert.ToString(dr["SEA_AIR_FLG"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO", v]);
			Trans_Seq_No = ClsConvert.ToInt64Nullable(dr["TRANS_SEQ_NO", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO", v]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO", v]);
			Vessel_Ircc = ClsConvert.ToString(dr["VESSEL_IRCC", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Mil_Voyage_No = ClsConvert.ToString(dr["MIL_VOYAGE_NO", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Poe_Cd = ClsConvert.ToString(dr["POE_CD", v]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC", v]);
			Poe_Qualifier = ClsConvert.ToString(dr["POE_QUALIFIER", v]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER", v]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC", v]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR", v]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD", v]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD", v]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD", v]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD", v]);
			Totals_Stopoffs_Nbr = ClsConvert.ToInt32Nullable(dr["TOTALS_STOPOFFS_NBR", v]);
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
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD", v]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY", v]);
			Delivery_Dsc2 = ClsConvert.ToString(dr["DELIVERY_DSC2", v]);
			Hazmat_Cd = ClsConvert.ToString(dr["HAZMAT_CD", v]);
			Hazmat_Cd_Qualifier = ClsConvert.ToString(dr["HAZMAT_CD_QUALIFIER", v]);
			Hazmat_Class_Cd = ClsConvert.ToString(dr["HAZMAT_CLASS_CD", v]);
			Hazmat_Dsc = ClsConvert.ToString(dr["HAZMAT_DSC", v]);
			Hazmat_Contact = ClsConvert.ToString(dr["HAZMAT_CONTACT", v]);
			Special_Handling_Cd = ClsConvert.ToString(dr["SPECIAL_HANDLING_CD", v]);
			Shipper_Dodaac = ClsConvert.ToString(dr["SHIPPER_DODAAC", v]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC", v]);
			Req_Dodaac = ClsConvert.ToString(dr["REQ_DODAAC", v]);
			Booker_Dodaac = ClsConvert.ToString(dr["BOOKER_DODAAC", v]);
			Port_To_Door_Flg = ClsConvert.ToString(dr["PORT_TO_DOOR_FLG", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Sea_Air_Flg = ClsConvert.ToString(dr["SEA_AIR_FLG", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["TRANS_SEQ_NO"] = ClsConvert.ToDbObject(Trans_Seq_No);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["CONFIRM_CD"] = ClsConvert.ToDbObject(Confirm_Cd);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["PROJECT_CD"] = ClsConvert.ToDbObject(Project_Cd);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["TAC_NO"] = ClsConvert.ToDbObject(Tac_No);
			dr["FMS_CASE_NO"] = ClsConvert.ToDbObject(Fms_Case_No);
			dr["VESSEL_IRCC"] = ClsConvert.ToDbObject(Vessel_Ircc);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["MIL_VOYAGE_NO"] = ClsConvert.ToDbObject(Mil_Voyage_No);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["POE_CD"] = ClsConvert.ToDbObject(Poe_Cd);
			dr["POE_DSC"] = ClsConvert.ToDbObject(Poe_Dsc);
			dr["POE_QUALIFIER"] = ClsConvert.ToDbObject(Poe_Qualifier);
			dr["POD_CD"] = ClsConvert.ToDbObject(Pod_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["POD_QUALIFIER"] = ClsConvert.ToDbObject(Pod_Qualifier);
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
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POE_LOCATION_CD"] = ClsConvert.ToDbObject(Poe_Location_Cd);
			dr["RCVR_COUNTRY"] = ClsConvert.ToDbObject(Rcvr_Country);
			dr["DELIVERY_DSC2"] = ClsConvert.ToDbObject(Delivery_Dsc2);
			dr["HAZMAT_CD"] = ClsConvert.ToDbObject(Hazmat_Cd);
			dr["HAZMAT_CD_QUALIFIER"] = ClsConvert.ToDbObject(Hazmat_Cd_Qualifier);
			dr["HAZMAT_CLASS_CD"] = ClsConvert.ToDbObject(Hazmat_Class_Cd);
			dr["HAZMAT_DSC"] = ClsConvert.ToDbObject(Hazmat_Dsc);
			dr["HAZMAT_CONTACT"] = ClsConvert.ToDbObject(Hazmat_Contact);
			dr["SPECIAL_HANDLING_CD"] = ClsConvert.ToDbObject(Special_Handling_Cd);
			dr["SHIPPER_DODAAC"] = ClsConvert.ToDbObject(Shipper_Dodaac);
			dr["RCVR_DODAAC"] = ClsConvert.ToDbObject(Rcvr_Dodaac);
			dr["REQ_DODAAC"] = ClsConvert.ToDbObject(Req_Dodaac);
			dr["BOOKER_DODAAC"] = ClsConvert.ToDbObject(Booker_Dodaac);
			dr["PORT_TO_DOOR_FLG"] = ClsConvert.ToDbObject(Port_To_Door_Flg);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["SEA_AIR_FLG"] = ClsConvert.ToDbObject(Sea_Air_Flg);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
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

		public static ClsBookingRequest GetUsingKey(Int64 Trans_Ctl_No, Int64 Trans_Seq_No)
		{
			object[] vals = new object[] {Trans_Ctl_No, Trans_Seq_No};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingRequest(dr);
		}
		public static DataTable GetAll(string Acms_Status_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Acms_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ACMS_STATUS_CD", Acms_Status_Cd));
				sb.Append(" WHERE T_BOOKING_REQUEST.ACMS_STATUS_CD=@ACMS_STATUS_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}