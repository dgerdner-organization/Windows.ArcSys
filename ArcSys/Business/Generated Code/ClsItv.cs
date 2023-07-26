using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsItv : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ITV";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ITV_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_ITV";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Trading_Partner_CdMax = 10;
		public const int Cargo_KeyMax = 30;
		public const int Serial_NoMax = 50;
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
		public const int Actual_Departure_FlgMax = 1;
		public const int Actual_Arrival_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Itv_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected decimal? _Isa_Nbr;
		protected string _Trading_Partner_Cd;
		protected string _Cargo_Key;
		protected decimal? _Cargo_Line_ID;
		protected string _Serial_No;
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
		protected string _Actual_Departure_Flg;
		protected string _Actual_Arrival_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
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
		public string Actual_Departure_Flg
		{
			get { return _Actual_Departure_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Actual_Departure_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Actual_Departure_FlgMax )
					_Actual_Departure_Flg = val.Substring(0, (int)Actual_Departure_FlgMax);
				else
					_Actual_Departure_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Actual_Departure_Flg");
			}
		}
		public string Actual_Arrival_Flg
		{
			get { return _Actual_Arrival_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Actual_Arrival_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Actual_Arrival_FlgMax )
					_Actual_Arrival_Flg = val.Substring(0, (int)Actual_Arrival_FlgMax);
				else
					_Actual_Arrival_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Actual_Arrival_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsItv() : base() {}
		public ClsItv(DataRow dr) : base(dr) {}
		public ClsItv(ClsItv src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Itv_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Trading_Partner_Cd = null;
			Cargo_Key = null;
			Cargo_Line_ID = null;
			Serial_No = null;
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
			Actual_Departure_Flg = null;
			Actual_Arrival_Flg = null;
		}

		public void CopyFrom(ClsItv src)
		{
			Itv_ID = src._Itv_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Cargo_Key = src._Cargo_Key;
			Cargo_Line_ID = src._Cargo_Line_ID;
			Serial_No = src._Serial_No;
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
			Actual_Departure_Flg = src._Actual_Departure_Flg;
			Actual_Arrival_Flg = src._Actual_Arrival_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsItv tmp = ClsItv.GetUsingKey(Itv_ID.Value);
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

			DbParameter[] p = new DbParameter[25];

			p[0] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[1] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[2] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[3] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[4] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[5] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[6] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[7] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[8] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[9] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[10] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[11] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[12] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[13] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[14] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[15] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[16] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[17] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[18] = Connection.GetParameter
				("@ACTUAL_DEPARTURE_FLG", Actual_Departure_Flg);
			p[19] = Connection.GetParameter
				("@ACTUAL_ARRIVAL_FLG", Actual_Arrival_Flg);
			p[20] = Connection.GetParameter
				("@ITV_ID", Itv_ID, ParameterDirection.Output, DbType.Decimal, 0);
			p[21] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[22] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[23] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[24] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_ITV
					(ITV_ID, ISA_NBR, TRADING_PARTNER_CD,
					CARGO_KEY, CARGO_LINE_ID, SERIAL_NO,
					ACTIVITY_DT, ACTIVITY_CD, BOOKING_NO,
					BOL_NO, LOCATION_CD, VOYAGE_NO,
					VESSEL_CD, DEPARTURE_DT, ARRIVAL_DT,
					PLOR_LOCATION_CD, POL_LOCATION_CD, POD_LOCATION_CD,
					PLOD_LOCATION_CD, ACTUAL_DEPARTURE_FLG, ACTUAL_ARRIVAL_FLG)
				VALUES
					(ITV_ID_SEQ.NEXTVAL, @ISA_NBR, @TRADING_PARTNER_CD,
					@CARGO_KEY, @CARGO_LINE_ID, @SERIAL_NO,
					@ACTIVITY_DT, @ACTIVITY_CD, @BOOKING_NO,
					@BOL_NO, @LOCATION_CD, @VOYAGE_NO,
					@VESSEL_CD, @DEPARTURE_DT, @ARRIVAL_DT,
					@PLOR_LOCATION_CD, @POL_LOCATION_CD, @POD_LOCATION_CD,
					@PLOD_LOCATION_CD, @ACTUAL_DEPARTURE_FLG, @ACTUAL_ARRIVAL_FLG)
				RETURNING
					ITV_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@ITV_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Itv_ID = ClsConvert.ToDecimalNullable(p[20].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[21].Value);
			Create_User = ClsConvert.ToString(p[22].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[23].Value);
			Modify_User = ClsConvert.ToString(p[24].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[4] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[5] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[6] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[7] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[8] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[9] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[10] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[11] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[12] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[13] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[14] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[15] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[16] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[17] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[18] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[19] = Connection.GetParameter
				("@ACTUAL_DEPARTURE_FLG", Actual_Departure_Flg);
			p[20] = Connection.GetParameter
				("@ACTUAL_ARRIVAL_FLG", Actual_Arrival_Flg);
			p[21] = Connection.GetParameter
				("@ITV_ID", Itv_ID);
			p[22] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ITV SET
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					CARGO_KEY = @CARGO_KEY,
					CARGO_LINE_ID = @CARGO_LINE_ID,
					SERIAL_NO = @SERIAL_NO,
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
					ACTUAL_DEPARTURE_FLG = @ACTUAL_DEPARTURE_FLG,
					ACTUAL_ARRIVAL_FLG = @ACTUAL_ARRIVAL_FLG
				WHERE
					ITV_ID = @ITV_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[22].Value);
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

			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Cargo_Line_ID = ClsConvert.ToDecimalNullable(dr["CARGO_LINE_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
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
			Actual_Departure_Flg = ClsConvert.ToString(dr["ACTUAL_DEPARTURE_FLG"]);
			Actual_Arrival_Flg = ClsConvert.ToString(dr["ACTUAL_ARRIVAL_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Itv_ID = ClsConvert.ToDecimalNullable(dr["ITV_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Cargo_Line_ID = ClsConvert.ToDecimalNullable(dr["CARGO_LINE_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
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
			Actual_Departure_Flg = ClsConvert.ToString(dr["ACTUAL_DEPARTURE_FLG", v]);
			Actual_Arrival_Flg = ClsConvert.ToString(dr["ACTUAL_ARRIVAL_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ITV_ID"] = ClsConvert.ToDbObject(Itv_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
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
			dr["ACTUAL_DEPARTURE_FLG"] = ClsConvert.ToDbObject(Actual_Departure_Flg);
			dr["ACTUAL_ARRIVAL_FLG"] = ClsConvert.ToDbObject(Actual_Arrival_Flg);
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

		public static ClsItv GetUsingKey(decimal Itv_ID)
		{
			object[] vals = new object[] {Itv_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsItv(dr);
		}

		#endregion		// #region Static Methods
	}
}