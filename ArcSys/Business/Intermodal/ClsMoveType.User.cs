using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ArcSys.Business
{
	partial class ClsMoveType
	{

		public bool IsDoorIn
		{
			get
			{
				if (this.Move_Type_Cd == "F5" ||
					this.Move_Type_Cd == "F6" ||
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}
		public bool IsDoorOut
		{
			get
			{
				if (this.Move_Type_Cd == "F7" ||
					this.Move_Type_Cd == "F8" ||
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}
		public bool IsDoorMove
		{
			get
			{
				return (IsDoorIn || IsDoorOut);
			}
		}
	}
}
