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
using CS2010.AVSS.WinCtrls;
using CS2010.CommonWinCtrls;
//using CS2010.Framework.Alpha;
using CS2010.CommonSecurity;
using CS2010.Common;

namespace CS2010.AVSS.Win 
{
    public partial class frmUpdateVessel : frmAVSSChildBase
    {

        public frmUpdateVessel()
        {
            InitializeComponent();
		}
        #region Properties
		//private frmEditVesselPortCall _frmEditVesselPortCall;
		private bool ARCMode = false;
		private List<ClsVesselPortCall> PortCalls;
		private List<ClsVesselBerthActivity> BerthActivities;
		private ClsVessel CurrentVessel
		{
			get
			{
				if( comboVessel.SelectedVessel == null )
					return null;
				ClsVessel v = comboVessel.SelectedVessel;
				return v;
			}
		}
		private ClsPort CurrentPort
		{
			get
			{
				return cmbPort.SelectedPort;
			}
		}


		private ClsVesselPortCall CurrentPortCall
		{
			get
			{
				//if( CurrentVessel == null)
				//    return null;
				if( grdVesselPortCalls.Row < 0 )
					return null;
				return grdVesselPortCalls.GetCurrentItem<ClsVesselPortCall>();
			}
		}
		private ClsVesselPortCall PrevPortCall
		{
			get
			{
				return GetItem(grdVesselPortCalls, grdVesselPortCalls.CurrentRow.RowIndex - 1);
			}
		}
		private ClsVesselPortCall NextPortCall
		{
			get
			{
				return GetItem(grdVesselPortCalls, grdVesselPortCalls.CurrentRow.RowIndex + 1);
			}
		}

		private ClsVesselBerthActivity CurrentActivity
		{
			get
			{
				if( CurrentPortCall == null )
					return null;
				return grdBerthActivity.GetCurrentItem<ClsVesselBerthActivity>();
			}
		}

		private List<ClsVesselPortCall> SelectedPortCalls
		{
			get
			{
				List<ClsVesselPortCall> list = new List<ClsVesselPortCall>();

				int ix = 0;

				foreach(GridEXRow grow in grdVesselPortCalls.GetDataRows())
				{
					if( grow.Selected )
					{
						ClsVesselPortCall vpc = GetItem(grdVesselPortCalls, ix);
						if (vpc != null)
							list.Add(vpc);
					}
					ix++;
				}
				grdVesselPortCalls.GetCurrentItem<ClsVesselPortCall>();
				return list;
			}
		}
		private string SearchTradeVoyage
		{
			get { return txtVoyage.Text; }
		}
		private string SearchTradeLane
		{
			get
			{
				if( txtVoyage.Text.Length < 2 )
					return null;
				return txtVoyage.Text.Substring(0, 2);
			}
		}
		private string SearchVoyageNo
		{
			get
			{
				if( txtVoyage.Text.Length < 5 )
					return null;
				return txtVoyage.Text.Substring(2, 3);
			}
		}
        #endregion

        #region Helper Methods

		public void SetToARCMode()
		{
			ARCMode = true;
		}
		private void FormLoad()
		{
			
			this.WindowState = FormWindowState.Maximized;
			if( !ClsEnvironment.IsDesignMode )
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			if( ARCMode )
			{
				ucGridToolStrip1.HideEditButton = true;
			}
			DefaultParms();

			if( !SecureContextMenu() ) Close();
		}

		private bool SecureContextMenu()
		{
			try
			{
				tsInsertPortBefore.Visible = (ucGridToolStrip1.Visible && tsInsertBefore.Visible);
				tsInsertPortAfter.Visible = (ucGridToolStrip1.Visible && tsInsertAfter.Visible);

				tsEditPortCall.Visible = (ucGridToolStrip1.Visible && ucGridToolStrip1.IsEditVisible);
				tsDeletePortCall.Visible = (ucGridToolStrip1.Visible && ucGridToolStrip1.IsDeleteVisible);

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Error", ex);
			}
		}

		private void DefaultParms()
		{

			comboVessel.Value = null;
			cmbPort.Value = null;


			if( ARCMode )
				txtFromDt.Value = null;
			else
				txtFromDt.Value = DateTime.Today.AddDays(-14);

			txtToDt.Value = null;
			txtVoyage.Text = null;

			if( PortCalls != null ) { PortCalls.Clear(); grdVesselPortCalls.Refetch(); }
			if( BerthActivities != null ) { BerthActivities.Clear(); grdBerthActivity.Refetch(); }

			//grdVesselPortCalls.DataSource = null;
			//grdBerthActivity.DataSource = null;

		}

