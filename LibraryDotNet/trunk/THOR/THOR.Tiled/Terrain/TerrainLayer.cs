/*
 * TerrainLayer
 * liuqiang@2015/12/3 16:55:11
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Tiled.Terrain
{
	/// <summary>
	/// 地形层
	/// </summary>
	public class TerrainLayer
	{
		#region constants


		protected const int FLAG_LEFT = 1;
		protected const int FLAG_TOP = 2;
		protected const int FLAG_RIGHT = 4;
		protected const int FLAG_BOTTOM = 8;

		#endregion

		#region variables

		protected bool[,] FillCells;
		protected int[,] Cells;
		protected int _Rows;
		protected int _Columns;

		#endregion

		#region construct

		public TerrainLayer(int rows, int columns)
		{
			_Rows = rows;
			_Columns = columns;
			Cells = new int[rows, columns];
			FillCells = new bool[rows, columns];
		}

		#endregion

		#region methods

		/// <summary>
		/// 设置地形格
		/// </summary>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		/// <param name="eraseMode">是否擦除模式</param>
		public virtual void SetTerrain(int x, int y, bool eraseMode = false)
		{
			if (x >= 0 && x < _Columns && y >= 0 && y < _Rows)
			{
				if (eraseMode)
				{
					SetTerrainFillCellMethod(x, y, false);

					//---- 清除之前的地形(1+8)
					SetTerrainCellMethod(x - 1, y - 1, 0);
					SetTerrainCellMethod(x - 1, y, 0);
					SetTerrainCellMethod(x - 1, y + 1, 0);

					SetTerrainCellMethod(x, y - 1, 0);
					SetTerrainCellMethod(x, y, 0);
					SetTerrainCellMethod(x, y + 1, 0);

					SetTerrainCellMethod(x + 1, y - 1, 0);
					SetTerrainCellMethod(x + 1, y, 0);
					SetTerrainCellMethod(x + 1, y + 1, 0);

					//---- 重置当前的地形(1+8)

					int dist = 3;

					for (int ox = x - dist; ox <= x + dist; ox++)
					{
						for (int oy = y - dist; oy <= y + dist; oy++)
						{
							FillOutlineCell(ox, oy);
						}
					}

				}
				else
				{
					Cells[y, x] = (FLAG_LEFT | FLAG_TOP | FLAG_RIGHT | FLAG_BOTTOM);
					FillCells[y, x] = true;

					FillOutlineCell(x, y);
				}
			}
		}

		/// <summary>
		/// 设置地形格标记值
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="flags"></param>
		protected virtual void SetTerrainCellMethod(int x, int y, int flags)
		{
			if (x < 0) return;
			if (y < 0) return;
			if (x > _Columns - 1) return;
			if (y > _Rows - 1) return;

			Cells[y, x] = flags;
		}

		/// <summary>
		/// 设置地形填充格标记值
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="fill"></param>
		protected virtual void SetTerrainFillCellMethod(int x, int y, bool fill)
		{
			if (x < 0) return;
			if (y < 0) return;
			if (x > _Columns - 1) return;
			if (y > _Rows - 1) return;

			FillCells[y, x] = fill;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="flags"></param>
		/// <param name="eraseMode"></param>
		protected virtual void SetTerrainCell(int x, int y, int flags, bool eraseMode = false)
		{
			if (x < 0) return;
			if (y < 0) return;
			if (x > _Columns - 1) return;
			if (y > _Rows - 1) return;

			if (eraseMode)
			{
				int c = Cells[y, x];
				c &= flags;
				Cells[y, x] = Cells[y, x] - c;
			}
			else
			{
				Cells[y, x] = Cells[y, x] | flags;
			}
		}

		/// <summary>
		/// 填充所有的地形格
		/// </summary>
		public void FillOutlineCells()
		{
			for (int r = 0; r < _Rows; r++)
			{
				for (int c = 0; c < _Columns; c++)
				{
					if (FillCells[r, c])
					{
						Cells[r, c] = (FLAG_LEFT | FLAG_TOP | FLAG_RIGHT | FLAG_BOTTOM);
					}
					else
					{
						Cells[r, c] = 0;
					}
				}
			}

			for (int r = 0; r < _Rows; r++)
			{
				for (int c = 0; c < _Columns; c++)
				{
					FillOutlineCell(c, r);
				}
			}
		}


		/// <summary>
		/// 填充指定的地形格
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void FillOutlineCell(int x, int y)
		{
			bool v = FillCells[y, x];

			if (v)
			{
				Cells[y, x] = (v ? (FLAG_LEFT | FLAG_TOP | FLAG_RIGHT | FLAG_BOTTOM) : 0);

				SetTerrainCell(x - 1, y - 1, FLAG_BOTTOM);
				SetTerrainCell(x - 1, y, FLAG_RIGHT | FLAG_BOTTOM);
				SetTerrainCell(x - 1, y + 1, FLAG_RIGHT);

				SetTerrainCell(x, y - 1, FLAG_LEFT | FLAG_BOTTOM);
				SetTerrainCell(x, y + 1, FLAG_TOP | FLAG_RIGHT);

				SetTerrainCell(x + 1, y - 1, FLAG_LEFT);
				SetTerrainCell(x + 1, y, FLAG_LEFT | FLAG_TOP);
				SetTerrainCell(x + 1, y + 1, FLAG_TOP);
			}
		}

		public string TraceFillCells
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				for (int r = 0; r < _Rows; r++)
				{
					for (int c = 0; c < _Columns; c++)
					{
						bool v = FillCells[r, c];
						sb.Append(v ? "X" : ".");
					}
					sb.Append("\r\n");
				}

				return sb.ToString();
			}

		}


		/// <summary>
		/// 获取文本信息
		/// </summary>
		/// <returns></returns>
		public string TraceCells
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				//FillOutlineCells();

				for (int r = 0; r < _Rows; r++)
				{
					for (int c = 0; c < _Columns; c++)
					{
						int v = Cells[r, c];

						bool top = ((v & FLAG_TOP) > 0);
						bool right = ((v & FLAG_RIGHT) > 0);

						sb.Append(top ? "X" : ".");
						sb.Append(right ? "X" : ".");
					}

					sb.Append("\r\n");


					for (int c = 0; c < _Columns; c++)
					{
						int v = Cells[r, c];

						bool left = ((v & FLAG_LEFT) > 0);
						bool bottom = ((v & FLAG_BOTTOM) > 0);

						sb.Append(left ? "X" : ".");
						sb.Append(bottom ? "X" : ".");

					}

					sb.Append("\r\n");
				}

				return sb.ToString();
			}
		}

		#endregion

		#region properties

		public int Rows
		{
			get
			{
				return _Rows;
			}
		}

		public int Columns
		{
			get
			{
				return _Columns;
			}
		}



		#endregion

		#region events

		#endregion
	}
}
