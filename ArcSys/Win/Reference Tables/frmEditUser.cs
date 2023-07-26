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
	public partial class frmEditUser : Form
	{
		#region Static Fields

		/// <summary>Used by the static ShowMaintenance method to ensure that no more than
		/// one frmEditUser window is visible at any given time</summary>
		private static frmEditUser MaintenanceWindow;

		#endregion		// #region Static Fields

		#region Fields

		private DialogMode CurrentMode;

		public ClsUser theItem;

		#endregion		// #region Fields

		#region Constructors/Initialization/Cleanup

		public frmEditUser()
		{
			InitializeComponent();

			theItem = new ClsUser();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmEditUser window is visible at any given time</summary>
		public static frmEditUser ShowMaintenance()
		{
			try
			{
				if( MaintenanceWindow == null )
				{
					MaintenanceWindow = new frmEditUser();
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
				BindHelper.Bind(txtCode, theItem, "User_Login");
				BindHelper.Bind(txtFirstNm, theItem, "First_Nm");
				BindHelper.Bind(txtLastNm, theItem, "Last_Nm");
				BindHelper.Bind(chkActive, theItem, "Active_Flg");
				BindHelper.Bind(txtVendorInd, theItem, "Vendor_Ind");
				BindHelper.Bind(txtEmail, theItem, "Email");

				txtCode.MaxLength = ClsUser.User_LoginMax;
				txtFirstNm.MaxLength = ClsUser.First_NmMax;
				txtLastNm.MaxLength = ClsUser.Last_NmMax;
				txtEmail.MaxLength = ClsUser.EmailMax;
				txtVendorInd.MaxLength = ClsUser.Vendor_IndMax;

				SetFormState(DialogMode.View);

				DataTable dt = ClsUser.GetAll();
				dt.DefaultView.Sort = "User_Login asc";
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

				txtFirstNm.ReadOnly = !edit;
				txtFirstNm.Enabled = txtLastNm.Enabled = txtEmail.Enabled =
					txtVendorInd.Enabled = chkActive.Enabled = edit;

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
					DataRow[] rows = dt.Select(string.Format("User_Login = '{0}'", codeValue));
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

				ClsUser item = grdResults.GetCurrentItem<ClsUser>();
				if (item != null)
					theItem.CopyFrom(item);
				else
					theItem.ResetColumns();
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

				string codeValue = theItem.User_Login;
				if( CurrentMode == DialogMode.Add )
				{
					if (!theItem.ValidateInsert()) return;
					theItem.AddUser();
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

		protected void Delete()
		{
			try
			{
				if (string.Compare(ClsEnvironment.UserName, theItem.User_Login, true) == 0)
				{
					Program.ShowError("Cannot delete current user");
					return;
				}

				if( Display.Ask("Confirm Delete",
					"Are you sure you want to DELETE the selected item?\r\n{0}",
					theItem.ToString()))
				{
					if (!theItem.ValidateDelete()) return;
					theItem.DropUser();
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
				if (theItem == null || string.IsNullOrEmpty(theItem.User_Login))
				{
					Program.ShowError("Item no longer exists, please refresh the list");
					return;
				}

				SetFormState(DialogMode.Edit);

				txtFirstNm.Focus();
				ActiveControl = txtFirstNm;
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
				int spaceNeeded = (splEdit.IsCollapsed) ? 120 : 175;
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