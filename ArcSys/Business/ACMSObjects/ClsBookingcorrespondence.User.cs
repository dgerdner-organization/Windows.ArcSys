using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingCorrespondence
	{
		public static DataTable GetForRequest(string sPartnerCd, string sPCFN)
		{
			string sql = string.Format(@"
			  SELECT  nvl(bc.corr_text, bc.corr_textlong) AS corr_body, bc.*,
				  r_correspondence_type.corr_dsc
			  FROM  T_BOOKING_CORRESPONDENCE bc,
				  T_BOOKING_REQUEST,
				  r_correspondence_type
			  WHERE
				  bc.corr_cd = r_correspondence_type.corr_cd and
				  trim(t_booking_request.partner_cd) = trim(bc.partner_cd) and
				  trim(t_booking_request.partner_request_cd) = trim(bc.partner_request_cd) and
				  t_booking_request.acms_status_cd <> 'A' and
							t_booking_request.partner_cd like '{0}' and
					t_booking_request.partner_request_cd like '{1}'
			ORDER BY bc.corr_dt",
					sPartnerCd, sPCFN);

			return Connection.GetDataTable(sql);
		}
		public static long NextID()
		{
			string sql = "select t_booking_correspondence_seq.nextval from dual";
			object oID = Connection.GetScalar(sql);
			long lID = ClsConvert.ToInt64(oID);
			return lID;
		}

		public static DataTable GetUnreadAcmsInbox(ClsConnection conn)
		{	// Dashboard method, expects connection object so as not to use the main connection
			string sql = @"
			SELECT	bc.corr_id, bc.partner_cd, bc.partner_request_cd, bc.corr_dt, bc.corr_text, bc.corr_cd,
					bc.attachment, bc.email_to, bc.email_sent, bc.corr_textlong, bc.email_from, bc.corr_user,
					bc.email_to_name, bc.email_from_name, NULL AS email_blob
			FROM	t_booking_correspondence bc
			WHERE	bc.corr_cd = 'EI'
			AND		bc.email_sent = 'N'
			ORDER BY
					bc.corr_dt, bc.corr_id ";

			return conn.GetDataTable(sql);
		}

		public override bool ValidateInsert()
		{
			return CommonValidation();
		}
		public override bool ValidateUpdate()
		{
			return CommonValidation();
		}

		public bool CommonValidation()
		{
			// Make sure only one Confirmation Note (type=N) and DIMS exists
			// Make sure Confirmation Notes are no longer than 600 characters
			if (this.Corr_Cd != "N"  && this.Corr_Cd != "DIMS")
				return true;
			
			DataTable dt = GetForRequest(this.Partner_Cd, this.Partner_Request_Cd);
			foreach (DataRow drow in dt.Rows)
			{
				ClsBookingCorrespondence c = new ClsBookingCorrespondence(drow);
				if (this.Corr_Cd == "N")
				{
					if (c.Corr_Cd == "N" && c.Corr_ID != this.Corr_ID)
					{
						if (!_Errors.ContainsKey("NOTES"))
						{
							this._Errors.Add("NOTES", "You can only have one correspondence of type 'Confirmation Note'");
						}
						return false;
					}
				}
				if (this.Corr_Cd == "DIMS")
				{
					if (c.Corr_Cd == "DIMS" && c.Corr_ID != this.Corr_ID)
					{
						this._Errors.Add("DIMS", "You can only have one correspondence of type 'Dimensions'");
						return false;
					}
				}
			}

			return true;
		}
	}
}
