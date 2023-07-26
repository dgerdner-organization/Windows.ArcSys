namespace CS2010.ArcSys.Win
{
	partial class frmPATLoadList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPATLoadList));
			Janus.Windows.GridEX.GridEXLayout grdLOB_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdLobRemoved_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCreateNew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbSentToPat = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbTestPat = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.miniToolStrip = new System.Windows.Forms.ToolStrip();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsbNewRow = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbDeleteRow = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.grdLOB = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdLobRemoved = new CS2010.CommonWinCtrls.ucGridEx();
			this.lblDeleted = new System.Windows.Forms.Label();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.tsbAddtoLoadList = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.lblLoadList = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdLOB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLobRemoved)).BeginInit();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbCreateNew,
            this.toolStripSeparator2,
            this.tsbLoad,
            this.toolStripSeparator3,
            this.tsbDelete,
            this.toolStripSeparator4,
            this.tsbSentToPat,
            this.toolStripSeparator8,
            this.tsbTestPat,
            this.toolStripSeparator9});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(919, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(113, 22);
			this.tsbSave.Text = "&Save Current Version";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbCreateNew
			// 
			this.tsbCreateNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbCreateNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateNew.Image")));
			this.tsbCreateNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCreateNew.Name = "tsbCreateNew";
			this.tsbCreateNew.Size = new System.Drawing.Size(106, 22);
			this.tsbCreateNew.Text = "&Create New Version";
			this.tsbCreateNew.Click += new System.EventHandler(this.tsbCreateNew_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbLoad
			// 
			this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
			this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLoad.Name = "tsbLoad";
			this.tsbLoad.Size = new System.Drawing.Size(72, 22);
			this.tsbLoad.Text = "&Load Version";
			this.tsbLoad.Click += new System.EventHandler(this.tsbLoad_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbDelete
			// 
			this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(80, 22);
			this.tsbDelete.Text = "&Delete Version";
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbSentToPat
			// 
			this.tsbSentToPat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbSentToPat.Image = ((System.Drawing.Image)(resources.GetObject("tsbSentToPat.Image")));
			this.tsbSentToPat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSentToPat.Name = "tsbSentToPat";
			this.tsbSentToPat.Size = new System.Drawing.Size(70, 22);
			this.tsbSentToPat.Text = "&Send to PAT";
			this.tsbSentToPat.Click += new System.EventHandler(this.tsbSentToPat_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbTestPat
			// 
			this.tsbTestPat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbTestPat.Image = ((System.Drawing.Image)(resources.GetObject("tsbTestPat.Image")));
			this.tsbTestPat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTestPat.Name = "tsbTestPat";
			this.tsbTestPat.Size = new System.Drawing.Size(54, 22);
			this.tsbTestPat.Text = "&Test PAT";
			this.tsbTestPat.Click += new System.EventHandler(this.tsbTestPat_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// miniToolStrip
			// 
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.miniToolStrip.Location = new System.Drawing.Point(7, 3);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new System.Drawing.Size(914, 25);
			this.miniToolStrip.TabIndex = 11;
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ucSplitContainer1.BackColor = System.Drawing.SystemColors.Control;
			this.ucSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ucSplitContainer1.Location = new System.Drawing.Point(0, 63);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.label1);
			this.ucSplitContainer1.Panel1.Controls.Add(this.toolStrip2);
			this.ucSplitContainer1.Panel1.Controls.Add(this.grdLOB);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdLobRemoved);
			this.ucSplitContainer1.Panel2.Controls.Add(this.lblDeleted);
			this.ucSplitContainer1.Panel2.Controls.Add(this.toolStrip3);
			this.ucSplitContainer1.Size = new System.Drawing.Size(914, 450);
			this.ucSplitContainer1.SplitterDistance = 252;
			this.ucSplitContainer1.SplitterWidth = 20;
			this.ucSplitContainer1.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "LOB Load List";
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewRow,
            this.toolStripSeparator5,
            this.tsbDeleteRow,
            this.toolStripSeparator6});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(912, 25);
			this.toolStrip2.TabIndex = 10;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsbNewRow
			// 
			this.tsbNewRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbNewRow.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewRow.Image")));
			this.tsbNewRow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNewRow.Name = "tsbNewRow";
			this.tsbNewRow.Size = new System.Drawing.Size(56, 22);
			this.tsbNewRow.Text = "&New Row";
			this.tsbNewRow.Click += new System.EventHandler(this.tsbNewRow_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbDeleteRow
			// 
			this.tsbDeleteRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteRow.Image")));
			this.tsbDeleteRow.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDeleteRow.Name = "tsbDeleteRow";
			this.tsbDeleteRow.Size = new System.Drawing.Size(66, 22);
			this.tsbDeleteRow.Text = "&Delete Row";
			this.tsbDeleteRow.Click += new System.EventHandler(this.tsbDeleteRow_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// grdLOB
			// 
			this.grdLOB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			grdLOB_DesignTimeLayout.LayoutString = resources.GetString("grdLOB_DesignTimeLayout.LayoutString");
			this.grdLOB.DesignTimeLayout = grdLOB_DesignTimeLayout;
			this.grdLOB.ExportFileID = null;
			this.grdLOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdLOB.Location = new System.Drawing.Point(3, 60);
			this.grdLOB.Name = "grdLOB";
			this.grdLOB.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdLOB.Size = new System.Drawing.Size(906, 187);
			this.grdLOB.TabIndex = 9;
			this.grdLOB.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdLOB_FormattingRow);
			this.grdLOB.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLOB_ColumnButtonClick);
			this.grdLOB.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLOB_LinkClicked);
			this.grdLOB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdLOB_KeyUp);
			// 
			// grdLobRemoved
			// 
			this.grdLobRemoved.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			grdLobRemoved_DesignTimeLayout.LayoutString = resources.GetString("grdLobRemoved_DesignTimeLayout.LayoutString");
			this.grdLobRemoved.DesignTimeLayout = grdLobRemoved_DesignTimeLayout;
			this.grdLobRemoved.ExportFileID = null;
			this.grdLobRemoved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdLobRemoved.Location = new System.Drawing.Point(3, 69);
			this.grdLobRemoved.Name = "grdLobRemoved";
			this.grdLobRemoved.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdLobRemoved.Size = new System.Drawing.Size(906, 56);
			this.grdLobRemoved.TabIndex = 13;
			// 
			// lblDeleted
			// 
			this.lblDeleted.AutoSize = true;
			this.lblDeleted.Location = new System.Drawing.Point(11, 42);
			this.lblDeleted.Name = "lblDeleted";
			this.lblDeleted.Size = new System.Drawing.Size(151, 13);
			this.lblDeleted.TabIndex = 12;
			this.lblDeleted.Text = "ACMS Cargo NOT in Load List";
			this.lblDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddtoLoadList,
            this.toolStripSeparator7});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(912, 25);
			this.toolStrip3.TabIndex = 11;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// tsbAddtoLoadList
			// 
			this.tsbAddtoLoadList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAddtoLoadList.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddtoLoadList.Image")));
			this.tsbAddtoLoadList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAddtoLoadList.Name = "tsbAddtoLoadList";
			this.tsbAddtoLoadList.Size = new System.Drawing.Size(88, 22);
			this.tsbAddtoLoadList.Text = "&Add to Load List";
			this.tsbAddtoLoadList.Click += new System.EventHandler(this.tsbAddtoLoadList_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// lblLoadList
			// 
			this.lblLoadList.AutoSize = true;
			this.lblLoadList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoadList.ForeColor = System.Drawing.Color.Black;
			this.lblLoadList.Location = new System.Drawing.Point(12, 34);
			this.lblLoadList.Name = "lblLoadList";
			this.lblLoadList.Size = new System.Drawing.Size(23, 16);
			this.lblLoadList.TabIndex = 12;
			this.lblLoadList.Text = "...";
			this.lblLoadList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmPATLoadList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(919, 525);
			this.Controls.Add(this.lblLoadList);
			this.Controls.Add(this.ucSplitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "frmPATLoadList";
			this.Text = "Load List";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.PerformLayout();
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdLOB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLobRemoved)).EndInit();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private CommonWinCtrls.ucGridEx grdLOB;
        private CommonWinCtrls.ucGridEx grdLobRemoved;
        private System.Windows.Forms.Label lblDeleted;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbCreateNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoadList;
        private System.Windows.Forms.ToolStripButton tsbNewRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbDeleteRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbAddtoLoadList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbSentToPat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsbTestPat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;


    }
}
