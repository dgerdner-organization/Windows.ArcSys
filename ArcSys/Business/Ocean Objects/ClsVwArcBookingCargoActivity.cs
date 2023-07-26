using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBookingCargoActivity : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_booking_cargo_activity";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_booking_cargo_activity";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 50;
		public const int Serial_NoMax = 40;
		public const int Status_CodeMax = 2;
		public const int UpdateddatelocalMax = 27;
		public const int NameMax = 40;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _ID;
		protected string _Booking_No;
		protected string _Serial_No;
		protected Int32? _Item_No;
		protected Int32? _Piecenumber;
		protected string _Status_Code;
		protected string _Updateddatelocal;
		protected string _Name;
		protected Int32? _Bookingcargoid;
		protected Int32? _Bookingid;

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
		public string Updateddatelocal
		{
			get { return _Updateddatelocal; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Updateddatelocal, val, false) == 0 ) return;
		
				if( val != null && val.Length > UpdateddatelocalMax )
					_Updateddatelocal = val.Substring(0, (int)UpdateddatelocalMax);
				else
					_Updateddatelocal = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Updateddatelocal");
			}
		}
		public string Name
		{
			get { return _Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > NameMax )
					_Name = val.Substring(0, (int)NameMax);
				else
					_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Name");
			}
		}
		public Int32? Bookingcargoid
		{
			get { return _Bookingcargoid; }
			set
			{
				if( _Bookingcargoid == value ) return;
		
				_Bookingcargoid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Bookingcargoid");
			}
		}
		public Int32? Bookingid
		{
			get { return _Bookingid; }
			set
			{
				if( _Bookingid == value ) return;
		
				_Bookingid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Bookingid");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBookingCargoActivity() : base() {}
		public ClsVwArcBookingCargoActivity(DataRow dr) : base(dr) {}
		public ClsVwArcBookingCargoActivity(ClsVwArcBookingCargoActivity src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			ID = null;
			Booking_No = null;
			Serial_No = null;
			Item_No = null;
			Piecenumber = null;
			Status_Code = null;
			Updateddatelocal = null;
			Name = null;
			Bookingcargoid = null;
			Bookingid = null;
		}

		public void CopyFrom(ClsVwArcBookingCargoActivity src)
		{
			ID = src._ID;
			Booking_No = src._Booking_No;
			Serial_No = src._Serial_No;
			Item_No = src._Item_No;
			Piecenumber = src._Piecenumber;
			Status_Code = src._Status_Code;
			Updateddatelocal = src._Updateddatelocal;
			Name = src._Name;
			Bookingcargoid = src._Bookingcargoid;
			Bookingid = src._Bookingid;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBookingCargoActivity tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@Id", ID);
			p[1] = Connection.GetParameter
				("@booking_no", Booking_No);
			p[2] = Connection.GetParameter
				("@serial_no", Serial_No);
			p[3] = Connection.GetParameter
				("@item_no", Item_No);
			p[4] = Connection.GetParameter
				("@PieceNumber", Piecenumber);
			p[5] = Connection.GetParameter
				("@status_code", Status_Code);
			p[6] = Connection.GetParameter
				("@UpdatedDateLocal", Updateddatelocal);
			p[7] = Connection.GetParameter
				("@Name", Name);
			p[8] = Connection.GetParameter
				("@BookingCargoId", Bookingcargoid);
			p[9] = Connection.GetParameter
				("@BookingId", Bookingid);

			const string sql = @"INSERT INTO vw_arc_booking_cargo_activity VALUES
				(@Id,@booking_no,@serial_no
				,@item_no,@PieceNumber,@status_code
				,@UpdatedDateLocal,@Name,@BookingCargoId
				,@BookingId)";
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
			Booking_No = ClsConvert.ToString(dr["booking_no"]);
			Serial_No = ClsConvert.ToString(dr["serial_no"]);
			Item_No = ClsConvert.ToInt32Nullable(dr["item_no"]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber"]);
			Status_Code = ClsConvert.ToString(dr["status_code"]);
			Updateddatelocal = ClsConvert.ToString(dr["UpdatedDateLocal"]);
			Name = ClsConvert.ToString(dr["Name"]);
			Bookingcargoid = ClsConvert.ToInt32Nullable(dr["BookingCargoId"]);
			Bookingid = ClsConvert.ToInt32Nullable(dr["BookingId"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			ID = ClsConvert.ToInt32Nullable(dr["Id", v]);
			Booking_No = ClsConvert.ToString(dr["booking_no", v]);
			Serial_No = ClsConvert.ToString(dr["serial_no", v]);
			Item_No = ClsConvert.ToInt32Nullable(dr["item_no", v]);
			Piecenumber = ClsConvert.ToInt32Nullable(dr["PieceNumber", v]);
			Status_Code = ClsConvert.ToString(dr["status_code", v]);
			Updateddatelocal = ClsConvert.ToString(dr["UpdatedDateLocal", v]);
			Name = ClsConvert.ToString(dr["Name", v]);
			Bookingcargoid = ClsConvert.ToInt32Nullable(dr["BookingCargoId", v]);
			Bookingid = ClsConvert.ToInt32Nullable(dr["BookingId", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["Id"] = ClsConvert.ToDbObject(ID);
			dr["booking_no"] = ClsConvert.ToDbObject(Booking_No);
			dr["serial_no"] = ClsConvert.ToDbObject(Serial_No);
			dr["item_no"] = ClsConvert.ToDbObject(Item_No);
			dr["PieceNumber"] = ClsConvert.ToDbObject(Piecenumber);
			dr["status_code"] = ClsConvert.ToDbObject(Status_Code);
			dr["UpdatedDateLocal"] = ClsConvert.ToDbObject(Updateddatelocal);
			dr["Name"] = ClsConvert.ToDbObject(Name);
			dr["BookingCargoId"] = ClsConvert.ToDbObject(Bookingcargoid);
			dr["BookingId"] = ClsConvert.ToDbObject(Bookingid);
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