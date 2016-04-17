using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THOR.D2D.Core
{
	/// <summary>
	/// Direct2D 画布区域
	/// </summary>
	public class D2DCanvasRegion
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="controller"></param>
		public D2DCanvasRegion(D2DController controller)
		{
			Controller = controller;
		}


		/// <summary>
		/// 获取Direct2D控制器
		/// </summary>
		public D2DController Controller { get; protected set; }

		/// <summary>
		/// 获取视角宽度
		/// </summary>
		public int ViewPortWidth
		{
			get
			{
				return Controller.Target.Width;
			}
		}

		/// <summary>
		/// 获取视角高度
		/// </summary>
		public int ViewPortHeight
		{
			get
			{
				return Controller.Target.Height;
			}
		}

		/// <summary>
		/// 获取或设置视角偏移横坐标
		/// </summary>
		public int X
		{
			get
			{
				return Controller.Target.AutoScrollPosition.X;
			}
			set
			{
				int nx = value;
				int ny = Controller.Target.AutoScrollPosition.Y;
				Controller.Target.AutoScrollPosition = new System.Drawing.Point(nx, ny);
			}

		}

		/// <summary>
		/// 获取或设置视角偏移纵坐标
		/// </summary>
		public int Y
		{
			get
			{
				return Controller.Target.AutoScrollPosition.Y;
			}
			set
			{
				int nx = Controller.Target.AutoScrollPosition.X;
				int ny = value;

				Controller.Target.AutoScrollPosition = new System.Drawing.Point(nx, ny);
			}
		}

		/// <summary>
		/// 获取或设置内容宽度
		/// </summary>
		public int Width
		{
			get
			{
				return Controller.Target.AutoScrollMinSize.Width;
			}
			set
			{
				int nw = value;
				int nh = Controller.Target.AutoScrollMinSize.Height;

				Controller.Target.AutoScrollMinSize = new System.Drawing.Size(nw, nh);
			}
		}

		/// <summary>
		/// 获取或设置内容高度
		/// </summary>
		public int Height
		{
			get
			{
				return Controller.Target.AutoScrollMinSize.Height;
			}
			set
			{
				int nw = Controller.Target.AutoScrollMinSize.Width;
				int nh = value;

				Controller.Target.AutoScrollMinSize = new System.Drawing.Size(nw, nh);
			}

		}
	}
}
