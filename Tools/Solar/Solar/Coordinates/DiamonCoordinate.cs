/*
 * 
 *		x(cols)								y(rows)
 *		/									\
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Solar.Coordinates
{
	/// <summary>
	/// Diamon斜角坐标系
	/// </summary>
	public class DiamonCoordinate : ICoordinate
	{
		public DiamonCoordinate()
		{
			GridSize = new Size(40, 20);
		}

		public DiamonCoordinate(int tileWidth, int tileHeight)
		{
			GridSize = new Size(tileWidth, tileHeight);
		}

		public System.Drawing.Point ScreenToLogic(System.Drawing.Point screenPosition)
		{
			Point r = new Point();

			r.X = screenPosition.X;
			r.Y = Convert.ToInt32(
					Convert.ToDouble(screenPosition.Y) *
					(Convert.ToDouble(GridSize.Width) / Convert.ToDouble(GridSize.Height))
				);


			return r;
		}

		public System.Drawing.Point LogicToScreen(System.Drawing.Point logicPosition)
		{

			Point r = new Point();

			r.X = logicPosition.X;
			r.Y = Convert.ToInt32(
					Convert.ToDouble(logicPosition.Y) *
					(Convert.ToDouble(GridSize.Height) / Convert.ToDouble(GridSize.Width))
				);

			return r;
		}

		public System.Drawing.Point ScreenToGrid(System.Drawing.Point screenPosition)
		{
			Point r = new Point();

			double x = screenPosition.X;
			double y = screenPosition.Y - (GridSize.Height / 2);
			double tw = GridSize.Width;
			double th = GridSize.Height;

			r.X = -Convert.ToInt32(x / tw - y / th);
			r.Y = Convert.ToInt32(x / tw + y / th);

			return r;
		}

		public System.Drawing.Point GridToScreen(System.Drawing.Point gridPosition)
		{
			Point r = new Point();

			double x = gridPosition.X;
			double y = gridPosition.Y;
			double tw = GridSize.Width;
			double th = GridSize.Height;

			r.X = Convert.ToInt32((y - x) * (tw / 2));
			r.Y = Convert.ToInt32((y + x) * (th / 2));

			r.Y += GridSize.Height / 2;

			return r;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="cols"></param>
		/// <param name="x1Points">右斜边A点X坐标</param>
		/// <param name="x2Points">右斜边B点X坐标</param>
		/// <param name="x3Points">左斜边A点X坐标</param>
		/// <param name="x4Points">左斜边B点X坐标</param>
		/// <param name="y1Points">右斜边A点Y坐标</param>
		/// <param name="y2Points">右斜边B点Y坐标</param>
		/// <param name="y3Points">左斜边A点Y坐标</param>
		/// <param name="y4Points">左斜边B点Y坐标</param>
		public void GetGridPoints(int rows, int cols,
			List<int> x1Points,
			List<int> x2Points,
			List<int> x3Points,
			List<int> x4Points,

			List<int> y1Points,
			List<int> y2Points,
			List<int> y3Points,
			List<int> y4Points)
		{
			x1Points.Clear();
			x2Points.Clear();
			y1Points.Clear();
			y2Points.Clear();

			int tw = GridSize.Width >> 1;
			int th = GridSize.Height >> 1;

			if (rows == 0 || cols == 0) return;

			for (int i = 0; i <= cols; i++)
			{
				int x1 = -i * tw;
				int x2 = Convert.ToInt32(cols - i) * tw;

				x1Points.Add(x1);
				x2Points.Add(x2);
			}

			for (int i = 0; i <= rows; i++)
			{
				int y1 = i * th;
				int y2 = Convert.ToInt32(i + rows) * th;

				y1Points.Add(y1);
				y2Points.Add(y2);
			}

			for (int i = 0; i <= cols; i++)
			{
				int x3 = i * tw;
				int x4 = -Convert.ToInt32(cols - i) * tw;

				x3Points.Add(x3);
				x4Points.Add(x4);
			}

			for (int i = 0; i <= rows; i++)
			{
				int y3 = i * th;
				int y4 = Convert.ToInt32(i + rows) * th;

				y3Points.Add(y3);
				y4Points.Add(y4);
			}

		}

		public System.Drawing.Size GridSize { get; set; }
	}
}
