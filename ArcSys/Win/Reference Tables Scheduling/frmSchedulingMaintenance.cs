using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.AVSS.Business;
using CS2010.CommonSecurity;
using Janus.Windows.GridEX;
using System.Text;
using CS2010.ArcSys.Win;

namespace CS2010.ArcSys.Win
{
    public partial class frmSchedulingMaintenance : frmChildBase
    {
        #region Static Fields

        /// <summary>Used by the static ShowMaintenance method to ensure that no more than
        /// one frmMaintenance window is visible at any given time</summary>
        private static frmSchedulingMaintenance MaintenanceWindow;

        #endregion		// #region Static Fields

        #region Constants (Step 1: Add new tables here)

        private const string Berth = "Berth";
        private const string BerthOperation = "BerthOperation";
        private const string BerthPair = "BerthPair";
        private const string Port = "Port";
		private const string Distance = "Distance";
        private const string Route = "Route";
        private const string SceduleType = "ScheduleType";
        private const string Season = "Season";
		private const string VesselSpeed = "VesselSpeed";
        private const string TradeLane = "TradeLane";
        private const string Vessel = "Vessel";
		private const string Service = "Service";
		private const string BerthActivity = "BerthActivity";
		private const string MilitaryVoyage = "MilitaryVoyage";

        #endregion		// #region Constants

        #region Fields

        private enum DMLAction { Insert, Update, Delete };

        private delegate DataTable LoadMethod();
        private delegate DataRow MaintenanceMethod(DMLAction action);

        private Dictionary<string, DataTable> Tables;
        private Dictionary<string, LoadMethod> LoadMethods;
        private Dictionary<string, MaintenanceMethod> ModifyMethods;

        #endregion		// #region Fields

        #region Internal Properties

        private string CurrentKey
        {
            get
            {
                TreeNode tn = tvwTables.SelectedNode;
                return (tn != null) ? tn.Name : null;
            }
        }

        private DataTable CurrentTable
        {
            get
            {
                string key = CurrentKey;
                if (string.IsNullOrEmpty(key) == true) return null;

                return (Tables.ContainsKey(key)) ? Tables[key] : null;
            }
        }

        private GridEXLayout CurrentLayout
        {
            get
            {
                string key = CurrentKey;
                if (string.IsNullOrEmpty(key) == true) return null;

                return (grdTable.Layouts.Contains(key)) ? grdTable.Layouts[key] : null;
            }
        }

        private LoadMethod CurrentLoadMethod
        {
            get
            {
                string key = CurrentKey;
                if (string.IsNullOrEmpty(key) == true) return null;

                return (LoadMethods.ContainsKey(key)) ? LoadMethods[key] : null;
            }
        }

        private MaintenanceMethod CurrentModifyMethod
        {
            get
            {
                string key = CurrentKey;
                if (string.IsNullOrEmpty(key) == true) return null;

                return (ModifyMethods.ContainsKey(key)) ? ModifyMethods[key] : null;
            }
        }
        #endregion		// #region Internal Properties

        #region Constructors/Initialization (Add New Tables Here)

        public frmSchedulingMaintenance() : base()
        {
            InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

            InitializeTables();
            InitializeLoadMethods();
            InitializeModifyMethods();

            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

        }

        private void InitializeTables()
        {
            Tables = new Dictionary<string, DataTable>();
            Tables.Add(Port, null);
            Tables.Add(Vessel, null);
            Tables.Add(TradeLane, null);
            Tables.Add(Berth, null);
            Tables.Add(BerthOperation, null);
            Tables.Add(BerthPair, null);
			Tables.Add(Distance, null);
            Tables.Add(Route, null);
            Tables.Add(SceduleType, null);
            Tables.Add(Season, null);
			Tables.Add(VesselSpeed, null);
			Tables.Add(Service, null);
			Tables.Add(MilitaryVoyage, null);
        }

