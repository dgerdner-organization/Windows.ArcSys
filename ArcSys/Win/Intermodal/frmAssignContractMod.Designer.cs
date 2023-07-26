namespace CS2010.ArcSys.Win
{
	partial class frmAssignContractMod
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
			Janus.Windows.GridEX.GridEXLayout cmbMod_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignContractMod));
			this.cmbMod = new CS2010.ArcSys.WinCtrls.ucContractModCombo();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.lnkNewMod = new CS2010.CommonWinCtrls.ucLinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.cmbMod)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbMod
			// 
			this.cmbMod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbMod.CodeColumn = "Mod_No";
			this.cmbMod.DescriptionColumn = "Attachment_Nm";
			cmbMod_DesignTimeLayout.LayoutString = resources.GetString("cmbMod_DesignTimeLayout.LayoutString");
			this.cmbMod.DesignTimeLayout = cmbMod_DesignTimeLayout;
			this.cmbMod.DisplayMember = "Mod_NoAttachment_Nm";
			this.cmbMod.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbMod.LabelText = "Contract Mod";
			this.cmbMod.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMod.Location = new System.Drawing.Point(80, 27);
			this.cmbMod.Name = "cmbMod";
			this.cmbMod.SelectedIndex = -1;
			this.cmbMod.SelectedItem = null;
			this.cmbMod.Size = new System.Drawing.Size(345, 20);
			this.cmbMod.TabIndex = 0;
			this.cmbMod.ValueColumn = "Contract_Mod_ID";
			this.cmbMod.ValueMember = "Contract_Mod_ID";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(253, 83);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(334, 83);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lnkNewMod
			// 
			this.lnkNewMod.AutoSize = true;
			this.lnkNewMod.Location = new System.Drawing.Point(80, 54);
			this.lnkNewMod.Name = "lnkNewMod";
			this.lnkNewMod.Size = new System.Drawing.Size(238, 13);
			this.lnkNewMod.TabIndex = 5;
			this.lnkNewMod.TabStop = true;
			this.lnkNewMod.Text = "Click here to assign cargo to a new contract mod";
			this.lnkNewMod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewMod_LinkClicked);
			// 
			// frmAssignContractMod
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(445, 120);
			this.Controls.Add(this.lnkNewMod);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbMod);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAssignContractMod";
			this.Text = "Assign Contract Mod";
			((System.ComponentModel.ISupportInitialize)(this.cmbMod)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private WinCtrls.ucContractModCombo cmbMod;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucLinkLabel lnkNewMod;
	}
}