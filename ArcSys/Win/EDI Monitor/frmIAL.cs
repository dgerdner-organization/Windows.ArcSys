using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.Diagnostics;
using System.IO;
using Janus.Windows.GridEX;
using CS2010.ACMS.Business;
using ASL.ARC.EDISQLTools;
using CS2010.CommonSecurity;
using CS2010.Common;
using System.Linq;
//using CS2010.ArcSys.Business.PAT;


namespace CS2010.ArcSys.Win
{
	public partial class frmIAL : frmChildBase
	{
		#region Properties
		protected bool bStarted = false;
		protected bool bSearching = false;
		protected DataTable dtDownloadsSearch;
		protected int iSearchCount = 0;
		protected int iFoundCount = 0;

		protected ClsEdiInboundDetail currentCargoDtl
		{
			get
			{
				DataRow drow = grdUnprocessedDetail.GetDataRow();
				if (grdUnprocessedDetail.CurrentRow.RowType != RowType.Record)
					return null;
				if (drow == null)
					return null;
				ClsEdiInboundDetail d = new ClsEdiInboundDetail(drow);
				return d;	
			}
		}
		protected ClsEdiInboundSi currenetSI
		{
			get
			{
				DataRow drow = grdUnprocessedSI.GetDataRow();
				if (drow == null)
					return null;
				ClsEdiInboundSi s = new ClsEdiInboundSi(drow);
				return s;
			}
		}
		protected DataTable dtShippingInstructionsQueue;

		DataTable dtDetailSource;
		DataTable dtSISource;
		protected int Checked304Rows
		{
			get
			{
				DataRow[] drows = grdUnprocessedSI.GetCheckedDataRows();
				if (drows == null)
					return 0;
				return drows.Length;
			}
		}
		protected int ReadyToSendRows
		{
			get
			{
				DataRow[] drows = grdUnprocessedSI.GetCheckedDataRows();
				if (drows == null)
					return 0;
				int ix = 0;
				foreach (DataRow drow in drows)
				{
					ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
					if (si.Processed_Flg == "N")
						ix++;
				}
				//return ix;
				return 1;
			}
		}
		protected int DaysBack
		{
			get
			{
				if (rb30Days.Checked) return 30;
				if (rb60Days.Checked) return 60;
				return 99999;
			}
		}

		// Shipping Instructions Tab
		protected DataRow currentSISummaryRow
		{
			get 
			{
				DataRow drow = grdSISummary.GetDataRow();
				if (grdSISummary.CurrentRow.RowType != RowType.Record)
					return null;
				return drow;
			}
		}
		protected string current304BookingNo
		{
			get
			{
				DataRow drow = grdSISummary.GetDataRow();
				if (grdSISummary.CurrentRow.RowType != RowType.Record)
					return null;
				if (drow == null)
					return null;
				return drow["booking_no"].ToString();
			}
		}
		protected DataTable dtIALVins;
		protected DataTable dtLINEVins;
		protected DataTable dtOverHeights;

		// Download Search Tab
		protected string currentSearchFile
		{
			get
			{
				GridEXRow grow = grdDownloadResults.CurrentRow;
				if (grow != null)
				{
					string sFile = grow.Cells[0].Value.ToString();
					return sFile;
				}
				return "";
			}
		}
		#endregion

		#region Primary Methods

		public frmIAL()
		{
			InitializeComponent();
		}

		public void ShowForm()
		{
			ShowForm(null);
		}
		public void ShowForm(string sBookingNo)
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			if (!string.IsNullOrEmpty(sBookingNo))
				txtBookingNo.Text = sBookingNo;
			RefreshForm();
			bStarted = true;
			ClsSecurityMaster.SetSecurity(this);
		}

