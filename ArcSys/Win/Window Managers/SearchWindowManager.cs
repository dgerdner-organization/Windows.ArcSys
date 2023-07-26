using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public static class SearchWindowManager
	{
		#region Fields

		private static Dictionary<Type, Form> SearchForms;

		#endregion		// #region Fields

		#region Constructors

		static SearchWindowManager()
		{
			SearchForms = new Dictionary<Type, Form>();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public static ISearchWindow Search<T>(bool showOptions) where T : Form, ISearchWindow
		{
			ISearchWindow win = null;
			try
			{
				Type formType = typeof(T);
				Form f = ( SearchForms.ContainsKey(formType) == true )
					? SearchForms[formType] : null;
				if( f == null )
				{
					//showOptions = true;
					ConstructorInfo ci = formType.GetConstructor(System.Type.EmptyTypes);
					object formObj = ci.Invoke(null);
					f = formObj as Form;
					SearchForms[formType] = f;
					f.FormClosed += new FormClosedEventHandler(SearchForms_FormClosed);
				}

				f.Show();
				f.Activate();
				if( f.WindowState == FormWindowState.Minimized )
					f.WindowState = FormWindowState.Maximized;
				win = f as ISearchWindow;
				if( win != null ) win.ShowSearch(showOptions);
				return win;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public static ISearchWindow Search<T>() where T : Form, ISearchWindow
		{
			return Search<T>(true);
		}

		public static void RefreshResults<T>() where T : Form, ISearchWindow
		{
			try
			{
				Type formType = typeof(T);
				ISearchWindow win = (SearchForms.ContainsKey(formType) == true)
					? SearchForms[formType] as ISearchWindow : null;

				if( win != null ) win.RefreshResults();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		public static void AddRows<F, T>(List<T> lst) where F : Form, ISearchWindow
			where T: ClsBaseTable
		{
			try
			{
				if( lst == null || lst.Count <= 0 ) return;

				Type formType = typeof(T);
				ISearchWindow win = (SearchForms.ContainsKey(formType) == true)
					? SearchForms[formType] as ISearchWindow : null;
				if( win == null ) win = Search<F>(false);

				ISearchWindowUpdate winmod = win as ISearchWindowUpdate;
				if( winmod != null )
				{
					foreach( T item in lst ) winmod.AddRow(item);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		public static void AddRow<T>(ClsBaseTable bizObject) where T : Form, ISearchWindow
		{
			try
			{
				Type formType = typeof(T);
				ISearchWindow win = (SearchForms.ContainsKey(formType) == true)
					? SearchForms[formType] as ISearchWindow : null;
				if( win == null ) win = Search<T>(false);

				ISearchWindowUpdate winmod = win as ISearchWindowUpdate;
				if( winmod != null ) winmod.AddRow(bizObject);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		public static void RemoveRow<T>(ClsBaseTable bizObject) where T : Form, ISearchWindow
		{
			try
			{
				Type formType = typeof(T);
				ISearchWindow win = (SearchForms.ContainsKey(formType) == true)
					? SearchForms[formType] as ISearchWindow : null;
				if( win == null ) return;

				ISearchWindowUpdate winmod = win as ISearchWindowUpdate;
				if( winmod != null ) winmod.RemoveRow(bizObject);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private static void SearchForms_FormClosed(object sender,
			FormClosedEventArgs e)
		{
			try
			{
				bool found = false;
				Type key = null;
				foreach( Type t in SearchForms.Keys )
				{
					if( SearchForms[t] == sender )
					{
						found = true;
						key = t;
						break;
					}
				}

				if( found == true ) SearchForms.Remove(key);

				Form f = sender as Form;
				if( f != null )
				{
					f.Dispose();
					f = null;
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Helper Methods
	}

	public interface ISearchWindow
	{
		void ShowSearch(bool showOptions);
		void RefreshResults();
	}

	public interface ISearchWindowUpdate
	{
		void AddRow(ClsBaseTable bizObject);
		void RemoveRow(ClsBaseTable bizObject);
	}
}