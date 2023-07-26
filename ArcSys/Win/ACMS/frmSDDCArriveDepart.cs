using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Data;
using Janus.Windows.GridEX;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using CS2010.ArcSys.Win;
using CS2010.ACMS.Business;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmSDDCArriveDepart : Form
	{
		#region Fields
		private static frmSDDCArriveDepart UnsentITVWindow;

		//private DataTable dtMissingVesselDepart;

		//private DataTable dtMissinvVesselArrive;

		//private DataTable dtLineRcvdByDate;

		//private DataTable dtACMSRcvdByDate;

		private DataTable dtLineArriveDepart;

		//private DataTable dtPendingDoorITV;
		//private List<ClsLoadedCargo> listPendingITV;

		//private DataTable dtBlankTCN;

		//private DataTable dtUnloadedCargo;

		private DataTable dtLINECargoByVoyage;
		private DataTable dtACMSCargoByVoyage;
		private DataTable dtArriveDepartITV;

		private string _VoyageNo;
		private static bool AutoSearch;
		#endregion

		#region Main Form Methods
		public frmSDDCArriveDepart()
		{
			InitializeComponent();
		}

		public static frmSDDCArriveDepart ShowWindow()
		{
			return ShowWindow(7, 3, "%", false);
		}

		public static frmSDDCArriveDepart ShowWindow(int iFrom, int iTo, string sVoyageNo, bool bAutoSearch)
		{
			try
			{
				AutoSearch = bAutoSearch;
				if( UnsentITVWindow == null )
				{
				    UnsentITVWindow = new frmSDDCArriveDepart();
				    UnsentITVWindow.MdiParent = Program.MainWindow;
				}

				UnsentITVWindow.Activate();
				UnsentITVWindow.Show();
				UnsentITVWindow.WindowState = FormWindowState.Maximized;
				UnsentITVWindow.ucADFromDays.Value = iFrom;
				UnsentITVWindow.ucADToDays.Value = iTo;
				UnsentITVWindow._VoyageNo = sVoyageNo;
				if (bAutoSearch)
					UnsentITVWindow.Search();


				return UnsentITVWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void frmMainProcess()
		{
		}
		#endregion

		#region Helper Methods
		private bool ConfirmSearch(ucLabel label)
		{
			label.Visible = true;
			if( MessageBox.Show("Search Now?  This may take several minutes.",
								"Confirm",
								MessageBoxButtons.OKCancel,
								MessageBoxIcon.Warning,
								MessageBoxDefaultButton.Button1) == DialogResult.Cancel )
			{
				label.Visible = false;
				return false;
			}

			return true;
		}

		private void Search()
		{
			tbbLINEvsACMS.Checked = false;
			ResetCompareFlags(tbbLINEvsACMS);
			int iFromDays = ClsConvert.ToInt32(ucADFromDays.Value);
			int iToDays = ClsConvert.ToInt32(ucADToDays.Value);
			dtLineArriveDepart = ClsACMSQueries.GetArriveDepartSchedule("MTMCIBSD", iFromDays, iToDays, _VoyageNo, false);
			grdArriveDepart.DataSource = dtLineArriveDepart;
			if (!AutoSearch)
				Program.Show("Search complete");
		}

		#endregion

		#region Arrive/Depart Tab
	
		private void CompareGrids(GridEX grid1, DataTable dt1, GridEX grid2, DataTable dt2, bool bDiff)
		{
			try
			{
				if( dt1 == null || dt1.Rows.Count < 1 ||
					dt2 == null || dt2.Rows.Count < 1 ) return;
				lock( grid1 )
				{
					if( bDiff )
					{
						foreach( DataRow dr in dt1.Rows )
						{
							string vin = ClsConvert.ToString(dr["tcn"]);
							if( string.IsNullOrEmpty(vin) ) continue;
							string where = string.Format("tcn = '{0}'", vin);
							DataRow[] rows = dt2.Select(where);
							int diffStatus = (rows == null || rows.Length <= 0) ? 1 : 0;
							dr["diff_status"] = ClsConvert.ToDbObject(diffStatus);
						}
						dt1.DefaultView.RowFilter = "Diff_Status = 1";
					}
					else
					{
						dt1.DefaultView.RowFilter = null;
						grid1.DataSource = dt1;
					}
				}
				lock( grid2 )
				{
					if( bDiff )
					{
						foreach( DataRow dr in dt2.Rows )
						{
							string vin = ClsConvert.ToString(dr["tcn"]);
							if( string.IsNullOrEmpty(vin) ) continue;
							string where = string.Format("tcn = '{0}'", vin);
							DataRow[] rows = dt1.Select(where);
							int diffStatus = (rows == null || rows.Length <= 0) ? 1 : 0;
							dr["diff_status"] = ClsConvert.ToDbObject(diffStatus);
						}
						dt2.DefaultView.RowFilter = "Diff_Status = 1";
					}
					else
					{
						dt2.DefaultView.RowFilter = null;
						grid2.DataSource = dt2;
					}
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void ResetCompareFlags(ToolStripButton tsb)
		{
			// Resets all of the "Mismatch" buttons to unchecked, other
			// than the one that was just clicked.  
			//
			// Then it removes the filter from all of the datatables
			//
			if (tsb != tbbLINEvsACMS) {tbbLINEvsACMS.Checked = false;}
			if (tsb != tbbLINEvsITV ) {tbbLINEvsITV.Checked = false;}
			if( tsb != tbbACMSvsITV ) { tbbACMSvsITV.Checked = false; }
			if( tsb != tbbACMSvsLINE) { tbbACMSvsLINE.Checked = false; }
			if( dtACMSCargoByVoyage != null ) { dtACMSCargoByVoyage.DefaultView.RowFilter = null; }
			if( dtACMSCargoByVoyage != null ) { dtLINECargoByVoyage.DefaultView.RowFilter = null; }
			if( dtArriveDepartITV != null ) { dtArriveDepartITV.DefaultView.RowFilter = null; }
		}
		private void tbbLINEvsITV_Click(object sender, EventArgs e)
		{
			ResetCompareFlags(tbbLINEvsITV);
			CompareGrids(grdAD_LINE, dtLINECargoByVoyage,
						 grdAD_ITV, dtArriveDepartITV, tbbLINEvsITV.Checked);
		}
		private void tsCompareLineACMS_Click(object sender, EventArgs e)
		{
			ResetCompareFlags(tbbLINEvsACMS);
			CompareGrids(grdAD_LINE, dtLINECargoByVoyage,
						 grdAD_ACMS, dtACMSCargoByVoyage, tbbLINEvsACMS.Checked);
		}
		private void tbbACMSvsLINE_Click(object sender, EventArgs e)
		{
			ResetCompareFlags(tbbACMSvsLINE);
			CompareGrids(grdAD_ACMS, dtACMSCargoByVoyage,
						 grdAD_LINE, dtLINECargoByVoyage,
						 tbbACMSvsLINE.Checked);
		}
		private void tbbACMSvsITV_Click(object sender, EventArgs e)
		{
			ResetCompareFlags(tbbACMSvsITV);
			CompareGrids(grdAD_ACMS, dtACMSCargoByVoyage,
						 grdAD_ITV, dtArriveDepartITV,
						 tbbACMSvsITV.Checked);
		}
		private void tsSearchArriveDepart_Click(object sender, EventArgs e)
		{
			Search();
		}
		private void grdArriveDepart_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				GridEXRow grow = grdArriveDepart.CurrentRow;
				if( grow == null ) { return; }
				if( grow.RowType != RowType.Record ) { return; }

				// First, set the "Only see differences" Off
				//tbbLINEvsACMS.Checked = false;
				ResetCompareFlags(null);

				// Find the currently selcted voyage info
				DataRow dr = grdArriveDepart.GetDataRow();
				string sVoyageNo = dr["voyageno"].ToString();
				string sLocation = dr["location_cd"].ToString();
				string sAD = dr["arrivedepart"].ToString();
				string sPOL = "%";
				string sPOD = "%";
				if (sAD.ToLower() == "arrive")
					sPOD = sLocation;
				else
					sPOL = sLocation;

				// Get LINE data
                //dtLINECargoByVoyage =  ClsArcSQL.GetCargoListForVAD ("%", sVoyageNo, "%", "%", "%", sPOL, sPOD, sAD);
                dtLINECargoByVoyage = CS2010.ArcSys.Business.ClsVwArcBookingCargo.GetCargoListForVAD("%", sVoyageNo, "%", "%", "%", sPOL, sPOD, sAD);
                grdAD_LINE.DataSource = dtLINECargoByVoyage;

				// Get ACMS data
				dtACMSCargoByVoyage = ClsAcmsSQL.GetCargoByVoyage(sVoyageNo, sLocation, sAD);
				grdAD_ACMS.DataSource = dtACMSCargoByVoyage;

				// Get actual ITV that has been sent
				dtArriveDepartITV = ClsAcmsSQL.ITVbyVoyage(sVoyageNo, sLocation, sAD);
				grdAD_ITV.DataSource = dtArriveDepartITV;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		private void tbbADDiff_Click(object sender, EventArgs e)
		{
			//ArriveDeparatCompareDifferences();
		}
		#endregion

		#region Events
		private void frmUnsentBookings_FormClosed(object sender, FormClosedEventArgs e)
		{
			UnsentITVWindow = null;
		}

		private void grdAD_LINE_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdAD_LINE.CurrentRow, "partner_request_cd");
		}
		private void grdAD_ACMS_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdAD_ACMS.CurrentRow, "partner_request_cd");
		}
		#endregion

		private void grdArriveDepart_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				DataRow drow = grdArriveDepart.GetDataRow();
				string sVoyageNo = drow["voyageno"].ToString();
				using (frmSearchVoyages frm = new frmSearchVoyages(sVoyageNo))
				{
					frm.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}









	






	}

}