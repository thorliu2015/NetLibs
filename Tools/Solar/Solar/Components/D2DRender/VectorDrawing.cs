using SharpDX;
using Solar.Animations;
using Solar.Animations.Biz;
using Solar.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.UI.Utils;

namespace Solar.Components.D2DRender
{
	/// <summary>
	/// 向量绘制
	/// </summary>
	public class VectorDrawing
	{
		/// <summary>
		/// 绘制枪口
		/// </summary>
		/// <param name="context"></param>
		static public void DrawShootPosition(AnimationViewContext context, SAnimationDirection direction)
		{

			foreach (SAnimationPoint p in direction.ShootPosition)
			{
				int x = Convert.ToInt32(p.X);
				int y = Convert.ToInt32(p.Y);
				DrawShootPositionMethod(context, x, y, context.AttackAngle, p == DialogShootPosition.Instance.CurrentPoint);
			}
		}

		static private void DrawShootPositionMethod(AnimationViewContext context, int x, int y, float angle, bool selected = true)
		{
			Vector2 p = new Vector2(context.Position.X, context.Position.Y);

			p.X += x * context.Scale.X;
			p.Y += y * context.Scale.Y;

			int r = 5;

			DoublePoint p2 =
			MathUtility.GetPosition(new DoublePoint(p.X, p.Y), angle, Math.Max(context.AnimationView.Width, context.AnimationView.Height) * 2);

			System.Drawing.Color c1 = System.Drawing.Color.FromArgb(selected ? 0xFF : 0x80, context.ViewStyle.Weapon);
			System.Drawing.Color c2 = System.Drawing.Color.FromArgb(selected ? 0x80 : 0x40, context.ViewStyle.Weapon);

			context.Render.DrawEllipse(
				new SharpDX.Direct2D1.Ellipse(p, 5, 5), context.Controller.GetSolidColorBrush(c1));

			context.Render.DrawLine(p,
				new Vector2(
				Convert.ToSingle(p2.X),
				Convert.ToSingle(p2.Y)),
				context.Controller.GetSolidColorBrush(c2));
		}
	}
}
