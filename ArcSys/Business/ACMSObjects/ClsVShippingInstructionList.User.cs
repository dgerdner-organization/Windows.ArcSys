using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVShippingInstructionList
	{
		public bool FullyReceived
		{
			get
			{
				if (Rcvd_Count < Liner_Count)
					return false;
				return true;
			}
		}
	}
}
