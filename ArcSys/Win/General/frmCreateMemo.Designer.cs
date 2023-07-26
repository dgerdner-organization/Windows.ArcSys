namespace CS2010.ArcSys.Win
{
	partial class frmCreateMemo
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
			this.txtMemoDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.rtfMemo = new CS2010.CommonWinCtrls.ucRichTextBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.btnFile = new CS2010.CommonWinCtrls.ucButton();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.txtID = new CS2010.CommonWinCtrls.ucTextBox();
			this.lvwFiles = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// txtMemoDsc
			// 
			this.txtMemoDsc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMemoDsc.LabelText = "Title";
			this.txtMemoDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMemoDsc.LinkDisabledMessage = "Link Disabled";
			this.txtMemoDsc.Location = new System.Drawing.Point(64, 12);
			this.txtMemoDsc.Name = "txtMemoDsc";
			this.txtMemoDsc.Size = new System.Drawing.Size(480, 20);
			this.txtMemoDsc.TabIndex = 1;
			// 
			// rtfMemo
			// 
			this.rtfMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.rtfMemo.LabelText = "Memo";
			this.rtfMemo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.rtfMemo.Location = new System.Drawing.Point(64, 38);
			this.rtfMemo.Name = "rtfMemo";
			this.rtfMemo.Size = new System.Drawing.Size(480, 295);
			this.rtfMemo.TabIndex = 3;
			this.rtfMemo.Text = "";
			// 
			// dlgOpen
			// 
			this.dlgOpen.AddExtension = false;
			this.dlgOpen.Filter = "All files|*.*";
			this.dlgOpen.Multiselect = true;
			this.dlgOpen.SupportMultiDottedExtensions = true;
			this.dlgOpen.Title = "Select file for Contract Mod";
			// 
			// btnFile
			// 
			this.btnFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFile.Location = new System.Drawing.Point(551, 348);
			this.btnFile.Name = "btnFile";
			this.btnFile.Size = new System.Drawing.Size(28, 23);
			this.btnFile.TabIndex = 5;
			this.btnFile.Text = "...";
			this.btnFile.UseVisualStyleBackColor = true;
			this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(388, 506);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 24;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(469, 506);
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
			// lvwFiles
			// 
			this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvwFiles.Location = new System.Drawing.Point(65, 348);
			this.lvwFiles.MultiSelect = false;
			this.lvwFiles.Name = "lvwFiles";
			this.lvwFiles.Size = new System.Drawing.Size(480, 152);
			this.lvwFiles.TabIndex = 4;
			this.lvwFiles.UseCompatibleStateImageBehavior = false;
			this.lvwFiles.View = System.Windows.Forms.View.Details;
			this.lvwFiles.DoubleClick += new System.EventHandler(this.lvwFiles_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File";
			this.columnHeader1.Width = 457;
			// 
			// frmCreateMemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(585, 536);
			this.Controls.Add(this.lvwFiles);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnFile);
			this.Controls.Add(this.rtfMemo);
			this.Controls.Add(this.txtMemoDsc);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmCreateMemo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Memo";
			this.Load += new System.EventHandler(this.frmCreateMemo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtMemoDsc;
		private CommonWinCtrls.ucRichTextBox rtfMemo;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private CommonWinCtrls.ucButton btnFile;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucTextBox txtID;
		private System.Windows.Forms.ListView lvwFiles;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}