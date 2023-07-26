using System;
using System.IO;
using System.Data;
using System.Text;
using System.Threading;
using System.Data.Common;
using System.Configuration;
using System.Collections.Generic;
using CS2010.Common;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public static class ClsIssueNotifier
	{
		#region Connection Manager

		public static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrackNotifier"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields

		private static int _msTimerInterval;

		private static DateTime? _LastCheck;
		private static List<ClsIssue> _AllNewIssues;
		private static List<ClsIssue> _CurrentNewIssues;

		private static bool _CheckForNewIssues;
		private static bool _CheckForModifiedIssues;

		private static bool _ShowNotificationArea;
		private static bool _ShowNotificationWindow;

		private static AutoResetEvent _MainEventSignal;

		private static Timer NotificationTimer;

		#endregion		// #region Fields

		#region Properties

		private static event TimerCallback EndNotification;
		private static event TimerCallback ErrorNotification;

		public static AutoResetEvent MainEventSignal { get { return _MainEventSignal; } }

		public static List<ClsIssue> AllNewIssues { get { return _AllNewIssues; } }

		public static int TimerInterval
		{
			get { return _msTimerInterval; } set { _msTimerInterval = value; }
		}

		public static DateTime? LastCheck
		{
			get { return _LastCheck; } set { _LastCheck = value; }
		}

		public static bool CheckForNewIssues
		{
			get { return _CheckForNewIssues; } set { _CheckForNewIssues = value; }
		}

		public static bool CheckForModifiedIssues
		{
			get { return _CheckForModifiedIssues; } set { _CheckForModifiedIssues = value; }
		}

		public static bool ShowNotificationArea
		{
			get { return _ShowNotificationArea; } set { _ShowNotificationArea = value; }
		}

		public static bool ShowNotificationWindow
		{
			get { return _ShowNotificationWindow; } set { _ShowNotificationWindow = value; }
		}

		public static bool CanPerformCheck
		{
			get { return CheckForModifiedIssues || CheckForNewIssues; }
		}
		#endregion		// #region Properties

		#region Constructors

		static ClsIssueNotifier()
		{
			_LastCheck = null;

			_CurrentNewIssues = null;
			_AllNewIssues = new List<ClsIssue>();

			_CheckForModifiedIssues = _CheckForNewIssues = false;
			_ShowNotificationArea = _ShowNotificationWindow = false;

			if (!ClsConMgr.Manager.ContainsKey("ITrackNotifier"))
			{
				ConnectionStringSettings cns =
					ConfigurationManager.ConnectionStrings[ClsEnvironment.ConnectionStringName];
				ClsConMgr.Manager.AddConnection("ITrackNotifier", cns.ProviderName,
					cns.ConnectionString, ClsEnvironment.UserName, ClsEnvironment.Password, null);
			}

			LoadUserNotificationOptions();
		}

		private static void LoadUserNotificationOptions()
		{
			if( ClsEnvironment.IsDeveloper )
			{
				_msTimerInterval = 10 * 1000;			// 10 second default
			}
			else
			{
				_msTimerInterval = 5 * 60 * 1000;
			}
		}
		#endregion		// #region Constructors

		#region Public Issue Methods

		public static void ClearIssues()
		{
			if( AllNewIssues == null || AllNewIssues.Count <= 0 ) return;

			lock( AllNewIssues )
			{
				AllNewIssues.Clear();
			}
		}

		public static List<ClsIssue> CopyIssues()
		{
			if( AllNewIssues == null ) return new List<ClsIssue>();

			List<ClsIssue> lst = null;
			lock( AllNewIssues )
			{
				lst = new List<ClsIssue>(AllNewIssues);
			}
			return lst;
		}

		public static void RemoveIssues(List<ClsIssue> issueLst)
		{
			if( AllNewIssues == null || AllNewIssues.Count <= 0 ||
				issueLst == null || issueLst.Count <= 0 ) return;

			lock( AllNewIssues )
			{
				AllNewIssues.RemoveAll(delegate(ClsIssue delIssue)
				{
					return issueLst.Exists(delegate(ClsIssue specIssue)
					{ return specIssue.Issue_ID == delIssue.Issue_ID; }); ;
				});
			}
		}

		public static List<ClsIssue> GetNewIssues()
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	iss.*, ");
			sb.AppendFormat(@"{0} AS ACTION_OWNER ", ClsIssue.SqlComputedOwner);
			sb.Append(@"
			FROM	T_ISSUE iss
			WHERE	(
						(
							USER IN ('JROMAN', 'DGERDNER', 'JDORNEY') AND
							NVL(iss.it_owner_login, USER) = USER
						)
						OR
						(
							USER NOT IN ('JROMAN', 'DGERDNER', 'JDORNEY') AND
							iss.BIZ_OWNER_LOGIN = USER
						)
					)
			AND		(
						(
							iss.CREATE_DT >= @CRE_ISS_DT OR
							iss.MODIFY_DT >= @MOD_ISS_DT
						)
						OR EXISTS
						(
							SELECT	'X'
							FROM	t_issue_note nt
							WHERE	nt.issue_id = iss.issue_id
							AND		(
										nt.create_dt >= @CRE_NT_DT OR
										nt.modify_dt >= @MOD_NT_DT
									)
						)
						OR EXISTS
						(
							SELECT	'X'
							FROM	t_attachment att
							WHERE	att.issue_id = iss.issue_id
							AND		(
										att.create_dt >= @CRE_ATT_DT OR
										att.modify_dt >= @MOD_ATT_DT
									)
						)
					) ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@CRE_ISS_DT", LastCheck.Value));
			p.Add(Connection.GetParameter("@MOD_ISS_DT", LastCheck.Value));
			p.Add(Connection.GetParameter("@CRE_NT_DT", LastCheck.Value));
			p.Add(Connection.GetParameter("@MOD_NT_DT", LastCheck.Value));
			p.Add(Connection.GetParameter("@CRE_ATT_DT", LastCheck.Value));
			p.Add(Connection.GetParameter("@MOD_ATT_DT", LastCheck.Value));

			List<ClsIssue> lst = Connection.GetList<ClsIssue>(sb.ToString(), p.ToArray());
			return lst;
		}

		public static void AddNewIssues()
		{
			List<ClsIssue> lst = GetNewIssues();

			lock( AllNewIssues )
			{
				_CurrentNewIssues = lst;
				if( lst == null || lst.Count < 1 ) return;

				DateTime? latestDt = null;
				foreach( ClsIssue iss in lst )
				{
					ClsIssue existingIssue = _AllNewIssues.Find(delegate(ClsIssue ni)
					{ return ni.Issue_ID == iss.Issue_ID; });
					if( existingIssue == null )
						_AllNewIssues.Add(iss);
					else
					{
						existingIssue.CopyFrom(iss);
						existingIssue.LoadActionOwner();
					}

					if( latestDt == null || iss.Modify_Dt > latestDt ) latestDt = iss.Modify_Dt;
				}
				if( latestDt != null && latestDt > LastCheck )
					LastCheck = latestDt.Value.AddMilliseconds(1);
			}
		}
		#endregion		// #region Public Issue Methods

		#region Public Timer Methods

		public static void Pause()
		{
			if( NotificationTimer != null )
				_MainEventSignal = new AutoResetEvent(false);
		}

		public static void Resume()
		{
			if( NotificationTimer == null ) return;

			if( _MainEventSignal != null )
			{
				_MainEventSignal.Set();
				_MainEventSignal.Close();
				_MainEventSignal = null;
			}
		}

		public static void CreateTimer(TimerCallback method, TimerCallback errMethod)
		{
			if( NotificationTimer != null ) return;

			TimerCallback tmrCB = new TimerCallback(HandleNotification);
			NotificationTimer = new Timer(tmrCB, null, Timeout.Infinite, Timeout.Infinite);

			EndNotification = method;
			ErrorNotification = errMethod;

			DateTime stamp = Connection.GetSystemDate();
			ClsIssueNotifier.LastCheck = stamp.AddSeconds(-30);

			StartTimer();
		}

		public static void DisposeTimer()
		{
			if( NotificationTimer == null ) return;

			SuspendTimer();
			NotificationTimer.Dispose();
			NotificationTimer = null;
		}
		#endregion		// #region Public Timer Methods

		#region Timer Helper Methods

		private static void StartTimer()
		{
			if( NotificationTimer != null )
				NotificationTimer.Change(TimerInterval, TimerInterval);
		}

		private static void SuspendTimer()
		{
			if( NotificationTimer != null )
				NotificationTimer.Change(Timeout.Infinite, Timeout.Infinite);
		}

		private static void HandleNotification(object state)
		{
			if( NotificationTimer == null ) return;

			try
			{
				lock( AllNewIssues )
				{
					SuspendTimer();

					if( !CanPerformCheck )
					{
						NotificationTimer.Dispose();
						NotificationTimer = null;
					}
				}

				if( _MainEventSignal != null )
				{
					MainEventSignal.WaitOne();
				}

				lock( AllNewIssues )
				{
					AddNewIssues();
					if( EndNotification != null ) EndNotification(state);
				}
			}
			catch( Exception ex )
			{
				state = ex;
				if( ErrorNotification != null ) ErrorNotification(state);
			}
			finally
			{
				StartTimer();
			}
		}
		#endregion		// #region Timer Helper Methods
	}
}