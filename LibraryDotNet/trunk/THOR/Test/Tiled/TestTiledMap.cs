/*
 * TestTiledMap
 * liuqiang@2015/12/3 11:47:57
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Components;
using THOR.Tiled.Terrain;


//---- 8< ------------------

namespace Test.Tiled
{
	public class TestTiledMap : AbstractComponentTest
	{
		protected override System.Windows.Forms.Control CreateControl()
		{

			TerrainLayer layer = new TerrainLayer(10, 10);

			layer.SetTerrain(5, 4);
			string s1 = layer.TraceCells;

			layer.SetTerrain(7, 6);
			string s2 = layer.TraceCells;

			layer.SetTerrain(5, 5);
			string s3 = layer.TraceCells;

			layer.SetTerrain(6, 5, true);
			string s4 = layer.TraceCells;
			
			return new TestTiledMapControl();
		}
	}
}