		public void RefreshForm()
		{

			if (tabMain.SelectedIndex == 1)
			{
				// Get detail file data
				listDetailFiles.DataSource = ClsIALEDI.UnprocessedDetailFiles;
				listFailedDetail.DataSource = ClsIALEDI.FailedDetailFiles;
				dtDetailSource = ClsEdiInboundDetail.GetUnprocessed(cbxShowAll.Checked, DaysBack, txtBookingNo.Text, txtVIN.Text,"%");
				grdUnprocessedDetail.DataSource = dtDetailSource;

				// Get Shipping Instruction data
				listUnprocessedSI.DataSource = ClsIALEDI.UnprocessedSIFiles;
				listFailedSI.DataSource = ClsIALEDI.FailedSIFiles;
				dtSISource = ClsEdiInboundSi.GetUnprocessed(cbxShowAll.Checked, DaysBack, txtBookingNo.Text, txtVIN.Text);
				grdUnprocessedSI.DataSource = dtSISource;
				//btnRun304.Enabled = ReadyToSendRows > 0;

				// Scroll to the top row
				if (grdUnprocessedDetail.GetRows().Length > 0)
					grdUnprocessedDetail.Row = 0;
				if (grdUnprocessedSI.GetRows().Length > 0)
					grdUnprocessedSI.Row = 0;

				// Decide whether or not to shows the file listings
				ShowFileList();
			}

			// Dec2017 DGERDNER
			//   No longer refresh Shipping Instructions tab every time; only do it on-demand
			//   on the Shipping Instructions tab via a button.
			if (tabMain.SelectedIndex == 0)
			{
				RefreshSIQueue();
			}

			// DEC2018 DGERDNER
			//   Retrieve Over Height History.  Only perform this one time.
			if (dtOverHeights == null)
			{
				dtOverHeights = ClsIALEDI.GetOverHeightHistory();
				grdOverheight.DataSource = dtOverHeights;
			}

			int i = tabMain.SelectedIndex;
		}

		private void RefreshSIQueue()
		{
			// DGERDNER Dec2017
			//  Commented out these lines.  This grid is invisible, and I see no evidence that
			//  the datatable is used anywhere.
			//
			//dtShippingInstructionsQueue = ClsEdiInboundSi.GetUnprocessed(false, 7, "%", "%");
			//grdShippingInstructions.DataSource = dtShippingInstructionsQueue;
			//ClsEdiInboundSi.InspectShippingInstructions(ref dtShippingInstructionsQueue);
			//grdShippingInstructions.DataSource = dtShippingInstructionsQueue;
			grdQueue.DataSource = ClsShippingInstructionsQueue.GetAll();
			grdSISummary.DataSource = ClsEdiInboundSi.GetBookingSummary(10);
		}

		public void ShowFileList()
		{
			panelTopDtl.Visible = panelTopSI.Visible = cbxShowFileList.Checked;
		}
		#endregion

