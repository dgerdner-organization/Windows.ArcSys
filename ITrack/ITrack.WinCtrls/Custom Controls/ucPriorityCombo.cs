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
	/// <summary>ITrack version of ucMultiColumnCombo for priorities</summary>
	public partial class ucPriorityCombo : ucMultiColumnCombo
	{
		#region Fields

		private bool IsLoadingDataSource;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets the selected priority code</summary>
		[Browsable(false)]
		public string SelectedPriorityCD
		{
			get
			{
				ComboItem ci = SelectedItem as ComboItem;
				return ( ci != null ) ? ci.Code : null;
			}
		}

		[Browsable(false)]
		public string SelectedPriorityDsc
		{
			get
			{
				ComboItem ci = SelectedItem as ComboItem;
				return (ci != null) ? ci.Description : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucPriorityCombo()
		{
			InitializeComponent();

			IsLoadingDataSource = false;

			SetTable();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			SetTable();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Code");
			c.DataMember = "Code";
			c.Caption = "Priority";
			c.Width = 150;

			c = DropDownList.Columns.Add("Description");
			c.DataMember = "Description";
			c.Caption = "Description";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			try
			{
				IsLoadingDataSource = true;
				base.DataSource = null;
				base.DataSource = ClsIssue.GetPriorities();
			}
			finally
			{
				IsLoadingDataSource = false;
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
			if( IsLoadingDataSource ) base.SetDataSource(aValue);
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