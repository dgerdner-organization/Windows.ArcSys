using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	public class ClsGridExUtils
	{
		public static void Setbackgroundformat(GridEX grd)
		{
			// If a column is not Selectable, set background color to grey
			foreach (GridEXTable tbl in grd.Tables)
			{
				foreach (GridEXColumn col in tbl.Columns)
				{
					if (!col.Selectable)
					{
						col.CellStyle.BackColor = System.Drawing.Color.LightGray;
					}
				}
			}
		}
		public static void SetFormats(GridEX grd)
		{
			// If a column is not Selectable, set background color to grey
			foreach (GridEXTable tbl in grd.Tables)
			{
				foreach (GridEXColumn col in tbl.Columns)
				{
					if (col.DataMember.ToLower().EndsWith("NBR"))
						col.TextAlignment = TextAlignment.Far;
				}
			}
		}

	}
}
