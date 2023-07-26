using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLobDetail : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
            get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_LOB_DETAIL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LOB_DETAIL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_LOB_DETAIL 
				INNER JOIN T_LOB_HEADER
				ON T_LOB_DETAIL.LOB_HEADER_ID=T_LOB_HEADER.LOB_HEADER_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Booking_NoMax = 25;
		public const int Cargo_DscMax = 100;
		public const int Comment_OneMax = 100;
		public const int Comment_TwoMax = 100;
		public const int Consignee_DodaacMax = 20;
		public const int Consignor_DodaacMax = 20;
		public const int Container_NoMax = 20;
		public const int Vd_FlgMax = 1;
		public const int Si_FlgMax = 1;
		public const int Booked_FlgMax = 1;
		public const int Manifested_FlgMax = 1;
		public const int PcfnMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int TcnMax = 50;
		public const int Vessel_Status_CdMax = 10;
		public const int Van_TypeMax = 20;
		public const int Commodity_CdMax = 10;
		public const int Bol_NoMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Lob_Detail_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Lob_Header_ID;
		protected string _Booking_No;
		protected string _Cargo_Dsc;
		protected string _Comment_One;
		protected string _Comment_Two;
		protected string _Consignee_Dodaac;
		protected string _Consignor_Dodaac;
		protected string _Container_No;
		protected decimal? _Cube_Nbr;
		protected string _Vd_Flg;
		protected string _Si_Flg;
		protected string _Booked_Flg;
		protected string _Manifested_Flg;
		protected decimal? _Height_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Length_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Mton_Nbr;
		protected string _Pcfn;
		protected string _Pod_Location_Cd;
		protected string _Tcn;
		protected string _Vessel_Status_Cd;
		protected string _Van_Type;
		protected string _Commodity_Cd;
		protected DateTime? _Rdd_Dt;
		protected string _Bol_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Lob_Detail_ID
		{
			get { return _Lob_Detail_ID; }
			set
			{
				if( _Lob_Detail_ID == value ) return;
		
				_Lob_Detail_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lob_Detail_ID");
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
		public Int64? Lob_Header_ID
		{
			get { return _Lob_Header_ID; }
			set
			{
				if( _Lob_Header_ID == value ) return;
		
				_Lob_Header_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lob_Header_ID");
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
		public string Comment_One
		{
			get { return _Comment_One; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Comment_One, val, false) == 0 ) return;
		
				if( val != null && val.Length > Comment_OneMax )
					_Comment_One = val.Substring(0, (int)Comment_OneMax);
				else
					_Comment_One = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Comment_One");
			}
		}
		public string Comment_Two
		{
			get { return _Comment_Two; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Comment_Two, val, false) == 0 ) return;
		
				if( val != null && val.Length > Comment_TwoMax )
					_Comment_Two = val.Substring(0, (int)Comment_TwoMax);
				else
					_Comment_Two = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Comment_Two");
			}
		}
		public string Consignee_Dodaac
		{
			get { return _Consignee_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Consignee_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Consignee_DodaacMax )
					_Consignee_Dodaac = val.Substring(0, (int)Consignee_DodaacMax);
				else
					_Consignee_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Consignee_Dodaac");
			}
		}
		public string Consignor_Dodaac
		{
			get { return _Consignor_Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Consignor_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > Consignor_DodaacMax )
					_Consignor_Dodaac = val.Substring(0, (int)Consignor_DodaacMax);
				else
					_Consignor_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Consignor_Dodaac");
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
		public decimal? Cube_Nbr
		{
			get { return _Cube_Nbr; }
			set
			{
				if( _Cube_Nbr == value ) return;
		
				_Cube_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cube_Nbr");
			}
		}
		public string Vd_Flg
		{
			get { return _Vd_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vd_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vd_FlgMax )
					_Vd_Flg = val.Substring(0, (int)Vd_FlgMax);
				else
					_Vd_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vd_Flg");
			}
		}
		public string Si_Flg
		{
			get { return _Si_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Si_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Si_FlgMax )
					_Si_Flg = val.Substring(0, (int)Si_FlgMax);
				else
					_Si_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Si_Flg");
			}
		}
		public string Booked_Flg
		{
			get { return _Booked_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booked_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booked_FlgMax )
					_Booked_Flg = val.Substring(0, (int)Booked_FlgMax);
				else
					_Booked_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booked_Flg");
			}
		}
		public string Manifested_Flg
		{
			get { return _Manifested_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Manifested_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Manifested_FlgMax )
					_Manifested_Flg = val.Substring(0, (int)Manifested_FlgMax);
				else
					_Manifested_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Manifested_Flg");
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
		public decimal? Mton_Nbr
		{
			get { return _Mton_Nbr; }
			set
			{
				if( _Mton_Nbr == value ) return;
		
				_Mton_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Mton_Nbr");
			}
		}
		public string Pcfn
		{
			get { return _Pcfn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pcfn, val, false) == 0 ) return;
		
				if( val != null && val.Length > PcfnMax )
					_Pcfn = val.Substring(0, (int)PcfnMax);
				else
					_Pcfn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pcfn");
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
		public string Vessel_Status_Cd
		{
			get { return _Vessel_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_Status_CdMax )
					_Vessel_Status_Cd = val.Substring(0, (int)Vessel_Status_CdMax);
				else
					_Vessel_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Status_Cd");
			}
		}
		public string Van_Type
		{
			get { return _Van_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Van_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Van_TypeMax )
					_Van_Type = val.Substring(0, (int)Van_TypeMax);
				else
					_Van_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Van_Type");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsLobHeader _Lob_Header;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsLobHeader Lob_Header
		{
			get
			{
				if( Lob_Header_ID == null )
					_Lob_Header = null;
				else if( _Lob_Header == null ||
					_Lob_Header.Lob_Header_ID != Lob_Header_ID )
					_Lob_Header = ClsLobHeader.GetUsingKey(Lob_Header_ID.Value);
				return _Lob_Header;
			}
			set
			{
				if( _Lob_Header == value ) return;
		
				_Lob_Header = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLobDetail() : base() {}
		public ClsLobDetail(DataRow dr) : base(dr) {}
		public ClsLobDetail(ClsLobDetail src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Lob_Detail_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Lob_Header_ID = null;
			Booking_No = null;
			Cargo_Dsc = null;
			Comment_One = null;
			Comment_Two = null;
			Consignee_Dodaac = null;
			Consignor_Dodaac = null;
			Container_No = null;
			Cube_Nbr = null;
			Vd_Flg = null;
			Si_Flg = null;
			Booked_Flg = null;
			Manifested_Flg = null;
			Height_Nbr = null;
			Width_Nbr = null;
			Length_Nbr = null;
			Weight_Nbr = null;
			Mton_Nbr = null;
			Pcfn = null;
			Pod_Location_Cd = null;
			Tcn = null;
			Vessel_Status_Cd = null;
			Van_Type = null;
			Commodity_Cd = null;
			Rdd_Dt = null;
			Bol_No = null;
		}

		public void CopyFrom(ClsLobDetail src)
		{
			Lob_Detail_ID = src._Lob_Detail_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Lob_Header_ID = src._Lob_Header_ID;
			Booking_No = src._Booking_No;
			Cargo_Dsc = src._Cargo_Dsc;
			Comment_One = src._Comment_One;
			Comment_Two = src._Comment_Two;
			Consignee_Dodaac = src._Consignee_Dodaac;
			Consignor_Dodaac = src._Consignor_Dodaac;
			Container_No = src._Container_No;
			Cube_Nbr = src._Cube_Nbr;
			Vd_Flg = src._Vd_Flg;
			Si_Flg = src._Si_Flg;
			Booked_Flg = src._Booked_Flg;
			Manifested_Flg = src._Manifested_Flg;
			Height_Nbr = src._Height_Nbr;
			Width_Nbr = src._Width_Nbr;
			Length_Nbr = src._Length_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Mton_Nbr = src._Mton_Nbr;
			Pcfn = src._Pcfn;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Tcn = src._Tcn;
			Vessel_Status_Cd = src._Vessel_Status_Cd;
			Van_Type = src._Van_Type;
			Commodity_Cd = src._Commodity_Cd;
			Rdd_Dt = src._Rdd_Dt;
			Bol_No = src._Bol_No;
		}

		public override bool ReloadFromDB()
		{
			ClsLobDetail tmp = ClsLobDetail.GetUsingKey(Lob_Detail_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Lob_Header = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[31];

			p[0] = Connection.GetParameter
				("@LOB_HEADER_ID", Lob_Header_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[3] = Connection.GetParameter
				("@COMMENT_ONE", Comment_One);
			p[4] = Connection.GetParameter
				("@COMMENT_TWO", Comment_Two);
			p[5] = Connection.GetParameter
				("@CONSIGNEE_DODAAC", Consignee_Dodaac);
			p[6] = Connection.GetParameter
				("@CONSIGNOR_DODAAC", Consignor_Dodaac);
			p[7] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[8] = Connection.GetParameter
				("@CUBE_NBR", Cube_Nbr);
			p[9] = Connection.GetParameter
				("@VD_FLG", Vd_Flg);
			p[10] = Connection.GetParameter
				("@SI_FLG", Si_Flg);
			p[11] = Connection.GetParameter
				("@BOOKED_FLG", Booked_Flg);
			p[12] = Connection.GetParameter
				("@MANIFESTED_FLG", Manifested_Flg);
			p[13] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[14] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[15] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[16] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[17] = Connection.GetParameter
				("@MTON_NBR", Mton_Nbr);
			p[18] = Connection.GetParameter
				("@PCFN", Pcfn);
			p[19] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[20] = Connection.GetParameter
				("@TCN", Tcn);
			p[21] = Connection.GetParameter
				("@VESSEL_STATUS_CD", Vessel_Status_Cd);
			p[22] = Connection.GetParameter
				("@VAN_TYPE", Van_Type);
			p[23] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[24] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[25] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[26] = Connection.GetParameter
				("@LOB_DETAIL_ID", Lob_Detail_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[27] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[28] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[29] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[30] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_LOB_DETAIL
					(LOB_DETAIL_ID, LOB_HEADER_ID, BOOKING_NO,
					CARGO_DSC, COMMENT_ONE, COMMENT_TWO,
					CONSIGNEE_DODAAC, CONSIGNOR_DODAAC, CONTAINER_NO,
					CUBE_NBR, VD_FLG, SI_FLG,
					BOOKED_FLG, MANIFESTED_FLG, HEIGHT_NBR,
					WIDTH_NBR, LENGTH_NBR, WEIGHT_NBR,
					MTON_NBR, PCFN, POD_LOCATION_CD,
					TCN, VESSEL_STATUS_CD, VAN_TYPE,
					COMMODITY_CD, RDD_DT, BOL_NO)
				VALUES
					(LOB_DETAIL_ID_SEQ.NEXTVAL, @LOB_HEADER_ID, @BOOKING_NO,
					@CARGO_DSC, @COMMENT_ONE, @COMMENT_TWO,
					@CONSIGNEE_DODAAC, @CONSIGNOR_DODAAC, @CONTAINER_NO,
					@CUBE_NBR, @VD_FLG, @SI_FLG,
					@BOOKED_FLG, @MANIFESTED_FLG, @HEIGHT_NBR,
					@WIDTH_NBR, @LENGTH_NBR, @WEIGHT_NBR,
					@MTON_NBR, @PCFN, @POD_LOCATION_CD,
					@TCN, @VESSEL_STATUS_CD, @VAN_TYPE,
					@COMMODITY_CD, @RDD_DT, @BOL_NO)
				RETURNING
					LOB_DETAIL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@LOB_DETAIL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Lob_Detail_ID = ClsConvert.ToInt64Nullable(p[26].Value);
			Create_User = ClsConvert.ToString(p[27].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[28].Value);
			Modify_User = ClsConvert.ToString(p[29].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[30].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[29];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@LOB_HEADER_ID", Lob_Header_ID);
			p[2] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[3] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[4] = Connection.GetParameter
				("@COMMENT_ONE", Comment_One);
			p[5] = Connection.GetParameter
				("@COMMENT_TWO", Comment_Two);
			p[6] = Connection.GetParameter
				("@CONSIGNEE_DODAAC", Consignee_Dodaac);
			p[7] = Connection.GetParameter
				("@CONSIGNOR_DODAAC", Consignor_Dodaac);
			p[8] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[9] = Connection.GetParameter
				("@CUBE_NBR", Cube_Nbr);
			p[10] = Connection.GetParameter
				("@VD_FLG", Vd_Flg);
			p[11] = Connection.GetParameter
				("@SI_FLG", Si_Flg);
			p[12] = Connection.GetParameter
				("@BOOKED_FLG", Booked_Flg);
			p[13] = Connection.GetParameter
				("@MANIFESTED_FLG", Manifested_Flg);
			p[14] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[15] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[16] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[17] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[18] = Connection.GetParameter
				("@MTON_NBR", Mton_Nbr);
			p[19] = Connection.GetParameter
				("@PCFN", Pcfn);
			p[20] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[21] = Connection.GetParameter
				("@TCN", Tcn);
			p[22] = Connection.GetParameter
				("@VESSEL_STATUS_CD", Vessel_Status_Cd);
			p[23] = Connection.GetParameter
				("@VAN_TYPE", Van_Type);
			p[24] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[25] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[26] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[27] = Connection.GetParameter
				("@LOB_DETAIL_ID", Lob_Detail_ID);
			p[28] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_LOB_DETAIL SET
					MODIFY_DT = @MODIFY_DT,
					LOB_HEADER_ID = @LOB_HEADER_ID,
					BOOKING_NO = @BOOKING_NO,
					CARGO_DSC = @CARGO_DSC,
					COMMENT_ONE = @COMMENT_ONE,
					COMMENT_TWO = @COMMENT_TWO,
					CONSIGNEE_DODAAC = @CONSIGNEE_DODAAC,
					CONSIGNOR_DODAAC = @CONSIGNOR_DODAAC,
					CONTAINER_NO = @CONTAINER_NO,
					CUBE_NBR = @CUBE_NBR,
					VD_FLG = @VD_FLG,
					SI_FLG = @SI_FLG,
					BOOKED_FLG = @BOOKED_FLG,
					MANIFESTED_FLG = @MANIFESTED_FLG,
					HEIGHT_NBR = @HEIGHT_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					LENGTH_NBR = @LENGTH_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					MTON_NBR = @MTON_NBR,
					PCFN = @PCFN,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					TCN = @TCN,
					VESSEL_STATUS_CD = @VESSEL_STATUS_CD,
					VAN_TYPE = @VAN_TYPE,
					COMMODITY_CD = @COMMODITY_CD,
					RDD_DT = @RDD_DT,
					BOL_NO = @BOL_NO
				WHERE
					LOB_DETAIL_ID = @LOB_DETAIL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[28].Value);
			return ret;
		}
		public override int Delete()
		{
            DbParameter[] p = new DbParameter[1];

            p[0] = Connection.GetParameter
                ("@LOB_DETAIL_ID", Lob_Detail_ID);

            const string sql = @"
				DELETE FROM T_LOB_DETAIL WHERE
				LOB_DETAIL_ID=@LOB_DETAIL_ID";
            return Connection.RunSQL(sql, p);

		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Lob_Detail_ID = ClsConvert.ToInt64Nullable(dr["LOB_DETAIL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Lob_Header_ID = ClsConvert.ToInt64Nullable(dr["LOB_HEADER_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC"]);
			Comment_One = ClsConvert.ToString(dr["COMMENT_ONE"]);
			Comment_Two = ClsConvert.ToString(dr["COMMENT_TWO"]);
			Consignee_Dodaac = ClsConvert.ToString(dr["CONSIGNEE_DODAAC"]);
			Consignor_Dodaac = ClsConvert.ToString(dr["CONSIGNOR_DODAAC"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Cube_Nbr = ClsConvert.ToDecimalNullable(dr["CUBE_NBR"]);
			Vd_Flg = ClsConvert.ToString(dr["VD_FLG"]);
			Si_Flg = ClsConvert.ToString(dr["SI_FLG"]);
			Booked_Flg = ClsConvert.ToString(dr["BOOKED_FLG"]);
			Manifested_Flg = ClsConvert.ToString(dr["MANIFESTED_FLG"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Mton_Nbr = ClsConvert.ToDecimalNullable(dr["MTON_NBR"]);
			Pcfn = ClsConvert.ToString(dr["PCFN"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Vessel_Status_Cd = ClsConvert.ToString(dr["VESSEL_STATUS_CD"]);
			Van_Type = ClsConvert.ToString(dr["VAN_TYPE"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Lob_Detail_ID = ClsConvert.ToInt64Nullable(dr["LOB_DETAIL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Lob_Header_ID = ClsConvert.ToInt64Nullable(dr["LOB_HEADER_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC", v]);
			Comment_One = ClsConvert.ToString(dr["COMMENT_ONE", v]);
			Comment_Two = ClsConvert.ToString(dr["COMMENT_TWO", v]);
			Consignee_Dodaac = ClsConvert.ToString(dr["CONSIGNEE_DODAAC", v]);
			Consignor_Dodaac = ClsConvert.ToString(dr["CONSIGNOR_DODAAC", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Cube_Nbr = ClsConvert.ToDecimalNullable(dr["CUBE_NBR", v]);
			Vd_Flg = ClsConvert.ToString(dr["VD_FLG", v]);
			Si_Flg = ClsConvert.ToString(dr["SI_FLG", v]);
			Booked_Flg = ClsConvert.ToString(dr["BOOKED_FLG", v]);
			Manifested_Flg = ClsConvert.ToString(dr["MANIFESTED_FLG", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Mton_Nbr = ClsConvert.ToDecimalNullable(dr["MTON_NBR", v]);
			Pcfn = ClsConvert.ToString(dr["PCFN", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Vessel_Status_Cd = ClsConvert.ToString(dr["VESSEL_STATUS_CD", v]);
			Van_Type = ClsConvert.ToString(dr["VAN_TYPE", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LOB_DETAIL_ID"] = ClsConvert.ToDbObject(Lob_Detail_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["LOB_HEADER_ID"] = ClsConvert.ToDbObject(Lob_Header_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["CARGO_DSC"] = ClsConvert.ToDbObject(Cargo_Dsc);
			dr["COMMENT_ONE"] = ClsConvert.ToDbObject(Comment_One);
			dr["COMMENT_TWO"] = ClsConvert.ToDbObject(Comment_Two);
			dr["CONSIGNEE_DODAAC"] = ClsConvert.ToDbObject(Consignee_Dodaac);
			dr["CONSIGNOR_DODAAC"] = ClsConvert.ToDbObject(Consignor_Dodaac);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["CUBE_NBR"] = ClsConvert.ToDbObject(Cube_Nbr);
			dr["VD_FLG"] = ClsConvert.ToDbObject(Vd_Flg);
			dr["SI_FLG"] = ClsConvert.ToDbObject(Si_Flg);
			dr["BOOKED_FLG"] = ClsConvert.ToDbObject(Booked_Flg);
			dr["MANIFESTED_FLG"] = ClsConvert.ToDbObject(Manifested_Flg);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["MTON_NBR"] = ClsConvert.ToDbObject(Mton_Nbr);
			dr["PCFN"] = ClsConvert.ToDbObject(Pcfn);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["VESSEL_STATUS_CD"] = ClsConvert.ToDbObject(Vessel_Status_Cd);
			dr["VAN_TYPE"] = ClsConvert.ToDbObject(Van_Type);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
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

		public static ClsLobDetail GetUsingKey(Int64 Lob_Detail_ID)
		{
			object[] vals = new object[] {Lob_Detail_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLobDetail(dr);
		}
		public static DataTable GetAll(Int64? Lob_Header_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Lob_Header_ID != null && Lob_Header_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LOB_HEADER_ID", Lob_Header_ID));
				sb.Append(" WHERE T_LOB_DETAIL.LOB_HEADER_ID=@LOB_HEADER_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}