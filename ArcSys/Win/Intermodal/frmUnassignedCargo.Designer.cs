namespace CS2010.ArcSys.Win
{
    partial class frmUnassignedCargo
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
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnassignedCargo));
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsSearchCargo = new System.Windows.Forms.ToolStripButton();
            this.ucProgressBar1 = new CS2010.CommonWinCtrls.ucProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.tsGrdCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCargo
            // 
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCargo.Location = new System.Drawing.Point(0, 25);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.Size = new System.Drawing.Size(782, 471);
            this.grdCargo.TabIndex = 0;
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
            this.tsSearchCargo});
            this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
            this.tsGrdCargo.Name = "tsGrdCargo";
            this.tsGrdCargo.Size = new System.Drawing.Size(782, 25);
            this.tsGrdCargo.TabIndex = 1;
            this.tsGrdCargo.Text = "ucGridToolStrip1";
            // 
            // tsSearchCargo
            // 
            this.tsSearchCargo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsSearchCargo.Image = ((System.Drawing.Image)(resources.GetObject("tsSearchCargo.Image")));
            this.tsSearchCargo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSearchCargo.Name = "tsSearchCargo";
            this.tsSearchCargo.Size = new System.Drawing.Size(44, 22);
            this.tsSearchCargo.Text = "Search";
            this.tsSearchCargo.Click += new System.EventHandler(this.tsSearchCargo_Click);
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
            // frmUnassignedCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.ucProgressBar1);
            this.Controls.Add(this.grdCargo);
            this.Controls.Add(this.tsGrdCargo);
            this.Name = "frmUnassignedCargo";
            this.Text = "Unassigned Cargo";
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.tsGrdCargo.ResumeLayout(false);
            this.tsGrdCargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdCargo;
        private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
        private System.Windows.Forms.ToolStripButton tsSearchCargo;
        private CommonWinCtrls.ucProgressBar ucProgressBar1;

    }
}