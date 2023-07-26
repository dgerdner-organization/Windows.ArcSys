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
    public partial class frmSearchMove : frmChildBase, ISearchWindow
    {

        private delegate void SearchCompleteDelegate(SearchEventArgs e, bool Success);
        private SearchCompleteDelegate SearchComplete;

        private sql_moves _moves = new sql_moves();

        #region Init

        public frmSearchMove() : base()
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
            try
            {
                // Initializing the Delegate
                SearchComplete = new SearchCompleteDelegate(InvokeSearchComplete);

                // Subscribing to the SearchStatus Event Hanlder
                _moves.SearchStatus += new sql_base.SearchEventHandler(SearchUpdate);

                Clear();
                SearchingOff();
                this.Show();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Private Methods


        private void InvokeSearchComplete(SearchEventArgs e, bool Success)
        {
            try
            {
                grdMoves.DataSource = e.Data;
                grdMoves.RootTable.Caption = (Success) ? e.Message_RowsAffectedElapsedTime : string.Empty;
                SearchingOff();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SearchUpdate(object o, SearchEventArgs e)
        {
            try
            {
                Invoke(SearchComplete, new object[] { e, (e.Status == SearchStatusCd.Complete) });
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        private void SearchingOn()
        {
            try
            {
                tsbCancelSearch.Visible =
                    tsProgress.Visible = true;

                tsbSearch.Visible =
                    tsbClear.Visible;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SearchingOff()
        {
            try
            {
                tsbCancelSearch.Visible =
                    tsProgress.Visible = false;

                tsbSearch.Visible =
                    tsbClear.Visible = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Abort()
        {
            try
            {
                _moves.Abort();
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
                cmbVendor.Clear();
                cmbOrigin.Clear();
                cmbDestination.Clear();
                txtBookingNo.Clear();
                txtVoyageNo.Clear();
                txtSerialNo.Clear();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Search()
        {
            try
            {
                SearchingOn();

                _moves.Run(
                    cmbVendor.SelectedVendorCD,
                    cmbOrigin.SelectedLocationCD,
                    cmbDestination.SelectedLocationCD,
                    txtBookingNo.Text,
                    txtSerialNo.Text,
                    txtVoyageNo.Text);

                //do { Application.DoEvents(); }
                //while (_moves.STATUS_CD == SQL_STATUS_CD.RUNNING);

                //if (_moves.STATUS_CD == SQL_STATUS_CD.COMPLETE)
                //{
                //    grdMoves.DataSource = _moves.Data;
                //    grdMoves.RootTable.Caption = _moves.Message_RowsAffectedElapsedTime;
                //}

                //SearchingOff();
				
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                SearchingOff();
            }
        }

        private void CreateMove()
        {            
            try
            {
                frmEditVendorMove cm = new frmEditVendorMove();
                cm.ShowForm();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ShowMove()
        {
            try
            {
                frmEditVendorMove cm = new frmEditVendorMove();
                ClsMove m = new ClsMove(grdMoves.GetDataRow());

                cm.ShowForm(m);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

		private void ShowVendorMove()
		{
			ClsVendorMove vm = new ClsVendorMove(grdMoves.GetDataRow());
			long lID = vm.Vendor_Move_ID.GetValueOrDefault();
			ClsVendorMove vMove = ClsVendorMove.GetUsingKey(lID);
			Program.MainWindow.ShowCreateMove(vMove);
		}

		private void CreateVendorMove()
		{
			if (grdMoves.GetDataRow() == null)
				return;
			ClsMove m = new ClsMove(grdMoves.GetDataRow());
			Program.MainWindow.ShowCreateVendorMove(m);
		}
        private void ToolTipWorkAround()
        {
            try
            {
                // Fix to Tooltip problem ... more on the problem check out:
                // http://stackoverflow.com/questions/559707/winforms-tooltip-will-not-re-appear-after-first-use

                ToolTip.Active = false;
                ToolTip.Active = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void tsbCancelSearch_Click(object sender, EventArgs e)
        {
            Abort();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }       
 
        public void ShowSearch(bool showOptions)
        {
            grpSearch.Expanded = true;
        }

        public void RefreshResults()
        {
            Search();
        }

        private void frmSearchMove_FormClosing(object sender, FormClosingEventArgs e)
        {
            _moves.SearchStatus -= new sql_base.SearchEventHandler(SearchUpdate);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbCreateMove_Click(object sender, EventArgs e)
        {
            CreateMove();
        }
  
        private void grdMoves_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                ShowVendorMove();
        }

        private void grdMoves_MouseEnter(object sender, EventArgs e)
        {
            ToolTipWorkAround();
        }
		private void tsbCreateVendorMove_Click(object sender, EventArgs e)
		{
			CreateVendorMove();
		}
        #endregion 



    }
}
