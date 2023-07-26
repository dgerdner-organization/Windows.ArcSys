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
	/// <summary>ITrack version of ucMultiColumnCombo for groups</summary>
	public partial class ucGroupCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsGroup object</summary>
		[Browsable(false)]
		public ClsGroup SelectedGroup
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return ( drv != null ) ? new ClsGroup(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected group code</summary>
		[Browsable(false)]
		public string SelectedGroupCD
		{
			get
			{
				ClsGroup item = SelectedGroup;
				return ( item != null ) ? item.Group_Cd : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucGroupCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Group_Cd");
			c.DataMember = "Group_Cd";
			c.Caption = "Group";
			c.Width = 150;

			c = DropDownList.Columns.Add("Group_Dsc");
			c.DataMember = "Group_Dsc";
			c.Caption = "Group Name";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsGroup.GetAll(true);
			ClsConnection.AddColumns(Table, "Group_Cd", "Group_Dsc");
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