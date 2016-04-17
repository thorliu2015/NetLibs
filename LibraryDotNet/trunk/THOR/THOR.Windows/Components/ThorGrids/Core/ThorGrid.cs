/*
 * ThorGrid
 * liuqiang@2015/11/16 19:37:01
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Components.ThorGrids.Interactives;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.TypeConverters;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Core
{
	public class ThorGrid : ThorAbstractGrid
	{
		#region constants

		#endregion

		#region variables

		/// <summary>
		/// 默认的转换器
		/// </summary>
		protected IThorTypeConverter DefaultConverter = new ThorTypeConverter();

		/// <summary>
		/// 默认的编辑器
		/// </summary>
		protected IEditorInteractive DefaultEditor = new ThorAbstractEditorInteractive();

		/// <summary>
		/// 文本编辑器
		/// </summary>
		protected TextBox TextEditor;

		/// <summary>
		/// 弹出编辑器
		/// </summary>
		protected FlatPopuper PopupEditor;


		#endregion

		#region construct

		public ThorGrid()
			: base()
		{
			InitEditors();
		}

		#endregion

		#region methods

		#region 基础
		protected override void InitGrid()
		{
			base.InitGrid();
			_Render = new ThorGridRender();
			Dock = DockStyle.Fill;
		}


		#endregion

		#region 外观

		/// <summary>
		/// 绘制所有行
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawRows(PaintEventArgs e)
		{
			if (_Render is ThorGridRender == false) return;
			if (_DataTable == null) return;

			ThorGridRender r = (ThorGridRender)_Render;
			Rectangle rectCell = new Rectangle();
			rectCell.Height = _RowHeight;


			ThorGridRenderArgs gridArgs = new ThorGridRenderArgs(this, e.Graphics, GetThemeColor());

			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;


			for (int rowIndex = DataTableRowsCache.Count - 1; rowIndex >= 0; rowIndex--)
			{
				ThorDataTableRow row = DataTableRowsCache[rowIndex];

				for (int cellIndex = row.Cells.Count - 1; cellIndex >= 0; cellIndex--)
				{
					ThorDataTableCell cell = row.Cells[cellIndex];
					//info
					bool isFixed = false;
					if (cellIndex < _FixedColumns || rowIndex < _FixedRows) isFixed = true;

					//rect
					rectCell.X = GetColumnPosition(cellIndex);
					rectCell.Width = GetColumnWidth(cellIndex);
					rectCell.Y = rowIndex * _RowHeight - vScrollBar.Value;

					if (cellIndex == row.Cells.Count - 1)
					{
						rectCell.Width = Width - rectCell.X;
						if (vScrollBar.Visible)
						{
							rectCell.Width -= vScrollBar.Width + borderSize * 2;
						}
					}

					cell.CellBounds = new Rectangle();

					if (!isFixed)
					{
						//if (rectCell.Bottom < 0) continue;
						//if (rectCell.Top > Height) continue;
						//if (rectCell.Left > Width) continue;
						//if (rectCell.Right < 0) continue;

						if (rectCell.Bottom < e.ClipRectangle.Top) continue;
						if (rectCell.Top > e.ClipRectangle.Bottom) continue;
						if (rectCell.Left > e.ClipRectangle.Right) continue;
						if (rectCell.Right < e.ClipRectangle.Left) continue;
					}
					else
					{
						if (rowIndex < _FixedRows) rectCell.Y = rowIndex * _RowHeight;
					}


					//-----
					ThorGridCellRenderArgs args = new ThorGridCellRenderArgs(this, e.Graphics, GetThemeColor());
					args.GridControl = this;
					args.Cell = cell;
					args.RowIndex = rowIndex;
					args.ColumnIndex = cellIndex;
					args.Row = row;
					args.Bounds = new Rectangle(rectCell.Left, rectCell.Top, rectCell.Width, rectCell.Height);

					r.DrawCell(args);

				}
			}

			//选定单元
			if (_SelectedRow != null && _SelectedCell != null)
			{
				int _SelectedRowIndex = DataTableRowsCache.IndexOf(_SelectedRow);
				int _SelectedCellIndex = _SelectedRow.Cells.IndexOf(_SelectedCell);

				Rectangle rectSelectedCell = new Rectangle();
				rectSelectedCell.Height = _RowHeight;
				rectSelectedCell.Width = GetColumnWidth(_SelectedCellIndex);

				rectSelectedCell.X = GetColumnPosition(_SelectedCellIndex);
				rectSelectedCell.Y = _SelectedRowIndex * _RowHeight - vScrollBar.Value;

				if (_SelectedCellIndex >= _DataTable.Columns.Count - 1)
				{
					rectSelectedCell.Width = Width - rectSelectedCell.X;
					if (vScrollBar.Visible)
					{
						rectSelectedCell.Width -= vScrollBar.Width + borderSize * 2;
					}
				}

				if (_FixedColumns > 0)
				{
					int lastFixedColumnIndex = _FixedColumns - 1;
					int lp = GetColumnPosition(lastFixedColumnIndex);
					int lw = GetColumnWidth(lastFixedColumnIndex);

					if (rectSelectedCell.Left < lp + lw)
					{
						int low = (lp + lw) - rectSelectedCell.Left;
						rectSelectedCell.X += low;
						rectSelectedCell.Width -= low;
					}
				}

				if (rectSelectedCell.Bottom < e.ClipRectangle.Top) return;
				if (rectSelectedCell.Top > e.ClipRectangle.Bottom) return;
				if (rectSelectedCell.Left > e.ClipRectangle.Right) return;
				if (rectSelectedCell.Right < e.ClipRectangle.Left) return;

				ThorGridCellRenderArgs scra = new ThorGridCellRenderArgs(this, e.Graphics, GetThemeColor());
				scra.Row = _SelectedRow;
				scra.Cell = _SelectedCell;
				scra.RowIndex = _SelectedRowIndex;
				scra.ColumnIndex = _SelectedCellIndex;
				scra.Bounds = rectSelectedCell;
				scra.GridControl = this;

				r.DrawSelectedCell(scra);
				ArrangeEditor(rectSelectedCell);
				//Debug.WriteLine("? row {0}, cell {1}", _SelectedRowIndex, _SelectedCellIndex);
			}
			else
			{
				ArrangeEditor(new Rectangle());
			}

		}

		/// <summary>
		/// 获取指定列的位置
		/// </summary>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		protected virtual int GetColumnPosition(int columnIndex)
		{
			int ret = 0;

			if (_DataTable != null && columnIndex >= 0 && columnIndex < _DataTable.Columns.Count)
			{
				ret = _DataTable.Columns[columnIndex].Position;
			}

			if (columnIndex >= _FixedColumns)
			{
				ret -= hScrollBar.Value;
			}

			return ret;
		}

		/// <summary>
		/// 获取指定列的宽度
		/// </summary>
		/// <param name="columnIndex"></param>
		/// <returns></returns>
		protected virtual int GetColumnWidth(int columnIndex)
		{
			if (_DataTable != null)
			{
				if (columnIndex >= 0 && columnIndex < _DataTable.Columns.Count)
				{
					return _DataTable.Columns[columnIndex].Width;
				}
			}
			return 100;
		}

		/// <summary>
		/// 计算内容尺寸
		/// </summary>
		/// <returns></returns>
		protected override Size MeasureScrollContentSize()
		{
			Size size = base.MeasureScrollContentSize();

			int w = 0;

			if (_DataTable != null)
			{
				foreach (ThorDataTableColumn column in _DataTable.Columns)
				{
					w += column.Width;
				}
			}

			size.Width = w;

			return size;
		}

		#endregion

		#region 交互

		/// <summary>
		/// 选择
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public override ThorDataTableRow GetRowFromPoint(int x, int y)
		{
			ThorDataTableRow row = GetRowFromPointByFullRowMode(x, y);

			if (row != null)
			{
				int rowIndex = DataTableRowsCache.IndexOf(row);
				if (rowIndex <= _FixedRows)
				{
					_SelectedCell = null;
					return null;
				}



				for (int c = 0; c < row.Cells.Count; c++)
				{
					if (c < _FixedColumns) continue;
					int p = GetColumnPosition(c);
					int w = GetColumnWidth(c);
					if (x >= p && (x < p + w || c == row.Cells.Count - 1))
					{
						_SelectedCell = row.Cells[c];
						break;
					}
				}
			}
			else
			{
				_SelectedRow = null;
				_SelectedCell = null;
			}

			return row;
		}

		/// <summary>
		/// 滚动位置改变时
		/// </summary>
		protected override void OnScrollPositionChanged()
		{
			base.OnScrollPositionChanged();

			if (_SelectedCell != null) ArrangeEditor(_SelectedCell.CellBounds);
		}

		/// <summary>
		/// 滚动位置改变时
		/// </summary>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			if (_SelectedCell != null) ArrangeEditor(_SelectedCell.CellBounds);
		}

		/// <summary>
		/// 点击鼠标时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			if (_SelectedCell != null)
			{
				TryClickButtons(e.X, e.Y);
				TryEnterEditor();
			}
		}

		/// <summary>
		/// 尝试点击按钮
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		protected virtual void TryClickButtons(int x, int y)
		{
			if (_SelectedCell == null) return;

			foreach (ThorDataTableCellButton btn in _SelectedCell.Buttons)
			{
				if (btn.Bounds.Contains(x, y))
				{
					switch (btn.ButtonType)
					{
						case ThorDataTableCellButtonType.DropDown:
							TryDropDown();
							break;

						case ThorDataTableCellButtonType.ModalDialog:
							TryModalDialog();
							break;
					}

					break;
				}
			}
		}

		

		/// <summary>
		/// 缩放窗体时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			TryHideEditors();
		}

		

		#endregion

		#region 数据

		#endregion

		#region 接口


		/// <summary>
		/// 获取编辑器
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		public IEditorInteractive GetEditor(ThorDataTableCell cell)
		{

			//单元
			if (cell.Editor != null) return cell.Editor;

			//列
			ThorDataTableColumn column = cell.GetColumn();
			if (column != null && column.Editor != null) return column.Editor;

			return DefaultEditor;
		}

		/// <summary>
		/// 获取转换器
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		public IThorTypeConverter GetConverter(ThorDataTableCell cell)
		{
			//单元
			if (cell.Editor != null) return cell.TypeConverter;

			//列
			ThorDataTableColumn column = cell.GetColumn();
			if (column != null && column.TypeConverter != null) return column.TypeConverter;

			return DefaultConverter;
		}

		#endregion

		#region 编辑

		/// <summary>
		/// 初始化编辑器
		/// </summary>
		protected virtual void InitEditors()
		{
			InitTextEditor();
			InitPopupEditor();
		}

		/// <summary>
		/// 初始化文本编辑器
		/// </summary>
		protected virtual void InitTextEditor()
		{
			TextEditor = new TextBox();
			TextEditor.BorderStyle = BorderStyle.None;
			TextEditor.BackColor = ThorColors.Focus;
			TextEditor.ForeColor = ThorColors.HighLightText;
			TextEditor.TextChanged += TextEditor_TextChanged;
			TextEditor.KeyDown += TextEditor_KeyDown;
			Controls.Add(TextEditor);
		}

		

		/// <summary>
		/// 初始化弹出层
		/// </summary>
		protected virtual void InitPopupEditor()
		{
			PopupEditor = new FlatPopuper();
		}

		/// <summary>
		/// 布置编辑器
		/// </summary>
		protected virtual void ArrangeEditor(Rectangle rectCell)
		{

			if (_SelectedRow == null || _SelectedRow.Rows.Count > 0)
			{
				TextEditor.Visible = false;
				return;
			}

			if (TextEditor != null && _SelectedCell != null)
			{
				if (_SelectedCell.CellBounds.Width == 0 || _SelectedCell.CellBounds.Height == 0)
				{
					TextEditor.Visible = false;
					return;
				}

				Color themeColor = GetThemeColor();
				if (themeColor == null) return;
				if (themeColor == Color.Transparent) themeColor = ThorColors.Focus;
				TextEditor.BackColor = ThorColors.GridFocusBackground;
				TextEditor.ForeColor = ThorColors.GridFocusForeground;

				int bs = 1;
				int tp = 6;
				rectCell.X += bs;
				rectCell.Y += bs;
				rectCell.Width -= bs * 1;
				rectCell.Height -= bs * 2;

				rectCell.X += tp;
				rectCell.Width -= tp * 2 - 1;
				rectCell.Y += (rectCell.Height - TextEditor.Height) / 2;

				if (_SelectedCell.Buttons.Count > 0)
				{
					rectCell.Width = _SelectedCell.TextBounds.Width;
				}
				try
				{
					IThorTypeConverter typeConverter = GetConverter(_SelectedCell);

					if (rectCell.Width < 0 || rectCell.Height < 0)
					{
						TextEditor.Visible = false;
						return;
					}


					if (TextEditor.Tag != _SelectedCell)
					{
						if (typeConverter != null && typeConverter.AllowGetText(_SelectedCell, _SelectedCell.DataType))
						{
							TextEditor.Text = typeConverter.GetText(_SelectedCell.Data, _SelectedCell.DataType);
						}
						else
						{
							TextEditor.Text = "";
						}
					}
					TextEditor.Tag = _SelectedCell;
					TextEditor.Location = rectCell.Location;
					TextEditor.Size = rectCell.Size;
					TextEditor.Visible = true;
				}
				catch (Exception ex)
				{
					Debug.Write(ex.ToString());
				}
			}
			else
			{
				TextEditor.Visible = false;
			}
		}

		/// <summary>
		/// 尝试保存编辑器数据
		/// </summary>
		protected virtual void TrySaveTextEditorData()
		{
			if (_SelectedCell == null) return;
			if (TextEditor == null) return;

			string strData = TextEditor.Text;
			SaveCellDataByText(strData);
		}

		/// <summary>
		/// 保存文本为单元数据
		/// </summary>
		/// <param name="text"></param>
		protected virtual void SaveCellDataByText(string text)
		{
			if (_SelectedCell == null) return;

			IThorTypeConverter typeConverter = GetConverter(_SelectedCell);
			if (typeConverter == null) return;
			if (!typeConverter.AllowGetObject(text, _SelectedCell.DataType)) return;
			object cellData = typeConverter.GetObject(text, _SelectedCell.DataType);
			_SelectedCell.Data = cellData;

			if (_SelectedCell.CellBindPropertyInfo != null && _SelectedCell.CellBindPropertyObject != null)
			{

				try
				{
					_SelectedCell.CellBindPropertyInfo.SetValue(_SelectedCell.CellBindPropertyObject, cellData);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(String.Format("(ERROR) SaveCellDataByText", ex.Message));
				}
			}
		}


		/// <summary>
		/// 文本编辑器中按键按下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void TextEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Control && !e.Alt && !e.Shift && e.KeyCode == Keys.Enter)
			{
				TrySaveTextEditorData();
				TryHideEditors();
			}
			else if (!e.Control && !e.Alt && !e.Shift && e.KeyCode == Keys.Cancel)
			{
				TryHideEditors();
			}
		}

		protected virtual void TextEditor_TextChanged(object sender, EventArgs e)
		{

		}


		/// <summary>
		/// 尝试进入编辑器
		/// </summary>
		protected virtual void TryEnterEditor()
		{
			if (TextEditor != null && TextEditor.Visible)
			{
				TextEditor.Select();
			}
		}

		/// <summary>
		/// 尝试打开下拉
		/// </summary>
		protected virtual void TryDropDown()
		{
			if (PopupEditor == null) return;
			if (_SelectedCell == null) return;

			Rectangle r = new Rectangle(_SelectedCell.CellBounds.X, _SelectedCell.CellBounds.Y, _SelectedCell.CellBounds.Width, _SelectedCell.CellBounds.Height);
			r.Width += 1;
			PopupEditor.Show(this, r);
		}

		/// <summary>
		/// 尝试打开模态窗
		/// </summary>
		protected virtual void TryModalDialog()
		{
			ThorUI.ShowMessageBox("TODO: TryModalDialog ...");
		}

		/// <summary>
		/// 尝试隐藏所有编辑器
		/// </summary>
		protected virtual void TryHideEditors()
		{
			if (TextEditor != null)
			{
				TextEditor.Visible = false;
			}

			if (PopupEditor != null)
			{
				PopupEditor.Hide();
			}
		}

		#endregion

		#endregion

		#region properties

		#region 外观





		#endregion

		#region 数据



		#endregion

		#endregion

		#region events

		#endregion
	}
}
