namespace CS2010.ArcSys.Win
{
    partial class frmLINEImport
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
			this.txtError = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSuccess = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewBookings = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewLocations = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnImport = new CS2010.CommonWinCtrls.ucButton();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewCargo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTempTime = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtLastSQL = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBookingUpds = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCargoUpds = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCargoCount = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBookingCount = new CS2010.CommonWinCtrls.ucTextBox();
			this.cbxFull = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnAdd2ILMS = new CS2010.CommonWinCtrls.ucButton();
			this.txtVessels = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewCustomers = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewActivity = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnUpdateILMS = new CS2010.CommonWinCtrls.ucButton();
			this.btnDeleteCargo = new System.Windows.Forms.Button();
			this.btnRefreshAll = new System.Windows.Forms.Button();
			this.txtDeletedCargo = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucButton1 = new CS2010.CommonWinCtrls.ucButton();
			this.ucButton2 = new CS2010.CommonWinCtrls.ucButton();
			this.grpHide = new CS2010.CommonWinCtrls.ucGroupBox();
			this.grpHide.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.SystemColors.Control;
			this.txtError.ForeColor = System.Drawing.Color.Black;
			this.txtError.LabelText = "Errors";
			this.txtError.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtError.LinkDisabledMessage = "Link Disabled";
			this.txtError.Location = new System.Drawing.Point(23, 160);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.ReadOnly = true;
			this.txtError.Size = new System.Drawing.Size(364, 52);
			this.txtError.TabIndex = 1;
			this.txtError.TabStop = false;
			// 
			// txtSuccess
			// 
			this.txtSuccess.BackColor = System.Drawing.SystemColors.Control;
			this.txtSuccess.ForeColor = System.Drawing.Color.Black;
			this.txtSuccess.LabelText = "Success Status";
			this.txtSuccess.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSuccess.LinkDisabledMessage = "Link Disabled";
			this.txtSuccess.Location = new System.Drawing.Point(23, 134);
			this.txtSuccess.Name = "txtSuccess";
			this.txtSuccess.ReadOnly = true;
			this.txtSuccess.Size = new System.Drawing.Size(100, 20);
			this.txtSuccess.TabIndex = 2;
			this.txtSuccess.TabStop = false;
			// 
			// txtNewBookings
			// 
			this.txtNewBookings.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewBookings.ForeColor = System.Drawing.Color.Black;
			this.txtNewBookings.LabelText = "New Bookings";
			this.txtNewBookings.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewBookings.LinkDisabledMessage = "Link Disabled";
			this.txtNewBookings.Location = new System.Drawing.Point(103, 67);
			this.txtNewBookings.Name = "txtNewBookings";
			this.txtNewBookings.ReadOnly = true;
			this.txtNewBookings.Size = new System.Drawing.Size(100, 20);
			this.txtNewBookings.TabIndex = 3;
			this.txtNewBookings.TabStop = false;
			// 
			// txtNewLocations
			// 
			this.txtNewLocations.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewLocations.ForeColor = System.Drawing.Color.Black;
			this.txtNewLocations.LabelText = "New Locations";
			this.txtNewLocations.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewLocations.LinkDisabledMessage = "Link Disabled";
			this.txtNewLocations.Location = new System.Drawing.Point(23, 65);
			this.txtNewLocations.Name = "txtNewLocations";
			this.txtNewLocations.ReadOnly = true;
			this.txtNewLocations.Size = new System.Drawing.Size(100, 20);
			this.txtNewLocations.TabIndex = 4;
			this.txtNewLocations.TabStop = false;
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(219, 15);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(110, 23);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "Import LINE";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(103, 15);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtVoyage.TabIndex = 0;
			// 
			// txtNewCargo
			// 
			this.txtNewCargo.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewCargo.ForeColor = System.Drawing.Color.Black;
			this.txtNewCargo.LabelText = "New Cargo";
			this.txtNewCargo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewCargo.LinkDisabledMessage = "Link Disabled";
			this.txtNewCargo.Location = new System.Drawing.Point(103, 93);
			this.txtNewCargo.Name = "txtNewCargo";
			this.txtNewCargo.ReadOnly = true;
			this.txtNewCargo.Size = new System.Drawing.Size(100, 20);
			this.txtNewCargo.TabIndex = 7;
			this.txtNewCargo.TabStop = false;
			// 
			// txtTempTime
			// 
			this.txtTempTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtTempTime.ForeColor = System.Drawing.Color.Black;
			this.txtTempTime.LabelText = "Refresh Time";
			this.txtTempTime.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTempTime.LinkDisabledMessage = "Link Disabled";
			this.txtTempTime.Location = new System.Drawing.Point(103, 41);
			this.txtTempTime.Name = "txtTempTime";
			this.txtTempTime.ReadOnly = true;
			this.txtTempTime.Size = new System.Drawing.Size(100, 20);
			this.txtTempTime.TabIndex = 12;
			this.txtTempTime.TabStop = false;
			// 
			// txtLastSQL
			// 
			this.txtLastSQL.BackColor = System.Drawing.SystemColors.Control;
			this.txtLastSQL.ForeColor = System.Drawing.Color.Black;
			this.txtLastSQL.LinkDisabledMessage = "Link Disabled";
			this.txtLastSQL.Location = new System.Drawing.Point(22, 218);
			this.txtLastSQL.Multiline = true;
			this.txtLastSQL.Name = "txtLastSQL";
			this.txtLastSQL.ReadOnly = true;
			this.txtLastSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLastSQL.Size = new System.Drawing.Size(364, 51);
			this.txtLastSQL.TabIndex = 13;
			this.txtLastSQL.TabStop = false;
			// 
			// txtBookingUpds
			// 
			this.txtBookingUpds.BackColor = System.Drawing.SystemColors.Control;
			this.txtBookingUpds.ForeColor = System.Drawing.Color.Black;
			this.txtBookingUpds.LabelText = "Updated";
			this.txtBookingUpds.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBookingUpds.LinkDisabledMessage = "Link Disabled";
			this.txtBookingUpds.Location = new System.Drawing.Point(287, 67);
			this.txtBookingUpds.Name = "txtBookingUpds";
			this.txtBookingUpds.ReadOnly = true;
			this.txtBookingUpds.Size = new System.Drawing.Size(100, 20);
			this.txtBookingUpds.TabIndex = 14;
			this.txtBookingUpds.TabStop = false;
			// 
			// txtCargoUpds
			// 
			this.txtCargoUpds.BackColor = System.Drawing.SystemColors.Control;
			this.txtCargoUpds.ForeColor = System.Drawing.Color.Black;
			this.txtCargoUpds.LabelText = "Updated";
			this.txtCargoUpds.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCargoUpds.LinkDisabledMessage = "Link Disabled";
			this.txtCargoUpds.Location = new System.Drawing.Point(287, 93);
			this.txtCargoUpds.Name = "txtCargoUpds";
			this.txtCargoUpds.ReadOnly = true;
			this.txtCargoUpds.Size = new System.Drawing.Size(100, 20);
			this.txtCargoUpds.TabIndex = 15;
			this.txtCargoUpds.TabStop = false;
			// 
			// txtCargoCount
			// 
			this.txtCargoCount.BackColor = System.Drawing.SystemColors.Control;
			this.txtCargoCount.ForeColor = System.Drawing.Color.Black;
			this.txtCargoCount.LabelText = "Count";
			this.txtCargoCount.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCargoCount.LinkDisabledMessage = "Link Disabled";
			this.txtCargoCount.Location = new System.Drawing.Point(461, 93);
			this.txtCargoCount.Name = "txtCargoCount";
			this.txtCargoCount.ReadOnly = true;
			this.txtCargoCount.Size = new System.Drawing.Size(100, 20);
			this.txtCargoCount.TabIndex = 16;
			this.txtCargoCount.TabStop = false;
			// 
			// txtBookingCount
			// 
			this.txtBookingCount.BackColor = System.Drawing.SystemColors.Control;
			this.txtBookingCount.ForeColor = System.Drawing.Color.Black;
			this.txtBookingCount.LabelText = "Count";
			this.txtBookingCount.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBookingCount.LinkDisabledMessage = "Link Disabled";
			this.txtBookingCount.Location = new System.Drawing.Point(461, 67);
			this.txtBookingCount.Name = "txtBookingCount";
			this.txtBookingCount.ReadOnly = true;
			this.txtBookingCount.Size = new System.Drawing.Size(100, 20);
			this.txtBookingCount.TabIndex = 17;
			this.txtBookingCount.TabStop = false;
			// 
			// cbxFull
			// 
			this.cbxFull.Location = new System.Drawing.Point(606, 38);
			this.cbxFull.Name = "cbxFull";
			this.cbxFull.Size = new System.Drawing.Size(104, 24);
			this.cbxFull.TabIndex = 18;
			this.cbxFull.Text = "Full Refresh";
			this.cbxFull.UseVisualStyleBackColor = true;
			this.cbxFull.YN = "N";
			// 
			// btnAdd2ILMS
			// 
			this.btnAdd2ILMS.Location = new System.Drawing.Point(595, 97);
			this.btnAdd2ILMS.Name = "btnAdd2ILMS";
			this.btnAdd2ILMS.Size = new System.Drawing.Size(82, 23);
			this.btnAdd2ILMS.TabIndex = 19;
			this.btnAdd2ILMS.Text = "Add to ILMS";
			this.btnAdd2ILMS.UseVisualStyleBackColor = true;
			this.btnAdd2ILMS.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtVessels
			// 
			this.txtVessels.BackColor = System.Drawing.SystemColors.Control;
			this.txtVessels.ForeColor = System.Drawing.Color.Black;
			this.txtVessels.LabelText = "New Vessels";
			this.txtVessels.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVessels.LinkDisabledMessage = "Link Disabled";
			this.txtVessels.Location = new System.Drawing.Point(381, 65);
			this.txtVessels.Name = "txtVessels";
			this.txtVessels.ReadOnly = true;
			this.txtVessels.Size = new System.Drawing.Size(100, 20);
			this.txtVessels.TabIndex = 20;
			this.txtVessels.TabStop = false;
			// 
			// txtNewCustomers
			// 
			this.txtNewCustomers.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewCustomers.ForeColor = System.Drawing.Color.Black;
			this.txtNewCustomers.LabelText = "New Customers";
			this.txtNewCustomers.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewCustomers.LinkDisabledMessage = "Link Disabled";
			this.txtNewCustomers.Location = new System.Drawing.Point(207, 65);
			this.txtNewCustomers.Name = "txtNewCustomers";
			this.txtNewCustomers.ReadOnly = true;
			this.txtNewCustomers.Size = new System.Drawing.Size(100, 20);
			this.txtNewCustomers.TabIndex = 21;
			this.txtNewCustomers.TabStop = false;
			// 
			// txtNewActivity
			// 
			this.txtNewActivity.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewActivity.ForeColor = System.Drawing.Color.Black;
			this.txtNewActivity.LabelText = "New Activity";
			this.txtNewActivity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewActivity.LinkDisabledMessage = "Link Disabled";
			this.txtNewActivity.Location = new System.Drawing.Point(23, 38);
			this.txtNewActivity.Name = "txtNewActivity";
			this.txtNewActivity.ReadOnly = true;
			this.txtNewActivity.Size = new System.Drawing.Size(100, 20);
			this.txtNewActivity.TabIndex = 22;
			this.txtNewActivity.TabStop = false;
			// 
			// btnUpdateILMS
			// 
			this.btnUpdateILMS.Location = new System.Drawing.Point(595, 126);
			this.btnUpdateILMS.Name = "btnUpdateILMS";
			this.btnUpdateILMS.Size = new System.Drawing.Size(78, 23);
			this.btnUpdateILMS.TabIndex = 23;
			this.btnUpdateILMS.Text = "Update ILMS";
			this.btnUpdateILMS.UseVisualStyleBackColor = true;
			this.btnUpdateILMS.Click += new System.EventHandler(this.btnUpdateILMS_Click);
			// 
			// btnDeleteCargo
			// 
			this.btnDeleteCargo.Location = new System.Drawing.Point(595, 155);
			this.btnDeleteCargo.Name = "btnDeleteCargo";
			this.btnDeleteCargo.Size = new System.Drawing.Size(111, 23);
			this.btnDeleteCargo.TabIndex = 24;
			this.btnDeleteCargo.Text = "Deleted Cargo";
			this.btnDeleteCargo.UseVisualStyleBackColor = true;
			this.btnDeleteCargo.Click += new System.EventHandler(this.btnDeleteCargo_Click);
			// 
			// btnRefreshAll
			// 
			this.btnRefreshAll.Location = new System.Drawing.Point(595, 68);
			this.btnRefreshAll.Name = "btnRefreshAll";
			this.btnRefreshAll.Size = new System.Drawing.Size(75, 23);
			this.btnRefreshAll.TabIndex = 25;
			this.btnRefreshAll.Text = "Refresh All";
			this.btnRefreshAll.UseVisualStyleBackColor = true;
			this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
			// 
			// txtDeletedCargo
			// 
			this.txtDeletedCargo.BackColor = System.Drawing.SystemColors.Control;
			this.txtDeletedCargo.ForeColor = System.Drawing.Color.Black;
			this.txtDeletedCargo.LabelText = "Deleted Cargo";
			this.txtDeletedCargo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDeletedCargo.LinkDisabledMessage = "Link Disabled";
			this.txtDeletedCargo.Location = new System.Drawing.Point(23, 104);
			this.txtDeletedCargo.Name = "txtDeletedCargo";
			this.txtDeletedCargo.ReadOnly = true;
			this.txtDeletedCargo.Size = new System.Drawing.Size(100, 20);
			this.txtDeletedCargo.TabIndex = 26;
			this.txtDeletedCargo.TabStop = false;
			// 
			// ucButton1
			// 
			this.ucButton1.Location = new System.Drawing.Point(595, 184);
			this.ucButton1.Name = "ucButton1";
			this.ucButton1.Size = new System.Drawing.Size(107, 23);
			this.ucButton1.TabIndex = 27;
			this.ucButton1.Text = "Find Deleted Cargo";
			this.ucButton1.UseVisualStyleBackColor = true;
			this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
			// 
			// ucButton2
			// 
			this.ucButton2.Location = new System.Drawing.Point(595, 213);
			this.ucButton2.Name = "ucButton2";
			this.ucButton2.Size = new System.Drawing.Size(75, 23);
			this.ucButton2.TabIndex = 28;
			this.ucButton2.Text = "IMDG";
			this.ucButton2.UseVisualStyleBackColor = true;
			this.ucButton2.Click += new System.EventHandler(this.ucButton2_Click);
			// 
			// grpHide
			// 
			this.grpHide.Controls.Add(this.txtNewActivity);
			this.grpHide.Controls.Add(this.ucButton2);
			this.grpHide.Controls.Add(this.ucButton1);
			this.grpHide.Controls.Add(this.txtDeletedCargo);
			this.grpHide.Controls.Add(this.btnRefreshAll);
			this.grpHide.Controls.Add(this.txtError);
			this.grpHide.Controls.Add(this.btnDeleteCargo);
			this.grpHide.Controls.Add(this.btnUpdateILMS);
			this.grpHide.Controls.Add(this.txtSuccess);
			this.grpHide.Controls.Add(this.btnAdd2ILMS);
			this.grpHide.Controls.Add(this.cbxFull);
			this.grpHide.Controls.Add(this.txtNewLocations);
			this.grpHide.Controls.Add(this.txtLastSQL);
			this.grpHide.Controls.Add(this.txtNewCustomers);
			this.grpHide.Controls.Add(this.txtVessels);
			this.grpHide.Location = new System.Drawing.Point(26, 144);
			this.grpHide.Name = "grpHide";
			this.grpHide.Size = new System.Drawing.Size(845, 301);
			this.grpHide.TabIndex = 29;
			this.grpHide.TabStop = false;
			this.grpHide.Text = "ucGroupBox1";
			this.grpHide.Visible = false;
			// 
			// frmLINEImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 460);
			this.Controls.Add(this.grpHide);
			this.Controls.Add(this.txtBookingCount);
			this.Controls.Add(this.txtCargoCount);
			this.Controls.Add(this.txtCargoUpds);
			this.Controls.Add(this.txtBookingUpds);
			this.Controls.Add(this.txtTempTime);
			this.Controls.Add(this.txtNewCargo);
			this.Controls.Add(this.txtVoyage);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.txtNewBookings);
			this.Name = "frmLINEImport";
			this.Text = "Import LINE Data Warehouse";
			this.grpHide.ResumeLayout(false);
			this.grpHide.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CommonWinCtrls.ucTextBox txtError;
        private CommonWinCtrls.ucTextBox txtSuccess;
        private CommonWinCtrls.ucTextBox txtNewBookings;
        private CommonWinCtrls.ucTextBox txtNewLocations;
        private CommonWinCtrls.ucButton btnImport;
        private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucTextBox txtNewCargo;
        private CommonWinCtrls.ucTextBox txtTempTime;
		private CommonWinCtrls.ucTextBox txtLastSQL;
		private CommonWinCtrls.ucTextBox txtBookingUpds;
		private CommonWinCtrls.ucTextBox txtCargoUpds;
		private CommonWinCtrls.ucTextBox txtCargoCount;
		private CommonWinCtrls.ucTextBox txtBookingCount;
		private CommonWinCtrls.ucCheckBox cbxFull;
		private CommonWinCtrls.ucButton btnAdd2ILMS;
		private CommonWinCtrls.ucTextBox txtVessels;
		private CommonWinCtrls.ucTextBox txtNewCustomers;
		private CommonWinCtrls.ucTextBox txtNewActivity;
		private CommonWinCtrls.ucButton btnUpdateILMS;
		private System.Windows.Forms.Button btnDeleteCargo;
		private System.Windows.Forms.Button btnRefreshAll;
		private CommonWinCtrls.ucTextBox txtDeletedCargo;
		private CommonWinCtrls.ucButton ucButton1;
		private CommonWinCtrls.ucButton ucButton2;
		private CommonWinCtrls.ucGroupBox grpHide;
    }
}