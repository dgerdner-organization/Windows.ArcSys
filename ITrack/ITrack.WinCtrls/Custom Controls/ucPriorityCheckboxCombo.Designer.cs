namespace ASL.ITrack.WinCtrls
{
	partial class ucPriorityCheckboxCombo
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
			Janus.Windows.GridEX.GridEXLayout ucPriorityCheckboxCombo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPriorityCheckboxCombo));
			this.SuspendLayout();
			// 
			// ucPriorityCheckboxCombo
			// 
			this.CodeColumn = "Code";
			this.DescriptionColumn = "Description";
			ucPriorityCheckboxCombo_DesignTimeLayout.LayoutString = resources.GetString("ucPriorityCheckboxCombo_DesignTimeLayout.LayoutString");
			this.DesignTimeLayout = ucPriorityCheckboxCombo_DesignTimeLayout;
			this.DropDownDisplayMember = "Code";
			this.DropDownValueMember = "Code";
			this.ValueColumn = "Code";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
