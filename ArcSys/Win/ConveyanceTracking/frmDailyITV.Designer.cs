namespace CS2010.ArcSys.Win
{
	partial class frmDailyITV
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
			Janus.Windows.GridEX.GridEXLayout cmbPartner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailyITV));
			Janus.Windows.GridEX.GridEXLayout grdDailyITV_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.pnlHeader = new CS2010.CommonWinCtrls.ucPanel();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.cmbPartner = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grdDailyITV = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGridToolStrip1 = new CS2010.CommonWinCtrls.ucGridToolStrip();
			this.pnlHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDailyITV)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlHeader.Controls.Add(this.btnSearch);
			this.pnlHeader.Controls.Add(this.cmbPartner);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(776, 67);
			this.pnlHeader.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(394, 8);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cmbPartner
			// 
			cmbPartner_DesignTimeLayout.LayoutString = resources.GetString("cmbPartner_DesignTimeLayout.LayoutString");
			this.cmbPartner.DesignTimeLayout = cmbPartner_DesignTimeLayout;
			this.cmbPartner.DisplayMember = "partner_dsc";
			this.cmbPartner.ForeColor = System.Drawing.Color.Black;
			this.cmbPartner.LabelText = "Customer";
			this.cmbPartner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPartner.Location = new System.Drawing.Point(123, 10);
			this.cmbPartner.Name = "cmbPartner";
			this.cmbPartner.SelectedIndex = -1;
			this.cmbPartner.SelectedItem = null;
			this.cmbPartner.Size = new System.Drawing.Size(257, 20);
			this.cmbPartner.TabIndex = 3;
			this.cmbPartner.ValueMember = "trading_partner_cd";
			// 
			// grdDailyITV
			// 
			grdDailyITV_DesignTimeLayout.LayoutString = resources.GetString("grdDailyITV_DesignTimeLayout.LayoutString");
			this.grdDailyITV.DesignTimeLayout = grdDailyITV_DesignTimeLayout;
			this.grdDailyITV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDailyITV.ExportFileID = null;
			this.grdDailyITV.Location = new System.Drawing.Point(0, 92);
			this.grdDailyITV.Name = "grdDailyITV";
			this.grdDailyITV.Size = new System.Drawing.Size(776, 497);
			this.grdDailyITV.TabIndex = 1;
			this.grdDailyITV.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdDailyITV_FormattingRow);
			// 
			// ucGridToolStrip1
			// 
			this.ucGridToolStrip1.GridObject = null;
			this.ucGridToolStrip1.Location = new System.Drawing.Point(0, 67);
			this.ucGridToolStrip1.Name = "ucGridToolStrip1";
			this.ucGridToolStrip1.Size = new System.Drawing.Size(776, 25);
			this.ucGridToolStrip1.TabIndex = 2;
			this.ucGridToolStrip1.Text = "ucGridToolStrip1";
			// 
			// frmDailyITV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 589);
			this.Controls.Add(this.grdDailyITV);
			this.Controls.Add(this.ucGridToolStrip1);
			this.Controls.Add(this.pnlHeader);
			this.Name = "frmDailyITV";
			this.Text = "Daily ITV";
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDailyITV)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlHeader;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartner;
		private CommonWinCtrls.ucGridEx grdDailyITV;
		private CommonWinCtrls.ucGridToolStrip ucGridToolStrip1;

	}
}