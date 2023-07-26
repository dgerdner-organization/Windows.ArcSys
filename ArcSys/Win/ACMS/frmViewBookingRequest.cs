using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using CS2010.CommonReports;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using System.Configuration;
using System.IO;
using ASL.ARC.EDITools;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmViewBookingRequest : frmChildBase, IViewWindow
	{
		#region Main Region
		
		ClsBookingRequestEditControl requestCtrl;
		protected DataTable dtStatusCodes;
		protected DataTable dtVoyages;
		protected ClsBookingUnit CurrentBookingUnit
		{
			get
			{
				DataRow drow = grdCargo.GetDataRow();
				if (drow == null)
					return null;
				ClsBookingUnit bu = new ClsBookingUnit(drow);

				return bu;
			}
		}
		protected ClsBookingCorrespondence CurrentCorrespondence
		{
			get
			{
				try
				{
					DataRow drow = grdCorrespondence.GetDataRow();
					string sID = drow["corr_id"].ToString();
					Int64? lID = ClsConvert.ToInt64Nullable(sID);
					ClsBookingCorrespondence corr = ClsBookingCorrespondence.GetUsingKey(
						lID.GetValueOrDefault(), requestCtrl.theBookingRequest.Partner_Cd, requestCtrl.theBookingRequest.Partner_Request_Cd);
					return corr;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					return null;
				}
			}
		}

		public frmViewBookingRequest(bool showModal) : base()
		{
			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
			InitializeComponent();
		}

		private void InitWindow()
		{
			try
			{

				WindowHelper.InitAllGrids(this);
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetTitle(string AdditionalText)
		{
			this.Text = "Booking Request " + AdditionalText;
		}
		#endregion

		#region View the Object
		private void ViewObject(ClsBookingRequest aRequest)
		{
			try
			{
				requestCtrl = new ClsBookingRequestEditControl();
				
				requestCtrl.theBookingRequest = (aRequest != null && aRequest.Partner_Request_Cd != null)
					? ClsBookingRequest.GetUsingKey(aRequest.Trans_Ctl_No.GetValueOrDefault(), 
								aRequest.Trans_Seq_No.GetValueOrDefault()) : null;

				if (requestCtrl.theBookingRequest == null)
				{
					Program.ShowError("No booking request provided");
					return;
				}

				if (MdiParent == null)
				{
					Show();
				}
				else
					Show();


				// Lock the request
				if (!ClsBookingRequest.LockRequest(requestCtrl.theBookingRequest.Partner_Request_Cd))
					Program.Show("PCFN was not locked; report this to software support.");

				// DropDowns
				dtStatusCodes = ClsAcmsStatus.GetAll();
				cmbStatus.DataSource = dtStatusCodes;
				//dtVoyages = ClsVessel.GetVoyages(360);
				dtVoyages = CS2010.ACMS.Business.ClsVVoyage.GetVoyages(360);
				cmbBookVoyage.DataSource = dtVoyages;
				cmbTerms.DataSource = ClsDropDowns.MoveTypes;

				// Title, etc
				SetTitle(requestCtrl.theBookingRequest.Partner_Request_Cd);
				pnlBookingDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;

				// Enable/Disable Objects
				EnableEditRequest(false);
				EnableEditBooking(false);
				EnableButtons();

				// Bind all data
				BindAudit();
				BindBookingRequest();
				BindMappingErrors();
				BindRDDInfo();

				// Enable certain tabs only if there is relevant data for those tabs
				//    Mapping Errors (only while the status is Pending Corrections
				if (requestCtrl.theBookingRequest.Acms_Status_Cd != ClsAcmsStatus.StatusCodes.PendingCorrections)
					tabMain.TabPages.Remove(tpMapErrors);
				//    RDD Log (only if there are rows in t_booking_rdd)
				if (requestCtrl.theBookingRequest.Booking.RDDLog.Rows.Count < 1)
					tabMain.TabPages.Remove(tpRDD);

				WindowHelper.InitAllGrids(this, true);
                // Enable editing of party state and country
                grdParties.Enabled = true;
                grdParties.AllowEdit = InheritableBoolean.True;
                grdParties.Tables[0].Columns["country_cd"].Selectable = true;
                grdParties.Tables[0].Columns["state"].Selectable = true;

                // EDI Log tab
                GetEDILog();
                GetITVLog();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, requestCtrl.theBookingRequest);
			}
		}

		private void BindBookingRequest()
		{
			try
			{
				requestCtrl.AALPreFills();
				requestCtrl.RefreshBooking();
				requestCtrl.RefreshUnits();

				// Bind Request Data
				BindHelper.Bind(txtBookingNo, requestCtrl.theBookingRequest, "booking_id");
				BindHelper.Bind(txtReqVesselDsc, requestCtrl.theBookingRequest, "vessel_dsc");
				BindHelper.Bind(txtReqPOD, requestCtrl.theBookingRequest, "pod_dsc");
				BindHelper.Bind(txtReqPOE, requestCtrl.theBookingRequest, "poe_dsc");
				BindHelper.Bind(txtReqAvailable, requestCtrl.theBookingRequest, "cargo_avail_dt");
				BindHelper.Bind(txtReqRDD, requestCtrl.theBookingRequest, "rdd_dt");
				BindHelper.Bind(txtReqVoyage, requestCtrl.theBookingRequest, "voyage_no");
				BindHelper.Bind(cmbStatus, requestCtrl.theBookingRequest, "acms_status_cd");
				BindHelper.Bind(txtReqDt, requestCtrl.theBookingRequest, "request_dt");
				BindHelper.Bind(txtReqPCFN, requestCtrl.theBookingRequest, "Partner_Request_Cd");
				BindHelper.Bind(txtReqHazDsc, requestCtrl.theBookingRequest, "Hazmat_Dsc");
				BindHelper.Bind(txtReqHazMatCd, requestCtrl.theBookingRequest, "Hazmat_Cd");
				BindHelper.Bind(txtReqBookerName, requestCtrl.theBookingRequest, "Booker_Name");
				BindHelper.Bind(txtReqPhone, requestCtrl.theBookingRequest, "Booker_Phone");
				BindHelper.Bind(lblProblems, requestCtrl.theBookingRequest, "Problems");
				BindHelper.Bind(cmbTerms, requestCtrl.theBookingRequest, "Move_Type_Cd");
				BindHelper.Bind(txtVoyDoc, requestCtrl.theBookingRequest, "Mil_Voyage_No");
				BindHelper.Bind(txtNotes, requestCtrl.theBookingRequest, "BookingNotes");
				BindHelper.Bind(txtHaxMatContact, requestCtrl.theBookingRequest, "Hazmat_Contact");
				BindHelper.Bind(txtHazMatClass, requestCtrl.theBookingRequest, "Hazmat_Class_Cd");
				BindHelper.Bind(txtHazMatQlfr, requestCtrl.theBookingRequest, "Hazmat_Cd_Qualifier");
                BindHelper.Bind(txtSystem, requestCtrl.theBookingRequest, "OceanSystem");

				// Bind Booking Data
				BindBooking();

				// Get cargo units
				grdCargo.DataSource = requestCtrl.theBookingRequest.BookingUnits;
				if (requestCtrl.theBookingRequest.BookingUnits.Rows.Count > 0)
					grdCargo.Row = 0;

				// Get parties
				if (requestCtrl.theBookingRequest.IsAALBooking)
					grdParties.Visible = false;
				else
					grdParties.DataSource = requestCtrl.theBookingRequest.Parties;

				// get correspondence
				grdCorrespondence.DataSource = requestCtrl.theBookingRequest.Correspondence;

				// Get Transhipment Infor
				grdTShipment.DataSource = requestCtrl.theBookingRequest.TShipment;
				if (requestCtrl.theBookingRequest.TShipment == null ||
					requestCtrl.theBookingRequest.TShipment.Rows.Count < 1)
					grdTShipment.Visible = false;

				// Get Locks
				grdLocks.DataSource = requestCtrl.theBookingRequest.GetLocks();

				EnableButtons();
                grdParties.Enabled = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void BindBooking()
		{
			GetBookingLocations();

			BindHelper.Bind(cmbBookPLOR, requestCtrl.theBookingRequest.Booking, "location_plor_cd");
			BindHelper.Bind(cmbBookPLOD, requestCtrl.theBookingRequest.Booking, "Location_Plod_Cd");
			BindHelper.Bind(cmbPODTerminal, requestCtrl.theBookingRequest.Booking, "Pod_Terminal_Cd");
			BindHelper.Bind(cmbPolTerminal, requestCtrl.theBookingRequest.Booking, "Poe_Terminal_Cd");
			BindHelper.Bind(cmbBookVoyage, requestCtrl.theBookingRequest.Booking, "Voyage_no");
			BindHelper.Bind(txtBookDlvyDsc, requestCtrl.theBookingRequest.Booking, "Delivery_Dsc");
			BindHelper.Bind(txtBookRdd, requestCtrl.theBookingRequest.Booking, "Rdd_Dt");
			BindHelper.Bind(txtBookAdjRdd, requestCtrl.theBookingRequest.Booking, "Adj_Rdd_Dt");
			BindHelper.Bind(txtBookAdjRsn, requestCtrl.theBookingRequest.Booking, "Adj_Rdd_Reason");
		}

		private void BindMappingErrors()
		{
			requestCtrl.dtMapErros = ClsBookingRequestError.GetByISA(requestCtrl.theBookingRequest.Trans_Ctl_No, requestCtrl.theBookingRequest.Trans_Seq_No);
			grdMappingErrors.DataSource = requestCtrl.dtMapErros;
			BindHelper.Bind(txtReleaseNotes, requestCtrl, "ReleaseErrorsNotes");
		}

		private void BindRDDInfo()
		{
			grdRDDLog.DataSource = requestCtrl.theBookingRequest.Booking.RDDLog;

		}

		protected void GetBookingLocations()
		{
			DataTable dtPOL = CS2010.ArcSys.Business.ClsLocation.GetVoyageLocations(requestCtrl.theBookingRequest.Booking.Voyage_No, "L");
			DataTable dtPOD = CS2010.ArcSys.Business.ClsLocation.GetVoyageLocations(requestCtrl.theBookingRequest.Booking.Voyage_No, "D");
			cmbPolTerminal.DataSource = dtPOL;
			cmbPODTerminal.DataSource = dtPOD;
		}

		private void BindAudit()
		{
			try
			{
				grdAudit.DataSource = requestCtrl.theBookingRequest.GetAuditTrail();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdAudit_FetchCellToolTipText(object sender, Janus.Windows.GridEX.FetchCellToolTipTextEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.DataMember, "Audit_User", true) == 0 ||
					string.Compare(e.Column.DataMember, "Audit_Dt", true) == 0)
				{
					string usr = ClsConvert.ToString(e.Row.Cells["Audit_User"].Value);
					DateTime? adt = ClsConvert.ToDateTimeNullable(e.Row.Cells["Audit_Dt"].Value);
					string sdt = (adt != null ) ? adt.Value.ToString("MMMM dd, yyyy a\\t HH:mm:ss") : null;
					e.ToolTipText = "Modified by " + usr + " on " + sdt;
				}
				else if (string.Compare(e.Column.Key, "Old_Data", true) == 0 ||
					string.Compare(e.Column.Key, "New_Data", true) == 0)
				{
					e.ToolTipText = ClsConvert.ToString(e.Row.Cells[e.Column.Key].Value);
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		#endregion

		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return requestCtrl.theBookingRequest; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			ViewObject(bizObject as ClsBookingRequest);
		}

		public void UpdateDisplay()
		{
		}

		#endregion		// #region IViewWindow Interface Implementation

		#region Methods

		#region Helper Methods
		protected void EnableEditRequest(bool bEnable)
		{
			txtBookingNo.ReadOnly = txtReqBookerName.ReadOnly = txtReqPhone.ReadOnly = cmbTerms.ReadOnly
				= txtReqHazDsc.ReadOnly = txtReqHazMatCd.ReadOnly = cmbStatus.ReadOnly = !bEnable;
			btnRequestCancel.Enabled = btnRequestSave.Enabled = bEnable;
		}

		protected void EnableEditBooking(bool bEnable)
		{
			cmbBookPLOD.ReadOnly = cmbBookPLOR.ReadOnly = txtBookAdjRdd.ReadOnly = txtBookAdjRsn.ReadOnly 
				= txtBookDlvyDsc.ReadOnly = btnEditBooking.Enabled = !bEnable;
			btnBookCancel.Enabled = btnSaveBooking.Enabled = bEnable;
			
			// March2019 Allow users to update RDD even after receive government approved delays
			//if (requestCtrl.theBookingRequest.Booking.RDDLog.Rows.Count > 0)
			//{
			//    txtBookAdjRsn.ReadOnly = txtBookAdjRdd.ReadOnly = true;
			//}
		}

		protected void EnableButtons()
		{

			tsAccept.Visible = btnAccept.Enabled = requestCtrl.theBookingRequest.MayAccept;
			tsRequestBooking.Visible = btnRequestBooking.Enabled = 
				tsRequestCounter.Visible = btnRequestCounter.Enabled = 
					requestCtrl.theBookingRequest.MayRequestBooking;
			tsReleaseWaitList.Visible = btnReleaseWait.Enabled = requestCtrl.theBookingRequest.MayReleaseWait;
			btnDecline.Enabled = requestCtrl.theBookingRequest.MayDecline;

		}
		#endregion

		#region Action Methods

		protected void SaveRequestChanges()
		{
			requestCtrl.UpdateRequest();
			if (requestCtrl.HasErrors)
			{
				Program.Show(requestCtrl.Errors);
				return;
			}
            if (requestCtrl.theBookingRequest.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.PendingBooking)
            {
                requestCtrl.theBookingRequest.SendRequestAudit();
            }
			EnableEditRequest(false);
			//Program.Show("Requested Updated.");
			EnableButtons();
			btnRequestCancel.Enabled = btnRequestSave.Enabled = false;
		}

		protected void SaveBookingChanges()
		{
			requestCtrl.UpdateBooking();
			if (requestCtrl.HasErrors)
			{
				Program.Show(requestCtrl.Errors);
				return;
			}
			//Program.Show("booking Updated.");
			EnableEditBooking(false);
		}
		
		private void CheckForErrors()
		{
			if (requestCtrl.HasErrors)
				Program.Show(requestCtrl.Errors);
			if (requestCtrl.theBookingRequest.HasErrors)
				Program.Show(requestCtrl.theBookingRequest.Error);
		}

		private void AcceptBooking()
		{
			using (frmAcceptBooking frm = new frmAcceptBooking())
			{
				if (frm.GetBookingNo(requestCtrl.theBookingRequest.Booking_ID))
				{
					string sBookingNo = frm.BookingNo;
					requestCtrl.theBookingRequest.RequestAccept(sBookingNo);
					BindBookingRequest();
					CheckForErrors();
				}
			}
			DialogResult dr = MessageBox.Show("Would you like to send back some booking notes?", "Notes?", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
				AddConfirmationNotes();
		}

		private void AddConfirmationNotes()
		{
			//
			// Use this to add notes that can be passed back in the 301 confirmation message
			//
			using (frmBookingCorrespondence frm = new frmBookingCorrespondence())
			{
				if (frm.AddCorrespondence(requestCtrl.theBookingRequest, "N"))
				{
					requestCtrl.theBookingRequest.Correspondence = null;
					grdCorrespondence.DataSource = requestCtrl.theBookingRequest.Correspondence;
				}
			}
		}
		private void AddCorrespondence()
		{
			using (frmBookingCorrespondence frm = new frmBookingCorrespondence())
			{
				if (frm.AddCorrespondence(requestCtrl.theBookingRequest))
				{
					requestCtrl.theBookingRequest.Correspondence = null;
					grdCorrespondence.DataSource = requestCtrl.theBookingRequest.Correspondence;
				}
			}
		}

		private void SetDBLogon(ClsReportDocument report)
		{
			string user = null, pwd = null, db = null;
			ClsConnection cn = ClsConMgr.Manager["ACMS"];
			if (cn != null) cn.GetPropertiesFromConnectionString(out user, out pwd, out db);
			if (user.IsNullOrWhiteSpace()) user = "ediuser";
			if (pwd.IsNullOrWhiteSpace()) user = "montvale123";
			if (db.IsNullOrWhiteSpace()) user = "ACMSP";

			ConnectionInfo cnInfo = new ConnectionInfo();
			cnInfo.UserID = user;
			cnInfo.Password = pwd;
			cnInfo.ServerName = db;

			Tables tables = report.Database.Tables;
			foreach (Table table in tables)
			{
				TableLogOnInfo tabInfo = table.LogOnInfo;
				tabInfo.ConnectionInfo = cnInfo;
				table.ApplyLogOnInfo(tabInfo);
			}

			if (report.Subreports.Count > 0)
			{
				foreach (ReportDocument rd in report.Subreports)
				{
					tables = rd.Database.Tables;
					foreach (Table table in tables)
					{
						TableLogOnInfo tabInfo = table.LogOnInfo;
						tabInfo.ConnectionInfo = cnInfo;
						table.ApplyLogOnInfo(tabInfo);
					}
				}
			}
		}

		private void PrintDockReceipt()
		{
			try
			{
				string repName = @"ACMS\rptDockReceipt.rpt";
				ClsReportDocument report = ClsReportHandler.GetReport(repName);
				SetDBLogon(report);

				ParameterField pf1 = report.ParameterFields.Find("P_REQ_CD", null);

				pf1.CurrentValues.Clear();

				pf1.CurrentValues.AddValue(requestCtrl.theBookingRequest.Partner_Request_Cd);

				ClsReportObject ro = new ClsReportObject();
				ro.Title = "Dock Receipt";
				frmCrystalPreview.ShowReport(ro, report, false);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
        private void PrintDockDelivery()
        {
            try
            {
                string repName = @"ACMS\rptDockDelivery.rpt";
                ClsReportDocument report = ClsReportHandler.GetReport(repName);
                SetDBLogon(report);

                ParameterField pf1 = report.ParameterFields.Find("P_REQ_CD", null);

                pf1.CurrentValues.Clear();

                pf1.CurrentValues.AddValue(requestCtrl.theBookingRequest.Partner_Request_Cd);

                ClsReportObject ro = new ClsReportObject();
                ro.Title = "Dock Delivery";
                frmCrystalPreview.ShowReport(ro, report, false);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

		private void PrintRequest()
		{
			try
			{
				string repName = @"ACMS\rptShippingRequest.rpt";
				ClsReportDocument report = ClsReportHandler.GetReport(repName);
				SetDBLogon(report);

				ParameterField pf1 = report.ParameterFields.Find("P_TRANS_CTL_NO", null);
				ParameterField pf2 = report.ParameterFields.Find("P_TRANS_SEQ_NO", null);

				pf1.CurrentValues.Clear();
				pf2.CurrentValues.Clear();

				pf1.CurrentValues.AddValue(requestCtrl.theBookingRequest.Trans_Ctl_No);
				pf2.CurrentValues.AddValue(requestCtrl.theBookingRequest.Trans_Seq_No);

				ClsReportObject ro = new ClsReportObject();
				ro.Title = "Shipping Request";
				frmCrystalPreview.ShowReport(ro, report, false);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewVoyage()
		{
			using (frmSearchVoyages frm = new frmSearchVoyages(CurrentBookingUnit.Voyage_No))
			{
				frm.ShowDialog();
			}
		}

		private void ReleaseFromError()
		{
			if (requestCtrl.ReleaseFromErrors())
			{
				Program.Show("This Booking Request has been released.");
				grdMappingErrors.DataSource = requestCtrl.dtMapErros;
				BindBookingRequest();
				Program.MainWindow.RefreshSearchRequests();
				tabMain.SelectedTab = tpMain;
				return;
			}
			else
			{
				Program.Show(requestCtrl.Errors);
			}
		}

		private void ReleaseFromWait()
		{
			if (requestCtrl.ReleaseFromWaitList())
				Program.Show("Booking has been released from Wait List status");
			CheckForErrors();
			EnableButtons();
		}
		private void DeclineRequest()
		{
			if (requestCtrl.DeclineRequest())
				Program.Show("Booking has been declined");
			CheckForErrors();
			EnableButtons();
		}

        private void GetEDILog()
        {
           
            //grdEDILog.DataSource = request.EDILog;
            grdArcEDILog.DataSource = requestCtrl.theBookingRequest.EDIArcSysLog;
            DataTable api01 = ClsApiLog.GetForDocument(requestCtrl.theBookingRequest.Partner_Request_Cd);
            DataTable api02 = new DataTable();
            if (requestCtrl.theBookingRequest.Booking_ID.IsNotNull())
            {
                api02 = ClsApiLog.GetForDocument(requestCtrl.theBookingRequest.Booking_ID);
                api01.Merge(api02);
            }

            grdOceanAPI.DataSource = api01;
        }
        private void GetITVLog()
        {

            DataTable dtReport = ASL.ARC.EDISQLTools.ClsAcmsSQL.SearchITVHistory(
                "%", "%", "%", "%", false, requestCtrl.theBookingRequest.Partner_Request_Cd,
                "%", "%", "%", "%", false, false, DateRange.Empty);

            grdITVList.DataSource = dtReport;
        }
		#endregion

		#endregion

		#region Events

		private void btnRequestSave_Click(object sender, EventArgs e)
		{
			SaveRequestChanges();
			BindAudit();
		}

		private void btnRequestCancel_Click(object sender, EventArgs e)
		{
			EnableEditRequest(false);

		}

		private void grdCargo_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToLower() == "tcn")
			{
				ClsBookingUnit bu = CurrentBookingUnit;
                bu.Partner_Cd = requestCtrl.theBookingRequest.Partner_Cd;
                bu.Booking_ID = requestCtrl.theBookingRequest.Booking_ID;
                bu.Partner_Request_Cd = requestCtrl.theBookingRequest.Partner_Request_Cd;
                if (bu.IsNull())
                {
                    Program.Show("Does not exist");
                    return;
                }
				ViewWindowManager.View(bu, true);
				BindBookingRequest();
			}
			if (e.Column.DataMember.ToLower() == "voyage_no")
			{
				ViewVoyage();
			}
		}

		private void btnEditRequest_Click(object sender, EventArgs e)
		{
			EnableEditRequest(true);
		}

		private void btnEditBooking_Click(object sender, EventArgs e)
		{
			EnableEditBooking(true);
		}

		private void btnSaveBooking_Click(object sender, EventArgs e)
		{
			SaveBookingChanges();
            grdParties.UpdateMode = UpdateMode.CellUpdate;
            foreach (GridEXRow grow in grdParties.Tables[0].GridEX.GetRows())
            {
                string a = grow.Cells["party_id"].Value.ToString();
                string b = grow.Cells["state"].Value.ToString();
                string c = grow.Cells["country_cd"].Value.ToString();

                requestCtrl.UpdateParties(a, b, c);
            }
			BindAudit();
		}

		private void cmbBookVoyage_ValueChanged(object sender, EventArgs e)
		{
			GetBookingLocations();
		}

		private void btnRelease_Click(object sender, EventArgs e)
		{
			ReleaseFromError();
		}

		private void btnRequestSheet_Click(object sender, EventArgs e)
		{
			PrintRequest();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			AcceptBooking();
			Program.MainWindow.RefreshSearchRequests();
		}

		private void btnCounter_Click(object sender, EventArgs e)
		{
			Program.Show("Not Yet Implemented");
		}

		private void btnRequestBk_Click(object sender, EventArgs e)
		{
			requestCtrl.theBookingRequest.RequestBooking();
			CheckForErrors();
			Program.MainWindow.RefreshSearchRequests();
		}

		private void btnRequestCtr_Click(object sender, EventArgs e)
		{
			requestCtrl.theBookingRequest.RequestBookingCounter();
			CheckForErrors();
		}

		private void btnAddCorr_Click(object sender, EventArgs e)
		{
			AddCorrespondence();
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (requestCtrl.CancelRequest())
				Program.Show("Booking has been cancelled");
			CheckForErrors();
			EnableButtons();
		}

		private void btnWaitRelease_Click(object sender, EventArgs e)
		{
			ReleaseFromWait();
		}

		private void btnDockReceipt_Click(object sender, EventArgs e)
		{
			PrintDockReceipt();
		}
        private void ucButton1_Click_1(object sender, EventArgs e)
        {
            PrintDockDelivery();
        }

		private void btnITV_Click(object sender, EventArgs e)
		{
			frmEDIQuery frm = new frmEDIQuery(requestCtrl.theBookingRequest.Partner_Request_Cd);
			frm.Show();
		}

		private void btnViewEDI_Click(object sender, EventArgs e)
		{

			frmRequestEDILog frm = new frmRequestEDILog();
			frm.ShowForm(requestCtrl.theBookingRequest);
		}
		private void grdCorrespondence_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			if (CurrentCorrespondence == null)
				return;
			using (frmBookingCorrespondence frm = new frmBookingCorrespondence())
			{
				frm.ShowCorrespondence(CurrentCorrespondence);
			}
		}
		private void grdCorrespondence_FetchCellToolTipText(object sender, Janus.Windows.GridEX.FetchCellToolTipTextEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.DataMember, "Corr_Body", true) == 0 ||
					string.Compare(e.Column.DataMember, "Email_To", true) == 0)
				{
					e.ToolTipText = ClsConvert.ToString(e.Row.Cells[e.Column.DataMember].Value);
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}

		private void grdCorrespondence_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
		{
			try
			{
				DataRowView drv = e.Row.DataRow as DataRowView;
				if (drv == null) return;

				string s = ClsConvert.ToString(drv["Corr_Body"]);
				if( s != null ) s = s.Replace("\t", " ").Trim();
				e.Row.Cells["Corr_Body"].Value = s;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}

		private void btnViewLine_Click(object sender, EventArgs e)
		{
            if (requestCtrl.theBookingRequest.OceanSystem == "OCEAN")
            {
                frmLINEQuery frm = new frmLINEQuery(requestCtrl.theBookingRequest.Booking_ID);
                frm.MdiParent = Program.MainWindow;
                frm.Show();
                return;
            }
            ClsBookingLine b = ClsBookingLine.GetByBookingNo(requestCtrl.theBookingRequest.Booking_ID);
			if (b == null)
			{
				// If there is no booking in the warehouse, put the PCFN in the customer ref
				// field so the View Window can find the LINE data directly from the LINE databse.
				b = new ClsBookingLine();
				b.Customer_Ref = requestCtrl.theBookingRequest.Partner_Request_Cd;
				b.Booking_Line_ID = 1;
			}
			ViewWindowManager.View(b);
		}

		private void btnBookCancel_Click(object sender, EventArgs e)
		{
			EnableEditBooking(false);
		}

		private void btnReleaseWait_Click(object sender, EventArgs e)
		{
			ReleaseFromWait();
		}

		private void btnDecline_Click(object sender, EventArgs e)
		{
			DeclineRequest();
		}
		#endregion

		private void btnSynchITV_Click(object sender, EventArgs e)
		{
			if (!requestCtrl.theBookingRequest.SynchITV())
			{
				Program.Show("The synchronization encountered errors");
				Program.Show(requestCtrl.theBookingRequest.Error);
				return;
			}
			Program.Show("ITV data has been synchronized");
		}

		private void frmViewBookingRequest_FormClosed(object sender, FormClosedEventArgs e)
		{
			string s = requestCtrl.theBookingRequest.Partner_Request_Cd;
			if (!ClsBookingRequest.UnlockRequest(s))
				Program.Show("PCFN was not unlocked; report this to software support.");
		}

        private void grpBookedInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ucButton1_Click(object sender, EventArgs e)
        {
            grdParties.Enabled = true;
            grdParties.AllowEdit = InheritableBoolean.True;
            grdParties.Tables[0].Columns["country_cd"].Selectable = true;
            grdParties.Tables[0].Columns["state"].Selectable = true;


        }

        private void grdArcEDILog_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DataRow drow = grdArcEDILog.GetDataRow();
                string sFile = drow["table_dsc"].ToString().Trim();
                string sType = drow["edi_type"].ToString().Trim();
                string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim();
                //ClsOpenEDIFile.OpenFile(sFile, sPartner, sType);
                ClsOpenEDIFile.OpenFileWithFullName(sFile);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void grdCargo_FetchCellToolTipText(object sender, FetchCellToolTipTextEventArgs e)
        {
            try
            {
                if (string.Compare(e.Column.DataMember, "ModFlag", true) == 0 )
                {
                    e.ToolTipText = "";
                    string modFlag = ClsConvert.ToString(e.Row.Cells["ModFlag"].Value);
                    if (modFlag == "A")
                    {
                        e.ToolTipText = "'A' indicates cargo needs to be added to OCEAN";
                    }
                    if (modFlag == "D")
                    {
                        e.ToolTipText = "'D' indicates cargo needs to be deleted from OCEAN because it is no longer on this booking";
                    }
                }

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
            }
        }
	}
}