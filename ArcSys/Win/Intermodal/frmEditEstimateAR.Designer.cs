namespace CS2010.ArcSys.Win
{
	partial class frmEditEstimateAR
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
			Janus.Windows.GridEX.GridEXLayout cmbCustomer_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditEstimateAR));
			Janus.Windows.GridEX.GridEXLayout cmbBasis_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.SuperTipSettings superTipSettings1 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings2 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.GridEX.GridEXLayout cmbCharge_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.SuperTipSettings superTipSettings3 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings4 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings5 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings6 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings7 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings8 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.SuperTipSettings superTipSettings9 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.GridEX.GridEXLayout grdChargeActivities_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.SuperTipSettings superTipSettings10 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.Common.SuperTipSettings superTipSettings11 = new Janus.Windows.Common.SuperTipSettings();
			Janus.Windows.GridEX.GridEXLayout grdAvailableActivities_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedBottom, new System.Guid("569bcec0-bb81-4f1f-83f5-2fd2bab954b5"));
			Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("1af81039-c2f2-41d5-8f0d-8f0a28c6ba50"), new System.Guid("e29a2ba4-f2dd-4574-8731-211aa810248e"), 0, new System.Guid("569bcec0-bb81-4f1f-83f5-2fd2bab954b5"), 0);
			Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("e29a2ba4-f2dd-4574-8731-211aa810248e"));
			this.tabUscRates = new CS2010.ArcSys.WinCtrls.ucUscRates();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbTitle = new System.Windows.Forms.ToolStripLabel();
			this.tbbMainN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbCancel = new System.Windows.Forms.ToolStripButton();
			this.pnlCharge = new CS2010.CommonWinCtrls.ucPanel();
			this.cmbCustomer = new CS2010.ArcSys.WinCtrls.ucCustomerCombo();
			this.cmbBasis = new CS2010.ArcSys.WinCtrls.ucLevelUnitCombo();
			this.numPcsPerCnvy = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.cnuNumericMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuNumericMenuCalculator = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuNumericMenuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuNumericMenuCut = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuNumericMenuN3 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuNumericMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbCharge = new CS2010.ArcSys.WinCtrls.ucChargeTypeCombo();
			this.numLevelCount = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.rtfChargeMemo = new CS2010.CommonWinCtrls.ucRichTextBox();
			this.numTotal = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numUnits = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numRate = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
			this.grdChargeActivities = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlButtons = new CS2010.CommonWinCtrls.ucPanel();
			this.numPcfnCount = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numTcnCount = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.btnAllDtlToAvl = new CS2010.CommonWinCtrls.ucButton();
			this.btnCheckedDtlToAvl = new CS2010.CommonWinCtrls.ucButton();
			this.btnAllAvlToDtl = new CS2010.CommonWinCtrls.ucButton();
			this.btnCheckedAvlToDtl = new CS2010.CommonWinCtrls.ucButton();
			this.grdAvailableActivities = new CS2010.CommonWinCtrls.ucGridEx();
			this.tipJanusMain = new Janus.Windows.Common.JanusSuperTip(this.components);
			this.pnlCargo = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.infPopupContainer = new Infragistics.Win.Misc.UltraPopupControlContainer(this.components);
			this.infDockMgr = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
			this._frmChildBaseUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
			this._frmChildBaseAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
			this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
			this.tbrMain.SuspendLayout();
			this.pnlCharge.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBasis)).BeginInit();
			this.cnuNumericMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCharge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdChargeActivities)).BeginInit();
			this.pnlButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvailableActivities)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlCargo)).BeginInit();
			this.pnlCargo.Panel1.SuspendLayout();
			this.pnlCargo.Panel2.SuspendLayout();
			this.pnlCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).BeginInit();
			this._frmChildBaseAutoHideControl.SuspendLayout();
			this.dockableWindow1.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabUscRates
			// 
			this.tabUscRates.Location = new System.Drawing.Point(0, 18);
			this.tabUscRates.Name = "tabUscRates";
			this.tabUscRates.Size = new System.Drawing.Size(782, 185);
			this.tabUscRates.TabIndex = 5;
			this.tabUscRates.RowCopied += new System.EventHandler(this.tabUscRates_RowCopied);
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbTitle,
            this.tbbMainN1,
            this.tbbSave,
            this.tbbMainN2,
            this.tbbCancel});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(782, 25);
			this.tbrMain.TabIndex = 1;
			this.tbrMain.Text = "toolStrip3";
			// 
			// tbbTitle
			// 
			this.tbbTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.tbbTitle.ForeColor = System.Drawing.Color.DarkGreen;
			this.tbbTitle.Name = "tbbTitle";
			this.tbbTitle.Size = new System.Drawing.Size(227, 22);
			this.tbbTitle.Text = "AR Charge Estimate Data Entry Section";
			// 
			// tbbMainN1
			// 
			this.tbbMainN1.Name = "tbbMainN1";
			this.tbbMainN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(77, 22);
			this.tbbSave.Text = "Save (Ctrl+S)";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbMainN2
			// 
			this.tbbMainN2.Name = "tbbMainN2";
			this.tbbMainN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbCancel
			// 
			this.tbbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCancel.Name = "tbbCancel";
			this.tbbCancel.Size = new System.Drawing.Size(70, 22);
			this.tbbCancel.Text = "Cancel (Esc)";
			this.tbbCancel.Click += new System.EventHandler(this.tbbCancel_Click);
			// 
			// pnlCharge
			// 
			this.pnlCharge.AutoScroll = true;
			this.pnlCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlCharge.Controls.Add(this.cmbCustomer);
			this.pnlCharge.Controls.Add(this.cmbBasis);
			this.pnlCharge.Controls.Add(this.numPcsPerCnvy);
			this.pnlCharge.Controls.Add(this.cmbCharge);
			this.pnlCharge.Controls.Add(this.numLevelCount);
			this.pnlCharge.Controls.Add(this.rtfChargeMemo);
			this.pnlCharge.Controls.Add(this.numTotal);
			this.pnlCharge.Controls.Add(this.numUnits);
			this.pnlCharge.Controls.Add(this.numRate);
			this.pnlCharge.Controls.Add(this.cmbVendor);
			this.pnlCharge.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCharge.Location = new System.Drawing.Point(0, 0);
			this.pnlCharge.Name = "pnlCharge";
			this.pnlCharge.Size = new System.Drawing.Size(782, 101);
			this.pnlCharge.TabIndex = 0;
			// 
			// cmbCustomer
			// 
			this.cmbCustomer.CodeColumn = "Customer_Cd";
			this.cmbCustomer.DescriptionColumn = "Customer_Nm";
			cmbCustomer_DesignTimeLayout.LayoutString = resources.GetString("cmbCustomer_DesignTimeLayout.LayoutString");
			this.cmbCustomer.DesignTimeLayout = cmbCustomer_DesignTimeLayout;
			this.cmbCustomer.DisplayMember = "Customer_Cd";
			this.cmbCustomer.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.cmbCustomer.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbCustomer.LabelText = "Customer";
			this.cmbCustomer.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCustomer.Location = new System.Drawing.Point(574, 16);
			this.cmbCustomer.Name = "cmbCustomer";
			this.cmbCustomer.SelectedIndex = -1;
			this.cmbCustomer.SelectedItem = null;
			this.cmbCustomer.Size = new System.Drawing.Size(194, 20);
			this.cmbCustomer.TabIndex = 15;
			this.cmbCustomer.ValueColumn = "Customer_Cd";
			this.cmbCustomer.ValueMember = "Customer_Cd";
			this.cmbCustomer.Visible = false;
			// 
			// cmbBasis
			// 
			this.cmbBasis.CodeColumn = "Level_Unit_ID";
			this.cmbBasis.DescriptionColumn = "Level_Unit_Dsc";
			cmbBasis_DesignTimeLayout.LayoutString = resources.GetString("cmbBasis_DesignTimeLayout.LayoutString");
			this.cmbBasis.DesignTimeLayout = cmbBasis_DesignTimeLayout;
			this.cmbBasis.DisplayMember = "Level_Unit_Dsc";
			this.cmbBasis.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbBasis.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.cmbBasis.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbBasis.LabelText = "Rate Basis";
			this.cmbBasis.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbBasis.Location = new System.Drawing.Point(273, 16);
			this.cmbBasis.Name = "cmbBasis";
			this.cmbBasis.SelectedIndex = -1;
			this.cmbBasis.SelectedItem = null;
			this.cmbBasis.Size = new System.Drawing.Size(233, 20);
			superTipSettings1.HeaderText = "Rate Basis";
			superTipSettings1.ImageListProvider = null;
			superTipSettings1.Text = resources.GetString("superTipSettings1.Text");
			this.tipJanusMain.SetSuperTip(this.cmbBasis, superTipSettings1);
			this.cmbBasis.TabIndex = 3;
			this.cmbBasis.ValueColumn = "Level_Unit_ID";
			this.cmbBasis.ValueMember = "Level_Unit_ID";
			this.cmbBasis.ValueChanged += new System.EventHandler(this.cmbBasis_ValueChanged);
			// 
			// numPcsPerCnvy
			// 
			this.numPcsPerCnvy.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numPcsPerCnvy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numPcsPerCnvy.ContextMenuStrip = this.cnuNumericMenu;
			this.numPcsPerCnvy.DecimalDigits = 0;
			this.numPcsPerCnvy.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numPcsPerCnvy.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numPcsPerCnvy.LabelBackColor = System.Drawing.Color.Transparent;
			this.numPcsPerCnvy.LabelText = "Pcs/Cnvy";
			this.numPcsPerCnvy.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numPcsPerCnvy.Location = new System.Drawing.Point(119, 55);
			this.numPcsPerCnvy.Name = "numPcsPerCnvy";
			this.numPcsPerCnvy.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numPcsPerCnvy.Size = new System.Drawing.Size(46, 20);
			superTipSettings2.HeaderText = "Pieces Per Conveyance";
			superTipSettings2.ImageListProvider = null;
			this.tipJanusMain.SetSuperTip(this.numPcsPerCnvy, superTipSettings2);
			this.numPcsPerCnvy.TabIndex = 7;
			this.numPcsPerCnvy.Value = null;
			this.numPcsPerCnvy.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
			this.numPcsPerCnvy.Visible = false;
			this.numPcsPerCnvy.ValueChanged += new System.EventHandler(this.numPcsPerCnvy_ValueChanged);
			// 
			// cnuNumericMenu
			// 
			this.cnuNumericMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuNumericMenuCalculator,
            this.cnuNumericMenuN1,
            this.cnuNumericMenuUndo,
            this.cnuNumericMenuN2,
            this.cnuNumericMenuCut,
            this.cnuNumericMenuCopy,
            this.cnuNumericMenuPaste,
            this.cnuNumericMenuDelete,
            this.cnuNumericMenuN3,
            this.cnuNumericMenuSelectAll});
			this.cnuNumericMenu.Name = "cnuNumericMenu";
			this.cnuNumericMenu.Size = new System.Drawing.Size(134, 176);
			this.cnuNumericMenu.Opened += new System.EventHandler(this.cnuNumericMenu_Opened);
			// 
			// cnuNumericMenuCalculator
			// 
			this.cnuNumericMenuCalculator.Name = "cnuNumericMenuCalculator";
			this.cnuNumericMenuCalculator.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuCalculator.Text = "Calculator";
			this.cnuNumericMenuCalculator.Click += new System.EventHandler(this.cnuNumericMenuCalculator_Click);
			// 
			// cnuNumericMenuN1
			// 
			this.cnuNumericMenuN1.Name = "cnuNumericMenuN1";
			this.cnuNumericMenuN1.Size = new System.Drawing.Size(130, 6);
			// 
			// cnuNumericMenuUndo
			// 
			this.cnuNumericMenuUndo.Name = "cnuNumericMenuUndo";
			this.cnuNumericMenuUndo.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuUndo.Text = "Undo";
			this.cnuNumericMenuUndo.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cnuNumericMenuN2
			// 
			this.cnuNumericMenuN2.Name = "cnuNumericMenuN2";
			this.cnuNumericMenuN2.Size = new System.Drawing.Size(130, 6);
			// 
			// cnuNumericMenuCut
			// 
			this.cnuNumericMenuCut.Name = "cnuNumericMenuCut";
			this.cnuNumericMenuCut.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuCut.Text = "Cut";
			this.cnuNumericMenuCut.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cnuNumericMenuCopy
			// 
			this.cnuNumericMenuCopy.Name = "cnuNumericMenuCopy";
			this.cnuNumericMenuCopy.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuCopy.Text = "Copy";
			this.cnuNumericMenuCopy.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cnuNumericMenuPaste
			// 
			this.cnuNumericMenuPaste.Name = "cnuNumericMenuPaste";
			this.cnuNumericMenuPaste.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuPaste.Text = "Paste";
			this.cnuNumericMenuPaste.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cnuNumericMenuDelete
			// 
			this.cnuNumericMenuDelete.Name = "cnuNumericMenuDelete";
			this.cnuNumericMenuDelete.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuDelete.Text = "Delete";
			this.cnuNumericMenuDelete.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cnuNumericMenuN3
			// 
			this.cnuNumericMenuN3.Name = "cnuNumericMenuN3";
			this.cnuNumericMenuN3.Size = new System.Drawing.Size(130, 6);
			// 
			// cnuNumericMenuSelectAll
			// 
			this.cnuNumericMenuSelectAll.Name = "cnuNumericMenuSelectAll";
			this.cnuNumericMenuSelectAll.Size = new System.Drawing.Size(133, 22);
			this.cnuNumericMenuSelectAll.Text = "Select All";
			this.cnuNumericMenuSelectAll.Click += new System.EventHandler(this.cnuNumericMenuEditCommands_Click);
			// 
			// cmbCharge
			// 
			this.cmbCharge.CodeColumn = "Charge_Type_Cd";
			this.cmbCharge.DescriptionColumn = "Charge_Type_Dsc";
			cmbCharge_DesignTimeLayout.LayoutString = resources.GetString("cmbCharge_DesignTimeLayout.LayoutString");
			this.cmbCharge.DesignTimeLayout = cmbCharge_DesignTimeLayout;
			this.cmbCharge.DisplayMember = "Charge_Type_Dsc";
			this.cmbCharge.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbCharge.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.cmbCharge.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbCharge.LabelText = "Charge";
			this.cmbCharge.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCharge.Location = new System.Drawing.Point(8, 16);
			this.cmbCharge.Name = "cmbCharge";
			this.cmbCharge.SelectedIndex = -1;
			this.cmbCharge.SelectedItem = null;
			this.cmbCharge.Size = new System.Drawing.Size(256, 20);
			superTipSettings3.HeaderText = "Charge Type";
			superTipSettings3.ImageListProvider = null;
			superTipSettings3.Text = "The type of charge being entered (Security, Linehaul, Washing, etc.)";
			this.tipJanusMain.SetSuperTip(this.cmbCharge, superTipSettings3);
			this.cmbCharge.TabIndex = 1;
			this.cmbCharge.ValueColumn = "Charge_Type_Cd";
			this.cmbCharge.ValueMember = "Charge_Type_Cd";
			this.cmbCharge.ValueChanged += new System.EventHandler(this.cmbCharge_ValueChanged);
			// 
			// numLevelCount
			// 
			this.numLevelCount.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numLevelCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numLevelCount.ContextMenuStrip = this.cnuNumericMenu;
			this.numLevelCount.DecimalDigits = 0;
			this.numLevelCount.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numLevelCount.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numLevelCount.LabelBackColor = System.Drawing.Color.Transparent;
			this.numLevelCount.LabelText = "Count";
			this.numLevelCount.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numLevelCount.Location = new System.Drawing.Point(171, 55);
			this.numLevelCount.MaxLength = 10;
			this.numLevelCount.Name = "numLevelCount";
			this.numLevelCount.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numLevelCount.Size = new System.Drawing.Size(67, 20);
			superTipSettings4.HeaderText = "Level Count";
			superTipSettings4.ImageListProvider = null;
			superTipSettings4.Text = "Used with the Level field to describe how many items we are rating for a given Le" +
				"vel. For example if Count is 3 and Level is PCFN, then we are adding a per PCFN " +
				"charge for 3 PCFNs.";
			this.tipJanusMain.SetSuperTip(this.numLevelCount, superTipSettings4);
			this.numLevelCount.TabIndex = 9;
			this.numLevelCount.Tag = "117 wid, at 374";
			this.numLevelCount.Value = null;
			this.numLevelCount.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
			this.numLevelCount.ValueChanged += new System.EventHandler(this.numLevelCount_ValueChanged);
			// 
			// rtfChargeMemo
			// 
			this.rtfChargeMemo.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.rtfChargeMemo.LabelText = "Memo";
			this.rtfChargeMemo.Location = new System.Drawing.Point(512, 42);
			this.rtfChargeMemo.Name = "rtfChargeMemo";
			this.rtfChargeMemo.Size = new System.Drawing.Size(256, 33);
			superTipSettings5.HeaderText = "Memo";
			superTipSettings5.ImageListProvider = null;
			superTipSettings5.Text = "Additional information that can be added describing the charge.";
			this.tipJanusMain.SetSuperTip(this.rtfChargeMemo, superTipSettings5);
			this.rtfChargeMemo.TabIndex = 17;
			this.rtfChargeMemo.Text = "Add Optional Memo Here";
			this.rtfChargeMemo.Enter += new System.EventHandler(this.rtfChargeMemo_Enter);
			this.rtfChargeMemo.Leave += new System.EventHandler(this.rtfChargeMemo_Leave);
			this.rtfChargeMemo.Validated += new System.EventHandler(this.rtfChargeMemo_Validated);
			// 
			// numTotal
			// 
			this.numTotal.BackColor = System.Drawing.SystemColors.Control;
			this.numTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numTotal.ForeColor = System.Drawing.Color.Black;
			this.numTotal.FormatString = "c";
			this.numTotal.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numTotal.LabelBackColor = System.Drawing.Color.Transparent;
			this.numTotal.LabelText = "Total";
			this.numTotal.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numTotal.Location = new System.Drawing.Point(370, 55);
			this.numTotal.Name = "numTotal";
			this.numTotal.ReadOnly = true;
			this.numTotal.Size = new System.Drawing.Size(136, 20);
			superTipSettings6.HeaderText = "Total Amount";
			superTipSettings6.ImageListProvider = null;
			superTipSettings6.Text = "The total amount for the charge being entered. It is computed by multiplying the " +
				"Count, Rate, and Units fields.";
			this.tipJanusMain.SetSuperTip(this.numTotal, superTipSettings6);
			this.numTotal.TabIndex = 13;
			this.numTotal.TabStop = false;
			this.numTotal.Text = "$0.00";
			this.numTotal.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// numUnits
			// 
			this.numUnits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numUnits.ContextMenuStrip = this.cnuNumericMenu;
			this.numUnits.DecimalDigits = 5;
			this.numUnits.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numUnits.FormatString = "#.#####";
			this.numUnits.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numUnits.LabelBackColor = System.Drawing.Color.Transparent;
			this.numUnits.LabelText = "Units";
			this.numUnits.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numUnits.Location = new System.Drawing.Point(244, 55);
			this.numUnits.Name = "numUnits";
			this.numUnits.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numUnits.Size = new System.Drawing.Size(120, 20);
			superTipSettings7.HeaderText = "Unit Quantity";
			superTipSettings7.ImageListProvider = null;
			superTipSettings7.Text = resources.GetString("superTipSettings7.Text");
			this.tipJanusMain.SetSuperTip(this.numUnits, superTipSettings7);
			this.numUnits.TabIndex = 11;
			this.numUnits.Value = null;
			this.numUnits.ValueChanged += new System.EventHandler(this.numUnits_ValueChanged);
			// 
			// numRate
			// 
			this.numRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numRate.ContextMenuStrip = this.cnuNumericMenu;
			this.numRate.DecimalDigits = 5;
			this.numRate.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numRate.FormatString = "#,##0.00###";
			this.numRate.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numRate.LabelBackColor = System.Drawing.Color.Transparent;
			this.numRate.LabelText = "Rate";
			this.numRate.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numRate.Location = new System.Drawing.Point(8, 55);
			this.numRate.Name = "numRate";
			this.numRate.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numRate.Size = new System.Drawing.Size(105, 20);
			superTipSettings8.HeaderText = "Rate";
			superTipSettings8.ImageListProvider = null;
			superTipSettings8.Text = "The rate for the given charge";
			this.tipJanusMain.SetSuperTip(this.numRate, superTipSettings8);
			this.numRate.TabIndex = 5;
			this.numRate.Value = null;
			this.numRate.ValueChanged += new System.EventHandler(this.numRate_ValueChanged);
			// 
			// cmbVendor
			// 
			this.cmbVendor.CodeColumn = "Vendor_Cd";
			this.cmbVendor.DescriptionColumn = "Vendor_Nm";
			cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
			this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
			this.cmbVendor.DisplayMember = "Vendor_Nm";
			this.cmbVendor.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbVendor.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.cmbVendor.LabelBackColor = System.Drawing.Color.Transparent;
			this.cmbVendor.LabelText = "Vendor";
			this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendor.Location = new System.Drawing.Point(512, 16);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.SelectedIndex = -1;
			this.cmbVendor.SelectedItem = null;
			this.cmbVendor.Size = new System.Drawing.Size(256, 20);
			superTipSettings9.HeaderText = "Vendor";
			superTipSettings9.ImageListProvider = null;
			superTipSettings9.Text = "The vendor who performed that activity that we are entering a charge for.";
			this.tipJanusMain.SetSuperTip(this.cmbVendor, superTipSettings9);
			this.cmbVendor.TabIndex = 15;
			this.cmbVendor.ValueColumn = "Vendor_Cd";
			this.cmbVendor.ValueMember = "Vendor_Cd";
			this.cmbVendor.ValueChanged += new System.EventHandler(this.cmbVendor_ValueChanged);
			this.cmbVendor.Validated += new System.EventHandler(this.cmbVendor_ValueChanged);
			// 
			// grdChargeActivities
			// 
			this.grdChargeActivities.AllowDrop = true;
			this.grdChargeActivities.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdChargeActivities.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdChargeActivities_DesignTimeLayout.LayoutString = resources.GetString("grdChargeActivities_DesignTimeLayout.LayoutString");
			this.grdChargeActivities.DesignTimeLayout = grdChargeActivities_DesignTimeLayout;
			this.grdChargeActivities.DisplayFieldChooser = true;
			this.grdChargeActivities.DisplayFieldChooserChildren = true;
			this.grdChargeActivities.DisplayFontSelector = true;
			this.grdChargeActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdChargeActivities.ExportFileID = null;
			this.grdChargeActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdChargeActivities.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
			this.grdChargeActivities.GroupTotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.grdChargeActivities.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
			this.grdChargeActivities.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
			this.grdChargeActivities.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdChargeActivities.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdChargeActivities.Location = new System.Drawing.Point(53, 0);
			this.grdChargeActivities.Name = "grdChargeActivities";
			this.grdChargeActivities.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this.grdChargeActivities.Size = new System.Drawing.Size(300, 409);
			this.grdChargeActivities.TabIndex = 2;
			this.grdChargeActivities.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdChargeActivities.ThemedAreas = ((Janus.Windows.GridEX.ThemedArea)(((((((((Janus.Windows.GridEX.ThemedArea.ScrollBars | Janus.Windows.GridEX.ThemedArea.EditControls)
						| Janus.Windows.GridEX.ThemedArea.Headers)
						| Janus.Windows.GridEX.ThemedArea.GroupByBox)
						| Janus.Windows.GridEX.ThemedArea.TreeGliphs)
						| Janus.Windows.GridEX.ThemedArea.ControlBorder)
						| Janus.Windows.GridEX.ThemedArea.Cards)
						| Janus.Windows.GridEX.ThemedArea.Gridlines)
						| Janus.Windows.GridEX.ThemedArea.CheckBoxes)));
			this.grdChargeActivities.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdChargeActivities.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdChargeActivities.UseGroupRowSelector = true;
			this.grdChargeActivities.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdChargeActivities_RowCheckStateChanged);
			this.grdChargeActivities.RowDrag += new Janus.Windows.GridEX.RowDragEventHandler(this.grd_RowDrag);
			this.grdChargeActivities.GroupsChanged += new Janus.Windows.GridEX.GroupsChangedEventHandler(this.grd_GroupsChanged);
			this.grdChargeActivities.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
			this.grdChargeActivities.DragDrop += new System.Windows.Forms.DragEventHandler(this.grd_DragDrop);
			this.grdChargeActivities.DragEnter += new System.Windows.Forms.DragEventHandler(this.grd_DragEnter);
			this.grdChargeActivities.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
			this.grdChargeActivities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_KeyDown);
			// 
			// pnlButtons
			// 
			this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlButtons.Controls.Add(this.numPcfnCount);
			this.pnlButtons.Controls.Add(this.numTcnCount);
			this.pnlButtons.Controls.Add(this.btnAllDtlToAvl);
			this.pnlButtons.Controls.Add(this.btnCheckedDtlToAvl);
			this.pnlButtons.Controls.Add(this.btnAllAvlToDtl);
			this.pnlButtons.Controls.Add(this.btnCheckedAvlToDtl);
			this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlButtons.Location = new System.Drawing.Point(0, 0);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(53, 409);
			this.pnlButtons.TabIndex = 1;
			// 
			// numPcfnCount
			// 
			this.numPcfnCount.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numPcfnCount.BackColor = System.Drawing.SystemColors.Control;
			this.numPcfnCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numPcfnCount.DecimalDigits = 0;
			this.numPcfnCount.ForeColor = System.Drawing.Color.Black;
			this.numPcfnCount.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numPcfnCount.LabelBackColor = System.Drawing.Color.Transparent;
			this.numPcfnCount.LabelText = "PCFNs";
			this.numPcfnCount.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numPcfnCount.Location = new System.Drawing.Point(8, 365);
			this.numPcfnCount.Name = "numPcfnCount";
			this.numPcfnCount.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numPcfnCount.ReadOnly = true;
			this.numPcfnCount.Size = new System.Drawing.Size(36, 20);
			superTipSettings10.HeaderText = "TCN Count";
			superTipSettings10.ImageListProvider = null;
			superTipSettings10.Text = "Total number of TCNs selected for this charge.";
			this.tipJanusMain.SetSuperTip(this.numPcfnCount, superTipSettings10);
			this.numPcfnCount.TabIndex = 6;
			this.numPcfnCount.TabStop = false;
			this.numPcfnCount.Value = null;
			this.numPcfnCount.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64;
			// 
			// numTcnCount
			// 
			this.numTcnCount.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numTcnCount.BackColor = System.Drawing.SystemColors.Control;
			this.numTcnCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numTcnCount.DecimalDigits = 0;
			this.numTcnCount.ForeColor = System.Drawing.Color.Black;
			this.numTcnCount.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.numTcnCount.LabelBackColor = System.Drawing.Color.Transparent;
			this.numTcnCount.LabelText = "TCNs";
			this.numTcnCount.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numTcnCount.Location = new System.Drawing.Point(8, 327);
			this.numTcnCount.Name = "numTcnCount";
			this.numTcnCount.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numTcnCount.ReadOnly = true;
			this.numTcnCount.Size = new System.Drawing.Size(36, 20);
			superTipSettings11.HeaderText = "TCN Count";
			superTipSettings11.ImageListProvider = null;
			superTipSettings11.Text = "Total number of TCNs selected for this charge.";
			this.tipJanusMain.SetSuperTip(this.numTcnCount, superTipSettings11);
			this.numTcnCount.TabIndex = 4;
			this.numTcnCount.TabStop = false;
			this.numTcnCount.Value = null;
			this.numTcnCount.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64;
			this.numTcnCount.ValueChanged += new System.EventHandler(this.numTcnCount_ValueChanged);
			// 
			// btnAllDtlToAvl
			// 
			this.btnAllDtlToAvl.Location = new System.Drawing.Point(8, 234);
			this.btnAllDtlToAvl.Name = "btnAllDtlToAvl";
			this.btnAllDtlToAvl.Size = new System.Drawing.Size(36, 23);
			this.btnAllDtlToAvl.TabIndex = 3;
			this.btnAllDtlToAvl.Text = "<<";
			this.btnAllDtlToAvl.UseVisualStyleBackColor = true;
			this.btnAllDtlToAvl.Click += new System.EventHandler(this.btnAllToLeft_Click);
			// 
			// btnCheckedDtlToAvl
			// 
			this.btnCheckedDtlToAvl.Location = new System.Drawing.Point(8, 203);
			this.btnCheckedDtlToAvl.Name = "btnCheckedDtlToAvl";
			this.btnCheckedDtlToAvl.Size = new System.Drawing.Size(36, 23);
			this.btnCheckedDtlToAvl.TabIndex = 2;
			this.btnCheckedDtlToAvl.Text = "<";
			this.btnCheckedDtlToAvl.UseVisualStyleBackColor = true;
			this.btnCheckedDtlToAvl.Click += new System.EventHandler(this.btnCheckedDtlToAvl_Click);
			// 
			// btnAllAvlToDtl
			// 
			this.btnAllAvlToDtl.Location = new System.Drawing.Point(8, 159);
			this.btnAllAvlToDtl.Name = "btnAllAvlToDtl";
			this.btnAllAvlToDtl.Size = new System.Drawing.Size(36, 23);
			this.btnAllAvlToDtl.TabIndex = 1;
			this.btnAllAvlToDtl.Text = ">>";
			this.btnAllAvlToDtl.UseVisualStyleBackColor = true;
			this.btnAllAvlToDtl.Click += new System.EventHandler(this.btnAllToRight_Click);
			// 
			// btnCheckedAvlToDtl
			// 
			this.btnCheckedAvlToDtl.Location = new System.Drawing.Point(8, 128);
			this.btnCheckedAvlToDtl.Name = "btnCheckedAvlToDtl";
			this.btnCheckedAvlToDtl.Size = new System.Drawing.Size(36, 23);
			this.btnCheckedAvlToDtl.TabIndex = 0;
			this.btnCheckedAvlToDtl.Text = ">";
			this.btnCheckedAvlToDtl.UseVisualStyleBackColor = true;
			this.btnCheckedAvlToDtl.Click += new System.EventHandler(this.btnCheckedAvlToDtl_Click);
			// 
			// grdAvailableActivities
			// 
			this.grdAvailableActivities.AllowDrop = true;
			this.grdAvailableActivities.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdAvailableActivities.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdAvailableActivities_DesignTimeLayout.LayoutString = resources.GetString("grdAvailableActivities_DesignTimeLayout.LayoutString");
			this.grdAvailableActivities.DesignTimeLayout = grdAvailableActivities_DesignTimeLayout;
			this.grdAvailableActivities.DisplayFieldChooser = true;
			this.grdAvailableActivities.DisplayFieldChooserChildren = true;
			this.grdAvailableActivities.DisplayFontSelector = true;
			this.grdAvailableActivities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAvailableActivities.ExportFileID = null;
			this.grdAvailableActivities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdAvailableActivities.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
			this.grdAvailableActivities.GroupTotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
			this.grdAvailableActivities.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
			this.grdAvailableActivities.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
			this.grdAvailableActivities.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvailableActivities.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdAvailableActivities.Location = new System.Drawing.Point(0, 0);
			this.grdAvailableActivities.Name = "grdAvailableActivities";
			this.grdAvailableActivities.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this.grdAvailableActivities.Size = new System.Drawing.Size(423, 409);
			this.grdAvailableActivities.TabIndex = 0;
			this.grdAvailableActivities.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdAvailableActivities.Tag = "";
			this.grdAvailableActivities.ThemedAreas = ((Janus.Windows.GridEX.ThemedArea)(((((((((Janus.Windows.GridEX.ThemedArea.ScrollBars | Janus.Windows.GridEX.ThemedArea.EditControls)
						| Janus.Windows.GridEX.ThemedArea.Headers)
						| Janus.Windows.GridEX.ThemedArea.GroupByBox)
						| Janus.Windows.GridEX.ThemedArea.TreeGliphs)
						| Janus.Windows.GridEX.ThemedArea.ControlBorder)
						| Janus.Windows.GridEX.ThemedArea.Cards)
						| Janus.Windows.GridEX.ThemedArea.Gridlines)
						| Janus.Windows.GridEX.ThemedArea.CheckBoxes)));
			this.grdAvailableActivities.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvailableActivities.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdAvailableActivities.UseGroupRowSelector = true;
			this.grdAvailableActivities.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdAvailableActivities_RowCheckStateChanged);
			this.grdAvailableActivities.RowDrag += new Janus.Windows.GridEX.RowDragEventHandler(this.grd_RowDrag);
			this.grdAvailableActivities.GroupsChanged += new Janus.Windows.GridEX.GroupsChangedEventHandler(this.grd_GroupsChanged);
			this.grdAvailableActivities.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grd_LinkClicked);
			this.grdAvailableActivities.DragDrop += new System.Windows.Forms.DragEventHandler(this.grd_DragDrop);
			this.grdAvailableActivities.DragEnter += new System.Windows.Forms.DragEventHandler(this.grd_DragEnter);
			this.grdAvailableActivities.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
			this.grdAvailableActivities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grd_KeyDown);
			// 
			// tipJanusMain
			// 
			this.tipJanusMain.AutoPopDelay = 4000;
			this.tipJanusMain.ImageList = null;
			this.tipJanusMain.InitialDelay = 2000;
			// 
			// pnlCargo
			// 
			this.pnlCargo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlCargo.Location = new System.Drawing.Point(0, 101);
			this.pnlCargo.Name = "pnlCargo";
			// 
			// pnlCargo.Panel1
			// 
			this.pnlCargo.Panel1.Controls.Add(this.grdAvailableActivities);
			// 
			// pnlCargo.Panel2
			// 
			this.pnlCargo.Panel2.Controls.Add(this.grdChargeActivities);
			this.pnlCargo.Panel2.Controls.Add(this.pnlButtons);
			this.pnlCargo.Size = new System.Drawing.Size(782, 409);
			this.pnlCargo.SplitterDistance = 423;
			this.pnlCargo.SplitterWidth = 6;
			this.pnlCargo.TabIndex = 3;
			// 
			// infPopupContainer
			// 
			this.infPopupContainer.PreferredDropDownSize = new System.Drawing.Size(0, 0);
			// 
			// infDockMgr
			// 
			this.infDockMgr.CompressUnpinnedTabs = false;
			dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
			dockAreaPane1.DockedBefore = new System.Guid("e29a2ba4-f2dd-4574-8731-211aa810248e");
			dockAreaPane1.FloatingLocation = new System.Drawing.Point(304, 331);
			dockableControlPane1.Control = this.tabUscRates;
			dockableControlPane1.FlyoutSize = new System.Drawing.Size(-1, 203);
			dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(139, 119, 548, 402);
			dockableControlPane1.Pinned = false;
			dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
			dockableControlPane1.Size = new System.Drawing.Size(100, 100);
			dockableControlPane1.Text = "USC Rates";
			dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
			dockAreaPane1.Size = new System.Drawing.Size(782, 265);
			dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
			dockAreaPane2.FloatingLocation = new System.Drawing.Point(304, 331);
			dockAreaPane2.Size = new System.Drawing.Size(490, 393);
			this.infDockMgr.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2});
			this.infDockMgr.HostControl = this;
			// 
			// _frmChildBaseUnpinnedTabAreaLeft
			// 
			this._frmChildBaseUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this._frmChildBaseUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 25);
			this._frmChildBaseUnpinnedTabAreaLeft.Name = "_frmChildBaseUnpinnedTabAreaLeft";
			this._frmChildBaseUnpinnedTabAreaLeft.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 531);
			this._frmChildBaseUnpinnedTabAreaLeft.TabIndex = 7;
			// 
			// _frmChildBaseUnpinnedTabAreaRight
			// 
			this._frmChildBaseUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
			this._frmChildBaseUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaRight.Location = new System.Drawing.Point(782, 25);
			this._frmChildBaseUnpinnedTabAreaRight.Name = "_frmChildBaseUnpinnedTabAreaRight";
			this._frmChildBaseUnpinnedTabAreaRight.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 531);
			this._frmChildBaseUnpinnedTabAreaRight.TabIndex = 8;
			// 
			// _frmChildBaseUnpinnedTabAreaTop
			// 
			this._frmChildBaseUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
			this._frmChildBaseUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 25);
			this._frmChildBaseUnpinnedTabAreaTop.Name = "_frmChildBaseUnpinnedTabAreaTop";
			this._frmChildBaseUnpinnedTabAreaTop.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaTop.Size = new System.Drawing.Size(782, 0);
			this._frmChildBaseUnpinnedTabAreaTop.TabIndex = 9;
			// 
			// _frmChildBaseUnpinnedTabAreaBottom
			// 
			this._frmChildBaseUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._frmChildBaseUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 535);
			this._frmChildBaseUnpinnedTabAreaBottom.Name = "_frmChildBaseUnpinnedTabAreaBottom";
			this._frmChildBaseUnpinnedTabAreaBottom.Owner = this.infDockMgr;
			this._frmChildBaseUnpinnedTabAreaBottom.Size = new System.Drawing.Size(782, 21);
			this._frmChildBaseUnpinnedTabAreaBottom.TabIndex = 10;
			// 
			// _frmChildBaseAutoHideControl
			// 
			this._frmChildBaseAutoHideControl.Controls.Add(this.dockableWindow1);
			this._frmChildBaseAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._frmChildBaseAutoHideControl.Location = new System.Drawing.Point(0, 327);
			this._frmChildBaseAutoHideControl.Name = "_frmChildBaseAutoHideControl";
			this._frmChildBaseAutoHideControl.Owner = this.infDockMgr;
			this._frmChildBaseAutoHideControl.Size = new System.Drawing.Size(782, 208);
			this._frmChildBaseAutoHideControl.TabIndex = 11;
			// 
			// dockableWindow1
			// 
			this.dockableWindow1.Controls.Add(this.tabUscRates);
			this.dockableWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dockableWindow1.Location = new System.Drawing.Point(0, 5);
			this.dockableWindow1.Name = "dockableWindow1";
			this.dockableWindow1.Owner = this.infDockMgr;
			this.dockableWindow1.Size = new System.Drawing.Size(782, 203);
			this.dockableWindow1.TabIndex = 14;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlCargo);
			this.pnlMain.Controls.Add(this.pnlCharge);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(782, 510);
			this.pnlMain.TabIndex = 13;
			// 
			// windowDockingArea2
			// 
			this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.windowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowDockingArea2.Location = new System.Drawing.Point(0, 265);
			this.windowDockingArea2.Name = "windowDockingArea2";
			this.windowDockingArea2.Owner = this.infDockMgr;
			this.windowDockingArea2.Size = new System.Drawing.Size(782, 270);
			this.windowDockingArea2.TabIndex = 0;
			// 
			// windowDockingArea3
			// 
			this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windowDockingArea3.Location = new System.Drawing.Point(0, 348);
			this.windowDockingArea3.Name = "windowDockingArea3";
			this.windowDockingArea3.Owner = this.infDockMgr;
			this.windowDockingArea3.Size = new System.Drawing.Size(490, 393);
			this.windowDockingArea3.TabIndex = 14;
			// 
			// frmEditEstimateAR
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 556);
			this.Controls.Add(this._frmChildBaseAutoHideControl);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaLeft);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaTop);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaRight);
			this.Controls.Add(this.windowDockingArea2);
			this.Controls.Add(this._frmChildBaseUnpinnedTabAreaBottom);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmEditEstimateAR";
			this.Text = "Add/Edit Estimated Revenue";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditEstimateAR_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditEstimateAR_FormClosed);
			this.Load += new System.EventHandler(this.frmEditEstimateAR_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditEstimateAR_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlCharge.ResumeLayout(false);
			this.pnlCharge.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBasis)).EndInit();
			this.cnuNumericMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbCharge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdChargeActivities)).EndInit();
			this.pnlButtons.ResumeLayout(false);
			this.pnlButtons.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvailableActivities)).EndInit();
			this.pnlCargo.Panel1.ResumeLayout(false);
			this.pnlCargo.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlCargo)).EndInit();
			this.pnlCargo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.infDockMgr)).EndInit();
			this._frmChildBaseAutoHideControl.ResumeLayout(false);
			this.dockableWindow1.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripLabel tbbTitle;
		private System.Windows.Forms.ToolStripSeparator tbbMainN1;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripButton tbbCancel;
		private System.Windows.Forms.ToolStripSeparator tbbMainN2;
		private CommonWinCtrls.ucPanel pnlCharge;
		private CommonWinCtrls.ucRichTextBox rtfChargeMemo;
		private CommonWinCtrls.ucNumericEditBox numTotal;
		private CommonWinCtrls.ucNumericEditBox numUnits;
		private CommonWinCtrls.ucNumericEditBox numRate;
		private WinCtrls.ucVendorCombo cmbVendor;
		private CommonWinCtrls.ucPanel pnlButtons;
		private CommonWinCtrls.ucButton btnAllDtlToAvl;
		private CommonWinCtrls.ucButton btnCheckedDtlToAvl;
		private CommonWinCtrls.ucButton btnAllAvlToDtl;
		private CommonWinCtrls.ucButton btnCheckedAvlToDtl;
		private CommonWinCtrls.ucGridEx grdChargeActivities;
		private CommonWinCtrls.ucGridEx grdAvailableActivities;
		private CommonWinCtrls.ucNumericEditBox numLevelCount;
		private WinCtrls.ucChargeTypeCombo cmbCharge;
		private Janus.Windows.Common.JanusSuperTip tipJanusMain;
		private CommonWinCtrls.ucNumericEditBox numPcsPerCnvy;
		private CommonWinCtrls.ucNumericEditBox numTcnCount;
		private CommonWinCtrls.ucNumericEditBox numPcfnCount;
		private WinCtrls.ucLevelUnitCombo cmbBasis;
		private CommonWinCtrls.ucSplitContainer pnlCargo;
		private Infragistics.Win.Misc.UltraPopupControlContainer infPopupContainer;
		private System.Windows.Forms.ContextMenuStrip cnuNumericMenu;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuCalculator;
		private System.Windows.Forms.ToolStripSeparator cnuNumericMenuN1;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuCut;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuCopy;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuPaste;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuSelectAll;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuUndo;
		private System.Windows.Forms.ToolStripSeparator cnuNumericMenuN2;
		private System.Windows.Forms.ToolStripMenuItem cnuNumericMenuDelete;
		private System.Windows.Forms.ToolStripSeparator cnuNumericMenuN3;
		private WinCtrls.ucCustomerCombo cmbCustomer;
		private WinCtrls.ucUscRates tabUscRates;
		private Infragistics.Win.UltraWinDock.UltraDockManager infDockMgr;
		private System.Windows.Forms.Panel pnlMain;
		private Infragistics.Win.UltraWinDock.AutoHideControl _frmChildBaseAutoHideControl;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _frmChildBaseUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
	}
}