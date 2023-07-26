using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi304 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI304";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI304_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI304 
				LEFT OUTER JOIN T_ISA
				ON T_EDI304.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Trading_Partner_CdMax = 20;
		public const int Bol_NoMax = 20;
		public const int MsgMax = 200;
		public const int Processed_FlgMax = 1;
		public const int Map_NmMax = 20;
		public const int VoyageMax = 10;
		public const int MrnMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi304_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_Nbr;
		protected string _Trading_Partner_Cd;
		protected string _Bol_No;
		protected string _Msg;
		protected string _Processed_Flg;
		protected Int16? _Status_Ind;
		protected Int16? _Exempt_Ind;
		protected string _Map_Nm;
		protected string _Voyage;
		protected string _Mrn;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi304_ID
		{
			get { return _Edi304_ID; }
			set
			{
				if( _Edi304_ID == value ) return;
		
				_Edi304_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi304_ID");
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
		public Int64? Isa_Nbr
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
		public string Bol_No
		{
			get { return _Bol_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_NoMax )
					_Bol_No = val.Substring(0, (int)Bol_NoMax);
				else
					_Bol_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_No");
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
		public Int16? Status_Ind
		{
			get { return _Status_Ind; }
			set
			{
				if( _Status_Ind == value ) return;
		
				_Status_Ind = value;
				_IsDirty = true;
				NotifyPropertyChanged("Status_Ind");
			}
		}
		public Int16? Exempt_Ind
		{
			get { return _Exempt_Ind; }
			set
			{
				if( _Exempt_Ind == value ) return;
		
				_Exempt_Ind = value;
				_IsDirty = true;
				NotifyPropertyChanged("Exempt_Ind");
			}
		}
		public string Map_Nm
		{
			get { return _Map_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_NmMax )
					_Map_Nm = val.Substring(0, (int)Map_NmMax);
				else
					_Map_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_Nm");
			}
		}
		public string Voyage
		{
			get { return _Voyage; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage, val, false) == 0 ) return;
		
				if( val != null && val.Length > VoyageMax )
					_Voyage = val.Substring(0, (int)VoyageMax);
				else
					_Voyage = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage");
			}
		}
		public string Mrn
		{
			get { return _Mrn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mrn, val, false) == 0 ) return;
		
				if( val != null && val.Length > MrnMax )
					_Mrn = val.Substring(0, (int)MrnMax);
				else
					_Mrn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mrn");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi304() : base() {}
		public ClsEdi304(DataRow dr) : base(dr) {}
		public ClsEdi304(ClsEdi304 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi304_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Trading_Partner_Cd = null;
			Bol_No = null;
			Msg = null;
			Processed_Flg = null;
			Status_Ind = null;
			Exempt_Ind = null;
			Map_Nm = null;
			Voyage = null;
			Mrn = null;
		}

		public void CopyFrom(ClsEdi304 src)
		{
			Edi304_ID = src._Edi304_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Bol_No = src._Bol_No;
			Msg = src._Msg;
			Processed_Flg = src._Processed_Flg;
			Status_Ind = src._Status_Ind;
			Exempt_Ind = src._Exempt_Ind;
			Map_Nm = src._Map_Nm;
			Voyage = src._Voyage;
			Mrn = src._Mrn;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi304 tmp = ClsEdi304.GetUsingKey(Edi304_ID.Value);
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

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[4] = Connection.GetParameter
				("@MSG", Msg);
			p[5] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[6] = Connection.GetParameter
				("@STATUS_IND", Status_Ind);
			p[7] = Connection.GetParameter
				("@EXEMPT_IND", Exempt_Ind);
			p[8] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[9] = Connection.GetParameter
				("@VOYAGE", Voyage);
			p[10] = Connection.GetParameter
				("@MRN", Mrn);
			p[11] = Connection.GetParameter
				("@EDI304_ID", Edi304_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[12] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[14] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[15] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI304
					(EDI304_ID, ISA_ID, ISA_NBR,
					TRADING_PARTNER_CD, BOL_NO, MSG,
					PROCESSED_FLG, STATUS_IND, EXEMPT_IND,
					MAP_NM, VOYAGE, MRN)
				VALUES
					(EDI304_ID_SEQ.NEXTVAL, @ISA_ID, @ISA_NBR,
					@TRADING_PARTNER_CD, @BOL_NO, @MSG,
					@PROCESSED_FLG, @STATUS_IND, @EXEMPT_IND,
					@MAP_NM, @VOYAGE, @MRN)
				RETURNING
					EDI304_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI304_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi304_ID = ClsConvert.ToInt64Nullable(p[11].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Create_User = ClsConvert.ToString(p[13].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
			Modify_User = ClsConvert.ToString(p[15].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[5] = Connection.GetParameter
				("@MSG", Msg);
			p[6] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[7] = Connection.GetParameter
				("@STATUS_IND", Status_Ind);
			p[8] = Connection.GetParameter
				("@EXEMPT_IND", Exempt_Ind);
			p[9] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[10] = Connection.GetParameter
				("@VOYAGE", Voyage);
			p[11] = Connection.GetParameter
				("@MRN", Mrn);
			p[12] = Connection.GetParameter
				("@EDI304_ID", Edi304_ID);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI304 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					BOL_NO = @BOL_NO,
					MSG = @MSG,
					PROCESSED_FLG = @PROCESSED_FLG,
					STATUS_IND = @STATUS_IND,
					EXEMPT_IND = @EXEMPT_IND,
					MAP_NM = @MAP_NM,
					VOYAGE = @VOYAGE,
					MRN = @MRN
				WHERE
					EDI304_ID = @EDI304_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
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

			Edi304_ID = ClsConvert.ToInt64Nullable(dr["EDI304_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Msg = ClsConvert.ToString(dr["MSG"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Status_Ind = ClsConvert.ToInt16Nullable(dr["STATUS_IND"]);
			Exempt_Ind = ClsConvert.ToInt16Nullable(dr["EXEMPT_IND"]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM"]);
			Voyage = ClsConvert.ToString(dr["VOYAGE"]);
			Mrn = ClsConvert.ToString(dr["MRN"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi304_ID = ClsConvert.ToInt64Nullable(dr["EDI304_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Msg = ClsConvert.ToString(dr["MSG", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Status_Ind = ClsConvert.ToInt16Nullable(dr["STATUS_IND", v]);
			Exempt_Ind = ClsConvert.ToInt16Nullable(dr["EXEMPT_IND", v]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM", v]);
			Voyage = ClsConvert.ToString(dr["VOYAGE", v]);
			Mrn = ClsConvert.ToString(dr["MRN", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI304_ID"] = ClsConvert.ToDbObject(Edi304_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["MSG"] = ClsConvert.ToDbObject(Msg);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["STATUS_IND"] = ClsConvert.ToDbObject(Status_Ind);
			dr["EXEMPT_IND"] = ClsConvert.ToDbObject(Exempt_Ind);
			dr["MAP_NM"] = ClsConvert.ToDbObject(Map_Nm);
			dr["VOYAGE"] = ClsConvert.ToDbObject(Voyage);
			dr["MRN"] = ClsConvert.ToDbObject(Mrn);
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

		public static ClsEdi304 GetUsingKey(Int64 Edi304_ID)
		{
			object[] vals = new object[] {Edi304_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi304(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI304.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}