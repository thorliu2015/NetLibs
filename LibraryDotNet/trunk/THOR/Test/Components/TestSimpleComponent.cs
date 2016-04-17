/*
 * TestSimpleComponent
 * liuqiang@2015/11/18 21:25:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace Test.Components
{
	public class TestSimpleComponent : AbstractComponentTest
	{
		protected Control control;

		public TestSimpleComponent(Control ctrl)
			: base()
		{
			control = ctrl;
		}

		protected override Control CreateControl()
		{
			noDock = true;
			return control;
		}

		public override string GetName()
		{
			return String.Format("Test: {0}", control.GetType().Name);
		}
	}
}
