namespace CS2010.ArcSys.Win
{
    partial class frmNHTSARecall
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
            Janus.Windows.GridEX.GridEXLayout grdData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNHTSARecall));
            Janus.Windows.GridEX.GridEXLayout grdNotes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbRisk_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPol_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tssCancel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.grdData = new CS2010.CommonWinCtrls.ucGridEx();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.grdNotes = new CS2010.CommonWinCtrls.ucGridEx();
            this.ultraSplitter2 = new Infragistics.Win.Misc.UltraSplitter();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtVin = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbStatus = new CS2010.ArcSys.WinCtrls.ucRecallStatusCombo();
            this.cmbRisk = new CS2010.ArcSys.WinCtrls.ucRecallRiskCombo();
            this.gbSailDates = new System.Windows.Forms.GroupBox();
            this.dtSailTo = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.dtSailFrom = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbVessel = new CS2010.AVSS.WinCtrls.ucVesselCombo();
            this.cmbPol = new CS2010.AVSS.WinCtrls.ucPortCombo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHtmlEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ss.SuspendLayout();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotes)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRisk)).BeginInit();
            this.gbSailDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPol)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssCancel,
            this.tsProgress,
            this.tssStatus,
            this.tssStatusLabel});
            this.ss.Location = new System.Drawing.Point(0, 727);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(1080, 22);
            this.ss.TabIndex = 2;
            this.ss.Text = "statusStrip1";
            // 
            // tssCancel
            // 
            this.tssCancel.Name = "tssCancel";
            this.tssCancel.Size = new System.Drawing.Size(109, 17);
            this.tssCancel.Text = "[Click here to Cancel]";
            this.tssCancel.Click += new System.EventHandler(this.tssCancel_Click);
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(100, 16);
            this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tssStatusLabel
            // 
            this.tssStatusLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tssStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tssStatusLabel.Name = "tssStatusLabel";
            this.tssStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tssStatusLabel.Size = new System.Drawing.Size(854, 17);
            this.tssStatusLabel.Spring = true;
            this.tssStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ultraPanel2
            // 
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraPanel1);
            this.ultraPanel2.ClientArea.Controls.Add(this.ultraSplitter2);
            this.ultraPanel2.ClientArea.Controls.Add(this.pnlSearch);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(1080, 727);
            this.ultraPanel2.TabIndex = 8;
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.grdData);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraSplitter1);
            this.ultraPanel1.ClientArea.Controls.Add(this.grdNotes);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(288, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(792, 727);
            this.ultraPanel1.TabIndex = 8;
            // 
            // grdData
            // 
            grdData_DesignTimeLayout.LayoutString = resources.GetString("grdData_DesignTimeLayout.LayoutString");
            this.grdData.DesignTimeLayout = grdData_DesignTimeLayout;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.ExportFileID = null;
            this.grdData.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.Name = "grdData";
            this.grdData.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdData.Size = new System.Drawing.Size(423, 727);
            this.grdData.TabIndex = 15;
            this.grdData.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.grdData.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdData_RowDoubleClick);
            this.grdData.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdData_ColumnButtonClick);
            this.grdData.DropDownHide += new Janus.Windows.GridEX.DropDownHideEventHandler(this.grdData_DropDownHide);
            this.grdData.SelectionChanged += new System.EventHandler(this.grdData_SelectionChanged);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.SystemColors.Control;
            this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraSplitter1.Location = new System.Drawing.Point(423, 0);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 354;
            this.ultraSplitter1.Size = new System.Drawing.Size(15, 727);
            this.ultraSplitter1.TabIndex = 14;
            // 
            // grdNotes
            // 
            grdNotes_DesignTimeLayout.LayoutString = resources.GetString("grdNotes_DesignTimeLayout.LayoutString");
            this.grdNotes.DesignTimeLayout = grdNotes_DesignTimeLayout;
            this.grdNotes.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdNotes.ExportFileID = null;
            this.grdNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdNotes.GroupByBoxVisible = false;
            this.grdNotes.Location = new System.Drawing.Point(438, 0);
            this.grdNotes.Name = "grdNotes";
            this.grdNotes.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdNotes.Size = new System.Drawing.Size(354, 727);
            this.grdNotes.TabIndex = 13;
            // 
            // ultraSplitter2
            // 
            this.ultraSplitter2.Location = new System.Drawing.Point(273, 0);
            this.ultraSplitter2.Name = "ultraSplitter2";
            this.ultraSplitter2.RestoreExtent = 273;
            this.ultraSplitter2.Size = new System.Drawing.Size(15, 727);
            this.ultraSplitter2.TabIndex = 2;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.groupBox1);
            this.pnlSearch.Controls.Add(this.txtVin);
            this.pnlSearch.Controls.Add(this.btnClear);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cmbStatus);
            this.pnlSearch.Controls.Add(this.cmbRisk);
            this.pnlSearch.Controls.Add(this.gbSailDates);
            this.pnlSearch.Controls.Add(this.txtVoyage);
            this.pnlSearch.Controls.Add(this.cmbVessel);
            this.pnlSearch.Controls.Add(this.cmbPol);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(273, 727);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtVin
            // 
            this.txtVin.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtVin.LabelText = "Vin";
            this.txtVin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVin.LinkDisabledMessage = "Link Disabled";
            this.txtVin.Location = new System.Drawing.Point(12, 275);
            this.txtVin.Name = "txtVin";
            this.txtVin.Size = new System.Drawing.Size(252, 20);
            this.txtVin.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(189, 462);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(189, 491);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.CodeColumn = "Recall_Status_Cd";
            this.cmbStatus.DescriptionColumn = "Recall_Status_Dsc";
            cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
            this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
            this.cmbStatus.DisplayMember = "Recall_Status_Dsc";
            this.cmbStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbStatus.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.cmbStatus.LabelText = "Status";
            this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatus.Location = new System.Drawing.Point(12, 225);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.SelectedIndex = -1;
            this.cmbStatus.SelectedItem = null;
            this.cmbStatus.Size = new System.Drawing.Size(252, 20);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.ValueColumn = "Recall_Status_Cd";
            this.cmbStatus.ValueMember = "Recall_Status_Cd";
            // 
            // cmbRisk
            // 
            this.cmbRisk.CodeColumn = "Recall_Risk_Cd";
            this.cmbRisk.DescriptionColumn = "Recall_Risk_Dsc";
            cmbRisk_DesignTimeLayout.LayoutString = resources.GetString("cmbRisk_DesignTimeLayout.LayoutString");
            this.cmbRisk.DesignTimeLayout = cmbRisk_DesignTimeLayout;
            this.cmbRisk.DisplayMember = "Recall_Risk_Dsc";
            this.cmbRisk.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbRisk.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.cmbRisk.LabelText = "Recall Level";
            this.cmbRisk.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbRisk.Location = new System.Drawing.Point(12, 175);
            this.cmbRisk.Name = "cmbRisk";
            this.cmbRisk.SelectedIndex = -1;
            this.cmbRisk.SelectedItem = null;
            this.cmbRisk.Size = new System.Drawing.Size(252, 20);
            this.cmbRisk.TabIndex = 4;
            this.cmbRisk.ValueColumn = "Recall_Risk_Cd";
            this.cmbRisk.ValueMember = "Recall_Risk_Cd";
            // 
            // gbSailDates
            // 
            this.gbSailDates.Controls.Add(this.dtSailTo);
            this.gbSailDates.Controls.Add(this.dtSailFrom);
            this.gbSailDates.Location = new System.Drawing.Point(3, 325);
            this.gbSailDates.Name = "gbSailDates";
            this.gbSailDates.Size = new System.Drawing.Size(267, 131);
            this.gbSailDates.TabIndex = 7;
            this.gbSailDates.TabStop = false;
            this.gbSailDates.Text = "Load Dates";
            // 
            // dtSailTo
            // 
            this.dtSailTo.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.dtSailTo.LabelText = "To";
            this.dtSailTo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.dtSailTo.LinkDisabledMessage = "Link Disabled";
            this.dtSailTo.Location = new System.Drawing.Point(9, 85);
            this.dtSailTo.MaxLength = 10;
            this.dtSailTo.Name = "dtSailTo";
            this.dtSailTo.Size = new System.Drawing.Size(252, 20);
            this.dtSailTo.TabIndex = 8;
            this.dtSailTo.Value = null;
            // 
            // dtSailFrom
            // 
            this.dtSailFrom.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.dtSailFrom.LabelText = "From";
            this.dtSailFrom.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.dtSailFrom.LinkDisabledMessage = "Link Disabled";
            this.dtSailFrom.Location = new System.Drawing.Point(9, 35);
            this.dtSailFrom.MaxLength = 10;
            this.dtSailFrom.Name = "dtSailFrom";
            this.dtSailFrom.Size = new System.Drawing.Size(252, 20);
            this.dtSailFrom.TabIndex = 7;
            this.dtSailFrom.Value = null;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(12, 75);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(252, 20);
            this.txtVoyage.TabIndex = 2;
            // 
            // cmbVessel
            // 
            this.cmbVessel.CodeColumn = "VESSEL_CD";
            this.cmbVessel.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.cmbVessel.DescriptionColumn = "VESSEL_NM";
            cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
            this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
            this.cmbVessel.DisplayMember = "VESSEL_CDVESSEL_NM";
            this.cmbVessel.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbVessel.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.cmbVessel.LabelText = "Vessel:";
            this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVessel.Location = new System.Drawing.Point(12, 25);
            this.cmbVessel.Name = "cmbVessel";
            this.cmbVessel.SelectedCdNm = null;
            this.cmbVessel.SelectedIndex = -1;
            this.cmbVessel.SelectedItem = null;
            this.cmbVessel.ShowOnlyARCVessels = true;
            this.cmbVessel.Size = new System.Drawing.Size(252, 20);
            this.cmbVessel.TabIndex = 1;
            this.cmbVessel.ValueColumn = "VESSEL_CD";
            this.cmbVessel.ValueMember = "VESSEL_CD";
            // 
            // cmbPol
            // 
            this.cmbPol.CodeColumn = "PORT_CD";
            this.cmbPol.DescriptionColumn = "PORT_NM";
            cmbPol_DesignTimeLayout.LayoutString = resources.GetString("cmbPol_DesignTimeLayout.LayoutString");
            this.cmbPol.DesignTimeLayout = cmbPol_DesignTimeLayout;
            this.cmbPol.DisplayMember = "PORT_NM";
            this.cmbPol.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPol.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.cmbPol.LabelText = "Port of Load";
            this.cmbPol.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPol.Location = new System.Drawing.Point(12, 125);
            this.cmbPol.Name = "cmbPol";
            this.cmbPol.SelectedIndex = -1;
            this.cmbPol.SelectedItem = null;
            this.cmbPol.Size = new System.Drawing.Size(252, 20);
            this.cmbPol.TabIndex = 3;
            this.cmbPol.ValueColumn = "PORT_CD";
            this.cmbPol.ValueMember = "PORT_CD";
            this.cmbPol.WithBerths = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnHtmlEmail);
            this.groupBox1.Location = new System.Drawing.Point(13, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 109);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnHtmlEmail
            // 
            this.btnHtmlEmail.Location = new System.Drawing.Point(87, 78);
            this.btnHtmlEmail.Name = "btnHtmlEmail";
            this.btnHtmlEmail.Size = new System.Drawing.Size(158, 23);
            this.btnHtmlEmail.TabIndex = 12;
            this.btnHtmlEmail.Text = "&Battery Disconnect Report";
            this.btnHtmlEmail.UseVisualStyleBackColor = true;
            this.btnHtmlEmail.Click += new System.EventHandler(this.btnHtmlEmail_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 47);
            this.label1.TabIndex = 14;
            this.label1.Text = "Please search with (at least) VOYAGE, POL and STATUS (ACB) to view the Battery Di" +
                "sconnect Report.";
            // 
            // frmNHTSARecall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 749);
            this.Controls.Add(this.ultraPanel2);
            this.Controls.Add(this.ss);
            this.Name = "frmNHTSARecall";
            this.Text = "NHTSA Recall";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNHTSARecall_FormClosing);
            this.Load += new System.EventHandler(this.frmNHTSARecall_Load);
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotes)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRisk)).EndInit();
            this.gbSailDates.ResumeLayout(false);
            this.gbSailDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVessel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPol)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tssCancel;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private CommonWinCtrls.ucGridEx grdData;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
        private CommonWinCtrls.ucGridEx grdNotes;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter2;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private WinCtrls.ucRecallStatusCombo cmbStatus;
        private WinCtrls.ucRecallRiskCombo cmbRisk;
        private System.Windows.Forms.GroupBox gbSailDates;
        private CommonWinCtrls.ucDateTextBox dtSailTo;
        private CommonWinCtrls.ucDateTextBox dtSailFrom;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private AVSS.WinCtrls.ucVesselCombo cmbVessel;
        private AVSS.WinCtrls.ucPortCombo cmbPol;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssStatusLabel;
        private CommonWinCtrls.ucTextBox txtVin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHtmlEmail;
        private System.Windows.Forms.Label label1;
    }
}