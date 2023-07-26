using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsIssue : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ISSUE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ISSUE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ISSUE 
				INNER JOIN R_PROJECT
				ON T_ISSUE.PROJECT_CD=R_PROJECT.PROJECT_CD
				INNER JOIN R_STATUS
				ON T_ISSUE.STATUS_CD=R_STATUS.STATUS_CD
				LEFT OUTER JOIN R_CATEGORY
				ON T_ISSUE.CATEGORY_CD=R_CATEGORY.CATEGORY_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Issue_DscMax = 100;
		public const int Project_CdMax = 10;
		public const int Status_CdMax = 10;
		public const int Wip_FlgMax = 1;
		public const int New_Requirement_FlgMax = 1;
		public const int Dev_Assist_FlgMax = 1;
		public const int Emg_FlgMax = 1;
		public const int Data_Fix_FlgMax = 1;
		public const int Release_FlgMax = 1;
		public const int Category_CdMax = 10;
		public const int It_Owner_LoginMax = 30;
		public const int Biz_Owner_LoginMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Issue_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Issue_Dsc;
		protected string _Project_Cd;
		protected string _Status_Cd;
		protected string _Wip_Flg;
		protected string _New_Requirement_Flg;
		protected string _Dev_Assist_Flg;
		protected string _Emg_Flg;
		protected string _Data_Fix_Flg;
		protected string _Release_Flg;
		protected string _Category_Cd;
		protected DateTime? _Due_Dt;
		protected Int16? _Priority_Nbr;
		protected string _It_Owner_Login;
		protected string _Biz_Owner_Login;
		protected DateTime? _Request_By_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Issue_ID
		{
			get { return _Issue_ID; }
			set
			{
				if( _Issue_ID == value ) return;
		
				_Issue_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Issue_ID");
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
		public string Issue_Dsc
		{
			get { return _Issue_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Issue_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Issue_DscMax )
					_Issue_Dsc = val.Substring(0, (int)Issue_DscMax);
				else
					_Issue_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Issue_Dsc");
			}
		}
		public string Project_Cd
		{
			get { return _Project_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Project_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Project_CdMax )
					_Project_Cd = val.Substring(0, (int)Project_CdMax);
				else
					_Project_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Project_Cd");
			}
		}
		public string Status_Cd
		{
			get { return _Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_CdMax )
					_Status_Cd = val.Substring(0, (int)Status_CdMax);
				else
					_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Cd");
			}
		}
		public string Wip_Flg
		{
			get { return _Wip_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Wip_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Wip_FlgMax )
					_Wip_Flg = val.Substring(0, (int)Wip_FlgMax);
				else
					_Wip_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Wip_Flg");
			}
		}
		public string New_Requirement_Flg
		{
			get { return _New_Requirement_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_New_Requirement_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > New_Requirement_FlgMax )
					_New_Requirement_Flg = val.Substring(0, (int)New_Requirement_FlgMax);
				else
					_New_Requirement_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("New_Requirement_Flg");
			}
		}
		public string Dev_Assist_Flg
		{
			get { return _Dev_Assist_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dev_Assist_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dev_Assist_FlgMax )
					_Dev_Assist_Flg = val.Substring(0, (int)Dev_Assist_FlgMax);
				else
					_Dev_Assist_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dev_Assist_Flg");
			}
		}
		public string Emg_Flg
		{
			get { return _Emg_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Emg_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Emg_FlgMax )
					_Emg_Flg = val.Substring(0, (int)Emg_FlgMax);
				else
					_Emg_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Emg_Flg");
			}
		}
		public string Data_Fix_Flg
		{
			get { return _Data_Fix_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Data_Fix_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Data_Fix_FlgMax )
					_Data_Fix_Flg = val.Substring(0, (int)Data_Fix_FlgMax);
				else
					_Data_Fix_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Data_Fix_Flg");
			}
		}
		public string Release_Flg
		{
			get { return _Release_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Release_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Release_FlgMax )
					_Release_Flg = val.Substring(0, (int)Release_FlgMax);
				else
					_Release_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Release_Flg");
			}
		}
		public string Category_Cd
		{
			get { return _Category_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Category_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Category_CdMax )
					_Category_Cd = val.Substring(0, (int)Category_CdMax);
				else
					_Category_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Category_Cd");
			}
		}
		public DateTime? Due_Dt
		{
			get { return _Due_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Due_Dt == val ) return;
		
				_Due_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Due_Dt");
			}
		}
		public Int16? Priority_Nbr
		{
			get { return _Priority_Nbr; }
			set
			{
				if( _Priority_Nbr == value ) return;
		
				_Priority_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Priority_Nbr");
			}
		}
		public string It_Owner_Login
		{
			get { return _It_Owner_Login; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_It_Owner_Login, val, false) == 0 ) return;
		
				if( val != null && val.Length > It_Owner_LoginMax )
					_It_Owner_Login = val.Substring(0, (int)It_Owner_LoginMax);
				else
					_It_Owner_Login = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("It_Owner_Login");
			}
		}
		public string Biz_Owner_Login
		{
			get { return _Biz_Owner_Login; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Biz_Owner_Login, val, false) == 0 ) return;
		
				if( val != null && val.Length > Biz_Owner_LoginMax )
					_Biz_Owner_Login = val.Substring(0, (int)Biz_Owner_LoginMax);
				else
					_Biz_Owner_Login = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Biz_Owner_Login");
			}
		}
		public DateTime? Request_By_Dt
		{
			get { return _Request_By_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Request_By_Dt == val ) return;
		
				_Request_By_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Request_By_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsProject _Project;
		protected ClsStatus _Status;
		protected ClsCategory _Category;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsProject Project
		{
			get
			{
				if( Project_Cd == null )
					_Project = null;
				else if( _Project == null ||
					_Project.Project_Cd != Project_Cd )
					_Project = ClsProject.GetUsingKey(Project_Cd);
				return _Project;
			}
			set
			{
				if( _Project == value ) return;
		
				_Project = value;
			}
		}
		public ClsStatus Status
		{
			get
			{
				if( Status_Cd == null )
					_Status = null;
				else if( _Status == null ||
					_Status.Status_Cd != Status_Cd )
					_Status = ClsStatus.GetUsingKey(Status_Cd);
				return _Status;
			}
			set
			{
				if( _Status == value ) return;
		
				_Status = value;
			}
		}
		public ClsCategory Category
		{
			get
			{
				if( Category_Cd == null )
					_Category = null;
				else if( _Category == null ||
					_Category.Category_Cd != Category_Cd )
					_Category = ClsCategory.GetUsingKey(Category_Cd);
				return _Category;
			}
			set
			{
				if( _Category == value ) return;
		
				_Category = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsIssue() : base() {}
		public ClsIssue(DataRow dr) : base(dr) {}
		public ClsIssue(ClsIssue src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Issue_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Issue_Dsc = null;
			Project_Cd = null;
			Status_Cd = null;
			Wip_Flg = null;
			New_Requirement_Flg = null;
			Dev_Assist_Flg = null;
			Emg_Flg = null;
			Data_Fix_Flg = null;
			Release_Flg = null;
			Category_Cd = null;
			Due_Dt = null;
			Priority_Nbr = null;
			It_Owner_Login = null;
			Biz_Owner_Login = null;
			Request_By_Dt = null;
		}

		public void CopyFrom(ClsIssue src)
		{
			Issue_ID = src._Issue_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Issue_Dsc = src._Issue_Dsc;
			Project_Cd = src._Project_Cd;
			Status_Cd = src._Status_Cd;
			Wip_Flg = src._Wip_Flg;
			New_Requirement_Flg = src._New_Requirement_Flg;
			Dev_Assist_Flg = src._Dev_Assist_Flg;
			Emg_Flg = src._Emg_Flg;
			Data_Fix_Flg = src._Data_Fix_Flg;
			Release_Flg = src._Release_Flg;
			Category_Cd = src._Category_Cd;
			Due_Dt = src._Due_Dt;
			Priority_Nbr = src._Priority_Nbr;
			It_Owner_Login = src._It_Owner_Login;
			Biz_Owner_Login = src._Biz_Owner_Login;
			Request_By_Dt = src._Request_By_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsIssue tmp = ClsIssue.GetUsingKey(Issue_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Project = null;
			_Status = null;
			_Category = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[20];

			p[0] = Connection.GetParameter
				("@ISSUE_DSC", Issue_Dsc);
			p[1] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[2] = Connection.GetParameter
				("@STATUS_CD", Status_Cd);
			p[3] = Connection.GetParameter
				("@WIP_FLG", Wip_Flg);
			p[4] = Connection.GetParameter
				("@NEW_REQUIREMENT_FLG", New_Requirement_Flg);
			p[5] = Connection.GetParameter
				("@DEV_ASSIST_FLG", Dev_Assist_Flg);
			p[6] = Connection.GetParameter
				("@EMG_FLG", Emg_Flg);
			p[7] = Connection.GetParameter
				("@DATA_FIX_FLG", Data_Fix_Flg);
			p[8] = Connection.GetParameter
				("@RELEASE_FLG", Release_Flg);
			p[9] = Connection.GetParameter
				("@CATEGORY_CD", Category_Cd);
			p[10] = Connection.GetParameter
				("@DUE_DT", Due_Dt);
			p[11] = Connection.GetParameter
				("@PRIORITY_NBR", Priority_Nbr);
			p[12] = Connection.GetParameter
				("@IT_OWNER_LOGIN", It_Owner_Login);
			p[13] = Connection.GetParameter
				("@BIZ_OWNER_LOGIN", Biz_Owner_Login);
			p[14] = Connection.GetParameter
				("@REQUEST_BY_DT", Request_By_Dt);
			p[15] = Connection.GetParameter
				("@ISSUE_ID", Issue_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[16] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[17] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[18] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[19] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_ISSUE
					(ISSUE_ID, ISSUE_DSC, PROJECT_CD,
					STATUS_CD, WIP_FLG, NEW_REQUIREMENT_FLG,
					DEV_ASSIST_FLG, EMG_FLG, DATA_FIX_FLG,
					RELEASE_FLG, CATEGORY_CD, DUE_DT,
					PRIORITY_NBR, IT_OWNER_LOGIN, BIZ_OWNER_LOGIN,
					REQUEST_BY_DT)
				VALUES
					(ISSUE_ID_SEQ.NEXTVAL, @ISSUE_DSC, @PROJECT_CD,
					@STATUS_CD, @WIP_FLG, @NEW_REQUIREMENT_FLG,
					@DEV_ASSIST_FLG, @EMG_FLG, @DATA_FIX_FLG,
					@RELEASE_FLG, @CATEGORY_CD, @DUE_DT,
					@PRIORITY_NBR, @IT_OWNER_LOGIN, @BIZ_OWNER_LOGIN,
					@REQUEST_BY_DT)
				RETURNING
					ISSUE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@ISSUE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Issue_ID = ClsConvert.ToInt64Nullable(p[15].Value);
			Create_User = ClsConvert.ToString(p[16].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[17].Value);
			Modify_User = ClsConvert.ToString(p[18].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[19].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[18];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ISSUE_DSC", Issue_Dsc);
			p[2] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[3] = Connection.GetParameter
				("@STATUS_CD", Status_Cd);
			p[4] = Connection.GetParameter
				("@WIP_FLG", Wip_Flg);
			p[5] = Connection.GetParameter
				("@NEW_REQUIREMENT_FLG", New_Requirement_Flg);
			p[6] = Connection.GetParameter
				("@DEV_ASSIST_FLG", Dev_Assist_Flg);
			p[7] = Connection.GetParameter
				("@EMG_FLG", Emg_Flg);
			p[8] = Connection.GetParameter
				("@DATA_FIX_FLG", Data_Fix_Flg);
			p[9] = Connection.GetParameter
				("@RELEASE_FLG", Release_Flg);
			p[10] = Connection.GetParameter
				("@CATEGORY_CD", Category_Cd);
			p[11] = Connection.GetParameter
				("@DUE_DT", Due_Dt);
			p[12] = Connection.GetParameter
				("@PRIORITY_NBR", Priority_Nbr);
			p[13] = Connection.GetParameter
				("@IT_OWNER_LOGIN", It_Owner_Login);
			p[14] = Connection.GetParameter
				("@BIZ_OWNER_LOGIN", Biz_Owner_Login);
			p[15] = Connection.GetParameter
				("@REQUEST_BY_DT", Request_By_Dt);
			p[16] = Connection.GetParameter
				("@ISSUE_ID", Issue_ID);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ISSUE SET
					MODIFY_DT = @MODIFY_DT,
					ISSUE_DSC = @ISSUE_DSC,
					PROJECT_CD = @PROJECT_CD,
					STATUS_CD = @STATUS_CD,
					WIP_FLG = @WIP_FLG,
					NEW_REQUIREMENT_FLG = @NEW_REQUIREMENT_FLG,
					DEV_ASSIST_FLG = @DEV_ASSIST_FLG,
					EMG_FLG = @EMG_FLG,
					DATA_FIX_FLG = @DATA_FIX_FLG,
					RELEASE_FLG = @RELEASE_FLG,
					CATEGORY_CD = @CATEGORY_CD,
					DUE_DT = @DUE_DT,
					PRIORITY_NBR = @PRIORITY_NBR,
					IT_OWNER_LOGIN = @IT_OWNER_LOGIN,
					BIZ_OWNER_LOGIN = @BIZ_OWNER_LOGIN,
					REQUEST_BY_DT = @REQUEST_BY_DT
				WHERE
					ISSUE_ID = @ISSUE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ISSUE_ID", Issue_ID);

			const string sql = @"
				DELETE FROM T_ISSUE WHERE
				ISSUE_ID=@ISSUE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Issue_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Issue_Dsc = ClsConvert.ToString(dr["ISSUE_DSC"]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD"]);
			Status_Cd = ClsConvert.ToString(dr["STATUS_CD"]);
			Wip_Flg = ClsConvert.ToString(dr["WIP_FLG"]);
			New_Requirement_Flg = ClsConvert.ToString(dr["NEW_REQUIREMENT_FLG"]);
			Dev_Assist_Flg = ClsConvert.ToString(dr["DEV_ASSIST_FLG"]);
			Emg_Flg = ClsConvert.ToString(dr["EMG_FLG"]);
			Data_Fix_Flg = ClsConvert.ToString(dr["DATA_FIX_FLG"]);
			Release_Flg = ClsConvert.ToString(dr["RELEASE_FLG"]);
			Category_Cd = ClsConvert.ToString(dr["CATEGORY_CD"]);
			Due_Dt = ClsConvert.ToDateTimeNullable(dr["DUE_DT"]);
			Priority_Nbr = ClsConvert.ToInt16Nullable(dr["PRIORITY_NBR"]);
			It_Owner_Login = ClsConvert.ToString(dr["IT_OWNER_LOGIN"]);
			Biz_Owner_Login = ClsConvert.ToString(dr["BIZ_OWNER_LOGIN"]);
			Request_By_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_BY_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Issue_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Issue_Dsc = ClsConvert.ToString(dr["ISSUE_DSC", v]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD", v]);
			Status_Cd = ClsConvert.ToString(dr["STATUS_CD", v]);
			Wip_Flg = ClsConvert.ToString(dr["WIP_FLG", v]);
			New_Requirement_Flg = ClsConvert.ToString(dr["NEW_REQUIREMENT_FLG", v]);
			Dev_Assist_Flg = ClsConvert.ToString(dr["DEV_ASSIST_FLG", v]);
			Emg_Flg = ClsConvert.ToString(dr["EMG_FLG", v]);
			Data_Fix_Flg = ClsConvert.ToString(dr["DATA_FIX_FLG", v]);
			Release_Flg = ClsConvert.ToString(dr["RELEASE_FLG", v]);
			Category_Cd = ClsConvert.ToString(dr["CATEGORY_CD", v]);
			Due_Dt = ClsConvert.ToDateTimeNullable(dr["DUE_DT", v]);
			Priority_Nbr = ClsConvert.ToInt16Nullable(dr["PRIORITY_NBR", v]);
			It_Owner_Login = ClsConvert.ToString(dr["IT_OWNER_LOGIN", v]);
			Biz_Owner_Login = ClsConvert.ToString(dr["BIZ_OWNER_LOGIN", v]);
			Request_By_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_BY_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ISSUE_ID"] = ClsConvert.ToDbObject(Issue_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ISSUE_DSC"] = ClsConvert.ToDbObject(Issue_Dsc);
			dr["PROJECT_CD"] = ClsConvert.ToDbObject(Project_Cd);
			dr["STATUS_CD"] = ClsConvert.ToDbObject(Status_Cd);
			dr["WIP_FLG"] = ClsConvert.ToDbObject(Wip_Flg);
			dr["NEW_REQUIREMENT_FLG"] = ClsConvert.ToDbObject(New_Requirement_Flg);
			dr["DEV_ASSIST_FLG"] = ClsConvert.ToDbObject(Dev_Assist_Flg);
			dr["EMG_FLG"] = ClsConvert.ToDbObject(Emg_Flg);
			dr["DATA_FIX_FLG"] = ClsConvert.ToDbObject(Data_Fix_Flg);
			dr["RELEASE_FLG"] = ClsConvert.ToDbObject(Release_Flg);
			dr["CATEGORY_CD"] = ClsConvert.ToDbObject(Category_Cd);
			dr["DUE_DT"] = ClsConvert.ToDbObject(Due_Dt);
			dr["PRIORITY_NBR"] = ClsConvert.ToDbObject(Priority_Nbr);
			dr["IT_OWNER_LOGIN"] = ClsConvert.ToDbObject(It_Owner_Login);
			dr["BIZ_OWNER_LOGIN"] = ClsConvert.ToDbObject(Biz_Owner_Login);
			dr["REQUEST_BY_DT"] = ClsConvert.ToDbObject(Request_By_Dt);
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

		public static ClsIssue GetUsingKey(Int64 Issue_ID)
		{
			object[] vals = new object[] {Issue_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsIssue(dr);
		}
		public static DataTable GetAll(string Project_Cd, string Status_Cd,
			string Category_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Project_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PROJECT_CD", Project_Cd));
				sb.Append(" WHERE T_ISSUE.PROJECT_CD=@PROJECT_CD");
			}
			if( string.IsNullOrEmpty(Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@STATUS_CD", Status_Cd));
				sb.AppendFormat(" {0} T_ISSUE.STATUS_CD=@STATUS_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Category_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CATEGORY_CD", Category_Cd));
				sb.AppendFormat(" {0} T_ISSUE.CATEGORY_CD=@CATEGORY_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}