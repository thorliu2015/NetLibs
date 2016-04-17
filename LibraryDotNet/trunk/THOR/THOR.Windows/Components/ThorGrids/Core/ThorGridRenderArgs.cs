/*
 * ThorGridRenderArgs
 * liuqiang@2015/11/14 17:22:16
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.ThorGrids.Models;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Core
{
	/// <summary>
	/// 表格绘制参数
	/// </summary>
	public class ThorGridRenderArgs
	{
		public ThorGridRenderArgs(ThorAbstractGrid grid, Graphics g, Color theme)
		{
			this.Grid = grid;
			this.Graphics = g;
			this.ThemeColor = theme;
		}

		public ThorAbstractGrid Grid { get; protected set; }
		public Graphics Graphics { get; protected set; }
		public Color ThemeColor { get; protected set; }
	}

	/// <summary>
	/// 表格行绘制参数
	/// </summary>
	public class ThorGridRowRenderArgs : ThorGridRenderArgs
	{
		public ThorGridRowRenderArgs(ThorAbstractGrid grid, Graphics g, Color theme)
			: base(grid, g, theme)
		{
		}

		public ThorDataTableRow Row { get; internal set; }
		public Rectangle Bounds { get; internal set; }
	}

	/// <summary>
	/// 表格单位绘制参数
	/// </summary>
	public class ThorGridCellRenderArgs : ThorGridRenderArgs
	{
		public ThorGridCellRenderArgs(ThorAbstractGrid grid, Graphics g, Color theme)
			: base(grid, g, theme)
		{
		}

		public ThorDataTableCell Cell { get; internal set; }
		public Rectangle Bounds { get; internal set; }
		public int RowIndex { get; internal set; }
		public int ColumnIndex { get; internal set; }
		public ThorGrid GridControl { get; internal set; }
		public ThorDataTableRow Row { get; internal set; }
	}

	/// <summary>
	/// 图形绘制参数
	/// </summary>
	public class ThorGridShapeRenderArgs : ThorGridRenderArgs
	{
		public ThorGridShapeRenderArgs(ThorAbstractGrid grid, Graphics g, Color theme)
			: base(grid, g, theme)
		{
		}

		public Rectangle Bounds { get; internal set; }
	}



}
