namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVendorMoveCombo
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
			Janus.Windows.GridEX.GridEXLayout ucVendorMoveCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVendorMoveCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucVendorMoveCombo
			// 
			this.CodeColumn = "Vendor_Move_ID";
			this.DescriptionColumn = "Extra_Dsc";
			ucVendorMoveCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVendorMoveCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucVendorMoveCombo_DesignTimeLayout;
			this.DisplayMember = "Extra_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.ValueColumn = "Vendor_Move_ID";
			this.ValueMember = "Vendor_Move_ID";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}