using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.Common;
using ASL.ARC.EDITools;
using CS2010.ACMS.Business;
using STENA;
using System.Threading;

namespace CS2010.ArcSys.Win
{
	public partial class frmStenaUnbookedList : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmStenaUnbookedList()
		{
			InitializeComponent();
					
		}

		#region FIELDS AND PROPERTIES
		protected string sStenaMessage;
		protected DataTable dtUnbooked;
		protected DateTime StenaSailingDt
		{
			get
			{
				object obj = cmbSailings.Value;
				DateTime? dt = ClsConvert.ToDateTimeNullable(obj);
				return dt.GetValueOrDefault();
			}
		}
		protected ClsVStenaUnbooked CurrentRow
		{
			get
			{
				DataRow drow = grdMain.GetDataRow();
				ClsVStenaUnbooked obj = new ClsVStenaUnbooked(drow);
				return obj;
			}
		}
		protected ClsBookingUnit CurrentBookingUnit
		{
			get
			{
				return ClsBookingUnit.GetByTCN(CurrentRow.Booking_No, CurrentRow.Serial_No);
			}
		}
		#endregion

		#region METHODS
		public void ShowWindow()
		{

			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
		}

		protected void GetStenaSailings()
		{
			DataTable dt = ClsStenaRouteSailing.GetSailings(CurrentBookingUnit.StenaRoutecd, -3, 10);
			cmbSailings.DataSource = dt;
		}

