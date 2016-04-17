using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOR.Attributes.Notes;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.Utils;

namespace THOR.Windows.Editors.Common.Dialogs
{
	public partial class DialogEntityTypeSelector : THOR.Windows.Dialogs.FlatDialog
	{
		public DialogEntityTypeSelector()
		{
			InitializeComponent();

			txtSearch.TextBox.KeyDown += TextBox_KeyDown;
		}

		

		public void SetTypes(List<Type> types)
		{
			if (types == null || types.Count == 0) return;

			ThorDataTable table = new ThorDataTable();

			table.Columns.Add(new ThorDataTableColumn());

			

			foreach (Type type in types)
			{
				ThorDataTableRow rowType = GetType(type);
				ThorDataTableRow rowCategory = GetCategoryRow(table, type);

				if (rowCategory == null)
				{
					table.Rows.Add(rowType);
				}
				else
				{
					rowCategory.Rows.Add(rowType);
				}
				
			}

			treeTypes.DataTable = table;
		}


		protected ThorDataTableRow GetCategoryRow(ThorDataTable table, Type type)
		{
			NoteAttribute note = NoteAttribute.GetNote(type);
			if (note != null)
			{
				string category = note.Category.Trim();
				string[] categoryNodes = category.Split(new char[2] { '\\', '/' });

				ThorDataTableMemberCollection<ThorDataTableRow> rows = table.Rows;
				foreach (string categoryNode in categoryNodes)
				{
					if (categoryNode.Trim().Length == 0) continue;

					ThorDataTableRow rowTemp = GetCategoryRowMethod(rows, categoryNode);

					rows = rowTemp.Rows;

					if (categoryNode == categoryNodes[categoryNodes.Length - 1]) return rowTemp;
				}
			}
			return null;
		}

		protected ThorDataTableRow GetCategoryRowMethod(ThorDataTableMemberCollection<ThorDataTableRow> rows, string category)
		{
			ThorDataTableRow ret = null;

			foreach (ThorDataTableRow row in rows)
			{
				if (row.Cells.Count > 0)
				{
					if (row.Cells[0].Text == category)
					{
						ret = row;
						break;
					}
				}
			}

			ret = new ThorDataTableRow();
			ret.OpenedIcon = ThorEditorTypeIcons.GetCategoryIcon(true);
			ret.ClosedIcon = ThorEditorTypeIcons.GetCategoryIcon(false);
			ret.Cells.Add(new ThorDataTableCell() { Text = category });

			rows.Add(ret);

			return ret;
		}



		protected ThorDataTableRow GetType(Type type)
		{
			NoteAttribute note = NoteAttribute.GetNote(type);
			ThorDataTableRow row = new ThorDataTableRow();
			row.TagData = type;
			row.OpenedIcon = row.ClosedIcon = ThorEditorTypeIcons.GetTypeIcon(type);

			string text = type.Name;
			if (note != null)
			{
				text = note.Name;
			}

			row.Cells.Add(new ThorDataTableCell() { Text = text });

			return row;
		}

		

		private void treeTypes_SelectionChanged(object sender, EventArgs e)
		{
			if (treeTypes.SelectedRow != null && treeTypes.SelectedRow.TagData is Type)
			{
				SelectedType = (Type)treeTypes.SelectedRow.TagData;
				return;
			}

			SelectedType = null;
		}

		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			btnSearch_Click(null, null);
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (txtSearch.TextBox.Text.Trim().Length == 0) return;

			ThorDataTableRow row = ThorDataTableFinder.FindRow(treeTypes.DataTable, txtSearch.TextBox.Text.Trim(), treeTypes.SelectedRow);

			treeTypes.SelectedRow = row;
			treeTypes.ScrollToSelection();


			if (treeTypes.SelectedRow != null && treeTypes.SelectedRow.TagData is Type)
			{
				SelectedType = (Type)treeTypes.SelectedRow.TagData;
				return;
			}

			SelectedType = null;
		}

		protected override bool OnClickDialogButtonOK()
		{
			return (SelectedType != null);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (btnSearch != null)
			{
				txtSearch.Width = this.Width - 30 - btnSearch.Width;
			}
		}

		public Type SelectedType { get; protected set; }

	

		
	}
}
