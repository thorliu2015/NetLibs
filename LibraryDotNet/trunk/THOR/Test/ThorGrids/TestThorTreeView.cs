/*
 * TestThorTreeView
 * liuqiang@2015/11/14 16:01:50
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common;
using Test.Components;
using THOR.Windows.Components.ThorGrids.Core;
using THOR.Windows.Components.ThorGrids.Models;
using THOR.Windows.Components.ThorGrids.ThorTree;


//---- 8< ------------------

namespace Test.ThorGrids
{
	public class TestThorTreeView : AbstractComponentTest
	{
		protected ThorTreeView tree;
		protected ThorDataTable table;
		protected override System.Windows.Forms.Control CreateControl()
		{
			//ThorAbstractGrid ctrl = new ThorAbstractGrid();

			ThorTreeView ctrl = new ThorTreeView();
			tree = ctrl;

			table =
			ctrl.DataTable = TestFileSystemData.GetDataTableFromFileSystem();
			return ctrl;
		}

		
	}
}
