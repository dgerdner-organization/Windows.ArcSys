using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVIalItvOut : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_IAL_ITV_OUT";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_IAL_ITV_OUT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int PortMax = 10;
		public const int Booking_NoMax = 25;
		public const int Ial_Order_NoMax = 20;
		public const int VinMax = 50;
		public const int Activity_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Port;
		protected string _Booking_No;
		protected string _Ial_Order_No;
		protected string _Vin;
		protected string _Activity_Cd;
		protected DateTime? _Activity_Dt;
		protected decimal? _Isa_Nbr;
		protected decimal? _Itv_ID;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Port
		{
			get { return _Port; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Port, val, false) == 0 ) return;
		
				if( val != null && val.Length > PortMax )
					_Port = val.Substring(0, (int)PortMax);
				else
					_Port = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Port");
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
		public string Ial_Order_No
		{
			get { return _Ial_Order_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ial_Order_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ial_Order_NoMax )
					_Ial_Order_No = val.Substring(0, (int)Ial_Order_NoMax);
				else
					_Ial_Order_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ial_Order_No");
			}
		}
		public string Vin
		{
			get { return _Vin; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vin, val, false) == 0 ) return;
		
				if( val != null && val.Length > VinMax )
					_Vin = val.Substring(0, (int)VinMax);
				else
					_Vin = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vin");
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
		public decimal? Itv_ID
		{
			get { return _Itv_ID; }
			set
			{
				if( _Itv_ID == value ) return;
		
				_Itv_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Itv_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVIalItvOut() : base() {}
		public ClsVIalItvOut(DataRow dr) : base(dr) {}
		public ClsVIalItvOut(ClsVIalItvOut src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vessel_Cd = null;
			Voyage_No = null;
			Port = null;
			Booking_No = null;
			Ial_Order_No = null;
			Vin = null;
			Activity_Cd = null;
			Activity_Dt = null;
			Isa_Nbr = null;
			Itv_ID = null;
		}

		public void CopyFrom(ClsVIalItvOut src)
		{
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Port = src._Port;
			Booking_No = src._Booking_No;
			Ial_Order_No = src._Ial_Order_No;
			Vin = src._Vin;
			Activity_Cd = src._Activity_Cd;
			Activity_Dt = src._Activity_Dt;
			Isa_Nbr = src._Isa_Nbr;
			Itv_ID = src._Itv_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsVIalItvOut tmp = null;	//No primary key can't refresh;
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
				("@VESSEL_CD", Vessel_Cd);
			p[1] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[2] = Connection.GetParameter
				("@PORT", Port);
			p[3] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[4] = Connection.GetParameter
				("@IAL_ORDER_NO", Ial_Order_No);
			p[5] = Connection.GetParameter
				("@VIN", Vin);
			p[6] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[7] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[8] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[9] = Connection.GetParameter
				("@ITV_ID", Itv_ID);

			const string sql = @"
				INSERT INTO V_IAL_ITV_OUT
					(VESSEL_CD, VOYAGE_NO, PORT,
					BOOKING_NO, IAL_ORDER_NO, VIN,
					ACTIVITY_CD, ACTIVITY_DT, ISA_NBR,
					ITV_ID)
				VALUES
					(@VESSEL_CD, @VOYAGE_NO, @PORT,
					@BOOKING_NO, @IAL_ORDER_NO, @VIN,
					@ACTIVITY_CD, @ACTIVITY_DT, @ISA_NBR,
					@ITV_ID)
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

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Port = ClsConvert.ToString(dr["PORT"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Ial_Order_No = ClsConvert.ToString(dr["IAL_ORDER_NO"]);
			Vin = ClsConvert.ToString(dr["VIN"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR"]);
			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Port = ClsConvert.ToString(dr["PORT", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Ial_Order_No = ClsConvert.ToString(dr["IAL_ORDER_NO", v]);
			Vin = ClsConvert.ToString(dr["VIN", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR", v]);
			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["PORT"] = ClsConvert.ToDbObject(Port);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["IAL_ORDER_NO"] = ClsConvert.ToDbObject(Ial_Order_No);
			dr["VIN"] = ClsConvert.ToDbObject(Vin);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["ITV_ID"] = ClsConvert.ToDbObject(Itv_ID);
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