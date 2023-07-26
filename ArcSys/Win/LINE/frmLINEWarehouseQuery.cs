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
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
    public partial class frmLINEWarehouseQuery : frmChildBase, ISearchWindow
    {
        #region Main Region
		private bool vgmOnly;
		private int currentIndex;
		private DataTable dtCargo;
		private List<ClsVBookingCargoLine> cargoList
		{
			get
			{
				List<ClsVBookingCargoLine> cargoList = new List<ClsVBookingCargoLine>();
				foreach (DataRow drow in dtCargo.Rows)
				{
					ClsVBookingCargoLine x = new ClsVBookingCargoLine(drow);
					cargoList.Add(x);
				}
				return cargoList;
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
		private string PCFN
		{
			get
			{
				string s = txtPCFN.Text;
				if (string.IsNullOrEmpty(s))
					return "%";
				return s.Trim();
			}
		}
        private string tcn
        {
            get
            {
                string s = txtTCN.Text;
                if (string.IsNullOrEmpty(s))
                    return "%";
                return s;
            }
        }
		private string POL
		{
			get { return cmbPOL.SelectedLocationCD; }
		}
		private string POD
		{
			get
			{
				return cmbPOD.SelectedLocationCD;
			}
		}
		private string currentCargoKey
		{
			get
			{
				DataRow drow = grdCargo.GetDataRow();
				if (drow == null)
					return null;
				if (grdCargo.GetRow().RowType != RowType.Record)
					return null;
				string s = drow["cargo_key"].ToString();
				return s;
			}
		}
		private ClsCargoExtend currentExtend
		{
			get
			{
				if (currentCargoKey == null)
					return null;
				ClsCargoExtend be = ClsCargoExtend.GetUsingKey(currentCargoKey);
				return be;
			}
		}

        public frmLINEWarehouseQuery(bool vgm)
            : base()
        {
            InitializeComponent();
			vgmOnly = vgm;
            AdjustForm(Program.MainWindow, true, null);
            WindowHelper.InitAllGrids(this);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			if (vgmOnly)
				cbxContainers.Enabled = false;
			//if (Program.CurrentUser.IsSuper)
			//    btnOrphans.Visible = true;
			//else
			//    btnOrphans.Visible = false;

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
			currentIndex = grdCargo.Row;
            try
            {
				if (string.IsNullOrEmpty(txtBookingNo.Text) &&
					string.IsNullOrEmpty(txtPCFN.Text) &&
					string.IsNullOrEmpty(txtTCN.Text) &&
					string.IsNullOrEmpty(txtVoyage.Text) &&
					cmbPOD.SelectedIndex < 0 &&
					cmbPOL.SelectedIndex < 0 &&
					cbxVGM.Checked == false)
				{
					Program.Show("You must enter some search criteria");
					return;
				}
				if (Program.MainWindow != null)
					Program.MainWindow.SetMainMenuStatus(false);

                AdjustGUI(false);

                StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
            }
            catch (Exception ex)
            {
				Program.ShowError("frmLINEWarehoueQuery.PerformSearch: {0}", ex.Message);
            }
        }

        private TimeSpan ElapsedTime;

        private void StartSearch()
        {
            try
            {
                AsynchConnectionKey = "LINE";
                DateTime start = DateTime.Now;
				ClsLINEWarehouseSearch search = new ClsLINEWarehouseSearch();

				dtCargo = search.GeneralSearch(
					VoyageNo,
					"",
					BookingNo,
					PCFN,
					tcn, POL, POD,cbxContainers.Checked, cbxVGM.Checked);

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

                lock (grdCargo)
                {
                    try
                    {
                         grdCargo.DataSource = dtCargo;
                        //lblParams.Text = string.Format("{0} Row(s) in {1:0.00} sec {2}",
                        //    grdResults.RecordCount, ElapsedTime.TotalSeconds, SearchOptions.Options);
                        //lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
                        //pnlTop.Height = lblParams.Height + 10;

                        grdCargo.Focus();
						grdCargo.Row = currentIndex;
						SetToolTips();
                    }
                    catch (Exception ex)
                    {
						Program.ShowError("frmLINEWarehoueQuery.UpdateGrid1: {0}", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
				Program.ShowError("frmLINEWarehoueQuery.UpdateGrid2: {0}", ex.Message);
            }
            finally
            {
				if (Program.MainWindow != null)
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
				Program.ShowError("frmLINEWarehoueQuery.ResetCounter: {0}", ex.Message);
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
                    grdCargo.Enabled = state;
                    sbrChild.Visible = sbbProgressCaption.Visible =
                        sbbProgressMeter.Visible = !state;
                    grdCargo.Enabled = state;
                }
            }
            catch (Exception ex)
            {
				Program.ShowError("frmLINEWarehoueQuery.AdjustGUI: {0}", ex.Message); ;
            }
        }
        #endregion		// #region Search Methods

		#region Methods
		private void PurgeOrphans()
		{
			if (dtCargo == null)
				return;
			if (dtCargo.Rows.Count < 1)
				return;
			try
			{
				Program.ConnectToLINE();
				int iCount = 0;
				foreach (DataRow drow in dtCargo.Rows)
				{

					ClsCargoLine cargo = new ClsCargoLine(drow);
					string sKey = cargo.Cargo_Key;
					if (sKey.StartsWith("BREAKBULK"))
					{
						string s = sKey.Remove(0, 9);
						DataTable dt = ASL.ARC.EDISQLTools.ClsLineSQL.FindBB(s);
						if (dt != null && dt.Rows.Count > 0)
							continue;
						cargo.Delete();
						ClearDupeMessage(cargo.Serial_No);
						iCount++;
					}
					if (sKey.StartsWith("RORO"))
					{
						string s = sKey.Remove(0, 4);
						DataTable dt = ASL.ARC.EDISQLTools.ClsLineSQL.FindRoRo(s);
						if (dt != null && dt.Rows.Count > 0)
							continue;
						cargo.Delete();
						ClearDupeMessage(cargo.Serial_No);
						iCount++;
					}

				}
				Program.Show("{0} pieces of cargo have been purged.", iCount);
				if (iCount > 0)
					PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ClearDupeMessage(string sSerialNo)
		{
			DataTable dt = ClsCargoLine.GetByTCNLocationsDT(sSerialNo, "%", "%");
			if (dt.Rows.Count < 1)
				return;
			foreach (DataRow drow in dt.Rows)
			{
				ClsCargoLine c = new ClsCargoLine(drow);
				c.Import_Notes_Txt = null;
				c.Update();
			}
		}
		private void PrintLabels()
		{
			
		}

		private void PatchReceivedDate()
		{
			try
			{
				CS2010.ArcSys.Business.ClsLineSQL.CleanupBookRcvVins();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void SaveChanges()
		{
			try
			{
				Program.ConnectToLINE();
				if (dtCargo == null)
				{
					Program.Show("Nothing to save");
					return;
				}
				foreach (DataRow drow in dtCargo.Rows)
				{
					if (drow.RowState == DataRowState.Modified)
					{
						//
						// First, update t_booking_extend
						//
						string cargokey = drow["cargo_key"].ToString();
						string vmg = drow["dim_vgm_nbr"].ToString();
						string bookingno = drow["booking_no"].ToString();
						string kgs = drow["weight_kgs_nbr"].ToString();
						decimal? dVmg = ClsConvert.ToDecimalNullable(vmg);
						decimal? dKgs = ClsConvert.ToDecimalNullable(kgs);
						ClsCargoExtend be = ClsCargoExtend.GetUsingKey(cargokey);
						if (be == null)
						{
							//Program.Show("Error saving cargokey {0} ", cargokey);
							be = new ClsCargoExtend();
							be.Cargo_Key = cargokey;
							be.Booking_No = bookingno;
							be.Dim_Vgm_Nbr = dVmg;
							be.Original_Weight_Nbr = dKgs;
							be.Insert();
						}
						else
						{
							be.Dim_Vgm_Nbr = dVmg;
							be.Update();
						}

						// Then update LINE
                        // September 2020 DGERDNER
                        // Removed the references to LINE.  May need to provide
                        // a mechanism to update OCEAN.
                        //if (cargokey.StartsWith("BREAKBULK"))
                        //{
                        //    string s = cargokey.Remove(0, 9);
                        //    ASL.ARC.EDISQLTools.ClsLineSQL.UpdateWeight_BB(s, dVmg);

                        //}

						// Then update LINE Warehouse
						ClsCargoLine a = new ClsCargoLine();
						ClsCargoLine cl = a.GetByCargoKey(cargokey);
						cl.Weight_Nbr = dVmg;
						cl.Update();

						// And update ACMS
						CS2010.ACMS.Business.ClsBookingUnit acmsBU =
							CS2010.ACMS.Business.ClsBookingUnit.GetByTCN(bookingno, cl.Serial_No);
						if (acmsBU != null)
						{
							decimal? dWt = dVmg * 2.20462M;
							dWt = Math.Round(dWt.GetValueOrDefault(),3);
							acmsBU.Wt_Nbr = ClsConvert.ToDouble(dWt.GetValueOrDefault());
							acmsBU.Update();
						}

						// Add row to the SPS log table in LINE
						//be.BookingLine.UpdateSPSLog();
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				PerformSearch();
			}
		}

		private void SetToolTips()
		{
			try
			{
				foreach (GridEXRow grow in grdCargo.GetDataRows())
				{
					int i = grdCargo.GetDataRows().Length;
					DataRowView drv = grow.DataRow as DataRowView;
					if (drv != null)
					{
						DataRow drow = drv.Row;
						string CargoKey = drow["cargo_key"].ToString();
						ClsCargoExtend cx = ClsCargoExtend.GetUsingKey(CargoKey);
						if (cx != null)
						{
							StringBuilder sTip = new StringBuilder(cx.AuditTrailString);
							grow.Cells["vgm_modified"].ToolTipText = sTip.ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
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

		private void btnOrphans_Click(object sender, EventArgs e)
		{
			PurgeOrphans();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}
		private void btnLabels_Click(object sender, EventArgs e)
		{
			PrintLabels();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveChanges();
		}

		private void grdCargo_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

		private void grdCargo_TextChanged(object sender, EventArgs e)
		{
			btnSave.Enabled = true;
		}

		private void grdCargo_Validated(object sender, EventArgs e)
		{
			btnSave.Enabled = true;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			cmbPOD.SelectedIndex = -1;
			cmbPOL.SelectedIndex = -1;
			txtBookingNo.Text = txtPCFN.Text = txtTCN.Text = txtVoyage.Text = "";
			cbxContainers.Checked = true;
			cbxVGM.Checked = false;
		}

		private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentIndex = grdCargo.Row;
			if (tabMain.SelectedIndex == 1)
			{
				DataTable dt = ClsCargoExtend.GetAuditTrail(currentCargoKey);
				grdAudit.DataSource = dt;
			}
			else
			{
				grdCargo.Row = currentIndex;
			}
		}
		private void grdCargo_SortKeysChanged(object sender, EventArgs e)
		{
			SetToolTips();
		}
        #endregion

		private void btnReceivedDt_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(BookingNo))
			{
				Program.Show("This only works if you have queried on a single booking");
				return;
			}
			try
			{
				//PatchReceivedDate();
				int iRows = CS2010.ArcSys.Business.ClsLineSQL.CleanupMismatchRcvdVINS(BookingNo);
				Program.Show("{0} pieces of cargo were updated.", iRows);
			}
			catch (Exception ex)
			{
				Program.Show(ex.Message);
			}



		}









 
    }
}