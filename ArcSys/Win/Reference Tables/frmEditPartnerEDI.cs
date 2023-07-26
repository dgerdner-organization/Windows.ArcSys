using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmEditPartnerEDI : frmChildBase 
    {
        private DataTable dtMain;

        public frmEditPartnerEDI() 
        {
            InitializeComponent();
            GetData();
        }

        protected void GetData()
        {
            dtMain = ClsTradingPartnerEdi.GetAll();
            grdMain.DataSource = dtMain;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grdMain.UpdateData();
                foreach (DataRow drow in grdMain.GetDataRowList())
                {
                    // Get the object from the grid
                    ClsTradingPartnerEdi c = new ClsTradingPartnerEdi(drow);

                    // See if it exists in the database
                    ClsTradingPartnerEdi x = ClsTradingPartnerEdi.GetUsingKey(c.Trading_Partner_Edi_ID.GetValueOrDefault());

                    // If it does exist, just update it
                    if (x != null)
                    {
                        c.Update();
                        GetData();
                        continue;
                    }

                    // If it does not exist, insert it
                    c.Insert();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dNew = dtMain.NewRow();
            dtMain.Rows.Add(dNew);
        }

        private void grdMain_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (MessageBox.Show("Delete this item?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                object obj = grdMain.GetValue("trading_partner_edi_id");
                Int64 id = ClsConvert.ToInt64(obj);
                ClsTradingPartnerEdi c = ClsTradingPartnerEdi.GetUsingKey(id);
                c.Delete();
                GetData();
            }
        }

        private void grdMain_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }
    }
}
