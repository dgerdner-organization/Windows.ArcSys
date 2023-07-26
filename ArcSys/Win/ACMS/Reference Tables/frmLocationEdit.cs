using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmLocationEdit : Form
	{
		#region Fields/Properties

		private DialogMode CurrentMode;
		private CS2010.ACMS.Business.ClsLocation theLocation;
		private ArcSys.Business.ClsLocation theArcSysLocation;
		private AVSS.Business.ClsPort thePort;

		#endregion		// #region Fields/Properties

		#region Constructors

		public frmLocationEdit()
		{
			InitializeComponent();
		}

		public ClsLocation AddLocation()
		{
			try
			{
				CurrentMode = DialogMode.Add;

				theLocation = new ClsLocation();
				theLocation.SetDefaults();
				thePort = new AVSS.Business.ClsPort();
				thePort.SetDefaults();
				theArcSysLocation = new ArcSys.Business.ClsLocation();
				theArcSysLocation.SetDefaults();

				return (ShowDialog() == DialogResult.OK) ? theLocation : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditLocation(ClsLocation aLoc)
		{
			try
			{
				CurrentMode = DialogMode.Edit;

				theLocation = (aLoc != null) ? new ClsLocation(aLoc) : null;
				if (theLocation == null)
					return Program.ShowError("No location provided");
				theLocation.ReloadFromDB();

				// Get the corresopnding ArcSys Location
				theArcSysLocation = ArcSys.Business.ClsLocation.GetUsingKey(theLocation.Location_Cd);
				if (theArcSysLocation == null)
				{
					theArcSysLocation = new ArcSys.Business.ClsLocation();
					theArcSysLocation.SetDefaults();
					theArcSysLocation.Location_Cd = theLocation.Location_Cd;
					theArcSysLocation.Location_Dsc = theLocation.Location_Dsc;
					theArcSysLocation.Location_Type_Cd = "PORT";
					theArcSysLocation.Insert();
				}

				// Get corresponding AVSS Port Location
				thePort = AVSS.Business.ClsPort.GetUsingKey(theLocation.Location_Cd);
				if (thePort == null)
				{
					thePort = new AVSS.Business.ClsPort();
					thePort.SetDefaults();
					thePort.Port_Cd = theLocation.Location_Cd;
					thePort.Port_Nm = theLocation.Location_Dsc;
					thePort.Census_Cd = theLocation.Census_Cd;
					thePort.Census_Type = theLocation.Census_Type;
					thePort.Insert();
				}

				if (ShowDialog() != DialogResult.OK) return false;

				aLoc.CopyFrom(theLocation);


				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmLocationEdit_Load(object sender, EventArgs e)
		{
			try
			{
				txtLocationCd.MaxLength = ClsLocation.Location_CdMax;
				txtLocationDsc.MaxLength = ClsLocation.Location_DscMax;
				txtOther1.MaxLength = ClsLocation.Other1_CdMax;
				txtOther2.MaxLength = ClsLocation.Other2_CdMax;
				txtCensusCd.MaxLength = ClsLocation.Census_CdMax;
				txtCensusType.MaxLength = ClsLocation.Census_TypeMax;
				txtCity.MaxLength = ClsLocation.CityMax;
				txtState.MaxLength = ClsLocation.State_CdMax;
				txtCountryCd.MaxLength = ClsLocation.Country_CdMax;

				BindHelper.Bind(txtLocationCd, theLocation, "Location_Cd");
				BindHelper.Bind(txtLocationDsc, theLocation, "Location_Dsc");
				BindHelper.Bind(txtOther1, theLocation, "Other1_Cd");
				BindHelper.Bind(txtOther2, theLocation, "Other2_Cd");
				BindHelper.Bind(txtCensusCd, theLocation, "Census_Cd");
				BindHelper.Bind(txtCensusType, theLocation, "Census_Type");
				BindHelper.Bind(txtCity, theLocation, "City");
				BindHelper.Bind(txtState, theLocation, "State_Cd");
				BindHelper.Bind(txtCountryCd, theLocation, "Country_Cd");
				BindHelper.Bind(chkDeleted, theLocation, "Delete_Fl");

				BindHelper.Bind(txtAVSSCendusType, thePort, "Census_Type");
				BindHelper.Bind(txtAVSSCensusCd, thePort, "Census_Cd");
				BindHelper.Bind(txtPortCode, thePort, "Port_Cd");
				BindHelper.Bind(txtAVSSPortName, thePort, "Port_Nm");

				BindHelper.Bind(txtArcSysName, theArcSysLocation, "Location_Dsc");
				BindHelper.Bind(cbxActive, theArcSysLocation, "Active_Flg");
				BindHelper.Bind(cbxBorder, theArcSysLocation, "Border_Flg");
				BindHelper.Bind(cbxCheckPoint, theArcSysLocation, "Checkpoint_Flg");
				BindHelper.Bind(cbxGate, theArcSysLocation, "Gate_Flg");
				BindHelper.Bind(cbxHold, theArcSysLocation, "Hold_Area_Flg");
				BindHelper.Bind(cmbGeoRegion, theArcSysLocation, "Geo_Region_Cd");
				BindHelper.Bind(cmbLocationType, theArcSysLocation,"Location_Type_Cd");

				if (CurrentMode == DialogMode.Add)
				{
					txtLocationCd.ReadOnly = false;
					txtLocationCd.Focus();
					ActiveControl = txtLocationCd;
					Text = "Add New Location";
				}
				else
				{
					txtLocationCd.ReadOnly = true;
					txtLocationDsc.Focus();
					ActiveControl = txtLocationDsc;
					Text = "Edit Location";
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
					? theLocation.ValidateInsert() : theLocation.ValidateUpdate();
				if (!ok)
				{
					Program.ShowError(theLocation.Error);
					return;
				}

				string locType = cmbLocationType.SelectedLocationTypeCD;
				if (string.IsNullOrWhiteSpace(locType))
				{
					Program.ShowError("Missing or invalid location type");
					return;
				}

				if (CurrentMode == DialogMode.Add)
				{
					theLocation.Insert();
					theArcSysLocation.Insert();
					if (theArcSysLocation.Location_Type_Cd == "PORT")
						thePort.Insert();
				}
				else
					theLocation.Update();

				SynchArcSys();

				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void SynchArcSys()
		{
			try
			{	// Update ArcSys with ACMS data
				//ClsACMSUtil.SynchronizeLocations();
				//CS2010.ArcSys.Business.ClsLocation arcLocation =
				//    CS2010.ArcSys.Business.ClsLocation.GetUsingKey(theLocation.Location_Cd);
				//if (arcLocation == null)
				//    return;
				//arcLocation.Location_Type_Cd = cmbLocationType.SelectedLocationTypeCD;
				//arcLocation.Update();
				theArcSysLocation.Update();
				if (theArcSysLocation.Location_Type_Cd == "PORT")
					thePort.Update();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		#endregion		// #region Save

		#region Events
		private void ucLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sURL = "http://www.transcom.mil/dteb/files/refdata/V_SEAPORT.htm";
			System.Diagnostics.Process.Start(sURL);
		}

		private void linkCountries_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sURL = "http://www.transcom.mil/dteb/files/refdata/V_CTRY_DOD.htm";
			System.Diagnostics.Process.Start(sURL);
		}
		#endregion

		#region Synchronize Events

		private void txtLocationDsc_TextChanged(object sender, EventArgs e)
		{
			thePort.Port_Nm = theArcSysLocation.Location_Dsc = txtLocationDsc.Text;
		}

		private void txtCensusCd_TextChanged(object sender, EventArgs e)
		{
			thePort.Census_Cd = txtCensusCd.Text;
		}

		private void txtLocationCd_TextChanged(object sender, EventArgs e)
		{
			thePort.Port_Cd = theArcSysLocation.Location_Cd = txtLocationCd.Text;
		}

		private void txtCensusType_TextChanged(object sender, EventArgs e)
		{
			thePort.Census_Type = txtCensusType.Text;
		}

		private void chkDeleted_CheckedChanged(object sender, EventArgs e)
		{
			//if (chkDeleted.Checked)
			//    cbxActive.Checked = false;
			//else
			//    cbxActive.Checked = true;
		}

		private void txtCensusCd_Validated(object sender, EventArgs e)
		{
		}

		#endregion

		private void ucLinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sURL = "http://www.navigationdatacenter.us/db/foreign/ScheduleK/data/Sep32014KCODEQ.txt";
			System.Diagnostics.Process.Start(sURL);
		}

		private void ucLinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sURL = "https://www.census.gov/foreign-trade/schedules/d/dist2.txt";
			System.Diagnostics.Process.Start(sURL);
		}

		private void ucLinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			string sURL = string.Format(@"https://tools.usps.com/go/ZipLookupResultsAction!input.action?resultMode=0&companyName=&address1=&address2=&city={0}&state={1}&urbanCode=&postalCode=&zip=",
					txtCity.Text, txtState.Text);
			System.Diagnostics.Process.Start(sURL);
		}
	}
}