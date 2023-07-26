namespace CS2010.ArcSys.WinCtrls
{
	partial class ucMoveCombo
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
			Janus.Windows.GridEX.GridEXLayout ucMoveCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMoveCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucMoveCombo
			// 
			this.CodeColumn = "Move_ID";
			this.DescriptionColumn = "Move_Dsc";
			ucMoveCombo_DesignTimeLayout.LayoutString = resources.GetString("ucMoveCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucMoveCombo_DesignTimeLayout;
			this.DisplayMember = "Move_Dsc";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.ValueColumn = "Move_ID";
			this.ValueMember = "Move_ID";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}