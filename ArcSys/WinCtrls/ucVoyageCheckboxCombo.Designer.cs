namespace CS2010.ArcSys.WinCtrls
{
	partial class ucVoyageCheckBoxCombo
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
			Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVesselCheckBoxCombo));
			this.SuspendLayout();
			// 
			// ucVesselCheckBoxCombo
			// 
			this.CodeColumn = "Vessel_Cd";
			this.DescriptionColumn = "Vessel_Nm";
			gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
			this.DesignTimeLayout = gridEXLayout2;
			this.DropDownDisplayMember = "Vessel_Cd";
			this.DropDownValueMember = "Vessel_Cd";
			this.ValueColumn = "Vessel_Cd";
			this.ValuesDataMember = "";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	}
}
