using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmSalesSummaryOptions : frmDialogBase
	{
		#region Fields/Properties

		private ClsSalesSummary _Options;

		public ClsSalesSummary Options { get { return _Options; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Initialization

        public frmSalesSummaryOptions()
		{
			InitializeComponent();

            _Options = new ClsSalesSummary();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		public bool GetSearchCriteria()
		{
			try
			{
				return ShowDialog() == DialogResult.OK;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmSearchEstimateOptions_Load(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Entry/Initialization

		#region Actions/Events

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}

		private void frmSearchEstimateOptions_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.D) btnClear.PerformClick();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Actions/Events

		#region Check/Save Changes

		protected override bool SaveChanges()
		{
			try
			{
				_Options.Clear();

				_Options.PCFN = txtPCFN.Text.Trim();
				_Options.Booking_No = txtBooking.Text.Trim();

				_Options.Vessel = cmbVessel.VesselCDs;
				_Options.VoyageNo = txtVoyage.Text.Trim();
				_Options.PLOR_CDs = cmbPLOR.LocationCDs;
				_Options.POL_CDs = cmbPOL.LocationCDs;
				_Options.POD_CDs = cmbPOD.LocationCDs;
				_Options.PLOD_CDs = cmbPLOD.LocationCDs;
				_Options.MoveTypeCDs = cmbMoveType.MoveTypeCDs;
				_Options.Serial_No = txtSerialNo.Text.Trim();
                _Options.Estimate_No = txtEstimateNo.Text.Trim();

				_Options.Vessel_Sail_Dt = grpSailDt.CheckedValueRange;

				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion		// #region Check/Save Changes
	}
}
