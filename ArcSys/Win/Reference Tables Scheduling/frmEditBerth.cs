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
//using CS2010.Framework.Alpha;

namespace CS2010.ArcSys.Win
{
    public partial class frmEditBerth : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

        private ClsBerth theItem;

        #endregion

        #region Constructors
        public frmEditBerth()
        {
            InitializeComponent();
            //ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        private void FormLoad()
        {
            try
            {

                txtBerthCd.MaxLength = ClsBerth.Berth_CdMax;
                txtBerthName.MaxLength = ClsBerth.Berth_NmMax;
				txtMilitaryCode.MaxLength = ClsBerth.Military_CdMax;
				txtWebBerthDisplay.MaxLength = ClsBerth.Berth_Web_DisplayMax;

                BindHelper.Bind(txtBerthCd, theItem, "Berth_Cd");
                BindHelper.Bind(txtBerthName, theItem, "Berth_Nm");
                BindHelper.Bind(cmbPort, theItem, "Port_Cd");
                BindHelper.Bind(cbxMilitaryFlg, theItem, "Military_Flg");
				BindHelper.Bind(chkInducement, theItem, "Inducement_Flg");
				BindHelper.Bind(txtMilitaryCode, theItem, "Military_Cd");
				BindHelper.Bind(txtWebBerthDisplay, theItem, "Berth_Web_Display");
                cmbEndTime.DataBindings.Add("Value", theItem, "Work_Hours_End", true, DataSourceUpdateMode.OnPropertyChanged);
                cmbStartTime.DataBindings.Add("Value", theItem, "Work_Hours_Start", true, DataSourceUpdateMode.OnPropertyChanged);
                txtBerthCd.ReadOnly = (CurrentMode == DialogMode.Edit);
                Text = string.Format("{0} Berth", CurrentMode.ToString());
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion

        #region Public Methods

        public ClsBerth Add()
        {
            try
            {
                CurrentMode = DialogMode.Add;

                theItem = new ClsBerth();
                theItem.SetDefaults();
                theItem.Military_Flg = "N";

                return (ShowDialog() == DialogResult.OK) ? theItem : null;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return null;
            }
        }

        public bool Edit(ClsBerth aBerth)
        {
            try
            {
                CurrentMode = DialogMode.Edit;

                theItem = new ClsBerth(aBerth);

                if (ShowDialog() != DialogResult.OK) return false;

                aBerth.CopyFrom(theItem);
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
                    theItem.Insert();
                else
                    theItem.Update();

                return true;
            }
            catch (Exception ex)
            {
                return Program.ShowError(ex);
            }
        }
        #endregion

        #region Events

        private void frmEditBerth_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void cbxMilitaryFlg_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
