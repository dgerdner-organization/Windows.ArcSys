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
	public partial class frmConveyanceManagerAlt : frmChildBase, ISearchWindow
	{
		#region Fields

		private ClsCargoMoveSearch Options;

		private DataSet dsMoveCargo;
		private DataRelation relMoveGroup
		{
			get
			{
				return dsMoveCargo != null && dsMoveCargo.Relations.Count > 0 ? dsMoveCargo.Relations[0] : null;
			}
		}

		private DataTable dtMoveGroup
		{
			get
			{
				return dsMoveCargo != null && dsMoveCargo.Tables.Count > 0 ? dsMoveCargo.Tables[0] : null;
			}
		}

		private DataTable dtMoveCargo
		{
			get
			{
				return dsMoveCargo != null && dsMoveCargo.Tables.Count > 1 ? dsMoveCargo.Tables[1] : null;
			}
		}
		private DataTable dtConveyance;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmConveyanceManagerAlt()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			//WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			Options = new ClsCargoMoveSearch();

			DeveloperOptions();

			DefaultOptions();
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
					if (grdConveyance.RootTable.Columns.Contains("Vendor"))
						grdConveyance.RootTable.Columns.Remove("Vendor");
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
					/*if( ClsUser.CurrentUser.Vendor_Ind != "%")*/ SearchParameters();
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

		private void frmConveyanceManagerAlt_Load(object sender, EventArgs e)
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

		private void grpSearch_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
					SearchParameters();
				else if (e.KeyCode == Keys.Delete && e.Control)
					WindowHelper.ClearControls(pnlSearchParams.Controls);
				else if (e.KeyCode == Keys.R && e.Control)
					DefaultOptions();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearControls(pnlSearchParams.Controls);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			DefaultOptions();
		}

		private void DefaultOptions()
		{
			try
			{
				WindowHelper.ClearControls(pnlSearchParams.Controls);
				grpSailDt.CheckBoxChecked = true;
				grpSailDt.FromDate = DateTime.Now.AddMonths(-1);
				chkOnlyAvailable.Checked = false;
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
				Options.Dest_CDs = cmbDest.LocationCDs;
				Options.Vendor_Cd = cmbVendor.SelectedVendorCD;
				Options.Serial_No = txtSerialNo.Text.Trim();
				Options.Last_Loc_CDs = cmbLastLoc.LocationCDs;
				Options.Voyage_No = txtVoyageNo.Text.Trim();
				Options.Cargo_Status_DSCs = cmbCargoStatus.CargoStatusDSCs;
				Options.OnlyAvailable = chkOnlyAvailable.Checked;
				Options.Vessel_Sail_Dt = grpSailDt.CheckedValueRange;

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
				DataSet ds = Options.SearchCargoDS();
				DataTable dt2 = Options.SearchConveyance();
				TimeSpan time = DateTime.Now - start;
				lock (grdCargo)
				{
					dsMoveCargo = ds;
					dtConveyance = dt2;
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
				UpdateConveyanceGrid();
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
					DataTable dt = dtMoveGroup;
					DataRelation rel = relMoveGroup;

					grdCargo.DataSource = dsMoveCargo;
					grdCargo.RootTable.FilterCondition = null;
					if (dt != null)
					{
						if (dt.Rows.Count > 0 && rel != null)
							grdCargo.RootTable.ChildTables[0].DataMember = rel.RelationName;
						grdCargo.DataMember = dt.TableName;
					}

					grdCargo.Focus();
					ActiveControl = grdCargo;

					string opts = Options.ToString();
					string cap = null;
					if (string.IsNullOrEmpty(opts))
						cap = "Search for All";
					else
						cap = "Search for " + opts;
					infDockMgr.ControlPanes[pnlSearchParams].Text =
						string.Format("{0} returned {1} Row(s)", cap, grdCargo.RecordCount);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateConveyanceGrid()
		{
			try
			{
				lock (grdConveyance)
				{
					grdConveyance.DataSource = dtConveyance;
					grdConveyance.RootTable.FilterCondition = null;
					infDockMgr.ControlPanes[grdConveyance].Text =
						string.Format("{0} Conveyance{1}", grdConveyance.RecordCount,
						(grdConveyance.RecordCount != 1 ? "s" : null));

					infDockMgr.ControlPanes[grdConveyance].Pinned =
						(grdConveyance.RecordCount > 0);
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

		private void CreateFutileConveyance()
		{
			try
			{
				DataTable dtVen = ClsVendor.GetVendors(true);
				if (dtVen == null || dtVen.Rows.Count <= 0)
				{
					Program.ShowError("Cannot perform this operation, current user has no vendor association");
					return;
				}

				string vendorCd = null;
				if (dtVen.Rows.Count == 1)
					vendorCd = ClsConvert.ToString(dtVen.Rows[0]["vendor_cd"]);
				else
					vendorCd = cmbVendor.SelectedVendorCD;
				if (string.IsNullOrWhiteSpace(vendorCd))
				{
					Program.ShowError("Must specify a vendor");
					return;
				}
				ClsConveyance conveyance = null;
				using (frmEditConveyance f = new frmEditConveyance() )
				{
					conveyance = f.AddFutileConveyance(vendorCd);
				}
				if (conveyance == null) return;

				conveyance.Insert();

				DataRow dr = dtConveyance.NewRow();
				conveyance.CopyToDataRow(dr);
				ClsConveyanceType cnvType = conveyance.Conveyance_Type;
				string cnvTypeDsc = (cnvType != null) ? cnvType.Conveyance_Type_Dsc : null;
				dr["Conveyance_Type_Dsc"] = ClsConvert.ToDbObject(cnvTypeDsc);
				UpdateRowMoveInfo(conveyance.Vendor_Move, dr);
				dtConveyance.Rows.Add(dr);

				UpdateConveyanceGrid();
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

				EditCargoConveyance();
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
				if (e.KeyCode == Keys.Enter)
				{
					/*GridEXRow gr = grdCargo.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					EditCargoConveyance();

					e.Handled = true;*/
				}
				else if ((e.KeyCode == Keys.O && e.Control) || e.KeyCode == Keys.F3)
				{
					cmbOrig.Focus();
					ActiveControl = cmbOrig;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditCargoConveyance()
		{
			try
			{
				DataRow dr = grdCargo.GetDataRow();
				if (dr == null) return;

				long? cmvID = ClsConvert.ToInt64Nullable(dr["cargo_move_id"]);
				if (cmvID == null)
				{
					Program.ShowError("Cargo not found, please search again to update cargo list");
					return;
				}

				ClsCargoMove cmv = ClsCargoMove.GetUsingKey(cmvID.Value);
				if (cmv == null)
				{
					Program.ShowError("Serial # not found, please search again to update cargo list");
					return;
				}

				cmv.CopyToDataRow(dr);
				UpdateRowConveyanceInfo(cmv.Conveyance, dr);
				UpdateRowMoveInfo(cmv.Vendor_Move, dr);

				ClsConveyance cnv = cmv.Conveyance;
				if (cnv == null)
				{
					Program.ShowError("Cargo is not on a conveyance");
					return;
				}

				using (frmEditConveyance f = new frmEditConveyance())
				{
					if (!f.EditConveyance(cnv)) return;

					cnv.Update();
				}

				DataTable dtc = dtMoveCargo;
				DataRow[] cnvCargo = (dtc != null)
					? dtc.Select("conveyance_id = " + cnv.Conveyance_ID) : null;
				if (cnvCargo != null && cnvCargo.Length > 0)
				{
					foreach (DataRow drCargo in cnvCargo)
						UpdateRowConveyanceInfo(cnv, drCargo);
				}
				else
					UpdateRowConveyanceInfo(cnv, dr);
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
				if (string.Compare(e.Column.DataMember, "Truck_No", true) == 0 ||
					string.Compare(e.Column.DataMember, "Conveyance_Type_Dsc", true) == 0 ||
					string.Compare(e.Column.DataMember, "Conveyance_No", true) == 0 ||
					string.Compare(e.Column.DataMember, "Driver", true) == 0)
					EditCargoConveyance();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdConveyance_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.DataMember, "Truck_No", true) == 0 ||
					string.Compare(e.Column.DataMember, "Conveyance_Type_Dsc", true) == 0 ||
					string.Compare(e.Column.DataMember, "Conveyance_No", true) == 0 ||
					string.Compare(e.Column.DataMember, "Driver", true) == 0)
					EditConveyance();
				else if (string.Compare(e.Column.Key, "DeleteConvey", true) == 0)
				{
					DeleteConveyance();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DeleteConveyance()
		{
			try
			{
				DataRow dr = grdConveyance.GetDataRow();
				if (dr == null) return;

				ClsConveyance cnv = new ClsConveyance(dr);
				if (cnv == null) return;

				cnv.ReloadFromDB();
				if (!cnv.ValidateDelete())
				{
					Program.ShowError(cnv.Error);
					return;
				}

				if (!Display.Ask("Confirm", "Delete conveyance {0}", cnv.ToString("f"))) return;

				cnv.Delete();
				if (dtConveyance != null) dtConveyance.Rows.Remove(dr);
				infDockMgr.ControlPanes[grdConveyance].Text =
					string.Format("{0} Conveyance(s) with no cargo", grdConveyance.RecordCount);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdConveyance_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdConveyance.HitTest();
				if (ga != GridArea.Cell) return;

				EditConveyance();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdConveyance_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdConveyance.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					EditConveyance();

					e.Handled = true;
				}
				else if ((e.KeyCode == Keys.O && e.Control) || e.KeyCode == Keys.F3)
				{
					cmbOrig.Focus();
					ActiveControl = cmbOrig;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditConveyance()
		{
			try
			{
				DataRow dr = grdConveyance.GetDataRow();
				if (dr == null) return;
				ClsConveyance cnv = new ClsConveyance(dr);
				using (frmEditConveyance f = new frmEditConveyance())
				{
					if (!f.EditConveyance(cnv)) return;

					cnv.Update();

					ClsVendorMove vmv = cnv.Vendor_Move;
					ClsMove mv = vmv.Move;
					cnv.CopyToDataRow(dr);
					ClsConveyanceType cnvType = cnv.Conveyance_Type;
					string cnvTypeDsc = (cnvType != null) ? cnvType.Conveyance_Type_Dsc : null;
					dr["Conveyance_Type_Dsc"] = ClsConvert.ToDbObject(cnvTypeDsc);
					UpdateRowMoveInfo(cnv.Vendor_Move, dr);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

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

		private void cnuGrid_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AdjustMenuItems();
		}

		private void AdjustMenuItems()
		{
			try
			{
				SetEllipsisColumnGUI();
				SetSingleGUI();
				SetCheckedGUI();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetEllipsisColumnGUI()
		{
			try
			{
				GridEXColumn col1 = grdCargo.RootTable.Columns.Contains("Conveyance")
					? grdCargo.RootTable.Columns["Conveyance"] : null;
				GridEXColumn col2 = grdCargo.RootTable.Columns.Contains("Conveyance Type")
					? grdCargo.RootTable.Columns["Conveyance Type"] : null;
				ClsCargoMove cmv = null;
				DataRow dr = grdCargo.GetDataRow();
				if (dr != null && dr.Table.Columns.Contains("CARGO_MOVE_ID"))
					cmv = new ClsCargoMove(dr);
				bool editable = (cmv != null && cmv.Conveyance != null);
				if (editable)
				{
					if (col1 != null) col1.ButtonStyle = ButtonStyle.Ellipsis;
					if (col2 != null) col2.ButtonStyle = ButtonStyle.Ellipsis;
				}
				else
				{
					if (col1 != null) col1.ButtonStyle = ButtonStyle.NoButton;
					if (col2 != null) col2.ButtonStyle = ButtonStyle.NoButton;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetSingleGUI()
		{
			try
			{
				bool valid = false;
				string txt1 = "Remove Highlighted from Conveyance";
				string txt2 = "Edit Conveyance #/Type";
				DataRow dr = grdCargo.GetDataRow();
				if (dr != null && dr.Table.Columns.Contains("CARGO_MOVE_ID"))
				{
					ClsCargoMove cmv = new ClsCargoMove(dr);
					if (cmv != null && cmv.Conveyance != null)
					{
						valid = true;
						txt1 = string.Format("Remove {0} from {1}",
							cmv.Serial_No, cmv.Conveyance.Truck_No);
						txt2 = string.Format("Edit Conveyance {0}", cmv.Conveyance.Truck_No);
					}
				}

				infToolbar.Tools["RemoveSelected"].SharedProps.Enabled = valid;
				infToolbar.Tools["RemoveSelected"].SharedProps.Caption = txt1;
				infToolbar.Tools["EditEx"].SharedProps.Caption = txt1;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void SetCheckedGUI()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();

				bool valid = false;
				string txt = "Remove Checked from Conveyance";
				if (rows != null && rows.Length > 0)
				{
					List<long> convIDs = new List<long>();
					foreach (DataRow dr in rows)
					{
						long? id = ClsConvert.ToInt64Nullable(dr["conveyance_id"]);
						if (id.GetValueOrDefault(0) <= 0) continue;

						if (!convIDs.Contains(id.Value)) convIDs.Add(id.Value);
					}
					if (convIDs.Count > 0)
					{
						txt = string.Format("Remove {0} piece(s) from {1} conveyance(s)",
							rows.Length, convIDs.Count);
						valid = true;
					}
				}
				infToolbar.Tools["RemoveChecked"].SharedProps.Enabled = valid;
				infToolbar.Tools["RemoveChecked"].SharedProps.Caption = txt;
				if (valid)	// if showing checked item, don't show single item
					infToolbar.Tools["RemoveSelected"].SharedProps.Visible = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCargo_SelectionChanged(object sender, EventArgs e)
		{
			AdjustMenuItems();
		}

		private void grdCargo_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
		{
			AdjustMenuItems();
		}

		private void AddCargo()
		{
			try
			{
				grdCargo.ResetDataRowErrors();

				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No cargo rows checked");
					return;
				}

				List<long> vendorMoves = new List<long>();
				foreach (DataRow dr in rows)
				{
					long? cmvID = ClsConvert.ToInt64Nullable(dr["cargo_move_id"]);
					if (cmvID == null)
					{
						dr.RowError = "Cargo not found, please search again to update cargo list";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					ClsCargoMove cmv = ClsCargoMove.GetUsingKey(cmvID.Value);
					if (cmv == null)
					{
						dr.RowError = "Serial # not found, please search again to update cargo list";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					cmv.CopyToDataRow(dr);
					UpdateRowConveyanceInfo(cmv.Conveyance, dr);
					UpdateRowMoveInfo(cmv.Vendor_Move, dr);

					if (cmv.Conveyance_ID.GetValueOrDefault(0) > 0)
					{
						dr.RowError = "This cargo is already on a conveyance";
						dr.SetColumnError("truck_no", dr.RowError);
						continue;
					}

					if (cmv.Vendor_Move_ID.GetValueOrDefault(0) <= 0)
					{
						dr.RowError = "Move info not found for Serial #, please search again to update cargo list";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					int index = vendorMoves.IndexOf(cmv.Vendor_Move_ID.Value);
					if (index < 0)	// Vendor move NOT in the list, we will add it
					{
						vendorMoves.Add(cmv.Vendor_Move_ID.Value);
						if (vendorMoves.Count > 1)	// If this is not the 1st vendor move ID
						{							// then they are trying to mix moves
							dr.RowError = "Cannot mix moves on a single conveyance";
							dr.SetColumnError("serial_no", dr.RowError);
							continue;
						}
						//else, OK, this is the 1st move found
					}
					else// Vendor move IS IN the list (index >= 0). If index == 0, its OK because
					{	// cargo is part of the 1st move we found. If index > 0, report as error
						// This will flag all cargo part of mixed moves as an error, the code above
						// flags only the 1st piece of mixed moves.
						if (index > 0)
						{
							dr.RowError = "Cannot mix moves on a single conveyance";
							dr.SetColumnError("serial_no", dr.RowError);
							continue;
						}
					}
				}

				DataTable dtc = dtMoveCargo;
				if (dtc != null && (dtc.HasErrors || vendorMoves.Count != 1))
				{
					Program.ShowError("Unable to add selected cargo to conveyance.\r\n" +
						"Check individual cargo rows (in red) for more information");
					return;
				}

				//TODO: JROMAN if conveyance is moving, we might want to prevent this or at least
				// make it an ADMIN function. We might want insert cargo actions for all of the
				// actions that were performed on the conveyance.
				ClsConveyance cnv = null;
				using (frmEditConveyance f = new frmEditConveyance())
				{
					cnv = f.AddCargo(vendorMoves[0], rows);
				}
				if (cnv == null) return;

				if (!cnv.AddCargo(rows))
				{
					Program.ShowError(cnv.Error);
					return;
				}

				foreach (DataRow dr in rows)
				{
					UpdateRowConveyanceInfo(cnv, dr);
					//TODO: JROMAN, ensure visible on the 1st piece of cargo and
					// highlight the rows somehow, then, remove the highlight
					// in the selection change event, do the same when editing truck
				}

				grdCargo.UnCheckAllRecords();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				AdjustMenuItems();
			}
		}

		private void UpdateRowMoveInfo(ClsVendorMove vmv, DataRow dr)
		{
			try
			{
				string orig = null, dest = null, cust = null, desc = null, ven = null;
				if (vmv != null)
				{
					if (vmv.Orig_Location != null) orig = vmv.Orig_Location.Location_Dsc;
					if (vmv.Dest_Location != null) dest = vmv.Dest_Location.Location_Dsc;
					if (vmv.Vendor != null) ven = vmv.Vendor.Vendor_Nm;
					if (vmv.Move != null)
					{
						desc = vmv.Move.Move_Dsc;
						if (vmv.Move.Trading_Partner != null)
							cust = vmv.Move.Trading_Partner.Partner_Dsc;
					}
				}

				dr["orig_location_dsc"] = ClsConvert.ToDbObject(orig);
				dr["dest_location_dsc"] = ClsConvert.ToDbObject(dest);
				dr["move_dsc"] = ClsConvert.ToDbObject(desc);
				dr["partner_dsc"] = ClsConvert.ToDbObject(cust);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateRowConveyanceInfo(ClsConveyance cnv, DataRow dr)
		{
			try
			{
				long? cnvID = null;
				string conveyNo = null, truckNo = null, driver = null, cnvType = null,
					futileFlg = "N";
				if (cnv != null)
				{
					cnvID = cnv.Conveyance_ID;
					conveyNo = cnv.Conveyance_No;
					truckNo = cnv.Truck_No;
					driver = cnv.Driver;
					if (cnv.Conveyance_Type != null)
						cnvType = cnv.Conveyance_Type.Conveyance_Type_Dsc;
					futileFlg = cnv.Futile_Flg;
				}

				dr["conveyance_no"] = ClsConvert.ToDbObject(conveyNo);
				dr["truck_no"] = ClsConvert.ToDbObject(truckNo);
				dr["driver"] = ClsConvert.ToDbObject(driver);
				dr["conveyance_type_dsc"] = ClsConvert.ToDbObject(cnvType);
				dr["conveyance_id"] = ClsConvert.ToDbObject(cnvID);
				dr["futile_flg"] = ClsConvert.ToDbObject(futileFlg);
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
						object[] colValues = e.Row.GroupValue as object[];
						if (colValues != null && colValues.Length >= 4)
						{
							//long? cnvID = ClsConvert.ToInt64Nullable(colValues[1]);
							string bolNo = ClsConvert.ToString(colValues[0]);
							string sCnv = (!string.IsNullOrWhiteSpace(bolNo))
								? string.Format("Vendor Ref # {0}", bolNo) : "Available Cargo";
							e.Row.GroupCaption = string.Format("{0} from {1} to {2}",
								sCnv, colValues[2], colValues[3]);
						}
					}
				}
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
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmConveyanceManagerAlt_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmConveyanceManagerAlt_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				Control c = ActiveControl;
				if( c == null ) return;
				if (c == pnlSearchParams || c.Parent == pnlSearchParams)
				{
					if (e.KeyCode == Keys.Enter)
						SearchParameters();
					else if (e.KeyCode == Keys.Delete && e.Control)
						WindowHelper.ClearControls(pnlSearchParams.Controls);
					else if (e.KeyCode == Keys.R && e.Control)
						DefaultOptions();
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
					case "PopupAddRemove": break;
					case "AddCargo": AddCargo(); break;
					case "RemoveSelected": RemoveSelectedFromConveyance(); break;
					case "RemoveChecked": RemoveCheckedFromConveyances(); break;

					case "CreateFutile": CreateFutileConveyance(); break;
					case "EditEx": EditCargoConveyance(); break;

					case "PopupActions": break;
					case "PopupCargoActions": break;
					case "InGate": InGate(false); break;
					case "PODStamp": Delivered(false); break;
					case "T1": RequestT1(false); break;
					case "PopupConveyanceActions": break;
					case "ArrivedatPickup": TruckArrivedAtOrigin(false); break;

					case "PopupUndoActions": break;
					case "PopupUndoCargoActions": break;
					case "UndoInGate": InGate(true); break;
					case "UndoPOD": Delivered(true); break;
					case "UndoT1": RequestT1(true); break;
					case "PopupUndoConveyanceActions": break;
					case "UndoArriveatPickup": TruckArrivedAtOrigin(true); break;

					default: break;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RemoveCheckedFromConveyances()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No cargo rows are checked");
					return;
				}

				grdCargo.ResetDataRowErrors();
				StringBuilder sb = new StringBuilder();
				Dictionary<long, List<ClsCargoMove>> lstConveyCargo =
					new Dictionary<long, List<ClsCargoMove>>();
				foreach (DataRow dr in rows)
				{
					long? cmvID = ClsConvert.ToInt64Nullable(dr["cargo_move_id"]);
					if (cmvID == null)
					{
						dr.RowError = "Cargo not found, please search again to update cargo list";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					ClsCargoMove cmv = ClsCargoMove.GetUsingKey(cmvID.Value);
					if (cmv == null)
					{
						dr.RowError = "Serial # not found, please search again to update cargo list";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					cmv.CopyToDataRow(dr);
					UpdateRowConveyanceInfo(cmv.Conveyance, dr);
					UpdateRowMoveInfo(cmv.Vendor_Move, dr);

					if (cmv.Conveyance_ID.GetValueOrDefault(0) <= 0)
					{
						dr.RowError = "This cargo is not on a conveyance";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					if( cmv.Last_Logistic_Action != null )
					{	//TODO: JROMAN eventually allow admins to do this, but it involves
						// deleting all the cargo actions as well
						dr.RowError = "This cargo cannot be removed it has started moving";
						dr.SetColumnError("serial_no", dr.RowError);
						continue;
					}

					List<ClsCargoMove> lstCargo = null;
					if (lstConveyCargo.ContainsKey(cmv.Conveyance_ID.Value))
						lstCargo = lstConveyCargo[cmv.Conveyance_ID.Value];
					if (lstCargo == null)
						lstCargo = new List<ClsCargoMove>();
					lstCargo.Add(cmv);
					lstConveyCargo[cmv.Conveyance_ID.Value] = lstCargo;
				}

				DataTable dtc = dtMoveCargo;
				if (dtc != null && dtc.HasErrors)
				{
					Program.ShowError(
						"Cannot perform this operation. Check cargo rows in red for more information");
					return;
				}

				List<ClsCargoMove> lstAllCargo = new List<ClsCargoMove>();
				foreach (List<ClsCargoMove> lstCM in lstConveyCargo.Values)
				{
					if (lstCM != null || lstCM.Count > 0)
						lstAllCargo.AddRange(lstCM);
				}

				if (!Display.Ask("Confirm", "Remove {0} piece(s) of cargo from {1} conveyance(s)?",
					lstAllCargo.Count, lstConveyCargo.Count))
					return;

				ClsConnection Connection = ClsConMgr.Manager["ArcSys"];
				try
				{
					Connection.TransactionBegin();

					foreach (ClsCargoMove cmv in lstAllCargo)
					{
						cmv.Conveyance_ID = null;
						cmv.Update();
					}

					Connection.TransactionCommit();
				}
				catch( Exception exTrans )
				{
					Connection.TransactionRollback();
					Program.ShowError(exTrans);
				}

				foreach (DataRow dr in rows) UpdateRowConveyanceInfo(null, dr);

				grdCargo.UnCheckAllRecords();

				UpdateConveyanceGrid();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				AdjustMenuItems();
			}
		}

		private void RemoveSelectedFromConveyance()
		{
			try
			{
				DataRow dr = grdCargo.GetDataRow();
				if (dr == null) return;

				long? cmvID = ClsConvert.ToInt64Nullable(dr["cargo_move_id"]);
				if (cmvID == null)
				{
					Program.ShowError("Cargo not found, please search again to update cargo list");
					return;
				}

				ClsCargoMove cmv = ClsCargoMove.GetUsingKey(cmvID.Value);
				if (cmv == null)
				{
					Program.ShowError("Serial # not found, please search again to update cargo list");
					return;
				}

				cmv.CopyToDataRow(dr);
				ClsConveyance cnv = cmv.Conveyance;
				UpdateRowConveyanceInfo(cnv, dr);
				UpdateRowMoveInfo(cmv.Vendor_Move, dr);

				if (cnv == null)
				{
					Program.ShowError("{0} is not on a conveyance", cmv.Serial_No);
					return;
				}

				if (cmv.Last_Logistic_Action != null)
				{	//TODO: JROMAN eventually allow admins to do this, but it involves
					// deleting all the cargo actions as well
					Program.ShowError("{0} cannot be removed it has started moving", cmv.Serial_No);
					return;
				}

				ClsVendorMove vmv = cnv.Vendor_Move;
				ClsMove mv = vmv.Move;
				if (!Display.Ask("Confirm", "Remove {0} from conveyance {1} ({2} to {3} {4})",
					cmv.Serial_No, cnv.Truck_No, vmv.Orig_Location.Location_Dsc,
					vmv.Dest_Location.Location_Dsc, mv.Move_Dsc)) return;

				cmv.Conveyance_ID = null;
				cmv.Update();

				UpdateRowConveyanceInfo(null, dr);
				UpdateConveyanceGrid();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				AdjustMenuItems();
			}
		}
		#endregion		// #region Form Event Handlers

		#region Cargo/Conveyance Actions

		private void InGate(bool undo)
		{
			try
			{
				Program.ShowError("Not implemented yet");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void Delivered(bool undo)
		{
			try
			{
				Program.ShowError("Not implemented yet");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RequestT1(bool undo)
		{
			try
			{
				Program.ShowError("Not implemented yet");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void TruckArrivedAtOrigin(bool undo)
		{
			try
			{
				Program.ShowError("Not implemented yet");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Cargo/Conveyance Actions

		private void pnlCargo_PaintClient(object sender, PaintEventArgs e)
		{

		}
	}
}