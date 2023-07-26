using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{

    public class manager_cargo_actions
    {

        #region Connection Manager

        protected static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }

        #endregion		// #region Connection Manager

		#region Public Attributes
		public string sError;
		#endregion

		#region Public Methods

		#region Searches

		public DataSet SearchForConveyancesAtOVPC()
        {

            sql_cargo_actions_conveyance _conveyance = new sql_cargo_actions_conveyance();
            _conveyance.Async = false;
            _conveyance.RunForOVPC();
            _conveyance.Data.TableName = "conveyance";

            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForOVPC();
            _cargo.Data.TableName = "cargo";

            DataSet ds = new DataSet();

            ds.Tables.Add(_conveyance.Data);
            ds.Tables.Add(_cargo.Data);

            ds.Relations.Add(new DataRelation("cargo",
                _conveyance.Data.Columns["conveyance_id"],
                _cargo.Data.Columns["conveyance_id"], false));

            return ds;

        }

        public DataSet SearchForConveyancesAtIVPC()
        {

            sql_cargo_actions_conveyance _conveyance = new sql_cargo_actions_conveyance();
            _conveyance.Async = false;
            _conveyance.RunForIVPC();
            _conveyance.Data.TableName = "conveyance";

            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForIVPC();
            _cargo.Data.TableName = "cargo";

            DataSet ds = new DataSet();

            ds.Tables.Add(_conveyance.Data);
            ds.Tables.Add(_cargo.Data);

            ds.Relations.Add(new DataRelation("cargo",
                _conveyance.Data.Columns["conveyance_id"],
                _cargo.Data.Columns["conveyance_id"], false));

            return ds;

        }

        public DataSet SearchForConveyancesENROUTE()
        {

            sql_cargo_actions_conveyance _conveyance = new sql_cargo_actions_conveyance();
            _conveyance.Async = false;
            _conveyance.RunForENROUTE();
            _conveyance.Data.TableName = "conveyance";

            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForENROUTE();
            _cargo.Data.TableName = "cargo";

            DataSet ds = new DataSet();

            ds.Tables.Add(_conveyance.Data);
            ds.Tables.Add(_cargo.Data);

            ds.Relations.Add(new DataRelation("cargo",
                _conveyance.Data.Columns["conveyance_id"],
                _cargo.Data.Columns["conveyance_id"], false));

            return ds;

        }

        public DataSet SearchForConveyancesAtDVPC()
        {

            sql_cargo_actions_conveyance _conveyance = new sql_cargo_actions_conveyance();
            _conveyance.Async = false;
            _conveyance.RunForDVPC();
            _conveyance.Data.TableName = "conveyance";

            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForDVPC();
            _cargo.Data.TableName = "cargo";

            DataSet ds = new DataSet();

            ds.Tables.Add(_conveyance.Data);
            ds.Tables.Add(_cargo.Data);

            ds.Relations.Add(new DataRelation("cargo",
                _conveyance.Data.Columns["conveyance_id"],
                _cargo.Data.Columns["conveyance_id"], false));

            return ds;

        }

        public DataTable SearchForCargoAtDVPC()
        {
            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForDVPC();
            _cargo.Data.TableName = "cargo";

            return _cargo.Data;
        }

        public DataSet SearchForCargoCompletedMoves()
        {

            sql_cargo_actions_conveyance _conveyance = new sql_cargo_actions_conveyance();
            _conveyance.Async = false;
            _conveyance.RunForCompletedMoves();
            _conveyance.Data.TableName = "conveyance";

            sql_cargo_actions_cargo _cargo = new sql_cargo_actions_cargo();
            _cargo.Async = false;
            _cargo.RunForCompletedMoves();
            _cargo.Data.TableName = "cargo";

            DataSet ds = new DataSet();

            ds.Tables.Add(_conveyance.Data);
            ds.Tables.Add(_cargo.Data);

            ds.Relations.Add(new DataRelation("cargo",
                _conveyance.Data.Columns["conveyance_id"],
                _cargo.Data.Columns["conveyance_id"], false));

            return ds;

        }

        #endregion

        #region Actions

        public bool PreValidateConveyances(DataRow[] Conveyances)
        {
            ClsConveyance _Conveyance;
            string LastLocation = "NA";

            foreach (DataRow dr in Conveyances)
            {
                _Conveyance = new ClsConveyance(dr);
                foreach (ClsCargoMove cm in _Conveyance.ListOfCargoMoves)
                {
                    if (LastLocation == "NA") LastLocation = cm.Last_Logistic_Action.Location_Cd;
                    if (cm.Last_Logistic_Action.Location_Cd != LastLocation) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Updates Multiple Cargo Moves (ClsCargoMove), with specified TRACKING_ACTION
        /// </summary>
        /// <param name="Action">TRACKING_ACTION for the Cargo Move.</param>
        /// <param name="drs">The List of DataRows with data to update.</param>
        /// <param name="ActionDt">The Date that Action took place on.</param>
        /// <param name="TagNo">The TagNo to update (if applicable).</param>
        /// <returns>True if successful, False if errors</returns>
        public bool CargoActionUpdate(TRACKING_ACTIONS Action, DataRow[] drs, DateTime ActionDt, string TagNo)
        {
            bool newTx = !Connection.IsInTransaction;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                foreach (DataRow dr in drs)
                {
                    if (CargoActionUpdate(Action, dr, ActionDt, TagNo) == false)
                    {
                        Connection.TransactionRollback();
                        return false;
                    }
                }   

                if (newTx == true)
                {
                    Connection.TransactionCommit();
                }

                return true;
            }
            catch (Exception)
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }

        }


        /// <summary>
        /// Updates Cargo Moves (ClsCargoMove) on DataRow at a time, with specified TRACKING_ACTION
        /// </summary>
        /// <param name="Action">TRACKING_ACTION for the Cargo Move.</param>
        /// <param name="dr">The DataRow with data to update.</param>
        /// <param name="ActionDt">The Date that Action took place on.</param>
        /// <param name="TagNo">The TagNo to update (if applicable).</param>
        /// <returns>True if successful, False if errors</returns>
        public bool CargoActionUpdate(TRACKING_ACTIONS Action, DataRow dr, DateTime ActionDt, string TagNo)
        {
            bool newTx = !Connection.IsInTransaction;
            bool blnErrors = false;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsCargoMove cm = new ClsCargoMove(dr);

                switch (Action)
                {
                    case TRACKING_ACTIONS.CARGO_IN_GATE:

                        if (cm.ValidateAction(TRACKING_ACTIONS.CARGO_IN_GATE, null,ActionDt))
                        {
                            cm.In_Gate_Dt = ActionDt;
                            cm.Update();
                        }
                        else
                        {
                            blnErrors = true;
                            dr.RowError = cm.Error.ToString();
                            dr.SetColumnError("SERIAL_NO", dr.RowError);
                        }

                        break;
                    case TRACKING_ACTIONS.CARGO_STAMP_OF_DELIVERY:

                        if (cm.ValidateAction(TRACKING_ACTIONS.CARGO_STAMP_OF_DELIVERY, null,ActionDt))
                        {
                            cm.Delivery_Dt = ActionDt;
                            cm.Update();
                        }
                        else
                        {
                            blnErrors = true;
                            dr.RowError = cm.Error.ToString();
                            dr.SetColumnError("SERIAL_NO", dr.RowError);
                        }

                        break;
                    case TRACKING_ACTIONS.CARGO_COMMISSION_TAG:

                        // No Validation
                        cm.Tag_No = TagNo;
                        cm.Tag_Commission_Dt = ActionDt;
                        cm.Update();

                        break;

                    case TRACKING_ACTIONS.CARGO_DECOMMISSION_TAG:

                        if (cm.ValidateAction(TRACKING_ACTIONS.CARGO_DECOMMISSION_TAG, null,ActionDt))
                        {
                            cm.Tag_Decommission_Dt = ActionDt;
                            cm.Update();
                        }
                        else
                        {
                            blnErrors = true;
                            dr.RowError = cm.Error.ToString();
                            dr.SetColumnError("SERIAL_NO", dr.RowError);
                        }

                        break;
                }

                if (newTx == true)
                {
                    if (blnErrors)
                        Connection.TransactionRollback();
                    else
                        Connection.TransactionCommit();
                }

                return (!blnErrors);
            }
            catch (Exception)
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }

        }

        /// <summary>
        /// Updates Cargo Moves (ClsCargoMove) associated with Conveyances, with specified TRACKING_ACTION 
        /// </summary>
        /// <param name="Action">TRACKING_ACTION for the Cargo Move.</param>
        /// <param name="Conveyances">The Conveyances to apply action to.</param>
        /// <param name="ActionDt">The date the action took place on.</param>
        /// <param name="NewLocation">The location action took place at.</param>
        /// <returns>True if successful, False if errors.</returns>
        public bool ConveyanceActionUpdate(TRACKING_ACTIONS Action,DataRow[] Conveyances, DateTime ActionDt, ClsLocation NewLocation)
        {
            bool newTx = !Connection.IsInTransaction;
            bool blnErrors = false;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsConveyance _Conveyance;
                ClsAction _Action;
                ClsCargoAction _AddedAction;

                foreach (DataRow dr in Conveyances)
                {
                    _Conveyance = new ClsConveyance(dr);

                    foreach (ClsCargoMove cm in _Conveyance.ListOfCargoMoves)
                    {
                        switch(Action)
                        {
                            case TRACKING_ACTIONS.CONVEYANCE_DEPART_ORIGIN:

                                _Action = ClsAction.GetUsingKey("DEPART");

                                if (cm.ValidateAction(TRACKING_ACTIONS.CONVEYANCE_DEPART_ORIGIN, null, ActionDt))
                                {
                                    _AddedAction = cm.AddAction(_Action, cm.Vendor_Move.Orig_Location, ActionDt);
                                    cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = _AddedAction.Cargo_Action_ID;
                                    cm.Move_Start_Dt = ActionDt;
                                    cm.Update();
                                }
                                else
                                {
                                    blnErrors = true;
                                    dr.RowError = cm.Error.ToString();
                                    dr.SetColumnError("TRUCK_NO", dr.RowError);
                                }
                                
                                break;
                            case TRACKING_ACTIONS.CONVEYANCE_ARRIVE:

                                _Action = ClsAction.GetUsingKey("ARRIVE");

                                if (cm.ValidateAction(TRACKING_ACTIONS.CONVEYANCE_ARRIVE, NewLocation, ActionDt))
                                {
                                    _AddedAction = cm.AddAction(_Action, NewLocation, ActionDt);
                                    cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = _AddedAction.Cargo_Action_ID;

                                    if (cm.AreWeAtDestination == true)
                                        cm.Move_End_Dt = ActionDt;

                                    cm.Update();
                                }
                                else
                                {
									// JUNE2018 DGERDNER
									// Capture the actual error message
									sError = cm.Error;
                                    blnErrors = true;
                                    dr.RowError = cm.Error.ToString();
                                    dr.SetColumnError("TRUCK_NO", dr.RowError);
                                }

                                break;
                            case TRACKING_ACTIONS.CONVEYANCE_DEPART:

                                _Action = ClsAction.GetUsingKey("DEPART");

                                if (cm.ValidateAction(TRACKING_ACTIONS.CONVEYANCE_DEPART, null, ActionDt))
                                {
                                    _AddedAction = cm.AddAction(_Action, cm.LastLogisticsAction.Location , ActionDt);
                                    cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = _AddedAction.Cargo_Action_ID;
                                    cm.Update();
                                }
                                else
                                {
                                    blnErrors = true;
                                    dr.RowError = cm.Error.ToString();
                                    dr.SetColumnError("TRUCK_NO", dr.RowError);
                                }

                                break;
                        }
                    }
                }

                if (newTx == true)
                {
                    if (blnErrors)
                        Connection.TransactionRollback();
                    else
                        Connection.TransactionCommit();
                }

                return (!blnErrors);
            }
            catch 
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }

        }

        #endregion

        #region 'Undo' Actions

        public bool CargoActionUndoComplete(DataRow[] Cargo)
        {
            bool newTx = !Connection.IsInTransaction;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsCargoMove cm;

                foreach (DataRow dr in Cargo)
                {
                    cm = new ClsCargoMove(dr);
                    cm.Delivery_Dt = null;
                    cm.Update();
                }

                Connection.TransactionCommit();
                return true;
            }
            catch 
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }

        }

        public bool CargoActionUndoEnroute(DataRow[] Conveyances)
        {
            bool newTx = !Connection.IsInTransaction;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsConveyance C;
                ClsCargoAction ca;

                foreach (DataRow dr in Conveyances)
                {
                    C = new ClsConveyance(dr);
                    foreach (ClsCargoMove cm in C.ListOfCargoMoves)
                    {
                        ca = cm.Last_Cargo_Action;

                        if (cm.ActionBeforeLastAction == null)
                        {
                            // Put back to Origin
                            cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = null;
                            cm.Move_Start_Dt = null;
                        }
                        else
                        {
                            cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = cm.ActionBeforeLastAction.Cargo_Action_ID;
                        }
                        cm.Update();
                        ca.Delete();
                    }
                }

                Connection.TransactionCommit();
                return true;
            }
            catch
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }
        }

        public bool CargoActionUndoAtIVPC(DataRow[] Conveyances)
        {
            bool newTx = !Connection.IsInTransaction;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsConveyance C;
                ClsCargoAction ca;

                foreach (DataRow dr in Conveyances)
                {
                    C = new ClsConveyance(dr);
                    foreach (ClsCargoMove cm in C.ListOfCargoMoves)
                    {
                        ca = cm.Last_Cargo_Action;
                        cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = cm.ActionBeforeLastAction.Cargo_Action_ID;
                        cm.Move_End_Dt = null;
                        cm.Update();
                        ca.Delete();
                    }
                }
                Connection.TransactionCommit();
                return true;
            }
            catch
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }
        }

        public bool CargoActionUndoAtDestinationCheck(DataRow[] Cargo)
        {
            bool blnErrors = false;
            ClsCargoMove cm;

            foreach (DataRow dr in Cargo)
            {
                cm = new ClsCargoMove(dr);

                if (!AreAllCargoMovesSelectedForConveyance(cm,Cargo))
                {
                    dr.RowError = "For an undo you need to select all cargo attached to the conveyance.";
                    dr.SetColumnError("SERIAL_NO", dr.RowError);
                    blnErrors = true;
                }
            }

            return blnErrors;
        }

        /// <summary>
        /// Checks to see if the Cargo Moves selected also include accompanying Cargo Moves for the
        /// attached Conveyances.  NOTE: Linq would provide a much better, cleaner solution but
        /// need to research it to get it to work.
        /// </summary>
        /// <param name="cm">Cargo Move</param>
        /// <param name="Cargo">Selected Cargo Moves</param>
        /// <returns></returns>
        private bool AreAllCargoMovesSelectedForConveyance(ClsCargoMove CargoMoves, DataRow[] Cargo)
        {
            bool blnFound;
            ClsCargoMove cm2;

            foreach (ClsCargoMove cm in CargoMoves.CargoMovesAttachedToConveyance)
            {
                blnFound = false;

                foreach (DataRow dr in Cargo)
                {
                    cm2 = new ClsCargoMove(dr);
                    if (cm.Cargo_Move_ID == cm2.Cargo_Move_ID) 
                        blnFound = true;
                }
                if (blnFound == false) return false;
            }
            return true;
        }

        public bool CargoActionUndoAtDestination(DataRow[] Cargo)
        {
            bool newTx = !Connection.IsInTransaction;

            try
            {
                if (newTx == true) Connection.TransactionBegin();

                ClsCargoMove cm;
                ClsCargoAction ca;

                foreach (DataRow dr in Cargo)
                {
                    cm = new ClsCargoMove(dr);
                    ca = cm.Last_Cargo_Action;
                    cm.Last_Cargo_Action_ID = cm.Last_Logistic_Action_ID = cm.ActionBeforeLastAction.Cargo_Action_ID;
                    cm.Move_End_Dt = null;
                    cm.In_Gate_Dt = null;
                    cm.Update();
                    ca.Delete();
                }

                Connection.TransactionCommit();
                return true;
            }
            catch
            {
                if (newTx == true) Connection.TransactionRollback();
                return false;
            }
        }

        #endregion

        #endregion
    }

    public enum TRACKING_ACTIONS
    {
        CONVEYANCE_DEPART_ORIGIN,		// DEPART ORIGIN LOCATION (FROM VENDOR MOVE)
        CONVEYANCE_ARRIVE,	            // ARRIVE AT LOCATION
        CONVEYANCE_DEPART,	            // DEPART FROM CURRENT LOCATION 
        CARGO_IN_GATE,                  // IN-GATE
        CARGO_STAMP_OF_DELIVERY,	    // STAMP OF DELIVERY (END ACTION)
        CARGO_COMMISSION_TAG,           // ASSOCIATE E-ITV TAG TO CARGO
        CARGO_DECOMMISSION_TAG          // DISASSOCIATE E-ITV TAG FROM CARGO
    }
}
