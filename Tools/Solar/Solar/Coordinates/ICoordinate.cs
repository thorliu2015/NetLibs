using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Coordinates
{
	/// <summary>
	/// 游戏坐标系统接口
	/// </summary>
	public interface ICoordinate
	{
		/// <summary>
		/// 根据屏幕坐标获取逻辑坐标
		/// </summary>
		/// <param name="screenPosition"></param>
		/// <returns></returns>
		Point ScreenToLogic(Point screenPosition);

		/// <summary>
		/// 根据逻辑坐标获取屏幕坐标
		/// </summary>
		/// <param name="logicPosition"></param>
		/// <returns></returns>
		Point LogicToScreen(Point logicPosition);




		/// <summary>
		/// 根据屏幕坐标获取网格坐标
		/// </summary>
		/// <param name="screenPosition"></param>
		/// <returns></returns>
		Point ScreenToGrid(Point screenPosition);

		/// <summary>
		/// 根据网格坐标获取屏幕坐标
		/// </summary>
		/// <param name="gridPosition"></param>
		/// <returns></returns>
		Point GridToScreen(Point gridPosition);



		/// <summary>
		/// 获取网格点坐标(用于绘制网格线)
		/// </summary>
		void GetGridPoints(int rows, int cols,
			List<int> x1Points,
			List<int> x2Points,
			List<int> x3Points,
			List<int> x4Points,

			List<int> y1Points,
			List<int> y2Points,
			List<int> y3Points,
			List<int> y4Points);



		/// <summary>
		/// 获取或设置网格尺寸
		/// </summary>
		Size GridSize { get; set; }
	}
}
