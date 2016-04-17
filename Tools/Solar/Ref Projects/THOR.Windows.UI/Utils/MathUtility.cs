using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.Windows.UI.Utils
{
	public class DoublePoint
	{
		public DoublePoint()
		{
		}

		public DoublePoint(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X { get; set; }
		public double Y { get; set; }
	}


	public class MathUtility
	{
		/// <summary>
		/// 计算两点的距离
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		static public double GetDistance(DoublePoint p1, DoublePoint p2)
		{
			double dx = Math.Abs(p1.X - p2.X);
			double dy = Math.Abs(p1.Y - p2.Y);

			return Math.Sqrt(dx * dx + dy * dy);
		}

		/// <summary>
		/// 计算两点的角度
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		static public double GetAngle(DoublePoint p1, DoublePoint p2, bool use360 = false)
		{
			double dx = p2.Y - p1.Y;
			double dy = p2.X - p1.X;

			double r = Math.Atan2(dy, dx) * (180 / Math.PI);

			if (use360)
			{
				r += 360;
				r %= 360;

				r = 360 - r + 90;
				r = r % 360;
			}

			return r;
		}

		/// <summary>
		/// 根据一个点,角度和长度计算最终的位置
		/// </summary>
		/// <param name="p"></param>
		/// <param name="angle"></param>
		/// <param name="distance"></param>
		/// <returns></returns>
		static public DoublePoint GetPosition(DoublePoint p, double angle, double distance)
		{

			double a = angle / (180 / Math.PI);
			double cx = distance * Math.Cos(a);
			double cy = distance * Math.Sin(a);

			return new DoublePoint(p.X + cx, p.Y + cy);
		}
	}
}
