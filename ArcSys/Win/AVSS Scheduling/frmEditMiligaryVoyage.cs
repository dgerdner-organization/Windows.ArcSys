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
    public partial class frmEditMilitaryVoyage : CS2010.CommonWinCtrls.frmDialogBase
    {
        #region Fields

		private ClsMilitaryVoyage theMilitaryVoyage;

        #endregion

        #region Constructors
        public frmEditMilitaryVoyage()
        {
            InitializeComponent();
            //ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }
        #endregion

        #region Public Methods

		public ClsMilitaryVoyage Add()
		{
			return Add(null, null);
		}
        public ClsMilitaryVoyage Add(string sTradeLane, string sVoyageNo)
        {
            try
            {
                CurrentMode = DialogMode.Add;

                theMilitaryVoyage = new ClsMilitaryVoyage();
                theMilitaryVoyage.SetDefaults();
				theMilitaryVoyage.Voyage_No = sVoyageNo;
				theMilitaryVoyage.Trade_Lane_Cd = sTradeLane;
                return (ShowDialog() == DialogResult.OK) ? theMilitaryVoyage : null;
            }
            catch (Exception ex)
            {
				Display.ShowError(ex);
                return null;
            }
        }

        public bool Edit(ClsMilitaryVoyage aMilitaryVoyage)
        {
            try
            {
                CurrentMode = DialogMode.Edit;

                theMilitaryVoyage = new ClsMilitaryVoyage(aMilitaryVoyage);

                if (ShowDialog() != DialogResult.OK) return false;

                aMilitaryVoyage.CopyFrom(theMilitaryVoyage);
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
                    ? theMilitaryVoyage.ValidateInsert() : theMilitaryVoyage.ValidateUpdate();

                return (ok) ? true : Display.ShowError(theMilitaryVoyage.Error);
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
                    theMilitaryVoyage.Insert();
                else
                    theMilitaryVoyage.Update();

                return true;
            }
            catch (Exception ex)
            {
				return Display.ShowError(ex);
            }
        }
        #endregion

        private void FormLoad()
        {
            try
            {

				BindHelper.Bind(txtMilVoy, theMilitaryVoyage, "Military_Voyage_No");
				BindHelper.Bind(cmbTradeLane, theMilitaryVoyage, "Trade_Lane_Cd");
				BindHelper.Bind(txtVoyageNo, theMilitaryVoyage, "Voyage_No");
				BindHelper.Bind(txtSuffix, theMilitaryVoyage, "Suffix");

				txtMilVoy.ReadOnly = 
				cmbTradeLane.ReadOnly = 
				txtVoyageNo.ReadOnly = (CurrentMode == DialogMode.Edit);
			
			}
            catch (Exception ex)
            {
                Display.ShowError(ex);
            }
        }

        private void frmEditMilitaryVoyage_Load(object sender, EventArgs e)
        {
            FormLoad();
        }
    }
}
