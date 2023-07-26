namespace CS2010.ArcSys.Win
{
    partial class frmCustomerServiceLhaulCharges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerServiceLhaulCharges));
            Janus.Windows.GridEX.GridEXLayout grdCharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.gbSearch = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.gbpSearch = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdCharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbpSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPrint,
            this.toolStripSeparator2,
            this.tsbExport,
            this.tsProgressBar,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(33, 22);
            this.tsbPrint.Text = "&Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(43, 22);
            this.tsbExport.Text = "&Export";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 22);
            this.tsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tsbCancel
            // 
            this.tsbCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(43, 22);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.gbpSearch);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.ExpandedSize = new System.Drawing.Size(782, 74);
            this.gbSearch.Location = new System.Drawing.Point(0, 25);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(782, 74);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.Text = " ";
            // 
            // gbpSearch
            // 
            this.gbpSearch.Controls.Add(this.panel2);
            this.gbpSearch.Controls.Add(this.lblResults);
            this.gbpSearch.Controls.Add(this.btnSearch);
            this.gbpSearch.Controls.Add(this.txtBooking);
            this.gbpSearch.Controls.Add(this.btnClear);
            this.gbpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbpSearch.Location = new System.Drawing.Point(3, 19);
            this.gbpSearch.Name = "gbpSearch";
            this.gbpSearch.Size = new System.Drawing.Size(776, 52);
            this.gbpSearch.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(681, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 20);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transshipment";
            // 
            // lblResults
            // 
            this.lblResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblResults.BackColor = System.Drawing.SystemColors.Control;
            this.lblResults.Location = new System.Drawing.Point(18, 29);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(749, 17);
            this.lblResults.TabIndex = 3;
            this.lblResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(301, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBooking
            // 
            this.txtBooking.LabelText = "Booking #";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(72, 6);
            this.txtBooking.MaxLength = 30;
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(142, 20);
            this.txtBooking.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(220, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdCharges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 397);
            this.panel1.TabIndex = 2;
            // 
            // grdCharges
            // 
            this.grdCharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdCharges_DesignTimeLayout.LayoutString = resources.GetString("grdCharges_DesignTimeLayout.LayoutString");
            this.grdCharges.DesignTimeLayout = grdCharges_DesignTimeLayout;
            this.grdCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCharges.ExportFileID = null;
            this.grdCharges.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCharges.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCharges.Location = new System.Drawing.Point(0, 0);
            this.grdCharges.Name = "grdCharges";
            this.grdCharges.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCharges.Size = new System.Drawing.Size(782, 397);
            this.grdCharges.TabIndex = 1;
            this.grdCharges.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCharges_LinkClicked);
            // 
            // frmCustomerServiceLhaulCharges
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCustomerServiceLhaulCharges";
            this.Text = "CSD Revenue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomerServiceLhaulCharges_FormClosing);
            this.Load += new System.EventHandler(this.frmCustomerServiceLhaulCharges_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbpSearch.ResumeLayout(false);
            this.gbpSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private Infragistics.Win.Misc.UltraExpandableGroupBox gbSearch;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel gbpSearch;
        private System.Windows.Forms.Panel panel1;
        private CommonWinCtrls.ucButton btnSearch;
        private CommonWinCtrls.ucTextBox txtBooking;
        private CommonWinCtrls.ucButton btnClear;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private CommonWinCtrls.ucGridEx grdCharges;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}