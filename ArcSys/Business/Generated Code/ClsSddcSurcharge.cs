using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsSddcSurcharge : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_SDDC_SURCHARGE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LINE_CHARGE_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_SDDC_SURCHARGE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Line_Charge_CdMax = 10;
		public const int Sddc_Charge_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Line_Charge_Cd;
		protected string _Sddc_Charge_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Line_Charge_Cd
		{
			get { return _Line_Charge_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Charge_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_Charge_CdMax )
					_Line_Charge_Cd = val.Substring(0, (int)Line_Charge_CdMax);
				else
					_Line_Charge_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Charge_Cd");
			}
		}
		public string Sddc_Charge_Cd
		{
			get { return _Sddc_Charge_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Sddc_Charge_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Sddc_Charge_CdMax )
					_Sddc_Charge_Cd = val.Substring(0, (int)Sddc_Charge_CdMax);
				else
					_Sddc_Charge_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Sddc_Charge_Cd");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsSddcSurcharge() : base() {}
		public ClsSddcSurcharge(DataRow dr) : base(dr) {}
		public ClsSddcSurcharge(ClsSddcSurcharge src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Line_Charge_Cd = null;
			Sddc_Charge_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
		}

		public void CopyFrom(ClsSddcSurcharge src)
		{
			Line_Charge_Cd = src._Line_Charge_Cd;
			Sddc_Charge_Cd = src._Sddc_Charge_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsSddcSurcharge tmp = ClsSddcSurcharge.GetUsingKey(Line_Charge_Cd);
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

			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@LINE_CHARGE_CD", Line_Charge_Cd);
			p[1] = Connection.GetParameter
				("@SDDC_CHARGE_CD", Sddc_Charge_Cd);
			p[2] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[3] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_SDDC_SURCHARGE
					(LINE_CHARGE_CD, SDDC_CHARGE_CD)
				VALUES
					(@LINE_CHARGE_CD, @SDDC_CHARGE_CD)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[2].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[4].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@SDDC_CHARGE_CD", Sddc_Charge_Cd);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@LINE_CHARGE_CD", Line_Charge_Cd);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_SDDC_SURCHARGE SET
					SDDC_CHARGE_CD = @SDDC_CHARGE_CD,
					MODIFY_DT = @MODIFY_DT
				WHERE
					LINE_CHARGE_CD = @LINE_CHARGE_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[3].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@LINE_CHARGE_CD", Line_Charge_Cd);

			const string sql = @"
				DELETE FROM R_SDDC_SURCHARGE WHERE
				LINE_CHARGE_CD=@LINE_CHARGE_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Line_Charge_Cd = ClsConvert.ToString(dr["LINE_CHARGE_CD"]);
			Sddc_Charge_Cd = ClsConvert.ToString(dr["SDDC_CHARGE_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Line_Charge_Cd = ClsConvert.ToString(dr["LINE_CHARGE_CD", v]);
			Sddc_Charge_Cd = ClsConvert.ToString(dr["SDDC_CHARGE_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LINE_CHARGE_CD"] = ClsConvert.ToDbObject(Line_Charge_Cd);
			dr["SDDC_CHARGE_CD"] = ClsConvert.ToDbObject(Sddc_Charge_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
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

		public static ClsSddcSurcharge GetUsingKey(string Line_Charge_Cd)
		{
			object[] vals = new object[] {Line_Charge_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsSddcSurcharge(dr);
		}

		#endregion		// #region Static Methods
	}
}