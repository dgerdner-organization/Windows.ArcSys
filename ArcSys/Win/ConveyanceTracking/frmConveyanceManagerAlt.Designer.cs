namespace CS2010.ArcSys.Win
{
	partial class frmConveyanceManagerAlt
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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout cmbOrig_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConveyanceManagerAlt));
			Janus.Windows.GridEX.GridEXLayout cmbLastLoc_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbCargoStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbDest_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbMove_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdConveyance_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdConveyance_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.ButtonImage");
			Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedTop, new System.Guid("240c1df1-15a2-40dc-ad57-6bcef01b5c72"));
			Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("f69db7fd-7869-41d5-8d6b-62ca496d15d7"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("240c1df1-15a2-40dc-ad57-6bcef01b5c72"), 0);
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("6ad67918-a499-4aa3-bbdf-0cea5fe6020a"));
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("9c0f5999-c155-4544-ad2e-fe14ea41dca3"));
			Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("0fd5344a-d44c-4963-ab09-1f7cab211062"), new System.Guid("8422e57d-2f84-44ef-b875-5f9709e230cc"), -1, new System.Guid("9c0f5999-c155-4544-ad2e-fe14ea41dca3"), 0);
			Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("c85c03fd-c700-46f7-9ff3-af1b59b5c6fd"), new System.Guid("6ad67918-a499-4aa3-bbdf-0cea5fe6020a"), 0, new System.Guid("9c0f5999-c155-4544-ad2e-fe14ea41dca3"), 0);
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane4 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("8422e57d-2f84-44ef-b875-5f9709e230cc"));
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("infToolMain");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddCargo");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveSelected");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveChecked");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CreateFutile");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool10 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoActions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CreateFutile");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveSelected");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveChecked");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupAddRemove");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveChecked");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RemoveSelected");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddCargo");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("EditEx");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("AddCargo");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupCargoActions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PODStamp");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("T1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PODStamp");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("T1");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoConveyanceActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoCargoActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoConveyanceActions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoArriveatPickup");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupUndoCargoActions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoInGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoPOD");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoT1");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoInGate");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoPOD");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoT1");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool11 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool12 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupCargoActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool13 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupConveyanceActions");
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool14 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupConveyanceActions");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ArrivedatPickup");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ArrivedatPickup");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UndoArriveatPickup");
			this.pnlSearchParams = new Infragistics.Win.Misc.UltraPanel();
			this.btnReset = new Infragistics.Win.Misc.UltraButton();
			this.grpSailDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.cmbOrig = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.chkOnlyAvailable = new System.Windows.Forms.CheckBox();
			this.btnSearch = new Infragistics.Win.Misc.UltraButton();
			this.cmbLastLoc = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.cmbCargoStatus = new CS2010.ArcSys.WinCtrls.ucCargoStatusCheckBoxCombo();
			this.cmbDest = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbMove = new CS2010.ArcSys.WinCtrls.ucMoveCombo();
			this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
			this.grdConveyance = new CS2010.CommonWinCtrls.ucGridEx();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
			this.infDockMgr = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
			this._frmChildBaseUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
			this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
			this._frmChildBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.infToolbar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this._frmChildBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._frmChildBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._frmChildBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
			this.pnlCargo = new Infragistics.Win.Misc.UltraPanel();
			this.tbrCargoActions = new System.Windows.Forms.ToolStrip();
			this.tbbCargoGroupBy = new System.Windows.Forms.ToolStripDropDownButton();
			this.tbbCargoGroupByNone = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbCargoGroupByFromTo = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbCargoGroupByTruck = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbCargoOnlyAvail = new System.Windows.Forms.ToolStripButton();
			this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.windowDockingArea4 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.dockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
			this.windowDockingArea5 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.pnlSearchParams.ClientArea.SuspendLayout();
			this.pnlSearchParams.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbMove)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdConveyance)).BeginInit();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).BeginInit();
			this.dockableWindow1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infToolbar)).BeginInit();
			this.dockableWindow2.SuspendLayout();
			this.pnlCargo.ClientArea.SuspendLayout();
			this.pnlCargo.SuspendLayout();
			this.tbrCargoActions.SuspendLayout();
			this.windowDockingArea3.SuspendLayout();
			this.windowDockingArea4.SuspendLayout();
			this.dockableWindow3.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlSearchParams
			// 
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(235)))));
			appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
			appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.pnlSearchParams.Appearance = appearance3;
			this.pnlSearchParams.AutoScroll = true;
			// 
			// pnlSearchParams.ClientArea
			// 
			this.pnlSearchParams.ClientArea.Controls.Add(this.btnReset);
			this.pnlSearchParams.ClientArea.Controls.Add(this.grpSailDt);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbOrig);
			this.pnlSearchParams.ClientArea.Controls.Add(this.chkOnlyAvailable);
			this.pnlSearchParams.ClientArea.Controls.Add(this.btnSearch);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbLastLoc);
			this.pnlSearchParams.ClientArea.Controls.Add(this.btnClear);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbCargoStatus);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbDest);
			this.pnlSearchParams.ClientArea.Controls.Add(this.txtSerialNo);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbMove);
			this.pnlSearchParams.ClientArea.Controls.Add(this.txtVoyageNo);
			this.pnlSearchParams.ClientArea.Controls.Add(this.cmbVendor);
			this.pnlSearchParams.Location = new System.Drawing.Point(0, 18);
			this.pnlSearchParams.Name = "pnlSearchParams";
			this.pnlSearchParams.Size = new System.Drawing.Size(992, 130);
			this.pnlSearchParams.TabIndex = 18;
			// 
			// btnReset
			// 
			this.btnReset.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			this.btnReset.Location = new System.Drawing.Point(760, 67);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 42;
			this.btnReset.Text = "Reset";
			this.btnReset.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnReset.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// grpSailDt
			// 
			this.grpSailDt.BackColor = System.Drawing.Color.Transparent;
			this.grpSailDt.CheckBoxText = "Sail Date";
			this.grpSailDt.DateFormatDefault = "MM-dd-yyyy";
			this.grpSailDt.DateFormatEdit = "MMddyy";
			this.grpSailDt.Location = new System.Drawing.Point(614, 12);
			this.grpSailDt.Name = "grpSailDt";
			this.grpSailDt.Size = new System.Drawing.Size(129, 76);
			this.grpSailDt.TabIndex = 16;
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
			this.cmbOrig.Location = new System.Drawing.Point(78, 12);
			this.cmbOrig.Name = "cmbOrig";
			this.cmbOrig.SaveSettings = false;
			this.cmbOrig.Size = new System.Drawing.Size(257, 20);
			this.cmbOrig.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbOrig.TabIndex = 1;
			this.cmbOrig.ValueColumn = "Location_Cd";
			this.cmbOrig.ValuesDataMember = null;
			this.cmbOrig.VendorLimited = true;
			// 
			// chkOnlyAvailable
			// 
			this.chkOnlyAvailable.AutoSize = true;
			this.chkOnlyAvailable.BackColor = System.Drawing.Color.Transparent;
			this.chkOnlyAvailable.Location = new System.Drawing.Point(614, 91);
			this.chkOnlyAvailable.Name = "chkOnlyAvailable";
			this.chkOnlyAvailable.Size = new System.Drawing.Size(123, 17);
			this.chkOnlyAvailable.TabIndex = 17;
			this.chkOnlyAvailable.Text = "Only Show Available";
			this.chkOnlyAvailable.UseVisualStyleBackColor = false;
			// 
			// btnSearch
			// 
			this.btnSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsXPCommandButton;
			this.btnSearch.Location = new System.Drawing.Point(760, 12);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 40;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
			this.cmbLastLoc.Location = new System.Drawing.Point(78, 64);
			this.cmbLastLoc.Name = "cmbLastLoc";
			this.cmbLastLoc.SaveSettings = false;
			this.cmbLastLoc.Size = new System.Drawing.Size(257, 20);
			this.cmbLastLoc.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbLastLoc.TabIndex = 5;
			this.cmbLastLoc.ValueColumn = "Location_Cd";
			this.cmbLastLoc.ValuesDataMember = null;
			this.cmbLastLoc.VendorLimited = true;
			// 
			// btnClear
			// 
			this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
			this.btnClear.Location = new System.Drawing.Point(760, 38);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 41;
			this.btnClear.Text = "Clear";
			this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
			this.cmbCargoStatus.Location = new System.Drawing.Point(78, 90);
			this.cmbCargoStatus.Name = "cmbCargoStatus";
			this.cmbCargoStatus.SaveSettings = false;
			this.cmbCargoStatus.ShowContextMenu = false;
			this.cmbCargoStatus.Size = new System.Drawing.Size(257, 20);
			this.cmbCargoStatus.SortType = CS2010.CommonWinCtrls.ComboSortType.None;
			this.cmbCargoStatus.TabIndex = 7;
			this.cmbCargoStatus.ValueColumn = "Cargo_Status_Cd";
			this.cmbCargoStatus.ValuesDataMember = null;
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
			this.cmbDest.Location = new System.Drawing.Point(78, 38);
			this.cmbDest.Name = "cmbDest";
			this.cmbDest.SaveSettings = false;
			this.cmbDest.Size = new System.Drawing.Size(257, 20);
			this.cmbDest.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbDest.TabIndex = 3;
			this.cmbDest.ValueColumn = "Location_Cd";
			this.cmbDest.ValuesDataMember = null;
			this.cmbDest.VendorLimited = true;
			// 
			// txtSerialNo
			// 
			this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtSerialNo.LabelText = "Serial #";
			this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
			this.txtSerialNo.Location = new System.Drawing.Point(403, 12);
			this.txtSerialNo.Name = "txtSerialNo";
			this.txtSerialNo.Size = new System.Drawing.Size(198, 20);
			this.txtSerialNo.TabIndex = 9;
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
			this.cmbMove.LabelText = "Move Desc";
			this.cmbMove.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMove.Location = new System.Drawing.Point(403, 64);
			this.cmbMove.Name = "cmbMove";
			this.cmbMove.SelectedIndex = -1;
			this.cmbMove.SelectedItem = null;
			this.cmbMove.Size = new System.Drawing.Size(198, 20);
			this.cmbMove.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbMove.TabIndex = 13;
			this.cmbMove.ValueColumn = "Move_ID";
			this.cmbMove.ValueMember = "Move_ID";
			// 
			// txtVoyageNo
			// 
			this.txtVoyageNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtVoyageNo.LabelText = "Voyage";
			this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
			this.txtVoyageNo.Location = new System.Drawing.Point(403, 37);
			this.txtVoyageNo.Name = "txtVoyageNo";
			this.txtVoyageNo.Size = new System.Drawing.Size(198, 20);
			this.txtVoyageNo.TabIndex = 11;
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
			this.cmbVendor.LabelText = "Vendor";
			this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendor.Location = new System.Drawing.Point(403, 89);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.SelectedIndex = -1;
			this.cmbVendor.SelectedItem = null;
			this.cmbVendor.Size = new System.Drawing.Size(198, 20);
			this.cmbVendor.TabIndex = 15;
			this.cmbVendor.ValueColumn = "Vendor_Cd";
			this.cmbVendor.ValueMember = "Vendor_Cd";
			this.cmbVendor.Visible = false;
			// 
			// grdConveyance
			// 
			this.grdConveyance.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdConveyance.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdConveyance_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdConveyance_DesignTimeLayout_Reference_0.Instance")));
			grdConveyance_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdConveyance_DesignTimeLayout_Reference_0});
			grdConveyance_DesignTimeLayout.LayoutString = resources.GetString("grdConveyance_DesignTimeLayout.LayoutString");
			this.grdConveyance.DesignTimeLayout = grdConveyance_DesignTimeLayout;
			this.grdConveyance.DisplayFieldChooser = true;
			this.grdConveyance.DisplayFieldChooserChildren = true;
			this.grdConveyance.DisplayFontSelector = true;
			this.grdConveyance.DisplayPreviewMenu = false;
			this.grdConveyance.DisplayPrintMenu = false;
			this.grdConveyance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdConveyance.ExportFileID = null;
			this.grdConveyance.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdConveyance.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdConveyance.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdConveyance.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdConveyance.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdConveyance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdConveyance.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdConveyance.Location = new System.Drawing.Point(0, 19);
			this.grdConveyance.Name = "grdConveyance";
			this.grdConveyance.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdConveyance.Size = new System.Drawing.Size(992, 494);
			this.grdConveyance.TabIndex = 12;
			this.grdConveyance.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdConveyance.UseGroupRowSelector = true;
			this.grdConveyance.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdConveyance.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdConveyance_ColumnButtonClick);
			this.grdConveyance.DoubleClick += new System.EventHandler(this.grdConveyance_DoubleClick);
			this.grdConveyance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdConveyance_KeyDown);
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
			this.grdCargo.GroupRowFormatStyle.FontName = "Tahoma";
			this.grdCargo.GroupRowFormatStyle.FontSize = 9F;
			this.grdCargo.GroupRowFormatStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(130)))), ((int)(((byte)(70)))));
			this.grdCargo.Hierarchical = true;
			this.grdCargo.Location = new System.Drawing.Point(0, 25);
			this.grdCargo.Name = "grdCargo";
			this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdCargo.Size = new System.Drawing.Size(992, 470);
			this.grdCargo.TabIndex = 1;
			this.grdCargo.Tag = "21, 74, 147";
			this.grdCargo.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdCargo.UseGroupRowSelector = true;
			this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdCargo.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdCargo_RowCheckStateChanged);
			this.grdCargo.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCargo_FormattingRow);
			this.grdCargo.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_ColumnButtonClick);
			this.grdCargo.SelectionChanged += new System.EventHandler(this.grdCargo_SelectionChanged);
			this.grdCargo.FilterApplied += new System.EventHandler(this.grdCargo_FilterApplied);
			this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
			this.grdCargo.DoubleClick += new System.EventHandler(this.grdCargo_DoubleClick);
			this.grdCargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCargo_KeyDown);
			// 
			// infDockMgr
			// 
			this.infDockMgr.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2007;
			this.infDockMgr.CompressUnpinnedTabs = false;
			dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
			dockAreaPane1.DockedBefore = new System.Guid("6ad67918-a499-4aa3-bbdf-0cea5fe6020a");
			dockableControlPane1.Control = this.pnlSearchParams;
			dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(23, 46, 884, 124);
			dockableControlPane1.Size = new System.Drawing.Size(100, 100);
			dockableControlPane1.Text = "Search Options";
			dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
			dockAreaPane1.Size = new System.Drawing.Size(992, 148);
			dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.SlidingGroup;
			dockAreaPane2.DockedBefore = new System.Guid("9c0f5999-c155-4544-ad2e-fe14ea41dca3");
			dockAreaPane2.FloatingLocation = new System.Drawing.Point(121, 685);
			dockAreaPane2.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.True;
			dockAreaPane2.Size = new System.Drawing.Size(992, 148);
			dockAreaPane3.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
			dockAreaPane3.DockedBefore = new System.Guid("8422e57d-2f84-44ef-b875-5f9709e230cc");
			dockAreaPane3.FloatingLocation = new System.Drawing.Point(121, 685);
			dockableControlPane2.Control = this.pnlCargo;
			dockableControlPane2.FlyoutSize = new System.Drawing.Size(-1, 367);
			dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(310, 216, 682, 347);
			dockableControlPane2.Size = new System.Drawing.Size(100, 100);
			dockableControlPane2.Text = "pnlCargo";
			dockableControlPane3.Control = this.grdConveyance;
			dockableControlPane3.FlyoutSize = new System.Drawing.Size(-1, 179);
			dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(142, 231, 717, 454);
			appearance6.FontData.Name = "Arial";
			appearance6.FontData.SizeInPoints = 10F;
			dockableControlPane3.Settings.CaptionAppearance = appearance6;
			appearance7.FontData.Name = "Arial";
			appearance7.FontData.SizeInPoints = 10F;
			dockableControlPane3.Settings.HotTrackingTabAppearance = appearance7;
			appearance8.FontData.BoldAsString = "True";
			appearance8.FontData.Name = "Arial";
			appearance8.FontData.SizeInPoints = 10F;
			dockableControlPane3.Settings.TabAppearance = appearance8;
			dockableControlPane3.Size = new System.Drawing.Size(100, 98);
			dockableControlPane3.Text = "Conveyances";
			dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2,
            dockableControlPane3});
			dockAreaPane3.Size = new System.Drawing.Size(992, 538);
			dockAreaPane3.UnfilledSize = new System.Drawing.Size(992, 148);
			dockAreaPane4.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.TabGroup;
			dockAreaPane4.FloatingLocation = new System.Drawing.Point(82, 404);
			dockAreaPane4.Size = new System.Drawing.Size(992, 385);
			dockAreaPane4.UnfilledSize = new System.Drawing.Size(100, 95);
			this.infDockMgr.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3,
            dockAreaPane4});
			this.infDockMgr.HostControl = this;
			this.infDockMgr.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
			this.infDockMgr.ShowCloseButton = false;
			this.infDockMgr.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2007;
			// 
			// _frmChildBaseUnpinnedTabAreaLeft
			// 
			this._frmChildBaseUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this._frmChildBaseUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 25);
			this._frmChildBaseUnpinnedTabAreaLeft.Name = "_frmChildBaseUnpinnedTabAreaLeft";
			this._frmChildBaseUnpinnedTabAreaLeft.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 691);
			this._frmChildBaseUnpinnedTabAreaLeft.TabIndex = 7;
			// 
			// _frmChildBaseUnpinnedTabAreaRight
			// 
			this._frmChildBaseUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
			this._frmChildBaseUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaRight.Location = new System.Drawing.Point(992, 25);
			this._frmChildBaseUnpinnedTabAreaRight.Name = "_frmChildBaseUnpinnedTabAreaRight";
			this._frmChildBaseUnpinnedTabAreaRight.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 691);
			this._frmChildBaseUnpinnedTabAreaRight.TabIndex = 8;
			// 
			// _frmChildBaseUnpinnedTabAreaTop
			// 
			this._frmChildBaseUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
			this._frmChildBaseUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 25);
			this._frmChildBaseUnpinnedTabAreaTop.Name = "_frmChildBaseUnpinnedTabAreaTop";
			this._frmChildBaseUnpinnedTabAreaTop.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaTop.Size = new System.Drawing.Size(992, 0);
			this._frmChildBaseUnpinnedTabAreaTop.TabIndex = 9;
			// 
			// _frmChildBaseUnpinnedTabAreaBottom
			// 
			this._frmChildBaseUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._frmChildBaseUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 695);
			this._frmChildBaseUnpinnedTabAreaBottom.Name = "_frmChildBaseUnpinnedTabAreaBottom";
			this._frmChildBaseUnpinnedTabAreaBottom.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaBottom.Size = new System.Drawing.Size(992, 0);
			this._frmChildBaseUnpinnedTabAreaBottom.TabIndex = 10;
			// 
			// _frmChildBaseAutoHideControl
			// 
			this._frmChildBaseAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseAutoHideControl.Location = new System.Drawing.Point(0, 323);
			this._frmChildBaseAutoHideControl.Name = "_frmChildBaseAutoHideControl";
			this._frmChildBaseAutoHideControl.Owner = this.infDockMgr;
			this._frmChildBaseAutoHideControl.Size = new System.Drawing.Size(992, 372);
			this._frmChildBaseAutoHideControl.TabIndex = 11;
			// 
			// dockableWindow1
			// 
			this.dockableWindow1.Controls.Add(this.grdConveyance);
			this.dockableWindow1.Location = new System.Drawing.Point(-10000, 0);
			this.dockableWindow1.Name = "dockableWindow1";
			this.dockableWindow1.Owner = this.infDockMgr;
			this.dockableWindow1.Size = new System.Drawing.Size(992, 515);
			this.dockableWindow1.TabIndex = 52;
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
			this.infToolbar.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Fade;
			this.infToolbar.MiniToolbar.ToolRowCount = 1;
			this.infToolbar.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.infToolbar.ShowFullMenusDelay = 500;
			this.infToolbar.ShowMenuShadows = Infragistics.Win.DefaultableBoolean.True;
			this.infToolbar.ShowQuickCustomizeButton = false;
			this.infToolbar.ShowShortcutsInToolTips = true;
			this.infToolbar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			buttonTool10.InstanceProps.IsFirstInGroup = true;
			buttonTool1.InstanceProps.IsFirstInGroup = true;
			popupMenuTool10.InstanceProps.IsFirstInGroup = true;
			ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool10,
            buttonTool11,
            buttonTool1,
            popupMenuTool10,
            popupMenuTool4});
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
			buttonTool9.SharedPropsInternal.Caption = "Create Futile Conveyance";
			buttonTool9.SharedPropsInternal.Category = "ConveyanceActions";
			buttonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
			buttonTool12.SharedPropsInternal.Caption = "Remove Highlighted from Conveyance";
			buttonTool12.SharedPropsInternal.Category = "AddRemove";
			buttonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
			buttonTool12.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			buttonTool12.SharedPropsInternal.Visible = false;
			buttonTool13.SharedPropsInternal.Caption = "Remove Checked Cargo from Conveyance(s)";
			buttonTool13.SharedPropsInternal.Category = "AddRemove";
			buttonTool13.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
			buttonTool13.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			popupMenuTool1.SharedPropsInternal.Caption = "Add/Remove";
			popupMenuTool1.SharedPropsInternal.Category = "AddRemove";
			popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15,
            buttonTool16,
            buttonTool18});
			buttonTool4.SharedPropsInternal.Caption = "Edit Conveyance #/Type";
			buttonTool4.SharedPropsInternal.Category = "EditConveyance";
			buttonTool17.SharedPropsInternal.Caption = "Add to Conveyance";
			buttonTool17.SharedPropsInternal.Category = "AddRemove";
			popupMenuTool3.SharedPropsInternal.Caption = "Cargo Actions";
			popupMenuTool3.SharedPropsInternal.Category = "CargoActions";
			popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool5,
            buttonTool6});
			buttonTool8.SharedPropsInternal.Caption = "In Gate";
			buttonTool8.SharedPropsInternal.Category = "CargoActions";
			buttonTool14.SharedPropsInternal.Caption = "POD Stamp";
			buttonTool14.SharedPropsInternal.Category = "CargoActions";
			buttonTool19.SharedPropsInternal.Caption = "T1";
			buttonTool19.SharedPropsInternal.Category = "CargoActions";
			popupMenuTool5.SharedPropsInternal.Caption = "Undo Actions";
			popupMenuTool5.SharedPropsInternal.Category = "UndoActions";
			popupMenuTool5.SharedPropsInternal.Visible = false;
			popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool6,
            popupMenuTool8});
			popupMenuTool7.SharedPropsInternal.Caption = "Undo Conveyance Actions";
			popupMenuTool7.SharedPropsInternal.Category = "UndoActions";
			popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool31});
			popupMenuTool9.SharedPropsInternal.Caption = "Undo Cargo Actions";
			popupMenuTool9.SharedPropsInternal.Category = "UndoActions";
			popupMenuTool9.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool21,
            buttonTool22,
            buttonTool23});
			buttonTool25.SharedPropsInternal.Caption = "Undo InGate";
			buttonTool25.SharedPropsInternal.Category = "UndoActions";
			buttonTool26.SharedPropsInternal.Caption = "Undo POD Stamp";
			buttonTool26.SharedPropsInternal.Category = "UndoActions";
			buttonTool27.SharedPropsInternal.Caption = "Undo T1";
			buttonTool27.SharedPropsInternal.Category = "UndoActions";
			popupMenuTool11.SharedPropsInternal.Caption = "Actions";
			popupMenuTool11.SharedPropsInternal.Category = "Actions";
			popupMenuTool11.SharedPropsInternal.Visible = false;
			popupMenuTool11.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool12,
            popupMenuTool13});
			popupMenuTool14.SharedPropsInternal.Caption = "Conveyance Actions";
			popupMenuTool14.SharedPropsInternal.Category = "ConveyanceActions";
			popupMenuTool14.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool29});
			buttonTool30.SharedPropsInternal.Caption = "Arrived at Pickup";
			buttonTool32.SharedPropsInternal.Caption = "Undo Arrive at Pickup";
			buttonTool32.SharedPropsInternal.Category = "UndoActions";
			this.infToolbar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool12,
            buttonTool13,
            popupMenuTool1,
            buttonTool4,
            buttonTool17,
            popupMenuTool3,
            buttonTool8,
            buttonTool14,
            buttonTool19,
            popupMenuTool5,
            popupMenuTool7,
            popupMenuTool9,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            popupMenuTool11,
            popupMenuTool14,
            buttonTool30,
            buttonTool32});
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
			// dockableWindow2
			// 
			this.dockableWindow2.Controls.Add(this.pnlSearchParams);
			this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
			this.dockableWindow2.Name = "dockableWindow2";
			this.dockableWindow2.Owner = this.infDockMgr;
			this.dockableWindow2.Size = new System.Drawing.Size(992, 148);
			this.dockableWindow2.TabIndex = 50;
			// 
			// pnlCargo
			// 
			// 
			// pnlCargo.ClientArea
			// 
			this.pnlCargo.ClientArea.Controls.Add(this.grdCargo);
			this.pnlCargo.ClientArea.Controls.Add(this.tbrCargoActions);
			this.pnlCargo.Location = new System.Drawing.Point(0, 18);
			this.pnlCargo.Name = "pnlCargo";
			this.pnlCargo.Size = new System.Drawing.Size(992, 495);
			this.pnlCargo.TabIndex = 29;
			this.pnlCargo.PaintClient += new System.Windows.Forms.PaintEventHandler(this.pnlCargo_PaintClient);
			// 
			// tbrCargoActions
			// 
			this.tbrCargoActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbCargoGroupBy,
            this.tbbCargoOnlyAvail});
			this.tbrCargoActions.Location = new System.Drawing.Point(0, 0);
			this.tbrCargoActions.Name = "tbrCargoActions";
			this.tbrCargoActions.Size = new System.Drawing.Size(992, 25);
			this.tbrCargoActions.TabIndex = 2;
			this.tbrCargoActions.Text = "toolStrip1";
			// 
			// tbbCargoGroupBy
			// 
			this.tbbCargoGroupBy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCargoGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbCargoGroupByNone,
            this.tbbCargoGroupByFromTo,
            this.tbbCargoGroupByTruck});
			this.tbbCargoGroupBy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCargoGroupBy.Name = "tbbCargoGroupBy";
			this.tbbCargoGroupBy.Size = new System.Drawing.Size(72, 22);
			this.tbbCargoGroupBy.Text = "Group By";
			// 
			// tbbCargoGroupByNone
			// 
			this.tbbCargoGroupByNone.Checked = true;
			this.tbbCargoGroupByNone.CheckOnClick = true;
			this.tbbCargoGroupByNone.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tbbCargoGroupByNone.Name = "tbbCargoGroupByNone";
			this.tbbCargoGroupByNone.Size = new System.Drawing.Size(139, 22);
			this.tbbCargoGroupByNone.Text = "None";
			// 
			// tbbCargoGroupByFromTo
			// 
			this.tbbCargoGroupByFromTo.CheckOnClick = true;
			this.tbbCargoGroupByFromTo.Name = "tbbCargoGroupByFromTo";
			this.tbbCargoGroupByFromTo.Size = new System.Drawing.Size(139, 22);
			this.tbbCargoGroupByFromTo.Text = "From/To";
			// 
			// tbbCargoGroupByTruck
			// 
			this.tbbCargoGroupByTruck.CheckOnClick = true;
			this.tbbCargoGroupByTruck.Name = "tbbCargoGroupByTruck";
			this.tbbCargoGroupByTruck.Size = new System.Drawing.Size(139, 22);
			this.tbbCargoGroupByTruck.Text = "Truck";
			// 
			// tbbCargoOnlyAvail
			// 
			this.tbbCargoOnlyAvail.Checked = true;
			this.tbbCargoOnlyAvail.CheckOnClick = true;
			this.tbbCargoOnlyAvail.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tbbCargoOnlyAvail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCargoOnlyAvail.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCargoOnlyAvail.Name = "tbbCargoOnlyAvail";
			this.tbbCargoOnlyAvail.Size = new System.Drawing.Size(92, 22);
			this.tbbCargoOnlyAvail.Text = "Only Available";
			// 
			// windowDockingArea3
			// 
			this.windowDockingArea3.Controls.Add(this.dockableWindow2);
			this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Top;
			this.windowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowDockingArea3.Location = new System.Drawing.Point(0, 25);
			this.windowDockingArea3.Name = "windowDockingArea3";
			this.windowDockingArea3.Owner = this.infDockMgr;
			this.windowDockingArea3.Size = new System.Drawing.Size(992, 153);
			this.windowDockingArea3.TabIndex = 36;
			// 
			// windowDockingArea1
			// 
			this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowDockingArea1.Location = new System.Drawing.Point(4, 4);
			this.windowDockingArea1.Name = "windowDockingArea1";
			this.windowDockingArea1.Owner = this.infDockMgr;
			this.windowDockingArea1.Size = new System.Drawing.Size(992, 148);
			this.windowDockingArea1.TabIndex = 0;
			// 
			// windowDockingArea4
			// 
			this.windowDockingArea4.Controls.Add(this.dockableWindow3);
			this.windowDockingArea4.Controls.Add(this.dockableWindow1);
			this.windowDockingArea4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowDockingArea4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowDockingArea4.Location = new System.Drawing.Point(0, 178);
			this.windowDockingArea4.Name = "windowDockingArea4";
			this.windowDockingArea4.Owner = this.infDockMgr;
			this.windowDockingArea4.Size = new System.Drawing.Size(992, 538);
			this.windowDockingArea4.TabIndex = 45;
			// 
			// dockableWindow3
			// 
			this.dockableWindow3.Controls.Add(this.pnlCargo);
			this.dockableWindow3.Location = new System.Drawing.Point(0, 0);
			this.dockableWindow3.Name = "dockableWindow3";
			this.dockableWindow3.Owner = this.infDockMgr;
			this.dockableWindow3.Size = new System.Drawing.Size(992, 515);
			this.dockableWindow3.TabIndex = 51;
			// 
			// windowDockingArea5
			// 
			this.windowDockingArea5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowDockingArea5.Location = new System.Drawing.Point(4, 4);
			this.windowDockingArea5.Name = "windowDockingArea5";
			this.windowDockingArea5.Owner = this.infDockMgr;
			this.windowDockingArea5.Size = new System.Drawing.Size(992, 385);
			this.windowDockingArea5.TabIndex = 0;
			// 
			// frmConveyanceManagerAlt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this._frmChildBaseAutoHideControl);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaLeft);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaRight);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaTop);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaBottom);
			this.Controls.Add(this.windowDockingArea4);
			this.Controls.Add(this.windowDockingArea3);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._frmChildBase_Toolbars_Dock_Area_Bottom);
			this.KeyPreview = true;
			this.Name = "frmConveyanceManagerAlt";
			this.Text = "Alternate Vendor Window";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConveyanceManagerAlt_FormClosing);
			this.Load += new System.EventHandler(this.frmConveyanceManagerAlt_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConveyanceManagerAlt_KeyDown);
			this.pnlSearchParams.ClientArea.ResumeLayout(false);
			this.pnlSearchParams.ClientArea.PerformLayout();
			this.pnlSearchParams.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbMove)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdConveyance)).EndInit();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).EndInit();
			this.dockableWindow1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.infToolbar)).EndInit();
			this.dockableWindow2.ResumeLayout(false);
			this.pnlCargo.ClientArea.ResumeLayout(false);
			this.pnlCargo.ClientArea.PerformLayout();
			this.pnlCargo.ResumeLayout(false);
			this.tbrCargoActions.ResumeLayout(false);
			this.tbrCargoActions.PerformLayout();
			this.windowDockingArea3.ResumeLayout(false);
			this.windowDockingArea4.ResumeLayout(false);
			this.dockableWindow3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private CommonWinCtrls.ucGridEx grdCargo;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private WinCtrls.ucLocationCheckBoxCombo cmbDest;
		private WinCtrls.ucLocationCheckBoxCombo cmbOrig;
		private WinCtrls.ucMoveCombo cmbMove;
		private WinCtrls.ucVendorCombo cmbVendor;
		private Infragistics.Win.UltraWinDock.UltraDockManager infDockMgr;
		private Infragistics.Win.UltraWinDock.AutoHideControl _frmChildBaseAutoHideControl;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaLeft;
		private CommonWinCtrls.ucGridEx grdConveyance;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager infToolbar;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmChildBase_Toolbars_Dock_Area_Bottom;
		private CommonWinCtrls.ucTextBox txtVoyageNo;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private WinCtrls.ucCargoStatusCheckBoxCombo cmbCargoStatus;
		private WinCtrls.ucLocationCheckBoxCombo cmbLastLoc;
		private System.Windows.Forms.CheckBox chkOnlyAvailable;
		private Infragistics.Win.Misc.UltraButton btnReset;
		private CommonWinCtrls.ucDateGroupBox grpSailDt;
		private Infragistics.Win.Misc.UltraPanel pnlSearchParams;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
		private Infragistics.Win.Misc.UltraPanel pnlCargo;
		private System.Windows.Forms.ToolStrip tbrCargoActions;
		private System.Windows.Forms.ToolStripDropDownButton tbbCargoGroupBy;
		private System.Windows.Forms.ToolStripMenuItem tbbCargoGroupByNone;
		private System.Windows.Forms.ToolStripMenuItem tbbCargoGroupByFromTo;
		private System.Windows.Forms.ToolStripMenuItem tbbCargoGroupByTruck;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private System.Windows.Forms.ToolStripButton tbbCargoOnlyAvail;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea4;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow3;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea5;
	}
}