namespace CS2010.ArcSys.Win
{
    partial class frmLINEQuery
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
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLINEQuery));
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdOceanMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdOceanBols_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsSearchCargo = new System.Windows.Forms.ToolStripButton();
            this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.txtBolNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.rbOcean = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbLINE = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbOceanBOLs = new CS2010.CommonWinCtrls.ucRadioButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.txtTCN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.tpOcean = new System.Windows.Forms.TabPage();
            this.grdOceanMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpOceanBills = new System.Windows.Forms.TabPage();
            this.grdOceanBols = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
            this.grpResendOceanBOL = new CS2010.CommonWinCtrls.ucGroupBox();
            this.btnResend315 = new CS2010.CommonWinCtrls.ucButton();
            this.btnResend310 = new CS2010.CommonWinCtrls.ucButton();
            this.tpLINE = new System.Windows.Forms.TabPage();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.tsGrdCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
            this.ucSplitContainer1.Panel1.SuspendLayout();
            this.ucSplitContainer1.Panel2.SuspendLayout();
            this.ucSplitContainer1.SuspendLayout();
            this.ucGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            this.TabMain.SuspendLayout();
            this.tpOcean.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanMain)).BeginInit();
            this.tpOceanBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanBols)).BeginInit();
            this.ucPanel2.SuspendLayout();
            this.grpResendOceanBOL.SuspendLayout();
            this.tpLINE.SuspendLayout();
            this.sbrChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCargo
            // 
            this.grdCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargo.Location = new System.Drawing.Point(3, 3);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(1103, 398);
            this.grdCargo.TabIndex = 0;
            this.grdCargo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
            this.grdCargo.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_ColumnButtonClick);
            this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
            // 
            // tsGrdCargo
            // 
            this.tsGrdCargo.GridObject = null;
            this.tsGrdCargo.HideAddButton = true;
            this.tsGrdCargo.HideDeleteButton = true;
            this.tsGrdCargo.HideEditButton = true;
            this.tsGrdCargo.HideExportMenu = true;
            this.tsGrdCargo.HidePrintMenu = true;
            this.tsGrdCargo.HideSeparator = true;
            this.tsGrdCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearchCargo});
            this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
            this.tsGrdCargo.Name = "tsGrdCargo";
            this.tsGrdCargo.Size = new System.Drawing.Size(1117, 25);
            this.tsGrdCargo.TabIndex = 1;
            this.tsGrdCargo.Text = "ucGridToolStrip1";
            // 
            // tsSearchCargo
            // 
            this.tsSearchCargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSearchCargo.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchCargo.Image")));
            this.tsSearchCargo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchCargo.Name = "tsSearchCargo";
            this.tsSearchCargo.Size = new System.Drawing.Size(44, 22);
            this.tsSearchCargo.Text = "Search";
            this.tsSearchCargo.Click += new System.EventHandler(this.tsSearchCargo_Click);
            // 
            // ucSplitContainer1
            // 
            this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.ucSplitContainer1.Name = "ucSplitContainer1";
            this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer1.Panel1
            // 
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtBolNo);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnClear);
            this.ucSplitContainer1.Panel1.Controls.Add(this.ucGroupBox1);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cmbPOD);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cmbPOL);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtTCN);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtBookingNo);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtVoyage);
            this.ucSplitContainer1.Panel1.Controls.Add(this.tsGrdCargo);
            // 
            // ucSplitContainer1.Panel2
            // 
            this.ucSplitContainer1.Panel2.Controls.Add(this.TabMain);
            this.ucSplitContainer1.Size = new System.Drawing.Size(1117, 551);
            this.ucSplitContainer1.SplitterDistance = 117;
            this.ucSplitContainer1.TabIndex = 2;
            // 
            // txtBolNo
            // 
            this.txtBolNo.LabelText = "BOL#";
            this.txtBolNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBolNo.LinkDisabledMessage = "Link Disabled";
            this.txtBolNo.Location = new System.Drawing.Point(61, 81);
            this.txtBolNo.Name = "txtBolNo";
            this.txtBolNo.Size = new System.Drawing.Size(169, 20);
            this.txtBolNo.TabIndex = 14;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(724, 62);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.rbOcean);
            this.ucGroupBox1.Controls.Add(this.rbLINE);
            this.ucGroupBox1.Controls.Add(this.rbOceanBOLs);
            this.ucGroupBox1.Location = new System.Drawing.Point(490, 29);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(201, 85);
            this.ucGroupBox1.TabIndex = 12;
            this.ucGroupBox1.TabStop = false;
            this.ucGroupBox1.Text = "Ocean System";
            // 
            // rbOcean
            // 
            this.rbOcean.Checked = true;
            this.rbOcean.Location = new System.Drawing.Point(10, 14);
            this.rbOcean.Name = "rbOcean";
            this.rbOcean.Size = new System.Drawing.Size(159, 24);
            this.rbOcean.TabIndex = 9;
            this.rbOcean.TabStop = true;
            this.rbOcean.Text = "ARC-OCEAN Bookings";
            this.rbOcean.UseVisualStyleBackColor = true;
            this.rbOcean.CheckedChanged += new System.EventHandler(this.rbLINE_CheckedChanged);
            // 
            // rbLINE
            // 
            this.rbLINE.Location = new System.Drawing.Point(12, 59);
            this.rbLINE.Name = "rbLINE";
            this.rbLINE.Size = new System.Drawing.Size(140, 24);
            this.rbLINE.TabIndex = 10;
            this.rbLINE.Text = "LINE Bookings";
            this.rbLINE.UseVisualStyleBackColor = true;
            this.rbLINE.CheckedChanged += new System.EventHandler(this.rbLINE_CheckedChanged);
            // 
            // rbOceanBOLs
            // 
            this.rbOceanBOLs.Location = new System.Drawing.Point(11, 36);
            this.rbOceanBOLs.Name = "rbOceanBOLs";
            this.rbOceanBOLs.Size = new System.Drawing.Size(159, 24);
            this.rbOceanBOLs.TabIndex = 11;
            this.rbOceanBOLs.Text = "ARC-OCEAN BOLs";
            this.rbOceanBOLs.UseVisualStyleBackColor = true;
            this.rbOceanBOLs.CheckedChanged += new System.EventHandler(this.rbLINE_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(724, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.cmbPOD.Location = new System.Drawing.Point(300, 79);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(168, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 7;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValueMember = "Location_Cd";
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
            this.cmbPOL.Location = new System.Drawing.Point(300, 55);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(168, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 6;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // txtTCN
            // 
            this.txtTCN.LabelText = "Serial#";
            this.txtTCN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTCN.LinkDisabledMessage = "Link Disabled";
            this.txtTCN.Location = new System.Drawing.Point(299, 32);
            this.txtTCN.Name = "txtTCN";
            this.txtTCN.Size = new System.Drawing.Size(169, 20);
            this.txtTCN.TabIndex = 4;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(61, 57);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(169, 20);
            this.txtBookingNo.TabIndex = 3;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(61, 33);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(64, 20);
            this.txtVoyage.TabIndex = 2;
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.tpOcean);
            this.TabMain.Controls.Add(this.tpOceanBills);
            this.TabMain.Controls.Add(this.tpLINE);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(0, 0);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(1117, 430);
            this.TabMain.TabIndex = 0;
            // 
            // tpOcean
            // 
            this.tpOcean.Controls.Add(this.grdOceanMain);
            this.tpOcean.Location = new System.Drawing.Point(4, 22);
            this.tpOcean.Name = "tpOcean";
            this.tpOcean.Padding = new System.Windows.Forms.Padding(3);
            this.tpOcean.Size = new System.Drawing.Size(1109, 404);
            this.tpOcean.TabIndex = 0;
            this.tpOcean.Text = "ARC-OCEAN Bookings";
            this.tpOcean.UseVisualStyleBackColor = true;
            // 
            // grdOceanMain
            // 
            this.grdOceanMain.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdOceanMain_DesignTimeLayout.LayoutString = resources.GetString("grdOceanMain_DesignTimeLayout.LayoutString");
            this.grdOceanMain.DesignTimeLayout = grdOceanMain_DesignTimeLayout;
            this.grdOceanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOceanMain.ExportFileID = null;
            this.grdOceanMain.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdOceanMain.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdOceanMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdOceanMain.Location = new System.Drawing.Point(3, 3);
            this.grdOceanMain.Name = "grdOceanMain";
            this.grdOceanMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdOceanMain.Size = new System.Drawing.Size(1103, 398);
            this.grdOceanMain.TabIndex = 1;
            this.grdOceanMain.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdOceanMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdOceanMain.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdOceanMain_RowCheckStateChanged);
            this.grdOceanMain.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdOceanMain_FormattingRow);
            this.grdOceanMain.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdOceanMain_ColumnButtonClick);
            this.grdOceanMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdOceanMain_LinkClicked);
            // 
            // tpOceanBills
            // 
            this.tpOceanBills.Controls.Add(this.grdOceanBols);
            this.tpOceanBills.Controls.Add(this.ucPanel2);
            this.tpOceanBills.Location = new System.Drawing.Point(4, 22);
            this.tpOceanBills.Name = "tpOceanBills";
            this.tpOceanBills.Padding = new System.Windows.Forms.Padding(3);
            this.tpOceanBills.Size = new System.Drawing.Size(1109, 404);
            this.tpOceanBills.TabIndex = 2;
            this.tpOceanBills.Text = "ARC-OCEAN BOLs";
            this.tpOceanBills.UseVisualStyleBackColor = true;
            // 
            // grdOceanBols
            // 
            grdOceanBols_DesignTimeLayout.LayoutString = resources.GetString("grdOceanBols_DesignTimeLayout.LayoutString");
            this.grdOceanBols.DesignTimeLayout = grdOceanBols_DesignTimeLayout;
            this.grdOceanBols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOceanBols.ExportFileID = null;
            this.grdOceanBols.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdOceanBols.Location = new System.Drawing.Point(3, 67);
            this.grdOceanBols.Name = "grdOceanBols";
            this.grdOceanBols.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdOceanBols.Size = new System.Drawing.Size(1103, 334);
            this.grdOceanBols.TabIndex = 0;
            this.grdOceanBols.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdOceanBols.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdOceanBols.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdOceanBols_RowCheckStateChanged);
            // 
            // ucPanel2
            // 
            this.ucPanel2.Controls.Add(this.grpResendOceanBOL);
            this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel2.Location = new System.Drawing.Point(3, 3);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(1103, 64);
            this.ucPanel2.TabIndex = 1;
            // 
            // grpResendOceanBOL
            // 
            this.grpResendOceanBOL.Controls.Add(this.btnResend315);
            this.grpResendOceanBOL.Controls.Add(this.btnResend310);
            this.grpResendOceanBOL.Location = new System.Drawing.Point(2, -1);
            this.grpResendOceanBOL.Name = "grpResendOceanBOL";
            this.grpResendOceanBOL.Size = new System.Drawing.Size(337, 59);
            this.grpResendOceanBOL.TabIndex = 0;
            this.grpResendOceanBOL.TabStop = false;
            this.grpResendOceanBOL.Text = "Resend WWL EDI";
            // 
            // btnResend315
            // 
            this.btnResend315.Location = new System.Drawing.Point(153, 23);
            this.btnResend315.Name = "btnResend315";
            this.btnResend315.Size = new System.Drawing.Size(165, 23);
            this.btnResend315.TabIndex = 1;
            this.btnResend315.Text = "Resend 315 Carrier Release";
            this.btnResend315.UseVisualStyleBackColor = true;
            this.btnResend315.Click += new System.EventHandler(this.btnResend315_Click);
            // 
            // btnResend310
            // 
            this.btnResend310.Location = new System.Drawing.Point(14, 23);
            this.btnResend310.Name = "btnResend310";
            this.btnResend310.Size = new System.Drawing.Size(135, 23);
            this.btnResend310.TabIndex = 0;
            this.btnResend310.Text = "Resend 310 as New";
            this.btnResend310.UseVisualStyleBackColor = true;
            this.btnResend310.Click += new System.EventHandler(this.btnResend310_Click);
            // 
            // tpLINE
            // 
            this.tpLINE.Controls.Add(this.grdCargo);
            this.tpLINE.Location = new System.Drawing.Point(4, 22);
            this.tpLINE.Name = "tpLINE";
            this.tpLINE.Padding = new System.Windows.Forms.Padding(3);
            this.tpLINE.Size = new System.Drawing.Size(1109, 404);
            this.tpLINE.TabIndex = 1;
            this.tpLINE.Text = "LINE Bookings";
            this.tpLINE.UseVisualStyleBackColor = true;
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 474);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(782, 22);
            this.sbrChild.TabIndex = 5;
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
            // frmLINEQuery
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 551);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.ucSplitContainer1);
            this.Name = "frmLINEQuery";
            this.Text = "LINE and ARC-OCEAN Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesSummary_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesSummary_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.tsGrdCargo.ResumeLayout(false);
            this.tsGrdCargo.PerformLayout();
            this.ucSplitContainer1.Panel1.ResumeLayout(false);
            this.ucSplitContainer1.Panel1.PerformLayout();
            this.ucSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
            this.ucSplitContainer1.ResumeLayout(false);
            this.ucGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.tpOcean.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanMain)).EndInit();
            this.tpOceanBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanBols)).EndInit();
            this.ucPanel2.ResumeLayout(false);
            this.grpResendOceanBOL.ResumeLayout(false);
            this.tpLINE.ResumeLayout(false);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdCargo;
        private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private System.Windows.Forms.ToolStripButton tsSearchCargo;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private CommonWinCtrls.ucTextBox txtTCN;
        private CommonWinCtrls.ucTextBox txtBookingNo;
        private CommonWinCtrls.ucTextBox txtVoyage;
		private WinCtrls.ucLocationCombo cmbPOL;
		private WinCtrls.ucLocationCombo cmbPOD;
        private CommonWinCtrls.ucButton btnSearch;
        private CommonWinCtrls.ucRadioButton rbOcean;
		private System.Windows.Forms.TabControl TabMain;
		private System.Windows.Forms.TabPage tpOcean;
		private CommonWinCtrls.ucGridEx grdOceanMain;
        private System.Windows.Forms.TabPage tpLINE;
        private CommonWinCtrls.ucGroupBox ucGroupBox1;
        private CommonWinCtrls.ucRadioButton rbLINE;
        private CommonWinCtrls.ucRadioButton rbOceanBOLs;
        private System.Windows.Forms.TabPage tpOceanBills;
        private CommonWinCtrls.ucGridEx grdOceanBols;
        private CommonWinCtrls.ucPanel ucPanel2;
        private CommonWinCtrls.ucGroupBox grpResendOceanBOL;
        private CommonWinCtrls.ucButton btnResend315;
        private CommonWinCtrls.ucButton btnResend310;
        private CommonWinCtrls.ucButton btnClear;
        private CommonWinCtrls.ucTextBox txtBolNo;

    }
}