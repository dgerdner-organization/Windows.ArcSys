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
	/// <summary>ArcSys version of ucMultiColumnCombo for finance codes</summary>
	public partial class ucFinanceCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsFinance object</summary>
		[Browsable(false)]
		public ClsFinance SelectedFinance
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsFinance(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected finance code</summary>
		[Browsable(false)]
		public string SelectedFinanceCD
		{
			get
			{
				ClsFinance item = SelectedFinance;
				return (item != null) ? item.Finance_Cd : null;
			}
		}

		/// <summary>Gets the selected finance description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsFinance item = SelectedFinance;
				return (item != null) ? item.Finance_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucFinanceCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Finance_Cd");
			c.DataMember = "Finance_Cd";
			c.Caption = "Finance Code";

			c = DropDownList.Columns.Add("Finance_Dsc");
			c.DataMember = "Finance_Dsc";
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

			DataTable dt = ClsFinance.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Finance_CD", "Finance_DSC");

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
					Display.ShowError("ArcSys", "Specified finance code is not in the list");
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