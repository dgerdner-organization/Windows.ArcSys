using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsContractMod : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CONTRACT_MOD";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CONTRACT_MOD_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_CONTRACT_MOD";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Mod_NoMax = 25;
		public const int Mod_NotesMax = 500;
		public const int Attachment_NmMax = 250;
		public const long AttachmentMax = 4294967294;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Contract_Mod_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Mod_No;
		protected string _Mod_Notes;
		protected string _Attachment_Nm;
		protected byte[] _Attachment;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Contract_Mod_ID
		{
			get { return _Contract_Mod_ID; }
			set
			{
				if( _Contract_Mod_ID == value ) return;
		
				_Contract_Mod_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Contract_Mod_ID");
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
		public string Mod_No
		{
			get { return _Mod_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mod_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Mod_NoMax )
					_Mod_No = val.Substring(0, (int)Mod_NoMax);
				else
					_Mod_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mod_No");
			}
		}
		public string Mod_Notes
		{
			get { return _Mod_Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mod_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > Mod_NotesMax )
					_Mod_Notes = val.Substring(0, (int)Mod_NotesMax);
				else
					_Mod_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mod_Notes");
			}
		}
		public string Attachment_Nm
		{
			get { return _Attachment_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Attachment_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Attachment_NmMax )
					_Attachment_Nm = val.Substring(0, (int)Attachment_NmMax);
				else
					_Attachment_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Attachment_Nm");
			}
		}
		public byte[] Attachment
		{
			get { return _Attachment; }
			set
			{
				if( _Attachment == value ) return;
		
				if( value == null || value.LongLength <= 0 )
				{
					if( _Attachment == null ) return;
		
					_Attachment = null;
				}
				else
				{
					long sz = ( value.LongLength < AttachmentMax ) ?
						value.LongLength : AttachmentMax;
					if( _Attachment == null ||
						_Attachment.LongLength != sz )
							_Attachment = new byte[sz];
					Array.Copy(value, _Attachment, sz);
				}
		
				_IsDirty = true;
				NotifyPropertyChanged("Attachment");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsContractMod() : base() {}
		public ClsContractMod(DataRow dr) : base(dr) {}
		public ClsContractMod(ClsContractMod src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Contract_Mod_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Mod_No = null;
			Mod_Notes = null;
			Attachment_Nm = null;
			Attachment = null;
		}

		public void CopyFrom(ClsContractMod src)
		{
			Contract_Mod_ID = src._Contract_Mod_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Mod_No = src._Mod_No;
			Mod_Notes = src._Mod_Notes;
			Attachment_Nm = src._Attachment_Nm;
			Attachment = (byte[])src._Attachment.Clone();
		}

		public override bool ReloadFromDB()
		{
			ClsContractMod tmp = ClsContractMod.GetUsingKey(Contract_Mod_ID.Value);
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

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@MOD_NO", Mod_No);
			p[1] = Connection.GetParameter
				("@MOD_NOTES", Mod_Notes);
			p[2] = Connection.GetParameter
				("@ATTACHMENT_NM", Attachment_Nm);
			p[3] = Connection.GetParameter
				("@ATTACHMENT", Attachment, ParameterDirection.Input, DbType.Binary, 0);
			p[4] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CONTRACT_MOD
					(CONTRACT_MOD_ID, MOD_NO, MOD_NOTES,
					ATTACHMENT_NM, ATTACHMENT)
				VALUES
					(CONTRACT_MOD_ID_SEQ.NEXTVAL, @MOD_NO, @MOD_NOTES,
					@ATTACHMENT_NM, @ATTACHMENT)
				RETURNING
					CONTRACT_MOD_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CONTRACT_MOD_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Contract_Mod_ID = ClsConvert.ToInt64Nullable(p[4].Value);
			Create_User = ClsConvert.ToString(p[5].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@MOD_NO", Mod_No);
			p[2] = Connection.GetParameter
				("@MOD_NOTES", Mod_Notes);
			p[3] = Connection.GetParameter
				("@ATTACHMENT_NM", Attachment_Nm);
			p[4] = Connection.GetParameter
				("@ATTACHMENT", Attachment, ParameterDirection.Input, DbType.Binary, 0);
			p[5] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CONTRACT_MOD SET
					MODIFY_DT = @MODIFY_DT,
					MOD_NO = @MOD_NO,
					MOD_NOTES = @MOD_NOTES,
					ATTACHMENT_NM = @ATTACHMENT_NM,
					ATTACHMENT = @ATTACHMENT
				WHERE
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);

			const string sql = @"
				DELETE FROM T_CONTRACT_MOD WHERE
				CONTRACT_MOD_ID=@CONTRACT_MOD_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Mod_No = ClsConvert.ToString(dr["MOD_NO"]);
			Mod_Notes = ClsConvert.ToString(dr["MOD_NOTES"]);
			Attachment_Nm = ClsConvert.ToString(dr["ATTACHMENT_NM"]);
			Attachment = ClsConvert.ToByteArray(dr["ATTACHMENT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Mod_No = ClsConvert.ToString(dr["MOD_NO", v]);
			Mod_Notes = ClsConvert.ToString(dr["MOD_NOTES", v]);
			Attachment_Nm = ClsConvert.ToString(dr["ATTACHMENT_NM", v]);
			Attachment = ClsConvert.ToByteArray(dr["ATTACHMENT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CONTRACT_MOD_ID"] = ClsConvert.ToDbObject(Contract_Mod_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MOD_NO"] = ClsConvert.ToDbObject(Mod_No);
			dr["MOD_NOTES"] = ClsConvert.ToDbObject(Mod_Notes);
			dr["ATTACHMENT_NM"] = ClsConvert.ToDbObject(Attachment_Nm);
			dr["ATTACHMENT"] = ClsConvert.ToDbObject(Attachment);
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

		public static ClsContractMod GetUsingKey(Int64 Contract_Mod_ID)
		{
			object[] vals = new object[] {Contract_Mod_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsContractMod(dr);
		}

		#endregion		// #region Static Methods
	}
}