namespace CS2010.ArcSys.Win
{
	partial class frmEditLocation
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
			Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditLocation));
			Janus.Windows.GridEX.GridEXLayout cmbGeoRegion_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbLocationType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdLineLocs_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbNew = new System.Windows.Forms.ToolStripButton();
			this.tbbEdit = new System.Windows.Forms.ToolStripButton();
			this.tbbDelete = new System.Windows.Forms.ToolStripButton();
			this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbCancel = new System.Windows.Forms.ToolStripButton();
			this.tbbN3 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbExit = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlEditArea = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.cmbGeoRegion = new CS2010.ArcSys.WinCtrls.ucGeoRegionCombo();
			this.chkCheckpoint = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkHoldArea = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkBorder = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkGate = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnLineLookupCd = new CS2010.CommonWinCtrls.ucButton();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.chkConus = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnLineLookupDsc = new CS2010.CommonWinCtrls.ucButton();
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbLocationType = new CS2010.ArcSys.WinCtrls.ucLocationTypeCombo();
			this.chkActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grdLineLocs = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtCity = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.Country = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCensusCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMilStamp = new CS2010.CommonWinCtrls.ucTextBox();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlEditArea)).BeginInit();
			this.pnlEditArea.Panel1.SuspendLayout();
			this.pnlEditArea.Panel2.SuspendLayout();
			this.pnlEditArea.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbGeoRegion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocationType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLineLocs)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbRefresh,
            this.tbbN1,
            this.tbbNew,
            this.tbbEdit,
            this.tbbDelete,
            this.tbbN2,
            this.tbbSave,
            this.tbbCancel,
            this.tbbN3,
            this.tbbExit});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(814, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbRefresh.Name = "tbbRefresh";
			this.tbbRefresh.Size = new System.Drawing.Size(49, 22);
			this.tbbRefresh.Text = "&Refresh";
			this.tbbRefresh.Click += new System.EventHandler(this.tbbRefresh_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbNew
			// 
			this.tbbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbNew.Name = "tbbNew";
			this.tbbNew.Size = new System.Drawing.Size(32, 22);
			this.tbbNew.Text = "&New";
			this.tbbNew.Click += new System.EventHandler(this.tbbNew_Click);
			// 
			// tbbEdit
			// 
			this.tbbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbEdit.Name = "tbbEdit";
			this.tbbEdit.Size = new System.Drawing.Size(29, 22);
			this.tbbEdit.Text = "&Edit";
			this.tbbEdit.Click += new System.EventHandler(this.tbbEdit_Click);
			// 
			// tbbDelete
			// 
			this.tbbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbDelete.Name = "tbbDelete";
			this.tbbDelete.Size = new System.Drawing.Size(42, 22);
			this.tbbDelete.Text = "&Delete";
			this.tbbDelete.Click += new System.EventHandler(this.tbbDelete_Click);
			// 
			// tbbN2
			// 
			this.tbbN2.Name = "tbbN2";
			this.tbbN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(35, 22);
			this.tbbSave.Text = "&Save";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbCancel
			// 
			this.tbbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCancel.Name = "tbbCancel";
			this.tbbCancel.Size = new System.Drawing.Size(43, 22);
			this.tbbCancel.Text = "&Cancel";
			this.tbbCancel.Click += new System.EventHandler(this.tbbCancel_Click);
			// 
			// tbbN3
			// 
			this.tbbN3.Name = "tbbN3";
			this.tbbN3.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbExit
			// 
			this.tbbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbExit.Name = "tbbExit";
			this.tbbExit.Size = new System.Drawing.Size(29, 22);
			this.tbbExit.Text = "E&xit";
			this.tbbExit.Click += new System.EventHandler(this.tbbExit_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.grdResults);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.pnlEditArea);
			this.pnlMain.Size = new System.Drawing.Size(814, 681);
			this.pnlMain.SplitterDistance = 401;
			this.pnlMain.TabIndex = 1;
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
			this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
			this.grdResults.DisplayFieldChooser = true;
			this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResults.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this.grdResults.ExportFileID = null;
			this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdResults.GroupByBoxVisible = false;
			this.grdResults.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdResults.Location = new System.Drawing.Point(0, 0);
			this.grdResults.Name = "grdResults";
			this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdResults.Size = new System.Drawing.Size(814, 401);
			this.grdResults.TabIndex = 0;
			this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			// 
			// pnlEditArea
			// 
			this.pnlEditArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEditArea.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.pnlEditArea.Location = new System.Drawing.Point(0, 0);
			this.pnlEditArea.Name = "pnlEditArea";
			this.pnlEditArea.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlEditArea.Panel1
			// 
			this.pnlEditArea.Panel1.Controls.Add(this.ucGroupBox1);
			this.pnlEditArea.Panel1.Controls.Add(this.cmbGeoRegion);
			this.pnlEditArea.Panel1.Controls.Add(this.chkCheckpoint);
			this.pnlEditArea.Panel1.Controls.Add(this.chkHoldArea);
			this.pnlEditArea.Panel1.Controls.Add(this.chkBorder);
			this.pnlEditArea.Panel1.Controls.Add(this.chkGate);
			this.pnlEditArea.Panel1.Controls.Add(this.btnLineLookupCd);
			this.pnlEditArea.Panel1.Controls.Add(this.txtCode);
			this.pnlEditArea.Panel1.Controls.Add(this.chkConus);
			this.pnlEditArea.Panel1.Controls.Add(this.btnLineLookupDsc);
			this.pnlEditArea.Panel1.Controls.Add(this.txtDesc);
			this.pnlEditArea.Panel1.Controls.Add(this.cmbLocationType);
			this.pnlEditArea.Panel1.Controls.Add(this.chkActive);
			// 
			// pnlEditArea.Panel2
			// 
			this.pnlEditArea.Panel2.Controls.Add(this.grdLineLocs);
			this.pnlEditArea.Size = new System.Drawing.Size(814, 276);
			this.pnlEditArea.SplitterDistance = 138;
			this.pnlEditArea.TabIndex = 10;
			// 
			// cmbGeoRegion
			// 
			this.cmbGeoRegion.CodeColumn = "Geo_Region_Cd";
			this.cmbGeoRegion.DescriptionColumn = "Geo_Region_Dsc";
			cmbGeoRegion_DesignTimeLayout.LayoutString = resources.GetString("cmbGeoRegion_DesignTimeLayout.LayoutString");
			this.cmbGeoRegion.DesignTimeLayout = cmbGeoRegion_DesignTimeLayout;
			this.cmbGeoRegion.DisplayMember = "Geo_Region_Dsc";
			this.cmbGeoRegion.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbGeoRegion.LabelText = "Region";
			this.cmbGeoRegion.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbGeoRegion.Location = new System.Drawing.Point(261, 64);
			this.cmbGeoRegion.Name = "cmbGeoRegion";
			this.cmbGeoRegion.SelectedIndex = -1;
			this.cmbGeoRegion.SelectedItem = null;
			this.cmbGeoRegion.Size = new System.Drawing.Size(156, 20);
			this.cmbGeoRegion.TabIndex = 9;
			this.cmbGeoRegion.ValueColumn = "Geo_Region_Cd";
			this.cmbGeoRegion.ValueMember = "Geo_Region_Cd";
			// 
			// chkCheckpoint
			// 
			this.chkCheckpoint.AutoSize = true;
			this.chkCheckpoint.Location = new System.Drawing.Point(282, 90);
			this.chkCheckpoint.Name = "chkCheckpoint";
			this.chkCheckpoint.Size = new System.Drawing.Size(80, 17);
			this.chkCheckpoint.TabIndex = 12;
			this.chkCheckpoint.Text = "Chec&kpoint";
			this.chkCheckpoint.UseVisualStyleBackColor = true;
			this.chkCheckpoint.YN = "N";
			// 
			// chkHoldArea
			// 
			this.chkHoldArea.AutoSize = true;
			this.chkHoldArea.Location = new System.Drawing.Point(282, 113);
			this.chkHoldArea.Name = "chkHoldArea";
			this.chkHoldArea.Size = new System.Drawing.Size(73, 17);
			this.chkHoldArea.TabIndex = 15;
			this.chkHoldArea.Text = "&Hold Area";
			this.chkHoldArea.UseVisualStyleBackColor = true;
			this.chkHoldArea.YN = "N";
			// 
			// chkBorder
			// 
			this.chkBorder.AutoSize = true;
			this.chkBorder.Location = new System.Drawing.Point(193, 113);
			this.chkBorder.Name = "chkBorder";
			this.chkBorder.Size = new System.Drawing.Size(57, 17);
			this.chkBorder.TabIndex = 14;
			this.chkBorder.Text = "&Border";
			this.chkBorder.UseVisualStyleBackColor = true;
			this.chkBorder.YN = "N";
			// 
			// chkGate
			// 
			this.chkGate.AutoSize = true;
			this.chkGate.Location = new System.Drawing.Point(100, 113);
			this.chkGate.Name = "chkGate";
			this.chkGate.Size = new System.Drawing.Size(49, 17);
			this.chkGate.TabIndex = 13;
			this.chkGate.Text = "&Gate";
			this.chkGate.UseVisualStyleBackColor = true;
			this.chkGate.YN = "N";
			// 
			// btnLineLookupCd
			// 
			this.btnLineLookupCd.Location = new System.Drawing.Point(423, 10);
			this.btnLineLookupCd.Name = "btnLineLookupCd";
			this.btnLineLookupCd.Size = new System.Drawing.Size(24, 24);
			this.btnLineLookupCd.TabIndex = 2;
			this.btnLineLookupCd.Text = "...";
			this.btnLineLookupCd.UseVisualStyleBackColor = true;
			this.btnLineLookupCd.Click += new System.EventHandler(this.btnLineLookup_Click);
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "Location Code";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.LinkDisabledMessage = "Link Disabled";
			this.txtCode.Location = new System.Drawing.Point(100, 12);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(317, 20);
			this.txtCode.TabIndex = 1;
			// 
			// chkConus
			// 
			this.chkConus.AutoSize = true;
			this.chkConus.Location = new System.Drawing.Point(193, 90);
			this.chkConus.Name = "chkConus";
			this.chkConus.Size = new System.Drawing.Size(64, 17);
			this.chkConus.TabIndex = 11;
			this.chkConus.Text = "CON&US";
			this.chkConus.UseVisualStyleBackColor = true;
			this.chkConus.YN = "N";
			// 
			// btnLineLookupDsc
			// 
			this.btnLineLookupDsc.Location = new System.Drawing.Point(423, 36);
			this.btnLineLookupDsc.Name = "btnLineLookupDsc";
			this.btnLineLookupDsc.Size = new System.Drawing.Size(24, 24);
			this.btnLineLookupDsc.TabIndex = 5;
			this.btnLineLookupDsc.Text = "...";
			this.btnLineLookupDsc.UseVisualStyleBackColor = true;
			this.btnLineLookupDsc.Click += new System.EventHandler(this.btnLineLookup_Click);
			// 
			// txtDesc
			// 
			this.txtDesc.LabelText = "Description";
			this.txtDesc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDesc.LinkDisabledMessage = "Link Disabled";
			this.txtDesc.Location = new System.Drawing.Point(100, 38);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(317, 20);
			this.txtDesc.TabIndex = 4;
			// 
			// cmbLocationType
			// 
			this.cmbLocationType.CodeColumn = "Location_Type_Cd";
			this.cmbLocationType.DescriptionColumn = "Location_Type_Dsc";
			cmbLocationType_DesignTimeLayout.LayoutString = resources.GetString("cmbLocationType_DesignTimeLayout.LayoutString");
			this.cmbLocationType.DesignTimeLayout = cmbLocationType_DesignTimeLayout;
			this.cmbLocationType.DisplayMember = "Location_Type_Cd";
			this.cmbLocationType.LabelText = "Location Type";
			this.cmbLocationType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbLocationType.Location = new System.Drawing.Point(100, 64);
			this.cmbLocationType.Name = "cmbLocationType";
			this.cmbLocationType.SelectedIndex = -1;
			this.cmbLocationType.SelectedItem = null;
			this.cmbLocationType.Size = new System.Drawing.Size(112, 20);
			this.cmbLocationType.TabIndex = 7;
			this.cmbLocationType.ValueColumn = "Location_Type_Cd";
			this.cmbLocationType.ValueMember = "Location_Type_Cd";
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Location = new System.Drawing.Point(100, 90);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(56, 17);
			this.chkActive.TabIndex = 10;
			this.chkActive.Text = "Acti&ve";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.YN = "N";
			// 
			// grdLineLocs
			// 
			this.grdLineLocs.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdLineLocs_DesignTimeLayout.LayoutString = resources.GetString("grdLineLocs_DesignTimeLayout.LayoutString");
			this.grdLineLocs.DesignTimeLayout = grdLineLocs_DesignTimeLayout;
			this.grdLineLocs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdLineLocs.ExportFileID = null;
			this.grdLineLocs.GroupByBoxVisible = false;
			this.grdLineLocs.Location = new System.Drawing.Point(0, 0);
			this.grdLineLocs.Name = "grdLineLocs";
			this.grdLineLocs.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdLineLocs.Size = new System.Drawing.Size(814, 134);
			this.grdLineLocs.TabIndex = 0;
			this.grdLineLocs.DoubleClick += new System.EventHandler(this.grdLineLocs_DoubleClick);
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.txtMilStamp);
			this.ucGroupBox1.Controls.Add(this.txtCensusCd);
			this.ucGroupBox1.Controls.Add(this.Country);
			this.ucGroupBox1.Controls.Add(this.txtState);
			this.ucGroupBox1.Controls.Add(this.txtCity);
			this.ucGroupBox1.Location = new System.Drawing.Point(465, 6);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(337, 122);
			this.ucGroupBox1.TabIndex = 16;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "ACMS Information";
			// 
			// txtCity
			// 
			this.txtCity.LabelText = "City";
			this.txtCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCity.LinkDisabledMessage = "Link Disabled";
			this.txtCity.Location = new System.Drawing.Point(57, 16);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(196, 20);
			this.txtCity.TabIndex = 0;
			// 
			// txtState
			// 
			this.txtState.LabelText = "State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.LinkDisabledMessage = "Link Disabled";
			this.txtState.Location = new System.Drawing.Point(58, 39);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(75, 20);
			this.txtState.TabIndex = 1;
			// 
			// Country
			// 
			this.Country.LabelText = "Country";
			this.Country.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.Country.LinkDisabledMessage = "Link Disabled";
			this.Country.Location = new System.Drawing.Point(178, 39);
			this.Country.Name = "Country";
			this.Country.Size = new System.Drawing.Size(75, 20);
			this.Country.TabIndex = 2;
			// 
			// txtCensusCd
			// 
			this.txtCensusCd.LabelText = "Census";
			this.txtCensusCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCensusCd.LinkDisabledMessage = "Link Disabled";
			this.txtCensusCd.Location = new System.Drawing.Point(57, 63);
			this.txtCensusCd.Name = "txtCensusCd";
			this.txtCensusCd.Size = new System.Drawing.Size(75, 20);
			this.txtCensusCd.TabIndex = 3;
			// 
			// txtMilStamp
			// 
			this.txtMilStamp.LabelText = "MilStamp";
			this.txtMilStamp.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMilStamp.LinkDisabledMessage = "Link Disabled";
			this.txtMilStamp.Location = new System.Drawing.Point(57, 87);
			this.txtMilStamp.Name = "txtMilStamp";
			this.txtMilStamp.Size = new System.Drawing.Size(75, 20);
			this.txtMilStamp.TabIndex = 4;
			// 
			// frmEditLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 706);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmEditLocation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Location Maintenance";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceWindow_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceWindow_FormClosed);
			this.Load += new System.EventHandler(this.MaintenanceWindow_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceWindow_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.pnlEditArea.Panel1.ResumeLayout(false);
			this.pnlEditArea.Panel1.PerformLayout();
			this.pnlEditArea.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlEditArea)).EndInit();
			this.pnlEditArea.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbGeoRegion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocationType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLineLocs)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbRefresh;
		private System.Windows.Forms.ToolStripButton tbbNew;
		private System.Windows.Forms.ToolStripButton tbbEdit;
		private System.Windows.Forms.ToolStripButton tbbDelete;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripButton tbbCancel;
		private System.Windows.Forms.ToolStripSeparator tbbN3;
		private System.Windows.Forms.ToolStripButton tbbExit;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private CS2010.CommonWinCtrls.ucTextBox txtDesc;
		private CS2010.CommonWinCtrls.ucTextBoxPK txtCode;
		private CS2010.CommonWinCtrls.ucGridEx grdResults;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CommonWinCtrls.ucCheckBox chkActive;
		private WinCtrls.ucLocationTypeCombo cmbLocationType;
		private CommonWinCtrls.ucCheckBox chkConus;
		private CommonWinCtrls.ucButton btnLineLookupDsc;
		private CommonWinCtrls.ucGridEx grdLineLocs;
		private CommonWinCtrls.ucSplitContainer pnlEditArea;
		private CommonWinCtrls.ucButton btnLineLookupCd;
        private CommonWinCtrls.ucCheckBox chkHoldArea;
        private CommonWinCtrls.ucCheckBox chkBorder;
        private CommonWinCtrls.ucCheckBox chkGate;
		private CommonWinCtrls.ucCheckBox chkCheckpoint;
		private WinCtrls.ucGeoRegionCombo cmbGeoRegion;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucTextBox Country;
		private CommonWinCtrls.ucTextBox txtState;
		private CommonWinCtrls.ucTextBox txtCity;
		private CommonWinCtrls.ucTextBox txtMilStamp;
		private CommonWinCtrls.ucTextBox txtCensusCd;
	}
}