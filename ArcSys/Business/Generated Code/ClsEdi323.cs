using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi323 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI323";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI323_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI323 
				INNER JOIN T_ISA
				ON T_EDI323.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 10;
		public const int MsgMax = 200;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi323_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected decimal? _Isa_Nbr;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected string _Msg;
		protected string _Processed_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi323_ID
		{
			get { return _Edi323_ID; }
			set
			{
				if( _Edi323_ID == value ) return;
		
				_Edi323_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi323_ID");
			}
		}
		public Int64? Isa_ID
		{
			get { return _Isa_ID; }
			set
			{
				if( _Isa_ID == value ) return;
		
				_Isa_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_ID");
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
		public decimal? Isa_Nbr
		{
			get { return _Isa_Nbr; }
			set
			{
				if( _Isa_Nbr == value ) return;
		
				_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Nbr");
			}
		}
		public string Voyage_No
		{
			get { return _Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_NoMax )
					_Voyage_No = val.Substring(0, (int)Voyage_NoMax);
				else
					_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_No");
			}
		}
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
		public string Msg
		{
			get { return _Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > MsgMax )
					_Msg = val.Substring(0, (int)MsgMax);
				else
					_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Msg");
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

		protected ClsIsa _Isa;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsIsa Isa
		{
			get
			{
				if( Isa_ID == null )
					_Isa = null;
				else if( _Isa == null ||
					_Isa.Isa_ID != Isa_ID )
					_Isa = ClsIsa.GetUsingKey(Isa_ID.Value);
				return _Isa;
			}
			set
			{
				if( _Isa == value ) return;
		
				_Isa = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi323() : base() {}
		public ClsEdi323(DataRow dr) : base(dr) {}
		public ClsEdi323(ClsEdi323 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi323_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Msg = null;
			Processed_Flg = null;
		}

		public void CopyFrom(ClsEdi323 src)
		{
			Edi323_ID = src._Edi323_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Msg = src._Msg;
			Processed_Flg = src._Processed_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi323 tmp = ClsEdi323.GetUsingKey(Edi323_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Isa = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@EDI323_ID", Edi323_ID);
			p[1] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[4] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[5] = Connection.GetParameter
				("@MSG", Msg);
			p[6] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI323
					(EDI323_ID, ISA_ID, ISA_NBR,
					VOYAGE_NO, VESSEL_CD, MSG,
					PROCESSED_FLG)
				VALUES
					(@EDI323_ID, @ISA_ID, @ISA_NBR,
					@VOYAGE_NO, @VESSEL_CD, @MSG,
					@PROCESSED_FLG)
				RETURNING
					CREATE_DT, CREATE_USER, MODIFY_DT,
					MODIFY_USER
				INTO
					@CREATE_DT, @CREATE_USER, @MODIFY_DT,
					@MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Create_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			Modify_User = ClsConvert.ToString(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[4] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[5] = Connection.GetParameter
				("@MSG", Msg);
			p[6] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[7] = Connection.GetParameter
				("@EDI323_ID", Edi323_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI323 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					VOYAGE_NO = @VOYAGE_NO,
					VESSEL_CD = @VESSEL_CD,
					MSG = @MSG,
					PROCESSED_FLG = @PROCESSED_FLG
				WHERE
					EDI323_ID = @EDI323_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
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

			Edi323_ID = ClsConvert.ToInt64Nullable(dr["EDI323_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Msg = ClsConvert.ToString(dr["MSG"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi323_ID = ClsConvert.ToInt64Nullable(dr["EDI323_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Msg = ClsConvert.ToString(dr["MSG", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI323_ID"] = ClsConvert.ToDbObject(Edi323_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["MSG"] = ClsConvert.ToDbObject(Msg);
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

		public static ClsEdi323 GetUsingKey(Int64 Edi323_ID)
		{
			object[] vals = new object[] {Edi323_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi323(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI323.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}