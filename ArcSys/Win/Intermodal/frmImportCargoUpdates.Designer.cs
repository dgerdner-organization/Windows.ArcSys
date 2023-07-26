namespace CS2010.ArcSys.Win
{
    partial class frmImportCargoUpdates
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
            Janus.Windows.GridEX.GridEXLayout grdCargoChanged_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportCargoUpdates));
            this.grdCargoChanged = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsCargoChanged = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsSearch = new System.Windows.Forms.ToolStripButton();
            this.tsUpdate = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoChanged)).BeginInit();
            this.tsCargoChanged.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCargoChanged
            // 
            grdCargoChanged_DesignTimeLayout.LayoutString = resources.GetString("grdCargoChanged_DesignTimeLayout.LayoutString");
            this.grdCargoChanged.DesignTimeLayout = grdCargoChanged_DesignTimeLayout;
            this.grdCargoChanged.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargoChanged.ExportFileID = null;
            this.grdCargoChanged.Location = new System.Drawing.Point(0, 25);
            this.grdCargoChanged.Name = "grdCargoChanged";
            this.grdCargoChanged.Size = new System.Drawing.Size(782, 471);
            this.grdCargoChanged.TabIndex = 0;
            this.grdCargoChanged.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargoChanged_LinkClicked);
            // 
            // tsCargoChanged
            // 
            this.tsCargoChanged.GridObject = this.grdCargoChanged;
            this.tsCargoChanged.HideAddButton = true;
            this.tsCargoChanged.HideDeleteButton = true;
            this.tsCargoChanged.HideEditButton = true;
            this.tsCargoChanged.HideExportMenu = true;
            this.tsCargoChanged.HidePrintMenu = true;
            this.tsCargoChanged.HideSeparator = true;
            this.tsCargoChanged.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearch,
            this.tsUpdate});
            this.tsCargoChanged.Location = new System.Drawing.Point(0, 0);
            this.tsCargoChanged.Name = "tsCargoChanged";
            this.tsCargoChanged.Size = new System.Drawing.Size(782, 25);
            this.tsCargoChanged.TabIndex = 1;
            this.tsCargoChanged.Text = "ucGridToolStrip1";
            // 
            // tsSearch
            // 
            this.tsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsSearch.Image")));
            this.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearch.Name = "tsSearch";
            this.tsSearch.Size = new System.Drawing.Size(44, 22);
            this.tsSearch.Text = "Search";
            this.tsSearch.Click += new System.EventHandler(this.tsSearch_Click);
            // 
            // tsUpdate
            // 
            this.tsUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdate.Image")));
            this.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdate.Name = "tsUpdate";
            this.tsUpdate.Size = new System.Drawing.Size(46, 22);
            this.tsUpdate.Text = "Update";
            this.tsUpdate.Click += new System.EventHandler(this.tsUpdate_Click);
            // 
            // frmImportCargoUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.grdCargoChanged);
            this.Controls.Add(this.tsCargoChanged);
            this.Name = "frmImportCargoUpdates";
            this.Text = "Cargo Updates";
            ((System.ComponentModel.ISupportInitialize)(this.grdCargoChanged)).EndInit();
            this.tsCargoChanged.ResumeLayout(false);
            this.tsCargoChanged.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdCargoChanged;
        private CommonWinCtrls.ucGridToolStrip tsCargoChanged;
        private System.Windows.Forms.ToolStripButton tsSearch;
        private System.Windows.Forms.ToolStripButton tsUpdate;

    }
}