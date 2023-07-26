using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBolCargo : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_bol_cargo";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_bol_cargo";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Bol_NoMax = 50;
		public const int Booking_NoMax = 50;
		public const int Cargo_TypeMax = 20;
		public const int MarksandnumbersMax = 1000;
		public const int Serial_NoMax = 25;
		public const int Kop_CdMax = 8;
		public const int Kop_DscMax = 50;
		public const int Cargo_Commodity_CdMax = 15;
		public const int Cargo_Commodity_NameMax = 50;
		public const int Item_DogMax = 80;
		public const int Item_Dog_TxtMax = 500;
		public const int Handling_Ind_CdMax = 2;
		public const int Handling_Ind_DscMax = 15;
		public const int Transfer_Gear_CdMax = 2;
		public const int Transfer_Gear_DscMax = 50;
		public const int ManufacturerMax = 30;
		public const int ModelMax = 30;
		public const int TrimMax = 30;
		public const int DescriptionofgoodsMax = 80;
		public const int ContainernumberMax = 13;
		public const int DockreceiptMax = 50;
		public const int DescriptionofgoodstextMax = 1073741823;
		public const int Item_Kop_CdMax = 8;
		public const int Item_Kop_DscMax = 50;
		public const int Item_Commodity_CdMax = 15;
		public const int Item_Commodity_NameMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _Bol_ID;
		protected string _Bol_No;
		protected string _Booking_No;
		protected Int32? _Item_ID;
		protected Int32? _Item_No;
		protected string _Cargo_Type;
		protected string _Marksandnumbers;
		protected string _Serial_No;
		protected string _Kop_Cd;
		protected string _Kop_Dsc;
		protected string _Cargo_Commodity_Cd;
		protected string _Cargo_Commodity_Name;
		protected string _Item_Dog;
		protected string _Item_Dog_Txt;
		protected string _Handling_Ind_Cd;
		protected string _Handling_Ind_Dsc;
		protected string _Transfer_Gear_Cd;
		protected string _Transfer_Gear_Dsc;
		protected Int32? _Axlecount;
		protected Int32? _Year;
		protected string _Manufacturer;
		protected string _Model;
		protected string _Trim;
		protected Int32? _Numberofpackages;
		protected string _Descriptionofgoods;
		protected string _Containernumber;
		protected Int32? _Containerloadtypeid;
		protected Int32? _Billofladingconvanid;
		protected Double? _Weight;
		protected Double? _Containertareweight;
		protected Double? _Length;
		protected Double? _Width;
		protected Double? _Height;
		protected Double? _Cubicmeter;
		protected Double? _Squaremeter;
		protected string _Dockreceipt;
		protected Int32? _Piecenumber;
		protected string _Descriptionofgoodstext;
		protected string _Item_Kop_Cd;
		protected string _Item_Kop_Dsc;
		protected string _Item_Commodity_Cd;
		protected string _Item_Commodity_Name;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public Int32? Item_ID
		{
			get { return _Item_ID; }
			set
			{
				if( _Item_ID == value ) return;
		
				_Item_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Item_ID");
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
		public string Marksandnumbers
		{
			get { return _Marksandnumbers; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Marksandnumbers, val, false) == 0 ) return;
		
				if( val != null && val.Length > MarksandnumbersMax )
					_Marksandnumbers = val.Substring(0, (int)MarksandnumbersMax);
				else
					_Marksandnumbers = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Marksandnumbers");
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
		public string Kop_Dsc
		{
			get { return _Kop_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Kop_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Kop_DscMax )
					_Kop_Dsc = val.Substring(0, (int)Kop_DscMax);
				else
					_Kop_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Kop_Dsc");
			}
		}
		public string Cargo_Commodity_Cd
		{
			get { return _Cargo_Commodity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Commodity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Commodity_CdMax )
					_Cargo_Commodity_Cd = val.Substring(0, (int)Cargo_Commodity_CdMax);
				else
					_Cargo_Commodity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Commodity_Cd");
			}
		}
		public string Cargo_Commodity_Name
		{
			get { return _Cargo_Commodity_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Commodity_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Commodity_NameMax )
					_Cargo_Commodity_Name = val.Substring(0, (int)Cargo_Commodity_NameMax);
				else
					_Cargo_Commodity_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Commodity_Name");
			}
		}
		public string Item_Dog
		{
			get { return _Item_Dog; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Dog, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_DogMax )
					_Item_Dog = val.Substring(0, (int)Item_DogMax);
				else
					_Item_Dog = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Dog");
			}
		}
		public string Item_Dog_Txt
		{
			get { return _Item_Dog_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Dog_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_Dog_TxtMax )
					_Item_Dog_Txt = val.Substring(0, (int)Item_Dog_TxtMax);
				else
					_Item_Dog_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Dog_Txt");
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
		public Int32? Containerloadtypeid
		{
			get { return _Containerloadtypeid; }
			set
			{
				if( _Containerloadtypeid == value ) return;
		
				_Containerloadtypeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Containerloadtypeid");
			}
		}
		public Int32? Billofladingconvanid
		{
			get { return _Billofladingconvanid; }
			set
			{
				if( _Billofladingconvanid == value ) return;
		
				_Billofladingconvanid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Billofladingconvanid");
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
		public string Descriptionofgoodstext
		{
			get { return _Descriptionofgoodstext; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Descriptionofgoodstext, val, false) == 0 ) return;
		
				if( val != null && val.Length > DescriptionofgoodstextMax )
					_Descriptionofgoodstext = val.Substring(0, (int)DescriptionofgoodstextMax);
				else
					_Descriptionofgoodstext = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Descriptionofgoodstext");
			}
		}
		public string Item_Kop_Cd
		{
			get { return _Item_Kop_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Kop_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_Kop_CdMax )
					_Item_Kop_Cd = val.Substring(0, (int)Item_Kop_CdMax);
				else
					_Item_Kop_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Kop_Cd");
			}
		}
		public string Item_Kop_Dsc
		{
			get { return _Item_Kop_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Kop_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_Kop_DscMax )
					_Item_Kop_Dsc = val.Substring(0, (int)Item_Kop_DscMax);
				else
					_Item_Kop_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Kop_Dsc");
			}
		}
		public string Item_Commodity_Cd
		{
			get { return _Item_Commodity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Commodity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_Commodity_CdMax )
					_Item_Commodity_Cd = val.Substring(0, (int)Item_Commodity_CdMax);
				else
					_Item_Commodity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Commodity_Cd");
			}
		}
		public string Item_Commodity_Name
		{
			get { return _Item_Commodity_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Commodity_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_Commodity_NameMax )
					_Item_Commodity_Name = val.Substring(0, (int)Item_Commodity_NameMax);
				else
					_Item_Commodity_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Commodity_Name");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBolCargo() : base() {}
		public ClsVwArcBolCargo(DataRow dr) : base(dr) {}
		public ClsVwArcBolCargo(ClsVwArcBolCargo src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Bol_ID = null;
			Bol_No = null;
			Booking_No = null;
			Item_ID = null;
			Item_No = null;
			Cargo_Type = null;
			Marksandnumbers = null;
			Serial_No = null;
			Kop_Cd = null;
			Kop_Dsc = null;
			Cargo_Commodity_Cd = null;
			Cargo_Commodity_Name = null;
			Item_Dog = null;
			Item_Dog_Txt = null;
			Handling_Ind_Cd = null;
			Handling_Ind_Dsc = null;
			Transfer_Gear_Cd = null;
			Transfer_Gear_Dsc = null;
			Axlecount = null;
			Year = null;
			Manufacturer = null;
			Model = null;
			Trim = null;
			Numberofpackages = null;
			Descriptionofgoods = null;
			Containernumber = null;
			Containerloadtypeid = null;
			Billofladingconvanid = null;
			Weight = null;
			Containertareweight = null;
			Length = null;
			Width = null;
			Height = null;
			Cubicmeter = null;
			Squaremeter = null;
			Dockreceipt = null;
			Piecenumber = null;
			Descriptionofgoodstext = null;
			Item_Kop_Cd = null;
			Item_Kop_Dsc = null;
			Item_Commodity_Cd = null;
			Item_Commodity_Name = null;
		}

		public void CopyFrom(ClsVwArcBolCargo src)
		{
			Bol_ID = src._Bol_ID;
			Bol_No = src._Bol_No;
			Booking_No = src._Booking_No;
			Item_ID = src._Item_ID;
			Item_No = src._Item_No;
			Cargo_Type = src._Cargo_Type;
			Marksandnumbers = src._Marksandnumbers;
			Serial_No = src._Serial_No;
			Kop_Cd = src._Kop_Cd;
			Kop_Dsc = src._Kop_Dsc;
			Cargo_Commodity_Cd = src._Cargo_Commodity_Cd;
			Cargo_Commodity_Name = src._Cargo_Commodity_Name;
			Item_Dog = src._Item_Dog;
			Item_Dog_Txt = src._Item_Dog_Txt;
			Handling_Ind_Cd = src._Handling_Ind_Cd;
			Handling_Ind_Dsc = src._Handling_Ind_Dsc;
			Transfer_Gear_Cd = src._Transfer_Gear_Cd;
			Transfer_Gear_Dsc = src._Transfer_Gear_Dsc;
			Axlecount = src._Axlecount;
			Year = src._Year;
			Manufacturer = src._Manufacturer;
			Model = src._Model;
			Trim = src._Trim;
			Numberofpackages = src._Numberofpackages;
			Descriptionofgoods = src._Descriptionofgoods;
			Containernumber = src._Containernumber;
			Containerloadtypeid = src._Containerloadtypeid;
			Billofladingconvanid = src._Billofladingconvanid;
			Weight = src._Weight;
			Containertareweight = src._Containertareweight;
			Length = src._Length;
			Width = src._Width;
			Height = src._Height;
			Cubicmeter = src._Cubicmeter;
			Squaremeter = src._Squaremeter;
			Dockreceipt = src._Dockreceipt;
			Piecenumber = src._Piecenumber;
			Descriptionofgoodstext = src._Descriptionofgoodstext;
			Item_Kop_Cd = src._Item_Kop_Cd;
			Item_Kop_Dsc = src._Item_Kop_Dsc;
			Item_Commodity_Cd = src._Item_Commodity_Cd;
			Item_Commodity_Name = src._Item_Commodity_Name;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBolCargo tmp = null;	//No primary key can't refresh;
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
				("@bol_id", Bol_ID);
			p[1] = Connection.GetParameter
				("@bol_no", Bol_No);
			p[2] = Connection.GetParameter
				("@booking_no", Booking_No);
			p[3] = Connection.GetParameter
				("@Item_id", Item_ID);
			p[4] = Connection.GetParameter
				("@Item_no", Item_No);
			p[5] = Connection.GetParameter
				("@cargo_type", Cargo_Type);
			p[6] = Connection.GetParameter
				("@MarksAndNumbers", Marksandnumbers);
			p[7] = Connection.GetParameter
				("@Serial_no", Serial_No);
			p[8] = Connection.GetParameter
				("@kop_cd", Kop_Cd);
			p[9] = Connection.GetParameter
				("@kop_dsc", Kop_Dsc);
			p[10] = Connection.GetParameter
				("@cargo_commodity_cd", Cargo_Commodity_Cd);
			p[11] = Connection.GetParameter
				("@cargo_commodity_name", Cargo_Commodity_Name);
			p[12] = Connection.GetParameter
				("@Item_dog", Item_Dog);
			p[13] = Connection.GetParameter
				("@item_dog_txt", Item_Dog_Txt);
			p[14] = Connection.GetParameter
				("@Handling_Ind_Cd", Handling_Ind_Cd);
			p[15] = Connection.GetParameter
				("@Handling_Ind_Dsc", Handling_Ind_Dsc);
			p[16] = Connection.GetParameter
				("@Transfer_Gear_Cd", Transfer_Gear_Cd);
			p[17] = Connection.GetParameter
				("@Transfer_Gear_Dsc", Transfer_Gear_Dsc);
			p[18] = Connection.GetParameter
				("@AxleCount", Axlecount);
			p[19] = Connection.GetParameter
				("@Year", Year);
			p[20] = Connection.GetParameter
				("@Manufacturer", Manufacturer);
			p[21] = Connection.GetParameter
				("@Model", Model);
			p[22] = Connection.GetParameter
				("@Trim", Trim);
			p[23] = Connection.GetParameter
				("@NumberOfPackages", Numberofpackages);
			p[24] = Connection.GetParameter
				("@DescriptionOfGoods", Descriptionofgoods);
			p[25] = Connection.GetParameter
				("@ContainerNumber", Containernumber);
			p[26] = Connection.GetParameter
				("@ContainerLoadTypeId", Containerloadtypeid);
			p[27] = Connection.GetParameter
				("@BillOfLadingConvanId", Billofladingconvanid);
			p[28] = Connection.GetParameter
				("@Weight", Weight);
			p[29] = Connection.GetParameter
				("@ContainerTareWeight", Containertareweight);
			p[30] = Connection.GetParameter
				("@Length", Length);
			p[31] = Connection.GetParameter
				("@Width", Width);
			p[32] = Connection.GetParameter
				("@Height", Height);
			p[33] = Connection.GetParameter
				("@CubicMeter", Cubicmeter);
			p[34] = Connection.GetParameter
				("@SquareMeter", Squaremeter);
			p[35] = Connection.GetParameter
				("@DockReceipt", Dockreceipt);
			p[36] = Connection.GetParameter
				("@PieceNumber", Piecenumber);
			p[37] = Connection.GetParameter
				("@DescriptionOfGoodsText", Descriptionofgoodstext);
			p[38] = Connection.GetParameter
				("@item_kop_cd", Item_Kop_Cd);
			p[39] = Connection.GetParameter
				("@item_kop_dsc", Item_Kop_Dsc);
			p[40] = Connection.GetParameter
				("@item_commodity_cd", Item_Commodity_Cd);
			p[41] = Connection.GetParameter
				("@item_commodity_name", Item_Commodity_Name);

			const string sql = @"INSERT INTO vw_arc_bol_cargo VALUES
				(@bol_id,@bol_no,@booking_no
				,@Item_id,@Item_no,@cargo_type
				,@MarksAndNumbers,@Serial_no,@kop_cd
				,@kop_dsc,@cargo_commodity_cd,@cargo_commodity_name
				,@Item_dog,@item_dog_txt,@Handling_Ind_Cd
				,@Handling_Ind_Dsc,@Transfer_Gear_Cd,@Transfer_Gear_Dsc
				,@AxleCount,@Year,@Manufacturer
				,@Model,@Trim,@NumberOfPackages
				,@DescriptionOfGoods,@ContainerNumber,@ContainerLoadTypeId
				,@BillOfLadingConvanId,@Weight,@ContainerTareWeight
				,@Length,@Width,@Height
				,@CubicMeter,@SquareMeter,@DockReceipt
				,@PieceNumber,@DescriptionOfGoodsText,@item_kop_cd
				,@item_kop_dsc,@item_commodity_cd,@item_commodity_name)";
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

			Bol_ID = ClsConvert.ToInt32Nullable(dr["bol_id"]);
			Bol_No = ClsConvert.ToString(dr["bol_no"]);
			Booking_No = ClsConvert.ToString(dr["booking_no"]);
			Item_ID = ClsConvert.ToInt32Nullable(dr["Item_id"]);
			Item_No = ClsConvert.ToInt32Nullable(dr["Item_no"]);
			Cargo_Type = ClsConvert.ToString(dr["cargo_type"]);
			Marksandnumbers = ClsConvert.ToString(dr["MarksAndNumbers"]);
			Serial_No = ClsConvert.ToString(dr["Serial_no"]);
			Kop_Cd = ClsConvert.ToString(dr["kop_cd"]);
			Kop_Dsc = ClsConvert.ToString(dr["kop_dsc"]);
			Cargo_Commodity_Cd = ClsConvert.ToString(dr["cargo_commodity_cd"]);
			Cargo_Commodity_Name = ClsConvert.ToString(dr["cargo_commodity_name"]);
			Item_Dog = ClsConvert.ToString(dr["Item_dog"]);
			Item_Dog_Txt = ClsConvert.ToString(dr["item_dog_txt"]);
			Handling_Ind_Cd = ClsConvert.ToString(dr["Handling_Ind_Cd"]);
			Handling_Ind_Dsc = ClsConvert.ToString(dr["Handling_Ind_Dsc"]);
			Transfer_Gear_Cd = ClsConvert.ToString(dr["Transfer_Gear_Cd"]);
			Transfer_Gear_Dsc = ClsConvert.ToString(dr["Transfer_Gear_Dsc"]);
			Axlecount = ClsConvert.ToInt32Nullable(dr["AxleCount"]);
			Year = ClsConvert.ToInt32Nullable(dr["Year"]);
			Manufacturer = ClsConvert.ToString(dr["Manufacturer"]);
			Model = ClsConvert.ToString(dr["Model"]);
			Trim = ClsConvert.ToString(dr["Trim"]);
			Numberofpackages = ClsConvert.ToInt32Nullable(dr["NumberOfPackages"]);
			Descriptionofgoods = ClsConvert.ToString(dr["DescriptionOfGoods"]);
			Containernumber = ClsConvert.ToString(dr["ContainerNumber"]);
			Containerloadtypeid = ClsConvert.ToInt32Nullable(dr["ContainerLoadTypeId"]);
			Billofladingconvanid = ClsConvert.ToInt32Nullable(dr["BillOfLadingConvanId"]);
			Weight = ClsConvert.ToDoubleNullable(dr["Weight"]);
			Containertareweight = ClsConvert.ToDoubleNullable(dr["ContainerTareWeight"]);
			Length = ClsConvert.ToDoubleNullable(dr["Length"]);
			Width = ClsConvert.ToDoubleNullable(dr["Width"]);
			Height = ClsConvert.ToDoubleNullable(dr["Height"]);
			Cubicmeter = ClsConvert.ToDoubleNullable(dr["CubicMeter"]);
			Squaremeter = ClsConvert.ToDoubleNullable(dr["SquareMeter"]);
			Dockreceipt = ClsConvert.ToString(dr["DockReceipt"]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber"]);
			Descriptionofgoodstext = ClsConvert.ToString(dr["DescriptionOfGoodsText"]);
			Item_Kop_Cd = ClsConvert.ToString(dr["item_kop_cd"]);
			Item_Kop_Dsc = ClsConvert.ToString(dr["item_kop_dsc"]);
			Item_Commodity_Cd = ClsConvert.ToString(dr["item_commodity_cd"]);
			Item_Commodity_Name = ClsConvert.ToString(dr["item_commodity_name"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Bol_ID = ClsConvert.ToInt32Nullable(dr["bol_id", v]);
			Bol_No = ClsConvert.ToString(dr["bol_no", v]);
			Booking_No = ClsConvert.ToString(dr["booking_no", v]);
			Item_ID = ClsConvert.ToInt32Nullable(dr["Item_id", v]);
			Item_No = ClsConvert.ToInt32Nullable(dr["Item_no", v]);
			Cargo_Type = ClsConvert.ToString(dr["cargo_type", v]);
			Marksandnumbers = ClsConvert.ToString(dr["MarksAndNumbers", v]);
			Serial_No = ClsConvert.ToString(dr["Serial_no", v]);
			Kop_Cd = ClsConvert.ToString(dr["kop_cd", v]);
			Kop_Dsc = ClsConvert.ToString(dr["kop_dsc", v]);
			Cargo_Commodity_Cd = ClsConvert.ToString(dr["cargo_commodity_cd", v]);
			Cargo_Commodity_Name = ClsConvert.ToString(dr["cargo_commodity_name", v]);
			Item_Dog = ClsConvert.ToString(dr["Item_dog", v]);
			Item_Dog_Txt = ClsConvert.ToString(dr["item_dog_txt", v]);
			Handling_Ind_Cd = ClsConvert.ToString(dr["Handling_Ind_Cd", v]);
			Handling_Ind_Dsc = ClsConvert.ToString(dr["Handling_Ind_Dsc", v]);
			Transfer_Gear_Cd = ClsConvert.ToString(dr["Transfer_Gear_Cd", v]);
			Transfer_Gear_Dsc = ClsConvert.ToString(dr["Transfer_Gear_Dsc", v]);
			Axlecount = ClsConvert.ToInt32Nullable(dr["AxleCount", v]);
			Year = ClsConvert.ToInt32Nullable(dr["Year", v]);
			Manufacturer = ClsConvert.ToString(dr["Manufacturer", v]);
			Model = ClsConvert.ToString(dr["Model", v]);
			Trim = ClsConvert.ToString(dr["Trim", v]);
			Numberofpackages = ClsConvert.ToInt32Nullable(dr["NumberOfPackages", v]);
			Descriptionofgoods = ClsConvert.ToString(dr["DescriptionOfGoods", v]);
			Containernumber = ClsConvert.ToString(dr["ContainerNumber", v]);
			Containerloadtypeid = ClsConvert.ToInt32Nullable(dr["ContainerLoadTypeId", v]);
			Billofladingconvanid = ClsConvert.ToInt32Nullable(dr["BillOfLadingConvanId", v]);
			Weight = ClsConvert.ToDoubleNullable(dr["Weight", v]);
			Containertareweight = ClsConvert.ToDoubleNullable(dr["ContainerTareWeight", v]);
			Length = ClsConvert.ToDoubleNullable(dr["Length", v]);
			Width = ClsConvert.ToDoubleNullable(dr["Width", v]);
			Height = ClsConvert.ToDoubleNullable(dr["Height", v]);
			Cubicmeter = ClsConvert.ToDoubleNullable(dr["CubicMeter", v]);
			Squaremeter = ClsConvert.ToDoubleNullable(dr["SquareMeter", v]);
			Dockreceipt = ClsConvert.ToString(dr["DockReceipt", v]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber", v]);
			Descriptionofgoodstext = ClsConvert.ToString(dr["DescriptionOfGoodsText", v]);
			Item_Kop_Cd = ClsConvert.ToString(dr["item_kop_cd", v]);
			Item_Kop_Dsc = ClsConvert.ToString(dr["item_kop_dsc", v]);
			Item_Commodity_Cd = ClsConvert.ToString(dr["item_commodity_cd", v]);
			Item_Commodity_Name = ClsConvert.ToString(dr["item_commodity_name", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["bol_id"] = ClsConvert.ToDbObject(Bol_ID);
			dr["bol_no"] = ClsConvert.ToDbObject(Bol_No);
			dr["booking_no"] = ClsConvert.ToDbObject(Booking_No);
			dr["Item_id"] = ClsConvert.ToDbObject(Item_ID);
			dr["Item_no"] = ClsConvert.ToDbObject(Item_No);
			dr["cargo_type"] = ClsConvert.ToDbObject(Cargo_Type);
			dr["MarksAndNumbers"] = ClsConvert.ToDbObject(Marksandnumbers);
			dr["Serial_no"] = ClsConvert.ToDbObject(Serial_No);
			dr["kop_cd"] = ClsConvert.ToDbObject(Kop_Cd);
			dr["kop_dsc"] = ClsConvert.ToDbObject(Kop_Dsc);
			dr["cargo_commodity_cd"] = ClsConvert.ToDbObject(Cargo_Commodity_Cd);
			dr["cargo_commodity_name"] = ClsConvert.ToDbObject(Cargo_Commodity_Name);
			dr["Item_dog"] = ClsConvert.ToDbObject(Item_Dog);
			dr["item_dog_txt"] = ClsConvert.ToDbObject(Item_Dog_Txt);
			dr["Handling_Ind_Cd"] = ClsConvert.ToDbObject(Handling_Ind_Cd);
			dr["Handling_Ind_Dsc"] = ClsConvert.ToDbObject(Handling_Ind_Dsc);
			dr["Transfer_Gear_Cd"] = ClsConvert.ToDbObject(Transfer_Gear_Cd);
			dr["Transfer_Gear_Dsc"] = ClsConvert.ToDbObject(Transfer_Gear_Dsc);
			dr["AxleCount"] = ClsConvert.ToDbObject(Axlecount);
			dr["Year"] = ClsConvert.ToDbObject(Year);
			dr["Manufacturer"] = ClsConvert.ToDbObject(Manufacturer);
			dr["Model"] = ClsConvert.ToDbObject(Model);
			dr["Trim"] = ClsConvert.ToDbObject(Trim);
			dr["NumberOfPackages"] = ClsConvert.ToDbObject(Numberofpackages);
			dr["DescriptionOfGoods"] = ClsConvert.ToDbObject(Descriptionofgoods);
			dr["ContainerNumber"] = ClsConvert.ToDbObject(Containernumber);
			dr["ContainerLoadTypeId"] = ClsConvert.ToDbObject(Containerloadtypeid);
			dr["BillOfLadingConvanId"] = ClsConvert.ToDbObject(Billofladingconvanid);
			dr["Weight"] = ClsConvert.ToDbObject(Weight);
			dr["ContainerTareWeight"] = ClsConvert.ToDbObject(Containertareweight);
			dr["Length"] = ClsConvert.ToDbObject(Length);
			dr["Width"] = ClsConvert.ToDbObject(Width);
			dr["Height"] = ClsConvert.ToDbObject(Height);
			dr["CubicMeter"] = ClsConvert.ToDbObject(Cubicmeter);
			dr["SquareMeter"] = ClsConvert.ToDbObject(Squaremeter);
			dr["DockReceipt"] = ClsConvert.ToDbObject(Dockreceipt);
			dr["PieceNumber"] = ClsConvert.ToDbObject(Piecenumber);
			dr["DescriptionOfGoodsText"] = ClsConvert.ToDbObject(Descriptionofgoodstext);
			dr["item_kop_cd"] = ClsConvert.ToDbObject(Item_Kop_Cd);
			dr["item_kop_dsc"] = ClsConvert.ToDbObject(Item_Kop_Dsc);
			dr["item_commodity_cd"] = ClsConvert.ToDbObject(Item_Commodity_Cd);
			dr["item_commodity_name"] = ClsConvert.ToDbObject(Item_Commodity_Name);
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