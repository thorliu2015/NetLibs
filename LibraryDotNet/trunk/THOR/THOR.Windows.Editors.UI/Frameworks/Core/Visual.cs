/*
 * Visual
 * liuqiang@2016/1/22 13:42:28
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Editors.UI.Frameworks.Core
{
	public class Visual : DependencyObject
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public Visual()
		{
		}

		#endregion

		#region methods

		public virtual System.Drawing.Size Measure(System.Drawing.Size availableSize)
		{
			return new System.Drawing.Size(0, 0);
		}

		public virtual void Arrange(System.Drawing.Rectangle finalRect)
		{
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
