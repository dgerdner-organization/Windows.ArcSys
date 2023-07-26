using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.WinCtrls
{
	/// <summary>ArcSys version of ucMultiColumnCombo for Actions</summary>
	public partial class ucActionCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsAction object</summary>
		[Browsable(false)]
		public ClsAction SelectedAction
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsAction(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected Action code</summary>
		[Browsable(false)]
		public string SelectedActionCD
		{
			get
			{
				ClsAction item = SelectedAction;
				return (item != null) ? item.Action_Cd : null;
			}
		}

		/// <summary>Gets the selected Action description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsAction item = SelectedAction;
				return (item != null) ? item.Action_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucActionCombo()
		{
			InitializeComponent();

			SetTableSource();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTableSource();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Action_Cd");
			c.DataMember = "Action_Cd";
			c.Caption = "Action";
			c.Visible = false;

			c = DropDownList.Columns.Add("Action_Dsc");
			c.DataMember = "Action_Dsc";
			c.Caption = "Name";
			c.Width = 250;

			c = DropDownList.Columns.Add("Active_Flg");
			c.DataMember = "Active_Flg";
			c.Caption = "Active";
			c.Visible = false;
			c.Width = 65;
			c.HeaderAlignment = TextAlignment.Center;
			c.ColumnType = ColumnType.CheckBox;
			c.EditType = EditType.CheckBox;
			c.CheckBoxTrueValue = "Y";
			c.CheckBoxFalseValue = "N";

			DropDownList.VisibleRows = 20;
			// Set in designer
			//SortType = ComboSortType.Description;
			//DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsAction.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Action_Cd", "Action_Dsc");

			if (Table != null)
			{
				Table.Dispose();
				Table = null;
			}

			Table = dt;
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
					Display.ShowError("ArcSys", "Specified Action is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ArcSys", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}