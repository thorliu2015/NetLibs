/*
 * ThorScrollView
 * liuqiang@2015/11/1 22:41:05
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Components.Drawing;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorScrollView : Control
	{
		#region constants

		#endregion

		#region variables


		/// <summary>
		/// 纵向滚动条
		/// </summary>
		protected ThorVScrollBar vScrollBar;

		/// <summary>
		/// 横向滚动条
		/// </summary>
		protected ThorHScrollBar hScrollBar;

		/// <summary>
		/// 滚动条设定
		/// </summary>
		protected ScrollBars scrollBars = ScrollBars.Vertical;

		/// <summary>
		/// 边框大小
		/// </summary>
		protected int borderSize = 1;

		/// <summary>
		/// 是否焦点进入
		/// </summary>
		protected bool focusIn = false;



		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public ThorScrollView()
			: base()
		{
			DoubleBuffered = true;

			InitScrollView();
		}

		#endregion

		#region methods

		

		/// <summary>
		/// 初始化滚动条
		/// </summary>
		virtual protected void InitScrollView()
		{
			TabStop = true;
			InitScrollBars();

			NoFocusBorder = true;

			this.Width = 100;
			this.Height = 100;
		}

		/// <summary>
		/// 获取焦点时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			focusIn = true;
			this.Invalidate();
		}

		/// <summary>
		/// 失去焦点时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			focusIn = false;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标按下
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.Select();
			this.Invalidate();
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="pevent"></param>
		protected virtual void DrawBackground(PaintEventArgs pevent)
		{
			pevent.Graphics.FillRectangle(ThorBrushs.Window, pevent.ClipRectangle);
		}

		/// <summary>
		/// 绘制滚动视图
		/// </summary>
		/// <param name="pevent"></param>
		protected virtual void DrawScrollView(PaintEventArgs pevent)
		{
			LayoutScrollView();
			DrawBackground(pevent);

			Rectangle rect = new Rectangle(0, 0, Width, Height);

			Form form = this.FindForm();
			Color tc = Color.Transparent;
			if (form is FlatForm)
			{
				FlatForm flatForm = (FlatForm)form;
				tc = flatForm.ThemeColor;
			}


			DrawScrollContent(pevent);


			if (!NoFocusBorder)
			{
				ThorControlPaint.DrawRectangle(pevent.Graphics, rect, (Focused) ?
					((tc != Color.Transparent) ? new Pen(new SolidBrush(tc)) : ThorPens.Focus)
					: ThorPens.WindowBorder, false);
			}
			else
			{
				ThorControlPaint.DrawRectangle(pevent.Graphics, rect, ThorPens.WindowBorder, false);
			}

			if (hScrollBar.Visible && vScrollBar.Visible)
			{
				rect.Width = vScrollBar.Width;
				rect.Height = hScrollBar.Height;
				rect.X = Width - rect.Width - borderSize;
				rect.Y = Height - rect.Height - borderSize;

				pevent.Graphics.FillRectangle(ThorBrushs.ScrollBarBackground, rect);
			}
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			DrawScrollView(pevent);
		}

		/// <summary>
		/// 绘制滚动内容
		/// </summary>
		/// <param name="e"></param>
		virtual protected void DrawScrollContent(PaintEventArgs e)
		{

		}

		/// <summary>
		/// 初始化滚动条
		/// </summary>
		virtual protected void InitScrollBars()
		{
			Padding = new System.Windows.Forms.Padding(1);
			vScrollBar = new ThorVScrollBar();
			hScrollBar = new ThorHScrollBar();
			vScrollBar.Visible = hScrollBar.Visible = false;

			Size size = MeasureScrollContentSize();
			hScrollBar.Minimum = 0;
			vScrollBar.Minimum = 0;
			vScrollBar.Maximum = size.Width;
			hScrollBar.Maximum = size.Height;
			hScrollBar.LargeChange = this.Width;
			vScrollBar.LargeChange = this.Height;

			Controls.Add(vScrollBar);
			Controls.Add(hScrollBar);

			LayoutScrollView();

			hScrollBar.MouseDown += ScrollBar_MouseDown;
			vScrollBar.MouseDown += ScrollBar_MouseDown;
			hScrollBar.Scroll += ScrollBar_Scroll;
			vScrollBar.Scroll += ScrollBar_Scroll;
		}

		/// <summary>
		/// 滚动位置改变时
		/// </summary>
		virtual protected void OnScrollPositionChanged()
		{
			this.Invalidate();
		}



		/// <summary>
		/// 操作滚动条时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ScrollBar_Scroll(object sender, EventArgs e)
		{
			OnScrollPositionChanged();
		}

		/// <summary>
		/// 计算内容的尺寸
		/// </summary>
		/// <returns></returns>
		virtual protected Size MeasureScrollContentSize()
		{
			Size size = new Size(0, 10);

			return size;
		}


		/// <summary>
		/// 在滚动条上按下鼠标
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ScrollBar_MouseDown(object sender, MouseEventArgs e)
		{
			this.Select();
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标滚轮
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			OnMouseWheelEvent(e);
		}

		/// <summary>
		/// 鼠标滚轮
		/// </summary>
		/// <param name="e"></param>
		virtual protected void OnMouseWheelEvent(MouseEventArgs e)
		{
			if (vScrollBar.Visible)
			{
				vScrollBar.Value -= e.Delta;
				vScrollBar.Invalidate();
				this.Invalidate();
				this.OnScrollPositionChanged();
			}
		}


		/// <summary>
		/// 更新布局
		/// </summary>
		virtual protected void LayoutScrollView()
		{
			vScrollBar.Visible = (scrollBars == ScrollBars.Both || scrollBars == ScrollBars.Vertical);
			hScrollBar.Visible = (scrollBars == ScrollBars.Both || scrollBars == ScrollBars.Horizontal);

			Size contentSize = MeasureScrollContentSize();

			if (vScrollBar.Visible)
			{
				vScrollBar.SuspendLayout();
				if (hScrollBar.Visible)
				{
					vScrollBar.Height = Height - hScrollBar.Height - borderSize * 2;
				}
				else
				{
					vScrollBar.Height = Height - borderSize * 2;
				}

				vScrollBar.Left = Width - vScrollBar.Width - borderSize * 2 + borderSize;
				vScrollBar.Top = borderSize;

				vScrollBar.LargeChange = vScrollBar.Height;
				vScrollBar.Maximum = contentSize.Height;
				vScrollBar.ResumeLayout();
			}

			if (hScrollBar.Visible)
			{
				hScrollBar.SuspendLayout();
				if (vScrollBar.Visible)
				{
					hScrollBar.Width = Width - vScrollBar.Width - borderSize * 2;
				}
				else
				{
					hScrollBar.Width = Width - borderSize * 2;
				}

				hScrollBar.Left = borderSize;
				hScrollBar.Top = Height - hScrollBar.Height - borderSize * 2 + borderSize;
				hScrollBar.LargeChange = hScrollBar.Width;
				hScrollBar.Maximum = contentSize.Width;
				hScrollBar.ResumeLayout();
			}
		}

		/// <summary>
		/// 缩放尺寸时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			LayoutScrollView();
			this.Invalidate();
		}

		#endregion

		#region properties

		/// <summary>
		/// 获取或设置滚动条
		/// </summary>
		public ScrollBars ScrollBars
		{
			get
			{
				return scrollBars;
			}
			set
			{
				if (scrollBars == value) return;
				scrollBars = value;
				LayoutScrollView();
				this.Invalidate();
			}
		}

		public bool NoFocusBorder { get; set; }

		/// <summary>
		/// 获取焦点是否进入
		/// </summary>
		public bool FocusIn
		{
			get
			{
				return focusIn;
			}
		}


		#endregion

		#region events

		#endregion
	}
}
