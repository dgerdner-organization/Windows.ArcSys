using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.AVSS.Business;
using CS2010.CommonSecurity;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using Janus.Windows.GridEX;
using CS2010.AVSS.Win;

namespace CS2010.AVSS.Win
{
    public partial class frmEditVesselMilitaryVoyage : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

		private ClsVesselBerthActivity theActivity;
		private List<ClsVesselMilitaryVoyage> theMilitaryVoyages;

        #endregion

        #region Constructors
		public frmEditVesselMilitaryVoyage()
        {
            InitializeComponent();
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        #endregion

        #region Public Methods

        
        public bool Edit(ClsVesselBerthActivity aActivity)
        {
            try
            {
                CurrentMode = DialogMode.Edit;

                theActivity = new ClsVesselBerthActivity(aActivity);

                if (ShowDialog() != DialogResult.OK) return false;

                aActivity.CopyFrom(theActivity);
                return true;
            }
            catch (Exception ex)
            {
                //return Program.ShowError(ex);
				Display.ShowError("Error", ex);
				return false;
            }
        }
        #endregion

        #region Overrides

        protected override bool CheckChanges()
        {
            try
            {
                bool ok = (CurrentMode == DialogMode.Add)
                    ? theActivity.ValidateInsert() : theActivity.ValidateUpdate();

                return (ok) ? true : Display.ShowError(theActivity.Error);
            }
            catch (Exception ex)
            {
                return Display.ShowError(ex);
            }
        }

        protected override bool SaveChanges()
        {
            try
            {
                if (CurrentMode == DialogMode.Add)
                    theActivity.Insert();
                else
                    theActivity.Update();

                return true;
            }
            catch (Exception ex)
            {
                return Display.ShowError(ex);
            }
        }
        #endregion

		#region Private Methods
		private void FormLoad()
        {
            try
            {
				RefreshWindow();
            }
            catch (Exception ex)
            {
                Display.ShowError(ex);
            }
        }

		private void RefreshWindow()
		{
			txtVoyage.Text = theActivity.Full_Voyage_No;
			txtActivity.Text = theActivity.Berth_Activity.Berth_Activity_Dsc;
			txtPort.Text = theActivity.Vessel_Port_Call.Port.Port_Nm + " / " +
							theActivity.Vessel_Port_Call.Berth.Berth_Nm;

			theMilitaryVoyages = ClsVesselMilitaryVoyage.GetForBerthActivity(theActivity.Vessel_Berth_Activity_ID);
			grdMilitaryVoyages.DataSource = theMilitaryVoyages;
			cmbMilVoy.DataSource = ClsMilitaryVoyage.GetForVoyage(theActivity.Trade_Lane_Cd, theActivity.Voyage_No);
		}

		private void RemoveVoyage()
		{
			try
			{
				ClsVesselMilitaryVoyage mv = grdMilitaryVoyages.GetCurrentItem<ClsVesselMilitaryVoyage>();
				if( mv != null )
				{
					ClsVesselMilitaryVoyage.DeleteRow(mv);
					RefreshWindow();
				}
			}
			catch( Exception ex )
			{
				Display.ShowError(ex);
			}
		}
		private void AddVoyage()
		{
			try
			{
				string sMilVoy = cmbMilVoy.SelectedValue.ToString();
				ClsVesselMilitaryVoyage mv = new ClsVesselMilitaryVoyage();
				mv.Vessel_Berth_Activity_ID = theActivity.Vessel_Berth_Activity_ID;
				mv.Military_Voyage_No = sMilVoy;
				mv.Insert();
				RefreshWindow();
			}
			////catch( OracleException ex )
			////{
			////    if( ex.Message.Contains("unique constraint") )
			////    {
			////        // Ignore if it's a dupe
			////        Program.Show("Military Voyage already assigned");
			////        return;
			////    }
			////    throw ex as Exception;
			////}
			catch( Exception ex )
			{
				Display.ShowError(ex);
			}
		}
		private void AddAll()
		{
			try
			{
				int lx = 0;
				while( lx < cmbMilVoy.Items.Count )
				{
					cmbMilVoy.SelectedIndex = lx;
					AddVoyage();
					lx++;
				}
			}

			catch( Exception ex )
			{
				Display.ShowError(ex);
			}
		}

		#endregion

		#region Events
		private void frmEditActivity_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

		private void grdMilitaryVoyages_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			RemoveVoyage();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AddVoyage();
		}
		private void btnAddAll_Click(object sender, EventArgs e)
		{
			AddAll();
		}
		#endregion


	}
}
