/*
 * SquareCoordinate
 * liuqiang@2015/12/3 15:13:02
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Tiled.Common;


//---- 8< ------------------

namespace THOR.Tiled.Square
{
	/// <summary>
	/// 正方形坐标系
	/// </summary>
	public class SquareCoordinate : ITiledCoordinate
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public SquareCoordinate()
		{
			TileSize = new Size(30, 30);
		}

		#endregion

		#region methods
		public Point IsoToDisplay(int x, int y)
		{
			Point ret = new Point(x, y);

			return ret;
		}

		public Point DisplayToIso(int x, int y)
		{
			Point ret = new Point(x, y);

			return ret;
		}

		public Point TileToDisplay(int x, int y)
		{
			Point ret = new Point();

			ret.X = x * TileSize.Width;
			ret.Y = y * TileSize.Height;

			ret.X += (TileSize.Width / 2);
			ret.Y += (TileSize.Height / 2);

			return ret;
		}

		public Point DisplayToTile(int x, int y)
		{
			Point ret = new Point();

			ret.X = (x / TileSize.Width);
			ret.Y = (y / TileSize.Height);

			return ret;
		}

		public Size GetTotalSize(int rows, int columns)
		{
			Size ret = new Size();

			return ret;
		}

		public TileCoordinateGrid GetGrid(int rows, int columns)
		{
			TileCoordinateGrid ret = new TileCoordinateGrid();


			//------ [-]
			int bx = 0;
			int by = 0;
			int ex = columns * TileSize.Width;
			int ey = 0;

			for (int r = 0; r <= rows; r++)
			{
				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = r;
				l.X1 = bx;
				l.X2 = ex;
				l.Y1 = by + r * TileSize.Height;
				l.Y2 = ey + r * TileSize.Height;

				ret.RowLines.Add(l);
			}

			//------- [|]
			ex = 0;
			ey = rows * TileSize.Height;

			for (int c = 0; c <= columns; c++)
			{
				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = c;
				l.X1 = bx + c * TileSize.Width;
				l.X2 = ex + c * TileSize.Width;
				l.Y1 = by;
				l.Y2 = ey;

				ret.ColumnLines.Add(l);
			}

			return ret;
		}
		#endregion

		#region properties
		public Size TileSize { get; set; }
		#endregion

		#region events

		#endregion
	}
}
