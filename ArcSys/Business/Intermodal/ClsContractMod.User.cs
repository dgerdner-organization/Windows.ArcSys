using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public partial class ClsContractMod
	{
		#region Fields/Properties

		public string Mod_ID_No_Attachment_Nm
		{
			get
			{
				return string.Format("{0}: {1} - {2}", Contract_Mod_ID, Mod_No,
					(string.IsNullOrWhiteSpace(Attachment_Nm) ? "<No Attachment>" : Attachment_Nm));
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} - {2}", Contract_Mod_ID, Mod_No, Attachment_Nm);
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
			if (string.IsNullOrEmpty(Mod_No) == true)
				_Errors["Mod_No"] = "Missing Mod #";
		}

		public override bool ValidateDelete()
		{
			_Errors.Clear();

			if (Contract_Mod_ID == null)
			{
				_Errors["Contract_Mod_ID"] = "Contract mod does not exist";
				return false;
			}

			string sql = @"
			SELECT	COUNT(c.cargo_id)
			FROM	t_cargo c
			WHERE	c.contract_mod_id = @CM_ID";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CM_ID", Contract_Mod_ID.Value);

			object o = Connection.GetScalar(sql, p);
			long? count = ClsConvert.ToInt64Nullable(o);
			if (count.GetValueOrDefault(0) > 0)
				_Errors["Cargo"] = "Cannot delete mod, there is cargo assigned to it.\r\nRemove all cargo then try again.";

			return _Errors.Count == 0;
		}
		#endregion		// #region Validation

		#region Cargo

		public bool AssignMod(DataRow[] cargoActRows)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to assign to a contract mod";
				return false;
			}

			StringBuilder sb = new StringBuilder();
			List<ClsCargo> lstCargo = new List<ClsCargo>();
			foreach (DataRow dr in cargoActRows)
			{
				dr.ClearErrors();
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				ClsCargo c = ( ca != null ) ? ca.Cargo : null;
				if (c == null) continue;

				if (c.Contract_Mod_ID != null)
				{
					if (Contract_Mod_ID != null && Contract_Mod_ID == c.Contract_Mod_ID)
						sb.AppendFormat("Cargo {0} is already assigned to this mod\r\n",
							c.Serial_No);
					else
						sb.AppendFormat("Cargo {0} is already assigned to a Mod {1} (ID {2})\r\n",
							c.Serial_No, c.Contract_Mod.Mod_No, c.Contract_Mod.Contract_Mod_ID);
					continue;
				}

				if( !lstCargo.Exists(delegate(ClsCargo cgo){return cgo.Cargo_ID == c.Cargo_ID;}))
					lstCargo.Add(c);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Contract_Mod"] = sb.ToString();
				return false;
			}

			if (lstCargo.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo provided to be assigned";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				if (Contract_Mod_ID == null)
					Insert();

				foreach (ClsCargo c in lstCargo)
				{
					c.Contract_Mod_ID = Contract_Mod_ID;
					c.Update();
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
		#endregion		// #region Cargo
	}

	#region Static Methods of ClsContractMod

	partial class ClsContractMod
	{
		public static ClsContractMod GetUsingModNo(string modNo)
		{
			string sql = @"
			SELECT	cm.*
			FROM	t_contract_mod cm
			WHERE	cm.mod_no = @MOD_NO ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@MOD_NO", modNo);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsContractMod(dr) : null;
		}

		public static DataSet GetModsDS(string modNo, string notes, string fileNm, DateRange created)
		{
			DataSet ds = new DataSet();

			DataTable dtMods = GetMods(modNo, notes, fileNm, created);
			ds.Tables.Add(dtMods);

			if (dtMods.Rows.Count > 0)
			{
				DataTable dtActs = GetModActivities(modNo, notes, fileNm, created);
				ds.Tables.Add(dtActs);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtMods.Columns["CONTRACT_MOD_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtActs.Columns["CONTRACT_MOD_ID"];

				ds.Relations.Add("ContractModActivities", dcPK, dcFK, false);
			}

			return ds;
		}

		public static DataTable GetMods(string modNo, string notes, string fileNm, DateRange created)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	cm.*,
					(select	count(distinct c.cargo_id)
					from	t_cargo c
					where c.contract_mod_id = cm.contract_mod_id) as cargo_count
			FROM	t_contract_mod cm
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendLikeClause(sb, p, "AND", "cm.mod_no", "@MD_NO", modNo);
			Connection.AppendLikeClause(sb, p, "AND", "cm.mod_notes", "@M_NTS",
				ClsConvert.ReplaceWildCard(notes, true, true));
			Connection.AppendLikeClause(sb, p, "AND", "cm.attachment_nm", "@FL_NM", fileNm);
			Connection.AppendDateClause(sb, p, "AND", "cm.create_dt", "@CR_FR", "@CR_TO", created);

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ContractMods";
			}
			return dt;
		}

		public static DataTable GetModActivities(string modNo, string notes, string fileNm,
			DateRange created)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	cm.*, c.cargo_id, c.booking_id, c.serial_no, c.commodity_cd, c.pkg_type_cd,
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					bk.booking_no, bk.booking_ref,
					bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt,
					plor.location_dsc as plor_location_dsc, pol.location_dsc as pol_location_dsc,
					pod.location_dsc as pod_location_dsc, plod.location_dsc as plod_location_dsc,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					ca.cargo_activity_id, ca.orig_location_cd, ca.dest_location_cd,
					ca.billable_flg, ca.estimate_id, ca.vendor_cd,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					est.estimate_no
			FROM	t_contract_mod cm
				INNER JOIN t_cargo c				ON c.contract_mod_id = cm.contract_mod_id
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
				INNER JOIN r_location plor			ON plor.location_cd = bk.plor_location_cd
				INNER JOIN r_location pol			ON pol.location_cd = bk.pol_location_cd
				INNER JOIN r_location pod			ON pod.location_cd = bk.pod_location_cd
				INNER JOIN r_location plod			ON plod.location_cd = bk.plod_location_cd
				INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_cargo_activity ca
					INNER JOIN r_location oloc		ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc		ON dloc.location_cd = ca.dest_location_cd
													ON ca.cargo_id = c.cargo_id
				LEFT OUTER JOIN t_estimate est		ON est.estimate_id = ca.estimate_id
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendLikeClause(sb, p, "AND", "cm.mod_no", "@MD_NO", modNo);
			Connection.AppendLikeClause(sb, p, "AND", "cm.mod_notes", "@M_NTS",
				ClsConvert.ReplaceWildCard(notes, true, true));
			Connection.AppendLikeClause(sb, p, "AND", "cm.attachment_nm", "@FL_NM", fileNm);
			Connection.AppendDateClause(sb, p, "AND", "cm.create_dt", "@CR_FR", "@CR_TO", created);

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
			}
			return dt;
		}
	}
	#endregion		// #region Static Methods of ClsContractMod
}