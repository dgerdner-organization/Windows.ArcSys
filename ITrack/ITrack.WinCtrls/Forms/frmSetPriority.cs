using System;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmSetPriority : frmDialogBase
	{
		#region Fields/Properties

		private bool IsLoadingForm;
		private bool ProcessingAdjustment;

		private ClsIssue theIssue;
		private ClsIssue HoldIssue;

		private bool HasPriorityChanged
		{
			get
			{
				return (HoldIssue.Data_Fix_Flg != theIssue.Data_Fix_Flg ||
					HoldIssue.Emg_Flg != theIssue.Emg_Flg ||
					HoldIssue.Request_By_Dt != theIssue.Request_By_Dt ||
					HoldIssue.Due_Dt != theIssue.Due_Dt);
			}
		}

		private string OldRequestDate
		{
			get
			{
				return (HoldIssue.Request_By_Dt != null)
					? ClsConfig.FormatDate(HoldIssue.Request_By_Dt) : "<none>";
			}
		}

		private string OldDueDate
		{
			get
			{
				return (HoldIssue.Due_Dt != null)
					? ClsConfig.FormatDate(HoldIssue.Due_Dt) : "<none>";
			}
		}

		private string NewRequestDate
		{
			get
			{
				return (theIssue.Request_By_Dt != null)
					? ClsConfig.FormatDate(theIssue.Request_By_Dt) : "<none>";
			}
		}

		private string NewDueDate
		{
			get
			{
				return (theIssue.Due_Dt != null)
					? ClsConfig.FormatDate(theIssue.Due_Dt) : "<none>";
			}
		}

		private string PriorityNote
		{
			get
			{
				return string.Format
					("Priority values changed from\r\nEmg: {0}, Fix: {1}, Requested: {2}, Due: {3}\r\nto\r\nEmg: {4}, Fix: {5}, Requested: {6}, Due: {7}",
					HoldIssue.Emg_Flg, HoldIssue.Data_Fix_Flg, OldRequestDate, OldDueDate,
					theIssue.Emg_Flg, theIssue.Data_Fix_Flg, NewRequestDate, NewDueDate);
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Entry Points/Initialization

		public frmSetPriority()
		{
			InitializeComponent();

			InitLabels();
		}

		private void InitLabels()
		{
			try
			{
				chkDataFix.Tag = chkEmergency.Tag = lblFlags.Text;
				dteRequest.Tag = lblReq.Text;
				cmbReleaseDue.Tag = lblRel.Text;
				dteDue.Tag = lblDue.Text;
				txtPriority.Tag = lblPriority.Text;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		public bool SetPriority(ClsIssue anIssue)
		{
			try
			{
				theIssue = (anIssue != null) ? new ClsIssue(anIssue) : null;
				if( theIssue == null ) return false;

				HoldIssue = anIssue;
				theIssue.ReloadFromDB();

				chkEmergency.Enabled = ClsConvert.YNToBool(ClsUser.CurrentUser.Admin_Flg);

				if( ShowDialog() != DialogResult.OK ) return false;

				anIssue.CopyFrom(theIssue);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private void frmSetPriority_Load(object sender, EventArgs e)
		{
			try
			{
				IsLoadingForm = true;

				chkDataFix.Checked = ClsConvert.YNToBool(theIssue.Data_Fix_Flg);
				chkEmergency.Checked = ClsConvert.YNToBool(theIssue.Emg_Flg);
				dteDue.Value = theIssue.Due_Dt;
				dteRequest.Value = theIssue.Request_By_Dt;

				if( theIssue.Due_Dt == null )
				{
					cmbReleaseDue.Text = null;
					cmbReleaseDue.Value = null;
				}
				else
				{
					cmbReleaseDue.Text = theIssue.Due_Dt.Value.ToString("MMMM yyyy");
					if( HoldIssue.Due_Dt != null &&
						(cmbReleaseDue.Value == null || theIssue.Due_Dt == null) )
					{
						Display.ShowError("I-Track", "Current due date {0} is not valid and will be removed",
							ClsConfig.FormatDate(HoldIssue.Due_Dt));
					}
				}

				Text = string.Format("{0} {1}: {2}", Tag, theIssue.Issue_ID, theIssue.Issue_Dsc);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				IsLoadingForm = false;
				AdjustWindow();
			}
		}
		#endregion		// #region Constructors/Entry Points/Initialization

		#region Helper Methods

		private void AdjustWindow()
		{
			try
			{
				if( IsLoadingForm || ProcessingAdjustment ) return;

				ProcessingAdjustment = true;

				if( chkDataFix.Checked || chkEmergency.Checked )
				{
					dteRequest.Enabled = cmbReleaseDue.Enabled = false;
					cmbReleaseDue.Text = null;
					dteRequest.Value = null;
					dteDue.Value = null;
				}
				else
				{
					dteRequest.Enabled = cmbReleaseDue.Enabled = true;
				}

				theIssue.Data_Fix_Flg = ClsConvert.BoolToYN(chkDataFix.Checked);
				theIssue.Emg_Flg = ClsConvert.BoolToYN(chkEmergency.Checked);
				theIssue.Due_Dt = cmbReleaseDue.SelectedDate;
				theIssue.Request_By_Dt = dteRequest.Value;

				IssuePriority p = theIssue.ComputePriority();
				string pdsc = theIssue.ComputePriorityDsc();

				dteDue.Value = theIssue.Due_Dt;
				txtPriority.Text = string.Format("{0} - {1}", p, pdsc);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				ProcessingAdjustment = false;
			}
		}

		protected override bool SaveChanges()
		{
			try
			{
				if( dteDue.Value != null )
				{
					DateTime sel = dteDue.Value.Value;
					DateTime now = ClsITrackConfig.SystemDate;
					TimeSpan ts = sel - now;
					if( ts.Days < 7 )
						return Display.ShowError("I-Track", "Cannot specify a release less than a week away");
				}

				if( cmbReleaseDue.NotInList )
					return Display.ShowError("I-Track", "Due date {0} is not valid",
						ClsConfig.FormatDate(HoldIssue.Due_Dt));

				if( theIssue.Request_By_Dt != null && theIssue.Due_Dt == null )
					return Display.ShowError("I-Track", "A release month must be specified when the request date is provided");

				if( theIssue.Request_By_Dt != null && theIssue.Due_Dt != null &&
					theIssue.Request_By_Dt > theIssue.Due_Dt )
					return Display.ShowError("I-Track", "Release date cannot be earlier than the request date");

				ClsEmail em = new ClsEmail();
				if( !HandleEmail(em) ) return false;

				theIssue.Update();

				AddPriorityNote();

				AttemptSendEmail(em);

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private void AddPriorityNote()
		{
			try
			{	// Add a note only if something changed
				if( HasPriorityChanged == false ) return;

				ClsIssueNote nt = new ClsIssueNote();
				nt.SetDefaults();
				nt.Issue_ID = theIssue.Issue_ID;
				nt.Developer_Flg = "Y";
				if( theIssue.Project != null ) nt.Version_No = theIssue.Project.Next_Version_No;
				nt.Note_Txt = PriorityNote;
				nt.Insert();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private bool HandleEmail(ClsEmail em)
		{
			try
			{	// only assemble email if priority has changed
				if( HasPriorityChanged == false ) return true;

				string notes = theIssue.NotesBox;
				string line = new string('-', 132);

				em.From = ClsUser.CurrentUser.Email.ToLower();
				// use app.config server em.SMTPServer = "172.16.1.3";

				StringBuilder sbBody = new StringBuilder();
				if( !chkEmergency.Checked )
				{	// not emergency, only assemble email if config value is set to true
					if( ClsITrackConfig.EmailDevPriority )
					{
						em.To = ClsITrackConfig.DevDistributionList;
						em.Subject = string.Format("ITrack Priority Change - Issue {0}: {1}",
							theIssue.Issue_ID, theIssue.Issue_Dsc);

						StringBuilder sb = new StringBuilder();
						sb.AppendFormat("{0} Issue {1}: {2}\r\n\r\n{3}", theIssue.Project_Cd,
							theIssue.Issue_ID, theIssue.Issue_Dsc, PriorityNote);
						em.Body = sb.ToString();
					}
				}
				else
				{
					if( HoldIssue.Emg_Flg != theIssue.Emg_Flg )
					{
						em.To = ClsITrackConfig.EmgDistributionList.ToLower();
						if( !em.To.Contains(ClsUser.CurrentUser.Email.ToLower()) )
							em.CC = ClsUser.CurrentUser.Email.ToLower();
						em.Subject = string.Format("ITrack Emergency Issue Updated {0}: {1}",
							theIssue.Issue_ID, theIssue.Issue_Dsc);

						StringBuilder sb = new StringBuilder(ClsIssue.EmgEmailIntro);
						sb.AppendFormat
							("\r\n\r\n{0} {1}: (see description below)\r\n{2}\r\n{3}\r\n",
							theIssue.Project_Cd,
							(theIssue.Category != null ? theIssue.Category.Category_Nm : theIssue.Category_Cd),
							line, notes);

						em.Body = sb.ToString();

						using( frmEmail f = new frmEmail() )
						{
							f.EmailAddresses = ClsUser.GetEmailList();
							f.UpperCaseTextBoxes = false;
							if( !f.ShowEmail(em, true, true) ) return false;
						}
					}
				}
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		private void AttemptSendEmail(ClsEmail em)
		{
			try
			{	// only send email if priority has changed
				if( HasPriorityChanged == false ) return;

				if( !ClsEnvironment.IsDeveloper )
				{
					if( chkEmergency.Checked )
					{	// only send if the flag changed
						if( HoldIssue.Emg_Flg != theIssue.Emg_Flg ) em.SendMail();
					}
					else
					{	// not emergency, only send email if config value is set to true
						if( ClsITrackConfig.EmailDevPriority ) em.SendMail();
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void chkFix_CheckedChanged(object sender, EventArgs e)
		{
			AdjustWindow();
		}

		private void Control_Enter(object sender, EventArgs e)
		{
			try
			{
				Control c = sender as Control;
				lblInfo.Text = (c != null) ? c.Tag as string : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void chkEmg_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( chkEmergency.Checked && !ClsConvert.YNToBool(HoldIssue.Emg_Flg) )
				{// If the issue was not already marked as emergency
					if( !Display.Ask("Confirm Emergency", ClsIssue.EmgWarningQuestion) )
						chkEmergency.Checked = false;
				}

				AdjustWindow();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void dteRequest_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if( dteRequest.Value == null ) return;

				DateTime reqDt = dteRequest.Value.Value.Date;
				DateTime dtNow = ClsITrackConfig.SystemDate.Date;
				if( reqDt < dtNow )
				{
					e.Cancel = true;
					Display.ShowError("I-Track", "Cannot specify a value earlier than today");
					return;
				}

				bool ret = cmbReleaseDue.ValidateReleaseDate(reqDt);
				if( ret == false )
				{
					e.Cancel = true;
					Display.ShowError("I-Track", "Request date is out of range");
					return;
				}
			}
			catch( Exception ex )
			{
				e.Cancel = true;
				Display.ShowError("I-Track", ex);
			}
		}

		private void dteRequest_Validated(object sender, EventArgs e)
		{
			try
			{
				theIssue.Request_By_Dt = dteRequest.Value;
				// Do not attempt to change the release date if setting request date to null
				if( theIssue.Request_By_Dt == null ) return;

				// Do not attempt to change release date if one already exists (Due_Dt != null) and
				// if that due date is still valid (request date is less than or equal to due date)
				if( theIssue.Due_Dt != null && theIssue.Request_By_Dt <= theIssue.Due_Dt ) return;

				if( cmbReleaseDue.SetReleaseDate(theIssue.Request_By_Dt) == false ) return;

				if( cmbReleaseDue.SelectedDate != null )
				{
					DateTime reqDt = theIssue.Request_By_Dt.Value.Date;
					DateTime release = cmbReleaseDue.SelectedDate.Value.Date;
					if( reqDt < release )
						Display.Show("I-Track",
							"Note:\r\nAlthough the request date is {0},\r\nthe earliest date of release is {1}",
							reqDt.ToString("MMMM dd, yyyy"), release.ToString("MMMM dd, yyyy"));
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void cmbReleaseDue_ValueChanged(object sender, EventArgs e)
		{
			AdjustWindow();
		}

		private void cmbReleaseDue_Validated(object sender, EventArgs e)
		{
			AdjustWindow();
		}
		#endregion		// #region Event Handlers
	}
}
