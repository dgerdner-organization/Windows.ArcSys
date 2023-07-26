namespace CS2010.ArcSys.Win
{
	partial class frmVesselEdit
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
			this.txtVesselCd = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.chkDeleted = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtVesselDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtNationality = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtIrcs = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtFlag = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.numMaxWt = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numMaxHt = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numYrBuilt = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.cbxARCFlag = new CS2010.CommonWinCtrls.ucCheckBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.SuspendLayout();
			// 
			// txtVesselCd
			// 
			this.txtVesselCd.LabelText = "&Vessel Code";
			this.txtVesselCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVesselCd.LinkDisabledMessage = "Link Disabled";
			this.txtVesselCd.Location = new System.Drawing.Point(86, 43);
			this.txtVesselCd.Name = "txtVesselCd";
			this.txtVesselCd.Size = new System.Drawing.Size(153, 20);
			this.txtVesselCd.TabIndex = 1;
			// 
			// chkDeleted
			// 
			this.chkDeleted.AutoSize = true;
			this.chkDeleted.Location = new System.Drawing.Point(86, 281);
			this.chkDeleted.Name = "chkDeleted";
			this.chkDeleted.Size = new System.Drawing.Size(69, 17);
			this.chkDeleted.TabIndex = 29;
			this.chkDeleted.Text = "&Deleted?";
			this.chkDeleted.UseVisualStyleBackColor = true;
			this.chkDeleted.YN = "N";
			// 
			// txtVesselDsc
			// 
			this.txtVesselDsc.LabelText = "Des&cription";
			this.txtVesselDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVesselDsc.LinkDisabledMessage = "Link Disabled";
			this.txtVesselDsc.Location = new System.Drawing.Point(86, 69);
			this.txtVesselDsc.Name = "txtVesselDsc";
			this.txtVesselDsc.Size = new System.Drawing.Size(378, 20);
			this.txtVesselDsc.TabIndex = 3;
			// 
			// txtNationality
			// 
			this.txtNationality.LabelText = "&Nationality";
			this.txtNationality.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNationality.LinkDisabledMessage = "Link Disabled";
			this.txtNationality.Location = new System.Drawing.Point(86, 147);
			this.txtNationality.Name = "txtNationality";
			this.txtNationality.Size = new System.Drawing.Size(200, 20);
			this.txtNationality.TabIndex = 9;
			// 
			// txtIrcs
			// 
			this.txtIrcs.LabelText = "&IRCS";
			this.txtIrcs.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtIrcs.LinkDisabledMessage = "Link Disabled";
			this.txtIrcs.Location = new System.Drawing.Point(86, 121);
			this.txtIrcs.Name = "txtIrcs";
			this.txtIrcs.Size = new System.Drawing.Size(200, 20);
			this.txtIrcs.TabIndex = 7;
			// 
			// txtFlag
			// 
			this.txtFlag.LabelText = "&Flag";
			this.txtFlag.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFlag.LinkDisabledMessage = "Link Disabled";
			this.txtFlag.Location = new System.Drawing.Point(86, 95);
			this.txtFlag.Name = "txtFlag";
			this.txtFlag.Size = new System.Drawing.Size(200, 20);
			this.txtFlag.TabIndex = 5;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(308, 277);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 30;
			this.btnOK.Text = "&Save";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(389, 277);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// numMaxWt
			// 
			this.numMaxWt.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numMaxWt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numMaxWt.DecimalDigits = 0;
			this.numMaxWt.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numMaxWt.FormatString = "#";
			this.numMaxWt.LabelText = "Max &Weight";
			this.numMaxWt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numMaxWt.Location = new System.Drawing.Point(86, 174);
			this.numMaxWt.MaxLength = 10;
			this.numMaxWt.Name = "numMaxWt";
			this.numMaxWt.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numMaxWt.Size = new System.Drawing.Size(153, 20);
			this.numMaxWt.TabIndex = 11;
			this.numMaxWt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numMaxWt.Value = null;
			this.numMaxWt.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt32;
			// 
			// numMaxHt
			// 
			this.numMaxHt.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numMaxHt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numMaxHt.DecimalDigits = 0;
			this.numMaxHt.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numMaxHt.FormatString = "#";
			this.numMaxHt.LabelText = "Max &Height";
			this.numMaxHt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numMaxHt.Location = new System.Drawing.Point(86, 200);
			this.numMaxHt.MaxLength = 10;
			this.numMaxHt.Name = "numMaxHt";
			this.numMaxHt.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numMaxHt.Size = new System.Drawing.Size(153, 20);
			this.numMaxHt.TabIndex = 13;
			this.numMaxHt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numMaxHt.Value = null;
			this.numMaxHt.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt32;
			// 
			// numYrBuilt
			// 
			this.numYrBuilt.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numYrBuilt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numYrBuilt.DecimalDigits = 0;
			this.numYrBuilt.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numYrBuilt.FormatString = "#";
			this.numYrBuilt.LabelText = "&Year Built";
			this.numYrBuilt.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numYrBuilt.Location = new System.Drawing.Point(86, 226);
			this.numYrBuilt.MaxLength = 4;
			this.numYrBuilt.Name = "numYrBuilt";
			this.numYrBuilt.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numYrBuilt.Size = new System.Drawing.Size(69, 20);
			this.numYrBuilt.TabIndex = 15;
			this.numYrBuilt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numYrBuilt.Value = null;
			this.numYrBuilt.ValueType = Janus.Windows.GridEX.NumericEditValueType.UInt32;
			// 
			// cbxARCFlag
			// 
			this.cbxARCFlag.Location = new System.Drawing.Point(86, 251);
			this.cbxARCFlag.Name = "cbxARCFlag";
			this.cbxARCFlag.Size = new System.Drawing.Size(104, 24);
			this.cbxARCFlag.TabIndex = 32;
			this.cbxARCFlag.Text = "ARC Vessel?";
			this.cbxARCFlag.UseVisualStyleBackColor = true;
			this.cbxARCFlag.YN = "N";
			// 
			// ucLabel1
			// 
			this.ucLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.ucLabel1.Location = new System.Drawing.Point(8, 7);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(476, 18);
			this.ucLabel1.TabIndex = 33;
			this.ucLabel1.Text = "NOTE:  This will update the vessel table in all ARC Databases.";
			// 
			// frmVesselEdit
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(513, 317);
			this.Controls.Add(this.ucLabel1);
			this.Controls.Add(this.cbxARCFlag);
			this.Controls.Add(this.numYrBuilt);
			this.Controls.Add(this.numMaxHt);
			this.Controls.Add(this.numMaxWt);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtFlag);
			this.Controls.Add(this.txtIrcs);
			this.Controls.Add(this.txtNationality);
			this.Controls.Add(this.txtVesselDsc);
			this.Controls.Add(this.chkDeleted);
			this.Controls.Add(this.txtVesselCd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVesselEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add/Edit Vessel";
			this.Load += new System.EventHandler(this.frmVesselEdit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBoxPK txtVesselCd;
		private CommonWinCtrls.ucCheckBox chkDeleted;
		private CommonWinCtrls.ucTextBox txtVesselDsc;
		private CommonWinCtrls.ucTextBox txtNationality;
		private CommonWinCtrls.ucTextBox txtIrcs;
		private CommonWinCtrls.ucTextBox txtFlag;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucNumericEditBox numMaxWt;
		private CommonWinCtrls.ucNumericEditBox numMaxHt;
		private CommonWinCtrls.ucNumericEditBox numYrBuilt;
		private CommonWinCtrls.ucCheckBox cbxARCFlag;
		private CommonWinCtrls.ucLabel ucLabel1;
	}
}