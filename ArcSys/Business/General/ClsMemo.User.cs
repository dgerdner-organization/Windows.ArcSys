using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMemo
	{
		#region Fields/Properties

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Ven_Visible_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			try
			{
				string txt = Memo_Txt.NullTrim();
				if (txt != null && txt.Length > 50) txt = txt.Substring(0, 50);
				return string.Format("{0}: {1} - {2}", Memo_ID, Memo_Dsc, txt);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return Memo_ID.ToString();
			}
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
			if (string.IsNullOrWhiteSpace(Memo_Dsc) == true)
				_Errors["Memo_Dsc"] = "Missing memo title/description";
			if (string.IsNullOrWhiteSpace(Memo_Txt) == true)
				_Errors["Memo_Txt"] = "Missing memo body";
			if( !ClsConvert.ValidateYN(Ven_Visible_Flg) )
				_Errors["Ven_Visible_Flg"] = "Missing or invalid vendor visible flag";
		}

		public override bool ValidateDelete()
		{
			_Errors.Clear();

			if (Memo_ID == null)
			{
				_Errors["Memo_ID"] = "Memo does not exist";
				return false;
			}

			string sql = @"
			SELECT	COUNT(ma.memo_attachment_id)
			FROM	t_memo_attachment ma
			WHERE	ma.memo_id = @MM_ID";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@MM_ID", Memo_ID.Value);

			object o = Connection.GetScalar(sql, p);
			long? count = ClsConvert.ToInt64Nullable(o);
			if (count.GetValueOrDefault(0) > 0)
				_Errors["Memo"] = "Cannot delete memo, attachments exist.\r\nRemove all attachments then try again.";

			return _Errors.Count == 0;
		}
		#endregion		// #region Validation

		public List<ClsMemoAttachment> AddMemo(List<ClsMemoAttachment> attachments)
		{
			ResetWarnings();

			Insert();
			if (attachments == null || attachments.Count <= 0) return null;	// Done

			List<ClsMemoAttachment> addedList = new List<ClsMemoAttachment>();
			StringBuilder sb = new StringBuilder();
			foreach (ClsMemoAttachment ma in attachments)
			{
				try
				{
					ma.Memo_ID = Memo_ID;
					ma.Insert();
					addedList.Add(ma);
				}
				catch (Exception ex)
				{
					string exMsg = ClsErrorHandler.LogException(ex);
					AddWarning("Unable to add attachment {0}\r\n{1}", ma.Attachment_Nm, exMsg);
				}
			}

			return addedList;	// return the attachments that were actually added
		}

		public List<ClsMemoAttachment> AddAttachments(List<ClsMemoAttachment> attachments)
		{
			ResetErrors();
			ResetWarnings();
			if (Memo_ID == null)
			{
				_Errors["Memo_ID"] = "No memo provided";
				return null;
			}

			if (attachments == null || attachments.Count <= 0)
			{
				_Errors["Att"] = "No attachments were specified";
				return null;
			}

			List<ClsMemoAttachment> addedList = new List<ClsMemoAttachment>();
			StringBuilder sb = new StringBuilder();
			foreach (ClsMemoAttachment ma in attachments)
			{
				try
				{
					ma.Memo_ID = Memo_ID;
					ma.Insert();
					addedList.Add(ma);
				}
				catch (Exception ex)
				{
					string exMsg = ClsErrorHandler.LogException(ex);
					AddWarning("Unable to add attachment {0}\r\n{1}", ma.Attachment_Nm, exMsg);
				}
			}

			return addedList;	// return the attachments that were actually added
		}

		public int GetAttachmentCount()
		{
			if (Memo_ID == null) return 0;

			string sql = @"
			SELECT	COUNT(ma.memo_attachment_id) AS att_count
			FROM	t_memo_attachment ma
			WHERE	ma.memo_id = @MM_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@MM_ID", Memo_ID.Value);

			object o = Connection.GetScalar(sql, p);
			int? count = ClsConvert.ToInt32Nullable(o);
			return count.GetValueOrDefault(0);
		}
	}

	#region Static Methods of ClsMemo

	partial class ClsMemo
	{
		public static DataSet GetMemosDS(string memoDsc, string memoTxt, string fileNm,
			DateRange created)
		{
			DataSet ds = new DataSet();

			DataTable dtMemos = GetMemos(memoDsc, memoTxt, fileNm, created);
			ds.Tables.Add(dtMemos);

			if (dtMemos.Rows.Count > 0)
			{
				DataTable dtActs = GetMemoAttachments(memoDsc, memoTxt, fileNm, created);
				ds.Tables.Add(dtActs);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtMemos.Columns["MEMO_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtActs.Columns["MEMO_ID"];

				ds.Relations.Add("MemoAttachments", dcPK, dcFK, false);
			}

			return ds;
		}

		public static DataTable GetMemos(string memoDsc, string memoTxt, string fileNm,
			DateRange created)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	mm.*,
					(	SELECT	COUNT(DISTINCT ma.memo_attachment_id)
						FROM	t_memo_attachment ma
						WHERE	ma.memo_id = mm.memo_id) AS att_count
			FROM	t_memo mm
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendLikeClause(sb, p, "AND", "upper(mm.memo_dsc)", "@MM_DSC",
				ClsConvert.ReplaceWildCard(memoDsc, true, true));
			Connection.AppendLikeClause(sb, p, "AND", "upper(mm.memo_txt)", "@MM_TXT",
				ClsConvert.ReplaceWildCard(memoTxt, true, true));
			Connection.AppendDateClause(sb, p, "AND", "mm.create_dt", "@CR_FR", "@CR_TO", created);

			if (!fileNm.IsNullOrWhiteSpace())
			{
				sb.AppendFormat(@"
				AND EXISTS (
					SELECT	'X'
					FROM	t_memo_attachment ma
					WHERE	ma.memo_id = mm.memo_id AND upper(ma.attachment_nm) like '{0}'
					) ", ClsConvert.ReplaceWildCard(fileNm, true, true));
			}

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Memos";
			}
			return dt;
		}

		public static DataTable GetMemoAttachments(string memoDsc, string memoTxt, string fileNm,
			DateRange created)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	ma.memo_attachment_id, ma.memo_id, ma.attachment_nm,
					ma.create_dt, ma.create_user
			FROM	t_memo_attachment ma
			WHERE	1 = 1 ");

			if (!memoDsc.IsNullOrWhiteSpace() || !memoTxt.IsNullOrWhiteSpace() ||
				!fileNm.IsNullOrWhiteSpace() || !created.IsEmpty)
			{
				sb.Append(@"
				AND ma.memo_id IN (
					SELECT	mm.memo_id
					FROM	t_memo mm
					WHERE 1 = 1 ");
				Connection.AppendLikeClause(sb, p, "AND", "upper(mm.memo_dsc)", "@MM_DSC",
					ClsConvert.ReplaceWildCard(memoDsc, true, true));
				Connection.AppendLikeClause(sb, p, "AND", "upper(mm.memo_txt)", "@MM_TXT",
					ClsConvert.ReplaceWildCard(memoTxt, true, true));

				if (!fileNm.IsNullOrWhiteSpace())
				{
					sb.AppendFormat(@"
					AND EXISTS (
						SELECT	'X'
						FROM	t_memo_attachment ma
						WHERE	ma.memo_id = mm.memo_id AND upper(ma.attachment_nm) like '{0}'
						) ", ClsConvert.ReplaceWildCard(fileNm, true, true));
				}
				sb.Append(")");		// Closing IN
			}

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "MemoAttachments";
			}
			return dt;
		}
	}
	#endregion		// #region Static Methods of ClsMemo
}