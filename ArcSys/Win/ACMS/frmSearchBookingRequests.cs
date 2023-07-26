using System;
using System.IO;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonReports;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Win;
using CS2010.ACMS.Business;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Business;
using System.Configuration;
using System.Linq;
using System.Diagnostics;

namespace ASL.ARC.EDITools
{
	public partial class frmSearchBookingRequests : frmChildBase
	{
		#region Fields/Properties
		ClsSearchRequestControl searchCtrl;
		DataTable dtCancels;
		string sHoldPCFN;

		public DataTable dtPartners;

		protected ClsBookingRequest _CurrentBookingRequest;
		protected ClsBookingRequest CurrentBookingRequest
		{
			get
			{
				//if (!AsynchronousProcessComplete)
				//    return null;
				if (searchCtrl.BookingRequests.Rows.Count < 1)
					return null;
				if (_CurrentBookingRequest != null)
					return _CurrentBookingRequest;
				DataRow drow = grdList.GetDataRow();
				if (drow == null)
				{
					drow = grdList.GetDataRow(0);
				}
				string sCtlNo = drow["trans_ctl_no"].ToString();
				string sSeqNo = drow["trans_seq_no"].ToString();
				long lCtlNo = ClsConvert.ToInt64(sCtlNo);
				long lSeqNo = ClsConvert.ToInt64(sSeqNo);

				_CurrentBookingRequest = ClsBookingRequest.GetUsingKey(lCtlNo, lSeqNo);
				return _CurrentBookingRequest;
			}
			set
			{
				_CurrentBookingRequest = null;
			}
		}
		protected ClsBookingRequest CurrentCancel
		{
			get
			{
				DataRow drow = grdCancels.GetDataRow();
				if (drow == null)
					return null;
				string sPCFN = drow["partner_request_cd"].ToString() + "%";
				ClsBookingRequest br = ClsBookingRequest.GetByRequestCd(sPCFN);
				return br;
			}
		}

		#endregion

		#region Constructors/Initialization/Entry/Cleanup

		public frmSearchBookingRequests()
		{
			InitializeComponent();

			AsynchConnectionKey = "ACMS";
		}

		public void ShowForm()
		{
			if (!Program.IsLoggedIntoACMS)
			{
				Program.Show("Not logged into ACMS");
				return;
			}
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
			this.AcceptButton = btnSearch;
		}


