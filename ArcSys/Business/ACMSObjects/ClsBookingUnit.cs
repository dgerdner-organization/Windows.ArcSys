using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingUnit : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_UNIT";
		public const int PrimaryKeyCount = 3;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD", "PARTNER_REQUEST_CD", "ITEM_NO" };
		}

		public const string SelectSQL = @"SELECT * FROM T_BOOKING_UNIT 
				INNER JOIN T_BOOKING
				ON ( T_BOOKING.PARTNER_CD=T_BOOKING_UNIT.PARTNER_CD AND T_BOOKING.PARTNER_REQUEST_CD=T_BOOKING_UNIT.PARTNER_REQUEST_CD)
				LEFT OUTER JOIN R_REVENUE_CODE
				ON T_BOOKING_UNIT.REV_CD=R_REVENUE_CODE.REV_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Wt_QualifierMax = 2;
		public const int Volume_QualifierMax = 2;
		public const int Packaging_Form_CdMax = 5;
		public const int Wt_Unit_CdMax = 2;
		public const int Item_DscMax = 50;
		public const int Commodity_CdMax = 30;
		public const int Commodity_QualifierMax = 2;
		public const int Type_Pack_CdMax = 3;
		public const int TcnMax = 30;
		public const int Measure_Unit_QualifierMax = 2;
		public const int Vessel_CdMax = 4;
		public const int Poe_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Mil_Voyage_NoMax = 10;
		public const int Booking_IDMax = 30;
		public const int Booking_Id_SubMax = 5;
		public const int Poe_Terminal_CdMax = 10;
		public const int Pod_Terminal_CdMax = 10;
		public const int Rev_CdMax = 10;
		public const int Adj_Rdd_ReasonMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected Double? _Item_No;
		protected Double? _Wt_Nbr;
		protected string _Wt_Qualifier;
		protected Double? _Volume_Nbr;
		protected string _Volume_Qualifier;
		protected Double? _Lading_Qty_Nbr;
		protected string _Packaging_Form_Cd;
		protected string _Wt_Unit_Cd;
		protected string _Item_Dsc;
		protected string _Commodity_Cd;
		protected string _Commodity_Qualifier;
		protected string _Type_Pack_Cd;
		protected string _Tcn;
		protected Double? _Length_Nbr;
		protected Double? _Width_Nbr;
		protected Double? _Height_Nbr;
		protected string _Measure_Unit_Qualifier;
		protected Double? _Units_Nbr;
		protected string _Vessel_Cd;
		protected string _Poe_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Voyage_No;
		protected string _Mil_Voyage_No;
		protected string _Booking_ID;
		protected string _Booking_Id_Sub;
		protected string _Poe_Terminal_Cd;
		protected string _Pod_Terminal_Cd;
		protected decimal? _Cargo_ID;
		protected string _Rev_Cd;
		protected DateTime? _Adj_Rdd_Dt;
		protected string _Adj_Rdd_Reason;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public Double? Item_No
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
		public Double? Lading_Qty_Nbr
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
		public string Packaging_Form_Cd
		{
			get { return _Packaging_Form_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Packaging_Form_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Packaging_Form_CdMax )
					_Packaging_Form_Cd = val.Substring(0, (int)Packaging_Form_CdMax);
				else
					_Packaging_Form_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Packaging_Form_Cd");
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
		public string Item_Dsc
		{
			get { return _Item_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_DscMax )
					_Item_Dsc = val.Substring(0, (int)Item_DscMax);
				else
					_Item_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Dsc");
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
		public string Commodity_Qualifier
		{
			get { return _Commodity_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_QualifierMax )
					_Commodity_Qualifier = val.Substring(0, (int)Commodity_QualifierMax);
				else
					_Commodity_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Qualifier");
			}
		}
		public string Type_Pack_Cd
		{
			get { return _Type_Pack_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Type_Pack_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Type_Pack_CdMax )
					_Type_Pack_Cd = val.Substring(0, (int)Type_Pack_CdMax);
				else
					_Type_Pack_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Type_Pack_Cd");
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
		public Double? Length_Nbr
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
		public Double? Width_Nbr
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
		public Double? Height_Nbr
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
		public string Measure_Unit_Qualifier
		{
			get { return _Measure_Unit_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Measure_Unit_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Measure_Unit_QualifierMax )
					_Measure_Unit_Qualifier = val.Substring(0, (int)Measure_Unit_QualifierMax);
				else
					_Measure_Unit_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Measure_Unit_Qualifier");
			}
		}
		public Double? Units_Nbr
		{
			get { return _Units_Nbr; }
			set
			{
				if( _Units_Nbr == value ) return;
		
				_Units_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Units_Nbr");
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
		public string Poe_Location_Cd
		{
			get { return _Poe_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Location_CdMax )
					_Poe_Location_Cd = val.Substring(0, (int)Poe_Location_CdMax);
				else
					_Poe_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Location_Cd");
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
		public string Mil_Voyage_No
		{
			get { return _Mil_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mil_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Mil_Voyage_NoMax )
					_Mil_Voyage_No = val.Substring(0, (int)Mil_Voyage_NoMax);
				else
					_Mil_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mil_Voyage_No");
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
		public string Booking_Id_Sub
		{
			get { return _Booking_Id_Sub; }
			set
			{
				_Booking_Id_Sub = value;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Id_Sub");
			}
		}
		public string Poe_Terminal_Cd
		{
			get { return _Poe_Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Poe_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Poe_Terminal_CdMax )
					_Poe_Terminal_Cd = val.Substring(0, (int)Poe_Terminal_CdMax);
				else
					_Poe_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Poe_Terminal_Cd");
			}
		}
		public string Pod_Terminal_Cd
		{
			get { return _Pod_Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Terminal_CdMax )
					_Pod_Terminal_Cd = val.Substring(0, (int)Pod_Terminal_CdMax);
				else
					_Pod_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Terminal_Cd");
			}
		}
		public decimal? Cargo_ID
		{
			get { return _Cargo_ID; }
			set
			{
				if( _Cargo_ID == value ) return;
		
				_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_ID");
			}
		}
		public string Rev_Cd
		{
			get { return _Rev_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rev_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rev_CdMax )
					_Rev_Cd = val.Substring(0, (int)Rev_CdMax);
				else
					_Rev_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rev_Cd");
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
		public string Adj_Rdd_Reason
		{
			get { return _Adj_Rdd_Reason; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Adj_Rdd_Reason, val, false) == 0 ) return;
		
				if( val != null && val.Length > Adj_Rdd_ReasonMax )
					_Adj_Rdd_Reason = val.Substring(0, (int)Adj_Rdd_ReasonMax);
				else
					_Adj_Rdd_Reason = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Adj_Rdd_Reason");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		//protected ClsBooking _BookingFK;
		//protected ClsRevenueCode _Rev;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties


		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingUnit() : base() {}
		public ClsBookingUnit(DataRow dr) : base(dr) {}
		public ClsBookingUnit(ClsBookingUnit src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Item_No = null;
			Wt_Nbr = null;
			Wt_Qualifier = null;
			Volume_Nbr = null;
			Volume_Qualifier = null;
			Lading_Qty_Nbr = null;
			Packaging_Form_Cd = null;
			Wt_Unit_Cd = null;
			Item_Dsc = null;
			Commodity_Cd = null;
			Commodity_Qualifier = null;
			Type_Pack_Cd = null;
			Tcn = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Measure_Unit_Qualifier = null;
			Units_Nbr = null;
			Vessel_Cd = null;
			Poe_Location_Cd = null;
			Pod_Location_Cd = null;
			Voyage_No = null;
			Mil_Voyage_No = null;
			Booking_ID = null;
			Booking_Id_Sub = null;
			Poe_Terminal_Cd = null;
			Pod_Terminal_Cd = null;
			Cargo_ID = null;
			Rev_Cd = null;
			Adj_Rdd_Dt = null;
			Adj_Rdd_Reason = null;
		}

		public void CopyFrom(ClsBookingUnit src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Item_No = src._Item_No;
			Wt_Nbr = src._Wt_Nbr;
			Wt_Qualifier = src._Wt_Qualifier;
			Volume_Nbr = src._Volume_Nbr;
			Volume_Qualifier = src._Volume_Qualifier;
			Lading_Qty_Nbr = src._Lading_Qty_Nbr;
			Packaging_Form_Cd = src._Packaging_Form_Cd;
			Wt_Unit_Cd = src._Wt_Unit_Cd;
			Item_Dsc = src._Item_Dsc;
			Commodity_Cd = src._Commodity_Cd;
			Commodity_Qualifier = src._Commodity_Qualifier;
			Type_Pack_Cd = src._Type_Pack_Cd;
			Tcn = src._Tcn;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Measure_Unit_Qualifier = src._Measure_Unit_Qualifier;
			Units_Nbr = src._Units_Nbr;
			Vessel_Cd = src._Vessel_Cd;
			Poe_Location_Cd = src._Poe_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Voyage_No = src._Voyage_No;
			Mil_Voyage_No = src._Mil_Voyage_No;
			Booking_ID = src._Booking_ID;
			Booking_Id_Sub = src._Booking_Id_Sub;
			Poe_Terminal_Cd = src._Poe_Terminal_Cd;
			Pod_Terminal_Cd = src._Pod_Terminal_Cd;
			Cargo_ID = src._Cargo_ID;
			Rev_Cd = src._Rev_Cd;
			Adj_Rdd_Dt = src._Adj_Rdd_Dt;
			Adj_Rdd_Reason = src._Adj_Rdd_Reason;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingUnit tmp = ClsBookingUnit.GetUsingKey(Partner_Cd, Partner_Request_Cd, Item_No.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			//_BookingFK = null;
			//_Rev = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[33];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[3] = Connection.GetParameter
				("@WT_NBR", Wt_Nbr);
			p[4] = Connection.GetParameter
				("@WT_QUALIFIER", Wt_Qualifier);
			p[5] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[6] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[7] = Connection.GetParameter
				("@LADING_QTY_NBR", Lading_Qty_Nbr);
			p[8] = Connection.GetParameter
				("@PACKAGING_FORM_CD", Packaging_Form_Cd);
			p[9] = Connection.GetParameter
				("@WT_UNIT_CD", Wt_Unit_Cd);
			p[10] = Connection.GetParameter
				("@ITEM_DSC", Item_Dsc);
			p[11] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[12] = Connection.GetParameter
				("@COMMODITY_QUALIFIER", Commodity_Qualifier);
			p[13] = Connection.GetParameter
				("@TYPE_PACK_CD", Type_Pack_Cd);
			p[14] = Connection.GetParameter
				("@TCN", Tcn);
			p[15] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[16] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[17] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[18] = Connection.GetParameter
				("@MEASURE_UNIT_QUALIFIER", Measure_Unit_Qualifier);
			p[19] = Connection.GetParameter
				("@UNITS_NBR", Units_Nbr);
			p[20] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[21] = Connection.GetParameter
				("@POE_LOCATION_CD", Poe_Location_Cd);
			p[22] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[23] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[24] = Connection.GetParameter
				("@MIL_VOYAGE_NO", Mil_Voyage_No);
			p[25] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[26] = Connection.GetParameter
				("@BOOKING_ID_SUB", Booking_Id_Sub);
			p[27] = Connection.GetParameter
				("@POE_TERMINAL_CD", Poe_Terminal_Cd);
			p[28] = Connection.GetParameter
				("@POD_TERMINAL_CD", Pod_Terminal_Cd);
			p[29] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[30] = Connection.GetParameter
				("@REV_CD", Rev_Cd);
			p[31] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[32] = Connection.GetParameter
				("@ADJ_RDD_REASON", Adj_Rdd_Reason);

			const string sql = @"
				INSERT INTO T_BOOKING_UNIT
					(PARTNER_CD, PARTNER_REQUEST_CD, ITEM_NO,
					WT_NBR, WT_QUALIFIER, VOLUME_NBR,
					VOLUME_QUALIFIER, LADING_QTY_NBR, PACKAGING_FORM_CD,
					WT_UNIT_CD, ITEM_DSC, COMMODITY_CD,
					COMMODITY_QUALIFIER, TYPE_PACK_CD, TCN,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					MEASURE_UNIT_QUALIFIER, UNITS_NBR, VESSEL_CD,
					POE_LOCATION_CD, POD_LOCATION_CD, VOYAGE_NO,
					MIL_VOYAGE_NO, BOOKING_ID, BOOKING_ID_SUB,
					POE_TERMINAL_CD, POD_TERMINAL_CD, CARGO_ID,
					REV_CD, ADJ_RDD_DT, ADJ_RDD_REASON)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @ITEM_NO,
					@WT_NBR, @WT_QUALIFIER, @VOLUME_NBR,
					@VOLUME_QUALIFIER, @LADING_QTY_NBR, @PACKAGING_FORM_CD,
					@WT_UNIT_CD, @ITEM_DSC, @COMMODITY_CD,
					@COMMODITY_QUALIFIER, @TYPE_PACK_CD, @TCN,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@MEASURE_UNIT_QUALIFIER, @UNITS_NBR, @VESSEL_CD,
					@POE_LOCATION_CD, @POD_LOCATION_CD, @VOYAGE_NO,
					@MIL_VOYAGE_NO, @BOOKING_ID, @BOOKING_ID_SUB,
					@POE_TERMINAL_CD, @POD_TERMINAL_CD, @CARGO_ID,
					@REV_CD, @ADJ_RDD_DT, @ADJ_RDD_REASON)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[33];

			p[0] = Connection.GetParameter
				("@WT_NBR", Wt_Nbr);
			p[1] = Connection.GetParameter
				("@WT_QUALIFIER", Wt_Qualifier);
			p[2] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[3] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[4] = Connection.GetParameter
				("@LADING_QTY_NBR", Lading_Qty_Nbr);
			p[5] = Connection.GetParameter
				("@PACKAGING_FORM_CD", Packaging_Form_Cd);
			p[6] = Connection.GetParameter
				("@WT_UNIT_CD", Wt_Unit_Cd);
			p[7] = Connection.GetParameter
				("@ITEM_DSC", Item_Dsc);
			p[8] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[9] = Connection.GetParameter
				("@COMMODITY_QUALIFIER", Commodity_Qualifier);
			p[10] = Connection.GetParameter
				("@TYPE_PACK_CD", Type_Pack_Cd);
			p[11] = Connection.GetParameter
				("@TCN", Tcn);
			p[12] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[13] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[14] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[15] = Connection.GetParameter
				("@MEASURE_UNIT_QUALIFIER", Measure_Unit_Qualifier);
			p[16] = Connection.GetParameter
				("@UNITS_NBR", Units_Nbr);
			p[17] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[18] = Connection.GetParameter
				("@POE_LOCATION_CD", Poe_Location_Cd);
			p[19] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[20] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[21] = Connection.GetParameter
				("@MIL_VOYAGE_NO", Mil_Voyage_No);
			p[22] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[23] = Connection.GetParameter
				("@BOOKING_ID_SUB", Booking_Id_Sub);
			p[24] = Connection.GetParameter
				("@POE_TERMINAL_CD", Poe_Terminal_Cd);
			p[25] = Connection.GetParameter
				("@POD_TERMINAL_CD", Pod_Terminal_Cd);
			p[26] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[27] = Connection.GetParameter
				("@REV_CD", Rev_Cd);
			p[28] = Connection.GetParameter
				("@ADJ_RDD_DT", Adj_Rdd_Dt);
			p[29] = Connection.GetParameter
				("@ADJ_RDD_REASON", Adj_Rdd_Reason);
			p[30] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[31] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[32] = Connection.GetParameter
				("@ITEM_NO", Item_No);

			const string sql = @"
				UPDATE T_BOOKING_UNIT SET
					WT_NBR = @WT_NBR,
					WT_QUALIFIER = @WT_QUALIFIER,
					VOLUME_NBR = @VOLUME_NBR,
					VOLUME_QUALIFIER = @VOLUME_QUALIFIER,
					LADING_QTY_NBR = @LADING_QTY_NBR,
					PACKAGING_FORM_CD = @PACKAGING_FORM_CD,
					WT_UNIT_CD = @WT_UNIT_CD,
					ITEM_DSC = @ITEM_DSC,
					COMMODITY_CD = @COMMODITY_CD,
					COMMODITY_QUALIFIER = @COMMODITY_QUALIFIER,
					TYPE_PACK_CD = @TYPE_PACK_CD,
					TCN = @TCN,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					MEASURE_UNIT_QUALIFIER = @MEASURE_UNIT_QUALIFIER,
					UNITS_NBR = @UNITS_NBR,
					VESSEL_CD = @VESSEL_CD,
					POE_LOCATION_CD = @POE_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					VOYAGE_NO = @VOYAGE_NO,
					MIL_VOYAGE_NO = @MIL_VOYAGE_NO,
					BOOKING_ID = @BOOKING_ID,
					BOOKING_ID_SUB = @BOOKING_ID_SUB,
					POE_TERMINAL_CD = @POE_TERMINAL_CD,
					POD_TERMINAL_CD = @POD_TERMINAL_CD,
					CARGO_ID = @CARGO_ID,
					REV_CD = @REV_CD,
					ADJ_RDD_DT = @ADJ_RDD_DT,
					ADJ_RDD_REASON = @ADJ_RDD_REASON
				WHERE
					PARTNER_CD = @PARTNER_CD AND
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD AND
					ITEM_NO = @ITEM_NO

					";
			int ret = Connection.RunSQL(sql, p);


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

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO"]);
			Wt_Nbr = ClsConvert.ToDoubleNullable(dr["WT_NBR"]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER"]);
			Volume_Nbr = ClsConvert.ToDoubleNullable(dr["VOLUME_NBR"]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER"]);
			Lading_Qty_Nbr = ClsConvert.ToDoubleNullable(dr["LADING_QTY_NBR"]);
			Packaging_Form_Cd = ClsConvert.ToString(dr["PACKAGING_FORM_CD"]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD"]);
			Item_Dsc = ClsConvert.ToString(dr["ITEM_DSC"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Commodity_Qualifier = ClsConvert.ToString(dr["COMMODITY_QUALIFIER"]);
			Type_Pack_Cd = ClsConvert.ToString(dr["TYPE_PACK_CD"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Length_Nbr = ClsConvert.ToDoubleNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDoubleNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDoubleNullable(dr["HEIGHT_NBR"]);
			Measure_Unit_Qualifier = ClsConvert.ToString(dr["MEASURE_UNIT_QUALIFIER"]);
			Units_Nbr = ClsConvert.ToDoubleNullable(dr["UNITS_NBR"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Mil_Voyage_No = ClsConvert.ToString(dr["MIL_VOYAGE_NO"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Booking_Id_Sub = ClsConvert.ToString(dr["BOOKING_ID_SUB"]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD"]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD"]);
			Cargo_ID = ClsConvert.ToDecimalNullable(dr["CARGO_ID"]);
			Rev_Cd = ClsConvert.ToString(dr["REV_CD"]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT"]);
			Adj_Rdd_Reason = ClsConvert.ToString(dr["ADJ_RDD_REASON"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO", v]);
			Wt_Nbr = ClsConvert.ToDoubleNullable(dr["WT_NBR", v]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER", v]);
			Volume_Nbr = ClsConvert.ToDoubleNullable(dr["VOLUME_NBR", v]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER", v]);
			Lading_Qty_Nbr = ClsConvert.ToDoubleNullable(dr["LADING_QTY_NBR", v]);
			Packaging_Form_Cd = ClsConvert.ToString(dr["PACKAGING_FORM_CD", v]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD", v]);
			Item_Dsc = ClsConvert.ToString(dr["ITEM_DSC", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Commodity_Qualifier = ClsConvert.ToString(dr["COMMODITY_QUALIFIER", v]);
			Type_Pack_Cd = ClsConvert.ToString(dr["TYPE_PACK_CD", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Length_Nbr = ClsConvert.ToDoubleNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDoubleNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDoubleNullable(dr["HEIGHT_NBR", v]);
			Measure_Unit_Qualifier = ClsConvert.ToString(dr["MEASURE_UNIT_QUALIFIER", v]);
			Units_Nbr = ClsConvert.ToDoubleNullable(dr["UNITS_NBR", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Poe_Location_Cd = ClsConvert.ToString(dr["POE_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Mil_Voyage_No = ClsConvert.ToString(dr["MIL_VOYAGE_NO", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Booking_Id_Sub = ClsConvert.ToString(dr["BOOKING_ID_SUB", v]);
			Poe_Terminal_Cd = ClsConvert.ToString(dr["POE_TERMINAL_CD", v]);
			Pod_Terminal_Cd = ClsConvert.ToString(dr["POD_TERMINAL_CD", v]);
			Cargo_ID = ClsConvert.ToDecimalNullable(dr["CARGO_ID", v]);
			Rev_Cd = ClsConvert.ToString(dr["REV_CD", v]);
			Adj_Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["ADJ_RDD_DT", v]);
			Adj_Rdd_Reason = ClsConvert.ToString(dr["ADJ_RDD_REASON", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["WT_NBR"] = ClsConvert.ToDbObject(Wt_Nbr);
			dr["WT_QUALIFIER"] = ClsConvert.ToDbObject(Wt_Qualifier);
			dr["VOLUME_NBR"] = ClsConvert.ToDbObject(Volume_Nbr);
			dr["VOLUME_QUALIFIER"] = ClsConvert.ToDbObject(Volume_Qualifier);
			dr["LADING_QTY_NBR"] = ClsConvert.ToDbObject(Lading_Qty_Nbr);
			dr["PACKAGING_FORM_CD"] = ClsConvert.ToDbObject(Packaging_Form_Cd);
			dr["WT_UNIT_CD"] = ClsConvert.ToDbObject(Wt_Unit_Cd);
			dr["ITEM_DSC"] = ClsConvert.ToDbObject(Item_Dsc);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["COMMODITY_QUALIFIER"] = ClsConvert.ToDbObject(Commodity_Qualifier);
			dr["TYPE_PACK_CD"] = ClsConvert.ToDbObject(Type_Pack_Cd);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["MEASURE_UNIT_QUALIFIER"] = ClsConvert.ToDbObject(Measure_Unit_Qualifier);
			dr["UNITS_NBR"] = ClsConvert.ToDbObject(Units_Nbr);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["POE_LOCATION_CD"] = ClsConvert.ToDbObject(Poe_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["MIL_VOYAGE_NO"] = ClsConvert.ToDbObject(Mil_Voyage_No);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["BOOKING_ID_SUB"] = ClsConvert.ToDbObject(Booking_Id_Sub);
			dr["POE_TERMINAL_CD"] = ClsConvert.ToDbObject(Poe_Terminal_Cd);
			dr["POD_TERMINAL_CD"] = ClsConvert.ToDbObject(Pod_Terminal_Cd);
			dr["CARGO_ID"] = ClsConvert.ToDbObject(Cargo_ID);
			dr["REV_CD"] = ClsConvert.ToDbObject(Rev_Cd);
			dr["ADJ_RDD_DT"] = ClsConvert.ToDbObject(Adj_Rdd_Dt);
			dr["ADJ_RDD_REASON"] = ClsConvert.ToDbObject(Adj_Rdd_Reason);
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

		public static ClsBookingUnit GetUsingKey(string Partner_Cd, string Partner_Request_Cd, Double Item_No)
		{
			object[] vals = new object[] {Partner_Cd, Partner_Request_Cd, Item_No};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingUnit(dr);
		}
		public static DataTable GetAll(string Partner_Cd, string Partner_Request_Cd,
			string Rev_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PARTNER_CD", Partner_Cd));
				sb.Append(" WHERE T_BOOKING_UNIT.PARTNER_CD=@PARTNER_CD");
			}
			if( string.IsNullOrEmpty(Partner_Request_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PARTNER_REQUEST_CD", Partner_Request_Cd));
				sb.AppendFormat(" {0} T_BOOKING_UNIT.PARTNER_REQUEST_CD=@PARTNER_REQUEST_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Rev_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@REV_CD", Rev_Cd));
				sb.AppendFormat(" {0} T_BOOKING_UNIT.REV_CD=@REV_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}