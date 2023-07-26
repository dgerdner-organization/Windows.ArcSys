using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsOceanExportQueue : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_OCEAN_EXPORT_QUEUE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "OCEAN_EXPORT_QUEUE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_OCEAN_EXPORT_QUEUE 
				LEFT OUTER JOIN R_TRADING_PARTNER
				ON T_OCEAN_EXPORT_QUEUE.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Document_TypeMax = 50;
		public const int Document_No_1Max = 50;
		public const int Document_No_2Max = 50;
		public const int Activity_CdMax = 50;
		public const int Trading_Partner_CdMax = 10;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ocean_Export_Queue_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Document_Type;
		protected string _Document_No_1;
		protected string _Document_No_2;
		protected string _Activity_Cd;
		protected string _Trading_Partner_Cd;
		protected string _Processed_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ocean_Export_Queue_ID
		{
			get { return _Ocean_Export_Queue_ID; }
			set
			{
				if( _Ocean_Export_Queue_ID == value ) return;
		
				_Ocean_Export_Queue_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Export_Queue_ID");
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
		public string Document_Type
		{
			get { return _Document_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Document_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Document_TypeMax )
					_Document_Type = val.Substring(0, (int)Document_TypeMax);
				else
					_Document_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Document_Type");
			}
		}
		public string Document_No_1
		{
			get { return _Document_No_1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Document_No_1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Document_No_1Max )
					_Document_No_1 = val.Substring(0, (int)Document_No_1Max);
				else
					_Document_No_1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Document_No_1");
			}
		}
		public string Document_No_2
		{
			get { return _Document_No_2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Document_No_2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Document_No_2Max )
					_Document_No_2 = val.Substring(0, (int)Document_No_2Max);
				else
					_Document_No_2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Document_No_2");
			}
		}
		public string Activity_Cd
		{
			get { return _Activity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CdMax )
					_Activity_Cd = val.Substring(0, (int)Activity_CdMax);
				else
					_Activity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Cd");
			}
		}
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
			}
		}
		public string Processed_Flg
		{
			get { return _Processed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_FlgMax )
					_Processed_Flg = val.Substring(0, (int)Processed_FlgMax);
				else
					_Processed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsOceanExportQueue() : base() {}
		public ClsOceanExportQueue(DataRow dr) : base(dr) {}
		public ClsOceanExportQueue(ClsOceanExportQueue src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ocean_Export_Queue_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Document_Type = null;
			Document_No_1 = null;
			Document_No_2 = null;
			Activity_Cd = null;
			Trading_Partner_Cd = null;
			Processed_Flg = null;
		}

		public void CopyFrom(ClsOceanExportQueue src)
		{
			Ocean_Export_Queue_ID = src._Ocean_Export_Queue_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Document_Type = src._Document_Type;
			Document_No_1 = src._Document_No_1;
			Document_No_2 = src._Document_No_2;
			Activity_Cd = src._Activity_Cd;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Processed_Flg = src._Processed_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsOceanExportQueue tmp = ClsOceanExportQueue.GetUsingKey(Ocean_Export_Queue_ID.Value);
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
				("@DOCUMENT_TYPE", Document_Type);
			p[1] = Connection.GetParameter
				("@DOCUMENT_NO_1", Document_No_1);
			p[2] = Connection.GetParameter
				("@DOCUMENT_NO_2", Document_No_2);
			p[3] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[4] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[5] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[6] = Connection.GetParameter
				("@OCEAN_EXPORT_QUEUE_ID", Ocean_Export_Queue_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_OCEAN_EXPORT_QUEUE
					(OCEAN_EXPORT_QUEUE_ID, DOCUMENT_TYPE, DOCUMENT_NO_1,
					DOCUMENT_NO_2, ACTIVITY_CD, TRADING_PARTNER_CD,
					PROCESSED_FLG)
				VALUES
					(OCEAN_EXPORT_QUEUE_ID_SEQ.NEXTVAL, @DOCUMENT_TYPE, @DOCUMENT_NO_1,
					@DOCUMENT_NO_2, @ACTIVITY_CD, @TRADING_PARTNER_CD,
					@PROCESSED_FLG)
				RETURNING
					OCEAN_EXPORT_QUEUE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@OCEAN_EXPORT_QUEUE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ocean_Export_Queue_ID = ClsConvert.ToInt64Nullable(p[6].Value);
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
				("@DOCUMENT_TYPE", Document_Type);
			p[2] = Connection.GetParameter
				("@DOCUMENT_NO_1", Document_No_1);
			p[3] = Connection.GetParameter
				("@DOCUMENT_NO_2", Document_No_2);
			p[4] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[5] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[6] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[7] = Connection.GetParameter
				("@OCEAN_EXPORT_QUEUE_ID", Ocean_Export_Queue_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_OCEAN_EXPORT_QUEUE SET
					MODIFY_DT = @MODIFY_DT,
					DOCUMENT_TYPE = @DOCUMENT_TYPE,
					DOCUMENT_NO_1 = @DOCUMENT_NO_1,
					DOCUMENT_NO_2 = @DOCUMENT_NO_2,
					ACTIVITY_CD = @ACTIVITY_CD,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					PROCESSED_FLG = @PROCESSED_FLG
				WHERE
					OCEAN_EXPORT_QUEUE_ID = @OCEAN_EXPORT_QUEUE_ID
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

			Ocean_Export_Queue_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_EXPORT_QUEUE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Document_Type = ClsConvert.ToString(dr["DOCUMENT_TYPE"]);
			Document_No_1 = ClsConvert.ToString(dr["DOCUMENT_NO_1"]);
			Document_No_2 = ClsConvert.ToString(dr["DOCUMENT_NO_2"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ocean_Export_Queue_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_EXPORT_QUEUE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Document_Type = ClsConvert.ToString(dr["DOCUMENT_TYPE", v]);
			Document_No_1 = ClsConvert.ToString(dr["DOCUMENT_NO_1", v]);
			Document_No_2 = ClsConvert.ToString(dr["DOCUMENT_NO_2", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["OCEAN_EXPORT_QUEUE_ID"] = ClsConvert.ToDbObject(Ocean_Export_Queue_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["DOCUMENT_TYPE"] = ClsConvert.ToDbObject(Document_Type);
			dr["DOCUMENT_NO_1"] = ClsConvert.ToDbObject(Document_No_1);
			dr["DOCUMENT_NO_2"] = ClsConvert.ToDbObject(Document_No_2);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
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

		public static ClsOceanExportQueue GetUsingKey(Int64 Ocean_Export_Queue_ID)
		{
			object[] vals = new object[] {Ocean_Export_Queue_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsOceanExportQueue(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE T_OCEAN_EXPORT_QUEUE.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}