		private void GetVesselPortCalls()
		{
			try
			{
				PortCalls = ClsVesselPortCall.GetPortCallsByVessel(ClsScheduleType.Codes.LongTermSchedule, CurrentVessel, CurrentPort, txtFromDt.Value, txtToDt.Value, SearchTradeVoyage, ARCMode);
				grdVesselPortCalls.DataSource = PortCalls;

			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}

		private void GetBerthActivity()
		{
			if( CurrentPortCall == null )
			    return;
			BerthActivities = ClsVesselBerthActivity.DisplayBerthActivityList(CurrentPortCall);
			grdBerthActivity.DataSource = BerthActivities;
		}

		private void EditPortCall()
		{
			//try
			//{
			//    if( CurrentPortCall == null )
			//        return;

			//    string sCol;

			//    if( grdVesselPortCalls.CurrentColumn == null )
			//        sCol = null;
			//    else
			//        sCol = grdVesselPortCalls.CurrentColumn.Key;

			//    using( _frmEditVesselPortCall = new frmEditVesselPortCall() )
			//    {
			//        bool bResult = _frmEditVesselPortCall.Edit(CurrentPortCall, sCol, true);
			//        _frmEditVesselPortCall = null;
			//    }
			//    return;
			//}
			//catch( Exception ex )
			//{
			//    Display.ShowError("EditPortCall Method: " + ex.Message);
			//}
			//finally
			//{
			//    _frmEditVesselPortCall = null;
			//    GetVesselPortCalls();
			//}

		}
		private void AddPortCall(ClsVesselPortCall vpc1, ClsVesselPortCall vpc2, string sTypeCd)
		{
			////if (CurrentPortCall == null)
			////    return;
			////using (frmEditVesselPortCall frm = new frmEditVesselPortCall())
			////{
			////    ClsVesselPortCall vpc = frm.Add(vpc1, vpc2, sTypeCd);
			////    if (vpc == null)
			////    {
			////        return;
			////    }
			////    PortCalls.Add(vpc);
			////    SelectPortInGrid(vpc);
			////}
		}
		private void InsertAfter()
		{
			//AddPortCall(CurrentPortCall, NextPortCall, ClsPortCallType.Codes.RegularARCPortCall);
		}
		private void InsertBefore()
		{
			//AddPortCall(PrevPortCall, CurrentPortCall, ClsPortCallType.Codes.RegularARCPortCall);
		}
		protected void AddTransshipment()
		{
			//AddPortCall(CurrentPortCall, NextPortCall, ClsPortCallType.Codes.Transshipment);
		}
		private void SelectPortInGrid(ClsVesselPortCall vpc)
		{
			PortCalls.Sort(
				delegate(ClsVesselPortCall p1, ClsVesselPortCall p2)
				{ return p1.Arrive_Dt.Value.CompareTo(p2.Arrive_Dt); });

			grdVesselPortCalls.Refetch();
			int ix = 0;
			foreach( ClsVesselPortCall pc in PortCalls )
			{
				if( pc.Vessel_Port_Call_ID == vpc.Vessel_Port_Call_ID )
					grdVesselPortCalls.Row = ix;
				ix++;
			}
		}

		private void DeletePortCall()
		{
			if( CurrentPortCall == null )
				return;
			if( Display.Ask("Confirm", "Delete port {0}?", CurrentPortCall.Port.Port_Nm) == false )
				return;
			if( !CurrentPortCall.ValidateDelete() )
			{
				Display.Show("Error", CurrentPortCall.Error);
				return;
			}

			// Hold onto the previous port calls
			ClsVesselPortCall vpc = PrevPortCall;

			// Delete all port call and all berth activities
			//CurrentPortCall.DeleteAll();

			// Refresh port call grid
			GetVesselPortCalls();

			// Set the previous port call as the current
			if( vpc != null )
				SelectPortInGrid(vpc);
		}
		private void DeleteBerthActivity()
		{
			try
			{

				if (CurrentActivity == null)
					return;
				if (Display.Ask("Confirm", "Delete Activity {0}", CurrentActivity.Berth_Activity.Berth_Activity_Dsc) == false)
					return;
				foreach (ClsVesselMilitaryVoyage mv in CurrentActivity.MilitaryVoyageList)
				{
					ClsVesselMilitaryVoyage.DeleteRow(mv);
				}
				CurrentActivity.Delete();
				CurrentPortCall.BerthActivities = null;
				GetBerthActivity();
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}
		}
		private void EnterMilitaryVoyage()
		{
			if (CurrentActivity == null)
				return;
			using (frmEditVesselMilitaryVoyage frm = new frmEditVesselMilitaryVoyage())
			{
				if (frm.Edit(CurrentActivity))
				{
					GetBerthActivity();
				}
			}
		}
		private void EditBerthActivity()
		{
			if (CurrentActivity == null)
				return;
			using (frmEditVesselBerthActivity frm = new frmEditVesselBerthActivity())
			{
				if (frm.Edit(CurrentActivity))
				{
					GetBerthActivity();

					// Refresh vpcgrid
					CurrentPortCall.BerthActivities = null;
					string sVoy = CurrentPortCall.Voyages;
					grdVesselPortCalls.Refetch();
					grdVesselPortCalls.Refresh();
				}
			}

		}
		private void AddBerthActivity()
		{
			try
			{
				if (CurrentPortCall == null)
					return;
				using (frmEditVesselBerthActivity frm = new frmEditVesselBerthActivity())
				{
					ClsVesselBerthActivity ba = frm.Add(CurrentPortCall);
					if (ba != null)
					{
						if (CurrentPortCall.IsTransshipment)
							CopyMilitaryVoyages(ba);

						CurrentPortCall.BerthActivities = null;
						GetBerthActivity();

						// Refresh vpc grid
						CurrentPortCall.BerthActivities = null;
						string sVoy = CurrentPortCall.Voyages;
						grdVesselPortCalls.Refetch();
						grdVesselPortCalls.Refresh();

					}
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Error", ex);
			}

		}
		private void CopyMilitaryVoyages(ClsVesselBerthActivity bAct)
		{
			// Find the matching berth activity in the "linked" port call
			//foreach( ClsVesselBerthActivity ba in bAct.Vessel_Port_Call.Pf_Vessel_Port_Call.BerthActivities )
			//{
			//    if( ba.Berth_Activity_Cd == bAct.Berth_Activity_Cd )
			//    {
			//        // Having found the match; copy its military voyage info
			//        foreach( ClsVesselMilitaryVoyage mv in ba.MilitaryVoyageList )
			//        {
			//            ClsVesselMilitaryVoyage newMV = new ClsVesselMilitaryVoyage(mv);
			//            newMV.Vessel_Berth_Activity_ID = bAct.Vessel_Berth_Activity_ID;
			//            newMV.Insert();
			//        }
			//    }
			//}
		}

		private void AdjustDates()
		{
			//using( frmScheduleAdjustDates frm = new frmScheduleAdjustDates() )
			//{
			//    frm.EntryPoint(SelectedPortCalls);
			//    grdVesselPortCalls.Refetch();
			//}
		}
		private ClsVesselPortCall GetItem(GridEX grid, int iRow)
		{
			if( iRow < 0 )
				return null;
			if( iRow > grid.GetDataRows().Length - 1 )
				return null;
			ClsVesselPortCall vpc = new ClsVesselPortCall();
			GridEXRow r = grid.GetRow(iRow);
			if( r == null ) return null;

			DataTable dt = grid.DataSource as DataTable;
			if( dt == null ) return r.DataRow as ClsVesselPortCall;

			DataRowView drv = r.DataRow as DataRowView;
			if (drv == null) return null;

			vpc.LoadFromDataRow(drv.Row);
			return vpc;
		}

		private void CoastalScheduleReport()
		{

			//try
			//{

			//    using( frmEditText e = new frmEditText() )
			//    {
			//        e.CoastalScheduleEntryPoint(grdVesselPortCalls.SelectedItems);
			//    }

			//    //using( frmCoastalScheduleEmail e = new frmCoastalScheduleEmail() )
			//    //{
			//    //    e.EntryPoint(grdVesselPortCalls.SelectedItems);					
			//    //}
			//}
			//catch( Exception ex )
			//{
			//    ClsError.AddError(ex.Message);
			//}
			//finally
			//{
			//    if( ClsError.HasErrors ) Display.ShowError("Error", ClsError.ErrorMsg);
			//}
               
		}

		private void ARCView()
		{
			string sVoy = txtVoyage.Text;
			if (string.IsNullOrEmpty(sVoy))
			{
				sVoy = CurrentPortCall.BerthActivities[0].Trade_Lane_Cd +
					   CurrentPortCall.BerthActivities[0].Voyage_No;
			}
			frmUpdateMilitaryVoyage frm = new frmUpdateMilitaryVoyage();
			frm.MdiParent = this.MdiParent;
			frm.UpdateVoyage(sVoy);
		}

        public void ChangeArcVessels()
        {
            try
            {
                comboVessel.ShowOnlyARCVessels = chkARC.Checked;
                comboVessel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem switching between ARC/Non-Arc Vessels. Err=" + ex.Message);
            }
        }

		private void UpdatePublishLoadFlag()
		{
			//CurrentPortCall.Publish_Load_Flg = (CurrentPortCall.Publish_Load_Flg == "Y") ? "N" : "Y";
			//CurrentPortCall.Update();
		}

		private void UpdatePublishDischargeFlag()
		{
			//CurrentPortCall.Publish_Discharge_Flg = (CurrentPortCall.Publish_Discharge_Flg == "Y") ? "N" : "Y";
			//CurrentPortCall.Update();
		}

        #endregion
		
        #region Events
		private void frmUpdateVessel_Load(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			GetVesselPortCalls();
		}

		private void grdVesselPortCalls_SelectionChanged(object sender, EventArgs e)
		{
			GetBerthActivity();
		}

		private void ucGridToolStrip1_ClickEdit(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip1.Visible || !ucGridToolStrip1.IsEditVisible ) return;

				EditPortCall();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ucGridToolStrip1_ClickAdd(object sender, EventArgs e)
		{
			//AddPortCall();
		}

		private void ucGridToolStrip1_ClickDelete(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip1.Visible || !ucGridToolStrip1.IsDeleteVisible ) return;

				DeletePortCall();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ucGridToolStrip2_ClickEdit(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip2.Visible || !ucGridToolStrip2.IsEditVisible ) return;

				EditBerthActivity();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ucGridToolStrip2_ClickAdd(object sender, EventArgs e)
		{
			AddBerthActivity();
		}

		private void ucGridToolStrip2_ClickDelete(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip2.Visible || !ucGridToolStrip2.IsDeleteVisible ) return;

				DeleteBerthActivity();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			DefaultParms();
		}

		private void grdVesselPortCalls_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip1.Visible || !ucGridToolStrip1.IsEditVisible ) return;

