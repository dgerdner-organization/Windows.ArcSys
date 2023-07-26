namespace CS2010.ArcSys.Win
{
	partial class frmSearchMemo
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
			Janus.Windows.Common.Layouts.JanusLayoutReference grdResults_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column6.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMemo));
			Janus.Windows.Common.Layouts.JanusLayoutReference grdResults_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.ChildTables.Table0.Columns.Column4.ButtonImage");
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.txtMemoDsc = new CS2010.CommonWinCtrls.ucTextBox();
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
			this.cnuGridEditMemo = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridClearAttached = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridDeleteMemo = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuGridCreateMemo = new System.Windows.Forms.ToolStripMenuItem();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbAddMemo = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbAddAttachment = new System.Windows.Forms.ToolStripButton();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
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
			// txtMemoDsc
			// 
			this.txtMemoDsc.LabelBackColor = System.Drawing.Color.Transparent;
			this.txtMemoDsc.LabelText = "&Desc";
			this.txtMemoDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMemoDsc.LinkDisabledMessage = "Link Disabled";
			this.txtMemoDsc.Location = new System.Drawing.Point(56, 12);
			this.txtMemoDsc.Name = "txtMemoDsc";
			this.txtMemoDsc.Size = new System.Drawing.Size(243, 20);
			this.txtMemoDsc.TabIndex = 1;
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
			this.txtNotes.LabelText = "&Body";
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
			this.grpSearchPanel.Controls.Add(this.txtMemoDsc);
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
			this.grpCreateDt.ValueRange = ((CS2010.Common.DateRange)(new CS2010.Common.DateRange(null, null)));
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdResults.ContextMenuStrip = this.cnuGrid;
			grdResults_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdResults_DesignTimeLayout_Reference_0.Instance")));
			grdResults_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("grdResults_DesignTimeLayout_Reference_1.Instance")));
			grdResults_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdResults_DesignTimeLayout_Reference_0,
            grdResults_DesignTimeLayout_Reference_1});
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
			this.grdResults.Size = new System.Drawing.Size(992, 575);
			this.grdResults.TabIndex = 1;
			this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			this.grdResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this.grdResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_ColumnButtonClick);
			this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
			this.grdResults.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_LinkClicked);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
			// 
			// cnuGrid
			// 
			this.cnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuGridN1,
            this.cnuGridEditMemo,
            this.cnuGridClearAttached,
            this.cnuGridDeleteMemo,
            this.cnuGridN2,
            this.cnuGridCreateMemo});
			this.cnuGrid.Name = "cnuGrid";
			this.cnuGrid.Size = new System.Drawing.Size(184, 104);
			// 
			// cnuGridN1
			// 
			this.cnuGridN1.Name = "cnuGridN1";
			this.cnuGridN1.Size = new System.Drawing.Size(180, 6);
			// 
			// cnuGridEditMemo
			// 
			this.cnuGridEditMemo.Name = "cnuGridEditMemo";
			this.cnuGridEditMemo.Size = new System.Drawing.Size(183, 22);
			this.cnuGridEditMemo.Text = "Edit Memo";
			this.cnuGridEditMemo.Click += new System.EventHandler(this.cnuGridEditMemo_Click);
			// 
			// cnuGridClearAttached
			// 
			this.cnuGridClearAttached.Name = "cnuGridClearAttached";
			this.cnuGridClearAttached.Size = new System.Drawing.Size(183, 22);
			this.cnuGridClearAttached.Text = "Remove Attachment";
			this.cnuGridClearAttached.Click += new System.EventHandler(this.cnuGridClearAttached_Click);
			// 
			// cnuGridDeleteMemo
			// 
			this.cnuGridDeleteMemo.Name = "cnuGridDeleteMemo";
			this.cnuGridDeleteMemo.Size = new System.Drawing.Size(183, 22);
			this.cnuGridDeleteMemo.Text = "Delete Memo";
			this.cnuGridDeleteMemo.Click += new System.EventHandler(this.cnuGridDeleteMemo_Click);
			// 
			// cnuGridN2
			// 
			this.cnuGridN2.Name = "cnuGridN2";
			this.cnuGridN2.Size = new System.Drawing.Size(180, 6);
			// 
			// cnuGridCreateMemo
			// 
			this.cnuGridCreateMemo.Name = "cnuGridCreateMemo";
			this.cnuGridCreateMemo.Size = new System.Drawing.Size(183, 22);
			this.cnuGridCreateMemo.Text = "Create New Memo";
			this.cnuGridCreateMemo.Click += new System.EventHandler(this.cnuGridCreateMemo_Click);
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbAddMemo,
            this.tbbN1,
            this.tbbAddAttachment});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(992, 25);
			this.tbrMain.TabIndex = 5;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tbbAddMemo
			// 
			this.tbbAddMemo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbAddMemo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbAddMemo.Name = "tbbAddMemo";
			this.tbbAddMemo.Size = new System.Drawing.Size(75, 22);
			this.tbbAddMemo.Text = "Create Memo";
			this.tbbAddMemo.Click += new System.EventHandler(this.tbbAddMemo_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbAddAttachment
			// 
			this.tbbAddAttachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbAddAttachment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbAddAttachment.Name = "tbbAddAttachment";
			this.tbbAddAttachment.Size = new System.Drawing.Size(89, 22);
			this.tbbAddAttachment.Text = "Add Attachment";
			this.tbbAddAttachment.Click += new System.EventHandler(this.tbbAddAttachment_Click);
			// 
			// dlgOpen
			// 
			this.dlgOpen.AddExtension = false;
			this.dlgOpen.Filter = "All files|*.*";
			this.dlgOpen.Multiselect = true;
			this.dlgOpen.SupportMultiDottedExtensions = true;
			this.dlgOpen.Title = "Select file for Contract Mod";
			// 
			// frmSearchMemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 716);
			this.Controls.Add(this.grdResults);
			this.Controls.Add(this.grpSearch);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmSearchMemo";
			this.Text = "Search Memos";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchMemo_FormClosing);
			this.Load += new System.EventHandler(this.frmSearchMemo_Load);
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
		private CommonWinCtrls.ucTextBox txtMemoDsc;
		private CommonWinCtrls.ucTextBox txtAttachmentNm;
		private CommonWinCtrls.ucTextBox txtNotes;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private CommonWinCtrls.ucDateGroupBox grpCreateDt;
		private CommonWinCtrls.ucGridEx grdResults;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbAddMemo;
		private System.Windows.Forms.ContextMenuStrip cnuGrid;
		private System.Windows.Forms.ToolStripMenuItem cnuGridDeleteMemo;
		private System.Windows.Forms.ToolStripMenuItem cnuGridClearAttached;
		private System.Windows.Forms.ToolStripMenuItem cnuGridEditMemo;
		private System.Windows.Forms.ToolStripSeparator cnuGridN1;
		private System.Windows.Forms.ToolStripMenuItem cnuGridCreateMemo;
		private System.Windows.Forms.ToolStripSeparator cnuGridN2;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.ToolStripButton tbbAddAttachment;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
	}
}