namespace CS2010.CommonWinCtrls
{
	partial class frmExportOptions
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
			this.grpExportType = new CS2010.CommonWinCtrls.ucGroupBox();
			this.rdoCSV = new CS2010.CommonWinCtrls.ucRadioButton();
			this.txtDelim = new CS2010.CommonWinCtrls.ucTextBox();
			this.rdoExcel = new CS2010.CommonWinCtrls.ucRadioButton();
			this.rdoDelimited = new CS2010.CommonWinCtrls.ucRadioButton();
			this.chkIncludeChild = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grpRows = new CS2010.CommonWinCtrls.ucGroupBox();
			this.rdoCheckedRows = new CS2010.CommonWinCtrls.ucRadioButton();
			this.rdoAllRows = new CS2010.CommonWinCtrls.ucRadioButton();
			this.chkIncludeColHeaders = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkIncludeSelectorColumn = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.grpExportType.SuspendLayout();
			this.grpRows.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpExportType
			// 
			this.grpExportType.Controls.Add(this.rdoCSV);
			this.grpExportType.Controls.Add(this.txtDelim);
			this.grpExportType.Controls.Add(this.rdoExcel);
			this.grpExportType.Controls.Add(this.rdoDelimited);
			this.grpExportType.Location = new System.Drawing.Point(12, 12);
			this.grpExportType.Name = "grpExportType";
			this.grpExportType.Size = new System.Drawing.Size(255, 48);
			this.grpExportType.TabIndex = 0;
			this.grpExportType.TabStop = false;
			this.grpExportType.Text = "Export Type";
			// 
			// rdoCSV
			// 
			this.rdoCSV.AutoSize = true;
			this.rdoCSV.Location = new System.Drawing.Point(77, 19);
			this.rdoCSV.Name = "rdoCSV";
			this.rdoCSV.Size = new System.Drawing.Size(46, 17);
			this.rdoCSV.TabIndex = 1;
			this.rdoCSV.TabStop = true;
			this.rdoCSV.Text = "&CSV";
			this.rdoCSV.UseVisualStyleBackColor = true;
			this.rdoCSV.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
			// 
			// txtDelim
			// 
			this.txtDelim.Enabled = false;
			this.txtDelim.LinkDisabledMessage = "Link Disabled";
			this.txtDelim.Location = new System.Drawing.Point(204, 20);
			this.txtDelim.MaxLength = 1;
			this.txtDelim.Name = "txtDelim";
			this.txtDelim.Size = new System.Drawing.Size(24, 20);
			this.txtDelim.TabIndex = 3;
			this.txtDelim.Text = ",";
			// 
			// rdoExcel
			// 
			this.rdoExcel.AutoSize = true;
			this.rdoExcel.Location = new System.Drawing.Point(19, 19);
			this.rdoExcel.Name = "rdoExcel";
			this.rdoExcel.Size = new System.Drawing.Size(51, 17);
			this.rdoExcel.TabIndex = 0;
			this.rdoExcel.TabStop = true;
			this.rdoExcel.Text = "E&xcel";
			this.rdoExcel.UseVisualStyleBackColor = true;
			this.rdoExcel.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
			// 
			// rdoDelimited
			// 
			this.rdoDelimited.AutoSize = true;
			this.rdoDelimited.Location = new System.Drawing.Point(129, 19);
			this.rdoDelimited.Name = "rdoDelimited";
			this.rdoDelimited.Size = new System.Drawing.Size(68, 17);
			this.rdoDelimited.TabIndex = 2;
			this.rdoDelimited.TabStop = true;
			this.rdoDelimited.Text = "Delimited";
			this.rdoDelimited.UseVisualStyleBackColor = true;
			this.rdoDelimited.CheckedChanged += new System.EventHandler(this.rdoType_CheckedChanged);
			// 
			// chkIncludeChild
			// 
			this.chkIncludeChild.AutoSize = true;
			this.chkIncludeChild.Checked = true;
			this.chkIncludeChild.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeChild.Location = new System.Drawing.Point(13, 118);
			this.chkIncludeChild.Name = "chkIncludeChild";
			this.chkIncludeChild.Size = new System.Drawing.Size(122, 17);
			this.chkIncludeChild.TabIndex = 2;
			this.chkIncludeChild.Text = "Include Child &Tables";
			this.chkIncludeChild.UseVisualStyleBackColor = true;
			this.chkIncludeChild.YN = "Y";
			// 
			// grpRows
			// 
			this.grpRows.Controls.Add(this.rdoCheckedRows);
			this.grpRows.Controls.Add(this.rdoAllRows);
			this.grpRows.Location = new System.Drawing.Point(12, 66);
			this.grpRows.Name = "grpRows";
			this.grpRows.Size = new System.Drawing.Size(255, 46);
			this.grpRows.TabIndex = 1;
			this.grpRows.TabStop = false;
			this.grpRows.Text = "Rows";
			// 
			// rdoCheckedRows
			// 
			this.rdoCheckedRows.AutoSize = true;
			this.rdoCheckedRows.Location = new System.Drawing.Point(86, 19);
			this.rdoCheckedRows.Name = "rdoCheckedRows";
			this.rdoCheckedRows.Size = new System.Drawing.Size(98, 17);
			this.rdoCheckedRows.TabIndex = 1;
			this.rdoCheckedRows.Text = "Chec&ked Rows";
			this.rdoCheckedRows.UseVisualStyleBackColor = true;
			// 
			// rdoAllRows
			// 
			this.rdoAllRows.AutoSize = true;
			this.rdoAllRows.Checked = true;
			this.rdoAllRows.Location = new System.Drawing.Point(6, 19);
			this.rdoAllRows.Name = "rdoAllRows";
			this.rdoAllRows.Size = new System.Drawing.Size(66, 17);
			this.rdoAllRows.TabIndex = 0;
			this.rdoAllRows.TabStop = true;
			this.rdoAllRows.Text = "All &Rows";
			this.rdoAllRows.UseVisualStyleBackColor = true;
			// 
			// chkIncludeColHeaders
			// 
			this.chkIncludeColHeaders.AutoSize = true;
			this.chkIncludeColHeaders.Checked = true;
			this.chkIncludeColHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIncludeColHeaders.Location = new System.Drawing.Point(13, 141);
			this.chkIncludeColHeaders.Name = "chkIncludeColHeaders";
			this.chkIncludeColHeaders.Size = new System.Drawing.Size(142, 17);
			this.chkIncludeColHeaders.TabIndex = 3;
			this.chkIncludeColHeaders.Text = "Include Column &Headers";
			this.chkIncludeColHeaders.UseVisualStyleBackColor = true;
			this.chkIncludeColHeaders.YN = "Y";
			// 
			// chkIncludeSelectorColumn
			// 
			this.chkIncludeSelectorColumn.AutoSize = true;
			this.chkIncludeSelectorColumn.Location = new System.Drawing.Point(13, 164);
			this.chkIncludeSelectorColumn.Name = "chkIncludeSelectorColumn";
			this.chkIncludeSelectorColumn.Size = new System.Drawing.Size(141, 17);
			this.chkIncludeSelectorColumn.TabIndex = 4;
			this.chkIncludeSelectorColumn.Text = "Include &Selector Column";
			this.chkIncludeSelectorColumn.UseVisualStyleBackColor = true;
			this.chkIncludeSelectorColumn.YN = "N";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(285, 12);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(285, 41);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// frmExportOptions
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(381, 190);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkIncludeSelectorColumn);
			this.Controls.Add(this.chkIncludeColHeaders);
			this.Controls.Add(this.grpRows);
			this.Controls.Add(this.chkIncludeChild);
			this.Controls.Add(this.grpExportType);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmExportOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export Options";
			this.grpExportType.ResumeLayout(false);
			this.grpExportType.PerformLayout();
			this.grpRows.ResumeLayout(false);
			this.grpRows.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ucGroupBox grpExportType;
		private ucRadioButton rdoExcel;
		private ucRadioButton rdoDelimited;
		private ucTextBox txtDelim;
		private ucCheckBox chkIncludeChild;
		private ucGroupBox grpRows;
		private ucRadioButton rdoCheckedRows;
		private ucRadioButton rdoAllRows;
		private ucRadioButton rdoCSV;
		private ucCheckBox chkIncludeColHeaders;
		private ucCheckBox chkIncludeSelectorColumn;
		private ucButton btnOK;
		private ucButton btnCancel;
	}
}