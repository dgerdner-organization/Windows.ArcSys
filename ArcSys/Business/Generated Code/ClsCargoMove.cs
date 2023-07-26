using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoMove : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_MOVE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_MOVE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO_MOVE 
				LEFT OUTER JOIN T_CARGO_ACTION
				ON T_CARGO_MOVE.LAST_LOGISTIC_ACTION_ID=T_CARGO_ACTION.CARGO_ACTION_ID
				LEFT OUTER JOIN R_VESSEL
				ON T_CARGO_MOVE.VESSEL_CD=R_VESSEL.VESSEL_CD
				LEFT OUTER JOIN R_LOCATION
				ON T_CARGO_MOVE.PLOR_LOCATION_CD=R_LOCATION.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc2
				ON T_CARGO_MOVE.POL_LOCATION_CD=r_loc2.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc3
				ON T_CARGO_MOVE.POD_LOCATION_CD=r_loc3.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc4
				ON T_CARGO_MOVE.PLOD_LOCATION_CD=r_loc4.LOCATION_CD
				LEFT OUTER JOIN R_MOVE_TYPE
				ON T_CARGO_MOVE.MOVE_TYPE_CD=R_MOVE_TYPE.MOVE_TYPE_CD
				LEFT OUTER JOIN T_CARGO_ACTION t_car2
				ON T_CARGO_MOVE.LAST_CARGO_ACTION_ID=t_car2.CARGO_ACTION_ID
				LEFT OUTER JOIN T_CONVEYANCE
				ON T_CARGO_MOVE.CONVEYANCE_ID=T_CONVEYANCE.CONVEYANCE_ID
				INNER JOIN T_VENDOR_MOVE
				ON T_CARGO_MOVE.VENDOR_MOVE_ID=T_VENDOR_MOVE.VENDOR_MOVE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Serial_NoMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Tag_NoMax = 20;
		public const int Booking_NoMax = 25;
		public const int Customer_RefMax = 25;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Plor_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Plod_Location_CdMax = 10;
		public const int Bol_NoMax = 25;
		public const int Rcvr_DodaacMax = 25;
		public const int Move_Type_CdMax = 10;
		public const int Cargo_DscMax = 50;
		public const int Container_NoMax = 20;
		public const int Cargo_KeyMax = 30;
		public const int Delivery_TxtMax = 250;
		public const int Cargo_Notes_TxtMax = 250;
		public const int Seal1Max = 20;
		public const int Seal2Max = 20;
		public const int Seal3Max = 20;
		public const int Make_CdMax = 25;
		public const int Model_CdMax = 25;
		public const int Commodity_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Move_ID;
		protected Int64? _Vendor_Move_ID;
		protected string _Serial_No;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected Int64? _Cargo_Activity_ID;
		protected Int64? _Conveyance_ID;
		protected DateTime? _Customs_Submitted_Dt;
		protected DateTime? _Customs_Clearance_Dt;
		protected DateTime? _Move_Start_Dt;
		protected DateTime? _Move_End_Dt;
		protected string _Tag_No;
		protected DateTime? _Tag_Commission_Dt;
		protected DateTime? _Tag_Decommission_Dt;
		protected DateTime? _In_Gate_Dt;
		protected DateTime? _Delivery_Dt;
		protected Int64? _Last_Cargo_Action_ID;
		protected Int64? _Last_Logistic_Action_ID;
		protected string _Booking_No;
		protected string _Customer_Ref;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected DateTime? _Sail_Dt;
		protected string _Plor_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Plod_Location_Cd;
		protected string _Bol_No;
		protected DateTime? _Required_Dlvy_Dt;
		protected string _Rcvr_Dodaac;
		protected string _Move_Type_Cd;
		protected string _Cargo_Dsc;
		protected string _Container_No;
		protected string _Cargo_Key;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Dim_Weight_Nbr;
		protected decimal? _Cube_Ft;
		protected decimal? _M_Tons;
		protected string _Delivery_Txt;
		protected string _Cargo_Notes_Txt;
		protected string _Seal1;
		protected string _Seal2;
		protected string _Seal3;
		protected string _Make_Cd;
		protected string _Model_Cd;
		protected string _Commodity_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_Move_ID
		{
			get { return _Cargo_Move_ID; }
			set
			{
				if( _Cargo_Move_ID == value ) return;
		
				_Cargo_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Move_ID");
			}
		}
		public Int64? Vendor_Move_ID
		{
			get { return _Vendor_Move_ID; }
			set
			{
				if( _Vendor_Move_ID == value ) return;
		
				_Vendor_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Move_ID");
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
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
			}
		}
		public Int64? Cargo_Activity_ID
		{
			get { return _Cargo_Activity_ID; }
			set
			{
				if( _Cargo_Activity_ID == value ) return;
		
				_Cargo_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Activity_ID");
			}
		}
		public Int64? Conveyance_ID
		{
			get { return _Conveyance_ID; }
			set
			{
				if( _Conveyance_ID == value ) return;
		
				_Conveyance_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_ID");
			}
		}
		public DateTime? Customs_Submitted_Dt
		{
			get { return _Customs_Submitted_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Customs_Submitted_Dt == val ) return;
		
				_Customs_Submitted_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Customs_Submitted_Dt");
			}
		}
		public DateTime? Customs_Clearance_Dt
		{
			get { return _Customs_Clearance_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Customs_Clearance_Dt == val ) return;
		
				_Customs_Clearance_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Customs_Clearance_Dt");
			}
		}
		public DateTime? Move_Start_Dt
		{
			get { return _Move_Start_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Move_Start_Dt == val ) return;
		
				_Move_Start_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Move_Start_Dt");
			}
		}
		public DateTime? Move_End_Dt
		{
			get { return _Move_End_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Move_End_Dt == val ) return;
		
				_Move_End_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Move_End_Dt");
			}
		}
		public string Tag_No
		{
			get { return _Tag_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tag_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Tag_NoMax )
					_Tag_No = val.Substring(0, (int)Tag_NoMax);
				else
					_Tag_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tag_No");
			}
		}
		public DateTime? Tag_Commission_Dt
		{
			get { return _Tag_Commission_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Tag_Commission_Dt == val ) return;
		
				_Tag_Commission_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Tag_Commission_Dt");
			}
		}
		public DateTime? Tag_Decommission_Dt
		{
			get { return _Tag_Decommission_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Tag_Decommission_Dt == val ) return;
		
				_Tag_Decommission_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Tag_Decommission_Dt");
			}
		}
		public DateTime? In_Gate_Dt
		{
			get { return _In_Gate_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _In_Gate_Dt == val ) return;
		
				_In_Gate_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("In_Gate_Dt");
			}
		}
		public DateTime? Delivery_Dt
		{
			get { return _Delivery_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Delivery_Dt == val ) return;
		
				_Delivery_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dt");
			}
		}
		public Int64? Last_Cargo_Action_ID
		{
			get { return _Last_Cargo_Action_ID; }
			set
			{
				if( _Last_Cargo_Action_ID == value ) return;
		
				_Last_Cargo_Action_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Last_Cargo_Action_ID");
			}
		}
		public Int64? Last_Logistic_Action_ID
		{
			get { return _Last_Logistic_Action_ID; }
			set
			{
				if( _Last_Logistic_Action_ID == value ) return;
		
				_Last_Logistic_Action_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Last_Logistic_Action_ID");
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
		public DateTime? Required_Dlvy_Dt
		{
			get { return _Required_Dlvy_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Required_Dlvy_Dt == val ) return;
		
				_Required_Dlvy_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Required_Dlvy_Dt");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsCargoAction _Last_Logistic_Action;
		protected ClsVessel _Vessel;
		protected ClsLocation _Plor_Location;
		protected ClsLocation _Pol_Location;
		protected ClsLocation _Pod_Location;
		protected ClsLocation _Plod_Location;
		protected ClsMoveType _Move_Type;
		protected ClsCargoAction _Last_Cargo_Action;
		protected ClsConveyance _Conveyance;
		protected ClsVendorMove _Vendor_Move;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCargoAction Last_Logistic_Action
		{
			get
			{
				if( Last_Logistic_Action_ID == null )
					_Last_Logistic_Action = null;
				else if( _Last_Logistic_Action == null ||
					_Last_Logistic_Action.Cargo_Action_ID != Last_Logistic_Action_ID )
					_Last_Logistic_Action = ClsCargoAction.GetUsingKey(Last_Logistic_Action_ID.Value);
				return _Last_Logistic_Action;
			}
			set
			{
				if( _Last_Logistic_Action == value ) return;
		
				_Last_Logistic_Action = value;
			}
		}
		public ClsVessel Vessel
		{
			get
			{
				if( Vessel_Cd == null )
					_Vessel = null;
				else if( _Vessel == null ||
					_Vessel.Vessel_Cd != Vessel_Cd )
					_Vessel = ClsVessel.GetUsingKey(Vessel_Cd);
				return _Vessel;
			}
			set
			{
				if( _Vessel == value ) return;
		
				_Vessel = value;
			}
		}
		public ClsLocation Plor_Location
		{
			get
			{
				if( Plor_Location_Cd == null )
					_Plor_Location = null;
				else if( _Plor_Location == null ||
					_Plor_Location.Location_Cd != Plor_Location_Cd )
					_Plor_Location = ClsLocation.GetUsingKey(Plor_Location_Cd);
				return _Plor_Location;
			}
			set
			{
				if( _Plor_Location == value ) return;
		
				_Plor_Location = value;
			}
		}
		public ClsLocation Pol_Location
		{
			get
			{
				if( Pol_Location_Cd == null )
					_Pol_Location = null;
				else if( _Pol_Location == null ||
					_Pol_Location.Location_Cd != Pol_Location_Cd )
					_Pol_Location = ClsLocation.GetUsingKey(Pol_Location_Cd);
				return _Pol_Location;
			}
			set
			{
				if( _Pol_Location == value ) return;
		
				_Pol_Location = value;
			}
		}
		public ClsLocation Pod_Location
		{
			get
			{
				if( Pod_Location_Cd == null )
					_Pod_Location = null;
				else if( _Pod_Location == null ||
					_Pod_Location.Location_Cd != Pod_Location_Cd )
					_Pod_Location = ClsLocation.GetUsingKey(Pod_Location_Cd);
				return _Pod_Location;
			}
			set
			{
				if( _Pod_Location == value ) return;
		
				_Pod_Location = value;
			}
		}
		public ClsLocation Plod_Location
		{
			get
			{
				if( Plod_Location_Cd == null )
					_Plod_Location = null;
				else if( _Plod_Location == null ||
					_Plod_Location.Location_Cd != Plod_Location_Cd )
					_Plod_Location = ClsLocation.GetUsingKey(Plod_Location_Cd);
				return _Plod_Location;
			}
			set
			{
				if( _Plod_Location == value ) return;
		
				_Plod_Location = value;
			}
		}
		public ClsMoveType Move_Type
		{
			get
			{
				if( Move_Type_Cd == null )
					_Move_Type = null;
				else if( _Move_Type == null ||
					_Move_Type.Move_Type_Cd != Move_Type_Cd )
					_Move_Type = ClsMoveType.GetUsingKey(Move_Type_Cd);
				return _Move_Type;
			}
			set
			{
				if( _Move_Type == value ) return;
		
				_Move_Type = value;
			}
		}
		public ClsCargoAction Last_Cargo_Action
		{
			get
			{
				if( Last_Cargo_Action_ID == null )
					_Last_Cargo_Action = null;
				else if( _Last_Cargo_Action == null ||
					_Last_Cargo_Action.Cargo_Action_ID != Last_Cargo_Action_ID )
					_Last_Cargo_Action = ClsCargoAction.GetUsingKey(Last_Cargo_Action_ID.Value);
				return _Last_Cargo_Action;
			}
			set
			{
				if( _Last_Cargo_Action == value ) return;
		
				_Last_Cargo_Action = value;
			}
		}
		public ClsConveyance Conveyance
		{
			get
			{
				if( Conveyance_ID == null )
					_Conveyance = null;
				else if( _Conveyance == null ||
					_Conveyance.Conveyance_ID != Conveyance_ID )
					_Conveyance = ClsConveyance.GetUsingKey(Conveyance_ID.Value);
				return _Conveyance;
			}
			set
			{
				if( _Conveyance == value ) return;
		
				_Conveyance = value;
			}
		}
		public ClsVendorMove Vendor_Move
		{
			get
			{
				if( Vendor_Move_ID == null )
					_Vendor_Move = null;
				else if( _Vendor_Move == null ||
					_Vendor_Move.Vendor_Move_ID != Vendor_Move_ID )
					_Vendor_Move = ClsVendorMove.GetUsingKey(Vendor_Move_ID.Value);
				return _Vendor_Move;
			}
			set
			{
				if( _Vendor_Move == value ) return;
		
				_Vendor_Move = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoMove() : base() {}
		public ClsCargoMove(DataRow dr) : base(dr) {}
		public ClsCargoMove(ClsCargoMove src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Move_ID = null;
			Vendor_Move_ID = null;
			Serial_No = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Cargo_Activity_ID = null;
			Conveyance_ID = null;
			Customs_Submitted_Dt = null;
			Customs_Clearance_Dt = null;
			Move_Start_Dt = null;
			Move_End_Dt = null;
			Tag_No = null;
			Tag_Commission_Dt = null;
			Tag_Decommission_Dt = null;
			In_Gate_Dt = null;
			Delivery_Dt = null;
			Last_Cargo_Action_ID = null;
			Last_Logistic_Action_ID = null;
			Booking_No = null;
			Customer_Ref = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Sail_Dt = null;
			Plor_Location_Cd = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Plod_Location_Cd = null;
			Bol_No = null;
			Required_Dlvy_Dt = null;
			Rcvr_Dodaac = null;
			Move_Type_Cd = null;
			Cargo_Dsc = null;
			Container_No = null;
			Cargo_Key = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Dim_Weight_Nbr = null;
			Cube_Ft = null;
			M_Tons = null;
			Delivery_Txt = null;
			Cargo_Notes_Txt = null;
			Seal1 = null;
			Seal2 = null;
			Seal3 = null;
			Make_Cd = null;
			Model_Cd = null;
			Commodity_Cd = null;
		}

		public void CopyFrom(ClsCargoMove src)
		{
			Cargo_Move_ID = src._Cargo_Move_ID;
			Vendor_Move_ID = src._Vendor_Move_ID;
			Serial_No = src._Serial_No;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Conveyance_ID = src._Conveyance_ID;
			Customs_Submitted_Dt = src._Customs_Submitted_Dt;
			Customs_Clearance_Dt = src._Customs_Clearance_Dt;
			Move_Start_Dt = src._Move_Start_Dt;
			Move_End_Dt = src._Move_End_Dt;
			Tag_No = src._Tag_No;
			Tag_Commission_Dt = src._Tag_Commission_Dt;
			Tag_Decommission_Dt = src._Tag_Decommission_Dt;
			In_Gate_Dt = src._In_Gate_Dt;
			Delivery_Dt = src._Delivery_Dt;
			Last_Cargo_Action_ID = src._Last_Cargo_Action_ID;
			Last_Logistic_Action_ID = src._Last_Logistic_Action_ID;
			Booking_No = src._Booking_No;
			Customer_Ref = src._Customer_Ref;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Sail_Dt = src._Sail_Dt;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Bol_No = src._Bol_No;
			Required_Dlvy_Dt = src._Required_Dlvy_Dt;
			Rcvr_Dodaac = src._Rcvr_Dodaac;
			Move_Type_Cd = src._Move_Type_Cd;
			Cargo_Dsc = src._Cargo_Dsc;
			Container_No = src._Container_No;
			Cargo_Key = src._Cargo_Key;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Dim_Weight_Nbr = src._Dim_Weight_Nbr;
			Cube_Ft = src._Cube_Ft;
			M_Tons = src._M_Tons;
			Delivery_Txt = src._Delivery_Txt;
			Cargo_Notes_Txt = src._Cargo_Notes_Txt;
			Seal1 = src._Seal1;
			Seal2 = src._Seal2;
			Seal3 = src._Seal3;
			Make_Cd = src._Make_Cd;
			Model_Cd = src._Model_Cd;
			Commodity_Cd = src._Commodity_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoMove tmp = ClsCargoMove.GetUsingKey(Cargo_Move_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Last_Logistic_Action = null;
			_Vessel = null;
			_Plor_Location = null;
			_Pol_Location = null;
			_Pod_Location = null;
			_Plod_Location = null;
			_Move_Type = null;
			_Last_Cargo_Action = null;
			_Conveyance = null;
			_Vendor_Move = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[52];

			p[0] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[4] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);
			p[5] = Connection.GetParameter
				("@CUSTOMS_SUBMITTED_DT", Customs_Submitted_Dt);
			p[6] = Connection.GetParameter
				("@CUSTOMS_CLEARANCE_DT", Customs_Clearance_Dt);
			p[7] = Connection.GetParameter
				("@MOVE_START_DT", Move_Start_Dt);
			p[8] = Connection.GetParameter
				("@MOVE_END_DT", Move_End_Dt);
			p[9] = Connection.GetParameter
				("@TAG_NO", Tag_No);
			p[10] = Connection.GetParameter
				("@TAG_COMMISSION_DT", Tag_Commission_Dt);
			p[11] = Connection.GetParameter
				("@TAG_DECOMMISSION_DT", Tag_Decommission_Dt);
			p[12] = Connection.GetParameter
				("@IN_GATE_DT", In_Gate_Dt);
			p[13] = Connection.GetParameter
				("@DELIVERY_DT", Delivery_Dt);
			p[14] = Connection.GetParameter
				("@LAST_CARGO_ACTION_ID", Last_Cargo_Action_ID);
			p[15] = Connection.GetParameter
				("@LAST_LOGISTIC_ACTION_ID", Last_Logistic_Action_ID);
			p[16] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[17] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[18] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[19] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[20] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[21] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[22] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[23] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[24] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[25] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[26] = Connection.GetParameter
				("@REQUIRED_DLVY_DT", Required_Dlvy_Dt);
			p[27] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[28] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[29] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[30] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[31] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[32] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[33] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[34] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[35] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[36] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[37] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[38] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[39] = Connection.GetParameter
				("@DELIVERY_TXT", Delivery_Txt);
			p[40] = Connection.GetParameter
				("@CARGO_NOTES_TXT", Cargo_Notes_Txt);
			p[41] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[42] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[43] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[44] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[45] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[46] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[47] = Connection.GetParameter
				("@CARGO_MOVE_ID", Cargo_Move_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[48] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[49] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[50] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[51] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_MOVE
					(CARGO_MOVE_ID, VENDOR_MOVE_ID, SERIAL_NO,
					ACTIVE_FLG, CARGO_ACTIVITY_ID, CONVEYANCE_ID,
					CUSTOMS_SUBMITTED_DT, CUSTOMS_CLEARANCE_DT, MOVE_START_DT,
					MOVE_END_DT, TAG_NO, TAG_COMMISSION_DT,
					TAG_DECOMMISSION_DT, IN_GATE_DT, DELIVERY_DT,
					LAST_CARGO_ACTION_ID, LAST_LOGISTIC_ACTION_ID, BOOKING_NO,
					CUSTOMER_REF, VESSEL_CD, VOYAGE_NO,
					SAIL_DT, PLOR_LOCATION_CD, POL_LOCATION_CD,
					POD_LOCATION_CD, PLOD_LOCATION_CD, BOL_NO,
					REQUIRED_DLVY_DT, RCVR_DODAAC, MOVE_TYPE_CD,
					CARGO_DSC, CONTAINER_NO, CARGO_KEY,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, DIM_WEIGHT_NBR, CUBE_FT,
					M_TONS, DELIVERY_TXT, CARGO_NOTES_TXT,
					SEAL1, SEAL2, SEAL3,
					MAKE_CD, MODEL_CD, COMMODITY_CD)
				VALUES
					(CARGO_MOVE_ID_SEQ.NEXTVAL, @VENDOR_MOVE_ID, @SERIAL_NO,
					@ACTIVE_FLG, @CARGO_ACTIVITY_ID, @CONVEYANCE_ID,
					@CUSTOMS_SUBMITTED_DT, @CUSTOMS_CLEARANCE_DT, @MOVE_START_DT,
					@MOVE_END_DT, @TAG_NO, @TAG_COMMISSION_DT,
					@TAG_DECOMMISSION_DT, @IN_GATE_DT, @DELIVERY_DT,
					@LAST_CARGO_ACTION_ID, @LAST_LOGISTIC_ACTION_ID, @BOOKING_NO,
					@CUSTOMER_REF, @VESSEL_CD, @VOYAGE_NO,
					@SAIL_DT, @PLOR_LOCATION_CD, @POL_LOCATION_CD,
					@POD_LOCATION_CD, @PLOD_LOCATION_CD, @BOL_NO,
					@REQUIRED_DLVY_DT, @RCVR_DODAAC, @MOVE_TYPE_CD,
					@CARGO_DSC, @CONTAINER_NO, @CARGO_KEY,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @DIM_WEIGHT_NBR, @CUBE_FT,
					@M_TONS, @DELIVERY_TXT, @CARGO_NOTES_TXT,
					@SEAL1, @SEAL2, @SEAL3,
					@MAKE_CD, @MODEL_CD, @COMMODITY_CD)
				RETURNING
					CARGO_MOVE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_MOVE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Move_ID = ClsConvert.ToInt64Nullable(p[47].Value);
			Create_User = ClsConvert.ToString(p[48].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[49].Value);
			Modify_User = ClsConvert.ToString(p[50].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[51].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[50];

			p[0] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[5] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);
			p[6] = Connection.GetParameter
				("@CUSTOMS_SUBMITTED_DT", Customs_Submitted_Dt);
			p[7] = Connection.GetParameter
				("@CUSTOMS_CLEARANCE_DT", Customs_Clearance_Dt);
			p[8] = Connection.GetParameter
				("@MOVE_START_DT", Move_Start_Dt);
			p[9] = Connection.GetParameter
				("@MOVE_END_DT", Move_End_Dt);
			p[10] = Connection.GetParameter
				("@TAG_NO", Tag_No);
			p[11] = Connection.GetParameter
				("@TAG_COMMISSION_DT", Tag_Commission_Dt);
			p[12] = Connection.GetParameter
				("@TAG_DECOMMISSION_DT", Tag_Decommission_Dt);
			p[13] = Connection.GetParameter
				("@IN_GATE_DT", In_Gate_Dt);
			p[14] = Connection.GetParameter
				("@DELIVERY_DT", Delivery_Dt);
			p[15] = Connection.GetParameter
				("@LAST_CARGO_ACTION_ID", Last_Cargo_Action_ID);
			p[16] = Connection.GetParameter
				("@LAST_LOGISTIC_ACTION_ID", Last_Logistic_Action_ID);
			p[17] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[18] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[19] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[20] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[21] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[22] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[23] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[24] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[25] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[26] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[27] = Connection.GetParameter
				("@REQUIRED_DLVY_DT", Required_Dlvy_Dt);
			p[28] = Connection.GetParameter
				("@RCVR_DODAAC", Rcvr_Dodaac);
			p[29] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[30] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[31] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[32] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[33] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[34] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[35] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[36] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[37] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[38] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[39] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[40] = Connection.GetParameter
				("@DELIVERY_TXT", Delivery_Txt);
			p[41] = Connection.GetParameter
				("@CARGO_NOTES_TXT", Cargo_Notes_Txt);
			p[42] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[43] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[44] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[45] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[46] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[47] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[48] = Connection.GetParameter
				("@CARGO_MOVE_ID", Cargo_Move_ID);
			p[49] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_MOVE SET
					VENDOR_MOVE_ID = @VENDOR_MOVE_ID,
					SERIAL_NO = @SERIAL_NO,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID,
					CONVEYANCE_ID = @CONVEYANCE_ID,
					CUSTOMS_SUBMITTED_DT = @CUSTOMS_SUBMITTED_DT,
					CUSTOMS_CLEARANCE_DT = @CUSTOMS_CLEARANCE_DT,
					MOVE_START_DT = @MOVE_START_DT,
					MOVE_END_DT = @MOVE_END_DT,
					TAG_NO = @TAG_NO,
					TAG_COMMISSION_DT = @TAG_COMMISSION_DT,
					TAG_DECOMMISSION_DT = @TAG_DECOMMISSION_DT,
					IN_GATE_DT = @IN_GATE_DT,
					DELIVERY_DT = @DELIVERY_DT,
					LAST_CARGO_ACTION_ID = @LAST_CARGO_ACTION_ID,
					LAST_LOGISTIC_ACTION_ID = @LAST_LOGISTIC_ACTION_ID,
					BOOKING_NO = @BOOKING_NO,
					CUSTOMER_REF = @CUSTOMER_REF,
					VESSEL_CD = @VESSEL_CD,
					VOYAGE_NO = @VOYAGE_NO,
					SAIL_DT = @SAIL_DT,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					BOL_NO = @BOL_NO,
					REQUIRED_DLVY_DT = @REQUIRED_DLVY_DT,
					RCVR_DODAAC = @RCVR_DODAAC,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					CARGO_DSC = @CARGO_DSC,
					CONTAINER_NO = @CONTAINER_NO,
					CARGO_KEY = @CARGO_KEY,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					DIM_WEIGHT_NBR = @DIM_WEIGHT_NBR,
					CUBE_FT = @CUBE_FT,
					M_TONS = @M_TONS,
					DELIVERY_TXT = @DELIVERY_TXT,
					CARGO_NOTES_TXT = @CARGO_NOTES_TXT,
					SEAL1 = @SEAL1,
					SEAL2 = @SEAL2,
					SEAL3 = @SEAL3,
					MAKE_CD = @MAKE_CD,
					MODEL_CD = @MODEL_CD,
					COMMODITY_CD = @COMMODITY_CD
				WHERE
					CARGO_MOVE_ID = @CARGO_MOVE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[49].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_MOVE_ID", Cargo_Move_ID);

			const string sql = @"
				DELETE FROM T_CARGO_MOVE WHERE
				CARGO_MOVE_ID=@CARGO_MOVE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Move_ID = ClsConvert.ToInt64Nullable(dr["CARGO_MOVE_ID"]);
			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID"]);
			Customs_Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["CUSTOMS_SUBMITTED_DT"]);
			Customs_Clearance_Dt = ClsConvert.ToDateTimeNullable(dr["CUSTOMS_CLEARANCE_DT"]);
			Move_Start_Dt = ClsConvert.ToDateTimeNullable(dr["MOVE_START_DT"]);
			Move_End_Dt = ClsConvert.ToDateTimeNullable(dr["MOVE_END_DT"]);
			Tag_No = ClsConvert.ToString(dr["TAG_NO"]);
			Tag_Commission_Dt = ClsConvert.ToDateTimeNullable(dr["TAG_COMMISSION_DT"]);
			Tag_Decommission_Dt = ClsConvert.ToDateTimeNullable(dr["TAG_DECOMMISSION_DT"]);
			In_Gate_Dt = ClsConvert.ToDateTimeNullable(dr["IN_GATE_DT"]);
			Delivery_Dt = ClsConvert.ToDateTimeNullable(dr["DELIVERY_DT"]);
			Last_Cargo_Action_ID = ClsConvert.ToInt64Nullable(dr["LAST_CARGO_ACTION_ID"]);
			Last_Logistic_Action_ID = ClsConvert.ToInt64Nullable(dr["LAST_LOGISTIC_ACTION_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Required_Dlvy_Dt = ClsConvert.ToDateTimeNullable(dr["REQUIRED_DLVY_DT"]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR"]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT"]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS"]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT"]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT"]);
			Seal1 = ClsConvert.ToString(dr["SEAL1"]);
			Seal2 = ClsConvert.ToString(dr["SEAL2"]);
			Seal3 = ClsConvert.ToString(dr["SEAL3"]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD"]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Move_ID = ClsConvert.ToInt64Nullable(dr["CARGO_MOVE_ID", v]);
			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID", v]);
			Customs_Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["CUSTOMS_SUBMITTED_DT", v]);
			Customs_Clearance_Dt = ClsConvert.ToDateTimeNullable(dr["CUSTOMS_CLEARANCE_DT", v]);
			Move_Start_Dt = ClsConvert.ToDateTimeNullable(dr["MOVE_START_DT", v]);
			Move_End_Dt = ClsConvert.ToDateTimeNullable(dr["MOVE_END_DT", v]);
			Tag_No = ClsConvert.ToString(dr["TAG_NO", v]);
			Tag_Commission_Dt = ClsConvert.ToDateTimeNullable(dr["TAG_COMMISSION_DT", v]);
			Tag_Decommission_Dt = ClsConvert.ToDateTimeNullable(dr["TAG_DECOMMISSION_DT", v]);
			In_Gate_Dt = ClsConvert.ToDateTimeNullable(dr["IN_GATE_DT", v]);
			Delivery_Dt = ClsConvert.ToDateTimeNullable(dr["DELIVERY_DT", v]);
			Last_Cargo_Action_ID = ClsConvert.ToInt64Nullable(dr["LAST_CARGO_ACTION_ID", v]);
			Last_Logistic_Action_ID = ClsConvert.ToInt64Nullable(dr["LAST_LOGISTIC_ACTION_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Required_Dlvy_Dt = ClsConvert.ToDateTimeNullable(dr["REQUIRED_DLVY_DT", v]);
			Rcvr_Dodaac = ClsConvert.ToString(dr["RCVR_DODAAC", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR", v]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT", v]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS", v]);
			Delivery_Txt = ClsConvert.ToString(dr["DELIVERY_TXT", v]);
			Cargo_Notes_Txt = ClsConvert.ToString(dr["CARGO_NOTES_TXT", v]);
			Seal1 = ClsConvert.ToString(dr["SEAL1", v]);
			Seal2 = ClsConvert.ToString(dr["SEAL2", v]);
			Seal3 = ClsConvert.ToString(dr["SEAL3", v]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD", v]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_MOVE_ID"] = ClsConvert.ToDbObject(Cargo_Move_ID);
			dr["VENDOR_MOVE_ID"] = ClsConvert.ToDbObject(Vendor_Move_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["CONVEYANCE_ID"] = ClsConvert.ToDbObject(Conveyance_ID);
			dr["CUSTOMS_SUBMITTED_DT"] = ClsConvert.ToDbObject(Customs_Submitted_Dt);
			dr["CUSTOMS_CLEARANCE_DT"] = ClsConvert.ToDbObject(Customs_Clearance_Dt);
			dr["MOVE_START_DT"] = ClsConvert.ToDbObject(Move_Start_Dt);
			dr["MOVE_END_DT"] = ClsConvert.ToDbObject(Move_End_Dt);
			dr["TAG_NO"] = ClsConvert.ToDbObject(Tag_No);
			dr["TAG_COMMISSION_DT"] = ClsConvert.ToDbObject(Tag_Commission_Dt);
			dr["TAG_DECOMMISSION_DT"] = ClsConvert.ToDbObject(Tag_Decommission_Dt);
			dr["IN_GATE_DT"] = ClsConvert.ToDbObject(In_Gate_Dt);
			dr["DELIVERY_DT"] = ClsConvert.ToDbObject(Delivery_Dt);
			dr["LAST_CARGO_ACTION_ID"] = ClsConvert.ToDbObject(Last_Cargo_Action_ID);
			dr["LAST_LOGISTIC_ACTION_ID"] = ClsConvert.ToDbObject(Last_Logistic_Action_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["CUSTOMER_REF"] = ClsConvert.ToDbObject(Customer_Ref);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["REQUIRED_DLVY_DT"] = ClsConvert.ToDbObject(Required_Dlvy_Dt);
			dr["RCVR_DODAAC"] = ClsConvert.ToDbObject(Rcvr_Dodaac);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["CARGO_DSC"] = ClsConvert.ToDbObject(Cargo_Dsc);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["DIM_WEIGHT_NBR"] = ClsConvert.ToDbObject(Dim_Weight_Nbr);
			dr["CUBE_FT"] = ClsConvert.ToDbObject(Cube_Ft);
			dr["M_TONS"] = ClsConvert.ToDbObject(M_Tons);
			dr["DELIVERY_TXT"] = ClsConvert.ToDbObject(Delivery_Txt);
			dr["CARGO_NOTES_TXT"] = ClsConvert.ToDbObject(Cargo_Notes_Txt);
			dr["SEAL1"] = ClsConvert.ToDbObject(Seal1);
			dr["SEAL2"] = ClsConvert.ToDbObject(Seal2);
			dr["SEAL3"] = ClsConvert.ToDbObject(Seal3);
			dr["MAKE_CD"] = ClsConvert.ToDbObject(Make_Cd);
			dr["MODEL_CD"] = ClsConvert.ToDbObject(Model_Cd);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
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

		public static ClsCargoMove GetUsingKey(Int64 Cargo_Move_ID)
		{
			object[] vals = new object[] {Cargo_Move_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoMove(dr);
		}
		public static DataTable GetAll(Int64? Last_Logistic_Action_ID, string Vessel_Cd,
			string Plor_Location_Cd, string Pol_Location_Cd,
			string Pod_Location_Cd, string Plod_Location_Cd,
			string Move_Type_Cd, Int64? Last_Cargo_Action_ID,
			Int64? Conveyance_ID, Int64? Vendor_Move_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Last_Logistic_Action_ID != null && Last_Logistic_Action_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LAST_LOGISTIC_ACTION_ID", Last_Logistic_Action_ID));
				sb.Append(" WHERE T_CARGO_MOVE.LAST_LOGISTIC_ACTION_ID=@LAST_LOGISTIC_ACTION_ID");
			}
			if( string.IsNullOrEmpty(Vessel_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VESSEL_CD", Vessel_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.VESSEL_CD=@VESSEL_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Plor_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOR_LOCATION_CD", Plor_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.PLOR_LOCATION_CD=@PLOR_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pol_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POL_LOCATION_CD", Pol_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.POL_LOCATION_CD=@POL_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POD_LOCATION_CD", Pod_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.POD_LOCATION_CD=@POD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Plod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOD_LOCATION_CD", Plod_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.PLOD_LOCATION_CD=@PLOD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Move_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@MOVE_TYPE_CD", Move_Type_Cd));
				sb.AppendFormat(" {0} T_CARGO_MOVE.MOVE_TYPE_CD=@MOVE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Last_Cargo_Action_ID != null && Last_Cargo_Action_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LAST_CARGO_ACTION_ID", Last_Cargo_Action_ID));
				sb.AppendFormat(" {0} T_CARGO_MOVE.LAST_CARGO_ACTION_ID=@LAST_CARGO_ACTION_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Conveyance_ID != null && Conveyance_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONVEYANCE_ID", Conveyance_ID));
				sb.AppendFormat(" {0} T_CARGO_MOVE.CONVEYANCE_ID=@CONVEYANCE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Vendor_Move_ID != null && Vendor_Move_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@VENDOR_MOVE_ID", Vendor_Move_ID));
				sb.AppendFormat(" {0} T_CARGO_MOVE.VENDOR_MOVE_ID=@VENDOR_MOVE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}