		private void InitForm()
		{
			searchCtrl = new ClsSearchRequestControl();

			dtPartners = ClsAcmsSQL.GetPartners();
			cmbPartner.DataSource = dtPartners;
			cmbMMYY.DataSource = ClsDropDowns.MMYY;

			DataTable dtStatusCodes = ClsDropDowns.ACMSStatusForSearch;
			cmbStatus.DataSource = dtStatusCodes;
			cmbTerms.DropDownDataSource = ClsDropDowns.MoveTypes;

			BindHelper.Bind(txtVoyage, searchCtrl, "VoyageNo");
            BindHelper.Bind(txtVoyDoc, searchCtrl, "VoyDoc");
			BindHelper.Bind(cmbVessel, searchCtrl, "Vessel");
			BindHelper.Bind(txtBooking, searchCtrl, "BookingNo");
			BindHelper.Bind(txtPCFN, searchCtrl, "PCFN");
			BindHelper.Bind(txtSerialNo, searchCtrl, "SerialNo");
			BindHelper.Bind(cmbPartner, searchCtrl, "TradingPartnerCd");
			BindHelper.Bind(cmbPOD, searchCtrl, "PODCd");
			BindHelper.Bind(cmbPOL, searchCtrl, "POLCd");
			BindHelper.Bind(cmbPLOR, searchCtrl, "PLORCd");
			BindHelper.Bind(cmbPLOD, searchCtrl, "PLODCd");
			BindHelper.Bind(cbxStena, searchCtrl, "JustStenaFlg");
			BindHelper.Bind(cbxUnprocessed, searchCtrl, "JustUnprocessedFlg");
			BindHelper.Bind(cbxBooked, searchCtrl, "JustBookedFlg");
			BindHelper.Bind(txtDays, searchCtrl, "RequestDays");
			BindHelper.Bind(cmbMMYY, searchCtrl, "MMYY");
			BindHelper.Bind(cmbStatus, searchCtrl, "ACMSStatusCd");
			//BindHelper.Bind(cmbTerms, searchCtrl, "Terms");
			//if (cmbTerms.DataBindings["SelectedValueString"] != null)
			//    cmbTerms.DataBindings.Remove(cmbTerms.DataBindings["SelectedValueString"]);
			//cmbTerms.DataBindings.Add("SelectedValueString", searchCtrl, "Terms", true,
				//DataSourceUpdateMode.Never);

            // Initial Search Settings
			ClearParms();
			
            //if (Array.IndexOf(Program.NoSearchusers, Program.CurrentUser.User_Nm.ToLower()) < 0)
            //    PerformSearch();
            // JANUARY 2021 - It used to use a configuration per user to decide whether or not to search 
            // immediately when the window opens; which was a time-saving feature.  Now the initial search
            // is fast so it will always search as soon as the window opens.
            //PerformSearch();
            SearchRequests(false, true);
		}

		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Asynch Methods
		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdList)
				{
					btnSearch.Enabled = btnClear.Enabled = btnConfirm.Enabled = btnRetransmit.Enabled =
						grdList.Enabled = pnlCommands.Enabled = ucSplitContainer1.Enabled = state;

					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = sbbProgressMeter.Enabled = !state;
					grdList.Enabled = state;
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

				lock (grdCancels)
				{
					grdCancels.DataSource = dtCancels;
				}
				lock (grdList)
				{
					grdList.DataSource = searchCtrl.BookingRequests;
					if ( searchCtrl.BookingRequests != null )
						if (searchCtrl.BookingRequests.Rows.Count > 0)
							grdList.Row = 0;
					if (!string.IsNullOrEmpty(sHoldPCFN))
						ScrollToRow(sHoldPCFN);
					SetToolTips();
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

		private void SetToolTips()
		{
			try
			{
				foreach (GridEXRow grow in grdList.GetRows())
				{
					DataRowView drv = grow.DataRow as DataRowView;
					if (drv != null)
					{
						DataRow drow = drv.Row;
						ClsBookingRequest br = new ClsBookingRequest(drow);

						string s = drow["pshipper_name"].ToString();
						grow.Cells["pshipper_name"].ToolTipText = s;

						s = drow["prcvr_name"].ToString();
						grow.Cells["prcvr_name"].ToolTipText = s;

						s = drow["preq_name"].ToString();
						grow.Cells["preq_name"].ToolTipText = s;

						if (br.POL != null)
							grow.Cells["poe_dsc"].ToolTipText = br.POL.Location_Dsc;
						if (br.POD != null)
							grow.Cells["pod_dsc"].ToolTipText = br.POD.Location_Dsc;
					}
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
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
				lock (grdList)
				{
					searchCtrl.Terms = cmbTerms.SelectedValueString;
					searchCtrl.SearchBookingRequest();
				}
				lock (grdCancels)
				{
					dtCancels = ClsACMSQueries.GetCancels(searchCtrl.RequestDays);
				}
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

		protected void Search()
		{
			searchCtrl.SearchBookingRequest();
		}

		protected void ClearParms()
		{
			searchCtrl.ClearParms();
			cmbPOD.SelectedIndex = -1;
			cmbPartner.SelectedIndex = 0;
			cmbPOL.SelectedIndex = -1;
			rbToday.Checked = true;
			txtDays.Text = "5";
			cmbMMYY.SelectedIndex = -1;
			cmbStatus.SelectedIndex = 0;
			reqDateRange.CheckBoxChecked = false;
			reqDateRange.FromDate = reqDateRange.ToDate = null;
			sailDtRange.FromDate = sailDtRange.ToDate = null;
			cmbVessel.SelectedIndex = -1;
			cmbPLOD.SelectedIndex = cmbPLOR.SelectedIndex = -1;
            txtVoyDoc.Text = "";
            cbxBooked.Checked = cbxMissedRdd.Checked = cbxMissedRdd.Checked = cbxUnprocessed.Checked = false;
		}

		private void SetTransmitted(string sXmit, string sCode)
		{
			try
			{
				searchCtrl.dList = grdList.GetCheckedDataRows();

				searchCtrl.SetTransmitted(sXmit, sCode);

				grdList.Refresh();


			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				if (searchCtrl.HasErrors)
					Program.Show(searchCtrl.Errors);
				if (searchCtrl.Messages.Length > 0)
					Program.Show(searchCtrl.Messages);
			}
		}

		#endregion

		#region Event Handlers

		private void tbbClear_Click(object sender, EventArgs e)
		{
			ClearParms();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			string s = searchCtrl.VoyageNo;
			ClearParms();
		}

		public void SearchRequests(bool bHoldRow, bool bUnprocessed)
		{
			// bHoldRow = Whichever pcfn was initially selected in the results grid,
			// find it and select it again when the search is complete
			sHoldPCFN = null;
			if (bHoldRow && CurrentBookingRequest != null)
				sHoldPCFN = CurrentBookingRequest.Partner_Request_Cd;

			// If the user has entered some specific search critera, change "days" to "all"
			if (!string.IsNullOrEmpty(searchCtrl.PCFN) || !string.IsNullOrEmpty(searchCtrl.BookingNo) ||
				!string.IsNullOrEmpty(searchCtrl.VoyageNo) || reqDateRange.CheckBoxChecked ||
				!string.IsNullOrEmpty(searchCtrl.SerialNo))
				rbAll.Checked = true;

			if (reqDateRange.CheckBoxChecked)
			{
				searchCtrl.fromDate = reqDateRange.FromDate;
				searchCtrl.toDate = reqDateRange.ToDate;
			}
			else
				searchCtrl.fromDate = searchCtrl.toDate = null;
			if (sailDtRange.CheckBoxChecked)
			{
				searchCtrl.fromSailDt = sailDtRange.FromDate;
				searchCtrl.toSailDt = sailDtRange.ToDate;
			}
			else
				searchCtrl.fromSailDt = searchCtrl.toSailDt = null;

            searchCtrl.MissedRdd = cbxMissedRdd.Checked;
            searchCtrl.RequestDays = ClsConvert.ToInt32(txtDays.Text);
            searchCtrl.JustUnprocessedSearch = bUnprocessed;

			PerformSearch();
		}
		private void btnSearch_Click(object sender, EventArgs e)
		{
			EnablePATLOB();
			SearchRequests(false, false);
			EnablePATLOB();
		}
        private void btnUnprocessedSearch_Click(object sender, EventArgs e)
        {
            EnablePATLOB();
            SearchRequests(false, true);
            EnablePATLOB();            
        }
		private void ScrollToRow(string sPCFN)
		{
			int ix = 0;
			try
			{
				foreach (GridEXRow grow in grdList.GetDataRows())
				{
					string s = grow.Cells["partner_request_cd"].Value.ToString();
					if (s == sPCFN)
					{
						grdList.Row = ix;
						return;
					}
					ix++;
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		private void btnRetransmit_Click(object sender, EventArgs e)
		{
			string sMsg = "This will set status to 'Pending Booking' and retransmit the booking to LINE";
            if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SetTransmitted("N", ClsAcmsStatus.StatusCodes.PendingBooking);
                
            }
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			string sMsg = "This will set Transmit Flag on, so no further EDI will be sent at this time";
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				SetTransmitted("Y", null);
		}

		private void btnRetransmit301_Click(object sender, EventArgs e)
		{
			string sMsg = "This will set status to Booked and retransmit the Booking Confirmation to SDDC";
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				SetTransmitted("N", ClsAcmsStatus.StatusCodes.Booked);
		}

		private void btnUntransmitted_Click(object sender, EventArgs e)
		{
			string sMsg = "This will set Transmit Flag off.";
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				SetTransmitted("N", null);
		}


		private void grdList_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToLower() == "partner_request_cd")
			{
				CurrentBookingRequest = null;
				ViewWindowManager.View(CurrentBookingRequest);
			}
			if (e.Column.DataMember.ToLower() == "booked_voyves")
			{
				CurrentBookingRequest = null;
				using (frmSearchVoyages frm = new frmSearchVoyages(CurrentBookingRequest.Booking.Voyage_No))
				{
					frm.ShowDialog();
				}
			}
		}

		private void btnTenPlusTwo_Click(object sender, EventArgs e)
		{
			try
			{
				searchCtrl.dList = grdList.GetCheckedDataRows();
				if (searchCtrl.dList == null || searchCtrl.dList.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				ClsReportObject ro = searchCtrl.TenPlusTwo();
				if (ro == null || searchCtrl.HasErrors)
				{
					Program.ShowError(searchCtrl.Errors ?? "Could not run 10 + 2");
					return;
				}
				ro.LinkHandler = Program.LinkHandler;

				ClsReportHandler.LoadReportData(ro);
				ExportTenPlusTwo(ro, searchCtrl.dList[0]);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ExportTenPlusTwo(ClsReportObject ro, DataRow drFirstReq)
		{
			try
			{
				string fullName = null;
				using (SaveFileDialog f = new SaveFileDialog())
				{
					string def1 = @"C:\Temp", def2 = @"C:\";
					if (Directory.Exists(def1))
						f.InitialDirectory = def1;
					else if (Directory.Exists(def2))
						f.InitialDirectory = def2;
					f.OverwritePrompt = true;
					f.Title = "Select folder where the export should be saved and specify the filename";
					f.DefaultExt = "xlsx";
					f.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
					f.FilterIndex = 1;
					if (f.ShowDialog() != DialogResult.OK) return;

					fullName = f.FileName;
				}

				ExportToExcel.ExportExcelOptions opts = new ExportToExcel.ExportExcelOptions();
				Dictionary<string, object> firstRows = new Dictionary<string, object>();
				if (ro.Report_Data != null && ro.Report_Data.Rows.Count > 0)
				{
					DataRow drResult = ro.Report_Data.Rows[0];
					firstRows.Add("Carrier's Name:", "American Roll On Roll Off Carrier LLC");
					firstRows.Add("SCAC Code:", ClsConvert.ToString(drResult["SCAC Code"]));
					firstRows.Add("Vessel:", ClsConvert.ToString(drResult["Vessel"]));
					firstRows.Add("Mil Voy Doc:", ClsConvert.ToString(drResult["Mil Voy Doc"]));
					DateTime? liftOn = ClsConvert.ToDateTimeNullable(drResult["lift_on"]);
					if (liftOn != null)
						firstRows.Add("Origin Vessel Sail Date:", liftOn.Value);
					else
						firstRows.Add("Origin Vessel Sail Date:", string.Empty);
					firstRows.Add("Port of Embarkation (POE):", ClsConvert.ToString(drResult["POE"]));
					firstRows.Add("Port of Discharge (POD):", ClsConvert.ToString(drResult["POD"]));
				}

				opts.FirstRows = firstRows;
				opts.AddGroups("POE", "POD", "PCFN", "Carrier Booking");
				opts.AddSummaries("CUBE", "MT", "Pcs");
				if (ExportToExcel.CreateExcelFile.CreateExcelDocument(ro.Report_Data, fullName, opts))
					Program.Show("Exported to " + fullName);
				else
					Program.Show("Export to Excel failed. If necessary, right-click the grid and export as needed.");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnLoadList_Click(object sender, EventArgs e)
		{
			try
			{
				searchCtrl.dList = grdList.GetCheckedDataRows();
				if (searchCtrl.dList == null || searchCtrl.dList.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				ClsReportObject ro = searchCtrl.LoadList();
				if (ro == null || searchCtrl.HasErrors)
				{
					Program.ShowError(searchCtrl.Errors ?? "Could not run load list");
					return;
				}
				ExportLoadList(ro, searchCtrl.dList[0]);
				ClsReportHandler.LoadReportData(ro);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ExportLoadList(ClsReportObject ro, DataRow drFirstReq)
		{
			try
			{
				string fullName = null;
				using (SaveFileDialog f = new SaveFileDialog())
				{
					string def1 = @"C:\Temp", def2 = @"C:\";
					if (Directory.Exists(def1))
						f.InitialDirectory = def1;
					else if (Directory.Exists(def2))
						f.InitialDirectory = def2;
					f.OverwritePrompt = true;
					f.Title = "Select folder where the export should be saved and specify the filename";
					f.DefaultExt = "xlsx";
					f.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
					f.FilterIndex = 1;
					if (f.ShowDialog() != DialogResult.OK) return;

					fullName = f.FileName;
				}

				if (ExportToExcel.CreateExcelFile.CreateExcelDocument(ro.Report_Data, fullName))
					Program.Show("Exported to " + fullName);
				else
					Program.Show("Export to Excel failed. If necessary, right-click the grid and export as needed.");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void rb7_CheckedChanged(object sender, EventArgs e)
		{
			if (rbToday.Checked)
				txtDays.Text = "5";
		}

		private void rb15_CheckedChanged(object sender, EventArgs e)
		{
			if (rb30.Checked)
				txtDays.Text = "30";
		}

		private void rb180_CheckedChanged(object sender, EventArgs e)
		{
			if (rb180.Checked)
				txtDays.Text = "180";
		}

		private void rbAll_CheckedChanged(object sender, EventArgs e)
		{
			if (rbAll.Checked)
				txtDays.Text = "9999";
		}

		private void grdList_SortKeysChanged(object sender, EventArgs e)
		{
			SetToolTips();
			if (searchCtrl.BookingRequests.Rows.Count > 0)
				grdList.Row = 0;
		}
		private void grdList_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			if (e.Column.Key == "booking_id")
			{
				_CurrentBookingRequest = null;
				ClsBookingRequest br = CurrentBookingRequest;
				ClsBookingLine b = ClsBookingLine.GetByBookingNo(br.Booking_ID);
				if (b == null)
				{
					// If there is no booking in the warehouse, put the PCFN in the customer ref
					// field so the View Window can find the LINE data directly from the LINE databse.
					b = new ClsBookingLine();
					b.Customer_Ref = br.Partner_Request_Cd;
					b.Booking_Line_ID = 1;
				}
				ViewWindowManager.View(b);
			}
		}

		private void btnResend304_Click(object sender, EventArgs e)
		{
			searchCtrl.dList = grdList.GetCheckedDataRows();
			string sMsg = "This will resend the shipping instructions";
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
				searchCtrl.Resend304();
		}

		private void grdCancels_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToLower() == "partner_request_cd")
			{
				if (CurrentCancel == null)
					return;
				ViewWindowManager.View(CurrentCancel);
			}
		}

		#endregion		// #region Event Handlers

		private void btnPATLOB_Click(object sender, EventArgs e)
		{
			try
			{
				searchCtrl.dList = grdList.GetCheckedDataRows();
				if (searchCtrl.dList == null || searchCtrl.dList.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				string sVoyage = searchCtrl.dList[0]["voyage_no"].ToString();
				string[] pcfns = searchCtrl.dList
					.Select((s) => ClsConvert.ToString(s["partner_request_cd"]).NullTrim())
					.Where((s) => !s.IsNullOrWhiteSpace()).ToArray();
				DataTable dtList = ClsBookingUnit.GetLoadListPAT(sVoyage, pcfns);
				// Temporary; plug BOL into comment two field
				foreach (DataRow drow in dtList.Rows)
				{
					string a = drow["cargo_bol_no"].ToString();
					drow["comment_two"] = a;
				}
				frmPATLoadList frm = new frmPATLoadList();
				frm.ShowForm(dtList);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void Event_EnablePATLOB(object sender, EventArgs e)
		{
			EnablePATLOB();
		}

		private void EnablePATLOB()
		{
			if (cbxBooked.Checked && !string.IsNullOrEmpty(searchCtrl.POLCd)
					&& !string.IsNullOrEmpty(searchCtrl.VoyageNo))
				btnPATLOB.Enabled = true;
			else
				btnPATLOB.Enabled = false;
		}

        private void btnCallAPI_Click(object sender, EventArgs e)
        {
            //int ExitCode;
            //ProcessStartInfo ProcessInfo;
            //Process Process;

            //ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            //ProcessInfo.CreateNoWindow = true;
            //ProcessInfo.UseShellExecute = false;

            //Process = Process.Start(ProcessInfo);
            //Process.WaitForExit();

            //ExitCode = Process.ExitCode;
            //Process.Close();

            //MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
        }









	}
}