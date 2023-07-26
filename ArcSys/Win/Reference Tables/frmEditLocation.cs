using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditLocation : Form
	{
		#region Static Fields

		/// <summary>Used by the static ShowMaintenance method to ensure that no more than
		/// one frmEditLocation window is visible at any given time</summary>
		private static frmEditLocation MaintenanceWindow;

		#endregion		// #region Static Fields

		#region Fields

		private DialogMode CurrentMode;

		public ClsLocation theItem;
		protected CS2010.ACMS.Business.ClsLocation theACMSItem;

		#endregion		// #region Fields

		#region Constructors/Initialization/Cleanup

		public frmEditLocation()
		{
			InitializeComponent();

			theItem = new ClsLocation();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmEditLocation window is visible at any given time</summary>
		public static frmEditLocation ShowMaintenance()
		{
			try
			{
				if( MaintenanceWindow == null )
				{
					MaintenanceWindow = new frmEditLocation();
					int offW = (Program.MainWindow.Width - MaintenanceWindow.Width) / 2;
					int offH = (Program.MainWindow.Height - MaintenanceWindow.Height) / 2;
					MaintenanceWindow.Left = Program.MainWindow.Left + offW;
					MaintenanceWindow.Top = Program.MainWindow.Top + offH;
				}

				MaintenanceWindow.Show();
				MaintenanceWindow.Activate();

				return MaintenanceWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		protected void FormLoad(string codeValue)
		{
			try
			{
				BindHelper.Bind(txtCode, theItem, "Location_Cd");
				BindHelper.Bind(txtDesc, theItem, "Location_Dsc");
				BindHelper.Bind(cmbLocationType, theItem, "Location_Type_Cd");
				BindHelper.Bind(cmbGeoRegion, theItem, "Geo_Region_Cd");
				BindHelper.Bind(chkActive, theItem, "Active_Flg");
				BindHelper.Bind(chkConus, theItem, "Conus_Flg");
				BindHelper.Bind(chkGate, theItem, "Gate_Flg");
				BindHelper.Bind(chkBorder, theItem, "Border_Flg");
				BindHelper.Bind(chkHoldArea, theItem, "Hold_Area_Flg");
				BindHelper.Bind(chkCheckpoint, theItem, "Checkpoint_Flg");

				txtCode.MaxLength = ClsLocation.Location_CdMax;
				txtDesc.MaxLength = ClsLocation.Location_DscMax;

				SetFormState(DialogMode.View);

				DataTable dt = ClsLocation.GetAllLocations();
				dt.DefaultView.Sort = "Location_Cd asc";
				grdResults.DataSource = dt;

				LoadItem(codeValue);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Cleanup

		#region Helper Methods

		protected void SetFormState(DialogMode newMode)
		{
			try
			{
				CurrentMode = newMode;

				bool edit = (newMode != DialogMode.View);

				tbbSave.Enabled = tbbCancel.Enabled = edit;
				tbbRefresh.Enabled = tbbNew.Enabled = tbbEdit.Enabled = tbbDelete.Enabled =
					tbbExit.Enabled = grdResults.Enabled = !edit;

				txtDesc.ReadOnly = !edit;
				cmbLocationType.Enabled = cmbGeoRegion.Enabled = chkConus.Enabled =
					chkActive.Enabled = chkGate.Enabled = chkBorder.Enabled =
					chkHoldArea.Enabled =  chkCheckpoint.Enabled = btnLineLookupDsc.Enabled = edit;
				pnlEditArea.Panel2Collapsed = true;
				pnlMain.SplitterDistance = pnlMain.Height - 140;
				pnlMain.FixedPanel = FixedPanel.Panel2;

				txtCode.ReadOnly = (newMode != DialogMode.Add);

				Color bk = (edit) ? SystemColors.ControlLight : SystemColors.Window;
				grdResults.BackColor = bk;
				grdResults.RowFormatStyle.BackColor = bk;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void LoadItem(string codeValue)
		{
			try
			{
				if( !string.IsNullOrEmpty(codeValue) )
				{	// If codeValue is not null attempt to select that row
					DataTable dt = grdResults.DataSource as DataTable;
					DataRow[] rows = dt.Select(string.Format("Location_Cd = '{0}'", codeValue));
					DataRow theRow = (rows != null && rows.Length > 0) ? rows[0] : null;
					GridEXRow gr = (theRow != null) ? grdResults.GetRow(theRow) : null;
					if( gr != null )
					{
						grdResults.SelectedItems.Clear();
						grdResults.SelectedItems.Add(gr.Position);
						grdResults.EnsureVisible(gr.Position);
						grdResults.Row = gr.Position;
					}
				}

				ClsLocation item = grdResults.GetCurrentItem<ClsLocation>();
				if (item != null)
					theItem.CopyFrom(item);
				else
					theItem.ResetColumns();

				// Get ACMS location
				theACMSItem = CS2010.ACMS.Business.ClsLocation.GetUsingKey(theItem.Location_Cd);
				if (theACMSItem != null)
				{
					BindHelper.Bind(txtCensusCd, theACMSItem, "Census_Cd");
					BindHelper.Bind(txtCity, theACMSItem, "City");
					BindHelper.Bind(txtState, theACMSItem, "State_Cd");
					BindHelper.Bind(txtMilStamp, theACMSItem, "Other1_Cd");
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		protected void Save()
		{
			try
			{
				ValidateChildren(ValidationConstraints.None);

				string codeValue = theItem.Location_Cd;
				if( CurrentMode == DialogMode.Add )
				{
					if (!theItem.ValidateInsert()) return;
					theItem.Insert();
				}
				else if( CurrentMode == DialogMode.Edit )
				{
					if (!theItem.ValidateUpdate()) return;
					theItem.Update();
				}

				FormLoad(codeValue);

				grdResults.Focus();
				ActiveControl = grdResults;
			}
			catch( Exception ex )
			{
				theItem["Exception"] = ex.Message;
			}
			finally
			{
				if( theItem.HasErrors ) Program.ShowError(theItem.Error);
			}
		}

		protected void SynchACMS()
		{
			CS2010.ACMS.Business.ClsLocation loc = CS2010.ACMS.Business.ClsLocation.GetUsingKey(theItem.Location_Cd);
			if (loc == null)
			{
				loc.Location_Cd = theItem.Location_Cd;
				loc.Delete_Fl = "N";
				loc.Location_Dsc = theItem.Location_Dsc;
				loc.Insert();
			}
			loc.Location_Dsc = theItem.Location_Dsc;
			loc.Other1_Cd = "";
			loc.Other2_Cd = "";
			if (theItem.Geo_Region_Cd.StartsWith("US"))
				loc.Census_Type = "D";
			else
				loc.Census_Type = "K";
			loc.City = "";
			loc.State_Cd = "";
			loc.Country_Cd = "";
		}
		protected void Delete()
		{
			try
			{
				if( Display.Ask("Confirm Delete",
					"Are you sure you want to DELETE the selected item?\r\n{0}",
					theItem.ToString()))
				{
					if (!theItem.ValidateDelete()) return;
					theItem.Delete();
				}
				FormLoad(null);

				grdResults.Focus();
				ActiveControl = grdResults;
			}
			catch( Exception ex )
			{
				theItem["Exception"] = ex.Message;
			}
			finally
			{
				if (theItem.HasErrors) Program.ShowError(theItem.Error);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void MaintenanceWindow_Load(object sender, EventArgs e)
		{
			FormLoad(null);
		}

		private void MaintenanceWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if( CurrentMode == DialogMode.View ) return;

				e.Cancel = !Display.Ask("Confirm",
					"Changes will be lost. Close anyway?\r\n{0}", theItem);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void MaintenanceWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			MaintenanceWindow = null;
		}

		private void MaintenanceWindow_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.F5 )
				{
					if( tbbRefresh.Enabled ) tbbRefresh.PerformClick();
				}
				else if( e.KeyCode == Keys.Escape )
				{
					if( tbbCancel.Enabled )
						tbbCancel.PerformClick();
					else
						tbbExit.PerformClick();
				}
				else if (e.KeyCode == Keys.Enter)
				{
					if (tbbEdit.Enabled && grdResults.ContainsFocus)
						tbbEdit.PerformClick();
				}
				else if (e.KeyCode == Keys.D && e.Control)
				{
					if (tbbDelete.Enabled)
						tbbDelete.PerformClick();
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			LoadItem(null);
		}

		private void tbbRefresh_Click(object sender, EventArgs e)
		{
			FormLoad(null);
		}

		private void tbbNew_Click(object sender, EventArgs e)
		{
			try
			{
				theItem.SetDefaults();

				SetFormState(DialogMode.Add);

				txtCode.Focus();
				ActiveControl = txtCode;
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}

		private void tbbEdit_Click(object sender, EventArgs e)
		{
			try
			{
				if (grdResults.RecordCount <= 0) return;

				LoadItem(null);
				if (theItem == null || string.IsNullOrEmpty(theItem.Location_Cd))
				{
					Program.ShowError("Item no longer exists, please refresh the list");
					return;
				}

				SetFormState(DialogMode.Edit);

				txtDesc.Focus();
				ActiveControl = txtDesc;
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}

		private void grdResults_DoubleClick(object sender, EventArgs e)
		{
			tbbEdit.PerformClick();
		}

		private void btnLineLookup_Click(object sender, EventArgs e)
		{
			try
			{
				string cd = null, dsc = null;
				if (sender == btnLineLookupCd)
					cd = txtCode.Text.Trim();
				else if (sender == btnLineLookupDsc)
					dsc = txtDesc.Text.Trim();
				else
					return;

				if (pnlEditArea.Panel2Collapsed)
				{
					pnlEditArea.Panel2Collapsed = false;

					int mainSplitLoc = pnlMain.Height - 215;
					if (mainSplitLoc < 15) mainSplitLoc = 15;
					if (pnlMain.SplitterDistance > mainSplitLoc)
						pnlMain.SplitterDistance = mainSplitLoc;

					pnlEditArea.SplitterDistance = 140;
					pnlMain.FixedPanel = FixedPanel.None;
				}
				grdLineLocs.DataSource = ClsLocation.SearchLineLocations(cd, dsc);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdLineLocs_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdLineLocs.HitTest();
				if( ga != GridArea.Cell ) return;

				object o = grdLineLocs.GetValue(grdLineLocs.CurrentColumn);
				string val = ClsConvert.ToString(o);

				if (string.IsNullOrWhiteSpace(val)) return;

				if (string.Compare(grdLineLocs.CurrentColumn.Key, "Location_Cd", true) == 0)
				{
					if (txtCode.ReadOnly) return;

					txtCode.Text = val;
				}
				else if (string.Compare(grdLineLocs.CurrentColumn.Key, "Location_Dsc", true) == 0)
				{
					txtDesc.Text = val;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void tbbCancel_Click(object sender, EventArgs e)
		{
			try
			{
				LoadItem(null);
				SetFormState(DialogMode.View);

				grdResults.Focus();
				ActiveControl = grdResults;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbbSave_Click(object sender, EventArgs e)
		{
			Save();
		}
		#endregion		// #region Event Handlers
	}
}