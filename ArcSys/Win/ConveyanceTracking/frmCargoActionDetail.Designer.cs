namespace CS2010.ArcSys.Win
{
    partial class frmCargoActionDetail
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoActionDetail));
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVessel = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCustomerRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtDeliveryDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtInGateDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtDecommissionDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCommissionDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtTagNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCustomsClearanceDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center;
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(299, 347);
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.FontData.SizeInPoints = 11F;
            this.ultraExpandableGroupBox1.HeaderAppearance = appearance3;
            this.ultraExpandableGroupBox1.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion;
            appearance4.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.FontData.SizeInPoints = 11F;
            this.ultraExpandableGroupBox1.HeaderCollapsedAppearance = appearance4;
            this.ultraExpandableGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftOnBorder;
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(299, 347);
            this.ultraExpandableGroupBox1.TabIndex = 14;
            this.ultraExpandableGroupBox1.Text = "Cargo Detail";
            this.ultraExpandableGroupBox1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtVoyage);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtVessel);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtCustomerRef);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtBookingNo);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtDeliveryDt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtInGateDt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtDecommissionDt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtCommissionDt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtTagNo);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtCustomsClearanceDt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.txtSerialNo);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(22, 3);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(274, 341);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // txtVoyage
            // 
            this.txtVoyage.BackColor = System.Drawing.SystemColors.Control;
            this.txtVoyage.ForeColor = System.Drawing.Color.Black;
            this.txtVoyage.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVoyage.LabelText = "Voyage:";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(113, 197);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.ReadOnly = true;
            this.txtVoyage.Size = new System.Drawing.Size(146, 20);
            this.txtVoyage.TabIndex = 10;
            this.txtVoyage.TabStop = false;
            // 
            // txtVessel
            // 
            this.txtVessel.BackColor = System.Drawing.SystemColors.Control;
            this.txtVessel.ForeColor = System.Drawing.Color.Black;
            this.txtVessel.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtVessel.LabelText = "Vessel";
            this.txtVessel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVessel.LinkDisabledMessage = "Link Disabled";
            this.txtVessel.Location = new System.Drawing.Point(113, 171);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.ReadOnly = true;
            this.txtVessel.Size = new System.Drawing.Size(146, 20);
            this.txtVessel.TabIndex = 9;
            this.txtVessel.TabStop = false;
            // 
            // txtCustomerRef
            // 
            this.txtCustomerRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerRef.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerRef.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtCustomerRef.LabelText = "PCFN:";
            this.txtCustomerRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomerRef.LinkDisabledMessage = "Link Disabled";
            this.txtCustomerRef.Location = new System.Drawing.Point(113, 145);
            this.txtCustomerRef.Name = "txtCustomerRef";
            this.txtCustomerRef.ReadOnly = true;
            this.txtCustomerRef.Size = new System.Drawing.Size(146, 20);
            this.txtCustomerRef.TabIndex = 8;
            this.txtCustomerRef.TabStop = false;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookingNo.ForeColor = System.Drawing.Color.Black;
            this.txtBookingNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtBookingNo.LabelText = "Booking #:";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(113, 119);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.ReadOnly = true;
            this.txtBookingNo.Size = new System.Drawing.Size(146, 20);
            this.txtBookingNo.TabIndex = 7;
            this.txtBookingNo.TabStop = false;
            // 
            // txtDeliveryDt
            // 
            this.txtDeliveryDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeliveryDt.ForeColor = System.Drawing.Color.Black;
            this.txtDeliveryDt.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtDeliveryDt.LabelText = "Proof of Delivery:";
            this.txtDeliveryDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDeliveryDt.LinkDisabledMessage = "Link Disabled";
            this.txtDeliveryDt.Location = new System.Drawing.Point(113, 275);
            this.txtDeliveryDt.Name = "txtDeliveryDt";
            this.txtDeliveryDt.ReadOnly = true;
            this.txtDeliveryDt.Size = new System.Drawing.Size(146, 20);
            this.txtDeliveryDt.TabIndex = 6;
            this.txtDeliveryDt.TabStop = false;
            // 
            // txtInGateDt
            // 
            this.txtInGateDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtInGateDt.ForeColor = System.Drawing.Color.Black;
            this.txtInGateDt.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtInGateDt.LabelText = "In-Gate:";
            this.txtInGateDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtInGateDt.LinkDisabledMessage = "Link Disabled";
            this.txtInGateDt.Location = new System.Drawing.Point(113, 249);
            this.txtInGateDt.Name = "txtInGateDt";
            this.txtInGateDt.ReadOnly = true;
            this.txtInGateDt.Size = new System.Drawing.Size(146, 20);
            this.txtInGateDt.TabIndex = 5;
            this.txtInGateDt.TabStop = false;
            // 
            // txtDecommissionDt
            // 
            this.txtDecommissionDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtDecommissionDt.ForeColor = System.Drawing.Color.Black;
            this.txtDecommissionDt.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtDecommissionDt.LabelText = "De-Commission Date:";
            this.txtDecommissionDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDecommissionDt.LinkDisabledMessage = "Link Disabled";
            this.txtDecommissionDt.Location = new System.Drawing.Point(113, 93);
            this.txtDecommissionDt.Name = "txtDecommissionDt";
            this.txtDecommissionDt.ReadOnly = true;
            this.txtDecommissionDt.Size = new System.Drawing.Size(146, 20);
            this.txtDecommissionDt.TabIndex = 4;
            this.txtDecommissionDt.TabStop = false;
            // 
            // txtCommissionDt
            // 
            this.txtCommissionDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtCommissionDt.ForeColor = System.Drawing.Color.Black;
            this.txtCommissionDt.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtCommissionDt.LabelText = "Commission Date:";
            this.txtCommissionDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCommissionDt.LinkDisabledMessage = "Link Disabled";
            this.txtCommissionDt.Location = new System.Drawing.Point(113, 67);
            this.txtCommissionDt.Name = "txtCommissionDt";
            this.txtCommissionDt.ReadOnly = true;
            this.txtCommissionDt.Size = new System.Drawing.Size(146, 20);
            this.txtCommissionDt.TabIndex = 3;
            this.txtCommissionDt.TabStop = false;
            // 
            // txtTagNo
            // 
            this.txtTagNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTagNo.ForeColor = System.Drawing.Color.Black;
            this.txtTagNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtTagNo.LabelText = "Tag #";
            this.txtTagNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTagNo.LinkDisabledMessage = "Link Disabled";
            this.txtTagNo.Location = new System.Drawing.Point(113, 41);
            this.txtTagNo.Name = "txtTagNo";
            this.txtTagNo.ReadOnly = true;
            this.txtTagNo.Size = new System.Drawing.Size(146, 20);
            this.txtTagNo.TabIndex = 2;
            this.txtTagNo.TabStop = false;
            // 
            // txtCustomsClearanceDt
            // 
            this.txtCustomsClearanceDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomsClearanceDt.ForeColor = System.Drawing.Color.Black;
            this.txtCustomsClearanceDt.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtCustomsClearanceDt.LabelText = "Customs Clearance:";
            this.txtCustomsClearanceDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomsClearanceDt.LinkDisabledMessage = "Link Disabled";
            this.txtCustomsClearanceDt.Location = new System.Drawing.Point(113, 223);
            this.txtCustomsClearanceDt.Name = "txtCustomsClearanceDt";
            this.txtCustomsClearanceDt.ReadOnly = true;
            this.txtCustomsClearanceDt.Size = new System.Drawing.Size(146, 20);
            this.txtCustomsClearanceDt.TabIndex = 1;
            this.txtCustomsClearanceDt.TabStop = false;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSerialNo.ForeColor = System.Drawing.Color.Black;
            this.txtSerialNo.LabelBackColor = System.Drawing.Color.Transparent;
            this.txtSerialNo.LabelText = "Serial #:";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(113, 15);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(146, 20);
            this.txtSerialNo.TabIndex = 0;
            this.txtSerialNo.TabStop = false;
            // 
            // grdCargo
            // 
            this.grdCargo.AlternatingColors = true;
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargo.Hierarchical = true;
            this.grdCargo.Location = new System.Drawing.Point(299, 0);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(359, 347);
            this.grdCargo.TabIndex = 15;
            this.grdCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // frmCargoActionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 347);
            this.Controls.Add(this.grdCargo);
            this.Controls.Add(this.ultraExpandableGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCargoActionDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargo Actions and Detail ...";
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private CommonWinCtrls.ucGridEx grdCargo;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private CommonWinCtrls.ucTextBox txtVessel;
        private CommonWinCtrls.ucTextBox txtCustomerRef;
        private CommonWinCtrls.ucTextBox txtBookingNo;
        private CommonWinCtrls.ucTextBox txtDeliveryDt;
        private CommonWinCtrls.ucTextBox txtInGateDt;
        private CommonWinCtrls.ucTextBox txtDecommissionDt;
        private CommonWinCtrls.ucTextBox txtCommissionDt;
        private CommonWinCtrls.ucTextBox txtTagNo;
        private CommonWinCtrls.ucTextBox txtCustomsClearanceDt;
        private CommonWinCtrls.ucTextBox txtSerialNo;


    }
}