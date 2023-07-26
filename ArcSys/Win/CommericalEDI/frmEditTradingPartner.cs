using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmEditTradingPartner : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmEditTradingPartner()
		{
			InitializeComponent();
		}
		private DataTable dtPartners;
		private DataTable dtCustomers;
        private List<ClsTradingPartnerEdi> listPartnerEDI;
        private List<ClsConfiguration> listConfiguration;
		private DataTable dtUserPartners;
        int iUpdates;
        int iInserts;

		private ClsTradingPartner currentTradingPartner
		{
			get
			{
				if (grdPartners.Row < 0)
					return null;
				DataRow dr = grdPartners.GetDataRow();
				if (dr == null)
					return null;
				ClsTradingPartner tp = new ClsTradingPartner(dr);
				return tp;
			}
		}
		public void ShowForm()
		{
			Refresh();
			RefreshData();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
		}
		private void RefreshData()
		{
			dtPartners = ClsTradingPartner.GetAll();
			grdPartners.DataSource = dtPartners;

			dtUserPartners = ClsTradingPartner.GetUserPartnersAll();
			grdUserPartners.DataSource = dtUserPartners;

            listPartnerEDI = ClsTradingPartnerEdi.GetAllList();
            grdEDIConfigure.DataSource = listPartnerEDI;

            listConfiguration = new List<ClsConfiguration>();
            DataTable dt1 = ClsConfiguration.GetAll();
            foreach (DataRow drow in dt1.Rows)
            {
                ClsConfiguration c = new ClsConfiguration(drow);
                listConfiguration.Add(c);
            }
            grdConfig.DataSource = listConfiguration;
		}

		private void RefreshCustomers()
		{
			dtCustomers = ClsCommercialEDIQueries.TradingPartnerCustomers(currentTradingPartner.Trading_Partner_Cd);
			grdCustomers.DataSource = dtCustomers;

			//dtEDIConfig = ClsCommercialEDIQueries.TradingPartnerEdiConfig(currentTradingPartner.Trading_Partner_Cd);
		}

		private void grdPartners_SelectionChanged(object sender, EventArgs e)
		{
			RefreshCustomers();
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPartnerEDI();
        }

        private void AddPartnerEDI()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePartnerEDI();
        }
        private void SavePartnerEDI()
        {
            iUpdates = iInserts = 0;
            List<ClsTradingPartnerEdi> lst = grdEDIConfigure.GetObjectList<ClsTradingPartnerEdi>();
            foreach (ClsTradingPartnerEdi edi in lst)
            {
                ClsTradingPartnerEdi x = ClsTradingPartnerEdi.GetUsingKey(edi.Trading_Partner_Edi_ID.GetValueOrDefault());
                // If it does exist, just update it
                if (x != null)
                {
                    if (!edi.Equals(x))
                    {
                        edi.Update();
                        iUpdates++;
                        continue;
                    }
                }

                // If it does not exist, insert it
                edi.Insert();
                iInserts++;
            }
            PostUpdate();
        }

        private void PostUpdate()
        {
            string sMessage = string.Format(@"{0} items were added, and {1} items were updteded.", iInserts, iUpdates);
            if (iUpdates + iInserts == 0)
            {
                sMessage = "Nothing to update";
            }
            Program.Show(sMessage);
            RefreshData();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            ClsConfiguration a = new ClsConfiguration();
            listConfiguration.Add(a);
            grdConfig.Refetch();

        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            iUpdates = iInserts = 0;
            List<ClsConfiguration> lst = grdConfig.GetObjectList<ClsConfiguration>();
            foreach (ClsConfiguration edi in lst)
            {
                ClsConfiguration x = ClsConfiguration.GetUsingKey(edi.Config_ID.GetValueOrDefault());
                // If it does exist, just update it
                if (x != null)
                {
                    if (!edi.Equals(x))
                    {
                        edi.Update();
                        iUpdates++;
                        continue;
                    }
                }

                // If it does not exist, insert it
                edi.Insert();
                iInserts++;
            }
            PostUpdate();
        }
	}
}
