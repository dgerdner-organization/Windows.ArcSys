using System;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.CommonWinCtrls;
using CS2010.AVSS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmVesselEdit : Form
	{
		#region Fields/Properties

		private DialogMode CurrentMode;
		private CS2010.ACMS.Business.ClsVessel theItem;

		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Init

		public frmVesselEdit()
		{
			InitializeComponent();
		}

		public CS2010.ACMS.Business.ClsVessel AddVessel()
		{
			try
			{
				CurrentMode = DialogMode.Add;

				theItem = new CS2010.ACMS.Business.ClsVessel();
				theItem.SetDefaults();

				return (ShowDialog() == DialogResult.OK) ? theItem : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditVessel(CS2010.ACMS.Business.ClsVessel aVessel)
		{
			try
			{
				CurrentMode = DialogMode.Edit;

				theItem = (aVessel != null) ? new CS2010.ACMS.Business.ClsVessel(aVessel) : null;
				if (theItem == null)
					return Program.ShowError("No vessel provided");
				theItem.ReloadFromDB();

				if (ShowDialog() != DialogResult.OK) return false;

				aVessel.CopyFrom(theItem);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmVesselEdit_Load(object sender, EventArgs e)
		{
			try
			{
				txtVesselCd.MaxLength = CS2010.ACMS.Business.ClsVessel.Vessel_CdMax;
				txtVesselDsc.MaxLength = CS2010.ACMS.Business.ClsVessel.Vessel_DscMax;
				txtFlag.MaxLength = CS2010.ACMS.Business.ClsVessel.FlagMax;
				txtIrcs.MaxLength = CS2010.ACMS.Business.ClsVessel.IrcsMax;
				txtNationality.MaxLength = CS2010.ACMS.Business.ClsVessel.NationalityMax;
				numMaxWt.MaxLength = 10;
				numMaxHt.MaxLength = 10;
				numYrBuilt.MaxLength = 4;

				BindHelper.Bind(txtVesselCd, theItem, "Vessel_Cd");
				BindHelper.Bind(txtVesselDsc, theItem, "Vessel_Dsc");
				BindHelper.Bind(txtFlag, theItem, "Flag");
				BindHelper.Bind(txtIrcs, theItem, "Ircs");
				BindHelper.Bind(txtNationality, theItem, "Nationality");
				BindHelper.Bind(numMaxWt, theItem, "Max_Wt");
				BindHelper.Bind(numMaxHt, theItem, "Max_Ht");
				BindHelper.Bind(numYrBuilt, theItem, "Year_Built");
				BindHelper.Bind(chkDeleted, theItem, "Delete_Fl");

				CS2010.AVSS.Business.ClsVessel avssVess = CS2010.AVSS.Business.ClsVessel.GetUsingKey(theItem.Vessel_Cd);
				cbxARCFlag.YN = "N";
				if (avssVess != null)
				{
					cbxARCFlag.YN = avssVess.Arc_Flg;
				}

				if (CurrentMode == DialogMode.Add)
				{
					txtVesselCd.ReadOnly = false;
					txtVesselCd.Focus();
					ActiveControl = txtVesselCd;
				}
				else
				{
					txtVesselCd.ReadOnly = true;
					txtVesselDsc.Focus();
					ActiveControl = txtVesselDsc;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region /Entry/Init

		#region Save

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				bool ok = (CurrentMode == DialogMode.Add)
					? theItem.ValidateInsert() : theItem.ValidateUpdate();
				if (!ok)
				{
					Program.ShowError(theItem.Error);
					return;
				}

				if (CurrentMode == DialogMode.Add)
				{
					theItem.Insert();
					SynchAVSS();
				}
				else
				{
					theItem.Update();
					SynchArcSys();
					SynchAVSS();
				}

				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SynchArcSys()
		{
			try
			{
				// Update matching Vessel in ArcSys
				ArcSys.Business.ClsVessel arcVess = ArcSys.Business.ClsVessel.GetUsingKey(theItem.Vessel_Cd);
				if (arcVess == null)
					return;
				arcVess.Vessel_Nm = theItem.Vessel_Dsc;
				arcVess.Ircs_Cd = theItem.Ircs;
				arcVess.Arc_Flg = cbxARCFlag.YN;
				arcVess.Update();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void SynchAVSS()
		{
			try
			{
				// Update matching Vessel in AVSS
				CS2010.AVSS.Business.ClsVessel avssVess = CS2010.AVSS.Business.ClsVessel.GetUsingKey(theItem.Vessel_Cd);
				if (avssVess == null)
				{
					avssVess = new AVSS.Business.ClsVessel();
					avssVess.Vessel_Cd = this.theItem.Vessel_Cd;
					avssVess.Vessel_Nm = this.theItem.Vessel_Dsc;
					avssVess.Ircs_Cd = this.theItem.Ircs;
					avssVess.Arc_Flg = cbxARCFlag.YN;
					if (avssVess.ValidateInsert())
						avssVess.Insert();
					else
						Program.Show(avssVess.Error);
				}
				else
				{
					avssVess.Ircs_Cd = theItem.Ircs;
					avssVess.Vessel_Nm = theItem.Vessel_Dsc;
					avssVess.Arc_Flg = cbxARCFlag.YN;
					if (avssVess.ValidateUpdate())
						avssVess.Update();
					else
						Program.Show(avssVess.Error);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Save
	}
}