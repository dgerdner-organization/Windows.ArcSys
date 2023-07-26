using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsOceanCargoActivity : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_OCEAN_CARGO_ACTIVITY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "OCEAN_ACTIVITY_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_OCEAN_CARGO_ACTIVITY";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 20;
		public const int Serial_NoMax = 50;
		public const int Ocean_Status_CdMax = 10;
		public const int Activity_CdMax = 10;
		public const int Activity_DscMax = 50;
		public const int Processed_Warehouse_FlgMax = 1;
		public const int Processed_Acms_FlgMax = 1;
		public const int Processed_Itv_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ocean_Activity_ID;
		protected string _Booking_No;
		protected string _Serial_No;
		protected Int64? _Item_No;
		protected Int64? _Piece_No;
		protected string _Ocean_Status_Cd;
		protected string _Activity_Cd;
		protected DateTime? _Activity_Dt;
		protected string _Activity_Dsc;
		protected Int64? _Ocean_Cargo_ID;
		protected Int64? _Ocean_Booking_ID;
		protected string _Processed_Warehouse_Flg;
		protected string _Processed_Acms_Flg;
		protected string _Processed_Itv_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ocean_Activity_ID
		{
			get { return _Ocean_Activity_ID; }
			set
			{
				if( _Ocean_Activity_ID == value ) return;
		
				_Ocean_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Activity_ID");
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
		public Int64? Piece_No
		{
			get { return _Piece_No; }
			set
			{
				if( _Piece_No == value ) return;
		
				_Piece_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Piece_No");
			}
		}
		public string Ocean_Status_Cd
		{
			get { return _Ocean_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ocean_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ocean_Status_CdMax )
					_Ocean_Status_Cd = val.Substring(0, (int)Ocean_Status_CdMax);
				else
					_Ocean_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Status_Cd");
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
		public DateTime? Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Activity_Dt == val ) return;
		
				_Activity_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
			}
		}
		public string Activity_Dsc
		{
			get { return _Activity_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_DscMax )
					_Activity_Dsc = val.Substring(0, (int)Activity_DscMax);
				else
					_Activity_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dsc");
			}
		}
		public Int64? Ocean_Cargo_ID
		{
			get { return _Ocean_Cargo_ID; }
			set
			{
				if( _Ocean_Cargo_ID == value ) return;
		
				_Ocean_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Cargo_ID");
			}
		}
		public Int64? Ocean_Booking_ID
		{
			get { return _Ocean_Booking_ID; }
			set
			{
				if( _Ocean_Booking_ID == value ) return;
		
				_Ocean_Booking_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Booking_ID");
			}
		}
		public string Processed_Warehouse_Flg
		{
			get { return _Processed_Warehouse_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Warehouse_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_Warehouse_FlgMax )
					_Processed_Warehouse_Flg = val.Substring(0, (int)Processed_Warehouse_FlgMax);
				else
					_Processed_Warehouse_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Warehouse_Flg");
			}
		}
		public string Processed_Acms_Flg
		{
			get { return _Processed_Acms_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Acms_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_Acms_FlgMax )
					_Processed_Acms_Flg = val.Substring(0, (int)Processed_Acms_FlgMax);
				else
					_Processed_Acms_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Acms_Flg");
			}
		}
		public string Processed_Itv_Flg
		{
			get { return _Processed_Itv_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Itv_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_Itv_FlgMax )
					_Processed_Itv_Flg = val.Substring(0, (int)Processed_Itv_FlgMax);
				else
					_Processed_Itv_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Itv_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsOceanCargoActivity() : base() {}
		public ClsOceanCargoActivity(DataRow dr) : base(dr) {}
		public ClsOceanCargoActivity(ClsOceanCargoActivity src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ocean_Activity_ID = null;
			Booking_No = null;
			Serial_No = null;
			Item_No = null;
			Piece_No = null;
			Ocean_Status_Cd = null;
			Activity_Cd = null;
			Activity_Dt = null;
			Activity_Dsc = null;
			Ocean_Cargo_ID = null;
			Ocean_Booking_ID = null;
			Processed_Warehouse_Flg = null;
			Processed_Acms_Flg = null;
			Processed_Itv_Flg = null;
		}

		public void CopyFrom(ClsOceanCargoActivity src)
		{
			Ocean_Activity_ID = src._Ocean_Activity_ID;
			Booking_No = src._Booking_No;
			Serial_No = src._Serial_No;
			Item_No = src._Item_No;
			Piece_No = src._Piece_No;
			Ocean_Status_Cd = src._Ocean_Status_Cd;
			Activity_Cd = src._Activity_Cd;
			Activity_Dt = src._Activity_Dt;
			Activity_Dsc = src._Activity_Dsc;
			Ocean_Cargo_ID = src._Ocean_Cargo_ID;
			Ocean_Booking_ID = src._Ocean_Booking_ID;
			Processed_Warehouse_Flg = src._Processed_Warehouse_Flg;
			Processed_Acms_Flg = src._Processed_Acms_Flg;
			Processed_Itv_Flg = src._Processed_Itv_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsOceanCargoActivity tmp = ClsOceanCargoActivity.GetUsingKey(Ocean_Activity_ID.Value);
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

			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@OCEAN_ACTIVITY_ID", Ocean_Activity_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[3] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[4] = Connection.GetParameter
				("@PIECE_NO", Piece_No);
			p[5] = Connection.GetParameter
				("@OCEAN_STATUS_CD", Ocean_Status_Cd);
			p[6] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[7] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[8] = Connection.GetParameter
				("@ACTIVITY_DSC", Activity_Dsc);
			p[9] = Connection.GetParameter
				("@OCEAN_CARGO_ID", Ocean_Cargo_ID);
			p[10] = Connection.GetParameter
				("@OCEAN_BOOKING_ID", Ocean_Booking_ID);
			p[11] = Connection.GetParameter
				("@PROCESSED_WAREHOUSE_FLG", Processed_Warehouse_Flg);
			p[12] = Connection.GetParameter
				("@PROCESSED_ACMS_FLG", Processed_Acms_Flg);
			p[13] = Connection.GetParameter
				("@PROCESSED_ITV_FLG", Processed_Itv_Flg);

			const string sql = @"
				INSERT INTO T_OCEAN_CARGO_ACTIVITY
					(OCEAN_ACTIVITY_ID, BOOKING_NO, SERIAL_NO,
					ITEM_NO, PIECE_NO, OCEAN_STATUS_CD,
					ACTIVITY_CD, ACTIVITY_DT, ACTIVITY_DSC,
					OCEAN_CARGO_ID, OCEAN_BOOKING_ID, PROCESSED_WAREHOUSE_FLG,
					PROCESSED_ACMS_FLG, PROCESSED_ITV_FLG)
				VALUES
					(@OCEAN_ACTIVITY_ID, @BOOKING_NO, @SERIAL_NO,
					@ITEM_NO, @PIECE_NO, @OCEAN_STATUS_CD,
					@ACTIVITY_CD, @ACTIVITY_DT, @ACTIVITY_DSC,
					@OCEAN_CARGO_ID, @OCEAN_BOOKING_ID, @PROCESSED_WAREHOUSE_FLG,
					@PROCESSED_ACMS_FLG, @PROCESSED_ITV_FLG)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[2] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[3] = Connection.GetParameter
				("@PIECE_NO", Piece_No);
			p[4] = Connection.GetParameter
				("@OCEAN_STATUS_CD", Ocean_Status_Cd);
			p[5] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[6] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[7] = Connection.GetParameter
				("@ACTIVITY_DSC", Activity_Dsc);
			p[8] = Connection.GetParameter
				("@OCEAN_CARGO_ID", Ocean_Cargo_ID);
			p[9] = Connection.GetParameter
				("@OCEAN_BOOKING_ID", Ocean_Booking_ID);
			p[10] = Connection.GetParameter
				("@PROCESSED_WAREHOUSE_FLG", Processed_Warehouse_Flg);
			p[11] = Connection.GetParameter
				("@PROCESSED_ACMS_FLG", Processed_Acms_Flg);
			p[12] = Connection.GetParameter
				("@PROCESSED_ITV_FLG", Processed_Itv_Flg);
			p[13] = Connection.GetParameter
				("@OCEAN_ACTIVITY_ID", Ocean_Activity_ID);

			const string sql = @"
				UPDATE T_OCEAN_CARGO_ACTIVITY SET
					BOOKING_NO = @BOOKING_NO,
					SERIAL_NO = @SERIAL_NO,
					ITEM_NO = @ITEM_NO,
					PIECE_NO = @PIECE_NO,
					OCEAN_STATUS_CD = @OCEAN_STATUS_CD,
					ACTIVITY_CD = @ACTIVITY_CD,
					ACTIVITY_DT = @ACTIVITY_DT,
					ACTIVITY_DSC = @ACTIVITY_DSC,
					OCEAN_CARGO_ID = @OCEAN_CARGO_ID,
					OCEAN_BOOKING_ID = @OCEAN_BOOKING_ID,
					PROCESSED_WAREHOUSE_FLG = @PROCESSED_WAREHOUSE_FLG,
					PROCESSED_ACMS_FLG = @PROCESSED_ACMS_FLG,
					PROCESSED_ITV_FLG = @PROCESSED_ITV_FLG
				WHERE
					OCEAN_ACTIVITY_ID = @OCEAN_ACTIVITY_ID
				RETURNING
					
				INTO
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

			Ocean_Activity_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_ACTIVITY_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Piece_No = ClsConvert.ToInt64Nullable(dr["PIECE_NO"]);
			Ocean_Status_Cd = ClsConvert.ToString(dr["OCEAN_STATUS_CD"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Activity_Dsc = ClsConvert.ToString(dr["ACTIVITY_DSC"]);
			Ocean_Cargo_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_CARGO_ID"]);
			Ocean_Booking_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_BOOKING_ID"]);
			Processed_Warehouse_Flg = ClsConvert.ToString(dr["PROCESSED_WAREHOUSE_FLG"]);
			Processed_Acms_Flg = ClsConvert.ToString(dr["PROCESSED_ACMS_FLG"]);
			Processed_Itv_Flg = ClsConvert.ToString(dr["PROCESSED_ITV_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ocean_Activity_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_ACTIVITY_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Piece_No = ClsConvert.ToInt64Nullable(dr["PIECE_NO", v]);
			Ocean_Status_Cd = ClsConvert.ToString(dr["OCEAN_STATUS_CD", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Activity_Dsc = ClsConvert.ToString(dr["ACTIVITY_DSC", v]);
			Ocean_Cargo_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_CARGO_ID", v]);
			Ocean_Booking_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_BOOKING_ID", v]);
			Processed_Warehouse_Flg = ClsConvert.ToString(dr["PROCESSED_WAREHOUSE_FLG", v]);
			Processed_Acms_Flg = ClsConvert.ToString(dr["PROCESSED_ACMS_FLG", v]);
			Processed_Itv_Flg = ClsConvert.ToString(dr["PROCESSED_ITV_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["OCEAN_ACTIVITY_ID"] = ClsConvert.ToDbObject(Ocean_Activity_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["PIECE_NO"] = ClsConvert.ToDbObject(Piece_No);
			dr["OCEAN_STATUS_CD"] = ClsConvert.ToDbObject(Ocean_Status_Cd);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_DSC"] = ClsConvert.ToDbObject(Activity_Dsc);
			dr["OCEAN_CARGO_ID"] = ClsConvert.ToDbObject(Ocean_Cargo_ID);
			dr["OCEAN_BOOKING_ID"] = ClsConvert.ToDbObject(Ocean_Booking_ID);
			dr["PROCESSED_WAREHOUSE_FLG"] = ClsConvert.ToDbObject(Processed_Warehouse_Flg);
			dr["PROCESSED_ACMS_FLG"] = ClsConvert.ToDbObject(Processed_Acms_Flg);
			dr["PROCESSED_ITV_FLG"] = ClsConvert.ToDbObject(Processed_Itv_Flg);
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

		public static ClsOceanCargoActivity GetUsingKey(Int64 Ocean_Activity_ID)
		{
			object[] vals = new object[] {Ocean_Activity_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsOceanCargoActivity(dr);
		}

		#endregion		// #region Static Methods
	}
}