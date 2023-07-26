using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmCargoActions : frmChildBase, ISearchWindow
    {

        #region Fields

        manager_cargo_actions _manager_cargo_actions = new manager_cargo_actions();
        frmActionUpdate _Action_Update = new frmActionUpdate();

        bool AutoExpandResults = true;

        #endregion

        #region Init

        public frmCargoActions()  : base()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            WindowHelper.InitAllGrids(this);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }          

        #endregion

        #region Properties

        public ClsCargoMove CurrentCargo 
        {
            get
            {
                if (CurrentCargoRow == null) return null;
                return new ClsCargoMove(CurrentCargoRow);
            }
        }

        private bool IsCurrentConveyanceConus
        {
            get
            {
                DataRow[] drs = null;

                //switch (tcActions.SelectedIndex)
                switch (utcActions.SelectedTab.Index)
                {
                    case 0:
                        if (grdOVPC.CurrentTable.Key == "conveyance")
                            drs = grdOVPC.GetCheckedDataRows();
                        break;
                    case 1:
                        if (grdENROUTE.CurrentTable.Key == "conveyance")
                            drs = grdENROUTE.GetCheckedDataRows();
                        break;
                    case 2:
                        if (grdIVPC.CurrentTable.Key == "conveyance")
                            drs = grdIVPC.GetCheckedDataRows();
                        break;
                    case 4:
                        if (grdCompletedMoves.CurrentTable.Key == "conveyance")
                            drs = grdCompletedMoves.GetCheckedDataRows();
                        break;
                }

                if (drs != null)
                    return (drs[0]["conus_flg"].ToString() == "Y");

                return false;
            }
        }


        public DataRow CurrentCargoRow
        {
            get
            {
                
                //switch (tcActions.SelectedIndex)
                switch (utcActions.SelectedTab.Index)
                {
                    case 0:
                        if (grdOVPC.CurrentTable.Key == "cargo")
                            return grdOVPC.GetDataRow();
                        break;
                    case 1:
                        if (grdENROUTE.CurrentTable.Key == "cargo")
                            return grdENROUTE.GetDataRow();
                        break;
                    case 2:
                        if (grdIVPC.CurrentTable.Key == "cargo")
                            return grdIVPC.GetDataRow();
                        break;
                    case 3:
                        if (grdDVPC.CurrentTable.Key == "cargo")
                            return grdDVPC.GetDataRow();
                        break;
                    case 4:
                        if (grdCompletedMoves.CurrentTable.Key == "cargo")
                            return grdCompletedMoves.GetDataRow();
                        break;

                }
                return null;
            }
        }

        public DataRow[] SelectedCargoRows
        {
            get
            {
                DataRow[] DRS = null;

                switch (utcActions.SelectedTab.Index)
                {
                    case 0:
                        if (grdOVPC.CurrentTable.Key == "cargo") DRS = grdOVPC.GetCheckedDataRows();
                        break;
                    case 1:
                        if (grdENROUTE.CurrentTable.Key == "cargo") DRS = grdENROUTE.GetCheckedDataRows();
                        break;
                    case 2:
                        if (grdIVPC.CurrentTable.Key == "cargo") DRS = grdIVPC.GetCheckedDataRows();
                        break;
                    case 3:
                        if (grdDVPC.CurrentTable.Key == "cargo") DRS = grdDVPC.GetCheckedDataRows();
                        break;
                    case 4:
                        if (grdCompletedMoves.CurrentTable.Key == "cargo") DRS = grdCompletedMoves.GetCheckedDataRows();
                        break;
                }

                if (DRS.IsNull()) return null;
                
                return DRS;
            }
        }

        #endregion

        #region Public Methods

        public void ShowForm()
        {
            try
            {
                this.Show();
                RefreshAll();
                ShowOptions(0);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowSearch(bool showOptions)
        {
            throw new NotImplementedException();
        }

        public void RefreshResults()
        {
            RefreshAll();
        }

        #endregion

        #region Private Methods

        private void RefreshAll()
        {
            try
            {
                Refresh_OVPC();
                Refresh_ENROUTE();
                Refresh_IVPC();
                Refresh_DVPC();
                Refresh_Complete();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Refresh_OVPC()
        {
            try
            {
                DataSet ds = _manager_cargo_actions.SearchForConveyancesAtOVPC();
                grdOVPC.SetDataBinding(ds, "conveyance");

                if (AutoExpandResults)
                    grdOVPC.ExpandRecords();
                else
                    grdOVPC.CollapseRecords();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Refresh_ENROUTE()
        {
            try
            {
                DataSet ds = _manager_cargo_actions.SearchForConveyancesENROUTE();
                grdENROUTE.SetDataBinding(ds, "conveyance");

                if (AutoExpandResults)
                    grdENROUTE.ExpandRecords();
                else
                    grdENROUTE.CollapseRecords();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Refresh_IVPC()
        {
            try
            {
                DataSet ds = _manager_cargo_actions.SearchForConveyancesAtIVPC();
                grdIVPC.SetDataBinding(ds, "conveyance");

                if (AutoExpandResults)
                    grdIVPC.ExpandRecords();
                else
                    grdIVPC.CollapseRecords();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Refresh_DVPC()
        {
            try
            {
                grdDVPC.DataSource = _manager_cargo_actions.SearchForCargoAtDVPC();

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Refresh_Complete()
        {
            try
            {
                DataSet ds = _manager_cargo_actions.SearchForCargoCompletedMoves();
                grdCompletedMoves.SetDataBinding(ds, "conveyance");

                if (AutoExpandResults)
                    grdCompletedMoves.ExpandRecords();
                else
                    grdCompletedMoves.CollapseRecords();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private bool PreValidate(DataRow[] drs)
        {

            return true;
        }

        private void ActionDepartOrigin()
        {
            try
            {
                if (grdOVPC.GetCheckedDataRows() == null) return;

                _Action_Update.ShowDepartOrigin();
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.ConveyanceActionUpdate(
                    TRACKING_ACTIONS.CONVEYANCE_DEPART_ORIGIN,
                    grdOVPC.GetCheckedDataRows(),
                    _Action_Update.SelectedActionDt,
                    null))
                {
                    RefreshAll();
                }
                else
                {
					string sMsg = _manager_cargo_actions.sError;
                    MessageBox.Show("Could not complete operation.");
					if (!string.IsNullOrEmpty(sMsg))
						MessageBox.Show(sMsg);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);


            }
        }

        private void ActionArrive()
        {
            try
            {
                if (grdENROUTE.GetCheckedDataRows() == null) return;

                _Action_Update.ShowArrive(IsCurrentConveyanceConus);
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.ConveyanceActionUpdate(
                    TRACKING_ACTIONS.CONVEYANCE_ARRIVE,
                    grdENROUTE.GetCheckedDataRows(),
                    _Action_Update.SelectedActionDt,
                    _Action_Update.SelectedLocation))
                {
                    RefreshAll();
                }
                else
                {
					if (!String.IsNullOrEmpty(_manager_cargo_actions.sError))
						MessageBox.Show(_manager_cargo_actions.sError);
					else
						MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionDepart()
        {
            try
            {
                if (grdIVPC.GetCheckedDataRows() == null) return;

                _Action_Update.ShowDepart();
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.ConveyanceActionUpdate(
                    TRACKING_ACTIONS.CONVEYANCE_DEPART,
                    grdIVPC.GetCheckedDataRows(),
                    _Action_Update.SelectedActionDt,
                    null))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionInGate()
        {
            try
            {

                if (SelectedCargoRows == null) return;
                //if (CurrentCargoRow == null) return;

                _Action_Update.ShowInGate();
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.CargoActionUpdate(
                    TRACKING_ACTIONS.CARGO_IN_GATE,
                    SelectedCargoRows,
                    _Action_Update.SelectedActionDt,
                    null))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionStampOfDelivery()
        {
            try
            {
                if (SelectedCargoRows == null) return;
                //if (CurrentCargoRow == null) return;

                _Action_Update.ShowStampOfDelivery();
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.CargoActionUpdate(
                    TRACKING_ACTIONS.CARGO_STAMP_OF_DELIVERY,
                    SelectedCargoRows,
                    _Action_Update.SelectedActionDt,
                    null))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionUndoComplete()
        {
            try
            {
                if (grdCompletedMoves.GetCheckedDataRows() == null) return;

                if (_manager_cargo_actions.CargoActionUndoComplete(
                    grdCompletedMoves.GetCheckedDataRows() ))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionUndoAtDestination()
        {
            try
            {
                if (  grdDVPC.GetCheckedDataRows() == null) return;

                if (_manager_cargo_actions.CargoActionUndoAtDestinationCheck(
                    grdDVPC.GetCheckedDataRows()))
                {
                    MessageBox.Show("Errors found.");
                    return;
                }

                if (_manager_cargo_actions.CargoActionUndoAtDestination(
                    grdDVPC.GetCheckedDataRows() ))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionUndoAtInTransitLocation()
        {
            try
            {
                if (grdIVPC.GetCheckedDataRows() == null) return;

                if (_manager_cargo_actions.CargoActionUndoAtIVPC(
                    grdIVPC.GetCheckedDataRows()))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionUndoEnroute()
        {
            try
            {
                try
                {
                    if (grdENROUTE.GetCheckedDataRows() == null) return;

                    if (_manager_cargo_actions.CargoActionUndoEnroute(
                        grdENROUTE.GetCheckedDataRows()))
                    {
                        RefreshAll();
                    }
                    else
                    {
                        MessageBox.Show("Could not complete operation.");
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowError(ex);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowOptions(int CurrentTab)
        {
            try
            {
                tsmiDepartOrigin.Visible =
                    tsmiArrive.Visible =
                    tsmiDepart.Visible =
                    tsmiInGate.Visible =
                    tsmiStampOfDelivery.Visible =
                    tsmiUndoCargoComplete.Visible =
                    tsmiUndoCargoAtDestination.Visible = 
                    tsmiUndoConveyanceAtIVPC.Visible = 
                    tsmiUndoConveyanceEnroute.Visible  = false;

                tsddCargoActions.Enabled = true;
                tsddConveyanceActions.Enabled = true;

                switch (CurrentTab)
                {
                    case 0:
                        tsmiDepartOrigin.Visible = true;
                        break;
                    case 1:
                        tsmiArrive.Visible = true;
                        tsmiUndoConveyanceEnroute.Visible = true;
                        break;
                    case 2:
                        tsmiDepart.Visible = true;
                        tsmiUndoConveyanceAtIVPC.Visible = true;
                        break;
                    case 3:
                        tsmiInGate.Visible = 
                        tsmiStampOfDelivery.Visible = true;
                        tsddCargoActions.Enabled = true;
                        tsddConveyanceActions.Enabled = false;
                        tsmiUndoCargoAtDestination.Visible = true;
                        break;
                    case 4:
                        tsddCargoActions.Enabled = true;
                        tsddConveyanceActions.Enabled = false;
                        tsmiUndoCargoComplete.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowCargoDetails()
        {
            try
            {
                frmCargoActionDetail CAD = new frmCargoActionDetail();
                CAD.ShowForm(CurrentCargo);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CommissionTag()
        {
            try
            {
                if (CurrentCargoRow == null) return;

                _Action_Update.ShowCommissionTag();
                if (_Action_Update.DialogResult != DialogResult.OK) return;

                if (_manager_cargo_actions.CargoActionUpdate(
                    TRACKING_ACTIONS.CARGO_COMMISSION_TAG,
                    CurrentCargoRow,
                    _Action_Update.SelectedActionDt,
                    _Action_Update.SelectedTagNo))
                {
                    RefreshAll();
                }
                else
                {
                    MessageBox.Show("Could not complete operation.");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SetAutoExpandResults()
        {
            try
            {
                AutoExpandResults = true;
                tsmiAutoExpandResults.Checked = true;
                tsmiAutoCollapseResults.Checked = false;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SetAutoCollapseResults()
        {
            try
            {
                AutoExpandResults = false;
                tsmiAutoExpandResults.Checked = false;
                tsmiAutoCollapseResults.Checked = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DecommissionTag()
        {
            try
            {
                try
                {
                    if (CurrentCargoRow == null) return;

                    _Action_Update.ShowDeCommissionTag();
                    if (_Action_Update.DialogResult != DialogResult.OK) return;

                    if (_manager_cargo_actions.CargoActionUpdate(
                        TRACKING_ACTIONS.CARGO_DECOMMISSION_TAG,
                        CurrentCargoRow,
                        _Action_Update.SelectedActionDt,
                        null))
                    {
                        RefreshAll();
                    }
                    else
                    {
                        MessageBox.Show("Could not complete operation.");
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowError(ex);
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            ShowOptions(tc.SelectedIndex);
        }

        private void utcActions_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            ShowOptions(utcActions.SelectedTab.Index);
        }

        private void tsmiDepartOrigin_Click(object sender, EventArgs e)
        {
            ActionDepartOrigin();
        }

        private void tsmiArrive_Click(object sender, EventArgs e)
        {
            ActionArrive();
        }

        private void tsmiDepart_Click(object sender, EventArgs e)
        {
            ActionDepart();
        }

        private void tsmiInGate_Click(object sender, EventArgs e)
        {
            ActionInGate();
        }

        private void tsmiStampOfDelivery_Click(object sender, EventArgs e)
        {
            ActionStampOfDelivery();
        }

        private void tsmiCommissionTag_Click(object sender, EventArgs e)
        {
            CommissionTag();
        }

        private void tsmiDecommissionTag_Click(object sender, EventArgs e)
        {
            DecommissionTag();
        }

        private void grdOVPC_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            ShowCargoDetails();
        }

        private void grdENROUTE_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            ShowCargoDetails();
        }

        private void grdIVPC_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            ShowCargoDetails();
        }

        private void grdDVPC_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            ShowCargoDetails();
        }        
        
        private void grdCompletedMoves_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            ShowCargoDetails();
        }        
        
        private void tsmiAutoCollapseResults_Click(object sender, EventArgs e)
        {
            SetAutoCollapseResults();
        }

        private void tsmiAutoExpandResults_Click(object sender, EventArgs e)
        {
            SetAutoExpandResults();
        }      

        private void grdOVPC_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            switch (e.Column.DataMember)
            {
                case "TAG_NO":
                    CommissionTag();
                    break;
                case "TAG_DECOMMISSION_DT":
                    DecommissionTag();
                    break;
            }
        }

        private void grdENROUTE_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            switch (e.Column.DataMember)
            {
                case "TAG_NO":
                    CommissionTag();
                    break;
                case "TAG_DECOMMISSION_DT":
                    DecommissionTag();
                    break;
            }
        }

        private void grdIVPC_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            switch (e.Column.DataMember)
            {
                case "TAG_NO":
                    CommissionTag();
                    break;
                case "TAG_DECOMMISSION_DT":
                    DecommissionTag();
                    break;
            }
        }

        private void grdDVPC_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            switch (e.Column.DataMember)
            {
                case "TAG_NO":
                    CommissionTag();
                    break;
                case "TAG_DECOMMISSION_DT":
                    DecommissionTag();
                    break;
                case "IN_GATE_DT":
                    ActionInGate();
                    break;
                case "DELIVERY_DT":
                    ActionStampOfDelivery();
                    break;
            }
        }




        private void tsmiUndoConveyanceEnroute_Click(object sender, EventArgs e)
        {
            ActionUndoEnroute();
        }

        private void tsmiUndoConveyanceAtIVPC_Click(object sender, EventArgs e)
        {
            ActionUndoAtInTransitLocation();
        }

        private void tsmiUndoCargoAtDestination_Click(object sender, EventArgs e)
        {
            ActionUndoAtDestination();
        }

        private void tsmiUndoCargoComplete_Click(object sender, EventArgs e)
        {
            ActionUndoComplete();
        }

        #endregion

    }
}
