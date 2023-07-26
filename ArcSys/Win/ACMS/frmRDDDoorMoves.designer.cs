namespace ASL.ARC.EDITools
{
	partial class frmRDDDoorMoves
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
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClear = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.cbxIncludeStena = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
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
			this.pnlMain.Panel1.Controls.Add(this.cbxIncludeStena);
			this.pnlMain.Panel1.Controls.Add(this.txtVoyage);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.crystalReportViewer1);
			this.pnlMain.Size = new System.Drawing.Size(846, 556);
			this.pnlMain.SplitterDistance = 95;
			this.pnlMain.TabIndex = 0;
			// 
			// cbxIncludeStena
			// 
			this.cbxIncludeStena.Location = new System.Drawing.Point(65, 37);
			this.cbxIncludeStena.Name = "cbxIncludeStena";
			this.cbxIncludeStena.Size = new System.Drawing.Size(195, 24);
			this.cbxIncludeStena.TabIndex = 2;
			this.cbxIncludeStena.Text = "Include Stena Bookings?";
			this.cbxIncludeStena.UseVisualStyleBackColor = true;
			this.cbxIncludeStena.YN = "N";
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(65, 11);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtVoyage.TabIndex = 0;
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ShowParameterPanelButton = false;
			this.crystalReportViewer1.ShowRefreshButton = false;
			this.crystalReportViewer1.Size = new System.Drawing.Size(846, 457);
			this.crystalReportViewer1.TabIndex = 0;
			this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
			// 
			// frmRDDDoorMoves
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 581);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmRDDDoorMoves";
			this.Text = "RDD Report Door Moves";
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel1.PerformLayout();
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
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
		//private CS2010.ArcSys.Win.rptRPTDoorOutilms rptRPTDoorOutilms1;
		private CS2010.CommonWinCtrls.ucCheckBox cbxIncludeStena;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
	}
}