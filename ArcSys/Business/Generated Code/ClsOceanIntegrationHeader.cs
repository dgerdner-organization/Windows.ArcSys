using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsOceanIntegrationHeader : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_OCEAN_INTEGRATION_HEADER";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "OCEAN_INTEGRATION_HEADER_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_OCEAN_INTEGRATION_HEADER";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Type_CdMax = 20;
		public const int Activity_CdMax = 20;
		public const int Document_No_1Max = 50;
		public const int Document_No_2Max = 50;
		public const int Processed_Import_FlgMax = 1;
		public const int Processed_Export_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ocean_Integration_Header_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Type_Cd;
		protected string _Activity_Cd;
		protected string _Document_No_1;
		protected Int64? _Document_Id_1;
		protected string _Document_No_2;
		protected Int64? _Document_Id_2;
		protected string _Processed_Import_Flg;
		protected string _Processed_Export_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ocean_Integration_Header_ID
		{
			get { return _Ocean_Integration_Header_ID; }
			set
			{
				if( _Ocean_Integration_Header_ID == value ) return;
		
				_Ocean_Integration_Header_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Integration_Header_ID");
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
		public string Type_Cd
		{
			get { return _Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Type_CdMax )
					_Type_Cd = val.Substring(0, (int)Type_CdMax);
				else
					_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Type_Cd");
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
		public Int64? Document_Id_1
		{
			get { return _Document_Id_1; }
			set
			{
				if( _Document_Id_1 == value ) return;
		
				_Document_Id_1 = value;
				_IsDirty = true;
				NotifyPropertyChanged("Document_Id_1");
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
		public Int64? Document_Id_2
		{
			get { return _Document_Id_2; }
			set
			{
				if( _Document_Id_2 == value ) return;
		
				_Document_Id_2 = value;
				_IsDirty = true;
				NotifyPropertyChanged("Document_Id_2");
			}
		}
		public string Processed_Import_Flg
		{
			get { return _Processed_Import_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Import_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_Import_FlgMax )
					_Processed_Import_Flg = val.Substring(0, (int)Processed_Import_FlgMax);
				else
					_Processed_Import_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Import_Flg");
			}
		}
		public string Processed_Export_Flg
		{
			get { return _Processed_Export_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Export_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_Export_FlgMax )
					_Processed_Export_Flg = val.Substring(0, (int)Processed_Export_FlgMax);
				else
					_Processed_Export_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Export_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsOceanIntegrationHeader() : base() {}
		public ClsOceanIntegrationHeader(DataRow dr) : base(dr) {}
		public ClsOceanIntegrationHeader(ClsOceanIntegrationHeader src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ocean_Integration_Header_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Type_Cd = null;
			Activity_Cd = null;
			Document_No_1 = null;
			Document_Id_1 = null;
			Document_No_2 = null;
			Document_Id_2 = null;
			Processed_Import_Flg = null;
			Processed_Export_Flg = null;
		}

		public void CopyFrom(ClsOceanIntegrationHeader src)
		{
			Ocean_Integration_Header_ID = src._Ocean_Integration_Header_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Type_Cd = src._Type_Cd;
			Activity_Cd = src._Activity_Cd;
			Document_No_1 = src._Document_No_1;
			Document_Id_1 = src._Document_Id_1;
			Document_No_2 = src._Document_No_2;
			Document_Id_2 = src._Document_Id_2;
			Processed_Import_Flg = src._Processed_Import_Flg;
			Processed_Export_Flg = src._Processed_Export_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsOceanIntegrationHeader tmp = ClsOceanIntegrationHeader.GetUsingKey(Ocean_Integration_Header_ID.Value);
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

			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@OCEAN_INTEGRATION_HEADER_ID", Ocean_Integration_Header_ID);
			p[1] = Connection.GetParameter
				("@TYPE_CD", Type_Cd);
			p[2] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[3] = Connection.GetParameter
				("@DOCUMENT_NO_1", Document_No_1);
			p[4] = Connection.GetParameter
				("@DOCUMENT_ID_1", Document_Id_1);
			p[5] = Connection.GetParameter
				("@DOCUMENT_NO_2", Document_No_2);
			p[6] = Connection.GetParameter
				("@DOCUMENT_ID_2", Document_Id_2);
			p[7] = Connection.GetParameter
				("@PROCESSED_IMPORT_FLG", Processed_Import_Flg);
			p[8] = Connection.GetParameter
				("@PROCESSED_EXPORT_FLG", Processed_Export_Flg);
			p[9] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[10] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[12] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_OCEAN_INTEGRATION_HEADER
					(OCEAN_INTEGRATION_HEADER_ID, TYPE_CD, ACTIVITY_CD,
					DOCUMENT_NO_1, DOCUMENT_ID_1, DOCUMENT_NO_2,
					DOCUMENT_ID_2, PROCESSED_IMPORT_FLG, PROCESSED_EXPORT_FLG)
				VALUES
					(@OCEAN_INTEGRATION_HEADER_ID, @TYPE_CD, @ACTIVITY_CD,
					@DOCUMENT_NO_1, @DOCUMENT_ID_1, @DOCUMENT_NO_2,
					@DOCUMENT_ID_2, @PROCESSED_IMPORT_FLG, @PROCESSED_EXPORT_FLG)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[9].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@TYPE_CD", Type_Cd);
			p[2] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[3] = Connection.GetParameter
				("@DOCUMENT_NO_1", Document_No_1);
			p[4] = Connection.GetParameter
				("@DOCUMENT_ID_1", Document_Id_1);
			p[5] = Connection.GetParameter
				("@DOCUMENT_NO_2", Document_No_2);
			p[6] = Connection.GetParameter
				("@DOCUMENT_ID_2", Document_Id_2);
			p[7] = Connection.GetParameter
				("@PROCESSED_IMPORT_FLG", Processed_Import_Flg);
			p[8] = Connection.GetParameter
				("@PROCESSED_EXPORT_FLG", Processed_Export_Flg);
			p[9] = Connection.GetParameter
				("@OCEAN_INTEGRATION_HEADER_ID", Ocean_Integration_Header_ID);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_OCEAN_INTEGRATION_HEADER SET
					MODIFY_DT = @MODIFY_DT,
					TYPE_CD = @TYPE_CD,
					ACTIVITY_CD = @ACTIVITY_CD,
					DOCUMENT_NO_1 = @DOCUMENT_NO_1,
					DOCUMENT_ID_1 = @DOCUMENT_ID_1,
					DOCUMENT_NO_2 = @DOCUMENT_NO_2,
					DOCUMENT_ID_2 = @DOCUMENT_ID_2,
					PROCESSED_IMPORT_FLG = @PROCESSED_IMPORT_FLG,
					PROCESSED_EXPORT_FLG = @PROCESSED_EXPORT_FLG
				WHERE
					OCEAN_INTEGRATION_HEADER_ID = @OCEAN_INTEGRATION_HEADER_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[10].Value);
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

			Ocean_Integration_Header_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_INTEGRATION_HEADER_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Type_Cd = ClsConvert.ToString(dr["TYPE_CD"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Document_No_1 = ClsConvert.ToString(dr["DOCUMENT_NO_1"]);
			Document_Id_1 = ClsConvert.ToInt64Nullable(dr["DOCUMENT_ID_1"]);
			Document_No_2 = ClsConvert.ToString(dr["DOCUMENT_NO_2"]);
			Document_Id_2 = ClsConvert.ToInt64Nullable(dr["DOCUMENT_ID_2"]);
			Processed_Import_Flg = ClsConvert.ToString(dr["PROCESSED_IMPORT_FLG"]);
			Processed_Export_Flg = ClsConvert.ToString(dr["PROCESSED_EXPORT_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ocean_Integration_Header_ID = ClsConvert.ToInt64Nullable(dr["OCEAN_INTEGRATION_HEADER_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Type_Cd = ClsConvert.ToString(dr["TYPE_CD", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Document_No_1 = ClsConvert.ToString(dr["DOCUMENT_NO_1", v]);
			Document_Id_1 = ClsConvert.ToInt64Nullable(dr["DOCUMENT_ID_1", v]);
			Document_No_2 = ClsConvert.ToString(dr["DOCUMENT_NO_2", v]);
			Document_Id_2 = ClsConvert.ToInt64Nullable(dr["DOCUMENT_ID_2", v]);
			Processed_Import_Flg = ClsConvert.ToString(dr["PROCESSED_IMPORT_FLG", v]);
			Processed_Export_Flg = ClsConvert.ToString(dr["PROCESSED_EXPORT_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["OCEAN_INTEGRATION_HEADER_ID"] = ClsConvert.ToDbObject(Ocean_Integration_Header_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["TYPE_CD"] = ClsConvert.ToDbObject(Type_Cd);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["DOCUMENT_NO_1"] = ClsConvert.ToDbObject(Document_No_1);
			dr["DOCUMENT_ID_1"] = ClsConvert.ToDbObject(Document_Id_1);
			dr["DOCUMENT_NO_2"] = ClsConvert.ToDbObject(Document_No_2);
			dr["DOCUMENT_ID_2"] = ClsConvert.ToDbObject(Document_Id_2);
			dr["PROCESSED_IMPORT_FLG"] = ClsConvert.ToDbObject(Processed_Import_Flg);
			dr["PROCESSED_EXPORT_FLG"] = ClsConvert.ToDbObject(Processed_Export_Flg);
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

		public static ClsOceanIntegrationHeader GetUsingKey(Int64 Ocean_Integration_Header_ID)
		{
			object[] vals = new object[] {Ocean_Integration_Header_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsOceanIntegrationHeader(dr);
		}

		#endregion		// #region Static Methods
	}
}