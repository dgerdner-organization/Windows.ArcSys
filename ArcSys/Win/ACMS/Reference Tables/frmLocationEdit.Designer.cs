namespace CS2010.ArcSys.Win
{
	partial class frmLocationEdit
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
			Janus.Windows.GridEX.GridEXLayout cmbLocationType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocationEdit));
			Janus.Windows.GridEX.GridEXLayout cmbGeoRegion_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtLocationCd = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.chkDeleted = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtLocationDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCountryCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCensusCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOther1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOther2 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCensusType = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCity = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.cmbLocationType = new CS2010.ArcSys.WinCtrls.ucLocationTypeCombo();
			this.ucLinkLabel1 = new CS2010.CommonWinCtrls.ucLinkLabel();
			this.linkCountries = new CS2010.CommonWinCtrls.ucLinkLabel();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtAVSSCensusCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAVSSCendusType = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAVSSPortName = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPortCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cmbGeoRegion = new CS2010.ArcSys.WinCtrls.ucGeoRegionCombo();
			this.cbxHold = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxCheckPoint = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxBorder = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxGate = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtConus = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtArcSysName = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucGroupBox3 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.ucLinkLabel2 = new CS2010.CommonWinCtrls.ucLinkLabel();
			this.ucLinkLabel3 = new CS2010.CommonWinCtrls.ucLinkLabel();
			this.ucLinkLabel4 = new CS2010.CommonWinCtrls.ucLinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.cmbLocationType)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			this.ucGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbGeoRegion)).BeginInit();
			this.ucGroupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtLocationCd
			// 
			this.txtLocationCd.LabelText = "Location Code";
			this.txtLocationCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLocationCd.LinkDisabledMessage = "Link Disabled";
			this.txtLocationCd.Location = new System.Drawing.Point(89, 16);
			this.txtLocationCd.Name = "txtLocationCd";
			this.txtLocationCd.Size = new System.Drawing.Size(103, 20);
			this.txtLocationCd.TabIndex = 1;
			this.txtLocationCd.TextChanged += new System.EventHandler(this.txtLocationCd_TextChanged);
			// 
			// chkDeleted
			// 
			this.chkDeleted.AutoSize = true;
			this.chkDeleted.Location = new System.Drawing.Point(79, 217);
			this.chkDeleted.Name = "chkDeleted";
			this.chkDeleted.Size = new System.Drawing.Size(69, 17);
			this.chkDeleted.TabIndex = 20;
			this.chkDeleted.Text = "Deleted?";
			this.chkDeleted.UseVisualStyleBackColor = true;
			this.chkDeleted.YN = "N";
			this.chkDeleted.CheckedChanged += new System.EventHandler(this.chkDeleted_CheckedChanged);
			// 
			// txtLocationDsc
			// 
			this.txtLocationDsc.LabelText = "Description";
			this.txtLocationDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLocationDsc.LinkDisabledMessage = "Link Disabled";
			this.txtLocationDsc.Location = new System.Drawing.Point(89, 38);
			this.txtLocationDsc.Name = "txtLocationDsc";
			this.txtLocationDsc.Size = new System.Drawing.Size(378, 20);
			this.txtLocationDsc.TabIndex = 3;
			this.txtLocationDsc.TextChanged += new System.EventHandler(this.txtLocationDsc_TextChanged);
			// 
			// txtCountryCd
			// 
			this.txtCountryCd.LabelText = "Country Code";
			this.txtCountryCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCountryCd.LinkDisabledMessage = "Link Disabled";
			this.txtCountryCd.Location = new System.Drawing.Point(89, 192);
			this.txtCountryCd.Name = "txtCountryCd";
			this.txtCountryCd.Size = new System.Drawing.Size(93, 20);
			this.txtCountryCd.TabIndex = 17;
			// 
			// txtCensusCd
			// 
			this.txtCensusCd.LabelText = "Census Code";
			this.txtCensusCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCensusCd.LinkDisabledMessage = "Link Disabled";
			this.txtCensusCd.Location = new System.Drawing.Point(89, 104);
			this.txtCensusCd.Name = "txtCensusCd";
			this.txtCensusCd.Size = new System.Drawing.Size(103, 20);
			this.txtCensusCd.TabIndex = 9;
			this.txtCensusCd.TextChanged += new System.EventHandler(this.txtCensusCd_TextChanged);
			this.txtCensusCd.Validated += new System.EventHandler(this.txtCensusCd_Validated);
			// 
			// txtOther1
			// 
			this.txtOther1.LabelText = "MilStamp";
			this.txtOther1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOther1.LinkDisabledMessage = "Link Disabled";
			this.txtOther1.Location = new System.Drawing.Point(89, 60);
			this.txtOther1.Name = "txtOther1";
			this.txtOther1.Size = new System.Drawing.Size(103, 20);
			this.txtOther1.TabIndex = 5;
			// 
			// txtOther2
			// 
			this.txtOther2.LabelText = "Other 2 Code";
			this.txtOther2.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOther2.LinkDisabledMessage = "Link Disabled";
			this.txtOther2.Location = new System.Drawing.Point(89, 82);
			this.txtOther2.Name = "txtOther2";
			this.txtOther2.Size = new System.Drawing.Size(103, 20);
			this.txtOther2.TabIndex = 7;
			// 
			// txtCensusType
			// 
			this.txtCensusType.LabelText = "Census Type";
			this.txtCensusType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCensusType.LinkDisabledMessage = "Link Disabled";
			this.txtCensusType.Location = new System.Drawing.Point(89, 126);
			this.txtCensusType.Name = "txtCensusType";
			this.txtCensusType.Size = new System.Drawing.Size(41, 20);
			this.txtCensusType.TabIndex = 11;
			this.txtCensusType.TextChanged += new System.EventHandler(this.txtCensusType_TextChanged);
			// 
			// txtState
			// 
			this.txtState.LabelText = "State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.LinkDisabledMessage = "Link Disabled";
			this.txtState.Location = new System.Drawing.Point(89, 170);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(93, 20);
			this.txtState.TabIndex = 15;
			// 
			// txtCity
			// 
			this.txtCity.LabelText = "City";
			this.txtCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCity.LinkDisabledMessage = "Link Disabled";
			this.txtCity.Location = new System.Drawing.Point(89, 148);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(200, 20);
			this.txtCity.TabIndex = 13;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(323, 519);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 30;
			this.btnOK.Text = "Save";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(404, 519);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// cmbLocationType
			// 
			this.cmbLocationType.CodeColumn = "Location_Type_Cd";
			this.cmbLocationType.DescriptionColumn = "Location_Type_Dsc";
			cmbLocationType_DesignTimeLayout.LayoutString = resources.GetString("cmbLocationType_DesignTimeLayout.LayoutString");
			this.cmbLocationType.DesignTimeLayout = cmbLocationType_DesignTimeLayout;
			this.cmbLocationType.DisplayMember = "Location_Type_Cd";
			this.cmbLocationType.LabelText = "Type";
			this.cmbLocationType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbLocationType.Location = new System.Drawing.Point(73, 16);
			this.cmbLocationType.Name = "cmbLocationType";
			this.cmbLocationType.SelectedIndex = -1;
			this.cmbLocationType.SelectedItem = null;
			this.cmbLocationType.Size = new System.Drawing.Size(93, 20);
			this.cmbLocationType.TabIndex = 19;
			this.cmbLocationType.ValueColumn = "Location_Type_Cd";
			this.cmbLocationType.ValueMember = "Location_Type_Cd";
			// 
			// ucLinkLabel1
			// 
			this.ucLinkLabel1.AutoSize = true;
			this.ucLinkLabel1.Location = new System.Drawing.Point(198, 61);
			this.ucLinkLabel1.Name = "ucLinkLabel1";
			this.ucLinkLabel1.Size = new System.Drawing.Size(160, 13);
			this.ucLinkLabel1.TabIndex = 32;
			this.ucLinkLabel1.TabStop = true;
			this.ucLinkLabel1.Text = "List of MilStamps for Water Ports";
			this.ucLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ucLinkLabel1_LinkClicked);
			// 
			// linkCountries
			// 
			this.linkCountries.AutoSize = true;
			this.linkCountries.Location = new System.Drawing.Point(190, 192);
			this.linkCountries.Name = "linkCountries";
			this.linkCountries.Size = new System.Drawing.Size(107, 13);
			this.linkCountries.TabIndex = 33;
			this.linkCountries.TabStop = true;
			this.linkCountries.Text = "List of Country Codes";
			this.linkCountries.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCountries_LinkClicked);
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.txtAVSSCensusCd);
			this.ucGroupBox1.Controls.Add(this.txtAVSSCendusType);
			this.ucGroupBox1.Controls.Add(this.txtAVSSPortName);
			this.ucGroupBox1.Controls.Add(this.txtPortCode);
			this.ucGroupBox1.Location = new System.Drawing.Point(10, 257);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(484, 124);
			this.ucGroupBox1.TabIndex = 34;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "AVSS Information (Only for Ports)";
			// 
			// txtAVSSCensusCd
			// 
			this.txtAVSSCensusCd.BackColor = System.Drawing.SystemColors.Control;
			this.txtAVSSCensusCd.ForeColor = System.Drawing.Color.Black;
			this.txtAVSSCensusCd.LabelText = "Census Code";
			this.txtAVSSCensusCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAVSSCensusCd.LinkDisabledMessage = "Link Disabled";
			this.txtAVSSCensusCd.Location = new System.Drawing.Point(73, 89);
			this.txtAVSSCensusCd.Name = "txtAVSSCensusCd";
			this.txtAVSSCensusCd.ReadOnly = true;
			this.txtAVSSCensusCd.Size = new System.Drawing.Size(100, 20);
			this.txtAVSSCensusCd.TabIndex = 3;
			this.txtAVSSCensusCd.TabStop = false;
			// 
			// txtAVSSCendusType
			// 
			this.txtAVSSCendusType.BackColor = System.Drawing.SystemColors.Control;
			this.txtAVSSCendusType.ForeColor = System.Drawing.Color.Black;
			this.txtAVSSCendusType.LabelText = "Census Type";
			this.txtAVSSCendusType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAVSSCendusType.LinkDisabledMessage = "Link Disabled";
			this.txtAVSSCendusType.Location = new System.Drawing.Point(73, 66);
			this.txtAVSSCendusType.Name = "txtAVSSCendusType";
			this.txtAVSSCendusType.ReadOnly = true;
			this.txtAVSSCendusType.Size = new System.Drawing.Size(41, 20);
			this.txtAVSSCendusType.TabIndex = 2;
			this.txtAVSSCendusType.TabStop = false;
			// 
			// txtAVSSPortName
			// 
			this.txtAVSSPortName.BackColor = System.Drawing.SystemColors.Control;
			this.txtAVSSPortName.ForeColor = System.Drawing.Color.Black;
			this.txtAVSSPortName.LabelText = "Port Name";
			this.txtAVSSPortName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAVSSPortName.LinkDisabledMessage = "Link Disabled";
			this.txtAVSSPortName.Location = new System.Drawing.Point(73, 43);
			this.txtAVSSPortName.Name = "txtAVSSPortName";
			this.txtAVSSPortName.ReadOnly = true;
			this.txtAVSSPortName.Size = new System.Drawing.Size(283, 20);
			this.txtAVSSPortName.TabIndex = 1;
			this.txtAVSSPortName.TabStop = false;
			// 
			// txtPortCode
			// 
			this.txtPortCode.BackColor = System.Drawing.SystemColors.Control;
			this.txtPortCode.ForeColor = System.Drawing.Color.Black;
			this.txtPortCode.LabelText = "Port Code";
			this.txtPortCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPortCode.LinkDisabledMessage = "Link Disabled";
			this.txtPortCode.Location = new System.Drawing.Point(73, 20);
			this.txtPortCode.Name = "txtPortCode";
			this.txtPortCode.ReadOnly = true;
			this.txtPortCode.Size = new System.Drawing.Size(100, 20);
			this.txtPortCode.TabIndex = 0;
			this.txtPortCode.TabStop = false;
			// 
			// ucGroupBox2
			// 
			this.ucGroupBox2.Controls.Add(this.cmbGeoRegion);
			this.ucGroupBox2.Controls.Add(this.cbxHold);
			this.ucGroupBox2.Controls.Add(this.cbxCheckPoint);
			this.ucGroupBox2.Controls.Add(this.cbxBorder);
			this.ucGroupBox2.Controls.Add(this.cbxGate);
			this.ucGroupBox2.Controls.Add(this.txtConus);
			this.ucGroupBox2.Controls.Add(this.cbxActive);
			this.ucGroupBox2.Controls.Add(this.txtArcSysName);
			this.ucGroupBox2.Controls.Add(this.cmbLocationType);
			this.ucGroupBox2.Location = new System.Drawing.Point(12, 388);
			this.ucGroupBox2.Name = "ucGroupBox2";
			this.ucGroupBox2.Size = new System.Drawing.Size(482, 125);
			this.ucGroupBox2.TabIndex = 35;
			this.ucGroupBox2.TabStop = false;
			this.ucGroupBox2.Text = "ArcSys Information";
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
			this.cmbGeoRegion.Location = new System.Drawing.Point(72, 85);
			this.cmbGeoRegion.Name = "cmbGeoRegion";
			this.cmbGeoRegion.SelectedIndex = -1;
			this.cmbGeoRegion.SelectedItem = null;
			this.cmbGeoRegion.Size = new System.Drawing.Size(156, 20);
			this.cmbGeoRegion.TabIndex = 37;
			this.cmbGeoRegion.ValueColumn = "Geo_Region_Cd";
			this.cmbGeoRegion.ValueMember = "Geo_Region_Cd";
			// 
			// cbxHold
			// 
			this.cbxHold.AutoSize = true;
			this.cbxHold.Location = new System.Drawing.Point(390, 65);
			this.cbxHold.Name = "cbxHold";
			this.cbxHold.Size = new System.Drawing.Size(87, 17);
			this.cbxHold.TabIndex = 26;
			this.cbxHold.Text = "Holding Area";
			this.cbxHold.UseVisualStyleBackColor = true;
			this.cbxHold.YN = "N";
			// 
			// cbxCheckPoint
			// 
			this.cbxCheckPoint.AutoSize = true;
			this.cbxCheckPoint.Location = new System.Drawing.Point(307, 64);
			this.cbxCheckPoint.Name = "cbxCheckPoint";
			this.cbxCheckPoint.Size = new System.Drawing.Size(81, 17);
			this.cbxCheckPoint.TabIndex = 25;
			this.cbxCheckPoint.Text = "CheckPoint";
			this.cbxCheckPoint.UseVisualStyleBackColor = true;
			this.cbxCheckPoint.YN = "N";
			// 
			// cbxBorder
			// 
			this.cbxBorder.AutoSize = true;
			this.cbxBorder.Location = new System.Drawing.Point(244, 65);
			this.cbxBorder.Name = "cbxBorder";
			this.cbxBorder.Size = new System.Drawing.Size(57, 17);
			this.cbxBorder.TabIndex = 24;
			this.cbxBorder.Text = "Border";
			this.cbxBorder.UseVisualStyleBackColor = true;
			this.cbxBorder.YN = "N";
			// 
			// cbxGate
			// 
			this.cbxGate.AutoSize = true;
			this.cbxGate.Location = new System.Drawing.Point(189, 64);
			this.cbxGate.Name = "cbxGate";
			this.cbxGate.Size = new System.Drawing.Size(49, 17);
			this.cbxGate.TabIndex = 23;
			this.cbxGate.Text = "Gate";
			this.cbxGate.UseVisualStyleBackColor = true;
			this.cbxGate.YN = "N";
			// 
			// txtConus
			// 
			this.txtConus.AutoSize = true;
			this.txtConus.Location = new System.Drawing.Point(136, 65);
			this.txtConus.Name = "txtConus";
			this.txtConus.Size = new System.Drawing.Size(56, 17);
			this.txtConus.TabIndex = 22;
			this.txtConus.Text = "Conus";
			this.txtConus.UseVisualStyleBackColor = true;
			this.txtConus.YN = "N";
			// 
			// cbxActive
			// 
			this.cbxActive.AutoSize = true;
			this.cbxActive.Location = new System.Drawing.Point(74, 64);
			this.cbxActive.Name = "cbxActive";
			this.cbxActive.Size = new System.Drawing.Size(56, 17);
			this.cbxActive.TabIndex = 21;
			this.cbxActive.Text = "Active";
			this.cbxActive.UseVisualStyleBackColor = true;
			this.cbxActive.YN = "N";
			// 
			// txtArcSysName
			// 
			this.txtArcSysName.BackColor = System.Drawing.SystemColors.Control;
			this.txtArcSysName.ForeColor = System.Drawing.Color.Black;
			this.txtArcSysName.LabelText = "Name";
			this.txtArcSysName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtArcSysName.LinkDisabledMessage = "Link Disabled";
			this.txtArcSysName.Location = new System.Drawing.Point(73, 39);
			this.txtArcSysName.Name = "txtArcSysName";
			this.txtArcSysName.ReadOnly = true;
			this.txtArcSysName.Size = new System.Drawing.Size(283, 20);
			this.txtArcSysName.TabIndex = 4;
			this.txtArcSysName.TabStop = false;
			// 
			// ucGroupBox3
			// 
			this.ucGroupBox3.Controls.Add(this.ucLinkLabel4);
			this.ucGroupBox3.Controls.Add(this.ucLinkLabel3);
			this.ucGroupBox3.Controls.Add(this.ucLinkLabel2);
			this.ucGroupBox3.Controls.Add(this.chkDeleted);
			this.ucGroupBox3.Location = new System.Drawing.Point(10, -2);
			this.ucGroupBox3.Name = "ucGroupBox3";
			this.ucGroupBox3.Size = new System.Drawing.Size(484, 253);
			this.ucGroupBox3.TabIndex = 36;
			this.ucGroupBox3.TabStop = false;
			this.ucGroupBox3.Text = "ACMS Information";
			// 
			// ucLinkLabel2
			// 
			this.ucLinkLabel2.AutoSize = true;
			this.ucLinkLabel2.Location = new System.Drawing.Point(182, 109);
			this.ucLinkLabel2.Name = "ucLinkLabel2";
			this.ucLinkLabel2.Size = new System.Drawing.Size(113, 13);
			this.ucLinkLabel2.TabIndex = 33;
			this.ucLinkLabel2.TabStop = true;
			this.ucLinkLabel2.Text = "Foreign Census Codes";
			this.ucLinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ucLinkLabel2_LinkClicked);
			// 
			// ucLinkLabel3
			// 
			this.ucLinkLabel3.AutoSize = true;
			this.ucLinkLabel3.Location = new System.Drawing.Point(181, 96);
			this.ucLinkLabel3.Name = "ucLinkLabel3";
			this.ucLinkLabel3.Size = new System.Drawing.Size(122, 13);
			this.ucLinkLabel3.TabIndex = 34;
			this.ucLinkLabel3.TabStop = true;
			this.ucLinkLabel3.Text = "Domestic Census Codes";
			this.ucLinkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ucLinkLabel3_LinkClicked);
			// 
			// ucLinkLabel4
			// 
			this.ucLinkLabel4.AutoSize = true;
			this.ucLinkLabel4.Location = new System.Drawing.Point(182, 122);
			this.ucLinkLabel4.Name = "ucLinkLabel4";
			this.ucLinkLabel4.Size = new System.Drawing.Size(89, 13);
			this.ucLinkLabel4.TabIndex = 35;
			this.ucLinkLabel4.TabStop = true;
			this.ucLinkLabel4.Text = "Zip Code Lookup";
			this.ucLinkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ucLinkLabel4_LinkClicked);
			// 
			// frmLocationEdit
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(520, 555);
			this.Controls.Add(this.ucGroupBox2);
			this.Controls.Add(this.ucGroupBox1);
			this.Controls.Add(this.linkCountries);
			this.Controls.Add(this.ucLinkLabel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtCensusType);
			this.Controls.Add(this.txtOther2);
			this.Controls.Add(this.txtOther1);
			this.Controls.Add(this.txtCensusCd);
			this.Controls.Add(this.txtCountryCd);
			this.Controls.Add(this.txtLocationDsc);
			this.Controls.Add(this.txtLocationCd);
			this.Controls.Add(this.ucGroupBox3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLocationEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add/Edit Location";
			this.Load += new System.EventHandler(this.frmLocationEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmbLocationType)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			this.ucGroupBox2.ResumeLayout(false);
			this.ucGroupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbGeoRegion)).EndInit();
			this.ucGroupBox3.ResumeLayout(false);
			this.ucGroupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBoxPK txtLocationCd;
		private CommonWinCtrls.ucCheckBox chkDeleted;
		private CommonWinCtrls.ucTextBox txtLocationDsc;
		private CommonWinCtrls.ucTextBox txtCountryCd;
		private CommonWinCtrls.ucTextBox txtCensusCd;
		private CommonWinCtrls.ucTextBox txtOther1;
		private CommonWinCtrls.ucTextBox txtOther2;
		private CommonWinCtrls.ucTextBox txtCensusType;
		private CommonWinCtrls.ucTextBox txtState;
		private CommonWinCtrls.ucTextBox txtCity;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private WinCtrls.ucLocationTypeCombo cmbLocationType;
		private CommonWinCtrls.ucLinkLabel ucLinkLabel1;
		private CommonWinCtrls.ucLinkLabel linkCountries;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucTextBox txtAVSSCensusCd;
		private CommonWinCtrls.ucTextBox txtAVSSCendusType;
		private CommonWinCtrls.ucTextBox txtAVSSPortName;
		private CommonWinCtrls.ucTextBox txtPortCode;
		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucGroupBox ucGroupBox3;
		private CommonWinCtrls.ucCheckBox cbxHold;
		private CommonWinCtrls.ucCheckBox cbxCheckPoint;
		private CommonWinCtrls.ucCheckBox cbxBorder;
		private CommonWinCtrls.ucCheckBox cbxGate;
		private CommonWinCtrls.ucCheckBox txtConus;
		private CommonWinCtrls.ucCheckBox cbxActive;
		private CommonWinCtrls.ucTextBox txtArcSysName;
		private WinCtrls.ucGeoRegionCombo cmbGeoRegion;
		private CommonWinCtrls.ucLinkLabel ucLinkLabel2;
		private CommonWinCtrls.ucLinkLabel ucLinkLabel3;
		private CommonWinCtrls.ucLinkLabel ucLinkLabel4;
	}
}