using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsTerminalContact
	{
		#region Fields/Properties

		public string Section_Dsc
		{
			get { return (Terminal_Section != null) ? Terminal_Section.Terminal_Section_Dsc : null; }
		}

		public string Description
		{
			get
			{
				string sec = Section_Dsc;
				bool blankTerm = string.IsNullOrWhiteSpace(Terminal_Cd),
					blankSec = string.IsNullOrWhiteSpace(sec);
				string sep1 = (!blankTerm && !blankSec) ? " " : null;
				string sep2 = (!blankTerm || !blankSec) ? " " : null;
				return string.Format("{0}{1}{2}{3}Contact",
					Terminal_Cd, sep1, sec, sep2);
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public ClsTerminalContact(string sectionCd)
		{
			ResetColumns();
			SetDefaults();
			Terminal_Section_Cd = sectionCd;
		}

		public override void SetDefaults()
		{
			ResetColumns();

			Active_Flg = "Y";
		}
		#endregion		// #region Constructors/Initialization

		#region ToString

		public override string ToString()
		{
			try
			{
				return string.Format("{0} {1}: {2} {3} {4} {5} {6} (id{7})",
					Description, Sequence_Nbr, Phone_Dsc, Phone,
					(string.IsNullOrWhiteSpace(Phone_Ext) ? null : "x" + Phone_Ext),
					Contact_Nm, ClsConvert.YNToActiveInactive(Active_Flg), Terminal_Contact_ID);
			}
			catch
			{
				return base.ToString();
			}
		}
		#endregion		// #region ToString

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
			if (string.IsNullOrEmpty(Terminal_Cd) == true)
				_Errors["Terminal_Cd"] = "Missing terminal code";
			if (string.IsNullOrEmpty(Terminal_Section_Cd) == true)
				_Errors["Terminal_Section_Cd"] = "Missing section";
			if( Sequence_Nbr.GetValueOrDefault(0) < 1 )
				_Errors["Sequence_Nbr"] = "Missing or invalid sequence number (must be > 0)";
			if (string.IsNullOrWhiteSpace(Phone_Dsc))
				_Errors["Phone_Dsc"] = "Missing phone number description";
			if (!Contact.ValidatePhone(Phone, Phone_Ext))
				_Errors["Phone"] = Contact.Error;
			if (!ClsConvert.ValidateYN(Active_Flg))
				_Errors["Active_Flg"] = "Missing or invalid active flag";
		}
		#endregion		// #region Validation
	}

	#region Static Methods/Properties of ClsTerminalContact

	partial class ClsTerminalContact
	{
		public static DataTable GetTerminalContacts(string termCD, string termSection)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	rtc.*,
					rtc.phone || nvl2(rtc.phone_ext, ' x', NULL) || rtc.phone_ext AS full_phone
			FROM	R_TERMINAL_CONTACT rtc
			WHERE	rtc.TERMINAL_CD=@TERM_CD ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@TERM_CD", termCD));
			Connection.AppendInClause(sb, p, "AND", "rtc.terminal_section_cd", "@TRM_SECT", termSection);

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}
	}
	#endregion		// 	#region Static Methods/Properties of ClsTerminalContact
}