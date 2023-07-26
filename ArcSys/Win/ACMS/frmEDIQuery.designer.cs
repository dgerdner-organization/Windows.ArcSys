namespace ASL.ARC.EDITools
{
	partial class frmEDIQuery
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
			if( disposing && (components != null) )
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
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDIQuery));
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdSumm_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.btnSave = new CS2010.CommonWinCtrls.ucButton();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtNotes = new CS2010.CommonWinCtrls.ucTextBox();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbPOD = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbPOL = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.grpBox2 = new System.Windows.Forms.GroupBox();
            this.cbxLate = new CS2010.CommonWinCtrls.ucCheckBox();
            this.txtISAnbr = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxUnsent = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxDRAP = new CS2010.CommonWinCtrls.ucCheckBox();
            this.txtActivityCd = new CS2010.CommonWinCtrls.ucTextBox();
            this.dateActivityRange = new CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpList = new System.Windows.Forms.TabPage();
            this.grdList = new CS2010.CommonWinCtrls.ucGridEx();
            this.Summary = new System.Windows.Forms.TabPage();
            this.splitSummary = new System.Windows.Forms.SplitContainer();
            this.grdSumm = new CS2010.CommonWinCtrls.ucGridEx();
            this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.ucGroupBox1.SuspendLayout();
            this.grpBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            this.grpBox2.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.Summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSummary)).BeginInit();
            this.splitSummary.Panel1.SuspendLayout();
            this.splitSummary.Panel2.SuspendLayout();
            this.splitSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSumm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrMain
            // 
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.toolStripSeparator1,
            this.tbbClear});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(987, 25);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "LINE Protocol Main Toolbar";
            // 
            // tbbSearch
            // 
            this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSearch.Name = "tbbSearch";
            this.tbbSearch.Size = new System.Drawing.Size(44, 22);
            this.tbbSearch.Text = "&Search";
            this.tbbSearch.Click += new System.EventHandler(this.tbbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbClear
            // 
            this.tbbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(66, 22);
            this.tbbClear.Text = "Clear Fields";
            this.tbbClear.Click += new System.EventHandler(this.tbbClear_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.btnClear);
            this.pnlMain.Panel1.Controls.Add(this.btnSearch);
            this.pnlMain.Panel1.Controls.Add(this.btnSave);
            this.pnlMain.Panel1.Controls.Add(this.ucGroupBox1);
            this.pnlMain.Panel1.Controls.Add(this.grpBox1);
            this.pnlMain.Panel1.Controls.Add(this.grpBox2);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.tabMain);
            this.pnlMain.Size = new System.Drawing.Size(987, 556);
            this.pnlMain.SplitterDistance = 153;
            this.pnlMain.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(780, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(699, 120);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(900, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.btnRemove);
            this.ucGroupBox1.Controls.Add(this.btnApply);
            this.ucGroupBox1.Controls.Add(this.txtNotes);
            this.ucGroupBox1.Location = new System.Drawing.Point(507, 1);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(181, 147);
            this.ucGroupBox1.TabIndex = 15;
            this.ucGroupBox1.TabStop = false;
            this.ucGroupBox1.Text = "Add Notes";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(70, 73);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(55, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(11, 73);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(55, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.LinkDisabledMessage = "Link Disabled";
            this.txtNotes.Location = new System.Drawing.Point(11, 13);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(147, 58);
            this.txtNotes.TabIndex = 14;
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.txtBooking);
            this.grpBox1.Controls.Add(this.txtSerialNo);
            this.grpBox1.Controls.Add(this.txtVoyage);
            this.grpBox1.Controls.Add(this.txtPCFN);
            this.grpBox1.Controls.Add(this.cmbPOD);
            this.grpBox1.Controls.Add(this.cmbPOL);
            this.grpBox1.Location = new System.Drawing.Point(6, 1);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(200, 148);
            this.grpBox1.TabIndex = 18;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "Search Parameters";
            // 
            // txtBooking
            // 
            this.txtBooking.LabelText = "Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(55, 35);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(100, 20);
            this.txtBooking.TabIndex = 15;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelText = "Serial#";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(55, 57);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(138, 20);
            this.txtSerialNo.TabIndex = 2;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(55, 13);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(100, 20);
            this.txtVoyage.TabIndex = 20;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(55, 79);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(100, 20);
            this.txtPCFN.TabIndex = 4;
            // 
            // cmbPOD
            // 
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DisplayMember = "location_cd";
            this.cmbPOD.LabelText = "POD";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(55, 123);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(113, 20);
            this.cmbPOD.TabIndex = 10;
            this.cmbPOD.ValueMember = "location_cd";
            // 
            // cmbPOL
            // 
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DisplayMember = "location_cd";
            this.cmbPOL.LabelText = "POL";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(55, 101);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(113, 20);
            this.cmbPOL.TabIndex = 9;
            this.cmbPOL.ValueMember = "location_cd";
            // 
            // grpBox2
            // 
            this.grpBox2.Controls.Add(this.cbxLate);
            this.grpBox2.Controls.Add(this.txtISAnbr);
            this.grpBox2.Controls.Add(this.cbxUnsent);
            this.grpBox2.Controls.Add(this.cbxDRAP);
            this.grpBox2.Controls.Add(this.txtActivityCd);
            this.grpBox2.Controls.Add(this.dateActivityRange);
            this.grpBox2.Location = new System.Drawing.Point(213, 2);
            this.grpBox2.Name = "grpBox2";
            this.grpBox2.Size = new System.Drawing.Size(288, 148);
            this.grpBox2.TabIndex = 19;
            this.grpBox2.TabStop = false;
            this.grpBox2.Text = "Only applies to ITV List";
            // 
            // cbxLate
            // 
            this.cbxLate.Location = new System.Drawing.Point(50, 86);
            this.cbxLate.Name = "cbxLate";
            this.cbxLate.Size = new System.Drawing.Size(104, 21);
            this.cbxLate.TabIndex = 17;
            this.cbxLate.Text = "Just Late ITV";
            this.cbxLate.UseVisualStyleBackColor = true;
            this.cbxLate.YN = "N";
            // 
            // txtISAnbr
            // 
            this.txtISAnbr.LabelText = "ISA";
            this.txtISAnbr.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtISAnbr.LinkDisabledMessage = "Link Disabled";
            this.txtISAnbr.Location = new System.Drawing.Point(50, 19);
            this.txtISAnbr.Name = "txtISAnbr";
            this.txtISAnbr.Size = new System.Drawing.Size(100, 20);
            this.txtISAnbr.TabIndex = 11;
            // 
            // cbxUnsent
            // 
            this.cbxUnsent.Location = new System.Drawing.Point(50, 68);
            this.cbxUnsent.Name = "cbxUnsent";
            this.cbxUnsent.Size = new System.Drawing.Size(104, 22);
            this.cbxUnsent.TabIndex = 5;
            this.cbxUnsent.Text = "Just unsent ITV";
            this.cbxUnsent.UseVisualStyleBackColor = true;
            this.cbxUnsent.YN = "N";
            // 
            // cbxDRAP
            // 
            this.cbxDRAP.Location = new System.Drawing.Point(50, 103);
            this.cbxDRAP.Name = "cbxDRAP";
            this.cbxDRAP.Size = new System.Drawing.Size(104, 22);
            this.cbxDRAP.TabIndex = 13;
            this.cbxDRAP.Text = "Include DRAP";
            this.cbxDRAP.UseVisualStyleBackColor = true;
            this.cbxDRAP.YN = "N";
            // 
            // txtActivityCd
            // 
            this.txtActivityCd.LabelText = "Activity";
            this.txtActivityCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtActivityCd.LinkDisabledMessage = "Link Disabled";
            this.txtActivityCd.Location = new System.Drawing.Point(50, 43);
            this.txtActivityCd.Name = "txtActivityCd";
            this.txtActivityCd.Size = new System.Drawing.Size(49, 20);
            this.txtActivityCd.TabIndex = 3;
            // 
            // dateActivityRange
            // 
            this.dateActivityRange.CheckBoxChecked = true;
            this.dateActivityRange.CheckBoxText = "Activity Range";
            this.dateActivityRange.Location = new System.Drawing.Point(158, 19);
            this.dateActivityRange.Name = "dateActivityRange";
            this.dateActivityRange.Size = new System.Drawing.Size(128, 79);
            this.dateActivityRange.TabIndex = 12;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpList);
            this.tabMain.Controls.Add(this.Summary);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(987, 399);
            this.tabMain.TabIndex = 1;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.grdList);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(979, 373);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "ITV List";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // grdList
            // 
            grdList_DesignTimeLayout.LayoutString = resources.GetString("grdList_DesignTimeLayout.LayoutString");
            this.grdList.DesignTimeLayout = grdList_DesignTimeLayout;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.ExportFileID = null;
            this.grdList.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdList.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdList.FrozenColumns = 4;
            this.grdList.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdList.Location = new System.Drawing.Point(3, 3);
            this.grdList.Name = "grdList";
            this.grdList.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdList.Size = new System.Drawing.Size(973, 367);
            this.grdList.TabIndex = 0;
            this.grdList.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdList.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdList_FormattingRow);
            this.grdList.EditingCell += new Janus.Windows.GridEX.EditingCellEventHandler(this.grdResults_EditingCell);
            this.grdList.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_CellUpdated);
            this.grdList.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdList_ColumnButtonClick);
            this.grdList.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdList_LinkClicked);
            this.grdList.TextChanged += new System.EventHandler(this.grdResults_TextChanged);
            // 
            // Summary
            // 
            this.Summary.Controls.Add(this.splitSummary);
            this.Summary.Location = new System.Drawing.Point(4, 22);
            this.Summary.Name = "Summary";
            this.Summary.Padding = new System.Windows.Forms.Padding(3);
            this.Summary.Size = new System.Drawing.Size(979, 373);
            this.Summary.TabIndex = 1;
            this.Summary.Text = "ITV Summary";
            this.Summary.UseVisualStyleBackColor = true;
            // 
            // splitSummary
            // 
            this.splitSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSummary.Location = new System.Drawing.Point(3, 3);
            this.splitSummary.Name = "splitSummary";
            this.splitSummary.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitSummary.Panel1
            // 
            this.splitSummary.Panel1.Controls.Add(this.grdSumm);
            // 
            // splitSummary.Panel2
            // 
            this.splitSummary.Panel2.Controls.Add(this.grdDetail);
            this.splitSummary.Size = new System.Drawing.Size(973, 367);
            this.splitSummary.SplitterDistance = 250;
            this.splitSummary.TabIndex = 0;
            // 
            // grdSumm
            // 
            grdSumm_DesignTimeLayout.LayoutString = resources.GetString("grdSumm_DesignTimeLayout.LayoutString");
            this.grdSumm.DesignTimeLayout = grdSumm_DesignTimeLayout;
            this.grdSumm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSumm.ExportFileID = null;
            this.grdSumm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdSumm.Location = new System.Drawing.Point(0, 0);
            this.grdSumm.Name = "grdSumm";
            this.grdSumm.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdSumm.Size = new System.Drawing.Size(973, 250);
            this.grdSumm.TabIndex = 1;
            this.grdSumm.SelectionChanged += new System.EventHandler(this.grdSumm_SelectionChanged);
            // 
            // grdDetail
            // 
            grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString");
            this.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.ExportFileID = null;
            this.grdDetail.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.None;
            this.grdDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDetail.GroupByBoxVisible = false;
            this.grdDetail.GroupTotals = Janus.Windows.GridEX.GroupTotals.Always;
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdDetail.Size = new System.Drawing.Size(973, 113);
            this.grdDetail.TabIndex = 1;
            this.grdDetail.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            // 
            // frmEDIQuery
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 581);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tbrMain);
            this.KeyPreview = true;
            this.Name = "frmEDIQuery";
            this.Text = "ITV Queries";
            this.Load += new System.EventHandler(this.frmEDIQuery_Load);
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.ucGroupBox1.ResumeLayout(false);
            this.ucGroupBox1.PerformLayout();
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            this.grpBox2.ResumeLayout(false);
            this.grpBox2.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.Summary.ResumeLayout(false);
            this.splitSummary.Panel1.ResumeLayout(false);
            this.splitSummary.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSummary)).EndInit();
            this.splitSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSumm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbClear;
		private CS2010.CommonWinCtrls.ucTextBox txtSerialNo;
		private CS2010.CommonWinCtrls.ucGridEx grdList;
		private CS2010.CommonWinCtrls.ucButton btnSave;
		private CS2010.CommonWinCtrls.ucButton btnSearch;
		private CS2010.CommonWinCtrls.ucTextBox txtActivityCd;
		private CS2010.CommonWinCtrls.ucCheckBox cbxUnsent;
		private CS2010.CommonWinCtrls.ucTextBox txtPCFN;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPOL;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPOD;
		private CS2010.CommonWinCtrls.ucTextBox txtISAnbr;
		private CS2010.CommonWinCtrls.ucDateGroupBoxMMddyy dateActivityRange;
		private CS2010.CommonWinCtrls.ucCheckBox cbxDRAP;
		private CS2010.CommonWinCtrls.ucGroupBox ucGroupBox1;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnApply;
		private CS2010.CommonWinCtrls.ucTextBox txtNotes;
		private CS2010.CommonWinCtrls.ucButton btnClear;
		private CS2010.CommonWinCtrls.ucCheckBox cbxLate;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tpList;
		private System.Windows.Forms.TabPage Summary;
		private System.Windows.Forms.SplitContainer splitSummary;
		private CS2010.CommonWinCtrls.ucGridEx grdSumm;
		private CS2010.CommonWinCtrls.ucGridEx grdDetail;
		private System.Windows.Forms.GroupBox grpBox2;
		private System.Windows.Forms.GroupBox grpBox1;
		private CS2010.CommonWinCtrls.ucTextBox txtBooking;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyage;
	}
}