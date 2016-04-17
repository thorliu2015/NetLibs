/*
 * Structs
 * liuqiang@2016/1/22 14:28:10
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Editors.UI.Frameworks.Core.Params
{
	#region enums

	/// <summary>
	/// 表示距离的单位
	/// </summary>
	public enum DistanceUnits
	{
		/// <summary>
		/// 像素
		/// </summary>
		Pixels,
		/// <summary>
		/// 百分比
		/// </summary>
		Percent
	}

	/// <summary>
	/// 表示横向对齐方式
	/// </summary>
	public enum HorizontalAlignment
	{
		/// <summary>
		/// 左对齐
		/// </summary>
		Left,
		/// <summary>
		/// 居中对齐
		/// </summary>
		Center,
		/// <summary>
		/// 右对齐
		/// </summary>
		Right
	}

	/// <summary>
	/// 表示纵向对齐方式
	/// </summary>
	public enum VerticalAlignment
	{
		/// <summary>
		/// 顶部对齐
		/// </summary>
		Top,
		/// <summary>
		/// 居中对齐
		/// </summary>
		Middle,
		/// <summary>
		/// 底部对齐
		/// </summary>
		Bottom
	}
	
	#endregion

	#region structs

	/// <summary>
	/// 表示距离
	/// </summary>
	public struct Distance
	{
		public double Amount;
		public DistanceUnits Unit;
	}

	/// <summary>
	/// 表示位置
	/// </summary>
	public struct Point
	{
		public Distance X;
		public Distance Y;
	}

	/// <summary>
	/// 表示尺寸
	/// </summary>
	public struct Size
	{
		public Distance Width;
		public Distance Height;
	}

	/// <summary>
	/// 表示区域
	/// </summary>
	public struct Rectangle
	{
		public Point Location;
		public Size Size;
	}

	/// <summary>
	/// 表示边距
	/// </summary>
	public struct Padding
	{
		public Distance Top;
		public Distance Bottom;
		public Distance Left;
		public Distance Right;
	}

	#endregion
}
