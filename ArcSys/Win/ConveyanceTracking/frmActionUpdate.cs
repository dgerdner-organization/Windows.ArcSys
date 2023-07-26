using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmActionUpdate : frmDialogBase
    {
        #region Properties

        private TRACKING_ACTIONS _action; 

        public ClsLocation SelectedLocation 
        {
            get { return cmbLocation.SelectedLocation; }  
        }

        public DateTime SelectedActionDt 
        {
            get { return (DateTime)dtDate.Value; }  
        }

        public string SelectedTagNo
        {
            get { return txtTag.Text; }
        }

        #endregion

        #region Init

        public frmActionUpdate()
        {
            InitializeComponent();
            dtDate.MaxDate = DateTime.Now.AddDays(1);
        }        

        #endregion

        #region Public Methods

        public void ShowDepartOrigin()
        {
            try
            {
                this.Text = "Depart from Origin ...";
                cmbLocation.Visible = txtTag.Visible = false;
                _action = TRACKING_ACTIONS.CONVEYANCE_DEPART_ORIGIN;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowArrive(bool ConusFlg)
        {
            try
            {
                this.Text = "Arrive ...";
                cmbLocation.Visible = true;
                txtTag.Visible = false;
                _action = TRACKING_ACTIONS.CONVEYANCE_ARRIVE;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowDepart()
        {
            try
            {
                this.Text = "Depart ...";
                cmbLocation.Visible = txtTag.Visible = false;
                _action = TRACKING_ACTIONS.CONVEYANCE_DEPART;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowInGate()
        {
            try
            {
                this.Text = "In Gate ...";
                cmbLocation.Visible = txtTag.Visible = false;
                _action = TRACKING_ACTIONS.CARGO_IN_GATE;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowStampOfDelivery()
        {
            try
            {
                this.Text = "Proof of Delivery ...";
                cmbLocation.Visible = txtTag.Visible = false;
                _action = TRACKING_ACTIONS.CARGO_STAMP_OF_DELIVERY;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowCommissionTag()
        {
            try
            {
                this.Text = "Commission EITV Tag ...";
                cmbLocation.Visible = false;
                txtTag.Visible = true;
                txtTag.Left = cmbLocation.Left;
                txtTag.Top = cmbLocation.Top;
                txtTag.Text = string.Empty;
                _action = TRACKING_ACTIONS.CARGO_COMMISSION_TAG;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        public void ShowDeCommissionTag()
        {
            try
            {
                this.Text = "De-Commission EITV Tag ...";
                cmbLocation.Visible = false;
                txtTag.Visible = false;

                _action = TRACKING_ACTIONS.CARGO_DECOMMISSION_TAG;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Overrides

        protected override bool CheckChanges()
        {
            if (_action == TRACKING_ACTIONS.CONVEYANCE_ARRIVE)
            {
                if (cmbLocation.SelectedLocationCD.IsNull())
                {
                    MessageBox.Show("Please select a Location.");
                    return false;
                }
            }

            if (_action == TRACKING_ACTIONS.CARGO_COMMISSION_TAG)
            {
                if (txtTag.Text.IsNull())
                {
                    MessageBox.Show("Please enter a EITV Tag number.");
                    return false;
                }
            }

            if (dtDate.Value == null)
            {
                MessageBox.Show("Please enter a Date.");
                return false;
            }

            return base.CheckChanges();
        }        

        #endregion

    }
}
