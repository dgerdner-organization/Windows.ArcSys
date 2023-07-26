namespace ASL.ITrack.WinCtrls
{
	partial class ucReleaseCombo
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
			Janus.Windows.GridEX.GridEXLayout ucReleaseCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReleaseCombo));
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// ucReleaseCombo
			// 
			this.CodeColumn = "Code";
			this.DescriptionColumn = "Description";
			ucReleaseCombo_DesignTimeLayout.LayoutString = resources.GetString("ucReleaseCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucReleaseCombo_DesignTimeLayout;
			this.DisplayMember = "Code";
			this.ValueColumn = "Description";
			this.ValueMember = "Description";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
