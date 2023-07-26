namespace ASL.ARC.EDITools
{
	partial class frmSearchBookingRequests
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
			if( disposing && (components != null) )
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
            Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchBookingRequests));
            Janus.Windows.GridEX.GridEXLayout cmbPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbMMYY_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbTerms_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCancels_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tpList = new System.Windows.Forms.TabPage();
            this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnUnprocessedSearch = new CS2010.CommonWinCtrls.ucButton();
            this.btnCallAPI = new CS2010.CommonWinCtrls.ucButton();
            this.grpBooked = new CS2010.CommonWinCtrls.ucGroupBox();
            this.cbxMissedRdd = new CS2010.CommonWinCtrls.ucCheckBox();
            this.txtVoyDoc = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCombo();
            this.cbxBooked = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cbxStena = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpDays = new CS2010.CommonWinCtrls.ucGroupBox();
            this.sailDtRange = new CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy();
            this.reqDateRange = new CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy();
            this.txtDays = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbMMYY = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.rbToday = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rb30 = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbAll = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rb180 = new CS2010.CommonWinCtrls.ucRadioButton();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.cmbTerms = new CS2010.CommonWinCtrls.ucCheckedComboBox();
            this.cmbStatus = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxUnprocessed = new CS2010.CommonWinCtrls.ucCheckBox();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdCancels = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdList = new CS2010.CommonWinCtrls.ucGridEx();
            this.pnlCommands = new CS2010.CommonWinCtrls.ucPanel();
            this.btnPATLOB = new CS2010.CommonWinCtrls.ucButton();
            this.btnResend304 = new CS2010.CommonWinCtrls.ucButton();
            this.btnLoadList = new CS2010.CommonWinCtrls.ucButton();
            this.btnTenPlusTwo = new CS2010.CommonWinCtrls.ucButton();
            this.btnUntransmitted = new CS2010.CommonWinCtrls.ucButton();
            this.btnRetransmit301 = new CS2010.CommonWinCtrls.ucButton();
            this.btnConfirm = new CS2010.CommonWinCtrls.ucButton();
            this.btnRetransmit = new CS2010.CommonWinCtrls.ucButton();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.tpMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
            this.ucSplitContainer1.Panel1.SuspendLayout();
            this.ucSplitContainer1.Panel2.SuspendLayout();
            this.ucSplitContainer1.SuspendLayout();
            this.grpBooked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            this.grpDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMMYY)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.pnlCommands.SuspendLayout();
            this.sbrChild.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpList
            // 
            this.tpList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpList.Controls.Add(this.ucSplitContainer1);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(1133, 673);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "List";
            // 
            // ucSplitContainer1
            // 
            this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ucSplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.ucSplitContainer1.Name = "ucSplitContainer1";
            this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer1.Panel1
            // 
            this.ucSplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnUnprocessedSearch);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnCallAPI);
            this.ucSplitContainer1.Panel1.Controls.Add(this.grpBooked);
            this.ucSplitContainer1.Panel1.Controls.Add(this.grpDays);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnClear);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.ucSplitContainer1.Panel1.Controls.Add(this.grpMain);
            // 
            // ucSplitContainer1.Panel2
            // 
            this.ucSplitContainer1.Panel2.Controls.Add(this.grdCancels);
            this.ucSplitContainer1.Panel2.Controls.Add(this.grdList);
            this.ucSplitContainer1.Panel2.Controls.Add(this.pnlCommands);
            this.ucSplitContainer1.Size = new System.Drawing.Size(1127, 667);
            this.ucSplitContainer1.SplitterDistance = 182;
            this.ucSplitContainer1.TabIndex = 1;
            // 
            // btnUnprocessedSearch
            // 
            this.btnUnprocessedSearch.Location = new System.Drawing.Point(919, 36);
            this.btnUnprocessedSearch.Name = "btnUnprocessedSearch";
            this.btnUnprocessedSearch.Size = new System.Drawing.Size(120, 23);
            this.btnUnprocessedSearch.TabIndex = 27;
            this.btnUnprocessedSearch.Text = "Unprocessed Search";
            this.btnUnprocessedSearch.UseVisualStyleBackColor = true;
            this.btnUnprocessedSearch.Click += new System.EventHandler(this.btnUnprocessedSearch_Click);
            // 
            // btnCallAPI
            // 
            this.btnCallAPI.Location = new System.Drawing.Point(919, 10);
            this.btnCallAPI.Name = "btnCallAPI";
            this.btnCallAPI.Size = new System.Drawing.Size(75, 23);
            this.btnCallAPI.TabIndex = 26;
            this.btnCallAPI.Text = "ucButton1";
            this.btnCallAPI.UseVisualStyleBackColor = true;
            this.btnCallAPI.Visible = false;
            this.btnCallAPI.Click += new System.EventHandler(this.btnCallAPI_Click);
            // 
            // grpBooked
            // 
            this.grpBooked.Controls.Add(this.cbxMissedRdd);
            this.grpBooked.Controls.Add(this.txtVoyDoc);
            this.grpBooked.Controls.Add(this.cmbPLOD);
            this.grpBooked.Controls.Add(this.cmbPLOR);
            this.grpBooked.Controls.Add(this.cmbVessel);
            this.grpBooked.Controls.Add(this.cbxBooked);
            this.grpBooked.Controls.Add(this.cmbPOD);
            this.grpBooked.Controls.Add(this.cbxStena);
            this.grpBooked.Controls.Add(this.cmbPOL);
            this.grpBooked.Controls.Add(this.txtVoyage);
            this.grpBooked.Location = new System.Drawing.Point(523, 3);
            this.grpBooked.Name = "grpBooked";
            this.grpBooked.Size = new System.Drawing.Size(379, 169);
            this.grpBooked.TabIndex = 15;
            this.grpBooked.TabStop = false;
            this.grpBooked.Text = "Booked";
            // 
            // cbxMissedRdd
            // 
            this.cbxMissedRdd.Location = new System.Drawing.Point(249, 60);
            this.cbxMissedRdd.Name = "cbxMissedRdd";
            this.cbxMissedRdd.Size = new System.Drawing.Size(124, 22);
            this.cbxMissedRdd.TabIndex = 28;
            this.cbxMissedRdd.Text = "Missed RDD";
            this.cbxMissedRdd.UseVisualStyleBackColor = true;
            this.cbxMissedRdd.YN = "N";
            // 
            // txtVoyDoc
            // 
            this.txtVoyDoc.LabelText = "VoyDoc";
            this.txtVoyDoc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyDoc.LinkDisabledMessage = "Link Disabled";
            this.txtVoyDoc.Location = new System.Drawing.Point(53, 32);
            this.txtVoyDoc.Name = "txtVoyDoc";
            this.txtVoyDoc.Size = new System.Drawing.Size(100, 20);
            this.txtVoyDoc.TabIndex = 27;
            // 
            // cmbPLOD
            // 
            this.cmbPLOD.CodeColumn = "Location_Cd";
            this.cmbPLOD.DescriptionColumn = "Location_Dsc";
            cmbPLOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOD_DesignTimeLayout.LayoutString");
            this.cmbPLOD.DesignTimeLayout = cmbPLOD_DesignTimeLayout;
            this.cmbPLOD.DisplayMember = "Location_Dsc";
            this.cmbPLOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPLOD.LabelText = "PLOD";
            this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOD.Location = new System.Drawing.Point(53, 144);
            this.cmbPLOD.Name = "cmbPLOD";
            this.cmbPLOD.SelectedIndex = -1;
            this.cmbPLOD.SelectedItem = null;
            this.cmbPLOD.Size = new System.Drawing.Size(168, 20);
            this.cmbPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOD.TabIndex = 26;
            this.cmbPLOD.ValueColumn = "Location_Cd";
            this.cmbPLOD.ValueMember = "Location_Cd";
            // 
            // cmbPLOR
            // 
            this.cmbPLOR.CodeColumn = "Location_Cd";
            this.cmbPLOR.DescriptionColumn = "Location_Dsc";
            cmbPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOR_DesignTimeLayout.LayoutString");
            this.cmbPLOR.DesignTimeLayout = cmbPLOR_DesignTimeLayout;
            this.cmbPLOR.DisplayMember = "Location_Dsc";
            this.cmbPLOR.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPLOR.LabelText = "PLOR";
            this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOR.Location = new System.Drawing.Point(53, 77);
            this.cmbPLOR.Name = "cmbPLOR";
            this.cmbPLOR.SelectedIndex = -1;
            this.cmbPLOR.SelectedItem = null;
            this.cmbPLOR.Size = new System.Drawing.Size(168, 20);
            this.cmbPLOR.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOR.TabIndex = 25;
            this.cmbPLOR.ValueColumn = "Location_Cd";
            this.cmbPLOR.ValueMember = "Location_Cd";
            // 
            // cmbVessel
            // 
            this.cmbVessel.CodeColumn = "Vessel_Cd";
            this.cmbVessel.DescriptionColumn = "Vessel_Nm";
            cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
            this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
            this.cmbVessel.DisplayMember = "Vessel_CdVessel_Nm";
            this.cmbVessel.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbVessel.LabelText = "Vessel";
            this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVessel.Location = new System.Drawing.Point(53, 55);
            this.cmbVessel.Name = "cmbVessel";
            this.cmbVessel.SelectedIndex = -1;
            this.cmbVessel.SelectedItem = null;
            this.cmbVessel.Size = new System.Drawing.Size(100, 20);
            this.cmbVessel.TabIndex = 24;
            this.cmbVessel.ValueColumn = "Vessel_Cd";
            this.cmbVessel.ValueMember = "Vessel_Cd";
            // 
            // cbxBooked
            // 
            this.cbxBooked.Location = new System.Drawing.Point(249, 14);
            this.cbxBooked.Name = "cbxBooked";
            this.cbxBooked.Size = new System.Drawing.Size(124, 23);
            this.cbxBooked.TabIndex = 23;
            this.cbxBooked.Text = "Just Booked";
            this.cbxBooked.UseVisualStyleBackColor = true;
            this.cbxBooked.YN = "N";
            // 
            // cmbPOD
            // 
            this.cmbPOD.CodeColumn = "Location_Cd";
            this.cmbPOD.DescriptionColumn = "Location_Dsc";
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DisplayMember = "Location_Dsc";
            this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOD.LabelText = "POD";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(53, 121);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(168, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 3;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValueMember = "Location_Cd";
            // 
            // cbxStena
            // 
            this.cbxStena.Location = new System.Drawing.Point(249, 38);
            this.cbxStena.Name = "cbxStena";
            this.cbxStena.Size = new System.Drawing.Size(124, 22);
            this.cbxStena.TabIndex = 21;
            this.cbxStena.Text = "Just Stena Bookings";
            this.cbxStena.UseVisualStyleBackColor = true;
            this.cbxStena.YN = "N";
            // 
            // cmbPOL
            // 
            this.cmbPOL.CodeColumn = "Location_Cd";
            this.cmbPOL.DescriptionColumn = "Location_Dsc";
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DisplayMember = "Location_Dsc";
            this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOL.LabelText = "POL";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(53, 99);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(168, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 2;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(53, 10);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 0;
            // 
            // grpDays
            // 
            this.grpDays.Controls.Add(this.sailDtRange);
            this.grpDays.Controls.Add(this.reqDateRange);
            this.grpDays.Controls.Add(this.txtDays);
            this.grpDays.Controls.Add(this.cmbMMYY);
            this.grpDays.Controls.Add(this.rbToday);
            this.grpDays.Controls.Add(this.rb30);
            this.grpDays.Controls.Add(this.rbAll);
            this.grpDays.Controls.Add(this.rb180);
            this.grpDays.Location = new System.Drawing.Point(253, 2);
            this.grpDays.Name = "grpDays";
            this.grpDays.Size = new System.Drawing.Size(266, 172);
            this.grpDays.TabIndex = 17;
            this.grpDays.TabStop = false;
            this.grpDays.Text = "Request Age";
            // 
            // sailDtRange
            // 
            this.sailDtRange.CheckBoxText = "Sailing (mmddyy)";
            this.sailDtRange.Location = new System.Drawing.Point(118, 90);
            this.sailDtRange.Name = "sailDtRange";
            this.sailDtRange.Size = new System.Drawing.Size(136, 76);
            this.sailDtRange.TabIndex = 24;
            // 
            // reqDateRange
            // 
            this.reqDateRange.CheckBoxText = "Request  (mmddyy)";
            this.reqDateRange.Location = new System.Drawing.Point(118, 12);
            this.reqDateRange.Name = "reqDateRange";
            this.reqDateRange.Size = new System.Drawing.Size(136, 76);
            this.reqDateRange.TabIndex = 23;
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.Control;
            this.txtDays.Enabled = false;
            this.txtDays.ForeColor = System.Drawing.Color.Black;
            this.txtDays.LinkDisabledMessage = "Link Disabled";
            this.txtDays.Location = new System.Drawing.Point(14, 128);
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(37, 20);
            this.txtDays.TabIndex = 21;
            this.txtDays.TabStop = false;
            // 
            // cmbMMYY
            // 
            cmbMMYY_DesignTimeLayout.LayoutString = resources.GetString("cmbMMYY_DesignTimeLayout.LayoutString");
            this.cmbMMYY.DesignTimeLayout = cmbMMYY_DesignTimeLayout;
            this.cmbMMYY.DisplayMember = "mmyy_dsc";
            this.cmbMMYY.LabelText = "Month";
            this.cmbMMYY.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMMYY.Location = new System.Drawing.Point(40, 19);
            this.cmbMMYY.Name = "cmbMMYY";
            this.cmbMMYY.SelectedIndex = -1;
            this.cmbMMYY.SelectedItem = null;
            this.cmbMMYY.Size = new System.Drawing.Size(62, 20);
            this.cmbMMYY.TabIndex = 22;
            this.cmbMMYY.ValueMember = "mmyy_val";
            // 
            // rbToday
            // 
            this.rbToday.Checked = true;
            this.rbToday.Location = new System.Drawing.Point(16, 46);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(81, 17);
            this.rbToday.TabIndex = 20;
            this.rbToday.TabStop = true;
            this.rbToday.Text = "5 Days";
            this.rbToday.UseVisualStyleBackColor = true;
            this.rbToday.CheckedChanged += new System.EventHandler(this.rb7_CheckedChanged);
            // 
            // rb30
            // 
            this.rb30.Location = new System.Drawing.Point(16, 66);
            this.rb30.Name = "rb30";
            this.rb30.Size = new System.Drawing.Size(81, 17);
            this.rb30.TabIndex = 16;
            this.rb30.Text = "30 Days";
            this.rb30.UseVisualStyleBackColor = true;
            this.rb30.CheckedChanged += new System.EventHandler(this.rb15_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.Location = new System.Drawing.Point(16, 104);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(81, 18);
            this.rbAll.TabIndex = 19;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rb180
            // 
            this.rb180.Location = new System.Drawing.Point(16, 84);
            this.rb180.Name = "rb180";
            this.rb180.Size = new System.Drawing.Size(81, 19);
            this.rb180.TabIndex = 18;
            this.rb180.Text = "180 Days";
            this.rb180.UseVisualStyleBackColor = true;
            this.rb180.CheckedChanged += new System.EventHandler(this.rb180_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(919, 118);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(919, 143);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.cmbTerms);
            this.grpMain.Controls.Add(this.cmbStatus);
            this.grpMain.Controls.Add(this.txtSerialNo);
            this.grpMain.Controls.Add(this.cmbPartner);
            this.grpMain.Controls.Add(this.txtPCFN);
            this.grpMain.Controls.Add(this.cbxUnprocessed);
            this.grpMain.Controls.Add(this.txtBooking);
            this.grpMain.Location = new System.Drawing.Point(3, 2);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(243, 172);
            this.grpMain.TabIndex = 25;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Search";
            // 
            // cmbTerms
            // 
            this.cmbTerms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            cmbTerms_DesignTimeLayout.LayoutString = resources.GetString("cmbTerms_DesignTimeLayout.LayoutString");
            this.cmbTerms.DesignTimeLayout = cmbTerms_DesignTimeLayout;
            this.cmbTerms.DropDownDisplayMember = "move_type_cd";
            this.cmbTerms.DropDownValueMember = "move_type_cd";
            this.cmbTerms.LabelText = "Terms";
            this.cmbTerms.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbTerms.Location = new System.Drawing.Point(52, 122);
            this.cmbTerms.Name = "cmbTerms";
            this.cmbTerms.SaveSettings = false;
            this.cmbTerms.Size = new System.Drawing.Size(100, 20);
            this.cmbTerms.TabIndex = 30;
            this.cmbTerms.ValueItemDataMember = "(None)";
            this.cmbTerms.ValuesDataMember = "move_type_cd";
            // 
            // cmbStatus
            // 
            cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
            this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
            this.cmbStatus.DisplayMember = "acms_status_dsc";
            this.cmbStatus.LabelText = "Status";
            this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatus.Location = new System.Drawing.Point(52, 100);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.SelectedIndex = -1;
            this.cmbStatus.SelectedItem = null;
            this.cmbStatus.Size = new System.Drawing.Size(181, 20);
            this.cmbStatus.TabIndex = 22;
            this.cmbStatus.ValueMember = "acms_status_cd";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelText = "TCN";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(52, 78);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(181, 20);
            this.txtSerialNo.TabIndex = 18;
            // 
            // cmbPartner
            // 
            cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
            this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
            this.cmbPartner.DisplayMember = "partner_dsc";
            this.cmbPartner.LabelText = "Partner";
            this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPartner.Location = new System.Drawing.Point(52, 15);
            this.cmbPartner.Name = "cmbPartner";
            this.cmbPartner.SelectedIndex = -1;
            this.cmbPartner.SelectedItem = null;
            this.cmbPartner.Size = new System.Drawing.Size(181, 20);
            this.cmbPartner.TabIndex = 12;
            this.cmbPartner.ValueMember = "partner_cd";
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(52, 36);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(100, 20);
            this.txtPCFN.TabIndex = 13;
            // 
            // cbxUnprocessed
            // 
            this.cbxUnprocessed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUnprocessed.Location = new System.Drawing.Point(52, 147);
            this.cbxUnprocessed.Name = "cbxUnprocessed";
            this.cbxUnprocessed.Size = new System.Drawing.Size(154, 20);
            this.cbxUnprocessed.TabIndex = 22;
            this.cbxUnprocessed.Text = "Just Unprocessed";
            this.cbxUnprocessed.UseVisualStyleBackColor = true;
            this.cbxUnprocessed.YN = "N";
            // 
            // txtBooking
            // 
            this.txtBooking.LabelText = "Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(52, 57);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(100, 20);
            this.txtBooking.TabIndex = 14;
            // 
            // grdCancels
            // 
            grdCancels_DesignTimeLayout.LayoutString = resources.GetString("grdCancels_DesignTimeLayout.LayoutString");
            this.grdCancels.DesignTimeLayout = grdCancels_DesignTimeLayout;
            this.grdCancels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCancels.ExportFileID = null;
            this.grdCancels.GroupByBoxVisible = false;
            this.grdCancels.Location = new System.Drawing.Point(0, 407);
            this.grdCancels.Name = "grdCancels";
            this.grdCancels.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCancels.Size = new System.Drawing.Size(1127, 74);
            this.grdCancels.TabIndex = 23;
            this.grdCancels.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCancels_LinkClicked);
            // 
            // grdList
            // 
            grdList_DesignTimeLayout.LayoutString = resources.GetString("grdList_DesignTimeLayout.LayoutString");
            this.grdList.DesignTimeLayout = grdList_DesignTimeLayout;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdList.ExportFileID = null;
            this.grdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdList.FrozenColumns = 5;
            this.grdList.GroupByBoxVisible = false;
            this.grdList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdList.Hierarchical = true;
            this.grdList.Location = new System.Drawing.Point(0, 31);
            this.grdList.Name = "grdList";
            this.grdList.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdList.Size = new System.Drawing.Size(1127, 376);
            this.grdList.TabIndex = 0;
            this.grdList.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdList.SortKeysChanged += new System.EventHandler(this.grdList_SortKeysChanged);
            this.grdList.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdList_ColumnButtonClick);
            this.grdList.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdList_LinkClicked);
            // 
            // pnlCommands
            // 
            this.pnlCommands.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCommands.Controls.Add(this.btnPATLOB);
            this.pnlCommands.Controls.Add(this.btnResend304);
            this.pnlCommands.Controls.Add(this.btnLoadList);
            this.pnlCommands.Controls.Add(this.btnTenPlusTwo);
            this.pnlCommands.Controls.Add(this.btnUntransmitted);
            this.pnlCommands.Controls.Add(this.btnRetransmit301);
            this.pnlCommands.Controls.Add(this.btnConfirm);
            this.pnlCommands.Controls.Add(this.btnRetransmit);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommands.Location = new System.Drawing.Point(0, 0);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(1127, 31);
            this.pnlCommands.TabIndex = 22;
            // 
            // btnPATLOB
            // 
            this.btnPATLOB.Enabled = false;
            this.btnPATLOB.Location = new System.Drawing.Point(763, 1);
            this.btnPATLOB.Name = "btnPATLOB";
            this.btnPATLOB.Size = new System.Drawing.Size(97, 23);
            this.btnPATLOB.TabIndex = 25;
            this.btnPATLOB.Text = "PAT Load List";
            this.btnPATLOB.UseVisualStyleBackColor = true;
            this.btnPATLOB.Visible = false;
            this.btnPATLOB.Click += new System.EventHandler(this.btnPATLOB_Click);
            // 
            // btnResend304
            // 
            this.btnResend304.Location = new System.Drawing.Point(414, 1);
            this.btnResend304.Name = "btnResend304";
            this.btnResend304.Size = new System.Drawing.Size(92, 23);
            this.btnResend304.TabIndex = 24;
            this.btnResend304.Text = "Retransmit 304";
            this.btnResend304.UseVisualStyleBackColor = true;
            this.btnResend304.Visible = false;
            this.btnResend304.Click += new System.EventHandler(this.btnResend304_Click);
            // 
            // btnLoadList
            // 
            this.btnLoadList.Location = new System.Drawing.Point(610, 1);
            this.btnLoadList.Name = "btnLoadList";
            this.btnLoadList.Size = new System.Drawing.Size(75, 23);
            this.btnLoadList.TabIndex = 23;
            this.btnLoadList.Text = "Load List";
            this.btnLoadList.UseVisualStyleBackColor = true;
            this.btnLoadList.Click += new System.EventHandler(this.btnLoadList_Click);
            // 
            // btnTenPlusTwo
            // 
            this.btnTenPlusTwo.Location = new System.Drawing.Point(686, 1);
            this.btnTenPlusTwo.Name = "btnTenPlusTwo";
            this.btnTenPlusTwo.Size = new System.Drawing.Size(75, 23);
            this.btnTenPlusTwo.TabIndex = 22;
            this.btnTenPlusTwo.Text = "Ten + Two";
            this.btnTenPlusTwo.UseVisualStyleBackColor = true;
            this.btnTenPlusTwo.Click += new System.EventHandler(this.btnTenPlusTwo_Click);
            // 
            // btnUntransmitted
            // 
            this.btnUntransmitted.Location = new System.Drawing.Point(286, 1);
            this.btnUntransmitted.Name = "btnUntransmitted";
            this.btnUntransmitted.Size = new System.Drawing.Size(128, 23);
            this.btnUntransmitted.TabIndex = 21;
            this.btnUntransmitted.Text = "Set as Not Transmitted";
            this.btnUntransmitted.UseVisualStyleBackColor = true;
            this.btnUntransmitted.Click += new System.EventHandler(this.btnUntransmitted_Click);
            // 
            // btnRetransmit301
            // 
            this.btnRetransmit301.Location = new System.Drawing.Point(89, 1);
            this.btnRetransmit301.Name = "btnRetransmit301";
            this.btnRetransmit301.Size = new System.Drawing.Size(87, 23);
            this.btnRetransmit301.TabIndex = 2;
            this.btnRetransmit301.Text = "Retransmit 301";
            this.btnRetransmit301.UseVisualStyleBackColor = true;
            this.btnRetransmit301.Click += new System.EventHandler(this.btnRetransmit301_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(176, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(110, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Set as Transmitted";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnRetransmit
            // 
            this.btnRetransmit.Location = new System.Drawing.Point(2, 1);
            this.btnRetransmit.Name = "btnRetransmit";
            this.btnRetransmit.Size = new System.Drawing.Size(87, 23);
            this.btnRetransmit.TabIndex = 0;
            this.btnRetransmit.Text = "Retransmit 300";
            this.btnRetransmit.UseVisualStyleBackColor = true;
            this.btnRetransmit.Click += new System.EventHandler(this.btnRetransmit_Click);
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 711);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(1141, 22);
            this.sbrChild.TabIndex = 21;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(227, 17);
            this.sbbProgressCaption.Text = "Processing... (Click here to cancel the search)";
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tpList);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.SelectedIndex = 0;
            this.tpMain.Size = new System.Drawing.Size(1141, 699);
            this.tpMain.TabIndex = 1;
            // 
            // frmSearchBookingRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 699);
            this.Controls.Add(this.tpMain);
            this.Controls.Add(this.sbrChild);
            this.KeyPreview = true;
            this.Name = "frmSearchBookingRequests";
            this.Text = "Search Booking Requests";
            this.tpList.ResumeLayout(false);
            this.ucSplitContainer1.Panel1.ResumeLayout(false);
            this.ucSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
            this.ucSplitContainer1.ResumeLayout(false);
            this.grpBooked.ResumeLayout(false);
            this.grpBooked.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.grpDays.ResumeLayout(false);
            this.grpDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMMYY)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.pnlCommands.ResumeLayout(false);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.tpMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tpList;
		private CS2010.CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CS2010.CommonWinCtrls.ucCheckBox cbxUnprocessed;
		private CS2010.CommonWinCtrls.ucCheckBox cbxStena;
		private CS2010.CommonWinCtrls.ucGroupBox grpBooked;
		private CS2010.ArcSys.WinCtrls.ucLocationCombo cmbPOD;
		private CS2010.ArcSys.WinCtrls.ucLocationCombo cmbPOL;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyage;
		private CS2010.CommonWinCtrls.ucGroupBox grpDays;
		private CS2010.CommonWinCtrls.ucRadioButton rbToday;
		private CS2010.CommonWinCtrls.ucRadioButton rb30;
		private CS2010.CommonWinCtrls.ucRadioButton rbAll;
		private CS2010.CommonWinCtrls.ucRadioButton rb180;
		private CS2010.CommonWinCtrls.ucTextBox txtSerialNo;
		private CS2010.CommonWinCtrls.ucTextBox txtBooking;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CS2010.CommonWinCtrls.ucTextBox txtPCFN;
		private CS2010.CommonWinCtrls.ucGridEx grdList;
		private CS2010.CommonWinCtrls.ucPanel pnlCommands;
		private CS2010.CommonWinCtrls.ucButton btnUntransmitted;
		private CS2010.CommonWinCtrls.ucButton btnRetransmit301;
		private CS2010.CommonWinCtrls.ucButton btnClear;
		private CS2010.CommonWinCtrls.ucButton btnConfirm;
		private CS2010.CommonWinCtrls.ucButton btnSearch;
		private CS2010.CommonWinCtrls.ucButton btnRetransmit;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private CS2010.CommonWinCtrls.ucTabControl tpMain;
		private CS2010.CommonWinCtrls.ucButton btnTenPlusTwo;
		private CS2010.CommonWinCtrls.ucButton btnLoadList;
		private CS2010.CommonWinCtrls.ucTextBox txtDays;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbMMYY;
		private CS2010.CommonWinCtrls.ucCheckBox cbxBooked;
		private System.Windows.Forms.GroupBox grpMain;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbStatus;
		private CS2010.CommonWinCtrls.ucButton btnResend304;
		private CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy reqDateRange;
		private CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy sailDtRange;
		private CS2010.ArcSys.WinCtrls.ucVesselCombo cmbVessel;
		private CS2010.CommonWinCtrls.ucCheckedComboBox cmbTerms;
		private CS2010.CommonWinCtrls.ucGridEx grdCancels;
		private CS2010.ArcSys.WinCtrls.ucLocationCombo cmbPLOD;
		private CS2010.ArcSys.WinCtrls.ucLocationCombo cmbPLOR;
		private CS2010.CommonWinCtrls.ucButton btnPATLOB;
        private CS2010.CommonWinCtrls.ucTextBox txtVoyDoc;
        private CS2010.CommonWinCtrls.ucCheckBox cbxMissedRdd;
        private CS2010.CommonWinCtrls.ucButton btnCallAPI;
        private CS2010.CommonWinCtrls.ucButton btnUnprocessedSearch;


	}
}