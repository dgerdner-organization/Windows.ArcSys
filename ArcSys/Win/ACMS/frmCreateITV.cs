using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Win;

namespace ASL.ARC.EDITools
{
	public partial class frmCreateITV : frmChildBase
	{
		#region Fields/Properties

		//private DataTable dtProtocol;
		//private List<ClsLoadedCargo> listCargo;
		private ProtocolParameters SearchParams;

		private static frmCreateITV ProtocolWindow;

		private string LocationCd
		{
			get
			{
				int i = cmbLocation.SelectedIndex;
				DataTable dt = cmbLocation.Table;
				if( i < 0 )
					return "";
				string s = dt.Rows[i]["location_cd"].ToString();
				return s;
			}
		}
		private string TerminalCd
		{
			get
			{
				int i = cmbTerminal.SelectedIndex;
				DataTable dt = cmbTerminal.Table;
				if( i < 0 )
					return "";
				string s = dt.Rows[i]["terminal_cd"].ToString();
				return s;
			}
		}
		private string ActivityCd
		{
			get
			{
				int i = cmbITVCodes.SelectedIndex;
				DataTable dt = cmbITVCodes.Table;
				if( i < 0 )
					return "";
				string s = dt.Rows[i]["activity_code"].ToString();
				return s;
			}
		}

