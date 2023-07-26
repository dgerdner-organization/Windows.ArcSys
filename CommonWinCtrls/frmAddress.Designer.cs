namespace CS2010.CommonWinCtrls
{
	partial class frmAddress
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
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddress));
			this.txtAddr1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr2 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr3 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPostalCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlAddr = new CS2010.CommonWinCtrls.ucPanel();
			this.btnLookup = new CS2010.CommonWinCtrls.ucButton();
			this.cmbCountry = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtContact = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbCity = new CS2010.CommonWinCtrls.ucComboBox();
			this.pnlAddr.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.cmbCountry ) ).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(162, 284);
			this.btnOK.TabIndex = 18;
			this.btnOK.Text = "Save";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnCancel.Location = new System.Drawing.Point(243, 284);
			this.btnCancel.TabIndex = 19;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(80, 283);
			this.btnApply.TabIndex = 17;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtAddr1
			// 
			this.txtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr1.LabelText = "Address &1";
			this.txtAddr1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr1.Location = new System.Drawing.Point(78, 44);
			this.txtAddr1.MaxLength = 100;
			this.txtAddr1.Name = "txtAddr1";
			this.txtAddr1.Size = new System.Drawing.Size(240, 20);
			this.txtAddr1.TabIndex = 3;
			// 
			// txtAddr2
			// 
			this.txtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr2.LabelText = "Address &2";
			this.txtAddr2.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr2.Location = new System.Drawing.Point(78, 74);
			this.txtAddr2.MaxLength = 100;
			this.txtAddr2.Name = "txtAddr2";
			this.txtAddr2.Size = new System.Drawing.Size(240, 20);
			this.txtAddr2.TabIndex = 5;
			// 
			// txtAddr3
			// 
			this.txtAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr3.LabelText = "Address &3";
			this.txtAddr3.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr3.Location = new System.Drawing.Point(78, 104);
			this.txtAddr3.MaxLength = 50;
			this.txtAddr3.Name = "txtAddr3";
			this.txtAddr3.Size = new System.Drawing.Size(240, 20);
			this.txtAddr3.TabIndex = 7;
			// 
			// txtPostalCd
			// 
			this.txtPostalCd.LabelText = "&Postal Code";
			this.txtPostalCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPostalCd.Location = new System.Drawing.Point(78, 195);
			this.txtPostalCd.MaxLength = 10;
			this.txtPostalCd.Name = "txtPostalCd";
			this.txtPostalCd.Size = new System.Drawing.Size(240, 20);
			this.txtPostalCd.TabIndex = 9;
			this.txtPostalCd.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostalCd_Validating);
			// 
			// pnlAddr
			// 
			this.pnlAddr.Controls.Add(this.btnLookup);
			this.pnlAddr.Controls.Add(this.cmbCountry);
			this.pnlAddr.Controls.Add(this.txtContact);
			this.pnlAddr.Controls.Add(this.txtState);
			this.pnlAddr.Controls.Add(this.cmbCity);
			this.pnlAddr.Controls.Add(this.txtPostalCd);
			this.pnlAddr.Controls.Add(this.txtAddr1);
			this.pnlAddr.Controls.Add(this.txtAddr3);
			this.pnlAddr.Controls.Add(this.txtAddr2);
			this.pnlAddr.Location = new System.Drawing.Point(0, 1);
			this.pnlAddr.Name = "pnlAddr";
			this.pnlAddr.Size = new System.Drawing.Size(330, 250);
			this.pnlAddr.TabIndex = 0;
			// 
			// btnLookup
			// 
			this.btnLookup.Location = new System.Drawing.Point(294, 133);
			this.btnLookup.Name = "btnLookup";
			this.btnLookup.Size = new System.Drawing.Size(24, 23);
			this.btnLookup.TabIndex = 12;
			this.btnLookup.Text = "...";
			this.btnLookup.UseVisualStyleBackColor = true;
			this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
			// 
			// cmbCountry
			// 
			this.cmbCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbCountry.CodeColumn = "Country_Cd";
			this.cmbCountry.DescriptionColumn = "Country_Nm";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbCountry.DesignTimeLayout = gridEXLayout1;
			this.cmbCountry.DisplayMember = "Country_Cd";
			this.cmbCountry.LabelText = "Coun&try";
			this.cmbCountry.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCountry.Location = new System.Drawing.Point(78, 225);
			this.cmbCountry.MaxLength = 10;
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.SaveSettings = false;
			this.cmbCountry.SelectedIndex = -1;
			this.cmbCountry.SelectedItem = null;
			this.cmbCountry.Size = new System.Drawing.Size(240, 20);
			this.cmbCountry.TabIndex = 16;
			this.cmbCountry.ValueColumn = "Country_Cd";
			this.cmbCountry.ValueMember = "Country_Cd";
			this.cmbCountry.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCountry_Validating);
			// 
			// txtContact
			// 
			this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtContact.LabelText = "C&ontact";
			this.txtContact.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtContact.Location = new System.Drawing.Point(78, 12);
			this.txtContact.MaxLength = 100;
			this.txtContact.Name = "txtContact";
			this.txtContact.Size = new System.Drawing.Size(240, 20);
			this.txtContact.TabIndex = 1;
			this.txtContact.Visible = false;
			// 
			// txtState
			// 
			this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtState.LabelText = "&State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.Location = new System.Drawing.Point(78, 165);
			this.txtState.MaxLength = 5;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(240, 20);
			this.txtState.TabIndex = 14;
			// 
			// cmbCity
			// 
			this.cmbCity.DisplayMember = "Postal_City";
			this.cmbCity.FormattingEnabled = true;
			this.cmbCity.LabelText = "&City";
			this.cmbCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCity.Location = new System.Drawing.Point(78, 134);
			this.cmbCity.MaxLength = 50;
			this.cmbCity.Name = "cmbCity";
			this.cmbCity.Size = new System.Drawing.Size(212, 21);
			this.cmbCity.TabIndex = 11;
			this.cmbCity.ValueMember = "Postal_City";
			this.cmbCity.TextChanged += new System.EventHandler(this.cmbCity_TextChanged);
			// 
			// frmAddress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(330, 319);
			this.Controls.Add(this.pnlAddr);
			this.Name = "frmAddress";
			this.Text = "Address";
			this.Load += new System.EventHandler(this.frmAddress_Load);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.pnlAddr, 0);
			this.pnlAddr.ResumeLayout(false);
			this.pnlAddr.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.cmbCountry ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		protected ucTextBox txtAddr1;
		protected ucTextBox txtAddr2;
		protected ucTextBox txtAddr3;
		protected ucTextBox txtPostalCd;
		protected ucPanel pnlAddr;
		protected ucTextBox txtState;
		protected ucComboBox cmbCity;
		protected ucTextBox txtContact;
		protected ucMultiColumnCombo cmbCountry;
		protected ucButton btnLookup;


	}
}