using Solar.Components.D2DRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Components.Drags
{
	/// <summary>
	/// 拖动方法接口
	/// </summary>
	public interface IDragMethod
	{
		void OnDragBegin(AnimationViewContext context, int x, int y);
		void OnDragMove(AnimationViewContext context, int x, int y);
		void OnDragEnd(AnimationViewContext context, int x, int y);
	}
}
