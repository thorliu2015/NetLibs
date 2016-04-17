/*
 * CEntityTableDataBuilder
 * liuqiang@2015/12/6 22:57:36
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Editors.Common.Data
{
	public class CEntityTableDataBuilder
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		static public ThorDataTableRow GetCategoryRow(ThorDataTable table, string category)
		{
			string[] cs = category.Split(new char[2] { '\\', '/' });

			ThorDataTableMemberCollection<ThorDataTableRow> rows = table.Rows;

			foreach (string c in cs)
			{
				if (c.Trim().Length == 0) continue;

				ThorDataTableRow r = GetCategoryRowMethod(rows, c);

				if (c == cs[cs.Length - 1]) return r;

				rows = r.Rows;
			}

			return null;
		}

		static private ThorDataTableRow GetCategoryRowMethod(ThorDataTableMemberCollection<ThorDataTableRow> rows, string category)
		{
			foreach (ThorDataTableRow row in rows)
			{
				if (row.TagData != null) continue;

				if (row.Cells.Count > 0)
				{
					if (row.Cells[0].Text == category) return row;
				}
			}

			ThorDataTableRow r = new ThorDataTableRow();
			r.Cells.Add(new ThorDataTableCell() { Text = category });

			r.OpenedIcon = ThorEditorTypeIcons.GetCategoryIcon(true);
			r.ClosedIcon = ThorEditorTypeIcons.GetCategoryIcon(false);

			rows.Add(r);

			return r;
		}

		static public ThorDataTableRow GetEntityRow(CEntity entity)
		{
			ThorDataTableRow row = new ThorDataTableRow();

			row.TagData = entity;
			row.Cells.Add(new ThorDataTableCell() { Text = entity.Id });

			row.OpenedIcon = row.ClosedIcon = ThorEditorTypeIcons.GetTypeIcon(entity.GetType());


			return row;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
