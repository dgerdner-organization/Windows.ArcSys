namespace CS2010.ArcSys.Win
{
    partial class frmTranshipmentReport
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout grdTranshipment_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTranshipment_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbVessels_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranshipmentReport));
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbBOL = new System.Windows.Forms.RadioButton();
            this.rbBooking = new System.Windows.Forms.RadioButton();
            this.dtSailDates = new CS2010.CommonWinCtrls.ucDateGroupBox();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbCancelSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbMsg = new System.Windows.Forms.ToolStripLabel();
            this.grdTranshipment = new CS2010.CommonWinCtrls.ucGridEx();
            this.cmbVessels = new CS2010.ArcSys.WinCtrls.ucVesselCheckBoxCombo();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTranshipment)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(822, 127);
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance1;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance2;
            this.grpSearch.Location = new System.Drawing.Point(0, 25);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(822, 127);
            this.grpSearch.TabIndex = 24;
            this.grpSearch.Text = "Search Options";
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.cmbVessels);
            this.grpSearchPanel.Controls.Add(this.txtBooking);
            this.grpSearchPanel.Controls.Add(this.txtBOL);
            this.grpSearchPanel.Controls.Add(this.txtVoyage);
            this.grpSearchPanel.Controls.Add(this.groupBox1);
            this.grpSearchPanel.Controls.Add(this.dtSailDates);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(816, 103);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // txtBooking
            // 
            this.txtBooking.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBooking.LabelText = "Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(619, 19);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(100, 20);
            this.txtBooking.TabIndex = 6;
            // 
            // txtBOL
            // 
            this.txtBOL.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBOL.LabelText = "B/L #";
            this.txtBOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBOL.LinkDisabledMessage = "Link Disabled";
            this.txtBOL.Location = new System.Drawing.Point(619, 47);
            this.txtBOL.Name = "txtBOL";
            this.txtBOL.Size = new System.Drawing.Size(100, 20);
            this.txtBOL.TabIndex = 7;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(463, 19);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbBOL);
            this.groupBox1.Controls.Add(this.rbBooking);
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // rbBOL
            // 
            this.rbBOL.AutoSize = true;
            this.rbBOL.Location = new System.Drawing.Point(40, 48);
            this.rbBOL.Name = "rbBOL";
            this.rbBOL.Size = new System.Drawing.Size(85, 17);
            this.rbBOL.TabIndex = 2;
            this.rbBOL.Text = "Bill of Lading";
            this.rbBOL.UseVisualStyleBackColor = true;
            this.rbBOL.CheckedChanged += new System.EventHandler(this.rbBOL_CheckedChanged);
            // 
            // rbBooking
            // 
            this.rbBooking.AutoSize = true;
            this.rbBooking.Location = new System.Drawing.Point(40, 22);
            this.rbBooking.Name = "rbBooking";
            this.rbBooking.Size = new System.Drawing.Size(64, 17);
            this.rbBooking.TabIndex = 1;
            this.rbBooking.Text = "Booking";
            this.rbBooking.UseVisualStyleBackColor = true;
            this.rbBooking.CheckedChanged += new System.EventHandler(this.rbBooking_CheckedChanged);
            // 
            // dtSailDates
            // 
            this.dtSailDates.BackColor = System.Drawing.Color.Transparent;
            this.dtSailDates.CheckBoxText = "Sail Dates (YYMMDD)";
            this.dtSailDates.Location = new System.Drawing.Point(204, 3);
            this.dtSailDates.Name = "dtSailDates";
            this.dtSailDates.Size = new System.Drawing.Size(189, 77);
            this.dtSailDates.TabIndex = 3;
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsProgress,
            this.tsbCancelSearch,
            this.tsbClear,
            this.tsbMsg});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(822, 25);
            this.ts.TabIndex = 23;
            this.ts.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(44, 22);
            this.tsbSearch.Text = "&Search";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsProgress
            // 
            this.tsProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(100, 22);
            this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tsbCancelSearch
            // 
            this.tsbCancelSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancelSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancelSearch.ForeColor = System.Drawing.Color.Black;
            this.tsbCancelSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelSearch.Image")));
            this.tsbCancelSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelSearch.Name = "tsbCancelSearch";
            this.tsbCancelSearch.Size = new System.Drawing.Size(149, 22);
            this.tsbCancelSearch.Text = "[&Click here to Cancel Search]";
            this.tsbCancelSearch.Click += new System.EventHandler(this.tsbCancelSearch_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(36, 22);
            this.tsbClear.Text = "&Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbMsg
            // 
            this.tsbMsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbMsg.Name = "tsbMsg";
            this.tsbMsg.Size = new System.Drawing.Size(0, 22);
            // 
            // grdTranshipment
            // 
            this.grdTranshipment.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdTranshipment.AlternatingColors = true;
            this.grdTranshipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTranshipment.ExportFileID = null;
            this.grdTranshipment.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdTranshipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            grdTranshipment_Layout_0.IsCurrentLayout = true;
            grdTranshipment_Layout_0.Key = "layoutBooking";
            grdTranshipment_Layout_0.LayoutString = resources.GetString("grdTranshipment_Layout_0.LayoutString");
            grdTranshipment_Layout_0.Tag = "layoutBooking";
            grdTranshipment_Layout_1.Key = "layoutBol";
            grdTranshipment_Layout_1.LayoutString = resources.GetString("grdTranshipment_Layout_1.LayoutString");
            grdTranshipment_Layout_1.Tag = "layoutBol";
            this.grdTranshipment.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grdTranshipment_Layout_0,
            grdTranshipment_Layout_1});
            this.grdTranshipment.Location = new System.Drawing.Point(0, 152);
            this.grdTranshipment.Name = "grdTranshipment";
            this.grdTranshipment.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdTranshipment.Size = new System.Drawing.Size(822, 471);
            this.grdTranshipment.TabIndex = 27;
            this.grdTranshipment.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // cmbVessels
            // 
            this.cmbVessels.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbVessels.CodeColumn = "Vessel_Cd";
            this.cmbVessels.DescriptionColumn = "Vessel_Nm";
            cmbVessels_DesignTimeLayout.LayoutString = resources.GetString("cmbVessels_DesignTimeLayout.LayoutString");
            this.cmbVessels.DesignTimeLayout = cmbVessels_DesignTimeLayout;
            this.cmbVessels.DropDownButtonsVisible = false;
            this.cmbVessels.DropDownDisplayMember = "Vessel_Cd";
            this.cmbVessels.DropDownValueMember = "Vessel_Cd";
            this.cmbVessels.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbVessels.LabelText = "Vessels";
            this.cmbVessels.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVessels.Location = new System.Drawing.Point(463, 48);
            this.cmbVessels.Name = "cmbVessels";
            this.cmbVessels.SaveSettings = false;
            this.cmbVessels.Size = new System.Drawing.Size(100, 20);
            this.cmbVessels.TabIndex = 5;
            this.cmbVessels.ValueColumn = "Vessel_Cd";
            // 
            // frmTranshipmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 623);
            this.Controls.Add(this.grdTranshipment);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.ts);
            this.Name = "frmTranshipmentReport";
            this.Text = "Transhipment Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTranshipmentReport_FormClosing);
            this.Load += new System.EventHandler(this.frmTranshipmentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTranshipment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
        private CommonWinCtrls.ucTextBox txtBOL;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbBOL;
        private System.Windows.Forms.RadioButton rbBooking;
        private CommonWinCtrls.ucDateGroupBox dtSailDates;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton tsbCancelSearch;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripLabel tsbMsg;
        private CommonWinCtrls.ucTextBox txtBooking;
        private CommonWinCtrls.ucGridEx grdTranshipment;
        private WinCtrls.ucVesselCheckBoxCombo cmbVessels;
    }
}