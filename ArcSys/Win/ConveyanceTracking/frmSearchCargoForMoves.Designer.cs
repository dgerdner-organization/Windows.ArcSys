namespace CS2010.ArcSys.Win
{
	partial class frmSearchCargoFormoves
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
			Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchCargoFormoves));
			Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.pnlHeader = new CS2010.CommonWinCtrls.ucPanel();
			this.cmbConus = new CS2010.CommonWinCtrls.ucComboBox();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsMain = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsAssignVendor = new System.Windows.Forms.ToolStripButton();
			this.numDays = new CS2010.CommonWinCtrls.ucNumericUpDown();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.ucLabel2 = new CS2010.CommonWinCtrls.ucLabel();
			this.pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			this.tsMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.ucLabel2);
			this.pnlHeader.Controls.Add(this.ucLabel1);
			this.pnlHeader.Controls.Add(this.numDays);
			this.pnlHeader.Controls.Add(this.cmbConus);
			this.pnlHeader.Controls.Add(this.btnSearch);
			this.pnlHeader.Controls.Add(this.cmbPartner);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(776, 67);
			this.pnlHeader.TabIndex = 0;
			// 
			// cmbConus
			// 
			this.cmbConus.FormattingEnabled = true;
			this.cmbConus.Items.AddRange(new object[] {
            "CONUS",
            "OCONUS"});
			this.cmbConus.Location = new System.Drawing.Point(64, 41);
			this.cmbConus.Name = "cmbConus";
			this.cmbConus.Size = new System.Drawing.Size(99, 21);
			this.cmbConus.TabIndex = 4;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(435, 14);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cmbPartner
			// 
			cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
			this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
			this.cmbPartner.DisplayMember = "partner_dsc";
			this.cmbPartner.ForeColor = System.Drawing.Color.Black;
			this.cmbPartner.LabelText = "Customer";
			this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPartner.Location = new System.Drawing.Point(64, 14);
			this.cmbPartner.Name = "cmbPartner";
			this.cmbPartner.SelectedIndex = -1;
			this.cmbPartner.SelectedItem = null;
			this.cmbPartner.Size = new System.Drawing.Size(257, 20);
			this.cmbPartner.TabIndex = 2;
			this.cmbPartner.ValueMember = "trading_partner_cd";
			// 
			// grdCargo
			// 
			grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
			this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
			this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCargo.ExportFileID = null;
			this.grdCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdCargo.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdCargo.Location = new System.Drawing.Point(0, 92);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.Size = new System.Drawing.Size(776, 497);
			this.grdCargo.TabIndex = 1;
			this.grdCargo.UseGroupRowSelector = true;
			this.grdCargo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
			// 
			// tsMain
			// 
			this.tsMain.GridObject = null;
			this.tsMain.HideAddButton = true;
			this.tsMain.HideDeleteButton = true;
			this.tsMain.HideEditButton = true;
			this.tsMain.HideExportMenu = true;
			this.tsMain.HidePrintMenu = true;
			this.tsMain.HideSeparator = true;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAssignVendor});
			this.tsMain.Location = new System.Drawing.Point(0, 67);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(776, 25);
			this.tsMain.TabIndex = 2;
			this.tsMain.Text = "ucGridToolStrip1";
			// 
			// tsAssignVendor
			// 
			this.tsAssignVendor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsAssignVendor.Image = ((System.Drawing.Image)(resources.GetObject("tsAssignVendor.Image")));
			this.tsAssignVendor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAssignVendor.Name = "tsAssignVendor";
			this.tsAssignVendor.Size = new System.Drawing.Size(79, 22);
			this.tsAssignVendor.Text = "Assign Vendor";
			this.tsAssignVendor.Click += new System.EventHandler(this.tsAssignVendor_Click);
			// 
			// numDays
			// 
			this.numDays.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numDays.Location = new System.Drawing.Point(277, 41);
			this.numDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numDays.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numDays.Name = "numDays";
			this.numDays.Size = new System.Drawing.Size(43, 20);
			this.numDays.TabIndex = 5;
			this.numDays.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(173, 45);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(99, 13);
			this.ucLabel1.TabIndex = 6;
			this.ucLabel1.Text = "Sail Date within last";
			// 
			// ucLabel2
			// 
			this.ucLabel2.Location = new System.Drawing.Point(321, 45);
			this.ucLabel2.Name = "ucLabel2";
			this.ucLabel2.Size = new System.Drawing.Size(29, 13);
			this.ucLabel2.TabIndex = 7;
			this.ucLabel2.Text = "days";
			// 
			// frmSearchCargoFormoves
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 589);
			this.Controls.Add(this.grdCargo);
			this.Controls.Add(this.tsMain);
			this.Controls.Add(this.pnlHeader);
			this.Name = "frmSearchCargoFormoves";
			this.Text = "Search Cargo for Vendor Assignment";
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlHeader;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucGridEx grdCargo;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucGridToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsAssignVendor;
		private CommonWinCtrls.ucComboBox cmbConus;
		private CommonWinCtrls.ucLabel ucLabel2;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucNumericUpDown numDays;

	}
}