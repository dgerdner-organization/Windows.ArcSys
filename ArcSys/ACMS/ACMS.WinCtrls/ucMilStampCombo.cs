using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using System.Data;
using CS2010.ACMS.Business;

namespace CS2010.ACMS.WinCtrls
{
    public partial class ucMilStampCombo : ucComboBoxBase
    {
        public ucMilStampCombo()
        {
            InitializeComponent();

            if( ClsEnvironment.IsDesignMode == true ) return;
            DataTable dt = ClsLocation.GetValidMilStampCodes();
            AddDataTable(dt, "OTHER1_CD", "OTHER1_CD");
        }

        public ucMilStampCombo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public DataRow CurrentRow()
        {
            DataRowView drv = (DataRowView)this.SelectedItem;
            return drv.Row;
        }

        public ClsLocation CurrentLobHeader()
        {
            DataRow dr = CurrentRow();
            return new ClsLocation(dr);
        }

    }
}
