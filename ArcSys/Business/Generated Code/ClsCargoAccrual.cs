using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoAccrual : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_ACCRUAL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_ACCRUAL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO_ACCRUAL 
				LEFT OUTER JOIN R_LOCATION
				ON T_CARGO_ACCRUAL.PLOR_LOCATION_CD=R_LOCATION.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc2
				ON T_CARGO_ACCRUAL.POL_LOCATION_CD=r_loc2.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc3
				ON T_CARGO_ACCRUAL.POD_LOCATION_CD=r_loc3.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc4
				ON T_CARGO_ACCRUAL.PLOD_LOCATION_CD=r_loc4.LOCATION_CD
				LEFT OUTER JOIN R_MOVE_TYPE
				ON T_CARGO_ACCRUAL.MOVE_TYPE_CD=R_MOVE_TYPE.MOVE_TYPE_CD
				LEFT OUTER JOIN R_LOCATION r_loc5
				ON T_CARGO_ACCRUAL.EST_ORIG_LOCATION_CD=r_loc5.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc6
				ON T_CARGO_ACCRUAL.EST_DEST_LOCATION_CD=r_loc6.LOCATION_CD
				LEFT OUTER JOIN R_CHARGE_TYPE
				ON T_CARGO_ACCRUAL.CHARGE_TYPE_CD=R_CHARGE_TYPE.CHARGE_TYPE_CD
				LEFT OUTER JOIN R_LEVEL_UNIT
				ON T_CARGO_ACCRUAL.LEVEL_UNIT_ID=R_LEVEL_UNIT.LEVEL_UNIT_ID
				LEFT OUTER JOIN R_VENDOR
				ON T_CARGO_ACCRUAL.VENDOR_CD=R_VENDOR.VENDOR_CD
				LEFT OUTER JOIN T_ESTIMATE_CHARGE
				ON T_CARGO_ACCRUAL.ESTIMATE_CHARGE_ID=T_ESTIMATE_CHARGE.ESTIMATE_CHARGE_ID
				LEFT OUTER JOIN R_VESSEL
				ON T_CARGO_ACCRUAL.VESSEL_CD=R_VESSEL.VESSEL_CD
				LEFT OUTER JOIN T_CARGO_ACTIVITY
				ON T_CARGO_ACCRUAL.CARGO_ACTIVITY_ID=T_CARGO_ACTIVITY.CARGO_ACTIVITY_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Booking_NoMax = 25;
		public const int Customer_RefMax = 25;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Plor_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Plod_Location_CdMax = 10;
		public const int Serial_NoMax = 50;
		public const int Move_Type_CdMax = 10;
		public const int Container_NoMax = 20;
		public const int Cargo_KeyMax = 30;
		public const int Estimate_NoMax = 10;
		public const int Est_Orig_Location_CdMax = 10;
		public const int Est_Dest_Location_CdMax = 10;
		public const int Charge_Type_CdMax = 10;
		public const int Vendor_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Accrual_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected decimal? _Activity_Amt;
		protected decimal? _Activity_Unit_Qty;
		protected DateTime? _Submitted_Dt;
		protected Int64? _Estimate_Charge_ID;
		protected Int64? _Cargo_Activity_ID;
		protected string _Booking_No;
		protected string _Customer_Ref;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected DateTime? _Sail_Dt;
		protected string _Plor_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Plod_Location_Cd;
		protected string _Serial_No;
		protected string _Move_Type_Cd;
		protected string _Container_No;
		protected string _Cargo_Key;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Dim_Weight_Nbr;
		protected decimal? _Cube_Ft;
		protected decimal? _M_Tons;
		protected string _Estimate_No;
		protected string _Est_Orig_Location_Cd;
		protected string _Est_Dest_Location_Cd;
		protected string _Charge_Type_Cd;
		protected Int64? _Level_Unit_ID;
		protected decimal? _Rate_Amt;
		protected Int64? _Level_Count;
		protected decimal? _Unit_Qty;
		protected decimal? _Total_Amt;
		protected Int64? _Tcn_Count;
		protected string _Vendor_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_Accrual_ID
		{
			get { return _Cargo_Accrual_ID; }
			set
			{
				if( _Cargo_Accrual_ID == value ) return;
		
				_Cargo_Accrual_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Accrual_ID");
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
		public decimal? Activity_Amt
		{
			get { return _Activity_Amt; }
			set
			{
				if( _Activity_Amt == value ) return;
		
				_Activity_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Amt");
			}
		}
		public decimal? Activity_Unit_Qty
		{
			get { return _Activity_Unit_Qty; }
			set
			{
				if( _Activity_Unit_Qty == value ) return;
		
				_Activity_Unit_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Unit_Qty");
			}
		}
		public DateTime? Submitted_Dt
		{
			get { return _Submitted_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Submitted_Dt == val ) return;
		
				_Submitted_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Submitted_Dt");
			}
		}
		public Int64? Estimate_Charge_ID
		{
			get { return _Estimate_Charge_ID; }
			set
			{
				if( _Estimate_Charge_ID == value ) return;
		
				_Estimate_Charge_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_Charge_ID");
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
		public string Estimate_No
		{
			get { return _Estimate_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Estimate_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Estimate_NoMax )
					_Estimate_No = val.Substring(0, (int)Estimate_NoMax);
				else
					_Estimate_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_No");
			}
		}
		public string Est_Orig_Location_Cd
		{
			get { return _Est_Orig_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Est_Orig_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Est_Orig_Location_CdMax )
					_Est_Orig_Location_Cd = val.Substring(0, (int)Est_Orig_Location_CdMax);
				else
					_Est_Orig_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Est_Orig_Location_Cd");
			}
		}
		public string Est_Dest_Location_Cd
		{
			get { return _Est_Dest_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Est_Dest_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Est_Dest_Location_CdMax )
					_Est_Dest_Location_Cd = val.Substring(0, (int)Est_Dest_Location_CdMax);
				else
					_Est_Dest_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Est_Dest_Location_Cd");
			}
		}
		public string Charge_Type_Cd
		{
			get { return _Charge_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Type_CdMax )
					_Charge_Type_Cd = val.Substring(0, (int)Charge_Type_CdMax);
				else
					_Charge_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Type_Cd");
			}
		}
		public Int64? Level_Unit_ID
		{
			get { return _Level_Unit_ID; }
			set
			{
				if( _Level_Unit_ID == value ) return;
		
				_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Unit_ID");
			}
		}
		public decimal? Rate_Amt
		{
			get { return _Rate_Amt; }
			set
			{
				if( _Rate_Amt == value ) return;
		
				_Rate_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Amt");
			}
		}
		public Int64? Level_Count
		{
			get { return _Level_Count; }
			set
			{
				if( _Level_Count == value ) return;
		
				_Level_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Count");
			}
		}
		public decimal? Unit_Qty
		{
			get { return _Unit_Qty; }
			set
			{
				if( _Unit_Qty == value ) return;
		
				_Unit_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Qty");
			}
		}
		public decimal? Total_Amt
		{
			get { return _Total_Amt; }
			set
			{
				if( _Total_Amt == value ) return;
		
				_Total_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Total_Amt");
			}
		}
		public Int64? Tcn_Count
		{
			get { return _Tcn_Count; }
			set
			{
				if( _Tcn_Count == value ) return;
		
				_Tcn_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Tcn_Count");
			}
		}
		public string Vendor_Cd
		{
			get { return _Vendor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_CdMax )
					_Vendor_Cd = val.Substring(0, (int)Vendor_CdMax);
				else
					_Vendor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsLocation _Plor_Location;
		protected ClsLocation _Pol_Location;
		protected ClsLocation _Pod_Location;
		protected ClsLocation _Plod_Location;
		protected ClsMoveType _Move_Type;
		protected ClsLocation _Est_Orig_Location;
		protected ClsLocation _Est_Dest_Location;
		protected ClsChargeType _Charge_Type;
		protected ClsLevelUnit _Level_Unit;
		protected ClsVendor _Vendor;
		protected ClsEstimateCharge _Estimate_Charge;
		protected ClsVessel _Vessel;
		protected ClsCargoActivity _Cargo_Activity;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

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
		public ClsLocation Est_Orig_Location
		{
			get
			{
				if( Est_Orig_Location_Cd == null )
					_Est_Orig_Location = null;
				else if( _Est_Orig_Location == null ||
					_Est_Orig_Location.Location_Cd != Est_Orig_Location_Cd )
					_Est_Orig_Location = ClsLocation.GetUsingKey(Est_Orig_Location_Cd);
				return _Est_Orig_Location;
			}
			set
			{
				if( _Est_Orig_Location == value ) return;
		
				_Est_Orig_Location = value;
			}
		}
		public ClsLocation Est_Dest_Location
		{
			get
			{
				if( Est_Dest_Location_Cd == null )
					_Est_Dest_Location = null;
				else if( _Est_Dest_Location == null ||
					_Est_Dest_Location.Location_Cd != Est_Dest_Location_Cd )
					_Est_Dest_Location = ClsLocation.GetUsingKey(Est_Dest_Location_Cd);
				return _Est_Dest_Location;
			}
			set
			{
				if( _Est_Dest_Location == value ) return;
		
				_Est_Dest_Location = value;
			}
		}
		public ClsChargeType Charge_Type
		{
			get
			{
				if( Charge_Type_Cd == null )
					_Charge_Type = null;
				else if( _Charge_Type == null ||
					_Charge_Type.Charge_Type_Cd != Charge_Type_Cd )
					_Charge_Type = ClsChargeType.GetUsingKey(Charge_Type_Cd);
				return _Charge_Type;
			}
			set
			{
				if( _Charge_Type == value ) return;
		
				_Charge_Type = value;
			}
		}
		public ClsLevelUnit Level_Unit
		{
			get
			{
				if( Level_Unit_ID == null )
					_Level_Unit = null;
				else if( _Level_Unit == null ||
					_Level_Unit.Level_Unit_ID != Level_Unit_ID )
					_Level_Unit = ClsLevelUnit.GetUsingKey(Level_Unit_ID.Value);
				return _Level_Unit;
			}
			set
			{
				if( _Level_Unit == value ) return;
		
				_Level_Unit = value;
			}
		}
		public ClsVendor Vendor
		{
			get
			{
				if( Vendor_Cd == null )
					_Vendor = null;
				else if( _Vendor == null ||
					_Vendor.Vendor_Cd != Vendor_Cd )
					_Vendor = ClsVendor.GetUsingKey(Vendor_Cd);
				return _Vendor;
			}
			set
			{
				if( _Vendor == value ) return;
		
				_Vendor = value;
			}
		}
		public ClsEstimateCharge Estimate_Charge
		{
			get
			{
				if( Estimate_Charge_ID == null )
					_Estimate_Charge = null;
				else if( _Estimate_Charge == null ||
					_Estimate_Charge.Estimate_Charge_ID != Estimate_Charge_ID )
					_Estimate_Charge = ClsEstimateCharge.GetUsingKey(Estimate_Charge_ID.Value);
				return _Estimate_Charge;
			}
			set
			{
				if( _Estimate_Charge == value ) return;
		
				_Estimate_Charge = value;
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
		public ClsCargoActivity Cargo_Activity
		{
			get
			{
				if( Cargo_Activity_ID == null )
					_Cargo_Activity = null;
				else if( _Cargo_Activity == null ||
					_Cargo_Activity.Cargo_Activity_ID != Cargo_Activity_ID )
					_Cargo_Activity = ClsCargoActivity.GetUsingKey(Cargo_Activity_ID.Value);
				return _Cargo_Activity;
			}
			set
			{
				if( _Cargo_Activity == value ) return;
		
				_Cargo_Activity = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoAccrual() : base() {}
		public ClsCargoAccrual(DataRow dr) : base(dr) {}
		public ClsCargoAccrual(ClsCargoAccrual src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Accrual_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Activity_Amt = null;
			Activity_Unit_Qty = null;
			Submitted_Dt = null;
			Estimate_Charge_ID = null;
			Cargo_Activity_ID = null;
			Booking_No = null;
			Customer_Ref = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Sail_Dt = null;
			Plor_Location_Cd = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Plod_Location_Cd = null;
			Serial_No = null;
			Move_Type_Cd = null;
			Container_No = null;
			Cargo_Key = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Dim_Weight_Nbr = null;
			Cube_Ft = null;
			M_Tons = null;
			Estimate_No = null;
			Est_Orig_Location_Cd = null;
			Est_Dest_Location_Cd = null;
			Charge_Type_Cd = null;
			Level_Unit_ID = null;
			Rate_Amt = null;
			Level_Count = null;
			Unit_Qty = null;
			Total_Amt = null;
			Tcn_Count = null;
			Vendor_Cd = null;
		}

		public void CopyFrom(ClsCargoAccrual src)
		{
			Cargo_Accrual_ID = src._Cargo_Accrual_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Activity_Amt = src._Activity_Amt;
			Activity_Unit_Qty = src._Activity_Unit_Qty;
			Submitted_Dt = src._Submitted_Dt;
			Estimate_Charge_ID = src._Estimate_Charge_ID;
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Booking_No = src._Booking_No;
			Customer_Ref = src._Customer_Ref;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Sail_Dt = src._Sail_Dt;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Serial_No = src._Serial_No;
			Move_Type_Cd = src._Move_Type_Cd;
			Container_No = src._Container_No;
			Cargo_Key = src._Cargo_Key;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Dim_Weight_Nbr = src._Dim_Weight_Nbr;
			Cube_Ft = src._Cube_Ft;
			M_Tons = src._M_Tons;
			Estimate_No = src._Estimate_No;
			Est_Orig_Location_Cd = src._Est_Orig_Location_Cd;
			Est_Dest_Location_Cd = src._Est_Dest_Location_Cd;
			Charge_Type_Cd = src._Charge_Type_Cd;
			Level_Unit_ID = src._Level_Unit_ID;
			Rate_Amt = src._Rate_Amt;
			Level_Count = src._Level_Count;
			Unit_Qty = src._Unit_Qty;
			Total_Amt = src._Total_Amt;
			Tcn_Count = src._Tcn_Count;
			Vendor_Cd = src._Vendor_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoAccrual tmp = ClsCargoAccrual.GetUsingKey(Cargo_Accrual_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Plor_Location = null;
			_Pol_Location = null;
			_Pod_Location = null;
			_Plod_Location = null;
			_Move_Type = null;
			_Est_Orig_Location = null;
			_Est_Dest_Location = null;
			_Charge_Type = null;
			_Level_Unit = null;
			_Vendor = null;
			_Estimate_Charge = null;
			_Vessel = null;
			_Cargo_Activity = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[41];

			p[0] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[1] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
			p[2] = Connection.GetParameter
				("@SUBMITTED_DT", Submitted_Dt);
			p[3] = Connection.GetParameter
				("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID);
			p[4] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[5] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[6] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[9] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[10] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[11] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[12] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[13] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[14] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[15] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[16] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[17] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[18] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[19] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[20] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[21] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[22] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[23] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[24] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[25] = Connection.GetParameter
				("@ESTIMATE_NO", Estimate_No);
			p[26] = Connection.GetParameter
				("@EST_ORIG_LOCATION_CD", Est_Orig_Location_Cd);
			p[27] = Connection.GetParameter
				("@EST_DEST_LOCATION_CD", Est_Dest_Location_Cd);
			p[28] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[29] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[30] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[31] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[32] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[33] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[34] = Connection.GetParameter
				("@TCN_COUNT", Tcn_Count);
			p[35] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[36] = Connection.GetParameter
				("@CARGO_ACCRUAL_ID", Cargo_Accrual_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[37] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[38] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[39] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[40] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_ACCRUAL
					(CARGO_ACCRUAL_ID, ACTIVITY_AMT, ACTIVITY_UNIT_QTY,
					SUBMITTED_DT, ESTIMATE_CHARGE_ID, CARGO_ACTIVITY_ID,
					BOOKING_NO, CUSTOMER_REF, VESSEL_CD,
					VOYAGE_NO, SAIL_DT, PLOR_LOCATION_CD,
					POL_LOCATION_CD, POD_LOCATION_CD, PLOD_LOCATION_CD,
					SERIAL_NO, MOVE_TYPE_CD, CONTAINER_NO,
					CARGO_KEY, LENGTH_NBR, WIDTH_NBR,
					HEIGHT_NBR, WEIGHT_NBR, DIM_WEIGHT_NBR,
					CUBE_FT, M_TONS, ESTIMATE_NO,
					EST_ORIG_LOCATION_CD, EST_DEST_LOCATION_CD, CHARGE_TYPE_CD,
					LEVEL_UNIT_ID, RATE_AMT, LEVEL_COUNT,
					UNIT_QTY, TOTAL_AMT, TCN_COUNT,
					VENDOR_CD)
				VALUES
					(CARGO_ACCRUAL_ID_SEQ.NEXTVAL, @ACTIVITY_AMT, @ACTIVITY_UNIT_QTY,
					@SUBMITTED_DT, @ESTIMATE_CHARGE_ID, @CARGO_ACTIVITY_ID,
					@BOOKING_NO, @CUSTOMER_REF, @VESSEL_CD,
					@VOYAGE_NO, @SAIL_DT, @PLOR_LOCATION_CD,
					@POL_LOCATION_CD, @POD_LOCATION_CD, @PLOD_LOCATION_CD,
					@SERIAL_NO, @MOVE_TYPE_CD, @CONTAINER_NO,
					@CARGO_KEY, @LENGTH_NBR, @WIDTH_NBR,
					@HEIGHT_NBR, @WEIGHT_NBR, @DIM_WEIGHT_NBR,
					@CUBE_FT, @M_TONS, @ESTIMATE_NO,
					@EST_ORIG_LOCATION_CD, @EST_DEST_LOCATION_CD, @CHARGE_TYPE_CD,
					@LEVEL_UNIT_ID, @RATE_AMT, @LEVEL_COUNT,
					@UNIT_QTY, @TOTAL_AMT, @TCN_COUNT,
					@VENDOR_CD)
				RETURNING
					CARGO_ACCRUAL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_ACCRUAL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Accrual_ID = ClsConvert.ToInt64Nullable(p[36].Value);
			Create_User = ClsConvert.ToString(p[37].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[38].Value);
			Modify_User = ClsConvert.ToString(p[39].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[40].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[39];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[2] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
			p[3] = Connection.GetParameter
				("@SUBMITTED_DT", Submitted_Dt);
			p[4] = Connection.GetParameter
				("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID);
			p[5] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[6] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[7] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[8] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[9] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[10] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[11] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[12] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[13] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[14] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[15] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[16] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[17] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[18] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[19] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[20] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[21] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[22] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[23] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[24] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[25] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[26] = Connection.GetParameter
				("@ESTIMATE_NO", Estimate_No);
			p[27] = Connection.GetParameter
				("@EST_ORIG_LOCATION_CD", Est_Orig_Location_Cd);
			p[28] = Connection.GetParameter
				("@EST_DEST_LOCATION_CD", Est_Dest_Location_Cd);
			p[29] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[30] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[31] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[32] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[33] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[34] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[35] = Connection.GetParameter
				("@TCN_COUNT", Tcn_Count);
			p[36] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[37] = Connection.GetParameter
				("@CARGO_ACCRUAL_ID", Cargo_Accrual_ID);
			p[38] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_ACCRUAL SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVITY_AMT = @ACTIVITY_AMT,
					ACTIVITY_UNIT_QTY = @ACTIVITY_UNIT_QTY,
					SUBMITTED_DT = @SUBMITTED_DT,
					ESTIMATE_CHARGE_ID = @ESTIMATE_CHARGE_ID,
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID,
					BOOKING_NO = @BOOKING_NO,
					CUSTOMER_REF = @CUSTOMER_REF,
					VESSEL_CD = @VESSEL_CD,
					VOYAGE_NO = @VOYAGE_NO,
					SAIL_DT = @SAIL_DT,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					SERIAL_NO = @SERIAL_NO,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					CONTAINER_NO = @CONTAINER_NO,
					CARGO_KEY = @CARGO_KEY,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					DIM_WEIGHT_NBR = @DIM_WEIGHT_NBR,
					CUBE_FT = @CUBE_FT,
					M_TONS = @M_TONS,
					ESTIMATE_NO = @ESTIMATE_NO,
					EST_ORIG_LOCATION_CD = @EST_ORIG_LOCATION_CD,
					EST_DEST_LOCATION_CD = @EST_DEST_LOCATION_CD,
					CHARGE_TYPE_CD = @CHARGE_TYPE_CD,
					LEVEL_UNIT_ID = @LEVEL_UNIT_ID,
					RATE_AMT = @RATE_AMT,
					LEVEL_COUNT = @LEVEL_COUNT,
					UNIT_QTY = @UNIT_QTY,
					TOTAL_AMT = @TOTAL_AMT,
					TCN_COUNT = @TCN_COUNT,
					VENDOR_CD = @VENDOR_CD
				WHERE
					CARGO_ACCRUAL_ID = @CARGO_ACCRUAL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[38].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_ACCRUAL_ID", Cargo_Accrual_ID);

			const string sql = @"
				DELETE FROM T_CARGO_ACCRUAL WHERE
				CARGO_ACCRUAL_ID=@CARGO_ACCRUAL_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Accrual_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACCRUAL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT"]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY"]);
			Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["SUBMITTED_DT"]);
			Estimate_Charge_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_CHARGE_ID"]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR"]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT"]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS"]);
			Estimate_No = ClsConvert.ToString(dr["ESTIMATE_NO"]);
			Est_Orig_Location_Cd = ClsConvert.ToString(dr["EST_ORIG_LOCATION_CD"]);
			Est_Dest_Location_Cd = ClsConvert.ToString(dr["EST_DEST_LOCATION_CD"]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD"]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT"]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY"]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT"]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Accrual_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACCRUAL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT", v]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY", v]);
			Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["SUBMITTED_DT", v]);
			Estimate_Charge_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_CHARGE_ID", v]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR", v]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT", v]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS", v]);
			Estimate_No = ClsConvert.ToString(dr["ESTIMATE_NO", v]);
			Est_Orig_Location_Cd = ClsConvert.ToString(dr["EST_ORIG_LOCATION_CD", v]);
			Est_Dest_Location_Cd = ClsConvert.ToString(dr["EST_DEST_LOCATION_CD", v]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD", v]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT", v]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY", v]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT", v]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_ACCRUAL_ID"] = ClsConvert.ToDbObject(Cargo_Accrual_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVITY_AMT"] = ClsConvert.ToDbObject(Activity_Amt);
			dr["ACTIVITY_UNIT_QTY"] = ClsConvert.ToDbObject(Activity_Unit_Qty);
			dr["SUBMITTED_DT"] = ClsConvert.ToDbObject(Submitted_Dt);
			dr["ESTIMATE_CHARGE_ID"] = ClsConvert.ToDbObject(Estimate_Charge_ID);
			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["CUSTOMER_REF"] = ClsConvert.ToDbObject(Customer_Ref);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["DIM_WEIGHT_NBR"] = ClsConvert.ToDbObject(Dim_Weight_Nbr);
			dr["CUBE_FT"] = ClsConvert.ToDbObject(Cube_Ft);
			dr["M_TONS"] = ClsConvert.ToDbObject(M_Tons);
			dr["ESTIMATE_NO"] = ClsConvert.ToDbObject(Estimate_No);
			dr["EST_ORIG_LOCATION_CD"] = ClsConvert.ToDbObject(Est_Orig_Location_Cd);
			dr["EST_DEST_LOCATION_CD"] = ClsConvert.ToDbObject(Est_Dest_Location_Cd);
			dr["CHARGE_TYPE_CD"] = ClsConvert.ToDbObject(Charge_Type_Cd);
			dr["LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Level_Unit_ID);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["LEVEL_COUNT"] = ClsConvert.ToDbObject(Level_Count);
			dr["UNIT_QTY"] = ClsConvert.ToDbObject(Unit_Qty);
			dr["TOTAL_AMT"] = ClsConvert.ToDbObject(Total_Amt);
			dr["TCN_COUNT"] = ClsConvert.ToDbObject(Tcn_Count);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
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

		public static ClsCargoAccrual GetUsingKey(Int64 Cargo_Accrual_ID)
		{
			object[] vals = new object[] {Cargo_Accrual_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoAccrual(dr);
		}
		public static DataTable GetAll(string Plor_Location_Cd, string Pol_Location_Cd,
			string Pod_Location_Cd, string Plod_Location_Cd,
			string Move_Type_Cd, string Est_Orig_Location_Cd,
			string Est_Dest_Location_Cd, string Charge_Type_Cd,
			Int64? Level_Unit_ID, string Vendor_Cd,
			Int64? Estimate_Charge_ID, string Vessel_Cd,
			Int64? Cargo_Activity_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Plor_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOR_LOCATION_CD", Plor_Location_Cd));
				sb.Append(" WHERE T_CARGO_ACCRUAL.PLOR_LOCATION_CD=@PLOR_LOCATION_CD");
			}
			if( string.IsNullOrEmpty(Pol_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POL_LOCATION_CD", Pol_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.POL_LOCATION_CD=@POL_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POD_LOCATION_CD", Pod_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.POD_LOCATION_CD=@POD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Plod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOD_LOCATION_CD", Plod_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.PLOD_LOCATION_CD=@PLOD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Move_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@MOVE_TYPE_CD", Move_Type_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.MOVE_TYPE_CD=@MOVE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Est_Orig_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@EST_ORIG_LOCATION_CD", Est_Orig_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.EST_ORIG_LOCATION_CD=@EST_ORIG_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Est_Dest_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@EST_DEST_LOCATION_CD", Est_Dest_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.EST_DEST_LOCATION_CD=@EST_DEST_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Charge_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CHARGE_TYPE_CD", Charge_Type_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.CHARGE_TYPE_CD=@CHARGE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Level_Unit_ID != null && Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LEVEL_UNIT_ID", Level_Unit_ID));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.LEVEL_UNIT_ID=@LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.VENDOR_CD=@VENDOR_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Estimate_Charge_ID != null && Estimate_Charge_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.ESTIMATE_CHARGE_ID=@ESTIMATE_CHARGE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vessel_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VESSEL_CD", Vessel_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.VESSEL_CD=@VESSEL_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Cargo_Activity_ID != null && Cargo_Activity_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_ACTIVITY_ID", Cargo_Activity_ID));
				sb.AppendFormat(" {0} T_CARGO_ACCRUAL.CARGO_ACTIVITY_ID=@CARGO_ACTIVITY_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}