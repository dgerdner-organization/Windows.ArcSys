namespace CS2010.ArcSys.Win
{
    partial class frmCargoSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoSearch));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbMoveType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tsCargo = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbViewCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRefreshResults = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.grpOptions = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCheckBoxCombo();
            this.cmbMoveType = new CS2010.ArcSys.WinCtrls.ucMoveTypeCheckBoxCombo();
            this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCustomerRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtEDIRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBolNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.fixDataProblemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOptions)).BeginInit();
            this.grpOptions.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.sbrChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsCargo
            // 
            this.tsCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.tsbClear,
            this.tbbN1,
            this.tsbOptions,
            this.tbbN2,
            this.tsbClose});
            this.tsCargo.Location = new System.Drawing.Point(0, 0);
            this.tsCargo.Name = "tsCargo";
            this.tsCargo.Size = new System.Drawing.Size(1006, 25);
            this.tsCargo.TabIndex = 3;
            this.tsCargo.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(44, 22);
            this.tsbSearch.Text = "&Search";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(36, 22);
            this.tsbClear.Text = "&Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tbbN1
            // 
            this.tbbN1.Name = "tbbN1";
            this.tbbN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbViewCargo,
            this.tsbRefreshResults,
            this.fixDataProblemsToolStripMenuItem});
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(57, 22);
            this.tsbOptions.Text = "&Options";
            // 
            // tsbViewCargo
            // 
            this.tsbViewCargo.Name = "tsbViewCargo";
            this.tsbViewCargo.Size = new System.Drawing.Size(171, 22);
            this.tsbViewCargo.Text = "View Cargo";
            this.tsbViewCargo.Click += new System.EventHandler(this.tsbViewCargo_Click);
            // 
            // tsbRefreshResults
            // 
            this.tsbRefreshResults.Name = "tsbRefreshResults";
            this.tsbRefreshResults.Size = new System.Drawing.Size(171, 22);
            this.tsbRefreshResults.Text = "Refresh Results";
            this.tsbRefreshResults.Click += new System.EventHandler(this.tsbRefreshResults_Click);
            // 
            // tbbN2
            // 
            this.tbbN2.Name = "tbbN2";
            this.tbbN2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(37, 22);
            this.tsbClose.Text = "&Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.grpOptions.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOptions.ExpandedSize = new System.Drawing.Size(1006, 132);
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 10F;
            this.grpOptions.HeaderAppearance = appearance1;
            this.grpOptions.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.FontData.SizeInPoints = 10F;
            this.grpOptions.HeaderCollapsedAppearance = appearance2;
            this.grpOptions.Location = new System.Drawing.Point(0, 25);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(1006, 132);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.Text = "Search Criteria ...";
            this.grpOptions.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpOptions.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbVessel);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbMoveType);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPLOD);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPOD);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPOL);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPLOR);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtVoyage);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtCustomerRef);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtEDIRef);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBolNo);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBookingRef);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBookingNo);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtSerialNo);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 20);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(1000, 109);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // cmbVessel
            // 
            this.cmbVessel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbVessel.CodeColumn = "Vessel_Cd";
            this.cmbVessel.DescriptionColumn = "Vessel_Nm";
            cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
            this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
            this.cmbVessel.DropDownButtonsVisible = false;
            this.cmbVessel.DropDownDisplayMember = "Vessel_Cd";
            this.cmbVessel.DropDownValueMember = "Vessel_Cd";
            this.cmbVessel.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbVessel.LabelText = "&Vessel";
            this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVessel.Location = new System.Drawing.Point(522, 34);
            this.cmbVessel.Name = "cmbVessel";
            this.cmbVessel.SaveSettings = false;
            this.cmbVessel.Size = new System.Drawing.Size(142, 20);
            this.cmbVessel.TabIndex = 19;
            this.cmbVessel.ValueColumn = "Vessel_Cd";
            this.cmbVessel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
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
            this.cmbMoveType.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbMoveType.LabelText = "&Move Type";
            this.cmbMoveType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMoveType.Location = new System.Drawing.Point(522, 8);
            this.cmbMoveType.Name = "cmbMoveType";
            this.cmbMoveType.SaveSettings = false;
            this.cmbMoveType.Size = new System.Drawing.Size(142, 20);
            this.cmbMoveType.TabIndex = 17;
            this.cmbMoveType.ValueColumn = "Code";
            this.cmbMoveType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
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
            this.cmbPLOD.DropDownDisplayMember = "Location_Cd";
            this.cmbPLOD.DropDownValueMember = "Location_Cd";
            this.cmbPLOD.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPLOD.LabelText = "&PLOD";
            this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOD.Location = new System.Drawing.Point(298, 86);
            this.cmbPLOD.Name = "cmbPLOD";
            this.cmbPLOD.SaveSettings = false;
            this.cmbPLOD.Size = new System.Drawing.Size(142, 20);
            this.cmbPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOD.TabIndex = 15;
            this.cmbPLOD.ValueColumn = "Location_Cd";
            this.cmbPLOD.ValuesDataMember = null;
            this.cmbPLOD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
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
            this.cmbPOD.DropDownDisplayMember = "Location_Cd";
            this.cmbPOD.DropDownValueMember = "Location_Cd";
            this.cmbPOD.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPOD.LabelText = "PO&D";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(298, 60);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.SaveSettings = false;
            this.cmbPOD.Size = new System.Drawing.Size(142, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 13;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValuesDataMember = null;
            this.cmbPOD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
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
            this.cmbPOL.DropDownDisplayMember = "Location_Cd";
            this.cmbPOL.DropDownValueMember = "Location_Cd";
            this.cmbPOL.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPOL.LabelText = "PO&L";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(298, 34);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.SaveSettings = false;
            this.cmbPOL.Size = new System.Drawing.Size(142, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 11;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValuesDataMember = null;
            this.cmbPOL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // cmbPLOR
            // 
            this.cmbPLOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbPLOR.CodeColumn = "Location_Cd";
            this.cmbPLOR.DescriptionColumn = "Location_Dsc";
            cmbPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOR_DesignTimeLayout.LayoutString");
            this.cmbPLOR.DesignTimeLayout = cmbPLOR_DesignTimeLayout;
            this.cmbPLOR.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPLOR.DropDownButtonsVisible = false;
            this.cmbPLOR.DropDownDisplayMember = "Location_Cd";
            this.cmbPLOR.DropDownValueMember = "Location_Cd";
            this.cmbPLOR.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPLOR.LabelText = "PLO&R";
            this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOR.Location = new System.Drawing.Point(298, 8);
            this.cmbPLOR.Name = "cmbPLOR";
            this.cmbPLOR.SaveSettings = false;
            this.cmbPLOR.Size = new System.Drawing.Size(142, 20);
            this.cmbPLOR.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOR.TabIndex = 9;
            this.cmbPLOR.ValueColumn = "Location_Cd";
            this.cmbPLOR.ValuesDataMember = null;
            this.cmbPLOR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVoyage.LabelText = "&Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(64, 86);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(185, 20);
            this.txtVoyage.TabIndex = 7;
            this.txtVoyage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtCustomerRef
            // 
            this.txtCustomerRef.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtCustomerRef.LabelText = "&PCFN";
            this.txtCustomerRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomerRef.LinkDisabledMessage = "Link Disabled";
            this.txtCustomerRef.Location = new System.Drawing.Point(64, 60);
            this.txtCustomerRef.Name = "txtCustomerRef";
            this.txtCustomerRef.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerRef.TabIndex = 5;
            this.txtCustomerRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtEDIRef
            // 
            this.txtEDIRef.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtEDIRef.LabelText = "EDI Ref";
            this.txtEDIRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtEDIRef.LinkDisabledMessage = "Link Disabled";
            this.txtEDIRef.Location = new System.Drawing.Point(716, 8);
            this.txtEDIRef.Name = "txtEDIRef";
            this.txtEDIRef.Size = new System.Drawing.Size(142, 20);
            this.txtEDIRef.TabIndex = 25;
            this.txtEDIRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtBolNo
            // 
            this.txtBolNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBolNo.LabelText = "BOL #";
            this.txtBolNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBolNo.LinkDisabledMessage = "Link Disabled";
            this.txtBolNo.Location = new System.Drawing.Point(522, 86);
            this.txtBolNo.Name = "txtBolNo";
            this.txtBolNo.Size = new System.Drawing.Size(142, 20);
            this.txtBolNo.TabIndex = 23;
            this.txtBolNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtBookingRef
            // 
            this.txtBookingRef.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingRef.LabelText = "Booking Ref";
            this.txtBookingRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingRef.LinkDisabledMessage = "Link Disabled";
            this.txtBookingRef.Location = new System.Drawing.Point(522, 60);
            this.txtBookingRef.Name = "txtBookingRef";
            this.txtBookingRef.Size = new System.Drawing.Size(142, 20);
            this.txtBookingRef.TabIndex = 21;
            this.txtBookingRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingNo.LabelText = "&Booking #";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(64, 34);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(185, 20);
            this.txtBookingNo.TabIndex = 3;
            this.txtBookingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerialNo.LabelText = "Serial No:";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(64, 8);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(185, 20);
            this.txtSerialNo.TabIndex = 1;
            this.txtSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // grdCargo
            // 
            this.grdCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.DisplayFieldChooser = true;
            this.grdCargo.DisplayFieldChooserChildren = true;
            this.grdCargo.DisplayFontSelector = true;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargo.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdCargo.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCargo.Hierarchical = true;
            this.grdCargo.Location = new System.Drawing.Point(0, 157);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(1006, 557);
            this.grdCargo.TabIndex = 61;
            this.grdCargo.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
            this.grdCargo.DoubleClick += new System.EventHandler(this.grdCargo_DoubleClick);
            this.grdCargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 644);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(871, 22);
            this.sbrChild.TabIndex = 62;
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
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // fixDataProblemsToolStripMenuItem
            // 
            this.fixDataProblemsToolStripMenuItem.Name = "fixDataProblemsToolStripMenuItem";
            this.fixDataProblemsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fixDataProblemsToolStripMenuItem.Text = "Fix Data Problems";
            this.fixDataProblemsToolStripMenuItem.Click += new System.EventHandler(this.fixDataProblemsToolStripMenuItem_Click);
            // 
            // frmCargoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 714);
            this.Controls.Add(this.grdCargo);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.tsCargo);
            this.MergeToolbar = this.tsCargo;
            this.Name = "frmCargoSearch";
            this.Text = "Cargo Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmCargoSearch_Load);
            this.tsCargo.ResumeLayout(false);
            this.tsCargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOptions)).EndInit();
            this.grpOptions.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStrip tsCargo;
        private System.Windows.Forms.ToolStripDropDownButton tsbOptions;
        private System.Windows.Forms.ToolStripMenuItem tsbViewCargo;
        private System.Windows.Forms.ToolStripMenuItem tsbRefreshResults;
        private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tbbN2;
        private Infragistics.Win.Misc.UltraExpandableGroupBox grpOptions;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
		private CommonWinCtrls.ucTextBox txtVoyage;
        private CommonWinCtrls.ucTextBox txtCustomerRef;
        private CommonWinCtrls.ucTextBox txtEDIRef;
        private CommonWinCtrls.ucTextBox txtBolNo;
        private CommonWinCtrls.ucTextBox txtBookingRef;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucTextBox txtSerialNo;
        private CommonWinCtrls.ucGridEx grdCargo;
		private WinCtrls.ucVesselCheckBoxCombo cmbVessel;
		private WinCtrls.ucMoveTypeCheckBoxCombo cmbMoveType;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOL;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOR;
		private System.Windows.Forms.ToolStripButton tsbSearch;
		private System.Windows.Forms.ToolStripButton tsbClear;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private System.Windows.Forms.ToolStripMenuItem fixDataProblemsToolStripMenuItem;
    }
}