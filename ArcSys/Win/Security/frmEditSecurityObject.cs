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
    public partial class frmEditSecurityObject : CS2010.CommonWinCtrls.frmDialogBase
    {
        public frmEditSecurityObject()
        {
            InitializeComponent();
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        private ClsSecurityObject theItem;

        public bool EditSecurityObject(ClsSecurityObject security)
        {
            theItem = security;
            BindData();
            if (ShowDialog() != DialogResult.OK) return false;

            security.CopyFrom(theItem);
            return true;
        }

        public ClsSecurityObject AddSecurityObject()
        {

            theItem = new ClsSecurityObject();
            BindData();
            theItem.Default_Visible_Flg = "N";
            theItem.Default_Enabled_Flg = "N";
            theItem.Vendor_Control_Flg = "N";
            theItem.Finance_Flg = "N";

            DialogResult dr = ShowDialog();
            if (dr == DialogResult.Cancel)
                return null;

            return theItem;
        }

        private void BindData()
        {
            BindHelper.Bind(txtObjectNm, theItem, "Object_Nm");
            BindHelper.Bind(txtObjectDsc, theItem, "Object_Dsc");
            BindHelper.Bind(txtParentNm, theItem, "Parent_Nm");
            BindHelper.Bind(txtParentDsc, theItem, "Parent_Dsc");
            BindHelper.Bind(txtCollectionDsc, theItem, "Collection_Dsc");

            BindHelper.Bind(cbxEnabled, theItem, "default_enabled_flg");
            BindHelper.Bind(cbxVisible, theItem, "default_visible_flg");
            BindHelper.Bind(cbxFinanceFlg, theItem, "Finance_Flg");
            BindHelper.Bind(cbxVendorFlg, theItem, "Vendor_Control_Flg");

            txtObjectNm.CharacterCasing = CharacterCasing.Normal;
            txtObjectDsc.CharacterCasing = CharacterCasing.Normal;
            txtParentNm.CharacterCasing = CharacterCasing.Normal;
            txtParentDsc.CharacterCasing = CharacterCasing.Normal;
            txtCollectionDsc.CharacterCasing = CharacterCasing.Normal;
        }
    }
}

