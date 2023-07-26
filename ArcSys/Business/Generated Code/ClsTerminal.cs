using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTerminal : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TERMINAL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TERMINAL_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM R_TERMINAL 
				INNER JOIN R_LOCATION
				ON R_TERMINAL.LOCATION_CD=R_LOCATION.LOCATION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Terminal_CdMax = 10;
		public const int Location_CdMax = 10;
		public const int Terminal_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Excluded_VesselsMax = 50;
		public const int Max_DraftMax = 50;
		public const int Tidal_VarianceMax = 50;
		public const int Lock_IssuesMax = 50;
		public const int LoaMax = 50;
		public const int BeamMax = 50;
		public const int Air_DraftMax = 50;
		public const int Pilotage_TimeMax = 50;
		public const int BerthsMax = 50;
		public const int Max_Draft_BerthMax = 50;
		public const int NotesMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Terminal_Cd;
		protected string _Location_Cd;
		protected string _Terminal_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Excluded_Vessels;
		protected string _Max_Draft;
		protected string _Tidal_Variance;
		protected string _Lock_Issues;
		protected string _Loa;
		protected string _Beam;
		protected string _Air_Draft;
		protected string _Pilotage_Time;
		protected string _Berths;
		protected string _Max_Draft_Berth;
		protected string _Notes;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Terminal_Cd
		{
			get { return _Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_CdMax )
					_Terminal_Cd = val.Substring(0, (int)Terminal_CdMax);
				else
					_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Cd");
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
		public string Terminal_Dsc
		{
			get { return _Terminal_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_DscMax )
					_Terminal_Dsc = val.Substring(0, (int)Terminal_DscMax);
				else
					_Terminal_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Dsc");
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
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
			}
		}
		public string Excluded_Vessels
		{
			get { return _Excluded_Vessels; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Excluded_Vessels, val, false) == 0 ) return;
		
				if( val != null && val.Length > Excluded_VesselsMax )
					_Excluded_Vessels = val.Substring(0, (int)Excluded_VesselsMax);
				else
					_Excluded_Vessels = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Excluded_Vessels");
			}
		}
		public string Max_Draft
		{
			get { return _Max_Draft; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Max_Draft, val, false) == 0 ) return;
		
				if( val != null && val.Length > Max_DraftMax )
					_Max_Draft = val.Substring(0, (int)Max_DraftMax);
				else
					_Max_Draft = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Max_Draft");
			}
		}
		public string Tidal_Variance
		{
			get { return _Tidal_Variance; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tidal_Variance, val, false) == 0 ) return;
		
				if( val != null && val.Length > Tidal_VarianceMax )
					_Tidal_Variance = val.Substring(0, (int)Tidal_VarianceMax);
				else
					_Tidal_Variance = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tidal_Variance");
			}
		}
		public string Lock_Issues
		{
			get { return _Lock_Issues; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Lock_Issues, val, false) == 0 ) return;
		
				if( val != null && val.Length > Lock_IssuesMax )
					_Lock_Issues = val.Substring(0, (int)Lock_IssuesMax);
				else
					_Lock_Issues = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Lock_Issues");
			}
		}
		public string Loa
		{
			get { return _Loa; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Loa, val, false) == 0 ) return;
		
				if( val != null && val.Length > LoaMax )
					_Loa = val.Substring(0, (int)LoaMax);
				else
					_Loa = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Loa");
			}
		}
		public string Beam
		{
			get { return _Beam; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Beam, val, false) == 0 ) return;
		
				if( val != null && val.Length > BeamMax )
					_Beam = val.Substring(0, (int)BeamMax);
				else
					_Beam = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Beam");
			}
		}
		public string Air_Draft
		{
			get { return _Air_Draft; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Air_Draft, val, false) == 0 ) return;
		
				if( val != null && val.Length > Air_DraftMax )
					_Air_Draft = val.Substring(0, (int)Air_DraftMax);
				else
					_Air_Draft = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Air_Draft");
			}
		}
		public string Pilotage_Time
		{
			get { return _Pilotage_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pilotage_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pilotage_TimeMax )
					_Pilotage_Time = val.Substring(0, (int)Pilotage_TimeMax);
				else
					_Pilotage_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pilotage_Time");
			}
		}
		public string Berths
		{
			get { return _Berths; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Berths, val, false) == 0 ) return;
		
				if( val != null && val.Length > BerthsMax )
					_Berths = val.Substring(0, (int)BerthsMax);
				else
					_Berths = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Berths");
			}
		}
		public string Max_Draft_Berth
		{
			get { return _Max_Draft_Berth; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Max_Draft_Berth, val, false) == 0 ) return;
		
				if( val != null && val.Length > Max_Draft_BerthMax )
					_Max_Draft_Berth = val.Substring(0, (int)Max_Draft_BerthMax);
				else
					_Max_Draft_Berth = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Max_Draft_Berth");
			}
		}
		public string Notes
		{
			get { return _Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > NotesMax )
					_Notes = val.Substring(0, (int)NotesMax);
				else
					_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Notes");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsLocation _Location;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsLocation Location
		{
			get
			{
				if( Location_Cd == null )
					_Location = null;
				else if( _Location == null ||
					_Location.Location_Cd != Location_Cd )
					_Location = ClsLocation.GetUsingKey(Location_Cd);
				return _Location;
			}
			set
			{
				if( _Location == value ) return;
		
				_Location = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTerminal() : base() {}
		public ClsTerminal(DataRow dr) : base(dr) {}
		public ClsTerminal(ClsTerminal src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Terminal_Cd = null;
			Location_Cd = null;
			Terminal_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Excluded_Vessels = null;
			Max_Draft = null;
			Tidal_Variance = null;
			Lock_Issues = null;
			Loa = null;
			Beam = null;
			Air_Draft = null;
			Pilotage_Time = null;
			Berths = null;
			Max_Draft_Berth = null;
			Notes = null;
		}

		public void CopyFrom(ClsTerminal src)
		{
			Terminal_Cd = src._Terminal_Cd;
			Location_Cd = src._Location_Cd;
			Terminal_Dsc = src._Terminal_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Excluded_Vessels = src._Excluded_Vessels;
			Max_Draft = src._Max_Draft;
			Tidal_Variance = src._Tidal_Variance;
			Lock_Issues = src._Lock_Issues;
			Loa = src._Loa;
			Beam = src._Beam;
			Air_Draft = src._Air_Draft;
			Pilotage_Time = src._Pilotage_Time;
			Berths = src._Berths;
			Max_Draft_Berth = src._Max_Draft_Berth;
			Notes = src._Notes;
		}

		public override bool ReloadFromDB()
		{
			ClsTerminal tmp = ClsTerminal.GetUsingKey(Terminal_Cd);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Location = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[19];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[2] = Connection.GetParameter
				("@TERMINAL_DSC", Terminal_Dsc);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@EXCLUDED_VESSELS", Excluded_Vessels);
			p[5] = Connection.GetParameter
				("@MAX_DRAFT", Max_Draft);
			p[6] = Connection.GetParameter
				("@TIDAL_VARIANCE", Tidal_Variance);
			p[7] = Connection.GetParameter
				("@LOCK_ISSUES", Lock_Issues);
			p[8] = Connection.GetParameter
				("@LOA", Loa);
			p[9] = Connection.GetParameter
				("@BEAM", Beam);
			p[10] = Connection.GetParameter
				("@AIR_DRAFT", Air_Draft);
			p[11] = Connection.GetParameter
				("@PILOTAGE_TIME", Pilotage_Time);
			p[12] = Connection.GetParameter
				("@BERTHS", Berths);
			p[13] = Connection.GetParameter
				("@MAX_DRAFT_BERTH", Max_Draft_Berth);
			p[14] = Connection.GetParameter
				("@NOTES", Notes);
			p[15] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[16] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[18] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_TERMINAL
					(TERMINAL_CD, LOCATION_CD, TERMINAL_DSC,
					ACTIVE_FLG, EXCLUDED_VESSELS, MAX_DRAFT,
					TIDAL_VARIANCE, LOCK_ISSUES, LOA,
					BEAM, AIR_DRAFT, PILOTAGE_TIME,
					BERTHS, MAX_DRAFT_BERTH, NOTES)
				VALUES
					(@TERMINAL_CD, @LOCATION_CD, @TERMINAL_DSC,
					@ACTIVE_FLG, @EXCLUDED_VESSELS, @MAX_DRAFT,
					@TIDAL_VARIANCE, @LOCK_ISSUES, @LOA,
					@BEAM, @AIR_DRAFT, @PILOTAGE_TIME,
					@BERTHS, @MAX_DRAFT_BERTH, @NOTES)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[15].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[18].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_DSC", Terminal_Dsc);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@EXCLUDED_VESSELS", Excluded_Vessels);
			p[5] = Connection.GetParameter
				("@MAX_DRAFT", Max_Draft);
			p[6] = Connection.GetParameter
				("@TIDAL_VARIANCE", Tidal_Variance);
			p[7] = Connection.GetParameter
				("@LOCK_ISSUES", Lock_Issues);
			p[8] = Connection.GetParameter
				("@LOA", Loa);
			p[9] = Connection.GetParameter
				("@BEAM", Beam);
			p[10] = Connection.GetParameter
				("@AIR_DRAFT", Air_Draft);
			p[11] = Connection.GetParameter
				("@PILOTAGE_TIME", Pilotage_Time);
			p[12] = Connection.GetParameter
				("@BERTHS", Berths);
			p[13] = Connection.GetParameter
				("@MAX_DRAFT_BERTH", Max_Draft_Berth);
			p[14] = Connection.GetParameter
				("@NOTES", Notes);
			p[15] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[16] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_TERMINAL SET
					LOCATION_CD = @LOCATION_CD,
					TERMINAL_DSC = @TERMINAL_DSC,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					EXCLUDED_VESSELS = @EXCLUDED_VESSELS,
					MAX_DRAFT = @MAX_DRAFT,
					TIDAL_VARIANCE = @TIDAL_VARIANCE,
					LOCK_ISSUES = @LOCK_ISSUES,
					LOA = @LOA,
					BEAM = @BEAM,
					AIR_DRAFT = @AIR_DRAFT,
					PILOTAGE_TIME = @PILOTAGE_TIME,
					BERTHS = @BERTHS,
					MAX_DRAFT_BERTH = @MAX_DRAFT_BERTH,
					NOTES = @NOTES
				WHERE
					TERMINAL_CD = @TERMINAL_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[16].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);

			const string sql = @"
				DELETE FROM R_TERMINAL WHERE
				TERMINAL_CD=@TERMINAL_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Terminal_Dsc = ClsConvert.ToString(dr["TERMINAL_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Excluded_Vessels = ClsConvert.ToString(dr["EXCLUDED_VESSELS"]);
			Max_Draft = ClsConvert.ToString(dr["MAX_DRAFT"]);
			Tidal_Variance = ClsConvert.ToString(dr["TIDAL_VARIANCE"]);
			Lock_Issues = ClsConvert.ToString(dr["LOCK_ISSUES"]);
			Loa = ClsConvert.ToString(dr["LOA"]);
			Beam = ClsConvert.ToString(dr["BEAM"]);
			Air_Draft = ClsConvert.ToString(dr["AIR_DRAFT"]);
			Pilotage_Time = ClsConvert.ToString(dr["PILOTAGE_TIME"]);
			Berths = ClsConvert.ToString(dr["BERTHS"]);
			Max_Draft_Berth = ClsConvert.ToString(dr["MAX_DRAFT_BERTH"]);
			Notes = ClsConvert.ToString(dr["NOTES"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Terminal_Dsc = ClsConvert.ToString(dr["TERMINAL_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Excluded_Vessels = ClsConvert.ToString(dr["EXCLUDED_VESSELS", v]);
			Max_Draft = ClsConvert.ToString(dr["MAX_DRAFT", v]);
			Tidal_Variance = ClsConvert.ToString(dr["TIDAL_VARIANCE", v]);
			Lock_Issues = ClsConvert.ToString(dr["LOCK_ISSUES", v]);
			Loa = ClsConvert.ToString(dr["LOA", v]);
			Beam = ClsConvert.ToString(dr["BEAM", v]);
			Air_Draft = ClsConvert.ToString(dr["AIR_DRAFT", v]);
			Pilotage_Time = ClsConvert.ToString(dr["PILOTAGE_TIME", v]);
			Berths = ClsConvert.ToString(dr["BERTHS", v]);
			Max_Draft_Berth = ClsConvert.ToString(dr["MAX_DRAFT_BERTH", v]);
			Notes = ClsConvert.ToString(dr["NOTES", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TERMINAL_CD"] = ClsConvert.ToDbObject(Terminal_Cd);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["TERMINAL_DSC"] = ClsConvert.ToDbObject(Terminal_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["EXCLUDED_VESSELS"] = ClsConvert.ToDbObject(Excluded_Vessels);
			dr["MAX_DRAFT"] = ClsConvert.ToDbObject(Max_Draft);
			dr["TIDAL_VARIANCE"] = ClsConvert.ToDbObject(Tidal_Variance);
			dr["LOCK_ISSUES"] = ClsConvert.ToDbObject(Lock_Issues);
			dr["LOA"] = ClsConvert.ToDbObject(Loa);
			dr["BEAM"] = ClsConvert.ToDbObject(Beam);
			dr["AIR_DRAFT"] = ClsConvert.ToDbObject(Air_Draft);
			dr["PILOTAGE_TIME"] = ClsConvert.ToDbObject(Pilotage_Time);
			dr["BERTHS"] = ClsConvert.ToDbObject(Berths);
			dr["MAX_DRAFT_BERTH"] = ClsConvert.ToDbObject(Max_Draft_Berth);
			dr["NOTES"] = ClsConvert.ToDbObject(Notes);
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

		public static ClsTerminal GetUsingKey(string Terminal_Cd)
		{
			object[] vals = new object[] {Terminal_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTerminal(dr);
		}
		public static DataTable GetAll(string Location_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LOCATION_CD", Location_Cd));
				sb.Append(" WHERE R_TERMINAL.LOCATION_CD=@LOCATION_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}