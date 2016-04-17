using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 界面渲染方法
	/// </summary>
	public class UIRender
	{
		/// <summary>
		/// 构造
		/// </summary>
		static UIRender()
		{
			DefaultFont = new Font("Consolas", 8.25f, GraphicsUnit.Point);
			//DefaultFont = new Font("Tahoma", 8.25f, GraphicsUnit.Point);
		}

		#region 基础绘图指令

		/// <summary>
		/// 绘制文本
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="text">文本</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <param name="font">字体</param>
		/// <param name="color">颜色</param>
		/// <param name="flags">标记</param>
		static public void DrawText(Graphics g, string text, int x, int y, int width, int height, Font font, Color color, TextFormatFlags flags)
		{
			TextRenderer.DrawText(g, text, font, new Rectangle(x, y, width, height), color, flags);
		}

		/// <summary>
		/// 绘制一个渐变矩形区域
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="rect">矩形区域</param>
		/// <param name="color1">起始颜色</param>
		/// <param name="color2">终止颜色</param>
		/// <param name="angle">角度</param>
		static public void DrawLinearGradienntRect(Graphics g, Rectangle rect, Color color1, Color color2, float angle)
		{
			LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, angle);
			g.FillRectangle(brush, rect);
		}

		/// <summary>
		/// 绘制线条
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		/// <param name="z">长度</param>
		/// <param name="color">颜色</param>
		/// <param name="v">是否纵向</param>
		static public void DrawLine(Graphics g, int x, int y, int z, Color color, bool v)
		{
			Color color1 = Color.FromArgb(0, color);
			Color color2 = color;
			Rectangle rect = new Rectangle(x, y, 1, 1);


			if (v)
			{
				rect.Height = z / 2 + 1;
				g.FillRectangle(new LinearGradientBrush(rect, color1, color2, 90), rect);

				rect.Y += z / 2;
				g.FillRectangle(new LinearGradientBrush(rect, color2, color1, 90), rect);
			}
			else
			{
				rect.Width = z / 2 + 1;
				g.FillRectangle(new LinearGradientBrush(rect, color1, color2, 0f), rect);

				rect.X += z / 2;
				g.FillRectangle(new LinearGradientBrush(rect, color2, color1, 0f), rect);
			}
		}
		#endregion

		#region 快捷绘图指令

		/// <summary>
		/// 绘制一个工作区域
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="rect">矩形区域</param>
		static public void DrawWorkspace(Graphics g, Rectangle rect)
		{
			rect.X++;
			rect.Y++;
			rect.Width -= 2;
			rect.Height -= 2;
			g.FillRectangle(UIBrushes.Workspace, rect);

			rect.X--;
			rect.Y--;
			rect.Width++;
			rect.Height++;
			g.DrawRectangle(UIPens.Workspace, rect);
		}

		/// <summary>
		/// 绘制一个应用程序工作区
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="rect">矩形区域</param>
		static public void DrawAppWorkspace(Graphics g, Rectangle rect)
		{
			rect.X++;
			rect.Y++;
			rect.Width -= 2;
			rect.Height -= 2;
			g.FillRectangle(UIBrushes.AppWorkspace, rect);

			rect.X--;
			rect.Y--;
			rect.Width++;
			rect.Height++;
			g.DrawRectangle(UIPens.AppWorkspace, rect);
		}

		/// <summary>
		/// 绘制一个带区
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="rect">矩形区域</param>
		static public void DrawBand(Graphics g, Rectangle rect)
		{
			DrawLinearGradienntRect(g, rect, UIColors.LightLightLight, UIColors.LightAlpha, 90);
			g.DrawLine(new Pen(new SolidBrush(UIColors.DarkDark)), rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
		}

		/// <summary>
		/// 绘制一个黑带区
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="rect">矩形区域</param>
		static public void DrawDarkBand(Graphics g, Rectangle rect)
		{
			g.DrawLine(new Pen(new SolidBrush(UIColors.DarkDarkDark)), rect.Left, rect.Top, rect.Right, rect.Top);

			rect.Y++;
			DrawLinearGradienntRect(g, rect, UIColors.LightDark, UIColors.DarkDarkDark, 90);

			g.DrawLine(new Pen(new SolidBrush(UIColors.LightLightLight)), rect.Left, rect.Top, rect.Right - 1, rect.Top);
		}

		/// <summary>
		/// 绘制分隔线
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		/// <param name="z">长度</param>
		/// <param name="v">是否纵向</param>
		static public void DrawSeparator(Graphics g, int x, int y, int z, bool v)
		{
			DrawLine(g, x, y, z, UIColors.DarkDarkDark, v);

			if (v)
			{
				DrawLine(g, x - 1, y, z, UIColors.LightLightLight, v);
				DrawLine(g, x + 1, y, z, UIColors.LightLightLight, v);
			}
			else
			{
				DrawLine(g, x, y - 1, z, UIColors.LightLightLight, v);
				DrawLine(g, x, y + 1, z, UIColors.LightLightLight, v);
			}
		}


		/// <summary>
		/// 绘制图片
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bmp"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		static public void DrawBitmap(Graphics g, Bitmap bmp, int x, int y)
		{
			g.DrawImage(bmp, new Rectangle(x, y, bmp.Width, bmp.Height));
		}

		/// <summary>
		/// 绘制下拉箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawDropDownArrow(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.DropDownArrow, x, y);
		}

		/// <summary>
		/// 绘制自定义箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawCustomArrow(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.CustomArrow, x, y);
		}

		/// <summary>
		/// 绘制更多内容箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawMoreArrow(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.MoreArrow, x, y);
		}

		/// <summary>
		/// 绘制上箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawArrowUp(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.ArrowUp, x, y);
		}

		/// <summary>
		/// 绘制下箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawArrowDown(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.ArrowDown, x, y);
		}

		/// <summary>
		/// 绘制左箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawArrowLeft(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.ArrowLeft, x, y);
		}

		/// <summary>
		/// 绘制右箭头
		/// </summary>
		/// <param name="g">图形区</param>
		/// <param name="x">横坐标</param>
		/// <param name="y">纵坐标</param>
		static public void DrawArrowRight(Graphics g, int x, int y)
		{
			DrawBitmap(g, UIResources.ArrowRight, x, y);
		}
		#endregion


		/// <summary>
		/// 默认字体
		/// </summary>
		static public Font DefaultFont { get; set; }
	}
}
