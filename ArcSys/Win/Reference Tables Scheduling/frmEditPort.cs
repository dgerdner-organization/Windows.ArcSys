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
//using CS2010.Framework.Alpha;

namespace CS2010.ArcSys.Win
{
    public partial class frmEditPort : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

        private ClsPort theItem;
		private CS2010.ACMS.Business.ClsLocation theACMSItem;
		private ArcSys.Business.ClsAction theARCItem;

        #endregion

        #region Constructors
        public frmEditPort()
        {
            InitializeComponent();
            //ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        private void FormLoad()
        {
            try
            {

                txtPortCd.MaxLength = ClsPort.Port_CdMax;
                txtCensusCode.MaxLength = ClsPort.Census_CdMax;
                txtPortName.MaxLength = ClsPort.Port_NmMax;

                BindHelper.Bind(txtPortCd, theItem, "Port_Cd");
                BindHelper.Bind(txtPortName, theItem, "Port_Nm");
                BindHelper.Bind(txtCensusCode, theItem, "Census_Cd");
                BindHelper.Bind(txtOffset, theItem, "Time_Offset");
                BindHelper.Bind(txtType, theItem, "Census_Type");
                txtPortCd.ReadOnly = (CurrentMode == DialogMode.Edit);
                Text = string.Format("{0} Port", CurrentMode.ToString());

				// ACMS
				theACMSItem = CS2010.ACMS.Business.ClsLocation.GetUsingKey(theItem.Port_Cd);
				if (theACMSItem == null)
				{
					theACMSItem = new CS2010.ACMS.Business.ClsLocation();
					theACMSItem.Location_Cd = theItem.Port_Cd;
					theACMSItem.Location_Cd = theItem.Port_Nm;
					theACMSItem.Delete_Fl = "N";
					theACMSItem.Insert();
				}
				BindHelper.Bind(txtCity, theACMSItem, "City");
				BindHelper.Bind(txtState, theACMSItem, "State_Cd");
				BindHelper.Bind(txtMilStamp, theACMSItem, "Other1_Cd");
				BindHelper.Bind(txtCountry, theACMSItem, "Country_Cd");
				BindHelper.Bind(cbxDeleted, theACMSItem, "Delete_Fl");
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Public Methods

        public ClsPort Add()
        {
            try
            {
                CurrentMode = DialogMode.Add;

                theItem = new ClsPort();
                theItem.SetDefaults();
                theItem.Census_Type = "D";
                theItem.Time_Offset = 0;

                return (ShowDialog() == DialogResult.OK) ? theItem : null;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        public bool Edit(ClsPort aPort)
        {
            try
            {
                CurrentMode = DialogMode.Edit;

                theItem = new ClsPort(aPort);

                if (ShowDialog() != DialogResult.OK) return false;

                aPort.CopyFrom(theItem);
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
                ClsError.ResetAll();
                bool ok = (CurrentMode == DialogMode.Add)
                    ? theItem.ValidateInsert() : theItem.ValidateUpdate();

                return (ok) ? true : Program.ShowError(ClsError.ErrorMsg);
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
				{
					theItem.Insert();
				}
				else
				{
					theItem.Update();
					theACMSItem.Census_Type = theItem.Census_Type;
					theACMSItem.Census_Cd = theItem.Census_Cd;
					theACMSItem.Update();
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
        private void frmEditPort_Load(object sender, EventArgs e)
        {
            FormLoad();
        }
        #endregion
    }
}
