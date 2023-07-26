using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVItvCatPass1 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_ITV_CAT_PASS1";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_ITV_CAT_PASS1";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Serial_NoMax = 50;
		public const int Container_NoMax = 20;
		public const int Container_PfxMax = 4;
		public const int Container_MainMax = 6;
		public const int Container_Check_DigitMax = 1;
		public const int Pkg_Type_CdMax = 10;
		public const int Activity_CdMax = 10;
		public const int Activity_DtMax = 8;
		public const int Activity_TimeMax = 4;
		public const int Location_CdMax = 10;
		public const int Cargo_KeyMax = 30;
		public const int Cargo_TypeMax = 10;
		public const int Eqpt_Status_CdMax = 1;
		public const int Customer_IDMax = 4;
		public const int Bol_NoMax = 30;
		public const int Booking_NoMax = 30;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Vessel_FlgMax = 2;
		public const int Vessel_DscMax = 50;
		public const int Plor_Location_CdMax = 4000;
		public const int Plor_Location_DscMax = 50;
		public const int Pol_Location_CdMax = 4000;
		public const int Pol_Location_DscMax = 50;
		public const int Pod_Location_CdMax = 4000;
		public const int Pod_Location_DscMax = 50;
		public const int Plod_Location_CdMax = 4000;
		public const int Plod_Location_DscMax = 50;
		public const int Departure_DtMax = 8;
		public const int Departure_TimeMax = 4;
		public const int Departure_QualifierMax = 3;
		public const int Arrival_DtMax = 8;
		public const int Arrival_TimeMax = 4;
		public const int Arrival_QualifierMax = 3;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Outbound_Isa_Nbr;
		protected string _Trading_Partner_Cd;
		protected decimal? _Itv_ID;
		protected string _Serial_No;
		protected string _Container_No;
		protected string _Container_Pfx;
		protected string _Container_Main;
		protected string _Container_Check_Digit;
		protected string _Pkg_Type_Cd;
		protected string _Activity_Cd;
		protected string _Activity_Dt;
		protected string _Activity_Time;
		protected string _Location_Cd;
		protected string _Cargo_Key;
		protected string _Cargo_Type;
		protected string _Eqpt_Status_Cd;
		protected string _Customer_ID;
		protected string _Bol_No;
		protected string _Booking_No;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected string _Vessel_Flg;
		protected string _Vessel_Dsc;
		protected string _Plor_Location_Cd;
		protected string _Plor_Location_Dsc;
		protected string _Pol_Location_Cd;
		protected string _Pol_Location_Dsc;
		protected string _Pod_Location_Cd;
		protected string _Pod_Location_Dsc;
		protected string _Plod_Location_Cd;
		protected string _Plod_Location_Dsc;
		protected string _Departure_Dt;
		protected string _Departure_Time;
		protected string _Departure_Qualifier;
		protected string _Arrival_Dt;
		protected string _Arrival_Time;
		protected string _Arrival_Qualifier;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Outbound_Isa_Nbr
		{
			get { return _Outbound_Isa_Nbr; }
			set
			{
				if( _Outbound_Isa_Nbr == value ) return;
		
				_Outbound_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Outbound_Isa_Nbr");
			}
		}
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
			}
		}
		public decimal? Itv_ID
		{
			get { return _Itv_ID; }
			set
			{
				if( _Itv_ID == value ) return;
		
				_Itv_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Itv_ID");
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
		public string Container_No
		{
			get { return _Container_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_NoMax )
					_Container_No = val.Substring(0, (int)Container_NoMax);
				else
					_Container_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_No");
			}
		}
		public string Container_Pfx
		{
			get { return _Container_Pfx; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_Pfx, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_PfxMax )
					_Container_Pfx = val.Substring(0, (int)Container_PfxMax);
				else
					_Container_Pfx = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_Pfx");
			}
		}
		public string Container_Main
		{
			get { return _Container_Main; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_Main, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_MainMax )
					_Container_Main = val.Substring(0, (int)Container_MainMax);
				else
					_Container_Main = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_Main");
			}
		}
		public string Container_Check_Digit
		{
			get { return _Container_Check_Digit; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_Check_Digit, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_Check_DigitMax )
					_Container_Check_Digit = val.Substring(0, (int)Container_Check_DigitMax);
				else
					_Container_Check_Digit = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_Check_Digit");
			}
		}
		public string Pkg_Type_Cd
		{
			get { return _Pkg_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pkg_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pkg_Type_CdMax )
					_Pkg_Type_Cd = val.Substring(0, (int)Pkg_Type_CdMax);
				else
					_Pkg_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pkg_Type_Cd");
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
		public string Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Dt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_DtMax )
					_Activity_Dt = val.Substring(0, (int)Activity_DtMax);
				else
					_Activity_Dt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
			}
		}
		public string Activity_Time
		{
			get { return _Activity_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_TimeMax )
					_Activity_Time = val.Substring(0, (int)Activity_TimeMax);
				else
					_Activity_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Time");
			}
		}
		public string Location_Cd
		{
			get { return _Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_CdMax )
					_Location_Cd = val.Substring(0, (int)Location_CdMax);
				else
					_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Cd");
			}
		}
		public string Cargo_Key
		{
			get { return _Cargo_Key; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Key, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_KeyMax )
					_Cargo_Key = val.Substring(0, (int)Cargo_KeyMax);
				else
					_Cargo_Key = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Key");
			}
		}
		public string Cargo_Type
		{
			get { return _Cargo_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_TypeMax )
					_Cargo_Type = val.Substring(0, (int)Cargo_TypeMax);
				else
					_Cargo_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Type");
			}
		}
		public string Eqpt_Status_Cd
		{
			get { return _Eqpt_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Eqpt_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Eqpt_Status_CdMax )
					_Eqpt_Status_Cd = val.Substring(0, (int)Eqpt_Status_CdMax);
				else
					_Eqpt_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Eqpt_Status_Cd");
			}
		}
		public string Customer_ID
		{
			get { return _Customer_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_IDMax )
					_Customer_ID = val.Substring(0, (int)Customer_IDMax);
				else
					_Customer_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_ID");
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
		public string Vessel_Flg
		{
			get { return _Vessel_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_FlgMax )
					_Vessel_Flg = val.Substring(0, (int)Vessel_FlgMax);
				else
					_Vessel_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Flg");
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
		public string Plor_Location_Dsc
		{
			get { return _Plor_Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_Location_DscMax )
					_Plor_Location_Dsc = val.Substring(0, (int)Plor_Location_DscMax);
				else
					_Plor_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Location_Dsc");
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
		public string Pol_Location_Dsc
		{
			get { return _Pol_Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Location_DscMax )
					_Pol_Location_Dsc = val.Substring(0, (int)Pol_Location_DscMax);
				else
					_Pol_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Location_Dsc");
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
		public string Pod_Location_Dsc
		{
			get { return _Pod_Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Location_DscMax )
					_Pod_Location_Dsc = val.Substring(0, (int)Pod_Location_DscMax);
				else
					_Pod_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Location_Dsc");
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
		public string Plod_Location_Dsc
		{
			get { return _Plod_Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_Location_DscMax )
					_Plod_Location_Dsc = val.Substring(0, (int)Plod_Location_DscMax);
				else
					_Plod_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Location_Dsc");
			}
		}
		public string Departure_Dt
		{
			get { return _Departure_Dt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departure_Dt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Departure_DtMax )
					_Departure_Dt = val.Substring(0, (int)Departure_DtMax);
				else
					_Departure_Dt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Dt");
			}
		}
		public string Departure_Time
		{
			get { return _Departure_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departure_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Departure_TimeMax )
					_Departure_Time = val.Substring(0, (int)Departure_TimeMax);
				else
					_Departure_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Time");
			}
		}
		public string Departure_Qualifier
		{
			get { return _Departure_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departure_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Departure_QualifierMax )
					_Departure_Qualifier = val.Substring(0, (int)Departure_QualifierMax);
				else
					_Departure_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Qualifier");
			}
		}
		public string Arrival_Dt
		{
			get { return _Arrival_Dt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrival_Dt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Arrival_DtMax )
					_Arrival_Dt = val.Substring(0, (int)Arrival_DtMax);
				else
					_Arrival_Dt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Dt");
			}
		}
		public string Arrival_Time
		{
			get { return _Arrival_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrival_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Arrival_TimeMax )
					_Arrival_Time = val.Substring(0, (int)Arrival_TimeMax);
				else
					_Arrival_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Time");
			}
		}
		public string Arrival_Qualifier
		{
			get { return _Arrival_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrival_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Arrival_QualifierMax )
					_Arrival_Qualifier = val.Substring(0, (int)Arrival_QualifierMax);
				else
					_Arrival_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Qualifier");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVItvCatPass1() : base() {}
		public ClsVItvCatPass1(DataRow dr) : base(dr) {}
		public ClsVItvCatPass1(ClsVItvCatPass1 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Outbound_Isa_Nbr = null;
			Trading_Partner_Cd = null;
			Itv_ID = null;
			Serial_No = null;
			Container_No = null;
			Container_Pfx = null;
			Container_Main = null;
			Container_Check_Digit = null;
			Pkg_Type_Cd = null;
			Activity_Cd = null;
			Activity_Dt = null;
			Activity_Time = null;
			Location_Cd = null;
			Cargo_Key = null;
			Cargo_Type = null;
			Eqpt_Status_Cd = null;
			Customer_ID = null;
			Bol_No = null;
			Booking_No = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Vessel_Flg = null;
			Vessel_Dsc = null;
			Plor_Location_Cd = null;
			Plor_Location_Dsc = null;
			Pol_Location_Cd = null;
			Pol_Location_Dsc = null;
			Pod_Location_Cd = null;
			Pod_Location_Dsc = null;
			Plod_Location_Cd = null;
			Plod_Location_Dsc = null;
			Departure_Dt = null;
			Departure_Time = null;
			Departure_Qualifier = null;
			Arrival_Dt = null;
			Arrival_Time = null;
			Arrival_Qualifier = null;
		}

		public void CopyFrom(ClsVItvCatPass1 src)
		{
			Outbound_Isa_Nbr = src._Outbound_Isa_Nbr;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Itv_ID = src._Itv_ID;
			Serial_No = src._Serial_No;
			Container_No = src._Container_No;
			Container_Pfx = src._Container_Pfx;
			Container_Main = src._Container_Main;
			Container_Check_Digit = src._Container_Check_Digit;
			Pkg_Type_Cd = src._Pkg_Type_Cd;
			Activity_Cd = src._Activity_Cd;
			Activity_Dt = src._Activity_Dt;
			Activity_Time = src._Activity_Time;
			Location_Cd = src._Location_Cd;
			Cargo_Key = src._Cargo_Key;
			Cargo_Type = src._Cargo_Type;
			Eqpt_Status_Cd = src._Eqpt_Status_Cd;
			Customer_ID = src._Customer_ID;
			Bol_No = src._Bol_No;
			Booking_No = src._Booking_No;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Flg = src._Vessel_Flg;
			Vessel_Dsc = src._Vessel_Dsc;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Plor_Location_Dsc = src._Plor_Location_Dsc;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pol_Location_Dsc = src._Pol_Location_Dsc;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pod_Location_Dsc = src._Pod_Location_Dsc;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Plod_Location_Dsc = src._Plod_Location_Dsc;
			Departure_Dt = src._Departure_Dt;
			Departure_Time = src._Departure_Time;
			Departure_Qualifier = src._Departure_Qualifier;
			Arrival_Dt = src._Arrival_Dt;
			Arrival_Time = src._Arrival_Time;
			Arrival_Qualifier = src._Arrival_Qualifier;
		}

		public override bool ReloadFromDB()
		{
			ClsVItvCatPass1 tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[37];

			p[0] = Connection.GetParameter
				("@OUTBOUND_ISA_NBR", Outbound_Isa_Nbr);
			p[1] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[2] = Connection.GetParameter
				("@ITV_ID", Itv_ID);
			p[3] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[4] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[5] = Connection.GetParameter
				("@CONTAINER_PFX", Container_Pfx);
			p[6] = Connection.GetParameter
				("@CONTAINER_MAIN", Container_Main);
			p[7] = Connection.GetParameter
				("@CONTAINER_CHECK_DIGIT", Container_Check_Digit);
			p[8] = Connection.GetParameter
				("@PKG_TYPE_CD", Pkg_Type_Cd);
			p[9] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[10] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[11] = Connection.GetParameter
				("@ACTIVITY_TIME", Activity_Time);
			p[12] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[13] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[14] = Connection.GetParameter
				("@CARGO_TYPE", Cargo_Type);
			p[15] = Connection.GetParameter
				("@EQPT_STATUS_CD", Eqpt_Status_Cd);
			p[16] = Connection.GetParameter
				("@CUSTOMER_ID", Customer_ID);
			p[17] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[18] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[19] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[20] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[21] = Connection.GetParameter
				("@VESSEL_FLG", Vessel_Flg);
			p[22] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[23] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[24] = Connection.GetParameter
				("@PLOR_LOCATION_DSC", Plor_Location_Dsc);
			p[25] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[26] = Connection.GetParameter
				("@POL_LOCATION_DSC", Pol_Location_Dsc);
			p[27] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[28] = Connection.GetParameter
				("@POD_LOCATION_DSC", Pod_Location_Dsc);
			p[29] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[30] = Connection.GetParameter
				("@PLOD_LOCATION_DSC", Plod_Location_Dsc);
			p[31] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[32] = Connection.GetParameter
				("@DEPARTURE_TIME", Departure_Time);
			p[33] = Connection.GetParameter
				("@DEPARTURE_QUALIFIER", Departure_Qualifier);
			p[34] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[35] = Connection.GetParameter
				("@ARRIVAL_TIME", Arrival_Time);
			p[36] = Connection.GetParameter
				("@ARRIVAL_QUALIFIER", Arrival_Qualifier);

			const string sql = @"
				INSERT INTO V_ITV_CAT_PASS1
					(OUTBOUND_ISA_NBR, TRADING_PARTNER_CD, ITV_ID,
					SERIAL_NO, CONTAINER_NO, CONTAINER_PFX,
					CONTAINER_MAIN, CONTAINER_CHECK_DIGIT, PKG_TYPE_CD,
					ACTIVITY_CD, ACTIVITY_DT, ACTIVITY_TIME,
					LOCATION_CD, CARGO_KEY, CARGO_TYPE,
					EQPT_STATUS_CD, CUSTOMER_ID, BOL_NO,
					BOOKING_NO, VOYAGE_NO, VESSEL_CD,
					VESSEL_FLG, VESSEL_DSC, PLOR_LOCATION_CD,
					PLOR_LOCATION_DSC, POL_LOCATION_CD, POL_LOCATION_DSC,
					POD_LOCATION_CD, POD_LOCATION_DSC, PLOD_LOCATION_CD,
					PLOD_LOCATION_DSC, DEPARTURE_DT, DEPARTURE_TIME,
					DEPARTURE_QUALIFIER, ARRIVAL_DT, ARRIVAL_TIME,
					ARRIVAL_QUALIFIER)
				VALUES
					(@OUTBOUND_ISA_NBR, @TRADING_PARTNER_CD, @ITV_ID,
					@SERIAL_NO, @CONTAINER_NO, @CONTAINER_PFX,
					@CONTAINER_MAIN, @CONTAINER_CHECK_DIGIT, @PKG_TYPE_CD,
					@ACTIVITY_CD, @ACTIVITY_DT, @ACTIVITY_TIME,
					@LOCATION_CD, @CARGO_KEY, @CARGO_TYPE,
					@EQPT_STATUS_CD, @CUSTOMER_ID, @BOL_NO,
					@BOOKING_NO, @VOYAGE_NO, @VESSEL_CD,
					@VESSEL_FLG, @VESSEL_DSC, @PLOR_LOCATION_CD,
					@PLOR_LOCATION_DSC, @POL_LOCATION_CD, @POL_LOCATION_DSC,
					@POD_LOCATION_CD, @POD_LOCATION_DSC, @PLOD_LOCATION_CD,
					@PLOD_LOCATION_DSC, @DEPARTURE_DT, @DEPARTURE_TIME,
					@DEPARTURE_QUALIFIER, @ARRIVAL_DT, @ARRIVAL_TIME,
					@ARRIVAL_QUALIFIER)
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

			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Container_Pfx = ClsConvert.ToString(dr["CONTAINER_PFX"]);
			Container_Main = ClsConvert.ToString(dr["CONTAINER_MAIN"]);
			Container_Check_Digit = ClsConvert.ToString(dr["CONTAINER_CHECK_DIGIT"]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Activity_Dt = ClsConvert.ToString(dr["ACTIVITY_DT"]);
			Activity_Time = ClsConvert.ToString(dr["ACTIVITY_TIME"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE"]);
			Eqpt_Status_Cd = ClsConvert.ToString(dr["EQPT_STATUS_CD"]);
			Customer_ID = ClsConvert.ToString(dr["CUSTOMER_ID"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Vessel_Flg = ClsConvert.ToString(dr["VESSEL_FLG"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Plor_Location_Dsc = ClsConvert.ToString(dr["PLOR_LOCATION_DSC"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pol_Location_Dsc = ClsConvert.ToString(dr["POL_LOCATION_DSC"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pod_Location_Dsc = ClsConvert.ToString(dr["POD_LOCATION_DSC"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Plod_Location_Dsc = ClsConvert.ToString(dr["PLOD_LOCATION_DSC"]);
			Departure_Dt = ClsConvert.ToString(dr["DEPARTURE_DT"]);
			Departure_Time = ClsConvert.ToString(dr["DEPARTURE_TIME"]);
			Departure_Qualifier = ClsConvert.ToString(dr["DEPARTURE_QUALIFIER"]);
			Arrival_Dt = ClsConvert.ToString(dr["ARRIVAL_DT"]);
			Arrival_Time = ClsConvert.ToString(dr["ARRIVAL_TIME"]);
			Arrival_Qualifier = ClsConvert.ToString(dr["ARRIVAL_QUALIFIER"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Container_Pfx = ClsConvert.ToString(dr["CONTAINER_PFX", v]);
			Container_Main = ClsConvert.ToString(dr["CONTAINER_MAIN", v]);
			Container_Check_Digit = ClsConvert.ToString(dr["CONTAINER_CHECK_DIGIT", v]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Activity_Dt = ClsConvert.ToString(dr["ACTIVITY_DT", v]);
			Activity_Time = ClsConvert.ToString(dr["ACTIVITY_TIME", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE", v]);
			Eqpt_Status_Cd = ClsConvert.ToString(dr["EQPT_STATUS_CD", v]);
			Customer_ID = ClsConvert.ToString(dr["CUSTOMER_ID", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Vessel_Flg = ClsConvert.ToString(dr["VESSEL_FLG", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Plor_Location_Dsc = ClsConvert.ToString(dr["PLOR_LOCATION_DSC", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pol_Location_Dsc = ClsConvert.ToString(dr["POL_LOCATION_DSC", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pod_Location_Dsc = ClsConvert.ToString(dr["POD_LOCATION_DSC", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Plod_Location_Dsc = ClsConvert.ToString(dr["PLOD_LOCATION_DSC", v]);
			Departure_Dt = ClsConvert.ToString(dr["DEPARTURE_DT", v]);
			Departure_Time = ClsConvert.ToString(dr["DEPARTURE_TIME", v]);
			Departure_Qualifier = ClsConvert.ToString(dr["DEPARTURE_QUALIFIER", v]);
			Arrival_Dt = ClsConvert.ToString(dr["ARRIVAL_DT", v]);
			Arrival_Time = ClsConvert.ToString(dr["ARRIVAL_TIME", v]);
			Arrival_Qualifier = ClsConvert.ToString(dr["ARRIVAL_QUALIFIER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["OUTBOUND_ISA_NBR"] = ClsConvert.ToDbObject(Outbound_Isa_Nbr);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["ITV_ID"] = ClsConvert.ToDbObject(Itv_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["CONTAINER_PFX"] = ClsConvert.ToDbObject(Container_Pfx);
			dr["CONTAINER_MAIN"] = ClsConvert.ToDbObject(Container_Main);
			dr["CONTAINER_CHECK_DIGIT"] = ClsConvert.ToDbObject(Container_Check_Digit);
			dr["PKG_TYPE_CD"] = ClsConvert.ToDbObject(Pkg_Type_Cd);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_TIME"] = ClsConvert.ToDbObject(Activity_Time);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["CARGO_TYPE"] = ClsConvert.ToDbObject(Cargo_Type);
			dr["EQPT_STATUS_CD"] = ClsConvert.ToDbObject(Eqpt_Status_Cd);
			dr["CUSTOMER_ID"] = ClsConvert.ToDbObject(Customer_ID);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VESSEL_FLG"] = ClsConvert.ToDbObject(Vessel_Flg);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["PLOR_LOCATION_DSC"] = ClsConvert.ToDbObject(Plor_Location_Dsc);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POL_LOCATION_DSC"] = ClsConvert.ToDbObject(Pol_Location_Dsc);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POD_LOCATION_DSC"] = ClsConvert.ToDbObject(Pod_Location_Dsc);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["PLOD_LOCATION_DSC"] = ClsConvert.ToDbObject(Plod_Location_Dsc);
			dr["DEPARTURE_DT"] = ClsConvert.ToDbObject(Departure_Dt);
			dr["DEPARTURE_TIME"] = ClsConvert.ToDbObject(Departure_Time);
			dr["DEPARTURE_QUALIFIER"] = ClsConvert.ToDbObject(Departure_Qualifier);
			dr["ARRIVAL_DT"] = ClsConvert.ToDbObject(Arrival_Dt);
			dr["ARRIVAL_TIME"] = ClsConvert.ToDbObject(Arrival_Time);
			dr["ARRIVAL_QUALIFIER"] = ClsConvert.ToDbObject(Arrival_Qualifier);
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