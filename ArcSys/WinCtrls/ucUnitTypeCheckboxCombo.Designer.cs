namespace CS2010.ArcSys.WinCtrls
{
	partial class ucUnitTypeCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucUnitTypeCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUnitTypeCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucUnitTypeCheckBoxCombo
			// 
			this.CodeColumn = "Unit_Type_Cd";
			this.DescriptionColumn = "Unit_Type_Dsc";
			ucUnitTypeCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucUnitTypeCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucUnitTypeCheckBoxCombo_DesignTimeLayout;
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionPlusCode;
			this.DropDownDisplayMember = "Unit_Type_DscUnit_Type_Cd";
			this.DropDownValueMember = "Unit_Type_Cd";
			this.ValueColumn = "Unit_Type_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
