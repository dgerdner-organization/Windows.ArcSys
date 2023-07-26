using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using System.Configuration;
using CS2010.Common;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
	public partial class frmDimsSynch: frmChildBase
	{
		public frmDimsSynch()
		{
			InitializeComponent();
			AsynchConnectionKey = "ACMS";
		}
		protected DataTable dtPartners;
		protected DataTable dtMismatchDims;
		protected int iDays;

		#region Methods
		public void ShowForm()
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}

		public void InitForm()
		{
			Search();
		}

		protected void Search()
		{
			DateTime dtStart = DateTime.Now;

			dtMismatchDims = ClsACMSQueries.GetMismatchDims();
			grdMismatchDims.DataSource = dtMismatchDims;
			if (dtMismatchDims.Rows.Count > 0)
				grdMismatchDims.Row = 1;

			//if ((DateTime.Now - dtStart).Seconds > 3) 
			//    Program.Show("Done");
		}

		private void grdMismatchDims_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdMismatchDims.CurrentRow, e.Column.Key);
		}

		private void UpdateSelected()
		{
			DataRow[] lRows = grdMismatchDims.GetCheckedDataRows();
			if (lRows.Length < 1)
			{
				Program.Show("You must selected at least one row");
				return;
			}
			DialogResult dr = MessageBox.Show("This will update ACMS for all selected rows.", "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
			{
				Program.Show("Action cancelled by user.");
				return;
			}
			foreach (DataRow drow in lRows)
			{
				UpdateDataRow(drow);
			}
			grdMismatchDims.DataSource = dtMismatchDims;
			Program.Show("Complete");
		}

		private void RemoveSelected()
		{
			DataRow[] lRows = grdMismatchDims.GetCheckedDataRows();
			if (lRows.Length < 1)
			{
				Program.Show("You must selected at least one row");
				return;
			}
			DialogResult dr = MessageBox.Show("This will remove the selected cargo from the Dashboard.  Are you sure you want to do this?", "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
			{
				Program.Show("Action cancelled by user.");
				return;
			}
			foreach (DataRow drow in lRows)
			{
				RemoveDatarow(drow);
			}
			grdMismatchDims.DataSource = dtMismatchDims;
			Program.Show("Complete");
		}

		private void UpdateDataRow(DataRow drow)
		{
			try
			{
				string PartnerCd = drow["partner_cd"].ToString();
				string PCFN = drow["partner_request_cd"].ToString();
				string ItemNo = drow["item_no"].ToString();
				double dLength = drow["line_length"].ToDouble();
				double dHeight = drow["line_height"].ToDouble();
				double dWidth = drow["line_width"].ToDouble();
				dLength = Math.Round(dLength, 0);
				dHeight = Math.Round(dHeight, 0);
				dWidth = Math.Round(dWidth, 0);

				double dItemNo = ClsConvert.ToDouble(ItemNo);
				ClsBookingUnit bu = ClsBookingUnit.GetUsingKey("MTMCIBSD", PCFN, dItemNo);
				if (bu == null)
				{
					Program.Show("Could not find ACMS data.");
					return;
				}
				bu.Length_Nbr = dLength;
				bu.Width_Nbr = dWidth;
				bu.Height_Nbr = dHeight;

				// Remove the row from the Grid
				dtMismatchDims.Rows.Remove(drow);

				// Update
				bu.SaveUnit();

				AddCorrespondence(PartnerCd, PCFN);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Program.ShowError(ex);
			}
			
		}

		private void RemoveDatarow(DataRow drow)
		{
			string sBookingNo = drow["booking_no"].ToString();
			ArcSys.Business.ClsBookingDimRemove x = ArcSys.Business.ClsBookingDimRemove.GetUsingKey(sBookingNo);
			if (x == null)
			{
				ArcSys.Business.ClsBookingDimRemove dr = new ArcSys.Business.ClsBookingDimRemove();
				dr.Booking_No = sBookingNo;
				dr.Insert();
			}
			dtMismatchDims.Rows.Remove(drow);
		}

		private void AddCorrespondence(string PartnerCd, string PCFN)
		{
			try
			{
				//if (ClsBookingCorrespondence.GetForRequest(PartnerCd, PCFN) != null)
				//    return;

				ClsBookingCorrespondence bc = new ClsBookingCorrespondence();
				bc.Partner_Cd = PartnerCd;
				bc.Partner_Request_Cd = PCFN;
				bc.Corr_Cd = "DIMS";
				bc.Corr_Text = "Dimensions updated to match LINE";
				bc.Corr_Dt = DateTime.Today;
				if (bc.ValidateInsert())
				{
					bc.Corr_ID = ClsBookingCorrespondence.NextID();
					bc.Insert();
				}
			}
			catch (Exception ex)
			{
				Program.Show("Error adding to Correspondence.");
			}
		}

		#endregion

		#region Events
		private void grdMismatchDims_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			string sMsg = string.Format(@"Pressing this button assumes the data in LINE is correct.  It will update the ACMS dimensions with the data in LINE.  Is this what you want to do? ");
			try
			{
				DataRow drow = grdMismatchDims.GetDataRow();
				UpdateDataRow(drow);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateSelected();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			RemoveSelected();
		}
		#endregion









	}
}
