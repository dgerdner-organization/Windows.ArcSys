namespace CS2010.ArcSys.Win
{
	partial class frmCreateContractMod
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
			this.txtModNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.rtfMemo = new CS2010.CommonWinCtrls.ucRichTextBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.txtAttachmentNm = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtFullFilePath = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnFile = new CS2010.CommonWinCtrls.ucButton();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.txtID = new CS2010.CommonWinCtrls.ucTextBox();
			this.SuspendLayout();
			// 
			// txtModNo
			// 
			this.txtModNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtModNo.LabelText = "Mod #";
			this.txtModNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtModNo.LinkDisabledMessage = "Link Disabled";
			this.txtModNo.Location = new System.Drawing.Point(64, 12);
			this.txtModNo.Name = "txtModNo";
			this.txtModNo.Size = new System.Drawing.Size(480, 20);
			this.txtModNo.TabIndex = 1;
			// 
			// rtfMemo
			// 
			this.rtfMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtfMemo.LabelText = "Memo";
			this.rtfMemo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.rtfMemo.Location = new System.Drawing.Point(64, 64);
			this.rtfMemo.Name = "rtfMemo";
			this.rtfMemo.Size = new System.Drawing.Size(480, 226);
			this.rtfMemo.TabIndex = 6;
			this.rtfMemo.Text = "";
			// 
			// dlgOpen
			// 
			this.dlgOpen.AddExtension = false;
			this.dlgOpen.Filter = "All files|*.*";
			this.dlgOpen.SupportMultiDottedExtensions = true;
			this.dlgOpen.Title = "Select file for Contract Mod";
			// 
			// txtAttachmentNm
			// 
			this.txtAttachmentNm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAttachmentNm.BackColor = System.Drawing.SystemColors.Control;
			this.txtAttachmentNm.ForeColor = System.Drawing.Color.Black;
			this.txtAttachmentNm.LabelText = "File Name";
			this.txtAttachmentNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAttachmentNm.LinkDisabledMessage = "Link Disabled";
			this.txtAttachmentNm.Location = new System.Drawing.Point(64, 296);
			this.txtAttachmentNm.Name = "txtAttachmentNm";
			this.txtAttachmentNm.ReadOnly = true;
			this.txtAttachmentNm.Size = new System.Drawing.Size(480, 20);
			this.txtAttachmentNm.TabIndex = 8;
			this.txtAttachmentNm.TabStop = false;
			// 
			// txtFullFilePath
			// 
			this.txtFullFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFullFilePath.BackColor = System.Drawing.SystemColors.Control;
			this.txtFullFilePath.ForeColor = System.Drawing.Color.Black;
			this.txtFullFilePath.LabelText = "Attachment";
			this.txtFullFilePath.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFullFilePath.LinkDisabledMessage = "Link Disabled";
			this.txtFullFilePath.Location = new System.Drawing.Point(64, 38);
			this.txtFullFilePath.Name = "txtFullFilePath";
			this.txtFullFilePath.ReadOnly = true;
			this.txtFullFilePath.Size = new System.Drawing.Size(480, 20);
			this.txtFullFilePath.TabIndex = 3;
			this.txtFullFilePath.TabStop = false;
			// 
			// btnFile
			// 
			this.btnFile.Location = new System.Drawing.Point(551, 36);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(28, 23);
			this.btnFile.TabIndex = 4;
			this.btnFile.Text = "...";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(388, 324);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 24;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(469, 324);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 25;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtID
			// 
			this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtID.BackColor = System.Drawing.SystemColors.Control;
			this.txtID.ForeColor = System.Drawing.Color.Black;
			this.txtID.LinkDisabledMessage = "Link Disabled";
			this.txtID.Location = new System.Drawing.Point(551, 10);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(28, 20);
			this.txtID.TabIndex = 26;
			this.txtID.TabStop = false;
			// 
			// frmCreateContractMod
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(585, 354);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.txtFullFilePath);
			this.Controls.Add(this.txtAttachmentNm);
			this.Controls.Add(this.rtfMemo);
			this.Controls.Add(this.txtModNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmCreateContractMod";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Contract Mod";
			this.Load += new System.EventHandler(this.frmCreateContractMod_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtModNo;
		private CommonWinCtrls.ucRichTextBox rtfMemo;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private CommonWinCtrls.ucTextBox txtAttachmentNm;
		private CommonWinCtrls.ucTextBox txtFullFilePath;
		private CommonWinCtrls.ucButton btnFile;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucTextBox txtID;
	}
}