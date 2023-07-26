using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack version of ucMultiColumnCombo for projects</summary>
	public partial class ucProjectCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsProject object</summary>
		[Browsable(false)]
		public ClsProject SelectedProject
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return ( drv != null ) ? new ClsProject(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected project code</summary>
		[Browsable(false)]
		public string SelectedProjectCD
		{
			get
			{
				ClsProject item = SelectedProject;
				return ( item != null ) ? item.Project_Cd : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucProjectCombo()
		{
			InitializeComponent();

			SetTable();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTable();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Project_Cd");
			c.DataMember = "Project_Cd";
			c.Caption = "Project";
			c.Width = 150;

			c = DropDownList.Columns.Add("Project_Nm");
			c.DataMember = "Project_Nm";
			c.Caption = "Project Name";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsProject.GetAll(true);
			ClsConnection.AddColumns(Table, "Project_Cd", "Project_Nm");
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			try
			{
				if( NotInList == true )
				{
					e.Cancel = true;
					Display.ShowError("ITrack", "Specified item is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}