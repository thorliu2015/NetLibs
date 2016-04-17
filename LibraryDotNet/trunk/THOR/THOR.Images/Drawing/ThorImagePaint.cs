/*
 * ThorImagePaint
 * liuqiang@2015/12/1 21:59:12
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Images.Drawing
{
	/// <summary>
	/// 图片绘制方法
	/// </summary>
	public class ThorImagePaint
	{
		/// <summary>
		/// 获取透明背景图形(双色交错网格)的笔刷
		/// </summary>
		/// <param name="color1"></param>
		/// <param name="color2"></param>
		/// <returns></returns>
		static private HatchBrush GetAlphaBrush(Color color1, Color color2)
		{
			HatchBrush brush = new HatchBrush(HatchStyle.LargeCheckerBoard, color1, color2);
			return brush;
		}

		/// <summary>
		/// 绘制透明背景图形(双色交错网格)
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		static public void DrawAlpha(Graphics g, Rectangle rect)
		{
			DrawAlpha(g, rect, Color.FromArgb(0xFF, Color.White), Color.FromArgb(0xFF, 0xF0, 0xF0, 0xF0));
		}

		/// <summary>
		/// 绘制透明背景图形(双色交错网格)
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="color1"></param>
		/// <param name="color2"></param>
		static public void DrawAlpha(Graphics g, Rectangle rect, Color color1, Color color2)
		{
			HatchBrush brush = GetAlphaBrush(color1, color2);

			g.FillRectangle(brush, rect);
		}

		/// <summary>
		/// 绘制图片到指定位置
		/// </summary>
		/// <param name="g"></param>
		/// <param name="image"></param>
		/// <param name="rectSrc"></param>
		/// <param name="targetPosition"></param>
		static public void DrawImage(Graphics g, Image image, Rectangle rectSrc, Point targetPosition)
		{
			Rectangle rectDst = new Rectangle();
			rectDst.X = targetPosition.X;
			rectDst.Y = targetPosition.Y;
			rectDst.Width = rectSrc.Width;
			rectDst.Height = rectSrc.Height;

			g.DrawImage(image, rectDst, rectSrc, GraphicsUnit.Pixel);
		}


		/// <summary>
		/// 绘制图片到指定位置
		/// </summary>
		/// <param name="g"></param>
		/// <param name="image"></param>
		/// <param name="targetPosition"></param>
		static public void DrawImage(Graphics g, Image image, Point targetPosition)
		{
			Rectangle rectSrc = new Rectangle();
			rectSrc.X = 0;
			rectSrc.Y = 0;
			rectSrc.Width = image.Width;
			rectSrc.Height = image.Height;

			DrawImage(g, image, rectSrc, targetPosition);
		}


	}
}
