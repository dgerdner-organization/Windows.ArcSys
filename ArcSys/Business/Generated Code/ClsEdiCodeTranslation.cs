using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiCodeTranslation : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_CODE_TRANSLATION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_CODE_TRANSLATION_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI_CODE_TRANSLATION 
				INNER JOIN R_EDI_INTERFACE
				ON T_EDI_CODE_TRANSLATION.EDI_INTERFACE_ID=R_EDI_INTERFACE.EDI_INTERFACE_ID
				INNER JOIN R_EDI_FIELD
				ON T_EDI_CODE_TRANSLATION.EDI_FIELD_ID=R_EDI_FIELD.EDI_FIELD_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int DbcodeMax = 40;
		public const int ExportcodeMax = 40;
		public const int ImportcodeMax = 40;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Code_Translation_ID;
		protected Int64? _Edi_Interface_ID;
		protected Int64? _Edi_Field_ID;
		protected string _Dbcode;
		protected string _Exportcode;
		protected string _Importcode;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Code_Translation_ID
		{
			get { return _Edi_Code_Translation_ID; }
			set
			{
				if( _Edi_Code_Translation_ID == value ) return;
		
				_Edi_Code_Translation_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Code_Translation_ID");
			}
		}
		public Int64? Edi_Interface_ID
		{
			get { return _Edi_Interface_ID; }
			set
			{
				if( _Edi_Interface_ID == value ) return;
		
				_Edi_Interface_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Interface_ID");
			}
		}
		public Int64? Edi_Field_ID
		{
			get { return _Edi_Field_ID; }
			set
			{
				if( _Edi_Field_ID == value ) return;
		
				_Edi_Field_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Field_ID");
			}
		}
		public string Dbcode
		{
			get { return _Dbcode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dbcode, val, false) == 0 ) return;
		
				if( val != null && val.Length > DbcodeMax )
					_Dbcode = val.Substring(0, (int)DbcodeMax);
				else
					_Dbcode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dbcode");
			}
		}
		public string Exportcode
		{
			get { return _Exportcode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Exportcode, val, false) == 0 ) return;
		
				if( val != null && val.Length > ExportcodeMax )
					_Exportcode = val.Substring(0, (int)ExportcodeMax);
				else
					_Exportcode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Exportcode");
			}
		}
		public string Importcode
		{
			get { return _Importcode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Importcode, val, false) == 0 ) return;
		
				if( val != null && val.Length > ImportcodeMax )
					_Importcode = val.Substring(0, (int)ImportcodeMax);
				else
					_Importcode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Importcode");
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

		public ClsEdiCodeTranslation() : base() {}
		public ClsEdiCodeTranslation(DataRow dr) : base(dr) {}
		public ClsEdiCodeTranslation(ClsEdiCodeTranslation src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Code_Translation_ID = null;
			Edi_Interface_ID = null;
			Edi_Field_ID = null;
			Dbcode = null;
			Exportcode = null;
			Importcode = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
		}

		public void CopyFrom(ClsEdiCodeTranslation src)
		{
			Edi_Code_Translation_ID = src._Edi_Code_Translation_ID;
			Edi_Interface_ID = src._Edi_Interface_ID;
			Edi_Field_ID = src._Edi_Field_ID;
			Dbcode = src._Dbcode;
			Exportcode = src._Exportcode;
			Importcode = src._Importcode;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiCodeTranslation tmp = ClsEdiCodeTranslation.GetUsingKey(Edi_Code_Translation_ID.Value);
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
				("@EDI_INTERFACE_ID", Edi_Interface_ID);
			p[1] = Connection.GetParameter
				("@EDI_FIELD_ID", Edi_Field_ID);
			p[2] = Connection.GetParameter
				("@DBCODE", Dbcode);
			p[3] = Connection.GetParameter
				("@EXPORTCODE", Exportcode);
			p[4] = Connection.GetParameter
				("@IMPORTCODE", Importcode);
			p[5] = Connection.GetParameter
				("@EDI_CODE_TRANSLATION_ID", Edi_Code_Translation_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_CODE_TRANSLATION
					(EDI_CODE_TRANSLATION_ID, EDI_INTERFACE_ID, EDI_FIELD_ID,
					DBCODE, EXPORTCODE, IMPORTCODE)
				VALUES
					(EDI_CODE_TRANSLATION_ID_SEQ.NEXTVAL, @EDI_INTERFACE_ID, @EDI_FIELD_ID,
					@DBCODE, @EXPORTCODE, @IMPORTCODE)
				RETURNING
					EDI_CODE_TRANSLATION_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_CODE_TRANSLATION_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Code_Translation_ID = ClsConvert.ToInt64Nullable(p[5].Value);
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
				("@EDI_INTERFACE_ID", Edi_Interface_ID);
			p[1] = Connection.GetParameter
				("@EDI_FIELD_ID", Edi_Field_ID);
			p[2] = Connection.GetParameter
				("@DBCODE", Dbcode);
			p[3] = Connection.GetParameter
				("@EXPORTCODE", Exportcode);
			p[4] = Connection.GetParameter
				("@IMPORTCODE", Importcode);
			p[5] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@EDI_CODE_TRANSLATION_ID", Edi_Code_Translation_ID);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_CODE_TRANSLATION SET
					EDI_INTERFACE_ID = @EDI_INTERFACE_ID,
					EDI_FIELD_ID = @EDI_FIELD_ID,
					DBCODE = @DBCODE,
					EXPORTCODE = @EXPORTCODE,
					IMPORTCODE = @IMPORTCODE,
					MODIFY_DT = @MODIFY_DT
				WHERE
					EDI_CODE_TRANSLATION_ID = @EDI_CODE_TRANSLATION_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
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

			Edi_Code_Translation_ID = ClsConvert.ToInt64Nullable(dr["EDI_CODE_TRANSLATION_ID"]);
			Edi_Interface_ID = ClsConvert.ToInt64Nullable(dr["EDI_INTERFACE_ID"]);
			Edi_Field_ID = ClsConvert.ToInt64Nullable(dr["EDI_FIELD_ID"]);
			Dbcode = ClsConvert.ToString(dr["DBCODE"]);
			Exportcode = ClsConvert.ToString(dr["EXPORTCODE"]);
			Importcode = ClsConvert.ToString(dr["IMPORTCODE"]);
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

			Edi_Code_Translation_ID = ClsConvert.ToInt64Nullable(dr["EDI_CODE_TRANSLATION_ID", v]);
			Edi_Interface_ID = ClsConvert.ToInt64Nullable(dr["EDI_INTERFACE_ID", v]);
			Edi_Field_ID = ClsConvert.ToInt64Nullable(dr["EDI_FIELD_ID", v]);
			Dbcode = ClsConvert.ToString(dr["DBCODE", v]);
			Exportcode = ClsConvert.ToString(dr["EXPORTCODE", v]);
			Importcode = ClsConvert.ToString(dr["IMPORTCODE", v]);
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

			dr["EDI_CODE_TRANSLATION_ID"] = ClsConvert.ToDbObject(Edi_Code_Translation_ID);
			dr["EDI_INTERFACE_ID"] = ClsConvert.ToDbObject(Edi_Interface_ID);
			dr["EDI_FIELD_ID"] = ClsConvert.ToDbObject(Edi_Field_ID);
			dr["DBCODE"] = ClsConvert.ToDbObject(Dbcode);
			dr["EXPORTCODE"] = ClsConvert.ToDbObject(Exportcode);
			dr["IMPORTCODE"] = ClsConvert.ToDbObject(Importcode);
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

		public static ClsEdiCodeTranslation GetUsingKey(Int64 Edi_Code_Translation_ID)
		{
			object[] vals = new object[] {Edi_Code_Translation_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiCodeTranslation(dr);
		}
		public static DataTable GetAll(Int64? Edi_Interface_ID, Int64? Edi_Field_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi_Interface_ID != null && Edi_Interface_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI_INTERFACE_ID", Edi_Interface_ID));
				sb.Append(" WHERE T_EDI_CODE_TRANSLATION.EDI_INTERFACE_ID=@EDI_INTERFACE_ID");
			}
			if( Edi_Field_ID != null && Edi_Field_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI_FIELD_ID", Edi_Field_ID));
				sb.AppendFormat(" {0} T_EDI_CODE_TRANSLATION.EDI_FIELD_ID=@EDI_FIELD_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}