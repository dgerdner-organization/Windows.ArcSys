using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargo : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO 
				INNER JOIN T_BOOKING
				ON T_CARGO.BOOKING_ID=T_BOOKING.BOOKING_ID
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_CARGO.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID
				LEFT OUTER JOIN R_MOVE_TYPE
				ON T_CARGO.MOVE_TYPE_CD=R_MOVE_TYPE.MOVE_TYPE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
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
		public const int Cargo_KeyMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Booking_ID;
		protected string _Serial_No;
		protected Int32? _Item_No;
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
		protected string _Cargo_Key;
		protected DateTime? _Cargo_Rcvd_Dt;
		protected DateTime? _Rdd_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_ID
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
		public Int64? Booking_ID
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsBooking _Booking;
		protected ClsContractMod _Contract_Mod;
		protected ClsMoveType _Move_Type;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsBooking Booking
		{
			get
			{
				if( Booking_ID == null )
					_Booking = null;
				else if( _Booking == null ||
					_Booking.Booking_ID != Booking_ID )
					_Booking = ClsBooking.GetUsingKey(Booking_ID.Value);
				return _Booking;
			}
			set
			{
				if( _Booking == value ) return;
		
				_Booking = value;
			}
		}
		public ClsContractMod Contract_Mod
		{
			get
			{
				if( Contract_Mod_ID == null )
					_Contract_Mod = null;
				else if( _Contract_Mod == null ||
					_Contract_Mod.Contract_Mod_ID != Contract_Mod_ID )
					_Contract_Mod = ClsContractMod.GetUsingKey(Contract_Mod_ID.Value);
				return _Contract_Mod;
			}
			set
			{
				if( _Contract_Mod == value ) return;
		
				_Contract_Mod = value;
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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargo() : base() {}
		public ClsCargo(DataRow dr) : base(dr) {}
		public ClsCargo(ClsCargo src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Booking_ID = null;
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
			Cargo_Key = null;
			Cargo_Rcvd_Dt = null;
			Rdd_Dt = null;
		}

		public void CopyFrom(ClsCargo src)
		{
			Cargo_ID = src._Cargo_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Booking_ID = src._Booking_ID;
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
			Cargo_Key = src._Cargo_Key;
			Cargo_Rcvd_Dt = src._Cargo_Rcvd_Dt;
			Rdd_Dt = src._Rdd_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsCargo tmp = ClsCargo.GetUsingKey(Cargo_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Booking = null;
			_Contract_Mod = null;
			_Move_Type = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[30];

			p[0] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[3] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[4] = Connection.GetParameter
				("@PKG_TYPE_CD", Pkg_Type_Cd);
			p[5] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[6] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[7] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[8] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[9] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[10] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[11] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[12] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[13] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[14] = Connection.GetParameter
				("@VESSEL_LOAD_DT", Vessel_Load_Dt);
			p[15] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[16] = Connection.GetParameter
				("@CONTAINER_NO", Container_No);
			p[17] = Connection.GetParameter
				("@SEAL1", Seal1);
			p[18] = Connection.GetParameter
				("@SEAL2", Seal2);
			p[19] = Connection.GetParameter
				("@SEAL3", Seal3);
			p[20] = Connection.GetParameter
				("@MAKE_CD", Make_Cd);
			p[21] = Connection.GetParameter
				("@MODEL_CD", Model_Cd);
			p[22] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[23] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[24] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[25] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[26] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[27] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[28] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[29] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO
					(CARGO_ID, BOOKING_ID, SERIAL_NO,
					ITEM_NO, COMMODITY_CD, PKG_TYPE_CD,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, DIM_WEIGHT_NBR, CUBE_FT,
					M_TONS, MOVE_TYPE_CD, CARGO_DSC,
					VESSEL_LOAD_DT, CONTRACT_MOD_ID, CONTAINER_NO,
					SEAL1, SEAL2, SEAL3,
					MAKE_CD, MODEL_CD, CARGO_KEY,
					CARGO_RCVD_DT, RDD_DT)
				VALUES
					(CARGO_ID_SEQ.NEXTVAL, @BOOKING_ID, @SERIAL_NO,
					@ITEM_NO, @COMMODITY_CD, @PKG_TYPE_CD,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @DIM_WEIGHT_NBR, @CUBE_FT,
					@M_TONS, @MOVE_TYPE_CD, @CARGO_DSC,
					@VESSEL_LOAD_DT, @CONTRACT_MOD_ID, @CONTAINER_NO,
					@SEAL1, @SEAL2, @SEAL3,
					@MAKE_CD, @MODEL_CD, @CARGO_KEY,
					@CARGO_RCVD_DT, @RDD_DT)
				RETURNING
					CARGO_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_ID = ClsConvert.ToInt64Nullable(p[25].Value);
			Create_User = ClsConvert.ToString(p[26].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[27].Value);
			Modify_User = ClsConvert.ToString(p[28].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[29].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[28];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
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
				("@CARGO_KEY", Cargo_Key);
			p[24] = Connection.GetParameter
				("@CARGO_RCVD_DT", Cargo_Rcvd_Dt);
			p[25] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[26] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[27] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO SET
					MODIFY_DT = @MODIFY_DT,
					BOOKING_ID = @BOOKING_ID,
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
					CARGO_KEY = @CARGO_KEY,
					CARGO_RCVD_DT = @CARGO_RCVD_DT,
					RDD_DT = @RDD_DT
				WHERE
					CARGO_ID = @CARGO_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[27].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);

			const string sql = @"
				DELETE FROM T_CARGO WHERE
				CARGO_ID=@CARGO_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Item_No = ClsConvert.ToInt32Nullable(dr["ITEM_NO"]);
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
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Item_No = ClsConvert.ToInt32Nullable(dr["ITEM_NO", v]);
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
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Cargo_Rcvd_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_RCVD_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_ID"] = ClsConvert.ToDbObject(Cargo_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
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
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["CARGO_RCVD_DT"] = ClsConvert.ToDbObject(Cargo_Rcvd_Dt);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
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

		public static ClsCargo GetUsingKey(Int64 Cargo_ID)
		{
			object[] vals = new object[] {Cargo_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargo(dr);
		}
		public static DataTable GetAll(Int64? Booking_ID, Int64? Contract_Mod_ID,
			string Move_Type_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Booking_ID != null && Booking_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@BOOKING_ID", Booking_ID));
				sb.Append(" WHERE T_CARGO.BOOKING_ID=@BOOKING_ID");
			}
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.AppendFormat(" {0} T_CARGO.CONTRACT_MOD_ID=@CONTRACT_MOD_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Move_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@MOVE_TYPE_CD", Move_Type_Cd));
				sb.AppendFormat(" {0} T_CARGO.MOVE_TYPE_CD=@MOVE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}