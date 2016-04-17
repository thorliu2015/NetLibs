using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace THOR.Windows.UI.Components
{
	/// <summary>
	/// 面板
	/// </summary>
	public class TPanel : Panel
	{
		/// <summary>
		/// 标题
		/// </summary>
		protected string title = "Untitled";

		/// <summary>
		/// 构造
		/// </summary>
		public TPanel()
			: base()
		{
			Init();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected void Init()
		{
			TitleFont = new Font("Consolas", 8.25f, FontStyle.Bold);
			this.Padding = new Padding(2, 24, 2, 2);
			ForeColor = SystemColors.ControlDarkDark;
			DoubleBuffered = true;
		}

		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);

			this.Invalidate();
		}

		/// <summary>
		/// 重绘过程
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			Rectangle rect = new Rectangle();

			rect.X = 1;
			rect.Y = 1;
			rect.Width = Width - 3;
			rect.Height = Height - 3;

			if (rect.Width < 1 || rect.Height < 1) return;


			e.Graphics.FillRectangle(UIBrushes.Workspace, rect);
			Rectangle rectBar = new Rectangle(rect.X, rect.Y, rect.Width, 22);
			Brush brush = new LinearGradientBrush(
				rectBar,
				SystemColors.ControlLightLight,
				SystemColors.Control,
				LinearGradientMode.Vertical);
			e.Graphics.FillRectangle(brush, rectBar);

			e.Graphics.DrawRectangle(UIPens.Workspace, rect);
			e.Graphics.DrawLine(UIPens.Workspace, rectBar.Left + 1, rectBar.Bottom, rectBar.Right - 1, rectBar.Bottom);

			Brush spaceBrush = SystemBrushes.Window;




			//Rectangle rect = new Rectangle();

			//rect.X = 1;
			//rect.Y = 23;
			//rect.Width = Width - 2;
			//rect.Height = Height - 24;

			//UIRender.DrawWorkspace(e.Graphics, rect);

			rect.X = 0;
			rect.Y = 0;
			rect.Width = Width;
			rect.Height = 22;

			UIRender.DrawText(e.Graphics, Title, rectBar.X + 6, rectBar.Y + 1, rectBar.Width - 10, rectBar.Height, TitleFont, SystemColors.ControlLightLight, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			UIRender.DrawText(e.Graphics, Title, rectBar.X + 5, rectBar.Y, rectBar.Width - 10, rectBar.Height, TitleFont, ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
		}

		/// <summary>
		/// 标题字体
		/// </summary>
		public Font TitleFont { get; set; }

		/// <summary>
		/// 标题
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
	}
}
