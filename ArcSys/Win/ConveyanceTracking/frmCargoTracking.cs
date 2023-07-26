using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmCargoTracking : frmChildBase, ISearchWindow
	{
		#region Fields

		private ClsCargoTracking Options;

		private DataSet dsCargoPlusActions;

		private DataTable dtCargo
		{
			get
			{
				return (dsCargoPlusActions != null && dsCargoPlusActions.Tables.Count > 0)
					? dsCargoPlusActions.Tables[0] : null;
			}
		}

		private DataTable dtActions
		{
			get
			{
				return (dsCargoPlusActions != null && dsCargoPlusActions.Tables.Count > 1)
					? dsCargoPlusActions.Tables[1] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmCargoTracking()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			Options = new ClsCargoTracking();

			DeveloperOptions();
		}

		private void DeveloperOptions()
		{
			try
			{
				bool showVendor = (ClsUser.CurrentUser.Vendor_Ind == "%");
				cmbVendor.Visible = showVendor;
				if (!showVendor)
				{
					if (grdCargo.RootTable.Columns.Contains("Vendor"))
						grdCargo.RootTable.Columns.Remove("Vendor");
				}
				else
				{
					if (grdCargo.RootTable.Columns.Contains("Vendor"))
						grdCargo.RootTable.Columns["Vendor"].Visible = true;
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
				if (showOptions == true )
				{
					//SearchParameters();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void RefreshResults()
		{
			throw new NotImplementedException();
		}

		private void frmCargoTracking_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				WindowHelper.ClearControls(grpSearch.Panel.Controls);

				numDaysRDD.Value = null;
				numDaysSinceAction.Value = null;
				infRdoRDD.CheckedIndex = -1;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SearchParameters()
		{
			try
			{
				Options.Move_Dsc = cmbMove.SelectedDsc;
				Options.Orig_CDs = cmbOrig.LocationCDs;
				Options.Orig_DSCs = cmbOrig.LocationDSCs;
				Options.Dest_CDs = cmbDest.LocationCDs;
				Options.Dest_DSCs = cmbDest.LocationDSCs;
				Options.Last_Loc_CDs = cmbLastLoc.LocationCDs;
				Options.Last_Loc_DSCs = cmbLastLoc.LocationDSCs;
				Options.Vendor_Cd = cmbVendor.SelectedVendorCD;
				Options.Cargo_Status_DSCs = cmbCargoStatus.CargoStatusDSCs;
				Options.Serial_No = txtSerialNo.Text.Trim();
				Options.Vessel_CDs = cmbVessel.VesselCDs;
				Options.Voyage_No = txtVoyageNo.Text.Trim();
				Options.Vessel_Sail_Dt = grpSailDt.CheckedValueRange;
				Options.Booking_No = txtBookingNo.Text.Trim();
				Options.Customer_Ref = txtCustomerRef.Text.Trim();

				short? val = ClsConvert.ToInt16Nullable(infRdoRDD.Value);
				short? days = null;
				if (val == 2)
				{
					if (numDaysRDD.Value != null)
						days = ClsConvert.ToInt16Nullable(numDaysRDD.Value);
				}
				else if (val == 1)
				{
					days = -1;
				}
				Options.Days_RDD = days;

				days = null;
				if( numDaysSinceAction.Value != null )
					days = ClsConvert.ToInt16Nullable(numDaysSinceAction.Value);
				Options.Days_Inactive = days;

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
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
				DataSet ds = Options.SearchCargoPlusActions();
				TimeSpan time = DateTime.Now - start;
				lock (grdCargo)
				{
					dsCargoPlusActions = ds;
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

				UpdateCargoGrid();
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

		private void UpdateCargoGrid()
		{
			try
			{
				lock (grdCargo)
				{
					grdCargo.DataSource = dtCargo;
					grdCargo.RootTable.FilterCondition = null;
					grdCargo.Focus();
					ActiveControl = grdCargo;

					string opts = Options.ToString();
					string cap = null;
					if (string.IsNullOrEmpty(opts))
						cap = "Search for All";
					else
						cap = "Search for " + opts;

					string timeInfo = (ClsEnvironment.IsDeveloper)
						? string.Format(" in {0} seconds", ElapsedTime.TotalSeconds) : null;
					grpSearch.Text = string.Format("{0} returned {1} Row(s){2}",
						cap, grdCargo.RecordCount, timeInfo);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
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
					infToolbar.Enabled = btnSearch.Enabled = btnClear.Enabled =
						grdCargo.Enabled = state;
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

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Grid Operations/Event Handlers

		public static void RefreshRow()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmCargoTracking_KeyDown(object sender, KeyEventArgs e)
		{
			KeyHandler(e);
		}

		private void grdCargo_KeyDown(object sender, KeyEventArgs e)
		{
			KeyHandler(e);
		}

		private void grpSearch_KeyDown(object sender, KeyEventArgs e)
		{
			KeyHandler(e);
		}

		private void KeyHandler(KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.O && e.Control) || e.KeyCode == Keys.F3)
				{
					e.Handled = true;
					cmbOrig.Focus();
					ActiveControl = cmbOrig;
				}
				else if ((e.KeyCode == Keys.F && e.Control))
				{
					e.Handled = true;
					SearchParameters();
				}
				else if (e.KeyCode == Keys.Delete && e.Control)
				{
					WindowHelper.ClearControls(grpSearch.Panel.Controls);
					e.Handled = true;
					cmbOrig.Focus();
					ActiveControl = cmbOrig;
				}
				else if (e.KeyCode == Keys.Enter)
				{
					Control c = ActiveControl;
					if (c != null)
					{
						if (c == grpSearch || c == grpSearchPanel ||
							c.Parent == grpSearch || c.Parent == grpSearchPanel)
						{
							e.Handled = true;
							SearchParameters();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_FormattingRow(object sender, RowLoadEventArgs e)
		{
			try
			{
				if (e.Row.RowType == RowType.GroupHeader)
				{
					if (e.Row.Group != null && e.Row.Group.CustomGroup != null)
					{
						if (string.Compare(e.Row.Group.CustomGroup.Key, "grpAction", true) == 0)
						{
							object[] colValues = e.Row.GroupValue as object[];
							if (colValues != null && colValues.Length > 2)
							{
								string act = ClsConvert.ToString(colValues[0]);
								string loc = ClsConvert.ToString(colValues[1]);
								DateTime? actDate = ClsConvert.ToDateTimeNullable(colValues[2]);
								if( string.IsNullOrWhiteSpace(act))
									act = "Available";
								e.Row.GroupCaption = string.Format("{0} {1} on {2}",
									act, loc, ClsConfig.FormatDate(actDate));
							}
						}
						else if (string.Compare(e.Row.Group.CustomGroup.Key, "grpStatus", true) == 0)
						{
							object[] colValues = e.Row.GroupValue as object[];
							if (colValues != null && colValues.Length > 3)
							{
								string statusDsc = ClsConvert.ToString(colValues[1]);
								string loc = ClsConvert.ToString(colValues[2]);
								string act = ClsConvert.ToString(colValues[3]);
								if( string.IsNullOrWhiteSpace(act) ) act = string.Empty;
								string sep = null;
								if( act.Contains("depart") )
									sep = " from";
								else if( act.Contains("arrive") || act.Length < 1)
									sep = " at";
								int rowCount = e.Row.GetRecordCount();
								e.Row.GroupCaption = string.Format("{0}{1} {2} Piece Count: {3}",
									statusDsc, sep, loc, rowCount);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				DataRow dr = grdCargo.GetDataRow();
				ClsCargoMove cmv = (dr != null) ? new ClsCargoMove(dr) : null;
				if( cmv != null ) cmv.ReloadFromDB();
				if (string.Compare(e.Column.DataMember, "Tag_Commission_Dt", true) == 0 ||
					string.Compare(e.Column.DataMember, "Tag_No", true) == 0 )
				{
					CommissionDate(cmv);
				}
				else if (string.Compare(e.Column.DataMember, "Tag_Decommission_Dt", true) == 0)
				{
					if (cmv == null) return;
					DateTime? selDate = GetDate("Decommission Tag", cmv.Tag_Decommission_Dt);
					if (selDate != null)
					{
						cmv.Tag_Decommission_Dt = selDate;
						cmv.Update();
						dr["Tag_Decommission_Dt"] = ClsConvert.ToDbObject(selDate);
					}
				}
				else if (string.Compare(e.Column.DataMember, "Customs_Submitted_Dt", true) == 0)
				{
					if (cmv == null) return;
					DateTime? selDate = GetDate("Customs Submitted", cmv.Customs_Submitted_Dt);
					if (selDate != null)
					{
						cmv.Customs_Submitted_Dt = selDate;
						cmv.Update();
						dr["Customs_Submitted_Dt"] = ClsConvert.ToDbObject(selDate);
					}
				}
				else if (string.Compare(e.Column.DataMember, "Customs_Clearance_Dt", true) == 0)
				{
					if (cmv == null) return;
					DateTime? selDate = GetDate("Customs Clearance", cmv.Customs_Clearance_Dt);
					if (selDate != null)
					{
						cmv.Customs_Clearance_Dt = selDate;
						cmv.Update();
						dr["Customs_Clearance_Dt"] = ClsConvert.ToDbObject(selDate);
					}
				}
				else if (string.Compare(e.Column.DataMember, "Delivery_Txt", true) == 0)
				{
					using (frmMemo f = new frmMemo())
					{
						f.WordWrap = true;
						f.ViewText(cmv.Booking_No + " Delivery Text", cmv.Delivery_Txt);
					}
				}
				else if (string.Compare(e.Column.DataMember, "Cargo_Notes_Txt", true) == 0)
				{
					using (frmMemo f = new frmMemo())
					{
						f.WordWrap = true;
						f.ViewText(cmv.Booking_No + " Cargo Notes", cmv.Cargo_Notes_Txt);
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private DateTime? GetDate(string caption, DateTime? dtInit)
		{
			try
			{
				using (frmDateTextBox f = new frmDateTextBox())
				{
					DateTime dtNow = Program.CurrentDate;
					if (dtInit == null) dtInit = dtNow;
					f.Text = caption + " (yyyyMMdd)";
					f.EditFormat = "yyyyMMdd";
					f.DisplayFormat = "yyyy-MM-dd";
					f.Width = 240;
					if (!f.GetDate(dtInit, dtNow, dtNow.AddDays(1))) return null;

					return f.SelectedDate;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void CommissionDate(ClsCargoMove cmv)
		{
			try
			{
				if (cmv == null) return;

				Program.Show("Not implemented yet");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmCargoTracking_FormClosing(object sender, FormClosingEventArgs e)
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
		#endregion		// #region Form Event Handlers

		private void grdCargo_FilterApplied(object sender, EventArgs e)
		{
			try
			{
				IFilterCondition ifc = grdCargo.RootTable.FilterCondition;
				if (ifc != null)
				{
					grdCargo.TableHeaders = InheritableBoolean.True;
					grdCargo.RootTable.Caption =
						string.Format("{0} matching row(s), filtering on {1}",
						grdCargo.RecordCount, ifc.ToString());
				}
				else
				{
					grdCargo.RootTable.Caption = grdCargo.RecordCount + " Row(s)";
					grdCargo.TableHeaders = InheritableBoolean.False;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void infToolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			try
			{
				switch (e.Tool.Key)
				{
					case "CustomsSubmit":
						CustomsSubmit();
						break;
					case "UndoCustomsSubmit":
						UndoCustomsSubmit();
						break;
					case "CustomsClear":
						CustomsClear();
						break;
					case "UndoCustomsClear":
						UndoCustomsClear();
						break;
					case "Undo POD":
						UndoPOD();
						break;
					case "Undo InGate":
						UndoInGate();
						break;
					case "Undo Arrival":
						UndoArrive();
						break;
					case "Undo Depart":
						UndoDepart();
						break;
					case "HideActions":
						Infragistics.Win.UltraWinToolbars.StateButtonTool sbt =
							infToolbar.Tools["HideActions"] as
							Infragistics.Win.UltraWinToolbars.StateButtonTool;
						if (sbt != null)
							grdCargo.Hierarchical = !sbt.Checked;
						break;
					default: break;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CustomsSubmit()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				DateTime? selDate = GetDate("Customs Submitted", null);
				if (selDate == null) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.Customs_Submitted_Dt = selDate;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
						dr["Customs_Submitted_Dt"] = ClsConvert.ToDbObject(selDate);
				}
				catch( Exception exTrans )
				{
					if (Connection != null) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoCustomsSubmit()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Remove Customs Submitted date from checked rows?")) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.Customs_Submitted_Dt = null;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
						dr["Customs_Submitted_Dt"] = ClsConvert.ToDbObject(null);
				}
				catch (Exception exTrans)
				{
					if (Connection != null) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CustomsClear()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				DateTime? selDate = GetDate("Customs Clearance", null);
				if (selDate == null) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.Customs_Clearance_Dt = selDate;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
						dr["Customs_Clearance_Dt"] = ClsConvert.ToDbObject(selDate);
				}
				catch (Exception exTrans)
				{
					if( Connection != null ) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoCustomsClear()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Remove Customs Clearance date from checked rows?")) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.Customs_Clearance_Dt = null;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
						dr["Customs_Clearance_Dt"] = ClsConvert.ToDbObject(null);
				}
				catch (Exception exTrans)
				{
					if (Connection != null) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoPOD()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				StringBuilder sb = new StringBuilder();
				StringBuilder sbRemove = new StringBuilder();
				foreach (DataRow dr in rows)
				{
					ClsCargoMove cmv = new ClsCargoMove(dr);
					cmv.ReloadFromDB();
					if (cmv.Delivery_Dt == null)
					{
						sb.AppendFormat("{0} does not have a POD stamp\r\n", cmv.Serial_No);
						continue;
					}

					ClsConveyance cnv = cmv.Conveyance;
					sbRemove.AppendFormat("{0} {1} {2} Stamped {3} Conveyance {4} {5}\r\n",
						cmv.Serial_No, cmv.Cargo_Dsc, cmv.Container_Info,
						ClsConfig.FormatDate(cmv.Delivery_Dt, "yyyy-MM-dd"),
						(cnv != null ? cnv.ToString("tc") : null), cmv.Vendor_Move.Orig_Dest_Dsc);
				}

				if (sb.Length > 0)
				{
					Program.ShowError(sb.ToString());
					return;
				}

				if (!Display.Ask("Confirm", "Remove the POD stamp for checked cargo?\r\n{0}",
					sbRemove.ToString())) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.Delivery_Dt = null;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						dr["Delivery_Dt"] = ClsConvert.ToDbObject(cmv.Delivery_Dt);
						dr["Cargo_Status"] = ClsConvert.ToDbObject(cmv.GetCargoStatus());
					}
				}
				catch (Exception exTrans)
				{
					if (Connection != null) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoInGate()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				StringBuilder sb = new StringBuilder();
				StringBuilder sbRemove = new StringBuilder();
				foreach (DataRow dr in rows)
				{
					ClsCargoMove cmv = new ClsCargoMove(dr);
					cmv.ReloadFromDB();
					if (cmv.In_Gate_Dt == null)
					{
						sb.AppendFormat("{0} does not have an InGate date\r\n", cmv.Serial_No);
						continue;
					}
					if (cmv.Delivery_Dt != null)
					{
						sb.AppendFormat("{0} has a POD stamp (remove POD first)\r\n", cmv.Serial_No);
						continue;
					}

					ClsConveyance cnv = cmv.Conveyance;
					sbRemove.AppendFormat("{0} {1} {2} InGate {3} Conveyance {4} {5}\r\n",
						cmv.Serial_No, cmv.Cargo_Dsc, cmv.Container_Info,
						ClsConfig.FormatDate(cmv.In_Gate_Dt, "yyyy-MM-dd"),
						(cnv != null ? cnv.ToString("tc") : null), cmv.Vendor_Move.Orig_Dest_Dsc);
				}

				if (sb.Length > 0)
				{
					Program.ShowError(sb.ToString());
					return;
				}

				if (!Display.Ask("Confirm", "Remove the InGate date for checked cargo?\r\n{0}",
					sbRemove.ToString())) return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						cmv.In_Gate_Dt = null;
						cmv.Update();
					}

					Connection.TransactionCommit();
					Connection = null;
					foreach (DataRow dr in rows)
					{
						ClsCargoMove cmv = new ClsCargoMove(dr);
						cmv.ReloadFromDB();
						dr["In_Gate_Dt"] = ClsConvert.ToDbObject(cmv.In_Gate_Dt);
						dr["Cargo_Status"] = ClsConvert.ToDbObject(cmv.GetCargoStatus());
					}
				}
				catch (Exception exTrans)
				{
					if (Connection != null) Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoArrive()
		{
			try
			{
				Program.Show("Function not available, use the Cargo Actions window to undo depart and arrive");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UndoDepart()
		{
			try
			{
				Program.Show("Function not available, use the Cargo Actions window to undo depart and arrive");
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
				if (string.Compare(e.Column.Key, "Serial No", true) == 0)
				{
					ClsCargoMove cmv = grdCargo.GetCurrentItem<ClsCargoMove>();
					if (cmv != null)
					{
						cmv.ReloadFromDB();
						using (frmCargoActionDetail f = new frmCargoActionDetail())
						{
							f.ShowForm(cmv);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void infRdoRDD_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				short? val = ClsConvert.ToInt16Nullable(infRdoRDD.Value);
				numDaysRDD.ReadOnly = (val.GetValueOrDefault(0) != 2);
				if (numDaysRDD.ReadOnly)
				{
					numDaysRDD.Text = null;
					numDaysRDD.Value = null;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}