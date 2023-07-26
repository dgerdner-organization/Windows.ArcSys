namespace CS2010.ArcSys.Win
{
    partial class frmTestVoyages
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestVoyages));
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsSearchCargo = new System.Windows.Forms.ToolStripButton();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCombo();
			this.tsGrdCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).BeginInit();
			this.SuspendLayout();
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
			this.tsGrdCargo.Size = new System.Drawing.Size(879, 25);
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
			this.ucSplitContainer1.Panel1.Controls.Add(this.cmbVessel);
			this.ucSplitContainer1.Panel1.Controls.Add(this.btnSearch);
			this.ucSplitContainer1.Panel1.Controls.Add(this.txtVoyage);
			this.ucSplitContainer1.Panel1.Controls.Add(this.tsGrdCargo);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdMain);
			this.ucSplitContainer1.Size = new System.Drawing.Size(879, 496);
			this.ucSplitContainer1.SplitterDistance = 107;
			this.ucSplitContainer1.TabIndex = 2;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(386, 30);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 8;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(255, 32);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(64, 20);
			this.txtVoyage.TabIndex = 2;
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.Location = new System.Drawing.Point(0, 0);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(879, 385);
			this.grdMain.TabIndex = 0;
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
			// cmbVessel
			// 
			this.cmbVessel.CodeColumn = "Vessel_Cd";
			this.cmbVessel.DescriptionColumn = "Vessel_Nm";
			cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
			this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
			this.cmbVessel.DisplayMember = "Vessel_Cd";
			this.cmbVessel.LabelText = "Vessel";
			this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVessel.Location = new System.Drawing.Point(75, 32);
			this.cmbVessel.Name = "cmbVessel";
			this.cmbVessel.SelectedIndex = -1;
			this.cmbVessel.SelectedItem = null;
			this.cmbVessel.Size = new System.Drawing.Size(100, 20);
			this.cmbVessel.TabIndex = 9;
			this.cmbVessel.ValueColumn = "Vessel_Cd";
			this.cmbVessel.ValueMember = "Vessel_Cd";
			// 
			// frmTestVoyages
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(879, 496);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.ucSplitContainer1);
			this.Name = "frmTestVoyages";
			this.Text = "Line Search";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesSummary_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesSummary_FormClosed);
			this.tsGrdCargo.ResumeLayout(false);
			this.tsGrdCargo.PerformLayout();
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.PerformLayout();
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private System.Windows.Forms.ToolStripButton tsSearchCargo;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucGridEx grdMain;
		private WinCtrls.ucVesselCombo cmbVessel;

    }
}