/*
 * ThorDirect2DView
 * liuqiang@2015/12/20 15:34:16
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Common;
using THOR.D2D;

//---- 8< ------------------

namespace THOR.Windows.Components.D2D
{
	public class ThorDirect2DView : ThorScrollView
	{
		#region constants

		#endregion

		#region variables

		protected Direct2DCanvas direct2dCanvas;

		#endregion

		#region construct

		public ThorDirect2DView()
			: base()
		{
			Dock = System.Windows.Forms.DockStyle.Fill;
			this.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		}

		#endregion

		#region methods

		/// <summary>
		/// 设置画布
		/// </summary>
		protected virtual void SetupCanvas()
		{
			this.Controls.Add(direct2dCanvas);
		}

		/// <summary>
		/// 布置滚动视图
		/// </summary>
		protected override void LayoutScrollView()
		{
			base.LayoutScrollView();

			if (direct2dCanvas != null)
			{
				System.Drawing.Size sizeCanvas = new System.Drawing.Size(Width, Height);


				sizeCanvas.Width -= borderSize * 2;
				sizeCanvas.Height -= borderSize * 2;

				if (vScrollBar.Visible)
				{
					sizeCanvas.Width -= vScrollBar.Width;
				}

				if (hScrollBar.Visible)
				{
					sizeCanvas.Height -= hScrollBar.Height;
				}

				direct2dCanvas.Location = new System.Drawing.Point(borderSize, borderSize);
				direct2dCanvas.Size = sizeCanvas;
			}
		}

		protected override System.Drawing.Size MeasureScrollContentSize()
		{
			System.Drawing.Size size = new System.Drawing.Size();

			if (direct2dCanvas != null)
			{
				if (direct2dCanvas.RenderMethod != null)
				{
					size.Width = direct2dCanvas.RenderMethod.ContentWidth;
					size.Height = direct2dCanvas.RenderMethod.ContentHeight;
				}
			}

			return size;
		}

		protected override void OnScrollPositionChanged()
		{
			

			if (direct2dCanvas != null)
			{
				if (direct2dCanvas.RenderMethod != null)
				{
					direct2dCanvas.RenderMethod.ScrollX = -hScrollBar.Value;
					direct2dCanvas.RenderMethod.ScrollY = -vScrollBar.Value;

					direct2dCanvas.Invalidate();
				}
			}

			this.Invalidate();
		}

		public void InvalidateContent()
		{
			if (direct2dCanvas != null)
			{
				direct2dCanvas.Invalidate();
			}
		}

		#endregion

		#region properties

		public Direct2DCanvas Canvas
		{
			get
			{
				return direct2dCanvas;
			}
			set
			{
				if (direct2dCanvas != null) return;
				direct2dCanvas = value;
				if (direct2dCanvas != null)
				{
					SetupCanvas();
					LayoutScrollView();
				}
			}
		}

		#endregion

		#region events

		#endregion
	}
}
