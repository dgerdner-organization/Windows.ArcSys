namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVoyageLocationCombo
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
			Janus.Windows.GridEX.GridEXLayout ucVoyageLocationCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLocationCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucLocationCombo
			// 
			this.CodeColumn = "Location_Cd";
			this.DescriptionColumn = "Location_Dsc";
			ucVoyageLocationCombo_DesignTimeLayout.LayoutString = resources.GetString("ucVoyageLocationCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucVoyageLocationCombo_DesignTimeLayout;
			this.DisplayMember = "Location_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.ValueColumn = "Location_Cd";
			this.ValueMember = "Location_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}