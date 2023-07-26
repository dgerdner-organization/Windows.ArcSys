using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVSddcItvList
	{
		#region Connection Manager

		protected static ClsConnection ACMSConnection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}

		protected static ClsConnection ARCConnection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Properties
		public bool IsDoorIn
		{
			get
			{
				if (this.Move_Type_Cd == "F5" ||
					this.Move_Type_Cd == "F6" ||
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}

		public bool IsDoorOut
		{
			get
			{
				if (this.Move_Type_Cd == "F7" ||
					this.Move_Type_Cd == "F8" ||
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}

		public bool isTransShipFinalLeg
		{
			get
			{
				if (!string.IsNullOrEmpty(Firstleg_Booking_No))
					return true;
				return false;
			}
		}
		public bool isTransShipFistLeg
		{
			get
			{
				// If there is a transshipment First Leg
				// associated with this booking, then this
				DataTable dt = GetTransshipmentData(this.Booking_No, "First Leg");
				if (dt.Rows.Count < 1)
					return false;
				return true;
			}
		}

		private string _TransShipmentBookingNo;
		public string TransshipmentBookingNo
		{
			get
			{
				return _TransShipmentBookingNo;
			}
			set
			{
				_TransShipmentBookingNo = value;
			}
		}


		private DataRow _TransshipmentFinalLeg;
		public DataRow TransshipmentFinalLeg
		{
			get
			{
				if (_TransshipmentFinalLeg != null)
					return _TransshipmentFinalLeg;
				DataTable dt = GetTransshipmentData(this.Booking_No, "Final Leg");
				if (dt.Rows.Count < 1)
					return null;
				_TransshipmentFinalLeg = dt.Rows[0];
				return _TransshipmentFinalLeg;
			}
		}
		#endregion

		#region Static Methods
		public static List<ClsVSddcItvList> GetInGateList()
		{
			Connection.CommandTimeout = 0;
			// Find cargo where we have sent no ingates
			// and no pickups.
			//ClsVSddcItvList cargo = ClsVSddcItvList.GetAll();
			string sql = string.Format(@"
				select * from v_sddc_itv_list
				 where cargo_rcvd_dt > sysdate - 60
				  and acms_status_cd in ('B','C')
				  and (i_count = 0 or w_count = 0 )");

			DataTable dt = Connection.GetDataTable(sql);
			List<ClsVSddcItvList> list = DatatableToList(dt);
			return list;
		}

		public static List<ClsVSddcItvList> GetDepartList()
		{
			Connection.CommandTimeout = 0;
			// Find cargo where we have sent no va 
				string sql = string.Format(@"
				select * from v_sddc_itv_list
				 where cargo_rcvd_dt > sysdate - 180
				   and depart_flg = 'Y'
				   and acms_status_cd in ('B','C')
				   and (vd_count = 0 or ae_count = 0)  ");

			DataTable dt = Connection.GetDataTable(sql);
			List<ClsVSddcItvList> list = DatatableToList(dt);
			return list;
		}

		public static List<ClsVSddcItvList> GetArrivalList()
		{
			Connection.CommandTimeout = 0;
			// Find cargo where we have sent no ingates
			// and no pickups.
			//ClsVSddcItvList cargo = ClsVSddcItvList.GetAll();

			// DGERDNER July 2014: We now do an outer join to t_transshipment.  If the join
			//  is successful we know that this booking is the First Leg of a Transshipment.
			//  This is used later on in the ITV Create process.  The change was made for
			//  performance; formerlly it was reading the transshipment table once for each
			//  row in this database to determine if it existed.  That was causing the
			//  process to take up to 15 minutes to run.  This should improve performance to
			//  sub-one-minute.

			// DGERDNER August 2014: added oa or x1 count = 0 (was not creating oa/x1 if
			// the va had occured while it was a door out; then later it was changed to a port
			string sql = string.Format(@"
				select v_sddc_itv_list.*, ts.booking_no as tsBookingNo
				  from v_sddc_itv_list
				  left outer join v_acms_transshipment ts on ts.booking_no = v_sddc_itv_list.booking_no
				 where cargo_rcvd_dt > sysdate - 180
				   and arrive_flg = 'Y'
				   and acms_status_cd in ('B','C')
				   and (va_count = 0 or uv_count = 0 or oa_count = 0 or x1_count = 0)  ");

			DataTable dt = Connection.GetDataTable(sql);
			List<ClsVSddcItvList> list = DatatableToList(dt, true);
			return list;
		}

		public static DataTable GetFinalLegDepartList()
		{

//            string sql = string.Format(@"
//					select * from V_TRANSSHIPMENTS t
//					 where leg_type = 'Final Leg'
//						and edi_depart_dt is not null 
//						and depart_actual_flg = 'Y'
//						and ( vd_count = 0 or ae_count = 0 )
//						and edi_depart_dt > sysdate - 180
//					 order by pol_ets ");

			// July 2014: Dgerdner - use a new more efficient view
			string sql = string.Format(@"
				select * from v_ts_final_depart_list
				 where ae_count = 0 or vd_count = 0");
			
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetFinalLegArriveList()
		{
//            string sql = string.Format(@"
//					select * from V_TRANSSHIPMENTS t
//					 where leg_type = 'Final Leg'
//					 and edi_arrive_dt is not null 
//					 and arrive_actual_flg = 'Y'
//					 and ( va_count = 0 or uv_count = 0 or oa_count = 0 )
//					 and edi_arrive_dt > sysdate - 180
//					 order by pod_eta ");

			// July 2014: Dgerdner - use a new more efficient view
			string sql = string.Format(@"
				select * from v_ts_final_arrive_list
				 where va_count = 0 or uv_count = 0 or oa_count = 0");
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		protected static List<ClsVSddcItvList> DatatableToList(DataTable dt)
		{
			return DatatableToList(dt,false);
		}
		protected static List<ClsVSddcItvList> DatatableToList(DataTable dt, bool bTSBookingNo)
		{
			List<ClsVSddcItvList> list = new List<ClsVSddcItvList>();
			foreach (DataRow dr in dt.Rows)
			{
				ClsVSddcItvList item = new ClsVSddcItvList(dr);
				item.TransshipmentBookingNo = "";
				if (bTSBookingNo)
				{
					string s = dr["tsBookingNo"].ToString();
					item.TransshipmentBookingNo = s;
				}
				list.Add(item);
			}
			return list;
		}

		public static void CreateITV(ClsVSddcItvList c, string sCode, string sUser, DateTime dActivityDt)
		{
			bool bInTrans = ACMSConnection.IsInTransaction;

			if (string.IsNullOrEmpty(c.Acms_Booking_No))
			{
				return;
			}

			try
			{
				if (!bInTrans)
					ACMSConnection.TransactionBegin();
				ACMSConnection.CommandTimeout = 0;
				// This is here to fudge dates to be within the 24 hour limit.
				// Should normally be commented-out because we won't use it.
				//if (sCode == "VD" || sCode == "AE")
				//    dActivityDt = DateTime.Now.AddHours(-12);
				//else
				//    dActivityDt = DateTime.Now.AddDays(-1);
				List<DbParameter> p = new List<DbParameter>();

				// This is needed because a " " in the view
				// is trimmed by our code generator, and in
				// this case we need the space.
				string sSub = c.Acms_Booking_Sub;
				if (string.IsNullOrEmpty(sSub))
				{
					sSub = " ";
				}
				// Decide which voyage,vessel, and location(s) to use
				string sBookingNo = c.Acms_Booking_No;
				string sVoyageNo = c.Acms_Voyage_No;
				string sVessel = c.Vessel_Cd;
				string sLocation = c.Pol_Location_Cd;
				string sBerth = c.Pol_Berth;

				// For activities at the receiving end, use the POD location
				if (sCode == "VA" || sCode == "OA" || sCode == "X1" || sCode == "UV")
				{
					sLocation = c.Pod_Location_Cd;
					sBerth = c.Pod_Berth;
				}

				if (c.isTransShipFinalLeg)
				{
					// On the final leg of transshipments,
					// use booking and voyage info from first booking.
					sBookingNo = c.Firstleg_Booking_No;
					ClsBookingLine bl = ClsBookingLine.GetByBookingNo(c.Firstleg_Booking_No);
					sVoyageNo = bl.Voyage_No;
					sVessel = bl.Vessel_Cd;
				}
				p.Add(Connection.GetParameter("@RDATE", dActivityDt));
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(@"
				insert into t_booking_itv 
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no)
				  select t_booking_itv_seq.nextval,
					  '{0}', '{1}', '{2}', @RDATE, 
					  '{7}', 'N', '{3}', '{4}', {5}, '{6}', 0
					   from dual",
					  c.Acms_Booking_No,
					  sSub,
					  sCode,
					  c.Acms_Voyage_No,
					  sLocation,
					  c.Acms_Item_No,
					  sBerth,
					  sUser);
				ACMSConnection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());
				if (!bInTrans)
					ACMSConnection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					ACMSConnection.TransactionRollback();
				throw ex;
			}
		}

		public static void CreateITV(string sBookingNo, string sSub,
					string sVoyageNo,
					string sVessel,
					string sLocation,
					string sBerth,
					string sCode, 
					string sItemNo,
					string sUser, DateTime dActivityDt)
		{
			bool bInTrans = ACMSConnection.IsInTransaction;

			if (string.IsNullOrEmpty(sBookingNo))
			{
				return;
			}

			try
			{
				if (!bInTrans)
					ACMSConnection.TransactionBegin();
				ACMSConnection.CommandTimeout = 0;
				// This is here to fudge dates to be within the 24 hour limit.
				// Should normally be commented-out because we won't use it.
				//if (sCode == "VD" || sCode == "AE")
				//    dActivityDt = DateTime.Now.AddHours(-12);
				//else
				//    dActivityDt = DateTime.Now.AddDays(-1);
				List<DbParameter> p = new List<DbParameter>();

				// This is needed because a " " in the view
				// is trimmed by our code generator, and in
				// this case we need the space.
				if (string.IsNullOrEmpty(sSub))
				{
					sSub = " ";
				}

				p.Add(Connection.GetParameter("@RDATE", dActivityDt));
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(@"
				insert into t_booking_itv 
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no)
				  select t_booking_itv_seq.nextval,
					  '{0}', '{1}', '{2}', @RDATE, 
					  '{7}', 'N', '{3}', '{4}', {5}, '{6}', 0
					   from dual",
					  sBookingNo,
					  sSub,
					  sCode,
					  sVoyageNo,
					  sLocation,
					  sItemNo,
					  sBerth,
					  sUser);
				ACMSConnection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());
				if (!bInTrans)
					ACMSConnection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					ACMSConnection.TransactionRollback();
				throw ex;
			}
		}

		public static DataTable GetTransshipmentData(string sBookingNo, string sLeg)
		{
			string sql = string.Format(@"select *
                    from v_transshipments
                       where booking_no = '{0}' 
						and leg_type = '{1}'", sBookingNo, sLeg);
			return ARCConnection.GetDataTable(sql);
		}
		#endregion
	}
}
