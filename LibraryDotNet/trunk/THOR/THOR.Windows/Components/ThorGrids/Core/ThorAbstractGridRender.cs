/*
 * ThorGridRender
 * liuqiang@2015/11/14 17:19:53
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.ThorGrids.Core
{
	public class ThorAbstractGridRender
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorAbstractGridRender()
		{
		}

		#endregion

		#region methods

		/// <summary>
		/// 绘制网格背景
		/// </summary>
		public virtual void DrawGridBackground(ThorGridRenderArgs e)
		{
			//e.Graphics.Clear(Color.Red);
		}

		/// <summary>
		/// 绘制网格行背景
		/// </summary>
		public virtual void DrawRowBackground(ThorGridRowRenderArgs e)
		{
			e.Graphics.DrawRectangle(ThorPens.Control, e.Bounds);
		}

		/// <summary>
		/// 绘制网格列背景
		/// </summary>
		public virtual void DrawRowForeground(ThorGridRowRenderArgs e)
		{
		
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
