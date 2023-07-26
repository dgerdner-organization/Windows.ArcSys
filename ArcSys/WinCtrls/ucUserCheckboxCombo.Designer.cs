namespace CS2010.ArcSys.WinCtrls
{
	partial class ucUserCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucUserCheckBoxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucUserCheckBoxCombo
			// 
			this.CodeColumn = "User_Login";
			this.ContextMenuStrip = null;
			this.DescriptionColumn = "First_Nm";
			ucUserCheckBoxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucUserCheckBoxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucUserCheckBoxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "User_Login";
			this.DropDownValueMember = "User_Login";
			this.ShowContextMenu = false;
			this.ValueColumn = "User_Login";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
