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
	public partial class frmCreateEstimateOptions : frmDialogBase
	{
		#region Fields/Properties

		private ClsEstimateSearch _Options;

		public ClsEstimateSearch Options { get { return _Options; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Initialization

		public frmCreateEstimateOptions()
		{
			InitializeComponent();

			_Options = new ClsEstimateSearch();

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

		private void frmCreateEstimateOptions_Load(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void SetDefaults()
		{
			try
			{
				WindowHelper.ClearAllControls(this);

				DateRange defDate = GetDefaultDate();
				grpSailDt.CheckBoxChecked = true;
				grpSailDt.FromDate = defDate.From;
				grpSailDt.ToDate = defDate.To;

				chkIncludeBlankTCN.Checked = false;
				chkIncludeTransFinal.Checked = false;
				chkNonBillPay.Checked = false;
				chkShowAllMoveTypes.Checked = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public DateRange GetDefaultDate()
		{
			try
			{
				DateTime dt60 = DateTime.Now.AddDays(-60);
				if (dt60.Day != 1) dt60 = new DateTime(dt60.Year, dt60.Month, 1);
				DateRange result = new DateRange();
				result.From = dt60;
				result.To = null;
				return result;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return DateRange.Empty;
			}
		}
		#endregion		// #region Constructors/Entry/Initialization

		#region Actions/Events

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}

		private void btnDefaults_Click(object sender, EventArgs e)
		{
			SetDefaults();
		}

		private void frmCreateEstimateOptions_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.Delete)
					btnClear.PerformClick();
				else if (e.Control && e.KeyCode == Keys.D)
					btnDefaults.PerformClick();
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
				_Options.Act_Orig_CDs = cmbActOrig.LocationCDs;
				_Options.Act_Dest_CDs = cmbActDest.LocationCDs;
				_Options.MoveTypeCDs = cmbMoveType.MoveTypeCDs;
				_Options.Serial_No = txtSerialNo.Text.Trim();

				_Options.Vessel_Sail_Dt = grpSailDt.CheckedValueRange;

				VerifyMoveTypeCheckbox();
				_Options.IncludeNonDoor = chkShowAllMoveTypes.Checked;

				_Options.IncludeNonBillPay = chkNonBillPay.Checked;
				_Options.IncludeBlankTCNs = chkIncludeBlankTCN.Checked;
				_Options.IncludeTransShip = chkIncludeTransFinal.Checked;

				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private bool VerifyMoveTypeCheckbox()
		{
			try
			{
				string mtypes = cmbMoveType.MoveTypeCDs;
				if (string.IsNullOrEmpty(mtypes) ) return false;
				if (mtypes.Contains("1") || mtypes.Contains("2") ||
					mtypes.Contains("3") || mtypes.Contains("4"))
				{
					chkShowAllMoveTypes.Checked = true;
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion		// #region Check/Save Changes
	}
}