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
	public partial class frmEditVendor : Form
	{
		#region Static Fields

		/// <summary>Used by the static ShowMaintenance method to ensure that no more than
		/// one frmEditVendor window is visible at any given time</summary>
		private static frmEditVendor MaintenanceWindow;

		#endregion		// #region Static Fields

		#region Fields

		private DialogMode CurrentMode;

		public ClsVendor theItem;

		#endregion		// #region Fields

		#region Constructors/Initialization/Cleanup

		public frmEditVendor()
		{
			InitializeComponent();

			theItem = new ClsVendor();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmEditVendor window is visible at any given time</summary>
		public static frmEditVendor ShowMaintenance()
		{
			try
			{
				if( MaintenanceWindow == null )
				{
					MaintenanceWindow = new frmEditVendor();
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
			{	// At some point update to include all addres fields, Addr3, country, ext, etc.
				BindHelper.Bind(txtCode, theItem, "Vendor_Cd");
				BindHelper.Bind(txtDesc, theItem, "Vendor_Nm");
				BindHelper.Bind(chkActive, theItem, "Active_Flg");
				BindHelper.Bind(chkCONUS, theItem, "Conus_Flg");

				BindHelper.Bind(txtAddr1, theItem, "Addr1");
				BindHelper.Bind(txtAddr2, theItem, "Addr2");
				BindHelper.Bind(txtAddr3, theItem, "Addr3");
				BindHelper.Bind(cmbCity, theItem, "City");
				BindHelper.Bind(txtState, theItem, "State_Prov_Cd");
				BindHelper.Bind(txtPostalCd, theItem, "Postal_Cd");
				BindHelper.Bind(cmbCountry, theItem, "Country_Cd");
				BindHelper.Bind(txtContactNm, theItem, "Contact_Nm");
				BindHelper.Bind(txtPhone1, theItem, "Phone");
				BindHelper.Bind(txtPhone1Ext, theItem, "Phone_Ext");
				BindHelper.Bind(txtFax, theItem, "Fax");
				BindHelper.Bind(txtEmail, theItem, "Email");

				txtCode.MaxLength = ClsVendor.Vendor_CdMax;
				txtDesc.MaxLength = ClsVendor.Vendor_NmMax;
				txtAddr1.MaxLength = ClsVendor.Addr1Max;
				txtAddr2.MaxLength = ClsVendor.Addr2Max;
				txtAddr3.MaxLength = ClsVendor.Addr3Max;
				cmbCity.MaxLength = ClsVendor.CityMax;
				txtState.MaxLength = ClsVendor.State_Prov_CdMax;
				txtPostalCd.MaxLength = ClsVendor.Postal_CdMax;
				cmbCountry.MaxLength = ClsVendor.Country_CdMax;
				txtContactNm.MaxLength = ClsVendor.Contact_NmMax;
				txtPhone1.MaxLength = ClsVendor.PhoneMax;
				txtPhone1Ext.MaxLength = ClsVendor.Phone_ExtMax;
				txtFax.MaxLength = ClsVendor.FaxMax;
				txtEmail.MaxLength = ClsVendor.EmailMax;

				SetFormState(DialogMode.View);

				DataTable dt = ClsVendor.GetAll();
				dt.DefaultView.Sort = "Vendor_Cd asc";
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

				txtDesc.ReadOnly = cmbGeoRegion.ReadOnly = !edit;
				pnlEditBot.Enabled = chkActive.Enabled = edit;

				txtCode.ReadOnly = (newMode != DialogMode.Add);

				if (edit)
					splEdit.ExpandSplitter();
				else
					splEdit.CollapseSplitter();

				grdResults.EnsureVisible();

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
					DataRow[] rows = dt.Select(string.Format("Vendor_Cd = '{0}'", codeValue));
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

				ClsVendor item = grdResults.GetCurrentItem<ClsVendor>();
				if (item != null)
				{
					theItem.CopyFrom(item);
					string rgnCSV = item.GetAllowedRegions(false);
					cmbGeoRegion.Text = rgnCSV;
				}
				else
				{
					theItem.ResetColumns();
					cmbGeoRegion.Values = null;
					cmbGeoRegion.Text = null;
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

				string codeValue = theItem.Vendor_Cd;
				ClsConnection cn = ClsConMgr.Manager["ArcSys"];
				try
				{
					cn.TransactionBegin();
					if (CurrentMode == DialogMode.Add)
					{
						if (!theItem.ValidateInsert()) return;
						theItem.Insert();
					}
					else if (CurrentMode == DialogMode.Edit)
					{
						if (!theItem.ValidateUpdate()) return;
						theItem.Update();
					}

					if (!theItem.UpdateRegions(cmbGeoRegion.CheckedGeoRegionCDs))
					{
						cn.TransactionRollback();
						Program.ShowError(theItem.Error);
						return;
					}

					cn.TransactionCommit();
				}
				catch( Exception ex )
				{
					cn.TransactionRollback();
					Program.ShowError(ex);
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
				if (theItem == null || string.IsNullOrEmpty(theItem.Vendor_Cd))
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

		private void splEdit_SplitterCollapseChanged(object sender, EventArgs e)
		{
			try
			{
				int spaceNeeded = (splEdit.IsCollapsed) ? 95 : 430;
				int spld = pnlMain.Height - spaceNeeded;
				if (spld < 85) spld = 85;
				pnlMain.SplitterDistance = spld;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Event Handlers
	}
}