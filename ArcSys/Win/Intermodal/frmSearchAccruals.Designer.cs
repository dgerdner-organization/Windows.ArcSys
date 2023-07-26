namespace CS2010.ArcSys.Win
{
	partial class frmSearchAccruals
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
            Janus.Windows.GridEX.GridEXLayout grdApComputedAccrual_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAccruals));
            Janus.Windows.GridEX.GridEXLayout grdApExistingAccrual_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdApComputedByCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdApExistingByCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.lblParams = new System.Windows.Forms.Label();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
            this.tbbSearch = new System.Windows.Forms.ToolStripButton();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbAccrue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbExcessColumns = new System.Windows.Forms.ToolStripButton();
            this.tbbHideDetailTable = new System.Windows.Forms.ToolStripButton();
            this.tbbShowDiff = new System.Windows.Forms.ToolStripButton();
            this.tabAccruals = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpgAccrualSummary = new System.Windows.Forms.TabPage();
            this.grdApComputedAccrual = new CS2010.CommonWinCtrls.ucGridEx();
            this.splAccruals = new Infragistics.Win.Misc.UltraSplitter();
            this.grdApExistingAccrual = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpgApAccrualByCargo = new System.Windows.Forms.TabPage();
            this.grdApComputedByCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.splAccrualByTCN = new Infragistics.Win.Misc.UltraSplitter();
            this.grdApExistingByCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.pnlTop.SuspendLayout();
            this.sbrChild.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.tabAccruals.SuspendLayout();
            this.tpgAccrualSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApComputedAccrual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApExistingAccrual)).BeginInit();
            this.tpgApAccrualByCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApComputedByCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApExistingByCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblParams
            // 
            this.lblParams.AutoSize = true;
            this.lblParams.Location = new System.Drawing.Point(4, 4);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(79, 13);
            this.lblParams.TabIndex = 0;
            this.lblParams.Text = "Search Params";
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblParams);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 25);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(782, 23);
            this.pnlTop.TabIndex = 5;
            this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
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
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 474);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(782, 22);
            this.sbrChild.TabIndex = 4;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.toolStripSeparator1,
            this.tbbAccrue,
            this.toolStripSeparator2,
            this.tbbExcessColumns,
            this.tbbHideDetailTable,
            this.tbbShowDiff});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(782, 25);
            this.tbrMain.TabIndex = 3;
            this.tbrMain.Text = "Search Available Main Toolbar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbAccrue
            // 
            this.tbbAccrue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbAccrue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbAccrue.Name = "tbbAccrue";
            this.tbbAccrue.Size = new System.Drawing.Size(44, 22);
            this.tbbAccrue.Text = "Accrue";
            this.tbbAccrue.Click += new System.EventHandler(this.tbbAccrue_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbExcessColumns
            // 
            this.tbbExcessColumns.CheckOnClick = true;
            this.tbbExcessColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbExcessColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbExcessColumns.Name = "tbbExcessColumns";
            this.tbbExcessColumns.Size = new System.Drawing.Size(111, 22);
            this.tbbExcessColumns.Text = "Hide Excess Columns";
            this.tbbExcessColumns.Click += new System.EventHandler(this.tbbExcessColumns_Click);
            // 
            // tbbHideDetailTable
            // 
            this.tbbHideDetailTable.CheckOnClick = true;
            this.tbbHideDetailTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbHideDetailTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbHideDetailTable.Name = "tbbHideDetailTable";
            this.tbbHideDetailTable.Size = new System.Drawing.Size(91, 22);
            this.tbbHideDetailTable.Text = "Hide Detail Table";
            this.tbbHideDetailTable.Click += new System.EventHandler(this.tbbHideDetailTable_Click);
            // 
            // tbbShowDiff
            // 
            this.tbbShowDiff.CheckOnClick = true;
            this.tbbShowDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbShowDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbShowDiff.Name = "tbbShowDiff";
            this.tbbShowDiff.Size = new System.Drawing.Size(120, 22);
            this.tbbShowDiff.Text = "Only Show Differences";
            this.tbbShowDiff.Click += new System.EventHandler(this.tbbShowDiff_Click);
            // 
            // tabAccruals
            // 
            this.tabAccruals.Controls.Add(this.tpgAccrualSummary);
            this.tabAccruals.Controls.Add(this.tpgApAccrualByCargo);
            this.tabAccruals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAccruals.Location = new System.Drawing.Point(0, 48);
            this.tabAccruals.Name = "tabAccruals";
            this.tabAccruals.SelectedIndex = 0;
            this.tabAccruals.Size = new System.Drawing.Size(782, 448);
            this.tabAccruals.TabIndex = 7;
            this.tabAccruals.SelectedIndexChanged += new System.EventHandler(this.tabAccruals_SelectedIndexChanged);
            // 
            // tpgAccrualSummary
            // 
            this.tpgAccrualSummary.Controls.Add(this.grdApComputedAccrual);
            this.tpgAccrualSummary.Controls.Add(this.splAccruals);
            this.tpgAccrualSummary.Controls.Add(this.grdApExistingAccrual);
            this.tpgAccrualSummary.Location = new System.Drawing.Point(4, 22);
            this.tpgAccrualSummary.Name = "tpgAccrualSummary";
            this.tpgAccrualSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAccrualSummary.Size = new System.Drawing.Size(774, 422);
            this.tpgAccrualSummary.TabIndex = 2;
            this.tpgAccrualSummary.Text = "AP/Cost Accruals";
            this.tpgAccrualSummary.UseVisualStyleBackColor = true;
            this.tpgAccrualSummary.Resize += new System.EventHandler(this.tpgAccrualSummary_Resize);
            // 
            // grdApComputedAccrual
            // 
            this.grdApComputedAccrual.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApComputedAccrual.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdApComputedAccrual_DesignTimeLayout.LayoutString = resources.GetString("grdApComputedAccrual_DesignTimeLayout.LayoutString");
            this.grdApComputedAccrual.DesignTimeLayout = grdApComputedAccrual_DesignTimeLayout;
            this.grdApComputedAccrual.DisplayFieldChooser = true;
            this.grdApComputedAccrual.DisplayFieldChooserChildren = true;
            this.grdApComputedAccrual.DisplayFontSelector = true;
            this.grdApComputedAccrual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdApComputedAccrual.ExportFileID = null;
            this.grdApComputedAccrual.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdApComputedAccrual.FilterRowFormatStyle.Alpha = 192;
            this.grdApComputedAccrual.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdApComputedAccrual.FilterRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha;
            this.grdApComputedAccrual.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdApComputedAccrual.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdApComputedAccrual.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdApComputedAccrual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApComputedAccrual.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApComputedAccrual.Location = new System.Drawing.Point(3, 3);
            this.grdApComputedAccrual.Name = "grdApComputedAccrual";
            this.grdApComputedAccrual.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApComputedAccrual.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApComputedAccrual.Size = new System.Drawing.Size(768, 172);
            this.grdApComputedAccrual.TabIndex = 9;
            this.grdApComputedAccrual.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApComputedAccrual.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdApComputedAccrual.UseGroupRowSelector = true;
            this.grdApComputedAccrual.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            // 
            // splAccruals
            // 
            this.splAccruals.BackColor = System.Drawing.Color.Transparent;
            this.splAccruals.ButtonExtent = 150;
            this.splAccruals.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splAccruals.Location = new System.Drawing.Point(3, 175);
            this.splAccruals.Name = "splAccruals";
            this.splAccruals.RestoreExtent = 162;
            this.splAccruals.Size = new System.Drawing.Size(768, 10);
            this.splAccruals.TabIndex = 12;
            // 
            // grdApExistingAccrual
            // 
            this.grdApExistingAccrual.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApExistingAccrual.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdApExistingAccrual_DesignTimeLayout.LayoutString = resources.GetString("grdApExistingAccrual_DesignTimeLayout.LayoutString");
            this.grdApExistingAccrual.DesignTimeLayout = grdApExistingAccrual_DesignTimeLayout;
            this.grdApExistingAccrual.DisplayFieldChooser = true;
            this.grdApExistingAccrual.DisplayFieldChooserChildren = true;
            this.grdApExistingAccrual.DisplayFontSelector = true;
            this.grdApExistingAccrual.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdApExistingAccrual.ExportFileID = null;
            this.grdApExistingAccrual.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdApExistingAccrual.FilterRowFormatStyle.Alpha = 192;
            this.grdApExistingAccrual.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdApExistingAccrual.FilterRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha;
            this.grdApExistingAccrual.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdApExistingAccrual.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdApExistingAccrual.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdApExistingAccrual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApExistingAccrual.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApExistingAccrual.Location = new System.Drawing.Point(3, 185);
            this.grdApExistingAccrual.Name = "grdApExistingAccrual";
            this.grdApExistingAccrual.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApExistingAccrual.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApExistingAccrual.Size = new System.Drawing.Size(768, 234);
            this.grdApExistingAccrual.TabIndex = 11;
            this.grdApExistingAccrual.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApExistingAccrual.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdApExistingAccrual.UseGroupRowSelector = true;
            this.grdApExistingAccrual.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdApExistingAccrual_FormattingRow);
            // 
            // tpgApAccrualByCargo
            // 
            this.tpgApAccrualByCargo.Controls.Add(this.grdApComputedByCargo);
            this.tpgApAccrualByCargo.Controls.Add(this.splAccrualByTCN);
            this.tpgApAccrualByCargo.Controls.Add(this.grdApExistingByCargo);
            this.tpgApAccrualByCargo.Location = new System.Drawing.Point(4, 22);
            this.tpgApAccrualByCargo.Name = "tpgApAccrualByCargo";
            this.tpgApAccrualByCargo.Padding = new System.Windows.Forms.Padding(3);
            this.tpgApAccrualByCargo.Size = new System.Drawing.Size(774, 422);
            this.tpgApAccrualByCargo.TabIndex = 1;
            this.tpgApAccrualByCargo.Text = "AP/Cost Accrual by TCN";
            this.tpgApAccrualByCargo.UseVisualStyleBackColor = true;
            this.tpgApAccrualByCargo.Resize += new System.EventHandler(this.tpgApAccrualByCargo_Resize);
            // 
            // grdApComputedByCargo
            // 
            this.grdApComputedByCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApComputedByCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdApComputedByCargo_DesignTimeLayout.LayoutString = resources.GetString("grdApComputedByCargo_DesignTimeLayout.LayoutString");
            this.grdApComputedByCargo.DesignTimeLayout = grdApComputedByCargo_DesignTimeLayout;
            this.grdApComputedByCargo.DisplayFieldChooser = true;
            this.grdApComputedByCargo.DisplayFieldChooserChildren = true;
            this.grdApComputedByCargo.DisplayFontSelector = true;
            this.grdApComputedByCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdApComputedByCargo.ExportFileID = null;
            this.grdApComputedByCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdApComputedByCargo.FilterRowFormatStyle.Alpha = 192;
            this.grdApComputedByCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdApComputedByCargo.FilterRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha;
            this.grdApComputedByCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdApComputedByCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdApComputedByCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdApComputedByCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApComputedByCargo.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApComputedByCargo.Location = new System.Drawing.Point(3, 3);
            this.grdApComputedByCargo.Name = "grdApComputedByCargo";
            this.grdApComputedByCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApComputedByCargo.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApComputedByCargo.Size = new System.Drawing.Size(768, 193);
            this.grdApComputedByCargo.TabIndex = 14;
            this.grdApComputedByCargo.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApComputedByCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdApComputedByCargo.UseGroupRowSelector = true;
            this.grdApComputedByCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            // 
            // splAccrualByTCN
            // 
            this.splAccrualByTCN.BackColor = System.Drawing.Color.Transparent;
            this.splAccrualByTCN.ButtonExtent = 150;
            this.splAccrualByTCN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splAccrualByTCN.Location = new System.Drawing.Point(3, 196);
            this.splAccrualByTCN.Name = "splAccrualByTCN";
            this.splAccrualByTCN.RestoreExtent = 162;
            this.splAccrualByTCN.Size = new System.Drawing.Size(768, 10);
            this.splAccrualByTCN.TabIndex = 13;
            // 
            // grdApExistingByCargo
            // 
            this.grdApExistingByCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApExistingByCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdApExistingByCargo_DesignTimeLayout.LayoutString = resources.GetString("grdApExistingByCargo_DesignTimeLayout.LayoutString");
            this.grdApExistingByCargo.DesignTimeLayout = grdApExistingByCargo_DesignTimeLayout;
            this.grdApExistingByCargo.DisplayFieldChooser = true;
            this.grdApExistingByCargo.DisplayFieldChooserChildren = true;
            this.grdApExistingByCargo.DisplayFontSelector = true;
            this.grdApExistingByCargo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdApExistingByCargo.ExportFileID = null;
            this.grdApExistingByCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdApExistingByCargo.FilterRowFormatStyle.Alpha = 192;
            this.grdApExistingByCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdApExistingByCargo.FilterRowFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.UseAlpha;
            this.grdApExistingByCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdApExistingByCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdApExistingByCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdApExistingByCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdApExistingByCargo.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApExistingByCargo.Location = new System.Drawing.Point(3, 206);
            this.grdApExistingByCargo.Name = "grdApExistingByCargo";
            this.grdApExistingByCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdApExistingByCargo.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdApExistingByCargo.Size = new System.Drawing.Size(768, 213);
            this.grdApExistingByCargo.TabIndex = 15;
            this.grdApExistingByCargo.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdApExistingByCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdApExistingByCargo.UseGroupRowSelector = true;
            this.grdApExistingByCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
            // 
            // frmSearchAccruals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.tabAccruals);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Name = "frmSearchAccruals";
            this.Text = "Search Accruals";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchAccruals_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchAccruals_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.tabAccruals.ResumeLayout(false);
            this.tpgAccrualSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdApComputedAccrual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApExistingAccrual)).EndInit();
            this.tpgApAccrualByCargo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdApComputedByCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApExistingByCargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.Label lblParams;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private CommonWinCtrls.ucPanel pnlTop;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTabControl tabAccruals;
		private System.Windows.Forms.ToolStripButton tbbExcessColumns;
		private System.Windows.Forms.TabPage tpgApAccrualByCargo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbAccrue;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tpgAccrualSummary;
		private CommonWinCtrls.ucGridEx grdApComputedAccrual;
		private System.Windows.Forms.ToolStripButton tbbHideDetailTable;
		private CommonWinCtrls.ucGridEx grdApExistingAccrual;
		private Infragistics.Win.Misc.UltraSplitter splAccruals;
		private System.Windows.Forms.ToolStripButton tbbShowDiff;
		private Infragistics.Win.Misc.UltraSplitter splAccrualByTCN;
		private CommonWinCtrls.ucGridEx grdApComputedByCargo;
		private CommonWinCtrls.ucGridEx grdApExistingByCargo;
	}
}