using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.AVSS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmCustomsSubInfo : Form
	{
		public string SubUser { get; private set; }
		public DateTime? SubDate { get; private set; }
		public string SubNotes { get; private set; }

		public frmCustomsSubInfo()
		{
			InitializeComponent();
		}

		public bool GetSubmissionInfo(DateTime? initDate, DateTime? minDate, DateTime? maxDate)
		{
			try
			{
				SubDate = null;
				SubUser = null;
				SubNotes = null;
				txtNotes.MaxLength = ClsCustomsSubmission.NotesMax;

				if (initDate != null) calSubDt.TodayDate = initDate.Value;
				if (minDate != null) calSubDt.MinDate = minDate.Value;
				if (maxDate != null) calSubDt.MaxDate = maxDate.Value;

				if (ShowDialog() != System.Windows.Forms.DialogResult.OK) return false;

				SubUser = ClsEnvironment.UserName;
				SubDate = calSubDt.SelectionStart;
				SubNotes = txtNotes.Text.Trim();

				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (!Display.Ask("Confirm", "Submitted on {0:MMMM dd, yyyy}.\r\nContinue?",
					calSubDt.SelectionStart)) return;

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}