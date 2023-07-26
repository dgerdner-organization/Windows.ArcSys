namespace CS2010.ArcSys.Win
{
    partial class frmEDITranslation
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout cmbSelectInterface_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDITranslation));
            Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbInterface_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbField_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.cmbSelectInterface = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
            this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
            this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
            this.grpEdit = new CS2010.CommonWinCtrls.ucGroupBox();
            this.cmbInterface = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbField = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
            this.txtExportCode = new CS2010.CommonWinCtrls.ucTextBox();
            this.Save = new CS2010.CommonWinCtrls.ucButton();
            this.txtImportCode = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtDbCode = new CS2010.CommonWinCtrls.ucTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSelectInterface)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Control;
            appearance1.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.Appearance = appearance1;
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            appearance2.BackColor2 = System.Drawing.SystemColors.Control;
            this.grpSearch.ContentAreaAppearance = appearance2;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 68);
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance3;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance4;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(992, 68);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.Text = "Search Options";
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.cmbSelectInterface);
            this.grpSearchPanel.Controls.Add(this.btnClear);
            this.grpSearchPanel.Controls.Add(this.btnSearch);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(986, 44);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // cmbSelectInterface
            // 
            cmbSelectInterface_DesignTimeLayout.LayoutString = resources.GetString("cmbSelectInterface_DesignTimeLayout.LayoutString");
            this.cmbSelectInterface.DesignTimeLayout = cmbSelectInterface_DesignTimeLayout;
            this.cmbSelectInterface.DisplayMember = "interface_cd";
            this.cmbSelectInterface.LabelText = "Select an Interface";
            this.cmbSelectInterface.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbSelectInterface.Location = new System.Drawing.Point(133, 14);
            this.cmbSelectInterface.Name = "cmbSelectInterface";
            this.cmbSelectInterface.SelectedIndex = -1;
            this.cmbSelectInterface.SelectedItem = null;
            this.cmbSelectInterface.Size = new System.Drawing.Size(196, 20);
            this.cmbSelectInterface.TabIndex = 16;
            this.cmbSelectInterface.ValueMember = "edi_interface_id";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnClear.Location = new System.Drawing.Point(593, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(512, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 68);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(992, 631);
            this.tabMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 605);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.AllowDrop = true;
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(3, 3);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grdMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.btnDelete);
            this.splitMain.Panel2.Controls.Add(this.btnEdit);
            this.splitMain.Panel2.Controls.Add(this.btnAdd);
            this.splitMain.Panel2.Controls.Add(this.grpEdit);
            this.splitMain.Size = new System.Drawing.Size(978, 599);
            this.splitMain.SplitterDistance = 523;
            this.splitMain.TabIndex = 0;
            // 
            // grdMain
            // 
            this.grdMain.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdMain.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
            this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
            this.grdMain.DisplayFieldChooser = true;
            this.grdMain.DisplayFieldChooserChildren = true;
            this.grdMain.DisplayFontSelector = true;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.ExportFileID = null;
            this.grdMain.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdMain.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdMain.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdMain.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdMain.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdMain.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdMain.Hierarchical = true;
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.Name = "grdMain";
            this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMain.Size = new System.Drawing.Size(521, 597);
            this.grdMain.TabIndex = 2;
            this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(179, 208);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(20, 209);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(99, 208);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.cmbInterface);
            this.grpEdit.Controls.Add(this.cmbField);
            this.grpEdit.Controls.Add(this.btnCancel);
            this.grpEdit.Controls.Add(this.txtExportCode);
            this.grpEdit.Controls.Add(this.Save);
            this.grpEdit.Controls.Add(this.txtImportCode);
            this.grpEdit.Controls.Add(this.txtDbCode);
            this.grpEdit.Location = new System.Drawing.Point(20, 13);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(392, 190);
            this.grpEdit.TabIndex = 0;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit Translation Code";
            // 
            // cmbInterface
            // 
            cmbInterface_DesignTimeLayout.LayoutString = resources.GetString("cmbInterface_DesignTimeLayout.LayoutString");
            this.cmbInterface.DesignTimeLayout = cmbInterface_DesignTimeLayout;
            this.cmbInterface.DisplayMember = "interface_cd";
            this.cmbInterface.Enabled = false;
            this.cmbInterface.LabelText = "Interface";
            this.cmbInterface.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbInterface.Location = new System.Drawing.Point(92, 23);
            this.cmbInterface.Name = "cmbInterface";
            this.cmbInterface.SelectedIndex = -1;
            this.cmbInterface.SelectedItem = null;
            this.cmbInterface.Size = new System.Drawing.Size(196, 20);
            this.cmbInterface.TabIndex = 15;
            this.cmbInterface.ValueMember = "edi_interface_id";
            // 
            // cmbField
            // 
            cmbField_DesignTimeLayout.LayoutString = resources.GetString("cmbField_DesignTimeLayout.LayoutString");
            this.cmbField.DesignTimeLayout = cmbField_DesignTimeLayout;
            this.cmbField.DisplayMember = "field_nm";
            this.cmbField.LabelText = "Field";
            this.cmbField.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbField.Location = new System.Drawing.Point(92, 49);
            this.cmbField.Name = "cmbField";
            this.cmbField.SelectedIndex = -1;
            this.cmbField.SelectedItem = null;
            this.cmbField.Size = new System.Drawing.Size(196, 20);
            this.cmbField.TabIndex = 14;
            this.cmbField.ValueMember = "edi_field_id";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(291, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtExportCode
            // 
            this.txtExportCode.LabelText = "Export Code";
            this.txtExportCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtExportCode.LinkDisabledMessage = "Link Disabled";
            this.txtExportCode.Location = new System.Drawing.Point(92, 128);
            this.txtExportCode.Name = "txtExportCode";
            this.txtExportCode.Size = new System.Drawing.Size(100, 20);
            this.txtExportCode.TabIndex = 2;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(213, 125);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtImportCode
            // 
            this.txtImportCode.LabelText = "Import Code";
            this.txtImportCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtImportCode.LinkDisabledMessage = "Link Disabled";
            this.txtImportCode.Location = new System.Drawing.Point(92, 102);
            this.txtImportCode.Name = "txtImportCode";
            this.txtImportCode.Size = new System.Drawing.Size(100, 20);
            this.txtImportCode.TabIndex = 1;
            // 
            // txtDbCode
            // 
            this.txtDbCode.LabelText = "DB Code";
            this.txtDbCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDbCode.LinkDisabledMessage = "Link Disabled";
            this.txtDbCode.Location = new System.Drawing.Point(92, 76);
            this.txtDbCode.Name = "txtDbCode";
            this.txtDbCode.Size = new System.Drawing.Size(100, 20);
            this.txtDbCode.TabIndex = 0;
            // 
            // frmEDITranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(992, 699);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpSearch);
            this.Name = "frmEDITranslation";
            this.Text = "EDI Translations";
            this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSelectInterface)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInterface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private Infragistics.Win.Misc.UltraButton btnClear;
        private Infragistics.Win.Misc.UltraButton btnSearch;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
        private CommonWinCtrls.ucGridEx grdMain;
        private CommonWinCtrls.ucSplitContainer splitMain;
        private CommonWinCtrls.ucGroupBox grpEdit;
        private CommonWinCtrls.ucTextBox txtExportCode;
        private CommonWinCtrls.ucTextBox txtImportCode;
        private CommonWinCtrls.ucTextBox txtDbCode;
        private CommonWinCtrls.ucButton btnDelete;
        private CommonWinCtrls.ucButton btnEdit;
        private CommonWinCtrls.ucButton btnAdd;
        private CommonWinCtrls.ucButton btnCancel;
        private CommonWinCtrls.ucButton Save;
        private CommonWinCtrls.ucMultiColumnCombo cmbField;
        private CommonWinCtrls.ucMultiColumnCombo cmbInterface;
        private CommonWinCtrls.ucMultiColumnCombo cmbSelectInterface;
	}
}