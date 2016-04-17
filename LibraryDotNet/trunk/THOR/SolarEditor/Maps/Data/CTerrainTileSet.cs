/*
 * CTerrainTileSet
 * liuqiang@2015/12/13 12:39:58
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace SolarEditor.Maps.Data
{
	[Serializable()]

	/// <summary>
	/// 地形集
	/// </summary>
	public class CTerrainTileSet
	{
		#region constants

		#endregion

		#region variables

		

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public CTerrainTileSet()
			: base()
		{
			InitTiles();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化瓦片集
		/// </summary>
		protected virtual void InitTiles()
		{
			Tiles = new Dictionary<CTerrainTileFlags, List<CTerrainTile>>();

			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Top | CTerrainTileFlags.Right] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Top] = new List<CTerrainTile>();

			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left | CTerrainTileFlags.Right] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Left] = new List<CTerrainTile>();

			Tiles[CTerrainTileFlags.Top | CTerrainTileFlags.Right | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Top | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Top | CTerrainTileFlags.Right] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Top] = new List<CTerrainTile>();

			Tiles[CTerrainTileFlags.Right | CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Bottom] = new List<CTerrainTile>();
			Tiles[CTerrainTileFlags.Right] = new List<CTerrainTile>();

			ChildTerrainSets = new List<CTerrainTileSet>();
		}

		#endregion

		#region properties

		/// <summary>
		/// 地形索引
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// 父级地形集
		/// </summary>
		public CTerrainTileSet ParentTerrainSet { get; set; }

		/// <summary>
		/// 相关的地形集
		/// </summary>
		public List<CTerrainTileSet> ChildTerrainSets { get; set; }

		/// <summary>
		/// 地形瓷砖设定
		/// </summary>
		public Dictionary<CTerrainTileFlags, List<CTerrainTile>> Tiles { get; set; }

		#endregion

		#region events

		#endregion
	}
}
