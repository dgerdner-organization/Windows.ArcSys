using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using CS2010.AVSS.Win;
using ASL.ARC.EDITools;

using STENA;
using CS2010.AVSS.Business;
using System.ComponentModel;

namespace CS2010.ArcSys.Win
{
	public partial class frmMain : Form, IMdiParent
	{
		#region Properties

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				/*base.Text = "BETA " + value;
				infFormMgr.FormStyleSettings.Caption =
					"<span style=\"color:Red; font-weight:bold; font-size:14pt;\">BETA</span>" +
					"<span style=\"font-size:10pt; vertical-align: middle;\"> - " +
					value + " - </span>" +
					"<span style=\"color:Red; font-weight:bold; font-size:14pt;\">BETA</span>";*/
				base.Text = value;
				infFormMgr.FormStyleSettings.Caption =
					"<span style=\"font-size:10pt; vertical-align: middle;\">" +
					value + "</span>";
				infFormMgr.FormStyleSettings.CaptionInactive = infFormMgr.FormStyleSettings.Caption;
			}
		}

		#endregion		// #region Properties

		#region Constructors/Initialization/Cleanup

		public frmMain()
		{
			InitializeComponent();
			CreateResolutionMenu();
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			// If logged-into ACMS Test environment, turn everything else off
            //if (Program.IsACMSTest)
            //{
            //    mnuIntermodal.Visible = mnuCommEDIAdmin.Visible = mnuFinance.Visible = mnuVesselPlanning.Visible =
            //        mnuReports.Visible = mnuAdmin.Visible = false;
            //}

			try
			{
				infTabMgr.Enabled = ClsArcSysConfig.UseTabbedMDI;
				mnuWindowTileH.Visible = mnuWindowTileV.Visible = mnuWindowCascade.Visible =
					mnuWindowArranceIcons.Visible = !infTabMgr.Enabled;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

			try
			{
				mnuTableMaintenanceBasis.Visible = mnuTableMaintenanceLevels.Visible =
					mnuTableMaintenanceUnitType.Visible = mnuTableMaintenanceN2.Visible =
					mnuTableMaintenanceLocationTypes.Visible =
					mnuTableMaintenanceVessels.Visible = mnuUnassignedCargo.Visible =
					mnuLineCharges.Visible =
					 ClsEnvironment.IsDeveloper;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void SetMainMenuStatus(bool enabled)
		{
			try
			{
				if (mnuMain != null)
					mnuMain.Enabled = enabled;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{

		}
		#endregion		// #region Constructors/Initialization/Cleanup

		#region File Menu Actions

		private void mnuLINEQuery_Click(object sender, EventArgs e)
		{
			frmLINEQuery frm = new frmLINEQuery();
			frm.MdiParent = this;
			frm.Show();
		}
		private void mnuTestVoyages_Click(object sender, EventArgs e)
		{
			frmTestVoyages frm = new frmTestVoyages();
			frm.MdiParent = this;
			frm.Show();
		}
		private void mnuLINEWarehouseQuery_Click(object sender, EventArgs e)
		{
			frmLINEWarehouseQuery frm = new frmLINEWarehouseQuery(false);
			frm.MdiParent = this;
			frm.Show();
		}

		#endregion		// #region File Menu Actions

		#region Window/Help Menu/Toolbar Actions

		private void mnuWindowCascade_Click(object sender, EventArgs e)
		{
			WindowLayout(MdiLayout.Cascade);
		}

		private void mnuWindowTileH_Click(object sender, EventArgs e)
		{
			WindowLayout(MdiLayout.TileHorizontal);
		}

		private void mnuWindowTileV_Click(object sender, EventArgs e)
		{
			WindowLayout(MdiLayout.TileVertical);
		}

		private void mnuWindowArranceIcons_Click(object sender, EventArgs e)
		{
			WindowLayout(MdiLayout.ArrangeIcons);
		}

		private void WindowLayout(MdiLayout val)
		{
			try
			{
				LayoutMdi(val);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuWindow_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				mnuWindowCloseAll.Visible = (MdiChildren.Length > 1);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuWindowCloseAll_Click(object sender, EventArgs e)
		{
			CloseAllWindows();
		}

		private void CloseAllWindows()
		{
			try
			{
				for (int i = MdiChildren.Length - 1; i >= 0; i--)
					MdiChildren[i].Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuHelpITrack_Click(object sender, EventArgs e)
		{
			ASL.ITrack.WinCtrls.frmIssueTracking.Search(false, true, "ARCSYS", null);
		}

		private void mnuHelpContents_Click(object sender, EventArgs e)
		{
			try
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				if (asm == null)
				{
					Program.ShowError("Unable to find help file");
					return;
				}

				string path = Path.GetDirectoryName(asm.Location);
				string fileName = Path.Combine(path, ClsConfig.HelpFile);

				Process.Start(fileName);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuHelpIssueReporting_Click(object sender, EventArgs e)
		{
			try
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				if (asm == null)
				{
					Program.ShowError("Unable to find help file");
					return;
				}

				string path = Path.GetDirectoryName(asm.Location);
				string fileName = Path.Combine(path, ClsConfig.IssueReportingGuide);

				Process.Start(fileName);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuHelpAbout_Click(object sender, EventArgs e)
		{
			try
			{
				using (frmAbout frm = new frmAbout())
				{
					frm.DisplayAbout(Assembly.GetExecutingAssembly(), "Arc Systems",
						ClsConfig.Title);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Window/Help Menu/Toolbar Actions

		#region CARGO SEARCH

		private void mnuSearchCargo_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmCargoSearch>(true);
		}

		private void mnuCargoCreateEstimate_Click(object sender, EventArgs e)
		{
			frmCreateEstimate.Search(true, true);
		}

		private void mnuCargoSearchEstimate_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchEstimate>(true);
		}

		private void mnuCargoSearchAccruals_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchAccruals>(true);
		}

		private void mnuSearchMods_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchContractMod>(true);
		}
		#endregion

		#region Import from LINE

		frmImportFromLINE _frmImportFromLINE;

		protected void ShowImportLINE()
		{
			try
			{
				if (_frmImportFromLINE == null) _frmImportFromLINE = new frmImportFromLINE();

				_frmImportFromLINE.FormClosed += new FormClosedEventHandler(this.CloseImportLINE);
				_frmImportFromLINE.MdiParent = this;
				_frmImportFromLINE.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseImportLINE(object sender, FormClosedEventArgs e)
		{
			_frmImportFromLINE = null;
		}
		private void importFromLINEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowImportLINE();
		}
		#endregion

		#region Import LINE Warehouse

		frmLINEImport _frmLINEImport;

		protected void ShowLINEImport()
		{
			try
			{
				if (_frmLINEImport == null) _frmLINEImport = new frmLINEImport();

				_frmLINEImport.FormClosed += new FormClosedEventHandler(this.CloseLINEImport);
				_frmLINEImport.MdiParent = this;
				_frmLINEImport.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseLINEImport(object sender, FormClosedEventArgs e)
		{
			_frmLINEImport = null;
		}

		private void mnuLINEImport_Click(object sender, EventArgs e)
		{
			ShowLINEImport();
		}
		#endregion

		#region UpdateCargoChanges

		frmImportCargoUpdates _frmImportCargoUpdates;

		protected void ShowImportCargoUpdates(bool AutoRetrieve)
		{
			try
			{
				if (_frmImportCargoUpdates == null) _frmImportCargoUpdates = new frmImportCargoUpdates();

				_frmImportCargoUpdates.FormClosed += new FormClosedEventHandler(this.CloseImportCargoUpdates);
				_frmImportCargoUpdates.MdiParent = this;
				_frmImportCargoUpdates.ShowForm(AutoRetrieve);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseImportCargoUpdates(object sender, FormClosedEventArgs e)
		{
			_frmImportCargoUpdates = null;
		}
		private void importCargoUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowImportCargoUpdates(false);
		}
		#endregion

		#region Unassigned Cargo

		frmUnassignedCargo _frmUnassignedCargo;

		protected void ShowUnassignedCargo()
		{
			try
			{
				if (_frmUnassignedCargo == null) _frmUnassignedCargo = new frmUnassignedCargo();
				_frmUnassignedCargo.FormClosed += new FormClosedEventHandler(this.CloseUnassignedCargo);
				_frmUnassignedCargo.MdiParent = this;
				_frmUnassignedCargo.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseUnassignedCargo(object sender, FormClosedEventArgs e)
		{
			_frmUnassignedCargo = null;
		}
		private void mnuUnassignedCargo_Click(object sender, EventArgs e)
		{
			ShowUnassignedCargo();
		}
		#endregion

		#region Sales Summary
		private void salesSummaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSalesSummary>(true);
		}
		#endregion

		#region Estimate Investigate
		private frmEstimateInvestigate _frmEstimateInvestigate;

		public void ViewEstimateInvestigate()
		{
			try
			{
				if (_frmEstimateInvestigate == null) _frmEstimateInvestigate = new frmEstimateInvestigate();
				_frmEstimateInvestigate.FormClosed += new FormClosedEventHandler(this.CloseEstimateInvestigate);
				_frmEstimateInvestigate.MdiParent = this;
				_frmEstimateInvestigate.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseEstimateInvestigate(object sender, FormClosedEventArgs e)
		{
			_frmEstimateInvestigate = null;
		}
		#endregion
		#region Audit Trail(s)

		private frmViewAudit _frmViewAudit;

		public void ViewChangeHistory(ClsCargo cargo)
		{
			ViewChangeHistory();
			_frmViewAudit.SearchCargo(cargo);
		}

		public void ViewChangeHistory(string sTable)
		{
			try
			{
				if (_frmViewAudit == null) _frmViewAudit = new frmViewAudit();
				_frmViewAudit.FormClosed += new FormClosedEventHandler(this.CloseAuditHistory);
				_frmViewAudit.MdiParent = this;
				_frmViewAudit.ShowForm(sTable);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void ViewChangeHistory()
		{
			try
			{
				if (_frmViewAudit == null) _frmViewAudit = new frmViewAudit();
				_frmViewAudit.FormClosed += new FormClosedEventHandler(this.CloseAuditHistory);
				_frmViewAudit.MdiParent = this;
				_frmViewAudit.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseAuditHistory(object sender, FormClosedEventArgs e)
		{
			_frmViewAudit = null;
		}
		#endregion

		#region Reports

		private void mnuReportsExceptions_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmDatabaseExceptions>(true);
		}


        frmNHTSARecall _frmNHTSARecall;
        private void NHTSARecall()
        {
            try
            {
                frmNHTSARecall _frmNHTSARecall = new frmNHTSARecall();
                _frmNHTSARecall.FormClosed +=new FormClosedEventHandler(_frmNHTSARecall_FormClosed);
                _frmNHTSARecall.MdiParent = this;
                _frmNHTSARecall.ShowOpen();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void _frmNHTSARecall_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmNHTSARecall = null;
        }

		#region Actual Vs Budget

		frmActualvsBudget _frmActualvsBudget;

		protected void ShowActualvsBudget()
		{
			try
			{
				if (_frmActualvsBudget == null) _frmActualvsBudget = new frmActualvsBudget();

				_frmActualvsBudget.FormClosed += new FormClosedEventHandler(this.CloseActualvsBudget);
				_frmActualvsBudget.MdiParent = this;
				_frmActualvsBudget.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseActualvsBudget(object sender, FormClosedEventArgs e)
		{
			_frmActualvsBudget = null;
		}

		private void tsmiActualVsBudget_Click(object sender, EventArgs e)
		{
			ShowActualvsBudget();
		}

		#endregion

        #region Lhaul Charges (for Customer Service)

        frmCustomerServiceLhaulCharges _frmCustomerServiceLhaulCharges;

        private void lhaulChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCustomerServiceLhaulCharges();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowCustomerServiceLhaulCharges()
        {
            try
            {
                if (_frmCustomerServiceLhaulCharges == null) _frmCustomerServiceLhaulCharges = new frmCustomerServiceLhaulCharges();

                _frmCustomerServiceLhaulCharges.FormClosed += new FormClosedEventHandler(this.CloseCustomerServiceLhaulCharges);
                _frmCustomerServiceLhaulCharges.MdiParent = this;
                _frmCustomerServiceLhaulCharges.ShowForm();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        
        }

        private void CloseCustomerServiceLhaulCharges(object sender, EventArgs e)
        {
            try
            {
                //_frmCustomerServiceLhaulCharges.FormClosed -= new FormClosedEventHandler(this.CloseCustomerServiceLhaulCharges);
                _frmCustomerServiceLhaulCharges = null;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }


        #endregion

        #region AVSS Military Voyages

        #endregion

        frmMilitaryVoyages _frmMilitaryVoyages;

		protected void ShowAVSSMilitaryVoyages()
		{
			try
			{
				if (_frmMilitaryVoyages == null) _frmMilitaryVoyages = new frmMilitaryVoyages();

				_frmMilitaryVoyages.FormClosed += new FormClosedEventHandler(this.CloseAVSSMilitaryVoyages);
				_frmMilitaryVoyages.MdiParent = this;
				_frmMilitaryVoyages.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseAVSSMilitaryVoyages(object sender, FormClosedEventArgs e)
		{
			_frmActualvsBudget = null;
		}


		private void mnuAVSSMilitaryVoyages_Click(object sender, EventArgs e)
		{
			ShowAVSSMilitaryVoyages();
		}



		#region Transhipment

		frmTranshipmentReport _frmTranshipmentReport;

		protected void ShowTranshipmentReport()
		{
			try 
			{
				if (_frmTranshipmentReport.IsNull()) _frmTranshipmentReport = new frmTranshipmentReport();

				_frmTranshipmentReport.FormClosed += new FormClosedEventHandler(this.CloseTranshipmentReport);
				_frmTranshipmentReport.MdiParent = this;
				_frmTranshipmentReport.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseTranshipmentReport(object sender, EventArgs e)
		{
			_frmTranshipmentReport = null;
		}

		private void tsmiTranshipment_Click(object sender, EventArgs e)
		{
			ShowTranshipmentReport();
		}

		#endregion	
		
		private void mnuReportsUSC_Click(object sender, EventArgs e)
		{
			frmShowUscRates.ShowMaintenance();
		}
		#endregion		// #region Reports

		#region Line Charges

		private void mnuLineCharges_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmLINECharges>(true);
		}

		#endregion

		#region Daily ITV

		frmDailyITV _frmDailyITV;

		protected void ShowDailyITV(bool bImport)
		{
			try
			{
				if (_frmDailyITV == null) _frmDailyITV = new frmDailyITV();
				_frmDailyITV.FormClosed += new FormClosedEventHandler(this.CloseDailyITV);
				_frmDailyITV.MdiParent = this;
				_frmDailyITV.ShowForm(bImport);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseDailyITV(object sender, FormClosedEventArgs e)
		{
			_frmDailyITV = null;
		}

		private void mnuDailyITV_Click(object sender, EventArgs e)
		{
			ShowDailyITV(true);
		}
		private void mnuDailyITVExport_Click(object sender, EventArgs e)
		{
			ShowDailyITV(false);
		}
		#endregion

		#region CreateMove
		frmEditVendorMove _frmEditVendorMove;

		protected void ShowCreateMove(ClsMove aMove)
		{
			try
			{
				if (_frmEditVendorMove == null) _frmEditVendorMove = new frmEditVendorMove();

				_frmEditVendorMove.FormClosed += new FormClosedEventHandler(this.CloseCreateMove);
				_frmEditVendorMove.MdiParent = this;
				_frmEditVendorMove.ShowForm(aMove);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		public void ShowCreateMove(ClsVendorMove aVendorMove)
		{
			try
			{
				if (_frmEditVendorMove == null) _frmEditVendorMove = new frmEditVendorMove();

				_frmEditVendorMove.FormClosed += new FormClosedEventHandler(this.CloseCreateMove);
				_frmEditVendorMove.MdiParent = this;
				_frmEditVendorMove.ShowEditVendorMove(aVendorMove);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		public void ShowCreateVendorMove(ClsMove aMove)
		{
			try
			{
				if (_frmEditVendorMove == null) _frmEditVendorMove = new frmEditVendorMove();

				_frmEditVendorMove.FormClosed += new FormClosedEventHandler(this.CloseCreateMove);
				_frmEditVendorMove.MdiParent = this;
				_frmEditVendorMove.ShowEditVendorMove(aMove);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseCreateMove(object sender, FormClosedEventArgs e)
		{
			_frmEditVendorMove = null;
		}

		private void mnuCreateMove_Click(object sender, EventArgs e)
		{
			ClsMove move = new ClsMove();
			ShowCreateMove(move);
		}

		#endregion

		#region Search Move

		frmSearchMove _frmSearchMove;

		protected void ShowSearchMove()
		{
			try
			{
				if (_frmSearchMove == null) _frmSearchMove = new frmSearchMove();

				_frmSearchMove.FormClosed += new FormClosedEventHandler(this.CloseSearchMove);
				_frmSearchMove.MdiParent = this;
				_frmSearchMove.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseSearchMove(object sender, FormClosedEventArgs e)
		{
			_frmSearchMove = null;
		}

		private void mnuSearchMove_Click(object sender, EventArgs e)
		{
			ShowSearchMove();
		}

		#endregion

		#region Search Cargo For Move

		frmSearchCargoFormoves _frmSearchCargoForMoves;

		protected void ShowSearchCargoForMoves()
		{
			try
			{
				if (_frmSearchCargoForMoves == null) _frmSearchCargoForMoves = new frmSearchCargoFormoves();
				_frmSearchCargoForMoves.FormClosed += new FormClosedEventHandler(this.CloseSearchCargoForMoves);
				_frmSearchCargoForMoves.MdiParent = this;
				_frmSearchCargoForMoves.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseSearchCargoForMoves(object sender, FormClosedEventArgs e)
		{
			_frmSearchCargoForMoves = null;
		}

		private void mnuSearchCargoForMoves_Click(object sender, EventArgs e)
		{
			ShowSearchCargoForMoves();
		}

		#endregion

		#region Conveyance Tracking

		private void mnuDevAlternateConvey_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmConveyanceManagerAlt>(true);
		}

		private void mnuConveyanceManagement_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmConveyanceManager>(true);
		}

		private void mnuConveyanceTrackingCargoTracking_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmCargoTracking>(true);
		}

		private void mnuConveyanceTrackingMemos_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchMemo>();
		}

		frmCargoActions _frmCargoActions;

		protected void ShowCargoActions()
		{
			try
			{
				if (_frmCargoActions == null) _frmCargoActions = new frmCargoActions();

				_frmCargoActions.FormClosed += new FormClosedEventHandler(this.CloseCargoActions);
				_frmCargoActions.MdiParent = this;
				_frmCargoActions.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseCargoActions(object sender, FormClosedEventArgs e)
		{
			_frmCargoActions = null;
		}

		private void mnuCargoActions_Click(object sender, EventArgs e)
		{
			ShowCargoActions();
		}
		#endregion		// #region Conveyance Tracking

		#region Vessel Menu
		//frmPortTypeUpdate _frmPortTypeUpdate;

		//protected void ShowPortTypeUpdates()
		//{
		//    try
		//    {
		//        if (_frmPortTypeUpdate == null) _frmPortTypeUpdate = new frmPortTypeUpdate();

		//        _frmPortTypeUpdate.FormClosed += new FormClosedEventHandler(this.ClosePortTypeUpdate);
		//        _frmPortTypeUpdate.MdiParent = this;
		//        _frmPortTypeUpdate.show

		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//    }
		//}
		//private void ClosePortTypeUpdate(object sender, FormClosedEventArgs e)
		//{
		//    _frmPortTypeUpdate = null;
		//}

		private void mnuPortTypeUpdate_Click(object sender, EventArgs e)
		{
			frmPortTypeUpdate.ShowWindow();
		}

		private void mnuCustomsSubmission_Click(object sender, EventArgs e)
		{
			frmCustomsSubmission.ShowWindow(false);
		}
		#endregion

		#region IT Menu/Toolbar Actions

		private void mnuGetSecurityObjects_Click(object sender, EventArgs e)
		{
			try
			{
				List<ClsSecurityMaster.ClsSecurityChoices> choices = new List<ClsSecurityMaster.ClsSecurityChoices>();
				if (this.ActiveMdiChild == null)
					choices = ClsSecurityMaster.GetObjectsOnForm(this, true);
				else
				{
					choices = ClsSecurityMaster.GetObjectsOnForm(this.ActiveMdiChild, false);
				}
				using (frmCreateSecurity frm = new frmCreateSecurity())
				{
					frm.CreateSecurity(choices);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		#region Window Sizing

		#region Unmanaged Code Section

		[StructLayout(LayoutKind.Sequential)]
		public struct DEVMODE
		{
			private const int CCHDEVICENAME = 0x20;
			private const int CCHFORMNAME = 0x20;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
			public string dmDeviceName;
			public short dmSpecVersion;
			public short dmDriverVersion;
			public short dmSize;
			public short dmDriverExtra;
			public int dmFields;
			public int dmPositionX;
			public int dmPositionY;
			public ScreenOrientation dmDisplayOrientation;
			public int dmDisplayFixedOutput;
			public short dmColor;
			public short dmDuplex;
			public short dmYResolution;
			public short dmTTOption;
			public short dmCollate;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
			public string dmFormName;
			public short dmLogPixels;
			public int dmBitsPerPel;
			public int dmPelsWidth;
			public int dmPelsHeight;
			public int dmDisplayFlags;
			public int dmDisplayFrequency;
			public int dmICMMethod;
			public int dmICMIntent;
			public int dmMediaType;
			public int dmDitherType;
			public int dmReserved1;
			public int dmReserved2;
			public int dmPanningWidth;
			public int dmPanningHeight;
		}

		[DllImport("user32.dll")]
		public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

		#endregion		// #region Unmanaged Code Section

		private void CreateResolutionMenu()
		{
			try
			{
				int i = 0;
				DEVMODE dm = new DEVMODE();
				List<Size> lst = new List<Size>();
				while (EnumDisplaySettings(null, i, ref dm))
				{
					i++;
					Size sz = new System.Drawing.Size(dm.dmPelsWidth, dm.dmPelsHeight);
					if (sz.Width < 800 || sz.Height < 600) continue;

					if (!lst.Exists(delegate(Size eSize)
					{ return (eSize.Width == sz.Width && eSize.Height == sz.Height); }))
						lst.Add(sz);
				}
				lst.Sort(delegate(Size left, Size right)
				{
					if (left.Width < right.Width) return -1;
					if (left.Width > right.Width) return 1;
					if (left.Height < right.Height) return -1;
					if (left.Height > right.Height) return 1;
					return 0;
				});

				char menuChar = '0';
				for (i = 0; i < lst.Count; i++)
				{
					Size sz = lst[i];
					string htKey = (menuChar != '\0') ? "&" + menuChar + ": " : null;
					string menuText = string.Format("{0}Width:{1} Height:{2}",
						htKey, sz.Width, sz.Height);
					if (menuChar != '\0')
					{
						menuChar++;
						if (i == 9)
							menuChar = 'A';
						else if (menuChar > 'Z')
							menuChar = '\0';
					}
					ToolStripItem menuItem = mnuDevWindowSize.DropDownItems.Add(menuText);
					menuItem.Tag = sz;
					menuItem.Name = "mnuWindowSizeSet" + i.ToString("00");
					menuItem.Click += new EventHandler(mnuWindowSizeSet_Click);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void mnuWindowSizeSet_Click(object sender, EventArgs e)
		{
			try
			{
				ToolStripItem menuItem = sender as ToolStripItem;
				if (menuItem == null || menuItem.Tag == null) return;

				Size sz = (Size)menuItem.Tag;
				sz.Width = sz.Width - 10;
				sz.Height = sz.Height - 20;
				Size = sz;

				Screen scr = Screen.FromControl(this);
				int wOff = (scr.WorkingArea.Width - sz.Width) / 2;
				int hOff = (scr.WorkingArea.Height - sz.Height) / 2;

				Point pt = new Point(scr.WorkingArea.Left + wOff, scr.WorkingArea.Top + hOff);
				Location = pt;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Window Sizing

		#endregion		// #region IT Menu/Toolbar Actions

		#region Reference Tables

		#region AVSS 
		frmSchedulingMaintenance _frmSchedulingMaintenance;
	
		private void ViewAVSSMaintenance()
		{
			if (_frmSchedulingMaintenance == null)
		    {
				_frmSchedulingMaintenance = new frmSchedulingMaintenance();
				_frmSchedulingMaintenance.FormClosed += new FormClosedEventHandler(this.CloseMaintenance);
				_frmSchedulingMaintenance.MdiParent = this;
				_frmSchedulingMaintenance.Show();
		    }
		}
		private void CloseMaintenance(object sender, FormClosedEventArgs e)
		{
			_frmSchedulingMaintenance = null;
		}
		#endregion

		private void mnuTableMaintenanceChargeTypes_Click(object sender, EventArgs e)
		{
			frmEditChargeType.ShowMaintenance();
		}

		private void mnuTableMaintenanceChargeCategories_Click(object sender, EventArgs e)
		{
			frmEditChargeCategory.ShowMaintenance();
		}

		private void mnuTableMaintenanceLevels_Click(object sender, EventArgs e)
		{
			frmEditLevel.ShowMaintenance();
		}

		private void mnuTableMaintenanceUnitType_Click(object sender, EventArgs e)
		{
			frmEditUnitType.ShowMaintenance();
		}

		private void mnuTableMaintenanceBasis_Click(object sender, EventArgs e)
		{
			frmEditLevelUnit.ShowMaintenance();
		}

		private void mnuTableMaintenanceLocations_Click(object sender, EventArgs e)
		{
			frmEditLocation.ShowMaintenance();
		}

		private void mnuTableMaintenanceLocationTypes_Click(object sender, EventArgs e)
		{
			frmEditLocationType.ShowMaintenance();
		}

		private void mnuTableMaintenanceGeoRegion_Click(object sender, EventArgs e)
		{
			frmEditGeoRegion.ShowMaintenance();
		}

		private void mnuTableMaintenanceUsers_Click(object sender, EventArgs e)
		{
			frmEditUser.ShowMaintenance();
		}

		private void mnuTableMaintenanceVendors_Click(object sender, EventArgs e)
		{
			frmEditVendor.ShowMaintenance();
		}

		private void mnuTableMaintenanceCustomers_Click(object sender, EventArgs e)
		{
			frmEditCustomer.ShowMaintenance();
		}

		private void mnuTableMaintenanceVessels_Click(object sender, EventArgs e)
		{
			frmVesselMaintenance.ShowMaintenance();
		}

		private void mnuAdminArcNetTerminals_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchTerminals>(true);
		}

		private void mnuAdminUSC_Click(object sender, EventArgs e)
		{
			frmShowUscRates.ShowMaintenance();
		}
		#endregion		// #region Reference Tables

		#region EDI Admin
		private void tsSearchEDIHistory_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchEDIHistory>();
		}

		#region Batch Create EDI
		frmBatchEDICreate _frmBatchEDICreate;
		protected void ShowBatchEDICreate()
		{
			try
			{
				if (_frmBatchEDICreate == null) _frmBatchEDICreate = new frmBatchEDICreate();
				_frmBatchEDICreate.FormClosed += new FormClosedEventHandler(this.CloseBatchCreateEDI);
				_frmBatchEDICreate.MdiParent = this;
				_frmBatchEDICreate.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseBatchCreateEDI(object sender, FormClosedEventArgs e)
		{
			_frmBatchEDICreate = null;
		}

		private void batchEDICreateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowBatchEDICreate();
		}
		#endregion

		#region Trading Partner Edit
		frmEditTradingPartner _frmEditTradingPartner;

		protected void ShowEditTradingPartner()
		{
			try
			{
				if (_frmEditTradingPartner == null) _frmEditTradingPartner = new frmEditTradingPartner();
				_frmEditTradingPartner.FormClosed += new FormClosedEventHandler(this.CloseEditTradingPartner);
				_frmEditTradingPartner.MdiParent = this;
				_frmEditTradingPartner.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseEditTradingPartner(object sender, FormClosedEventArgs e)
		{
			_frmEditTradingPartner = null;
		}
		private void editTradingPartners_Click(object sender, EventArgs e)
		{
			ShowEditTradingPartner();
		}
		#endregion

		#region Diagnostics
		frmITVDiagnostics _frmITVDiagnostics;
		protected void ShowITVDiagnostics()
		{
			try
			{
				if (_frmImportCargoUpdates == null) _frmITVDiagnostics = new frmITVDiagnostics();
				_frmITVDiagnostics.FormClosed += new FormClosedEventHandler(this.CloseITVDiagnostics);
				_frmITVDiagnostics.MdiParent = this;
				_frmITVDiagnostics.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseITVDiagnostics(object sender, FormClosedEventArgs e)
		{
			_frmITVDiagnostics = null;
		}
		private void ediDiagnostics_Click(object sender, EventArgs e)
		{
			ShowITVDiagnostics();
		}
		#endregion

		#region Vessel Arrive Depart
		frmArriveDepart _frmArriveDepart;
		protected void ShowArriveDepart()
		{
			try
			{
				if (_frmArriveDepart == null) _frmArriveDepart = new frmArriveDepart();
				_frmArriveDepart.FormClosed += new FormClosedEventHandler(this.CloseArriveDepart);
				_frmArriveDepart.MdiParent = this;
				_frmArriveDepart.ShowForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseArriveDepart(object sender, FormClosedEventArgs e)
		{
			_frmArriveDepart = null;
		}
		private void vesselArriveDepartListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowArriveDepart();
		}
		#endregion

		#region Manual Create ITV
		frmManualITV _frmManualITV;
		protected void ShowManualITV()
		{
			try
			{
				if (_frmManualITV == null) _frmManualITV = new frmManualITV();
				_frmManualITV.FormClosed += new FormClosedEventHandler(this.CloseManualITV);
				_frmManualITV.MdiParent = this;
				_frmManualITV.Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CloseManualITV(object sender, FormClosedEventArgs e)
		{
			_frmManualITV = null;
		}

		private void ManualITVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowManualITV();
		}
		#endregion

		#endregion

		#region SDDC EDI Monitor & ACMS
		#region EDI Queries (ITV Queries)
		private void EDIQueries(string sPCFN )
		{
			frmEDIQuery frm = new frmEDIQuery(sPCFN);
			frm.Show();
		}
		private void tsEDIQuery_Click(object sender, EventArgs e)
		{
			EDIQueries(null);
		}
		#endregion

		#region Reports
		private void tsRDDReport_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmRDDReport>();
			//SearchWindowManager.Search<frmSearchEDIHistory>();
		}
		private void tsRDDPortMoves_Click(object sender, EventArgs e)
		{
			frmRDDPortMoves frm = new frmRDDPortMoves();
			frm.Show();
		}

		private void tsRDDDoorMoves_Click(object sender, EventArgs e)
		{
			frmRDDDoorMoves frm = new frmRDDDoorMoves();
			frm.Show();
		}

		private void tsSDDCArriveDepart_Click(object sender, EventArgs e)
		{
			frmSDDCArriveDepart.ShowWindow();
		}

		private void tsSterlingReports_Click(object sender, EventArgs e)
		{
			frmSterlingReports frm = new frmSterlingReports();
			frm.ShowWindow();
		}

		#endregion

		#region ACMS Windows
		private void tsManualITV_Click(object sender, EventArgs e)
		{
			frmCreateITV.ShowWindow();
		}

		private void stenaUnbookedListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmStenaUnbookedList frm = new frmStenaUnbookedList();
			frm.ShowWindow();
		}

		private void tsStenaRoutes_Click(object sender, EventArgs e)
		{
			frmEditStenaRoutes frm = new frmEditStenaRoutes();
			frm.ShowWindow();
		}



		private void tsShippingInstructions_Click(object sender, EventArgs e)
		{
			frmShippingInstructions frm = new frmShippingInstructions();
			frm.ShowWindow();
		}

		private void mnuACMSLocTermMaintenance_Click(object sender, EventArgs e)
		{
			frmLocationTerminalMaintenance.ShowMaintenance();
		}

		private void mnuACMSVesselMaintenance_Click(object sender, EventArgs e)
		{
			frmVesselMaintenance.ShowMaintenance();
		}
		#endregion

		#region Booking Requests
		frmSearchBookingRequests _frmSearchBookingRequests;

		public void RefreshSearchRequests()
		{
			if (_frmSearchBookingRequests == null)
				return;
			_frmSearchBookingRequests.SearchRequests(true,false);
		}
		public void ShowSearchRequests()
		{
			try
			{
				if (_frmSearchBookingRequests == null) _frmSearchBookingRequests = new frmSearchBookingRequests();
				_frmSearchBookingRequests.FormClosed += new FormClosedEventHandler(this.CloseSearchRequests);
				_frmSearchBookingRequests.MdiParent = this;
				_frmSearchBookingRequests.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseSearchRequests(object sender, FormClosedEventArgs e)
		{
			_frmSearchBookingRequests = null;
		}
		private void tsBookingRequests_Click(object sender, EventArgs e)
		{
			ShowSearchRequests();
		}
		#endregion

		#region Voyages
		frmSearchVoyages _frmSearchVoyages;

		//public void RefreshSearchVoyages()
		//{
		//    if (_frmSearchVoyages == null)
		//        return;
		//    _frmSearchVoyages.SearchVoyages(true);
		//}
		public void ShowSearchVoyages()
		{
			try
			{
				if (_frmSearchVoyages == null) _frmSearchVoyages = new frmSearchVoyages(null);
				_frmSearchVoyages.FormClosed += new FormClosedEventHandler(this.CloseSearchVoyages);
				_frmSearchVoyages.MdiParent = this;
				_frmSearchVoyages.Show();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseSearchVoyages(object sender, FormClosedEventArgs e)
		{
			_frmSearchVoyages = null;
		}
		private void tsSearchVoyages_Click(object sender, EventArgs e)
		{
			ShowSearchVoyages();
		}
		#endregion

		#region EDILog
		frmEDILog _frmEDILog;

		public void ShowEDILog()
		{
			try
			{
				if (_frmEDILog == null) _frmEDILog = new frmEDILog();
				_frmEDILog.FormClosed += new FormClosedEventHandler(this.ClosefrmEDILog);
				_frmEDILog.MdiParent = this;
				_frmEDILog.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ClosefrmEDILog(object sender, FormClosedEventArgs e)
		{
			_frmEDILog = null;
		}
		private void tsEDILog_Click(object sender, EventArgs e)
		{
			ShowEDILog();
		}
		#endregion

		#region Dimension Synch
		frmDimsSynch _frmDimsSynch;

		public void ShowDimsSynch()
		{
			try
			{
				if (_frmDimsSynch == null) _frmDimsSynch = new frmDimsSynch();
				_frmDimsSynch.FormClosed += new FormClosedEventHandler(this.ClosefrmDimsSynch);
				_frmDimsSynch.MdiParent = this;
				_frmDimsSynch.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ClosefrmDimsSynch(object sender, FormClosedEventArgs e)
		{
			_frmDimsSynch = null;
		}
		private void tsDimsSynch_Click(object sender, EventArgs e)
		{
			ShowDimsSynch();
		}
		#endregion

		#region Missed RDD Report
		frmRDDMissed _frmRDDMissed;

		public void ShowRDDMissed()
		{
			try
			{
				if (_frmRDDMissed == null) _frmRDDMissed= new frmRDDMissed();
				_frmRDDMissed.FormClosed += new FormClosedEventHandler(this.ClosefrmRDDMissed);
				_frmRDDMissed.MdiParent = this;
				_frmRDDMissed.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void ClosefrmRDDMissed(object sender, FormClosedEventArgs e)
		{
			_frmRDDMissed = null;
		}
		private void tsRDDMissed_Click(object sender, EventArgs e)
		{
			ShowRDDMissed();
		}
		#endregion

		#region ACMS Dashboard
		frmACMSDashboard _frmACMSDashboard;

		public void ShowACMSDashboard()
		{
			try
			{
                // JD - This prevents the automatic loading of the ACMS Dashboard for
                // The Port Operations Group.  (This falls outside of our security model)
                ClsSecurity s = ClsSecurity.GetUsingFKAlt(ClsEnvironment.UserName,"ACMS Dashboard");
                if (s.IsNotNull()) if (s.Visible_Flg == "N") return;

				if (!Program.IsLoggedIntoACMS)
					return;
				if (_frmACMSDashboard == null) _frmACMSDashboard = new frmACMSDashboard();
				_frmACMSDashboard.FormClosed += new FormClosedEventHandler(this.CloseACMSDashboard);
				_frmACMSDashboard.MdiParent = this;
				_frmACMSDashboard.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseACMSDashboard(object sender, FormClosedEventArgs e)
		{
			_frmACMSDashboard = null;
		}
		private void tsACMSDashboard_Click(object sender, EventArgs e)
		{
			ShowACMSDashboard();
		}
		#endregion
		#endregion

		#region Finance

		private void tsLineHaulBillingExtract_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmLHaulBillingExgtract>(true);
		}

		private void mnuSearchAPInvoices_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchAPInvoice>(true);
		}

		private void tsProvisionalInvoice_Click(object sender, EventArgs e)
		{
			frmProvisionalInvoice frm = new frmProvisionalInvoice();
			frm.Show();
		}

		private void tsSDDCediQueiresFi_Click(object sender, EventArgs e)
		{
			EDIQueries(null);
		}
		private void tsIALPOVTracking_Click(object sender, EventArgs e)
		{
			frmIALPOVTracking frm = new frmIALPOVTracking();
			frm.Show();
		}
		#endregion

		#region Security

		private void securityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmViewSecurity.ViewSecurity();
		}

		private void mnuGetSecurityObjects_Click_1(object sender, EventArgs e)
		{
			List<ClsSecurityMaster.ClsSecurityChoices> choices = new List<ClsSecurityMaster.ClsSecurityChoices>();
			if (this.ActiveMdiChild == null)
				choices = ClsSecurityMaster.GetObjectsOnForm(this, true);
			else
			{
				choices = ClsSecurityMaster.GetObjectsOnForm(this.ActiveMdiChild, false);
			}
			using (frmCreateSecurity frm = new frmCreateSecurity())
			{
				frm.CreateSecurity(choices);
			}
		}
		#endregion

		#region STENA
		private void testSTENABookingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//string s = ClsSTENAservice.ConfirmBooking();
			//Program.Show(s);
		}

		private void testSTENARoutesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StringBuilder sb = ClsSTENAservice.GetRoutes();
			Program.Show(sb.ToString());
		}
		#endregion

		#region SDDC Invoicing
		private void tsSDDCInvoicing_Click(object sender, EventArgs e)
		{
			frmSDDCInvoicing frm = new frmSDDCInvoicing();
			frm.Show();
		}
		#endregion

		#region Form Load
		private void frmMain_Load(object sender, EventArgs e)
		{
			if (Program.IsLoggedIntoACMS)
				ShowACMSDashboard();
            BuildHelpMenu();
		}
		#endregion

		#region EDI Monitor
		#region Inbound EDI Log
		frmEDIInboundLog _frmEDIInboundLog;

		public void ShowEDIInboundLog()
		{
			try
			{
				if (_frmEDIInboundLog == null) _frmEDIInboundLog = new frmEDIInboundLog();
				_frmEDIInboundLog.FormClosed += new FormClosedEventHandler(this.CloseEDIInboundLog);
				_frmEDIInboundLog.MdiParent = this;
				_frmEDIInboundLog.ShowForm();

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void CloseEDIInboundLog(object sender, FormClosedEventArgs e)
		{
			_frmEDIInboundLog = null;
		}
		private void tsInboundEDILog_Click(object sender, EventArgs e)
		{
			ShowEDIInboundLog();
		}
		#endregion

		#region IAL EDI
		//frmIAL _frmIAL = new frmIAL();

		//public void ShowIAL()
		//{
		//    try
		//    {
		//        if (_frmIAL == null) _frmIAL = new frmIAL();
		//        _frmIAL.FormClosed += new FormClosedEventHandler(this.CloseIAL);
		//        _frmIAL.MdiParent = this;
		//        _frmIAL.ShowForm();

		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//    }
		//}
		//private void CloseIAL(object sender, FormClosedEventArgs e)
		//{
		//    _frmIAL = null;
		//}

		private void mnuIALEDI_Click(object sender, EventArgs e)
		{
			frmIAL frm = new frmIAL();
			frm.MdiParent = this;
			frm.ShowForm();
		}
		#endregion
		#endregion

		#region Events

		private void tsSurchargeCodes_Click(object sender, EventArgs e)
		{
			frmSurchargeCodes frm = new frmSurchargeCodes();
			frm.Show();
		}

		private void tsTransmit_Click(object sender, EventArgs e)
		{
			frmEDITransmit frm = new frmEDITransmit();
			frm.Show();
		}

		private void tsErrorLog_Click(object sender, EventArgs e)
		{
			frmScanFilesEDI.ShowWindow();
		}

		private void mnuMailLists_Click(object sender, EventArgs e)
		{
			frmMailListEdit frm = new frmMailListEdit();
			frm.ShowWindow();
		}

		private void mnuCargoTypeEdit_Click(object sender, EventArgs e)
		{
			frmCargoTypeEdit frm = new frmCargoTypeEdit();
			frm.ShowWindow();
		}

		private void mnuCommodityEdit_Click(object sender, EventArgs e)
		{
			frmCommodityDscEdit frm = new frmCommodityDscEdit();
			frm.ShowWindow();
		}

        private void mnuSearchCargo_Click_1(object sender, EventArgs e)
        {
            frmCargoSearch frmCS = new frmCargoSearch();
            frmCS.Show();
        }

		private void mnuStenaSailings_Click(object sender, EventArgs e)
		{
			frmStenaSailings frm = new frmStenaSailings();
			frm.ShowWindow();
		}

		private void mnuStenaSailings1_Click(object sender, EventArgs e)
		{
			frmStenaSailings frm = new frmStenaSailings();
			frm.ShowWindow();
		}

		private void mnuAVSSRefTables_Click(object sender, EventArgs e)
		{
			ViewAVSSMaintenance();
		}
		private void tsSearchStena_Click(object sender, EventArgs e)
		{
			frmViewStenaBookings frm = new frmViewStenaBookings();
			frm.ShowWindow();
		}

		#endregion

		#region AVSS
		#region Manage Voyages
		private void tsManageVoyages_Click(object sender, EventArgs e)
		{
			VesselActivity(true);
		}
		frmUpdateVessel _frmUpdateVessel;
		private void VesselActivity(bool bShowTransshipments)
		{
			if (_frmUpdateVessel == null)
			{
				_frmUpdateVessel = new frmUpdateVessel();
				_frmUpdateVessel.FormClosed += new FormClosedEventHandler(this.CloseVesselActivity);
				_frmUpdateVessel.MdiParent = this;
				//if (bShowTransshipments)
				//    _frmUpdateVessel.SetToARCMode();
				_frmUpdateVessel.Show();
			}
		}
		private void CloseVesselActivity(object sender, FormClosedEventArgs e)
		{
			_frmUpdateVessel = null;
		}
		#endregion

        private void ArriveAndDepartVessels()
        {
            try
            {
                ClsConvenientArrDep c = new ClsConvenientArrDep();
                BindingList<mConvenientArrDep> x = (BindingList<mConvenientArrDep>)c.LoadArrDep();

                if (x != null && x.Count > 0)
                {
                    frmUpdateArrDep frmUAP = new frmUpdateArrDep();
                    frmUAP.ShowOpen(x);
                }
                else
                {
                    MessageBox.Show("There are no Port Calls to Arrive or Depart at this time.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ArriveAndDepartVesselsWWL()
        {
            try
            {

                ClsConvenientArrDep c = new ClsConvenientArrDep();
                BindingList<mConvenientArrDep> x = (BindingList<mConvenientArrDep>)c.LoadArrDepWWL();

                if (x != null && x.Count > 0)
                {
                    frmPortOpsArriveDepart frmP = new frmPortOpsArriveDepart();
                    frmP.ShowOpen(x);
                }
                else
                {
                    MessageBox.Show("There are no Port Calls to Arrive or Depart at this time.");
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }


		#endregion


		#region Assign VoyDocs
		frmManageMilitaryVoyages _frmManageMilitaryVoyages;

		private void ManageMilitaryVoyages()
		{
			if (_frmManageMilitaryVoyages == null)
			{
				_frmManageMilitaryVoyages = new frmManageMilitaryVoyages();
				_frmManageMilitaryVoyages.FormClosed += new FormClosedEventHandler(this.CloseManageMilitaryVoyages);
				_frmManageMilitaryVoyages.MdiParent = this;
				_frmManageMilitaryVoyages.Show();
			}
		}
		private void CloseManageMilitaryVoyages(object sender, FormClosedEventArgs e)
		{
			_frmManageMilitaryVoyages = null;
		}
		private void tsAssignVoyDocs_Click(object sender, EventArgs e)
		{
			ManageMilitaryVoyages();
		}
		#endregion

        #region SDDC Invoicing (Alternate Screen)

        frmSDDCInvoicing2 _frmSDDCInvoicing2;

        private void sDDCInvoicingAlternateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmSDDCInvoicing2.IsNull())
            {
                _frmSDDCInvoicing2 = new frmSDDCInvoicing2();
                _frmSDDCInvoicing2.FormClosed+=new FormClosedEventHandler(ClosefrmSDDCInvoicing2);
                _frmSDDCInvoicing2.MdiParent = this;
                _frmSDDCInvoicing2.Show();
            }
        }

        private void ClosefrmSDDCInvoicing2(object sender, FormClosedEventArgs e)
        {
            _frmSDDCInvoicing2 = null;
        }

        #endregion

        #region IAL Recalls

        frmIALRecall _frmIALRecall;

        private void tsmiIALRecalls_Click(object sender, EventArgs e)
        {
            if (_frmIALRecall.IsNull())
            {
                _frmIALRecall = new frmIALRecall();
                _frmIALRecall.FormClosed+=new FormClosedEventHandler(ClosefrmIALRecall);
                _frmIALRecall.MdiParent = this;
                _frmIALRecall.ShowForm();
            }
        }

        private void ClosefrmIALRecall(object o, FormClosedEventArgs e)
        {
            _frmIALRecall = null;
        }

        #endregion

        #region Dynamically Build Help Manual Menu
        private void BuildHelpMenu()
        {
            string sFolder = System.Configuration.ConfigurationManager.AppSettings["TSGUIDES"];
            DirectoryInfo d = new DirectoryInfo(sFolder);
            FileInfo[] Files = d.GetFiles("*.pdf");
            foreach (FileInfo file in Files)
            {
                ToolStripMenuItem Menu01 = new ToolStripMenuItem(file.Name, null, HelpManualClick);
                mnuHelp.DropDownItems.Add(Menu01);
            }
        }

        public void HelpManualClick(object sender, System.EventArgs e)
        {
            string sFolder = System.Configuration.ConfigurationManager.AppSettings["TSGUIDES"];
            string sFile = sender.ToString();
            ProcessStartInfo startInfo = new ProcessStartInfo(sFolder + sFile);
            Process.Start(startInfo);

        }
        #endregion

        private void tsVGM_Click(object sender, EventArgs e)
		{
			frmLINEWarehouseQuery frm = new frmLINEWarehouseQuery(true);
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuEstimageInvestigate_Click(object sender, EventArgs e)
		{
			ViewEstimateInvestigate();
		}

        private void tsmiArriveAndDepartVessels_Click(object sender, EventArgs e)
        {
            ArriveAndDepartVessels();
        }

        private void tsmiArriveAndDepartVesselsWWL_Click(object sender, EventArgs e)
        {
            ArriveAndDepartVesselsWWL();
        }

        private void tsmiNhtsaRecalls_Click(object sender, EventArgs e)
        {
            NHTSARecall();
        }

		private void stubTestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ClsUscbpExportAes a = new ClsUscbpExportAes();
				a.Bol_No = "ABC";
				a.Exempt_Ind = 0;
				a.Status_Ind = 1;
				a.Trading_Partner_Cd = "VILDEN";
				a.File_Nm = "testfile";
				a.Insert();
			}
			catch (Exception ex)
			{
				string a = ex.Message;

			}
		}

		private void tsSearchEDI_Click(object sender, EventArgs e)
		{
			SearchWindowManager.Search<frmSearchEDI>();
		}

		private void searchBookingsOceanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmLINEQuery frm = new frmLINEQuery();
			frm.MdiParent = this;
			frm.Show();
		}

        private void tsOceanAPILog_Click(object sender, EventArgs e)
        {
            SearchWindowManager.Search<frmAPILog>();
        }

        private void tsEDITranslate_Click(object sender, EventArgs e)
        {
            frmEDITranslation frm = new frmEDITranslation();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsTopsPorts_Click(object sender, EventArgs e)
        {
            frmEditTopsPorts frm = new frmEditTopsPorts();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsPartnerConfigs_Click(object sender, EventArgs e)
        {
            frmEditPartnerEDI frm = new frmEditPartnerEDI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsIALTroubleShooting_Click(object sender, EventArgs e)
        {
            OpenUserGuilde("IAL");
        }

        protected void OpenUserGuilde(string sGuide)
        {
            string sFld = System.Configuration.ConfigurationManager.AppSettings["TSGUIDES"];
            string sFolder = string.Format(@"\\SourceSafe\d\All Software Documentation\TroubleShooting Guides\");
            string sFile = "";
            switch (sGuide)
            {
                case "IAL":
                    sFile = "IALTroubleshooting.pdf";
                    break;
            }
            if (sFile.IsNullOrWhiteSpace())
            {
                Program.Show("Guide not found");
                return;
            }
            ProcessStartInfo startInfo = new ProcessStartInfo(sFolder + sFile);
            Process.Start(startInfo);
        }

        private void mnuEstimateInvestigator_Click(object sender, EventArgs e)
        {
            ViewEstimateInvestigate();
        }

        private void testLaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Show("Test launching an app on arcedi1");

        }



    }
}