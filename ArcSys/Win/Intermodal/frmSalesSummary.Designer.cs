namespace CS2010.ArcSys.Win
{
    partial class frmSalesSummary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesSummary));
			Janus.Windows.GridEX.GridEXLayout grdLINE_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsSearchCargo = new System.Windows.Forms.ToolStripButton();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdLINE = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsExcludeOcean = new System.Windows.Forms.ToolStripButton();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			this.tsGrdCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdLINE)).BeginInit();
			this.ucGridToolStrip1.SuspendLayout();
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
			this.grdCargo.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdCargo.Location = new System.Drawing.Point(0, 25);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.Size = new System.Drawing.Size(782, 223);
			this.grdCargo.TabIndex = 0;
			this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
			// 
			// tsGrdCargo
			// 
			this.tsGrdCargo.GridObject = null;
			this.tsGrdCargo.HideAddButton = true;
			this.tsGrdCargo.HideDeleteButton = true;
			this.tsGrdCargo.HideEditButton = true;
			this.tsGrdCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearchCargo});
			this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
			this.tsGrdCargo.Name = "tsGrdCargo";
			this.tsGrdCargo.Size = new System.Drawing.Size(782, 25);
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
			this.ucSplitContainer1.Panel1.Controls.Add(this.grdCargo);
			this.ucSplitContainer1.Panel1.Controls.Add(this.tsGrdCargo);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdLINE);
			this.ucSplitContainer1.Panel2.Controls.Add(this.ucGridToolStrip1);
			this.ucSplitContainer1.Size = new System.Drawing.Size(782, 496);
			this.ucSplitContainer1.SplitterDistance = 248;
			this.ucSplitContainer1.TabIndex = 2;
			// 
			// grdLINE
			// 
			this.grdLINE.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdLINE_DesignTimeLayout.LayoutString = resources.GetString("grdLINE_DesignTimeLayout.LayoutString");
			this.grdLINE.DesignTimeLayout = grdLINE_DesignTimeLayout;
			this.grdLINE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdLINE.ExportFileID = null;
			this.grdLINE.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdLINE.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdLINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdLINE.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdLINE.Location = new System.Drawing.Point(0, 25);
			this.grdLINE.Name = "grdLINE";
			this.grdLINE.Size = new System.Drawing.Size(782, 219);
			this.grdLINE.TabIndex = 2;
			// 
			// ucGridToolStrip1
			// 
			this.ucGridToolStrip1.GridObject = null;
			this.ucGridToolStrip1.HideAddButton = true;
			this.ucGridToolStrip1.HideDeleteButton = true;
			this.ucGridToolStrip1.HideEditButton = true;
			this.ucGridToolStrip1.HideExportMenu = true;
			this.ucGridToolStrip1.HidePrintMenu = true;
			this.ucGridToolStrip1.HideSeparator = true;
			this.ucGridToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExcludeOcean});
			this.ucGridToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ucGridToolStrip1.Name = "ucGridToolStrip1";
			this.ucGridToolStrip1.Size = new System.Drawing.Size(782, 25);
			this.ucGridToolStrip1.TabIndex = 1;
			this.ucGridToolStrip1.Text = "ucGridToolStrip1";
			// 
			// tsExcludeOcean
			// 
			this.tsExcludeOcean.CheckOnClick = true;
			this.tsExcludeOcean.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsExcludeOcean.Image = ((System.Drawing.Image)(resources.GetObject("tsExcludeOcean.Image")));
			this.tsExcludeOcean.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsExcludeOcean.Name = "tsExcludeOcean";
			this.tsExcludeOcean.Size = new System.Drawing.Size(82, 22);
			this.tsExcludeOcean.Text = "Exclude Ocean";
			this.tsExcludeOcean.ToolTipText = "Exclude Ocean charges";
			this.tsExcludeOcean.CheckedChanged += new System.EventHandler(this.tsExcludeOcean_CheckStateChanged);
			this.tsExcludeOcean.CheckStateChanged += new System.EventHandler(this.tsExcludeOcean_CheckStateChanged);
			this.tsExcludeOcean.Click += new System.EventHandler(this.tsExcludeOcean_CheckStateChanged);
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
			// frmSalesSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.ucSplitContainer1);
			this.Name = "frmSalesSummary";
			this.Text = "Sales Summary";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesSummary_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesSummary_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			this.tsGrdCargo.ResumeLayout(false);
			this.tsGrdCargo.PerformLayout();
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.PerformLayout();
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdLINE)).EndInit();
			this.ucGridToolStrip1.ResumeLayout(false);
			this.ucGridToolStrip1.PerformLayout();
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
        private CommonWinCtrls.ucGridEx grdLINE;
        private CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private System.Windows.Forms.ToolStripButton tsExcludeOcean;

    }
}