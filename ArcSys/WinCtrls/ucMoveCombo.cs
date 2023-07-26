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
	/// <summary>ArcSys version of ucMultiColumnCombo for Moves</summary>
	public partial class ucMoveCombo : ucMultiColumnCombo
	{
		#region Properties

		public bool _ValidateMoveExists;
		/// <summary>Gets/Sets whether we should validate that the move exists in the dropdown before exiting the field</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether we should validate that the move exists in the dropdown before exiting the field")]
		public bool ValidateMoveExists
		{
			get { return _ValidateMoveExists; }
			set { _ValidateMoveExists = value; }
		}

		/// <summary>Gets the selected ClsMove object</summary>
		[Browsable(false)]
		public ClsMove SelectedMove
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsMove(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected Move code</summary>
		[Browsable(false)]
		public long? SelectedMoveID
		{
			get
			{
				ClsMove item = SelectedMove;
				return (item != null) ? item.Move_ID : null;
			}
		}

		/// <summary>Gets the selected Move description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsMove item = SelectedMove;
				return (item != null) ? item.Move_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucMoveCombo()
		{
			InitializeComponent();

			_ValidateMoveExists = true;

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
			GridEXColumn c = DropDownList.Columns.Add("Move_ID");
			c.DataMember = "Move_ID";
			c.Caption = "Move";
			c.Visible = false;

			c = DropDownList.Columns.Add("Move_Dsc");
			c.DataMember = "Move_Dsc";
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
			SortType = ComboSortType.Description;
			DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsMove.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Move_ID", "Move_Dsc");

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
				if (ValidateMoveExists)
				{
					if (NotInList == true)
					{
						e.Cancel = true;
						Display.ShowError("ArcSys", "Specified Move is not in the list");
					}
					else if (DroppedDown == true)
						e.Cancel = true;
				}
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