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
	/// <summary>ArcSys version of ucMultiColumnCombo for cargo statuses</summary>
	public partial class ucCargoStatusCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsCargoStatus object</summary>
		[Browsable(false)]
		public ClsCargoStatus SelectedCargoStatus
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsCargoStatus(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected cargo status code</summary>
		[Browsable(false)]
		public string SelectedCargoStatusCD
		{
			get
			{
				ClsCargoStatus item = SelectedCargoStatus;
				return (item != null) ? item.Cargo_Status_Cd : null;
			}
		}

		/// <summary>Gets the selected cargo status description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsCargoStatus item = SelectedCargoStatus;
				return (item != null) ? item.Cargo_Status_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCargoStatusCombo()
		{
			InitializeComponent();

			SetTableSource();

			CreateStructure();

			DropDownList.FormattingRow += new RowLoadEventHandler(DropDownList_FormattingRow);
		}

		private void DropDownList_FormattingRow(object sender, RowLoadEventArgs e)
		{
			try
			{
				if (e.Row == null || e.Row.DataRow == null) return;

				DataRowView drv = e.Row.DataRow as DataRowView;
				DataRow dr = (drv != null) ? drv.Row : e.Row.DataRow as DataRow;
				if (dr == null || e.Row.Cells == null || e.Row.Cells.Count <= 0) return;

				string dsc = ClsConvert.ToString(dr["Extra_Dsc"]);
				e.Row.Cells["Cargo_Status_Dsc"].ToolTipText = dsc;
				e.Row.Cells["Extra_Dsc"].ToolTipText = dsc;
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
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
			GridEXColumn c = DropDownList.Columns.Add("Cargo_Status_Cd");
			c.DataMember = "Cargo_Status_Cd";
			c.Caption = "Cargo Status";
			c.Visible = false;

			c = DropDownList.Columns.Add("Cargo_Status_Dsc");
			c.DataMember = "Cargo_Status_Dsc";
			c.Caption = "Description";
			c.Width = 125;
			c.CellToolTip = CellToolTip.FetchToolTipText;

			c = DropDownList.Columns.Add("Sequence_Nbr");
			c.DataMember = "Sequence_Nbr";
			c.Caption = "Seq";
			c.Width = 50;

			c = DropDownList.Columns.Add("Extra_Dsc");
			c.DataMember = "Extra_Dsc";
			c.Caption = "Info";
			c.Width = 500;

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
			//SortType = ComboSortType.None;
			//DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsCargoStatus.GetStatuses();
			if (dt != null) ClsConnection.AddColumns(dt, "CARGO_STATUS_CD", "CARGO_STATUS_DSC");

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
					Display.ShowError("ArcSys", "Specified status is not in the list");
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