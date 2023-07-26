using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;

namespace ASL.ITrack.WinCtrls
{
	public partial class frmSetPrioritySequence : frmChildBase
	{
		#region Fields

		private List<ClsIssue> IssueList;

		#endregion		// #region Fields

		#region Constructors/Entry/Initialization

		public frmSetPrioritySequence() : base(true)
		{
			InitializeComponent();

			WindowHelper.InitAllGrids(this);
		}

		/// <summary>Used by the static Search method to ensure that no more than
		/// one frmSetPrioritySequence window is visible at any given time</summary>
		private static frmSetPrioritySequence SequenceWindow;

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmSetPrioritySequence window is visible at any given time</summary>
		public static frmSetPrioritySequence SetSequnce(List<ClsIssue> aList)
		{
			try
			{
				if( aList == null || aList.Count <= 0 )
				{
					Display.ShowError("I-Track", "No issues provided");
					return null;
				}

				if( SequenceWindow == null )
				{
					SequenceWindow = new frmSetPrioritySequence();
					SequenceWindow.FormInit(aList);
				}
				else
					Display.Show("I-Track", "This window is already open");

				WindowHelper.ShowChildWindow(SequenceWindow);

				return SequenceWindow;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
				return null;
			}
		}

		private void FormInit(List<ClsIssue> aList)
		{
			try
			{
				IssueList = new List<ClsIssue>(aList.Count);
				foreach( ClsIssue iss in aList ) IssueList.Add(new ClsIssue(iss));

				grdIssues.DataSource = IssueList;
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Constructors/Entry/Initialization

		#region Save

		private void tbbSave_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();

				List<ClsIssue> updList = new List<ClsIssue>();
				foreach( ClsIssue iss in IssueList )
				{
					ClsIssue orig = ClsIssue.GetUsingKey(iss.Issue_ID.Value);
					if( orig.Priority_Nbr == iss.Priority_Nbr ) continue;

					if( iss.Priority_Nbr != null && (iss.Priority_Nbr < 0 || iss.Priority_Nbr > 999) )
					{
						Display.ShowError("I-Track", "Value must be between 0 and 999");
						return;
					}

					sb.AppendFormat("Issue: {0}, Old Seq: {1}, New Seq: {2}\r\n", orig.Issue_ID,
						(orig.Priority_Nbr == null ? "<null>" : orig.Priority_Nbr.ToString()),
						(iss.Priority_Nbr == null ? "<null>" : iss.Priority_Nbr.ToString()));

					orig.Priority_Nbr = iss.Priority_Nbr;
					updList.Add(orig);
				}

				if( sb.Length <= 0 )
				{
					Display.ShowError("I-Track", "No changes made");
					return;
				}

				if( !Display.Ask("Confirm", "Save the following changes?\r\n\r\n{0}", sb.ToString()) )
					return;

				foreach( ClsIssue iss in updList ) iss.Update();

				frmSearchIssues.RefreshCheckedRows(true);

				Close();
			}
			catch( Exception ex )
			{
				Display.ShowError("I-Track", ex);
			}
		}
		#endregion		// #region Save

		#region Form Event Handlers

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmSetPrioritySequence_FormClosed(object sender, FormClosedEventArgs e)
		{
			SequenceWindow = null;
		}
		#endregion		// #region Form Event Handlers
	}
}