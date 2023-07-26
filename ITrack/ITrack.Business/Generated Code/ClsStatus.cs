using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsStatus : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_STATUS";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "STATUS_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_STATUS";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Status_CdMax = 10;
		public const int Status_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Status_Cd;
		protected string _Status_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Status_Cd
		{
			get { return _Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_CdMax )
					_Status_Cd = val.Substring(0, (int)Status_CdMax);
				else
					_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Cd");
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

		public ClsStatus() : base() {}
		public ClsStatus(DataRow dr) : base(dr) {}
		public ClsStatus(ClsStatus src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Status_Cd = null;
			Status_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
		}

		public void CopyFrom(ClsStatus src)
		{
			Status_Cd = src._Status_Cd;
			Status_Dsc = src._Status_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsStatus tmp = ClsStatus.GetUsingKey(Status_Cd);
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
				("@STATUS_CD", Status_Cd);
			p[1] = Connection.GetParameter
				("@STATUS_DSC", Status_Dsc);
			p[2] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[3] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_STATUS
					(STATUS_CD, STATUS_DSC)
				VALUES
					(@STATUS_CD, @STATUS_DSC)
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
				("@STATUS_DSC", Status_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@STATUS_CD", Status_Cd);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_STATUS SET
					STATUS_DSC = @STATUS_DSC,
					MODIFY_DT = @MODIFY_DT
				WHERE
					STATUS_CD = @STATUS_CD
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
				("@STATUS_CD", Status_Cd);

			const string sql = @"
				DELETE FROM R_STATUS WHERE
				STATUS_CD=@STATUS_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Status_Cd = ClsConvert.ToString(dr["STATUS_CD"]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC"]);
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

			Status_Cd = ClsConvert.ToString(dr["STATUS_CD", v]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC", v]);
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

			dr["STATUS_CD"] = ClsConvert.ToDbObject(Status_Cd);
			dr["STATUS_DSC"] = ClsConvert.ToDbObject(Status_Dsc);
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

		public static ClsStatus GetUsingKey(string Status_Cd)
		{
			object[] vals = new object[] {Status_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsStatus(dr);
		}

		#endregion		// #region Static Methods
	}
}