		#region Cargo Detail Methods
		protected void ProcessDetailFiles()
		{
			try
			{
				ClsIALEDI edi = new ClsIALEDI();
				edi.ProcessCargoDetails();
				if (edi.Warnings.Length > 1)
					Program.Show(edi.Warnings);
				if (edi.Errors.Length > 1)
					Program.Show(edi.Errors);
				if (edi.Warnings.Length < 1 &&
					edi.Errors.Length < 1)
					Program.Show("Process completed");
				RefreshForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ReprocessSelected()
		{
			foreach (DataRow drow in grdUnprocessedDetail.GetCheckedDataRows())
			{
				ClsEdiInboundDetail dtl = new ClsEdiInboundDetail(drow);
				dtl.Processed_Flg = "N";
				dtl.Update();
			}
			Program.Show("Cargo will be processed again");
			this.RefreshForm();
		}
		protected void EditDetail()
		{
			int ixRow = 0;
			try
			{
				using (frmEditIALDetail frm = new frmEditIALDetail())
				{
					DataRow dr = grdUnprocessedDetail.GetDataRow();
					ClsEdiInboundDetail d = new ClsEdiInboundDetail();
					d.CopyFrom(currentCargoDtl);
					ClsEdiInboundSi si = new ClsEdiInboundSi();
					DataRow drowSI = FindMatchingSI(d.Booking_No, d.Vin);
					if (drowSI != null)
						si = new ClsEdiInboundSi(drowSI);
					if (!frm.Edit(d, si))
						return;
					d.CopyToDataRow(dr);
					grdUnprocessedDetail.Refetch();

					// Refresh corresponding shipping instructions row
					if (drowSI != null)
					{
						si.CopyToDataRow(drowSI);
						grdUnprocessedSI.Refetch();
						bool bDone = false;
						int iCount = grdUnprocessedSI.GetRows().Length;
						while (bDone == false)
						{
							GridEXRow drow = grdUnprocessedSI.GetRow(ixRow);
							if (drow.RowType == RowType.Record)
							{
								string s1 = si.Vin;
								string s2 = drow.Cells["vin"].Value.ToString();
								if (s1 == s2)
									bDone = true;
								else
									ixRow++;
							}
							else
							{
								ixRow++;
							}
							if (ixRow > iCount - 1)
								bDone = true;
						}
						if (ixRow > -1)
							grdUnprocessedSI.Row = ixRow;
					}
				}
			}
			catch (Exception ex)
			{
				Display.ShowError(ex);
			}
		}
		private void OpenDetailFile(string s)
		{
			Process.Start("notepad.exe", s);
		}

		private void btnReprocessDtl_Click(object sender, EventArgs e)
		{
			foreach (string sFile in listFailedDetail.Items)
			{
				string sDest = sFile.Replace("error", "in");
				Directory.Move(sFile, sDest);
			}
			ProcessDetailFiles();
		}
		private void listFailedDetail_DoubleClick(object sender, EventArgs e)
		{
			string s = listFailedDetail.SelectedItem.ToString();
			OpenDetailFile(s);
		}
		private void listDetailFiles_DoubleClick(object sender, EventArgs e)
		{
			string s = listDetailFiles.SelectedItem.ToString();
			OpenDetailFile(s);

		}
		private void grdUnprocessedDetail_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				string sBookingNo = "";
				if (currentCargoDtl != null)
					sBookingNo = currentCargoDtl.Booking_No;
				frmLINEQuery frm = new frmLINEQuery(sBookingNo);
				frm.MdiParent = Program.MainWindow;
				frm.Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void btnReLoadDetail_Click(object sender, EventArgs e)
		{
			ClsIALEDI edi = new ClsIALEDI();
			if (!edi.UpdateLine())
				Program.Show(edi.Errors);
			if (edi.Warnings.Length > 1)
				Program.Show(edi.Warnings);
			if (edi.Warnings.Length < 1 &&
				edi.Errors.Length < 1)
				Program.Show("Process completed");
			RefreshForm();
		}
		private void grdUnprocessedDetail_DoubleClick(object sender, EventArgs e)
		{
			EditDetail();
		}
		private void btnArchiveDetail_Click(object sender, EventArgs e)
		{
			ClsIALEDI edi = new ClsIALEDI();
			edi.ArchiveCargoDetail();
			RefreshForm();
		}
		private void btnProcessFiles_Click(object sender, EventArgs e)
		{
			ProcessDetailFiles();
		}
		private void btnReprocess_Click(object sender, EventArgs e)
		{
			ReprocessSelected();
		}
		#endregion

		#region Shipping Instructions Methods
		public void ProcessShippingInstructions()
		{
			ClsIALEDI edi = new ClsIALEDI();
			edi.ProcessShippingInstructions();
			if (edi.Errors.Length > 1)
				Program.Show(edi.Errors);
			RefreshForm();
		}
		protected void Run304s()
		{
			try
			{
				string sMsg = ClsEdiInboundSi.Send304s();
				Program.Show(sMsg);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				RefreshForm();
			}
		}
		private void listFailedSI_DoubleClick(object sender, EventArgs e)
		{
			string s = listFailedSI.SelectedItem.ToString();
			OpenDetailFile(s);
		}
		private void listUnprocessedSI_DoubleClick(object sender, EventArgs e)
		{
			string s = listUnprocessedSI.SelectedItem.ToString();
			OpenDetailFile(s);

		}
		private void RemoveSI()
		{
			DataRow[] drows = grdUnprocessedSI.GetCheckedDataRows();
			if (drows == null)
			{
				Program.Show("No Rows Selected");
				return;
			}
			string sMsg = "The following booking(s) will be deleted: ";
			string sLastBooking = "ZZZ";
			foreach (DataRow drow in drows)
			{
				ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
				if (si.Booking_No != sLastBooking)
				{
					sMsg = sMsg + si.Booking_No + ",";
					sLastBooking = si.Booking_No;
				}
			}
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				return;
			int iCouint = 0;
			foreach (DataRow drow in drows)
			{
				ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
				si.Processed_Flg = "Y";
				//si.Update();
				si.DeleteSI();
				iCouint++;
			}
			Program.Show("{0} Shipping Instructions were removed", iCouint);
			RefreshForm();

		}
		private void ReSend304s()
		{
			DataRow[] drows = grdUnprocessedSI.GetCheckedDataRows();
			if (drows == null )
			{
				Program.Show("No Rows Selected");
				return;
			}
			string sMsg = "The following booking(s) will be resent: ";
			string sLastBooking = "ZZZ";
			foreach (DataRow drow in drows)
			{
				ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
				if (si.Booking_No != sLastBooking)
				{
					sMsg = sMsg + si.Booking_No + ",";
					sLastBooking = si.Booking_No;
				}
			}
			if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				return;
			int iCouint = 0;
			foreach (DataRow drow in drows)
			{
				ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
				si.Processed_Flg = "N";
				si.Update();
				iCouint++;
			}
			Program.Show("{0} 304's have been flagged to be resent", iCouint);
			//cbxShowAllSI.Checked = false;
			RefreshForm();
		}
		protected void EditSI()
		{
			try
			{
				using (frmEditIALDetail frm = new frmEditIALDetail())
				{
					DataRow dr = grdUnprocessedSI.GetDataRow();
					ClsEdiInboundSi si = new ClsEdiInboundSi();
					si.CopyFrom(currenetSI);
					ClsEdiInboundDetail d = new ClsEdiInboundDetail();
					//DataRow drowSI = FindMatchingSI(d.Booking_No, d.Vin);
					//if (drowSI != null)
					//    si = new ClsEdiInboundSi(drowSI);
					if (!frm.Edit(si, d))
						return;
					si.CopyToDataRow(dr);
					grdUnprocessedSI.Refetch();

					// Refresh corresponding shipping instructions row
					//if (drowSI != null)
					//{
					//    si.CopyToDataRow(drowSI);
					//    grdUnprocessedSI.Refetch();
					//    int ixRow = 0;
					//    bool bDone = false;
					//    while (bDone == false)
					//    {
					//        GridEXRow drow = grdUnprocessedSI.GetRow(ixRow);
					//        if (drow.RowType == RowType.Record)
					//        {
					//            string s1 = si.Vin;
					//            string s2 = drow.Cells["vin"].Value.ToString();
					//            if (s1 == s2)
					//                bDone = true;
					//            else
					//                ixRow++;
					//        }
					//        else
					//        {
					//            ixRow++;
					//        }
					//    }
					//    grdUnprocessedSI.Row = ixRow;
					//}
				}
			}
			catch (Exception ex)
			{
				Display.ShowError(ex);
			}
		}
		private void btnArchiveSI_Click(object sender, EventArgs e)
		{
			ClsIALEDI edi = new ClsIALEDI();
			edi.ArchiveShippingInstructsion();
			RefreshForm();
		}
		private void btnProcessSI_Click(object sender, EventArgs e)
		{
			ProcessShippingInstructions();
		}
		private void btnReProcessSI_Click(object sender, EventArgs e)
		{
			foreach (string sFile in listFailedSI.Items)
			{
				string sDest = sFile.Replace("error", "in");
				Directory.Move(sFile, sDest);
			}
			ProcessShippingInstructions();
		}

		private void grdUnprocessedSI_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
		{
			//btnRun304.Enabled = ReadyToSendRows > 0;
			btnResend304.Enabled = Checked304Rows > 0;
		}
		private void btnResend304_Click(object sender, EventArgs e)
		{
			ReSend304s();
		}
		private void btnPutInQueue_Click(object sender, EventArgs e)
		{
			Put304sInQueue();
		}
		private void Put304sInQueue()
		{
			try
			{

                var lstErrors =
                    (from x in grdSISummary.GetCheckedRows().ToList<GridEXRow>()
                    where x.Cells[9].Value.ToString() == "Y"
                    select x).ToList<GridEXRow>();

                if (lstErrors.Count > 0){
                     MessageBox.Show("Please correct the cargo type (BD Error) in LINE and try again.");
                    return;
                }

                string sMsg = ClsEdiInboundSi.PutInQueue(grdSISummary.GetCheckedDataRows());
                Program.Show(sMsg);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				RefreshForm();
			}
		}
		private void grdUnprocessedSI_DoubleClick(object sender, EventArgs e)
		{
			EditSI();
		}
		private void btnRemoveSI_Click(object sender, EventArgs e)
		{
			RemoveSI();
		}
		#endregion

		#region VIN Matching
		private void AdjustGrids()
		{
			try
			{
				if (dtLINEVins == null || dtLINEVins.Rows.Count <= 0 ||
					dtIALVins == null || dtIALVins.Rows.Count <= 0) return;

				lock (grdLINEVins)
				{
					foreach (DataRow dr in dtLINEVins.Rows)
					{
						string vin = ClsConvert.ToString(dr["VIN"]);
						if (string.IsNullOrEmpty(vin)) continue;

						string where = string.Format("VIN = '{0}'", vin);
						DataRow[] rows = dtIALVins.Select(where);
						int diffStatus = (rows == null || rows.Length <= 0) ? 1 : 0;
						dr["diff_status"] = ClsConvert.ToDbObject(diffStatus);
					}

					dtLINEVins.DefaultView.RowFilter = (cbxMismatches.Checked) ? "Diff_Status = 1" : null;
					//UpdateLineRecordCount();
				}

				lock (grdIALVins)
				{
					foreach (DataRow dr in dtIALVins.Rows)
					{
						string vin = ClsConvert.ToString(dr["VIN"]);
						if (string.IsNullOrEmpty(vin)) continue;

						string where = string.Format("VIN = '{0}'", vin);
						DataRow[] rows = dtLINEVins.Select(where);
						int diffStatus = (rows == null || rows.Length <= 0) ? 1 : 0;
						dr["diff_status"] = ClsConvert.ToDbObject(diffStatus);
					}
					dtIALVins.DefaultView.RowFilter = (cbxMismatches.Checked) ? "Diff_Status = 1" : null;
					//UpdateClassRecordCount();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cbxMismatches_CheckedChanged(object sender, EventArgs e)
		{
			AdjustGrids();
		}

		private void UpdateLINEVIN()
		{
			try
			{
				if (grdIALVins.GetDataRow() == null)
				{
					Program.Show("There is no data to select");
					return;
				}
				string sIAL = grdIALVins.GetDataRow()["vin"].ToString();
				string sLINE = grdLINEVins.GetDataRow()["vin"].ToString();
				string sBookingNo = grdIALVins.GetDataRow()["booking_no"].ToString();
				string sMsg = string.Format("Update LINE vin {0} to {1}?", sLINE, sIAL);
				DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
				{
					Program.Show("Action cancelled");
					return;
				}
				if (!CS2010.ArcSys.Business.ClsLineSQL.UpdateRoroVin(sBookingNo, sLINE, sIAL))
				{
					Program.Show("The update in LINE failed.  You can try again or manually update in LINE");
					return;
				}
				ClsVBookingCargoLine vc = ClsVBookingCargoLine.GetByBookingSerialNo(sBookingNo, sLINE);
				if (vc != null)
				{
					ClsCargoLine cl = ClsCargoLine.GetUsingKey(vc.Cargo_Line_ID.GetValueOrDefault());
					if (cl != null)
					{
						cl.Serial_No = sIAL;
						cl.Update();
					}
				}
				sMsg = string.Format("For Booking {2}: VIN {0} needs to be changed to {1} ", sLINE, sIAL, sBookingNo);

				DataRow drow = currentSISummaryRow;
				if (drow == null)
					return;
				string sPOL = drow["pol_location_cd"].ToString();
				AttemptSendEmail(sMsg, sPOL);
				Program.Show("VIN was updated in LINE, and the port has been notified via email");
				RefreshForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return;
			}
		}

		#endregion

		#region Helper Methods

		protected DataRow FindMatchingSI(string sBookingNo, string sVin)
		{
			string sFind = string.Format(@"vin = '{0}' ", sVin);
			DataRow[] drows = dtSISource.Select(sFind);
			if (drows.Length < 1)
				return null;
			return drows[0];
		}
		private void SendITV(string sCode)
		{
			ClsIALEDI edi = new ClsIALEDI();
			edi.SendITVOut(sCode);
			if (edi.Errors.Length > 1)
				Program.Show(edi.Errors);
			else
				if (edi.Warnings.Length > 1)
					Program.Show(edi.Warnings);
				else
					Program.Show("Export Complete");

		}
		#endregion

		#region Events
		
		private void cbxShowAll_CheckedChanged(object sender, EventArgs e)
		{
			//btnReLoadDetail.Enabled = !cbxShowAll.Checked;
			//btnReprocess.Enabled = cbxShowAll.Checked;
			//RefreshForm();
		}

		private void btnRefreshDetail_Click(object sender, EventArgs e)
		{
			RefreshForm();
		}

		private void cbxShowAllSI_CheckedChanged(object sender, EventArgs e)
		{
			//RefreshForm();
		}
		

		private void radiobutton_clicks(object sender, EventArgs e)
		{
			RefreshForm();
		}
		private void grdUnprocessedDetail_FilterApplied(object sender, EventArgs e)
		{

		}

		private void txtBookingNo_TextChanged(object sender, EventArgs e)
		{
			cbxShowAll.Checked = true;
			rbAll.Checked = true;
			//RefreshForm();
		}

		private void cbxShowFileList_CheckedChanged(object sender, EventArgs e)
		{
			ShowFileList();
		}
		private void btnBOLs_Click(object sender, EventArgs e)
		{
			ClsIALEDI edi = new ClsIALEDI();
			edi.SendBolsOut();
			if (edi.Errors.Length > 1)
				Program.Show(edi.Errors);
			else
				Program.Show("Export Complete");
		}

		private void btnSendITV_Click(object sender, EventArgs e)
		{
			try
			{
				SendITV("RECEIVED");
				SendITV("DEPART");
				SendITV("ARRIVE");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void cbxShowFileList_CheckedChanged_1(object sender, EventArgs e)
		{
			ShowFileList();
		}
		private void btnSearch_Click(object sender, EventArgs e)
		{
			RefreshForm();
		}
		
		private void txtVIN_TextChanged(object sender, EventArgs e)
		{
			cbxShowAll.Checked = true;
			rbAll.Checked = true;
		}

		private void grdSISummary_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(current304BookingNo))
				{
					grdIALVins.DataSource = grdLINEVins.DataSource = null;
					return;
				}
				ClsVinMatch.VinParameters p = new ClsVinMatch.VinParameters();
				p.Booking_No = current304BookingNo;
				p.OnlyAAL = false;

				//dtIALVins = ClsEdiInboundSi.GetUnprocessed(true, 360, current304BookingNo, "%");
				dtIALVins = ClsVinMatch.GetIALVins(p);
				grdIALVins.DataSource = dtIALVins;
				grdIALVins.Refresh();

                // DGERDNER Jan2020 Instead of direclty querying LINE, it now queries
                //  the datawarehouse; done in preparation for transfering to a new Liner system
				//dtLINEVins = ClsVinMatch.GetLineVins(p);
                dtLINEVins = ClsVBookingCargoLine.GetByBookingView(p.Booking_No);

				grdLINEVins.DataSource = dtLINEVins;

				AdjustGrids();
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}
		}

		private void btnUpdateLINE_Click(object sender, EventArgs e)
		{
			UpdateLINEVIN();
		}


        private void btnAdd2Queue_Click(object sender, EventArgs e)
        {
            Put304sInQueue();
        }

		private void AttemptSendEmail(string sMsg,string sPOL)
		{
			try
			{
				string toAddr = ClsConfig.ReadStringValue(sPOL, null);
				string[] toAddress = toAddr.Split(',');

				string bccAddr = ClsConfig.ReadStringValue("BCCGroup", null);
				ClsEmail em = new ClsEmail("ARCCustomerService@amslgroup.com",
					toAddress[0], null, bccAddr, "VIN Correction Required",
					sMsg);
				int ix = 0;
				foreach (string s in toAddress)
				{
					if (ix > 0)
						em.AddCC(s);
					ix++;
				}
				em.AddCC("ARCCustomerService@amslgroup.com");
				em.SendMail();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}
		
		private void btnTOPS_Click(object sender, EventArgs e)
		{
			ClsEdiInboundDetail.UpdateTOPS();
		}

		private void btnBDRefresh_Click(object sender, EventArgs e)
		{
			// Clear the Grid
			grdBatteryDisconnect.DataSource = null;
			grdBatteryDisconnect.Refetch();

			// Start Refreshing
			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();
			grdBatteryDisconnect.DataSource = CS2010.ArcSys.Business.ClsLineSQL.IncompleteBatteryDisconnects();
			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Download Search Region
		private void Search_Click(object sender, EventArgs e)
		{
			pnlDownloadsTop.Enabled = grdDownloadResults.Enabled = txtFileDisplay.Enabled = false;
			pnlDownloadsCancel.Visible = bSearching = true;
			txtFileDisplay.Text = "";
			bgwDownloads.RunWorkerAsync();
		}

		static string GetFileText(string name)
		{
			string fileContents = String.Empty;

			// If the file has been deleted since we took  
			// the snapshot, ignore it and return the empty string. 
			if (System.IO.File.Exists(name))
			{
				fileContents = System.IO.File.ReadAllText(name);
			}
			return fileContents;
		}

		protected void DisplayFile()
		{
			if (string.IsNullOrEmpty(currentSearchFile))
				return;
			try
			{
				if (!bgwDownloads.IsBusy)
				{
					txtFileDisplay.Text = System.IO.File.ReadAllText(currentSearchFile);
					//GridEXRow grow = grdDownloadResults.CurrentRow;
					//if (grow != null)
					//{
					//    string sFile = grow.Cells[0].Value.ToString();
					//    txtFileDisplay.Text = System.IO.File.ReadAllText(sFile);
					//}
				}
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}
		}
		private void grdDownloadResults_SelectionChanged(object sender, EventArgs e)
		{
			if (!bSearching)
				DisplayFile();
		}

		private void bgwDownloads_DoWork(object sender, DoWorkEventArgs e)
		{
			// Initialize everything
			iSearchCount = iFoundCount = 0;
			grdDownloadResults.DataSource = null;
			bgwDownloads.ReportProgress(0);

			//SearchForString();
			dtDownloadsSearch = new DataTable();
			dtDownloadsSearch.Columns.Add("FileName");

			// Modify this path as necessary; pick between Cargo Details and Shipping Instructions
			string startFolder;
			if (rbCargoDetail.Checked)
				startFolder = ClsIALEDI.sRoot;
			else
				startFolder = ClsIALEDI.sSIRoot;

			// Take a snapshot of the file system.
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

			// This method assumes that the application has discovery permissions 
			// for all folders under the specified path.
			IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
			int iFileCount = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Length;
			string searchTerm = txtSearchString.Text;
		
			// Loop through all files, searching for the specified string
			foreach (FileInfo fi in fileList)
			{
				iSearchCount++;
				decimal dPercent = 0;
				if (fi.Length > 0)
					dPercent = iSearchCount * 100 / iFileCount;
				if (dPercent > 1)
					bgwDownloads.ReportProgress(ClsConvert.ToInt32(dPercent));

				if (bgwDownloads.CancellationPending)
				{
					e.Cancel = true;
					bgwDownloads.ReportProgress(0);
					return;
				}
				string sContents = System.IO.File.ReadAllText(fi.FullName);
				// If string is found, add to the count and to the results set
				if (sContents.Contains(searchTerm))
				{
					iFoundCount++;
					DataRow drow = dtDownloadsSearch.NewRow();
					drow["FileName"] = fi.FullName;
					dtDownloadsSearch.Rows.Add(drow);
				}
			}

		}

		private void bgwDownloads_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			grdDownloadResults.DataSource = dtDownloadsSearch;
			pnlDownloadsTop.Enabled = grdDownloadResults.Enabled = txtFileDisplay.Enabled = true;
			pnlDownloadsCancel.Visible = bSearching = false;
			DisplayFile();
		}

		private void btnCancelSearch_Click(object sender, EventArgs e)
		{
			bgwDownloads.CancelAsync();
			btnCancelSearch.Visible = false;
		}

		private void bgwDownloads_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			lblProgress.Text = string.Format("Search is {0}% Complete", e.ProgressPercentage);
		}
		private void grdDownloadResults_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			DialogResult dr = MessageBox.Show("Do you want to reprocess this file?", "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;
			try
			{
				string sDest = currentSearchFile.ToLower();
				sDest = sDest.Replace("archive", "in");
				sDest = sDest.Replace("error", "in");
				File.Move(currentSearchFile, sDest);
				Program.Show("File has been moved to the 'In' folder for reprocessing");
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}
		}
		#endregion

        #region Grid-Row Formatting

        private GridEXFormatStyle ErrorStyle = new GridEXFormatStyle() { BackColor = Color.Red, ForeColor = Color.White };
        private GridEXFormatStyle NormalStyle = new GridEXFormatStyle() { BackColor = Color.White, ForeColor = Color.Black };

        private void grdSISummary_FormattingRow(object sender, RowLoadEventArgs e)
        {
            e.Row.Cells["invalid_cargo_type"].FormatStyle = (e.Row.Cells["invalid_cargo_type"].Text == "Y") ?
                ErrorStyle : NormalStyle;
        }

        private void grdBatteryDisconnect_FormattingRow(object sender, RowLoadEventArgs e)
        {
            e.Row.Cells["cargo_type"].FormatStyle = ErrorStyle;
        }

        #endregion

		private void btnRefreshOverHt_Click(object sender, EventArgs e)
		{
			dtOverHeights = ClsIALEDI.GetOverHeightHistory();
			grdOverheight.DataSource = dtOverHeights;
		}

		
	}
}
