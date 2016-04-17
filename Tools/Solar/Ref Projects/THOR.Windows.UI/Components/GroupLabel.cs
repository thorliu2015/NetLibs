using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;

namespace THOR.Windows.UI.Components
{
	public partial class GroupLabel : UserControl
	{
		public GroupLabel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			PaintBackground(e.Graphics);
			PaintIcon(e.Graphics);
			PaintTitle(e.Graphics);
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="g"></param>
		protected void PaintBackground(Graphics g)
		{
			int x = 5;// +18;
			int w = Width - 38;
			Rectangle rect = new Rectangle();
			rect.X = 5 + 18;
			rect.Height = Height;
			rect.Width = this.Bounds.Width - 28;
			int t = TextRenderer.MeasureText(title, Font).Width;

			x += t;
			w -= t;

			g.DrawLine(
				SystemPens.Control
				, x, Height / 2, x + w, Height / 2);
		}

		/// <summary>
		/// 绘制图标
		/// </summary>
		/// <param name="g"></param>
		protected void PaintIcon(Graphics g)
		{
			Rectangle rect = new Rectangle();
			rect.Width = rect.Height = 18;
			rect.Y = (this.Height - rect.Height) / 2;
			rect.X = Width - 18 - 5;

			Bitmap bmp = Expanded ? UIResources.IconExpand : UIResources.IconCollapse;

			UIRender.DrawBitmap(g, bmp, rect.X, rect.Y);
		}

		/// <summary>
		/// 绘制标题
		/// </summary>
		/// <param name="g"></param>
		protected void PaintTitle(Graphics g)
		{
			Rectangle rect = new Rectangle();
			rect.X = 5;// +18;
			rect.Height = Height;
			rect.Width = this.Width - 28;
			TextRenderer.DrawText(g, title, Font, rect,
				this.Expanded ? ForeColor : SystemColors.ControlDark
				, TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
		}

		/// <summary>
		/// 点击鼠标
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			this.Expanded = !this.Expanded;
		}

		/// <summary>
		/// 缩放时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}


		private bool expanded = false;
		/// <summary>
		/// 是否展开状态
		/// </summary>
		public bool Expanded
		{
			get
			{
				return expanded;
			}
			set
			{
				if (expanded == value) return;
				expanded = value;
				this.Invalidate();
				if (ExpandChanged != null) ExpandChanged(this, new EventArgs());
			}
		}

		private string title = "Untitled";
		/// <summary>
		/// 显示标题
		/// </summary>
		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				if (title == value) return;

				title = value;
				this.Invalidate();
			}
		}

		public event EventHandler ExpandChanged;
	}
}
