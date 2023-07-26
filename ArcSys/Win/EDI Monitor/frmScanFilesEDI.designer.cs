namespace CS2010.ArcSys.Win
{
	partial class frmScanFilesEDI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanFilesEDI));
			Janus.Windows.GridEX.GridEXLayout grdScan_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbScan = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnProcess = new System.Windows.Forms.ToolStripButton();
			this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbArchiveFiles = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbShowArchive = new System.Windows.Forms.ToolStripButton();
			this.btnReadable = new System.Windows.Forms.ToolStripButton();
			this.btnShowFile = new System.Windows.Forms.ToolStripButton();
			this.rtfContents = new System.Windows.Forms.RichTextBox();
			this.pnlMain = new System.Windows.Forms.SplitContainer();
			this.grdScan = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrFind = new System.Windows.Forms.ToolStrip();
			this.tbbHideFind = new System.Windows.Forms.ToolStripButton();
			this.tbbFindText = new System.Windows.Forms.ToolStripTextBox();
			this.tbbFind = new System.Windows.Forms.ToolStripButton();
			this.bkgThread = new System.ComponentModel.BackgroundWorker();
			this.sbrMain = new System.Windows.Forms.StatusStrip();
			this.sbbCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.btnDOD = new CS2010.CommonWinCtrls.ucButton();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdScan)).BeginInit();
			this.tbrFind.SuspendLayout();
			this.sbrMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbScan,
            this.tbbN1,
            this.btnProcess,
            this.tbbN2,
            this.tbbArchiveFiles,
            this.toolStripSeparator1,
            this.tbbShowArchive,
            this.btnReadable,
            this.btnShowFile});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1065, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "Main toolbar of reprocess EDI window";
			// 
			// tbbScan
			// 
			this.tbbScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbScan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbScan.Name = "tbbScan";
			this.tbbScan.Size = new System.Drawing.Size(34, 22);
			this.tbbScan.Text = "&Scan";
			this.tbbScan.Click += new System.EventHandler(this.tbbScan_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnProcess
			// 
			this.btnProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(116, 22);
			this.btnProcess.Text = "&Process Selected Files";
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// tbbN2
			// 
			this.tbbN2.Name = "tbbN2";
			this.tbbN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbArchiveFiles
			// 
			this.tbbArchiveFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbArchiveFiles.Image = ((System.Drawing.Image)(resources.GetObject("tbbArchiveFiles.Image")));
			this.tbbArchiveFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbArchiveFiles.Name = "tbbArchiveFiles";
			this.tbbArchiveFiles.Size = new System.Drawing.Size(115, 22);
			this.tbbArchiveFiles.Text = "Ar&chive Selected Files";
			this.tbbArchiveFiles.Click += new System.EventHandler(this.tbbArchiveFiles_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbShowArchive
			// 
			this.tbbShowArchive.CheckOnClick = true;
			this.tbbShowArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbShowArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbShowArchive.Name = "tbbShowArchive";
			this.tbbShowArchive.Size = new System.Drawing.Size(76, 22);
			this.tbbShowArchive.Text = "Show &Archive";
			this.tbbShowArchive.ToolTipText = "Determines whether the archive folders will be scanned for each message";
			this.tbbShowArchive.Visible = false;
			this.tbbShowArchive.Click += new System.EventHandler(this.tbbShowArchive_Click);
			// 
			// btnReadable
			// 
			this.btnReadable.CheckOnClick = true;
			this.btnReadable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnReadable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnReadable.Name = "btnReadable";
			this.btnReadable.Size = new System.Drawing.Size(99, 22);
			this.btnReadable.Text = "&User Friendly Text";
			this.btnReadable.ToolTipText = "Formats the EDI file to make it easier to read";
			this.btnReadable.Visible = false;
			this.btnReadable.Click += new System.EventHandler(this.btnReadable_Click);
			// 
			// btnShowFile
			// 
			this.btnShowFile.CheckOnClick = true;
			this.btnShowFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnShowFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnShowFile.Name = "btnShowFile";
			this.btnShowFile.Size = new System.Drawing.Size(56, 22);
			this.btnShowFile.Text = "Show File";
			this.btnShowFile.ToolTipText = "Display the contents of the EDI file";
			this.btnShowFile.Click += new System.EventHandler(this.btnShowFile_Click);
			// 
			// rtfContents
			// 
			this.rtfContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfContents.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtfContents.Location = new System.Drawing.Point(0, 0);
			this.rtfContents.Name = "rtfContents";
			this.rtfContents.ReadOnly = true;
			this.rtfContents.Size = new System.Drawing.Size(150, 46);
			this.rtfContents.TabIndex = 0;
			this.rtfContents.Text = "";
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.grdScan);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.rtfContents);
			this.pnlMain.Panel2Collapsed = true;
			this.pnlMain.Size = new System.Drawing.Size(1065, 499);
			this.pnlMain.SplitterDistance = 338;
			this.pnlMain.TabIndex = 1;
			// 
			// grdScan
			// 
			this.grdScan.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdScan.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdScan_DesignTimeLayout.LayoutString = resources.GetString("grdScan_DesignTimeLayout.LayoutString");
			this.grdScan.DesignTimeLayout = grdScan_DesignTimeLayout;
			this.grdScan.DisplayFieldChooser = true;
			this.grdScan.DisplayFontSelector = true;
			this.grdScan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdScan.ExportFileID = null;
			this.grdScan.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdScan.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdScan.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdScan.Location = new System.Drawing.Point(0, 0);
			this.grdScan.Name = "grdScan";
			this.grdScan.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdScan.Size = new System.Drawing.Size(1065, 499);
			this.grdScan.TabIndex = 0;
			this.grdScan.UseGroupRowSelector = true;
			this.grdScan.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdScan_ColumnButtonClick);
			this.grdScan.SelectionChanged += new System.EventHandler(this.grdScan_SelectionChanged);
			this.grdScan.FilterApplied += new System.EventHandler(this.grdScan_FilterApplied);
			this.grdScan.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdScan_LinkClicked);
			this.grdScan.DoubleClick += new System.EventHandler(this.grdScan_DoubleClick);
			this.grdScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdScan_KeyDown);
			// 
			// tbrFind
			// 
			this.tbrFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbHideFind,
            this.tbbFindText,
            this.tbbFind});
			this.tbrFind.Location = new System.Drawing.Point(0, 25);
			this.tbrFind.Name = "tbrFind";
			this.tbrFind.Size = new System.Drawing.Size(782, 25);
			this.tbrFind.TabIndex = 2;
			this.tbrFind.Text = "Find Toolbar of reprocess EDI window";
			this.tbrFind.Visible = false;
			// 
			// tbbHideFind
			// 
			this.tbbHideFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tbbHideFind.Image = ((System.Drawing.Image)(resources.GetObject("tbbHideFind.Image")));
			this.tbbHideFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbHideFind.Name = "tbbHideFind";
			this.tbbHideFind.Size = new System.Drawing.Size(23, 22);
			this.tbbHideFind.Text = "toolStripButton1";
			this.tbbHideFind.Click += new System.EventHandler(this.tbbHideFind_Click);
			// 
			// tbbFindText
			// 
			this.tbbFindText.Name = "tbbFindText";
			this.tbbFindText.Size = new System.Drawing.Size(300, 25);
			this.tbbFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbbFindText_KeyDown);
			// 
			// tbbFind
			// 
			this.tbbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbFind.Name = "tbbFind";
			this.tbbFind.Size = new System.Drawing.Size(31, 22);
			this.tbbFind.Text = "&Find";
			this.tbbFind.Click += new System.EventHandler(this.tbbFind_Click);
			// 
			// bkgThread
			// 
			this.bkgThread.WorkerReportsProgress = true;
			this.bkgThread.WorkerSupportsCancellation = true;
			this.bkgThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgThread_DoWork);
			this.bkgThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bkgThread_ProgressChanged);
			this.bkgThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgThread_RunWorkerCompleted);
			// 
			// sbrMain
			// 
			this.sbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbCaption,
            this.sbbProgress});
			this.sbrMain.Location = new System.Drawing.Point(0, 524);
			this.sbrMain.Name = "sbrMain";
			this.sbrMain.Size = new System.Drawing.Size(1065, 22);
			this.sbrMain.TabIndex = 3;
			this.sbrMain.Text = "statusStrip1";
			// 
			// sbbCaption
			// 
			this.sbbCaption.IsLink = true;
			this.sbbCaption.Name = "sbbCaption";
			this.sbbCaption.Size = new System.Drawing.Size(189, 17);
			this.sbbCaption.Text = "Scanning Files... (Click here to cancel)";
			this.sbbCaption.Click += new System.EventHandler(this.sbbCaption_Click);
			// 
			// sbbProgress
			// 
			this.sbbProgress.AutoSize = false;
			this.sbbProgress.Name = "sbbProgress";
			this.sbbProgress.Size = new System.Drawing.Size(250, 16);
			this.sbbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// btnDOD
			// 
			this.btnDOD.Location = new System.Drawing.Point(634, 0);
			this.btnDOD.Name = "btnDOD";
			this.btnDOD.Size = new System.Drawing.Size(112, 23);
			this.btnDOD.TabIndex = 4;
			this.btnDOD.Text = "Search && Replace";
			this.btnDOD.UseVisualStyleBackColor = true;
			this.btnDOD.Click += new System.EventHandler(this.btnDOD_Click);
			// 
			// frmScanFilesEDI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1065, 546);
			this.Controls.Add(this.btnDOD);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.sbrMain);
			this.Controls.Add(this.tbrFind);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmScanFilesEDI";
			this.Text = "EDI Monitor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScanFilesEDI_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmScanFilesEDI_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmScanFilesEDI_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdScan)).EndInit();
			this.tbrFind.ResumeLayout(false);
			this.tbrFind.PerformLayout();
			this.sbrMain.ResumeLayout(false);
			this.sbrMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbScan;
		private System.Windows.Forms.ToolStripButton btnProcess;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.RichTextBox rtfContents;
		private System.Windows.Forms.SplitContainer pnlMain;
		private CS2010.CommonWinCtrls.ucGridEx grdScan;
		private System.Windows.Forms.ToolStrip tbrFind;
		private System.Windows.Forms.ToolStripButton tbbHideFind;
		private System.Windows.Forms.ToolStripTextBox tbbFindText;
		private System.Windows.Forms.ToolStripButton tbbFind;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
		private System.Windows.Forms.ToolStripButton tbbShowArchive;
		private System.Windows.Forms.ToolStripButton btnReadable;
		private System.Windows.Forms.ToolStripButton tbbArchiveFiles;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.ComponentModel.BackgroundWorker bkgThread;
		private System.Windows.Forms.StatusStrip sbrMain;
		private System.Windows.Forms.ToolStripProgressBar sbbProgress;
		private System.Windows.Forms.ToolStripStatusLabel sbbCaption;
		private System.Windows.Forms.ToolStripButton btnShowFile;
		private CommonWinCtrls.ucButton btnDOD;
	}
}