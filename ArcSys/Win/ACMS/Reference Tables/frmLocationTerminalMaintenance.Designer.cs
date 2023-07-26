namespace CS2010.ArcSys.Win
{
	partial class frmLocationTerminalMaintenance
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
			Janus.Windows.GridEX.GridEXLayout grdLocation_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLocation_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.ButtonImage");
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLocation_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column11.ButtonImage");
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLocation_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column12.ButtonImage");
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLocation_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.ChildTables.Table0.Columns.Column6.ButtonImage");
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLocation_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.ChildTables.Table0.Columns.Column7.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationTerminalMaintenance));
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbAddLocation = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.grdLocation = new CS2010.CommonWinCtrls.ucGridEx();
			this.cnuGridOps = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuGridOpsN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuGridOpsAddLoc = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridOpsEditLoc = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridOpsN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuGridOpsAddTerm = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridOpsEditTerm = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbShowAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbrMain.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdLocation)).BeginInit();
			this.cnuGridOps.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbRefresh,
            this.tbbMainN1,
            this.tbbAddLocation,
            this.tbbMainN2,
            this.tbbShowAll,
            this.toolStripSeparator1,
            this.tbbClose});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(992, 25);
			this.tbrMain.TabIndex = 1;
			this.tbrMain.Text = "toolStrip3";
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbRefresh.Name = "tbbRefresh";
			this.tbbRefresh.Size = new System.Drawing.Size(49, 22);
			this.tbbRefresh.Text = "Refresh";
			this.tbbRefresh.ToolTipText = "Refresh Results (F5)";
			this.tbbRefresh.Click += new System.EventHandler(this.tbbRefresh_Click);
			// 
			// tbbMainN1
			// 
			this.tbbMainN1.Name = "tbbMainN1";
			this.tbbMainN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbAddLocation
			// 
			this.tbbAddLocation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbAddLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbAddLocation.Name = "tbbAddLocation";
			this.tbbAddLocation.Size = new System.Drawing.Size(73, 22);
			this.tbbAddLocation.Text = "&Add Location";
			this.tbbAddLocation.ToolTipText = "Add Location (Ctrl+N)";
			this.tbbAddLocation.Click += new System.EventHandler(this.tbbAddLocation_Click);
			// 
			// tbbMainN2
			// 
			this.tbbMainN2.Name = "tbbMainN2";
			this.tbbMainN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbClose
			// 
			this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClose.Name = "tbbClose";
			this.tbbClose.Size = new System.Drawing.Size(37, 22);
			this.tbbClose.Text = "Close";
			this.tbbClose.ToolTipText = "Close (Ctrl+F4)";
			this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.grdLocation);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(992, 695);
			this.pnlMain.TabIndex = 4;
			// 
			// grdLocation
			// 
			this.grdLocation.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdLocation.ContextMenuStrip = this.cnuGridOps;
			this.grdLocation.DataMember = "Location";
			grdLocation_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdLocation_DesignTimeLayout_Reference_0.Instance")));
			grdLocation_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("grdLocation_DesignTimeLayout_Reference_1.Instance")));
			grdLocation_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("grdLocation_DesignTimeLayout_Reference_2.Instance")));
			grdLocation_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("grdLocation_DesignTimeLayout_Reference_3.Instance")));
			grdLocation_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("grdLocation_DesignTimeLayout_Reference_4.Instance")));
			grdLocation_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdLocation_DesignTimeLayout_Reference_0,
            grdLocation_DesignTimeLayout_Reference_1,
            grdLocation_DesignTimeLayout_Reference_2,
            grdLocation_DesignTimeLayout_Reference_3,
            grdLocation_DesignTimeLayout_Reference_4});
			grdLocation_DesignTimeLayout.LayoutString = resources.GetString("grdLocation_DesignTimeLayout.LayoutString");
			this.grdLocation.DesignTimeLayout = grdLocation_DesignTimeLayout;
			this.grdLocation.DisplayFieldChooser = true;
			this.grdLocation.DisplayFieldChooserChildren = true;
			this.grdLocation.DisplayFontSelector = true;
			this.grdLocation.DisplayPreviewMenu = false;
			this.grdLocation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdLocation.ExportFileID = null;
			this.grdLocation.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdLocation.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdLocation.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdLocation.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdLocation.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdLocation.FilterRowFormatStyle.BlendGradient = 0.5F;
			this.grdLocation.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.grdLocation.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdLocation.Hierarchical = true;
			this.grdLocation.Location = new System.Drawing.Point(0, 0);
			this.grdLocation.Name = "grdLocation";
			this.grdLocation.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdLocation.Size = new System.Drawing.Size(992, 695);
			this.grdLocation.TabIndex = 0;
			this.grdLocation.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLocation_ColumnButtonClick);
			this.grdLocation.DoubleClick += new System.EventHandler(this.grdLocation_DoubleClick);
			this.grdLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdLocation_KeyDown);
			// 
			// cnuGridOps
			// 
			this.cnuGridOps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuGridOpsN1,
            this.cnuGridOpsAddLoc,
            this.cnuGridOpsEditLoc,
            this.cnuGridOpsN2,
            this.cnuGridOpsAddTerm,
            this.cnuGridOpsEditTerm});
			this.cnuGridOps.Name = "cnuGridOps";
			this.cnuGridOps.Size = new System.Drawing.Size(196, 126);
			this.cnuGridOps.Opening += new System.ComponentModel.CancelEventHandler(this.cnuGridOps_Opening);
			// 
			// cnuGridOpsN1
			// 
			this.cnuGridOpsN1.Name = "cnuGridOpsN1";
			this.cnuGridOpsN1.Size = new System.Drawing.Size(192, 6);
			// 
			// cnuGridOpsAddLoc
			// 
			this.cnuGridOpsAddLoc.Name = "cnuGridOpsAddLoc";
			this.cnuGridOpsAddLoc.Size = new System.Drawing.Size(195, 22);
			this.cnuGridOpsAddLoc.Text = "Add New Location";
			this.cnuGridOpsAddLoc.Click += new System.EventHandler(this.tbbAddLocation_Click);
			// 
			// cnuGridOpsEditLoc
			// 
			this.cnuGridOpsEditLoc.Name = "cnuGridOpsEditLoc";
			this.cnuGridOpsEditLoc.Size = new System.Drawing.Size(195, 22);
			this.cnuGridOpsEditLoc.Text = "Edit Location";
			this.cnuGridOpsEditLoc.Click += new System.EventHandler(this.grdLocation_DoubleClick);
			// 
			// cnuGridOpsN2
			// 
			this.cnuGridOpsN2.Name = "cnuGridOpsN2";
			this.cnuGridOpsN2.Size = new System.Drawing.Size(192, 6);
			// 
			// cnuGridOpsAddTerm
			// 
			this.cnuGridOpsAddTerm.Name = "cnuGridOpsAddTerm";
			this.cnuGridOpsAddTerm.Size = new System.Drawing.Size(195, 22);
			this.cnuGridOpsAddTerm.Text = "Add New Terminal";
			this.cnuGridOpsAddTerm.Click += new System.EventHandler(this.cnuGridOpsAddTerm_Click);
			// 
			// cnuGridOpsEditTerm
			// 
			this.cnuGridOpsEditTerm.Name = "cnuGridOpsEditTerm";
			this.cnuGridOpsEditTerm.Size = new System.Drawing.Size(195, 22);
			this.cnuGridOpsEditTerm.Text = "Edit Terminal";
			this.cnuGridOpsEditTerm.Click += new System.EventHandler(this.grdLocation_DoubleClick);
			// 
			// tbbShowAll
			// 
			this.tbbShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("tbbShowAll.Image")));
			this.tbbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbShowAll.Name = "tbbShowAll";
			this.tbbShowAll.Size = new System.Drawing.Size(47, 22);
			this.tbbShowAll.Text = "View All";
			this.tbbShowAll.Click += new System.EventHandler(this.tbbShowAll_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// frmLocationTerminalMaintenance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 720);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmLocationTerminalMaintenance";
			this.Text = "Location Terminal Maintenance";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLocationTerminalMaintenance_FormClosed);
			this.Load += new System.EventHandler(this.frmLocationTerminalMaintenance_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLocationTerminalMaintenance_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdLocation)).EndInit();
			this.cnuGridOps.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripSeparator tbbMainN1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ToolStripButton tbbAddLocation;
		private System.Windows.Forms.ToolStripButton tbbClose;
		private CommonWinCtrls.ucGridEx grdLocation;
		private System.Windows.Forms.ToolStripButton tbbRefresh;
		private System.Windows.Forms.ToolStripSeparator tbbMainN2;
		private System.Windows.Forms.ContextMenuStrip cnuGridOps;
		private System.Windows.Forms.ToolStripMenuItem cnuGridOpsAddLoc;
		private System.Windows.Forms.ToolStripMenuItem cnuGridOpsEditLoc;
		private System.Windows.Forms.ToolStripSeparator cnuGridOpsN1;
		private System.Windows.Forms.ToolStripMenuItem cnuGridOpsAddTerm;
		private System.Windows.Forms.ToolStripMenuItem cnuGridOpsEditTerm;
		private System.Windows.Forms.ToolStripSeparator cnuGridOpsN2;
		private System.Windows.Forms.ToolStripButton tbbShowAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}