using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.CommonSecurity;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditVendorMove : frmChildBase
	{
		#region Form
		protected ClsMove theMove;

		protected bool bCreate;

		protected DataTable dtVendorMoves;

		protected ClsVendorMove currentVendorMove;

		public frmEditVendorMove()
		{
			InitializeComponent();
		}

		public void ShowForm()
		{
			ShowForm(null);
		}

		public void ShowForm(ClsMove aMove)
		{
			// If a valid move was sent here, we must be changing an existing Move.
			// Otherwise we must be creating a New Move.
			if (aMove == null)
			{
				bCreate = true;
				theMove = new ClsMove();
				this.Text = "Create New Move";
				AddVendorMove();
			}
			else
			{
				bCreate = false;
				theMove = aMove;
				this.Text = string.Format("Edit {0} ", theMove.Move_Dsc);
				cmbTradingPartner.Enabled = false;
			}

			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}

		public void ShowEditVendorMove(ClsVendorMove aVendorMove)
		{
			// Edit an existing Vendor Move
			theMove = aVendorMove.Move;
			currentVendorMove = aVendorMove;
			BindVendorMove();
			ShowForm(theMove);
			if (aVendorMove == null)
				AddVendorMove();
		}

		public void ShowEditVendorMove(ClsMove aMove)
		{
			// If a Move is passed here, it means we're adding a vendor
			// move to that Move.
			theMove = aMove;
			ShowForm(theMove);
			AddVendorMove();
		}

		public void InitForm()
		{
			try
			{
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

				//  If we're creating a new move, set the Vendor Move area invisible
				//  Otherwise make it visible.

				// Get Dropdown stuff, and bind the Move to its controls
				DataTable dt = ClsTradingPartner.GetAll();
				cmbTradingPartner.DataSource = dt;
				DataTable dtVendor = ClsVendor.GetAll();
				cmbVendor.DataSource = dtVendor;

				DataTable dtVendorMoves = ClsMove.GetAll();
				//cmbVendorMove.DataSource = dtVendorMoves;

				BindHelper.Bind(txtMoveDsc, theMove, "move_dsc");
				BindHelper.Bind(cmbTradingPartner, theMove, "trading_partner_cd");

				EditOrCreate();
				EnableSave(false);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void EditOrCreate()
		{
			//if (bCreate)
			//{
			//    cmbMoves.Visible = false;
			//    txtMoveDsc.Visible = true;
			//    btnSave.Visible = true;
			//}
			//else
			//{
			//    cmbMoves.Visible = true;
			//    txtMoveDsc.Visible = false;
			//    btnSave.Visible = false;
			//}
		}
		#endregion
		
		#region Moves
		public bool CreateMove()
		{
			try
			{
				if (!VerifyInsertMove())
					return false;

				theMove.SetDefaults();
				theMove.Insert();
				Program.Show("New Move Created.");
				//ShowForm(theMove);
				//AddVendorMove();
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		protected bool VerifyInsertMove()
		{
			if (bCreate)
			{
				if (string.IsNullOrEmpty(txtMoveDsc.Text))
				{
					Program.Show("Move Description is required");
					return false;
				}
			}
			if (cmbDest.SelectedIndex < 0)
			{
				Program.Show("Destination is required");
				return false;
			}
			if (cmbOrigin.SelectedIndex < 0)
			{
				Program.Show("Origin is required");
				return false;
			}
			if (cmbTradingPartner.SelectedIndex < 0)
			{
				Program.Show("Customer is required");
				return false;
			}
			if (cmbVendor.SelectedIndex < 0)
			{
				Program.Show("Vendor is required");
				return false;
			}
			return true;
		}

		public bool SaveMove()
		{
			try
			{
				if (bCreate)
					return CreateMove();
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}

		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			if (bCreate)
				CreateMove();
			else
				SaveMove();
		}

		private void rbExistingMove_CheckedChanged(object sender, EventArgs e)
		{
			EditOrCreate();
		}

		private void rbNewMove_CheckedChanged(object sender, EventArgs e)
		{
			EditOrCreate();
		}

		private void btnNewMove_Click(object sender, EventArgs e)
		{
			theMove = new ClsMove();
			bCreate = true;
			//cmbVendorMove.ReadOnly = true;
			txtMoveDsc.ReadOnly = false;
			txtMoveDsc.Visible = true;
			cmbTradingPartner.ReadOnly = false;
			cmbTradingPartner.Enabled = true;
			InitForm();
		}


		#endregion

		#region VendorMoves

		private void AddVendorMove()
		{
			currentVendorMove = new ClsVendorMove();
			currentVendorMove.Move_ID = theMove.Move_ID;
			currentVendorMove.Active_Flg = "Y";
			cbxVMActive.Checked = true;
			BindVendorMove();
		}

		private void SaveVendorMove()
		{
			try
			{
				if (!VerifyInsertMove())
					return;

				// Checkbox stuff
				if (cbxVMActive.Checked)
					currentVendorMove.Active_Flg = "Y";
				else
					currentVendorMove.Active_Flg = "N";

				if (currentVendorMove.Vendor_Move_ID != null)
				{
					currentVendorMove.Update();
				}
				else
				{
					currentVendorMove.SetDefaults();
					currentVendorMove.Move_ID = theMove.Move_ID;
					currentVendorMove.Insert();
				}

				bCreate = false;
				txtMoveDsc.ReadOnly = true;
				cmbTradingPartner.ReadOnly = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void BindVendorMove()
		{
			if (currentVendorMove == null)
				return;
			//BindHelper.Bind(cmbVendorMove, currentVendorMove, "move_id");
			BindHelper.Bind(cmbVendor, currentVendorMove, "vendor_cd");
			BindHelper.Bind(cmbOrigin, currentVendorMove, "orig_location_cd");
			BindHelper.Bind(cmbDest, currentVendorMove, "dest_location_cd");
			BindHelper.Bind(txtAllocated, currentVendorMove, "allocated_qty");
			BindHelper.Bind(txtUsed, currentVendorMove, "Used_Qty");
			BindHelper.Bind(txtFutile, currentVendorMove, "Futile_Qty");
			cbxVMActive.Checked = false;
			if (currentVendorMove.Active_Flg == "Y")
				cbxVMActive.Checked = true;

			GetAvailableCargo();
			GetAssignedCargo();
		}

		private void EnableSave(bool bEnable)
		{
			btnSaveVendorMove.Enabled = bEnable;
		}

		private void grdVendorMoves_SelectionChanged(object sender, EventArgs e)
		{
			//SetCurrentVendorMove();
			BindVendorMove();
		}

		private void btnSaveVendorMove_Click(object sender, EventArgs e)
		{
			if (!SaveMove())
				return;
			SaveVendorMove();
		}

		private void ucGridToolStrip1_ClickAdd(object sender, EventArgs e)
		{
			AddVendorMove();
		}

		private void ucGridToolStrip1_ClickEdit(object sender, EventArgs e)
		{
			//EditVendorMove();
		}

		#endregion

		#region AssignCargo
		private void AssignCargo()
		{
			foreach (DataRow dr in grdAvailable.GetCheckedDataRows())
			{
				ClsCargoActivity ca = new ClsCargoActivity(dr);
				ClsCargoMove cm = new ClsCargoMove();
				cm.Active_Flg = "Y";
				cm.Vendor_Move_ID = currentVendorMove.Vendor_Move_ID;

				cm.SetValuesFromActivity(ca);
				
				cm.Insert();
				GetAvailableCargo();
				GetAssignedCargo();
			}
		}
		private void UnassignCargo()
		{
			try
			{
				foreach (DataRow dr in grdAssigned.GetCheckedDataRows())
				{
					ClsCargoMove cm = new ClsCargoMove(dr);
					cm.Delete();
				}
				GetAssignedCargo();
				GetAvailableCargo();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void GetAvailableCargo()
		{
			// Bail out if this is a brand new vendor move
			if (currentVendorMove.Vendor_Move_ID == null)
				return;
			DataTable dtAvail = ClsCargo.GetAvailableForMove( 
				currentVendorMove.Orig_Location_Cd, currentVendorMove.Dest_Location_Cd);
			grdAvailable.DataSource = dtAvail;

		}
		private void GetAssignedCargo()
		{
			try
			{
				// Bail out if this is a brand new vendor move
				if (currentVendorMove.Vendor_Move_ID == null)
					return;
				if (currentVendorMove.CargoOnMove == null)
					return;
				DataTable dtAssigned = currentVendorMove.CargoOnMove;
				grdAssigned.DataSource = dtAssigned;
			}
			catch
			{
			}
		}
		private void tsAssignCargo_Click(object sender, EventArgs e)
		{
			AssignCargo();
		}

		private void tsUnassignCargo_Click(object sender, EventArgs e)
		{
			UnassignCargo();
		}
		#endregion

		private void cmbVendor_Validated(object sender, EventArgs e)
		{
			EnableSave(true);
		}

		private void cmbOrigin_Validated(object sender, EventArgs e)
		{
			EnableSave(true);
		}

		private void cmbDest_Validated(object sender, EventArgs e)
		{
			EnableSave(true);
		}

		private void txtAllocated_Validated(object sender, EventArgs e)
		{
			EnableSave(true);
		}

		private void cbxVMActive_CheckedChanged(object sender, EventArgs e)
		{
			EnableSave(true);
		}






	}
}
