namespace CS2010.ArcSys.WinCtrls
{
	partial class ucUnitTypeCombo
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
			Janus.Windows.GridEX.GridEXLayout ucUnitTypeCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUnitTypeCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucUnitTypeCombo
			// 
			this.CodeColumn = "Unit_Type_Cd";
			this.DescriptionColumn = "Unit_Type_Dsc";
			ucUnitTypeCombo_DesignTimeLayout.LayoutString = resources.GetString("ucUnitTypeCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucUnitTypeCombo_DesignTimeLayout;
			this.DisplayMember = "Unit_Type_Cd";
			this.ValueColumn = "Unit_Type_Cd";
			this.ValueMember = "Unit_Type_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}