using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsStenaRouteSailing : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_STENA_ROUTE_SAILING";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "STENA_ROUTE_SAILING_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_STENA_ROUTE_SAILING 
				LEFT OUTER JOIN R_STENA_ROUTE
				ON R_STENA_ROUTE_SAILING.ROUTE_CD=R_STENA_ROUTE.ROUTE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Route_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Vessel_NmMax = 100;
		public const int Status_DscMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Stena_Route_Sailing_ID;
		protected string _Route_Cd;
		protected DateTime? _Sailing_Dt;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Vessel_Nm;
		protected DateTime? _Arrive_Dt;
		protected string _Status_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Stena_Route_Sailing_ID
		{
			get { return _Stena_Route_Sailing_ID; }
			set
			{
				if( _Stena_Route_Sailing_ID == value ) return;
		
				_Stena_Route_Sailing_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Stena_Route_Sailing_ID");
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
		public DateTime? Sailing_Dt
		{
			get { return _Sailing_Dt; }
			set
			{
				if( _Sailing_Dt == value ) return;
		
				_Sailing_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Sailing_Dt");
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
		public string Vessel_Nm
		{
			get { return _Vessel_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_NmMax )
					_Vessel_Nm = val.Substring(0, (int)Vessel_NmMax);
				else
					_Vessel_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Nm");
			}
		}
		public DateTime? Arrive_Dt
		{
			get { return _Arrive_Dt; }
			set
			{
				if( _Arrive_Dt == value ) return;
		
				_Arrive_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrive_Dt");
			}
		}
		public string Status_Dsc
		{
			get { return _Status_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_DscMax )
					_Status_Dsc = val.Substring(0, (int)Status_DscMax);
				else
					_Status_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsStenaRoute _Route;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsStenaRoute Route
		{
			get
			{
				if( Route_Cd == null )
					_Route = null;
				else if( _Route == null ||
					_Route.Route_Cd != Route_Cd )
					_Route = ClsStenaRoute.GetUsingKey(Route_Cd);
				return _Route;
			}
			set
			{
				if( _Route == value ) return;
		
				_Route = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsStenaRouteSailing() : base() {}
		public ClsStenaRouteSailing(DataRow dr) : base(dr) {}
		public ClsStenaRouteSailing(ClsStenaRouteSailing src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Stena_Route_Sailing_ID = null;
			Route_Cd = null;
			Sailing_Dt = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Vessel_Nm = null;
			Arrive_Dt = null;
			Status_Dsc = null;
		}

		public void CopyFrom(ClsStenaRouteSailing src)
		{
			Stena_Route_Sailing_ID = src._Stena_Route_Sailing_ID;
			Route_Cd = src._Route_Cd;
			Sailing_Dt = src._Sailing_Dt;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Vessel_Nm = src._Vessel_Nm;
			Arrive_Dt = src._Arrive_Dt;
			Status_Dsc = src._Status_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsStenaRouteSailing tmp = ClsStenaRouteSailing.GetUsingKey(Stena_Route_Sailing_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Route = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@ROUTE_CD", Route_Cd);
			p[1] = Connection.GetParameter
				("@SAILING_DT", Sailing_Dt);
			p[2] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[3] = Connection.GetParameter
				("@ARRIVE_DT", Arrive_Dt);
			p[4] = Connection.GetParameter
				("@STATUS_DSC", Status_Dsc);
			p[5] = Connection.GetParameter
				("@STENA_ROUTE_SAILING_ID", Stena_Route_Sailing_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_STENA_ROUTE_SAILING
					(STENA_ROUTE_SAILING_ID, ROUTE_CD, SAILING_DT,
					VESSEL_NM, ARRIVE_DT, STATUS_DSC)
				VALUES
					(STENA_ROUTE_SAILING_ID_SEQ.NEXTVAL, @ROUTE_CD, @SAILING_DT,
					@VESSEL_NM, @ARRIVE_DT, @STATUS_DSC)
				RETURNING
					STENA_ROUTE_SAILING_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@STENA_ROUTE_SAILING_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Stena_Route_Sailing_ID = ClsConvert.ToInt64Nullable(p[5].Value);
			Create_User = ClsConvert.ToString(p[6].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@ROUTE_CD", Route_Cd);
			p[1] = Connection.GetParameter
				("@SAILING_DT", Sailing_Dt);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[4] = Connection.GetParameter
				("@ARRIVE_DT", Arrive_Dt);
			p[5] = Connection.GetParameter
				("@STATUS_DSC", Status_Dsc);
			p[6] = Connection.GetParameter
				("@STENA_ROUTE_SAILING_ID", Stena_Route_Sailing_ID);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_STENA_ROUTE_SAILING SET
					ROUTE_CD = @ROUTE_CD,
					SAILING_DT = @SAILING_DT,
					MODIFY_DT = @MODIFY_DT,
					VESSEL_NM = @VESSEL_NM,
					ARRIVE_DT = @ARRIVE_DT,
					STATUS_DSC = @STATUS_DSC
				WHERE
					STENA_ROUTE_SAILING_ID = @STENA_ROUTE_SAILING_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@STENA_ROUTE_SAILING_ID", Stena_Route_Sailing_ID);

			const string sql = @"
				DELETE FROM R_STENA_ROUTE_SAILING WHERE
				STENA_ROUTE_SAILING_ID=@STENA_ROUTE_SAILING_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Stena_Route_Sailing_ID = ClsConvert.ToInt64Nullable(dr["STENA_ROUTE_SAILING_ID"]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD"]);
			Sailing_Dt = ClsConvert.ToDateTimeNullable(dr["SAILING_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM"]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT"]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Stena_Route_Sailing_ID = ClsConvert.ToInt64Nullable(dr["STENA_ROUTE_SAILING_ID", v]);
			Route_Cd = ClsConvert.ToString(dr["ROUTE_CD", v]);
			Sailing_Dt = ClsConvert.ToDateTimeNullable(dr["SAILING_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM", v]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT", v]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["STENA_ROUTE_SAILING_ID"] = ClsConvert.ToDbObject(Stena_Route_Sailing_ID);
			dr["ROUTE_CD"] = ClsConvert.ToDbObject(Route_Cd);
			dr["SAILING_DT"] = ClsConvert.ToDbObject(Sailing_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VESSEL_NM"] = ClsConvert.ToDbObject(Vessel_Nm);
			dr["ARRIVE_DT"] = ClsConvert.ToDbObject(Arrive_Dt);
			dr["STATUS_DSC"] = ClsConvert.ToDbObject(Status_Dsc);
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

		public static ClsStenaRouteSailing GetUsingKey(Int64 Stena_Route_Sailing_ID)
		{
			object[] vals = new object[] {Stena_Route_Sailing_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsStenaRouteSailing(dr);
		}
		public static DataTable GetAll(string Route_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Route_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ROUTE_CD", Route_Cd));
				sb.Append(" WHERE R_STENA_ROUTE_SAILING.ROUTE_CD=@ROUTE_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}