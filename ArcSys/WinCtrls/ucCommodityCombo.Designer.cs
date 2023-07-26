namespace CS2010.ArcSys.WinCtrls
{
    partial class ucCommodityCombo
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
            Janus.Windows.GridEX.GridEXLayout cmbCommodityCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLocationCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucLocationCombo
			// 
			this.CodeColumn = "Commodity_Cd";
            this.DescriptionColumn = "Commodity_Dsc";
            cmbCommodityCombo_DesignTimeLayout.LayoutString = resources.GetString("cmbCommodityCombo_DesignTimeLayout.LayoutString");
            this.DesignTimeLayout = cmbCommodityCombo_DesignTimeLayout;
            this.DisplayMember = "Commodity_Cd";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.ValueColumn = "Commodity_Cd";
            this.ValueMember = "Commodity_Cd";
            this.DisplayType = CommonWinCtrls.ComboDisplay.CodePlusDescription;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}