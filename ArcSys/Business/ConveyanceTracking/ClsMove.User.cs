using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMove
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			base.SetDefaults();
			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			try
			{
				return string.Format("{0}: {1} {2} {3} {4}", Move_ID, Trading_Partner_Cd,
					Move_Dsc, ClsConfig.FormatDate(End_Dt),
					ClsConvert.YNToActiveInactive(Active_Flg));
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return base.ToString();
			}
		}
		#endregion		// #region ToString Overrides

		#region Static Methods
		public static DataTable GetForShipper(string sTradingPartner)
		{
			string sql = string.Format(@"
				select *
				 from t_move
				  where trading_partner_cd = 'SDDC' ",
				sTradingPartner);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		#endregion
	}
}