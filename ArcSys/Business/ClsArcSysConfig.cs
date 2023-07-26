using System;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	#region ArcSys-Specific Config File

	public static class ClsArcSysConfig
	{
		public static bool UseTabbedMDI
		{
			get { return ClsConfig.ReadBooleanValue("UseTabbedMDI", false); }
		}
        public static bool CheckForLINEChanges
        {
            get { return ClsConfig.ReadBooleanValue("CheckForLINEChanges", false); }
        }
        public static int IntervalSeconds
        {
            get 
            {
                int i = ClsConfig.ReadNumeric<int>("IntervalSeconds", 60);

                // For simplicity, configuration file is seconds.  The timer
                // needs it in miliseconds so we convert here.
                i = i * 1000;
                return i;
            }
        }
	}
	#endregion		// #region ArcSys-Specific Config File
}