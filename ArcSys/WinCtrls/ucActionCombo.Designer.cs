namespace CS2010.ArcSys.WinCtrls
{
	partial class ucActionCombo
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
			Janus.Windows.GridEX.GridEXLayout ucActionCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucActionCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucActionCombo
			// 
			this.CodeColumn = "Action_Cd";
			this.DescriptionColumn = "Action_Dsc";
			ucActionCombo_DesignTimeLayout.LayoutString = resources.GetString("ucActionCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucActionCombo_DesignTimeLayout;
			this.DisplayMember = "Action_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.ValueColumn = "Action_Cd";
			this.ValueMember = "Action_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}