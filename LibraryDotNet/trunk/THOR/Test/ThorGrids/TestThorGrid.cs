/*
 * TestThorGrid
 * liuqiang@2015/11/19 15:12:32
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common;
using Test.Components;
using THOR.Windows.Components.ThorGrids.Core;


//---- 8< ------------------

namespace Test.ThorGrids
{
	public class TestThorGrid : AbstractComponentTest
	{
		protected override System.Windows.Forms.Control CreateControl()
		{
			//ThorAbstractGrid ctrl = new ThorAbstractGrid();

			ThorGrid ctrl = new ThorGrid();


			ctrl.DataTable = TestFileSystemData.GetDataTableFromFileSystem();
			return ctrl;
		}
	}
}
