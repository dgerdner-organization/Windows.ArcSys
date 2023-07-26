using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack version of ucCheckedComboBox for projects</summary>
	public partial class ucProjectCheckboxCombo : ucCheckedComboBox
	{
		#region Properties

		/// <summary>Gets a list of checked ClsProject objects</summary>
		[Browsable(false)]
		public List<ClsProject> CheckedProjects
		{
			get
			{
				List<ClsProject> lst = new List<ClsProject>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
						if( drv != null && drv.Row != null )
							lst.Add(new ClsProject(drv.Row));
				}

				return lst;
			}
		}

		/// <summary>Gets a list of checked project codes</summary>
		[Browsable(false)]
		public List<string> CheckedProjectCDs
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsProject item = new ClsProject(drv.Row);
						if( string.IsNullOrEmpty(item.Project_Cd) == false )
							lst.Add(item.Project_Cd);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of project codes</summary>
		[Browsable(false)]
		public string ProjectCDs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsProject item = new ClsProject(drv.Row);
						if( string.IsNullOrEmpty(item.Project_Cd) == false )
							sb.AppendFormat("{0}'{1}'",
								( sb.Length > 0 ? ", " : null ), item.Project_Cd);
					}
				}

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucProjectCheckboxCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Selector");
			c.DataMember = "Project_Cd";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("Project_Cd");
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
			base.OnValidating(e);
			try
			{
				if( CheckedItems != null )
				{
					foreach( object obj in CheckedItems )
					{
						if( obj == null )
						{
							e.Cancel = true;
							Display.ShowError("ITrack", "One or more items are invalid");
							break;
						}
					}
				}
				if( e.Cancel == false && DroppedDown == true ) e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
		}
		#endregion		// #region Overrides
	}
}