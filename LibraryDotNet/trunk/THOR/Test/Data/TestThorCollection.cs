/*
 * TestThorCollection
 * liuqiang@2015/11/4 10:24:26
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Common;
using THOR.Windows.Components.ThorGrids.Models;

//---- 8< ------------------

namespace Test.Data
{
	public class TestThorCollection : ITest
	{

		public void Run(FormMain MainForm)
		{
			ThorCollection<object> collection = new ThorCollection<object>();

			collection.Add(1);
			collection.Add(2);
			collection.Add(3);

			collection.Remove(2);
			collection.Insert(1, 100);

			bool c = collection.Contains(1);

			collection[1] = 200;

			object a = collection[100];

			collection.Clear();

			//...
			ThorCollection<ThorDataTableCell> cells = new ThorCollection<ThorDataTableCell>();
			ThorDataTableCell c1 = new ThorDataTableCell();
			ThorDataTableCell c2 = new ThorDataTableCell();
			ThorDataTableCell c3 = new ThorDataTableCell();
			cells.Add(c1);


		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
