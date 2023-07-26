namespace CS2010.ArcSys.Win
{
	partial class frmIALPOVTracking
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
            Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIALPOVTracking));
            Janus.Windows.GridEX.GridEXLayout cmbPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.txtVessel = new CS2010.CommonWinCtrls.ucTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCargoStatus = new System.Windows.Forms.ComboBox();
            this.grpPOLDate = new CS2010.CommonWinCtrls.ucDateGroupBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.tbrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.sbrChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.toolStripSeparator1,
            this.tbbClear});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(846, 25);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "LINE Protocol Main Toolbar";
            // 
            // tbbSearch
            // 
            this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSearch.Name = "tbbSearch";
            this.tbbSearch.Size = new System.Drawing.Size(44, 22);
            this.tbbSearch.Text = "&Search";
            this.tbbSearch.Click += new System.EventHandler(this.tbbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbClear
            // 
            this.tbbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(66, 22);
            this.tbbClear.Text = "Clear Fields";
            this.tbbClear.Click += new System.EventHandler(this.tbbClear_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.cmbPLOD);
            this.pnlMain.Panel1.Controls.Add(this.cmbPLOR);
            this.pnlMain.Panel1.Controls.Add(this.cmbPOD);
            this.pnlMain.Panel1.Controls.Add(this.cmbPOL);
            this.pnlMain.Panel1.Controls.Add(this.btnClear);
            this.pnlMain.Panel1.Controls.Add(this.btnSearch);
            this.pnlMain.Panel1.Controls.Add(this.txtVessel);
            this.pnlMain.Panel1.Controls.Add(this.label1);
            this.pnlMain.Panel1.Controls.Add(this.cmbCargoStatus);
            this.pnlMain.Panel1.Controls.Add(this.grpPOLDate);
            this.pnlMain.Panel1.Controls.Add(this.txtVoyage);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.grdResults);
            this.pnlMain.Size = new System.Drawing.Size(846, 556);
            this.pnlMain.SplitterDistance = 131;
            this.pnlMain.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(568, 38);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(568, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtVessel
            // 
            this.txtVessel.LabelText = "Vessel Code";
            this.txtVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVessel.LinkDisabledMessage = "Link Disabled";
            this.txtVessel.Location = new System.Drawing.Point(240, 33);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.Size = new System.Drawing.Size(91, 20);
            this.txtVessel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cargo Status";
            // 
            // cmbCargoStatus
            // 
            this.cmbCargoStatus.FormattingEnabled = true;
            this.cmbCargoStatus.Items.AddRange(new object[] {
            "All",
            "RCVD"});
            this.cmbCargoStatus.Location = new System.Drawing.Point(240, 57);
            this.cmbCargoStatus.Name = "cmbCargoStatus";
            this.cmbCargoStatus.Size = new System.Drawing.Size(91, 21);
            this.cmbCargoStatus.TabIndex = 2;
            // 
            // grpPOLDate
            // 
            this.grpPOLDate.CheckBoxText = "Sail Date (yymmdd)";
            this.grpPOLDate.GroupBoxText = "POL Date (yymmdd)";
            this.grpPOLDate.Location = new System.Drawing.Point(35, 12);
            this.grpPOLDate.Name = "grpPOLDate";
            this.grpPOLDate.Size = new System.Drawing.Size(129, 76);
            this.grpPOLDate.TabIndex = 0;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(240, 10);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(91, 20);
            this.txtVoyage.TabIndex = 1;
            // 
            // grdResults
            // 
            this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
            this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.ExportFileID = null;
            this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdResults.Location = new System.Drawing.Point(0, 0);
            this.grdResults.Name = "grdResults";
            this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdResults.Size = new System.Drawing.Size(846, 421);
            this.grdResults.TabIndex = 0;
            this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 559);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(846, 22);
            this.sbrChild.TabIndex = 23;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(227, 17);
            this.sbbProgressCaption.Text = "Processing... (Click here to cancel the search)";
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // cmbPLOD
            // 
            this.cmbPLOD.CodeColumn = "Location_Cd";
            this.cmbPLOD.DescriptionColumn = "Location_Dsc";
            cmbPLOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOD_DesignTimeLayout.LayoutString");
            this.cmbPLOD.DesignTimeLayout = cmbPLOD_DesignTimeLayout;
            this.cmbPLOD.DisplayMember = "Location_Dsc";
            this.cmbPLOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPLOD.LabelText = "PLOD";
            this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOD.Location = new System.Drawing.Point(398, 78);
            this.cmbPLOD.Name = "cmbPLOD";
            this.cmbPLOD.SelectedIndex = -1;
            this.cmbPLOD.SelectedItem = null;
            this.cmbPLOD.Size = new System.Drawing.Size(157, 20);
            this.cmbPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOD.TabIndex = 14;
            this.cmbPLOD.ValueColumn = "Location_Cd";
            this.cmbPLOD.ValueMember = "Location_Cd";
            // 
            // cmbPLOR
            // 
            this.cmbPLOR.CodeColumn = "Location_Cd";
            this.cmbPLOR.DescriptionColumn = "Location_Dsc";
            cmbPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOR_DesignTimeLayout.LayoutString");
            this.cmbPLOR.DesignTimeLayout = cmbPLOR_DesignTimeLayout;
            this.cmbPLOR.DisplayMember = "Location_Dsc";
            this.cmbPLOR.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPLOR.LabelText = "PLOR";
            this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOR.Location = new System.Drawing.Point(398, 10);
            this.cmbPLOR.Name = "cmbPLOR";
            this.cmbPLOR.SelectedIndex = -1;
            this.cmbPLOR.SelectedItem = null;
            this.cmbPLOR.Size = new System.Drawing.Size(157, 20);
            this.cmbPLOR.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPLOR.TabIndex = 13;
            this.cmbPLOR.ValueColumn = "Location_Cd";
            this.cmbPLOR.ValueMember = "Location_Cd";
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
            this.cmbPOD.Location = new System.Drawing.Point(398, 55);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(157, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 12;
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
            this.cmbPOL.Location = new System.Drawing.Point(398, 32);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(157, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 11;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // frmIALPOVTracking
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 581);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tbrMain);
            this.KeyPreview = true;
            this.Name = "frmIALPOVTracking";
            this.Text = "IAL POV Tracking";
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel1.PerformLayout();
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbClear;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyage;
		private CS2010.CommonWinCtrls.ucGridEx grdResults;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpPOLDate;
		private System.Windows.Forms.ComboBox cmbCargoStatus;
		private System.Windows.Forms.Label label1;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucTextBox txtVessel;
		private CommonWinCtrls.ucButton btnClear;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private WinCtrls.ucLocationCombo cmbPOD;
		private WinCtrls.ucLocationCombo cmbPOL;
		private WinCtrls.ucLocationCombo cmbPLOD;
		private WinCtrls.ucLocationCombo cmbPLOR;
	}
}