using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmNHTSARecall : Form
    {
        private delegate void SearchCompleteDelegate(SearchEventArgs e, bool Success);
        private SearchCompleteDelegate NHTSASearchCompleteDelegate;

        private sql_nhtsa_recall sql = new sql_nhtsa_recall();

        #region Private Properties

        private ClsNhtsaRecall currentRecall
        {
            get
            {
                grdData.UpdateData();
                DataRow dr = grdData.GetDataRow();
                if (dr.IsNull()) return null;

                ClsNhtsaRecall r = ClsNhtsaRecall.GetUsingKey(dr["NHTSA_RECALL_ID"].ToLong());
                return r;
            }
        }

        private ClsRecallStatus currentRecallStatus
        {
            get
            {
                grdData.UpdateData();
                DataRow dr = grdData.GetDataRow();
                if (dr.IsNull()) return null;

                ClsRecallStatus s = ClsRecallStatus.GetUsingKey(dr["RECALL_STATUS_DSC"].ToString());
                return s;
            }
        }
 
        #endregion

        public frmNHTSARecall()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void ShowOpen(string Voyage_no, string Location_cd, string Recall_level)
        {
            this.Text = this.Text + " Voyage: " + Voyage_no;
            txtVoyage.Text = Voyage_no;
            cmbPol.Text = Location_cd;
            cmbRisk.Text = Recall_level;
            this.Show();
            Search();
        }

        public void ShowOpen()
        {
            this.Show();
            DisableSearch();

            EnableEmail();
        }

        #endregion

        private void SearchStatus(object o, SearchEventArgs e)
        {
            Invoke(NHTSASearchCompleteDelegate, new object[] { e, (e.Status == SearchStatusCd.Complete) });
        }


        #region Private Methods

        private void EnableSearch()
        {
            try
            {
                grdData.Enabled = false;
                pnlSearch.Enabled = false;

                //ss.Visible = true;
                tsProgress.Visible = tssCancel.Visible = true;
                tssStatusLabel.Visible = false;
                tsProgress.Enabled = true;
                tssCancel.Enabled = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DisableSearch()
        {
            try
            {
                grdData.Enabled = true;
                pnlSearch.Enabled = true;

                //ss.Visible = false;
                tsProgress.Visible = tssCancel.Visible = false;
                tssStatusLabel.Visible = true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void EnableEmail()
        {
            btnHtmlEmail.Enabled = (
                cmbPol.SelectedPortCD.IsNotNull() &&
                txtVoyage.Text.IsNotNull() &&
                cmbStatus.SelectedRecallStatusCD == "ACB");
        }

        private void Clear()
        {
            try
            {
                txtVoyage.Text = string.Empty;
                cmbPol.Clear();
                cmbVessel.Clear();
                cmbRisk.Text = string.Empty;
                cmbStatus.Text = string.Empty;
                dtSailFrom.Value = new DateTime(2017, 4, 20); // Default Base Date
                //dtSailFrom.Text = "04-20-2017";  
                dtSailTo.Text = string.Empty;
                txtVin.Text = string.Empty;

                EnableEmail();
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
                grdData.DataSource = null;
                EnableSearch();

                // Get Param
                mNhtsaParameters p = new mNhtsaParameters()
                {
                    Pol_Cd = cmbPol.SelectedPortCD,
                    Vessel_Cd = cmbVessel.SelectedVesselCD,
                    Voyage = txtVoyage.Text,
                    RiskCd = cmbRisk.SelectedRecallRiskCd,
                    StatusCd = cmbStatus.SelectedRecallStatusCD,
                    SailDateFrom = dtSailFrom.Value,
                    SailDateTo = dtSailTo.Value,
                    Vin = txtVin.Text
                };

                sql.Run(p);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                DisableSearch();
            }
        }

        private void Cancel()
        {
            try
            {
                sql.Abort();
                DisableSearch();

                EnableEmail();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                DisableSearch();
            }
        }

        private void ViewNotes()
        {
            try
            {
                DataRow dr = grdData.GetDataRow();
                if (dr.IsNull())
                {
                    grdNotes.DataSource = null;
                    return;
                }
                grdNotes.DataSource = ClsNhtsaRecall.GetHistory(dr[0].ToLong());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyVin()
        {
            try
            {
                DataRow dr = grdData.GetDataRow();
                if (dr.IsNotNull()) 
                {
                    Clipboard.SetText(dr["VIN"].ToString());
                    tssStatusLabel.Text = "Vin '" + dr["vin"].ToString() + " copied to the Clipboard ...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateStatus()
        {
            try
            {
                grdData.UpdateData();
                DataRow dr = grdData.GetDataRow();
                ClsNhtsaRecall r = currentRecall;
                ClsRecallStatus s = currentRecallStatus;
                string msg;

                if (dr.IsNotNull())
                {
                    if (r.UpdateStatus(out msg, s))
                    {
                        // True
                        tssStatusLabel.Text = string.Format("VIN: '{0}' has been updated to '{1}' ...",
                        dr["VIN"].ToString(), s.Recall_Status_Dsc);
                        ViewNotes();
                    }
                    else
                    {
                        // False
                        tssStatusLabel.Text = "Update Failed";
                        MessageBox.Show(msg);
                    }
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ViewEmailReport()
        {
            try
            {
                List<DataRow> Source = grdData.GetDataRowList();

                List<DataRow> lstDR = Source
                    .Where(x => x["recall_status_cd"].ToString() == "ACB")
                    .ToList<DataRow>();

                #region HTML

                string html = @"

<html>
<head>
    <title>Battery Disconnects</title>
    <style>

        html, body {
            font-family: Arial;
            font-size: 10pt;
            padding: 0px;
            margin: 0px;
            border: 0px;
        }

        table{
            width: 90%;
            padding: 0px;
            margin: 10px;
            border: 1px solid black;
            
            font-family: Arial;
            font-size: 9pt;
            
            text-align: center;
            border-collapse: collapse;
        }

        th {
            border: 3px solid black;
            background-color: lightgray;
        }

        td{
            border: 1px solid black;
        }

        p{
            margin: 10px;
        }

    </style>

</head>
<body>

    <p>To [POL] Terminal Operations:</p>

    <p>Please be advised there are [NUM_OF_POVS] POVs received to load on the [VOYAGE]-[VESSEL] in [POL] which have active recalls that may be hazardous to the vessel in normal shipping configurations.</p>

    <p>As such, it is mandatory that the batteries for these units be disconnected after loading on board the vessel. POD will then reconnect the batteries for discharge.</p>

    <br />
    <table>
        <tr>
            <th>Voyage</th>
            <th>Vessel</th>
            <th>Booking</th>
            <th>POL</th>
            <th>POD</th>
            <th>VIN</th>
            <th>Vehicle</th>
        </tr>
        <tr>
            [TD]
        </tr>
    </table>

</body>

</html>
                ";

                #endregion

                string td = string.Empty;

                html = html.Replace("[POL]", lstDR[0]["location_dsc"].ToString().ToUpper());
                html = html.Replace("[NUM_OF_POVS]", lstDR.Count.ToString());
                html = html.Replace("[VOYAGE]", lstDR[0]["VOYAGE"].ToString().ToUpper());
                html = html.Replace("[VESSEL]", lstDR[0]["VESSEL_NM"].ToString().ToUpper());

                foreach (DataRow d in lstDR)
                {
                    td = td + string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                        d["VOYAGE"].ToString().ToUpper(),
                        d["VESSEL_CD"].ToString().ToUpper(),
                        d["BOOKING_NO"].ToString(),
                        d["POL"].ToString(),
                        d["POD"].ToString(),
                        d["VIN"].ToString(),
                        d["car_dsc"].ToString().ToUpper());
                }

                html = html.Replace("[TD]", td);

                frmHtmlReport r = new frmHtmlReport();
                r.ShowHtml("Battery Disconnect", html);

            }
            catch (Exception ex) 
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void grdData_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                DataRow dr = grdData.GetDataRow();
                if (dr.IsNotNull())
                {

                    ClsNhtsaRecall r = currentRecall;
                    frmNHTSARecallEdit re = new frmNHTSARecallEdit();

                    if (re.ShowOpen(r))
                    {

                        dr["RECALL_STATUS_DSC"] = r.Recall_Status.Recall_Status_Dsc;

                        DataRow drh = ClsNhtsaRecall.GetHistoryLastStatusUpdate((long)r.Nhtsa_Recall_ID);
                        dr["LAST_STATUS_UPDATE"] = drh["CREATE_DT"];

                        ViewNotes();

                        tssStatusLabel.Text = string.Format("VIN: '{0}' has been saved ...",dr["VIN"].ToString());

                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tssCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void SearchComplete(SearchEventArgs e, bool Success)
        {
            grdData.DropDowns["ddStatus"].DataSource = ClsRecallStatus.GetAll();
            grdData.DataSource = e.Data;
            tssStatusLabel.Text = e.Message_RowsAffectedElapsedTime;
            DisableSearch();

            EnableEmail();
        }

        private void frmNHTSARecall_Load(object sender, EventArgs e)
        {
            NHTSASearchCompleteDelegate = new SearchCompleteDelegate(SearchComplete);

            sql.SearchStatus += new sql_base.SearchEventHandler(SearchStatus);
 
        }

        private void frmNHTSARecall_FormClosing(object sender, FormClosingEventArgs e)
        {
            sql.SearchStatus -= new sql_base.SearchEventHandler(SearchStatus);
        }        

        private void grdData_SelectionChanged(object sender, EventArgs e)
        {
            ViewNotes();
        }       
 
        private void grdData_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            if (e.Column.Key.ToUpper() == "VIN") 
                CopyVin();
        }       

        private void grdData_DropDownHide(object sender, Janus.Windows.GridEX.DropDownHideEventArgs e)
        {
            if (e.ValueSelected) UpdateStatus();
        }

        private void btnHtmlEmail_Click(object sender, EventArgs e)
        {
            ViewEmailReport();
        }



        #endregion

        

    }
}
