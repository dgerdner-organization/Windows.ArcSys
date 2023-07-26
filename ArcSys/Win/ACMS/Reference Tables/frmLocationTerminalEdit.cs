using System;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.CommonWinCtrls;
using CS2010.AVSS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmLocationTerminalEdit : Form
	{
		#region Fields/Properties

		private DialogMode CurrentMode;
		private ClsLocationTerminal theTerminal;

		// This is the AVSS Berth/Terminal which we will synchronize with ACMS
		private ClsBerth theBerth;

		#endregion		// #region Fields/Properties

		#region Constructors

		public frmLocationTerminalEdit()
		{
			InitializeComponent();
		}

		public ClsLocationTerminal AddTerminal(ClsLocation aLoc)
		{
			try
			{
				if (aLoc == null || aLoc.Location_Cd == null)
				{
					Program.ShowError("No location provided");
					return null;
				}

				CurrentMode = DialogMode.Add;

				theTerminal = new ClsLocationTerminal();
				theTerminal.SetDefaults();
				theTerminal.Location_Cd = aLoc.Location_Cd;

				theBerth = new ClsBerth();
				theBerth.SetDefaults();
				theBerth.Port_Cd = aLoc.Location_Cd;

				return (ShowDialog() == DialogResult.OK) ? theTerminal : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditTerminal(ClsLocationTerminal aTerm)
		{
			try
			{
				CurrentMode = DialogMode.Edit;

				theTerminal = (aTerm != null) ? new ClsLocationTerminal(aTerm) : null;
				if (theTerminal == null)
					return Program.ShowError("No location provided");
				theTerminal.ReloadFromDB();

				// Get the AVSS Terminal
				theBerth = ClsBerth.GetUsingKey(theTerminal.Terminal_Cd);
				if (theBerth == null)
				{
					theBerth = new ClsBerth();
					theBerth.SetDefaults();
					theBerth.Military_Flg = theBerth.Inducement_Flg = "N";
					theBerth.Port_Cd = theTerminal.Location_Cd;
					theBerth.Berth_Cd = theTerminal.Terminal_Cd;
					theBerth.Berth_Nm = theBerth.Berth_Web_Display = theTerminal.Terminal_Dsc;
					theBerth.Military_Cd = theTerminal.Location.Other1_Cd;
					theBerth.Insert();
				}

				if (ShowDialog() != DialogResult.OK) return false;

				aTerm.CopyFrom(theTerminal);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmLocationTerminalEdit_Load(object sender, EventArgs e)
		{
			try
			{
				txtLocationCd.MaxLength = ClsLocationTerminal.Location_CdMax;
				txtTerminalCd.MaxLength = ClsLocationTerminal.Terminal_CdMax;
				txtTerminalDsc.MaxLength = ClsLocationTerminal.Terminal_DscMax;
				txtOther1.MaxLength = ClsLocationTerminal.Other1_CdMax;

				BindHelper.Bind(txtLocationCd, theTerminal, "Location_Cd");
				BindHelper.Bind(txtTerminalCd, theTerminal, "Terminal_Cd");
				BindHelper.Bind(txtTerminalDsc, theTerminal, "Terminal_Dsc");
				BindHelper.Bind(txtOther1, theTerminal, "Other1_Cd");
				BindHelper.Bind(chkDefault, theTerminal, "Default_Fl");
				BindHelper.Bind(chkDeleted, theTerminal, "Delete_Fl");

				// AVSS Stuff
				BindHelper.Bind(txtBerthCd, theBerth, "Berth_Cd");
				BindHelper.Bind(txtBerthName, theBerth, "Berth_Nm");
				//BindHelper.Bind(cmbPort, theItem, "Port_Cd");
				BindHelper.Bind(cbxMilitaryFlg, theBerth, "Military_Flg");
				BindHelper.Bind(chkInducement, theBerth, "Inducement_Flg");
				BindHelper.Bind(txtMilitaryCode, theBerth, "Military_Cd");
				BindHelper.Bind(txtWebBerthDisplay, theBerth, "Berth_Web_Display");
				cmbEndTime.DataBindings.Add("Value", theBerth, "Work_Hours_End", true, DataSourceUpdateMode.OnPropertyChanged);
				cmbStartTime.DataBindings.Add("Value", theBerth, "Work_Hours_Start", true, DataSourceUpdateMode.OnPropertyChanged);
				//
				if (CurrentMode == DialogMode.Add)
				{
					txtTerminalCd.ReadOnly = false;
					txtTerminalCd.Focus();
					ActiveControl = txtTerminalCd;
					Text = "Add New Terminal to " + theTerminal.Location_Cd;
				}
				else
				{
					txtTerminalCd.ReadOnly = true;
					txtTerminalDsc.Focus();
					ActiveControl = txtTerminalDsc;
					Text = "Edit Terminal";
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors

		#region Save

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				bool ok = (CurrentMode == DialogMode.Add)
					? theTerminal.ValidateInsert() : theTerminal.ValidateUpdate();
				if (!ok)
				{
					Program.ShowError(theTerminal.Error);
					return;
				}

				if (CurrentMode == DialogMode.Add)
					theTerminal.Insert();
				else
					theTerminal.Update();

				SynchronizeAVSS();
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SynchronizeAVSS()
		{
			if (CurrentMode == DialogMode.Add)
				theBerth.Insert();
			else
				theBerth.Update();
		}
		#endregion		// #region Save

		#region Synchronize Events
		private void txtTerminalCd_TextChanged(object sender, EventArgs e)
		{
			theBerth.Berth_Cd = txtTerminalCd.Text;
		}
		private void txtTerminalDsc_TextChanged(object sender, EventArgs e)
		{
			theBerth.Berth_Nm = txtTerminalDsc.Text;
		}

		private void txtOther1_TextChanged(object sender, EventArgs e)
		{
			theBerth.Military_Cd = txtOther1.Text;
		}
		#endregion


	}
}