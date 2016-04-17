/*
 * ThorScrollBar
 * liuqiang@2015/11/1 22:40:05
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Properties;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public abstract class ThorScrollBar : Control
	{

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		public static extern IntPtr SetCapture(IntPtr h);

		#region constants

		#endregion

		#region variables

		protected System.Windows.Forms.Timer pressTimer = new Timer();
		protected Timer delayTimer = new Timer();
		protected bool isHorizontablDirection = true;
		protected int defaultSize = 15;
		protected int thumbMiniSize = 15;

		protected bool hitPrev = false;
		protected bool hitNext = false;
		protected bool hitThumb = false;

		protected Timer eventTimer = new Timer();
		protected bool needThrowScrollEvent = false;

		#endregion

		#region construct

		public ThorScrollBar()
			: base()
		{
			DoubleBuffered = true;
			TabStop = false;

			delayTimer.Interval = 500;
			delayTimer.Enabled = false;
			delayTimer.Tick += delayTimer_Tick;

			pressTimer.Interval = 50;
			pressTimer.Enabled = false;
			pressTimer.Tick += pressTimer_Tick;

			eventTimer.Interval = 10;
			eventTimer.Enabled = false;
			eventTimer.Tick += eventTimer_Tick;

			InitDefaultSize();
		}

		protected void eventTimer_Tick(object sender, EventArgs e)
		{
			if (!needThrowScrollEvent) return;

			needThrowScrollEvent = false;
			if (Scroll != null)
			{
				Scroll(this, new EventArgs());
			}
			eventTimer.Enabled = false;
			eventTimer.Stop();
		}



		#endregion

		#region methods

		protected virtual void InitDefaultSize()
		{
			Width = 100;
			Height = defaultSize;
		}

		/// <summary>
		/// 抛出滚动事件
		/// </summary>
		protected void ThrowScrollEvent()
		{
			needThrowScrollEvent = true;

			eventTimer.Enabled = true;
			eventTimer.Start();
		}

		/// <summary>
		/// 控件缩放时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (isHorizontablDirection)
			{
				_LargeChange = Width;
			}
			else
			{
				_LargeChange = Height;
			}

			this.Invalidate();
		}

		#region 绘制
		/// <summary>
		/// 绘制控件
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			DrawBackground(pevent.Graphics, pevent.ClipRectangle);
			DrawPrevButton(pevent.Graphics, pevent.ClipRectangle);
			DrawNextButton(pevent.Graphics, pevent.ClipRectangle);
			DrawThumb(pevent.Graphics);
		}

		/// <summary>
		/// 绘制滚动条背景
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DrawBackground(Graphics g, Rectangle clipRectangle)
		{
			g.FillRectangle(ThorBrushs.ScrollBarBackground, clipRectangle);
			//g.Clear(ThorColors.ControlDark);
		}

		/// <summary>
		/// 绘制前滚按钮
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DrawPrevButton(Graphics g, Rectangle clipRectangle)
		{
			Rectangle rect = MeasurePrevButtonRect();
			if (rect.Top > clipRectangle.Bottom) return;
			if (rect.Bottom < clipRectangle.Top) return;
			if (rect.Left > clipRectangle.Right) return;
			if (rect.Right < clipRectangle.Left) return;
			//ThorControlPaint.DrawButton(g, rect, ThorButtonState.Normal, false);

			ThorButtonState s = ThorButtonState.Normal;
			if (!mouseDraged)
			{
				if (hitPrev)
				{
					if (mousePressed) s = ThorButtonState.Pressed;
					else s = ThorButtonState.Hover;
				}
			}

			//ThorControlPaint.DrawFlatButton(g, rect, s, false, false);


			Image icon = isHorizontablDirection ? Resources.ArrowLeft3x : Resources.ArrowUp3x;
			ThorControlPaint.DrawIcon(g, rect, icon);

			//ThorControlPaint.DrawArrow(g, rect, ThorColors.ScrollBarForeground, isHorizontablDirection ? ThorArrowDirection.Left : ThorArrowDirection.Up, 5);
		}

		/// <summary>
		/// 绘制后滚按钮
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DrawNextButton(Graphics g, Rectangle clipRectangle)
		{
			Rectangle rect = MeasureNextButtonRect();
			if (rect.Top > clipRectangle.Bottom) return;
			if (rect.Bottom < clipRectangle.Top) return;
			if (rect.Left > clipRectangle.Right) return;
			if (rect.Right < clipRectangle.Left) return;
			//ThorControlPaint.DrawButton(g, rect, ThorButtonState.Normal, false);

			ThorButtonState s = ThorButtonState.Normal;
			if (!mouseDraged)
			{
				if (hitNext)
				{
					if (mousePressed) s = ThorButtonState.Pressed;
					else s = ThorButtonState.Hover;
				}
			}

			//ThorControlPaint.DrawFlatButton(g, rect, s, false, false);

			Image icon = isHorizontablDirection ? Resources.ArrowRight3x : Resources.ArrowDown3x;
			ThorControlPaint.DrawIcon(g, rect, icon);
		}

		/// <summary>
		/// 绘制滑块
		/// </summary>
		/// <param name="g"></param>
		protected virtual void DrawThumb(Graphics g)
		{
			if (_LargeChange >= _Maximum - _Minimum) return;

			Rectangle rect = MeasureThumbRect();
			//ThorControlPaint.DrawButton(g, rect, ThorButtonState.Normal, false);

			int p = 2;
			if (isHorizontablDirection)
			{
				rect.Y += p;
				rect.Height -= p * 2;
			}
			else
			{
				rect.X += p;
				rect.Width -= p * 2;
			}

			ThorButtonState s = ThorButtonState.Normal;
			if (hitThumb)
			{
				if (mousePressed)
				{
					s = ThorButtonState.Pressed;
				}
				else
				{
					s = ThorButtonState.Hover;
				}
			}
			ThorControlPaint.DrawFlatButton(g, rect, s, true, false);


			//---- [  |||  ]

			int lineMargin = 3;
			int lineSpacing = 1;
			int lineCount = 3;
			Point cp = new Point();

			if (isHorizontablDirection)
			{
				cp.Y = lineMargin;
				cp.X = rect.Width / 2;

				cp.X -= (lineCount * 1 + (lineCount - 1) * lineSpacing) / 2;
			}
			else
			{
				cp.X = lineMargin;
				cp.Y = rect.Height / 2;

				cp.Y -= (lineCount * 1 + (lineCount - 1) * lineSpacing) / 2;
			}

			cp.X += rect.X;
			cp.Y += rect.Y;

			int x1, y1, x2, y2;

			for (int i = 0; i < lineCount; i++)
			{
				if (isHorizontablDirection)
				{
					x1 = cp.X + (i * (lineSpacing + 1));
					x2 = x1;
					y1 = cp.Y;
					y2 = rect.Height - lineMargin + 1;
				}
				else
				{
					y1 = cp.Y + (i * (lineSpacing + 1));
					y2 = y1;
					x1 = cp.X;
					x2 = rect.Width - lineMargin + 1;
				}


				g.DrawLine(ThorPens.ScrollBarBackground, x1, y1, x2, y2);

			}

		}


		#endregion

		#region 交互

		/// <summary>
		/// 按下计时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void pressTimer_Tick(object sender, EventArgs e)
		{
			SetValue(_Value + pressedStep, true);
		}

		/// <summary>
		/// 延迟计时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void delayTimer_Tick(object sender, EventArgs e)
		{
			delayTimer.Enabled = false;
			delayTimer.Stop();

			pressTimer.Enabled = true;
			pressTimer.Start();
		}


		protected bool mousePressed = false;
		protected bool mouseDraged = false;
		protected Point pressedPosition = new Point();
		protected Rectangle pressedThumbRect = new Rectangle();
		protected int pressedStep = 0;

		/// <summary>
		/// 设置滚动值
		/// </summary>
		/// <param name="v"></param>
		/// <param name="e"></param>
		protected void SetValue(int v, bool e)
		{
			if (v > Maximum - LargeChange) v = Maximum - LargeChange;
			if (v < Minimum) v = Minimum;
			if (_Value == v) return;
			_Value = v;
			this.Invalidate();
			if (e) ThrowScrollEvent();
		}

		/// <summary>
		/// 按下鼠标时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (mousePressed) return;
			SetCapture(this.Handle);


			//判定位置

			Rectangle rectThumbFull = MeasureThumbFullRect();
			Rectangle rectThumb = MeasureThumbRect();
			Rectangle rectPrev = MeasurePrevButtonRect();
			Rectangle rectNext = MeasureNextButtonRect();

			int step = 0;

			if (rectThumb.Contains(e.X, e.Y))
			{
				mousePressed = true;
				pressedPosition.X = e.X;
				pressedPosition.Y = e.Y;

				pressedThumbRect = MeasureThumbRect();
				return;
			}
			else if (rectPrev.Contains(e.X, e.Y))
			{
				step = -SmallChange;
			}
			else if (rectNext.Contains(e.X, e.Y))
			{
				step = SmallChange;
			}
			else if (e.X < rectThumb.Left) step = -LargeChange;
			else if (e.X > rectThumb.Right) step = LargeChange;
			else if (e.Y < rectThumb.Top) step = -LargeChange;
			else if (e.Y > rectThumb.Bottom) step = LargeChange;

			if (step != 0)
			{
				pressedPosition.X = e.X;
				pressedPosition.Y = e.Y;
				pressedStep = step;
				SetValue(_Value + step, true);
				delayTimer.Enabled = true;
				delayTimer.Start();
				this.Invalidate();
			}
			else
			{
				pressedStep = 0;
			}
		}

		/// <summary>
		/// 松开鼠标时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			delayTimer.Enabled = false;
			pressTimer.Enabled = false;
			delayTimer.Stop();
			pressTimer.Stop();

			HitButtons(e);
			ReleaseCapture();

			this.Invalidate();
			if (!mousePressed) return;

			mousePressed = false;
			mouseDraged = false;
		}

		protected void HitButtons(MouseEventArgs e)
		{
			if (!mouseDraged)
			{
				Rectangle rectThumb = MeasureThumbRect();
				Rectangle rectPrev = MeasurePrevButtonRect();
				Rectangle rectNext = MeasureNextButtonRect();

				hitThumb = false;
				hitPrev = false;
				hitNext = false;

				hitThumb = rectThumb.Contains(e.X, e.Y);
				hitPrev = rectPrev.Contains(e.X, e.Y);
				hitNext = rectNext.Contains(e.X, e.Y);
			}
		}

		/// <summary>
		/// 移动鼠标时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			
			

			//----

			if (!mousePressed)
			{
				HitButtons(e);
				this.Invalidate();

				return;
			}


			mouseDraged = true;

			Point p = new Point();
			p.X = e.X - pressedPosition.X;
			p.Y = e.Y - pressedPosition.Y;

			double rate = 0;
			Rectangle rectFull = MeasureThumbFullRect();

			if (isHorizontablDirection)
			{
				p.X += pressedThumbRect.X;

				rate = (p.X - rectFull.Left) * 1f / (rectFull.Width - pressedThumbRect.Width) * 1f;
			}
			else
			{
				p.Y += pressedThumbRect.Y;

				rate = (p.Y - rectFull.Top) * 1f / (rectFull.Height - pressedThumbRect.Height) * 1f;
			}

			if (rate > 1) rate = 1;
			if (rate < 0) rate = 0;

			if (double.IsNaN(rate)) rate = 0;

			int newValue = Convert.ToInt32(rate * (_Maximum - _Minimum - _LargeChange));
			if (_Value != newValue)
			{
				_Value = newValue;

				if (isHorizontablDirection)
				{
					this.Invalidate(new Rectangle(defaultSize, 0, Width - defaultSize * 2, Height));
				}
				else
				{
					this.Invalidate(new Rectangle(0, defaultSize, Width, Height - defaultSize * 2));
				}
				ThrowScrollEvent();
			}
		}

		/// <summary>
		/// 鼠标离开时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			if (mouseDraged) return;

			hitPrev = false;
			hitNext = false;
			hitThumb = false;
			this.Invalidate();
		}

		#endregion

		#region 计算

		/// <summary>
		/// 计算完整的滑动区域
		/// </summary>
		/// <returns></returns>
		protected Rectangle MeasureThumbFullRect()
		{
			Rectangle rect = new Rectangle(0, 0, Width, Height);

			Rectangle rectPrev = MeasurePrevButtonRect();
			Rectangle rectNext = MeasureNextButtonRect();

			if (isHorizontablDirection)
			{
				rect.X += rectPrev.Width;
				rect.Width -= rectPrev.Width + rectNext.Width;
				rect.X--;
				rect.Width += 2;
			}
			else
			{
				rect.Y += rectPrev.Height;
				rect.Height -= rectPrev.Height + rectNext.Height;
				rect.Y--;
				rect.Height += 2;
			}

			return rect;
		}

		/// <summary>
		/// 计算滑块区域
		/// </summary>
		/// <returns></returns>
		protected Rectangle MeasureThumbRect()
		{
			Rectangle rectFull = MeasureThumbFullRect();
			Rectangle rect = new Rectangle(rectFull.X, rectFull.Y, rectFull.Width, rectFull.Height);

			//计算尺寸
			double thumbSize = 0;
			if (_LargeChange > 0)
			{
				thumbSize = (_LargeChange * 1f) / ((_Maximum - _Minimum) * 1f);

				if (thumbSize < 0) thumbSize = 0;
				if (thumbSize > 1) thumbSize = 1;

				if (isHorizontablDirection)
				{
					rect.Width = Convert.ToInt32(thumbSize * rectFull.Width);
					if (rect.Width < thumbMiniSize) rect.Width = thumbMiniSize;
				}
				else
				{
					rect.Height = Convert.ToInt32(thumbSize * rectFull.Height);
					if (rect.Height < thumbMiniSize) rect.Height = thumbMiniSize;
				}
			}

			//计算位置
			double thumbPos = 0;
			if (_Value > 0)
			{
				thumbPos = ((_Value - _Minimum) * 1f) / ((_Maximum - _Minimum - _LargeChange) * 1f);

				if (thumbPos < 0) thumbPos = 0;
				if (thumbPos > 1) thumbPos = 1;

				if (isHorizontablDirection)
				{
					rect.X += Convert.ToInt32(thumbPos * (rectFull.Width - rect.Width));
				}
				else
				{
					rect.Y += Convert.ToInt32(thumbPos * (rectFull.Height - rect.Height));
				}
			}

			return rect;
		}

		/// <summary>
		/// 计算前滚按钮的区域
		/// </summary>
		/// <returns></returns>
		protected Rectangle MeasurePrevButtonRect()
		{
			Rectangle rect = new Rectangle();

			if (isHorizontablDirection)
			{
				rect.Width = defaultSize;
				rect.Height = Height;
			}
			else
			{
				rect.Height = defaultSize;
				rect.Width = Width;
			}

			return rect;
		}

		/// <summary>
		/// 计算后滚按钮的区域
		/// </summary>
		/// <returns></returns>
		protected Rectangle MeasureNextButtonRect()
		{
			Rectangle rect = new Rectangle();

			if (isHorizontablDirection)
			{
				rect.Width = defaultSize;
				rect.Height = Height;
				rect.X = Width - rect.Width;
			}
			else
			{
				rect.Height = defaultSize;
				rect.Width = Width;
				rect.Y = Height - rect.Height;
			}

			return rect;
		}

		#endregion

		#endregion

		#region properties

		protected int _Maximum = 100;
		protected int _Minimum = 0;
		protected int _SmallChange = 1;
		protected int _LargeChange = 10;
		protected int _Value = 0;

		/// <summary>
		/// 获取或设置最大滚动值
		/// </summary>
		public int Maximum
		{
			get
			{
				return _Maximum;
			}
			set
			{
				if (_Maximum == value) return;
				_Maximum = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置最小滚动值
		/// </summary>
		public int Minimum
		{
			get
			{
				return _Minimum;
			}
			set
			{
				if (_Minimum == value) return;
				_Minimum = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置小幅滚动值
		/// </summary>
		public int SmallChange
		{
			get
			{
				return _SmallChange;
			}
			set
			{
				if (_SmallChange == value) return;
				_SmallChange = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置大幅滚动值
		/// </summary>
		public int LargeChange
		{
			get
			{
				return _LargeChange;
			}
			set
			{
				if (_LargeChange == value) return;
				_LargeChange = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 获取或设置当前滚动值
		/// </summary>
		public int Value
		{
			get
			{
				int v = _Value;

				if (v > _Maximum - _LargeChange) v = _Maximum - _LargeChange;
				if (v < _Minimum) v = _Minimum;

				return v;
			}
			set
			{
				if (_Value == value) return;
				_Value = value;
				this.Invalidate();
			}
		}

		#endregion

		#region events

		/// <summary>
		/// 滚动条被用户滚动之后
		/// </summary>
		public event EventHandler Scroll;

		#endregion
	}
}
