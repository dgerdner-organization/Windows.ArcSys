namespace CS2010.ArcSys.WinCtrls
{
	partial class ucCustomerCombo
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
			Janus.Windows.GridEX.GridEXLayout ucCustomerCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCustomerCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucCustomerCombo
			// 
			this.CodeColumn = "Customer_Cd";
			this.DescriptionColumn = "Customer_Nm";
			ucCustomerCombo_DesignTimeLayout.LayoutString = resources.GetString("ucCustomerCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucCustomerCombo_DesignTimeLayout;
			this.DisplayMember = "Customer_Cd";
			this.ValueColumn = "Customer_Cd";
			this.ValueMember = "Customer_Cd";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}