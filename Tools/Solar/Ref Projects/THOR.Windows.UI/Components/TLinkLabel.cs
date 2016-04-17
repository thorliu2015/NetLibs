using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;
using THOR.Windows.UI.Components.LinkLabelCore;

namespace THOR.Windows.UI.Components
{
	/// <summary>
	/// 链接标题
	/// </summary>
	public partial class TLinkLabel : UserControl
	{
		public const int LabelMargin = 2;

		#region variables

		/// <summary>
		/// 鼠标状态
		/// </summary>
		protected MouseStatus mouseStatus = new MouseStatus();

		/// <summary>
		/// 显示图标
		/// </summary>
		protected Bitmap icon;

		#endregion

		#region construct

		/// <summary>
		/// 构造
		/// </summary>
		public TLinkLabel()
		{
			InitializeComponent();


			//linkLabel.Text = "this is a 链接";
			//linkLabel.Links.Clear();
			//linkLabel.Links.Add(0, 4);

			linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
			LinkColor = Color.FromArgb(0xff, 192, 0, 0);
			LinkHoverColor = Color.FromArgb(0xff, 0xff, 0x33, 0x00);
			icon = UIResources.IconTriggerNote;

			this.linkLabel.MouseEnter += new EventHandler(linkLabel_MouseEnter);
			this.linkLabel.MouseLeave += new EventHandler(linkLabel_MouseLeave);
			this.linkLabel.MouseDown += new MouseEventHandler(linkLabel_MouseDown);
			this.linkLabel.MouseUp += new MouseEventHandler(linkLabel_MouseUp);
			this.linkLabel.MouseClick += new MouseEventHandler(linkLabel_MouseClick);
			this.linkLabel.MouseDoubleClick += new MouseEventHandler(linkLabel_MouseDoubleClick);
			this.linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
		}

		

		

		

		#endregion

		#region methods

		#region 绘制方法

		/// <summary>
		/// 自动设置大小
		/// </summary>
		protected void AutoUpdateSize()
		{
			if (LinkLabelRender != null) LinkLabelRender.Update(this);

			int h = Height;
			

			Size s = new System.Drawing.Size(Width, Int32.MaxValue);
			string t = linkLabel.Text;
			
			try
			{
				s = TextRenderer.MeasureText(t, Font, s, TextFormatFlags.Left | TextFormatFlags.WordBreak);
				h = s.Height + 6;

				
			}
			catch
			{
			}

			if (h < 24) h = 24;

			Height = h;
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			Rectangle rect = new Rectangle();

			rect.X = LabelMargin;
			rect.Y = LabelMargin;
			rect.Width = this.Width - LabelMargin * 2;
			rect.Height = this.Height - LabelMargin * 2;
			MouseStatusRender.DrawDefault(e.Graphics, rect, mouseStatus);
		}

		/// <summary>
		/// 绘制前景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			AutoUpdateSize();
			UIRender.DrawBitmap(e.Graphics, icon, LabelMargin + 2, LabelMargin + 2);
		}

		/// <summary>
		/// 缩放控件时
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			this.Invalidate();
		}
		#endregion

		#region 鼠标事件

		/// <summary>
		/// 点击链接
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			LinkItemSpan span = (LinkItemSpan)e.Link.LinkData;
			if (this.LinkItemSpanClick != null)
			{
				LinkItemSpanClick(this, new LinkItemSpanClickEventArgs(span));
			}
		}

		/// <summary>
		/// 鼠标按下
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			//mouseStatus.IsChecked = !mouseStatus.IsChecked;
			mouseStatus.IsPressed = true;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标松开
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			mouseStatus.IsPressed = false;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标进入
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			mouseStatus.IsHoved = true;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标移出
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			mouseStatus.IsHoved = false;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标松开
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseUp(object sender, MouseEventArgs e)
		{
			mouseStatus.IsPressed = false;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标按下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseDown(object sender, MouseEventArgs e)
		{
			mouseStatus.IsPressed = true;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标移开
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseLeave(object sender, EventArgs e)
		{
			mouseStatus.IsHoved = false;
			this.Invalidate();
		}

		/// <summary>
		/// 鼠标进入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseEnter(object sender, EventArgs e)
		{
			mouseStatus.IsHoved = true;
			this.Invalidate();
		}

		/// <summary>
		/// 点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseClick(object sender, MouseEventArgs e)
		{
			//mouseStatus.IsChecked = !mouseStatus.IsChecked;
			this.Invalidate();
			this.OnMouseClick(e);
		}

		/// <summary>
		/// 双击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void linkLabel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.OnMouseDoubleClick(e);
		}
		#endregion

		#endregion

		#region properties

		/// <summary>
		/// 是否已经选中
		/// </summary>
		public bool Checked
		{
			get
			{
				return mouseStatus.IsChecked;
			}
			set
			{
				mouseStatus.IsChecked = value;
				this.Invalidate();
			}
		}


		/// <summary>
		/// 链接项目
		/// </summary>
		public LinkItem LinkItem { get; set; }

		/// <summary>
		/// 链接项目渲染接口
		/// </summary>
		public ILinkLabelRender LinkLabelRender { get; set; }

		/// <summary>
		/// 图标
		/// </summary>
		public Bitmap Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (this.icon == value) return;
				this.icon = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 文本颜色
		/// </summary>
		public Color TextColor
		{
			get
			{
				return linkLabel.ForeColor;
			}
			set
			{
				if (linkLabel.ForeColor == value) return;

				linkLabel.ForeColor = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 默认的链接颜色
		/// </summary>
		public Color LinkColor
		{
			get
			{
				return linkLabel.LinkColor;
			}
			set
			{
				linkLabel.LinkColor = linkLabel.VisitedLinkColor = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// 鼠标指向时的链接颜色
		/// </summary>
		public Color LinkHoverColor
		{
			get
			{
				return linkLabel.ActiveLinkColor;
			}
			set
			{
				linkLabel.ActiveLinkColor = value;
				this.Invalidate();
			}
		}

		#endregion

		#region events

		public delegate void LinkItemSpanClickEventHandler(object sender, LinkItemSpanClickEventArgs e);
		public event LinkItemSpanClickEventHandler LinkItemSpanClick;

		#endregion
	}
}
