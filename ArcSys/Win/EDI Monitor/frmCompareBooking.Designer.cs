namespace CS2010.ArcSys.Win
{
    partial class frmCompareBooking
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
            this.grpOcean = new System.Windows.Forms.GroupBox();
            this.txtBolNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCargoStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtOSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpWarehouse = new System.Windows.Forms.GroupBox();
            this.txtWHBolNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHNotes = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHCargoStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtWHPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpILMS = new System.Windows.Forms.GroupBox();
            this.txtILMSCargoStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtILMSPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtASCargoStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtASerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtAPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtAPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtAVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtAPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtAPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtASTatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpOcean.SuspendLayout();
            this.grpWarehouse.SuspendLayout();
            this.grpILMS.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOcean
            // 
            this.grpOcean.Controls.Add(this.txtBolNo);
            this.grpOcean.Controls.Add(this.txtCargoStatus);
            this.grpOcean.Controls.Add(this.txtOSerialNo);
            this.grpOcean.Controls.Add(this.txtBookingStatus);
            this.grpOcean.Controls.Add(this.txtPLOD);
            this.grpOcean.Controls.Add(this.txtPLOR);
            this.grpOcean.Controls.Add(this.txtVoyage);
            this.grpOcean.Controls.Add(this.txtPOD);
            this.grpOcean.Controls.Add(this.txtPOL);
            this.grpOcean.Location = new System.Drawing.Point(13, 84);
            this.grpOcean.Name = "grpOcean";
            this.grpOcean.Size = new System.Drawing.Size(201, 293);
            this.grpOcean.TabIndex = 0;
            this.grpOcean.TabStop = false;
            this.grpOcean.Text = "OCEAN";
            // 
            // txtBolNo
            // 
            this.txtBolNo.LabelText = "BOL";
            this.txtBolNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBolNo.LinkDisabledMessage = "Link Disabled";
            this.txtBolNo.Location = new System.Drawing.Point(60, 237);
            this.txtBolNo.Name = "txtBolNo";
            this.txtBolNo.Size = new System.Drawing.Size(129, 20);
            this.txtBolNo.TabIndex = 13;
            // 
            // txtCargoStatus
            // 
            this.txtCargoStatus.LabelText = "Status";
            this.txtCargoStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCargoStatus.LinkDisabledMessage = "Link Disabled";
            this.txtCargoStatus.Location = new System.Drawing.Point(60, 213);
            this.txtCargoStatus.Name = "txtCargoStatus";
            this.txtCargoStatus.Size = new System.Drawing.Size(61, 20);
            this.txtCargoStatus.TabIndex = 10;
            // 
            // txtOSerialNo
            // 
            this.txtOSerialNo.LabelText = "Serial#";
            this.txtOSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtOSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtOSerialNo.Location = new System.Drawing.Point(60, 190);
            this.txtOSerialNo.Name = "txtOSerialNo";
            this.txtOSerialNo.Size = new System.Drawing.Size(129, 20);
            this.txtOSerialNo.TabIndex = 9;
            // 
            // txtBookingStatus
            // 
            this.txtBookingStatus.LabelText = "Status";
            this.txtBookingStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingStatus.LinkDisabledMessage = "Link Disabled";
            this.txtBookingStatus.Location = new System.Drawing.Point(59, 128);
            this.txtBookingStatus.Name = "txtBookingStatus";
            this.txtBookingStatus.Size = new System.Drawing.Size(100, 20);
            this.txtBookingStatus.TabIndex = 8;
            // 
            // txtPLOD
            // 
            this.txtPLOD.LabelText = "PLOD";
            this.txtPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtPLOD.Location = new System.Drawing.Point(60, 105);
            this.txtPLOD.Name = "txtPLOD";
            this.txtPLOD.Size = new System.Drawing.Size(100, 20);
            this.txtPLOD.TabIndex = 7;
            // 
            // txtPLOR
            // 
            this.txtPLOR.LabelText = "PLOR";
            this.txtPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtPLOR.Location = new System.Drawing.Point(58, 36);
            this.txtPLOR.Name = "txtPLOR";
            this.txtPLOR.Size = new System.Drawing.Size(100, 20);
            this.txtPLOR.TabIndex = 5;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(58, 14);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 6;
            // 
            // txtPOD
            // 
            this.txtPOD.LabelText = "POD";
            this.txtPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOD.LinkDisabledMessage = "Link Disabled";
            this.txtPOD.Location = new System.Drawing.Point(59, 82);
            this.txtPOD.Name = "txtPOD";
            this.txtPOD.Size = new System.Drawing.Size(100, 20);
            this.txtPOD.TabIndex = 5;
            // 
            // txtPOL
            // 
            this.txtPOL.LabelText = "POL";
            this.txtPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOL.LinkDisabledMessage = "Link Disabled";
            this.txtPOL.Location = new System.Drawing.Point(58, 59);
            this.txtPOL.Name = "txtPOL";
            this.txtPOL.Size = new System.Drawing.Size(100, 20);
            this.txtPOL.TabIndex = 1;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtSerialNo.ForeColor = System.Drawing.Color.Black;
            this.txtSerialNo.LabelText = "Serial No";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(73, 38);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(100, 20);
            this.txtSerialNo.TabIndex = 2;
            this.txtSerialNo.TabStop = false;
            // 
            // txtBooking
            // 
            this.txtBooking.BackColor = System.Drawing.SystemColors.Control;
            this.txtBooking.ForeColor = System.Drawing.Color.Black;
            this.txtBooking.LabelText = "Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(73, 12);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.ReadOnly = true;
            this.txtBooking.Size = new System.Drawing.Size(100, 20);
            this.txtBooking.TabIndex = 0;
            this.txtBooking.TabStop = false;
            // 
            // grpWarehouse
            // 
            this.grpWarehouse.Controls.Add(this.txtWHBolNo);
            this.grpWarehouse.Controls.Add(this.txtWHNotes);
            this.grpWarehouse.Controls.Add(this.txtWHCargoStatus);
            this.grpWarehouse.Controls.Add(this.txtWHSerialNo);
            this.grpWarehouse.Controls.Add(this.txtWHStatus);
            this.grpWarehouse.Controls.Add(this.txtWHPLOD);
            this.grpWarehouse.Controls.Add(this.txtWHPLOR);
            this.grpWarehouse.Controls.Add(this.txtWHVoyage);
            this.grpWarehouse.Controls.Add(this.txtWHPOD);
            this.grpWarehouse.Controls.Add(this.txtWHPOL);
            this.grpWarehouse.Location = new System.Drawing.Point(221, 84);
            this.grpWarehouse.Name = "grpWarehouse";
            this.grpWarehouse.Size = new System.Drawing.Size(221, 293);
            this.grpWarehouse.TabIndex = 3;
            this.grpWarehouse.TabStop = false;
            this.grpWarehouse.Text = "Data Warehouse";
            // 
            // txtWHBolNo
            // 
            this.txtWHBolNo.LabelText = "BOL";
            this.txtWHBolNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHBolNo.LinkDisabledMessage = "Link Disabled";
            this.txtWHBolNo.Location = new System.Drawing.Point(44, 236);
            this.txtWHBolNo.Name = "txtWHBolNo";
            this.txtWHBolNo.Size = new System.Drawing.Size(129, 20);
            this.txtWHBolNo.TabIndex = 12;
            // 
            // txtWHNotes
            // 
            this.txtWHNotes.LabelText = "Notes";
            this.txtWHNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHNotes.LinkDisabledMessage = "Link Disabled";
            this.txtWHNotes.Location = new System.Drawing.Point(44, 267);
            this.txtWHNotes.Name = "txtWHNotes";
            this.txtWHNotes.Size = new System.Drawing.Size(171, 20);
            this.txtWHNotes.TabIndex = 13;
            // 
            // txtWHCargoStatus
            // 
            this.txtWHCargoStatus.LabelText = "Status";
            this.txtWHCargoStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHCargoStatus.LinkDisabledMessage = "Link Disabled";
            this.txtWHCargoStatus.Location = new System.Drawing.Point(44, 213);
            this.txtWHCargoStatus.Name = "txtWHCargoStatus";
            this.txtWHCargoStatus.Size = new System.Drawing.Size(61, 20);
            this.txtWHCargoStatus.TabIndex = 12;
            // 
            // txtWHSerialNo
            // 
            this.txtWHSerialNo.LabelText = "Serial#";
            this.txtWHSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtWHSerialNo.Location = new System.Drawing.Point(44, 190);
            this.txtWHSerialNo.Name = "txtWHSerialNo";
            this.txtWHSerialNo.Size = new System.Drawing.Size(129, 20);
            this.txtWHSerialNo.TabIndex = 11;
            // 
            // txtWHStatus
            // 
            this.txtWHStatus.LabelText = "Status";
            this.txtWHStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHStatus.LinkDisabledMessage = "Link Disabled";
            this.txtWHStatus.Location = new System.Drawing.Point(56, 128);
            this.txtWHStatus.Name = "txtWHStatus";
            this.txtWHStatus.Size = new System.Drawing.Size(100, 20);
            this.txtWHStatus.TabIndex = 10;
            // 
            // txtWHPLOD
            // 
            this.txtWHPLOD.LabelText = "PLOD";
            this.txtWHPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtWHPLOD.Location = new System.Drawing.Point(55, 105);
            this.txtWHPLOD.Name = "txtWHPLOD";
            this.txtWHPLOD.Size = new System.Drawing.Size(100, 20);
            this.txtWHPLOD.TabIndex = 9;
            // 
            // txtWHPLOR
            // 
            this.txtWHPLOR.LabelText = "PLOR";
            this.txtWHPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtWHPLOR.Location = new System.Drawing.Point(55, 36);
            this.txtWHPLOR.Name = "txtWHPLOR";
            this.txtWHPLOR.Size = new System.Drawing.Size(100, 20);
            this.txtWHPLOR.TabIndex = 8;
            // 
            // txtWHVoyage
            // 
            this.txtWHVoyage.LabelText = "Voyage";
            this.txtWHVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtWHVoyage.Location = new System.Drawing.Point(55, 14);
            this.txtWHVoyage.Name = "txtWHVoyage";
            this.txtWHVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtWHVoyage.TabIndex = 7;
            // 
            // txtWHPOD
            // 
            this.txtWHPOD.LabelText = "POD";
            this.txtWHPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHPOD.LinkDisabledMessage = "Link Disabled";
            this.txtWHPOD.Location = new System.Drawing.Point(55, 82);
            this.txtWHPOD.Name = "txtWHPOD";
            this.txtWHPOD.Size = new System.Drawing.Size(100, 20);
            this.txtWHPOD.TabIndex = 6;
            // 
            // txtWHPOL
            // 
            this.txtWHPOL.LabelText = "POL";
            this.txtWHPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtWHPOL.LinkDisabledMessage = "Link Disabled";
            this.txtWHPOL.Location = new System.Drawing.Point(55, 59);
            this.txtWHPOL.Name = "txtWHPOL";
            this.txtWHPOL.Size = new System.Drawing.Size(100, 20);
            this.txtWHPOL.TabIndex = 4;
            // 
            // grpILMS
            // 
            this.grpILMS.Controls.Add(this.txtILMSCargoStatus);
            this.grpILMS.Controls.Add(this.txtILMSSerialNo);
            this.grpILMS.Controls.Add(this.txtILMSPLOD);
            this.grpILMS.Controls.Add(this.txtILMSPLOR);
            this.grpILMS.Controls.Add(this.txtILMSVoyage);
            this.grpILMS.Controls.Add(this.txtILMSPOD);
            this.grpILMS.Controls.Add(this.txtILMSPOL);
            this.grpILMS.Location = new System.Drawing.Point(450, 84);
            this.grpILMS.Name = "grpILMS";
            this.grpILMS.Size = new System.Drawing.Size(201, 293);
            this.grpILMS.TabIndex = 4;
            this.grpILMS.TabStop = false;
            this.grpILMS.Text = "Intermodal Data";
            // 
            // txtILMSCargoStatus
            // 
            this.txtILMSCargoStatus.LabelText = "Status";
            this.txtILMSCargoStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSCargoStatus.LinkDisabledMessage = "Link Disabled";
            this.txtILMSCargoStatus.Location = new System.Drawing.Point(60, 213);
            this.txtILMSCargoStatus.Name = "txtILMSCargoStatus";
            this.txtILMSCargoStatus.Size = new System.Drawing.Size(61, 20);
            this.txtILMSCargoStatus.TabIndex = 13;
            // 
            // txtILMSSerialNo
            // 
            this.txtILMSSerialNo.LabelText = "Serial#";
            this.txtILMSSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtILMSSerialNo.Location = new System.Drawing.Point(59, 190);
            this.txtILMSSerialNo.Name = "txtILMSSerialNo";
            this.txtILMSSerialNo.Size = new System.Drawing.Size(129, 20);
            this.txtILMSSerialNo.TabIndex = 11;
            // 
            // txtILMSPLOD
            // 
            this.txtILMSPLOD.LabelText = "PLOD";
            this.txtILMSPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtILMSPLOD.Location = new System.Drawing.Point(60, 105);
            this.txtILMSPLOD.Name = "txtILMSPLOD";
            this.txtILMSPLOD.Size = new System.Drawing.Size(100, 20);
            this.txtILMSPLOD.TabIndex = 10;
            // 
            // txtILMSPLOR
            // 
            this.txtILMSPLOR.LabelText = "PLOR";
            this.txtILMSPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtILMSPLOR.Location = new System.Drawing.Point(59, 36);
            this.txtILMSPLOR.Name = "txtILMSPLOR";
            this.txtILMSPLOR.Size = new System.Drawing.Size(100, 20);
            this.txtILMSPLOR.TabIndex = 9;
            // 
            // txtILMSVoyage
            // 
            this.txtILMSVoyage.LabelText = "Voyage";
            this.txtILMSVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtILMSVoyage.Location = new System.Drawing.Point(59, 14);
            this.txtILMSVoyage.Name = "txtILMSVoyage";
            this.txtILMSVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtILMSVoyage.TabIndex = 7;
            // 
            // txtILMSPOD
            // 
            this.txtILMSPOD.LabelText = "POD";
            this.txtILMSPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSPOD.LinkDisabledMessage = "Link Disabled";
            this.txtILMSPOD.Location = new System.Drawing.Point(59, 82);
            this.txtILMSPOD.Name = "txtILMSPOD";
            this.txtILMSPOD.Size = new System.Drawing.Size(100, 20);
            this.txtILMSPOD.TabIndex = 6;
            // 
            // txtILMSPOL
            // 
            this.txtILMSPOL.LabelText = "POL";
            this.txtILMSPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtILMSPOL.LinkDisabledMessage = "Link Disabled";
            this.txtILMSPOL.Location = new System.Drawing.Point(59, 59);
            this.txtILMSPOL.Name = "txtILMSPOL";
            this.txtILMSPOL.Size = new System.Drawing.Size(100, 20);
            this.txtILMSPOL.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtASTatus);
            this.groupBox1.Controls.Add(this.txtASCargoStatus);
            this.groupBox1.Controls.Add(this.txtASerialNo);
            this.groupBox1.Controls.Add(this.txtAPLOD);
            this.groupBox1.Controls.Add(this.txtAPLOR);
            this.groupBox1.Controls.Add(this.txtAVoyage);
            this.groupBox1.Controls.Add(this.txtAPOD);
            this.groupBox1.Controls.Add(this.txtAPOL);
            this.groupBox1.Location = new System.Drawing.Point(659, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 293);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACMS Data";
            // 
            // txtASCargoStatus
            // 
            this.txtASCargoStatus.LabelText = "Status";
            this.txtASCargoStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtASCargoStatus.LinkDisabledMessage = "Link Disabled";
            this.txtASCargoStatus.Location = new System.Drawing.Point(60, 213);
            this.txtASCargoStatus.Name = "txtASCargoStatus";
            this.txtASCargoStatus.Size = new System.Drawing.Size(61, 20);
            this.txtASCargoStatus.TabIndex = 13;
            // 
            // txtASerialNo
            // 
            this.txtASerialNo.LabelText = "Serial#";
            this.txtASerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtASerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtASerialNo.Location = new System.Drawing.Point(59, 190);
            this.txtASerialNo.Name = "txtASerialNo";
            this.txtASerialNo.Size = new System.Drawing.Size(129, 20);
            this.txtASerialNo.TabIndex = 11;
            // 
            // txtAPLOD
            // 
            this.txtAPLOD.LabelText = "PLOD";
            this.txtAPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtAPLOD.Location = new System.Drawing.Point(60, 105);
            this.txtAPLOD.Name = "txtAPLOD";
            this.txtAPLOD.Size = new System.Drawing.Size(100, 20);
            this.txtAPLOD.TabIndex = 10;
            // 
            // txtAPLOR
            // 
            this.txtAPLOR.LabelText = "PLOR";
            this.txtAPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtAPLOR.Location = new System.Drawing.Point(59, 36);
            this.txtAPLOR.Name = "txtAPLOR";
            this.txtAPLOR.Size = new System.Drawing.Size(100, 20);
            this.txtAPLOR.TabIndex = 9;
            // 
            // txtAVoyage
            // 
            this.txtAVoyage.LabelText = "Voyage";
            this.txtAVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtAVoyage.Location = new System.Drawing.Point(59, 14);
            this.txtAVoyage.Name = "txtAVoyage";
            this.txtAVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtAVoyage.TabIndex = 7;
            this.txtAVoyage.TextChanged += new System.EventHandler(this.ucTextBox5_TextChanged);
            // 
            // txtAPOD
            // 
            this.txtAPOD.LabelText = "POD";
            this.txtAPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAPOD.LinkDisabledMessage = "Link Disabled";
            this.txtAPOD.Location = new System.Drawing.Point(59, 82);
            this.txtAPOD.Name = "txtAPOD";
            this.txtAPOD.Size = new System.Drawing.Size(100, 20);
            this.txtAPOD.TabIndex = 6;
            // 
            // txtAPOL
            // 
            this.txtAPOL.LabelText = "POL";
            this.txtAPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAPOL.LinkDisabledMessage = "Link Disabled";
            this.txtAPOL.Location = new System.Drawing.Point(59, 59);
            this.txtAPOL.Name = "txtAPOL";
            this.txtAPOL.Size = new System.Drawing.Size(100, 20);
            this.txtAPOL.TabIndex = 4;
            // 
            // txtASTatus
            // 
            this.txtASTatus.LabelText = "Status";
            this.txtASTatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtASTatus.LinkDisabledMessage = "Link Disabled";
            this.txtASTatus.Location = new System.Drawing.Point(60, 129);
            this.txtASTatus.Name = "txtASTatus";
            this.txtASTatus.Size = new System.Drawing.Size(100, 20);
            this.txtASTatus.TabIndex = 14;
            // 
            // frmCompareBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpILMS);
            this.Controls.Add(this.grpWarehouse);
            this.Controls.Add(this.txtBooking);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.grpOcean);
            this.Name = "frmCompareBooking";
            this.Text = "frmCompareBooking";
            this.grpOcean.ResumeLayout(false);
            this.grpOcean.PerformLayout();
            this.grpWarehouse.ResumeLayout(false);
            this.grpWarehouse.PerformLayout();
            this.grpILMS.ResumeLayout(false);
            this.grpILMS.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOcean;
        private CommonWinCtrls.ucTextBox txtSerialNo;
        private CommonWinCtrls.ucTextBox txtPOL;
        private CommonWinCtrls.ucTextBox txtBooking;
        private System.Windows.Forms.GroupBox grpWarehouse;
        private CommonWinCtrls.ucTextBox txtWHPOL;
        private System.Windows.Forms.GroupBox grpILMS;
        private CommonWinCtrls.ucTextBox txtILMSPOL;
        private CommonWinCtrls.ucTextBox txtPOD;
        private CommonWinCtrls.ucTextBox txtWHPOD;
        private CommonWinCtrls.ucTextBox txtILMSPOD;
        private CommonWinCtrls.ucTextBox txtVoyage;
        private CommonWinCtrls.ucTextBox txtWHVoyage;
        private CommonWinCtrls.ucTextBox txtILMSVoyage;
        private CommonWinCtrls.ucTextBox txtBookingStatus;
        private CommonWinCtrls.ucTextBox txtPLOD;
        private CommonWinCtrls.ucTextBox txtPLOR;
        private CommonWinCtrls.ucTextBox txtWHStatus;
        private CommonWinCtrls.ucTextBox txtWHPLOD;
        private CommonWinCtrls.ucTextBox txtWHPLOR;
        private CommonWinCtrls.ucTextBox txtILMSPLOD;
        private CommonWinCtrls.ucTextBox txtILMSPLOR;
        private CommonWinCtrls.ucTextBox txtCargoStatus;
        private CommonWinCtrls.ucTextBox txtOSerialNo;
        private CommonWinCtrls.ucTextBox txtWHCargoStatus;
        private CommonWinCtrls.ucTextBox txtWHSerialNo;
        private CommonWinCtrls.ucTextBox txtILMSCargoStatus;
        private CommonWinCtrls.ucTextBox txtILMSSerialNo;
        private CommonWinCtrls.ucTextBox txtWHNotes;
        private CommonWinCtrls.ucTextBox txtWHBolNo;
        private CommonWinCtrls.ucTextBox txtBolNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonWinCtrls.ucTextBox txtASCargoStatus;
        private CommonWinCtrls.ucTextBox txtASerialNo;
        private CommonWinCtrls.ucTextBox txtAPLOD;
        private CommonWinCtrls.ucTextBox txtAPLOR;
        private CommonWinCtrls.ucTextBox txtAVoyage;
        private CommonWinCtrls.ucTextBox txtAPOD;
        private CommonWinCtrls.ucTextBox txtAPOL;
        private CommonWinCtrls.ucTextBox txtASTatus;

    }
}