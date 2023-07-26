using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTradingPartnerEdi
	{
		public static ClsTradingPartnerEdi GetByMap(string sPartner, string sMap)
		{
	    	DataRow dr = Connection.GetDataRow(string.Format("select * from r_trading_partner_edi where trading_partner_cd = '{0}' and map_nm = '{1}' ", sPartner, sMap));
            return (dr == null) ? null : new ClsTradingPartnerEdi(dr);
		}

        public void UpdateIsa_Nbr_Receiver_Qualifier()
        {
            string sql = string.Format("Update r_trading_partner_edi set Outbound_Isa_Nbr = {0}, Receiver_Qualifier = '{1}' where Trading_Partner_Edi_ID = {2}", Outbound_Isa_Nbr, Receiver_Qualifier, Trading_Partner_Edi_ID);
            Connection.RunSQL(sql);
        }
	}
}
