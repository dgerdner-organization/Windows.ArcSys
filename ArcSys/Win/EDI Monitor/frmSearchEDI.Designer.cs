namespace CS2010.ArcSys.Win
{
	partial class frmSearchEDI
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout cmbMapTypes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchEDI));
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbStatusCodes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDetail_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDetail_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDetail_Layout_2 = new Janus.Windows.GridEX.GridEXLayout();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.btnProcess = new CS2010.CommonWinCtrls.ucButton();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.btnSDDC301 = new CS2010.CommonWinCtrls.ucButton();
            this.btnIALBOL = new CS2010.CommonWinCtrls.ucButton();
            this.btnIALITV = new CS2010.CommonWinCtrls.ucButton();
            this.ucButton3 = new CS2010.CommonWinCtrls.ucButton();
            this.ucButton2 = new CS2010.CommonWinCtrls.ucButton();
            this.ucButton1 = new CS2010.CommonWinCtrls.ucButton();
            this.cbxUnprocessed = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cmbMapTypes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbDayPicker = new CS2010.CommonWinCtrls.ucComboBox();
            this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
            this.txtDays = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbStatusCodes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            this.ucGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMapTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.sbrChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            appearance1.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.Appearance = appearance1;
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            appearance2.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.ContentAreaAppearance = appearance2;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(1278, 116);
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance3;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance4;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1278, 116);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.btnProcess);
            this.grpSearchPanel.Controls.Add(this.ucGroupBox1);
            this.grpSearchPanel.Controls.Add(this.cbxUnprocessed);
            this.grpSearchPanel.Controls.Add(this.cmbMapTypes);
            this.grpSearchPanel.Controls.Add(this.cmbDayPicker);
            this.grpSearchPanel.Controls.Add(this.ucLabel1);
            this.grpSearchPanel.Controls.Add(this.txtDays);
            this.grpSearchPanel.Controls.Add(this.cmbPOD);
            this.grpSearchPanel.Controls.Add(this.cmbPOL);
            this.grpSearchPanel.Controls.Add(this.cmbStatusCodes);
            this.grpSearchPanel.Controls.Add(this.txtPCFN);
            this.grpSearchPanel.Controls.Add(this.txtVoyage);
            this.grpSearchPanel.Controls.Add(this.cmbPartner);
            this.grpSearchPanel.Controls.Add(this.txtSerialNo);
            this.grpSearchPanel.Controls.Add(this.txtBookingNo);
            this.grpSearchPanel.Controls.Add(this.btnClear);
            this.grpSearchPanel.Controls.Add(this.btnSearch);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 18);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(1272, 95);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(563, 67);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(106, 23);
            this.btnProcess.TabIndex = 17;
            this.btnProcess.Text = "Archive Selected";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.btnSDDC301);
            this.ucGroupBox1.Controls.Add(this.btnIALBOL);
            this.ucGroupBox1.Controls.Add(this.btnIALITV);
            this.ucGroupBox1.Controls.Add(this.ucButton3);
            this.ucGroupBox1.Controls.Add(this.ucButton2);
            this.ucGroupBox1.Controls.Add(this.ucButton1);
            this.ucGroupBox1.Location = new System.Drawing.Point(928, -2);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(273, 94);
            this.ucGroupBox1.TabIndex = 16;
            this.ucGroupBox1.TabStop = false;
            this.ucGroupBox1.Text = "Quick Query";
            // 
            // btnSDDC301
            // 
            this.btnSDDC301.Location = new System.Drawing.Point(133, 61);
            this.btnSDDC301.Name = "btnSDDC301";
            this.btnSDDC301.Size = new System.Drawing.Size(115, 23);
            this.btnSDDC301.TabIndex = 5;
            this.btnSDDC301.Text = "SDDC 301s";
            this.btnSDDC301.UseVisualStyleBackColor = true;
            this.btnSDDC301.Click += new System.EventHandler(this.btnSDDC301_Click);
            // 
            // btnIALBOL
            // 
            this.btnIALBOL.Location = new System.Drawing.Point(132, 37);
            this.btnIALBOL.Name = "btnIALBOL";
            this.btnIALBOL.Size = new System.Drawing.Size(116, 23);
            this.btnIALBOL.TabIndex = 4;
            this.btnIALBOL.Text = "BOL\'s to IAL";
            this.btnIALBOL.UseVisualStyleBackColor = true;
            this.btnIALBOL.Click += new System.EventHandler(this.btnIALBOL_Click);
            // 
            // btnIALITV
            // 
            this.btnIALITV.Location = new System.Drawing.Point(132, 13);
            this.btnIALITV.Name = "btnIALITV";
            this.btnIALITV.Size = new System.Drawing.Size(116, 23);
            this.btnIALITV.TabIndex = 3;
            this.btnIALITV.Text = "ITV to IAL";
            this.btnIALITV.UseVisualStyleBackColor = true;
            this.btnIALITV.Click += new System.EventHandler(this.btnIALITV_Click);
            // 
            // ucButton3
            // 
            this.ucButton3.Location = new System.Drawing.Point(10, 37);
            this.ucButton3.Name = "ucButton3";
            this.ucButton3.Size = new System.Drawing.Size(116, 23);
            this.ucButton3.TabIndex = 2;
            this.ucButton3.Text = "BOL to WWL";
            this.ucButton3.UseVisualStyleBackColor = true;
            this.ucButton3.Click += new System.EventHandler(this.ucButton3_Click);
            // 
            // ucButton2
            // 
            this.ucButton2.Location = new System.Drawing.Point(10, 61);
            this.ucButton2.Name = "ucButton2";
            this.ucButton2.Size = new System.Drawing.Size(116, 23);
            this.ucButton2.TabIndex = 1;
            this.ucButton2.Text = "Charleston HHG";
            this.ucButton2.UseVisualStyleBackColor = true;
            this.ucButton2.Click += new System.EventHandler(this.ucButton2_Click);
            // 
            // ucButton1
            // 
            this.ucButton1.Location = new System.Drawing.Point(10, 13);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(116, 23);
            this.ucButton1.TabIndex = 0;
            this.ucButton1.Text = "Bookings to WWL";
            this.ucButton1.UseVisualStyleBackColor = true;
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // cbxUnprocessed
            // 
            this.cbxUnprocessed.Location = new System.Drawing.Point(563, 44);
            this.cbxUnprocessed.Name = "cbxUnprocessed";
            this.cbxUnprocessed.Size = new System.Drawing.Size(137, 24);
            this.cbxUnprocessed.TabIndex = 15;
            this.cbxUnprocessed.Text = "Just Unprocessed";
            this.cbxUnprocessed.UseVisualStyleBackColor = true;
            this.cbxUnprocessed.YN = "N";
            this.cbxUnprocessed.CheckStateChanged += new System.EventHandler(this.cbxUnprocessed_CheckStateChanged);
            // 
            // cmbMapTypes
            // 
            cmbMapTypes_DesignTimeLayout.LayoutString = resources.GetString("cmbMapTypes_DesignTimeLayout.LayoutString");
            this.cmbMapTypes.DesignTimeLayout = cmbMapTypes_DesignTimeLayout;
            this.cmbMapTypes.DisplayMember = "map_set";
            this.cmbMapTypes.LabelText = "Map Type";
            this.cmbMapTypes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMapTypes.Location = new System.Drawing.Point(563, 24);
            this.cmbMapTypes.Name = "cmbMapTypes";
            this.cmbMapTypes.SelectedIndex = -1;
            this.cmbMapTypes.SelectedItem = null;
            this.cmbMapTypes.Size = new System.Drawing.Size(64, 20);
            this.cmbMapTypes.TabIndex = 14;
            this.cmbMapTypes.ValueMember = "map_set";
            // 
            // cmbDayPicker
            // 
            this.cmbDayPicker.FormattingEnabled = true;
            this.cmbDayPicker.Items.AddRange(new object[] {
            "1",
            "7",
            "30",
            "360",
            "9999"});
            this.cmbDayPicker.LabelText = "ISA in the last";
            this.cmbDayPicker.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbDayPicker.Location = new System.Drawing.Point(563, 0);
            this.cmbDayPicker.Name = "cmbDayPicker";
            this.cmbDayPicker.Size = new System.Drawing.Size(64, 21);
            this.cmbDayPicker.TabIndex = 13;
            this.cmbDayPicker.SelectedIndexChanged += new System.EventHandler(this.cmbDayPicker_SelectedIndexChanged);
            // 
            // ucLabel1
            // 
            this.ucLabel1.Location = new System.Drawing.Point(627, 4);
            this.ucLabel1.Name = "ucLabel1";
            this.ucLabel1.Size = new System.Drawing.Size(35, 13);
            this.ucLabel1.TabIndex = 12;
            this.ucLabel1.Text = "day(s)";
            // 
            // txtDays
            // 
            this.txtDays.LabelText = "Activity no more than ";
            this.txtDays.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDays.LinkDisabledMessage = "Link Disabled";
            this.txtDays.Location = new System.Drawing.Point(760, 17);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(10, 20);
            this.txtDays.TabIndex = 11;
            this.txtDays.Text = "120";
            this.txtDays.Visible = false;
            // 
            // cmbPOD
            // 
            this.cmbPOD.CodeColumn = "Location_Cd";
            this.cmbPOD.DescriptionColumn = "Location_Dsc";
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DisplayMember = "Location_CdLocation_Dsc";
            this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbPOD.LabelText = "POD";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(279, 70);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(208, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 10;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValueMember = "Location_Cd";
            // 
            // cmbPOL
            // 
            this.cmbPOL.CodeColumn = "Location_Cd";
            this.cmbPOL.DescriptionColumn = "Location_Dsc";
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DisplayMember = "Location_CdLocation_Dsc";
            this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbPOL.LabelText = "POL";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(279, 48);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(208, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 9;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // cmbStatusCodes
            // 
            cmbStatusCodes_DesignTimeLayout.LayoutString = resources.GetString("cmbStatusCodes_DesignTimeLayout.LayoutString");
            this.cmbStatusCodes.DesignTimeLayout = cmbStatusCodes_DesignTimeLayout;
            this.cmbStatusCodes.DisplayMember = "activity_dsc";
            this.cmbStatusCodes.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbStatusCodes.LabelText = "Action Code";
            this.cmbStatusCodes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatusCodes.Location = new System.Drawing.Point(279, 26);
            this.cmbStatusCodes.Name = "cmbStatusCodes";
            this.cmbStatusCodes.SelectedIndex = -1;
            this.cmbStatusCodes.SelectedItem = null;
            this.cmbStatusCodes.Size = new System.Drawing.Size(208, 20);
            this.cmbStatusCodes.TabIndex = 8;
            this.cmbStatusCodes.ValueMember = "activity_cd";
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(54, 69);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(100, 20);
            this.txtPCFN.TabIndex = 3;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(54, 24);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 1;
            // 
            // cmbPartner
            // 
            this.cmbPartner.DescriptionColumn = "partner_dsc";
            cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
            this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
            this.cmbPartner.DisplayMember = "partner_dsc";
            this.cmbPartner.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbPartner.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPartner.LabelText = "Partner";
            this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPartner.Location = new System.Drawing.Point(54, 3);
            this.cmbPartner.Name = "cmbPartner";
            this.cmbPartner.SelectedIndex = -1;
            this.cmbPartner.SelectedItem = null;
            this.cmbPartner.Size = new System.Drawing.Size(179, 20);
            this.cmbPartner.TabIndex = 0;
            this.cmbPartner.ValueColumn = "partner_cd";
            this.cmbPartner.ValueMember = "trading_partner_cd";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerialNo.LabelText = "Serial#";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(279, 4);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(208, 20);
            this.txtSerialNo.TabIndex = 4;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(54, 46);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
            this.txtBookingNo.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnClear.Location = new System.Drawing.Point(841, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(760, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 116);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1278, 591);
            this.tabMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1270, 565);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(3, 3);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grdMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grdDetail);
            this.splitMain.Size = new System.Drawing.Size(1264, 559);
            this.splitMain.SplitterDistance = 215;
            this.splitMain.TabIndex = 0;
            // 
            // grdMain
            // 
            this.grdMain.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdMain.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
            this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
            this.grdMain.DisplayFieldChooser = true;
            this.grdMain.DisplayFieldChooserChildren = true;
            this.grdMain.DisplayFontSelector = true;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.ExportFileID = null;
            this.grdMain.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdMain.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdMain.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdMain.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdMain.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdMain.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdMain.Hierarchical = true;
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.Name = "grdMain";
            this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMain.Size = new System.Drawing.Size(1264, 215);
            this.grdMain.TabIndex = 2;
            this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
            // 
            // grdDetail
            // 
            this.grdDetail.DisplayFieldChooser = true;
            this.grdDetail.DisplayFieldChooserChildren = true;
            this.grdDetail.DisplayFontSelector = true;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.ExportFileID = null;
            this.grdDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            grdDetail_Layout_0.Key = "layout315";
            grdDetail_Layout_0.LayoutString = resources.GetString("grdDetail_Layout_0.LayoutString");
            grdDetail_Layout_1.IsCurrentLayout = true;
            grdDetail_Layout_1.Key = "layoutDefault";
            grdDetail_Layout_1.LayoutString = resources.GetString("grdDetail_Layout_1.LayoutString");
            grdDetail_Layout_2.Key = "layoutCargoDetail";
            grdDetail_Layout_2.LayoutString = resources.GetString("grdDetail_Layout_2.LayoutString");
            this.grdDetail.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grdDetail_Layout_0,
            grdDetail_Layout_1,
            grdDetail_Layout_2});
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdDetail.RowFormatStyle.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.grdDetail.Size = new System.Drawing.Size(1264, 340);
            this.grdDetail.TabIndex = 3;
            this.grdDetail.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdDetail.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDetail_LinkClicked);
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 685);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(1278, 22);
            this.sbrChild.TabIndex = 8;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
            this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tbrMain
            // 
            this.tbrMain.Location = new System.Drawing.Point(0, 116);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(1278, 25);
            this.tbrMain.TabIndex = 9;
            this.tbrMain.Text = "toolStrip1";
            // 
            // frmSearchEDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1278, 707);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpSearch);
            this.Name = "frmSearchEDI";
            this.Text = "Search EDI History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            this.ucGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMapTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private Infragistics.Win.Misc.UltraButton btnClear;
        private Infragistics.Win.Misc.UltraButton btnSearch;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucMultiColumnCombo cmbStatusCodes;
		private WinCtrls.ucLocationCombo cmbPOL;
		private WinCtrls.ucLocationCombo cmbPOD;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucTextBox txtDays;
		private CommonWinCtrls.ucComboBox cmbDayPicker;
		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucGridEx grdDetail;
		private CommonWinCtrls.ucMultiColumnCombo cmbMapTypes;
        private CommonWinCtrls.ucCheckBox cbxUnprocessed;
        private CommonWinCtrls.ucGroupBox ucGroupBox1;
        private CommonWinCtrls.ucButton ucButton1;
        private CommonWinCtrls.ucButton ucButton2;
        private CommonWinCtrls.ucButton ucButton3;
        private CommonWinCtrls.ucButton btnIALBOL;
        private CommonWinCtrls.ucButton btnIALITV;
        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private System.Windows.Forms.ToolStrip tbrMain;
        private CommonWinCtrls.ucButton btnProcess;
        private CommonWinCtrls.ucButton btnSDDC301;
	}
}