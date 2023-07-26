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
    public partial class frmEditGroup : CS2010.CommonWinCtrls.frmDialogBase
    {
        public frmEditGroup()
        {
            InitializeComponent();
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        private ClsSecurityGroup theItem;

        public bool EditGroup(ClsSecurityGroup group)
        {
            theItem = group;
            BindData();
            if (ShowDialog() != DialogResult.OK) return false;

            group.CopyFrom(theItem);
            return true;
        }

        public ClsSecurityGroup AddGroup()
        {

            theItem = new ClsSecurityGroup();
            BindData();

            DialogResult dr = ShowDialog();
            if (dr == DialogResult.Cancel)
                return null;

            return theItem;
        }

        private void BindData()
        {
            BindHelper.Bind(txtDsc, theItem, "Group_Dsc");
        }

    }
}

