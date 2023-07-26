using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMemo : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_MEMO";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "MEMO_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_MEMO";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Memo_DscMax = 75;
		public const int Memo_TxtMax = 500;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Ven_Visible_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Memo_ID;
		protected string _Memo_Dsc;
		protected string _Memo_Txt;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Ven_Visible_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Memo_ID
		{
			get { return _Memo_ID; }
			set
			{
				if( _Memo_ID == value ) return;
		
				_Memo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Memo_ID");
			}
		}
		public string Memo_Dsc
		{
			get { return _Memo_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Memo_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Memo_DscMax )
					_Memo_Dsc = val.Substring(0, (int)Memo_DscMax);
				else
					_Memo_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Memo_Dsc");
			}
		}
		public string Memo_Txt
		{
			get { return _Memo_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Memo_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Memo_TxtMax )
					_Memo_Txt = val.Substring(0, (int)Memo_TxtMax);
				else
					_Memo_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Memo_Txt");
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
		public string Ven_Visible_Flg
		{
			get { return _Ven_Visible_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ven_Visible_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ven_Visible_FlgMax )
					_Ven_Visible_Flg = val.Substring(0, (int)Ven_Visible_FlgMax);
				else
					_Ven_Visible_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ven_Visible_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsMemo() : base() {}
		public ClsMemo(DataRow dr) : base(dr) {}
		public ClsMemo(ClsMemo src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Memo_ID = null;
			Memo_Dsc = null;
			Memo_Txt = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Ven_Visible_Flg = null;
		}

		public void CopyFrom(ClsMemo src)
		{
			Memo_ID = src._Memo_ID;
			Memo_Dsc = src._Memo_Dsc;
			Memo_Txt = src._Memo_Txt;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Ven_Visible_Flg = src._Ven_Visible_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsMemo tmp = ClsMemo.GetUsingKey(Memo_ID.Value);
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
				("@MEMO_DSC", Memo_Dsc);
			p[1] = Connection.GetParameter
				("@MEMO_TXT", Memo_Txt);
			p[2] = Connection.GetParameter
				("@VEN_VISIBLE_FLG", Ven_Visible_Flg);
			p[3] = Connection.GetParameter
				("@MEMO_ID", Memo_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_MEMO
					(MEMO_ID, MEMO_DSC, MEMO_TXT,
					VEN_VISIBLE_FLG)
				VALUES
					(MEMO_ID_SEQ.NEXTVAL, @MEMO_DSC, @MEMO_TXT,
					@VEN_VISIBLE_FLG)
				RETURNING
					MEMO_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@MEMO_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Memo_ID = ClsConvert.ToInt64Nullable(p[3].Value);
			Create_User = ClsConvert.ToString(p[4].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@MEMO_DSC", Memo_Dsc);
			p[1] = Connection.GetParameter
				("@MEMO_TXT", Memo_Txt);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@VEN_VISIBLE_FLG", Ven_Visible_Flg);
			p[4] = Connection.GetParameter
				("@MEMO_ID", Memo_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_MEMO SET
					MEMO_DSC = @MEMO_DSC,
					MEMO_TXT = @MEMO_TXT,
					MODIFY_DT = @MODIFY_DT,
					VEN_VISIBLE_FLG = @VEN_VISIBLE_FLG
				WHERE
					MEMO_ID = @MEMO_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@MEMO_ID", Memo_ID);

			const string sql = @"
				DELETE FROM T_MEMO WHERE
				MEMO_ID=@MEMO_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Memo_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ID"]);
			Memo_Dsc = ClsConvert.ToString(dr["MEMO_DSC"]);
			Memo_Txt = ClsConvert.ToString(dr["MEMO_TXT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Ven_Visible_Flg = ClsConvert.ToString(dr["VEN_VISIBLE_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Memo_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ID", v]);
			Memo_Dsc = ClsConvert.ToString(dr["MEMO_DSC", v]);
			Memo_Txt = ClsConvert.ToString(dr["MEMO_TXT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Ven_Visible_Flg = ClsConvert.ToString(dr["VEN_VISIBLE_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["MEMO_ID"] = ClsConvert.ToDbObject(Memo_ID);
			dr["MEMO_DSC"] = ClsConvert.ToDbObject(Memo_Dsc);
			dr["MEMO_TXT"] = ClsConvert.ToDbObject(Memo_Txt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VEN_VISIBLE_FLG"] = ClsConvert.ToDbObject(Ven_Visible_Flg);
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

		public static ClsMemo GetUsingKey(Int64 Memo_ID)
		{
			object[] vals = new object[] {Memo_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsMemo(dr);
		}

		#endregion		// #region Static Methods
	}
}