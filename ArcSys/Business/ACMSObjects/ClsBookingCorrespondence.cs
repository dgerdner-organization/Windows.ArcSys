using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingCorrespondence : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_CORRESPONDENCE";
		public const int PrimaryKeyCount = 3;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CORR_ID", "PARTNER_CD", "PARTNER_REQUEST_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM T_BOOKING_CORRESPONDENCE 
				INNER JOIN T_BOOKING
				ON ( T_BOOKING.PARTNER_CD=T_BOOKING_CORRESPONDENCE.PARTNER_CD AND T_BOOKING.PARTNER_REQUEST_CD=T_BOOKING_CORRESPONDENCE.PARTNER_REQUEST_CD) ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Corr_TextMax = 4000;
		public const int Corr_CdMax = 5;
		public const int AttachmentMax = 50;
		public const int Email_ToMax = 50;
		public const int Email_SentMax = 1;
		public const int Corr_TextlongMax = 2147483647;
		public const int Email_FromMax = 50;
		public const int Corr_UserMax = 20;
		public const int Email_To_NameMax = 50;
		public const int Email_From_NameMax = 50;
		public const long Email_BlobMax = 4294967294;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Double? _Corr_ID;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected DateTime? _Corr_Dt;
		protected string _Corr_Text;
		protected string _Corr_Cd;
		protected string _Attachment;
		protected string _Email_To;
		protected string _Email_Sent;
		protected string _Corr_Textlong;
		protected string _Email_From;
		protected string _Corr_User;
		protected string _Email_To_Name;
		protected string _Email_From_Name;
		protected byte[] _Email_Blob;

		#endregion	// #region Column Fields

		#region Column Properties

		public Double? Corr_ID
		{
			get { return _Corr_ID; }
			set
			{
				if( _Corr_ID == value ) return;
		
				_Corr_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Corr_ID");
			}
		}
		public string Partner_Cd
		{
			get { return _Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_CdMax )
					_Partner_Cd = val.Substring(0, (int)Partner_CdMax);
				else
					_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Cd");
			}
		}
		public string Partner_Request_Cd
		{
			get { return _Partner_Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_Request_CdMax )
					_Partner_Request_Cd = val.Substring(0, (int)Partner_Request_CdMax);
				else
					_Partner_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Request_Cd");
			}
		}
		public DateTime? Corr_Dt
		{
			get { return _Corr_Dt; }
			set
			{
				if( _Corr_Dt == value ) return;
		
				_Corr_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Dt");
			}
		}
		public string Corr_Text
		{
			get { return _Corr_Text; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_Text, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_TextMax )
					_Corr_Text = val.Substring(0, (int)Corr_TextMax);
				else
					_Corr_Text = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Text");
			}
		}
		public string Corr_Cd
		{
			get { return _Corr_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_CdMax )
					_Corr_Cd = val.Substring(0, (int)Corr_CdMax);
				else
					_Corr_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Cd");
			}
		}
		public string Attachment
		{
			get { return _Attachment; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Attachment, val, false) == 0 ) return;
		
				if( val != null && val.Length > AttachmentMax )
					_Attachment = val.Substring(0, (int)AttachmentMax);
				else
					_Attachment = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Attachment");
			}
		}
		public string Email_To
		{
			get { return _Email_To; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_To, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_ToMax )
					_Email_To = val.Substring(0, (int)Email_ToMax);
				else
					_Email_To = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_To");
			}
		}
		public string Email_Sent
		{
			get { return _Email_Sent; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_Sent, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_SentMax )
					_Email_Sent = val.Substring(0, (int)Email_SentMax);
				else
					_Email_Sent = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_Sent");
			}
		}
		public string Corr_Textlong
		{
			get { return _Corr_Textlong; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_Textlong, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_TextlongMax )
					_Corr_Textlong = val.Substring(0, (int)Corr_TextlongMax);
				else
					_Corr_Textlong = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Textlong");
			}
		}
		public string Email_From
		{
			get { return _Email_From; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_From, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_FromMax )
					_Email_From = val.Substring(0, (int)Email_FromMax);
				else
					_Email_From = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_From");
			}
		}
		public string Corr_User
		{
			get { return _Corr_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_UserMax )
					_Corr_User = val.Substring(0, (int)Corr_UserMax);
				else
					_Corr_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_User");
			}
		}
		public string Email_To_Name
		{
			get { return _Email_To_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_To_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_To_NameMax )
					_Email_To_Name = val.Substring(0, (int)Email_To_NameMax);
				else
					_Email_To_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_To_Name");
			}
		}
		public string Email_From_Name
		{
			get { return _Email_From_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_From_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_From_NameMax )
					_Email_From_Name = val.Substring(0, (int)Email_From_NameMax);
				else
					_Email_From_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_From_Name");
			}
		}
		public byte[] Email_Blob
		{
			get { return _Email_Blob; }
			set
			{
				if( _Email_Blob == value ) return;
		
				if( value == null || value.LongLength <= 0 )
				{
					if( _Email_Blob == null ) return;
		
					_Email_Blob = null;
				}
				else
				{
					long sz = ( value.LongLength < Email_BlobMax ) ?
						value.LongLength : Email_BlobMax;
					if( _Email_Blob == null ||
						_Email_Blob.LongLength != sz )
							_Email_Blob = new byte[sz];
					Array.Copy(value, _Email_Blob, sz);
				}
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_Blob");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsBooking _BookingFK;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsBooking BookingFK
		{
			get
			{
				if( Partner_Cd == null || Partner_Request_Cd == null )
					_BookingFK = null;
				else if( _BookingFK == null ||
					BookingFK.Partner_Cd != Partner_Cd || BookingFK.Partner_Request_Cd != Partner_Request_Cd )
					_BookingFK = ClsBooking.GetUsingKey(Partner_Cd, Partner_Request_Cd);
				return _BookingFK;
			}
			set
			{
				if( _BookingFK == value ) return;
		
				_BookingFK = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingCorrespondence() : base() {}
		public ClsBookingCorrespondence(DataRow dr) : base(dr) {}
		public ClsBookingCorrespondence(ClsBookingCorrespondence src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Corr_ID = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Corr_Dt = null;
			Corr_Text = null;
			Corr_Cd = null;
			Attachment = null;
			Email_To = null;
			Email_Sent = null;
			Corr_Textlong = null;
			Email_From = null;
			Corr_User = null;
			Email_To_Name = null;
			Email_From_Name = null;
			Email_Blob = null;
		}

		public void CopyFrom(ClsBookingCorrespondence src)
		{
			Corr_ID = src._Corr_ID;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Corr_Dt = src._Corr_Dt;
			Corr_Text = src._Corr_Text;
			Corr_Cd = src._Corr_Cd;
			Attachment = src._Attachment;
			Email_To = src._Email_To;
			Email_Sent = src._Email_Sent;
			Corr_Textlong = src._Corr_Textlong;
			Email_From = src._Email_From;
			Corr_User = src._Corr_User;
			Email_To_Name = src._Email_To_Name;
			Email_From_Name = src._Email_From_Name;
			Email_Blob = (byte[])src._Email_Blob.Clone();
		}

		public override bool ReloadFromDB()
		{
			ClsBookingCorrespondence tmp = ClsBookingCorrespondence.GetUsingKey(Corr_ID.Value, Partner_Cd, Partner_Request_Cd);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_BookingFK = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@CORR_ID", Corr_ID);
			p[1] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[3] = Connection.GetParameter
				("@CORR_DT", Corr_Dt);
			p[4] = Connection.GetParameter
				("@CORR_TEXT", Corr_Text);
			p[5] = Connection.GetParameter
				("@CORR_CD", Corr_Cd);
			p[6] = Connection.GetParameter
				("@ATTACHMENT", Attachment);
			p[7] = Connection.GetParameter
				("@EMAIL_TO", Email_To);
			p[8] = Connection.GetParameter
				("@EMAIL_SENT", Email_Sent);
			p[9] = Connection.GetParameter
				("@CORR_TEXTLONG", Corr_Textlong);
			p[10] = Connection.GetParameter
				("@EMAIL_FROM", Email_From);
			p[11] = Connection.GetParameter
				("@CORR_USER", Corr_User);
			p[12] = Connection.GetParameter
				("@EMAIL_TO_NAME", Email_To_Name);
			p[13] = Connection.GetParameter
				("@EMAIL_FROM_NAME", Email_From_Name);
			p[14] = Connection.GetParameter
				("@EMAIL_BLOB", Email_Blob, ParameterDirection.Input, DbType.Binary, 0);

			const string sql = @"
				INSERT INTO T_BOOKING_CORRESPONDENCE
					(CORR_ID, PARTNER_CD, PARTNER_REQUEST_CD,
					CORR_DT, CORR_TEXT, CORR_CD,
					ATTACHMENT, EMAIL_TO, EMAIL_SENT,
					CORR_TEXTLONG, EMAIL_FROM, CORR_USER,
					EMAIL_TO_NAME, EMAIL_FROM_NAME, EMAIL_BLOB)
				VALUES
					(@CORR_ID, @PARTNER_CD, @PARTNER_REQUEST_CD,
					@CORR_DT, @CORR_TEXT, @CORR_CD,
					@ATTACHMENT, @EMAIL_TO, @EMAIL_SENT,
					@CORR_TEXTLONG, @EMAIL_FROM, @CORR_USER,
					@EMAIL_TO_NAME, @EMAIL_FROM_NAME, @EMAIL_BLOB)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@CORR_DT", Corr_Dt);
			p[1] = Connection.GetParameter
				("@CORR_TEXT", Corr_Text);
			p[2] = Connection.GetParameter
				("@CORR_CD", Corr_Cd);
			p[3] = Connection.GetParameter
				("@ATTACHMENT", Attachment);
			p[4] = Connection.GetParameter
				("@EMAIL_TO", Email_To);
			p[5] = Connection.GetParameter
				("@EMAIL_SENT", Email_Sent);
			p[6] = Connection.GetParameter
				("@CORR_TEXTLONG", Corr_Textlong);
			p[7] = Connection.GetParameter
				("@EMAIL_FROM", Email_From);
			p[8] = Connection.GetParameter
				("@CORR_USER", Corr_User);
			p[9] = Connection.GetParameter
				("@EMAIL_TO_NAME", Email_To_Name);
			p[10] = Connection.GetParameter
				("@EMAIL_FROM_NAME", Email_From_Name);
			p[11] = Connection.GetParameter
				("@EMAIL_BLOB", Email_Blob, ParameterDirection.Input, DbType.Binary, 0);
			p[12] = Connection.GetParameter
				("@CORR_ID", Corr_ID);
			p[13] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[14] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);

			const string sql = @"
				UPDATE T_BOOKING_CORRESPONDENCE SET
					CORR_DT = @CORR_DT,
					CORR_TEXT = @CORR_TEXT,
					CORR_CD = @CORR_CD,
					ATTACHMENT = @ATTACHMENT,
					EMAIL_TO = @EMAIL_TO,
					EMAIL_SENT = @EMAIL_SENT,
					CORR_TEXTLONG = @CORR_TEXTLONG,
					EMAIL_FROM = @EMAIL_FROM,
					CORR_USER = @CORR_USER,
					EMAIL_TO_NAME = @EMAIL_TO_NAME,
					EMAIL_FROM_NAME = @EMAIL_FROM_NAME,
					EMAIL_BLOB = @EMAIL_BLOB
				WHERE
					CORR_ID = @CORR_ID AND
					PARTNER_CD = @PARTNER_CD AND
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD

					";
			int ret = Connection.RunSQL(sql, p);


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

			Corr_ID = ClsConvert.ToDoubleNullable(dr["CORR_ID"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Corr_Dt = ClsConvert.ToDateTimeNullable(dr["CORR_DT"]);
			Corr_Text = ClsConvert.ToString(dr["CORR_TEXT"]);
			Corr_Cd = ClsConvert.ToString(dr["CORR_CD"]);
			Attachment = ClsConvert.ToString(dr["ATTACHMENT"]);
			Email_To = ClsConvert.ToString(dr["EMAIL_TO"]);
			Email_Sent = ClsConvert.ToString(dr["EMAIL_SENT"]);
			Corr_Textlong = ClsConvert.ToString(dr["CORR_TEXTLONG"]);
			Email_From = ClsConvert.ToString(dr["EMAIL_FROM"]);
			Corr_User = ClsConvert.ToString(dr["CORR_USER"]);
			Email_To_Name = ClsConvert.ToString(dr["EMAIL_TO_NAME"]);
			Email_From_Name = ClsConvert.ToString(dr["EMAIL_FROM_NAME"]);
			Email_Blob = ClsConvert.ToByteArray(dr["EMAIL_BLOB"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Corr_ID = ClsConvert.ToDoubleNullable(dr["CORR_ID", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Corr_Dt = ClsConvert.ToDateTimeNullable(dr["CORR_DT", v]);
			Corr_Text = ClsConvert.ToString(dr["CORR_TEXT", v]);
			Corr_Cd = ClsConvert.ToString(dr["CORR_CD", v]);
			Attachment = ClsConvert.ToString(dr["ATTACHMENT", v]);
			Email_To = ClsConvert.ToString(dr["EMAIL_TO", v]);
			Email_Sent = ClsConvert.ToString(dr["EMAIL_SENT", v]);
			Corr_Textlong = ClsConvert.ToString(dr["CORR_TEXTLONG", v]);
			Email_From = ClsConvert.ToString(dr["EMAIL_FROM", v]);
			Corr_User = ClsConvert.ToString(dr["CORR_USER", v]);
			Email_To_Name = ClsConvert.ToString(dr["EMAIL_TO_NAME", v]);
			Email_From_Name = ClsConvert.ToString(dr["EMAIL_FROM_NAME", v]);
			Email_Blob = ClsConvert.ToByteArray(dr["EMAIL_BLOB", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CORR_ID"] = ClsConvert.ToDbObject(Corr_ID);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["CORR_DT"] = ClsConvert.ToDbObject(Corr_Dt);
			dr["CORR_TEXT"] = ClsConvert.ToDbObject(Corr_Text);
			dr["CORR_CD"] = ClsConvert.ToDbObject(Corr_Cd);
			dr["ATTACHMENT"] = ClsConvert.ToDbObject(Attachment);
			dr["EMAIL_TO"] = ClsConvert.ToDbObject(Email_To);
			dr["EMAIL_SENT"] = ClsConvert.ToDbObject(Email_Sent);
			dr["CORR_TEXTLONG"] = ClsConvert.ToDbObject(Corr_Textlong);
			dr["EMAIL_FROM"] = ClsConvert.ToDbObject(Email_From);
			dr["CORR_USER"] = ClsConvert.ToDbObject(Corr_User);
			dr["EMAIL_TO_NAME"] = ClsConvert.ToDbObject(Email_To_Name);
			dr["EMAIL_FROM_NAME"] = ClsConvert.ToDbObject(Email_From_Name);
			dr["EMAIL_BLOB"] = ClsConvert.ToDbObject(Email_Blob);
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

		public static ClsBookingCorrespondence GetUsingKey(Double Corr_ID, string Partner_Cd, string Partner_Request_Cd)
		{
			object[] vals = new object[] {Corr_ID, Partner_Cd, Partner_Request_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingCorrespondence(dr);
		}
		public static DataTable GetAll(string Partner_Cd, string Partner_Request_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PARTNER_CD", Partner_Cd));
				sb.Append(" WHERE T_BOOKING_CORRESPONDENCE.PARTNER_CD=@PARTNER_CD");
			}
			if( string.IsNullOrEmpty(Partner_Request_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PARTNER_REQUEST_CD", Partner_Request_Cd));
				sb.AppendFormat(" {0} T_BOOKING_CORRESPONDENCE.PARTNER_REQUEST_CD=@PARTNER_REQUEST_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}