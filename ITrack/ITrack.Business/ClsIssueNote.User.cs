using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsIssueNote
	{
		#region Initialization

		public override void SetDefaults()
		{
			Developer_Flg = "N";
		}

		public void SetDefaults(ClsIssue anIssue)
		{
			Developer_Flg = "N";
			Issue_ID = anIssue.Issue_ID;
			Version_No = anIssue.Project.Next_Version_No;
		}
		#endregion		// #region Initialization

		#region Validation Methods

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
			if( Issue_ID == null || Issue_ID == 0 )
				_Errors["Issue_ID"] = "Missing issue ID";
			if( string.IsNullOrEmpty(Version_No) == true )
				_Errors["Version_No"] = "Missing version";
			if( string.IsNullOrEmpty(Note_Txt) == true )
				_Errors["Note_Txt"] = "Missing note";
		}
		#endregion		// #region Helper Methods

		#region Display

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3}",
				Issue_Note_ID, Issue_ID, Version_No, Note_Txt);
		}
		#endregion		// #region Display

		#region Public Methods

		public void AddNote(ClsIssue anIssue)
		{
			bool newTx = !Connection.IsInTransaction;
			try
			{
				if( newTx == true ) Connection.TransactionBegin();

				Insert();
				anIssue.Update();

				if( newTx == true ) Connection.TransactionCommit();
			}
			catch
			{
				if( newTx == true ) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Public Methods
	}

	#region Static Methods/Properties of ClsIssueNote

	partial class ClsIssueNote
	{
		#region Public Methods

		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsIssueNote
}