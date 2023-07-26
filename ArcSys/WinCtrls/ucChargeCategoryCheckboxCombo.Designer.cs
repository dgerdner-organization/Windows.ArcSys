namespace CS2010.ArcSys.WinCtrls
{
	partial class ucChargeCategoryCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucChargeCategoryCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChargeCategoryCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucChargeCategoryCheckBoxCombo
			// 
			this.CodeColumn = "Charge_Category_Cd";
			this.DescriptionColumn = "Charge_Category_Dsc";
			ucChargeCategoryCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucChargeCategoryCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucChargeCategoryCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Charge_Category_Cd";
			this.DropDownValueMember = "Charge_Category_Cd";
			this.ValueColumn = "Charge_Category_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
