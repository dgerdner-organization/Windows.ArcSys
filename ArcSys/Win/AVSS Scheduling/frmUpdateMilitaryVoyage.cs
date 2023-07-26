using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows;
using Janus.Data;
using Janus.Windows.GridEX;
using CS2010.AVSS.Business;
using CS2010.AVSS.Win;
using CS2010.AVSS.WinCtrls;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;

namespace CS2010.AVSS.Win
{
	public partial class frmUpdateMilitaryVoyage : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmUpdateMilitaryVoyage()
		{
			InitializeComponent();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}
		private List<ClsVesselBerthActivity> berthActivities;

		private ClsMilitaryVoyage currentMilVoy
		{
			get
			{
				string sMilVoy = cmbMilVoy.SelectedValue.ToString();
				ClsMilitaryVoyage mv = ClsMilitaryVoyage.GetUsingKey(sMilVoy);
				return mv;
			}
		}

		private ClsVesselBerthActivity CurrentBerthActivity
		{
			get
			{
				return grdPortCalls.GetCurrentItem<ClsVesselBerthActivity>();
			}
		}

		private List<ClsVesselBerthActivity> SelectedActivities
		{
			get
			{
				List<ClsVesselBerthActivity> list = new List<ClsVesselBerthActivity>();

				int ix = 0;
				foreach( GridEXRow grow in grdPortCalls.GetDataRows())
				{
					if( grow.Selected )
					{
						ClsVesselBerthActivity ba = GetItem(grdPortCalls, ix);
						if( ba != null )
							list.Add(ba);
					}
					ix++;
				}
				grdPortCalls.GetCurrentItem<ClsVesselBerthActivity>();
				return list;
			}
		}
		public void UpdateVoyage(string sFullVoyageNo)
		{
			this.Activate();
			this.Show();
			txtFullVoyage.Text = sFullVoyageNo;
			SearchVoyages();
		}
		private void FormLoad()
		{
			this.WindowState = FormWindowState.Maximized;
		}
		private void SearchVoyages()
		{
			berthActivities = ClsVesselBerthActivity.GetForVoyage(txtFullVoyage.Text);
			grdPortCalls.DataSource = berthActivities;
			GetMilitaryVoyages();
		}
		private void GetMilitaryVoyages()
		{
			if( berthActivities.Count > 0 )
			{
				cmbMilVoy.DataSource = ClsMilitaryVoyage.GetForVoyage
					(berthActivities[0].Trade_Lane_Cd, berthActivities[0].Voyage_No);
			}
		}
		private void EditMilitaryVoyage()
		{
			using( frmEditVesselMilitaryVoyage frm = new frmEditVesselMilitaryVoyage() )
			{
				frm.Edit(CurrentBerthActivity);
				SearchVoyages();
			}
		}
		private ClsVesselBerthActivity GetItem(GridEX grid, int iRow)
		{
			if( iRow < 0 )
				return null;
			if( iRow > grid.GetDataRows().Length - 1 )
				return null;
			ClsVesselBerthActivity ba = new ClsVesselBerthActivity();
			GridEXRow r = grid.GetRow(iRow);
			if( r == null ) return null;

			DataTable dt = grid.DataSource as DataTable;
			if( dt == null ) return r.DataRow as ClsVesselBerthActivity;

			DataRowView drv = r.DataRow as DataRowView;
			if( drv == null ) return null;

			ba.LoadFromDataRow(drv.Row);
			return ba;
		}
		private void AssignToAll()
		{
			if( SelectedActivities.Count < 1)
			{
				MessageBox.Show("You must select at least one port call");
				return;
			}
			foreach( ClsVesselBerthActivity ba in SelectedActivities ) 
			{
				ClsVesselMilitaryVoyage mv = new ClsVesselMilitaryVoyage();
				mv.Vessel_Berth_Activity_ID = ba.Vessel_Berth_Activity_ID;
				mv.Military_Voyage_No = cmbMilVoy.SelectedValue.ToString();
				
				// Verify trade lane and voyae match
				if( currentMilVoy.Trade_Lane_Cd != ba.Trade_Lane_Cd )
				{
					Display.Show("Military Voyage Trade Lane of '{0}' does not match this voyage", 
							currentMilVoy.Trade_Lane_Cd);
					return;
				}
				if( currentMilVoy.Voyage_No != ba.Voyage_No )
				{
					Display.Show("Military Voyage# '{0}' does not match this voyage",
							currentMilVoy.Voyage_No);
					return;
				}
				// See if it already exists
				ClsVesselMilitaryVoyage mvExists =
					ClsVesselMilitaryVoyage.GetUsingKey(mv.Military_Voyage_No, (long)ba.Vessel_Berth_Activity_ID);
				if (mvExists == null)
					mv.Insert();
			}
			SearchVoyages();
		}
		private void RemoveFromAll()
		{
			foreach( ClsVesselBerthActivity ba in SelectedActivities )
			{
				long? lID = ba.Vessel_Berth_Activity_ID;
				string  sMilVoy = cmbMilVoy.SelectedValue.ToString();
				ClsVesselMilitaryVoyage mv = ClsVesselMilitaryVoyage.GetUsingKey(sMilVoy, (long)lID);
				if (mv != null)
					ClsVesselMilitaryVoyage.DeleteRow(mv);
			}
			SearchVoyages();
		}

		private void NewMilitaryVoyage()
		{
			string sTradeLane = null;
			string sVoyageNo = null;
			if( berthActivities.Count > 0 )
			{
				sTradeLane = berthActivities[0].Trade_Lane_Cd;
				sVoyageNo = berthActivities[0].Voyage_No;
			}

			
			using( CS2010.AVSS.Win.frmEditMilitaryVoyage frm = new CS2010.AVSS.Win.frmEditMilitaryVoyage() )
			{
				if( frm.Add(sTradeLane, sVoyageNo) != null )
				{
					GetMilitaryVoyages();
				}
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchVoyages();
		}

		private void frmUpdateMilitaryVoyage_Load(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void grdPortCalls_DoubleClick(object sender, EventArgs e)
		{
			EditMilitaryVoyage();
		}

		private void btnAssignAll_Click(object sender, EventArgs e)
		{
			AssignToAll();
		}

		private void btnRemoveAll_Click(object sender, EventArgs e)
		{
			RemoveFromAll();
		}

		private void btnAddMilVoy_Click(object sender, EventArgs e)
		{
			NewMilitaryVoyage();
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
			//using( frmEditVesselOutsidePortCall frm = new frmEditVesselOutsidePortCall() )
			//{
			//    if (CurrentBerthActivity != null)
			//        frm.Add(CurrentBerthActivity.Vessel_Port_Call);
			//}
		}

		private void btnDeleteMilitaryVoyage_Click(object sender, EventArgs e)
		{
			using( frmMemo frmM = new frmMemo() )
			{
				if( frmM.InputBox("Enter the Military Voyage #:", string.Empty, 6) )
				{
					ClsMilitaryVoyage.DeleteVoyage(frmM.InputText);
				}
			}
		}
	}
}

