namespace CS2010.ArcSys.Win
{
    partial class frmSDDCInvoicing2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSDDCInvoicing2));
            Janus.Windows.GridEX.GridEXLayout grdData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdData2_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbCancelSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMsg = new System.Windows.Forms.ToolStripLabel();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdData = new CS2010.CommonWinCtrls.ucGridEx();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdData2 = new CS2010.CommonWinCtrls.ucGridEx();
            this.ts.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).BeginInit();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsProgress,
            this.tsbCancelSearch,
            this.tsbClear,
            this.toolStripSeparator2,
            this.tsbMsg,
            this.tsbExport});
            this.ts.Location = new System.Drawing.Point(0, 0);
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(851, 25);
            this.ts.TabIndex = 27;
            this.ts.Text = "toolStrip1";
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
            this.tsProgress.Visible = false;
            // 
            // tsbCancelSearch
            // 
            this.tsbCancelSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancelSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancelSearch.ForeColor = System.Drawing.Color.Black;
            this.tsbCancelSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelSearch.Image")));
            this.tsbCancelSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelSearch.Name = "tsbCancelSearch";
            this.tsbCancelSearch.Size = new System.Drawing.Size(149, 22);
            this.tsbCancelSearch.Text = "[&Click here to Cancel Search]";
            this.tsbCancelSearch.Visible = false;
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
            // tsbMsg
            // 
            this.tsbMsg.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbMsg.Name = "tsbMsg";
            this.tsbMsg.Size = new System.Drawing.Size(0, 22);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(43, 22);
            this.tsbExport.Text = "E&xport";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtPCFN);
            this.panel1.Controls.Add(this.txtVoyage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 51);
            this.panel1.TabIndex = 28;
            // 
            // txtVoyage
            // 
            this.txtVoyage.Enabled = false;
            this.txtVoyage.LabelText = "Voyage:";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(75, 14);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 0;
            // 
            // grdData
            // 
            grdData_DesignTimeLayout.LayoutString = resources.GetString("grdData_DesignTimeLayout.LayoutString");
            this.grdData.DesignTimeLayout = grdData_DesignTimeLayout;
            this.grdData.ExportFileID = null;
            this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(359, 355);
            this.grdData.Name = "grdData";
            this.grdData.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdData.Size = new System.Drawing.Size(492, 170);
            this.grdData.TabIndex = 29;
            this.grdData.Visible = false;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(253, 14);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(100, 20);
            this.txtPCFN.TabIndex = 1;
            // 
            // grdData2
            // 
            grdData2_DesignTimeLayout.LayoutString = "<GridEXLayoutData><RootTable><DataMember /><GroupCondition /></RootTable></GridEX" +
                "LayoutData>";
            this.grdData2.DesignTimeLayout = grdData2_DesignTimeLayout;
            this.grdData2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData2.ExportFileID = null;
            this.grdData2.Location = new System.Drawing.Point(0, 76);
            this.grdData2.Name = "grdData2";
            this.grdData2.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdData2.Size = new System.Drawing.Size(851, 449);
            this.grdData2.TabIndex = 30;
            // 
            // frmSDDCInvoicing2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 525);
            this.Controls.Add(this.grdData2);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts);
            this.Name = "frmSDDCInvoicing2";
            this.Text = "SDDC Invoicing";
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton tsbCancelSearch;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsbMsg;
        private System.Windows.Forms.Panel panel1;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private CommonWinCtrls.ucGridEx grdData;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private CommonWinCtrls.ucTextBox txtPCFN;
        private CommonWinCtrls.ucGridEx grdData2;
    }
}