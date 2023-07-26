namespace CS2010.ArcSys.Win
{
	partial class frmViewBookingRequest
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
            Janus.Windows.GridEX.GridEXLayout cmbTerms_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBookingRequest));
            Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPODTerminal_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPolTerminal_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbBookVoyage_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbBookPLOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbBookPLOR_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdLocks_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdParties_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTShipment_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdMappingErrors_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdRDDLog_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCorrespondence_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdOceanAPI_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdArcEDILog_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdITVList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.txtSystem = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtHazMatQlfr = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtHazMatClass = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtHaxMatContact = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyDoc = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbTerms = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.btnRequestCancel = new CS2010.CommonWinCtrls.ucButton();
            this.btnEditRequest = new CS2010.CommonWinCtrls.ucButton();
            this.btnRequestSave = new CS2010.CommonWinCtrls.ucButton();
            this.txtReqPhone = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqHazDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqBookerName = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbStatus = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtReqHazMatCd = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqDt = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtReqVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqAvailable = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtReqPOE = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqRDD = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtReqPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtReqVesselDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpBookedInfo = new CS2010.CommonWinCtrls.ucGroupBox();
            this.btnSynchITV = new System.Windows.Forms.Button();
            this.txtNotes = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnBookCancel = new CS2010.CommonWinCtrls.ucButton();
            this.btnEditBooking = new CS2010.CommonWinCtrls.ucButton();
            this.btnSaveBooking = new CS2010.CommonWinCtrls.ucButton();
            this.cmbPODTerminal = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbPolTerminal = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtBookAdjRsn = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookAdjRdd = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtBookRdd = new CS2010.CommonWinCtrls.ucDateTextBox();
            this.txtBookDlvyDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbBookVoyage = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbBookPLOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbBookPLOR = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.pnlBookingDetail = new CS2010.CommonWinCtrls.ucPanel();
            this.grdLocks = new CS2010.CommonWinCtrls.ucGridEx();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsCommands = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsAccept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRequestBooking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRequestCounter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReleaseWaitList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCommands = new CS2010.CommonWinCtrls.ucPanel();
            this.ucButton1 = new CS2010.CommonWinCtrls.ucButton();
            this.btnDecline = new CS2010.CommonWinCtrls.ucButton();
            this.btnAccept = new CS2010.CommonWinCtrls.ucButton();
            this.btnReleaseWait = new CS2010.CommonWinCtrls.ucButton();
            this.btnRequestCounter = new CS2010.CommonWinCtrls.ucButton();
            this.btnRequestBooking = new CS2010.CommonWinCtrls.ucButton();
            this.btnViewLine = new CS2010.CommonWinCtrls.ucButton();
            this.btnViewEDI = new CS2010.CommonWinCtrls.ucButton();
            this.btnITV = new CS2010.CommonWinCtrls.ucButton();
            this.lblProblems = new CS2010.CommonWinCtrls.ucLabel();
            this.btnDockReceipt = new CS2010.CommonWinCtrls.ucButton();
            this.btnRequestSheet = new CS2010.CommonWinCtrls.ucButton();
            this.grdParties = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.tabMain = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.grdTShipment = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpMapErrors = new System.Windows.Forms.TabPage();
            this.splitError = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnRelease = new CS2010.CommonWinCtrls.ucButton();
            this.txtReleaseNotes = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdMappingErrors = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpRDD = new System.Windows.Forms.TabPage();
            this.grdRDDLog = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
            this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
            this.tpCorrespondence = new System.Windows.Forms.TabPage();
            this.grdCorrespondence = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
            this.btnAddCorr = new CS2010.CommonWinCtrls.ucButton();
            this.tpAudit = new System.Windows.Forms.TabPage();
            this.grdAudit = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbEDILog = new System.Windows.Forms.TabPage();
            this.grdOceanAPI = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdArcEDILog = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpITV = new System.Windows.Forms.TabPage();
            this.grdITVList = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            this.grpBookedInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPODTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPolTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookVoyage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookPLOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookPLOR)).BeginInit();
            this.pnlBookingDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocks)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTShipment)).BeginInit();
            this.tpMapErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitError)).BeginInit();
            this.splitError.Panel1.SuspendLayout();
            this.splitError.Panel2.SuspendLayout();
            this.splitError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMappingErrors)).BeginInit();
            this.tpRDD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRDDLog)).BeginInit();
            this.ucPanel1.SuspendLayout();
            this.tpCorrespondence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCorrespondence)).BeginInit();
            this.ucPanel2.SuspendLayout();
            this.tpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            this.tbEDILog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanAPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArcEDILog)).BeginInit();
            this.tpITV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdITVList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGroupBox2
            // 
            this.ucGroupBox2.Controls.Add(this.txtSystem);
            this.ucGroupBox2.Controls.Add(this.txtHazMatQlfr);
            this.ucGroupBox2.Controls.Add(this.txtHazMatClass);
            this.ucGroupBox2.Controls.Add(this.txtHaxMatContact);
            this.ucGroupBox2.Controls.Add(this.txtVoyDoc);
            this.ucGroupBox2.Controls.Add(this.cmbTerms);
            this.ucGroupBox2.Controls.Add(this.btnRequestCancel);
            this.ucGroupBox2.Controls.Add(this.btnEditRequest);
            this.ucGroupBox2.Controls.Add(this.btnRequestSave);
            this.ucGroupBox2.Controls.Add(this.txtReqPhone);
            this.ucGroupBox2.Controls.Add(this.txtReqHazDsc);
            this.ucGroupBox2.Controls.Add(this.txtReqBookerName);
            this.ucGroupBox2.Controls.Add(this.txtBookingNo);
            this.ucGroupBox2.Controls.Add(this.cmbStatus);
            this.ucGroupBox2.Controls.Add(this.txtReqHazMatCd);
            this.ucGroupBox2.Controls.Add(this.txtReqPCFN);
            this.ucGroupBox2.Controls.Add(this.txtReqDt);
            this.ucGroupBox2.Controls.Add(this.txtReqVoyage);
            this.ucGroupBox2.Controls.Add(this.txtReqAvailable);
            this.ucGroupBox2.Controls.Add(this.txtReqPOE);
            this.ucGroupBox2.Controls.Add(this.txtReqRDD);
            this.ucGroupBox2.Controls.Add(this.txtReqPOD);
            this.ucGroupBox2.Controls.Add(this.txtReqVesselDsc);
            this.ucGroupBox2.Location = new System.Drawing.Point(5, 30);
            this.ucGroupBox2.Name = "ucGroupBox2";
            this.ucGroupBox2.Size = new System.Drawing.Size(463, 181);
            this.ucGroupBox2.TabIndex = 15;
            this.ucGroupBox2.TabStop = false;
            this.ucGroupBox2.Text = "Request Detail";
            // 
            // txtSystem
            // 
            this.txtSystem.BackColor = System.Drawing.SystemColors.Control;
            this.txtSystem.ForeColor = System.Drawing.Color.Black;
            this.txtSystem.LinkDisabledMessage = "Link Disabled";
            this.txtSystem.Location = new System.Drawing.Point(178, 127);
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.ReadOnly = true;
            this.txtSystem.Size = new System.Drawing.Size(49, 20);
            this.txtSystem.TabIndex = 33;
            this.txtSystem.TabStop = false;
            // 
            // txtHazMatQlfr
            // 
            this.txtHazMatQlfr.LabelText = "Contact/Cd/Qualifier";
            this.txtHazMatQlfr.LinkDisabledMessage = "Link Disabled";
            this.txtHazMatQlfr.Location = new System.Drawing.Point(443, 124);
            this.txtHazMatQlfr.Name = "txtHazMatQlfr";
            this.txtHazMatQlfr.Size = new System.Drawing.Size(13, 20);
            this.txtHazMatQlfr.TabIndex = 32;
            // 
            // txtHazMatClass
            // 
            this.txtHazMatClass.LabelText = "Contact/Cd/Qualifier";
            this.txtHazMatClass.LinkDisabledMessage = "Link Disabled";
            this.txtHazMatClass.Location = new System.Drawing.Point(427, 124);
            this.txtHazMatClass.Name = "txtHazMatClass";
            this.txtHazMatClass.Size = new System.Drawing.Size(13, 20);
            this.txtHazMatClass.TabIndex = 31;
            // 
            // txtHaxMatContact
            // 
            this.txtHaxMatContact.LabelText = "Contact/C.ass/Qlfr";
            this.txtHaxMatContact.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtHaxMatContact.LinkDisabledMessage = "Link Disabled";
            this.txtHaxMatContact.Location = new System.Drawing.Point(341, 124);
            this.txtHaxMatContact.Name = "txtHaxMatContact";
            this.txtHaxMatContact.Size = new System.Drawing.Size(85, 20);
            this.txtHaxMatContact.TabIndex = 30;
            // 
            // txtVoyDoc
            // 
            this.txtVoyDoc.BackColor = System.Drawing.SystemColors.Control;
            this.txtVoyDoc.ForeColor = System.Drawing.Color.Black;
            this.txtVoyDoc.LabelText = "VoyDoc";
            this.txtVoyDoc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyDoc.LinkDisabledMessage = "Link Disabled";
            this.txtVoyDoc.Location = new System.Drawing.Point(195, 15);
            this.txtVoyDoc.Name = "txtVoyDoc";
            this.txtVoyDoc.ReadOnly = true;
            this.txtVoyDoc.Size = new System.Drawing.Size(99, 20);
            this.txtVoyDoc.TabIndex = 29;
            this.txtVoyDoc.TabStop = false;
            // 
            // cmbTerms
            // 
            cmbTerms_DesignTimeLayout.LayoutString = resources.GetString("cmbTerms_DesignTimeLayout.LayoutString");
            this.cmbTerms.DesignTimeLayout = cmbTerms_DesignTimeLayout;
            this.cmbTerms.DisplayMember = "move_type_cd";
            this.cmbTerms.LabelText = "Terms";
            this.cmbTerms.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbTerms.Location = new System.Drawing.Point(195, 104);
            this.cmbTerms.Name = "cmbTerms";
            this.cmbTerms.SelectedIndex = -1;
            this.cmbTerms.SelectedItem = null;
            this.cmbTerms.Size = new System.Drawing.Size(99, 20);
            this.cmbTerms.TabIndex = 28;
            this.cmbTerms.ValueMember = "move_type_cd";
            // 
            // btnRequestCancel
            // 
            this.btnRequestCancel.Enabled = false;
            this.btnRequestCancel.Location = new System.Drawing.Point(390, 148);
            this.btnRequestCancel.Name = "btnRequestCancel";
            this.btnRequestCancel.Size = new System.Drawing.Size(68, 23);
            this.btnRequestCancel.TabIndex = 27;
            this.btnRequestCancel.Text = "Cancel";
            this.btnRequestCancel.UseVisualStyleBackColor = true;
            this.btnRequestCancel.Click += new System.EventHandler(this.btnRequestCancel_Click);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Location = new System.Drawing.Point(252, 148);
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(68, 23);
            this.btnEditRequest.TabIndex = 26;
            this.btnEditRequest.Text = "Edit";
            this.btnEditRequest.UseVisualStyleBackColor = true;
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // btnRequestSave
            // 
            this.btnRequestSave.Enabled = false;
            this.btnRequestSave.Location = new System.Drawing.Point(321, 148);
            this.btnRequestSave.Name = "btnRequestSave";
            this.btnRequestSave.Size = new System.Drawing.Size(68, 23);
            this.btnRequestSave.TabIndex = 25;
            this.btnRequestSave.Text = "Save";
            this.btnRequestSave.UseVisualStyleBackColor = true;
            this.btnRequestSave.Click += new System.EventHandler(this.btnRequestSave_Click);
            // 
            // txtReqPhone
            // 
            this.txtReqPhone.LabelText = "Phone";
            this.txtReqPhone.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqPhone.LinkDisabledMessage = "Link Disabled";
            this.txtReqPhone.Location = new System.Drawing.Point(341, 36);
            this.txtReqPhone.Name = "txtReqPhone";
            this.txtReqPhone.Size = new System.Drawing.Size(116, 20);
            this.txtReqPhone.TabIndex = 24;
            // 
            // txtReqHazDsc
            // 
            this.txtReqHazDsc.LabelText = "Descr";
            this.txtReqHazDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqHazDsc.LinkDisabledMessage = "Link Disabled";
            this.txtReqHazDsc.Location = new System.Drawing.Point(341, 80);
            this.txtReqHazDsc.Multiline = true;
            this.txtReqHazDsc.Name = "txtReqHazDsc";
            this.txtReqHazDsc.Size = new System.Drawing.Size(116, 42);
            this.txtReqHazDsc.TabIndex = 23;
            // 
            // txtReqBookerName
            // 
            this.txtReqBookerName.LabelText = "Booker";
            this.txtReqBookerName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqBookerName.LinkDisabledMessage = "Link Disabled";
            this.txtReqBookerName.Location = new System.Drawing.Point(341, 15);
            this.txtReqBookerName.Name = "txtReqBookerName";
            this.txtReqBookerName.Size = new System.Drawing.Size(116, 20);
            this.txtReqBookerName.TabIndex = 22;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(67, 127);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(96, 20);
            this.txtBookingNo.TabIndex = 0;
            // 
            // cmbStatus
            // 
            cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
            this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
            this.cmbStatus.DisplayMember = "acms_status_dsc";
            this.cmbStatus.LabelText = "Status";
            this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatus.Location = new System.Drawing.Point(67, 149);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.SelectedIndex = -1;
            this.cmbStatus.SelectedItem = null;
            this.cmbStatus.Size = new System.Drawing.Size(172, 20);
            this.cmbStatus.TabIndex = 21;
            this.cmbStatus.ValueMember = "acms_status_cd";
            // 
            // txtReqHazMatCd
            // 
            this.txtReqHazMatCd.LabelText = "Hazmat";
            this.txtReqHazMatCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqHazMatCd.LinkDisabledMessage = "Link Disabled";
            this.txtReqHazMatCd.Location = new System.Drawing.Point(341, 58);
            this.txtReqHazMatCd.Name = "txtReqHazMatCd";
            this.txtReqHazMatCd.Size = new System.Drawing.Size(116, 20);
            this.txtReqHazMatCd.TabIndex = 22;
            // 
            // txtReqPCFN
            // 
            this.txtReqPCFN.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqPCFN.ForeColor = System.Drawing.Color.Black;
            this.txtReqPCFN.LabelText = "PCFN";
            this.txtReqPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtReqPCFN.Location = new System.Drawing.Point(67, 15);
            this.txtReqPCFN.Name = "txtReqPCFN";
            this.txtReqPCFN.ReadOnly = true;
            this.txtReqPCFN.Size = new System.Drawing.Size(79, 20);
            this.txtReqPCFN.TabIndex = 1;
            this.txtReqPCFN.TabStop = false;
            // 
            // txtReqDt
            // 
            this.txtReqDt.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqDt.ForeColor = System.Drawing.Color.Black;
            this.txtReqDt.LabelText = "Requested";
            this.txtReqDt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqDt.LinkDisabledMessage = "Link Disabled";
            this.txtReqDt.Location = new System.Drawing.Point(67, 36);
            this.txtReqDt.MaxLength = 10;
            this.txtReqDt.Name = "txtReqDt";
            this.txtReqDt.ReadOnly = true;
            this.txtReqDt.Size = new System.Drawing.Size(79, 20);
            this.txtReqDt.TabIndex = 20;
            this.txtReqDt.TabStop = false;
            this.txtReqDt.Value = null;
            // 
            // txtReqVoyage
            // 
            this.txtReqVoyage.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqVoyage.ForeColor = System.Drawing.Color.Black;
            this.txtReqVoyage.LabelText = "Voyage";
            this.txtReqVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtReqVoyage.Location = new System.Drawing.Point(67, 58);
            this.txtReqVoyage.Name = "txtReqVoyage";
            this.txtReqVoyage.ReadOnly = true;
            this.txtReqVoyage.Size = new System.Drawing.Size(79, 20);
            this.txtReqVoyage.TabIndex = 15;
            this.txtReqVoyage.TabStop = false;
            // 
            // txtReqAvailable
            // 
            this.txtReqAvailable.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqAvailable.ForeColor = System.Drawing.Color.Black;
            this.txtReqAvailable.LabelText = "Cargo Avail";
            this.txtReqAvailable.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqAvailable.LinkDisabledMessage = "Link Disabled";
            this.txtReqAvailable.Location = new System.Drawing.Point(67, 104);
            this.txtReqAvailable.MaxLength = 10;
            this.txtReqAvailable.Name = "txtReqAvailable";
            this.txtReqAvailable.ReadOnly = true;
            this.txtReqAvailable.Size = new System.Drawing.Size(79, 20);
            this.txtReqAvailable.TabIndex = 19;
            this.txtReqAvailable.TabStop = false;
            this.txtReqAvailable.Value = null;
            // 
            // txtReqPOE
            // 
            this.txtReqPOE.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqPOE.ForeColor = System.Drawing.Color.Black;
            this.txtReqPOE.LabelText = "POE";
            this.txtReqPOE.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqPOE.LinkDisabledMessage = "Link Disabled";
            this.txtReqPOE.Location = new System.Drawing.Point(195, 36);
            this.txtReqPOE.Name = "txtReqPOE";
            this.txtReqPOE.ReadOnly = true;
            this.txtReqPOE.Size = new System.Drawing.Size(99, 20);
            this.txtReqPOE.TabIndex = 17;
            this.txtReqPOE.TabStop = false;
            // 
            // txtReqRDD
            // 
            this.txtReqRDD.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqRDD.ForeColor = System.Drawing.Color.Black;
            this.txtReqRDD.LabelText = "RDD";
            this.txtReqRDD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqRDD.LinkDisabledMessage = "Link Disabled";
            this.txtReqRDD.Location = new System.Drawing.Point(195, 81);
            this.txtReqRDD.MaxLength = 10;
            this.txtReqRDD.Name = "txtReqRDD";
            this.txtReqRDD.ReadOnly = true;
            this.txtReqRDD.Size = new System.Drawing.Size(99, 20);
            this.txtReqRDD.TabIndex = 18;
            this.txtReqRDD.TabStop = false;
            this.txtReqRDD.Value = null;
            // 
            // txtReqPOD
            // 
            this.txtReqPOD.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqPOD.ForeColor = System.Drawing.Color.Black;
            this.txtReqPOD.LabelText = "POD";
            this.txtReqPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqPOD.LinkDisabledMessage = "Link Disabled";
            this.txtReqPOD.Location = new System.Drawing.Point(195, 58);
            this.txtReqPOD.Name = "txtReqPOD";
            this.txtReqPOD.ReadOnly = true;
            this.txtReqPOD.Size = new System.Drawing.Size(99, 20);
            this.txtReqPOD.TabIndex = 16;
            this.txtReqPOD.TabStop = false;
            // 
            // txtReqVesselDsc
            // 
            this.txtReqVesselDsc.BackColor = System.Drawing.SystemColors.Control;
            this.txtReqVesselDsc.ForeColor = System.Drawing.Color.Black;
            this.txtReqVesselDsc.LabelText = "Vessel";
            this.txtReqVesselDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReqVesselDsc.LinkDisabledMessage = "Link Disabled";
            this.txtReqVesselDsc.Location = new System.Drawing.Point(67, 81);
            this.txtReqVesselDsc.Name = "txtReqVesselDsc";
            this.txtReqVesselDsc.ReadOnly = true;
            this.txtReqVesselDsc.Size = new System.Drawing.Size(79, 20);
            this.txtReqVesselDsc.TabIndex = 15;
            this.txtReqVesselDsc.TabStop = false;
            // 
            // grpBookedInfo
            // 
            this.grpBookedInfo.Controls.Add(this.btnSynchITV);
            this.grpBookedInfo.Controls.Add(this.txtNotes);
            this.grpBookedInfo.Controls.Add(this.btnBookCancel);
            this.grpBookedInfo.Controls.Add(this.btnEditBooking);
            this.grpBookedInfo.Controls.Add(this.btnSaveBooking);
            this.grpBookedInfo.Controls.Add(this.cmbPODTerminal);
            this.grpBookedInfo.Controls.Add(this.cmbPolTerminal);
            this.grpBookedInfo.Controls.Add(this.txtBookAdjRsn);
            this.grpBookedInfo.Controls.Add(this.txtBookAdjRdd);
            this.grpBookedInfo.Controls.Add(this.txtBookRdd);
            this.grpBookedInfo.Controls.Add(this.txtBookDlvyDsc);
            this.grpBookedInfo.Controls.Add(this.cmbBookVoyage);
            this.grpBookedInfo.Controls.Add(this.cmbBookPLOD);
            this.grpBookedInfo.Controls.Add(this.cmbBookPLOR);
            this.grpBookedInfo.Location = new System.Drawing.Point(474, 30);
            this.grpBookedInfo.Name = "grpBookedInfo";
            this.grpBookedInfo.Size = new System.Drawing.Size(518, 181);
            this.grpBookedInfo.TabIndex = 16;
            this.grpBookedInfo.TabStop = false;
            this.grpBookedInfo.Text = "Booking Detail";
            this.grpBookedInfo.Enter += new System.EventHandler(this.grpBookedInfo_Enter);
            // 
            // btnSynchITV
            // 
            this.btnSynchITV.Location = new System.Drawing.Point(225, 146);
            this.btnSynchITV.Name = "btnSynchITV";
            this.btnSynchITV.Size = new System.Drawing.Size(75, 23);
            this.btnSynchITV.TabIndex = 34;
            this.btnSynchITV.Text = "Synch ITV";
            this.btnSynchITV.UseVisualStyleBackColor = true;
            this.btnSynchITV.Visible = false;
            this.btnSynchITV.Click += new System.EventHandler(this.btnSynchITV_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.Control;
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.LabelText = "Notes";
            this.txtNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtNotes.LinkDisabledMessage = "Link Disabled";
            this.txtNotes.Location = new System.Drawing.Point(46, 123);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(157, 40);
            this.txtNotes.TabIndex = 33;
            this.txtNotes.TabStop = false;
            // 
            // btnBookCancel
            // 
            this.btnBookCancel.Enabled = false;
            this.btnBookCancel.Location = new System.Drawing.Point(444, 146);
            this.btnBookCancel.Name = "btnBookCancel";
            this.btnBookCancel.Size = new System.Drawing.Size(68, 23);
            this.btnBookCancel.TabIndex = 32;
            this.btnBookCancel.Text = "Cancel";
            this.btnBookCancel.UseVisualStyleBackColor = true;
            this.btnBookCancel.Click += new System.EventHandler(this.btnBookCancel_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.Location = new System.Drawing.Point(306, 146);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(68, 23);
            this.btnEditBooking.TabIndex = 31;
            this.btnEditBooking.Text = "Edit";
            this.btnEditBooking.UseVisualStyleBackColor = true;
            this.btnEditBooking.Click += new System.EventHandler(this.btnEditBooking_Click);
            // 
            // btnSaveBooking
            // 
            this.btnSaveBooking.Enabled = false;
            this.btnSaveBooking.Location = new System.Drawing.Point(375, 146);
            this.btnSaveBooking.Name = "btnSaveBooking";
            this.btnSaveBooking.Size = new System.Drawing.Size(68, 23);
            this.btnSaveBooking.TabIndex = 30;
            this.btnSaveBooking.Text = "Save";
            this.btnSaveBooking.UseVisualStyleBackColor = true;
            this.btnSaveBooking.Click += new System.EventHandler(this.btnSaveBooking_Click);
            // 
            // cmbPODTerminal
            // 
            this.cmbPODTerminal.BackColor = System.Drawing.SystemColors.Control;
            cmbPODTerminal_DesignTimeLayout.LayoutString = resources.GetString("cmbPODTerminal_DesignTimeLayout.LayoutString");
            this.cmbPODTerminal.DesignTimeLayout = cmbPODTerminal_DesignTimeLayout;
            this.cmbPODTerminal.DisplayMember = "port_terminal";
            this.cmbPODTerminal.ForeColor = System.Drawing.Color.Black;
            this.cmbPODTerminal.LabelText = "POD";
            this.cmbPODTerminal.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPODTerminal.Location = new System.Drawing.Point(46, 80);
            this.cmbPODTerminal.Name = "cmbPODTerminal";
            this.cmbPODTerminal.ReadOnly = true;
            this.cmbPODTerminal.SelectedIndex = -1;
            this.cmbPODTerminal.SelectedItem = null;
            this.cmbPODTerminal.Size = new System.Drawing.Size(157, 20);
            this.cmbPODTerminal.TabIndex = 29;
            this.cmbPODTerminal.TabStop = false;
            this.cmbPODTerminal.ValueMember = "terminal_cd";
            // 
            // cmbPolTerminal
            // 
            this.cmbPolTerminal.BackColor = System.Drawing.SystemColors.Control;
            cmbPolTerminal_DesignTimeLayout.LayoutString = resources.GetString("cmbPolTerminal_DesignTimeLayout.LayoutString");
            this.cmbPolTerminal.DesignTimeLayout = cmbPolTerminal_DesignTimeLayout;
            this.cmbPolTerminal.DisplayMember = "port_terminal";
            this.cmbPolTerminal.ForeColor = System.Drawing.Color.Black;
            this.cmbPolTerminal.LabelText = "POL";
            this.cmbPolTerminal.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPolTerminal.Location = new System.Drawing.Point(46, 59);
            this.cmbPolTerminal.Name = "cmbPolTerminal";
            this.cmbPolTerminal.ReadOnly = true;
            this.cmbPolTerminal.SelectedIndex = -1;
            this.cmbPolTerminal.SelectedItem = null;
            this.cmbPolTerminal.Size = new System.Drawing.Size(157, 20);
            this.cmbPolTerminal.TabIndex = 28;
            this.cmbPolTerminal.TabStop = false;
            this.cmbPolTerminal.ValueMember = "terminal_cd";
            // 
            // txtBookAdjRsn
            // 
            this.txtBookAdjRsn.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookAdjRsn.ForeColor = System.Drawing.Color.Black;
            this.txtBookAdjRsn.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtBookAdjRsn.LabelText = "Reason";
            this.txtBookAdjRsn.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookAdjRsn.LinkDisabledMessage = "Link Disabled";
            this.txtBookAdjRsn.Location = new System.Drawing.Point(377, 78);
            this.txtBookAdjRsn.Multiline = true;
            this.txtBookAdjRsn.Name = "txtBookAdjRsn";
            this.txtBookAdjRsn.ReadOnly = true;
            this.txtBookAdjRsn.Size = new System.Drawing.Size(135, 40);
            this.txtBookAdjRsn.TabIndex = 27;
            this.txtBookAdjRsn.TabStop = false;
            // 
            // txtBookAdjRdd
            // 
            this.txtBookAdjRdd.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookAdjRdd.DefaultFormat = "MM-dd-yy";
            this.txtBookAdjRdd.EditFormat = "MMddyy";
            this.txtBookAdjRdd.ForeColor = System.Drawing.Color.Black;
            this.txtBookAdjRdd.LabelText = "Current RDD";
            this.txtBookAdjRdd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookAdjRdd.LinkDisabledMessage = "Link Disabled";
            this.txtBookAdjRdd.Location = new System.Drawing.Point(443, 39);
            this.txtBookAdjRdd.MaxLength = 8;
            this.txtBookAdjRdd.Name = "txtBookAdjRdd";
            this.txtBookAdjRdd.ReadOnly = true;
            this.txtBookAdjRdd.Size = new System.Drawing.Size(68, 20);
            this.txtBookAdjRdd.TabIndex = 26;
            this.txtBookAdjRdd.TabStop = false;
            this.txtBookAdjRdd.Value = null;
            // 
            // txtBookRdd
            // 
            this.txtBookRdd.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookRdd.ForeColor = System.Drawing.Color.Black;
            this.txtBookRdd.LabelText = "Original RDD";
            this.txtBookRdd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookRdd.LinkDisabledMessage = "Link Disabled";
            this.txtBookRdd.Location = new System.Drawing.Point(443, 17);
            this.txtBookRdd.MaxLength = 10;
            this.txtBookRdd.Name = "txtBookRdd";
            this.txtBookRdd.ReadOnly = true;
            this.txtBookRdd.Size = new System.Drawing.Size(68, 20);
            this.txtBookRdd.TabIndex = 25;
            this.txtBookRdd.TabStop = false;
            this.txtBookRdd.Value = null;
            // 
            // txtBookDlvyDsc
            // 
            this.txtBookDlvyDsc.LinkDisabledMessage = "Link Disabled";
            this.txtBookDlvyDsc.Location = new System.Drawing.Point(208, 15);
            this.txtBookDlvyDsc.Multiline = true;
            this.txtBookDlvyDsc.Name = "txtBookDlvyDsc";
            this.txtBookDlvyDsc.Size = new System.Drawing.Size(161, 104);
            this.txtBookDlvyDsc.TabIndex = 6;
            // 
            // cmbBookVoyage
            // 
            this.cmbBookVoyage.BackColor = System.Drawing.SystemColors.Control;
            this.cmbBookVoyage.DescriptionColumn = "voyage_dsc";
            cmbBookVoyage_DesignTimeLayout.LayoutString = resources.GetString("cmbBookVoyage_DesignTimeLayout.LayoutString");
            this.cmbBookVoyage.DesignTimeLayout = cmbBookVoyage_DesignTimeLayout;
            this.cmbBookVoyage.DisplayMember = "voyage_dsc";
            this.cmbBookVoyage.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbBookVoyage.ForeColor = System.Drawing.Color.Black;
            this.cmbBookVoyage.LabelText = "Voyage";
            this.cmbBookVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbBookVoyage.Location = new System.Drawing.Point(46, 17);
            this.cmbBookVoyage.Name = "cmbBookVoyage";
            this.cmbBookVoyage.ReadOnly = true;
            this.cmbBookVoyage.SelectedIndex = -1;
            this.cmbBookVoyage.SelectedItem = null;
            this.cmbBookVoyage.Size = new System.Drawing.Size(157, 20);
            this.cmbBookVoyage.TabIndex = 5;
            this.cmbBookVoyage.TabStop = false;
            this.cmbBookVoyage.ValueColumn = "voyage_cd";
            this.cmbBookVoyage.ValueMember = "voyage_cd";
            this.cmbBookVoyage.ValueChanged += new System.EventHandler(this.cmbBookVoyage_ValueChanged);
            // 
            // cmbBookPLOD
            // 
            this.cmbBookPLOD.CodeColumn = "Location_Cd";
            this.cmbBookPLOD.DescriptionColumn = "Location_Dsc";
            cmbBookPLOD_DesignTimeLayout.LayoutString = resources.GetString("cmbBookPLOD_DesignTimeLayout.LayoutString");
            this.cmbBookPLOD.DesignTimeLayout = cmbBookPLOD_DesignTimeLayout;
            this.cmbBookPLOD.DisplayMember = "Location_Dsc";
            this.cmbBookPLOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbBookPLOD.LabelText = "PLOD";
            this.cmbBookPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbBookPLOD.Location = new System.Drawing.Point(46, 101);
            this.cmbBookPLOD.Name = "cmbBookPLOD";
            this.cmbBookPLOD.SelectedIndex = -1;
            this.cmbBookPLOD.SelectedItem = null;
            this.cmbBookPLOD.Size = new System.Drawing.Size(157, 20);
            this.cmbBookPLOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbBookPLOD.TabIndex = 4;
            this.cmbBookPLOD.ValueColumn = "Location_Cd";
            this.cmbBookPLOD.ValueMember = "Location_Cd";
            // 
            // cmbBookPLOR
            // 
            this.cmbBookPLOR.CodeColumn = "Location_Cd";
            this.cmbBookPLOR.DescriptionColumn = "Location_Dsc";
            cmbBookPLOR_DesignTimeLayout.LayoutString = resources.GetString("cmbBookPLOR_DesignTimeLayout.LayoutString");
            this.cmbBookPLOR.DesignTimeLayout = cmbBookPLOR_DesignTimeLayout;
            this.cmbBookPLOR.DisplayMember = "Location_Dsc";
            this.cmbBookPLOR.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbBookPLOR.LabelText = "PLOR";
            this.cmbBookPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbBookPLOR.Location = new System.Drawing.Point(46, 38);
            this.cmbBookPLOR.Name = "cmbBookPLOR";
            this.cmbBookPLOR.SelectedIndex = -1;
            this.cmbBookPLOR.SelectedItem = null;
            this.cmbBookPLOR.Size = new System.Drawing.Size(157, 20);
            this.cmbBookPLOR.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbBookPLOR.TabIndex = 0;
            this.cmbBookPLOR.ValueColumn = "Location_Cd";
            this.cmbBookPLOR.ValueMember = "Location_Cd";
            // 
            // pnlBookingDetail
            // 
            this.pnlBookingDetail.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBookingDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBookingDetail.Controls.Add(this.grdLocks);
            this.pnlBookingDetail.Controls.Add(this.toolStrip1);
            this.pnlBookingDetail.Controls.Add(this.pnlCommands);
            this.pnlBookingDetail.Controls.Add(this.ucGroupBox2);
            this.pnlBookingDetail.Controls.Add(this.grpBookedInfo);
            this.pnlBookingDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBookingDetail.Location = new System.Drawing.Point(3, 3);
            this.pnlBookingDetail.Name = "pnlBookingDetail";
            this.pnlBookingDetail.Size = new System.Drawing.Size(1123, 245);
            this.pnlBookingDetail.TabIndex = 17;
            // 
            // grdLocks
            // 
            grdLocks_DesignTimeLayout.LayoutString = resources.GetString("grdLocks_DesignTimeLayout.LayoutString");
            this.grdLocks.DesignTimeLayout = grdLocks_DesignTimeLayout;
            this.grdLocks.ExportFileID = null;
            this.grdLocks.GroupByBoxVisible = false;
            this.grdLocks.Location = new System.Drawing.Point(998, 37);
            this.grdLocks.Name = "grdLocks";
            this.grdLocks.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdLocks.Size = new System.Drawing.Size(109, 174);
            this.grdLocks.TabIndex = 19;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCommands});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1121, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "Commands";
            // 
            // tsCommands
            // 
            this.tsCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCommands.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAccept,
            this.tsRequestBooking,
            this.tsRequestCounter,
            this.tsReleaseWaitList,
            this.tsCancel});
            this.tsCommands.Image = ((System.Drawing.Image)(resources.GetObject("tsCommands.Image")));
            this.tsCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCommands.Name = "tsCommands";
            this.tsCommands.Size = new System.Drawing.Size(72, 22);
            this.tsCommands.Text = "Commands";
            // 
            // tsAccept
            // 
            this.tsAccept.Name = "tsAccept";
            this.tsAccept.Size = new System.Drawing.Size(192, 22);
            this.tsAccept.Text = "Accept";
            this.tsAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tsRequestBooking
            // 
            this.tsRequestBooking.Name = "tsRequestBooking";
            this.tsRequestBooking.Size = new System.Drawing.Size(192, 22);
            this.tsRequestBooking.Text = "&Request Booking";
            this.tsRequestBooking.Click += new System.EventHandler(this.btnRequestBk_Click);
            // 
            // tsRequestCounter
            // 
            this.tsRequestCounter.Name = "tsRequestCounter";
            this.tsRequestCounter.Size = new System.Drawing.Size(192, 22);
            this.tsRequestCounter.Text = "Request &Counter";
            this.tsRequestCounter.Click += new System.EventHandler(this.btnRequestCtr_Click);
            // 
            // tsReleaseWaitList
            // 
            this.tsReleaseWaitList.Name = "tsReleaseWaitList";
            this.tsReleaseWaitList.Size = new System.Drawing.Size(192, 22);
            this.tsReleaseWaitList.Text = "Release from Wait List";
            this.tsReleaseWaitList.Click += new System.EventHandler(this.btnWaitRelease_Click);
            // 
            // tsCancel
            // 
            this.tsCancel.Name = "tsCancel";
            this.tsCancel.Size = new System.Drawing.Size(192, 22);
            this.tsCancel.Text = "Cancel the Booking";
            this.tsCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlCommands
            // 
            this.pnlCommands.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlCommands.Controls.Add(this.ucButton1);
            this.pnlCommands.Controls.Add(this.btnDecline);
            this.pnlCommands.Controls.Add(this.btnAccept);
            this.pnlCommands.Controls.Add(this.btnReleaseWait);
            this.pnlCommands.Controls.Add(this.btnRequestCounter);
            this.pnlCommands.Controls.Add(this.btnRequestBooking);
            this.pnlCommands.Controls.Add(this.btnViewLine);
            this.pnlCommands.Controls.Add(this.btnViewEDI);
            this.pnlCommands.Controls.Add(this.btnITV);
            this.pnlCommands.Controls.Add(this.lblProblems);
            this.pnlCommands.Controls.Add(this.btnDockReceipt);
            this.pnlCommands.Controls.Add(this.btnRequestSheet);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommands.Location = new System.Drawing.Point(0, 217);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Size = new System.Drawing.Size(1121, 26);
            this.pnlCommands.TabIndex = 17;
            // 
            // ucButton1
            // 
            this.ucButton1.Location = new System.Drawing.Point(636, 1);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(89, 23);
            this.ucButton1.TabIndex = 35;
            this.ucButton1.Text = "Dock Delivery";
            this.ucButton1.UseVisualStyleBackColor = true;
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click_1);
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(194, 1);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(67, 23);
            this.btnDecline.TabIndex = 34;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(356, 1);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(68, 23);
            this.btnAccept.TabIndex = 33;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReleaseWait
            // 
            this.btnReleaseWait.Location = new System.Drawing.Point(260, 1);
            this.btnReleaseWait.Name = "btnReleaseWait";
            this.btnReleaseWait.Size = new System.Drawing.Size(97, 23);
            this.btnReleaseWait.TabIndex = 32;
            this.btnReleaseWait.Text = "Release Waitlist";
            this.btnReleaseWait.UseVisualStyleBackColor = true;
            this.btnReleaseWait.Click += new System.EventHandler(this.btnReleaseWait_Click);
            // 
            // btnRequestCounter
            // 
            this.btnRequestCounter.Location = new System.Drawing.Point(98, 1);
            this.btnRequestCounter.Name = "btnRequestCounter";
            this.btnRequestCounter.Size = new System.Drawing.Size(97, 23);
            this.btnRequestCounter.TabIndex = 31;
            this.btnRequestCounter.Text = "Request Counter";
            this.btnRequestCounter.UseVisualStyleBackColor = true;
            this.btnRequestCounter.Click += new System.EventHandler(this.btnRequestCtr_Click);
            // 
            // btnRequestBooking
            // 
            this.btnRequestBooking.Location = new System.Drawing.Point(1, 1);
            this.btnRequestBooking.Name = "btnRequestBooking";
            this.btnRequestBooking.Size = new System.Drawing.Size(97, 23);
            this.btnRequestBooking.TabIndex = 30;
            this.btnRequestBooking.Text = "Request Booking";
            this.btnRequestBooking.UseVisualStyleBackColor = true;
            this.btnRequestBooking.Click += new System.EventHandler(this.btnRequestBk_Click);
            // 
            // btnViewLine
            // 
            this.btnViewLine.Location = new System.Drawing.Point(724, 1);
            this.btnViewLine.Name = "btnViewLine";
            this.btnViewLine.Size = new System.Drawing.Size(100, 23);
            this.btnViewLine.TabIndex = 29;
            this.btnViewLine.Text = "View Ocean Data";
            this.btnViewLine.UseVisualStyleBackColor = true;
            this.btnViewLine.Click += new System.EventHandler(this.btnViewLine_Click);
            // 
            // btnViewEDI
            // 
            this.btnViewEDI.Location = new System.Drawing.Point(861, 1);
            this.btnViewEDI.Name = "btnViewEDI";
            this.btnViewEDI.Size = new System.Drawing.Size(62, 23);
            this.btnViewEDI.TabIndex = 28;
            this.btnViewEDI.Text = "EDI Log";
            this.btnViewEDI.UseVisualStyleBackColor = true;
            this.btnViewEDI.Visible = false;
            this.btnViewEDI.Click += new System.EventHandler(this.btnViewEDI_Click);
            // 
            // btnITV
            // 
            this.btnITV.Location = new System.Drawing.Point(824, 1);
            this.btnITV.Name = "btnITV";
            this.btnITV.Size = new System.Drawing.Size(35, 23);
            this.btnITV.TabIndex = 27;
            this.btnITV.Text = "ITV";
            this.btnITV.UseVisualStyleBackColor = true;
            this.btnITV.Visible = false;
            this.btnITV.Click += new System.EventHandler(this.btnITV_Click);
            // 
            // lblProblems
            // 
            this.lblProblems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProblems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblProblems.Location = new System.Drawing.Point(925, 6);
            this.lblProblems.Name = "lblProblems";
            this.lblProblems.Size = new System.Drawing.Size(58, 13);
            this.lblProblems.TabIndex = 26;
            this.lblProblems.Text = "Problems";
            // 
            // btnDockReceipt
            // 
            this.btnDockReceipt.Location = new System.Drawing.Point(556, 1);
            this.btnDockReceipt.Name = "btnDockReceipt";
            this.btnDockReceipt.Size = new System.Drawing.Size(81, 23);
            this.btnDockReceipt.TabIndex = 25;
            this.btnDockReceipt.Text = "Dock Receipt";
            this.btnDockReceipt.UseVisualStyleBackColor = true;
            this.btnDockReceipt.Click += new System.EventHandler(this.btnDockReceipt_Click);
            // 
            // btnRequestSheet
            // 
            this.btnRequestSheet.Location = new System.Drawing.Point(478, 1);
            this.btnRequestSheet.Name = "btnRequestSheet";
            this.btnRequestSheet.Size = new System.Drawing.Size(79, 23);
            this.btnRequestSheet.TabIndex = 0;
            this.btnRequestSheet.Text = "Print Request";
            this.btnRequestSheet.UseVisualStyleBackColor = true;
            this.btnRequestSheet.Click += new System.EventHandler(this.btnRequestSheet_Click);
            // 
            // grdParties
            // 
            this.grdParties.AutoEdit = true;
            this.grdParties.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grdParties.ColumnAutoResize = true;
            grdParties_DesignTimeLayout.LayoutString = resources.GetString("grdParties_DesignTimeLayout.LayoutString");
            this.grdParties.DesignTimeLayout = grdParties_DesignTimeLayout;
            this.grdParties.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdParties.ExportFileID = null;
            this.grdParties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdParties.GroupByBoxVisible = false;
            this.grdParties.Location = new System.Drawing.Point(3, 248);
            this.grdParties.Name = "grdParties";
            this.grdParties.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdParties.RowFormatStyle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grdParties.Size = new System.Drawing.Size(1123, 91);
            this.grdParties.TabIndex = 19;
            // 
            // grdCargo
            // 
            this.grdCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdCargo.BackColor = System.Drawing.Color.White;
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCargo.FrozenColumns = 2;
            this.grdCargo.GroupByBoxVisible = false;
            this.grdCargo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdCargo.Location = new System.Drawing.Point(3, 400);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.RowFormatStyle.BackColor = System.Drawing.Color.Empty;
            this.grdCargo.SelectedFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.SunkenLight;
            this.grdCargo.SelectedFormatStyle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.grdCargo.SelectedFormatStyle.BackColorGradient = System.Drawing.Color.Empty;
            this.grdCargo.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.False;
            this.grdCargo.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdCargo.Size = new System.Drawing.Size(1123, 270);
            this.grdCargo.TabIndex = 20;
            this.grdCargo.FetchCellToolTipText += new Janus.Windows.GridEX.FetchCellToolTipTextEventHandler(this.grdCargo_FetchCellToolTipText);
            this.grdCargo.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCargo_LinkClicked);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpMain);
            this.tabMain.Controls.Add(this.tpMapErrors);
            this.tabMain.Controls.Add(this.tpRDD);
            this.tabMain.Controls.Add(this.tpCorrespondence);
            this.tabMain.Controls.Add(this.tpAudit);
            this.tabMain.Controls.Add(this.tbEDILog);
            this.tabMain.Controls.Add(this.tpITV);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1137, 699);
            this.tabMain.TabIndex = 21;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.grdCargo);
            this.tpMain.Controls.Add(this.grdTShipment);
            this.tpMain.Controls.Add(this.grdParties);
            this.tpMain.Controls.Add(this.pnlBookingDetail);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(1129, 673);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Booking Request";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // grdTShipment
            // 
            grdTShipment_DesignTimeLayout.LayoutString = resources.GetString("grdTShipment_DesignTimeLayout.LayoutString");
            this.grdTShipment.DesignTimeLayout = grdTShipment_DesignTimeLayout;
            this.grdTShipment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdTShipment.ExportFileID = null;
            this.grdTShipment.GroupByBoxVisible = false;
            this.grdTShipment.Location = new System.Drawing.Point(3, 339);
            this.grdTShipment.Name = "grdTShipment";
            this.grdTShipment.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdTShipment.Size = new System.Drawing.Size(1123, 61);
            this.grdTShipment.TabIndex = 21;
            // 
            // tpMapErrors
            // 
            this.tpMapErrors.Controls.Add(this.splitError);
            this.tpMapErrors.Location = new System.Drawing.Point(4, 22);
            this.tpMapErrors.Name = "tpMapErrors";
            this.tpMapErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tpMapErrors.Size = new System.Drawing.Size(1129, 673);
            this.tpMapErrors.TabIndex = 1;
            this.tpMapErrors.Text = "Mapping Errors";
            this.tpMapErrors.UseVisualStyleBackColor = true;
            // 
            // splitError
            // 
            this.splitError.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitError.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitError.Location = new System.Drawing.Point(3, 3);
            this.splitError.Name = "splitError";
            this.splitError.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitError.Panel1
            // 
            this.splitError.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitError.Panel1.Controls.Add(this.btnRelease);
            this.splitError.Panel1.Controls.Add(this.txtReleaseNotes);
            // 
            // splitError.Panel2
            // 
            this.splitError.Panel2.Controls.Add(this.grdMappingErrors);
            this.splitError.Size = new System.Drawing.Size(1123, 667);
            this.splitError.SplitterDistance = 80;
            this.splitError.TabIndex = 0;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(312, 17);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(75, 23);
            this.btnRelease.TabIndex = 1;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // txtReleaseNotes
            // 
            this.txtReleaseNotes.LabelText = "Notes";
            this.txtReleaseNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtReleaseNotes.LinkDisabledMessage = "Link Disabled";
            this.txtReleaseNotes.Location = new System.Drawing.Point(55, 19);
            this.txtReleaseNotes.Name = "txtReleaseNotes";
            this.txtReleaseNotes.Size = new System.Drawing.Size(245, 20);
            this.txtReleaseNotes.TabIndex = 0;
            // 
            // grdMappingErrors
            // 
            this.grdMappingErrors.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdMappingErrors_DesignTimeLayout.LayoutString = resources.GetString("grdMappingErrors_DesignTimeLayout.LayoutString");
            this.grdMappingErrors.DesignTimeLayout = grdMappingErrors_DesignTimeLayout;
            this.grdMappingErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMappingErrors.ExportFileID = null;
            this.grdMappingErrors.GroupByBoxVisible = false;
            this.grdMappingErrors.Location = new System.Drawing.Point(0, 0);
            this.grdMappingErrors.Name = "grdMappingErrors";
            this.grdMappingErrors.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMappingErrors.RowFormatStyle.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grdMappingErrors.Size = new System.Drawing.Size(1123, 583);
            this.grdMappingErrors.TabIndex = 0;
            // 
            // tpRDD
            // 
            this.tpRDD.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tpRDD.Controls.Add(this.grdRDDLog);
            this.tpRDD.Controls.Add(this.ucPanel1);
            this.tpRDD.Location = new System.Drawing.Point(4, 22);
            this.tpRDD.Name = "tpRDD";
            this.tpRDD.Size = new System.Drawing.Size(1129, 673);
            this.tpRDD.TabIndex = 2;
            this.tpRDD.Text = "RDD Delays";
            // 
            // grdRDDLog
            // 
            this.grdRDDLog.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdRDDLog_DesignTimeLayout.LayoutString = resources.GetString("grdRDDLog_DesignTimeLayout.LayoutString");
            this.grdRDDLog.DesignTimeLayout = grdRDDLog_DesignTimeLayout;
            this.grdRDDLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRDDLog.ExportFileID = null;
            this.grdRDDLog.Location = new System.Drawing.Point(0, 47);
            this.grdRDDLog.Name = "grdRDDLog";
            this.grdRDDLog.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdRDDLog.Size = new System.Drawing.Size(1129, 626);
            this.grdRDDLog.TabIndex = 29;
            // 
            // ucPanel1
            // 
            this.ucPanel1.Controls.Add(this.ucLabel1);
            this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel1.Location = new System.Drawing.Point(0, 0);
            this.ucPanel1.Name = "ucPanel1";
            this.ucPanel1.Size = new System.Drawing.Size(1129, 47);
            this.ucPanel1.TabIndex = 28;
            // 
            // ucLabel1
            // 
            this.ucLabel1.Location = new System.Drawing.Point(23, 15);
            this.ucLabel1.Name = "ucLabel1";
            this.ucLabel1.Size = new System.Drawing.Size(180, 13);
            this.ucLabel1.TabIndex = 0;
            this.ucLabel1.Text = "Government Authorized RDD Delays";
            // 
            // tpCorrespondence
            // 
            this.tpCorrespondence.Controls.Add(this.grdCorrespondence);
            this.tpCorrespondence.Controls.Add(this.ucPanel2);
            this.tpCorrespondence.Location = new System.Drawing.Point(4, 22);
            this.tpCorrespondence.Name = "tpCorrespondence";
            this.tpCorrespondence.Size = new System.Drawing.Size(1129, 673);
            this.tpCorrespondence.TabIndex = 3;
            this.tpCorrespondence.Text = "Correspondence";
            this.tpCorrespondence.UseVisualStyleBackColor = true;
            // 
            // grdCorrespondence
            // 
            this.grdCorrespondence.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdCorrespondence_DesignTimeLayout.LayoutString = resources.GetString("grdCorrespondence_DesignTimeLayout.LayoutString");
            this.grdCorrespondence.DesignTimeLayout = grdCorrespondence_DesignTimeLayout;
            this.grdCorrespondence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCorrespondence.ExportFileID = null;
            this.grdCorrespondence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdCorrespondence.GroupByBoxVisible = false;
            this.grdCorrespondence.Location = new System.Drawing.Point(0, 26);
            this.grdCorrespondence.Name = "grdCorrespondence";
            this.grdCorrespondence.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCorrespondence.Size = new System.Drawing.Size(1129, 647);
            this.grdCorrespondence.TabIndex = 0;
            this.grdCorrespondence.FetchCellToolTipText += new Janus.Windows.GridEX.FetchCellToolTipTextEventHandler(this.grdCorrespondence_FetchCellToolTipText);
            this.grdCorrespondence.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdCorrespondence_LoadingRow);
            this.grdCorrespondence.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdCorrespondence_LinkClicked);
            // 
            // ucPanel2
            // 
            this.ucPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ucPanel2.Controls.Add(this.btnAddCorr);
            this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel2.Location = new System.Drawing.Point(0, 0);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(1129, 26);
            this.ucPanel2.TabIndex = 18;
            // 
            // btnAddCorr
            // 
            this.btnAddCorr.Location = new System.Drawing.Point(6, 1);
            this.btnAddCorr.Name = "btnAddCorr";
            this.btnAddCorr.Size = new System.Drawing.Size(138, 23);
            this.btnAddCorr.TabIndex = 0;
            this.btnAddCorr.Text = "Add Correspondence";
            this.btnAddCorr.UseVisualStyleBackColor = true;
            this.btnAddCorr.Click += new System.EventHandler(this.btnAddCorr_Click);
            // 
            // tpAudit
            // 
            this.tpAudit.Controls.Add(this.grdAudit);
            this.tpAudit.Location = new System.Drawing.Point(4, 22);
            this.tpAudit.Name = "tpAudit";
            this.tpAudit.Size = new System.Drawing.Size(1129, 673);
            this.tpAudit.TabIndex = 4;
            this.tpAudit.Text = "Audit Trail";
            this.tpAudit.UseVisualStyleBackColor = true;
            // 
            // grdAudit
            // 
            this.grdAudit.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAudit.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdAudit_DesignTimeLayout.LayoutString = resources.GetString("grdAudit_DesignTimeLayout.LayoutString");
            this.grdAudit.DesignTimeLayout = grdAudit_DesignTimeLayout;
            this.grdAudit.DisplayFieldChooser = true;
            this.grdAudit.DisplayFontSelector = true;
            this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAudit.ExportFileID = null;
            this.grdAudit.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAudit.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdAudit.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdAudit.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdAudit.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdAudit.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAudit.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdAudit.Location = new System.Drawing.Point(0, 0);
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdAudit.Size = new System.Drawing.Size(1129, 673);
            this.grdAudit.TabIndex = 0;
            this.grdAudit.FetchCellToolTipText += new Janus.Windows.GridEX.FetchCellToolTipTextEventHandler(this.grdAudit_FetchCellToolTipText);
            // 
            // tbEDILog
            // 
            this.tbEDILog.Controls.Add(this.grdOceanAPI);
            this.tbEDILog.Controls.Add(this.grdArcEDILog);
            this.tbEDILog.Location = new System.Drawing.Point(4, 22);
            this.tbEDILog.Name = "tbEDILog";
            this.tbEDILog.Padding = new System.Windows.Forms.Padding(3);
            this.tbEDILog.Size = new System.Drawing.Size(1129, 673);
            this.tbEDILog.TabIndex = 5;
            this.tbEDILog.Text = "EDI Log";
            this.tbEDILog.UseVisualStyleBackColor = true;
            // 
            // grdOceanAPI
            // 
            grdOceanAPI_DesignTimeLayout.LayoutString = resources.GetString("grdOceanAPI_DesignTimeLayout.LayoutString");
            this.grdOceanAPI.DesignTimeLayout = grdOceanAPI_DesignTimeLayout;
            this.grdOceanAPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdOceanAPI.ExportFileID = null;
            this.grdOceanAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdOceanAPI.GroupByBoxVisible = false;
            this.grdOceanAPI.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdOceanAPI.Location = new System.Drawing.Point(3, 253);
            this.grdOceanAPI.Name = "grdOceanAPI";
            this.grdOceanAPI.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdOceanAPI.Size = new System.Drawing.Size(1123, 176);
            this.grdOceanAPI.TabIndex = 4;
            // 
            // grdArcEDILog
            // 
            grdArcEDILog_DesignTimeLayout.LayoutString = resources.GetString("grdArcEDILog_DesignTimeLayout.LayoutString");
            this.grdArcEDILog.DesignTimeLayout = grdArcEDILog_DesignTimeLayout;
            this.grdArcEDILog.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdArcEDILog.ExportFileID = null;
            this.grdArcEDILog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdArcEDILog.GroupByBoxVisible = false;
            this.grdArcEDILog.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.grdArcEDILog.Location = new System.Drawing.Point(3, 3);
            this.grdArcEDILog.Name = "grdArcEDILog";
            this.grdArcEDILog.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdArcEDILog.Size = new System.Drawing.Size(1123, 250);
            this.grdArcEDILog.TabIndex = 3;
            this.grdArcEDILog.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdArcEDILog_LinkClicked);
            // 
            // tpITV
            // 
            this.tpITV.Controls.Add(this.grdITVList);
            this.tpITV.Location = new System.Drawing.Point(4, 22);
            this.tpITV.Name = "tpITV";
            this.tpITV.Padding = new System.Windows.Forms.Padding(3);
            this.tpITV.Size = new System.Drawing.Size(1129, 673);
            this.tpITV.TabIndex = 6;
            this.tpITV.Text = "ITV History";
            this.tpITV.UseVisualStyleBackColor = true;
            // 
            // grdITVList
            // 
            grdITVList_DesignTimeLayout.LayoutString = resources.GetString("grdITVList_DesignTimeLayout.LayoutString");
            this.grdITVList.DesignTimeLayout = grdITVList_DesignTimeLayout;
            this.grdITVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdITVList.ExportFileID = null;
            this.grdITVList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdITVList.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdITVList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdITVList.FrozenColumns = 4;
            this.grdITVList.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdITVList.Location = new System.Drawing.Point(3, 3);
            this.grdITVList.Name = "grdITVList";
            this.grdITVList.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdITVList.Size = new System.Drawing.Size(1123, 667);
            this.grdITVList.TabIndex = 1;
            this.grdITVList.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            // 
            // frmViewBookingRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1137, 699);
            this.Controls.Add(this.tabMain);
            this.Name = "frmViewBookingRequest";
            this.Text = "Booking Request";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViewBookingRequest_FormClosed);
            this.ucGroupBox2.ResumeLayout(false);
            this.ucGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            this.grpBookedInfo.ResumeLayout(false);
            this.grpBookedInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPODTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPolTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookVoyage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookPLOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBookPLOR)).EndInit();
            this.pnlBookingDetail.ResumeLayout(false);
            this.pnlBookingDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocks)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlCommands.ResumeLayout(false);
            this.pnlCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTShipment)).EndInit();
            this.tpMapErrors.ResumeLayout(false);
            this.splitError.Panel1.ResumeLayout(false);
            this.splitError.Panel1.PerformLayout();
            this.splitError.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitError)).EndInit();
            this.splitError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMappingErrors)).EndInit();
            this.tpRDD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRDDLog)).EndInit();
            this.ucPanel1.ResumeLayout(false);
            this.ucPanel1.PerformLayout();
            this.tpCorrespondence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCorrespondence)).EndInit();
            this.ucPanel2.ResumeLayout(false);
            this.tpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            this.tbEDILog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOceanAPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArcEDILog)).EndInit();
            this.tpITV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdITVList)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucButton btnRequestSave;
		private CommonWinCtrls.ucTextBox txtReqPhone;
		private CommonWinCtrls.ucTextBox txtReqHazDsc;
		private CommonWinCtrls.ucTextBox txtReqBookerName;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucMultiColumnCombo cmbStatus;
		private CommonWinCtrls.ucTextBox txtReqHazMatCd;
		private CommonWinCtrls.ucTextBox txtReqPCFN;
		private CommonWinCtrls.ucDateTextBox txtReqDt;
		private CommonWinCtrls.ucTextBox txtReqVoyage;
		private CommonWinCtrls.ucDateTextBox txtReqAvailable;
		private CommonWinCtrls.ucTextBox txtReqPOE;
		private CommonWinCtrls.ucDateTextBox txtReqRDD;
		private CommonWinCtrls.ucTextBox txtReqPOD;
		private CommonWinCtrls.ucTextBox txtReqVesselDsc;
		private CommonWinCtrls.ucGroupBox grpBookedInfo;
		private CommonWinCtrls.ucTextBox txtBookAdjRsn;
		private CommonWinCtrls.ucDateTextBox txtBookAdjRdd;
		private CommonWinCtrls.ucDateTextBox txtBookRdd;
		private CommonWinCtrls.ucTextBox txtBookDlvyDsc;
		private CommonWinCtrls.ucMultiColumnCombo cmbBookVoyage;
		private WinCtrls.ucLocationCombo cmbBookPLOD;
		private CommonWinCtrls.ucPanel pnlBookingDetail;
		private CommonWinCtrls.ucGridEx grdParties;
		private CommonWinCtrls.ucGridEx grdCargo;
		private WinCtrls.ucLocationCombo cmbBookPLOR;
		private CommonWinCtrls.ucMultiColumnCombo cmbPolTerminal;
		private CommonWinCtrls.ucMultiColumnCombo cmbPODTerminal;
		private CommonWinCtrls.ucButton btnEditRequest;
		private CommonWinCtrls.ucButton btnEditBooking;
		private CommonWinCtrls.ucButton btnSaveBooking;
		private CommonWinCtrls.ucPanel pnlCommands;
		private CommonWinCtrls.ucButton btnRequestSheet;
		private CommonWinCtrls.ucTabControl tabMain;
		private System.Windows.Forms.TabPage tpMain;
		private System.Windows.Forms.TabPage tpMapErrors;
		private CommonWinCtrls.ucSplitContainer splitError;
		private CommonWinCtrls.ucButton btnRelease;
		private CommonWinCtrls.ucTextBox txtReleaseNotes;
		private CommonWinCtrls.ucGridEx grdMappingErrors;
		private System.Windows.Forms.TabPage tpRDD;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucGridEx grdRDDLog;
		private CommonWinCtrls.ucLabel ucLabel1;
		private System.Windows.Forms.TabPage tpCorrespondence;
		private CommonWinCtrls.ucPanel ucPanel2;
		private CommonWinCtrls.ucButton btnAddCorr;
		private CommonWinCtrls.ucGridEx grdCorrespondence;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton tsCommands;
		private System.Windows.Forms.ToolStripMenuItem tsAccept;
		private System.Windows.Forms.ToolStripMenuItem tsRequestBooking;
		private System.Windows.Forms.ToolStripMenuItem tsRequestCounter;
		private System.Windows.Forms.ToolStripMenuItem tsReleaseWaitList;
		private System.Windows.Forms.ToolStripMenuItem tsCancel;
		private CommonWinCtrls.ucButton btnDockReceipt;
		private CommonWinCtrls.ucLabel lblProblems;
		private CommonWinCtrls.ucButton btnITV;
		private CommonWinCtrls.ucButton btnViewEDI;
		private CommonWinCtrls.ucButton btnRequestCancel;
		private CommonWinCtrls.ucMultiColumnCombo cmbTerms;
		private CommonWinCtrls.ucButton btnBookCancel;
		private CommonWinCtrls.ucButton btnViewLine;
		private System.Windows.Forms.TabPage tpAudit;
		private CommonWinCtrls.ucGridEx grdAudit;
		private CommonWinCtrls.ucButton btnRequestBooking;
		private CommonWinCtrls.ucButton btnAccept;
		private CommonWinCtrls.ucButton btnReleaseWait;
		private CommonWinCtrls.ucButton btnRequestCounter;
		private CommonWinCtrls.ucTextBox txtVoyDoc;
		private CommonWinCtrls.ucTextBox txtNotes;
		private CommonWinCtrls.ucGridEx grdTShipment;
		private CommonWinCtrls.ucButton btnDecline;
		private System.Windows.Forms.Button btnSynchITV;
		private CommonWinCtrls.ucTextBox txtHazMatQlfr;
		private CommonWinCtrls.ucTextBox txtHazMatClass;
		private CommonWinCtrls.ucTextBox txtHaxMatContact;
		private CommonWinCtrls.ucGridEx grdLocks;
        private CommonWinCtrls.ucTextBox txtSystem;
        private System.Windows.Forms.TabPage tbEDILog;
        private CommonWinCtrls.ucGridEx grdArcEDILog;
        private CommonWinCtrls.ucGridEx grdOceanAPI;
        private System.Windows.Forms.TabPage tpITV;
        private CommonWinCtrls.ucGridEx grdITVList;
        private CommonWinCtrls.ucButton ucButton1;
	}
}
