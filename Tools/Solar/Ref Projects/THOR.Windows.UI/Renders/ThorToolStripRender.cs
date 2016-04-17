using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Components;
using System.Drawing;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 工具栏系列控件的绘制
	/// </summary>
	public class ThorToolStripRender : ToolStripProfessionalRenderer
	{

		public ThorToolStripRender()
			: base()
		{
			RoundedEdges = false;
		}

		/// <summary>
		/// 绘制背景
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			Rectangle rect = new Rectangle();
			rect.Width = e.ToolStrip.Width;
			rect.Height = e.ToolStrip.Height;

			if (e.ToolStrip is TStatusBar)
			{
				rect.Height += 2;
				UIRender.DrawDarkBand(e.Graphics, rect);
			}
			else if (e.ToolStrip is TToolBar)
			{
				UIRender.DrawBand(e.Graphics, rect);
			}
			else if (e.ToolStrip is TMenuBar)
			{
				UIRender.DrawBand(e.Graphics, rect);
			}
			else
				base.OnRenderToolStripBackground(e);
		}

		/// <summary>
		/// 绘制边框
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip is TStatusBar)
			{ }
			else if (e.ToolStrip is TToolBar)
			{ }
			else
				base.OnRenderToolStripBorder(e);
		}

		/// <summary>
		/// 绘制分隔线
		/// </summary>
		/// <param name="e"></param>
		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			if (e.ToolStrip is TToolBar)
			{
				UIRender.DrawSeparator(e.Graphics, e.Item.Bounds.Width / 2, 0, e.Item.Height, true);
			}
			else if (e.ToolStrip is ToolStripDropDownMenu)
			{
				UIRender.DrawSeparator(e.Graphics, 0, e.Item.Height / 2, e.Item.Width, false);
			}
			else
				base.OnRenderSeparator(e);
		}
	}
}
