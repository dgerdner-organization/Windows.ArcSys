using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.Common;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;

namespace CS2010.ArcSys.Win
{
    public partial class frmLINEQuery : frmChildBase, ISearchWindow
    {
        #region Main Region
        private DataTable dtCargo;
		private DataTable dtOcean;
        private List<ClsVwArcBolHeader> lstOceanBol;
        private bool ShowOneBooking { get; set; }

		private string OceanSystem
		{
			get
			{
				if (rbLINE.Checked)
					return "LINE";
                if (rbOceanBOLs.Checked)
                    return "OCEANBOLS";
				return "OCEAN";
			}
		}
        private string VoyageNo
        {
            get
            {
                if (string.IsNullOrEmpty(txtVoyage.Text))
                    return "%";
                return txtVoyage.Text;
            }
        }
        private string BookingNo
        {
            get
            {
                string s = txtBookingNo.Text;
                if (string.IsNullOrEmpty(s))
                    return "%";
                return s;
            }
        }
        private string BolNo
        {
            get
            {
                string s = txtBolNo.Text;
                if (string.IsNullOrEmpty(s))
                    return "%";
                return s;
            }
        }
        private string tcn
        {
            get
            {
                string s = txtTCN.Text;
                return s;
            }
        }
		private string POL
		{
			get { return cmbPOL.SelectedLocationCD; }
		}
		private string POD
		{
			get { return cmbPOD.SelectedLocationCD; }
		}
        public frmLINEQuery()
            : base()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            WindowHelper.InitAllGrids(this);
            ShowOneBooking = false;
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

		public frmLINEQuery(string sBookingNo)
			: base()
		{
			InitializeComponent();
			AdjustForm(Program.MainWindow, true, null);
			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			txtBookingNo.Text = sBookingNo;
            ShowOneBooking = true;
			PerformSearch();
		}

        public void RefreshResults()
        {
            throw new NotImplementedException();
        }

        public void ShowSearch(bool showOptions)
        {
            return;
        }

        #endregion

        #region Search Methods

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

        private TimeSpan ElapsedTime;

        private void StartSearch()
        {
            try
            {
                AsynchConnectionKey = "LINE";
                DateTime start = DateTime.Now;
                ClsImportLine q = new ClsImportLine();
				if (OceanSystem == "LINE")
				{
					dtCargo = q.QueryLINEData(VoyageNo, BookingNo, txtTCN.Text, false, POL, POD);
				}
				else
				{
                    SearchOceanBookingParms p = new SearchOceanBookingParms();
                    p.BookingNo = BookingNo;
                    p.BolNo = BolNo;
                    p.PolCd = POL;
                    p.PodCd = POD;
                    p.SerialNo = tcn;
                    p.VoyageNo =VoyageNo;
                    if (OceanSystem == "OCEAN")
                    {
                        dtOcean = ClsVwArcBookingHeader.SearchOceanBookings(p);
                    }
                    if (OceanSystem == "OCEANBOLS")
                    {
                        lstOceanBol = ClsVwArcBolHeader.SearchOceanBols(p);
                    }
				}
			

                TimeSpan time = DateTime.Now - start;
                lock (grdCargo)
                {
                     ElapsedTime = time;
                }
 
            }
            catch (Exception ex)
            {
                if (ex.Message.
                    IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0 &&
                    ex.Message.IndexOf("should be discarded", StringComparison.InvariantCultureIgnoreCase) < 0)
                    Program.ShowError(ex);
                else
                    Program.ShowError("Search cancelled by user");
            }
            finally
            {
                AsynchronousProcessComplete = true;
                AsynchConnectionKey = null;
            }
        }

