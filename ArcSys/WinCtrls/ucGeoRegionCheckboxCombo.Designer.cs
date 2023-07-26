namespace CS2010.ArcSys.WinCtrls
{
	partial class ucGeoRegionCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucGeoRegionCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGeoRegionCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucGeoRegionCheckBoxCombo
			// 
			this.CodeColumn = "Geo_Region_Cd";
			this.DescriptionColumn = "Geo_Region_Dsc";
			ucGeoRegionCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucGeoRegionCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucGeoRegionCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Geo_Region_Cd";
			this.DropDownValueMember = "Geo_Region_Cd";
			this.ValueColumn = "Geo_Region_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