        private void InitializeLoadMethods()
        {
            LoadMethods = new Dictionary<string, LoadMethod>();
            LoadMethods.Add(Vessel, GetVesselTable);
            LoadMethods.Add(Port, GetPortTable);
            LoadMethods.Add(TradeLane, GetTradeLaneTable);
            LoadMethods.Add(Berth, GetBerthTable);
            LoadMethods.Add(BerthOperation, GetBerthOperationTable);
            LoadMethods.Add(BerthPair, GetBerthPairTable);
			LoadMethods.Add(Distance, GetDistanceTable);
            LoadMethods.Add(Route, GetRouteTable);
            LoadMethods.Add(SceduleType, GetScheduleTypeTable);
            LoadMethods.Add(Season, GetSeasonTable);
			LoadMethods.Add(VesselSpeed, GetVesselSpeedTable);
			LoadMethods.Add(Service, GetServiceTable);
			LoadMethods.Add(BerthActivity, GetBerthActivityTable);
			LoadMethods.Add(MilitaryVoyage, GetMilitaryVoyageTable);
			tvwTables.ExpandAll();
        }

        private void InitializeModifyMethods()
        {
            ModifyMethods = new Dictionary<string, MaintenanceMethod>();
            ModifyMethods.Add(Vessel, ModifyVessel);
			ModifyMethods.Add(Port, ModifyPort);
			//ModifyMethods.Add(TradeLane, ModifyTradeLane);
			ModifyMethods.Add(Berth, ModifyBerth);
			//ModifyMethods.Add(BerthPair, ModifyBerthPair);
			//ModifyMethods.Add(Route, ModifyRoute);
			//ModifyMethods.Add(SceduleType, ModifyScheduleType);
			//ModifyMethods.Add(Season, ModifySeason);
			//ModifyMethods.Add(Distance, ModifyDistance);
			//ModifyMethods.Add(VesselSpeed, ModifyVesselSpeed);
			//ModifyMethods.Add(Service, ModifyService);
			//ModifyMethods.Add(BerthActivity, ModifyBerthActivity);
			ModifyMethods.Add(MilitaryVoyage, ModifyMilitaryVoyage);
        }
        #endregion		// #region Constructors/Initialization

        #region Public Methods

