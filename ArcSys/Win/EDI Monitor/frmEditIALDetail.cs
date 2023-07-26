using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.Common;
using CS2010.CommonWinCtrls;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditIALDetail : CS2010.CommonWinCtrls.frmDialogBase
	{
		public frmEditIALDetail()
		{
			InitializeComponent();
		}
		#region Properties
		protected ClsEdiInboundDetail theDetail;
		protected ClsEdiInboundSi theSI;
		protected DataTable dtTypes;
		#endregion

		#region Methods
		protected void FormLoad()
		{
			try
			{
				// Popuplate Types list
				dtTypes = new DataTable();
				dtTypes.Columns.Add("Vehicle_Type_Cd", typeof(string));
				DataRow drow = dtTypes.NewRow();
				drow["Vehicle_Type_Cd"] = "CAR";
				dtTypes.Rows.Add(drow);
				DataRow drow2 = dtTypes.NewRow();
				drow2["Vehicle_Type_Cd"] = "VAN";
				dtTypes.Rows.Add(drow2);

				cmbTypeDtl.DataSource = dtTypes;

				// Set max lengths
				txtVIN.MaxLength = ClsEdiInboundDetail.VinMax;
				
				// Bind Details
				BindHelper.Bind(txtVIN, theDetail, "Vin");
				BindHelper.Bind(txtBookingNo, theDetail, "Booking_No");
				BindHelper.Bind(cbxProcessed, theDetail, "Processed_Flg");
				BindHelper.Bind(cmbTypeDtl, theDetail, "Vehicle_Type_Cd");
				BindHelper.Bind(txtHeight, theDetail, "Height_Nbr");
                BindHelper.Bind(txtYear, theDetail, "Vehicle_Year");
                BindHelper.Bind(txtMake, theDetail, "Make");
                BindHelper.Bind(txtModel, theDetail, "Model");

				// Bind Shipping Instructins
				if (theSI != null)
				{
					BindHelper.Bind(txtBookingNoSI, theSI, "Booking_No");
					BindHelper.Bind(txtVINSI, theSI, "VIN");
					BindHelper.Bind(cbxProcessedSI, theSI, "Processed_Flg");
					BindHelper.Bind(txtLastNm, theSI, "Last_Nm");
				}
												
				// Set title
				Text = string.Format("{0} Detail", CurrentMode.ToString());
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public bool Edit(ClsEdiInboundDetail aDetail, ClsEdiInboundSi anSI)
		{
			try
			{
				CurrentMode = DialogMode.Edit;
				theDetail = new ClsEdiInboundDetail(aDetail);

				// Get the SI row
				theSI = ClsEdiInboundSi.GetByBookingVin(theDetail.Booking_No, theDetail.Vin);

				if (ShowDialog() != DialogResult.OK) return false;

				aDetail.CopyFrom(theDetail);
				if (anSI != null)
					anSI.CopyFrom(theSI);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		public bool Edit(ClsEdiInboundSi anSI, ClsEdiInboundDetail aDetail)
		{
			try
			{
				CurrentMode = DialogMode.Edit;
				theSI = new ClsEdiInboundSi(anSI);

				// Get the Detail row
				theDetail = ClsEdiInboundDetail.GetByBookingVin(anSI.Booking_No, anSI.Vin);

				if (ShowDialog() != DialogResult.OK) return false;

				anSI.CopyFrom(theSI);
				aDetail.CopyFrom(theDetail);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		protected void DeleteCargo()
		{
			try
			{
				string sMsg = string.Format("Remove VIN {0} from booking {1}?", theDetail.Vin, theDetail.Booking_No);
				if (MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				{
					Program.Show("Action cancelled by user");
					this.DialogResult = DialogResult.Cancel;
					return;
				}
				theDetail.DeleteCargo();
				Program.Show("Cargo detail has been removed");
				this.DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return;
			}
		}

		protected override bool SaveChanges()
		{
			try
			{
				if (CurrentMode == DialogMode.Add)
					theDetail.Insert();
				else
				{
					if (theDetail != null)
						theDetail.Update();
					if (theSI != null)
						theSI.Update();

				}

				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion

		#region Events
		private void frmEditIALDetail_Load(object sender, EventArgs e)
		{
			FormLoad();
		}
		private void txtBookingNo_TextChanged(object sender, EventArgs e)
		{
			txtBookingNoSI.Text = txtBookingNo.Text;
		}

		private void txtVIN_TextChanged(object sender, EventArgs e)
		{
			txtVINSI.Text = txtVIN.Text;
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			DeleteCargo();
		}
		#endregion






		
	}
}
