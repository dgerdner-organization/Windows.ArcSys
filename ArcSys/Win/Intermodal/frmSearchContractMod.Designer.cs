namespace CS2010.ArcSys.Win
{
	partial class frmSearchContractMod
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdResults_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column7.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchContractMod));
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.txtModNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAttachmentNm = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNotes = new CS2010.CommonWinCtrls.ucTextBox();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
			this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
			this.btnClear = new Infragistics.Win.Misc.UltraButton();
			this.btnSearch = new Infragistics.Win.Misc.UltraButton();
			this.grpCreateDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.cnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuGridN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuGridEditMod = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridClearAttached = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridDeleteMod = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuGridCreateMod = new System.Windows.Forms.ToolStripMenuItem();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbAddMod = new System.Windows.Forms.ToolStripButton();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
			this.grpSearch.SuspendLayout();
			this.grpSearchPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			this.cnuGrid.SuspendLayout();
			this.tbrMain.SuspendLayout();
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
			// txtModNo
			// 
			this.txtModNo.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtModNo.LabelText = "&Mod #";
			this.txtModNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtModNo.LinkDisabledMessage = "Link Disabled";
			this.txtModNo.Location = new System.Drawing.Point(56, 12);
			this.txtModNo.Name = "txtModNo";
			this.txtModNo.Size = new System.Drawing.Size(243, 20);
			this.txtModNo.TabIndex = 1;
			// 
			// txtAttachmentNm
			// 
			this.txtAttachmentNm.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtAttachmentNm.LabelText = "&File Name";
			this.txtAttachmentNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAttachmentNm.LinkDisabledMessage = "Link Disabled";
			this.txtAttachmentNm.Location = new System.Drawing.Point(56, 64);
			this.txtAttachmentNm.Name = "txtAttachmentNm";
			this.txtAttachmentNm.Size = new System.Drawing.Size(243, 20);
			this.txtAttachmentNm.TabIndex = 5;
			// 
			// txtNotes
			// 
			this.txtNotes.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtNotes.LabelText = "&Notes";
			this.txtNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNotes.LinkDisabledMessage = "Link Disabled";
			this.txtNotes.Location = new System.Drawing.Point(56, 38);
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(243, 20);
			this.txtNotes.TabIndex = 3;
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
			this.grpSearchPanel.Controls.Add(this.btnClear);
			this.grpSearchPanel.Controls.Add(this.btnSearch);
			this.grpSearchPanel.Controls.Add(this.grpCreateDt);
			this.grpSearchPanel.Controls.Add(this.txtModNo);
			this.grpSearchPanel.Controls.Add(this.txtAttachmentNm);
			this.grpSearchPanel.Controls.Add(this.txtNotes);
			this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
			this.grpSearchPanel.Name = "grpSearchPanel";
			this.grpSearchPanel.Size = new System.Drawing.Size(986, 92);
			this.grpSearchPanel.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
			this.btnClear.Location = new System.Drawing.Point(516, 61);
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
			this.btnSearch.Location = new System.Drawing.Point(516, 35);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 20;
			this.btnSearch.Text = "&Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// grpCreateDt
			// 
			this.grpCreateDt.BackColor = System.Drawing.Color.Transparent;
			this.grpCreateDt.CheckBoxText = "Created";
			this.grpCreateDt.DateFormatDefault = "MM-dd-yyyy";
			this.grpCreateDt.DateFormatEdit = "MMddyy";
			this.grpCreateDt.Location = new System.Drawing.Point(316, 12);
			this.grpCreateDt.Name = "grpCreateDt";
			this.grpCreateDt.Size = new System.Drawing.Size(172, 72);
			this.grpCreateDt.TabIndex = 6;
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdResults.ContextMenuStrip = this.cnuGrid;
			grdResults_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdResults_DesignTimeLayout_Reference_0.Instance")));
			grdResults_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdResults_DesignTimeLayout_Reference_0});
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
			this.grdResults.Size = new System.Drawing.Size(992, 553);
			this.grdResults.TabIndex = 1;
			this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_ColumnButtonClick);
			this.grdResults.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_LinkClicked);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
			// 
			// cnuGrid
			// 
			this.cnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuGridN1,
            this.cnuGridEditMod,
            this.cnuGridClearAttached,
            this.cnuGridDeleteMod,
            this.cnuGridN2,
            this.cnuGridCreateMod});
			this.cnuGrid.Name = "cnuGrid";
			this.cnuGrid.Size = new System.Drawing.Size(185, 126);
			// 
			// cnuGridN1
			// 
			this.cnuGridN1.Name = "cnuGridN1";
			this.cnuGridN1.Size = new System.Drawing.Size(181, 6);
			// 
			// cnuGridEditMod
			// 
			this.cnuGridEditMod.Name = "cnuGridEditMod";
			this.cnuGridEditMod.Size = new System.Drawing.Size(184, 22);
			this.cnuGridEditMod.Text = "Edit Mod";
			this.cnuGridEditMod.Click += new System.EventHandler(this.cnuGridEditMod_Click);
			// 
			// cnuGridClearAttached
			// 
			this.cnuGridClearAttached.Name = "cnuGridClearAttached";
			this.cnuGridClearAttached.Size = new System.Drawing.Size(184, 22);
			this.cnuGridClearAttached.Text = "Remove Attachment";
			this.cnuGridClearAttached.Click += new System.EventHandler(this.cnuGridClearAttached_Click);
			// 
			// cnuGridDeleteMod
			// 
			this.cnuGridDeleteMod.Name = "cnuGridDeleteMod";
			this.cnuGridDeleteMod.Size = new System.Drawing.Size(184, 22);
			this.cnuGridDeleteMod.Text = "Delete Contract Mod";
			this.cnuGridDeleteMod.Click += new System.EventHandler(this.cnuGridDeleteMod_Click);
			// 
			// cnuGridN2
			// 
			this.cnuGridN2.Name = "cnuGridN2";
			this.cnuGridN2.Size = new System.Drawing.Size(181, 6);
			// 
			// cnuGridCreateMod
			// 
			this.cnuGridCreateMod.Name = "cnuGridCreateMod";
			this.cnuGridCreateMod.Size = new System.Drawing.Size(184, 22);
			this.cnuGridCreateMod.Text = "Create New Mod";
			this.cnuGridCreateMod.Click += new System.EventHandler(this.cnuGridCreateMod_Click);
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbAddMod});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(992, 25);
			this.tbrMain.TabIndex = 5;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tbbAddMod
			// 
			this.tbbAddMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbAddMod.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbAddMod.Name = "tbbAddMod";
			this.tbbAddMod.Size = new System.Drawing.Size(67, 22);
			this.tbbAddMod.Text = "Create Mod";
			this.tbbAddMod.Click += new System.EventHandler(this.tbbAddMod_Click);
			// 
			// frmSearchContractMod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this.grdResults);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmSearchContractMod";
			this.Text = "Search Contract Mods";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
			this.grpSearch.ResumeLayout(false);
			this.grpSearchPanel.ResumeLayout(false);
			this.grpSearchPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.cnuGrid.ResumeLayout(false);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private CommonWinCtrls.ucTextBox txtModNo;
		private CommonWinCtrls.ucTextBox txtAttachmentNm;
		private CommonWinCtrls.ucTextBox txtNotes;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private CommonWinCtrls.ucDateGroupBox grpCreateDt;
		private CommonWinCtrls.ucGridEx grdResults;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbAddMod;
		private System.Windows.Forms.ContextMenuStrip cnuGrid;
		private System.Windows.Forms.ToolStripMenuItem cnuGridDeleteMod;
		private System.Windows.Forms.ToolStripMenuItem cnuGridClearAttached;
		private System.Windows.Forms.ToolStripMenuItem cnuGridEditMod;
		private System.Windows.Forms.ToolStripSeparator cnuGridN1;
		private System.Windows.Forms.ToolStripMenuItem cnuGridCreateMod;
		private System.Windows.Forms.ToolStripSeparator cnuGridN2;
	}
}