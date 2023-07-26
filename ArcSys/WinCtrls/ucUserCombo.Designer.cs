namespace CS2010.ArcSys.WinCtrls
{
	partial class ucUserCombo
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
			Janus.Windows.GridEX.GridEXLayout ucUserCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUserCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucUserCombo
			// 
			this.CodeColumn = "User_Login";
			this.ContextMenuStrip = null;
			this.DescriptionColumn = "First_Nm";
			ucUserCombo_DesignTimeLayout.LayoutString = resources.GetString("ucUserCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucUserCombo_DesignTimeLayout;
			this.DisplayMember = "User_Login";
			this.ShowContextMenu = false;
			this.ValueColumn = "User_Login";
			this.ValueMember = "User_Login";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}