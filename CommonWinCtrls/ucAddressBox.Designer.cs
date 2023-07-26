namespace CS2010.CommonWinCtrls
{
	partial class ucAddressBox
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAddressBox));
			Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
			this.cmbCountry = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPostalCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr3 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr2 = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbCity = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.btnLookup = new CS2010.CommonWinCtrls.ucButton();
			( (System.ComponentModel.ISupportInitialize)( this.cmbCountry ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.cmbCity ) ).BeginInit();
			this.SuspendLayout();
			// 
			// cmbCountry
			// 
			this.cmbCountry.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmbCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbCountry.CodeColumn = "Country_Cd";
			this.cmbCountry.DescriptionColumn = "Country_Nm";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbCountry.DesignTimeLayout = gridEXLayout1;
			this.cmbCountry.DisplayMember = "Country_Cd";
			this.cmbCountry.LabelText = "Coun&try";
			this.cmbCountry.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCountry.Location = new System.Drawing.Point(66, 180);
			this.cmbCountry.MaxLength = 10;
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.SaveSettings = false;
			this.cmbCountry.SelectedIndex = -1;
			this.cmbCountry.SelectedItem = null;
			this.cmbCountry.Size = new System.Drawing.Size(250, 20);
			this.cmbCountry.TabIndex = 14;
			this.cmbCountry.ValueColumn = "Country_Cd";
			this.cmbCountry.ValueMember = "Country_Cd";
			this.cmbCountry.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCountry_Validating);
			// 
			// txtState
			// 
			this.txtState.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtState.LabelText = "&State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.Location = new System.Drawing.Point(66, 120);
			this.txtState.MaxLength = 5;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(250, 20);
			this.txtState.TabIndex = 12;
			// 
			// txtPostalCd
			// 
			this.txtPostalCd.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtPostalCd.LabelText = "&Postal Code";
			this.txtPostalCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPostalCd.Location = new System.Drawing.Point(66, 150);
			this.txtPostalCd.MaxLength = 10;
			this.txtPostalCd.Name = "txtPostalCd";
			this.txtPostalCd.Size = new System.Drawing.Size(250, 20);
			this.txtPostalCd.TabIndex = 7;
			this.txtPostalCd.Validated += new System.EventHandler(this.txtPostalCd_Validated);
			this.txtPostalCd.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostalCd_Validating);
			// 
			// txtAddr1
			// 
			this.txtAddr1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr1.LabelText = "Address &1";
			this.txtAddr1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr1.Location = new System.Drawing.Point(66, 0);
			this.txtAddr1.MaxLength = 100;
			this.txtAddr1.Name = "txtAddr1";
			this.txtAddr1.Size = new System.Drawing.Size(250, 20);
			this.txtAddr1.TabIndex = 1;
			// 
			// txtAddr3
			// 
			this.txtAddr3.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr3.LabelText = "Address &3";
			this.txtAddr3.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr3.Location = new System.Drawing.Point(66, 60);
			this.txtAddr3.MaxLength = 50;
			this.txtAddr3.Name = "txtAddr3";
			this.txtAddr3.Size = new System.Drawing.Size(250, 20);
			this.txtAddr3.TabIndex = 5;
			// 
			// txtAddr2
			// 
			this.txtAddr2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddr2.LabelText = "Address &2";
			this.txtAddr2.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr2.Location = new System.Drawing.Point(66, 30);
			this.txtAddr2.MaxLength = 100;
			this.txtAddr2.Name = "txtAddr2";
			this.txtAddr2.Size = new System.Drawing.Size(250, 20);
			this.txtAddr2.TabIndex = 3;
			// 
			// cmbCity
			// 
			this.cmbCity.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cmbCity.CodeColumn = "Postal_City";
			this.cmbCity.DescriptionColumn = "Postal_City";
			gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
			this.cmbCity.DesignTimeLayout = gridEXLayout2;
			this.cmbCity.DisplayMember = "Postal_City";
			this.cmbCity.LabelText = "&City";
			this.cmbCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCity.Location = new System.Drawing.Point(66, 90);
			this.cmbCity.Name = "cmbCity";
			this.cmbCity.SaveSettings = false;
			this.cmbCity.SelectedIndex = -1;
			this.cmbCity.SelectedItem = null;
			this.cmbCity.ShowContextMenu = false;
			this.cmbCity.Size = new System.Drawing.Size(220, 20);
			this.cmbCity.TabIndex = 9;
			this.cmbCity.ValueColumn = "Postal_City";
			this.cmbCity.ValueMember = "Postal_City";
			this.cmbCity.TextChanged += new System.EventHandler(this.cmbCity_TextChanged);
			// 
			// btnLookup
			// 
			this.btnLookup.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnLookup.Location = new System.Drawing.Point(292, 89);
			this.btnLookup.Name = "btnLookup";
			this.btnLookup.Size = new System.Drawing.Size(24, 23);
			this.btnLookup.TabIndex = 10;
			this.btnLookup.Text = "...";
			this.btnLookup.UseVisualStyleBackColor = true;
			this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
			// 
			// ucAddressBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnLookup);
			this.Controls.Add(this.cmbCity);
			this.Controls.Add(this.cmbCountry);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtPostalCd);
			this.Controls.Add(this.txtAddr1);
			this.Controls.Add(this.txtAddr3);
			this.Controls.Add(this.txtAddr2);
			this.Name = "ucAddressBox";
			this.Size = new System.Drawing.Size(317, 200);
			( (System.ComponentModel.ISupportInitialize)( this.cmbCountry ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.cmbCity ) ).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected ucMultiColumnCombo cmbCountry;
		protected ucTextBox txtState;
		protected ucTextBox txtPostalCd;
		protected ucTextBox txtAddr1;
		protected ucTextBox txtAddr3;
		protected ucTextBox txtAddr2;
		protected ucButton btnLookup;
		protected ucMultiColumnCombo cmbCity;
	}
}
