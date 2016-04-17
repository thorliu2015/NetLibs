using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.D2D.Core;

namespace THOR.D2D.Graphics
{
	/// <summary>
	/// 常用的渲染功能
	/// </summary>
	public class D2DRenderUtils
	{
		/// <summary>
		/// 绘制透明网格
		/// </summary>
		/// <param name="region"></param>
		/// <param name="cell"></param>
		/// <param name="brush1"></param>
		/// <param name="brush2"></param>
		static public void DrawAlphaGrid(D2DCanvasRegion region, int cell, SolidColorBrush brush1, SolidColorBrush brush2)
		{
			int rows = region.ViewPortHeight / cell + 3;
			int cols = region.ViewPortWidth / cell + 3;

			SharpDX.RectangleF rect = new SharpDX.RectangleF();
			rect.Width = cell;
			rect.Height = cell;

			int offsetX = region.X % cell;
			int offsetY = region.Y % cell;

			offsetX = -(cell - offsetX);
			offsetY = -(cell - offsetY);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					rect.X = c * cell + offsetX;
					rect.Y = r * cell + offsetY;

					region.Controller.WindowRenderTarget.FillRectangle(rect, ((r + c) % 2 == 0) ? brush1 : brush2);
				}
			}
		}
	}
}
