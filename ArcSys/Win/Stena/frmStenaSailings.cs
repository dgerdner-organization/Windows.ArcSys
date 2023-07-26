using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CS2010.Common;
using CS2010.AVSS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmStenaSailings : frmChildBase
	{
		protected DataTable dtMain;
		protected string currentMode = "view";
		private DataRow _currentRow;
		protected DataRow currentRow
		{
			get {return _currentRow ;}
			set { _currentRow = value; }
		}
		private ClsStenaRouteSailing _CurrentSailing;
		protected ClsStenaRouteSailing CurrentSailing
		{
			get { return _CurrentSailing; }
			set { _CurrentSailing = value; }
		}
		protected void SetCurrentItem()
		{
			DataRow drow = grdMain.GetDataRow();
			currentRow = drow;
			ClsStenaRouteSailing s = new ClsStenaRouteSailing(drow);
			if (s!=null)
				CurrentSailing = s;
		}
		public frmStenaSailings()
		{
			InitializeComponent();
		}
		public void ShowWindow()
		{

			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			dtMain = null;
			InitForm();
		}

		public void InitForm()
		{
			dtMain = ClsStenaRouteSailing.GetSailings("%", -7, 30);
			grdMain.DataSource = dtMain;
			if (dtMain.Rows.Count > 0)
				grdMain.Row = 1;
		}


		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			if (grdMain.CurrentRow.RowType != Janus.Windows.GridEX.RowType.Record)
				return;
			SetCurrentItem();
		}

		private void grdMain_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{

				GridEXRow grow = grdMain.CurrentRow;
				DataRow drow = currentRow;
				drow.AcceptChanges();

				Program.ConnectToLINE();
				ASL.ARC.EDISQLTools.CreateVoyageData c = new CreateVoyageData();
				c.VesselCd = drow["vessel_cd"].ToString();
				c.Voyage = grow.Cells[7].Value.ToString();
				if (string.IsNullOrEmpty(c.Voyage))
				{
					Program.Show("You must enter a new voyage number");
					return;
				}
				// ! Need to confirm it doesn't already exist
				c.TradeLane = c.Voyage.Substring(0, 2);
				c.Service = "E"; /* Always Europe */
				c.CurUser = Program.CurrentUser.User_Nm;
				string sDate = drow["sailing_dt"].ToString();
				c.Depart = ClsConvert.ToDateTime(sDate);
				//c.Arrive = c.Depart.AddHours(4);
				sDate = drow["arrive_dt"].ToString();
				c.Arrive = ClsConvert.ToDateTime(sDate);
				
				c.PreDepart = CurrentSailing.PriorSailing.Arrive_Dt.GetValueOrDefault();
				c.PostArrive = c.Arrive.AddHours(4);
				if (CurrentSailing.NextSailing != null)
					if (CurrentSailing.NextSailing.Sailing_Dt.HasValue)
						c.PostArrive = CurrentSailing.NextSailing.Sailing_Dt.GetValueOrDefault();
				c.POD = drow["pod_location_cd"].ToString();
				c.POL = drow["pol_location_cd"].ToString();
				c.CentralPort = c.POL;
				if (c.POL == "GBHRW")
					c.Direction = "WB";
				else
					c.Direction = "EB";
				string sMsg = string.Format("Create voyage {0} leaving {1} at {2}?", c.Voyage, c.POL, c.Depart);
				DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
				if (dr == DialogResult.Cancel)
				{
					Program.Show("Voyage was NOT created");
					return;
				}
				CreateVoyage cv = new CreateVoyage();
				if (!cv.CreateLINEVoyage(c))
				{
					Program.Show(c.ErrorMsg);
					return;
				}

				// Create the Load and Discharge Port Calls
				ClsVesselBerthActivity vba;
				ClsVesselRoute vr = ClsVesselRoute.GetUsingKey(c.VesselRouteID.GetValueOrDefault());
				ClsVesselPortCall vpcPOL = ClsVesselPortCall.GetPortCall(c.VesselCd, c.POL, c.Voyage, c.Depart, "L");
				if (vpcPOL == null)
				{
					vpcPOL = ClsVesselRoute.CreatePortCall(vr, c.POL, c.Depart, c.PreDepart);
				}
				if (vpcPOL == null)
					Program.Show("Creating the AVSS POL failed");
				else
					vba = vpcPOL.CreateBerthActivity(c.Voyage, "L");

				ClsVesselPortCall vpcPOD = ClsVesselPortCall.GetPortCall(c.VesselCd, c.POD, c.Voyage, c.Arrive, "A");
				if (vpcPOD == null)
				{
					vpcPOD = ClsVesselRoute.CreatePortCall(vr, c.POD, c.PostArrive, c.Arrive);
				}
				if (vpcPOD == null)
					Program.Show("Creating the AVSS POD failed");
				else
					vba = vpcPOD.CreateBerthActivity(c.Voyage, "D");

				Program.Show("Created in LINE and AVSS");
				//Program.StrmFile.Close();
			}
			catch (Exception ex)
			{
				//Program.WriteAudit(ex.Message);
				Program.Show(ex.Message);
			}


		}


	}
}
