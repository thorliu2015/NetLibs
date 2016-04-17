/*
 * StaggeredCoordinate
 * liuqiang@2015/12/3 10:37:54
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
using THOR.Tiled.Common;


//---- 8< ------------------

/*
 *	--[ 4 x 3 ]--
 * 
 *	(0,0)	(1,0)	(2,0)	(3,0)
 *		(0,1)	(1,1)	(2,1)	(3,1)
 *	(0,2)	(1,2)	(2,2)	(3,2)
 * 
 * ------------------
    int offset = 0;  
    for (int paintY = 0; paintY <= SCREEN_H + CHIP_H; paintY += CHIP_H / 2)   
      
        for (int paintX = 0; paintX <= SCREEN_W + CHIP_W; paintX += CHIP_W)   
       {  
            int gx = getGx(paintX + offset, paintY) + startCol;  
            int gy = getGy(paintX + offset, paintY) + startRow;   
            if (gy < 0 || gx < 0 || gy > 10 || gx > 10)  
            {   
                continue;   
            }   
            drawTile(g, data[gy][gx], paintX + offset, paintY);
        }   
        offset = offset == 0 ? CHIP_W / 2 : 0;  
    }

    //屏幕坐标转换成游戏坐标
    int getGx(int x, int y)   
    {  
         return (int) (0.5f * (y / (CHIP_H >> 1) + x / (CHIP_W >> 1)));   
    }  
      
     int getGy(int x, int y)   
    {  
         return (int) (0.5f * (y / (CHIP_H >> 1) - x / (CHIP_W >> 1)));   
    } 
 */

namespace THOR.Tiled.Staggered
{
	/// <summary>
	/// 交错斜角坐标系
	/// </summary>
	public class StaggeredCoordinate : ITiledCoordinate
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public StaggeredCoordinate()
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

			ret.X = x * TileSize.Width + TileSize.Width / 2;

			if (y % 2 != 0)
			{
				ret.X += TileSize.Width / 2;
			}

			ret.Y = (y + 1) * TileSize.Height / 2;

			return ret;
		}

//logic.y = ( 2 * stage.y ) / TileHeigth;
//logic.x = ( stage.x / TileWidth ) - ( logic.y & 1 ) * ( TileWidth / 2 );

//logic.x = Math.floor((stage.y + stage.x * .5) / tileWidth);
//logic.y = Math.floor((stage.x * .5 - stage.y) / tileWidth + i + 1);

		public Point DisplayToTile(int x, int y)
		{
			Point ret = new Point();

			//TODO: 没实现

			return ret;
		}


		public Size GetTotalSize(int rows, int columns)
		{
			Size ret = new Size();

			ret.Width = columns * TileSize.Width;
			ret.Height = (rows + 1) * (TileSize.Height / 2);


			return ret;
		}

		public TileCoordinateGrid GetGrid(int rows, int columns)
		{
			TileCoordinateGrid ret = new TileCoordinateGrid();

			int nRowCount = rows / 2;
			if (!IsDoubleInt(rows)) nRowCount++;

			//---- [\]
			int nCount1 = columns + nRowCount;

			for (int i = 0; i < nCount1; i++)
			{
				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = i;

				int nMax = Math.Min(nRowCount, columns);

				if (i < nMax)
				{
					//[^]
					l.X1 = 0;
					l.Y1 = (nRowCount) * (TileSize.Height) - (i * TileSize.Height) - TileSize.Height / 2;
					l.X2 = TileSize.Width / 2 + (i * TileSize.Width);
					l.Y2 = nRowCount * TileSize.Height;
				}
				else
				{
					//[>]
					int nIndex = i - nRowCount;

					l.X1 = TileSize.Width / 2 + nIndex * TileSize.Width;
					l.Y1 = 0;

					if (i >= columns)
					{
						l.X2 = columns * TileSize.Width;
						l.Y2 = nRowCount * TileSize.Height - (i - columns) * TileSize.Height - TileSize.Height / 2;
					}
					else
					{
						l.X2 = l.X1 + nRowCount * TileSize.Width;
						l.Y2 = nRowCount * TileSize.Height;
					}
				}

				//Debug.WriteLine(String.Format("{0},{1},{2},{3}", l.X1, l.Y1, l.X2, l.Y2));

				ret.RowLines.Add(l);

			}


			//---- [/]
			int nCount2 = columns + nRowCount;

			for (int i = 0; i < nCount1; i++)
			{
				TileCoordinatedGridLine l = new TileCoordinatedGridLine();
				l.Index = i;

				int nMax = Math.Min(nRowCount, columns);

				if (i < nMax)
				{
					//[>]
					l.X1 = TileSize.Width / 2 + (i * TileSize.Width);
					l.Y1 = 0;
					l.X2 = 0;
					l.Y2 = TileSize.Height / 2 + (i * TileSize.Height);
				}
				else
				{
					//[v]
					if (i < columns)
					{
						l.X1 = TileSize.Width / 2 + i * TileSize.Width;
						l.Y1 = 0;
						l.X2 = TileSize.Width / 2 + ((i - nMax) * TileSize.Width);
						l.Y2 = nRowCount * TileSize.Height;
					}
					else
					{
						l.X1 = columns * TileSize.Width;
						l.Y1 = TileSize.Height / 2 + (i - columns) * TileSize.Height;

						if (i < nRowCount)
						{
							l.X2 = 0;
							l.Y2 = TileSize.Height / 2 + (i * TileSize.Height);
						}
						else
						{
							l.X2 = TileSize.Width / 2 + ((i - nRowCount) * TileSize.Width);
							l.Y2 = nRowCount * TileSize.Height;
							//l.X2 = TileSize.Width / 2 + ((i - nMax) * TileSize.Width);
							//l.Y2 = nRowCount * TileSize.Height;
							//continue;
						}

					}
				}

				ret.RowLines.Add(l);
			}

			return ret;
		}

		protected bool IsDoubleInt(int v)
		{
			return (v % 2) == 0;
		}

		#endregion

		#region properties
		public Size TileSize { get; set; }

		public int TileWidth { get { return TileSize.Width; } }
		public int TileHeight { get { return TileSize.Height; } }

		#endregion

		#region events

		#endregion
	}
}
