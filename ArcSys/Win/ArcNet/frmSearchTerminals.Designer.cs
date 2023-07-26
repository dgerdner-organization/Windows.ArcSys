namespace CS2010.ArcSys.Win
{
	partial class frmSearchTerminals
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchTerminals));
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.lblParams = new System.Windows.Forms.Label();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
			this.tbbMainSearch = new System.Windows.Forms.ToolStripButton();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbMainN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbMainNewTerminal = new System.Windows.Forms.ToolStripButton();
			this.tabSearchMain = new CS2010.CommonWinCtrls.ucTabControl();
			this.tpgMainResults = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			this.pnlTop.SuspendLayout();
			this.sbrChild.SuspendLayout();
			this.tbrMain.SuspendLayout();
			this.tabSearchMain.SuspendLayout();
			this.tpgMainResults.SuspendLayout();
			this.SuspendLayout();
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
			this.grdResults.Size = new System.Drawing.Size(992, 624);
			this.grdResults.TabIndex = 6;
			this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
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
			this.pnlTop.Size = new System.Drawing.Size(1006, 23);
			this.pnlTop.TabIndex = 5;
			this.pnlTop.Resize += new System.EventHandler(this.pnlTop_Resize);
			// 
			// tbbMainSearch
			// 
			this.tbbMainSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbMainSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbMainSearch.Name = "tbbMainSearch";
			this.tbbMainSearch.Size = new System.Drawing.Size(44, 22);
			this.tbbMainSearch.Text = "&Search";
			this.tbbMainSearch.Click += new System.EventHandler(this.tbbMainSearch_Click);
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
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbMainSearch,
            this.tbbMainN1,
            this.tbbMainNewTerminal});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1006, 25);
			this.tbrMain.TabIndex = 3;
			this.tbrMain.Text = "Search Available Main Toolbar";
			// 
			// tbbMainN1
			// 
			this.tbbMainN1.Name = "tbbMainN1";
			this.tbbMainN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbMainNewTerminal
			// 
			this.tbbMainNewTerminal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbMainNewTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbMainNewTerminal.Name = "tbbMainNewTerminal";
			this.tbbMainNewTerminal.Size = new System.Drawing.Size(109, 22);
			this.tbbMainNewTerminal.Text = "Add New Terminal...";
			this.tbbMainNewTerminal.Click += new System.EventHandler(this.tbbMainNewTerminal_Click);
			// 
			// tabSearchMain
			// 
			this.tabSearchMain.Controls.Add(this.tpgMainResults);
			this.tabSearchMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabSearchMain.Location = new System.Drawing.Point(0, 48);
			this.tabSearchMain.Name = "tabSearchMain";
			this.tabSearchMain.SelectedIndex = 0;
			this.tabSearchMain.Size = new System.Drawing.Size(1006, 656);
			this.tabSearchMain.TabIndex = 7;
			// 
			// tpgMainResults
			// 
			this.tpgMainResults.Controls.Add(this.grdResults);
			this.tpgMainResults.Location = new System.Drawing.Point(4, 22);
			this.tpgMainResults.Name = "tpgMainResults";
			this.tpgMainResults.Padding = new System.Windows.Forms.Padding(3);
			this.tpgMainResults.Size = new System.Drawing.Size(998, 630);
			this.tpgMainResults.TabIndex = 0;
			this.tpgMainResults.Text = "Terminal Information";
			this.tpgMainResults.UseVisualStyleBackColor = true;
			// 
			// frmSearchTerminals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 704);
			this.Controls.Add(this.tabSearchMain);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmSearchTerminals";
			this.Text = "Search Terminals";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchTerminals_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchTerminals_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.tabSearchMain.ResumeLayout(false);
			this.tpgMainResults.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdResults;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.Label lblParams;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private CommonWinCtrls.ucPanel pnlTop;
		private System.Windows.Forms.ToolStripButton tbbMainSearch;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTabControl tabSearchMain;
		private System.Windows.Forms.TabPage tpgMainResults;
		private System.Windows.Forms.ToolStripSeparator tbbMainN1;
		private System.Windows.Forms.ToolStripButton tbbMainNewTerminal;
	}
}