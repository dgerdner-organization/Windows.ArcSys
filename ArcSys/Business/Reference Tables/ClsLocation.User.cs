using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLocation
	{
		#region Fields/Properties

		public bool IsLand { get { return Location_Type != null ? Location_Type.IsLand : false; } }
		public bool IsPort { get { return Location_Type != null ? Location_Type.IsPort : false; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
			Conus_Flg = "Y";
			Gate_Flg = "N";
			Border_Flg = "N";
			Hold_Area_Flg = "N";
			Checkpoint_Flg = "N";
		}

		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} - {2}, CONUS: {3}, {4}Active",
				Location_Cd, Location_Dsc, Location_Type_Cd, Conus_Flg,
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
			if (string.IsNullOrEmpty(Location_Cd) == true)
				_Errors["Location_Cd"] = "Missing or invalid location code";
			if (string.IsNullOrEmpty(Location_Type_Cd) == true)
				_Errors["Location_Type_Cd"] = "Missing or invalid location type code";
			if (string.IsNullOrEmpty(Location_Dsc) == true)
				_Errors["Location_Dsc"] = "Missing or invalid location description";
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid Active flag";

			if (!ClsConvert.ValidateYN(Conus_Flg))
				_Errors["Conus_Flg"] = "Missing or invalid CONUS flag";

			if (!ClsConvert.ValidateYN(Gate_Flg))
				_Errors["Gate_Flg"] = "Missing or invalid Gate flag";

			if (!ClsConvert.ValidateYN(Border_Flg))
				_Errors["Border_Flg"] = "Missing or invalid Border flag";

			if (!ClsConvert.ValidateYN(Hold_Area_Flg))
				_Errors["Hold_Area_Flg"] = "Missing or invalid Hold Area flag";

			if (!ClsConvert.ValidateYN(Checkpoint_Flg))
				_Errors["Checkpoint_Flg"] = "Missing or invalid Checkpoint flag";
		}
		#endregion		// #region Validation
	}

	#region Static Methods/Properties of ClsLocation



	partial class ClsLocation
	{
		private static ClsConnection ConnectionLine
		{
			get
			{
				if (ClsConMgr.Manager["LINE"] == null) ConnectToLINE();
				return ClsConMgr.Manager["LINE"];
			}
		}

		/// <summary>
		/// Returns locations for a user assigned to a vendor assigned to a geo_region
		/// </summary>
		/// <param name="LandPortType">Pass in either 'PORT','LAND' or null.</param>
		/// <returns></returns>
		public static DataTable GetGeoRegionLocations(string LandPortType)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM v_vendor_location WHERE 1=1 ");

			if (LandPortType.IsNotNull())
				sql.AppendFormat(" AND location_type_cd = '{0}'",LandPortType);

			return Connection.GetDataTable(sql.ToString());
		}

		public static DataTable GetVoyageLocations(string sVoyage, string sType)
		{
			string sql = string.Format(@"
			select v.voyage_cd,
				   v.location_cd,
				   l.location_dsc,
				   v.pol_pod,
				   v.terminal_cd,
				   l.location_dsc || ' - ' || v.terminal_cd as port_terminal
			 from mv_voyage_route_detail v
			  inner join r_location l
				on v.location_cd = l.location_cd
				  where voyage_cd = '{0}'
				  and pol_pod like '{1}' ", sVoyage, sType);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;

		}

		public static DataTable GetCargoTracking(string ConusFlg, string LandPortType)
		{
			StringBuilder sql = new StringBuilder(@"
				SELECT 
					*
				FROM
					r_location l
				WHERE
					1=1
			");

			if (ConusFlg.IsNotNull())
				sql.AppendFormat(" and l.conus_flg = '{0}'",ConusFlg);

			if (LandPortType.IsNotNull())
				sql.AppendFormat(" and l.location_type_cd = '{0}'",LandPortType); 
				
			sql.Append(" ORDER BY l.location_dsc");

			return Connection.GetDataTable(sql.ToString());
		}

		public static DataTable GetLocations(bool vendorLimited, string sType)
		{
			string from = (vendorLimited) ? "v_vendor_location" : "r_location";
			string where = "";
			if (!string.IsNullOrEmpty(sType))
				where = string.Format(" where location_type_cd = '{0}' ", sType);
			string sql = "SELECT * FROM " + from + where + " ORDER BY location_dsc ";
			return Connection.GetDataTable(sql);
		}
		public static DataTable GetLocations(bool vendorLimited)
		{
			return GetLocations(vendorLimited, null);
		}
		public static DataTable GetLocations(bool vendorLimited, bool portsOnly)
		{
			if (portsOnly)
				return GetLocations(vendorLimited, "PORT");
			return GetLocations(vendorLimited);
		}

		public static DataTable GetAllLocations()
		{
			string sql = @"
			SELECT	lt.location_type_dsc, gr.geo_region_dsc, loc.*
			FROM	r_location loc
				LEFT OUTER JOIN r_location_type lt	ON lt.location_type_cd = loc.location_type_cd
				LEFT OUTER JOIN r_geo_region gr		ON gr.geo_region_cd = loc.geo_region_cd
			ORDER BY loc.location_cd ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetLocationsByType(string sType)
		{
			string sql = string.Format(@"
				select * from r_location where location_type_cd = '{0}' ", sType);
			return Connection.GetDataTable(sql);
		}

		private static bool ConnectToLINE()
		{
			string sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
			ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
			line.DbConnectionKey = "LINE";
			ClsConMgr.Manager.AddConnection(line);
			return true;
		}

		public static DataTable GetTerminals(string sLocationCd)
		{
			string sql = string.Format(@"
				select * from v_location_terminal
				 where location_cd = '{0}' 
				   and delete_fl = 'N'
				 order by location_cd, default_fl desc, terminal_cd", sLocationCd);
			return Connection.GetDataTable(sql);
		}

		public static DataTable GetVoyageRouteDetails(string sVoyageNo, string sLocationCd, string sTerminalCd)
		{
			string sql = string.Format(@"
			   select * from mv_voyage_route_detail
				where voyage_cd = '{0}'
				 and location_cd = '{1}'
				 and terminal_cd = '{2}' ",
					sVoyageNo, sLocationCd, sTerminalCd);
			return Connection.GetDataTable(sql);
		}
		public static DataTable SearchLineLocations(string locCd, string locDsc)
		{
			ClsConnection cn = ConnectionLine;
			StringBuilder sb = new StringBuilder(@"
			SELECT	loc.lccode as location_cd, loc.lcname as location_dsc
			FROM	dba.lokation loc
			WHERE	loc.firma = 'ARC' ");

			if (locCd != null && !locCd.EndsWith("%") && !locCd.EndsWith("*"))
				locCd = locCd + "%";
			if (locDsc != null && !locDsc.EndsWith("%") && !locDsc.EndsWith("*"))
				locDsc = locDsc + "%";

			List<DbParameter> p = new List<DbParameter>();
			cn.AppendLikeClause(sb, p, "AND", "loc.lccode", "@LOC_CD", locCd);
			cn.AppendLikeClause(sb, p, "AND", "loc.lcname", "@LOC_DSC", locDsc);

			return cn.GetDataTable(sb.ToString(), p.ToArray());
		}
	}

	#endregion		// #region Static Methods/Properties of ClsLocation
}