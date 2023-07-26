namespace CS2010.ArcSys.Win
{
    partial class frmLINEWarehouseQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLINEWarehouseQuery));
            Janus.Windows.GridEX.GridEXLayout grdAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnReceivedDt = new CS2010.CommonWinCtrls.ucButton();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.cbxVGM = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxContainers = new CS2010.CommonWinCtrls.ucCheckBox();
            this.btnSave = new CS2010.CommonWinCtrls.ucButton();
            this.btnLabels = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.btnOrphans = new CS2010.CommonWinCtrls.ucButton();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtTCN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpResults = new System.Windows.Forms.TabPage();
            this.tpAudit = new System.Windows.Forms.TabPage();
            this.grdAudit = new CS2010.CommonWinCtrls.ucGridEx();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
            this.ucSplitContainer1.Panel1.SuspendLayout();
            this.ucSplitContainer1.Panel2.SuspendLayout();
            this.ucSplitContainer1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpResults.SuspendLayout();
            this.tpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            this.sbrChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
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
            this.grdCargo.Location = new System.Drawing.Point(3, 3);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(1072, 471);
            this.grdCargo.TabIndex = 0;
            this.grdCargo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
            this.grdCargo.SortKeysChanged += new System.EventHandler(this.grdCargo_SortKeysChanged);
            this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
            this.grdCargo.TextChanged += new System.EventHandler(this.grdCargo_TextChanged);
            this.grdCargo.Validated += new System.EventHandler(this.grdCargo_Validated);
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
            this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
            this.tsGrdCargo.Name = "tsGrdCargo";
            this.tsGrdCargo.Size = new System.Drawing.Size(1086, 25);
            this.tsGrdCargo.TabIndex = 1;
            this.tsGrdCargo.Text = "ucGridToolStrip1";
            this.tsGrdCargo.Visible = false;
            // 
            // ucSplitContainer1
            // 
            this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ucSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.ucSplitContainer1.Name = "ucSplitContainer1";
            this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer1.Panel1
            // 
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnReceivedDt);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnClear);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cbxVGM);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cbxContainers);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnSave);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cmbPOD);
            this.ucSplitContainer1.Panel1.Controls.Add(this.cmbPOL);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnLabels);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.ucSplitContainer1.Panel1.Controls.Add(this.btnOrphans);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtPCFN);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtTCN);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtBookingNo);
            this.ucSplitContainer1.Panel1.Controls.Add(this.txtVoyage);
            this.ucSplitContainer1.Panel1.Controls.Add(this.tsGrdCargo);
            // 
            // ucSplitContainer1.Panel2
            // 
            this.ucSplitContainer1.Panel2.Controls.Add(this.tabMain);
            this.ucSplitContainer1.Size = new System.Drawing.Size(1086, 609);
            this.ucSplitContainer1.SplitterDistance = 102;
            this.ucSplitContainer1.TabIndex = 2;
            // 
            // btnReceivedDt
            // 
            this.btnReceivedDt.Location = new System.Drawing.Point(779, 30);
            this.btnReceivedDt.Name = "btnReceivedDt";
            this.btnReceivedDt.Size = new System.Drawing.Size(118, 23);
            this.btnReceivedDt.TabIndex = 14;
            this.btnReceivedDt.Text = "Rcvd Date Patch";
            this.btnReceivedDt.UseVisualStyleBackColor = true;
            this.btnReceivedDt.Click += new System.EventHandler(this.btnReceivedDt_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(473, 30);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbxVGM
            // 
            this.cbxVGM.Location = new System.Drawing.Point(281, 69);
            this.cbxVGM.Name = "cbxVGM";
            this.cbxVGM.Size = new System.Drawing.Size(151, 17);
            this.cbxVGM.TabIndex = 12;
            this.cbxVGM.Text = "Just VGM Entered";
            this.cbxVGM.UseVisualStyleBackColor = true;
            this.cbxVGM.YN = "N";
            // 
            // cbxContainers
            // 
            this.cbxContainers.Location = new System.Drawing.Point(281, 51);
            this.cbxContainers.Name = "cbxContainers";
            this.cbxContainers.Size = new System.Drawing.Size(104, 15);
            this.cbxContainers.TabIndex = 11;
            this.cbxContainers.Text = "Just Containers";
            this.cbxContainers.UseVisualStyleBackColor = true;
            this.cbxContainers.YN = "N";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(655, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLabels
            // 
            this.btnLabels.Location = new System.Drawing.Point(655, 6);
            this.btnLabels.Name = "btnLabels";
            this.btnLabels.Size = new System.Drawing.Size(118, 23);
            this.btnLabels.TabIndex = 6;
            this.btnLabels.Text = "Print Labels";
            this.btnLabels.UseVisualStyleBackColor = true;
            this.btnLabels.Click += new System.EventHandler(this.btnLabels_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(473, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOrphans
            // 
            this.btnOrphans.Location = new System.Drawing.Point(779, 6);
            this.btnOrphans.Name = "btnOrphans";
            this.btnOrphans.Size = new System.Drawing.Size(118, 23);
            this.btnOrphans.TabIndex = 4;
            this.btnOrphans.Text = "Clean-up Orphans";
            this.btnOrphans.UseVisualStyleBackColor = true;
            this.btnOrphans.Click += new System.EventHandler(this.btnOrphans_Click);
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(58, 48);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(73, 20);
            this.txtPCFN.TabIndex = 2;
            // 
            // txtTCN
            // 
            this.txtTCN.LabelText = "TCN";
            this.txtTCN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTCN.LinkDisabledMessage = "Link Disabled";
            this.txtTCN.Location = new System.Drawing.Point(58, 69);
            this.txtTCN.Name = "txtTCN";
            this.txtTCN.Size = new System.Drawing.Size(169, 20);
            this.txtTCN.TabIndex = 3;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(58, 27);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(96, 20);
            this.txtBookingNo.TabIndex = 1;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(58, 6);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(64, 20);
            this.txtVoyage.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpResults);
            this.tabMain.Controls.Add(this.tpAudit);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1086, 503);
            this.tabMain.TabIndex = 1;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tpResults
            // 
            this.tpResults.Controls.Add(this.grdCargo);
            this.tpResults.Location = new System.Drawing.Point(4, 22);
            this.tpResults.Name = "tpResults";
            this.tpResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpResults.Size = new System.Drawing.Size(1078, 477);
            this.tpResults.TabIndex = 0;
            this.tpResults.Text = "Cargo";
            this.tpResults.UseVisualStyleBackColor = true;
            // 
            // tpAudit
            // 
            this.tpAudit.Controls.Add(this.grdAudit);
            this.tpAudit.Location = new System.Drawing.Point(4, 22);
            this.tpAudit.Name = "tpAudit";
            this.tpAudit.Padding = new System.Windows.Forms.Padding(3);
            this.tpAudit.Size = new System.Drawing.Size(1078, 477);
            this.tpAudit.TabIndex = 1;
            this.tpAudit.Text = "Audit Trail";
            this.tpAudit.UseVisualStyleBackColor = true;
            // 
            // grdAudit
            // 
            grdAudit_DesignTimeLayout.LayoutString = resources.GetString("grdAudit_DesignTimeLayout.LayoutString");
            this.grdAudit.DesignTimeLayout = grdAudit_DesignTimeLayout;
            this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAudit.ExportFileID = null;
            this.grdAudit.GroupByBoxVisible = false;
            this.grdAudit.Location = new System.Drawing.Point(3, 3);
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAudit.Size = new System.Drawing.Size(1072, 471);
            this.grdAudit.TabIndex = 0;
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
            // cmbPOD
            // 
            this.cmbPOD.CodeColumn = "Location_Cd";
            this.cmbPOD.DescriptionColumn = "Location_Dsc";
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DisplayMember = "Location_Dsc";
            this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOD.LabelText = "POD";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(281, 28);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(168, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 9;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValueMember = "Location_Cd";
            // 
            // cmbPOL
            // 
            this.cmbPOL.CodeColumn = "Location_Cd";
            this.cmbPOL.DescriptionColumn = "Location_Dsc";
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DisplayMember = "Location_Dsc";
            this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOL.LabelText = "POL";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(281, 5);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(168, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 8;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // frmLINEWarehouseQuery
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 609);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.ucSplitContainer1);
            this.Name = "frmLINEWarehouseQuery";
            this.Text = "Line Warehouse Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesSummary_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesSummary_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.ucSplitContainer1.Panel1.ResumeLayout(false);
            this.ucSplitContainer1.Panel1.PerformLayout();
            this.ucSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
            this.ucSplitContainer1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tpResults.ResumeLayout(false);
            this.tpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdCargo;
		private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private CommonWinCtrls.ucTextBox txtTCN;
        private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucButton btnOrphans;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucButton btnLabels;
		private WinCtrls.ucLocationCombo cmbPOD;
		private WinCtrls.ucLocationCombo cmbPOL;
		private CommonWinCtrls.ucButton btnSave;
		private CommonWinCtrls.ucCheckBox cbxContainers;
		private CommonWinCtrls.ucCheckBox cbxVGM;
		private CommonWinCtrls.ucButton btnClear;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tpResults;
		private System.Windows.Forms.TabPage tpAudit;
		private CommonWinCtrls.ucGridEx grdAudit;
		private CommonWinCtrls.ucButton btnReceivedDt;

    }
}