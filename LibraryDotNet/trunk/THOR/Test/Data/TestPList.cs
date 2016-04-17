/*
 * TestPList
 * liuqiang@2016/1/22 8:13:37
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;
using THOR.Serialization.PList;


//---- 8< ------------------

namespace Test.Data
{
	public class TestPList : ITest
	{

		public void Run(FormMain MainForm)
		{
			string filename = @"Z:\Documents\temp\1.plist";
			PList plist = new PList();
			plist.Load(filename);
			plist.Save(@"Z:\Documents\temp\2.plist");
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
