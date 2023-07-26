using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsFtpHistory : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_FTP_HISTORY";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM T_FTP_HISTORY";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int FilenameMax = 50;
		public const int BackupfilenameMax = 250;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Filename;
		protected string _Backupfilename;
		protected Int64? _Filesize;
		protected decimal? _Status;
		protected DateTime? _Datestamp;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Filename
		{
			get { return _Filename; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Filename, val, false) == 0 ) return;
		
				if( val != null && val.Length > FilenameMax )
					_Filename = val.Substring(0, (int)FilenameMax);
				else
					_Filename = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Filename");
			}
		}
		public string Backupfilename
		{
			get { return _Backupfilename; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Backupfilename, val, false) == 0 ) return;
		
				if( val != null && val.Length > BackupfilenameMax )
					_Backupfilename = val.Substring(0, (int)BackupfilenameMax);
				else
					_Backupfilename = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Backupfilename");
			}
		}
		public Int64? Filesize
		{
			get { return _Filesize; }
			set
			{
				if( _Filesize == value ) return;
		
				_Filesize = value;
				_IsDirty = true;
				NotifyPropertyChanged("Filesize");
			}
		}
		public decimal? Status
		{
			get { return _Status; }
			set
			{
				if( _Status == value ) return;
		
				_Status = value;
				_IsDirty = true;
				NotifyPropertyChanged("Status");
			}
		}
		public DateTime? Datestamp
		{
			get { return _Datestamp; }
			set
			{
				if( _Datestamp == value ) return;
		
				_Datestamp = value;
				_IsDirty = true;
				NotifyPropertyChanged("Datestamp");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsFtpHistory() : base() {}
		public ClsFtpHistory(DataRow dr) : base(dr) {}
		public ClsFtpHistory(ClsFtpHistory src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Filename = null;
			Backupfilename = null;
			Filesize = null;
			Status = null;
			Datestamp = null;
		}

		public void CopyFrom(ClsFtpHistory src)
		{
			Filename = src._Filename;
			Backupfilename = src._Backupfilename;
			Filesize = src._Filesize;
			Status = src._Status;
			Datestamp = src._Datestamp;
		}

		public override bool ReloadFromDB()
		{
			ClsFtpHistory tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@FILENAME", Filename);
			p[1] = Connection.GetParameter
				("@BACKUPFILENAME", Backupfilename);
			p[2] = Connection.GetParameter
				("@FILESIZE", Filesize);
			p[3] = Connection.GetParameter
				("@STATUS", Status);
			p[4] = Connection.GetParameter
				("@DATESTAMP", Datestamp);

			const string sql = @"
				INSERT INTO T_FTP_HISTORY
					(FILENAME, BACKUPFILENAME, FILESIZE,
					STATUS, DATESTAMP)
				VALUES
					(@FILENAME, @BACKUPFILENAME, @FILESIZE,
					@STATUS, @DATESTAMP)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			int ret = -1;


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

			Filename = ClsConvert.ToString(dr["FILENAME"]);
			Backupfilename = ClsConvert.ToString(dr["BACKUPFILENAME"]);
			Filesize = ClsConvert.ToInt64Nullable(dr["FILESIZE"]);
			Status = ClsConvert.ToDecimalNullable(dr["STATUS"]);
			Datestamp = ClsConvert.ToDateTimeNullable(dr["DATESTAMP"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Filename = ClsConvert.ToString(dr["FILENAME", v]);
			Backupfilename = ClsConvert.ToString(dr["BACKUPFILENAME", v]);
			Filesize = ClsConvert.ToInt64Nullable(dr["FILESIZE", v]);
			Status = ClsConvert.ToDecimalNullable(dr["STATUS", v]);
			Datestamp = ClsConvert.ToDateTimeNullable(dr["DATESTAMP", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["FILENAME"] = ClsConvert.ToDbObject(Filename);
			dr["BACKUPFILENAME"] = ClsConvert.ToDbObject(Backupfilename);
			dr["FILESIZE"] = ClsConvert.ToDbObject(Filesize);
			dr["STATUS"] = ClsConvert.ToDbObject(Status);
			dr["DATESTAMP"] = ClsConvert.ToDbObject(Datestamp);
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



		#endregion		// #region Static Methods
	}
}