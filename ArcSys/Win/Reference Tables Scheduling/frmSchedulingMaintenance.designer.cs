namespace CS2010.ArcSys.Win
{
	partial class frmSchedulingMaintenance 
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Ports");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Berths");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("BerthActivity");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Berth Pairs");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Service");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Routes");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Schedule Type");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Trade Lanes");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Vessel");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("MilitaryVoyages");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Seasons");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Distance");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Vessel Speed");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Season", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_0 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchedulingMaintenance));
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_1 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_2 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_3 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_4 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_5 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_6 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_7 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_8 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_9 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_10 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_11 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdTable_Layout_12 = new Janus.Windows.GridEX.GridEXLayout();
			this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
			this.tvwTables = new CS2010.CommonWinCtrls.ucTreeView();
			this.grdTable = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlAction = new CS2010.CommonWinCtrls.ucPanel();
			this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.tbbOptions = new System.Windows.Forms.ToolStripDropDownButton();
			this.cnuOptionsRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.getSecurityObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
			this.pnlAction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.tbrMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(166, 11);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// tvwTables
			// 
			this.tvwTables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwTables.HideSelection = false;
			this.tvwTables.Location = new System.Drawing.Point(0, 0);
			this.tvwTables.Name = "tvwTables";
			treeNode1.Name = "Port";
			treeNode1.Text = "Ports";
			treeNode2.Name = "Berth";
			treeNode2.Text = "Berths";
			treeNode3.BackColor = System.Drawing.Color.Transparent;
			treeNode3.ForeColor = System.Drawing.Color.Gray;
			treeNode3.Name = "BerthActivity";
			treeNode3.Text = "BerthActivity";
			treeNode4.ForeColor = System.Drawing.Color.Gray;
			treeNode4.Name = "BerthPair";
			treeNode4.Text = "Berth Pairs";
			treeNode5.ForeColor = System.Drawing.Color.Gray;
			treeNode5.Name = "Service";
			treeNode5.Text = "Service";
			treeNode6.ForeColor = System.Drawing.Color.Gray;
			treeNode6.Name = "Route";
			treeNode6.Text = "Routes";
			treeNode7.ForeColor = System.Drawing.Color.Gray;
			treeNode7.Name = "ScheduleType";
			treeNode7.Text = "Schedule Type";
			treeNode8.ForeColor = System.Drawing.Color.Gray;
			treeNode8.Name = "TradeLane";
			treeNode8.Text = "Trade Lanes";
			treeNode9.ForeColor = System.Drawing.Color.Gray;
			treeNode9.Name = "Vessel";
			treeNode9.Tag = "Vessel";
			treeNode9.Text = "Vessel";
			treeNode10.Name = "MilitaryVoyage";
			treeNode10.Text = "MilitaryVoyages";
			treeNode11.Name = "General";
			treeNode11.Text = "General";
			treeNode12.ForeColor = System.Drawing.Color.Gray;
			treeNode12.Name = "Season";
			treeNode12.Text = "Seasons";
			treeNode13.ForeColor = System.Drawing.Color.Gray;
			treeNode13.Name = "Distance";
			treeNode13.Text = "Distance";
			treeNode14.Name = "VesselSpeed";
			treeNode14.Text = "Vessel Speed";
			treeNode15.ForeColor = System.Drawing.Color.Gray;
			treeNode15.Name = "Season";
			treeNode15.Text = "Season";
			this.tvwTables.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode15});
			this.tvwTables.Size = new System.Drawing.Size(154, 449);
			this.tvwTables.TabIndex = 0;
			this.tvwTables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwTables_AfterSelect);
			// 
			// grdTable
			// 
			this.grdTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdTable.ExportFileID = null;
			this.grdTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			grdTable_Layout_0.Description = "Vessel Table Layout";
			grdTable_Layout_0.Key = "Vessel";
			grdTable_Layout_0.LayoutString = resources.GetString("grdTable_Layout_0.LayoutString");
			grdTable_Layout_0.Tag = "Vessel";
			grdTable_Layout_1.Description = "Port Table Layout";
			grdTable_Layout_1.Key = "Port";
			grdTable_Layout_1.LayoutString = resources.GetString("grdTable_Layout_1.LayoutString");
			grdTable_Layout_1.Tag = "Port";
			grdTable_Layout_2.Description = "Trade Lane Table Layout";
			grdTable_Layout_2.Key = "TradeLane";
			grdTable_Layout_2.LayoutString = resources.GetString("grdTable_Layout_2.LayoutString");
			grdTable_Layout_3.Description = "Berth";
			grdTable_Layout_3.Key = "Berth";
			grdTable_Layout_3.LayoutString = resources.GetString("grdTable_Layout_3.LayoutString");
			grdTable_Layout_4.Description = "Berth Pair";
			grdTable_Layout_4.Key = "BerthPair";
			grdTable_Layout_4.LayoutString = resources.GetString("grdTable_Layout_4.LayoutString");
			grdTable_Layout_5.Description = "Distance";
			grdTable_Layout_5.Key = "Distance";
			grdTable_Layout_5.LayoutString = resources.GetString("grdTable_Layout_5.LayoutString");
			grdTable_Layout_6.Description = "Route";
			grdTable_Layout_6.Key = "Route";
			grdTable_Layout_6.LayoutString = resources.GetString("grdTable_Layout_6.LayoutString");
			grdTable_Layout_7.Description = "Schedule Type";
			grdTable_Layout_7.Key = "ScheduleType";
			grdTable_Layout_7.LayoutString = resources.GetString("grdTable_Layout_7.LayoutString");
			grdTable_Layout_8.Description = "Season";
			grdTable_Layout_8.Key = "Season";
			grdTable_Layout_8.LayoutString = resources.GetString("grdTable_Layout_8.LayoutString");
			grdTable_Layout_9.Description = "Vessel Speed";
			grdTable_Layout_9.Key = "VesselSpeed";
			grdTable_Layout_9.LayoutString = resources.GetString("grdTable_Layout_9.LayoutString");
			grdTable_Layout_10.Description = "Service";
			grdTable_Layout_10.Key = "Service";
			grdTable_Layout_10.LayoutString = resources.GetString("grdTable_Layout_10.LayoutString");
			grdTable_Layout_11.Description = "BerthActivity";
			grdTable_Layout_11.Key = "BerthActivity";
			grdTable_Layout_11.LayoutString = resources.GetString("grdTable_Layout_11.LayoutString");
			grdTable_Layout_12.Description = "MilitaryVoyage";
			grdTable_Layout_12.Key = "MilitaryVoyage";
			grdTable_Layout_12.LayoutString = resources.GetString("grdTable_Layout_12.LayoutString");
			this.grdTable.Layouts.AddRange(new Janus.Windows.GridEX.GridEXLayout[] {
            grdTable_Layout_0,
            grdTable_Layout_1,
            grdTable_Layout_2,
            grdTable_Layout_3,
            grdTable_Layout_4,
            grdTable_Layout_5,
            grdTable_Layout_6,
            grdTable_Layout_7,
            grdTable_Layout_8,
            grdTable_Layout_9,
            grdTable_Layout_10,
            grdTable_Layout_11,
            grdTable_Layout_12});
			this.grdTable.Location = new System.Drawing.Point(0, 44);
			this.grdTable.Name = "grdTable";
			this.grdTable.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdTable.Size = new System.Drawing.Size(483, 405);
			this.grdTable.TabIndex = 2;
			this.grdTable.DoubleClick += new System.EventHandler(this.grdTable_DoubleClick);
			// 
			// pnlAction
			// 
			this.pnlAction.Controls.Add(this.btnAdd);
			this.pnlAction.Controls.Add(this.btnDelete);
			this.pnlAction.Controls.Add(this.btnEdit);
			this.pnlAction.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlAction.Location = new System.Drawing.Point(0, 0);
			this.pnlAction.Name = "pnlAction";
			this.pnlAction.Size = new System.Drawing.Size(483, 44);
			this.pnlAction.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(10, 11);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(88, 11);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 4;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.tvwTables);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.grdTable);
			this.pnlMain.Panel2.Controls.Add(this.pnlAction);
			this.pnlMain.Size = new System.Drawing.Size(641, 449);
			this.pnlMain.SplitterDistance = 154;
			this.pnlMain.TabIndex = 4;
			// 
			// tbbClose
			// 
			this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClose.Name = "tbbClose";
			this.tbbClose.Size = new System.Drawing.Size(37, 22);
			this.tbbClose.Text = "Close";
			// 
			// tbbOptions
			// 
			this.tbbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuOptionsRefresh,
            this.getSecurityObjectsToolStripMenuItem});
			this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbOptions.Name = "tbbOptions";
			this.tbbOptions.Size = new System.Drawing.Size(57, 22);
			this.tbbOptions.Text = "&Options";
			// 
			// cnuOptionsRefresh
			// 
			this.cnuOptionsRefresh.Name = "cnuOptionsRefresh";
			this.cnuOptionsRefresh.Size = new System.Drawing.Size(196, 22);
			this.cnuOptionsRefresh.Text = "&Refresh Selected Table";
			// 
			// getSecurityObjectsToolStripMenuItem
			// 
			this.getSecurityObjectsToolStripMenuItem.Name = "getSecurityObjectsToolStripMenuItem";
			this.getSecurityObjectsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.getSecurityObjectsToolStripMenuItem.Text = "Get Security Objects";
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbOptions,
            this.tbbN1,
            this.tbbClose});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(595, 25);
			this.tbrMain.TabIndex = 3;
			this.tbrMain.Text = "toolStrip1";
			this.tbrMain.Visible = false;
			// 
			// frmSchedulingMaintenance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(641, 449);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmSchedulingMaintenance";
			this.Text = "Reference Table Maintenance";
			((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
			this.pnlAction.ResumeLayout(false);
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucButton btnDelete;
        private CS2010.CommonWinCtrls.ucTreeView tvwTables;
        private CS2010.CommonWinCtrls.ucGridEx grdTable;
        private CS2010.CommonWinCtrls.ucPanel pnlAction;
        private CS2010.CommonWinCtrls.ucButton btnAdd;
        private CS2010.CommonWinCtrls.ucButton btnEdit;
        private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
        private System.Windows.Forms.ToolStripButton tbbClose;
        private System.Windows.Forms.ToolStripDropDownButton tbbOptions;
        private System.Windows.Forms.ToolStripMenuItem cnuOptionsRefresh;
        private System.Windows.Forms.ToolStripMenuItem getSecurityObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator tbbN1;
        private System.Windows.Forms.ToolStrip tbrMain;

    }
}