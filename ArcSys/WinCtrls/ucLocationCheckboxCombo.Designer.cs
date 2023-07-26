namespace CS2010.ArcSys.WinCtrls
{
	partial class ucLocationCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucLocationCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLocationCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucLocationCheckBoxCombo
			// 
			this.CodeColumn = "Location_Cd";
			this.DescriptionColumn = "Location_Dsc";
			ucLocationCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucLocationCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucLocationCheckBoxCombo_DesignTimeLayout;
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.DropDownDisplayMember = "Location_Dsc";
			this.DropDownValueMember = "Location_Cd";
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.ValueColumn = "Location_Cd";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