        private void UpdateGrid()
        {
            try
            {
                AdjustGUI(true);

                if (dtCargo != null)
                {
                    lock (grdCargo)
                    {
                        try
                        {
                            grdCargo.DataSource = dtCargo;
                            if (dtCargo.Rows.Count > 0)
                                grdCargo.Focus();
                        }
                        catch (Exception ex)
                        {
                            Program.ShowError(ex);
                        }
                    }
                }
                if (dtOcean != null)
                {
                    lock (grdOceanMain)
                    {
                        try
                        {
                            grdOceanMain.DataSource = dtOcean;
                            if (dtOcean.Rows.Count > 0)
                                grdOceanMain.Focus();
                        }
                        catch (Exception ex)
                        {
                            Program.ShowError(ex);
                        }
                    }
                }
                if (lstOceanBol != null)
                {
                    lock (grdOceanBols)
                    {
                        try
                        {
                            grdOceanBols.DataSource = lstOceanBol;
                            if (lstOceanBol.Count > 0)
                                grdOceanBols.Focus();
                        }
                        catch (Exception ex)
                        {
                            Program.ShowError(ex);
                        }
                    }
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

        private void AdjustGUI(bool state)
        {
            try
            {
                
                lock (grdCargo)
                {
					ClsGridExUtils.SetFormats(grdCargo);
                    tsSearchCargo.Enabled =  grdCargo.Enabled = state;
                    sbrChild.Visible = sbbProgressCaption.Visible =
                        sbbProgressMeter.Visible = !state;
                    grdCargo.Enabled = state;
                }
                lock (grdOceanMain)
                {
                    ClsGridExUtils.SetFormats(grdOceanMain);
                    tsSearchCargo.Enabled = grdCargo.Enabled = state;
                    sbrChild.Visible = sbbProgressCaption.Visible =
                        sbbProgressMeter.Visible = !state;
                    grdCargo.Enabled = state;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion		// #region Search Methods

        #region Methods
        private void Resend310(string sMode)
        {
            List<ClsVwArcBolHeader> listHdr = grdOceanBols.GetCheckedList<ClsVwArcBolHeader>();
            if (listHdr.Count < 1)
            {
                Program.Show("You must selected at least one BOL");
                return;
            }
            string sPrior = "ZZZZ";
            int iCounter = 0;
            bool bKeepConfirming = true;
            foreach (ClsVwArcBolHeader hdr in listHdr)
            {
                if (hdr.Bol_No == sPrior)
                    continue;
                string sMsg = "";
                bool bAdded = ClsOceanExportQueue.InsertWWL310Exp(hdr.Bol_No, sMode, hdr.Pod_Cd, ref sMsg);
                if (!bAdded)
                {
                    Program.Show(sMsg);
                    continue;
                }
                if (bKeepConfirming)
                {
                    Program.Show("Added " + hdr.Bol_No + " to export queue as " + sMode);
                    DialogResult dr = MessageBox.Show("Continue?", "Confirm", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        bKeepConfirming = false;
                    }
                    if (dr == DialogResult.Cancel)
                    {
                        break;
                    }
                }
                sPrior = hdr.Bol_No;
                iCounter++;
            }
            grdOceanBols.UnCheckAllRecords();
            Program.Show("{0} 310 files added to the queue", iCounter);
            //SetGroupBoxEDI();
        }
        private void Resend315(string sMode)
        {
            List<ClsVwArcBolHeader> listHdr = grdOceanBols.GetCheckedList<ClsVwArcBolHeader>();
            if (listHdr.Count < 1)
            {
                Program.Show("You must selected at least one BOL");
                return;
            }
            string sPrior = "ZZZZ";
            int iCounter = 0;
            bool bKeepConfirming = true;
            foreach (ClsVwArcBolHeader hdr in listHdr)
            {
                if (hdr.Bol_No == sPrior)
                    continue;
                string sMsg = "";
                bool bAdded = ClsOceanExportQueue.InsertWWL315Exp(hdr.Bol_No, sMode, hdr.Pod_Cd, ref sMsg);
                if (!bAdded)
                {
                    Program.Show(sMsg);
                    continue;
                }
                if (bKeepConfirming)
                {
                    Program.Show("Added " + hdr.Bol_No + " to export queue as " + sMode);
                    DialogResult dr = MessageBox.Show("Continue?", "Confirm", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        bKeepConfirming = false;
                    }
                }
                Program.Show("{0} 315 files added to the queue", iCounter);
                iCounter++;
                sPrior = hdr.Bol_No;
            }
            grdOceanBols.UnCheckAllRecords();
            //SetGroupBoxEDI();
        }
        //private void Resend300(string sMode)
        //{
            //List<ClsVwArcBookingHeader> listHdr = grdOceanMain.GetCheckedList<ClsVwArcBookingHeader>();
            //if (listHdr.Count < 1)
            //{
            //    Program.Show("You must selected at least one booking");
            //    return;
            //}
            //string sPrior = "ZZZZ";
            //foreach (ClsVwArcBookingHeader hdr in listHdr)
            //{
            //    if (hdr.Booking_No == sPrior)
            //        continue;
            //    string sMsg = "";
            //    bool bAdded = ClsOceanExportQueue.InsertWWL301(hdr.Booking_No, sMode, hdr.Pol_Cd, ref sMsg);
            //    if (!bAdded)
            //    {
            //        Program.Show(sMsg);
            //        continue;
            //    }
            //    Program.Show("Added " + hdr.Booking_No + " to export queue as " + sMode);

            //    sPrior = hdr.Booking_No;
            //}
            //grdOceanMain.UnCheckAllRecords();
            //SetGroupBoxEDI();
        //}
        #endregion 

        #region Events
        private void tsSearchCargo_Click(object sender, EventArgs e)
        {
            //SearchParameters();
            PerformSearch();
        }

        private void grdCargo_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            GridEXRow grow = grdCargo.CurrentRow;
            Program.LinkHandler.HandleLink(grow, e.Column.Key);
        }
		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}

		private void frmSalesSummary_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (e.CloseReason == CloseReason.WindowsShutDown) return;

				if (IsRunning)
				{
					e.Cancel = true;
					Program.Show("Cancel the search before closing the window");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmSalesSummary_FormClosed(object sender, FormClosedEventArgs e)
		{
			//SearchOptions = null;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}

        //private void btnResend300_Click(object sender, EventArgs e)
        //{
        //    Resend300("Created");
        //}

        //private void ucButton1_Click(object sender, EventArgs e)
        //{
        //    Resend300("Updated");
        //}

 

        private void rbLINE_CheckedChanged(object sender, EventArgs e)
        {
            SetTab();
        }

        private void SetTab()
        {
            if (rbLINE.Checked)
            {
                TabMain.SelectedIndex = 2;
            }
            if (rbOcean.Checked)
            {
                TabMain.SelectedIndex = 0;
            }
            if (rbOceanBOLs.Checked)
            {
                TabMain.SelectedIndex = 1;
            }
        }
        private void grdOceanMain_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            //SetGroupBoxEDI();
        }

        //private void SetGroupBoxEDI()
        //{
        //    // SEts the state of the Send EDI Groupbox based on whether or
        //    //  not any rows are checked.
        //    if (grdOceanMain.GetCheckedRows().Length < 1)
        //    {
        //        grpResendWWL.Enabled = false;
        //    }
        //    else
        //    {
        //        grpResendWWL.Enabled = true;
        //    }
        //    if (grdOceanBols.GetCheckedRows().Length < 1)
        //        grpResendOceanBOL.Enabled = false;
        //    else
        //        grpResendOceanBOL.Enabled = true;
        //}

		private void grdCargo_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToLower() == "kind_pkg")
			{
				string sMsg = string.Format(@"Would you like to update the Kind of Package for all outstanding 322 files?  This will assist you when 322's failed because of a mismatch KOP.");
				DialogResult dr = MessageBox.Show(sMsg, "Update 322s", MessageBoxButtons.YesNo);
				if (dr != DialogResult.Yes)
					return;
				GridEXRow grow = grdCargo.GetRow();
				string sBookingNo = grow.Cells["booking_no"].ToString();
				string sKOP = grow.Cells["kind_pkg"].ToString();

				//~N9*BN*ARCA17002879~L0*1***725*U*5.722*X*1*BLK*0000590659****PCS
				int iCount = 0;
				string[] sFiles = Directory.GetFiles("\\\\commserver01\\in_out\\ANSI322_IMP\\Error");
				foreach (string s in sFiles)
				{
					string sText = File.ReadAllText(s);
					int i = sText.IndexOf("~N9*");
					sText = sText.Replace("L5*1***", "L5*1*DOD HOUSEHOLD GOODS**");
					if (i > 0)
					{
						//Program.Show(s);
						File.WriteAllText(s, sText);
						iCount++;
					}
				}
				Program.Show("{0} files updated ", iCount);

			}
		}

		private void grdCargo_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

        private void btnResend310_Click(object sender, EventArgs e)
        {
            Resend310("CREATED");
        }

        private void btnResend315_Click(object sender, EventArgs e)
        {
            Resend315("CARRIER RELEASE");
        }

        private void grdOceanBols_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            //SetGroupBoxEDI();
        }

        private void grdOceanMain_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            ClsVwArcBookingHeader hdr = grdOceanMain.GetCurrentItem<ClsVwArcBookingHeader>();
            if (e.Column.Key.ToUpper() == "SENDBOOKINGNEW")
            {
                string sMsg = "";

                bool bAdded = ClsOceanExportQueue.InsertWWL301(hdr.Booking_No, "CREATED", hdr.Pol_Cd, ref sMsg);
                if (!bAdded)
                {
                    Program.Show(sMsg);
                    return;
                }
                Program.Show("Added " + hdr.Booking_No + " to export queue as " + "CREATED");
            }
            if (e.Column.Key.ToUpper() == "SENDBOOKINGUPDATE")
            {
                string sMsg = "";

                bool bAdded = ClsOceanExportQueue.InsertWWL301(hdr.Booking_No, "UPDATED", hdr.Pol_Cd, ref sMsg);
                if (!bAdded)
                {
                    Program.Show(sMsg);
                    return;
                }
                Program.Show("Added " + hdr.Booking_No + " to export queue as " + "UPDATED");
            }
        }

        private void grdOceanMain_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            ClsVwArcBookingHeader hdr = grdOceanMain.GetCurrentItem<ClsVwArcBookingHeader>();
            GridEXRow grow = grdOceanMain.GetRow();

            string sSerialNo = grow.Cells["serial_no"].Value.ToString();

            using (frmCompareBooking frm = new frmCompareBooking(hdr.Booking_No, sSerialNo))
            {
                frm.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbPOD.SelectedIndex = -1;
            cmbPOL.SelectedIndex = -1;
            txtBookingNo.Text = txtTCN.Text = txtVoyage.Text = "";
            txtBolNo.Text = "";
         }
        #endregion

        private void grdOceanMain_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }



    }
}