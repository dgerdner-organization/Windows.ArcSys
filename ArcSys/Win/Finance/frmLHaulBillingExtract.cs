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

namespace CS2010.ArcSys.Win
{
	public partial class frmLHaulBillingExgtract : frmChildBase, ISearchWindow
	{
		#region Fields
		string VoyageNo
		{
			get
			{
				string a = txtVoyageNo.Text;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string PCFN
		{
			get 
			{ 
				string a = txtPCFN.Text;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string SerialNo
		{
			get 
			{ 
				string a = txtSerialNo.Text;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string POL
		{
			get 
			{
				string a = cmbPOL.SelectedLocationCD;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string POD
		{
			get
			{
				string a = cmbPOD.SelectedLocationCD;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string Origin
		{
			get
			{
				string a = cmbOrigin.SelectedLocationCD;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string Destination
		{
			get
			{
				string a = cmbDestination.SelectedLocationCD;
				if (string.IsNullOrEmpty(a)) return "%";
				return a;
			}
		}
		string IncludeAP
		{
			get
			{
				if (cbxAP.Checked)
					return "Y";
				return "N";
			}
		}
		string IncludeAR
		{
			get
			{
				if (cbxAR.Checked)
					return "Y";
				return "N";
			}
		}
		private DataTable dtExtract;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmLHaulBillingExgtract()
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
				//if (showOptions == true) SearchParameters();
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

		private void frmSearchContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
				grdResults.Tables[0].Columns.Clear();
				dtExtract = ClsEstimateChargeDtl.GetLHaulBillingExtract("X", "X", "X", "X", "X", "X", "X", "X","X");
				grdResults.Tables[0].Columns.Clear();
				foreach (DataColumn col in dtExtract.Columns)
				{
					string cName = col.ColumnName;
					grdResults.Tables[0].Columns.Add(cName);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void SearchParameters()
		{
			try
			{

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
				if (Program.MainWindow != null)
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
				DataTable dt = ClsEstimateChargeDtl.GetLHaulBillingExtract(VoyageNo, PCFN, SerialNo, POL, POD, Origin, Destination, IncludeAP, IncludeAR);

				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dtExtract = dt;

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

				lock (grdResults)
				{
					DataTable dt = dtExtract;
					grdResults.DataSource = dtExtract;

					grdResults.RootTable.FilterCondition = null;

					grdResults.Focus();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				if (Program.MainWindow != null)	
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
				if (Program.MainWindow != null)	
					Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdResults)
				{
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdResults.Enabled = state;
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


		private void grdResults_DoubleClick(object sender, EventArgs e)
		{

		}

		private void grdResults_KeyDown(object sender, KeyEventArgs e)
		{

		}


		private void grdResults_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmSearchContractMod_FormClosing(object sender, FormClosingEventArgs e)
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

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			cmbPOL.SelectedIndex = cmbPOD.SelectedIndex = cmbDestination.SelectedIndex = cmbOrigin.SelectedIndex = -1;
			txtPCFN.Text = txtVoyageNo.Text = txtSerialNo.Text = "";
		}
		#endregion		// #region Form Event Handlers

		#region Initiate Datagrid
		private void InitGrid()
		{
			grdResults.Tables[0].Columns.Clear();
			foreach (DataColumn col in dtExtract.Columns)
			{
				string cName = col.ColumnName;
				grdResults.Tables[0].Columns.Add(cName);
			}
		}
		#endregion
	}
}