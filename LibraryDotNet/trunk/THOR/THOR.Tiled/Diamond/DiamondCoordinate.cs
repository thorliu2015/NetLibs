/*
 * DiamondCoordinate
 * liuqiang@2015/12/3 10:31:58
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

namespace THOR.Tiled.Diamond
{
	/// <summary>
	/// 斜角坐标系
	/// </summary>
	public class DiamondCoordinate : ITiledCoordinate
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public DiamondCoordinate()
		{
			TileSize = new Size(40, 20);
		}

		#endregion

		#region methods

		public Point IsoToDisplay(int x, int y)
		{
			Point ret = new Point();

			double r = Convert.ToDouble(TileSize.Width) / Convert.ToDouble(TileSize.Height);

			ret.X = x;
			ret.Y = Convert.ToInt32(y / r);

			return ret;
		}

		public Point DisplayToIso(int x, int y)
		{
			Point ret = new Point();

			double r = Convert.ToDouble(TileSize.Width) / Convert.ToDouble(TileSize.Height);

			ret.X = x;
			ret.Y = Convert.ToInt32(y * r);

			return ret;
		}

		public Point TileToDisplay(int x, int y)
		{
			Point ret = new Point();

			double tx = x;
			double ty = y;
			double tw = TileSize.Width;
			double th = TileSize.Height;

			ret.X = Convert.ToInt32((ty - tx) * (tw / 2));
			ret.Y = Convert.ToInt32((ty + tx) * (th / 2));

			ret.Y += TileSize.Height / 2;

			return ret;
		}

		public Point DisplayToTile(int x, int y)
		{
			Point ret = new Point();

			double tx = x;
			double ty = y - (TileSize.Height / 2);
			double tw = TileSize.Width;
			double th = TileSize.Height;

			ret.X = -Convert.ToInt32(tx / tw - ty / th);
			ret.Y = Convert.ToInt32(tx / tw + ty / th);

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

			//----------[\]

			int bx = 0;
			int by = 0;
			int ex = columns * (TileSize.Width / 2);
			int ey = columns * (TileSize.Height / 2);

			int x1 = 0;
			int y1 = 0;
			int x2 = 0;
			int y2 = 0;

			for (int r = 0; r <= rows; r++)
			{
				x1 = bx - (r * TileSize.Width / 2);
				y1 = by + (r * TileSize.Height / 2);
				x2 = ex - (r * TileSize.Width / 2);
				y2 = ey + (r * TileSize.Height / 2);


				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = r;
				l.X1 = x1;
				l.Y1 = y1;
				l.X2 = x2;
				l.Y2 = y2;
				ret.RowLines.Add(l);
			}

			//----------[/]

			ex = -rows * (TileSize.Width / 2);
			ey = rows * (TileSize.Height / 2);

			for (int c = 0; c <= columns; c++)
			{
				x1 = bx + (c * TileSize.Width / 2);
				y1 = by + (c * TileSize.Height / 2);
				x2 = ex + (c * TileSize.Width / 2);
				y2 = ey + (c * TileSize.Height / 2);

				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = c;
				l.X1 = x1;
				l.Y1 = y1;
				l.X2 = x2;
				l.Y2 = y2;
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
