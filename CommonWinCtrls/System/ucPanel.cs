using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(Panel))]
	public partial class ucPanel : Panel
	{
		#region Fields

		protected bool _Readonly;

		#endregion		// #region Fields

		#region Properties

		[DefaultValue(false)]
		[Description("This property will set the Readonly property on child " +
			"controls if applicable or the Enabled property if not")]
		public bool Readonly
		{
			get { return _Readonly; }
			set { _Readonly = value; AdjustPanel(); }
		}
		#endregion		// #region Properties

		#region Constructors

		public ucPanel()
		{
			InitializeComponent();
			_Readonly = false;
		}
		#endregion		// #region Constructors

		#region Helper Methods

		protected void AdjustPanel()
		{
			try
			{
				foreach( Control c in Controls )
				{
					if( c is Label ) continue;

					Type t = c.GetType();
					PropertyInfo pi = t.GetProperty("ReadOnly", typeof(bool));
					if( pi == null )
						pi = t.GetProperty("Readonly", typeof(bool));

					// pi == null then no readonly property, use Enabled
					if( pi == null )			// readonly true - enabled false 
						c.Enabled = !_Readonly;	// readonly false - enabled true
					else
						pi.SetValue(c, _Readonly, null);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("ucPanel Error", ex);
			}
		}
		#endregion		// #region Helper Methods
	}
}