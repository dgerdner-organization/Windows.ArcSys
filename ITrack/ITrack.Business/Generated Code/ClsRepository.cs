using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsRepository : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_REPOSITORY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "REPOSITORY_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_REPOSITORY";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Repository_Item_DscMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Repository_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Repository_Item_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Repository_Item_Dsc
		{
			get { return _Repository_Item_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Repository_Item_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Repository_Item_DscMax )
					_Repository_Item_Dsc = val.Substring(0, (int)Repository_Item_DscMax);
				else
					_Repository_Item_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Repository_Item_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsRepository() : base() {}
		public ClsRepository(DataRow dr) : base(dr) {}
		public ClsRepository(ClsRepository src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Repository_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Repository_Item_Dsc = null;
		}

		public void CopyFrom(ClsRepository src)
		{
			Repository_ID = src._Repository_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Repository_Item_Dsc = src._Repository_Item_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsRepository tmp = ClsRepository.GetUsingKey(Repository_ID.Value);
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
				("@REPOSITORY_ITEM_DSC", Repository_Item_Dsc);
			p[1] = Connection.GetParameter
				("@REPOSITORY_ID", Repository_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[2] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[3] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_REPOSITORY
					(REPOSITORY_ID, REPOSITORY_ITEM_DSC)
				VALUES
					(REPOSITORY_ID_SEQ.NEXTVAL, @REPOSITORY_ITEM_DSC)
				RETURNING
					REPOSITORY_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@REPOSITORY_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Repository_ID = ClsConvert.ToInt64Nullable(p[1].Value);
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
				("@REPOSITORY_ITEM_DSC", Repository_Item_Dsc);
			p[2] = Connection.GetParameter
				("@REPOSITORY_ID", Repository_ID);
			p[3] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_REPOSITORY SET
					MODIFY_DT = @MODIFY_DT,
					REPOSITORY_ITEM_DSC = @REPOSITORY_ITEM_DSC
				WHERE
					REPOSITORY_ID = @REPOSITORY_ID
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
				("@REPOSITORY_ID", Repository_ID);

			const string sql = @"
				DELETE FROM T_REPOSITORY WHERE
				REPOSITORY_ID=@REPOSITORY_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Repository_ID = ClsConvert.ToInt64Nullable(dr["REPOSITORY_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Repository_Item_Dsc = ClsConvert.ToString(dr["REPOSITORY_ITEM_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Repository_ID = ClsConvert.ToInt64Nullable(dr["REPOSITORY_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Repository_Item_Dsc = ClsConvert.ToString(dr["REPOSITORY_ITEM_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["REPOSITORY_ID"] = ClsConvert.ToDbObject(Repository_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["REPOSITORY_ITEM_DSC"] = ClsConvert.ToDbObject(Repository_Item_Dsc);
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

		public static ClsRepository GetUsingKey(Int64 Repository_ID)
		{
			object[] vals = new object[] {Repository_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsRepository(dr);
		}

		#endregion		// #region Static Methods
	}
}