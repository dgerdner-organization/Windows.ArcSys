namespace CS2010.ArcSys.Win
{
	partial class frmSearchEDIHistory
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
            Janus.Windows.GridEX.GridEXLayout cmbStatusCodes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchEDIHistory));
            Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdITVSummary_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.btnResend = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
            this.txtDays = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbStatusCodes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpITVSummary = new System.Windows.Forms.TabPage();
            this.grdITVSummary = new CS2010.CommonWinCtrls.ucGridEx();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsResendFTP = new System.Windows.Forms.ToolStripButton();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.sbrChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.tpITVSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdITVSummary)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.ucGridToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
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
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            appearance1.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.Appearance = appearance1;
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            appearance2.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.ContentAreaAppearance = appearance2;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 116);
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance3;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance4;
            this.grpSearch.Location = new System.Drawing.Point(0, 25);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(992, 116);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.Text = "Search Options";
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.btnResend);
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
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(986, 92);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // btnResend
            // 
            this.btnResend.Location = new System.Drawing.Point(838, 61);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(75, 23);
            this.btnResend.TabIndex = 13;
            this.btnResend.Text = "Resend";
            this.btnResend.UseVisualStyleBackColor = true;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // ucLabel1
            // 
            this.ucLabel1.Location = new System.Drawing.Point(719, 8);
            this.ucLabel1.Name = "ucLabel1";
            this.ucLabel1.Size = new System.Drawing.Size(46, 13);
            this.ucLabel1.TabIndex = 12;
            this.ucLabel1.Text = "days old";
            // 
            // txtDays
            // 
            this.txtDays.LabelText = "Activity no more than ";
            this.txtDays.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDays.LinkDisabledMessage = "Link Disabled";
            this.txtDays.Location = new System.Drawing.Point(675, 5);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(38, 20);
            this.txtDays.TabIndex = 11;
            this.txtDays.Text = "120";
            // 
            // cmbStatusCodes
            // 
            cmbStatusCodes_DesignTimeLayout.LayoutString = resources.GetString("cmbStatusCodes_DesignTimeLayout.LayoutString");
            this.cmbStatusCodes.DesignTimeLayout = cmbStatusCodes_DesignTimeLayout;
            this.cmbStatusCodes.DisplayMember = "activity_dsc";
            this.cmbStatusCodes.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbStatusCodes.LabelText = "Activity Code";
            this.cmbStatusCodes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatusCodes.Location = new System.Drawing.Point(330, 26);
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
            this.txtPCFN.Location = new System.Drawing.Point(91, 69);
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
            this.txtVoyage.Location = new System.Drawing.Point(91, 24);
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
            this.cmbPartner.Location = new System.Drawing.Point(91, 3);
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
            this.txtSerialNo.Location = new System.Drawing.Point(330, 4);
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
            this.txtBookingNo.Location = new System.Drawing.Point(91, 46);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
            this.txtBookingNo.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnClear.Location = new System.Drawing.Point(756, 61);
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
            this.btnSearch.Location = new System.Drawing.Point(675, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdResults
            // 
            this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
            this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
            this.grdResults.DisplayFieldChooser = true;
            this.grdResults.DisplayFieldChooserChildren = true;
            this.grdResults.DisplayFontSelector = true;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.ExportFileID = null;
            this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdResults.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdResults.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdResults.Hierarchical = true;
            this.grdResults.Location = new System.Drawing.Point(3, 3);
            this.grdResults.Name = "grdResults";
            this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdResults.Size = new System.Drawing.Size(978, 526);
            this.grdResults.TabIndex = 1;
            this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_ColumnButtonClick);
            this.grdResults.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_LinkClicked);
            this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
            this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
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
            this.tabMain.Controls.Add(this.tpITVSummary);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 141);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(992, 558);
            this.tabMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Query";
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
            this.grdMain.Size = new System.Drawing.Size(978, 526);
            this.grdMain.TabIndex = 2;
            this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
            // 
            // tpITVSummary
            // 
            this.tpITVSummary.Controls.Add(this.grdITVSummary);
            this.tpITVSummary.Location = new System.Drawing.Point(4, 22);
            this.tpITVSummary.Name = "tpITVSummary";
            this.tpITVSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tpITVSummary.Size = new System.Drawing.Size(984, 532);
            this.tpITVSummary.TabIndex = 2;
            this.tpITVSummary.Text = "ITV Summary";
            this.tpITVSummary.UseVisualStyleBackColor = true;
            // 
            // grdITVSummary
            // 
            this.grdITVSummary.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdITVSummary.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdITVSummary_DesignTimeLayout.LayoutString = resources.GetString("grdITVSummary_DesignTimeLayout.LayoutString");
            this.grdITVSummary.DesignTimeLayout = grdITVSummary_DesignTimeLayout;
            this.grdITVSummary.DisplayFieldChooser = true;
            this.grdITVSummary.DisplayFieldChooserChildren = true;
            this.grdITVSummary.DisplayFontSelector = true;
            this.grdITVSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdITVSummary.ExportFileID = null;
            this.grdITVSummary.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdITVSummary.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdITVSummary.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdITVSummary.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdITVSummary.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdITVSummary.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdITVSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdITVSummary.Hierarchical = true;
            this.grdITVSummary.Location = new System.Drawing.Point(3, 3);
            this.grdITVSummary.Name = "grdITVSummary";
            this.grdITVSummary.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdITVSummary.Size = new System.Drawing.Size(978, 526);
            this.grdITVSummary.TabIndex = 3;
            this.grdITVSummary.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdITVSummary.UseGroupRowSelector = true;
            this.grdITVSummary.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucGridToolStrip1);
            this.tabPage2.Controls.Add(this.grdResults);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(984, 532);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transmissions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucGridToolStrip1
            // 
            this.ucGridToolStrip1.GridObject = null;
            this.ucGridToolStrip1.HideAddButton = true;
            this.ucGridToolStrip1.HideDeleteButton = true;
            this.ucGridToolStrip1.HideExportMenu = true;
            this.ucGridToolStrip1.HidePrintMenu = true;
            this.ucGridToolStrip1.HideSeparator = true;
            this.ucGridToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsResendFTP});
            this.ucGridToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.ucGridToolStrip1.Name = "ucGridToolStrip1";
            this.ucGridToolStrip1.Size = new System.Drawing.Size(978, 25);
            this.ucGridToolStrip1.TabIndex = 7;
            this.ucGridToolStrip1.Text = "ucGridToolStrip1";
            // 
            // tsResendFTP
            // 
            this.tsResendFTP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsResendFTP.Image = ((System.Drawing.Image)(resources.GetObject("tsResendFTP.Image")));
            this.tsResendFTP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsResendFTP.Name = "tsResendFTP";
            this.tsResendFTP.Size = new System.Drawing.Size(47, 22);
            this.tsResendFTP.Text = "&Resend";
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
            this.cmbPOD.Location = new System.Drawing.Point(330, 70);
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
            this.cmbPOL.Location = new System.Drawing.Point(330, 48);
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
            // frmSearchEDIHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(992, 699);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Name = "frmSearchEDIHistory";
            this.Text = "Search Commercial ITV History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatusCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.tpITVSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdITVSummary)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ucGridToolStrip1.ResumeLayout(false);
            this.ucGridToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private CommonWinCtrls.ucGridEx grdResults;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
		private CommonWinCtrls.ucGridEx grdMain;
		private System.Windows.Forms.TabPage tabPage2;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
		private System.Windows.Forms.ToolStripButton tsResendFTP;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private System.Windows.Forms.TabPage tpITVSummary;
		private CommonWinCtrls.ucGridEx grdITVSummary;
		private CommonWinCtrls.ucMultiColumnCombo cmbStatusCodes;
		private WinCtrls.ucLocationCombo cmbPOL;
		private WinCtrls.ucLocationCombo cmbPOD;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucTextBox txtDays;
		private CommonWinCtrls.ucButton btnResend;
	}
}