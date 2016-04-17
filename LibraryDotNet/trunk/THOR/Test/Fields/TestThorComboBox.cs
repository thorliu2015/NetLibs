/*
 * TestThorFields
 * liuqiang@2015/11/16 21:06:11
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Components;
using THOR.Windows.Components.Fields;


//---- 8< ------------------

namespace Test.Fields
{
	public class TestThorComboBox : AbstractComponentTest
	{
		protected override System.Windows.Forms.Control CreateControl()
		{
			noDock = true;

			//ThorAbstractField field = new ThorAbstractField();
			//ThorTextField field = new ThorTextField();
			//ThorAbstractDomainField field = new ThorAbstractDomainField();
			//ThorNumbericField field = new ThorNumbericField();
			//field.Min = 0;
			//field.Max = 9999;

			ThorAbstractPopupField field = new ThorAbstractPopupField();

			return field;
		}

	
	}
}
