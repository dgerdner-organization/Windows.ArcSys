using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections.Generic;

namespace CS2010.ArcSys.WinCtrls
{
	[DefaultEvent("RowCopied")]
	public partial class ucUscRates : UserControl
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields/Properties

		[Description("Occurs when the user wants to transfer the rate to another " +
			"control on the form and double clicks a row in a grid")]
		public event EventHandler RowCopied;

		/// <summary>Returns the current grid (from the current tab)</summary>
		[Browsable(false)]
		public ucGridEx Grid { get; private set; }
		/// <summary>Returns the current row (from the current grid on the current tab)</summary>
		[Browsable(false)]
		public GridEXRow Row { get; private set; }
		[Browsable(false)]
		public decimal? Rate { get; private set; }
		[Browsable(false)]
		public long? Level_Unit_ID { get; private set; }

		private InheritableBoolean _AllowEdit;
		[DefaultValue(InheritableBoolean.False),
		Description("Gets/Sets whether the grids can be edited")]
		public InheritableBoolean AllowEdit
		{
			get { return _AllowEdit; }
			set
			{
				if (_AllowEdit == value) return;

				_AllowEdit = value;
				if (_AllowEdit == InheritableBoolean.True) ShowDistinctDropDowns = true;
				grdLinehaul.AllowEdit = grdMileageLH.AllowEdit =
					grdAssessorial.AllowEdit = grdOceanBB.AllowEdit =
					grdOceanCtr.AllowEdit = grdOceanRoute.AllowEdit = _AllowEdit;
				grdLinehaul.AllowAddNew = grdMileageLH.AllowAddNew =
					grdAssessorial.AllowAddNew = grdOceanBB.AllowAddNew =
					grdOceanCtr.AllowAddNew = grdOceanRoute.AllowAddNew = _AllowEdit;
			}
		}

		[Browsable(false)]
		public bool CanEdit { get { return AllowEdit.HasFlag(InheritableBoolean.True); } }

		private bool _ShowDistinctDropDowns;
		[DefaultValue(false),
		Description("Gets/Sets whether a drop down of distinct values will be shown for each column")]
		public bool ShowDistinctDropDowns
		{
			get { return _ShowDistinctDropDowns; }
			set
			{
				if (_AllowEdit == InheritableBoolean.True)
				{
					if (_ShowDistinctDropDowns == true) return;

					_ShowDistinctDropDowns = true;
				}
				else
				{
					if (_ShowDistinctDropDowns == value) return;

					_ShowDistinctDropDowns = value;
				}
			}
		}

