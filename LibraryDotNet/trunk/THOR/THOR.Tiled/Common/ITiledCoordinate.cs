using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Tiled.Common
{
	/// <summary>
	/// 瓷砖坐标系统的统一接口
	/// </summary>
	public interface ITiledCoordinate
	{

		/// <summary>
		/// 根据斜角坐标计算显示坐标
		/// </summary>
		/// <param name="displayPoint"></param>
		/// <returns></returns>
		Point IsoToDisplay(int x, int y);

		/// <summary>
		/// 根据显示坐标计算斜角坐标
		/// </summary>
		/// <param name="isoPoint"></param>
		/// <returns></returns>
		Point DisplayToIso(int x, int y);



		/// <summary>
		/// 根据瓷砖坐标计算显示坐标
		/// </summary>
		/// <param name="displayPoint"></param>
		/// <returns></returns>
		Point TileToDisplay(int x, int y);

		/// <summary>
		/// 根据显示坐标计算瓷砖坐标
		/// </summary>
		Point DisplayToTile(int x, int y);



		/// <summary>
		/// 计算指定行数和列数的总尺寸
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <returns></returns>
		Size GetTotalSize(int rows, int columns);


		/// <summary>
		/// 获取指定行数和列数的网格信息
		/// </summary>
		/// <param name="rows"></param>
		/// <param name="columns"></param>
		/// <returns></returns>
		TileCoordinateGrid GetGrid(int rows, int columns);

		/// <summary>
		/// 获取瓷砖大小
		/// </summary>
		Size TileSize { get; set; }
	}

	/// <summary>
	/// 斜角网格信息
	/// </summary>
	public class TileCoordinateGrid
	{
		/// <summary>
		/// 构造
		/// </summary>
		public TileCoordinateGrid()
		{
			RowLines = new List<TileCoordinatedGridLine>();
			ColumnLines = new List<TileCoordinatedGridLine>();
		}

		/// <summary>
		/// 行网格线
		/// </summary>
		public List<TileCoordinatedGridLine> RowLines { get; set; }
		
		/// <summary>
		/// 列网格线
		/// </summary>
		public List<TileCoordinatedGridLine> ColumnLines { get; set; }
	}

	/// <summary>
	/// 网格线信息
	/// </summary>
	public class TileCoordinatedGridLine
	{
		/// <summary>
		/// 构造
		/// </summary>
		public TileCoordinatedGridLine()
		{
			Index = 0;
			X1 = 0;
			Y1 = 0;
			X2 = 0;
			Y2 = 0;
		}

		public override string ToString()
		{
			return String.Format("[{0}]({1},{2}) ~ ({3},{4})", Index, X1, Y1, X2, Y2);
		}

		/// <summary>
		/// 索引
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// 起点横坐标
		/// </summary>
		public int X1 { get; set; }
		
		/// <summary>
		/// 起点纵坐标
		/// </summary>
		public int Y1 { get; set; }

		/// <summary>
		/// 终点横坐标
		/// </summary>
		public int X2 { get; set; }

		/// <summary>
		/// 终点纵坐标
		/// </summary>
		public int Y2 { get; set; }

	}
}
