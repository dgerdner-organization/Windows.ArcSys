namespace CS2010.ArcSys.Win
{
	partial class frmDimsSynch
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
			Janus.Windows.GridEX.GridEXLayout grdMismatchDims_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDimsSynch));
			this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.btnRemove = new CS2010.CommonWinCtrls.ucButton();
			this.btnUpdate = new CS2010.CommonWinCtrls.ucButton();
			this.grdMismatchDims = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMismatchDims)).BeginInit();
			this.SuspendLayout();
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitMain.Location = new System.Drawing.Point(0, 0);
			this.splitMain.Name = "splitMain";
			this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.btnRemove);
			this.splitMain.Panel1.Controls.Add(this.btnUpdate);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.grdMismatchDims);
			this.splitMain.Size = new System.Drawing.Size(960, 592);
			this.splitMain.SplitterDistance = 102;
			this.splitMain.TabIndex = 16;
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(28, 42);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(112, 23);
			this.btnRemove.TabIndex = 1;
			this.btnRemove.Text = "Remove Selected";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(28, 12);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(112, 23);
			this.btnUpdate.TabIndex = 0;
			this.btnUpdate.Text = "Update Selected";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// grdMismatchDims
			// 
			this.grdMismatchDims.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdMismatchDims.ColumnAutoResize = true;
			grdMismatchDims_DesignTimeLayout.LayoutString = resources.GetString("grdMismatchDims_DesignTimeLayout.LayoutString");
			this.grdMismatchDims.DesignTimeLayout = grdMismatchDims_DesignTimeLayout;
			this.grdMismatchDims.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMismatchDims.ExportFileID = null;
			this.grdMismatchDims.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdMismatchDims.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdMismatchDims.Location = new System.Drawing.Point(0, 0);
			this.grdMismatchDims.Name = "grdMismatchDims";
			this.grdMismatchDims.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMismatchDims.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this.grdMismatchDims.Size = new System.Drawing.Size(960, 486);
			this.grdMismatchDims.TabIndex = 30;
			this.grdMismatchDims.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdMismatchDims.UseGroupRowSelector = true;
			this.grdMismatchDims.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMismatchDims_ColumnButtonClick);
			this.grdMismatchDims.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMismatchDims_LinkClicked);
			// 
			// frmDimsSynch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(960, 592);
			this.Controls.Add(this.splitMain);
			this.Name = "frmDimsSynch";
			this.Text = "Dimension Synchronization";
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdMismatchDims)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartnerz;
		private CommonWinCtrls.ucGridEx grdLog;
		private CommonWinCtrls.ucGridEx grdMismatchDims;
		private CommonWinCtrls.ucButton btnRemove;
		private CommonWinCtrls.ucButton btnUpdate;
	}
}
