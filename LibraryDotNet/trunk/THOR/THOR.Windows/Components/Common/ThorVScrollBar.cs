/*
 * ThorVScrollBar
 * liuqiang@2015/11/1 22:40:47
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
	public class ThorVScrollBar : ThorScrollBar
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
			isHorizontablDirection = false;
			Width = defaultSize;
			Height = 100;
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
