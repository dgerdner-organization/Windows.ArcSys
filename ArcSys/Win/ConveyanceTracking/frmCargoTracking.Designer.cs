namespace CS2010.ArcSys.Win
{
	partial class frmCargoTracking
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
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout cmbVessel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoTracking));
			Janus.Windows.GridEX.GridEXLayout cmbLastLoc_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbDest_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbOrig_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbCargoStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbMove_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
			Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("infToolMain");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomsSubmit");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomsClear");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("HideActions", "");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Undo Actions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomsSubmit");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomsClear");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("HideActions", "");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Form Actions");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("HideActions", "");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Undo Actions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoCustomsSubmit");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoCustomsClear");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo InGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo POD");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo POD");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo InGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo Arrival");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Undo Depart");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoCustomsSubmit");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoCustomsClear");
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.grpSailDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.cmbVessel = new CS2010.ArcSys.WinCtrls.ucVesselCheckBoxCombo();
			this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbLastLoc = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbDest = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbOrig = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.cmbCargoStatus = new CS2010.ArcSys.WinCtrls.ucCargoStatusCheckBoxCombo();
			this.lblDaysRDD = new Infragistics.Win.Misc.UltraLabel();
			this.numDaysRDD = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numDaysSinceAction = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
			this.cmbMove = new CS2010.ArcSys.WinCtrls.ucMoveCombo();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.btnSearch = new Infragistics.Win.Misc.UltraButton();
			this.infRdoRDD = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.cnuTemp = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.testLine1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testLine2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.lastLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this._frmChildBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.infToolbar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._frmChildBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._frmChildBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._frmChildBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCustomerRef = new CS2010.CommonWinCtrls.ucTextBox();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
			this.grpSearch.SuspendLayout();
			this.grpSearchPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.infRdoRDD)).BeginInit();
			this.cnuTemp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.infToolbar)).BeginInit();
			this.SuspendLayout();
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(266, 17);
			this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
			this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 694);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(992, 22);
			this.sbrChild.TabIndex = 4;
			this.sbrChild.Text = "Search Available Main Status Strip";
			this.sbrChild.Visible = false;
			// 
			// grpSearch
			// 
			this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
			this.grpSearch.Controls.Add(this.grpSearchPanel);
			this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 159);
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(180)))), ((int)(((byte)(215)))));
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderAppearance = appearance2;
			this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance3.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderCollapsedAppearance = appearance3;
			this.grpSearch.Location = new System.Drawing.Point(0, 25);
			this.grpSearch.Name = "grpSearch";
			this.grpSearch.Size = new System.Drawing.Size(992, 159);
			this.grpSearch.TabIndex = 0;
			this.grpSearch.Text = "Search Options";
			this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
			this.grpSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grpSearch_KeyDown);
			// 
			// grpSearchPanel
			// 
			this.grpSearchPanel.AutoScroll = true;
			this.grpSearchPanel.Controls.Add(this.txtCustomerRef);
			this.grpSearchPanel.Controls.Add(this.txtBookingNo);
			this.grpSearchPanel.Controls.Add(this.grpSailDt);
			this.grpSearchPanel.Controls.Add(this.cmbVessel);
			this.grpSearchPanel.Controls.Add(this.txtVoyageNo);
			this.grpSearchPanel.Controls.Add(this.cmbLastLoc);
			this.grpSearchPanel.Controls.Add(this.cmbDest);
			this.grpSearchPanel.Controls.Add(this.cmbOrig);
			this.grpSearchPanel.Controls.Add(this.cmbCargoStatus);
			this.grpSearchPanel.Controls.Add(this.lblDaysRDD);
			this.grpSearchPanel.Controls.Add(this.numDaysRDD);
			this.grpSearchPanel.Controls.Add(this.numDaysSinceAction);
			this.grpSearchPanel.Controls.Add(this.txtSerialNo);
			this.grpSearchPanel.Controls.Add(this.cmbVendor);
			this.grpSearchPanel.Controls.Add(this.cmbMove);
			this.grpSearchPanel.Controls.Add(this.btnClear);
			this.grpSearchPanel.Controls.Add(this.btnSearch);
			this.grpSearchPanel.Controls.Add(this.infRdoRDD);
			this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
			this.grpSearchPanel.Name = "grpSearchPanel";
			this.grpSearchPanel.Size = new System.Drawing.Size(986, 135);
			this.grpSearchPanel.TabIndex = 0;
			// 
			// grpSailDt
			// 
			this.grpSailDt.BackColor = System.Drawing.Color.Transparent;
			this.grpSailDt.CheckBoxText = "Sail Date";
			this.grpSailDt.DateFormatDefault = "MM-dd-yyyy";
			this.grpSailDt.DateFormatEdit = "MMddyy";
			this.grpSailDt.Location = new System.Drawing.Point(767, 8);
			this.grpSailDt.Name = "grpSailDt";
			this.grpSailDt.Size = new System.Drawing.Size(129, 76);
			this.grpSailDt.TabIndex = 25;
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
			this.cmbVessel.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbVessel.LabelText = "Vessel";
			this.cmbVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVessel.Location = new System.Drawing.Point(400, 86);
			this.cmbVessel.Name = "cmbVessel";
			this.cmbVessel.SaveSettings = false;
			this.cmbVessel.Size = new System.Drawing.Size(174, 20);
			this.cmbVessel.TabIndex = 17;
			this.cmbVessel.ValueColumn = "Vessel_Cd";
			// 
			// txtVoyageNo
			// 
			this.txtVoyageNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtVoyageNo.LabelText = "Voyage";
			this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
			this.txtVoyageNo.Location = new System.Drawing.Point(400, 60);
			this.txtVoyageNo.Name = "txtVoyageNo";
			this.txtVoyageNo.Size = new System.Drawing.Size(174, 20);
			this.txtVoyageNo.TabIndex = 15;
			// 
			// cmbLastLoc
			// 
			this.cmbLastLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbLastLoc.CodeColumn = "Location_Cd";
			this.cmbLastLoc.DescriptionColumn = "Location_Dsc";
			cmbLastLoc_DesignTimeLayout.LayoutString = resources.GetString("cmbLastLoc_DesignTimeLayout.LayoutString");
			this.cmbLastLoc.DesignTimeLayout = cmbLastLoc_DesignTimeLayout;
			this.cmbLastLoc.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbLastLoc.DropDownButtonsVisible = false;
			this.cmbLastLoc.DropDownDisplayMember = "Location_Dsc";
			this.cmbLastLoc.DropDownValueMember = "Location_Cd";
			this.cmbLastLoc.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbLastLoc.LabelText = "Last Location";
			this.cmbLastLoc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbLastLoc.Location = new System.Drawing.Point(76, 60);
			this.cmbLastLoc.Name = "cmbLastLoc";
			this.cmbLastLoc.SaveSettings = false;
			this.cmbLastLoc.Size = new System.Drawing.Size(257, 20);
			this.cmbLastLoc.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbLastLoc.TabIndex = 5;
			this.cmbLastLoc.ValueColumn = "Location_Cd";
			this.cmbLastLoc.ValuesDataMember = null;
			this.cmbLastLoc.VendorLimited = true;
			// 
			// cmbDest
			// 
			this.cmbDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbDest.CodeColumn = "Location_Cd";
			this.cmbDest.DescriptionColumn = "Location_Dsc";
			cmbDest_DesignTimeLayout.LayoutString = resources.GetString("cmbDest_DesignTimeLayout.LayoutString");
			this.cmbDest.DesignTimeLayout = cmbDest_DesignTimeLayout;
			this.cmbDest.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbDest.DropDownButtonsVisible = false;
			this.cmbDest.DropDownDisplayMember = "Location_Dsc";
			this.cmbDest.DropDownValueMember = "Location_Cd";
			this.cmbDest.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbDest.LabelText = "Destination";
			this.cmbDest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbDest.Location = new System.Drawing.Point(76, 34);
			this.cmbDest.Name = "cmbDest";
			this.cmbDest.SaveSettings = false;
			this.cmbDest.Size = new System.Drawing.Size(257, 20);
			this.cmbDest.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbDest.TabIndex = 3;
			this.cmbDest.ValueColumn = "Location_Cd";
			this.cmbDest.ValuesDataMember = null;
			this.cmbDest.VendorLimited = true;
			// 
			// cmbOrig
			// 
			this.cmbOrig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbOrig.CodeColumn = "Location_Cd";
			this.cmbOrig.DescriptionColumn = "Location_Dsc";
			cmbOrig_DesignTimeLayout.LayoutString = resources.GetString("cmbOrig_DesignTimeLayout.LayoutString");
			this.cmbOrig.DesignTimeLayout = cmbOrig_DesignTimeLayout;
			this.cmbOrig.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbOrig.DropDownButtonsVisible = false;
			this.cmbOrig.DropDownDisplayMember = "Location_Dsc";
			this.cmbOrig.DropDownValueMember = "Location_Cd";
			this.cmbOrig.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbOrig.LabelText = "Origin";
			this.cmbOrig.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbOrig.Location = new System.Drawing.Point(76, 8);
			this.cmbOrig.Name = "cmbOrig";
			this.cmbOrig.SaveSettings = false;
			this.cmbOrig.Size = new System.Drawing.Size(257, 20);
			this.cmbOrig.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbOrig.TabIndex = 1;
			this.cmbOrig.ValueColumn = "Location_Cd";
			this.cmbOrig.ValuesDataMember = null;
			this.cmbOrig.VendorLimited = true;
			// 
			// cmbCargoStatus
			// 
			this.cmbCargoStatus.CodeColumn = "Cargo_Status_Cd";
			this.cmbCargoStatus.DescriptionColumn = "Cargo_Status_Dsc";
			cmbCargoStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbCargoStatus_DesignTimeLayout.LayoutString");
			this.cmbCargoStatus.DesignTimeLayout = cmbCargoStatus_DesignTimeLayout;
			this.cmbCargoStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbCargoStatus.DropDownButtonsVisible = false;
			this.cmbCargoStatus.DropDownDisplayMember = "Cargo_Status_Dsc";
			this.cmbCargoStatus.DropDownValueMember = "Cargo_Status_Cd";
			this.cmbCargoStatus.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbCargoStatus.LabelText = "Status";
			this.cmbCargoStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCargoStatus.Location = new System.Drawing.Point(76, 86);
			this.cmbCargoStatus.Name = "cmbCargoStatus";
			this.cmbCargoStatus.SaveSettings = false;
			this.cmbCargoStatus.ShowContextMenu = false;
			this.cmbCargoStatus.Size = new System.Drawing.Size(257, 20);
			this.cmbCargoStatus.SortType = CS2010.CommonWinCtrls.ComboSortType.None;
			this.cmbCargoStatus.TabIndex = 7;
			this.cmbCargoStatus.ValueColumn = "Cargo_Status_Cd";
			this.cmbCargoStatus.ValuesDataMember = null;
			// 
			// lblDaysRDD
			// 
			appearance1.BackColor = System.Drawing.Color.Transparent;
			this.lblDaysRDD.Appearance = appearance1;
			this.lblDaysRDD.AutoSize = true;
			this.lblDaysRDD.Location = new System.Drawing.Point(718, 57);
			this.lblDaysRDD.Name = "lblDaysRDD";
			this.lblDaysRDD.Size = new System.Drawing.Size(30, 14);
			this.lblDaysRDD.TabIndex = 17;
			this.lblDaysRDD.Text = "Da&ys";
			// 
			// numDaysRDD
			// 
			this.numDaysRDD.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numDaysRDD.BackColor = System.Drawing.SystemColors.Control;
			this.numDaysRDD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numDaysRDD.DecimalDigits = 0;
			this.numDaysRDD.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numDaysRDD.ForeColor = System.Drawing.Color.Black;
			this.numDaysRDD.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Right;
			this.numDaysRDD.LabelBackColor = System.Drawing.Color.Transparent;
			this.numDaysRDD.Location = new System.Drawing.Point(649, 54);
			this.numDaysRDD.MaxLength = 4;
			this.numDaysRDD.Name = "numDaysRDD";
			this.numDaysRDD.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numDaysRDD.ReadOnly = true;
			this.numDaysRDD.Size = new System.Drawing.Size(67, 20);
			this.numDaysRDD.TabIndex = 19;
			this.numDaysRDD.TabStop = false;
			this.numDaysRDD.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numDaysRDD.Value = null;
			this.numDaysRDD.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt16;
			// 
			// numDaysSinceAction
			// 
			this.numDaysSinceAction.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numDaysSinceAction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.infToolbar.SetContextMenuUltra(this.numDaysSinceAction, "Form Actions");
			this.numDaysSinceAction.DecimalDigits = 0;
			this.numDaysSinceAction.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numDaysSinceAction.LabelBackColor = System.Drawing.Color.Transparent;
			this.numDaysSinceAction.LabelText = "Days Since &Action";
			this.numDaysSinceAction.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numDaysSinceAction.Location = new System.Drawing.Point(689, 8);
			this.numDaysSinceAction.MaxLength = 4;
			this.numDaysSinceAction.Name = "numDaysSinceAction";
			this.numDaysSinceAction.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numDaysSinceAction.Size = new System.Drawing.Size(66, 20);
			this.numDaysSinceAction.TabIndex = 21;
			this.numDaysSinceAction.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numDaysSinceAction.Value = null;
			this.numDaysSinceAction.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt16;
			// 
			// txtSerialNo
			// 
			this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtSerialNo.LabelText = "Serial #";
			this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
			this.txtSerialNo.Location = new System.Drawing.Point(400, 34);
			this.txtSerialNo.Name = "txtSerialNo";
			this.txtSerialNo.Size = new System.Drawing.Size(174, 20);
			this.txtSerialNo.TabIndex = 13;
			// 
			// cmbVendor
			// 
			this.cmbVendor.CodeColumn = "Vendor_Cd";
			this.cmbVendor.DescriptionColumn = "Vendor_Nm";
			cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
			this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
			this.cmbVendor.DisplayMember = "Vendor_CdVendor_Nm";
			this.cmbVendor.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbVendor.DisplayUserVendorsOnly = true;
			this.cmbVendor.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbVendor.LabelText = "&Vendor";
			this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendor.Location = new System.Drawing.Point(632, 86);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.SelectedIndex = -1;
			this.cmbVendor.SelectedItem = null;
			this.cmbVendor.Size = new System.Drawing.Size(122, 20);
			this.cmbVendor.TabIndex = 24;
			this.cmbVendor.ValueColumn = "Vendor_Cd";
			this.cmbVendor.ValueMember = "Vendor_Cd";
			this.cmbVendor.Visible = false;
			// 
			// cmbMove
			// 
			this.cmbMove.CodeColumn = "Move_ID";
			this.cmbMove.DescriptionColumn = "Move_Dsc";
			cmbMove_DesignTimeLayout.LayoutString = resources.GetString("cmbMove_DesignTimeLayout.LayoutString");
			this.cmbMove.DesignTimeLayout = cmbMove_DesignTimeLayout;
			this.cmbMove.DisplayMember = "Move_Dsc";
			this.cmbMove.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbMove.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbMove.LabelText = "&Move Desc";
			this.cmbMove.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMove.Location = new System.Drawing.Point(400, 112);
			this.cmbMove.Name = "cmbMove";
			this.cmbMove.SelectedIndex = -1;
			this.cmbMove.SelectedItem = null;
			this.cmbMove.Size = new System.Drawing.Size(174, 20);
			this.cmbMove.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbMove.TabIndex = 19;
			this.cmbMove.ValueColumn = "Move_ID";
			this.cmbMove.ValueMember = "Move_ID";
			// 
			// btnClear
			// 
			this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			this.btnClear.Location = new System.Drawing.Point(907, 40);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 41;
			this.btnClear.Text = "Clear";
			this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
			this.btnSearch.Location = new System.Drawing.Point(907, 14);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 40;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// infRdoRDD
			// 
			this.infRdoRDD.BackColor = System.Drawing.Color.Transparent;
			this.infRdoRDD.BackColorInternal = System.Drawing.Color.Transparent;
			this.infRdoRDD.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
			this.infRdoRDD.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010RadioButtonGlyphInfo;
			valueListItem1.DataValue = ((short)(1));
			valueListItem1.DisplayText = "Missed RDD";
			valueListItem2.DataValue = ((short)(2));
			valueListItem2.DisplayText = "RDD in";
			valueListItem3.CheckState = System.Windows.Forms.CheckState.Checked;
			valueListItem3.DataValue = ((short)(0));
			valueListItem3.DisplayText = "All";
			this.infRdoRDD.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
			this.infRdoRDD.ItemSpacingVertical = 5;
			this.infRdoRDD.Location = new System.Drawing.Point(594, 34);
			this.infRdoRDD.Name = "infRdoRDD";
			this.infRdoRDD.Size = new System.Drawing.Size(160, 44);
			this.infRdoRDD.TabIndex = 22;
			this.infRdoRDD.ValueChanged += new System.EventHandler(this.infRdoRDD_ValueChanged);
			// 
			// cnuTemp
			// 
			this.cnuTemp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testLine1ToolStripMenuItem,
            this.testLine2ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.lastLineToolStripMenuItem});
			this.cnuTemp.Name = "cnuTemp";
			this.cnuTemp.Size = new System.Drawing.Size(138, 76);
			// 
			// testLine1ToolStripMenuItem
			// 
			this.testLine1ToolStripMenuItem.Name = "testLine1ToolStripMenuItem";
			this.testLine1ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.testLine1ToolStripMenuItem.Text = "Test Line 1";
			// 
			// testLine2ToolStripMenuItem
			// 
			this.testLine2ToolStripMenuItem.Name = "testLine2ToolStripMenuItem";
			this.testLine2ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.testLine2ToolStripMenuItem.Text = "Test Line 2";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
			// 
			// lastLineToolStripMenuItem
			// 
			this.lastLineToolStripMenuItem.Name = "lastLineToolStripMenuItem";
			this.lastLineToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.lastLineToolStripMenuItem.Text = "Last Line";
			// 
			// grdCargo
			// 
			this.grdCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdCargo.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
			this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
			this.grdCargo.DisplayFieldChooser = true;
			this.grdCargo.DisplayFieldChooserChildren = true;
			this.grdCargo.DisplayFontSelector = true;
			this.grdCargo.DisplayPreviewMenu = false;
			this.grdCargo.DisplayPrintMenu = false;
			this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCargo.ExportFileID = null;
			this.grdCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdCargo.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdCargo.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdCargo.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdCargo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdCargo.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdCargo.GroupRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(221)))), ((int)(((byte)(235)))));
			this.grdCargo.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(207)))), ((int)(((byte)(235)))));
			this.grdCargo.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
			this.grdCargo.Hierarchical = true;
			this.grdCargo.Location = new System.Drawing.Point(0, 184);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdCargo.Size = new System.Drawing.Size(992, 532);
			this.grdCargo.TabIndex = 1;
			this.grdCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdCargo.UseGroupRowSelector = true;
			this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdCargo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
			this.grdCargo.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_ColumnButtonClick);
			this.grdCargo.FilterApplied += new System.EventHandler(this.grdCargo_FilterApplied);
			this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
			this.grdCargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
			// 
			// _frmChildBase_Toolbars_Dock_Area_Left
			// 
			this._frmChildBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._frmChildBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._frmChildBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._frmChildBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmChildBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 25);
			this._frmChildBase_Toolbars_Dock_Area_Left.Name = "_frmChildBase_Toolbars_Dock_Area_Left";
			this._frmChildBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 691);
			this._frmChildBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.infToolbar;
			// 
			// infToolbar
			// 
			this.infToolbar.DesignerFlags = 1;
			this.infToolbar.DockWithinContainer = this;
			this.infToolbar.DockWithinContainerBaseType = typeof(CS2010.CommonWinCtrls.frmChildBase);
			this.infToolbar.MdiMergeable = false;
			this.infToolbar.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Random;
			this.infToolbar.MiniToolbar.ToolRowCount = 1;
			this.infToolbar.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.infToolbar.ShowFullMenusDelay = 500;
			this.infToolbar.ShowMenuShadows = Infragistics.Win.DefaultableBoolean.True;
			this.infToolbar.ShowQuickCustomizeButton = false;
			this.infToolbar.ShowShortcutsInToolTips = true;
			this.infToolbar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			stateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5,
            stateButtonTool4,
            popupMenuTool3});
			ultraToolbar1.Settings.PaddingBottom = 0;
			ultraToolbar1.Settings.PaddingLeft = 0;
			ultraToolbar1.Settings.PaddingRight = 0;
			ultraToolbar1.Settings.PaddingTop = 0;
			ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
			ultraToolbar1.Settings.ToolSpacing = 0;
			ultraToolbar1.Text = "infToolMain";
			this.infToolbar.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			this.infToolbar.ToolbarSettings.PaddingBottom = 0;
			this.infToolbar.ToolbarSettings.PaddingLeft = 0;
			this.infToolbar.ToolbarSettings.PaddingRight = 0;
			this.infToolbar.ToolbarSettings.PaddingTop = 0;
			buttonTool1.SharedPropsInternal.Caption = "Customs Submitted";
			buttonTool1.SharedPropsInternal.Category = "CargoDates";
			buttonTool1.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
			buttonTool2.SharedPropsInternal.Caption = "Customs Cleared";
			buttonTool2.SharedPropsInternal.Category = "CargoDates";
			buttonTool2.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlF6;
			stateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool3.SharedPropsInternal.Caption = "Hide Actions";
			stateButtonTool3.SharedPropsInternal.Category = "GUI";
			stateButtonTool3.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			popupMenuTool1.SharedPropsInternal.Caption = "Form Actions";
			popupMenuTool1.SharedPropsInternal.Category = "GUI";
			stateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1});
			popupMenuTool2.SharedPropsInternal.Caption = "Undo Actions";
			popupMenuTool2.SharedPropsInternal.Category = "UndoItems";
			popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool6,
            buttonTool12,
            buttonTool11});
			buttonTool7.SharedPropsInternal.Caption = "Undo POD Stamp";
			buttonTool7.SharedPropsInternal.Category = "UndoItems";
			buttonTool8.SharedPropsInternal.Caption = "Undo InGate";
			buttonTool8.SharedPropsInternal.Category = "UndoItems";
			buttonTool9.SharedPropsInternal.Caption = "Undo Arrival";
			buttonTool9.SharedPropsInternal.Category = "UndoItems";
			buttonTool10.SharedPropsInternal.Caption = "Undo Depart";
			buttonTool10.SharedPropsInternal.Category = "UndoItems";
			buttonTool13.SharedPropsInternal.Caption = "Undo Customs Submitted";
			buttonTool13.SharedPropsInternal.Category = "UndoItems";
			buttonTool14.SharedPropsInternal.Caption = "Undo Customs Clearance";
			buttonTool14.SharedPropsInternal.Category = "UndoItems";
			this.infToolbar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            stateButtonTool3,
            popupMenuTool1,
            popupMenuTool2,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool13,
            buttonTool14});
			this.infToolbar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.infToolbar_ToolClick);
			// 
			// _frmChildBase_Toolbars_Dock_Area_Right
			// 
			this._frmChildBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._frmChildBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._frmChildBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._frmChildBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmChildBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(992, 25);
			this._frmChildBase_Toolbars_Dock_Area_Right.Name = "_frmChildBase_Toolbars_Dock_Area_Right";
			this._frmChildBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 691);
			this._frmChildBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.infToolbar;
			// 
			// _frmChildBase_Toolbars_Dock_Area_Top
			// 
			this._frmChildBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._frmChildBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._frmChildBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._frmChildBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmChildBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._frmChildBase_Toolbars_Dock_Area_Top.Name = "_frmChildBase_Toolbars_Dock_Area_Top";
			this._frmChildBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(992, 25);
			this._frmChildBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.infToolbar;
			// 
			// _frmChildBase_Toolbars_Dock_Area_Bottom
			// 
			this._frmChildBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._frmChildBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			this._frmChildBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._frmChildBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			this._frmChildBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 716);
			this._frmChildBase_Toolbars_Dock_Area_Bottom.Name = "_frmChildBase_Toolbars_Dock_Area_Bottom";
			this._frmChildBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(992, 0);
			this._frmChildBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.infToolbar;
			// 
			// txtBookingNo
			// 
			this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtBookingNo.LabelText = "Booking";
			this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
			this.txtBookingNo.Location = new System.Drawing.Point(76, 112);
			this.txtBookingNo.Name = "txtBookingNo";
			this.txtBookingNo.Size = new System.Drawing.Size(257, 20);
			this.txtBookingNo.TabIndex = 9;
			// 
			// txtCustomerRef
			// 
			this.txtCustomerRef.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtCustomerRef.LabelText = "PCFN";
			this.txtCustomerRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCustomerRef.LinkDisabledMessage = "Link Disabled";
			this.txtCustomerRef.Location = new System.Drawing.Point(400, 8);
			this.txtCustomerRef.Name = "txtCustomerRef";
			this.txtCustomerRef.Size = new System.Drawing.Size(174, 20);
			this.txtCustomerRef.TabIndex = 11;
			// 
			// frmCargoTracking
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.ContextMenuStrip = this.cnuTemp;
			this.Controls.Add(this.grdCargo);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Bottom);
			this.KeyPreview = true;
			this.Name = "frmCargoTracking";
			this.Text = "Cargo Tracking";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCargoTracking_FormClosing);
			this.Load += new System.EventHandler(this.frmCargoTracking_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCargoTracking_KeyDown);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearchPanel.ResumeLayout(false);
			this.grpSearchPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbMove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.infRdoRDD)).EndInit();
			this.cnuTemp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.infToolbar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private CommonWinCtrls.ucGridEx grdCargo;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private WinCtrls.ucMoveCombo cmbMove;
		private WinCtrls.ucVendorCombo cmbVendor;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager infToolbar;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Bottom;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucNumericEditBox numDaysSinceAction;
		private CommonWinCtrls.ucNumericEditBox numDaysRDD;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet infRdoRDD;
		private System.Windows.Forms.ContextMenuStrip cnuTemp;
		private System.Windows.Forms.ToolStripMenuItem testLine1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testLine2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem lastLineToolStripMenuItem;
		private Infragistics.Win.Misc.UltraLabel lblDaysRDD;
		private WinCtrls.ucCargoStatusCheckBoxCombo cmbCargoStatus;
		private WinCtrls.ucLocationCheckBoxCombo cmbLastLoc;
		private WinCtrls.ucLocationCheckBoxCombo cmbDest;
		private WinCtrls.ucLocationCheckBoxCombo cmbOrig;
		private WinCtrls.ucVesselCheckBoxCombo cmbVessel;
		private CommonWinCtrls.ucTextBox txtVoyageNo;
		private CommonWinCtrls.ucDateGroupBox grpSailDt;
		private CommonWinCtrls.ucTextBox txtCustomerRef;
		private CommonWinCtrls.ucTextBox txtBookingNo;
	}
}