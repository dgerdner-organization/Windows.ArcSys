using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmViewIssue : frmDialogBase
	{
		#region Fields

		private ClsIssue theIssue;

		#endregion		// #region Fields

		#region Properties

		public bool MoveIssue
		{
			get { return chkAddToIssues.Checked; }
		}

		public bool DismissIssue
		{
			get { return chkDismissIssue.Checked; }
		}
		#endregion		// #region Properties

		#region Constructors

		public frmViewIssue()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool ViewIssue(ClsIssue anIssue)
		{
			try
			{
				theIssue = new ClsIssue(anIssue);
				return ( ShowDialog() == DialogResult.OK );
			}
			catch( Exception ex )
			{
				return Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void ViewIssueFormLoad()
		{
			try
			{
				List<ClsAttachment> lst = theIssue.Attachments;
				lst.Sort(delegate(ClsAttachment l, ClsAttachment r)
				{
					if( l.Create_Dt < r.Create_Dt ) return -1;
					if( l.Create_Dt > r.Create_Dt ) return 1;
					return 0;
				});
				grdAttachments.DataSource = lst;

				string notes = theIssue.NotesBox;
				if( string.IsNullOrEmpty(notes.Trim()) )
					notes = "NO NOTES PROVIDED";
				Text = string.Format("{0}: {1}", theIssue.Issue_ID, theIssue.Issue_Dsc);

				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("Created:\t{0}  ({1})\r\nModified:\t{2}  ({3})\r\nDue:\t{4}\r\n\r\n",
					ClsConfig.FormatDate(theIssue.Create_Dt), theIssue.Create_User,
					ClsConfig.FormatDate(theIssue.Modify_Dt), theIssue.Modify_User,
					ClsConfig.FormatDate(theIssue.Due_Dt));

				sb.AppendFormat("{0} {1} {2} \r\n\r\n",
					theIssue.Project_Cd,
					(theIssue.Category != null ? theIssue.Category.Category_Nm : null),
					theIssue.Status.Status_Dsc);

				string biz = string.IsNullOrEmpty(theIssue.Biz_Owner_Login)
					? "NONE" : theIssue.Biz_Owner_Login;
				string dev = string.IsNullOrEmpty(theIssue.It_Owner_Login)
					? "NONE" : theIssue.It_Owner_Login;
				sb.AppendFormat("Biz Owner: {0}, IT Owner: {1}\r\n\r\n", biz, dev);

				sb.AppendLine("Notes\r\n-------------");
				sb.AppendLine(notes);

				txtNotes.CharacterCasing = CharacterCasing.Normal;
				txtNotes.Text = sb.ToString();

				chkDismissIssue.Focus();
				ActiveControl = chkDismissIssue;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void ViewAttachment()
		{
			try
			{
				ClsAttachment a = grdAttachments.GetCurrentItem<ClsAttachment>();
				if( a == null ) return;

				string file = Path.Combine(Path.GetTempPath(), a.Attachment_Nm);
				if( ClsConvert.BlobToFile(file, a.Attachment) == false )
				{
					Display.ShowError("I-Track", "Error viewing attachment");
					return;
				}

				ClsConvert.ViewFile(file);
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void frmViewIssue_Load(object sender, EventArgs e)
		{
			ViewIssueFormLoad();
		}

		private void grdAttachments_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				if( string.Compare(e.Column.Key, "Attachment_Nm", true) == 0 )
					ViewAttachment();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}

		private void chkAddToIssues_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if( chkAddToIssues.Checked ) chkDismissIssue.Checked = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Event Handlers
	}
}