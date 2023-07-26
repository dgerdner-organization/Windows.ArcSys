using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.AVSS.Business;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmPortOpsArriveDepart : Form
    {
        private BindingList<mConvenientArrDep> _lstCAD;

        #region Constructor

        public frmPortOpsArriveDepart()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public void ShowOpen(BindingList<mConvenientArrDep> lstCAD)
        {
            _lstCAD = lstCAD;

            grdPortCalls.DataSource = _lstCAD;

             this.ShowDialog();
        }

        #endregion

        #region Private Methods

        private void RefeshGrid()
        {
            try
            {
                ClsConvenientArrDep c = new ClsConvenientArrDep();
                BindingList<mConvenientArrDep> x = (BindingList<mConvenientArrDep>)c.LoadArrDepWWL();

                if (x != null && x.Count > 0)
                {
                    grdPortCalls.DataSource = x;
                    grdPortCalls.Refresh();
                }
                else
                {
                    MessageBox.Show("There are no Port Calls to Arrive or Depart at this time. (Closing the window)");
                    Cancel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private mConvenientArrDep GetPortCall()
        {
            try 
	        {
                mConvenientArrDep ad = (mConvenientArrDep)grdPortCalls.CurrentRow.DataRow;
                return ad;
	        }
        	catch (Exception ex)
	        {
		        Program.ShowError(ex);
                return null;
	        }
        }

        private bool CheckDate(DateTime OldDate, DateTime NewDate)
        {
            DateTime MinDate = OldDate.AddHours(-24);
            DateTime MaxDate = OldDate.AddHours(24);

            if (NewDate < MinDate)
            {
                MessageBox.Show("The Date Entered can not be less than " + MinDate.ToString());
                return false;
            }
            if (NewDate > MaxDate)
            {
                MessageBox.Show("The Date Entered can not be greater than " + MaxDate.ToString());
                return false;
            }

            return true;

        }

        private void Arrive()
        {
            try
            {
                mConvenientArrDep ad = GetPortCall();
                if (ad.IsNull()) return;

                if (!CheckDate(ad.Arrive_Dt.ToDateTime(), dtArrive.Value.ToDateTime())) return;

                ad.Arrive_Dt = dtArrive.Value.ToDateTime();
                ad.Act_Arrive_Flg = "Y";

                // This needs to be TESTED!!!
                if (ad.Update() != 1)
                {
                    MessageBox.Show("Port Call could not be 'Arrived'.  Please contact an Administrator.");
                    ClsErrorHandler.LogError("Port Call could not be Arrived.  Vessel: {0}, Port Call: {1}", ad.vessel_nm, ad.port_nm);
                }
                // No longer needed ...
                //else
                //{
                //    ad.GenerateVesselEDI("A");
                //}

                MessageBox.Show("Arrive Operation Successful!");

                RefeshGrid();
                //Cancel();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Depart()
        {
            try
            {
                mConvenientArrDep ad = GetPortCall();
                if (ad.IsNull()) return;

                if (!CheckDate(ad.Depart_Dt.ToDateTime(), dtDepart.Value.ToDateTime())) return;

                ad.Depart_Dt = dtDepart.Value.ToDateTime();
                ad.Act_Depart_Flg = "Y";

                // This needs to be TESTED!!!
                if (ad.Update() != 1)
                {
                    MessageBox.Show("Port Call could not be 'Departed'.  Please contact an Administrator.");
                    ClsErrorHandler.LogError("Port Call could not be Departed.  Vessel: {0}, Port Call: {1}", ad.vessel_nm, ad.port_nm);
                }
                // No longer needed ...
                //else
                //{
                //    ad.GenerateVesselEDI("D");
                //}


                MessageBox.Show("Depart Operation Successful!");

                RefeshGrid();
                //Cancel();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SelectRow()
        {
            try
            {
                mConvenientArrDep ad = GetPortCall();

                dtArrive.Value = ad.Arrive_Dt;
                dtDepart.Value = ad.Depart_Dt;

                if ((ad.Act_Arrive_Flg == "N") && (ad.Act_Depart_Flg == "N"))
                {
                    pnlArrive.Enabled = btnArrive.Enabled = true;
                    pnlDepart.Enabled = btnDepart.Enabled = false;
                }
                else if ((ad.Act_Arrive_Flg == "Y") && (ad.Act_Depart_Flg == "N"))
                {
                    pnlArrive.Enabled = btnArrive.Enabled = false;
                    pnlDepart.Enabled = btnDepart.Enabled = true;
                }
                else {
                    pnlArrive.Enabled = btnArrive.Enabled = false;
                    pnlDepart.Enabled = btnDepart.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Cancel()
        {
            this.Close();
        }

        #endregion

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void btnArrive_Click(object sender, EventArgs e)
        {
            Arrive();
        }

        private void btnDepart_Click(object sender, EventArgs e)
        {
            Depart();
        }

        private void grdPortCalls_SelectionChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        #endregion
    }
}