        /// <summary>Main entry point into this window ensuring that no more than 1
        /// frmMaintenance window is visible at any given time</summary>
        public static frmSchedulingMaintenance ShowMaintenance()
        {
            try
            {
                bool newWindow = false;
                if (MaintenanceWindow == null)
                {
                    MaintenanceWindow = new frmSchedulingMaintenance();
                    newWindow = true;
                }

                WindowHelper.ShowChildWindow(MaintenanceWindow);

                if (newWindow)
                {
                    MaintenanceWindow.tvwTables.ExpandAll();
                    if (MaintenanceWindow.tvwTables.SelectedNode != null)
                        MaintenanceWindow.tvwTables.SelectedNode.EnsureVisible();
                }

                return MaintenanceWindow;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }
        #endregion		// #region Public Methods

        #region Common DML Methods

        private DataRow AddItem(ClsBaseTable item, string key)
        {
            try
            {
                DataTable dt = Tables[key];
                DataRow dr = dt.NewRow();
                item.CopyToDataRow(dr);
                dt.Rows.Add(dr);
                return dr;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        private void DeleteItem<T>(string key) where T : ClsBaseTable, new()
        {
            try
            {
                DataTable dt = (Tables.ContainsKey(key)) ? Tables[key] : null;
                if (dt == null) return;

                DataRow dr = grdTable.GetDataRow();
                if (dr == null) return;

                T item = new T();
                item.LoadFromDataRow(dr);

                if (Display.Ask("Delete Confirmation", "Delete {0}?\r\n{1}",
                    key, item) == false) return;

                Type objType = typeof(T);
                item.Delete();

                dt.Rows.Remove(dr);
            }
            catch (DbException ex)
            {
                StringBuilder sb = new StringBuilder("You cannot delete this item because it is referenced somewhere else.");
                sb.AppendLine();
                sb.AppendLine(" ");
                sb.AppendLine("Database Message: " + ex.Message);
                Program.ShowError(sb.ToString());
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion		// #region Common DML Methods

        #region Load Methods (Add New Tables Here)

		private DataTable GetMilitaryVoyageTable()
		{
			try
			{
				//return ClsMilitaryVoyage.GetAll(true);
				return ClsMilitaryVoyage.GetAllWithYear();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}
        private DataTable GetBerthTable()
        {
            try
            {
                DataTable dt = ClsBerth.GetAll(true);
                dt.DefaultView.Sort = "BERTH_CD ASC";
                return dt;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        private DataTable GetBerthOperationTable()
        {
			//try
			//{
			//    DataTable dt = ClsBerthOperation.GetAll(true);
			//    dt.DefaultView.Sort = "BERTH_CD ASC";
			//    return dt;
			//}
			//catch (Exception ex)
			//{
			//    Program.ShowError(ex);
			//    return null;
			//}
			return null;
        }
        private DataTable GetBerthPairTable()
        {
            try
            {
                DataTable dt = ClsBerthPair.GetBerthPairAll();
                dt.DefaultView.Sort = "START_BERTH_CD ASC";
                return dt;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        private DataTable GetPortTable()
        {
            DataTable dt = ClsPort.GetAll(true);
            dt.DefaultView.Sort = "PORT_NM ASC";
            return dt;
        }

		private DataTable GetDistanceTable()
        {
			DataTable dt = ClsDistance.GetAll(true);
            dt.DefaultView.Sort = "START_PORT_CD ASC";
            return dt;
        }
        private DataTable GetRouteTable()
        {
            DataTable dt = ClsRoute.GetAll(true);
            dt.DefaultView.Sort = "ROUTE_CD ASC";
            return dt;
        }

        private DataTable GetScheduleTypeTable()
        {
            DataTable dt = ClsScheduleType.GetAll(true);
            dt.DefaultView.Sort = "SCHEDULE_TYPE_CD ASC";
            return dt;
        }
        private DataTable GetSeasonTable()
        {
            DataTable dt = ClsSeason.GetAll(true);
            dt.DefaultView.Sort = "SEASON_NM ASC";
            return dt;
        }

		private DataTable GetVesselSpeedTable()
        {
			DataTable dt = ClsVesselSpeed.GetAll(true);
            dt.DefaultView.Sort = "VESSEL_CD ASC";
            return dt;
        }


        private DataTable GetTradeLaneTable()
        {
            try
            {
                DataTable dt = ClsTradeLane.GetAll(true);
                dt.DefaultView.Sort = "TRADE_LANE_CD ASC";
                return dt;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        private DataTable GetVesselTable()
        {
            try
            {
                DataTable dt = ClsVessel.GetAll(true);
                dt.DefaultView.Sort = "VESSEL_CD ASC";
                return dt;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

		private DataTable GetServiceTable()
		{
			try
			{
				DataTable dt = ClsService.GetAll(true);
				dt.DefaultView.Sort = "SERVICE_CD ASC";
				return dt;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}

		}
		private DataTable GetBerthActivityTable()
		{
			try
			{
				DataTable dt = ClsBerthActivity.GetAll(true);
				dt.DefaultView.Sort = "BERTH_ACTIVITY_CD ASC";
				return dt;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}

		}

        #endregion // Load

        #region DML Methods (Add New Tables Here)
		private DataRow ModifyMilitaryVoyage(DMLAction action)
		{
			try
			{
				if (action == DMLAction.Delete)
				{
					DeleteItem<ClsMilitaryVoyage>(MilitaryVoyage);
					return null;
				}

				if (action != DMLAction.Insert && action != DMLAction.Update) return null;

				DataRow dr = null;
				ClsMilitaryVoyage item = null;
				using (frmEditMilitaryVoyage frm = new frmEditMilitaryVoyage())
				{
					if (action == DMLAction.Insert)
					{
						item = frm.Add();
						if (item == null) return null;

						dr = AddItem(item, MilitaryVoyage);
					}
					else		// Update
					{
						dr = grdTable.GetDataRow();
						item = (dr != null) ? new ClsMilitaryVoyage(dr) : null;
						if (item == null || frm.Edit(item) == false) return null;

						item.CopyToDataRow(dr);
					}
				}

				// Add extra rows here
				return dr;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}
		private DataRow ModifyBerth(DMLAction action)
		{
			try
			{
				if (action == DMLAction.Delete)
				{
					DeleteItem<ClsBerth>(Berth);
					return null;
				}

				if (action != DMLAction.Insert && action != DMLAction.Update) return null;

				DataRow dr = null;
				ClsBerth item = null;
				using (frmEditBerth frm = new frmEditBerth())
				{
					if (action == DMLAction.Insert)
					{
						item = frm.Add();
						if (item == null) return null;

						dr = AddItem(item, Berth);
					}
					else		// Update
					{
						dr = grdTable.GetDataRow();
						item = (dr != null) ? new ClsBerth(dr) : null;
						if (item == null || frm.Edit(item) == false) return null;

						item.CopyToDataRow(dr);
					}
				}

				// Add extra rows here
				return dr;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}
		//private DataRow ModifyBerthPair(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsBerthPair>(BerthPair);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsBerthPair item = null;
		//        using (frmEditBerthPair frm = new frmEditBerthPair())
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, BerthPair);
		//                // Refresh
		//                DataTable dt = new DataTable();
		//                LoadMethod load = CurrentLoadMethod;
		//                if (load != null) dt = load();
		//                Tables[BerthPair] = dt;
		//                grdTable.DataSource = Tables[BerthPair];
		//                //
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsBerthPair(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}
		//private DataRow ModifyRoute(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsRoute>(Route);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsRoute item = null;
		//        using (frmEditRoute frm = new frmEditRoute())
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, Route);
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsRoute(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}
		//private DataRow ModifyScheduleType(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsScheduleType>(SceduleType);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsScheduleType item = null;
		//        using (frmEditScheduleType frm = new frmEditScheduleType())
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, SceduleType);
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsScheduleType(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}
		//private DataRow ModifySeason(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsSeason>(Season);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsSeason item = null;
		//        using (frmEditSeason frm = new frmEditSeason())
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, Season);
		//                // Refresh
		//                DataTable dt = new DataTable();
		//                LoadMethod load = CurrentLoadMethod;
		//                if (load != null) dt = load();
		//                Tables[Season] = dt;
		//                grdTable.DataSource = Tables[Season];
		//                //
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsSeason(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}
		//private DataRow ModifyDistance(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsDistance>(Distance);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsDistance item = null;
		//        using( frmEditDistance frm = new frmEditDistance() )
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, Distance);
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = ( dr != null ) ? new ClsDistance(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}

		private DataRow ModifyVessel(DMLAction action)
		{
			try
			{
				//frmVesselMaintenance.ShowMaintenance();
				//if (action == DMLAction.Delete)
				//{
				//    DeleteItem<ClsVessel>(Vessel);
				//    return null;
				//}

				//if (action != DMLAction.Insert && action != DMLAction.Update) return null;

				//DataRow dr = null;
				Program.Show("Not available here.");
				//if (action == DMLAction.Update)
				//{
				//    dr = grdTable.GetDataRow();
				//    ClsVessel item = null;
				//    item = (dr != null) ? new ClsVessel(dr) : null;
				//    if (item == null)
				//        return null;
				//    CS2010.ACMS.Business.ClsVessel v = CS2010.ACMS.Business.ClsVessel.GetUsingKey(item.Vessel_Cd);

				//    using (frmVesselEdit f = new frmVesselEdit())
				//    {
				//        f.EditVessel(v);
				//        return dr;
				//    }
				//}
				//ClsVessel item = null;
				//using (frmEditVessel frm = new frmEditVessel())
				//{
				//    if (action == DMLAction.Insert)
				//    {
				//        item = frm.Add();
				//        if (item == null) return null;

				//        dr = AddItem(item, Vessel);
				//    }
				//    else		// Update
				//    {
				//        dr = grdTable.GetDataRow();
				//        item = (dr != null) ? new ClsVessel(dr) : null;
				//        if (item == null || frm.Edit(item) == false) return null;

				//        item.CopyToDataRow(dr);
				//    }
				//}

				// Add extra rows here
				return null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}
		private DataRow ModifyPort(DMLAction action)
		{
			try
			{
				if (action == DMLAction.Delete)
				{
					DeleteItem<ClsPort>(Port);
					return null;
				}

				if (action != DMLAction.Insert && action != DMLAction.Update) return null;

				DataRow dr = null;
				ClsPort item = null;
				using (frmEditPort frm = new frmEditPort())
				{
					if (action == DMLAction.Insert)
					{
						item = frm.Add();
						if (item == null) return null;

						dr = AddItem(item, Port);
					}
					else		// Update
					{
						dr = grdTable.GetDataRow();
						item = (dr != null) ? new ClsPort(dr) : null;
						if (item == null || frm.Edit(item) == false) return null;

						item.CopyToDataRow(dr);
					}
				}

				// Add extra rows here
				return dr;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}
		//private DataRow ModifyTradeLane(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsTradeLane>(TradeLane);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsTradeLane item = null;
		//        using (frmEditTradeLane frm = new frmEditTradeLane())
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, TradeLane);
		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsTradeLane(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}

		//private DataRow ModifyVesselSpeed(DMLAction action)
		//{
		//    try
		//    {
		//        if (action == DMLAction.Delete)
		//        {
		//            DeleteItem<ClsVesselSpeed>(VesselSpeed);
		//            return null;
		//        }

		//        if (action != DMLAction.Insert && action != DMLAction.Update) return null;

		//        DataRow dr = null;
		//        ClsVesselSpeed item = null;
		//        using( frmEditVesselSpeed frm = new frmEditVesselSpeed() )
		//        {
		//            if (action == DMLAction.Insert)
		//            {
		//                item = frm.Add();
		//                if (item == null) return null;

		//                dr = AddItem(item, VesselSpeed);
		//                // Refresh
		//                DataTable dt = new DataTable();
		//                LoadMethod load = CurrentLoadMethod;
		//                if (load != null) dt = load();
		//                Tables[VesselSpeed] = dt;
		//                grdTable.DataSource = Tables[VesselSpeed];
		//                //

		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = ( dr != null ) ? new ClsVesselSpeed(dr) : null;
		//                if (item == null || frm.Edit(item) == false) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}

		//private DataRow ModifyService(DMLAction action)
		//{
		//    try
		//    {
		//        if( action == DMLAction.Delete )
		//        {
		//            DeleteItem<ClsService>(Service);
		//            return null;
		//        }

		//        if( action != DMLAction.Insert && action != DMLAction.Update ) return null;

		//        DataRow dr = null;
		//        ClsService item = null;
		//        using( frmEditService frm = new frmEditService() )
		//        {
		//            if( action == DMLAction.Insert )
		//            {
		//                item = frm.Add();
		//                if( item == null ) return null;

		//                dr = AddItem(item, Service);
		//                // Refresh
		//                DataTable dt = new DataTable();
		//                LoadMethod load = CurrentLoadMethod;
		//                if( load != null ) dt = load();
		//                Tables[Service] = dt;
		//                grdTable.DataSource = Tables[Service];
		//                //

		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsService(dr) : null;
		//                if( item == null || frm.Edit(item) == false ) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch( Exception ex )
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}

		//private DataRow ModifyBerthActivity(DMLAction action)
		//{
		//    try
		//    {
		//        if( action == DMLAction.Delete )
		//        {
		//            DeleteItem<ClsBerthActivity>(BerthActivity);
		//            return null;
		//        }

		//        if( action != DMLAction.Insert && action != DMLAction.Update ) return null;

		//        DataRow dr = null;
		//        ClsBerthActivity item = null;
		//        using( frmEditBerthActivity frm = new frmEditBerthActivity() )
		//        {
		//            if( action == DMLAction.Insert )
		//            {
		//                item = frm.Add();
		//                if( item == null ) return null;

		//                dr = AddItem(item, BerthActivity);
		//                // Refresh
		//                DataTable dt = new DataTable();
		//                LoadMethod load = CurrentLoadMethod;
		//                if( load != null ) dt = load();
		//                Tables[BerthActivity] = dt;
		//                grdTable.DataSource = Tables[BerthActivity];
		//                //

		//            }
		//            else		// Update
		//            {
		//                dr = grdTable.GetDataRow();
		//                item = (dr != null) ? new ClsBerthActivity(dr) : null;
		//                if( item == null || frm.Edit(item) == false ) return null;

		//                item.CopyToDataRow(dr);
		//            }
		//        }

		//        // Add extra rows here
		//        return dr;
		//    }
		//    catch( Exception ex )
		//    {
		//        Program.ShowError(ex);
		//        return null;
		//    }
		//}
        #endregion		// #region DML Methods

        #region Helper Methods


        private void MakeVisible(DataRow dr)
        {
            try
            {
                GridEXRow r = (dr != null) ? grdTable.GetRow(dr) : null;
                if (r == null) return;

                GridEXRow rtmp = r.Parent;
                while (rtmp != null)
                {
                    rtmp.Expanded = true;
                    rtmp = rtmp.Parent;
                }
                grdTable.EnsureVisible(r.Position);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void HandleForm(bool enable)
        {
            try
            {
                pnlMain.Enabled = tbbOptions.Enabled = tbbClose.Enabled = enable;
                Cursor = (enable) ? Cursors.Default : Cursors.WaitCursor;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SelectionChanged()
        {
            try
            {
                HandleForm(false);

                grdTable.DataSource = null;
                DataTable dt = CurrentTable;
                if (dt == null)
                {
                    LoadMethod load = CurrentLoadMethod;
                    if (load != null) dt = load();
                }

                Tables[CurrentKey] = dt;

                GridEXLayout layout = CurrentLayout;
                if (layout != null)
                    grdTable.CurrentLayout = layout;
                else
                    grdTable.ClearStructure();

                grdTable.DataSource = dt;
                if (dt != null && grdTable.RootTable != null &&
                    grdTable.RootTable.Groups.Count > 0) grdTable.CollapseGroups();

                WindowHelper.InitAllGrids(this);

                HandleTable();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
            finally
            {
                HandleForm(true);
            }
        }

        private void HandleTable()
        {
            try
            {
                bool onlyUpdate = false;
               // if (string.Compare(CurrentKey, Customer, true) == 0) onlyUpdate = true;
                btnAdd.Visible = btnDelete.Visible = !onlyUpdate;

                //switch (CurrentKey)
                //{
                //    case RegionTable:
                //        if (grdTable.RootTable.ChildTables.Count > 0)
                //            grdTable.RootTable.ChildTables[0].DataMember = "Locations";
                //        break;

                //    case ControlTable:
                //        if (grdTable.RootTable.ChildTables.Count > 0)
                //            grdTable.RootTable.ChildTables[0].DataMember = "Locations";
                //        break;

                //    case TradeRegion:
                //        if (grdTable.RootTable.ChildTables.Count > 0)
                //            grdTable.RootTable.ChildTables[0].DataMember = "Locations";
                //        break;

                //    default:
                //        break;
                //}

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion		// #region Helper Methods

        #region Event Handlers

        private void frmMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            MaintenanceWindow = null;
        }

        private void tbbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cnuOptionsRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentKey == null) return;

                Tables[CurrentKey] = null;
                SelectionChanged();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void tvwTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectionChanged();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MaintenanceMethod modify = CurrentModifyMethod;
                DataRow dr = (modify != null) ? modify(DMLAction.Insert) : null;
                if (dr != null) MakeVisible(dr);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                MaintenanceMethod modify = CurrentModifyMethod;
                if (modify != null) modify(DMLAction.Update);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MaintenanceMethod modify = CurrentModifyMethod;
                if (modify != null) modify(DMLAction.Delete);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void grdTable_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridArea ga = grdTable.HitTest();
                if (ga != GridArea.Cell) return;

                MaintenanceMethod modify = CurrentModifyMethod;
                if (modify != null) modify(DMLAction.Update);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void grdTable_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                GridEXRow gr = grdTable.GetRow();
                if (gr == null || gr.RowType != RowType.Record) return;

                if (e.KeyCode == Keys.Enter)
                {
                    MaintenanceMethod modify = CurrentModifyMethod;
                    if (modify != null)
                    {
                        modify(DMLAction.Update);
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    MaintenanceMethod modify = CurrentModifyMethod;
                    if (modify != null)
                    {
                        modify(DMLAction.Delete);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion		// #region Event Handlers


    }
}