namespace CS2010.ArcSys.Win
{
    partial class frmViewAudit
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
            Janus.Windows.GridEX.GridEXLayout grdAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewAudit));
            this.grdAudit = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsSearch = new System.Windows.Forms.ToolStripButton();
            this.ucProgressBar1 = new CS2010.CommonWinCtrls.ucProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            this.tsGrdCargo.SuspendLayout();
            this.SuspendLayout();
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
            this.grdAudit.Location = new System.Drawing.Point(0, 25);
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.Size = new System.Drawing.Size(782, 471);
            this.grdAudit.TabIndex = 0;
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
            // frmViewAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.ucProgressBar1);
            this.Controls.Add(this.grdAudit);
            this.Controls.Add(this.tsGrdCargo);
            this.Name = "frmViewAudit";
            this.Text = "Change History";
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            this.tsGrdCargo.ResumeLayout(false);
            this.tsGrdCargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdAudit;
        private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private System.Windows.Forms.ToolStripButton tsSearch;
        private CommonWinCtrls.ucProgressBar ucProgressBar1;

    }
}