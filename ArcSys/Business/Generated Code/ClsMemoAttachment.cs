using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMemoAttachment : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_MEMO_ATTACHMENT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "MEMO_ATTACHMENT_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_MEMO_ATTACHMENT 
				INNER JOIN T_MEMO
				ON T_MEMO_ATTACHMENT.MEMO_ID=T_MEMO.MEMO_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Attachment_NmMax = 250;
		public const long AttachmentMax = 4294967294;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Memo_Attachment_ID;
		protected Int64? _Memo_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Attachment_Nm;
		protected byte[] _Attachment;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Memo_Attachment_ID
		{
			get { return _Memo_Attachment_ID; }
			set
			{
				if( _Memo_Attachment_ID == value ) return;
		
				_Memo_Attachment_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Memo_Attachment_ID");
			}
		}
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

		protected ClsMemo _Memo;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsMemo Memo
		{
			get
			{
				if( Memo_ID == null )
					_Memo = null;
				else if( _Memo == null ||
					_Memo.Memo_ID != Memo_ID )
					_Memo = ClsMemo.GetUsingKey(Memo_ID.Value);
				return _Memo;
			}
			set
			{
				if( _Memo == value ) return;
		
				_Memo = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsMemoAttachment() : base() {}
		public ClsMemoAttachment(DataRow dr) : base(dr) {}
		public ClsMemoAttachment(ClsMemoAttachment src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Memo_Attachment_ID = null;
			Memo_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Attachment_Nm = null;
			Attachment = null;
		}

		public void CopyFrom(ClsMemoAttachment src)
		{
			Memo_Attachment_ID = src._Memo_Attachment_ID;
			Memo_ID = src._Memo_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Attachment_Nm = src._Attachment_Nm;
			Attachment = (byte[])src._Attachment.Clone();
		}

		public override bool ReloadFromDB()
		{
			ClsMemoAttachment tmp = ClsMemoAttachment.GetUsingKey(Memo_Attachment_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Memo = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@MEMO_ID", Memo_ID);
			p[1] = Connection.GetParameter
				("@ATTACHMENT_NM", Attachment_Nm);
			p[2] = Connection.GetParameter
				("@ATTACHMENT", Attachment, ParameterDirection.Input, DbType.Binary, 0);
			p[3] = Connection.GetParameter
				("@MEMO_ATTACHMENT_ID", Memo_Attachment_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_MEMO_ATTACHMENT
					(MEMO_ATTACHMENT_ID, MEMO_ID, ATTACHMENT_NM,
					ATTACHMENT)
				VALUES
					(MEMO_ATTACHMENT_ID_SEQ.NEXTVAL, @MEMO_ID, @ATTACHMENT_NM,
					@ATTACHMENT)
				RETURNING
					MEMO_ATTACHMENT_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@MEMO_ATTACHMENT_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Memo_Attachment_ID = ClsConvert.ToInt64Nullable(p[3].Value);
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
				("@MEMO_ID", Memo_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ATTACHMENT_NM", Attachment_Nm);
			p[3] = Connection.GetParameter
				("@ATTACHMENT", Attachment, ParameterDirection.Input, DbType.Binary, 0);
			p[4] = Connection.GetParameter
				("@MEMO_ATTACHMENT_ID", Memo_Attachment_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_MEMO_ATTACHMENT SET
					MEMO_ID = @MEMO_ID,
					MODIFY_DT = @MODIFY_DT,
					ATTACHMENT_NM = @ATTACHMENT_NM,
					ATTACHMENT = @ATTACHMENT
				WHERE
					MEMO_ATTACHMENT_ID = @MEMO_ATTACHMENT_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@MEMO_ATTACHMENT_ID", Memo_Attachment_ID);

			const string sql = @"
				DELETE FROM T_MEMO_ATTACHMENT WHERE
				MEMO_ATTACHMENT_ID=@MEMO_ATTACHMENT_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Memo_Attachment_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ATTACHMENT_ID"]);
			Memo_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
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

			Memo_Attachment_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ATTACHMENT_ID", v]);
			Memo_ID = ClsConvert.ToInt64Nullable(dr["MEMO_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Attachment_Nm = ClsConvert.ToString(dr["ATTACHMENT_NM", v]);
			Attachment = ClsConvert.ToByteArray(dr["ATTACHMENT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["MEMO_ATTACHMENT_ID"] = ClsConvert.ToDbObject(Memo_Attachment_ID);
			dr["MEMO_ID"] = ClsConvert.ToDbObject(Memo_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
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

		public static ClsMemoAttachment GetUsingKey(Int64 Memo_Attachment_ID)
		{
			object[] vals = new object[] {Memo_Attachment_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsMemoAttachment(dr);
		}
		public static DataTable GetAll(Int64? Memo_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Memo_ID != null && Memo_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@MEMO_ID", Memo_ID));
				sb.Append(" WHERE T_MEMO_ATTACHMENT.MEMO_ID=@MEMO_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}