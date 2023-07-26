using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ArcSys
{
    /// <summary>
    /// Experimenting with class extensions ... 
    /// </summary>
    public static class ClsExtensions
    {
        // String Extensions
        public static Boolean IsNull(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static Boolean IsNotNull(this string s)
        {
            return !IsNull(s);
        }

    }
}
