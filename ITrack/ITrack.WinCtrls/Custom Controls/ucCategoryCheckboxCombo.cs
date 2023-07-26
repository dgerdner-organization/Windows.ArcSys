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
	/// <summary>ITrack version of ucCheckedComboBox for categories</summary>
	public partial class ucCategoryCheckboxCombo : ucCheckedComboBox
	{
		#region Properties

		/// <summary>Gets a list of checked ClsCategory objects</summary>
		[Browsable(false)]
		public List<ClsCategory> CheckedCategories
		{
			get
			{
				List<ClsCategory> lst = new List<ClsCategory>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
						if( drv != null && drv.Row != null )
							lst.Add(new ClsCategory(drv.Row));
				}

				return lst;
			}
		}

		/// <summary>Gets a list of checked category codes</summary>
		[Browsable(false)]
		public List<string> CheckedCategoryCDs
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsCategory item = new ClsCategory(drv.Row);
						if( string.IsNullOrEmpty(item.Category_Cd) == false )
							lst.Add(item.Category_Cd);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of category codes</summary>
		[Browsable(false)]
		public string CategoryCDs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsCategory item = new ClsCategory(drv.Row);
						if( string.IsNullOrEmpty(item.Category_Cd) == false )
							sb.AppendFormat("{0}'{1}'",
								( sb.Length > 0 ? ", " : null ), item.Category_Cd);
					}
				}

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCategoryCheckboxCombo()
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
			c.DataMember = "Category_Cd";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("Category_Cd");
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