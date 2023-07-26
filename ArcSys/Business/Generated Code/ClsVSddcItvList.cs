using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVSddcItvList : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_SDDC_ITV_LIST";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_SDDC_ITV_LIST";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 25;
		public const int Booking_StatusMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pol_BerthMax = 20;
		public const int Pod_Location_CdMax = 10;
		public const int Pod_BerthMax = 20;
		public const int Customer_RefMax = 50;
		public const int Customer_CdMax = 10;
		public const int Customer_NmMax = 100;
		public const int Move_Type_CdMax = 10;
		public const int Serial_NoMax = 50;
		public const int Cargo_StatusMax = 10;
		public const int Depart_FlgMax = 1;
		public const int Arrive_FlgMax = 1;
		public const int Acms_Status_CdMax = 2;
		public const int Acms_Voyage_NoMax = 10;
		public const int Acms_Booking_NoMax = 30;
		public const int Acms_Booking_SubMax = 5;
		public const int Firstleg_Booking_NoMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;
		protected DateTime? _Booking_Dt;
		protected string _Booking_Status;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Pol_Location_Cd;
		protected string _Pol_Berth;
		protected string _Pod_Location_Cd;
		protected string _Pod_Berth;
		protected string _Customer_Ref;
		protected string _Customer_Cd;
		protected string _Customer_Nm;
		protected string _Move_Type_Cd;
		protected string _Serial_No;
		protected Int64? _Item_No;
		protected string _Cargo_Status;
		protected DateTime? _Cargo_Rcvd_Dt;
		protected DateTime? _Rdd_Dt;
		protected DateTime? _Depart_Dt;
		protected DateTime? _Arrive_Dt;
		protected string _Depart_Flg;
		protected string _Arrive_Flg;
		protected DateTime? _Acms_Rdd_Dt;
		protected string _Acms_Status_Cd;
		protected string _Acms_Voyage_No;
		protected string _Acms_Booking_No;
		protected string _Acms_Booking_Sub;
		protected Double? _Acms_Item_No;
		protected string _Firstleg_Booking_No;
		protected decimal? _W_Count;
		protected decimal? _I_Count;
		protected decimal? _Ae_Count;
		protected decimal? _Vd_Count;
		protected decimal? _Va_Count;
		protected decimal? _Uv_Count;
		protected decimal? _Oa_Count;
		protected decimal? _Av_Count;
		protected decimal? _X1_Count;
		protected Int64? _Cargo_Line_ID;
		protected Int64? _Booking_Line_ID;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public DateTime? Depart_Dt
		{
			get { return _Depart_Dt; }
			set
			{
				if( _Depart_Dt == value ) return;
		
				_Depart_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Depart_Dt");
			}
		}
		public DateTime? Arrive_Dt
		{
			get { return _Arrive_Dt; }
			set
			{
				if( _Arrive_Dt == value ) return;
		
				_Arrive_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrive_Dt");
			}
		}
		public string Depart_Flg
		{
			get { return _Depart_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Depart_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Depart_FlgMax )
					_Depart_Flg = val.Substring(0, (int)Depart_FlgMax);
				else
					_Depart_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Depart_Flg");
			}
		}
		public string Arrive_Flg
		{
			get { return _Arrive_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrive_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Arrive_FlgMax )
					_Arrive_Flg = val.Substring(0, (int)Arrive_FlgMax);
				else
					_Arrive_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrive_Flg");
			}
		}
		public DateTime? Acms_Rdd_Dt
		{
			get { return _Acms_Rdd_Dt; }
			set
			{
				if( _Acms_Rdd_Dt == value ) return;
		
				_Acms_Rdd_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Rdd_Dt");
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
		public string Acms_Voyage_No
		{
			get { return _Acms_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Voyage_NoMax )
					_Acms_Voyage_No = val.Substring(0, (int)Acms_Voyage_NoMax);
				else
					_Acms_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Voyage_No");
			}
		}
		public string Acms_Booking_No
		{
			get { return _Acms_Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Booking_NoMax )
					_Acms_Booking_No = val.Substring(0, (int)Acms_Booking_NoMax);
				else
					_Acms_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Booking_No");
			}
		}
		public string Acms_Booking_Sub
		{
			get { return _Acms_Booking_Sub; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Booking_Sub, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Booking_SubMax )
					_Acms_Booking_Sub = val.Substring(0, (int)Acms_Booking_SubMax);
				else
					_Acms_Booking_Sub = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Booking_Sub");
			}
		}
		public Double? Acms_Item_No
		{
			get { return _Acms_Item_No; }
			set
			{
				if( _Acms_Item_No == value ) return;
		
				_Acms_Item_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Item_No");
			}
		}
		public string Firstleg_Booking_No
		{
			get { return _Firstleg_Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Firstleg_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Firstleg_Booking_NoMax )
					_Firstleg_Booking_No = val.Substring(0, (int)Firstleg_Booking_NoMax);
				else
					_Firstleg_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Firstleg_Booking_No");
			}
		}
		public decimal? W_Count
		{
			get { return _W_Count; }
			set
			{
				if( _W_Count == value ) return;
		
				_W_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("W_Count");
			}
		}
		public decimal? I_Count
		{
			get { return _I_Count; }
			set
			{
				if( _I_Count == value ) return;
		
				_I_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("I_Count");
			}
		}
		public decimal? Ae_Count
		{
			get { return _Ae_Count; }
			set
			{
				if( _Ae_Count == value ) return;
		
				_Ae_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ae_Count");
			}
		}
		public decimal? Vd_Count
		{
			get { return _Vd_Count; }
			set
			{
				if( _Vd_Count == value ) return;
		
				_Vd_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vd_Count");
			}
		}
		public decimal? Va_Count
		{
			get { return _Va_Count; }
			set
			{
				if( _Va_Count == value ) return;
		
				_Va_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Va_Count");
			}
		}
		public decimal? Uv_Count
		{
			get { return _Uv_Count; }
			set
			{
				if( _Uv_Count == value ) return;
		
				_Uv_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Uv_Count");
			}
		}
		public decimal? Oa_Count
		{
			get { return _Oa_Count; }
			set
			{
				if( _Oa_Count == value ) return;
		
				_Oa_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Oa_Count");
			}
		}
		public decimal? Av_Count
		{
			get { return _Av_Count; }
			set
			{
				if( _Av_Count == value ) return;
		
				_Av_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Av_Count");
			}
		}
		public decimal? X1_Count
		{
			get { return _X1_Count; }
			set
			{
				if( _X1_Count == value ) return;
		
				_X1_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("X1_Count");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVSddcItvList() : base() {}
		public ClsVSddcItvList(DataRow dr) : base(dr) {}
		public ClsVSddcItvList(ClsVSddcItvList src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
			Booking_Dt = null;
			Booking_Status = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Pol_Location_Cd = null;
			Pol_Berth = null;
			Pod_Location_Cd = null;
			Pod_Berth = null;
			Customer_Ref = null;
			Customer_Cd = null;
			Customer_Nm = null;
			Move_Type_Cd = null;
			Serial_No = null;
			Item_No = null;
			Cargo_Status = null;
			Cargo_Rcvd_Dt = null;
			Rdd_Dt = null;
			Depart_Dt = null;
			Arrive_Dt = null;
			Depart_Flg = null;
			Arrive_Flg = null;
			Acms_Rdd_Dt = null;
			Acms_Status_Cd = null;
			Acms_Voyage_No = null;
			Acms_Booking_No = null;
			Acms_Booking_Sub = null;
			Acms_Item_No = null;
			Firstleg_Booking_No = null;
			W_Count = null;
			I_Count = null;
			Ae_Count = null;
			Vd_Count = null;
			Va_Count = null;
			Uv_Count = null;
			Oa_Count = null;
			Av_Count = null;
			X1_Count = null;
			Cargo_Line_ID = null;
			Booking_Line_ID = null;
		}

		public void CopyFrom(ClsVSddcItvList src)
		{
			Booking_No = src._Booking_No;
			Booking_Dt = src._Booking_Dt;
			Booking_Status = src._Booking_Status;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pol_Berth = src._Pol_Berth;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pod_Berth = src._Pod_Berth;
			Customer_Ref = src._Customer_Ref;
			Customer_Cd = src._Customer_Cd;
			Customer_Nm = src._Customer_Nm;
			Move_Type_Cd = src._Move_Type_Cd;
			Serial_No = src._Serial_No;
			Item_No = src._Item_No;
			Cargo_Status = src._Cargo_Status;
			Cargo_Rcvd_Dt = src._Cargo_Rcvd_Dt;
			Rdd_Dt = src._Rdd_Dt;
			Depart_Dt = src._Depart_Dt;
			Arrive_Dt = src._Arrive_Dt;
			Depart_Flg = src._Depart_Flg;
			Arrive_Flg = src._Arrive_Flg;
			Acms_Rdd_Dt = src._Acms_Rdd_Dt;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Acms_Voyage_No = src._Acms_Voyage_No;
			Acms_Booking_No = src._Acms_Booking_No;
			Acms_Booking_Sub = src._Acms_Booking_Sub;
			Acms_Item_No = src._Acms_Item_No;
			Firstleg_Booking_No = src._Firstleg_Booking_No;
			W_Count = src._W_Count;
			I_Count = src._I_Count;
			Ae_Count = src._Ae_Count;
			Vd_Count = src._Vd_Count;
			Va_Count = src._Va_Count;
			Uv_Count = src._Uv_Count;
			Oa_Count = src._Oa_Count;
			Av_Count = src._Av_Count;
			X1_Count = src._X1_Count;
			Cargo_Line_ID = src._Cargo_Line_ID;
			Booking_Line_ID = src._Booking_Line_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsVSddcItvList tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[40];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@BOOKING_DT", Booking_Dt);
			p[2] = Connection.GetParameter
				("@BOOKING_STATUS", Booking_Status);
			p[3] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[4] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[5] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[6] = Connection.GetParameter
				("@POL_BERTH", Pol_Berth);
			p[7] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[8] = Connection.GetParameter
				("@POD_BERTH", Pod_Berth);
			p[9] = Connection.GetParameter
				("@CUSTOMER_REF", Customer_Ref);
			p[10] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[11] = Connection.GetParameter
				("@CUSTOMER_NM", Customer_Nm);
			p[12] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[13] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[14] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[15] = Connection.GetParameter
				("@CARGO_STATUS", Cargo_Status);
			p[16] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[17] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[18] = Connection.GetParameter
				("@DEPART_DT", Depart_Dt);
			p[19] = Connection.GetParameter
				("@ARRIVE_DT", Arrive_Dt);
			p[20] = Connection.GetParameter
				("@DEPART_FLG", Depart_Flg);
			p[21] = Connection.GetParameter
				("@ARRIVE_FLG", Arrive_Flg);
			p[22] = Connection.GetParameter
				("@ACMS_RDD_DT", Acms_Rdd_Dt);
			p[23] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[24] = Connection.GetParameter
				("@ACMS_VOYAGE_NO", Acms_Voyage_No);
			p[25] = Connection.GetParameter
				("@ACMS_BOOKING_NO", Acms_Booking_No);
			p[26] = Connection.GetParameter
				("@ACMS_BOOKING_SUB", Acms_Booking_Sub);
			p[27] = Connection.GetParameter
				("@ACMS_ITEM_NO", Acms_Item_No);
			p[28] = Connection.GetParameter
				("@FIRSTLEG_BOOKING_NO", Firstleg_Booking_No);
			p[29] = Connection.GetParameter
				("@W_COUNT", W_Count);
			p[30] = Connection.GetParameter
				("@I_COUNT", I_Count);
			p[31] = Connection.GetParameter
				("@AE_COUNT", Ae_Count);
			p[32] = Connection.GetParameter
				("@VD_COUNT", Vd_Count);
			p[33] = Connection.GetParameter
				("@VA_COUNT", Va_Count);
			p[34] = Connection.GetParameter
				("@UV_COUNT", Uv_Count);
			p[35] = Connection.GetParameter
				("@OA_COUNT", Oa_Count);
			p[36] = Connection.GetParameter
				("@AV_COUNT", Av_Count);
			p[37] = Connection.GetParameter
				("@X1_COUNT", X1_Count);
			p[38] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[39] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);

			const string sql = @"
				INSERT INTO V_SDDC_ITV_LIST
					(BOOKING_NO, BOOKING_DT, BOOKING_STATUS,
					VESSEL_CD, VOYAGE_NO, POL_LOCATION_CD,
					POL_BERTH, POD_LOCATION_CD, POD_BERTH,
					CUSTOMER_REF, CUSTOMER_CD, CUSTOMER_NM,
					MOVE_TYPE_CD, SERIAL_NO, ITEM_NO,
					CARGO_STATUS, CARGO_RCVD_DT, RDD_DT,
					DEPART_DT, ARRIVE_DT, DEPART_FLG,
					ARRIVE_FLG, ACMS_RDD_DT, ACMS_STATUS_CD,
					ACMS_VOYAGE_NO, ACMS_BOOKING_NO, ACMS_BOOKING_SUB,
					ACMS_ITEM_NO, FIRSTLEG_BOOKING_NO, W_COUNT,
					I_COUNT, AE_COUNT, VD_COUNT,
					VA_COUNT, UV_COUNT, OA_COUNT,
					AV_COUNT, X1_COUNT, CARGO_LINE_ID,
					BOOKING_LINE_ID)
				VALUES
					(@BOOKING_NO, @BOOKING_DT, @BOOKING_STATUS,
					@VESSEL_CD, @VOYAGE_NO, @POL_LOCATION_CD,
					@POL_BERTH, @POD_LOCATION_CD, @POD_BERTH,
					@CUSTOMER_REF, @CUSTOMER_CD, @CUSTOMER_NM,
					@MOVE_TYPE_CD, @SERIAL_NO, @ITEM_NO,
					@CARGO_STATUS, @CARGO_RCVD_DT, @RDD_DT,
					@DEPART_DT, @ARRIVE_DT, @DEPART_FLG,
					@ARRIVE_FLG, @ACMS_RDD_DT, @ACMS_STATUS_CD,
					@ACMS_VOYAGE_NO, @ACMS_BOOKING_NO, @ACMS_BOOKING_SUB,
					@ACMS_ITEM_NO, @FIRSTLEG_BOOKING_NO, @W_COUNT,
					@I_COUNT, @AE_COUNT, @VD_COUNT,
					@VA_COUNT, @UV_COUNT, @OA_COUNT,
					@AV_COUNT, @X1_COUNT, @CARGO_LINE_ID,
					@BOOKING_LINE_ID)
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

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Booking_Dt = ClsConvert.ToDateTimeNullable(dr["BOOKING_DT"]);
			Booking_Status = ClsConvert.ToString(dr["BOOKING_STATUS"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pol_Berth = ClsConvert.ToString(dr["POL_BERTH"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pod_Berth = ClsConvert.ToString(dr["POD_BERTH"]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS"]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT"]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT"]);
			Depart_Flg = ClsConvert.ToString(dr["DEPART_FLG"]);
			Arrive_Flg = ClsConvert.ToString(dr["ARRIVE_FLG"]);
			Acms_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ACMS_RDD_DT"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Acms_Voyage_No = ClsConvert.ToString(dr["ACMS_VOYAGE_NO"]);
			Acms_Booking_No = ClsConvert.ToString(dr["ACMS_BOOKING_NO"]);
			Acms_Booking_Sub = ClsConvert.ToString(dr["ACMS_BOOKING_SUB"]);
			Acms_Item_No = ClsConvert.ToDoubleNullable(dr["ACMS_ITEM_NO"]);
			Firstleg_Booking_No = ClsConvert.ToString(dr["FIRSTLEG_BOOKING_NO"]);
			W_Count = ClsConvert.ToDecimalNullable(dr["W_COUNT"]);
			I_Count = ClsConvert.ToDecimalNullable(dr["I_COUNT"]);
			Ae_Count = ClsConvert.ToDecimalNullable(dr["AE_COUNT"]);
			Vd_Count = ClsConvert.ToDecimalNullable(dr["VD_COUNT"]);
			Va_Count = ClsConvert.ToDecimalNullable(dr["VA_COUNT"]);
			Uv_Count = ClsConvert.ToDecimalNullable(dr["UV_COUNT"]);
			Oa_Count = ClsConvert.ToDecimalNullable(dr["OA_COUNT"]);
			Av_Count = ClsConvert.ToDecimalNullable(dr["AV_COUNT"]);
			X1_Count = ClsConvert.ToDecimalNullable(dr["X1_COUNT"]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID"]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Booking_Dt = ClsConvert.ToDateTimeNullable(dr["BOOKING_DT", v]);
			Booking_Status = ClsConvert.ToString(dr["BOOKING_STATUS", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pol_Berth = ClsConvert.ToString(dr["POL_BERTH", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pod_Berth = ClsConvert.ToString(dr["POD_BERTH", v]);
			Customer_Ref = ClsConvert.ToString(dr["CUSTOMER_REF", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS", v]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Depart_Dt = ClsConvert.ToDateTimeNullable(dr["DEPART_DT", v]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT", v]);
			Depart_Flg = ClsConvert.ToString(dr["DEPART_FLG", v]);
			Arrive_Flg = ClsConvert.ToString(dr["ARRIVE_FLG", v]);
			Acms_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ACMS_RDD_DT", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Acms_Voyage_No = ClsConvert.ToString(dr["ACMS_VOYAGE_NO", v]);
			Acms_Booking_No = ClsConvert.ToString(dr["ACMS_BOOKING_NO", v]);
			Acms_Booking_Sub = ClsConvert.ToString(dr["ACMS_BOOKING_SUB", v]);
			Acms_Item_No = ClsConvert.ToDoubleNullable(dr["ACMS_ITEM_NO", v]);
			Firstleg_Booking_No = ClsConvert.ToString(dr["FIRSTLEG_BOOKING_NO", v]);
			W_Count = ClsConvert.ToDecimalNullable(dr["W_COUNT", v]);
			I_Count = ClsConvert.ToDecimalNullable(dr["I_COUNT", v]);
			Ae_Count = ClsConvert.ToDecimalNullable(dr["AE_COUNT", v]);
			Vd_Count = ClsConvert.ToDecimalNullable(dr["VD_COUNT", v]);
			Va_Count = ClsConvert.ToDecimalNullable(dr["VA_COUNT", v]);
			Uv_Count = ClsConvert.ToDecimalNullable(dr["UV_COUNT", v]);
			Oa_Count = ClsConvert.ToDecimalNullable(dr["OA_COUNT", v]);
			Av_Count = ClsConvert.ToDecimalNullable(dr["AV_COUNT", v]);
			X1_Count = ClsConvert.ToDecimalNullable(dr["X1_COUNT", v]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID", v]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOOKING_DT"] = ClsConvert.ToDbObject(Booking_Dt);
			dr["BOOKING_STATUS"] = ClsConvert.ToDbObject(Booking_Status);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POL_BERTH"] = ClsConvert.ToDbObject(Pol_Berth);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POD_BERTH"] = ClsConvert.ToDbObject(Pod_Berth);
			dr["CUSTOMER_REF"] = ClsConvert.ToDbObject(Customer_Ref);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
			dr["CUSTOMER_NM"] = ClsConvert.ToDbObject(Customer_Nm);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["CARGO_STATUS"] = ClsConvert.ToDbObject(Cargo_Status);
			dr["CARGO_RCVD_DT"] = ClsConvert.ToDbObject(Cargo_Rcvd_Dt);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["DEPART_DT"] = ClsConvert.ToDbObject(Depart_Dt);
			dr["ARRIVE_DT"] = ClsConvert.ToDbObject(Arrive_Dt);
			dr["DEPART_FLG"] = ClsConvert.ToDbObject(Depart_Flg);
			dr["ARRIVE_FLG"] = ClsConvert.ToDbObject(Arrive_Flg);
			dr["ACMS_RDD_DT"] = ClsConvert.ToDbObject(Acms_Rdd_Dt);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["ACMS_VOYAGE_NO"] = ClsConvert.ToDbObject(Acms_Voyage_No);
			dr["ACMS_BOOKING_NO"] = ClsConvert.ToDbObject(Acms_Booking_No);
			dr["ACMS_BOOKING_SUB"] = ClsConvert.ToDbObject(Acms_Booking_Sub);
			dr["ACMS_ITEM_NO"] = ClsConvert.ToDbObject(Acms_Item_No);
			dr["FIRSTLEG_BOOKING_NO"] = ClsConvert.ToDbObject(Firstleg_Booking_No);
			dr["W_COUNT"] = ClsConvert.ToDbObject(W_Count);
			dr["I_COUNT"] = ClsConvert.ToDbObject(I_Count);
			dr["AE_COUNT"] = ClsConvert.ToDbObject(Ae_Count);
			dr["VD_COUNT"] = ClsConvert.ToDbObject(Vd_Count);
			dr["VA_COUNT"] = ClsConvert.ToDbObject(Va_Count);
			dr["UV_COUNT"] = ClsConvert.ToDbObject(Uv_Count);
			dr["OA_COUNT"] = ClsConvert.ToDbObject(Oa_Count);
			dr["AV_COUNT"] = ClsConvert.ToDbObject(Av_Count);
			dr["X1_COUNT"] = ClsConvert.ToDbObject(X1_Count);
			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["BOOKING_LINE_ID"] = ClsConvert.ToDbObject(Booking_Line_ID);
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