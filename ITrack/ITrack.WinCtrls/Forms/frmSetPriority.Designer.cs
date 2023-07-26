namespace ASL.ITrack.WinCtrls
{
	partial class frmSetPriority
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetPriority));
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			this.chkDataFix = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtPriority = new CS2010.CommonWinCtrls.ucTextBox();
			this.dteDue = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.cmbReleaseDue = new ASL.ITrack.WinCtrls.ucReleaseCombo();
			this.chkEmergency = new CS2010.CommonWinCtrls.ucCheckBox();
			this.dteRequest = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.lblRel = new CS2010.CommonWinCtrls.ucLabel();
			this.grpFlags = new CS2010.CommonWinCtrls.ucGroupBox();
			this.lblReq = new CS2010.CommonWinCtrls.ucLabel();
			this.lblDue = new CS2010.CommonWinCtrls.ucLabel();
			this.lblFlags = new CS2010.CommonWinCtrls.ucLabel();
			this.lblPriority = new CS2010.CommonWinCtrls.ucLabel();
			this.lblInfo = new CS2010.CommonWinCtrls.ucLabel();
			((System.ComponentModel.ISupportInitialize)(this.cmbReleaseDue)).BeginInit();
			this.grpFlags.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(181, 216);
			this.btnOK.TabIndex = 10;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(262, 216);
			this.btnCancel.TabIndex = 11;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(343, 216);
			this.btnApply.TabIndex = 12;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// chkDataFix
			// 
			this.chkDataFix.AutoSize = true;
			this.chkDataFix.Location = new System.Drawing.Point(12, 16);
			this.chkDataFix.Name = "chkDataFix";
			this.chkDataFix.Size = new System.Drawing.Size(65, 17);
			this.chkDataFix.TabIndex = 0;
			this.chkDataFix.Text = "Data Fi&x";
			this.chkDataFix.UseVisualStyleBackColor = true;
			this.chkDataFix.YN = "N";
			this.chkDataFix.Enter += new System.EventHandler(this.Control_Enter);
			this.chkDataFix.CheckedChanged += new System.EventHandler(this.chkFix_CheckedChanged);
			// 
			// txtPriority
			// 
			this.txtPriority.BackColor = System.Drawing.SystemColors.Control;
			this.txtPriority.ForeColor = System.Drawing.Color.Black;
			this.txtPriority.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.txtPriority.LabelText = "Priority";
			this.txtPriority.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPriority.LinkDisabledMessage = "Link Disabled";
			this.txtPriority.Location = new System.Drawing.Point(16, 122);
			this.txtPriority.Name = "txtPriority";
			this.txtPriority.ReadOnly = true;
			this.txtPriority.Size = new System.Drawing.Size(320, 20);
			this.txtPriority.TabIndex = 8;
			this.txtPriority.TabStop = false;
			this.txtPriority.Enter += new System.EventHandler(this.Control_Enter);
			// 
			// dteDue
			// 
			this.dteDue.BackColor = System.Drawing.SystemColors.Control;
			this.dteDue.DefaultFormat = "yyyy-MM-dd";
			this.dteDue.EditFormat = "yyMMdd";
			this.dteDue.ForeColor = System.Drawing.Color.Black;
			this.dteDue.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.dteDue.LabelText = "Actual Release Date";
			this.dteDue.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteDue.LinkDisabledMessage = "Link Disabled";
			this.dteDue.Location = new System.Drawing.Point(236, 82);
			this.dteDue.MaxLength = 6;
			this.dteDue.Name = "dteDue";
			this.dteDue.ReadOnly = true;
			this.dteDue.Size = new System.Drawing.Size(100, 20);
			this.dteDue.TabIndex = 6;
			this.dteDue.TabStop = false;
			this.dteDue.Value = null;
			this.dteDue.Enter += new System.EventHandler(this.Control_Enter);
			// 
			// cmbReleaseDue
			// 
			this.cmbReleaseDue.CodeColumn = "Code";
			this.cmbReleaseDue.DescriptionColumn = "Description";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbReleaseDue.DesignTimeLayout = gridEXLayout1;
			this.cmbReleaseDue.DisplayMember = "Code";
			this.cmbReleaseDue.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.cmbReleaseDue.LabelText = "Release &Month";
			this.cmbReleaseDue.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbReleaseDue.Location = new System.Drawing.Point(122, 82);
			this.cmbReleaseDue.Name = "cmbReleaseDue";
			this.cmbReleaseDue.SaveSettings = false;
			this.cmbReleaseDue.SelectedIndex = -1;
			this.cmbReleaseDue.SelectedItem = null;
			this.cmbReleaseDue.ShowContextMenu = false;
			this.cmbReleaseDue.Size = new System.Drawing.Size(108, 20);
			this.cmbReleaseDue.StartingPoint = null;
			this.cmbReleaseDue.TabIndex = 4;
			this.cmbReleaseDue.ValueColumn = "Description";
			this.cmbReleaseDue.ValueMember = "Description";
			this.cmbReleaseDue.Validated += new System.EventHandler(this.cmbReleaseDue_Validated);
			this.cmbReleaseDue.ValueChanged += new System.EventHandler(this.cmbReleaseDue_ValueChanged);
			this.cmbReleaseDue.Enter += new System.EventHandler(this.Control_Enter);
			// 
			// chkEmergency
			// 
			this.chkEmergency.AutoSize = true;
			this.chkEmergency.Location = new System.Drawing.Point(100, 16);
			this.chkEmergency.Name = "chkEmergency";
			this.chkEmergency.Size = new System.Drawing.Size(79, 17);
			this.chkEmergency.TabIndex = 1;
			this.chkEmergency.Text = "&Emergency";
			this.chkEmergency.UseVisualStyleBackColor = true;
			this.chkEmergency.YN = "N";
			this.chkEmergency.Enter += new System.EventHandler(this.Control_Enter);
			this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmg_CheckedChanged);
			// 
			// dteRequest
			// 
			this.dteRequest.DefaultFormat = "yyyy-MM-dd";
			this.dteRequest.EditFormat = "yyMMdd";
			this.dteRequest.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
			this.dteRequest.LabelText = "Date &Requested";
			this.dteRequest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteRequest.LinkDisabledMessage = "Link Disabled";
			this.dteRequest.Location = new System.Drawing.Point(16, 82);
			this.dteRequest.MaxLength = 6;
			this.dteRequest.Name = "dteRequest";
			this.dteRequest.Size = new System.Drawing.Size(100, 20);
			this.dteRequest.TabIndex = 2;
			this.dteRequest.Value = null;
			this.dteRequest.Validating += new System.ComponentModel.CancelEventHandler(this.dteRequest_Validating);
			this.dteRequest.Validated += new System.EventHandler(this.dteRequest_Validated);
			this.dteRequest.Enter += new System.EventHandler(this.Control_Enter);
			// 
			// lblRel
			// 
			this.lblRel.AutoSize = false;
			this.lblRel.Location = new System.Drawing.Point(16, 327);
			this.lblRel.Name = "lblRel";
			this.lblRel.Size = new System.Drawing.Size(284, 56);
			this.lblRel.TabIndex = 0;
			this.lblRel.Text = resources.GetString("lblRel.Text");
			this.lblRel.Visible = false;
			// 
			// grpFlags
			// 
			this.grpFlags.Controls.Add(this.chkEmergency);
			this.grpFlags.Controls.Add(this.chkDataFix);
			this.grpFlags.Location = new System.Drawing.Point(16, 12);
			this.grpFlags.Name = "grpFlags";
			this.grpFlags.Size = new System.Drawing.Size(192, 40);
			this.grpFlags.TabIndex = 0;
			this.grpFlags.TabStop = false;
			this.grpFlags.Text = "&Priority Flags";
			// 
			// lblReq
			// 
			this.lblReq.AutoSize = false;
			this.lblReq.Location = new System.Drawing.Point(16, 271);
			this.lblReq.Name = "lblReq";
			this.lblReq.Size = new System.Drawing.Size(284, 56);
			this.lblReq.TabIndex = 0;
			this.lblReq.Text = "The date you would like the issue completed by. This is not the date that the iss" +
				"ue will actually be available or completed by, it is just used to indicate how s" +
				"oon the issue is needed.";
			this.lblReq.Visible = false;
			// 
			// lblDue
			// 
			this.lblDue.AutoSize = false;
			this.lblDue.Location = new System.Drawing.Point(16, 383);
			this.lblDue.Name = "lblDue";
			this.lblDue.Size = new System.Drawing.Size(284, 26);
			this.lblDue.TabIndex = 10;
			this.lblDue.Text = "The actual date that the release to production will occur. This will be the first" +
				" Monday of the release month.";
			this.lblDue.Visible = false;
			// 
			// lblFlags
			// 
			this.lblFlags.AutoSize = false;
			this.lblFlags.Location = new System.Drawing.Point(16, 243);
			this.lblFlags.Name = "lblFlags";
			this.lblFlags.Size = new System.Drawing.Size(284, 28);
			this.lblFlags.TabIndex = 0;
			this.lblFlags.Text = "Data fixes and emergency issues are the highest priority issues and do not requir" +
				"e any dates to be specified below.";
			this.lblFlags.Visible = false;
			// 
			// lblPriority
			// 
			this.lblPriority.AutoSize = false;
			this.lblPriority.Location = new System.Drawing.Point(16, 409);
			this.lblPriority.Name = "lblPriority";
			this.lblPriority.Size = new System.Drawing.Size(284, 16);
			this.lblPriority.TabIndex = 0;
			this.lblPriority.Text = "This is computed from the data entered in the fields above.";
			this.lblPriority.Visible = false;
			// 
			// lblInfo
			// 
			this.lblInfo.AutoSize = false;
			this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblInfo.Location = new System.Drawing.Point(16, 152);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(320, 55);
			this.lblInfo.TabIndex = 9;
			this.lblInfo.Text = resources.GetString("lblInfo.Text");
			// 
			// frmSetPriority
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 252);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.lblPriority);
			this.Controls.Add(this.lblFlags);
			this.Controls.Add(this.lblDue);
			this.Controls.Add(this.grpFlags);
			this.Controls.Add(this.txtPriority);
			this.Controls.Add(this.cmbReleaseDue);
			this.Controls.Add(this.dteRequest);
			this.Controls.Add(this.lblReq);
			this.Controls.Add(this.dteDue);
			this.Controls.Add(this.lblRel);
			this.Name = "frmSetPriority";
			this.Tag = "Set Priority for Issue";
			this.Text = "Set Priority for Issue";
			this.Load += new System.EventHandler(this.frmSetPriority_Load);
			this.Controls.SetChildIndex(this.lblRel, 0);
			this.Controls.SetChildIndex(this.dteDue, 0);
			this.Controls.SetChildIndex(this.lblReq, 0);
			this.Controls.SetChildIndex(this.dteRequest, 0);
			this.Controls.SetChildIndex(this.cmbReleaseDue, 0);
			this.Controls.SetChildIndex(this.txtPriority, 0);
			this.Controls.SetChildIndex(this.grpFlags, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.lblDue, 0);
			this.Controls.SetChildIndex(this.lblFlags, 0);
			this.Controls.SetChildIndex(this.lblPriority, 0);
			this.Controls.SetChildIndex(this.lblInfo, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbReleaseDue)).EndInit();
			this.grpFlags.ResumeLayout(false);
			this.grpFlags.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucCheckBox chkDataFix;
		private CS2010.CommonWinCtrls.ucTextBox txtPriority;
		private CS2010.CommonWinCtrls.ucDateTextBox dteDue;
		private ASL.ITrack.WinCtrls.ucReleaseCombo cmbReleaseDue;
		private CS2010.CommonWinCtrls.ucCheckBox chkEmergency;
		private CS2010.CommonWinCtrls.ucDateTextBox dteRequest;
		private CS2010.CommonWinCtrls.ucLabel lblRel;
		private CS2010.CommonWinCtrls.ucGroupBox grpFlags;
		private CS2010.CommonWinCtrls.ucLabel lblReq;
		private CS2010.CommonWinCtrls.ucLabel lblDue;
		private CS2010.CommonWinCtrls.ucLabel lblFlags;
		private CS2010.CommonWinCtrls.ucLabel lblPriority;
		private CS2010.CommonWinCtrls.ucLabel lblInfo;
	}
}