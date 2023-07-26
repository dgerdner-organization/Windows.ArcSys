namespace CS2010.CommonReports
{
	partial class frmGridPreview
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
			if( disposing && ( components != null ) )
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
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbPreview = new System.Windows.Forms.ToolStripButton();
            this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbSaveLayout = new System.Windows.Forms.ToolStripButton();
            this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClose = new System.Windows.Forms.ToolStripButton();
            this.grdView = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbPrint,
            this.tbbPreview,
            this.tbbN1,
            this.tbbSaveLayout,
            this.tbbN2,
            this.tbbClose});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(826, 25);
            this.tbrMain.TabIndex = 0;
            // 
            // tbbPrint
            // 
            this.tbbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(33, 22);
            this.tbbPrint.Text = "&Print";
            this.tbbPrint.Click += new System.EventHandler(this.tbbPrint_Click);
            // 
            // tbbPreview
            // 
            this.tbbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPreview.Name = "tbbPreview";
            this.tbbPreview.Size = new System.Drawing.Size(49, 22);
            this.tbbPreview.Text = "Pre&view";
            this.tbbPreview.Click += new System.EventHandler(this.tbbPreview_Click);
            // 
            // tbbN1
            // 
            this.tbbN1.Name = "tbbN1";
            this.tbbN1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbSaveLayout
            // 
            this.tbbSaveLayout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbSaveLayout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSaveLayout.Name = "tbbSaveLayout";
            this.tbbSaveLayout.Size = new System.Drawing.Size(71, 22);
            this.tbbSaveLayout.Text = "Save Layout";
            this.tbbSaveLayout.Click += new System.EventHandler(this.tbbSaveLayout_Click);
            // 
            // tbbN2
            // 
            this.tbbN2.Name = "tbbN2";
            this.tbbN2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbClose
            // 
            this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClose.Name = "tbbClose";
            this.tbbClose.Size = new System.Drawing.Size(37, 22);
            this.tbbClose.Text = "Close";
            this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
            // 
            // grdView
            // 
            this.grdView.DisplayFieldChooser = true;
            this.grdView.DisplayFontSelector = true;
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.ExportFileID = null;
            this.grdView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdView.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdView.Location = new System.Drawing.Point(0, 25);
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(826, 552);
            this.grdView.TabIndex = 1;
            this.grdView.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdView_LinkClicked);
            // 
            // frmGridPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 577);
            this.Controls.Add(this.grdView);
            this.Controls.Add(this.tbrMain);
            this.KeyPreview = true;
            this.Name = "frmGridPreview";
            this.Text = "Grid Report Data Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportPreview_FormClosed);
            this.Load += new System.EventHandler(this.frmReportPreview_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportPreview_KeyDown);
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbClose;
		private CS2010.CommonWinCtrls.ucGridEx grdView;
		private System.Windows.Forms.ToolStripButton tbbPrint;
		private System.Windows.Forms.ToolStripButton tbbPreview;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.ToolStripButton tbbSaveLayout;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
	}
}