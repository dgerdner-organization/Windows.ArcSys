namespace CS2010.ArcSys.Win
{
	partial class frmSterlingReports
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
			Janus.Windows.GridEX.GridEXLayout grdList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSterlingReports));
			this.grdList = new CS2010.CommonWinCtrls.ucGridEx();
			this.txtContent = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlMain = new CS2010.CommonWinCtrls.ucPanel();
			this.progressMain = new System.Windows.Forms.ProgressBar();
			this.ucButton1 = new CS2010.CommonWinCtrls.ucButton();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.txtFind = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnFind = new CS2010.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdList
			// 
			grdList_DesignTimeLayout.LayoutString = resources.GetString("grdList_DesignTimeLayout.LayoutString");
			this.grdList.DesignTimeLayout = grdList_DesignTimeLayout;
			this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdList.ExportFileID = null;
			this.grdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdList.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdList.Location = new System.Drawing.Point(0, 0);
			this.grdList.Name = "grdList";
			this.grdList.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdList.Size = new System.Drawing.Size(899, 342);
			this.grdList.TabIndex = 0;
			this.grdList.SelectionChanged += new System.EventHandler(this.grdList_SelectionChanged);
			// 
			// txtContent
			// 
			this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtContent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtContent.LinkDisabledMessage = "Link Disabled";
			this.txtContent.Location = new System.Drawing.Point(0, 388);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtContent.Size = new System.Drawing.Size(899, 187);
			this.txtContent.TabIndex = 10;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.progressMain);
			this.pnlMain.Controls.Add(this.ucButton1);
			this.pnlMain.Controls.Add(this.btnEdit);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlMain.Location = new System.Drawing.Point(0, 575);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(899, 33);
			this.pnlMain.TabIndex = 2;
			// 
			// progressMain
			// 
			this.progressMain.Location = new System.Drawing.Point(133, 4);
			this.progressMain.Name = "progressMain";
			this.progressMain.Size = new System.Drawing.Size(762, 23);
			this.progressMain.TabIndex = 3;
			// 
			// ucButton1
			// 
			this.ucButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucButton1.Location = new System.Drawing.Point(98, 4);
			this.ucButton1.Name = "ucButton1";
			this.ucButton1.Size = new System.Drawing.Size(28, 23);
			this.ucButton1.TabIndex = 2;
			this.ucButton1.Text = "?";
			this.ucButton1.UseVisualStyleBackColor = true;
			this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(3, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(90, 23);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Edit / Print";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.ucSplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.btnFind);
			this.ucSplitContainer1.Panel1.Controls.Add(this.txtFind);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdList);
			this.ucSplitContainer1.Size = new System.Drawing.Size(899, 388);
			this.ucSplitContainer1.SplitterDistance = 42;
			this.ucSplitContainer1.TabIndex = 3;
			// 
			// txtFind
			// 
			this.txtFind.LabelText = "Find";
			this.txtFind.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFind.LinkDisabledMessage = "Link Disabled";
			this.txtFind.Location = new System.Drawing.Point(45, 12);
			this.txtFind.Name = "txtFind";
			this.txtFind.Size = new System.Drawing.Size(164, 20);
			this.txtFind.TabIndex = 1;
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(214, 10);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(45, 23);
			this.btnFind.TabIndex = 1;
			this.btnFind.Text = "Go";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// frmSterlingReports
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(899, 608);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.ucSplitContainer1);
			this.Controls.Add(this.pnlMain);
			this.Name = "frmSterlingReports";
			this.Text = "Sterling Commerce Reports";
			this.Load += new System.EventHandler(this.frmSterlingReports_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.PerformLayout();
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdList;
		private CommonWinCtrls.ucTextBox txtContent;
		private CommonWinCtrls.ucPanel pnlMain;
		private CommonWinCtrls.ucButton btnEdit;
		private CommonWinCtrls.ucButton ucButton1;
		private System.Windows.Forms.ProgressBar progressMain;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CommonWinCtrls.ucButton btnFind;
		private CommonWinCtrls.ucTextBox txtFind;
	}
}
