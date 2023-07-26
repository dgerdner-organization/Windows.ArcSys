namespace CS2010.CommonWinCtrls
{
	partial class frmAddressLookup
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
			Janus.Windows.GridEX.GridEXLayout grdAddress_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressLookup));
			this.txtCity = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtZip = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdAddress = new CS2010.CommonWinCtrls.ucGridEx();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			( (System.ComponentModel.ISupportInitialize)( this.grdAddress ) ).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(368, 388);
			this.btnOK.TabIndex = 8;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(448, 388);
			this.btnCancel.TabIndex = 9;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(528, 388);
			this.btnApply.TabIndex = 10;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtCity
			// 
			this.txtCity.LabelText = "City";
			this.txtCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCity.Location = new System.Drawing.Point(86, 8);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(192, 20);
			this.txtCity.TabIndex = 1;
			// 
			// txtState
			// 
			this.txtState.LabelText = "State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.Location = new System.Drawing.Point(86, 38);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(116, 20);
			this.txtState.TabIndex = 3;
			// 
			// txtZip
			// 
			this.txtZip.LabelText = "Postal Code";
			this.txtZip.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtZip.Location = new System.Drawing.Point(86, 68);
			this.txtZip.Name = "txtZip";
			this.txtZip.Size = new System.Drawing.Size(116, 20);
			this.txtZip.TabIndex = 5;
			// 
			// grdAddress
			// 
			this.grdAddress.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdAddress.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			grdAddress_DesignTimeLayout.LayoutString = resources.GetString("grdAddress_DesignTimeLayout.LayoutString");
			this.grdAddress.DesignTimeLayout = grdAddress_DesignTimeLayout;
			this.grdAddress.ExportFileID = null;
			this.grdAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdAddress.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
			this.grdAddress.Location = new System.Drawing.Point(4, 104);
			this.grdAddress.Name = "grdAddress";
			this.grdAddress.Size = new System.Drawing.Size(537, 275);
			this.grdAddress.TabIndex = 7;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(292, 6);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 6;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// frmAddressLookup
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(545, 419);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.grdAddress);
			this.Controls.Add(this.txtZip);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtCity);
			this.Name = "frmAddressLookup";
			this.Text = "Postal Code Lookup";
			this.Load += new System.EventHandler(this.frmAddressLookup_Load);
			this.Controls.SetChildIndex(this.txtCity, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtState, 0);
			this.Controls.SetChildIndex(this.txtZip, 0);
			this.Controls.SetChildIndex(this.grdAddress, 0);
			this.Controls.SetChildIndex(this.btnSearch, 0);
			( (System.ComponentModel.ISupportInitialize)( this.grdAddress ) ).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ucTextBox txtCity;
		private ucTextBox txtState;
		private ucTextBox txtZip;
		private ucGridEx grdAddress;
		private ucButton btnSearch;
	}
}