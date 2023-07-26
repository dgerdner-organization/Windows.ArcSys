using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVArcsysMismatch : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_ARCSYS_MISMATCH";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_ARCSYS_MISMATCH";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 30;
		public const int Partner_Request_CdMax = 30;
		public const int Acms_Voyage_NoMax = 10;
		public const int Acms_Pol_BerthMax = 10;
		public const int Acms_Pod_BerthMax = 10;
		public const int Line_Voyage_NoMax = 10;
		public const int Line_Pol_BerthMax = 20;
		public const int Line_Pod_BerthMax = 20;
		public const int Acms_Status_CdMax = 2;
		public const int Line_PolMax = 10;
		public const int Line_PodMax = 10;
		public const int Amcs_PolMax = 10;
		public const int Acms_PodMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;
		protected string _Partner_Request_Cd;
		protected DateTime? _Request_Dt;
		protected string _Acms_Voyage_No;
		protected string _Acms_Pol_Berth;
		protected string _Acms_Pod_Berth;
		protected string _Line_Voyage_No;
		protected string _Line_Pol_Berth;
		protected string _Line_Pod_Berth;
		protected string _Acms_Status_Cd;
		protected Double? _Item_No;
		protected string _Line_Pol;
		protected string _Line_Pod;
		protected string _Amcs_Pol;
		protected string _Acms_Pod;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public DateTime? Request_Dt
		{
			get { return _Request_Dt; }
			set
			{
				if( _Request_Dt == value ) return;
		
				_Request_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Request_Dt");
			}
		}
		public string Acms_Voyage_No
		{
			get { return _Acms_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Voyage_NoMax )
					_Acms_Voyage_No = val.Substring(0, (int)Acms_Voyage_NoMax);
				else
					_Acms_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Voyage_No");
			}
		}
		public string Acms_Pol_Berth
		{
			get { return _Acms_Pol_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Pol_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Pol_BerthMax )
					_Acms_Pol_Berth = val.Substring(0, (int)Acms_Pol_BerthMax);
				else
					_Acms_Pol_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Pol_Berth");
			}
		}
		public string Acms_Pod_Berth
		{
			get { return _Acms_Pod_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Pod_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Pod_BerthMax )
					_Acms_Pod_Berth = val.Substring(0, (int)Acms_Pod_BerthMax);
				else
					_Acms_Pod_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Pod_Berth");
			}
		}
		public string Line_Voyage_No
		{
			get { return _Line_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_Voyage_NoMax )
					_Line_Voyage_No = val.Substring(0, (int)Line_Voyage_NoMax);
				else
					_Line_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Voyage_No");
			}
		}
		public string Line_Pol_Berth
		{
			get { return _Line_Pol_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Pol_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_Pol_BerthMax )
					_Line_Pol_Berth = val.Substring(0, (int)Line_Pol_BerthMax);
				else
					_Line_Pol_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Pol_Berth");
			}
		}
		public string Line_Pod_Berth
		{
			get { return _Line_Pod_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Pod_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_Pod_BerthMax )
					_Line_Pod_Berth = val.Substring(0, (int)Line_Pod_BerthMax);
				else
					_Line_Pod_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Pod_Berth");
			}
		}
		public string Acms_Status_Cd
		{
			get { return _Acms_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Status_CdMax )
					_Acms_Status_Cd = val.Substring(0, (int)Acms_Status_CdMax);
				else
					_Acms_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Status_Cd");
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
		public string Line_Pol
		{
			get { return _Line_Pol; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Pol, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_PolMax )
					_Line_Pol = val.Substring(0, (int)Line_PolMax);
				else
					_Line_Pol = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Pol");
			}
		}
		public string Line_Pod
		{
			get { return _Line_Pod; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Pod, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_PodMax )
					_Line_Pod = val.Substring(0, (int)Line_PodMax);
				else
					_Line_Pod = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Pod");
			}
		}
		public string Amcs_Pol
		{
			get { return _Amcs_Pol; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Amcs_Pol, val, false) == 0 ) return;
		
				if( val != null && val.Length > Amcs_PolMax )
					_Amcs_Pol = val.Substring(0, (int)Amcs_PolMax);
				else
					_Amcs_Pol = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Amcs_Pol");
			}
		}
		public string Acms_Pod
		{
			get { return _Acms_Pod; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Pod, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_PodMax )
					_Acms_Pod = val.Substring(0, (int)Acms_PodMax);
				else
					_Acms_Pod = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Pod");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVArcsysMismatch() : base() {}
		public ClsVArcsysMismatch(DataRow dr) : base(dr) {}
		public ClsVArcsysMismatch(ClsVArcsysMismatch src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
			Partner_Request_Cd = null;
			Request_Dt = null;
			Acms_Voyage_No = null;
			Acms_Pol_Berth = null;
			Acms_Pod_Berth = null;
			Line_Voyage_No = null;
			Line_Pol_Berth = null;
			Line_Pod_Berth = null;
			Acms_Status_Cd = null;
			Item_No = null;
			Line_Pol = null;
			Line_Pod = null;
			Amcs_Pol = null;
			Acms_Pod = null;
		}

		public void CopyFrom(ClsVArcsysMismatch src)
		{
			Booking_No = src._Booking_No;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Request_Dt = src._Request_Dt;
			Acms_Voyage_No = src._Acms_Voyage_No;
			Acms_Pol_Berth = src._Acms_Pol_Berth;
			Acms_Pod_Berth = src._Acms_Pod_Berth;
			Line_Voyage_No = src._Line_Voyage_No;
			Line_Pol_Berth = src._Line_Pol_Berth;
			Line_Pod_Berth = src._Line_Pod_Berth;
			Acms_Status_Cd = src._Acms_Status_Cd;
			Item_No = src._Item_No;
			Line_Pol = src._Line_Pol;
			Line_Pod = src._Line_Pod;
			Amcs_Pol = src._Amcs_Pol;
			Acms_Pod = src._Acms_Pod;
		}

		public override bool ReloadFromDB()
		{
			ClsVArcsysMismatch tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[3] = Connection.GetParameter
				("@ACMS_VOYAGE_NO", Acms_Voyage_No);
			p[4] = Connection.GetParameter
				("@ACMS_POL_BERTH", Acms_Pol_Berth);
			p[5] = Connection.GetParameter
				("@ACMS_POD_BERTH", Acms_Pod_Berth);
			p[6] = Connection.GetParameter
				("@LINE_VOYAGE_NO", Line_Voyage_No);
			p[7] = Connection.GetParameter
				("@LINE_POL_BERTH", Line_Pol_Berth);
			p[8] = Connection.GetParameter
				("@LINE_POD_BERTH", Line_Pod_Berth);
			p[9] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[10] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[11] = Connection.GetParameter
				("@LINE_POL", Line_Pol);
			p[12] = Connection.GetParameter
				("@LINE_POD", Line_Pod);
			p[13] = Connection.GetParameter
				("@AMCS_POL", Amcs_Pol);
			p[14] = Connection.GetParameter
				("@ACMS_POD", Acms_Pod);

			const string sql = @"
				INSERT INTO V_ARCSYS_MISMATCH
					(BOOKING_NO, PARTNER_REQUEST_CD, REQUEST_DT,
					ACMS_VOYAGE_NO, ACMS_POL_BERTH, ACMS_POD_BERTH,
					LINE_VOYAGE_NO, LINE_POL_BERTH, LINE_POD_BERTH,
					ACMS_STATUS_CD, ITEM_NO, LINE_POL,
					LINE_POD, AMCS_POL, ACMS_POD)
				VALUES
					(@BOOKING_NO, @PARTNER_REQUEST_CD, @REQUEST_DT,
					@ACMS_VOYAGE_NO, @ACMS_POL_BERTH, @ACMS_POD_BERTH,
					@LINE_VOYAGE_NO, @LINE_POL_BERTH, @LINE_POD_BERTH,
					@ACMS_STATUS_CD, @ITEM_NO, @LINE_POL,
					@LINE_POD, @AMCS_POL, @ACMS_POD)
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

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Acms_Voyage_No = ClsConvert.ToString(dr["ACMS_VOYAGE_NO"]);
			Acms_Pol_Berth = ClsConvert.ToString(dr["ACMS_POL_BERTH"]);
			Acms_Pod_Berth = ClsConvert.ToString(dr["ACMS_POD_BERTH"]);
			Line_Voyage_No = ClsConvert.ToString(dr["LINE_VOYAGE_NO"]);
			Line_Pol_Berth = ClsConvert.ToString(dr["LINE_POL_BERTH"]);
			Line_Pod_Berth = ClsConvert.ToString(dr["LINE_POD_BERTH"]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO"]);
			Line_Pol = ClsConvert.ToString(dr["LINE_POL"]);
			Line_Pod = ClsConvert.ToString(dr["LINE_POD"]);
			Amcs_Pol = ClsConvert.ToString(dr["AMCS_POL"]);
			Acms_Pod = ClsConvert.ToString(dr["ACMS_POD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Acms_Voyage_No = ClsConvert.ToString(dr["ACMS_VOYAGE_NO", v]);
			Acms_Pol_Berth = ClsConvert.ToString(dr["ACMS_POL_BERTH", v]);
			Acms_Pod_Berth = ClsConvert.ToString(dr["ACMS_POD_BERTH", v]);
			Line_Voyage_No = ClsConvert.ToString(dr["LINE_VOYAGE_NO", v]);
			Line_Pol_Berth = ClsConvert.ToString(dr["LINE_POL_BERTH", v]);
			Line_Pod_Berth = ClsConvert.ToString(dr["LINE_POD_BERTH", v]);
			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO", v]);
			Line_Pol = ClsConvert.ToString(dr["LINE_POL", v]);
			Line_Pod = ClsConvert.ToString(dr["LINE_POD", v]);
			Amcs_Pol = ClsConvert.ToString(dr["AMCS_POL", v]);
			Acms_Pod = ClsConvert.ToString(dr["ACMS_POD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["ACMS_VOYAGE_NO"] = ClsConvert.ToDbObject(Acms_Voyage_No);
			dr["ACMS_POL_BERTH"] = ClsConvert.ToDbObject(Acms_Pol_Berth);
			dr["ACMS_POD_BERTH"] = ClsConvert.ToDbObject(Acms_Pod_Berth);
			dr["LINE_VOYAGE_NO"] = ClsConvert.ToDbObject(Line_Voyage_No);
			dr["LINE_POL_BERTH"] = ClsConvert.ToDbObject(Line_Pol_Berth);
			dr["LINE_POD_BERTH"] = ClsConvert.ToDbObject(Line_Pod_Berth);
			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["LINE_POL"] = ClsConvert.ToDbObject(Line_Pol);
			dr["LINE_POD"] = ClsConvert.ToDbObject(Line_Pod);
			dr["AMCS_POL"] = ClsConvert.ToDbObject(Amcs_Pol);
			dr["ACMS_POD"] = ClsConvert.ToDbObject(Acms_Pod);
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