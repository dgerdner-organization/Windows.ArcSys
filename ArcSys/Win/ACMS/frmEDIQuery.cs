using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;
using CS2010.ArcSys.Win;
using CS2010.CommonSecurity;
using System.Configuration;
using CS2010.ACMS.Business;


namespace ASL.ARC.EDITools
{
	public partial class frmEDIQuery : frmChildBase
	{
		#region Fields/Properties
		public DataTable dtReport;
		public DataTable dtSummary;
		public DataTable dtDetail;
		private string parmPCFN;

		private string POLCd
		{
			get
			{
				int i = cmbPOL.SelectedIndex;
				if( i < 0 )
					return "%";
				DataTable dt = cmbPOL.Table;
				string s = dt.Rows[i]["location_cd"].ToString();
				return s;
			}
		}
		private string PODCd
		{
			get
			{
				int i = cmbPOD.SelectedIndex;
				if( i < 0 )
					return "%";
				DataTable dt = cmbPOD.Table;

				string s = dt.Rows[i]["location_cd"].ToString();
				return s;
			}
		}

		private ClsBookingRequest _CurrentRequest;
		public ClsBookingRequest CurrentRequest
		{
			get
			{
				DataRow drow = grdList.GetDataRow();
				string sPCFN = drow["partner_request_cd"].ToString();
				_CurrentRequest = ClsBookingRequest.GetByRequestCd(sPCFN);
				return _CurrentRequest;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup


		public frmEDIQuery(string sPCFN)
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;
			ClsSecurityMaster.SetSecurity(this);
			if (!string.IsNullOrEmpty(sPCFN))
			{
				txtPCFN.Text = sPCFN;
				parmPCFN = sPCFN;
			}
		}
		private void Init()
		{
			DataTable dtPOL = ClsAcmsSQL.SelectLocations();
			cmbPOL.DataSource = dtPOL;
			DataTable dtPOD = ClsAcmsSQL.SelectLocations();
			cmbPOD.DataSource = dtPOD;

			dateActivityRange.FromDate =  new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			dateActivityRange.ToDate = dateActivityRange.FromDate.Value.AddMonths(1).AddDays(-1);
			ClearParameters();
			if (!string.IsNullOrEmpty(parmPCFN))
				Search();
		}

		private void Search()
		{
			if (!dateActivityRange.CheckBoxChecked)
				dateActivityRange.Clear();

			string sVoyage = txtVoyage.Text + "%";
			string sBooking = txtBooking.Text + "%";
			string sTCN = txtSerialNo.Text + "%";
			string sCode = txtActivityCd.Text + "%";
			string sPCFN = txtPCFN.Text + "%";
			//string sVoyDoc = txtVoyDoc.Text + "%";
			string sVoyDoc = "%";
			string sPOD = PODCd;
			string sPOL = POLCd;
			string sISA = txtISAnbr.Text;
			dtReport = ClsAcmsSQL.SearchITVHistory(sVoyage, sBooking, sTCN, sCode, cbxUnsent.Checked, sPCFN, sVoyDoc,
						sPOL, sPOD, sISA, cbxDRAP.Checked, cbxLate.Checked, dateActivityRange.ValueRange);

			grdList.DataSource = dtReport;

			// Get Summary
			if (!string.IsNullOrEmpty(txtVoyage.Text) ||
				!string.IsNullOrEmpty(txtSerialNo.Text))
			{
				dtSummary = ClsArcSQL.GetITVSummaryReport(txtVoyage.Text + "%", "%", txtSerialNo.Text);
				grdSumm.DataSource = dtSummary;
			}

			btnSave.Enabled = false;
			txtNotes.Text = "";
		}

		private void ClearParameters()
		{
			WindowHelper.ClearAllControls(this);
			txtVoyage.Text = "";
			txtBooking.Text = "";
			txtSerialNo.Text = "";
			txtActivityCd.Text = "";
			txtPCFN.Text = "";
			txtISAnbr.Text = "";
			cbxDRAP.Checked = cbxUnsent.Checked = false;
			cmbPOL.SelectedIndex = -1;
			cmbPOD.SelectedIndex = -1;
			if (!string.IsNullOrEmpty(parmPCFN))
			{
				txtPCFN.Text = parmPCFN;
				dateActivityRange.CheckBoxChecked = false;
			}
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Main Methods
		private void Savechanges()
		{
			int i = 0;
			try
			{
				foreach (GridEXRow grow in grdList.GetRows())
				{
					DataRowView drv = (DataRowView)grow.DataRow;
					DataRow drow = drv.Row;
					string sConfirm = drow["confirm_cd"].ToString();
					string sNotes = drow["notes"].ToString();
					string sEditFlg = grow.Cells["edit_flg"].Value.ToString();
					if (sEditFlg != "Y")
						continue;
					i++;
					int iActivityID = ClsConvert.ToInt32(drow["activity_id"].ToString());
					string sLocation = drow["activity_location_cd"].ToString();

					ClsAcmsSQL.UpdateITV(iActivityID, sLocation, sConfirm, sNotes);
				}
				if (i == 0)
					Program.Show("Nothing to update");
				else
					Program.Show("ITV has been updated");
				txtNotes.Text = "";
				Search();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private void FlagCellEdit()
		{
			GridEXRow grow = grdList.CurrentRow;
			btnSave.Enabled = true;
			grow.Cells["edit_flg"].Value = "Y";
		}

		private void UpdateAllNotes(string sNotes)
		{
			foreach (GridEXRow grow in grdList.GetRows())
			{
				grow.BeginEdit();
				grow.Cells["notes"].Value = sNotes;
				grow.Cells["edit_flg"].Value = "Y";
				btnSave.Enabled = true;
				grow.EndEdit();
			}
			Program.Show("The notes will not take affect until you 'Save'");
		}

		private void OpenFile()
		{
			try
			{
				DataRow drow = grdList.GetDataRow();
				string sFile = drow["table_dsc"].ToString().Trim();
				string sType = drow["edi_type"].ToString().ToUpper().Trim();
				//string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim();
				ClsOpenEDIFile.OpenFile(sFile, "MTMCIBSD", sType);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DeleteITV()
		{
			DialogResult dr = MessageBox.Show("This will delete the ITV activity and cannot be undone.  Are you sure you want to do this?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (dr != DialogResult.OK)
			{
				Program.Show("Action cancelled by user");
				return;
			}
			try
			{
				DataRow drow = grdList.GetDataRow();
				string sID = drow["activity_id"].ToString();
				long lID = ClsConvert.ToInt64(sID);
				ClsBookingItv itv = ClsBookingItv.GetUsingKey(lID);
				if (itv == null)
				{
					Program.Show("Delete Failed.  ITV Activity could not be found.");
					return;
				}
				itv.DeleteITV();
				Program.Show("ITV has been deleted");
				Search();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			
		}
        private void ResendITV()
        {
            DialogResult dr = MessageBox.Show("This will make a new copy of the ITV activity re-send it.  Are you sure you want to do this?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr != DialogResult.OK)
            {
                Program.Show("Action cancelled by user");
                return;
            }
            try
            {
                DataRow drow = grdList.GetDataRow();
                string sID = drow["activity_id"].ToString();
                long lID = ClsConvert.ToInt64(sID);
                ClsBookingItv itv = ClsBookingItv.GetUsingKey(lID);
                if (itv == null)
                {
                    Program.Show("Resend Failed.  ITV Activity could not be found.");
                    return;
                }
                ClsBookingItv copyITV = new ClsBookingItv(itv);
                copyITV.Activity_ID = itv.NextSeq();
                copyITV.Confirm_Cd = "N";
                copyITV.Trans_Ctl_No = null;
                copyITV.Create_Dt = copyITV.Modify_Dt = null;
                copyITV.Activity_User = copyITV.Modify_User = Program.CurrentUser.User_Nm;
                copyITV.Insert();

                Program.Show("ITV has been copied for re-send");
                Search();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }

        }
		#endregion

		#region Event Handlers
		private void tbbSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void tbbClear_Click(object sender, EventArgs e)
		{
			ClearParameters();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

			Savechanges();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void grdResults_TextChanged(object sender, EventArgs e)
		{
			FlagCellEdit();
		}

		private void grdResults_CellUpdated(object sender, ColumnActionEventArgs e)
		{
			FlagCellEdit();
		}
		private void grdResults_EditingCell(object sender, EditingCellEventArgs e)
		{
			FlagCellEdit();
		}
		private void frmEDIQuery_Load(object sender, EventArgs e)
		{
			Init();
		}
		private void btnApply_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("This will apply these notes to all ITV in this window", "Confirm", MessageBoxButtons.OKCancel);
			if (dr != DialogResult.OK)
				return;
			UpdateAllNotes(txtNotes.Text);
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("This will remove notes from all ITV in this window", "Confirm", MessageBoxButtons.OKCancel);
			if (dr != DialogResult.OK)
				return;
			UpdateAllNotes("");
		}

		private void grdSumm_SelectionChanged(object sender, EventArgs e)
		{
			GridEXRow gr = grdSumm.GetRow();
			string sPCFN = gr.Cells["partner_request_cd"].Text;
			string sTCN = gr.Cells["tcn"].Text;
			DateRange udr = new DateRange();
			dtDetail = ClsAcmsSQL.SearchITVHistory
				("%", "%", sTCN, "%", false, sPCFN, "%", "%", "%", "");

			dtDetail = ClsAcmsSQL.SearchITVHistory("%", "%", sTCN, "%", false, sPCFN, "%",
				"%", "%", "%", false, false, udr);

			grdDetail.DataSource = dtDetail;
		}

		private void grdList_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToUpper() == "TABLE_DSC")
			{
				OpenFile();
			}
			if (e.Column.DataMember.ToUpper() == "PARTNER_REQUEST_CD")
			{
				ViewWindowManager.View(CurrentRequest);
			}
		}
		private void grdList_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

		private void grdList_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
            switch (e.Column.Key.ToLower())
            {
                case "delete_btn":
		        	DeleteITV();
                    break;
                case "resent_btn":
                    ResendITV();
                    break;

            }
		}
		#endregion		// #region Event Handlers




	
	}
}

	