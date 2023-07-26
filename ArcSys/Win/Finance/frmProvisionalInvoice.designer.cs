namespace CS2010.ArcSys.Win
{
	partial class frmProvisionalInvoice
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProvisionalInvoice));
			Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout4 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClear = new System.Windows.Forms.ToolStripButton();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.cmbPLOD = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cmbPOD = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbPOL = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cmbCargoStatus = new System.Windows.Forms.ComboBox();
			this.cmbPLOR = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grpPOLDate = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
			this.tbrMain.SuspendLayout();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
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
			this.tbrMain.Size = new System.Drawing.Size(846, 25);
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
			this.pnlMain.Panel1.Controls.Add(this.txtPCFN);
			this.pnlMain.Panel1.Controls.Add(this.cmbPLOD);
			this.pnlMain.Panel1.Controls.Add(this.cmbPOD);
			this.pnlMain.Panel1.Controls.Add(this.label1);
			this.pnlMain.Panel1.Controls.Add(this.cmbPOL);
			this.pnlMain.Panel1.Controls.Add(this.cmbCargoStatus);
			this.pnlMain.Panel1.Controls.Add(this.cmbPLOR);
			this.pnlMain.Panel1.Controls.Add(this.grpPOLDate);
			this.pnlMain.Panel1.Controls.Add(this.txtVoyage);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.grdResults);
			this.pnlMain.Size = new System.Drawing.Size(846, 556);
			this.pnlMain.SplitterDistance = 131;
			this.pnlMain.TabIndex = 0;
			// 
			// cmbPLOD
			// 
			this.cmbPLOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPLOD.CodeColumn = "location_cd";
			this.cmbPLOD.DataMember = "location_dsc";
			this.cmbPLOD.DescriptionColumn = "location_dsc";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbPLOD.DesignTimeLayout = gridEXLayout1;
			this.cmbPLOD.DisplayMember = "location_cd";
			this.cmbPLOD.LabelText = "PLOD";
			this.cmbPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPLOD.Location = new System.Drawing.Point(398, 79);
			this.cmbPLOD.Name = "cmbPLOD";
			this.cmbPLOD.SaveSettings = false;
			this.cmbPLOD.SelectedIndex = -1;
			this.cmbPLOD.SelectedItem = null;
			this.cmbPLOD.Size = new System.Drawing.Size(91, 20);
			this.cmbPLOD.TabIndex = 7;
			this.cmbPLOD.ValueColumn = "location_cd";
			this.cmbPLOD.ValueMember = "location_cd";
			// 
			// cmbPOD
			// 
			this.cmbPOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOD.CodeColumn = "location_cd";
			this.cmbPOD.DataMember = "location_dsc";
			this.cmbPOD.DescriptionColumn = "location_dsc";
			gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
			this.cmbPOD.DesignTimeLayout = gridEXLayout2;
			this.cmbPOD.DisplayMember = "location_cd";
			this.cmbPOD.LabelText = "POD";
			this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOD.Location = new System.Drawing.Point(398, 56);
			this.cmbPOD.Name = "cmbPOD";
			this.cmbPOD.SaveSettings = false;
			this.cmbPOD.SelectedIndex = -1;
			this.cmbPOD.SelectedItem = null;
			this.cmbPOD.Size = new System.Drawing.Size(91, 20);
			this.cmbPOD.TabIndex = 6;
			this.cmbPOD.ValueColumn = "location_cd";
			this.cmbPOD.ValueMember = "location_cd";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(170, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Cargo Status";
			// 
			// cmbPOL
			// 
			this.cmbPOL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPOL.CodeColumn = "location_cd";
			this.cmbPOL.DataMember = "location_dsc";
			this.cmbPOL.DescriptionColumn = "location_dsc";
			gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
			this.cmbPOL.DesignTimeLayout = gridEXLayout3;
			this.cmbPOL.DisplayMember = "location_cd";
			this.cmbPOL.LabelText = "POL";
			this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOL.Location = new System.Drawing.Point(398, 33);
			this.cmbPOL.Name = "cmbPOL";
			this.cmbPOL.SaveSettings = false;
			this.cmbPOL.SelectedIndex = -1;
			this.cmbPOL.SelectedItem = null;
			this.cmbPOL.Size = new System.Drawing.Size(91, 20);
			this.cmbPOL.TabIndex = 5;
			this.cmbPOL.ValueColumn = "location_cd";
			this.cmbPOL.ValueMember = "location_cd";
			// 
			// cmbCargoStatus
			// 
			this.cmbCargoStatus.FormattingEnabled = true;
			this.cmbCargoStatus.Items.AddRange(new object[] {
            "All",
            "RCVD"});
			this.cmbCargoStatus.Location = new System.Drawing.Point(240, 33);
			this.cmbCargoStatus.Name = "cmbCargoStatus";
			this.cmbCargoStatus.Size = new System.Drawing.Size(91, 21);
			this.cmbCargoStatus.TabIndex = 2;
			// 
			// cmbPLOR
			// 
			this.cmbPLOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPLOR.CodeColumn = "location_cd";
			this.cmbPLOR.DataMember = "location_dsc";
			this.cmbPLOR.DescriptionColumn = "location_dsc";
			gridEXLayout4.LayoutString = resources.GetString("gridEXLayout4.LayoutString");
			this.cmbPLOR.DesignTimeLayout = gridEXLayout4;
			this.cmbPLOR.DisplayMember = "location_cd";
			this.cmbPLOR.LabelText = "PLOR";
			this.cmbPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPLOR.Location = new System.Drawing.Point(398, 10);
			this.cmbPLOR.Name = "cmbPLOR";
			this.cmbPLOR.SaveSettings = false;
			this.cmbPLOR.SelectedIndex = -1;
			this.cmbPLOR.SelectedItem = null;
			this.cmbPLOR.Size = new System.Drawing.Size(91, 20);
			this.cmbPLOR.TabIndex = 4;
			this.cmbPLOR.ValueColumn = "location_cd";
			this.cmbPLOR.ValueMember = "location_cd";
			// 
			// grpPOLDate
			// 
			this.grpPOLDate.CheckBoxText = "POL Date (yymmdd)";
			this.grpPOLDate.GroupBoxText = "POL Date (yymmdd)";
			this.grpPOLDate.Location = new System.Drawing.Point(35, 12);
			this.grpPOLDate.Name = "grpPOLDate";
			this.grpPOLDate.Size = new System.Drawing.Size(129, 76);
			this.grpPOLDate.TabIndex = 0;
			this.grpPOLDate.ValueRange = ((CS2010.Common.DateRange)(new CS2010.Common.DateRange(null, null)));
			// 
			// txtVoyage
			// 
			this.txtVoyage.LabelText = "Voyage";
			this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtVoyage.Location = new System.Drawing.Point(240, 10);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(91, 20);
			this.txtVoyage.TabIndex = 1;
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
			this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
			this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResults.ExportFileID = null;
			this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdResults.Location = new System.Drawing.Point(0, 0);
			this.grdResults.Name = "grdResults";
			this.grdResults.Size = new System.Drawing.Size(846, 421);
			this.grdResults.TabIndex = 0;
			this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
			// 
			// txtPCFN
			// 
			this.txtPCFN.LabelText = "PCFN";
			this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPCFN.LinkDisabledMessage = "Link Disabled";
			this.txtPCFN.Location = new System.Drawing.Point(240, 58);
			this.txtPCFN.Name = "txtPCFN";
			this.txtPCFN.Size = new System.Drawing.Size(91, 20);
			this.txtPCFN.TabIndex = 3;
			// 
			// frmProvisionalInvoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 581);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmProvisionalInvoice";
			this.Text = "ITV Summary by TCN";
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel1.PerformLayout();
			this.pnlMain.Panel2.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbPLOD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPLOR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tbbClear;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyage;
		private CS2010.CommonWinCtrls.ucGridEx grdResults;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpPOLDate;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPLOR;
		private System.Windows.Forms.ComboBox cmbCargoStatus;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPLOD;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPOD;
		private System.Windows.Forms.Label label1;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPOL;
		private CS2010.CommonWinCtrls.ucTextBox txtPCFN;
	}
}