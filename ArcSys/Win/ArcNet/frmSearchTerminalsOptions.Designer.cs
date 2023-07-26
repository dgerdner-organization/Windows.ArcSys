namespace CS2010.ArcSys.Win
{
	partial class frmSearchTerminalsOptions
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
			Janus.Windows.GridEX.GridEXLayout cmbPort_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchTerminalsOptions));
			this.cmbPort = new CS2010.ArcSys.WinCtrls.ucLocationCheckBoxCombo();
			this.btnClear = new CS2010.CommonWinCtrls.ucButton();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(341, 12);
			this.btnOK.TabIndex = 40;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(341, 42);
			this.btnCancel.TabIndex = 41;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(341, 102);
			this.btnApply.TabIndex = 43;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// cmbPort
			// 
			this.cmbPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPort.CodeColumn = "Location_Cd";
			this.cmbPort.DescriptionColumn = "Location_Dsc";
			cmbPort_DesignTimeLayout.LayoutString = resources.GetString("cmbPort_DesignTimeLayout.LayoutString");
			this.cmbPort.DesignTimeLayout = cmbPort_DesignTimeLayout;
			this.cmbPort.DropDownButtonsVisible = false;
			this.cmbPort.DropDownDisplayMember = "Location_Cd";
			this.cmbPort.DropDownValueMember = "Location_Cd";
			this.cmbPort.LabelText = "Port";
			this.cmbPort.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPort.Location = new System.Drawing.Point(68, 12);
			this.cmbPort.Name = "cmbPort";
			this.cmbPort.SaveSettings = false;
			this.cmbPort.Size = new System.Drawing.Size(249, 20);
			this.cmbPort.TabIndex = 9;
			this.cmbPort.ValueColumn = "Location_Cd";
			this.cmbPort.ValuesDataMember = null;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(341, 72);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 42;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// frmSearchTerminalsOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 115);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.cmbPort);
			this.Name = "frmSearchTerminalsOptions";
			this.Text = "Search Terminal Options";
			this.Load += new System.EventHandler(this.frmSearchTerminalsOptions_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchTerminalsOptions_KeyDown);
			this.Controls.SetChildIndex(this.cmbPort, 0);
			this.Controls.SetChildIndex(this.btnClear, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WinCtrls.ucLocationCheckBoxCombo cmbPort;
		private CommonWinCtrls.ucButton btnClear;
	}
}