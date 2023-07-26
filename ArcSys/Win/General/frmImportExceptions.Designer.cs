namespace CS2010.ArcSys.Win
{
    partial class frmImportExceptions

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExceptions));
			Janus.Windows.GridEX.GridEXLayout grdAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsSearch = new System.Windows.Forms.ToolStripButton();
			this.ucProgressBar1 = new CS2010.CommonWinCtrls.ucProgressBar();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.cbxShowAll = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grdAudit = new CS2010.CommonWinCtrls.ucGridEx();
			this.tsGrdCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
			this.SuspendLayout();
			// 
			// tsGrdCargo
			// 
			this.tsGrdCargo.GridObject = null;
			this.tsGrdCargo.HideAddButton = true;
			this.tsGrdCargo.HideDeleteButton = true;
			this.tsGrdCargo.HideEditButton = true;
			this.tsGrdCargo.HideExportMenu = true;
			this.tsGrdCargo.HidePrintMenu = true;
			this.tsGrdCargo.HideSeparator = true;
			this.tsGrdCargo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearch});
			this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
			this.tsGrdCargo.Name = "tsGrdCargo";
			this.tsGrdCargo.Size = new System.Drawing.Size(782, 25);
			this.tsGrdCargo.TabIndex = 1;
			this.tsGrdCargo.Text = "ucGridToolStrip1";
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
			// ucProgressBar1
			// 
			this.ucProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucProgressBar1.Location = new System.Drawing.Point(0, 473);
			this.ucProgressBar1.Name = "ucProgressBar1";
			this.ucProgressBar1.Size = new System.Drawing.Size(782, 23);
			this.ucProgressBar1.TabIndex = 2;
			this.ucProgressBar1.Visible = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.grdAudit);
			this.splitContainer1.Panel1.Controls.Add(this.cbxShowAll);
			this.splitContainer1.Size = new System.Drawing.Size(782, 448);
			this.splitContainer1.SplitterDistance = 305;
			this.splitContainer1.TabIndex = 3;
			// 
			// cbxShowAll
			// 
			this.cbxShowAll.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbxShowAll.Location = new System.Drawing.Point(0, 0);
			this.cbxShowAll.Name = "cbxShowAll";
			this.cbxShowAll.Size = new System.Drawing.Size(782, 24);
			this.cbxShowAll.TabIndex = 0;
			this.cbxShowAll.Text = "Show All";
			this.cbxShowAll.UseVisualStyleBackColor = true;
			this.cbxShowAll.YN = "N";
			// 
			// grdAudit
			// 
			grdAudit_DesignTimeLayout.LayoutString = resources.GetString("grdAudit_DesignTimeLayout.LayoutString");
			this.grdAudit.DesignTimeLayout = grdAudit_DesignTimeLayout;
			this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAudit.ExportFileID = null;
			this.grdAudit.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdAudit.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdAudit.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdAudit.Location = new System.Drawing.Point(0, 24);
			this.grdAudit.Name = "grdAudit";
			this.grdAudit.Size = new System.Drawing.Size(782, 281);
			this.grdAudit.TabIndex = 1;
			// 
			// frmImportExceptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.ucProgressBar1);
			this.Controls.Add(this.tsGrdCargo);
			this.Name = "frmImportExceptions";
			this.Text = "Import Exceptions";
			this.tsGrdCargo.ResumeLayout(false);
			this.tsGrdCargo.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private System.Windows.Forms.ToolStripButton tsSearch;
        private CommonWinCtrls.ucProgressBar ucProgressBar1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private CommonWinCtrls.ucGridEx grdAudit;
		private CommonWinCtrls.ucCheckBox cbxShowAll;

    }
}