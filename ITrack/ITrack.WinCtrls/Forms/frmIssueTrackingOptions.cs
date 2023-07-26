using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmIssueTrackingOptions : frmDialogBase
	{
		#region Fields

		private bool FirstLoad;
		private IssueParams _Options;

		#endregion		// #region Fields

		#region Properties

		public IssueParams Options { get { return _Options; } }

		#endregion		// #region Properties

		#region Constructors

		public frmIssueTrackingOptions()
		{
			InitializeComponent();

			_Options = new IssueParams();

			FirstLoad = true;
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool GetSearchCriteria()
		{
			try
			{
				SetGUI();

				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private void SetGUI()
		{
			try
			{
				bool isDev = ClsEnvironment.IsDeveloper;
				/*Height = (isDev) ? 494 : 442;

				grpLastAttachDt.Visible = grpLastNoteDt.Visible = isDev;*/
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void OptionsFormLoad()
		{
			try
			{
				string itowners = ClsUser.GetITOwners();
				string developers = ClsUser.GetDevelopers();
				cmbBizUser.Filter = string.Format("USER_LOGIN NOT IN ({0})", developers);
				cmbITUser.Filter = string.Format("USER_LOGIN IN ({0})", itowners);

				if( FirstLoad )
				{
					FirstLoad = false;

					cmbStatus.Text = _Options.StatusCds;
					cmbProject.Text = _Options.ProjectCds;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override bool SaveChanges()
		{
			try
			{
				_Options.ClearFields();

				_Options.IssueIDs = txtMultipleIssues.Text.Trim();
				if( string.IsNullOrEmpty(_Options.IssueIDs) && chkIssueRange.Checked )
				{
					if( numFromIssue.Value != null )
						_Options.Issue_ID_Fr = ClsConvert.ToInt64Nullable(numFromIssue.Value);
					if( numToIssue.Value != null )
						_Options.Issue_ID_To = ClsConvert.ToInt64Nullable(numToIssue.Value);
				}

				_Options.ProjectCds = cmbProject.ProjectCDs;
				_Options.StatusCds = cmbStatus.StatusCDs;

				_Options.Biz_User_Logins = cmbBizUser.UserLogins;
				_Options.IT_User_Logins = cmbITUser.UserLogins;
				_Options.Create_User_Logins = cmbCreator.UserLogins;

				_Options.Issue_Dsc = txtIssueTitle.Text.Trim();
				_Options.Notes = txtIssueNotes.Text.Trim();

				_Options.Create_Dt = grpCreated.CheckedValueRange;
				_Options.Modify_Dt = grpModified.CheckedValueRange;
				_Options.Last_Note_Dt = grpLastNoteDt.CheckedValueRange;
				_Options.Last_Attach_Dt = grpLastAttachDt.CheckedValueRange;

				VerifyClosedCheckbox();
				_Options.IncludeClosed = chkIncludeClosed.Checked;
				_Options.IncludeOnHold = chkIncludeHold.Checked;

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private bool VerifyClosedCheckbox()
		{
			try
			{
				string status = cmbStatus.StatusCDs;
				if( !string.IsNullOrEmpty(status) && status.Contains("CLOSED") )
				{
					chkIncludeClosed.Checked = true;
					return true;
				}
				return false;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private bool VerifyHoldCheckbox()
		{
			try
			{
				string status = cmbStatus.StatusCDs;
				if( !string.IsNullOrEmpty(status) && status.Contains("HOLD") )
				{
					chkIncludeHold.Checked = true;
					return true;
				}
				return false;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		#endregion		// #region Overrides

		#region Event Handlers

		private void frmIssueTrackingOptions_Load(object sender, EventArgs e)
		{
			OptionsFormLoad();
		}

		private void frmIssueTrackingOptions_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.Control && e.KeyCode == Keys.D ) btnClear.PerformClick();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				WindowHelper.ClearAllControls(this);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void chkIssueRange_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				numFromIssue.Enabled = numToIssue.Enabled = txtMultipleIssues.ReadOnly =
					chkIssueRange.Checked;
				if( txtMultipleIssues.ReadOnly )
					txtMultipleIssues.Text = null;
				else
					numFromIssue.Value = numToIssue.Value = null;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void txtMultipleIssues_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if( !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != ',' &&
					e.KeyChar != '\b' ) e.Handled = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cmbStatus_Validated(object sender, EventArgs e)
		{
			VerifyClosedCheckbox();
		}

		private void chkIncludeClosed_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( chkIncludeClosed.Checked ) return;

				if( VerifyClosedCheckbox() )
					Display.ShowError("I-Track",
						"CLOSED is specified as a status, this checkbox must remain checked");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void chkIncludeHold_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( chkIncludeHold.Checked ) return;

				if( VerifyHoldCheckbox() )
					Display.ShowError("I-Track",
						"ON HOLD is specified as a status, this checkbox must remain checked");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}

		}

		#endregion		// #region Event Handlers

	}
}