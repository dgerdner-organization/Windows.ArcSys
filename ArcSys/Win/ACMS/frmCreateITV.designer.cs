namespace ASL.ARC.EDITools
{
	partial class frmCreateITV
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
			Janus.Windows.GridEX.GridEXLayout grdITVHistory_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateITV));
			Janus.Windows.GridEX.GridEXLayout cmbITVCodes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbLocation_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbTerminal_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdSubCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdCargoxxx_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClear = new System.Windows.Forms.ToolStripButton();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.grdITVHistory = new CS2010.CommonWinCtrls.ucGridEx();
			this.grpCreate = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cbxShowAll = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cmbITVCodes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cbxDelay = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cmbLocation = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cmbTerminal = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.btnCreate = new CS2010.CommonWinCtrls.ucButton();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.txtActivityDate = new CS2010.CommonWinCtrls.ucDateTimePicker();
			this.grpSearch = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cbxIncludeMemo = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxBooked = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVessel = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPOL = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTCN = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPOD = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdSubCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdCargoxxx = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain.SuspendLayout();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdITVHistory)).BeginInit();
			this.grpCreate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbITVCodes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTerminal)).BeginInit();
			this.grpSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSubCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargoxxx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.toolStripSeparator1,
            this.tbbClear});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1012, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "LINE Protocol Main Toolbar";
			// 
			// tbbSearch
			// 
			this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSearch.Name = "tbbSearch";
			this.tbbSearch.Size = new System.Drawing.Size(44, 22);
			this.tbbSearch.Text = "&Search";
			this.tbbSearch.Click += new System.EventHandler(this.tbbSearch_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbClear
			// 
			this.tbbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClear.Name = "tbbClear";
			this.tbbClear.Size = new System.Drawing.Size(66, 22);
			this.tbbClear.Text = "Clear Fields";
			this.tbbClear.Click += new System.EventHandler(this.tbbClear_Click);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgress});
			this.sbrChild.Location = new System.Drawing.Point(0, 559);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(1012, 22);
			this.sbrChild.TabIndex = 2;
			this.sbrChild.Text = "statusStrip1";
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(169, 17);
			this.sbbProgressCaption.Text = "Searching... (Click here to cancel)";
			this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbbProgress
			// 
			this.sbbProgress.AutoSize = false;
			this.sbbProgress.Name = "sbbProgress";
			this.sbbProgress.Size = new System.Drawing.Size(250, 16);
			this.sbbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.panel1);
			this.pnlMain.Panel1.Controls.Add(this.grpCreate);
			this.pnlMain.Panel1.Controls.Add(this.grpSearch);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.grdSubCargo);
			this.pnlMain.Panel2.Controls.Add(this.grdCargoxxx);
			this.pnlMain.Panel2.Controls.Add(this.grdCargo);
			this.pnlMain.Size = new System.Drawing.Size(1012, 534);
			this.pnlMain.SplitterDistance = 172;
			this.pnlMain.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grdITVHistory);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(480, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(532, 172);
			this.panel1.TabIndex = 8;
			// 
			// grdITVHistory
			// 
			grdITVHistory_DesignTimeLayout.LayoutString = resources.GetString("grdITVHistory_DesignTimeLayout.LayoutString");
			this.grdITVHistory.DesignTimeLayout = grdITVHistory_DesignTimeLayout;
			this.grdITVHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdITVHistory.ExportFileID = null;
			this.grdITVHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdITVHistory.GroupByBoxVisible = false;
			this.grdITVHistory.Location = new System.Drawing.Point(0, 0);
			this.grdITVHistory.Name = "grdITVHistory";
			this.grdITVHistory.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdITVHistory.Size = new System.Drawing.Size(532, 172);
			this.grdITVHistory.TabIndex = 8;
			// 
			// grpCreate
			// 
			this.grpCreate.Controls.Add(this.cbxShowAll);
			this.grpCreate.Controls.Add(this.cmbITVCodes);
			this.grpCreate.Controls.Add(this.cbxDelay);
			this.grpCreate.Controls.Add(this.cmbLocation);
			this.grpCreate.Controls.Add(this.cmbTerminal);
			this.grpCreate.Controls.Add(this.btnCreate);
			this.grpCreate.Controls.Add(this.ucLabel1);
			this.grpCreate.Controls.Add(this.txtActivityDate);
			this.grpCreate.Dock = System.Windows.Forms.DockStyle.Left;
			this.grpCreate.Location = new System.Drawing.Point(223, 0);
			this.grpCreate.Name = "grpCreate";
			this.grpCreate.Size = new System.Drawing.Size(257, 172);
			this.grpCreate.TabIndex = 7;
			this.grpCreate.TabStop = false;
			this.grpCreate.Text = "Create ITV";
			// 
			// cbxShowAll
			// 
			this.cbxShowAll.Location = new System.Drawing.Point(185, 57);
			this.cbxShowAll.Name = "cbxShowAll";
			this.cbxShowAll.Size = new System.Drawing.Size(68, 25);
			this.cbxShowAll.TabIndex = 7;
			this.cbxShowAll.Text = "Show All";
			this.cbxShowAll.UseVisualStyleBackColor = true;
			this.cbxShowAll.YN = "N";
			this.cbxShowAll.CheckedChanged += new System.EventHandler(this.cbxShowAll_CheckedChanged);
			// 
			// cmbITVCodes
			// 
			cmbITVCodes_DesignTimeLayout.LayoutString = resources.GetString("cmbITVCodes_DesignTimeLayout.LayoutString");
			this.cmbITVCodes.DesignTimeLayout = cmbITVCodes_DesignTimeLayout;
			this.cmbITVCodes.DisplayMember = "activity_dsc";
			this.cmbITVCodes.LabelText = "Status";
			this.cmbITVCodes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbITVCodes.Location = new System.Drawing.Point(69, 15);
			this.cmbITVCodes.Name = "cmbITVCodes";
			this.cmbITVCodes.SelectedIndex = -1;
			this.cmbITVCodes.SelectedItem = null;
			this.cmbITVCodes.Size = new System.Drawing.Size(141, 20);
			this.cmbITVCodes.TabIndex = 0;
			this.cmbITVCodes.ValueMember = "activity_code";
			// 
			// cbxDelay
			// 
			this.cbxDelay.Location = new System.Drawing.Point(19, 128);
			this.cbxDelay.Name = "cbxDelay";
			this.cbxDelay.Size = new System.Drawing.Size(70, 22);
			this.cbxDelay.TabIndex = 7;
			this.cbxDelay.Text = "On Delay";
			this.cbxDelay.UseVisualStyleBackColor = true;
			this.cbxDelay.Visible = false;
			this.cbxDelay.YN = "N";
			// 
			// cmbLocation
			// 
			cmbLocation_DesignTimeLayout.LayoutString = resources.GetString("cmbLocation_DesignTimeLayout.LayoutString");
			this.cmbLocation.DesignTimeLayout = cmbLocation_DesignTimeLayout;
			this.cmbLocation.DisplayMember = "location_cd";
			this.cmbLocation.LabelText = "Location";
			this.cmbLocation.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbLocation.Location = new System.Drawing.Point(69, 57);
			this.cmbLocation.Name = "cmbLocation";
			this.cmbLocation.SelectedIndex = -1;
			this.cmbLocation.SelectedItem = null;
			this.cmbLocation.Size = new System.Drawing.Size(112, 20);
			this.cmbLocation.TabIndex = 2;
			this.cmbLocation.ValueMember = "location_cd";
			this.cmbLocation.ValueChanged += new System.EventHandler(this.cmbLocation_SelectedValueChanged);
			this.cmbLocation.TextChanged += new System.EventHandler(this.cmbLocation_SelectedValueChanged);
			this.cmbLocation.Validated += new System.EventHandler(this.cmbLocation_SelectedValueChanged);
			// 
			// cmbTerminal
			// 
			cmbTerminal_DesignTimeLayout.LayoutString = resources.GetString("cmbTerminal_DesignTimeLayout.LayoutString");
			this.cmbTerminal.DesignTimeLayout = cmbTerminal_DesignTimeLayout;
			this.cmbTerminal.DisplayMember = "descr";
			this.cmbTerminal.LabelText = "Terminal";
			this.cmbTerminal.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbTerminal.Location = new System.Drawing.Point(69, 78);
			this.cmbTerminal.Name = "cmbTerminal";
			this.cmbTerminal.SelectedIndex = -1;
			this.cmbTerminal.SelectedItem = null;
			this.cmbTerminal.Size = new System.Drawing.Size(112, 20);
			this.cmbTerminal.TabIndex = 3;
			this.cmbTerminal.ValueMember = "terminal_cd";
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(69, 99);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 4;
			this.btnCreate.Text = "Create ITV";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(1, 39);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(67, 13);
			this.ucLabel1.TabIndex = 1;
			this.ucLabel1.Text = "Activity Date";
			// 
			// txtActivityDate
			// 
			this.txtActivityDate.CustomFormat = "yyyy-MM-dd HH:mm";
			this.txtActivityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtActivityDate.Location = new System.Drawing.Point(69, 36);
			this.txtActivityDate.Name = "txtActivityDate";
			this.txtActivityDate.Size = new System.Drawing.Size(112, 20);
			this.txtActivityDate.TabIndex = 1;
			// 
			// grpSearch
			// 
			this.grpSearch.Controls.Add(this.cbxIncludeMemo);
			this.grpSearch.Controls.Add(this.cbxBooked);
			this.grpSearch.Controls.Add(this.txtBooking);
			this.grpSearch.Controls.Add(this.txtVessel);
			this.grpSearch.Controls.Add(this.txtVoyage);
			this.grpSearch.Controls.Add(this.txtPOL);
			this.grpSearch.Controls.Add(this.txtTCN);
			this.grpSearch.Controls.Add(this.txtPCFN);
			this.grpSearch.Controls.Add(this.txtPOD);
			this.grpSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.grpSearch.Location = new System.Drawing.Point(0, 0);
			this.grpSearch.Name = "grpSearch";
			this.grpSearch.Size = new System.Drawing.Size(223, 172);
			this.grpSearch.TabIndex = 0;
			this.grpSearch.TabStop = false;
			this.grpSearch.Text = "Search";
			// 
			// cbxIncludeMemo
			// 
			this.cbxIncludeMemo.Location = new System.Drawing.Point(30, 145);
			this.cbxIncludeMemo.Name = "cbxIncludeMemo";
			this.cbxIncludeMemo.Size = new System.Drawing.Size(156, 22);
			this.cbxIncludeMemo.TabIndex = 9;
			this.cbxIncludeMemo.Text = "Include Memo Bookings";
			this.cbxIncludeMemo.UseVisualStyleBackColor = true;
			this.cbxIncludeMemo.YN = "N";
			// 
			// cbxBooked
			// 
			this.cbxBooked.Location = new System.Drawing.Point(30, 124);
			this.cbxBooked.Name = "cbxBooked";
			this.cbxBooked.Size = new System.Drawing.Size(177, 18);
			this.cbxBooked.TabIndex = 8;
			this.cbxBooked.Text = "Include Cargo in Booked Status";
			this.cbxBooked.UseVisualStyleBackColor = true;
			this.cbxBooked.YN = "N";
			// 
			// txtBooking
			// 
			this.txtBooking.LabelText = "Booking";
			this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBooking.LinkDisabledMessage = "Link Disabled";
			this.txtBooking.Location = new System.Drawing.Point(50, 14);
			this.txtBooking.Name = "txtBooking";
			this.txtBooking.Size = new System.Drawing.Size(131, 20);
			this.txtBooking.TabIndex = 0;
			// 
			// txtVessel
			// 
			this.txtVessel.LabelText = "Vessel";
			this.txtVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVessel.LinkDisabledMessage = "Link Disabled";
			this.txtVessel.Location = new System.Drawing.Point(50, 98);
			this.txtVessel.Name = "txtVessel";
			this.txtVessel.Size = new System.Drawing.Size(83, 20);
			this.txtVessel.TabIndex = 4;
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(50, 77);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(83, 20);
			this.txtVoyage.TabIndex = 3;
			// 
			// txtPOL
			// 
			this.txtPOL.LabelText = "POL";
			this.txtPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPOL.LinkDisabledMessage = "Link Disabled";
			this.txtPOL.Location = new System.Drawing.Point(163, 77);
			this.txtPOL.Name = "txtPOL";
			this.txtPOL.Size = new System.Drawing.Size(53, 20);
			this.txtPOL.TabIndex = 5;
			// 
			// txtTCN
			// 
			this.txtTCN.LabelText = "TCN";
			this.txtTCN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTCN.LinkDisabledMessage = "Link Disabled";
			this.txtTCN.Location = new System.Drawing.Point(50, 35);
			this.txtTCN.Name = "txtTCN";
			this.txtTCN.Size = new System.Drawing.Size(131, 20);
			this.txtTCN.TabIndex = 1;
			// 
			// txtPCFN
			// 
			this.txtPCFN.LabelText = "PCFN";
			this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPCFN.LinkDisabledMessage = "Link Disabled";
			this.txtPCFN.Location = new System.Drawing.Point(50, 56);
			this.txtPCFN.Name = "txtPCFN";
			this.txtPCFN.Size = new System.Drawing.Size(83, 20);
			this.txtPCFN.TabIndex = 2;
			// 
			// txtPOD
			// 
			this.txtPOD.LabelText = "POD";
			this.txtPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPOD.LinkDisabledMessage = "Link Disabled";
			this.txtPOD.Location = new System.Drawing.Point(163, 98);
			this.txtPOD.Name = "txtPOD";
			this.txtPOD.Size = new System.Drawing.Size(53, 20);
			this.txtPOD.TabIndex = 6;
			// 
			// grdSubCargo
			// 
			grdSubCargo_DesignTimeLayout.LayoutString = resources.GetString("grdSubCargo_DesignTimeLayout.LayoutString");
			this.grdSubCargo.DesignTimeLayout = grdSubCargo_DesignTimeLayout;
			this.grdSubCargo.ExportFileID = null;
			this.grdSubCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdSubCargo.Location = new System.Drawing.Point(293, 250);
			this.grdSubCargo.Name = "grdSubCargo";
			this.grdSubCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdSubCargo.Size = new System.Drawing.Size(174, 66);
			this.grdSubCargo.TabIndex = 7;
			this.grdSubCargo.UseGroupRowSelector = true;
			this.grdSubCargo.Visible = false;
			// 
			// grdCargoxxx
			// 
			grdCargoxxx_DesignTimeLayout.LayoutString = resources.GetString("grdCargoxxx_DesignTimeLayout.LayoutString");
			this.grdCargoxxx.DesignTimeLayout = grdCargoxxx_DesignTimeLayout;
			this.grdCargoxxx.ExportFileID = null;
			this.grdCargoxxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdCargoxxx.Location = new System.Drawing.Point(428, 94);
			this.grdCargoxxx.Name = "grdCargoxxx";
			this.grdCargoxxx.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdCargoxxx.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both;
			this.grdCargoxxx.Size = new System.Drawing.Size(112, 87);
			this.grdCargoxxx.TabIndex = 6;
			this.grdCargoxxx.UseGroupRowSelector = true;
			this.grdCargoxxx.Visible = false;
			this.grdCargoxxx.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
			this.grdCargoxxx.GroupsChanged += new Janus.Windows.GridEX.GroupsChangedEventHandler(this.grdCargo_GroupsChanged);
			this.grdCargoxxx.SelectionChanged += new System.EventHandler(this.grdCargo_SelectionChanged);
			this.grdCargoxxx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
			// 
			// grdCargo
			// 
			grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
			this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
			this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCargo.ExportFileID = null;
			this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdCargo.Location = new System.Drawing.Point(0, 0);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdCargo.Size = new System.Drawing.Size(1012, 358);
			this.grdCargo.TabIndex = 8;
			this.grdCargo.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdCargo.SelectionChanged += new System.EventHandler(this.grdCargo_SelectionChanged);
			// 
			// frmCreateITV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 581);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmCreateITV";
			this.Text = "Create SDDC ITV messages";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLineProtocol_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLineProtocol_FormClosed);
			this.Load += new System.EventHandler(this.frmCreateITV_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdITVHistory)).EndInit();
			this.grpCreate.ResumeLayout(false);
			this.grpCreate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbITVCodes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbTerminal)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSubCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargoxxx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgress;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private CS2010.CommonWinCtrls.ucTextBox txtPOD;
		private CS2010.CommonWinCtrls.ucTextBox txtPOL;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyage;
		private CS2010.CommonWinCtrls.ucTextBox txtVessel;
		private CS2010.CommonWinCtrls.ucTextBox txtBooking;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbClear;
		private CS2010.CommonWinCtrls.ucGridEx grdCargoxxx;
		private CS2010.CommonWinCtrls.ucGridEx grdSubCargo;
		private CS2010.CommonWinCtrls.ucTextBox txtPCFN;
		private CS2010.CommonWinCtrls.ucTextBox txtTCN;
		private CS2010.CommonWinCtrls.ucGridEx grdITVHistory;
		private CS2010.CommonWinCtrls.ucGroupBox grpSearch;
		private CS2010.CommonWinCtrls.ucGroupBox grpCreate;
		private CS2010.CommonWinCtrls.ucCheckBox cbxShowAll;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbITVCodes;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbLocation;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbTerminal;
		private CS2010.CommonWinCtrls.ucButton btnCreate;
		private CS2010.CommonWinCtrls.ucLabel ucLabel1;
		private CS2010.CommonWinCtrls.ucDateTimePicker txtActivityDate;
		private CS2010.CommonWinCtrls.ucCheckBox cbxDelay;
		private CS2010.CommonWinCtrls.ucCheckBox cbxBooked;
		private CS2010.CommonWinCtrls.ucGridEx grdCargo;
		private System.Windows.Forms.Panel panel1;
		private CS2010.CommonWinCtrls.ucCheckBox cbxIncludeMemo;
	}
}