				EditPortCall();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void grdBerthActivity_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if( !ucGridToolStrip2.Visible || !ucGridToolStrip2.IsEditVisible ) return;

				EditBerthActivity();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void tsAdjustDates_Click(object sender, EventArgs e)
		{
			AdjustDates();
		}

		private void tsInsertAfter_Click(object sender, EventArgs e)
		{
			InsertAfter();
		}

		private void tsInsertBefore_Click(object sender, EventArgs e)
		{
			InsertBefore();
		}

		private void tsEditPortCall_Click(object sender, EventArgs e)
		{
			EditPortCall();
		}

		private void tsDeletePortCall_Click(object sender, EventArgs e)
		{
			DeletePortCall();
		}

		private void tsInsertPortBefore_Click(object sender, EventArgs e)
		{
			InsertBefore();
		}

		private void tsInsertPortAfter_Click(object sender, EventArgs e)
		{
			InsertAfter();
		}

		private void tsCoastalScheduleReport_Click(object sender, EventArgs e)
		{
			CoastalScheduleReport();
		}
		private void tsEnterMilitaryVoyage_Click(object sender, EventArgs e)
		{
			EnterMilitaryVoyage();
		}

		private void tsAddTransShipment_Click(object sender, EventArgs e)
		{
			AddTransshipment();
		}

		private void tsARCView_Click(object sender, EventArgs e)
		{
			ARCView();
		}

		private void grdVesselPortCalls_CellValueChanged(object sender, ColumnActionEventArgs e)
		{
			switch (e.Column.Key)
			{
				case "publish_load_flg":
					UpdatePublishLoadFlag();
					break;
				case "publish_discharge_flg":
					UpdatePublishDischargeFlag();
					break;
			}
		}

     #endregion

        private void chkARC_CheckedChanged(object sender, EventArgs e)
        {
            ChangeArcVessels();
        }

        private void grdVesselPortCalls_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }




	}
}
