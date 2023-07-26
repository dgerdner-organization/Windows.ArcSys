using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequestError : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_REQUEST_ERROR";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = @"SELECT * FROM T_BOOKING_REQUEST_ERROR 
				INNER JOIN T_BOOKING_REQUEST
				ON ( T_BOOKING_REQUEST.TRANS_CTL_NO=T_BOOKING_REQUEST_ERROR.TRANS_CTL_NO AND T_BOOKING_REQUEST.TRANS_SEQ_NO=T_BOOKING_REQUEST_ERROR.TRANS_SEQ_NO) ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Error_DscMax = 100;
		public const int Error_NotesMax = 100;
		public const int Error_UserMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Double? _Trans_Ctl_No;
		protected Double? _Trans_Seq_No;
		protected string _Error_Dsc;
		protected string _Error_Notes;
		protected string _Error_User;

		#endregion	// #region Column Fields

		#region Column Properties

		public Double? Trans_Ctl_No
		{
			get { return _Trans_Ctl_No; }
			set
			{
				if( _Trans_Ctl_No == value ) return;
		
				_Trans_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Ctl_No");
			}
		}
		public Double? Trans_Seq_No
		{
			get { return _Trans_Seq_No; }
			set
			{
				if( _Trans_Seq_No == value ) return;
		
				_Trans_Seq_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Seq_No");
			}
		}
		public string Error_Dsc
		{
			get { return _Error_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_DscMax )
					_Error_Dsc = val.Substring(0, (int)Error_DscMax);
				else
					_Error_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Dsc");
			}
		}
		public string Error_Notes
		{
			get { return _Error_Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_NotesMax )
					_Error_Notes = val.Substring(0, (int)Error_NotesMax);
				else
					_Error_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Notes");
			}
		}
		public string Error_User
		{
			get { return _Error_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_UserMax )
					_Error_User = val.Substring(0, (int)Error_UserMax);
				else
					_Error_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_User");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsBookingRequest _BookingRequestFK;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsBookingRequest BookingRequestFK
		{
			get
			{
				if (Trans_Ctl_No == null || Trans_Seq_No == null)
					_BookingRequestFK = null;
				else if (_BookingRequestFK == null ||
					BookingRequestFK.Trans_Ctl_No != Trans_Ctl_No || BookingRequestFK.Trans_Seq_No != Trans_Seq_No)
					_BookingRequestFK = ClsBookingRequest.GetUsingKey(
							ClsConvert.ToInt32(Trans_Ctl_No.GetValueOrDefault()),
							ClsConvert.ToInt32(Trans_Seq_No.GetValueOrDefault()));
				return _BookingRequestFK;
			}
			set
			{
				if( _BookingRequestFK == value ) return;
		
				_BookingRequestFK = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingRequestError() : base() {}
		public ClsBookingRequestError(DataRow dr) : base(dr) {}
		public ClsBookingRequestError(ClsBookingRequestError src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trans_Ctl_No = null;
			Trans_Seq_No = null;
			Error_Dsc = null;
			Error_Notes = null;
			Error_User = null;
		}

		public void CopyFrom(ClsBookingRequestError src)
		{
			Trans_Ctl_No = src._Trans_Ctl_No;
			Trans_Seq_No = src._Trans_Seq_No;
			Error_Dsc = src._Error_Dsc;
			Error_Notes = src._Error_Notes;
			Error_User = src._Error_User;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingRequestError tmp = null;	//No primary key can't refresh;
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_BookingRequestFK = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[1] = Connection.GetParameter
				("@TRANS_SEQ_NO", Trans_Seq_No);
			p[2] = Connection.GetParameter
				("@ERROR_DSC", Error_Dsc);
			p[3] = Connection.GetParameter
				("@ERROR_NOTES", Error_Notes);
			p[4] = Connection.GetParameter
				("@ERROR_USER", Error_User);

			const string sql = @"
				INSERT INTO T_BOOKING_REQUEST_ERROR
					(TRANS_CTL_NO, TRANS_SEQ_NO, ERROR_DSC,
					ERROR_NOTES, ERROR_USER)
				VALUES
					(@TRANS_CTL_NO, @TRANS_SEQ_NO, @ERROR_DSC,
					@ERROR_NOTES, @ERROR_USER)
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

			Trans_Ctl_No = ClsConvert.ToDoubleNullable(dr["TRANS_CTL_NO"]);
			Trans_Seq_No = ClsConvert.ToDoubleNullable(dr["TRANS_SEQ_NO"]);
			Error_Dsc = ClsConvert.ToString(dr["ERROR_DSC"]);
			Error_Notes = ClsConvert.ToString(dr["ERROR_NOTES"]);
			Error_User = ClsConvert.ToString(dr["ERROR_USER"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trans_Ctl_No = ClsConvert.ToDoubleNullable(dr["TRANS_CTL_NO", v]);
			Trans_Seq_No = ClsConvert.ToDoubleNullable(dr["TRANS_SEQ_NO", v]);
			Error_Dsc = ClsConvert.ToString(dr["ERROR_DSC", v]);
			Error_Notes = ClsConvert.ToString(dr["ERROR_NOTES", v]);
			Error_User = ClsConvert.ToString(dr["ERROR_USER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["TRANS_SEQ_NO"] = ClsConvert.ToDbObject(Trans_Seq_No);
			dr["ERROR_DSC"] = ClsConvert.ToDbObject(Error_Dsc);
			dr["ERROR_NOTES"] = ClsConvert.ToDbObject(Error_Notes);
			dr["ERROR_USER"] = ClsConvert.ToDbObject(Error_User);
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


		public static DataTable GetAll(Double? Trans_Ctl_No, Double? Trans_Seq_No)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Trans_Ctl_No != null && Trans_Ctl_No > 0 )
			{
				lst.Add(Connection.GetParameter("@TRANS_CTL_NO", Trans_Ctl_No));
				sb.Append(" WHERE T_BOOKING_REQUEST_ERROR.TRANS_CTL_NO=@TRANS_CTL_NO");
			}
			if( Trans_Seq_No != null && Trans_Seq_No > 0 )
			{
				lst.Add(Connection.GetParameter("@TRANS_SEQ_NO", Trans_Seq_No));
				sb.AppendFormat(" {0} T_BOOKING_REQUEST_ERROR.TRANS_SEQ_NO=@TRANS_SEQ_NO",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}