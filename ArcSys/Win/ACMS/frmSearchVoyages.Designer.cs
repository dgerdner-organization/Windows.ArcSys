namespace CS2010.ArcSys.Win
{
	partial class frmSearchVoyages
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
			Janus.Windows.GridEX.GridEXLayout grdVoyages_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchVoyages));
			Janus.Windows.GridEX.GridEXLayout grdDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlSearchParms = new CS2010.CommonWinCtrls.ucPanel();
			this.panelMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdVoyages = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlSearchParms.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
			this.panelMain.Panel1.SuspendLayout();
			this.panelMain.Panel2.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdVoyages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(242, 12);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(80, 12);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtVoyage.TabIndex = 2;
			// 
			// pnlSearchParms
			// 
			this.pnlSearchParms.Controls.Add(this.txtVoyage);
			this.pnlSearchParms.Controls.Add(this.btnSearch);
			this.pnlSearchParms.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearchParms.Location = new System.Drawing.Point(0, 0);
			this.pnlSearchParms.Name = "pnlSearchParms";
			this.pnlSearchParms.Size = new System.Drawing.Size(782, 47);
			this.pnlSearchParms.TabIndex = 3;
			// 
			// panelMain
			// 
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 47);
			this.panelMain.Name = "panelMain";
			this.panelMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// panelMain.Panel1
			// 
			this.panelMain.Panel1.Controls.Add(this.grdVoyages);
			// 
			// panelMain.Panel2
			// 
			this.panelMain.Panel2.Controls.Add(this.grdDetail);
			this.panelMain.Size = new System.Drawing.Size(782, 449);
			this.panelMain.SplitterDistance = 159;
			this.panelMain.TabIndex = 4;
			// 
			// grdVoyages
			// 
			this.grdVoyages.ColumnAutoResize = true;
			grdVoyages_DesignTimeLayout.LayoutString = resources.GetString("grdVoyages_DesignTimeLayout.LayoutString");
			this.grdVoyages.DesignTimeLayout = grdVoyages_DesignTimeLayout;
			this.grdVoyages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdVoyages.ExportFileID = null;
			this.grdVoyages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdVoyages.GroupByBoxVisible = false;
			this.grdVoyages.Location = new System.Drawing.Point(0, 0);
			this.grdVoyages.Name = "grdVoyages";
			this.grdVoyages.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdVoyages.Size = new System.Drawing.Size(782, 159);
			this.grdVoyages.TabIndex = 0;
			this.grdVoyages.SelectionChanged += new System.EventHandler(this.grdVoyages_SelectionChanged);
			this.grdVoyages.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdVoyages_LinkClicked);
			// 
			// grdDetail
			// 
			this.grdDetail.ColumnAutoResize = true;
			grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString");
			this.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout;
			this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDetail.ExportFileID = null;
			this.grdDetail.GroupByBoxVisible = false;
			this.grdDetail.Location = new System.Drawing.Point(0, 0);
			this.grdDetail.Name = "grdDetail";
			this.grdDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdDetail.Size = new System.Drawing.Size(782, 286);
			this.grdDetail.TabIndex = 0;
			// 
			// frmSearchVoyages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.pnlSearchParms);
			this.Name = "frmSearchVoyages";
			this.Text = "Search Voyages";
			this.pnlSearchParms.ResumeLayout(false);
			this.pnlSearchParms.PerformLayout();
			this.panelMain.Panel1.ResumeLayout(false);
			this.panelMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
			this.panelMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdVoyages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucPanel pnlSearchParms;
		private CommonWinCtrls.ucSplitContainer panelMain;
		private CommonWinCtrls.ucGridEx grdVoyages;
		private CommonWinCtrls.ucGridEx grdDetail;
	}
}
