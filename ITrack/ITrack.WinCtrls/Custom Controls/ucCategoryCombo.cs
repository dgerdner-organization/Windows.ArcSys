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
	/// <summary>ITrack version of ucMultiColumnCombo for categories</summary>
	public partial class ucCategoryCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsCategory object</summary>
		[Browsable(false)]
		public ClsCategory SelectedCategory
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return ( drv != null ) ? new ClsCategory(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected category code</summary>
		[Browsable(false)]
		public string SelectedCategoryCD
		{
			get
			{
				ClsCategory item = SelectedCategory;
				return ( item != null ) ? item.Category_Cd : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCategoryCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Category_Cd");
			c.DataMember = "Category_Cd";
			c.Caption = "Category";
			c.Width = 150;

			c = DropDownList.Columns.Add("Category_Nm");
			c.DataMember = "Category_Nm";
			c.Caption = "Category Name";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsCategory.GetAll(true);
			ClsConnection.AddColumns(Table, "Category_Cd", "Category_Nm");
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