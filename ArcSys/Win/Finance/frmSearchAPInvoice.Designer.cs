namespace CS2010.ArcSys.Win
{
	partial class frmSearchAPInvoice
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
			Janus.Windows.GridEX.GridEXLayout ucVendorCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAPInvoice));
			Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.txtInvoiceNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucVendorCombo = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.btnSearch = new Infragistics.Win.Misc.UltraButton();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
			this.grpSearch.SuspendLayout();
			this.grpSearchPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucVendorCombo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
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
			this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
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
			this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 116);
			appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance1.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderAppearance = appearance1;
			this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
			appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance2.FontData.SizeInPoints = 11F;
			this.grpSearch.HeaderCollapsedAppearance = appearance2;
			this.grpSearch.Location = new System.Drawing.Point(0, 25);
			this.grpSearch.Name = "grpSearch";
			this.grpSearch.Size = new System.Drawing.Size(992, 116);
			this.grpSearch.TabIndex = 0;
			this.grpSearch.Text = "Search Options";
			this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
			// 
			// grpSearchPanel
			// 
			this.grpSearchPanel.Controls.Add(this.txtInvoiceNo);
			this.grpSearchPanel.Controls.Add(this.ucVendorCombo);
			this.grpSearchPanel.Controls.Add(this.btnClear);
			this.grpSearchPanel.Controls.Add(this.btnSearch);
			this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
			this.grpSearchPanel.Name = "grpSearchPanel";
			this.grpSearchPanel.Size = new System.Drawing.Size(986, 92);
			this.grpSearchPanel.TabIndex = 0;
			// 
			// txtInvoiceNo
			// 
			this.txtInvoiceNo.LabelBackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.txtInvoiceNo.LabelText = "Invoice#";
			this.txtInvoiceNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtInvoiceNo.LinkDisabledMessage = "Link Disabled";
			this.txtInvoiceNo.Location = new System.Drawing.Point(69, 42);
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			this.txtInvoiceNo.Size = new System.Drawing.Size(153, 20);
			this.txtInvoiceNo.TabIndex = 23;
			// 
			// ucVendorCombo
			// 
			this.ucVendorCombo.CodeColumn = "Vendor_Cd";
			this.ucVendorCombo.DescriptionColumn = "Vendor_Nm";
			ucVendorCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVendorCombo_DesignTimeLayout.LayoutString");
			this.ucVendorCombo.DesignTimeLayout = ucVendorCombo_DesignTimeLayout;
			this.ucVendorCombo.DisplayMember = "Vendor_Cd";
			this.ucVendorCombo.LabelBackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ucVendorCombo.LabelText = "Vendor";
			this.ucVendorCombo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.ucVendorCombo.Location = new System.Drawing.Point(69, 15);
			this.ucVendorCombo.Name = "ucVendorCombo";
			this.ucVendorCombo.SelectedIndex = -1;
			this.ucVendorCombo.SelectedItem = null;
			this.ucVendorCombo.Size = new System.Drawing.Size(153, 20);
			this.ucVendorCombo.TabIndex = 22;
			this.ucVendorCombo.ValueColumn = "Vendor_Cd";
			this.ucVendorCombo.ValueMember = "Vendor_Cd";
			// 
			// btnClear
			// 
			this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
			this.btnClear.Location = new System.Drawing.Point(251, 41);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 21;
			this.btnClear.Text = "Clear";
			this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(251, 15);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 20;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
			this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
			this.grdResults.DisplayFieldChooser = true;
			this.grdResults.DisplayFieldChooserChildren = true;
			this.grdResults.DisplayFontSelector = true;
			this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResults.ExportFileID = null;
			this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdResults.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdResults.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdResults.Hierarchical = true;
			this.grdResults.Location = new System.Drawing.Point(0, 141);
			this.grdResults.Name = "grdResults";
			this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdResults.Size = new System.Drawing.Size(992, 575);
			this.grdResults.TabIndex = 1;
			this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_ColumnButtonClick);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
			// 
			// tbrMain
			// 
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(992, 25);
			this.tbrMain.TabIndex = 5;
			this.tbrMain.Text = "toolStrip1";
			// 
			// frmSearchAPInvoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this.grdResults);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmSearchAPInvoice";
			this.Text = "Search AP Invoices";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearchPanel.ResumeLayout(false);
			this.grpSearchPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucVendorCombo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private CommonWinCtrls.ucGridEx grdResults;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTextBox txtInvoiceNo;
		private WinCtrls.ucVendorCombo ucVendorCombo;
	}
}