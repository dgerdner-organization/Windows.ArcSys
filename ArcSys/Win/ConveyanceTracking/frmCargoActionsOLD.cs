using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmCargoActionsOLD : frmChildBase, ISearchWindow
    {

        #region Init

        public frmCargoActionsOLD()
            : base()
        {
            InitializeComponent();

            AdjustForm(Program.MainWindow, true, null);

            WindowHelper.InitAllGrids(this);

            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

        }           

        #endregion

        #region Public Methods

        public void ShowForm()
        {
            this.Show();
        }     
  
        public void ShowSearch(bool showOptions)
        {
            throw new NotImplementedException();
        }

        public void RefreshResults()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private void Search()
        {            
            try
            {
                //manager_cargo_actions ca = new manager_cargo_actions();

                //DataSet ds = ca.SearchForConveyancesAndCargo(
                //                cmbMove.SelectedMoveID,
                //                txtSerialNo.Text,
                //                txtTruckNo.Text,
                //                cmbOrigin.SelectedLocationCD,
                //                cmbDestination.SelectedLocationCD,
                //                cmbLastAction.SelectedActionCD,
                //                cmbLastLocation.SelectedLocationCD);

                //grdCargo.SetDataBinding(ds, "conveyance");
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowErrors()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowSuccess()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ActionUpdate()
        {
            try
            {
                //frmActionUpdate au = new frmActionUpdate();
                //au.ShowDialog();

                //if (au.DialogResult != DialogResult.OK) return;

                //manager_cargo_actions ca = new manager_cargo_actions();

                //if (grdCargo.GetCheckedDataRows() == null)
                //{
                //    if ((ca.ActionUpdate(grdCargo.GetCheckedDataRows(), au.ActionCd, au.LocationCd, au.ActionDt)) == false)
                //        ShowErrors();
                //    else
                //        ShowSuccess();
                //}

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                cmbMove.Clear();
                txtSerialNo.Text = string.Empty;
                txtTruckNo.Text = string.Empty;
                cmbOrigin.Clear();
                cmbDestination.Clear();
                cmbLastAction.Clear();
                cmbLastLocation.Clear();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }     
 
        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbActionUpdate_Click(object sender, EventArgs e)
        {
            ActionUpdate();
        }

        private void grdCargo_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {

        }
        #endregion





    }
}
