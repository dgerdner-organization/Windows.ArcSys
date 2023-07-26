using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequestNote : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_REQUEST_NOTE";
		public const int PrimaryKeyCount = 3;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD", "PARTNER_REQUEST_CD", "NOTE_DT" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_REQUEST_NOTE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 20;
		public const int Partner_Request_CdMax = 10;
		public const int Note_Cd1Max = 10;
		public const int Note_Cd2Max = 10;
		public const int Note_Cd3Max = 10;
		public const int Note_Cd4Max = 10;
		public const int Note_Cd5Max = 10;
		public const int Note_Cd6Max = 10;
		public const int Note_Cd7Max = 10;
		public const int Note_Cd8Max = 10;
		public const int Note_Cd9Max = 10;
		public const int Note_Cd10Max = 10;
		public const int Note_Cd11Max = 10;
		public const int Note_Cd12Max = 10;
		public const int Note_Cd13Max = 10;
		public const int Note_Cd14Max = 10;
		public const int Note_Cd15Max = 10;
		public const int Note_Cd16Max = 10;
		public const int Note_Cd17Max = 10;
		public const int Note_Cd18Max = 10;
		public const int Note_Cd19Max = 10;
		public const int Note_Cd20Max = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected DateTime? _Note_Dt;
		protected string _Note_Cd1;
		protected string _Note_Cd2;
		protected string _Note_Cd3;
		protected string _Note_Cd4;
		protected string _Note_Cd5;
		protected string _Note_Cd6;
		protected string _Note_Cd7;
		protected string _Note_Cd8;
		protected string _Note_Cd9;
		protected string _Note_Cd10;
		protected string _Note_Cd11;
		protected string _Note_Cd12;
		protected string _Note_Cd13;
		protected string _Note_Cd14;
		protected string _Note_Cd15;
		protected string _Note_Cd16;
		protected string _Note_Cd17;
		protected string _Note_Cd18;
		protected string _Note_Cd19;
		protected string _Note_Cd20;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public DateTime? Note_Dt
		{
			get { return _Note_Dt; }
			set
			{
				if( _Note_Dt == value ) return;
		
				_Note_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Note_Dt");
			}
		}
		public string Note_Cd1
		{
			get { return _Note_Cd1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd1Max )
					_Note_Cd1 = val.Substring(0, (int)Note_Cd1Max);
				else
					_Note_Cd1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd1");
			}
		}
		public string Note_Cd2
		{
			get { return _Note_Cd2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd2Max )
					_Note_Cd2 = val.Substring(0, (int)Note_Cd2Max);
				else
					_Note_Cd2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd2");
			}
		}
		public string Note_Cd3
		{
			get { return _Note_Cd3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd3Max )
					_Note_Cd3 = val.Substring(0, (int)Note_Cd3Max);
				else
					_Note_Cd3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd3");
			}
		}
		public string Note_Cd4
		{
			get { return _Note_Cd4; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd4, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd4Max )
					_Note_Cd4 = val.Substring(0, (int)Note_Cd4Max);
				else
					_Note_Cd4 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd4");
			}
		}
		public string Note_Cd5
		{
			get { return _Note_Cd5; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd5, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd5Max )
					_Note_Cd5 = val.Substring(0, (int)Note_Cd5Max);
				else
					_Note_Cd5 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd5");
			}
		}
		public string Note_Cd6
		{
			get { return _Note_Cd6; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd6, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd6Max )
					_Note_Cd6 = val.Substring(0, (int)Note_Cd6Max);
				else
					_Note_Cd6 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd6");
			}
		}
		public string Note_Cd7
		{
			get { return _Note_Cd7; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd7, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd7Max )
					_Note_Cd7 = val.Substring(0, (int)Note_Cd7Max);
				else
					_Note_Cd7 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd7");
			}
		}
		public string Note_Cd8
		{
			get { return _Note_Cd8; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd8, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd8Max )
					_Note_Cd8 = val.Substring(0, (int)Note_Cd8Max);
				else
					_Note_Cd8 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd8");
			}
		}
		public string Note_Cd9
		{
			get { return _Note_Cd9; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd9, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd9Max )
					_Note_Cd9 = val.Substring(0, (int)Note_Cd9Max);
				else
					_Note_Cd9 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd9");
			}
		}
		public string Note_Cd10
		{
			get { return _Note_Cd10; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd10, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd10Max )
					_Note_Cd10 = val.Substring(0, (int)Note_Cd10Max);
				else
					_Note_Cd10 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd10");
			}
		}
		public string Note_Cd11
		{
			get { return _Note_Cd11; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd11, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd11Max )
					_Note_Cd11 = val.Substring(0, (int)Note_Cd11Max);
				else
					_Note_Cd11 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd11");
			}
		}
		public string Note_Cd12
		{
			get { return _Note_Cd12; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd12, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd12Max )
					_Note_Cd12 = val.Substring(0, (int)Note_Cd12Max);
				else
					_Note_Cd12 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd12");
			}
		}
		public string Note_Cd13
		{
			get { return _Note_Cd13; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd13, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd13Max )
					_Note_Cd13 = val.Substring(0, (int)Note_Cd13Max);
				else
					_Note_Cd13 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd13");
			}
		}
		public string Note_Cd14
		{
			get { return _Note_Cd14; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd14, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd14Max )
					_Note_Cd14 = val.Substring(0, (int)Note_Cd14Max);
				else
					_Note_Cd14 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd14");
			}
		}
		public string Note_Cd15
		{
			get { return _Note_Cd15; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd15, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd15Max )
					_Note_Cd15 = val.Substring(0, (int)Note_Cd15Max);
				else
					_Note_Cd15 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd15");
			}
		}
		public string Note_Cd16
		{
			get { return _Note_Cd16; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd16, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd16Max )
					_Note_Cd16 = val.Substring(0, (int)Note_Cd16Max);
				else
					_Note_Cd16 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd16");
			}
		}
		public string Note_Cd17
		{
			get { return _Note_Cd17; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd17, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd17Max )
					_Note_Cd17 = val.Substring(0, (int)Note_Cd17Max);
				else
					_Note_Cd17 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd17");
			}
		}
		public string Note_Cd18
		{
			get { return _Note_Cd18; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd18, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd18Max )
					_Note_Cd18 = val.Substring(0, (int)Note_Cd18Max);
				else
					_Note_Cd18 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd18");
			}
		}
		public string Note_Cd19
		{
			get { return _Note_Cd19; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd19, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd19Max )
					_Note_Cd19 = val.Substring(0, (int)Note_Cd19Max);
				else
					_Note_Cd19 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd19");
			}
		}
		public string Note_Cd20
		{
			get { return _Note_Cd20; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Cd20, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_Cd20Max )
					_Note_Cd20 = val.Substring(0, (int)Note_Cd20Max);
				else
					_Note_Cd20 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Cd20");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingRequestNote() : base() {}
		public ClsBookingRequestNote(DataRow dr) : base(dr) {}
		public ClsBookingRequestNote(ClsBookingRequestNote src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Note_Dt = null;
			Note_Cd1 = null;
			Note_Cd2 = null;
			Note_Cd3 = null;
			Note_Cd4 = null;
			Note_Cd5 = null;
			Note_Cd6 = null;
			Note_Cd7 = null;
			Note_Cd8 = null;
			Note_Cd9 = null;
			Note_Cd10 = null;
			Note_Cd11 = null;
			Note_Cd12 = null;
			Note_Cd13 = null;
			Note_Cd14 = null;
			Note_Cd15 = null;
			Note_Cd16 = null;
			Note_Cd17 = null;
			Note_Cd18 = null;
			Note_Cd19 = null;
			Note_Cd20 = null;
		}

		public void CopyFrom(ClsBookingRequestNote src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Note_Dt = src._Note_Dt;
			Note_Cd1 = src._Note_Cd1;
			Note_Cd2 = src._Note_Cd2;
			Note_Cd3 = src._Note_Cd3;
			Note_Cd4 = src._Note_Cd4;
			Note_Cd5 = src._Note_Cd5;
			Note_Cd6 = src._Note_Cd6;
			Note_Cd7 = src._Note_Cd7;
			Note_Cd8 = src._Note_Cd8;
			Note_Cd9 = src._Note_Cd9;
			Note_Cd10 = src._Note_Cd10;
			Note_Cd11 = src._Note_Cd11;
			Note_Cd12 = src._Note_Cd12;
			Note_Cd13 = src._Note_Cd13;
			Note_Cd14 = src._Note_Cd14;
			Note_Cd15 = src._Note_Cd15;
			Note_Cd16 = src._Note_Cd16;
			Note_Cd17 = src._Note_Cd17;
			Note_Cd18 = src._Note_Cd18;
			Note_Cd19 = src._Note_Cd19;
			Note_Cd20 = src._Note_Cd20;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingRequestNote tmp = ClsBookingRequestNote.GetUsingKey(Partner_Cd, Partner_Request_Cd, Note_Dt.Value);
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

			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@NOTE_DT", Note_Dt);
			p[3] = Connection.GetParameter
				("@NOTE_CD1", Note_Cd1);
			p[4] = Connection.GetParameter
				("@NOTE_CD2", Note_Cd2);
			p[5] = Connection.GetParameter
				("@NOTE_CD3", Note_Cd3);
			p[6] = Connection.GetParameter
				("@NOTE_CD4", Note_Cd4);
			p[7] = Connection.GetParameter
				("@NOTE_CD5", Note_Cd5);
			p[8] = Connection.GetParameter
				("@NOTE_CD6", Note_Cd6);
			p[9] = Connection.GetParameter
				("@NOTE_CD7", Note_Cd7);
			p[10] = Connection.GetParameter
				("@NOTE_CD8", Note_Cd8);
			p[11] = Connection.GetParameter
				("@NOTE_CD9", Note_Cd9);
			p[12] = Connection.GetParameter
				("@NOTE_CD10", Note_Cd10);
			p[13] = Connection.GetParameter
				("@NOTE_CD11", Note_Cd11);
			p[14] = Connection.GetParameter
				("@NOTE_CD12", Note_Cd12);
			p[15] = Connection.GetParameter
				("@NOTE_CD13", Note_Cd13);
			p[16] = Connection.GetParameter
				("@NOTE_CD14", Note_Cd14);
			p[17] = Connection.GetParameter
				("@NOTE_CD15", Note_Cd15);
			p[18] = Connection.GetParameter
				("@NOTE_CD16", Note_Cd16);
			p[19] = Connection.GetParameter
				("@NOTE_CD17", Note_Cd17);
			p[20] = Connection.GetParameter
				("@NOTE_CD18", Note_Cd18);
			p[21] = Connection.GetParameter
				("@NOTE_CD19", Note_Cd19);
			p[22] = Connection.GetParameter
				("@NOTE_CD20", Note_Cd20);

			const string sql = @"
				INSERT INTO T_BOOKING_REQUEST_NOTE
					(PARTNER_CD, PARTNER_REQUEST_CD, NOTE_DT,
					NOTE_CD1, NOTE_CD2, NOTE_CD3,
					NOTE_CD4, NOTE_CD5, NOTE_CD6,
					NOTE_CD7, NOTE_CD8, NOTE_CD9,
					NOTE_CD10, NOTE_CD11, NOTE_CD12,
					NOTE_CD13, NOTE_CD14, NOTE_CD15,
					NOTE_CD16, NOTE_CD17, NOTE_CD18,
					NOTE_CD19, NOTE_CD20)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @NOTE_DT,
					@NOTE_CD1, @NOTE_CD2, @NOTE_CD3,
					@NOTE_CD4, @NOTE_CD5, @NOTE_CD6,
					@NOTE_CD7, @NOTE_CD8, @NOTE_CD9,
					@NOTE_CD10, @NOTE_CD11, @NOTE_CD12,
					@NOTE_CD13, @NOTE_CD14, @NOTE_CD15,
					@NOTE_CD16, @NOTE_CD17, @NOTE_CD18,
					@NOTE_CD19, @NOTE_CD20)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@NOTE_CD1", Note_Cd1);
			p[1] = Connection.GetParameter
				("@NOTE_CD2", Note_Cd2);
			p[2] = Connection.GetParameter
				("@NOTE_CD3", Note_Cd3);
			p[3] = Connection.GetParameter
				("@NOTE_CD4", Note_Cd4);
			p[4] = Connection.GetParameter
				("@NOTE_CD5", Note_Cd5);
			p[5] = Connection.GetParameter
				("@NOTE_CD6", Note_Cd6);
			p[6] = Connection.GetParameter
				("@NOTE_CD7", Note_Cd7);
			p[7] = Connection.GetParameter
				("@NOTE_CD8", Note_Cd8);
			p[8] = Connection.GetParameter
				("@NOTE_CD9", Note_Cd9);
			p[9] = Connection.GetParameter
				("@NOTE_CD10", Note_Cd10);
			p[10] = Connection.GetParameter
				("@NOTE_CD11", Note_Cd11);
			p[11] = Connection.GetParameter
				("@NOTE_CD12", Note_Cd12);
			p[12] = Connection.GetParameter
				("@NOTE_CD13", Note_Cd13);
			p[13] = Connection.GetParameter
				("@NOTE_CD14", Note_Cd14);
			p[14] = Connection.GetParameter
				("@NOTE_CD15", Note_Cd15);
			p[15] = Connection.GetParameter
				("@NOTE_CD16", Note_Cd16);
			p[16] = Connection.GetParameter
				("@NOTE_CD17", Note_Cd17);
			p[17] = Connection.GetParameter
				("@NOTE_CD18", Note_Cd18);
			p[18] = Connection.GetParameter
				("@NOTE_CD19", Note_Cd19);
			p[19] = Connection.GetParameter
				("@NOTE_CD20", Note_Cd20);
			p[20] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[21] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[22] = Connection.GetParameter
				("@NOTE_DT", Note_Dt);

			const string sql = @"
				UPDATE T_BOOKING_REQUEST_NOTE SET
					NOTE_CD1 = @NOTE_CD1,
					NOTE_CD2 = @NOTE_CD2,
					NOTE_CD3 = @NOTE_CD3,
					NOTE_CD4 = @NOTE_CD4,
					NOTE_CD5 = @NOTE_CD5,
					NOTE_CD6 = @NOTE_CD6,
					NOTE_CD7 = @NOTE_CD7,
					NOTE_CD8 = @NOTE_CD8,
					NOTE_CD9 = @NOTE_CD9,
					NOTE_CD10 = @NOTE_CD10,
					NOTE_CD11 = @NOTE_CD11,
					NOTE_CD12 = @NOTE_CD12,
					NOTE_CD13 = @NOTE_CD13,
					NOTE_CD14 = @NOTE_CD14,
					NOTE_CD15 = @NOTE_CD15,
					NOTE_CD16 = @NOTE_CD16,
					NOTE_CD17 = @NOTE_CD17,
					NOTE_CD18 = @NOTE_CD18,
					NOTE_CD19 = @NOTE_CD19,
					NOTE_CD20 = @NOTE_CD20
				WHERE
					PARTNER_CD = @PARTNER_CD AND
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD AND
					NOTE_DT = @NOTE_DT
				RETURNING
					
				INTO
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

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Note_Dt = ClsConvert.ToDateTimeNullable(dr["NOTE_DT"]);
			Note_Cd1 = ClsConvert.ToString(dr["NOTE_CD1"]);
			Note_Cd2 = ClsConvert.ToString(dr["NOTE_CD2"]);
			Note_Cd3 = ClsConvert.ToString(dr["NOTE_CD3"]);
			Note_Cd4 = ClsConvert.ToString(dr["NOTE_CD4"]);
			Note_Cd5 = ClsConvert.ToString(dr["NOTE_CD5"]);
			Note_Cd6 = ClsConvert.ToString(dr["NOTE_CD6"]);
			Note_Cd7 = ClsConvert.ToString(dr["NOTE_CD7"]);
			Note_Cd8 = ClsConvert.ToString(dr["NOTE_CD8"]);
			Note_Cd9 = ClsConvert.ToString(dr["NOTE_CD9"]);
			Note_Cd10 = ClsConvert.ToString(dr["NOTE_CD10"]);
			Note_Cd11 = ClsConvert.ToString(dr["NOTE_CD11"]);
			Note_Cd12 = ClsConvert.ToString(dr["NOTE_CD12"]);
			Note_Cd13 = ClsConvert.ToString(dr["NOTE_CD13"]);
			Note_Cd14 = ClsConvert.ToString(dr["NOTE_CD14"]);
			Note_Cd15 = ClsConvert.ToString(dr["NOTE_CD15"]);
			Note_Cd16 = ClsConvert.ToString(dr["NOTE_CD16"]);
			Note_Cd17 = ClsConvert.ToString(dr["NOTE_CD17"]);
			Note_Cd18 = ClsConvert.ToString(dr["NOTE_CD18"]);
			Note_Cd19 = ClsConvert.ToString(dr["NOTE_CD19"]);
			Note_Cd20 = ClsConvert.ToString(dr["NOTE_CD20"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Note_Dt = ClsConvert.ToDateTimeNullable(dr["NOTE_DT", v]);
			Note_Cd1 = ClsConvert.ToString(dr["NOTE_CD1", v]);
			Note_Cd2 = ClsConvert.ToString(dr["NOTE_CD2", v]);
			Note_Cd3 = ClsConvert.ToString(dr["NOTE_CD3", v]);
			Note_Cd4 = ClsConvert.ToString(dr["NOTE_CD4", v]);
			Note_Cd5 = ClsConvert.ToString(dr["NOTE_CD5", v]);
			Note_Cd6 = ClsConvert.ToString(dr["NOTE_CD6", v]);
			Note_Cd7 = ClsConvert.ToString(dr["NOTE_CD7", v]);
			Note_Cd8 = ClsConvert.ToString(dr["NOTE_CD8", v]);
			Note_Cd9 = ClsConvert.ToString(dr["NOTE_CD9", v]);
			Note_Cd10 = ClsConvert.ToString(dr["NOTE_CD10", v]);
			Note_Cd11 = ClsConvert.ToString(dr["NOTE_CD11", v]);
			Note_Cd12 = ClsConvert.ToString(dr["NOTE_CD12", v]);
			Note_Cd13 = ClsConvert.ToString(dr["NOTE_CD13", v]);
			Note_Cd14 = ClsConvert.ToString(dr["NOTE_CD14", v]);
			Note_Cd15 = ClsConvert.ToString(dr["NOTE_CD15", v]);
			Note_Cd16 = ClsConvert.ToString(dr["NOTE_CD16", v]);
			Note_Cd17 = ClsConvert.ToString(dr["NOTE_CD17", v]);
			Note_Cd18 = ClsConvert.ToString(dr["NOTE_CD18", v]);
			Note_Cd19 = ClsConvert.ToString(dr["NOTE_CD19", v]);
			Note_Cd20 = ClsConvert.ToString(dr["NOTE_CD20", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["NOTE_DT"] = ClsConvert.ToDbObject(Note_Dt);
			dr["NOTE_CD1"] = ClsConvert.ToDbObject(Note_Cd1);
			dr["NOTE_CD2"] = ClsConvert.ToDbObject(Note_Cd2);
			dr["NOTE_CD3"] = ClsConvert.ToDbObject(Note_Cd3);
			dr["NOTE_CD4"] = ClsConvert.ToDbObject(Note_Cd4);
			dr["NOTE_CD5"] = ClsConvert.ToDbObject(Note_Cd5);
			dr["NOTE_CD6"] = ClsConvert.ToDbObject(Note_Cd6);
			dr["NOTE_CD7"] = ClsConvert.ToDbObject(Note_Cd7);
			dr["NOTE_CD8"] = ClsConvert.ToDbObject(Note_Cd8);
			dr["NOTE_CD9"] = ClsConvert.ToDbObject(Note_Cd9);
			dr["NOTE_CD10"] = ClsConvert.ToDbObject(Note_Cd10);
			dr["NOTE_CD11"] = ClsConvert.ToDbObject(Note_Cd11);
			dr["NOTE_CD12"] = ClsConvert.ToDbObject(Note_Cd12);
			dr["NOTE_CD13"] = ClsConvert.ToDbObject(Note_Cd13);
			dr["NOTE_CD14"] = ClsConvert.ToDbObject(Note_Cd14);
			dr["NOTE_CD15"] = ClsConvert.ToDbObject(Note_Cd15);
			dr["NOTE_CD16"] = ClsConvert.ToDbObject(Note_Cd16);
			dr["NOTE_CD17"] = ClsConvert.ToDbObject(Note_Cd17);
			dr["NOTE_CD18"] = ClsConvert.ToDbObject(Note_Cd18);
			dr["NOTE_CD19"] = ClsConvert.ToDbObject(Note_Cd19);
			dr["NOTE_CD20"] = ClsConvert.ToDbObject(Note_Cd20);
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

		public static ClsBookingRequestNote GetUsingKey(string Partner_Cd, string Partner_Request_Cd, DateTime Note_Dt)
		{
			object[] vals = new object[] {Partner_Cd, Partner_Request_Cd, Note_Dt};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingRequestNote(dr);
		}

		#endregion		// #region Static Methods
	}
}