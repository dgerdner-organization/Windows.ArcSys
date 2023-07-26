namespace CS2010.ArcSys.Win
{
	partial class frmPortTypeUpdate
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
			Janus.Windows.GridEX.GridEXLayout cmbVoyage_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortTypeUpdate));
			Janus.Windows.GridEX.GridEXLayout cmbPortType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdAudit_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grpBox1 = new System.Windows.Forms.GroupBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.btnUpdate = new CS2010.CommonWinCtrls.ucButton();
			this.txtSeqNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtID = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbVoyage = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cmbPortType = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grdAudit = new CS2010.CommonWinCtrls.ucGridEx();
			this.grpBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVoyage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPortType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
			this.SuspendLayout();
			// 
			// grpBox1
			// 
			this.grpBox1.Controls.Add(this.ucLabel1);
			this.grpBox1.Controls.Add(this.btnUpdate);
			this.grpBox1.Controls.Add(this.txtSeqNo);
			this.grpBox1.Controls.Add(this.txtID);
			this.grpBox1.Controls.Add(this.cmbVoyage);
			this.grpBox1.Controls.Add(this.cmbPortType);
			this.grpBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpBox1.Location = new System.Drawing.Point(0, 0);
			this.grpBox1.Name = "grpBox1";
			this.grpBox1.Size = new System.Drawing.Size(733, 147);
			this.grpBox1.TabIndex = 0;
			this.grpBox1.TabStop = false;
			this.grpBox1.Text = "Port to Update";
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(0, 133);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(160, 13);
			this.ucLabel1.TabIndex = 14;
			this.ucLabel1.Text = "Audit Trail of Port Type Changes";
			// 
			// btnUpdate
			// 
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Location = new System.Drawing.Point(170, 73);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(118, 23);
			this.btnUpdate.TabIndex = 13;
			this.btnUpdate.Text = "Update to \'Both\'";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// txtSeqNo
			// 
			this.txtSeqNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtSeqNo.Enabled = false;
			this.txtSeqNo.ForeColor = System.Drawing.Color.Black;
			this.txtSeqNo.LinkDisabledMessage = "Link Disabled";
			this.txtSeqNo.Location = new System.Drawing.Point(114, 74);
			this.txtSeqNo.Name = "txtSeqNo";
			this.txtSeqNo.ReadOnly = true;
			this.txtSeqNo.Size = new System.Drawing.Size(38, 20);
			this.txtSeqNo.TabIndex = 12;
			this.txtSeqNo.TabStop = false;
			// 
			// txtID
			// 
			this.txtID.BackColor = System.Drawing.SystemColors.Control;
			this.txtID.Enabled = false;
			this.txtID.ForeColor = System.Drawing.Color.Black;
			this.txtID.LinkDisabledMessage = "Link Disabled";
			this.txtID.Location = new System.Drawing.Point(69, 74);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(38, 20);
			this.txtID.TabIndex = 11;
			this.txtID.TabStop = false;
			// 
			// cmbVoyage
			// 
			this.cmbVoyage.CodeColumn = "Code";
			this.cmbVoyage.DescriptionColumn = "Description";
			cmbVoyage_DesignTimeLayout.LayoutString = resources.GetString("cmbVoyage_DesignTimeLayout.LayoutString");
			this.cmbVoyage.DesignTimeLayout = cmbVoyage_DesignTimeLayout;
			this.cmbVoyage.DisplayMember = "Description";
			this.cmbVoyage.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbVoyage.LabelText = "Voyage";
			this.cmbVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbVoyage.Location = new System.Drawing.Point(69, 20);
			this.cmbVoyage.Name = "cmbVoyage";
			this.cmbVoyage.SelectedIndex = -1;
			this.cmbVoyage.SelectedItem = null;
			this.cmbVoyage.Size = new System.Drawing.Size(83, 20);
			this.cmbVoyage.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbVoyage.TabIndex = 1;
			this.cmbVoyage.ValueColumn = "Code";
			this.cmbVoyage.ValueMember = "Code";
			this.cmbVoyage.ValueChanged += new System.EventHandler(this.cmbVoyages_ValueChanged);
			// 
			// cmbPortType
			// 
			this.cmbPortType.CodeColumn = "SeqNo";
			this.cmbPortType.DataMember = "SeqNo";
			this.cmbPortType.DescriptionColumn = "Description";
			cmbPortType_DesignTimeLayout.LayoutString = resources.GetString("cmbPortType_DesignTimeLayout.LayoutString");
			this.cmbPortType.DesignTimeLayout = cmbPortType_DesignTimeLayout;
			this.cmbPortType.DisplayMember = "Description";
			this.cmbPortType.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPortType.LabelText = "Port";
			this.cmbPortType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPortType.Location = new System.Drawing.Point(69, 47);
			this.cmbPortType.Name = "cmbPortType";
			this.cmbPortType.SelectedIndex = -1;
			this.cmbPortType.SelectedItem = null;
			this.cmbPortType.Size = new System.Drawing.Size(237, 20);
			this.cmbPortType.TabIndex = 10;
			this.cmbPortType.ValueColumn = "SeqNO";
			this.cmbPortType.ValueMember = "SeqNO";
			this.cmbPortType.ValueChanged += new System.EventHandler(this.cmbPortType_ValueChanged);
			// 
			// grdAudit
			// 
			grdAudit_DesignTimeLayout.LayoutString = resources.GetString("grdAudit_DesignTimeLayout.LayoutString");
			this.grdAudit.DesignTimeLayout = grdAudit_DesignTimeLayout;
			this.grdAudit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAudit.ExportFileID = null;
			this.grdAudit.GroupByBoxVisible = false;
			this.grdAudit.Location = new System.Drawing.Point(0, 147);
			this.grdAudit.Name = "grdAudit";
			this.grdAudit.Size = new System.Drawing.Size(733, 419);
			this.grdAudit.TabIndex = 2;
			// 
			// frmPortTypeUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 566);
			this.Controls.Add(this.grdAudit);
			this.Controls.Add(this.grpBox1);
			this.Name = "frmPortTypeUpdate";
			this.Text = "Update Port Type";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPortTypeUpdate_FormClosed);
			this.grpBox1.ResumeLayout(false);
			this.grpBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbVoyage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPortType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpBox1;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbPortType;
		private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbVoyage;
		private CS2010.CommonWinCtrls.ucTextBox txtSeqNo;
		private CS2010.CommonWinCtrls.ucTextBox txtID;
		private CS2010.CommonWinCtrls.ucButton btnUpdate;
		private CS2010.CommonWinCtrls.ucGridEx grdAudit;
		private CS2010.CommonWinCtrls.ucLabel ucLabel1;
	}
}