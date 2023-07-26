using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsLocationTerminal : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_LOCATION_TERMINAL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TERMINAL_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM R_LOCATION_TERMINAL 
				INNER JOIN R_LOCATION
				ON R_LOCATION_TERMINAL.LOCATION_CD=R_LOCATION.LOCATION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Terminal_CdMax = 10;
		public const int Location_CdMax = 10;
		public const int Terminal_DscMax = 30;
		public const int Delete_FlMax = 1;
		public const int Default_FlMax = 1;
		public const int Other1_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Terminal_Cd;
		protected string _Location_Cd;
		protected string _Terminal_Dsc;
		protected string _Delete_Fl;
		protected string _Default_Fl;
		protected string _Other1_Cd;

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
		public string Delete_Fl
		{
			get { return _Delete_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delete_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delete_FlMax )
					_Delete_Fl = val.Substring(0, (int)Delete_FlMax);
				else
					_Delete_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delete_Fl");
			}
		}
		public string Default_Fl
		{
			get { return _Default_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Default_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Default_FlMax )
					_Default_Fl = val.Substring(0, (int)Default_FlMax);
				else
					_Default_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Default_Fl");
			}
		}
		public string Other1_Cd
		{
			get { return _Other1_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Other1_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Other1_CdMax )
					_Other1_Cd = val.Substring(0, (int)Other1_CdMax);
				else
					_Other1_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Other1_Cd");
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

		public ClsLocationTerminal() : base() {}
		public ClsLocationTerminal(DataRow dr) : base(dr) {}
		public ClsLocationTerminal(ClsLocationTerminal src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Terminal_Cd = null;
			Location_Cd = null;
			Terminal_Dsc = null;
			Delete_Fl = null;
			Default_Fl = null;
			Other1_Cd = null;
		}

		public void CopyFrom(ClsLocationTerminal src)
		{
			Terminal_Cd = src._Terminal_Cd;
			Location_Cd = src._Location_Cd;
			Terminal_Dsc = src._Terminal_Dsc;
			Delete_Fl = src._Delete_Fl;
			Default_Fl = src._Default_Fl;
			Other1_Cd = src._Other1_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsLocationTerminal tmp = ClsLocationTerminal.GetUsingKey(Terminal_Cd);
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

			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[2] = Connection.GetParameter
				("@TERMINAL_DSC", Terminal_Dsc);
			p[3] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[4] = Connection.GetParameter
				("@DEFAULT_FL", Default_Fl);
			p[5] = Connection.GetParameter
				("@OTHER1_CD", Other1_Cd);

			const string sql = @"
				INSERT INTO R_LOCATION_TERMINAL
					(TERMINAL_CD, LOCATION_CD, TERMINAL_DSC,
					DELETE_FL, DEFAULT_FL, OTHER1_CD)
				VALUES
					(@TERMINAL_CD, @LOCATION_CD, @TERMINAL_DSC,
					@DELETE_FL, @DEFAULT_FL, @OTHER1_CD)
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_DSC", Terminal_Dsc);
			p[2] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[3] = Connection.GetParameter
				("@DEFAULT_FL", Default_Fl);
			p[4] = Connection.GetParameter
				("@OTHER1_CD", Other1_Cd);
			p[5] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);

			const string sql = @"
				UPDATE R_LOCATION_TERMINAL SET
					LOCATION_CD = @LOCATION_CD,
					TERMINAL_DSC = @TERMINAL_DSC,
					DELETE_FL = @DELETE_FL,
					DEFAULT_FL = @DEFAULT_FL,
					OTHER1_CD = @OTHER1_CD
				WHERE
					TERMINAL_CD = @TERMINAL_CD
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);

			const string sql = @"
				DELETE FROM R_LOCATION_TERMINAL WHERE
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
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Default_Fl = ClsConvert.ToString(dr["DEFAULT_FL"]);
			Other1_Cd = ClsConvert.ToString(dr["OTHER1_CD"]);
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
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Default_Fl = ClsConvert.ToString(dr["DEFAULT_FL", v]);
			Other1_Cd = ClsConvert.ToString(dr["OTHER1_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TERMINAL_CD"] = ClsConvert.ToDbObject(Terminal_Cd);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["TERMINAL_DSC"] = ClsConvert.ToDbObject(Terminal_Dsc);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["DEFAULT_FL"] = ClsConvert.ToDbObject(Default_Fl);
			dr["OTHER1_CD"] = ClsConvert.ToDbObject(Other1_Cd);
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

		public static ClsLocationTerminal GetUsingKey(string Terminal_Cd)
		{
			object[] vals = new object[] {Terminal_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLocationTerminal(dr);
		}
		public static DataTable GetAll(string Location_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LOCATION_CD", Location_Cd));
				sb.Append(" WHERE R_LOCATION_TERMINAL.LOCATION_CD=@LOCATION_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}