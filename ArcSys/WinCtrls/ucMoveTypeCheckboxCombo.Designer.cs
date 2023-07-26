namespace CS2010.ArcSys.WinCtrls
{
	partial class ucMoveTypeCheckBoxCombo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMoveTypeCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucMoveTypeCheckBoxCombo
			// 
			this.CodeColumn = "Code";
			this.DescriptionColumn = "Description";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.DesignTimeLayout = gridEXLayout1;
			this.DropDownDisplayMember = "Code";
			this.DropDownValueMember = "Code";
			this.ValueColumn = "Code";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
