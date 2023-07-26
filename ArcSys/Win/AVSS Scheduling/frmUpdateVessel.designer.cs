namespace CS2010.AVSS.Win
{
    partial class frmUpdateVessel
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
            Janus.Windows.GridEX.GridEXLayout grdVesselPortCalls_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateVessel));
            Janus.Windows.GridEX.GridEXLayout grdBerthActivity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPort_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout comboVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.menuPortCallGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEditPortCall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeletePortCall = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInsertPortBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInsertPortAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCoastalScheduleReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ucSplitContainer2 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdVesselPortCalls = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsInsertBefore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInsertAfter = new System.Windows.Forms.ToolStripButton();
            this.tsAdjustDates = new System.Windows.Forms.ToolStripButton();
            this.tsAddTransShipment = new System.Windows.Forms.ToolStripButton();
            this.tsARCView = new System.Windows.Forms.ToolStripButton();
            this.grdBerthActivity = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGridToolStrip2 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsEnterMilitaryVoyage = new System.Windows.Forms.ToolStripButton();
            this.cmbPort = new CS2010.AVSS.WinCtrls.ucPortCombo();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtToDt = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtFromDt = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.comboVessel = new CS2010.AVSS.WinCtrls.ucVesselCombo();
            this.chkARC = new CS2010.CommonWinCtrls.ucCheckBox();
            this.menuPortCallGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).BeginInit();
            this.ucSplitContainer2.Panel1.SuspendLayout();
            this.ucSplitContainer2.Panel2.SuspendLayout();
            this.ucSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVesselPortCalls)).BeginInit();
            this.ucGridToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBerthActivity)).BeginInit();
            this.ucGridToolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboVessel)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPortCallGrid
            // 
            this.menuPortCallGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditPortCall,
            this.tsDeletePortCall,
            this.tsInsertPortBefore,
            this.tsInsertPortAfter,
            this.toolStripMenuItem1,
            this.tsCoastalScheduleReport});
            this.menuPortCallGrid.Name = "menuPortCallGrid";
            this.menuPortCallGrid.ShowImageMargin = false;
            this.menuPortCallGrid.Size = new System.Drawing.Size(179, 120);
            // 
            // tsEditPortCall
            // 
            this.tsEditPortCall.Name = "tsEditPortCall";
            this.tsEditPortCall.Size = new System.Drawing.Size(178, 22);
            this.tsEditPortCall.Text = "Edit";
            this.tsEditPortCall.Click += new System.EventHandler(this.tsEditPortCall_Click);
            // 
            // tsDeletePortCall
            // 
            this.tsDeletePortCall.Name = "tsDeletePortCall";
            this.tsDeletePortCall.Size = new System.Drawing.Size(178, 22);
            this.tsDeletePortCall.Text = "Delete Port Call";
            this.tsDeletePortCall.Click += new System.EventHandler(this.tsDeletePortCall_Click);
            // 
            // tsInsertPortBefore
            // 
            this.tsInsertPortBefore.Name = "tsInsertPortBefore";
            this.tsInsertPortBefore.Size = new System.Drawing.Size(178, 22);
            this.tsInsertPortBefore.Text = "Insert Before";
            this.tsInsertPortBefore.Click += new System.EventHandler(this.tsInsertPortBefore_Click);
            // 
            // tsInsertPortAfter
            // 
            this.tsInsertPortAfter.Name = "tsInsertPortAfter";
            this.tsInsertPortAfter.Size = new System.Drawing.Size(178, 22);
            this.tsInsertPortAfter.Text = "Insert After";
            this.tsInsertPortAfter.Click += new System.EventHandler(this.tsInsertPortAfter_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // tsCoastalScheduleReport
            // 
            this.tsCoastalScheduleReport.Name = "tsCoastalScheduleReport";
            this.tsCoastalScheduleReport.Size = new System.Drawing.Size(178, 22);
            this.tsCoastalScheduleReport.Text = "Coastal Schedule Report";
            this.tsCoastalScheduleReport.Click += new System.EventHandler(this.tsCoastalScheduleReport_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(177, 22);
            this.tsEdit.Text = "Edit";
            // 
            // ucSplitContainer2
            // 
            this.ucSplitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSplitContainer2.Location = new System.Drawing.Point(1, 71);
            this.ucSplitContainer2.Name = "ucSplitContainer2";
            this.ucSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer2.Panel1
            // 
            this.ucSplitContainer2.Panel1.Controls.Add(this.grdVesselPortCalls);
            this.ucSplitContainer2.Panel1.Controls.Add(this.ucGridToolStrip1);
            // 
            // ucSplitContainer2.Panel2
            // 
            this.ucSplitContainer2.Panel2.Controls.Add(this.grdBerthActivity);
            this.ucSplitContainer2.Panel2.Controls.Add(this.ucGridToolStrip2);
            this.ucSplitContainer2.Size = new System.Drawing.Size(820, 440);
            this.ucSplitContainer2.SplitterDistance = 300;
            this.ucSplitContainer2.SplitterWidth = 10;
            this.ucSplitContainer2.TabIndex = 1;
            // 
            // grdVesselPortCalls
            // 
            this.grdVesselPortCalls.ContextMenuStrip = this.menuPortCallGrid;
            grdVesselPortCalls_DesignTimeLayout.LayoutString = resources.GetString("grdVesselPortCalls_DesignTimeLayout.LayoutString");
            this.grdVesselPortCalls.DesignTimeLayout = grdVesselPortCalls_DesignTimeLayout;
            this.grdVesselPortCalls.DisplayPrintMenu = false;
            this.grdVesselPortCalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVesselPortCalls.ExportFileID = null;
            this.grdVesselPortCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdVesselPortCalls.GroupByBoxVisible = false;
            this.grdVesselPortCalls.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdVesselPortCalls.Location = new System.Drawing.Point(0, 25);
            this.grdVesselPortCalls.Name = "grdVesselPortCalls";
            this.grdVesselPortCalls.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdVesselPortCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.grdVesselPortCalls.Size = new System.Drawing.Size(820, 275);
            this.grdVesselPortCalls.TabIndex = 0;
            this.grdVesselPortCalls.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdVesselPortCalls_CellValueChanged);
            this.grdVesselPortCalls.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdVesselPortCalls_FormattingRow);
            this.grdVesselPortCalls.SelectionChanged += new System.EventHandler(this.grdVesselPortCalls_SelectionChanged);
            this.grdVesselPortCalls.DoubleClick += new System.EventHandler(this.grdVesselPortCalls_DoubleClick);
            // 
            // ucGridToolStrip1
            // 
            this.ucGridToolStrip1.GridObject = this.grdVesselPortCalls;
            this.ucGridToolStrip1.HideAddButton = true;
            this.ucGridToolStrip1.HideExportMenu = true;
            this.ucGridToolStrip1.HidePrintMenu = true;
            this.ucGridToolStrip1.HideSeparator = true;
            this.ucGridToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInsertBefore,
            this.toolStripSeparator1,
            this.tsInsertAfter,
            this.tsAdjustDates,
            this.tsAddTransShipment,
            this.tsARCView});
            this.ucGridToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ucGridToolStrip1.Name = "ucGridToolStrip1";
            this.ucGridToolStrip1.Size = new System.Drawing.Size(820, 25);
            this.ucGridToolStrip1.TabIndex = 1;
            this.ucGridToolStrip1.Text = "ucGridToolStrip1";
            this.ucGridToolStrip1.ClickAdd += new System.EventHandler(this.ucGridToolStrip1_ClickAdd);
            this.ucGridToolStrip1.ClickEdit += new System.EventHandler(this.ucGridToolStrip1_ClickEdit);
            this.ucGridToolStrip1.ClickDelete += new System.EventHandler(this.ucGridToolStrip1_ClickDelete);
            // 
            // tsInsertBefore
            // 
            this.tsInsertBefore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsInsertBefore.Image = ((System.Drawing.Image)(resources.GetObject("tsInsertBefore.Image")));
            this.tsInsertBefore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInsertBefore.Name = "tsInsertBefore";
            this.tsInsertBefore.Size = new System.Drawing.Size(75, 22);
            this.tsInsertBefore.Text = "Insert Before";
            this.tsInsertBefore.Click += new System.EventHandler(this.tsInsertBefore_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsInsertAfter
            // 
            this.tsInsertAfter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsInsertAfter.Image = ((System.Drawing.Image)(resources.GetObject("tsInsertAfter.Image")));
            this.tsInsertAfter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInsertAfter.Name = "tsInsertAfter";
            this.tsInsertAfter.Size = new System.Drawing.Size(68, 22);
            this.tsInsertAfter.Text = "Insert After";
            this.tsInsertAfter.Click += new System.EventHandler(this.tsInsertAfter_Click);
            // 
            // tsAdjustDates
            // 
            this.tsAdjustDates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAdjustDates.Image = ((System.Drawing.Image)(resources.GetObject("tsAdjustDates.Image")));
            this.tsAdjustDates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdjustDates.Name = "tsAdjustDates";
            this.tsAdjustDates.Size = new System.Drawing.Size(73, 22);
            this.tsAdjustDates.Text = "Adjust Dates";
            this.tsAdjustDates.Click += new System.EventHandler(this.tsAdjustDates_Click);
            // 
            // tsAddTransShipment
            // 
            this.tsAddTransShipment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAddTransShipment.Image = ((System.Drawing.Image)(resources.GetObject("tsAddTransShipment.Image")));
            this.tsAddTransShipment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddTransShipment.Name = "tsAddTransShipment";
            this.tsAddTransShipment.Size = new System.Drawing.Size(103, 22);
            this.tsAddTransShipment.Text = "Add Transshipment";
            this.tsAddTransShipment.Click += new System.EventHandler(this.tsAddTransShipment_Click);
            // 
            // tsARCView
            // 
            this.tsARCView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsARCView.Image = ((System.Drawing.Image)(resources.GetObject("tsARCView.Image")));
            this.tsARCView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsARCView.Name = "tsARCView";
            this.tsARCView.Size = new System.Drawing.Size(86, 22);
            this.tsARCView.Text = "Assign VoyDocs";
            this.tsARCView.Click += new System.EventHandler(this.tsARCView_Click);
            // 
            // grdBerthActivity
            // 
            grdBerthActivity_DesignTimeLayout.LayoutString = resources.GetString("grdBerthActivity_DesignTimeLayout.LayoutString");
            this.grdBerthActivity.DesignTimeLayout = grdBerthActivity_DesignTimeLayout;
            this.grdBerthActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBerthActivity.ExportFileID = null;
            this.grdBerthActivity.GroupByBoxVisible = false;
            this.grdBerthActivity.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdBerthActivity.Location = new System.Drawing.Point(0, 25);
            this.grdBerthActivity.Name = "grdBerthActivity";
            this.grdBerthActivity.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdBerthActivity.Size = new System.Drawing.Size(820, 105);
            this.grdBerthActivity.TabIndex = 0;
            this.grdBerthActivity.DoubleClick += new System.EventHandler(this.grdBerthActivity_DoubleClick);
            // 
            // ucGridToolStrip2
            // 
            this.ucGridToolStrip2.GridObject = null;
            this.ucGridToolStrip2.HideExportMenu = true;
            this.ucGridToolStrip2.HidePrintMenu = true;
            this.ucGridToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEnterMilitaryVoyage});
            this.ucGridToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.ucGridToolStrip2.Name = "ucGridToolStrip2";
            this.ucGridToolStrip2.Size = new System.Drawing.Size(820, 25);
            this.ucGridToolStrip2.TabIndex = 1;
            this.ucGridToolStrip2.Text = "ucGridToolStrip2";
            this.ucGridToolStrip2.ClickAdd += new System.EventHandler(this.ucGridToolStrip2_ClickAdd);
            this.ucGridToolStrip2.ClickEdit += new System.EventHandler(this.ucGridToolStrip2_ClickEdit);
            this.ucGridToolStrip2.ClickDelete += new System.EventHandler(this.ucGridToolStrip2_ClickDelete);
            this.ucGridToolStrip2.DoubleClick += new System.EventHandler(this.ucGridToolStrip2_ClickEdit);
            // 
            // tsEnterMilitaryVoyage
            // 
            this.tsEnterMilitaryVoyage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsEnterMilitaryVoyage.Image = ((System.Drawing.Image)(resources.GetObject("tsEnterMilitaryVoyage.Image")));
            this.tsEnterMilitaryVoyage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEnterMilitaryVoyage.Name = "tsEnterMilitaryVoyage";
            this.tsEnterMilitaryVoyage.Size = new System.Drawing.Size(84, 22);
            this.tsEnterMilitaryVoyage.Text = "Military Voyage";
            this.tsEnterMilitaryVoyage.ToolTipText = "Enter Military Voyage ";
            this.tsEnterMilitaryVoyage.Click += new System.EventHandler(this.tsEnterMilitaryVoyage_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.CodeColumn = "PORT_CD";
            this.cmbPort.DescriptionColumn = "PORT_NM";
            cmbPort_DesignTimeLayout.LayoutString = resources.GetString("cmbPort_DesignTimeLayout.LayoutString");
            this.cmbPort.DesignTimeLayout = cmbPort_DesignTimeLayout;
            this.cmbPort.DisplayMember = "PORT_CDPORT_NM";
            this.cmbPort.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbPort.LabelText = "Port:";
            this.cmbPort.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPort.Location = new System.Drawing.Point(56, 39);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.SelectedIndex = -1;
            this.cmbPort.SelectedItem = null;
            this.cmbPort.Size = new System.Drawing.Size(172, 20);
            this.cmbPort.TabIndex = 13;
            this.cmbPort.ValueColumn = "PORT_CD";
            this.cmbPort.ValueMember = "PORT_CD";
            this.cmbPort.WithBerths = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(736, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(364, 12);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(67, 20);
            this.txtVoyage.TabIndex = 8;
            // 
            // txtToDt
            // 
            this.txtToDt.EditFormat = "MMddyy";
            this.txtToDt.LabelText = "To";
            this.txtToDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtToDt.LinkDisabledMessage = "Link Disabled";
            this.txtToDt.Location = new System.Drawing.Point(518, 36);
            this.txtToDt.MaxLength = 10;
            this.txtToDt.Name = "txtToDt";
            this.txtToDt.Size = new System.Drawing.Size(90, 20);
            this.txtToDt.TabIndex = 10;
            this.txtToDt.Value = null;
            // 
            // txtFromDt
            // 
            this.txtFromDt.EditFormat = "MMddyy";
            this.txtFromDt.LabelText = "From (mmddyy)";
            this.txtFromDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtFromDt.LinkDisabledMessage = "Link Disabled";
            this.txtFromDt.Location = new System.Drawing.Point(518, 12);
            this.txtFromDt.MaxLength = 10;
            this.txtFromDt.Name = "txtFromDt";
            this.txtFromDt.Size = new System.Drawing.Size(90, 20);
            this.txtFromDt.TabIndex = 9;
            this.txtFromDt.Value = null;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(736, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboVessel
            // 
            this.comboVessel.CodeColumn = "VESSEL_CD";
            this.comboVessel.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.comboVessel.DescriptionColumn = "VESSEL_NM";
            comboVessel_DesignTimeLayout.LayoutString = resources.GetString("comboVessel_DesignTimeLayout.LayoutString");
            this.comboVessel.DesignTimeLayout = comboVessel_DesignTimeLayout;
            this.comboVessel.DisplayMember = "VESSEL_CDVESSEL_NM";
            this.comboVessel.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.comboVessel.LabelText = "Vessel:";
            this.comboVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.comboVessel.Location = new System.Drawing.Point(56, 12);
            this.comboVessel.Name = "comboVessel";
            this.comboVessel.SelectedCdNm = null;
            this.comboVessel.SelectedIndex = -1;
            this.comboVessel.SelectedItem = null;
            this.comboVessel.ShowOnlyARCVessels = true;
            this.comboVessel.Size = new System.Drawing.Size(172, 20);
            this.comboVessel.TabIndex = 7;
            this.comboVessel.ValueColumn = "VESSEL_CD";
            this.comboVessel.ValueMember = "VESSEL_CD";
            // 
            // chkARC
            // 
            this.chkARC.Checked = true;
            this.chkARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkARC.Location = new System.Drawing.Point(234, 10);
            this.chkARC.Name = "chkARC";
            this.chkARC.Size = new System.Drawing.Size(51, 24);
            this.chkARC.TabIndex = 14;
            this.chkARC.Text = "ARC";
            this.chkARC.UseVisualStyleBackColor = true;
            this.chkARC.YN = "Y";
            this.chkARC.CheckedChanged += new System.EventHandler(this.chkARC_CheckedChanged);
            // 
            // frmUpdateVessel
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(823, 511);
            this.Controls.Add(this.chkARC);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtVoyage);
            this.Controls.Add(this.txtToDt);
            this.Controls.Add(this.txtFromDt);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboVessel);
            this.Controls.Add(this.ucSplitContainer2);
            this.Name = "frmUpdateVessel";
            this.Text = "Vessel Activity ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUpdateVessel_Load);
            this.menuPortCallGrid.ResumeLayout(false);
            this.ucSplitContainer2.Panel1.ResumeLayout(false);
            this.ucSplitContainer2.Panel1.PerformLayout();
            this.ucSplitContainer2.Panel2.ResumeLayout(false);
            this.ucSplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).EndInit();
            this.ucSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVesselPortCalls)).EndInit();
            this.ucGridToolStrip1.ResumeLayout(false);
            this.ucGridToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBerthActivity)).EndInit();
            this.ucGridToolStrip2.ResumeLayout(false);
            this.ucGridToolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboVessel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolStripMenuItem tsEdit;
		private System.Windows.Forms.ContextMenuStrip menuPortCallGrid;
		private System.Windows.Forms.ToolStripMenuItem tsEditPortCall;
		private System.Windows.Forms.ToolStripMenuItem tsDeletePortCall;
		private System.Windows.Forms.ToolStripMenuItem tsInsertPortBefore;
		private System.Windows.Forms.ToolStripMenuItem tsInsertPortAfter;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsCoastalScheduleReport;
		protected CS2010.CommonWinCtrls.ucSplitContainer ucSplitContainer2;
		protected CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
		private System.Windows.Forms.ToolStripButton tsInsertBefore;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsInsertAfter;
		private System.Windows.Forms.ToolStripButton tsAdjustDates;
		private System.Windows.Forms.ToolStripButton tsAddTransShipment;
		private System.Windows.Forms.ToolStripButton tsARCView;
		protected CS2010.CommonWinCtrls.ucGridEx grdBerthActivity;
		protected CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip2;
		private System.Windows.Forms.ToolStripButton tsEnterMilitaryVoyage;
		protected CS2010.CommonWinCtrls.ucGridEx grdVesselPortCalls;
		private CS2010.AVSS.WinCtrls.ucPortCombo cmbPort;
		protected CS2010.CommonWinCtrls.ucButton btnClear;
		protected CS2010.CommonWinCtrls.ucTextBox txtVoyage;
		protected CS2010.CommonWinCtrls.ucDateTextBox txtToDt;
		protected CS2010.CommonWinCtrls.ucDateTextBox txtFromDt;
		protected CS2010.CommonWinCtrls.ucButton btnSearch;
		protected CS2010.AVSS.WinCtrls.ucVesselCombo comboVessel;
        private CommonWinCtrls.ucCheckBox chkARC;
    }
}