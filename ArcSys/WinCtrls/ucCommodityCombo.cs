using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.WinCtrls
{
	/// <summary>ArcSys version of ucMultiColumnCombo for Commoditys</summary>
	public partial class ucCommodityCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsCommodity object</summary>
		[Browsable(false)]
		public ClsCommodityDsc SelectedCommodity
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsCommodityDsc(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected Commodity code</summary>
		[Browsable(false)]
		public string SelectedCommodityCD
		{
			get
			{
				ClsCommodityDsc item = SelectedCommodity;
				return (item != null) ? item.Commodity_Cd : null;
			}
		}

		/// <summary>Gets the selected Commodity description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsCommodityDsc item = SelectedCommodity;
				return (item != null) ? item.Commodity_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCommodityCombo()
		{
			InitializeComponent();

            //_VendorLimited = false;
            //_PortsOnly = false;

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
            GridEXColumn c = DropDownList.Columns.Add("Commodity_Cd");
            c.DataMember = "Commodity_Cd";
            c.Caption = "Code";
            c.Width = 100;
            
            c = DropDownList.Columns.Add("Commodity_Dsc");
			c.DataMember = "Commodity_Dsc";
			c.Caption = "Commodity";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
			// Set in designer SortType = ComboSortType.Description;
			// DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsCommodityDsc.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Commodity_Cd", "Commodity_Dsc");

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
					Display.ShowError("ArcSys", "Specified Commodity is not in the list");
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