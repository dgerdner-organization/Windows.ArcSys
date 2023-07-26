namespace CS2010.ArcSys.Win
{
	partial class frmStenaUnbookedList
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
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStenaUnbookedList));
			Janus.Windows.GridEX.GridEXLayout cmbSailings_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdStenaAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.grpStena = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btnSave = new CS2010.CommonWinCtrls.ucButton();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.cbxStenaSailing = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnBookgStena = new CS2010.CommonWinCtrls.ucButton();
			this.cmbSailings = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtStenaID = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCargoTrailerNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtStenaDate = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCargoRoute = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVehicleType = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdStenaAudit = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btnGetTrailers = new CS2010.CommonWinCtrls.ucButton();
			this.txtDeliveryDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlMainGrid = new CS2010.CommonWinCtrls.ucPanel();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.pnlDetail = new CS2010.CommonWinCtrls.ucPanel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.grpStena.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbSailings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdStenaAudit)).BeginInit();
			this.ucGroupBox2.SuspendLayout();
			this.pnlMainGrid.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			this.sbrChild.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.btnSearch);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1172, 50);
			this.pnlTop.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(13, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.GroupByBoxVisible = false;
			this.grdMain.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdMain.Location = new System.Drawing.Point(0, 0);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(1172, 302);
			this.grdMain.TabIndex = 1;
			this.grdMain.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_ColumnButtonClick);
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// grpStena
			// 
			this.grpStena.Controls.Add(this.btnSave);
			this.grpStena.Controls.Add(this.btnEdit);
			this.grpStena.Controls.Add(this.cbxStenaSailing);
			this.grpStena.Controls.Add(this.btnBookgStena);
			this.grpStena.Controls.Add(this.cmbSailings);
			this.grpStena.Controls.Add(this.txtStenaID);
			this.grpStena.Controls.Add(this.txtCargoTrailerNo);
			this.grpStena.Controls.Add(this.txtStenaDate);
			this.grpStena.Controls.Add(this.txtCargoRoute);
			this.grpStena.Controls.Add(this.txtVehicleType);
			this.grpStena.Location = new System.Drawing.Point(3, 3);
			this.grpStena.Name = "grpStena";
			this.grpStena.Size = new System.Drawing.Size(331, 198);
			this.grpStena.TabIndex = 14;
			this.grpStena.TabStop = false;
			this.grpStena.Text = "Stena";
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(255, 167);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 23);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(185, 167);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(67, 23);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// cbxStenaSailing
			// 
			this.cbxStenaSailing.Location = new System.Drawing.Point(85, 120);
			this.cbxStenaSailing.Name = "cbxStenaSailing";
			this.cbxStenaSailing.Size = new System.Drawing.Size(92, 17);
			this.cbxStenaSailing.TabIndex = 12;
			this.cbxStenaSailing.Text = "Pick a Sailing";
			this.cbxStenaSailing.UseVisualStyleBackColor = true;
			this.cbxStenaSailing.YN = "N";
			this.cbxStenaSailing.CheckedChanged += new System.EventHandler(this.cbxStenaSailing_CheckedChanged);
			// 
			// btnBookgStena
			// 
			this.btnBookgStena.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnBookgStena.Location = new System.Drawing.Point(85, 167);
			this.btnBookgStena.Name = "btnBookgStena";
			this.btnBookgStena.Size = new System.Drawing.Size(94, 23);
			this.btnBookgStena.TabIndex = 11;
			this.btnBookgStena.Text = "Book with Stena";
			this.btnBookgStena.UseVisualStyleBackColor = true;
			this.btnBookgStena.Click += new System.EventHandler(this.btnBookgStena_Click);
			// 
			// cmbSailings
			// 
			cmbSailings_DesignTimeLayout.LayoutString = resources.GetString("cmbSailings_DesignTimeLayout.LayoutString");
			this.cmbSailings.DesignTimeLayout = cmbSailings_DesignTimeLayout;
			this.cmbSailings.DisplayMember = "sailing_dt";
			this.cmbSailings.Enabled = false;
			this.cmbSailings.LabelText = "Stena Sailings";
			this.cmbSailings.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbSailings.Location = new System.Drawing.Point(85, 141);
			this.cmbSailings.Name = "cmbSailings";
			this.cmbSailings.SelectedIndex = -1;
			this.cmbSailings.SelectedItem = null;
			this.cmbSailings.Size = new System.Drawing.Size(233, 20);
			this.cmbSailings.TabIndex = 10;
			this.cmbSailings.ValueMember = "sailing_dt";
			// 
			// txtStenaID
			// 
			this.txtStenaID.BackColor = System.Drawing.SystemColors.Control;
			this.txtStenaID.ForeColor = System.Drawing.Color.Black;
			this.txtStenaID.LabelText = "Stena ID";
			this.txtStenaID.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtStenaID.LinkDisabledMessage = "Link Disabled";
			this.txtStenaID.Location = new System.Drawing.Point(85, 10);
			this.txtStenaID.Name = "txtStenaID";
			this.txtStenaID.ReadOnly = true;
			this.txtStenaID.Size = new System.Drawing.Size(100, 20);
			this.txtStenaID.TabIndex = 5;
			this.txtStenaID.TabStop = false;
			// 
			// txtCargoTrailerNo
			// 
			this.txtCargoTrailerNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtCargoTrailerNo.ForeColor = System.Drawing.Color.Black;
			this.txtCargoTrailerNo.LabelText = "Trailer#";
			this.txtCargoTrailerNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCargoTrailerNo.LinkDisabledMessage = "Link Disabled";
			this.txtCargoTrailerNo.Location = new System.Drawing.Point(85, 31);
			this.txtCargoTrailerNo.Name = "txtCargoTrailerNo";
			this.txtCargoTrailerNo.ReadOnly = true;
			this.txtCargoTrailerNo.Size = new System.Drawing.Size(100, 20);
			this.txtCargoTrailerNo.TabIndex = 6;
			this.txtCargoTrailerNo.TabStop = false;
			// 
			// txtStenaDate
			// 
			this.txtStenaDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtStenaDate.ForeColor = System.Drawing.Color.Black;
			this.txtStenaDate.LabelText = "Sailing Date";
			this.txtStenaDate.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtStenaDate.LinkDisabledMessage = "Link Disabled";
			this.txtStenaDate.Location = new System.Drawing.Point(85, 94);
			this.txtStenaDate.Name = "txtStenaDate";
			this.txtStenaDate.ReadOnly = true;
			this.txtStenaDate.Size = new System.Drawing.Size(100, 20);
			this.txtStenaDate.TabIndex = 9;
			this.txtStenaDate.TabStop = false;
			// 
			// txtCargoRoute
			// 
			this.txtCargoRoute.BackColor = System.Drawing.SystemColors.Control;
			this.txtCargoRoute.ForeColor = System.Drawing.Color.Black;
			this.txtCargoRoute.LabelText = "Stena Route";
			this.txtCargoRoute.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCargoRoute.LinkDisabledMessage = "Link Disabled";
			this.txtCargoRoute.Location = new System.Drawing.Point(85, 52);
			this.txtCargoRoute.Name = "txtCargoRoute";
			this.txtCargoRoute.ReadOnly = true;
			this.txtCargoRoute.Size = new System.Drawing.Size(100, 20);
			this.txtCargoRoute.TabIndex = 7;
			this.txtCargoRoute.TabStop = false;
			// 
			// txtVehicleType
			// 
			this.txtVehicleType.BackColor = System.Drawing.SystemColors.Control;
			this.txtVehicleType.ForeColor = System.Drawing.Color.Black;
			this.txtVehicleType.LabelText = "Vehicle Type";
			this.txtVehicleType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVehicleType.LinkDisabledMessage = "Link Disabled";
			this.txtVehicleType.Location = new System.Drawing.Point(85, 73);
			this.txtVehicleType.Name = "txtVehicleType";
			this.txtVehicleType.ReadOnly = true;
			this.txtVehicleType.Size = new System.Drawing.Size(100, 20);
			this.txtVehicleType.TabIndex = 8;
			this.txtVehicleType.TabStop = false;
			// 
			// grdStenaAudit
			// 
			grdStenaAudit_DesignTimeLayout.LayoutString = resources.GetString("grdStenaAudit_DesignTimeLayout.LayoutString");
			this.grdStenaAudit.DesignTimeLayout = grdStenaAudit_DesignTimeLayout;
			this.grdStenaAudit.ExportFileID = null;
			this.grdStenaAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdStenaAudit.GroupByBoxVisible = false;
			this.grdStenaAudit.Location = new System.Drawing.Point(0, 579);
			this.grdStenaAudit.Name = "grdStenaAudit";
			this.grdStenaAudit.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdStenaAudit.Size = new System.Drawing.Size(826, 134);
			this.grdStenaAudit.TabIndex = 15;
			// 
			// ucGroupBox2
			// 
			this.ucGroupBox2.Controls.Add(this.btnGetTrailers);
			this.ucGroupBox2.Controls.Add(this.txtDeliveryDsc);
			this.ucGroupBox2.Location = new System.Drawing.Point(347, 4);
			this.ucGroupBox2.Name = "ucGroupBox2";
			this.ucGroupBox2.Size = new System.Drawing.Size(253, 197);
			this.ucGroupBox2.TabIndex = 16;
			this.ucGroupBox2.TabStop = false;
			this.ucGroupBox2.Text = "Booking";
			// 
			// btnGetTrailers
			// 
			this.btnGetTrailers.Location = new System.Drawing.Point(7, 166);
			this.btnGetTrailers.Name = "btnGetTrailers";
			this.btnGetTrailers.Size = new System.Drawing.Size(114, 23);
			this.btnGetTrailers.TabIndex = 1;
			this.btnGetTrailers.Text = "Extract Trailer#\'s";
			this.btnGetTrailers.UseVisualStyleBackColor = true;
			this.btnGetTrailers.Click += new System.EventHandler(this.btnGetTrailers_Click);
			// 
			// txtDeliveryDsc
			// 
			this.txtDeliveryDsc.LinkDisabledMessage = "Link Disabled";
			this.txtDeliveryDsc.Location = new System.Drawing.Point(7, 17);
			this.txtDeliveryDsc.Multiline = true;
			this.txtDeliveryDsc.Name = "txtDeliveryDsc";
			this.txtDeliveryDsc.Size = new System.Drawing.Size(239, 89);
			this.txtDeliveryDsc.TabIndex = 0;
			// 
			// pnlMainGrid
			// 
			this.pnlMainGrid.Controls.Add(this.grdMain);
			this.pnlMainGrid.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMainGrid.Location = new System.Drawing.Point(0, 50);
			this.pnlMainGrid.Name = "pnlMainGrid";
			this.pnlMainGrid.Size = new System.Drawing.Size(1172, 302);
			this.pnlMainGrid.TabIndex = 17;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(5, 563);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(183, 13);
			this.ucLabel1.TabIndex = 18;
			this.ucLabel1.Text = "Stena Booking Error Message History";
			// 
			// pnlDetail
			// 
			this.pnlDetail.Controls.Add(this.grpStena);
			this.pnlDetail.Controls.Add(this.ucGroupBox2);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlDetail.Location = new System.Drawing.Point(0, 352);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Size = new System.Drawing.Size(1172, 208);
			this.pnlDetail.TabIndex = 19;
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 758);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(1172, 22);
			this.sbrChild.TabIndex = 20;
			this.sbrChild.Text = "Search Available Main Status Strip";
			this.sbrChild.Visible = false;
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(227, 17);
			this.sbbProgressCaption.Text = "Processing... (Click here to cancel the search)";
			this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// frmStenaUnbookedList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1172, 780);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.ucLabel1);
			this.Controls.Add(this.pnlMainGrid);
			this.Controls.Add(this.grdStenaAudit);
			this.Controls.Add(this.pnlTop);
			this.Name = "frmStenaUnbookedList";
			this.Text = "List Unbooked Stena Cargo";
			this.pnlTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.grpStena.ResumeLayout(false);
			this.grpStena.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbSailings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdStenaAudit)).EndInit();
			this.ucGroupBox2.ResumeLayout(false);
			this.ucGroupBox2.PerformLayout();
			this.pnlMainGrid.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlTop;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucGroupBox grpStena;
		private CommonWinCtrls.ucCheckBox cbxStenaSailing;
		private CommonWinCtrls.ucButton btnBookgStena;
		private CommonWinCtrls.ucMultiColumnCombo cmbSailings;
		private CommonWinCtrls.ucTextBox txtStenaID;
		private CommonWinCtrls.ucTextBox txtCargoTrailerNo;
		private CommonWinCtrls.ucTextBox txtStenaDate;
		private CommonWinCtrls.ucTextBox txtCargoRoute;
		private CommonWinCtrls.ucTextBox txtVehicleType;
		private CommonWinCtrls.ucGridEx grdStenaAudit;
		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucTextBox txtDeliveryDsc;
		private CommonWinCtrls.ucPanel pnlMainGrid;
		private CommonWinCtrls.ucButton btnGetTrailers;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucPanel pnlDetail;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private CommonWinCtrls.ucButton btnEdit;
		private CommonWinCtrls.ucButton btnSave;
	}
}
