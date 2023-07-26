using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBookingLine
	{

		#region Public Properties
        private string _OceanSystem;
        public string OceanSystem
        {
            get
            {
                if (_OceanSystem != null)
                    return _OceanSystem;
                if (Booking_No.StartsWith("ARCA"))
                    return "LINE";
                return "OCEAN";
            }
        }
		public List<ClsCargoLine> BookingCargo
		{
			get
			{
				List<ClsCargoLine> cargo = new List<ClsCargoLine>();
				DataTable dt = GetCargo(this.Booking_Line_ID);
				foreach (DataRow dr in dt.Rows)
				{
					ClsCargoLine c = new ClsCargoLine(dr);
					cargo.Add(c);
				}
				return cargo;
			}
		}
		private ClsMoveType _MoveType;
		public ClsMoveType MoveType
		{
			get
			{
				if (_MoveType != null)
					return _MoveType;
				_MoveType = ClsMoveType.GetUsingKey(this.Move_Type_Cd);
				return _MoveType;
			}
		}

		#endregion

		#region Public Methods
		public bool IsEqual(ClsBookingLine compare)
		{
			if (this.Agent_Cd != compare.Agent_Cd ||
				this.Bol_ID != compare.Bol_ID ||
				this.Bol_No != compare.Bol_No ||
				this.Deleted_Flg != compare.Deleted_Flg ||
				this.Booking_Dt != compare.Booking_Dt ||
				this.Booking_No != compare.Booking_No ||
				this.Booking_Ref != compare.Booking_Ref ||
				this.Booking_Status != compare.Booking_Status ||
				this.Cargo_Notes_Txt != compare.Cargo_Notes_Txt ||
				this.Cargo_Type != compare.Cargo_Type ||
				this.Customer_Cd != compare.Customer_Cd ||
				this.Customer_Nm != compare.Customer_Nm ||
				this.Customer_Ref != compare.Customer_Ref ||
				this.Deleted_Flg != compare.Deleted_Flg ||
				this.Delivery_Txt != compare.Delivery_Txt ||
				this.Edi_Ref != compare.Edi_Ref ||
				this.Imdg_Flg != compare.Imdg_Flg ||
				this.Kind_Of_Pkg_Cd != compare.Kind_Of_Pkg_Cd ||
				this.Match_Cd != compare.Match_Cd ||
				this.Move_Type_Cd != compare.Move_Type_Cd ||
				this.Plod_Location_Cd != compare.Plod_Location_Cd ||
				this.Plor_Location_Cd != compare.Plor_Location_Cd ||
				this.Pod_Berth != compare.Pod_Berth ||
				this.Pod_Dsc != compare.Pod_Dsc ||
				this.Pod_Eta != compare.Pod_Eta ||
				this.Pod_Location_Cd != compare.Pod_Location_Cd ||
				this.Pol_Berth != compare.Pol_Berth ||
				this.Pol_Ets != compare.Pol_Ets ||
				this.Pol_Location_Cd != compare.Pol_Location_Cd ||
				this.Vessel_Cd != compare.Vessel_Cd ||
				this.Voyage_No != compare.Voyage_No ||
				this.Tariff_Cd != compare.Tariff_Cd
				)
				return false;
			return true;
				
		}
		#endregion

		#region Private Methods
		public string SetILMSEligibleFlg()
		{
			this.Ilms_Eligible_Flg = "N";

			// If neither the PLOR nor PLOD is a Land location, this 
			// is not eligible for ILMS because it is not a door move.
			// May 2012 Remove this requirement
			ClsLocation plor = ClsLocation.GetUsingKey(this.Plor_Location_Cd);
			ClsLocation plod = ClsLocation.GetUsingKey(this.Plod_Location_Cd);
			if (plor == null)
				return "N";
			if (plod == null)
				return "N";
			//if (plor.Location_Type.IsPort && plod.Location_Type.IsPort)
			//    return "N";

			// If it's not a Door Move Type, it is not eligible
			ClsMoveType move = ClsMoveType.GetUsingKey(this.Move_Type_Cd);
			if (move == null)
				return "N";
			if (!move.IsDoorMove)
				return "N";

			if (this.Deleted_Flg == "Y")
				return "N";

			this.Ilms_Eligible_Flg = "Y";
			return "Y";
		}
		#endregion


		#region Public Static Methods
		public static ClsBookingLine GetByBookingNo(string sBookingNo)
		{
			string sql = string.Format(@"
				select * from t_booking_line
                  where booking_no = '{0}' ", sBookingNo);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			DataRow dr = dt.Rows[0];
			ClsBookingLine bl = new ClsBookingLine(dr);
			return bl;
			
		}

		public static DataTable GetCargo(long? iBookingID)
		{
			string sql = string.Format(@"
				select * from t_cargo_line
				  where booking_line_id = {0} ", iBookingID);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetCargo(long? iBookingID, long iItemNo, 
			string sContainers, bool bStowed)
		{
			/*
			 * Finds all cargo for a booking / item.
			 * 
			 * Sorts so that the further along in the logistics process,
			 * the sooner it appears in the list.
			 * 
			 * If a list of containers is provided, and we're just 
			 * looking for stowed cargo, limit the search to the
			 * containers.
			*/
			 
			string sql = string.Format(@"
				select * from t_cargo_line
				  where booking_line_id = {0} and item_no = {1} ",
				   iBookingID, iItemNo);

			if (bStowed)
				if (!string.IsNullOrEmpty(sContainers))
				{
					sql = sql + string.Format(@"
						and replace(container_no,' ','') in ({0})",
							sContainers);
				};

			sql = sql + @"
					 order by
					 case
					   when cargo_status = 'BOOK' then 900
					   when cargo_status = 'EXRC' then 850
					   when cargo_status = 'LOAD' then 800
					   when cargo_status = 'DISC' then 100
						 else 500
					end ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		public static List<ClsCargoLine> GetCargoList(long? iBookingID, long iItemNo,
				string sContainers, bool bStowed)
		{
			/* Currently just used for iCodes Export */
			List<ClsCargoLine> cargoList = new List<ClsCargoLine>();
			DataTable dt = GetCargo(iBookingID, iItemNo, sContainers, bStowed);
			foreach (DataRow dr in dt.Rows)
			{
				ClsCargoLine cargo = new ClsCargoLine(dr);
				cargoList.Add(cargo);
			}
			return cargoList;
		}
		#endregion
	}
}
