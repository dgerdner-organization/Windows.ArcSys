namespace CS2010.ArcSys.WinCtrls
{
	partial class ucCargoStatusCombo
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
			Janus.Windows.GridEX.GridEXLayout ucCargoStatusCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCargoStatusCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucCargoStatusCombo
			// 
			this.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.CodeColumn = "Cargo_Status_Cd";
			this.DescriptionColumn = "Cargo_Status_Dsc";
			ucCargoStatusCombo_DesignTimeLayout.LayoutString = resources.GetString("ucCargoStatusCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucCargoStatusCombo_DesignTimeLayout;
			this.DisplayMember = "Cargo_Status_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.None;
			this.ValueColumn = "Cargo_Status_Cd";
			this.ValueMember = "Cargo_Status_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}