		private ClsConnection Connection
		{
			get { return ClsConMgr.Manager["LINE"]; }
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmCreateITV()
		{
			InitializeComponent();

			DataTable dtCodes = ClsAcmsSQL.SelectActivityCodes();
			cmbITVCodes.DataSource = dtCodes;

			DataTable dtLoc = ClsAcmsSQL.SelectLocations();
			cmbLocation.DataSource = dtLoc;
			cmbTerminal.DataSource = null;

			grpCreate.Visible = grdITVHistory.Visible = false;

			SearchParams = new ProtocolParameters();
		}

		public static frmCreateITV ShowWindow()
		{
			try
			{
				if( ProtocolWindow == null )
				{
					ProtocolWindow = new frmCreateITV();
					ProtocolWindow.MdiParent = Program.MainWindow;
				}

				ProtocolWindow.Activate();
				ProtocolWindow.Show();
				ProtocolWindow.WindowState = FormWindowState.Maximized;
				ProtocolWindow.sbrChild.Visible = false;

				return ProtocolWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void frmLineProtocol_FormClosed(object sender, FormClosedEventArgs e)
		{
			ProtocolWindow = null;
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Search Methods

		private void tbbSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void SearchParameters()
		{
			try
			{
				SearchParams.Clear();

				SearchParams.Booking_No = txtBooking.Text.Trim();
				SearchParams.POD_CDs = txtPOD.Text.Trim();
				SearchParams.POL_CDs = txtPOL.Text.Trim();
				SearchParams.Vessel = txtVessel.Text.Trim();
				SearchParams.Voyage = txtVoyage.Text.Trim();
				SearchParams.PCFN = txtPCFN.Text.Trim();
				SearchParams.OnDelay = cbxDelay.Checked;
				SearchParams.IncludeBooked = cbxBooked.Checked;
				SearchParams.TCN = txtTCN.Text.Trim();
				if( string.IsNullOrEmpty(SearchParams.Voyage) &&
					string.IsNullOrEmpty(SearchParams.Booking_No) &&
					string.IsNullOrEmpty(SearchParams.TCN) &&
					string.IsNullOrEmpty(SearchParams.PCFN))
				{
					Program.Show("You must specify at least a voyage/tcn/pcfn or a booking");
					return;
				}
				//if (string.IsNullOrEmpty(SearchParams.Booking_No) &&
				//    string.IsNullOrEmpty(SearchParams.TCN) &&
				//    string.IsNullOrEmpty(SearchParams.PCFN))
				//    if (string.IsNullOrEmpty(SearchParams.POL_CDs))
				//        if( string.IsNullOrEmpty(SearchParams.POD_CDs) )
				//        {
				//            Program.Show("You must specify a voyage and one port");
				//            return;
				//        }

				if( string.IsNullOrEmpty(SearchParams.POL_CDs) )
					SearchParams.POL_CDs = "%";
				if( string.IsNullOrEmpty(SearchParams.POD_CDs) )
					SearchParams.POD_CDs = "%";
				if( string.IsNullOrEmpty(SearchParams.Booking_No) )
					SearchParams.Booking_No = "%";
				if( string.IsNullOrEmpty(SearchParams.Voyage) )
					SearchParams.Voyage = "%";
				if( string.IsNullOrEmpty(SearchParams.TCN) )
					SearchParams.TCN = "%";
				if( string.IsNullOrEmpty(SearchParams.PCFN) )
					SearchParams.PCFN = "%";

				GetLocations();

				PerformSearch();


			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
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
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void StartSearch()
		{
			try
			{
				//DataTable dt = ClsLineSQL.GetCargoForCreateITV(SearchParams);
				//DataTable dtSub = ClsAcmsSQL.GetSubCargoQuery(ClsLineSQL.CargoForCreateItv);
				DataTable dtReport = ClsArcSQL.GetCargoListIncludePending(txtBooking.Text, txtVoyage.Text + "%", txtVessel.Text, txtTCN.Text, 
						txtPCFN.Text, txtPOL.Text, txtPOD.Text, cbxIncludeMemo.Checked, cbxBooked.Checked);
				lock( grdCargo )
				{
					grdCargo.DataSource = dtReport;
					//dtProtocol = dt;
					//listCargo = ClsLineSQL.CargoForCreateItv;
					//grdCargo.DataSource = listCargo;
				}
				//lock( grdSubCargo )
				//{
				//    grdSubCargo.DataSource = dtSub;
				//}
			}
			catch( Exception ex )
			{
				if( ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0 )
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock( grdCargo )
				{
					grdCargo.RemoveFilters();
					//grdCargo.DataSource = listCargo;

					grdCargo.RootTable.Caption = string.Format("{0} Row(s)",
						grdCargoxxx.RecordCount);
					grdCargo.Focus();
					if( grdCargo.RecordCount > 0 )
						grpCreate.Visible = grdITVHistory.Visible = true;
					else
						grpCreate.Visible = grdITVHistory.Visible = false;
				}
			}
			catch( Exception ex )
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
			catch( Exception ex )
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
				lock( pnlMain )
				{
					tbbSearch.Enabled = //tbbOptions.Enabled = tbbClose.Enabled =
						grdCargo.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgress.Visible = !state;
					pnlMain.Enabled = state;
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Helper Methods
		private bool ConfirmCreate()
		{
			DataRow[] drows = grdCargo.GetCheckedDataRows();
			int i = (drows != null) ? drows.Length : 0;
			if (i <= 0) return Program.ShowError("No rows selected");

			//int i = grdCargo.GetCheckedList<ClsLoadedCargo>().Count;
			//if (grdSubCargo.GetCheckedDataRows() != null)
			//	i = i + grdSubCargo.GetCheckedDataRows().Length;
			string sConfirm = string.Format("Create ITV activity for {0} pieces of cargo?", i);
			DialogResult b = MessageBox.Show(sConfirm, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			return (b == DialogResult.OK);
		}

		private void GetLocations()
		{
			if( cbxShowAll.Checked )
			{
				cmbLocation.DataSource = ClsAcmsSQL.SelectLocations();
				return;
			}
			if( !string.IsNullOrEmpty(txtBooking.Text) )
			{
				cmbLocation.DataSource = ClsAcmsSQL.SelectLocations(txtBooking.Text);
			}
			else
				if( !string.IsNullOrEmpty(txtVoyage.Text) )
				{
					cmbLocation.DataSource = ClsAcmsSQL.SelectLocationsByVoyage(txtVoyage.Text);
				}
		}

		private bool VerifyDate()
		{
			if( txtActivityDate.Value > DateTime.Now )
			{
				Program.Show("Dates cannot be entered in the future");
				return false;
			}
			return true;
		}

		#endregion

		#region Event Handlers

		private void frmLineProtocol_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if( e.CloseReason == CloseReason.WindowsShutDown ) return;

				if( IsRunning )
				{
					e.Cancel = true;
					Program.Show("Cancel the search before closing the window");
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void frmLineProtocol_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.Enter ) SearchParameters();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbClear_Click(object sender, EventArgs e)
		{
			try
			{
				WindowHelper.ClearControls(pnlMain.Panel1.Controls);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_FilterApplied(object sender, EventArgs e)
		{
			//try
			//{
			//    int dtTotal = (dtProtocol != null) ? dtProtocol.Rows.Count : 0;
			//    int gridTotal = grdCargo.RecordCount;
			//    if( dtTotal != gridTotal )
			//        grdCargo.RootTable.Caption =
			//            string.Format("{0} Total Row(s), {1} Matching Row(s)", dtTotal, gridTotal);
			//    else
			//        grdCargo.RootTable.Caption = string.Format("{0} Row(s)", gridTotal);
			//}
			//catch( Exception ex )
			//{
			//    Program.ShowError(ex);
			//}
		}

		private void grdCargo_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.C && e.Control )
				{
					GridEXRow r = grdCargo.GetRow();
					GridEXColumn c = grdCargo.CurrentColumn;
					if( r == null || c == null || string.IsNullOrEmpty(c.DataMember) ) return;

					string s = ClsConvert.ToString(r.Cells[c].Text);
					if( !string.IsNullOrEmpty(s) ) Clipboard.SetText(s);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			if( !VerifyDate() )
			    return;
			try
			{
				int i = 0;

				//i = grdCargo.GetCheckedList<ClsLoadedCargo>().Count;
				//if( grdSubCargo.GetCheckedDataRows() != null )
				//    i = i + grdSubCargo.GetCheckedDataRows().Length;
				//if( i < 1 )
				//{
				//    Program.Show("You must select at least one piece of cargo");
				//    return;
				//}

				if( !ConfirmCreate() )
				{
					Program.Show("Operation Cancelled");
					return;
				}

				if( string.IsNullOrEmpty(ActivityCd) )
				{
					Program.Show("You must select a Status");
					return;
				}
				if( cmbLocation.SelectedIndex < 0 )
				{
					Program.Show("You must select a location");
					return;
				}

				// This was removed early 2012
				//if( cmbTerminal.SelectedIndex < 0 )
				//{
				//    Program.Show("You must select a terminal");
				//    return;
				//}

				i = 0;
				DateTime dtActivityDate = txtActivityDate.Value;
				foreach( DataRow drow in grdCargo.GetCheckedDataRows() )
				{
					string sBookingNo = drow["booking_id"].ToString();
					string sBookingSub = drow["booking_id_sub"].ToString();
					string sVoyage = drow["acms_voyage_no"].ToString();
					string sItemNo = drow["acms_item_no"].ToString();
					string sTCN = drow["tcn"].ToString();
					ClsAcmsSQL.CreateITVMessage(ActivityCd, dtActivityDate,
						LocationCd, TerminalCd, sBookingNo,
						sBookingSub, sVoyage, sItemNo, sTCN, Program.UserName);
					i++;
				}
				// DGERDNER DEC2012 Replace following code with above code;
				// taking data from a brand new datagrid
				//
				//foreach( ClsLoadedCargo c in grdCargo.GetCheckedList<ClsLoadedCargo>() )
				//{
				//    // June 2012 -- confirm if they're entering more than one
				//    bool bDuplicates = isDuplicate(c, ActivityCd);
				//    if( bDuplicates )
				//    {
				//        string sMsg = string.Format("{0} already has an {1} activity; confirm to send another.",
				//            c.TCN, ActivityCd);
				//        if( MessageBox.Show(sMsg, "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel )
				//        {
				//            continue;
				//        }
				//    }

				//    // May 2012 -- uses the User Name instead of "EDIMan"
				//    ClsAcmsSQL.CreateITVMessage(c,
				//        ActivityCd,
				//        dtActivityDate,
				//        LocationCd,
				//        TerminalCd,
				//        Program.Class_User_Nm);
				//    i++;
				//}

				// DGERDNER DEC2012 This has been here for a long time
				// but we aren't using the "sub item" feature so it has
				// never been used.
				//if( grdSubCargo.GetCheckedDataRows() != null )
				//{
				//    foreach( DataRow drow in grdSubCargo.GetCheckedDataRows() )
				//    {
				//        string sBookingID = drow["booking_id"].ToString();
				//        string sBookingIDSub = drow["booking_id_sub"].ToString();
				//        string sItemNo = drow["item_no"].ToString();
				//        string sSubTCN = drow["tcn"].ToString();
				//        string sVoyage = drow["voyage_no"].ToString();
				//        ClsAcmsSQL.CreateITVSubMessage(sBookingID,
				//            sBookingIDSub, ActivityCd, "EDImansub", sVoyage, LocationCd,
				//            sItemNo, TerminalCd, dtActivityDate, sSubTCN);
				//    }
				//}
				Program.Show("{0} ITV messages created", i);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private bool isDuplicate(ClsLoadedCargo c, string sCode)
		{
			switch( ActivityCd )
			{
				case "OA":
					if( c.OA_OutgateCount > 0 ) return true;
					break;
				case "X1":
					if( c.X1_DeliveredCount > 0 ) return true;
					break;
			    default:
					return false;
			}
			return false;
		}

		private void cmbLocation_SelectedValueChanged(object sender, EventArgs e)
		{
			DataTable dt = ClsAcmsSQL.SelectTerminals(LocationCd);
			cmbTerminal.DataSource = dt;
			if( cmbTerminal.Table.Rows.Count > 0 )
				cmbTerminal.SelectedIndex = 0;
			else
				cmbTerminal.SelectedText = null;
		}

		private void frmCreateITV_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void grdCargo_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

		private void cbxShowAll_CheckedChanged(object sender, EventArgs e)
		{
			GetLocations();
		}

		private void grdCargo_SelectionChanged(object sender, EventArgs e)
		{
			GridEXRow gr = grdCargo.GetRow();
			if (gr == null)
			{
				grdITVHistory.DataSource = null;
				return;
			}

			string sPCFN = gr.Cells["partner_request_cd"].Text;
			string sTCN = gr.Cells["tcn"].Text;
			//DataTable dt = ClsAcmsSQL.SelectITVHistory(sPCFN, sTCN);
			// DGERDNER JUNE 2012 - Use the other ITV query so we only have one
			//  to maintain
			DateRange drNull = new DateRange();
			DataTable dt = ClsAcmsSQL.SearchITVHistory("%", "%", sTCN, "%", false, sPCFN, "%","%","%","%",true,false,drNull);
			grdITVHistory.DataSource = dt;
		}

		#endregion		// #region Event Handlers

		private void grdCargo_GroupsChanged(object sender, GroupsChangedEventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}
	}

	#region CLASS ITVCodes
	public class ITVCodes
	{
		private string _Code;
		public string sCode
		{
			get { return _Code; }
			set { _Code = value; }
		}
		private string _Description;
		public string sDescription
		{
			get { return _Description; }
			set { _Description = value; }
		}
	}
	#endregion
}