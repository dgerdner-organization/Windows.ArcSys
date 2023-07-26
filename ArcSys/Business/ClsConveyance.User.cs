using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsConveyance
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Futile_Flg = "N";
		}

		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			try
			{
				return string.Format("{0}: {1} {2} {3} {4}",
					Conveyance_ID, Vendor_Move_ID, Conveyance_No, Truck_No, Futile_Flg);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return Conveyance_No;
			}
		}

		public string ToString(string detailStr)
		{
			try
			{
				StringBuilder sb = null;
				ClsVendorMove vm = null;
				switch (detailStr)
				{
					case "t": return Conveyance_No;
					case "tc": return string.Format("{0} {1}", Conveyance_No, Truck_No);

					case "f":
						vm = Vendor_Move;
						sb = new StringBuilder();
						sb.AppendFormat("{0} {1}", Conveyance_No, Truck_No);
						if (vm != null)
						{
							sb.AppendFormat(" {0} {1}", vm.Vendor_Cd, vm.Orig_Dest_Dsc);
						}
						if (ClsConvert.YNToBool(Futile_Flg)) sb.Append(" Futile");
						return sb.ToString();

					default: return this.ToString();
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return Conveyance_No;
			}
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			return ValidateInsert(true);
		}

		public override bool ValidateUpdate()
		{
			return ValidateUpdate(true);
		}

		public bool ValidateInsert(bool checkTruckNoExists)
		{
			_Errors.Clear();
			ResetWarnings();

			CommonValidation(true);

			return _Errors.Count == 0;
		}

		public bool ValidateUpdate(bool checkTruckNoExists)
		{
			_Errors.Clear();
			ResetWarnings();

			CommonValidation(checkTruckNoExists);

			return _Errors.Count == 0;
		}

		private void CommonValidation(bool checkConveyNoExists)
		{
			if (Vendor_Move_ID == null)
				_Errors["Vendor_Move_ID"] = "Missing vendore move ID";
			if (string.IsNullOrWhiteSpace(Conveyance_No) == true)
				_Errors["Conveyance_No"] = "Missing BOL/Job #";
			if (string.IsNullOrWhiteSpace(Truck_No) == true)
				_Errors["Truck_No"] = "Missing truck #";
			if (!ClsConvert.ValidateYN(Futile_Flg))
				_Errors["Futile_Flg"] = "Missing or invalid futile flag";
			else if (Futile_Flg == "Y")
			{
				if (Conveyance_ID != null)
				{
					long cargoCount = GetActiveCargoCount();
					if (cargoCount > 0)
						_Errors["Futile_Flg"] =
							"Cannot make this truck futile, there is cargo assigned to it";
				}
			}

			if (checkConveyNoExists)
			{
				ClsVendorMove vmv = Vendor_Move;
				if( vmv != null && !string.IsNullOrWhiteSpace(Conveyance_No))
				{
					List<ClsConveyance> lst = ClsConveyance.GetByConveyanceNo(Conveyance_No,
						vmv.Vendor_Cd, Conveyance_ID);
					if (lst != null && lst.Count > 0)
						AddWarning("BOL/Job # {0} already exists", Conveyance_No);
				}
			}
		}
		#endregion		// #region Validation

		#region Add/Remove Cargo

		public bool AddCargo(DataRow[] rows)
		{
			ResetErrors();
			if (rows == null || rows.Length <= 0)
			{
				_Errors["Count"] = "Cannot create conveyance, no cargo rows provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				if (Conveyance_ID == null)
					Insert();
				else
					Update();

				foreach (DataRow dr in rows)
				{
					ClsCargoMove cmv = new ClsCargoMove(dr);
					cmv.Conveyance_ID = Conveyance_ID;
					cmv.Update();
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

		public bool AddCargoToConveyance(DataRow[] rows, bool createNew)
		{
			ResetErrors();
			if (rows == null || rows.Length <= 0)
			{
				_Errors["Count"] = "Cannot create conveyance, no cargo rows provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				if (createNew)
					Insert();
				else
					Update();

				foreach (DataRow dr in rows)
				{
					ClsCargoMove cmv = new ClsCargoMove(dr);
					cmv.Conveyance_ID = Conveyance_ID;
					cmv.Update();
				}

				if( newTx == true ) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Add/Remove Cargo

		public DataTable GetActiveCargo()
		{
			string sql = @"
			SELECT	cmv.*
			FROM	t_cargo_move cmv
			WHERE	cmv.conveyance_id = @CNV_ID AND cmv.active_flg = 'Y' ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CNV_ID", Conveyance_ID.GetValueOrDefault(-1));

			return Connection.GetDataTable(sql, p);
		}

		public long GetActiveCargoCount()
		{
			string sql = @"
			SELECT	cmv.*
			FROM	t_cargo_move cmv
			WHERE	cmv.conveyance_id = @CNV_ID AND cmv.active_flg = 'Y' ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CNV_ID", Conveyance_ID.GetValueOrDefault(-1));

			object o = Connection.GetScalar(sql, p);
			long? activeCount = ClsConvert.ToInt64Nullable(o);
			return activeCount.GetValueOrDefault(0);
		}

		#region Extended Properties

		private int? _TruckCount;
		public int TruckCount
		{
			get
			{
				if (_TruckCount != null)
					return (int)_TruckCount;
				string sql = string.Format(@"
					select count(*) from t_cargo_activity 
					  where conveyance_id = {0} ", this.Conveyance_ID);

				object objReturn = Connection.GetScalar(sql);
				if (objReturn == null)
					_TruckCount = 0;
				else
				{
					_TruckCount = Convert.ToInt32(objReturn);
				}
				return (int) _TruckCount;
			}
		}

		public List<ClsCargoMove> ListOfCargoMoves
		{
			get
			{
				if (Conveyance_ID == null) return null;

				string sql = string.Format(@"
					SELECT
					*
					FROM
					t_cargo_move cm
					WHERE
					cm.conveyance_id = {0}", Conveyance_ID);

				return Connection.GetList<ClsCargoMove>(sql);

			}
		}

		public bool IsConveyanceActive()
		{
			if( Conveyance_ID == null ) return false;

			string sql = @"
			SELECT	COUNT(*)
			FROM	t_cargo_move cmv
			WHERE	cmv.CONVEYANCE_ID = @CNVY_ID AND cmv.ACTIVE_FLG = 'Y'";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CNVY_ID", Conveyance_ID.Value);

			object o = Connection.GetScalar(sql, p);
			long? count = ClsConvert.ToInt64Nullable(o);

			return count.GetValueOrDefault(0) > 0;
		}
		#endregion		// #region Extended Properties
	}

	#region Static Methods/Properties of ClsConveyance

	partial class ClsConveyance
	{
		public static List<ClsConveyance> GetByConveyanceNo(string conveyNo, string vendorCd,
			long? excludeConveyID)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	cnv.*
			FROM	t_conveyance cnv
			INNER JOIN t_vendor_move vmv	ON vmv.vendor_move_id = cnv.vendor_move_id
			WHERE	cnv.conveyance_no = @CNVY_NO AND vmv.vendor_cd = @VEN_CD ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@CNVY_NO", conveyNo));		// required
			p.Add(Connection.GetParameter("@VEN_CD", vendorCd));		// required
			Connection.AppendNotEqualClause(sb, p, "AND",				// optional
				"cnv.conveyance_id", "@CNV_ID", excludeConveyID);

			sb.Append(@"
			ORDER BY cnv.sequence_nbr, cnv.create_dt ");

			return Connection.GetList<ClsConveyance>(sb.ToString(), p.ToArray());
		}

		/// <summary>Gets a list of conveyances for the given vendor move. Vendor move ID is
		/// required, the futile flag is optional </summary>
		/// <param name="vendorMoveID">The vendor move for which to return the conveyances</param>
		/// <param name="futileFlg">Optional parameter to filter returned datatable based on
		/// the Futile_Flg column. To bring back all conveyances specify null.</param>
		public static DataTable GetVendorMoveConveyances(long vendorMoveID, string futileFlg)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	mv.trading_partner_cd, tp.partner_dsc, mv.move_dsc, vmv.vendor_cd,
					vmv.orig_location_cd, oloc.location_dsc AS orig_location_dsc,
					vmv.dest_location_cd, dloc.location_dsc AS dest_location_dsc,
					cnv.conveyance_no || ' ' || cnv.truck_no || ' ' || tp.partner_dsc || ' ' || mv.move_dsc || ' ' ||
						oloc.location_dsc || ' to ' || dloc.location_dsc AS extra_dsc,
					cnv.*
			FROM	t_conveyance cnv
				INNER JOIN v_vendor_move vmv		ON vmv.vendor_move_id = cnv.vendor_move_id
				INNER JOIN t_move mv				ON mv.move_id = vmv.move_id
				INNER JOIN r_location oloc			ON oloc.location_cd = vmv.orig_location_cd
				INNER JOIN r_location dloc			ON dloc.location_cd = vmv.dest_location_cd
				INNER JOIN r_trading_partner tp		ON tp.trading_partner_cd = mv.trading_partner_cd
			WHERE cnv.vendor_move_id = @VMV_ID ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@VMV_ID", vendorMoveID));
			Connection.AppendEqualClause(sb, p, "AND", "cnv.futile_flg", "@FT_FLG", futileFlg);

			sb.Append(@"
			ORDER BY	cnv.conveyance_no, tp.partner_dsc, mv.move_dsc, oloc.location_dsc,
						dloc.location_dsc ");

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}
	}
	#endregion		// #region Static Methods/Properties of ClsConveyance
}