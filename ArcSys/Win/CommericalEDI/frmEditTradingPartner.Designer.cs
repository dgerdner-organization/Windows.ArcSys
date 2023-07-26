namespace CS2010.ArcSys.Win
{
	partial class frmEditTradingPartner
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
            Janus.Windows.GridEX.GridEXLayout grdPartners_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCustomers_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdEDIConfigure_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdUserPartners_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdConfig_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTradingPartner));
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.grdPartners = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpCustomers = new System.Windows.Forms.TabPage();
            this.pnlCustomers = new CS2010.CommonWinCtrls.ucPanel();
            this.grdCustomers = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tpConfigure = new System.Windows.Forms.TabPage();
            this.pnlEDIConfig = new CS2010.CommonWinCtrls.ucPanel();
            this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdEDIConfigure = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnSave = new CS2010.CommonWinCtrls.ucButton();
            this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
            this.tpUserPartners = new System.Windows.Forms.TabPage();
            this.grdUserPartners = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpTOPSPorts = new System.Windows.Forms.TabPage();
            this.grdConfig = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucSplitContainer2 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnSave2 = new CS2010.CommonWinCtrls.ucButton();
            this.btnAdd2 = new CS2010.CommonWinCtrls.ucButton();
            this.tabMain.SuspendLayout();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPartners)).BeginInit();
            this.tpCustomers.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
            this.tpConfigure.SuspendLayout();
            this.pnlEDIConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
            this.ucSplitContainer1.Panel1.SuspendLayout();
            this.ucSplitContainer1.Panel2.SuspendLayout();
            this.ucSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEDIConfigure)).BeginInit();
            this.tpUserPartners.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserPartners)).BeginInit();
            this.tpTOPSPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).BeginInit();
            this.ucSplitContainer2.Panel1.SuspendLayout();
            this.ucSplitContainer2.Panel2.SuspendLayout();
            this.ucSplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpMain);
            this.tabMain.Controls.Add(this.tpCustomers);
            this.tabMain.Controls.Add(this.tpConfigure);
            this.tabMain.Controls.Add(this.tpUserPartners);
            this.tabMain.Controls.Add(this.tpTOPSPorts);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(782, 496);
            this.tabMain.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.grdPartners);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(774, 470);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "EDI Trading Partners";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // grdPartners
            // 
            grdPartners_DesignTimeLayout.LayoutString = resources.GetString("grdPartners_DesignTimeLayout.LayoutString");
            this.grdPartners.DesignTimeLayout = grdPartners_DesignTimeLayout;
            this.grdPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPartners.ExportFileID = null;
            this.grdPartners.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPartners.GroupByBoxVisible = false;
            this.grdPartners.Location = new System.Drawing.Point(3, 3);
            this.grdPartners.Name = "grdPartners";
            this.grdPartners.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdPartners.Size = new System.Drawing.Size(768, 464);
            this.grdPartners.TabIndex = 0;
            this.grdPartners.SelectionChanged += new System.EventHandler(this.grdPartners_SelectionChanged);
            // 
            // tpCustomers
            // 
            this.tpCustomers.Controls.Add(this.pnlCustomers);
            this.tpCustomers.Location = new System.Drawing.Point(4, 22);
            this.tpCustomers.Name = "tpCustomers";
            this.tpCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomers.Size = new System.Drawing.Size(774, 470);
            this.tpCustomers.TabIndex = 1;
            this.tpCustomers.Text = "Customers";
            this.tpCustomers.UseVisualStyleBackColor = true;
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.Controls.Add(this.grdCustomers);
            this.pnlCustomers.Controls.Add(this.ucGridToolStrip1);
            this.pnlCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomers.Location = new System.Drawing.Point(3, 3);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(768, 459);
            this.pnlCustomers.TabIndex = 1;
            // 
            // grdCustomers
            // 
            grdCustomers_DesignTimeLayout.LayoutString = resources.GetString("grdCustomers_DesignTimeLayout.LayoutString");
            this.grdCustomers.DesignTimeLayout = grdCustomers_DesignTimeLayout;
            this.grdCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCustomers.ExportFileID = null;
            this.grdCustomers.GroupByBoxVisible = false;
            this.grdCustomers.Location = new System.Drawing.Point(0, 25);
            this.grdCustomers.Name = "grdCustomers";
            this.grdCustomers.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCustomers.Size = new System.Drawing.Size(768, 434);
            this.grdCustomers.TabIndex = 0;
            // 
            // ucGridToolStrip1
            // 
            this.ucGridToolStrip1.GridObject = null;
            this.ucGridToolStrip1.HideExportMenu = true;
            this.ucGridToolStrip1.HidePrintMenu = true;
            this.ucGridToolStrip1.HideSeparator = true;
            this.ucGridToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ucGridToolStrip1.Name = "ucGridToolStrip1";
            this.ucGridToolStrip1.Size = new System.Drawing.Size(768, 25);
            this.ucGridToolStrip1.TabIndex = 1;
            this.ucGridToolStrip1.Text = "ucGridToolStrip1";
            // 
            // tpConfigure
            // 
            this.tpConfigure.Controls.Add(this.pnlEDIConfig);
            this.tpConfigure.Location = new System.Drawing.Point(4, 22);
            this.tpConfigure.Name = "tpConfigure";
            this.tpConfigure.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfigure.Size = new System.Drawing.Size(774, 470);
            this.tpConfigure.TabIndex = 2;
            this.tpConfigure.Text = "EDI Configuration";
            this.tpConfigure.UseVisualStyleBackColor = true;
            // 
            // pnlEDIConfig
            // 
            this.pnlEDIConfig.Controls.Add(this.ucSplitContainer1);
            this.pnlEDIConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEDIConfig.Location = new System.Drawing.Point(3, 3);
            this.pnlEDIConfig.Name = "pnlEDIConfig";
            this.pnlEDIConfig.Size = new System.Drawing.Size(768, 437);
            this.pnlEDIConfig.TabIndex = 1;
            // 
            // ucSplitContainer1
            // 
            this.ucSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ucSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.ucSplitContainer1.Name = "ucSplitContainer1";
            this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer1.Panel1
            // 
            this.ucSplitContainer1.Panel1.Controls.Add(this.grdEDIConfigure);
            // 
            // ucSplitContainer1.Panel2
            // 
            this.ucSplitContainer1.Panel2.Controls.Add(this.btnSave);
            this.ucSplitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.ucSplitContainer1.Size = new System.Drawing.Size(768, 437);
            this.ucSplitContainer1.SplitterDistance = 391;
            this.ucSplitContainer1.TabIndex = 0;
            // 
            // grdEDIConfigure
            // 
            grdEDIConfigure_DesignTimeLayout.LayoutString = resources.GetString("grdEDIConfigure_DesignTimeLayout.LayoutString");
            this.grdEDIConfigure.DesignTimeLayout = grdEDIConfigure_DesignTimeLayout;
            this.grdEDIConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEDIConfigure.ExportFileID = null;
            this.grdEDIConfigure.Location = new System.Drawing.Point(0, 0);
            this.grdEDIConfigure.Name = "grdEDIConfigure";
            this.grdEDIConfigure.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdEDIConfigure.Size = new System.Drawing.Size(764, 387);
            this.grdEDIConfigure.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(190, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tpUserPartners
            // 
            this.tpUserPartners.Controls.Add(this.grdUserPartners);
            this.tpUserPartners.Location = new System.Drawing.Point(4, 22);
            this.tpUserPartners.Name = "tpUserPartners";
            this.tpUserPartners.Padding = new System.Windows.Forms.Padding(3);
            this.tpUserPartners.Size = new System.Drawing.Size(774, 470);
            this.tpUserPartners.TabIndex = 3;
            this.tpUserPartners.Text = "User Partners";
            this.tpUserPartners.UseVisualStyleBackColor = true;
            // 
            // grdUserPartners
            // 
            grdUserPartners_DesignTimeLayout.LayoutString = resources.GetString("grdUserPartners_DesignTimeLayout.LayoutString");
            this.grdUserPartners.DesignTimeLayout = grdUserPartners_DesignTimeLayout;
            this.grdUserPartners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserPartners.ExportFileID = null;
            this.grdUserPartners.GroupByBoxVisible = false;
            this.grdUserPartners.Location = new System.Drawing.Point(3, 3);
            this.grdUserPartners.Name = "grdUserPartners";
            this.grdUserPartners.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdUserPartners.Size = new System.Drawing.Size(768, 464);
            this.grdUserPartners.TabIndex = 0;
            // 
            // tpTOPSPorts
            // 
            this.tpTOPSPorts.Controls.Add(this.ucSplitContainer2);
            this.tpTOPSPorts.Location = new System.Drawing.Point(4, 22);
            this.tpTOPSPorts.Name = "tpTOPSPorts";
            this.tpTOPSPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tpTOPSPorts.Size = new System.Drawing.Size(774, 470);
            this.tpTOPSPorts.TabIndex = 4;
            this.tpTOPSPorts.Text = "General Configurations";
            this.tpTOPSPorts.UseVisualStyleBackColor = true;
            // 
            // grdConfig
            // 
            grdConfig_DesignTimeLayout.LayoutString = resources.GetString("grdConfig_DesignTimeLayout.LayoutString");
            this.grdConfig.DesignTimeLayout = grdConfig_DesignTimeLayout;
            this.grdConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConfig.ExportFileID = null;
            this.grdConfig.Location = new System.Drawing.Point(0, 0);
            this.grdConfig.Name = "grdConfig";
            this.grdConfig.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdConfig.Size = new System.Drawing.Size(768, 380);
            this.grdConfig.TabIndex = 1;
            // 
            // ucSplitContainer2
            // 
            this.ucSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ucSplitContainer2.IsSplitterFixed = true;
            this.ucSplitContainer2.Location = new System.Drawing.Point(3, 3);
            this.ucSplitContainer2.Name = "ucSplitContainer2";
            this.ucSplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer2.Panel1
            // 
            this.ucSplitContainer2.Panel1.Controls.Add(this.grdConfig);
            // 
            // ucSplitContainer2.Panel2
            // 
            this.ucSplitContainer2.Panel2.Controls.Add(this.btnSave2);
            this.ucSplitContainer2.Panel2.Controls.Add(this.btnAdd2);
            this.ucSplitContainer2.Size = new System.Drawing.Size(768, 464);
            this.ucSplitContainer2.SplitterDistance = 380;
            this.ucSplitContainer2.TabIndex = 2;
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(202, 6);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 6;
            this.btnSave2.Text = "Save";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Location = new System.Drawing.Point(15, 6);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(75, 23);
            this.btnAdd2.TabIndex = 5;
            this.btnAdd2.Text = "Add";
            this.btnAdd2.UseVisualStyleBackColor = true;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // frmEditTradingPartner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.tabMain);
            this.Name = "frmEditTradingPartner";
            this.Text = "Edit Trading Partner";
            this.tabMain.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPartners)).EndInit();
            this.tpCustomers.ResumeLayout(false);
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
            this.tpConfigure.ResumeLayout(false);
            this.pnlEDIConfig.ResumeLayout(false);
            this.ucSplitContainer1.Panel1.ResumeLayout(false);
            this.ucSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
            this.ucSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEDIConfigure)).EndInit();
            this.tpUserPartners.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserPartners)).EndInit();
            this.tpTOPSPorts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConfig)).EndInit();
            this.ucSplitContainer2.Panel1.ResumeLayout(false);
            this.ucSplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer2)).EndInit();
            this.ucSplitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tpMain;
		private CommonWinCtrls.ucGridEx grdPartners;
		private System.Windows.Forms.TabPage tpCustomers;
		private CommonWinCtrls.ucGridEx grdCustomers;
        private System.Windows.Forms.TabPage tpConfigure;
		private CommonWinCtrls.ucPanel pnlCustomers;
		private CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;
		private CommonWinCtrls.ucPanel pnlEDIConfig;
		private System.Windows.Forms.TabPage tpUserPartners;
        private CommonWinCtrls.ucGridEx grdUserPartners;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
        private CommonWinCtrls.ucGridEx grdEDIConfigure;
        private CommonWinCtrls.ucButton btnAdd;
        private CommonWinCtrls.ucButton btnSave;
        private System.Windows.Forms.TabPage tpTOPSPorts;
        private CommonWinCtrls.ucSplitContainer ucSplitContainer2;
        private CommonWinCtrls.ucGridEx grdConfig;
        private CommonWinCtrls.ucButton btnSave2;
        private CommonWinCtrls.ucButton btnAdd2;

	}
}
