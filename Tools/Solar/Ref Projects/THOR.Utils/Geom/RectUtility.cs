using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace THOR.Utils.Geom
{
	public class RectUtility
	{
		/// <summary>
		/// 获取两个长度的相对比例
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		static public double GetRate(int a, int b)
		{
			double result = Convert.ToDouble(a) / Convert.ToDouble(b);

			return result;
		}


		/// <summary>
		/// 限定为最小尺寸
		/// </summary>
		/// <param name="minSize"></param>
		/// <param name="contentSize"></param>
		/// <returns></returns>
		static public Size LimitMinSize(Size minSize, Size contentSize)
		{
			Size result = new Size();

			double h = GetRate(contentSize.Width, minSize.Width);
			double v = GetRate(contentSize.Height, minSize.Height);

			double r = 1;

			if (h < 1 || v < 1)
			{
				if (h < v)
				{
					r = GetRate(minSize.Width, contentSize.Width);
				}
				else
				{
					r = GetRate(minSize.Height, contentSize.Height);
				}
			}

			result.Width = Convert.ToInt32(contentSize.Width * r);
			result.Height = Convert.ToInt32(contentSize.Height * r);

			return result;
		}


		/// <summary>
		/// 限定为最大尺寸
		/// </summary>
		/// <param name="maxSize"></param>
		/// <param name="contentSize"></param>
		/// <returns></returns>
		static public Size LimitMaxSize(Size maxSize, Size contentSize)
		{
			Size result = new Size();

			double h = GetRate(contentSize.Width, maxSize.Width);
			double v = GetRate(contentSize.Height, maxSize.Height);

			double r = 1;

			if (h > 1 || v > 1)
			{
				if (h > v)
				{
					r = GetRate(maxSize.Width, contentSize.Width);
				}
				else
				{
					r = GetRate(maxSize.Height, contentSize.Height);
				}
			}

			result.Width = Convert.ToInt32(contentSize.Width * r);
			result.Height = Convert.ToInt32(contentSize.Height * r);

			return result;
		}

		/// <summary>
		/// 限定为目标尺寸
		/// </summary>
		/// <param name="targetSize"></param>
		/// <param name="contentSize"></param>
		/// <returns></returns>
		static public Size LimitAutoSize(Size targetSize, Size contentSize)
		{
			Size result = new Size();


			double h = GetRate(contentSize.Width, targetSize.Width);
			double v = GetRate(contentSize.Height, targetSize.Height);

			double r = Math.Min(h, v);

			result.Width = Convert.ToInt32(contentSize.Width * r);
			result.Height = Convert.ToInt32(contentSize.Height * r);

			return result;
		}

		/// <summary>
		/// 获取居中坐标
		/// </summary>
		/// <param name="viewSize">视图尺寸</param>
		/// <param name="contentSize">内容尺寸</param>
		/// <returns></returns>
		static public Point CenterBySize(Size viewSize, Size contentSize)
		{
			Point result = new Point();

			result.X = (viewSize.Width - contentSize.Width) >> 1;
			result.Y = (viewSize.Height - contentSize.Height) >> 1;

			return result;
		}

		/// <summary>
		/// 获取居中坐标
		/// </summary>
		/// <param name="viewSize"></param>
		/// <param name="contentSize"></param>
		/// <param name="margin"></param>
		/// <returns></returns>
		static public Point CenterBySize(Size viewSize, Size contentSize, Padding margin)
		{

			Rectangle v = new Rectangle(0, 0, viewSize.Width, viewSize.Height);
			v = GetRectByPadding(v, margin, true);

			Point result = CenterBySize(v.Size, contentSize);

			return result;
		}

		/// <summary>
		/// 获取居中坐标
		/// </summary>
		/// <param name="viewSize"></param>
		/// <param name="contentSize"></param>
		/// <param name="margin"></param>
		/// <param name="padding"></param>
		/// <returns></returns>
		static public Point CenterBySize(Size viewSize, Size contentSize, Padding margin, Padding padding)
		{
			Rectangle v = new Rectangle(0, 0, viewSize.Width, viewSize.Height);
			v = GetRectByPadding(v, margin, true);

			Rectangle c = new Rectangle(0, 0, contentSize.Width, contentSize.Height);
			c = GetRectByPadding(v, padding, false);

			Point result = CenterBySize(v.Size, c.Size);

			return result;
		}



		static public Rectangle GetRectByOffset(Rectangle rect, Point offset)
		{
			Rectangle result = new Rectangle();

			result.X = rect.X + offset.X;
			result.Y = rect.Y + offset.Y;
			result.Width = rect.Width;
			result.Height = rect.Height;

			return result;
		}


		static public Rectangle GetRectByPadding(Rectangle rect, Padding padding, bool inner)
		{
			Rectangle result = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			if (inner)
			{
				rect.X += padding.Left;
				rect.Y += padding.Top;
				rect.Width -= padding.Left + padding.Right;
				rect.Height -= padding.Top + padding.Bottom;
			}
			else
			{
				rect.X -= padding.Left;
				rect.Y -= padding.Top;
				rect.Width += padding.Left + padding.Right;
				rect.Height += padding.Top + padding.Bottom;
			}

			return result;
		}

		static public Rectangle GetExpandRect(Rectangle rect, int offset)
		{
			Rectangle result = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

			result.X += offset;
			result.Y += offset;
			result.Width -= offset * 2;
			result.Height -= offset * 2;

			return result;
		}
	}
}
