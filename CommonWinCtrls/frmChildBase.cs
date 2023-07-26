using System;
using System.Threading;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

namespace CS2010.CommonWinCtrls
{
	public partial class frmChildBase : Form
	{
		#region Fields

		private ToolStrip _tbrChild;

		#endregion		// #region Fields

		#region Properties

		public ToolStrip MergeToolbar
		{
			get { return _tbrChild; } set { _tbrChild = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		public frmChildBase()
		{
			InitializeComponent();
		}

		public frmChildBase(bool fullSize)
		{
			InitializeComponent();


			AdjustForm(WindowHelper.MDIParent, fullSize, null);
		}

		public frmChildBase(Form frmParent, bool fullSize)
		{
			InitializeComponent();
			AdjustForm(frmParent, fullSize, null);
		}

		public frmChildBase(Form frmParent, bool fullSize,
			FormClosedEventHandler ev)
		{
			InitializeComponent();
			AdjustForm(frmParent, fullSize, ev);
		}
		#endregion		// #region Constructors

		#region Helper methods

		protected void AdjustForm(Form frmParent, bool fullSize,
			FormClosedEventHandler ev)
		{
			try
			{
				MdiParent = frmParent;
				if( fullSize ) WindowState = FormWindowState.Maximized;
				if( ev != null ) FormClosed += new FormClosedEventHandler(ev);
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}
		#endregion		// #region Helper methods

		#region Overrides

		protected override void OnActivated(EventArgs e)
		{
			try
			{

				base.OnActivated(e);
				if( Disposing == true ) return;

				ShowToolbar();
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			try
			{
				base.OnClosed(e);
				HideToolbar();
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}

		protected override void OnDeactivate(EventArgs e)
		{
			try
			{
				base.OnDeactivate(e);
				if( Disposing == true ) return;

				HideToolbar();
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}
		#endregion		// #region Overrides

		#region Helper Methods

		protected void ShowToolbar()
		{
			try
			{
				if( _tbrChild != null )
				{
					ToolStrip tbr = ToolStripManager.FindToolStrip("tbrMain");
					if (tbr != null && tbr != _tbrChild && tbr.Parent == TopLevelControl)
					{	// prevent merging/unmerging to/from itself, and should only merge with
						// the MDIParent's toolbar (so we check TopLevelControl)
						tbr.Visible = true;
						ToolStripManager.Merge(_tbrChild, "tbrMain");
					}
					else
						_tbrChild.Visible = true;	// No parent, just show
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}

		protected void HideToolbar()
		{
			try
			{
				if( _tbrChild != null )
				{
					ToolStrip tbr = ToolStripManager.FindToolStrip("tbrMain");
					if( tbr != null && tbr != _tbrChild && tbr.Parent == TopLevelControl )
					{	// prevent merging/unmerging to/from itself, and should only merge with
						// the MDIParent's toolbar (so we check TopLevelControl)
						ToolStripManager.RevertMerge("tbrMain");
						tbr.Visible = false;
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("ChildBase", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Asynchronous DB access

		private string _AsynchConnectionKey;
		protected string AsynchConnectionKey
		{
			get
			{
				// If no connection key has been specified, use the
				// default connection key from the environment. Note
				// you can set this in order to specify asynch processing
				// from an alternate database connecition.
				if (string.IsNullOrEmpty(_AsynchConnectionKey))
				{
					_AsynchConnectionKey = ClsEnvironment.ConnectionKey;
				}
				return _AsynchConnectionKey;
			}
			set { _AsynchConnectionKey = value; }
		}
		protected bool AsynchronousProcessCancelled;
		protected bool AsynchronousProcessComplete;
		private ThreadStart DbMethod;
		private ThreadStart UpdateMethod;
		private ThreadStart CancelMethod;

		private Thread MainThread;
		private AutoResetEvent ExecuteEvent;
		private AutoResetEvent CancelEvent;
		private AutoResetEvent FinishedEvent;
		private AutoResetEvent[] ExecuteAndCancel;

		protected bool IsRunning
		{
			get
			{
				return ( MainThread != null && MainThread.IsAlive );
			}
		}

		protected void StartAsynchronousProcess(ThreadStart dbMethod,
			ThreadStart anUpdateMethod, ThreadStart aCancelMethod)
		{
			try
			{
				DbMethod = new ThreadStart(dbMethod);
				UpdateMethod = new ThreadStart(anUpdateMethod);
				CancelMethod = new ThreadStart(aCancelMethod);

				AsynchronousProcessCancelled = false;
				AsynchronousProcessComplete = false;

				ExecuteEvent = new AutoResetEvent(false);
				CancelEvent = new AutoResetEvent(false);
				FinishedEvent = new AutoResetEvent(false);

				ExecuteAndCancel = new AutoResetEvent[2];
				ExecuteAndCancel[0] = ExecuteEvent;
				ExecuteAndCancel[1] = CancelEvent;

				MainThread = new Thread(new ThreadStart(StartExecuteWithCancel));
				MainThread.Start();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		protected void CancelAsynchronousProcess()
		{
			try
			{
				lock( this )
				{
					AsynchronousProcessCancelled = true;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}

		private void ExecuteThreadMethod()
		{
			try
			{
				DbMethod();
			}
			catch( Exception ex )
			{
				Display.ShowError("Warning", ex);
			}
			ExecuteEvent.Set();
		}

		private void CancelThreadMethod()
		{
			try
			{
				bool loop = true, cancel = false;
				while( loop )
				{
					Thread.Sleep(1000);

					lock( this )
					{
						if( AsynchronousProcessCancelled )
						{
							loop = false;
							cancel = true;
						}
						else if( AsynchronousProcessComplete )
						{
							loop = cancel = false;
						}
					}
				}

				if( cancel )
				{
					ClsConnection cn = ClsConMgr.Manager[AsynchConnectionKey];
					DbCommand cmd = cn.CurrentCommand;
					if (cn.IsOpen)
					{
						cmd.Cancel();
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Warning", ex);
			}
			CancelEvent.Set();
		}

		private void StartExecuteWithCancel()
		{
			try
			{
				ExecuteEvent.Reset();
				CancelEvent.Reset();

				Thread t1 = new Thread(new ThreadStart(ExecuteThreadMethod));
				Thread t2 = new Thread(new ThreadStart(CancelThreadMethod));

				t1.Start();
				t2.Start();
			}
			catch( Exception ex )
			{
				Display.ShowError("Warning", ex);
			}
			finally
			{
				WaitHandle.WaitAll(ExecuteAndCancel);
			}
			FinishedEvent.Set();
			if( AsynchronousProcessComplete && !AsynchronousProcessCancelled )
				BeginInvoke(UpdateMethod);
			else
				BeginInvoke(CancelMethod);
		}
		#endregion		// #region Asynchronous DB access
	}
}