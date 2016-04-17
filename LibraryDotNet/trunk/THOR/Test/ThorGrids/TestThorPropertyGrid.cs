/*
 * TestThorPropertyGrid
 * liuqiang@2015/11/23 18:15:46
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Components;
using THOR.Attributes.Notes;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.ThorPropertyGrid;


//---- 8< ------------------

namespace Test.ThorGrids
{
	public class TestThorPropertyGrid : AbstractComponentTest
	{
		protected override System.Windows.Forms.Control CreateControl()
		{
			ThorPropertyGrid grid = new ThorPropertyGrid();

			//TestEntity entity = new TestEntity();
			//grid.SelectedObject = entity;

			grid.SelectedObject = grid;

			return grid;
		}
	}

	public class TestEntity
	{
		public const int CATEGORY_SORT_BASE = 0;
		public const int CATEGORY_SORT_MOVE = 1;
		public const int CATEGORY_SORT_FIGHT = 2;

		public TestEntity()
		{
		}

		//[Note("ID", "标识", "基础", 0, CATEGORY_SORT_BASE)]
		public string Id { get; set; }

		//[Note("能力", "能力", "战斗", 1, CATEGORY_SORT_FIGHT)]
		public string Ability { get; set; }

		//[Note("名称", "名称", "基础", 1, CATEGORY_SORT_BASE)]
		public string Name { get; set; }

		//[Note("速度", "速度", "行为", 1,CATEGORY_SORT_MOVE)]
		public int Speed { get; set; }

		//[Note("武器", "武器", "战斗", 0, CATEGORY_SORT_FIGHT)]
		public string Weapon { get; set; }

		//[Note("视野", "视野", "行为", 0, CATEGORY_SORT_MOVE)]
		public int Sight { get; set; }
	}
}
