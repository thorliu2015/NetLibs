using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Solar.Coordinates
{
	/// <summary>
	/// 坐标系统网格绘制接口
	/// </summary>
	public interface ICoordinateGridPainter
	{
		/// <summary>
		/// 获取或设置坐标系统
		/// </summary>
		ICoordinate Coordinate { get; set; }


		/// <summary>
		/// 获取或设置横向偏移坐标
		/// </summary>
		int OffsetX { get; set; }

		/// <summary>
		/// 获取或设置纵向偏移坐标
		/// </summary>
		int OffsetY { get; set; }

		/// <summary>
		/// 获取或设置网格行数
		/// </summary>
		int Rows { get; set; }

		/// <summary>
		/// 获取或设置网格列数
		/// </summary>
		int Columns { get; set; }

		/// <summary>
		/// 边框线颜色
		/// </summary>
		Color BorderColor { get; set; }

		/// <summary>
		/// 网格线颜色
		/// </summary>
		Color GridColor { get; set; }

		/// <summary>
		/// 5格线颜色
		/// </summary>
		Color Grid5Color { get; set; }

		/// <summary>
		/// 10格线颜色
		/// </summary>
		Color Grid10Color { get; set; }

	}
}
