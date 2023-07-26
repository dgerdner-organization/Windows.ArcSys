using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	#region Color/Casing Configuration

	public static class ClsControlConfig
	{
		#region Helper Methods

		public static CharacterCasing ReadCharacterCase(string key, CharacterCasing defaultVal)
		{
			try
			{
				string s = ClsConfig.ReadConfigValue(key);
				string val = !string.IsNullOrEmpty(s) ? s.Trim() : null;
				if( string.IsNullOrEmpty(val) ) return defaultVal;

				return (CharacterCasing)Enum.Parse(typeof(CharacterCasing), val, true);
			}
			catch( Exception ex )
			{
				ClsErrorHandler.LogException(ex);
				return defaultVal;
			}
		}
		#endregion		// #region Helper Methods

		#region Config Settings

		public static CharacterCasing Case
		{
			get { return ReadCharacterCase("ucControl.Case", CharacterCasing.Upper); }
		}

		public static Boolean ChangeColorOnEnter
		{
			get { return ClsConfig.ReadBooleanValue("ucControl.ChangeColorOnEnter", false); }
		}

		public static Color EnterForeColor
		{
			get { return ClsConfig.ReadColorValue("ucControl.EnterForeColor", Color.White); }
		}

		public static Color EnterBackGroundColor
		{
			get
			{
				return ClsConfig.ReadColorValue("ucControl.EnterBackGroundColor",
					Color.Yellow);
			}
		}

		public static Color DisableBackGroundColor
		{
			get
			{
				return ClsConfig.ReadColorValue("ucControl.DisableBackGroundColor",
					SystemColors.Control);
			}
		}

		public static Color ReadOnlyBackGroundColor
		{
			get
			{
				return ClsConfig.ReadColorValue("ucControl.ReadOnlyBackGroundColor",
					SystemColors.Control);
			}
		}
		#endregion		// #region Config Settings
	}
	#endregion		// #region Color/Casing Configuration
}