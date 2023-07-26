namespace CS2010.ArcSys.Win
{
	partial class frmEDIInboundLog
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
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDIInboundLog));
			this.pnlSearch = new CS2010.CommonWinCtrls.ucPanel();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.ucLabel1);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(782, 46);
			this.pnlSearch.TabIndex = 0;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.ucLabel1.Location = new System.Drawing.Point(14, 11);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(311, 26);
			this.ucLabel1.TabIndex = 0;
			this.ucLabel1.Text = "Charleston HHG Received Log";
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdMain.Location = new System.Drawing.Point(0, 46);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(782, 450);
			this.grdMain.TabIndex = 1;
			this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
			// 
			// frmEDIInboundLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.pnlSearch);
			this.Name = "frmEDIInboundLog";
			this.Text = "LINE EDI Inbound Log";
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlSearch;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucLabel ucLabel1;
	}
}
