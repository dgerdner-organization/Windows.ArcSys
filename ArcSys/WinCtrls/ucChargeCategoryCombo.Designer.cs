namespace CS2010.ArcSys.WinCtrls
{
	partial class ucChargeCategoryCombo
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
			Janus.Windows.GridEX.GridEXLayout ucChargeCategoryCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChargeCategoryCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucChargeCategoryCombo
			// 
			this.CodeColumn = "Charge_Category_Cd";
			this.DescriptionColumn = "Charge_Category_Dsc";
			ucChargeCategoryCombo_DesignTimeLayout.LayoutString = resources.GetString("ucChargeCategoryCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucChargeCategoryCombo_DesignTimeLayout;
			this.DisplayMember = "Charge_Category_Cd";
			this.ValueColumn = "Charge_Category_Cd";
			this.ValueMember = "Charge_Category_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}