using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVendor
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1} {2}Active", Vendor_Cd, Vendor_Nm,
				(Active_Flg != "Y" ? "In" : null));
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			if (string.IsNullOrEmpty(Vendor_Cd) == true)
				_Errors["Vendor_Cd"] = "Missing or invalid vendor code";
			if (string.IsNullOrEmpty(Vendor_Nm) == true)
				_Errors["Vendor_Nm"] = "Missing or invalid vendor name";

			if (!ClsConvert.ValidateYN(Conus_Flg))
				_Errors["Conus_Flg"] = "Missing or invalid CONUS flag";

			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";

			/* We have all the fields, but for now do not validate
			StringBuilder sb = new StringBuilder();
			if (Address.ValidateAddress(this, sb) == false)
				_Errors["Address"] = sb.ToString();
			*/

			if (Contact.ValidateEmail(Email) == false)
				_Errors["Email"] = Contact.Error;
		}
		#endregion		// #region Validation

		#region Geo Regions

		public List<ClsVendorGeoRegion> GetAllowedVendorRegions()
		{
			if (Vendor_Cd.IsNullOrWhiteSpace()) return null;

			string sql = @"
			SELECT		vgr.*
			FROM		r_vendor_geo_region vgr
			WHERE		vgr.active_flg = 'Y' AND vgr.vendor_cd = @VEN_CD ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@VEN_CD", Vendor_Cd);

			return Connection.GetList<ClsVendorGeoRegion>(sql, p);
		}

		public List<ClsGeoRegion> GetAllowedRegions()
		{
			if (Vendor_Cd.IsNullOrWhiteSpace()) return null;

			string sql = @"
			SELECT		gr.*
			FROM		r_geo_region gr
			INNER JOIN	r_vendor_geo_region vgr		ON vgr.geo_region_cd = gr.geo_region_cd
			WHERE		gr.active_flg = 'Y' AND vgr.active_flg = 'Y'
			AND			vgr.vendor_cd = @VEN_CD ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@VEN_CD", Vendor_Cd);

			return Connection.GetList<ClsGeoRegion>(sql, p);
		}

		public string GetAllowedRegions(bool getDescriptions)
		{
			List<ClsGeoRegion> lst = GetAllowedRegions();
			if (lst == null || lst.Count <= 0) return null;

			StringBuilder sb = new StringBuilder();
			foreach (ClsGeoRegion rgn in lst)
			{
				string val = (getDescriptions) ? rgn.Geo_Region_Dsc : rgn.Geo_Region_Cd;
				sb.AppendFormat("{0}{1}", (sb.Length > 0 ? "," : null), val);
			}

			return sb.ToString();
		}

		public bool UpdateRegions(List<string> newRegionCodes)
		{
			ResetErrors();

			List<ClsGeoRegion> lstNew = new List<ClsGeoRegion>();
			if (newRegionCodes != null && newRegionCodes.Count > 0)
			{
				StringBuilder sb = new StringBuilder();
				foreach (string rc in newRegionCodes)
				{
					string rCode = rc.NullTrimUpper();
					if (rCode.IsNullOrWhiteSpace()) continue;

					ClsGeoRegion gr = ClsGeoRegion.GetUsingKey(rCode);
					if (gr == null)
					{
						sb.AppendFormat("Geo Region Code {0} not found\r\n", rCode);
						continue;
					}
					bool exists = lstNew.Exists(delegate(ClsGeoRegion lg)
					{ return string.Compare(lg.Geo_Region_Cd, gr.Geo_Region_Cd, true) == 0; });
					if (!exists) lstNew.Add(gr);
				}
				if (sb.Length > 0)
				{
					_Errors["Regions"] = sb.ToString();
					return false;
				}
			}
			List<ClsVendorGeoRegion> oldList = GetAllowedVendorRegions();

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsVendorGeoRegion venRgn in oldList)
				{
					bool exists = lstNew.Exists(delegate(ClsGeoRegion lg)
					{ return string.Compare(lg.Geo_Region_Cd, venRgn.Geo_Region_Cd, true) == 0; });
					if (exists) continue;	// If found in new list, do nothing

					venRgn.Delete();		// otherwise delete
				}

				foreach (ClsGeoRegion addRgn in lstNew)
				{
					bool exists = oldList.Exists(delegate(ClsVendorGeoRegion evnRgn)
					{ return string.Compare(evnRgn.Geo_Region_Cd, addRgn.Geo_Region_Cd, true) == 0; });
					if (exists) continue;	// If found in new list, do nothing

					// otherwise add
					ClsVendorGeoRegion venNew = new ClsVendorGeoRegion();
					venNew.SetDefaults();
					venNew.Geo_Region_Cd = addRgn.Geo_Region_Cd;
					venNew.Vendor_Cd = this.Vendor_Cd;
					venNew.Insert();
				}

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Geo Regions
	}

	#region Static Section

	partial class ClsVendor
	{
		public static DataTable GetVendors(bool userVendorsOnly)
		{
			string fromObject = (userVendorsOnly) ? "V_VENDOR ven" : "R_VENDOR ven";
			string sql = "SELECT ven.* FROM	" + fromObject;
			return Connection.GetDataTable(sql);
		}
	}
	#endregion		// #region Static Section
}