using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargo
	{
		#region Properties

		public string Make_Model_Cd { get { return Make_Cd + " " + Model_Cd; } }

		public string Len_Wid_Hgt
		{
			get { return string.Format("{0} x {1} x {2}", Length_Nbr, Width_Nbr, Height_Nbr); }
		}

		public string Seal123
		{
			get
			{
				return string.Format("{0}{1}{2}", Seal1,
					(string.IsNullOrEmpty(Seal2) ? null : " [" + Seal2 + "] "),
					(string.IsNullOrEmpty(Seal3) ? null : "[" + Seal3 + "]"));
			}
		}

		#region Cargo Activity

		private List<ClsCargoActivity> _lstCargoActivities;

		public List<ClsCargoActivity> lstCargoActivities
		{
			get
			{
				if (_lstCargoActivities != null) return _lstCargoActivities;

				_lstCargoActivities = new List<ClsCargoActivity>();

				foreach (DataRow dr in _dtCargoActivities.Rows)
					_lstCargoActivities.Add(new ClsCargoActivity(dr));

				return _lstCargoActivities;

			}
		}

		private DataTable _dtCargoActivities
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendFormat(@"
					SELECT *
					FROM t_cargo_activity ca 
					WHERE
					ca.cargo_id = {0}", this.Cargo_ID);

				return Connection.GetDataTable(sb.ToString());
			}
		}
		public DataTable dtCargoChanges
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(@"
					 select c.serial_no, t.* from A_AUDIT_TRAIL t
					 inner join t_cargo c on t.primary_key = c.cargo_id
					 where primary_key = {0}
					  and table_nm = 't_cargo'
					  and operation_cd = 'U' ",
					  this.Cargo_ID);

				sb.AppendFormat(@"
					union all
					select c.serial_no, t.* from a_audit_trail t
					  inner join t_cargo c on t.primary_key = c.booking_id
					   and c.cargo_id = {0}
					 where table_nm = 't_booking'
					   and primary_key in
					  (select booking_id from t_cargo where cargo_id = {0}) ",
					  this.Cargo_ID);

				return Connection.GetDataTable(sb.ToString());
			}
		}

		public DataTable GetCargoActivities(bool extraInfo)
		{
			string sql = null;
			if (extraInfo)
			{
				sql = @"
			select	ca.*, est.estimate_no,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					decode(ca.orig_location_cd, null, 0, est.orig_location_cd, 0, 1) as mismatch_orig,
					decode(ca.dest_location_cd, null, 0, est.dest_location_cd, 0, 1) as mismatch_dest,
					decode(estoloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(estoloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(estdloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt
			FROM	t_cargo_activity ca
					INNER JOIN t_estimate est			ON est.estimate_id = ca.estimate_id
					INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
					INNER JOIN r_location estoloc		ON estoloc.location_cd = est.orig_location_cd
					INNER JOIN r_location estdloc		ON estdloc.location_cd = est.dest_location_cd
			WHERE	ca.cargo_id = @CGO_ID ";
			}
			else
			{
				sql = @"
			SELECT	ca.*
			FROM	t_cargo_activity ca
			WHERE	ca.cargo_id = @CGO_ID ";
			}

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CGO_ID", Cargo_ID.Value);

			return Connection.GetDataTable(sql, p);
		}
		#endregion

		#endregion

		#region Public Methods

		//public DataTable GetCargoActivities()
		//{
		//    DataSet DS = new DataSet();

		//    DataTable dtCA = _dtCargoActivities;
		//    dtCA.TableName = "CargoActivities";

		//    //DataTable dtEstAP = _dtEstimateAPCharges;
		//    //dtEstAP.TableName = "EstAP";

		//    //DataTable dtEstAR = _dtEstimateARCharges;
		//    //dtEstAR.TableName = "EstAR";

		//    //DS.Relations.Add(new DataRelation("EstAP",
		//    //    dtCA.Columns["CARGO_ACTIVITY_ID"],
		//    //    dtEstAP.Columns["CARGO_ACTIVITY_ID"], true));

		//    //DS.Relations.Add(new DataRelation("EstAR",
		//    //    dtCA.Columns["CARGO_ACTIVITY_ID"],
		//    //    dtEstAR.Columns["CARGO_ACTIVITY_ID"], true));

		//    //DS.Tables.Add(_dtCargoActivities);
		//    //DS.Tables.Add(_dtEstimateAPCharges);
		//    //DS.Tables.Add(_dtEstimateARCharges);

		//    //DS.Relations.Add(new DataRelation("EstAP",
		//    //    _dtCargoActivities.Columns["CARGO_ACTIVITY_ID"],
		//    //    _dtEstimateAPCharges.Columns["CARGO_ACTIVITY_ID"],true));

		//    //DS.Relations.Add(new DataRelation("EstAR",
		//    //    _dtCargoActivities.Columns["CARGO_ACTIVITY_ID"],
		//    //    _dtEstimateARCharges.Columns["CARGO_ACTIVITY_ID"],true));

		//    return DS;
		//}

		#endregion

		#region Static Methods
		public static StringBuilder BuildTCNWarningMessages(string tcn, string origin, string destination)
		{
			StringBuilder sbMsg = new StringBuilder();

			// If this TCN does not exist at all, tell the user and bail-out
			if (!GetByTCNLocations(tcn, "%", "%"))
			{
				sbMsg.AppendFormat("TCN {0} does not exist in ILMS", tcn);
				return sbMsg;
			}

			if (!GetByTCNLocations(tcn, origin, destination))
			{
				sbMsg.AppendFormat("TCN {0} does not exist in ILMS for {1} / {2} ",
					tcn, origin, destination);
			}
			return sbMsg;
		}

		public static bool GetByTCNLocations(string tcn, string origin, string destination)
		{
			string sql = string.Format(@"
				select * 
				  from t_cargo_activity ca
                 inner join t_cargo c on ca.cargo_id = c.cargo_id
				 inner join t_booking b on c.booking_id = b.booking_id
				 where c.serial_no = '{0}'
				  and (ca.orig_location_cd like '{1}' and ca.dest_location_cd like '{2}' ) ",
				 tcn, origin, destination);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return true;

			return false;

		}

		//public static DataTable GetAvailableForMove(string sCustomer)
		//{
		//    return GetAvailableForMove(sCustomer, "%", "%", "%", 1000);
		//}
		public static DataTable GetAvailableForMove(string origin, string destination)
		{
			return GetAvailableForMove("%", origin, destination, "%", 1000);
		}
		public static DataTable GetAvailableForMove(
			string sCustomer, string origin, string destination, string ConusOconus, int days)
		{
			string sConusFlg = "Y";
			if (ConusOconus == "OCONUS")
				sConusFlg = "N";
			if (ConusOconus == "%")
				sConusFlg = "%";
			string sql = string.Format(@"
			select ca.*, 
				   b.booking_no, 
				   b.voyage_no, 
				   b.vessel_cd,
				   b.sail_dt,
				   org.location_dsc as org_dsc,
				   dest.location_dsc as dest_dsc,
				   c.*,
				   case when container_no is null then '' 
					 else 
						container_no || '  Seals:' || nvl(seal1,'') ||  
						case when seal2 is null then '' else ' / ' || seal2 end || 
						case when seal3 is null then '' else ' / ' || seal3 end
				   end as container_info   
			 from t_booking b
			  inner join t_cargo c on c.booking_id = b.booking_id
			  inner join t_cargo_activity ca on ca.cargo_id = c.cargo_id
			  inner join r_trading_partner_customer tpc on tpc.customer_cd = b.customer_cd
			  inner join r_location org on org.location_cd = ca.orig_location_cd
			  inner join r_location dest on dest.location_cd = ca.dest_location_cd
			 where tpc.trading_partner_cd like '{0}'
               and b.create_dt > sysdate - 720
			   and ca.orig_location_cd like '{1}'
			   and ca.dest_location_cd like '{2}'
			   and org.conus_flg like '{3}'
			   and not exists
				  (select 1
				   from t_cargo_move cm
					where cm.serial_no = c.serial_no
					  and cm.booking_no = b.booking_no)
			   and (b.sail_dt is null or b.sail_dt > sysdate - {4}) ",
					sCustomer, origin, destination, sConusFlg, days);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

        public static ClsCargo GetByBookingSerialNo(string sBooking, string sSerialNo)
        {
            string sql = string.Format(@"
				select * from t_cargo c
				 inner join t_booking b
				  on c.booking_id = b.booking_id
				 where c.serial_no = '{0}'
				  and (b.booking_no like '{1}' ) ",
                  sSerialNo, sBooking);

            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count < 1)
                return null;
            ClsCargo cl = new ClsCargo(dt.Rows[0]);
            return cl;
        }


		#endregion

	}
}
