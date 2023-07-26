namespace CS2010.ArcSys.WinCtrls
{
	partial class ucLevelUnitCombo
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
			Janus.Windows.GridEX.GridEXLayout ucLevelUnitCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLevelUnitCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucLevelUnitCombo
			// 
			this.CodeColumn = "Level_Unit_ID";
			this.DescriptionColumn = "Level_Unit_Dsc";
			ucLevelUnitCombo_DesignTimeLayout.LayoutString = resources.GetString("ucLevelUnitCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucLevelUnitCombo_DesignTimeLayout;
			this.DisplayMember = "Level_Unit_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.ValueColumn = "Level_Unit_ID";
			this.ValueMember = "Level_Unit_ID";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}