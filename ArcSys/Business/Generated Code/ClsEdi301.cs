using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi301 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI301";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI301_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI301 
				INNER JOIN T_ISA
				ON T_EDI301.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Trading_Partner_CdMax = 10;
		public const int Request_CdMax = 10;
		public const int Acms_Status_CdMax = 2;
		public const int Confirm_CdMax = 2;
		public const int Booking_NoMax = 30;
		public const int Pol_FunctionMax = 1;
		public const int Pol_CdMax = 30;
		public const int Pol_DscMax = 50;
		public const int Pol_QualifierMax = 2;
		public const int Pod_FunctionMax = 1;
		public const int Pod_CdMax = 30;
		public const int Pod_DscMax = 50;
		public const int Pod_QualifierMax = 2;
		public const int Scac_CdMax = 4;
		public const int Eqp_InitialMax = 1;
		public const int Edi_IDMax = 15;
		public const int Voyage_NoMax = 10;
		public const int IrcsMax = 15;
		public const int Vessel_DscMax = 50;
		public const int Vessel_FlagMax = 10;
		public const int Military_Voyage_NoMax = 5;
		public const int Vessel_QualifierMax = 1;
		public const int Contract_NoMax = 30;
		public const int Iso_Eqp_Type_CdMax = 2;
		public const int K1aMax = 100;
		public const int K1bMax = 100;
		public const int K2aMax = 100;
		public const int K2bMax = 100;
		public const int K3aMax = 100;
		public const int K3bMax = 100;
		public const int K4aMax = 100;
		public const int K4bMax = 100;
		public const int K5aMax = 100;
		public const int K5bMax = 100;
		public const int K6aMax = 100;
		public const int K6bMax = 100;
		public const int K7aMax = 100;
		public const int K7bMax = 100;
		public const int K8aMax = 100;
		public const int K8bMax = 100;
		public const int K9aMax = 100;
		public const int K9bMax = 100;
		public const int K10aMax = 100;
		public const int K10bMax = 100;
		public const int Pol_Berth_CdMax = 10;
		public const int Pod_Berth_CdMax = 10;
		public const int Plor_CdMax = 10;
		public const int Plor_DscMax = 20;
		public const int Plod_CdMax = 10;
		public const int Plod_DscMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Processed_FlgMax = 1;
		public const int Action_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi301_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_Nbr;
		protected string _Trading_Partner_Cd;
		protected string _Request_Cd;
		protected string _Acms_Status_Cd;
		protected string _Confirm_Cd;
		protected string _Booking_No;
		protected string _Pol_Function;
		protected string _Pol_Cd;
		protected string _Pol_Dsc;
		protected string _Pol_Qualifier;
		protected string _Pod_Function;
		protected string _Pod_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Qualifier;
		protected string _Scac_Cd;
		protected string _Eqp_Initial;
		protected decimal? _Eqp_Number;
		protected string _Edi_ID;
		protected string _Voyage_No;
		protected string _Ircs;
		protected string _Vessel_Dsc;
		protected string _Vessel_Flag;
		protected string _Military_Voyage_No;
		protected string _Vessel_Qualifier;
		protected string _Contract_No;
		protected decimal? _Ship_Units_Nbr;
		protected string _Iso_Eqp_Type_Cd;
		protected DateTime? _Departure_Dt;
		protected DateTime? _Arrival_Dt;
		protected decimal? _Arrival_Count;
		protected DateTime? _Adj_Rdd_Dt;
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
		protected string _Pol_Berth_Cd;
		protected string _Pod_Berth_Cd;
		protected string _Plor_Cd;
		protected string _Plor_Dsc;
		protected string _Plod_Cd;
		protected string _Plod_Dsc;
		protected string _Vessel_Cd;
		protected string _Processed_Flg;
		protected string _Action_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi301_ID
		{
			get { return _Edi301_ID; }
			set
			{
				if( _Edi301_ID == value ) return;
		
				_Edi301_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi301_ID");
			}
		}
		public Int64? Isa_ID
		{
			get { return _Isa_ID; }
			set
			{
				if( _Isa_ID == value ) return;
		
				_Isa_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_ID");
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
		public Int64? Isa_Nbr
		{
			get { return _Isa_Nbr; }
			set
			{
				if( _Isa_Nbr == value ) return;
		
				_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Nbr");
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
		public string Request_Cd
		{
			get { return _Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Request_CdMax )
					_Request_Cd = val.Substring(0, (int)Request_CdMax);
				else
					_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Request_Cd");
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
		public string Pol_Function
		{
			get { return _Pol_Function; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Function, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_FunctionMax )
					_Pol_Function = val.Substring(0, (int)Pol_FunctionMax);
				else
					_Pol_Function = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Function");
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
		public string Pol_Qualifier
		{
			get { return _Pol_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_QualifierMax )
					_Pol_Qualifier = val.Substring(0, (int)Pol_QualifierMax);
				else
					_Pol_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Qualifier");
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
		public string Military_Voyage_No
		{
			get { return _Military_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Military_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Military_Voyage_NoMax )
					_Military_Voyage_No = val.Substring(0, (int)Military_Voyage_NoMax);
				else
					_Military_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Military_Voyage_No");
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
		public decimal? Ship_Units_Nbr
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
		public DateTime? Departure_Dt
		{
			get { return _Departure_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Departure_Dt == val ) return;
		
				_Departure_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Dt");
			}
		}
		public DateTime? Arrival_Dt
		{
			get { return _Arrival_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Arrival_Dt == val ) return;
		
				_Arrival_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Dt");
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
		public string Processed_Flg
		{
			get { return _Processed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_FlgMax )
					_Processed_Flg = val.Substring(0, (int)Processed_FlgMax);
				else
					_Processed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Flg");
			}
		}
		public string Action_Cd
		{
			get { return _Action_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Action_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Action_CdMax )
					_Action_Cd = val.Substring(0, (int)Action_CdMax);
				else
					_Action_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Action_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi301() : base() {}
		public ClsEdi301(DataRow dr) : base(dr) {}
		public ClsEdi301(ClsEdi301 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi301_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Trading_Partner_Cd = null;
			Request_Cd = null;
			Acms_Status_Cd = null;
			Confirm_Cd = null;
			Booking_No = null;
			Pol_Function = null;
			Pol_Cd = null;
			Pol_Dsc = null;
			Pol_Qualifier = null;
			Pod_Function = null;
			Pod_Cd = null;
			Pod_Dsc = null;
			Pod_Qualifier = null;
			Scac_Cd = null;
			Eqp_Initial = null;
			Eqp_Number = null;
			Edi_ID = null;
			Voyage_No = null;
			Ircs = null;
			Vessel_Dsc = null;
			Vessel_Flag = null;
			Military_Voyage_No = null;
			Vessel_Qualifier = null;
			Contract_No = null;
			Ship_Units_Nbr = null;
			Iso_Eqp_Type_Cd = null;
			Departure_Dt = null;
			Arrival_Dt = null;
			Arrival_Count = null;
			Adj_Rdd_Dt = null;
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
			Pol_Berth_Cd = null;
			Pod_Berth_Cd = null;
			Plor_Cd = null;
			Plor_Dsc = null;
			Plod_Cd = null;
			Plod_Dsc = null;
			Vessel_Cd = null;
			Processed_Flg = null;
			Action_Cd = null;
		}

		public void CopyFrom(ClsEdi301 src)
		{
			Edi301_ID = src._Edi301_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Request_Cd = src._Request_Cd;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Confirm_Cd = src._Confirm_Cd;
			Booking_No = src._Booking_No;
			Pol_Function = src._Pol_Function;
			Pol_Cd = src._Pol_Cd;
			Pol_Dsc = src._Pol_Dsc;
			Pol_Qualifier = src._Pol_Qualifier;
			Pod_Function = src._Pod_Function;
			Pod_Cd = src._Pod_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Qualifier = src._Pod_Qualifier;
			Scac_Cd = src._Scac_Cd;
			Eqp_Initial = src._Eqp_Initial;
			Eqp_Number = src._Eqp_Number;
			Edi_ID = src._Edi_ID;
			Voyage_No = src._Voyage_No;
			Ircs = src._Ircs;
			Vessel_Dsc = src._Vessel_Dsc;
			Vessel_Flag = src._Vessel_Flag;
			Military_Voyage_No = src._Military_Voyage_No;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Contract_No = src._Contract_No;
			Ship_Units_Nbr = src._Ship_Units_Nbr;
			Iso_Eqp_Type_Cd = src._Iso_Eqp_Type_Cd;
			Departure_Dt = src._Departure_Dt;
			Arrival_Dt = src._Arrival_Dt;
			Arrival_Count = src._Arrival_Count;
			Adj_Rdd_Dt = src._Adj_Rdd_Dt;
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
			Pol_Berth_Cd = src._Pol_Berth_Cd;
			Pod_Berth_Cd = src._Pod_Berth_Cd;
			Plor_Cd = src._Plor_Cd;
			Plor_Dsc = src._Plor_Dsc;
			Plod_Cd = src._Plod_Cd;
			Plod_Dsc = src._Plod_Dsc;
			Vessel_Cd = src._Vessel_Cd;
			Processed_Flg = src._Processed_Flg;
			Action_Cd = src._Action_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi301 tmp = ClsEdi301.GetUsingKey(Edi301_ID.Value);
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

			DbParameter[] p = new DbParameter[66];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[4] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[5] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[6] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[7] = Connection.GetParameter
				("@POL_FUNCTION", Pol_Function);
			p[8] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[9] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[10] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[11] = Connection.GetParameter
				("@POD_FUNCTION", Pod_Function);
			p[12] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[13] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[14] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[15] = Connection.GetParameter
				("@SCAC_CD", Scac_Cd);
			p[16] = Connection.GetParameter
				("@EQP_INITIAL", Eqp_Initial);
			p[17] = Connection.GetParameter
				("@EQP_NUMBER", Eqp_Number);
			p[18] = Connection.GetParameter
				("@EDI_ID", Edi_ID);
			p[19] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[20] = Connection.GetParameter
				("@IRCS", Ircs);
			p[21] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[22] = Connection.GetParameter
				("@VESSEL_FLAG", Vessel_Flag);
			p[23] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[24] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[25] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[26] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[27] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[28] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[29] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[30] = Connection.GetParameter
				("@ARRIVAL_COUNT", Arrival_Count);
			p[31] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[32] = Connection.GetParameter
				("@K1A", K1a);
			p[33] = Connection.GetParameter
				("@K1B", K1b);
			p[34] = Connection.GetParameter
				("@K2A", K2a);
			p[35] = Connection.GetParameter
				("@K2B", K2b);
			p[36] = Connection.GetParameter
				("@K3A", K3a);
			p[37] = Connection.GetParameter
				("@K3B", K3b);
			p[38] = Connection.GetParameter
				("@K4A", K4a);
			p[39] = Connection.GetParameter
				("@K4B", K4b);
			p[40] = Connection.GetParameter
				("@K5A", K5a);
			p[41] = Connection.GetParameter
				("@K5B", K5b);
			p[42] = Connection.GetParameter
				("@K6A", K6a);
			p[43] = Connection.GetParameter
				("@K6B", K6b);
			p[44] = Connection.GetParameter
				("@K7A", K7a);
			p[45] = Connection.GetParameter
				("@K7B", K7b);
			p[46] = Connection.GetParameter
				("@K8A", K8a);
			p[47] = Connection.GetParameter
				("@K8B", K8b);
			p[48] = Connection.GetParameter
				("@K9A", K9a);
			p[49] = Connection.GetParameter
				("@K9B", K9b);
			p[50] = Connection.GetParameter
				("@K10A", K10a);
			p[51] = Connection.GetParameter
				("@K10B", K10b);
			p[52] = Connection.GetParameter
				("@POL_BERTH_CD", Pol_Berth_Cd);
			p[53] = Connection.GetParameter
				("@POD_BERTH_CD", Pod_Berth_Cd);
			p[54] = Connection.GetParameter
				("@PLOR_CD", Plor_Cd);
			p[55] = Connection.GetParameter
				("@PLOR_DSC", Plor_Dsc);
			p[56] = Connection.GetParameter
				("@PLOD_CD", Plod_Cd);
			p[57] = Connection.GetParameter
				("@PLOD_DSC", Plod_Dsc);
			p[58] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[59] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[60] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[61] = Connection.GetParameter
				("@EDI301_ID", Edi301_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[62] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[63] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[64] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[65] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI301
					(EDI301_ID, ISA_ID, ISA_NBR,
					TRADING_PARTNER_CD, REQUEST_CD, ACMS_STATUS_CD,
					CONFIRM_CD, BOOKING_NO, POL_FUNCTION,
					POL_CD, POL_DSC, POL_QUALIFIER,
					POD_FUNCTION, POD_CD, POD_DSC,
					POD_QUALIFIER, SCAC_CD, EQP_INITIAL,
					EQP_NUMBER, EDI_ID, VOYAGE_NO,
					IRCS, VESSEL_DSC, VESSEL_FLAG,
					MILITARY_VOYAGE_NO, VESSEL_QUALIFIER, CONTRACT_NO,
					SHIP_UNITS_NBR, ISO_EQP_TYPE_CD, DEPARTURE_DT,
					ARRIVAL_DT, ARRIVAL_COUNT, ADJ_RDD_DT,
					K1A, K1B, K2A,
					K2B, K3A, K3B,
					K4A, K4B, K5A,
					K5B, K6A, K6B,
					K7A, K7B, K8A,
					K8B, K9A, K9B,
					K10A, K10B, POL_BERTH_CD,
					POD_BERTH_CD, PLOR_CD, PLOR_DSC,
					PLOD_CD, PLOD_DSC, VESSEL_CD,
					PROCESSED_FLG, ACTION_CD)
				VALUES
					(EDI301_ID_SEQ.NEXTVAL, @ISA_ID, @ISA_NBR,
					@TRADING_PARTNER_CD, @REQUEST_CD, @ACMS_STATUS_CD,
					@CONFIRM_CD, @BOOKING_NO, @POL_FUNCTION,
					@POL_CD, @POL_DSC, @POL_QUALIFIER,
					@POD_FUNCTION, @POD_CD, @POD_DSC,
					@POD_QUALIFIER, @SCAC_CD, @EQP_INITIAL,
					@EQP_NUMBER, @EDI_ID, @VOYAGE_NO,
					@IRCS, @VESSEL_DSC, @VESSEL_FLAG,
					@MILITARY_VOYAGE_NO, @VESSEL_QUALIFIER, @CONTRACT_NO,
					@SHIP_UNITS_NBR, @ISO_EQP_TYPE_CD, @DEPARTURE_DT,
					@ARRIVAL_DT, @ARRIVAL_COUNT, @ADJ_RDD_DT,
					@K1A, @K1B, @K2A,
					@K2B, @K3A, @K3B,
					@K4A, @K4B, @K5A,
					@K5B, @K6A, @K6B,
					@K7A, @K7B, @K8A,
					@K8B, @K9A, @K9B,
					@K10A, @K10B, @POL_BERTH_CD,
					@POD_BERTH_CD, @PLOR_CD, @PLOR_DSC,
					@PLOD_CD, @PLOD_DSC, @VESSEL_CD,
					@PROCESSED_FLG, @ACTION_CD)
				RETURNING
					EDI301_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI301_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi301_ID = ClsConvert.ToInt64Nullable(p[61].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[62].Value);
			Create_User = ClsConvert.ToString(p[63].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[64].Value);
			Modify_User = ClsConvert.ToString(p[65].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[64];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[5] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[6] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[7] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[8] = Connection.GetParameter
				("@POL_FUNCTION", Pol_Function);
			p[9] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[10] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[11] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[12] = Connection.GetParameter
				("@POD_FUNCTION", Pod_Function);
			p[13] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[14] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[15] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[16] = Connection.GetParameter
				("@SCAC_CD", Scac_Cd);
			p[17] = Connection.GetParameter
				("@EQP_INITIAL", Eqp_Initial);
			p[18] = Connection.GetParameter
				("@EQP_NUMBER", Eqp_Number);
			p[19] = Connection.GetParameter
				("@EDI_ID", Edi_ID);
			p[20] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[21] = Connection.GetParameter
				("@IRCS", Ircs);
			p[22] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[23] = Connection.GetParameter
				("@VESSEL_FLAG", Vessel_Flag);
			p[24] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[25] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[26] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[27] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[28] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[29] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[30] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[31] = Connection.GetParameter
				("@ARRIVAL_COUNT", Arrival_Count);
			p[32] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[33] = Connection.GetParameter
				("@K1A", K1a);
			p[34] = Connection.GetParameter
				("@K1B", K1b);
			p[35] = Connection.GetParameter
				("@K2A", K2a);
			p[36] = Connection.GetParameter
				("@K2B", K2b);
			p[37] = Connection.GetParameter
				("@K3A", K3a);
			p[38] = Connection.GetParameter
				("@K3B", K3b);
			p[39] = Connection.GetParameter
				("@K4A", K4a);
			p[40] = Connection.GetParameter
				("@K4B", K4b);
			p[41] = Connection.GetParameter
				("@K5A", K5a);
			p[42] = Connection.GetParameter
				("@K5B", K5b);
			p[43] = Connection.GetParameter
				("@K6A", K6a);
			p[44] = Connection.GetParameter
				("@K6B", K6b);
			p[45] = Connection.GetParameter
				("@K7A", K7a);
			p[46] = Connection.GetParameter
				("@K7B", K7b);
			p[47] = Connection.GetParameter
				("@K8A", K8a);
			p[48] = Connection.GetParameter
				("@K8B", K8b);
			p[49] = Connection.GetParameter
				("@K9A", K9a);
			p[50] = Connection.GetParameter
				("@K9B", K9b);
			p[51] = Connection.GetParameter
				("@K10A", K10a);
			p[52] = Connection.GetParameter
				("@K10B", K10b);
			p[53] = Connection.GetParameter
				("@POL_BERTH_CD", Pol_Berth_Cd);
			p[54] = Connection.GetParameter
				("@POD_BERTH_CD", Pod_Berth_Cd);
			p[55] = Connection.GetParameter
				("@PLOR_CD", Plor_Cd);
			p[56] = Connection.GetParameter
				("@PLOR_DSC", Plor_Dsc);
			p[57] = Connection.GetParameter
				("@PLOD_CD", Plod_Cd);
			p[58] = Connection.GetParameter
				("@PLOD_DSC", Plod_Dsc);
			p[59] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[60] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[61] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[62] = Connection.GetParameter
				("@EDI301_ID", Edi301_ID);
			p[63] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI301 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					REQUEST_CD = @REQUEST_CD,
					ACMS_STATUS_CD = @ACMS_STATUS_CD,
					CONFIRM_CD = @CONFIRM_CD,
					BOOKING_NO = @BOOKING_NO,
					POL_FUNCTION = @POL_FUNCTION,
					POL_CD = @POL_CD,
					POL_DSC = @POL_DSC,
					POL_QUALIFIER = @POL_QUALIFIER,
					POD_FUNCTION = @POD_FUNCTION,
					POD_CD = @POD_CD,
					POD_DSC = @POD_DSC,
					POD_QUALIFIER = @POD_QUALIFIER,
					SCAC_CD = @SCAC_CD,
					EQP_INITIAL = @EQP_INITIAL,
					EQP_NUMBER = @EQP_NUMBER,
					EDI_ID = @EDI_ID,
					VOYAGE_NO = @VOYAGE_NO,
					IRCS = @IRCS,
					VESSEL_DSC = @VESSEL_DSC,
					VESSEL_FLAG = @VESSEL_FLAG,
					MILITARY_VOYAGE_NO = @MILITARY_VOYAGE_NO,
					VESSEL_QUALIFIER = @VESSEL_QUALIFIER,
					CONTRACT_NO = @CONTRACT_NO,
					SHIP_UNITS_NBR = @SHIP_UNITS_NBR,
					ISO_EQP_TYPE_CD = @ISO_EQP_TYPE_CD,
					DEPARTURE_DT = @DEPARTURE_DT,
					ARRIVAL_DT = @ARRIVAL_DT,
					ARRIVAL_COUNT = @ARRIVAL_COUNT,
					ADJ_RDD_DT = @ADJ_RDD_DT,
					K1A = @K1A,
					K1B = @K1B,
					K2A = @K2A,
					K2B = @K2B,
					K3A = @K3A,
					K3B = @K3B,
					K4A = @K4A,
					K4B = @K4B,
					K5A = @K5A,
					K5B = @K5B,
					K6A = @K6A,
					K6B = @K6B,
					K7A = @K7A,
					K7B = @K7B,
					K8A = @K8A,
					K8B = @K8B,
					K9A = @K9A,
					K9B = @K9B,
					K10A = @K10A,
					K10B = @K10B,
					POL_BERTH_CD = @POL_BERTH_CD,
					POD_BERTH_CD = @POD_BERTH_CD,
					PLOR_CD = @PLOR_CD,
					PLOR_DSC = @PLOR_DSC,
					PLOD_CD = @PLOD_CD,
					PLOD_DSC = @PLOD_DSC,
					VESSEL_CD = @VESSEL_CD,
					PROCESSED_FLG = @PROCESSED_FLG,
					ACTION_CD = @ACTION_CD
				WHERE
					EDI301_ID = @EDI301_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[63].Value);
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

			Edi301_ID = ClsConvert.ToInt64Nullable(dr["EDI301_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Pol_Function = ClsConvert.ToString(dr["POL_FUNCTION"]);
			Pol_Cd = ClsConvert.ToString(dr["POL_CD"]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC"]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER"]);
			Pod_Function = ClsConvert.ToString(dr["POD_FUNCTION"]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER"]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD"]);
			Eqp_Initial = ClsConvert.ToString(dr["EQP_INITIAL"]);
			Eqp_Number = ClsConvert.ToDecimalNullable(dr["EQP_NUMBER"]);
			Edi_ID = ClsConvert.ToString(dr["EDI_ID"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Ircs = ClsConvert.ToString(dr["IRCS"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Vessel_Flag = ClsConvert.ToString(dr["VESSEL_FLAG"]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Ship_Units_Nbr = ClsConvert.ToDecimalNullable(dr["SHIP_UNITS_NBR"]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD"]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT"]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT"]);
			Arrival_Count = ClsConvert.ToDecimalNullable(dr["ARRIVAL_COUNT"]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT"]);
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
			Pol_Berth_Cd = ClsConvert.ToString(dr["POL_BERTH_CD"]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["POD_BERTH_CD"]);
			Plor_Cd = ClsConvert.ToString(dr["PLOR_CD"]);
			Plor_Dsc = ClsConvert.ToString(dr["PLOR_DSC"]);
			Plod_Cd = ClsConvert.ToString(dr["PLOD_CD"]);
			Plod_Dsc = ClsConvert.ToString(dr["PLOD_DSC"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi301_ID = ClsConvert.ToInt64Nullable(dr["EDI301_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Pol_Function = ClsConvert.ToString(dr["POL_FUNCTION", v]);
			Pol_Cd = ClsConvert.ToString(dr["POL_CD", v]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC", v]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER", v]);
			Pod_Function = ClsConvert.ToString(dr["POD_FUNCTION", v]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER", v]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD", v]);
			Eqp_Initial = ClsConvert.ToString(dr["EQP_INITIAL", v]);
			Eqp_Number = ClsConvert.ToDecimalNullable(dr["EQP_NUMBER", v]);
			Edi_ID = ClsConvert.ToString(dr["EDI_ID", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Ircs = ClsConvert.ToString(dr["IRCS", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Vessel_Flag = ClsConvert.ToString(dr["VESSEL_FLAG", v]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Ship_Units_Nbr = ClsConvert.ToDecimalNullable(dr["SHIP_UNITS_NBR", v]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD", v]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT", v]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT", v]);
			Arrival_Count = ClsConvert.ToDecimalNullable(dr["ARRIVAL_COUNT", v]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT", v]);
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
			Pol_Berth_Cd = ClsConvert.ToString(dr["POL_BERTH_CD", v]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["POD_BERTH_CD", v]);
			Plor_Cd = ClsConvert.ToString(dr["PLOR_CD", v]);
			Plor_Dsc = ClsConvert.ToString(dr["PLOR_DSC", v]);
			Plod_Cd = ClsConvert.ToString(dr["PLOD_CD", v]);
			Plod_Dsc = ClsConvert.ToString(dr["PLOD_DSC", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI301_ID"] = ClsConvert.ToDbObject(Edi301_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["REQUEST_CD"] = ClsConvert.ToDbObject(Request_Cd);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["CONFIRM_CD"] = ClsConvert.ToDbObject(Confirm_Cd);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["POL_FUNCTION"] = ClsConvert.ToDbObject(Pol_Function);
			dr["POL_CD"] = ClsConvert.ToDbObject(Pol_Cd);
			dr["POL_DSC"] = ClsConvert.ToDbObject(Pol_Dsc);
			dr["POL_QUALIFIER"] = ClsConvert.ToDbObject(Pol_Qualifier);
			dr["POD_FUNCTION"] = ClsConvert.ToDbObject(Pod_Function);
			dr["POD_CD"] = ClsConvert.ToDbObject(Pod_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["POD_QUALIFIER"] = ClsConvert.ToDbObject(Pod_Qualifier);
			dr["SCAC_CD"] = ClsConvert.ToDbObject(Scac_Cd);
			dr["EQP_INITIAL"] = ClsConvert.ToDbObject(Eqp_Initial);
			dr["EQP_NUMBER"] = ClsConvert.ToDbObject(Eqp_Number);
			dr["EDI_ID"] = ClsConvert.ToDbObject(Edi_ID);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["IRCS"] = ClsConvert.ToDbObject(Ircs);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["VESSEL_FLAG"] = ClsConvert.ToDbObject(Vessel_Flag);
			dr["MILITARY_VOYAGE_NO"] = ClsConvert.ToDbObject(Military_Voyage_No);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["SHIP_UNITS_NBR"] = ClsConvert.ToDbObject(Ship_Units_Nbr);
			dr["ISO_EQP_TYPE_CD"] = ClsConvert.ToDbObject(Iso_Eqp_Type_Cd);
			dr["DEPARTURE_DT"] = ClsConvert.ToDbObject(Departure_Dt);
			dr["ARRIVAL_DT"] = ClsConvert.ToDbObject(Arrival_Dt);
			dr["ARRIVAL_COUNT"] = ClsConvert.ToDbObject(Arrival_Count);
			dr["ADJ_RDD_DT"] = ClsConvert.ToDbObject(Adj_Rdd_Dt);
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
			dr["POL_BERTH_CD"] = ClsConvert.ToDbObject(Pol_Berth_Cd);
			dr["POD_BERTH_CD"] = ClsConvert.ToDbObject(Pod_Berth_Cd);
			dr["PLOR_CD"] = ClsConvert.ToDbObject(Plor_Cd);
			dr["PLOR_DSC"] = ClsConvert.ToDbObject(Plor_Dsc);
			dr["PLOD_CD"] = ClsConvert.ToDbObject(Plod_Cd);
			dr["PLOD_DSC"] = ClsConvert.ToDbObject(Plod_Dsc);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["ACTION_CD"] = ClsConvert.ToDbObject(Action_Cd);
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

		public static ClsEdi301 GetUsingKey(Int64 Edi301_ID)
		{
			object[] vals = new object[] {Edi301_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi301(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI301.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}