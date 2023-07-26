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
	/// <summary>ArcSys version of ucMultiColumnCombo for charge RecallStatuss</summary>
	public partial class ucRecallStatusCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsRecallStatus object</summary>
		[Browsable(false)]
		public ClsRecallStatus SelectedRecallStatus
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsRecallStatus(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected RecallStatus code</summary>
		[Browsable(false)]
		public string SelectedRecallStatusCD
		{
			get
			{
				ClsRecallStatus item = SelectedRecallStatus;
				return (item != null) ? item.Recall_Status_Cd : null;
			}
		}

		/// <summary>Gets the selected charge RecallStatus description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsRecallStatus item = SelectedRecallStatus;
				return (item != null) ? item.Recall_Status_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucRecallStatusCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Recall_Status_Cd");
			c.DataMember = "Recall_Status_Cd";
			c.Caption = "Recall_Status";

			c = DropDownList.Columns.Add("Recall_Status_Dsc");
			c.DataMember = "Recall_Status_Dsc";
			c.Caption = "Description";
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
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsRecallStatus.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Recall_Status_Cd", "Recall_Status_Dsc");

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
					Display.ShowError("ArcSys", "Specified charge Recall Status is not in the list");
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