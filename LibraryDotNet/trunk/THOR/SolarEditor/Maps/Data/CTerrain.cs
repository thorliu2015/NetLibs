/*
 * CTerrain
 * liuqiang@2015/12/12 0:56:15
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Editors.Common.Data;


/*
 *		默认地形 (4x4)
 *			- 相关地形 (4x4)
 *			- 相关地形 (4x4)
 *				- 相关地形 (4x4)
 */

//---- 8< ------------------

namespace SolarEditor.Maps.Data
{
	[Serializable()]

	/// <summary>
	/// 地形配置
	/// </summary>
	public class CTerrain : CEntity
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public CTerrain()
			: base()
		{
			IdPrefix = "terrain";

			DefaultTilles = new List<CTerrainTile>();
			TileSets = new List<CTerrainTileSet>();
		}

		#endregion

		#region methods

		#endregion

		#region properties

		/// <summary>
		/// 默认瓷砖
		/// </summary>
		public List<CTerrainTile> DefaultTilles { get; set; }

		/// <summary>
		/// 相关地形
		/// </summary>
		public List<CTerrainTileSet> TileSets { get; set; }

		#endregion

		#region events

		#endregion
	}
}
