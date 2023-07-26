namespace CS2010.ArcSys.Win
{
	partial class frmShowUscRates
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
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbbChangesOnly = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbNew = new System.Windows.Forms.ToolStripButton();
			this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbN3 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbExit = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.tabUscRates = new CS2010.ArcSys.WinCtrls.ucUscRates();
			this.tbbRefreshMods = new System.Windows.Forms.ToolStripButton();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbRefresh,
            this.tbbRefreshMods,
            this.tbbChangesOnly,
            this.tbbN1,
            this.tbbNew,
            this.tbbN2,
            this.tbbSave,
            this.tbbN3,
            this.tbbExit});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1012, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbRefresh.Name = "tbbRefresh";
			this.tbbRefresh.Size = new System.Drawing.Size(72, 22);
			this.tbbRefresh.Text = "&Refresh (F5)";
			this.tbbRefresh.Click += new System.EventHandler(this.tbbRefresh_Click);
			// 
			// tbbChangesOnly
			// 
			this.tbbChangesOnly.CheckOnClick = true;
			this.tbbChangesOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbChangesOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbChangesOnly.Name = "tbbChangesOnly";
			this.tbbChangesOnly.Size = new System.Drawing.Size(107, 22);
			this.tbbChangesOnly.Text = "Show Changes Only";
			this.tbbChangesOnly.Click += new System.EventHandler(this.tbbChangesOnly_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbNew
			// 
			this.tbbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbNew.Name = "tbbNew";
			this.tbbNew.Size = new System.Drawing.Size(97, 22);
			this.tbbNew.Text = "&Add Row (Ctrl+N)";
			this.tbbNew.Click += new System.EventHandler(this.tbbNew_Click);
			// 
			// tbbN2
			// 
			this.tbbN2.Name = "tbbN2";
			this.tbbN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(77, 22);
			this.tbbSave.Text = "&Save (Ctrl+S)";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbN3
			// 
			this.tbbN3.Name = "tbbN3";
			this.tbbN3.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbExit
			// 
			this.tbbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbExit.Name = "tbbExit";
			this.tbbExit.Size = new System.Drawing.Size(29, 22);
			this.tbbExit.Text = "E&xit";
			this.tbbExit.Click += new System.EventHandler(this.tbbExit_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.tabUscRates);
			this.pnlMain.Panel2Collapsed = true;
			this.pnlMain.Size = new System.Drawing.Size(1012, 681);
			this.pnlMain.SplitterDistance = 432;
			this.pnlMain.TabIndex = 1;
			// 
			// tabUscRates
			// 
			this.tabUscRates.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
			this.tabUscRates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabUscRates.Location = new System.Drawing.Point(0, 0);
			this.tabUscRates.Name = "tabUscRates";
			this.tabUscRates.ShowDistinctDropDowns = true;
			this.tabUscRates.Size = new System.Drawing.Size(1012, 681);
			this.tabUscRates.TabIndex = 0;
			// 
			// tbbRefreshMods
			// 
			this.tbbRefreshMods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbRefreshMods.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbRefreshMods.Name = "tbbRefreshMods";
			this.tbbRefreshMods.Size = new System.Drawing.Size(77, 22);
			this.tbbRefreshMods.Text = "Refresh Mods";
			this.tbbRefreshMods.Click += new System.EventHandler(this.tbbRefreshMods_Click);
			// 
			// frmShowUscRates
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 706);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmShowUscRates";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "USC Rates";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceWindow_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceWindow_FormClosed);
			this.Load += new System.EventHandler(this.MaintenanceWindow_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceWindow_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbRefresh;
		private System.Windows.Forms.ToolStripButton tbbNew;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripSeparator tbbN3;
		private System.Windows.Forms.ToolStripButton tbbExit;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private WinCtrls.ucUscRates tabUscRates;
		private System.Windows.Forms.ToolStripButton tbbChangesOnly;
		private System.Windows.Forms.ToolStripButton tbbRefreshMods;
	}
}