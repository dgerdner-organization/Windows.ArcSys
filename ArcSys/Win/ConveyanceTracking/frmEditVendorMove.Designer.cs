namespace CS2010.ArcSys.Win
{
	partial class frmEditVendorMove
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
			Janus.Windows.GridEX.GridEXLayout cmbTradingPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditVendorMove));
			Janus.Windows.GridEX.GridEXLayout cmbOrigin_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbDest_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdAssigned_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdAvailable_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtMoveDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbTradingPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.pnlHeader = new CS2010.CommonWinCtrls.ucPanel();
			this.pnlVendorMove = new CS2010.CommonWinCtrls.ucPanel();
			this.txtAllocated = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.cmbOrigin = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
			this.txtFutile = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.btnSaveVendorMove = new CS2010.CommonWinCtrls.ucButton();
			this.cmbDest = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
			this.cmbVendor = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cbxVMActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtUsed = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
			this.tpVendorMove = new System.Windows.Forms.TabPage();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdAssigned = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsUnassignCargo = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.grdAvailable = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsAvailable = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsAssignCargo = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			((System.ComponentModel.ISupportInitialize)(this.cmbTradingPartner)).BeginInit();
			this.pnlHeader.SuspendLayout();
			this.pnlVendorMove.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
			this.tabMain.SuspendLayout();
			this.tpVendorMove.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAssigned)).BeginInit();
			this.ucGridToolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvailable)).BeginInit();
			this.tsAvailable.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtMoveDsc
			// 
			this.txtMoveDsc.BackColor = System.Drawing.SystemColors.Control;
			this.txtMoveDsc.ForeColor = System.Drawing.Color.Black;
			this.txtMoveDsc.LabelText = "Move Description";
			this.txtMoveDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMoveDsc.LinkDisabledMessage = "Link Disabled";
			this.txtMoveDsc.Location = new System.Drawing.Point(125, 10);
			this.txtMoveDsc.Name = "txtMoveDsc";
			this.txtMoveDsc.ReadOnly = true;
			this.txtMoveDsc.Size = new System.Drawing.Size(406, 20);
			this.txtMoveDsc.TabIndex = 0;
			this.txtMoveDsc.TabStop = false;
			// 
			// cmbTradingPartner
			// 
			this.cmbTradingPartner.BackColor = System.Drawing.SystemColors.Control;
			cmbTradingPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbTradingPartner_DesignTimeLayout.LayoutString");
			this.cmbTradingPartner.DesignTimeLayout = cmbTradingPartner_DesignTimeLayout;
			this.cmbTradingPartner.DisplayMember = "partner_dsc";
			this.cmbTradingPartner.ForeColor = System.Drawing.Color.Black;
			this.cmbTradingPartner.LabelText = "Customer";
			this.cmbTradingPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbTradingPartner.Location = new System.Drawing.Point(125, 33);
			this.cmbTradingPartner.Name = "cmbTradingPartner";
			this.cmbTradingPartner.ReadOnly = true;
			this.cmbTradingPartner.SelectedIndex = -1;
			this.cmbTradingPartner.SelectedItem = null;
			this.cmbTradingPartner.Size = new System.Drawing.Size(257, 20);
			this.cmbTradingPartner.TabIndex = 1;
			this.cmbTradingPartner.TabStop = false;
			this.cmbTradingPartner.ValueMember = "trading_partner_cd";
			// 
			// pnlHeader
			// 
			this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlHeader.Controls.Add(this.pnlVendorMove);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(776, 147);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlVendorMove
			// 
			this.pnlVendorMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlVendorMove.Controls.Add(this.cmbTradingPartner);
			this.pnlVendorMove.Controls.Add(this.txtMoveDsc);
			this.pnlVendorMove.Controls.Add(this.txtAllocated);
			this.pnlVendorMove.Controls.Add(this.cmbOrigin);
			this.pnlVendorMove.Controls.Add(this.txtFutile);
			this.pnlVendorMove.Controls.Add(this.btnSaveVendorMove);
			this.pnlVendorMove.Controls.Add(this.cmbDest);
			this.pnlVendorMove.Controls.Add(this.cmbVendor);
			this.pnlVendorMove.Controls.Add(this.cbxVMActive);
			this.pnlVendorMove.Controls.Add(this.txtUsed);
			this.pnlVendorMove.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlVendorMove.Location = new System.Drawing.Point(0, 0);
			this.pnlVendorMove.Name = "pnlVendorMove";
			this.pnlVendorMove.Size = new System.Drawing.Size(772, 133);
			this.pnlVendorMove.TabIndex = 0;
			// 
			// txtAllocated
			// 
			this.txtAllocated.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAllocated.DecimalDigits = 0;
			this.txtAllocated.LabelText = "Allocated";
			this.txtAllocated.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAllocated.Location = new System.Drawing.Point(388, 57);
			this.txtAllocated.Name = "txtAllocated";
			this.txtAllocated.Size = new System.Drawing.Size(67, 20);
			this.txtAllocated.TabIndex = 5;
			this.txtAllocated.Text = "0";
			this.txtAllocated.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtAllocated.Validated += new System.EventHandler(this.txtAllocated_Validated);
			// 
			// cmbOrigin
			// 
			this.cmbOrigin.CodeColumn = "Location_Cd";
			this.cmbOrigin.DescriptionColumn = "Location_Dsc";
			cmbOrigin_DesignTimeLayout.LayoutString = resources.GetString("cmbOrigin_DesignTimeLayout.LayoutString");
			this.cmbOrigin.DesignTimeLayout = cmbOrigin_DesignTimeLayout;
			this.cmbOrigin.DisplayMember = "Location_CdLocation_Dsc";
			this.cmbOrigin.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbOrigin.LabelText = "Origin";
			this.cmbOrigin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbOrigin.Location = new System.Drawing.Point(125, 79);
			this.cmbOrigin.Name = "cmbOrigin";
			this.cmbOrigin.SelectedIndex = -1;
			this.cmbOrigin.SelectedItem = null;
			this.cmbOrigin.Size = new System.Drawing.Size(204, 20);
			this.cmbOrigin.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbOrigin.TabIndex = 3;
			this.cmbOrigin.ValueColumn = "Location_Cd";
			this.cmbOrigin.ValueMember = "Location_Cd";
			this.cmbOrigin.Validated += new System.EventHandler(this.cmbOrigin_Validated);
			// 
			// txtFutile
			// 
			this.txtFutile.BackColor = System.Drawing.SystemColors.Control;
			this.txtFutile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFutile.DecimalDigits = 0;
			this.txtFutile.Enabled = false;
			this.txtFutile.ForeColor = System.Drawing.Color.Black;
			this.txtFutile.LabelText = "Futile";
			this.txtFutile.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFutile.Location = new System.Drawing.Point(388, 102);
			this.txtFutile.Name = "txtFutile";
			this.txtFutile.ReadOnly = true;
			this.txtFutile.Size = new System.Drawing.Size(67, 20);
			this.txtFutile.TabIndex = 7;
			this.txtFutile.TabStop = false;
			this.txtFutile.Text = "0";
			this.txtFutile.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// btnSaveVendorMove
			// 
			this.btnSaveVendorMove.Enabled = false;
			this.btnSaveVendorMove.Location = new System.Drawing.Point(470, 99);
			this.btnSaveVendorMove.Name = "btnSaveVendorMove";
			this.btnSaveVendorMove.Size = new System.Drawing.Size(75, 23);
			this.btnSaveVendorMove.TabIndex = 9;
			this.btnSaveVendorMove.Text = "Save";
			this.btnSaveVendorMove.UseVisualStyleBackColor = true;
			this.btnSaveVendorMove.Click += new System.EventHandler(this.btnSaveVendorMove_Click);
			// 
			// cmbDest
			// 
			this.cmbDest.CodeColumn = "Location_Cd";
			this.cmbDest.DescriptionColumn = "Location_Dsc";
			cmbDest_DesignTimeLayout.LayoutString = resources.GetString("cmbDest_DesignTimeLayout.LayoutString");
			this.cmbDest.DesignTimeLayout = cmbDest_DesignTimeLayout;
			this.cmbDest.DisplayMember = "Location_CdLocation_Dsc";
			this.cmbDest.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbDest.LabelText = "Destination";
			this.cmbDest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbDest.Location = new System.Drawing.Point(125, 101);
			this.cmbDest.Name = "cmbDest";
			this.cmbDest.SelectedIndex = -1;
			this.cmbDest.SelectedItem = null;
			this.cmbDest.Size = new System.Drawing.Size(204, 20);
			this.cmbDest.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbDest.TabIndex = 4;
			this.cmbDest.ValueColumn = "Location_Cd";
			this.cmbDest.ValueMember = "Location_Cd";
			this.cmbDest.Validated += new System.EventHandler(this.cmbDest_Validated);
			// 
			// cmbVendor
			// 
			cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
			this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
			this.cmbVendor.DisplayMember = "vendor_nm";
			this.cmbVendor.LabelText = "Vendor";
			this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendor.Location = new System.Drawing.Point(125, 56);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.SelectedIndex = -1;
			this.cmbVendor.SelectedItem = null;
			this.cmbVendor.Size = new System.Drawing.Size(204, 20);
			this.cmbVendor.TabIndex = 2;
			this.cmbVendor.ValueMember = "vendor_cd";
			this.cmbVendor.Validated += new System.EventHandler(this.cmbVendor_Validated);
			// 
			// cbxVMActive
			// 
			this.cbxVMActive.Checked = true;
			this.cbxVMActive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbxVMActive.Location = new System.Drawing.Point(464, 55);
			this.cbxVMActive.Name = "cbxVMActive";
			this.cbxVMActive.Size = new System.Drawing.Size(68, 24);
			this.cbxVMActive.TabIndex = 8;
			this.cbxVMActive.Text = "Active";
			this.cbxVMActive.UseVisualStyleBackColor = true;
			this.cbxVMActive.YN = "Y";
			this.cbxVMActive.CheckedChanged += new System.EventHandler(this.cbxVMActive_CheckedChanged);
			// 
			// txtUsed
			// 
			this.txtUsed.BackColor = System.Drawing.SystemColors.Control;
			this.txtUsed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUsed.DecimalDigits = 0;
			this.txtUsed.Enabled = false;
			this.txtUsed.ForeColor = System.Drawing.Color.Black;
			this.txtUsed.LabelText = "Used";
			this.txtUsed.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtUsed.Location = new System.Drawing.Point(388, 79);
			this.txtUsed.Name = "txtUsed";
			this.txtUsed.ReadOnly = true;
			this.txtUsed.Size = new System.Drawing.Size(67, 20);
			this.txtUsed.TabIndex = 6;
			this.txtUsed.TabStop = false;
			this.txtUsed.Text = "0";
			this.txtUsed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tpVendorMove);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 147);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(776, 442);
			this.tabMain.TabIndex = 4;
			// 
			// tpVendorMove
			// 
			this.tpVendorMove.Controls.Add(this.ucSplitContainer1);
			this.tpVendorMove.Location = new System.Drawing.Point(4, 22);
			this.tpVendorMove.Name = "tpVendorMove";
			this.tpVendorMove.Padding = new System.Windows.Forms.Padding(3);
			this.tpVendorMove.Size = new System.Drawing.Size(768, 416);
			this.tpVendorMove.TabIndex = 0;
			this.tpVendorMove.Text = "Vendor Moves";
			this.tpVendorMove.UseVisualStyleBackColor = true;
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitContainer1.Location = new System.Drawing.Point(3, 3);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.grdAssigned);
			this.ucSplitContainer1.Panel1.Controls.Add(this.ucGridToolStrip1);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdAvailable);
			this.ucSplitContainer1.Panel2.Controls.Add(this.tsAvailable);
			this.ucSplitContainer1.Size = new System.Drawing.Size(762, 410);
			this.ucSplitContainer1.SplitterDistance = 397;
			this.ucSplitContainer1.TabIndex = 3;
			// 
			// grdAssigned
			// 
			grdAssigned_DesignTimeLayout.LayoutString = resources.GetString("grdAssigned_DesignTimeLayout.LayoutString");
			this.grdAssigned.DesignTimeLayout = grdAssigned_DesignTimeLayout;
			this.grdAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAssigned.ExportFileID = null;
			this.grdAssigned.Location = new System.Drawing.Point(0, 25);
			this.grdAssigned.Name = "grdAssigned";
			this.grdAssigned.Size = new System.Drawing.Size(393, 381);
			this.grdAssigned.TabIndex = 1;
			this.grdAssigned.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// ucGridToolStrip1
			// 
			this.ucGridToolStrip1.GridObject = null;
			this.ucGridToolStrip1.HideAddButton = true;
			this.ucGridToolStrip1.HideDeleteButton = true;
			this.ucGridToolStrip1.HideEditButton = true;
			this.ucGridToolStrip1.HideExportMenu = true;
			this.ucGridToolStrip1.HidePrintMenu = true;
			this.ucGridToolStrip1.HideSeparator = true;
			this.ucGridToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUnassignCargo,
            this.toolStripLabel1});
			this.ucGridToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ucGridToolStrip1.Name = "ucGridToolStrip1";
			this.ucGridToolStrip1.Size = new System.Drawing.Size(393, 25);
			this.ucGridToolStrip1.TabIndex = 2;
			this.ucGridToolStrip1.Text = "ucGridToolStrip1";
			// 
			// tsUnassignCargo
			// 
			this.tsUnassignCargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsUnassignCargo.Image = ((System.Drawing.Image)(resources.GetObject("tsUnassignCargo.Image")));
			this.tsUnassignCargo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsUnassignCargo.Name = "tsUnassignCargo";
			this.tsUnassignCargo.Size = new System.Drawing.Size(54, 22);
			this.tsUnassignCargo.Text = "Unassign";
			this.tsUnassignCargo.Click += new System.EventHandler(this.tsUnassignCargo_Click);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(211, 22);
			this.toolStripLabel1.Text = "    Cargo Currently Assigned to Move";
			// 
			// grdAvailable
			// 
			grdAvailable_DesignTimeLayout.LayoutString = resources.GetString("grdAvailable_DesignTimeLayout.LayoutString");
			this.grdAvailable.DesignTimeLayout = grdAvailable_DesignTimeLayout;
			this.grdAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAvailable.ExportFileID = null;
			this.grdAvailable.Location = new System.Drawing.Point(0, 25);
			this.grdAvailable.Name = "grdAvailable";
			this.grdAvailable.Size = new System.Drawing.Size(357, 381);
			this.grdAvailable.TabIndex = 2;
			this.grdAvailable.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvailable.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// tsAvailable
			// 
			this.tsAvailable.GridObject = null;
			this.tsAvailable.HideAddButton = true;
			this.tsAvailable.HideDeleteButton = true;
			this.tsAvailable.HideEditButton = true;
			this.tsAvailable.HideExportMenu = true;
			this.tsAvailable.HidePrintMenu = true;
			this.tsAvailable.HideSeparator = true;
			this.tsAvailable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAssignCargo,
            this.toolStripLabel2});
			this.tsAvailable.Location = new System.Drawing.Point(0, 0);
			this.tsAvailable.Name = "tsAvailable";
			this.tsAvailable.Size = new System.Drawing.Size(357, 25);
			this.tsAvailable.TabIndex = 1;
			this.tsAvailable.Text = "ucGridToolStrip1";
			// 
			// tsAssignCargo
			// 
			this.tsAssignCargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsAssignCargo.Image = ((System.Drawing.Image)(resources.GetObject("tsAssignCargo.Image")));
			this.tsAssignCargo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsAssignCargo.Name = "tsAssignCargo";
			this.tsAssignCargo.Size = new System.Drawing.Size(42, 22);
			this.tsAssignCargo.Text = "Assign";
			this.tsAssignCargo.Click += new System.EventHandler(this.tsAssignCargo_Click);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(187, 22);
			this.toolStripLabel2.Text = "     Cargo Available for this Move";
			// 
			// frmEditVendorMove
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 589);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.pnlHeader);
			this.Name = "frmEditVendorMove";
			this.Text = "Moves";
			((System.ComponentModel.ISupportInitialize)(this.cmbTradingPartner)).EndInit();
			this.pnlHeader.ResumeLayout(false);
			this.pnlVendorMove.ResumeLayout(false);
			this.pnlVendorMove.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbDest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
			this.tabMain.ResumeLayout(false);
			this.tpVendorMove.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.PerformLayout();
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdAssigned)).EndInit();
			this.ucGridToolStrip1.ResumeLayout(false);
			this.ucGridToolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvailable)).EndInit();
			this.tsAvailable.ResumeLayout(false);
			this.tsAvailable.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtMoveDsc;
		private CommonWinCtrls.ucMultiColumnCombo cmbTradingPartner;
		private CommonWinCtrls.ucPanel pnlHeader;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tpVendorMove;
		private CommonWinCtrls.ucMultiColumnCombo cmbVendor;
		private CommonWinCtrls.ucNumericEditBox txtFutile;
		private CommonWinCtrls.ucNumericEditBox txtUsed;
		private CommonWinCtrls.ucNumericEditBox txtAllocated;
		private CommonWinCtrls.ucCheckBox cbxVMActive;
		private WinCtrls.ucLocationCombo cmbDest;
		private WinCtrls.ucLocationCombo cmbOrigin;
		private CommonWinCtrls.ucButton btnSaveVendorMove;
		private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CommonWinCtrls.ucGridEx grdAssigned;
		private CommonWinCtrls.ucGridToolStrip tsAvailable;
		private System.Windows.Forms.ToolStripButton tsAssignCargo;
		private CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
		private System.Windows.Forms.ToolStripButton tsUnassignCargo;
		private CommonWinCtrls.ucPanel pnlVendorMove;
		private CommonWinCtrls.ucGridEx grdAvailable;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	}
}