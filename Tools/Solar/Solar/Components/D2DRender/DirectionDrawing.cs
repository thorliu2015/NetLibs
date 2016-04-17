using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.UI.Utils;

namespace Solar.Components.D2DRender
{
	public class DirectionDrawing
	{
		public const int CIRCLE_RADIUS = 20;
		public const int CIRCLE_SPACING = 10;

		static public void DrawDirections(AnimationViewContext context)
		{
			int x = CIRCLE_SPACING + CIRCLE_RADIUS;
			int y = CIRCLE_SPACING + CIRCLE_RADIUS;

			DrawDirection(context, "移动", x, y, context.MoveAngle);

			x += CIRCLE_SPACING + CIRCLE_RADIUS * 2;

			DrawDirection(context, "攻击", x, y, context.AttackAngle);
		}

		static private void DrawDirection(AnimationViewContext context, string title, int x, int y, float angle)
		{

			Ellipse ellipse = new Ellipse(new SharpDX.Vector2(x, y), CIRCLE_RADIUS, CIRCLE_RADIUS);
			context.Render.DrawEllipse(ellipse, context.Controller.GetSolidColorBrush(context.ViewStyle.Grid));

			DoublePoint d = MathUtility.GetPosition(new DoublePoint(x, y), angle, CIRCLE_RADIUS);


			context.Render.DrawLine(
				new SharpDX.Vector2(x, y),
				new SharpDX.Vector2(Convert.ToSingle(d.X), Convert.ToSingle(d.Y)), context.Controller.GetSolidColorBrush(context.ViewStyle.Grid));

			RectangleF rect = new RectangleF();
			rect.Y = CIRCLE_RADIUS * 2 + CIRCLE_SPACING * 1;
			rect.Height = 20;
			rect.Width = CIRCLE_RADIUS * 2;
			rect.X = x - CIRCLE_RADIUS;

			SharpDX.DirectWrite.Factory factory = new SharpDX.DirectWrite.Factory();
			SharpDX.DirectWrite.TextFormat textFormat = new SharpDX.DirectWrite.TextFormat(factory, "Arial", 12);
			textFormat.TextAlignment = SharpDX.DirectWrite.TextAlignment.Center;

			context.Render.DrawText(title, textFormat, rect, context.Controller.GetSolidColorBrush(context.ViewStyle.Grid));


		}
	}
}

