using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ACMS.Business
{
	public static class ClsDropDowns
	{
		#region Connection Manager

		private static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		//
		// Cached datatables which, once populated, will be available for the duration of the session.
		//
		private static DataTable _ACMSStatusForSearch;
		public static DataTable ACMSStatusForSearch
		{
			get
			{
				if (_ACMSStatusForSearch != null)
					if (_ACMSStatusForSearch.Rows.Count > 0)
						return _ACMSStatusForSearch;
				_ACMSStatusForSearch = ClsAcmsStatus.GetAll();
				DataRow drow = _ACMSStatusForSearch.NewRow();
				drow["acms_status_cd"] = null;
				drow["acms_status_dsc"] = "(All)";
				_ACMSStatusForSearch.Rows.Add(drow);
				_ACMSStatusForSearch.DefaultView.Sort = "acms_status_cd";
				_ACMSStatusForSearch = _ACMSStatusForSearch.DefaultView.ToTable();
				return _ACMSStatusForSearch;
			}
			set
			{
				_ACMSStatusForSearch = value;
			}
		}
		private static DataTable _CurrentVoyages;
		public static DataTable CurrentVoyages
		{
			get
			{
				//if (_CurrentVoyages != null)
				//    return _CurrentVoyages;
				//_CurrentVoyages = ClsArcSQL.CurrentVoyageList();
				_CurrentVoyages = ClsVVoyage.GetVoyages(VoyageDaysOld);
				return _CurrentVoyages;
			}
		}
        private static Int32 _VoyageDaysOld = 60;
        public static Int32 VoyageDaysOld
        {
            get { return _VoyageDaysOld; }
            set { _VoyageDaysOld = value; }
        }
		private static DataTable _CurrentVoyagesImmediate;
		public static DataTable CurrentVoyagesImmediate
		{
			get
			{
				//if (_CurrentVoyagesImmediate != null)
				//    return _CurrentVoyagesImmediate;
				_CurrentVoyagesImmediate = ClsVVoyage.GetVoyagesImmediate(VoyageDaysOld);
				return _CurrentVoyagesImmediate;
			}
		}
		private static DataTable _AllVoyages;
		public static DataTable	AllVoyages
		{
			get
			{
				if (_AllVoyages != null)
					return _AllVoyages;
				_AllVoyages = ClsVVoyage.GetVoyages(2000);
				return _AllVoyages;
			}
		}

		private static DataTable _CommodityDescriptions;
		public static DataTable CommodityDescriptions
		{
			get
			{
				if (_CommodityDescriptions != null)
					return _CommodityDescriptions;
				_CommodityDescriptions = ClsCommodityDsc.GetAll();
				return _CommodityDescriptions;
			}
		}
		private static DataTable _RevenueCodes;
		public static DataTable RevenueCodes
		{
			get
			{
				if (_RevenueCodes != null)
					return _RevenueCodes;
				_RevenueCodes = ClsRevenueCode.GetAll();
				return _RevenueCodes;
			}
		}
		private static DataTable _CargoCodes;
		public static DataTable CargoCodes
		{
			get
			{
				if (_CargoCodes == null)
					_CargoCodes = ClsCargoCode.GetAllActive();
				return _CargoCodes;
			}
		}

		private static DataTable _MoveTypes;
		public static DataTable MoveTypes
		{
			get
			{
				if (_MoveTypes != null)
					return _MoveTypes;
				string sql = string.Format(@"
					 select '' as move_type_cd from dual
					 union all
					 select 'F1' as move_type_cd from dual
					 union all
					 select 'F2' from dual
					 union all
					 select 'F3' from dual
					 union all
					 select 'F4' from dual
					 union all
					 select 'F5' from dual
					 union all
					  select 'F6' from dual
					 union all
					 select 'F7' from dual
					 union all
					 select 'F8' from dual 
					 union all
					  select 'F9' from dual");
				_MoveTypes = Connection.GetDataTable(sql);
				return _MoveTypes;
			}
		}

		private static DataTable _MMYY;
		public static DataTable MMYY
		{
			get
			{
				if (_MMYY != null)
					return _MMYY;
				try
				{
					string sql = string.Format(@"
					select to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MM') as mmyy_val,
					 to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MON') as mmyy_dsc
					 from t_booking_request 
					 group by to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MM'),
					 to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MON')
					  order by to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MM') desc ");
					_MMYY = Connection.GetDataTable(sql);
					return _MMYY;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					return null;
				}
			}
		}
	}
}
