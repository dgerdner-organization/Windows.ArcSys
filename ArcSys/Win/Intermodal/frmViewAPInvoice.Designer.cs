namespace CS2010.ArcSys.Win
{
	partial class frmViewAPInvoice 
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
			Janus.Windows.GridEX.GridEXLayout grdChargeDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewAPInvoice));
			this.pnlInvoice = new CS2010.CommonWinCtrls.ucPanel();
			this.txtInvoiceDt = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.txtInvoiceNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVendor = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdChargeDetail = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlInvoice.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdChargeDetail)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlInvoice
			// 
			this.pnlInvoice.Controls.Add(this.txtInvoiceDt);
			this.pnlInvoice.Controls.Add(this.txtInvoiceNo);
			this.pnlInvoice.Controls.Add(this.txtVendor);
			this.pnlInvoice.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlInvoice.Location = new System.Drawing.Point(0, 0);
			this.pnlInvoice.Name = "pnlInvoice";
			this.pnlInvoice.Size = new System.Drawing.Size(782, 88);
			this.pnlInvoice.TabIndex = 0;
			// 
			// txtInvoiceDt
			// 
			this.txtInvoiceDt.BackColor = System.Drawing.SystemColors.Control;
			this.txtInvoiceDt.ForeColor = System.Drawing.Color.Black;
			this.txtInvoiceDt.LabelText = "Date";
			this.txtInvoiceDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtInvoiceDt.LinkDisabledMessage = "Link Disabled";
			this.txtInvoiceDt.Location = new System.Drawing.Point(71, 57);
			this.txtInvoiceDt.MaxLength = 6;
			this.txtInvoiceDt.Name = "txtInvoiceDt";
			this.txtInvoiceDt.ReadOnly = true;
			this.txtInvoiceDt.Size = new System.Drawing.Size(122, 20);
			this.txtInvoiceDt.TabIndex = 2;
			this.txtInvoiceDt.TabStop = false;
			this.txtInvoiceDt.Value = null;
			// 
			// txtInvoiceNo
			// 
			this.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtInvoiceNo.ForeColor = System.Drawing.Color.Black;
			this.txtInvoiceNo.LabelText = "Invoice#";
			this.txtInvoiceNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtInvoiceNo.LinkDisabledMessage = "Link Disabled";
			this.txtInvoiceNo.Location = new System.Drawing.Point(71, 33);
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			this.txtInvoiceNo.ReadOnly = true;
			this.txtInvoiceNo.Size = new System.Drawing.Size(122, 20);
			this.txtInvoiceNo.TabIndex = 1;
			this.txtInvoiceNo.TabStop = false;
			// 
			// txtVendor
			// 
			this.txtVendor.BackColor = System.Drawing.SystemColors.Control;
			this.txtVendor.ForeColor = System.Drawing.Color.Black;
			this.txtVendor.LabelText = "Vendor";
			this.txtVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVendor.LinkDisabledMessage = "Link Disabled";
			this.txtVendor.Location = new System.Drawing.Point(71, 9);
			this.txtVendor.Name = "txtVendor";
			this.txtVendor.ReadOnly = true;
			this.txtVendor.Size = new System.Drawing.Size(177, 20);
			this.txtVendor.TabIndex = 0;
			this.txtVendor.TabStop = false;
			// 
			// grdChargeDetail
			// 
			grdChargeDetail_DesignTimeLayout.LayoutString = resources.GetString("grdChargeDetail_DesignTimeLayout.LayoutString");
			this.grdChargeDetail.DesignTimeLayout = grdChargeDetail_DesignTimeLayout;
			this.grdChargeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdChargeDetail.ExportFileID = null;
			this.grdChargeDetail.Location = new System.Drawing.Point(0, 88);
			this.grdChargeDetail.Name = "grdChargeDetail";
			this.grdChargeDetail.Size = new System.Drawing.Size(782, 408);
			this.grdChargeDetail.TabIndex = 1;
			// 
			// frmViewAPInvoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdChargeDetail);
			this.Controls.Add(this.pnlInvoice);
			this.Name = "frmViewAPInvoice";
			this.Text = "View AP Invoice";
			this.Load += new System.EventHandler(this.frmViewAPInvoice_Load);
			this.pnlInvoice.ResumeLayout(false);
			this.pnlInvoice.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdChargeDetail)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlInvoice;
		private CommonWinCtrls.ucDateTextBox txtInvoiceDt;
		private CommonWinCtrls.ucTextBox txtInvoiceNo;
		private CommonWinCtrls.ucTextBox txtVendor;
		private CommonWinCtrls.ucGridEx grdChargeDetail;
	}
}