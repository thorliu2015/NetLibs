/*
 * CTerrainDataTableBuilder
 * liuqiang@2015/12/13 17:47:43
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Images.Core;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Editors.Common;
using THOR.Windows.Utils;


//---- 8< ------------------

namespace SolarEditor.Maps.Data
{
	public class CTerrainController
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		#region common


		static public CTerrainTileFlags GetTileFlags(int index)
		{
			switch (index)
			{
				case 1:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom;

				case 2:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Bottom;

				case 3:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right;

				case 4:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Top;

				//----

				case 5:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom;

				case 6:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Bottom;

				case 7:
					return CTerrainTileFlags.Left | CTerrainTileFlags.Right;

				case 8:
					return CTerrainTileFlags.Left;

				//----

				case 9:
					return CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom;

				case 10:
					return CTerrainTileFlags.Top | CTerrainTileFlags.Bottom;

				case 11:
					return CTerrainTileFlags.Top | CTerrainTileFlags.Right;

				case 12:
					return CTerrainTileFlags.Top;

				//----

				case 13:
					return CTerrainTileFlags.Right | CTerrainTileFlags.Bottom;

				case 14:
					return CTerrainTileFlags.Bottom;

				case 15:
					return CTerrainTileFlags.Right;

				default:
					return CTerrainTileFlags.None;
			}
		}

		static public int GetTileFlagsIndex(CTerrainTileFlags flags)
		{
			switch (flags)
			{
				case CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom:
					return 1;

				case CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Bottom:
					return 2;

				case CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right:
					return 3;

				case CTerrainTileFlags.Left | CTerrainTileFlags.Top:
					return 4;

				//----

				case CTerrainTileFlags.Left | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom:
					return 5;

				case CTerrainTileFlags.Left | CTerrainTileFlags.Bottom:
					return 6;

				case CTerrainTileFlags.Left | CTerrainTileFlags.Right:
					return 7;

				case CTerrainTileFlags.Left:
					return 8;

				//----

				case CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom:
					return 9;

				case CTerrainTileFlags.Top | CTerrainTileFlags.Bottom:
					return 10;

				case CTerrainTileFlags.Top | CTerrainTileFlags.Right:
					return 11;

				case CTerrainTileFlags.Top:
					return 12;

				//----

				case CTerrainTileFlags.Right | CTerrainTileFlags.Bottom:
					return 13;

				case CTerrainTileFlags.Bottom:
					return 14;

				case CTerrainTileFlags.Right:
					return 15;

				default:
					return 16;
			}
		}


		static Dictionary<string, Image> ImageCache = new Dictionary<string, Image>();

		static public Image GetStyleImage(int index, bool tile = false)
		{
			string dirPath = ApplicationUtils.CombinePath(@"Resources\TerrainStyles");
			string filePath = tile ? "s{0}.png" : "t{0}.png";

			filePath = Path.Combine(dirPath, String.Format(filePath, index));

			if (ImageCache.ContainsKey(filePath))
			{
				return ImageCache[filePath];
			}

			Image img = ImageFileUtils.LoadImage(filePath);

			if (img != null)
			{
				ImageCache[filePath] = img;
			}

			return img;
		} 
		#endregion


		/*
		 *	[LIST] DEFAULT
		 *		[SET] Set
		 *			[LIST] Style
		 * 
		 */

		/// <summary>
		/// 获取表格
		/// </summary>
		/// <param name="terrain"></param>
		/// <returns></returns>
		static public ThorDataTable GetDataTable(CTerrain terrain)
		{
			if (terrain == null) return null;

			//----

			ThorDataTable table = new ThorDataTable();
			table.Columns.Add(new ThorDataTableColumn());

			//----

			ThorDataTableRow rowRoot = new ThorDataTableRow();
			rowRoot.OpenedIcon = rowRoot.ClosedIcon = GetStyleImage(1);
			rowRoot.TagData = terrain.DefaultTilles;
			rowRoot.Cells.Add(new ThorDataTableCell() { Text = "ROOT" });
			table.Rows.Add(rowRoot);

			//----

			if (terrain.TileSets.Count == 0)
			{
				for (int i = 0; i < 3; i++)
				{
					CTerrainTileSet tileSet = new CTerrainTileSet();

					terrain.TileSets.Add(tileSet);

					for (int j = 0; j < 3; j++)
					{
						tileSet.ChildTerrainSets.Add(new CTerrainTileSet());
					}
				}
			}

			foreach (CTerrainTileSet tileSet in terrain.TileSets)
			{
				//主节点
				ThorDataTableRow rowTileSet = GetTileSetRow(tileSet);
				rowRoot.Rows.Add(rowTileSet);

				

				
			}

			return table;
		}

		/// <summary>
		/// 获取地形集的数据行
		/// </summary>
		/// <param name="tileSet"></param>
		/// <returns></returns>
		static public ThorDataTableRow GetTileSetRow(CTerrainTileSet tileSet)
		{
			if (tileSet != null)
			{
				//主节点
				ThorDataTableRow rowTileSet = new ThorDataTableRow();
				rowTileSet.OpenedIcon = rowTileSet.ClosedIcon = GetStyleImage(0);
				rowTileSet.Cells.Add(new ThorDataTableCell() { Text = "TileSet" });

				//样式
				ThorDataTableRow rowStyles = new ThorDataTableRow();
				rowStyles.OpenedIcon = ThorEditorTypeIcons.GetCategoryIcon(true);
				rowStyles.ClosedIcon = ThorEditorTypeIcons.GetCategoryIcon(false);
				rowStyles.Cells.Add(new ThorDataTableCell() { Text = "Styles" });
				rowTileSet.Rows.Add(rowStyles);

				for (int i = 1; i < 16; i++)
				{
					ThorDataTableRow rowStyle = new ThorDataTableRow();
					rowStyle.OpenedIcon = rowStyle.ClosedIcon = GetStyleImage(i);
					rowStyle.Cells.Add(new ThorDataTableCell() { Text = String.Format("Style {0}", i) });
					rowStyles.Rows.Add(rowStyle);
				}

				//子节点
				ThorDataTableRow rowChildren = new ThorDataTableRow();
				rowChildren.OpenedIcon = ThorEditorTypeIcons.GetCategoryIcon(true);
				rowChildren.ClosedIcon = ThorEditorTypeIcons.GetCategoryIcon(false);
				rowChildren.Cells.Add(new ThorDataTableCell() { Text = "Children" });
				rowTileSet.Rows.Add(rowChildren);

				foreach (CTerrainTileSet childTileSet in tileSet.ChildTerrainSets)
				{
					ThorDataTableRow rowChildrenTileSet = GetTileSetRow(childTileSet);
					rowChildren.Rows.Add(rowChildrenTileSet);
				}

				return rowTileSet;
			}
			return null;
		}


		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
