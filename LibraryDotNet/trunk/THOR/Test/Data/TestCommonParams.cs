/*
 * TestCommonParams
 * liuqiang@2016/1/22 14:35:09
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Windows.Editors.UI.Frameworks.Core.Params;


//---- 8< ------------------

namespace Test.Data
{
	public class TestCommonParams : ITest
	{
		public void Run(FormMain MainForm)
		{
			Rectangle rect = new Rectangle();
			//System.Windows.Forms.scrollbar
		}

		public string GetName()
		{
			return GetType().Name;
		}
	}
}
