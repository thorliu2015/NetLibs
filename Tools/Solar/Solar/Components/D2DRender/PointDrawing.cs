using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Components.D2DRender
{
	public class PointDrawing
	{
		static public void DrawZeroPoint(AnimationViewContext context)
		{
			int size = 5;

			context.Render.DrawLine(
				new SharpDX.Vector2(context.Position.X - size, context.Position.Y),
				new SharpDX.Vector2(context.Position.X + size, context.Position.Y),
				context.Controller.GetSolidColorBrush(context.ViewStyle.Anchor));

			context.Render.DrawLine(
				new SharpDX.Vector2(context.Position.X, context.Position.Y - size),
				new SharpDX.Vector2(context.Position.X, context.Position.Y + size),
				context.Controller.GetSolidColorBrush(context.ViewStyle.Anchor));
		}

		
	}
}
