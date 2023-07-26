using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonSecurity;
using CS2010.Common;
using CS2010.CommonWinCtrls;

namespace CS2010.ArcSys.Win
{
    public partial class frmGetSecurity : CS2010.CommonWinCtrls.frmDialogBase
    {
        public frmGetSecurity()
        {
            InitializeComponent();
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        private ClsSecurity theItem;

        public bool EditSecurityInfo(ClsSecurity security)
        {
            theItem = security;
            BindData();
            if (ShowDialog() != DialogResult.OK) return false;

            security.CopyFrom(theItem);
            return true;
        }

        public ClsSecurity AddSecurityInfo()
        {

            theItem = new ClsSecurity();
            BindData();
            theItem.Visible_Flg = "N";
            theItem.Enabled_Flg = "N";
            theItem.Application_ID = 1;

            DialogResult dr = ShowDialog();
            if (dr == DialogResult.Cancel)
                return null;

            return theItem;
        }

        private void BindData()
        {
            comboObject.DataSource = ClsSecurityObject.GetAll();
            comboGroup.DataSource = ClsSecurityGroup.GetAll();

            BindHelper.Bind(comboGroup, theItem, "group_id");
            BindHelper.Bind(comboObject, theItem, "object_id");
            BindHelper.Bind(cbxEnabled, theItem, "enabled_flg");
            BindHelper.Bind(cbxVisible, theItem, "visible_flg");
        }
    }
}

