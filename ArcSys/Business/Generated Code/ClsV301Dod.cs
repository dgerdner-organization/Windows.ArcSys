using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsV301Dod : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_301_DOD";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_301_DOD";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Edi_Partner_Xchg_QualifierMax = 2;
		public const int Edi_Partner_Xchg_CdMax = 15;
		public const int Edi_Partner_Gs03Max = 15;
		public const int Edi_Control_VersionMax = 5;
		public const int Edi_TestMax = 1;
		public const int Edi_VersionMax = 6;
		public const int Acms_Status_CdMax = 2;
		public const int Confirm_CdMax = 2;
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Booking_IDMax = 30;
		public const int Poe_FunctionMax = 1;
		public const int Poe_Census_CdMax = 30;
		public const int Poe_DscMax = 50;
		public const int Poe_Census_TypeMax = 2;
		public const int Pod_FunctionMax = 1;
		public const int Pod_Census_CdMax = 30;
		public const int Pod_DscMax = 50;
		public const int Pod_Census_TypeMax = 2;
		public const int Scac_CdMax = 4;
		public const int Eqp_InitialMax = 1;
		public const int Edi_IDMax = 15;
		public const int Voyage_NoMax = 10;
		public const int IrcsMax = 15;
		public const int Vessel_DscMax = 50;
		public const int Vessel_FlagMax = 10;
		public const int Military_Voyage_CdMax = 5;
		public const int Vessel_QualifierMax = 1;
		public const int Contract_NoMax = 30;
		public const int Iso_Eqp_Type_CdMax = 2;
		public const int K1aMax = 4000;
		public const int K1bMax = 4000;
		public const int K2aMax = 4000;
		public const int K2bMax = 4000;
		public const int K3aMax = 4000;
		public const int K3bMax = 4000;
		public const int K4aMax = 4000;
		public const int K4bMax = 4000;
		public const int K5aMax = 4000;
		public const int K5bMax = 4000;
		public const int K6aMax = 4000;
		public const int K6bMax = 4000;
		public const int K7aMax = 4000;
		public const int K7bMax = 4000;
		public const int K8aMax = 4000;
		public const int K8bMax = 4000;
		public const int K9aMax = 4000;
		public const int K9bMax = 4000;
		public const int K10aMax = 4000;
		public const int K10bMax = 4000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Edi_Partner_Xchg_Qualifier;
		protected string _Edi_Partner_Xchg_Cd;
		protected string _Edi_Partner_Gs03;
		protected string _Edi_Control_Version;
		protected string _Edi_Test;
		protected string _Edi_Version;
		protected string _Acms_Status_Cd;
		protected string _Confirm_Cd;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Booking_ID;
		protected string _Poe_Function;
		protected string _Poe_Census_Cd;
		protected string _Poe_Dsc;
		protected string _Poe_Census_Type;
		protected string _Pod_Function;
		protected string _Pod_Census_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Census_Type;
		protected string _Scac_Cd;
		protected string _Eqp_Initial;
		protected decimal? _Eqp_Number;
		protected string _Edi_ID;
		protected decimal? _Cur_Ctl_No;
		protected string _Voyage_No;
		protected string _Ircs;
		protected string _Vessel_Dsc;
		protected string _Vessel_Flag;
		protected string _Military_Voyage_Cd;
		protected string _Vessel_Qualifier;
		protected string _Contract_No;
		protected Int32? _Ship_Units_Nbr;
		protected string _Iso_Eqp_Type_Cd;
		protected DateTime? _Departure_Date;
		protected DateTime? _Arrival_Date;
		protected decimal? _Arrival_Count;
		protected string _K1a;
		protected string _K1b;
		protected string _K2a;
		protected string _K2b;
		protected string _K3a;
		protected string _K3b;
		protected string _K4a;
		protected string _K4b;
		protected string _K5a;
		protected string _K5b;
		protected string _K6a;
		protected string _K6b;
		protected string _K7a;
		protected string _K7b;
		protected string _K8a;
		protected string _K8b;
		protected string _K9a;
		protected string _K9b;
		protected string _K10a;
		protected string _K10b;
		protected DateTime? _Adj_Rdd_Dt;
		protected decimal? _St_Counter;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Edi_Partner_Xchg_Qualifier
		{
			get { return _Edi_Partner_Xchg_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Xchg_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Xchg_QualifierMax )
					_Edi_Partner_Xchg_Qualifier = val.Substring(0, (int)Edi_Partner_Xchg_QualifierMax);
				else
					_Edi_Partner_Xchg_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Xchg_Qualifier");
			}
		}
		public string Edi_Partner_Xchg_Cd
		{
			get { return _Edi_Partner_Xchg_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Xchg_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Xchg_CdMax )
					_Edi_Partner_Xchg_Cd = val.Substring(0, (int)Edi_Partner_Xchg_CdMax);
				else
					_Edi_Partner_Xchg_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Xchg_Cd");
			}
		}
		public string Edi_Partner_Gs03
		{
			get { return _Edi_Partner_Gs03; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Gs03, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Gs03Max )
					_Edi_Partner_Gs03 = val.Substring(0, (int)Edi_Partner_Gs03Max);
				else
					_Edi_Partner_Gs03 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Gs03");
			}
		}
		public string Edi_Control_Version
		{
			get { return _Edi_Control_Version; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Control_Version, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Control_VersionMax )
					_Edi_Control_Version = val.Substring(0, (int)Edi_Control_VersionMax);
				else
					_Edi_Control_Version = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Control_Version");
			}
		}
		public string Edi_Test
		{
			get { return _Edi_Test; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Test, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_TestMax )
					_Edi_Test = val.Substring(0, (int)Edi_TestMax);
				else
					_Edi_Test = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Test");
			}
		}
		public string Edi_Version
		{
			get { return _Edi_Version; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Version, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_VersionMax )
					_Edi_Version = val.Substring(0, (int)Edi_VersionMax);
				else
					_Edi_Version = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Version");
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
		public string Poe_Function
		{
			get { return _Poe_Function; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Function, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_FunctionMax )
					_Poe_Function = val.Substring(0, (int)Poe_FunctionMax);
				else
					_Poe_Function = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Function");
			}
		}
		public string Poe_Census_Cd
		{
			get { return _Poe_Census_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Census_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Census_CdMax )
					_Poe_Census_Cd = val.Substring(0, (int)Poe_Census_CdMax);
				else
					_Poe_Census_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Census_Cd");
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
		public string Poe_Census_Type
		{
			get { return _Poe_Census_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Census_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Census_TypeMax )
					_Poe_Census_Type = val.Substring(0, (int)Poe_Census_TypeMax);
				else
					_Poe_Census_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Census_Type");
			}
		}
		public string Pod_Function
		{
			get { return _Pod_Function; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Function, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_FunctionMax )
					_Pod_Function = val.Substring(0, (int)Pod_FunctionMax);
				else
					_Pod_Function = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Function");
			}
		}
		public string Pod_Census_Cd
		{
			get { return _Pod_Census_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Census_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Census_CdMax )
					_Pod_Census_Cd = val.Substring(0, (int)Pod_Census_CdMax);
				else
					_Pod_Census_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Census_Cd");
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
		public string Pod_Census_Type
		{
			get { return _Pod_Census_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Census_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Census_TypeMax )
					_Pod_Census_Type = val.Substring(0, (int)Pod_Census_TypeMax);
				else
					_Pod_Census_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Census_Type");
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
		public string Eqp_Initial
		{
			get { return _Eqp_Initial; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Eqp_Initial, val, false) == 0 ) return;
		
				if( val != null && val.Length > Eqp_InitialMax )
					_Eqp_Initial = val.Substring(0, (int)Eqp_InitialMax);
				else
					_Eqp_Initial = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Eqp_Initial");
			}
		}
		public decimal? Eqp_Number
		{
			get { return _Eqp_Number; }
			set
			{
				if( _Eqp_Number == value ) return;
		
				_Eqp_Number = value;
				_IsDirty = true;
				NotifyPropertyChanged("Eqp_Number");
			}
		}
		public string Edi_ID
		{
			get { return _Edi_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_IDMax )
					_Edi_ID = val.Substring(0, (int)Edi_IDMax);
				else
					_Edi_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_ID");
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
		public string Vessel_Flag
		{
			get { return _Vessel_Flag; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Flag, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_FlagMax )
					_Vessel_Flag = val.Substring(0, (int)Vessel_FlagMax);
				else
					_Vessel_Flag = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Flag");
			}
		}
		public string Military_Voyage_Cd
		{
			get { return _Military_Voyage_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Military_Voyage_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Military_Voyage_CdMax )
					_Military_Voyage_Cd = val.Substring(0, (int)Military_Voyage_CdMax);
				else
					_Military_Voyage_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Military_Voyage_Cd");
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
		public DateTime? Departure_Date
		{
			get { return _Departure_Date; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Departure_Date == val ) return;
		
				_Departure_Date = val;
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Date");
			}
		}
		public DateTime? Arrival_Date
		{
			get { return _Arrival_Date; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Arrival_Date == val ) return;
		
				_Arrival_Date = val;
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Date");
			}
		}
		public decimal? Arrival_Count
		{
			get { return _Arrival_Count; }
			set
			{
				if( _Arrival_Count == value ) return;
		
				_Arrival_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Count");
			}
		}
		public string K1a
		{
			get { return _K1a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K1a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K1aMax )
					_K1a = val.Substring(0, (int)K1aMax);
				else
					_K1a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K1a");
			}
		}
		public string K1b
		{
			get { return _K1b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K1b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K1bMax )
					_K1b = val.Substring(0, (int)K1bMax);
				else
					_K1b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K1b");
			}
		}
		public string K2a
		{
			get { return _K2a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K2a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K2aMax )
					_K2a = val.Substring(0, (int)K2aMax);
				else
					_K2a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K2a");
			}
		}
		public string K2b
		{
			get { return _K2b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K2b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K2bMax )
					_K2b = val.Substring(0, (int)K2bMax);
				else
					_K2b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K2b");
			}
		}
		public string K3a
		{
			get { return _K3a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K3a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K3aMax )
					_K3a = val.Substring(0, (int)K3aMax);
				else
					_K3a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K3a");
			}
		}
		public string K3b
		{
			get { return _K3b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K3b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K3bMax )
					_K3b = val.Substring(0, (int)K3bMax);
				else
					_K3b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K3b");
			}
		}
		public string K4a
		{
			get { return _K4a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K4a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K4aMax )
					_K4a = val.Substring(0, (int)K4aMax);
				else
					_K4a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K4a");
			}
		}
		public string K4b
		{
			get { return _K4b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K4b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K4bMax )
					_K4b = val.Substring(0, (int)K4bMax);
				else
					_K4b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K4b");
			}
		}
		public string K5a
		{
			get { return _K5a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K5a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K5aMax )
					_K5a = val.Substring(0, (int)K5aMax);
				else
					_K5a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K5a");
			}
		}
		public string K5b
		{
			get { return _K5b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K5b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K5bMax )
					_K5b = val.Substring(0, (int)K5bMax);
				else
					_K5b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K5b");
			}
		}
		public string K6a
		{
			get { return _K6a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K6a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K6aMax )
					_K6a = val.Substring(0, (int)K6aMax);
				else
					_K6a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K6a");
			}
		}
		public string K6b
		{
			get { return _K6b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K6b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K6bMax )
					_K6b = val.Substring(0, (int)K6bMax);
				else
					_K6b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K6b");
			}
		}
		public string K7a
		{
			get { return _K7a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K7a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K7aMax )
					_K7a = val.Substring(0, (int)K7aMax);
				else
					_K7a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K7a");
			}
		}
		public string K7b
		{
			get { return _K7b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K7b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K7bMax )
					_K7b = val.Substring(0, (int)K7bMax);
				else
					_K7b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K7b");
			}
		}
		public string K8a
		{
			get { return _K8a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K8a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K8aMax )
					_K8a = val.Substring(0, (int)K8aMax);
				else
					_K8a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K8a");
			}
		}
		public string K8b
		{
			get { return _K8b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K8b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K8bMax )
					_K8b = val.Substring(0, (int)K8bMax);
				else
					_K8b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K8b");
			}
		}
		public string K9a
		{
			get { return _K9a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K9a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K9aMax )
					_K9a = val.Substring(0, (int)K9aMax);
				else
					_K9a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K9a");
			}
		}
		public string K9b
		{
			get { return _K9b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K9b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K9bMax )
					_K9b = val.Substring(0, (int)K9bMax);
				else
					_K9b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K9b");
			}
		}
		public string K10a
		{
			get { return _K10a; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K10a, val, false) == 0 ) return;
		
				if( val != null && val.Length > K10aMax )
					_K10a = val.Substring(0, (int)K10aMax);
				else
					_K10a = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K10a");
			}
		}
		public string K10b
		{
			get { return _K10b; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_K10b, val, false) == 0 ) return;
		
				if( val != null && val.Length > K10bMax )
					_K10b = val.Substring(0, (int)K10bMax);
				else
					_K10b = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("K10b");
			}
		}
		public DateTime? Adj_Rdd_Dt
		{
			get { return _Adj_Rdd_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Adj_Rdd_Dt == val ) return;
		
				_Adj_Rdd_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Adj_Rdd_Dt");
			}
		}
		public decimal? St_Counter
		{
			get { return _St_Counter; }
			set
			{
				if( _St_Counter == value ) return;
		
				_St_Counter = value;
				_IsDirty = true;
				NotifyPropertyChanged("St_Counter");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsV301Dod() : base() {}
		public ClsV301Dod(DataRow dr) : base(dr) {}
		public ClsV301Dod(ClsV301Dod src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Partner_Xchg_Qualifier = null;
			Edi_Partner_Xchg_Cd = null;
			Edi_Partner_Gs03 = null;
			Edi_Control_Version = null;
			Edi_Test = null;
			Edi_Version = null;
			Acms_Status_Cd = null;
			Confirm_Cd = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Booking_ID = null;
			Poe_Function = null;
			Poe_Census_Cd = null;
			Poe_Dsc = null;
			Poe_Census_Type = null;
			Pod_Function = null;
			Pod_Census_Cd = null;
			Pod_Dsc = null;
			Pod_Census_Type = null;
			Scac_Cd = null;
			Eqp_Initial = null;
			Eqp_Number = null;
			Edi_ID = null;
			Cur_Ctl_No = null;
			Voyage_No = null;
			Ircs = null;
			Vessel_Dsc = null;
			Vessel_Flag = null;
			Military_Voyage_Cd = null;
			Vessel_Qualifier = null;
			Contract_No = null;
			Ship_Units_Nbr = null;
			Iso_Eqp_Type_Cd = null;
			Departure_Date = null;
			Arrival_Date = null;
			Arrival_Count = null;
			K1a = null;
			K1b = null;
			K2a = null;
			K2b = null;
			K3a = null;
			K3b = null;
			K4a = null;
			K4b = null;
			K5a = null;
			K5b = null;
			K6a = null;
			K6b = null;
			K7a = null;
			K7b = null;
			K8a = null;
			K8b = null;
			K9a = null;
			K9b = null;
			K10a = null;
			K10b = null;
			Adj_Rdd_Dt = null;
			St_Counter = null;
		}

		public void CopyFrom(ClsV301Dod src)
		{
			Edi_Partner_Xchg_Qualifier = src._Edi_Partner_Xchg_Qualifier;
			Edi_Partner_Xchg_Cd = src._Edi_Partner_Xchg_Cd;
			Edi_Partner_Gs03 = src._Edi_Partner_Gs03;
			Edi_Control_Version = src._Edi_Control_Version;
			Edi_Test = src._Edi_Test;
			Edi_Version = src._Edi_Version;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Confirm_Cd = src._Confirm_Cd;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Booking_ID = src._Booking_ID;
			Poe_Function = src._Poe_Function;
			Poe_Census_Cd = src._Poe_Census_Cd;
			Poe_Dsc = src._Poe_Dsc;
			Poe_Census_Type = src._Poe_Census_Type;
			Pod_Function = src._Pod_Function;
			Pod_Census_Cd = src._Pod_Census_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Census_Type = src._Pod_Census_Type;
			Scac_Cd = src._Scac_Cd;
			Eqp_Initial = src._Eqp_Initial;
			Eqp_Number = src._Eqp_Number;
			Edi_ID = src._Edi_ID;
			Cur_Ctl_No = src._Cur_Ctl_No;
			Voyage_No = src._Voyage_No;
			Ircs = src._Ircs;
			Vessel_Dsc = src._Vessel_Dsc;
			Vessel_Flag = src._Vessel_Flag;
			Military_Voyage_Cd = src._Military_Voyage_Cd;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Contract_No = src._Contract_No;
			Ship_Units_Nbr = src._Ship_Units_Nbr;
			Iso_Eqp_Type_Cd = src._Iso_Eqp_Type_Cd;
			Departure_Date = src._Departure_Date;
			Arrival_Date = src._Arrival_Date;
			Arrival_Count = src._Arrival_Count;
			K1a = src._K1a;
			K1b = src._K1b;
			K2a = src._K2a;
			K2b = src._K2b;
			K3a = src._K3a;
			K3b = src._K3b;
			K4a = src._K4a;
			K4b = src._K4b;
			K5a = src._K5a;
			K5b = src._K5b;
			K6a = src._K6a;
			K6b = src._K6b;
			K7a = src._K7a;
			K7b = src._K7b;
			K8a = src._K8a;
			K8b = src._K8b;
			K9a = src._K9a;
			K9b = src._K9b;
			K10a = src._K10a;
			K10b = src._K10b;
			Adj_Rdd_Dt = src._Adj_Rdd_Dt;
			St_Counter = src._St_Counter;
		}

		public override bool ReloadFromDB()
		{
			ClsV301Dod tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[58];

			p[0] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_QUALIFIER", Edi_Partner_Xchg_Qualifier);
			p[1] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_CD", Edi_Partner_Xchg_Cd);
			p[2] = Connection.GetParameter
				("@EDI_PARTNER_GS03", Edi_Partner_Gs03);
			p[3] = Connection.GetParameter
				("@EDI_CONTROL_VERSION", Edi_Control_Version);
			p[4] = Connection.GetParameter
				("@EDI_TEST", Edi_Test);
			p[5] = Connection.GetParameter
				("@EDI_VERSION", Edi_Version);
			p[6] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[7] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[8] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[9] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[10] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[11] = Connection.GetParameter
				("@POE_FUNCTION", Poe_Function);
			p[12] = Connection.GetParameter
				("@POE_CENSUS_CD", Poe_Census_Cd);
			p[13] = Connection.GetParameter
				("@POE_DSC", Poe_Dsc);
			p[14] = Connection.GetParameter
				("@POE_CENSUS_TYPE", Poe_Census_Type);
			p[15] = Connection.GetParameter
				("@POD_FUNCTION", Pod_Function);
			p[16] = Connection.GetParameter
				("@POD_CENSUS_CD", Pod_Census_Cd);
			p[17] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[18] = Connection.GetParameter
				("@POD_CENSUS_TYPE", Pod_Census_Type);
			p[19] = Connection.GetParameter
				("@SCAC_CD", Scac_Cd);
			p[20] = Connection.GetParameter
				("@EQP_INITIAL", Eqp_Initial);
			p[21] = Connection.GetParameter
				("@EQP_NUMBER", Eqp_Number);
			p[22] = Connection.GetParameter
				("@EDI_ID", Edi_ID);
			p[23] = Connection.GetParameter
				("@CUR_CTL_NO", Cur_Ctl_No);
			p[24] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[25] = Connection.GetParameter
				("@IRCS", Ircs);
			p[26] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[27] = Connection.GetParameter
				("@VESSEL_FLAG", Vessel_Flag);
			p[28] = Connection.GetParameter
				("@MILITARY_VOYAGE_CD", Military_Voyage_Cd);
			p[29] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[30] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[31] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[32] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[33] = Connection.GetParameter
				("@DEPARTURE_DATE", Departure_Date);
			p[34] = Connection.GetParameter
				("@ARRIVAL_DATE", Arrival_Date);
			p[35] = Connection.GetParameter
				("@ARRIVAL_COUNT", Arrival_Count);
			p[36] = Connection.GetParameter
				("@K1A", K1a);
			p[37] = Connection.GetParameter
				("@K1B", K1b);
			p[38] = Connection.GetParameter
				("@K2A", K2a);
			p[39] = Connection.GetParameter
				("@K2B", K2b);
			p[40] = Connection.GetParameter
				("@K3A", K3a);
			p[41] = Connection.GetParameter
				("@K3B", K3b);
			p[42] = Connection.GetParameter
				("@K4A", K4a);
			p[43] = Connection.GetParameter
				("@K4B", K4b);
			p[44] = Connection.GetParameter
				("@K5A", K5a);
			p[45] = Connection.GetParameter
				("@K5B", K5b);
			p[46] = Connection.GetParameter
				("@K6A", K6a);
			p[47] = Connection.GetParameter
				("@K6B", K6b);
			p[48] = Connection.GetParameter
				("@K7A", K7a);
			p[49] = Connection.GetParameter
				("@K7B", K7b);
			p[50] = Connection.GetParameter
				("@K8A", K8a);
			p[51] = Connection.GetParameter
				("@K8B", K8b);
			p[52] = Connection.GetParameter
				("@K9A", K9a);
			p[53] = Connection.GetParameter
				("@K9B", K9b);
			p[54] = Connection.GetParameter
				("@K10A", K10a);
			p[55] = Connection.GetParameter
				("@K10B", K10b);
			p[56] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[57] = Connection.GetParameter
				("@ST_COUNTER", St_Counter);

			const string sql = @"
				INSERT INTO V_301_DOD
					(EDI_PARTNER_XCHG_QUALIFIER, EDI_PARTNER_XCHG_CD, EDI_PARTNER_GS03,
					EDI_CONTROL_VERSION, EDI_TEST, EDI_VERSION,
					ACMS_STATUS_CD, CONFIRM_CD, PARTNER_CD,
					PARTNER_REQUEST_CD, BOOKING_ID, POE_FUNCTION,
					POE_CENSUS_CD, POE_DSC, POE_CENSUS_TYPE,
					POD_FUNCTION, POD_CENSUS_CD, POD_DSC,
					POD_CENSUS_TYPE, SCAC_CD, EQP_INITIAL,
					EQP_NUMBER, EDI_ID, CUR_CTL_NO,
					VOYAGE_NO, IRCS, VESSEL_DSC,
					VESSEL_FLAG, MILITARY_VOYAGE_CD, VESSEL_QUALIFIER,
					CONTRACT_NO, SHIP_UNITS_NBR, ISO_EQP_TYPE_CD,
					DEPARTURE_DATE, ARRIVAL_DATE, ARRIVAL_COUNT,
					K1A, K1B, K2A,
					K2B, K3A, K3B,
					K4A, K4B, K5A,
					K5B, K6A, K6B,
					K7A, K7B, K8A,
					K8B, K9A, K9B,
					K10A, K10B, ADJ_RDD_DT,
					ST_COUNTER)
				VALUES
					(@EDI_PARTNER_XCHG_QUALIFIER, @EDI_PARTNER_XCHG_CD, @EDI_PARTNER_GS03,
					@EDI_CONTROL_VERSION, @EDI_TEST, @EDI_VERSION,
					@ACMS_STATUS_CD, @CONFIRM_CD, @PARTNER_CD,
					@PARTNER_REQUEST_CD, @BOOKING_ID, @POE_FUNCTION,
					@POE_CENSUS_CD, @POE_DSC, @POE_CENSUS_TYPE,
					@POD_FUNCTION, @POD_CENSUS_CD, @POD_DSC,
					@POD_CENSUS_TYPE, @SCAC_CD, @EQP_INITIAL,
					@EQP_NUMBER, @EDI_ID, @CUR_CTL_NO,
					@VOYAGE_NO, @IRCS, @VESSEL_DSC,
					@VESSEL_FLAG, @MILITARY_VOYAGE_CD, @VESSEL_QUALIFIER,
					@CONTRACT_NO, @SHIP_UNITS_NBR, @ISO_EQP_TYPE_CD,
					@DEPARTURE_DATE, @ARRIVAL_DATE, @ARRIVAL_COUNT,
					@K1A, @K1B, @K2A,
					@K2B, @K3A, @K3B,
					@K4A, @K4B, @K5A,
					@K5B, @K6A, @K6B,
					@K7A, @K7B, @K8A,
					@K8B, @K9A, @K9B,
					@K10A, @K10B, @ADJ_RDD_DT,
					@ST_COUNTER)
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

			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER"]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD"]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03"]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION"]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST"]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Poe_Function = ClsConvert.ToString(dr["POE_FUNCTION"]);
			Poe_Census_Cd = ClsConvert.ToString(dr["POE_CENSUS_CD"]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC"]);
			Poe_Census_Type = ClsConvert.ToString(dr["POE_CENSUS_TYPE"]);
			Pod_Function = ClsConvert.ToString(dr["POD_FUNCTION"]);
			Pod_Census_Cd = ClsConvert.ToString(dr["POD_CENSUS_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Pod_Census_Type = ClsConvert.ToString(dr["POD_CENSUS_TYPE"]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD"]);
			Eqp_Initial = ClsConvert.ToString(dr["EQP_INITIAL"]);
			Eqp_Number = ClsConvert.ToDecimalNullable(dr["EQP_NUMBER"]);
			Edi_ID = ClsConvert.ToString(dr["EDI_ID"]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Ircs = ClsConvert.ToString(dr["IRCS"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Vessel_Flag = ClsConvert.ToString(dr["VESSEL_FLAG"]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR"]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD"]);
			Departure_Date = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DATE"]);
			Arrival_Date = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DATE"]);
			Arrival_Count = ClsConvert.ToDecimalNullable(dr["ARRIVAL_COUNT"]);
			K1a = ClsConvert.ToString(dr["K1A"]);
			K1b = ClsConvert.ToString(dr["K1B"]);
			K2a = ClsConvert.ToString(dr["K2A"]);
			K2b = ClsConvert.ToString(dr["K2B"]);
			K3a = ClsConvert.ToString(dr["K3A"]);
			K3b = ClsConvert.ToString(dr["K3B"]);
			K4a = ClsConvert.ToString(dr["K4A"]);
			K4b = ClsConvert.ToString(dr["K4B"]);
			K5a = ClsConvert.ToString(dr["K5A"]);
			K5b = ClsConvert.ToString(dr["K5B"]);
			K6a = ClsConvert.ToString(dr["K6A"]);
			K6b = ClsConvert.ToString(dr["K6B"]);
			K7a = ClsConvert.ToString(dr["K7A"]);
			K7b = ClsConvert.ToString(dr["K7B"]);
			K8a = ClsConvert.ToString(dr["K8A"]);
			K8b = ClsConvert.ToString(dr["K8B"]);
			K9a = ClsConvert.ToString(dr["K9A"]);
			K9b = ClsConvert.ToString(dr["K9B"]);
			K10a = ClsConvert.ToString(dr["K10A"]);
			K10b = ClsConvert.ToString(dr["K10B"]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT"]);
			St_Counter = ClsConvert.ToDecimalNullable(dr["ST_COUNTER"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER", v]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD", v]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03", v]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION", v]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST", v]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Poe_Function = ClsConvert.ToString(dr["POE_FUNCTION", v]);
			Poe_Census_Cd = ClsConvert.ToString(dr["POE_CENSUS_CD", v]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC", v]);
			Poe_Census_Type = ClsConvert.ToString(dr["POE_CENSUS_TYPE", v]);
			Pod_Function = ClsConvert.ToString(dr["POD_FUNCTION", v]);
			Pod_Census_Cd = ClsConvert.ToString(dr["POD_CENSUS_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Pod_Census_Type = ClsConvert.ToString(dr["POD_CENSUS_TYPE", v]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD", v]);
			Eqp_Initial = ClsConvert.ToString(dr["EQP_INITIAL", v]);
			Eqp_Number = ClsConvert.ToDecimalNullable(dr["EQP_NUMBER", v]);
			Edi_ID = ClsConvert.ToString(dr["EDI_ID", v]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Ircs = ClsConvert.ToString(dr["IRCS", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Vessel_Flag = ClsConvert.ToString(dr["VESSEL_FLAG", v]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR", v]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD", v]);
			Departure_Date = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DATE", v]);
			Arrival_Date = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DATE", v]);
			Arrival_Count = ClsConvert.ToDecimalNullable(dr["ARRIVAL_COUNT", v]);
			K1a = ClsConvert.ToString(dr["K1A", v]);
			K1b = ClsConvert.ToString(dr["K1B", v]);
			K2a = ClsConvert.ToString(dr["K2A", v]);
			K2b = ClsConvert.ToString(dr["K2B", v]);
			K3a = ClsConvert.ToString(dr["K3A", v]);
			K3b = ClsConvert.ToString(dr["K3B", v]);
			K4a = ClsConvert.ToString(dr["K4A", v]);
			K4b = ClsConvert.ToString(dr["K4B", v]);
			K5a = ClsConvert.ToString(dr["K5A", v]);
			K5b = ClsConvert.ToString(dr["K5B", v]);
			K6a = ClsConvert.ToString(dr["K6A", v]);
			K6b = ClsConvert.ToString(dr["K6B", v]);
			K7a = ClsConvert.ToString(dr["K7A", v]);
			K7b = ClsConvert.ToString(dr["K7B", v]);
			K8a = ClsConvert.ToString(dr["K8A", v]);
			K8b = ClsConvert.ToString(dr["K8B", v]);
			K9a = ClsConvert.ToString(dr["K9A", v]);
			K9b = ClsConvert.ToString(dr["K9B", v]);
			K10a = ClsConvert.ToString(dr["K10A", v]);
			K10b = ClsConvert.ToString(dr["K10B", v]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT", v]);
			St_Counter = ClsConvert.ToDecimalNullable(dr["ST_COUNTER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_PARTNER_XCHG_QUALIFIER"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Qualifier);
			dr["EDI_PARTNER_XCHG_CD"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Cd);
			dr["EDI_PARTNER_GS03"] = ClsConvert.ToDbObject(Edi_Partner_Gs03);
			dr["EDI_CONTROL_VERSION"] = ClsConvert.ToDbObject(Edi_Control_Version);
			dr["EDI_TEST"] = ClsConvert.ToDbObject(Edi_Test);
			dr["EDI_VERSION"] = ClsConvert.ToDbObject(Edi_Version);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["CONFIRM_CD"] = ClsConvert.ToDbObject(Confirm_Cd);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["POE_FUNCTION"] = ClsConvert.ToDbObject(Poe_Function);
			dr["POE_CENSUS_CD"] = ClsConvert.ToDbObject(Poe_Census_Cd);
			dr["POE_DSC"] = ClsConvert.ToDbObject(Poe_Dsc);
			dr["POE_CENSUS_TYPE"] = ClsConvert.ToDbObject(Poe_Census_Type);
			dr["POD_FUNCTION"] = ClsConvert.ToDbObject(Pod_Function);
			dr["POD_CENSUS_CD"] = ClsConvert.ToDbObject(Pod_Census_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["POD_CENSUS_TYPE"] = ClsConvert.ToDbObject(Pod_Census_Type);
			dr["SCAC_CD"] = ClsConvert.ToDbObject(Scac_Cd);
			dr["EQP_INITIAL"] = ClsConvert.ToDbObject(Eqp_Initial);
			dr["EQP_NUMBER"] = ClsConvert.ToDbObject(Eqp_Number);
			dr["EDI_ID"] = ClsConvert.ToDbObject(Edi_ID);
			dr["CUR_CTL_NO"] = ClsConvert.ToDbObject(Cur_Ctl_No);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["IRCS"] = ClsConvert.ToDbObject(Ircs);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["VESSEL_FLAG"] = ClsConvert.ToDbObject(Vessel_Flag);
			dr["MILITARY_VOYAGE_CD"] = ClsConvert.ToDbObject(Military_Voyage_Cd);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["SHIP_UNITS_NBR"] = ClsConvert.ToDbObject(Ship_Units_Nbr);
			dr["ISO_EQP_TYPE_CD"] = ClsConvert.ToDbObject(Iso_Eqp_Type_Cd);
			dr["DEPARTURE_DATE"] = ClsConvert.ToDbObject(Departure_Date);
			dr["ARRIVAL_DATE"] = ClsConvert.ToDbObject(Arrival_Date);
			dr["ARRIVAL_COUNT"] = ClsConvert.ToDbObject(Arrival_Count);
			dr["K1A"] = ClsConvert.ToDbObject(K1a);
			dr["K1B"] = ClsConvert.ToDbObject(K1b);
			dr["K2A"] = ClsConvert.ToDbObject(K2a);
			dr["K2B"] = ClsConvert.ToDbObject(K2b);
			dr["K3A"] = ClsConvert.ToDbObject(K3a);
			dr["K3B"] = ClsConvert.ToDbObject(K3b);
			dr["K4A"] = ClsConvert.ToDbObject(K4a);
			dr["K4B"] = ClsConvert.ToDbObject(K4b);
			dr["K5A"] = ClsConvert.ToDbObject(K5a);
			dr["K5B"] = ClsConvert.ToDbObject(K5b);
			dr["K6A"] = ClsConvert.ToDbObject(K6a);
			dr["K6B"] = ClsConvert.ToDbObject(K6b);
			dr["K7A"] = ClsConvert.ToDbObject(K7a);
			dr["K7B"] = ClsConvert.ToDbObject(K7b);
			dr["K8A"] = ClsConvert.ToDbObject(K8a);
			dr["K8B"] = ClsConvert.ToDbObject(K8b);
			dr["K9A"] = ClsConvert.ToDbObject(K9a);
			dr["K9B"] = ClsConvert.ToDbObject(K9b);
			dr["K10A"] = ClsConvert.ToDbObject(K10a);
			dr["K10B"] = ClsConvert.ToDbObject(K10b);
			dr["ADJ_RDD_DT"] = ClsConvert.ToDbObject(Adj_Rdd_Dt);
			dr["ST_COUNTER"] = ClsConvert.ToDbObject(St_Counter);
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