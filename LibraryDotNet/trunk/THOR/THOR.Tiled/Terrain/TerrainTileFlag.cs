/*
 * TerrainTiles
 * liuqiang@2015/12/3 15:29:33
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------


/*
 *		   TOP
 *			
 *	LEFT		RIGHT
 *	
 *		  BOTTOM
 *		  
 * 
 * 
 *		XX							XX							XX							XX
 *		XX							X.							.X							..
 *		TOP|RIGHT|BOTTOM|LEFT		TOP|RIGHT|LEFT				TOP|RIGHT|BOTTOM			TOP|RIGHT
 *		
 *		X.							X.							X.							X.
 *		XX							X.							.X							..
 *		TOP|BOTTOM|LEFT				TOP|LEFT					TOP|BOTTOM					TOP
 * 
 *		.X							.X							.X							.X
 *		XX							X.							.X							..
 *		RIGHT|BOTTOM|LEFT			RIGHT|LEFT					RIGHT|BOTTOM				RIGHT
 * 
 *		..							..							..							..
 *		XX							X.							.X							..
 *		BOTTOM|LEFT					LEFT						BOTTOM						NULL
 *		
 */

namespace THOR.Tiled.Terrain
{
	/// <summary>
	/// 地形瓷砖标记
	/// </summary>
	public enum TerrainTileFlag
	{
		NULL = 0,
		LEFT = 1,
		TOP = 2,
		RIGHT = 4,
		BOTTOM = 8
	}
}
