/*
 * D2DTest
 * liuqiang@2015/12/15 11:42:05
 * ---- 8< ------------------
 * NOTE
 */

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
	public class D2DTest : Control
	{
		protected D2DRender render;

		public D2DTest()
			: base()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

			Dock = DockStyle.Fill;
			Timer t = new Timer();
			t.Interval = 10;
			t.Tick += t_Tick;
			t.Start();

			Button btn = new Button();
			btn.Width = 60;
			btn.Height = 25;
			btn.Top = 100;
			btn.Text = "T";
			this.Controls.Add(btn);
		}

		void t_Tick(object sender, EventArgs e)
		{
			this.Invalidate();
		}


		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (DesignMode)
			{
				base.OnPaintBackground(pevent);
				return;
			}

			Draw();
		}

		protected virtual void Draw()
		{
			if (DesignMode) return;
			if (render == null)
			{
				render = new D2DRender();
				render.Initialize(this);
			}

			try
			{
				if (render.Disposed) return;

				render.RenderTarget.BeginDraw();

				render.RenderTarget.Clear(render.GetColor4(0));
				//render.RenderTarget.FillRectangle(new SharpDX.RectangleF(0, 0, Width, Height), render.GetSolidColorBrush("#0000FF"));
				render.RenderTarget.DrawLine(new SharpDX.Vector2(100, 100), new SharpDX.Vector2(300, 200), render.GetSolidColorBrush(System.Drawing.Color.Red));

				SharpDX.DirectWrite.TextFormat tf = new SharpDX.DirectWrite.TextFormat(new SharpDX.DirectWrite.Factory(), "Tahoma", 10.5f);
				
				render.RenderTarget.DrawText(DateTime.Now.ToString(), tf
				, new SharpDX.RectangleF(0, 0, Width, Height),
					render.GetSolidColorBrush(System.Drawing.Color.White));

				render.RenderTarget.EndDraw();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				render.Dispose();
				render = null;
				this.Invalidate();
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (render != null)
			{
				render.RenderTarget.Resize(new SharpDX.Size2(Width, Height));

				this.Invalidate();
			}
		}



	}
}
