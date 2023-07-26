using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public enum StatusCode
	{
		New, Hold, Spec, Dev, Pend, Test, Approved, Closed
	}

	public enum IssueFlag
	{
		New_Requirement, Work_In_Progress, Developer_Assistance, Emergency, Data_Fix, Release
	}

	partial class ClsIssue
	{
		#region Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Emg_Flg = "N";
			Wip_Flg = "N";
			Release_Flg = "Y";
			Data_Fix_Flg = "N";
			Dev_Assist_Flg = "N";
			New_Requirement_Flg = "Y";

			Issue_Dsc = "NEW ISSUE ADDED";

			Status_Cd = StatusCode.New.ToString().ToUpper();
			ClsUser user = ClsUser.CurrentUser;
			if( user != null ) Category_Cd = user.Def_Category_Cd;

			if( ClsEnvironment.IsDeveloper )
			{
				Biz_Owner_Login = null;
				It_Owner_Login = ClsEnvironment.UserName;
			}
			else if( ClsEnvironment.CheckInfrastructure(ClsEnvironment.UserName) )
			{
				Biz_Owner_Login = ClsEnvironment.UserName;
				It_Owner_Login = ClsEnvironment.UserName;
			}
			else
			{
				Biz_Owner_Login = ClsEnvironment.UserName;
				It_Owner_Login = null;
			}
		}

		protected override void OnReload()
		{
			_NotesBox = null;
			_Action_Owner = null;

			_Notes = null;
			_Attachments = null;

			_Priority_Cd = null;
			_Priority_Dsc = null;
		}
		#endregion		// #region Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}, {3}, {4}",
				Issue_ID, Issue_Dsc, Project_Cd, Category_Cd, Status_Cd);
		}

		public string ToString(string format)
		{
			switch( format )
			{
				case "s":
				case "S":
					string cat = (Category != null) ? Category.Category_Nm : Category_Cd;
					string stat = (Status != null && !string.IsNullOrEmpty(Status.Status_Dsc))
						? Status.Status_Dsc.ToLower() : Status_Cd;
					return string.Format("{0} {1} Issue# {2}: {3} ({4})",
						Project_Cd, cat, Issue_ID, Issue_Dsc, stat);

				case "l":
				case "L":
					return string.Format
						("{0}: {1} Target Date: {2}\r\n{3} - {4} - {5}\r\nAction Owner: {6}, Other: {7}",
						Issue_ID, Issue_Dsc, (Due_Dt != null ? ClsConfig.FormatDate(Due_Dt) : "NONE"),
						Project_Cd,
						(Category != null ? Category.Category_Nm : Category_Cd),
						(Status != null ? Status.Status_Dsc : Status_Cd),
						Action_Owner, Other_Owner);

				case "a":
				case "A":
					return string.Format("{0}: {1}, {2}, {3}, {4}, {5}, {6}, {7}",
						Issue_ID, Issue_Dsc, Project_Cd, Category_Cd, Status_Cd,
						Biz_Owner_Login, ClsConfig.FormatDate(Due_Dt), It_Owner_Login);

				case "b":
				case "B":
					return string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
						Project_Cd, Category_Cd, Status_Cd, Biz_Owner_Login,
						ClsConfig.FormatDate(Due_Dt), It_Owner_Login);

				default:
					break;
			}

			return ToString();
		}
		#endregion		// #region ToString Overrides

		#region Validation Methods

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			if( string.IsNullOrEmpty(Project_Cd) == true )
				_Errors["Project_Cd"] = "Missing project";
			if( string.IsNullOrEmpty(Status_Cd) == true )
				_Errors["Status_Cd"] = "Missing status";
			if( string.IsNullOrEmpty(Issue_Dsc) == true )
				_Errors["Issue_Dsc"] = "Missing issue description";
			else if( Issue_Dsc.Length < 10 )
				_Errors["Issue_Dsc"] = "More information is needed in the title";

			if( string.IsNullOrEmpty(Emg_Flg) )
				_Errors["Emg_Flg"] = "Missing EMG flag";
			if( string.IsNullOrEmpty(Wip_Flg) )
				_Errors["Wip_Flg"] = "Missing WIP flag";
			if( string.IsNullOrEmpty(Data_Fix_Flg) )
				_Errors["Data_Fix_Flg"] = "Missing data fix flag";
			if( string.IsNullOrEmpty(Dev_Assist_Flg) )
				_Errors["Dev_Assist_Flg"] = "Missing DVA flag";
			if( string.IsNullOrEmpty(Release_Flg) )
				_Errors["Release_Flg"] = "Missing release flag";
			if( string.IsNullOrEmpty(New_Requirement_Flg) )
				_Errors["New_Requirement_Flg"] = "Missing NRQ flag";
		}
		#endregion		// #region Validation Methods

		#region Add/Remove Issues

		public bool AddNewIssue(string note)
		{
			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				Insert();

				ClsIssueNote nt = new ClsIssueNote();
				nt.SetDefaults(this);
				nt.Note_Txt = note;

				bool ok = nt.ValidateInsert();
				if( !ok )
					_Errors["Notes"] = nt.Error;
				else
					nt.Insert();

				if( newTx == true ) Connection.TransactionEnd(ok);

				return ok;
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}

		public bool UpdateIssue(string note)
		{
			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				Update();

				ClsIssueNote nt = new ClsIssueNote();
				nt.SetDefaults(this);
				nt.Note_Txt = note;

				bool ok = nt.ValidateInsert();
				if( !ok )
					_Errors["Notes"] = nt.Error;
				else
					nt.Insert();

				if( newTx == true ) Connection.TransactionEnd(ok);

				return ok;
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}

		public bool DeleteIssue()
		{
			if( !ClsEnvironment.IsDeveloper )
			{
				_Errors["DeleteIssue"] = "You are not authorized to perform this action";
				return false;
			}

			LoadNotes(false);
			if( _Notes != null && _Notes.Count > 0 )
			{
				_Errors["DeleteIssue"] = "Issue cannot be deleted, there are notes associated with it";
				return false;
			}

			LoadAttachments();
			if( _Attachments != null && _Attachments.Count > 0 )
			{
				_Errors["DeleteIssue"] = "Issue cannot be deleted, there are attachments associated with it";
				return false;
			}

			Delete();

			return true;
		}
		#endregion		// #region Add/Remove Issues

		#region Owner Section

		private string _Action_Owner;

		public string Action_Owner
		{
			get
			{
				if( _Action_Owner == null ) LoadActionOwner();
				return _Action_Owner;
			}
		}

		public void LoadActionOwner()
		{
			if( Issue_ID == null )
			{
				_Action_Owner = string.Empty;
				return;
			}

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ISS_ID", Issue_ID.Value);
			string sql = string.Format("SELECT {0} FROM t_issue iss WHERE iss.ISSUE_ID = @ISS_ID ",
				SqlComputedOwner);

			object o = Connection.GetScalar(sql, p);
			_Action_Owner = ClsConvert.ToString(o);
		}

		public string Other_Owner
		{
			get
			{
				if( string.Compare(Biz_Owner_Login, It_Owner_Login, true) == 0 ) return null;

				return (string.Compare(Action_Owner, Biz_Owner_Login, true) == 0)
					? It_Owner_Login : Biz_Owner_Login;
			}
		}
		#endregion		// #region Owner Section

		#region Priority Section

		private IssuePriority? _Priority_Cd;
		private string _Priority_Dsc;

		public IssuePriority Priority_Cd
		{
			get
			{
				if( _Priority_Cd == null ) _Priority_Cd = ComputePriority();
				return _Priority_Cd.GetValueOrDefault(IssuePriority.NONE);
			}
		}

		public string Priority_Dsc
		{
			get
			{
				if( _Priority_Dsc == null ) _Priority_Dsc = ComputePriorityDsc();
				return _Priority_Dsc;
			}
		}

		public IssuePriority ComputePriority()
		{
			if( ClsConvert.YNToBool(Emg_Flg) ) return IssuePriority.EMERGENCY;
			if( ClsConvert.YNToBool(Data_Fix_Flg) ) return IssuePriority.DATA_FIX;
			if( Due_Dt != null ) return IssuePriority.NORMAL;

			return IssuePriority.NONE;
		}

		public string ComputePriorityDsc()
		{
			IssuePriority p = ComputePriority();

			return PriorityList[p];
		}
		#endregion		// #region Priority Section

		#region Notes

		private List<ClsIssueNote> _Notes;

		public List<ClsIssueNote> Notes
		{
			get
			{
				if( _Notes == null ) LoadNotes(true);
				return _Notes;
			}
		}

		public void LoadNotes(bool excludeDevNotes)
		{
			if( Issue_ID == null )
			{
				if( _Notes == null )
					_Notes = new List<ClsIssueNote>();
				else
					_Notes.Clear();
				return;
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("SELECT * FROM {0} nt ", ClsIssueNote.TableName);

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "WHERE", "nt.ISSUE_ID", "@ISS_ID", Issue_ID.Value);

			if( excludeDevNotes )
				Connection.AppendEqualClause(sb, p, "AND", "nt.DEVELOPER_FLG", "@DEV_FLG", "N");

			sb.Append("\r\n\t ORDER BY nt.CREATE_DT DESC");

			_Notes = Connection.GetList<ClsIssueNote>(sb.ToString(), p.ToArray());
		}

		private string _NotesBox;

		public string NotesBox
		{
			get
			{
				if( _NotesBox == null ) AssembleNotes(null, true);
				return _NotesBox;
			}
		}

		public void AssembleNotes(string format, bool excludeDevNotes)
		{
			LoadNotes(excludeDevNotes);
			if( _Notes == null || _Notes.Count <= 0 )
			{
				_NotesBox = string.Empty;
				return;
			}

			string line = new string('-', 8);
			StringBuilder sb = new StringBuilder();
			foreach( ClsIssueNote nt in _Notes )
			{
				switch( format )
				{
					case "e":
					case "E":
						sb.AppendFormat("{4}: Note from {1} on {0}\r\n{2}\r\n{3}\r\n\r\n",
							ClsConfig.FormatDate(nt.Create_Dt),
							nt.Create_User, line, nt.Note_Txt, Issue_ID);
						break;

					default:
						sb.AppendFormat("{0} {1}: {2}\r\n",
							ClsConfig.FormatDate(nt.Create_Dt), nt.Create_User, nt.Note_Txt);
						break;
				}
			}

			_NotesBox = (sb.Length > 0) ? sb.ToString() : string.Empty;
		}
		#endregion		// #region Notes

		#region Attachments

		private List<ClsAttachment> _Attachments;

		public List<ClsAttachment> Attachments
		{
			get
			{
				if( _Attachments == null ) LoadAttachments();
				return _Attachments;
			}
		}

		public void LoadAttachments()
		{
			if( Issue_ID == null )
			{
				if( _Attachments == null )
					_Attachments = new List<ClsAttachment>();
				else
					_Attachments.Clear();
				return;
			}

			string sql = string.Format("SELECT * FROM {0} att WHERE att.ISSUE_ID = @ISS_ID ",
				ClsAttachment.TableName);
			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ISS_ID", Issue_ID.Value);

			_Attachments = Connection.GetList<ClsAttachment>(sql, p);
		}

		public ClsAttachment AddAttachment(string file)
		{
			_Errors.Clear();

			ClsAttachment att = new ClsAttachment();
			att.SetDefaults();
			att.Issue_ID = Issue_ID;
			att.Attachment = ClsConvert.FileToBlob(file);
			att.Attachment_Nm = Path.GetFileName(file);

			if( att.ValidateInsert() == false )
				_Errors["Attachment"] = att.Error;
			else
				att.Insert();

			return (_Errors.Count == 0) ? att : null;
		}
		#endregion		// #region Attachments

		#region Flag Section

		public bool CanSetWIP
		{
			get { return (IsSpec || IsDev || IsTest); }
		}

		public bool CanSetNewRequirement
		{
			get { return true; }
		}

		public bool CanSetEmergency
		{
			get { return !IsClosed; }
		}

		public bool CanSetDataFix
		{
			get { return true; }
		}

		public bool CanSetRelease
		{
			get { return true; }
		}

		public bool CanSetDevAssist
		{
			get { return (IsSpec || IsTest); }
		}

		public bool CanUpdateFlag(IssueFlag issFlg, bool newState)
		{
			bool? currentState = null;
			bool canChange = false;
			switch( issFlg )
			{
				case IssueFlag.New_Requirement:
					currentState = ClsConvert.YNToBool(New_Requirement_Flg);
					canChange = (newState) ? CanSetNewRequirement : true;
					break;
				case IssueFlag.Work_In_Progress:
					currentState = ClsConvert.YNToBool(Wip_Flg);
					canChange = (newState) ? CanSetWIP : true;
					break;
				case IssueFlag.Developer_Assistance:
					currentState = ClsConvert.YNToBool(Dev_Assist_Flg);
					canChange = (newState) ? CanSetDevAssist : true;
					break;
				case IssueFlag.Emergency:
					currentState = ClsConvert.YNToBool(Emg_Flg);
					canChange = (newState) ? CanSetEmergency : true;
					break;
				case IssueFlag.Data_Fix	:
					currentState = ClsConvert.YNToBool(Data_Fix_Flg);
					canChange = (newState) ? CanSetDataFix : true;
					break;
				case IssueFlag.Release:
					currentState = ClsConvert.YNToBool(Release_Flg);
					canChange = (newState) ? CanSetRelease : true;
					break;
				default: currentState = null; break;
			}

			if( currentState == null )
			{
				_Errors["MissingOP"] = string.Format("No operation defined for {0} flag", issFlg);
				return false;
			}

			if( currentState == newState )
			{
				_Errors["SameState"] = string.Format("Issue {0}: {1} flag is already set to {2}",
					Issue_ID, issFlg, ClsConvert.BoolToYN(newState));
				return false;
			}

			if( !canChange )
			{
				_Errors["Status"] = string.Format("Issue {0}: {1} flag cannot be set to {2}, status is {3}",
					Issue_ID, issFlg, ClsConvert.BoolToYN(newState), Status_Cd);
				return false;
			}

			return true;
		}

		public void UpdateFlag(IssueFlag issFlg, string yn)
		{
			switch( issFlg )
			{
				case IssueFlag.New_Requirement: New_Requirement_Flg = yn; break;
				case IssueFlag.Work_In_Progress: Wip_Flg = yn; break;
				case IssueFlag.Developer_Assistance: Dev_Assist_Flg = yn; break;
				case IssueFlag.Emergency: Emg_Flg = yn; break;
				case IssueFlag.Data_Fix: Data_Fix_Flg = yn; break;
				case IssueFlag.Release: Release_Flg = yn; break;
			}
		}

		public string GetFlag(IssueFlag issFlg)
		{
			switch( issFlg )
			{
				case IssueFlag.New_Requirement: return New_Requirement_Flg;
				case IssueFlag.Work_In_Progress: return Wip_Flg;
				case IssueFlag.Developer_Assistance: return Dev_Assist_Flg;
				case IssueFlag.Emergency: return Emg_Flg;
				case IssueFlag.Data_Fix: return Data_Fix_Flg;
				case IssueFlag.Release: return Release_Flg;
			}
			return null;
		}
		#endregion		// #region Flag Section

		#region Status Section

		public bool IsNew
		{
			get { return string.Compare(Status_Cd, StatusCode.New.ToString(), true) == 0; }
		}

		public bool IsHold
		{
			get { return string.Compare(Status_Cd, StatusCode.Hold.ToString(), true) == 0; }
		}

		public bool IsSpec
		{
			get { return string.Compare(Status_Cd, StatusCode.Spec.ToString(), true) == 0; }
		}

		public bool IsDev
		{
			get { return string.Compare(Status_Cd, StatusCode.Dev.ToString(), true) == 0; }
		}

		public bool IsPend
		{
			get { return string.Compare(Status_Cd, StatusCode.Pend.ToString(), true) == 0; }
		}

		public bool IsTest
		{
			get { return string.Compare(Status_Cd, StatusCode.Test.ToString(), true) == 0; }
		}

		public bool IsApproved
		{
			get { return string.Compare(Status_Cd, StatusCode.Approved.ToString(), true) == 0; }
		}

		public bool IsClosed
		{
			get { return string.Compare(Status_Cd, StatusCode.Closed.ToString(), true) == 0; }
		}

		public string NextNormalStatus
		{
			get
			{
				if( IsNew || IsHold ) return StatusCode.Spec.ToString().ToUpper();
				if( IsSpec ) return StatusCode.Dev.ToString().ToUpper();
				if( IsDev ) return StatusCode.Pend.ToString().ToUpper();
				if( IsPend ) return StatusCode.Test.ToString().ToUpper();
				if( IsTest ) return StatusCode.Approved.ToString().ToUpper();
				if( IsApproved ) return StatusCode.Closed.ToString().ToUpper();

				return null;		// IsClosed and any other not defined yet
			}
		}

		public List<string> NextPossibleStatus()
		{
			// return list of all possible next statuses given the current status
			return null;
		}
		#endregion		// #region Status Section
	}

	#region Static Methods/Properties of ClsIssue

	partial class ClsIssue
	{
		#region Constants

		public const string EmgWarningQuestion = @"
Emergency issues threaten normal business operation. The indviduals involved must remain
on-site until the issue is resolved. This includes the business owner, the issue creator,
development manager, a programmer, and other key members who may be identified. An email
will be sent to a predefined list of users notifying them of the emergency.

Are you sure you want to mark the issue as an emergency?";

		public const string EmgEmailIntro = @"
The following issue has been flagged as an emergency and threatens normal business operation.";

		#endregion		// #region Constants

		#region Static Constructor

		static ClsIssue()
		{
			PriorityList = new Dictionary<IssuePriority, string>(3);
			PriorityList.Add(IssuePriority.EMERGENCY, "HIGHEST PRIORITY");
			PriorityList.Add(IssuePriority.DATA_FIX, "HIGH PRIORITY");
			PriorityList.Add(IssuePriority.NORMAL, "DUE DATE ASSIGNED");
			PriorityList.Add(IssuePriority.NONE, "MISSING DUE DATE");
		}
		#endregion		// #region Static Constructor

		#region Public Update Methods

		public static bool UpdateIssueFlag(List<ClsIssue> lst, IssueFlag issFlg, bool newState, StringBuilder sb)
		{
			sb.Length = 0;
			if( lst == null || lst.Count <= 0 )
			{
				sb.Append("No issues provided");
				return false;
			}

			string yn = ClsConvert.BoolToYN(newState);
			foreach( ClsIssue iss in lst )
			{
				iss.ResetErrors();
				if( !iss.CanUpdateFlag(issFlg, newState) )
					sb.AppendLine(iss.Error);
			}
			if( sb.Length > 0 ) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				foreach( ClsIssue iss in lst )
				{
					iss.UpdateFlag(issFlg, yn);
					iss.Update();
				}

				if( newTx == true ) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}

		public static void ClearDeveloper(List<ClsIssue> lst)
		{
			if( lst == null || lst.Count <= 0 ) return;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				foreach( ClsIssue iss in lst )
				{
					iss.It_Owner_Login = null;
					iss.Update();
				}

				if( newTx == true ) Connection.TransactionCommit();
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}

		public static void ReleaseIssues(List<ClsIssue> lst, ClsProject aProject,
			ClsIssueNote aNote, string statusCd)
		{
			if( lst == null || lst.Count <= 0 ) return;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				foreach( ClsIssue iss in lst )
				{
					iss.Status_Cd = statusCd;
					aNote.Version_No = aProject.Next_Version_No;
					aNote.Issue_ID = iss.Issue_ID;
					aNote.AddNote(iss);
				}

				aProject.Update();

				if( newTx == true ) Connection.TransactionCommit();
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}

		public static void UpdateIssues(List<ClsIssue> lst, ClsProject aProject,
			ClsStatus aStatus, ClsIssueNote aNote)
		{
			if( lst == null || lst.Count <= 0 ) return;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				foreach( ClsIssue iss in lst )
				{
					if( aStatus != null || aProject != null )
					{
						if( aStatus != null ) iss.Status_Cd = aStatus.Status_Cd;
						if( aProject != null ) iss.Project_Cd = aProject.Project_Cd;
						iss.Update();
					}

					if( aNote != null && !string.IsNullOrEmpty(aNote.Note_Txt) )
					{
						if( aProject != null ) aNote.Version_No = aProject.Next_Version_No;
						aNote.Issue_ID = iss.Issue_ID;
						aNote.AddNote(iss);
					}
				}

				if( newTx == true ) Connection.TransactionCommit();
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Public Update Methods

		#region Public Search Methods

		public static string SqlComputedOwner
		{
			get
			{
				return @"
				CASE
					WHEN iss.status_cd IN ('DEV', 'NEW', 'HOLD')
						THEN nvl(iss.it_owner_login, 'DEV GRP')
					WHEN iss.status_cd IN ('APPROVED', 'PEND')
						THEN 'DEV GRP'
					WHEN iss.status_cd IN ('SPEC', 'TEST')
						THEN nvl(iss.biz_owner_login, 'BIZ GRP')
					WHEN iss.status_cd = 'CLOSED' THEN
						'NONE'
					ELSE
						'UNKNOWN'
				END";
			}
		}

		public static string SqlComputedPriority
		{
			get
			{
				return @"
				CASE
					WHEN iss.emg_flg = 'Y'		THEN	'EMERGENCY'
					WHEN iss.data_fix_flg = 'Y'	THEN	'DATA_FIX'
					WHEN iss.due_dt IS NOT NULL	THEN	'NORMAL'
					ELSE								'NONE'
				END";
			}
		}

		public static string SqlDueDateStatus
		{
			get
			{
				return @"
				CASE
					WHEN iss.due_dt IS NULL OR iss.status_cd = 'CLOSED' THEN ''
					WHEN trunc(SYSDATE) > trunc(iss.due_dt)				THEN 'OVERDUE'
					WHEN trunc(SYSDATE) = trunc(iss.due_dt)				THEN 'DUE TODAY'
					WHEN trunc(iss.due_dt) <= (trunc(SYSDATE) + 10)		THEN 'APPROACHING DUE DATE'
					ELSE ''
				END";
			}
		}

		public static DataSet SearchIssuesDS(IssueParams options)
		{
			DataSet ds = new DataSet();

			DataTable dtIssues = SearchIssues(options);
			dtIssues.TableName = "Issues";

			DataTable dtNotes = SearchIssueNotes(options);
			dtNotes.TableName = "IssueNotes";

			DataTable dtAttachments = SearchIssueAttachments(options);
			dtAttachments.TableName = "IssueAttachments";

			ds.Tables.Add(dtIssues);
			ds.Tables.Add(dtNotes);
			ds.Tables.Add(dtAttachments);

			if( dtIssues.Rows.Count > 0 )
			{
				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtIssues.Columns["ISSUE_ID"];

				DataColumn[] dcFK1 = new DataColumn[1];
				dcFK1[0] = dtNotes.Columns["ISSUE_ID"];

				ds.Relations.Add("IssueNotes", dcPK, dcFK1, false);

				DataColumn[] dcFK2 = new DataColumn[1];
				dcFK2[0] = dtAttachments.Columns["ISSUE_ID"];

				ds.Relations.Add("IssueAttachments", dcPK, dcFK2, false);
			}

			return ds;
		}

		public static DataTable SearchIssues(IssueParams options)
		{
			try
			{
				List<DbParameter> p = new List<DbParameter>();
				StringBuilder sb = new StringBuilder(@"
			WITH nt_info AS
				(
					SELECT issue_id, count(*) AS note_count, MAX(create_dt) AS last_note_dt
					FROM t_issue_note GROUP BY issue_id
				),
				att_info AS
				(
					SELECT issue_id, count(*) AS attach_count, MAX(create_dt) AS last_attach_dt
					FROM t_attachment GROUP BY issue_id
				)
			SELECT	iss.*, prj.project_nm, cat.category_nm, st.status_dsc, att_info.attach_count,
					nt_info.note_count, att_info.last_attach_dt, nt_info.last_note_dt,
					(iss.due_dt - 7) AS avl_test_dt ");

				sb.AppendFormat(",{0} AS ACTION_OWNER ", SqlComputedOwner);
				sb.AppendFormat(",{0} AS Priority_Dsc ", SqlComputedPriority);
				sb.AppendFormat(",{0} AS Due_Date_Status ", SqlDueDateStatus);

				sb.Append(@"
			FROM	T_ISSUE iss
					INNER JOIN R_PROJECT prj ON prj.PROJECT_CD = iss.PROJECT_CD
					LEFT OUTER JOIN R_CATEGORY cat ON cat.CATEGORY_CD = iss.CATEGORY_CD
					LEFT OUTER JOIN R_STATUS st ON st.STATUS_CD = iss.STATUS_CD
					LEFT OUTER JOIN R_USER usr ON usr.user_login = iss.biz_owner_login
					LEFT OUTER JOIN nt_info ON nt_info.issue_id = iss.issue_id
					LEFT OUTER JOIN att_info ON att_info.issue_id = iss.issue_id
			WHERE 1 = 1");

				AppendWhere(sb, p, options, true);

				string keyTxt = (string.IsNullOrEmpty(options.Keyword)) ? null : options.Keyword.Trim();
				if (string.IsNullOrEmpty(keyTxt))
				{
					string notes = (string.IsNullOrEmpty(options.Notes)) ? null : options.Notes.Trim();
					if (string.IsNullOrEmpty(notes) == false)
					{
						string s = string.Format("%{0}%", notes);
						string noteSql = @"
				EXISTS (
					SELECT 'X' FROM T_ISSUE_NOTE nt
					WHERE nt.ISSUE_ID = iss.ISSUE_ID AND UPPER(nt.NOTE_TXT) LIKE UPPER(@NOTE_TXT)
				)";
						sb.AppendFormat("\r\n\t AND {0}", noteSql);
						p.Add(Connection.GetParameter("@NOTE_TXT", s));
					}
				}
				else
				{
					string s = string.Format("%{0}%", keyTxt);
					sb.Append(@" AND (UPPER(iss.issue_dsc) LIKE UPPER(@ISSUE_TXT) OR
				EXISTS (
					SELECT 'X' FROM T_ISSUE_NOTE nt
					WHERE nt.ISSUE_ID = iss.ISSUE_ID AND UPPER(nt.NOTE_TXT) LIKE UPPER(@NOTE_TXT)
				) )");
					p.Add(Connection.GetParameter("@ISSUE_TXT", s));
					p.Add(Connection.GetParameter("@NOTE_TXT", s));
				}

				sb.Append("\r\n ORDER BY st.status_dsc, iss.ISSUE_ID ");

				return Connection.GetDataTable(sb.ToString(), p.ToArray());
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		public static DataTable SearchIssueNotes(IssueParams options)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	nts.*
			FROM	T_ISSUE_NOTE nts
					INNER JOIN T_ISSUE iss ON iss.ISSUE_ID = nts.ISSUE_ID
			WHERE	1 = 1 ");

			AppendWhere(sb, p, options, false);

			if( ClsEnvironment.IsDeveloper == false )
				Connection.AppendEqualClause(sb, p, "AND", "DEVELOPER_FLG", "@DEV_FLG", "N");

			sb.AppendFormat("\r\n ORDER BY nts.ISSUE_ID ASC, nts.CREATE_DT DESC ");

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static DataTable SearchIssueAttachments(IssueParams options)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	att.attachment_id, att.issue_id, att.create_user, att.create_dt,
					att.modify_user, att.modify_dt, att.attachment_nm, TO_BLOB(NULL) AS attachment
			FROM	T_ATTACHMENT att
					INNER JOIN T_ISSUE iss ON iss.ISSUE_ID = att.ISSUE_ID
			WHERE	1 = 1 ");

			AppendWhere(sb, p, options, false);

			sb.AppendFormat("\r\n ORDER BY att.ISSUE_ID ASC, att.CREATE_DT DESC ");

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static DataTable GetNotesAndAttachments(long issueID)
		{
			StringBuilder sb =  new StringBuilder(@"
			SELECT	'NOTE' AS tab_type, nt.issue_note_id AS tab_id, nt.create_user, nt.create_dt,
					nt.modify_user, nt.modify_dt, nt.issue_id, nt.note_txt AS tab_dsc
			FROM	t_issue_note nt
			WHERE	nt.issue_id = @ISS_IDNT <DEV_CLAUSE>
		UNION ALL
			SELECT	'ATTACHMENT' AS tab_type, att.attachment_id AS tab_id, att.create_user, att.create_dt,
					att.modify_user, att.modify_dt, att.issue_id, att.attachment_nm AS tab_dsc
			FROM	t_attachment att
			WHERE	att.issue_id = @ISS_IDAT
		ORDER BY issue_id asc, create_dt desc ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@ISS_IDNT", issueID));
			p.Add(Connection.GetParameter("@ISS_IDAT", issueID));

			string devFlg = (ClsEnvironment.IsDeveloper) ? null : " AND nt.developer_flg = 'Y' ";
			sb.Replace("<DEV_CLAUSE>", devFlg);

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}
		#endregion		// #region Public Search Methods

		#region Helper Methods

		private static void AppendWhere(StringBuilder sb, List<DbParameter> p, IssueParams options,
			bool parent)
		{
			if( string.IsNullOrEmpty(options.IssueIDs) == false )
				Connection.AppendInClause(sb, p, "AND",
					"iss.ISSUE_ID", "@ISS_ID", options.IssueIDs);
			else if( options.IssueID != null )
				Connection.AppendEqualClause(sb, p, "AND",
					"iss.ISSUE_ID", "@ISS_ID", options.IssueID);
			else if( options.Issue_ID_Fr != null || options.Issue_ID_To != null )
				Connection.AppendRangeClause(sb, p, "AND",
					"iss.ISSUE_ID", "@ISS_FR", "@ISS_TO", options.Issue_ID_Fr, options.Issue_ID_To);

			Connection.AppendLikeClause(sb, p, "AND",
				"upper(iss.ISSUE_DSC)", "@ISS_DSC",
				(options.Issue_Dsc != null ? options.Issue_Dsc.ToUpper() : null));

			Connection.AppendInClause(sb, p, "AND",
				"iss.PROJECT_CD", "@PROJ_CD", ClsConvert.AddQuotes(options.ProjectCds));
			Connection.AppendInClause(sb, p, "AND",
				"iss.CATEGORY_CD", "@CAT_CD", ClsConvert.AddQuotes(options.CategoryCds));
			Connection.AppendInClause(sb, p, "AND",
				"iss.STATUS_CD", "@STATUS_CD", ClsConvert.AddQuotes(options.StatusCds));
			Connection.AppendInClause(sb, p, "AND",
				"iss.CREATE_USER", "@CRE_USR", ClsConvert.AddQuotes(options.Create_User_Logins));
			Connection.AppendInClause(sb, p, "AND",
				"iss.BIZ_OWNER_LOGIN", "@BIZ_USR", ClsConvert.AddQuotes(options.Biz_User_Logins));
			Connection.AppendInClause(sb, p, "AND",
				"iss.IT_OWNER_LOGIN", "@IT_USR", ClsConvert.AddQuotes(options.IT_User_Logins));

			if( string.IsNullOrEmpty(options.Action_Owners) == false )
				sb.AppendFormat("AND ({0}) IN ({1})", SqlComputedOwner,
					ClsConvert.AddQuotes(options.Action_Owners));

			if( string.IsNullOrEmpty(options.PriorityCds) == false )
				sb.AppendFormat("AND ({0}) IN ({1})", SqlComputedPriority,
					ClsConvert.AddQuotes(options.PriorityCds));

			Connection.AppendDateClause(sb, p, "AND",
				"iss.CREATE_DT", "@CRE_FR", "@CRE_TO", options.Create_Dt);
			Connection.AppendDateClause(sb, p, "AND",
				"iss.MODIFY_DT", "@MOD_FR", "@MOD_TO", options.Modify_Dt);
			Connection.AppendDateClause(sb, p, "AND",
				"iss.DUE_DT", "@DUE_FR", "@DUE_TO", options.Due_Dt);

			if( options.PriorityNull != null )
			{
				if( options.PriorityNull == true )
					sb.Append(" AND iss.PRIORITY_NBR IS NULL ");
				else
				{
					if( options.Priority_Nbr_Fr == null && options.Priority_Nbr_To == null )
						sb.Append(" AND iss.PRIORITY_NBR IS NOT NULL ");
					else
						Connection.AppendRangeClause(sb, p, "AND", "iss.PRIORITY_NBR",
							"@PRI_FR", "@PRI_TO", options.Priority_Nbr_Fr, options.Priority_Nbr_To);
				}
			}

			if( parent )
			{
				Connection.AppendDateClause(sb, p, "AND",
					"nt_info.LAST_NOTE_DT", "@NMX_FR", "@NMX_TO", options.Last_Note_Dt);

				Connection.AppendDateClause(sb, p, "AND",
					"att_info.LAST_ATTACH_DT", "@AMX_FR", "@AMX_TO", options.Last_Attach_Dt);

				if( options.OnlyRelatedIssues )
				{
					sb.AppendFormat(@"
					AND
					(
						nvl(iss.category_cd, '{0}') = '{0}' OR nvl(usr.group_cd, '{1}') = '{1}'
					) ", ClsUser.CurrentUser.Def_Category_Cd, ClsUser.CurrentUser.Group_Cd);
				}
			}

			if( options.HasNotes != null )
			{
				sb.AppendFormat("\r\n\t AND nvl(nt_info.note_count, 0) {0} 0",
					(options.HasNotes == true ? ">" : "<="));
			}

			if( options.IncludeClosed.GetValueOrDefault(false) == false )
			{	// Don't exclude closed issues if closed was explicitly specified as a parameter
				if( options.StatusCds == null || !options.StatusCds.Contains("CLOSED") )
					Connection.AppendNotEqualClause(sb, p, "AND",
						"iss.STATUS_CD", "@C_ST", "CLOSED");
			}

			if( options.IncludeOnHold.GetValueOrDefault(false) == false )
			{	// Don't exclude On Hold issues if On Hold was explicitly specified as a parameter
				if( options.StatusCds == null || !options.StatusCds.Contains("HOLD") )
					Connection.AppendNotEqualClause(sb, p, "AND",
						"iss.STATUS_CD", "@C_ST", "HOLD");
			}

			Connection.AppendEqualClause(sb, p, "AND",
				"iss.WIP_FLG", "@REQ_FLG", options.Wip_Flg);
			Connection.AppendEqualClause(sb, p, "AND",
				"iss.DEV_ASSIST_FLG", "@REQ_FLG", options.Dev_Assist_Flg);
			Connection.AppendEqualClause(sb, p, "AND",
				"iss.NEW_REQUIREMENT_FLG", "@REQ_FLG", options.New_Requirement_Flg);
			Connection.AppendEqualClause(sb, p, "AND",
				"iss.EMG_FLG", "@EMG_FLG", options.Emg_Flg);
			Connection.AppendEqualClause(sb, p, "AND",
				"iss.DATA_FIX_FLG", "@DFX_FLG", options.Data_Fix_Flg);
			Connection.AppendEqualClause(sb, p, "AND",
				"iss.RELEASE_FLG", "@RLS_FLG", options.Release_Flg);
		}
		#endregion		// #region Helper Methods

		#region Priority

		private static Dictionary<IssuePriority, string> PriorityList;

		public static ComboItem[] GetPriorities()
		{
			ComboItem[] pri = new ComboItem[PriorityList.Count];
			int index = 0;
			foreach( IssuePriority p in PriorityList.Keys )
			{
				pri[index] = new ComboItem(p.ToString(), PriorityList[p]);
				index++;
				if( index >= pri.Length ) break;
			}
			return pri;
		}
		#endregion		// #region Priority
	}
	#endregion		// #region Static Methods/Properties of ClsIssue

	public enum IssuePriority { NONE, NORMAL, DATA_FIX, EMERGENCY }

	#region Issue Search Parameters

	public class IssueParams
	{
		public long? IssueID;
		public long? Issue_ID_Fr;
		public long? Issue_ID_To;

		public string IssueIDs;
		public string Issue_Dsc;
		public string Keyword;

		public bool? PriorityNull;
		public long? Priority_Nbr_Fr;
		public long? Priority_Nbr_To;

		public string ProjectCds;
		public string CategoryCds;
		public string StatusCds;
		public string PriorityCds;
		public string Tags;

		public string Create_User_Logins;
		public string Biz_User_Logins;
		public string IT_User_Logins;
		public string Action_Owners;

		public string Emg_Flg;
		public string Wip_Flg;
		public string Data_Fix_Flg;
		public string Release_Flg;
		public string Dev_Assist_Flg;
		public string New_Requirement_Flg;

		public string Notes;

		public bool? IncludeClosed;
		public bool? IncludeOnHold;
		public bool? HasNotes;
		public bool OnlyRelatedIssues;

		public DateRange Create_Dt;
		public DateRange Modify_Dt;
		public DateRange Due_Dt;
		public DateRange Last_Note_Dt;
		public DateRange Last_Attach_Dt;

		public void ClearFields()
		{
			IssueID = Issue_ID_Fr = Issue_ID_To = null;
			IssueIDs = Issue_Dsc = null;
			Keyword = null;

			PriorityNull = null;
			Priority_Nbr_Fr = Priority_Nbr_To = null;

			PriorityCds = ProjectCds = CategoryCds = StatusCds = Tags = null;
			Create_User_Logins = Biz_User_Logins = IT_User_Logins = Action_Owners = null;

			New_Requirement_Flg = Dev_Assist_Flg = Wip_Flg =
				Emg_Flg = Data_Fix_Flg = Release_Flg = null;

			Notes = null;
			HasNotes = null;
			IncludeClosed = null;
			IncludeOnHold = null;
			OnlyRelatedIssues = false;

			Create_Dt.Clear();
			Modify_Dt.Clear();
			Due_Dt.Clear();
			Last_Note_Dt.Clear();
			Last_Attach_Dt.Clear();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if( string.IsNullOrEmpty(IssueIDs) == false )
				sb.AppendFormat(" Issue(s): {0}", IssueIDs);
			else if( IssueID != null )
				sb.AppendFormat(" Issue: {0}", IssueID.Value);
			else if( Issue_ID_Fr != null || Issue_ID_To != null )
			{
				if( Issue_ID_Fr != null ) sb.AppendFormat(" From: {0}", Issue_ID_Fr.Value);
				if( Issue_ID_To != null ) sb.AppendFormat(" To: {0}", Issue_ID_To.Value);
			}

			if( string.IsNullOrEmpty(Issue_Dsc) == false )
				sb.AppendFormat(" Desc: {0}", Issue_Dsc);

			if( string.IsNullOrEmpty(Keyword) == false )
				sb.AppendFormat(" Title/Notes: {0}", Keyword);

			if( PriorityNull != null )
			{
				if( PriorityNull == true )
					sb.Append(" Priority NULL ");
				else
				{
					sb.Append(" Priority NOT null ");
					if( Priority_Nbr_Fr != null )
						sb.AppendFormat(" From: {0}", Priority_Nbr_Fr.Value);
					if( Priority_Nbr_To != null )
						sb.AppendFormat(" To: {0}", Priority_Nbr_To.Value);
				}
			}

			if( string.IsNullOrEmpty(ProjectCds) == false )
				sb.AppendFormat(" Project: {0}", ProjectCds);
			if( string.IsNullOrEmpty(CategoryCds) == false )
				sb.AppendFormat(" Category: {0}", CategoryCds);
			if( string.IsNullOrEmpty(StatusCds) == false )
				sb.AppendFormat(" Status: {0}", StatusCds);
			if( string.IsNullOrEmpty(PriorityCds) == false )
				sb.AppendFormat(" Priority: {0}", PriorityCds);
			if( string.IsNullOrEmpty(Tags) == false )
				sb.AppendFormat(" Tags: {0}", Tags);

			if( string.IsNullOrEmpty(Create_User_Logins) == false )
				sb.AppendFormat(" Created by: {0}", Create_User_Logins);
			if( string.IsNullOrEmpty(Biz_User_Logins) == false )
				sb.AppendFormat(" Biz Owner: {0}", Biz_User_Logins);
			if( string.IsNullOrEmpty(IT_User_Logins) == false )
				sb.AppendFormat(" Developer: {0}", IT_User_Logins);
			if( string.IsNullOrEmpty(Action_Owners) == false )
				sb.AppendFormat(" Action Owner: {0}", Action_Owners);

			if( string.IsNullOrEmpty(Emg_Flg) == false )
				sb.AppendFormat(" Emg: {0}", Emg_Flg);
			if( string.IsNullOrEmpty(Data_Fix_Flg) == false )
				sb.AppendFormat(" Data Fix: {0}", Data_Fix_Flg);
			if( string.IsNullOrEmpty(Release_Flg) == false )
				sb.AppendFormat(" Release: {0}", Release_Flg);
			if( string.IsNullOrEmpty(Wip_Flg) == false )
				sb.AppendFormat(" WIP: {0}", Wip_Flg);
			if( string.IsNullOrEmpty(Dev_Assist_Flg) == false )
				sb.AppendFormat(" Dev Assist: {0}", Dev_Assist_Flg);
			if( string.IsNullOrEmpty(New_Requirement_Flg) == false )
				sb.AppendFormat(" New_Req: {0}", New_Requirement_Flg);

			if( string.IsNullOrEmpty(Notes) == false )
				sb.AppendFormat(" Notes: {0}", Notes);

			if( Create_Dt.IsEmpty == false ) sb.AppendFormat(" Created: {0}", Create_Dt);
			if( Modify_Dt.IsEmpty == false ) sb.AppendFormat(" Modified: {0}", Modify_Dt);
			if( Due_Dt.IsEmpty == false ) sb.AppendFormat(" Due: {0}", Due_Dt);

			if( Last_Note_Dt.IsEmpty == false )
				sb.AppendFormat(" Last Note: {0}", Last_Note_Dt);
			if( Last_Attach_Dt.IsEmpty == false )
				sb.AppendFormat(" Last Attachment: {0}", Last_Attach_Dt);


			if( IncludeOnHold.GetValueOrDefault(false) == false )
			{	// Don't exclude On Hold issues if on hold was explicitly specified as a parameter
				if( StatusCds == null || !StatusCds.Contains("HOLD") )
					sb.Append(" Excluding On Hold Issues ");
			}

			if( IncludeClosed.GetValueOrDefault(false) == false )
			{	// Don't exclude closed issues if closed was explicitly specified as a parameter
				if( StatusCds == null || !StatusCds.Contains("CLOSED") )
					sb.Append(" Excluding Closed Issues ");
			}
			return sb.ToString();
		}
	}
	#endregion		// #region Issue Search Parameters
}