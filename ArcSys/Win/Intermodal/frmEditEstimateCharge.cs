using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.Common;
using Janus.Windows.GridEX;
using Infragistics.Win.UltraWinEditors.UltraWinCalc;
using Janus.Windows.GridEX.EditControls;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditEstimateCharge : frmChildBase
	{	//TODO: JROMAN
		// 1. add check for all cargo on a PCFN when selecting by PCFN
		// 2. add check for mixing cargo contract mods, all cargo should either
		// not have a mod or all have the same mod and/or possibly redo how contract
		// mods are assigned to cargo, it may have to be added at the booking item_no
		// level instead of at the t_cargo level
		// 4. Add contract mod drop down to this window if selected then further filter grid
		// to show only cargo that has that mod
		// 5. Add an indicator (checkbox?) that indicates average as the basis is changed
		// 6. add window for adding PCFN charges, filter out PCFN on AP?
		// 7. Dynamically change tooltips for numLevel and numUnits depending on the
		// label of the numeric fields
		// 8. In LH mode, allow charge to be modified so that it can be overriden if necessary
		// 9. Determine differences in add/edit mode for USC rate functionality
		#region Fields/Properties

		private const string ChargeMemoNullText = "Add Optional Memo Here";

		/// <summary>For AR we are splitting the add charge button into 2 types: linehaul and
		/// assessorial, so when this window is called for AR, this field will be one of those
		/// 2 types. For AP we are not splitting the buttons, so when adding an AP charge, this
		/// field will be set to All.</summary>
		private ChargeCategory Category;
		private string Category_Dsc { get { return (IsAll) ? null : Category.ToString(); } }
		private bool IsAll { get { return Category == ChargeCategory.All; } }
		private bool IsNotAll	{ get { return !IsAll; } }
		private bool IsLineHaul { get { return Category == ChargeCategory.LineHaul; } }
		private bool IsAssessorial { get { return Category == ChargeCategory.Assessorial; }	}
		private bool IsAutoRate
		{	// "Automatic" Rating is for AR only
			get { return (OriginalCharge != null) ? OriginalCharge.Finance.IsAR : false; }
		}
		/// <summary>For linehaul auto rating, we display the cargo first, for all other
		/// combinations the user selects a charge type first and then we display the
		/// appropriate cargo</summary>
		private bool IsLoadCargoFirst {	 get { return IsAutoRate && IsLineHaul; } }

		protected bool IsChargeSaved;

		private UltraCalculator infCalculator;

		private ClsEstimateCharge OriginalCharge;
		private ClsEstimateCharge CopyFromCharge;

		private DataSet dsChargeActivities;
		private DataSet dsAvailableActivities;

		private DataTable dtChargeActivities
		{
			get
			{
				return (dsChargeActivities != null && dsChargeActivities.Tables.Count > 0)
					? dsChargeActivities.Tables[0] : null;
			}
		}

		private DataTable dtChargeActivityCharges
		{
			get
			{
				return (dsChargeActivities != null && dsChargeActivities.Tables.Count > 1)
					? dsChargeActivities.Tables[1] : null;
			}
		}

		private DataRelation relChargeActivities
		{
			get
			{
				return (dsChargeActivities != null && dsChargeActivities.Relations.Count > 0)
					? dsChargeActivities.Relations[0] : null;
			}
		}

		private DataTable dtAvailableActivities
		{
			get
			{
				return (dsAvailableActivities != null && dsAvailableActivities.Tables.Count > 0)
					? dsAvailableActivities.Tables[0] : null;
			}
		}

		private DataTable dtAvailableActivityCharges
		{
			get
			{
				return (dsAvailableActivities != null && dsAvailableActivities.Tables.Count > 1)
					? dsAvailableActivities.Tables[1] : null;
			}
		}

		private DataRelation relAvailableActivities
		{
			get
			{
				return (dsAvailableActivities != null && dsAvailableActivities.Relations.Count > 0)
					? dsAvailableActivities.Relations[0] : null;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmEditEstimateCharge()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			infCalculator = new UltraCalculator();
			infCalculator.DoubleClick += new EventHandler(infCalculator_DoubleClick);
			infPopupContainer.PopupControl = infCalculator;
		}

		/// <summary>Used by the static entry methods to ensure that no more than one of these
		/// windows is visible at any given time</summary>
		private static frmEditEstimateCharge EditWindow;

		/// <summary>Static entry point used to display this window to ensure that no
		/// more than 1 of this type of window is visible at any given time.</summary>
		/// <param name="anEstimate">The estimate that the charge will be added to</param>
		/// <param name="finCd">Finance code indicating AP or AR</param>
		/// <param name="cat">Value indicating the types of charges that will be available for
		/// the user to add. See the ChargeCategory enum.</param>
		/// <param name="copyChg">Optional charge that we will use a starting point</param>
		/// <returns>The instance of the window.</returns>
		public static frmEditEstimateCharge AddCharge(ClsEstimate anEstimate, string finCd,
			ChargeCategory cat, ClsEstimateCharge copyChg)
		{
			try
			{
				if (anEstimate == null || anEstimate.ReloadFromDB() == false)
				{
					Program.ShowError("Estimate does not exist");
					return null;
				}

				if (EditWindow == null)
				{
					if (!ClsFinance.Codes.IsValid(finCd))
					{
						Program.ShowError("Invalid finance code {0} specified, must be AP or AR");
						return null;
					}

					if (anEstimate.IsAccrued)
					{
						Program.ShowError("Cannot add charges after an estimate has been accrued");
						return null;
					}

					EditWindow = new frmEditEstimateCharge();
					ClsEstimateCharge newCharge = new ClsEstimateCharge();
					newCharge.SetDefaults();
					newCharge.Estimate_ID = anEstimate.Estimate_ID;
					newCharge.Finance_Cd = finCd;
					EditWindow.InitWindow(newCharge, cat, copyChg);
				}
				else
				{
					if (EditWindow.OriginalCharge.Estimate_Charge_ID == null)
						Display.Show("Add Charge in progress",
							"Please finish adding the current charge before attempting to add a new one");
					else
						Display.Show("Edit Charge in progress",
							"Please finish editing current charge before attempting to add a new one");
				}

				WindowHelper.ShowChildWindow(EditWindow);

				return EditWindow;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		/// <summary>Static entry point used to display this window to ensure that no
		/// more than 1 of this type of window is visible at any given time. The charge that
		/// will be modified is expected as a parameter</summary>
		public static frmEditEstimateCharge EditCharge(ClsEstimateCharge aCharge)
		{
			try
			{
				if (aCharge == null || aCharge.ReloadFromDB() == false)
				{
					Program.ShowError("Charge does not exist");
					return null;
				}

				if (EditWindow == null)
				{
					if (aCharge.Estimate.IsAccrued)
					{
						Program.ShowError("Cannot edit charges after an estimate has been accrued");
						return null;
					}

					EditWindow = new frmEditEstimateCharge();
					ChargeCategory cat = ChargeCategory.All;
					if( aCharge.Finance.IsAR )
						cat = (aCharge.Charge_Type.IsLineHaul)
							? ChargeCategory.LineHaul : ChargeCategory.Assessorial;
					EditWindow.InitWindow(aCharge, cat, null);
				}
				else
				{
					if (EditWindow.OriginalCharge.Estimate_Charge_ID != aCharge.Estimate_Charge_ID)
						Display.Show("Edit Charge in progress",
							"Please finish editing current charge before attempting to edit another");
				}

				WindowHelper.ShowChildWindow(EditWindow);

				return EditWindow;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void InitWindow(ClsEstimateCharge aCharge, ChargeCategory cat,
			ClsEstimateCharge copyChg)
		{
			try
			{
				Category = cat;
				IsChargeSaved = false;

				OriginalCharge = aCharge;
				CopyFromCharge = copyChg;

				Text = string.Format("{0} {1} {2} {3}", OriginalCharge.Estimate.Estimate_No,
					(OriginalCharge.Estimate_Charge_ID == null ? "Add" : "Edit"), Category_Dsc,
					OriginalCharge.Finance.FinanceText);
				if (IsAutoRate)
				{
					tbbTitle.Text = string.Format("{0} {1} to {2}",
						(OriginalCharge.Estimate_Charge_ID == null ? "Add" : "Edit"),
						aCharge.Estimate.Orig_Location.Location_Dsc,
						aCharge.Estimate.Dest_Location.Location_Dsc);
				}
				else
					tbbTitle.Text = Text;

				numRate.TextBox.Tag = numRate;
				numPcsPerCnvy.TextBox.Tag = numPcsPerCnvy;
				numLevelCount.TextBox.Tag = numLevelCount;
				numUnits.TextBox.Tag = numUnits;

				cnuNumericMenuUndo.Tag = "Undo";
				cnuNumericMenuCut.Tag = "Cut";
				cnuNumericMenuCopy.Tag = "Copy";
				cnuNumericMenuPaste.Tag = "Paste";
				cnuNumericMenuDelete.Tag = "Delete";
				cnuNumericMenuSelectAll.Tag = "SelectAll";
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, aCharge);
			}
		}

		private void frmEditEstimateCharge_Load(object sender, EventArgs e)
		{
			try
			{
				tabUscRates.LoadRates();

				BindCharge();

				if (OriginalCharge.Estimate_Charge_ID == null)
				{
					AdjustGUI(true);
					cmbCharge.ReadOnly = false;
					ActiveControl = cmbCharge;
					cmbCharge.Focus();
					grdAvailableActivities.BuiltInTexts[GridEXBuiltInText.EmptyGridInfo] =
						"Enter a charge type first to see a list of available cargo";

					//if (OriginalCharge.Estimate.CargoWithoutLineHaulExists())
					//    cmbCharge.Filter = "charge_category_cd = 'LINEHAUL'";
					//else
					//    cmbCharge.Filter = "charge_category_cd is null or charge_category_cd <> 'LINEHAUL'";

					if (CopyFromCharge != null || IsLoadCargoFirst)
					{
						LoadCargo(false);
						AdjustGUI(false);
						AdjustList();
						ActiveControl = numRate;
						numRate.Focus();
					}
					if (IsAutoRate && IsNotAll)
						cmbCharge.Filter =
							string.Format("ISNULL(Charge_Category_Cd, 'ZZZ') {0} 'LINEHAUL'",
							(IsLineHaul ? "=" : "<>"));
				}
				else
				{
					LoadCargo(false);

					cmbCharge.ReadOnly = true;
					ActiveControl = numRate;
					numRate.Focus();
				}

				if (IsAutoRate && IsAssessorial)
				{
					GridEXColumn col = grdAvailableActivities.RootTable.Columns["Customer_Ref"];
					GridEXGroup grp = new GridEXGroup(col);
					grdAvailableActivities.RootTable.Groups.Insert(0, grp);
				}

				SetGUI();

				AddToolTipFooter();

				cmbVendor.Visible = OriginalCharge.Finance.IsAP;
				cmbCustomer.Visible = !cmbVendor.Visible;
				if (cmbVendor.Visible)
				{
					cmbVendor.Filter = string.Format("Conus_Flg = '{0}'",
						OriginalCharge.Estimate.Orig_Location.Conus_Flg);
					rtfChargeMemo.Top = 42;
					rtfChargeMemo.Height = 34;
				}
				else
				{
					//rtfChargeMemo.Top = 16;
					//rtfChargeMemo.Height = 60;
					rtfChargeMemo.Top = 42;
					rtfChargeMemo.Height = 34;
					cmbCustomer.Location = cmbVendor.Location;
					cmbCustomer.Size = cmbVendor.Size;
				}

				IsChargeDirty = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, OriginalCharge);
			}
		}

		private void AdjustList()
		{
			try
			{
				if (CopyFromCharge == null) return;

				DataTable dtCurr = dtAvailableActivities;
				DataTable dtCopy = CopyFromCharge.GetChargeActivities();
				if (dtCopy == null)
				{
					dtCurr.Rows.Clear();
					return;
				}

				for (int i = dtCurr.Rows.Count - 1; i >= 0; i--)
				{
					DataRow drCurr = dtCurr.Rows[i];
					DataRow[] checkRows = dtCopy.Select(
						string.Format("Cargo_Activity_ID = {0}", drCurr["Cargo_Activity_ID"]));
					if (checkRows != null && checkRows.Length > 0) continue;	// Found it, so leave it

					dtCurr.Rows.Remove(drCurr);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void frmEditEstimateCharge_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (IsChargeSaved) return;

				StringBuilder sb = new StringBuilder();
				if (OriginalCharge.Estimate_Charge_ID == null)
				{
					if (!string.IsNullOrEmpty(cmbCharge.SelectedChargeTypeCD) ||
						!string.IsNullOrEmpty(cmbVendor.SelectedVendorCD) ||
						cmbBasis.SelectedLevelUnitID != null || numLevelCount.Value != null ||
						numRate.Value != null || numUnits.Value != null)
						sb.AppendLine("Any changes made will be lost");
				}
				else
				{
					if (IsChargeDirty)
						sb.AppendLine("Changes have been made to the charge");
					if (IsDetailAmtDirty || IsListChanged)
						sb.AppendLine("Changes have been made to the cargo list");
				}

				if (sb.Length <= 0) return;

				sb.AppendLine("Continue without saving?");
				e.Cancel = !Display.Ask("Confirm", sb.ToString());
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmEditEstimateCharge_FormClosed(object sender, FormClosedEventArgs e)
		{
			EditWindow = null;
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Helper Methods

		private void AdjustGUI(bool chargeOnly)
		{
			try
			{
				tbbSave.Enabled = pnlCargo.Enabled = cmbBasis.Enabled =
					numLevelCount.Enabled = numUnits.Enabled = rtfChargeMemo.Enabled =
					!chargeOnly;
				if (cmbVendor.Visible)
					cmbVendor.Enabled = !chargeOnly;
				else
					cmbCustomer.Enabled = !chargeOnly;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool IsBinding;
		private void BindCharge()
		{
			try
			{
				IsBinding = true;

				if (OriginalCharge.Estimate_Charge_ID == null && CopyFromCharge != null)
				{
					numPcsPerCnvy.Value = CopyFromCharge.Pcs_Per_Conveyance;
					cmbCharge.Value = CopyFromCharge.Charge_Type_Cd;
					cmbBasis.Value = CopyFromCharge.Level_Unit_ID;
					numLevelCount.Value = CopyFromCharge.Level_Count;
					numRate.Value = CopyFromCharge.Rate_Amt;
					numUnits.Value = CopyFromCharge.Unit_Qty;
					numTotal.Value = CopyFromCharge.Total_Amt;
					numTcnCount.Value = CopyFromCharge.Tcn_Count;

					if (OriginalCharge.Finance.IsAP)
						cmbVendor.Value = CopyFromCharge.Vendor_Cd;
					else
						cmbCustomer.Value = CopyFromCharge.Customer_Cd;

					rtfChargeMemo.Text = ChargeMemoNullText;
				}
				else
				{
					numPcsPerCnvy.Value = OriginalCharge.Pcs_Per_Conveyance;
					cmbCharge.Value = OriginalCharge.Charge_Type_Cd;
					cmbBasis.Value = OriginalCharge.Level_Unit_ID;
					numLevelCount.Value = OriginalCharge.Level_Count;
					numRate.Value = OriginalCharge.Rate_Amt;
					numUnits.Value = OriginalCharge.Unit_Qty;
					numTotal.Value = OriginalCharge.Total_Amt;
					numTcnCount.Value = OriginalCharge.Tcn_Count;
					cmbVendor.Value = OriginalCharge.Vendor_Cd;
					cmbCustomer.Value = OriginalCharge.Customer_Cd;

					rtfChargeMemo.Clear();
					if (string.IsNullOrWhiteSpace(OriginalCharge.Memo))
						rtfChargeMemo.Text = ChargeMemoNullText;
					else
						rtfChargeMemo.Text = OriginalCharge.Memo;
				}
				rtfChargeMemo.MaxLength = ClsEstimateCharge.MemoMax;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				IsBinding = false;
			}
		}

		private void LoadCargo(bool resetAmt)
		{
			try
			{
				if (dsChargeActivities != null)
				{
					dsChargeActivities.Dispose();
					dsChargeActivities = null;
				}
				dsChargeActivities = OriginalCharge.GetActivitiesPlusCharges();
				DataTable dt = dtChargeActivities;
				DataRelation rel = relChargeActivities;

				grdChargeActivities.DataSource = dsChargeActivities;
				List<string> pcfns = new List<string>();
				decimal totalAmt = 0;
				if (dt != null)
				{
					dt.Columns.Add("chg_flg", typeof(short));
					dt.Columns.Add("cat_flg", typeof(short));
					if (dt.Rows.Count > 0 && rel != null)
						grdChargeActivities.RootTable.ChildTables[0].DataMember = rel.RelationName;
					grdChargeActivities.DataMember = dt.TableName;

					foreach (DataRow dr in dt.Rows)
					{
						string pcfn = ClsConvert.ToString(dr["Customer_Ref"]);
						if (!string.IsNullOrWhiteSpace(pcfn))
						{
							pcfn = pcfn.ToUpper();
							if (!pcfns.Contains(pcfn)) pcfns.Add(pcfn);
						}
						decimal? amt = ClsConvert.ToDecimalNullable(dr["Activity_Amt"]);
						totalAmt += amt.GetValueOrDefault(0);
					}
				}
				numPcfnCount.Value = pcfns.Count;

				if (resetAmt)
				{
					numTcnCount.Value = (dt != null) ? dt.Rows.Count : 0;
					numTotal.Value = totalAmt;
				}

				grdChargeActivities.RootTable.Caption =
					string.Format("{0} Row(s)", grdChargeActivities.RecordCount);

				DataColumn dc1 = dt.Columns["estimate_charge_dtl_id"];
				DataColumn dc2 = dt.Columns["estimate_charge_id"];
				DataColumn dc3 = dt.Columns["activity_amt"];

				if (dsAvailableActivities != null)
				{
					dsAvailableActivities.Dispose();
					dsAvailableActivities = null;
				}
				dsAvailableActivities = OriginalCharge.GetAvailableActivitiesPlusCharges();
				dt = dtAvailableActivities;
				rel = relAvailableActivities;

				grdAvailableActivities.DataSource = dsAvailableActivities;
				if (dt != null)
				{
					dt.Columns.Add(dc1.ColumnName, dc1.DataType);
					dt.Columns.Add(dc2.ColumnName, dc2.DataType);
					dt.Columns.Add(dc3.ColumnName, dc3.DataType);
					dt.Columns.Add("chg_flg", typeof(short));
					dt.Columns.Add("cat_flg", typeof(short));
					if (dt.Rows.Count > 0 && rel != null)
						grdAvailableActivities.RootTable.ChildTables[0].DataMember = rel.RelationName;
					grdAvailableActivities.DataMember = dt.TableName;
				}
				grdAvailableActivities.RootTable.Caption =
					string.Format("{0} Row(s)", grdAvailableActivities.RecordCount);
				FilterAllCargo();
				GridEXFilterCondition cond =
					new GridEXFilterCondition(grdAvailableActivities.RootTable.Columns["chg_flg"],
						 ConditionOperator.Equal, 0);
				grdAvailableActivities.RootTable.ApplyFilter(cond);

				grdAvailableActivities.BuiltInTexts[GridEXBuiltInText.EmptyGridInfo] =
					"No cargo available to be added for the given charge type";

				if( grdAvailableActivities.RootTable.Groups.Count > 1 )
					grdAvailableActivities.RootTable.Groups[1].Collapse();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void AddToolTipFooter()
		{
			try
			{
				if (OriginalCharge == null) return;

				SuperTipSettings tips = tipJanusMain.GetSuperTip(cmbBasis);
				string origDsc = (OriginalCharge.Level_Unit != null)
					? OriginalCharge.Level_Unit.Level_Unit_Dsc
					: OriginalCharge.Level_Unit_ID.ToString();
				tips.FooterText = string.Format("Original value: {0}", origDsc);
				tipJanusMain.SetSuperTip(cmbBasis, tips);

				tips = tipJanusMain.GetSuperTip(numLevelCount);
				tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Level_Count);
				tipJanusMain.SetSuperTip(numLevelCount, tips);

				tips = tipJanusMain.GetSuperTip(cmbCharge);
				tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Charge_Type_Cd);
				tipJanusMain.SetSuperTip(cmbCharge, tips);

				tips = tipJanusMain.GetSuperTip(numRate);
				tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Rate_Amt);
				tipJanusMain.SetSuperTip(numRate, tips);


				tips = tipJanusMain.GetSuperTip(numUnits);
				tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Unit_Qty);
				tipJanusMain.SetSuperTip(numUnits, tips);

				tips = tipJanusMain.GetSuperTip(numTotal);
				tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Total_Amt);
				tipJanusMain.SetSuperTip(numTotal, tips);

				if (cmbVendor.Visible)
				{
					tips = tipJanusMain.GetSuperTip(cmbVendor);
					tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Vendor_Cd);
					tipJanusMain.SetSuperTip(cmbVendor, tips);
				}
				else
				{
					tips = tipJanusMain.GetSuperTip(cmbCustomer);
					tips.FooterText = string.Format("Original value: {0}", OriginalCharge.Customer_Cd);
					tipJanusMain.SetSuperTip(cmbCustomer, tips);
				}

				string disp = (string.IsNullOrEmpty(OriginalCharge.Memo))
					? "<Empty>" : OriginalCharge.Memo;
				tips = tipJanusMain.GetSuperTip(rtfChargeMemo);
				tips.FooterText = string.Format("Original value: {0}", disp);
				tipJanusMain.SetSuperTip(rtfChargeMemo, tips);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void FilterAllCargo()
		{
			try
			{
				DataTable dt = dtAvailableActivities;
				if (dt == null || dt.Rows.Count <= 0) return;

				ClsChargeType chargeType = cmbCharge.SelectedChargeType;
				if (chargeType != null || IsLineHaul)
				{
					foreach (DataRow dr in dt.Rows)
					{
						dr["chg_flg"] = ClsConvert.ToDbObject(0);
						dr["cat_flg"] = ClsConvert.ToDbObject(0);

						DataRow[] chargeRows = dr.GetChildRows(relAvailableActivities);
						if (chargeRows == null || chargeRows.Length <= 0) continue;

						foreach (DataRow chargeRow in chargeRows)
						{
							ClsEstimateChargeDtl edt = new ClsEstimateChargeDtl(chargeRow);
							if (OriginalCharge.Estimate_Charge_ID != null &&
								OriginalCharge.Estimate_Charge_ID == edt.Estimate_Charge_ID) continue;
							if (IsLineHaul)
							{
								if (edt.Estimate_Charge.Charge_Type.IsLineHaul)
								{
									dr["chg_flg"] = ClsConvert.ToDbObject(1);
									dr["cat_flg"] = ClsConvert.ToDbObject(1);
								}
							}
							else
							{
								if (string.Compare(edt.Estimate_Charge.Charge_Type_Cd,
									chargeType.Charge_Type_Cd, true) == 0)
								{
									dr["chg_flg"] = ClsConvert.ToDbObject(1);
									dr["cat_flg"] = ClsConvert.ToDbObject(1);
									break;
								}
								else
								{
									if (!string.IsNullOrEmpty(edt.Estimate_Charge.Charge_Type.Charge_Category_Cd) &&
										!string.IsNullOrEmpty(chargeType.Charge_Category_Cd) &&
										string.Compare(edt.Estimate_Charge.Charge_Type.Charge_Category_Cd,
										chargeType.Charge_Category_Cd, true) == 0)
									{
										dr["chg_flg"] = ClsConvert.ToDbObject(1);
										dr["cat_flg"] = ClsConvert.ToDbObject(1);
										break;
									}
								}
							}
						}
					}
				}

				grdAvailableActivities.RootTable.RemoveFilter();
				GridEXFilterCondition cond =
					new GridEXFilterCondition(grdAvailableActivities.RootTable.Columns["chg_flg"],
						 ConditionOperator.Equal, 0);
				grdAvailableActivities.RootTable.ApplyFilter(cond);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateActivityCounts()
		{
			try
			{
				DataTable dt = dtChargeActivities;
				if (dt == null || dt.Rows.Count <= 0)
				{
					numTcnCount.Value = 0;
					numPcfnCount.Value = 0;
					return;
				}

				int tcnCount = dt.Rows.Count;
				numTcnCount.Value = tcnCount;
				GetConveyances();

				List<string> pcfns = new List<string>();
				foreach (DataRow dr in dt.Rows)
				{
					string pcfn = ClsConvert.ToString(dr["Customer_Ref"]);
					if (string.IsNullOrWhiteSpace(pcfn)) continue;
					pcfn = pcfn.ToUpper();
					if (!pcfns.Contains(pcfn)) pcfns.Add(pcfn);
				}
				numPcfnCount.Value = pcfns.Count;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				UpdateTruckType();
			}
		}

		private void UpdateTruckType()
		{
			try
			{
				if (!IsAutoRate || !IsLineHaul) return;

				DataTable dt = dtChargeActivities;
				if (dt == null || dt.Rows.Count <= 0)
				{
					tabUscRates.FilterTruckType(null, null);
					return;
				}

				bool doubleDrop = false, oog = false;
				foreach (DataRow dr in dt.Rows)
				{
					decimal? wid = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
					decimal? hgt = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
					if (hgt.GetValueOrDefault(0) > 126) doubleDrop = true;
					if (wid.GetValueOrDefault(0) > 102) oog = true;
					if (doubleDrop && oog) break;
				}

				tabUscRates.FilterTruckType(doubleDrop, oog);
				if (doubleDrop && oog)
					cmbCharge.Value = "DDOGLH";
				else if (doubleDrop && !oog)
					cmbCharge.Value = "DDIGLH";
				else if (!doubleDrop && oog)
					cmbCharge.Value = "FBOGLH";
				else //if (!doubleDrop && !oog)
					cmbCharge.Value = "FBIGLH";
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				try
				{
					if (IsAutoRate && IsLineHaul)
						infDockMgr.ControlPanes[tabUscRates].Pinned = true;
				}
				catch (Exception ex2)
				{
					ClsErrorHandler.LogException(ex2);
				}
			}
		}

		private string CargoAttributeColName
		{
			get
			{
				ClsLevelUnit lvu = cmbBasis.SelectedLevelUnit;
				return (lvu != null && lvu.Unit_Type != null) ? lvu.Unit_Type.Db_Column_Nm : null;
			}
		}
		private bool UseExactTcnAmount
		{
			get
			{
				ClsLevelUnit lvu = cmbBasis.SelectedLevelUnit;
				if (lvu == null || lvu.IsAverage == true) return false;

				string dbCol = CargoAttributeColName;
				if (string.IsNullOrEmpty(dbCol)) return false;

				return true;
			}
		}
		private void UpdateActivityAmts()
		{
			try
			{
				ClsLevelUnit lvu = cmbBasis.SelectedLevelUnit;
				bool computeExact = UseExactTcnAmount;

				if (computeExact)
				{
					string dbColName = CargoAttributeColName;

					decimal totalAmt = 0, sumAttribute = 0;

					List<GridEXRow> lst = grdChargeActivities.GetGridExRowList();
					if (lst != null)
					{
						IsDetailAmtDirty = false;
						decimal? rate = ClsConvert.ToDecimalNullable(numRate.Value);
						foreach (GridEXRow gr in lst)
						{
							DataRowView drv = gr.DataRow as DataRowView;
							DataRow dr = (drv != null) ? drv.Row : null;
							if (dr == null) continue;

							decimal? attrValue = ClsConvert.ToDecimalNullable(dr[dbColName]);
							decimal tAmt = rate.GetValueOrDefault(0) * attrValue.GetValueOrDefault(0);
							decimal tcnAmt = Math.Round(tAmt, 2, MidpointRounding.AwayFromZero);
							dr["Activity_Amt"] = ClsConvert.ToDbObject(tcnAmt);
							dr["Activity_Unit_Qty"] = ClsConvert.ToDbObject(attrValue.GetValueOrDefault(0));
							totalAmt += tcnAmt;
							sumAttribute += attrValue.GetValueOrDefault(0);

							long? edtID =
								ClsConvert.ToInt64Nullable(dr["Estimate_Charge_Dtl_ID"]);
							ClsEstimateChargeDtl edt =
								(edtID != null) ? ClsEstimateChargeDtl.GetUsingKey(edtID.Value) : null;
							decimal? oldAmt = (edt != null) ? edt.Activity_Amt : null;
							int change = (oldAmt == null || oldAmt != tcnAmt) ? 1 : 0;
							if (change == 1) IsDetailAmtDirty = true;

							decimal? oldQty = (edt != null) ? edt.Activity_Unit_Qty : null;
							change = (oldQty == null || oldQty != attrValue) ? 1 : 0;
							if (change == 1) IsDetailAmtDirty = true;

							gr.BeginEdit();
							try
							{
								string amtDesc = string.Format("{0} x {1} {2}",
									rate.GetValueOrDefault(0), attrValue.GetValueOrDefault(0),
									lvu.Unit_Type.Grid_Column_Dsc);
								gr.Cells["Amt_Dsc"].Value = amtDesc;
								gr.Cells["Amt_Change"].Value = change;
								gr.Cells["Activity_Amt"].ToolTipText =
									string.Format("Original Amount: {0:c}", oldAmt);
							}
							finally
							{
								gr.EndEdit();
							}
						}
					}

					numUnits.Value = sumAttribute;
					numTotal.Value = totalAmt;
				}
				else
				{
					DataTable dt = dtChargeActivities;
					if (dt == null || dt.Rows.Count <= 0) return;

					int? tcnCount = ClsConvert.ToInt32Nullable(numTcnCount.Value);
					if (tcnCount.GetValueOrDefault(0) <= 0) return;

					decimal? chgAmt = ClsConvert.ToDecimalNullable(numTotal.Value);

					int extraItems = 0;
					decimal perTcnAmt = 0M, extraAmt = 0.01M;
					ClsConvert.DivideCurrencyEvenly(chgAmt.GetValueOrDefault(0),
						tcnCount.Value, out perTcnAmt, out extraItems);

					foreach (DataRow dr in dt.Rows)
					{
						decimal tcnAmt = perTcnAmt;
						if (extraItems > 0)
						{
							tcnAmt += extraAmt;
							extraItems--;
						}
						dr["Activity_Amt"] = ClsConvert.ToDbObject(tcnAmt);
						dr["Activity_Unit_Qty"] = ClsConvert.ToDbObject(null);
					}

					IsDetailAmtDirty = false;
					List<GridEXRow> rows = grdChargeActivities.GetGridExRowList();
					if (rows != null)
					{
						foreach (GridEXRow gr in rows)
						{
							gr.BeginEdit();
							try
							{
								gr.Cells["Amt_Dsc"].Value = "Average";

								long? edtID =
									ClsConvert.ToInt64Nullable(gr.Cells["Estimate_Charge_Dtl_ID"].Value);
								ClsEstimateChargeDtl edt =
									(edtID != null) ? ClsEstimateChargeDtl.GetUsingKey(edtID.Value) : null;
								decimal? oldAmt = (edt != null) ? edt.Activity_Amt : null;
								decimal? amt = ClsConvert.ToDecimalNullable(gr.Cells["Activity_Amt"].Value);
								int change = (oldAmt == null || oldAmt != amt) ? 1 : 0;
								if (change == 1) IsDetailAmtDirty = true;
								gr.Cells["Amt_Change"].Value = change;
								gr.Cells["Activity_Amt"].ToolTipText =
									string.Format("Original Amount: {0:c}", oldAmt);
							}
							finally
							{
								gr.EndEdit();
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

		private void ComputeTotal()
		{
			try
			{
				if (UseExactTcnAmount) return;

				ClsLevelUnit lvu = cmbBasis.SelectedLevelUnit;

				decimal? oldTotal = ClsConvert.ToDecimalNullable(numTotal.Value);
				decimal? newTotal = null;

				long? lvlCount = ClsConvert.ToInt64Nullable(numLevelCount.Value);
				decimal? rate = ClsConvert.ToDecimalNullable(numRate.Value);

				decimal? units = (lvu == null || lvu.RequiresUnits)
					? ClsConvert.ToDecimalNullable(numUnits.Value) : 1;
				if (rate == null || units == null || lvlCount == null)
				{
					newTotal = null;
				}
				else
				{
					decimal tot = rate.Value * units.Value * lvlCount.Value;
					newTotal = tot;
				}

				if (oldTotal == newTotal) return;

				numTotal.Value = newTotal;

				CheckOriginal();

				UpdateActivityAmts();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool IsChargeDirty, IsDetailAmtDirty, IsListChanged;
		public void CheckOriginal()
		{
			try
			{
				if (OriginalCharge == null) return;

				ClsEstimateCharge chg = new ClsEstimateCharge();
				FillCharge(chg);

				cmbBasis.LabelColor = (chg.Level_Unit_ID != OriginalCharge.Level_Unit_ID)
					? Color.Red : System.Drawing.Color.Black;

				numLevelCount.LabelColor = (chg.Level_Count.GetValueOrDefault(0) !=
					OriginalCharge.Level_Count.GetValueOrDefault(0))
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				numPcsPerCnvy.LabelColor = (chg.Pcs_Per_Conveyance.GetValueOrDefault(0) !=
					OriginalCharge.Pcs_Per_Conveyance.GetValueOrDefault(0))
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				cmbCharge.LabelColor =
					(string.Compare(chg.Charge_Type_Cd, OriginalCharge.Charge_Type_Cd, true) != 0)
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				numRate.LabelColor = (chg.Rate_Amt.GetValueOrDefault(0) !=
					OriginalCharge.Rate_Amt.GetValueOrDefault(0))
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				numUnits.LabelColor = (chg.Unit_Qty.GetValueOrDefault(0) !=
					OriginalCharge.Unit_Qty.GetValueOrDefault(0))
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				numTotal.LabelColor = (chg.Total_Amt.GetValueOrDefault(0) !=
					OriginalCharge.Total_Amt.GetValueOrDefault(0))
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				if (cmbVendor.Visible)
				{
					cmbVendor.LabelColor =
						(string.Compare(chg.Vendor_Cd, OriginalCharge.Vendor_Cd, true) != 0)
						? System.Drawing.Color.Red : System.Drawing.Color.Black;
				}
				else
				{
					cmbCustomer.LabelColor =
						(string.Compare(chg.Customer_Cd, OriginalCharge.Customer_Cd, true) != 0)
						? System.Drawing.Color.Red : System.Drawing.Color.Black;
				}

				string origMemo = (string.IsNullOrEmpty(OriginalCharge.Memo))
					? ChargeMemoNullText : OriginalCharge.Memo;
				string chgMemo = (string.IsNullOrEmpty(chg.Memo))
					? ChargeMemoNullText : chg.Memo;
				rtfChargeMemo.ForeColor =
					(string.Compare(chgMemo, origMemo, true) != 0)
					? System.Drawing.Color.Red : System.Drawing.Color.Black;

				IsChargeDirty = false;
				if (cmbBasis.LabelColor == Color.Red || numLevelCount.LabelColor == Color.Red ||
					cmbCharge.LabelColor == Color.Red || numRate.LabelColor == Color.Red ||
					numUnits.LabelColor == Color.Red || numTotal.LabelColor == Color.Red ||
					numPcsPerCnvy.LabelColor == Color.Red || cmbVendor.LabelColor == Color.Red ||
					cmbCustomer.LabelColor == Color.Red || rtfChargeMemo.ForeColor == Color.Red)
					IsChargeDirty = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Charge Panel

		private string Prev_Charge_Type_Cd;
		private void cmbCharge_ValueChanged(object sender, EventArgs e)
		{
			try
			{	// Charge type should not be allowed to change when editing
				if (OriginalCharge.Estimate_Charge_ID != null) return;

				ClsChargeType cht = cmbCharge.SelectedChargeType;
				string chgTypeCd = (cht != null) ? cht.Charge_Type_Cd : null;

				if (!string.IsNullOrEmpty(chgTypeCd))
				{
					if (string.Compare(Prev_Charge_Type_Cd, chgTypeCd, true) != 0)
					{
						if (!IsLoadCargoFirst) LoadCargo(true);
						ShowAssessorial();

						if (!pnlCargo.Enabled) AdjustGUI(false);

						ClsLevelUnit levUnitDefault =
							(OriginalCharge.Finance.IsAR) ? cht.Ar_Level_Unit : cht.Ap_Level_Unit;
						if (levUnitDefault != null)
						{
							cmbBasis.Value = levUnitDefault.Level_Unit_ID;
							cmbBasis.Text = levUnitDefault.Level_Unit_Dsc;
						}
						else
						{
							cmbBasis.Value = null;
							cmbBasis.Text = null;
						}

						SetGUI();
						CheckOriginal();
					}
				}
				else
				{
					SetGUI();
					CheckOriginal();
				}

				Prev_Charge_Type_Cd = chgTypeCd;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ShowAssessorial()
		{
			try
			{
				if (IsAutoRate && IsAssessorial)
				{
					infDockMgr.ControlPanes[tabUscRates].Pinned = true;
					tabUscRates.GotoAssessorial(false);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private int? prevTcnCount;
		private long? prevPPC, prevLevelCount;
		private decimal? prevRate, prevUnits;
		private void numRate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				decimal? rate = ClsConvert.ToDecimalNullable(numRate.Value);
				if (rate == prevRate) return;

				if (UseExactTcnAmount)
					UpdateActivityAmts();
				else
					ComputeTotal();

				prevRate = rate;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void numPcsPerCnvy_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				long? ppc = ClsConvert.ToInt64Nullable(numPcsPerCnvy.Value);
				if (ppc == prevPPC) return;

				GetConveyances();

				prevPPC = ppc;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void numTcnCount_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				int? tcns = ClsConvert.ToInt32Nullable(numTcnCount.Value);
				if (tcns == prevTcnCount) return;

				GetConveyances();

				prevTcnCount = tcns;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void GetConveyances()
		{
			try
			{
				if (!numPcsPerCnvy.Visible) return;

				long? ppc = ClsConvert.ToInt32Nullable(numPcsPerCnvy.Value);
				if (ppc.GetValueOrDefault(0) <= 0)
				{
					long? val = ClsConvert.ToInt64Nullable(numLevelCount.Value);
					if (val.GetValueOrDefault(0) > 0)
						numLevelCount.Value = 0;
					return;
				}

				DataTable dt = dtChargeActivities;
				long rowCount = (dt != null) ? dt.Rows.Count : 0;
				long cnvys = rowCount / ppc.Value;
				if (rowCount % ppc.Value != 0) cnvys++;
				numLevelCount.Value = cnvys;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void numLevelCount_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				long? cnt = ClsConvert.ToInt64Nullable(numLevelCount.Value);
				if (cnt == prevLevelCount) return;

				if (!UseExactTcnAmount)
					ComputeTotal();

				prevLevelCount = cnt;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void numUnits_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				decimal? units = ClsConvert.ToDecimalNullable(numUnits.Value);
				if (units == prevUnits) return;

				if (!UseExactTcnAmount)
					ComputeTotal();

				prevUnits = units;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private ClsLevelUnit prevLU;
		private void cmbBasis_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (IsBinding)
				{
					prevLU = cmbBasis.SelectedLevelUnit;
					return;
				}

				if (cmbBasis.SelectedLevelUnit == null) return;

				SetGUI();
				prevLU = cmbBasis.SelectedLevelUnit;

				if (UseExactTcnAmount)
					UpdateActivityAmts();
				else
					ComputeTotal();

				CheckOriginal();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetGUI()
		{
			try
			{
				ClsChargeType cht = cmbCharge.SelectedChargeType;
				bool isLinehaul = (cht != null && cht.IsLineHaul);

				bool requiresUnits = false, isTruckLevel = false, computeExact = false;
				string levCountDsc = "Qty", unitQtyDsc = "Qty 2",
					unitTotalDesc = "Qty 2", dbColName = null;
				ClsLevelUnit lvu = cmbBasis.SelectedLevelUnit;
				if (lvu != null)
				{
					requiresUnits = lvu.RequiresUnits;
					isTruckLevel = (lvu.Level != null) ? lvu.Level.IsConveyance : false;

					levCountDsc = lvu.Level_Count_Dsc;
					unitQtyDsc = lvu.Unit_Qty_Dsc;
					if (lvu.Unit_Type != null)
					{
						if (requiresUnits && !string.IsNullOrEmpty(lvu.Unit_Type.Grid_Column_Dsc))
							unitTotalDesc = lvu.Unit_Type.Grid_Column_Dsc;

						dbColName = lvu.Unit_Type.Db_Column_Nm;
						if (lvu.IsAverage == false && !string.IsNullOrEmpty(dbColName))
							computeExact = true;
					}
				}

				numPcsPerCnvy.Visible = isTruckLevel && isLinehaul;
				numPcsPerCnvy.LabelText = numPcsPerCnvy.Visible ? "Pcs/Cnvy" : null;

				if (computeExact)
				{
					numLevelCount.Visible = false;
					numLevelCount.LabelText = null;
					numLevelCount.Value = 1;
					grdChargeActivities.RootTable.Columns["Activity_Unit_Qty"].Visible = true;
					grdChargeActivities.RootTable.Columns["Activity_Amt"].Caption = "Amount";
				}
				else
				{
					numLevelCount.Visible = true;
					numLevelCount.ReadOnly = numPcsPerCnvy.Visible;
					numLevelCount.LabelText = levCountDsc;

					numLevelCount.Left = (numPcsPerCnvy.Visible) ? 171 : 119;
					numLevelCount.Width = (numPcsPerCnvy.Visible) ? 67 : 119;
					grdChargeActivities.RootTable.Columns["Activity_Unit_Qty"].Visible = false;
					grdChargeActivities.RootTable.Columns["Activity_Amt"].Caption = "Avg. Amt";
				}

				numUnits.LabelText = unitQtyDsc;
				if (requiresUnits)
				{
					numUnits.Visible = true;
					if (computeExact)
					{
						numUnits.ReadOnly = true;
						numUnits.Value = GetAttributeSum(dbColName);
					}
					else
					{
						numUnits.ReadOnly = false;
						if (prevLU != null && lvu != null && lvu.RequiresUnits != prevLU.RequiresUnits)
							numUnits.Value = null;
					}
				}
				else
				{
					numUnits.Value = 1;
					numUnits.ReadOnly = true;
					numUnits.Visible = false;
				}

				if (numUnits.Visible)
				{
					numTotal.LabelText = string.Format("Rate x {0} x {1}",
						numLevelCount.LabelText, unitTotalDesc);
					numTotal.Left = numUnits.Right + 6;
				}
				else
				{
					numTotal.LabelText = "Rate x " + numLevelCount.LabelText;
					numTotal.Left = numLevelCount.Right + 6;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private decimal? GetAttributeSum(string colName)
		{
			try
			{
				if (string.IsNullOrEmpty(colName)) return null;

				List<DataRow> lst = grdChargeActivities.GetDataRowList();
				if (lst == null || lst.Count <= 0) return 0;

				decimal sum = 0;
				foreach (DataRow dr in lst)
				{
					decimal? val = ClsConvert.ToDecimalNullable(dr[colName]);
					sum += val.GetValueOrDefault(0);
				}
				return sum;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void cmbVendor_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (IsBinding || OriginalCharge.Finance.IsAR) return;

				CheckOriginal();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cmbCustomer_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (IsBinding || OriginalCharge.Finance.IsAP) return;

				CheckOriginal();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void rtfChargeMemo_Enter(object sender, EventArgs e)
		{
			try
			{
				if (string.Compare(rtfChargeMemo.Text, ChargeMemoNullText, true) == 0)
				{
					rtfChargeMemo.Clear();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void rtfChargeMemo_Leave(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(rtfChargeMemo.Text))
				{
					rtfChargeMemo.Text = ChargeMemoNullText;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void rtfChargeMemo_Validated(object sender, EventArgs e)
		{
			try
			{
				if (IsBinding) return;

				CheckOriginal();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Charge Panel

		#region Grid Row Movement

		private void grd_GroupsChanged(object sender, GroupsChangedEventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				grd.CollapseGroups();
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
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				if (e.KeyCode == Keys.A && e.Control)
				{
					grd.CheckAllRecords();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_DragEnter(object sender, DragEventArgs e)
		{
			try
			{
				e.Effect = DragDropEffects.Move;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_RowDrag(object sender, Janus.Windows.GridEX.RowDragEventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null || grd.SelectedItems == null ||
					grd.SelectedItems.Count <= 0) return;

				List<DataRow> lst = new List<DataRow>();
				foreach (GridEXSelectedItem gsi in grd.SelectedItems)
				{
					GridEXRow g = gsi.GetRow();
					DataRowView drv = (g != null) ? g.DataRow as DataRowView : null;
					if (drv != null && drv.Row != null) lst.Add(drv.Row);
				}

				if (lst.Count > 0) grd.DoDragDrop(lst, DragDropEffects.Move);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				Type t = typeof(List<DataRow>);
				if (e.Data.GetDataPresent(t) == false) return;

				List<DataRow> lst = (List<DataRow>)e.Data.GetData(t);
				if (lst == null || lst.Count <= 0) return;

				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				DataSet dsTo = grd.DataSource as DataSet;
				DataSet dsFrom = lst[0].Table.DataSet;
				MoveRows(dsFrom, dsTo, lst);
				lst.Clear();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void MoveRows(DataSet dsFrom, DataSet dsTo, List<DataRow> dataRowList)
		{
			try
			{
				if (dsFrom == null || dsTo == null || dsFrom == dsTo || dataRowList == null ||
					dataRowList.Count <= 0) return;

				DataTable dtFrom = (dsFrom.Tables.Count > 0) ? dsFrom.Tables[0] : null;
				DataTable dtTo = (dsTo.Tables.Count > 0) ? dsTo.Tables[0] : null;
				if (dtFrom == null || dtTo == null || dtFrom == dtTo) return;

				DataTable childFrom = (dsFrom.Tables.Count > 1) ? dsFrom.Tables[1] : null;
				DataRelation relFrom = (dsFrom.Relations.Count > 0) ? dsFrom.Relations[0] : null;

				DataTable childTo = (dsTo.Tables.Count > 1) ? dsTo.Tables[1] : null;

				IsListChanged = true;
				foreach (DataRow dr in dataRowList)
				{
					dtTo.ImportRow(dr);
					DataRow[] childRows = dr.GetChildRows(relFrom);
					if (childRows != null && childRows.Length > 0)
					{
						foreach (DataRow childRow in childRows)
						{
							childTo.ImportRow(childRow);
							childFrom.Rows.Remove(childRow);
						}
					}
					dtFrom.Rows.Remove(dr);
				}

				UpdateActivityCounts();
				if (dsTo == dsAvailableActivities)
					FilterAllCargo();
				UpdateActivityAmts();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnCheckedAvlToDtl_Click(object sender, EventArgs e)
		{
			MoveChecked(grdAvailableActivities, dsAvailableActivities, dsChargeActivities);
		}

		private void btnCheckedDtlToAvl_Click(object sender, EventArgs e)
		{
			MoveChecked(grdChargeActivities, dsChargeActivities, dsAvailableActivities);
		}

		private void btnAllToRight_Click(object sender, EventArgs e)
		{
			MoveAll(grdAvailableActivities, dsAvailableActivities, dsChargeActivities);
		}

		private void btnAllToLeft_Click(object sender, EventArgs e)
		{
			MoveAll(grdChargeActivities, dsChargeActivities, dsAvailableActivities);
		}

		private void grd_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				GridArea ga = grd.HitTest();
				if (ga != GridArea.Cell) return;

				if (grd == grdAvailableActivities)
					MoveSelected(grdAvailableActivities, dsAvailableActivities, dsChargeActivities);
				else if (grd == grdChargeActivities)
					MoveSelected(grdChargeActivities, dsChargeActivities, dsAvailableActivities);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void MoveChecked(ucGridEx grdFrom, DataSet dsFrom, DataSet dsTo)
		{
			try
			{
				DataRow[] checkedRows = grdFrom.GetCheckedDataRows();
				if (checkedRows == null || checkedRows.Length <= 0) return;

				List<DataRow> lst = new List<DataRow>();
				foreach (DataRow dr in checkedRows) lst.Add(dr);
				if (lst.Count <= 0) return;

				MoveRows(dsFrom, dsTo, lst);
				lst.Clear();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void MoveAll(ucGridEx grdFrom, DataSet dsFrom, DataSet dsTo)
		{
			try
			{
				List<DataRow> lst = grdFrom.GetDataRowList();
				if (lst == null || lst.Count <= 0) return;

				MoveRows(dsFrom, dsTo, lst);
				lst.Clear();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void MoveSelected(ucGridEx grdFrom, DataSet dsFrom, DataSet dsTo)
		{
			try
			{
				List<DataRow> lst = grdFrom.GetSelectedDataRowList();
				if (lst == null || lst.Count <= 0) return;

				/*List<DataRow> allRows = grdFrom.GetDataRowList();
				if (allRows != null && allRows.Count > 0)
				{
					List<DataRow> moreRows = new List<DataRow>();
					foreach (DataRow dr in lst)
					{
						string bkNo = ClsConvert.ToString(dr["Booking_No"]);
						int? itemNo = ClsConvert.ToInt32Nullable(dr["Item_No"]);

						if (string.IsNullOrEmpty(bkNo) || itemNo == null) continue;

						foreach (DataRow drAll in allRows)
						{
							if (drAll == dr) continue;

							string gbkNo = ClsConvert.ToString(drAll["Booking_No"]);
							int? gitemNo = ClsConvert.ToInt32Nullable(drAll["Item_No"]);

							if (string.Compare(bkNo, gbkNo, true) != 0 || itemNo != gitemNo) continue;

							if (!moreRows.Contains(drAll))
								moreRows.Add(drAll);
						}
					}
					lst.AddRange(moreRows);
				}*/
				MoveRows(dsFrom, dsTo, lst);
				lst.Clear();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		//private bool InAvlCheckStateHandler;
		private void grdAvailableActivities_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
		{
			try
			{
				/*if (InAvlCheckStateHandler || e.Row == null) return;

				InAvlCheckStateHandler = true;
				try
				{
					string bkNo = ClsConvert.ToString(e.Row.Cells["Booking_No"].Value);
					int? itemNo = ClsConvert.ToInt32Nullable(e.Row.Cells["Item_No"].Value);

					if (string.IsNullOrEmpty(bkNo) || itemNo == null) return;

					List<GridEXRow> lst = grdAvailableActivities.GetGridExRowList();
					if (lst == null || lst.Count <= 0) return;

					foreach (GridEXRow gr in lst)
					{
						if (e.Row == gr) continue;
						string gbkNo = ClsConvert.ToString(gr.Cells["Booking_No"].Value);
						int? gitemNo = ClsConvert.ToInt32Nullable(gr.Cells["Item_No"].Value);

						if (string.Compare(bkNo, gbkNo, true) != 0 || itemNo != gitemNo) continue;

						gr.CheckState = e.CheckState;
					}
				}
				finally
				{
					InAvlCheckStateHandler = false;
				}*/
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		//private bool InActCheckStateHandler;
		private void grdChargeActivities_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
		{
			try
			{
				/*if (InActCheckStateHandler || e.Row == null) return;

				InActCheckStateHandler = true;
				try
				{
					string bkNo = ClsConvert.ToString(e.Row.Cells["Booking_No"].Value);
					int? itemNo = ClsConvert.ToInt32Nullable(e.Row.Cells["Item_No"].Value);

					if (string.IsNullOrEmpty(bkNo) || itemNo == null) return;

					List<GridEXRow> lst = grdChargeActivities.GetGridExRowList();
					if (lst == null || lst.Count <= 0) return;

					foreach (GridEXRow gr in lst)
					{
						if (e.Row == gr) continue;
						string gbkNo = ClsConvert.ToString(gr.Cells["Booking_No"].Value);
						int? gitemNo = ClsConvert.ToInt32Nullable(gr.Cells["Item_No"].Value);

						if (string.Compare(bkNo, gbkNo, true) != 0 || itemNo != gitemNo) continue;

						gr.CheckState = e.CheckState;
					}
				}
				finally
				{
					InActCheckStateHandler = false;
				}*/
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grd_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;
				Program.LinkHandler.HandleLink(grd.CurrentRow, e.Column.Key);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Row Movement

		#region Save/Cancel

		private void tbbCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbbSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void frmEditEstimateCharge_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.S)
					Save();
				else if (e.KeyCode == Keys.Escape)
					Close();
				else if (e.Control && e.KeyCode == Keys.U)
				{
					infDockMgr.ControlPanes[tabUscRates].Pinned = true;
					tabUscRates.GotoRates(true);
				}
				else if (e.Control && e.KeyCode == Keys.P)
				{
					infDockMgr.ControlPanes[tabUscRates].Pinned = true;
					tabUscRates.GotoP2P(true);
				}
				else if (e.Control && e.KeyCode == Keys.M)
				{
					infDockMgr.ControlPanes[tabUscRates].Pinned = true;
					tabUscRates.GotoMileage(true);
				}
				else if (e.Control && e.KeyCode == Keys.O)
				{
					infDockMgr.ControlPanes[tabUscRates].Pinned = true;
					tabUscRates.GotoAssessorial(true);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void FillCharge(ClsEstimateCharge chg)
		{
			try
			{
				chg.Estimate_ID = OriginalCharge.Estimate_ID;
				chg.Estimate_Charge_ID = OriginalCharge.Estimate_Charge_ID;
				chg.Finance_Cd = OriginalCharge.Finance_Cd;

				chg.Charge_Type_Cd = cmbCharge.SelectedChargeTypeCD;

				chg.Level_Unit_ID = cmbBasis.SelectedLevelUnitID;
				chg.Level_Count = ClsConvert.ToInt64Nullable(numLevelCount.Value);
				chg.Rate_Amt = ClsConvert.ToDecimalNullable(numRate.Value);
				chg.Unit_Qty = ClsConvert.ToDecimalNullable(numUnits.Value);
				chg.Total_Amt = ClsConvert.ToDecimalNullable(numTotal.Value);
				chg.Tcn_Count = ClsConvert.ToInt32Nullable(numTcnCount.Value);
				chg.Pcs_Per_Conveyance = ClsConvert.ToInt64Nullable(numPcsPerCnvy.Value);

				if (chg.Finance.IsAP)
					chg.Vendor_Cd = cmbVendor.SelectedVendorCD;
				else
					chg.Customer_Cd = cmbCustomer.SelectedCustomerCD;

				string memo = rtfChargeMemo.Text.Trim();
				chg.Memo = (string.IsNullOrEmpty(memo) ||
					string.Compare(memo, ChargeMemoNullText, true) == 0) ? null : memo;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void Save()
		{
			try
			{
				ValidateChildren(ValidationConstraints.None);
				if (cmbBasis.NotInList)
					return;

				if (UseExactTcnAmount)
					UpdateActivityAmts();
				else
					ComputeTotal();

				ClsEstimateCharge chg = new ClsEstimateCharge();
				FillCharge(chg);

				bool ok = (chg.Estimate_Charge_ID == null)
					? chg.ValidateInsert() : chg.ValidateUpdate();
				if (!ok)
				{
					Program.ShowError(chg.Error);
					return;
				}

				if (chg.Level_Unit != null)
				{
					if (chg.Level_Unit.Level.IsTCN && chg.Level_Count != chg.Tcn_Count)
					{
						Program.ShowError("TCNs selected ({0}) does not match the TCN count in charge section {1}",
							chg.Tcn_Count, chg.Level_Count);
						return;
					}


					if (chg.Level_Unit.Level.IsPCFN)
					{
						int? pcfnCount = ClsConvert.ToInt32Nullable(numPcfnCount.Value);
						if (chg.Level_Count != pcfnCount)
						{
							Program.ShowError("PCFNs selected ({0}) does not match the PCFN count in charge section {1}",
								pcfnCount, chg.Level_Count);
							//Just display as warning now since mulitple PCFNs can appear in customer ref field
							//return;
						}
					}
				}

				if (chg.Tcn_Count <= 0)
				{
					if (!Display.Ask("Confirm", "No TCNs selected. Save anyway?")) return;
				}

				if (chg.Total_Amt <= 0)
				{
					if (!Display.Ask("Confirm", "Total Amount is zero. Save anyway?")) return;
				}

				if (!CheckDims(chg)) return;

				DataTable dt = dtChargeActivities;
				if (!chg.SaveChanges(dt))
				{
					Program.ShowError(chg.Error);
					return;
				}

				if (chg.HasWarnings)
					Program.Show("The save produced the following warnings\r\n{0}", chg.Warning);

				IsChargeSaved = true;
				ViewWindowManager.Refresh(chg.Estimate);
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool CheckDims(ClsEstimateCharge chg)
		{
			try
			{
				if (UseExactTcnAmount) return true;

				string colName = chg.Level_Unit.CargoAttributeColName;
				if (string.IsNullOrEmpty(colName)) return true;

				decimal units = chg.Unit_Qty.GetValueOrDefault(0);
				if (units <= 0 || dtChargeActivities == null || dtChargeActivities.Rows.Count <= 0)
					return true;

				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dtChargeActivities.Rows)
				{
					decimal? qty = ClsConvert.ToDecimalNullable(dr[colName]);
					if (qty.GetValueOrDefault(0) <= 0) continue;

					decimal diff = Math.Abs(units - qty.Value);
					if (diff < 1) continue;

					sb.AppendFormat("{0} {1}, {2} {3}\r\n", dr["Cargo_Dsc"], dr["Serial_No"],
						chg.Level_Unit.Unit_Type.Grid_Column_Dsc, dr[colName]);
				}

				if (sb.Length <= 0) return true;

				sb.Insert(0, string.Format(
					"Cargo below does not match the value ({0}) specified for {1}. Continue with save?\r\n\r\n",
					units, chg.Level_Unit.Unit_Qty_Dsc));
				return Display.Ask("Confirm", sb.ToString());
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion		// #region Save/Cancel

		#region Numeric Edit Box Menu/Infragistics Calculator

		private void cnuNumericMenu_Opened(object sender, EventArgs e)
		{
			try
			{
				cnuNumericMenu.SourceControl.Focus();
				ActiveControl = cnuNumericMenu.SourceControl;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuNumericMenuEditCommands_Click(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem mnuItem = sender as ToolStripMenuItem;
				if (mnuItem == null) return;

				ucNumericEditBox num = cnuNumericMenu.SourceControl as ucNumericEditBox;
				if (num == null)
				{
					NumericEdit editbox = cnuNumericMenu.SourceControl as NumericEdit;
					if (editbox == null) return;
					num = editbox.Tag as ucNumericEditBox;
					if (num == null) return;
				}

				string command = mnuItem.Tag as string;
				switch (command)
				{
					case "Undo": num.Undo(); break;
					case "Cut": num.Cut(); break;
					case "Copy": num.Copy(); break;
					case "Paste": num.Paste(); break;
					case "Delete": num.Value = null; break;
					case "SelectAll": num.SelectAll(); break;
					default: break;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuNumericMenuCalculator_Click(object sender, EventArgs e)
		{
			try
			{
				ucNumericEditBox num = cnuNumericMenu.SourceControl as ucNumericEditBox;
				if (num == null)
				{
					NumericEdit editbox = cnuNumericMenu.SourceControl as NumericEdit;
					if (editbox == null) return;
					num = editbox.Tag as ucNumericEditBox;
					if (num == null) return;
				}

				infPopupContainer.Show(num, MousePosition);
				infPopupContainer.PopupControl.Focus();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void infCalculator_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				ucNumericEditBox num = infPopupContainer.SourceControl as ucNumericEditBox;
				if (num != null)
				{
					num.Value = infCalculator.DisplayValue;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				try
				{
					infPopupContainer.Close();
				}
				catch (Exception exf)
				{
					Program.ShowError(exf);
				}
			}
		}
		#endregion		// #region Numeric Edit Box Menu/Infragistics Calculator

		#region USC Rate Tab

		private void tabUscRates_RowCopied(object sender, EventArgs e)
		{
			try
			{
				if (tabUscRates.Row == null) return;

				numRate.Value = tabUscRates.Rate;
				if (tabUscRates.Level_Unit_ID != null)
					cmbBasis.Value = tabUscRates.Level_Unit_ID;
				//infDockMgr.ControlPanes[tabUscRates].Pinned = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region USC Rate Tab
	}

	public enum ChargeCategory
	{
		All,
		LineHaul,
		Assessorial
	}
}