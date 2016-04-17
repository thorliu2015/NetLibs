using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.D2D.Core;

namespace Solar.Components.D2DRender
{
	public class AnimationViewContext
	{
		public AnimationViewContext()
		{
			DrawGuide = true;
			ViewStyle = AnimationViewStyle.Light;
			Scale = new PointF(1, 1);
			MoveAngle = 45;
			AttackAngle = 45;
		}

		public AnimationViewContext Clone()
		{
			AnimationViewContext r = new AnimationViewContext();

			r.AnimationView = AnimationView;
			r.Render = Render;
			r.Controller = Controller;

			r.FrameIndex = FrameIndex;

			r.DrawGuide = DrawGuide;
			r.ViewStyle = ViewStyle;

			r.Position = new PointF(Position.X, Position.Y);
			r.Scale = new PointF(Scale.X, Scale.Y);
			r.Rotation = 0;

			r.MoveAngle = MoveAngle;
			r.AttackAngle = AttackAngle;

			return r;
		}

		//---- 引用

		/// <summary>
		/// 动画视图控件
		/// </summary>
		public AnimationView AnimationView { get; set; }

		/// <summary>
		/// 渲染器
		/// </summary>
		public WindowRenderTarget Render { get; set; }

		/// <summary>
		/// 控制器
		/// </summary>
		public D2DController Controller { get; set; }


		//---- 参数

		/// <summary>
		/// 帧索引
		/// </summary>
		public Int64 FrameIndex { get; set; }

		/// <summary>
		/// 是否绘制辅助线
		/// </summary>
		public bool DrawGuide { get; set; }

		/// <summary>
		/// 控件颜色风格
		/// </summary>
		public AnimationViewStyle ViewStyle { get; set; }

		/// <summary>
		/// 当前位置
		/// </summary>
		public PointF Position { get; set; }
		

		/// <summary>
		/// 当前缩放比例
		/// </summary>
		public PointF Scale { get; set; }

		/// <summary>
		/// 当前旋转角度
		/// </summary>
		public float Rotation { get; set; }


		

		/// <summary>
		/// 当前移动方向角度
		/// </summary>
		public float MoveAngle { get; set; }

		/// <summary>
		/// 当前攻击方向角度
		/// </summary>
		public float AttackAngle { get; set; }
	}
}
