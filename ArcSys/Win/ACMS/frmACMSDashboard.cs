using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ACMS.Business;
using CS2010.ArcSys.Business;
using ASL.ARC.EDISQLTools;
using Infragistics.Win.Misc;
using System.Net.Sockets;
using System.IO;
using Janus.Windows.GridEX;
using System.Configuration;
using ASL.ITrack.Business;
using ASL.ITrack.WinCtrls;
using CS2010.AVSS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmACMSDashboard : frmChildBase
	{
		public frmACMSDashboard()
		{
			InitializeComponent();
		}


		#region Connection Objects
	
		protected static ClsConnection ConnectionACMS
		{
			get { return ClsConMgr.Manager["ACMSBG"]; }
		}
		protected static ClsConnection ConnectionArcSys
		{
			get { return ClsConMgr.Manager["ArcSysBG"]; }
		}
		protected static ClsConnection ConnectionLINE
		{
			get 
			{
				if (ClsConMgr.Manager["LINE"] == null)
				{
					Program.ConnectToLINE();
				}
				return ClsConMgr.Manager["LINE"]; 
			}
		}
		#endregion

		#region All Fields and Properties

		#region Data Sources
		DataTable dtUnbookedStena;
		DataTable dtAllProblems;
		DataTable dtITVNotSent;
		DataTable dtPortBerthMismatch;
		DataTable dtUnprocessedFiles;
		DataTable dtArriveDepart;
		DataTable dtNoCargo;
		DataTable dtNewRequests;
		DataTable dtCargoMismatch;
		DataTable dtEmails;
		DataTable dtTSDiag;
		DataTable dtNoVessel;
		DataTable dtISAGap;
		//DataTable dtFTPerrors;
		DataTable dtStenaMismatch;
		DataTable dtVesselErrors;
		DataTable dtBadLocations;
		DataTable dtIALsiProblems;
		DataTable dtIALdtlProblems;
		//DataTable dtRemoves;
		DataTable dtIALRemove;
        DataTable dtItrack;

        // DGERDNER 9/2022 : this is obsolete
        //DataTable dtRecall;
		DataTable dtOverht;
		DataTable dtDupeCensus;
		DataTable dtLocationProblems;
        DataTable dtIALSIMissingAddress;
		DataTable dtJobErrors;
		DataTable dtCommAD;
		DataTable dtLinerOutRDD;
		DataTable dtMismatchDims;
		DataTable dtDupeVIN;
        DataTable dtNHTSARecalls;

		#endregion

		#region Timer Objects

		int TimerA_Mins
		{
			get
			{
				if (!HaveDoneARefresh)
				{
					return 5;
				}
				int iMins = 30;
				try
				{
					iMins = ClsConvert.ToInt32(tsRefreshMins.Text);
					return iMins;
				}
				catch (Exception ex)
				{
					Program.ShowError("frmACMSDashboard.TimerA: {0}", ex.Message);
					ClsErrorHandler.LogException(ex);
					return iMins;
				}
			}
		}
		#endregion

		#region Other Fields
		string sTitle = "ACMS Dashboard";
		protected bool CanClose = false;
		protected bool HaveDoneARefresh = false;
		protected int iFailCountA = 0;
		protected int iFailCountB = 0;
		protected int iTotalCountA = 0;
		#endregion

		public TcpClient Server;
		public NetworkStream NetStrm;
		public StreamReader RdStrm;
		public string Data;
		public byte[] szData;
		public string CRLF = "\r\n";
		public StringBuilder Message;

		protected ClsVArcsysMismatch currMismatch
		{
			get
			{
				DataRow drow = grdCargoMismatch.GetDataRow();
				ClsVArcsysMismatch mm = new ClsVArcsysMismatch(drow);
				return mm;
			}
		}

		#endregion

		#region Show Form
		public void ShowForm()
		{
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;
			ClsSecurityMaster.SetSecurity(this);
			expRemoves.Expanded = false;
			expNewRequests.Visible = expISAGaps.Visible = false;
			this.Show();

			// Setup Timer
			_timerA.Interval = MilSecsToMins(TimerA_Mins);
			_timerA.Start();
			_timerB.Interval = MilSecsToMins(600);
			_timerB.Start();

			RefreshA();
			//RefreshB();
		}
		#endregion

		#region Timed Events
		protected int MilSecsToMins(int MilSecs)
		{
			int Mins = MilSecs * 60000;
			return Mins;
		}
		private void TimerA_Tick(object sender, EventArgs e)
		{
			RefreshA();
		}
		private void TimerB_Tick(object sender, EventArgs e)
		{
			//RefreshB();
		}
		#endregion

		#region Background A Stuff
		private void backgroundA_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				string sDays = ConfigurationManager.AppSettings["BadLocationDays"].ToString();
				int iDays = 30;
				if (!string.IsNullOrEmpty(sDays))
					iDays = ClsConvert.ToInt32(sDays);

				dtAllProblems = dtUnbookedStena = dtUnprocessedFiles =
					dtNoCargo = dtNewRequests = dtCargoMismatch = dtISAGap =
					dtITVNotSent = dtEmails = dtPortBerthMismatch =
					dtArriveDepart = dtTSDiag =  null;

                dtNHTSARecalls = ClsNhtsaRecall.DashboardView();
                dtAllProblems = ClsACMSQueries.GetAllProblems(ConnectionACMS);
                string sql = "select * from v_edi_unprocessed where problem_dt between sysdate - 4 and sysdate - .2";
                DataTable dtEDIProblems2 = ConnectionArcSys.GetDataTable(sql);
                dtAllProblems.Merge(dtEDIProblems2);
                dtUnbookedStena = ClsVStenaUnbooked.GetAll(ConnectionACMS);
                dtUnprocessedFiles = ClsACMSQueries.GetUnprocessedEDIFiles(ConnectionACMS);
                dtNoCargo = ClsACMSQueries.GetRequestsWithNoCargo(ConnectionACMS);
                dtNewRequests = ClsBookingRequest.GetNewRequests(ConnectionACMS);
                dtCargoMismatch = ClsVArcsysMismatch.GetAll(ConnectionACMS);
                dtISAGap = ClsEdiActivityFtp.GetISAGaps(ConnectionACMS, "MTM%", "I", 7);
                dtStenaMismatch = ClsArcSQL.GetStenaMismatch(ConnectionArcSys);
                dtVesselErrors = ClsAcmsSQL.GetVesselErrors(ConnectionACMS);
                dtDupeCensus = CS2010.ACMS.Business.ClsLocation.GetDuplicateCensus(ConnectionACMS);
                dtLocationProblems = ClsACMSQueries.GetLocationProblems(ConnectionACMS);
                dtCommAD = ClsCommercialEDIQueries.DashboardArriveDepart(ConnectionArcSys);
                dtMismatchDims = ClsACMSQueries.GetMismatchDims(ConnectionACMS);

                dtITVNotSent = ClsACMSQueries.GetITVNotSent(ConnectionACMS);
                dtPortBerthMismatch = ClsVNitelyPortBerthMismatch.GetAll(ConnectionACMS);
                dtArriveDepart = ClsACMSQueries.GetArriveDepartSchedule(ConnectionACMS, "MTMCIBSD", 5, -.5, "%", true);
                dtTSDiag = ClsArcSQL.GetTShipmentDiagnostics(ConnectionACMS);
                dtNoVessel = ClsACMSQueries.GetMissingVessel(ConnectionACMS);
                dtBadLocations = ClsArcSQL.GetBadLocationList(ConnectionArcSys, iDays);
                dtIALsiProblems = ClsEdiInboundSi.MisMatchedVINS(ConnectionArcSys);
                //dtIALdtlProblems = ClsEdiInboundDetail.GetAllUnprocessed(60);
                dtIALdtlProblems = ClsEdiInboundDetail.GetAllDashboard(30);
                dtIALRemove = ClsEdiInboundRemove.GetUnprocessed(ConnectionArcSys);
                dtIALSIMissingAddress = ClsEdiInboundSi.ShippingInstructionsMissingAddress(ConnectionArcSys);
                dtLinerOutRDD = ClsAcmsSQL.GetDashboardLinerOutRDD(ConnectionACMS);
                dtDupeVIN = ASL.ARC.EDISQLTools.ClsLineSQL.GetDupeVIN(ConnectionLINE);

                //dtFTPerrors = ClsEdiActivityFtp.GetFTPerrors();
                //dtJobErrors = CS2010.ArcSys.Business.ClsJobError.GetAll();
                //dtIALdtlProblems = ClsEdiInboundDetail.GetUnprocessed(ConnectionArcSys, false, 60, null, null,"LINE");


                //dtRecall = ClsIALEDI.GetIALRecalls(ConnectionArcSys);
                dtOverht = ClsIALEDI.GetOverHeights(ConnectionArcSys);
				iTotalCountA++;

			}
			catch (Exception ex)
			{
				iFailCountA++;
				Program.ShowError("frmACMSDashboard.DoWorkA: {0}", ex.Message);
			}
		}

		private void backgroundA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				_timerA.Interval = MilSecsToMins(TimerA_Mins);
				_timerA.Start();

                grdNHTSARecalls.DataSource = dtNHTSARecalls;
                expNHTSARecall.Expanded = dtNHTSARecalls.Rows.Count > 0;
                grdAllProblems.DataSource = dtAllProblems;
                grdUnprocessedFiles.DataSource = dtUnprocessedFiles;
                grdCargoMismatch.DataSource = dtCargoMismatch;
                grdNoVessel.DataSource = dtNoVessel;
                grdISAGaps.DataSource = dtISAGap;
                grdVesselErrors.DataSource = dtVesselErrors;
                grdMismatchDims.DataSource = dtMismatchDims;
                expEDIProblems.Expanded = dtAllProblems.Rows.Count > 0;
                expUnprocessedFiles.Expanded = dtUnprocessedFiles.Rows.Count > 0;
                expGBMismatch.Expanded = (dtCargoMismatch.Rows.Count > 0);
                expNoVessel.Expanded = dtNoVessel.Rows.Count > 0;

                grdITVNotSent.DataSource = dtITVNotSent;
                grdPortBerthMismatch.DataSource = dtPortBerthMismatch;
                grdArriveDepart.DataSource = dtArriveDepart;
                grdNewRequests.DataSource = dtNewRequests;
                grdTSDiag.DataSource = dtTSDiag;
                grdBadLocations.DataSource = dtBadLocations;
                grdUnprocessedDetail.DataSource = dtIALdtlProblems;
                grdIALRemove.DataSource = dtIALRemove;
                expMismatchDims.Expanded = dtMismatchDims.Rows.Count > 0;
                grdOverheight.DataSource = dtOverht;
                expOverheight.Expanded = dtOverht.Rows.Count > 0;
                //grdRecalls.DataSource = dtRecall;
                grdRecalls.Visible = false;
                expRecall.Visible = false;
                grdLocationProblems.DataSource = dtLocationProblems;
                grdIALSIMissingAddress.DataSource = dtIALSIMissingAddress;

                expITVNotXmit.Expanded = dtITVNotSent.Rows.Count > 0;
                expPortBerthMismatch.Expanded = dtPortBerthMismatch.Rows.Count > 0;
                expArriveDepart.Expanded = dtArriveDepart.Rows.Count > 0;
                expNewRequests.Expanded = dtNewRequests.Rows.Count > 0;
                expTSDiag.Expanded = dtTSDiag.Rows.Count > 0;
                expISAGaps.Expanded = dtISAGap.Rows.Count > 0;
                expBadLocations.Expanded = dtBadLocations.Rows.Count > 0;
                grpIALDetails.Expanded = dtIALdtlProblems.Rows.Count > 0;
                //expRecall.Expanded = dtRecall.Rows.Count > 0;
                expRemoves.Expanded = dtIALRemove.Rows.Count > 0;
                expLocationProblems.Expanded = dtLocationProblems.Rows.Count > 0;
                expIALSIMissingAddress.Expanded = dtIALSIMissingAddress.Rows.Count > 0;

                //DGERDNER July 2021 Disabled this because we no longer have access to LINE database
                grdLinerOutRDD.DataSource = dtLinerOutRDD;
                expLinerOutRDD.Expanded = dtLinerOutRDD.Rows.Count > 0;

                //// Obsolete
                //grdFTPerrors.DataSource = dtFTPerrors;
                //expDupeCensus.Expanded = dtDupeCensus.Rows.Count > 0;
                //grdIALsi.DataSource = dtIALsiProblems;
                //expVesselErrors.Expanded = dtVesselErrors.Rows.Count > 0;
                //grdDupeCensus.DataSource = dtDupeCensus;
                ////

				txtRefreshA.Text = string.Format(@"Last Refreshed {0}       (failures:{1} success:{2} )",
					DateTime.Now.ToLongTimeString(), iFailCountA, iTotalCountA);
				int iCount = ErrorCount();
				this.Text = sTitle;
				// Only display an Alert if this is NOT the first time.  Do this because otherwise
				// the user sees the Alert window everytime they open the application, which might
				// get annoying.
				if (iCount > 0 && HaveDoneARefresh)
				{
					this.Text = string.Format(@"{0} ({1})", sTitle, iCount);
					UltraDesktopAlertShowWindowInfo info = new UltraDesktopAlertShowWindowInfo("Warning", "Dashboard Messages!");
					info.ScreenPosition = ScreenPosition.TopRight;
					info.PinButtonVisible = true;
					info.Pinned = false;
					ultraDesktopAlert1.Show(info);
				}
				HaveDoneARefresh = true;

			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Program.ShowError("frmACMSDashboard.WorkCompletedA: {0}", ex.Message);
				iFailCountA++;
			}
			finally
			{
				txtRefreshA.Text = string.Format(@"Last Refreshed {0}       (failures:{1} success:{2} )",
						DateTime.Now.ToLongTimeString(), iFailCountA, iTotalCountA);

			}
		}

		void RefreshA()
		{
			try
			{
				if (backgroundA.IsBusy) return;

				backgroundA.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.ShowError("frmACMSDashboard.RefreshA: {0}", ex.Message);
			}
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
			RefreshA();
		}
		#endregion

		#region Background B Stuff
		void backgroundB_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Program.ShowError("frmACMSDashboard.BrackgroundB: {0}", ex.Message);
				iFailCountB++;
			}


		}

		void backgroundB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{


				txtRefreshB.Text = string.Format(@"Last Refreshed {0}       (failures:{1})",
					DateTime.Now.ToLongTimeString(), iFailCountB);
				int iCount = ErrorCount();
				this.Text = sTitle;
				if (iCount > 0)
					this.Text = string.Format(@"{0} ({1})", sTitle, iCount);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				iFailCountB++;
			}
		}

		void RefreshB()
		{
			try
			{
				backgroundB.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}
		}

		#endregion

		#region Common Methods
		int ErrorCount()
		{
			int iCount = 0;
			if (dtAllProblems != null)
				iCount = iCount + dtAllProblems.Rows.Count;
			if (dtUnbookedStena != null)
				iCount = iCount + dtUnbookedStena.Rows.Count;
			if (dtITVNotSent != null)
				iCount = iCount + dtITVNotSent.Rows.Count;
			if (dtPortBerthMismatch != null)
				iCount = iCount + dtPortBerthMismatch.Rows.Count;
			if (dtUnprocessedFiles != null)
				iCount = iCount + dtUnprocessedFiles.Rows.Count;
			if (dtNoCargo != null)
				iCount = iCount + dtNoCargo.Rows.Count;
			if (dtArriveDepart != null)
				iCount = iCount + dtArriveDepart.Rows.Count;
			if (dtNewRequests != null)
				iCount = iCount + dtNewRequests.Rows.Count;
			if (dtEmails != null)
				iCount += dtEmails.Rows.Count;

			return iCount;
		}

		#endregion

		#region Events

		#region Hyperlinks

		private void grdPortBerthMismatch_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdPortBerthMismatch.CurrentRow, e.Column.Key);
		}

		private void grdStenaUnbooked_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			//Program.LinkHandler.HandleLink(grdStenaUnbooked.CurrentRow, e.Column.Key);
		}

		private void grdAllProblems_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdAllProblems.CurrentRow, e.Column.Key);
		}

		private void grdArriveDepart_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				DataRow drow = grdArriveDepart.GetDataRow();
				string sVoyageNo = drow["voyageno"].ToString();
				frmSDDCArriveDepart.ShowWindow(5, 3, sVoyageNo, true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdAALNoCargo_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			//Program.LinkHandler.HandleLink(grdAALNoCargo.CurrentRow, e.Column.Key);
		}

		private void grdNewRequests_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				DataRow drow = grdNewRequests.GetDataRow();
				ClsBookingRequest br = new ClsBookingRequest(drow);
				ViewWindowManager.View(br);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}






		private void grdCargoMismatch_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdCargoMismatch.CurrentRow, e.Column.Key);
		}

		private void grdITVNotSent_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToLower() == "tcn")
			{
				string sBookingNo = grdITVNotSent.GetDataRow()["booking_id"].ToString();
				string sTCN = grdITVNotSent.GetDataRow()["tcn"].ToString();
				ClsBookingUnit bu = ClsBookingUnit.GetByTCN(sBookingNo, sTCN);
				ViewWindowManager.View(bu, true);
			}
			if (e.Column.DataMember.ToLower() == "partner_request_cd")
				Program.LinkHandler.HandleLink(grdITVNotSent.CurrentRow, e.Column.Key);
		}

		private void grdNoVessel_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdNoVessel.CurrentRow, e.Column.Key);
		}

		private void grdISAGaps_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"EDI messages are each assigned a unique, sequential ISA#.  Under normal circumstances");
			sb.AppendFormat(@" there will be no 'gaps' in the numbering of theses numbers.  If something shows up here");
			sb.AppendFormat(@" it indicates we are missing the listed ISA#'s. ");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendFormat("IT Support should be notified so they can check to see if ");
			sb.AppendFormat(@"one of the files we received from our trading partner did not process.");
			Program.Show(sb.ToString());

		}

		private void grdFTPerrors_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			frmScanFilesEDI.ShowWindow();
		}

		private void grdVesselErrors_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			string sVessel = grdVesselErrors.CurrentRow.Cells[e.Column].Value.ToString();
			frmVesselMaintenance.ShowMaintenance(sVessel);
		}

		private void grdLocationProblems_LinkClicked(object sender, ColumnActionEventArgs e)
		{

			try
			{
				string s = grdLocationProblems.CurrentRow.Cells["location_cd"].Value.ToString();
				frmLocationTerminalMaintenance.ShowMaintenance(s);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdLinerOutRDD_LinkClicked_1(object sender, ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdLinerOutRDD.CurrentRow, e.Column.Key);
		}
		#endregion

		#region Other events

		private void grdJobErrors_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			DeleteJobError();
		}

		private void tsRefresh_Click(object sender, EventArgs e)
		{
			RefreshA();
		}

		private void frmACMSDashboard_FormClosing(object sender, FormClosingEventArgs e)
		{
			// If the main form is closing, then go ahead and close this window.
			// Otherwise ask the user to verify that they really want to close
			// the dashboard.  NOTE:  Window will not close by user simply clicking the "X"
			// they have to use the Close button.
			if (e.CloseReason != CloseReason.MdiFormClosing)
			{
				if (this.CanClose)
				{
					DialogResult dr = MessageBox.Show("Are you sure you want to close the ACMS Dashboard?", "Confirm", MessageBoxButtons.YesNo);
					if (dr == DialogResult.No)
						e.Cancel = true;
				}
				else
					e.Cancel = true;
			}
		}

		private void tsClose_Click(object sender, EventArgs e)
		{
			if (backgroundA.IsBusy) return;
			CanClose = true;
			this.Close();
		}

		private void tsRefreshMins_TextChanged(object sender, EventArgs e)
		{
			int iMinsA = ClsConvert.ToInt32(tsRefreshMins.Text);
			_timerA.Interval = MilSecsToMins(iMinsA);
		}

		private void tsRefreshMins_Click(object sender, EventArgs e)
		{
			//_timerA.Interval = MilSecsToMins(TimerA_Mins);
		}


		#endregion

		#endregion

		#region Email Methods
		private void GetEmail()
		{
			

			try
			{
				Server = new TcpClient("172.16.1.1", 110);

				// initialization
				NetStrm = Server.GetStream();
				RdStrm = new StreamReader(Server.GetStream());
				//Status.Items.Add(RdStrm.ReadLine());
				string s = RdStrm.ReadLine();

				// Login Process
				Data = "USER " + "acms" + CRLF;
				szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
				NetStrm.Write(szData, 0, szData.Length);
				//Status.Items.Add(RdStrm.ReadLine());
				s = RdStrm.ReadLine();

				Data = "PASS " + "acmsit" + CRLF;
				szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
				NetStrm.Write(szData, 0, szData.Length);
				//Status.Items.Add(RdStrm.ReadLine());
				s = RdStrm.ReadLine();

				// Send STAT command to get information ie: number of mail and size
				Data = "STAT" + CRLF;
				szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
				NetStrm.Write(szData, 0, szData.Length);
				//Status.Items.Add(RdStrm.ReadLine());
				s = RdStrm.ReadLine();


				// back to normal cursor
				//Cursor.Current = cr;

				RetrieveEmail();
			}
			catch (InvalidOperationException err)
			{
				string x = err.Message;
			}

		}

		private void RetrieveEmail()
		{
			// change cursor into wait cursor
			Cursor cr = Cursor.Current;
			//Cursor.Current = Cursors.WaitCursor;
			string szTemp;
			Message = new StringBuilder();
			try
			{
				// retrieve mail with number mail parameter
				Data = "RETR " + "1";
				szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
				NetStrm.Write(szData, 0, szData.Length);

				szTemp = RdStrm.ReadLine();
				if (szTemp[0] != '-')
				{

					while (szTemp != ".")
					{
						Message.AppendLine(szTemp);
						szTemp = RdStrm.ReadLine();
					}
				}
				else
				{
					//Status.Items.Add(szTemp);
				}

				// back to normal cursor
				Cursor.Current = cr;

			}
			catch (InvalidOperationException err)
			{
				Program.Show(err.Message);
				//Status.Items.Add("Error: "+err.ToString());
			}

		}
		#endregion

		#region IAL Removes
		private void grdRemoves_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			string sBookingNo = grdIALRemove.CurrentRow.Cells[e.Column].Value.ToString();
			frmLINEQuery frm = new frmLINEQuery(sBookingNo);
			frm.MdiParent = Program.MainWindow;
			frm.Show();
		}
		private void grdRemoves_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				// Flag as Completed
				GridEXRow grow = grdIALRemove.CurrentRow;
				string sID = grow.Cells["edi_inbound_remove_id"].Value.ToString();
				long lID = ClsConvert.ToInt64(sID);
				ClsEdiInboundRemove rem = ClsEdiInboundRemove.GetUsingKey(lID);
				if (rem == null)
					return;
				string s = e.Column.Key;
				if (s.ToUpper().Contains("IGNORE"))
					IgnoreRemove(rem);
				else
					ProcessRemove(rem);

				// refresh
				dtIALRemove = ClsEdiInboundRemove.GetUnprocessed();
				grdIALRemove.DataSource = dtIALRemove;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ProcessRemove(ClsEdiInboundRemove rem)
		{
			try
			{
				DialogResult dr = MessageBox.Show("Flag that VIN has processed?", "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					return;
				rem.SetProcessed(true);
				ClsEmail em = new ClsEmail();
				em.From = "helpdesk@amslgroup.com";
				//em.AddTo("dgerdner@gmail.com");
				em.AddTo("arccustomerservice@amslgroup.com");
				em.AddCC("dgerdner@amslgroup.com");
				em.Subject = "IAL Remove Cargo";
				em.Body = string.Format("VIN {0} needs to be removed from booking {1} (Source: IAL 'Remove' message)", rem.Vin, rem.Booking_No);
				//em.SendMail();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void IgnoreRemove(ClsEdiInboundRemove rem)
		{
			DialogResult dr = MessageBox.Show("Take this off of the Dashboard?", "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;
			rem.SetProcessed(true);
		}

		private void btnCompleteAll_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dr = MessageBox.Show("Flag all selected cars as processed?", "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					return;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow drow in grdIALRemove.GetCheckedDataRows())
				{
					ClsEdiInboundRemove rem = new ClsEdiInboundRemove(drow);
					rem.SetProcessed(true);
					sb.AppendFormat("VIN {0} needs to be removed from booking {1} (Source: IAL 'Remove' message)", rem.Vin, rem.Booking_No);
					sb.AppendLine(".");
				}
				ClsEmail em = new ClsEmail();
				em.From = "helpdesk@amslgroup.com";
				em.AddTo("arccustomerservice@amslgroup.com");
				em.AddCC("dgerdner@amslgroup.com");
				em.Subject = "IAL Remove Cargo";
				em.Body = sb.ToString();
				//em.SendMail();

				dtIALRemove = ClsEdiInboundRemove.GetUnprocessed();
				grdIALRemove.DataSource = dtIALRemove;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnIgnoreAll_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dr = MessageBox.Show("Take all selected cars off of the Dashboard?", "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
					return;
				foreach (DataRow drow in grdIALRemove.GetCheckedDataRows())
				{
					ClsEdiInboundRemove rem = new ClsEdiInboundRemove(drow);
					rem.SetProcessed(true);
				}
				dtIALRemove = ClsEdiInboundRemove.GetUnprocessed();
				grdIALRemove.DataSource = dtIALRemove;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion

		#region Job Error Delete
		private void DeleteJobError()
		{
		}
		#endregion

		#region IAL Recalls

		//private void RefreshRecalls()
        //{
        //    ClsIALEDI ial = new ClsIALEDI();

        //    dtRecall = ClsIALEDI.GetIALRecalls();
        //    grdRecalls.DataSource = dtRecall;
        //    expRecall.Expanded = dtRecall.Rows.Count > 0;
        //}

        #endregion

        #region Issue Tracking

        //private void RefreshItrack()
        //{
        //    dtItrack = ClsIssue.SearchIssues(new IssueParams() { ProjectCds = "ARCSYS", Action_Owners = ClsEnvironment.UserName }); //Environment.UserName
        //    grdItrack.DataSource = dtItrack;
        //    expItrack.Expanded = dtItrack.Rows.Count > 0;
        //}

        private void ItrackAction(string action)
        {
			//try
			//{
			//    DataRow dr = (DataRow)grdItrack.GetDataRow();
			//    ClsIssue i = ClsIssue.GetUsingKey(dr[0].ToLong());

			//    if (action == "VIEW")
			//    {
			//        frmViewIssue vi = new frmViewIssue();
			//        vi.ViewIssue(i);
			//    }
			//    else
			//    {
			//        frmEditIssue ei = new frmEditIssue();
			//        ei.Edit(i);
			//        grdItrack.DataSource = ClsIssue.SearchIssues(new IssueParams() { ProjectCds = "ARCSYS", Action_Owners = ClsEnvironment.UserName }); //Environment.UserName
			//        expItrack.Expanded = ((DataTable)grdItrack.DataSource).Rows.Count > 0;
			//    }
			//}
			//catch (Exception ex)
			//{
			//    Program.ShowError(ex);
			//}
        }

        private void grdItrack_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            ItrackAction(e.Column.Key);
        }

        #endregion
		
        #region Recalls

        private void ReviewRecall()
        {
            try
            {
                DataRow dr = (DataRow)grdRecalls.GetDataRow();

                if (dr.IsNull())
                {
                    MessageBox.Show("Nothing to do.");
                    return;
                }

                string v = dr["VIN"].ToString();

                if (v.IsNullOrWhiteSpace())
                {
                    MessageBox.Show("Nothing to do.");
                    return;
                }

                if (MessageBox.Show(
                    "The VIN '" + v + "' will be removed from the Dashboard as it has been 'Reviewed'.  Are you sure you want to proceed?",
                    "Reviewed?", 
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                ClsRecallVin vinRecall = new ClsRecallVin() { Vin = v };
                //if (vinRecall.Insert() == 1)
                //{
                //    dtRecall = ClsIALEDI.GetIALRecalls(ConnectionArcSys);
                //    grdRecalls.DataSource = dtRecall;
                //    grdRecalls.Refresh();
                //}
         
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
            }
        }

        private void grdRecalls_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            //ReviewRecall();
            Program.Show("This function has been disabled September 2022");
        }
		
        #endregion

		#region Over Heights Vehicles

		private void ReviewOverht()
		{
			try
			{
				DataRow dr = (DataRow)grdOverheight.GetDataRow();

				if (dr.IsNull())
				{
					MessageBox.Show("Nothing to do.");
					return;
				}

				string v = dr["VIN"].ToString();
				if (v.IsNullOrWhiteSpace())
				{
					MessageBox.Show("Nothing to do.");
					return;
				}

				string sID = dr["edi_inbound_overht_id"].ToString();
				if (sID.IsNullOrWhiteSpace())
				{
					MessageBox.Show("Error; no valid detail ID was found.");
					return;
				}
				long lID = ClsConvert.ToInt32(sID);

				if (MessageBox.Show(
					"The VIN '" + v + "' will be removed from the Dashboard as it has been 'Reviewed'.  Are you sure you want to proceed?",
					"Reviewed?",
					MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
				{
					return;
				}

				ClsEdiInboundOverht oh = ClsEdiInboundOverht.GetUsingKey(lID);
				if (oh == null)
				{
					Program.Show("There was an error finding this over height information.  Contact system support.");
				}
				oh.Processed_Flg = "Y";
				oh.Update();
				dtOverht = ClsIALEDI.GetOverHeights(ConnectionArcSys);
				grdOverheight.DataSource = dtOverht;
				grdOverheight.Refresh();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdOverht_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			ReviewOverht();
		}

		#endregion


        private void RefreshACMSLINEDimension()
        {
            dtMismatchDims = ClsACMSQueries.GetMismatchDims(ConnectionACMS);
            grdMismatchDims.DataSource = dtMismatchDims;
            lblRefreshACMSLINE.Text = "Refreshed at " + DateTime.Now.ToLongTimeString();
        }


        #region Events
        private void grdCargoMismatch_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			MismatchACMSUpdate();
		}
		private void MismatchACMSUpdate()
		{
			string sMsg = string.Format(@"Pressing this button assumes the data in LINE is correct.  It will update the ACMS voyage and ports with the data in LINE.  Is this what you want to do? ");
			try
			{
				DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
				if (dr == System.Windows.Forms.DialogResult.Cancel)
				{
					Program.Show("Action cancelled by user.  Nothing was updated.");
					return;
				}
				ClsVArcsysMismatch mm = currMismatch;
				ClsBookingUnit bu = ClsBookingUnit.GetUsingKey("MTMCIBSD", mm.Partner_Request_Cd, mm.Item_No.GetValueOrDefault());
				if (bu == null)
				{
					Program.Show("Could not find ACMS data.");
					return;
				}
				bu.Pod_Location_Cd = mm.Line_Pod;
				bu.Pod_Terminal_Cd = mm.Line_Pod_Berth;
				bu.Poe_Location_Cd = mm.Line_Pol;
				bu.Poe_Terminal_Cd = mm.Line_Pol_Berth;
				
				// Find the VoyDoc
				ClsVesselMilitaryVoyage vmv = ClsVesselMilitaryVoyage.GetByVoyageBerth(mm.Line_Voyage_No, bu.Poe_Terminal_Cd);
				if (vmv == null)
				{
					Program.Show("Could not find VoyDoc for {0} {1}. Update Failed.", mm.Line_Voyage_No, bu.Poe_Terminal_Cd);
					return;
				}
				if (string.IsNullOrEmpty(vmv.Military_Voyage_No))
				{
					Program.Show("Could not find VoyDoc for {0} {1}. Update failed.", mm.Line_Voyage_No, bu.Poe_Terminal_Cd);
					return;
				}
				bu.Mil_Voyage_No = vmv.Military_Voyage_No;

				// Construct the Voyage Number
				bu.Voyage_No = mm.Line_Voyage_No;
				if (!string.IsNullOrEmpty(vmv.Military_Voyage.Suffix))
					bu.Voyage_No = bu.Voyage_No + vmv.Military_Voyage.Suffix;
				bu.Voyage = null;
				if (bu.Voyage == null)
				{
					Program.Show("Could not find voyage {0}. Update failed.", bu.Voyage_No);
					return;
				}

				// Remove the row from the Grid
				DataRow drow = grdCargoMismatch.GetDataRow();
				dtCargoMismatch.Rows.Remove(drow);

				// Update
				bu.Update();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdMismatchDims_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			string sMsg = string.Format(@"Pressing this button assumes the data in LINE is correct.  It will update the ACMS dimensions with the data in LINE.  Is this what you want to do? ");
			try
			{
				Program.MainWindow.ShowDimsSynch();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdMismatchDims_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdMismatchDims.CurrentRow, e.Column.Key);
		}

		private void ucButton1_Click_1(object sender, EventArgs e)
		{

		}

        private void grdNHTSARecalls_FormattingRow(object sender, RowLoadEventArgs e)
        {       
            GridEXFormatStyle ErrorStyle = new GridEXFormatStyle() { BackColor = Color.Red, ForeColor = Color.White };
            GridEXFormatStyle NormalStyle = new GridEXFormatStyle() { BackColor = Color.White, ForeColor = Color.Black };

            e.Row.Cells["recall_risk_dsc"].FormatStyle = 
                ((e.Row.Cells["recall_risk_dsc"].Text == "L1") || (e.Row.Cells["recall_risk_dsc"].Text == "L2")) ? 
                ErrorStyle : NormalStyle;
        }

        private void grdNHTSARecalls_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)grdNHTSARecalls.CurrentRow.DataRow;

                frmNHTSARecall nr = new frmNHTSARecall();

                string voyage = drv["VOYAGE"].ToString();
                string pol = drv["LOCATION_CD"].ToString();
                string recall_level = drv["RECALL_RISK_CD"].ToString();
                
                nr.MdiParent = this.MdiParent;
                nr.ShowOpen(voyage, pol, recall_level);

            }
            catch (Exception)
            {

                throw;
            }

            
        }

		private void btnMarkAll_MouseHover(object sender, EventArgs e)
		{

		}

        private void btnRefreshACMSLINEDimension_Click(object sender, EventArgs e)
        {
            RefreshACMSLINEDimension();
        }

        private void btnUnprFiles_Click(object sender, EventArgs e)
        {
            Program.Show("These are EDI files that failed.  You should use the EDI Monitor to see what the problem is");
        }

        private void btnITVNotTrans_Click(object sender, EventArgs e)
        {
            Program.Show("SDDC ITV data that has not been transmitted.  This is an urgent issue that needs to be resolve quickly.  It usually is caused by some bad data in the booking");
        }

        private void btnNewRequests_Click(object sender, EventArgs e)
        {
            Program.Show("New booking requests from SDDC have been received that have not yet been handled.  See the ACMS Booking Requests window.");
        }

        private void ucButton1_Click_2(object sender, EventArgs e)
        {
            Program.Show("A voyage has been created in AVSS that has a vessel which does not exist in the ACMS vessel table.  Use the ACMS reference tables window to add the vessel.");
        }

        private void ucButton2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("This is a list of bookings where the Voyage/Port data in ACMS does not match the booking in our liner system.  If we assume our liner system (the system of record) is correct, you can use the Update ACMS button to copy the liner data into our ACMS booking request.");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("NOTE: This compares ACMS to our data warehouse.  It does not look directly into our ocean system.");
            Program.Show(sb.ToString());
        }

        private void btnPortMismatch_Click(object sender, EventArgs e)
        {
            Program.Show("These are SDDC bookings in which one of the port/berths is not on the assigned voyage.");
        }
        private void btnArriveDepartWarning_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("These are voyages in which the Arrive or Depart date has arrive, but VA or VD ITV messages have not been generated.");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Possible reasons include:  The arrival departure has not been flagged in AVSS, or there is a mismatch in the ocean system data and ACMS.");
            Program.Show(sb.ToString());

        }

        private void ucButton3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("These are SDDC bookings in which the dimensions in our data warehouse does not match what is in ACMS.  These need to be kept synchronized.");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("The UPDATE button does not immediately update anything.  It opens a window that allows you to decide how to synchronize the data.");
            Program.Show(sb.ToString());
        }

        private void btnLinerOutRDD_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("These are SDDC Liner bookings in which the RDD is approaching or has past, but we have not sent both the OA and X1 ITV messages.");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("It might indicate the Vessel Arrive has not been flagged in AVSS for the POD.");
            Program.Show(sb.ToString());
        }

        private void btnIALOverHt_Click(object sender, EventArgs e)
        {
            Program.Show("This lists  all IAL vehicles with a height over 195cm.  Pressing the Reviewed button simply removes the cargo from the Dashboard, it doesn't change the cargo in any way.");
        }
        #endregion

        private void btnEDIProblems_Click(object sender, EventArgs e)
        {
            SearchWindowManager.Search<frmSearchEDI>();
        }




    }
}