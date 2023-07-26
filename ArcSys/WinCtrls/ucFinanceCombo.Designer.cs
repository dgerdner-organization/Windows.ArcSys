namespace CS2010.ArcSys.WinCtrls
{
	partial class ucFinanceCombo
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
			Janus.Windows.GridEX.GridEXLayout ucFinanceCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFinanceCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucFinanceCombo
			// 
			this.CodeColumn = "Finance_Cd";
			this.DescriptionColumn = "Finance_Dsc";
			ucFinanceCombo_DesignTimeLayout.LayoutString = resources.GetString("ucFinanceCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucFinanceCombo_DesignTimeLayout;
			this.DisplayMember = "Finance_Cd";
			this.ValueColumn = "Finance_Cd";
			this.ValueMember = "Finance_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}