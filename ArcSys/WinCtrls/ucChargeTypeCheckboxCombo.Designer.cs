namespace CS2010.ArcSys.WinCtrls
{
	partial class ucChargeTypeCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucChargeTypeCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChargeTypeCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucChargeTypeCheckBoxCombo
			// 
			this.CodeColumn = "Charge_Type_Cd";
			this.DescriptionColumn = "Charge_Type_Dsc";
			ucChargeTypeCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucChargeTypeCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucChargeTypeCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Charge_Type_Cd";
			this.DropDownValueMember = "Charge_Type_Cd";
			this.ValueColumn = "Charge_Type_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
