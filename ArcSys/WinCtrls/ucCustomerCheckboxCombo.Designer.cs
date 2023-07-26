namespace CS2010.ArcSys.WinCtrls
{
	partial class ucCustomerCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucCustomerCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCustomerCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucCustomerCheckBoxCombo
			// 
			this.CodeColumn = "Customer_Cd";
			this.DescriptionColumn = "Customer_Nm";
			ucCustomerCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucCustomerCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucCustomerCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Customer_Cd";
			this.DropDownValueMember = "Customer_Cd";
			this.ValueColumn = "Customer_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
