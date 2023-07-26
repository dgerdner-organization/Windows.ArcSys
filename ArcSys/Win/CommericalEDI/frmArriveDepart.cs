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
using CS2010.ArcSys.Business;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
	public partial class frmArriveDepart : Form
	{
		#region Fields
		private static frmArriveDepart UnsentITVWindow;

		private DataTable dtPartners;
		//private DataTable dtMissingVesselDepart;
		//private DataTable dtMissinvVesselArrive;
		private DataTable dtLineArriveDepart;
		private DataTable dtLINECargoByVoyage;
		//private DataTable dtACMSCargoByVoyage;
		private DataTable dtITV;

		private ClsTradingPartner CurrentPartner
		{
			get
			{
				int ix = cmbPartner.SelectedIndex;
				if (ix < 0)
					return null;
				DataRow dr = dtPartners.Rows[ix];
				ClsTradingPartner tp = new ClsTradingPartner(dr);
				return tp;
			}
		}

		#endregion

		#region Main Form Methods
		public frmArriveDepart()
		{
			InitializeComponent();
		}


		public void ShowForm()
		{
			RefreshAll();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			dtPartners = ClsTradingPartner.GetUserPartners();
			cmbPartner.DataSource = dtPartners;
			if (dtPartners.Rows.Count > 0)
				cmbPartner.SelectedIndex = 0;
		}

		private void RefreshAll()
		{
		}

		public static frmArriveDepart ShowWindow()
		{
			try
			{
				if( UnsentITVWindow == null )
				{
					UnsentITVWindow = new frmArriveDepart();
				    UnsentITVWindow.MdiParent = Program.MainWindow;
				}

				UnsentITVWindow.Activate();
				UnsentITVWindow.Show();
				UnsentITVWindow.WindowState = FormWindowState.Maximized;

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
		#endregion

		private void tsSearchArriveDepart_Click(object sender, EventArgs e)
		{
			int iFromDays = ClsConvert.ToInt32(ucADFromDays.Value);
			int iToDays = ClsConvert.ToInt32(ucADToDays.Value);
			dtLineArriveDepart = ClsCommercialEDIQueries.searchVesselArriveDepart(CurrentPartner.Trading_Partner_Cd, iFromDays, iToDays);
			grdArriveDepart.DataSource = dtLineArriveDepart;
			Program.Show("Search complete");
		}

		private void grdArriveDepart_SelectionChanged(object sender, EventArgs e)
		{
			LINECargoSearch();
		}

		#region Tab Methods
	
		#region Arrive/Depart Tab

		private void ITVSearch()
		{

		}
		private void LINECargoSearch()
		{
			try
			{
				GridEXRow grow = grdArriveDepart.CurrentRow;
				if (grow == null) { return; }
				if (grow.RowType != RowType.Record) { return; }

				// Find the currently selcted voyage info
				DataRow dr = grdArriveDepart.GetDataRow();
				string sVoyageNo = dr["voyageno"].ToString();
				string sLocation = dr["location_cd"].ToString();
				string sAD = dr["arrivedepart"].ToString();

				DateTime start = DateTime.Now;
				ClsCommercialEDIQueries.EDIQueryParms parms = new ClsCommercialEDIQueries.EDIQueryParms();
				parms.PartnerCd = CurrentPartner.Trading_Partner_Cd;
				parms.VoyageNo = sVoyageNo;
				parms.ArriveDepartCd = sAD;
				if (sAD.ToLower() == "arrive")
					parms.PODCd = sLocation;
				else
					parms.POLCd = sLocation;

				dtLINECargoByVoyage = ClsCommercialEDIQueries.SearchCargo(parms, true);
				grdAD_LINE.DataSource = dtLINECargoByVoyage;

				dtITV =  ClsCommercialEDIQueries.SearchITVHistory(parms);
				grdAD_ITV.DataSource = dtITV;

				TimeSpan time = DateTime.Now - start;
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}

		}
		#endregion

	
		#endregion

		#region Events

		#endregion

	
	}

}