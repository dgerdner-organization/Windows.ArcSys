namespace CS2010.ArcSys.WinCtrls
{
	partial class ucConveyanceTypeCombo
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
			Janus.Windows.GridEX.GridEXLayout ucConveyanceTypeCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConveyanceTypeCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucConveyanceTypeCombo
			// 
			this.CodeColumn = "Conveyance_Type_Cd";
			this.DescriptionColumn = "Conveyance_Type_Dsc";
			ucConveyanceTypeCombo_DesignTimeLayout.LayoutString = resources.GetString("ucConveyanceTypeCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucConveyanceTypeCombo_DesignTimeLayout;
			this.DisplayMember = "Conveyance_Type_Cd";
			this.ValueColumn = "Conveyance_Type_Cd";
			this.ValueMember = "Conveyance_Type_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}