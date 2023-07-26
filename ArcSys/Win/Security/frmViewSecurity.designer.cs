namespace CS2010.ArcSys.Win
{
    partial class frmViewSecurity
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
			Janus.Windows.GridEX.GridEXLayout grdDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewSecurity));
			Janus.Windows.GridEX.GridEXLayout grdUnassigned_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdGroups_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdSecurity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdViewSecurity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdObjects_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdParentDescriptions_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbOptions = new System.Windows.Forms.ToolStripDropDownButton();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
			this.tpUserGroup = new System.Windows.Forms.TabPage();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
			this.grdUnassigned = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tpGroups = new System.Windows.Forms.TabPage();
			this.grdGroups = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsGroup = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsCloneGroup = new System.Windows.Forms.ToolStripButton();
			this.tsClearSecurity = new System.Windows.Forms.ToolStripButton();
			this.tpSecurity = new System.Windows.Forms.TabPage();
			this.grdSecurity = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsSecurity = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.tabViewSecurity = new System.Windows.Forms.TabPage();
			this.grdViewSecurity = new CS2010.CommonWinCtrls.ucGridEx();
			this.tpObjects = new System.Windows.Forms.TabPage();
			this.grdObjects = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGridToolStrip2 = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tpDescriptions = new System.Windows.Forms.TabPage();
			this.ucSplitContainer2 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdParentDescriptions = new CS2010.CommonWinCtrls.ucGridEx();
			this.btnChange = new CS2010.CommonWinCtrls.ucButton();
			this.txtNewDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOldDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.tbrMain.SuspendLayout();
			this.ucPanel1.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tpUserGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdUnassigned)).BeginInit();
			this.tpGroups.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdGroups)).BeginInit();
			this.tsGroup.SuspendLayout();
			this.tpSecurity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSecurity)).BeginInit();
			this.tsSecurity.SuspendLayout();
			this.tabViewSecurity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdViewSecurity)).BeginInit();
			this.tpObjects.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdObjects)).BeginInit();
			this.tpDescriptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).BeginInit();
			this.ucSplitContainer2.Panel1.SuspendLayout();
			this.ucSplitContainer2.Panel2.SuspendLayout();
			this.ucSplitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdParentDescriptions)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbOptions,
            this.tbbN1,
            this.tbbClose});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(782, 25);
			this.tbrMain.TabIndex = 1;
			// 
			// tbbOptions
			// 
			this.tbbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem});
			this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbOptions.Name = "tbbOptions";
			this.tbbOptions.Size = new System.Drawing.Size(57, 22);
			this.tbbOptions.Text = "&Options";
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbClose
			// 
			this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClose.Name = "tbbClose";
			this.tbbClose.Size = new System.Drawing.Size(37, 22);
			this.tbbClose.Text = "Close";
			this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.tabMain);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucPanel1.Location = new System.Drawing.Point(0, 25);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(782, 428);
			this.ucPanel1.TabIndex = 3;
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tpUserGroup);
			this.tabMain.Controls.Add(this.tpGroups);
			this.tabMain.Controls.Add(this.tpSecurity);
			this.tabMain.Controls.Add(this.tabViewSecurity);
			this.tabMain.Controls.Add(this.tpObjects);
			this.tabMain.Controls.Add(this.tpDescriptions);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(782, 428);
			this.tabMain.TabIndex = 1;
			// 
			// tpUserGroup
			// 
			this.tpUserGroup.Controls.Add(this.ucSplitContainer1);
			this.tpUserGroup.Controls.Add(this.ucGridToolStrip1);
			this.tpUserGroup.Location = new System.Drawing.Point(4, 22);
			this.tpUserGroup.Name = "tpUserGroup";
			this.tpUserGroup.Padding = new System.Windows.Forms.Padding(3);
			this.tpUserGroup.Size = new System.Drawing.Size(774, 402);
			this.tpUserGroup.TabIndex = 0;
			this.tpUserGroup.Text = "Group Assignments";
			this.tpUserGroup.UseVisualStyleBackColor = true;
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitContainer1.Location = new System.Drawing.Point(3, 28);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.grdDetail);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdUnassigned);
			this.ucSplitContainer1.Size = new System.Drawing.Size(768, 371);
			this.ucSplitContainer1.SplitterDistance = 233;
			this.ucSplitContainer1.TabIndex = 2;
			// 
			// grdDetail
			// 
			this.grdDetail.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString");
			this.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout;
			this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDetail.ExportFileID = null;
			this.grdDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdDetail.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdDetail.Location = new System.Drawing.Point(0, 0);
			this.grdDetail.Name = "grdDetail";
			this.grdDetail.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this.grdDetail.Size = new System.Drawing.Size(768, 233);
			this.grdDetail.TabIndex = 0;
			this.grdDetail.UseGroupRowSelector = true;
			this.grdDetail.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDetail_CellValueChanged);
			this.grdDetail.DoubleClick += new System.EventHandler(this.grdDetail_DoubleClick);
			// 
			// grdUnassigned
			// 
			grdUnassigned_DesignTimeLayout.LayoutString = resources.GetString("grdUnassigned_DesignTimeLayout.LayoutString");
			this.grdUnassigned.DesignTimeLayout = grdUnassigned_DesignTimeLayout;
			this.grdUnassigned.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdUnassigned.ExportFileID = null;
			this.grdUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdUnassigned.GroupByBoxVisible = false;
			this.grdUnassigned.Location = new System.Drawing.Point(0, 0);
			this.grdUnassigned.Name = "grdUnassigned";
			this.grdUnassigned.Size = new System.Drawing.Size(768, 134);
			this.grdUnassigned.TabIndex = 0;
			// 
			// ucGridToolStrip1
			// 
			this.ucGridToolStrip1.GridObject = null;
			this.ucGridToolStrip1.HideExportMenu = true;
			this.ucGridToolStrip1.HidePrintMenu = true;
			this.ucGridToolStrip1.Location = new System.Drawing.Point(3, 3);
			this.ucGridToolStrip1.Name = "ucGridToolStrip1";
			this.ucGridToolStrip1.Size = new System.Drawing.Size(768, 25);
			this.ucGridToolStrip1.TabIndex = 1;
			this.ucGridToolStrip1.Text = "ucGridToolStrip1";
			this.ucGridToolStrip1.ClickAdd += new System.EventHandler(this.ucGridToolStrip1_ClickAdd);
			this.ucGridToolStrip1.ClickEdit += new System.EventHandler(this.ucGridToolStrip1_ClickEdit);
			this.ucGridToolStrip1.ClickDelete += new System.EventHandler(this.ucGridToolStrip1_ClickDelete);
			// 
			// tpGroups
			// 
			this.tpGroups.Controls.Add(this.grdGroups);
			this.tpGroups.Controls.Add(this.tsGroup);
			this.tpGroups.Location = new System.Drawing.Point(4, 22);
			this.tpGroups.Name = "tpGroups";
			this.tpGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tpGroups.Size = new System.Drawing.Size(774, 427);
			this.tpGroups.TabIndex = 1;
			this.tpGroups.Text = "Groups";
			this.tpGroups.UseVisualStyleBackColor = true;
			// 
			// grdGroups
			// 
			grdGroups_DesignTimeLayout.LayoutString = resources.GetString("grdGroups_DesignTimeLayout.LayoutString");
			this.grdGroups.DesignTimeLayout = grdGroups_DesignTimeLayout;
			this.grdGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdGroups.ExportFileID = null;
			this.grdGroups.GroupByBoxVisible = false;
			this.grdGroups.Location = new System.Drawing.Point(3, 28);
			this.grdGroups.Name = "grdGroups";
			this.grdGroups.Size = new System.Drawing.Size(768, 396);
			this.grdGroups.TabIndex = 0;
			this.grdGroups.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdGroups_CellValueChanged);
			// 
			// tsGroup
			// 
			this.tsGroup.GridObject = null;
			this.tsGroup.HideExportMenu = true;
			this.tsGroup.HidePrintMenu = true;
			this.tsGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCloneGroup,
            this.tsClearSecurity});
			this.tsGroup.Location = new System.Drawing.Point(3, 3);
			this.tsGroup.Name = "tsGroup";
			this.tsGroup.Size = new System.Drawing.Size(768, 25);
			this.tsGroup.TabIndex = 1;
			this.tsGroup.Text = "ucGridToolStrip2";
			this.tsGroup.ClickAdd += new System.EventHandler(this.ucGridToolStrip2_ClickAdd);
			this.tsGroup.ClickEdit += new System.EventHandler(this.tsGroup_ClickEdit_1);
			this.tsGroup.ClickDelete += new System.EventHandler(this.ucGridToolStrip2_ClickDelete);
			// 
			// tsCloneGroup
			// 
			this.tsCloneGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsCloneGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsCloneGroup.Image")));
			this.tsCloneGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsCloneGroup.Name = "tsCloneGroup";
			this.tsCloneGroup.Size = new System.Drawing.Size(38, 22);
			this.tsCloneGroup.Text = "Clone";
			this.tsCloneGroup.ToolTipText = "Clone";
			this.tsCloneGroup.Click += new System.EventHandler(this.tsCloneGroup_Click);
			// 
			// tsClearSecurity
			// 
			this.tsClearSecurity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsClearSecurity.Image = ((System.Drawing.Image)(resources.GetObject("tsClearSecurity.Image")));
			this.tsClearSecurity.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsClearSecurity.Name = "tsClearSecurity";
			this.tsClearSecurity.Size = new System.Drawing.Size(75, 22);
			this.tsClearSecurity.Text = "ClearSecurity";
			this.tsClearSecurity.Click += new System.EventHandler(this.tsClearSecurity_Click);
			// 
			// tpSecurity
			// 
			this.tpSecurity.Controls.Add(this.grdSecurity);
			this.tpSecurity.Controls.Add(this.tsSecurity);
			this.tpSecurity.Location = new System.Drawing.Point(4, 22);
			this.tpSecurity.Name = "tpSecurity";
			this.tpSecurity.Padding = new System.Windows.Forms.Padding(3);
			this.tpSecurity.Size = new System.Drawing.Size(774, 427);
			this.tpSecurity.TabIndex = 2;
			this.tpSecurity.Text = "Security by Group";
			this.tpSecurity.UseVisualStyleBackColor = true;
			// 
			// grdSecurity
			// 
			grdSecurity_DesignTimeLayout.LayoutString = resources.GetString("grdSecurity_DesignTimeLayout.LayoutString");
			this.grdSecurity.DesignTimeLayout = grdSecurity_DesignTimeLayout;
			this.grdSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdSecurity.ExportFileID = null;
			this.grdSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdSecurity.GroupByBoxVisible = false;
			this.grdSecurity.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdSecurity.Location = new System.Drawing.Point(3, 28);
			this.grdSecurity.Name = "grdSecurity";
			this.grdSecurity.Size = new System.Drawing.Size(768, 396);
			this.grdSecurity.TabIndex = 1;
			this.grdSecurity.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdSecurity_CellValueChanged);
			// 
			// tsSecurity
			// 
			this.tsSecurity.GridObject = null;
			this.tsSecurity.HideAddButton = true;
			this.tsSecurity.HideDeleteButton = true;
			this.tsSecurity.HideEditButton = true;
			this.tsSecurity.HideExportMenu = true;
			this.tsSecurity.HidePrintMenu = true;
			this.tsSecurity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.tsSecurity.Location = new System.Drawing.Point(3, 3);
			this.tsSecurity.Name = "tsSecurity";
			this.tsSecurity.Size = new System.Drawing.Size(768, 25);
			this.tsSecurity.TabIndex = 2;
			this.tsSecurity.Text = "ucGridToolStrip3";
			this.tsSecurity.ClickAdd += new System.EventHandler(this.tsSecurity_ClickAdd);
			this.tsSecurity.ClickEdit += new System.EventHandler(this.tsSecurity_ClickEdit);
			this.tsSecurity.ClickDelete += new System.EventHandler(this.tsSecurity_ClickDelete);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(42, 22);
			this.toolStripButton1.Text = "Re-init";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// tabViewSecurity
			// 
			this.tabViewSecurity.Controls.Add(this.grdViewSecurity);
			this.tabViewSecurity.Location = new System.Drawing.Point(4, 22);
			this.tabViewSecurity.Name = "tabViewSecurity";
			this.tabViewSecurity.Padding = new System.Windows.Forms.Padding(3);
			this.tabViewSecurity.Size = new System.Drawing.Size(774, 427);
			this.tabViewSecurity.TabIndex = 5;
			this.tabViewSecurity.Text = "Security by Object";
			this.tabViewSecurity.UseVisualStyleBackColor = true;
			// 
			// grdViewSecurity
			// 
			grdViewSecurity_DesignTimeLayout.LayoutString = resources.GetString("grdViewSecurity_DesignTimeLayout.LayoutString");
			this.grdViewSecurity.DesignTimeLayout = grdViewSecurity_DesignTimeLayout;
			this.grdViewSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdViewSecurity.ExportFileID = null;
			this.grdViewSecurity.GroupByBoxVisible = false;
			this.grdViewSecurity.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdViewSecurity.Location = new System.Drawing.Point(3, 3);
			this.grdViewSecurity.Name = "grdViewSecurity";
			this.grdViewSecurity.Size = new System.Drawing.Size(768, 421);
			this.grdViewSecurity.TabIndex = 0;
			// 
			// tpObjects
			// 
			this.tpObjects.Controls.Add(this.grdObjects);
			this.tpObjects.Controls.Add(this.ucGridToolStrip2);
			this.tpObjects.Location = new System.Drawing.Point(4, 22);
			this.tpObjects.Name = "tpObjects";
			this.tpObjects.Padding = new System.Windows.Forms.Padding(3);
			this.tpObjects.Size = new System.Drawing.Size(774, 402);
			this.tpObjects.TabIndex = 3;
			this.tpObjects.Text = "Objects";
			this.tpObjects.UseVisualStyleBackColor = true;
			// 
			// grdObjects
			// 
			grdObjects_DesignTimeLayout.LayoutString = resources.GetString("grdObjects_DesignTimeLayout.LayoutString");
			this.grdObjects.DesignTimeLayout = grdObjects_DesignTimeLayout;
			this.grdObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdObjects.ExportFileID = null;
			this.grdObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdObjects.Location = new System.Drawing.Point(3, 28);
			this.grdObjects.Name = "grdObjects";
			this.grdObjects.Size = new System.Drawing.Size(768, 371);
			this.grdObjects.TabIndex = 0;
			this.grdObjects.DoubleClick += new System.EventHandler(this.grdObjects_DoubleClick);
			// 
			// ucGridToolStrip2
			// 
			this.ucGridToolStrip2.GridObject = null;
			this.ucGridToolStrip2.HideExportMenu = true;
			this.ucGridToolStrip2.HidePrintMenu = true;
			this.ucGridToolStrip2.Location = new System.Drawing.Point(3, 3);
			this.ucGridToolStrip2.Name = "ucGridToolStrip2";
			this.ucGridToolStrip2.Size = new System.Drawing.Size(768, 25);
			this.ucGridToolStrip2.TabIndex = 1;
			this.ucGridToolStrip2.Text = "ucGridToolStrip2";
			this.ucGridToolStrip2.ClickAdd += new System.EventHandler(this.ucGridToolStrip2_ClickAdd_1);
			this.ucGridToolStrip2.ClickEdit += new System.EventHandler(this.ucGridToolStrip2_ClickEdit);
			this.ucGridToolStrip2.ClickDelete += new System.EventHandler(this.ucGridToolStrip2_ClickDelete_1);
			// 
			// tpDescriptions
			// 
			this.tpDescriptions.Controls.Add(this.ucSplitContainer2);
			this.tpDescriptions.Location = new System.Drawing.Point(4, 22);
			this.tpDescriptions.Name = "tpDescriptions";
			this.tpDescriptions.Padding = new System.Windows.Forms.Padding(3);
			this.tpDescriptions.Size = new System.Drawing.Size(774, 402);
			this.tpDescriptions.TabIndex = 4;
			this.tpDescriptions.Text = "Window Descriptions";
			this.tpDescriptions.UseVisualStyleBackColor = true;
			// 
			// ucSplitContainer2
			// 
			this.ucSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitContainer2.Location = new System.Drawing.Point(3, 3);
			this.ucSplitContainer2.Name = "ucSplitContainer2";
			this.ucSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer2.Panel1
			// 
			this.ucSplitContainer2.Panel1.Controls.Add(this.grdParentDescriptions);
			// 
			// ucSplitContainer2.Panel2
			// 
			this.ucSplitContainer2.Panel2.Controls.Add(this.btnChange);
			this.ucSplitContainer2.Panel2.Controls.Add(this.txtNewDsc);
			this.ucSplitContainer2.Panel2.Controls.Add(this.txtOldDsc);
			this.ucSplitContainer2.Size = new System.Drawing.Size(768, 421);
			this.ucSplitContainer2.SplitterDistance = 342;
			this.ucSplitContainer2.TabIndex = 0;
			// 
			// grdParentDescriptions
			// 
			this.grdParentDescriptions.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdParentDescriptions_DesignTimeLayout.LayoutString = resources.GetString("grdParentDescriptions_DesignTimeLayout.LayoutString");
			this.grdParentDescriptions.DesignTimeLayout = grdParentDescriptions_DesignTimeLayout;
			this.grdParentDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdParentDescriptions.ExportFileID = null;
			this.grdParentDescriptions.GroupByBoxVisible = false;
			this.grdParentDescriptions.Location = new System.Drawing.Point(0, 0);
			this.grdParentDescriptions.Name = "grdParentDescriptions";
			this.grdParentDescriptions.Size = new System.Drawing.Size(768, 342);
			this.grdParentDescriptions.TabIndex = 0;
			this.grdParentDescriptions.SelectionChanged += new System.EventHandler(this.ucGridEx1_SelectionChanged);
			// 
			// btnChange
			// 
			this.btnChange.Location = new System.Drawing.Point(457, 37);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(75, 23);
			this.btnChange.TabIndex = 2;
			this.btnChange.Text = "Change";
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// txtNewDsc
			// 
			this.txtNewDsc.LabelText = "To this:";
			this.txtNewDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewDsc.LinkDisabledMessage = "Link Disabled";
			this.txtNewDsc.Location = new System.Drawing.Point(141, 38);
			this.txtNewDsc.Name = "txtNewDsc";
			this.txtNewDsc.Size = new System.Drawing.Size(309, 20);
			this.txtNewDsc.TabIndex = 1;
			// 
			// txtOldDsc
			// 
			this.txtOldDsc.BackColor = System.Drawing.SystemColors.Control;
			this.txtOldDsc.ForeColor = System.Drawing.Color.Black;
			this.txtOldDsc.LabelText = "Change Description from:";
			this.txtOldDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOldDsc.LinkDisabledMessage = "Link Disabled";
			this.txtOldDsc.Location = new System.Drawing.Point(141, 12);
			this.txtOldDsc.Name = "txtOldDsc";
			this.txtOldDsc.ReadOnly = true;
			this.txtOldDsc.Size = new System.Drawing.Size(309, 20);
			this.txtOldDsc.TabIndex = 0;
			this.txtOldDsc.TabStop = false;
			// 
			// frmViewSecurity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 453);
			this.Controls.Add(this.ucPanel1);
			this.Controls.Add(this.tbrMain);
			this.MergeToolbar = this.tbrMain;
			this.Name = "frmViewSecurity";
			this.Text = "View Security";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewSecurity_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewSecurity_FormClosed);
			this.Load += new System.EventHandler(this.frmViewSecurity_Load);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.ucPanel1.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tpUserGroup.ResumeLayout(false);
			this.tpUserGroup.PerformLayout();
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdUnassigned)).EndInit();
			this.tpGroups.ResumeLayout(false);
			this.tpGroups.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdGroups)).EndInit();
			this.tsGroup.ResumeLayout(false);
			this.tsGroup.PerformLayout();
			this.tpSecurity.ResumeLayout(false);
			this.tpSecurity.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSecurity)).EndInit();
			this.tsSecurity.ResumeLayout(false);
			this.tsSecurity.PerformLayout();
			this.tabViewSecurity.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdViewSecurity)).EndInit();
			this.tpObjects.ResumeLayout(false);
			this.tpObjects.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdObjects)).EndInit();
			this.tpDescriptions.ResumeLayout(false);
			this.ucSplitContainer2.Panel1.ResumeLayout(false);
			this.ucSplitContainer2.Panel2.ResumeLayout(false);
			this.ucSplitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).EndInit();
			this.ucSplitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdParentDescriptions)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolStrip tbrMain;
		protected System.Windows.Forms.ToolStripDropDownButton tbbOptions;
        protected System.Windows.Forms.ToolStripSeparator tbbN1;
        protected System.Windows.Forms.ToolStripButton tbbClose;
        private CS2010.CommonWinCtrls.ucPanel ucPanel1;
        private CS2010.CommonWinCtrls.ucTabControl tabMain;
        private System.Windows.Forms.TabPage tpUserGroup;
        private CS2010.CommonWinCtrls.ucGridEx grdDetail;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabPage tpGroups;
        private System.Windows.Forms.TabPage tpSecurity;
        private CS2010.CommonWinCtrls.ucGridEx grdGroups;
        private CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
        private CS2010.CommonWinCtrls.ucGridToolStrip tsGroup;
        private CS2010.CommonWinCtrls.ucGridEx grdSecurity;
        private CS2010.CommonWinCtrls.ucGridToolStrip tsSecurity;
        private System.Windows.Forms.TabPage tpObjects;
        private CS2010.CommonWinCtrls.ucGridEx grdObjects;
        private CS2010.CommonWinCtrls.ucGridToolStrip ucGridToolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private CS2010.CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private CS2010.CommonWinCtrls.ucGridEx grdUnassigned;
        private System.Windows.Forms.TabPage tpDescriptions;
        private CS2010.CommonWinCtrls.ucSplitContainer ucSplitContainer2;
        private CS2010.CommonWinCtrls.ucGridEx grdParentDescriptions;
        private CS2010.CommonWinCtrls.ucTextBox txtNewDsc;
        private CS2010.CommonWinCtrls.ucTextBox txtOldDsc;
        private CS2010.CommonWinCtrls.ucButton btnChange;
        private System.Windows.Forms.ToolStripButton tsCloneGroup;
        private System.Windows.Forms.TabPage tabViewSecurity;
        private CS2010.CommonWinCtrls.ucGridEx grdViewSecurity;
        private System.Windows.Forms.ToolStripButton tsClearSecurity;
    }
}
