using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVBookingCargoLine : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_BOOKING_CARGO_LINE";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_BOOKING_CARGO_LINE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Booking_NoMax = 25;
		public const int Deleted_FlgMax = 1;
		public const int Booking_StatusMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Plor_Location_CdMax = 10;
		public const int Plor_DscMax = 50;
		public const int Pol_Location_CdMax = 10;
		public const int Pol_DscMax = 50;
		public const int Pol_BerthMax = 20;
		public const int Pod_Location_CdMax = 10;
		public const int Pod_DscMax = 50;
		public const int Pod_BerthMax = 20;
		public const int Plod_Location_CdMax = 10;
		public const int Plod_DscMax = 50;
		public const int Booking_RefMax = 25;
		public const int Edi_RefMax = 25;
		public const int Customer_RefMax = 25;
		public const int Customer_CdMax = 10;
		public const int Match_CdMax = 15;
		public const int Customer_NmMax = 100;
		public const int Agent_CdMax = 20;
		public const int Bol_NoMax = 25;
		public const int Cargo_TypeMax = 10;
		public const int Move_Type_CdMax = 10;
		public const int Imdg_FlgMax = 10;
		public const int Kind_Of_Pkg_CdMax = 10;
		public const int Delivery_TxtMax = 250;
		public const int Cargo_Notes_TxtMax = 250;
		public const int Ilms_Eligible_FlgMax = 1;
		public const int Tariff_CdMax = 20;
		public const int Service_CdMax = 10;
		public const int Cargo_KeyMax = 30;
		public const int Serial_NoMax = 50;
		public const int Commodity_CdMax = 10;
		public const int Pkg_Type_CdMax = 10;
		public const int Cargo_DscMax = 50;
		public const int Container_NoMax = 20;
		public const int Seal1Max = 20;
		public const int Seal2Max = 20;
		public const int Seal3Max = 20;
		public const int Make_CdMax = 25;
		public const int Model_CdMax = 25;
		public const int Import_Notes_TxtMax = 100;
		public const int Cargo_Type_CdMax = 10;
		public const int Cargo_StatusMax = 10;
		public const int Bol_StatusMax = 10;
		public const int Cargo_Bol_NoMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Booking_Line_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Booking_No;
		protected string _Deleted_Flg;
		protected string _Booking_Status;
		protected DateTime? _Booking_Dt;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Plor_Location_Cd;
		protected string _Plor_Dsc;
		protected string _Pol_Location_Cd;
		protected string _Pol_Dsc;
		protected string _Pol_Berth;
		protected string _Pod_Location_Cd;
		protected string _Pod_Dsc;
		protected string _Pod_Berth;
		protected string _Plod_Location_Cd;
		protected string _Plod_Dsc;
		protected DateTime? _Rdd_Dt;
		protected string _Booking_Ref;
		protected string _Edi_Ref;
		protected string _Customer_Ref;
		protected string _Customer_Cd;
		protected string _Match_Cd;
		protected string _Customer_Nm;
		protected string _Agent_Cd;
		protected Int64? _Bol_ID;
		protected string _Bol_No;
		protected DateTime? _Sail_Dt;
		protected DateTime? _Pol_Ets;
		protected DateTime? _Pod_Eta;
		protected string _Cargo_Type;
		protected string _Move_Type_Cd;
		protected string _Imdg_Flg;
		protected string _Kind_Of_Pkg_Cd;
		protected string _Delivery_Txt;
		protected string _Cargo_Notes_Txt;
		protected string _Ilms_Eligible_Flg;
		protected string _Tariff_Cd;
		protected string _Service_Cd;
		protected Int64? _Cargo_Line_ID;
		protected string _Cargo_Key;
		protected string _Serial_No;
		protected Int64? _Item_No;
		protected string _Commodity_Cd;
		protected string _Pkg_Type_Cd;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Dim_Weight_Nbr;
		protected decimal? _Cube_Ft;
		protected decimal? _M_Tons;
		protected string _Cargo_Dsc;
		protected DateTime? _Vessel_Load_Dt;
		protected string _Container_No;
		protected string _Seal1;
		protected string _Seal2;
		protected string _Seal3;
		protected string _Make_Cd;
		protected string _Model_Cd;
		protected DateTime? _Cargo_Rcvd_Dt;
		protected string _Import_Notes_Txt;
		protected string _Cargo_Type_Cd;
		protected string _Cargo_Status;
		protected string _Bol_Status;
		protected string _Cargo_Bol_No;
		protected DateTime? _Cargo_Rdd_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Booking_Line_ID
		{
			get { return _Booking_Line_ID; }
			set
			{
				if( _Booking_Line_ID == value ) return;
		
				_Booking_Line_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Line_ID");
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
		public string Deleted_Flg
		{
			get { return _Deleted_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Deleted_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Deleted_FlgMax )
					_Deleted_Flg = val.Substring(0, (int)Deleted_FlgMax);
				else
					_Deleted_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Deleted_Flg");
			}
		}
		public string Booking_Status
		{
			get { return _Booking_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_StatusMax )
					_Booking_Status = val.Substring(0, (int)Booking_StatusMax);
				else
					_Booking_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Status");
			}
		}
		public DateTime? Booking_Dt
		{
			get { return _Booking_Dt; }
			set
			{
				if( _Booking_Dt == value ) return;
		
				_Booking_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Dt");
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
		public string Pol_Berth
		{
			get { return _Pol_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_BerthMax )
					_Pol_Berth = val.Substring(0, (int)Pol_BerthMax);
				else
					_Pol_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Berth");
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
		public string Pod_Berth
		{
			get { return _Pod_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_BerthMax )
					_Pod_Berth = val.Substring(0, (int)Pod_BerthMax);
				else
					_Pod_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Berth");
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
		public string Customer_Nm
		{
			get { return _Customer_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_NmMax )
					_Customer_Nm = val.Substring(0, (int)Customer_NmMax);
				else
					_Customer_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Nm");
			}
		}
		public string Agent_Cd
		{
			get { return _Agent_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Agent_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Agent_CdMax )
					_Agent_Cd = val.Substring(0, (int)Agent_CdMax);
				else
					_Agent_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Agent_Cd");
			}
		}
		public Int64? Bol_ID
		{
			get { return _Bol_ID; }
			set
			{
				if( _Bol_ID == value ) return;
		
				_Bol_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Bol_ID");
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
		public DateTime? Pol_Ets
		{
			get { return _Pol_Ets; }
			set
			{
				if( _Pol_Ets == value ) return;
		
				_Pol_Ets = value;
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Ets");
			}
		}
		public DateTime? Pod_Eta
		{
			get { return _Pod_Eta; }
			set
			{
				if( _Pod_Eta == value ) return;
		
				_Pod_Eta = value;
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Eta");
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
		public string Imdg_Flg
		{
			get { return _Imdg_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Imdg_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Imdg_FlgMax )
					_Imdg_Flg = val.Substring(0, (int)Imdg_FlgMax);
				else
					_Imdg_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Imdg_Flg");
			}
		}
		public string Kind_Of_Pkg_Cd
		{
			get { return _Kind_Of_Pkg_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Kind_Of_Pkg_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Kind_Of_Pkg_CdMax )
					_Kind_Of_Pkg_Cd = val.Substring(0, (int)Kind_Of_Pkg_CdMax);
				else
					_Kind_Of_Pkg_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Kind_Of_Pkg_Cd");
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
		public string Ilms_Eligible_Flg
		{
			get { return _Ilms_Eligible_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ilms_Eligible_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ilms_Eligible_FlgMax )
					_Ilms_Eligible_Flg = val.Substring(0, (int)Ilms_Eligible_FlgMax);
				else
					_Ilms_Eligible_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ilms_Eligible_Flg");
			}
		}
		public string Tariff_Cd
		{
			get { return _Tariff_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tariff_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Tariff_CdMax )
					_Tariff_Cd = val.Substring(0, (int)Tariff_CdMax);
				else
					_Tariff_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tariff_Cd");
			}
		}
		public string Service_Cd
		{
			get { return _Service_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Service_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Service_CdMax )
					_Service_Cd = val.Substring(0, (int)Service_CdMax);
				else
					_Service_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Service_Cd");
			}
		}
		public Int64? Cargo_Line_ID
		{
			get { return _Cargo_Line_ID; }
			set
			{
				if( _Cargo_Line_ID == value ) return;
		
				_Cargo_Line_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Line_ID");
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
		public string Commodity_Cd
		{
			get { return _Commodity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_CdMax )
					_Commodity_Cd = val.Substring(0, (int)Commodity_CdMax);
				else
					_Commodity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Cd");
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
		public decimal? Length_Nbr
		{
			get { return _Length_Nbr; }
			set
			{
				if( _Length_Nbr == value ) return;
		
				_Length_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Length_Nbr");
			}
		}
		public decimal? Width_Nbr
		{
			get { return _Width_Nbr; }
			set
			{
				if( _Width_Nbr == value ) return;
		
				_Width_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Width_Nbr");
			}
		}
		public decimal? Height_Nbr
		{
			get { return _Height_Nbr; }
			set
			{
				if( _Height_Nbr == value ) return;
		
				_Height_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Height_Nbr");
			}
		}
		public decimal? Weight_Nbr
		{
			get { return _Weight_Nbr; }
			set
			{
				if( _Weight_Nbr == value ) return;
		
				_Weight_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weight_Nbr");
			}
		}
		public decimal? Dim_Weight_Nbr
		{
			get { return _Dim_Weight_Nbr; }
			set
			{
				if( _Dim_Weight_Nbr == value ) return;
		
				_Dim_Weight_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Dim_Weight_Nbr");
			}
		}
		public decimal? Cube_Ft
		{
			get { return _Cube_Ft; }
			set
			{
				if( _Cube_Ft == value ) return;
		
				_Cube_Ft = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cube_Ft");
			}
		}
		public decimal? M_Tons
		{
			get { return _M_Tons; }
			set
			{
				if( _M_Tons == value ) return;
		
				_M_Tons = value;
				_IsDirty = true;
				NotifyPropertyChanged("M_Tons");
			}
		}
		public string Cargo_Dsc
		{
			get { return _Cargo_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_DscMax )
					_Cargo_Dsc = val.Substring(0, (int)Cargo_DscMax);
				else
					_Cargo_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Dsc");
			}
		}
		public DateTime? Vessel_Load_Dt
		{
			get { return _Vessel_Load_Dt; }
			set
			{
				if( _Vessel_Load_Dt == value ) return;
		
				_Vessel_Load_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Load_Dt");
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
		public string Seal1
		{
			get { return _Seal1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Seal1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Seal1Max )
					_Seal1 = val.Substring(0, (int)Seal1Max);
				else
					_Seal1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Seal1");
			}
		}
		public string Seal2
		{
			get { return _Seal2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Seal2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Seal2Max )
					_Seal2 = val.Substring(0, (int)Seal2Max);
				else
					_Seal2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Seal2");
			}
		}
		public string Seal3
		{
			get { return _Seal3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Seal3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Seal3Max )
					_Seal3 = val.Substring(0, (int)Seal3Max);
				else
					_Seal3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Seal3");
			}
		}
		public string Make_Cd
		{
			get { return _Make_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Make_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Make_CdMax )
					_Make_Cd = val.Substring(0, (int)Make_CdMax);
				else
					_Make_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Make_Cd");
			}
		}
		public string Model_Cd
		{
			get { return _Model_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Model_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Model_CdMax )
					_Model_Cd = val.Substring(0, (int)Model_CdMax);
				else
					_Model_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Model_Cd");
			}
		}
		public DateTime? Cargo_Rcvd_Dt
		{
			get { return _Cargo_Rcvd_Dt; }
			set
			{
				if( _Cargo_Rcvd_Dt == value ) return;
		
				_Cargo_Rcvd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Rcvd_Dt");
			}
		}
		public string Import_Notes_Txt
		{
			get { return _Import_Notes_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Import_Notes_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Import_Notes_TxtMax )
					_Import_Notes_Txt = val.Substring(0, (int)Import_Notes_TxtMax);
				else
					_Import_Notes_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Import_Notes_Txt");
			}
		}
		public string Cargo_Type_Cd
		{
			get { return _Cargo_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Type_CdMax )
					_Cargo_Type_Cd = val.Substring(0, (int)Cargo_Type_CdMax);
				else
					_Cargo_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Type_Cd");
			}
		}
		public string Cargo_Status
		{
			get { return _Cargo_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_StatusMax )
					_Cargo_Status = val.Substring(0, (int)Cargo_StatusMax);
				else
					_Cargo_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Status");
			}
		}
		public string Bol_Status
		{
			get { return _Bol_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_StatusMax )
					_Bol_Status = val.Substring(0, (int)Bol_StatusMax);
				else
					_Bol_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_Status");
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
		public DateTime? Cargo_Rdd_Dt
		{
			get { return _Cargo_Rdd_Dt; }
			set
			{
				if( _Cargo_Rdd_Dt == value ) return;
		
				_Cargo_Rdd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Rdd_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVBookingCargoLine() : base() {}
		public ClsVBookingCargoLine(DataRow dr) : base(dr) {}
		public ClsVBookingCargoLine(ClsVBookingCargoLine src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_Line_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Booking_No = null;
			Deleted_Flg = null;
			Booking_Status = null;
			Booking_Dt = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Plor_Location_Cd = null;
			Plor_Dsc = null;
			Pol_Location_Cd = null;
			Pol_Dsc = null;
			Pol_Berth = null;
			Pod_Location_Cd = null;
			Pod_Dsc = null;
			Pod_Berth = null;
			Plod_Location_Cd = null;
			Plod_Dsc = null;
			Rdd_Dt = null;
			Booking_Ref = null;
			Edi_Ref = null;
			Customer_Ref = null;
			Customer_Cd = null;
			Match_Cd = null;
			Customer_Nm = null;
			Agent_Cd = null;
			Bol_ID = null;
			Bol_No = null;
			Sail_Dt = null;
			Pol_Ets = null;
			Pod_Eta = null;
			Cargo_Type = null;
			Move_Type_Cd = null;
			Imdg_Flg = null;
			Kind_Of_Pkg_Cd = null;
			Delivery_Txt = null;
			Cargo_Notes_Txt = null;
			Ilms_Eligible_Flg = null;
			Tariff_Cd = null;
			Service_Cd = null;
			Cargo_Line_ID = null;
			Cargo_Key = null;
			Serial_No = null;
			Item_No = null;
			Commodity_Cd = null;
			Pkg_Type_Cd = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Dim_Weight_Nbr = null;
			Cube_Ft = null;
			M_Tons = null;
			Cargo_Dsc = null;
			Vessel_Load_Dt = null;
			Container_No = null;
			Seal1 = null;
			Seal2 = null;
			Seal3 = null;
			Make_Cd = null;
			Model_Cd = null;
			Cargo_Rcvd_Dt = null;
			Import_Notes_Txt = null;
			Cargo_Type_Cd = null;
			Cargo_Status = null;
			Bol_Status = null;
			Cargo_Bol_No = null;
			Cargo_Rdd_Dt = null;
		}

		public void CopyFrom(ClsVBookingCargoLine src)
		{
			Booking_Line_ID = src._Booking_Line_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Booking_No = src._Booking_No;
			Deleted_Flg = src._Deleted_Flg;
			Booking_Status = src._Booking_Status;
			Booking_Dt = src._Booking_Dt;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Plor_Dsc = src._Plor_Dsc;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pol_Dsc = src._Pol_Dsc;
			Pol_Berth = src._Pol_Berth;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Pod_Berth = src._Pod_Berth;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Plod_Dsc = src._Plod_Dsc;
			Rdd_Dt = src._Rdd_Dt;
			Booking_Ref = src._Booking_Ref;
			Edi_Ref = src._Edi_Ref;
			Customer_Ref = src._Customer_Ref;
			Customer_Cd = src._Customer_Cd;
			Match_Cd = src._Match_Cd;
			Customer_Nm = src._Customer_Nm;
			Agent_Cd = src._Agent_Cd;
			Bol_ID = src._Bol_ID;
			Bol_No = src._Bol_No;
			Sail_Dt = src._Sail_Dt;
			Pol_Ets = src._Pol_Ets;
			Pod_Eta = src._Pod_Eta;
			Cargo_Type = src._Cargo_Type;
			Move_Type_Cd = src._Move_Type_Cd;
			Imdg_Flg = src._Imdg_Flg;
			Kind_Of_Pkg_Cd = src._Kind_Of_Pkg_Cd;
			Delivery_Txt = src._Delivery_Txt;
			Cargo_Notes_Txt = src._Cargo_Notes_Txt;
			Ilms_Eligible_Flg = src._Ilms_Eligible_Flg;
			Tariff_Cd = src._Tariff_Cd;
			Service_Cd = src._Service_Cd;
			Cargo_Line_ID = src._Cargo_Line_ID;
			Cargo_Key = src._Cargo_Key;
			Serial_No = src._Serial_No;
			Item_No = src._Item_No;
			Commodity_Cd = src._Commodity_Cd;
			Pkg_Type_Cd = src._Pkg_Type_Cd;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Dim_Weight_Nbr = src._Dim_Weight_Nbr;
			Cube_Ft = src._Cube_Ft;
			M_Tons = src._M_Tons;
			Cargo_Dsc = src._Cargo_Dsc;
			Vessel_Load_Dt = src._Vessel_Load_Dt;
			Container_No = src._Container_No;
			Seal1 = src._Seal1;
			Seal2 = src._Seal2;
			Seal3 = src._Seal3;
			Make_Cd = src._Make_Cd;
			Model_Cd = src._Model_Cd;
			Cargo_Rcvd_Dt = src._Cargo_Rcvd_Dt;
			Import_Notes_Txt = src._Import_Notes_Txt;
			Cargo_Type_Cd = src._Cargo_Type_Cd;
			Cargo_Status = src._Cargo_Status;
			Bol_Status = src._Bol_Status;
			Cargo_Bol_No = src._Cargo_Bol_No;
			Cargo_Rdd_Dt = src._Cargo_Rdd_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsVBookingCargoLine tmp = null;	//No primary key can't refresh;
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
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@DELETED_FLG", Deleted_Flg);
			p[3] = Connection.GetParameter
				("@BOOKING_STATUS", Booking_Status);
			p[4] = Connection.GetParameter
				("@BOOKING_DT", Booking_Dt);
			p[5] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[6] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[7] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[8] = Connection.GetParameter
				("@PLOR_DSC", Plor_Dsc);
			p[9] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[10] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[11] = Connection.GetParameter
				("@POL_BERTH", Pol_Berth);
			p[12] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[13] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[14] = Connection.GetParameter
				("@POD_BERTH", Pod_Berth);
			p[15] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[16] = Connection.GetParameter
				("@PLOD_DSC", Plod_Dsc);
			p[17] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[18] = Connection.GetParameter
				("@BOOKING_REF", Booking_Ref);
			p[19] = Connection.GetParameter
				("@EDI_REF", Edi_Ref);
			p[20] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[21] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[22] = Connection.GetParameter
				("@MATCH_CD", Match_Cd);
			p[23] = Connection.GetParameter
				("@CUSTOMER_NM", Customer_Nm);
			p[24] = Connection.GetParameter
				("@AGENT_CD", Agent_Cd);
			p[25] = Connection.GetParameter
				("@BOL_ID", Bol_ID);
			p[26] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[27] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[28] = Connection.GetParameter
				("@POL_ETS", Pol_Ets);
			p[29] = Connection.GetParameter
				("@POD_ETA", Pod_Eta);
			p[30] = Connection.GetParameter
				("@CARGO_TYPE", Cargo_Type);
			p[31] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[32] = Connection.GetParameter
				("@IMDG_FLG", Imdg_Flg);
			p[33] = Connection.GetParameter
				("@KIND_OF_PKG_CD", Kind_Of_Pkg_Cd);
			p[34] = Connection.GetParameter
				("@DELIVERY_TXT", Delivery_Txt);
			p[35] = Connection.GetParameter
				("@CARGO_NOTES_TXT", Cargo_Notes_Txt);
			p[36] = Connection.GetParameter
				("@ILMS_ELIGIBLE_FLG", Ilms_Eligible_Flg);
			p[37] = Connection.GetParameter
				("@TARIFF_CD", Tariff_Cd);
			p[38] = Connection.GetParameter
				("@SERVICE_CD", Service_Cd);
			p[39] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[40] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[41] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[42] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[43] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[44] = Connection.GetParameter
				("@PKG_TYPE_CD", Pkg_Type_Cd);
			p[45] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[46] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[47] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[48] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[49] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[50] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[51] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[52] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[53] = Connection.GetParameter
				("@VESSEL_LOAD_DT", Vessel_Load_Dt);
			p[54] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[55] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[56] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[57] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[58] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[59] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[60] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[61] = Connection.GetParameter
				("@IMPORT_NOTES_TXT", Import_Notes_Txt);
			p[62] = Connection.GetParameter
				("@CARGO_TYPE_CD", Cargo_Type_Cd);
			p[63] = Connection.GetParameter
				("@CARGO_STATUS", Cargo_Status);
			p[64] = Connection.GetParameter
				("@BOL_STATUS", Bol_Status);
			p[65] = Connection.GetParameter
				("@CARGO_BOL_NO", Cargo_Bol_No);
			p[66] = Connection.GetParameter
				("@CARGO_RDD_DT", Cargo_Rdd_Dt);
			p[67] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[68] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[69] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[70] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO V_BOOKING_CARGO_LINE
					(BOOKING_LINE_ID, BOOKING_NO, DELETED_FLG,
					BOOKING_STATUS, BOOKING_DT, VESSEL_CD,
					VOYAGE_NO, PLOR_LOCATION_CD, PLOR_DSC,
					POL_LOCATION_CD, POL_DSC, POL_BERTH,
					POD_LOCATION_CD, POD_DSC, POD_BERTH,
					PLOD_LOCATION_CD, PLOD_DSC, RDD_DT,
					BOOKING_REF, EDI_REF, CUSTOMER_REF,
					CUSTOMER_CD, MATCH_CD, CUSTOMER_NM,
					AGENT_CD, BOL_ID, BOL_NO,
					SAIL_DT, POL_ETS, POD_ETA,
					CARGO_TYPE, MOVE_TYPE_CD, IMDG_FLG,
					KIND_OF_PKG_CD, DELIVERY_TXT, CARGO_NOTES_TXT,
					ILMS_ELIGIBLE_FLG, TARIFF_CD, SERVICE_CD,
					CARGO_LINE_ID, CARGO_KEY, SERIAL_NO,
					ITEM_NO, COMMODITY_CD, PKG_TYPE_CD,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, DIM_WEIGHT_NBR, CUBE_FT,
					M_TONS, CARGO_DSC, VESSEL_LOAD_DT,
					CONTAINER_NO, SEAL1, SEAL2,
					SEAL3, MAKE_CD, MODEL_CD,
					CARGO_RCVD_DT, IMPORT_NOTES_TXT, CARGO_TYPE_CD,
					CARGO_STATUS, BOL_STATUS, CARGO_BOL_NO,
					CARGO_RDD_DT)
				VALUES
					(@BOOKING_LINE_ID, @BOOKING_NO, @DELETED_FLG,
					@BOOKING_STATUS, @BOOKING_DT, @VESSEL_CD,
					@VOYAGE_NO, @PLOR_LOCATION_CD, @PLOR_DSC,
					@POL_LOCATION_CD, @POL_DSC, @POL_BERTH,
					@POD_LOCATION_CD, @POD_DSC, @POD_BERTH,
					@PLOD_LOCATION_CD, @PLOD_DSC, @RDD_DT,
					@BOOKING_REF, @EDI_REF, @CUSTOMER_REF,
					@CUSTOMER_CD, @MATCH_CD, @CUSTOMER_NM,
					@AGENT_CD, @BOL_ID, @BOL_NO,
					@SAIL_DT, @POL_ETS, @POD_ETA,
					@CARGO_TYPE, @MOVE_TYPE_CD, @IMDG_FLG,
					@KIND_OF_PKG_CD, @DELIVERY_TXT, @CARGO_NOTES_TXT,
					@ILMS_ELIGIBLE_FLG, @TARIFF_CD, @SERVICE_CD,
					@CARGO_LINE_ID, @CARGO_KEY, @SERIAL_NO,
					@ITEM_NO, @COMMODITY_CD, @PKG_TYPE_CD,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @DIM_WEIGHT_NBR, @CUBE_FT,
					@M_TONS, @CARGO_DSC, @VESSEL_LOAD_DT,
					@CONTAINER_NO, @SEAL1, @SEAL2,
					@SEAL3, @MAKE_CD, @MODEL_CD,
					@CARGO_RCVD_DT, @IMPORT_NOTES_TXT, @CARGO_TYPE_CD,
					@CARGO_STATUS, @BOL_STATUS, @CARGO_BOL_NO,
					@CARGO_RDD_DT)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[67].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[68].Value);
			Modify_User = ClsConvert.ToString(p[69].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[70].Value);
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

			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Deleted_Flg = ClsConvert.ToString(dr["DELETED_FLG"]);
			Booking_Status = ClsConvert.ToString(dr["BOOKING_STATUS"]);
			Booking_Dt = ClsConvert.ToDateTimeNullable(dr["BOOKING_DT"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Plor_Dsc = ClsConvert.ToString(dr["PLOR_DSC"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC"]);
			Pol_Berth = ClsConvert.ToString(dr["POL_BERTH"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Pod_Berth = ClsConvert.ToString(dr["POD_BERTH"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Plod_Dsc = ClsConvert.ToString(dr["PLOD_DSC"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Booking_Ref = ClsConvert.ToString(dr["BOOKING_REF"]);
			Edi_Ref = ClsConvert.ToString(dr["EDI_REF"]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
			Match_Cd = ClsConvert.ToString(dr["MATCH_CD"]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM"]);
			Agent_Cd = ClsConvert.ToString(dr["AGENT_CD"]);
			Bol_ID = ClsConvert.ToInt64Nullable(dr["BOL_ID"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Pol_Ets = ClsConvert.ToDateTimeNullable(dr["POL_ETS"]);
			Pod_Eta = ClsConvert.ToDateTimeNullable(dr["POD_ETA"]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Imdg_Flg = ClsConvert.ToString(dr["IMDG_FLG"]);
			Kind_Of_Pkg_Cd = ClsConvert.ToString(dr["KIND_OF_PKG_CD"]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT"]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT"]);
			Ilms_Eligible_Flg = ClsConvert.ToString(dr["ILMS_ELIGIBLE_FLG"]);
			Tariff_Cd = ClsConvert.ToString(dr["TARIFF_CD"]);
			Service_Cd = ClsConvert.ToString(dr["SERVICE_CD"]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR"]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT"]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS"]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC"]);
			Vessel_Load_Dt = ClsConvert.ToDateTimeNullable(dr["VESSEL_LOAD_DT"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Seal1 = ClsConvert.ToString(dr["SEAL1"]);
			Seal2 = ClsConvert.ToString(dr["SEAL2"]);
			Seal3 = ClsConvert.ToString(dr["SEAL3"]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD"]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD"]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT"]);
			Import_Notes_Txt = ClsConvert.ToString(dr["IMPORT_NOTES_TXT"]);
			Cargo_Type_Cd = ClsConvert.ToString(dr["CARGO_TYPE_CD"]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS"]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS"]);
			Cargo_Bol_No = ClsConvert.ToString(dr["CARGO_BOL_NO"]);
			Cargo_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RDD_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Deleted_Flg = ClsConvert.ToString(dr["DELETED_FLG", v]);
			Booking_Status = ClsConvert.ToString(dr["BOOKING_STATUS", v]);
			Booking_Dt = ClsConvert.ToDateTimeNullable(dr["BOOKING_DT", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Plor_Dsc = ClsConvert.ToString(dr["PLOR_DSC", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC", v]);
			Pol_Berth = ClsConvert.ToString(dr["POL_BERTH", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Pod_Berth = ClsConvert.ToString(dr["POD_BERTH", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Plod_Dsc = ClsConvert.ToString(dr["PLOD_DSC", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Booking_Ref = ClsConvert.ToString(dr["BOOKING_REF", v]);
			Edi_Ref = ClsConvert.ToString(dr["EDI_REF", v]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
			Match_Cd = ClsConvert.ToString(dr["MATCH_CD", v]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM", v]);
			Agent_Cd = ClsConvert.ToString(dr["AGENT_CD", v]);
			Bol_ID = ClsConvert.ToInt64Nullable(dr["BOL_ID", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Pol_Ets = ClsConvert.ToDateTimeNullable(dr["POL_ETS", v]);
			Pod_Eta = ClsConvert.ToDateTimeNullable(dr["POD_ETA", v]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Imdg_Flg = ClsConvert.ToString(dr["IMDG_FLG", v]);
			Kind_Of_Pkg_Cd = ClsConvert.ToString(dr["KIND_OF_PKG_CD", v]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT", v]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT", v]);
			Ilms_Eligible_Flg = ClsConvert.ToString(dr["ILMS_ELIGIBLE_FLG", v]);
			Tariff_Cd = ClsConvert.ToString(dr["TARIFF_CD", v]);
			Service_Cd = ClsConvert.ToString(dr["SERVICE_CD", v]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR", v]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT", v]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS", v]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC", v]);
			Vessel_Load_Dt = ClsConvert.ToDateTimeNullable(dr["VESSEL_LOAD_DT", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Seal1 = ClsConvert.ToString(dr["SEAL1", v]);
			Seal2 = ClsConvert.ToString(dr["SEAL2", v]);
			Seal3 = ClsConvert.ToString(dr["SEAL3", v]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD", v]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD", v]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT", v]);
			Import_Notes_Txt = ClsConvert.ToString(dr["IMPORT_NOTES_TXT", v]);
			Cargo_Type_Cd = ClsConvert.ToString(dr["CARGO_TYPE_CD", v]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS", v]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS", v]);
			Cargo_Bol_No = ClsConvert.ToString(dr["CARGO_BOL_NO", v]);
			Cargo_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RDD_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_LINE_ID"] = ClsConvert.ToDbObject(Booking_Line_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["DELETED_FLG"] = ClsConvert.ToDbObject(Deleted_Flg);
			dr["BOOKING_STATUS"] = ClsConvert.ToDbObject(Booking_Status);
			dr["BOOKING_DT"] = ClsConvert.ToDbObject(Booking_Dt);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["PLOR_DSC"] = ClsConvert.ToDbObject(Plor_Dsc);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POL_DSC"] = ClsConvert.ToDbObject(Pol_Dsc);
			dr["POL_BERTH"] = ClsConvert.ToDbObject(Pol_Berth);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["POD_BERTH"] = ClsConvert.ToDbObject(Pod_Berth);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["PLOD_DSC"] = ClsConvert.ToDbObject(Plod_Dsc);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["BOOKING_REF"] = ClsConvert.ToDbObject(Booking_Ref);
			dr["EDI_REF"] = ClsConvert.ToDbObject(Edi_Ref);
			dr["CUSTOMER_REF"] = ClsConvert.ToDbObject(Customer_Ref);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
			dr["MATCH_CD"] = ClsConvert.ToDbObject(Match_Cd);
			dr["CUSTOMER_NM"] = ClsConvert.ToDbObject(Customer_Nm);
			dr["AGENT_CD"] = ClsConvert.ToDbObject(Agent_Cd);
			dr["BOL_ID"] = ClsConvert.ToDbObject(Bol_ID);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["POL_ETS"] = ClsConvert.ToDbObject(Pol_Ets);
			dr["POD_ETA"] = ClsConvert.ToDbObject(Pod_Eta);
			dr["CARGO_TYPE"] = ClsConvert.ToDbObject(Cargo_Type);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["IMDG_FLG"] = ClsConvert.ToDbObject(Imdg_Flg);
			dr["KIND_OF_PKG_CD"] = ClsConvert.ToDbObject(Kind_Of_Pkg_Cd);
			dr["DELIVERY_TXT"] = ClsConvert.ToDbObject(Delivery_Txt);
			dr["CARGO_NOTES_TXT"] = ClsConvert.ToDbObject(Cargo_Notes_Txt);
			dr["ILMS_ELIGIBLE_FLG"] = ClsConvert.ToDbObject(Ilms_Eligible_Flg);
			dr["TARIFF_CD"] = ClsConvert.ToDbObject(Tariff_Cd);
			dr["SERVICE_CD"] = ClsConvert.ToDbObject(Service_Cd);
			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["PKG_TYPE_CD"] = ClsConvert.ToDbObject(Pkg_Type_Cd);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["DIM_WEIGHT_NBR"] = ClsConvert.ToDbObject(Dim_Weight_Nbr);
			dr["CUBE_FT"] = ClsConvert.ToDbObject(Cube_Ft);
			dr["M_TONS"] = ClsConvert.ToDbObject(M_Tons);
			dr["CARGO_DSC"] = ClsConvert.ToDbObject(Cargo_Dsc);
			dr["VESSEL_LOAD_DT"] = ClsConvert.ToDbObject(Vessel_Load_Dt);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["SEAL1"] = ClsConvert.ToDbObject(Seal1);
			dr["SEAL2"] = ClsConvert.ToDbObject(Seal2);
			dr["SEAL3"] = ClsConvert.ToDbObject(Seal3);
			dr["MAKE_CD"] = ClsConvert.ToDbObject(Make_Cd);
			dr["MODEL_CD"] = ClsConvert.ToDbObject(Model_Cd);
			dr["CARGO_RCVD_DT"] = ClsConvert.ToDbObject(Cargo_Rcvd_Dt);
			dr["IMPORT_NOTES_TXT"] = ClsConvert.ToDbObject(Import_Notes_Txt);
			dr["CARGO_TYPE_CD"] = ClsConvert.ToDbObject(Cargo_Type_Cd);
			dr["CARGO_STATUS"] = ClsConvert.ToDbObject(Cargo_Status);
			dr["BOL_STATUS"] = ClsConvert.ToDbObject(Bol_Status);
			dr["CARGO_BOL_NO"] = ClsConvert.ToDbObject(Cargo_Bol_No);
			dr["CARGO_RDD_DT"] = ClsConvert.ToDbObject(Cargo_Rdd_Dt);
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