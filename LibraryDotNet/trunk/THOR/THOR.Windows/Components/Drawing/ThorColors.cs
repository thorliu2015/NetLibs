/*
 * ThorColors
 * liuqiang@2015/11/7 11:11:58
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THOR.Windows.Dialogs;


//---- 8< ------------------

namespace THOR.Windows.Components.Drawing
{
	public class ThorColors
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		#endregion

		#region methods

		/// <summary>
		/// 获取控件的主题颜色
		/// </summary>
		/// <param name="control"></param>
		/// <returns></returns>
		static public Color GetThemeColor(Control control)
		{
			return GetThemeColor(control, Focus);
		}

		/// <summary>
		/// 获取控件的主题颜色
		/// </summary>
		/// <param name="control"></param>
		/// <param name="defaultColor"></param>
		/// <returns></returns>
		static public Color GetThemeColor(Control control, Color defaultColor)
		{
			if (control is FlatForm)
			{
				FlatForm ff = (FlatForm)control;
				if (ff.ThemeColor != Color.Transparent)
				{
					return ff.ThemeColor;
				}
			}
			else
			{
				Form f = control.FindForm();
				if (f is FlatForm)
				{
					FlatForm ff = (FlatForm)f;
					if (ff.ThemeColor != Color.Transparent)
					{
						return ff.ThemeColor;
					}
				}
			}

			return defaultColor;
		}

		#endregion

		#region properties

		//static public Color ControlLightLight { get { return ThorComponentTheme.Current.ControlLightLightColor; } }
		
		
		/// <summary>
		/// 通用控件最暗色部分的颜色
		/// </summary>
		static public Color ControlDarkDarkDark { get { return ThorComponentTheme.Current.ControlDarkDarkDark; } }

		/// <summary>
		/// 通用控件暗色部分的颜色
		/// </summary>
		static public Color ControlDarkDark { get { return ThorComponentTheme.Current.ControlDarkDark; } }

		/// <summary>
		/// 通用控件浅暗色部分的颜色
		/// </summary>
		static public Color ControlDark { get { return ThorComponentTheme.Current.ControlDark; } }

		/// <summary>
		/// 通用控件的颜色
		/// </summary>
		static public Color Control { get { return ThorComponentTheme.Current.Control; } }

		/// <summary>
		/// 通用控件的浅亮色部分的颜色
		/// </summary>
		static public Color ControlLight { get { return ThorComponentTheme.Current.ControlLight; } }

		/// <summary>
		/// 通用控件的高亮色部分的颜色
		/// </summary>
		static public Color ControlLightLight { get { return ThorComponentTheme.Current.ControlLightLight; } }

		/// <summary>
		/// 通用控件的最高亮色部分的颜色
		/// </summary>
		static public Color ControlLightLightLight { get { return ThorComponentTheme.Current.ControlLightLightLight; } }

		/// <summary>
		/// 通用控件的文本颜色
		/// </summary>
		static public Color ControlText { get { return ThorComponentTheme.Current.ControlText; } }

		/// <summary>
		/// 通用控件的灰色文本颜色
		/// </summary>
		static public Color GrayText { get { return ThorComponentTheme.Current.GrayText; } }

		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public Color Window { get { return ThorComponentTheme.Current.Window; } }

		/// <summary>
		/// 窗体框架颜色
		/// </summary>
		static public Color WindowFrame { get { return ThorComponentTheme.Current.WindowFrame; } }

		/// <summary>
		/// 窗体标准文本颜色
		/// </summary>
		static public Color WindowText { get { return ThorComponentTheme.Current.WindowText; } }

		/// <summary>
		/// 窗体标准文本的阴影颜色
		/// </summary>
		static public Color WindowTextShadow { get { return ThorComponentTheme.Current.WindowTextShadow; } }

		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		static public Color WindowBackground { get { return ThorComponentTheme.Current.WindowBackground; } }

		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public Color WindowButtonHover { get { return ThorComponentTheme.Current.WindowButtonHover; } }

		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		static public Color WindowButtonPressed { get { return ThorComponentTheme.Current.WindowButtonPressed; } }

		/// <summary>
		/// 窗口边框颜色
		/// </summary>
		static public Color WindowBorder { get { return ThorComponentTheme.Current.WindowBorder; } }

		/// <summary>
		/// 高亮区域背景颜色
		/// </summary>
		static public Color HighLight { get { return ThorComponentTheme.Current.HighLight; } }

		/// <summary>
		/// 高亮区域文本颜色
		/// </summary>
		static public Color HighLightText { get { return ThorComponentTheme.Current.HighLightText; } }

		/// <summary>
		/// 焦点颜色
		/// </summary>
		static public Color Focus { get { return ThorComponentTheme.Current.Focus; } }

		/// <summary>
		/// 面板边框颜色
		/// </summary>
		static public Color PanelBorder { get { return ThorComponentTheme.Current.PanelBorder; } }

		/// <summary>
		/// 带区句柄颜色
		/// </summary>
		static public Color BandDot { get { return ThorComponentTheme.Current.BandDot; } }

		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public Color SplitterForeground { get { return ThorComponentTheme.Current.SplitterForeground; } }

		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		static public Color SplitterBackground { get { return ThorComponentTheme.Current.SplitterBackground; } }

		/// <summary>
		/// 滚动条背景颜色
		/// </summary>
		static public Color ScrollBarBackground { get { return ThorComponentTheme.Current.ScrollBarBackground; } }

		/// <summary>
		/// 滚动条前景颜色
		/// </summary>
		static public Color ScrollBarForeground { get { return ThorComponentTheme.Current.ScrollBarForeground; } }

		/// <summary>
		/// 滚动条前景指向时颜色
		/// </summary>
		static public Color ScrollBarForegroundHover { get { return ThorComponentTheme.Current.ScrollBarForegroundHover; } }

		/// <summary>
		/// 滚动条前景按下时颜色
		/// </summary>
		static public Color ScrollBarForegroundPressed { get { return ThorComponentTheme.Current.ScrollBarForegroundPressed; } }

		/// <summary>
		/// 菜单背景颜色
		/// </summary>
		static public Color MenuBackground { get { return ThorComponentTheme.Current.MenuBackground; } }

		/// <summary>
		/// 网格固定行背景颜色
		/// </summary>
		static public Color GridFixedRowBackground { get { return ThorComponentTheme.Current.GridFixedRowBackground; } }

		/// <summary>
		/// 网格固定行前景颜色
		/// </summary>
		static public Color GridFixedRowForeground { get { return ThorComponentTheme.Current.GridFixedRowForeground; } }

		/// <summary>
		/// 网格固定行线条颜色
		/// </summary>
		static public Color GridFixedRowGrid { get { return ThorComponentTheme.Current.GridFixedRowGrid; } }

		/// <summary>
		/// 网格固定行聚焦背景颜色
		/// </summary>
		static public Color GridFixedRowFocusBackground { get { return ThorComponentTheme.Current.GridFixedRowFocusBackground; } }

		/// <summary>
		/// 网格固定列背景颜色
		/// </summary>
		static public Color GridFixedColumnBackground { get { return ThorComponentTheme.Current.GridFixedColumnBackground; } }

		/// <summary>
		/// 网格固定列前景颜色
		/// </summary>
		static public Color GridFixedColumnForeground { get { return ThorComponentTheme.Current.GridFixedColumnForeground; } }

		/// <summary>
		/// 网格固定列线条颜色
		/// </summary>
		static public Color GridFixedColumnGrid { get { return ThorComponentTheme.Current.GridFixedColumnGrid; } }

		/// <summary>
		/// 网格固定列聚焦背景颜色
		/// </summary>
		static public Color GridFixedColumnFocusBackground { get { return ThorComponentTheme.Current.GridFixedColumnFocusBackground; } }

		/// <summary>
		/// 网格分组单元背景颜色
		/// </summary>
		static public Color GridGroupBackground { get { return ThorComponentTheme.Current.GridGroupBackground; } }

		/// <summary>
		/// 网格分组单元前景颜色
		/// </summary>
		static public Color GridGroupForeground { get { return ThorComponentTheme.Current.GridGroupForeground; } }

		/// <summary>
		/// 网格分组单位线条颜色
		/// </summary>
		static public Color GridGroupGrid { get { return ThorComponentTheme.Current.GridGroupGrid; } }

		/// <summary>
		/// 网格分组单元的折叠边框颜色
		/// </summary>
		static public Color GridGroupFoldBorder { get { return ThorComponentTheme.Current.GridGroupFoldBorder; } }

		/// <summary>
		/// 网格分组单元的折叠前景颜色
		/// </summary>
		static public Color GridGroupFoldFore { get { return ThorComponentTheme.Current.GridGroupFoldFore; } }

		/// <summary>
		/// 网格默认单元的背景颜色
		/// </summary>
		static public Color GridNormalBackground { get { return ThorComponentTheme.Current.GridNormalBackground; } }

		/// <summary>
		/// 网格默认单元的前景颜色
		/// </summary>
		static public Color GridNormalForeground { get { return ThorComponentTheme.Current.GridNormalForeground; } }

		/// <summary>
		/// 网格默认单元的线条颜色
		/// </summary>
		static public Color GridNormalGrid { get { return ThorComponentTheme.Current.GridNormalGrid; } }

		/// <summary>
		/// 网格聚焦单元的背景颜色
		/// </summary>
		static public Color GridFocusBackground { get { return ThorComponentTheme.Current.GridFocusBackground; } }

		/// <summary>
		/// 网格聚焦单元的前景颜色
		/// </summary>
		static public Color GridFocusForeground { get { return ThorComponentTheme.Current.GridFocusForeground; } }

		/// <summary>
		/// 网格聚焦单元的线条颜色
		/// </summary>
		static public Color GridFocusGrid { get { return ThorComponentTheme.Current.GridFocusGrid; } }

		/// <summary>
		/// 图片透明色1
		/// </summary>
		static public Color ImageViewAlpha1 { get { return ThorComponentTheme.Current.ImageViewAlpha1; } }

		/// <summary>
		/// 图片透明色2
		/// </summary>
		static public Color ImageViewAlpha2 { get { return ThorComponentTheme.Current.ImageViewAlpha2; } }


		#endregion

		#region events

		#endregion
	}
}
