namespace CS2010.ArcSys.Win
{
	partial class frmEditConveyance
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
			Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditConveyance));
			Janus.Windows.GridEX.GridEXLayout cmbVendorMove_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbConveyanceNo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			Janus.Windows.GridEX.GridEXLayout grdCargoNew_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.btnOK = new Infragistics.Win.Misc.UltraButton();
			this.txtConveyanceNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnCancel = new Infragistics.Win.Misc.UltraButton();
			this.chkFutile = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.cmbVendorMove = new CS2010.ArcSys.WinCtrls.ucVendorMoveCombo();
			this.cmbConveyanceNo = new CS2010.ArcSys.WinCtrls.ucConveyanceCombo();
			this.txtCustomer = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMoveDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOrig = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtDest = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
			this.txtDriver = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTruckNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlMoveInfo = new CS2010.CommonWinCtrls.ucPanel();
			this.lblConveyance = new CS2010.CommonWinCtrls.ucLabel();
			this.infCreateOptions = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.grdCargoNew = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlGrids = new CS2010.CommonWinCtrls.ucPanel();
			this.splGrids = new Infragistics.Win.Misc.UltraSplitter();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendorMove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbConveyanceNo)).BeginInit();
			this.pnlTop.SuspendLayout();
			this.pnlMoveInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infCreateOptions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargoNew)).BeginInit();
			this.pnlGrids.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(434, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtConveyanceNo
			// 
			this.txtConveyanceNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtConveyanceNo.LabelText = "&BOL/Job #";
			this.txtConveyanceNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtConveyanceNo.LinkDisabledMessage = "Link Disabled";
			this.txtConveyanceNo.Location = new System.Drawing.Point(364, 64);
			this.txtConveyanceNo.Name = "txtConveyanceNo";
			this.txtConveyanceNo.Size = new System.Drawing.Size(274, 20);
			this.txtConveyanceNo.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.CausesValidation = false;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(434, 39);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			// 
			// chkFutile
			// 
			this.chkFutile.AutoSize = true;
			this.chkFutile.Location = new System.Drawing.Point(364, 14);
			this.chkFutile.Name = "chkFutile";
			this.chkFutile.Size = new System.Drawing.Size(51, 17);
			this.chkFutile.TabIndex = 2;
			this.chkFutile.Text = "&Futile";
			this.chkFutile.UseVisualStyleBackColor = true;
			this.chkFutile.YN = "N";
			// 
			// grdCargo
			// 
			this.grdCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdCargo.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><EmptyGridInfo>No carg" +
				"o on the conveyance</EmptyGridInfo></LocalizableData>";
			grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
			this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
			this.grdCargo.DisplayFieldChooser = true;
			this.grdCargo.DisplayFieldChooserChildren = true;
			this.grdCargo.DisplayFontSelector = true;
			this.grdCargo.DisplayPreviewMenu = false;
			this.grdCargo.DisplayPrintMenu = false;
			this.grdCargo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grdCargo.ExportFileID = null;
			this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdCargo.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdCargo.GroupByBoxVisible = false;
			this.grdCargo.Location = new System.Drawing.Point(0, 303);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.Size = new System.Drawing.Size(643, 0);
			this.grdCargo.TabIndex = 2;
			this.grdCargo.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdCargo.UseGroupRowSelector = true;
			this.grdCargo.Visible = false;
			this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			// 
			// cmbVendorMove
			// 
			this.cmbVendorMove.CodeColumn = "Vendor_Move_ID";
			this.cmbVendorMove.DescriptionColumn = "Extra_Dsc";
			cmbVendorMove_DesignTimeLayout.LayoutString = resources.GetString("cmbVendorMove_DesignTimeLayout.LayoutString");
			this.cmbVendorMove.DesignTimeLayout = cmbVendorMove_DesignTimeLayout;
			this.cmbVendorMove.DisplayMember = "Extra_Dsc";
			this.cmbVendorMove.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbVendorMove.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbVendorMove.LabelText = "&Moves";
			this.cmbVendorMove.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendorMove.Location = new System.Drawing.Point(84, 64);
			this.cmbVendorMove.Name = "cmbVendorMove";
			this.cmbVendorMove.SelectedIndex = -1;
			this.cmbVendorMove.SelectedItem = null;
			this.cmbVendorMove.Size = new System.Drawing.Size(274, 20);
			this.cmbVendorMove.TabIndex = 8;
			this.cmbVendorMove.ValueColumn = "Vendor_Move_ID";
			this.cmbVendorMove.ValueMember = "Vendor_Move_ID";
			this.cmbVendorMove.Vendor_Cd = null;
			// 
			// cmbConveyanceNo
			// 
			this.cmbConveyanceNo.CodeColumn = "Conveyance_ID";
			this.cmbConveyanceNo.DescriptionColumn = "Conveyance_No";
			cmbConveyanceNo_DesignTimeLayout.LayoutString = resources.GetString("cmbConveyanceNo_DesignTimeLayout.LayoutString");
			this.cmbConveyanceNo.DesignTimeLayout = cmbConveyanceNo_DesignTimeLayout;
			this.cmbConveyanceNo.DisplayMember = "Conveyance_No";
			this.cmbConveyanceNo.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbConveyanceNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbConveyanceNo.LabelText = "&BOL/Job #";
			this.cmbConveyanceNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbConveyanceNo.Location = new System.Drawing.Point(84, 12);
			this.cmbConveyanceNo.Name = "cmbConveyanceNo";
			this.cmbConveyanceNo.SelectedIndex = -1;
			this.cmbConveyanceNo.SelectedItem = null;
			this.cmbConveyanceNo.Size = new System.Drawing.Size(274, 20);
			this.cmbConveyanceNo.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbConveyanceNo.TabIndex = 1;
			this.cmbConveyanceNo.ValueColumn = "Conveyance_ID";
			this.cmbConveyanceNo.ValueMember = "Conveyance_ID";
			this.cmbConveyanceNo.Vendor_Move_ID = null;
			this.cmbConveyanceNo.ValueChanged += new System.EventHandler(this.cmbConveyance_ValueChanged);
			this.cmbConveyanceNo.Validated += new System.EventHandler(this.cmbConveyance_Validated);
			// 
			// txtCustomer
			// 
			this.txtCustomer.BackColor = System.Drawing.SystemColors.Control;
			this.txtCustomer.ForeColor = System.Drawing.Color.Black;
			this.txtCustomer.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtCustomer.LabelText = "Shipper";
			this.txtCustomer.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCustomer.LinkDisabledMessage = "Link Disabled";
			this.txtCustomer.Location = new System.Drawing.Point(84, 4);
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.ReadOnly = true;
			this.txtCustomer.Size = new System.Drawing.Size(274, 20);
			this.txtCustomer.TabIndex = 1;
			this.txtCustomer.TabStop = false;
			// 
			// txtMoveDsc
			// 
			this.txtMoveDsc.BackColor = System.Drawing.SystemColors.Control;
			this.txtMoveDsc.ForeColor = System.Drawing.Color.Black;
			this.txtMoveDsc.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtMoveDsc.LabelText = "Move Desc";
			this.txtMoveDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMoveDsc.LinkDisabledMessage = "Link Disabled";
			this.txtMoveDsc.Location = new System.Drawing.Point(84, 30);
			this.txtMoveDsc.Name = "txtMoveDsc";
			this.txtMoveDsc.ReadOnly = true;
			this.txtMoveDsc.Size = new System.Drawing.Size(274, 20);
			this.txtMoveDsc.TabIndex = 3;
			this.txtMoveDsc.TabStop = false;
			// 
			// txtOrig
			// 
			this.txtOrig.BackColor = System.Drawing.SystemColors.Control;
			this.txtOrig.ForeColor = System.Drawing.Color.Black;
			this.txtOrig.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtOrig.LabelText = "Origin";
			this.txtOrig.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOrig.LinkDisabledMessage = "Link Disabled";
			this.txtOrig.Location = new System.Drawing.Point(84, 56);
			this.txtOrig.Name = "txtOrig";
			this.txtOrig.ReadOnly = true;
			this.txtOrig.Size = new System.Drawing.Size(274, 20);
			this.txtOrig.TabIndex = 5;
			this.txtOrig.TabStop = false;
			// 
			// txtDest
			// 
			this.txtDest.BackColor = System.Drawing.SystemColors.Control;
			this.txtDest.ForeColor = System.Drawing.Color.Black;
			this.txtDest.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtDest.LabelText = "Destination";
			this.txtDest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDest.LinkDisabledMessage = "Link Disabled";
			this.txtDest.Location = new System.Drawing.Point(84, 82);
			this.txtDest.Name = "txtDest";
			this.txtDest.ReadOnly = true;
			this.txtDest.Size = new System.Drawing.Size(274, 20);
			this.txtDest.TabIndex = 7;
			this.txtDest.TabStop = false;
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.txtDriver);
			this.pnlTop.Controls.Add(this.txtTruckNo);
			this.pnlTop.Controls.Add(this.cmbConveyanceNo);
			this.pnlTop.Controls.Add(this.chkFutile);
			this.pnlTop.Controls.Add(this.cmbVendorMove);
			this.pnlTop.Controls.Add(this.btnCancel);
			this.pnlTop.Controls.Add(this.btnOK);
			this.pnlTop.Controls.Add(this.txtConveyanceNo);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(643, 88);
			this.pnlTop.TabIndex = 0;
			// 
			// txtDriver
			// 
			this.txtDriver.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtDriver.LabelText = "Driver";
			this.txtDriver.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDriver.LinkDisabledMessage = "Link Disabled";
			this.txtDriver.Location = new System.Drawing.Point(248, 37);
			this.txtDriver.Name = "txtDriver";
			this.txtDriver.Size = new System.Drawing.Size(110, 20);
			this.txtDriver.TabIndex = 6;
			// 
			// txtTruckNo
			// 
			this.txtTruckNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtTruckNo.LabelText = "Truck #";
			this.txtTruckNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTruckNo.LinkDisabledMessage = "Link Disabled";
			this.txtTruckNo.Location = new System.Drawing.Point(84, 38);
			this.txtTruckNo.Name = "txtTruckNo";
			this.txtTruckNo.Size = new System.Drawing.Size(121, 20);
			this.txtTruckNo.TabIndex = 4;
			// 
			// pnlMoveInfo
			// 
			this.pnlMoveInfo.Controls.Add(this.lblConveyance);
			this.pnlMoveInfo.Controls.Add(this.infCreateOptions);
			this.pnlMoveInfo.Controls.Add(this.txtCustomer);
			this.pnlMoveInfo.Controls.Add(this.txtMoveDsc);
			this.pnlMoveInfo.Controls.Add(this.txtOrig);
			this.pnlMoveInfo.Controls.Add(this.txtDest);
			this.pnlMoveInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMoveInfo.Location = new System.Drawing.Point(0, 88);
			this.pnlMoveInfo.Name = "pnlMoveInfo";
			this.pnlMoveInfo.Size = new System.Drawing.Size(643, 107);
			this.pnlMoveInfo.TabIndex = 1;
			// 
			// lblConveyance
			// 
			this.lblConveyance.AutoSize = false;
			this.lblConveyance.Location = new System.Drawing.Point(384, 4);
			this.lblConveyance.Name = "lblConveyance";
			this.lblConveyance.Size = new System.Drawing.Size(223, 26);
			this.lblConveyance.TabIndex = 9;
			this.lblConveyance.Tag = "Conveyance exists with the given #, select one of the options below";
			this.lblConveyance.Text = "This will create a new conveyance";
			this.lblConveyance.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// infCreateOptions
			// 
			this.infCreateOptions.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
			this.infCreateOptions.CheckedIndex = 0;
			this.infCreateOptions.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010RadioButtonGlyphInfo;
			valueListItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			valueListItem1.DataValue = true;
			valueListItem1.DisplayText = "Create new conveyance with the given #";
			valueListItem2.DataValue = false;
			valueListItem2.DisplayText = "Add to existing conveyance";
			this.infCreateOptions.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
			this.infCreateOptions.ItemSpacingVertical = 5;
			this.infCreateOptions.Location = new System.Drawing.Point(374, 40);
			this.infCreateOptions.Name = "infCreateOptions";
			this.infCreateOptions.Size = new System.Drawing.Size(233, 43);
			this.infCreateOptions.TabIndex = 8;
			this.infCreateOptions.Text = "Create new conveyance with the given #";
			this.infCreateOptions.ValueChanged += new System.EventHandler(this.infCreateOptions_ValueChanged);
			// 
			// grdCargoNew
			// 
			this.grdCargoNew.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdCargoNew.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdCargoNew_DesignTimeLayout.LayoutString = resources.GetString("grdCargoNew_DesignTimeLayout.LayoutString");
			this.grdCargoNew.DesignTimeLayout = grdCargoNew_DesignTimeLayout;
			this.grdCargoNew.DisplayFieldChooser = true;
			this.grdCargoNew.DisplayFieldChooserChildren = true;
			this.grdCargoNew.DisplayFontSelector = true;
			this.grdCargoNew.DisplayPreviewMenu = false;
			this.grdCargoNew.DisplayPrintMenu = false;
			this.grdCargoNew.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCargoNew.ExportFileID = null;
			this.grdCargoNew.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdCargoNew.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdCargoNew.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdCargoNew.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdCargoNew.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdCargoNew.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdCargoNew.GroupByBoxVisible = false;
			this.grdCargoNew.Location = new System.Drawing.Point(0, 0);
			this.grdCargoNew.Name = "grdCargoNew";
			this.grdCargoNew.Size = new System.Drawing.Size(643, 293);
			this.grdCargoNew.TabIndex = 3;
			this.grdCargoNew.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdCargoNew.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdCargoNew.UseGroupRowSelector = true;
			this.grdCargoNew.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			// 
			// pnlGrids
			// 
			this.pnlGrids.Controls.Add(this.grdCargoNew);
			this.pnlGrids.Controls.Add(this.splGrids);
			this.pnlGrids.Controls.Add(this.grdCargo);
			this.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGrids.Location = new System.Drawing.Point(0, 195);
			this.pnlGrids.Name = "pnlGrids";
			this.pnlGrids.Size = new System.Drawing.Size(643, 303);
			this.pnlGrids.TabIndex = 4;
			// 
			// splGrids
			// 
			this.splGrids.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
			this.splGrids.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splGrids.Location = new System.Drawing.Point(0, 293);
			this.splGrids.Name = "splGrids";
			this.splGrids.RestoreExtent = 128;
			this.splGrids.Size = new System.Drawing.Size(643, 10);
			this.splGrids.TabIndex = 4;
			// 
			// frmEditConveyance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(643, 498);
			this.ControlBox = false;
			this.Controls.Add(this.pnlGrids);
			this.Controls.Add(this.pnlMoveInfo);
			this.Controls.Add(this.pnlTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmEditConveyance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add/Edit Conveyance";
			this.Load += new System.EventHandler(this.frmEditConveyance_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendorMove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbConveyanceNo)).EndInit();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.pnlMoveInfo.ResumeLayout(false);
			this.pnlMoveInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.infCreateOptions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdCargoNew)).EndInit();
			this.pnlGrids.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtConveyanceNo;
		private Infragistics.Win.Misc.UltraButton btnOK;
		private WinCtrls.ucConveyanceCombo cmbConveyanceNo;
		private WinCtrls.ucVendorMoveCombo cmbVendorMove;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private CommonWinCtrls.ucCheckBox chkFutile;
		private CommonWinCtrls.ucGridEx grdCargo;
		private CommonWinCtrls.ucTextBox txtCustomer;
		private CommonWinCtrls.ucTextBox txtMoveDsc;
		private CommonWinCtrls.ucTextBox txtOrig;
		private CommonWinCtrls.ucTextBox txtDest;
		private CommonWinCtrls.ucPanel pnlTop;
		private CommonWinCtrls.ucPanel pnlMoveInfo;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet infCreateOptions;
		private CommonWinCtrls.ucLabel lblConveyance;
		private CommonWinCtrls.ucGridEx grdCargoNew;
		private CommonWinCtrls.ucPanel pnlGrids;
		private Infragistics.Win.Misc.UltraSplitter splGrids;
		private CommonWinCtrls.ucTextBox txtDriver;
		private CommonWinCtrls.ucTextBox txtTruckNo;
	}
}