using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoMove
	{
		#region Fields/Properties

		public string Make_Model_Cd { get { return Make_Cd + " " + Model_Cd; } }

		public string Len_Wid_Hgt
		{
			get { return string.Format("{0} x {1} x {2}", Length_Nbr, Width_Nbr, Height_Nbr); }
		}

		public string Container_Info { get { return Container_No + " " + Seal123; } }

		public string Seal123
		{
			get
			{
				return string.Format("{0}{1}{2}", Seal1,
					(Seal2.IsNullOrWhiteSpace() ? null : " [" + Seal2 + "] "),
					(Seal3.IsNullOrWhiteSpace() ? null : "[" + Seal3 + "]"));
			}
		}

		public string GetCargoStatus()
		{
			ClsCargoAction lgac = _Last_Logistic_Action;
			bool startFlg = (lgac != null ) ? ClsConvert.YNToBool(lgac.Action.Start_Flg) : false;
			bool endFlg = (lgac != null ) ? ClsConvert.YNToBool(lgac.Action.End_Flg) : false;
			bool isLand = (lgac != null) ? lgac.Location.IsLand : false;
			bool isPort = (lgac != null) ? lgac.Location.IsPort : false;
			bool isDoorInOnly = (Move_Type != null) ? Move_Type.IsDoorInOnly : false;
			
			if( Move_Start_Dt == null ) return "At Origin";
			if( Move_Start_Dt != null && Move_End_Dt == null && startFlg) return "In Transit";
			if (Move_Start_Dt != null && Move_End_Dt == null && endFlg) return "At Checkpoint";
			if (Move_Start_Dt != null && Move_End_Dt != null && In_Gate_Dt == null &&
				Delivery_Dt == null) return "At Destination";
			if (Move_Start_Dt != null && Move_End_Dt != null && In_Gate_Dt != null &&
				Delivery_Dt == null) return "In Gate";
			if (Move_Start_Dt != null && Move_End_Dt != null && Delivery_Dt != null &&
				isLand) return "Delivered to Customer";
			if (Move_Start_Dt != null && Move_End_Dt != null && Delivery_Dt != null &&
				isPort && isDoorInOnly) return "Delivered to Port";
			if (Move_Start_Dt != null && Move_End_Dt != null && Delivery_Dt != null &&
				isPort && !isDoorInOnly) return "With Ocean Carrier";
			return "Unknown Status";
		}
		#endregion		// #region Fields/Properties

		public void SetValuesFromActivity(ClsCargoActivity ca)
		{
			Cargo_Activity_ID = ca.Cargo_Activity_ID;

			ClsCargo c = ca.Cargo;
			ClsBooking bk = c.Booking;

			Booking_No = bk.Booking_No;
			Customer_Ref = bk.Customer_Ref;
			Vessel_Cd = bk.Vessel_Cd;
			Voyage_No = bk.Voyage_No;
			Sail_Dt = bk.Sail_Dt;
			Plor_Location_Cd = bk.Plor_Location_Cd;
			Pol_Location_Cd = bk.Pol_Location_Cd;
			Pod_Location_Cd = bk.Pod_Location_Cd;
			Plod_Location_Cd = bk.Plod_Location_Cd;
			Bol_No = bk.Bol_No;
			Rcvr_Dodaac = bk.Rcvr_Dodaac;
			Delivery_Txt = bk.Delivery_Txt;
			Cargo_Notes_Txt = bk.Cargo_Notes_Txt;

			Serial_No = c.Serial_No;
			Required_Dlvy_Dt = c.Rdd_Dt;
			Move_Type_Cd = c.Move_Type_Cd;
			Cargo_Dsc = c.Cargo_Dsc;
			Container_No = c.Container_No;
			Cargo_Key = c.Cargo_Key;
			Length_Nbr = c.Length_Nbr;
			Width_Nbr = c.Width_Nbr;
			Height_Nbr = c.Height_Nbr;
			Weight_Nbr = c.Weight_Nbr;
			Dim_Weight_Nbr = c.Dim_Weight_Nbr;
			Cube_Ft = c.Cube_Ft;
			M_Tons = c.M_Tons;
			Seal1 = c.Seal1;
			Seal2 = c.Seal2;
			Seal3 = c.Seal3;
			Make_Cd = c.Make_Cd;
			Model_Cd = c.Model_Cd;
			Commodity_Cd = c.Commodity_Cd;
		}

		#region Static Methods
		public static DataTable GetDailyITV_AEJEA_to_AFCLN()
		{
			string sql = string.Format(@"
			select cm.*,
			( select max(action_dt)
			 from t_cargo_action act
			 where act.cargo_move_id = cm.cargo_move_id
			  and act.action_cd = 'DEPART'
			  and act.location_cd = 'AEJEA') as DepartAEJEA,
			 (select max(action_dt)
			  from t_cargo_action act
			   where act.cargo_move_id = cm.cargo_move_id
				and act.action_cd = 'ARRIVE'
				and act.location_cd = 'AFKBL') as ArriveAFKBL,
				( select max(action_dt)
			 from t_cargo_action act
			 where act.cargo_move_id = cm.cargo_move_id
			   and act.action_cd = 'DEPART'
			  and act.location_cd = 'AFKBL') as DepartAFKBL,
			 (select max(action_dt)
			  from t_cargo_action act
			   where act.cargo_move_id = cm.cargo_move_id
				 and act.action_cd = 'ARRIVE'
				and act.location_cd = 'AFCLN') as ArriveAFCLN,
				 (select max(vrd.arrival_dt)
				  from mv_voyage_route_detail vrd
				   where vrd.voyage_cd like cm.voyage_no || '%' 
					 and vrd.location_cd = cm.pod_location_cd) as vessel_arrive_dt
			 from v_daily_itv_import_base cm ");

			DataTable dt = Connection.GetDataTable(sql);
			return dt;

		}
		#endregion
	}
}
