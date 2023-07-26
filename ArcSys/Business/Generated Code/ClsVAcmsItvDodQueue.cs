using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVAcmsItvDodQueue : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_ACMS_ITV_DOD_QUEUE";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_ACMS_ITV_DOD_QUEUE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Booking_IDMax = 30;
		public const int Booking_SubMax = 5;
		public const int Activity_CodeMax = 2;
		public const int Activity_DtMax = 8;
		public const int Activity_TimeMax = 4;
		public const int Voyage_NoMax = 10;
		public const int Military_Voyage_CdMax = 5;
		public const int Location_CdMax = 10;
		public const int IrcsMax = 15;
		public const int Vessel_DscMax = 50;
		public const int Vessel_QualifierMax = 1;
		public const int Edi_Control_StdMax = 1;
		public const int Edi_Control_VersionMax = 5;
		public const int Edi_VersionMax = 6;
		public const int Edi_TestMax = 1;
		public const int Edi_Partner_Xchg_CdMax = 15;
		public const int Edi_Partner_Xchg_QualifierMax = 2;
		public const int Edi_Partner_Gs03Max = 15;
		public const int TcnMax = 30;
		public const int Wt_QualifierMax = 1;
		public const int Volume_QualifierMax = 2;
		public const int Wt_Unit_CdMax = 2;
		public const int Scac_CdMax = 4;
		public const int Shipper_CityMax = 30;
		public const int Location_Poe_CdMax = 10;
		public const int Location_Pod_CdMax = 10;
		public const int Rcvr_CityMax = 30;
		public const int Act_DscMax = 50;
		public const int Act_CensusMax = 30;
		public const int Act_CityMax = 20;
		public const int Act_State_CdMax = 2;
		public const int Act_Country_CdMax = 3;
		public const int Poe_DscMax = 50;
		public const int Poe_CensusMax = 30;
		public const int Poe_Census_TypeMax = 1;
		public const int Poe_CityMax = 20;
		public const int Poe_State_CdMax = 2;
		public const int Poe_Country_CdMax = 3;
		public const int Pod_DscMax = 50;
		public const int Pod_CensusMax = 30;
		public const int Pod_Census_TypeMax = 1;
		public const int Pod_CityMax = 20;
		public const int Pod_State_CdMax = 2;
		public const int Pod_Country_CdMax = 3;
		public const int Departure_QualifierMax = 3;
		public const int Arrival_QualifierMax = 3;
		public const int Poe_Est_Sail_DateMax = 8;
		public const int Poe_Est_Sail_TimeMax = 4;
		public const int Pod_Est_Arrival_DateMax = 8;
		public const int Pod_Est_Arrival_TimeMax = 4;
		public const int Location_QualifierMax = 2;
		public const int Poe_Water_PortMax = 30;
		public const int Pod_Water_PortMax = 30;
		public const int Pickup_DodaacMax = 200;
		public const int Consignee_DodaacMax = 200;
		public const int Pickup_DtMax = 8;
		public const int Pickup_TmMax = 4;
		public const int Pickup_Qualifier_CdMax = 3;
		public const int Delivery_DtMax = 8;
		public const int Delivery_TmMax = 4;
		public const int Delivery_Qualifier_CdMax = 3;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Activity_ID;
		protected decimal? _St_Count;
		protected decimal? _Cur_Ctl_No;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Booking_ID;
		protected string _Booking_Sub;
		protected Int64? _Item_No;
		protected string _Activity_Code;
		protected string _Activity_Dt;
		protected string _Activity_Time;
		protected string _Voyage_No;
		protected string _Military_Voyage_Cd;
		protected string _Location_Cd;
		protected string _Ircs;
		protected string _Vessel_Dsc;
		protected string _Vessel_Qualifier;
		protected DateTime? _Estimated_Sail_Date;
		protected string _Edi_Control_Std;
		protected string _Edi_Control_Version;
		protected string _Edi_Version;
		protected string _Edi_Test;
		protected string _Edi_Partner_Xchg_Cd;
		protected string _Edi_Partner_Xchg_Qualifier;
		protected string _Edi_Partner_Gs03;
		protected string _Tcn;
		protected decimal? _Lading_Qty_Nbr;
		protected Double? _Wt_Nbr;
		protected string _Wt_Qualifier;
		protected Double? _Volume_Nbr;
		protected string _Volume_Qualifier;
		protected string _Wt_Unit_Cd;
		protected string _Scac_Cd;
		protected string _Shipper_City;
		protected string _Location_Poe_Cd;
		protected string _Location_Pod_Cd;
		protected string _Rcvr_City;
		protected string _Act_Dsc;
		protected string _Act_Census;
		protected string _Act_City;
		protected string _Act_State_Cd;
		protected string _Act_Country_Cd;
		protected string _Poe_Dsc;
		protected string _Poe_Census;
		protected string _Poe_Census_Type;
		protected string _Poe_City;
		protected string _Poe_State_Cd;
		protected string _Poe_Country_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Census;
		protected string _Pod_Census_Type;
		protected string _Pod_City;
		protected string _Pod_State_Cd;
		protected string _Pod_Country_Cd;
		protected string _Departure_Qualifier;
		protected string _Arrival_Qualifier;
		protected string _Poe_Est_Sail_Date;
		protected string _Poe_Est_Sail_Time;
		protected string _Pod_Est_Arrival_Date;
		protected string _Pod_Est_Arrival_Time;
		protected string _Location_Qualifier;
		protected string _Poe_Water_Port;
		protected string _Pod_Water_Port;
		protected string _Pickup_Dodaac;
		protected string _Consignee_Dodaac;
		protected string _Pickup_Dt;
		protected string _Pickup_Tm;
		protected string _Pickup_Qualifier_Cd;
		protected string _Delivery_Dt;
		protected string _Delivery_Tm;
		protected string _Delivery_Qualifier_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Activity_ID
		{
			get { return _Activity_ID; }
			set
			{
				if( _Activity_ID == value ) return;
		
				_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_ID");
			}
		}
		public decimal? St_Count
		{
			get { return _St_Count; }
			set
			{
				if( _St_Count == value ) return;
		
				_St_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("St_Count");
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
		public string Booking_Sub
		{
			get { return _Booking_Sub; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_Sub, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_SubMax )
					_Booking_Sub = val.Substring(0, (int)Booking_SubMax);
				else
					_Booking_Sub = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Sub");
			}
		}
		public Int64? Item_No
		{
			get { return _Item_No; }
			set
			{
				if( _Item_No == value ) return;
		
				_Item_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Item_No");
			}
		}
		public string Activity_Code
		{
			get { return _Activity_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CodeMax )
					_Activity_Code = val.Substring(0, (int)Activity_CodeMax);
				else
					_Activity_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Code");
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
		public DateTime? Estimated_Sail_Date
		{
			get { return _Estimated_Sail_Date; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Estimated_Sail_Date == val ) return;
		
				_Estimated_Sail_Date = val;
				_IsDirty = true;
				NotifyPropertyChanged("Estimated_Sail_Date");
			}
		}
		public string Edi_Control_Std
		{
			get { return _Edi_Control_Std; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Control_Std, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Control_StdMax )
					_Edi_Control_Std = val.Substring(0, (int)Edi_Control_StdMax);
				else
					_Edi_Control_Std = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Control_Std");
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
		public string Tcn
		{
			get { return _Tcn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tcn, val, false) == 0 ) return;
		
				if( val != null && val.Length > TcnMax )
					_Tcn = val.Substring(0, (int)TcnMax);
				else
					_Tcn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tcn");
			}
		}
		public decimal? Lading_Qty_Nbr
		{
			get { return _Lading_Qty_Nbr; }
			set
			{
				if( _Lading_Qty_Nbr == value ) return;
		
				_Lading_Qty_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lading_Qty_Nbr");
			}
		}
		public Double? Wt_Nbr
		{
			get { return _Wt_Nbr; }
			set
			{
				if( _Wt_Nbr == value ) return;
		
				_Wt_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Nbr");
			}
		}
		public string Wt_Qualifier
		{
			get { return _Wt_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Wt_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Wt_QualifierMax )
					_Wt_Qualifier = val.Substring(0, (int)Wt_QualifierMax);
				else
					_Wt_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Qualifier");
			}
		}
		public Double? Volume_Nbr
		{
			get { return _Volume_Nbr; }
			set
			{
				if( _Volume_Nbr == value ) return;
		
				_Volume_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Volume_Nbr");
			}
		}
		public string Volume_Qualifier
		{
			get { return _Volume_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Volume_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Volume_QualifierMax )
					_Volume_Qualifier = val.Substring(0, (int)Volume_QualifierMax);
				else
					_Volume_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Volume_Qualifier");
			}
		}
		public string Wt_Unit_Cd
		{
			get { return _Wt_Unit_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Wt_Unit_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Wt_Unit_CdMax )
					_Wt_Unit_Cd = val.Substring(0, (int)Wt_Unit_CdMax);
				else
					_Wt_Unit_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Unit_Cd");
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
		public string Act_Dsc
		{
			get { return _Act_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Act_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Act_DscMax )
					_Act_Dsc = val.Substring(0, (int)Act_DscMax);
				else
					_Act_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Act_Dsc");
			}
		}
		public string Act_Census
		{
			get { return _Act_Census; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Act_Census, val, false) == 0 ) return;
		
				if( val != null && val.Length > Act_CensusMax )
					_Act_Census = val.Substring(0, (int)Act_CensusMax);
				else
					_Act_Census = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Act_Census");
			}
		}
		public string Act_City
		{
			get { return _Act_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Act_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Act_CityMax )
					_Act_City = val.Substring(0, (int)Act_CityMax);
				else
					_Act_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Act_City");
			}
		}
		public string Act_State_Cd
		{
			get { return _Act_State_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Act_State_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Act_State_CdMax )
					_Act_State_Cd = val.Substring(0, (int)Act_State_CdMax);
				else
					_Act_State_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Act_State_Cd");
			}
		}
		public string Act_Country_Cd
		{
			get { return _Act_Country_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Act_Country_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Act_Country_CdMax )
					_Act_Country_Cd = val.Substring(0, (int)Act_Country_CdMax);
				else
					_Act_Country_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Act_Country_Cd");
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
		public string Poe_City
		{
			get { return _Poe_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_CityMax )
					_Poe_City = val.Substring(0, (int)Poe_CityMax);
				else
					_Poe_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_City");
			}
		}
		public string Poe_State_Cd
		{
			get { return _Poe_State_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_State_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_State_CdMax )
					_Poe_State_Cd = val.Substring(0, (int)Poe_State_CdMax);
				else
					_Poe_State_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_State_Cd");
			}
		}
		public string Poe_Country_Cd
		{
			get { return _Poe_Country_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Country_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Country_CdMax )
					_Poe_Country_Cd = val.Substring(0, (int)Poe_Country_CdMax);
				else
					_Poe_Country_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Country_Cd");
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
		public string Pod_City
		{
			get { return _Pod_City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_CityMax )
					_Pod_City = val.Substring(0, (int)Pod_CityMax);
				else
					_Pod_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_City");
			}
		}
		public string Pod_State_Cd
		{
			get { return _Pod_State_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_State_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_State_CdMax )
					_Pod_State_Cd = val.Substring(0, (int)Pod_State_CdMax);
				else
					_Pod_State_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_State_Cd");
			}
		}
		public string Pod_Country_Cd
		{
			get { return _Pod_Country_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Country_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Country_CdMax )
					_Pod_Country_Cd = val.Substring(0, (int)Pod_Country_CdMax);
				else
					_Pod_Country_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Country_Cd");
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
		public string Poe_Est_Sail_Date
		{
			get { return _Poe_Est_Sail_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Est_Sail_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Est_Sail_DateMax )
					_Poe_Est_Sail_Date = val.Substring(0, (int)Poe_Est_Sail_DateMax);
				else
					_Poe_Est_Sail_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Est_Sail_Date");
			}
		}
		public string Poe_Est_Sail_Time
		{
			get { return _Poe_Est_Sail_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Est_Sail_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Est_Sail_TimeMax )
					_Poe_Est_Sail_Time = val.Substring(0, (int)Poe_Est_Sail_TimeMax);
				else
					_Poe_Est_Sail_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Est_Sail_Time");
			}
		}
		public string Pod_Est_Arrival_Date
		{
			get { return _Pod_Est_Arrival_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Est_Arrival_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Est_Arrival_DateMax )
					_Pod_Est_Arrival_Date = val.Substring(0, (int)Pod_Est_Arrival_DateMax);
				else
					_Pod_Est_Arrival_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Est_Arrival_Date");
			}
		}
		public string Pod_Est_Arrival_Time
		{
			get { return _Pod_Est_Arrival_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Est_Arrival_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Est_Arrival_TimeMax )
					_Pod_Est_Arrival_Time = val.Substring(0, (int)Pod_Est_Arrival_TimeMax);
				else
					_Pod_Est_Arrival_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Est_Arrival_Time");
			}
		}
		public string Location_Qualifier
		{
			get { return _Location_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_QualifierMax )
					_Location_Qualifier = val.Substring(0, (int)Location_QualifierMax);
				else
					_Location_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Qualifier");
			}
		}
		public string Poe_Water_Port
		{
			get { return _Poe_Water_Port; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Water_Port, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Water_PortMax )
					_Poe_Water_Port = val.Substring(0, (int)Poe_Water_PortMax);
				else
					_Poe_Water_Port = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Water_Port");
			}
		}
		public string Pod_Water_Port
		{
			get { return _Pod_Water_Port; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Water_Port, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Water_PortMax )
					_Pod_Water_Port = val.Substring(0, (int)Pod_Water_PortMax);
				else
					_Pod_Water_Port = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Water_Port");
			}
		}
		public string Pickup_Dodaac
		{
			get { return _Pickup_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pickup_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pickup_DodaacMax )
					_Pickup_Dodaac = val.Substring(0, (int)Pickup_DodaacMax);
				else
					_Pickup_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pickup_Dodaac");
			}
		}
		public string Consignee_Dodaac
		{
			get { return _Consignee_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Consignee_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Consignee_DodaacMax )
					_Consignee_Dodaac = val.Substring(0, (int)Consignee_DodaacMax);
				else
					_Consignee_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Consignee_Dodaac");
			}
		}
		public string Pickup_Dt
		{
			get { return _Pickup_Dt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pickup_Dt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pickup_DtMax )
					_Pickup_Dt = val.Substring(0, (int)Pickup_DtMax);
				else
					_Pickup_Dt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pickup_Dt");
			}
		}
		public string Pickup_Tm
		{
			get { return _Pickup_Tm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pickup_Tm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pickup_TmMax )
					_Pickup_Tm = val.Substring(0, (int)Pickup_TmMax);
				else
					_Pickup_Tm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pickup_Tm");
			}
		}
		public string Pickup_Qualifier_Cd
		{
			get { return _Pickup_Qualifier_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pickup_Qualifier_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pickup_Qualifier_CdMax )
					_Pickup_Qualifier_Cd = val.Substring(0, (int)Pickup_Qualifier_CdMax);
				else
					_Pickup_Qualifier_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pickup_Qualifier_Cd");
			}
		}
		public string Delivery_Dt
		{
			get { return _Delivery_Dt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Dt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_DtMax )
					_Delivery_Dt = val.Substring(0, (int)Delivery_DtMax);
				else
					_Delivery_Dt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dt");
			}
		}
		public string Delivery_Tm
		{
			get { return _Delivery_Tm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Tm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_TmMax )
					_Delivery_Tm = val.Substring(0, (int)Delivery_TmMax);
				else
					_Delivery_Tm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Tm");
			}
		}
		public string Delivery_Qualifier_Cd
		{
			get { return _Delivery_Qualifier_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Qualifier_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_Qualifier_CdMax )
					_Delivery_Qualifier_Cd = val.Substring(0, (int)Delivery_Qualifier_CdMax);
				else
					_Delivery_Qualifier_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Qualifier_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVAcmsItvDodQueue() : base() {}
		public ClsVAcmsItvDodQueue(DataRow dr) : base(dr) {}
		public ClsVAcmsItvDodQueue(ClsVAcmsItvDodQueue src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Activity_ID = null;
			St_Count = null;
			Cur_Ctl_No = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Booking_ID = null;
			Booking_Sub = null;
			Item_No = null;
			Activity_Code = null;
			Activity_Dt = null;
			Activity_Time = null;
			Voyage_No = null;
			Military_Voyage_Cd = null;
			Location_Cd = null;
			Ircs = null;
			Vessel_Dsc = null;
			Vessel_Qualifier = null;
			Estimated_Sail_Date = null;
			Edi_Control_Std = null;
			Edi_Control_Version = null;
			Edi_Version = null;
			Edi_Test = null;
			Edi_Partner_Xchg_Cd = null;
			Edi_Partner_Xchg_Qualifier = null;
			Edi_Partner_Gs03 = null;
			Tcn = null;
			Lading_Qty_Nbr = null;
			Wt_Nbr = null;
			Wt_Qualifier = null;
			Volume_Nbr = null;
			Volume_Qualifier = null;
			Wt_Unit_Cd = null;
			Scac_Cd = null;
			Shipper_City = null;
			Location_Poe_Cd = null;
			Location_Pod_Cd = null;
			Rcvr_City = null;
			Act_Dsc = null;
			Act_Census = null;
			Act_City = null;
			Act_State_Cd = null;
			Act_Country_Cd = null;
			Poe_Dsc = null;
			Poe_Census = null;
			Poe_Census_Type = null;
			Poe_City = null;
			Poe_State_Cd = null;
			Poe_Country_Cd = null;
			Pod_Dsc = null;
			Pod_Census = null;
			Pod_Census_Type = null;
			Pod_City = null;
			Pod_State_Cd = null;
			Pod_Country_Cd = null;
			Departure_Qualifier = null;
			Arrival_Qualifier = null;
			Poe_Est_Sail_Date = null;
			Poe_Est_Sail_Time = null;
			Pod_Est_Arrival_Date = null;
			Pod_Est_Arrival_Time = null;
			Location_Qualifier = null;
			Poe_Water_Port = null;
			Pod_Water_Port = null;
			Pickup_Dodaac = null;
			Consignee_Dodaac = null;
			Pickup_Dt = null;
			Pickup_Tm = null;
			Pickup_Qualifier_Cd = null;
			Delivery_Dt = null;
			Delivery_Tm = null;
			Delivery_Qualifier_Cd = null;
		}

		public void CopyFrom(ClsVAcmsItvDodQueue src)
		{
			Activity_ID = src._Activity_ID;
			St_Count = src._St_Count;
			Cur_Ctl_No = src._Cur_Ctl_No;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Booking_ID = src._Booking_ID;
			Booking_Sub = src._Booking_Sub;
			Item_No = src._Item_No;
			Activity_Code = src._Activity_Code;
			Activity_Dt = src._Activity_Dt;
			Activity_Time = src._Activity_Time;
			Voyage_No = src._Voyage_No;
			Military_Voyage_Cd = src._Military_Voyage_Cd;
			Location_Cd = src._Location_Cd;
			Ircs = src._Ircs;
			Vessel_Dsc = src._Vessel_Dsc;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Estimated_Sail_Date = src._Estimated_Sail_Date;
			Edi_Control_Std = src._Edi_Control_Std;
			Edi_Control_Version = src._Edi_Control_Version;
			Edi_Version = src._Edi_Version;
			Edi_Test = src._Edi_Test;
			Edi_Partner_Xchg_Cd = src._Edi_Partner_Xchg_Cd;
			Edi_Partner_Xchg_Qualifier = src._Edi_Partner_Xchg_Qualifier;
			Edi_Partner_Gs03 = src._Edi_Partner_Gs03;
			Tcn = src._Tcn;
			Lading_Qty_Nbr = src._Lading_Qty_Nbr;
			Wt_Nbr = src._Wt_Nbr;
			Wt_Qualifier = src._Wt_Qualifier;
			Volume_Nbr = src._Volume_Nbr;
			Volume_Qualifier = src._Volume_Qualifier;
			Wt_Unit_Cd = src._Wt_Unit_Cd;
			Scac_Cd = src._Scac_Cd;
			Shipper_City = src._Shipper_City;
			Location_Poe_Cd = src._Location_Poe_Cd;
			Location_Pod_Cd = src._Location_Pod_Cd;
			Rcvr_City = src._Rcvr_City;
			Act_Dsc = src._Act_Dsc;
			Act_Census = src._Act_Census;
			Act_City = src._Act_City;
			Act_State_Cd = src._Act_State_Cd;
			Act_Country_Cd = src._Act_Country_Cd;
			Poe_Dsc = src._Poe_Dsc;
			Poe_Census = src._Poe_Census;
			Poe_Census_Type = src._Poe_Census_Type;
			Poe_City = src._Poe_City;
			Poe_State_Cd = src._Poe_State_Cd;
			Poe_Country_Cd = src._Poe_Country_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Census = src._Pod_Census;
			Pod_Census_Type = src._Pod_Census_Type;
			Pod_City = src._Pod_City;
			Pod_State_Cd = src._Pod_State_Cd;
			Pod_Country_Cd = src._Pod_Country_Cd;
			Departure_Qualifier = src._Departure_Qualifier;
			Arrival_Qualifier = src._Arrival_Qualifier;
			Poe_Est_Sail_Date = src._Poe_Est_Sail_Date;
			Poe_Est_Sail_Time = src._Poe_Est_Sail_Time;
			Pod_Est_Arrival_Date = src._Pod_Est_Arrival_Date;
			Pod_Est_Arrival_Time = src._Pod_Est_Arrival_Time;
			Location_Qualifier = src._Location_Qualifier;
			Poe_Water_Port = src._Poe_Water_Port;
			Pod_Water_Port = src._Pod_Water_Port;
			Pickup_Dodaac = src._Pickup_Dodaac;
			Consignee_Dodaac = src._Consignee_Dodaac;
			Pickup_Dt = src._Pickup_Dt;
			Pickup_Tm = src._Pickup_Tm;
			Pickup_Qualifier_Cd = src._Pickup_Qualifier_Cd;
			Delivery_Dt = src._Delivery_Dt;
			Delivery_Tm = src._Delivery_Tm;
			Delivery_Qualifier_Cd = src._Delivery_Qualifier_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsVAcmsItvDodQueue tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[71];

			p[0] = Connection.GetParameter
				("@ACTIVITY_ID", Activity_ID);
			p[1] = Connection.GetParameter
				("@ST_COUNT", St_Count);
			p[2] = Connection.GetParameter
				("@CUR_CTL_NO", Cur_Ctl_No);
			p[3] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[4] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[5] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[6] = Connection.GetParameter
				("@BOOKING_SUB", Booking_Sub);
			p[7] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[8] = Connection.GetParameter
				("@ACTIVITY_CODE", Activity_Code);
			p[9] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[10] = Connection.GetParameter
				("@ACTIVITY_TIME", Activity_Time);
			p[11] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[12] = Connection.GetParameter
				("@MILITARY_VOYAGE_CD", Military_Voyage_Cd);
			p[13] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[14] = Connection.GetParameter
				("@IRCS", Ircs);
			p[15] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[16] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[17] = Connection.GetParameter
				("@ESTIMATED_SAIL_DATE", Estimated_Sail_Date);
			p[18] = Connection.GetParameter
				("@EDI_CONTROL_STD", Edi_Control_Std);
			p[19] = Connection.GetParameter
				("@EDI_CONTROL_VERSION", Edi_Control_Version);
			p[20] = Connection.GetParameter
				("@EDI_VERSION", Edi_Version);
			p[21] = Connection.GetParameter
				("@EDI_TEST", Edi_Test);
			p[22] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_CD", Edi_Partner_Xchg_Cd);
			p[23] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_QUALIFIER", Edi_Partner_Xchg_Qualifier);
			p[24] = Connection.GetParameter
				("@EDI_PARTNER_GS03", Edi_Partner_Gs03);
			p[25] = Connection.GetParameter
				("@TCN", Tcn);
			p[26] = Connection.GetParameter
				("@LADING_QTY_NBR", Lading_Qty_Nbr);
			p[27] = Connection.GetParameter
				("@WT_NBR", Wt_Nbr);
			p[28] = Connection.GetParameter
				("@WT_QUALIFIER", Wt_Qualifier);
			p[29] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[30] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[31] = Connection.GetParameter
				("@WT_UNIT_CD", Wt_Unit_Cd);
			p[32] = Connection.GetParameter
				("@SCAC_CD", Scac_Cd);
			p[33] = Connection.GetParameter
				("@SHIPPER_CITY", Shipper_City);
			p[34] = Connection.GetParameter
				("@LOCATION_POE_CD", Location_Poe_Cd);
			p[35] = Connection.GetParameter
				("@LOCATION_POD_CD", Location_Pod_Cd);
			p[36] = Connection.GetParameter
				("@RCVR_CITY", Rcvr_City);
			p[37] = Connection.GetParameter
				("@ACT_DSC", Act_Dsc);
			p[38] = Connection.GetParameter
				("@ACT_CENSUS", Act_Census);
			p[39] = Connection.GetParameter
				("@ACT_CITY", Act_City);
			p[40] = Connection.GetParameter
				("@ACT_STATE_CD", Act_State_Cd);
			p[41] = Connection.GetParameter
				("@ACT_COUNTRY_CD", Act_Country_Cd);
			p[42] = Connection.GetParameter
				("@POE_DSC", Poe_Dsc);
			p[43] = Connection.GetParameter
				("@POE_CENSUS", Poe_Census);
			p[44] = Connection.GetParameter
				("@POE_CENSUS_TYPE", Poe_Census_Type);
			p[45] = Connection.GetParameter
				("@POE_CITY", Poe_City);
			p[46] = Connection.GetParameter
				("@POE_STATE_CD", Poe_State_Cd);
			p[47] = Connection.GetParameter
				("@POE_COUNTRY_CD", Poe_Country_Cd);
			p[48] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[49] = Connection.GetParameter
				("@POD_CENSUS", Pod_Census);
			p[50] = Connection.GetParameter
				("@POD_CENSUS_TYPE", Pod_Census_Type);
			p[51] = Connection.GetParameter
				("@POD_CITY", Pod_City);
			p[52] = Connection.GetParameter
				("@POD_STATE_CD", Pod_State_Cd);
			p[53] = Connection.GetParameter
				("@POD_COUNTRY_CD", Pod_Country_Cd);
			p[54] = Connection.GetParameter
				("@DEPARTURE_QUALIFIER", Departure_Qualifier);
			p[55] = Connection.GetParameter
				("@ARRIVAL_QUALIFIER", Arrival_Qualifier);
			p[56] = Connection.GetParameter
				("@POE_EST_SAIL_DATE", Poe_Est_Sail_Date);
			p[57] = Connection.GetParameter
				("@POE_EST_SAIL_TIME", Poe_Est_Sail_Time);
			p[58] = Connection.GetParameter
				("@POD_EST_ARRIVAL_DATE", Pod_Est_Arrival_Date);
			p[59] = Connection.GetParameter
				("@POD_EST_ARRIVAL_TIME", Pod_Est_Arrival_Time);
			p[60] = Connection.GetParameter
				("@LOCATION_QUALIFIER", Location_Qualifier);
			p[61] = Connection.GetParameter
				("@POE_WATER_PORT", Poe_Water_Port);
			p[62] = Connection.GetParameter
				("@POD_WATER_PORT", Pod_Water_Port);
			p[63] = Connection.GetParameter
				("@PICKUP_DODAAC", Pickup_Dodaac);
			p[64] = Connection.GetParameter
				("@CONSIGNEE_DODAAC", Consignee_Dodaac);
			p[65] = Connection.GetParameter
				("@PICKUP_DT", Pickup_Dt);
			p[66] = Connection.GetParameter
				("@PICKUP_TM", Pickup_Tm);
			p[67] = Connection.GetParameter
				("@PICKUP_QUALIFIER_CD", Pickup_Qualifier_Cd);
			p[68] = Connection.GetParameter
				("@DELIVERY_DT", Delivery_Dt);
			p[69] = Connection.GetParameter
				("@DELIVERY_TM", Delivery_Tm);
			p[70] = Connection.GetParameter
				("@DELIVERY_QUALIFIER_CD", Delivery_Qualifier_Cd);

			const string sql = @"
				INSERT INTO V_ACMS_ITV_DOD_QUEUE
					(ACTIVITY_ID, ST_COUNT, CUR_CTL_NO,
					PARTNER_CD, PARTNER_REQUEST_CD, BOOKING_ID,
					BOOKING_SUB, ITEM_NO, ACTIVITY_CODE,
					ACTIVITY_DT, ACTIVITY_TIME, VOYAGE_NO,
					MILITARY_VOYAGE_CD, LOCATION_CD, IRCS,
					VESSEL_DSC, VESSEL_QUALIFIER, ESTIMATED_SAIL_DATE,
					EDI_CONTROL_STD, EDI_CONTROL_VERSION, EDI_VERSION,
					EDI_TEST, EDI_PARTNER_XCHG_CD, EDI_PARTNER_XCHG_QUALIFIER,
					EDI_PARTNER_GS03, TCN, LADING_QTY_NBR,
					WT_NBR, WT_QUALIFIER, VOLUME_NBR,
					VOLUME_QUALIFIER, WT_UNIT_CD, SCAC_CD,
					SHIPPER_CITY, LOCATION_POE_CD, LOCATION_POD_CD,
					RCVR_CITY, ACT_DSC, ACT_CENSUS,
					ACT_CITY, ACT_STATE_CD, ACT_COUNTRY_CD,
					POE_DSC, POE_CENSUS, POE_CENSUS_TYPE,
					POE_CITY, POE_STATE_CD, POE_COUNTRY_CD,
					POD_DSC, POD_CENSUS, POD_CENSUS_TYPE,
					POD_CITY, POD_STATE_CD, POD_COUNTRY_CD,
					DEPARTURE_QUALIFIER, ARRIVAL_QUALIFIER, POE_EST_SAIL_DATE,
					POE_EST_SAIL_TIME, POD_EST_ARRIVAL_DATE, POD_EST_ARRIVAL_TIME,
					LOCATION_QUALIFIER, POE_WATER_PORT, POD_WATER_PORT,
					PICKUP_DODAAC, CONSIGNEE_DODAAC, PICKUP_DT,
					PICKUP_TM, PICKUP_QUALIFIER_CD, DELIVERY_DT,
					DELIVERY_TM, DELIVERY_QUALIFIER_CD)
				VALUES
					(@ACTIVITY_ID, @ST_COUNT, @CUR_CTL_NO,
					@PARTNER_CD, @PARTNER_REQUEST_CD, @BOOKING_ID,
					@BOOKING_SUB, @ITEM_NO, @ACTIVITY_CODE,
					@ACTIVITY_DT, @ACTIVITY_TIME, @VOYAGE_NO,
					@MILITARY_VOYAGE_CD, @LOCATION_CD, @IRCS,
					@VESSEL_DSC, @VESSEL_QUALIFIER, @ESTIMATED_SAIL_DATE,
					@EDI_CONTROL_STD, @EDI_CONTROL_VERSION, @EDI_VERSION,
					@EDI_TEST, @EDI_PARTNER_XCHG_CD, @EDI_PARTNER_XCHG_QUALIFIER,
					@EDI_PARTNER_GS03, @TCN, @LADING_QTY_NBR,
					@WT_NBR, @WT_QUALIFIER, @VOLUME_NBR,
					@VOLUME_QUALIFIER, @WT_UNIT_CD, @SCAC_CD,
					@SHIPPER_CITY, @LOCATION_POE_CD, @LOCATION_POD_CD,
					@RCVR_CITY, @ACT_DSC, @ACT_CENSUS,
					@ACT_CITY, @ACT_STATE_CD, @ACT_COUNTRY_CD,
					@POE_DSC, @POE_CENSUS, @POE_CENSUS_TYPE,
					@POE_CITY, @POE_STATE_CD, @POE_COUNTRY_CD,
					@POD_DSC, @POD_CENSUS, @POD_CENSUS_TYPE,
					@POD_CITY, @POD_STATE_CD, @POD_COUNTRY_CD,
					@DEPARTURE_QUALIFIER, @ARRIVAL_QUALIFIER, @POE_EST_SAIL_DATE,
					@POE_EST_SAIL_TIME, @POD_EST_ARRIVAL_DATE, @POD_EST_ARRIVAL_TIME,
					@LOCATION_QUALIFIER, @POE_WATER_PORT, @POD_WATER_PORT,
					@PICKUP_DODAAC, @CONSIGNEE_DODAAC, @PICKUP_DT,
					@PICKUP_TM, @PICKUP_QUALIFIER_CD, @DELIVERY_DT,
					@DELIVERY_TM, @DELIVERY_QUALIFIER_CD)
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

			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID"]);
			St_Count = ClsConvert.ToDecimalNullable(dr["ST_COUNT"]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE"]);
			Activity_Dt = ClsConvert.ToString(dr["ACTIVITY_DT"]);
			Activity_Time = ClsConvert.ToString(dr["ACTIVITY_TIME"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Ircs = ClsConvert.ToString(dr["IRCS"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Estimated_Sail_Date = ClsConvert.ToDateTimeNullable(dr["ESTIMATED_SAIL_DATE"]);
			Edi_Control_Std = ClsConvert.ToString(dr["EDI_CONTROL_STD"]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION"]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION"]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST"]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD"]);
			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER"]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Lading_Qty_Nbr = ClsConvert.ToDecimalNullable(dr["LADING_QTY_NBR"]);
			Wt_Nbr = ClsConvert.ToDoubleNullable(dr["WT_NBR"]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER"]);
			Volume_Nbr = ClsConvert.ToDoubleNullable(dr["VOLUME_NBR"]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER"]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD"]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD"]);
			Shipper_City = ClsConvert.ToString(dr["SHIPPER_CITY"]);
			Location_Poe_Cd = ClsConvert.ToString(dr["LOCATION_POE_CD"]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD"]);
			Rcvr_City = ClsConvert.ToString(dr["RCVR_CITY"]);
			Act_Dsc = ClsConvert.ToString(dr["ACT_DSC"]);
			Act_Census = ClsConvert.ToString(dr["ACT_CENSUS"]);
			Act_City = ClsConvert.ToString(dr["ACT_CITY"]);
			Act_State_Cd = ClsConvert.ToString(dr["ACT_STATE_CD"]);
			Act_Country_Cd = ClsConvert.ToString(dr["ACT_COUNTRY_CD"]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC"]);
			Poe_Census = ClsConvert.ToString(dr["POE_CENSUS"]);
			Poe_Census_Type = ClsConvert.ToString(dr["POE_CENSUS_TYPE"]);
			Poe_City = ClsConvert.ToString(dr["POE_CITY"]);
			Poe_State_Cd = ClsConvert.ToString(dr["POE_STATE_CD"]);
			Poe_Country_Cd = ClsConvert.ToString(dr["POE_COUNTRY_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Pod_Census = ClsConvert.ToString(dr["POD_CENSUS"]);
			Pod_Census_Type = ClsConvert.ToString(dr["POD_CENSUS_TYPE"]);
			Pod_City = ClsConvert.ToString(dr["POD_CITY"]);
			Pod_State_Cd = ClsConvert.ToString(dr["POD_STATE_CD"]);
			Pod_Country_Cd = ClsConvert.ToString(dr["POD_COUNTRY_CD"]);
			Departure_Qualifier = ClsConvert.ToString(dr["DEPARTURE_QUALIFIER"]);
			Arrival_Qualifier = ClsConvert.ToString(dr["ARRIVAL_QUALIFIER"]);
			Poe_Est_Sail_Date = ClsConvert.ToString(dr["POE_EST_SAIL_DATE"]);
			Poe_Est_Sail_Time = ClsConvert.ToString(dr["POE_EST_SAIL_TIME"]);
			Pod_Est_Arrival_Date = ClsConvert.ToString(dr["POD_EST_ARRIVAL_DATE"]);
			Pod_Est_Arrival_Time = ClsConvert.ToString(dr["POD_EST_ARRIVAL_TIME"]);
			Location_Qualifier = ClsConvert.ToString(dr["LOCATION_QUALIFIER"]);
			Poe_Water_Port = ClsConvert.ToString(dr["POE_WATER_PORT"]);
			Pod_Water_Port = ClsConvert.ToString(dr["POD_WATER_PORT"]);
			Pickup_Dodaac = ClsConvert.ToString(dr["PICKUP_DODAAC"]);
			Consignee_Dodaac = ClsConvert.ToString(dr["CONSIGNEE_DODAAC"]);
			Pickup_Dt = ClsConvert.ToString(dr["PICKUP_DT"]);
			Pickup_Tm = ClsConvert.ToString(dr["PICKUP_TM"]);
			Pickup_Qualifier_Cd = ClsConvert.ToString(dr["PICKUP_QUALIFIER_CD"]);
			Delivery_Dt = ClsConvert.ToString(dr["DELIVERY_DT"]);
			Delivery_Tm = ClsConvert.ToString(dr["DELIVERY_TM"]);
			Delivery_Qualifier_Cd = ClsConvert.ToString(dr["DELIVERY_QUALIFIER_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID", v]);
			St_Count = ClsConvert.ToDecimalNullable(dr["ST_COUNT", v]);
			Cur_Ctl_No = ClsConvert.ToDecimalNullable(dr["CUR_CTL_NO", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE", v]);
			Activity_Dt = ClsConvert.ToString(dr["ACTIVITY_DT", v]);
			Activity_Time = ClsConvert.ToString(dr["ACTIVITY_TIME", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Ircs = ClsConvert.ToString(dr["IRCS", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Estimated_Sail_Date = ClsConvert.ToDateTimeNullable(dr["ESTIMATED_SAIL_DATE", v]);
			Edi_Control_Std = ClsConvert.ToString(dr["EDI_CONTROL_STD", v]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION", v]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION", v]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST", v]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD", v]);
			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER", v]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Lading_Qty_Nbr = ClsConvert.ToDecimalNullable(dr["LADING_QTY_NBR", v]);
			Wt_Nbr = ClsConvert.ToDoubleNullable(dr["WT_NBR", v]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER", v]);
			Volume_Nbr = ClsConvert.ToDoubleNullable(dr["VOLUME_NBR", v]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER", v]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD", v]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD", v]);
			Shipper_City = ClsConvert.ToString(dr["SHIPPER_CITY", v]);
			Location_Poe_Cd = ClsConvert.ToString(dr["LOCATION_POE_CD", v]);
			Location_Pod_Cd = ClsConvert.ToString(dr["LOCATION_POD_CD", v]);
			Rcvr_City = ClsConvert.ToString(dr["RCVR_CITY", v]);
			Act_Dsc = ClsConvert.ToString(dr["ACT_DSC", v]);
			Act_Census = ClsConvert.ToString(dr["ACT_CENSUS", v]);
			Act_City = ClsConvert.ToString(dr["ACT_CITY", v]);
			Act_State_Cd = ClsConvert.ToString(dr["ACT_STATE_CD", v]);
			Act_Country_Cd = ClsConvert.ToString(dr["ACT_COUNTRY_CD", v]);
			Poe_Dsc = ClsConvert.ToString(dr["POE_DSC", v]);
			Poe_Census = ClsConvert.ToString(dr["POE_CENSUS", v]);
			Poe_Census_Type = ClsConvert.ToString(dr["POE_CENSUS_TYPE", v]);
			Poe_City = ClsConvert.ToString(dr["POE_CITY", v]);
			Poe_State_Cd = ClsConvert.ToString(dr["POE_STATE_CD", v]);
			Poe_Country_Cd = ClsConvert.ToString(dr["POE_COUNTRY_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Pod_Census = ClsConvert.ToString(dr["POD_CENSUS", v]);
			Pod_Census_Type = ClsConvert.ToString(dr["POD_CENSUS_TYPE", v]);
			Pod_City = ClsConvert.ToString(dr["POD_CITY", v]);
			Pod_State_Cd = ClsConvert.ToString(dr["POD_STATE_CD", v]);
			Pod_Country_Cd = ClsConvert.ToString(dr["POD_COUNTRY_CD", v]);
			Departure_Qualifier = ClsConvert.ToString(dr["DEPARTURE_QUALIFIER", v]);
			Arrival_Qualifier = ClsConvert.ToString(dr["ARRIVAL_QUALIFIER", v]);
			Poe_Est_Sail_Date = ClsConvert.ToString(dr["POE_EST_SAIL_DATE", v]);
			Poe_Est_Sail_Time = ClsConvert.ToString(dr["POE_EST_SAIL_TIME", v]);
			Pod_Est_Arrival_Date = ClsConvert.ToString(dr["POD_EST_ARRIVAL_DATE", v]);
			Pod_Est_Arrival_Time = ClsConvert.ToString(dr["POD_EST_ARRIVAL_TIME", v]);
			Location_Qualifier = ClsConvert.ToString(dr["LOCATION_QUALIFIER", v]);
			Poe_Water_Port = ClsConvert.ToString(dr["POE_WATER_PORT", v]);
			Pod_Water_Port = ClsConvert.ToString(dr["POD_WATER_PORT", v]);
			Pickup_Dodaac = ClsConvert.ToString(dr["PICKUP_DODAAC", v]);
			Consignee_Dodaac = ClsConvert.ToString(dr["CONSIGNEE_DODAAC", v]);
			Pickup_Dt = ClsConvert.ToString(dr["PICKUP_DT", v]);
			Pickup_Tm = ClsConvert.ToString(dr["PICKUP_TM", v]);
			Pickup_Qualifier_Cd = ClsConvert.ToString(dr["PICKUP_QUALIFIER_CD", v]);
			Delivery_Dt = ClsConvert.ToString(dr["DELIVERY_DT", v]);
			Delivery_Tm = ClsConvert.ToString(dr["DELIVERY_TM", v]);
			Delivery_Qualifier_Cd = ClsConvert.ToString(dr["DELIVERY_QUALIFIER_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ACTIVITY_ID"] = ClsConvert.ToDbObject(Activity_ID);
			dr["ST_COUNT"] = ClsConvert.ToDbObject(St_Count);
			dr["CUR_CTL_NO"] = ClsConvert.ToDbObject(Cur_Ctl_No);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["BOOKING_SUB"] = ClsConvert.ToDbObject(Booking_Sub);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["ACTIVITY_CODE"] = ClsConvert.ToDbObject(Activity_Code);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_TIME"] = ClsConvert.ToDbObject(Activity_Time);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["MILITARY_VOYAGE_CD"] = ClsConvert.ToDbObject(Military_Voyage_Cd);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["IRCS"] = ClsConvert.ToDbObject(Ircs);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["ESTIMATED_SAIL_DATE"] = ClsConvert.ToDbObject(Estimated_Sail_Date);
			dr["EDI_CONTROL_STD"] = ClsConvert.ToDbObject(Edi_Control_Std);
			dr["EDI_CONTROL_VERSION"] = ClsConvert.ToDbObject(Edi_Control_Version);
			dr["EDI_VERSION"] = ClsConvert.ToDbObject(Edi_Version);
			dr["EDI_TEST"] = ClsConvert.ToDbObject(Edi_Test);
			dr["EDI_PARTNER_XCHG_CD"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Cd);
			dr["EDI_PARTNER_XCHG_QUALIFIER"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Qualifier);
			dr["EDI_PARTNER_GS03"] = ClsConvert.ToDbObject(Edi_Partner_Gs03);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["LADING_QTY_NBR"] = ClsConvert.ToDbObject(Lading_Qty_Nbr);
			dr["WT_NBR"] = ClsConvert.ToDbObject(Wt_Nbr);
			dr["WT_QUALIFIER"] = ClsConvert.ToDbObject(Wt_Qualifier);
			dr["VOLUME_NBR"] = ClsConvert.ToDbObject(Volume_Nbr);
			dr["VOLUME_QUALIFIER"] = ClsConvert.ToDbObject(Volume_Qualifier);
			dr["WT_UNIT_CD"] = ClsConvert.ToDbObject(Wt_Unit_Cd);
			dr["SCAC_CD"] = ClsConvert.ToDbObject(Scac_Cd);
			dr["SHIPPER_CITY"] = ClsConvert.ToDbObject(Shipper_City);
			dr["LOCATION_POE_CD"] = ClsConvert.ToDbObject(Location_Poe_Cd);
			dr["LOCATION_POD_CD"] = ClsConvert.ToDbObject(Location_Pod_Cd);
			dr["RCVR_CITY"] = ClsConvert.ToDbObject(Rcvr_City);
			dr["ACT_DSC"] = ClsConvert.ToDbObject(Act_Dsc);
			dr["ACT_CENSUS"] = ClsConvert.ToDbObject(Act_Census);
			dr["ACT_CITY"] = ClsConvert.ToDbObject(Act_City);
			dr["ACT_STATE_CD"] = ClsConvert.ToDbObject(Act_State_Cd);
			dr["ACT_COUNTRY_CD"] = ClsConvert.ToDbObject(Act_Country_Cd);
			dr["POE_DSC"] = ClsConvert.ToDbObject(Poe_Dsc);
			dr["POE_CENSUS"] = ClsConvert.ToDbObject(Poe_Census);
			dr["POE_CENSUS_TYPE"] = ClsConvert.ToDbObject(Poe_Census_Type);
			dr["POE_CITY"] = ClsConvert.ToDbObject(Poe_City);
			dr["POE_STATE_CD"] = ClsConvert.ToDbObject(Poe_State_Cd);
			dr["POE_COUNTRY_CD"] = ClsConvert.ToDbObject(Poe_Country_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["POD_CENSUS"] = ClsConvert.ToDbObject(Pod_Census);
			dr["POD_CENSUS_TYPE"] = ClsConvert.ToDbObject(Pod_Census_Type);
			dr["POD_CITY"] = ClsConvert.ToDbObject(Pod_City);
			dr["POD_STATE_CD"] = ClsConvert.ToDbObject(Pod_State_Cd);
			dr["POD_COUNTRY_CD"] = ClsConvert.ToDbObject(Pod_Country_Cd);
			dr["DEPARTURE_QUALIFIER"] = ClsConvert.ToDbObject(Departure_Qualifier);
			dr["ARRIVAL_QUALIFIER"] = ClsConvert.ToDbObject(Arrival_Qualifier);
			dr["POE_EST_SAIL_DATE"] = ClsConvert.ToDbObject(Poe_Est_Sail_Date);
			dr["POE_EST_SAIL_TIME"] = ClsConvert.ToDbObject(Poe_Est_Sail_Time);
			dr["POD_EST_ARRIVAL_DATE"] = ClsConvert.ToDbObject(Pod_Est_Arrival_Date);
			dr["POD_EST_ARRIVAL_TIME"] = ClsConvert.ToDbObject(Pod_Est_Arrival_Time);
			dr["LOCATION_QUALIFIER"] = ClsConvert.ToDbObject(Location_Qualifier);
			dr["POE_WATER_PORT"] = ClsConvert.ToDbObject(Poe_Water_Port);
			dr["POD_WATER_PORT"] = ClsConvert.ToDbObject(Pod_Water_Port);
			dr["PICKUP_DODAAC"] = ClsConvert.ToDbObject(Pickup_Dodaac);
			dr["CONSIGNEE_DODAAC"] = ClsConvert.ToDbObject(Consignee_Dodaac);
			dr["PICKUP_DT"] = ClsConvert.ToDbObject(Pickup_Dt);
			dr["PICKUP_TM"] = ClsConvert.ToDbObject(Pickup_Tm);
			dr["PICKUP_QUALIFIER_CD"] = ClsConvert.ToDbObject(Pickup_Qualifier_Cd);
			dr["DELIVERY_DT"] = ClsConvert.ToDbObject(Delivery_Dt);
			dr["DELIVERY_TM"] = ClsConvert.ToDbObject(Delivery_Tm);
			dr["DELIVERY_QUALIFIER_CD"] = ClsConvert.ToDbObject(Delivery_Qualifier_Cd);
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