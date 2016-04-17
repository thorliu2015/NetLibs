/*
 * CTerrainTileFlags
 * liuqiang@2015/12/12 22:23:34
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
	/*
	 *	LEFT			TOP
	 *	BOTTOM			RIGHT
	 *	----------------------
	 *			TOP
	 *	LEFT			RIGHT
	 *		  BOTTOM
	 */

	/// <summary>
	/// 地形标记
	/// </summary>
	public enum CTerrainTileFlags
	{
		None = 0,
		Left = 1,
		Top = 2,
		Right = 4,
		Bottom = 8
	}
}
