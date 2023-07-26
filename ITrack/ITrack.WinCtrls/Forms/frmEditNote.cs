using System;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmEditNote : frmDialogBase
	{
		#region Fields

		private bool SelectStatus;
		private ClsIssue theIssue;
		private ClsIssueNote theNote;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public frmEditNote()
		{
			InitializeComponent();

			AdjustLayout();
		}

		private void AdjustLayout()
		{
			try
			{
				btnOK.Top = btnCancel.Top = (chkEmail.Checked) ? txtTo.Top + 30 : txtTo.Top;
				Height = btnOK.Top + btnOK.Height + 48;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Tracl", ex);
			}
		}
		#endregion		// #region Constructors/Initialization

		#region Public Methods

		public ClsIssueNote Add(ClsIssue anIssue)
		{
			try
			{
				theIssue = new ClsIssue(anIssue);

				theNote = new ClsIssueNote();
				theNote.SetDefaults(theIssue);

				SelectStatus = true;

				CurrentMode = DialogMode.Add;
				if( ShowDialog() != DialogResult.OK ) return null;

				anIssue.CopyFrom(theIssue);
				return theNote;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		public ClsIssueNote Add(ClsIssue anIssue, string status)
		{
			try
			{
				theIssue = new ClsIssue(anIssue);

				theNote = new ClsIssueNote();
				theNote.SetDefaults(theIssue);

				SelectStatus = false;
				theIssue.Status_Cd = status;

				CurrentMode = DialogMode.Add;
				if( ShowDialog() != DialogResult.OK ) return null;

				anIssue.CopyFrom(theIssue);
				return theNote;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		public bool Edit(ClsIssueNote aNote)
		{
			try
			{
				if( !ClsEnvironment.IsDeveloper ) return false;

				theNote = new ClsIssueNote(aNote);
				theNote.ReloadFromDB();
				theIssue = theNote.Issue;

				SelectStatus = false;
				CurrentMode = DialogMode.Edit;
				if( ShowDialog() != DialogResult.OK ) return false;

				aNote.CopyFrom(theNote);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void NoteFormLoad()
		{
			try
			{
				BindHelper.Bind(txtDesc, theIssue, "Issue_Dsc");
				BindHelper.Bind(cmbStatus, theIssue, "Status_Cd");
				BindHelper.Bind(txtNote, theNote, "Note_Txt");
				BindHelper.Bind(chkDeveloper, theNote, "Developer_Flg");

				Text = string.Format("{0} Note Issue {1} - {2}", CurrentMode, theIssue.Issue_ID,
					(theIssue.Category != null ?
					theIssue.Category.Category_Nm : theIssue.Category_Cd));

				chkDeveloper.Visible = ClsEnvironment.IsDeveloper;
				cmbStatus.ReadOnly = !SelectStatus;
				chkEmail.Visible = (CurrentMode == DialogMode.Add);

				MinimumSize = new System.Drawing.Size(380, 364);
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
				string csTo = txtTo.Text.Trim();
				string devTo = ClsITrackConfig.DevDistributionList;

				// Send to user specified list if send box is checked and textbox is not blank
				bool usrSend = chkEmail.Checked && !string.IsNullOrEmpty(csTo);

				// Send to dev if user is not a developer and the config value is true and
				// the dev email list is not blank
				bool devSend = !ClsEnvironment.IsDeveloper && ClsITrackConfig.EmailDevNote &&
					!string.IsNullOrEmpty(devTo);

				// Neither one qualified, return without sending
				if( usrSend == false && devSend == false ) return;

				StringBuilder sbTo = new StringBuilder();
				if( usrSend )
				{
					sbTo.Append(csTo);

					if( devSend )
					{
						string[] emails = devTo.Split(',');
						if( emails != null && emails.Length > 0 )
						{
							foreach( string s in emails )
							{
								string e = ( s != null ) ? s.Trim() : null;
								if( string.IsNullOrEmpty(e) ) continue;

								if( csTo.IndexOf(e) < 0 )
									sbTo.AppendFormat("{0}{1}",
										(sbTo.Length > 0 ? ", " : null), e);
							}
						}
					}
				}
				else if( devSend )
					sbTo.Append(devTo);

				if( sbTo.Length <= 0 ) return;

				string subject = string.Format("ITrack Update {0} ({1}: {2})",
					ClsConfig.FormatDate(ClsITrackConfig.SystemDate), theIssue.Issue_ID,
					theIssue.Issue_Dsc);

				ClsEmail em = new ClsEmail(ClsUser.CurrentUser.Email.ToLower(), sbTo.ToString(),
					subject, theNote.Note_Txt);
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
				if( CurrentMode == DialogMode.Add )
				{
					string statusCd = cmbStatus.SelectedStatusCD;
					if( string.IsNullOrEmpty(statusCd) )
						return Display.ShowError("I-Track", "Missing status");

					if( theIssue.ValidateUpdate() == false )
						return Display.ShowError("I-Track", theIssue.Error);

					bool ok = (CurrentMode == DialogMode.Add)
						? theNote.ValidateInsert() : theNote.ValidateUpdate();
					if( !ok ) return Display.ShowError("I-Track", theNote.Error);

					string csTo = txtTo.Text.Trim();
					if( chkEmail.Checked )
					{
						if( string.IsNullOrEmpty(csTo) )
							return Display.ShowError("I-Track", "No email address(es) provided");
						if( !Contact.ValidateEmailList(csTo) )
							return Display.ShowError("I-Track", Contact.Error);
					}
				}
				else
				{
					if( !theNote.ValidateUpdate() )
						return Display.ShowError("I-Track", theNote.Error);
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}

		protected override bool SaveChanges()
		{
			try
			{
				if( CurrentMode == DialogMode.Add )
				{
					theNote.AddNote(theIssue);
					AttemptSendEmail();
				}
				else
				{
					theNote.Update();
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

		private void frmEditNote_Load(object sender, EventArgs e)
		{
			NoteFormLoad();
		}

		private void chkEmail_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				lblTo.Visible = txtTo.Visible = chkEmail.Checked;
				AdjustLayout();
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