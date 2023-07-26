using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
    public partial class frmEmail : Form
    {
		#region Fields

		private List<string> _EmailAddresses;

		private ClsEmail theEmail;

		private bool _SaveEmailButDoNotSend;

		#endregion		// #region Fields

		#region Properties

		public bool UpperCaseTextBoxes
		{
			get { return txtBody.CharacterCasing == CharacterCasing.Upper; }
			set
			{
				CharacterCasing cc = value ? CharacterCasing.Upper : CharacterCasing.Normal;
				txtBody.CharacterCasing = txtCC.CharacterCasing = txtTo.CharacterCasing =
					txtSubject.CharacterCasing = cc;
			}
		}

		public List<string> EmailAddresses
		{
			get { return _EmailAddresses; }
			set { _EmailAddresses = value; }
		}

		public bool DisableToField
		{
			get { return txtTo.ReadOnly; }
			set
			{
				txtTo.ReadOnly = value;
				lblTo.Enabled = !txtTo.ReadOnly;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		public frmEmail()
		{
			InitializeComponent();

			_SaveEmailButDoNotSend = false;
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool ShowEmail(ClsEmail anEmail)
		{
			try
			{
				theEmail = new ClsEmail(anEmail);

				if( string.IsNullOrEmpty(theEmail.SMTPServer) )
					theEmail.SMTPServer = ClsEmail.UnrestrictedSMTPServer;
				if( ShowDialog() != DialogResult.OK ) return false;

				anEmail.CopyFrom(theEmail);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Email Error", ex);
			}
		}

		public bool ShowEmail(ClsEmail anEmail, bool saveDoNotSend, bool disableTo)
		{
			try
			{
				theEmail = new ClsEmail(anEmail);

				if( string.IsNullOrEmpty(theEmail.SMTPServer) )
					theEmail.SMTPServer = ClsEmail.UnrestrictedSMTPServer;

				_SaveEmailButDoNotSend = saveDoNotSend;
				DisableToField = disableTo;
				if( ShowDialog() != DialogResult.OK ) return false;

				anEmail.CopyFrom(theEmail);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Email Error", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void EmailFormLoad()
		{
			try
			{
				BindHelper.Bind(txtTo, theEmail, "To");
				BindHelper.Bind(txtCC, theEmail, "CC");
				BindHelper.Bind(txtSubject, theEmail, "Subject");
				BindHelper.Bind(txtBody, theEmail, "Body");

				StringBuilder sb = new StringBuilder();
				foreach( string s in theEmail.Attachments )
					sb.AppendFormat("{0} ", Path.GetFileName(s));
				txtAttachments.Text = sb.ToString();

				if( !string.IsNullOrEmpty(theEmail.From) ) Text = "Email from " + theEmail.From;
			}
			catch( Exception ex )
			{
				Display.ShowError("Email", ex);
			}
		}

		private void GetTo()
		{
			try
			{
				using( frmEmailList f = new frmEmailList() )
				{
					f.AvailableAddresses = _EmailAddresses;
					f.CommaSeparatedAddresses = txtTo.Text.Trim();

					if( f.ShowList() ) txtTo.Text = f.CommaSeparatedAddresses;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Email", ex);
			}
		}

		private void GetCC()
		{
			try
			{
				using( frmEmailList f = new frmEmailList() )
				{
					f.AvailableAddresses = _EmailAddresses;
					f.CommaSeparatedAddresses = txtCC.Text.Trim();

					if( f.ShowList() ) txtCC.Text = f.CommaSeparatedAddresses;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Email", ex);
			}
		}

		private void GetAttachment()
		{
			try
			{
				using( OpenFileDialog dlg = new OpenFileDialog() )
				{
					if( dlg.ShowDialog() != DialogResult.OK ) return;

					theEmail.AddAttachment(dlg.FileName);
					StringBuilder sb = new StringBuilder();
					foreach( string s in theEmail.Attachments )
						sb.AppendFormat("{0} ", Path.GetFileName(s));
					txtAttachments.Text = sb.ToString();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Email", ex);
			}
		}

		private void SendEmail()
		{
			try
			{
				if( string.IsNullOrEmpty(theEmail.To) )
				{
					Display.ShowError("Email", "To field cannot be empty");
					return;
				}

				if( string.IsNullOrEmpty(theEmail.Subject) &&
					string.IsNullOrEmpty(theEmail.Body) )
				{
					Display.ShowError("Email", "Subject and body cannot both be empty");
					return;
				}

				AdjustButtons(false);

				if( _SaveEmailButDoNotSend )
				{
					Display.Show("Email Status", "Email has been saved, but has not been sent yet");
				}
				else
				{
					theEmail.SendMail();
					Display.Show("Email Status", "Email Sent");
				}

				DialogResult = DialogResult.OK;
			}
			catch( Exception ex )
			{
				string msg = ( ex.Message != null ) ? ex.Message.Trim() : null;
				int index = ( msg != null ) ? msg.ToUpper().IndexOf("INVALID RECIPIENT") : -1;
				if( index >= 0 )
				{
					string error = msg.Substring(index);
					Display.ShowError("Error Sending Email", error);
				}
				else
				{
					ClsErrorHandler.LogException(ex);
					Display.ShowError("Email Status", "Error sending email");
				}
			}
			finally
			{
				AdjustButtons(true);
			}
		}

		private void AdjustButtons(bool enable)
		{
			try
			{
				btnSend.Text = ( enable ) ? "Send" : "Sending...";
				btnSend.Enabled = btnAttach.Enabled = btnCancel.Enabled = enable;
				UseWaitCursor = !enable;
				Application.DoEvents();
			}
			catch( Exception ex )
			{
				Display.ShowError("Email", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void frmEmail_Load(object sender, EventArgs e)
		{
			EmailFormLoad();
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
				Display.ShowError("Email", ex);
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
				Display.ShowError("Email", ex);
			}
		}

		private void lblTo_Click(object sender, EventArgs e)
		{
			GetTo();
		}

		private void lblCC_Click(object sender, EventArgs e)
		{
			GetCC();
		}

		private void btnAttach_Click(object sender, EventArgs e)
		{
			GetAttachment();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			SendEmail();
		}
		#endregion		// #region Event Handlers
    }
}