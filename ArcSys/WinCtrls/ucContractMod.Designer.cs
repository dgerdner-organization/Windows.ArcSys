namespace CS2010.ArcSys.WinCtrls
{
	partial class ucContractModCombo
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
			Janus.Windows.GridEX.GridEXLayout ucContractModCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucContractModCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucContractModCombo
			// 
			this.CodeColumn = "Mod_No";
			this.DescriptionColumn = "Attachment_Nm";
			ucContractModCombo_DesignTimeLayout.LayoutString = resources.GetString("ucContractModCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucContractModCombo_DesignTimeLayout;
			this.DisplayMember = "Mod_NoAttachment_Nm";
			this.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.ValueColumn = "Contract_Mod_ID";
			this.ValueMember = "Contract_Mod_ID";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}