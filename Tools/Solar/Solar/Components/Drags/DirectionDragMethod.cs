using Solar.Animations;
using Solar.Components.D2DRender;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.UI.Utils;

namespace Solar.Components.Drags
{
	

	public class DirectionDragMethod : IDragMethod
	{
		protected AnimationDirectionType directionType;
		protected int centerX;
		protected int centerY;

		protected bool isCurrent = false;

		public DirectionDragMethod(AnimationDirectionType type, int x, int y)
		{
			directionType = type;
			centerX = x;
			centerY = y;

			
		}

		public void OnDragBegin(D2DRender.AnimationViewContext context, int x, int y)
		{

			//Debug.WriteLine(String.Format("OnDragBegin, {0}, {1}, {2}", directionType.ToString(), x, y , centerX, centerY));
			if (x >= centerX - DirectionDrawing.CIRCLE_RADIUS && x <= centerX + DirectionDrawing.CIRCLE_RADIUS)
			{
				if (y >= centerY - DirectionDrawing.CIRCLE_RADIUS && y <= centerY + DirectionDrawing.CIRCLE_RADIUS)
				{
					//Debug.WriteLine(directionType.ToString());
					isCurrent = true;
					return;
				}
			}

			isCurrent = false;
			
		}

		public void OnDragMove(D2DRender.AnimationViewContext context, int x, int y)
		{
			if (!isCurrent) return;

			DoublePoint center = new DoublePoint(centerX, centerY);
			DoublePoint border = new DoublePoint(x, y);
			double angle = MathUtility.GetAngle(center, border, true);

			

			switch (directionType)
			{
				case AnimationDirectionType.Move:
					context.MoveAngle = Convert.ToSingle(angle);
					break;

				case AnimationDirectionType.Attack:
					context.AttackAngle = Convert.ToSingle(angle);
					break;
			}

			//Debug.WriteLine(String.Format("center = {0},{1}, border = {2},{3}, move = {4}, attack = {5}", center.X, center.Y, border.X, border.Y, context.MoveAngle, context.AttackAngle));

			context.AnimationView.Invalidate();
			context.AnimationView.ThrowDirectionChangedEvent();

		}

		public void OnDragEnd(D2DRender.AnimationViewContext context, int x, int y)
		{
			isCurrent = false;
		}
	}
}
