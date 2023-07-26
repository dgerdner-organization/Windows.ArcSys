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
    public partial class frmGetUserGroup : CS2010.CommonWinCtrls.frmDialogBase
    {
        public frmGetUserGroup()
        {
            InitializeComponent();
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        private ClsUserGroup theItem;

        public bool Edit(ClsUserGroup ug)
        {
            theItem = ug;
            BindData();
            if (ShowDialog() != DialogResult.OK) return false;

            ug.CopyFrom(theItem);
            return true;
        }

        public ClsUserGroup Add()
        {

            theItem = new ClsUserGroup();
            BindData();
            DialogResult dr = ShowDialog();
            if (dr == DialogResult.Cancel)
                return null;

            return theItem;
        }

        private void BindData()
        {
            comboUser.DataSource = ClsSecurityUser.GetAll();
            comboGroup.DataSource = ClsSecurityGroup.GetAll();

            BindHelper.Bind(comboGroup, theItem, "group_id");
            BindHelper.Bind(comboUser, theItem, "user_id");
        }
    }
}

