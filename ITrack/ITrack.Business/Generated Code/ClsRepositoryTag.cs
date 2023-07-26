using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsRepositoryTag : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_REPOSITORY_TAG";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "REPOSITORY_TAG_NM" };
		}

		public const string SelectSQL = @"SELECT * FROM T_REPOSITORY_TAG 
				INNER JOIN T_REPOSITORY
				ON T_REPOSITORY_TAG.REPOSITORY_ID=T_REPOSITORY.REPOSITORY_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Repository_Tag_NmMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Repository_Tag_Nm;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Repository_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Repository_Tag_Nm
		{
			get { return _Repository_Tag_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Repository_Tag_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Repository_Tag_NmMax )
					_Repository_Tag_Nm = val.Substring(0, (int)Repository_Tag_NmMax);
				else
					_Repository_Tag_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Repository_Tag_Nm");
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
		public Int64? Repository_ID
		{
			get { return _Repository_ID; }
			set
			{
				if( _Repository_ID == value ) return;
		
				_Repository_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Repository_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsRepository _Repository;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsRepository Repository
		{
			get
			{
				if( Repository_ID == null )
					_Repository = null;
				else if( _Repository == null ||
					_Repository.Repository_ID != Repository_ID )
					_Repository = ClsRepository.GetUsingKey(Repository_ID.Value);
				return _Repository;
			}
			set
			{
				if( _Repository == value ) return;
		
				_Repository = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsRepositoryTag() : base() {}
		public ClsRepositoryTag(DataRow dr) : base(dr) {}
		public ClsRepositoryTag(ClsRepositoryTag src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Repository_Tag_Nm = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Repository_ID = null;
		}

		public void CopyFrom(ClsRepositoryTag src)
		{
			Repository_Tag_Nm = src._Repository_Tag_Nm;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Repository_ID = src._Repository_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsRepositoryTag tmp = ClsRepositoryTag.GetUsingKey(Repository_Tag_Nm);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Repository = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@REPOSITORY_TAG_NM", Repository_Tag_Nm);
			p[1] = Connection.GetParameter
				("@REPOSITORY_ID", Repository_ID);
			p[2] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[3] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_REPOSITORY_TAG
					(REPOSITORY_TAG_NM, REPOSITORY_ID)
				VALUES
					(@REPOSITORY_TAG_NM, @REPOSITORY_ID)
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
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@REPOSITORY_ID", Repository_ID);
			p[2] = Connection.GetParameter
				("@REPOSITORY_TAG_NM", Repository_Tag_Nm);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_REPOSITORY_TAG SET
					MODIFY_DT = @MODIFY_DT,
					REPOSITORY_ID = @REPOSITORY_ID
				WHERE
					REPOSITORY_TAG_NM = @REPOSITORY_TAG_NM
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[3].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@REPOSITORY_TAG_NM", Repository_Tag_Nm);

			const string sql = @"
				DELETE FROM T_REPOSITORY_TAG WHERE
				REPOSITORY_TAG_NM=@REPOSITORY_TAG_NM";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Repository_Tag_Nm = ClsConvert.ToString(dr["REPOSITORY_TAG_NM"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Repository_ID = ClsConvert.ToInt64Nullable(dr["REPOSITORY_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Repository_Tag_Nm = ClsConvert.ToString(dr["REPOSITORY_TAG_NM", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Repository_ID = ClsConvert.ToInt64Nullable(dr["REPOSITORY_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["REPOSITORY_TAG_NM"] = ClsConvert.ToDbObject(Repository_Tag_Nm);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["REPOSITORY_ID"] = ClsConvert.ToDbObject(Repository_ID);
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

		public static ClsRepositoryTag GetUsingKey(string Repository_Tag_Nm)
		{
			object[] vals = new object[] {Repository_Tag_Nm};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsRepositoryTag(dr);
		}
		public static DataTable GetAll(Int64? Repository_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Repository_ID != null && Repository_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@REPOSITORY_ID", Repository_ID));
				sb.Append(" WHERE T_REPOSITORY_TAG.REPOSITORY_ID=@REPOSITORY_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}