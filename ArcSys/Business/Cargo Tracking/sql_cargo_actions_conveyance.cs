using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_cargo_actions_conveyance : sql_base
    {
        protected override string connection_key
        {
            get { return "ArcSys"; }
        }

        protected override string base_query
        {
            get
            {
                return @"
                    SELECT
                        distinct
                        m.move_id,
                        m.move_dsc,
                        vm.vendor_move_id,
                        vm.vendor_cd,
                        v.vendor_nm,
                        vm.orig_location_cd,
                        vm_orig.location_dsc AS vm_orig_loc_dsc,
                        vm.dest_location_cd,
                        vm_dest.location_dsc AS vm_dest_loc_dsc,
                        c.*,
                        ct.conveyance_type_dsc,
                        c.futile_flg,
                        last_log_action.action_cd,
                        a.action_dsc,
                        last_log_action.location_cd,
                        last_location.location_dsc AS last_location_dsc,
                        last_log_action.action_dt,
                        vm_orig.conus_flg

                    FROM
                        v_vendor_move vm
                        INNER JOIN v_vendor v ON v.vendor_cd = vm.vendor_cd
                        INNER JOIN t_move m ON m.move_id = vm.move_id
                        INNER JOIN t_cargo_move cm ON cm.vendor_move_id = vm.vendor_move_id
                        INNER JOIN r_location vm_orig ON vm_orig.location_cd = vm.orig_location_cd
                        INNER JOIN r_location vm_dest ON vm_dest.location_cd = vm.dest_location_cd
                        INNER JOIN t_conveyance c ON cm.conveyance_id = c.conveyance_id
                        LEFT OUTER JOIN r_conveyance_type ct ON ct.conveyance_type_cd = c.conveyance_type_cd
                        LEFT OUTER JOIN t_cargo_action last_log_action ON cm.last_logistic_action_id = last_log_action.cargo_action_id
                        LEFT OUTER JOIN r_action a ON a.action_cd = last_log_action.action_cd
                        LEFT OUTER JOIN r_location last_location ON last_location.location_cd = last_log_action.location_cd

                    WHERE 
                        1=1
                        AND m.active_flg = 'Y'
                        AND vm.active_flg = 'Y'
                        AND cm.active_flg = 'Y'
                        [WHERE]

                    ORDER BY 
                        m.move_dsc
                ";
            }
        }

        /// <summary>
        /// DO NOT USE ... With new frmCargoAction screen this is obsolete ...
        /// </summary>
        /// <param name="MoveId"></param>
        /// <param name="SerialNo"></param>
        /// <param name="TruckNo"></param>
        /// <param name="Origin"></param>
        /// <param name="Dest"></param>
        /// <param name="LastAction"></param>
        /// <param name="LastLocation"></param>
        //public void Run(            
        //    long MoveId,
        //    string SerialNo,
        //    string TruckNo,
        //    string Origin,
        //    string Dest,
        //    string LastAction,
        //    string LastLocation)
        //{

        //    throw new Exception("DO NOT USE ... it is now obsolete.");

        //    StringBuilder where = new StringBuilder();

        //    if (MoveId > 0)
        //        where.AppendFormat(" AND m.Move_Id = {0}", MoveId);

        //    if (SerialNo.IsNotNull())
        //        where.AppendFormat(" AND c.conveyance_id = (SELECT cm2.conveyance_id FROM t_cargo_move cm2 WHERE cm2.serial_no = '{0}') ", SerialNo);

        //    if (TruckNo.IsNotNull())
        //        where.AppendFormat(" AND c.truck_no = '{0}'", TruckNo);

        //    if (Origin.IsNotNull())
        //        where.AppendFormat(" AND vm.orig_location_cd = '{0}'", Origin);

        //    if (Dest.IsNotNull())
        //        where.AppendFormat(" AND vm.dest_location_cd = '{0}'", Dest);

        //    if (LastAction.IsNotNull())
        //        where.AppendFormat(" AND last_log_action.action_cd = '{0}'", LastAction);

        //    if (LastLocation.IsNotNull())
        //        where.AppendFormat(" AND last_log_action.location_cd = '{0}'", LastLocation);

        //    RunWhere(where.ToString());

        //}

        public void RunForOVPC()
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@" 
                AND cm.move_start_dt IS NULL
            ");

            RunWhere(where.ToString());
        }

        public void RunForENROUTE()
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@" 
                AND cm.move_start_dt IS NOT NULL
				AND cm.move_end_dt IS NULL
				AND a.start_flg = 'Y'                            
            ");

            RunWhere(where.ToString());
        }

        public void RunForIVPC()
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@" 
                AND cm.move_start_dt IS NOT NULL
				AND cm.move_end_dt IS NULL
				AND a.end_flg = 'Y'
            ");

            RunWhere(where.ToString());
        }

        public void RunForDVPC()
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@" 
                AND cm.move_start_dt IS NOT NULL
                AND cm.move_end_dt IS NOT NULL
                AND cm.delivery_dt IS NULL
            ");

            RunWhere(where.ToString());
        }

        public void RunForCompletedMoves()
        {
            StringBuilder where = new StringBuilder();

            where.AppendFormat(@" 
                AND cm.delivery_dt IS NOT NULL
            ");

            RunWhere(where.ToString());
        }

    }
}
