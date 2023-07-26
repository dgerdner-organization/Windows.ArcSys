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
	public partial class frmShowUscRates : frmChildBase
	{
		#region Static Fields

		/// <summary>Used by the static ShowMaintenance method to ensure that no more than
		/// one this type of window is visible at any given time</summary>
		private static frmShowUscRates MaintenanceWindow;

		#endregion		// #region Static Fields

		#region Constructors/Initialization/Cleanup

		public frmShowUscRates() : base(Program.MainWindow, true)
		{
			InitializeComponent();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// of this type of window is visible at any given time</summary>
		public static frmShowUscRates ShowMaintenance()
		{
			try
			{
				if( MaintenanceWindow == null )
				{
					MaintenanceWindow = new frmShowUscRates();
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

		private void MaintenanceWindow_Load(object sender, EventArgs e)
		{
			try
			{
				FormLoad();

				bool showToolbar = false;
				if (ClsEnvironment.IsDeveloper ||
					string.Compare(ClsEnvironment.UserName, "ASWENSON", true) == 0)
					showToolbar = true;

				tbrMain.Visible = showToolbar;
				tabUscRates.AllowEdit =
					(showToolbar) ? InheritableBoolean.True : InheritableBoolean.False;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void FormLoad()
		{
			try
			{
				tabUscRates.LoadRates();
				tbbChangesOnly.Checked = false;
				tabUscRates.Grid.Focus();
				ActiveControl = tabUscRates.Grid;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RefreshAll()
		{
			try
			{
				if (tabUscRates.CanEdit && tabUscRates.HasChanges)
				{
					if (!Display.Ask("Confirm",
						"Changes have not been saved. If you continue with the refresh operation,\r\n" +
						"all changes will be lost. Continue with refresh and lose all changes?")) return;
				}
				FormLoad();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Cleanup

		#region Helper Methods

		protected void Save()
		{
			try
			{
				if (!tabUscRates.CanEdit) return;

				ValidateChildren(ValidationConstraints.None);

				if (!tabUscRates.HasChanges)
				{
					Program.ShowError("Nothing to save, rates were not modified");
					return;
				}

				string info = tabUscRates.GetProposedChanges();
				if (!string.IsNullOrWhiteSpace(info))
				{
					using (frmMemo f = new frmMemo())
					{
						f.ViewTextFull("Review Pending Changes", info, "Close");
					}
				}

				if (!Display.Ask("Confirm", "Continue with save operation?")) return;

				string errMsg = null, infoMsg = null;
				if (!tabUscRates.SaveChanges(out errMsg, out infoMsg))
				{
					Program.ShowError(errMsg);
					return;
				}

				using (frmMemo f = new frmMemo())
				{
					f.ViewTextFull("Changes", infoMsg, "Close");
				}
				FormLoad();	// Should we Close() or just reload? just reload for now
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void MaintenanceWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (tabUscRates.CanEdit && tabUscRates.HasChanges)
				{
					e.Cancel = !Display.Ask("Confirm",
						"Changes have not been saved. Close window and lose changes?");
				}
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
					RefreshAll();
				}
				else if (e.KeyCode == Keys.N && e.Control)
				{
					GotoAddRow();
				}
				else if (e.KeyCode == Keys.S && e.Control)
				{
					Save();
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbRefresh_Click(object sender, EventArgs e)
		{
			RefreshAll();
		}

		private void tbbRefreshMods_Click(object sender, EventArgs e)
		{
			tabUscRates.RefreshMods();
		}

		private void tbbNew_Click(object sender, EventArgs e)
		{
			GotoAddRow();
		}

		private void GotoAddRow()
		{
			try
			{
				if( tabUscRates.CanEdit )
					tabUscRates.GotoAddRow();
			}
			catch (Exception ex)
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}

		private void tbbSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void tbbChangesOnly_Click(object sender, EventArgs e)
		{
			try
			{
				if( tabUscRates.CanEdit )
					tabUscRates.ShowChangesOnly(tbbChangesOnly.Checked);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbExit_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion		// #region Event Handlers
	}
}