namespace CS2010.ArcSys.Win
{
	partial class frmRequestEDILog
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
			Janus.Windows.GridEX.GridEXLayout grdEDILog_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequestEDILog));
			Janus.Windows.GridEX.GridEXLayout grdArcEDILog_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdOceanAPI_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grdEDILog = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdArcEDILog = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
			this.grdOceanAPI = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.grdEDILog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdArcEDILog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			this.ucPanel1.SuspendLayout();
			this.ucPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdOceanAPI)).BeginInit();
			this.SuspendLayout();
			// 
			// grdEDILog
			// 
			grdEDILog_DesignTimeLayout.LayoutString = resources.GetString("grdEDILog_DesignTimeLayout.LayoutString");
			this.grdEDILog.DesignTimeLayout = grdEDILog_DesignTimeLayout;
			this.grdEDILog.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdEDILog.ExportFileID = null;
			this.grdEDILog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdEDILog.GroupByBoxVisible = false;
			this.grdEDILog.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdEDILog.Location = new System.Drawing.Point(0, 0);
			this.grdEDILog.Name = "grdEDILog";
			this.grdEDILog.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdEDILog.Size = new System.Drawing.Size(1131, 158);
			this.grdEDILog.TabIndex = 1;
			this.grdEDILog.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdEDILog_FormattingRow);
			this.grdEDILog.SelectionChanged += new System.EventHandler(this.grdEDILog_SelectionChanged);
			this.grdEDILog.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdEDILog_LinkClicked);
			// 
			// grdArcEDILog
			// 
			grdArcEDILog_DesignTimeLayout.LayoutString = resources.GetString("grdArcEDILog_DesignTimeLayout.LayoutString");
			this.grdArcEDILog.DesignTimeLayout = grdArcEDILog_DesignTimeLayout;
			this.grdArcEDILog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdArcEDILog.ExportFileID = null;
			this.grdArcEDILog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdArcEDILog.GroupByBoxVisible = false;
			this.grdArcEDILog.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdArcEDILog.Location = new System.Drawing.Point(0, 24);
			this.grdArcEDILog.Name = "grdArcEDILog";
			this.grdArcEDILog.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdArcEDILog.Size = new System.Drawing.Size(1131, 305);
			this.grdArcEDILog.TabIndex = 2;
			this.grdArcEDILog.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdArcEDILog_LinkClicked);
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.grdArcEDILog);
			this.ucSplitContainer1.Panel1.Controls.Add(this.ucPanel1);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.ucPanel2);
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdEDILog);
			this.ucSplitContainer1.Size = new System.Drawing.Size(1131, 658);
			this.ucSplitContainer1.SplitterDistance = 329;
			this.ucSplitContainer1.TabIndex = 3;
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.ucLabel1);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(1131, 24);
			this.ucPanel1.TabIndex = 2;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(3, 8);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(80, 13);
			this.ucLabel1.TabIndex = 0;
			this.ucLabel1.Text = "EDI with SDDC";
			// 
			// ucPanel2
			// 
			this.ucPanel2.Controls.Add(this.grdOceanAPI);
			this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel2.Location = new System.Drawing.Point(0, 158);
			this.ucPanel2.Name = "ucPanel2";
			this.ucPanel2.Size = new System.Drawing.Size(1131, 141);
			this.ucPanel2.TabIndex = 3;
			// 
			// grdOceanAPI
			// 
			grdOceanAPI_DesignTimeLayout.LayoutString = resources.GetString("grdOceanAPI_DesignTimeLayout.LayoutString");
			this.grdOceanAPI.DesignTimeLayout = grdOceanAPI_DesignTimeLayout;
			this.grdOceanAPI.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdOceanAPI.ExportFileID = null;
			this.grdOceanAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdOceanAPI.GroupByBoxVisible = false;
			this.grdOceanAPI.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdOceanAPI.Location = new System.Drawing.Point(0, 0);
			this.grdOceanAPI.Name = "grdOceanAPI";
			this.grdOceanAPI.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdOceanAPI.Size = new System.Drawing.Size(1131, 158);
			this.grdOceanAPI.TabIndex = 2;
			// 
			// frmRequestEDILog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1131, 658);
			this.Controls.Add(this.ucSplitContainer1);
			this.Name = "frmRequestEDILog";
			this.Text = "Request EDI Log";
			((System.ComponentModel.ISupportInitialize)(this.grdEDILog)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdArcEDILog)).EndInit();
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			this.ucPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdOceanAPI)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdEDILog;
		private CommonWinCtrls.ucGridEx grdArcEDILog;
		private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucPanel ucPanel2;
		private CommonWinCtrls.ucGridEx grdOceanAPI;
	}
}
