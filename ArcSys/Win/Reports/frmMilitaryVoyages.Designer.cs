namespace CS2010.ArcSys.Win
{
    partial class frmMilitaryVoyages
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMilitaryVoyages));
			this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.dtSailDates = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.cmbPort = new CS2010.CommonWinCtrls.ucComboBox();
			this.cmbVessel = new CS2010.CommonWinCtrls.ucComboBox();
			this.grdData = new CS2010.CommonWinCtrls.ucGridEx();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tsbCancelSearch = new System.Windows.Forms.ToolStripButton();
			this.tsbClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbPrint = new System.Windows.Forms.ToolStripButton();
			this.tsbMsg = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
			this.ultraExpandableGroupBox1.SuspendLayout();
			this.ultraExpandableGroupBoxPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// ultraExpandableGroupBox1
			// 
			this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
			this.ultraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(787, 119);
			this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(0, 0);
			this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
			this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(787, 119);
			this.ultraExpandableGroupBox1.TabIndex = 0;
			this.ultraExpandableGroupBox1.Text = "Search Options";
			this.ultraExpandableGroupBox1.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
			this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
			// 
			// ultraExpandableGroupBoxPanel1
			// 
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.dtSailDates);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbPort);
			this.ultraExpandableGroupBoxPanel1.Controls.Add(this.cmbVessel);
			this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 20);
			this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
			this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(781, 96);
			this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
			// 
			// dtSailDates
			// 
			this.dtSailDates.BackColor = System.Drawing.Color.Transparent;
			this.dtSailDates.CheckBoxText = "Sail Dates (YYMMDD)";
			this.dtSailDates.Location = new System.Drawing.Point(297, 3);
			this.dtSailDates.Name = "dtSailDates";
			this.dtSailDates.Size = new System.Drawing.Size(189, 81);
			this.dtSailDates.TabIndex = 5;
			// 
			// cmbPort
			// 
			this.cmbPort.FormattingEnabled = true;
			this.cmbPort.LabelText = "Port";
			this.cmbPort.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPort.Location = new System.Drawing.Point(52, 41);
			this.cmbPort.Name = "cmbPort";
			this.cmbPort.Size = new System.Drawing.Size(171, 21);
			this.cmbPort.TabIndex = 2;
			// 
			// cmbVessel
			// 
			this.cmbVessel.FormattingEnabled = true;
			this.cmbVessel.LabelText = "Vessel";
			this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVessel.Location = new System.Drawing.Point(52, 14);
			this.cmbVessel.Name = "cmbVessel";
			this.cmbVessel.Size = new System.Drawing.Size(171, 21);
			this.cmbVessel.TabIndex = 0;
			// 
			// grdData
			// 
			this.grdData.AlternatingColors = true;
			grdData_DesignTimeLayout.LayoutString = resources.GetString("grdData_DesignTimeLayout.LayoutString");
			this.grdData.DesignTimeLayout = grdData_DesignTimeLayout;
			this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdData.ExportFileID = null;
			this.grdData.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdData.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdData.Hierarchical = true;
			this.grdData.Location = new System.Drawing.Point(0, 119);
			this.grdData.Name = "grdData";
			this.grdData.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdData.Size = new System.Drawing.Size(787, 386);
			this.grdData.TabIndex = 1;
			this.grdData.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			// 
			// ts
			// 
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsProgress,
            this.tsbCancelSearch,
            this.tsbClear,
            this.toolStripSeparator2,
            this.tsbPrint,
            this.tsbMsg,
            this.toolStripSeparator3});
			this.ts.Location = new System.Drawing.Point(0, 119);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(787, 25);
			this.ts.TabIndex = 24;
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
			this.tsProgress.Visible = false;
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
			this.tsbCancelSearch.Visible = false;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbPrint
			// 
			this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
			this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPrint.Name = "tsbPrint";
			this.tsbPrint.Size = new System.Drawing.Size(43, 22);
			this.tsbPrint.Text = "&Export";
			this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
			// 
			// tsbMsg
			// 
			this.tsbMsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbMsg.Name = "tsbMsg";
			this.tsbMsg.Size = new System.Drawing.Size(0, 22);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// frmMilitaryVoyages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 505);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.grdData);
			this.Controls.Add(this.ultraExpandableGroupBox1);
			this.Name = "frmMilitaryVoyages";
			this.Text = "Military Voyages";
			((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
			this.ultraExpandableGroupBox1.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
			this.ultraExpandableGroupBoxPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private CommonWinCtrls.ucGridEx grdData;
        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton tsbCancelSearch;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripLabel tsbMsg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private CommonWinCtrls.ucComboBox cmbPort;
        private CommonWinCtrls.ucComboBox cmbVessel;
        private CommonWinCtrls.ucDateGroupBox dtSailDates;

    }
}