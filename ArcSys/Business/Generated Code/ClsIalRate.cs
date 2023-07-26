using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsIalRate : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_IAL_RATE";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM R_IAL_RATE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Rate_Type_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ial_Rate_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Rate_Type_Cd;
		protected decimal? _Rate_Amt;
		protected DateTime? _Effective_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ial_Rate_ID
		{
			get { return _Ial_Rate_ID; }
			set
			{
				if( _Ial_Rate_ID == value ) return;
		
				_Ial_Rate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ial_Rate_ID");
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
		public string Rate_Type_Cd
		{
			get { return _Rate_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rate_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rate_Type_CdMax )
					_Rate_Type_Cd = val.Substring(0, (int)Rate_Type_CdMax);
				else
					_Rate_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Type_Cd");
			}
		}
		public decimal? Rate_Amt
		{
			get { return _Rate_Amt; }
			set
			{
				if( _Rate_Amt == value ) return;
		
				_Rate_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Amt");
			}
		}
		public DateTime? Effective_Dt
		{
			get { return _Effective_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Effective_Dt == val ) return;
		
				_Effective_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Effective_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsIalRate() : base() {}
		public ClsIalRate(DataRow dr) : base(dr) {}
		public ClsIalRate(ClsIalRate src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ial_Rate_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Rate_Type_Cd = null;
			Rate_Amt = null;
			Effective_Dt = null;
		}

		public void CopyFrom(ClsIalRate src)
		{
			Ial_Rate_ID = src._Ial_Rate_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Rate_Type_Cd = src._Rate_Type_Cd;
			Rate_Amt = src._Rate_Amt;
			Effective_Dt = src._Effective_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsIalRate tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@IAL_RATE_ID", Ial_Rate_ID);
			p[1] = Connection.GetParameter
				("@RATE_TYPE_CD", Rate_Type_Cd);
			p[2] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[3] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_IAL_RATE
					(IAL_RATE_ID, RATE_TYPE_CD, RATE_AMT,
					EFFECTIVE_DT)
				VALUES
					(@IAL_RATE_ID, @RATE_TYPE_CD, @RATE_AMT,
					@EFFECTIVE_DT)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[4].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
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
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@IAL_RATE_ID", Ial_Rate_ID);
			p[1] = Connection.GetParameter
				("@CREATE_USER", Create_User);
			p[2] = Connection.GetParameter
				("@CREATE_DT", Create_Dt);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User);
			p[4] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt);
			p[5] = Connection.GetParameter
				("@RATE_TYPE_CD", Rate_Type_Cd);
			p[6] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[7] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);

			const string sql = @"
				DELETE FROM R_IAL_RATE WHERE
				IAL_RATE_ID=@IAL_RATE_ID AND CREATE_USER=@CREATE_USER
				 AND CREATE_DT=@CREATE_DT AND MODIFY_USER=@MODIFY_USER
				 AND MODIFY_DT=@MODIFY_DT AND RATE_TYPE_CD=@RATE_TYPE_CD
				 AND RATE_AMT=@RATE_AMT AND EFFECTIVE_DT=@EFFECTIVE_DT";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ial_Rate_ID = ClsConvert.ToInt64Nullable(dr["IAL_RATE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Rate_Type_Cd = ClsConvert.ToString(dr["RATE_TYPE_CD"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ial_Rate_ID = ClsConvert.ToInt64Nullable(dr["IAL_RATE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Rate_Type_Cd = ClsConvert.ToString(dr["RATE_TYPE_CD", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["IAL_RATE_ID"] = ClsConvert.ToDbObject(Ial_Rate_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["RATE_TYPE_CD"] = ClsConvert.ToDbObject(Rate_Type_Cd);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["EFFECTIVE_DT"] = ClsConvert.ToDbObject(Effective_Dt);
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