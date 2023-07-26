namespace CS2010.ArcSys.Win
{
    partial class frmAPILog
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
            Janus.Windows.GridEX.GridEXLayout cmbMapTypes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAPILog));
            Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ucButton1 = new CS2010.CommonWinCtrls.ucButton();
            this.txtDays = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxUnprocessed = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cmbMapTypes = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbDayPicker = new CS2010.CommonWinCtrls.ucComboBox();
            this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
            this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucLabel3 = new CS2010.CommonWinCtrls.ucLabel();
            this.ucLabel2 = new CS2010.CommonWinCtrls.ucLabel();
            this.txtMessage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtJson = new CS2010.CommonWinCtrls.ucTextBox();
            this.sbrChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMapTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
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
            this.sbrChild.Location = new System.Drawing.Point(0, 677);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(992, 22);
            this.sbrChild.TabIndex = 4;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
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
            this.grpSearch.ExpandedSize = new System.Drawing.Size(992, 116);
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance3;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance4;
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
            this.grpSearchPanel.Controls.Add(this.ucButton1);
            this.grpSearchPanel.Controls.Add(this.txtDays);
            this.grpSearchPanel.Controls.Add(this.cbxUnprocessed);
            this.grpSearchPanel.Controls.Add(this.cmbMapTypes);
            this.grpSearchPanel.Controls.Add(this.cmbDayPicker);
            this.grpSearchPanel.Controls.Add(this.ucLabel1);
            this.grpSearchPanel.Controls.Add(this.cmbPartner);
            this.grpSearchPanel.Controls.Add(this.txtSerialNo);
            this.grpSearchPanel.Controls.Add(this.txtBookingNo);
            this.grpSearchPanel.Controls.Add(this.btnClear);
            this.grpSearchPanel.Controls.Add(this.btnSearch);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(986, 92);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // ucButton1
            // 
            this.ucButton1.Location = new System.Drawing.Point(902, 65);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(75, 23);
            this.ucButton1.TabIndex = 18;
            this.ucButton1.Text = "Clear Log";
            this.ucButton1.UseVisualStyleBackColor = true;
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // txtDays
            // 
            this.txtDays.LinkDisabledMessage = "Link Disabled";
            this.txtDays.Location = new System.Drawing.Point(765, 2);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(48, 20);
            this.txtDays.TabIndex = 17;
            this.txtDays.Visible = false;
            // 
            // cbxUnprocessed
            // 
            this.cbxUnprocessed.Location = new System.Drawing.Point(396, 44);
            this.cbxUnprocessed.Name = "cbxUnprocessed";
            this.cbxUnprocessed.Size = new System.Drawing.Size(137, 24);
            this.cbxUnprocessed.TabIndex = 15;
            this.cbxUnprocessed.Text = "Just Fails";
            this.cbxUnprocessed.UseVisualStyleBackColor = true;
            this.cbxUnprocessed.YN = "N";
            // 
            // cmbMapTypes
            // 
            cmbMapTypes_DesignTimeLayout.LayoutString = resources.GetString("cmbMapTypes_DesignTimeLayout.LayoutString");
            this.cmbMapTypes.DesignTimeLayout = cmbMapTypes_DesignTimeLayout;
            this.cmbMapTypes.DisplayMember = "api_dsc";
            this.cmbMapTypes.LabelText = "API";
            this.cmbMapTypes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMapTypes.Location = new System.Drawing.Point(396, 24);
            this.cmbMapTypes.Name = "cmbMapTypes";
            this.cmbMapTypes.SelectedIndex = -1;
            this.cmbMapTypes.SelectedItem = null;
            this.cmbMapTypes.Size = new System.Drawing.Size(276, 20);
            this.cmbMapTypes.TabIndex = 14;
            this.cmbMapTypes.ValueMember = "api_nm";
            // 
            // cmbDayPicker
            // 
            this.cmbDayPicker.FormattingEnabled = true;
            this.cmbDayPicker.Items.AddRange(new object[] {
            "1",
            "7",
            "30",
            "360",
            "9999"});
            this.cmbDayPicker.LabelText = "Run in the last";
            this.cmbDayPicker.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbDayPicker.Location = new System.Drawing.Point(396, 0);
            this.cmbDayPicker.Name = "cmbDayPicker";
            this.cmbDayPicker.Size = new System.Drawing.Size(64, 21);
            this.cmbDayPicker.TabIndex = 13;
            this.cmbDayPicker.SelectedIndexChanged += new System.EventHandler(this.cmbDayPicker_SelectedIndexChanged);
            // 
            // ucLabel1
            // 
            this.ucLabel1.Location = new System.Drawing.Point(466, 4);
            this.ucLabel1.Name = "ucLabel1";
            this.ucLabel1.Size = new System.Drawing.Size(35, 13);
            this.ucLabel1.TabIndex = 12;
            this.ucLabel1.Text = "day(s)";
            // 
            // cmbPartner
            // 
            this.cmbPartner.DescriptionColumn = "partner_dsc";
            cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
            this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
            this.cmbPartner.DisplayMember = "partner_dsc";
            this.cmbPartner.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
            this.cmbPartner.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbPartner.LabelText = "Partner";
            this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPartner.Location = new System.Drawing.Point(91, 3);
            this.cmbPartner.Name = "cmbPartner";
            this.cmbPartner.SelectedIndex = -1;
            this.cmbPartner.SelectedItem = null;
            this.cmbPartner.Size = new System.Drawing.Size(208, 20);
            this.cmbPartner.TabIndex = 0;
            this.cmbPartner.ValueColumn = "partner_cd";
            this.cmbPartner.ValueMember = "trading_partner_cd";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerialNo.LabelText = "Serial#";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(91, 46);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(208, 20);
            this.txtSerialNo.TabIndex = 4;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(91, 25);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
            this.txtBookingNo.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnClear.Location = new System.Drawing.Point(778, 66);
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
            this.btnSearch.Location = new System.Drawing.Point(697, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbrMain
            // 
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(992, 25);
            this.tbrMain.TabIndex = 5;
            this.tbrMain.Text = "toolStrip1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 141);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(992, 558);
            this.tabMain.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(984, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(3, 3);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grdMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.ucLabel3);
            this.splitMain.Panel2.Controls.Add(this.ucLabel2);
            this.splitMain.Panel2.Controls.Add(this.txtMessage);
            this.splitMain.Panel2.Controls.Add(this.txtJson);
            this.splitMain.Size = new System.Drawing.Size(978, 526);
            this.splitMain.SplitterDistance = 307;
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
            this.grdMain.Size = new System.Drawing.Size(976, 305);
            this.grdMain.TabIndex = 2;
            this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdMain.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMain.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_ColumnButtonClick);
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            // 
            // ucLabel3
            // 
            this.ucLabel3.Location = new System.Drawing.Point(616, 12);
            this.ucLabel3.Name = "ucLabel3";
            this.ucLabel3.Size = new System.Drawing.Size(50, 13);
            this.ucLabel3.TabIndex = 3;
            this.ucLabel3.Text = "Message";
            // 
            // ucLabel2
            // 
            this.ucLabel2.Location = new System.Drawing.Point(18, 12);
            this.ucLabel2.Name = "ucLabel2";
            this.ucLabel2.Size = new System.Drawing.Size(35, 13);
            this.ucLabel2.TabIndex = 2;
            this.ucLabel2.Text = "JSON";
            // 
            // txtMessage
            // 
            this.txtMessage.LinkDisabledMessage = "Link Disabled";
            this.txtMessage.Location = new System.Drawing.Point(617, 31);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(346, 177);
            this.txtMessage.TabIndex = 1;
            // 
            // txtJson
            // 
            this.txtJson.LinkDisabledMessage = "Link Disabled";
            this.txtJson.Location = new System.Drawing.Point(13, 31);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJson.Size = new System.Drawing.Size(598, 177);
            this.txtJson.TabIndex = 0;
            // 
            // frmAPILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(992, 699);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Name = "frmAPILog";
            this.Text = "Search API Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMapTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
        private CommonWinCtrls.ucGridEx grdMain;
        private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucComboBox cmbDayPicker;
        private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucMultiColumnCombo cmbMapTypes;
        private CommonWinCtrls.ucCheckBox cbxUnprocessed;
        private CommonWinCtrls.ucTextBox txtDays;
        private CommonWinCtrls.ucTextBox txtJson;
        private CommonWinCtrls.ucLabel ucLabel3;
        private CommonWinCtrls.ucLabel ucLabel2;
        private CommonWinCtrls.ucTextBox txtMessage;
        private CommonWinCtrls.ucButton ucButton1;
	}
}