namespace CS2010.ArcSys.Win
{
    partial class frmSalesSummaryOptions
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
            Janus.Windows.GridEX.GridEXLayout cmbMoveType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesSummaryOptions));
            Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.grpSailDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
            this.cmbMoveType = new CS2010.ArcSys.WinCtrls.ucMoveTypeCheckBoxCombo();
            this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCheckBoxCombo();
            this.cmbPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.cmbPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
            this.txtEstimateNo = new CS2010.CommonWinCtrls.ucTextBox();
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
            this.btnApply.Location = new System.Drawing.Point(341, 102);
            this.btnApply.TabIndex = 43;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.LabelText = "Serial &No";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(78, 348);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(249, 20);
            this.txtSerialNo.TabIndex = 17;
            this.txtSerialNo.Visible = false;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "&PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(78, 322);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(249, 20);
            this.txtPCFN.TabIndex = 1;
            this.txtPCFN.Visible = false;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "&Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(78, 88);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(249, 20);
            this.txtVoyage.TabIndex = 7;
            // 
            // txtBooking
            // 
            this.txtBooking.LabelText = "&Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(78, 12);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(249, 20);
            this.txtBooking.TabIndex = 3;
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
            // grpSailDt
            // 
            this.grpSailDt.CheckBoxText = "Sail Date";
            this.grpSailDt.DateFormatDefault = "MM-dd-yyyy";
            this.grpSailDt.DateFormatEdit = "MMddyy";
            this.grpSailDt.Location = new System.Drawing.Point(78, 374);
            this.grpSailDt.Name = "grpSailDt";
            this.grpSailDt.Size = new System.Drawing.Size(129, 76);
            this.grpSailDt.TabIndex = 26;
            this.grpSailDt.Visible = false;
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
            this.cmbMoveType.Location = new System.Drawing.Point(78, 218);
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
            this.cmbVessel.Location = new System.Drawing.Point(78, 62);
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
            this.cmbPLOD.DropDownButtonsVisible = false;
            this.cmbPLOD.DropDownDisplayMember = "Location_Cd";
            this.cmbPLOD.DropDownValueMember = "Location_Cd";
            this.cmbPLOD.LabelText = "PL&OD";
            this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOD.Location = new System.Drawing.Point(78, 192);
            this.cmbPLOD.Name = "cmbPLOD";
            this.cmbPLOD.SaveSettings = false;
            this.cmbPLOD.Size = new System.Drawing.Size(249, 20);
            this.cmbPLOD.TabIndex = 15;
            this.cmbPLOD.ValueColumn = "Location_Cd";
            // 
            // cmbPOD
            // 
            this.cmbPOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbPOD.CodeColumn = "Location_Cd";
            this.cmbPOD.DescriptionColumn = "Location_Dsc";
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DropDownButtonsVisible = false;
            this.cmbPOD.DropDownDisplayMember = "Location_Cd";
            this.cmbPOD.DropDownValueMember = "Location_Cd";
            this.cmbPOD.LabelText = "PO&D";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(78, 166);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.SaveSettings = false;
            this.cmbPOD.Size = new System.Drawing.Size(249, 20);
            this.cmbPOD.TabIndex = 13;
            this.cmbPOD.ValueColumn = "Location_Cd";
            // 
            // cmbPOL
            // 
            this.cmbPOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbPOL.CodeColumn = "Location_Cd";
            this.cmbPOL.DescriptionColumn = "Location_Dsc";
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DropDownButtonsVisible = false;
            this.cmbPOL.DropDownDisplayMember = "Location_Cd";
            this.cmbPOL.DropDownValueMember = "Location_Cd";
            this.cmbPOL.LabelText = "PO&L";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(78, 140);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.SaveSettings = false;
            this.cmbPOL.Size = new System.Drawing.Size(249, 20);
            this.cmbPOL.TabIndex = 11;
            this.cmbPOL.ValueColumn = "Location_Cd";
            // 
            // cmbPLOR
            // 
            this.cmbPLOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbPLOR.CodeColumn = "Location_Cd";
            this.cmbPLOR.DescriptionColumn = "Location_Dsc";
            cmbPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbPLOR_DesignTimeLayout.LayoutString");
            this.cmbPLOR.DesignTimeLayout = cmbPLOR_DesignTimeLayout;
            this.cmbPLOR.DropDownButtonsVisible = false;
            this.cmbPLOR.DropDownDisplayMember = "Location_Cd";
            this.cmbPLOR.DropDownValueMember = "Location_Cd";
            this.cmbPLOR.LabelText = "PLO&R";
            this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPLOR.Location = new System.Drawing.Point(78, 114);
            this.cmbPLOR.Name = "cmbPLOR";
            this.cmbPLOR.SaveSettings = false;
            this.cmbPLOR.Size = new System.Drawing.Size(249, 20);
            this.cmbPLOR.TabIndex = 9;
            this.cmbPLOR.ValueColumn = "Location_Cd";
            // 
            // txtEstimateNo
            // 
            this.txtEstimateNo.LabelText = "&Estimate";
            this.txtEstimateNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtEstimateNo.LinkDisabledMessage = "Link Disabled";
            this.txtEstimateNo.Location = new System.Drawing.Point(78, 37);
            this.txtEstimateNo.Name = "txtEstimateNo";
            this.txtEstimateNo.Size = new System.Drawing.Size(249, 20);
            this.txtEstimateNo.TabIndex = 44;
            // 
            // frmSalesSummaryOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 266);
            this.Controls.Add(this.txtEstimateNo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtBooking);
            this.Controls.Add(this.cmbVessel);
            this.Controls.Add(this.cmbPLOD);
            this.Controls.Add(this.cmbPOD);
            this.Controls.Add(this.cmbMoveType);
            this.Controls.Add(this.cmbPOL);
            this.Controls.Add(this.txtPCFN);
            this.Controls.Add(this.txtVoyage);
            this.Controls.Add(this.cmbPLOR);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.grpSailDt);
            this.Name = "frmSalesSummaryOptions";
            this.Text = "Sales Summary Search Options";
            this.Load += new System.EventHandler(this.frmSearchEstimateOptions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchEstimateOptions_KeyDown);
            this.Controls.SetChildIndex(this.grpSailDt, 0);
            this.Controls.SetChildIndex(this.txtSerialNo, 0);
            this.Controls.SetChildIndex(this.cmbPLOR, 0);
            this.Controls.SetChildIndex(this.txtVoyage, 0);
            this.Controls.SetChildIndex(this.txtPCFN, 0);
            this.Controls.SetChildIndex(this.cmbPOL, 0);
            this.Controls.SetChildIndex(this.cmbMoveType, 0);
            this.Controls.SetChildIndex(this.cmbPOD, 0);
            this.Controls.SetChildIndex(this.cmbPLOD, 0);
            this.Controls.SetChildIndex(this.cmbVessel, 0);
            this.Controls.SetChildIndex(this.txtBooking, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.txtEstimateNo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private CommonWinCtrls.ucTextBox txtSerialNo;
		private WinCtrls.ucMoveTypeCheckBoxCombo cmbMoveType;
		private WinCtrls.ucVesselCheckBoxCombo cmbVessel;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOD;
		private WinCtrls.ucLocationCheckBoxCombo cmbPOL;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucTextBox txtBooking;
		private WinCtrls.ucLocationCheckBoxCombo cmbPLOR;
        private CommonWinCtrls.ucButton btnClear;
		private CommonWinCtrls.ucDateGroupBox grpSailDt;
        private CommonWinCtrls.ucTextBox txtEstimateNo;
	}
}