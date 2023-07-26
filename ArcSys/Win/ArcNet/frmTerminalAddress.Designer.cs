namespace CS2010.ArcSys.Win
{
	partial class frmTerminalAddress
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
			Janus.Windows.GridEX.GridEXLayout cmbCountry_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerminalAddress));
			Janus.Windows.GridEX.GridEXLayout grdAddr_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grdAddr = new CS2010.CommonWinCtrls.ucGridEx();
			this.tabAddresses = new CS2010.CommonWinCtrls.ucTabControl();
			this.tpMemberAddresses = new System.Windows.Forms.TabPage();
			this.txtContactDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddressee = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlAddr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAddr)).BeginInit();
			this.tabAddresses.SuspendLayout();
			this.tpMemberAddresses.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAddr1
			// 
			this.txtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAddr1.Location = new System.Drawing.Point(78, 28);
			this.txtAddr1.Size = new System.Drawing.Size(422, 20);
			// 
			// txtAddr2
			// 
			this.txtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAddr2.Location = new System.Drawing.Point(78, 52);
			this.txtAddr2.Size = new System.Drawing.Size(422, 20);
			// 
			// txtAddr3
			// 
			this.txtAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAddr3.Location = new System.Drawing.Point(78, 76);
			this.txtAddr3.Size = new System.Drawing.Size(422, 20);
			// 
			// txtPostalCd
			// 
			this.txtPostalCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtPostalCd.Location = new System.Drawing.Point(78, 148);
			this.txtPostalCd.Size = new System.Drawing.Size(422, 20);
			// 
			// pnlAddr
			// 
			this.pnlAddr.Controls.Add(this.txtAddressee);
			this.pnlAddr.Controls.Add(this.txtContactDsc);
			this.pnlAddr.Location = new System.Drawing.Point(12, 212);
			this.pnlAddr.Size = new System.Drawing.Size(505, 244);
			this.pnlAddr.Controls.SetChildIndex(this.txtContact, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtContactDsc, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtAddr3, 0);
			this.pnlAddr.Controls.SetChildIndex(this.cmbCity, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtAddr2, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtAddr1, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtPostalCd, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtState, 0);
			this.pnlAddr.Controls.SetChildIndex(this.cmbCountry, 0);
			this.pnlAddr.Controls.SetChildIndex(this.btnLookup, 0);
			this.pnlAddr.Controls.SetChildIndex(this.txtAddressee, 0);
			// 
			// txtState
			// 
			this.txtState.Location = new System.Drawing.Point(78, 124);
			this.txtState.Size = new System.Drawing.Size(422, 20);
			// 
			// cmbCity
			// 
			this.cmbCity.Location = new System.Drawing.Point(78, 100);
			this.cmbCity.Size = new System.Drawing.Size(392, 21);
			// 
			// txtContact
			// 
			this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtContact.LabelText = "Contact Name";
			this.txtContact.Location = new System.Drawing.Point(78, 220);
			this.txtContact.Size = new System.Drawing.Size(422, 20);
			this.txtContact.TabIndex = 20;
			this.txtContact.Visible = true;
			// 
			// cmbCountry
			// 
			cmbCountry_DesignTimeLayout.LayoutString = resources.GetString("cmbCountry_DesignTimeLayout.LayoutString");
			this.cmbCountry.DesignTimeLayout = cmbCountry_DesignTimeLayout;
			this.cmbCountry.Location = new System.Drawing.Point(78, 172);
			this.cmbCountry.Size = new System.Drawing.Size(422, 20);
			// 
			// btnLookup
			// 
			this.btnLookup.Location = new System.Drawing.Point(476, 100);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(356, 465);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(437, 465);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(274, 465);
			// 
			// grdAddr
			// 
			this.grdAddr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdAddr_DesignTimeLayout.LayoutString = resources.GetString("grdAddr_DesignTimeLayout.LayoutString");
			this.grdAddr.DesignTimeLayout = grdAddr_DesignTimeLayout;
			this.grdAddr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAddr.ExportFileID = null;
			this.grdAddr.GroupByBoxVisible = false;
			this.grdAddr.Location = new System.Drawing.Point(3, 3);
			this.grdAddr.Name = "grdAddr";
			this.grdAddr.Size = new System.Drawing.Size(510, 174);
			this.grdAddr.TabIndex = 4;
			this.grdAddr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdAddr.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAddr.DoubleClick += new System.EventHandler(this.grdAddr_DoubleClick);
			// 
			// tabAddresses
			// 
			this.tabAddresses.Controls.Add(this.tpMemberAddresses);
			this.tabAddresses.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabAddresses.Location = new System.Drawing.Point(0, 0);
			this.tabAddresses.Name = "tabAddresses";
			this.tabAddresses.SelectedIndex = 0;
			this.tabAddresses.Size = new System.Drawing.Size(524, 206);
			this.tabAddresses.TabIndex = 20;
			// 
			// tpMemberAddresses
			// 
			this.tpMemberAddresses.Controls.Add(this.grdAddr);
			this.tpMemberAddresses.Location = new System.Drawing.Point(4, 22);
			this.tpMemberAddresses.Name = "tpMemberAddresses";
			this.tpMemberAddresses.Padding = new System.Windows.Forms.Padding(3);
			this.tpMemberAddresses.Size = new System.Drawing.Size(516, 180);
			this.tpMemberAddresses.TabIndex = 0;
			this.tpMemberAddresses.Text = "Addresses";
			this.tpMemberAddresses.UseVisualStyleBackColor = true;
			// 
			// txtContactDsc
			// 
			this.txtContactDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtContactDsc.LabelText = "Contact Desc";
			this.txtContactDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtContactDsc.LinkDisabledMessage = "Link Disabled";
			this.txtContactDsc.Location = new System.Drawing.Point(78, 196);
			this.txtContactDsc.Name = "txtContactDsc";
			this.txtContactDsc.Size = new System.Drawing.Size(422, 20);
			this.txtContactDsc.TabIndex = 18;
			// 
			// txtAddressee
			// 
			this.txtAddressee.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAddressee.LabelText = "Name";
			this.txtAddressee.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddressee.LinkDisabledMessage = "Link Disabled";
			this.txtAddressee.Location = new System.Drawing.Point(78, 4);
			this.txtAddressee.Name = "txtAddressee";
			this.txtAddressee.Size = new System.Drawing.Size(422, 20);
			this.txtAddressee.TabIndex = 1;
			// 
			// frmTerminalAddress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 492);
			this.ContactLabel = "Contact Name";
			this.Controls.Add(this.tabAddresses);
			this.Name = "frmTerminalAddress";
			this.Text = "Terminal Address";
			this.Load += new System.EventHandler(this.frmTerminalAddress_Load);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.tabAddresses, 0);
			this.Controls.SetChildIndex(this.pnlAddr, 0);
			this.pnlAddr.ResumeLayout(false);
			this.pnlAddr.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdAddr)).EndInit();
			this.tabAddresses.ResumeLayout(false);
			this.tpMemberAddresses.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucGridEx grdAddr;
        private CS2010.CommonWinCtrls.ucTabControl tabAddresses;
		private System.Windows.Forms.TabPage tpMemberAddresses;
		private CommonWinCtrls.ucTextBox txtContactDsc;
		private CommonWinCtrls.ucTextBox txtAddressee;
	}
}