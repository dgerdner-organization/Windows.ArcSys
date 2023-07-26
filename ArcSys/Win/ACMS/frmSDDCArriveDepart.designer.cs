namespace CS2010.ArcSys.Win
{
	partial class frmSDDCArriveDepart
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
            Janus.Windows.GridEX.GridEXLayout grdArriveDepart_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSDDCArriveDepart));
            Janus.Windows.GridEX.GridEXLayout grdAD_ITV_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdAD_LINE_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdAD_ACMS_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.tpArriveDepart = new System.Windows.Forms.TabPage();
            this.splitArriveDepart = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.splitArriveDepartTop = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdArriveDepart = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
            this.ucLabel10 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucADToDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
            this.ucLabel9 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucLabel8 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucADFromDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
            this.ucLabel5 = new CS2010.CommonWinCtrls.ucLabel();
            this.tsArriveDepart = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsSearchArriveDepart = new System.Windows.Forms.ToolStripButton();
            this.grdAD_ITV = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucLabel11 = new CS2010.CommonWinCtrls.ucLabel();
            this.splitArriveDepartBottom = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdAD_LINE = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGridToolStrip4 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tbbLINEvsACMS = new System.Windows.Forms.ToolStripButton();
            this.tbbLINEvsITV = new System.Windows.Forms.ToolStripButton();
            this.ucLabel6 = new CS2010.CommonWinCtrls.ucLabel();
            this.grdAD_ACMS = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGridToolStrip5 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tbbACMSvsLINE = new System.Windows.Forms.ToolStripButton();
            this.tbbACMSvsITV = new System.Windows.Forms.ToolStripButton();
            this.ucLabel7 = new CS2010.CommonWinCtrls.ucLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TabMain.SuspendLayout();
            this.tpArriveDepart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepart)).BeginInit();
            this.splitArriveDepart.Panel1.SuspendLayout();
            this.splitArriveDepart.Panel2.SuspendLayout();
            this.splitArriveDepart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartTop)).BeginInit();
            this.splitArriveDepartTop.Panel1.SuspendLayout();
            this.splitArriveDepartTop.Panel2.SuspendLayout();
            this.splitArriveDepartTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdArriveDepart)).BeginInit();
            this.ucPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucADToDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucADFromDays)).BeginInit();
            this.tsArriveDepart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_ITV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartBottom)).BeginInit();
            this.splitArriveDepartBottom.Panel1.SuspendLayout();
            this.splitArriveDepartBottom.Panel2.SuspendLayout();
            this.splitArriveDepartBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_LINE)).BeginInit();
            this.ucGridToolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_ACMS)).BeginInit();
            this.ucGridToolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.tpArriveDepart);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(0, 0);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(899, 523);
            this.TabMain.TabIndex = 2;
            // 
            // tpArriveDepart
            // 
            this.tpArriveDepart.Controls.Add(this.splitArriveDepart);
            this.tpArriveDepart.Location = new System.Drawing.Point(4, 22);
            this.tpArriveDepart.Name = "tpArriveDepart";
            this.tpArriveDepart.Padding = new System.Windows.Forms.Padding(3);
            this.tpArriveDepart.Size = new System.Drawing.Size(891, 497);
            this.tpArriveDepart.TabIndex = 9;
            this.tpArriveDepart.Text = "ArriveDepart";
            this.tpArriveDepart.UseVisualStyleBackColor = true;
            // 
            // splitArriveDepart
            // 
            this.splitArriveDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitArriveDepart.Location = new System.Drawing.Point(3, 3);
            this.splitArriveDepart.Name = "splitArriveDepart";
            this.splitArriveDepart.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitArriveDepart.Panel1
            // 
            this.splitArriveDepart.Panel1.Controls.Add(this.splitArriveDepartTop);
            // 
            // splitArriveDepart.Panel2
            // 
            this.splitArriveDepart.Panel2.Controls.Add(this.splitArriveDepartBottom);
            this.splitArriveDepart.Size = new System.Drawing.Size(885, 491);
            this.splitArriveDepart.SplitterDistance = 279;
            this.splitArriveDepart.TabIndex = 2;
            // 
            // splitArriveDepartTop
            // 
            this.splitArriveDepartTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitArriveDepartTop.Location = new System.Drawing.Point(0, 0);
            this.splitArriveDepartTop.Name = "splitArriveDepartTop";
            // 
            // splitArriveDepartTop.Panel1
            // 
            this.splitArriveDepartTop.Panel1.Controls.Add(this.grdArriveDepart);
            this.splitArriveDepartTop.Panel1.Controls.Add(this.ucPanel2);
            this.splitArriveDepartTop.Panel1.Controls.Add(this.ucLabel5);
            this.splitArriveDepartTop.Panel1.Controls.Add(this.tsArriveDepart);
            // 
            // splitArriveDepartTop.Panel2
            // 
            this.splitArriveDepartTop.Panel2.Controls.Add(this.grdAD_ITV);
            this.splitArriveDepartTop.Panel2.Controls.Add(this.ucLabel11);
            this.splitArriveDepartTop.Size = new System.Drawing.Size(885, 279);
            this.splitArriveDepartTop.SplitterDistance = 439;
            this.splitArriveDepartTop.TabIndex = 3;
            // 
            // grdArriveDepart
            // 
            this.grdArriveDepart.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdArriveDepart.ColumnAutoResize = true;
            grdArriveDepart_DesignTimeLayout.LayoutString = resources.GetString("grdArriveDepart_DesignTimeLayout.LayoutString");
            this.grdArriveDepart.DesignTimeLayout = grdArriveDepart_DesignTimeLayout;
            this.grdArriveDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdArriveDepart.ExportFileID = null;
            this.grdArriveDepart.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdArriveDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdArriveDepart.GroupByBoxVisible = false;
            this.grdArriveDepart.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdArriveDepart.Location = new System.Drawing.Point(0, 67);
            this.grdArriveDepart.Name = "grdArriveDepart";
            this.grdArriveDepart.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdArriveDepart.Size = new System.Drawing.Size(439, 212);
            this.grdArriveDepart.TabIndex = 0;
            this.grdArriveDepart.SelectionChanged += new System.EventHandler(this.grdArriveDepart_SelectionChanged);
            this.grdArriveDepart.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdArriveDepart_LinkClicked);
            // 
            // ucPanel2
            // 
            this.ucPanel2.Controls.Add(this.ucLabel10);
            this.ucPanel2.Controls.Add(this.ucADToDays);
            this.ucPanel2.Controls.Add(this.ucLabel9);
            this.ucPanel2.Controls.Add(this.ucLabel8);
            this.ucPanel2.Controls.Add(this.ucADFromDays);
            this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel2.Location = new System.Drawing.Point(0, 43);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(439, 24);
            this.ucPanel2.TabIndex = 3;
            // 
            // ucLabel10
            // 
            this.ucLabel10.Location = new System.Drawing.Point(181, 6);
            this.ucLabel10.Name = "ucLabel10";
            this.ucLabel10.Size = new System.Drawing.Size(88, 13);
            this.ucLabel10.TabIndex = 4;
            this.ucLabel10.Text = "days in the future";
            // 
            // ucADToDays
            // 
            this.ucADToDays.Location = new System.Drawing.Point(142, 2);
            this.ucADToDays.Name = "ucADToDays";
            this.ucADToDays.Size = new System.Drawing.Size(34, 20);
            this.ucADToDays.TabIndex = 3;
            this.ucADToDays.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ucLabel9
            // 
            this.ucLabel9.Location = new System.Drawing.Point(73, 5);
            this.ucLabel9.Name = "ucLabel9";
            this.ucLabel9.Size = new System.Drawing.Size(62, 13);
            this.ucLabel9.TabIndex = 2;
            this.ucLabel9.Text = "days ago to";
            // 
            // ucLabel8
            // 
            this.ucLabel8.Location = new System.Drawing.Point(4, 6);
            this.ucLabel8.Name = "ucLabel8";
            this.ucLabel8.Size = new System.Drawing.Size(30, 13);
            this.ucLabel8.TabIndex = 1;
            this.ucLabel8.Text = "From";
            // 
            // ucADFromDays
            // 
            this.ucADFromDays.Location = new System.Drawing.Point(35, 2);
            this.ucADFromDays.Name = "ucADFromDays";
            this.ucADFromDays.Size = new System.Drawing.Size(35, 20);
            this.ucADFromDays.TabIndex = 0;
            this.ucADFromDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // ucLabel5
            // 
            this.ucLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel5.Location = new System.Drawing.Point(0, 25);
            this.ucLabel5.Name = "ucLabel5";
            this.ucLabel5.Size = new System.Drawing.Size(356, 18);
            this.ucLabel5.TabIndex = 2;
            this.ucLabel5.Text = "List of Recent and Upcoming Departures and Arrivals";
            // 
            // tsArriveDepart
            // 
            this.tsArriveDepart.GridObject = this.grdArriveDepart;
            this.tsArriveDepart.HideAddButton = true;
            this.tsArriveDepart.HideDeleteButton = true;
            this.tsArriveDepart.HideEditButton = true;
            this.tsArriveDepart.HideExportMenu = true;
            this.tsArriveDepart.HidePrintMenu = true;
            this.tsArriveDepart.HideSeparator = true;
            this.tsArriveDepart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearchArriveDepart});
            this.tsArriveDepart.Location = new System.Drawing.Point(0, 0);
            this.tsArriveDepart.Name = "tsArriveDepart";
            this.tsArriveDepart.Size = new System.Drawing.Size(439, 25);
            this.tsArriveDepart.TabIndex = 1;
            this.tsArriveDepart.Text = "ucGridToolStrip5";
            // 
            // tsSearchArriveDepart
            // 
            this.tsSearchArriveDepart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSearchArriveDepart.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchArriveDepart.Image")));
            this.tsSearchArriveDepart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchArriveDepart.Name = "tsSearchArriveDepart";
            this.tsSearchArriveDepart.Size = new System.Drawing.Size(44, 22);
            this.tsSearchArriveDepart.Text = "Search";
            this.tsSearchArriveDepart.Click += new System.EventHandler(this.tsSearchArriveDepart_Click);
            // 
            // grdAD_ITV
            // 
            this.grdAD_ITV.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAD_ITV.ColumnAutoResize = true;
            grdAD_ITV_DesignTimeLayout.LayoutString = resources.GetString("grdAD_ITV_DesignTimeLayout.LayoutString");
            this.grdAD_ITV.DesignTimeLayout = grdAD_ITV_DesignTimeLayout;
            this.grdAD_ITV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAD_ITV.ExportFileID = null;
            this.grdAD_ITV.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAD_ITV.Location = new System.Drawing.Point(0, 18);
            this.grdAD_ITV.Name = "grdAD_ITV";
            this.grdAD_ITV.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAD_ITV.Size = new System.Drawing.Size(442, 261);
            this.grdAD_ITV.TabIndex = 0;
            this.grdAD_ITV.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAD_ITV.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // ucLabel11
            // 
            this.ucLabel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel11.Location = new System.Drawing.Point(0, 0);
            this.ucLabel11.Name = "ucLabel11";
            this.ucLabel11.Size = new System.Drawing.Size(85, 18);
            this.ucLabel11.TabIndex = 1;
            this.ucLabel11.Text = "ITV Created";
            // 
            // splitArriveDepartBottom
            // 
            this.splitArriveDepartBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitArriveDepartBottom.Location = new System.Drawing.Point(0, 0);
            this.splitArriveDepartBottom.Name = "splitArriveDepartBottom";
            // 
            // splitArriveDepartBottom.Panel1
            // 
            this.splitArriveDepartBottom.Panel1.Controls.Add(this.grdAD_LINE);
            this.splitArriveDepartBottom.Panel1.Controls.Add(this.ucGridToolStrip4);
            this.splitArriveDepartBottom.Panel1.Controls.Add(this.ucLabel6);
            // 
            // splitArriveDepartBottom.Panel2
            // 
            this.splitArriveDepartBottom.Panel2.Controls.Add(this.grdAD_ACMS);
            this.splitArriveDepartBottom.Panel2.Controls.Add(this.ucGridToolStrip5);
            this.splitArriveDepartBottom.Panel2.Controls.Add(this.ucLabel7);
            this.splitArriveDepartBottom.Size = new System.Drawing.Size(885, 208);
            this.splitArriveDepartBottom.SplitterDistance = 439;
            this.splitArriveDepartBottom.TabIndex = 0;
            // 
            // grdAD_LINE
            // 
            this.grdAD_LINE.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAD_LINE.ColumnAutoResize = true;
            grdAD_LINE_DesignTimeLayout.LayoutString = resources.GetString("grdAD_LINE_DesignTimeLayout.LayoutString");
            this.grdAD_LINE.DesignTimeLayout = grdAD_LINE_DesignTimeLayout;
            this.grdAD_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAD_LINE.ExportFileID = null;
            this.grdAD_LINE.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAD_LINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdAD_LINE.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdAD_LINE.Location = new System.Drawing.Point(0, 43);
            this.grdAD_LINE.Name = "grdAD_LINE";
            this.grdAD_LINE.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAD_LINE.Size = new System.Drawing.Size(439, 165);
            this.grdAD_LINE.TabIndex = 0;
            this.grdAD_LINE.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAD_LINE.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdAD_LINE.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdAD_LINE_LinkClicked);
            // 
            // ucGridToolStrip4
            // 
            this.ucGridToolStrip4.GridObject = null;
            this.ucGridToolStrip4.HideAddButton = true;
            this.ucGridToolStrip4.HideDeleteButton = true;
            this.ucGridToolStrip4.HideEditButton = true;
            this.ucGridToolStrip4.HideExportMenu = true;
            this.ucGridToolStrip4.HidePrintMenu = true;
            this.ucGridToolStrip4.HideSeparator = true;
            this.ucGridToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbLINEvsACMS,
            this.tbbLINEvsITV});
            this.ucGridToolStrip4.Location = new System.Drawing.Point(0, 18);
            this.ucGridToolStrip4.Name = "ucGridToolStrip4";
            this.ucGridToolStrip4.Size = new System.Drawing.Size(439, 25);
            this.ucGridToolStrip4.TabIndex = 2;
            this.ucGridToolStrip4.Text = "ucGridToolStrip4";
            // 
            // tbbLINEvsACMS
            // 
            this.tbbLINEvsACMS.CheckOnClick = true;
            this.tbbLINEvsACMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbLINEvsACMS.Image = ((System.Drawing.Image)(resources.GetObject("tbbLINEvsACMS.Image")));
            this.tbbLINEvsACMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbLINEvsACMS.Name = "tbbLINEvsACMS";
            this.tbbLINEvsACMS.Size = new System.Drawing.Size(98, 22);
            this.tbbLINEvsACMS.Text = "Mismatch w/ACMS";
            this.tbbLINEvsACMS.Click += new System.EventHandler(this.tsCompareLineACMS_Click);
            // 
            // tbbLINEvsITV
            // 
            this.tbbLINEvsITV.CheckOnClick = true;
            this.tbbLINEvsITV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbLINEvsITV.Image = ((System.Drawing.Image)(resources.GetObject("tbbLINEvsITV.Image")));
            this.tbbLINEvsITV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbLINEvsITV.Name = "tbbLINEvsITV";
            this.tbbLINEvsITV.Size = new System.Drawing.Size(86, 22);
            this.tbbLINEvsITV.Text = "Mismatch w/ITV";
            this.tbbLINEvsITV.Click += new System.EventHandler(this.tbbLINEvsITV_Click);
            // 
            // ucLabel6
            // 
            this.ucLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel6.Location = new System.Drawing.Point(0, 0);
            this.ucLabel6.Name = "ucLabel6";
            this.ucLabel6.Size = new System.Drawing.Size(80, 18);
            this.ucLabel6.TabIndex = 1;
            this.ucLabel6.Text = "Line Cargo";
            // 
            // grdAD_ACMS
            // 
            this.grdAD_ACMS.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAD_ACMS.ColumnAutoResize = true;
            grdAD_ACMS_DesignTimeLayout.LayoutString = resources.GetString("grdAD_ACMS_DesignTimeLayout.LayoutString");
            this.grdAD_ACMS.DesignTimeLayout = grdAD_ACMS_DesignTimeLayout;
            this.grdAD_ACMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAD_ACMS.ExportFileID = null;
            this.grdAD_ACMS.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAD_ACMS.Location = new System.Drawing.Point(0, 43);
            this.grdAD_ACMS.Name = "grdAD_ACMS";
            this.grdAD_ACMS.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAD_ACMS.Size = new System.Drawing.Size(442, 165);
            this.grdAD_ACMS.TabIndex = 0;
            this.grdAD_ACMS.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAD_ACMS.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdAD_ACMS.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdAD_ACMS_LinkClicked);
            // 
            // ucGridToolStrip5
            // 
            this.ucGridToolStrip5.GridObject = null;
            this.ucGridToolStrip5.HideAddButton = true;
            this.ucGridToolStrip5.HideDeleteButton = true;
            this.ucGridToolStrip5.HideEditButton = true;
            this.ucGridToolStrip5.HideExportMenu = true;
            this.ucGridToolStrip5.HidePrintMenu = true;
            this.ucGridToolStrip5.HideSeparator = true;
            this.ucGridToolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbACMSvsLINE,
            this.tbbACMSvsITV});
            this.ucGridToolStrip5.Location = new System.Drawing.Point(0, 18);
            this.ucGridToolStrip5.Name = "ucGridToolStrip5";
            this.ucGridToolStrip5.Size = new System.Drawing.Size(442, 25);
            this.ucGridToolStrip5.TabIndex = 2;
            this.ucGridToolStrip5.Text = "ucGridToolStrip5";
            // 
            // tbbACMSvsLINE
            // 
            this.tbbACMSvsLINE.CheckOnClick = true;
            this.tbbACMSvsLINE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbACMSvsLINE.Image = ((System.Drawing.Image)(resources.GetObject("tbbACMSvsLINE.Image")));
            this.tbbACMSvsLINE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbACMSvsLINE.Name = "tbbACMSvsLINE";
            this.tbbACMSvsLINE.Size = new System.Drawing.Size(92, 22);
            this.tbbACMSvsLINE.Text = "Mismatch w/LINE";
            this.tbbACMSvsLINE.Click += new System.EventHandler(this.tbbACMSvsLINE_Click);
            // 
            // tbbACMSvsITV
            // 
            this.tbbACMSvsITV.CheckOnClick = true;
            this.tbbACMSvsITV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbACMSvsITV.Image = ((System.Drawing.Image)(resources.GetObject("tbbACMSvsITV.Image")));
            this.tbbACMSvsITV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbACMSvsITV.Name = "tbbACMSvsITV";
            this.tbbACMSvsITV.Size = new System.Drawing.Size(86, 22);
            this.tbbACMSvsITV.Text = "Mismatch w/ITV";
            this.tbbACMSvsITV.Click += new System.EventHandler(this.tbbACMSvsITV_Click);
            // 
            // ucLabel7
            // 
            this.ucLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLabel7.Location = new System.Drawing.Point(0, 0);
            this.ucLabel7.Name = "ucLabel7";
            this.ucLabel7.Size = new System.Drawing.Size(96, 18);
            this.ucLabel7.TabIndex = 1;
            this.ucLabel7.Text = "ACMS Cargo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmSDDCArriveDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 523);
            this.Controls.Add(this.TabMain);
            this.Name = "frmSDDCArriveDepart";
            this.Text = "Arrive / Depart List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUnsentBookings_FormClosed);
            this.TabMain.ResumeLayout(false);
            this.tpArriveDepart.ResumeLayout(false);
            this.splitArriveDepart.Panel1.ResumeLayout(false);
            this.splitArriveDepart.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepart)).EndInit();
            this.splitArriveDepart.ResumeLayout(false);
            this.splitArriveDepartTop.Panel1.ResumeLayout(false);
            this.splitArriveDepartTop.Panel1.PerformLayout();
            this.splitArriveDepartTop.Panel2.ResumeLayout(false);
            this.splitArriveDepartTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartTop)).EndInit();
            this.splitArriveDepartTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdArriveDepart)).EndInit();
            this.ucPanel2.ResumeLayout(false);
            this.ucPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucADToDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucADFromDays)).EndInit();
            this.tsArriveDepart.ResumeLayout(false);
            this.tsArriveDepart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_ITV)).EndInit();
            this.splitArriveDepartBottom.Panel1.ResumeLayout(false);
            this.splitArriveDepartBottom.Panel1.PerformLayout();
            this.splitArriveDepartBottom.Panel2.ResumeLayout(false);
            this.splitArriveDepartBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartBottom)).EndInit();
            this.splitArriveDepartBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_LINE)).EndInit();
            this.ucGridToolStrip4.ResumeLayout(false);
            this.ucGridToolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAD_ACMS)).EndInit();
            this.ucGridToolStrip5.ResumeLayout(false);
            this.ucGridToolStrip5.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabMain;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tpArriveDepart;
		private CS2010.CommonWinCtrls.ucGridEx grdArriveDepart;
		private CS2010.CommonWinCtrls.ucGridToolStrip tsArriveDepart;
		private System.Windows.Forms.ToolStripButton tsSearchArriveDepart;
		private CS2010.CommonWinCtrls.ucSplitContainer splitArriveDepart;
		private CS2010.CommonWinCtrls.ucSplitContainer splitArriveDepartTop;
		private CS2010.CommonWinCtrls.ucSplitContainer splitArriveDepartBottom;
		private CS2010.CommonWinCtrls.ucGridEx grdAD_LINE;
		private CS2010.CommonWinCtrls.ucGridEx grdAD_ACMS;
		private CS2010.CommonWinCtrls.ucLabel ucLabel5;
		private CS2010.CommonWinCtrls.ucLabel ucLabel6;
		private CS2010.CommonWinCtrls.ucLabel ucLabel7;
		private CS2010.CommonWinCtrls.ucPanel ucPanel2;
		private CS2010.CommonWinCtrls.ucNumericUpDown ucADToDays;
		private CS2010.CommonWinCtrls.ucLabel ucLabel9;
		private CS2010.CommonWinCtrls.ucLabel ucLabel8;
		private CS2010.CommonWinCtrls.ucNumericUpDown ucADFromDays;
		private CS2010.CommonWinCtrls.ucLabel ucLabel10;
		private CS2010.CommonWinCtrls.ucGridEx grdAD_ITV;
		private CS2010.CommonWinCtrls.ucLabel ucLabel11;
		private CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip4;
		private CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip5;
		private System.Windows.Forms.ToolStripButton tbbLINEvsACMS;
		private System.Windows.Forms.ToolStripButton tbbLINEvsITV;
		private System.Windows.Forms.ToolStripButton tbbACMSvsLINE;
		private System.Windows.Forms.ToolStripButton tbbACMSvsITV;


	}
}