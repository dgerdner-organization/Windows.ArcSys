namespace CS2010.ArcSys.WinCtrls
{
	partial class ucRecallRiskCombo
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
			Janus.Windows.GridEX.GridEXLayout ucRecallRiskCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecallRiskCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucRecallRiskCombo
			// 
			this.CodeColumn = "Recall_Risk_Cd";
			this.DescriptionColumn = "Recall_Risk_Dsc";
			ucRecallRiskCombo_DesignTimeLayout.LayoutString = resources.GetString("ucRecallRiskCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucRecallRiskCombo_DesignTimeLayout;
			this.DisplayMember = "Recall_Risk_Dsc";
			this.ValueColumn = "Recall_Risk_Cd";
			this.ValueMember = "Recall_Risk_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}