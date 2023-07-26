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
using CS2010.ArcSys.Win;

namespace CS2010.ArcSys.Win
{
    public partial class frmEditVessel : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

        private ClsVessel theVessel;

        #endregion

        #region Constructors
        public frmEditVessel()
        {
            InitializeComponent();
            //ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        #endregion
        #region Public Methods

        public ClsVessel Add()
        {
            try
            {
                CurrentMode = DialogMode.Add;

                theVessel = new ClsVessel();
                theVessel.SetDefaults();

                return (ShowDialog() == DialogResult.OK) ? theVessel : null;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        public bool Edit(ClsVessel aVessel)
        {
            try
            {
                CurrentMode = DialogMode.Edit;

                theVessel = new ClsVessel(aVessel);

                if (ShowDialog() != DialogResult.OK) return false;

                aVessel.CopyFrom(theVessel);
                return true;
            }
            catch (Exception ex)
            {
                return Program.ShowError(ex);
            }
        }
        #endregion

        #region Overrides

        protected override bool CheckChanges()
        {
            try
            {
                bool ok = (CurrentMode == DialogMode.Add)
                    ? theVessel.ValidateInsert() : theVessel.ValidateUpdate();

                return (ok) ? true : Program.ShowError(theVessel.Error);
            }
            catch (Exception ex)
            {
                return Program.ShowError(ex);
            }
        }

        protected override bool SaveChanges()
        {
            try
            {
                if (CurrentMode == DialogMode.Add)
                    theVessel.Insert();
                else
                    theVessel.Update();

                return true;
            }
            catch (Exception ex)
            {
                return Program.ShowError(ex);
            }
        }
        #endregion

        private void VesselFormLoad()
        {
            try
            {

                txtVesselCd.MaxLength = ClsVessel.Vessel_CdMax;
                txtIRCSCode.MaxLength = ClsVessel.Ircs_CdMax;
                txtVesselName.MaxLength = ClsVessel.Vessel_NmMax;

                BindHelper.Bind(txtVesselCd, theVessel, "Vessel_Cd");
                BindHelper.Bind(txtIRCSCode, theVessel, "Ircs_Cd");
                BindHelper.Bind(txtVesselName, theVessel, "Vessel_Nm");
				BindHelper.Bind(ucArcVessel, theVessel, "Arc_Flg");
			
                txtVesselCd.ReadOnly = (CurrentMode == DialogMode.Edit);

                Text = string.Format("{0} Vessel", CurrentMode.ToString());
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void frmEditVessel_Load(object sender, EventArgs e)
        {
            VesselFormLoad();
        }
    }
}
