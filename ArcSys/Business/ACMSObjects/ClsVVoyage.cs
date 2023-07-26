using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVVoyage : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_VOYAGE";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_VOYAGE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Voyage_CdMax = 25;
		public const int Military_Voyage_CdMax = 20;
		public const int Delete_FlMax = 1;
		public const int Vessel_CdMax = 10;
		public const int Route_CdMax = 10;
		public const int Budget_PeriodMax = 0;
		public const int Scac_CdMax = 4;
		public const int Full_FlMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Voyage_Cd;
		protected string _Military_Voyage_Cd;
		protected string _Delete_Fl;
		protected string _Vessel_Cd;
		protected string _Route_Cd;
		protected string _Budget_Period;
		protected string _Scac_Cd;
		protected DateTime? _Sail_Dt;
		protected string _Full_Fl;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Voyage_Cd
		{
			get { return _Voyage_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_CdMax )
					_Voyage_Cd = val.Substring(0, (int)Voyage_CdMax);
				else
					_Voyage_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_Cd");
			}
		}
		public string Military_Voyage_Cd
		{
			get { return _Military_Voyage_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Military_Voyage_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Military_Voyage_CdMax )
					_Military_Voyage_Cd = val.Substring(0, (int)Military_Voyage_CdMax);
				else
					_Military_Voyage_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Military_Voyage_Cd");
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
		public string Route_Cd
		{
			get { return _Route_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Route_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Route_CdMax )
					_Route_Cd = val.Substring(0, (int)Route_CdMax);
				else
					_Route_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Route_Cd");
			}
		}
		public string Budget_Period
		{
			get { return _Budget_Period; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Budget_Period, val, false) == 0 ) return;
		
				if( val != null && val.Length > Budget_PeriodMax )
					_Budget_Period = val.Substring(0, (int)Budget_PeriodMax);
				else
					_Budget_Period = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Budget_Period");
			}
		}
		public string Scac_Cd
		{
			get { return _Scac_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Scac_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Scac_CdMax )
					_Scac_Cd = val.Substring(0, (int)Scac_CdMax);
				else
					_Scac_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Scac_Cd");
			}
		}
		public DateTime? Sail_Dt
		{
			get { return _Sail_Dt; }
			set
			{
				if( _Sail_Dt == value ) return;
		
				_Sail_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}
		public string Full_Fl
		{
			get { return _Full_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Full_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Full_FlMax )
					_Full_Fl = val.Substring(0, (int)Full_FlMax);
				else
					_Full_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Full_Fl");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVVoyage() : base() {}
		public ClsVVoyage(DataRow dr) : base(dr) {}
		public ClsVVoyage(ClsVVoyage src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Voyage_Cd = null;
			Military_Voyage_Cd = null;
			Delete_Fl = null;
			Vessel_Cd = null;
			Route_Cd = null;
			Budget_Period = null;
			Scac_Cd = null;
			Sail_Dt = null;
			Full_Fl = null;
		}

		public void CopyFrom(ClsVVoyage src)
		{
			Voyage_Cd = src._Voyage_Cd;
			Military_Voyage_Cd = src._Military_Voyage_Cd;
			Delete_Fl = src._Delete_Fl;
			Vessel_Cd = src._Vessel_Cd;
			Route_Cd = src._Route_Cd;
			Budget_Period = src._Budget_Period;
			Scac_Cd = src._Scac_Cd;
			Sail_Dt = src._Sail_Dt;
			Full_Fl = src._Full_Fl;
		}

		public override bool ReloadFromDB()
		{
			ClsVVoyage tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@VOYAGE_CD", Voyage_Cd);
			p[1] = Connection.GetParameter
				("@MILITARY_VOYAGE_CD", Military_Voyage_Cd);
			p[2] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[3] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[4] = Connection.GetParameter
				("@ROUTE_CD", Route_Cd);
			p[5] = Connection.GetParameter
				("@BUDGET_PERIOD", Budget_Period);
			p[6] = Connection.GetParameter
				("@SCAC_CD", Scac_Cd);
			p[7] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[8] = Connection.GetParameter
				("@FULL_FL", Full_Fl);

			const string sql = @"
				INSERT INTO V_VOYAGE
					(VOYAGE_CD, MILITARY_VOYAGE_CD, DELETE_FL,
					VESSEL_CD, ROUTE_CD, BUDGET_PERIOD,
					SCAC_CD, SAIL_DT, FULL_FL)
				VALUES
					(@VOYAGE_CD, @MILITARY_VOYAGE_CD, @DELETE_FL,
					@VESSEL_CD, @ROUTE_CD, @BUDGET_PERIOD,
					@SCAC_CD, @SAIL_DT, @FULL_FL)
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

			Voyage_Cd = ClsConvert.ToString(dr["VOYAGE_CD"]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD"]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD"]);
			Budget_Period = ClsConvert.ToString(dr["BUDGET_PERIOD"]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Full_Fl = ClsConvert.ToString(dr["FULL_FL"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Voyage_Cd = ClsConvert.ToString(dr["VOYAGE_CD", v]);
			Military_Voyage_Cd = ClsConvert.ToString(dr["MILITARY_VOYAGE_CD", v]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD", v]);
			Budget_Period = ClsConvert.ToString(dr["BUDGET_PERIOD", v]);
			Scac_Cd = ClsConvert.ToString(dr["SCAC_CD", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Full_Fl = ClsConvert.ToString(dr["FULL_FL", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VOYAGE_CD"] = ClsConvert.ToDbObject(Voyage_Cd);
			dr["MILITARY_VOYAGE_CD"] = ClsConvert.ToDbObject(Military_Voyage_Cd);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["ROUTE_CD"] = ClsConvert.ToDbObject(Route_Cd);
			dr["BUDGET_PERIOD"] = ClsConvert.ToDbObject(Budget_Period);
			dr["SCAC_CD"] = ClsConvert.ToDbObject(Scac_Cd);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["FULL_FL"] = ClsConvert.ToDbObject(Full_Fl);
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