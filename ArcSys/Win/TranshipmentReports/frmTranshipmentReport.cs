using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.Common;
using CS2010.CommonSecurity;


/*
 *  2013-02-13 - JD
 *  NOTE:  Tried to implement a Model- View-ViewModel (MVVM)approach but this does not work well with WinForms. 
 *  Reason being is ViewModel needs to bind to View (Form) and there are some controls that don't bind due to an 
 *  absense of 'DataBinding' attribute (i.e. Status Bars, Menus etc).  The only way to make it work is to create  
 *  View-level propeties that the ViewModel binds to but that is a lot of additional coding.  
 *  
 * MVC/MVVM works well in WPF because you can bind to ANY attribute in the View.   
 * 
 * For this, example I am just going to implement a basic Model (not a ViewModel) that interacts with a Controller.
 */
namespace CS2010.ArcSys.Win
{
    public partial class frmTranshipmentReport : frmChildBase
    {
        private sql_transhipment_booking bookingSearch = new sql_transhipment_booking();
        private sql_transhipment_bol bolSearch = new sql_transhipment_bol();

        conTranshipmentReport cTR = new conTranshipmentReport();
        //modTranshipmentReport mTR;

        private delegate void SearchCompleteDelegate(bool Success);
        private SearchCompleteDelegate BookingSearchCompleteDelegate;
        private SearchCompleteDelegate BolSearchCompleteDelegate;



        public frmTranshipmentReport()
        {
            InitializeComponent();

            AdjustForm(Program.MainWindow, true, null);

            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        public void ShowForm()
        {
            Setup();
            this.Show();
        }

        public void Setup()
        {
            SearchOff();
            Reset();
        }

        #region Private Methods

        private void SearchOn()
        {
            tsbCancelSearch.Visible = tsProgress.Visible = true;
        }

        private void SearchOff()
        {
            tsbCancelSearch.Visible = tsProgress.Visible = false;
        }

        private void Search()
        {
            try
            {

                modTranshipmentReport mTR = new modTranshipmentReport()
                {
                    IsBooking = (rbBooking.Checked),
                    sailDateFrom = dtSailDates.FromDate,
                    sailDateTo = dtSailDates.ToDate,
                    voyage = txtVoyage.Text,
                    vessels = cmbVessels.VesselCDs,
                    bol = txtBOL.Text,
                    booking = txtBooking.Text
                };

                if (!cTR.TestSAGAEDIConnection())
                {
                    MessageBox.Show("Error, could not connect to the database.  Please contact an administrator.");
                    return;
                }

                if (mTR.IsBooking)
                {

                    if(grdTranshipment.CurrentLayout==null || grdTranshipment.CurrentLayout.Key!="layoutBooking") 
                        grdTranshipment.CurrentLayout = grdTranshipment.Layouts["layoutBooking"]; 

                    bookingSearch.Run(mTR);
                }
                else // must be bolChecked
                {
                    if (grdTranshipment.CurrentLayout == null || grdTranshipment.CurrentLayout.Key != "layoutBol")
                        grdTranshipment.CurrentLayout = grdTranshipment.Layouts["layoutBol"]; 

                    bolSearch.Run(mTR);
                }
                SearchOn();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Reset()
        {
            try
            {
                rbBooking.Checked = true;
                dtSailDates.CheckBoxChecked = false;
                txtVoyage.Text = txtBooking.Text = txtBOL.Text = string.Empty;
                cmbVessels.SelectedText = string.Empty;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Print()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CancelSearch()
        {
            try
            {
                bookingSearch.Abort();
                bolSearch.Abort();
                SearchOff();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void BookingBolChanged()
        {
            try
            {
                if (rbBOL.Checked)
                {
                    txtBOL.Enabled = true;
                    txtBooking.Enabled = false;
                }
                else
                {
                    txtBooking.Enabled = true;
                    txtBOL.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Search / SQL Base Methods

        private void BookingSearchComplete(bool Success)
        {
            grdTranshipment.DataSource = bookingSearch.Data;
            grdTranshipment.RootTable.Caption = bookingSearch.Message_RowsAffectedElapsedTime;
            SearchOff();
        }

        private void BolSearchComplete(bool Success)
        {
            grdTranshipment.DataSource = bolSearch.Data;
            grdTranshipment.RootTable.Caption = bolSearch.Message_RowsAffectedElapsedTime;
            SearchOff();
        }

        public void BookingSearchStatus(object o, SearchEventArgs e)
        {
            Invoke(BookingSearchCompleteDelegate,true );
        }

        private void BolSearchStatus(object o, SearchEventArgs e)
        {
            Invoke(BolSearchCompleteDelegate, true);
        }

        #endregion


        #region Event Handlers

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void tsbCancelSearch_Click(object sender, EventArgs e)
        {
            CancelSearch();
        }

        private void rbBooking_CheckedChanged(object sender, EventArgs e)
        {
            BookingBolChanged();
        }

        private void rbBOL_CheckedChanged(object sender, EventArgs e)
        {
            BookingBolChanged();
        }

        private void frmTranshipmentReport_Load(object sender, EventArgs e)
        {
            BookingSearchCompleteDelegate = new SearchCompleteDelegate(BookingSearchComplete);
            BolSearchCompleteDelegate = new SearchCompleteDelegate(BolSearchComplete);

            bookingSearch.SearchStatus += new sql_base.SearchEventHandler(BookingSearchStatus);
            bolSearch.SearchStatus += new sql_base.SearchEventHandler(BolSearchStatus);

        }

        private void frmTranshipmentReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            bookingSearch.SearchStatus -= new sql_base.SearchEventHandler(BookingSearchStatus);
            bolSearch.SearchStatus -= new sql_base.SearchEventHandler(BolSearchStatus);
        }

        #endregion


    }
}
