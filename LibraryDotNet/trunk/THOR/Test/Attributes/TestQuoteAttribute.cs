/*
 * TestQuoteAttribute
 * liuqiang@2015/11/1 17:12:03
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Core;


//---- 8< ------------------

namespace Test.Attributes
{
	public class TestQuoteAttribute : ITest
	{
		public void Run(FormMain MainForm)
		{
		}

		public string GetName()
		{
			return this.GetType().Name;
		}
	}
}
