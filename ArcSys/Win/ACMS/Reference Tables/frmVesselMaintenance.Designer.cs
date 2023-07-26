namespace CS2010.ArcSys.Win
{
	partial class frmVesselMaintenance
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
			Janus.Windows.GridEX.GridEXLayout grdVessels_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdVessels_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column10.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVesselMaintenance));
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbAddVessel = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.grdVessels = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdVessels)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbRefresh,
            this.tbbMainN1,
            this.tbbAddVessel,
            this.tbbMainN2,
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
			// tbbAddVessel
			// 
			this.tbbAddVessel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbAddVessel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbAddVessel.Name = "tbbAddVessel";
			this.tbbAddVessel.Size = new System.Drawing.Size(63, 22);
			this.tbbAddVessel.Text = "&Add Vessel";
			this.tbbAddVessel.ToolTipText = "Add Vessel (Ctrl+N)";
			this.tbbAddVessel.Click += new System.EventHandler(this.tbbAddVessel_Click);
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
			this.pnlMain.Controls.Add(this.grdVessels);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(992, 695);
			this.pnlMain.TabIndex = 4;
			// 
			// grdVessels
			// 
			this.grdVessels.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdVessels.DataMember = "Vessel";
			grdVessels_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdVessels_DesignTimeLayout_Reference_0.Instance")));
			grdVessels_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdVessels_DesignTimeLayout_Reference_0});
			grdVessels_DesignTimeLayout.LayoutString = resources.GetString("grdVessels_DesignTimeLayout.LayoutString");
			this.grdVessels.DesignTimeLayout = grdVessels_DesignTimeLayout;
			this.grdVessels.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdVessels.ExportFileID = null;
			this.grdVessels.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdVessels.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdVessels.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdVessels.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdVessels.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdVessels.FilterRowFormatStyle.BlendGradient = 0.5F;
			this.grdVessels.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdVessels.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
			this.grdVessels.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdVessels.Location = new System.Drawing.Point(0, 0);
			this.grdVessels.Name = "grdVessels";
			this.grdVessels.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdVessels.Size = new System.Drawing.Size(992, 695);
			this.grdVessels.TabIndex = 0;
			this.grdVessels.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdVessel_ColumnButtonClick);
			this.grdVessels.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdVessels_LinkClicked);
			this.grdVessels.DoubleClick += new System.EventHandler(this.grdVessel_DoubleClick);
			this.grdVessels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVessel_KeyDown);
			// 
			// frmVesselMaintenance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 720);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmVesselMaintenance";
			this.Text = "Vessel Maintenance";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVesselMaintenance_FormClosed);
			this.Load += new System.EventHandler(this.frmVesselMaintenance_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVesselMaintenance_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdVessels)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripSeparator tbbMainN1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.ToolStripButton tbbAddVessel;
		private System.Windows.Forms.ToolStripButton tbbClose;
		private CommonWinCtrls.ucGridEx grdVessels;
		private System.Windows.Forms.ToolStripButton tbbRefresh;
		private System.Windows.Forms.ToolStripSeparator tbbMainN2;
	}
}