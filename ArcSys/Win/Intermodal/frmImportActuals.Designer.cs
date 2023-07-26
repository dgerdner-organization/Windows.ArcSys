namespace CS2010.ArcSys.Win
{
	partial class frmImportActuals
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportActuals));
			Janus.Windows.GridEX.GridEXLayout grdAdHoc_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tsGrdCargo = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.tsSave = new System.Windows.Forms.ToolStripButton();
			this.txtDate = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.txtInvoiceNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnExcel = new CS2010.CommonWinCtrls.ucButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.grdAdHoc = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
			this.tsGrdCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAdHoc)).BeginInit();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
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
            this.tsSave});
			this.tsGrdCargo.Location = new System.Drawing.Point(0, 0);
			this.tsGrdCargo.Name = "tsGrdCargo";
			this.tsGrdCargo.Size = new System.Drawing.Size(782, 25);
			this.tsGrdCargo.TabIndex = 1;
			this.tsGrdCargo.Text = "ucGridToolStrip1";
			// 
			// tsSave
			// 
			this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsSave.Image = ((System.Drawing.Image)(resources.GetObject("tsSave.Image")));
			this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSave.Name = "tsSave";
			this.tsSave.Size = new System.Drawing.Size(35, 22);
			this.tsSave.Text = "Save";
			this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
			// 
			// txtDate
			// 
			this.txtDate.LabelText = "Invoice Date";
			this.txtDate.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDate.LinkDisabledMessage = "Link Disabled";
			this.txtDate.Location = new System.Drawing.Point(83, 49);
			this.txtDate.MaxLength = 6;
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(100, 20);
			this.txtDate.TabIndex = 2;
			this.txtDate.Value = null;
			// 
			// txtInvoiceNo
			// 
			this.txtInvoiceNo.LabelText = "Invoice#";
			this.txtInvoiceNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtInvoiceNo.LinkDisabledMessage = "Link Disabled";
			this.txtInvoiceNo.Location = new System.Drawing.Point(83, 26);
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			this.txtInvoiceNo.Size = new System.Drawing.Size(100, 20);
			this.txtInvoiceNo.TabIndex = 1;
			// 
			// btnExcel
			// 
			this.btnExcel.Location = new System.Drawing.Point(83, 72);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(75, 23);
			this.btnExcel.TabIndex = 5;
			this.btnExcel.Text = "Open Excel";
			this.btnExcel.UseVisualStyleBackColor = true;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// grdAdHoc
			// 
			grdAdHoc_DesignTimeLayout.LayoutString = resources.GetString("grdAdHoc_DesignTimeLayout.LayoutString");
			this.grdAdHoc.DesignTimeLayout = grdAdHoc_DesignTimeLayout;
			this.grdAdHoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAdHoc.ExportFileID = null;
			this.grdAdHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdAdHoc.GroupByBoxVisible = false;
			this.grdAdHoc.Location = new System.Drawing.Point(0, 125);
			this.grdAdHoc.Name = "grdAdHoc";
			this.grdAdHoc.Size = new System.Drawing.Size(782, 371);
			this.grdAdHoc.TabIndex = 6;
			this.grdAdHoc.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAdHoc.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.cmbVendor);
			this.ucPanel1.Controls.Add(this.btnExcel);
			this.ucPanel1.Controls.Add(this.txtDate);
			this.ucPanel1.Controls.Add(this.txtInvoiceNo);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 25);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(782, 100);
			this.ucPanel1.TabIndex = 7;
			// 
			// cmbVendor
			// 
			this.cmbVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbVendor.CodeColumn = "Vendor_Cd";
			this.cmbVendor.DescriptionColumn = "Vendor_Nm";
			cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
			this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
			this.cmbVendor.DisplayMember = "Vendor_Cd";
			this.cmbVendor.LabelText = "Vendor";
			this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVendor.Location = new System.Drawing.Point(83, 3);
			this.cmbVendor.Name = "cmbVendor";
			this.cmbVendor.SelectedIndex = -1;
			this.cmbVendor.SelectedItem = null;
			this.cmbVendor.Size = new System.Drawing.Size(213, 20);
			this.cmbVendor.TabIndex = 0;
			this.cmbVendor.ValueColumn = "Vendor_Cd";
			this.cmbVendor.ValueMember = "Vendor_Cd";
			// 
			// frmImportActuals
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdAdHoc);
			this.Controls.Add(this.ucPanel1);
			this.Controls.Add(this.tsGrdCargo);
			this.Name = "frmImportActuals";
			this.Text = "Import Actuals";
			this.tsGrdCargo.ResumeLayout(false);
			this.tsGrdCargo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAdHoc)).EndInit();
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CommonWinCtrls.ucGridToolStrip tsGrdCargo;
		private WinCtrls.ucVendorCombo cmbVendor;
		private CommonWinCtrls.ucDateTextBox txtDate;
		private CommonWinCtrls.ucTextBox txtInvoiceNo;
		private System.Windows.Forms.ToolStripButton tsSave;
		private CommonWinCtrls.ucButton btnExcel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private CommonWinCtrls.ucGridEx grdAdHoc;
		private CommonWinCtrls.ucPanel ucPanel1;

    }
}