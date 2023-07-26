namespace CS2010.ArcSys.WinCtrls
{
    partial class ucLineServiceCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucServiceCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLineServiceCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucServiceCheckBoxCombo
			// 
			this.CodeColumn = "SERVICE_CD";
			this.DescriptionColumn = "SERVICE_DSC";
			ucServiceCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucServiceCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucServiceCheckBoxCombo_DesignTimeLayout;
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.DropDownDisplayMember = "SERVICE_CD";
			this.DropDownValueMember = "SERVICE_CD";
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.ValueColumn = "SERVICE_CD";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
