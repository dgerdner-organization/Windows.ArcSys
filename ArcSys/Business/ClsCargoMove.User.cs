using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoMove
    {

        #region Properties

		private ClsCargoActivity _CargoActivity;
		public ClsCargoActivity CargoActivity
		{
			get 
			{
				if (_CargoActivity != null)
					return _CargoActivity;
				_CargoActivity = ClsCargoActivity.GetUsingKey(this.Cargo_Activity_ID.GetValueOrDefault());
				return _CargoActivity;
			}
		}
        public ClsCargoAction ActionBeforeLastAction
        {
            get
            {
                ClsCargoAction Last = LastAction;

                if (Last == null) return null;

                string sql = string.Format(@"
                    SELECT * FROM t_cargo_action ca WHERE ca.cargo_action_id = 
                    (SELECT MAX(ca2.cargo_action_id) 
	                    FROM t_cargo_action ca2
	                    WHERE ca2.cargo_move_id = {0} 
	                    AND ca2.cargo_action_id NOT IN ({1}))", 
                        Last.Cargo_Move_ID, Last.Cargo_Action_ID);

                DataRow dr = Connection.GetDataRow(sql);

                return (dr == null) ? null :  new ClsCargoAction(dr);

            }
        }

        public List<ClsCargoMove> CargoMovesAttachedToConveyance
        {
            get
            {
                if (Cargo_Move_ID == null) return null;

                string sql = string.Format(@"
                    SELECT *
                    FROM t_cargo_move cm
                    WHERE cm.conveyance_id = 
                    (SELECT cm2.conveyance_id FROM t_cargo_move cm2 WHERE cm2.cargo_move_id = {0})
                    ", Cargo_Move_ID);

                return Connection.GetList<ClsCargoMove>(sql);
            }
        }

        public ClsCargoAction LastAction 
        { 
            get
            {
                if (Last_Cargo_Action_ID == null) return null;

                string sql = string.Format(@"
                    SELECT
                    *
                    FROM
                    t_cargo_action ca
                    WHERE
                    ca.cargo_action_id = {0}", Last_Cargo_Action_ID);

                return new ClsCargoAction(Connection.GetDataRow(sql));

            }  
        }

        public ClsCargoAction LastLogisticsAction
        {
            get
            {
                if (Last_Logistic_Action_ID == null) return null;

                string sql = string.Format(@"
                    SELECT
                    *
                    FROM
                    t_cargo_action ca
                    WHERE
                    ca.cargo_action_id = {0}", Last_Logistic_Action_ID);

                return new ClsCargoAction(Connection.GetDataRow(sql));

            }
        }

        public DataTable CargoActions
        {
            get
            {
                if (Cargo_Move_ID == null) return null;

                string sql = string.Format(@"
                    SELECT 
                    * 
                    FROM t_cargo_action ca 
                    INNER JOIN r_action a ON a.action_cd = ca.action_cd
                    INNER JOIN r_location l ON l.location_cd = ca.location_cd
                    WHERE ca.cargo_move_id = {0} ORDER BY ca.create_dt
                    ", Cargo_Move_ID);

                return Connection.GetDataTable(sql);

            }
        }

        public List<ClsCargoAction> ListOfCargoActions
        {
            get
            {
                if (Cargo_Move_ID == null) return null;

                string sql = string.Format(@"
                    SELECT 
                    * 
                    FROM t_cargo_action ca 
                    INNER JOIN r_action a ON a.action_cd = ca.action_cd
                    INNER JOIN r_location l ON l.location_cd = ca.location_cd
                    WHERE ca.cargo_move_id = {0} ORDER BY ca.action_dt
                    ", Cargo_Move_ID);

                return Connection.GetList<ClsCargoAction>(sql);

            }
        }

        public bool AreWeAtDestination 
        {
            get
            {
                return (Vendor_Move.Dest_Location_Cd == Last_Logistic_Action.Location_Cd);
            }  
        }


        #endregion

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			try
			{
				return string.Format("{0} {1} {2} {3}", Cargo_Move_ID, Vendor_Move_ID, Serial_No,
					ClsConvert.YNToActiveInactive(Active_Flg));
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return base.ToString();
			}
		}
		#endregion		// #region ToString Overrides

		#region Validation

        public bool ValidateAction(TRACKING_ACTIONS _Action,ClsLocation NewLocation, DateTime? ActionDt)
        {
            _Errors.Clear();

            if (Active_Flg == "N")
                _Errors["Active_Flg"] = "This cargo is NOT active.";

            switch (_Action)
            {
                case TRACKING_ACTIONS.CONVEYANCE_DEPART_ORIGIN:

                    if (LastLogisticsAction != null)
                        _Errors["LastLogisticsAction"] = "Depart from Origin must be the first action.";

                    if (Move_Start_Dt != null)
                        _Errors["Move_Start_Dt"] = string.Format("This cargo has already started moving.");

                    if (Move_End_Dt != null)
                        _Errors["Move_End_Dt"] = string.Format("Cannot be at final destination");

                    if (ListOfCargoActions.Count > 0)
                        _Errors["CargoActions"] = "Cargo Actions already exist for this move.";

                        break;
                case TRACKING_ACTIONS.CONVEYANCE_ARRIVE:

                    if (LastLogisticsAction.Action_Cd != "DEPART")
                        _Errors["Action_Cd"] = string.Format("Previous Action must be 'DEPART'");

                    if (Last_Logistic_Action.Action_Dt > (DateTime)ActionDt)
                        _Errors["Action_Dt"] = string.Format("Action Date '{0:d}' must take place after last Action Date '{1:d}'.",ActionDt,Last_Logistic_Action.Action_Dt);

					// JUNE2018 DGERDNER
					// Formerly would not allow Arrivate to the same location as the current location
					// I allow this if it's arriving to the PLOD.
					string sPLOD = this.CargoActivity.Cargo.Booking.Plod_Location_Cd;
                    if (LastLogisticsAction.Location_Cd == NewLocation.Location_Cd)
						if (NewLocation.Location_Cd != sPLOD)
							_Errors["NewLocation"] = string.Format("Cannot rearrive at location '{0}'.", NewLocation.Location_Dsc);

                    if (Move_Start_Dt == null)
                        _Errors["Move_Start_Dt"] = string.Format("This cargo has not started moving.");

                    if (Move_End_Dt != null)
                        _Errors["Move_End_Dt"] = string.Format("Cannot be at final destination");

                    break;
                case TRACKING_ACTIONS.CONVEYANCE_DEPART:

                    if (LastLogisticsAction.Action_Cd != "ARRIVE")
                        _Errors["Action_Cd"] = string.Format("Previous Action must be 'ARRIVE'");

                    if (Last_Logistic_Action.Action_Dt > (DateTime)ActionDt)
                        _Errors["Action_Dt"] = string.Format("Action Date '{0:d}' must take place after last Action Date '{1:d}'.", ActionDt, Last_Logistic_Action.Action_Dt);

                    if (Move_Start_Dt == null)
                        _Errors["Move_Start_Dt"] = string.Format("This cargo has not started moving.");

                    if (Move_End_Dt != null)
                        _Errors["Move_End_Dt"] = string.Format("Cannot be at final destination");

                    break;
                case TRACKING_ACTIONS.CARGO_IN_GATE:

                    if (LastLogisticsAction.Action_Cd != "ARRIVE")
                        _Errors["Action_Cd"] = string.Format("Previous Action must be 'ARRIVE'");

                    if (Last_Logistic_Action.Action_Dt > (DateTime)ActionDt)
                        _Errors["Action_Dt"] = string.Format("Action Date '{0:d}' must take place after last Action Date '{1:d}'.", ActionDt, Last_Logistic_Action.Action_Dt);

                    if (Move_Start_Dt == null)
                        _Errors["Move_Start_Dt"] = string.Format("This cargo has not started moving.");

                    if (Move_End_Dt == null)
                        _Errors["Move_End_Dt"] = string.Format("This cargo must be at final destination.");

                    break;
                case TRACKING_ACTIONS.CARGO_STAMP_OF_DELIVERY:
                                        
                    if (LastLogisticsAction.Action_Cd != "ARRIVE")
                        _Errors["Action_Cd"] = string.Format("Previous Action must be 'ARRIVE'");

                    if (Last_Logistic_Action.Action_Dt > (DateTime)ActionDt)
                        _Errors["Action_Dt"] = string.Format("Action Date '{0:d}' must take place after last Action Date '{1:d}'.", ActionDt, Last_Logistic_Action.Action_Dt);

                    if (Move_Start_Dt == null)
                        _Errors["Move_Start_Dt"] = string.Format("This cargo has not started moving.");

                    if (Move_End_Dt == null)
                        _Errors["Move_End_Dt"] = string.Format("This cargo must be at final destination.");


                    break;
                case TRACKING_ACTIONS.CARGO_DECOMMISSION_TAG:

                    if (Tag_No.IsNull())
                        _Errors["Tag_No"] = "Cannot De-Commission a Tag that does not exist.";

                    if (Tag_Commission_Dt > (DateTime)ActionDt)
                        _Errors["Tag_Commission_Dt"] = "Cannot De-Commission a Tag before the Commission Date.";

                    break;
            }

            return _Errors.Count == 0;
        }

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			if (Vendor_Move_ID == null)
				_Errors["Vendor_Move_ID"] = "Missing vendor move";
			if (string.IsNullOrEmpty(Serial_No) == true)
				_Errors["Serial_No"] = "Missing serial #";

			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";
		}
		#endregion		// #region Validation

        #region Cargo Actions

        public ClsCargoAction AddAction(ClsAction Action, ClsLocation Location, DateTime ActionDt)
        {
            ClsCargoAction ca = new ClsCargoAction();

            if (LastAction != null)      
            {
                ca.CopyFrom(LastAction);
            }

            ca.Cargo_Move_ID = Cargo_Move_ID;
            ca.Action_Cd = Action.Action_Cd;
            ca.Location_Cd = Location.Location_Cd;
            ca.Action_Dt = ActionDt;
            ca.Active_Flg = "Y";
            ca.Insert();

            return ca;
        }

        #endregion
    }
}