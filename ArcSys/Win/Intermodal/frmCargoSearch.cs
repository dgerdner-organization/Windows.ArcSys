using System;
using System.Data;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmCargoSearch : frmChildBase, ISearchWindow
	{
		#region Fields/Properties

		private clsCargoParameters _CARGO_PARAMETERS = new clsCargoParameters();

		private DataSet dsCargo;

		private DataTable dtCargo
		{
			get
			{
				return (dsCargo != null && dsCargo.Tables.Contains("Cargo"))
					? dsCargo.Tables["Cargo"] : null;
			}
		}

		private DataTable dtCharges
		{
			get
			{
				return (dsCargo != null && dsCargo.Tables.Contains("CargoCharges"))
					? dsCargo.Tables["CargoCharges"] : null;
			}
		}

		private DataRelation relCharges
		{
			get
			{
				return (dsCargo != null && dsCargo.Relations.Contains("CargoCharges"))
					? dsCargo.Relations["CargoCharges"] : null;
			}
		}

		private ClsCargo _CARGO
		{
			get
			{
				return grdCargo.GetCurrentItem<ClsCargo>();
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry

		public frmCargoSearch()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
				// Nothing to do since we are not using a popup for options, usually would be following line
				//if (showOptions == true) SearchParameters();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmCargoSearch_Load(object sender, EventArgs e)
		{
			try
			{
				BindParameters();

				txtSerialNo.Focus();
				ActiveControl = txtSerialNo;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void BindParameters()
		{
			try
			{	// Cannot bind to CheckedCombos at least for now, so they will have to
				// be filled in later just before executing the search, PLOR, PLOD, etc.

				BindHelper.Bind(txtSerialNo, _CARGO_PARAMETERS, "SERIAL_NO");
				// ... and other cargo params

				BindHelper.Bind(txtBookingNo, _CARGO_PARAMETERS, "BOOKING_NO");
				BindHelper.Bind(txtBookingRef, _CARGO_PARAMETERS, "BOOKING_REF");
				BindHelper.Bind(txtBolNo, _CARGO_PARAMETERS, "BOL_NO");
				BindHelper.Bind(txtEDIRef, _CARGO_PARAMETERS, "EDI_REF");
				BindHelper.Bind(txtCustomerRef, _CARGO_PARAMETERS, "CUSTOMER_REF");
				BindHelper.Bind(txtVoyage, _CARGO_PARAMETERS, "VOYAGE_NO");
				// ... and other booking params
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void tsbSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		public void RefreshResults()
		{
			Search();
		}

		private void search_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					e.Handled = true;
					Search();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void Search()
		{
			try
			{
				_CARGO_PARAMETERS.MOVE_TYPE_CD = cmbMoveType.MoveTypeCDs;
				_CARGO_PARAMETERS.PLOR = cmbPLOR.LocationCDs;
				_CARGO_PARAMETERS.POL = cmbPOL.LocationCDs;
				_CARGO_PARAMETERS.POD = cmbPOD.LocationCDs;
				_CARGO_PARAMETERS.PLOD = cmbPLOD.LocationCDs;
				_CARGO_PARAMETERS.VESSEL_CD = cmbVessel.VesselCDs;

				PerformSearch();
			}
			catch (Exception ex)
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
				DateTime start = DateTime.Now;
				DataSet ds = clsCargoSearch.SearchCargoDS(_CARGO_PARAMETERS);
				TimeSpan time = DateTime.Now - start;
				lock (grdCargo)
				{
					dsCargo = ds;
					ElapsedTime = time;
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

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdCargo)
				{
					DataTable dt = dtCargo;
					DataRelation rel = relCharges;

					grdCargo.RootTable.FilterCondition = null;

					grdCargo.DataSource = dsCargo;
					if (dt != null)
					{
						if (dt.Rows.Count > 0 && rel != null)
							grdCargo.RootTable.ChildTables[0].DataMember = rel.RelationName;
						grdCargo.DataMember = dt.TableName;
					}

					grdCargo.RootTable.Caption = string.Format("{0} Row(s) in {1:0.00} sec",
						grdCargo.RecordCount, ElapsedTime.TotalSeconds);

					grdCargo.Focus();
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
					tsCargo.Enabled = grdCargo.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Toolbar/Form Event Handlers

		private void frmCargoSearch_FormClosing(object sender, FormClosingEventArgs e)
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

		private void tsbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearControls(grpOptions.Controls);
		}

		private void tsbRefreshResults_Click(object sender, EventArgs e)
		{
			RefreshResults();
		}

		private void tsbViewCargo_Click(object sender, EventArgs e)
		{
			ViewCargo();
		}

		private void ViewCargo()
		{
			try
			{
				ClsCargo c = _CARGO;
				ViewWindowManager.View(c);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdCargo.HitTest();
				if (ga != GridArea.Cell) return;

				ViewCargo();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode != Keys.Enter) return;

				e.Handled = true;
				ViewCargo();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				GridEXRow grow = grdCargo.CurrentRow;
				Program.LinkHandler.HandleLink(grow, e.Column.Key);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Toolbar/Form Event Handlers

        private void fixDataProblemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will fix broken conveyances that prevent cargo activity from taking place.  Do you want to do this?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string sError = null;
                bool bResult = ClsBooking.FixBrokenIntermodalData(ref sError);
                if (bResult)
                {
                    Program.Show("All bad data has been fixed.  You should be able to proceed now.");
                    return;
                }
                Program.Show(sError);
            }
            else
            {
                Program.Show("Action cancelled by user.");
            }
        }
	}
}