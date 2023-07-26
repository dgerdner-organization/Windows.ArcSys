namespace CS2010.ArcSys.WinCtrls
{
	partial class ucGeoRegionCombo
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
			Janus.Windows.GridEX.GridEXLayout ucGeoRegionCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGeoRegionCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucGeoRegionCombo
			// 
			this.CodeColumn = "Geo_Region_Cd";
			this.DescriptionColumn = "Geo_Region_Dsc";
			ucGeoRegionCombo_DesignTimeLayout.LayoutString = resources.GetString("ucGeoRegionCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucGeoRegionCombo_DesignTimeLayout;
			this.DisplayMember = "Geo_Region_Cd";
			this.ValueColumn = "Geo_Region_Cd";
			this.ValueMember = "Geo_Region_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}