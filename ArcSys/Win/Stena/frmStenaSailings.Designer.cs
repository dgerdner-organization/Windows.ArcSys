namespace CS2010.ArcSys.Win
{
	partial class frmStenaSailings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStenaSailings));
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucLabel5 = new CS2010.CommonWinCtrls.ucLabel();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.SuspendLayout();
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdMain.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdMain.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdMain.Location = new System.Drawing.Point(0, 25);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(1064, 572);
			this.grdMain.TabIndex = 0;
			this.grdMain.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_ColumnButtonClick);
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// ucLabel5
			// 
			this.ucLabel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.ucLabel5.Location = new System.Drawing.Point(0, 0);
			this.ucLabel5.Name = "ucLabel5";
			this.ucLabel5.Size = new System.Drawing.Size(484, 25);
			this.ucLabel5.TabIndex = 15;
			this.ucLabel5.Text = "This looks directly into the STENA booking portal";
			// 
			// frmStenaSailings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1064, 597);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.ucLabel5);
			this.Name = "frmStenaSailings";
			this.Text = "Stena Sailings";
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucLabel ucLabel5;
	}
}
