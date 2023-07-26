using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVendorMove
	{
		#region Fields/Properties

		public string Orig_Dest_Dsc
		{
			get
			{
				return string.Format("{0} to {1}",
					(Orig_Location != null ? Orig_Location.Location_Dsc : Orig_Location_Cd),
					(Dest_Location != null ? Dest_Location.Location_Dsc : Dest_Location_Cd));
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			try
			{
				return string.Format("{0}: {1} {2} {3} {4}", Vendor_Move_ID, Vendor_Cd,
					Orig_Location_Cd, Dest_Location_Cd, ClsConvert.YNToActiveInactive(Active_Flg));
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return base.ToString();
			}
		}
		#endregion		// #region ToString Overrides

		public DataTable CargoOnMove
		{
			get
			{
				string sql = string.Format(@"
					select *
					 from t_cargo_move c
					 where vendor_move_id = {0}",
				this.Vendor_Move_ID);
				DataTable dt =  Connection.GetDataTable(sql);
				return dt;
			}
		}
	}

	#region Static Methods/Properties of ClsVendorMove

	partial class ClsVendorMove
	{
		public static DataTable GetVendorMoves(string vendorCd)
		{
			string sql = @"
			SELECT	mv.trading_partner_cd, tp.partner_dsc, mv.move_dsc,
					vmv.orig_location_cd, oloc.location_dsc AS orig_location_dsc,
					vmv.dest_location_cd, dloc.location_dsc AS dest_location_dsc,
					tp.partner_dsc || ' ' || mv.move_dsc || ' ' ||
						oloc.location_dsc || ' to ' || dloc.location_dsc AS extra_dsc,
					vmv.*
			FROM	v_vendor_move vmv
				INNER JOIN t_move mv				ON mv.move_id = vmv.move_id
				INNER JOIN r_location oloc			ON oloc.location_cd = vmv.orig_location_cd
				INNER JOIN r_location dloc			ON dloc.location_cd = vmv.dest_location_cd
				INNER JOIN r_trading_partner tp		ON tp.trading_partner_cd = mv.trading_partner_cd
			WHERE vmv.vendor_cd = @VEN_CD
			ORDER BY tp.partner_dsc, mv.move_dsc, oloc.location_dsc, dloc.location_dsc ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@VEN_CD", vendorCd);

			return Connection.GetDataTable(sql, p);
		}

		public static ClsVendorMove FindVendorMove(long moveid, string vendorcd, string orig, string dest)
		{
			string sql = string.Format(@"
				select * from t_vendor_move
				 where move_id = {0}
				  and vendor_cd = '{1}'
				  and orig_location_cd = '{2}'
				  and dest_location_cd = '{3}' ",
				moveid, vendorcd, orig, dest);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
			{
				DataRow drow = dt.Rows[0];
				ClsVendorMove move = new ClsVendorMove(drow);
				return move;
			}
			return null;
		}
	}
	#endregion		// #region Static Methods/Properties of ClsVendorMove
}
