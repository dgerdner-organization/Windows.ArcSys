namespace ASL.ITrack.WinCtrls
{
	partial class ucPriorityCombo
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
			Janus.Windows.GridEX.GridEXLayout ucPriorityCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPriorityCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucPriorityCombo
			// 
			this.CodeColumn = "Code";
			this.DescriptionColumn = "Description";
			ucPriorityCombo_DesignTimeLayout.LayoutString = resources.GetString("ucPriorityCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucPriorityCombo_DesignTimeLayout;
			this.DisplayMember = "Code";
			this.ValueColumn = "Code";
			this.ValueMember = "Code";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
