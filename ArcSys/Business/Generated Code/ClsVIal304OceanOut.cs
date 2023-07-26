using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVIal304OceanOut : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_IAL_304_OCEAN_OUT";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_IAL_304_OCEAN_OUT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int GroupidMax = 0;
		public const int Booking_NoMax = 20;
		public const int East_Or_WestMax = 1;
		public const int Queue_StatusMax = 2;
		public const int VoyageMax = 10;
		public const int VesselMax = 10;
		public const int CarrierMax = 4;
		public const int Orig_LocationMax = 10;
		public const int Dest_LocationMax = 10;
		public const int Not_PartyMax = 50;
		public const int Not_Party2Max = 0;
		public const int Not_Address_1Max = 50;
		public const int Not_Address_2Max = 50;
		public const int Not_Address_3Max = 50;
		public const int Not_Address_CityMax = 50;
		public const int Not_Address_StateMax = 2;
		public const int Not_Address_CountryMax = 3;
		public const int Not_Address_ZipMax = 10;
		public const int Ship_PartyMax = 50;
		public const int Ship_Address_1Max = 50;
		public const int Ship_Address_2Max = 50;
		public const int Ship_Address_3Max = 50;
		public const int Ship_Address_CityMax = 50;
		public const int Ship_Address_StateMax = 2;
		public const int Ship_Address_CountryMax = 3;
		public const int Ship_Address_ZipMax = 10;
		public const int Also_PartyMax = 50;
		public const int Also_Address_1Max = 50;
		public const int Also_Address_2Max = 50;
		public const int Also_Address_3Max = 50;
		public const int Also_Address_CityMax = 50;
		public const int Also_Address_StateMax = 2;
		public const int Also_Address_CountryMax = 3;
		public const int Also_Address_ZipMax = 10;
		public const int Dest_CensusMax = 30;
		public const int Orig_CensusMax = 30;
		public const int Vessel_IrcsMax = 10;
		public const int Vessel_DscMax = 50;
		public const int Clause_19Max = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Control_ID;
		protected string _Groupid;
		protected string _Booking_No;
		protected string _East_Or_West;
		protected string _Queue_Status;
		protected string _Voyage;
		protected string _Vessel;
		protected string _Carrier;
		protected string _Orig_Location;
		protected string _Dest_Location;
		protected string _Not_Party;
		protected string _Not_Party2;
		protected string _Not_Address_1;
		protected string _Not_Address_2;
		protected string _Not_Address_3;
		protected string _Not_Address_City;
		protected string _Not_Address_State;
		protected string _Not_Address_Country;
		protected string _Not_Address_Zip;
		protected string _Ship_Party;
		protected string _Ship_Address_1;
		protected string _Ship_Address_2;
		protected string _Ship_Address_3;
		protected string _Ship_Address_City;
		protected string _Ship_Address_State;
		protected string _Ship_Address_Country;
		protected string _Ship_Address_Zip;
		protected string _Also_Party;
		protected string _Also_Address_1;
		protected string _Also_Address_2;
		protected string _Also_Address_3;
		protected string _Also_Address_City;
		protected string _Also_Address_State;
		protected string _Also_Address_Country;
		protected string _Also_Address_Zip;
		protected string _Dest_Census;
		protected string _Orig_Census;
		protected string _Vessel_Ircs;
		protected string _Vessel_Dsc;
		protected decimal? _Shipper_ID;
		protected decimal? _Consignee_ID;
		protected decimal? _Notify_ID;
		protected string _Clause_19;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Control_ID
		{
			get { return _Control_ID; }
			set
			{
				if( _Control_ID == value ) return;
		
				_Control_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Control_ID");
			}
		}
		public string Groupid
		{
			get { return _Groupid; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Groupid, val, false) == 0 ) return;
		
				if( val != null && val.Length > GroupidMax )
					_Groupid = val.Substring(0, (int)GroupidMax);
				else
					_Groupid = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Groupid");
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
		public string Queue_Status
		{
			get { return _Queue_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Queue_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Queue_StatusMax )
					_Queue_Status = val.Substring(0, (int)Queue_StatusMax);
				else
					_Queue_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Queue_Status");
			}
		}
		public string Voyage
		{
			get { return _Voyage; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage, val, false) == 0 ) return;
		
				if( val != null && val.Length > VoyageMax )
					_Voyage = val.Substring(0, (int)VoyageMax);
				else
					_Voyage = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage");
			}
		}
		public string Vessel
		{
			get { return _Vessel; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel, val, false) == 0 ) return;
		
				if( val != null && val.Length > VesselMax )
					_Vessel = val.Substring(0, (int)VesselMax);
				else
					_Vessel = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel");
			}
		}
		public string Carrier
		{
			get { return _Carrier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Carrier, val, false) == 0 ) return;
		
				if( val != null && val.Length > CarrierMax )
					_Carrier = val.Substring(0, (int)CarrierMax);
				else
					_Carrier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Carrier");
			}
		}
		public string Orig_Location
		{
			get { return _Orig_Location; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Location, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_LocationMax )
					_Orig_Location = val.Substring(0, (int)Orig_LocationMax);
				else
					_Orig_Location = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Location");
			}
		}
		public string Dest_Location
		{
			get { return _Dest_Location; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Location, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_LocationMax )
					_Dest_Location = val.Substring(0, (int)Dest_LocationMax);
				else
					_Dest_Location = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Location");
			}
		}
		public string Not_Party
		{
			get { return _Not_Party; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Party, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_PartyMax )
					_Not_Party = val.Substring(0, (int)Not_PartyMax);
				else
					_Not_Party = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Party");
			}
		}
		public string Not_Party2
		{
			get { return _Not_Party2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Party2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Party2Max )
					_Not_Party2 = val.Substring(0, (int)Not_Party2Max);
				else
					_Not_Party2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Party2");
			}
		}
		public string Not_Address_1
		{
			get { return _Not_Address_1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_1Max )
					_Not_Address_1 = val.Substring(0, (int)Not_Address_1Max);
				else
					_Not_Address_1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_1");
			}
		}
		public string Not_Address_2
		{
			get { return _Not_Address_2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_2Max )
					_Not_Address_2 = val.Substring(0, (int)Not_Address_2Max);
				else
					_Not_Address_2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_2");
			}
		}
		public string Not_Address_3
		{
			get { return _Not_Address_3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_3Max )
					_Not_Address_3 = val.Substring(0, (int)Not_Address_3Max);
				else
					_Not_Address_3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_3");
			}
		}
		public string Not_Address_City
		{
			get { return _Not_Address_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_CityMax )
					_Not_Address_City = val.Substring(0, (int)Not_Address_CityMax);
				else
					_Not_Address_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_City");
			}
		}
		public string Not_Address_State
		{
			get { return _Not_Address_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_StateMax )
					_Not_Address_State = val.Substring(0, (int)Not_Address_StateMax);
				else
					_Not_Address_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_State");
			}
		}
		public string Not_Address_Country
		{
			get { return _Not_Address_Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_CountryMax )
					_Not_Address_Country = val.Substring(0, (int)Not_Address_CountryMax);
				else
					_Not_Address_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_Country");
			}
		}
		public string Not_Address_Zip
		{
			get { return _Not_Address_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Not_Address_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Not_Address_ZipMax )
					_Not_Address_Zip = val.Substring(0, (int)Not_Address_ZipMax);
				else
					_Not_Address_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Not_Address_Zip");
			}
		}
		public string Ship_Party
		{
			get { return _Ship_Party; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Party, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_PartyMax )
					_Ship_Party = val.Substring(0, (int)Ship_PartyMax);
				else
					_Ship_Party = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Party");
			}
		}
		public string Ship_Address_1
		{
			get { return _Ship_Address_1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_1Max )
					_Ship_Address_1 = val.Substring(0, (int)Ship_Address_1Max);
				else
					_Ship_Address_1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_1");
			}
		}
		public string Ship_Address_2
		{
			get { return _Ship_Address_2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_2Max )
					_Ship_Address_2 = val.Substring(0, (int)Ship_Address_2Max);
				else
					_Ship_Address_2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_2");
			}
		}
		public string Ship_Address_3
		{
			get { return _Ship_Address_3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_3Max )
					_Ship_Address_3 = val.Substring(0, (int)Ship_Address_3Max);
				else
					_Ship_Address_3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_3");
			}
		}
		public string Ship_Address_City
		{
			get { return _Ship_Address_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_CityMax )
					_Ship_Address_City = val.Substring(0, (int)Ship_Address_CityMax);
				else
					_Ship_Address_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_City");
			}
		}
		public string Ship_Address_State
		{
			get { return _Ship_Address_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_StateMax )
					_Ship_Address_State = val.Substring(0, (int)Ship_Address_StateMax);
				else
					_Ship_Address_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_State");
			}
		}
		public string Ship_Address_Country
		{
			get { return _Ship_Address_Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_CountryMax )
					_Ship_Address_Country = val.Substring(0, (int)Ship_Address_CountryMax);
				else
					_Ship_Address_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_Country");
			}
		}
		public string Ship_Address_Zip
		{
			get { return _Ship_Address_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ship_Address_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ship_Address_ZipMax )
					_Ship_Address_Zip = val.Substring(0, (int)Ship_Address_ZipMax);
				else
					_Ship_Address_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Address_Zip");
			}
		}
		public string Also_Party
		{
			get { return _Also_Party; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Party, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_PartyMax )
					_Also_Party = val.Substring(0, (int)Also_PartyMax);
				else
					_Also_Party = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Party");
			}
		}
		public string Also_Address_1
		{
			get { return _Also_Address_1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_1Max )
					_Also_Address_1 = val.Substring(0, (int)Also_Address_1Max);
				else
					_Also_Address_1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_1");
			}
		}
		public string Also_Address_2
		{
			get { return _Also_Address_2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_2Max )
					_Also_Address_2 = val.Substring(0, (int)Also_Address_2Max);
				else
					_Also_Address_2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_2");
			}
		}
		public string Also_Address_3
		{
			get { return _Also_Address_3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_3Max )
					_Also_Address_3 = val.Substring(0, (int)Also_Address_3Max);
				else
					_Also_Address_3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_3");
			}
		}
		public string Also_Address_City
		{
			get { return _Also_Address_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_CityMax )
					_Also_Address_City = val.Substring(0, (int)Also_Address_CityMax);
				else
					_Also_Address_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_City");
			}
		}
		public string Also_Address_State
		{
			get { return _Also_Address_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_StateMax )
					_Also_Address_State = val.Substring(0, (int)Also_Address_StateMax);
				else
					_Also_Address_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_State");
			}
		}
		public string Also_Address_Country
		{
			get { return _Also_Address_Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_CountryMax )
					_Also_Address_Country = val.Substring(0, (int)Also_Address_CountryMax);
				else
					_Also_Address_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_Country");
			}
		}
		public string Also_Address_Zip
		{
			get { return _Also_Address_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Also_Address_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Also_Address_ZipMax )
					_Also_Address_Zip = val.Substring(0, (int)Also_Address_ZipMax);
				else
					_Also_Address_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Also_Address_Zip");
			}
		}
		public string Dest_Census
		{
			get { return _Dest_Census; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Census, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_CensusMax )
					_Dest_Census = val.Substring(0, (int)Dest_CensusMax);
				else
					_Dest_Census = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Census");
			}
		}
		public string Orig_Census
		{
			get { return _Orig_Census; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Census, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_CensusMax )
					_Orig_Census = val.Substring(0, (int)Orig_CensusMax);
				else
					_Orig_Census = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Census");
			}
		}
		public string Vessel_Ircs
		{
			get { return _Vessel_Ircs; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Ircs, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_IrcsMax )
					_Vessel_Ircs = val.Substring(0, (int)Vessel_IrcsMax);
				else
					_Vessel_Ircs = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Ircs");
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
		public decimal? Shipper_ID
		{
			get { return _Shipper_ID; }
			set
			{
				if( _Shipper_ID == value ) return;
		
				_Shipper_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_ID");
			}
		}
		public decimal? Consignee_ID
		{
			get { return _Consignee_ID; }
			set
			{
				if( _Consignee_ID == value ) return;
		
				_Consignee_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Consignee_ID");
			}
		}
		public decimal? Notify_ID
		{
			get { return _Notify_ID; }
			set
			{
				if( _Notify_ID == value ) return;
		
				_Notify_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Notify_ID");
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

		public ClsVIal304OceanOut() : base() {}
		public ClsVIal304OceanOut(DataRow dr) : base(dr) {}
		public ClsVIal304OceanOut(ClsVIal304OceanOut src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Control_ID = null;
			Groupid = null;
			Booking_No = null;
			East_Or_West = null;
			Queue_Status = null;
			Voyage = null;
			Vessel = null;
			Carrier = null;
			Orig_Location = null;
			Dest_Location = null;
			Not_Party = null;
			Not_Party2 = null;
			Not_Address_1 = null;
			Not_Address_2 = null;
			Not_Address_3 = null;
			Not_Address_City = null;
			Not_Address_State = null;
			Not_Address_Country = null;
			Not_Address_Zip = null;
			Ship_Party = null;
			Ship_Address_1 = null;
			Ship_Address_2 = null;
			Ship_Address_3 = null;
			Ship_Address_City = null;
			Ship_Address_State = null;
			Ship_Address_Country = null;
			Ship_Address_Zip = null;
			Also_Party = null;
			Also_Address_1 = null;
			Also_Address_2 = null;
			Also_Address_3 = null;
			Also_Address_City = null;
			Also_Address_State = null;
			Also_Address_Country = null;
			Also_Address_Zip = null;
			Dest_Census = null;
			Orig_Census = null;
			Vessel_Ircs = null;
			Vessel_Dsc = null;
			Shipper_ID = null;
			Consignee_ID = null;
			Notify_ID = null;
			Clause_19 = null;
		}

		public void CopyFrom(ClsVIal304OceanOut src)
		{
			Control_ID = src._Control_ID;
			Groupid = src._Groupid;
			Booking_No = src._Booking_No;
			East_Or_West = src._East_Or_West;
			Queue_Status = src._Queue_Status;
			Voyage = src._Voyage;
			Vessel = src._Vessel;
			Carrier = src._Carrier;
			Orig_Location = src._Orig_Location;
			Dest_Location = src._Dest_Location;
			Not_Party = src._Not_Party;
			Not_Party2 = src._Not_Party2;
			Not_Address_1 = src._Not_Address_1;
			Not_Address_2 = src._Not_Address_2;
			Not_Address_3 = src._Not_Address_3;
			Not_Address_City = src._Not_Address_City;
			Not_Address_State = src._Not_Address_State;
			Not_Address_Country = src._Not_Address_Country;
			Not_Address_Zip = src._Not_Address_Zip;
			Ship_Party = src._Ship_Party;
			Ship_Address_1 = src._Ship_Address_1;
			Ship_Address_2 = src._Ship_Address_2;
			Ship_Address_3 = src._Ship_Address_3;
			Ship_Address_City = src._Ship_Address_City;
			Ship_Address_State = src._Ship_Address_State;
			Ship_Address_Country = src._Ship_Address_Country;
			Ship_Address_Zip = src._Ship_Address_Zip;
			Also_Party = src._Also_Party;
			Also_Address_1 = src._Also_Address_1;
			Also_Address_2 = src._Also_Address_2;
			Also_Address_3 = src._Also_Address_3;
			Also_Address_City = src._Also_Address_City;
			Also_Address_State = src._Also_Address_State;
			Also_Address_Country = src._Also_Address_Country;
			Also_Address_Zip = src._Also_Address_Zip;
			Dest_Census = src._Dest_Census;
			Orig_Census = src._Orig_Census;
			Vessel_Ircs = src._Vessel_Ircs;
			Vessel_Dsc = src._Vessel_Dsc;
			Shipper_ID = src._Shipper_ID;
			Consignee_ID = src._Consignee_ID;
			Notify_ID = src._Notify_ID;
			Clause_19 = src._Clause_19;
		}

		public override bool ReloadFromDB()
		{
			ClsVIal304OceanOut tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[43];

			p[0] = Connection.GetParameter
				("@CONTROL_ID", Control_ID);
			p[1] = Connection.GetParameter
				("@GROUPID", Groupid);
			p[2] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[3] = Connection.GetParameter
				("@EAST_OR_WEST", East_Or_West);
			p[4] = Connection.GetParameter
				("@QUEUE_STATUS", Queue_Status);
			p[5] = Connection.GetParameter
				("@VOYAGE", Voyage);
			p[6] = Connection.GetParameter
				("@VESSEL", Vessel);
			p[7] = Connection.GetParameter
				("@CARRIER", Carrier);
			p[8] = Connection.GetParameter
				("@ORIG_LOCATION", Orig_Location);
			p[9] = Connection.GetParameter
				("@DEST_LOCATION", Dest_Location);
			p[10] = Connection.GetParameter
				("@NOT_PARTY", Not_Party);
			p[11] = Connection.GetParameter
				("@NOT_PARTY2", Not_Party2);
			p[12] = Connection.GetParameter
				("@NOT_ADDRESS_1", Not_Address_1);
			p[13] = Connection.GetParameter
				("@NOT_ADDRESS_2", Not_Address_2);
			p[14] = Connection.GetParameter
				("@NOT_ADDRESS_3", Not_Address_3);
			p[15] = Connection.GetParameter
				("@NOT_ADDRESS_CITY", Not_Address_City);
			p[16] = Connection.GetParameter
				("@NOT_ADDRESS_STATE", Not_Address_State);
			p[17] = Connection.GetParameter
				("@NOT_ADDRESS_COUNTRY", Not_Address_Country);
			p[18] = Connection.GetParameter
				("@NOT_ADDRESS_ZIP", Not_Address_Zip);
			p[19] = Connection.GetParameter
				("@SHIP_PARTY", Ship_Party);
			p[20] = Connection.GetParameter
				("@SHIP_ADDRESS_1", Ship_Address_1);
			p[21] = Connection.GetParameter
				("@SHIP_ADDRESS_2", Ship_Address_2);
			p[22] = Connection.GetParameter
				("@SHIP_ADDRESS_3", Ship_Address_3);
			p[23] = Connection.GetParameter
				("@SHIP_ADDRESS_CITY", Ship_Address_City);
			p[24] = Connection.GetParameter
				("@SHIP_ADDRESS_STATE", Ship_Address_State);
			p[25] = Connection.GetParameter
				("@SHIP_ADDRESS_COUNTRY", Ship_Address_Country);
			p[26] = Connection.GetParameter
				("@SHIP_ADDRESS_ZIP", Ship_Address_Zip);
			p[27] = Connection.GetParameter
				("@ALSO_PARTY", Also_Party);
			p[28] = Connection.GetParameter
				("@ALSO_ADDRESS_1", Also_Address_1);
			p[29] = Connection.GetParameter
				("@ALSO_ADDRESS_2", Also_Address_2);
			p[30] = Connection.GetParameter
				("@ALSO_ADDRESS_3", Also_Address_3);
			p[31] = Connection.GetParameter
				("@ALSO_ADDRESS_CITY", Also_Address_City);
			p[32] = Connection.GetParameter
				("@ALSO_ADDRESS_STATE", Also_Address_State);
			p[33] = Connection.GetParameter
				("@ALSO_ADDRESS_COUNTRY", Also_Address_Country);
			p[34] = Connection.GetParameter
				("@ALSO_ADDRESS_ZIP", Also_Address_Zip);
			p[35] = Connection.GetParameter
				("@DEST_CENSUS", Dest_Census);
			p[36] = Connection.GetParameter
				("@ORIG_CENSUS", Orig_Census);
			p[37] = Connection.GetParameter
				("@VESSEL_IRCS", Vessel_Ircs);
			p[38] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[39] = Connection.GetParameter
				("@SHIPPER_ID", Shipper_ID);
			p[40] = Connection.GetParameter
				("@CONSIGNEE_ID", Consignee_ID);
			p[41] = Connection.GetParameter
				("@NOTIFY_ID", Notify_ID);
			p[42] = Connection.GetParameter
				("@CLAUSE_19", Clause_19);

			const string sql = @"
				INSERT INTO V_IAL_304_OCEAN_OUT
					(CONTROL_ID, GROUPID, BOOKING_NO,
					EAST_OR_WEST, QUEUE_STATUS, VOYAGE,
					VESSEL, CARRIER, ORIG_LOCATION,
					DEST_LOCATION, NOT_PARTY, NOT_PARTY2,
					NOT_ADDRESS_1, NOT_ADDRESS_2, NOT_ADDRESS_3,
					NOT_ADDRESS_CITY, NOT_ADDRESS_STATE, NOT_ADDRESS_COUNTRY,
					NOT_ADDRESS_ZIP, SHIP_PARTY, SHIP_ADDRESS_1,
					SHIP_ADDRESS_2, SHIP_ADDRESS_3, SHIP_ADDRESS_CITY,
					SHIP_ADDRESS_STATE, SHIP_ADDRESS_COUNTRY, SHIP_ADDRESS_ZIP,
					ALSO_PARTY, ALSO_ADDRESS_1, ALSO_ADDRESS_2,
					ALSO_ADDRESS_3, ALSO_ADDRESS_CITY, ALSO_ADDRESS_STATE,
					ALSO_ADDRESS_COUNTRY, ALSO_ADDRESS_ZIP, DEST_CENSUS,
					ORIG_CENSUS, VESSEL_IRCS, VESSEL_DSC,
					SHIPPER_ID, CONSIGNEE_ID, NOTIFY_ID,
					CLAUSE_19)
				VALUES
					(@CONTROL_ID, @GROUPID, @BOOKING_NO,
					@EAST_OR_WEST, @QUEUE_STATUS, @VOYAGE,
					@VESSEL, @CARRIER, @ORIG_LOCATION,
					@DEST_LOCATION, @NOT_PARTY, @NOT_PARTY2,
					@NOT_ADDRESS_1, @NOT_ADDRESS_2, @NOT_ADDRESS_3,
					@NOT_ADDRESS_CITY, @NOT_ADDRESS_STATE, @NOT_ADDRESS_COUNTRY,
					@NOT_ADDRESS_ZIP, @SHIP_PARTY, @SHIP_ADDRESS_1,
					@SHIP_ADDRESS_2, @SHIP_ADDRESS_3, @SHIP_ADDRESS_CITY,
					@SHIP_ADDRESS_STATE, @SHIP_ADDRESS_COUNTRY, @SHIP_ADDRESS_ZIP,
					@ALSO_PARTY, @ALSO_ADDRESS_1, @ALSO_ADDRESS_2,
					@ALSO_ADDRESS_3, @ALSO_ADDRESS_CITY, @ALSO_ADDRESS_STATE,
					@ALSO_ADDRESS_COUNTRY, @ALSO_ADDRESS_ZIP, @DEST_CENSUS,
					@ORIG_CENSUS, @VESSEL_IRCS, @VESSEL_DSC,
					@SHIPPER_ID, @CONSIGNEE_ID, @NOTIFY_ID,
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

			Control_ID = ClsConvert.ToDecimalNullable(dr["CONTROL_ID"]);
			Groupid = ClsConvert.ToString(dr["GROUPID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			East_Or_West = ClsConvert.ToString(dr["EAST_OR_WEST"]);
			Queue_Status = ClsConvert.ToString(dr["QUEUE_STATUS"]);
			Voyage = ClsConvert.ToString(dr["VOYAGE"]);
			Vessel = ClsConvert.ToString(dr["VESSEL"]);
			Carrier = ClsConvert.ToString(dr["CARRIER"]);
			Orig_Location = ClsConvert.ToString(dr["ORIG_LOCATION"]);
			Dest_Location = ClsConvert.ToString(dr["DEST_LOCATION"]);
			Not_Party = ClsConvert.ToString(dr["NOT_PARTY"]);
			Not_Party2 = ClsConvert.ToString(dr["NOT_PARTY2"]);
			Not_Address_1 = ClsConvert.ToString(dr["NOT_ADDRESS_1"]);
			Not_Address_2 = ClsConvert.ToString(dr["NOT_ADDRESS_2"]);
			Not_Address_3 = ClsConvert.ToString(dr["NOT_ADDRESS_3"]);
			Not_Address_City = ClsConvert.ToString(dr["NOT_ADDRESS_CITY"]);
			Not_Address_State = ClsConvert.ToString(dr["NOT_ADDRESS_STATE"]);
			Not_Address_Country = ClsConvert.ToString(dr["NOT_ADDRESS_COUNTRY"]);
			Not_Address_Zip = ClsConvert.ToString(dr["NOT_ADDRESS_ZIP"]);
			Ship_Party = ClsConvert.ToString(dr["SHIP_PARTY"]);
			Ship_Address_1 = ClsConvert.ToString(dr["SHIP_ADDRESS_1"]);
			Ship_Address_2 = ClsConvert.ToString(dr["SHIP_ADDRESS_2"]);
			Ship_Address_3 = ClsConvert.ToString(dr["SHIP_ADDRESS_3"]);
			Ship_Address_City = ClsConvert.ToString(dr["SHIP_ADDRESS_CITY"]);
			Ship_Address_State = ClsConvert.ToString(dr["SHIP_ADDRESS_STATE"]);
			Ship_Address_Country = ClsConvert.ToString(dr["SHIP_ADDRESS_COUNTRY"]);
			Ship_Address_Zip = ClsConvert.ToString(dr["SHIP_ADDRESS_ZIP"]);
			Also_Party = ClsConvert.ToString(dr["ALSO_PARTY"]);
			Also_Address_1 = ClsConvert.ToString(dr["ALSO_ADDRESS_1"]);
			Also_Address_2 = ClsConvert.ToString(dr["ALSO_ADDRESS_2"]);
			Also_Address_3 = ClsConvert.ToString(dr["ALSO_ADDRESS_3"]);
			Also_Address_City = ClsConvert.ToString(dr["ALSO_ADDRESS_CITY"]);
			Also_Address_State = ClsConvert.ToString(dr["ALSO_ADDRESS_STATE"]);
			Also_Address_Country = ClsConvert.ToString(dr["ALSO_ADDRESS_COUNTRY"]);
			Also_Address_Zip = ClsConvert.ToString(dr["ALSO_ADDRESS_ZIP"]);
			Dest_Census = ClsConvert.ToString(dr["DEST_CENSUS"]);
			Orig_Census = ClsConvert.ToString(dr["ORIG_CENSUS"]);
			Vessel_Ircs = ClsConvert.ToString(dr["VESSEL_IRCS"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Shipper_ID = ClsConvert.ToDecimalNullable(dr["SHIPPER_ID"]);
			Consignee_ID = ClsConvert.ToDecimalNullable(dr["CONSIGNEE_ID"]);
			Notify_ID = ClsConvert.ToDecimalNullable(dr["NOTIFY_ID"]);
			Clause_19 = ClsConvert.ToString(dr["CLAUSE_19"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Control_ID = ClsConvert.ToDecimalNullable(dr["CONTROL_ID", v]);
			Groupid = ClsConvert.ToString(dr["GROUPID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			East_Or_West = ClsConvert.ToString(dr["EAST_OR_WEST", v]);
			Queue_Status = ClsConvert.ToString(dr["QUEUE_STATUS", v]);
			Voyage = ClsConvert.ToString(dr["VOYAGE", v]);
			Vessel = ClsConvert.ToString(dr["VESSEL", v]);
			Carrier = ClsConvert.ToString(dr["CARRIER", v]);
			Orig_Location = ClsConvert.ToString(dr["ORIG_LOCATION", v]);
			Dest_Location = ClsConvert.ToString(dr["DEST_LOCATION", v]);
			Not_Party = ClsConvert.ToString(dr["NOT_PARTY", v]);
			Not_Party2 = ClsConvert.ToString(dr["NOT_PARTY2", v]);
			Not_Address_1 = ClsConvert.ToString(dr["NOT_ADDRESS_1", v]);
			Not_Address_2 = ClsConvert.ToString(dr["NOT_ADDRESS_2", v]);
			Not_Address_3 = ClsConvert.ToString(dr["NOT_ADDRESS_3", v]);
			Not_Address_City = ClsConvert.ToString(dr["NOT_ADDRESS_CITY", v]);
			Not_Address_State = ClsConvert.ToString(dr["NOT_ADDRESS_STATE", v]);
			Not_Address_Country = ClsConvert.ToString(dr["NOT_ADDRESS_COUNTRY", v]);
			Not_Address_Zip = ClsConvert.ToString(dr["NOT_ADDRESS_ZIP", v]);
			Ship_Party = ClsConvert.ToString(dr["SHIP_PARTY", v]);
			Ship_Address_1 = ClsConvert.ToString(dr["SHIP_ADDRESS_1", v]);
			Ship_Address_2 = ClsConvert.ToString(dr["SHIP_ADDRESS_2", v]);
			Ship_Address_3 = ClsConvert.ToString(dr["SHIP_ADDRESS_3", v]);
			Ship_Address_City = ClsConvert.ToString(dr["SHIP_ADDRESS_CITY", v]);
			Ship_Address_State = ClsConvert.ToString(dr["SHIP_ADDRESS_STATE", v]);
			Ship_Address_Country = ClsConvert.ToString(dr["SHIP_ADDRESS_COUNTRY", v]);
			Ship_Address_Zip = ClsConvert.ToString(dr["SHIP_ADDRESS_ZIP", v]);
			Also_Party = ClsConvert.ToString(dr["ALSO_PARTY", v]);
			Also_Address_1 = ClsConvert.ToString(dr["ALSO_ADDRESS_1", v]);
			Also_Address_2 = ClsConvert.ToString(dr["ALSO_ADDRESS_2", v]);
			Also_Address_3 = ClsConvert.ToString(dr["ALSO_ADDRESS_3", v]);
			Also_Address_City = ClsConvert.ToString(dr["ALSO_ADDRESS_CITY", v]);
			Also_Address_State = ClsConvert.ToString(dr["ALSO_ADDRESS_STATE", v]);
			Also_Address_Country = ClsConvert.ToString(dr["ALSO_ADDRESS_COUNTRY", v]);
			Also_Address_Zip = ClsConvert.ToString(dr["ALSO_ADDRESS_ZIP", v]);
			Dest_Census = ClsConvert.ToString(dr["DEST_CENSUS", v]);
			Orig_Census = ClsConvert.ToString(dr["ORIG_CENSUS", v]);
			Vessel_Ircs = ClsConvert.ToString(dr["VESSEL_IRCS", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Shipper_ID = ClsConvert.ToDecimalNullable(dr["SHIPPER_ID", v]);
			Consignee_ID = ClsConvert.ToDecimalNullable(dr["CONSIGNEE_ID", v]);
			Notify_ID = ClsConvert.ToDecimalNullable(dr["NOTIFY_ID", v]);
			Clause_19 = ClsConvert.ToString(dr["CLAUSE_19", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CONTROL_ID"] = ClsConvert.ToDbObject(Control_ID);
			dr["GROUPID"] = ClsConvert.ToDbObject(Groupid);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["EAST_OR_WEST"] = ClsConvert.ToDbObject(East_Or_West);
			dr["QUEUE_STATUS"] = ClsConvert.ToDbObject(Queue_Status);
			dr["VOYAGE"] = ClsConvert.ToDbObject(Voyage);
			dr["VESSEL"] = ClsConvert.ToDbObject(Vessel);
			dr["CARRIER"] = ClsConvert.ToDbObject(Carrier);
			dr["ORIG_LOCATION"] = ClsConvert.ToDbObject(Orig_Location);
			dr["DEST_LOCATION"] = ClsConvert.ToDbObject(Dest_Location);
			dr["NOT_PARTY"] = ClsConvert.ToDbObject(Not_Party);
			dr["NOT_PARTY2"] = ClsConvert.ToDbObject(Not_Party2);
			dr["NOT_ADDRESS_1"] = ClsConvert.ToDbObject(Not_Address_1);
			dr["NOT_ADDRESS_2"] = ClsConvert.ToDbObject(Not_Address_2);
			dr["NOT_ADDRESS_3"] = ClsConvert.ToDbObject(Not_Address_3);
			dr["NOT_ADDRESS_CITY"] = ClsConvert.ToDbObject(Not_Address_City);
			dr["NOT_ADDRESS_STATE"] = ClsConvert.ToDbObject(Not_Address_State);
			dr["NOT_ADDRESS_COUNTRY"] = ClsConvert.ToDbObject(Not_Address_Country);
			dr["NOT_ADDRESS_ZIP"] = ClsConvert.ToDbObject(Not_Address_Zip);
			dr["SHIP_PARTY"] = ClsConvert.ToDbObject(Ship_Party);
			dr["SHIP_ADDRESS_1"] = ClsConvert.ToDbObject(Ship_Address_1);
			dr["SHIP_ADDRESS_2"] = ClsConvert.ToDbObject(Ship_Address_2);
			dr["SHIP_ADDRESS_3"] = ClsConvert.ToDbObject(Ship_Address_3);
			dr["SHIP_ADDRESS_CITY"] = ClsConvert.ToDbObject(Ship_Address_City);
			dr["SHIP_ADDRESS_STATE"] = ClsConvert.ToDbObject(Ship_Address_State);
			dr["SHIP_ADDRESS_COUNTRY"] = ClsConvert.ToDbObject(Ship_Address_Country);
			dr["SHIP_ADDRESS_ZIP"] = ClsConvert.ToDbObject(Ship_Address_Zip);
			dr["ALSO_PARTY"] = ClsConvert.ToDbObject(Also_Party);
			dr["ALSO_ADDRESS_1"] = ClsConvert.ToDbObject(Also_Address_1);
			dr["ALSO_ADDRESS_2"] = ClsConvert.ToDbObject(Also_Address_2);
			dr["ALSO_ADDRESS_3"] = ClsConvert.ToDbObject(Also_Address_3);
			dr["ALSO_ADDRESS_CITY"] = ClsConvert.ToDbObject(Also_Address_City);
			dr["ALSO_ADDRESS_STATE"] = ClsConvert.ToDbObject(Also_Address_State);
			dr["ALSO_ADDRESS_COUNTRY"] = ClsConvert.ToDbObject(Also_Address_Country);
			dr["ALSO_ADDRESS_ZIP"] = ClsConvert.ToDbObject(Also_Address_Zip);
			dr["DEST_CENSUS"] = ClsConvert.ToDbObject(Dest_Census);
			dr["ORIG_CENSUS"] = ClsConvert.ToDbObject(Orig_Census);
			dr["VESSEL_IRCS"] = ClsConvert.ToDbObject(Vessel_Ircs);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["SHIPPER_ID"] = ClsConvert.ToDbObject(Shipper_ID);
			dr["CONSIGNEE_ID"] = ClsConvert.ToDbObject(Consignee_ID);
			dr["NOTIFY_ID"] = ClsConvert.ToDbObject(Notify_ID);
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