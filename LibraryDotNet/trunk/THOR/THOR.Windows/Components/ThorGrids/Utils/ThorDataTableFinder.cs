/*
 * ThorDataTableFinder
 * liuqiang@2015/12/8 20:54:50
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Core;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Utils
{
	public class ThorDataTableFinder
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public ThorDataTableRow FindRow(ThorDataTable table, string text, ThorDataTableRow currentRow = null)
		{
			if (table == null || table.Rows.Count == 0) return null;

			ThorDataTableRow row = currentRow;

			if (row != null)
			{
				row = row.GetNextRow();
			}
			else
			{
				row = table.Rows[0];
			}

			//向后找
			while (row != null)
			{
				if (MatchRow(row, text)) return row;

				row = row.GetNextRow();
			}

			//从头找
			if (row == null)
			{
				row = table.Rows[0];

				while (row != null)
				{
					if (row == currentRow) break;

					if (MatchRow(row, text)) return row;

					row = row.GetNextRow();
				}
			}

			return null;
		}

		static private bool MatchRow(ThorDataTableRow row, string text)
		{
			bool ret = false;
			
			if (row != null)
			{
				string szText = text.ToLower();
				foreach (ThorDataTableCell cell in row.Cells)
				{
					if (cell.Text.ToLower().IndexOf(szText) >= 0)
					{
						return true;
					}
				}
			}

			return ret;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
