using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi322 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI322";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI322_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI322 
				INNER JOIN T_ISA
				ON T_EDI322.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Cargo_KeyMax = 30;
		public const int Serial_NoMax = 50;
		public const int Description_Of_GoodsMax = 50;
		public const int Kind_Of_PkgMax = 10;
		public const int Activity_CdMax = 10;
		public const int Booking_NoMax = 30;
		public const int Bol_NoMax = 30;
		public const int Location_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Plor_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Plod_Location_CdMax = 10;
		public const int MsgMax = 200;
		public const int Processed_FlgMax = 1;
		public const int Truck_NoMax = 30;
		public const int Doc_Receipt_NoMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi322_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected decimal? _Isa_Nbr;
		protected string _Cargo_Key;
		protected decimal? _Cargo_Line_ID;
		protected string _Serial_No;
		protected string _Description_Of_Goods;
		protected string _Kind_Of_Pkg;
		protected DateTime? _Activity_Dt;
		protected string _Activity_Cd;
		protected string _Booking_No;
		protected string _Bol_No;
		protected string _Location_Cd;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected DateTime? _Departure_Dt;
		protected DateTime? _Arrival_Dt;
		protected string _Plor_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Plod_Location_Cd;
		protected decimal? _Length_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Weight_Nbr;
		protected string _Msg;
		protected string _Processed_Flg;
		protected string _Truck_No;
		protected string _Doc_Receipt_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi322_ID
		{
			get { return _Edi322_ID; }
			set
			{
				if( _Edi322_ID == value ) return;
		
				_Edi322_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi322_ID");
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
		public decimal? Isa_Nbr
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
		public decimal? Cargo_Line_ID
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
		public string Description_Of_Goods
		{
			get { return _Description_Of_Goods; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Description_Of_Goods, val, false) == 0 ) return;
		
				if( val != null && val.Length > Description_Of_GoodsMax )
					_Description_Of_Goods = val.Substring(0, (int)Description_Of_GoodsMax);
				else
					_Description_Of_Goods = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Description_Of_Goods");
			}
		}
		public string Kind_Of_Pkg
		{
			get { return _Kind_Of_Pkg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Kind_Of_Pkg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Kind_Of_PkgMax )
					_Kind_Of_Pkg = val.Substring(0, (int)Kind_Of_PkgMax);
				else
					_Kind_Of_Pkg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Kind_Of_Pkg");
			}
		}
		public DateTime? Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				if( _Activity_Dt == value ) return;
		
				_Activity_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
			}
		}
		public string Activity_Cd
		{
			get { return _Activity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CdMax )
					_Activity_Cd = val.Substring(0, (int)Activity_CdMax);
				else
					_Activity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Cd");
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
		public string Location_Cd
		{
			get { return _Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_CdMax )
					_Location_Cd = val.Substring(0, (int)Location_CdMax);
				else
					_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Cd");
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
		public DateTime? Departure_Dt
		{
			get { return _Departure_Dt; }
			set
			{
				if( _Departure_Dt == value ) return;
		
				_Departure_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Dt");
			}
		}
		public DateTime? Arrival_Dt
		{
			get { return _Arrival_Dt; }
			set
			{
				if( _Arrival_Dt == value ) return;
		
				_Arrival_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Dt");
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
		public string Msg
		{
			get { return _Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > MsgMax )
					_Msg = val.Substring(0, (int)MsgMax);
				else
					_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Msg");
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
		public string Truck_No
		{
			get { return _Truck_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Truck_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Truck_NoMax )
					_Truck_No = val.Substring(0, (int)Truck_NoMax);
				else
					_Truck_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Truck_No");
			}
		}
		public string Doc_Receipt_No
		{
			get { return _Doc_Receipt_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Doc_Receipt_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Doc_Receipt_NoMax )
					_Doc_Receipt_No = val.Substring(0, (int)Doc_Receipt_NoMax);
				else
					_Doc_Receipt_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Doc_Receipt_No");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi322() : base() {}
		public ClsEdi322(DataRow dr) : base(dr) {}
		public ClsEdi322(ClsEdi322 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi322_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Cargo_Key = null;
			Cargo_Line_ID = null;
			Serial_No = null;
			Description_Of_Goods = null;
			Kind_Of_Pkg = null;
			Activity_Dt = null;
			Activity_Cd = null;
			Booking_No = null;
			Bol_No = null;
			Location_Cd = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Departure_Dt = null;
			Arrival_Dt = null;
			Plor_Location_Cd = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Plod_Location_Cd = null;
			Length_Nbr = null;
			Height_Nbr = null;
			Width_Nbr = null;
			Weight_Nbr = null;
			Msg = null;
			Processed_Flg = null;
			Truck_No = null;
			Doc_Receipt_No = null;
		}

		public void CopyFrom(ClsEdi322 src)
		{
			Edi322_ID = src._Edi322_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Cargo_Key = src._Cargo_Key;
			Cargo_Line_ID = src._Cargo_Line_ID;
			Serial_No = src._Serial_No;
			Description_Of_Goods = src._Description_Of_Goods;
			Kind_Of_Pkg = src._Kind_Of_Pkg;
			Activity_Dt = src._Activity_Dt;
			Activity_Cd = src._Activity_Cd;
			Booking_No = src._Booking_No;
			Bol_No = src._Bol_No;
			Location_Cd = src._Location_Cd;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Departure_Dt = src._Departure_Dt;
			Arrival_Dt = src._Arrival_Dt;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Length_Nbr = src._Length_Nbr;
			Height_Nbr = src._Height_Nbr;
			Width_Nbr = src._Width_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Msg = src._Msg;
			Processed_Flg = src._Processed_Flg;
			Truck_No = src._Truck_No;
			Doc_Receipt_No = src._Doc_Receipt_No;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi322 tmp = ClsEdi322.GetUsingKey(Edi322_ID.Value);
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

			DbParameter[] p = new DbParameter[33];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[3] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[4] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[5] = Connection.GetParameter
				("@DESCRIPTION_OF_GOODS", Description_Of_Goods);
			p[6] = Connection.GetParameter
				("@KIND_OF_PKG", Kind_Of_Pkg);
			p[7] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[8] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[9] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[10] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[11] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[12] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[13] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[14] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[15] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[16] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[17] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[18] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[19] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[20] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[21] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[22] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[23] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[24] = Connection.GetParameter
				("@MSG", Msg);
			p[25] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[26] = Connection.GetParameter
				("@TRUCK_NO", Truck_No);
			p[27] = Connection.GetParameter
				("@DOC_RECEIPT_NO", Doc_Receipt_No);
			p[28] = Connection.GetParameter
				("@EDI322_ID", Edi322_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[29] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[30] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[31] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[32] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI322
					(EDI322_ID, ISA_ID, ISA_NBR,
					CARGO_KEY, CARGO_LINE_ID, SERIAL_NO,
					DESCRIPTION_OF_GOODS, KIND_OF_PKG, ACTIVITY_DT,
					ACTIVITY_CD, BOOKING_NO, BOL_NO,
					LOCATION_CD, VOYAGE_NO, VESSEL_CD,
					DEPARTURE_DT, ARRIVAL_DT, PLOR_LOCATION_CD,
					POL_LOCATION_CD, POD_LOCATION_CD, PLOD_LOCATION_CD,
					LENGTH_NBR, HEIGHT_NBR, WIDTH_NBR,
					WEIGHT_NBR, MSG, PROCESSED_FLG,
					TRUCK_NO, DOC_RECEIPT_NO)
				VALUES
					(EDI322_ID_SEQ.NEXTVAL, @ISA_ID, @ISA_NBR,
					@CARGO_KEY, @CARGO_LINE_ID, @SERIAL_NO,
					@DESCRIPTION_OF_GOODS, @KIND_OF_PKG, @ACTIVITY_DT,
					@ACTIVITY_CD, @BOOKING_NO, @BOL_NO,
					@LOCATION_CD, @VOYAGE_NO, @VESSEL_CD,
					@DEPARTURE_DT, @ARRIVAL_DT, @PLOR_LOCATION_CD,
					@POL_LOCATION_CD, @POD_LOCATION_CD, @PLOD_LOCATION_CD,
					@LENGTH_NBR, @HEIGHT_NBR, @WIDTH_NBR,
					@WEIGHT_NBR, @MSG, @PROCESSED_FLG,
					@TRUCK_NO, @DOC_RECEIPT_NO)
				RETURNING
					EDI322_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI322_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi322_ID = ClsConvert.ToInt64Nullable(p[28].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[29].Value);
			Create_User = ClsConvert.ToString(p[30].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[31].Value);
			Modify_User = ClsConvert.ToString(p[32].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[31];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[4] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[5] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[6] = Connection.GetParameter
				("@DESCRIPTION_OF_GOODS", Description_Of_Goods);
			p[7] = Connection.GetParameter
				("@KIND_OF_PKG", Kind_Of_Pkg);
			p[8] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[9] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[10] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[11] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[12] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[13] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[14] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[15] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[16] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[17] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[18] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[19] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[20] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[21] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[22] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[23] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[24] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[25] = Connection.GetParameter
				("@MSG", Msg);
			p[26] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[27] = Connection.GetParameter
				("@TRUCK_NO", Truck_No);
			p[28] = Connection.GetParameter
				("@DOC_RECEIPT_NO", Doc_Receipt_No);
			p[29] = Connection.GetParameter
				("@EDI322_ID", Edi322_ID);
			p[30] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI322 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					CARGO_KEY = @CARGO_KEY,
					CARGO_LINE_ID = @CARGO_LINE_ID,
					SERIAL_NO = @SERIAL_NO,
					DESCRIPTION_OF_GOODS = @DESCRIPTION_OF_GOODS,
					KIND_OF_PKG = @KIND_OF_PKG,
					ACTIVITY_DT = @ACTIVITY_DT,
					ACTIVITY_CD = @ACTIVITY_CD,
					BOOKING_NO = @BOOKING_NO,
					BOL_NO = @BOL_NO,
					LOCATION_CD = @LOCATION_CD,
					VOYAGE_NO = @VOYAGE_NO,
					VESSEL_CD = @VESSEL_CD,
					DEPARTURE_DT = @DEPARTURE_DT,
					ARRIVAL_DT = @ARRIVAL_DT,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					LENGTH_NBR = @LENGTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					MSG = @MSG,
					PROCESSED_FLG = @PROCESSED_FLG,
					TRUCK_NO = @TRUCK_NO,
					DOC_RECEIPT_NO = @DOC_RECEIPT_NO
				WHERE
					EDI322_ID = @EDI322_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[30].Value);
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

			Edi322_ID = ClsConvert.ToInt64Nullable(dr["EDI322_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Cargo_Line_ID = ClsConvert.ToDecimalNullable(dr["CARGO_LINE_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Description_Of_Goods = ClsConvert.ToString(dr["DESCRIPTION_OF_GOODS"]);
			Kind_Of_Pkg = ClsConvert.ToString(dr["KIND_OF_PKG"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT"]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Msg = ClsConvert.ToString(dr["MSG"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Truck_No = ClsConvert.ToString(dr["TRUCK_NO"]);
			Doc_Receipt_No = ClsConvert.ToString(dr["DOC_RECEIPT_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi322_ID = ClsConvert.ToInt64Nullable(dr["EDI322_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Cargo_Line_ID = ClsConvert.ToDecimalNullable(dr["CARGO_LINE_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Description_Of_Goods = ClsConvert.ToString(dr["DESCRIPTION_OF_GOODS", v]);
			Kind_Of_Pkg = ClsConvert.ToString(dr["KIND_OF_PKG", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT", v]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Msg = ClsConvert.ToString(dr["MSG", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Truck_No = ClsConvert.ToString(dr["TRUCK_NO", v]);
			Doc_Receipt_No = ClsConvert.ToString(dr["DOC_RECEIPT_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI322_ID"] = ClsConvert.ToDbObject(Edi322_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["DESCRIPTION_OF_GOODS"] = ClsConvert.ToDbObject(Description_Of_Goods);
			dr["KIND_OF_PKG"] = ClsConvert.ToDbObject(Kind_Of_Pkg);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["DEPARTURE_DT"] = ClsConvert.ToDbObject(Departure_Dt);
			dr["ARRIVAL_DT"] = ClsConvert.ToDbObject(Arrival_Dt);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["MSG"] = ClsConvert.ToDbObject(Msg);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["TRUCK_NO"] = ClsConvert.ToDbObject(Truck_No);
			dr["DOC_RECEIPT_NO"] = ClsConvert.ToDbObject(Doc_Receipt_No);
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

		public static ClsEdi322 GetUsingKey(Int64 Edi322_ID)
		{
			object[] vals = new object[] {Edi322_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi322(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI322.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}