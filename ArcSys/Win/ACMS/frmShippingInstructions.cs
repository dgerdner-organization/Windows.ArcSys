using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.Common;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
	public partial class frmShippingInstructions : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmShippingInstructions()
		{
			InitializeComponent();
		}
		List<ClsVShippingInstructionList> vList;
		List<ClsEdi304Queue> ediList;

		public void ShowWindow()
		{

			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;

			// Connect to LINE
			if (ClsConMgr.Manager["LINE"] == null)
			{
				Program.ConnectToLINE();
			}
		}

		#region Asynch Methods
		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdMain)
				{
					btnSearch.Enabled = state;

					sbrStrip.Visible = sbbProgressCaption.Visible =
					    sbbProgressMeter.Visible = sbbProgressMeter.Enabled = !state;
					grdMain.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
					grdMain.DataSource = vList;
				}
				lock (grd304Queue)
				{
					grd304Queue.DataSource = ediList;
					if (ediList.Count > 0)
						btnCancelXmit.Enabled = true;
				}

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void PerformSearch()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				TimeSpan time = DateTime.Now - start;
				lock (grdMain)
				{
					vList = ClsACMSQueries.GetShippingInstructionList(txtVoyage.Text, txtPCFN.Text, txtBookingNo.Text);
				}
				lock (grd304Queue)
					ediList = ClsEdi304Queue.GetUnsentList(cbxAll.Checked);

			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}
		#endregion

		#region Methods
		protected void SendInstructions()
		{
			try
			{
				DialogResult dr = MessageBox.Show("This will send shipping instructions for all selected bookings.", "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
				{
					Program.Show("Cancelled by user");
					return;
				}
				List<ClsVShippingInstructionList> siList = grdMain.GetCheckedList<ClsVShippingInstructionList>();

				bool bWarning = false;
				int iCount = 0;
				foreach (ClsVShippingInstructionList si in siList)
				{
					iCount++;
					if (!si.FullyReceived)
					{
						bWarning = true;
					}
				}
				if (bWarning)
				{
					dr = MessageBox.Show("Warning.  At least one of these bookings is not fully received.  Do you still want to send shipping instructions?", "Confirm", MessageBoxButtons.YesNo);
					if (dr == DialogResult.No)
					{
						Program.Show("Cancelled by user");
						return;
					}
				}
				foreach (ClsVShippingInstructionList si in siList)
				{
					if (si.Partner_Request_Cd.ToLower().StartsWith("tran"))
						ClsEdi304Queue.Send304(si.Partner_Cd, si.Booking_ID);
					else
						ClsEdi304Queue.Send304(si.Partner_Cd, si.Partner_Request_Cd);
				}

				string sMsg = string.Format(@"{0} Bookings will have their Shipping Instructions sent ", iCount);
				Program.Show(sMsg);
				ReSearch(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void CancelTransmit(string sFlag)
		{
			try
			{
				string sMsg = "This will cancel the 304 transmission for selected bookings.";
				if (sFlag == "N")
					sMsg = "This will resend 304s for the selected bookings.";
				DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
				{
					Program.Show("Cancelled by user");
					return;
				}

				List<ClsEdi304Queue> xList = grd304Queue.GetCheckedList<ClsEdi304Queue>();

				int iCount = 0;
				foreach (ClsEdi304Queue q in xList)
				{
					iCount++;
					q.Confirm_Flg = sFlag;
					q.Update();
				}
				ReSearch(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void Resend()
		{
			try
			{
				string	sMsg = "This will resend 304s for the selected bookings.";
				DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
				{
					Program.Show("Cancelled by user");
					return;
				}

				List<ClsEdi304Queue> xList = grd304Queue.GetCheckedList<ClsEdi304Queue>();

				int iCount = 0;
				foreach (ClsEdi304Queue q in xList)
				{
					iCount++;
					ClsEdi304Queue.Send304(q.Partner_Cd, q.Partner_Request_Cd);
				}
				ReSearch(false);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		protected void ReSearch(bool bAll)
		{
			grdMain.UnCheckAllRecords();
			grd304Queue.UnCheckAllRecords();
			grdMain.DataSource = null;
			grd304Queue.DataSource = null;
			if (bAll)
				PerformSearch();
			else
			{
				ediList = ClsEdi304Queue.GetUnsentList(cbxAll.Checked);
				grd304Queue.DataSource = ediList;
			}
		}

		protected void DoNotSend()
		{
			try
			{
				List<ClsVShippingInstructionList> siList = grdMain.GetCheckedList<ClsVShippingInstructionList>();
				if (siList.Count < 1)
				{
					Program.Show("You must select at least one booking request.");
					return;
				}
				DialogResult dr = MessageBox.Show("Are you sure?  This will flag the bookings so Shipping Instructions will never be sent (this cannot be undone.)", "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					return;

				foreach (ClsVShippingInstructionList si in siList)
				{
					ClsEdi304Queue.DoNotSend(si.Partner_Cd, si.Partner_Request_Cd);
				}
				Program.Show("Booking requests were removed from this list.");
				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}
		}
		#endregion

		#region Events
		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				ClsACMSUtil.Update304DeleteFlag();
				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdMain_RowCheckStateChanged(object sender, Janus.Windows.GridEX.RowCheckStateChangeEventArgs e)
		{
			if (grdMain.GetCheckedRows().Length > 0)
				btnSend.Enabled = true;
			else
				btnSend.Enabled = false;
		}
		private void btnSend_Click(object sender, EventArgs e)
		{
			SendInstructions();
		}

		private void btnCancelXmit_Click(object sender, EventArgs e)
		{
			CancelTransmit("Y");
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
			Resend();
		}

		private void cbxAll_CheckedChanged(object sender, EventArgs e)
		{
			ediList = ClsEdi304Queue.GetUnsentList(cbxAll.Checked);
			grd304Queue.DataSource = ediList;
		}
		private void grdMain_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key);
		}
		#endregion

		private void btnNoSend_Click(object sender, EventArgs e)
		{
			DoNotSend();
		}

		//private void btnXmt_Click(object sender, EventArgs e)
		//{
		//    DataTable dt304Sddc = ClsAcmsSQL.Get304s();
		//    if (dt304Sddc.Rows.Count > 0)
		//    {
		//        EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_SDDC304();
		//        EdiInfo ediReturn= ClsMapsAndFTP.RunOutboundMap(edi);
		//    }
		//}





	}
}
