/*
 * Direct2DCanvas
 * liuqiang@2015/12/15 15:18:42
 * ---- 8< ------------------
 * NOTE
 */

using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//---- 8< ------------------

namespace THOR.D2D
{
	/// <summary>
	/// Direct2D画布控件
	/// </summary>
	public class Direct2DCanvas : Control
	{
		#region constants

		#endregion

		#region variables

		protected D2DRender Render;
		protected Timer FpsTimer;

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public Direct2DCanvas()
			: base()
		{
			InitCanvas();
		}

		#endregion

		#region methods

		/// <summary>
		/// 初始化画布
		/// </summary>
		protected virtual void InitCanvas()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

			FpsTimer = new Timer();
			FpsTimer.Enabled = false;
			FpsTimer.Interval = 1000;

			this.BackColor = System.Drawing.Color.Black;
			this.ForeColor = System.Drawing.Color.Gray;

			Size = new System.Drawing.Size(100, 100);

			FpsTimer = new Timer();
			int fpsInterval = (1000 / GetFps());
			if (fpsInterval < 1) fpsInterval = 1;
			if (fpsInterval > 1000) fpsInterval = 1000;
			FpsTimer.Interval = fpsInterval;
			FpsTimer.Tick += FpsTimer_Tick;
			FpsTimer.Start();
		}

		/// <summary>
		/// 计时器
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void FpsTimer_Tick(object sender, EventArgs e)
		{
			this.Invalidate();
		}

		/// <summary>
		/// 初始化渲染器
		/// </summary>
		protected virtual void InitRender()
		{
			if (DesignMode) return;
			if (Render != null && !Render.Disposed) return;

			Render = new D2DRender();
			Render.Initialize(this);
		}

		/// <summary>
		/// FPS
		/// </summary>
		/// <returns></returns>
		protected virtual int GetFps()
		{
			return 1000;
		}

		/// <summary>
		/// 缩放控件时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (Render != null && !Render.Disposed)
			{
				Render.RenderTarget.Resize(new SharpDX.Size2(Width, Height));
				this.Invalidate();
			}
		}

		/// <summary>
		/// 重绘背景
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (DesignMode)
			{
				base.OnPaintBackground(pevent);
			}
			else
			{
				DrawCanvas();
			}
		}

		/// <summary>
		/// 重绘前景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
		}

		/// <summary>
		/// 绘制画布
		/// </summary>
		protected virtual void DrawCanvas()
		{
			InitRender();

			try
			{
				if (Render.Disposed) return;

				Render.RenderTarget.BeginDraw();

				//System.Drawing.Color bc = System.Drawing.Color.Blue;
				System.Drawing.Color bc = this.BackColor;
				//Render.RenderTarget.Clear(Render.GetColor4(bc));
				Render.RenderTarget.FillRectangle(new SharpDX.RectangleF(0, 0, Width, Height), Render.GetSolidColorBrush(bc));

				Drawing();

				Render.RenderTarget.EndDraw();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Render.Dispose();
				Render = null;
				this.Invalidate();
			}
		}



		/// <summary>
		/// 绘制画布内容
		/// </summary>
		protected virtual void Drawing()
		{
			if (RenderMethod != null)
			{
				RenderMethod.Draw(this, Render);
			}

			
		}

		#endregion

		#region properties

		public Direct2DRenderMethod RenderMethod { get; set; }
		

		#endregion

		#region events

		#endregion
	}
}
