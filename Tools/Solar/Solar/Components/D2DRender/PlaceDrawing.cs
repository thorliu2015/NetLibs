using Solar.Coordinates;
using Solar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Components.D2DRender
{
	public class PlaceDrawing
	{
		/// <summary>
		/// 绘制圆形
		/// </summary>
		/// <param name="context"></param>
		static public void DrawPlace(AnimationViewContext context)
		{
			//DrawGrid(context, 10);
			//return;

			if (context.AnimationView.CurrentAnimationState == null) return;

			switch (context.AnimationView.CurrentAnimationState.PlaceType)
			{
				case Animations.SAnimationStatePlaceType.Grid:
					DrawGrid(context, context.AnimationView.CurrentAnimationState.PlaceSize);
					break;

				case Animations.SAnimationStatePlaceType.Circle:
					DrawCircle(context, context.AnimationView.CurrentAnimationState.PlaceSize);

					break;

			}
		}

		/// <summary>
		/// 绘制网格
		/// </summary>
		/// <param name="context"></param>
		/// <param name="size"></param>
		static public void DrawGrid(AnimationViewContext context, int size)
		{
			if (size <= 0) return;

			DiamonCoordinate coordinate = new DiamonCoordinate(40, 30);

			float scaleX = context.Scale.X;
			float scaleY = context.Scale.Y;

			float offsetX = context.Position.X;
			float offsetY = context.Position.Y - (coordinate.GridSize.Height * size / 2 * scaleY);


			List<int> x1s = new List<int>();
			List<int> x2s = new List<int>();
			List<int> x3s = new List<int>();
			List<int> x4s = new List<int>();

			List<int> y1s = new List<int>();
			List<int> y2s = new List<int>();
			List<int> y3s = new List<int>();
			List<int> y4s = new List<int>();

			coordinate.GetGridPoints(size, size, x1s, x2s, x3s, x4s, y1s, y2s, y3s, y4s);

			SharpDX.Vector2 p1 = new SharpDX.Vector2();
			SharpDX.Vector2 p2 = new SharpDX.Vector2();
			SharpDX.Direct2D1.Brush brushBorder = context.Controller.GetSolidColorBrush(context.ViewStyle.Grid);
			SharpDX.Direct2D1.Brush brushLine = context.Controller.GetSolidColorBrush(context.ViewStyle.Grid);

			bool isBorder = true;

			for (int i = 0; i <= size; i++)
			{
				isBorder = (i == 0) || (i == size);

				p1.X = x1s[i] * scaleX + offsetX;
				p1.Y = y1s[i] * scaleY + offsetY;

				p2.X = x2s[i] * scaleX + offsetX;
				p2.Y = y2s[i] * scaleY + offsetY;

				context.Render.DrawLine(p1, p2, isBorder ? brushBorder : brushLine);


				p1.X = x3s[i] * scaleX + offsetX;
				p1.Y = y3s[i] * scaleY + offsetY;

				p2.X = x4s[i] * scaleX + offsetX;
				p2.Y = y4s[i] * scaleY + offsetY;

				context.Render.DrawLine(p1, p2, isBorder ? brushBorder : brushLine);
			}
		}

		static public void DrawCircle(AnimationViewContext context, int size)
		{
			if (size <= 0) return;

			size = Convert.ToInt32(size * context.Scale.X);

			float w = SModelManager.Current.TileSize.Width;
			float h = SModelManager.Current.TileSize.Height;

			float r = h / w;

			w = size;
			h = w * r;

			context.Render.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(context.Position.X, context.Position.Y), w, h), context.Controller.GetSolidColorBrush(context.ViewStyle.Grid));

		}
	}
}
