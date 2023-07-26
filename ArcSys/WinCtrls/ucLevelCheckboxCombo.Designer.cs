namespace CS2010.ArcSys.WinCtrls
{
	partial class ucLevelCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucLevelCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLevelCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucLevelCheckBoxCombo
			// 
			this.CodeColumn = "Level_Cd";
			this.DescriptionColumn = "Level_Dsc";
			ucLevelCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucLevelCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucLevelCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Level_Cd";
			this.DropDownValueMember = "Level_Cd";
			this.ValueColumn = "Level_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
