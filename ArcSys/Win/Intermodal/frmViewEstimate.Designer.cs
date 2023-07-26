namespace CS2010.ArcSys.Win
{
	partial class frmViewEstimate
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
            Janus.Windows.GridEX.GridEXLayout grdCargoChanges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewEstimate));
            Janus.Windows.GridEX.GridEXLayout grdApCharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdApChargeDtl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdArCharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdArChargeDtl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdAvailableCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("734fafe6-9a68-48ba-afad-aab69d0bf7f0"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("1488c574-bbf4-4434-a046-8df13624b5b6"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("734fafe6-9a68-48ba-afad-aab69d0bf7f0"), 0);
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("2a568266-a95d-4e56-a2ab-3836a592d611"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("0c069e49-2dd3-40d7-8044-6f491d5ca009"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("2a568266-a95d-4e56-a2ab-3836a592d611"), -1);
            this.pnlCargoChanges = new Infragistics.Win.Misc.UltraPanel();
            this.grdCargoChanges = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrChanges = new System.Windows.Forms.ToolStrip();
            this.tbbChangesDismiss = new System.Windows.Forms.ToolStripButton();
            this.rtfBookingNotes = new CS2010.CommonWinCtrls.ucRichTextBox();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbMainTitle = new System.Windows.Forms.ToolStripLabel();
            this.tbbMainOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.cnuOptionsMileage = new System.Windows.Forms.ToolStripMenuItem();
            this.cnuOptionsEstimateDate = new System.Windows.Forms.ToolStripMenuItem();
            this.cnuOptionsN1 = new System.Windows.Forms.ToolStripSeparator();
            this.cnuOptionsDeleteEst = new System.Windows.Forms.ToolStripMenuItem();
            this.cnuOptionsN2 = new System.Windows.Forms.ToolStripSeparator();
            this.cnuOptionsChangeVoyage = new System.Windows.Forms.ToolStripMenuItem();
            this.cnuOptionsRecomputeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cnuOptionsN3 = new System.Windows.Forms.ToolStripSeparator();
            this.cnuOptionsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbMainClose = new System.Windows.Forms.ToolStripButton();
            this.tabEstimateMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpgCharges = new System.Windows.Forms.TabPage();
            this.pnlCharges = new CS2010.CommonWinCtrls.ucPanel();
            this.pnlApCharges = new CS2010.CommonWinCtrls.ucPanel();
            this.grdApCharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.splApChargeDtl = new CS2010.CommonWinCtrls.ucCollapsibleSplitter();
            this.grdApChargeDtl = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrApCharges = new System.Windows.Forms.ToolStrip();
            this.tbbApChargesNew = new System.Windows.Forms.ToolStripButton();
            this.tbbApChargesEdit = new System.Windows.Forms.ToolStripButton();
            this.tbbApChargesN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbApChargesDelete = new System.Windows.Forms.ToolStripButton();
            this.splArCharges = new CS2010.CommonWinCtrls.ucCollapsibleSplitter();
            this.pnlArCharges = new CS2010.CommonWinCtrls.ucPanel();
            this.grdArCharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.splArChargeDtl = new CS2010.CommonWinCtrls.ucCollapsibleSplitter();
            this.grdArChargeDtl = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrArCharges = new System.Windows.Forms.ToolStrip();
            this.tbbArNewLH = new System.Windows.Forms.ToolStripButton();
            this.tbbArChargesNew = new System.Windows.Forms.ToolStripButton();
            this.tbbArChargesFromAp = new System.Windows.Forms.ToolStripButton();
            this.tbbArChargesEdit = new System.Windows.Forms.ToolStripButton();
            this.tbbArChargesN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbArChargesDelete = new System.Windows.Forms.ToolStripButton();
            this.tpgCargo = new System.Windows.Forms.TabPage();
            this.pnlCargo = new Infragistics.Win.Misc.UltraPanel();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrCargo = new System.Windows.Forms.ToolStrip();
            this.tbbCargoAddVendor = new System.Windows.Forms.ToolStripButton();
            this.tbbCargoRemoveVendor = new System.Windows.Forms.ToolStripButton();
            this.tbbCargoN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbCargoAssignMod = new System.Windows.Forms.ToolStripButton();
            this.tbbCargoN2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbCargoRemove = new System.Windows.Forms.ToolStripButton();
            this.tbbCargoRemoveFromCharges = new System.Windows.Forms.ToolStripButton();
            this.tbrCargoN3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbrCargoCheckLINE = new System.Windows.Forms.ToolStripButton();
            this.tbbCargoCheckDup = new System.Windows.Forms.ToolStripButton();
            this.splUnassigned = new Infragistics.Win.Misc.UltraSplitter();
            this.pnlUnassigned = new Infragistics.Win.Misc.UltraPanel();
            this.grdAvailableCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrAvailableCargo = new System.Windows.Forms.ToolStrip();
            this.tbbAvailableCargoAdd = new System.Windows.Forms.ToolStripButton();
            this.tbbAvailableCargoN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAvailableCargoDelete = new System.Windows.Forms.ToolStripButton();
            this.infDockMgr = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._frmChildBaseUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmChildBaseUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmChildBaseUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmChildBaseUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._frmChildBaseAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.bkgCleanup = new System.ComponentModel.BackgroundWorker();
            this.bkgCheckLINE = new System.ComponentModel.BackgroundWorker();
            this.pnlCargoChanges.ClientArea.SuspendLayout();
            this.pnlCargoChanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoChanges)).BeginInit();
            this.tbrChanges.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.tabEstimateMain.SuspendLayout();
            this.tpgCharges.SuspendLayout();
            this.pnlCharges.SuspendLayout();
            this.pnlApCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApChargeDtl)).BeginInit();
            this.tbrApCharges.SuspendLayout();
            this.pnlArCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArChargeDtl)).BeginInit();
            this.tbrArCharges.SuspendLayout();
            this.tpgCargo.SuspendLayout();
            this.pnlCargo.ClientArea.SuspendLayout();
            this.pnlCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.tbrCargo.SuspendLayout();
            this.pnlUnassigned.ClientArea.SuspendLayout();
            this.pnlUnassigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableCargo)).BeginInit();
            this.tbrAvailableCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).BeginInit();
            this._frmChildBaseAutoHideControl.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.windowDockingArea3.SuspendLayout();
            this.sbrChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCargoChanges
            // 
            // 
            // pnlCargoChanges.ClientArea
            // 
            this.pnlCargoChanges.ClientArea.Controls.Add(this.grdCargoChanges);
            this.pnlCargoChanges.ClientArea.Controls.Add(this.tbrChanges);
            this.pnlCargoChanges.Location = new System.Drawing.Point(0, 18);
            this.pnlCargoChanges.Name = "pnlCargoChanges";
            this.pnlCargoChanges.Size = new System.Drawing.Size(1006, 375);
            this.pnlCargoChanges.TabIndex = 1;
            // 
            // grdCargoChanges
            // 
            this.grdCargoChanges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdCargoChanges.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdCargoChanges_DesignTimeLayout.LayoutString = resources.GetString("grdCargoChanges_DesignTimeLayout.LayoutString");
            this.grdCargoChanges.DesignTimeLayout = grdCargoChanges_DesignTimeLayout;
            this.grdCargoChanges.DisplayFieldChooser = true;
            this.grdCargoChanges.DisplayFieldChooserChildren = true;
            this.grdCargoChanges.DisplayFontSelector = true;
            this.grdCargoChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargoChanges.ExportFileID = null;
            this.grdCargoChanges.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCargoChanges.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCargoChanges.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdCargoChanges.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdCargoChanges.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdCargoChanges.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdCargoChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargoChanges.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdCargoChanges.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdCargoChanges.Location = new System.Drawing.Point(0, 25);
            this.grdCargoChanges.Name = "grdCargoChanges";
            this.grdCargoChanges.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargoChanges.Size = new System.Drawing.Size(1006, 350);
            this.grdCargoChanges.TabIndex = 2;
            this.grdCargoChanges.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdCargoChanges.UseGroupRowSelector = true;
            // 
            // tbrChanges
            // 
            this.tbrChanges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbChangesDismiss});
            this.tbrChanges.Location = new System.Drawing.Point(0, 0);
            this.tbrChanges.Name = "tbrChanges";
            this.tbrChanges.Size = new System.Drawing.Size(1006, 25);
            this.tbrChanges.TabIndex = 0;
            this.tbrChanges.Text = "toolStrip1";
            // 
            // tbbChangesDismiss
            // 
            this.tbbChangesDismiss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbChangesDismiss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbChangesDismiss.Name = "tbbChangesDismiss";
            this.tbbChangesDismiss.Size = new System.Drawing.Size(90, 22);
            this.tbbChangesDismiss.Text = "Dismiss Changes";
            this.tbbChangesDismiss.Click += new System.EventHandler(this.tbbChangesDismiss_Click);
            // 
            // rtfBookingNotes
            // 
            this.rtfBookingNotes.BackColor = System.Drawing.SystemColors.Control;
            this.rtfBookingNotes.ForeColor = System.Drawing.Color.Black;
            this.rtfBookingNotes.Location = new System.Drawing.Point(0, 18);
            this.rtfBookingNotes.Name = "rtfBookingNotes";
            this.rtfBookingNotes.ReadOnly = true;
            this.rtfBookingNotes.Size = new System.Drawing.Size(159, 660);
            this.rtfBookingNotes.TabIndex = 1;
            this.rtfBookingNotes.TabStop = false;
            this.rtfBookingNotes.Text = "";
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbMainTitle,
            this.tbbMainOptions,
            this.tbbMainRefresh,
            this.toolStripSeparator1,
            this.tbbMainClose});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(1006, 25);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "Move Window Main Toolbar";
            // 
            // tbbMainTitle
            // 
            this.tbbMainTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbbMainTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbbMainTitle.Name = "tbbMainTitle";
            this.tbbMainTitle.Size = new System.Drawing.Size(272, 22);
            this.tbbMainTitle.Text = "Estimate ID: 1 EST000001 UM102 USBAL USDAL";
            this.tbbMainTitle.Visible = false;
            // 
            // tbbMainOptions
            // 
            this.tbbMainOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbMainOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsMileage,
            this.cnuOptionsEstimateDate,
            this.cnuOptionsN1,
            this.cnuOptionsDeleteEst,
            this.cnuOptionsN2,
            this.cnuOptionsChangeVoyage,
            this.cnuOptionsRecomputeAll,
            this.cnuOptionsN3,
            this.cnuOptionsRefresh});
            this.tbbMainOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbMainOptions.Name = "tbbMainOptions";
            this.tbbMainOptions.Size = new System.Drawing.Size(57, 22);
            this.tbbMainOptions.Text = "&Options";
            // 
            // cnuOptionsMileage
            // 
            this.cnuOptionsMileage.Name = "cnuOptionsMileage";
            this.cnuOptionsMileage.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsMileage.Text = "Edit Mileage";
            this.cnuOptionsMileage.Click += new System.EventHandler(this.cnuOptionsMileage_Click);
            // 
            // cnuOptionsEstimateDate
            // 
            this.cnuOptionsEstimateDate.Name = "cnuOptionsEstimateDate";
            this.cnuOptionsEstimateDate.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsEstimateDate.Text = "Edit Estimate Date";
            this.cnuOptionsEstimateDate.Click += new System.EventHandler(this.cnuOptionsEstimateDate_Click);
            // 
            // cnuOptionsN1
            // 
            this.cnuOptionsN1.Name = "cnuOptionsN1";
            this.cnuOptionsN1.Size = new System.Drawing.Size(202, 6);
            // 
            // cnuOptionsDeleteEst
            // 
            this.cnuOptionsDeleteEst.Name = "cnuOptionsDeleteEst";
            this.cnuOptionsDeleteEst.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsDeleteEst.Text = "Delete Estimate";
            this.cnuOptionsDeleteEst.Click += new System.EventHandler(this.cnuOptionsDeleteEst_Click);
            // 
            // cnuOptionsN2
            // 
            this.cnuOptionsN2.Name = "cnuOptionsN2";
            this.cnuOptionsN2.Size = new System.Drawing.Size(202, 6);
            // 
            // cnuOptionsChangeVoyage
            // 
            this.cnuOptionsChangeVoyage.Name = "cnuOptionsChangeVoyage";
            this.cnuOptionsChangeVoyage.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsChangeVoyage.Text = "Change Estimate Voyage";
            this.cnuOptionsChangeVoyage.Click += new System.EventHandler(this.cnuOptionsChangeVoyage_Click);
            // 
            // cnuOptionsRecomputeAll
            // 
            this.cnuOptionsRecomputeAll.Name = "cnuOptionsRecomputeAll";
            this.cnuOptionsRecomputeAll.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsRecomputeAll.Text = "Recompute All Charges";
            this.cnuOptionsRecomputeAll.Click += new System.EventHandler(this.cnuOptionsRecomputeAll_Click);
            // 
            // cnuOptionsN3
            // 
            this.cnuOptionsN3.Name = "cnuOptionsN3";
            this.cnuOptionsN3.Size = new System.Drawing.Size(202, 6);
            // 
            // cnuOptionsRefresh
            // 
            this.cnuOptionsRefresh.Name = "cnuOptionsRefresh";
            this.cnuOptionsRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.cnuOptionsRefresh.Size = new System.Drawing.Size(205, 22);
            this.cnuOptionsRefresh.Text = "Refresh";
            this.cnuOptionsRefresh.Click += new System.EventHandler(this.cnuOptionsRefresh_Click);
            // 
            // tbbMainRefresh
            // 
            this.tbbMainRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbMainRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbMainRefresh.Name = "tbbMainRefresh";
            this.tbbMainRefresh.Size = new System.Drawing.Size(49, 22);
            this.tbbMainRefresh.Text = "Refresh";
            this.tbbMainRefresh.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // tbbMainClose
            // 
            this.tbbMainClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbMainClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbMainClose.Name = "tbbMainClose";
            this.tbbMainClose.Size = new System.Drawing.Size(37, 22);
            this.tbbMainClose.Text = "Close";
            this.tbbMainClose.Click += new System.EventHandler(this.tbbMainClose_Click);
            // 
            // tabEstimateMain
            // 
            this.tabEstimateMain.Controls.Add(this.tpgCharges);
            this.tabEstimateMain.Controls.Add(this.tpgCargo);
            this.tabEstimateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEstimateMain.Location = new System.Drawing.Point(0, 25);
            this.tabEstimateMain.Name = "tabEstimateMain";
            this.tabEstimateMain.Padding = new System.Drawing.Point(18, 3);
            this.tabEstimateMain.SelectedIndex = 0;
            this.tabEstimateMain.Size = new System.Drawing.Size(842, 678);
            this.tabEstimateMain.TabIndex = 0;
            this.tabEstimateMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabEstimateMain_DrawItem);
            this.tabEstimateMain.SelectedIndexChanged += new System.EventHandler(this.tabEstimateMain_SelectedIndexChanged);
            // 
            // tpgCharges
            // 
            this.tpgCharges.Controls.Add(this.pnlCharges);
            this.tpgCharges.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpgCharges.Location = new System.Drawing.Point(4, 22);
            this.tpgCharges.Name = "tpgCharges";
            this.tpgCharges.Size = new System.Drawing.Size(834, 652);
            this.tpgCharges.TabIndex = 4;
            this.tpgCharges.Text = "Charges";
            this.tpgCharges.UseVisualStyleBackColor = true;
            // 
            // pnlCharges
            // 
            this.pnlCharges.Controls.Add(this.pnlApCharges);
            this.pnlCharges.Controls.Add(this.splArCharges);
            this.pnlCharges.Controls.Add(this.pnlArCharges);
            this.pnlCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharges.Location = new System.Drawing.Point(0, 0);
            this.pnlCharges.Name = "pnlCharges";
            this.pnlCharges.Size = new System.Drawing.Size(834, 652);
            this.pnlCharges.TabIndex = 0;
            this.pnlCharges.Resize += new System.EventHandler(this.pnlCharges_Resize);
            // 
            // pnlApCharges
            // 
            this.pnlApCharges.Controls.Add(this.grdApCharges);
            this.pnlApCharges.Controls.Add(this.splApChargeDtl);
            this.pnlApCharges.Controls.Add(this.grdApChargeDtl);
            this.pnlApCharges.Controls.Add(this.tbrApCharges);
            this.pnlApCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApCharges.Location = new System.Drawing.Point(0, 0);
            this.pnlApCharges.Name = "pnlApCharges";
            this.pnlApCharges.Size = new System.Drawing.Size(433, 652);
            this.pnlApCharges.TabIndex = 0;
            // 
            // grdApCharges
            // 
            this.grdApCharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdApCharges_DesignTimeLayout.LayoutString = resources.GetString("grdApCharges_DesignTimeLayout.LayoutString");
            this.grdApCharges.DesignTimeLayout = grdApCharges_DesignTimeLayout;
            this.grdApCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdApCharges.ExportFileID = null;
            this.grdApCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApCharges.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdApCharges.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApCharges.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdApCharges.Location = new System.Drawing.Point(0, 25);
            this.grdApCharges.Name = "grdApCharges";
            this.grdApCharges.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApCharges.Size = new System.Drawing.Size(433, 386);
            this.grdApCharges.TabIndex = 1;
            this.grdApCharges.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdApCharges.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApCharges.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApCharges.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdApCharges.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_ColumnButtonClick);
            this.grdApCharges.SelectionChanged += new System.EventHandler(this.grdCharge_SelectionChanged);
            this.grdApCharges.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            this.grdApCharges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_KeyDown);
            // 
            // splApChargeDtl
            // 
            this.splApChargeDtl.ControlToHide = this.grdApChargeDtl;
            this.splApChargeDtl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splApChargeDtl.Location = new System.Drawing.Point(0, 411);
            this.splApChargeDtl.Name = "splApChargeDtl";
            this.splApChargeDtl.Size = new System.Drawing.Size(433, 8);
            this.splApChargeDtl.TabIndex = 2;
            this.splApChargeDtl.TabStop = false;
            // 
            // grdApChargeDtl
            // 
            this.grdApChargeDtl.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApChargeDtl.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdApChargeDtl_DesignTimeLayout.LayoutString = resources.GetString("grdApChargeDtl_DesignTimeLayout.LayoutString");
            this.grdApChargeDtl.DesignTimeLayout = grdApChargeDtl_DesignTimeLayout;
            this.grdApChargeDtl.DisplayFieldChooser = true;
            this.grdApChargeDtl.DisplayFieldChooserChildren = true;
            this.grdApChargeDtl.DisplayFontSelector = true;
            this.grdApChargeDtl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdApChargeDtl.ExportFileID = null;
            this.grdApChargeDtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApChargeDtl.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdApChargeDtl.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApChargeDtl.Location = new System.Drawing.Point(0, 419);
            this.grdApChargeDtl.Name = "grdApChargeDtl";
            this.grdApChargeDtl.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApChargeDtl.Size = new System.Drawing.Size(433, 233);
            this.grdApChargeDtl.TabIndex = 3;
            this.grdApChargeDtl.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdApChargeDtl.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            // 
            // tbrApCharges
            // 
            this.tbrApCharges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbApChargesNew,
            this.tbbApChargesEdit,
            this.tbbApChargesN1,
            this.tbbApChargesDelete});
            this.tbrApCharges.Location = new System.Drawing.Point(0, 0);
            this.tbrApCharges.Name = "tbrApCharges";
            this.tbrApCharges.Size = new System.Drawing.Size(433, 25);
            this.tbrApCharges.TabIndex = 0;
            this.tbrApCharges.Text = "toolStrip1";
            // 
            // tbbApChargesNew
            // 
            this.tbbApChargesNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbApChargesNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbApChargesNew.Name = "tbbApChargesNew";
            this.tbbApChargesNew.Size = new System.Drawing.Size(79, 22);
            this.tbbApChargesNew.Text = "Add New Cost";
            this.tbbApChargesNew.ToolTipText = "Add a new AP Cost Charge (Ctrl+Ins)";
            this.tbbApChargesNew.Click += new System.EventHandler(this.tbbApChargesNew_Click);
            // 
            // tbbApChargesEdit
            // 
            this.tbbApChargesEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbApChargesEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbApChargesEdit.Name = "tbbApChargesEdit";
            this.tbbApChargesEdit.Size = new System.Drawing.Size(98, 22);
            this.tbbApChargesEdit.Text = "Edit Selected Cost";
            this.tbbApChargesEdit.ToolTipText = "Edit the selected AP Cost Charge (Enter)";
            this.tbbApChargesEdit.Click += new System.EventHandler(this.tbbApChargesEdit_Click);
            // 
            // tbbApChargesN1
            // 
            this.tbbApChargesN1.Name = "tbbApChargesN1";
            this.tbbApChargesN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbApChargesDelete
            // 
            this.tbbApChargesDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbApChargesDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbApChargesDelete.Name = "tbbApChargesDelete";
            this.tbbApChargesDelete.Size = new System.Drawing.Size(111, 22);
            this.tbbApChargesDelete.Text = "Delete Selected Cost";
            this.tbbApChargesDelete.ToolTipText = "Delete the selected AP Cost Charge (Ctrl+D)";
            this.tbbApChargesDelete.Click += new System.EventHandler(this.tbbApChargesDelete_Click);
            // 
            // splArCharges
            // 
            this.splArCharges.ControlToHide = this.pnlArCharges;
            this.splArCharges.Dock = System.Windows.Forms.DockStyle.Right;
            this.splArCharges.Location = new System.Drawing.Point(433, 0);
            this.splArCharges.Name = "splArCharges";
            this.splArCharges.Size = new System.Drawing.Size(8, 652);
            this.splArCharges.TabIndex = 1;
            this.splArCharges.TabStop = false;
            // 
            // pnlArCharges
            // 
            this.pnlArCharges.Controls.Add(this.grdArCharges);
            this.pnlArCharges.Controls.Add(this.splArChargeDtl);
            this.pnlArCharges.Controls.Add(this.grdArChargeDtl);
            this.pnlArCharges.Controls.Add(this.tbrArCharges);
            this.pnlArCharges.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlArCharges.Location = new System.Drawing.Point(441, 0);
            this.pnlArCharges.Name = "pnlArCharges";
            this.pnlArCharges.Size = new System.Drawing.Size(393, 652);
            this.pnlArCharges.TabIndex = 2;
            // 
            // grdArCharges
            // 
            this.grdArCharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdArCharges_DesignTimeLayout.LayoutString = resources.GetString("grdArCharges_DesignTimeLayout.LayoutString");
            this.grdArCharges.DesignTimeLayout = grdArCharges_DesignTimeLayout;
            this.grdArCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdArCharges.ExportFileID = null;
            this.grdArCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdArCharges.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdArCharges.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdArCharges.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdArCharges.Location = new System.Drawing.Point(0, 25);
            this.grdArCharges.Name = "grdArCharges";
            this.grdArCharges.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdArCharges.Size = new System.Drawing.Size(393, 386);
            this.grdArCharges.TabIndex = 4;
            this.grdArCharges.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdArCharges.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdArCharges.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdArCharges.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdArCharges.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_ColumnButtonClick);
            this.grdArCharges.SelectionChanged += new System.EventHandler(this.grdCharge_SelectionChanged);
            this.grdArCharges.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            this.grdArCharges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_KeyDown);
            // 
            // splArChargeDtl
            // 
            this.splArChargeDtl.ControlToHide = this.grdArChargeDtl;
            this.splArChargeDtl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splArChargeDtl.Location = new System.Drawing.Point(0, 411);
            this.splArChargeDtl.Name = "splArChargeDtl";
            this.splArChargeDtl.Size = new System.Drawing.Size(393, 8);
            this.splArChargeDtl.TabIndex = 2;
            this.splArChargeDtl.TabStop = false;
            // 
            // grdArChargeDtl
            // 
            this.grdArChargeDtl.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdArChargeDtl.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdArChargeDtl_DesignTimeLayout.LayoutString = resources.GetString("grdArChargeDtl_DesignTimeLayout.LayoutString");
            this.grdArChargeDtl.DesignTimeLayout = grdArChargeDtl_DesignTimeLayout;
            this.grdArChargeDtl.DisplayFieldChooser = true;
            this.grdArChargeDtl.DisplayFieldChooserChildren = true;
            this.grdArChargeDtl.DisplayFontSelector = true;
            this.grdArChargeDtl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdArChargeDtl.ExportFileID = null;
            this.grdArChargeDtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdArChargeDtl.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdArChargeDtl.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdArChargeDtl.Location = new System.Drawing.Point(0, 419);
            this.grdArChargeDtl.Name = "grdArChargeDtl";
            this.grdArChargeDtl.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdArChargeDtl.Size = new System.Drawing.Size(393, 233);
            this.grdArChargeDtl.TabIndex = 5;
            this.grdArChargeDtl.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdArChargeDtl.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            // 
            // tbrArCharges
            // 
            this.tbrArCharges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbArNewLH,
            this.tbbArChargesNew,
            this.tbbArChargesFromAp,
            this.tbbArChargesEdit,
            this.tbbArChargesN1,
            this.tbbArChargesDelete});
            this.tbrArCharges.Location = new System.Drawing.Point(0, 0);
            this.tbrArCharges.Name = "tbrArCharges";
            this.tbrArCharges.Size = new System.Drawing.Size(393, 25);
            this.tbrArCharges.TabIndex = 0;
            this.tbrArCharges.Text = "toolStrip2";
            // 
            // tbbArNewLH
            // 
            this.tbbArNewLH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbArNewLH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArNewLH.Name = "tbbArNewLH";
            this.tbbArNewLH.Size = new System.Drawing.Size(72, 22);
            this.tbbArNewLH.Text = "Add Linehaul";
            this.tbbArNewLH.Click += new System.EventHandler(this.tbbArNewLH_Click);
            // 
            // tbbArChargesNew
            // 
            this.tbbArChargesNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbArChargesNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArChargesNew.Name = "tbbArChargesNew";
            this.tbbArChargesNew.Size = new System.Drawing.Size(61, 22);
            this.tbbArChargesNew.Text = "Add Other";
            this.tbbArChargesNew.ToolTipText = "Add a new AR Revenue Charge";
            this.tbbArChargesNew.Click += new System.EventHandler(this.tbbArChargesNew_Click);
            // 
            // tbbArChargesFromAp
            // 
            this.tbbArChargesFromAp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbArChargesFromAp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArChargesFromAp.Name = "tbbArChargesFromAp";
            this.tbbArChargesFromAp.Size = new System.Drawing.Size(71, 22);
            this.tbbArChargesFromAp.Text = "Add from AP";
            this.tbbArChargesFromAp.Visible = false;
            this.tbbArChargesFromAp.Click += new System.EventHandler(this.tbbArChargesFromAp_Click);
            // 
            // tbbArChargesEdit
            // 
            this.tbbArChargesEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbArChargesEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArChargesEdit.Name = "tbbArChargesEdit";
            this.tbbArChargesEdit.Size = new System.Drawing.Size(73, 22);
            this.tbbArChargesEdit.Text = "Edit Selected";
            this.tbbArChargesEdit.ToolTipText = "Edit the selected AR Revenue Charge (Enter)";
            this.tbbArChargesEdit.Click += new System.EventHandler(this.tbbArChargesEdit_Click);
            // 
            // tbbArChargesN1
            // 
            this.tbbArChargesN1.Name = "tbbArChargesN1";
            this.tbbArChargesN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbArChargesDelete
            // 
            this.tbbArChargesDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbArChargesDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbArChargesDelete.Name = "tbbArChargesDelete";
            this.tbbArChargesDelete.Size = new System.Drawing.Size(86, 22);
            this.tbbArChargesDelete.Text = "Delete Selected";
            this.tbbArChargesDelete.ToolTipText = "Delete the selected AR Revenue Charge (Ctrl+D)";
            this.tbbArChargesDelete.Click += new System.EventHandler(this.tbbArChargesDelete_Click);
            // 
            // tpgCargo
            // 
            this.tpgCargo.Controls.Add(this.pnlCargo);
            this.tpgCargo.Controls.Add(this.splUnassigned);
            this.tpgCargo.Controls.Add(this.pnlUnassigned);
            this.tpgCargo.Location = new System.Drawing.Point(4, 22);
            this.tpgCargo.Name = "tpgCargo";
            this.tpgCargo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCargo.Size = new System.Drawing.Size(834, 652);
            this.tpgCargo.TabIndex = 1;
            this.tpgCargo.Text = "Cargo";
            this.tpgCargo.UseVisualStyleBackColor = true;
            // 
            // pnlCargo
            // 
            // 
            // pnlCargo.ClientArea
            // 
            this.pnlCargo.ClientArea.Controls.Add(this.grdCargo);
            this.pnlCargo.ClientArea.Controls.Add(this.tbrCargo);
            this.pnlCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCargo.Location = new System.Drawing.Point(3, 3);
            this.pnlCargo.Name = "pnlCargo";
            this.pnlCargo.Size = new System.Drawing.Size(828, 474);
            this.pnlCargo.TabIndex = 2;
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
            this.grdCargo.Location = new System.Drawing.Point(0, 25);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(828, 449);
            this.grdCargo.TabIndex = 1;
            this.grdCargo.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdCargo.UseGroupRowSelector = true;
            this.grdCargo.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_ColumnButtonClick);
            this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            this.grdCargo.DoubleClick += new System.EventHandler(this.grdCargo_DoubleClick);
            this.grdCargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
            // 
            // tbrCargo
            // 
            this.tbrCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbCargoAddVendor,
            this.tbbCargoRemoveVendor,
            this.tbbCargoN1,
            this.tbbCargoAssignMod,
            this.tbbCargoN2,
            this.tbbCargoRemove,
            this.tbbCargoRemoveFromCharges,
            this.tbrCargoN3,
            this.tbrCargoCheckLINE,
            this.tbbCargoCheckDup});
            this.tbrCargo.Location = new System.Drawing.Point(0, 0);
            this.tbrCargo.Name = "tbrCargo";
            this.tbrCargo.Size = new System.Drawing.Size(828, 25);
            this.tbrCargo.TabIndex = 0;
            this.tbrCargo.Text = "Cargo Operations";
            // 
            // tbbCargoAddVendor
            // 
            this.tbbCargoAddVendor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoAddVendor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoAddVendor.Name = "tbbCargoAddVendor";
            this.tbbCargoAddVendor.Size = new System.Drawing.Size(79, 22);
            this.tbbCargoAddVendor.Text = "Assign &Vendor";
            this.tbbCargoAddVendor.Click += new System.EventHandler(this.tbbCargoAddVendor_Click);
            // 
            // tbbCargoRemoveVendor
            // 
            this.tbbCargoRemoveVendor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoRemoveVendor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoRemoveVendor.Name = "tbbCargoRemoveVendor";
            this.tbbCargoRemoveVendor.Size = new System.Drawing.Size(91, 22);
            this.tbbCargoRemoveVendor.Text = "Unassign Vendor";
            this.tbbCargoRemoveVendor.Click += new System.EventHandler(this.tbbCargoRemoveVendor_Click);
            // 
            // tbbCargoN1
            // 
            this.tbbCargoN1.Name = "tbbCargoN1";
            this.tbbCargoN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbCargoAssignMod
            // 
            this.tbbCargoAssignMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoAssignMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoAssignMod.Name = "tbbCargoAssignMod";
            this.tbbCargoAssignMod.Size = new System.Drawing.Size(110, 22);
            this.tbbCargoAssignMod.Text = "Assign Contract Mod";
            this.tbbCargoAssignMod.Click += new System.EventHandler(this.tbbCargoAssignMod_Click);
            // 
            // tbbCargoN2
            // 
            this.tbbCargoN2.Name = "tbbCargoN2";
            this.tbbCargoN2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbCargoRemove
            // 
            this.tbbCargoRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoRemove.Name = "tbbCargoRemove";
            this.tbbCargoRemove.Size = new System.Drawing.Size(151, 22);
            this.tbbCargoRemove.Text = "Remove Cargo from Estimate";
            this.tbbCargoRemove.Click += new System.EventHandler(this.tbbCargoRemove_Click);
            // 
            // tbbCargoRemoveFromCharges
            // 
            this.tbbCargoRemoveFromCharges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoRemoveFromCharges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoRemoveFromCharges.Name = "tbbCargoRemoveFromCharges";
            this.tbbCargoRemoveFromCharges.Size = new System.Drawing.Size(152, 22);
            this.tbbCargoRemoveFromCharges.Text = "Remove Cargo From Charges";
            this.tbbCargoRemoveFromCharges.Click += new System.EventHandler(this.tbbCargoRemoveFromCharges_Click);
            // 
            // tbrCargoN3
            // 
            this.tbrCargoN3.Name = "tbrCargoN3";
            this.tbrCargoN3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbrCargoCheckLINE
            // 
            this.tbrCargoCheckLINE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbrCargoCheckLINE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbrCargoCheckLINE.Name = "tbrCargoCheckLINE";
            this.tbrCargoCheckLINE.Size = new System.Drawing.Size(65, 22);
            this.tbrCargoCheckLINE.Text = "Check LINE";
            this.tbrCargoCheckLINE.Click += new System.EventHandler(this.tbrCargoCheckLINE_Click);
            // 
            // tbbCargoCheckDup
            // 
            this.tbbCargoCheckDup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbCargoCheckDup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCargoCheckDup.Name = "tbbCargoCheckDup";
            this.tbbCargoCheckDup.Size = new System.Drawing.Size(92, 22);
            this.tbbCargoCheckDup.Text = "Check Duplicates";
            this.tbbCargoCheckDup.Click += new System.EventHandler(this.tbbCargoCheckDup_Click);
            // 
            // splUnassigned
            // 
            this.splUnassigned.BackColor = System.Drawing.Color.Transparent;
            this.splUnassigned.ButtonExtent = 150;
            this.splUnassigned.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splUnassigned.Location = new System.Drawing.Point(3, 477);
            this.splUnassigned.Name = "splUnassigned";
            this.splUnassigned.RestoreExtent = 162;
            this.splUnassigned.Size = new System.Drawing.Size(828, 10);
            this.splUnassigned.TabIndex = 4;
            // 
            // pnlUnassigned
            // 
            // 
            // pnlUnassigned.ClientArea
            // 
            this.pnlUnassigned.ClientArea.Controls.Add(this.grdAvailableCargo);
            this.pnlUnassigned.ClientArea.Controls.Add(this.tbrAvailableCargo);
            this.pnlUnassigned.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUnassigned.Location = new System.Drawing.Point(3, 487);
            this.pnlUnassigned.Name = "pnlUnassigned";
            this.pnlUnassigned.Size = new System.Drawing.Size(828, 162);
            this.pnlUnassigned.TabIndex = 3;
            // 
            // grdAvailableCargo
            // 
            this.grdAvailableCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAvailableCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdAvailableCargo_DesignTimeLayout.LayoutString = resources.GetString("grdAvailableCargo_DesignTimeLayout.LayoutString");
            this.grdAvailableCargo.DesignTimeLayout = grdAvailableCargo_DesignTimeLayout;
            this.grdAvailableCargo.DisplayFieldChooser = true;
            this.grdAvailableCargo.DisplayFieldChooserChildren = true;
            this.grdAvailableCargo.DisplayFontSelector = true;
            this.grdAvailableCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAvailableCargo.ExportFileID = null;
            this.grdAvailableCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdAvailableCargo.FilterRowFormatStyle.Alpha = 192;
            this.grdAvailableCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdAvailableCargo.FilterRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha;
            this.grdAvailableCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdAvailableCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdAvailableCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdAvailableCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdAvailableCargo.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAvailableCargo.Location = new System.Drawing.Point(0, 25);
            this.grdAvailableCargo.Name = "grdAvailableCargo";
            this.grdAvailableCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAvailableCargo.Size = new System.Drawing.Size(828, 137);
            this.grdAvailableCargo.TabIndex = 7;
            this.grdAvailableCargo.UseGroupRowSelector = true;
            // 
            // tbrAvailableCargo
            // 
            this.tbrAvailableCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbAvailableCargoAdd,
            this.tbbAvailableCargoN1,
            this.tbbAvailableCargoDelete});
            this.tbrAvailableCargo.Location = new System.Drawing.Point(0, 0);
            this.tbrAvailableCargo.Name = "tbrAvailableCargo";
            this.tbrAvailableCargo.Size = new System.Drawing.Size(828, 25);
            this.tbrAvailableCargo.TabIndex = 2;
            this.tbrAvailableCargo.Text = "Cargo Operations";
            // 
            // tbbAvailableCargoAdd
            // 
            this.tbbAvailableCargoAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbAvailableCargoAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAvailableCargoAdd.Name = "tbbAvailableCargoAdd";
            this.tbbAvailableCargoAdd.Size = new System.Drawing.Size(131, 22);
            this.tbbAvailableCargoAdd.Text = "Assign Cargo to Estimate";
            this.tbbAvailableCargoAdd.Click += new System.EventHandler(this.tbbAvailableAdd_Click);
            // 
            // tbbAvailableCargoN1
            // 
            this.tbbAvailableCargoN1.Name = "tbbAvailableCargoN1";
            this.tbbAvailableCargoN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbAvailableCargoDelete
            // 
            this.tbbAvailableCargoDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbAvailableCargoDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAvailableCargoDelete.Name = "tbbAvailableCargoDelete";
            this.tbbAvailableCargoDelete.Size = new System.Drawing.Size(192, 22);
            this.tbbAvailableCargoDelete.Text = "Delete Cargo from Intermodal System";
            this.tbbAvailableCargoDelete.Click += new System.EventHandler(this.tbbAvailableCargoDelete_Click);
            // 
            // infDockMgr
            // 
            this.infDockMgr.CompressUnpinnedTabs = false;
            dockAreaPane1.DockedBefore = new System.Guid("2a568266-a95d-4e56-a2ab-3836a592d611");
            dockableControlPane1.Control = this.pnlCargoChanges;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(-1, 393);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(167, 183, 350, 205);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Cargo Change Notification";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane1.Size = new System.Drawing.Size(1006, 453);
            dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockableControlPane2.Control = this.rtfBookingNotes;
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(859, 25, 147, 699);
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "Booking Notes";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockAreaPane2.Size = new System.Drawing.Size(159, 656);
            this.infDockMgr.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
            this.infDockMgr.HostControl = this;
            // 
            // _frmChildBaseUnpinnedTabAreaLeft
            // 
            this._frmChildBaseUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._frmChildBaseUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmChildBaseUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 25);
            this._frmChildBaseUnpinnedTabAreaLeft.Name = "_frmChildBaseUnpinnedTabAreaLeft";
            this._frmChildBaseUnpinnedTabAreaLeft.Owner = this.infDockMgr;
            this._frmChildBaseUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 699);
            this._frmChildBaseUnpinnedTabAreaLeft.TabIndex = 2;
            // 
            // _frmChildBaseUnpinnedTabAreaRight
            // 
            this._frmChildBaseUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._frmChildBaseUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmChildBaseUnpinnedTabAreaRight.Location = new System.Drawing.Point(1006, 25);
            this._frmChildBaseUnpinnedTabAreaRight.Name = "_frmChildBaseUnpinnedTabAreaRight";
            this._frmChildBaseUnpinnedTabAreaRight.Owner = this.infDockMgr;
            this._frmChildBaseUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 699);
            this._frmChildBaseUnpinnedTabAreaRight.TabIndex = 3;
            // 
            // _frmChildBaseUnpinnedTabAreaTop
            // 
            this._frmChildBaseUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._frmChildBaseUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmChildBaseUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 25);
            this._frmChildBaseUnpinnedTabAreaTop.Name = "_frmChildBaseUnpinnedTabAreaTop";
            this._frmChildBaseUnpinnedTabAreaTop.Owner = this.infDockMgr;
            this._frmChildBaseUnpinnedTabAreaTop.Size = new System.Drawing.Size(1006, 0);
            this._frmChildBaseUnpinnedTabAreaTop.TabIndex = 4;
            // 
            // _frmChildBaseUnpinnedTabAreaBottom
            // 
            this._frmChildBaseUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._frmChildBaseUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmChildBaseUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 703);
            this._frmChildBaseUnpinnedTabAreaBottom.Name = "_frmChildBaseUnpinnedTabAreaBottom";
            this._frmChildBaseUnpinnedTabAreaBottom.Owner = this.infDockMgr;
            this._frmChildBaseUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1006, 21);
            this._frmChildBaseUnpinnedTabAreaBottom.TabIndex = 5;
            // 
            // _frmChildBaseAutoHideControl
            // 
            this._frmChildBaseAutoHideControl.Controls.Add(this.dockableWindow2);
            this._frmChildBaseAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._frmChildBaseAutoHideControl.Location = new System.Drawing.Point(0, 25);
            this._frmChildBaseAutoHideControl.Name = "_frmChildBaseAutoHideControl";
            this._frmChildBaseAutoHideControl.Owner = this.infDockMgr;
            this._frmChildBaseAutoHideControl.Size = new System.Drawing.Size(1006, 678);
            this._frmChildBaseAutoHideControl.TabIndex = 6;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.pnlCargoChanges);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 5);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.infDockMgr;
            this.dockableWindow2.Size = new System.Drawing.Size(1006, 393);
            this.dockableWindow2.TabIndex = 11;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.rtfBookingNotes);
            this.dockableWindow1.Location = new System.Drawing.Point(5, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.infDockMgr;
            this.dockableWindow1.Size = new System.Drawing.Size(159, 678);
            this.dockableWindow1.TabIndex = 12;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 245);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.infDockMgr;
            this.windowDockingArea1.Size = new System.Drawing.Size(1006, 458);
            this.windowDockingArea1.TabIndex = 7;
            // 
            // windowDockingArea3
            // 
            this.windowDockingArea3.Controls.Add(this.dockableWindow1);
            this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Right;
            this.windowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowDockingArea3.Location = new System.Drawing.Point(842, 25);
            this.windowDockingArea3.Name = "windowDockingArea3";
            this.windowDockingArea3.Owner = this.infDockMgr;
            this.windowDockingArea3.Size = new System.Drawing.Size(164, 678);
            this.windowDockingArea3.TabIndex = 9;
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 702);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(1006, 22);
            this.sbrChild.TabIndex = 10;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(116, 17);
            this.sbbProgressCaption.Text = "Processing Cleanup....";
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(200, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // bkgCleanup
            // 
            this.bkgCleanup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgCleanup_DoWork);
            this.bkgCleanup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgCleanup_RunWorkerCompleted);
            // 
            // bkgCheckLINE
            // 
            this.bkgCheckLINE.WorkerReportsProgress = true;
            this.bkgCheckLINE.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgCheckLINE_DoWork);
            this.bkgCheckLINE.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgCheckLINE_ProgressChanged);
            this.bkgCheckLINE.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgCheckLINE_RunWorkerCompleted);
            // 
            // frmViewEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 724);
            this.Controls.Add(this._frmChildBaseAutoHideControl);
            this.Controls.Add(this.tabEstimateMain);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.windowDockingArea3);
            this.Controls.Add(this._frmChildBaseUnpinnedTabAreaTop);
            this.Controls.Add(this._frmChildBaseUnpinnedTabAreaBottom);
            this.Controls.Add(this._frmChildBaseUnpinnedTabAreaLeft);
            this.Controls.Add(this._frmChildBaseUnpinnedTabAreaRight);
            this.Controls.Add(this.tbrMain);
            this.KeyPreview = true;
            this.Name = "frmViewEstimate";
            this.Text = "Intermodal Estimate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewEstimate_FormClosing);
            this.Load += new System.EventHandler(this.frmViewEstimate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmViewEstimate_KeyDown);
            this.pnlCargoChanges.ClientArea.ResumeLayout(false);
            this.pnlCargoChanges.ClientArea.PerformLayout();
            this.pnlCargoChanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoChanges)).EndInit();
            this.tbrChanges.ResumeLayout(false);
            this.tbrChanges.PerformLayout();
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.tabEstimateMain.ResumeLayout(false);
            this.tpgCharges.ResumeLayout(false);
            this.pnlCharges.ResumeLayout(false);
            this.pnlApCharges.ResumeLayout(false);
            this.pnlApCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApChargeDtl)).EndInit();
            this.tbrApCharges.ResumeLayout(false);
            this.tbrApCharges.PerformLayout();
            this.pnlArCharges.ResumeLayout(false);
            this.pnlArCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArChargeDtl)).EndInit();
            this.tbrArCharges.ResumeLayout(false);
            this.tbrArCharges.PerformLayout();
            this.tpgCargo.ResumeLayout(false);
            this.pnlCargo.ClientArea.ResumeLayout(false);
            this.pnlCargo.ClientArea.PerformLayout();
            this.pnlCargo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.tbrCargo.ResumeLayout(false);
            this.tbrCargo.PerformLayout();
            this.pnlUnassigned.ClientArea.ResumeLayout(false);
            this.pnlUnassigned.ClientArea.PerformLayout();
            this.pnlUnassigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableCargo)).EndInit();
            this.tbrAvailableCargo.ResumeLayout(false);
            this.tbrAvailableCargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).EndInit();
            this._frmChildBaseAutoHideControl.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.windowDockingArea3.ResumeLayout(false);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripDropDownButton tbbMainOptions;
		private System.Windows.Forms.ToolStripButton tbbMainClose;
		private CommonWinCtrls.ucRichTextBox rtfBookingNotes;
		private CommonWinCtrls.ucTabControl tabEstimateMain;
		private System.Windows.Forms.TabPage tpgCharges;
		private CommonWinCtrls.ucPanel pnlCharges;
		private CommonWinCtrls.ucPanel pnlApCharges;
		private CommonWinCtrls.ucCollapsibleSplitter splApChargeDtl;
		private CommonWinCtrls.ucGridEx grdApChargeDtl;
		private System.Windows.Forms.ToolStrip tbrApCharges;
		private System.Windows.Forms.ToolStripButton tbbApChargesNew;
		private System.Windows.Forms.ToolStripButton tbbApChargesEdit;
		private System.Windows.Forms.ToolStripSeparator tbbApChargesN1;
		private System.Windows.Forms.ToolStripButton tbbApChargesDelete;
		private CommonWinCtrls.ucCollapsibleSplitter splArCharges;
		private CommonWinCtrls.ucPanel pnlArCharges;
		private CommonWinCtrls.ucCollapsibleSplitter splArChargeDtl;
		private System.Windows.Forms.ToolStrip tbrArCharges;
		private System.Windows.Forms.ToolStripButton tbbArChargesNew;
		private System.Windows.Forms.ToolStripButton tbbArChargesEdit;
		private System.Windows.Forms.ToolStripSeparator tbbArChargesN1;
		private System.Windows.Forms.ToolStripButton tbbArChargesDelete;
		private System.Windows.Forms.TabPage tpgCargo;
		private CommonWinCtrls.ucGridEx grdCargo;
		private System.Windows.Forms.ToolStrip tbrCargo;
		private System.Windows.Forms.ToolStripButton tbbCargoRemove;
		private System.Windows.Forms.ToolStripButton tbbCargoAddVendor;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsRefresh;
		private CommonWinCtrls.ucGridEx grdApCharges;
		private System.Windows.Forms.ToolStripButton tbbCargoAssignMod;
		private System.Windows.Forms.ToolStripSeparator tbbCargoN1;
		private System.Windows.Forms.ToolStripLabel tbbMainTitle;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsMileage;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsEstimateDate;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN1;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN2;
		private System.Windows.Forms.ToolStripButton tbbMainRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator tbbCargoN2;
		private System.Windows.Forms.ToolStripButton tbbArChargesFromAp;
		private System.Windows.Forms.ToolStripButton tbbCargoRemoveVendor;
		private Infragistics.Win.UltraWinDock.UltraDockManager infDockMgr;
		private Infragistics.Win.UltraWinDock.AutoHideControl _frmChildBaseAutoHideControl;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.Misc.UltraPanel pnlCargoChanges;
		private CommonWinCtrls.ucGridEx grdCargoChanges;
		private System.Windows.Forms.ToolStrip tbrChanges;
		private System.Windows.Forms.ToolStripButton tbbChangesDismiss;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
		private Infragistics.Win.Misc.UltraPanel pnlUnassigned;
		private CommonWinCtrls.ucGridEx grdAvailableCargo;
		private System.Windows.Forms.ToolStrip tbrAvailableCargo;
		private System.Windows.Forms.ToolStripButton tbbAvailableCargoAdd;
		private Infragistics.Win.Misc.UltraPanel pnlCargo;
		private Infragistics.Win.Misc.UltraSplitter splUnassigned;
		private CommonWinCtrls.ucGridEx grdArCharges;
		private CommonWinCtrls.ucGridEx grdArChargeDtl;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsDeleteEst;
		private System.Windows.Forms.ToolStripSeparator tbbAvailableCargoN1;
		private System.Windows.Forms.ToolStripButton tbbAvailableCargoDelete;
		private System.Windows.Forms.ToolStripButton tbbCargoRemoveFromCharges;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsRecomputeAll;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN3;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.ComponentModel.BackgroundWorker bkgCleanup;
		private System.Windows.Forms.ToolStripSeparator tbrCargoN3;
		private System.Windows.Forms.ToolStripButton tbrCargoCheckLINE;
		private System.ComponentModel.BackgroundWorker bkgCheckLINE;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsChangeVoyage;
		private System.Windows.Forms.ToolStripButton tbbCargoCheckDup;
		private System.Windows.Forms.ToolStripButton tbbArNewLH;
	}
}