		[Browsable(false)]
		public DataTable dtChangesLinehaulP2P
		{
			get
			{
				DataTable dt = grdLinehaul.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesLinehaulP2P
		{
			get
			{
				DataTable dtc = dtChangesLinehaulP2P;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		[Browsable(false)]
		public DataTable dtChangesLinehaulMileage
		{
			get
			{
				DataTable dt = grdMileageLH.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesLinehaulMileage
		{
			get
			{
				DataTable dtc = dtChangesLinehaulMileage;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		[Browsable(false)]
		public DataTable dtChangesAssessorial
		{
			get
			{
				DataTable dt = grdAssessorial.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesAssessorial
		{
			get
			{
				DataTable dtc = dtChangesAssessorial;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		[Browsable(false)]
		public DataTable dtChangesOceanBB
		{
			get
			{
				DataTable dt = grdOceanBB.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesOceanBB
		{
			get
			{
				DataTable dtc = dtChangesOceanBB;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		[Browsable(false)]
		public DataTable dtChangesOceanCtr
		{
			get
			{
				DataTable dt = grdOceanCtr.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesOceanCtr
		{
			get
			{
				DataTable dtc = dtChangesOceanCtr;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		[Browsable(false)]
		public DataTable dtChangesOceanRoute
		{
			get
			{
				DataTable dt = grdOceanRoute.DataSource as DataTable;
				return (dt != null) ? dt.GetChanges() : null;
			}
		}

		[Browsable(false)]
		public bool HasChangesOceanRoute
		{
			get
			{
				DataTable dtc = dtChangesOceanRoute;
				return (dtc != null && dtc.Rows.Count > 0);
			}
		}

		public bool HasChanges
		{
			get
			{
				return HasChangesLinehaulP2P || HasChangesLinehaulMileage || HasChangesAssessorial ||
					HasChangesOceanBB || HasChangesOceanCtr || HasChangesOceanRoute;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public ucUscRates()
		{
			InitializeComponent();

			_AllowEdit = InheritableBoolean.False;
			_ShowDistinctDropDowns = false;
			grdLinehaul.AllowEdit = grdMileageLH.AllowEdit =
				grdAssessorial.AllowEdit = grdOceanBB.AllowEdit =
				grdOceanCtr.AllowEdit = grdOceanRoute.AllowEdit = _AllowEdit;
			grdLinehaul.AllowAddNew = grdMileageLH.AllowAddNew =
				grdAssessorial.AllowAddNew = grdOceanBB.AllowAddNew =
				grdOceanCtr.AllowAddNew = grdOceanRoute.AllowAddNew = _AllowEdit;

			tpgAssessorials.Tag = grdAssessorial;
			tpgLinehaulPtPt.Tag = grdLinehaul;
			tpgMileageLH.Tag = grdMileageLH;
			tpgOceanBb.Tag = grdOceanBB;
			tpgOceanCtr.Tag = grdOceanCtr;
			tpgOceanRoute.Tag = grdOceanRoute;

			Grid = grdLinehaul;
			Grid.Focus();
			ActiveControl = Grid;

			WindowHelper.InitGrids(this.Controls);
		}
		#endregion		// #region Constructors/Initialization

		#region Methods for interacting with the control

		public void LoadRates()
		{
			try
			{
				LoadLinehaulPtToPtRates();
				LoadLinehaulMileRates();
				LoadAssessorialRates();
				LoadOceanBbRates();
				LoadOceanCtrRates();
				LoadOceanRouteRates();

				LoadDropDowns();
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoRates(bool giveFocus)
		{
			try
			{
				TabPage tpg = tabRates.SelectedTab;
				ucGridEx grd = (tpg != null) ? tpg.Tag as ucGridEx : null;
				if (grd == null) return;
				if (giveFocus)
				{
					grd.Focus();
					ActiveControl = grd;
					grd.Row = grd.FilterRow.Position;
					grd.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoP2P(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgLinehaulPtPt;
				if (giveFocus)
				{
					grdLinehaul.Focus();
					ActiveControl = grdLinehaul;
					grdLinehaul.Row = grdLinehaul.FilterRow.Position;
					grdLinehaul.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoMileage(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgMileageLH;
				if (giveFocus)
				{
					grdMileageLH.Focus();
					ActiveControl = grdMileageLH;
					grdMileageLH.Row = grdMileageLH.FilterRow.Position;
					grdMileageLH.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoAssessorial(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgAssessorials;
				if (giveFocus)
				{
					grdAssessorial.Focus();
					ActiveControl = grdAssessorial;
					grdAssessorial.Row = grdAssessorial.FilterRow.Position;
					grdAssessorial.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoOceanBB(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgOceanBb;
				if (giveFocus)
				{
					grdOceanBB.Focus();
					ActiveControl = grdOceanBB;
					grdOceanBB.Row = grdOceanBB.FilterRow.Position;
					grdOceanBB.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoOceanCtr(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgOceanCtr;
				if (giveFocus)
				{
					grdOceanCtr.Focus();
					ActiveControl = grdOceanCtr;
					grdOceanCtr.Row = grdOceanCtr.FilterRow.Position;
					grdOceanCtr.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoOceanRoute(bool giveFocus)
		{
			try
			{
				tabRates.SelectedTab = tpgOceanRoute;
				if (giveFocus)
				{
					grdOceanRoute.Focus();
					ActiveControl = grdOceanRoute;
					grdOceanRoute.Row = grdOceanRoute.FilterRow.Position;
					grdOceanRoute.Col = 2;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void FilterTruckType(bool? doubleDrop, bool? oog)
		{
			try
			{
				FilterTruckType(grdLinehaul, doubleDrop, oog);
				FilterTruckType(grdMileageLH, doubleDrop, oog);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void GotoAddRow()
		{
			try
			{
				ucGridEx grd = Grid;
				if (grd == null) return;
				grd.MoveToNewRecord();
				if (grd == grdOceanRoute)
					grd.Col = 0;
				else
					grd.Col = 2;
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void ShowChangesOnly(bool onlyChanges)
		{
			try
			{
				ShowChangesOnly(grdLinehaul, onlyChanges);
				ShowChangesOnly(grdMileageLH, onlyChanges);
				ShowChangesOnly(grdAssessorial, onlyChanges);
				ShowChangesOnly(grdOceanBB, onlyChanges);
				ShowChangesOnly(grdOceanCtr, onlyChanges);
				ShowChangesOnly(grdOceanRoute, onlyChanges);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public string GetProposedChanges()
		{
			DataTable dt = null;
			StringBuilder sbChanges = new StringBuilder();

			dt = dtChangesLinehaulP2P;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscInlandBb item = new ClsUscInlandBb(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Linehaul P2P Changes: {0}\r\n{1}", count, sb.ToString());
			}

			dt = dtChangesLinehaulMileage;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscMileage item = new ClsUscMileage(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Linehaul Mileage Changes: {0}\r\n{1}", count, sb.ToString());
			}

			dt = dtChangesAssessorial;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscAssessorial item = new ClsUscAssessorial(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Assessorial Changes: {0}\r\n{1}", count, sb.ToString());
			}

			dt = dtChangesOceanBB;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscOceanBb item = new ClsUscOceanBb(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Linehaul P2P Changes: {0}\r\n{1}", count, sb.ToString());
			}

			dt = dtChangesOceanCtr;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscOceanCtr item = new ClsUscOceanCtr(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Linehaul P2P Changes: {0}\r\n{1}", count, sb.ToString());
			}

			dt = dtChangesOceanRoute;
			if (dt != null && dt.Rows.Count > 0)
			{
				int count = 0;
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
						dr.RowState == DataRowState.Deleted)	// We do not allow deletes
						continue;

					ClsUscOceanRoute item = new ClsUscOceanRoute(dr);
					sb.AppendFormat("{0} - {1}\r\n", dr.RowState, item);
					count++;
				}

				if (count > 0)
					sbChanges.AppendFormat("Linehaul P2P Changes: {0}\r\n{1}", count, sb.ToString());
			}

			return sbChanges.ToString();
		}

		public bool SaveChanges(out string errMsg, out string infoMsg)
		{
			return ClsUscMgr.SaveAll(dtChangesLinehaulP2P, dtChangesLinehaulMileage, dtChangesAssessorial,
				out errMsg, out infoMsg);
		}
		#endregion		// #region Methods for interacting with the control

		#region Load Data

		private DataTable LoadLinehaulPtToPtRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_linehaul_p2p v
				ORDER BY	v.region, v.country, v.port, v.point, v.container, v.commodity ";

				dt = Connection.GetDataTable(sql);
				grdLinehaul.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdLinehaul.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdLinehaul.Layouts[layoutName];
					grdLinehaul.LoadLayout(ly);
				}
				grdLinehaul.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdLinehaul.GroupByBoxVisible = true;
				grdLinehaul.OriginalNewPosition = NewRowPosition.BottomRow;
				UpdateCaption(grdLinehaul);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private DataTable LoadLinehaulMileRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_linehaul_mile v
				ORDER BY
					CASE WHEN
						LENGTH(TRIM(TRANSLATE(
							TRIM(SUBSTR(v.mileage_band, 1, INSTR(UPPER(v.mileage_band), 'TO') - 1)),
							' +-.0123456789',' '))) IS NULL
						THEN
							to_number(TRIM(SUBSTR(v.mileage_band, 1, INSTR(UPPER(v.mileage_band), 'TO') - 1)))
					ELSE
						NULL
					END, v.container_size ";

				dt = Connection.GetDataTable(sql);
				grdMileageLH.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdMileageLH.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdMileageLH.Layouts[layoutName];
					grdMileageLH.LoadLayout(ly);
				}

				grdMileageLH.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdMileageLH.OriginalNewPosition = NewRowPosition.BottomRow;

				UpdateCaption(grdMileageLH);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private DataTable LoadAssessorialRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_assessorial v
				ORDER BY	v.assessorial_type, v.origin, v.destination, v.commodity, v.unit_type ";

				dt = Connection.GetDataTable(sql);
				grdAssessorial.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdAssessorial.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdAssessorial.Layouts[layoutName];
					grdAssessorial.LoadLayout(ly);
				}

				grdAssessorial.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdAssessorial.OriginalNewPosition = NewRowPosition.BottomRow;

				UpdateCaption(grdAssessorial);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private DataTable LoadOceanBbRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_ocean_bb v
				ORDER BY	v.route, v.direction, v.origin, v.destination, v.commodity, v.unit_type ";

				dt = Connection.GetDataTable(sql);
				grdOceanBB.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdOceanBB.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdOceanBB.Layouts[layoutName];
					grdOceanBB.LoadLayout(ly);
				}

				grdOceanBB.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdOceanBB.OriginalNewPosition = NewRowPosition.BottomRow;

				UpdateCaption(grdOceanBB);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private DataTable LoadOceanCtrRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_ocean_ctr v
				ORDER BY	v.route, v.direction, v.origin, v.destination, v.commodity, v.unit_type ";

				dt = Connection.GetDataTable(sql);
				grdOceanCtr.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdOceanCtr.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdOceanCtr.Layouts[layoutName];
					grdOceanCtr.LoadLayout(ly);
				}

				grdOceanCtr.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdOceanCtr.OriginalNewPosition = NewRowPosition.BottomRow;

				UpdateCaption(grdOceanCtr);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private DataTable LoadOceanRouteRates()
		{
			DataTable dt = null;
			try
			{
				string sql = @"
				SELECT	v.*
				FROM	v_usc_ocean_route v
				ORDER BY	v.route, v.from_to, v.commodity, v.rate_type ";

				dt = Connection.GetDataTable(sql);
				grdOceanRoute.DataSource = dt;
				string layoutName = (CanEdit) ? "EditMode" : "ViewMode";
				if (grdOceanRoute.Layouts.Contains(layoutName))
				{
					GridEXLayout ly = grdOceanRoute.Layouts[layoutName];
					grdOceanRoute.LoadLayout(ly);
				}

				grdOceanRoute.SelectionMode = (CanEdit)
					? Janus.Windows.GridEX.SelectionMode.MultipleSelection
					: Janus.Windows.GridEX.SelectionMode.SingleSelection;
				grdOceanRoute.OriginalNewPosition = NewRowPosition.BottomRow;

				UpdateCaption(grdOceanRoute);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
			return dt;
		}

		private void LoadDropDowns()
		{
			try
			{
				LoadDropDown(grdLinehaul, "ddP2PPort", "Port", "Port");
				LoadDropDown(grdLinehaul, "ddP2PPoint", "Point", "Point");
				LoadDropDown(grdLinehaul, "ddP2PContainer", "Container", "Container");
				LoadDropDown(grdLinehaul, "ddP2PCommodity", "Commodity", "Commodity");
				LoadDropDown(grdLinehaul, "ddP2PRegion", "Region", "Region");
				LoadDropDown(grdLinehaul, "ddP2PCountry", "Country", "Country");
				LoadDropDown(grdLinehaul, "ddP2PUnitType", "Unit Type", "Unit_Type");
				LoadDropDown(grdLinehaul, "ddP2PService", "Service", "Service");
				LoadDropDown(grdLinehaul, "ddP2PRFP", "RFP", "RFP");
				LoadDropDown(grdLinehaul, "ddP2PInlandType", "Inland Type", "Inland_Type");

				LoadDropDown(grdMileageLH, "ddMileContainer_Type", "Container Type", "Container_Type");
				LoadDropDown(grdMileageLH, "ddMileContainer_Size", "Container_Size", "Container_Size");
				LoadDropDown(grdMileageLH, "ddMileCommodity", "Commodity", "Commodity");
				LoadDropDown(grdMileageLH, "ddMileCountry", "Country", "Country");
				LoadDropDown(grdMileageLH, "ddMileUnitType", "Unit Type", "Unit_Type");
				LoadDropDown(grdMileageLH, "ddMileService", "Service", "Service");
				LoadDropDown(grdMileageLH, "ddMileRFP", "RFP", "RFP");

				LoadDropDown(grdAssessorial, "ddAssOrig", "Origin", "Origin");
				LoadDropDown(grdAssessorial, "ddAssDest", "Destination", "Destination");
				LoadDropDown(grdAssessorial, "ddAssType", "Assessorial Type", "Assessorial_Type");
				LoadDropDown(grdAssessorial, "ddAssCont_Type", "Container Type", "Container_Type");
				LoadDropDown(grdAssessorial, "ddAssCont_Size", "Container Size", "Container_Size");
				LoadDropDown(grdAssessorial, "ddAssCommodity", "Commodity", "Commodity");
				LoadDropDown(grdAssessorial, "ddAssRoute", "Route", "Route");
				LoadDropDown(grdAssessorial, "ddAssVia", "Via", "Via");
				LoadDropDown(grdAssessorial, "ddAssUnitType", "Unit Type", "Unit_Type");
				LoadDropDown(grdAssessorial, "ddAssService", "Service", "Service");
				LoadDropDown(grdAssessorial, "ddAssRFP", "RFP", "RFP");
				LoadDropDown(grdAssessorial, "ddAssValType", "Value Type", "Value_Type");

				ModDropDown(grdLinehaul, "ddP2PMod");
				ModDropDown(grdMileageLH, "ddMileMod");
				ModDropDown(grdAssessorial, "ddAssMod");

				LoadDropDown(grdOceanBB, "ddOcnBbRoute", "Route", "Route");
				LoadDropDown(grdOceanBB, "ddOcnBbDir", "Direction", "Direction");
				LoadDropDown(grdOceanBB, "ddOcnBbOrig", "Origin", "Origin");
				LoadDropDown(grdOceanBB, "ddOcnBbDest", "Destination", "Destination");
				LoadDropDown(grdOceanBB, "ddOcnBbComm", "Commodity", "Commodity");
				LoadDropDown(grdOceanBB, "ddOcnBbUnitType", "Unit Type", "Unit_Type");
				LoadDropDown(grdOceanBB, "ddOcnBbContType", "Container Type", "Container_Type");
				LoadDropDown(grdOceanBB, "ddOcnBbContSz", "Container Size", "Container_Size");
				LoadDropDown(grdOceanBB, "ddOcnBbBvRank", "BV Rank", "Bv_Rank");
				LoadDropDown(grdOceanBB, "ddOcnBbService", "Service", "Service");
				LoadDropDown(grdOceanBB, "ddOcnBbRFP", "RFP", "RFP");
				LoadDropDown(grdOceanBB, "ddOcnBbOcnType", "Ocean Type", "Ocean_Type");
				ModDropDown(grdOceanBB, "ddOcnBbMod");

				LoadDropDown(grdOceanCtr, "ddOcnCtrRoute", "Route", "Route");
				LoadDropDown(grdOceanCtr, "ddOcnCtrDir", "Direction", "Direction");
				LoadDropDown(grdOceanCtr, "ddOcnCtrOrig", "Origin", "Origin");
				LoadDropDown(grdOceanCtr, "ddOcnCtrDest", "Destination", "Destination");
				LoadDropDown(grdOceanCtr, "ddOcnCtrComm", "Commodity", "Commodity");
				LoadDropDown(grdOceanCtr, "ddOcnCtrUnitType", "Unit Type", "Unit_Type");
				LoadDropDown(grdOceanCtr, "ddOcnCtrContType", "Container Type", "Container_Type");
				LoadDropDown(grdOceanCtr, "ddOcnCtrContSz", "Container Size", "Container_Size");
				LoadDropDown(grdOceanCtr, "ddOcnCtrBvRank", "BV Rank", "Bv_Rank");
				LoadDropDown(grdOceanCtr, "ddOcnCtrService", "Service", "Service");
				LoadDropDown(grdOceanCtr, "ddOcnCtrRFP", "RFP", "RFP");
				LoadDropDown(grdOceanCtr, "ddOcnCtrOcnType", "Ocean Type", "Ocean_Type");
				ModDropDown(grdOceanCtr, "ddOcnCtrMod");

				LoadDropDown(grdOceanRoute, "ddOcnRtRoute", "Route", "Route");
				LoadDropDown(grdOceanRoute, "ddOcnRtFromTo", "From/To", "From_To");
				LoadDropDown(grdOceanRoute, "ddOcnRtComm", "Commodity", "Commodity");
				LoadDropDown(grdOceanRoute, "ddOcnRtRateType", "Rate Type", "Rate_Type");
				ModDropDown(grdOceanRoute, "ddOcnRtMod");
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void LoadDropDown(GridEX grd, string ddName, string ddColCaption, string colKey)
		{
			try
			{
				GridEXDropDown dd = null;
				DataTable dtSource = null;
				if (grd.DropDowns.Contains(ddName)) dd = grd.DropDowns[ddName];
				if (_ShowDistinctDropDowns)
				{
					if (dd == null)
					{
						dd = grd.DropDowns.Add(ddName);
						GridEXColumn ddCol = dd.Columns.Add("Col_Data");
						ddCol.DataMember = "Col_Data";
						ddCol.Caption = ddColCaption;
						ddCol.Width = 400;
						dd.ValueMember = "Col_Data";
						dd.DisplayMember = "Col_Data";
						dd.VisibleRows = 25;
					}
					grd.RootTable.Columns[colKey].DropDown = dd;
					grd.RootTable.Columns[colKey].EditType = EditType.MultiColumnCombo;
					grd.RootTable.Columns[colKey].LimitToList = false;
					grd.RootTable.Columns[colKey].AutoComplete = false;
					string viewNameSuffix = null;
					if (grd == grdLinehaul)
						viewNameSuffix = "linehaul_p2p";
					else if (grd == grdMileageLH)
						viewNameSuffix = "linehaul_mile";
					else if (grd == grdAssessorial)
						viewNameSuffix = "assessorial";
					else if (grd == grdOceanBB)
						viewNameSuffix = "ocean_bb";
					else if (grd == grdOceanCtr)
						viewNameSuffix = "ocean_ctr";
					else if (grd == grdOceanRoute)
						viewNameSuffix = "ocean_route";
					if (!string.IsNullOrWhiteSpace(viewNameSuffix))
					{
						string sql = string.Format(
							"SELECT DISTINCT {0} AS col_data FROM v_usc_{1} ORDER BY col_data ",
							colKey, viewNameSuffix);
						dtSource = Connection.GetDataTable(sql);
					}
				}
				else
				{
					grd.RootTable.Columns[colKey].DropDown = null;
					grd.RootTable.Columns[colKey].EditType = EditType.TextBox;
				}
				if (dd != null) dd.DataSource = dtSource;
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		public void RefreshMods()
		{
			try
			{
				ModDropDown(grdLinehaul, "ddP2PMod");
				ModDropDown(grdMileageLH, "ddMileMod");
				ModDropDown(grdAssessorial, "ddAssMod");
				ModDropDown(grdOceanBB, "ddOcnBbMod");
				ModDropDown(grdOceanCtr, "ddOcnCtrMod");
				ModDropDown(grdOceanRoute, "ddOcnRtMod");
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ModDropDown(GridEX grd, string ddName)
		{
			try
			{
				GridEXColumn col = null;
				if (grd.RootTable.Columns.Contains("Contract_Mod_ID"))
					col = grd.RootTable.Columns["Contract_Mod_ID"];
				if (col == null) return;

				GridEXDropDown dd = null;
				DataTable dtSource = null;
				if (grd.DropDowns.Contains(ddName)) dd = grd.DropDowns[ddName];

				if (CanEdit)
				{
					if (dd == null)
					{
						dd = grd.DropDowns.Add(ddName);
						GridEXColumn ddCol = dd.Columns.Add("Mod_No");
						ddCol.DataMember = "Mod_No";
						ddCol.Caption = "Mod #";
						ddCol.Width = 105;

						ddCol = dd.Columns.Add("Attachment_Nm");
						ddCol.DataMember = "Attachment_Nm";
						ddCol.Caption = "File";
						ddCol.Width = 300;

						ddCol = dd.Columns.Add("Contract_Mod_ID");
						ddCol.DataMember = "Contract_Mod_ID";
						ddCol.Caption = "ID";
						ddCol.Width = 75;

						ddCol = dd.Columns.Add("Mod_Notes");
						ddCol.DataMember = "Mod_Notes";
						ddCol.Caption = "Notes";
						ddCol.Width = 125;

						dd.ValueMember = "Contract_Mod_ID";
						dd.DisplayMember = "Mod_No";
						dd.VisibleRows = 25;
					}
					col.DropDown = dd;
					col.EditType = EditType.MultiColumnCombo;
					col.LimitToList = true;
					dtSource = ClsContractMod.GetAll();
					dtSource.DefaultView.Sort = "Mod_No";
				}
				else
				{
					col.DropDown = null;
					col.EditType = EditType.NoEdit;
				}
				if (dd != null) dd.DataSource = dtSource;
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}
		#endregion		// #region Load Data

		#region Helper Methods/Event Handlers

		protected void OnRowCopied(EventArgs e)
		{
			if (RowCopied != null) RowCopied(this, e);
		}

		private void CopyRow(ucGridEx grd)
		{
			try
			{
				if (grd == null) return;

				decimal? val = null;
				long? luID = null;
				Row = grd.GetRow();
				if (Row != null && Row.RowType == RowType.Record)
				{
					DataRowView drv = Row.DataRow as DataRowView;
					if (drv != null)
					{
						val = ClsConvert.ToDecimalNullable(drv["Rate_Amt"]);
						luID = ClsConvert.ToInt64Nullable(drv["Rate_Basis_ID"]);
					}
				}
				Rate = val;
				Level_Unit_ID = luID;
				OnRowCopied(EventArgs.Empty);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void tabRates_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (tabRates.SelectedTab == tpgAssessorials)
					Grid = grdAssessorial;
				else if (tabRates.SelectedTab == tpgMileageLH)
					Grid = grdMileageLH;
				else if (tabRates.SelectedTab == tpgOceanBb)
					Grid = grdOceanBB;
				else if (tabRates.SelectedTab == tpgOceanCtr)
					Grid = grdOceanCtr;
				else if (tabRates.SelectedTab == tpgOceanRoute)
					Grid = grdOceanRoute;
				else
					Grid = grdLinehaul;
				Grid.Focus();
				ActiveControl = Grid;
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ShowChangesOnly(ucGridEx grd, bool onlyChanges)
		{
			try
			{
				DataTable dt = (grd != null) ? grd.DataSource as DataTable : null;
				if (dt == null) return;
				dt.DefaultView.RowStateFilter = (onlyChanges)
					? DataViewRowState.ModifiedCurrent | DataViewRowState.Added
					: DataViewRowState.CurrentRows;
				if (onlyChanges)
				{
					grd.EnsureVisible(0);
					grd.Row = grd.FilterRow.Position;
				}
				UpdateCaption(grd);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void UpdateCaption(ucGridEx grd)
		{
			try
			{
				if (grd == null) return;
				DataTable dt = grd.DataSource as DataTable;
				int count = (dt != null) ? dt.Rows.Count : grd.RecordCount;
				bool viewFiltered =
					(dt != null && dt.DefaultView.RowStateFilter != DataViewRowState.CurrentRows);

				StringBuilder sb = new StringBuilder();
				if (grd.RootTable.FilterApplied == null && grd.RootTable.FilterCondition == null &&
					viewFiltered == false)
					sb.AppendFormat("{0} Row(s)", grd.RecordCount);
				else
					sb.AppendFormat("{0} of {1}", grd.RecordCount, count);
				GridEXRow fr = grd.FilterRow;
				if (fr != null)
				{
					bool first = true;
					foreach (GridEXCell cell in fr.Cells)
					{
						string val = ClsConvert.ToString(cell.Value);
						if (!string.IsNullOrEmpty(val))
						{
							sb.AppendFormat("{0}{1}: {2}", (first ? " Filtered on " : ", "),
								cell.Column.Caption, cell.Value);
							first = false;
						}
					}
				}

				if (grd.SelectedItems != null && grd.SelectedItems.Count > 1)
					sb.AppendFormat("   {0} rows selected ", grd.SelectedItems.Count);
				grd.RootTable.Caption = sb.ToString();
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void FilterTruckType(ucGridEx grd, bool? doubleDrop, bool? oog)
		{
			try
			{
				grd.Row = grd.FilterRow.Position;
				if (doubleDrop == null)
				{
					grd.SetValue("flatbed_flg", null);
					grd.SetValue("double_drop_flg", null);
				}
				else
				{
					if (doubleDrop.Value)
					{
						grd.SetValue("flatbed_flg", null);
						grd.SetValue("double_drop_flg", "Y");
					}
					else
					{
						grd.SetValue("flatbed_flg", "Y");
						grd.SetValue("double_drop_flg", null);
					}
				}

				if (oog == null)
					grd.SetValue("oog_flg", null);
				else
					grd.SetValue("oog_flg", ClsConvert.BoolToYN(oog.Value));
				grd.UpdateData();
				UpdateCaption(grd);
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grd_FilterApplied(object sender, EventArgs e)
		{
			UpdateCaption(sender as ucGridEx);
		}

		private void grd_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				if (!CanEdit)
				{
					GridArea ga = grd.HitTest();
					grd.RootTable.Caption = ga.ToString();
					if (ga != GridArea.Cell && ga != GridArea.None) return;

					CopyRow(grd);
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grd_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
				{
					if (!CanEdit)
					{
						e.Handled = true;
						CopyRow(grd);
					}
				}
				else if (e.KeyCode == Keys.A && e.Control)
				{
					for (int i = 0; i < grd.RecordCount; i++)
						grd.SelectedItems.Add(i);
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grd_CellUpdated(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.DataMember, "Container", true) != 0 &&
					string.Compare(e.Column.DataMember, "Container_Size", true) != 0 &&
					string.Compare(e.Column.DataMember, "Commodity", true) != 0 &&
					string.Compare(e.Column.DataMember, "Unit_Type", true) != 0)
					return;

				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				GridEXRow r = grd.GetRow();
				if (r == null || r.RowType != RowType.Record) return;

				DataRowView drv = r.DataRow as DataRowView;
				if (drv == null) return;

				if (string.Compare(e.Column.DataMember, "Unit_Type", true) == 0)
				{
					string utDsc = ClsConvert.ToString(r.Cells["Unit_Type"].Value);
					ClsLevelUnit lvu = ClsUscMgr.ComputeRateBasis(utDsc);
					r.Cells["Rate_Basis_ID"].Value = ClsConvert.ToDbObject(lvu != null ? lvu.Level_Unit_ID : null);
					r.Cells["Rate_Basis_Dsc"].Value = ClsConvert.ToDbObject(lvu != null ? lvu.Level_Unit_Dsc : null);
				}
				else
				{
					string fb_flg, dd_flg, o_flg, field1, field2;
					if (grd == grdLinehaul)
					{
						field1 = ClsConvert.ToString(r.Cells["Container"].Value);
						field2 = ClsConvert.ToString(r.Cells["Commodity"].Value);
					}
					else if (grd == grdMileageLH)
					{
						field1 = ClsConvert.ToString(r.Cells["Container_Size"].Value);
						field2 = field1;
					}
					else
						return;
					ClsUscMgr.ComputeConveyanceType(field1, field2, out fb_flg, out dd_flg, out o_flg);
					r.Cells["Flatbed_Flg"].Value = ClsConvert.ToDbObject(fb_flg);
					r.Cells["Double_Drop_Flg"].Value = ClsConvert.ToDbObject(dd_flg);
					r.Cells["Oog_Flg"].Value = ClsConvert.ToDbObject(o_flg);
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grd_FormattingRow(object sender, RowLoadEventArgs e)
		{
			try
			{
				if( e.Row.RowType != RowType.Record ) return;
				DataRowView drv = e.Row.DataRow as DataRowView;
				DataRow dr = ( drv != null ) ? drv.Row : null;
				if( dr == null ) return;

				if( dr.RowState == DataRowState.Added )
				{
					GridEXFormatStyle fs = new GridEXFormatStyle();
					fs.BackColor = Color.FromArgb(153, 202, 166);
					e.Row.RowStyle = fs;
				}
				else if( dr.RowState == DataRowState.Modified )
				{
					GridEXFormatStyle fs = new GridEXFormatStyle();
					fs.BackColor = Color.FromArgb(202, 228, 244);
					e.Row.RowStyle = fs;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grd_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				if (!CanEdit) return;

				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				UpdateCaption(grd);

				GridEXRow r = grd.GetRow();
				if (r == null) return;

				bool autocomp = (r.RowType != RowType.FilterRow);
				foreach (GridEXColumn col in grd.RootTable.Columns)
					col.AutoComplete = autocomp;
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}
		#endregion		// #region Helper Methods/Event Handlers
	}
}