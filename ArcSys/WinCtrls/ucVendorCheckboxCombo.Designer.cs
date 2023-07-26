namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVendorCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucVendorCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVendorCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucVendorCheckBoxCombo
			// 
			this.CodeColumn = "Vendor_Cd";
			this.DescriptionColumn = "Vendor_Nm";
			ucVendorCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVendorCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucVendorCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Vendor_Cd";
			this.DropDownValueMember = "Vendor_Cd";
			this.ValueColumn = "Vendor_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
