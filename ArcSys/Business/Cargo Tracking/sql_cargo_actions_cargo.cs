using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_cargo_actions_cargo : sql_base
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
                        c.conveyance_id,
                        cm.*,
                        last_action.*,
                        cm.required_dlvy_dt as rdd_dt,
						CASE 
						    WHEN cm.seal1 IS NULL THEN NULL
							WHEN cm.seal2 IS NULL THEN cm.seal1
							WHEN cm.seal3 IS NULL THEN cm.seal1 || ', ' || cm.seal2
							ELSE cm.seal1 || ', ' || cm.seal2 || ', ' || cm.seal3
						END AS SEAL
                    FROM
                        v_vendor_move vm
                        INNER JOIN v_vendor v ON v.vendor_cd = vm.vendor_cd
                        INNER JOIN t_move m ON m.move_id = vm.move_id
                        INNER JOIN t_cargo_move cm ON cm.vendor_move_id = vm.vendor_move_id
                        INNER JOIN t_conveyance c ON cm.conveyance_id = c.conveyance_id
                        LEFT OUTER JOIN t_cargo_action last_log_action ON cm.last_logistic_action_id = last_log_action.cargo_action_id
                        LEFT OUTER JOIN r_action a ON a.action_cd = last_log_action.action_cd
                        LEFT OUTER JOIN r_location last_location ON last_location.location_cd = last_log_action.location_cd
                        LEFT OUTER JOIN t_cargo_action last_action ON cm.last_cargo_action_id = last_action.cargo_action_id
                    WHERE 
                    1=1
                        AND m.active_flg = 'Y'
                        AND vm.active_flg = 'Y'
                        AND cm.active_flg = 'Y'
                        [WHERE]
                    ORDER BY 
                        cm.Serial_No

                ";
            }
        }

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
