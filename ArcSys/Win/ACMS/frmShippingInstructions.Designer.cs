namespace CS2010.ArcSys.Win
{
	partial class frmShippingInstructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShippingInstructions));
            Janus.Windows.GridEX.GridEXLayout grd304Queue_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.pnlSearch = new CS2010.CommonWinCtrls.ucPanel();
            this.btnNoSend = new CS2010.CommonWinCtrls.ucButton();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyage = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.sbrStrip = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.grd304Queue = new CS2010.CommonWinCtrls.ucGridEx();
            this.pnlQueueTitle = new CS2010.CommonWinCtrls.ucPanel();
            this.cbxAll = new CS2010.CommonWinCtrls.ucCheckBox();
            this.btnResend = new CS2010.CommonWinCtrls.ucButton();
            this.btnCancelXmit = new CS2010.CommonWinCtrls.ucButton();
            this.lblQueueTitle = new CS2010.CommonWinCtrls.ucLabel();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.sbrStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd304Queue)).BeginInit();
            this.pnlQueueTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnNoSend);
            this.pnlSearch.Controls.Add(this.txtBookingNo);
            this.pnlSearch.Controls.Add(this.txtPCFN);
            this.pnlSearch.Controls.Add(this.txtVoyage);
            this.pnlSearch.Controls.Add(this.btnSend);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(891, 52);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnNoSend
            // 
            this.btnNoSend.Location = new System.Drawing.Point(774, 10);
            this.btnNoSend.Name = "btnNoSend";
            this.btnNoSend.Size = new System.Drawing.Size(96, 23);
            this.btnNoSend.TabIndex = 5;
            this.btnNoSend.Text = "Do Not Send";
            this.btnNoSend.UseVisualStyleBackColor = true;
            this.btnNoSend.Click += new System.EventHandler(this.btnNoSend_Click);
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(351, 13);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(87, 20);
            this.txtBookingNo.TabIndex = 4;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(202, 13);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(87, 20);
            this.txtPCFN.TabIndex = 3;
            // 
            // txtVoyage
            // 
            this.txtVoyage.LabelText = "Voyage";
            this.txtVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyage.LinkDisabledMessage = "Link Disabled";
            this.txtVoyage.Location = new System.Drawing.Point(62, 13);
            this.txtVoyage.Name = "txtVoyage";
            this.txtVoyage.Size = new System.Drawing.Size(87, 20);
            this.txtVoyage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(602, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send 304s";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(521, 10);
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
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.Name = "grdMain";
            this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMain.Size = new System.Drawing.Size(891, 211);
            this.grdMain.TabIndex = 1;
            this.grdMain.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdMain_RowCheckStateChanged);
            this.grdMain.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_LinkClicked);
            // 
            // sbrStrip
            // 
            this.sbrStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrStrip.Location = new System.Drawing.Point(0, 474);
            this.sbrStrip.Name = "sbrStrip";
            this.sbrStrip.Size = new System.Drawing.Size(891, 22);
            this.sbrStrip.TabIndex = 2;
            this.sbrStrip.Text = "statusStrip1";
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(227, 17);
            this.sbbProgressCaption.Text = "Processing... (Click here to cancel the search)";
            this.sbbProgressCaption.Visible = false;
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.sbbProgressMeter.Visible = false;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 52);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.grdMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grd304Queue);
            this.splitMain.Panel2.Controls.Add(this.pnlQueueTitle);
            this.splitMain.Size = new System.Drawing.Size(891, 422);
            this.splitMain.SplitterDistance = 211;
            this.splitMain.TabIndex = 3;
            // 
            // grd304Queue
            // 
            grd304Queue_DesignTimeLayout.LayoutString = resources.GetString("grd304Queue_DesignTimeLayout.LayoutString");
            this.grd304Queue.DesignTimeLayout = grd304Queue_DesignTimeLayout;
            this.grd304Queue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd304Queue.ExportFileID = null;
            this.grd304Queue.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grd304Queue.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grd304Queue.GroupByBoxVisible = false;
            this.grd304Queue.Location = new System.Drawing.Point(0, 35);
            this.grd304Queue.Name = "grd304Queue";
            this.grd304Queue.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grd304Queue.Size = new System.Drawing.Size(891, 172);
            this.grd304Queue.TabIndex = 1;
            // 
            // pnlQueueTitle
            // 
            this.pnlQueueTitle.Controls.Add(this.cbxAll);
            this.pnlQueueTitle.Controls.Add(this.btnResend);
            this.pnlQueueTitle.Controls.Add(this.btnCancelXmit);
            this.pnlQueueTitle.Controls.Add(this.lblQueueTitle);
            this.pnlQueueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueueTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlQueueTitle.Name = "pnlQueueTitle";
            this.pnlQueueTitle.Size = new System.Drawing.Size(891, 35);
            this.pnlQueueTitle.TabIndex = 0;
            // 
            // cbxAll
            // 
            this.cbxAll.Location = new System.Drawing.Point(202, 5);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(104, 24);
            this.cbxAll.TabIndex = 3;
            this.cbxAll.Text = "Show All";
            this.cbxAll.UseVisualStyleBackColor = true;
            this.cbxAll.YN = "N";
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // btnResend
            // 
            this.btnResend.Enabled = false;
            this.btnResend.Location = new System.Drawing.Point(427, 2);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(103, 23);
            this.btnResend.TabIndex = 2;
            this.btnResend.Text = "Resend";
            this.btnResend.UseVisualStyleBackColor = true;
            this.btnResend.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // btnCancelXmit
            // 
            this.btnCancelXmit.Enabled = false;
            this.btnCancelXmit.Location = new System.Drawing.Point(312, 2);
            this.btnCancelXmit.Name = "btnCancelXmit";
            this.btnCancelXmit.Size = new System.Drawing.Size(109, 23);
            this.btnCancelXmit.TabIndex = 1;
            this.btnCancelXmit.Text = "Cancel Transmit";
            this.btnCancelXmit.UseVisualStyleBackColor = true;
            this.btnCancelXmit.Click += new System.EventHandler(this.btnCancelXmit_Click);
            // 
            // lblQueueTitle
            // 
            this.lblQueueTitle.Location = new System.Drawing.Point(8, 10);
            this.lblQueueTitle.Name = "lblQueueTitle";
            this.lblQueueTitle.Size = new System.Drawing.Size(172, 13);
            this.lblQueueTitle.TabIndex = 0;
            this.lblQueueTitle.Text = "Current Shipping Instruction Queue";
            // 
            // frmShippingInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(891, 496);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.sbrStrip);
            this.Controls.Add(this.pnlSearch);
            this.Name = "frmShippingInstructions";
            this.Text = "Shipping Instructions";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.sbrStrip.ResumeLayout(false);
            this.sbrStrip.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd304Queue)).EndInit();
            this.pnlQueueTitle.ResumeLayout(false);
            this.pnlQueueTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucPanel pnlSearch;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucGridEx grdMain;
		private System.Windows.Forms.StatusStrip sbrStrip;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.Button btnSend;
		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucGridEx grd304Queue;
		private CommonWinCtrls.ucPanel pnlQueueTitle;
		private CommonWinCtrls.ucLabel lblQueueTitle;
		private CommonWinCtrls.ucButton btnCancelXmit;
		private CommonWinCtrls.ucButton btnResend;
		private CommonWinCtrls.ucCheckBox cbxAll;
		private CommonWinCtrls.ucTextBox txtVoyage;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucButton btnNoSend;
	}
}
