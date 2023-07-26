namespace CS2010.ArcSys.Win
{
	partial class frmCreateEstimateOptions
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
			Janus.Windows.GridEX.GridEXLayout cmbActDest_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateEstimateOptions));
			Janus.Windows.GridEX.GridEXLayout cmbActOrig_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbMoveType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnClear = new CS2010.CommonWinCtrls.ucButton();
			this.chkShowAllMoveTypes = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grpSailDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.chkNonBillPay = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnDefaults = new CS2010.CommonWinCtrls.ucButton();
			this.cmbActDest = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbActOrig = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbMoveType = new CS2010.ArcSys.WinCtrls.ucMoveTypeCheckBoxCombo();
			this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCheckBoxCombo();
			this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.chkIncludeBlankTCN = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkIncludeTransFinal = new CS2010.CommonWinCtrls.ucCheckBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(341, 12);
			this.btnOK.TabIndex = 40;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(341, 42);
			this.btnCancel.TabIndex = 41;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(341, 132);
			this.btnApply.TabIndex = 44;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtPCFN
			// 
			this.txtPCFN.LabelText = "&PCFN";
			this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPCFN.LinkDisabledMessage = "Link Disabled";
			this.txtPCFN.Location = new System.Drawing.Point(68, 12);
			this.txtPCFN.Name = "txtPCFN";
			this.txtPCFN.Size = new System.Drawing.Size(249, 20);
			this.txtPCFN.TabIndex = 1;
			// 
			// txtBooking
			// 
			this.txtBooking.LabelText = "&Booking";
			this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBooking.LinkDisabledMessage = "Link Disabled";
			this.txtBooking.Location = new System.Drawing.Point(68, 40);
			this.txtBooking.Name = "txtBooking";
			this.txtBooking.Size = new System.Drawing.Size(249, 20);
			this.txtBooking.TabIndex = 3;
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "&Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(68, 96);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(249, 20);
			this.txtVoyage.TabIndex = 7;
			// 
			// txtSerialNo
			// 
			this.txtSerialNo.LabelText = "Serial &No";
			this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
			this.txtSerialNo.Location = new System.Drawing.Point(68, 236);
			this.txtSerialNo.Name = "txtSerialNo";
			this.txtSerialNo.Size = new System.Drawing.Size(249, 20);
			this.txtSerialNo.TabIndex = 17;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(341, 72);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 42;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// chkShowAllMoveTypes
			// 
			this.chkShowAllMoveTypes.AutoSize = true;
			this.chkShowAllMoveTypes.Location = new System.Drawing.Point(324, 266);
			this.chkShowAllMoveTypes.Name = "chkShowAllMoveTypes";
			this.chkShowAllMoveTypes.Size = new System.Drawing.Size(91, 17);
			this.chkShowAllMoveTypes.TabIndex = 20;
			this.chkShowAllMoveTypes.Text = "Include F1-F4";
			this.chkShowAllMoveTypes.UseVisualStyleBackColor = true;
			this.chkShowAllMoveTypes.YN = "N";
			// 
			// grpSailDt
			// 
			this.grpSailDt.CheckBoxText = "Sail Date";
			this.grpSailDt.DateFormatDefault = "MM-dd-yyyy";
			this.grpSailDt.DateFormatEdit = "MMddyy";
			this.grpSailDt.Location = new System.Drawing.Point(68, 346);
			this.grpSailDt.Name = "grpSailDt";
			this.grpSailDt.Size = new System.Drawing.Size(129, 76);
			this.grpSailDt.TabIndex = 25;
			// 
			// chkNonBillPay
			// 
			this.chkNonBillPay.AutoSize = true;
			this.chkNonBillPay.Location = new System.Drawing.Point(68, 428);
			this.chkNonBillPay.Name = "chkNonBillPay";
			this.chkNonBillPay.Size = new System.Drawing.Size(163, 17);
			this.chkNonBillPay.TabIndex = 26;
			this.chkNonBillPay.Text = "Include Non-Billable/Payable";
			this.chkNonBillPay.UseVisualStyleBackColor = true;
			this.chkNonBillPay.YN = "N";
			// 
			// btnDefaults
			// 
			this.btnDefaults.Location = new System.Drawing.Point(341, 102);
			this.btnDefaults.Name = "btnDefaults";
			this.btnDefaults.Size = new System.Drawing.Size(75, 23);
			this.btnDefaults.TabIndex = 43;
			this.btnDefaults.Text = "Default";
			this.btnDefaults.UseVisualStyleBackColor = true;
			this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
			// 
			// cmbActDest
			// 
			this.cmbActDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbActDest.CodeColumn = "Location_Cd";
			this.cmbActDest.DescriptionColumn = "Location_Dsc";
			cmbActDest_DesignTimeLayout.LayoutString = resources.GetString("cmbActDest_DesignTimeLayout.LayoutString");
			this.cmbActDest.DesignTimeLayout = cmbActDest_DesignTimeLayout;
			this.cmbActDest.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbActDest.DropDownButtonsVisible = false;
			this.cmbActDest.DropDownDisplayMember = "Location_Cd";
			this.cmbActDest.DropDownValueMember = "Location_Cd";
			this.cmbActDest.LabelText = "Move Dest";
			this.cmbActDest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbActDest.Location = new System.Drawing.Point(68, 320);
			this.cmbActDest.Name = "cmbActDest";
			this.cmbActDest.SaveSettings = false;
			this.cmbActDest.Size = new System.Drawing.Size(249, 20);
			this.cmbActDest.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbActDest.TabIndex = 24;
			this.cmbActDest.ValueColumn = "Location_Cd";
			this.cmbActDest.ValuesDataMember = null;
			// 
			// cmbActOrig
			// 
			this.cmbActOrig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbActOrig.CodeColumn = "Location_Cd";
			this.cmbActOrig.DescriptionColumn = "Location_Dsc";
			cmbActOrig_DesignTimeLayout.LayoutString = resources.GetString("cmbActOrig_DesignTimeLayout.LayoutString");
			this.cmbActOrig.DesignTimeLayout = cmbActOrig_DesignTimeLayout;
			this.cmbActOrig.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbActOrig.DropDownButtonsVisible = false;
			this.cmbActOrig.DropDownDisplayMember = "Location_Cd";
			this.cmbActOrig.DropDownValueMember = "Location_Cd";
			this.cmbActOrig.LabelText = "Move Ori&g";
			this.cmbActOrig.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbActOrig.Location = new System.Drawing.Point(68, 292);
			this.cmbActOrig.Name = "cmbActOrig";
			this.cmbActOrig.SaveSettings = false;
			this.cmbActOrig.Size = new System.Drawing.Size(249, 20);
			this.cmbActOrig.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbActOrig.TabIndex = 22;
			this.cmbActOrig.ValueColumn = "Location_Cd";
			this.cmbActOrig.ValuesDataMember = null;
			// 
			// cmbMoveType
			// 
			this.cmbMoveType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbMoveType.CodeColumn = "Code";
			this.cmbMoveType.DescriptionColumn = "Description";
			cmbMoveType_DesignTimeLayout.LayoutString = resources.GetString("cmbMoveType_DesignTimeLayout.LayoutString");
			this.cmbMoveType.DesignTimeLayout = cmbMoveType_DesignTimeLayout;
			this.cmbMoveType.DropDownButtonsVisible = false;
			this.cmbMoveType.DropDownDataSource = new CS2010.Common.ComboItem[] {
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource1"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource2"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource3"))),
        ((CS2010.Common.ComboItem)(resources.GetObject("cmbMoveType.DropDownDataSource4")))};
			this.cmbMoveType.DropDownDisplayMember = "Code";
			this.cmbMoveType.DropDownValueMember = "Code";
			this.cmbMoveType.LabelText = "&Move Type";
			this.cmbMoveType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMoveType.Location = new System.Drawing.Point(68, 264);
			this.cmbMoveType.Name = "cmbMoveType";
			this.cmbMoveType.SaveSettings = false;
			this.cmbMoveType.Size = new System.Drawing.Size(249, 20);
			this.cmbMoveType.TabIndex = 19;
			this.cmbMoveType.ValueColumn = "Code";
			// 
			// cmbVessel
			// 
			this.cmbVessel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbVessel.CodeColumn = "Vessel_Cd";
			this.cmbVessel.DescriptionColumn = "Vessel_Nm";
			cmbVessel_DesignTimeLayout.LayoutString = resources.GetString("cmbVessel_DesignTimeLayout.LayoutString");
			this.cmbVessel.DesignTimeLayout = cmbVessel_DesignTimeLayout;
			this.cmbVessel.DropDownButtonsVisible = false;
			this.cmbVessel.DropDownDisplayMember = "Vessel_Cd";
			this.cmbVessel.DropDownValueMember = "Vessel_Cd";
			this.cmbVessel.LabelText = "Ve&ssel";
			this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVessel.Location = new System.Drawing.Point(68, 68);
			this.cmbVessel.Name = "cmbVessel";
			this.cmbVessel.SaveSettings = false;
			this.cmbVessel.Size = new System.Drawing.Size(249, 20);
			this.cmbVessel.TabIndex = 5;
			this.cmbVessel.ValueColumn = "Vessel_Cd";
			// 
			// cmbPLOD
			// 
			this.cmbPLOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPLOD.CodeColumn = "Location_Cd";
			this.cmbPLOD.DescriptionColumn = "Location_Dsc";
			cmbPLOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOD_DesignTimeLayout.LayoutString");
			this.cmbPLOD.DesignTimeLayout = cmbPLOD_DesignTimeLayout;
			this.cmbPLOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPLOD.DropDownButtonsVisible = false;
			this.cmbPLOD.DropDownDisplayMember = "Location_Cd";
			this.cmbPLOD.DropDownValueMember = "Location_Cd";
			this.cmbPLOD.LabelText = "PL&OD";
			this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPLOD.Location = new System.Drawing.Point(68, 208);
			this.cmbPLOD.Name = "cmbPLOD";
			this.cmbPLOD.SaveSettings = false;
			this.cmbPLOD.Size = new System.Drawing.Size(249, 20);
			this.cmbPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPLOD.TabIndex = 15;
			this.cmbPLOD.ValueColumn = "Location_Cd";
			this.cmbPLOD.ValuesDataMember = null;
			// 
			// cmbPOD
			// 
			this.cmbPOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOD.CodeColumn = "Location_Cd";
			this.cmbPOD.DescriptionColumn = "Location_Dsc";
			cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
			this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
			this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOD.DropDownButtonsVisible = false;
			this.cmbPOD.DropDownDisplayMember = "Location_Cd";
			this.cmbPOD.DropDownValueMember = "Location_Cd";
			this.cmbPOD.LabelText = "PO&D";
			this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOD.Location = new System.Drawing.Point(68, 180);
			this.cmbPOD.Name = "cmbPOD";
			this.cmbPOD.SaveSettings = false;
			this.cmbPOD.Size = new System.Drawing.Size(249, 20);
			this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOD.TabIndex = 13;
			this.cmbPOD.ValueColumn = "Location_Cd";
			this.cmbPOD.ValuesDataMember = null;
			// 
			// cmbPOL
			// 
			this.cmbPOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOL.CodeColumn = "Location_Cd";
			this.cmbPOL.DescriptionColumn = "Location_Dsc";
			cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
			this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
			this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOL.DropDownButtonsVisible = false;
			this.cmbPOL.DropDownDisplayMember = "Location_Cd";
			this.cmbPOL.DropDownValueMember = "Location_Cd";
			this.cmbPOL.LabelText = "PO&L";
			this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOL.Location = new System.Drawing.Point(68, 152);
			this.cmbPOL.Name = "cmbPOL";
			this.cmbPOL.SaveSettings = false;
			this.cmbPOL.Size = new System.Drawing.Size(249, 20);
			this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOL.TabIndex = 11;
			this.cmbPOL.ValueColumn = "Location_Cd";
			this.cmbPOL.ValuesDataMember = null;
			// 
			// cmbPLOR
			// 
			this.cmbPLOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPLOR.CodeColumn = "Location_Cd";
			this.cmbPLOR.DescriptionColumn = "Location_Dsc";
			cmbPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOR_DesignTimeLayout.LayoutString");
			this.cmbPLOR.DesignTimeLayout = cmbPLOR_DesignTimeLayout;
			this.cmbPLOR.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPLOR.DropDownButtonsVisible = false;
			this.cmbPLOR.DropDownDisplayMember = "Location_Cd";
			this.cmbPLOR.DropDownValueMember = "Location_Cd";
			this.cmbPLOR.LabelText = "PLO&R";
			this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPLOR.Location = new System.Drawing.Point(68, 124);
			this.cmbPLOR.Name = "cmbPLOR";
			this.cmbPLOR.SaveSettings = false;
			this.cmbPLOR.Size = new System.Drawing.Size(249, 20);
			this.cmbPLOR.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPLOR.TabIndex = 9;
			this.cmbPLOR.ValueColumn = "Location_Cd";
			this.cmbPLOR.ValuesDataMember = null;
			// 
			// chkIncludeBlankTCN
			// 
			this.chkIncludeBlankTCN.AutoSize = true;
			this.chkIncludeBlankTCN.Location = new System.Drawing.Point(68, 474);
			this.chkIncludeBlankTCN.Name = "chkIncludeBlankTCN";
			this.chkIncludeBlankTCN.Size = new System.Drawing.Size(165, 17);
			this.chkIncludeBlankTCN.TabIndex = 28;
			this.chkIncludeBlankTCN.Text = "Include Blank Serial Numbers";
			this.chkIncludeBlankTCN.UseVisualStyleBackColor = true;
			this.chkIncludeBlankTCN.YN = "N";
			// 
			// chkIncludeTransFinal
			// 
			this.chkIncludeTransFinal.AutoSize = true;
			this.chkIncludeTransFinal.Location = new System.Drawing.Point(68, 451);
			this.chkIncludeTransFinal.Name = "chkIncludeTransFinal";
			this.chkIncludeTransFinal.Size = new System.Drawing.Size(156, 17);
			this.chkIncludeTransFinal.TabIndex = 27;
			this.chkIncludeTransFinal.Text = "Include TransShipment Leg";
			this.chkIncludeTransFinal.UseVisualStyleBackColor = true;
			this.chkIncludeTransFinal.YN = "N";
			// 
			// frmCreateEstimateOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 499);
			this.Controls.Add(this.chkIncludeTransFinal);
			this.Controls.Add(this.chkIncludeBlankTCN);
			this.Controls.Add(this.btnDefaults);
			this.Controls.Add(this.chkNonBillPay);
			this.Controls.Add(this.grpSailDt);
			this.Controls.Add(this.chkShowAllMoveTypes);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.cmbActDest);
			this.Controls.Add(this.cmbActOrig);
			this.Controls.Add(this.txtSerialNo);
			this.Controls.Add(this.cmbMoveType);
			this.Controls.Add(this.cmbVessel);
			this.Controls.Add(this.cmbPLOD);
			this.Controls.Add(this.cmbPOD);
			this.Controls.Add(this.cmbPOL);
			this.Controls.Add(this.txtPCFN);
			this.Controls.Add(this.txtVoyage);
			this.Controls.Add(this.txtBooking);
			this.Controls.Add(this.cmbPLOR);
			this.Name = "frmCreateEstimateOptions";
			this.Text = "Create Estimate Options";
			this.Load += new System.EventHandler(this.frmCreateEstimateOptions_Load);
			this.Click += new System.EventHandler(this.frmCreateEstimateOptions_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCreateEstimateOptions_KeyDown);
			this.Controls.SetChildIndex(this.cmbPLOR, 0);
			this.Controls.SetChildIndex(this.txtBooking, 0);
			this.Controls.SetChildIndex(this.txtVoyage, 0);
			this.Controls.SetChildIndex(this.txtPCFN, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.cmbPOL, 0);
			this.Controls.SetChildIndex(this.cmbPOD, 0);
			this.Controls.SetChildIndex(this.cmbPLOD, 0);
			this.Controls.SetChildIndex(this.cmbVessel, 0);
			this.Controls.SetChildIndex(this.cmbMoveType, 0);
			this.Controls.SetChildIndex(this.txtSerialNo, 0);
			this.Controls.SetChildIndex(this.cmbActOrig, 0);
			this.Controls.SetChildIndex(this.cmbActDest, 0);
			this.Controls.SetChildIndex(this.btnClear, 0);
			this.Controls.SetChildIndex(this.chkShowAllMoveTypes, 0);
			this.Controls.SetChildIndex(this.grpSailDt, 0);
			this.Controls.SetChildIndex(this.chkNonBillPay, 0);
			this.Controls.SetChildIndex(this.btnDefaults, 0);
			this.Controls.SetChildIndex(this.chkIncludeBlankTCN, 0);
			this.Controls.SetChildIndex(this.chkIncludeTransFinal, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucTextBox txtBooking;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOR;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOL;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOD;
		private WinCtrls.ucVesselCheckBoxCombo cmbVessel;
		private WinCtrls.ucMoveTypeCheckBoxCombo cmbMoveType;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private WinCtrls.ucLocationCheckBoxCombo cmbActDest;
		private WinCtrls.ucLocationCheckBoxCombo cmbActOrig;
		private CommonWinCtrls.ucButton btnClear;
		private CommonWinCtrls.ucCheckBox chkShowAllMoveTypes;
		private CommonWinCtrls.ucDateGroupBox grpSailDt;
		private CommonWinCtrls.ucCheckBox chkNonBillPay;
		private CommonWinCtrls.ucButton btnDefaults;
		private CommonWinCtrls.ucCheckBox chkIncludeBlankTCN;
		private CommonWinCtrls.ucCheckBox chkIncludeTransFinal;
	}
}