namespace CS2010.ArcSys.Win
{
	partial class frmRDDMissed
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRDDMissed));
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.SuspendLayout();
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.Location = new System.Drawing.Point(0, 0);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(782, 496);
			this.grdMain.TabIndex = 0;
			this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
			// 
			// frmRDDMissed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdMain);
			this.Name = "frmRDDMissed";
			this.Text = "Missed RDD Report";
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdMain;
	}
}
