namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVendorCombo
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
			Janus.Windows.GridEX.GridEXLayout ucVendorCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVendorCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucVendorCombo
			// 
			this.CodeColumn = "Vendor_Cd";
			this.DescriptionColumn = "Vendor_Nm";
			ucVendorCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVendorCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucVendorCombo_DesignTimeLayout;
			this.DisplayMember = "Vendor_Cd";
			this.ValueColumn = "Vendor_Cd";
			this.ValueMember = "Vendor_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}