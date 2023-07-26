namespace ASL.ITrack.WinCtrls
{
	partial class frmEditNote
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
			if( disposing && ( components != null ) )
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
			Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditNote));
			this.txtNote = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbStatus = new ASL.ITrack.WinCtrls.ucStatusCombo();
			this.chkDeveloper = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkEmail = new CS2010.CommonWinCtrls.ucCheckBox();
			this.lblTo = new CS2010.CommonWinCtrls.ucLabel();
			this.txtTo = new CS2010.CommonWinCtrls.ucTextBox();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(412, 467);
			this.btnOK.TabIndex = 10;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(495, 467);
			this.btnCancel.TabIndex = 11;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(578, 467);
			this.btnApply.TabIndex = 12;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtNote
			// 
			this.txtNote.AcceptsReturn = true;
			this.txtNote.AcceptsTab = true;
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNote.LabelText = "&Remarks";
			this.txtNote.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNote.LinkDisabledMessage = "Link Disabled";
			this.txtNote.Location = new System.Drawing.Point(52, 72);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNote.Size = new System.Drawing.Size(518, 333);
			this.txtNote.TabIndex = 5;
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDesc.BackColor = System.Drawing.SystemColors.Control;
			this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtDesc.ForeColor = System.Drawing.Color.Black;
			this.txtDesc.LabelText = "&Desc";
			this.txtDesc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDesc.LinkDisabledMessage = "Link Disabled";
			this.txtDesc.Location = new System.Drawing.Point(52, 12);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ReadOnly = true;
			this.txtDesc.Size = new System.Drawing.Size(518, 20);
			this.txtDesc.TabIndex = 1;
			this.txtDesc.TabStop = false;
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbStatus.CodeColumn = "Status_Cd";
			this.cmbStatus.DescriptionColumn = "Status_Dsc";
			cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
			this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
			this.cmbStatus.DisplayMember = "Status_CdStatus_Dsc";
			this.cmbStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbStatus.LabelText = "&Status";
			this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbStatus.Location = new System.Drawing.Point(52, 42);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.SelectedIndex = -1;
			this.cmbStatus.SelectedItem = null;
			this.cmbStatus.Size = new System.Drawing.Size(518, 20);
			this.cmbStatus.TabIndex = 3;
			this.cmbStatus.ValueColumn = "Status_Cd";
			this.cmbStatus.ValueMember = "Status_Cd";
			// 
			// chkDeveloper
			// 
			this.chkDeveloper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkDeveloper.AutoSize = true;
			this.chkDeveloper.Location = new System.Drawing.Point(498, 416);
			this.chkDeveloper.Name = "chkDeveloper";
			this.chkDeveloper.Size = new System.Drawing.Size(72, 17);
			this.chkDeveloper.TabIndex = 7;
			this.chkDeveloper.Text = "Dev &Note";
			this.chkDeveloper.UseVisualStyleBackColor = true;
			this.chkDeveloper.Visible = false;
			this.chkDeveloper.YN = "N";
			// 
			// chkEmail
			// 
			this.chkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkEmail.AutoSize = true;
			this.chkEmail.Location = new System.Drawing.Point(52, 416);
			this.chkEmail.Name = "chkEmail";
			this.chkEmail.Size = new System.Drawing.Size(79, 17);
			this.chkEmail.TabIndex = 6;
			this.chkEmail.Text = "Send &Email";
			this.chkEmail.UseVisualStyleBackColor = true;
			this.chkEmail.YN = "N";
			this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
			// 
			// lblTo
			// 
			this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTo.Location = new System.Drawing.Point(50, 444);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(29, 13);
			this.lblTo.TabIndex = 8;
			this.lblTo.Text = "&To...";
			this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblTo.Visible = false;
			this.lblTo.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
			this.lblTo.Click += new System.EventHandler(this.lblTo_Click);
			this.lblTo.MouseHover += new System.EventHandler(this.lbl_MouseHover);
			// 
			// txtTo
			// 
			this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtTo.LinkDisabledMessage = "Link Disabled";
			this.txtTo.Location = new System.Drawing.Point(84, 440);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(486, 20);
			this.txtTo.TabIndex = 9;
			this.txtTo.Visible = false;
			// 
			// frmEditNote
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 498);
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.lblTo);
			this.Controls.Add(this.chkEmail);
			this.Controls.Add(this.chkDeveloper);
			this.Controls.Add(this.cmbStatus);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.txtNote);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "frmEditNote";
			this.Text = "Add/Edit Note (Change Status)";
			this.Load += new System.EventHandler(this.frmEditNote_Load);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtNote, 0);
			this.Controls.SetChildIndex(this.txtDesc, 0);
			this.Controls.SetChildIndex(this.cmbStatus, 0);
			this.Controls.SetChildIndex(this.chkDeveloper, 0);
			this.Controls.SetChildIndex(this.chkEmail, 0);
			this.Controls.SetChildIndex(this.lblTo, 0);
			this.Controls.SetChildIndex(this.txtTo, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtNote;
		private CS2010.CommonWinCtrls.ucTextBox txtDesc;
		private ASL.ITrack.WinCtrls.ucStatusCombo cmbStatus;
		private CS2010.CommonWinCtrls.ucCheckBox chkDeveloper;
		private CS2010.CommonWinCtrls.ucCheckBox chkEmail;
		private CS2010.CommonWinCtrls.ucLabel lblTo;
		private CS2010.CommonWinCtrls.ucTextBox txtTo;
	}
}