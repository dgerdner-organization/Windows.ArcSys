namespace CS2010.ArcSys.WinCtrls
{
	partial class ucCargoStatusCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucCargoStatusCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCargoStatusCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucCargoStatusCheckBoxCombo
			// 
			this.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.CodeColumn = "Cargo_Status_Cd";
			this.ContextMenuStrip = null;
			this.DescriptionColumn = "Cargo_Status_Dsc";
			ucCargoStatusCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucCargoStatusCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucCargoStatusCheckBoxCombo_DesignTimeLayout;
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.DropDownDisplayMember = "Cargo_Status_Dsc";
			this.DropDownValueMember = "Cargo_Status_Cd";
			this.ShowContextMenu = false;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.None;
			this.ValueColumn = "Cargo_Status_Cd";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
