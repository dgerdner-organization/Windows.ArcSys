using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Data.Common;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;
using CS2010.CommonSecurity;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmIssueTracking : frmChildBase
	{
		#region Constants

		private const string Issues = "Issues";
		private const string IssueNotes = "IssueNotes";
		private const string IssueAttachments = "IssueAttachments";

		private const string IssueColumn = "ISSUE_ID";

		#endregion		// #region Constants

		#region Fields/Properties

		private string Project_Cd;
		private bool IsWorking;

		private DataSet dsIssues;
		private frmIssueTrackingOptions SearchOptions;

		private DataTable dtIssues
		{
			get
			{
				return (dsIssues != null && dsIssues.Tables.Contains(Issues)) ?
					dsIssues.Tables[Issues] : null;
			}
		}

		private DataTable dtNotes
		{
			get
			{
				return (dsIssues != null && dsIssues.Tables.Contains(IssueNotes)) ?
					dsIssues.Tables[IssueNotes] : null;
			}
		}

		private DataTable dtAttachments
		{
			get
			{
				return (dsIssues != null && dsIssues.Tables.Contains(IssueAttachments)) ?
					dsIssues.Tables[IssueAttachments] : null;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public frmIssueTracking()
			: base(true)
		{
			InitializeComponent();

			SearchOptions = new frmIssueTrackingOptions();

			WindowHelper.InitAllGrids(this);

			FlagInit();

			FormInit();

			ActionsMenuInit();

			NotificationInit();

			grdIssues.PrintDocument.PrintPage +=
				new System.Drawing.Printing.PrintPageEventHandler(grdIssues_Print_Page);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			tbbOptions.Visible = false;
			grdIssues.RootTable.Columns.Remove("Selector");
			grdIssues.UseGroupRowSelector = false;
		}

		private void FlagInit()
		{
			try
			{
				cnuOptionsITDataFix.Tag = IssueFlag.Data_Fix.ToString();
				cnuOptionsITDevAssist.Tag = IssueFlag.Developer_Assistance.ToString();
				cnuOptionsITEmg.Tag = IssueFlag.Emergency.ToString();
				cnuOptionsITNewReq.Tag = IssueFlag.New_Requirement.ToString();
				cnuOptionsITReleaseFlag.Tag = IssueFlag.Release.ToString();
				cnuOptionsITWip.Tag = IssueFlag.Work_In_Progress.ToString();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void FormInit()
		{
			try
			{
				if( ClsEnvironment.IsDeveloper )
				{
					cnuOptionsN3.Visible = cnuOptionsIT.Visible = true;

					//SetColumnVisible(grdIssues.RootTable, "Emg_Flg");
					//SetColumnVisible(grdIssues.RootTable, "Data_Fix_Flg");
					//SetColumnVisible(grdIssues.RootTable, "Dev_Assist_Flg");
					//SetColumnVisible(grdIssues.RootTable, "Release_Flg");
					//SetColumnVisible(grdIssues.RootTable, "WIP_Flg");
					//SetColumnVisible(grdIssues.RootTable, "New_Requirement_Flg");
					SetColumnVisible(grdIssues.RootTable.ChildTables[0], "Developer_Flg");
					SetColumnVisible(grdIssues.RootTable.ChildTables[0], "Version_No");

					GridEXColumn c = grdIssues.RootTable.Columns["IT_Owner_Login"];
					c.ButtonStyle = ButtonStyle.Ellipsis;

					//ClsITrackConfig.GridOptions.ApplyOptions(grdIssues);
				}
				else
				{
					RemoveColumn("Release_Flg");
					RemoveColumn("Dev_Assist_Flg");
					RemoveColumn("New_Requirement_Flg");
					RemoveColumn("Due_Date_Status");

					grdIssues.RootTable.FormatConditions.Clear();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void SetColumnVisible(GridEXTable table, string column)
		{
			try
			{
				GridEXColumn c = table.Columns[column];
				if (c != null) c.Visible = true;
			}
			catch( Exception ex )
			{
				ClsErrorHandler.LogException(ex);
				Display.ShowError("I-Track", "Internal Error: V");
			}
		}

		private void RemoveColumn(string column)
		{
			try
			{
				grdIssues.RootTable.Columns.Remove(column);
			}
			catch( Exception ex )
			{
				ClsErrorHandler.LogException(ex);
				Display.ShowError("I-Track", "Internal Error: R");
			}
		}

		private void ActionsMenuInit()
		{
			try
			{
				cnuActionsStatusApprove.Tag = StatusCode.Approved.ToString().ToUpper();
				cnuActionsStatusClose.Tag = StatusCode.Closed.ToString().ToUpper();
				cnuActionsStatusDev.Tag = StatusCode.Dev.ToString().ToUpper();
				cnuActionsStatusHold.Tag = StatusCode.Hold.ToString().ToUpper();
				cnuActionsStatusNew.Tag = StatusCode.New.ToString().ToUpper();
				cnuActionsStatusPend.Tag = StatusCode.Pend.ToString().ToUpper();
				cnuActionsStatusSpec.Tag = StatusCode.Spec.ToString().ToUpper();
				cnuActionsStatusTest.Tag = StatusCode.Test.ToString().ToUpper();
				cnuActionsAddAttachment.Tag = "ADDATTACH";
				cnuActionsAddNote.Tag = "ADDNOTE";
				cnuActionsEditIssue.Tag = "EDITISSUE";
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void NotificationInit()
		{
			try
			{
				pnlMain.Panel2Collapsed = true;
				bool showNotifier = ClsITrackConfig.ShowNotifier;
				if( /*ClsEnvironment.IsDeveloper &&*/ showNotifier ) StartNotification();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		#endregion		// #region Constructors/Initialization

		#region Public Method (Main Entry Point)

		/// <summary>Used by the static Search method to ensure that no more than
		/// one of this window is visible at any given time</summary>
		private static frmIssueTracking SearchWindow;

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// of this window is visible at any given time</summary>
		public static frmIssueTracking Search(bool showOptions, bool performDefaultSearch)
		{
			return Search(showOptions, performDefaultSearch, null, null);
		}

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// of this window is visible at any given time</summary>
		public static frmIssueTracking Search(bool showOptions, bool performDefaultSearch,
			string projCd, string projectCaption)
		{
			try
			{
				bool firstShow = (SearchWindow == null);
				if (SearchWindow == null) SearchWindow = new frmIssueTracking();

				WindowHelper.ShowChildWindow(SearchWindow);
				string cap = SearchWindow.Tag as string;
				if (!string.IsNullOrWhiteSpace(cap))
					SearchWindow.Text = cap.Replace("<Project>", projectCaption);

				if (firstShow)
				{
					SearchWindow.Project_Cd = projCd;

					if (showOptions)
						SearchWindow.SearchParameters();
					else if (performDefaultSearch)
						SearchWindow.PerformDefaultSearch(projCd);
				}

				return SearchWindow;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}
		#endregion		// #region Public Method (Main Entry Point)

		#region Search Methods

		private void PerformDefaultSearch(string projCd)
		{
			try
			{
				WindowHelper.SetMainMenuStatus(false);
				/*
				if( ClsEnvironment.IsDeveloper )
				{
					ClsITrackConfig.IssueOptions.ApplyIssueOptions(SearchOptions.Options);
				}
				else
				{
					//SearchOptions.Options.StatusCds = string.Format("{0},{1},{2}",
						//StatusCode.New.ToString().ToUpper(),
						//StatusCode.Spec.ToString().ToUpper(),
						//StatusCode.Test.ToString().ToUpper());
					SearchOptions.Options.OnlyRelatedIssues = ClsITrackConfig.LimitBizDefaultSearch;
				}*/
				SearchOptions.Options.ProjectCds = projCd;

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void tbbSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void SearchParameters()
		{
			try
			{
				if( SearchOptions.GetSearchCriteria() == false ) return;

				PerformSearch();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex.Message);
			}
		}

		private void PerformSearch()
		{
			try
			{
				WindowHelper.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void StartSearch()
		{
			try
			{
				ClsIssueNotifier.Pause();

				DataSet ds = ClsIssue.SearchIssuesDS(SearchOptions.Options);
				lock( grdIssues )
				{
					dsIssues = ds;
				}
			}
			catch( Exception ex )
			{
				if( ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0 )
					Display.ShowError("I-Track", ex);
				else
					Display.ShowError("I-Track", "Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
				ClsIssueNotifier.Resume();
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock( grdIssues )
				{
					grdIssues.DataSource = dsIssues;

					lblParams.Text = string.Format("{0} Issue(s) {1}",
						grdIssues.RecordCount, SearchOptions.Options);
					lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
					pnlTop.Height = lblParams.Height + 10;

					PrintDocumentInit();

					grdIssues.Focus();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				WindowHelper.SetMainMenuStatus(true);
			}
		}

		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				WindowHelper.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock( pnlMain )
				{
					tbbSearch.Enabled = tbbOptions.Enabled = tbbClose.Enabled =
						grdIssues.Enabled = state;
					sbrChild.Visible = sbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					pnlMain.Enabled = state;
					tmrRefresh.Enabled = state;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Print Methods

		private void PrintDocumentInit()
		{
			try
			{
				string title = (string.IsNullOrEmpty(SearchOptions.Options.ProjectCds))
					? "All Projects"
					: string.Format("Project(s): {0}",
					SearchOptions.Options.ProjectCds.Replace("'", null));

				grdIssues.PrintDocument.PageHeaderCenter = title;
				grdIssues.PrintDocument.PageHeaderLeft = DateTime.Now.ToString("dd-MMM-yyyy");
				grdIssues.PrintDocument.PageHeaderFormatStyle.FontSize = 11;
				grdIssues.PrintDocument.PageHeaderFormatStyle.FontBold = TriState.True;

				grdIssues.PrintDocument.HeaderDistance = 45;
				grdIssues.PrintDocument.DefaultPageSettings.Margins = new Margins(60, 60, 60, 60);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void grdIssues_Print_Page(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				grdIssues.PrintDocument.PageHeaderRight =
					string.Format("Page {0} of {1}",
					grdIssues.PrintDocument.Page, grdIssues.PrintDocument.TotalPages);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Print Methods

		#region Attachment Menu

		private void ShowAttachmentMenu()
		{
			try
			{
				DataRow drCurr = grdIssues.GetDataRow();
				if (drCurr == null) return;

				cnuAttachments.Items.Clear();

				List<ClsAttachment> lst = null;
				DataRow[] attRows = drCurr.GetChildRows(IssueAttachments);
				if (attRows != null)
				{
					lst = new List<ClsAttachment>();
					foreach (DataRow drAtt in attRows) lst.Add(new ClsAttachment(drAtt));

					lst.Sort(delegate(ClsAttachment l, ClsAttachment r)
					{	// sort by date descending
						if (l.Create_Dt > r.Create_Dt) return -1;
						if (l.Create_Dt < r.Create_Dt) return 1;
						return 0;
					});

					for (int i = 0; i < lst.Count; i++)
					{
						ClsAttachment att = lst[i];
						string mnuTxt = string.Format("&{0}. {1} (Attachment: {2} {3} {4})",
							i + 1, att.Attachment_Nm, att.Attachment_ID, att.Create_User,
							ClsConfig.FormatDate(att.Create_Dt));
						ToolStripItem ti = cnuAttachments.Items.Add(mnuTxt, null,
							new EventHandler(grdIssues_AttachClick));
						ti.Tag = att.Attachment_ID;
					}
				}

				if (lst != null && lst.Count > 0) cnuAttachments.Items.Add("-");
				ToolStripItem tiAdd = cnuAttachments.Items.Add
					("Click to add an attachment", null, new EventHandler(grdIssues_AttachClick));
				tiAdd.Tag = 0;

				cnuAttachments.Show(MousePosition.X, MousePosition.Y);
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void grdIssues_AttachClick(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ToolStripItem ti = sender as ToolStripItem;
				if( ti == null ) return;

				long? id = ClsConvert.ToInt64Nullable(ti.Tag);
				if( id == null || id < 0 ) return;

				if( id == 0 )		// Add an attachment (when the tag/id is 0)
				{
					AddAttachment();
					return;
				}

				ClsAttachment a = ClsAttachment.GetUsingKey(id.Value);
				if( a == null ) return;

				if( Display.Ask("Save/View", "Save selected file (select no to view it)?") )
				{
					using( FolderBrowserDialog f = new FolderBrowserDialog() )
					{
						string def1 = @"C:\Temp", def2 = @"C:\";
						if( Directory.Exists(def1) )
							f.SelectedPath = def1;
						else if( Directory.Exists(def2) )
							f.SelectedPath = def2;
						f.ShowNewFolderButton = true;
						f.Description = "Select folder where the attachment should be saved";
						f.RootFolder = Environment.SpecialFolder.MyComputer;
						if( f.ShowDialog() != DialogResult.OK ) return;

						string file = Path.Combine(f.SelectedPath, a.Attachment_Nm);
						if( ClsConvert.BlobToFile(file, a.Attachment) == false )
						{
							Display.ShowError("I-Track", "Error saving attachment");
							return;
						}
					}
				}
				else
				{
					string file = Path.Combine(Path.GetTempPath(), a.Attachment_Nm);
					if( ClsConvert.BlobToFile(file, a.Attachment) == false )
					{
						Display.ShowError("I-Track", "Error viewing attachment");
						return;
					}

					ClsConvert.ViewFile(file);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}
		#endregion		// #region Attachment Menu

		#region Actions Menu

		private void ShowActionMenu()
		{
			AssembleActionMenu();
			cnuActions.Show(MousePosition.X, MousePosition.Y);
		}

		private ClsIssue AssembleActionMenu()
		{
			try
			{
				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return null;

				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();

				cnuActionsEditIssue.Visible = true;
				cnuActionsStatusNoAction.Visible = false;

				cnuActionsStatusApprove.Visible = 
					cnuActionsStatusDev.Visible = cnuActionsStatusHold.Visible =
					cnuActionsStatusNew.Visible = cnuActionsStatusPend.Visible =
					cnuActionsStatusSpec.Visible = cnuActionsStatusTest.Visible =
					cnuActionsAddNote.Visible = false;
				cnuActionsStatusApprove.Enabled = 
					cnuActionsStatusDev.Enabled = cnuActionsStatusHold.Enabled =
					cnuActionsStatusNew.Enabled = cnuActionsStatusPend.Enabled =
					cnuActionsStatusSpec.Enabled = cnuActionsStatusTest.Enabled = true;
				cnuActionsEditIssue.Enabled = true;
				cnuActionsStatusClose.Visible = cnuActionsStatusClose.Enabled = true;	// always allow close

				if( issue.IsNew )
				{
					//cnuActionsStatusNoAction.Visible = cnuActionsAddNote.Visible = true;
					cnuActionsAddNote.Visible = true;

					cnuActionsStatusDev.Visible = cnuActionsStatusHold.Visible =
						cnuActionsStatusSpec.Visible = true;

					cnuActionsStatusDev.Enabled = cnuActionsStatusHold.Enabled =
						cnuActionsStatusSpec.Enabled = ClsEnvironment.IsDeveloper;

					cnuActionsStatusDev.Text = "Set status to DEV";
					cnuActionsStatusHold.Text = "Put issue ON HOLD";
					cnuActionsStatusSpec.Text = "Specification";
				}
				else if( issue.IsHold )
				{
					cnuActionsAddNote.Visible = true;

					cnuActionsStatusDev.Visible = cnuActionsStatusSpec.Visible = true;

					cnuActionsStatusDev.Enabled = cnuActionsStatusSpec.Enabled =
						ClsEnvironment.IsDeveloper;

					cnuActionsStatusDev.Text = "Set status to DEV";
					cnuActionsStatusSpec.Text = "Specification";
				}
				else if( issue.IsDev )
				{
					cnuActionsAddNote.Visible = true;

					cnuActionsStatusPend.Visible = cnuActionsStatusSpec.Visible =
						cnuActionsStatusTest.Visible = cnuActionsStatusHold.Visible = true;

					cnuActionsStatusPend.Enabled = cnuActionsStatusSpec.Enabled =
						cnuActionsStatusTest.Enabled = cnuActionsStatusHold.Enabled =
						ClsEnvironment.IsDeveloper;

					cnuActionsStatusPend.Text = "Pending Release to Test";
					cnuActionsStatusSpec.Text = "Specification";
					cnuActionsStatusTest.Text = "Available for Testing (no release required)";
					cnuActionsStatusHold.Text = "Put issue ON HOLD";
				}
				else if( issue.IsPend )
				{
					cnuActionsStatusTest.Visible = true;

					cnuActionsStatusTest.Enabled = ClsEnvironment.IsDeveloper;

					cnuActionsStatusTest.Text = "Available for Testing";
				}
				else if( issue.IsApproved )
				{
					cnuActionsStatusDev.Visible = cnuActionsStatusTest.Visible = true;
					cnuActionsStatusDev.Text = "Testing Failed/Need Assistance - Set status to DEV";
					cnuActionsStatusTest.Text = "Set status back to TEST";
				}
				else if( issue.IsClosed )
				{
					cnuActionsStatusNew.Visible = true;
					cnuActionsEditIssue.Enabled = ClsEnvironment.IsDeveloper;
					cnuActionsStatusNew.Text = "Reopen Issue";
				}
				else if( issue.IsSpec )
				{
					cnuActionsStatusDev.Visible = cnuActionsAddNote.Visible = true;
					cnuActionsStatusDev.Text = "Ready for development - Set status to DEV";
				}
				else if( issue.IsTest )
				{
					cnuActionsStatusDev.Visible = cnuActionsStatusApprove.Visible = true;
					cnuActionsStatusDev.Text = "Testing Failed/Need Assistance - Set status to DEV";
					cnuActionsStatusApprove.Text = "Tested Successfully - Set status to APPROVED (Pending Release to Production)";
				}

				//TODO: jr query for sending email
				//TODO: jr find a way to email table straight from app to avoid export
				// select email issues and record the note sent in the issue, along with
				// recipients, etc.

				//cnuActions.Show(MousePosition.X, MousePosition.Y);
				return issue;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		private void grdIssues_ActionClick(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ToolStripItem ti = sender as ToolStripItem;
				if( ti == null ) return;

				string action = ClsConvert.ToString(ti.Tag);
				if( string.IsNullOrEmpty(action) ) return;

				PerformAction(action.ToUpper());
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void PerformAction(string status)
		{
			try
			{
				if( string.IsNullOrEmpty(status) ) return;

				try
				{
					DataRow dr = GetCurrentIssueDataRow();
					if( dr == null ) return;

					ClsIssueNote nt = null;
					ClsIssue issue = new ClsIssue(dr);
					issue.ReloadFromDB();
					if( string.Compare(status, "EDITISSUE", true) == 0 )
					{
						using( frmEditIssue f = new frmEditIssue() )
						{
							if( f.Edit(issue) == false ) return;
						}
					}
					else if( string.Compare(status, "PRIORITY", true) == 0 )
					{
						using( frmSetPriority f = new frmSetPriority() )
						{
							if( f.SetPriority(issue) == false ) return;
						}
					}
					else if( string.Compare(status, "ADDATTACH", true) == 0 )
					{
						AddAttachment();
					}
					else
					{
						if( string.Compare(status, "ADDNOTE", true) == 0 ) status = issue.Status_Cd;

						using( frmEditNote f = new frmEditNote() )
						{
							nt = f.Add(issue, status);
						}
						if( nt == null ) return;
					}

					RefreshRow(dr);
				}
				catch( Exception ex )
				{
					Display.ShowError("I-Track", ex);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Actions Menu

		#region Menu/Toolbar Event Handlers

		private void cnuOptionsCreate_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ClsIssue newIssue = null;
				using (frmIssueTrackingAdd f = new frmIssueTrackingAdd())
				{
					newIssue = f.CreateIssue(Project_Cd);
				}
				if (newIssue == null) return;

				AddNewRow(newIssue);
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuOptionsEmail_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				SendEmail();
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void SendEmail()
		{
			try
			{
				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();

				StringBuilder sb = new StringBuilder(), sbIDs = new StringBuilder();
				if (lst != null)
				{
					lst.Sort(delegate(ClsIssue l, ClsIssue r)
					{
						if (l.Issue_ID < r.Issue_ID) return -1;
						if (l.Issue_ID > r.Issue_ID) return 1;
						return 0;
					});

					string line = new string('-', 132);
					foreach (ClsIssue iss in lst)
					{
						iss.ReloadFromDB();
						sbIDs.AppendFormat("{0}{1}",
							(sbIDs.Length > 0 ? ", " : null), iss.Issue_ID);
						iss.AssembleNotes("e", true);
						sb.AppendFormat("{0}{1}\r\n{2}\r\n{3}\r\n",
							(sb.Length > 0 ? "\r\n" : null),
							iss.ToString("s"), line, iss.NotesBox);
					}
				}

				string subject = string.Format("ITrack Update {0} ({1})",
					ClsConfig.FormatDate(ClsITrackConfig.SystemDate), sbIDs.ToString());
				ClsEmail em = new ClsEmail(ClsUser.CurrentUser.Email.ToLower(), null,
					subject, sb.ToString());
				// use app.config server em.SMTPServer = "172.16.1.3";
				using (frmEmail f = new frmEmail())
				{
					f.EmailAddresses = ClsUser.GetEmailList();
					f.UpperCaseTextBoxes = false;
					f.ShowEmail(em);
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void AddAttachment()
		{
			try
			{
				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return;

				ClsAttachment att = null;
				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();
				using( OpenFileDialog f = new OpenFileDialog() )
				{
					if( f.ShowDialog() != DialogResult.OK ) return;

					att = issue.AddAttachment(f.FileName);
				}
				if( att == null ) return;

				DataTable dt = dtAttachments;
				if( dt != null )
				{
					DataRow drNew = dt.NewRow();
					att.CopyToDataRow(drNew);
					dt.Rows.Add(drNew);
				}

				RefreshRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void ChangeBizOwner()
		{
			try
			{
				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return;

				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();
				string title = string.Format("Biz Owner: {0}", issue);
				using( frmComboSelect<ucUserCombo> f = new frmComboSelect<ucUserCombo>(title) )
				{
					ucUserCombo cmb = new ucUserCombo();
					f.ComboBox = cmb;

					cmb.Filter = string.Format("USER_LOGIN NOT IN ({0})", ClsUser.GetDevelopers());
					cmb.Value = issue.Biz_Owner_Login;

					if( f.GetSelection() == false ) return;

					issue.Biz_Owner_Login = cmb.SelectedUserLogin;
					issue.Update();
				}

				RefreshRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Menu/Toolbar Event Handlers

		#region IT Menu/Toolbar Actions

		private void cnuOptionsITSequence_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();
				if( lst == null || lst.Count <= 0 ) return;

				frmSetPrioritySequence.SetSequnce(lst);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void ChangePriorityNbr()
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return;

				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();
				string title = string.Format("Issue {0}, Priority: {1}", issue.Issue_ID,
					issue.Priority_Nbr);
				using( frmMemo f = new frmMemo() )
				{
					f.MaxLength = 3;
					f.UpperCase = true;
					if( !f.InputBox(title, null) ) return;

					string s = f.InputText.Trim();
					if( !string.IsNullOrEmpty(s) && !ClsConvert.IsNumeric(s) )
					{
						Display.ShowError("I-Track", "Cannot enter non-numeric characters");
						return;
					}

					short? val = (!string.IsNullOrEmpty(s)) ? ClsConvert.ToInt16Nullable(s) : null;
					if( val != null && (val < 1 || val > 999) )
					{
						Display.ShowError("I-Track", "({0}) Priority must be a value from 1 to 999", val);
						return;
					}

					issue.Priority_Nbr = val;
					issue.Update();
				}

				RefreshRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cnuOptionsClearDeveloper_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ClearDeveloper();
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void ClearDeveloper()
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();
				if( lst == null || lst.Count <= 0 )
				{
					Display.ShowError("I-Track", "No issues checked");
					return;
				}

				foreach( ClsIssue iss in lst ) iss.ReloadFromDB();

				ClsIssue.ClearDeveloper(lst);
				RefreshChecked(true);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cnuOptionsDeveloper_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				BatchChangeDeveloper();
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void BatchChangeDeveloper()
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();
				if( lst == null || lst.Count <= 0 )
				{
					Display.ShowError("I-Track", "No issues checked");
					return;
				}

				foreach( ClsIssue iss in lst ) iss.ReloadFromDB();

				string title = "Change I.T. Owner";
				using( frmComboSelect<ucUserCombo> f = new frmComboSelect<ucUserCombo>(title) )
				{
					ucUserCombo cmb = new ucUserCombo();
					f.ComboBox = cmb;

					cmb.Filter = string.Format("USER_LOGIN IN ({0})", ClsUser.GetITOwners());

					if( f.GetSelection() == false ) return;

					if( !Display.Ask("Confirm", "Clear I.T. owner for all checked issues?") )
						return;

					foreach( ClsIssue iss in lst )
					{
						iss.It_Owner_Login = cmb.SelectedUserLogin;
						iss.Update();
					}
				}

				RefreshChecked(true);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void ChangeDeveloper()
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return;

				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();
				string title = string.Format("I.T. Owner: {0}", issue);
				using( frmComboSelect<ucUserCombo> f = new frmComboSelect<ucUserCombo>(title) )
				{
					ucUserCombo cmb = new ucUserCombo();
					f.ComboBox = cmb;

					cmb.Filter = string.Format("USER_LOGIN IN ({0})", ClsUser.GetITOwners());
					cmb.Value = issue.It_Owner_Login;

					if( f.GetSelection() == false ) return;

					issue.It_Owner_Login = cmb.SelectedUserLogin;
					issue.Update();
				}

				RefreshRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cnuOptionsITFlag_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ToolStripMenuItem mi = sender as ToolStripMenuItem;
				if( mi == null ) return;

				string tg = mi.Tag as string;
				if( string.IsNullOrEmpty(tg) ) return;

				IssueFlag issFlg = (IssueFlag)Enum.Parse(typeof(IssueFlag), tg);
				UpdateFlag(issFlg);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void ToggleFlag(IssueFlag issFlg)
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				DataRow dr = GetCurrentIssueDataRow();
				if( dr == null ) return;

				ClsIssue issue = new ClsIssue(dr);
				issue.ReloadFromDB();

				string ynOld = issue.GetFlag(issFlg);
				string ynNew = (ClsConvert.YNToBool(ynOld)) ? "N" : "Y";

				if( Display.Ask("Confirm", "{0}\r\nChange {1} flag from {2} to {3}?",
					issue, issFlg, ynOld, ynNew) == false ) return;

				issue.ResetErrors();
				if( !issue.CanUpdateFlag(issFlg, ClsConvert.YNToBool(ynNew)) )
				{
					Display.ShowError("I-Track", issue.Error);
					return;
				}

				issue.UpdateFlag(issFlg, ynNew);
				issue.Update();

				RefreshRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void UpdateFlag(IssueFlag issFlg)
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();
				if( lst == null || lst.Count <= 0 )
				{
					Display.ShowError("I-Track", "No issues checked");
					return;
				}

				foreach( ClsIssue iss in lst ) iss.ReloadFromDB();

				string yn = null;
				string title = string.Format("Change {0} Flag", issFlg);
				using( frmComboSelect<ucGenericCombo> f = new frmComboSelect<ucGenericCombo>(title) )
				{
					ucGenericCombo cmb = new ucGenericCombo();
					f.ComboBox = cmb;

					cmb.ComboType = GenericComboType.YesNo;

					if( f.GetSelection() == false ) return;

					yn = cmb.SelectedCD;
				}
				bool newState = ClsConvert.YNToBool(yn);

				StringBuilder sb = new StringBuilder();
				if( ClsIssue.UpdateIssueFlag(lst, issFlg, newState, sb) == false )
				{
					Display.ShowError("I-Track", sb.ToString());
					return;
				}

				RefreshChecked(true);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cnuOptionsITDevNoteFlg_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ToggleDeveloperNoteFlag();
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void ToggleDeveloperNoteFlag()
		{
			try
			{
				DataRow dr = GetCurrentNoteDataRow();
				if( dr == null ) return;

				ClsIssueNote nt = new ClsIssueNote(dr);
				string ynOld = nt.Developer_Flg;
				string ynNew = (ClsConvert.YNToBool(ynOld)) ? "N" : "Y";
				if( Display.Ask("Confirm",
					"Change developer flag on the selected note from {0} to {1}?\r\n\r\n{2}",
					ynOld, ynNew, nt) == false ) return;

				nt.Developer_Flg = ynNew;
				nt.Update();
				nt.CopyToDataRow(dr);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void EditNote()
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				DataRow dr = grdIssues.GetDataRow();
				if( dr == null ) return;

				long? id = (dr.Table.Columns.Contains("Issue_Note_ID"))
					? ClsConvert.ToInt64Nullable(dr["Issue_Note_ID"]) : null;
				ClsIssueNote nt = (id != null) ? ClsIssueNote.GetUsingKey(id.Value) : null;
				if( nt == null ) return;

				//using( frmEditNote f = new frmEditNote() )
				//{
				//    if( !f.Edit(nt) ) return;
				//}
				using( frmMemo f = new frmMemo() )
				{
					f.UpperCase = false;
					string title = string.Format("Edit Note {0}, Issue {1}: {2} - {3}",
						nt.Issue_Note_ID, nt.Issue_ID, nt.Issue.Project_Cd, nt.Issue.Issue_Dsc);
					f.MaxLength = ClsIssueNote.Note_TxtMax;
					int w = (int)(Width * 0.90);
					int h = (int)(Height * 0.90);
					if( !f.AddMemo(title, nt.Note_Txt, w, h) ) return;

					nt.Note_Txt = f.InputText;
					nt.Update();
				}

				dr["Note_Txt"] = nt.Note_Txt;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cnuOptionsReleaseTest_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				UpdateIssues(ReleaseType.Test);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuOptionsReleaseProd_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				UpdateIssues(ReleaseType.Production);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuOptionsUpdateIssues_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				UpdateIssues(ReleaseType.None);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void UpdateIssues(ReleaseType relType)
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return;

				List<ClsIssue> lst = grdIssues.GetCheckedList<ClsIssue>();
				if( lst == null || lst.Count <= 0 )
				{
					Display.ShowError("I-Track", "No issues checked");
					return;
				}

				foreach( ClsIssue iss in lst ) iss.ReloadFromDB();

				using( frmUpdateIssues f = new frmUpdateIssues() )
				{
					if( relType != ReleaseType.None )
					{
						if( f.ReleaseIssues(lst, relType) == false ) return;
					}
					else
					{
						if( f.UpdateIssues(lst) == false ) return;
					}
				}

				RefreshChecked(false);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region IT Menu/Toolbar Actions

		#region Grid Operations/Event Handlers

		public static void AddRow(ClsIssue anIssue)
		{
			try
			{
				if( anIssue == null || anIssue.Issue_ID == null ) return;

				Search(false, false);

				if( SearchWindow.dtIssues != null )
				{	// check if it is already in the grid
					string filt = string.Format("ISSUE_ID = {0}", anIssue.Issue_ID.Value);
					DataRow[] drs = SearchWindow.dtIssues.Select(filt);
					if( drs != null && drs.Length > 0 ) return;
				}

				IssueParams p = new IssueParams();
				p.IssueID = anIssue.Issue_ID;

				DataSet ds = null;
				try
				{
					SearchWindow.UseWaitCursor = true;
					Application.DoEvents();

					ds = ClsIssue.SearchIssuesDS(p);
				}
				finally
				{
					SearchWindow.UseWaitCursor = false;
				}

				if( SearchWindow.dsIssues == null )
					SearchWindow.dsIssues = ds;
				else
					SearchWindow.dsIssues.Merge(ds);

				SearchWindow.UpdateGrid();

				DataTable dt = SearchWindow.dtIssues;
				string selectRow = string.Format("ISSUE_ID = {0}", anIssue.Issue_ID.Value);
				DataRow[] drows = dt.Select(selectRow);
				if( drows != null && drows.Length > 0 )
				{
					GridEXRow gr = SearchWindow.grdIssues.GetRow(drows[0]);
					if( gr != null )
					{
						SearchWindow.grdIssues.EnsureVisible(gr.Position);
						SearchWindow.grdIssues.SelectedItems.Clear();
						SearchWindow.grdIssues.SelectedItems.Add(gr.Position);
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void AddNewRow(ClsIssue anIssue)
		{
			try
			{
				if( anIssue == null || anIssue.Issue_ID == null || dtIssues == null ) return;

				IssueParams p = new IssueParams();
				p.IssueID = anIssue.Issue_ID;

				DataSet ds = null;
				try
				{
					UseWaitCursor = true;
					Application.DoEvents();

					ds = ClsIssue.SearchIssuesDS(p);
				}
				finally
				{
					UseWaitCursor = false;
				}

				if( ds == null || ds.Tables.Count <= 0 ) return;

				// 1st the issue
				DataTable dtNewIssue = ds.Tables[0];
				if( dtNewIssue.Rows.Count <= 0 ) return;

				DataRow drNewIssue = dtNewIssue.Rows[0];
				dtIssues.LoadDataRow(drNewIssue.ItemArray, true);

				// Then the note
				if( dtNotes == null || ds.Tables.Count <= 1 ) return;

				DataTable dtNewNote = ds.Tables[1];
				if( dtNewNote.Rows.Count <= 0 ) return;

				DataRow drNewNote = dtNewNote.Rows[0];
				dtNotes.LoadDataRow(drNewNote.ItemArray, true);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private static void AddRows(List<ClsIssue> issueLst)
		{
			try
			{
				ClsIssueNotifier.Pause();

				if( issueLst == null || issueLst.Count <= 0 ) return;

				Search(false, false);

				StringBuilder sb = new StringBuilder();
				foreach( ClsIssue iss in issueLst )
				{
					if( iss.Issue_ID == null ) continue;
					if( SearchWindow.dtIssues != null )
					{
						string filt = string.Format("ISSUE_ID = {0}", iss.Issue_ID.Value);
						DataRow[] drs = SearchWindow.dtIssues.Select(filt);
						if( drs != null && drs.Length > 0 ) continue;
					}

					sb.AppendFormat("{0}{1}", (sb.Length > 0 ? ", " : null), iss.Issue_ID.Value);
				}
				if( sb.Length <= 0 ) return;

				IssueParams p = new IssueParams();
				p.IssueIDs = sb.ToString();

				DataSet ds = null;
				try
				{
					SearchWindow.UseWaitCursor = true;
					Application.DoEvents();

					ds = ClsIssue.SearchIssuesDS(p);
				}
				finally
				{
					SearchWindow.UseWaitCursor = false;
				}

				if( SearchWindow.dsIssues == null )
					SearchWindow.dsIssues = ds;
				else
					SearchWindow.dsIssues.Merge(ds);

				SearchWindow.UpdateGrid();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				ClsIssueNotifier.Resume();
			}
		}

		private void cnuOptionsRefresh_Click(object sender, EventArgs e)
		{
			RefreshAll();
		}

		private static void RefreshAll()
		{
			try
			{
				Search(false, false);

				DataTable dt = (SearchWindow != null) ? SearchWindow.dtIssues : null;
				if( dt == null || dt.Rows.Count <= 0 ) return;

				SearchWindow.UseWaitCursor = true;
				Application.DoEvents();

				StringBuilder sbIDs = new StringBuilder();
				foreach( DataRow dr in dt.Rows )
				{
					long? id = ClsConvert.ToInt64Nullable(dr[IssueColumn]);
					if( id.GetValueOrDefault(0) > 0 )
						sbIDs.AppendFormat("{0}{1}", sbIDs.Length > 0 ? ", " : null, id.Value);
				}
				if( sbIDs.Length <= 0 ) return;

				IssueParams p = new IssueParams();
				p.IssueIDs = sbIDs.ToString();
				p.IncludeClosed = true;
				p.IncludeOnHold = true;
				DataSet ds = ClsIssue.SearchIssuesDS(p);

				SearchWindow.dsIssues = ds;
				SearchWindow.UpdateGrid();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				if( SearchWindow != null ) SearchWindow.UseWaitCursor = false;
			}
		}

		private void RefreshRow(DataRow dr)
		{
			try
			{
				IssueParams p = new IssueParams();
				p.IssueID = ClsConvert.ToInt64Nullable(dr[IssueColumn]);
				p.IncludeClosed = true;
				p.IncludeOnHold = true;

				DataSet ds = ClsIssue.SearchIssuesDS(p);
				if( ds != null )
				{
					if( ds.Tables.Contains(Issues) && ds.Tables[Issues].Rows.Count == 1 )
						dr.ItemArray = ds.Tables[Issues].Rows[0].ItemArray;

					if( ds.Tables.Contains(IssueNotes) && ds.Tables[IssueNotes].Rows.Count > 0 )
					{
						string sel = string.Format("ISSUE_ID = {0}", p.IssueID);
						DataRow[] oldRows = dr.GetChildRows(IssueNotes);

						DataRow[] newRows = ds.Tables[IssueNotes].Select(sel);
						if( oldRows != null )
						{
							for( int i = oldRows.Length - 1; i >= 0; i-- )
								oldRows[i].Delete();

							DataTable dtOld = dtNotes;
							foreach( DataRow drNew in newRows )
								dtOld.Rows.Add(drNew.ItemArray);
						}
					}
				}

				grdIssues.RootTable.ChildTables[0].SortKeys["CREATE_DT"].SortOrder =
					Janus.Windows.GridEX.SortOrder.Descending;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		public static void RefreshCheckedRows(bool clearAllChecked)
		{
			try
			{
				if( SearchWindow != null ) SearchWindow.RefreshChecked(clearAllChecked);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		public void RefreshChecked(bool clearAllChecked)
		{
			try
			{
				DataRow[] rows = grdIssues.GetCheckedDataRows();
				if( rows == null || rows.Length <= 0 ) return;

				SearchWindow.UseWaitCursor = true;
				Application.DoEvents();

				StringBuilder sbIDs = new StringBuilder();
				Dictionary<long, DataRow> checkedRows = new Dictionary<long, DataRow>();
				foreach( DataRow dr in rows )
				{
					long? id = ClsConvert.ToInt64Nullable(dr[IssueColumn]);
					if( id.GetValueOrDefault(0) > 0 )
					{
						sbIDs.AppendFormat("{0}{1}", sbIDs.Length > 0 ? ", " : null, id.Value);
						checkedRows.Add(id.Value, dr);
					}
				}
				if( sbIDs.Length <= 0 ) return;

				if( rows.Length > 50 || sbIDs.Length > 512 )
				{
					RefreshAll();
					return;
				}

				IssueParams p = new IssueParams();
				p.IssueIDs = sbIDs.ToString();
				p.IncludeClosed = true;
				p.IncludeOnHold = true;

				DataSet ds = ClsIssue.SearchIssuesDS(p);
				DataTable dt =
					(ds != null && ds.Tables.Contains(Issues)) ? ds.Tables[Issues] : null;
				if( dt == null || dt.Rows.Count <= 0 ) return;

				foreach( DataRow newDR in dt.Rows )
				{
					long? id = ClsConvert.ToInt64Nullable(newDR[IssueColumn]);
					if( id == null ) continue;

					DataRow oldDR =
						(checkedRows.ContainsKey(id.Value)) ? checkedRows[id.Value] : null;
					if( oldDR != null ) oldDR.ItemArray = newDR.ItemArray;
				}

				if( clearAllChecked ) grdIssues.UnCheckAllRecords();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				if( SearchWindow != null ) SearchWindow.UseWaitCursor = false;
			}
		}

		private DataRow GetCurrentIssueDataRow()
		{
			try
			{
				DataRow dr = grdIssues.GetDataRow();
				if( dr == null ) return null;

				if( string.Compare(dr.Table.TableName, Issues, true) == 0 ) return dr;

				// If on a child row, get the parent
				string relName = dr.Table.TableName;
				return (dsIssues.Relations.Contains(relName)) ? dr.GetParentRow(relName) : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		private DataRow GetCurrentNoteDataRow()
		{
			try
			{
				DataRow dr = grdIssues.GetDataRow();
				if( dr == null || string.Compare(dr.Table.TableName, IssueNotes, true) != 0 )
					return null;

				return dr;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		private void grdIssues_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				IsWorking = true;

				if( string.Compare(e.Column.Key, "Attach_Count", true) == 0 )
					ShowAttachmentMenu();
				else if( string.Compare(e.Column.Key, "IT_Owner_Login", true) == 0 )
					ChangeDeveloper();
				else if( string.Compare(e.Column.Key, "Biz_Owner_Login", true) == 0 )
					ChangeBizOwner();
				else if( string.Compare(e.Column.Key, "Priority_Nbr", true) == 0 )
					ChangePriorityNbr();
				else if( string.Compare(e.Column.Key, "New_Requirement_Flg", true) == 0 )
					ToggleFlag(IssueFlag.New_Requirement);
				else if( string.Compare(e.Column.Key, "Dev_Assist_Flg", true) == 0 )
					ToggleFlag(IssueFlag.Developer_Assistance);
				else if( string.Compare(e.Column.Key, "WIP_Flg", true) == 0 )
					ToggleFlag(IssueFlag.Work_In_Progress);
				else if( string.Compare(e.Column.Key, "Release_Flg", true) == 0 )
					ToggleFlag(IssueFlag.Release);
				else if( string.Compare(e.Column.Key, "Data_Fix_Flg", true) == 0 )
					ToggleFlag(IssueFlag.Data_Fix);
				else if( string.Compare(e.Column.Key, "Emg_Flg", true) == 0 )
					ToggleFlag(IssueFlag.Emergency);
				else if( string.Compare(e.Column.Key, "Status_Cd", true) == 0 ||
					string.Compare(e.Column.Key, "Status_Dsc", true) == 0 )
					ShowActionMenu();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void grdIssues_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				GridArea ga = grdIssues.HitTest();
				if( ga != GridArea.Cell ) return;

				GridEXColumn col = grdIssues.ColumnFromPoint();
				if( col == null )
				{
					ShowActionMenu();
					return;
				}

				if( ClsEnvironment.IsDeveloper )
				{
					if( string.Compare(col.Key, "Priority_Nbr", true) == 0 )
						ChangePriorityNbr();
					else if( string.Compare(col.Key, "New_Requirement_Flg", true) == 0 )
						ToggleFlag(IssueFlag.New_Requirement);
					else if( string.Compare(col.Key, "Dev_Assist_FLg", true) == 0 )
						ToggleFlag(IssueFlag.Developer_Assistance);
					else if( string.Compare(col.Key, "WIP_Flg", true) == 0 )
						ToggleFlag(IssueFlag.Work_In_Progress);
					else if( string.Compare(col.Key, "Release_Flg", true) == 0 )
						ToggleFlag(IssueFlag.Release);
					else if( string.Compare(col.Key, "Data_Fix_FLg", true) == 0 )
						ToggleFlag(IssueFlag.Data_Fix);
					else if( string.Compare(col.Key, "Emg_Flg", true) == 0 )
						ToggleFlag(IssueFlag.Emergency);
					else if( string.Compare(col.Key, "IT_Owner_Login", true) == 0 )
						ChangeDeveloper();
					else if( string.Compare(col.Key, "Note_Txt", true) == 0 )
						EditNote();
					else
						ShowActionMenu();
				}
				else
				{
					ShowActionMenu();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void grdIssues_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				IsWorking = true;

				if( e.KeyCode == Keys.Enter )
				{
					e.Handled = true;
					//AddNote();
					ShowActionMenu();
				}
				else if( e.KeyCode == Keys.C && e.Control )
				{
					GridEXRow r = grdIssues.GetRow();
					GridEXColumn c = grdIssues.CurrentColumn;
					if( r == null || c == null || string.IsNullOrEmpty(c.DataMember) ) return;

					string s = ClsConvert.ToString(r.Cells[c].Text);
					if( !string.IsNullOrEmpty(s) ) Clipboard.SetText(s);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void grdIssues_LoadingRow(object sender, RowLoadEventArgs e)
		{
			try
			{
				//DataRowView drv = e.Row.DataRow as DataRowView;
				//if( drv != null && drv.Row.Table.Columns.Contains("Issue_Dsc") )
				//{
				//    string dsc = ClsConvert.ToString(drv["Issue_Dsc"]);
				//    if( dsc != null && dsc.Length > 40 )
				//        e.Row.Cells["Issue_Dsc"].ToolTipText = dsc;
				//}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmIssueTracking_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if( e.CloseReason == CloseReason.WindowsShutDown ) return;

				if( IsRunning )
				{
					e.Cancel = true;
					Display.Show("I-Track", "Cancel the search before closing the window");
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void frmIssueTracking_FormClosed(object sender, FormClosedEventArgs e)
		{
			SearchWindow = null;
			ClsIssueNotifier.DisposeTimer();
		}

		private void pnlTop_Resize(object sender, EventArgs e)
		{
			try
			{
				lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
				pnlTop.Height = lblParams.Height + 10;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Form Event Handlers

		#region Issue Notification Methods

		private void StartNotification()
		{
			try
			{
				//if( !ClsEnvironment.IsDeveloper ) return;

				ClsIssueNotifier.ShowNotificationArea = ClsIssueNotifier.CheckForNewIssues =
					ClsIssueNotifier.CheckForModifiedIssues = true;

				ClsIssueNotifier.CreateTimer(NotificationCallback, ErrorCallback);

				pnlMain.Panel2Collapsed = false;
				cnuOptionsShowNew.Checked = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void NotificationCallback(object state)
		{
			try
			{
				BeginInvoke(new MethodInvoker(UpdateNotification));
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void ErrorCallback(object state)
		{
			try
			{
				Delegate d = new TimerCallback(ErrorNotification);
				BeginInvoke(d, new object[] { state });
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void ErrorNotification(object state)
		{
			try
			{
				EndNotification();

				Exception exs = state as Exception;
				Display.ShowError("I-Track",
					"Disabling notification: error checking for new/updated issues\r\n{0}",
					(exs != null ? exs.Message : null));
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void UpdateNotification()
		{
			try
			{
				if( ClsIssueNotifier.ShowNotificationArea && !pnlMain.Panel2Collapsed )
					UpdateNotificationGrid();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void EndNotification()
		{
			try
			{
				ClsIssueNotifier.DisposeTimer();
				ClsIssueNotifier.ShowNotificationArea = ClsIssueNotifier.CheckForNewIssues =
					ClsIssueNotifier.CheckForModifiedIssues = false;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				pnlMain.Panel2Collapsed = true;
			}
		}

		private void ViewNotificationIssue()
		{
			try
			{
				ClsIssue iss = grdNew.GetCurrentItem<ClsIssue>();
				if( iss == null ) return;

				using( frmViewIssue f = new frmViewIssue() )
				{
					if( f.ViewIssue(iss) == false ) return;

					if( f.MoveIssue ) AddNewRow(iss);
					if( f.MoveIssue || f.DismissIssue ) ClsIssueNotifier.AllNewIssues.Remove(iss);
					UpdateNotificationGrid();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void UpdateNotificationGrid()
		{
			try
			{
				lock( grdNew )
				{
					grdNew.DataSource = null;
					grdNew.DataSource = ClsIssueNotifier.AllNewIssues;
					grdNew.RootTable.TableHeader = InheritableBoolean.True;
					grdNew.RootTable.Caption =
						string.Format("{0} Issues (Created/Modified since {1})",
						grdNew.RecordCount,
						ClsIssueNotifier.LastCheck.Value.ToString("MM/dd hh:mm:ss.fff"));
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void tbbShowNew_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				if (tbbShowNew.Checked)
					StartNotification();
				else
					EndNotification();
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuOptionsShowNew_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				if( cnuOptionsShowNew.Checked )
					StartNotification();
				else
					EndNotification();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuNewClear_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				ClsIssueNotifier.ClearIssues();
				UpdateNotificationGrid();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void cnuNewMove_Click(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				if( grdNew.SelectedItems == null ) return;

				List<ClsIssue> lst = new List<ClsIssue>();
				foreach( GridEXSelectedItem item in grdNew.SelectedItems )
				{
					if( item.RowType != RowType.Record ) continue;

					GridEXRow r = item.GetRow();
					ClsIssue iss = r.DataRow as ClsIssue;
					if( iss != null ) lst.Add(iss);
				}
				if( lst == null || lst.Count <= 0 ) return;

				ClsIssueNotifier.RemoveIssues(lst);

				UpdateNotificationGrid();

				AddRows(lst);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void grdNew_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				GridArea ga = grdNew.HitTest();
				if( ga != GridArea.Cell ) return;

				ViewNotificationIssue();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void grdNew_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				IsWorking = true;

				if( e.KeyCode != Keys.Enter ) return;

				e.Handled = true;
				ViewNotificationIssue();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}
		#endregion		// #region Issue Notification Methods

		private void grdIssues_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				IsWorking = true;

				DataRow dr = GetCurrentIssueDataRow();
				ClsIssue iss = (dr != null) ? new ClsIssue(dr) : null;
				tbbSingleIssueOptions.Text = (iss != null)
					? string.Format("Edit Issue {0}", iss.Issue_ID, iss.Issue_Dsc)
					: "Click an issue to enable editing";
				tbbSingleIssueOptions.Enabled = (iss != null);
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsWorking = false;
			}
		}

		private void tbbSingleIssueOptions_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				AssembleActionMenu();
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void tmrRefresh_Tick(object sender, EventArgs e)
		{
			try
			{
				if (IsRunning || IsWorking || ClsConMgr.Manager["ITrack"].IsOpen )
					return;
				PerformSearch();
			}
			catch (Exception ex)
			{
				Display.ShowError("I-Track", ex);
			}
		}
	}
}