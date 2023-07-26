using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoLine : ClsBaseTable
	{
		public ClsCargoLine GetByCargoKey(string sCargoKey)
		{
			string sql = string.Format(@"
				select * from t_cargo_line
                   where cargo_key = '{0}' ",
				sCargoKey);

			DataRow dr = Connection.GetDataRow(sql);

			if (dr == null)
				return null;
			ClsCargoLine cargo = new ClsCargoLine(dr);
			return cargo;
		}
		public bool IsEqual(ClsCargoLine compare)
		{
			if (this.Cargo_Dsc != compare.Cargo_Dsc ||
				this.Cargo_Rcvd_Dt != compare.Cargo_Rcvd_Dt ||
				this.Commodity_Cd != compare.Commodity_Cd ||
				this.Container_No != compare.Container_No ||
				this.Contract_Mod_ID != compare.Contract_Mod_ID ||
				this.Cube_Ft != compare.Cube_Ft ||
				this.Height_Nbr != compare.Height_Nbr ||
				this.Item_No != compare.Item_No ||
				this.Length_Nbr != compare.Length_Nbr ||
				this.Make_Cd != compare.Make_Cd ||
				this.Model_Cd != compare.Model_Cd ||
				this.Move_Type_Cd != compare.Move_Type_Cd ||
				this.Pkg_Type_Cd != compare.Pkg_Type_Cd ||
				this.Seal1 != compare.Seal1 ||
				this.Seal2 != compare.Seal2 ||
				this.Seal3 != compare.Seal3 ||
				this.Vessel_Load_Dt != compare.Vessel_Load_Dt ||
				this.Weight_Nbr != compare.Weight_Nbr ||
				this.Dim_Weight_Nbr != compare.Dim_Weight_Nbr ||
				this.Width_Nbr != compare.Width_Nbr ||
				this.Booking_Line_ID != compare.Booking_Line_ID ||
				this.Serial_No != compare.Serial_No ||
				this.Bol_No != compare.Bol_No ||
				this.Bol_Status != compare.Bol_Status ||
				this.Cargo_Status != compare.Cargo_Status ||
				this.Serial_No != compare.Serial_No ||
				this.Seq_No != compare.Seq_No ||
				this.Ecn_Rcn != compare.Ecn_Rcn ||
				this.Cargo_Status_Dt != compare.Cargo_Status_Dt
				)
				return false;
			return true;
		}
		public decimal? CalcCubeFt
		{
			get
			{
				decimal? cf;
				cf = Length_Nbr * Width_Nbr * Height_Nbr / 1728;
				if (!cf.HasValue)
					cf = 0;
				cf = Math.Round(cf.Value, 3);
				return cf;
			}
		}
		public decimal? CalcMTon
		{
			get
			{
				decimal? mt;
				mt = CalcCubeFt / 40;
				mt = Math.Round(mt.Value, 3);
				return mt;
			}
		}
		public decimal? CalcDimWeight
		{
			get
			{
				decimal? dw;
				dw = Length_Nbr * Width_Nbr * Height_Nbr;
				dw = dw / 166;
				dw = Math.Round(dw.Value, 2);
				if (dw > Weight_Nbr)
					return dw;
				dw = WeightRounding(Weight_Nbr);
				return dw;
			}
		}
		private decimal? WeightRounding(decimal? w)
		{
			if (w == null)
				return 0;
			decimal wt = (decimal)w;
			if (wt > 10)
				wt = decimal.Round(wt, 2);
			else
				wt = decimal.Round(wt, 0);
			w = wt;
			return w;
		}

		#region Static Methods
		public static StringBuilder BuildTCNWarningMessages(string tcn, string origin, string destination)
		{
			StringBuilder sbMsg = new StringBuilder();

			// If this TCN does not exist at all, tell the user and bail-out
			if (!GetByTCNLocations(tcn, "%", "%"))
			{
				sbMsg.AppendFormat("TCN {0} does not exist in LINE", tcn);
				return sbMsg;
			}

			if (!GetByTCNLocations(tcn, origin, destination))
			{
				sbMsg.AppendFormat("TCN {0} does not exist in LINE for {1} / {2} ",
					tcn, origin, destination);
			}
			return sbMsg;
		}

		public static bool GetByTCNLocations(string tcn, string origin, string destination)
		{
			string sql = string.Format(@"
				select * from t_cargo_line c
				 inner join t_booking_line b
				  on c.booking_line_id = b.booking_line_id
				 where c.serial_no = '{0}'
				  and (b.plor_location_cd like '{1}' and b.pol_location_cd like '{2}' ) ",
				 tcn, origin, destination);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return true;

			return false;

		}
		public static DataTable GetByTCNLocationsDT(string tcn, string origin, string destination)
		{
			string sql = string.Format(@"
				select * from t_cargo_line c
				 inner join t_booking_line b
				  on c.booking_line_id = b.booking_line_id
				 where c.serial_no = '{0}'
				  and (b.plor_location_cd like '{1}' and b.pol_location_cd like '{2}' ) ",
				 tcn, origin, destination);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

        public static ClsCargoLine GetByBookingSerialNo(string sBooking, string sSerialNo)
        {
            string sql = string.Format(@"
				select * from t_cargo_line c
				 inner join t_booking_line b
				  on c.booking_line_id = b.booking_line_id
				 where c.serial_no = '{0}'
				  and (b.booking_no like '{1}' ) ",
                  sSerialNo, sBooking);

            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count < 1)
                return null;
            ClsCargoLine cl = new ClsCargoLine(dt.Rows[0]);
            return cl;
        }
		#endregion
	}
}
