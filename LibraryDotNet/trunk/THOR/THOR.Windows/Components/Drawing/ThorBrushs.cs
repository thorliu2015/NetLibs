/*
 * ThorBrushs
 * liuqiang@2015/11/7 12:08:03
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//---- 8< ------------------

namespace THOR.Windows.Components.Drawing
{
	public class ThorBrushs
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		#endregion

		#region properties

		//static public SolidBrush ControlLightLight { get { return new SolidBrush(ThorColors.ControlLightLight); } }
	
		

		/// <summary>
		/// 通用控件最暗色部分的颜色
		/// </summary>
		static public SolidBrush ControlDarkDarkDark { get { return new SolidBrush(ThorColors.ControlDarkDarkDark); } }


		/// <summary>
		/// 通用控件暗色部分的颜色
		/// </summary>
		static public SolidBrush ControlDarkDark { get { return new SolidBrush(ThorColors.ControlDarkDark); } }


		/// <summary>
		/// 通用控件浅暗色部分的颜色
		/// </summary>
		static public SolidBrush ControlDark { get { return new SolidBrush(ThorColors.ControlDark); } }


		/// <summary>
		/// 通用控件的颜色
		/// </summary>
		static public SolidBrush Control { get { return new SolidBrush(ThorColors.Control); } }


		/// <summary>
		/// 通用控件的浅亮色部分的颜色
		/// </summary>
		static public SolidBrush ControlLight { get { return new SolidBrush(ThorColors.ControlLight); } }


		/// <summary>
		/// 通用控件的高亮色部分的颜色
		/// </summary>
		static public SolidBrush ControlLightLight { get { return new SolidBrush(ThorColors.ControlLightLight); } }


		/// <summary>
		/// 通用控件的最高亮色部分的颜色
		/// </summary>
		static public SolidBrush ControlLightLightLight { get { return new SolidBrush(ThorColors.ControlLightLightLight); } }


		/// <summary>
		/// 通用控件的文本颜色
		/// </summary>
		static public SolidBrush ControlText { get { return new SolidBrush(ThorColors.ControlText); } }


		/// <summary>
		/// 通用控件的灰色文本颜色
		/// </summary>
		static public SolidBrush GrayText { get { return new SolidBrush(ThorColors.GrayText); } }


		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public SolidBrush Window { get { return new SolidBrush(ThorColors.Window); } }


		/// <summary>
		/// 窗体框架颜色
		/// </summary>
		static public SolidBrush WindowFrame { get { return new SolidBrush(ThorColors.WindowFrame); } }


		/// <summary>
		/// 窗体标准文本颜色
		/// </summary>
		static public SolidBrush WindowText { get { return new SolidBrush(ThorColors.WindowText); } }


		/// <summary>
		/// 窗体标准文本的阴影颜色
		/// </summary>
		static public SolidBrush WindowTextShadow { get { return new SolidBrush(ThorColors.WindowTextShadow); } }


		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public SolidBrush WindowBackground { get { return new SolidBrush(ThorColors.WindowBackground); } }


		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public SolidBrush WindowButtonHover { get { return new SolidBrush(ThorColors.WindowButtonHover); } }


		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public SolidBrush WindowButtonPressed { get { return new SolidBrush(ThorColors.WindowButtonPressed); } }


		/// <summary>
		/// 窗口边框颜色
		/// </summary>
		static public SolidBrush WindowBorder { get { return new SolidBrush(ThorColors.WindowBorder); } }


		/// <summary>
		/// 高亮区域背景颜色
		/// </summary>
		static public SolidBrush HighLight { get { return new SolidBrush(ThorColors.HighLight); } }


		/// <summary>
		/// 高亮区域文本颜色
		/// </summary>
		static public SolidBrush HighLightText { get { return new SolidBrush(ThorColors.HighLightText); } }


		/// <summary>
		/// 焦点颜色
		/// </summary>
		static public SolidBrush Focus { get { return new SolidBrush(ThorColors.Focus); } }


		/// <summary>
		/// 面板边框颜色
		/// </summary>
		static public SolidBrush PanelBorder { get { return new SolidBrush(ThorColors.PanelBorder); } }


		/// <summary>
		/// 带区句柄颜色
		/// </summary>
		static public SolidBrush BandDot { get { return new SolidBrush(ThorColors.BandDot); } }


		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public SolidBrush SplitterForeground { get { return new SolidBrush(ThorColors.SplitterForeground); } }


		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public SolidBrush SplitterBackground { get { return new SolidBrush(ThorColors.SplitterBackground); } }


		/// <summary>
		/// 滚动条背景颜色
		/// </summary>
		static public SolidBrush ScrollBarBackground { get { return new SolidBrush(ThorColors.ScrollBarBackground); } }


		/// <summary>
		/// 滚动条前景颜色
		/// </summary>
		static public SolidBrush ScrollBarForeground { get { return new SolidBrush(ThorColors.ScrollBarForeground); } }


		/// <summary>
		/// 滚动条前景指向时颜色
		/// </summary>
		static public SolidBrush ScrollBarForegroundHover { get { return new SolidBrush(ThorColors.ScrollBarForegroundHover); } }


		/// <summary>
		/// 滚动条前景按下时颜色
		/// </summary>
		static public SolidBrush ScrollBarForegroundPressed { get { return new SolidBrush(ThorColors.ScrollBarForegroundPressed); } }


		/// <summary>
		/// 菜单背景颜色
		/// </summary>
		static public SolidBrush MenuBackground { get { return new SolidBrush(ThorColors.MenuBackground); } }


		/// <summary>
		/// 网格固定行背景颜色
		/// </summary>
		static public SolidBrush GridFixedRowBackground { get { return new SolidBrush(ThorColors.GridFixedRowBackground); } }


		/// <summary>
		/// 网格固定行前景颜色
		/// </summary>
		static public SolidBrush GridFixedRowForeground { get { return new SolidBrush(ThorColors.GridFixedRowForeground); } }


		/// <summary>
		/// 网格固定行线条颜色
		/// </summary>
		static public SolidBrush GridFixedRowGrid { get { return new SolidBrush(ThorColors.GridFixedRowGrid); } }


		/// <summary>
		/// 网格固定行聚焦背景颜色
		/// </summary>
		static public SolidBrush GridFixedRowFocusBackground { get { return new SolidBrush(ThorColors.GridFixedRowFocusBackground); } }


		/// <summary>
		/// 网格固定列背景颜色
		/// </summary>
		static public SolidBrush GridFixedColumnBackground { get { return new SolidBrush(ThorColors.GridFixedColumnBackground); } }


		/// <summary>
		/// 网格固定列前景颜色
		/// </summary>
		static public SolidBrush GridFixedColumnForeground { get { return new SolidBrush(ThorColors.GridFixedColumnForeground); } }


		/// <summary>
		/// 网格固定列线条颜色
		/// </summary>
		static public SolidBrush GridFixedColumnGrid { get { return new SolidBrush(ThorColors.GridFixedColumnGrid); } }


		/// <summary>
		/// 网格固定列聚焦背景颜色
		/// </summary>
		static public SolidBrush GridFixedColumnFocusBackground { get { return new SolidBrush(ThorColors.GridFixedColumnFocusBackground); } }


		/// <summary>
		/// 网格分组单元背景颜色
		/// </summary>
		static public SolidBrush GridGroupBackground { get { return new SolidBrush(ThorColors.GridGroupBackground); } }


		/// <summary>
		/// 网格分组单元前景颜色
		/// </summary>
		static public SolidBrush GridGroupForeground { get { return new SolidBrush(ThorColors.GridGroupForeground); } }


		/// <summary>
		/// 网格分组单位线条颜色
		/// </summary>
		static public SolidBrush GridGroupGrid { get { return new SolidBrush(ThorColors.GridGroupGrid); } }


		/// <summary>
		/// 网格分组单元的折叠边框颜色
		/// </summary>
		static public SolidBrush GridGroupFoldBorder { get { return new SolidBrush(ThorColors.GridGroupFoldBorder); } }


		/// <summary>
		/// 网格分组单元的折叠前景颜色
		/// </summary>
		static public SolidBrush GridGroupFoldFore { get { return new SolidBrush(ThorColors.GridGroupFoldFore); } }


		/// <summary>
		/// 网格默认单元的背景颜色
		/// </summary>
		static public SolidBrush GridNormalBackground { get { return new SolidBrush(ThorColors.GridNormalBackground); } }


		/// <summary>
		/// 网格默认单元的前景颜色
		/// </summary>
		static public SolidBrush GridNormalForeground { get { return new SolidBrush(ThorColors.GridNormalForeground); } }


		/// <summary>
		/// 网格默认单元的线条颜色
		/// </summary>
		static public SolidBrush GridNormalGrid { get { return new SolidBrush(ThorColors.GridNormalGrid); } }


		/// <summary>
		/// 网格聚焦单元的背景颜色
		/// </summary>
		static public SolidBrush GridFocusBackground { get { return new SolidBrush(ThorColors.GridFocusBackground); } }


		/// <summary>
		/// 网格聚焦单元的前景颜色
		/// </summary>
		static public SolidBrush GridFocusForeground { get { return new SolidBrush(ThorColors.GridFocusForeground); } }


		/// <summary>
		/// 网格聚焦单元的线条颜色
		/// </summary>
		static public SolidBrush GridFocusGrid { get { return new SolidBrush(ThorColors.GridFocusGrid); } }


		/// <summary>
		/// 图片透明色1
		/// </summary>
		static public SolidBrush ImageViewAlpha1 { get { return new SolidBrush(ThorColors.ImageViewAlpha1); } }


		/// <summary>
		/// 图片透明色2
		/// </summary>
		static public SolidBrush ImageViewAlpha2 { get { return new SolidBrush(ThorColors.ImageViewAlpha2); } }


		#endregion

		#region events

		#endregion
	}
}
