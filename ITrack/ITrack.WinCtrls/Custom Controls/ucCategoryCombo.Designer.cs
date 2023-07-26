namespace ASL.ITrack.WinCtrls
{
	partial class ucCategoryCombo
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
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCategoryCombo));
			( (System.ComponentModel.ISupportInitialize)( this ) ).BeginInit();
			this.SuspendLayout();
			// 
			// ucCategoryCombo
			// 
			this.CodeColumn = "Category_Cd";
			this.DescriptionColumn = "Category_Nm";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.DesignTimeLayout = gridEXLayout1;
			this.DisplayMember = "Category_Cd";
			this.ValueColumn = "Category_Cd";
			this.ValueMember = "Category_Cd";
			( (System.ComponentModel.ISupportInitialize)( this ) ).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
