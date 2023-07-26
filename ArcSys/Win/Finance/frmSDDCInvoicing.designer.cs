namespace CS2010.ArcSys.Win
{
	partial class frmSDDCInvoicing
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
			if( disposing && (components != null) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSDDCInvoicing));
            Janus.Windows.GridEX.GridEXLayout grdWorkFormat_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbCode_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbTwo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCargoLevel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdItemLevel_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdInvoiceOut_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.tsInvoicing = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsNewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsImportFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGenerateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grdWorkFormat = new CS2010.CommonWinCtrls.ucGridEx();
            this.progressBar1 = new CS2010.CommonWinCtrls.ucProgressBar();
            this.panelSearch = new CS2010.CommonWinCtrls.ucPanel();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbCode = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbTwo = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.btnBindObject = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.tbImportExport = new System.Windows.Forms.TabPage();
            this.grdCargoLevel = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdItemLevel = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdInvoiceOut = new CS2010.CommonWinCtrls.ucGridEx();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbrMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
            this.ucSplitContainer1.Panel1.SuspendLayout();
            this.ucSplitContainer1.Panel2.SuspendLayout();
            this.ucSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFormat)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTwo)).BeginInit();
            this.tbImportExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.toolStripSeparator1,
            this.tbbClear,
            this.tsInvoicing});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(988, 25);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "LINE Protocol Main Toolbar";
            // 
            // tbbSearch
            // 
            this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSearch.Name = "tbbSearch";
            this.tbbSearch.Size = new System.Drawing.Size(44, 22);
            this.tbbSearch.Text = "&Search";
            this.tbbSearch.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbClear
            // 
            this.tbbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(66, 22);
            this.tbbClear.Text = "Clear Fields";
            this.tbbClear.Click += new System.EventHandler(this.tbbClear_Click);
            // 
            // tsInvoicing
            // 
            this.tsInvoicing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsInvoicing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNewInvoice,
            this.tsImportFromExcel,
            this.tsExportExcel,
            this.tsGenerateInvoice});
            this.tsInvoicing.Image = ((System.Drawing.Image)(resources.GetObject("tsInvoicing.Image")));
            this.tsInvoicing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInvoicing.Name = "tsInvoicing";
            this.tsInvoicing.Size = new System.Drawing.Size(63, 22);
            this.tsInvoicing.Text = "Invoicing";
            // 
            // tsNewInvoice
            // 
            this.tsNewInvoice.Name = "tsNewInvoice";
            this.tsNewInvoice.Size = new System.Drawing.Size(170, 22);
            this.tsNewInvoice.Text = "New Invoice";
            this.tsNewInvoice.Click += new System.EventHandler(this.tsQueryLINE_Click);
            // 
            // tsImportFromExcel
            // 
            this.tsImportFromExcel.Name = "tsImportFromExcel";
            this.tsImportFromExcel.Size = new System.Drawing.Size(170, 22);
            this.tsImportFromExcel.Text = "Import from Excel";
            this.tsImportFromExcel.Click += new System.EventHandler(this.txImportFromExcel_Click);
            // 
            // tsExportExcel
            // 
            this.tsExportExcel.Enabled = false;
            this.tsExportExcel.Name = "tsExportExcel";
            this.tsExportExcel.Size = new System.Drawing.Size(170, 22);
            this.tsExportExcel.Text = "Export to Excel";
            this.tsExportExcel.Click += new System.EventHandler(this.tsExportExcel_Click);
            // 
            // tsGenerateInvoice
            // 
            this.tsGenerateInvoice.Enabled = false;
            this.tsGenerateInvoice.Name = "tsGenerateInvoice";
            this.tsGenerateInvoice.Size = new System.Drawing.Size(170, 22);
            this.tsGenerateInvoice.Text = "Generate Invoice";
            this.tsGenerateInvoice.Click += new System.EventHandler(this.tsGenerateInvoice_Click);
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(53, 13);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(91, 20);
            this.txtPCFN.TabIndex = 3;
            this.txtPCFN.TabStop = false;
            this.txtPCFN.Text = "77447111";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tbImportExport);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(988, 636);
            this.tabMain.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.ucSplitContainer1);
            this.tabPage1.Controls.Add(this.panelSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(980, 610);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Review Data";
            // 
            // ucSplitContainer1
            // 
            this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ucSplitContainer1.Location = new System.Drawing.Point(3, 93);
            this.ucSplitContainer1.Name = "ucSplitContainer1";
            this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplitContainer1.Panel1
            // 
            this.ucSplitContainer1.Panel1.Controls.Add(this.grdWorkFormat);
            // 
            // ucSplitContainer1.Panel2
            // 
            this.ucSplitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.ucSplitContainer1.Size = new System.Drawing.Size(974, 514);
            this.ucSplitContainer1.SplitterDistance = 485;
            this.ucSplitContainer1.TabIndex = 10;
            // 
            // grdWorkFormat
            // 
            this.grdWorkFormat.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdWorkFormat_DesignTimeLayout.LayoutString = resources.GetString("grdWorkFormat_DesignTimeLayout.LayoutString");
            this.grdWorkFormat.DesignTimeLayout = grdWorkFormat_DesignTimeLayout;
            this.grdWorkFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkFormat.ExportFileID = null;
            this.grdWorkFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdWorkFormat.GroupByBoxVisible = false;
            this.grdWorkFormat.Location = new System.Drawing.Point(0, 0);
            this.grdWorkFormat.Name = "grdWorkFormat";
            this.grdWorkFormat.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdWorkFormat.Size = new System.Drawing.Size(974, 485);
            this.grdWorkFormat.TabIndex = 9;
            this.grdWorkFormat.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(974, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.txtVoyage);
            this.panelSearch.Controls.Add(this.cmbCode);
            this.panelSearch.Controls.Add(this.cmbTwo);
            this.panelSearch.Controls.Add(this.btnBindObject);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtPCFN);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(974, 90);
            this.panelSearch.TabIndex = 8;
            this.panelSearch.Visible = false;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(53, 40);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(91, 20);
            this.txtVoyage.TabIndex = 11;
            // 
            // cmbCode
            // 
            this.cmbCode.CodeColumn = "blvanfo";
            this.cmbCode.DataMember = "blvanfo";
            this.cmbCode.DescriptionColumn = "blvanfo";
            cmbCode_DesignTimeLayout.LayoutString = resources.GetString("cmbCode_DesignTimeLayout.LayoutString");
            this.cmbCode.DesignTimeLayout = cmbCode_DesignTimeLayout;
            this.cmbCode.DisplayMember = "blvanfo";
            this.cmbCode.Location = new System.Drawing.Point(675, 13);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.SelectedIndex = -1;
            this.cmbCode.SelectedItem = null;
            this.cmbCode.Size = new System.Drawing.Size(100, 20);
            this.cmbCode.TabIndex = 10;
            this.cmbCode.ValueColumn = "blvanfo";
            this.cmbCode.ValueMember = "blvanfo";
            this.cmbCode.Visible = false;
            // 
            // cmbTwo
            // 
            cmbTwo_DesignTimeLayout.LayoutString = resources.GetString("cmbTwo_DesignTimeLayout.LayoutString");
            this.cmbTwo.DesignTimeLayout = cmbTwo_DesignTimeLayout;
            this.cmbTwo.LabelText = "Charge Per";
            this.cmbTwo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbTwo.Location = new System.Drawing.Point(837, 13);
            this.cmbTwo.Name = "cmbTwo";
            this.cmbTwo.SelectedIndex = -1;
            this.cmbTwo.SelectedItem = null;
            this.cmbTwo.Size = new System.Drawing.Size(100, 20);
            this.cmbTwo.TabIndex = 8;
            // 
            // btnBindObject
            // 
            this.btnBindObject.Location = new System.Drawing.Point(585, 13);
            this.btnBindObject.Name = "btnBindObject";
            this.btnBindObject.Size = new System.Drawing.Size(75, 23);
            this.btnBindObject.TabIndex = 5;
            this.btnBindObject.Text = "Bind";
            this.btnBindObject.UseVisualStyleBackColor = true;
            this.btnBindObject.Visible = false;
            this.btnBindObject.Click += new System.EventHandler(this.btnBindObject_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(150, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbImportExport
            // 
            this.tbImportExport.Controls.Add(this.grdCargoLevel);
            this.tbImportExport.Controls.Add(this.grdItemLevel);
            this.tbImportExport.Controls.Add(this.grdMain);
            this.tbImportExport.Location = new System.Drawing.Point(4, 22);
            this.tbImportExport.Name = "tbImportExport";
            this.tbImportExport.Padding = new System.Windows.Forms.Padding(3);
            this.tbImportExport.Size = new System.Drawing.Size(980, 610);
            this.tbImportExport.TabIndex = 1;
            this.tbImportExport.Text = "Import Export";
            this.tbImportExport.UseVisualStyleBackColor = true;
            // 
            // grdCargoLevel
            // 
            this.grdCargoLevel.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdCargoLevel_DesignTimeLayout.LayoutString = resources.GetString("grdCargoLevel_DesignTimeLayout.LayoutString");
            this.grdCargoLevel.DesignTimeLayout = grdCargoLevel_DesignTimeLayout;
            this.grdCargoLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargoLevel.ExportFileID = null;
            this.grdCargoLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCargoLevel.GroupByBoxVisible = false;
            this.grdCargoLevel.Location = new System.Drawing.Point(3, 269);
            this.grdCargoLevel.Name = "grdCargoLevel";
            this.grdCargoLevel.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargoLevel.Size = new System.Drawing.Size(974, 338);
            this.grdCargoLevel.TabIndex = 13;
            this.grdCargoLevel.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // grdItemLevel
            // 
            this.grdItemLevel.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdItemLevel_DesignTimeLayout.LayoutString = resources.GetString("grdItemLevel_DesignTimeLayout.LayoutString");
            this.grdItemLevel.DesignTimeLayout = grdItemLevel_DesignTimeLayout;
            this.grdItemLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdItemLevel.ExportFileID = null;
            this.grdItemLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdItemLevel.GroupByBoxVisible = false;
            this.grdItemLevel.Location = new System.Drawing.Point(3, 114);
            this.grdItemLevel.Name = "grdItemLevel";
            this.grdItemLevel.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdItemLevel.Size = new System.Drawing.Size(974, 155);
            this.grdItemLevel.TabIndex = 12;
            this.grdItemLevel.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // grdMain
            // 
            this.grdMain.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
            this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdMain.ExportFileID = null;
            this.grdMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdMain.GroupByBoxVisible = false;
            this.grdMain.Location = new System.Drawing.Point(3, 3);
            this.grdMain.Name = "grdMain";
            this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMain.Size = new System.Drawing.Size(974, 111);
            this.grdMain.TabIndex = 11;
            this.grdMain.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdInvoiceOut);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(980, 610);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Invoice ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdInvoiceOut
            // 
            grdInvoiceOut_DesignTimeLayout.LayoutString = resources.GetString("grdInvoiceOut_DesignTimeLayout.LayoutString");
            this.grdInvoiceOut.DesignTimeLayout = grdInvoiceOut_DesignTimeLayout;
            this.grdInvoiceOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInvoiceOut.ExportFileID = null;
            this.grdInvoiceOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdInvoiceOut.Location = new System.Drawing.Point(3, 3);
            this.grdInvoiceOut.Name = "grdInvoiceOut";
            this.grdInvoiceOut.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdInvoiceOut.Size = new System.Drawing.Size(974, 604);
            this.grdInvoiceOut.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmSDDCInvoicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 661);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.tbrMain);
            this.KeyPreview = true;
            this.Name = "frmSDDCInvoicing";
            this.Text = "SDDC Invoicing";
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ucSplitContainer1.Panel1.ResumeLayout(false);
            this.ucSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
            this.ucSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFormat)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTwo)).EndInit();
            this.tbImportExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbClear;
		private CS2010.CommonWinCtrls.ucTextBox txtPCFN;
		private System.Windows.Forms.ToolStripDropDownButton tsInvoicing;
		private System.Windows.Forms.ToolStripMenuItem tsNewInvoice;
		private System.Windows.Forms.ToolStripMenuItem tsImportFromExcel;
		private System.Windows.Forms.ToolStripMenuItem tsExportExcel;
		private System.Windows.Forms.ToolStripMenuItem tsGenerateInvoice;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tabPage1;
		private CommonWinCtrls.ucPanel panelSearch;
		private System.Windows.Forms.TabPage tbImportExport;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucButton btnBindObject;
		private CommonWinCtrls.ucMultiColumnCombo cmbTwo;
		private CommonWinCtrls.ucMultiColumnCombo cmbCode;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private CommonWinCtrls.ucGridEx grdWorkFormat;
		private CommonWinCtrls.ucGridEx grdCargoLevel;
		private CommonWinCtrls.ucGridEx grdItemLevel;
		private CommonWinCtrls.ucGridEx grdMain;
		private System.Windows.Forms.TabPage tabPage2;
		private CommonWinCtrls.ucGridEx grdInvoiceOut;
		private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CommonWinCtrls.ucProgressBar progressBar1;
		private CommonWinCtrls.ucTextBox txtVoyage;
	}
}