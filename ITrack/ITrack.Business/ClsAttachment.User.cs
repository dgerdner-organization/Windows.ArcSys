using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	partial class ClsAttachment
	{
		#region Overrides

		public override void SetDefaults()
		{
		}

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

		public override string ToString()
		{
			return string.Format("{0}: {1} {2}",
				Attachment_ID, Issue_ID, Attachment_Nm);
		}
		#endregion		// #region Overrides

		#region Helper Methods

		private void CommonValidation()
		{
			if( Issue_ID == null || Issue_ID == 0 )
				_Errors["Issue_ID"] = "Missing issue ID";
			if( string.IsNullOrEmpty(Attachment_Nm) == true )
				_Errors["Attachment_Nm"] = "Missing attachment name";
			if( Attachment == null || Attachment.Length <= 0 )
				_Errors["Attachment"] = "Missing attachment object";
		}
		#endregion		// #region Helper Methods

		#region Public Methods

		#endregion		// #region Public Methods
	}

	#region Static Methods/Properties of ClsAttachment

	partial class ClsAttachment
	{
		#region Public Methods

		#endregion		// #region Public Methods
	}
	#endregion		// #region Static Methods/Properties of ClsAttachment
}