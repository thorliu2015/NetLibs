/*
 * ThorHScrollBar
 * liuqiang@2015/11/1 22:40:36
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorHScrollBar : ThorScrollBar
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		protected override void InitDefaultSize()
		{
			isHorizontablDirection = true;
			Width = 100;
			Height = defaultSize;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
