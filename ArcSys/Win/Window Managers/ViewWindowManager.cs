using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	#region ViewWindowManager

	/// <summary>Helper ArcSys for displaying and refreshing our "View" windows.
	/// Use View to display/activate a window with a given object, use Refresh to
	/// update a window without activating it. If a window does not exist, Refresh
	/// will NOT create one; the View method will.</summary>
	/// <remarks>Our "View" forms need to implement an interface in order to be
	/// handled by the ViewWindowManager. See IViewWindow for more info.</remarks>
	public static partial class ViewWindowManager
	{
		#region Fields

		/// <summary>Holds all "View" Type forms regardless of business object</summary>
		private static List<IViewWindow> ViewWindows = new List<IViewWindow>();
		private static Dictionary<Type, Type> ViewWindowTypes = new Dictionary<Type, Type>();

		#endregion		// #region Fields

		public static void AddWindowType(Type objectType, Type formType)
		{
			if (ViewWindowTypes.ContainsKey(objectType))
				ViewWindowTypes[objectType] = formType;
			else
				ViewWindowTypes.Add(objectType, formType);
		}

		#region Generic Public Methods

		/// <summary>Method used to view a business object. It will create a new
		/// "View" window for the object if a window does not already exist with
		/// that object. We determine whether that object exists based on its
		/// primary key value (i.e. order ID, bol ID, etc.). If the object already
		/// exists in an open window, we do not create a window, instead we
		/// refresh the display, and activiate it.</summary>
		/// <param name="bizObject">The business object to display</param>
		/// <returns>The "View" window used to display the object returned as an
		/// IViewWindow. It can be cast to the actual form if necessary (i.e.
		/// frmViewOrder, frmViewBOL, etc.). It will return null if there was
		/// an error creating the window.</returns>
		public static IViewWindow View(ClsBaseTable bizObject)
		{
			return View(bizObject, false);
		}

		/// <summary>Method used to view a business object either modally or non-
		/// modaly. If modal is false it will call the View(bizObject) method. If
		/// it is true, then it will create the form display it as a pop-up and
		/// then dispose of it. Modal windows will not be added to the "View"
		/// window lists because of their temporary nature.</summary>
		/// <param name="bizObject">The business object to display</param>
		/// <param name="modal">True to display the "View" window modally, false
		/// to display it non-modal.</param>
		/// <returns>The "View" window used to display the object returned as an
		/// IViewWindow when modal is false. When modal is true this method will
		/// always return null.</returns>
		public static IViewWindow View(ClsBaseTable bizObject, bool modal)
		{
			try
			{
				if (bizObject == null)
				{
					Program.ShowError("No object provided");
					return null;
				}

				IViewWindow vw = null;
				if (!modal)
				{
					vw = FindWindow(bizObject);
					if (vw != null)				// If a window with the object exists
					{
						ShowRefreshed(vw);		// refresh and activiate it
						return vw;
					}	// Otherwise fall through to the next section to create the window
				}

				Type objectType = bizObject.GetType();
				if (!ViewWindowTypes.ContainsKey(objectType))
				{	// When this occurs, call AddWindowType for the object and form in question
					// For example AddWindowType(typeof(ClsOrder), typeof(frmViewOrder));
					Program.ShowError(ClsErrorHandler.LogError(
						"Missing entry in View Window Manager for type {0}", objectType));
					return null;
				}

				Type formType = ViewWindowTypes[objectType];
				if( formType == null )
				{	// When this occurs, check the call to AddWindowType to make sure 2nd parameter
					// is not null: AddWindowType(typeof(ClsOrder), typeof(frmViewOrder));
					Program.ShowError(ClsErrorHandler.LogError(
						"Missing form type in View Window Manager for {0}", objectType));
					return null;
				}

				ConstructorInfo ci = formType.GetConstructor(new Type[] { typeof(bool) });
				if( ci == null )
				{	// When this occurs, ensure that there is a constructor that accepts
					// a bool that indicates whether to show the view window as modal (true)
					// or non-modal (false). See frmViewOrder in CLASS.
					Program.ShowError(ClsErrorHandler.LogError(
						"Could not find constructor for {0}\r\n", objectType));
					return null;
				}
				object formWindow = ci.Invoke(new object[] { modal });
				if (formWindow == null)
				{	// When this occurs, check the constructor that accepts a bool to ensure
					// it is not throwing an exception when invoked
					Program.ShowError(ClsErrorHandler.LogError(
						"Could not create window for {0}\r\n", objectType));
					return null;
				}

				bool attemptDispose = true;
				try
				{
					vw = formWindow as IViewWindow;
					if (vw == null)
					{	// When this occurs, ensure that the View Window implements the
						// IViewWindow interface
						Program.ShowError(ClsErrorHandler.LogError(
							"Form {0} does not implement IViewWindow\r\n", objectType));
						return null;
					}

					if (!modal)
					{
						attemptDispose = false;
						AttachEvent(vw);
					}
					vw.ViewObject(bizObject);
				}
				finally
				{
					if (attemptDispose)
					{
						IDisposable disp = formWindow as IDisposable;
						if (disp != null) disp.Dispose();
					}
				}

				// If modal, window is gone by the time we return, so return null
				return ( modal ) ? null : vw;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		/// <summary>Method used to refresh a "View" window. It will attempt to
		/// find a window that has the given object displayed. We determine
		/// whether that object exists based on its primary key value (i.e.
		/// order ID, bol ID, etc.). If the object exists in an open window, we
		/// refresh the display, but we do not activate the window. If a window
		/// was not found, we do nothing.</summary>
		/// <param name="bizObject">The business object to refresh</param>
		/// <returns>The "View" window used to display the object returned as an
		/// IViewWindow. It can be cast to the actual form if necessary (i.e.
		/// frmViewOrder, frmViewBOL, etc.). It will return null if a window
		/// with the given object was not found.</returns>
		public static IViewWindow Refresh(ClsBaseTable bizObject)
		{
			try
			{
				if( bizObject == null )
				{
					Program.ShowError("No object provided");
					return null;
				}

				IViewWindow vw = FindWindow(bizObject);
				if( vw == null ) return null;	// Window not found: ok, return

				vw.TableObject.ReloadFromDB();	// Found it: reload and update the
				vw.UpdateDisplay();		// display, but do NOT activate the window

				return vw;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}
		#endregion		// #region Generic Public Methods

		#region Window Helper Methods

		/// <summary>Search for a "View" window with the given object</summary>
		/// <param name="bizObject">The object to search for</param>
		/// <returns>The "View" window with the object displayed, or null if no
		/// window exists for that object.</returns>
		private static IViewWindow FindWindow(ClsBaseTable bizObject)
		{
			try
			{
				if (ViewWindows == null || ViewWindows.Count <= 0) return null;

				object[] bizValues = GetValues(bizObject);
				if( bizValues == null ) return null;

				Type bizType = bizObject.GetType();
				IViewWindow v = ViewWindows.Find(delegate(IViewWindow vw)
				{
					if (vw.TableObject == null)
					{
						Program.ShowError(ClsErrorHandler.LogError(
							"View Window TableObject is null for {0}", vw.GetType()));
						return false;
					}

					Type vwObjType = vw.TableObject.GetType();
					if (vwObjType != bizType) return false;

					object[] formValues = GetValues(vw.TableObject);
					if( formValues == null ) return false;

					for( int i = 0; i < bizValues.Length; i++ )
						if( bizValues[i].Equals(formValues[i]) == false )
							return false;

					return true;
				});

				return v;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private static void AttachEvent(IViewWindow vw)
		{
			Form f = vw as Form;
			f.FormClosed += new FormClosedEventHandler(Window_FormClosed);

			ViewWindows.Add(vw);
		}

		/// <summary>Refresh and activate the given window</summary>
		/// <param name="vw">The window to display</param>
		private static void ShowRefreshed(IViewWindow vw)
		{
			try
			{
				vw.TableObject.ReloadFromDB();	// Reload object
				vw.UpdateDisplay();				// Update display
												// Then activate the window
				Form f = vw as Form;

				f.Show();
				f.Activate();
				if( f.WindowState == FormWindowState.Minimized )
					f.WindowState = FormWindowState.Maximized;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Window Helper Methods

		#region Other Helper Methods

		/// <summary>Get the primary key value or values from the given object
		/// and return them as an array of objects</summary>
		/// <param name="bizObject">The object to retrieve the values from</param>
		/// <returns>The array of primary key values</returns>
		private static object[] GetValues(ClsBaseTable bizObject)
		{
			try
			{
				if( bizObject == null ) return null;

				Type t = bizObject.GetType();

				string[] keys = t.InvokeMember("GetPrimaryKeys",
					BindingFlags.Public | BindingFlags.Static |
					BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod,
					null, bizObject, null) as string[];
				if( keys == null || keys.Length <= 0 )
				{
					Program.ShowError("Unable to retrieve primary key columns");
					return null;
				}

				object[] vals = new object[keys.Length];
				for( int i = 0; i < keys.Length; i++ )
					vals[i] = t.InvokeMember(keys[i], BindingFlags.Public |
						BindingFlags.Instance | BindingFlags.GetProperty |
						BindingFlags.IgnoreCase, null, bizObject, null);

				return vals;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}
		#endregion		// #region Other Helper Methods

		#region Event Handlers

		/// <summary>FormClosed event handler for any window managed by this
		/// ArcSys. We need this so that we can remove closed windows from our
		/// "View" window lists.</summary>
		/// <param name="sender">This will be the window that was closed</param>
		/// <param name="e">Arguments pertaining to the FormClosed event</param>
		private static void Window_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				ViewWindows.Remove(sender as IViewWindow);
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
		#endregion		// #region Event Handlers
	}
	#endregion		// #region ViewWindowManager

	#region IViewWindow Interface

	/// <summary>Interface required by the ViewWindowManager ArcSys that is used to
	/// display business object. "View" windows will need to implement this
	/// interface in order to be managed by the ViewWindowManager.</summary>
	public interface IViewWindow
	{
		/// <summary>The business object being displayed. For example, in the
		/// frmViewOrder window this would return the ClsOrder object. But to use
		/// this TableObject as an order object you would have to cast it to a
		/// ClsOrder object</summary>
		ClsBaseTable TableObject { get; }

		/// <summary>Method in the "View" window that displays the business
		/// object and its associated information</summary>
		void UpdateDisplay();
		/// <summary>Method for viewing a business object. This method is/should
		/// only be used by the ViewWindowManager. In most cases it will just call
		/// the form's View method. For example, in the frmViewOrder form, View
		/// will call ViewOrder.</summary>
		/// <param name="bizObject">The object to display</param>
		void ViewObject(ClsBaseTable bizObject);
	}
	#endregion		// #region IViewWindow Interface
}