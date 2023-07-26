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

namespace CS2010.ArcSys.Win
{
    public partial class frmMilitaryVoyages : frmChildBase
    {
        public frmMilitaryVoyages()
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

        #region Private Methods
        

        private void Setup()
        {
            try
            {
                sql_avss_ports p = new sql_avss_ports();
                p.Run();

                //cmbPort.DataBindings.Add("SelectedValue", p.Data, "port_cd");
                cmbPort.DisplayMember = "port_nm";
                cmbPort.ValueMember = "port_cd";
                cmbPort.DataSource = p.Data;
            
                sql_avss_vessels v = new sql_avss_vessels();
                v.Run();
                //cmbVessel.DataBindings.Add("SelectedValue", v.Data, "vessel_cd");
                cmbVessel.DisplayMember = "vessel_nm";
                cmbVessel.ValueMember = "vessel_cd";
                cmbVessel.DataSource = v.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            try
            {
                cmbPort.SelectedIndex = -1;
                cmbVessel.SelectedIndex = -1;
                dtSailDates.Clear();
                grdData.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search()
        {
            try
            {
                // Redirecting focus from search input so values can be properly updated
                grdData.Focus();

                sql_avss_military_voyages avss = new sql_avss_military_voyages();

                AvssMilitaryParams p = new AvssMilitaryParams();
                p.PortCd = (cmbPort.SelectedValue != null) ? cmbPort.SelectedValue.ToString() : null;
                p.VesselCd = (cmbVessel.SelectedValue != null) ? cmbVessel.SelectedValue.ToString() : null;
                p.DateFrom = (dtSailDates.FromDate != null) ? dtSailDates.FromDate : null;
                p.DateTo = (dtSailDates.ToDate != null) ? dtSailDates.ToDate : null;

                avss.Run(p);
                grdData.DataSource = avss.Data;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Export()
        {
            try
            {
                grdData.Export(true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            Export();
        }

    }
}
