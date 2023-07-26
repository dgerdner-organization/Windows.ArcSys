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
	/// <summary>ITrack version of ucMultiColumnCombo for statuses</summary>
	public partial class ucStatusCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsStatus object</summary>
		[Browsable(false)]
		public ClsStatus SelectedStatus
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return ( drv != null ) ? new ClsStatus(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected status code</summary>
		[Browsable(false)]
		public string SelectedStatusCD
		{
			get
			{
				ClsStatus item = SelectedStatus;
				return ( item != null ) ? item.Status_Cd : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucStatusCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Status_Cd");
			c.DataMember = "Status_Cd";
			c.Caption = "Status";
			c.Width = 150;

			c = DropDownList.Columns.Add("Status_Dsc");
			c.DataMember = "Status_Dsc";
			c.Caption = "Status Description";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsStatus.GetAll(true);
			ClsConnection.AddColumns(Table, "Status_Cd", "Status_Dsc");
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