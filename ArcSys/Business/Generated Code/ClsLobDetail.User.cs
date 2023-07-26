using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.ComponentModel;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Business
{
	partial class ClsLobDetail
	{
        public bool New_Flg { get; set; }

		private string _Cargo_Status;
		public string Cargo_Status
		{
			get
			{
				if (!string.IsNullOrEmpty(_Cargo_Status))
					return _Cargo_Status;
				ClsVBookingCargoLine bl = GetvBookingCargoLine();
				if (bl != null)
					_Cargo_Status = bl.Cargo_Status;
				return _Cargo_Status;
			}
			set
			{
				_Cargo_Status = value;
			}
		}
		public ClsVBookingCargoLine GetvBookingCargoLine()
		{
			ClsVBookingCargoLine bl = ClsVBookingCargoLine.GetByBookingSerialNo(this.Booking_No, this.Tcn);
			return bl;
		}

        public static DataTable GetByHeaderID(long hID)
		{
            try
            {
                List<DbParameter> parms = new List<DbParameter>();

                string sql = @"select d.*, h.voyage_no, h.pol_location_cd 
				    from t_lob_detail d 
				    inner join t_lob_header h on h.lob_header_id = d.lob_header_id
				    where d.lob_header_id = @LOB_HEADER_ID ";

                parms.Add(Connection.GetParameter("@LOB_HEADER_ID", hID));

			    DataTable dt = Connection.GetDataTable(sql,parms.ToArray());
			    return dt;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
		}

        public static BindingList<ClsLobDetail> GetBindingListByHeaderID(long hID)
        {
            try
            {
                List<DbParameter> parms = new List<DbParameter>();

                string sql = @"select d.*, h.voyage_no, h.pol_location_cd 
				    from t_lob_detail d 
				    inner join t_lob_header h on h.lob_header_id = d.lob_header_id
				    where d.lob_header_id = @LOB_HEADER_ID ";

                parms.Add(Connection.GetParameter("@LOB_HEADER_ID", hID));

                DataTable dt = Connection.GetDataTable(sql, parms.ToArray());

                BindingList<ClsLobDetail> lstDB = new BindingList<ClsLobDetail>();

                foreach (DataRow dr in dt.Rows)
                    lstDB.Add(new ClsLobDetail(dr));

                return lstDB;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

        public static ClsLobDetail GetByPcfnTcn(string pcfn, string tcn, long? version_no)
        {
            try
            {
                List<DbParameter> parms = new List<DbParameter>();

                string sql = string.Format(@"
                    Select * from t_lob_detail d 
                    inner join t_lob_header h on h.lob_header_id = d.lob_header_id
                    where d.pcfn = @PCFN and d.tcn = @TCN and h.version_no = @VERSION_NO ");

                parms.Add(Connection.GetParameter("@PCFN",pcfn));
                parms.Add(Connection.GetParameter("@TCN", tcn));
                parms.Add(Connection.GetParameter("@VERSION_NO", version_no));

                ClsLobDetail d = Connection.GetList<ClsLobDetail>(sql,parms.ToArray())[0];
                return d;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

        public static ClsLobDetail GetByTcn(string tcn, long? version_no)
        {
            try
            {
                List<DbParameter> parms = new List<DbParameter>();

                string sql = string.Format(@"
                    Select d.* 
                    from t_lob_detail d 
                    inner join t_lob_header h on h.lob_header_id = d.lob_header_id
                    where d.tcn = @TCN and h.version_no = @VERSION_NO ");

                parms.Add(Connection.GetParameter("@TCN", tcn));
                parms.Add(Connection.GetParameter("@VERSION_NO", version_no));

                ClsLobDetail d = Connection.GetList<ClsLobDetail>(sql, parms.ToArray())[0];
                return d;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }

        }

        public decimal Cube_Nbr_Computed
        {
            get
			{
                return cube_ft(Length_Nbr, Width_Nbr, Height_Nbr);
				
            }
        }

        public decimal MTON_Nbr_Computed
        {
            get
            {
                decimal m = cube_ft(Length_Nbr, Width_Nbr, Height_Nbr);
                return (m == 0) ? 0 : Math.Round( (m / 40),3);
            }
        }

        private decimal cube_ft(decimal? length, decimal? width, decimal? height)
        {
            try 
	        {	        
                decimal l = (length.IsNull()) ? 0 : (decimal)length;
                decimal w = (width.IsNull()) ? 0 : (decimal)width;
                decimal h = (height.IsNull()) ? 0 : (decimal)height;

                if (((l * w * h) %  1728) == 0)
                    return Math.Floor( Math.Round((l * w * h / 1728),3));
                else
                    return (Math.Floor( Math.Round((l * w * h / 1728),3)) + 1);		
	        }
	        catch 
	        {
                return 0;
	        }
        }

        /// <summary>
        ///  The method will update the corresponding detail data in ACMS.
        /// </summary>
        /// <returns></returns>
        public bool UpdateACMS()
        {
            try
            {
                ClsBookingUnit bu = ClsBookingUnit.GetByTCN(Booking_No, Tcn);

                if (bu.IsNotNull())
                {
                    bu.Item_Dsc = Cargo_Dsc;
                    bu.Length_Nbr = Length_Nbr.ToDouble();
                    bu.Width_Nbr = Width_Nbr.ToDouble();
                    bu.Height_Nbr = Height_Nbr.ToDouble();
                    bu.Wt_Nbr = Weight_Nbr.ToDouble();
                    bu.Commodity_Cd = Commodity_Cd;
                    bu.Adj_Rdd_Dt = Rdd_Dt;

                    if (bu.Update() != 1) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return false;
            }

        }

        public bool PopulateFromExtract(clsLobExtract e)
        {
            try
            {

                // leave tcn as-is ...
                Tcn = e.tcn;
                Van_Type = e.van_type;
                Container_No = e.container_no;
                Consignor_Dodaac = e.consignor_dodaac;
                Pod_Location_Cd = e.pod_location_cd;
                Booking_No = e.booking_no;
                Bol_No = e.cargo_bol_no;
                Pcfn = e.pcfn;
                Vessel_Status_Cd = e.vessel_status_cd;
                Consignee_Dodaac = e.consignee_dodaac;
                Cargo_Dsc = e.cargo_dsc;
                Cube_Nbr = e.cube_nbr;
                Length_Nbr = e.length_nbr;
                Width_Nbr = e.width_nbr;
                Height_Nbr = e.height_nbr;
                Weight_Nbr = e.weight_nbr;
                Mton_Nbr = e.mton_nbr;
                Booked_Flg = e.booked_flg;
                Si_Flg = e.si_flg;
                Comment_One = e.comment_one;
                Comment_Two = e.comment_two;
                Commodity_Cd = e.commodity_cd;
                Rdd_Dt = e.rdd_dt;
                // LiftOnDt ???
                // Pcs Nbr
                // pol location
                // pol berth
                // req pod
                // plod
                // sddc cbft
                // Move Type
                Manifested_Flg = e.manifested_flg;
                Vd_Flg = e.vd_flg;
                Cargo_Status = e.cargo_status;
                //Lob_Header_ID = e.lob_header_id;

                return true;
            }
            catch 
            {
                return false;
            }

        }

	}
}
