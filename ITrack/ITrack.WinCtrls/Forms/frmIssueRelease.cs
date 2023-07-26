using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmIssueRelease : frmDialogBase
	{
		#region Fields

		private List<ClsIssue> Issues;
		private ClsProject theProject;
		private ClsIssueNote theNote;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public frmIssueRelease()
		{
			InitializeComponent();
		}

		private void IssueReleaseFormLoad()
		{
			try
			{
				grdIssues.DataSource = Issues;

				BindHelper.Bind(txtNote, theNote, "Note_Txt");
				BindHelper.Bind(txtVersion, theProject, "Next_Version_No");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Constructors/Initialization

		#region Public Methods

		public bool ReleaseIssues(List<ClsIssue> lst)
		{
			try
			{
				if( lst == null || lst.Count <= 0 ) return Display.ShowError("I-Track", "No issues provided");

				string projectCD = null;
				bool multipeProjects = false, notPending = false;
				foreach( ClsIssue iss in lst )
				{
					if( string.IsNullOrEmpty(projectCD) )
						projectCD = iss.Project_Cd;
					else
					{
						if( string.Compare(projectCD, iss.Project_Cd, true) != 0 )
							multipeProjects = true;
					}

					if( string.Compare(iss.Status_Cd, "PEND", true) != 0 )
						notPending = true;
				}

				if( multipeProjects )
					return Display.ShowError("I-Track", "All issues must have the same project");
				if( notPending )
					return Display.ShowError("I-Track", "All issues must be pending release");

				theProject = ClsProject.GetUsingKey(projectCD);
				if( theProject == null )
					return Display.ShowError("I-Track", "Project {0} not found", projectCD);

				theNote = new ClsIssueNote();
				theNote.SetDefaults();
				theNote.Version_No = theProject.Next_Version_No;
				theNote.Issue_ID = lst[0].Issue_ID;
				theNote.Note_Txt = "AVAILABLE FOR TESTING";

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

				if( theNote.ValidateInsert() == false )
					return Display.ShowError("I-Track", theNote.Error);
				if( theProject.ValidateUpdate() == false )
					return Display.ShowError("I-Track", theProject.Error);

				ClsIssue.ReleaseIssues(Issues, theProject, theNote, "TEST");

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
}