namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVesselCombo
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
			Janus.Windows.GridEX.GridEXLayout ucVesselCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVesselCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucVesselCombo
			// 
			this.CodeColumn = "Vessel_Cd";
			this.DescriptionColumn = "Vessel_Nm";
			ucVesselCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVesselCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucVesselCombo_DesignTimeLayout;
			this.DisplayMember = "Vessel_Cd";
			this.ValueColumn = "Vessel_Cd";
			this.ValueMember = "Vessel_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}