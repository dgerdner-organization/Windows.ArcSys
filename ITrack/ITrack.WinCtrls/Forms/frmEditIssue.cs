using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmEditIssue : frmDialogBase
	{
		#region Fields

		private ClsIssue theIssue;

		#endregion		// #region Fields

		#region Internal Properties

		private string NoteTxt { get { return txtNote.Text.Trim(); } }

		#endregion		// #region Internal Properties

		#region Constructors

		public frmEditIssue()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public ClsIssue Add()
		{
			try
			{
				theIssue = new ClsIssue();
				theIssue.SetDefaults();

				CurrentMode = DialogMode.Add;
				SetGUI();
				return (ShowDialog() == DialogResult.OK) ? theIssue : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		public bool Edit(ClsIssue anIssue)
		{
			try
			{
				theIssue = new ClsIssue(anIssue);

				CurrentMode = DialogMode.Edit;
				SetGUI();
				if( ShowDialog() != DialogResult.OK ) return false;

				anIssue.CopyFrom(theIssue);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void IssueFormLoad()
		{
			try
			{
				SetBinding();

				Text = (CurrentMode == DialogMode.Add)
					? "Add Issue" : string.Format("{0}", theIssue);

				AdjustHeight();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void SetBinding()
		{
			try
			{
				string developers = ClsUser.GetDevelopers();
				string itOwners = ClsUser.GetITOwners();
				cmbBizOwner.Filter = string.Format("USER_LOGIN NOT IN ({0})", developers);
				cmbDeveloper.Filter = string.Format("USER_LOGIN IN ({0})", itOwners);

				BindHelper.Bind(cmbProject, theIssue, "Project_Cd");
				BindHelper.Bind(cmbCategory, theIssue, "Category_Cd");
				BindHelper.Bind(cmbBizOwner, theIssue, "Biz_Owner_Login");
				BindHelper.Bind(txtIssueDesc, theIssue, "Issue_Dsc");
				BindHelper.Bind(dteDue, theIssue, "Due_Dt");
				BindHelper.Bind(dteRequest, theIssue, "Request_By_Dt");

				BindHelper.Bind(cmbStatus, theIssue, "Status_Cd");
				BindHelper.Bind(cmbDeveloper, theIssue, "It_Owner_Login");
				BindHelper.Bind(numPriority, theIssue, "Priority_Nbr");
				BindHelper.Bind(chkNewReq, theIssue, "New_Requirement_Flg");
				BindHelper.Bind(chkDevAssist, theIssue, "Dev_Assist_Flg");
				BindHelper.Bind(chkWIP, theIssue, "Wip_Flg");
				BindHelper.Bind(chkEmg, theIssue, "Emg_Flg");
				BindHelper.Bind(chkFix, theIssue, "Data_Fix_Flg");
				BindHelper.Bind(chkRelease, theIssue, "Release_Flg");
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				if( cmbBizOwner.NotInList ) cmbBizOwner.Text = null;
			}
		}

		private void SetGUI()
		{
			try
			{
				if( ClsEnvironment.IsDeveloper )
				{
					pnlBottom.Visible = true;
					pnlBottom.Panel1Collapsed = false;
					MinimumSize = new System.Drawing.Size(610, 400);
					ControlBox = true;
					FormBorderStyle = FormBorderStyle.Sizable;
				}
				else
				{
					cmbProject.ReadOnly = (CurrentMode != DialogMode.Add);
					pnlBottom.Visible = (CurrentMode == DialogMode.Add);
					pnlBottom.Panel1Collapsed = true;
					if( pnlBottom.Visible )
					{
						MinimumSize = new System.Drawing.Size(610, 400);
						ControlBox = true;
						FormBorderStyle = FormBorderStyle.Sizable;
					}
					else
					{
						MinimumSize = new System.Drawing.Size(610, 164);
						ControlBox = false;
						FormBorderStyle = FormBorderStyle.FixedDialog;
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
			finally
			{
				txtIssueDesc.MaxLength = ClsIssue.Issue_DscMax;
			}
		}

		private void AdjustHeight()
		{
			try
			{
				Height = (pnlBottom.Visible) ? 560 : 164;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void AttemptSendEmail()
		{
			try
			{
				string txt = NoteTxt;
				string csTo = txtTo.Text.Trim();
				if( !chkEmail.Checked || string.IsNullOrEmpty(csTo) ||
					string.IsNullOrEmpty(txt) ) return;

				string subject = string.Format("ITrack Update {0} Issue {1}: {2}",
					ClsConfig.FormatDate(ClsITrackConfig.SystemDate), theIssue.Issue_ID,
					theIssue.Issue_Dsc);
				ClsEmail em = new ClsEmail(ClsUser.CurrentUser.Email.ToLower(), csTo,
					subject, txt);
				// use app.config server em.SMTPServer = "172.16.1.3";
				em.SendMail();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
				bool ok = (CurrentMode == DialogMode.Add)
					? theIssue.ValidateInsert() : theIssue.ValidateUpdate();

				if( !ok ) return Display.ShowError("I-Track", theIssue.Error);

				string csTo = txtTo.Text.Trim();
				if( chkEmail.Checked )
				{
					if( string.IsNullOrEmpty(csTo) )
						return Display.ShowError("I-Track", "No email address(es) provided");
					if( !Contact.ValidateEmailList(csTo) )
						return Display.ShowError("I-Track", Contact.Error);
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		/// <summary>Method called when the OK buttons is clicked and the form passes
		/// validation. In add mode an issue and a note will be inserted (and the note is
		/// required), in edit mode the issue will be updated, but the note is optional and
		/// will only be inserted if it is not blank</summary>
		/// <returns>True all changes were saved to the DB, false if errors</returns>
		protected override bool SaveChanges()
		{
			try
			{
				string txt = NoteTxt;
				if( CurrentMode == DialogMode.Add )
				{
					if( string.IsNullOrEmpty(txt) )
						return Display.ShowError("I-Track", "Please provide the first issue note");

					theIssue.AddNewIssue(txt);

					AttemptSendEmail();
				}
				else
				{
					if( string.IsNullOrEmpty(txt) )
					{	// No note just update the issue
						theIssue.Update();
					}
					else
					{
						theIssue.UpdateIssue(txt);

						AttemptSendEmail();
					}
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

		private void frmEditIssue_Load(object sender, EventArgs e)
		{
			IssueFormLoad();
		}

		private void chkEmail_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				lblTo.Visible = txtTo.Visible = chkEmail.Checked;
				//AdjustHeight();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void lbl_MouseHover(object sender, EventArgs e)
		{
			try
			{
				ucLabel lbl = sender as ucLabel;
				if( lbl == null ) return;

				lbl.BorderStyle = BorderStyle.Fixed3D;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void lbl_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				ucLabel lbl = sender as ucLabel;
				if( lbl == null ) return;

				lbl.BorderStyle = BorderStyle.None;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void lblTo_Click(object sender, EventArgs e)
		{
			try
			{
				using( frmEmailList f = new frmEmailList() )
				{
					f.AvailableAddresses = ClsUser.GetEmailList();
					f.CommaSeparatedAddresses = txtTo.Text.Trim();

					if( f.ShowList() ) txtTo.Text = f.CommaSeparatedAddresses;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Event Handlers
	}
}