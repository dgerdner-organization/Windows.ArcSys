namespace CS2010.ArcSys.Win
{
    partial class frmLINECharges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLINECharges));
            Janus.Windows.GridEX.GridEXLayout grdLINECharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdIntermodalCharges_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.miniToolStrip = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdLINECharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.label2 = new System.Windows.Forms.Label();
            this.grdIntermodalCharges = new CS2010.CommonWinCtrls.ucGridEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVesselCd = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtElapsedTime = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtLINEStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtARStatus = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOD = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPOL = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPLOR = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sbrChild.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLINECharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermodalCharges)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 551);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(828, 22);
            this.sbrChild.TabIndex = 5;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
            this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GridObject = null;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.HideAddButton = true;
            this.miniToolStrip.HideDeleteButton = true;
            this.miniToolStrip.HideEditButton = true;
            this.miniToolStrip.Location = new System.Drawing.Point(109, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(782, 25);
            this.miniToolStrip.TabIndex = 1;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.toolStripSeparator2});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(828, 25);
            this.tsMenu.TabIndex = 7;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(44, 22);
            this.tsbSearch.Text = "&Search";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(49, 22);
            this.tsbRefresh.Text = "&Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grdLINECharges, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.grdIntermodalCharges, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 548);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // grdLINECharges
            // 
            this.grdLINECharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdLINECharges_DesignTimeLayout.LayoutString = resources.GetString("grdLINECharges_DesignTimeLayout.LayoutString");
            this.grdLINECharges.DesignTimeLayout = grdLINECharges_DesignTimeLayout;
            this.grdLINECharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLINECharges.ExportFileID = null;
            this.grdLINECharges.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdLINECharges.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdLINECharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdLINECharges.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdLINECharges.Location = new System.Drawing.Point(3, 337);
            this.grdLINECharges.Name = "grdLINECharges";
            this.grdLINECharges.Size = new System.Drawing.Size(822, 208);
            this.grdLINECharges.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(822, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "LINE Charges";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdIntermodalCharges
            // 
            this.grdIntermodalCharges.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdIntermodalCharges_DesignTimeLayout.LayoutString = resources.GetString("grdIntermodalCharges_DesignTimeLayout.LayoutString");
            this.grdIntermodalCharges.DesignTimeLayout = grdIntermodalCharges_DesignTimeLayout;
            this.grdIntermodalCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIntermodalCharges.ExportFileID = null;
            this.grdIntermodalCharges.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdIntermodalCharges.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdIntermodalCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdIntermodalCharges.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdIntermodalCharges.Location = new System.Drawing.Point(3, 103);
            this.grdIntermodalCharges.Name = "grdIntermodalCharges";
            this.grdIntermodalCharges.Size = new System.Drawing.Size(822, 208);
            this.grdIntermodalCharges.TabIndex = 14;
            this.grdIntermodalCharges.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVoyageNo);
            this.panel1.Controls.Add(this.txtVesselCd);
            this.panel1.Controls.Add(this.txtElapsedTime);
            this.panel1.Controls.Add(this.txtLINEStatus);
            this.panel1.Controls.Add(this.txtARStatus);
            this.panel1.Controls.Add(this.txtPLOD);
            this.panel1.Controls.Add(this.txtPOD);
            this.panel1.Controls.Add(this.txtPOL);
            this.panel1.Controls.Add(this.txtPLOR);
            this.panel1.Controls.Add(this.txtBookingNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 74);
            this.panel1.TabIndex = 11;
            // 
            // txtVoyageNo
            // 
            this.txtVoyageNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtVoyageNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVoyageNo.LabelText = "Voyage #:";
            this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
            this.txtVoyageNo.Location = new System.Drawing.Point(74, 54);
            this.txtVoyageNo.Name = "txtVoyageNo";
            this.txtVoyageNo.Size = new System.Drawing.Size(100, 13);
            this.txtVoyageNo.TabIndex = 9;
            // 
            // txtVesselCd
            // 
            this.txtVesselCd.BackColor = System.Drawing.SystemColors.Control;
            this.txtVesselCd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVesselCd.LabelText = "Vessel:";
            this.txtVesselCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVesselCd.LinkDisabledMessage = "Link Disabled";
            this.txtVesselCd.Location = new System.Drawing.Point(74, 29);
            this.txtVesselCd.Name = "txtVesselCd";
            this.txtVesselCd.Size = new System.Drawing.Size(100, 13);
            this.txtVesselCd.TabIndex = 8;
            // 
            // txtElapsedTime
            // 
            this.txtElapsedTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElapsedTime.BackColor = System.Drawing.SystemColors.Control;
            this.txtElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtElapsedTime.LabelText = "Search Time:";
            this.txtElapsedTime.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtElapsedTime.LinkDisabledMessage = "Link Disabled";
            this.txtElapsedTime.Location = new System.Drawing.Point(694, 58);
            this.txtElapsedTime.Name = "txtElapsedTime";
            this.txtElapsedTime.Size = new System.Drawing.Size(120, 13);
            this.txtElapsedTime.TabIndex = 7;
            // 
            // txtLINEStatus
            // 
            this.txtLINEStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtLINEStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLINEStatus.LabelText = "LINE Status:";
            this.txtLINEStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLINEStatus.LinkDisabledMessage = "Link Disabled";
            this.txtLINEStatus.Location = new System.Drawing.Point(646, 29);
            this.txtLINEStatus.Name = "txtLINEStatus";
            this.txtLINEStatus.Size = new System.Drawing.Size(100, 13);
            this.txtLINEStatus.TabIndex = 6;
            this.txtLINEStatus.Visible = false;
            // 
            // txtARStatus
            // 
            this.txtARStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtARStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtARStatus.LabelText = "AR Status:";
            this.txtARStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtARStatus.LinkDisabledMessage = "Link Disabled";
            this.txtARStatus.Location = new System.Drawing.Point(646, 3);
            this.txtARStatus.Name = "txtARStatus";
            this.txtARStatus.Size = new System.Drawing.Size(100, 13);
            this.txtARStatus.TabIndex = 5;
            this.txtARStatus.Visible = false;
            // 
            // txtPLOD
            // 
            this.txtPLOD.BackColor = System.Drawing.SystemColors.Control;
            this.txtPLOD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPLOD.LabelText = "PLOD:";
            this.txtPLOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOD.LinkDisabledMessage = "Link Disabled";
            this.txtPLOD.Location = new System.Drawing.Point(367, 29);
            this.txtPLOD.Name = "txtPLOD";
            this.txtPLOD.Size = new System.Drawing.Size(100, 13);
            this.txtPLOD.TabIndex = 4;
            // 
            // txtPOD
            // 
            this.txtPOD.BackColor = System.Drawing.SystemColors.Control;
            this.txtPOD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPOD.LabelText = "POD:";
            this.txtPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOD.LinkDisabledMessage = "Link Disabled";
            this.txtPOD.Location = new System.Drawing.Point(367, 3);
            this.txtPOD.Name = "txtPOD";
            this.txtPOD.Size = new System.Drawing.Size(100, 13);
            this.txtPOD.TabIndex = 3;
            // 
            // txtPOL
            // 
            this.txtPOL.BackColor = System.Drawing.SystemColors.Control;
            this.txtPOL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPOL.LabelText = "POL:";
            this.txtPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPOL.LinkDisabledMessage = "Link Disabled";
            this.txtPOL.Location = new System.Drawing.Point(225, 29);
            this.txtPOL.Name = "txtPOL";
            this.txtPOL.Size = new System.Drawing.Size(100, 13);
            this.txtPOL.TabIndex = 2;
            // 
            // txtPLOR
            // 
            this.txtPLOR.BackColor = System.Drawing.SystemColors.Control;
            this.txtPLOR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPLOR.LabelText = "PLOR:";
            this.txtPLOR.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPLOR.LinkDisabledMessage = "Link Disabled";
            this.txtPLOR.Location = new System.Drawing.Point(225, 3);
            this.txtPLOR.Name = "txtPLOR";
            this.txtPLOR.Size = new System.Drawing.Size(100, 13);
            this.txtPLOR.TabIndex = 1;
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookingNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBookingNo.LabelText = "Booking #:";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(74, 3);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(100, 13);
            this.txtBookingNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "INTERMODAL Charges";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmLINECharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 573);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.sbrChild);
            this.Name = "frmLINECharges";
            this.Text = "LINE Charges";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLINECharges_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLINECharges_FormClosed);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLINECharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntermodalCharges)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sbrChild;
        private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
        private CommonWinCtrls.ucGridToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CommonWinCtrls.ucTextBox txtBookingNo;
        private CommonWinCtrls.ucTextBox txtLINEStatus;
        private CommonWinCtrls.ucTextBox txtARStatus;
        private CommonWinCtrls.ucTextBox txtPLOD;
        private CommonWinCtrls.ucTextBox txtPOD;
        private CommonWinCtrls.ucTextBox txtPOL;
        private CommonWinCtrls.ucTextBox txtPLOR;
        private CommonWinCtrls.ucTextBox txtElapsedTime;
        private System.Windows.Forms.Label label2;
        private CommonWinCtrls.ucGridEx grdIntermodalCharges;
        private System.Windows.Forms.Label label1;
        private CommonWinCtrls.ucGridEx grdLINECharges;
        private CommonWinCtrls.ucTextBox txtVoyageNo;
        private CommonWinCtrls.ucTextBox txtVesselCd;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

    }
}