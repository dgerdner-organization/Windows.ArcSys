namespace CS2010.ArcSys.Win
{
	partial class frmCreateEstimate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateEstimate));
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.tbbOptions = new System.Windows.Forms.ToolStripDropDownButton();
			this.cnuOptionsCreateEstimate = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsViewEstimate = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuOptionsDeleteCargo = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsBillPayFlags = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsNonBillable = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsNonPayable = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuOptionsNonBillPay = new System.Windows.Forms.ToolStripMenuItem();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
			this.lblParams = new System.Windows.Forms.Label();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain.SuspendLayout();
			this.sbrChild.SuspendLayout();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.tbbOptions});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1006, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "Search Available Main Toolbar";
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
			// tbbOptions
			// 
			this.tbbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsCreateEstimate,
            this.cnuOptionsViewEstimate,
            this.cnuOptionsN1,
            this.cnuOptionsDeleteCargo,
            this.cnuOptionsBillPayFlags});
			this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbOptions.Name = "tbbOptions";
			this.tbbOptions.Size = new System.Drawing.Size(57, 22);
			this.tbbOptions.Text = "&Options";
			this.tbbOptions.DropDownOpening += new System.EventHandler(this.tbbOptions_DropDownOpening);
			// 
			// cnuOptionsCreateEstimate
			// 
			this.cnuOptionsCreateEstimate.Name = "cnuOptionsCreateEstimate";
			this.cnuOptionsCreateEstimate.Size = new System.Drawing.Size(187, 22);
			this.cnuOptionsCreateEstimate.Text = "Create Estimate...";
			this.cnuOptionsCreateEstimate.Click += new System.EventHandler(this.cnuOptionsCreateEstimate_Click);
			// 
			// cnuOptionsViewEstimate
			// 
			this.cnuOptionsViewEstimate.Enabled = false;
			this.cnuOptionsViewEstimate.Name = "cnuOptionsViewEstimate";
			this.cnuOptionsViewEstimate.Size = new System.Drawing.Size(187, 22);
			this.cnuOptionsViewEstimate.Text = "View Estimate";
			this.cnuOptionsViewEstimate.Click += new System.EventHandler(this.cnuOptionsViewEstimate_Click);
			// 
			// cnuOptionsN1
			// 
			this.cnuOptionsN1.Name = "cnuOptionsN1";
			this.cnuOptionsN1.Size = new System.Drawing.Size(184, 6);
			// 
			// cnuOptionsDeleteCargo
			// 
			this.cnuOptionsDeleteCargo.Name = "cnuOptionsDeleteCargo";
			this.cnuOptionsDeleteCargo.Size = new System.Drawing.Size(187, 22);
			this.cnuOptionsDeleteCargo.Text = "Delete Cargo";
			this.cnuOptionsDeleteCargo.Click += new System.EventHandler(this.cnuOptionsDeleteCargo_Click);
			// 
			// cnuOptionsBillPayFlags
			// 
			this.cnuOptionsBillPayFlags.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsNonBillable,
            this.cnuOptionsNonPayable,
            this.cnuOptionsNonBillPay});
			this.cnuOptionsBillPayFlags.Name = "cnuOptionsBillPayFlags";
			this.cnuOptionsBillPayFlags.Size = new System.Drawing.Size(187, 22);
			this.cnuOptionsBillPayFlags.Text = "Billable/Payable Flags";
			// 
			// cnuOptionsNonBillable
			// 
			this.cnuOptionsNonBillable.Name = "cnuOptionsNonBillable";
			this.cnuOptionsNonBillable.Size = new System.Drawing.Size(250, 22);
			this.cnuOptionsNonBillable.Text = "Non-Billable";
			this.cnuOptionsNonBillable.Click += new System.EventHandler(this.cnuOptionsNonBillable_Click);
			// 
			// cnuOptionsNonPayable
			// 
			this.cnuOptionsNonPayable.Name = "cnuOptionsNonPayable";
			this.cnuOptionsNonPayable.Size = new System.Drawing.Size(250, 22);
			this.cnuOptionsNonPayable.Text = "Non-Payable";
			this.cnuOptionsNonPayable.Click += new System.EventHandler(this.cnuOptionsNonPayable_Click);
			// 
			// cnuOptionsNonBillPay
			// 
			this.cnuOptionsNonBillPay.Name = "cnuOptionsNonBillPay";
			this.cnuOptionsNonBillPay.Size = new System.Drawing.Size(250, 22);
			this.cnuOptionsNonBillPay.Text = "Both Non-Billable and Non-Payable";
			this.cnuOptionsNonBillPay.Click += new System.EventHandler(this.cnuOptionsNonBillPay_Click);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 474);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(782, 22);
			this.sbrChild.TabIndex = 1;
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
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.lblParams);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 25);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1006, 23);
			this.pnlTop.TabIndex = 1;
			this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
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
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdResults.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
			grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
			this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
			this.grdResults.DisplayFieldChooser = true;
			this.grdResults.DisplayFieldChooserChildren = true;
			this.grdResults.DisplayFontSelector = true;
			this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResults.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this.grdResults.ExportFileID = "Available";
			this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdResults.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdResults.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdResults.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdResults.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdResults.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdResults.Hierarchical = true;
			this.grdResults.Location = new System.Drawing.Point(0, 48);
			this.grdResults.Name = "grdResults";
			this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdResults.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdResults.Size = new System.Drawing.Size(1006, 676);
			this.grdResults.TabIndex = 2;
			this.grdResults.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdResults.UseGroupRowSelector = true;
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
			// 
			// frmCreateEstimate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 724);
			this.Controls.Add(this.grdResults);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmCreateEstimate";
			this.Text = "Create Estimates";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCreateEstimate_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCreateEstimate_FormClosed);
			this.Load += new System.EventHandler(this.frmCreateEstimate_Load);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private CommonWinCtrls.ucPanel pnlTop;
		private System.Windows.Forms.Label lblParams;
		private CommonWinCtrls.ucGridEx grdResults;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripDropDownButton tbbOptions;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsCreateEstimate;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsViewEstimate;
		private System.Windows.Forms.ToolStripSeparator cnuOptionsN1;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsDeleteCargo;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsBillPayFlags;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsNonBillable;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsNonPayable;
		private System.Windows.Forms.ToolStripMenuItem cnuOptionsNonBillPay;
	}
}