using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public static class Display
	{
		#region Public methods

		public static bool ShowError(string title, Exception ex, ClsBaseTable obj,
			string extraInfo)
		{
			return ShowError(title, ClsErrorHandler.LogException(ex, obj, extraInfo));
		}

		public static bool ShowError<T>(string title, Exception ex, List<T> lst)
			where T : ClsBaseTable
		{
			return ShowError(title, ClsErrorHandler.LogException<T>(ex, lst));
		}

		public static bool ShowError(string title, Exception ex, ClsBaseTable obj)
		{
			return ShowError(title, ClsErrorHandler.LogException(ex, obj));
		}

		public static bool ShowError(string title, Exception ex)
		{
			return ShowError(title, ClsErrorHandler.LogException(ex));
		}

		public static bool ShowError(string msg)
		{
			return ShowError("Error", msg);
		}

		public static bool ShowError(string title, string msg)
		{
			MessageBox.Show(msg, title, MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			return false;
		}

		public static bool ShowError(Exception ex)
		{
			return ShowError("Error", ex);
		}

		public static bool ShowError(string title, string msg,
			params object[] args)
		{
			string s = string.Format(msg, args);
			MessageBox.Show(s, title, MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			return false;
		}

		public static bool ShowErrors<T>(string title, List<T> lst) where T: ClsBaseTable
		{
			StringBuilder sb = new StringBuilder();
			foreach( T obj in lst )
				if( obj != null && obj.HasErrors == true )
					sb.AppendLine(obj.Error);
			return ( sb.Length > 0 ) ? Display.ShowError(title, sb.ToString()) : true;
		}

		public static bool Show(string title, string msg, params object[] args)
		{
			string s = string.Format(msg, args);
			MessageBox.Show(s, title, MessageBoxButtons.OK,
				MessageBoxIcon.Information);
			return true;
		}

		public static bool Ask(string title, string q, params object[] args)
		{
			string s = string.Format(q, args);
			return MessageBox.Show(s, title, MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes;
		}

		/// <summary>Ask a yes/no/cancel question (returns 1 for yes, 0,
		/// for now, and -1 for cancel)</summary>
		/// <returns>1: yes, 0: no, -1: cancel</returns>
		public static sbyte AskCancel(string title, string q, params object[] args)
		{
			string s = string.Format(q, args);
			DialogResult res = MessageBox.Show(s, title,
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button3);
			if( res == DialogResult.Yes ) return 1;
			if( res == DialogResult.No ) return 0;
			return -1;
		}

        public static void CursorBusy()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void CursorNormal()
        {
            Cursor.Current = Cursors.Default;
        }
		#endregion		// #region Public methods
	}
}