using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVessel : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_VESSEL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VESSEL_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_VESSEL";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vessel_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Vessel_NmMax = 50;
		public const int Active_FlgMax = 1;
		public const int Arc_FlgMax = 1;
		public const int Ircs_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Vessel_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Vessel_Nm;
		protected string _Active_Flg;
		protected string _Arc_Flg;
		protected string _Ircs_Cd;
		protected Int32? _Avg_Hfo_Per_Hr;
		protected Int32? _Avg_Mdo_Per_Hr;

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
		public string Arc_Flg
		{
			get { return _Arc_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arc_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Arc_FlgMax )
					_Arc_Flg = val.Substring(0, (int)Arc_FlgMax);
				else
					_Arc_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arc_Flg");
			}
		}
		public string Ircs_Cd
		{
			get { return _Ircs_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ircs_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ircs_CdMax )
					_Ircs_Cd = val.Substring(0, (int)Ircs_CdMax);
				else
					_Ircs_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ircs_Cd");
			}
		}
		public Int32? Avg_Hfo_Per_Hr
		{
			get { return _Avg_Hfo_Per_Hr; }
			set
			{
				if( _Avg_Hfo_Per_Hr == value ) return;
		
				_Avg_Hfo_Per_Hr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Avg_Hfo_Per_Hr");
			}
		}
		public Int32? Avg_Mdo_Per_Hr
		{
			get { return _Avg_Mdo_Per_Hr; }
			set
			{
				if( _Avg_Mdo_Per_Hr == value ) return;
		
				_Avg_Mdo_Per_Hr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Avg_Mdo_Per_Hr");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVessel() : base() {}
		public ClsVessel(DataRow dr) : base(dr) {}
		public ClsVessel(ClsVessel src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vessel_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Vessel_Nm = null;
			Active_Flg = null;
			Arc_Flg = null;
			Ircs_Cd = null;
			Avg_Hfo_Per_Hr = null;
			Avg_Mdo_Per_Hr = null;
		}

		public void CopyFrom(ClsVessel src)
		{
			Vessel_Cd = src._Vessel_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Vessel_Nm = src._Vessel_Nm;
			Active_Flg = src._Active_Flg;
			Arc_Flg = src._Arc_Flg;
			Ircs_Cd = src._Ircs_Cd;
			Avg_Hfo_Per_Hr = src._Avg_Hfo_Per_Hr;
			Avg_Mdo_Per_Hr = src._Avg_Mdo_Per_Hr;
		}

		public override bool ReloadFromDB()
		{
			ClsVessel tmp = ClsVessel.GetUsingKey(Vessel_Cd);
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

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[1] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@ARC_FLG", Arc_Flg);
			p[4] = Connection.GetParameter
				("@IRCS_CD", Ircs_Cd);
			p[5] = Connection.GetParameter
				("@AVG_HFO_PER_HR", Avg_Hfo_Per_Hr);
			p[6] = Connection.GetParameter
				("@AVG_MDO_PER_HR", Avg_Mdo_Per_Hr);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_VESSEL
					(VESSEL_CD, VESSEL_NM, ACTIVE_FLG,
					ARC_FLG, IRCS_CD, AVG_HFO_PER_HR,
					AVG_MDO_PER_HR)
				VALUES
					(@VESSEL_CD, @VESSEL_NM, @ACTIVE_FLG,
					@ARC_FLG, @IRCS_CD, @AVG_HFO_PER_HR,
					@AVG_MDO_PER_HR)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[7].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@ARC_FLG", Arc_Flg);
			p[4] = Connection.GetParameter
				("@IRCS_CD", Ircs_Cd);
			p[5] = Connection.GetParameter
				("@AVG_HFO_PER_HR", Avg_Hfo_Per_Hr);
			p[6] = Connection.GetParameter
				("@AVG_MDO_PER_HR", Avg_Mdo_Per_Hr);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_VESSEL SET
					MODIFY_DT = @MODIFY_DT,
					VESSEL_NM = @VESSEL_NM,
					ACTIVE_FLG = @ACTIVE_FLG,
					ARC_FLG = @ARC_FLG,
					IRCS_CD = @IRCS_CD,
					AVG_HFO_PER_HR = @AVG_HFO_PER_HR,
					AVG_MDO_PER_HR = @AVG_MDO_PER_HR
				WHERE
					VESSEL_CD = @VESSEL_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);

			const string sql = @"
				DELETE FROM R_VESSEL WHERE
				VESSEL_CD=@VESSEL_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Arc_Flg = ClsConvert.ToString(dr["ARC_FLG"]);
			Ircs_Cd = ClsConvert.ToString(dr["IRCS_CD"]);
			Avg_Hfo_Per_Hr = ClsConvert.ToInt32Nullable(dr["AVG_HFO_PER_HR"]);
			Avg_Mdo_Per_Hr = ClsConvert.ToInt32Nullable(dr["AVG_MDO_PER_HR"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Arc_Flg = ClsConvert.ToString(dr["ARC_FLG", v]);
			Ircs_Cd = ClsConvert.ToString(dr["IRCS_CD", v]);
			Avg_Hfo_Per_Hr = ClsConvert.ToInt32Nullable(dr["AVG_HFO_PER_HR", v]);
			Avg_Mdo_Per_Hr = ClsConvert.ToInt32Nullable(dr["AVG_MDO_PER_HR", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VESSEL_NM"] = ClsConvert.ToDbObject(Vessel_Nm);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["ARC_FLG"] = ClsConvert.ToDbObject(Arc_Flg);
			dr["IRCS_CD"] = ClsConvert.ToDbObject(Ircs_Cd);
			dr["AVG_HFO_PER_HR"] = ClsConvert.ToDbObject(Avg_Hfo_Per_Hr);
			dr["AVG_MDO_PER_HR"] = ClsConvert.ToDbObject(Avg_Mdo_Per_Hr);
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

		public static ClsVessel GetUsingKey(string Vessel_Cd)
		{
			object[] vals = new object[] {Vessel_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsVessel(dr);
		}

		#endregion		// #region Static Methods
	}
}