		private void BindDetail()
		{
			try
			{
				//
				//  Bind the text objects 
				txtCargoRoute.Text = CurrentRow.Route_Cd;
				txtCargoTrailerNo.Text = CurrentRow.Trailer_No;
				txtStenaDate.Text = CurrentRow.Depart_Dt.GetValueOrDefault().ToString("d-MMM-yyyy HH:mm");
				txtVehicleType.Text = CurrentRow.Vehicle_Type_Cd;
				btnBookgStena.Enabled = true;

				// If this booking has a stena ID (ie: it has been successfully booked)
				// then disable the "Book" button; because you don't want to do it again.
				if (CurrentBookingUnit != null)
				{
					if (CurrentBookingUnit.StenaBooking != null)
					{
						txtStenaID.Text = CurrentBookingUnit.StenaBooking.Stena_ID.ToString();
						if (!string.IsNullOrEmpty(txtStenaID.Text))
							btnBookgStena.Enabled = false;
					}
					if (CurrentBookingUnit != null)
						grdStenaAudit.DataSource = CurrentBookingUnit.StenaAuditTrail;
					if (CurrentBookingUnit.BookingRequest != null)
						txtDeliveryDsc.Text = CurrentBookingUnit.BookingRequest.Delivery_Dsc;
				}

				// Reset the sailings for this booking
				GetStenaSailings();
				cbxStenaSailing.Checked = false;
				cmbSailings.SelectedIndex = -1;

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditStenaInfo(bool bEdit)
		{
			txtStenaID.ReadOnly = !bEdit;
			txtCargoTrailerNo.ReadOnly = !bEdit;
			btnSave.Enabled = bEdit;
		}

		private void SaveChanges()
		{
			try
			{
			ClsStenaBooking sb = CurrentBookingUnit.StenaBooking;
			if (sb == null)
			{
				//Program.Show("The changes could not be saved.  Contact IT Software Development support.");
				sb = new ClsStenaBooking();
				sb.Booking_No = CurrentBookingUnit.Booking_ID;
				sb.Serial_No = CurrentBookingUnit.Tcn;
				sb.Sailing_Dt = CurrentBookingUnit.DepartDt;
				sb.Insert();
			}
			if (string.IsNullOrEmpty(txtStenaID.Text))
				sb.Stena_ID = null;
			else
				sb.Stena_ID = ClsConvert.ToInt32Nullable(txtStenaID.Text);

			sb.Trailer_No = txtCargoTrailerNo.Text;
			sb.Update();
			btnSave.Enabled = false;
			EditStenaInfo(false);
			Program.Show("Stena data was updated in ACMS");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}

		#region Asynch Methods
		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdMain)
				{
					//infToolbar.Enabled = btnSearch.Enabled = btnClear.Enabled =
					//    grdCargo.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdMain.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
					grdMain.DataSource = dtUnbooked;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}
		private TimeSpan ElapsedTime;
		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void PerformSearch()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				DataTable dt = ClsVStenaUnbooked.GetAll();
				TimeSpan time = DateTime.Now - start;
				lock (grdMain)
				{
					dtUnbooked = dt;
					ElapsedTime = time;
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}
		#endregion

		#region Asynch Stena Calls

		private void PerformStenaCall()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartStenaCall, UpdateSCMethod, ResetCounter);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void StartStenaCall()
		{
			try
			{
				DateTime start = DateTime.Now;

				DateTime dt = CurrentRow.Depart_Dt.GetValueOrDefault();
				if (cbxStenaSailing.Checked)
					dt = StenaSailingDt;
				sStenaMessage = ClsSTENABookings.BookStenaSingle(CurrentBookingUnit, dt);
				if (string.IsNullOrEmpty(sStenaMessage))
				{
					sStenaMessage = "Success";
					DataRow drow = grdMain.GetDataRow();
					drow["error_msg"] = "";
				}

				TimeSpan time = DateTime.Now - start;
				lock (grdStenaAudit)
				{
					ElapsedTime = time;
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}
		private void UpdateSCMethod()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
					grdMain.Refresh();
					Program.Show(sStenaMessage);
					BindDetail();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
			
		}

		#endregion

		#region Asynch Extract Trailer

		private void PerformTrailersCall()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartTrailersCall, UpdateTrailerMethod, ResetCounter);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void StartTrailersCall()
		{
			try
			{
				DateTime start = DateTime.Now;
				STENA.ClsSTENABookings.UpdateTrailerNumbers();

				TimeSpan time = DateTime.Now - start;
				lock (grdMain)
				{
					ElapsedTime = time;
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}
		private void UpdateTrailerMethod()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
					PerformSearch();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}

		}

		#endregion

		#endregion

		#region EVENTS
		private void grdMain_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			string s = e.Column.DataMember;
			CS2010.ACMS.Business.ClsBooking bk = CS2010.ACMS.Business.ClsBooking.GetUsingKey(CurrentRow.Partner_Cd, CurrentRow.Partner_Request_Cd);
			if (bk == null)
				return;
			if (bk.BookingRequest == null)
				return;
			ViewWindowManager.View(bk.BookingRequest);
		}
		
		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			BindDetail();
		}

		private void cbxStenaSailing_CheckedChanged(object sender, EventArgs e)
		{
			cmbSailings.Enabled = cbxStenaSailing.Checked;
		}

		private void btnBookgStena_Click(object sender, EventArgs e)
		{
			PerformStenaCall();
			//DateTime dt = CurrentRow.Depart_Dt.GetValueOrDefault();
			//if (cbxStenaSailing.Checked)
			//    dt = StenaSailingDt;
			//string sMsg = ClsSTENABookings.BookStenaSingle(CurrentBookingUnit, dt);
			//if (string.IsNullOrEmpty(sMsg))
			//{
			//    Program.Show("Success");
			//    DataRow drow = grdMain.GetDataRow();
			//    drow["error_msg"] = "";
			//    grdMain.Refresh();				
			//}
			//else
			//    Program.Show(sMsg);
			//BindDetail();
		}

		private void btnGetTrailers_Click(object sender, EventArgs e)
		{
			ClsBookingRequest br = CurrentBookingUnit.BookingRequest;
			if (br == null)
			    return;
			br.Delivery_Dsc = txtDeliveryDsc.Text;
			br.Update();
			PerformTrailersCall();

			//STENA.ClsSTENABookings.UpdateTrailerNumbers();
			//PerformSearch();				
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditStenaInfo(true);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveChanges();
		}




	}
		#endregion

}
