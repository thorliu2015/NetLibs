/*
 * D2DRenderMethod
 * liuqiang@2015/12/20 17:13:13
 * ---- 8< ------------------
 * NOTE
 */

using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.D2D
{
	public class Direct2DRenderMethod
	{
		#region constants

		#endregion

		#region variables

		protected float minScale = 0.25f;
		protected float maxScale = 5;
		protected float scale = 1;

		#endregion

		#region construct

		public Direct2DRenderMethod()
			: base()
		{
			AnchorX = 0;
			AnchorY = 0;
			ScrollX = 0;
			ScrollY = 0;
			Rotation = 0;

			ContentWidth = 2000;
			ContentHeight = 1000;
		}

		#endregion

		#region methods

		public float stepIndex = 0;
		public float step = 0.1f;

		public virtual void Draw(Control control, D2DRender render)
		{
			//DPI
			SharpDX.Size2F dpi = render.RenderTarget.DotsPerInch;
			int Width = control.Width;
			int Height = control.Height;

			//文本
			//Exo 2.0
			//Tahoma
			//Consolas
			//Segoe UI
			//Arial
			//Verdana
			render.RenderTarget.TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Cleartype;


			//pt=1/72(英寸), px=1/dpi(英寸)
			float fontSize = 80f * ((1f / 72f) * dpi.Width);

			SharpDX.DirectWrite.TextFormat tf = new SharpDX.DirectWrite.TextFormat(new SharpDX.DirectWrite.Factory(), "Consolas", fontSize);

			SharpDX.RectangleF rect = new SharpDX.RectangleF(300, 200, Width, Height);


			render.RenderTarget.AntialiasMode = SharpDX.Direct2D1.AntialiasMode.PerPrimitive;
			SharpDX.Direct2D1.SolidColorBrush brush = render.GetSolidColorBrush(System.Drawing.Color.Red);

			StrokeStyleProperties strokeProperties = new StrokeStyleProperties();
			strokeProperties.StartCap = CapStyle.Square;
			strokeProperties.EndCap = CapStyle.Square;
			strokeProperties.LineJoin = LineJoin.Round;

			strokeProperties.DashStyle = DashStyle.Custom;
			strokeProperties.DashOffset = stepIndex;
			strokeProperties.DashCap = CapStyle.Square;



			StrokeStyle strokeStyle = new StrokeStyle(render.Factory2D, strokeProperties, new[] { 0.3333f, 3f });	//自定义虚线
			//StrokeStyle strokeStyle = new StrokeStyle(Render.Factory2D, strokeProperties);	//


			//转换

			//常用2D(缩放,旋转)
			//Render.RenderTarget.Transform =  
			//	SharpDX.Matrix.Transformation2D(
			//		new SharpDX.Vector2(rect.X,rect.Y),	//scalingCenter
			//		0,	//scalingRotation
			//		new SharpDX.Vector2(1,1),	//scaling
			//		new SharpDX.Vector2(rect.X,rect.Y), //rotationCenter
			//		SharpDX.MathUtil.DegreesToRadians(stepIndex), //rotation
			//		new SharpDX.Vector2(0,0));	//translation

			//Render.RenderTarget.Transform = SharpDX.Matrix.Shadow
			//SharpDX.Matrix.RotationZ(ArowRotation) * SharpDX.Matrix.Translation(200,100, 1);

			//----

			render.RenderTarget.Transform = SharpDX.Matrix.Transformation2D(
				new SharpDX.Vector2(AnchorX, AnchorY),
				0,
				new SharpDX.Vector2(Scale, Scale),
				new SharpDX.Vector2(AnchorX, AnchorY),
				SharpDX.MathUtil.DegreesToRadians(Rotation),
				new SharpDX.Vector2(ScrollX, ScrollY));

			Random rnd = new Random();
			for (int i = 0; i < 1; i++)
			{
				//线
				//Render.RenderTarget.DrawLine(
				//	//new SharpDX.Vector2(rnd.Next(0, Width) + i, rnd.Next(0, Height) + i * 3 - 300),
				//	//new SharpDX.Vector2(rnd.Next(0, Width) - i, rnd.Next(0, Height) + i * 3 + 300),

				//	new SharpDX.Vector2(100, 100),
				//	new SharpDX.Vector2(1000, 650),
				//	brush, 20f, strokeStyle);

				//多边形
				//Render.RenderTarget.DrawEllipse(new Ellipse(new SharpDX.Vector2(500, 300), 200, 200), brush, 9f, strokeStyle);


				//文本
				//rect.X = rnd.Next(0, Width);
				//rect.Y = rnd.Next(0, Height);

				string ts = "ss:fff"; // "HH:mm:ss:fff";
				render.RenderTarget.DrawText("" + DateTime.Now.ToString(ts), tf
				, rect,
					render.GetSolidColorBrush(System.Drawing.Color.White));
			}


			stepIndex += step;

		}

		#endregion

		#region properties

		public float AnchorX { get; set; }
		public float AnchorY { get; set; }
		public float ScrollX { get; set; }
		public float ScrollY { get; set; }
		public float Rotation { get; set; }

		public int ContentWidth { get; set; }
		public int ContentHeight { get; set; }

		public float Scale
		{
			get
			{
				return scale;
			}
			set
			{
				float newScale = value;
				if (newScale > maxScale) newScale = maxScale;
				if (newScale < minScale) newScale = minScale;
				if (newScale == scale) return;
				scale = newScale;
			}
		}

		#endregion

		#region events

		#endregion
	}
}
