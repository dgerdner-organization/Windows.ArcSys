using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmUpdateIssues : frmDialogBase
	{
		#region Fields

		private ReleaseType IssueReleaseType;

		private List<ClsIssue> Issues;
		private ClsProject theProject;
		private ClsIssueNote theNote;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public frmUpdateIssues()
		{
			InitializeComponent();
		}

		private void IssueReleaseFormLoad()
		{
			try
			{
				SetGUI();

				grdIssues.DataSource = Issues;

				BindHelper.Bind(txtNote, theNote, "Note_Txt");
				BindHelper.Bind(txtVersion, theProject, "Next_Version_No");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void SetGUI()
		{
			try
			{
				switch( IssueReleaseType )
				{
					case ReleaseType.None:
						txtVersion.Visible = false;
						cmbProject.Visible = cmbStatus.Visible = true;
						cmbProject.Left = 64;
						cmbStatus.Left = cmbProject.Left + 276;
						lblNote.Text = "&Note\r\n(Optional)";
						break;

					case ReleaseType.Test:
						txtVersion.Visible = true;
						cmbProject.Visible = cmbStatus.Visible = false;
						lblNote.Text = "&Note";
						break;

					case ReleaseType.Production:
						txtVersion.Visible = cmbProject.Visible = cmbStatus.Visible = false;
						lblNote.Text = "&Note";
						break;

					default: break;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Constructors/Initialization

		#region Public Methods

		public bool ReleaseIssues(List<ClsIssue> lst, ReleaseType relType)
		{
			try
			{
				if( lst == null || lst.Count <= 0 ) return Display.ShowError("I-Track", "No issues provided");

				string projectCD = null;
				bool multipeProjects = false, notPending = false, notApproved = false;
				foreach( ClsIssue iss in lst )
				{
					if( string.IsNullOrEmpty(projectCD) )
						projectCD = iss.Project_Cd;
					else
					{
						if( string.Compare(projectCD, iss.Project_Cd, true) != 0 )
							multipeProjects = true;
					}

					if( string.Compare(iss.Status_Cd, StatusCode.Pend.ToString(), true) != 0 )
						notPending = true;
					if( string.Compare(iss.Status_Cd, StatusCode.Approved.ToString(), true) != 0 )
						notApproved = true;
				}

				if( multipeProjects )
					return Display.ShowError("I-Track", "All issues must have the same project");

				theProject = ClsProject.GetUsingKey(projectCD);
				if( theProject == null )
					return Display.ShowError("I-Track", "Project {0} not found", projectCD);

				string note = null;
				IssueReleaseType = relType;
				if( IssueReleaseType == ReleaseType.Test )
				{
					if( notPending )
						return Display.ShowError("I-Track", "All issues must be pending release");
					note = string.Format
						("Released to TEST (Available for Testing), Version: {0}, Date: {1}",
						theProject.Next_Version_No, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
				}
				else if( IssueReleaseType == ReleaseType.Production )
				{
					if( notApproved)
						return Display.ShowError("I-Track", "All issues must be approved for production");
					note = string.Format
						("Released to Production (Closed), Version: {0}, Date: {1}",
						theProject.Next_Version_No, DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
				}
				else
				{
					return Display.ShowError("I-Track", "Release type not provided");
				}

				theNote = new ClsIssueNote();
				theNote.SetDefaults();
				theNote.Version_No = theProject.Next_Version_No;
				theNote.Issue_ID = lst[0].Issue_ID;
				theNote.Note_Txt = note;

				Issues = lst;
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		public bool UpdateIssues(List<ClsIssue> lst)
		{
			try
			{
				if( lst == null || lst.Count <= 0 ) return Display.ShowError("I-Track", "No issues provided");

				string projectCD = null;
				bool multipeProjects = false;
				foreach( ClsIssue iss in lst )
				{
					if( string.IsNullOrEmpty(projectCD) )
						projectCD = iss.Project_Cd;
					else
					{
						if( string.Compare(projectCD, iss.Project_Cd, true) != 0 )
							multipeProjects = true;
					}
				}

				if( multipeProjects )
					return Display.ShowError("I-Track", "All issues must have the same project");

				theProject = ClsProject.GetUsingKey(projectCD);
				if( theProject == null )
					return Display.ShowError("I-Track", "Project {0} not found", projectCD);

				IssueReleaseType = ReleaseType.None;

				theNote = new ClsIssueNote();
				theNote.SetDefaults();
				theNote.Version_No = theProject.Next_Version_No;
				theNote.Issue_ID = lst[0].Issue_ID;
				theNote.Note_Txt = null;

				Issues = lst;
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Overrides

		protected override bool SaveChanges()
		{
			try
			{
				if( Issues == null || Issues.Count <= 0 ) return false;

				if( IssueReleaseType != ReleaseType.None )
				{
					if( theNote.ValidateInsert() == false )
						return Display.ShowError("I-Track", theNote.Error);

					if( theProject.ValidateUpdate() == false )
						return Display.ShowError("I-Track", theProject.Error);

					string statusCd = (IssueReleaseType == ReleaseType.Production)
						? StatusCode.Closed.ToString().ToUpper()
						: StatusCode.Test.ToString().ToUpper();

					ClsIssue.ReleaseIssues(Issues, theProject, theNote, statusCd);
				}
				else
				{
					ClsProject aProject = cmbProject.SelectedProject;
					ClsStatus aStatus = cmbStatus.SelectedStatus;

					if( string.IsNullOrEmpty(theNote.Note_Txt) && aProject == null &&
						aStatus == null ) return Display.ShowError("I-Track", "No changes specified");

					if( !string.IsNullOrEmpty(theNote.Note_Txt) )
						if( theNote.ValidateInsert() == false )
							return Display.ShowError("I-Track", theNote.Error);

					ClsIssue.UpdateIssues(Issues, aProject, aStatus, theNote);
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Overrides

		#region Event Handlers

		private void frmIssueRelease_Load(object sender, EventArgs e)
		{
			IssueReleaseFormLoad();
		}
		#endregion		// #region Event Handlers
	}

	public enum ReleaseType { None, Test, Production }
}