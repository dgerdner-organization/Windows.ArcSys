using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBolHeader : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_bol_header";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_bol_header";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Scac_CdMax = 4;
		public const int Scac_CompanyMax = 50;
		public const int Booking_NoMax = 50;
		public const int AlternatebookingnumberMax = 50;
		public const int Bol_NoMax = 50;
		public const int AlternatenumberMax = 50;
		public const int Status_CdMax = 30;
		public const int Status_DscMax = 50;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 5;
		public const int Vessel_NameMax = 30;
		public const int CallsignMax = 7;
		public const int LloydsnumberMax = 7;
		public const int Plor_CdMax = 5;
		public const int Plor_DscMax = 100;
		public const int Plod_CdMax = 5;
		public const int Plod_DscMax = 100;
		public const int Pol_CdMax = 5;
		public const int Pol_DscMax = 100;
		public const int Pol_Berth_CdMax = 7;
		public const int Pol_Berth_DscMax = 100;
		public const int Pod_CdMax = 5;
		public const int Pod_DscMax = 100;
		public const int Pod_Berth_CdMax = 7;
		public const int Pod_Berth_DscMax = 7;
		public const int EdireferenceMax = 40;
		public const int PortcallfilenumberMax = 8;
		public const int ProjectnumberMax = 30;
		public const int ContractnumberMax = 30;
		public const int DateofissueMax = 27;
		public const int FinalmanifestedMax = 100;
		public const int ItnnumberMax = 30;
		public const int Liner_Release_CdMax = 5;
		public const int Customs_Release_CdMax = 5;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _ID;
		protected Int32? _Scaccodeid;
		protected string _Scac_Cd;
		protected string _Scac_Company;
		protected string _Booking_No;
		protected string _Alternatebookingnumber;
		protected string _Bol_No;
		protected string _Alternatenumber;
		protected string _Status_Cd;
		protected string _Status_Dsc;
		protected Int32? _Voyageid;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected string _Vessel_Name;
		protected string _Callsign;
		protected string _Lloydsnumber;
		protected Int32? _Plor_ID;
		protected string _Plor_Cd;
		protected string _Plor_Dsc;
		protected string _Plod_Cd;
		protected string _Plod_Dsc;
		protected Int32? _Plod_ID;
		protected string _Pol_Cd;
		protected string _Pol_Dsc;
		protected string _Pol_Berth_Cd;
		protected string _Pol_Berth_Dsc;
		protected string _Pod_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Berth_Cd;
		protected string _Pod_Berth_Dsc;
		protected string _Edireference;
		protected string _Portcallfilenumber;
		protected string _Projectnumber;
		protected string _Contractnumber;
		protected string _Dateofissue;
		protected Int32? _Linerreleasecodeid;
		protected string _Finalmanifested;
		protected Int32? _Customsreleasecodeid;
		protected string _Itnnumber;
		protected string _Liner_Release_Cd;
		protected string _Customs_Release_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int32? ID
		{
			get { return _ID; }
			set
			{
				if( _ID == value ) return;
		
				_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("ID");
			}
		}
		public Int32? Scaccodeid
		{
			get { return _Scaccodeid; }
			set
			{
				if( _Scaccodeid == value ) return;
		
				_Scaccodeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Scaccodeid");
			}
		}
		public string Scac_Cd
		{
			get { return _Scac_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Scac_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Scac_CdMax )
					_Scac_Cd = val.Substring(0, (int)Scac_CdMax);
				else
					_Scac_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Scac_Cd");
			}
		}
		public string Scac_Company
		{
			get { return _Scac_Company; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Scac_Company, val, false) == 0 ) return;
		
				if( val != null && val.Length > Scac_CompanyMax )
					_Scac_Company = val.Substring(0, (int)Scac_CompanyMax);
				else
					_Scac_Company = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Scac_Company");
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
		public string Alternatebookingnumber
		{
			get { return _Alternatebookingnumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Alternatebookingnumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > AlternatebookingnumberMax )
					_Alternatebookingnumber = val.Substring(0, (int)AlternatebookingnumberMax);
				else
					_Alternatebookingnumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Alternatebookingnumber");
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
		public string Alternatenumber
		{
			get { return _Alternatenumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Alternatenumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > AlternatenumberMax )
					_Alternatenumber = val.Substring(0, (int)AlternatenumberMax);
				else
					_Alternatenumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Alternatenumber");
			}
		}
		public string Status_Cd
		{
			get { return _Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_CdMax )
					_Status_Cd = val.Substring(0, (int)Status_CdMax);
				else
					_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Cd");
			}
		}
		public string Status_Dsc
		{
			get { return _Status_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_DscMax )
					_Status_Dsc = val.Substring(0, (int)Status_DscMax);
				else
					_Status_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Dsc");
			}
		}
		public Int32? Voyageid
		{
			get { return _Voyageid; }
			set
			{
				if( _Voyageid == value ) return;
		
				_Voyageid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Voyageid");
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
		public string Vessel_Name
		{
			get { return _Vessel_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_NameMax )
					_Vessel_Name = val.Substring(0, (int)Vessel_NameMax);
				else
					_Vessel_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Name");
			}
		}
		public string Callsign
		{
			get { return _Callsign; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Callsign, val, false) == 0 ) return;
		
				if( val != null && val.Length > CallsignMax )
					_Callsign = val.Substring(0, (int)CallsignMax);
				else
					_Callsign = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Callsign");
			}
		}
		public string Lloydsnumber
		{
			get { return _Lloydsnumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Lloydsnumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > LloydsnumberMax )
					_Lloydsnumber = val.Substring(0, (int)LloydsnumberMax);
				else
					_Lloydsnumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Lloydsnumber");
			}
		}
		public Int32? Plor_ID
		{
			get { return _Plor_ID; }
			set
			{
				if( _Plor_ID == value ) return;
		
				_Plor_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Plor_ID");
			}
		}
		public string Plor_Cd
		{
			get { return _Plor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_CdMax )
					_Plor_Cd = val.Substring(0, (int)Plor_CdMax);
				else
					_Plor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Cd");
			}
		}
		public string Plor_Dsc
		{
			get { return _Plor_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_DscMax )
					_Plor_Dsc = val.Substring(0, (int)Plor_DscMax);
				else
					_Plor_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Dsc");
			}
		}
		public string Plod_Cd
		{
			get { return _Plod_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_CdMax )
					_Plod_Cd = val.Substring(0, (int)Plod_CdMax);
				else
					_Plod_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Cd");
			}
		}
		public string Plod_Dsc
		{
			get { return _Plod_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_DscMax )
					_Plod_Dsc = val.Substring(0, (int)Plod_DscMax);
				else
					_Plod_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Dsc");
			}
		}
		public Int32? Plod_ID
		{
			get { return _Plod_ID; }
			set
			{
				if( _Plod_ID == value ) return;
		
				_Plod_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Plod_ID");
			}
		}
		public string Pol_Cd
		{
			get { return _Pol_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_CdMax )
					_Pol_Cd = val.Substring(0, (int)Pol_CdMax);
				else
					_Pol_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Cd");
			}
		}
		public string Pol_Dsc
		{
			get { return _Pol_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_DscMax )
					_Pol_Dsc = val.Substring(0, (int)Pol_DscMax);
				else
					_Pol_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Dsc");
			}
		}
		public string Pol_Berth_Cd
		{
			get { return _Pol_Berth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Berth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Berth_CdMax )
					_Pol_Berth_Cd = val.Substring(0, (int)Pol_Berth_CdMax);
				else
					_Pol_Berth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Berth_Cd");
			}
		}
		public string Pol_Berth_Dsc
		{
			get { return _Pol_Berth_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Berth_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Berth_DscMax )
					_Pol_Berth_Dsc = val.Substring(0, (int)Pol_Berth_DscMax);
				else
					_Pol_Berth_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Berth_Dsc");
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
		public string Pod_Berth_Cd
		{
			get { return _Pod_Berth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Berth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Berth_CdMax )
					_Pod_Berth_Cd = val.Substring(0, (int)Pod_Berth_CdMax);
				else
					_Pod_Berth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Berth_Cd");
			}
		}
		public string Pod_Berth_Dsc
		{
			get { return _Pod_Berth_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Berth_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Berth_DscMax )
					_Pod_Berth_Dsc = val.Substring(0, (int)Pod_Berth_DscMax);
				else
					_Pod_Berth_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Berth_Dsc");
			}
		}
		public string Edireference
		{
			get { return _Edireference; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edireference, val, false) == 0 ) return;
		
				if( val != null && val.Length > EdireferenceMax )
					_Edireference = val.Substring(0, (int)EdireferenceMax);
				else
					_Edireference = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edireference");
			}
		}
		public string Portcallfilenumber
		{
			get { return _Portcallfilenumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Portcallfilenumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > PortcallfilenumberMax )
					_Portcallfilenumber = val.Substring(0, (int)PortcallfilenumberMax);
				else
					_Portcallfilenumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Portcallfilenumber");
			}
		}
		public string Projectnumber
		{
			get { return _Projectnumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Projectnumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > ProjectnumberMax )
					_Projectnumber = val.Substring(0, (int)ProjectnumberMax);
				else
					_Projectnumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Projectnumber");
			}
		}
		public string Contractnumber
		{
			get { return _Contractnumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contractnumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > ContractnumberMax )
					_Contractnumber = val.Substring(0, (int)ContractnumberMax);
				else
					_Contractnumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contractnumber");
			}
		}
		public string Dateofissue
		{
			get { return _Dateofissue; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dateofissue, val, false) == 0 ) return;
		
				if( val != null && val.Length > DateofissueMax )
					_Dateofissue = val.Substring(0, (int)DateofissueMax);
				else
					_Dateofissue = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dateofissue");
			}
		}
		public Int32? Linerreleasecodeid
		{
			get { return _Linerreleasecodeid; }
			set
			{
				if( _Linerreleasecodeid == value ) return;
		
				_Linerreleasecodeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Linerreleasecodeid");
			}
		}
		public string Finalmanifested
		{
			get { return _Finalmanifested; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Finalmanifested, val, false) == 0 ) return;
		
				if( val != null && val.Length > FinalmanifestedMax )
					_Finalmanifested = val.Substring(0, (int)FinalmanifestedMax);
				else
					_Finalmanifested = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Finalmanifested");
			}
		}
		public Int32? Customsreleasecodeid
		{
			get { return _Customsreleasecodeid; }
			set
			{
				if( _Customsreleasecodeid == value ) return;
		
				_Customsreleasecodeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Customsreleasecodeid");
			}
		}
		public string Itnnumber
		{
			get { return _Itnnumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Itnnumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > ItnnumberMax )
					_Itnnumber = val.Substring(0, (int)ItnnumberMax);
				else
					_Itnnumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Itnnumber");
			}
		}
		public string Liner_Release_Cd
		{
			get { return _Liner_Release_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Liner_Release_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Liner_Release_CdMax )
					_Liner_Release_Cd = val.Substring(0, (int)Liner_Release_CdMax);
				else
					_Liner_Release_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Liner_Release_Cd");
			}
		}
		public string Customs_Release_Cd
		{
			get { return _Customs_Release_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customs_Release_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customs_Release_CdMax )
					_Customs_Release_Cd = val.Substring(0, (int)Customs_Release_CdMax);
				else
					_Customs_Release_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customs_Release_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBolHeader() : base() {}
		public ClsVwArcBolHeader(DataRow dr) : base(dr) {}
		public ClsVwArcBolHeader(ClsVwArcBolHeader src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			ID = null;
			Scaccodeid = null;
			Scac_Cd = null;
			Scac_Company = null;
			Booking_No = null;
			Alternatebookingnumber = null;
			Bol_No = null;
			Alternatenumber = null;
			Status_Cd = null;
			Status_Dsc = null;
			Voyageid = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Vessel_Name = null;
			Callsign = null;
			Lloydsnumber = null;
			Plor_ID = null;
			Plor_Cd = null;
			Plor_Dsc = null;
			Plod_Cd = null;
			Plod_Dsc = null;
			Plod_ID = null;
			Pol_Cd = null;
			Pol_Dsc = null;
			Pol_Berth_Cd = null;
			Pol_Berth_Dsc = null;
			Pod_Cd = null;
			Pod_Dsc = null;
			Pod_Berth_Cd = null;
			Pod_Berth_Dsc = null;
			Edireference = null;
			Portcallfilenumber = null;
			Projectnumber = null;
			Contractnumber = null;
			Dateofissue = null;
			Linerreleasecodeid = null;
			Finalmanifested = null;
			Customsreleasecodeid = null;
			Itnnumber = null;
			Liner_Release_Cd = null;
			Customs_Release_Cd = null;
		}

		public void CopyFrom(ClsVwArcBolHeader src)
		{
			ID = src._ID;
			Scaccodeid = src._Scaccodeid;
			Scac_Cd = src._Scac_Cd;
			Scac_Company = src._Scac_Company;
			Booking_No = src._Booking_No;
			Alternatebookingnumber = src._Alternatebookingnumber;
			Bol_No = src._Bol_No;
			Alternatenumber = src._Alternatenumber;
			Status_Cd = src._Status_Cd;
			Status_Dsc = src._Status_Dsc;
			Voyageid = src._Voyageid;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Name = src._Vessel_Name;
			Callsign = src._Callsign;
			Lloydsnumber = src._Lloydsnumber;
			Plor_ID = src._Plor_ID;
			Plor_Cd = src._Plor_Cd;
			Plor_Dsc = src._Plor_Dsc;
			Plod_Cd = src._Plod_Cd;
			Plod_Dsc = src._Plod_Dsc;
			Plod_ID = src._Plod_ID;
			Pol_Cd = src._Pol_Cd;
			Pol_Dsc = src._Pol_Dsc;
			Pol_Berth_Cd = src._Pol_Berth_Cd;
			Pol_Berth_Dsc = src._Pol_Berth_Dsc;
			Pod_Cd = src._Pod_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Berth_Cd = src._Pod_Berth_Cd;
			Pod_Berth_Dsc = src._Pod_Berth_Dsc;
			Edireference = src._Edireference;
			Portcallfilenumber = src._Portcallfilenumber;
			Projectnumber = src._Projectnumber;
			Contractnumber = src._Contractnumber;
			Dateofissue = src._Dateofissue;
			Linerreleasecodeid = src._Linerreleasecodeid;
			Finalmanifested = src._Finalmanifested;
			Customsreleasecodeid = src._Customsreleasecodeid;
			Itnnumber = src._Itnnumber;
			Liner_Release_Cd = src._Liner_Release_Cd;
			Customs_Release_Cd = src._Customs_Release_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBolHeader tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[41];

			p[0] = Connection.GetParameter
				("@Id", ID);
			p[1] = Connection.GetParameter
				("@ScacCodeId", Scaccodeid);
			p[2] = Connection.GetParameter
				("@Scac_cd", Scac_Cd);
			p[3] = Connection.GetParameter
				("@Scac_company", Scac_Company);
			p[4] = Connection.GetParameter
				("@Booking_No", Booking_No);
			p[5] = Connection.GetParameter
				("@AlternateBookingNumber", Alternatebookingnumber);
			p[6] = Connection.GetParameter
				("@bol_no", Bol_No);
			p[7] = Connection.GetParameter
				("@AlternateNumber", Alternatenumber);
			p[8] = Connection.GetParameter
				("@status_cd", Status_Cd);
			p[9] = Connection.GetParameter
				("@status_dsc", Status_Dsc);
			p[10] = Connection.GetParameter
				("@VoyageId", Voyageid);
			p[11] = Connection.GetParameter
				("@voyage_no", Voyage_No);
			p[12] = Connection.GetParameter
				("@vessel_cd", Vessel_Cd);
			p[13] = Connection.GetParameter
				("@vessel_name", Vessel_Name);
			p[14] = Connection.GetParameter
				("@CallSign", Callsign);
			p[15] = Connection.GetParameter
				("@LloydsNumber", Lloydsnumber);
			p[16] = Connection.GetParameter
				("@plor_Id", Plor_ID);
			p[17] = Connection.GetParameter
				("@plor_cd", Plor_Cd);
			p[18] = Connection.GetParameter
				("@plor_dsc", Plor_Dsc);
			p[19] = Connection.GetParameter
				("@plod_cd", Plod_Cd);
			p[20] = Connection.GetParameter
				("@plod_dsc", Plod_Dsc);
			p[21] = Connection.GetParameter
				("@plod_id", Plod_ID);
			p[22] = Connection.GetParameter
				("@pol_cd", Pol_Cd);
			p[23] = Connection.GetParameter
				("@pol_dsc", Pol_Dsc);
			p[24] = Connection.GetParameter
				("@pol_berth_cd", Pol_Berth_Cd);
			p[25] = Connection.GetParameter
				("@pol_berth_dsc", Pol_Berth_Dsc);
			p[26] = Connection.GetParameter
				("@pod_cd", Pod_Cd);
			p[27] = Connection.GetParameter
				("@pod_dsc", Pod_Dsc);
			p[28] = Connection.GetParameter
				("@pod_berth_cd", Pod_Berth_Cd);
			p[29] = Connection.GetParameter
				("@pod_berth_dsc", Pod_Berth_Dsc);
			p[30] = Connection.GetParameter
				("@EdiReference", Edireference);
			p[31] = Connection.GetParameter
				("@PortCallFileNumber", Portcallfilenumber);
			p[32] = Connection.GetParameter
				("@ProjectNumber", Projectnumber);
			p[33] = Connection.GetParameter
				("@ContractNumber", Contractnumber);
			p[34] = Connection.GetParameter
				("@DateOfIssue", Dateofissue);
			p[35] = Connection.GetParameter
				("@LinerReleaseCodeId", Linerreleasecodeid);
			p[36] = Connection.GetParameter
				("@FinalManifested", Finalmanifested);
			p[37] = Connection.GetParameter
				("@CustomsReleaseCodeId", Customsreleasecodeid);
			p[38] = Connection.GetParameter
				("@ItnNumber", Itnnumber);
			p[39] = Connection.GetParameter
				("@liner_release_cd", Liner_Release_Cd);
			p[40] = Connection.GetParameter
				("@customs_release_cd", Customs_Release_Cd);

			const string sql = @"INSERT INTO vw_arc_bol_header VALUES
				(@Id,@ScacCodeId,@Scac_cd
				,@Scac_company,@Booking_No,@AlternateBookingNumber
				,@bol_no,@AlternateNumber,@status_cd
				,@status_dsc,@VoyageId,@voyage_no
				,@vessel_cd,@vessel_name,@CallSign
				,@LloydsNumber,@plor_Id,@plor_cd
				,@plor_dsc,@plod_cd,@plod_dsc
				,@plod_id,@pol_cd,@pol_dsc
				,@pol_berth_cd,@pol_berth_dsc,@pod_cd
				,@pod_dsc,@pod_berth_cd,@pod_berth_dsc
				,@EdiReference,@PortCallFileNumber,@ProjectNumber
				,@ContractNumber,@DateOfIssue,@LinerReleaseCodeId
				,@FinalManifested,@CustomsReleaseCodeId,@ItnNumber
				,@liner_release_cd,@customs_release_cd)";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			return -1;

__cs__PostUpdate
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

			ID = ClsConvert.ToInt32Nullable(dr["Id"]);
			Scaccodeid = ClsConvert.ToInt32Nullable(dr["ScacCodeId"]);
			Scac_Cd = ClsConvert.ToString(dr["Scac_cd"]);
			Scac_Company = ClsConvert.ToString(dr["Scac_company"]);
			Booking_No = ClsConvert.ToString(dr["Booking_No"]);
			Alternatebookingnumber = ClsConvert.ToString(dr["AlternateBookingNumber"]);
			Bol_No = ClsConvert.ToString(dr["bol_no"]);
			Alternatenumber = ClsConvert.ToString(dr["AlternateNumber"]);
			Status_Cd = ClsConvert.ToString(dr["status_cd"]);
			Status_Dsc = ClsConvert.ToString(dr["status_dsc"]);
			Voyageid = ClsConvert.ToInt32Nullable(dr["VoyageId"]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
			Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
			Vessel_Name = ClsConvert.ToString(dr["vessel_name"]);
			Callsign = ClsConvert.ToString(dr["CallSign"]);
			Lloydsnumber = ClsConvert.ToString(dr["LloydsNumber"]);
			Plor_ID = ClsConvert.ToInt32Nullable(dr["plor_Id"]);
			Plor_Cd = ClsConvert.ToString(dr["plor_cd"]);
			Plor_Dsc = ClsConvert.ToString(dr["plor_dsc"]);
			Plod_Cd = ClsConvert.ToString(dr["plod_cd"]);
			Plod_Dsc = ClsConvert.ToString(dr["plod_dsc"]);
			Plod_ID = ClsConvert.ToInt32Nullable(dr["plod_id"]);
			Pol_Cd = ClsConvert.ToString(dr["pol_cd"]);
			Pol_Dsc = ClsConvert.ToString(dr["pol_dsc"]);
			Pol_Berth_Cd = ClsConvert.ToString(dr["pol_berth_cd"]);
			Pol_Berth_Dsc = ClsConvert.ToString(dr["pol_berth_dsc"]);
			Pod_Cd = ClsConvert.ToString(dr["pod_cd"]);
			Pod_Dsc = ClsConvert.ToString(dr["pod_dsc"]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["pod_berth_cd"]);
			Pod_Berth_Dsc = ClsConvert.ToString(dr["pod_berth_dsc"]);
			Edireference = ClsConvert.ToString(dr["EdiReference"]);
			Portcallfilenumber = ClsConvert.ToString(dr["PortCallFileNumber"]);
			Projectnumber = ClsConvert.ToString(dr["ProjectNumber"]);
			Contractnumber = ClsConvert.ToString(dr["ContractNumber"]);
			Dateofissue = ClsConvert.ToString(dr["DateOfIssue"]);
			Linerreleasecodeid = ClsConvert.ToInt32Nullable(dr["LinerReleaseCodeId"]);
			Finalmanifested = ClsConvert.ToString(dr["FinalManifested"]);
			Customsreleasecodeid = ClsConvert.ToInt32Nullable(dr["CustomsReleaseCodeId"]);
			Itnnumber = ClsConvert.ToString(dr["ItnNumber"]);
			Liner_Release_Cd = ClsConvert.ToString(dr["liner_release_cd"]);
			Customs_Release_Cd = ClsConvert.ToString(dr["customs_release_cd"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			ID = ClsConvert.ToInt32Nullable(dr["Id", v]);
			Scaccodeid = ClsConvert.ToInt32Nullable(dr["ScacCodeId", v]);
			Scac_Cd = ClsConvert.ToString(dr["Scac_cd", v]);
			Scac_Company = ClsConvert.ToString(dr["Scac_company", v]);
			Booking_No = ClsConvert.ToString(dr["Booking_No", v]);
			Alternatebookingnumber = ClsConvert.ToString(dr["AlternateBookingNumber", v]);
			Bol_No = ClsConvert.ToString(dr["bol_no", v]);
			Alternatenumber = ClsConvert.ToString(dr["AlternateNumber", v]);
			Status_Cd = ClsConvert.ToString(dr["status_cd", v]);
			Status_Dsc = ClsConvert.ToString(dr["status_dsc", v]);
			Voyageid = ClsConvert.ToInt32Nullable(dr["VoyageId", v]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no", v]);
			Vessel_Cd = ClsConvert.ToString(dr["vessel_cd", v]);
			Vessel_Name = ClsConvert.ToString(dr["vessel_name", v]);
			Callsign = ClsConvert.ToString(dr["CallSign", v]);
			Lloydsnumber = ClsConvert.ToString(dr["LloydsNumber", v]);
			Plor_ID = ClsConvert.ToInt32Nullable(dr["plor_Id", v]);
			Plor_Cd = ClsConvert.ToString(dr["plor_cd", v]);
			Plor_Dsc = ClsConvert.ToString(dr["plor_dsc", v]);
			Plod_Cd = ClsConvert.ToString(dr["plod_cd", v]);
			Plod_Dsc = ClsConvert.ToString(dr["plod_dsc", v]);
			Plod_ID = ClsConvert.ToInt32Nullable(dr["plod_id", v]);
			Pol_Cd = ClsConvert.ToString(dr["pol_cd", v]);
			Pol_Dsc = ClsConvert.ToString(dr["pol_dsc", v]);
			Pol_Berth_Cd = ClsConvert.ToString(dr["pol_berth_cd", v]);
			Pol_Berth_Dsc = ClsConvert.ToString(dr["pol_berth_dsc", v]);
			Pod_Cd = ClsConvert.ToString(dr["pod_cd", v]);
			Pod_Dsc = ClsConvert.ToString(dr["pod_dsc", v]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["pod_berth_cd", v]);
			Pod_Berth_Dsc = ClsConvert.ToString(dr["pod_berth_dsc", v]);
			Edireference = ClsConvert.ToString(dr["EdiReference", v]);
			Portcallfilenumber = ClsConvert.ToString(dr["PortCallFileNumber", v]);
			Projectnumber = ClsConvert.ToString(dr["ProjectNumber", v]);
			Contractnumber = ClsConvert.ToString(dr["ContractNumber", v]);
			Dateofissue = ClsConvert.ToString(dr["DateOfIssue", v]);
			Linerreleasecodeid = ClsConvert.ToInt32Nullable(dr["LinerReleaseCodeId", v]);
			Finalmanifested = ClsConvert.ToString(dr["FinalManifested", v]);
			Customsreleasecodeid = ClsConvert.ToInt32Nullable(dr["CustomsReleaseCodeId", v]);
			Itnnumber = ClsConvert.ToString(dr["ItnNumber", v]);
			Liner_Release_Cd = ClsConvert.ToString(dr["liner_release_cd", v]);
			Customs_Release_Cd = ClsConvert.ToString(dr["customs_release_cd", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["Id"] = ClsConvert.ToDbObject(ID);
			dr["ScacCodeId"] = ClsConvert.ToDbObject(Scaccodeid);
			dr["Scac_cd"] = ClsConvert.ToDbObject(Scac_Cd);
			dr["Scac_company"] = ClsConvert.ToDbObject(Scac_Company);
			dr["Booking_No"] = ClsConvert.ToDbObject(Booking_No);
			dr["AlternateBookingNumber"] = ClsConvert.ToDbObject(Alternatebookingnumber);
			dr["bol_no"] = ClsConvert.ToDbObject(Bol_No);
			dr["AlternateNumber"] = ClsConvert.ToDbObject(Alternatenumber);
			dr["status_cd"] = ClsConvert.ToDbObject(Status_Cd);
			dr["status_dsc"] = ClsConvert.ToDbObject(Status_Dsc);
			dr["VoyageId"] = ClsConvert.ToDbObject(Voyageid);
			dr["voyage_no"] = ClsConvert.ToDbObject(Voyage_No);
			dr["vessel_cd"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["vessel_name"] = ClsConvert.ToDbObject(Vessel_Name);
			dr["CallSign"] = ClsConvert.ToDbObject(Callsign);
			dr["LloydsNumber"] = ClsConvert.ToDbObject(Lloydsnumber);
			dr["plor_Id"] = ClsConvert.ToDbObject(Plor_ID);
			dr["plor_cd"] = ClsConvert.ToDbObject(Plor_Cd);
			dr["plor_dsc"] = ClsConvert.ToDbObject(Plor_Dsc);
			dr["plod_cd"] = ClsConvert.ToDbObject(Plod_Cd);
			dr["plod_dsc"] = ClsConvert.ToDbObject(Plod_Dsc);
			dr["plod_id"] = ClsConvert.ToDbObject(Plod_ID);
			dr["pol_cd"] = ClsConvert.ToDbObject(Pol_Cd);
			dr["pol_dsc"] = ClsConvert.ToDbObject(Pol_Dsc);
			dr["pol_berth_cd"] = ClsConvert.ToDbObject(Pol_Berth_Cd);
			dr["pol_berth_dsc"] = ClsConvert.ToDbObject(Pol_Berth_Dsc);
			dr["pod_cd"] = ClsConvert.ToDbObject(Pod_Cd);
			dr["pod_dsc"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["pod_berth_cd"] = ClsConvert.ToDbObject(Pod_Berth_Cd);
			dr["pod_berth_dsc"] = ClsConvert.ToDbObject(Pod_Berth_Dsc);
			dr["EdiReference"] = ClsConvert.ToDbObject(Edireference);
			dr["PortCallFileNumber"] = ClsConvert.ToDbObject(Portcallfilenumber);
			dr["ProjectNumber"] = ClsConvert.ToDbObject(Projectnumber);
			dr["ContractNumber"] = ClsConvert.ToDbObject(Contractnumber);
			dr["DateOfIssue"] = ClsConvert.ToDbObject(Dateofissue);
			dr["LinerReleaseCodeId"] = ClsConvert.ToDbObject(Linerreleasecodeid);
			dr["FinalManifested"] = ClsConvert.ToDbObject(Finalmanifested);
			dr["CustomsReleaseCodeId"] = ClsConvert.ToDbObject(Customsreleasecodeid);
			dr["ItnNumber"] = ClsConvert.ToDbObject(Itnnumber);
			dr["liner_release_cd"] = ClsConvert.ToDbObject(Liner_Release_Cd);
			dr["customs_release_cd"] = ClsConvert.ToDbObject(Customs_Release_Cd);
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