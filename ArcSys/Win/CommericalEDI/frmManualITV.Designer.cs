namespace CS2010.ArcSys.Win
{
	partial class frmManualITV
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
			Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManualITV));
			Janus.Windows.GridEX.GridEXLayout cmbTerminal_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbLocation_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbStatusCodes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.pnlSearchCreate = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.btnSearch = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpenCreate = new Infragistics.Win.Misc.UltraButton();
			this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.rbLand = new System.Windows.Forms.RadioButton();
			this.rbPorts = new System.Windows.Forms.RadioButton();
			this.btnCreateSave = new CS2010.CommonWinCtrls.ucButton();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbTerminal = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.calActivityDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbLocation = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbStatusCodes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.txtPOL = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPOD = new CS2010.CommonWinCtrls.ucTextBox();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
			this.grpSearch.SuspendLayout();
			this.grpSearchPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlSearchCreate)).BeginInit();
			this.pnlSearchCreate.Panel1.SuspendLayout();
			this.pnlSearchCreate.Panel2.SuspendLayout();
			this.pnlSearchCreate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTerminal)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.calActivityDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).BeginInit();
			this.tabMain.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.SuspendLayout();
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
			this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
			this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 694);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(992, 22);
			this.sbrChild.TabIndex = 4;
			this.sbrChild.Text = "Search Available Main Status Strip";
			this.sbrChild.Visible = false;
			// 
			// grpSearch
			// 
			this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
			this.grpSearch.Controls.Add(this.grpSearchPanel);
			this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 148);
			appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance1.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderAppearance = appearance1;
			this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderCollapsedAppearance = appearance2;
			this.grpSearch.Location = new System.Drawing.Point(0, 25);
			this.grpSearch.Name = "grpSearch";
			this.grpSearch.Size = new System.Drawing.Size(992, 148);
			this.grpSearch.TabIndex = 0;
			this.grpSearch.Text = "Search Options";
			this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			// 
			// grpSearchPanel
			// 
			this.grpSearchPanel.Controls.Add(this.pnlSearchCreate);
			this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
			this.grpSearchPanel.Name = "grpSearchPanel";
			this.grpSearchPanel.Size = new System.Drawing.Size(986, 124);
			this.grpSearchPanel.TabIndex = 0;
			// 
			// pnlSearchCreate
			// 
			this.pnlSearchCreate.BackColor = System.Drawing.Color.Transparent;
			this.pnlSearchCreate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSearchCreate.Location = new System.Drawing.Point(0, 0);
			this.pnlSearchCreate.Name = "pnlSearchCreate";
			// 
			// pnlSearchCreate.Panel1
			// 
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtPOL);
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtPOD);
			this.pnlSearchCreate.Panel1.Controls.Add(this.btnSearch);
			this.pnlSearchCreate.Panel1.Controls.Add(this.label9);
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtPCFN);
			this.pnlSearchCreate.Panel1.Controls.Add(this.label4);
			this.pnlSearchCreate.Panel1.Controls.Add(this.label3);
			this.pnlSearchCreate.Panel1.Controls.Add(this.label2);
			this.pnlSearchCreate.Panel1.Controls.Add(this.label1);
			this.pnlSearchCreate.Panel1.Controls.Add(this.btnOpenCreate);
			this.pnlSearchCreate.Panel1.Controls.Add(this.cmbPartner);
			this.pnlSearchCreate.Panel1.Controls.Add(this.btnClear);
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtSerialNo);
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtVoyage);
			this.pnlSearchCreate.Panel1.Controls.Add(this.txtBookingNo);
			// 
			// pnlSearchCreate.Panel2
			// 
			this.pnlSearchCreate.Panel2.Controls.Add(this.ucLabel1);
			this.pnlSearchCreate.Panel2.Controls.Add(this.rbLand);
			this.pnlSearchCreate.Panel2.Controls.Add(this.rbPorts);
			this.pnlSearchCreate.Panel2.Controls.Add(this.btnCreateSave);
			this.pnlSearchCreate.Panel2.Controls.Add(this.label8);
			this.pnlSearchCreate.Panel2.Controls.Add(this.cmbTerminal);
			this.pnlSearchCreate.Panel2.Controls.Add(this.calActivityDate);
			this.pnlSearchCreate.Panel2.Controls.Add(this.label7);
			this.pnlSearchCreate.Panel2.Controls.Add(this.cmbLocation);
			this.pnlSearchCreate.Panel2.Controls.Add(this.label6);
			this.pnlSearchCreate.Panel2.Controls.Add(this.label5);
			this.pnlSearchCreate.Panel2.Controls.Add(this.cmbStatusCodes);
			this.pnlSearchCreate.Panel2.Controls.Add(this.ultraButton1);
			this.pnlSearchCreate.Panel2.Controls.Add(this.btnCancel);
			this.pnlSearchCreate.Size = new System.Drawing.Size(986, 124);
			this.pnlSearchCreate.SplitterDistance = 404;
			this.pnlSearchCreate.TabIndex = 6;
			this.pnlSearchCreate.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.pnlSearchCreate_SplitterMoved);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(303, 8);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 13;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 79);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "PCFN";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPCFN
			// 
			this.txtPCFN.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtPCFN.LabelText = "Serial#";
			this.txtPCFN.LinkDisabledMessage = "Link Disabled";
			this.txtPCFN.Location = new System.Drawing.Point(65, 76);
			this.txtPCFN.Name = "txtPCFN";
			this.txtPCFN.Size = new System.Drawing.Size(100, 20);
			this.txtPCFN.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Serial#";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Voyage";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Booking";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Partner";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOpenCreate
			// 
			this.btnOpenCreate.Location = new System.Drawing.Point(303, 95);
			this.btnOpenCreate.Name = "btnOpenCreate";
			this.btnOpenCreate.Size = new System.Drawing.Size(75, 23);
			this.btnOpenCreate.TabIndex = 6;
			this.btnOpenCreate.Text = "Next>>";
			this.btnOpenCreate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnOpenCreate.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnOpenCreate.Click += new System.EventHandler(this.btnOpenCreate_Click);
			// 
			// cmbPartner
			// 
			cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
			this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
			this.cmbPartner.DisplayMember = "partner_dsc";
			this.cmbPartner.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbPartner.LabelText = "Partner";
			this.cmbPartner.Location = new System.Drawing.Point(65, 9);
			this.cmbPartner.Name = "cmbPartner";
			this.cmbPartner.SelectedIndex = -1;
			this.cmbPartner.SelectedItem = null;
			this.cmbPartner.Size = new System.Drawing.Size(208, 20);
			this.cmbPartner.TabIndex = 0;
			this.cmbPartner.ValueMember = "trading_partner_cd";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(303, 34);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// txtSerialNo
			// 
			this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtSerialNo.LabelText = "Serial#";
			this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
			this.txtSerialNo.Location = new System.Drawing.Point(65, 98);
			this.txtSerialNo.Name = "txtSerialNo";
			this.txtSerialNo.Size = new System.Drawing.Size(208, 20);
			this.txtSerialNo.TabIndex = 3;
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(65, 31);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtVoyage.TabIndex = 1;
			// 
			// txtBookingNo
			// 
			this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtBookingNo.LabelText = "Booking#";
			this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
			this.txtBookingNo.Location = new System.Drawing.Point(65, 53);
			this.txtBookingNo.Name = "txtBookingNo";
			this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
			this.txtBookingNo.TabIndex = 2;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(208, 45);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(71, 13);
			this.ucLabel1.TabIndex = 13;
			this.ucLabel1.Text = "(mm/dd/yyyy)";
			this.ucLabel1.Click += new System.EventHandler(this.ucLabel1_Click);
			// 
			// rbLand
			// 
			this.rbLand.AutoSize = true;
			this.rbLand.Location = new System.Drawing.Point(292, 75);
			this.rbLand.Name = "rbLand";
			this.rbLand.Size = new System.Drawing.Size(49, 17);
			this.rbLand.TabIndex = 12;
			this.rbLand.Text = "Land";
			this.rbLand.UseVisualStyleBackColor = true;
			this.rbLand.CheckedChanged += new System.EventHandler(this.rbLand_CheckedChanged);
			// 
			// rbPorts
			// 
			this.rbPorts.AutoSize = true;
			this.rbPorts.Checked = true;
			this.rbPorts.Location = new System.Drawing.Point(292, 59);
			this.rbPorts.Name = "rbPorts";
			this.rbPorts.Size = new System.Drawing.Size(49, 17);
			this.rbPorts.TabIndex = 11;
			this.rbPorts.TabStop = true;
			this.rbPorts.Text = "Ports";
			this.rbPorts.UseVisualStyleBackColor = true;
			this.rbPorts.CheckedChanged += new System.EventHandler(this.rbPorts_CheckedChanged);
			// 
			// btnCreateSave
			// 
			this.btnCreateSave.Location = new System.Drawing.Point(395, 83);
			this.btnCreateSave.Name = "btnCreateSave";
			this.btnCreateSave.Size = new System.Drawing.Size(75, 23);
			this.btnCreateSave.TabIndex = 6;
			this.btnCreateSave.Text = "Create";
			this.btnCreateSave.UseVisualStyleBackColor = true;
			this.btnCreateSave.Click += new System.EventHandler(this.btnCreateSave_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(25, 89);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Terminal";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTerminal
			// 
			this.cmbTerminal.DataMember = "terminal_cd";
			this.cmbTerminal.DescriptionColumn = "terminal_dsc";
			cmbTerminal_DesignTimeLayout.LayoutString = resources.GetString("cmbTerminal_DesignTimeLayout.LayoutString");
			this.cmbTerminal.DesignTimeLayout = cmbTerminal_DesignTimeLayout;
			this.cmbTerminal.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbTerminal.LabelText = "Partner";
			this.cmbTerminal.Location = new System.Drawing.Point(78, 86);
			this.cmbTerminal.Name = "cmbTerminal";
			this.cmbTerminal.SelectedIndex = -1;
			this.cmbTerminal.SelectedItem = null;
			this.cmbTerminal.Size = new System.Drawing.Size(208, 20);
			this.cmbTerminal.TabIndex = 3;
			this.cmbTerminal.ValueColumn = "terminal_cd";
			this.cmbTerminal.ValueMember = "terminal_cd";
			// 
			// calActivityDate
			// 
			this.calActivityDate.Location = new System.Drawing.Point(78, 40);
			this.calActivityDate.MaskInput = "{LOC}mm/dd/yyyy HH:mm";
			this.calActivityDate.Name = "calActivityDate";
			this.calActivityDate.Size = new System.Drawing.Size(127, 21);
			this.calActivityDate.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 68);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Location";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbLocation
			// 
			cmbLocation_DesignTimeLayout.LayoutString = resources.GetString("cmbLocation_DesignTimeLayout.LayoutString");
			this.cmbLocation.DesignTimeLayout = cmbLocation_DesignTimeLayout;
			this.cmbLocation.DisplayMember = "location_dsc";
			this.cmbLocation.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbLocation.LabelText = "Partner";
			this.cmbLocation.Location = new System.Drawing.Point(78, 64);
			this.cmbLocation.Name = "cmbLocation";
			this.cmbLocation.SelectedIndex = -1;
			this.cmbLocation.SelectedItem = null;
			this.cmbLocation.Size = new System.Drawing.Size(208, 20);
			this.cmbLocation.TabIndex = 2;
			this.cmbLocation.ValueMember = "location_cd";
			this.cmbLocation.ValueChanged += new System.EventHandler(this.cmbLocation_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Activity Date";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(33, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Activity";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbStatusCodes
			// 
			cmbStatusCodes_DesignTimeLayout.LayoutString = resources.GetString("cmbStatusCodes_DesignTimeLayout.LayoutString");
			this.cmbStatusCodes.DesignTimeLayout = cmbStatusCodes_DesignTimeLayout;
			this.cmbStatusCodes.DisplayMember = "activity_dsc";
			this.cmbStatusCodes.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbStatusCodes.LabelText = "";
			this.cmbStatusCodes.Location = new System.Drawing.Point(78, 18);
			this.cmbStatusCodes.Name = "cmbStatusCodes";
			this.cmbStatusCodes.SelectedIndex = -1;
			this.cmbStatusCodes.SelectedItem = null;
			this.cmbStatusCodes.Size = new System.Drawing.Size(208, 20);
			this.cmbStatusCodes.TabIndex = 0;
			this.cmbStatusCodes.ValueMember = "activity_cd";
			this.cmbStatusCodes.ValueChanged += new System.EventHandler(this.cmbStatusCodes_ValueChanged);
			// 
			// ultraButton1
			// 
			this.ultraButton1.Location = new System.Drawing.Point(393, 14);
			this.ultraButton1.Name = "ultraButton1";
			this.ultraButton1.Size = new System.Drawing.Size(75, 23);
			this.ultraButton1.TabIndex = 4;
			this.ultraButton1.Text = "Clear";
			this.ultraButton1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(393, 39);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbrMain
			// 
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(992, 25);
			this.tbrMain.TabIndex = 5;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabPage1);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 173);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(992, 543);
			this.tabMain.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grdMain);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(984, 517);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Bookings/Cargo";
			this.tabPage1.UseVisualStyleBackColor = true;
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
			this.grdMain.Location = new System.Drawing.Point(3, 3);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(978, 511);
			this.grdMain.TabIndex = 2;
			this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdMain.UseGroupRowSelector = true;
			this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			// 
			// txtPOL
			// 
			this.txtPOL.LabelText = "POL";
			this.txtPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPOL.LinkDisabledMessage = "Link Disabled";
			this.txtPOL.Location = new System.Drawing.Point(220, 53);
			this.txtPOL.Name = "txtPOL";
			this.txtPOL.Size = new System.Drawing.Size(53, 20);
			this.txtPOL.TabIndex = 14;
			// 
			// txtPOD
			// 
			this.txtPOD.LabelText = "POD";
			this.txtPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPOD.LinkDisabledMessage = "Link Disabled";
			this.txtPOD.Location = new System.Drawing.Point(220, 75);
			this.txtPOD.Name = "txtPOD";
			this.txtPOD.Size = new System.Drawing.Size(53, 20);
			this.txtPOD.TabIndex = 15;
			// 
			// frmManualITV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmManualITV";
			this.Text = "Manually Enter ITV";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearchPanel.ResumeLayout(false);
			this.pnlSearchCreate.Panel1.ResumeLayout(false);
			this.pnlSearchCreate.Panel1.PerformLayout();
			this.pnlSearchCreate.Panel2.ResumeLayout(false);
			this.pnlSearchCreate.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlSearchCreate)).EndInit();
			this.pnlSearchCreate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTerminal)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.calActivityDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).EndInit();
			this.tabMain.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucSplitContainer pnlSearchCreate;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnOpenCreate;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private Infragistics.Win.Misc.UltraButton ultraButton1;
		private System.Windows.Forms.Label label5;
		private CommonWinCtrls.ucMultiColumnCombo cmbStatusCodes;
		private System.Windows.Forms.Label label7;
		private CommonWinCtrls.ucMultiColumnCombo cmbLocation;
		private System.Windows.Forms.Label label6;
		private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor calActivityDate;
		private System.Windows.Forms.Label label8;
		private CommonWinCtrls.ucMultiColumnCombo cmbTerminal;
		private CommonWinCtrls.ucButton btnCreateSave;
		private System.Windows.Forms.RadioButton rbLand;
		private System.Windows.Forms.RadioButton rbPorts;
		private System.Windows.Forms.Label label9;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucLabel ucLabel1;
		private System.Windows.Forms.Button btnSearch;
		private CommonWinCtrls.ucTextBox txtPOL;
		private CommonWinCtrls.ucTextBox txtPOD;
	}
}