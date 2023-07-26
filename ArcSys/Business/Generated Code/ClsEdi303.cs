using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi303 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI303";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI303_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI303 
				INNER JOIN T_ISA
				ON T_EDI303.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Cancel_FlgMax = 1;
		public const int Request_CdMax = 20;
		public const int Booking_NoMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi303_ID;
		protected Int64? _Isa_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected DateTime? _Request_Dt;
		protected string _Cancel_Flg;
		protected string _Request_Cd;
		protected string _Booking_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi303_ID
		{
			get { return _Edi303_ID; }
			set
			{
				if( _Edi303_ID == value ) return;
		
				_Edi303_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi303_ID");
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
		public DateTime? Request_Dt
		{
			get { return _Request_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Request_Dt == val ) return;
		
				_Request_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Request_Dt");
			}
		}
		public string Cancel_Flg
		{
			get { return _Cancel_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cancel_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cancel_FlgMax )
					_Cancel_Flg = val.Substring(0, (int)Cancel_FlgMax);
				else
					_Cancel_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cancel_Flg");
			}
		}
		public string Request_Cd
		{
			get { return _Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Request_CdMax )
					_Request_Cd = val.Substring(0, (int)Request_CdMax);
				else
					_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Request_Cd");
			}
		}
		public string Booking_No
		{
			get { return _Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_NoMax )
					_Booking_No = val.Substring(0, (int)Booking_NoMax);
				else
					_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_No");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi303() : base() {}
		public ClsEdi303(DataRow dr) : base(dr) {}
		public ClsEdi303(ClsEdi303 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi303_ID = null;
			Isa_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Request_Dt = null;
			Cancel_Flg = null;
			Request_Cd = null;
			Booking_No = null;
		}

		public void CopyFrom(ClsEdi303 src)
		{
			Edi303_ID = src._Edi303_ID;
			Isa_ID = src._Isa_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Request_Dt = src._Request_Dt;
			Cancel_Flg = src._Cancel_Flg;
			Request_Cd = src._Request_Cd;
			Booking_No = src._Booking_No;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi303 tmp = ClsEdi303.GetUsingKey(Edi303_ID.Value);
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

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[2] = Connection.GetParameter
				("@CANCEL_FLG", Cancel_Flg);
			p[3] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@EDI303_ID", Edi303_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI303
					(EDI303_ID, ISA_ID, REQUEST_DT,
					CANCEL_FLG, REQUEST_CD, BOOKING_NO)
				VALUES
					(EDI303_ID_SEQ.NEXTVAL, @ISA_ID, @REQUEST_DT,
					@CANCEL_FLG, @REQUEST_CD, @BOOKING_NO)
				RETURNING
					EDI303_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI303_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi303_ID = ClsConvert.ToInt64Nullable(p[5].Value);
			Create_User = ClsConvert.ToString(p[6].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[3] = Connection.GetParameter
				("@CANCEL_FLG", Cancel_Flg);
			p[4] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[5] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[6] = Connection.GetParameter
				("@EDI303_ID", Edi303_ID);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI303 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					REQUEST_DT = @REQUEST_DT,
					CANCEL_FLG = @CANCEL_FLG,
					REQUEST_CD = @REQUEST_CD,
					BOOKING_NO = @BOOKING_NO
				WHERE
					EDI303_ID = @EDI303_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
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

			Edi303_ID = ClsConvert.ToInt64Nullable(dr["EDI303_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Cancel_Flg = ClsConvert.ToString(dr["CANCEL_FLG"]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi303_ID = ClsConvert.ToInt64Nullable(dr["EDI303_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Cancel_Flg = ClsConvert.ToString(dr["CANCEL_FLG", v]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI303_ID"] = ClsConvert.ToDbObject(Edi303_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["CANCEL_FLG"] = ClsConvert.ToDbObject(Cancel_Flg);
			dr["REQUEST_CD"] = ClsConvert.ToDbObject(Request_Cd);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
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

		public static ClsEdi303 GetUsingKey(Int64 Edi303_ID)
		{
			object[] vals = new object[] {Edi303_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi303(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI303.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}