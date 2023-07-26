namespace CS2010.ArcSys.Win
{
    partial class frmViewBookingLINE
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
            Janus.Windows.GridEX.GridEXLayout grdDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBookingLINE));
            this.pnlTop = new CS2010.CommonWinCtrls.ucPanel();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.txtLINECustREf = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtLINEEDIRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtLINEStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtLineBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.lblNotFound = new CS2010.CommonWinCtrls.ucLabel();
            this.txtCustomerRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCustomerNm = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtMoveType = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtEdIREF = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPODBerth = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtTariff = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingRef = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOLBerth = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSailDt = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtRDD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtDate = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVesselNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.lblDeleted = new CS2010.CommonWinCtrls.ucLabel();
            this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnOceanView = new CS2010.CommonWinCtrls.ucButton();
            this.pnlTop.SuspendLayout();
            this.ucGroupBox1.SuspendLayout();
            this.ucGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.ucGroupBox1);
            this.pnlTop.Controls.Add(this.ucGroupBox2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(980, 200);
            this.pnlTop.TabIndex = 0;
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.btnOceanView);
            this.ucGroupBox1.Controls.Add(this.txtLINECustREf);
            this.ucGroupBox1.Controls.Add(this.txtLINEEDIRef);
            this.ucGroupBox1.Controls.Add(this.txtLINEStatus);
            this.ucGroupBox1.Controls.Add(this.txtLineBookingNo);
            this.ucGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupBox1.Location = new System.Drawing.Point(641, 6);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(327, 151);
            this.ucGroupBox1.TabIndex = 13;
            this.ucGroupBox1.TabStop = false;
            this.ucGroupBox1.Text = "OCEAN Database";
            // 
            // txtLINECustREf
            // 
            this.txtLINECustREf.BackColor = System.Drawing.SystemColors.Control;
            this.txtLINECustREf.ForeColor = System.Drawing.Color.Black;
            this.txtLINECustREf.LabelText = "Customer";
            this.txtLINECustREf.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLINECustREf.LinkDisabledMessage = "Link Disabled";
            this.txtLINECustREf.Location = new System.Drawing.Point(78, 39);
            this.txtLINECustREf.Name = "txtLINECustREf";
            this.txtLINECustREf.ReadOnly = true;
            this.txtLINECustREf.Size = new System.Drawing.Size(228, 20);
            this.txtLINECustREf.TabIndex = 15;
            this.txtLINECustREf.TabStop = false;
            // 
            // txtLINEEDIRef
            // 
            this.txtLINEEDIRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtLINEEDIRef.ForeColor = System.Drawing.Color.Black;
            this.txtLINEEDIRef.LabelText = "EDI Ref";
            this.txtLINEEDIRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLINEEDIRef.LinkDisabledMessage = "Link Disabled";
            this.txtLINEEDIRef.Location = new System.Drawing.Point(78, 62);
            this.txtLINEEDIRef.Name = "txtLINEEDIRef";
            this.txtLINEEDIRef.ReadOnly = true;
            this.txtLINEEDIRef.Size = new System.Drawing.Size(78, 20);
            this.txtLINEEDIRef.TabIndex = 14;
            this.txtLINEEDIRef.TabStop = false;
            // 
            // txtLINEStatus
            // 
            this.txtLINEStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtLINEStatus.ForeColor = System.Drawing.Color.Black;
            this.txtLINEStatus.LabelText = "Status";
            this.txtLINEStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLINEStatus.LinkDisabledMessage = "Link Disabled";
            this.txtLINEStatus.Location = new System.Drawing.Point(78, 85);
            this.txtLINEStatus.Name = "txtLINEStatus";
            this.txtLINEStatus.ReadOnly = true;
            this.txtLINEStatus.Size = new System.Drawing.Size(46, 20);
            this.txtLINEStatus.TabIndex = 13;
            this.txtLINEStatus.TabStop = false;
            // 
            // txtLineBookingNo
            // 
            this.txtLineBookingNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtLineBookingNo.ForeColor = System.Drawing.Color.Black;
            this.txtLineBookingNo.LabelText = "Booking#";
            this.txtLineBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLineBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtLineBookingNo.Location = new System.Drawing.Point(78, 16);
            this.txtLineBookingNo.Name = "txtLineBookingNo";
            this.txtLineBookingNo.ReadOnly = true;
            this.txtLineBookingNo.Size = new System.Drawing.Size(78, 20);
            this.txtLineBookingNo.TabIndex = 12;
            this.txtLineBookingNo.TabStop = false;
            // 
            // ucGroupBox2
            // 
            this.ucGroupBox2.Controls.Add(this.lblNotFound);
            this.ucGroupBox2.Controls.Add(this.txtCustomerRef);
            this.ucGroupBox2.Controls.Add(this.txtCustomerNm);
            this.ucGroupBox2.Controls.Add(this.txtMoveType);
            this.ucGroupBox2.Controls.Add(this.txtEdIREF);
            this.ucGroupBox2.Controls.Add(this.txtPODBerth);
            this.ucGroupBox2.Controls.Add(this.txtTariff);
            this.ucGroupBox2.Controls.Add(this.txtBookingRef);
            this.ucGroupBox2.Controls.Add(this.txtBookingStatus);
            this.ucGroupBox2.Controls.Add(this.txtPOLBerth);
            this.ucGroupBox2.Controls.Add(this.txtSailDt);
            this.ucGroupBox2.Controls.Add(this.txtVoyageNo);
            this.ucGroupBox2.Controls.Add(this.txtRDD);
            this.ucGroupBox2.Controls.Add(this.txtDate);
            this.ucGroupBox2.Controls.Add(this.txtVesselNo);
            this.ucGroupBox2.Controls.Add(this.txtPLOR);
            this.ucGroupBox2.Controls.Add(this.txtPOL);
            this.ucGroupBox2.Controls.Add(this.txtPOD);
            this.ucGroupBox2.Controls.Add(this.txtPLOD);
            this.ucGroupBox2.Controls.Add(this.lblDeleted);
            this.ucGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupBox2.Location = new System.Drawing.Point(7, 6);
            this.ucGroupBox2.Name = "ucGroupBox2";
            this.ucGroupBox2.Size = new System.Drawing.Size(628, 187);
            this.ucGroupBox2.TabIndex = 20;
            this.ucGroupBox2.TabStop = false;
            this.ucGroupBox2.Text = "Data Warehouse (this data could be up to 30 minutes old)";
            // 
            // lblNotFound
            // 
            this.lblNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotFound.ForeColor = System.Drawing.Color.Red;
            this.lblNotFound.Location = new System.Drawing.Point(346, 10);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(265, 13);
            this.lblNotFound.TabIndex = 19;
            this.lblNotFound.Text = "* This booking# not found in the warehouse *";
            this.lblNotFound.Visible = false;
            // 
            // txtCustomerRef
            // 
            this.txtCustomerRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerRef.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerRef.LabelText = "Customer Ref";
            this.txtCustomerRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomerRef.LinkDisabledMessage = "Link Disabled";
            this.txtCustomerRef.Location = new System.Drawing.Point(349, 131);
            this.txtCustomerRef.Name = "txtCustomerRef";
            this.txtCustomerRef.ReadOnly = true;
            this.txtCustomerRef.Size = new System.Drawing.Size(137, 20);
            this.txtCustomerRef.TabIndex = 11;
            this.txtCustomerRef.TabStop = false;
            // 
            // txtCustomerNm
            // 
            this.txtCustomerNm.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerNm.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerNm.LabelText = "Customer";
            this.txtCustomerNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomerNm.LinkDisabledMessage = "Link Disabled";
            this.txtCustomerNm.Location = new System.Drawing.Point(349, 153);
            this.txtCustomerNm.Name = "txtCustomerNm";
            this.txtCustomerNm.ReadOnly = true;
            this.txtCustomerNm.Size = new System.Drawing.Size(137, 20);
            this.txtCustomerNm.TabIndex = 16;
            this.txtCustomerNm.TabStop = false;
            // 
            // txtMoveType
            // 
            this.txtMoveType.BackColor = System.Drawing.SystemColors.Control;
            this.txtMoveType.ForeColor = System.Drawing.Color.Black;
            this.txtMoveType.LabelText = "Move Type";
            this.txtMoveType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtMoveType.LinkDisabledMessage = "Link Disabled";
            this.txtMoveType.Location = new System.Drawing.Point(554, 48);
            this.txtMoveType.Name = "txtMoveType";
            this.txtMoveType.ReadOnly = true;
            this.txtMoveType.Size = new System.Drawing.Size(45, 20);
            this.txtMoveType.TabIndex = 18;
            this.txtMoveType.TabStop = false;
            // 
            // txtEdIREF
            // 
            this.txtEdIREF.BackColor = System.Drawing.SystemColors.Control;
            this.txtEdIREF.ForeColor = System.Drawing.Color.Black;
            this.txtEdIREF.LabelText = "EDI Ref";
            this.txtEdIREF.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtEdIREF.LinkDisabledMessage = "Link Disabled";
            this.txtEdIREF.Location = new System.Drawing.Point(349, 110);
            this.txtEdIREF.Name = "txtEdIREF";
            this.txtEdIREF.ReadOnly = true;
            this.txtEdIREF.Size = new System.Drawing.Size(137, 20);
            this.txtEdIREF.TabIndex = 10;
            this.txtEdIREF.TabStop = false;
            // 
            // txtPODBerth
            // 
            this.txtPODBerth.BackColor = System.Drawing.SystemColors.Control;
            this.txtPODBerth.ForeColor = System.Drawing.Color.Black;
            this.txtPODBerth.LabelText = "Berth";
            this.txtPODBerth.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPODBerth.LinkDisabledMessage = "Link Disabled";
            this.txtPODBerth.Location = new System.Drawing.Point(66, 133);
            this.txtPODBerth.Name = "txtPODBerth";
            this.txtPODBerth.ReadOnly = true;
            this.txtPODBerth.Size = new System.Drawing.Size(189, 20);
            this.txtPODBerth.TabIndex = 18;
            this.txtPODBerth.TabStop = false;
            // 
            // txtTariff
            // 
            this.txtTariff.BackColor = System.Drawing.SystemColors.Control;
            this.txtTariff.ForeColor = System.Drawing.Color.Black;
            this.txtTariff.LabelText = "Tariff";
            this.txtTariff.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTariff.LinkDisabledMessage = "Link Disabled";
            this.txtTariff.Location = new System.Drawing.Point(554, 27);
            this.txtTariff.Name = "txtTariff";
            this.txtTariff.ReadOnly = true;
            this.txtTariff.Size = new System.Drawing.Size(45, 20);
            this.txtTariff.TabIndex = 17;
            this.txtTariff.TabStop = false;
            // 
            // txtBookingRef
            // 
            this.txtBookingRef.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookingRef.ForeColor = System.Drawing.Color.Black;
            this.txtBookingRef.LabelText = "Booking Ref";
            this.txtBookingRef.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingRef.LinkDisabledMessage = "Link Disabled";
            this.txtBookingRef.Location = new System.Drawing.Point(349, 89);
            this.txtBookingRef.Name = "txtBookingRef";
            this.txtBookingRef.ReadOnly = true;
            this.txtBookingRef.Size = new System.Drawing.Size(137, 20);
            this.txtBookingRef.TabIndex = 9;
            this.txtBookingRef.TabStop = false;
            // 
            // txtBookingStatus
            // 
            this.txtBookingStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookingStatus.ForeColor = System.Drawing.Color.Black;
            this.txtBookingStatus.LabelText = "Status";
            this.txtBookingStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingStatus.LinkDisabledMessage = "Link Disabled";
            this.txtBookingStatus.Location = new System.Drawing.Point(554, 69);
            this.txtBookingStatus.Name = "txtBookingStatus";
            this.txtBookingStatus.ReadOnly = true;
            this.txtBookingStatus.Size = new System.Drawing.Size(45, 20);
            this.txtBookingStatus.TabIndex = 15;
            this.txtBookingStatus.TabStop = false;
            // 
            // txtPOLBerth
            // 
            this.txtPOLBerth.BackColor = System.Drawing.SystemColors.Control;
            this.txtPOLBerth.ForeColor = System.Drawing.Color.Black;
            this.txtPOLBerth.LabelText = "Berth";
            this.txtPOLBerth.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOLBerth.LinkDisabledMessage = "Link Disabled";
            this.txtPOLBerth.Location = new System.Drawing.Point(66, 91);
            this.txtPOLBerth.Name = "txtPOLBerth";
            this.txtPOLBerth.ReadOnly = true;
            this.txtPOLBerth.Size = new System.Drawing.Size(189, 20);
            this.txtPOLBerth.TabIndex = 17;
            this.txtPOLBerth.TabStop = false;
            // 
            // txtSailDt
            // 
            this.txtSailDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtSailDt.ForeColor = System.Drawing.Color.Black;
            this.txtSailDt.LabelText = "Sail Date";
            this.txtSailDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSailDt.LinkDisabledMessage = "Link Disabled";
            this.txtSailDt.Location = new System.Drawing.Point(349, 68);
            this.txtSailDt.Name = "txtSailDt";
            this.txtSailDt.ReadOnly = true;
            this.txtSailDt.Size = new System.Drawing.Size(68, 20);
            this.txtSailDt.TabIndex = 8;
            this.txtSailDt.TabStop = false;
            // 
            // txtVoyageNo
            // 
            this.txtVoyageNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtVoyageNo.ForeColor = System.Drawing.Color.Black;
            this.txtVoyageNo.LabelText = "Voyage";
            this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
            this.txtVoyageNo.Location = new System.Drawing.Point(66, 28);
            this.txtVoyageNo.Name = "txtVoyageNo";
            this.txtVoyageNo.ReadOnly = true;
            this.txtVoyageNo.Size = new System.Drawing.Size(68, 20);
            this.txtVoyageNo.TabIndex = 1;
            this.txtVoyageNo.TabStop = false;
            // 
            // txtRDD
            // 
            this.txtRDD.BackColor = System.Drawing.SystemColors.Control;
            this.txtRDD.ForeColor = System.Drawing.Color.Black;
            this.txtRDD.LabelText = "RDD";
            this.txtRDD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtRDD.LinkDisabledMessage = "Link Disabled";
            this.txtRDD.Location = new System.Drawing.Point(349, 47);
            this.txtRDD.Name = "txtRDD";
            this.txtRDD.ReadOnly = true;
            this.txtRDD.Size = new System.Drawing.Size(68, 20);
            this.txtRDD.TabIndex = 7;
            this.txtRDD.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.LabelText = "Booking Date";
            this.txtDate.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDate.LinkDisabledMessage = "Link Disabled";
            this.txtDate.Location = new System.Drawing.Point(349, 26);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(68, 20);
            this.txtDate.TabIndex = 2;
            this.txtDate.TabStop = false;
            // 
            // txtVesselNo
            // 
            this.txtVesselNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtVesselNo.ForeColor = System.Drawing.Color.Black;
            this.txtVesselNo.LabelText = "Vessel";
            this.txtVesselNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVesselNo.LinkDisabledMessage = "Link Disabled";
            this.txtVesselNo.Location = new System.Drawing.Point(189, 28);
            this.txtVesselNo.Name = "txtVesselNo";
            this.txtVesselNo.ReadOnly = true;
            this.txtVesselNo.Size = new System.Drawing.Size(66, 20);
            this.txtVesselNo.TabIndex = 0;
            this.txtVesselNo.TabStop = false;
            // 
            // txtPLOR
            // 
            this.txtPLOR.BackColor = System.Drawing.SystemColors.Control;
            this.txtPLOR.ForeColor = System.Drawing.Color.Black;
            this.txtPLOR.LabelText = "PLOR";
            this.txtPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtPLOR.Location = new System.Drawing.Point(66, 49);
            this.txtPLOR.Name = "txtPLOR";
            this.txtPLOR.ReadOnly = true;
            this.txtPLOR.Size = new System.Drawing.Size(189, 20);
            this.txtPLOR.TabIndex = 3;
            this.txtPLOR.TabStop = false;
            // 
            // txtPOL
            // 
            this.txtPOL.BackColor = System.Drawing.SystemColors.Control;
            this.txtPOL.ForeColor = System.Drawing.Color.Black;
            this.txtPOL.LabelText = "POL";
            this.txtPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOL.LinkDisabledMessage = "Link Disabled";
            this.txtPOL.Location = new System.Drawing.Point(66, 70);
            this.txtPOL.Name = "txtPOL";
            this.txtPOL.ReadOnly = true;
            this.txtPOL.Size = new System.Drawing.Size(189, 20);
            this.txtPOL.TabIndex = 4;
            this.txtPOL.TabStop = false;
            // 
            // txtPOD
            // 
            this.txtPOD.BackColor = System.Drawing.SystemColors.Control;
            this.txtPOD.ForeColor = System.Drawing.Color.Black;
            this.txtPOD.LabelText = "POD";
            this.txtPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOD.LinkDisabledMessage = "Link Disabled";
            this.txtPOD.Location = new System.Drawing.Point(66, 112);
            this.txtPOD.Name = "txtPOD";
            this.txtPOD.ReadOnly = true;
            this.txtPOD.Size = new System.Drawing.Size(189, 20);
            this.txtPOD.TabIndex = 5;
            this.txtPOD.TabStop = false;
            // 
            // txtPLOD
            // 
            this.txtPLOD.BackColor = System.Drawing.SystemColors.Control;
            this.txtPLOD.ForeColor = System.Drawing.Color.Black;
            this.txtPLOD.LabelText = "PLOD";
            this.txtPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtPLOD.Location = new System.Drawing.Point(66, 154);
            this.txtPLOD.Name = "txtPLOD";
            this.txtPLOD.ReadOnly = true;
            this.txtPLOD.Size = new System.Drawing.Size(189, 20);
            this.txtPLOD.TabIndex = 6;
            this.txtPLOD.TabStop = false;
            // 
            // lblDeleted
            // 
            this.lblDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleted.ForeColor = System.Drawing.Color.Red;
            this.lblDeleted.Location = new System.Drawing.Point(66, 14);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(69, 13);
            this.lblDeleted.TabIndex = 14;
            this.lblDeleted.Text = "* Deleted *";
            this.lblDeleted.Visible = false;
            // 
            // grdDetail
            // 
            grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString");
            this.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.ExportFileID = null;
            this.grdDetail.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDetail.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDetail.Location = new System.Drawing.Point(0, 200);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdDetail.Size = new System.Drawing.Size(980, 301);
            this.grdDetail.TabIndex = 2;
            this.grdDetail.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDetail.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // btnOceanView
            // 
            this.btnOceanView.Location = new System.Drawing.Point(78, 106);
            this.btnOceanView.Name = "btnOceanView";
            this.btnOceanView.Size = new System.Drawing.Size(123, 23);
            this.btnOceanView.TabIndex = 16;
            this.btnOceanView.Text = "View OCEAN data";
            this.btnOceanView.UseVisualStyleBackColor = true;
            this.btnOceanView.Click += new System.EventHandler(this.btnOceanView_Click);
            // 
            // frmViewBookingLINE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 501);
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmViewBookingLINE";
            this.Text = "Booking";
            this.pnlTop.ResumeLayout(false);
            this.ucGroupBox1.ResumeLayout(false);
            this.ucGroupBox1.PerformLayout();
            this.ucGroupBox2.ResumeLayout(false);
            this.ucGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private CommonWinCtrls.ucPanel pnlTop;
		private CommonWinCtrls.ucTextBox txtVoyageNo;
		private CommonWinCtrls.ucTextBox txtVesselNo;
		private CommonWinCtrls.ucTextBox txtPLOR;
		private CommonWinCtrls.ucTextBox txtDate;
		private CommonWinCtrls.ucTextBox txtSailDt;
		private CommonWinCtrls.ucTextBox txtRDD;
		private CommonWinCtrls.ucTextBox txtPLOD;
		private CommonWinCtrls.ucTextBox txtPOD;
		private CommonWinCtrls.ucTextBox txtPOL;
		private CommonWinCtrls.ucTextBox txtCustomerRef;
		private CommonWinCtrls.ucTextBox txtEdIREF;
		private CommonWinCtrls.ucTextBox txtBookingRef;
		private CommonWinCtrls.ucGridEx grdDetail;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucTextBox txtLineBookingNo;
		private CommonWinCtrls.ucLabel lblDeleted;
		private CommonWinCtrls.ucTextBox txtCustomerNm;
		private CommonWinCtrls.ucTextBox txtBookingStatus;
		private CommonWinCtrls.ucTextBox txtMoveType;
        private CommonWinCtrls.ucTextBox txtTariff;
		private CommonWinCtrls.ucTextBox txtLINEStatus;
		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucTextBox txtPODBerth;
		private CommonWinCtrls.ucTextBox txtPOLBerth;
		private CommonWinCtrls.ucTextBox txtLINECustREf;
		private CommonWinCtrls.ucTextBox txtLINEEDIRef;
		private CommonWinCtrls.ucLabel lblNotFound;
        private CommonWinCtrls.ucButton btnOceanView;


	}
}