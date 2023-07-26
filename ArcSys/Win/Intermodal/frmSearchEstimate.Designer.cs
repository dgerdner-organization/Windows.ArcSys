namespace CS2010.ArcSys.Win
{
	partial class frmSearchEstimate
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
            Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchEstimate));
            Janus.Windows.GridEX.GridEXLayout grdChargesByEstimate_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdAllCharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.lblParams = new System.Windows.Forms.Label();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
            this.tbbSearch = new System.Windows.Forms.ToolStripButton();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.tbbOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tabSearchEstimateMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpgEstimate = new System.Windows.Forms.TabPage();
            this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpgCharges = new System.Windows.Forms.TabPage();
            this.grdChargesByEstimate = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpgChargeDetail = new System.Windows.Forms.TabPage();
            this.grdAllCharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.pnlTop.SuspendLayout();
            this.sbrChild.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.tabSearchEstimateMain.SuspendLayout();
            this.tpgEstimate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.tpgCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChargesByEstimate)).BeginInit();
            this.tpgChargeDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // lblParams
            // 
            this.lblParams.AutoSize = true;
            this.lblParams.Location = new System.Drawing.Point(4, 4);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(79, 13);
            this.lblParams.TabIndex = 0;
            this.lblParams.Text = "Search Params";
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblParams);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 25);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(782, 23);
            this.pnlTop.TabIndex = 5;
            this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
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
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 474);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(782, 22);
            this.sbrChild.TabIndex = 4;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // tbbOptions
            // 
            this.tbbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbOptions.Name = "tbbOptions";
            this.tbbOptions.Size = new System.Drawing.Size(57, 22);
            this.tbbOptions.Text = "&Options";
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.tbbOptions});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(782, 25);
            this.tbrMain.TabIndex = 3;
            this.tbrMain.Text = "Search Available Main Toolbar";
            // 
            // tabSearchEstimateMain
            // 
            this.tabSearchEstimateMain.Controls.Add(this.tpgEstimate);
            this.tabSearchEstimateMain.Controls.Add(this.tpgCharges);
            this.tabSearchEstimateMain.Controls.Add(this.tpgChargeDetail);
            this.tabSearchEstimateMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSearchEstimateMain.Location = new System.Drawing.Point(0, 48);
            this.tabSearchEstimateMain.Name = "tabSearchEstimateMain";
            this.tabSearchEstimateMain.SelectedIndex = 0;
            this.tabSearchEstimateMain.Size = new System.Drawing.Size(782, 448);
            this.tabSearchEstimateMain.TabIndex = 7;
            // 
            // tpgEstimate
            // 
            this.tpgEstimate.Controls.Add(this.grdResults);
            this.tpgEstimate.Location = new System.Drawing.Point(4, 22);
            this.tpgEstimate.Name = "tpgEstimate";
            this.tpgEstimate.Padding = new System.Windows.Forms.Padding(3);
            this.tpgEstimate.Size = new System.Drawing.Size(774, 422);
            this.tpgEstimate.TabIndex = 0;
            this.tpgEstimate.Text = "Estimate Information";
            this.tpgEstimate.UseVisualStyleBackColor = true;
            // 
            // grdResults
            // 
            this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
            this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
            this.grdResults.DisplayFieldChooser = true;
            this.grdResults.DisplayFieldChooserChildren = true;
            this.grdResults.DisplayFontSelector = true;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.ExportFileID = null;
            this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdResults.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdResults.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdResults.Hierarchical = true;
            this.grdResults.Location = new System.Drawing.Point(3, 3);
            this.grdResults.Name = "grdResults";
            this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdResults.Size = new System.Drawing.Size(768, 416);
            this.grdResults.TabIndex = 6;
            this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
            this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
            this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
            // 
            // tpgCharges
            // 
            this.tpgCharges.Controls.Add(this.grdChargesByEstimate);
            this.tpgCharges.Location = new System.Drawing.Point(4, 22);
            this.tpgCharges.Name = "tpgCharges";
            this.tpgCharges.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCharges.Size = new System.Drawing.Size(774, 422);
            this.tpgCharges.TabIndex = 1;
            this.tpgCharges.Text = "Charges by Estimate";
            this.tpgCharges.UseVisualStyleBackColor = true;
            // 
            // grdChargesByEstimate
            // 
            this.grdChargesByEstimate.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdChargesByEstimate.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdChargesByEstimate_DesignTimeLayout.LayoutString = resources.GetString("grdChargesByEstimate_DesignTimeLayout.LayoutString");
            this.grdChargesByEstimate.DesignTimeLayout = grdChargesByEstimate_DesignTimeLayout;
            this.grdChargesByEstimate.DisplayFieldChooser = true;
            this.grdChargesByEstimate.DisplayFieldChooserChildren = true;
            this.grdChargesByEstimate.DisplayFontSelector = true;
            this.grdChargesByEstimate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChargesByEstimate.ExportFileID = null;
            this.grdChargesByEstimate.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdChargesByEstimate.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdChargesByEstimate.FilterRowFormatStyle.BackColor = System.Drawing.Color.PowderBlue;
            this.grdChargesByEstimate.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.AliceBlue;
            this.grdChargesByEstimate.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdChargesByEstimate.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdChargesByEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdChargesByEstimate.Hierarchical = true;
            this.grdChargesByEstimate.Location = new System.Drawing.Point(3, 3);
            this.grdChargesByEstimate.Name = "grdChargesByEstimate";
            this.grdChargesByEstimate.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdChargesByEstimate.Size = new System.Drawing.Size(768, 416);
            this.grdChargesByEstimate.TabIndex = 7;
            this.grdChargesByEstimate.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdChargesByEstimate.DoubleClick += new System.EventHandler(this.grdChargesByEstimate_DoubleClick);
            this.grdChargesByEstimate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdChargesByEstimate_KeyDown);
            // 
            // tpgChargeDetail
            // 
            this.tpgChargeDetail.Controls.Add(this.grdAllCharges);
            this.tpgChargeDetail.Location = new System.Drawing.Point(4, 22);
            this.tpgChargeDetail.Name = "tpgChargeDetail";
            this.tpgChargeDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tpgChargeDetail.Size = new System.Drawing.Size(774, 422);
            this.tpgChargeDetail.TabIndex = 2;
            this.tpgChargeDetail.Text = "All Charges";
            this.tpgChargeDetail.UseVisualStyleBackColor = true;
            // 
            // grdAllCharges
            // 
            this.grdAllCharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAllCharges.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdAllCharges_DesignTimeLayout.LayoutString = resources.GetString("grdAllCharges_DesignTimeLayout.LayoutString");
            this.grdAllCharges.DesignTimeLayout = grdAllCharges_DesignTimeLayout;
            this.grdAllCharges.DisplayFieldChooser = true;
            this.grdAllCharges.DisplayFieldChooserChildren = true;
            this.grdAllCharges.DisplayFontSelector = true;
            this.grdAllCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAllCharges.ExportFileID = null;
            this.grdAllCharges.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAllCharges.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdAllCharges.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdAllCharges.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdAllCharges.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Diagonal;
            this.grdAllCharges.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdAllCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdAllCharges.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdAllCharges.Location = new System.Drawing.Point(3, 3);
            this.grdAllCharges.Name = "grdAllCharges";
            this.grdAllCharges.NewRowEnterKeyBehavior = Janus.Windows.GridEX.NewRowEnterKeyBehavior.AddRowAndMoveToAddedRow;
            this.grdAllCharges.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAllCharges.Size = new System.Drawing.Size(768, 416);
            this.grdAllCharges.TabIndex = 2;
            this.grdAllCharges.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdAllCharges.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAllCharges.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdAllCharges.DoubleClick += new System.EventHandler(this.grdAllCharges_DoubleClick);
            // 
            // frmSearchEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.tabSearchEstimateMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Name = "frmSearchEstimate";
            this.Text = "Search Existing Estimates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchEstimate_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchEstimate_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.tabSearchEstimateMain.ResumeLayout(false);
            this.tpgEstimate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.tpgCharges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChargesByEstimate)).EndInit();
            this.tpgChargeDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.Label lblParams;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private CommonWinCtrls.ucPanel pnlTop;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripDropDownButton tbbOptions;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTabControl tabSearchEstimateMain;
		private System.Windows.Forms.TabPage tpgEstimate;
		private System.Windows.Forms.TabPage tpgCharges;
		private CommonWinCtrls.ucGridEx grdChargesByEstimate;
		private System.Windows.Forms.TabPage tpgChargeDetail;
		private CommonWinCtrls.ucGridEx grdAllCharges;
		private CommonWinCtrls.ucGridEx grdResults;
	}
}