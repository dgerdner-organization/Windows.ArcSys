using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.WinCtrls;
using Infragistics.Win.Misc;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditTerminal : Form
	{
		#region Internal Helper Class

		protected class SectionData
		{
			public SectionData(string termSection, UltraExpandableGroupBox gb, ucTextBox tb,
				ucTerminalContactsGrid tcg, ucTerminalLinksGrid tlg)
			{
				Terminal_Section_Cd = termSection;
				GroupBox = gb;
				AddressBox = tb;
				Contacts = tcg;
				Links = tlg;
			}
			public string Terminal_Section_Cd { get; set; }
			public UltraExpandableGroupBox GroupBox { get; set; }
			public ucTextBox AddressBox { get; set; }
			public ucTerminalContactsGrid Contacts { get; set; }
			public ucTerminalLinksGrid Links { get; set; }
			public ClsTerminalAddress theTerminalAddress { get; set; }
			public ClsTerminalAddress theTerminalAddressOrig { get; set; }
		}
		#endregion		// #region Internal Helper Class

		#region Fields/Properties

		protected DialogMode CurrentMode;

		protected ClsTerminal theTerminal;

		protected Dictionary<string, SectionData> Sections;

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry

		public frmEditTerminal()
		{
			InitializeComponent();

			Sections = new Dictionary<string, SectionData>();
			Sections.Add("AGENT", new SectionData("AGENT",
				grpAgent, txtAgentAddr, grdAgentContacts, grdAgentLinks));
			Sections.Add("TERM", new SectionData("TERM",
				grpTerminal, txtTerminalAddr, grdTerminalContacts, grdTerminalLinks));
			Sections.Add("PCAPT", new SectionData("PCAPT",
				grpCapt, txtCaptAddr, grdCaptContacts, grdCaptLinks));
			Sections.Add("STVDR", new SectionData("STVDR",
				grpStvdr, txtStvdrAddr, grdStvdrContacts, grdStvdrLinks));
			Sections.Add("PAUTH", new SectionData("PAUTH",
				grpPortAuth, txtPortAuthAddr, grdPortAuthContacts, grdPortAuthLinks));
			Sections.Add("MARSEC", new SectionData("MARSEC",
				grpMarsec, null, grdMarsecContacts, grdMarsecLinks));
		}

		public bool EditTerminal(ClsTerminal aTerminal)
		{
			try
			{
				CurrentMode = DialogMode.Edit;
				theTerminal = (aTerminal != null) ? new ClsTerminal(aTerminal) : null;
				if (theTerminal == null)
					return Program.ShowError("No terminal provided");
				theTerminal.ReloadFromDB();
				if (ShowDialog() != DialogResult.OK) return false;

				aTerminal.CopyFrom(theTerminal);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		public ClsTerminal AddTerminal()
		{
			try
			{
				CurrentMode = DialogMode.Add;
				theTerminal = new ClsTerminal();
				theTerminal.SetDefaults();

				return (ShowDialog() == DialogResult.OK) ? theTerminal : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void frmEditTerminal_Load(object sender, EventArgs e)
		{
			try
			{
				RefreshData();

				cmbPort.Filter = "Location_Type_Cd = 'PORT'";
				cmbPort.DropDownList.Columns["Location_Type_Cd"].Visible = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RefreshData()
		{
			try
			{
				theTerminal.ReloadFromDB();

				SetupSection("AGENT");
				SetupSection("TERM");
				SetupSection("PCAPT");
				SetupSection("STVDR");
				SetupSection("PAUTH");
				SetupSection("MARSEC");

				BindDetail();

				txtTerminalCd.ReadOnly = (CurrentMode != DialogMode.Add);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void BindDetail()
		{
			try
			{
				BindHelper.Bind(txtTerminalCd, theTerminal, "Terminal_Cd");
				BindHelper.Bind(cmbPort, theTerminal, "Location_Cd");
				BindHelper.Bind(txtTerminalDsc, theTerminal, "Terminal_Dsc");

				BindHelper.Bind(txtExcludedVessels, theTerminal, "Excluded_Vessels");
				BindHelper.Bind(txtMaxDraft, theTerminal, "Max_Draft");
				BindHelper.Bind(txtTidalVar, theTerminal, "Tidal_Variance");
				BindHelper.Bind(txtLockIssues, theTerminal, "Lock_Issues");
				BindHelper.Bind(txtLOA, theTerminal, "LOA");
				BindHelper.Bind(txtBeam, theTerminal, "Beam");
				BindHelper.Bind(txtAirDraft, theTerminal, "Air_Draft");
				BindHelper.Bind(txtPilotTime, theTerminal, "Pilotage_Time");
				BindHelper.Bind(txtBerths, theTerminal, "Berths");
				BindHelper.Bind(txtMaxDraftBerth, theTerminal, "Max_Draft_Berth");
				BindHelper.Bind(rtfNotes, theTerminal, "Notes");

				txtTerminalCd.MaxLength = ClsTerminal.Terminal_CdMax;
				txtTerminalDsc.MaxLength = ClsTerminal.Terminal_DscMax;
				txtExcludedVessels.MaxLength = ClsTerminal.Excluded_VesselsMax;
				txtMaxDraft.MaxLength = ClsTerminal.Max_DraftMax;
				txtTidalVar.MaxLength = ClsTerminal.Tidal_VarianceMax;
				txtLockIssues.MaxLength = ClsTerminal.Lock_IssuesMax;
				txtLOA.MaxLength = ClsTerminal.LoaMax;
				txtBeam.MaxLength = ClsTerminal.BeamMax;
				txtAirDraft.MaxLength = ClsTerminal.Air_DraftMax;
				txtPilotTime.MaxLength = ClsTerminal.Pilotage_TimeMax;
				txtBerths.MaxLength = ClsTerminal.BerthsMax;
				txtMaxDraftBerth.MaxLength = ClsTerminal.Max_Draft_BerthMax;
				rtfNotes.MaxLength = ClsTerminal.NotesMax;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetupSection(string termSection)
		{
			try
			{
				SectionData sd = Sections[termSection];
				sd.Contacts.SetGridSource(theTerminal.Terminal_Cd, termSection);
				sd.Links.SetGridSource(theTerminal.Terminal_Cd, termSection);
				if (sd.AddressBox != null)	// If no address text box, don't bother with the address
				{
					sd.theTerminalAddress =
						ClsTerminalAddress.GetAddress(theTerminal.Terminal_Cd, termSection);
					if (sd.theTerminalAddress == null)
					{
						sd.theTerminalAddress = new ClsTerminalAddress(termSection);
						sd.theTerminalAddress.Terminal_Cd = theTerminal.Terminal_Cd;
					}
					sd.GroupBox.Panel.Tag = sd.theTerminalAddress;
					sd.theTerminalAddressOrig = new ClsTerminalAddress(sd.theTerminalAddress);
					sd.AddressBox.Text = sd.theTerminalAddress.AddressBoxExtra();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Save/Cancel

		private void tbbCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbbSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (CurrentMode == DialogMode.Add)
				{
					if (!theTerminal.ValidateInsert())
					{
						Program.ShowError(theTerminal.Error);
						return;
					}
					theTerminal.Insert();
					CurrentMode = DialogMode.Edit;		// once the insert happens, switch to edit mode
				}
				else if (CurrentMode == DialogMode.Edit)
				{
					if (!theTerminal.ValidateUpdate())
					{
						Program.ShowError(theTerminal.Error);
						return;
					}
					theTerminal.Update();
				}
				else
				{
					Program.ShowError("Invalid mode");
					return;
				}


				StringBuilder sbError = new StringBuilder();
				foreach (SectionData sd in Sections.Values)
				{	// set terminal code here again, because SetupSection wouldn't have had a terminal code when in Add mode
					sd.Contacts.Terminal_Cd = theTerminal.Terminal_Cd;
					sd.Links.Terminal_Cd = theTerminal.Terminal_Cd;
					if (sd.theTerminalAddress != null &&
						!sd.theTerminalAddress.Equals(sd.theTerminalAddressOrig))
					{
						sd.theTerminalAddress.Terminal_Cd = theTerminal.Terminal_Cd;
						if (!sd.theTerminalAddress.SaveAddress())
							sbError.AppendLine(sd.theTerminalAddress.Description).
								AppendLine(sd.theTerminalAddress.Error);
					}
					if (!sd.Contacts.SaveChanges())
						sbError.AppendLine(sd.Contacts.Errors);
					if (!sd.Links.SaveChanges())
						sbError.AppendLine(sd.Links.Errors);
				}
			
				if (sbError.Length > 0)
					Program.Show("Some changes could not be saved\r\n" + sbError.ToString());
				else
				{
					Program.Show("All Changes Saved");
					Close();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Save/Cancel

		#region Actions

		private void txtAddrBox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				ucLinkLabel lnk = sender as ucLinkLabel;
				ClsTerminalAddress addr = lnk.Parent.Tag as ClsTerminalAddress;
				List<ClsTerminalAddress> lst =
					ClsTerminalAddress.GetAddressesBySection(addr.Terminal_Section_Cd);
				using (frmTerminalAddress frm = new frmTerminalAddress())
				{
					if (frm.Edit(addr, lst) == false) return;

					if (addr.ValidateUpdate() == false)
					{
						Program.ShowError(addr.Error);
						return;
					}

					SectionData sd = Sections[addr.Terminal_Section_Cd];
					sd.AddressBox.Text =  addr.AddressBoxExtra();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Actions
	}
}