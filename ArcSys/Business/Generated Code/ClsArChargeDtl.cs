using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsArChargeDtl : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_AR_CHARGE_DTL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "AR_CHARGE_DTL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_AR_CHARGE_DTL 
				INNER JOIN T_AR_CHARGE
				ON T_AR_CHARGE_DTL.AR_CHARGE_ID=T_AR_CHARGE.AR_CHARGE_ID
				LEFT OUTER JOIN R_VESSEL
				ON T_AR_CHARGE_DTL.VESSEL_CD=R_VESSEL.VESSEL_CD
				LEFT OUTER JOIN R_LOCATION
				ON T_AR_CHARGE_DTL.PLOR_LOCATION_CD=R_LOCATION.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc2
				ON T_AR_CHARGE_DTL.POL_LOCATION_CD=r_loc2.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc3
				ON T_AR_CHARGE_DTL.POD_LOCATION_CD=r_loc3.LOCATION_CD
				LEFT OUTER JOIN R_LOCATION r_loc4
				ON T_AR_CHARGE_DTL.PLOD_LOCATION_CD=r_loc4.LOCATION_CD
				LEFT OUTER JOIN R_MOVE_TYPE
				ON T_AR_CHARGE_DTL.MOVE_TYPE_CD=R_MOVE_TYPE.MOVE_TYPE_CD
				INNER JOIN T_CARGO_ACTIVITY
				ON T_AR_CHARGE_DTL.CARGO_ACTIVITY_ID=T_CARGO_ACTIVITY.CARGO_ACTIVITY_ID ";

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

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ar_Charge_Dtl_ID;
		protected Int64? _Ar_Charge_ID;
		protected Int64? _Cargo_Activity_ID;
		protected decimal? _Activity_Amt;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected decimal? _Activity_Unit_Qty;
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

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ar_Charge_Dtl_ID
		{
			get { return _Ar_Charge_Dtl_ID; }
			set
			{
				if( _Ar_Charge_Dtl_ID == value ) return;
		
				_Ar_Charge_Dtl_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Charge_Dtl_ID");
			}
		}
		public Int64? Ar_Charge_ID
		{
			get { return _Ar_Charge_ID; }
			set
			{
				if( _Ar_Charge_ID == value ) return;
		
				_Ar_Charge_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Charge_ID");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsArCharge _Ar_Charge;
		protected ClsVessel _Vessel;
		protected ClsLocation _Plor_Location;
		protected ClsLocation _Pol_Location;
		protected ClsLocation _Pod_Location;
		protected ClsLocation _Plod_Location;
		protected ClsMoveType _Move_Type;
		protected ClsCargoActivity _Cargo_Activity;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsArCharge Ar_Charge
		{
			get
			{
				if( Ar_Charge_ID == null )
					_Ar_Charge = null;
				else if( _Ar_Charge == null ||
					_Ar_Charge.Ar_Charge_ID != Ar_Charge_ID )
					_Ar_Charge = ClsArCharge.GetUsingKey(Ar_Charge_ID.Value);
				return _Ar_Charge;
			}
			set
			{
				if( _Ar_Charge == value ) return;
		
				_Ar_Charge = value;
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

		public ClsArChargeDtl() : base() {}
		public ClsArChargeDtl(DataRow dr) : base(dr) {}
		public ClsArChargeDtl(ClsArChargeDtl src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ar_Charge_Dtl_ID = null;
			Ar_Charge_ID = null;
			Cargo_Activity_ID = null;
			Activity_Amt = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Activity_Unit_Qty = null;
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
		}

		public void CopyFrom(ClsArChargeDtl src)
		{
			Ar_Charge_Dtl_ID = src._Ar_Charge_Dtl_ID;
			Ar_Charge_ID = src._Ar_Charge_ID;
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Activity_Amt = src._Activity_Amt;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Activity_Unit_Qty = src._Activity_Unit_Qty;
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
		}

		public override bool ReloadFromDB()
		{
			ClsArChargeDtl tmp = ClsArChargeDtl.GetUsingKey(Ar_Charge_Dtl_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Ar_Charge = null;
			_Vessel = null;
			_Plor_Location = null;
			_Pol_Location = null;
			_Pod_Location = null;
			_Plod_Location = null;
			_Move_Type = null;
			_Cargo_Activity = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[29];

			p[0] = Connection.GetParameter
				("@AR_CHARGE_ID", Ar_Charge_ID);
			p[1] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[2] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[3] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[6] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[7] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[8] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[9] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[10] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[11] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[12] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[13] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[14] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[15] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[16] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[17] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[18] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[19] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[20] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[21] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[22] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[23] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[24] = Connection.GetParameter
				("@AR_CHARGE_DTL_ID", Ar_Charge_Dtl_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[25] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[26] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[27] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[28] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_AR_CHARGE_DTL
					(AR_CHARGE_DTL_ID, AR_CHARGE_ID, CARGO_ACTIVITY_ID,
					ACTIVITY_AMT, ACTIVITY_UNIT_QTY, BOOKING_NO,
					CUSTOMER_REF, VESSEL_CD, VOYAGE_NO,
					SAIL_DT, PLOR_LOCATION_CD, POL_LOCATION_CD,
					POD_LOCATION_CD, PLOD_LOCATION_CD, SERIAL_NO,
					MOVE_TYPE_CD, CONTAINER_NO, CARGO_KEY,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, DIM_WEIGHT_NBR, CUBE_FT,
					M_TONS)
				VALUES
					(AR_CHARGE_DTL_ID_SEQ.NEXTVAL, @AR_CHARGE_ID, @CARGO_ACTIVITY_ID,
					@ACTIVITY_AMT, @ACTIVITY_UNIT_QTY, @BOOKING_NO,
					@CUSTOMER_REF, @VESSEL_CD, @VOYAGE_NO,
					@SAIL_DT, @PLOR_LOCATION_CD, @POL_LOCATION_CD,
					@POD_LOCATION_CD, @PLOD_LOCATION_CD, @SERIAL_NO,
					@MOVE_TYPE_CD, @CONTAINER_NO, @CARGO_KEY,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @DIM_WEIGHT_NBR, @CUBE_FT,
					@M_TONS)
				RETURNING
					AR_CHARGE_DTL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@AR_CHARGE_DTL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ar_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(p[24].Value);
			Create_User = ClsConvert.ToString(p[25].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[26].Value);
			Modify_User = ClsConvert.ToString(p[27].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[28].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[27];

			p[0] = Connection.GetParameter
				("@AR_CHARGE_ID", Ar_Charge_ID);
			p[1] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[2] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
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
				("@AR_CHARGE_DTL_ID", Ar_Charge_Dtl_ID);
			p[26] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_AR_CHARGE_DTL SET
					AR_CHARGE_ID = @AR_CHARGE_ID,
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID,
					ACTIVITY_AMT = @ACTIVITY_AMT,
					MODIFY_DT = @MODIFY_DT,
					ACTIVITY_UNIT_QTY = @ACTIVITY_UNIT_QTY,
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
					M_TONS = @M_TONS
				WHERE
					AR_CHARGE_DTL_ID = @AR_CHARGE_DTL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[26].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@AR_CHARGE_DTL_ID", Ar_Charge_Dtl_ID);

			const string sql = @"
				DELETE FROM T_AR_CHARGE_DTL WHERE
				AR_CHARGE_DTL_ID=@AR_CHARGE_DTL_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ar_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_DTL_ID"]);
			Ar_Charge_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_ID"]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY"]);
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
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ar_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_DTL_ID", v]);
			Ar_Charge_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_ID", v]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY", v]);
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
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["AR_CHARGE_DTL_ID"] = ClsConvert.ToDbObject(Ar_Charge_Dtl_ID);
			dr["AR_CHARGE_ID"] = ClsConvert.ToDbObject(Ar_Charge_ID);
			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["ACTIVITY_AMT"] = ClsConvert.ToDbObject(Activity_Amt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVITY_UNIT_QTY"] = ClsConvert.ToDbObject(Activity_Unit_Qty);
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

		public static ClsArChargeDtl GetUsingKey(Int64 Ar_Charge_Dtl_ID)
		{
			object[] vals = new object[] {Ar_Charge_Dtl_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsArChargeDtl(dr);
		}
		public static DataTable GetAll(Int64? Ar_Charge_ID, string Vessel_Cd,
			string Plor_Location_Cd, string Pol_Location_Cd,
			string Pod_Location_Cd, string Plod_Location_Cd,
			string Move_Type_Cd, Int64? Cargo_Activity_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Ar_Charge_ID != null && Ar_Charge_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AR_CHARGE_ID", Ar_Charge_ID));
				sb.Append(" WHERE T_AR_CHARGE_DTL.AR_CHARGE_ID=@AR_CHARGE_ID");
			}
			if( string.IsNullOrEmpty(Vessel_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VESSEL_CD", Vessel_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.VESSEL_CD=@VESSEL_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Plor_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOR_LOCATION_CD", Plor_Location_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.PLOR_LOCATION_CD=@PLOR_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pol_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POL_LOCATION_CD", Pol_Location_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.POL_LOCATION_CD=@POL_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Pod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@POD_LOCATION_CD", Pod_Location_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.POD_LOCATION_CD=@POD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Plod_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PLOD_LOCATION_CD", Plod_Location_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.PLOD_LOCATION_CD=@PLOD_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Move_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@MOVE_TYPE_CD", Move_Type_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.MOVE_TYPE_CD=@MOVE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Cargo_Activity_ID != null && Cargo_Activity_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_ACTIVITY_ID", Cargo_Activity_ID));
				sb.AppendFormat(" {0} T_AR_CHARGE_DTL.CARGO_ACTIVITY_ID=@CARGO_ACTIVITY_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}