namespace CS2010.ArcSys.Win
{
	partial class frmEditChargeType
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditChargeType));
			Janus.Windows.GridEX.GridEXLayout cmbArBasis_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbApBasis_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbCategory_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
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
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.cmbArBasis = new CS2010.ArcSys.WinCtrls.ucLevelUnitCombo();
			this.cmbApBasis = new CS2010.ArcSys.WinCtrls.ucLevelUnitCombo();
			this.cmbCategory = new CS2010.ArcSys.WinCtrls.ucChargeCategoryCombo();
			this.chkActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbArBasis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbApBasis)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).BeginInit();
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
			this.tbrMain.Size = new System.Drawing.Size(782, 25);
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
			// txtDesc
			// 
			this.txtDesc.LabelText = "Description";
			this.txtDesc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDesc.LinkDisabledMessage = "Link Disabled";
			this.txtDesc.Location = new System.Drawing.Point(104, 38);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(317, 20);
			this.txtDesc.TabIndex = 4;
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "Charge Type Code";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.LinkDisabledMessage = "Link Disabled";
			this.txtCode.Location = new System.Drawing.Point(104, 12);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(317, 20);
			this.txtCode.TabIndex = 1;
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
			this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdResults.GroupByBoxVisible = false;
			this.grdResults.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdResults.Location = new System.Drawing.Point(0, 0);
			this.grdResults.Name = "grdResults";
			this.grdResults.Size = new System.Drawing.Size(782, 383);
			this.grdResults.TabIndex = 0;
			this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
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
			this.pnlMain.Panel2.Controls.Add(this.cmbArBasis);
			this.pnlMain.Panel2.Controls.Add(this.cmbApBasis);
			this.pnlMain.Panel2.Controls.Add(this.cmbCategory);
			this.pnlMain.Panel2.Controls.Add(this.chkActive);
			this.pnlMain.Panel2.Controls.Add(this.txtCode);
			this.pnlMain.Panel2.Controls.Add(this.txtDesc);
			this.pnlMain.Size = new System.Drawing.Size(782, 531);
			this.pnlMain.SplitterDistance = 383;
			this.pnlMain.TabIndex = 1;
			// 
			// cmbArBasis
			// 
			this.cmbArBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbArBasis.CodeColumn = "Level_Unit_ID";
			this.cmbArBasis.DescriptionColumn = "Level_Unit_Dsc";
			cmbArBasis_DesignTimeLayout.LayoutString = resources.GetString("cmbArBasis_DesignTimeLayout.LayoutString");
			this.cmbArBasis.DesignTimeLayout = cmbArBasis_DesignTimeLayout;
			this.cmbArBasis.DisplayMember = "Level_Unit_Dsc";
			this.cmbArBasis.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbArBasis.LabelText = "Default Basis AR";
			this.cmbArBasis.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbArBasis.Location = new System.Drawing.Point(104, 116);
			this.cmbArBasis.Name = "cmbArBasis";
			this.cmbArBasis.SelectedIndex = -1;
			this.cmbArBasis.SelectedItem = null;
			this.cmbArBasis.Size = new System.Drawing.Size(317, 20);
			this.cmbArBasis.TabIndex = 10;
			this.cmbArBasis.ValueColumn = "Level_Unit_ID";
			this.cmbArBasis.ValueMember = "Level_Unit_ID";
			// 
			// cmbApBasis
			// 
			this.cmbApBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbApBasis.CodeColumn = "Level_Unit_ID";
			this.cmbApBasis.DescriptionColumn = "Level_Unit_Dsc";
			cmbApBasis_DesignTimeLayout.LayoutString = resources.GetString("cmbApBasis_DesignTimeLayout.LayoutString");
			this.cmbApBasis.DesignTimeLayout = cmbApBasis_DesignTimeLayout;
			this.cmbApBasis.DisplayMember = "Level_Unit_Dsc";
			this.cmbApBasis.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbApBasis.LabelText = "Default Basis AP";
			this.cmbApBasis.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbApBasis.Location = new System.Drawing.Point(104, 90);
			this.cmbApBasis.Name = "cmbApBasis";
			this.cmbApBasis.SelectedIndex = -1;
			this.cmbApBasis.SelectedItem = null;
			this.cmbApBasis.Size = new System.Drawing.Size(317, 20);
			this.cmbApBasis.TabIndex = 8;
			this.cmbApBasis.ValueColumn = "Level_Unit_ID";
			this.cmbApBasis.ValueMember = "Level_Unit_ID";
			// 
			// cmbCategory
			// 
			this.cmbCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbCategory.CodeColumn = "Charge_Category_Cd";
			this.cmbCategory.DescriptionColumn = "Charge_Category_Dsc";
			cmbCategory_DesignTimeLayout.LayoutString = resources.GetString("cmbCategory_DesignTimeLayout.LayoutString");
			this.cmbCategory.DesignTimeLayout = cmbCategory_DesignTimeLayout;
			this.cmbCategory.DisplayMember = "Charge_Category_Dsc";
			this.cmbCategory.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbCategory.LabelText = "Category";
			this.cmbCategory.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCategory.Location = new System.Drawing.Point(104, 64);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.SelectedIndex = -1;
			this.cmbCategory.SelectedItem = null;
			this.cmbCategory.Size = new System.Drawing.Size(317, 20);
			this.cmbCategory.TabIndex = 6;
			this.cmbCategory.ValueColumn = "Charge_Category_Cd";
			this.cmbCategory.ValueMember = "Charge_Category_Cd";
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Location = new System.Drawing.Point(427, 12);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(56, 17);
			this.chkActive.TabIndex = 2;
			this.chkActive.Text = "Acti&ve";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.YN = "N";
			// 
			// frmEditChargeType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 556);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmEditChargeType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Charge Type Maintenance";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceWindow_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceWindow_FormClosed);
			this.Load += new System.EventHandler(this.MaintenanceWindow_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceWindow_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			this.pnlMain.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbArBasis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbApBasis)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).EndInit();
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
		private WinCtrls.ucChargeCategoryCombo cmbCategory;
		private WinCtrls.ucLevelUnitCombo cmbArBasis;
		private WinCtrls.ucLevelUnitCombo cmbApBasis;
	}
}