namespace CS2010.ArcSys.WinCtrls
{
	partial class ucLevelCombo
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
			Janus.Windows.GridEX.GridEXLayout ucLevelCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLevelCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucLevelCombo
			// 
			this.CodeColumn = "Level_Cd";
			this.DescriptionColumn = "Level_Dsc";
			ucLevelCombo_DesignTimeLayout.LayoutString = resources.GetString("ucLevelCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucLevelCombo_DesignTimeLayout;
			this.DisplayMember = "Level_Cd";
			this.ValueColumn = "Level_Cd";
			this.ValueMember = "Level_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}