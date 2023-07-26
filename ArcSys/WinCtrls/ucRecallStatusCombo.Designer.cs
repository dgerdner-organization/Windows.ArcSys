namespace CS2010.ArcSys.WinCtrls
{
	partial class ucRecallStatusCombo
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
			Janus.Windows.GridEX.GridEXLayout ucRecallStatusCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecallStatusCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucRecallStatusCombo
			// 
			this.CodeColumn = "Recall_Status_Cd";
			this.DescriptionColumn = "Recall_Status_Dsc";
			ucRecallStatusCombo_DesignTimeLayout.LayoutString = resources.GetString("ucRecallStatusCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucRecallStatusCombo_DesignTimeLayout;
			this.DisplayMember = "Recall_Status_Dsc";
			this.ValueColumn = "Recall_Status_Cd";
			this.ValueMember = "Recall_Status_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}