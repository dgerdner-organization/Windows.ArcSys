using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using CS2010.ArcSys.WinCtrls;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmViewEstimate : frmChildBase, IViewWindow
	{	//TODO: JROMAN
		// 1. Functionality to do estimate that is not tied to cargo
		// 2. Allow new AP out of AP and new AR out of AR
		// 3. Add tab group or grid or floating toolwindow that alerts the user to changes
		//    to the exception reports, mismatches, dups, no linehauls, etc. Maybe highlight
		//    rows in grid where appropriate and also a floating window with a text field that
		//    summarizes the issues and instructs users which grids to check. Or dynamically add
		//    tabs for each query. Or one tab with one grid and a set of dynamically added radio
		//    buttons that dynamically change the grid. Attempt some type of notification in
		//    the Search Estimates window.
		#region Fields/Properties

		private ClsEstimate theEstimate;
		private decimal EstimateDifference;

		private DataTable dtBookingNotes;

		private DataSet dsCargo;
		private DataTable dtCargo
		{
			get
			{
				return (dsCargo != null && dsCargo.Tables.Count > 0) ? dsCargo.Tables[0] : null;
			}
		}

		private DataRelation relCargo
		{
			get
			{
				return (dsCargo != null && dsCargo.Relations.Count > 0)
					? dsCargo.Relations[0] : null;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry

		protected frmViewEstimate() : base(Program.MainWindow, true)
		{
			InitializeComponent();

			InitWindow();
		}

		public frmViewEstimate(bool showModal)
			: base()
		{
			InitializeComponent();

			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
		}

		public void ViewEstimate(ClsEstimate anEstimate)
		{
			try
			{
				theEstimate = (anEstimate != null && anEstimate.Estimate_ID != null)
					? ClsEstimate.GetUsingKey(anEstimate.Estimate_ID.Value) : null;
				if (theEstimate == null)
				{
					Program.ShowError("No estimate provided");
					return;
				}

				theEstimate.ConfirmChanges += new ClsEstimate.PromptHandler(est_ConfirmChanges);
				theEstimate.ProgressUpdate += new ClsEstimate.ProgressHandler(est_ProgressUpdate);

				if (MdiParent == null)
					ShowDialog();
				else
					Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, theEstimate);
			}
		}

		private void InitWindow()
		{
			try
			{
				WindowHelper.InitAllGrids(this);

				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

				tabEstimateMain.DrawMode = TabDrawMode.OwnerDrawFixed;

				grdApCharges.Tag = tbbApChargesEdit;
				grdArCharges.Tag = tbbArChargesEdit;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmViewEstimate_Load(object sender, EventArgs e)
		{
			try
			{
				UpdateDisplay();

				grdApCharges.Focus();
				ActiveControl = grdApCharges;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsRefresh_Click(object sender, EventArgs e)
		{
			RefreshEstimate();
		}

		public void RefreshEstimate()
		{
			try
			{
				theEstimate.ReloadFromDB();
				UpdateDisplay();
			}

			catch (Exception ex)
			{
				Program.ShowError(ex, theEstimate);
			}
		}

		public void UpdateDisplay()
		{
			try
			{
				LoadSummary();

				LoadArEstimateCharges();

				LoadApEstimateCharges();

				LoadCargoActivities();

				Text = string.Format("{0}: {1} {2} - {3}", theEstimate.Estimate_No,
					theEstimate.Voyage_No, theEstimate.Orig_Location_Cd,
					theEstimate.Dest_Location_Cd);

				tbbMainTitle.Text = string.Format("{0}, Est Date {1}, Mileage {2}",
					theEstimate.ToString("e"),
					(theEstimate.Estimate_Dt == null ? "<None>" : ClsConfig.FormatDate(theEstimate.Estimate_Dt)),
					(theEstimate.Mileage == null ? "<None>" : theEstimate.Mileage.ToString()));

				if (grdApCharges.RecordCount <= 0 && grdArCharges.RecordCount <= 0)
				{
					splApChargeDtl.CollapseSplitter();
					splArChargeDtl.CollapseSplitter();
				}
				else
				{
					splApChargeDtl.ExpandSplitter();
					splArChargeDtl.ExpandSplitter();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return theEstimate; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			ViewEstimate(bizObject as ClsEstimate);
		}
		#endregion		// #region IViewWindow Interface Implementation

		#region Cargo Activities

		private void LoadCargoActivities()
		{
			try
			{
				if (dsCargo != null)
				{
					dsCargo.Dispose();
					dsCargo = null;
				}

				dsCargo = theEstimate.GetActivitiesPlusCharges();
				DataTable dt = dtCargo;
				DataRelation rel = relCargo;

				grdCargo.DataSource = dsCargo;
				grdCargo.RootTable.Columns["Tcn_Occurrence"].Visible = false;
				if (dt != null)
				{
					dt.Columns.Add("ap_chg_flg", typeof(short));
					dt.Columns.Add("ap_cat_flg", typeof(short));
					dt.Columns.Add("ap_lh_flg", typeof(short));
					dt.Columns.Add("ar_chg_flg", typeof(short));
					dt.Columns.Add("ar_cat_flg", typeof(short));
					dt.Columns.Add("ar_lh_flg", typeof(short));
					dt.Columns.Add("Exists_In_Line_Flg", typeof(short));
					dt.Columns.Add("Tcn_Occurrence", typeof(short));
					dt.Columns.Add("Missing_Reason", typeof(string));
					dt.Columns.Add("Ar_Ap_Diff", typeof(decimal), "AR_Total_Amt - AP_Total_Amt");
					if (dt.Rows.Count > 0 && rel != null)
						grdCargo.RootTable.ChildTables[0].DataMember = rel.RelationName;
					grdCargo.DataMember = dt.TableName;
				}

				GetChanges();

				grdAvailableCargo.DataSource = theEstimate.GetAvailableActivities();

				string tabCap = string.Format("Cargo: {0}, Unassigned: {1}",
					grdCargo.RecordCount, grdAvailableCargo.RecordCount);
				tpgCargo.Text = tabCap;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void GetChanges()
		{
			try
			{
				grdCargoChanges.DataSource = theEstimate.GetChanges();
				Infragistics.Win.UltraWinDock.DockableControlPane ccPane =
					infDockMgr.ControlPanes[pnlCargoChanges];
				ccPane.Text =
					string.Format("Cargo Change Notification ({0})", grdCargoChanges.RecordCount);

				ccPane.Settings.TabAppearance.BackColor = (grdCargoChanges.RecordCount > 0) ?
					Color.Red : Color.Empty;

				ccPane.Settings.CaptionAppearance.BackColor =
					ccPane.Settings.ActiveCaptionAppearance.BackColor =
					ccPane.Settings.TabAppearance.BackColor;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoRemove_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Removing cargo may affect estimates. Continue anyway?"))
					return;

				if (!theEstimate.RemoveCargo(rows))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}
				LoadCargoActivities();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbAvailableAdd_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdAvailableCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Adding cargo may affect estimates. Continue anyway?"))
					return;

				if (!theEstimate.AddCargo(rows))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}
				LoadCargoActivities();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoAddVendor_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Add Vendor for selected activities?"))
					return;

				string vendorCd = null;
				using (frmComboSelect<ucVendorCombo> f = new frmComboSelect<ucVendorCombo>("Select Vendor"))
				{
					ucVendorCombo cmbv = new ucVendorCombo();
					f.ComboBox = cmbv;
					cmbv.DisplayType = ComboDisplay.DescriptionOnly;
					cmbv.Filter = string.Format("Conus_Flg = '{0}'",
						theEstimate.Orig_Location.Conus_Flg);
					if (!f.GetSelection()) return;

					vendorCd = f.ComboBox.SelectedVendorCD;
				}

				if (!theEstimate.AddVendor(rows, vendorCd))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}
				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoRemoveVendor_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Remove Vendor from selected activities?"))
					return;

				if (!theEstimate.RemoveVendor(rows))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}
				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoAssignMod_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No cargo rows checked");
					return;
				}

				ClsContractMod mod = null;
				using (frmAssignContractMod f = new frmAssignContractMod())
				{
					if (!f.GetContractMod()) return;

					if (f.CreateNew)
					{
						using (frmCreateContractMod frm = new frmCreateContractMod())
						{
							mod = frm.CreateMod();
							if (mod == null) return;
						}
					}
					else
						mod = f.SelectedMod;
				}

				if (mod == null) return;

				if (!mod.AssignMod(rows))
				{
					Program.ShowError(mod.Error);
					return;
				}

				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoUnassignMod_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No cargo rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Remove Contract Mod from selected cargo?"))
					return;

				if (!theEstimate.RemoveMod(rows))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}

				UpdateDisplay();
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

				EditCargoCharge();
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
					EditCargoCharge();
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
				if (string.Compare(e.Column.Key, "EditCharge", true) == 0)
				{
					EditCargoCharge();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditCargoCharge()
		{
			try
			{
				DataRow dr = grdCargo.GetDataRow();
				if (dr == null || !dr.Table.Columns.Contains("Estimate_Charge_Dtl_ID")) return;

				ClsEstimateChargeDtl edt = new ClsEstimateChargeDtl(dr);
				if (edt != null && edt.Estimate_Charge != null)
					frmEditEstimateCharge.EditCharge(edt.Estimate_Charge);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbChangesDismiss_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdCargoChanges.RecordCount <= 0) return;

				DataRow[] rows = grdCargoChanges.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Dismiss notification for checked items?")) return;

				if (!theEstimate.DismissChanges(rows))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}
				GetChanges();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbAvailableCargoDelete_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdAvailableCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Delete cargo from the Intermodal System?"))
					return;

				string error = null;
				if (!ClsCargoActivity.DeleteCargoActivities(rows, out error))
				{
					Program.ShowError(error);
					return;
				}
				LoadCargoActivities();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbCargoRemoveFromCharges_Click(object sender, EventArgs e)
		{
			RemoveCargoFromCharges();
		}

		private void RemoveCargoFromCharges()
		{
			try
			{
				DataRow[] rows = grdCargo.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "All charges associated with selected cargo will change as a result of this operation. Continue anyway?"))
					return;

				string info = null;
				if (!theEstimate.RemoveCargoFromCharges(rows, out info))
				{
					Program.ShowError(theEstimate.Error);
					return;
				}

				using (frmMemo f = new frmMemo())
				{
					f.ViewTextFull("Changes", info, "Close");
				}

				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Cargo Activities

		#region AP Estimate Charges

		private void LoadApEstimateCharges()
		{
			try
			{
				DataTable dt = theEstimate.GetApChargesDT();
				grdApCharges.DataSource = dt;
				grdApCharges.RootTable.Caption =
					string.Format("Estimated AP (Cost) - {0} Row(s)",
					grdApCharges.RecordCount);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbApChargesNew_Click(object sender, EventArgs e)
		{
			try
			{
				frmEditEstimateCharge.AddCharge(theEstimate, ClsFinance.Codes.AP,
					ChargeCategory.All, null);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbApChargesEdit_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdApCharges.RecordCount <= 0) return;

				ClsEstimateCharge item = grdApCharges.GetCurrentItem<ClsEstimateCharge>();
				if (item == null) return;

				if (!item.ReloadFromDB())
				{
					Program.ShowError("Item no longer exists, please refresh the list");
					return;
				}

				frmEditEstimateCharge.EditCharge(item);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbApChargesDelete_Click(object sender, EventArgs e)
		{
			try
			{
				Delete(grdApCharges);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region AP Estimate Charges

		#region AR Estimate Charges

		private void LoadArEstimateCharges()
		{
			try
			{
				DataTable dt = theEstimate.GetArChargesDT();
				grdArCharges.DataSource = dt;
				grdArCharges.RootTable.Caption =
					string.Format("Estimated AR (Revenue) - {0} Row(s)",
					grdArCharges.RecordCount);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbArChargesNew_Click(object sender, EventArgs e)
		{
			NewArAssessorialCharge();
		}

		private void tbbArNewLH_Click(object sender, EventArgs e)
		{
			NewArLinehaulCharge();
		}

		private void NewArLinehaulCharge()
		{
			frmEditEstimateCharge.AddCharge(theEstimate, ClsFinance.Codes.AR,
				ChargeCategory.LineHaul, null);
		}

		private void NewArAssessorialCharge()
		{
			try
			{
				frmEditEstimateCharge.AddCharge(theEstimate, ClsFinance.Codes.AR,
					ChargeCategory.Assessorial, null);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbArChargesFromAp_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdApCharges.RecordCount <= 0) return;

				ClsEstimateCharge apChg = grdApCharges.GetCurrentItem<ClsEstimateCharge>();
				if (apChg == null) return;

				if (!apChg.ReloadFromDB())
				{
					Program.ShowError("Item no longer exists, please refresh the list");
					return;
				}

				ChargeCategory cat = (apChg.Charge_Type.IsLineHaul)
					? ChargeCategory.LineHaul : ChargeCategory.Assessorial;
				frmEditEstimateCharge.AddCharge(theEstimate, ClsFinance.Codes.AR, cat, apChg);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbArChargesEdit_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdArCharges.RecordCount <= 0) return;

				ClsEstimateCharge item = grdArCharges.GetCurrentItem<ClsEstimateCharge>();
				if (item == null) return;

				if (!item.ReloadFromDB())
				{
					Program.ShowError("Item no longer exists, please refresh the list");
					return;
				}

				frmEditEstimateCharge.EditCharge(item);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbArChargesDelete_Click(object sender, EventArgs e)
		{
			try
			{
				Delete(grdArCharges);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region AR Estimate Charges

		#region Summary

		private void LoadSummary()
		{
			try
			{
				EstimateDifference = theEstimate.GetEstimateDiff();
				tpgCharges.Text = string.Format("Estimate {0:c}", EstimateDifference);

				LoadBookingNotes();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void LoadBookingNotes()
		{
			try
			{
				rtfBookingNotes.Clear();

				StringBuilder sb = new StringBuilder();
				rtfBookingNotes.SelectionStart = rtfBookingNotes.TextLength;
				rtfBookingNotes.SelectionFont = new Font(rtfBookingNotes.Font,
					FontStyle.Bold | FontStyle.Underline);
				rtfBookingNotes.SelectedText =
					string.Format("Estimate {0}\r\nVoyage: {1}\r\nFrom {2} to {3}\r\n",
					theEstimate.Estimate_No, theEstimate.Voyage_No,
					theEstimate.Orig_Location.Location_Dsc,
					theEstimate.Dest_Location.Location_Dsc);

				sb.Length = 0;
				sb.AppendFormat("Est Date: {0}\r\nMileage: {1}\r\nID: {2}\r\n\r\n",
					(theEstimate.Estimate_Dt == null ? "<None>" : ClsConfig.FormatDate(theEstimate.Estimate_Dt)),
					(theEstimate.Mileage == null ? "<None>" : theEstimate.Mileage.ToString()),
					theEstimate.Estimate_ID);

				rtfBookingNotes.SelectionStart = rtfBookingNotes.TextLength;
				rtfBookingNotes.SelectedText = sb.ToString();

				dtBookingNotes = theEstimate.GetComments();
				if (dtBookingNotes != null)
				{
					foreach (DataRow dr in dtBookingNotes.Rows)
					{
						string bkNo = ClsConvert.ToString(dr["Booking_No"]);
						string pcfn = ClsConvert.ToString(dr["Customer_Ref"]);

						string delTxt = ClsConvert.ToString(dr["Delivery_Txt"]);
						string cargoTxt = ClsConvert.ToString(dr["Cargo_Notes_Txt"]);
						if (string.IsNullOrWhiteSpace(delTxt) &&
							string.IsNullOrWhiteSpace(cargoTxt)) continue;

						rtfBookingNotes.SelectionStart = rtfBookingNotes.TextLength;
						rtfBookingNotes.SelectionFont = new Font(rtfBookingNotes.Font,
							FontStyle.Bold |FontStyle.Underline);
						rtfBookingNotes.SelectedText = string.Format("PCFN-Booking: {0} - {1}\r\n",
							pcfn, bkNo);

						sb.Length = 0;
						sb.AppendFormat("{0}\r\nCargo Notes: {1}", delTxt, cargoTxt);

						rtfBookingNotes.SelectionStart = rtfBookingNotes.TextLength;
						rtfBookingNotes.SelectedText = sb.ToString();

						rtfBookingNotes.AppendText("\r\n\r\n");
					}

					infDockMgr.ControlPanes[rtfBookingNotes].Pinned =
						(rtfBookingNotes.TextLength > 0);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Summary

		#region Common Grid Methods

		private void grd_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				Program.LinkHandler.HandleLink(grdCargo.CurrentRow, e.Column.Key);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.Key, "grdDelBtn", true) == 0)
				{
					DeleteCurrentRow(sender as ucGridEx);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DeleteCurrentRow(ucGridEx grd)
		{
			try
			{
				DataRow dr = (grd != null) ? grd.GetDataRow() : null;
				if (dr != null)
				{
					ClsEstimateCharge chg = new ClsEstimateCharge(dr);
					if (!Display.Ask("Confirm", "Delete {0}?", chg)) return;
					dr.Delete();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void Delete(ucGridEx grd)
		{
			try
			{
				if (grd.RecordCount <= 0) return;

				ClsEstimateCharge item = grd.GetCurrentItem<ClsEstimateCharge>();
				if (item == null) return;

				string finCd = item.Finance_Cd;
				if (!Display.Ask("Confirm Delete",
					"Are you sure you want to DELETE the selected item?\r\n{0}",
					item)) return;

				if (!item.DeleteChargePlusDetail())
				{
					Program.ShowError(item.Error);
					return;
				}

				UpdateDisplay();

				grd.Focus();
				ActiveControl = grd;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;

				GridArea ga = grd.HitTest();
				if (ga != GridArea.Cell) return;

				ToolStripButton tbb = (grd != null) ? grd.Tag as ToolStripButton : null;
				if (tbb != null) tbb.PerformClick();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				//TODO: JROMAN instead of calling performclick call method otherwise
				// the focus changes to the control

				ucGridEx grd = sender as ucGridEx;
				GridEXRow gr = grd.GetRow();
				if (e.KeyCode == Keys.Enter)
				{
					if (gr == null || gr.RowType != RowType.Record) return;

					ToolStripButton tbb = (grd != null) ? grd.Tag as ToolStripButton : null;
					if (tbb != null)
					{
						e.Handled = true;
						tbb.PerformClick();
					}
				}
				else if (e.KeyCode == Keys.Insert && e.Control)
				{
					ToolStripButton tbb = null;
					if (grd == grdApCharges)
					{
						e.Handled = true;
						tbb = tbbApChargesNew;
					}
					else if (grd == grdArCharges)
					{
						e.Handled = true;
						tbb = tbbArNewLH;
					}
					if (tbb != null)
					{
						tbb.PerformClick();
					}
				}
				else if (e.KeyCode == Keys.D && e.Control)
				{
					if (gr == null || gr.RowType != RowType.Record) return;
					Delete(grd);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdCharge_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				ucGridEx grdChg = sender as ucGridEx;
				if (grdChg == null) return;

				ClsEstimateCharge echg = grdChg.GetCurrentItem<ClsEstimateCharge>();
				DataTable dtNewDetail = (echg == null) ? null : echg.GetChargeActivities();

				ucGridEx grdDtl = null;
				if (grdChg == grdArCharges)
					grdDtl = grdArChargeDtl;
				else if (grdChg == grdApCharges)
					grdDtl = grdApChargeDtl;

				DataTable dtOldDtl = grdDtl.DataSource as DataTable;
				if (dtOldDtl != null)
				{
					dtOldDtl.Dispose();
					dtOldDtl = null;
				}

				grdDtl.DataSource = dtNewDetail;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void pnlCharges_Resize(object sender, EventArgs e)
		{
			try
			{
				int pos = pnlCharges.Width / 2;
				pnlArCharges.Width = pos;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Common Grid Methods

		#region General Event Handlers

		private void tbbMainClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmViewEstimate_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (e.CloseReason == CloseReason.WindowsShutDown) return;

				if (bkgCleanup.IsBusy)
				{
					e.Cancel = true;
					Program.Show("Wait for the cleanup to finish before closing the window");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tabEstimateMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmViewEstimate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
				{
					if (e.Control)
					{
						if (tabEstimateMain.Focused) return;

						e.Handled = true;
						if (e.KeyCode == Keys.PageDown)
						{
							if (tabEstimateMain.SelectedIndex <= 0)
							{
								if (tabEstimateMain.TabCount > 1)
									tabEstimateMain.SelectedIndex = 1;
								else if (tabEstimateMain.TabCount == 1)
									tabEstimateMain.SelectedIndex = 0;
							}
							else if (tabEstimateMain.SelectedIndex == tabEstimateMain.TabCount - 1)
							{
								if (tabEstimateMain.TabCount > 0)
									tabEstimateMain.SelectedIndex = 0;
							}
							else
								tabEstimateMain.SelectedIndex = tabEstimateMain.SelectedIndex + 1;
						}
						else
						{
							if (tabEstimateMain.SelectedIndex <= 0)
							{
								if (tabEstimateMain.TabCount > 0)
									tabEstimateMain.SelectedIndex = tabEstimateMain.TabCount - 1;
							}
							else
								tabEstimateMain.SelectedIndex = tabEstimateMain.SelectedIndex - 1;
						}
					}
				}
				else if (e.KeyCode == Keys.Insert && e.Control)
				{
					if (ActiveControl == grdArCharges || ActiveControl == grdArChargeDtl ||
						ActiveControl == tbrArCharges || ActiveControl == pnlArCharges)
					{
						e.Handled = true;
						NewArLinehaulCharge();
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tabEstimateMain_DrawItem(object sender, DrawItemEventArgs e)
		{
			try
			{
				TabPage tpg = tabEstimateMain.TabPages[e.Index];
				RectangleF textRect = tabEstimateMain.GetTabRect(e.Index);
				textRect.Inflate(-3, -1);
				RectangleF boundRect = e.Bounds;

				using (Graphics g = e.Graphics)
				{
					string tabText = tpg.Text;
					Color textColor = Color.Black;
					if (tpg == tpgCharges)
					{
						if (EstimateDifference < 0) textColor = Color.Red;
					}

					using (SolidBrush b = new SolidBrush(textColor))
					{
						FontStyle fs = (e.State == DrawItemState.Selected)
							? FontStyle.Bold : FontStyle.Regular;
						if (e.State == DrawItemState.Selected)
						{
							e.DrawFocusRectangle();
						}
						using (Font f = new System.Drawing.Font(e.Font, fs))
						{
							SizeF sz = g.MeasureString(tpg.Text, f);
							//if (sz.Width > boundRect.Width)
							//								boundRect.Width = sz.Width + 40;
							using (StringFormat sf = new StringFormat(StringFormatFlags.NoWrap))
							{
								g.DrawString(tpg.Text, f, b, textRect, sf);
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
		#endregion		// #region General Event Handlers

		#region Estimate Header Info

		private void cnuOptionsMileage_Click(object sender, EventArgs e)
		{
			try
			{
				using (frmMemo f = new frmMemo())
				{
					f.NumericOnly = true;
					string disp = ( theEstimate.Mileage == null ) ? null : theEstimate.Mileage.ToString();
					if (!f.InputBox("Mileage", disp, 10)) return;

					long? val = ClsConvert.ToInt64Nullable(f.InputText);
					theEstimate.Mileage = val;
					theEstimate.Update();
					UpdateDisplay();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsEstimateDate_Click(object sender, EventArgs e)
		{
			try
			{
				using (frmDateSelector f = new frmDateSelector())
				{
					DateTime dtNow = Program.CurrentDate;
					if (!f.GetDate(theEstimate.Estimate_Dt, dtNow, dtNow)) return;

					theEstimate.Estimate_Dt = f.SelectedDate;
					theEstimate.Update();
					UpdateDisplay();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsDeleteEst_Click(object sender, EventArgs e)
		{
			try
			{
				if (!theEstimate.ValidateDelete())
				{
					Program.ShowError(theEstimate.Error);
					return;
				}

				theEstimate.Delete();
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsChangeVoyage_Click(object sender, EventArgs e)
		{
			try
			{
				string newVoyageNo = null;
				using (frmMemo f = new frmMemo())
				{
					f.UpperCase = true;
					f.MaxLength = ClsEstimate.Voyage_NoMax;
					if (!f.InputBox("Enter new Voyage #", null))
					{
						Program.ShowError("No changes made");
						return;
					}

					newVoyageNo = f.InputText;
				}

				if (string.IsNullOrWhiteSpace(newVoyageNo))
				{
					Program.ShowError("Voyage was not specified");
					return;
				}

				bool ok = theEstimate.ChangeVoyage(newVoyageNo);
				UpdateDisplay();

				if (!ok)
					Program.ShowError(theEstimate.Error);
				else
				{
					Program.ShowError("Voyage changed. The estimate will now be recomputed.");
					RecomputeAll();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Estimate Header Info

		#region Estimate Cleanup

		private ClsEstimate.ProgressHandler delProgressUpdate;
		private ClsEstimate.ProgressHandler delShowAsyncMsg;
		private ClsEstimate.PromptHandler delConfirmChanges;
		private RichTextBox rtfCleanup;

		private void InitProgressPopup()
		{
			try
			{
				if (rtfCleanup == null)
				{
					rtfCleanup = new RichTextBox();
					rtfCleanup.Parent = this;

					rtfCleanup.WordWrap = false;
					rtfCleanup.ScrollBars = RichTextBoxScrollBars.Both;
					rtfCleanup.ReadOnly = true;
					rtfCleanup.BackColor = SystemColors.ControlDark;

					rtfCleanup.Width = 740;
					rtfCleanup.Height = 540;
					rtfCleanup.Font = new Font(rtfCleanup.Font.FontFamily, 10);
				}

				rtfCleanup.Text = null;
			}
			catch (Exception ex)

			{
				Program.ShowError(ex);
			}
		}

		private void AdjustStatus(bool enable, bool displayBox)
		{
			try
			{
				tabEstimateMain.Enabled = tbrMain.Enabled = !enable;
				sbrChild.Visible = enable;

				if (enable)
				{
					if (displayBox)
					{
						InitProgressPopup();

						rtfCleanup.Left = (ClientSize.Width - rtfCleanup.Width) / 2;
						rtfCleanup.Top = (ClientSize.Height - rtfCleanup.Height) / 2;
						rtfCleanup.Visible = true;
						rtfCleanup.BringToFront();
					}
				}
				else
				{
					if( rtfCleanup != null ) rtfCleanup.Visible = false;
				}

				Application.DoEvents();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ShowAsyncMsg(string caption, string info)
		{
			try
			{
				Program.ShowError(info);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsRecomputeAll_Click(object sender, EventArgs e)
		{
			RecomputeAll();
		}

		private void RecomputeAll()
		{
			try
			{
				if (delProgressUpdate == null)
					delProgressUpdate = new ClsEstimate.ProgressHandler(ProgressUpdate);
				if (delShowAsyncMsg == null)
					delShowAsyncMsg = new ClsEstimate.ProgressHandler(ShowAsyncMsg);
				if (delConfirmChanges == null)
					delConfirmChanges = new ClsEstimate.PromptHandler(ConfirmChanges);

				sbbProgressMeter.Style = ProgressBarStyle.Marquee;

				AdjustStatus(true, true);
				bkgCleanup.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private struct AsyncReturn
		{
			public string InfoMsg;
			public string ErrMsg;
			public bool ReturnValue;
		}

		private void bkgCleanup_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			try
			{	// Initiated by call to RunWorkerAsync
				string info = null;
				bool ret = theEstimate.RefreshAllCharges(out info);
				AsyncReturn aret = new AsyncReturn();
				aret.ReturnValue = ret;
				aret.InfoMsg = info;
				aret.ErrMsg = theEstimate.Error;
				e.Result = aret;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void bkgCleanup_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			try
			{
				AdjustStatus(false, true);
				AsyncReturn aret = (AsyncReturn)e.Result;
				if (aret.ReturnValue == true)
				{
					Program.Show("Process completed successfully");
					RefreshEstimate();
				}
				else
				{
					using (frmMemo f = new frmMemo())
					{
						f.ViewTextFull("Information",
							"Error Messages\r\n----------------------------\r\n" + aret.ErrMsg +
							"\r\nProposed Changes\r\n----------------------------\r\n" +
							aret.InfoMsg, "Close");
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void est_ProgressUpdate(string caption, string info)
		{
			try
			{
				Invoke(delProgressUpdate, new string[] { caption, info });
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Invoke(delShowAsyncMsg, new string[] { "Unexpected Error", ex.Message });
			}
		}

		private void ProgressUpdate(string caption, string info)
		{
			try
			{
				sbbProgressCaption.Text = caption;
				rtfCleanup.AppendText(info);
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool est_ConfirmChanges(string info)
		{
			try
			{
				object o = Invoke(delConfirmChanges, new string[] { info });
				bool ret = (bool)o;
				return ret;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Invoke(delShowAsyncMsg, new string[] { "Unexpected Error", ex.Message });
				return false;
			}
		}

		private bool ConfirmChanges(string info)
		{
			try
			{
				AdjustStatus(false, true);
				sbbProgressCaption.Text = "Waiting for User Confirmation...";
				sbbProgressMeter.Style = ProgressBarStyle.Blocks;
				sbbProgressMeter.Maximum = 100;
				sbbProgressMeter.Value = 98;
				using (frmMemo f = new frmMemo())
				{
					f.ViewTextFull("Review Pending Changes", info, "Close");
				}

				return Display.Ask("Confirm", "Continue with recompute operation?");
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion		// #region Estimate Cleanup

		#region Check LINE

		private void tbrCargoCheckLINE_Click(object sender, EventArgs e)
		{
            CheckLineOrOcean();
            //try
            //{
            //    sbbProgressMeter.Style = ProgressBarStyle.Continuous;
            //    sbbProgressMeter.Value = 0;
            //    sbbProgressMeter.Maximum = 100;
            //    AdjustStatus(true, false);
            //    bkgCheckLINE.RunWorkerAsync();
            //}
            //catch (Exception ex)
            //{
            //    Program.ShowError(ex);
            //}
		}

        private int CheckLineOrOcean()
        {
            string sSystem = "OCEAN";
            int iMissing = 0;

            try
            {
                if (dtCargo == null || dtCargo.Rows.Count <= 0) return 0;

                int i = 0;
                foreach (DataRow drow in dtCargo.Rows)
                {
                    i++;
                    short existsInLine = 0;
                    string tcn = ClsConvert.ToString(drow["Serial_No"]);
                    string bkNo = ClsConvert.ToString(drow["Booking_No"]);
                    sSystem = ClsOceanSystem.OceanSystem(bkNo);
                    ClsVBookingCargoLine bcl = ClsVBookingCargoLine.GetByBookingSerialNo(bkNo, tcn);
                    if (bcl.IsNull())
                    {
                        iMissing++;
                        drow["Missing_Reason"] = ClsConvert.ToDbObject(
                                    string.Format("Could not find Serial # {0} on booking {1}",
                                    tcn, bkNo));
                    }
                    else
                    {
                        bool matchesIn = (
                            string.Compare(theEstimate.Orig_Location_Cd, bcl.Plor_Location_Cd, true) == 0 &&
                            string.Compare(theEstimate.Dest_Location_Cd, bcl.Pol_Location_Cd, true) == 0);
                        bool matchesOut = (
                           string.Compare(theEstimate.Orig_Location_Cd, bcl.Pod_Location_Cd, true) == 0 &&
                           string.Compare(theEstimate.Dest_Location_Cd, bcl.Plod_Dsc, true) == 0);
                        bool matchesVoy = (
                        string.Compare(theEstimate.Voyage_No, bcl.Voyage_No, true) == 0);
                        if ((matchesIn || matchesOut) && matchesVoy)
                        {
                            existsInLine = 1;
                        }
                    }
                    if (existsInLine != 1)
                    {
                        iMissing++;
                        string info = string.Format("Serial # exists but booking info {0}-{1}-{2}-{3}-{4} does not match estimate {5}-{6}-{7}",
                            bcl.Voyage_No, bcl.Plor_Location_Cd, bcl.Pol_Location_Cd, bcl.Pod_Location_Cd, bcl.Plod_Location_Cd, theEstimate.Voyage_No,
                            theEstimate.Orig_Location.Location_Dsc,
                            theEstimate.Dest_Location.Location_Dsc);
                        drow["Missing_Reason"] = ClsConvert.ToDbObject(info);
                    }
                    drow["Exists_In_Line_Flg"] = ClsConvert.ToDbObject(existsInLine);
                    //bkgCheckLINE.ReportProgress(((i + 1) * 100) / dtCargo.Rows.Count, (i + 1));
                }
                return iMissing;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return iMissing;
            }
        }

		private void bkgCheckLINE_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			try
			{	// Initiated by call to RunWorkerAsync
				int count = CheckLineOrOcean();
				e.Result = count;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private int CheckLINE()
		{
            // Obsolete.  Now use CheckLineOrOcean
			int missinCount = 0;
			try
			{
				if (dtCargo == null || dtCargo.Rows.Count <= 0) return 0;

				ClsImportLine iline = new ClsImportLine();
				for( int i = 0; i < dtCargo.Rows.Count; i++ )
				{
					DataRow dr = dtCargo.Rows[i];
					short existsInLine = 0;
					string tcn = ClsConvert.ToString(dr["Serial_No"]);
					string bkNo = ClsConvert.ToString(dr["Booking_No"]);
					if (!string.IsNullOrEmpty(tcn))
					{
						DataTable dtLine = iline.QueryLINEData("%", bkNo, tcn, false);
						if (dtLine == null || dtLine.Rows.Count <= 0)
						{
							missinCount++;
							dr["Missing_Reason"] = ClsConvert.ToDbObject(
								string.Format("Could not find Serial # {0} on booking {1}",
								tcn, bkNo));
						}
						else
						{
							string plor = null, pol = null, pod = null, plod = null, voyNo = null;
							foreach (DataRow drLine in dtLine.Rows)
							{
								plor = ClsConvert.ToString(drLine["plor"]);
								pol = ClsConvert.ToString(drLine["pol"]);
								pod = ClsConvert.ToString(drLine["pod"]);
								plod = ClsConvert.ToString(drLine["plod"]);
								voyNo = ClsConvert.ToString(drLine["voyage_no"]);
								bool matchesIn = (
									string.Compare(theEstimate.Orig_Location_Cd, plor, true) == 0 &&
									string.Compare(theEstimate.Dest_Location_Cd, pol, true) == 0);
								bool matchesOut = (
									string.Compare(theEstimate.Orig_Location_Cd, pod, true) == 0 &&
									string.Compare(theEstimate.Dest_Location_Cd, plod, true) == 0);
								bool matchesVoy = (
									string.Compare(theEstimate.Voyage_No, voyNo, true) == 0);
								if ((matchesIn || matchesOut) && matchesVoy)
								{
									existsInLine = 1;
									break;
								}
							}
							if (existsInLine != 1)
							{
								missinCount++;
								string info = string.Format("Serial # exists but booking info {0}-{1}-{2}-{3}-{4} does not match estimate {5}-{6}-{7}",
									voyNo, plor, pol, pod, plod, theEstimate.Voyage_No,
									theEstimate.Orig_Location.Location_Dsc,
									theEstimate.Dest_Location.Location_Dsc);
								dr["Missing_Reason"] = ClsConvert.ToDbObject(info);
							}
						}
					}
					dr["Exists_In_Line_Flg"] = ClsConvert.ToDbObject(existsInLine);

					bkgCheckLINE.ReportProgress(((i + 1) * 100) / dtCargo.Rows.Count, (i+1));
				}

				return missinCount;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return missinCount;
			}
		}

		private void bkgCheckLINE_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			try
			{
				sbbProgressMeter.Value = e.ProgressPercentage;
				int count = (int)e.UserState;
				sbbProgressCaption.Text =
					string.Format("Checking item {0} of {1}", count, dtCargo.Rows.Count);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void bkgCheckLINE_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			try
			{
				AdjustStatus(false, false);
				int count = (int)e.Result;
				if (count > 0)
					Program.Show("Pieces of cargo no longer in LINE: {0}. To find the TCNs that are missing examine\r\nthe last two columns of the grid (\"In LINE\" and \"Info\") for rows highlighted in yellow.",
						count);
				else
					Program.Show("All cargo exists in LINE");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Check LINE

		#region Duplicates

		private void tbbCargoCheckDup_Click(object sender, EventArgs e)
		{
			CheckDuplicateTCN();
		}

		private void CheckDuplicateTCN()
		{
			try
			{
				if (dtCargo == null || dtCargo.Rows.Count <= 0) return;

				bool hasDups = false;
				Dictionary<string, List<DataRow>> tcns = new Dictionary<string, List<DataRow>>();
				foreach (DataRow dr in dtCargo.Rows)
				{
					dr.ClearErrors();
					string tcn = ClsConvert.ToString(dr["Serial_No"]);
					if (tcn.IsNullOrWhiteSpace()) tcn = string.Empty;

					List<DataRow> lstData = null;
					if (tcns.ContainsKey(tcn))
					{
						lstData = tcns[tcn];
						int tcnOccur = lstData.Count + 1;
						dr["Tcn_Occurrence"] = ClsConvert.ToDbObject(tcnOccur);
						dr.SetColumnError("Tcn_Occurrence",
							"This TCN is duplicated. Look for rows with an exclamation point to find other occurrences");
						hasDups = true;
						lstData[0].SetColumnError("Tcn_Occurrence",
							"This is the 1st occurrence of this TCN. Look for rows in red to find subsequent occurrences");
					}
					else
					{
						lstData = new List<DataRow>();
						dr["Tcn_Occurrence"] = ClsConvert.ToDbObject(1);
						tcns[tcn] = lstData;
					}
					lstData.Add(dr);
				}

				if (hasDups)
				{
					grdCargo.RootTable.Columns["Tcn_Occurrence"].Visible = true;
					Program.ShowError("Duplicates exist, sort by TCN, then examine rows in red along with the 'Occurs' column");
				}
				else
					Program.Show("No duplicates found");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Duplicates
	}
}