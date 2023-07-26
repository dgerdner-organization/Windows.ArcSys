using System;
using System.IO;
using System.Data;
using CS2010.Common;
using CS2010.CommonReports;
using CS2010.ArcSys.Business;
using CS2010.ACMS.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class ClsLinkHandlerARC : CS2010.Common.ClsLinkHandler
	{
		/// <summary>
		/// Typical usage from GridEx:
		/// Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key);
		/// </summary>
		/// <param name="g">Theoretically any kind of object.  Currently only handles GridExRow</param>
		/// <param name="sKey">Column Name</param>
		public override void HandleLink(object g, string sKey)
		{
			try
			{
				GridEXRow grow = g as GridEXRow;
				if (g == null) return;
				long? ID;
				switch (sKey.ToLower())
				{
					case "serial_no":
						ID = ClsConvert.ToInt64Nullable(grow.Cells["cargo_id"].Value);
						ClsCargo cargo = (ID != null) ? ClsCargo.GetUsingKey(ID.Value) : null;

						if (cargo != null)
						{
							Program.MainWindow.ViewChangeHistory(cargo);
						}
						break;

					case "estimate_id":
					case "estimate_no":
						ViewEstimate(grow);
						break;

					case "contract_mod_id":
					case "mod_no_attachment_nm":
					case "mod_id_no_attachment_nm":
						ViewContractMod(grow);
						break;
					case "booking_line_id":
					case "booking_id":
					case "booking_no":
					case "carrier booking":
					case "fieldvalue":
						ViewBookingLINE(grow);
						break;
					case "partner_request_cd":
					case "pcfn":
					case "request_cd":
						ViewBookingRequest(grow);
						break;
					case "trans_ctl_no":
						ViewBookingRequest(grow);
						break;
					case "voyage_no":
					case "voyage_cd":
						ViewVoyage(grow);
						break;
					default:
						Program.MainWindow.ViewChangeHistory("%");
						break;
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Program.ShowError(ex);
			}
		}

		public void HandleLink(ClsBookingRequest br)
		{
			ViewWindowManager.View(br);
		}

		private void ViewVoyage(GridEXRow grow)
		{
			string sVoyageNo = "";
			try
			{
				sVoyageNo = grow.Cells["voyage_no"].Value.ToString();
			}
			catch
			{
				sVoyageNo = ClsConvert.ToString(grow.Cells["voyage_cd"].Value);
			}
			if (string.IsNullOrEmpty(sVoyageNo))
			{
				Program.Show("No voyage was sent to the View Voyage window");
				return;
			}
			using (frmSearchVoyages frm = new frmSearchVoyages(sVoyageNo))
			{
				frm.ShowDialog();
			}
		}

		private void ViewBookingLINE(GridEXRow grow)
		{
			try
			{
				long booking_line_id = 0;
				string booking_no = null;
				ClsBookingLine bl = null;
				if (grow.Table.Columns.Contains("carrier booking"))
					booking_no = ClsConvert.ToString(grow.Cells["carrier booking"].Value);
				if (grow.Table.Columns.Contains("booking_id"))
					booking_no = ClsConvert.ToString(grow.Cells["booking_id"].Value);

				if (grow.Table.Columns.Contains("booking_no"))
					booking_no = ClsConvert.ToString(grow.Cells["booking_no"].Value);
				if (grow.Table.Columns.Contains("FieldValue"))
					booking_no = ClsConvert.ToString(grow.Cells["FieldValue"].Value);

				if (grow.Table.Columns.Contains("booking_line_id"))
					booking_line_id = ClsConvert.ToInt64 (grow.Cells["booking_line_id"].Value);
				if (booking_line_id == 0)
					bl = ClsBookingLine.GetByBookingNo(booking_no);
				else
					bl = ClsBookingLine.GetUsingKey(booking_line_id);
				ViewWindowManager.View(bl);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewEstimate(GridEXRow grow)
		{
			try
			{
				long? estimate_id = null;
				string estimate_no = null;
				if (grow.Table.Columns.Contains("estimate_id"))
					estimate_id = ClsConvert.ToInt64Nullable(grow.Cells["estimate_id"].Value);
				if (estimate_id == null)
				{
					if (grow.Table.Columns.Contains("estimate_no"))
						estimate_no = ClsConvert.ToString(grow.Cells["estimate_no"].Value);
				}

				if( estimate_id == null && string.IsNullOrEmpty(estimate_no) )
				{	// Try to look in the data row since we could not find a value in the grid row
					DataRowView drv = grow.DataRow as DataRowView;
					if (drv == null) return;

					if (drv.Row.Table.Columns.Contains("estimate_id"))
						estimate_id = ClsConvert.ToInt64Nullable(drv["estimate_id"]);
					if (estimate_id == null)
					{
						if (drv.Row.Table.Columns.Contains("estimate_no"))
							estimate_no = ClsConvert.ToString(drv["estimate_no"]);
					}
				}

				ClsEstimate est = (estimate_id != null)
					? ClsEstimate.GetUsingKey(estimate_id.Value) : null;
				if (est == null && !string.IsNullOrEmpty(estimate_no))
					est = ClsEstimate.GetUsingEstimateNo(estimate_no);
				if (est == null) return;

				ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewContractMod(GridEXRow grow)
		{
			try
			{
				string mod_no = null;
				long? contract_mod_id = null;
				if (grow.Table.Columns.Contains("contract_mod_id"))
					contract_mod_id = ClsConvert.ToInt64Nullable(grow.Cells["contract_mod_id"].Value);
				if (contract_mod_id == null)
				{
					if (grow.Table.Columns.Contains("mod_no"))
						mod_no = ClsConvert.ToString(grow.Cells["mod_no"].Value);
				}

				if( contract_mod_id == null && string.IsNullOrEmpty(mod_no) )
				{	// Try to look in the data row since we could not find a value in the grid row
					DataRowView drv = grow.DataRow as DataRowView;
					if (drv == null) return;

					if (drv.Row.Table.Columns.Contains("contract_mod_id"))
						contract_mod_id = ClsConvert.ToInt64Nullable(drv["contract_mod_id"]);
					if (contract_mod_id == null)
					{
						if (drv.Row.Table.Columns.Contains("mod_no"))
							mod_no = ClsConvert.ToString(drv["mod_no"]);
					}
				}

				ClsContractMod cmod = (contract_mod_id != null)
					? ClsContractMod.GetUsingKey(contract_mod_id.Value) : null;
				if (cmod == null && !string.IsNullOrEmpty(mod_no))
					cmod = ClsContractMod.GetUsingModNo(mod_no);
				if (cmod == null) return;

				if (string.IsNullOrEmpty(cmod.Attachment_Nm) || cmod.Attachment == null)
				{
					Program.Show("Contract Mod {0} does not have an attachment", cmod.Mod_No);
					return;
				}

				string file = Path.Combine(Path.GetTempPath(), cmod.Attachment_Nm);
				if (ClsConvert.BlobToFile(file, cmod.Attachment) == false)
				{
					Program.ShowError("Error viewing attachment");
					return;
				}

				ClsConvert.ViewFile(file);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewBookingRequest(GridEXRow grow)
		{
			string sPCFN = null;
			ClsBookingRequest br = null;
			if (grow.Table.Columns.Contains("partner_request_cd"))
				sPCFN = ClsConvert.ToString(grow.Cells["partner_request_cd"].Value);
			if (grow.Table.Columns.Contains("request_cd"))
				sPCFN = ClsConvert.ToString(grow.Cells["request_cd"].Value);
			if (grow.Table.Columns.Contains("pcfn"))
				sPCFN = ClsConvert.ToString(grow.Cells["pcfn"].Value);
			if (grow.Table.Columns.Contains("trans_ctl_no"))
			{
				Int64? iISA = ClsConvert.ToInt64Nullable(grow.Cells["trans_ctl_no"].Value);
				Int32? iSeq = ClsConvert.ToInt32Nullable(grow.Cells["trans_seq_no"].Value);
				ClsBookingRequest.GetUsingKey(iISA.GetValueOrDefault(), iSeq.GetValueOrDefault());
				if (br == null)
					return;
				ViewWindowManager.View(br);
			}
			br = ClsBookingRequest.GetByRequestCd(sPCFN);
			if (br == null)
				return;
			ViewWindowManager.View(br);
		}
	}
}
