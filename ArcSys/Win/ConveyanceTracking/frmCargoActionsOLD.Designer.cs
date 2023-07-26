namespace CS2010.ArcSys.Win
{
    partial class frmCargoActionsOLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoActionsOLD));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout cmbLastLocation_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbMove_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbLastAction_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbDestination_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbOrigin_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbActionUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.grpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.grpSearchPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.cmbLastLocation = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbMove = new CS2010.ArcSys.WinCtrls.ucMoveCombo();
            this.cmbLastAction = new CS2010.ArcSys.WinCtrls.ucActionCombo();
            this.txtTruckNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbDestination = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbOrigin = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpSearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLastLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLastAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsbClear,
            this.toolStripSeparator2,
            this.tsbActionUpdate,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 1;
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
            // tsbActionUpdate
            // 
            this.tsbActionUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbActionUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbActionUpdate.Image")));
            this.tsbActionUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbActionUpdate.Name = "tsbActionUpdate";
            this.tsbActionUpdate.Size = new System.Drawing.Size(79, 22);
            this.tsbActionUpdate.Text = "Action Update";
            this.tsbActionUpdate.Click += new System.EventHandler(this.tsbActionUpdate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // grpSearch
            // 
            this.grpSearch.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.grpSearch.Controls.Add(this.grpSearchPanel);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.ExpandedSize = new System.Drawing.Size(831, 219);
            appearance1.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance1.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderAppearance = appearance1;
            this.grpSearch.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance2.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.FontData.SizeInPoints = 11F;
            this.grpSearch.HeaderCollapsedAppearance = appearance2;
            this.grpSearch.Location = new System.Drawing.Point(0, 25);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(831, 219);
            this.grpSearch.TabIndex = 10;
            this.grpSearch.Text = "Search Options ... based on current status";
            this.grpSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.grpSearch.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // grpSearchPanel
            // 
            this.grpSearchPanel.Controls.Add(this.cmbLastLocation);
            this.grpSearchPanel.Controls.Add(this.cmbMove);
            this.grpSearchPanel.Controls.Add(this.cmbLastAction);
            this.grpSearchPanel.Controls.Add(this.txtTruckNo);
            this.grpSearchPanel.Controls.Add(this.txtSerialNo);
            this.grpSearchPanel.Controls.Add(this.cmbDestination);
            this.grpSearchPanel.Controls.Add(this.cmbOrigin);
            this.grpSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchPanel.Location = new System.Drawing.Point(3, 21);
            this.grpSearchPanel.Name = "grpSearchPanel";
            this.grpSearchPanel.Size = new System.Drawing.Size(825, 195);
            this.grpSearchPanel.TabIndex = 0;
            // 
            // cmbLastLocation
            // 
            this.cmbLastLocation.CodeColumn = "Location_Cd";
            this.cmbLastLocation.DescriptionColumn = "Location_Dsc";
            cmbLastLocation_DesignTimeLayout.LayoutString = resources.GetString("cmbLastLocation_DesignTimeLayout.LayoutString");
            this.cmbLastLocation.DesignTimeLayout = cmbLastLocation_DesignTimeLayout;
            this.cmbLastLocation.DisplayMember = "Location_Cd";
            this.cmbLastLocation.LabelText = "Last Location:";
            this.cmbLastLocation.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbLastLocation.Location = new System.Drawing.Point(117, 160);
            this.cmbLastLocation.Name = "cmbLastLocation";
            this.cmbLastLocation.SelectedIndex = -1;
            this.cmbLastLocation.SelectedItem = null;
            this.cmbLastLocation.Size = new System.Drawing.Size(206, 20);
            this.cmbLastLocation.TabIndex = 18;
            this.cmbLastLocation.ValueColumn = "Location_Cd";
            this.cmbLastLocation.ValueMember = "Location_Cd";
            // 
            // cmbMove
            // 
            this.cmbMove.CodeColumn = "Move_ID";
            this.cmbMove.DescriptionColumn = "Move_Dsc";
            cmbMove_DesignTimeLayout.LayoutString = resources.GetString("cmbMove_DesignTimeLayout.LayoutString");
            this.cmbMove.DesignTimeLayout = cmbMove_DesignTimeLayout;
            this.cmbMove.DisplayMember = "Move_Dsc";
            this.cmbMove.LabelText = "Move:";
            this.cmbMove.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMove.Location = new System.Drawing.Point(117, 3);
            this.cmbMove.Name = "cmbMove";
            this.cmbMove.SelectedIndex = -1;
            this.cmbMove.SelectedItem = null;
            this.cmbMove.Size = new System.Drawing.Size(206, 20);
            this.cmbMove.TabIndex = 17;
            this.cmbMove.ValueColumn = "Move_ID";
            this.cmbMove.ValueMember = "Move_ID";
            // 
            // cmbLastAction
            // 
            this.cmbLastAction.CodeColumn = "Action_Cd";
            this.cmbLastAction.DescriptionColumn = "Action_Dsc";
            cmbLastAction_DesignTimeLayout.LayoutString = resources.GetString("cmbLastAction_DesignTimeLayout.LayoutString");
            this.cmbLastAction.DesignTimeLayout = cmbLastAction_DesignTimeLayout;
            this.cmbLastAction.DisplayMember = "Action_Dsc";
            this.cmbLastAction.LabelText = "Last Action:";
            this.cmbLastAction.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbLastAction.Location = new System.Drawing.Point(117, 134);
            this.cmbLastAction.Name = "cmbLastAction";
            this.cmbLastAction.SelectedIndex = -1;
            this.cmbLastAction.SelectedItem = null;
            this.cmbLastAction.Size = new System.Drawing.Size(206, 20);
            this.cmbLastAction.TabIndex = 16;
            this.cmbLastAction.ValueColumn = "Action_Cd";
            this.cmbLastAction.ValueMember = "Action_Cd";
            // 
            // txtTruckNo
            // 
            this.txtTruckNo.LabelText = "Truck #:";
            this.txtTruckNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTruckNo.LinkDisabledMessage = "Link Disabled";
            this.txtTruckNo.Location = new System.Drawing.Point(117, 55);
            this.txtTruckNo.Name = "txtTruckNo";
            this.txtTruckNo.Size = new System.Drawing.Size(206, 20);
            this.txtTruckNo.TabIndex = 15;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelText = "Serial #:";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(117, 29);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(206, 20);
            this.txtSerialNo.TabIndex = 14;
            // 
            // cmbDestination
            // 
            this.cmbDestination.CodeColumn = "Location_Cd";
            this.cmbDestination.DescriptionColumn = "Location_Dsc";
            cmbDestination_DesignTimeLayout.LayoutString = resources.GetString("cmbDestination_DesignTimeLayout.LayoutString");
            this.cmbDestination.DesignTimeLayout = cmbDestination_DesignTimeLayout;
            this.cmbDestination.DisplayMember = "Location_Cd";
            this.cmbDestination.LabelText = "Destination:";
            this.cmbDestination.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbDestination.Location = new System.Drawing.Point(117, 107);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.SelectedIndex = -1;
            this.cmbDestination.SelectedItem = null;
            this.cmbDestination.Size = new System.Drawing.Size(206, 20);
            this.cmbDestination.TabIndex = 13;
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
            this.cmbOrigin.LabelText = "Origin:";
            this.cmbOrigin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbOrigin.Location = new System.Drawing.Point(117, 81);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.SelectedIndex = -1;
            this.cmbOrigin.SelectedItem = null;
            this.cmbOrigin.Size = new System.Drawing.Size(206, 20);
            this.cmbOrigin.TabIndex = 12;
            this.cmbOrigin.ValueColumn = "Location_Cd";
            this.cmbOrigin.ValueMember = "Location_Cd";
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraExpandableGroupBox1.Expanded = false;
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(831, 120);
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.ultraExpandableGroupBox1.HeaderAppearance = appearance3;
            this.ultraExpandableGroupBox1.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.ultraExpandableGroupBox1.HeaderCollapsedAppearance = appearance4;
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(0, 244);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(831, 27);
            this.ultraExpandableGroupBox1.TabIndex = 13;
            this.ultraExpandableGroupBox1.Text = "Search Options ... based on new action";
            this.ultraExpandableGroupBox1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(825, 221);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            this.ultraExpandableGroupBoxPanel1.Visible = false;
            // 
            // grdCargo
            // 
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargo.Hierarchical = true;
            this.grdCargo.Location = new System.Drawing.Point(0, 271);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.Size = new System.Drawing.Size(831, 325);
            this.grdCargo.TabIndex = 14;
            this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdCargo.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdCargo_RowDoubleClick);
            // 
            // frmCargoActionsOLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 596);
            this.Controls.Add(this.grdCargo);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCargoActionsOLD";
            this.Text = "Cargo / Conveyance Action";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearch)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearchPanel.ResumeLayout(false);
            this.grpSearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLastLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLastAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Infragistics.Win.Misc.UltraExpandableGroupBox grpSearch;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel grpSearchPanel;
        private CommonWinCtrls.ucTextBox txtTruckNo;
        private CommonWinCtrls.ucTextBox txtSerialNo;
        private WinCtrls.ucLocationCombo cmbDestination;
        private WinCtrls.ucLocationCombo cmbOrigin;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private CommonWinCtrls.ucGridEx grdCargo;
        private WinCtrls.ucMoveCombo cmbMove;
        private WinCtrls.ucActionCombo cmbLastAction;
        private WinCtrls.ucLocationCombo cmbLastLocation;
        private System.Windows.Forms.ToolStripButton tsbActionUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}