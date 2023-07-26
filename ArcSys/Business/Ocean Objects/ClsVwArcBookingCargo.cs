using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBookingCargo : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_booking_cargo";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_booking_cargo";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Kop_CdMax = 8;
		public const int Cargo_TypeMax = 20;
		public const int Commodity_CdMax = 15;
		public const int Booking_NoMax = 50;
		public const int Serial_NoMax = 40;
		public const int Handling_Ind_CdMax = 2;
		public const int Handling_Ind_DscMax = 15;
		public const int Transfer_Gear_CdMax = 2;
		public const int Transfer_Gear_DscMax = 50;
		public const int ManufacturerMax = 30;
		public const int ModelMax = 30;
		public const int TrimMax = 30;
		public const int DescriptionofgoodsMax = 80;
		public const int ContainernumberMax = 13;
		public const int CargoidbookedMax = 40;
		public const int CargoidediMax = 40;
		public const int UpdateddateediMax = 27;
		public const int DockreceiptMax = 50;
		public const int ExceptionshandlingMax = 250;
		public const int RemarksMax = 500;
		public const int Bol_NoMax = 50;
		public const int RequireddeliverydateMax = 27;
		public const int Move_Type_CdMax = 8;
		public const int Status_CodeMax = 2;
		public const int Status_DateMax = 27;
		public const int Received_DateMax = 27;
		public const int CreateddateMax = 27;
		public const int UpdateddateMax = 27;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _ID;
		protected string _Kop_Cd;
		protected string _Cargo_Type;
		protected string _Commodity_Cd;
		protected string _Booking_No;
		protected Int32? _Item_No;
		protected string _Serial_No;
		protected string _Handling_Ind_Cd;
		protected string _Handling_Ind_Dsc;
		protected string _Transfer_Gear_Cd;
		protected string _Transfer_Gear_Dsc;
		protected string _Manufacturer;
		protected Int32? _Year;
		protected string _Model;
		protected string _Trim;
		protected Int32? _Axlecount;
		protected Int32? _Numberofpackages;
		protected string _Descriptionofgoods;
		protected string _Containernumber;
		protected Double? _Weight;
		protected Double? _Containertareweight;
		protected Double? _Length;
		protected Double? _Width;
		protected Double? _Height;
		protected Double? _Cubicmeter;
		protected Double? _Squaremeter;
		protected string _Cargoidbooked;
		protected Double? _Cubicmeterbooked;
		protected Double? _Squaremeterbooked;
		protected Double? _Heightbooked;
		protected Double? _Weightbooked;
		protected Double? _Lengthbooked;
		protected Double? _Widthbooked;
		protected Double? _Containertareweightbooked;
		protected Int32? _Numberofpackagesbooked;
		protected string _Cargoidedi;
		protected Double? _Cubicmeteredi;
		protected Double? _Squaremeteredi;
		protected Double? _Heightedi;
		protected Double? _Weightedi;
		protected Double? _Lengthedi;
		protected Double? _Widthedi;
		protected Double? _Containertareweightedi;
		protected Int32? _Numberofpackagesedi;
		protected string _Updateddateedi;
		protected Int32? _Updatedbyedi;
		protected Double? _Weightreceived;
		protected Double? _Lengthreceived;
		protected Double? _Widthreceived;
		protected Double? _Heightreceived;
		protected Double? _Cubicmeterreceived;
		protected string _Dockreceipt;
		protected string _Exceptionshandling;
		protected Int32? _Piecenumber;
		protected string _Remarks;
		protected string _Bol_No;
		protected Int32? _Bol_ID;
		protected string _Requireddeliverydate;
		protected string _Move_Type_Cd;
		protected string _Status_Code;
		protected string _Status_Date;
		protected string _Received_Date;
		protected Int32? _Booking_ID;
		protected string _Createddate;
		protected string _Updateddate;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int32? ID
		{
			get { return _ID; }
			set
			{
				if( _ID == value ) return;
		
				_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("ID");
			}
		}
		public string Kop_Cd
		{
			get { return _Kop_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Kop_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Kop_CdMax )
					_Kop_Cd = val.Substring(0, (int)Kop_CdMax);
				else
					_Kop_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Kop_Cd");
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
		public Int32? Item_No
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
		public string Handling_Ind_Cd
		{
			get { return _Handling_Ind_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Handling_Ind_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Handling_Ind_CdMax )
					_Handling_Ind_Cd = val.Substring(0, (int)Handling_Ind_CdMax);
				else
					_Handling_Ind_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Handling_Ind_Cd");
			}
		}
		public string Handling_Ind_Dsc
		{
			get { return _Handling_Ind_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Handling_Ind_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Handling_Ind_DscMax )
					_Handling_Ind_Dsc = val.Substring(0, (int)Handling_Ind_DscMax);
				else
					_Handling_Ind_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Handling_Ind_Dsc");
			}
		}
		public string Transfer_Gear_Cd
		{
			get { return _Transfer_Gear_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Transfer_Gear_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Transfer_Gear_CdMax )
					_Transfer_Gear_Cd = val.Substring(0, (int)Transfer_Gear_CdMax);
				else
					_Transfer_Gear_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Transfer_Gear_Cd");
			}
		}
		public string Transfer_Gear_Dsc
		{
			get { return _Transfer_Gear_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Transfer_Gear_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Transfer_Gear_DscMax )
					_Transfer_Gear_Dsc = val.Substring(0, (int)Transfer_Gear_DscMax);
				else
					_Transfer_Gear_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Transfer_Gear_Dsc");
			}
		}
		public string Manufacturer
		{
			get { return _Manufacturer; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Manufacturer, val, false) == 0 ) return;
		
				if( val != null && val.Length > ManufacturerMax )
					_Manufacturer = val.Substring(0, (int)ManufacturerMax);
				else
					_Manufacturer = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Manufacturer");
			}
		}
		public Int32? Year
		{
			get { return _Year; }
			set
			{
				if( _Year == value ) return;
		
				_Year = value;
				_IsDirty = true;
				NotifyPropertyChanged("Year");
			}
		}
		public string Model
		{
			get { return _Model; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Model, val, false) == 0 ) return;
		
				if( val != null && val.Length > ModelMax )
					_Model = val.Substring(0, (int)ModelMax);
				else
					_Model = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Model");
			}
		}
		public string Trim
		{
			get { return _Trim; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trim, val, false) == 0 ) return;
		
				if( val != null && val.Length > TrimMax )
					_Trim = val.Substring(0, (int)TrimMax);
				else
					_Trim = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trim");
			}
		}
		public Int32? Axlecount
		{
			get { return _Axlecount; }
			set
			{
				if( _Axlecount == value ) return;
		
				_Axlecount = value;
				_IsDirty = true;
				NotifyPropertyChanged("Axlecount");
			}
		}
		public Int32? Numberofpackages
		{
			get { return _Numberofpackages; }
			set
			{
				if( _Numberofpackages == value ) return;
		
				_Numberofpackages = value;
				_IsDirty = true;
				NotifyPropertyChanged("Numberofpackages");
			}
		}
		public string Descriptionofgoods
		{
			get { return _Descriptionofgoods; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Descriptionofgoods, val, false) == 0 ) return;
		
				if( val != null && val.Length > DescriptionofgoodsMax )
					_Descriptionofgoods = val.Substring(0, (int)DescriptionofgoodsMax);
				else
					_Descriptionofgoods = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Descriptionofgoods");
			}
		}
		public string Containernumber
		{
			get { return _Containernumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Containernumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > ContainernumberMax )
					_Containernumber = val.Substring(0, (int)ContainernumberMax);
				else
					_Containernumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Containernumber");
			}
		}
		public Double? Weight
		{
			get { return _Weight; }
			set
			{
				if( _Weight == value ) return;
		
				_Weight = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weight");
			}
		}
		public Double? Containertareweight
		{
			get { return _Containertareweight; }
			set
			{
				if( _Containertareweight == value ) return;
		
				_Containertareweight = value;
				_IsDirty = true;
				NotifyPropertyChanged("Containertareweight");
			}
		}
		public Double? Length
		{
			get { return _Length; }
			set
			{
				if( _Length == value ) return;
		
				_Length = value;
				_IsDirty = true;
				NotifyPropertyChanged("Length");
			}
		}
		public Double? Width
		{
			get { return _Width; }
			set
			{
				if( _Width == value ) return;
		
				_Width = value;
				_IsDirty = true;
				NotifyPropertyChanged("Width");
			}
		}
		public Double? Height
		{
			get { return _Height; }
			set
			{
				if( _Height == value ) return;
		
				_Height = value;
				_IsDirty = true;
				NotifyPropertyChanged("Height");
			}
		}
		public Double? Cubicmeter
		{
			get { return _Cubicmeter; }
			set
			{
				if( _Cubicmeter == value ) return;
		
				_Cubicmeter = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cubicmeter");
			}
		}
		public Double? Squaremeter
		{
			get { return _Squaremeter; }
			set
			{
				if( _Squaremeter == value ) return;
		
				_Squaremeter = value;
				_IsDirty = true;
				NotifyPropertyChanged("Squaremeter");
			}
		}
		public string Cargoidbooked
		{
			get { return _Cargoidbooked; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargoidbooked, val, false) == 0 ) return;
		
				if( val != null && val.Length > CargoidbookedMax )
					_Cargoidbooked = val.Substring(0, (int)CargoidbookedMax);
				else
					_Cargoidbooked = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargoidbooked");
			}
		}
		public Double? Cubicmeterbooked
		{
			get { return _Cubicmeterbooked; }
			set
			{
				if( _Cubicmeterbooked == value ) return;
		
				_Cubicmeterbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cubicmeterbooked");
			}
		}
		public Double? Squaremeterbooked
		{
			get { return _Squaremeterbooked; }
			set
			{
				if( _Squaremeterbooked == value ) return;
		
				_Squaremeterbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Squaremeterbooked");
			}
		}
		public Double? Heightbooked
		{
			get { return _Heightbooked; }
			set
			{
				if( _Heightbooked == value ) return;
		
				_Heightbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Heightbooked");
			}
		}
		public Double? Weightbooked
		{
			get { return _Weightbooked; }
			set
			{
				if( _Weightbooked == value ) return;
		
				_Weightbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weightbooked");
			}
		}
		public Double? Lengthbooked
		{
			get { return _Lengthbooked; }
			set
			{
				if( _Lengthbooked == value ) return;
		
				_Lengthbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lengthbooked");
			}
		}
		public Double? Widthbooked
		{
			get { return _Widthbooked; }
			set
			{
				if( _Widthbooked == value ) return;
		
				_Widthbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Widthbooked");
			}
		}
		public Double? Containertareweightbooked
		{
			get { return _Containertareweightbooked; }
			set
			{
				if( _Containertareweightbooked == value ) return;
		
				_Containertareweightbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Containertareweightbooked");
			}
		}
		public Int32? Numberofpackagesbooked
		{
			get { return _Numberofpackagesbooked; }
			set
			{
				if( _Numberofpackagesbooked == value ) return;
		
				_Numberofpackagesbooked = value;
				_IsDirty = true;
				NotifyPropertyChanged("Numberofpackagesbooked");
			}
		}
		public string Cargoidedi
		{
			get { return _Cargoidedi; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargoidedi, val, false) == 0 ) return;
		
				if( val != null && val.Length > CargoidediMax )
					_Cargoidedi = val.Substring(0, (int)CargoidediMax);
				else
					_Cargoidedi = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargoidedi");
			}
		}
		public Double? Cubicmeteredi
		{
			get { return _Cubicmeteredi; }
			set
			{
				if( _Cubicmeteredi == value ) return;
		
				_Cubicmeteredi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cubicmeteredi");
			}
		}
		public Double? Squaremeteredi
		{
			get { return _Squaremeteredi; }
			set
			{
				if( _Squaremeteredi == value ) return;
		
				_Squaremeteredi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Squaremeteredi");
			}
		}
		public Double? Heightedi
		{
			get { return _Heightedi; }
			set
			{
				if( _Heightedi == value ) return;
		
				_Heightedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Heightedi");
			}
		}
		public Double? Weightedi
		{
			get { return _Weightedi; }
			set
			{
				if( _Weightedi == value ) return;
		
				_Weightedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weightedi");
			}
		}
		public Double? Lengthedi
		{
			get { return _Lengthedi; }
			set
			{
				if( _Lengthedi == value ) return;
		
				_Lengthedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lengthedi");
			}
		}
		public Double? Widthedi
		{
			get { return _Widthedi; }
			set
			{
				if( _Widthedi == value ) return;
		
				_Widthedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Widthedi");
			}
		}
		public Double? Containertareweightedi
		{
			get { return _Containertareweightedi; }
			set
			{
				if( _Containertareweightedi == value ) return;
		
				_Containertareweightedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Containertareweightedi");
			}
		}
		public Int32? Numberofpackagesedi
		{
			get { return _Numberofpackagesedi; }
			set
			{
				if( _Numberofpackagesedi == value ) return;
		
				_Numberofpackagesedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Numberofpackagesedi");
			}
		}
		public string Updateddateedi
		{
			get { return _Updateddateedi; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Updateddateedi, val, false) == 0 ) return;
		
				if( val != null && val.Length > UpdateddateediMax )
					_Updateddateedi = val.Substring(0, (int)UpdateddateediMax);
				else
					_Updateddateedi = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Updateddateedi");
			}
		}
		public Int32? Updatedbyedi
		{
			get { return _Updatedbyedi; }
			set
			{
				if( _Updatedbyedi == value ) return;
		
				_Updatedbyedi = value;
				_IsDirty = true;
				NotifyPropertyChanged("Updatedbyedi");
			}
		}
		public Double? Weightreceived
		{
			get { return _Weightreceived; }
			set
			{
				if( _Weightreceived == value ) return;
		
				_Weightreceived = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weightreceived");
			}
		}
		public Double? Lengthreceived
		{
			get { return _Lengthreceived; }
			set
			{
				if( _Lengthreceived == value ) return;
		
				_Lengthreceived = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lengthreceived");
			}
		}
		public Double? Widthreceived
		{
			get { return _Widthreceived; }
			set
			{
				if( _Widthreceived == value ) return;
		
				_Widthreceived = value;
				_IsDirty = true;
				NotifyPropertyChanged("Widthreceived");
			}
		}
		public Double? Heightreceived
		{
			get { return _Heightreceived; }
			set
			{
				if( _Heightreceived == value ) return;
		
				_Heightreceived = value;
				_IsDirty = true;
				NotifyPropertyChanged("Heightreceived");
			}
		}
		public Double? Cubicmeterreceived
		{
			get { return _Cubicmeterreceived; }
			set
			{
				if( _Cubicmeterreceived == value ) return;
		
				_Cubicmeterreceived = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cubicmeterreceived");
			}
		}
		public string Dockreceipt
		{
			get { return _Dockreceipt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dockreceipt, val, false) == 0 ) return;
		
				if( val != null && val.Length > DockreceiptMax )
					_Dockreceipt = val.Substring(0, (int)DockreceiptMax);
				else
					_Dockreceipt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dockreceipt");
			}
		}
		public string Exceptionshandling
		{
			get { return _Exceptionshandling; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Exceptionshandling, val, false) == 0 ) return;
		
				if( val != null && val.Length > ExceptionshandlingMax )
					_Exceptionshandling = val.Substring(0, (int)ExceptionshandlingMax);
				else
					_Exceptionshandling = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Exceptionshandling");
			}
		}
		public Int32? Piecenumber
		{
			get { return _Piecenumber; }
			set
			{
				if( _Piecenumber == value ) return;
		
				_Piecenumber = value;
				_IsDirty = true;
				NotifyPropertyChanged("Piecenumber");
			}
		}
		public string Remarks
		{
			get { return _Remarks; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Remarks, val, false) == 0 ) return;
		
				if( val != null && val.Length > RemarksMax )
					_Remarks = val.Substring(0, (int)RemarksMax);
				else
					_Remarks = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Remarks");
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
		public Int32? Bol_ID
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
		public string Requireddeliverydate
		{
			get { return _Requireddeliverydate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Requireddeliverydate, val, false) == 0 ) return;
		
				if( val != null && val.Length > RequireddeliverydateMax )
					_Requireddeliverydate = val.Substring(0, (int)RequireddeliverydateMax);
				else
					_Requireddeliverydate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Requireddeliverydate");
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
		public string Status_Code
		{
			get { return _Status_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_CodeMax )
					_Status_Code = val.Substring(0, (int)Status_CodeMax);
				else
					_Status_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Code");
			}
		}
		public string Status_Date
		{
			get { return _Status_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_DateMax )
					_Status_Date = val.Substring(0, (int)Status_DateMax);
				else
					_Status_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Date");
			}
		}
		public string Received_Date
		{
			get { return _Received_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Received_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Received_DateMax )
					_Received_Date = val.Substring(0, (int)Received_DateMax);
				else
					_Received_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Received_Date");
			}
		}
		public Int32? Booking_ID
		{
			get { return _Booking_ID; }
			set
			{
				if( _Booking_ID == value ) return;
		
				_Booking_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_ID");
			}
		}
		public string Createddate
		{
			get { return _Createddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Createddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > CreateddateMax )
					_Createddate = val.Substring(0, (int)CreateddateMax);
				else
					_Createddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Createddate");
			}
		}
		public string Updateddate
		{
			get { return _Updateddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Updateddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > UpdateddateMax )
					_Updateddate = val.Substring(0, (int)UpdateddateMax);
				else
					_Updateddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Updateddate");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBookingCargo() : base() {}
		public ClsVwArcBookingCargo(DataRow dr) : base(dr) {}
		public ClsVwArcBookingCargo(ClsVwArcBookingCargo src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			ID = null;
			Kop_Cd = null;
			Cargo_Type = null;
			Commodity_Cd = null;
			Booking_No = null;
			Item_No = null;
			Serial_No = null;
			Handling_Ind_Cd = null;
			Handling_Ind_Dsc = null;
			Transfer_Gear_Cd = null;
			Transfer_Gear_Dsc = null;
			Manufacturer = null;
			Year = null;
			Model = null;
			Trim = null;
			Axlecount = null;
			Numberofpackages = null;
			Descriptionofgoods = null;
			Containernumber = null;
			Weight = null;
			Containertareweight = null;
			Length = null;
			Width = null;
			Height = null;
			Cubicmeter = null;
			Squaremeter = null;
			Cargoidbooked = null;
			Cubicmeterbooked = null;
			Squaremeterbooked = null;
			Heightbooked = null;
			Weightbooked = null;
			Lengthbooked = null;
			Widthbooked = null;
			Containertareweightbooked = null;
			Numberofpackagesbooked = null;
			Cargoidedi = null;
			Cubicmeteredi = null;
			Squaremeteredi = null;
			Heightedi = null;
			Weightedi = null;
			Lengthedi = null;
			Widthedi = null;
			Containertareweightedi = null;
			Numberofpackagesedi = null;
			Updateddateedi = null;
			Updatedbyedi = null;
			Weightreceived = null;
			Lengthreceived = null;
			Widthreceived = null;
			Heightreceived = null;
			Cubicmeterreceived = null;
			Dockreceipt = null;
			Exceptionshandling = null;
			Piecenumber = null;
			Remarks = null;
			Bol_No = null;
			Bol_ID = null;
			Requireddeliverydate = null;
			Move_Type_Cd = null;
			Status_Code = null;
			Status_Date = null;
			Received_Date = null;
			Booking_ID = null;
			Createddate = null;
			Updateddate = null;
		}

		public void CopyFrom(ClsVwArcBookingCargo src)
		{
			ID = src._ID;
			Kop_Cd = src._Kop_Cd;
			Cargo_Type = src._Cargo_Type;
			Commodity_Cd = src._Commodity_Cd;
			Booking_No = src._Booking_No;
			Item_No = src._Item_No;
			Serial_No = src._Serial_No;
			Handling_Ind_Cd = src._Handling_Ind_Cd;
			Handling_Ind_Dsc = src._Handling_Ind_Dsc;
			Transfer_Gear_Cd = src._Transfer_Gear_Cd;
			Transfer_Gear_Dsc = src._Transfer_Gear_Dsc;
			Manufacturer = src._Manufacturer;
			Year = src._Year;
			Model = src._Model;
			Trim = src._Trim;
			Axlecount = src._Axlecount;
			Numberofpackages = src._Numberofpackages;
			Descriptionofgoods = src._Descriptionofgoods;
			Containernumber = src._Containernumber;
			Weight = src._Weight;
			Containertareweight = src._Containertareweight;
			Length = src._Length;
			Width = src._Width;
			Height = src._Height;
			Cubicmeter = src._Cubicmeter;
			Squaremeter = src._Squaremeter;
			Cargoidbooked = src._Cargoidbooked;
			Cubicmeterbooked = src._Cubicmeterbooked;
			Squaremeterbooked = src._Squaremeterbooked;
			Heightbooked = src._Heightbooked;
			Weightbooked = src._Weightbooked;
			Lengthbooked = src._Lengthbooked;
			Widthbooked = src._Widthbooked;
			Containertareweightbooked = src._Containertareweightbooked;
			Numberofpackagesbooked = src._Numberofpackagesbooked;
			Cargoidedi = src._Cargoidedi;
			Cubicmeteredi = src._Cubicmeteredi;
			Squaremeteredi = src._Squaremeteredi;
			Heightedi = src._Heightedi;
			Weightedi = src._Weightedi;
			Lengthedi = src._Lengthedi;
			Widthedi = src._Widthedi;
			Containertareweightedi = src._Containertareweightedi;
			Numberofpackagesedi = src._Numberofpackagesedi;
			Updateddateedi = src._Updateddateedi;
			Updatedbyedi = src._Updatedbyedi;
			Weightreceived = src._Weightreceived;
			Lengthreceived = src._Lengthreceived;
			Widthreceived = src._Widthreceived;
			Heightreceived = src._Heightreceived;
			Cubicmeterreceived = src._Cubicmeterreceived;
			Dockreceipt = src._Dockreceipt;
			Exceptionshandling = src._Exceptionshandling;
			Piecenumber = src._Piecenumber;
			Remarks = src._Remarks;
			Bol_No = src._Bol_No;
			Bol_ID = src._Bol_ID;
			Requireddeliverydate = src._Requireddeliverydate;
			Move_Type_Cd = src._Move_Type_Cd;
			Status_Code = src._Status_Code;
			Status_Date = src._Status_Date;
			Received_Date = src._Received_Date;
			Booking_ID = src._Booking_ID;
			Createddate = src._Createddate;
			Updateddate = src._Updateddate;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBookingCargo tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[65];

			p[0] = Connection.GetParameter
				("@Id", ID);
			p[1] = Connection.GetParameter
				("@kop_cd", Kop_Cd);
			p[2] = Connection.GetParameter
				("@cargo_type", Cargo_Type);
			p[3] = Connection.GetParameter
				("@commodity_cd", Commodity_Cd);
			p[4] = Connection.GetParameter
				("@booking_no", Booking_No);
			p[5] = Connection.GetParameter
				("@item_no", Item_No);
			p[6] = Connection.GetParameter
				("@serial_no", Serial_No);
			p[7] = Connection.GetParameter
				("@Handling_Ind_Cd", Handling_Ind_Cd);
			p[8] = Connection.GetParameter
				("@Handling_Ind_Dsc", Handling_Ind_Dsc);
			p[9] = Connection.GetParameter
				("@Transfer_Gear_Cd", Transfer_Gear_Cd);
			p[10] = Connection.GetParameter
				("@Transfer_Gear_Dsc", Transfer_Gear_Dsc);
			p[11] = Connection.GetParameter
				("@Manufacturer", Manufacturer);
			p[12] = Connection.GetParameter
				("@Year", Year);
			p[13] = Connection.GetParameter
				("@Model", Model);
			p[14] = Connection.GetParameter
				("@Trim", Trim);
			p[15] = Connection.GetParameter
				("@AxleCount", Axlecount);
			p[16] = Connection.GetParameter
				("@NumberOfPackages", Numberofpackages);
			p[17] = Connection.GetParameter
				("@DescriptionOfGoods", Descriptionofgoods);
			p[18] = Connection.GetParameter
				("@ContainerNumber", Containernumber);
			p[19] = Connection.GetParameter
				("@Weight", Weight);
			p[20] = Connection.GetParameter
				("@ContainerTareWeight", Containertareweight);
			p[21] = Connection.GetParameter
				("@Length", Length);
			p[22] = Connection.GetParameter
				("@Width", Width);
			p[23] = Connection.GetParameter
				("@Height", Height);
			p[24] = Connection.GetParameter
				("@CubicMeter", Cubicmeter);
			p[25] = Connection.GetParameter
				("@SquareMeter", Squaremeter);
			p[26] = Connection.GetParameter
				("@CargoIdBooked", Cargoidbooked);
			p[27] = Connection.GetParameter
				("@CubicMeterBooked", Cubicmeterbooked);
			p[28] = Connection.GetParameter
				("@SquareMeterBooked", Squaremeterbooked);
			p[29] = Connection.GetParameter
				("@HeightBooked", Heightbooked);
			p[30] = Connection.GetParameter
				("@WeightBooked", Weightbooked);
			p[31] = Connection.GetParameter
				("@LengthBooked", Lengthbooked);
			p[32] = Connection.GetParameter
				("@WidthBooked", Widthbooked);
			p[33] = Connection.GetParameter
				("@ContainerTareWeightBooked", Containertareweightbooked);
			p[34] = Connection.GetParameter
				("@NumberOfPackagesBooked", Numberofpackagesbooked);
			p[35] = Connection.GetParameter
				("@CargoIdEdi", Cargoidedi);
			p[36] = Connection.GetParameter
				("@CubicMeterEdi", Cubicmeteredi);
			p[37] = Connection.GetParameter
				("@SquareMeterEdi", Squaremeteredi);
			p[38] = Connection.GetParameter
				("@HeightEdi", Heightedi);
			p[39] = Connection.GetParameter
				("@WeightEdi", Weightedi);
			p[40] = Connection.GetParameter
				("@LengthEdi", Lengthedi);
			p[41] = Connection.GetParameter
				("@WidthEdi", Widthedi);
			p[42] = Connection.GetParameter
				("@ContainerTareWeightEdi", Containertareweightedi);
			p[43] = Connection.GetParameter
				("@NumberOfPackagesEdi", Numberofpackagesedi);
			p[44] = Connection.GetParameter
				("@UpdatedDateEdi", Updateddateedi);
			p[45] = Connection.GetParameter
				("@UpdatedByEdi", Updatedbyedi);
			p[46] = Connection.GetParameter
				("@WeightReceived", Weightreceived);
			p[47] = Connection.GetParameter
				("@LengthReceived", Lengthreceived);
			p[48] = Connection.GetParameter
				("@WidthReceived", Widthreceived);
			p[49] = Connection.GetParameter
				("@HeightReceived", Heightreceived);
			p[50] = Connection.GetParameter
				("@CubicMeterReceived", Cubicmeterreceived);
			p[51] = Connection.GetParameter
				("@DockReceipt", Dockreceipt);
			p[52] = Connection.GetParameter
				("@ExceptionsHandling", Exceptionshandling);
			p[53] = Connection.GetParameter
				("@PieceNumber", Piecenumber);
			p[54] = Connection.GetParameter
				("@Remarks", Remarks);
			p[55] = Connection.GetParameter
				("@bol_no", Bol_No);
			p[56] = Connection.GetParameter
				("@bol_id", Bol_ID);
			p[57] = Connection.GetParameter
				("@RequiredDeliveryDate", Requireddeliverydate);
			p[58] = Connection.GetParameter
				("@move_type_cd", Move_Type_Cd);
			p[59] = Connection.GetParameter
				("@status_code", Status_Code);
			p[60] = Connection.GetParameter
				("@status_date", Status_Date);
			p[61] = Connection.GetParameter
				("@received_date", Received_Date);
			p[62] = Connection.GetParameter
				("@booking_id", Booking_ID);
			p[63] = Connection.GetParameter
				("@CreatedDate", Createddate);
			p[64] = Connection.GetParameter
				("@UpdatedDate", Updateddate);

			const string sql = @"INSERT INTO vw_arc_booking_cargo VALUES
				(@Id,@kop_cd,@cargo_type
				,@commodity_cd,@booking_no,@item_no
				,@serial_no,@Handling_Ind_Cd,@Handling_Ind_Dsc
				,@Transfer_Gear_Cd,@Transfer_Gear_Dsc,@Manufacturer
				,@Year,@Model,@Trim
				,@AxleCount,@NumberOfPackages,@DescriptionOfGoods
				,@ContainerNumber,@Weight,@ContainerTareWeight
				,@Length,@Width,@Height
				,@CubicMeter,@SquareMeter,@CargoIdBooked
				,@CubicMeterBooked,@SquareMeterBooked,@HeightBooked
				,@WeightBooked,@LengthBooked,@WidthBooked
				,@ContainerTareWeightBooked,@NumberOfPackagesBooked,@CargoIdEdi
				,@CubicMeterEdi,@SquareMeterEdi,@HeightEdi
				,@WeightEdi,@LengthEdi,@WidthEdi
				,@ContainerTareWeightEdi,@NumberOfPackagesEdi,@UpdatedDateEdi
				,@UpdatedByEdi,@WeightReceived,@LengthReceived
				,@WidthReceived,@HeightReceived,@CubicMeterReceived
				,@DockReceipt,@ExceptionsHandling,@PieceNumber
				,@Remarks,@bol_no,@bol_id
				,@RequiredDeliveryDate,@move_type_cd,@status_code
				,@status_date,@received_date,@booking_id
				,@CreatedDate,@UpdatedDate)";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			return -1;

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

			ID = ClsConvert.ToInt32Nullable(dr["Id"]);
			Kop_Cd = ClsConvert.ToString(dr["kop_cd"]);
			Cargo_Type = ClsConvert.ToString(dr["cargo_type"]);
			Commodity_Cd = ClsConvert.ToString(dr["commodity_cd"]);
			Booking_No = ClsConvert.ToString(dr["booking_no"]);
			Item_No = ClsConvert.ToInt32Nullable(dr["item_no"]);
			Serial_No = ClsConvert.ToString(dr["serial_no"]);
			Handling_Ind_Cd = ClsConvert.ToString(dr["Handling_Ind_Cd"]);
			Handling_Ind_Dsc = ClsConvert.ToString(dr["Handling_Ind_Dsc"]);
			Transfer_Gear_Cd = ClsConvert.ToString(dr["Transfer_Gear_Cd"]);
			Transfer_Gear_Dsc = ClsConvert.ToString(dr["Transfer_Gear_Dsc"]);
			Manufacturer = ClsConvert.ToString(dr["Manufacturer"]);
			Year = ClsConvert.ToInt32Nullable(dr["Year"]);
			Model = ClsConvert.ToString(dr["Model"]);
			Trim = ClsConvert.ToString(dr["Trim"]);
			Axlecount = ClsConvert.ToInt32Nullable(dr["AxleCount"]);
			Numberofpackages = ClsConvert.ToInt32Nullable(dr["NumberOfPackages"]);
			Descriptionofgoods = ClsConvert.ToString(dr["DescriptionOfGoods"]);
			Containernumber = ClsConvert.ToString(dr["ContainerNumber"]);
			Weight = ClsConvert.ToDoubleNullable(dr["Weight"]);
			Containertareweight = ClsConvert.ToDoubleNullable(dr["ContainerTareWeight"]);
			Length = ClsConvert.ToDoubleNullable(dr["Length"]);
			Width = ClsConvert.ToDoubleNullable(dr["Width"]);
			Height = ClsConvert.ToDoubleNullable(dr["Height"]);
			Cubicmeter = ClsConvert.ToDoubleNullable(dr["CubicMeter"]);
			Squaremeter = ClsConvert.ToDoubleNullable(dr["SquareMeter"]);
			Cargoidbooked = ClsConvert.ToString(dr["CargoIdBooked"]);
			Cubicmeterbooked = ClsConvert.ToDoubleNullable(dr["CubicMeterBooked"]);
			Squaremeterbooked = ClsConvert.ToDoubleNullable(dr["SquareMeterBooked"]);
			Heightbooked = ClsConvert.ToDoubleNullable(dr["HeightBooked"]);
			Weightbooked = ClsConvert.ToDoubleNullable(dr["WeightBooked"]);
			Lengthbooked = ClsConvert.ToDoubleNullable(dr["LengthBooked"]);
			Widthbooked = ClsConvert.ToDoubleNullable(dr["WidthBooked"]);
			Containertareweightbooked = ClsConvert.ToDoubleNullable(dr["ContainerTareWeightBooked"]);
			Numberofpackagesbooked = ClsConvert.ToInt32Nullable(dr["NumberOfPackagesBooked"]);
			Cargoidedi = ClsConvert.ToString(dr["CargoIdEdi"]);
			Cubicmeteredi = ClsConvert.ToDoubleNullable(dr["CubicMeterEdi"]);
			Squaremeteredi = ClsConvert.ToDoubleNullable(dr["SquareMeterEdi"]);
			Heightedi = ClsConvert.ToDoubleNullable(dr["HeightEdi"]);
			Weightedi = ClsConvert.ToDoubleNullable(dr["WeightEdi"]);
			Lengthedi = ClsConvert.ToDoubleNullable(dr["LengthEdi"]);
			Widthedi = ClsConvert.ToDoubleNullable(dr["WidthEdi"]);
			Containertareweightedi = ClsConvert.ToDoubleNullable(dr["ContainerTareWeightEdi"]);
			Numberofpackagesedi = ClsConvert.ToInt32Nullable(dr["NumberOfPackagesEdi"]);
			Updateddateedi = ClsConvert.ToString(dr["UpdatedDateEdi"]);
			Updatedbyedi = ClsConvert.ToInt32Nullable(dr["UpdatedByEdi"]);
			Weightreceived = ClsConvert.ToDoubleNullable(dr["WeightReceived"]);
			Lengthreceived = ClsConvert.ToDoubleNullable(dr["LengthReceived"]);
			Widthreceived = ClsConvert.ToDoubleNullable(dr["WidthReceived"]);
			Heightreceived = ClsConvert.ToDoubleNullable(dr["HeightReceived"]);
			Cubicmeterreceived = ClsConvert.ToDoubleNullable(dr["CubicMeterReceived"]);
			Dockreceipt = ClsConvert.ToString(dr["DockReceipt"]);
			Exceptionshandling = ClsConvert.ToString(dr["ExceptionsHandling"]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber"]);
			Remarks = ClsConvert.ToString(dr["Remarks"]);
			Bol_No = ClsConvert.ToString(dr["bol_no"]);
			Bol_ID = ClsConvert.ToInt32Nullable(dr["bol_id"]);
			Requireddeliverydate = ClsConvert.ToString(dr["RequiredDeliveryDate"]);
			Move_Type_Cd = ClsConvert.ToString(dr["move_type_cd"]);
			Status_Code = ClsConvert.ToString(dr["status_code"]);
			Status_Date = ClsConvert.ToString(dr["status_date"]);
			Received_Date = ClsConvert.ToString(dr["received_date"]);
			Booking_ID = ClsConvert.ToInt32Nullable(dr["booking_id"]);
			Createddate = ClsConvert.ToString(dr["CreatedDate"]);
			Updateddate = ClsConvert.ToString(dr["UpdatedDate"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			ID = ClsConvert.ToInt32Nullable(dr["Id", v]);
			Kop_Cd = ClsConvert.ToString(dr["kop_cd", v]);
			Cargo_Type = ClsConvert.ToString(dr["cargo_type", v]);
			Commodity_Cd = ClsConvert.ToString(dr["commodity_cd", v]);
			Booking_No = ClsConvert.ToString(dr["booking_no", v]);
			Item_No = ClsConvert.ToInt32Nullable(dr["item_no", v]);
			Serial_No = ClsConvert.ToString(dr["serial_no", v]);
			Handling_Ind_Cd = ClsConvert.ToString(dr["Handling_Ind_Cd", v]);
			Handling_Ind_Dsc = ClsConvert.ToString(dr["Handling_Ind_Dsc", v]);
			Transfer_Gear_Cd = ClsConvert.ToString(dr["Transfer_Gear_Cd", v]);
			Transfer_Gear_Dsc = ClsConvert.ToString(dr["Transfer_Gear_Dsc", v]);
			Manufacturer = ClsConvert.ToString(dr["Manufacturer", v]);
			Year = ClsConvert.ToInt32Nullable(dr["Year", v]);
			Model = ClsConvert.ToString(dr["Model", v]);
			Trim = ClsConvert.ToString(dr["Trim", v]);
			Axlecount = ClsConvert.ToInt32Nullable(dr["AxleCount", v]);
			Numberofpackages = ClsConvert.ToInt32Nullable(dr["NumberOfPackages", v]);
			Descriptionofgoods = ClsConvert.ToString(dr["DescriptionOfGoods", v]);
			Containernumber = ClsConvert.ToString(dr["ContainerNumber", v]);
			Weight = ClsConvert.ToDoubleNullable(dr["Weight", v]);
			Containertareweight = ClsConvert.ToDoubleNullable(dr["ContainerTareWeight", v]);
			Length = ClsConvert.ToDoubleNullable(dr["Length", v]);
			Width = ClsConvert.ToDoubleNullable(dr["Width", v]);
			Height = ClsConvert.ToDoubleNullable(dr["Height", v]);
			Cubicmeter = ClsConvert.ToDoubleNullable(dr["CubicMeter", v]);
			Squaremeter = ClsConvert.ToDoubleNullable(dr["SquareMeter", v]);
			Cargoidbooked = ClsConvert.ToString(dr["CargoIdBooked", v]);
			Cubicmeterbooked = ClsConvert.ToDoubleNullable(dr["CubicMeterBooked", v]);
			Squaremeterbooked = ClsConvert.ToDoubleNullable(dr["SquareMeterBooked", v]);
			Heightbooked = ClsConvert.ToDoubleNullable(dr["HeightBooked", v]);
			Weightbooked = ClsConvert.ToDoubleNullable(dr["WeightBooked", v]);
			Lengthbooked = ClsConvert.ToDoubleNullable(dr["LengthBooked", v]);
			Widthbooked = ClsConvert.ToDoubleNullable(dr["WidthBooked", v]);
			Containertareweightbooked = ClsConvert.ToDoubleNullable(dr["ContainerTareWeightBooked", v]);
			Numberofpackagesbooked = ClsConvert.ToInt32Nullable(dr["NumberOfPackagesBooked", v]);
			Cargoidedi = ClsConvert.ToString(dr["CargoIdEdi", v]);
			Cubicmeteredi = ClsConvert.ToDoubleNullable(dr["CubicMeterEdi", v]);
			Squaremeteredi = ClsConvert.ToDoubleNullable(dr["SquareMeterEdi", v]);
			Heightedi = ClsConvert.ToDoubleNullable(dr["HeightEdi", v]);
			Weightedi = ClsConvert.ToDoubleNullable(dr["WeightEdi", v]);
			Lengthedi = ClsConvert.ToDoubleNullable(dr["LengthEdi", v]);
			Widthedi = ClsConvert.ToDoubleNullable(dr["WidthEdi", v]);
			Containertareweightedi = ClsConvert.ToDoubleNullable(dr["ContainerTareWeightEdi", v]);
			Numberofpackagesedi = ClsConvert.ToInt32Nullable(dr["NumberOfPackagesEdi", v]);
			Updateddateedi = ClsConvert.ToString(dr["UpdatedDateEdi", v]);
			Updatedbyedi = ClsConvert.ToInt32Nullable(dr["UpdatedByEdi", v]);
			Weightreceived = ClsConvert.ToDoubleNullable(dr["WeightReceived", v]);
			Lengthreceived = ClsConvert.ToDoubleNullable(dr["LengthReceived", v]);
			Widthreceived = ClsConvert.ToDoubleNullable(dr["WidthReceived", v]);
			Heightreceived = ClsConvert.ToDoubleNullable(dr["HeightReceived", v]);
			Cubicmeterreceived = ClsConvert.ToDoubleNullable(dr["CubicMeterReceived", v]);
			Dockreceipt = ClsConvert.ToString(dr["DockReceipt", v]);
			Exceptionshandling = ClsConvert.ToString(dr["ExceptionsHandling", v]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber", v]);
			Remarks = ClsConvert.ToString(dr["Remarks", v]);
			Bol_No = ClsConvert.ToString(dr["bol_no", v]);
			Bol_ID = ClsConvert.ToInt32Nullable(dr["bol_id", v]);
			Requireddeliverydate = ClsConvert.ToString(dr["RequiredDeliveryDate", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["move_type_cd", v]);
			Status_Code = ClsConvert.ToString(dr["status_code", v]);
			Status_Date = ClsConvert.ToString(dr["status_date", v]);
			Received_Date = ClsConvert.ToString(dr["received_date", v]);
			Booking_ID = ClsConvert.ToInt32Nullable(dr["booking_id", v]);
			Createddate = ClsConvert.ToString(dr["CreatedDate", v]);
			Updateddate = ClsConvert.ToString(dr["UpdatedDate", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["Id"] = ClsConvert.ToDbObject(ID);
			dr["kop_cd"] = ClsConvert.ToDbObject(Kop_Cd);
			dr["cargo_type"] = ClsConvert.ToDbObject(Cargo_Type);
			dr["commodity_cd"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["booking_no"] = ClsConvert.ToDbObject(Booking_No);
			dr["item_no"] = ClsConvert.ToDbObject(Item_No);
			dr["serial_no"] = ClsConvert.ToDbObject(Serial_No);
			dr["Handling_Ind_Cd"] = ClsConvert.ToDbObject(Handling_Ind_Cd);
			dr["Handling_Ind_Dsc"] = ClsConvert.ToDbObject(Handling_Ind_Dsc);
			dr["Transfer_Gear_Cd"] = ClsConvert.ToDbObject(Transfer_Gear_Cd);
			dr["Transfer_Gear_Dsc"] = ClsConvert.ToDbObject(Transfer_Gear_Dsc);
			dr["Manufacturer"] = ClsConvert.ToDbObject(Manufacturer);
			dr["Year"] = ClsConvert.ToDbObject(Year);
			dr["Model"] = ClsConvert.ToDbObject(Model);
			dr["Trim"] = ClsConvert.ToDbObject(Trim);
			dr["AxleCount"] = ClsConvert.ToDbObject(Axlecount);
			dr["NumberOfPackages"] = ClsConvert.ToDbObject(Numberofpackages);
			dr["DescriptionOfGoods"] = ClsConvert.ToDbObject(Descriptionofgoods);
			dr["ContainerNumber"] = ClsConvert.ToDbObject(Containernumber);
			dr["Weight"] = ClsConvert.ToDbObject(Weight);
			dr["ContainerTareWeight"] = ClsConvert.ToDbObject(Containertareweight);
			dr["Length"] = ClsConvert.ToDbObject(Length);
			dr["Width"] = ClsConvert.ToDbObject(Width);
			dr["Height"] = ClsConvert.ToDbObject(Height);
			dr["CubicMeter"] = ClsConvert.ToDbObject(Cubicmeter);
			dr["SquareMeter"] = ClsConvert.ToDbObject(Squaremeter);
			dr["CargoIdBooked"] = ClsConvert.ToDbObject(Cargoidbooked);
			dr["CubicMeterBooked"] = ClsConvert.ToDbObject(Cubicmeterbooked);
			dr["SquareMeterBooked"] = ClsConvert.ToDbObject(Squaremeterbooked);
			dr["HeightBooked"] = ClsConvert.ToDbObject(Heightbooked);
			dr["WeightBooked"] = ClsConvert.ToDbObject(Weightbooked);
			dr["LengthBooked"] = ClsConvert.ToDbObject(Lengthbooked);
			dr["WidthBooked"] = ClsConvert.ToDbObject(Widthbooked);
			dr["ContainerTareWeightBooked"] = ClsConvert.ToDbObject(Containertareweightbooked);
			dr["NumberOfPackagesBooked"] = ClsConvert.ToDbObject(Numberofpackagesbooked);
			dr["CargoIdEdi"] = ClsConvert.ToDbObject(Cargoidedi);
			dr["CubicMeterEdi"] = ClsConvert.ToDbObject(Cubicmeteredi);
			dr["SquareMeterEdi"] = ClsConvert.ToDbObject(Squaremeteredi);
			dr["HeightEdi"] = ClsConvert.ToDbObject(Heightedi);
			dr["WeightEdi"] = ClsConvert.ToDbObject(Weightedi);
			dr["LengthEdi"] = ClsConvert.ToDbObject(Lengthedi);
			dr["WidthEdi"] = ClsConvert.ToDbObject(Widthedi);
			dr["ContainerTareWeightEdi"] = ClsConvert.ToDbObject(Containertareweightedi);
			dr["NumberOfPackagesEdi"] = ClsConvert.ToDbObject(Numberofpackagesedi);
			dr["UpdatedDateEdi"] = ClsConvert.ToDbObject(Updateddateedi);
			dr["UpdatedByEdi"] = ClsConvert.ToDbObject(Updatedbyedi);
			dr["WeightReceived"] = ClsConvert.ToDbObject(Weightreceived);
			dr["LengthReceived"] = ClsConvert.ToDbObject(Lengthreceived);
			dr["WidthReceived"] = ClsConvert.ToDbObject(Widthreceived);
			dr["HeightReceived"] = ClsConvert.ToDbObject(Heightreceived);
			dr["CubicMeterReceived"] = ClsConvert.ToDbObject(Cubicmeterreceived);
			dr["DockReceipt"] = ClsConvert.ToDbObject(Dockreceipt);
			dr["ExceptionsHandling"] = ClsConvert.ToDbObject(Exceptionshandling);
			dr["PieceNumber"] = ClsConvert.ToDbObject(Piecenumber);
			dr["Remarks"] = ClsConvert.ToDbObject(Remarks);
			dr["bol_no"] = ClsConvert.ToDbObject(Bol_No);
			dr["bol_id"] = ClsConvert.ToDbObject(Bol_ID);
			dr["RequiredDeliveryDate"] = ClsConvert.ToDbObject(Requireddeliverydate);
			dr["move_type_cd"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["status_code"] = ClsConvert.ToDbObject(Status_Code);
			dr["status_date"] = ClsConvert.ToDbObject(Status_Date);
			dr["received_date"] = ClsConvert.ToDbObject(Received_Date);
			dr["booking_id"] = ClsConvert.ToDbObject(Booking_ID);
			dr["CreatedDate"] = ClsConvert.ToDbObject(Createddate);
			dr["UpdatedDate"] = ClsConvert.ToDbObject(Updateddate);
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