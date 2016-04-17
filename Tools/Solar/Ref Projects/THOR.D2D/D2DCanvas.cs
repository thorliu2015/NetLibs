using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using THOR.D2D.Core;
using THOR.D2D.Graphics;

namespace THOR.D2D
{
	public partial class D2DCanvas : Panel
	{
		#region constants

		#endregion

		#region variables

		/// <summary>
		/// Direct2D控制器
		/// </summary>
		protected D2DController D2D;

		/// <summary>
		/// 渲染计时器
		/// </summary>
		protected Timer RenderTimer;

		/// <summary>
		/// 每秒渲染的帧数
		/// </summary>
		protected uint _FPS = 0;

		/// <summary>
		/// 背景笔刷
		/// </summary>
		protected SharpDX.Direct2D1.SolidColorBrush BackgroundBrush;

		/// <summary>
		/// 渲染帧数
		/// </summary>
		public Int64 FrameIndex { get; protected set; }


		#endregion

		#region construct
		/// <summary>
		/// 构造
		/// </summary>
		public D2DCanvas()
		{
			InitializeComponent();

			RenderTimer = new Timer();
			RenderTimer.Tick += RenderTimer_Tick;

			BackColor = Color.FromArgb(0x1E, 0x1E, 0x1E);
			ForeColor = Color.FromArgb(0xE1, 0xE1, 0xE1);
		}
		#endregion

		#region methods

		/// <summary>
		/// 初始化
		/// </summary>
		virtual public void InitializeDirect2D()
		{
			D2D = new D2DController();
			D2D.Initialize(this);

			BackgroundBrush = D2D.GetSolidColorBrush(this.BackColor);
			
			if (FPS > 0) RenderTimer.Start();

		}

		/// <summary>
		/// 渲染时钟
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RenderTimer_Tick(object sender, EventArgs e)
		{
			NextFrame();
			this.Invalidate();
		}
		
		/// <summary>
		/// 重绘
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if (D2D == null)
			{
				base.OnPaintBackground(e);
				return;
			}

			D2D.WindowRenderTarget.Resize(new SharpDX.Size2(Bounds.Width, Bounds.Height));
			//D2D.WindowRenderTarget.AntialiasMode = SharpDX.Direct2D1.AntialiasMode.PerPrimitive;
			D2D.WindowRenderTarget.BeginDraw();

			//更新背景笔刷颜色
			BackgroundBrush.Color = D2D.GetColor(BackColor);
			Renderendering();

			D2D.WindowRenderTarget.EndDraw();
		}

		/// <summary>
		/// 需要切换至下一帧时
		/// </summary>
		virtual protected void NextFrame()
		{
			if (FrameIndex >= Int64.MaxValue)
			{
				FrameIndex = FrameIndex % FPS;
			}

			FrameIndex++;

		}

		/// <summary>
		/// 渲染过程
		/// </summary>
		virtual protected void Renderendering()
		{
			//绘制背景
			D2D.WindowRenderTarget.FillRectangle(new SharpDX.RectangleF(0, 0, Width, Height), BackgroundBrush);

			return;
			#region NOTE


			//绘制背景色
			


			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 100 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 500 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0xFF00FF00));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 140 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 540 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0xFFFFFFFF));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 180 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 580 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0x66FFFFFF));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 220 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 620 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0x33FFFFFF));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 260 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 660 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0xFFFFFF00));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 300 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 700 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0xFFFF0000));
			D2D.WindowRenderTarget.DrawLine(new SharpDX.Vector2(100 + AutoScrollPosition.X, 340 + AutoScrollPosition.Y), new SharpDX.Vector2(740 + AutoScrollPosition.X, 740 + AutoScrollPosition.Y), D2D.GetSolidColorBrush(0xFF00FFFF));


			D2D.WindowRenderTarget.DrawEllipse(new SharpDX.Direct2D1.Ellipse(new SharpDX.Vector2(300, 300), 128, 80), D2D.GetSolidColorBrush(0xFFFFFFFF));

			//D2D.WindowRenderTarget.DrawBitmap(new SharpDX.Direct2D1.Bitmap(),

			//SharpDX.Matrix3x2 m = new SharpDX.Matrix3x2();
			//SharpDX.Matrix3x2.Rotation(0.5f, out m);



			//旋转 + 缩放
			D2D.WindowRenderTarget.Transform = SharpDX.Matrix.Transformation2D(
				new SharpDX.Vector2(100, 100),		//scale center
				0f,									//
				new SharpDX.Vector2(1, 1),			//scale rate
				new SharpDX.Vector2(100, 100),		//rotation
				SharpDX.MathUtil.DegreesToRadians(45),
				new SharpDX.Vector2(-200, -200));


			D2D.WindowRenderTarget.DrawBitmap(D2D.LoadBitmap(@"C:\Docs\美国队长.png"), 0.5f, SharpDX.Direct2D1.BitmapInterpolationMode.Linear);
			D2D.WindowRenderTarget.Transform = SharpDX.Matrix.Transformation2D(new SharpDX.Vector2(0, 0), 0, new SharpDX.Vector2(1, 1), new SharpDX.Vector2(0, 0), 0, new SharpDX.Vector2(0, 0));
			//D2D.WindowRenderTarget.DrawBitmap(D2D.LoadBitmap(@"C:\Docs\美国队长.png"), 1, SharpDX.Direct2D1.BitmapInterpolationMode.Linear);

			//绘制透明网格
			//D2DRenderUtils.DrawAlphaGrid(CanvasRegion, 10, D2D.GetSolidColorBrush(0xFF1E1E1E), D2D.GetSolidColorBrush(0xFF282828));



			/*
			 * 
			 * 旋转
			 * 
			 * http://sharpdx.org/forum/5-api-usage/3429-bitmap-rotation
			 * 
			 * 
				public virtual void Render(TargetBase target)
				{
					if (!Show)return;
             
					YCoord += _DeltaY;
					if (YCoord < 0)
						YCoord = 0; 
					if (YCoord > _root.RenderSize.Height - 100f)
						YCoord = (float)_root.RenderSize.Height - 100f;
             
					RectangleF destinRect = new RectangleF(600, YCoord, 800, YCoord+100f);
 
					var context2D = target.DeviceManager.ContextDirect2D;
 
					_TestRotation += 1f;
					if (_TestRotation > 360)
						_TestRotation = 0;
             
					Update();
              
					_TheCar = SharpDX.Direct2D1.Bitmap.FromWicBitmap(context2D, _formatConverter);
             
					context2D.BeginDraw();
           
					context2D.Transform = Matrix.RotationZ( _TestRotation);
        
					if (EnableClear)
						context2D.Clear(Color.CornflowerBlue);
 
					context2D.DrawBitmap(_TheCar, destinRect, 1.0f, SharpDX.Direct2D1.BitmapInterpolationMode.Linear);
           
					context2D.EndDraw();
				}
			 * 
			 * 
			 */

			
			#endregion
		}

		#endregion

		#region properties

		/// <summary>
		/// 每秒渲染的帧数
		/// </summary>
		public uint FPS
		{
			get
			{
				return _FPS;
			}
			set
			{
				

				_FPS = value;

				if (_FPS > 0)
				{

					RenderTimer.Stop();
					RenderTimer.Interval = Convert.ToInt32(1000 / _FPS);
					RenderTimer.Start();
				}
				else
				{
					RenderTimer.Stop();
				}
			}
		}


		/// <summary>
		/// 获取Direct2D控制器
		/// </summary>
		public D2DController Direct2DController
		{
			get
			{
				return D2D;
			}
		}

		

		#endregion
	}
}
