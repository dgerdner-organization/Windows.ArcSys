using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ARC.EDISQLTools
{
	public class ClsProtocol
	{
		public static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["LINE"]; }
		}

		public static DataTable GetProtocol(ProtocolParameters pps)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	dba.edi_protocol_detail.epddatum AS create_dt_epddatum,
					ltrim(rtrim(dba.edi_protocol_detail.epdbunr)) AS booking_no_epdbunr,
					ltrim(rtrim(dba.edi_protocol_detail.epdreport)) AS msg_dsc_epdreport,
					ltrim(rtrim(dba.edi_protocol_detail.epdmsgtext)) AS msg_txt,
					ltrim(rtrim(dba.edi_protocol_detail.epddettext)) AS detail_epddettext,
					ltrim(rtrim(dba.edi_protocol_detail.epdrefnr)) AS ref_no_epdrefnr,
					ltrim(rtrim(dba.edi_protocol_detail.epdvessel)) AS vessel,
					ltrim(rtrim(dba.edi_protocol_detail.epdvoyage)) AS voyage,
					ltrim(rtrim(dba.edi_protocol_detail.epdpolcde)) AS pol,
					ltrim(rtrim(dba.edi_protocol_detail.epdpodcde)) AS pod,
					ltrim(rtrim(dba.edi_protocol_detail.epdmsgid)) AS msg_id,
					ltrim(rtrim(dba.edi_protocol_detail.epdstatus)) AS status,
					ltrim(rtrim(dba.edi_protocol.epkfilename)) AS filename
			FROM	dba.edi_protocol
				INNER JOIN dba.edi_protocol_relation	ON	dba.edi_protocol.firma = dba.edi_protocol_relation.firma AND
															dba.edi_protocol.epkepmanr = dba.edi_protocol_relation.eprepmanr
				INNER JOIN dba.edi_protocol_detail		ON	dba.edi_protocol_relation.firma = dba.edi_protocol_detail.firma AND
															dba.edi_protocol_relation.eprlfnr = dba.edi_protocol_detail.epdrelfnr AND
															dba.edi_protocol_relation.eprepmanr = dba.edi_protocol_detail.epdepmanr
			WHERE	epddatum > getdate() - 14");

			List<DbParameter> p = new List<DbParameter>();
			AppendWhere(sb, p, pps);

			sb.Append("ORDER BY dba.edi_protocol_detail.epddatum DESC");
			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static void AppendWhere(StringBuilder sb, List<DbParameter> p,
			ProtocolParameters pps)
		{
			Connection.AppendLikeClause(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol.epkfilename))", "@FL_NM", pps.Filename);
			if( !string.IsNullOrEmpty(pps.File_Exists_Flg) )
			{
				if( pps.File_Exists_Flg == "Y" )
					sb.Append("AND (dba.edi_protocol.epkfilename IS NOT NULL) ");
				else
					sb.Append("AND (dba.edi_protocol.epkfilename IS NULL) ");
			}

			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdmsgid))", "@MSG_IDN", pps.Msg_ID);
			Connection.AppendLikeClause(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdmsgtext))", "@MSG_TX", pps.Msg_TxtDbParam);
			Connection.AppendLikeClause(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epddettext))", "@DT_TX", pps.Detail_TxtDbParam);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdstatus))", "@PT_ST", pps.Protocol_Type);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdreport))", "@FL_NM", pps.Msg_Dsc);
			Connection.AppendDateClauseSqlServer(sb, p, "AND",
				"dba.edi_protocol_detail.epddatum", "@CR_FR", "@CR_TO", pps.Create_Dt);

			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdbunr))", "@BU_NO", pps.Booking_No);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdvessel))", "@VESS", pps.Vessel);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdvoyage))", "@VOY_NO", pps.Voyage);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdpolcde))", "@PL_CD", pps.POL_CDs);
			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdpodcde))", "@PD_CD", pps.POD_CDs);

			Connection.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(dba.edi_protocol_detail.epdrefnr))", "@RF_NO", pps.Reference_No);

		}
	}

	#region Protocol Parameters

	public class ProtocolParameters
	{
		public string Filename;
		public string File_Exists_Flg;

		public string Msg_ID;
		public string Msg_Dsc;
		public string Msg_Txt;
		public string Detail_Txt;
		public string Protocol_Type;
		public DateRange Create_Dt;

		public string Booking_No;
		public string Vessel;
		public string Voyage;
		public string POL_CDs;
		public string POD_CDs;
		public string PCFN;
		public string TCN;
		public string Reference_No;
		public bool IncludeWarnings;
		public bool OnDelay;
		public bool IncludeBooked;

		public void Clear()
		{
			File_Exists_Flg = Filename = null;
			Msg_ID = Msg_Dsc = Msg_Txt = Detail_Txt = Protocol_Type = null;
			Create_Dt.Clear();

			Booking_No = Vessel = Voyage = POL_CDs = POD_CDs = Reference_No = null;
		}

		public string Msg_TxtDbParam
		{
			get
			{
				if( string.IsNullOrEmpty(Msg_Txt) ) return null;
				if( Msg_Txt.StartsWith("%") && Msg_Txt.EndsWith("%") ) return Msg_Txt;
				if( Msg_Txt.StartsWith("%") && !Msg_Txt.EndsWith("%") ) return Msg_Txt + "%";
				if( !Msg_Txt.StartsWith("%") && Msg_Txt.EndsWith("%") ) return "%" + Msg_Txt;
				return "%" + Msg_Txt + "%";
			}
		}

		public string Detail_TxtDbParam
		{
			get
			{
				if( string.IsNullOrEmpty(Detail_Txt) ) return null;
				if( Detail_Txt.StartsWith("%") && Detail_Txt.EndsWith("%") ) return Detail_Txt;
				if( Detail_Txt.StartsWith("%") && !Detail_Txt.EndsWith("%") ) return Detail_Txt + "%";
				if( !Detail_Txt.StartsWith("%") && Detail_Txt.EndsWith("%") ) return "%" + Detail_Txt;
				return "%" + Detail_Txt + "%";
			}
		}
	}
	#endregion		// #region Protocol Parameters
}