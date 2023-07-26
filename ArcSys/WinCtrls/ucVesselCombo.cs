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
	/// <summary>ArcSys version of ucMultiColumnCombo for vessels</summary>
	public partial class ucVesselCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsVessel object</summary>
		[Browsable(false)]
		public ClsVessel SelectedVessel
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsVessel(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected vessel code</summary>
		[Browsable(false)]
		public string SelectedVesselCD
		{
			get
			{
				ClsVessel item = SelectedVessel;
				return (item != null) ? item.Vessel_Cd : null;
			}
		}

		/// <summary>Gets the selected vessel name</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsVessel item = SelectedVessel;
				return (item != null) ? item.Vessel_Nm : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucVesselCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Vessel_Cd");
			c.DataMember = "Vessel_Cd";
			c.Caption = "Vessel";

			c = DropDownList.Columns.Add("Vessel_Nm");
			c.DataMember = "Vessel_Nm";
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
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsVessel.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Vessel_Cd", "Vessel_Nm");

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
					Display.ShowError("ArcSys", "Specified vessel is not in the list");
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