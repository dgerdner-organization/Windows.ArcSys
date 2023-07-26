using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundOverht : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_INBOUND_OVERHT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_INBOUND_OVERHT_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI_INBOUND_OVERHT 
				INNER JOIN T_EDI_INBOUND_DETAIL
				ON T_EDI_INBOUND_OVERHT.EDI_INBOUND_DETAIL_ID=T_EDI_INBOUND_DETAIL.EDI_INBOUND_DETAIL_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Inbound_Overht_ID;
		protected Int64? _Edi_Inbound_Detail_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Processed_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Inbound_Overht_ID
		{
			get { return _Edi_Inbound_Overht_ID; }
			set
			{
				if( _Edi_Inbound_Overht_ID == value ) return;
		
				_Edi_Inbound_Overht_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Overht_ID");
			}
		}
		public Int64? Edi_Inbound_Detail_ID
		{
			get { return _Edi_Inbound_Detail_ID; }
			set
			{
				if( _Edi_Inbound_Detail_ID == value ) return;
		
				_Edi_Inbound_Detail_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Detail_ID");
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

		protected ClsEdiInboundDetail _Edi_Inbound_Detail;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEdiInboundDetail Edi_Inbound_Detail
		{
			get
			{
				if( Edi_Inbound_Detail_ID == null )
					_Edi_Inbound_Detail = null;
				else if( _Edi_Inbound_Detail == null ||
					_Edi_Inbound_Detail.Edi_Inbound_Detail_ID != Edi_Inbound_Detail_ID )
					_Edi_Inbound_Detail = ClsEdiInboundDetail.GetUsingKey(Edi_Inbound_Detail_ID.Value);
				return _Edi_Inbound_Detail;
			}
			set
			{
				if( _Edi_Inbound_Detail == value ) return;
		
				_Edi_Inbound_Detail = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiInboundOverht() : base() {}
		public ClsEdiInboundOverht(DataRow dr) : base(dr) {}
		public ClsEdiInboundOverht(ClsEdiInboundOverht src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Inbound_Overht_ID = null;
			Edi_Inbound_Detail_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Processed_Flg = null;
		}

		public void CopyFrom(ClsEdiInboundOverht src)
		{
			Edi_Inbound_Overht_ID = src._Edi_Inbound_Overht_ID;
			Edi_Inbound_Detail_ID = src._Edi_Inbound_Detail_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Processed_Flg = src._Processed_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiInboundOverht tmp = ClsEdiInboundOverht.GetUsingKey(Edi_Inbound_Overht_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Edi_Inbound_Detail = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@EDI_INBOUND_DETAIL_ID", Edi_Inbound_Detail_ID);
			p[1] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[2] = Connection.GetParameter
				("@EDI_INBOUND_OVERHT_ID", Edi_Inbound_Overht_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[3] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[4] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[6] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_INBOUND_OVERHT
					(EDI_INBOUND_OVERHT_ID, EDI_INBOUND_DETAIL_ID, PROCESSED_FLG)
				VALUES
					(EDI_INBOUND_OVERHT_ID_SEQ.NEXTVAL, @EDI_INBOUND_DETAIL_ID, @PROCESSED_FLG)
				RETURNING
					EDI_INBOUND_OVERHT_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_INBOUND_OVERHT_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Inbound_Overht_ID = ClsConvert.ToInt64Nullable(p[2].Value);
			Create_User = ClsConvert.ToString(p[3].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@EDI_INBOUND_DETAIL_ID", Edi_Inbound_Detail_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[3] = Connection.GetParameter
				("@EDI_INBOUND_OVERHT_ID", Edi_Inbound_Overht_ID);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_INBOUND_OVERHT SET
					EDI_INBOUND_DETAIL_ID = @EDI_INBOUND_DETAIL_ID,
					MODIFY_DT = @MODIFY_DT,
					PROCESSED_FLG = @PROCESSED_FLG
				WHERE
					EDI_INBOUND_OVERHT_ID = @EDI_INBOUND_OVERHT_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[4].Value);
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

			Edi_Inbound_Overht_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_OVERHT_ID"]);
			Edi_Inbound_Detail_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_DETAIL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Inbound_Overht_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_OVERHT_ID", v]);
			Edi_Inbound_Detail_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_DETAIL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_INBOUND_OVERHT_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Overht_ID);
			dr["EDI_INBOUND_DETAIL_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Detail_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
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

		public static ClsEdiInboundOverht GetUsingKey(Int64 Edi_Inbound_Overht_ID)
		{
			object[] vals = new object[] {Edi_Inbound_Overht_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiInboundOverht(dr);
		}
		public static DataTable GetAll(Int64? Edi_Inbound_Detail_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi_Inbound_Detail_ID != null && Edi_Inbound_Detail_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI_INBOUND_DETAIL_ID", Edi_Inbound_Detail_ID));
				sb.Append(" WHERE T_EDI_INBOUND_OVERHT.EDI_INBOUND_DETAIL_ID=@EDI_INBOUND_DETAIL_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}