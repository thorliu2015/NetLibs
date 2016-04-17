/*
 * ThorPens
 * liuqiang@2015/11/7 12:08:15
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
	public class ThorPens
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

		//static public Pen ControlLightLight { get { return new Pen(ThorBrushs.ControlLightLight); } }
		
		

		/// <summary>
		/// 通用控件最暗色部分的颜色
		/// </summary>
		static public Pen ControlDarkDarkDark { get { return new Pen(ThorBrushs.ControlDarkDarkDark); } }


		/// <summary>
		/// 通用控件暗色部分的颜色
		/// </summary>
		static public Pen ControlDarkDark { get { return new Pen(ThorBrushs.ControlDarkDark); } }


		/// <summary>
		/// 通用控件浅暗色部分的颜色
		/// </summary>
		static public Pen ControlDark { get { return new Pen(ThorBrushs.ControlDark); } }


		/// <summary>
		/// 通用控件的颜色
		/// </summary>
		static public Pen Control { get { return new Pen(ThorBrushs.Control); } }


		/// <summary>
		/// 通用控件的浅亮色部分的颜色
		/// </summary>
		static public Pen ControlLight { get { return new Pen(ThorBrushs.ControlLight); } }


		/// <summary>
		/// 通用控件的高亮色部分的颜色
		/// </summary>
		static public Pen ControlLightLight { get { return new Pen(ThorBrushs.ControlLightLight); } }


		/// <summary>
		/// 通用控件的最高亮色部分的颜色
		/// </summary>
		static public Pen ControlLightLightLight { get { return new Pen(ThorBrushs.ControlLightLightLight); } }


		/// <summary>
		/// 通用控件的文本颜色
		/// </summary>
		static public Pen ControlText { get { return new Pen(ThorBrushs.ControlText); } }


		/// <summary>
		/// 通用控件的灰色文本颜色
		/// </summary>
		static public Pen GrayText { get { return new Pen(ThorBrushs.GrayText); } }


		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public Pen Window { get { return new Pen(ThorBrushs.Window); } }


		/// <summary>
		/// 窗体框架颜色
		/// </summary>
		static public Pen WindowFrame { get { return new Pen(ThorBrushs.WindowFrame); } }


		/// <summary>
		/// 窗体标准文本颜色
		/// </summary>
		static public Pen WindowText { get { return new Pen(ThorBrushs.WindowText); } }


		/// <summary>
		/// 窗体标准文本的阴影颜色
		/// </summary>
		static public Pen WindowTextShadow { get { return new Pen(ThorBrushs.WindowTextShadow); } }


		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public Pen WindowBackground { get { return new Pen(ThorBrushs.WindowBackground); } }


		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public Pen WindowButtonHover { get { return new Pen(ThorBrushs.WindowButtonHover); } }


		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public Pen WindowButtonPressed { get { return new Pen(ThorBrushs.WindowButtonPressed); } }


		/// <summary>
		/// 窗口边框颜色
		/// </summary>
		static public Pen WindowBorder { get { return new Pen(ThorBrushs.WindowBorder); } }


		/// <summary>
		/// 高亮区域背景颜色
		/// </summary>
		static public Pen HighLight { get { return new Pen(ThorBrushs.HighLight); } }


		/// <summary>
		/// 高亮区域文本颜色
		/// </summary>
		static public Pen HighLightText { get { return new Pen(ThorBrushs.HighLightText); } }


		/// <summary>
		/// 焦点颜色
		/// </summary>
		static public Pen Focus { get { return new Pen(ThorBrushs.Focus); } }


		/// <summary>
		/// 面板边框颜色
		/// </summary>
		static public Pen PanelBorder { get { return new Pen(ThorBrushs.PanelBorder); } }


		/// <summary>
		/// 带区句柄颜色
		/// </summary>
		static public Pen BandDot { get { return new Pen(ThorBrushs.BandDot); } }


		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public Pen SplitterForeground { get { return new Pen(ThorBrushs.SplitterForeground); } }


		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public Pen SplitterBackground { get { return new Pen(ThorBrushs.SplitterBackground); } }


		/// <summary>
		/// 滚动条背景颜色
		/// </summary>
		static public Pen ScrollBarBackground { get { return new Pen(ThorBrushs.ScrollBarBackground); } }


		/// <summary>
		/// 滚动条前景颜色
		/// </summary>
		static public Pen ScrollBarForeground { get { return new Pen(ThorBrushs.ScrollBarForeground); } }


		/// <summary>
		/// 滚动条前景指向时颜色
		/// </summary>
		static public Pen ScrollBarForegroundHover { get { return new Pen(ThorBrushs.ScrollBarForegroundHover); } }


		/// <summary>
		/// 滚动条前景按下时颜色
		/// </summary>
		static public Pen ScrollBarForegroundPressed { get { return new Pen(ThorBrushs.ScrollBarForegroundPressed); } }


		/// <summary>
		/// 菜单背景颜色
		/// </summary>
		static public Pen MenuBackground { get { return new Pen(ThorBrushs.MenuBackground); } }


		/// <summary>
		/// 网格固定行背景颜色
		/// </summary>
		static public Pen GridFixedRowBackground { get { return new Pen(ThorBrushs.GridFixedRowBackground); } }


		/// <summary>
		/// 网格固定行前景颜色
		/// </summary>
		static public Pen GridFixedRowForeground { get { return new Pen(ThorBrushs.GridFixedRowForeground); } }


		/// <summary>
		/// 网格固定行线条颜色
		/// </summary>
		static public Pen GridFixedRowGrid { get { return new Pen(ThorBrushs.GridFixedRowGrid); } }


		/// <summary>
		/// 网格固定行聚焦背景颜色
		/// </summary>
		static public Pen GridFixedRowFocusBackground { get { return new Pen(ThorBrushs.GridFixedRowFocusBackground); } }


		/// <summary>
		/// 网格固定列背景颜色
		/// </summary>
		static public Pen GridFixedColumnBackground { get { return new Pen(ThorBrushs.GridFixedColumnBackground); } }


		/// <summary>
		/// 网格固定列前景颜色
		/// </summary>
		static public Pen GridFixedColumnForeground { get { return new Pen(ThorBrushs.GridFixedColumnForeground); } }


		/// <summary>
		/// 网格固定列线条颜色
		/// </summary>
		static public Pen GridFixedColumnGrid { get { return new Pen(ThorBrushs.GridFixedColumnGrid); } }


		/// <summary>
		/// 网格固定列聚焦背景颜色
		/// </summary>
		static public Pen GridFixedColumnFocusBackground { get { return new Pen(ThorBrushs.GridFixedColumnFocusBackground); } }


		/// <summary>
		/// 网格分组单元背景颜色
		/// </summary>
		static public Pen GridGroupBackground { get { return new Pen(ThorBrushs.GridGroupBackground); } }


		/// <summary>
		/// 网格分组单元前景颜色
		/// </summary>
		static public Pen GridGroupForeground { get { return new Pen(ThorBrushs.GridGroupForeground); } }


		/// <summary>
		/// 网格分组单位线条颜色
		/// </summary>
		static public Pen GridGroupGrid { get { return new Pen(ThorBrushs.GridGroupGrid); } }


		/// <summary>
		/// 网格分组单元的折叠边框颜色
		/// </summary>
		static public Pen GridGroupFoldBorder { get { return new Pen(ThorBrushs.GridGroupFoldBorder); } }


		/// <summary>
		/// 网格分组单元的折叠前景颜色
		/// </summary>
		static public Pen GridGroupFoldFore { get { return new Pen(ThorBrushs.GridGroupFoldFore); } }


		/// <summary>
		/// 网格默认单元的背景颜色
		/// </summary>
		static public Pen GridNormalBackground { get { return new Pen(ThorBrushs.GridNormalBackground); } }


		/// <summary>
		/// 网格默认单元的前景颜色
		/// </summary>
		static public Pen GridNormalForeground { get { return new Pen(ThorBrushs.GridNormalForeground); } }


		/// <summary>
		/// 网格默认单元的线条颜色
		/// </summary>
		static public Pen GridNormalGrid { get { return new Pen(ThorBrushs.GridNormalGrid); } }


		/// <summary>
		/// 网格聚焦单元的背景颜色
		/// </summary>
		static public Pen GridFocusBackground { get { return new Pen(ThorBrushs.GridFocusBackground); } }


		/// <summary>
		/// 网格聚焦单元的前景颜色
		/// </summary>
		static public Pen GridFocusForeground { get { return new Pen(ThorBrushs.GridFocusForeground); } }


		/// <summary>
		/// 网格聚焦单元的线条颜色
		/// </summary>
		static public Pen GridFocusGrid { get { return new Pen(ThorBrushs.GridFocusGrid); } }


		/// <summary>
		/// 图片透明色1
		/// </summary>
		static public Pen ImageViewAlpha1 { get { return new Pen(ThorBrushs.ImageViewAlpha1); } }


		/// <summary>
		/// 图片透明色2
		/// </summary>
		static public Pen ImageViewAlpha2 { get { return new Pen(ThorBrushs.ImageViewAlpha2); } }


		#endregion

		#region events

		#endregion
	}
}
