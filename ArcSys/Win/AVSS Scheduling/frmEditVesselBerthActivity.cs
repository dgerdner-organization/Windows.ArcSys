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

namespace CS2010.AVSS.Win
{
    public partial class frmEditVesselBerthActivity : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

		private ClsVesselBerthActivity theActivity;

        #endregion

        #region Constructors
		public frmEditVesselBerthActivity()
        {
            InitializeComponent();
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        #endregion

        #region Public Methods

        public ClsVesselBerthActivity Add(ClsVesselPortCall pc)
        {
            try
            {
                CurrentMode = DialogMode.Add;

                theActivity = new ClsVesselBerthActivity();
                theActivity.SetDefaults();
				theActivity.Vessel_Port_Call_ID = pc.Vessel_Port_Call_ID;


                return (ShowDialog() == DialogResult.OK) ? theActivity : null;
            }
            catch (Exception ex)
            {
                Display.ShowError(ex);
                return null;
            }
        }

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
				return Display.ShowError(ex);
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

		#region Methods
		private void FormLoad()
        {
            try
            {
				comboActivity.DataSource = ClsBerthActivity.GetAll(true);
				BindHelper.Bind(comboActivity, theActivity, "Berth_Activity_Cd");
				BindHelper.Bind(comboTradeLane, theActivity, "Trade_Lane_Cd");
				BindHelper.Bind(txtVoyageNo, theActivity, "Voyage_No");
            }
            catch (Exception ex)
            {
                Display.ShowError(ex);
            }
		}

		private void DefaultVoyageInfo()
		{
			if (theActivity.Vessel_Port_Call.IsTransshipment)
			{
				foreach(ClsVesselBerthActivity ba in theActivity.Vessel_Port_Call.Pf_Vessel_Port_Call.BerthActivities)
				{
					if( ba.Berth_Activity_Cd == comboActivity.SelectedValue.ToString() )
					{
						theActivity.Trade_Lane_Cd = ba.Trade_Lane_Cd;
						txtVoyageNo.Text = ba.Voyage_No;
					}
				}
			}

		}

		#endregion

		#region Events
		private void frmEditActivity_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

		private void comboActivity_Validated(object sender, EventArgs e)
		{
			DefaultVoyageInfo();
		}
		#endregion
	}
}
