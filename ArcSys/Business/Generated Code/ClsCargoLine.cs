using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoLine : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_LINE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_LINE_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_CARGO_LINE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Cargo_KeyMax = 30;
		public const int Serial_NoMax = 50;
		public const int Commodity_CdMax = 10;
		public const int Pkg_Type_CdMax = 10;
		public const int Move_Type_CdMax = 10;
		public const int Cargo_DscMax = 50;
		public const int Container_NoMax = 20;
		public const int Seal1Max = 20;
		public const int Seal2Max = 20;
		public const int Seal3Max = 20;
		public const int Make_CdMax = 25;
		public const int Model_CdMax = 25;
		public const int Import_Notes_TxtMax = 100;
		public const int Cargo_Type_CdMax = 10;
		public const int Cargo_StatusMax = 10;
		public const int Bol_NoMax = 25;
		public const int Bol_StatusMax = 10;
		public const int Ecn_RcnMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Line_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Cargo_Key;
		protected Int64? _Booking_Line_ID;
		protected string _Serial_No;
		protected Int64? _Item_No;
		protected string _Commodity_Cd;
		protected string _Pkg_Type_Cd;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Dim_Weight_Nbr;
		protected decimal? _Cube_Ft;
		protected decimal? _M_Tons;
		protected string _Move_Type_Cd;
		protected string _Cargo_Dsc;
		protected DateTime? _Vessel_Load_Dt;
		protected Int64? _Contract_Mod_ID;
		protected string _Container_No;
		protected string _Seal1;
		protected string _Seal2;
		protected string _Seal3;
		protected string _Make_Cd;
		protected string _Model_Cd;
		protected DateTime? _Cargo_Rcvd_Dt;
		protected string _Import_Notes_Txt;
		protected string _Cargo_Type_Cd;
		protected string _Cargo_Status;
		protected string _Bol_No;
		protected string _Bol_Status;
		protected DateTime? _Rdd_Dt;
		protected string _Ecn_Rcn;
		protected DateTime? _Cargo_Status_Dt;
		protected Int64? _Seq_No;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Pkg_Type_Cd
		{
			get { return _Pkg_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pkg_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pkg_Type_CdMax )
					_Pkg_Type_Cd = val.Substring(0, (int)Pkg_Type_CdMax);
				else
					_Pkg_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pkg_Type_Cd");
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
		public DateTime? Vessel_Load_Dt
		{
			get { return _Vessel_Load_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Vessel_Load_Dt == val ) return;
		
				_Vessel_Load_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Load_Dt");
			}
		}
		public Int64? Contract_Mod_ID
		{
			get { return _Contract_Mod_ID; }
			set
			{
				if( _Contract_Mod_ID == value ) return;
		
				_Contract_Mod_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Contract_Mod_ID");
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
		public DateTime? Cargo_Rcvd_Dt
		{
			get { return _Cargo_Rcvd_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Cargo_Rcvd_Dt == val ) return;
		
				_Cargo_Rcvd_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Rcvd_Dt");
			}
		}
		public string Import_Notes_Txt
		{
			get { return _Import_Notes_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Import_Notes_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Import_Notes_TxtMax )
					_Import_Notes_Txt = val.Substring(0, (int)Import_Notes_TxtMax);
				else
					_Import_Notes_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Import_Notes_Txt");
			}
		}
		public string Cargo_Type_Cd
		{
			get { return _Cargo_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_Type_CdMax )
					_Cargo_Type_Cd = val.Substring(0, (int)Cargo_Type_CdMax);
				else
					_Cargo_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Type_Cd");
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
		public string Bol_Status
		{
			get { return _Bol_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_StatusMax )
					_Bol_Status = val.Substring(0, (int)Bol_StatusMax);
				else
					_Bol_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_Status");
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
		public string Ecn_Rcn
		{
			get { return _Ecn_Rcn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ecn_Rcn, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ecn_RcnMax )
					_Ecn_Rcn = val.Substring(0, (int)Ecn_RcnMax);
				else
					_Ecn_Rcn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ecn_Rcn");
			}
		}
		public DateTime? Cargo_Status_Dt
		{
			get { return _Cargo_Status_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Cargo_Status_Dt == val ) return;
		
				_Cargo_Status_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Status_Dt");
			}
		}
		public Int64? Seq_No
		{
			get { return _Seq_No; }
			set
			{
				if( _Seq_No == value ) return;
		
				_Seq_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Seq_No");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoLine() : base() {}
		public ClsCargoLine(DataRow dr) : base(dr) {}
		public ClsCargoLine(ClsCargoLine src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Line_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Cargo_Key = null;
			Booking_Line_ID = null;
			Serial_No = null;
			Item_No = null;
			Commodity_Cd = null;
			Pkg_Type_Cd = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Dim_Weight_Nbr = null;
			Cube_Ft = null;
			M_Tons = null;
			Move_Type_Cd = null;
			Cargo_Dsc = null;
			Vessel_Load_Dt = null;
			Contract_Mod_ID = null;
			Container_No = null;
			Seal1 = null;
			Seal2 = null;
			Seal3 = null;
			Make_Cd = null;
			Model_Cd = null;
			Cargo_Rcvd_Dt = null;
			Import_Notes_Txt = null;
			Cargo_Type_Cd = null;
			Cargo_Status = null;
			Bol_No = null;
			Bol_Status = null;
			Rdd_Dt = null;
			Ecn_Rcn = null;
			Cargo_Status_Dt = null;
			Seq_No = null;
		}

		public void CopyFrom(ClsCargoLine src)
		{
			Cargo_Line_ID = src._Cargo_Line_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Cargo_Key = src._Cargo_Key;
			Booking_Line_ID = src._Booking_Line_ID;
			Serial_No = src._Serial_No;
			Item_No = src._Item_No;
			Commodity_Cd = src._Commodity_Cd;
			Pkg_Type_Cd = src._Pkg_Type_Cd;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Dim_Weight_Nbr = src._Dim_Weight_Nbr;
			Cube_Ft = src._Cube_Ft;
			M_Tons = src._M_Tons;
			Move_Type_Cd = src._Move_Type_Cd;
			Cargo_Dsc = src._Cargo_Dsc;
			Vessel_Load_Dt = src._Vessel_Load_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
			Container_No = src._Container_No;
			Seal1 = src._Seal1;
			Seal2 = src._Seal2;
			Seal3 = src._Seal3;
			Make_Cd = src._Make_Cd;
			Model_Cd = src._Model_Cd;
			Cargo_Rcvd_Dt = src._Cargo_Rcvd_Dt;
			Import_Notes_Txt = src._Import_Notes_Txt;
			Cargo_Type_Cd = src._Cargo_Type_Cd;
			Cargo_Status = src._Cargo_Status;
			Bol_No = src._Bol_No;
			Bol_Status = src._Bol_Status;
			Rdd_Dt = src._Rdd_Dt;
			Ecn_Rcn = src._Ecn_Rcn;
			Cargo_Status_Dt = src._Cargo_Status_Dt;
			Seq_No = src._Seq_No;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoLine tmp = ClsCargoLine.GetUsingKey(Cargo_Line_ID.Value);
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

			DbParameter[] p = new DbParameter[38];

			p[0] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[1] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[2] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[3] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[4] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[5] = Connection.GetParameter
				("@PKG_TYPE_CD", Pkg_Type_Cd);
			p[6] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[7] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[8] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[9] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[10] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[11] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[12] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[13] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[14] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[15] = Connection.GetParameter
				("@VESSEL_LOAD_DT", Vessel_Load_Dt);
			p[16] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[17] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[18] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[19] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[20] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[21] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[22] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[23] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[24] = Connection.GetParameter
				("@IMPORT_NOTES_TXT", Import_Notes_Txt);
			p[25] = Connection.GetParameter
				("@CARGO_TYPE_CD", Cargo_Type_Cd);
			p[26] = Connection.GetParameter
				("@CARGO_STATUS", Cargo_Status);
			p[27] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[28] = Connection.GetParameter
				("@BOL_STATUS", Bol_Status);
			p[29] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[30] = Connection.GetParameter
				("@ECN_RCN", Ecn_Rcn);
			p[31] = Connection.GetParameter
				("@CARGO_STATUS_DT", Cargo_Status_Dt);
			p[32] = Connection.GetParameter
				("@SEQ_NO", Seq_No);
			p[33] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[34] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[35] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[36] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[37] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_LINE
					(CARGO_LINE_ID, CARGO_KEY, BOOKING_LINE_ID,
					SERIAL_NO, ITEM_NO, COMMODITY_CD,
					PKG_TYPE_CD, LENGTH_NBR, WIDTH_NBR,
					HEIGHT_NBR, WEIGHT_NBR, DIM_WEIGHT_NBR,
					CUBE_FT, M_TONS, MOVE_TYPE_CD,
					CARGO_DSC, VESSEL_LOAD_DT, CONTRACT_MOD_ID,
					CONTAINER_NO, SEAL1, SEAL2,
					SEAL3, MAKE_CD, MODEL_CD,
					CARGO_RCVD_DT, IMPORT_NOTES_TXT, CARGO_TYPE_CD,
					CARGO_STATUS, BOL_NO, BOL_STATUS,
					RDD_DT, ECN_RCN, CARGO_STATUS_DT,
					SEQ_NO)
				VALUES
					(CARGO_LINE_ID_SEQ.NEXTVAL, @CARGO_KEY, @BOOKING_LINE_ID,
					@SERIAL_NO, @ITEM_NO, @COMMODITY_CD,
					@PKG_TYPE_CD, @LENGTH_NBR, @WIDTH_NBR,
					@HEIGHT_NBR, @WEIGHT_NBR, @DIM_WEIGHT_NBR,
					@CUBE_FT, @M_TONS, @MOVE_TYPE_CD,
					@CARGO_DSC, @VESSEL_LOAD_DT, @CONTRACT_MOD_ID,
					@CONTAINER_NO, @SEAL1, @SEAL2,
					@SEAL3, @MAKE_CD, @MODEL_CD,
					@CARGO_RCVD_DT, @IMPORT_NOTES_TXT, @CARGO_TYPE_CD,
					@CARGO_STATUS, @BOL_NO, @BOL_STATUS,
					@RDD_DT, @ECN_RCN, @CARGO_STATUS_DT,
					@SEQ_NO)
				RETURNING
					CARGO_LINE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_LINE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Line_ID = ClsConvert.ToInt64Nullable(p[33].Value);
			Create_User = ClsConvert.ToString(p[34].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[35].Value);
			Modify_User = ClsConvert.ToString(p[36].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[37].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[36];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[2] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[3] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[4] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[5] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[6] = Connection.GetParameter
				("@PKG_TYPE_CD", Pkg_Type_Cd);
			p[7] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[8] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[9] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[10] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[11] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[12] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[13] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[14] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[15] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[16] = Connection.GetParameter
				("@VESSEL_LOAD_DT", Vessel_Load_Dt);
			p[17] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[18] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[19] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[20] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[21] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[22] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[23] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[24] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[25] = Connection.GetParameter
				("@IMPORT_NOTES_TXT", Import_Notes_Txt);
			p[26] = Connection.GetParameter
				("@CARGO_TYPE_CD", Cargo_Type_Cd);
			p[27] = Connection.GetParameter
				("@CARGO_STATUS", Cargo_Status);
			p[28] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[29] = Connection.GetParameter
				("@BOL_STATUS", Bol_Status);
			p[30] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[31] = Connection.GetParameter
				("@ECN_RCN", Ecn_Rcn);
			p[32] = Connection.GetParameter
				("@CARGO_STATUS_DT", Cargo_Status_Dt);
			p[33] = Connection.GetParameter
				("@SEQ_NO", Seq_No);
			p[34] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[35] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_LINE SET
					MODIFY_DT = @MODIFY_DT,
					CARGO_KEY = @CARGO_KEY,
					BOOKING_LINE_ID = @BOOKING_LINE_ID,
					SERIAL_NO = @SERIAL_NO,
					ITEM_NO = @ITEM_NO,
					COMMODITY_CD = @COMMODITY_CD,
					PKG_TYPE_CD = @PKG_TYPE_CD,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					DIM_WEIGHT_NBR = @DIM_WEIGHT_NBR,
					CUBE_FT = @CUBE_FT,
					M_TONS = @M_TONS,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					CARGO_DSC = @CARGO_DSC,
					VESSEL_LOAD_DT = @VESSEL_LOAD_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID,
					CONTAINER_NO = @CONTAINER_NO,
					SEAL1 = @SEAL1,
					SEAL2 = @SEAL2,
					SEAL3 = @SEAL3,
					MAKE_CD = @MAKE_CD,
					MODEL_CD = @MODEL_CD,
					CARGO_RCVD_DT = @CARGO_RCVD_DT,
					IMPORT_NOTES_TXT = @IMPORT_NOTES_TXT,
					CARGO_TYPE_CD = @CARGO_TYPE_CD,
					CARGO_STATUS = @CARGO_STATUS,
					BOL_NO = @BOL_NO,
					BOL_STATUS = @BOL_STATUS,
					RDD_DT = @RDD_DT,
					ECN_RCN = @ECN_RCN,
					CARGO_STATUS_DT = @CARGO_STATUS_DT,
					SEQ_NO = @SEQ_NO
				WHERE
					CARGO_LINE_ID = @CARGO_LINE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[35].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);

			const string sql = @"
				DELETE FROM T_CARGO_LINE WHERE
				CARGO_LINE_ID=@CARGO_LINE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR"]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT"]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC"]);
			Vessel_Load_Dt = ClsConvert.ToDateTimeNullable(dr["VESSEL_LOAD_DT"]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID"]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO"]);
			Seal1 = ClsConvert.ToString(dr["SEAL1"]);
			Seal2 = ClsConvert.ToString(dr["SEAL2"]);
			Seal3 = ClsConvert.ToString(dr["SEAL3"]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD"]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD"]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT"]);
			Import_Notes_Txt = ClsConvert.ToString(dr["IMPORT_NOTES_TXT"]);
			Cargo_Type_Cd = ClsConvert.ToString(dr["CARGO_TYPE_CD"]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Ecn_Rcn = ClsConvert.ToString(dr["ECN_RCN"]);
			Cargo_Status_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_STATUS_DT"]);
			Seq_No = ClsConvert.ToInt64Nullable(dr["SEQ_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Pkg_Type_Cd = ClsConvert.ToString(dr["PKG_TYPE_CD", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR", v]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT", v]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC", v]);
			Vessel_Load_Dt = ClsConvert.ToDateTimeNullable(dr["VESSEL_LOAD_DT", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
			Container_No = ClsConvert.ToString(dr["CONTAINER_NO", v]);
			Seal1 = ClsConvert.ToString(dr["SEAL1", v]);
			Seal2 = ClsConvert.ToString(dr["SEAL2", v]);
			Seal3 = ClsConvert.ToString(dr["SEAL3", v]);
			Make_Cd = ClsConvert.ToString(dr["MAKE_CD", v]);
			Model_Cd = ClsConvert.ToString(dr["MODEL_CD", v]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT", v]);
			Import_Notes_Txt = ClsConvert.ToString(dr["IMPORT_NOTES_TXT", v]);
			Cargo_Type_Cd = ClsConvert.ToString(dr["CARGO_TYPE_CD", v]);
			Cargo_Status = ClsConvert.ToString(dr["CARGO_STATUS", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Ecn_Rcn = ClsConvert.ToString(dr["ECN_RCN", v]);
			Cargo_Status_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_STATUS_DT", v]);
			Seq_No = ClsConvert.ToInt64Nullable(dr["SEQ_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["BOOKING_LINE_ID"] = ClsConvert.ToDbObject(Booking_Line_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["PKG_TYPE_CD"] = ClsConvert.ToDbObject(Pkg_Type_Cd);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["DIM_WEIGHT_NBR"] = ClsConvert.ToDbObject(Dim_Weight_Nbr);
			dr["CUBE_FT"] = ClsConvert.ToDbObject(Cube_Ft);
			dr["M_TONS"] = ClsConvert.ToDbObject(M_Tons);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["CARGO_DSC"] = ClsConvert.ToDbObject(Cargo_Dsc);
			dr["VESSEL_LOAD_DT"] = ClsConvert.ToDbObject(Vessel_Load_Dt);
			dr["CONTRACT_MOD_ID"] = ClsConvert.ToDbObject(Contract_Mod_ID);
			dr["CONTAINER_NO"] = ClsConvert.ToDbObject(Container_No);
			dr["SEAL1"] = ClsConvert.ToDbObject(Seal1);
			dr["SEAL2"] = ClsConvert.ToDbObject(Seal2);
			dr["SEAL3"] = ClsConvert.ToDbObject(Seal3);
			dr["MAKE_CD"] = ClsConvert.ToDbObject(Make_Cd);
			dr["MODEL_CD"] = ClsConvert.ToDbObject(Model_Cd);
			dr["CARGO_RCVD_DT"] = ClsConvert.ToDbObject(Cargo_Rcvd_Dt);
			dr["IMPORT_NOTES_TXT"] = ClsConvert.ToDbObject(Import_Notes_Txt);
			dr["CARGO_TYPE_CD"] = ClsConvert.ToDbObject(Cargo_Type_Cd);
			dr["CARGO_STATUS"] = ClsConvert.ToDbObject(Cargo_Status);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["BOL_STATUS"] = ClsConvert.ToDbObject(Bol_Status);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["ECN_RCN"] = ClsConvert.ToDbObject(Ecn_Rcn);
			dr["CARGO_STATUS_DT"] = ClsConvert.ToDbObject(Cargo_Status_Dt);
			dr["SEQ_NO"] = ClsConvert.ToDbObject(Seq_No);
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

		public static ClsCargoLine GetUsingKey(Int64 Cargo_Line_ID)
		{
			object[] vals = new object[] {Cargo_Line_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoLine(dr);
		}

		#endregion		// #region Static Methods
	}
}