namespace CS2010.ArcSys.Win
{
	partial class frmIAL
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
            Janus.Windows.GridEX.GridEXLayout grdLINEVins_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIAL));
            Janus.Windows.GridEX.GridEXLayout grdIALVins_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdShippingInstructions_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdQueue_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdSISummary_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdUnprocessedDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdUnprocessedSI_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDownloadResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdBatteryDisconnect_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdOverheight_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpShippingInstructions = new System.Windows.Forms.TabPage();
            this.btnUpdateLINE = new CS2010.CommonWinCtrls.ucButton();
            this.cbxMismatches = new CS2010.CommonWinCtrls.ucCheckBox();
            this.grdLINEVins = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdIALVins = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdShippingInstructions = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdQueue = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdSISummary = new CS2010.CommonWinCtrls.ucGridEx();
            this.pnlSITop = new CS2010.CommonWinCtrls.ucPanel();
            this.btnPutInQueue = new CS2010.CommonWinCtrls.ucButton();
            this.tpMonitor = new System.Windows.Forms.TabPage();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.pnlFiles = new CS2010.CommonWinCtrls.ucPanel();
            this.grdUnprocessedDetail = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
            this.btnReprocess = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel2 = new CS2010.CommonWinCtrls.ucLabel();
            this.btnReLoadDetail = new CS2010.CommonWinCtrls.ucButton();
            this.panelTopDtl = new CS2010.CommonWinCtrls.ucPanel();
            this.btnArchiveDetail = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel4 = new CS2010.CommonWinCtrls.ucLabel();
            this.listDetailFiles = new CS2010.CommonWinCtrls.ucListBox();
            this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucLabel3 = new CS2010.CommonWinCtrls.ucLabel();
            this.btnProcessFiles = new CS2010.CommonWinCtrls.ucButton();
            this.btnReprocessDtl = new CS2010.CommonWinCtrls.ucButton();
            this.listFailedDetail = new CS2010.CommonWinCtrls.ucListBox();
            this.pnlSI = new CS2010.CommonWinCtrls.ucPanel();
            this.grdUnprocessedSI = new CS2010.CommonWinCtrls.ucGridEx();
            this.panelSICommands = new CS2010.CommonWinCtrls.ucPanel();
            this.btnRemoveSI = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel8 = new CS2010.CommonWinCtrls.ucLabel();
            this.btnResend304 = new CS2010.CommonWinCtrls.ucButton();
            this.panelTopSI = new CS2010.CommonWinCtrls.ucPanel();
            this.ucLabel5 = new CS2010.CommonWinCtrls.ucLabel();
            this.listUnprocessedSI = new CS2010.CommonWinCtrls.ucListBox();
            this.btnArchiveSI = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel6 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucLabel7 = new CS2010.CommonWinCtrls.ucLabel();
            this.btnReProcessSI = new CS2010.CommonWinCtrls.ucButton();
            this.listFailedSI = new CS2010.CommonWinCtrls.ucListBox();
            this.btnProcessSI = new CS2010.CommonWinCtrls.ucButton();
            this.panelTop = new CS2010.CommonWinCtrls.ucPanel();
            this.btnTOPS = new CS2010.CommonWinCtrls.ucButton();
            this.btnSendITV = new CS2010.CommonWinCtrls.ucButton();
            this.btnBOLs = new CS2010.CommonWinCtrls.ucButton();
            this.cbxShowFileList = new CS2010.CommonWinCtrls.ucCheckBox();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.txtVIN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxShowAll = new CS2010.CommonWinCtrls.ucCheckBox();
            this.grpDays = new CS2010.CommonWinCtrls.ucGroupBox();
            this.rbAll = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rb30Days = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rb60Days = new CS2010.CommonWinCtrls.ucRadioButton();
            this.btnRefreshDetail = new CS2010.CommonWinCtrls.ucButton();
            this.ucLabel9 = new CS2010.CommonWinCtrls.ucLabel();
            this.tpDownloads = new System.Windows.Forms.TabPage();
            this.splitDownloadSearch = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdDownloadResults = new CS2010.CommonWinCtrls.ucGridEx();
            this.txtFileDisplay = new CS2010.CommonWinCtrls.ucTextBox();
            this.pnlDownloadsCancel = new CS2010.CommonWinCtrls.ucPanel();
            this.lblProgress = new CS2010.CommonWinCtrls.ucLabel();
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.pnlDownloadsTop = new CS2010.CommonWinCtrls.ucPanel();
            this.Search = new CS2010.CommonWinCtrls.ucButton();
            this.txtSearchString = new CS2010.CommonWinCtrls.ucTextBox();
            this.rbShippingInstructions = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbCargoDetail = new CS2010.CommonWinCtrls.ucRadioButton();
            this.tpBatteryDisconnects = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBDRefresh = new CS2010.CommonWinCtrls.ucButton();
            this.grdBatteryDisconnect = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpOverHeights = new System.Windows.Forms.TabPage();
            this.grdOverheight = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
            this.btnRefreshOverHt = new CS2010.CommonWinCtrls.ucButton();
            this.bgwDownloads = new System.ComponentModel.BackgroundWorker();
            this.tabMain.SuspendLayout();
            this.tpShippingInstructions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLINEVins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIALVins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShippingInstructions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSISummary)).BeginInit();
            this.pnlSITop.SuspendLayout();
            this.tpMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnprocessedDetail)).BeginInit();
            this.ucPanel1.SuspendLayout();
            this.panelTopDtl.SuspendLayout();
            this.pnlSI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnprocessedSI)).BeginInit();
            this.panelSICommands.SuspendLayout();
            this.panelTopSI.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.ucGroupBox1.SuspendLayout();
            this.grpDays.SuspendLayout();
            this.tpDownloads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDownloadSearch)).BeginInit();
            this.splitDownloadSearch.Panel1.SuspendLayout();
            this.splitDownloadSearch.Panel2.SuspendLayout();
            this.splitDownloadSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDownloadResults)).BeginInit();
            this.pnlDownloadsCancel.SuspendLayout();
            this.pnlDownloadsTop.SuspendLayout();
            this.tpBatteryDisconnects.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatteryDisconnect)).BeginInit();
            this.tpOverHeights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOverheight)).BeginInit();
            this.ucPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpShippingInstructions);
            this.tabMain.Controls.Add(this.tpMonitor);
            this.tabMain.Controls.Add(this.tpDownloads);
            this.tabMain.Controls.Add(this.tpBatteryDisconnects);
            this.tabMain.Controls.Add(this.tpOverHeights);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(742, 632);
            this.tabMain.TabIndex = 0;
            // 
            // tpShippingInstructions
            // 
            this.tpShippingInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.tpShippingInstructions.Controls.Add(this.btnUpdateLINE);
            this.tpShippingInstructions.Controls.Add(this.cbxMismatches);
            this.tpShippingInstructions.Controls.Add(this.grdLINEVins);
            this.tpShippingInstructions.Controls.Add(this.grdIALVins);
            this.tpShippingInstructions.Controls.Add(this.grdShippingInstructions);
            this.tpShippingInstructions.Controls.Add(this.grdQueue);
            this.tpShippingInstructions.Controls.Add(this.grdSISummary);
            this.tpShippingInstructions.Controls.Add(this.pnlSITop);
            this.tpShippingInstructions.Location = new System.Drawing.Point(4, 22);
            this.tpShippingInstructions.Name = "tpShippingInstructions";
            this.tpShippingInstructions.Size = new System.Drawing.Size(734, 606);
            this.tpShippingInstructions.TabIndex = 0;
            this.tpShippingInstructions.Text = "Shipping Instructions";
            // 
            // btnUpdateLINE
            // 
            this.btnUpdateLINE.Location = new System.Drawing.Point(603, 440);
            this.btnUpdateLINE.Name = "btnUpdateLINE";
            this.btnUpdateLINE.Size = new System.Drawing.Size(99, 23);
            this.btnUpdateLINE.TabIndex = 22;
            this.btnUpdateLINE.Text = "Update LINE";
            this.btnUpdateLINE.UseVisualStyleBackColor = true;
            this.btnUpdateLINE.Click += new System.EventHandler(this.btnUpdateLINE_Click);
            // 
            // cbxMismatches
            // 
            this.cbxMismatches.Location = new System.Drawing.Point(603, 398);
            this.cbxMismatches.Name = "cbxMismatches";
            this.cbxMismatches.Size = new System.Drawing.Size(153, 24);
            this.cbxMismatches.TabIndex = 21;
            this.cbxMismatches.Text = "Only Show Mismatches";
            this.cbxMismatches.UseVisualStyleBackColor = true;
            this.cbxMismatches.YN = "N";
            this.cbxMismatches.CheckedChanged += new System.EventHandler(this.cbxMismatches_CheckedChanged);
            // 
            // grdLINEVins
            // 
            grdLINEVins_DesignTimeLayout.LayoutString = resources.GetString("grdLINEVins_DesignTimeLayout.LayoutString");
            this.grdLINEVins.DesignTimeLayout = grdLINEVins_DesignTimeLayout;
            this.grdLINEVins.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdLINEVins.ExportFileID = null;
            this.grdLINEVins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdLINEVins.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdLINEVins.Location = new System.Drawing.Point(337, 346);
            this.grdLINEVins.Name = "grdLINEVins";
            this.grdLINEVins.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdLINEVins.Size = new System.Drawing.Size(245, 260);
            this.grdLINEVins.TabIndex = 20;
            this.grdLINEVins.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdLINEVins.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // grdIALVins
            // 
            grdIALVins_DesignTimeLayout.LayoutString = resources.GetString("grdIALVins_DesignTimeLayout.LayoutString");
            this.grdIALVins.DesignTimeLayout = grdIALVins_DesignTimeLayout;
            this.grdIALVins.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdIALVins.ExportFileID = null;
            this.grdIALVins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdIALVins.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdIALVins.Location = new System.Drawing.Point(121, 346);
            this.grdIALVins.Name = "grdIALVins";
            this.grdIALVins.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdIALVins.Size = new System.Drawing.Size(216, 260);
            this.grdIALVins.TabIndex = 18;
            this.grdIALVins.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // grdShippingInstructions
            // 
            this.grdShippingInstructions.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdShippingInstructions_DesignTimeLayout.LayoutString = resources.GetString("grdShippingInstructions_DesignTimeLayout.LayoutString");
            this.grdShippingInstructions.DesignTimeLayout = grdShippingInstructions_DesignTimeLayout;
            this.grdShippingInstructions.ExportFileID = null;
            this.grdShippingInstructions.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdShippingInstructions.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdShippingInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdShippingInstructions.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdShippingInstructions.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdShippingInstructions.Location = new System.Drawing.Point(603, 469);
            this.grdShippingInstructions.Name = "grdShippingInstructions";
            this.grdShippingInstructions.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdShippingInstructions.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            this.grdShippingInstructions.Size = new System.Drawing.Size(109, 98);
            this.grdShippingInstructions.TabIndex = 14;
            this.grdShippingInstructions.UseGroupRowSelector = true;
            this.grdShippingInstructions.Visible = false;
            // 
            // grdQueue
            // 
            grdQueue_DesignTimeLayout.LayoutString = resources.GetString("grdQueue_DesignTimeLayout.LayoutString");
            this.grdQueue.DesignTimeLayout = grdQueue_DesignTimeLayout;
            this.grdQueue.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdQueue.ExportFileID = null;
            this.grdQueue.GroupByBoxVisible = false;
            this.grdQueue.Location = new System.Drawing.Point(0, 346);
            this.grdQueue.Name = "grdQueue";
            this.grdQueue.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdQueue.Size = new System.Drawing.Size(121, 260);
            this.grdQueue.TabIndex = 16;
            // 
            // grdSISummary
            // 
            this.grdSISummary.CellToolTipText = "If BD Error = Y it indicates there is at least one vehicle with a safety recall t" +
                "hat we have not addressed.";
            grdSISummary_DesignTimeLayout.LayoutString = resources.GetString("grdSISummary_DesignTimeLayout.LayoutString");
            this.grdSISummary.DesignTimeLayout = grdSISummary_DesignTimeLayout;
            this.grdSISummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSISummary.ExportFileID = null;
            this.grdSISummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdSISummary.Location = new System.Drawing.Point(0, 47);
            this.grdSISummary.Name = "grdSISummary";
            this.grdSISummary.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdSISummary.Size = new System.Drawing.Size(734, 299);
            this.grdSISummary.TabIndex = 17;
            this.grdSISummary.UseGroupRowSelector = true;
            this.grdSISummary.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdSISummary_FormattingRow);
            this.grdSISummary.SelectionChanged += new System.EventHandler(this.grdSISummary_SelectionChanged);
            // 
            // pnlSITop
            // 
            this.pnlSITop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSITop.Controls.Add(this.btnPutInQueue);
            this.pnlSITop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSITop.Location = new System.Drawing.Point(0, 0);
            this.pnlSITop.Name = "pnlSITop";
            this.pnlSITop.Size = new System.Drawing.Size(734, 47);
            this.pnlSITop.TabIndex = 15;
            // 
            // btnPutInQueue
            // 
            this.btnPutInQueue.Location = new System.Drawing.Point(15, 9);
            this.btnPutInQueue.Name = "btnPutInQueue";
            this.btnPutInQueue.Size = new System.Drawing.Size(149, 23);
            this.btnPutInQueue.TabIndex = 19;
            this.btnPutInQueue.Text = "Add Selected to Queue";
            this.btnPutInQueue.UseVisualStyleBackColor = true;
            this.btnPutInQueue.Click += new System.EventHandler(this.btnPutInQueue_Click);
            // 
            // tpMonitor
            // 
            this.tpMonitor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpMonitor.Controls.Add(this.splitMain);
            this.tpMonitor.Controls.Add(this.panelTop);
            this.tpMonitor.Location = new System.Drawing.Point(4, 22);
            this.tpMonitor.Name = "tpMonitor";
            this.tpMonitor.Size = new System.Drawing.Size(734, 606);
            this.tpMonitor.TabIndex = 0;
            this.tpMonitor.Text = "IAL Cargo Overview";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 113);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlFiles);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.pnlSI);
            this.splitMain.Size = new System.Drawing.Size(734, 493);
            this.splitMain.SplitterDistance = 370;
            this.splitMain.TabIndex = 11;
            // 
            // pnlFiles
            // 
            this.pnlFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFiles.Controls.Add(this.grdUnprocessedDetail);
            this.pnlFiles.Controls.Add(this.ucPanel1);
            this.pnlFiles.Controls.Add(this.panelTopDtl);
            this.pnlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiles.Location = new System.Drawing.Point(0, 0);
            this.pnlFiles.Name = "pnlFiles";
            this.pnlFiles.Size = new System.Drawing.Size(370, 493);
            this.pnlFiles.TabIndex = 0;
            // 
            // grdUnprocessedDetail
            // 
            this.grdUnprocessedDetail.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdUnprocessedDetail_DesignTimeLayout.LayoutString = resources.GetString("grdUnprocessedDetail_DesignTimeLayout.LayoutString");
            this.grdUnprocessedDetail.DesignTimeLayout = grdUnprocessedDetail_DesignTimeLayout;
            this.grdUnprocessedDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnprocessedDetail.ExportFileID = null;
            this.grdUnprocessedDetail.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdUnprocessedDetail.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdUnprocessedDetail.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdUnprocessedDetail.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdUnprocessedDetail.Location = new System.Drawing.Point(0, 264);
            this.grdUnprocessedDetail.Name = "grdUnprocessedDetail";
            this.grdUnprocessedDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdUnprocessedDetail.Size = new System.Drawing.Size(366, 225);
            this.grdUnprocessedDetail.TabIndex = 4;
            this.grdUnprocessedDetail.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdUnprocessedDetail_LinkClicked);
            this.grdUnprocessedDetail.DoubleClick += new System.EventHandler(this.grdUnprocessedDetail_DoubleClick);
            // 
            // ucPanel1
            // 
            this.ucPanel1.Controls.Add(this.btnReprocess);
            this.ucPanel1.Controls.Add(this.ucLabel2);
            this.ucPanel1.Controls.Add(this.btnReLoadDetail);
            this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel1.Location = new System.Drawing.Point(0, 229);
            this.ucPanel1.Name = "ucPanel1";
            this.ucPanel1.Size = new System.Drawing.Size(366, 35);
            this.ucPanel1.TabIndex = 11;
            // 
            // btnReprocess
            // 
            this.btnReprocess.Location = new System.Drawing.Point(361, 5);
            this.btnReprocess.Name = "btnReprocess";
            this.btnReprocess.Size = new System.Drawing.Size(114, 23);
            this.btnReprocess.TabIndex = 8;
            this.btnReprocess.Text = "Reprocess Selected";
            this.btnReprocess.UseVisualStyleBackColor = true;
            this.btnReprocess.Click += new System.EventHandler(this.btnReprocess_Click);
            // 
            // ucLabel2
            // 
            this.ucLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ucLabel2.Location = new System.Drawing.Point(2, 9);
            this.ucLabel2.Name = "ucLabel2";
            this.ucLabel2.Size = new System.Drawing.Size(181, 13);
            this.ucLabel2.TabIndex = 3;
            this.ucLabel2.Text = "Cargo Detail received from IAL";
            // 
            // btnReLoadDetail
            // 
            this.btnReLoadDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReLoadDetail.Location = new System.Drawing.Point(255, 5);
            this.btnReLoadDetail.Name = "btnReLoadDetail";
            this.btnReLoadDetail.Size = new System.Drawing.Size(98, 23);
            this.btnReLoadDetail.TabIndex = 7;
            this.btnReLoadDetail.Text = "Reprocess All";
            this.btnReLoadDetail.UseVisualStyleBackColor = true;
            this.btnReLoadDetail.Click += new System.EventHandler(this.btnReLoadDetail_Click);
            // 
            // panelTopDtl
            // 
            this.panelTopDtl.Controls.Add(this.btnArchiveDetail);
            this.panelTopDtl.Controls.Add(this.ucLabel4);
            this.panelTopDtl.Controls.Add(this.listDetailFiles);
            this.panelTopDtl.Controls.Add(this.ucLabel1);
            this.panelTopDtl.Controls.Add(this.ucLabel3);
            this.panelTopDtl.Controls.Add(this.btnProcessFiles);
            this.panelTopDtl.Controls.Add(this.btnReprocessDtl);
            this.panelTopDtl.Controls.Add(this.listFailedDetail);
            this.panelTopDtl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopDtl.Location = new System.Drawing.Point(0, 0);
            this.panelTopDtl.Name = "panelTopDtl";
            this.panelTopDtl.Size = new System.Drawing.Size(366, 229);
            this.panelTopDtl.TabIndex = 10;
            // 
            // btnArchiveDetail
            // 
            this.btnArchiveDetail.Location = new System.Drawing.Point(400, 160);
            this.btnArchiveDetail.Name = "btnArchiveDetail";
            this.btnArchiveDetail.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveDetail.TabIndex = 7;
            this.btnArchiveDetail.Text = "Archive";
            this.btnArchiveDetail.UseVisualStyleBackColor = true;
            this.btnArchiveDetail.Click += new System.EventHandler(this.btnArchiveDetail_Click);
            // 
            // ucLabel4
            // 
            this.ucLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ucLabel4.Location = new System.Drawing.Point(4, 1);
            this.ucLabel4.Name = "ucLabel4";
            this.ucLabel4.Size = new System.Drawing.Size(211, 24);
            this.ucLabel4.TabIndex = 6;
            this.ucLabel4.Text = "Cargo Detail Processing";
            // 
            // listDetailFiles
            // 
            this.listDetailFiles.FormattingEnabled = true;
            this.listDetailFiles.Location = new System.Drawing.Point(4, 40);
            this.listDetailFiles.Name = "listDetailFiles";
            this.listDetailFiles.Size = new System.Drawing.Size(388, 56);
            this.listDetailFiles.TabIndex = 0;
            // 
            // ucLabel1
            // 
            this.ucLabel1.Location = new System.Drawing.Point(4, 24);
            this.ucLabel1.Name = "ucLabel1";
            this.ucLabel1.Size = new System.Drawing.Size(155, 13);
            this.ucLabel1.TabIndex = 2;
            this.ucLabel1.Text = "Unprocessed Cargo Detail Files";
            // 
            // ucLabel3
            // 
            this.ucLabel3.Location = new System.Drawing.Point(6, 113);
            this.ucLabel3.Name = "ucLabel3";
            this.ucLabel3.Size = new System.Drawing.Size(96, 13);
            this.ucLabel3.TabIndex = 5;
            this.ucLabel3.Text = "Failed Cargo Detail";
            // 
            // btnProcessFiles
            // 
            this.btnProcessFiles.Location = new System.Drawing.Point(398, 40);
            this.btnProcessFiles.Name = "btnProcessFiles";
            this.btnProcessFiles.Size = new System.Drawing.Size(75, 23);
            this.btnProcessFiles.TabIndex = 1;
            this.btnProcessFiles.Text = "Process";
            this.btnProcessFiles.UseVisualStyleBackColor = true;
            this.btnProcessFiles.Click += new System.EventHandler(this.btnProcessFiles_Click);
            // 
            // btnReprocessDtl
            // 
            this.btnReprocessDtl.Location = new System.Drawing.Point(399, 130);
            this.btnReprocessDtl.Name = "btnReprocessDtl";
            this.btnReprocessDtl.Size = new System.Drawing.Size(75, 23);
            this.btnReprocessDtl.TabIndex = 2;
            this.btnReprocessDtl.Text = "Re-Process";
            this.btnReprocessDtl.UseVisualStyleBackColor = true;
            this.btnReprocessDtl.Click += new System.EventHandler(this.btnReprocessDtl_Click);
            // 
            // listFailedDetail
            // 
            this.listFailedDetail.FormattingEnabled = true;
            this.listFailedDetail.Location = new System.Drawing.Point(5, 130);
            this.listFailedDetail.Name = "listFailedDetail";
            this.listFailedDetail.Size = new System.Drawing.Size(388, 82);
            this.listFailedDetail.TabIndex = 1;
            // 
            // pnlSI
            // 
            this.pnlSI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSI.Controls.Add(this.grdUnprocessedSI);
            this.pnlSI.Controls.Add(this.panelSICommands);
            this.pnlSI.Controls.Add(this.panelTopSI);
            this.pnlSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSI.Location = new System.Drawing.Point(0, 0);
            this.pnlSI.Name = "pnlSI";
            this.pnlSI.Size = new System.Drawing.Size(360, 493);
            this.pnlSI.TabIndex = 8;
            // 
            // grdUnprocessedSI
            // 
            this.grdUnprocessedSI.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdUnprocessedSI_DesignTimeLayout.LayoutString = resources.GetString("grdUnprocessedSI_DesignTimeLayout.LayoutString");
            this.grdUnprocessedSI.DesignTimeLayout = grdUnprocessedSI_DesignTimeLayout;
            this.grdUnprocessedSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUnprocessedSI.ExportFileID = null;
            this.grdUnprocessedSI.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdUnprocessedSI.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdUnprocessedSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdUnprocessedSI.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdUnprocessedSI.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdUnprocessedSI.Location = new System.Drawing.Point(0, 264);
            this.grdUnprocessedSI.Name = "grdUnprocessedSI";
            this.grdUnprocessedSI.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdUnprocessedSI.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            this.grdUnprocessedSI.Size = new System.Drawing.Size(356, 225);
            this.grdUnprocessedSI.TabIndex = 13;
            this.grdUnprocessedSI.UseGroupRowSelector = true;
            this.grdUnprocessedSI.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdUnprocessedSI_RowCheckStateChanged);
            this.grdUnprocessedSI.DoubleClick += new System.EventHandler(this.grdUnprocessedSI_DoubleClick);
            // 
            // panelSICommands
            // 
            this.panelSICommands.Controls.Add(this.btnRemoveSI);
            this.panelSICommands.Controls.Add(this.ucLabel8);
            this.panelSICommands.Controls.Add(this.btnResend304);
            this.panelSICommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSICommands.Location = new System.Drawing.Point(0, 229);
            this.panelSICommands.Name = "panelSICommands";
            this.panelSICommands.Size = new System.Drawing.Size(356, 35);
            this.panelSICommands.TabIndex = 17;
            // 
            // btnRemoveSI
            // 
            this.btnRemoveSI.Location = new System.Drawing.Point(500, 3);
            this.btnRemoveSI.Name = "btnRemoveSI";
            this.btnRemoveSI.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSI.TabIndex = 19;
            this.btnRemoveSI.Text = "Remove Selected";
            this.btnRemoveSI.UseVisualStyleBackColor = true;
            this.btnRemoveSI.Click += new System.EventHandler(this.btnRemoveSI_Click);
            // 
            // ucLabel8
            // 
            this.ucLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ucLabel8.Location = new System.Drawing.Point(4, 9);
            this.ucLabel8.Name = "ucLabel8";
            this.ucLabel8.Size = new System.Drawing.Size(184, 13);
            this.ucLabel8.TabIndex = 14;
            this.ucLabel8.Text = "Shipping Instructions Received";
            // 
            // btnResend304
            // 
            this.btnResend304.Enabled = false;
            this.btnResend304.Location = new System.Drawing.Point(382, 4);
            this.btnResend304.Name = "btnResend304";
            this.btnResend304.Size = new System.Drawing.Size(109, 23);
            this.btnResend304.TabIndex = 18;
            this.btnResend304.Text = "Resend Selected";
            this.btnResend304.UseVisualStyleBackColor = true;
            this.btnResend304.Click += new System.EventHandler(this.btnResend304_Click);
            // 
            // panelTopSI
            // 
            this.panelTopSI.Controls.Add(this.ucLabel5);
            this.panelTopSI.Controls.Add(this.listUnprocessedSI);
            this.panelTopSI.Controls.Add(this.btnArchiveSI);
            this.panelTopSI.Controls.Add(this.ucLabel6);
            this.panelTopSI.Controls.Add(this.ucLabel7);
            this.panelTopSI.Controls.Add(this.btnReProcessSI);
            this.panelTopSI.Controls.Add(this.listFailedSI);
            this.panelTopSI.Controls.Add(this.btnProcessSI);
            this.panelTopSI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopSI.Location = new System.Drawing.Point(0, 0);
            this.panelTopSI.Name = "panelTopSI";
            this.panelTopSI.Size = new System.Drawing.Size(356, 229);
            this.panelTopSI.TabIndex = 16;
            // 
            // ucLabel5
            // 
            this.ucLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ucLabel5.Location = new System.Drawing.Point(3, 1);
            this.ucLabel5.Name = "ucLabel5";
            this.ucLabel5.Size = new System.Drawing.Size(283, 24);
            this.ucLabel5.TabIndex = 7;
            this.ucLabel5.Text = "Shipping Instructions Processing";
            // 
            // listUnprocessedSI
            // 
            this.listUnprocessedSI.FormattingEnabled = true;
            this.listUnprocessedSI.Location = new System.Drawing.Point(6, 44);
            this.listUnprocessedSI.Name = "listUnprocessedSI";
            this.listUnprocessedSI.Size = new System.Drawing.Size(388, 56);
            this.listUnprocessedSI.TabIndex = 8;
            // 
            // btnArchiveSI
            // 
            this.btnArchiveSI.Location = new System.Drawing.Point(400, 164);
            this.btnArchiveSI.Name = "btnArchiveSI";
            this.btnArchiveSI.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveSI.TabIndex = 15;
            this.btnArchiveSI.Text = "Archive";
            this.btnArchiveSI.UseVisualStyleBackColor = true;
            this.btnArchiveSI.Click += new System.EventHandler(this.btnArchiveSI_Click);
            // 
            // ucLabel6
            // 
            this.ucLabel6.Location = new System.Drawing.Point(6, 28);
            this.ucLabel6.Name = "ucLabel6";
            this.ucLabel6.Size = new System.Drawing.Size(190, 13);
            this.ucLabel6.TabIndex = 7;
            this.ucLabel6.Text = "Unprocessed Shipping Instruction Files";
            // 
            // ucLabel7
            // 
            this.ucLabel7.Location = new System.Drawing.Point(4, 118);
            this.ucLabel7.Name = "ucLabel7";
            this.ucLabel7.Size = new System.Drawing.Size(96, 13);
            this.ucLabel7.TabIndex = 9;
            this.ucLabel7.Text = "Failed Cargo Detail";
            // 
            // btnReProcessSI
            // 
            this.btnReProcessSI.Location = new System.Drawing.Point(400, 134);
            this.btnReProcessSI.Name = "btnReProcessSI";
            this.btnReProcessSI.Size = new System.Drawing.Size(75, 23);
            this.btnReProcessSI.TabIndex = 12;
            this.btnReProcessSI.Text = "Re-Process";
            this.btnReProcessSI.UseVisualStyleBackColor = true;
            this.btnReProcessSI.Click += new System.EventHandler(this.btnReProcessSI_Click);
            // 
            // listFailedSI
            // 
            this.listFailedSI.FormattingEnabled = true;
            this.listFailedSI.Location = new System.Drawing.Point(7, 134);
            this.listFailedSI.Name = "listFailedSI";
            this.listFailedSI.Size = new System.Drawing.Size(386, 82);
            this.listFailedSI.TabIndex = 10;
            // 
            // btnProcessSI
            // 
            this.btnProcessSI.Location = new System.Drawing.Point(400, 44);
            this.btnProcessSI.Name = "btnProcessSI";
            this.btnProcessSI.Size = new System.Drawing.Size(75, 23);
            this.btnProcessSI.TabIndex = 11;
            this.btnProcessSI.Text = "Process";
            this.btnProcessSI.UseVisualStyleBackColor = true;
            this.btnProcessSI.Click += new System.EventHandler(this.btnProcessSI_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnTOPS);
            this.panelTop.Controls.Add(this.btnSendITV);
            this.panelTop.Controls.Add(this.btnBOLs);
            this.panelTop.Controls.Add(this.cbxShowFileList);
            this.panelTop.Controls.Add(this.ucGroupBox1);
            this.panelTop.Controls.Add(this.ucLabel9);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(734, 113);
            this.panelTop.TabIndex = 12;
            // 
            // btnTOPS
            // 
            this.btnTOPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTOPS.Location = new System.Drawing.Point(651, 60);
            this.btnTOPS.Name = "btnTOPS";
            this.btnTOPS.Size = new System.Drawing.Size(75, 23);
            this.btnTOPS.TabIndex = 19;
            this.btnTOPS.Text = "Send TOPS";
            this.btnTOPS.UseVisualStyleBackColor = true;
            this.btnTOPS.Click += new System.EventHandler(this.btnTOPS_Click);
            // 
            // btnSendITV
            // 
            this.btnSendITV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendITV.Location = new System.Drawing.Point(651, 32);
            this.btnSendITV.Name = "btnSendITV";
            this.btnSendITV.Size = new System.Drawing.Size(75, 23);
            this.btnSendITV.TabIndex = 18;
            this.btnSendITV.Text = "Send ITV";
            this.btnSendITV.UseVisualStyleBackColor = true;
            this.btnSendITV.Click += new System.EventHandler(this.btnSendITV_Click);
            // 
            // btnBOLs
            // 
            this.btnBOLs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBOLs.Location = new System.Drawing.Point(651, 4);
            this.btnBOLs.Name = "btnBOLs";
            this.btnBOLs.Size = new System.Drawing.Size(75, 23);
            this.btnBOLs.TabIndex = 17;
            this.btnBOLs.Text = "Send BOLs";
            this.btnBOLs.UseVisualStyleBackColor = true;
            this.btnBOLs.Click += new System.EventHandler(this.btnBOLs_Click);
            // 
            // cbxShowFileList
            // 
            this.cbxShowFileList.Location = new System.Drawing.Point(183, 3);
            this.cbxShowFileList.Name = "cbxShowFileList";
            this.cbxShowFileList.Size = new System.Drawing.Size(104, 24);
            this.cbxShowFileList.TabIndex = 16;
            this.cbxShowFileList.Text = "Show File Lists";
            this.cbxShowFileList.UseVisualStyleBackColor = true;
            this.cbxShowFileList.YN = "N";
            this.cbxShowFileList.CheckedChanged += new System.EventHandler(this.cbxShowFileList_CheckedChanged_1);
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.btnSearch);
            this.ucGroupBox1.Controls.Add(this.txtVIN);
            this.ucGroupBox1.Controls.Add(this.txtBookingNo);
            this.ucGroupBox1.Controls.Add(this.cbxShowAll);
            this.ucGroupBox1.Controls.Add(this.grpDays);
            this.ucGroupBox1.Controls.Add(this.btnRefreshDetail);
            this.ucGroupBox1.Location = new System.Drawing.Point(5, 24);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(724, 82);
            this.ucGroupBox1.TabIndex = 15;
            this.ucGroupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(590, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVIN
            // 
            this.txtVIN.LabelText = "VIN";
            this.txtVIN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVIN.LinkDisabledMessage = "Link Disabled";
            this.txtVIN.Location = new System.Drawing.Point(318, 13);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(124, 20);
            this.txtVIN.TabIndex = 15;
            this.txtVIN.TextChanged += new System.EventHandler(this.txtVIN_TextChanged);
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(178, 14);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
            this.txtBookingNo.TabIndex = 14;
            this.txtBookingNo.TextChanged += new System.EventHandler(this.txtBookingNo_TextChanged);
            // 
            // cbxShowAll
            // 
            this.cbxShowAll.Location = new System.Drawing.Point(5, 14);
            this.cbxShowAll.Name = "cbxShowAll";
            this.cbxShowAll.Size = new System.Drawing.Size(119, 19);
            this.cbxShowAll.TabIndex = 8;
            this.cbxShowAll.Text = "Show Processed";
            this.cbxShowAll.UseVisualStyleBackColor = true;
            this.cbxShowAll.YN = "N";
            this.cbxShowAll.CheckedChanged += new System.EventHandler(this.cbxShowAll_CheckedChanged);
            // 
            // grpDays
            // 
            this.grpDays.Controls.Add(this.rbAll);
            this.grpDays.Controls.Add(this.rb30Days);
            this.grpDays.Controls.Add(this.rb60Days);
            this.grpDays.Location = new System.Drawing.Point(463, 8);
            this.grpDays.Name = "grpDays";
            this.grpDays.Size = new System.Drawing.Size(99, 68);
            this.grpDays.TabIndex = 13;
            this.grpDays.TabStop = false;
            this.grpDays.Text = "Go back this far";
            // 
            // rbAll
            // 
            this.rbAll.Location = new System.Drawing.Point(10, 47);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(63, 16);
            this.rbAll.TabIndex = 12;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rb30Days
            // 
            this.rb30Days.Checked = true;
            this.rb30Days.Location = new System.Drawing.Point(10, 15);
            this.rb30Days.Name = "rb30Days";
            this.rb30Days.Size = new System.Drawing.Size(66, 16);
            this.rb30Days.TabIndex = 10;
            this.rb30Days.TabStop = true;
            this.rb30Days.Text = "30 Days";
            this.rb30Days.UseVisualStyleBackColor = true;
            // 
            // rb60Days
            // 
            this.rb60Days.Location = new System.Drawing.Point(10, 31);
            this.rb60Days.Name = "rb60Days";
            this.rb60Days.Size = new System.Drawing.Size(68, 16);
            this.rb60Days.TabIndex = 11;
            this.rb60Days.Text = "60 Days";
            this.rb60Days.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDetail
            // 
            this.btnRefreshDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshDetail.Location = new System.Drawing.Point(590, 48);
            this.btnRefreshDetail.Name = "btnRefreshDetail";
            this.btnRefreshDetail.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshDetail.TabIndex = 9;
            this.btnRefreshDetail.Text = "Refresh";
            this.btnRefreshDetail.UseVisualStyleBackColor = true;
            this.btnRefreshDetail.Click += new System.EventHandler(this.btnRefreshDetail_Click);
            // 
            // ucLabel9
            // 
            this.ucLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ucLabel9.Location = new System.Drawing.Point(4, 0);
            this.ucLabel9.Name = "ucLabel9";
            this.ucLabel9.Size = new System.Drawing.Size(107, 24);
            this.ucLabel9.TabIndex = 8;
            this.ucLabel9.Text = "Filter Cargo";
            // 
            // tpDownloads
            // 
            this.tpDownloads.BackColor = System.Drawing.SystemColors.Control;
            this.tpDownloads.Controls.Add(this.splitDownloadSearch);
            this.tpDownloads.Controls.Add(this.pnlDownloadsCancel);
            this.tpDownloads.Controls.Add(this.pnlDownloadsTop);
            this.tpDownloads.Location = new System.Drawing.Point(4, 22);
            this.tpDownloads.Name = "tpDownloads";
            this.tpDownloads.Size = new System.Drawing.Size(734, 606);
            this.tpDownloads.TabIndex = 1;
            this.tpDownloads.Text = "Downloads";
            // 
            // splitDownloadSearch
            // 
            this.splitDownloadSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDownloadSearch.IsSplitterFixed = true;
            this.splitDownloadSearch.Location = new System.Drawing.Point(0, 81);
            this.splitDownloadSearch.Name = "splitDownloadSearch";
            // 
            // splitDownloadSearch.Panel1
            // 
            this.splitDownloadSearch.Panel1.Controls.Add(this.grdDownloadResults);
            // 
            // splitDownloadSearch.Panel2
            // 
            this.splitDownloadSearch.Panel2.Controls.Add(this.txtFileDisplay);
            this.splitDownloadSearch.Size = new System.Drawing.Size(746, 525);
            this.splitDownloadSearch.SplitterDistance = 337;
            this.splitDownloadSearch.TabIndex = 5;
            // 
            // grdDownloadResults
            // 
            grdDownloadResults_DesignTimeLayout.LayoutString = resources.GetString("grdDownloadResults_DesignTimeLayout.LayoutString");
            this.grdDownloadResults.DesignTimeLayout = grdDownloadResults_DesignTimeLayout;
            this.grdDownloadResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDownloadResults.ExportFileID = null;
            this.grdDownloadResults.GroupByBoxVisible = false;
            this.grdDownloadResults.Location = new System.Drawing.Point(0, 0);
            this.grdDownloadResults.Name = "grdDownloadResults";
            this.grdDownloadResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdDownloadResults.Size = new System.Drawing.Size(337, 525);
            this.grdDownloadResults.TabIndex = 1;
            this.grdDownloadResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDownloadResults_ColumnButtonClick);
            this.grdDownloadResults.SelectionChanged += new System.EventHandler(this.grdDownloadResults_SelectionChanged);
            // 
            // txtFileDisplay
            // 
            this.txtFileDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.txtFileDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileDisplay.ForeColor = System.Drawing.Color.Black;
            this.txtFileDisplay.LinkDisabledMessage = "Link Disabled";
            this.txtFileDisplay.Location = new System.Drawing.Point(0, 0);
            this.txtFileDisplay.Multiline = true;
            this.txtFileDisplay.Name = "txtFileDisplay";
            this.txtFileDisplay.ReadOnly = true;
            this.txtFileDisplay.Size = new System.Drawing.Size(405, 525);
            this.txtFileDisplay.TabIndex = 2;
            this.txtFileDisplay.TabStop = false;
            // 
            // pnlDownloadsCancel
            // 
            this.pnlDownloadsCancel.Controls.Add(this.lblProgress);
            this.pnlDownloadsCancel.Controls.Add(this.btnCancelSearch);
            this.pnlDownloadsCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDownloadsCancel.Location = new System.Drawing.Point(0, 55);
            this.pnlDownloadsCancel.Name = "pnlDownloadsCancel";
            this.pnlDownloadsCancel.Size = new System.Drawing.Size(746, 26);
            this.pnlDownloadsCancel.TabIndex = 4;
            this.pnlDownloadsCancel.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(594, 7);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "Progress";
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Location = new System.Drawing.Point(496, 1);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(91, 23);
            this.btnCancelSearch.TabIndex = 3;
            this.btnCancelSearch.Text = "Cancel Search";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // pnlDownloadsTop
            // 
            this.pnlDownloadsTop.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDownloadsTop.Controls.Add(this.Search);
            this.pnlDownloadsTop.Controls.Add(this.txtSearchString);
            this.pnlDownloadsTop.Controls.Add(this.rbShippingInstructions);
            this.pnlDownloadsTop.Controls.Add(this.rbCargoDetail);
            this.pnlDownloadsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDownloadsTop.Location = new System.Drawing.Point(0, 0);
            this.pnlDownloadsTop.Name = "pnlDownloadsTop";
            this.pnlDownloadsTop.Size = new System.Drawing.Size(746, 55);
            this.pnlDownloadsTop.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(496, 26);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(91, 23);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // txtSearchString
            // 
            this.txtSearchString.LabelText = "Search for This";
            this.txtSearchString.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSearchString.LinkDisabledMessage = "Link Disabled";
            this.txtSearchString.Location = new System.Drawing.Point(275, 28);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(199, 20);
            this.txtSearchString.TabIndex = 2;
            // 
            // rbShippingInstructions
            // 
            this.rbShippingInstructions.Location = new System.Drawing.Point(17, 31);
            this.rbShippingInstructions.Name = "rbShippingInstructions";
            this.rbShippingInstructions.Size = new System.Drawing.Size(132, 19);
            this.rbShippingInstructions.TabIndex = 1;
            this.rbShippingInstructions.Text = "Shipping Instructions Downloads";
            this.rbShippingInstructions.UseVisualStyleBackColor = true;
            // 
            // rbCargoDetail
            // 
            this.rbCargoDetail.Checked = true;
            this.rbCargoDetail.Location = new System.Drawing.Point(17, 9);
            this.rbCargoDetail.Name = "rbCargoDetail";
            this.rbCargoDetail.Size = new System.Drawing.Size(104, 19);
            this.rbCargoDetail.TabIndex = 0;
            this.rbCargoDetail.TabStop = true;
            this.rbCargoDetail.Text = "Cargo Detail Downloads";
            this.rbCargoDetail.UseVisualStyleBackColor = true;
            // 
            // tpBatteryDisconnects
            // 
            this.tpBatteryDisconnects.Controls.Add(this.panel1);
            this.tpBatteryDisconnects.Controls.Add(this.grdBatteryDisconnect);
            this.tpBatteryDisconnects.Location = new System.Drawing.Point(4, 22);
            this.tpBatteryDisconnects.Name = "tpBatteryDisconnects";
            this.tpBatteryDisconnects.Size = new System.Drawing.Size(734, 606);
            this.tpBatteryDisconnects.TabIndex = 2;
            this.tpBatteryDisconnects.Text = "Battery Disconnect Errors";
            this.tpBatteryDisconnects.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBDRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 35);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOTE: This is how the data appears in LINE.  Please put the VIN in the correct Ca" +
                "rgo Type (CARBD or VANBD).";
            // 
            // btnBDRefresh
            // 
            this.btnBDRefresh.Location = new System.Drawing.Point(6, 5);
            this.btnBDRefresh.Name = "btnBDRefresh";
            this.btnBDRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnBDRefresh.TabIndex = 0;
            this.btnBDRefresh.Text = "Refresh";
            this.btnBDRefresh.UseVisualStyleBackColor = true;
            this.btnBDRefresh.Click += new System.EventHandler(this.btnBDRefresh_Click);
            // 
            // grdBatteryDisconnect
            // 
            this.grdBatteryDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            grdBatteryDisconnect_DesignTimeLayout.LayoutString = resources.GetString("grdBatteryDisconnect_DesignTimeLayout.LayoutString");
            this.grdBatteryDisconnect.DesignTimeLayout = grdBatteryDisconnect_DesignTimeLayout;
            this.grdBatteryDisconnect.ExportFileID = null;
            this.grdBatteryDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdBatteryDisconnect.Location = new System.Drawing.Point(8, 41);
            this.grdBatteryDisconnect.Name = "grdBatteryDisconnect";
            this.grdBatteryDisconnect.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdBatteryDisconnect.Size = new System.Drawing.Size(730, 557);
            this.grdBatteryDisconnect.TabIndex = 0;
            this.grdBatteryDisconnect.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdBatteryDisconnect_FormattingRow);
            // 
            // tpOverHeights
            // 
            this.tpOverHeights.Controls.Add(this.grdOverheight);
            this.tpOverHeights.Controls.Add(this.ucPanel2);
            this.tpOverHeights.Location = new System.Drawing.Point(4, 22);
            this.tpOverHeights.Name = "tpOverHeights";
            this.tpOverHeights.Size = new System.Drawing.Size(734, 606);
            this.tpOverHeights.TabIndex = 3;
            this.tpOverHeights.Text = "Over Heights";
            this.tpOverHeights.UseVisualStyleBackColor = true;
            // 
            // grdOverheight
            // 
            this.grdOverheight.ColumnAutoResize = true;
            grdOverheight_DesignTimeLayout.LayoutString = resources.GetString("grdOverheight_DesignTimeLayout.LayoutString");
            this.grdOverheight.DesignTimeLayout = grdOverheight_DesignTimeLayout;
            this.grdOverheight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOverheight.ExportFileID = null;
            this.grdOverheight.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdOverheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdOverheight.FrozenColumns = 1;
            this.grdOverheight.Location = new System.Drawing.Point(0, 30);
            this.grdOverheight.Name = "grdOverheight";
            this.grdOverheight.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdOverheight.Size = new System.Drawing.Size(746, 576);
            this.grdOverheight.TabIndex = 34;
            // 
            // ucPanel2
            // 
            this.ucPanel2.Controls.Add(this.btnRefreshOverHt);
            this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel2.Location = new System.Drawing.Point(0, 0);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(746, 30);
            this.ucPanel2.TabIndex = 36;
            // 
            // btnRefreshOverHt
            // 
            this.btnRefreshOverHt.Location = new System.Drawing.Point(8, 3);
            this.btnRefreshOverHt.Name = "btnRefreshOverHt";
            this.btnRefreshOverHt.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshOverHt.TabIndex = 35;
            this.btnRefreshOverHt.Text = "Refresh";
            this.btnRefreshOverHt.UseVisualStyleBackColor = true;
            this.btnRefreshOverHt.Click += new System.EventHandler(this.btnRefreshOverHt_Click);
            // 
            // bgwDownloads
            // 
            this.bgwDownloads.WorkerReportsProgress = true;
            this.bgwDownloads.WorkerSupportsCancellation = true;
            this.bgwDownloads.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownloads_DoWork);
            this.bgwDownloads.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDownloads_ProgressChanged);
            this.bgwDownloads.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownloads_RunWorkerCompleted);
            // 
            // frmIAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(742, 632);
            this.Controls.Add(this.tabMain);
            this.Name = "frmIAL";
            this.Text = "IAL EDI Processing";
            this.tabMain.ResumeLayout(false);
            this.tpShippingInstructions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLINEVins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIALVins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShippingInstructions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSISummary)).EndInit();
            this.pnlSITop.ResumeLayout(false);
            this.tpMonitor.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnprocessedDetail)).EndInit();
            this.ucPanel1.ResumeLayout(false);
            this.ucPanel1.PerformLayout();
            this.panelTopDtl.ResumeLayout(false);
            this.panelTopDtl.PerformLayout();
            this.pnlSI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUnprocessedSI)).EndInit();
            this.panelSICommands.ResumeLayout(false);
            this.panelSICommands.PerformLayout();
            this.panelTopSI.ResumeLayout(false);
            this.panelTopSI.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ucGroupBox1.ResumeLayout(false);
            this.ucGroupBox1.PerformLayout();
            this.grpDays.ResumeLayout(false);
            this.tpDownloads.ResumeLayout(false);
            this.splitDownloadSearch.Panel1.ResumeLayout(false);
            this.splitDownloadSearch.Panel2.ResumeLayout(false);
            this.splitDownloadSearch.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDownloadSearch)).EndInit();
            this.splitDownloadSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDownloadResults)).EndInit();
            this.pnlDownloadsCancel.ResumeLayout(false);
            this.pnlDownloadsCancel.PerformLayout();
            this.pnlDownloadsTop.ResumeLayout(false);
            this.pnlDownloadsTop.PerformLayout();
            this.tpBatteryDisconnects.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatteryDisconnect)).EndInit();
            this.tpOverHeights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOverheight)).EndInit();
            this.ucPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tpMonitor;
		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucPanel pnlFiles;
		private CommonWinCtrls.ucGridEx grdUnprocessedDetail;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucLabel ucLabel2;
		private CommonWinCtrls.ucButton btnReLoadDetail;
		private CommonWinCtrls.ucPanel panelTopDtl;
		private CommonWinCtrls.ucButton btnArchiveDetail;
		private CommonWinCtrls.ucLabel ucLabel4;
		private CommonWinCtrls.ucListBox listDetailFiles;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucLabel ucLabel3;
		private CommonWinCtrls.ucButton btnProcessFiles;
		private CommonWinCtrls.ucButton btnReprocessDtl;
		private CommonWinCtrls.ucListBox listFailedDetail;
		private CommonWinCtrls.ucPanel pnlSI;
		private CommonWinCtrls.ucGridEx grdUnprocessedSI;
		private CommonWinCtrls.ucPanel panelSICommands;
		private CommonWinCtrls.ucButton btnRemoveSI;
		private CommonWinCtrls.ucLabel ucLabel8;
		private CommonWinCtrls.ucButton btnResend304;
		private CommonWinCtrls.ucPanel panelTopSI;
		private CommonWinCtrls.ucLabel ucLabel5;
		private CommonWinCtrls.ucListBox listUnprocessedSI;
		private CommonWinCtrls.ucButton btnArchiveSI;
		private CommonWinCtrls.ucLabel ucLabel6;
		private CommonWinCtrls.ucLabel ucLabel7;
		private CommonWinCtrls.ucButton btnReProcessSI;
		private CommonWinCtrls.ucListBox listFailedSI;
		private CommonWinCtrls.ucButton btnProcessSI;
		private CommonWinCtrls.ucPanel panelTop;
		private CommonWinCtrls.ucButton btnSendITV;
		private CommonWinCtrls.ucButton btnBOLs;
		private CommonWinCtrls.ucCheckBox cbxShowFileList;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucCheckBox cbxShowAll;
		private CommonWinCtrls.ucGroupBox grpDays;
		private CommonWinCtrls.ucRadioButton rbAll;
		private CommonWinCtrls.ucRadioButton rb30Days;
		private CommonWinCtrls.ucRadioButton rb60Days;
		private CommonWinCtrls.ucLabel ucLabel9;
		private CommonWinCtrls.ucButton btnRefreshDetail;
		private System.Windows.Forms.TabPage tpShippingInstructions;
		private CommonWinCtrls.ucButton btnReprocess;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucTextBox txtVIN;
		private CommonWinCtrls.ucGridEx grdShippingInstructions;
        private CommonWinCtrls.ucPanel pnlSITop;
		private CommonWinCtrls.ucGridEx grdQueue;
		private CommonWinCtrls.ucButton btnPutInQueue;
		private CommonWinCtrls.ucGridEx grdSISummary;
		private CommonWinCtrls.ucGridEx grdIALVins;
		private CommonWinCtrls.ucGridEx grdLINEVins;
		private CommonWinCtrls.ucCheckBox cbxMismatches;
		private CommonWinCtrls.ucButton btnUpdateLINE;
		private CommonWinCtrls.ucButton btnTOPS;
		private System.Windows.Forms.TabPage tpDownloads;
		private CommonWinCtrls.ucPanel pnlDownloadsTop;
		private CommonWinCtrls.ucButton Search;
		private CommonWinCtrls.ucTextBox txtSearchString;
		private CommonWinCtrls.ucRadioButton rbShippingInstructions;
		private CommonWinCtrls.ucRadioButton rbCargoDetail;
		private CommonWinCtrls.ucGridEx grdDownloadResults;
		private CommonWinCtrls.ucTextBox txtFileDisplay;
		private System.ComponentModel.BackgroundWorker bgwDownloads;
		private System.Windows.Forms.Button btnCancelSearch;
		private CommonWinCtrls.ucSplitContainer splitDownloadSearch;
		private CommonWinCtrls.ucPanel pnlDownloadsCancel;
		private CommonWinCtrls.ucLabel lblProgress;
        private System.Windows.Forms.TabPage tpBatteryDisconnects;
        private System.Windows.Forms.Panel panel1;
        private CommonWinCtrls.ucButton btnBDRefresh;
        private CommonWinCtrls.ucGridEx grdBatteryDisconnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tpOverHeights;
		private CommonWinCtrls.ucGridEx grdOverheight;
		private CommonWinCtrls.ucPanel ucPanel2;
		private CommonWinCtrls.ucButton btnRefreshOverHt;
	}
}
