using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBookingLine : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_LINE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOOKING_LINE_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_LINE";

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
		public const int Customer_RefMax = 50;
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
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Booking_Dt == val ) return;
		
				_Booking_Dt = val;
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
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Rdd_Dt == val ) return;
		
				_Rdd_Dt = val;
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
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Sail_Dt == val ) return;
		
				_Sail_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}
		public DateTime? Pol_Ets
		{
			get { return _Pol_Ets; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Pol_Ets == val ) return;
		
				_Pol_Ets = val;
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Ets");
			}
		}
		public DateTime? Pod_Eta
		{
			get { return _Pod_Eta; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Pod_Eta == val ) return;
		
				_Pod_Eta = val;
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingLine() : base() {}
		public ClsBookingLine(DataRow dr) : base(dr) {}
		public ClsBookingLine(ClsBookingLine src) { CopyFrom(src); }

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
		}

		public void CopyFrom(ClsBookingLine src)
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
		}

		public override bool ReloadFromDB()
		{
			ClsBookingLine tmp = ClsBookingLine.GetUsingKey(Booking_Line_ID.Value);
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

			DbParameter[] p = new DbParameter[42];

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
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[39] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[40] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[41] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_BOOKING_LINE
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
					ILMS_ELIGIBLE_FLG, TARIFF_CD)
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
					@ILMS_ELIGIBLE_FLG, @TARIFF_CD)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[38].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[39].Value);
			Modify_User = ClsConvert.ToString(p[40].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[41].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[40];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
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
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[39] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_BOOKING_LINE SET
					MODIFY_DT = @MODIFY_DT,
					BOOKING_NO = @BOOKING_NO,
					DELETED_FLG = @DELETED_FLG,
					BOOKING_STATUS = @BOOKING_STATUS,
					BOOKING_DT = @BOOKING_DT,
					VESSEL_CD = @VESSEL_CD,
					VOYAGE_NO = @VOYAGE_NO,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					PLOR_DSC = @PLOR_DSC,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POL_DSC = @POL_DSC,
					POL_BERTH = @POL_BERTH,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					POD_DSC = @POD_DSC,
					POD_BERTH = @POD_BERTH,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					PLOD_DSC = @PLOD_DSC,
					RDD_DT = @RDD_DT,
					BOOKING_REF = @BOOKING_REF,
					EDI_REF = @EDI_REF,
					CUSTOMER_REF = @CUSTOMER_REF,
					CUSTOMER_CD = @CUSTOMER_CD,
					MATCH_CD = @MATCH_CD,
					CUSTOMER_NM = @CUSTOMER_NM,
					AGENT_CD = @AGENT_CD,
					BOL_ID = @BOL_ID,
					BOL_NO = @BOL_NO,
					SAIL_DT = @SAIL_DT,
					POL_ETS = @POL_ETS,
					POD_ETA = @POD_ETA,
					CARGO_TYPE = @CARGO_TYPE,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					IMDG_FLG = @IMDG_FLG,
					KIND_OF_PKG_CD = @KIND_OF_PKG_CD,
					DELIVERY_TXT = @DELIVERY_TXT,
					CARGO_NOTES_TXT = @CARGO_NOTES_TXT,
					ILMS_ELIGIBLE_FLG = @ILMS_ELIGIBLE_FLG,
					TARIFF_CD = @TARIFF_CD
				WHERE
					BOOKING_LINE_ID = @BOOKING_LINE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[39].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);

			const string sql = @"
				DELETE FROM T_BOOKING_LINE WHERE
				BOOKING_LINE_ID=@BOOKING_LINE_ID";
			return Connection.RunSQL(sql, p);
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

		public static ClsBookingLine GetUsingKey(Int64 Booking_Line_ID)
		{
			object[] vals = new object[] {Booking_Line_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingLine(dr);
		}

		#endregion		// #region Static Methods
	}
}