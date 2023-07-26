namespace CS2010.ArcSys.Win
{
	partial class frmArriveDepart
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
			Janus.Windows.GridEX.GridEXLayout grdArriveDepart_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArriveDepart));
			Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdAD_ITV_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdAD_LINE_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tpArriveDepart = new System.Windows.Forms.TabPage();
			this.splitArriveDepart = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.splitArriveDepartTop = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdArriveDepart = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
			this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.ucLabel10 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucADToDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
			this.ucLabel9 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucLabel8 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucADFromDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
			this.ucLabel5 = new CS2010.CommonWinCtrls.ucLabel();
			this.tsArriveDepart = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsSearchArriveDepart = new System.Windows.Forms.ToolStripButton();
			this.grdAD_ITV = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucLabel11 = new CS2010.CommonWinCtrls.ucLabel();
			this.grdAD_LINE = new CS2010.CommonWinCtrls.ucGridEx();
			this.TabMain = new System.Windows.Forms.TabControl();
			this.tpArriveDepart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitArriveDepart)).BeginInit();
			this.splitArriveDepart.Panel1.SuspendLayout();
			this.splitArriveDepart.Panel2.SuspendLayout();
			this.splitArriveDepart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartTop)).BeginInit();
			this.splitArriveDepartTop.Panel1.SuspendLayout();
			this.splitArriveDepartTop.Panel2.SuspendLayout();
			this.splitArriveDepartTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdArriveDepart)).BeginInit();
			this.ucPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucADToDays)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ucADFromDays)).BeginInit();
			this.tsArriveDepart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAD_ITV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAD_LINE)).BeginInit();
			this.TabMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tpArriveDepart
			// 
			this.tpArriveDepart.Controls.Add(this.splitArriveDepart);
			this.tpArriveDepart.Location = new System.Drawing.Point(4, 22);
			this.tpArriveDepart.Name = "tpArriveDepart";
			this.tpArriveDepart.Padding = new System.Windows.Forms.Padding(3);
			this.tpArriveDepart.Size = new System.Drawing.Size(862, 424);
			this.tpArriveDepart.TabIndex = 9;
			this.tpArriveDepart.Text = "ArriveDepart";
			this.tpArriveDepart.UseVisualStyleBackColor = true;
			// 
			// splitArriveDepart
			// 
			this.splitArriveDepart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitArriveDepart.Location = new System.Drawing.Point(3, 3);
			this.splitArriveDepart.Name = "splitArriveDepart";
			this.splitArriveDepart.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitArriveDepart.Panel1
			// 
			this.splitArriveDepart.Panel1.Controls.Add(this.splitArriveDepartTop);
			// 
			// splitArriveDepart.Panel2
			// 
			this.splitArriveDepart.Panel2.Controls.Add(this.grdAD_LINE);
			this.splitArriveDepart.Size = new System.Drawing.Size(856, 418);
			this.splitArriveDepart.SplitterDistance = 237;
			this.splitArriveDepart.TabIndex = 3;
			// 
			// splitArriveDepartTop
			// 
			this.splitArriveDepartTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitArriveDepartTop.Location = new System.Drawing.Point(0, 0);
			this.splitArriveDepartTop.Name = "splitArriveDepartTop";
			// 
			// splitArriveDepartTop.Panel1
			// 
			this.splitArriveDepartTop.Panel1.Controls.Add(this.grdArriveDepart);
			this.splitArriveDepartTop.Panel1.Controls.Add(this.ucPanel2);
			this.splitArriveDepartTop.Panel1.Controls.Add(this.ucLabel5);
			this.splitArriveDepartTop.Panel1.Controls.Add(this.tsArriveDepart);
			// 
			// splitArriveDepartTop.Panel2
			// 
			this.splitArriveDepartTop.Panel2.Controls.Add(this.grdAD_ITV);
			this.splitArriveDepartTop.Panel2.Controls.Add(this.ucLabel11);
			this.splitArriveDepartTop.Size = new System.Drawing.Size(856, 237);
			this.splitArriveDepartTop.SplitterDistance = 491;
			this.splitArriveDepartTop.TabIndex = 3;
			// 
			// grdArriveDepart
			// 
			grdArriveDepart_DesignTimeLayout.LayoutString = resources.GetString("grdArriveDepart_DesignTimeLayout.LayoutString");
			this.grdArriveDepart.DesignTimeLayout = grdArriveDepart_DesignTimeLayout;
			this.grdArriveDepart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdArriveDepart.ExportFileID = null;
			this.grdArriveDepart.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdArriveDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdArriveDepart.GroupByBoxVisible = false;
			this.grdArriveDepart.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdArriveDepart.Location = new System.Drawing.Point(0, 67);
			this.grdArriveDepart.Name = "grdArriveDepart";
			this.grdArriveDepart.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdArriveDepart.Size = new System.Drawing.Size(491, 170);
			this.grdArriveDepart.TabIndex = 0;
			this.grdArriveDepart.SelectionChanged += new System.EventHandler(this.grdArriveDepart_SelectionChanged);
			// 
			// ucPanel2
			// 
			this.ucPanel2.Controls.Add(this.cmbPartner);
			this.ucPanel2.Controls.Add(this.ucLabel10);
			this.ucPanel2.Controls.Add(this.ucADToDays);
			this.ucPanel2.Controls.Add(this.ucLabel9);
			this.ucPanel2.Controls.Add(this.ucLabel8);
			this.ucPanel2.Controls.Add(this.ucADFromDays);
			this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel2.Location = new System.Drawing.Point(0, 43);
			this.ucPanel2.Name = "ucPanel2";
			this.ucPanel2.Size = new System.Drawing.Size(491, 24);
			this.ucPanel2.TabIndex = 3;
			// 
			// cmbPartner
			// 
			cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
			this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
			this.cmbPartner.DisplayMember = "partner_dsc";
			this.cmbPartner.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbPartner.LabelText = "Partner";
			this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPartner.Location = new System.Drawing.Point(338, 2);
			this.cmbPartner.Name = "cmbPartner";
			this.cmbPartner.SelectedIndex = -1;
			this.cmbPartner.SelectedItem = null;
			this.cmbPartner.Size = new System.Drawing.Size(140, 20);
			this.cmbPartner.TabIndex = 1;
			this.cmbPartner.ValueMember = "trading_partner_cd";
			// 
			// ucLabel10
			// 
			this.ucLabel10.Location = new System.Drawing.Point(181, 6);
			this.ucLabel10.Name = "ucLabel10";
			this.ucLabel10.Size = new System.Drawing.Size(88, 13);
			this.ucLabel10.TabIndex = 4;
			this.ucLabel10.Text = "days in the future";
			// 
			// ucADToDays
			// 
			this.ucADToDays.Location = new System.Drawing.Point(142, 2);
			this.ucADToDays.Name = "ucADToDays";
			this.ucADToDays.Size = new System.Drawing.Size(34, 20);
			this.ucADToDays.TabIndex = 3;
			this.ucADToDays.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// ucLabel9
			// 
			this.ucLabel9.Location = new System.Drawing.Point(73, 5);
			this.ucLabel9.Name = "ucLabel9";
			this.ucLabel9.Size = new System.Drawing.Size(62, 13);
			this.ucLabel9.TabIndex = 2;
			this.ucLabel9.Text = "days ago to";
			// 
			// ucLabel8
			// 
			this.ucLabel8.Location = new System.Drawing.Point(4, 6);
			this.ucLabel8.Name = "ucLabel8";
			this.ucLabel8.Size = new System.Drawing.Size(30, 13);
			this.ucLabel8.TabIndex = 1;
			this.ucLabel8.Text = "From";
			// 
			// ucADFromDays
			// 
			this.ucADFromDays.Location = new System.Drawing.Point(35, 2);
			this.ucADFromDays.Name = "ucADFromDays";
			this.ucADFromDays.Size = new System.Drawing.Size(35, 20);
			this.ucADFromDays.TabIndex = 0;
			this.ucADFromDays.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
			// 
			// ucLabel5
			// 
			this.ucLabel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel5.Location = new System.Drawing.Point(0, 25);
			this.ucLabel5.Name = "ucLabel5";
			this.ucLabel5.Size = new System.Drawing.Size(356, 18);
			this.ucLabel5.TabIndex = 2;
			this.ucLabel5.Text = "List of Recent and Upcoming Departures and Arrivals";
			// 
			// tsArriveDepart
			// 
			this.tsArriveDepart.GridObject = this.grdArriveDepart;
			this.tsArriveDepart.HideAddButton = true;
			this.tsArriveDepart.HideDeleteButton = true;
			this.tsArriveDepart.HideEditButton = true;
			this.tsArriveDepart.HideExportMenu = true;
			this.tsArriveDepart.HidePrintMenu = true;
			this.tsArriveDepart.HideSeparator = true;
			this.tsArriveDepart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearchArriveDepart});
			this.tsArriveDepart.Location = new System.Drawing.Point(0, 0);
			this.tsArriveDepart.Name = "tsArriveDepart";
			this.tsArriveDepart.Size = new System.Drawing.Size(491, 25);
			this.tsArriveDepart.TabIndex = 1;
			this.tsArriveDepart.Text = "ucGridToolStrip5";
			// 
			// tsSearchArriveDepart
			// 
			this.tsSearchArriveDepart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsSearchArriveDepart.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchArriveDepart.Image")));
			this.tsSearchArriveDepart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSearchArriveDepart.Name = "tsSearchArriveDepart";
			this.tsSearchArriveDepart.Size = new System.Drawing.Size(44, 22);
			this.tsSearchArriveDepart.Text = "Search";
			this.tsSearchArriveDepart.Click += new System.EventHandler(this.tsSearchArriveDepart_Click);
			// 
			// grdAD_ITV
			// 
			grdAD_ITV_DesignTimeLayout.LayoutString = resources.GetString("grdAD_ITV_DesignTimeLayout.LayoutString");
			this.grdAD_ITV.DesignTimeLayout = grdAD_ITV_DesignTimeLayout;
			this.grdAD_ITV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAD_ITV.ExportFileID = null;
			this.grdAD_ITV.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdAD_ITV.Location = new System.Drawing.Point(0, 18);
			this.grdAD_ITV.Name = "grdAD_ITV";
			this.grdAD_ITV.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdAD_ITV.Size = new System.Drawing.Size(361, 219);
			this.grdAD_ITV.TabIndex = 0;
			this.grdAD_ITV.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAD_ITV.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// ucLabel11
			// 
			this.ucLabel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel11.Location = new System.Drawing.Point(0, 0);
			this.ucLabel11.Name = "ucLabel11";
			this.ucLabel11.Size = new System.Drawing.Size(63, 18);
			this.ucLabel11.TabIndex = 1;
			this.ucLabel11.Text = "ITV Sent";
			// 
			// grdAD_LINE
			// 
			grdAD_LINE_DesignTimeLayout.LayoutString = resources.GetString("grdAD_LINE_DesignTimeLayout.LayoutString");
			this.grdAD_LINE.DesignTimeLayout = grdAD_LINE_DesignTimeLayout;
			this.grdAD_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAD_LINE.ExportFileID = null;
			this.grdAD_LINE.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdAD_LINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdAD_LINE.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdAD_LINE.Location = new System.Drawing.Point(0, 0);
			this.grdAD_LINE.Name = "grdAD_LINE";
			this.grdAD_LINE.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdAD_LINE.Size = new System.Drawing.Size(856, 177);
			this.grdAD_LINE.TabIndex = 0;
			this.grdAD_LINE.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAD_LINE.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// TabMain
			// 
			this.TabMain.Controls.Add(this.tpArriveDepart);
			this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabMain.Location = new System.Drawing.Point(0, 0);
			this.TabMain.Name = "TabMain";
			this.TabMain.SelectedIndex = 0;
			this.TabMain.Size = new System.Drawing.Size(870, 450);
			this.TabMain.TabIndex = 2;
			// 
			// frmArriveDepart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 450);
			this.Controls.Add(this.TabMain);
			this.Name = "frmArriveDepart";
			this.Text = "Arrive and Depart Summary";
			this.tpArriveDepart.ResumeLayout(false);
			this.splitArriveDepart.Panel1.ResumeLayout(false);
			this.splitArriveDepart.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitArriveDepart)).EndInit();
			this.splitArriveDepart.ResumeLayout(false);
			this.splitArriveDepartTop.Panel1.ResumeLayout(false);
			this.splitArriveDepartTop.Panel1.PerformLayout();
			this.splitArriveDepartTop.Panel2.ResumeLayout(false);
			this.splitArriveDepartTop.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitArriveDepartTop)).EndInit();
			this.splitArriveDepartTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdArriveDepart)).EndInit();
			this.ucPanel2.ResumeLayout(false);
			this.ucPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ucADToDays)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ucADFromDays)).EndInit();
			this.tsArriveDepart.ResumeLayout(false);
			this.tsArriveDepart.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAD_ITV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAD_LINE)).EndInit();
			this.TabMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tpArriveDepart;
		private System.Windows.Forms.TabControl TabMain;
		private CommonWinCtrls.ucSplitContainer splitArriveDepart;
		private CommonWinCtrls.ucSplitContainer splitArriveDepartTop;
		private CommonWinCtrls.ucGridEx grdArriveDepart;
		private CommonWinCtrls.ucPanel ucPanel2;
		private CommonWinCtrls.ucLabel ucLabel10;
		private CommonWinCtrls.ucNumericUpDown ucADToDays;
		private CommonWinCtrls.ucLabel ucLabel9;
		private CommonWinCtrls.ucLabel ucLabel8;
		private CommonWinCtrls.ucNumericUpDown ucADFromDays;
		private CommonWinCtrls.ucLabel ucLabel5;
		private CommonWinCtrls.ucGridToolStrip tsArriveDepart;
		private System.Windows.Forms.ToolStripButton tsSearchArriveDepart;
		private CommonWinCtrls.ucGridEx grdAD_ITV;
		private CommonWinCtrls.ucLabel ucLabel11;
		private CommonWinCtrls.ucGridEx grdAD_LINE;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;


	}
}