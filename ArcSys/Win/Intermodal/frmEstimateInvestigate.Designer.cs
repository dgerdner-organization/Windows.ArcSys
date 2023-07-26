namespace CS2010.ArcSys.Win
{
    partial class frmEstimateInvestigate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstimateInvestigate));
            this.ucProgressBar1 = new CS2010.CommonWinCtrls.ucProgressBar();
            this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
            this.rbOutbound = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbInbound = new CS2010.CommonWinCtrls.ucRadioButton();
            this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.grdDetail = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnUpdateSailDt = new CS2010.CommonWinCtrls.ucButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ucProgressBar1
            // 
            this.ucProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucProgressBar1.Location = new System.Drawing.Point(0, 473);
            this.ucProgressBar1.Name = "ucProgressBar1";
            this.ucProgressBar1.Size = new System.Drawing.Size(782, 23);
            this.ucProgressBar1.TabIndex = 2;
            this.ucProgressBar1.Visible = false;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.btnUpdateSailDt);
            this.splitMain.Panel1.Controls.Add(this.rbOutbound);
            this.splitMain.Panel1.Controls.Add(this.rbInbound);
            this.splitMain.Panel1.Controls.Add(this.btnSearch);
            this.splitMain.Panel1.Controls.Add(this.txtBookingNo);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grdDetail);
            this.splitMain.Size = new System.Drawing.Size(782, 473);
            this.splitMain.SplitterDistance = 103;
            this.splitMain.TabIndex = 3;
            // 
            // rbOutbound
            // 
            this.rbOutbound.Location = new System.Drawing.Point(75, 60);
            this.rbOutbound.Name = "rbOutbound";
            this.rbOutbound.Size = new System.Drawing.Size(104, 24);
            this.rbOutbound.TabIndex = 3;
            this.rbOutbound.Text = "Outbound Leg";
            this.rbOutbound.UseVisualStyleBackColor = true;
            // 
            // rbInbound
            // 
            this.rbInbound.Checked = true;
            this.rbInbound.Location = new System.Drawing.Point(75, 41);
            this.rbInbound.Name = "rbInbound";
            this.rbInbound.Size = new System.Drawing.Size(104, 24);
            this.rbInbound.TabIndex = 2;
            this.rbInbound.TabStop = true;
            this.rbInbound.Text = "Inbound Leg";
            this.rbInbound.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(195, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(75, 14);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 20);
            this.txtBookingNo.TabIndex = 0;
            // 
            // grdDetail
            // 
            grdDetail_DesignTimeLayout.LayoutString = resources.GetString("grdDetail_DesignTimeLayout.LayoutString");
            this.grdDetail.DesignTimeLayout = grdDetail_DesignTimeLayout;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.ExportFileID = null;
            this.grdDetail.Location = new System.Drawing.Point(0, 0);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdDetail.Size = new System.Drawing.Size(782, 366);
            this.grdDetail.TabIndex = 0;
            // 
            // btnUpdateSailDt
            // 
            this.btnUpdateSailDt.Location = new System.Drawing.Point(425, 11);
            this.btnUpdateSailDt.Name = "btnUpdateSailDt";
            this.btnUpdateSailDt.Size = new System.Drawing.Size(101, 23);
            this.btnUpdateSailDt.TabIndex = 4;
            this.btnUpdateSailDt.Text = "Update Sail Date";
            this.btnUpdateSailDt.UseVisualStyleBackColor = true;
            this.btnUpdateSailDt.Click += new System.EventHandler(this.btnUpdateSailDt_Click);
            // 
            // frmEstimateInvestigate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.ucProgressBar1);
            this.Name = "frmEstimateInvestigate";
            this.Text = "Estimate Investigate";
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private CommonWinCtrls.ucProgressBar ucProgressBar1;
		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucRadioButton rbInbound;
		private CommonWinCtrls.ucRadioButton rbOutbound;
		private CommonWinCtrls.ucGridEx grdDetail;
        private CommonWinCtrls.ucButton btnUpdateSailDt;

    }
}