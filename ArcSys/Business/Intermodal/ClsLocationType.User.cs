using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
	partial class ClsLocationType
	{
		public bool IsPort
		{
			get
			{
				if (this.Location_Type_Cd == "PORT")
					return true;
				return false;
			}
		}
		public bool IsLand
		{
			get
			{
				if (this.Location_Type_Cd == "LAND")
					return true;
				return false;
			}
		}
	}
}
