using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	partial class ClsLocation
	{
		#region Fields/Properties


		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Delete_Fl = "N";
		}

		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0} - {1}, Census {2}, Census Type: {3}, {4}Active",
				Location_Cd, Location_Dsc, Census_Cd, Census_Type,
				(Delete_Fl == "Y" ? "In" : null));
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			if (!string.IsNullOrWhiteSpace(Location_Cd))
			{
				ClsLocation dup = GetUsingKey(Location_Cd);
				if (dup != null)
					_Errors["Location_Dup"] = Location_Cd + " already exists";
			}

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
			if (string.IsNullOrWhiteSpace(Location_Cd) == true)
				_Errors["Location_Cd"] = "Missing location code";
			if (string.IsNullOrWhiteSpace(Location_Dsc) == true)
				_Errors["Location_Dsc"] = "Missing location description";
			if (!ClsConvert.ValidateYN(Delete_Fl))
				_Errors["Delete_Fl"] = "Missing or invalid Delete flag";
		}

		public DataTable GetTerminals()
		{
			string sql = @"
			SELECT	term.*
			FROM	r_location_terminal term
			WHERE	term.location_cd = @LOC_CD ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@LOC_CD", Location_Cd);

			return Connection.GetDataTable(sql, p);
		}

		public override bool ValidateDelete()
		{
			_Errors.Clear();

			DataTable dt = GetTerminals();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["Location_Cd"] = "Cannot delete location, one or more terminals exist";

			return _Errors.Count == 0;
		}
		#endregion		// #region Validation

	}

	#region Static Section

	partial class ClsLocation
	{
		public static DataSet GetLocationPlusTerminals()
		{
			DataSet ds = new DataSet();

			DataTable dtLoc = ClsLocation.GetAllLocations();
			dtLoc.TableName = "Location";
			ds.Tables.Add(dtLoc);

			if (dtLoc.Rows.Count > 0)
			{
				DataTable dtTerminals = ClsLocationTerminal.GetAllTerminals();
				dtTerminals.TableName = "LocationTerminal";
				ds.Tables.Add(dtTerminals);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtLoc.Columns["LOCATION_CD"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtTerminals.Columns["LOCATION_CD"];

				ds.Relations.Add("LocationTerminal", dcPK, dcFK, false);
			}

			return ds;
		}

		public static DataTable GetAllLocations()
		{
			string sql = @"
			SELECT	loc.*
			FROM	r_location loc
			ORDER BY	loc.location_cd ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetDuplicateCensus(ClsConnection conn)
		{
			string sql = "select census_cd  from r_location group by census_cd  having count(census_cd) > 1";
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

        /// <summary>
        /// This will query the ACMS location table and return only records that have the 'OTHERCD_1'.
        /// This is also known as the 'Mil Stamp' Code.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetValidMilStampCodes()
        {
            string sql = @"
                Select *
                from r_location l
                where l.other1_cd is not null
                order by l.other1_cd";

            return Connection.GetDataTable(sql);

        }

	}
	#endregion		// #region Static Section
}