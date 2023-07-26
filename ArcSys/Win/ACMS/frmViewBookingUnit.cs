using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using ASL.ARC.EDISQLTools;
using STENA;

namespace CS2010.ArcSys.Win
{
	public partial class frmViewBookingUnit : frmChildBase,  IViewWindow
	{
		ClsBookingUnit theUnit;
		ClsBookingUnit oldUnit;
        Boolean bGoodRow = true;

		public frmViewBookingUnit(bool showModal) : base()
		{
			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
			InitializeComponent();
		}

		private void InitWindow()
		{
			try
			{
				WindowHelper.InitAllGrids(this);
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetTitle(string AdditionalText)
		{
			this.Text = "Booking Request " + AdditionalText;
		}
		
		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return theUnit; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			DisplayUnit(bizObject as ClsBookingUnit);
		}

		public void UpdateDisplay()
		{
		}

		#endregion		// #region IViewWindow Interface Implementation

		#region Display the Object
		public void DisplayUnit(ClsBookingUnit aUnit)
        {

            theUnit = aUnit;
            oldUnit = new ClsBookingUnit();
            oldUnit.CopyFrom(aUnit);
            this.Text = aUnit.Tcn;
            bGoodRow = false;
            if (!theUnit.Poe_Location_Cd.IsNullOrWhiteSpace())
            {
                bGoodRow = true;
                BindCargoDetail();
            }
            else
            {
                EmptyRowLogic();
                if (bGoodRow)
                    BindCargoDetail();
            }

            if (MdiParent == null)
            {
                if (bGoodRow)
                    ShowDialog();
            }
            else
            {
                if (bGoodRow)
                    Show();
            }

        }
		private void BindCargoDetail()
		{

			//DataTable dtVoyageVessel = ClsDropDowns.CurrentVoyages;
			DataTable dtVoyageVessel = ClsDropDowns.CurrentVoyagesImmediate;
			if (theUnit.BookingRequest.Request_Dt < DateTime.Today.AddDays(-20))
			{
				dtVoyageVessel = ClsDropDowns.AllVoyages;
                btnOlderVoyages.Visible = true;
			}
			else
				if (theUnit.BookingRequest.Sail_Dt < DateTime.Today.AddDays(-20))
				{
					dtVoyageVessel = ClsDropDowns.AllVoyages;
                    btnOlderVoyages.Visible = true;
				}

			cmbVoyageVessel.DataSource = dtVoyageVessel;
			cmbCommodity.DataSource = ClsDropDowns.CommodityDescriptions;
			cmbRevenue.DataSource = ClsDropDowns.RevenueCodes;
			cmbCargoCode.DataSource = ClsDropDowns.CargoCodes;
			SetPortDropDowns();

			lblSeqNo.Text = theUnit.Item_No.ToString();
			BindHelper.Bind(txtCargoBooking, theUnit, "Booking_ID");
			BindHelper.Bind(txtCargoTCN, theUnit, "Tcn");
			BindHelper.Bind(txtBookingSub, theUnit, "Booking_Id_Sub");
			BindHelper.Bind(cmbVoyageVessel, theUnit, "Voyage_No");
			BindHelper.Bind(cmbPolTerminal, theUnit, "Poe_Terminal_Cd");
			BindHelper.Bind(cmbPODTerminal, theUnit, "Pod_Terminal_Cd");
			BindHelper.Bind(txtHeight, theUnit, "Height_Nbr");
			BindHelper.Bind(txtLength, theUnit, "Length_Nbr");
			BindHelper.Bind(txtWeight, theUnit, "Wt_Nbr");
			BindHelper.Bind(txtWidth, theUnit, "Width_Nbr");
			BindHelper.Bind(cmbCommodity, theUnit, "Commodity_Cd");
			BindHelper.Bind(cmbCargoCode, theUnit, "Cargo_ID");
			BindHelper.Bind(cmbRevenue, theUnit, "Rev_Cd");
			BindHelper.Bind(txtRDD, theUnit, "Adj_Rdd_Dt");
			BindHelper.Bind(txtVolume, theUnit, "Volume_Nbr");

			// If the are rows in the RDD Adjustment Log it means they can make
			// changes to the RDD at the cargo level.
			// DGERDNER APR-2018
			//    Remove this logic and just let users make changes to the RDD whenever they want.
			//if (theUnit.Booking.RDDLog.Rows.Count > 0)
			    txtRDD.Enabled = true;
			//else
			//    txtRDD.Enabled = false;
						
			// If this is a Stena Booking, but there is no Stena Data, create it
			if (theUnit.StenaBooking == null)
				if (theUnit.IsStenaBooking)
				{
					theUnit.StenaBooking = CreateStenaBooking();
				}

			// If there is Stena Booking data, bind it.
			if (theUnit.StenaBooking != null)
			{
				BindHelper.Bind(txtStenaID, theUnit.StenaBooking, "Stena_ID");
				BindHelper.Bind(txtCargoTrailerNo, theUnit.StenaBooking, "Trailer_No");
				txtCargoRoute.Text = theUnit.StenaRoutecd;
				if (theUnit.StenaBooking.Sailing_Dt != null)
					txtStenaDate.Text = theUnit.StenaBooking.Sailing_Dt.ToString();
				else
					txtStenaDate.Text = theUnit.StenaProposedDepartDt.ToString();
				if (theUnit.CargoCode != null)
					txtVehicleType.Text = theUnit.CargoCode.Stena_Vehicle_Type_Cd;

				DataTable dtRoutes = theUnit.GetStenaSailings();
				if (theUnit.Voyage != null)
				{
					txtVessel.Text = theUnit.Voyage.Vessel_Cd;
					CS2010.ACMS.Business.ClsVessel v = CS2010.ACMS.Business.ClsVessel.GetUsingKey(theUnit.Voyage.Vessel_Cd);
					if (v != null)
						txtVessel.Text = v.Vessel_Dsc;
				}
				grdStenaRoutes.DataSource = dtRoutes;

				//GetSTENAInfo();
			}


			grpStena.Visible = theUnit.IsStenaBooking;

			// See if there are unsent ITV messages for this cargo
			DataTable dtUnsent = ClsACMSQueries.GetITVNotSent(theUnit.Booking_ID, theUnit.Tcn);
			if (dtUnsent.Rows.Count > 0)
			{
				string sMsg = string.Format(@"If there is are any unsent ITV message, use the Update ITV button to make the ITV voyage match the cargo");
				txtMsg.Text = sMsg;					
				this.Height = 500;
				btnUpdateITV.Enabled = true;
			}
			else
			{
				this.Height = 390;
				btnUpdateITV.Enabled = false;
			}

			if (theUnit.BookingRequest.BookingUnits.Rows.Count < 2)
			{
				cbxCargo.Visible = cbxBooking.Visible = cbxCategory.Visible = cbxCommodity.Visible =
					cbxHeight.Visible = cbxLength.Visible = cbxLength.Visible = cbxPOD.Visible = cbxPOL.Visible =
					cbxVolumne.Visible = cbxVoyage.Visible = cbxWeight.Visible = cbxWidth.Visible =
					cbxCommodity.Checked = cbxCategory.Checked = cbxCargo.Checked = false;
			}
		}

		private void SetPortDropDowns()
		{
			DataTable dtPOL = CS2010.ArcSys.Business.ClsLocation.GetVoyageLocations(theUnit.Voyage_No, "L");
			DataTable dtPOD = CS2010.ArcSys.Business.ClsLocation.GetVoyageLocations(theUnit.Voyage_No, "D");
			cmbPolTerminal.DataSource = dtPOL;
			cmbPODTerminal.DataSource = dtPOD;
		}

		private clsBookingInfo GetSTENAInfo()
		{
			try
			{
				clsBookingInfo sb = ClsSTENAservice.FindBooking(theUnit.Booking_ID, theUnit.StenaBooking.Trailer_No);
				if (sb == null)
					return null;
				txtStenaRoute.Text = sb.RouteCd;
				txtStenaSailDt.Text = sb.SailingDt.ToString();
				//string sDims = sb.Length.ToString() + "x" + sb.Height.ToString() + "x" + sb.Width.ToString();
				//txtDims.Text = sDims;
				txtStenaBookingID.Text = sb.bookingid.ToString();
				txtStenaStatus.Text = sb.StatusCd;
				txtStenaBookingNo.Text = sb.BookingNo;
				txtStenaTrailerNo.Text = sb.VehicleRegistration;
				return sb;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}
		#endregion

		#region Saving
		private void Save()
		{
			try
			{
				// Save Stena
				SaveStena();

				// If validation fails, quit
				if (!theUnit.ValidateUpdate())
					return;

				// Update the unit
				if (theUnit.Voyage != null)
				{
					if (theUnit.Vessel_Cd != theUnit.Voyage.Vessel_Cd)
						theUnit.Vessel_Cd = theUnit.Voyage.Vessel_Cd;
				}
				theUnit.Update();
				theUnit.PostUpdate();
				theUnit.Booking.UpdateBookingData(theUnit);
				theUnit.ReloadFromDB();

				SaveAll();
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected bool SaveStena()
		{
			try
			{
				ClsStenaBooking sb = ClsStenaBooking.GetUsingKey(theUnit.Booking_ID, theUnit.Tcn);
				if (sb == null)
				{
					return false;
				}
				if (String.IsNullOrEmpty(txtStenaID.Text))
					sb.Stena_ID = null;
				else
					sb.Stena_ID = ClsConvert.ToInt64Nullable(txtStenaID.Text);
				sb.Trailer_No = txtCargoTrailerNo.Text;
				sb.Update();
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		private void SaveAll()
		{
			StringBuilder sb = new StringBuilder();
			if (cbxBooking.Checked )
				sb.Append(" Booking:");
			if (cbxCategory.Checked && theUnit.Rev_Cd != oldUnit.Rev_Cd)
				sb.Append(" Category:");
			if (cbxCargo.Checked && theUnit.Cargo_ID != oldUnit.Cargo_ID)
				sb.Append(" Cargo:");
			if (cbxCommodity.Checked && theUnit.Commodity_Cd != oldUnit.Commodity_Cd)
				sb.Append(" Commodity:");
			if (cbxHeight.Checked)
				sb.Append(" Height:");
			if (cbxLength.Checked)
				sb.Append(" Length:");
			if (cbxPOD.Checked)
				sb.Append(" POD:");
			if (cbxPOL.Checked)
				sb.Append(" POL:");
			if (cbxVoyage.Checked)
				sb.Append(" Voyage:");
			if (cbxWeight.Checked)
				sb.Append(" Weight:");
			if (cbxWidth.Checked)
				sb.Append(" Width:");
			if (cbxVolumne.Checked)
				sb.Append(" Volume:");
			if (sb.Length < 1)
				return;
			sb.Append(" Will be changed on all cargo for this booking");
			DialogResult dr = MessageBox.Show(sb.ToString(), "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
			{
				Program.Show("Only the current cargo was updated");
				return;
			}

			/* Save All */
			foreach (DataRow drow in theUnit.BookingRequest.BookingUnits.Rows)
			{
				ClsBookingUnit bu = new ClsBookingUnit(drow);
				/* Don't change the current piece of cargo */
				if (bu.Item_No == theUnit.Item_No)
					continue;

				//// Sept 2016: Old logic changed all cargo/revenue codes if the dims were all the same.
				////   New logic is to change all for the same cargo/revenue code
				//if (bu.Height_Nbr == theUnit.Height_Nbr &&
				//    bu.Length_Nbr == theUnit.Length_Nbr &&
				//    bu.Width_Nbr == theUnit.Width_Nbr)
				//{
				//    if (cbxCargo.Checked)
				//        bu.Cargo_ID = theUnit.Cargo_ID;
				//    if (cbxCategory.Checked)
				//        bu.Rev_Cd = theUnit.Rev_Cd;
				//}
				if (bu.Cargo_ID == oldUnit.Cargo_ID &&
					bu.Rev_Cd == oldUnit.Rev_Cd)
				{
					if (cbxCargo.Checked)
						bu.Cargo_ID = theUnit.Cargo_ID;
					if (cbxCategory.Checked)
						bu.Rev_Cd = theUnit.Rev_Cd;
				}
				///////////////////////////////////////


				if (cbxBooking.Checked)
					bu.Booking_ID = theUnit.Booking_ID;

				if (cbxCommodity.Checked)
					bu.Commodity_Cd = theUnit.Commodity_Cd;
				if (cbxHeight.Checked)
					bu.Height_Nbr = theUnit.Height_Nbr;
				if (cbxLength.Checked)
					bu.Length_Nbr = theUnit.Length_Nbr;
				if (cbxPOD.Checked)
				{
					bu.Pod_Terminal_Cd = theUnit.Pod_Terminal_Cd;
					if (theUnit.PODTerminal == null)
					{
						string sMsg = string.Format("Cannot update {0} because system cannot find terminal {1}", theUnit.Tcn, theUnit.Pod_Terminal_Cd);
						Program.Show(sMsg);
					}
					bu.Pod_Location_Cd = theUnit.PODTerminal.Location_Cd;
				}
				if (cbxPOL.Checked)
				{
					bu.Poe_Terminal_Cd = theUnit.Poe_Terminal_Cd;
					if (theUnit.POLTerminal == null)
					{
						string sMsg = string.Format("Cannot update {0} because system cannot find terminal {1}", theUnit.Tcn, theUnit.Poe_Terminal_Cd);
						Program.Show(sMsg);
					}
					bu.Poe_Location_Cd = theUnit.POLTerminal.Location_Cd;
				}
				if (cbxVoyage.Checked)
				{
					bu.Voyage_No = theUnit.Voyage_No;
					bu.Mil_Voyage_No = theUnit.Mil_Voyage_No;
				}
				if (cbxVolumne.Checked)
					bu.Volume_Nbr = theUnit.Volume_Nbr;
				if (cbxWeight.Checked)
					bu.Wt_Nbr = theUnit.Wt_Nbr;
				if (cbxWidth.Checked)
					bu.Width_Nbr = theUnit.Width_Nbr;
				bu.Update();
				bu.PostUpdate();
				if (bu.HasErrors)
					Program.Show(bu.Error);
			}

			if (theUnit.Booking.HasErrors)
			{
				Program.Show(theUnit.Booking.Error);
			}
		}

		private void SaveAllOld()
		{
			/* Obsolete */
			foreach (DataRow drow in theUnit.BookingRequest.BookingUnits.Rows)
			{
				ClsBookingUnit bu = new ClsBookingUnit(drow);
				bu.UpdateBookingData(theUnit);
				if (bu.HasErrors)
					Program.Show(bu.Error);
			}
			theUnit.Booking.UpdateBookingData(theUnit);
			if (theUnit.Booking.HasErrors)
			{
				Program.Show(theUnit.Booking.Error);
			}
		}

		private ClsStenaBooking CreateStenaBooking()
		{
			try
			{
				// Cannot create if there is no booking ID
				if (string.IsNullOrEmpty(theUnit.Booking_ID))
					return null;
				ClsStenaBooking sb = new ClsStenaBooking();
				sb.Serial_No = theUnit.Tcn;
				sb.Booking_No = theUnit.Booking_ID;
				sb.Insert();
				return sb;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		#endregion

		#region Events
		private void btnSaveStena_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void btnUpdateITV_Click(object sender, EventArgs e)
		{
			try
			{
				if (!ClsACMSUtil.SynchronizeITVData(theUnit.Booking_ID, theUnit.Tcn))
					Program.Show("Synchronization failed");
				else
					Program.Show("ITV data has been synchronized to match this booking");
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cmbVoyageVessel_Validated(object sender, EventArgs e)
		{
			SetPortDropDowns();
			CheckChanged();
		}
		private void CheckChanged()
		{
			if (theUnit.BookingRequest.BookingUnitList.Count < 2)
				return;

			//if (oldUnit.Length_Nbr != theUnit.Length_Nbr)
			//    cbxLength.Visible =  true;
			//else cbxLength.Visible = cbxLength.Checked = false;

			//if (oldUnit.Width_Nbr != theUnit.Width_Nbr)
			//    cbxWidth.Visible = true;
			//else
			//    cbxWidth.Visible = cbxWidth.Checked = false;

			//if (oldUnit.Booking_ID != theUnit.Booking_ID)
			//    cbxBooking.Visible = true;
			//else
			//    cbxBooking.Visible = cbxBooking.Checked = false;
			
			//cbxPOL.Visible = (oldUnit.Poe_Terminal_Cd != theUnit.Poe_Terminal_Cd);
			//cbxHeight.Visible = (oldUnit.Height_Nbr != theUnit.Height_Nbr);
			//cbxVoyage.Visible = (oldUnit.Voyage_No != theUnit.Voyage_No);
			//cbxPOD.Visible = (oldUnit.Pod_Terminal_Cd != theUnit.Pod_Terminal_Cd);
			//cbxWeight.Visible = (oldUnit.Wt_Nbr != theUnit.Wt_Nbr);
			//cbxCommodity.Checked =  cbxCommodity.Visible = (oldUnit.Commodity_Cd != theUnit.Commodity_Cd);
			//cbxCargo.Checked = cbxCargo.Visible = (oldUnit.Cargo_ID != theUnit.Cargo_ID);
			//cbxCategory.Checked = cbxCategory.Visible = (oldUnit.Rev_Cd != theUnit.Rev_Cd);
			//cbxVolumne.Visible = (oldUnit.Volume_Nbr != theUnit.Volume_Nbr);

			//if (oldUnit.Poe_Terminal_Cd == theUnit.Poe_Terminal_Cd) cbxPOL.Checked = false;
			//if (oldUnit.Pod_Terminal_Cd == theUnit.Pod_Terminal_Cd) cbxPOD.Checked = false;
			//if (oldUnit.Height_Nbr == theUnit.Height_Nbr) cbxHeight.Checked = false;
			//if (oldUnit.Voyage_No == theUnit.Voyage_No) cbxVoyage.Checked = false;
			//if (oldUnit.Wt_Nbr == theUnit.Wt_Nbr) cbxWeight.Checked = false;
			//if (oldUnit.Volume_Nbr == theUnit.Volume_Nbr) cbxVolumne.Checked = false;
			//if (oldUnit.Commodity_Cd == theUnit.Commodity_Cd) cbxCommodity.Checked = false;
			//if (oldUnit.Cargo_ID == theUnit.Cargo_ID) cbxCargo.Checked = false;
			//if (oldUnit.Rev_Cd == theUnit.Rev_Cd) cbxCategory.Checked = false;
		}

		private void KeyFieldLeave(object sender, EventArgs e)
		{
			CheckChanged();
		}
		private void KeyValidated(object sender, EventArgs e)
		{
			CheckChanged();
		}


		private void btnOlderVoyages_Click(object sender, EventArgs e)
		{
			DataTable dtVoyageVessel = ClsDropDowns.AllVoyages;
			cmbVoyageVessel.DataSource = dtVoyageVessel;
		}

		private void btnClone_Click(object sender, EventArgs e)
		{
			Int32 iCount = numCloneCount.Value.ToInt();
			if (!theUnit.CloneCargo(iCount))
			{
				Program.Show(theUnit.Error);
				return;
			}
			Program.Show("Cargo was successfully Cloned");
			Close();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				string sMsg = string.Format("Delete item#: {0}?", theUnit.Item_No);
				DialogResult dr = MessageBox.Show(sMsg, "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (dr == DialogResult.Cancel)
					return;
				if (!theUnit.DeleteCargo())
				{
					Program.Show(theUnit.Error);
					return;
				}
				Program.Show("Cargo successfully delete");
				Close();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		#endregion

		private void btnConfirmStena_Click(object sender, EventArgs e)
		{
			//btnConfirmStena.Visible = false;
			clsBookingInfo sb = GetSTENAInfo();
			pnlStenaAPI.Visible = true;
			if (sb == null)
			{
				Program.Show("Could not find a matching booking in STENA");
				return;
			}
			if (sb.SailingDt != theUnit.StenaProposedDepartDt)
			{
				Program.Show("STENA sail date does not match");
			}
			if (sb.bookingid != theUnit.StenaBooking.Stena_ID)
			{
				Program.Show("STENA ID does not match");
			}
			if (sb.BookingNo != theUnit.Booking_ID)
			{
				Program.Show("STENA Customer Ref does not match our Booking#");
			}
			if (sb.VehicleRegistration != theUnit.StenaBooking.Trailer_No)
			{
				Program.Show("Trailer Numbers do not match");
			}
		}

        private void EmptyRowLogic()
        {
            //
            // If there is no row in the database for this booking unit
            // ask if the user wants to import data from OCEAN.
            //
            ClsVwArcBookingCargo oCargo = ClsVwArcBookingCargo.GetForBookingSerialNo(theUnit.Booking_ID, theUnit.Tcn);
            if (oCargo.IsNull())
            {
                Program.Show("This cargo no longer exists in OCEAN or ACMS");
                return;
            }
            DialogResult dr = MessageBox.Show("Cargo no longer exists in ACMS.  Import data from OCEAN?", "Question", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return;
            }
            //Program.Show("Data will be imported now.");
            dr = MessageBox.Show("You are about to import a piece of cargo from OCEAN.  Please confirm this is what you want to do.", "Confirm", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            ClsBookingRequest br = ClsBookingRequest.GetByRequestCd(theUnit.Partner_Request_Cd);
            int i = br.LastCargoItemNo;
            i++;
            ClsBookingUnit.ImportRowFromOcean(theUnit.Booking_ID, theUnit.Tcn, theUnit.Partner_Request_Cd, i);
            theUnit = ClsBookingUnit.GetUsingKey(br.Partner_Cd, br.Partner_Request_Cd, i);
            if (!theUnit.IsNull())
            {
                bGoodRow = true;
                Program.Show("This piece of cargo has been imported from OCEAN.  You will need to update its commodity, cargo, and category codes.");
            }
        }
	}
}
