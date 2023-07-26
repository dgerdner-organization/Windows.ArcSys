using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CS2010.CommonWinCtrls;
using System.Data;
using CS2010.ArcSys.Business;
using CS2010.Common;

namespace CS2010.ArcSys.WinCtrls
{
    public partial class ucLobHeader : ucComboBoxBase
    {
        public ucLobHeader()
        {
            InitializeComponent();

            if( ClsEnvironment.IsDesignMode == true ) return;
            DataTable dt = ClsLobHeader.GetAll();
            AddDataTable(dt, "VERSION_NO", "LOB_HEADER_ID");
        }

        public ucLobHeader(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public DataRow CurrentRow()
        {
            DataRowView drv = (DataRowView)this.SelectedItem;
            return drv.Row;
        }

        public ClsLobHeader CurrentLobHeader()
        {
            DataRow dr = CurrentRow();
            return new ClsLobHeader(dr);
        }

    }
}
