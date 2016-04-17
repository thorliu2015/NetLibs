/*
 * ThorAbstractGrid
 * liuqiang@2015/11/1 22:35:18
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using THOR.Windows.Components.Common;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Dialogs;

//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Core
{
	/// <summary>
	/// 数据表控件的抽象类
	/// </summary>
	public class ThorAbstractGrid : ThorScrollView
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public ThorAbstractGrid()
			: base()
		{
			InitGrid();
		}

		#endregion

		#region methods

		#region 初始化

		/// <summary>
		/// 初始化网格
		/// </summary>
		protected virtual void InitGrid()
		{
		}

		/// <summary>
		/// 初始化滚动条
		/// </summary>
		protected override void InitScrollBars()
		{
			base.InitScrollBars();

			this.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		}

		#endregion

		#region 外观

		/// <summary>
		/// 绘制内容
		/// </summary>
		/// <param name="e"></param>
		protected override void DrawScrollContent(PaintEventArgs e)
		{
			BuildTableCacheData();

			if (_Render == null) return;

			Color themeColor = GetThemeColor();

			//绘制背景
			ThorGridRenderArgs drawGridBackgroundArgs = new ThorGridRenderArgs(this, e.Graphics, themeColor);
			_Render.DrawGridBackground(drawGridBackgroundArgs);

			//绘制行
			DrawRows(e);
		}

		/// <summary>
		/// 获取主题颜色
		/// </summary>
		/// <returns></returns>
		protected Color GetThemeColor()
		{
			Form f = this.FindForm();
			if (f is FlatForm)
			{
				FlatForm ff = (FlatForm)f;

				return ff.ThemeColor;
			}

			return Color.Transparent;
		}

		/// <summary>
		/// 绘制行
		/// </summary>
		/// <param name="e"></param>
		protected virtual void DrawRows(PaintEventArgs e)
		{
			if (_Render == null) return;

			//计算坐标
			Rectangle rectRow = new Rectangle();
			rectRow.Height = _RowHeight;
			rectRow.Width = Width - borderSize * 2;
			rectRow.X = borderSize;

			if (vScrollBar.Visible)
			{
				rectRow.Width -= vScrollBar.Width;
			}

			//计算状态

			//绘制
			ThorGridRowRenderArgs drawRowArgs = new ThorGridRowRenderArgs(this, e.Graphics, GetThemeColor());


			for (int i = 0; i < DataTableRowsCache.Count; i++)
			{
				ThorDataTableRow row = DataTableRowsCache[i];

				rectRow.Y = borderSize + i * _RowHeight - vScrollBar.Value;

				if (rectRow.Bottom < borderSize)
				{
					row.DisplayBounds = new Rectangle();
					continue;
				}
				if (rectRow.Top > Height)
				{
					row.DisplayBounds = new Rectangle();
					continue;
				}

				drawRowArgs.Bounds = rectRow;
				drawRowArgs.Row = row;

				_Render.DrawRowBackground(drawRowArgs);
				_Render.DrawRowForeground(drawRowArgs);
			}
		}


		#endregion

		#region 数据

		/// <summary>
		/// 构造表格缓存数据
		/// </summary>
		protected virtual void BuildTableCacheData()
		{

			//----

			if (_DataTable == null) return;
			if (!_DataTable.Invalidated) return;

			DataTableRowsCache.Clear();
			if (_DataTable.Rows.Count == 0) return;
			int p = 0;
			int w = 0;
			for (int i = 0; i < _DataTable.Columns.Count; i++)
			{
				w = _DataTable.Columns[i].Width;
				_DataTable.Columns[i].Position = p;
				p += w;
			}

			foreach (ThorDataTableRow row in _DataTable.Rows)
			{
				DataTableRowsCache.Add(row);
				if (row.IsExpanded && row.Rows.Count > 0)
				{
					BuildTableRowsCache(row);
				}
			}

			_DataTable.Invalidated = false;
		}

		/// <summary>
		/// 构建表格行缓存数据
		/// </summary>
		/// <param name="row"></param>
		protected virtual void BuildTableRowsCache(ThorDataTableRow row)
		{
			foreach (ThorDataTableRow childRow in row.Rows)
			{
				DataTableRowsCache.Add(childRow);
				if (childRow.IsExpanded && childRow.Rows.Count > 0)
				{
					BuildTableRowsCache(childRow);
				}
			}
		}

		/// <summary>
		/// 计算滚动内容大小
		/// </summary>
		/// <returns></returns>
		protected override Size MeasureScrollContentSize()
		{
			Size size = new Size();

			size.Width = 0;
			size.Height = DataTableRowsCache.Count * _RowHeight;

			return size;
		}


		#endregion

		#region 交互

		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			//选取行
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				ThorDataTableRow row = GetRowFromPoint(e.X, e.Y);


				bool needThrowEvent = false;

				if (row != _SelectedRow) needThrowEvent = true;
				this._SelectedRow = row;
				

				TryClickFoldIcon(e.X, e.Y);


				this.LayoutScrollView();
				this.Invalidate();

				if (needThrowEvent && SelectionChanged != null)
				{
					SelectionChanged(this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// 尝试点击折叠项
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		protected virtual void TryClickFoldIcon(int x, int y)
		{
			ThorDataTableRow row = GetRowFromPointByFullRowMode(x, y);
			if (row == null) return;

			if (row.FoldBounds != null && row.FoldBounds.Contains(x, y))
			{
				row.IsExpanded = !row.IsExpanded;
				this.BuildTableCacheData();
			}
		}

		/// <summary>
		/// 获取指定位置的行
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public virtual ThorDataTableRow GetRowFromPoint(int x, int y)
		{
			bool bUseFullSelectionMode = true;

			if (bUseFullSelectionMode)
			{
				return GetRowFromPointByFullRowMode(x, y);
			}
			else
			{
				return GetRowFromPointByDisplayBounds(x, y);
			}
		}

		/// <summary>
		/// 以整行选择模式获取指定位置的行
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public virtual ThorDataTableRow GetRowFromPointByFullRowMode(int x, int y)
		{
			int p = y + vScrollBar.Value;

			int i = p / _RowHeight;

			if (i >= 0 && i < DataTableRowsCache.Count)
			{
				return DataTableRowsCache[i];
			}

			return null;
		}

		/// <summary>
		/// 以显示区域模式获取指定位置的行
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public virtual ThorDataTableRow GetRowFromPointByDisplayBounds(int x, int y)
		{
			ThorDataTableRow row = GetRowFromPointByFullRowMode(x, y);
			if (row != null)
			{
				if (row.DisplayBounds.Contains(x, y))
				{
					return row;
				}
			}
			return null;
		}

		/// <summary>
		/// 滚动至选定区域
		/// </summary>
		public virtual void ScrollToSelection(bool noRedraw = false)
		{
			if (_DataTable == null) return;
			if (_SelectedRow == null) return;

			_SelectedRow.ExpandToThis();

			int rowIndex = 0;

			rowIndex = DataTableRowsCache.IndexOf(_SelectedRow);

			int nTop = _FixedRows * _RowHeight;
			int nBottom = Height;

			if (hScrollBar.Visible)
			{
				nBottom -= hScrollBar.Height;
			}

			Rectangle rect = new Rectangle();
			rect.Height = _RowHeight;
			rect.Width = this.Width;
			rect.X = 0;
			rect.Y = rowIndex * _RowHeight - vScrollBar.Value;

			if (rect.Bottom > nBottom)
			{
				vScrollBar.Value = (rowIndex - _FixedRows) * _RowHeight;
			}

			if (rect.Top < nTop)
			{
				vScrollBar.Value = (rowIndex - _FixedRows) * _RowHeight;
			}

			if (!noRedraw)
			{
				this.Invalidate();
			}
		}




		#region 键盘

		/// <summary>
		/// 键盘事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			OnKeyboardEvent(e);
		}

		/// <summary>
		/// 键盘事件
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnKeyboardEvent(KeyEventArgs e)
		{
			if (!e.Control && e.Alt && !e.Shift)
			{
				switch (e.KeyCode)
				{
					case Keys.Up:
						SetSelectedCell(0, -1);
						e.Handled = true;
						break;

					case Keys.Down:
						SetSelectedCell(0, 1);
						e.Handled = true;
						break;

					case Keys.Left:
						SetSelectedCell(-1, 0);
						e.Handled = true;
						break;

					case Keys.Right:
						SetSelectedCell(1, 0);
						e.Handled = true;
						break;

					case Keys.Home:
						SetSelectedCell(int.MinValue, 0);
						e.Handled = true;
						break;

					case Keys.End:
						SetSelectedCell(int.MaxValue, 0);
						e.Handled = true;
						break;
				}
			}

			if (e.Control && !e.Alt && !e.Shift)
			{
				switch (e.KeyCode)
				{
					case Keys.Home:
						SetSelectedCell(0, 0, false);
						e.Handled = true;
						break;

					case Keys.End:
						SetSelectedCell(Int32.MaxValue, Int32.MaxValue, false);
						e.Handled = true;
						break;
				}
			}

		}

		/// <summary>
		/// 设置选定单元
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="offsetMode"></param>
		protected virtual void SetSelectedCell(int x, int y, bool offsetMode = true)
		{
			if (_DataTable == null) return;

			int nx = x;
			int ny = y;
			if (offsetMode)
			{
				if (_SelectedRow == null || _SelectedCell == null) return;

				int cx = _SelectedRow.Cells.IndexOf(_SelectedCell);
				int cy = DataTableRowsCache.IndexOf(_SelectedRow);

				nx += cx;
				ny += cy;
			}

			if (nx > _DataTable.Columns.Count - 1) nx = _DataTable.Columns.Count - 1;
			if (ny > DataTableRowsCache.Count - 1) ny = DataTableRowsCache.Count - 1;

			nx = CheckCellColumnIndex(nx);
			ny = CheckCellRowIndex(ny);

			if (nx < 0) nx = 0;
			if (ny < 0) ny = 0;

			ThorDataTableRow newRow = DataTableRowsCache[ny];
			ThorDataTableCell newCell = newRow.Cells[nx];

			_SelectedRow = newRow;
			_SelectedCell = newCell;
			ScrollToSelection(true);
			this.LayoutScrollView();
			this.Invalidate();

			ScrollToSelection();
		}

		protected virtual int CheckCellRowIndex(int ny)
		{
			if (ny < _FixedRows) ny = _FixedRows;
			return ny;
		}

		protected virtual int CheckCellColumnIndex(int nx)
		{
			if (nx < _FixedColumns) nx = _FixedColumns;
			return nx;
		}

		#endregion

		#endregion

		#region 编辑



		#endregion

		#endregion

		#region properties

		#region 外观

		/// <summary>
		/// 行高
		/// </summary>
		protected int _RowHeight = 24;

		/// <summary>
		/// 网格渲染方法
		/// </summary>
		protected ThorAbstractGridRender _Render = new ThorAbstractGridRender();

		//----

		/// <summary>
		/// 获取或设置行高
		/// </summary>
		public int RowHeight
		{
			get
			{
				return _RowHeight;
			}
			set
			{
				if (_RowHeight != value) return;
				_RowHeight = value;

				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置网格渲染方法
		/// </summary>
		public ThorAbstractGridRender Render
		{
			get
			{
				return _Render;
			}
			set
			{
				if (_Render == value) return;
				_Render = value;
				this.Invalidate();
			}
		}

		#endregion

		#region 交互

		#endregion

		#region 编辑

		#endregion

		#region 数据

		protected ThorDataTableRow _SelectedRow = null;
		protected ThorDataTableCell _SelectedCell;
		protected int _FixedRows = 1;
		protected int _FixedColumns = 1;

		/// <summary>
		/// 缓存表
		/// </summary>
		protected List<ThorDataTableRow> DataTableRowsCache = new List<ThorDataTableRow>();

		/// <summary>
		/// 数据表
		/// </summary>
		protected ThorDataTable _DataTable = null;

		/// <summary>
		/// 获取或设置数据表
		/// </summary>
		public ThorDataTable DataTable
		{
			get
			{
				return _DataTable;
			}
			set
			{
				if (_DataTable == value) return;
				_DataTable = value;
				if (_DataTable != null) _DataTable.Invalidated = true;
				this.BuildTableCacheData();
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置选定的行
		/// </summary>
		public ThorDataTableRow SelectedRow
		{
			get
			{
				return _SelectedRow;
			}
			set
			{
				if (_SelectedRow == value) return;
				_SelectedRow = value;
				this.Invalidate();
			}
		}


		/// <summary>
		/// 获取或设置选定的单元
		/// </summary>
		public ThorDataTableCell SelectedCell
		{
			get
			{
				return _SelectedCell;
			}
			set
			{
				if (_SelectedCell == value) return;
				_SelectedCell = value;
				this.Invalidate();
			}
		}




		/// <summary>
		/// 获取或设置固定行数
		/// </summary>
		public int FixedRows
		{
			get
			{
				return _FixedRows;
			}
			set
			{
				_FixedRows = value;
				this.BuildTableCacheData();
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置固定列数
		/// </summary>
		public int FixedColumns
		{
			get
			{
				return _FixedColumns;
			}
			set
			{
				_FixedColumns = value;
				this.BuildTableCacheData();
				this.LayoutScrollView();
				this.Invalidate();
			}
		}

		/// <summary>
		/// 网格数据缓存
		/// </summary>
		public List<ThorDataTableRow> GridDataCache
		{
			get
			{
				return DataTableRowsCache;
			}
		}

		#endregion

		#endregion

		#region events
		public event EventHandler SelectionChanged;
		#endregion
	}
}
