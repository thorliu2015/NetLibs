using System;
using System.Collections.Generic;
using System.Text;
using THOR.Windows.UI.Components;
using System.Drawing;
using System.Windows.Forms;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 根据鼠标状态的渲染方式
	/// </summary>
	public class MouseStatusRender
	{
		/// <summary>
		/// 绘制标准图形
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="status"></param>
		static public void DrawDefault(Graphics g, Rectangle rect, MouseStatus status)
		{
			Pen pen = SystemPens.Highlight;
			Brush brush;

			if (status.IsChecked)
			{
				//选中
				if (status.IsHoved)
				{
					if (status.IsPressed)
					{
						brush = new SolidBrush(Color.FromArgb(75, SystemColors.Highlight));
					}
					else
					{
						brush = new SolidBrush(Color.FromArgb(50, SystemColors.Highlight));
					}
				}
				else
				{
					if (status.IsPressed)
					{
						brush = new SolidBrush(Color.FromArgb(75, SystemColors.Highlight));
					}
					else
					{
						brush = new SolidBrush(Color.FromArgb(25, SystemColors.Highlight));
					}
				}
			}
			else
			{
				//未选中
				if (status.IsHoved)
				{
					if (status.IsPressed)
					{
						brush = new SolidBrush(Color.FromArgb(50, SystemColors.Highlight));
					}
					else
					{
						brush = new SolidBrush(Color.FromArgb(25, SystemColors.Highlight));
					}
				}
				else
				{
					if (status.IsPressed)
					{
						brush = new SolidBrush(Color.FromArgb(0, SystemColors.Highlight));
					}
					else
					{
						brush = new SolidBrush(Color.FromArgb(0, SystemColors.Highlight));
					}
				}
			}

			g.FillRectangle(brush, rect);

			if (status.IsChecked || status.IsHoved)
			{
				rect.Width--;
				rect.Height--;
				g.DrawRectangle(pen, rect);
			}

		}
	}
}
