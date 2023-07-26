namespace CS2010.ArcSys.Win
{
    partial class frmImportFromLINE
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
			this.txtPurged = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtError = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSuccess = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewBookings = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewLocations = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnImport = new CS2010.CommonWinCtrls.ucButton();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewCargo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNewCargoActivity = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnRefresh = new CS2010.CommonWinCtrls.ucButton();
			this.btnUpdate = new CS2010.CommonWinCtrls.ucButton();
			this.txtLiveTime = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTempTime = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtLastSQL = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.SuspendLayout();
			// 
			// txtPurged
			// 
			this.txtPurged.BackColor = System.Drawing.SystemColors.Control;
			this.txtPurged.ForeColor = System.Drawing.Color.Black;
			this.txtPurged.LabelText = "Purged";
			this.txtPurged.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPurged.LinkDisabledMessage = "Link Disabled";
			this.txtPurged.Location = new System.Drawing.Point(198, 73);
			this.txtPurged.Name = "txtPurged";
			this.txtPurged.ReadOnly = true;
			this.txtPurged.Size = new System.Drawing.Size(100, 20);
			this.txtPurged.TabIndex = 0;
			this.txtPurged.TabStop = false;
			this.txtPurged.TextChanged += new System.EventHandler(this.txtPurged_TextChanged);
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.SystemColors.Control;
			this.txtError.ForeColor = System.Drawing.Color.Black;
			this.txtError.LabelText = "Errors";
			this.txtError.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtError.LinkDisabledMessage = "Link Disabled";
			this.txtError.Location = new System.Drawing.Point(198, 284);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.ReadOnly = true;
			this.txtError.Size = new System.Drawing.Size(364, 72);
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
			this.txtSuccess.Location = new System.Drawing.Point(198, 258);
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
			this.txtNewBookings.Location = new System.Drawing.Point(198, 100);
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
			this.txtNewLocations.Location = new System.Drawing.Point(198, 179);
			this.txtNewLocations.Name = "txtNewLocations";
			this.txtNewLocations.ReadOnly = true;
			this.txtNewLocations.Size = new System.Drawing.Size(100, 20);
			this.txtNewLocations.TabIndex = 4;
			this.txtNewLocations.TabStop = false;
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(304, 43);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 5;
			this.btnImport.Text = "Refresh";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(198, 43);
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
			this.txtNewCargo.Location = new System.Drawing.Point(198, 126);
			this.txtNewCargo.Name = "txtNewCargo";
			this.txtNewCargo.ReadOnly = true;
			this.txtNewCargo.Size = new System.Drawing.Size(100, 20);
			this.txtNewCargo.TabIndex = 7;
			this.txtNewCargo.TabStop = false;
			// 
			// txtNewCargoActivity
			// 
			this.txtNewCargoActivity.BackColor = System.Drawing.SystemColors.Control;
			this.txtNewCargoActivity.ForeColor = System.Drawing.Color.Black;
			this.txtNewCargoActivity.LabelText = "New Cargo Activity";
			this.txtNewCargoActivity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewCargoActivity.LinkDisabledMessage = "Link Disabled";
			this.txtNewCargoActivity.Location = new System.Drawing.Point(198, 152);
			this.txtNewCargoActivity.Name = "txtNewCargoActivity";
			this.txtNewCargoActivity.ReadOnly = true;
			this.txtNewCargoActivity.Size = new System.Drawing.Size(100, 20);
			this.txtNewCargoActivity.TabIndex = 8;
			this.txtNewCargoActivity.TabStop = false;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(385, 43);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(127, 23);
			this.btnRefresh.TabIndex = 9;
			this.btnRefresh.Text = "Refresh Temp Table";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(518, 43);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(92, 23);
			this.btnUpdate.TabIndex = 10;
			this.btnUpdate.Text = "Update Cargo";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtLiveTime
			// 
			this.txtLiveTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtLiveTime.ForeColor = System.Drawing.Color.Black;
			this.txtLiveTime.LabelText = "Update Cargo Time";
			this.txtLiveTime.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLiveTime.LinkDisabledMessage = "Link Disabled";
			this.txtLiveTime.Location = new System.Drawing.Point(198, 232);
			this.txtLiveTime.Name = "txtLiveTime";
			this.txtLiveTime.ReadOnly = true;
			this.txtLiveTime.Size = new System.Drawing.Size(100, 20);
			this.txtLiveTime.TabIndex = 11;
			this.txtLiveTime.TabStop = false;
			// 
			// txtTempTime
			// 
			this.txtTempTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtTempTime.ForeColor = System.Drawing.Color.Black;
			this.txtTempTime.LabelText = "Refresh Temp Table Time";
			this.txtTempTime.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTempTime.LinkDisabledMessage = "Link Disabled";
			this.txtTempTime.Location = new System.Drawing.Point(198, 205);
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
			this.txtLastSQL.Location = new System.Drawing.Point(198, 363);
			this.txtLastSQL.Multiline = true;
			this.txtLastSQL.Name = "txtLastSQL";
			this.txtLastSQL.ReadOnly = true;
			this.txtLastSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLastSQL.Size = new System.Drawing.Size(364, 85);
			this.txtLastSQL.TabIndex = 13;
			this.txtLastSQL.TabStop = false;
			// 
			// ucLabel1
			// 
			this.ucLabel1.ForeColor = System.Drawing.Color.Red;
			this.ucLabel1.Location = new System.Drawing.Point(347, 152);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(119, 13);
			this.ucLabel1.TabIndex = 14;
			this.ucLabel1.Text = "This is the OLD window";
			// 
			// frmImportFromLINE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.ucLabel1);
			this.Controls.Add(this.txtLastSQL);
			this.Controls.Add(this.txtTempTime);
			this.Controls.Add(this.txtLiveTime);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.txtNewCargoActivity);
			this.Controls.Add(this.txtNewCargo);
			this.Controls.Add(this.txtVoyage);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.txtNewLocations);
			this.Controls.Add(this.txtNewBookings);
			this.Controls.Add(this.txtSuccess);
			this.Controls.Add(this.txtError);
			this.Controls.Add(this.txtPurged);
			this.Name = "frmImportFromLINE";
			this.Text = "Import Bookings from LINE";
			this.Load += new System.EventHandler(this.frmImportFromLINE_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucTextBox txtPurged;
        private CommonWinCtrls.ucTextBox txtError;
        private CommonWinCtrls.ucTextBox txtSuccess;
        private CommonWinCtrls.ucTextBox txtNewBookings;
        private CommonWinCtrls.ucTextBox txtNewLocations;
        private CommonWinCtrls.ucButton btnImport;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private CommonWinCtrls.ucTextBox txtNewCargo;
        private CommonWinCtrls.ucTextBox txtNewCargoActivity;
        private CommonWinCtrls.ucButton btnRefresh;
        private CommonWinCtrls.ucButton btnUpdate;
        private CommonWinCtrls.ucTextBox txtLiveTime;
        private CommonWinCtrls.ucTextBox txtTempTime;
		private CommonWinCtrls.ucTextBox txtLastSQL;
		private CommonWinCtrls.ucLabel ucLabel1;
    }
}