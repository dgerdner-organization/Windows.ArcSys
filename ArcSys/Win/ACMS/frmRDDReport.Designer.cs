namespace CS2010.ArcSys.Win
{
	partial class frmRDDReport
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
			Janus.Windows.GridEX.GridEXLayout cmbVoyages_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbMoveType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRDDReport));
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.cmbVoyages = new CS2010.ArcSys.WinCtrls.ucVoyageCheckBoxCombo();
			this.dateRDDRange = new CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy();
			this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbMoveType = new CS2010.ArcSys.WinCtrls.ucMoveTypeCheckBoxCombo();
			this.cmbVessel = new CS2010.AVSS.WinCtrls.ucVesselCombo();
			this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.btnSearch = new Infragistics.Win.Misc.UltraButton();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
			this.grpSearch.SuspendLayout();
			this.grpSearchPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).BeginInit();
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
			appearance1.BackColor = System.Drawing.SystemColors.Control;
			appearance1.BackColor2 = System.Drawing.SystemColors.Control;
			this.grpSearch.Appearance = appearance1;
			this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
			appearance2.BackColor = System.Drawing.SystemColors.Control;
			appearance2.BackColor2 = System.Drawing.SystemColors.Control;
			this.grpSearch.ContentAreaAppearance = appearance2;
			this.grpSearch.Controls.Add(this.grpSearchPanel);
			this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 129);
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
			this.grpSearch.Size = new System.Drawing.Size(992, 129);
			this.grpSearch.TabIndex = 0;
			this.grpSearch.Text = "Search Options";
			this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
			// 
			// grpSearchPanel
			// 
			this.grpSearchPanel.Controls.Add(this.cmbPOL);
			this.grpSearchPanel.Controls.Add(this.cmbVoyages);
			this.grpSearchPanel.Controls.Add(this.dateRDDRange);
			this.grpSearchPanel.Controls.Add(this.cmbPLOD);
			this.grpSearchPanel.Controls.Add(this.cmbPOD);
			this.grpSearchPanel.Controls.Add(this.cmbMoveType);
			this.grpSearchPanel.Controls.Add(this.cmbVessel);
			this.grpSearchPanel.Controls.Add(this.txtPCFN);
			this.grpSearchPanel.Controls.Add(this.btnClear);
			this.grpSearchPanel.Controls.Add(this.btnSearch);
			this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
			this.grpSearchPanel.Name = "grpSearchPanel";
			this.grpSearchPanel.Size = new System.Drawing.Size(986, 105);
			this.grpSearchPanel.TabIndex = 0;
			// 
			// cmbVoyages
			// 
			this.cmbVoyages.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbVoyages.CodeColumn = "Voyage_Cd";
			this.cmbVoyages.DescriptionColumn = "Vessel_Cd";
			cmbVoyages_DesignTimeLayout.LayoutString = resources.GetString("cmbVoyages_DesignTimeLayout.LayoutString");
			this.cmbVoyages.DesignTimeLayout = cmbVoyages_DesignTimeLayout;
			this.cmbVoyages.DropDownButtonsVisible = false;
			this.cmbVoyages.DropDownDisplayMember = "Voyage_Cd";
			this.cmbVoyages.DropDownValueMember = "Voyage_Cd";
			this.cmbVoyages.LabelText = "Voyage(s)";
			this.cmbVoyages.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVoyages.Location = new System.Drawing.Point(78, 29);
			this.cmbVoyages.Name = "cmbVoyages";
			this.cmbVoyages.SaveSettings = false;
			this.cmbVoyages.Size = new System.Drawing.Size(127, 20);
			this.cmbVoyages.TabIndex = 19;
			this.cmbVoyages.ValueColumn = "Voyage_Cd";
			// 
			// dateRDDRange
			// 
			this.dateRDDRange.CheckBoxText = "RDD Dates (mmddyy)";
			this.dateRDDRange.Location = new System.Drawing.Point(233, 3);
			this.dateRDDRange.Name = "dateRDDRange";
			this.dateRDDRange.Size = new System.Drawing.Size(136, 76);
			this.dateRDDRange.TabIndex = 18;
			// 
			// cmbPLOD
			// 
			this.cmbPLOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPLOD.CodeColumn = "Location_Cd";
			this.cmbPLOD.DescriptionColumn = "Location_Dsc";
			cmbPLOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOD_DesignTimeLayout.LayoutString");
			this.cmbPLOD.DesignTimeLayout = cmbPLOD_DesignTimeLayout;
			this.cmbPLOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPLOD.DropDownButtonsVisible = false;
			this.cmbPLOD.DropDownDisplayMember = "Location_Dsc";
			this.cmbPLOD.DropDownValueMember = "Location_Cd";
			this.cmbPLOD.LabelText = "PLOD(s)";
			this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPLOD.Location = new System.Drawing.Point(438, 51);
			this.cmbPLOD.Name = "cmbPLOD";
			this.cmbPLOD.SaveSettings = false;
			this.cmbPLOD.Size = new System.Drawing.Size(208, 20);
			this.cmbPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPLOD.TabIndex = 17;
			this.cmbPLOD.ValueColumn = "Location_Cd";
			this.cmbPLOD.ValuesDataMember = null;
			// 
			// cmbPOD
			// 
			this.cmbPOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOD.CodeColumn = "Location_Cd";
			this.cmbPOD.DescriptionColumn = "Location_Dsc";
			cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
			this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
			this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOD.DropDownButtonsVisible = false;
			this.cmbPOD.DropDownDisplayMember = "Location_Dsc";
			this.cmbPOD.DropDownValueMember = "Location_Cd";
			this.cmbPOD.LabelText = "POD(s)";
			this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOD.Location = new System.Drawing.Point(438, 28);
			this.cmbPOD.Name = "cmbPOD";
			this.cmbPOD.PortsOnly = true;
			this.cmbPOD.SaveSettings = false;
			this.cmbPOD.Size = new System.Drawing.Size(208, 20);
			this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOD.TabIndex = 16;
			this.cmbPOD.ValueColumn = "Location_Cd";
			this.cmbPOD.ValuesDataMember = null;
			// 
			// cmbMoveType
			// 
			this.cmbMoveType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbMoveType.CodeColumn = "Code";
			this.cmbMoveType.DescriptionColumn = "Description";
			cmbMoveType_DesignTimeLayout.LayoutString = resources.GetString("cmbMoveType_DesignTimeLayout.LayoutString");
			this.cmbMoveType.DesignTimeLayout = cmbMoveType_DesignTimeLayout;
			this.cmbMoveType.DropDownButtonsVisible = false;
			this.cmbMoveType.DropDownDataSource = new CS2010.Common.ComboItem[] {
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource1"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource2"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource3"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource4"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource5"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource6"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource7"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource8")))};
			this.cmbMoveType.DropDownDisplayMember = "Code";
			this.cmbMoveType.DropDownValueMember = "Code";
			this.cmbMoveType.LabelText = "Terms";
			this.cmbMoveType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMoveType.Location = new System.Drawing.Point(78, 52);
			this.cmbMoveType.Name = "cmbMoveType";
			this.cmbMoveType.SaveSettings = false;
			this.cmbMoveType.Size = new System.Drawing.Size(127, 20);
			this.cmbMoveType.TabIndex = 15;
			this.cmbMoveType.ValueColumn = "Code";
			// 
			// cmbVessel
			// 
			this.cmbVessel.CodeColumn = "VESSEL_CD";
			this.cmbVessel.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
			this.cmbVessel.DescriptionColumn = "VESSEL_NM";
			cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
			this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
			this.cmbVessel.DisplayMember = "VESSEL_CDVESSEL_NM";
			this.cmbVessel.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbVessel.LabelText = "Vessel";
			this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVessel.Location = new System.Drawing.Point(78, 6);
			this.cmbVessel.Name = "cmbVessel";
			this.cmbVessel.SelectedCdNm = null;
			this.cmbVessel.SelectedIndex = -1;
			this.cmbVessel.SelectedItem = null;
			this.cmbVessel.ShowOnlyARCVessels = true;
			this.cmbVessel.Size = new System.Drawing.Size(127, 20);
			this.cmbVessel.TabIndex = 14;
			this.cmbVessel.ValueColumn = "VESSEL_CD";
			this.cmbVessel.ValueMember = "VESSEL_CD";
			this.cmbVessel.ValueChanged += new System.EventHandler(this.cmbVessel_ValueChanged);
			// 
			// txtPCFN
			// 
			this.txtPCFN.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtPCFN.LabelText = "PCFN(s)";
			this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPCFN.LinkDisabledMessage = "Link Disabled";
			this.txtPCFN.Location = new System.Drawing.Point(438, 74);
			this.txtPCFN.Name = "txtPCFN";
			this.txtPCFN.Size = new System.Drawing.Size(208, 20);
			this.txtPCFN.TabIndex = 3;
			// 
			// btnClear
			// 
			this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
			this.btnClear.Location = new System.Drawing.Point(902, 73);
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
			this.btnSearch.Location = new System.Drawing.Point(821, 73);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
			this.tabMain.Location = new System.Drawing.Point(0, 154);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(992, 562);
			this.tabMain.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grdMain);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(984, 536);
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
			this.grdMain.Size = new System.Drawing.Size(978, 530);
			this.grdMain.TabIndex = 2;
			this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
			// 
			// cmbPOL
			// 
			this.cmbPOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOL.CodeColumn = "Location_Cd";
			this.cmbPOL.DescriptionColumn = "Location_Dsc";
			cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
			this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
			this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOL.DropDownButtonsVisible = false;
			this.cmbPOL.DropDownDisplayMember = "Location_Dsc";
			this.cmbPOL.DropDownValueMember = "Location_Cd";
			this.cmbPOL.LabelText = "POL(s)";
			this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOL.Location = new System.Drawing.Point(438, 5);
			this.cmbPOL.Name = "cmbPOL";
			this.cmbPOL.PortsOnly = true;
			this.cmbPOL.SaveSettings = false;
			this.cmbPOL.Size = new System.Drawing.Size(208, 20);
			this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOL.TabIndex = 20;
			this.cmbPOL.ValueColumn = "Location_Cd";
			this.cmbPOL.ValuesDataMember = null;
			// 
			// frmRDDReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmRDDReport";
			this.Text = "RDD Report";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearchPanel.ResumeLayout(false);
			this.grpSearchPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).EndInit();
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
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private WinCtrls.ucMoveTypeCheckBoxCombo cmbMoveType;
		private AVSS.WinCtrls.ucVesselCombo cmbVessel;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOD;
		private CommonWinCtrls.ucDateGroupBoxMMddyy dateRDDRange;
		private WinCtrls.ucVoyageCheckBoxCombo cmbVoyages;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOL;
	}
}