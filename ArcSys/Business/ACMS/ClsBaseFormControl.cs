using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ACMS.Business
{
	public class ClsBaseFormControl
	{
		public ClsBaseFormControl()
		{
		    ClearErrors();
		    ClearMessages();
		}

		#region Fields and Properties

		protected StringBuilder _Errors;
		public string Errors
		{
			get { return _Errors.ToString();}
		}
		public bool HasErrors
		{
			get
			{
				if (Errors.Length > 1)
					return true;
				return false;
			}
		}

		protected StringBuilder _Messages;
		public string Messages
		{
			get { return _Messages.ToString(); }
		}

		#endregion

		#region Base Methods

		public void ClearErrors()
		{
			_Errors = new StringBuilder();
		}
		public void ClearMessages()
		{
			_Messages = new StringBuilder();
		}
		protected void AddError(string sMsg)
		{
			_Errors.AppendLine(sMsg);
		}
		protected void AddMessage(string sMsg)
		{
			_Messages.AppendLine(sMsg);
		}
		#endregion

	}
}

