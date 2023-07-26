using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsLocation : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_LOCATION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LOCATION_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_LOCATION";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Location_CdMax = 10;
		public const int Location_DscMax = 50;
		public const int Delete_FlMax = 1;
		public const int Country_CdMax = 3;
		public const int Census_CdMax = 30;
		public const int Other1_CdMax = 30;
		public const int Other2_CdMax = 30;
		public const int Census_TypeMax = 1;
		public const int State_CdMax = 2;
		public const int CityMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Location_Cd;
		protected string _Location_Dsc;
		protected string _Delete_Fl;
		protected string _Country_Cd;
		protected string _Census_Cd;
		protected string _Other1_Cd;
		protected string _Other2_Cd;
		protected string _Census_Type;
		protected string _State_Cd;
		protected string _City;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Location_Dsc
		{
			get { return _Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_DscMax )
					_Location_Dsc = val.Substring(0, (int)Location_DscMax);
				else
					_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Dsc");
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
		public string Country_Cd
		{
			get { return _Country_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_CdMax )
					_Country_Cd = val.Substring(0, (int)Country_CdMax);
				else
					_Country_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_Cd");
			}
		}
		public string Census_Cd
		{
			get { return _Census_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Census_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Census_CdMax )
					_Census_Cd = val.Substring(0, (int)Census_CdMax);
				else
					_Census_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Census_Cd");
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
		public string Other2_Cd
		{
			get { return _Other2_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Other2_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Other2_CdMax )
					_Other2_Cd = val.Substring(0, (int)Other2_CdMax);
				else
					_Other2_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Other2_Cd");
			}
		}
		public string Census_Type
		{
			get { return _Census_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Census_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Census_TypeMax )
					_Census_Type = val.Substring(0, (int)Census_TypeMax);
				else
					_Census_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Census_Type");
			}
		}
		public string State_Cd
		{
			get { return _State_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_State_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > State_CdMax )
					_State_Cd = val.Substring(0, (int)State_CdMax);
				else
					_State_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("State_Cd");
			}
		}
		public string City
		{
			get { return _City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > CityMax )
					_City = val.Substring(0, (int)CityMax);
				else
					_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("City");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLocation() : base() {}
		public ClsLocation(DataRow dr) : base(dr) {}
		public ClsLocation(ClsLocation src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Location_Cd = null;
			Location_Dsc = null;
			Delete_Fl = null;
			Country_Cd = null;
			Census_Cd = null;
			Other1_Cd = null;
			Other2_Cd = null;
			Census_Type = null;
			State_Cd = null;
			City = null;
		}

		public void CopyFrom(ClsLocation src)
		{
			Location_Cd = src._Location_Cd;
			Location_Dsc = src._Location_Dsc;
			Delete_Fl = src._Delete_Fl;
			Country_Cd = src._Country_Cd;
			Census_Cd = src._Census_Cd;
			Other1_Cd = src._Other1_Cd;
			Other2_Cd = src._Other2_Cd;
			Census_Type = src._Census_Type;
			State_Cd = src._State_Cd;
			City = src._City;
		}

		public override bool ReloadFromDB()
		{
			ClsLocation tmp = ClsLocation.GetUsingKey(Location_Cd);
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
				("@LOCATION_CD", Location_Cd);
			p[1] = Connection.GetParameter
				("@LOCATION_DSC", Location_Dsc);
			p[2] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[3] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[4] = Connection.GetParameter
				("@CENSUS_CD", Census_Cd);
			p[5] = Connection.GetParameter
				("@OTHER1_CD", Other1_Cd);
			p[6] = Connection.GetParameter
				("@OTHER2_CD", Other2_Cd);
			p[7] = Connection.GetParameter
				("@CENSUS_TYPE", Census_Type);
			p[8] = Connection.GetParameter
				("@STATE_CD", State_Cd);
			p[9] = Connection.GetParameter
				("@CITY", City);

			const string sql = @"
				INSERT INTO R_LOCATION
					(LOCATION_CD, LOCATION_DSC, DELETE_FL,
					COUNTRY_CD, CENSUS_CD, OTHER1_CD,
					OTHER2_CD, CENSUS_TYPE, STATE_CD,
					CITY)
				VALUES
					(@LOCATION_CD, @LOCATION_DSC, @DELETE_FL,
					@COUNTRY_CD, @CENSUS_CD, @OTHER1_CD,
					@OTHER2_CD, @CENSUS_TYPE, @STATE_CD,
					@CITY)
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@LOCATION_DSC", Location_Dsc);
			p[1] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[2] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[3] = Connection.GetParameter
				("@CENSUS_CD", Census_Cd);
			p[4] = Connection.GetParameter
				("@OTHER1_CD", Other1_Cd);
			p[5] = Connection.GetParameter
				("@OTHER2_CD", Other2_Cd);
			p[6] = Connection.GetParameter
				("@CENSUS_TYPE", Census_Type);
			p[7] = Connection.GetParameter
				("@STATE_CD", State_Cd);
			p[8] = Connection.GetParameter
				("@CITY", City);
			p[9] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);

			const string sql = @"
				UPDATE R_LOCATION SET
					LOCATION_DSC = @LOCATION_DSC,
					DELETE_FL = @DELETE_FL,
					COUNTRY_CD = @COUNTRY_CD,
					CENSUS_CD = @CENSUS_CD,
					OTHER1_CD = @OTHER1_CD,
					OTHER2_CD = @OTHER2_CD,
					CENSUS_TYPE = @CENSUS_TYPE,
					STATE_CD = @STATE_CD,
					CITY = @CITY
				WHERE
					LOCATION_CD = @LOCATION_CD
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);

			const string sql = @"
				DELETE FROM R_LOCATION WHERE
				LOCATION_CD=@LOCATION_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Location_Dsc = ClsConvert.ToString(dr["LOCATION_DSC"]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD"]);
			Census_Cd = ClsConvert.ToString(dr["CENSUS_CD"]);
			Other1_Cd = ClsConvert.ToString(dr["OTHER1_CD"]);
			Other2_Cd = ClsConvert.ToString(dr["OTHER2_CD"]);
			Census_Type = ClsConvert.ToString(dr["CENSUS_TYPE"]);
			State_Cd = ClsConvert.ToString(dr["STATE_CD"]);
			City = ClsConvert.ToString(dr["CITY"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Location_Dsc = ClsConvert.ToString(dr["LOCATION_DSC", v]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD", v]);
			Census_Cd = ClsConvert.ToString(dr["CENSUS_CD", v]);
			Other1_Cd = ClsConvert.ToString(dr["OTHER1_CD", v]);
			Other2_Cd = ClsConvert.ToString(dr["OTHER2_CD", v]);
			Census_Type = ClsConvert.ToString(dr["CENSUS_TYPE", v]);
			State_Cd = ClsConvert.ToString(dr["STATE_CD", v]);
			City = ClsConvert.ToString(dr["CITY", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["LOCATION_DSC"] = ClsConvert.ToDbObject(Location_Dsc);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["COUNTRY_CD"] = ClsConvert.ToDbObject(Country_Cd);
			dr["CENSUS_CD"] = ClsConvert.ToDbObject(Census_Cd);
			dr["OTHER1_CD"] = ClsConvert.ToDbObject(Other1_Cd);
			dr["OTHER2_CD"] = ClsConvert.ToDbObject(Other2_Cd);
			dr["CENSUS_TYPE"] = ClsConvert.ToDbObject(Census_Type);
			dr["STATE_CD"] = ClsConvert.ToDbObject(State_Cd);
			dr["CITY"] = ClsConvert.ToDbObject(City);
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

		public static ClsLocation GetUsingKey(string Location_Cd)
		{
			object[] vals = new object[] {Location_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLocation(dr);
		}

		#endregion		// #region Static Methods
	}
}