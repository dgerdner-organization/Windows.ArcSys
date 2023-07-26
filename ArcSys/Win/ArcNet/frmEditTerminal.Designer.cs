namespace CS2010.ArcSys.Win
{
	partial class frmEditTerminal
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout cmbPort_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTerminal));
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			this.infPanelMain = new Infragistics.Win.Misc.UltraPanel();
			this.grpPrimaryKey = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.txtTerminalDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbPort = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
			this.txtTerminalCd = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.grpMarsec = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpMarsecPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdMarsecContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdMarsecLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.grpAgent = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpAgentPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdAgentContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdAgentLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.txtAgentAddr = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpTerminal = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpTerminalPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdTerminalContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdTerminalLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.txtTerminalAddr = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpCapt = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpCaptPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdCaptContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdCaptLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.txtCaptAddr = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpStvdr = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpStvdrPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdStvdrContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdStvdrLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.txtStvdrAddr = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpPortDtls = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpPortDtlsPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.rtfNotes = new CS2010.CommonWinCtrls.ucRichTextBox();
			this.txtMaxDraftBerth = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBerths = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPilotTime = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAirDraft = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBeam = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtLOA = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtLockIssues = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTidalVar = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMaxDraft = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtExcludedVessels = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpPortAuth = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpPortAuthPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grdPortAuthContacts = new CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid();
			this.grdPortAuthLinks = new CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid();
			this.txtPortAuthAddr = new CS2010.CommonWinCtrls.ucTextBox();
			this.infFlowMgr = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
			this.tbrTermMain = new System.Windows.Forms.ToolStrip();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbCancel = new System.Windows.Forms.ToolStripButton();
			this.lblAgentContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.lblAgentLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblTerminalLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblTerminalContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.lblPortAuthLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblPortAuthContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.lblStvdrLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblStvdrContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.lblCaptLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblCaptContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.lblMarsecLinks = new CS2010.CommonWinCtrls.ucLabel();
			this.lblMarsecContacts = new CS2010.CommonWinCtrls.ucLabel();
			this.infPanelMain.ClientArea.SuspendLayout();
			this.infPanelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPrimaryKey)).BeginInit();
			this.grpPrimaryKey.SuspendLayout();
			this.ultraExpandableGroupBoxPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMarsec)).BeginInit();
			this.grpMarsec.SuspendLayout();
			this.grpMarsecPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpAgent)).BeginInit();
			this.grpAgent.SuspendLayout();
			this.grpAgentPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpTerminal)).BeginInit();
			this.grpTerminal.SuspendLayout();
			this.grpTerminalPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpCapt)).BeginInit();
			this.grpCapt.SuspendLayout();
			this.grpCaptPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpStvdr)).BeginInit();
			this.grpStvdr.SuspendLayout();
			this.grpStvdrPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPortDtls)).BeginInit();
			this.grpPortDtls.SuspendLayout();
			this.grpPortDtlsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPortAuth)).BeginInit();
			this.grpPortAuth.SuspendLayout();
			this.grpPortAuthPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infFlowMgr)).BeginInit();
			this.tbrTermMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// infPanelMain
			// 
			this.infPanelMain.AutoScroll = true;
			// 
			// infPanelMain.ClientArea
			// 
			this.infPanelMain.ClientArea.Controls.Add(this.grpPrimaryKey);
			this.infPanelMain.ClientArea.Controls.Add(this.grpMarsec);
			this.infPanelMain.ClientArea.Controls.Add(this.grpAgent);
			this.infPanelMain.ClientArea.Controls.Add(this.grpTerminal);
			this.infPanelMain.ClientArea.Controls.Add(this.grpCapt);
			this.infPanelMain.ClientArea.Controls.Add(this.grpStvdr);
			this.infPanelMain.ClientArea.Controls.Add(this.grpPortDtls);
			this.infPanelMain.ClientArea.Controls.Add(this.grpPortAuth);
			this.infPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infPanelMain.Location = new System.Drawing.Point(0, 25);
			this.infPanelMain.Name = "infPanelMain";
			this.infPanelMain.Size = new System.Drawing.Size(760, 691);
			this.infPanelMain.TabIndex = 0;
			// 
			// grpPrimaryKey
			// 
			this.grpPrimaryKey.Controls.Add(this.ultraExpandableGroupBoxPanel1);
			this.grpPrimaryKey.ExpandedSize = new System.Drawing.Size(736, 60);
			this.grpPrimaryKey.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance5.FontData.BoldAsString = "True";
			appearance5.FontData.Name = "Tahoma";
			appearance5.FontData.SizeInPoints = 10F;
			appearance5.ForeColor = System.Drawing.Color.White;
			this.grpPrimaryKey.HeaderAppearance = appearance5;
			this.grpPrimaryKey.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpPrimaryKey.Location = new System.Drawing.Point(4, 2);
			this.grpPrimaryKey.Name = "grpPrimaryKey";
			this.grpPrimaryKey.Size = new System.Drawing.Size(736, 60);
			this.grpPrimaryKey.TabIndex = 0;
			this.grpPrimaryKey.Text = "Required Information";
			this.grpPrimaryKey.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// ultraExpandableGroupBoxPanel1
			// 
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtTerminalDsc);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPort);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtTerminalCd);
			this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(2, 22);
			this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
			this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(732, 36);
			this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
			// 
			// txtTerminalDsc
			// 
			this.txtTerminalDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTerminalDsc.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtTerminalDsc.LabelText = "Name";
			this.txtTerminalDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTerminalDsc.LinkDisabledMessage = "Link Disabled";
			this.txtTerminalDsc.Location = new System.Drawing.Point(424, 8);
			this.txtTerminalDsc.Name = "txtTerminalDsc";
			this.txtTerminalDsc.Size = new System.Drawing.Size(296, 20);
			this.txtTerminalDsc.TabIndex = 5;
			// 
			// cmbPort
			// 
			this.cmbPort.CodeColumn = "Location_Cd";
			this.cmbPort.DescriptionColumn = "Location_Dsc";
			cmbPort_DesignTimeLayout.LayoutString = resources.GetString("cmbPort_DesignTimeLayout.LayoutString");
			this.cmbPort.DesignTimeLayout = cmbPort_DesignTimeLayout;
			this.cmbPort.DisplayMember = "Location_Dsc";
			this.cmbPort.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPort.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbPort.LabelText = "Port";
			this.cmbPort.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPort.Location = new System.Drawing.Point(212, 8);
			this.cmbPort.Name = "cmbPort";
			this.cmbPort.SelectedIndex = -1;
			this.cmbPort.SelectedItem = null;
			this.cmbPort.Size = new System.Drawing.Size(174, 20);
			this.cmbPort.TabIndex = 3;
			this.cmbPort.ValueColumn = "Location_Cd";
			this.cmbPort.ValueMember = "Location_Cd";
			// 
			// txtTerminalCd
			// 
			this.txtTerminalCd.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtTerminalCd.LabelText = "Terminal Code";
			this.txtTerminalCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTerminalCd.LinkDisabledMessage = "Link Disabled";
			this.txtTerminalCd.Location = new System.Drawing.Point(80, 8);
			this.txtTerminalCd.Name = "txtTerminalCd";
			this.txtTerminalCd.Size = new System.Drawing.Size(100, 20);
			this.txtTerminalCd.TabIndex = 1;
			// 
			// grpMarsec
			// 
			this.grpMarsec.Controls.Add(this.grpMarsecPanel);
			this.grpMarsec.Expanded = false;
			this.grpMarsec.ExpandedSize = new System.Drawing.Size(736, 280);
			this.grpMarsec.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance1.FontData.BoldAsString = "True";
			appearance1.FontData.Name = "Tahoma";
			appearance1.FontData.SizeInPoints = 10F;
			appearance1.ForeColor = System.Drawing.Color.White;
			this.grpMarsec.HeaderAppearance = appearance1;
			this.grpMarsec.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpMarsec.Location = new System.Drawing.Point(4, 64);
			this.grpMarsec.Name = "grpMarsec";
			this.grpMarsec.Size = new System.Drawing.Size(736, 24);
			this.grpMarsec.TabIndex = 1;
			this.grpMarsec.Text = "MARSEC Level";
			this.grpMarsec.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpMarsecPanel
			// 
			this.grpMarsecPanel.Controls.Add(this.lblMarsecLinks);
			this.grpMarsecPanel.Controls.Add(this.lblMarsecContacts);
			this.grpMarsecPanel.Controls.Add(this.grdMarsecContacts);
			this.grpMarsecPanel.Controls.Add(this.grdMarsecLinks);
			this.grpMarsecPanel.Location = new System.Drawing.Point(-10000, -10000);
			this.grpMarsecPanel.Name = "grpMarsecPanel";
			this.grpMarsecPanel.Size = new System.Drawing.Size(827, 150);
			this.grpMarsecPanel.TabIndex = 0;
			this.grpMarsecPanel.Visible = false;
			// 
			// grdMarsecContacts
			// 
			this.grdMarsecContacts.Location = new System.Drawing.Point(52, 8);
			this.grdMarsecContacts.Name = "grdMarsecContacts";
			this.grdMarsecContacts.Size = new System.Drawing.Size(668, 117);
			this.grdMarsecContacts.TabIndex = 6;
			this.grdMarsecContacts.Terminal_Cd = "";
			this.grdMarsecContacts.Terminal_Section_Cd = null;
			// 
			// grdMarsecLinks
			// 
			this.grdMarsecLinks.Location = new System.Drawing.Point(52, 131);
			this.grdMarsecLinks.Name = "grdMarsecLinks";
			this.grdMarsecLinks.Size = new System.Drawing.Size(668, 117);
			this.grdMarsecLinks.TabIndex = 7;
			this.grdMarsecLinks.Terminal_Cd = null;
			this.grdMarsecLinks.Terminal_Section_Cd = null;
			// 
			// grpAgent
			// 
			this.grpAgent.Controls.Add(this.grpAgentPanel);
			this.grpAgent.ExpandedSize = new System.Drawing.Size(736, 344);
			this.grpAgent.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance3.FontData.BoldAsString = "True";
			appearance3.FontData.Name = "Tahoma";
			appearance3.FontData.SizeInPoints = 10F;
			appearance3.ForeColor = System.Drawing.Color.White;
			this.grpAgent.HeaderAppearance = appearance3;
			this.grpAgent.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpAgent.Location = new System.Drawing.Point(4, 90);
			this.grpAgent.Name = "grpAgent";
			this.grpAgent.Size = new System.Drawing.Size(736, 344);
			this.grpAgent.TabIndex = 2;
			this.grpAgent.Text = "AGENT";
			this.grpAgent.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpAgentPanel
			// 
			this.grpAgentPanel.Controls.Add(this.lblAgentLinks);
			this.grpAgentPanel.Controls.Add(this.lblAgentContacts);
			this.grpAgentPanel.Controls.Add(this.grdAgentContacts);
			this.grpAgentPanel.Controls.Add(this.grdAgentLinks);
			this.grpAgentPanel.Controls.Add(this.txtAgentAddr);
			this.grpAgentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpAgentPanel.Location = new System.Drawing.Point(2, 22);
			this.grpAgentPanel.Name = "grpAgentPanel";
			this.grpAgentPanel.Size = new System.Drawing.Size(732, 320);
			this.grpAgentPanel.TabIndex = 0;
			// 
			// grdAgentContacts
			// 
			this.grdAgentContacts.Location = new System.Drawing.Point(52, 74);
			this.grdAgentContacts.Name = "grdAgentContacts";
			this.grdAgentContacts.Size = new System.Drawing.Size(668, 117);
			this.grdAgentContacts.TabIndex = 3;
			this.grdAgentContacts.Terminal_Cd = "";
			this.grdAgentContacts.Terminal_Section_Cd = null;
			// 
			// grdAgentLinks
			// 
			this.grdAgentLinks.Location = new System.Drawing.Point(52, 197);
			this.grdAgentLinks.Name = "grdAgentLinks";
			this.grdAgentLinks.Size = new System.Drawing.Size(668, 117);
			this.grdAgentLinks.TabIndex = 5;
			this.grdAgentLinks.Terminal_Cd = null;
			this.grdAgentLinks.Terminal_Section_Cd = null;
			// 
			// txtAgentAddr
			// 
			this.txtAgentAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAgentAddr.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtAgentAddr.LabelText = "Address";
			this.txtAgentAddr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Link;
			this.txtAgentAddr.LinkDisabledMessage = "Link Disabled";
			this.txtAgentAddr.Location = new System.Drawing.Point(52, 8);
			this.txtAgentAddr.Multiline = true;
			this.txtAgentAddr.Name = "txtAgentAddr";
			this.txtAgentAddr.Size = new System.Drawing.Size(390, 60);
			this.txtAgentAddr.TabIndex = 1;
			this.txtAgentAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtAddrBox_LinkClicked);
			// 
			// grpTerminal
			// 
			this.grpTerminal.Controls.Add(this.grpTerminalPanel);
			this.grpTerminal.ExpandedSize = new System.Drawing.Size(736, 385);
			this.grpTerminal.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance2.FontData.BoldAsString = "True";
			appearance2.FontData.Name = "Tahoma";
			appearance2.FontData.SizeInPoints = 10F;
			appearance2.ForeColor = System.Drawing.Color.White;
			this.grpTerminal.HeaderAppearance = appearance2;
			this.grpTerminal.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpTerminal.Location = new System.Drawing.Point(4, 436);
			this.grpTerminal.Name = "grpTerminal";
			this.grpTerminal.Size = new System.Drawing.Size(736, 385);
			this.grpTerminal.TabIndex = 3;
			this.grpTerminal.Text = "TERMINAL";
			this.grpTerminal.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpTerminalPanel
			// 
			this.grpTerminalPanel.Controls.Add(this.lblTerminalLinks);
			this.grpTerminalPanel.Controls.Add(this.lblTerminalContacts);
			this.grpTerminalPanel.Controls.Add(this.grdTerminalContacts);
			this.grpTerminalPanel.Controls.Add(this.grdTerminalLinks);
			this.grpTerminalPanel.Controls.Add(this.txtTerminalAddr);
			this.grpTerminalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpTerminalPanel.Location = new System.Drawing.Point(2, 22);
			this.grpTerminalPanel.Name = "grpTerminalPanel";
			this.grpTerminalPanel.Size = new System.Drawing.Size(732, 361);
			this.grpTerminalPanel.TabIndex = 0;
			// 
			// grdTerminalContacts
			// 
			this.grdTerminalContacts.Location = new System.Drawing.Point(52, 74);
			this.grdTerminalContacts.Name = "grdTerminalContacts";
			this.grdTerminalContacts.Size = new System.Drawing.Size(668, 117);
			this.grdTerminalContacts.TabIndex = 3;
			this.grdTerminalContacts.Terminal_Cd = "";
			this.grdTerminalContacts.Terminal_Section_Cd = null;
			// 
			// grdTerminalLinks
			// 
			this.grdTerminalLinks.Location = new System.Drawing.Point(52, 197);
			this.grdTerminalLinks.Name = "grdTerminalLinks";
			this.grdTerminalLinks.Size = new System.Drawing.Size(668, 117);
			this.grdTerminalLinks.TabIndex = 5;
			this.grdTerminalLinks.Terminal_Cd = null;
			this.grdTerminalLinks.Terminal_Section_Cd = null;
			// 
			// txtTerminalAddr
			// 
			this.txtTerminalAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTerminalAddr.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtTerminalAddr.LabelText = "Address";
			this.txtTerminalAddr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Link;
			this.txtTerminalAddr.LinkDisabledMessage = "Link Disabled";
			this.txtTerminalAddr.Location = new System.Drawing.Point(52, 8);
			this.txtTerminalAddr.Multiline = true;
			this.txtTerminalAddr.Name = "txtTerminalAddr";
			this.txtTerminalAddr.Size = new System.Drawing.Size(390, 60);
			this.txtTerminalAddr.TabIndex = 1;
			this.txtTerminalAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtAddrBox_LinkClicked);
			// 
			// grpCapt
			// 
			this.grpCapt.Controls.Add(this.grpCaptPanel);
			this.grpCapt.Expanded = false;
			this.grpCapt.ExpandedSize = new System.Drawing.Size(736, 344);
			this.grpCapt.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance15.FontData.BoldAsString = "True";
			appearance15.FontData.Name = "Tahoma";
			appearance15.FontData.SizeInPoints = 10F;
			appearance15.ForeColor = System.Drawing.Color.White;
			this.grpCapt.HeaderAppearance = appearance15;
			this.grpCapt.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpCapt.Location = new System.Drawing.Point(4, 823);
			this.grpCapt.Name = "grpCapt";
			this.grpCapt.Size = new System.Drawing.Size(736, 24);
			this.grpCapt.TabIndex = 4;
			this.grpCapt.Text = "PORT CAPTAIN";
			this.grpCapt.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpCaptPanel
			// 
			this.grpCaptPanel.Controls.Add(this.lblCaptLinks);
			this.grpCaptPanel.Controls.Add(this.lblCaptContacts);
			this.grpCaptPanel.Controls.Add(this.grdCaptContacts);
			this.grpCaptPanel.Controls.Add(this.grdCaptLinks);
			this.grpCaptPanel.Controls.Add(this.txtCaptAddr);
			this.grpCaptPanel.Location = new System.Drawing.Point(-10000, -10000);
			this.grpCaptPanel.Name = "grpCaptPanel";
			this.grpCaptPanel.Size = new System.Drawing.Size(732, 320);
			this.grpCaptPanel.TabIndex = 0;
			this.grpCaptPanel.Visible = false;
			// 
			// grdCaptContacts
			// 
			this.grdCaptContacts.Location = new System.Drawing.Point(52, 74);
			this.grdCaptContacts.Name = "grdCaptContacts";
			this.grdCaptContacts.Size = new System.Drawing.Size(668, 117);
			this.grdCaptContacts.TabIndex = 3;
			this.grdCaptContacts.Terminal_Cd = "";
			this.grdCaptContacts.Terminal_Section_Cd = null;
			// 
			// grdCaptLinks
			// 
			this.grdCaptLinks.Location = new System.Drawing.Point(52, 197);
			this.grdCaptLinks.Name = "grdCaptLinks";
			this.grdCaptLinks.Size = new System.Drawing.Size(668, 117);
			this.grdCaptLinks.TabIndex = 5;
			this.grdCaptLinks.Terminal_Cd = null;
			this.grdCaptLinks.Terminal_Section_Cd = null;
			// 
			// txtCaptAddr
			// 
			this.txtCaptAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtCaptAddr.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtCaptAddr.LabelText = "Address";
			this.txtCaptAddr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Link;
			this.txtCaptAddr.LinkDisabledMessage = "Link Disabled";
			this.txtCaptAddr.Location = new System.Drawing.Point(52, 8);
			this.txtCaptAddr.Multiline = true;
			this.txtCaptAddr.Name = "txtCaptAddr";
			this.txtCaptAddr.Size = new System.Drawing.Size(390, 60);
			this.txtCaptAddr.TabIndex = 1;
			this.txtCaptAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtAddrBox_LinkClicked);
			// 
			// grpStvdr
			// 
			this.grpStvdr.Controls.Add(this.grpStvdrPanel);
			this.grpStvdr.Expanded = false;
			this.grpStvdr.ExpandedSize = new System.Drawing.Size(736, 344);
			this.grpStvdr.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance4.FontData.BoldAsString = "True";
			appearance4.FontData.Name = "Tahoma";
			appearance4.FontData.SizeInPoints = 10F;
			appearance4.ForeColor = System.Drawing.Color.White;
			this.grpStvdr.HeaderAppearance = appearance4;
			this.grpStvdr.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpStvdr.Location = new System.Drawing.Point(4, 849);
			this.grpStvdr.Name = "grpStvdr";
			this.grpStvdr.Size = new System.Drawing.Size(736, 24);
			this.grpStvdr.TabIndex = 5;
			this.grpStvdr.Text = "STEVEDORE";
			this.grpStvdr.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpStvdrPanel
			// 
			this.grpStvdrPanel.Controls.Add(this.lblStvdrLinks);
			this.grpStvdrPanel.Controls.Add(this.lblStvdrContacts);
			this.grpStvdrPanel.Controls.Add(this.grdStvdrContacts);
			this.grpStvdrPanel.Controls.Add(this.grdStvdrLinks);
			this.grpStvdrPanel.Controls.Add(this.txtStvdrAddr);
			this.grpStvdrPanel.Location = new System.Drawing.Point(-10000, -10000);
			this.grpStvdrPanel.Name = "grpStvdrPanel";
			this.grpStvdrPanel.Size = new System.Drawing.Size(732, 320);
			this.grpStvdrPanel.TabIndex = 0;
			this.grpStvdrPanel.Visible = false;
			// 
			// grdStvdrContacts
			// 
			this.grdStvdrContacts.Location = new System.Drawing.Point(52, 74);
			this.grdStvdrContacts.Name = "grdStvdrContacts";
			this.grdStvdrContacts.Size = new System.Drawing.Size(668, 117);
			this.grdStvdrContacts.TabIndex = 7;
			this.grdStvdrContacts.Terminal_Cd = "";
			this.grdStvdrContacts.Terminal_Section_Cd = null;
			// 
			// grdStvdrLinks
			// 
			this.grdStvdrLinks.Location = new System.Drawing.Point(52, 197);
			this.grdStvdrLinks.Name = "grdStvdrLinks";
			this.grdStvdrLinks.Size = new System.Drawing.Size(668, 117);
			this.grdStvdrLinks.TabIndex = 8;
			this.grdStvdrLinks.Terminal_Cd = null;
			this.grdStvdrLinks.Terminal_Section_Cd = null;
			// 
			// txtStvdrAddr
			// 
			this.txtStvdrAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtStvdrAddr.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtStvdrAddr.LabelText = "Address";
			this.txtStvdrAddr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Link;
			this.txtStvdrAddr.LinkDisabledMessage = "Link Disabled";
			this.txtStvdrAddr.Location = new System.Drawing.Point(52, 8);
			this.txtStvdrAddr.Multiline = true;
			this.txtStvdrAddr.Name = "txtStvdrAddr";
			this.txtStvdrAddr.Size = new System.Drawing.Size(390, 60);
			this.txtStvdrAddr.TabIndex = 6;
			this.txtStvdrAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtAddrBox_LinkClicked);
			// 
			// grpPortDtls
			// 
			this.grpPortDtls.Controls.Add(this.grpPortDtlsPanel);
			this.grpPortDtls.Expanded = false;
			this.grpPortDtls.ExpandedSize = new System.Drawing.Size(736, 280);
			this.grpPortDtls.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance16.FontData.BoldAsString = "True";
			appearance16.FontData.Name = "Tahoma";
			appearance16.FontData.SizeInPoints = 10F;
			appearance16.ForeColor = System.Drawing.Color.White;
			this.grpPortDtls.HeaderAppearance = appearance16;
			this.grpPortDtls.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpPortDtls.Location = new System.Drawing.Point(4, 875);
			this.grpPortDtls.Name = "grpPortDtls";
			this.grpPortDtls.Size = new System.Drawing.Size(736, 24);
			this.grpPortDtls.TabIndex = 6;
			this.grpPortDtls.Text = "PORT DETAILS";
			this.grpPortDtls.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpPortDtlsPanel
			// 
			this.grpPortDtlsPanel.Controls.Add(this.rtfNotes);
			this.grpPortDtlsPanel.Controls.Add(this.txtMaxDraftBerth);
			this.grpPortDtlsPanel.Controls.Add(this.txtBerths);
			this.grpPortDtlsPanel.Controls.Add(this.txtPilotTime);
			this.grpPortDtlsPanel.Controls.Add(this.txtAirDraft);
			this.grpPortDtlsPanel.Controls.Add(this.txtBeam);
			this.grpPortDtlsPanel.Controls.Add(this.txtLOA);
			this.grpPortDtlsPanel.Controls.Add(this.txtLockIssues);
			this.grpPortDtlsPanel.Controls.Add(this.txtTidalVar);
			this.grpPortDtlsPanel.Controls.Add(this.txtMaxDraft);
			this.grpPortDtlsPanel.Controls.Add(this.txtExcludedVessels);
			this.grpPortDtlsPanel.Location = new System.Drawing.Point(-10000, -10000);
			this.grpPortDtlsPanel.Name = "grpPortDtlsPanel";
			this.grpPortDtlsPanel.Size = new System.Drawing.Size(732, 256);
			this.grpPortDtlsPanel.TabIndex = 0;
			this.grpPortDtlsPanel.Visible = false;
			// 
			// rtfNotes
			// 
			this.rtfNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtfNotes.LabelText = "Notes";
			this.rtfNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.rtfNotes.Location = new System.Drawing.Point(122, 204);
			this.rtfNotes.Name = "rtfNotes";
			this.rtfNotes.Size = new System.Drawing.Size(572, 36);
			this.rtfNotes.TabIndex = 21;
			this.rtfNotes.Text = "";
			// 
			// txtMaxDraftBerth
			// 
			this.txtMaxDraftBerth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtMaxDraftBerth.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtMaxDraftBerth.LabelText = "Max Draft - Berth";
			this.txtMaxDraftBerth.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMaxDraftBerth.LinkDisabledMessage = "Link Disabled";
			this.txtMaxDraftBerth.Location = new System.Drawing.Point(122, 184);
			this.txtMaxDraftBerth.Name = "txtMaxDraftBerth";
			this.txtMaxDraftBerth.Size = new System.Drawing.Size(572, 20);
			this.txtMaxDraftBerth.TabIndex = 19;
			// 
			// txtBerths
			// 
			this.txtBerths.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtBerths.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtBerths.LabelText = "Berths";
			this.txtBerths.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBerths.LinkDisabledMessage = "Link Disabled";
			this.txtBerths.Location = new System.Drawing.Point(122, 164);
			this.txtBerths.Name = "txtBerths";
			this.txtBerths.Size = new System.Drawing.Size(572, 20);
			this.txtBerths.TabIndex = 17;
			// 
			// txtPilotTime
			// 
			this.txtPilotTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtPilotTime.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtPilotTime.LabelText = "Pilotage Time";
			this.txtPilotTime.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPilotTime.LinkDisabledMessage = "Link Disabled";
			this.txtPilotTime.Location = new System.Drawing.Point(122, 144);
			this.txtPilotTime.Name = "txtPilotTime";
			this.txtPilotTime.Size = new System.Drawing.Size(572, 20);
			this.txtPilotTime.TabIndex = 15;
			// 
			// txtAirDraft
			// 
			this.txtAirDraft.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAirDraft.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtAirDraft.LabelText = "Air Draft";
			this.txtAirDraft.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAirDraft.LinkDisabledMessage = "Link Disabled";
			this.txtAirDraft.Location = new System.Drawing.Point(122, 124);
			this.txtAirDraft.Name = "txtAirDraft";
			this.txtAirDraft.Size = new System.Drawing.Size(572, 20);
			this.txtAirDraft.TabIndex = 13;
			// 
			// txtBeam
			// 
			this.txtBeam.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtBeam.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtBeam.LabelText = "Beam";
			this.txtBeam.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBeam.LinkDisabledMessage = "Link Disabled";
			this.txtBeam.Location = new System.Drawing.Point(122, 104);
			this.txtBeam.Name = "txtBeam";
			this.txtBeam.Size = new System.Drawing.Size(572, 20);
			this.txtBeam.TabIndex = 11;
			// 
			// txtLOA
			// 
			this.txtLOA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtLOA.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtLOA.LabelText = "LOA";
			this.txtLOA.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLOA.LinkDisabledMessage = "Link Disabled";
			this.txtLOA.Location = new System.Drawing.Point(122, 84);
			this.txtLOA.Name = "txtLOA";
			this.txtLOA.Size = new System.Drawing.Size(572, 20);
			this.txtLOA.TabIndex = 9;
			// 
			// txtLockIssues
			// 
			this.txtLockIssues.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtLockIssues.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtLockIssues.LabelText = "Lock Issues";
			this.txtLockIssues.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLockIssues.LinkDisabledMessage = "Link Disabled";
			this.txtLockIssues.Location = new System.Drawing.Point(122, 64);
			this.txtLockIssues.Name = "txtLockIssues";
			this.txtLockIssues.Size = new System.Drawing.Size(572, 20);
			this.txtLockIssues.TabIndex = 7;
			// 
			// txtTidalVar
			// 
			this.txtTidalVar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTidalVar.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtTidalVar.LabelText = "Tidal Variance";
			this.txtTidalVar.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTidalVar.LinkDisabledMessage = "Link Disabled";
			this.txtTidalVar.Location = new System.Drawing.Point(122, 44);
			this.txtTidalVar.Name = "txtTidalVar";
			this.txtTidalVar.Size = new System.Drawing.Size(572, 20);
			this.txtTidalVar.TabIndex = 5;
			// 
			// txtMaxDraft
			// 
			this.txtMaxDraft.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtMaxDraft.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtMaxDraft.LabelText = "Max Draft";
			this.txtMaxDraft.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMaxDraft.LinkDisabledMessage = "Link Disabled";
			this.txtMaxDraft.Location = new System.Drawing.Point(122, 24);
			this.txtMaxDraft.Name = "txtMaxDraft";
			this.txtMaxDraft.Size = new System.Drawing.Size(572, 20);
			this.txtMaxDraft.TabIndex = 3;
			// 
			// txtExcludedVessels
			// 
			this.txtExcludedVessels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtExcludedVessels.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtExcludedVessels.LabelText = "ARC Vessels Excluded";
			this.txtExcludedVessels.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtExcludedVessels.LinkDisabledMessage = "Link Disabled";
			this.txtExcludedVessels.Location = new System.Drawing.Point(122, 4);
			this.txtExcludedVessels.Name = "txtExcludedVessels";
			this.txtExcludedVessels.Size = new System.Drawing.Size(572, 20);
			this.txtExcludedVessels.TabIndex = 1;
			// 
			// grpPortAuth
			// 
			this.grpPortAuth.Controls.Add(this.grpPortAuthPanel);
			this.grpPortAuth.Expanded = false;
			this.grpPortAuth.ExpandedSize = new System.Drawing.Size(736, 344);
			this.grpPortAuth.ExpansionIndicator = Infragistics.Win.Misc.GroupBoxExpansionIndicator.Far;
			appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(64)))), ((int)(((byte)(97)))));
			appearance17.FontData.BoldAsString = "True";
			appearance17.FontData.Name = "Tahoma";
			appearance17.FontData.SizeInPoints = 10F;
			appearance17.ForeColor = System.Drawing.Color.White;
			this.grpPortAuth.HeaderAppearance = appearance17;
			this.grpPortAuth.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			this.grpPortAuth.Location = new System.Drawing.Point(4, 901);
			this.grpPortAuth.Name = "grpPortAuth";
			this.grpPortAuth.Size = new System.Drawing.Size(736, 24);
			this.grpPortAuth.TabIndex = 7;
			this.grpPortAuth.Text = "PORT AUTHORITY";
			this.grpPortAuth.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003;
			// 
			// grpPortAuthPanel
			// 
			this.grpPortAuthPanel.Controls.Add(this.lblPortAuthLinks);
			this.grpPortAuthPanel.Controls.Add(this.lblPortAuthContacts);
			this.grpPortAuthPanel.Controls.Add(this.grdPortAuthContacts);
			this.grpPortAuthPanel.Controls.Add(this.grdPortAuthLinks);
			this.grpPortAuthPanel.Controls.Add(this.txtPortAuthAddr);
			this.grpPortAuthPanel.Location = new System.Drawing.Point(-10000, -10000);
			this.grpPortAuthPanel.Name = "grpPortAuthPanel";
			this.grpPortAuthPanel.Size = new System.Drawing.Size(732, 320);
			this.grpPortAuthPanel.TabIndex = 0;
			this.grpPortAuthPanel.Visible = false;
			// 
			// grdPortAuthContacts
			// 
			this.grdPortAuthContacts.Location = new System.Drawing.Point(52, 74);
			this.grdPortAuthContacts.Name = "grdPortAuthContacts";
			this.grdPortAuthContacts.Size = new System.Drawing.Size(668, 117);
			this.grdPortAuthContacts.TabIndex = 3;
			this.grdPortAuthContacts.Terminal_Cd = "";
			this.grdPortAuthContacts.Terminal_Section_Cd = null;
			// 
			// grdPortAuthLinks
			// 
			this.grdPortAuthLinks.Location = new System.Drawing.Point(52, 197);
			this.grdPortAuthLinks.Name = "grdPortAuthLinks";
			this.grdPortAuthLinks.Size = new System.Drawing.Size(668, 117);
			this.grdPortAuthLinks.TabIndex = 5;
			this.grdPortAuthLinks.Terminal_Cd = null;
			this.grdPortAuthLinks.Terminal_Section_Cd = null;
			// 
			// txtPortAuthAddr
			// 
			this.txtPortAuthAddr.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtPortAuthAddr.LabelText = "Address";
			this.txtPortAuthAddr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Link;
			this.txtPortAuthAddr.LinkDisabledMessage = "Link Disabled";
			this.txtPortAuthAddr.Location = new System.Drawing.Point(52, 8);
			this.txtPortAuthAddr.Multiline = true;
			this.txtPortAuthAddr.Name = "txtPortAuthAddr";
			this.txtPortAuthAddr.Size = new System.Drawing.Size(390, 60);
			this.txtPortAuthAddr.TabIndex = 1;
			this.txtPortAuthAddr.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtAddrBox_LinkClicked);
			// 
			// infFlowMgr
			// 
			this.infFlowMgr.ContainerControl = this.infPanelMain.ClientArea;
			this.infFlowMgr.HorizontalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Center;
			this.infFlowMgr.HorizontalGap = 2;
			this.infFlowMgr.Margins.Left = 2;
			this.infFlowMgr.Margins.Right = 2;
			this.infFlowMgr.VerticalAlignment = Infragistics.Win.Layout.DefaultableFlowLayoutAlignment.Center;
			this.infFlowMgr.VerticalGap = 2;
			// 
			// tbrTermMain
			// 
			this.tbrTermMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSave,
            this.tbbN1,
            this.tbbCancel});
			this.tbrTermMain.Location = new System.Drawing.Point(0, 0);
			this.tbrTermMain.Name = "tbrTermMain";
			this.tbrTermMain.Size = new System.Drawing.Size(760, 25);
			this.tbrTermMain.TabIndex = 40;
			this.tbrTermMain.Text = "Edit Terminal Toolbar";
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(35, 22);
			this.tbbSave.Text = "&Save";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbCancel
			// 
			this.tbbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCancel.Name = "tbbCancel";
			this.tbbCancel.Size = new System.Drawing.Size(43, 22);
			this.tbbCancel.Text = "Cancel";
			this.tbbCancel.Click += new System.EventHandler(this.tbbCancel_Click);
			// 
			// lblAgentContacts
			// 
			this.lblAgentContacts.Location = new System.Drawing.Point(2, 77);
			this.lblAgentContacts.Name = "lblAgentContacts";
			this.lblAgentContacts.Size = new System.Drawing.Size(49, 13);
			this.lblAgentContacts.TabIndex = 6;
			this.lblAgentContacts.Text = "Contacts";
			// 
			// lblAgentLinks
			// 
			this.lblAgentLinks.Location = new System.Drawing.Point(19, 201);
			this.lblAgentLinks.Name = "lblAgentLinks";
			this.lblAgentLinks.Size = new System.Drawing.Size(32, 13);
			this.lblAgentLinks.TabIndex = 7;
			this.lblAgentLinks.Text = "Links";
			// 
			// lblTerminalLinks
			// 
			this.lblTerminalLinks.Location = new System.Drawing.Point(19, 201);
			this.lblTerminalLinks.Name = "lblTerminalLinks";
			this.lblTerminalLinks.Size = new System.Drawing.Size(32, 13);
			this.lblTerminalLinks.TabIndex = 9;
			this.lblTerminalLinks.Text = "Links";
			// 
			// lblTerminalContacts
			// 
			this.lblTerminalContacts.Location = new System.Drawing.Point(2, 77);
			this.lblTerminalContacts.Name = "lblTerminalContacts";
			this.lblTerminalContacts.Size = new System.Drawing.Size(49, 13);
			this.lblTerminalContacts.TabIndex = 8;
			this.lblTerminalContacts.Text = "Contacts";
			// 
			// lblPortAuthLinks
			// 
			this.lblPortAuthLinks.Location = new System.Drawing.Point(19, 201);
			this.lblPortAuthLinks.Name = "lblPortAuthLinks";
			this.lblPortAuthLinks.Size = new System.Drawing.Size(32, 13);
			this.lblPortAuthLinks.TabIndex = 9;
			this.lblPortAuthLinks.Text = "Links";
			// 
			// lblPortAuthContacts
			// 
			this.lblPortAuthContacts.Location = new System.Drawing.Point(2, 77);
			this.lblPortAuthContacts.Name = "lblPortAuthContacts";
			this.lblPortAuthContacts.Size = new System.Drawing.Size(49, 13);
			this.lblPortAuthContacts.TabIndex = 8;
			this.lblPortAuthContacts.Text = "Contacts";
			// 
			// lblStvdrLinks
			// 
			this.lblStvdrLinks.Location = new System.Drawing.Point(19, 201);
			this.lblStvdrLinks.Name = "lblStvdrLinks";
			this.lblStvdrLinks.Size = new System.Drawing.Size(32, 13);
			this.lblStvdrLinks.TabIndex = 10;
			this.lblStvdrLinks.Text = "Links";
			// 
			// lblStvdrContacts
			// 
			this.lblStvdrContacts.Location = new System.Drawing.Point(2, 77);
			this.lblStvdrContacts.Name = "lblStvdrContacts";
			this.lblStvdrContacts.Size = new System.Drawing.Size(49, 13);
			this.lblStvdrContacts.TabIndex = 9;
			this.lblStvdrContacts.Text = "Contacts";
			// 
			// lblCaptLinks
			// 
			this.lblCaptLinks.Location = new System.Drawing.Point(19, 201);
			this.lblCaptLinks.Name = "lblCaptLinks";
			this.lblCaptLinks.Size = new System.Drawing.Size(32, 13);
			this.lblCaptLinks.TabIndex = 9;
			this.lblCaptLinks.Text = "Links";
			// 
			// lblCaptContacts
			// 
			this.lblCaptContacts.Location = new System.Drawing.Point(2, 77);
			this.lblCaptContacts.Name = "lblCaptContacts";
			this.lblCaptContacts.Size = new System.Drawing.Size(49, 13);
			this.lblCaptContacts.TabIndex = 8;
			this.lblCaptContacts.Text = "Contacts";
			// 
			// lblMarsecLinks
			// 
			this.lblMarsecLinks.Location = new System.Drawing.Point(19, 135);
			this.lblMarsecLinks.Name = "lblMarsecLinks";
			this.lblMarsecLinks.Size = new System.Drawing.Size(32, 13);
			this.lblMarsecLinks.TabIndex = 9;
			this.lblMarsecLinks.Text = "Links";
			// 
			// lblMarsecContacts
			// 
			this.lblMarsecContacts.Location = new System.Drawing.Point(2, 11);
			this.lblMarsecContacts.Name = "lblMarsecContacts";
			this.lblMarsecContacts.Size = new System.Drawing.Size(49, 13);
			this.lblMarsecContacts.TabIndex = 8;
			this.lblMarsecContacts.Text = "Contacts";
			// 
			// frmEditTerminal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(760, 716);
			this.Controls.Add(this.infPanelMain);
			this.Controls.Add(this.tbrTermMain);
			this.Name = "frmEditTerminal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Terminal Information";
			this.Load += new System.EventHandler(this.frmEditTerminal_Load);
			this.infPanelMain.ClientArea.ResumeLayout(false);
			this.infPanelMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grpPrimaryKey)).EndInit();
			this.grpPrimaryKey.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpMarsec)).EndInit();
			this.grpMarsec.ResumeLayout(false);
			this.grpMarsecPanel.ResumeLayout(false);
			this.grpMarsecPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpAgent)).EndInit();
			this.grpAgent.ResumeLayout(false);
			this.grpAgentPanel.ResumeLayout(false);
			this.grpAgentPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpTerminal)).EndInit();
			this.grpTerminal.ResumeLayout(false);
			this.grpTerminalPanel.ResumeLayout(false);
			this.grpTerminalPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpCapt)).EndInit();
			this.grpCapt.ResumeLayout(false);
			this.grpCaptPanel.ResumeLayout(false);
			this.grpCaptPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpStvdr)).EndInit();
			this.grpStvdr.ResumeLayout(false);
			this.grpStvdrPanel.ResumeLayout(false);
			this.grpStvdrPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPortDtls)).EndInit();
			this.grpPortDtls.ResumeLayout(false);
			this.grpPortDtlsPanel.ResumeLayout(false);
			this.grpPortDtlsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpPortAuth)).EndInit();
			this.grpPortAuth.ResumeLayout(false);
			this.grpPortAuthPanel.ResumeLayout(false);
			this.grpPortAuthPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.infFlowMgr)).EndInit();
			this.tbrTermMain.ResumeLayout(false);
			this.tbrTermMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Infragistics.Win.Misc.UltraPanel infPanelMain;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpMarsec;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpMarsecPanel;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpAgent;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpAgentPanel;
		private CS2010.CommonWinCtrls.ucTextBox txtAgentAddr;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdAgentLinks;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdAgentContacts;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpTerminal;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpTerminalPanel;
		private Infragistics.Win.Misc.UltraFlowLayoutManager infFlowMgr;
		private System.Windows.Forms.ToolStrip tbrTermMain;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.ToolStripButton tbbCancel;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpCapt;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpCaptPanel;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdCaptContacts;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdCaptLinks;
		private CS2010.CommonWinCtrls.ucTextBox txtCaptAddr;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdTerminalContacts;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdTerminalLinks;
		private CS2010.CommonWinCtrls.ucTextBox txtTerminalAddr;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpStvdr;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpStvdrPanel;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdStvdrContacts;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdStvdrLinks;
		private CS2010.CommonWinCtrls.ucTextBox txtStvdrAddr;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpPortDtls;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpPortDtlsPanel;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpPortAuth;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpPortAuthPanel;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdPortAuthContacts;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdPortAuthLinks;
		private CS2010.CommonWinCtrls.ucTextBox txtPortAuthAddr;
		private CS2010.CommonWinCtrls.ucTextBox txtMaxDraftBerth;
		private CS2010.CommonWinCtrls.ucTextBox txtBerths;
		private CS2010.CommonWinCtrls.ucTextBox txtPilotTime;
		private CS2010.CommonWinCtrls.ucTextBox txtAirDraft;
		private CS2010.CommonWinCtrls.ucTextBox txtBeam;
		private CS2010.CommonWinCtrls.ucTextBox txtLOA;
		private CS2010.CommonWinCtrls.ucTextBox txtLockIssues;
		private CS2010.CommonWinCtrls.ucTextBox txtTidalVar;
		private CS2010.CommonWinCtrls.ucTextBox txtMaxDraft;
		private CS2010.CommonWinCtrls.ucTextBox txtExcludedVessels;
		private CS2010.CommonWinCtrls.ucRichTextBox rtfNotes;
		private CS2010.ArcSys.WinCtrls.ucTerminalContactsGrid grdMarsecContacts;
		private CS2010.ArcSys.WinCtrls.ucTerminalLinksGrid grdMarsecLinks;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpPrimaryKey;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
		private CommonWinCtrls.ucTextBox txtTerminalDsc;
		private WinCtrls.ucLocationCombo cmbPort;
		private CommonWinCtrls.ucTextBoxPK txtTerminalCd;
		private CommonWinCtrls.ucLabel lblAgentLinks;
		private CommonWinCtrls.ucLabel lblAgentContacts;
		private CommonWinCtrls.ucLabel lblTerminalLinks;
		private CommonWinCtrls.ucLabel lblTerminalContacts;
		private CommonWinCtrls.ucLabel lblStvdrLinks;
		private CommonWinCtrls.ucLabel lblStvdrContacts;
		private CommonWinCtrls.ucLabel lblPortAuthLinks;
		private CommonWinCtrls.ucLabel lblPortAuthContacts;
		private CommonWinCtrls.ucLabel lblCaptLinks;
		private CommonWinCtrls.ucLabel lblCaptContacts;
		private CommonWinCtrls.ucLabel lblMarsecLinks;
		private CommonWinCtrls.ucLabel lblMarsecContacts;
	}
}