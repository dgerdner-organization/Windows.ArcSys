using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditConveyance : Form
	{
		#region Fields/Properties

		private DialogMode CurrentMode;

		private string Vendor_Cd;
		private ClsVendorMove theVendorMove;

		private DataTable dtNewCargo;
		private DataTable dtExistingCargo;

		private ClsConveyance theConveyance;

		#endregion		// #region Fields

		#region Constructors/Entry/Init

		public frmEditConveyance()
		{
			InitializeComponent();
		}

		public ClsConveyance AddCargo(long? vendorMoveID, DataRow[] rows)
		{
			try
			{
				CurrentMode = DialogMode.Add;

				theConveyance = new ClsConveyance();
				theConveyance.SetDefaults();
				theConveyance.Futile_Flg = "N";
				theConveyance.Vendor_Move_ID = vendorMoveID;
				theVendorMove = theConveyance.Vendor_Move;

				cmbVendorMove.Visible = chkFutile.Visible = false;
				chkFutile.Enabled = false;

				txtConveyanceNo.Visible = false;

				cmbConveyanceNo.Visible = true;
				cmbConveyanceNo.Left = 84;
				cmbConveyanceNo.Top = 12;

				txtTruckNo.Left = 84;
				txtTruckNo.Top = 38;
				txtDriver.Left = txtTruckNo.Right + 42;
				txtDriver.Top = txtTruckNo.Top;

				Vendor_Cd = theVendorMove.Vendor_Cd;
				dtNewCargo = ( rows != null && rows.Length >0 ) ? rows[0].Table.Clone() : null;
				if (dtNewCargo != null)
				{
					foreach (DataRow dr in rows)
					{
						dtNewCargo.ImportRow(dr);
					}
				}
				Text = "Add Cargo to Conveyance";
				return (ShowDialog() == DialogResult.OK) ? theConveyance : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public ClsConveyance AddFutileConveyance(string vendorCd)
		{
			try
			{
				CurrentMode = DialogMode.Add;
				theConveyance = new ClsConveyance();
				theConveyance.SetDefaults();
				theConveyance.Futile_Flg = "Y";

				cmbConveyanceNo.Visible = false;
				chkFutile.Visible = true;
				chkFutile.Enabled = false;

				cmbVendorMove.Visible = true;
				cmbVendorMove.Left = 84;
				cmbVendorMove.Top = 12;

				txtConveyanceNo.Visible = true;
				txtConveyanceNo.Left = 84;
				txtConveyanceNo.Top = 38;

				txtTruckNo.Left = 84;
				txtTruckNo.Top = 64;
				txtDriver.Left = txtTruckNo.Right + 42;
				txtDriver.Top = txtTruckNo.Top;

				Vendor_Cd = vendorCd;
				Text = "Add Futile Conveyance";
				BackColor = System.Drawing.SystemColors.Control;
				grdCargo.Visible = pnlMoveInfo.Visible = false;
				Height = 120;
				return (ShowDialog() == DialogResult.OK) ? theConveyance : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditConveyance(ClsConveyance aCnvy)
		{
			try
			{
				long? id = (aCnvy != null) ? aCnvy.Conveyance_ID : null;
				theConveyance = (id != null) ? ClsConveyance.GetUsingKey(id.Value) : null;
				if (theConveyance == null)
					return Program.ShowError("Missing or invalid conveyance provided");

				CurrentMode = DialogMode.Edit;

				cmbVendorMove.Visible = cmbConveyanceNo.Visible = false;

				long cargoCount = theConveyance.GetActiveCargoCount();
				chkFutile.Visible = chkFutile.Enabled = (cargoCount <= 0);

				txtConveyanceNo.Visible = true;
				txtConveyanceNo.Left = 84;
				txtConveyanceNo.Top = 12;

				txtTruckNo.Left = 84;
				txtTruckNo.Top = 38;
				txtDriver.Left = txtTruckNo.Right + 42;
				txtDriver.Top = txtTruckNo.Top;

				Vendor_Cd = aCnvy.Vendor_Move.Vendor_Cd;
				Text = "Edit Conveyance Number/Type";
				BackColor = System.Drawing.SystemColors.Control;
				infCreateOptions.Visible = lblConveyance.Visible = false;
				Height = 120;
				if (ShowDialog() != DialogResult.OK) return false;

				aCnvy.CopyFrom(theConveyance);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmEditConveyance_Load(object sender, EventArgs e)
		{
			try
			{
				grdCargoNew.DataSource = dtNewCargo;
				grdCargoNew.RootTable.Caption = string.Format("{0} piece(s) to be added to new conveyance",
					grdCargoNew.RecordCount);
				cmbConveyanceNo.Vendor_Move_ID = theConveyance.Vendor_Move_ID;
				cmbVendorMove.Vendor_Cd = Vendor_Cd;
				cmbConveyanceNo.ValidateConveyanceExists = false;

				if (cmbConveyanceNo.Visible)
					cmbConveyanceNo.Value = theConveyance.Conveyance_ID;
				else
					txtConveyanceNo.Text = theConveyance.Conveyance_No;
				
				txtTruckNo.Text = theConveyance.Truck_No;
				txtDriver.Text = theConveyance.Driver;
				chkFutile.Checked = ClsConvert.YNToBool(theConveyance.Futile_Flg);
				if (CurrentMode == DialogMode.Edit)
					FillConveyanceData(theConveyance);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Entry/Init

		#region Save/Close

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (CurrentMode == DialogMode.Add)
				{
					if (theConveyance.Futile_Flg == "Y" )
					{
						theConveyance.Vendor_Move_ID = cmbVendorMove.SelectedVendorMoveID;
						theConveyance.Conveyance_No = txtConveyanceNo.Text.Trim();
					}
					else
					{
						ClsConveyance cnvy = cmbConveyanceNo.SelectedConveyance;
						if (cnvy == null)
							theConveyance.Conveyance_No = cmbConveyanceNo.Text;
						else
							theConveyance.CopyFrom(cnvy);
					}
				}
				else
				{
					theConveyance.Conveyance_No = txtConveyanceNo.Text.Trim();
					theConveyance.Futile_Flg = ClsConvert.BoolToYN(chkFutile.Checked);
				}

				theConveyance.Truck_No = txtTruckNo.Text.Trim();
				theConveyance.Driver = txtDriver.Text.Trim();
				bool ok = (CurrentMode == DialogMode.Add && theConveyance.Conveyance_ID == null)
					? theConveyance.ValidateInsert(false) : theConveyance.ValidateUpdate(false);
				if (!ok)
				{
					Program.ShowError(theConveyance.Error);
					return;
				}

				string q1 = null;
				string q2 = null;
				if (CurrentMode == DialogMode.Add)
				{	// When attempting to insert a new conveyance, do not exclude any conveyances (3rd parameter is null)
					List<ClsConveyance> dupsAdd = ClsConveyance.GetByConveyanceNo(theConveyance.Conveyance_No,
						Vendor_Cd, null);
					bool hasDups = (dupsAdd != null && dupsAdd.Count > 0);
					bool? createNew = ClsConvert.ToBooleanNullable(infCreateOptions.Value);
					if (createNew == null || createNew == true)
					{
						theConveyance.Conveyance_ID = null;	// Null out the conveyance ID, since we want to insert
						if (hasDups)
						{
							/*q1 = string.Format("Other conveyances ({0}) exist with the given truck # {1}.",
								lstDups.Count, theConveyance.Truck_No);
							if( theConveyance.Futile_Flg == "N")
								q2 = string.Format("This will create a new conveyance with the duplicated truck # with {0} piece(s)",
									grdCargoNew.RecordCount);
							else
								q2 = "This will create a new futile conveyance with the duplicated truck #";*/
							Program.ShowError("A conveyance exists with the given BOL/Job #, cannot create a new conveyance with\r\nthe same identifier. Modify the BOL # or select add to existing conveyance.");
							return;
						}
						else
							q1 = q2 = null;
					}
					else
					{
						q1 = null;
						q2 = string.Format("Adding cargo to existing conveyance {0}, total piece count will be {1}",
								theConveyance.Conveyance_No, grdCargo.RecordCount + grdCargoNew.RecordCount);
					}
				}
				else
				{	// When editing conveyance info exclude the current conveyance ID when checking for dups
					List<ClsConveyance> dupsAdd = ClsConveyance.GetByConveyanceNo(theConveyance.Conveyance_No,
						Vendor_Cd, theConveyance.Conveyance_ID);
					if (dupsAdd != null && dupsAdd.Count > 0)
					{
						/*q1 = string.Format("Other conveyances ({0}) exist with the given truck # {1}",
							lstDups.Count, theConveyance.Truck_No);
						q2 = null;*/
						Program.ShowError("A conveyance exists with the given BOL/Job #");
						return;
					}
					else
						q1 = q2 = null;
				}

				if (!string.IsNullOrWhiteSpace(q1) || !string.IsNullOrWhiteSpace(q2))
				{
					if (!Display.Ask("Confirm", "{0}\r\n{1}\r\nDo you want to proceeed?", q1, q2))
						return;
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Save/Close

		private void cmbConveyance_Validated(object sender, EventArgs e)
		{
			try
			{
				ClsConveyance existingConvey = cmbConveyanceNo.SelectedConveyance;
				if (existingConvey != null)
				{
					txtTruckNo.Text = existingConvey.Truck_No;
					txtDriver.Text = existingConvey.Driver;
					chkFutile.Checked = ClsConvert.YNToBool(existingConvey.Futile_Flg);
				}
				FillConveyanceData(existingConvey);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cmbConveyance_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				ClsConveyance existingConvey = cmbConveyanceNo.SelectedConveyance;
				if (existingConvey != null)
				{
					txtTruckNo.Text = existingConvey.Truck_No;
					txtDriver.Text = existingConvey.Driver;
					chkFutile.Checked = ClsConvert.YNToBool(existingConvey.Futile_Flg);
				}
				FillConveyanceData(existingConvey);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void FillConveyanceData(ClsConveyance cnv)
		{
			try
			{
				if (cnv == null)
				{
					grdCargo.DataSource = null;
					grdCargo.RootTable.Caption = "New conveyance";
					txtCustomer.Text = null;
					txtMoveDsc.Text = null;
					txtOrig.Text = null;
					txtDest.Text = null;
					lblConveyance.Text = "This will create a new conveyance";
					infCreateOptions.Enabled = false;
					grdCargo.Visible = false;
					splGrids.Collapsed = true;
				}
				else
				{
					if (dtExistingCargo != null)
					{
						dtExistingCargo.Dispose();
						dtExistingCargo = null;
					}
					grdCargo.Visible = true;
					dtExistingCargo = cnv.GetActiveCargo();
					grdCargo.DataSource = dtExistingCargo;
					grdCargo.RootTable.Caption = string.Format("{0} Row(s) on existing conveyance {1} {2} ID {3}",
						grdCargo.RecordCount.ToString(), cnv.Conveyance_No, cnv.Truck_No, cnv.Conveyance_ID);

					ClsVendorMove vmv = cnv.Vendor_Move;
					ClsMove mv = vmv.Move;
					txtCustomer.Text = mv.Trading_Partner.Partner_Dsc;
					txtMoveDsc.Text = mv.Move_Dsc;
					txtOrig.Text = vmv.Orig_Location.Location_Dsc;
					txtDest.Text = vmv.Dest_Location.Location_Dsc;

					lblConveyance.Text = "Conveyance exists with the given #, select one of the options below";
					infCreateOptions.Enabled = true;
					splGrids.Collapsed = false;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void infCreateOptions_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				bool? createNew = ClsConvert.ToBooleanNullable(infCreateOptions.Value);
				string state = createNew.GetValueOrDefault(true) ? "new" : "existing";
				grdCargoNew.RootTable.Caption = string.Format("{0} piece(s) to be added to {1} conveyance {2}",
					grdCargoNew.RecordCount, state, cmbConveyanceNo.Text);
				ClsConveyance cnvy = cmbConveyanceNo.SelectedConveyance;
				lblConveyance.Text = createNew.GetValueOrDefault(true)
					? "This will create a new conveyance"
					: "Conveyance exists with the given #, select one of the options below";
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}
