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

namespace CS2010.ArcSys.Win
{
    public partial class frmAssignVendor : frmDialogBase
    {
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

        #region Properties

		private ClsTradingPartner currentShipper;
		private List<ClsCargoActivity> currentCargo;
		private string currentOriginCd
		{
			get
			{
				if (currentCargo.Count > 0)
					return currentCargo[0].Orig_Location.Location_Cd;
				return null;
			}
		}
		private string currentDestCd
		{
			get 
			{
				if (currentCargo.Count > 0)
					return currentCargo[0].Dest_Location_Cd;
				return null;
			}
		}
		private ClsMove _currentMove;
		private ClsMove currentMove
		{
			get
			{
				if (_currentMove != null)
					return _currentMove;
				object obj = cmbMoves.SelectedItem;
				DataRowView drv = (DataRowView)obj;
				if (drv == null)
					return null;
				_currentMove = new ClsMove(drv.Row);
				return _currentMove;
			}
			set
			{
				_currentMove = value;
			}
		}
		private ClsVendor currentVendor
		{
			get
			{
				return cmbVendor.SelectedVendor;
			}
		}

        private DataTable dtExistingMoves;

		public ClsVendorMove newVendorMove;
        #endregion

        #region Init

		public frmAssignVendor()
        {
            InitializeComponent();
        }

		public void Setup(ClsTradingPartner partner, List<ClsCargoActivity> cargo)
		{
			currentShipper = partner;
			txtShipper.Text = currentShipper.Partner_Dsc;
			currentCargo = cargo;
			if (currentCargo.Count > 0)
			{
				txtOrigin.Text = cargo[0].Orig_Location.Location_Dsc;
				txtDestination.Text = cargo[0].Dest_Location.Location_Dsc;
			}
			grdCargo.DataSource = currentCargo;
            cmbMoves.DataSource = dtExistingMoves = ClsMove.GetForShipper(currentShipper.Trading_Partner_Cd);
		}
        #endregion

        #region Overrides

		protected override bool SaveChanges()
		{
			Connection.TransactionBegin();
			try
			{
				if (!CheckChanges())
					return false;

				// See if they have chosen to create a new move
				if (rbNew.Checked)
				{
					_currentMove = new ClsMove();
					_currentMove.SetDefaults();
					_currentMove.Move_Dsc = txtMoveDsc.Text;
					_currentMove.Trading_Partner_Cd = currentShipper.Trading_Partner_Cd;
					_currentMove.Insert();
				}
				// See if a vendor move already exists for this 
				//  move, origin, destination, vendor.  If it does
				//  we'll use it.  Otherwise we create a new vendor
				//  move.
				ClsVendorMove move = ClsVendorMove.FindVendorMove(
						currentMove.Move_ID.GetValueOrDefault(), currentVendor.Vendor_Cd, currentOriginCd, currentDestCd);
				if (move == null)
				{
					newVendorMove = new ClsVendorMove();
					newVendorMove.SetDefaults();
					newVendorMove.Move_ID = currentMove.Move_ID;
					newVendorMove.Orig_Location_Cd = currentOriginCd;
					newVendorMove.Dest_Location_Cd = currentDestCd;
					newVendorMove.Vendor_Cd = currentVendor.Vendor_Cd;
					if (newVendorMove.ValidateInsert())
						newVendorMove.Insert();
				}
				else
				{
					newVendorMove = move;
				}

				// Create all Cargo Moves
				foreach (ClsCargoActivity ca in currentCargo)
				{
					ClsCargoMove cm = new ClsCargoMove();
					cm.SetDefaults();
					cm.Vendor_Move_ID = newVendorMove.Vendor_Move_ID;
					cm.Active_Flg = "Y";

					cm.SetValuesFromActivity(ca);

					cm.Insert();
				}
				Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{
				Connection.TransactionRollback();
				Program.ShowError(ex.Message);
				return false;
			}

		}
        protected override bool CheckChanges()
        {
			if (rbExisting.Checked && currentMove == null)
			{
				Program.Show("You must select a Move");
				return false;
			}
			if (rbNew.Checked && string.IsNullOrEmpty(txtMoveDsc.Text))
			{
				Program.Show("You must enter a move description");
				return false;
			}
			if (currentVendor == null)
			{
				Program.Show("You must select a vendor");
				return false;
			}

			return true;
        }        

        #endregion
		
		#region Methods
		protected void RadioButtonAction()
		{
			if (rbExisting.Checked)
			{
				txtMoveDsc.Visible = false;
				cmbMoves.Visible = true;
				cmbMoves.Enabled = true;
                btnEasySelect.Visible = true;
                btnEasySelect.Enabled = true;

			}
			else
			{
				txtMoveDsc.Visible = true;
				cmbMoves.Visible = false;
				cmbMoves.Enabled = false;
                btnEasySelect.Visible = false;
                btnEasySelect.Enabled = false;

			}
		}

        private void EasySelect()
        {
            try
            {
                frmEasyMoveSelect e = new frmEasyMoveSelect();
                if (e.ShowForm(dtExistingMoves))
                {
                    cmbMoves.Text = e.SelectedMove;
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

		#endregion

		#region Events
		private void rbNew_CheckedChanged(object sender, EventArgs e)
		{
			RadioButtonAction();
		}
		private void rbExisting_CheckedChanged(object sender, EventArgs e)
		{
			RadioButtonAction();
		}
        private void btnEasySelect_Click(object sender, EventArgs e)
        {
            EasySelect();
        }
        #endregion

    }
}
