namespace CS2010.ArcSys.Win
{
    partial class frmSearchMove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchMove));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout cmbDestination_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbOrigin_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMoves_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbCancelSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.cmbDestination = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbOrigin = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
            this.grdMoves = new CS2010.CommonWinCtrls.ucGridEx();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMoves)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsProgress,
            this.tsbCancelSearch,
            this.tsbClear,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1099, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(44, 22);
            this.tsbSearch.Text = "&Search";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsProgress
            // 
            this.tsProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(100, 22);
            this.tsProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tsbCancelSearch
            // 
            this.tsbCancelSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancelSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancelSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.tsbCancelSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelSearch.Image")));
            this.tsbCancelSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelSearch.Name = "tsbCancelSearch";
            this.tsbCancelSearch.Size = new System.Drawing.Size(149, 22);
            this.tsbCancelSearch.Text = "[&Click here to Cancel Search]";
            this.tsbCancelSearch.Click += new System.EventHandler(this.tsbCancelSearch_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(36, 22);
            this.tsbClear.Text = "&Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // grpSearch
            // 
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(1099, 114);
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance1;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance2;
            this.grpSearch.Location = new System.Drawing.Point(0, 25);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1099, 114);
            this.grpSearch.TabIndex = 9;
            this.grpSearch.Text = "Search Options";
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.txtSerialNo);
            this.grpSearchPanel.Controls.Add(this.txtVoyageNo);
            this.grpSearchPanel.Controls.Add(this.txtBookingNo);
            this.grpSearchPanel.Controls.Add(this.cmbDestination);
            this.grpSearchPanel.Controls.Add(this.cmbOrigin);
            this.grpSearchPanel.Controls.Add(this.cmbVendor);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(1093, 90);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // cmbDestination
            // 
            this.cmbDestination.CodeColumn = "Location_Cd";
            this.cmbDestination.DescriptionColumn = "Location_Dsc";
            cmbDestination_DesignTimeLayout.LayoutString = resources.GetString("cmbDestination_DesignTimeLayout.LayoutString");
            this.cmbDestination.DesignTimeLayout = cmbDestination_DesignTimeLayout;
            this.cmbDestination.DisplayMember = "Location_Cd";
            this.cmbDestination.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbDestination.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbDestination.LabelText = "Destination:";
            this.cmbDestination.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbDestination.Location = new System.Drawing.Point(88, 55);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.SelectedIndex = -1;
            this.cmbDestination.SelectedItem = null;
            this.cmbDestination.Size = new System.Drawing.Size(159, 20);
            this.cmbDestination.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbDestination.TabIndex = 2;
            this.cmbDestination.ValueColumn = "Location_Cd";
            this.cmbDestination.ValueMember = "Location_Cd";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.CodeColumn = "Location_Cd";
            this.cmbOrigin.DescriptionColumn = "Location_Dsc";
            cmbOrigin_DesignTimeLayout.LayoutString = resources.GetString("cmbOrigin_DesignTimeLayout.LayoutString");
            this.cmbOrigin.DesignTimeLayout = cmbOrigin_DesignTimeLayout;
            this.cmbOrigin.DisplayMember = "Location_Cd";
            this.cmbOrigin.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbOrigin.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbOrigin.LabelText = "Origin:";
            this.cmbOrigin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbOrigin.Location = new System.Drawing.Point(88, 29);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.SelectedIndex = -1;
            this.cmbOrigin.SelectedItem = null;
            this.cmbOrigin.Size = new System.Drawing.Size(159, 20);
            this.cmbOrigin.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbOrigin.TabIndex = 1;
            this.cmbOrigin.ValueColumn = "Location_Cd";
            this.cmbOrigin.ValueMember = "Location_Cd";
            // 
            // cmbVendor
            // 
            this.cmbVendor.CodeColumn = "Vendor_Cd";
            this.cmbVendor.DescriptionColumn = "Vendor_Nm";
            cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
            this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
            this.cmbVendor.DisplayMember = "Vendor_Cd";
            this.cmbVendor.LabelBackColor = System.Drawing.Color.Transparent;
            this.cmbVendor.LabelText = "Vendor";
            this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVendor.Location = new System.Drawing.Point(88, 3);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.SelectedIndex = -1;
            this.cmbVendor.SelectedItem = null;
            this.cmbVendor.Size = new System.Drawing.Size(159, 20);
            this.cmbVendor.TabIndex = 0;
            this.cmbVendor.ValueColumn = "Vendor_Cd";
            this.cmbVendor.ValueMember = "Vendor_Cd";
            // 
            // grdMoves
            // 
            grdMoves_DesignTimeLayout.LayoutString = resources.GetString("grdMoves_DesignTimeLayout.LayoutString");
            this.grdMoves.DesignTimeLayout = grdMoves_DesignTimeLayout;
            this.grdMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMoves.ExportFileID = null;
            this.grdMoves.Location = new System.Drawing.Point(0, 139);
            this.grdMoves.Name = "grdMoves";
            this.grdMoves.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMoves.Size = new System.Drawing.Size(1099, 540);
            this.grdMoves.TabIndex = 10;
            this.ToolTip.SetToolTip(this.grdMoves, "Double click to Edit/View Move ...");
            this.grdMoves.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdMoves.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdMoves_RowDoubleClick);
            this.grdMoves.MouseEnter += new System.EventHandler(this.grdMoves_MouseEnter);
            // 
            // ToolTip
            // 
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ShowAlways = true;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingNo.LabelText = "Booking #";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(335, 2);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(161, 20);
            this.txtBookingNo.TabIndex = 3;
            // 
            // txtVoyageNo
            // 
            this.txtVoyageNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVoyageNo.LabelText = "Voyage #";
            this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
            this.txtVoyageNo.Location = new System.Drawing.Point(335, 28);
            this.txtVoyageNo.Name = "txtVoyageNo";
            this.txtVoyageNo.Size = new System.Drawing.Size(161, 20);
            this.txtVoyageNo.TabIndex = 4;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerialNo.LabelText = "Serial #";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(335, 54);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(161, 20);
            this.txtSerialNo.TabIndex = 5;
            // 
            // frmSearchMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 679);
            this.Controls.Add(this.grdMoves);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSearchMove";
            this.Text = "Search for Moves ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchMove_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMoves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
        private CommonWinCtrls.ucGridEx grdMoves;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton tsbCancelSearch;
        private WinCtrls.ucLocationCombo cmbDestination;
        private WinCtrls.ucLocationCombo cmbOrigin;
        private WinCtrls.ucVendorCombo cmbVendor;
        private System.Windows.Forms.ToolStripButton tsbClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolTip ToolTip;
        private CommonWinCtrls.ucTextBox txtSerialNo;
        private CommonWinCtrls.ucTextBox txtVoyageNo;
        private CommonWinCtrls.ucTextBox txtBookingNo;
    }
}