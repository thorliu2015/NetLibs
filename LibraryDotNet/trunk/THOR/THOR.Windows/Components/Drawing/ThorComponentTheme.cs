
/*
 * ThorComponentTheme
 * liuqiang@2015/11/7 11:05:26
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
	public enum ThorComponentThemes
	{
		Dark,
		Light
	}

	/// <summary>
	/// 界面控件主题
	/// </summary>
	public class ThorComponentTheme
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		static public ThorComponentTheme Current { get; set; }
		static ThorComponentTheme()
		{
			Current = Dark();
			//Current = Light();
		}

		public ThorComponentTheme()
		{
			Theme = ThorComponentThemes.Light;
		}

		#endregion

		#region methods

		static public Color GetColor(string htmlColor)
		{
			return ColorTranslator.FromHtml(htmlColor);
		}

		/// <summary>
		/// 黑色主题
		/// </summary>
		/// <returns></returns>
		static public ThorComponentTheme Dark()
		{
			ThorComponentTheme theme = new ThorComponentTheme();
			theme.Theme = ThorComponentThemes.Dark;

			//theme.ControlLightLightColor = GetColor("#444444");

			
			theme.ControlDarkDarkDark = GetColor("#000000");

			theme.ControlDarkDark = GetColor("#111111");

			theme.ControlDark = GetColor("#222222");

			theme.Control = GetColor("#333333");

			theme.ControlLight = GetColor("#444444");

			theme.ControlLightLight = GetColor("#555555");

			theme.ControlLightLightLight = GetColor("#666666");

			theme.ControlText = GetColor("#999999");

			theme.GrayText = GetColor("#444444");

			theme.Window = GetColor("#000000");

			theme.WindowFrame = GetColor("#000000");

			theme.WindowText = GetColor("#999999");

			theme.WindowTextShadow = GetColor("#111111");

			theme.WindowBackground = GetColor("#333333");

			theme.WindowButtonHover = GetColor("#444444");

			theme.WindowButtonPressed = GetColor("#555555");

			theme.WindowBorder = GetColor("#444444");

			theme.HighLight = GetColor("#0099FF");

			theme.HighLightText = GetColor("#FFFFFF");

			theme.Focus = GetColor("#0099FF");

			theme.PanelBorder = GetColor("#444444");

			theme.BandDot = GetColor("#555555");

			theme.SplitterForeground = GetColor("#555555");

			theme.SplitterBackground = GetColor("#333333");

			theme.ScrollBarBackground = GetColor("#222222");

			theme.ScrollBarForeground = GetColor("#333333");

			theme.ScrollBarForegroundHover = GetColor("#444444");

			theme.ScrollBarForegroundPressed = GetColor("#555555");

			theme.MenuBackground = GetColor("#222222");

			theme.GridFixedRowBackground = GetColor("#333333");

			theme.GridFixedRowForeground = GetColor("#999999");

			theme.GridFixedRowGrid = GetColor("#444444");

			theme.GridFixedRowFocusBackground = GetColor("#222222");

			theme.GridFixedColumnBackground = GetColor("#222222");

			theme.GridFixedColumnForeground = GetColor("#999999");

			theme.GridFixedColumnGrid = GetColor("#444444");

			theme.GridFixedColumnFocusBackground = GetColor("#111111");

			theme.GridGroupBackground = GetColor("#222222");

			theme.GridGroupForeground = GetColor("#999999");

			theme.GridGroupGrid = GetColor("#444444");

			theme.GridGroupFoldBorder = GetColor("#444444");

			theme.GridGroupFoldFore = GetColor("#555555");

			theme.GridNormalBackground = GetColor("#000000");

			theme.GridNormalForeground = GetColor("#999999");

			theme.GridNormalGrid = GetColor("#444444");

			theme.GridFocusBackground = GetColor("#000000");

			theme.GridFocusForeground = GetColor("#999999");

			theme.GridFocusGrid = GetColor("#666666");

			theme.ImageViewAlpha1 = GetColor("#292929");

			theme.ImageViewAlpha2 = GetColor("#2F2F2F");


			return theme;
		}

		/// <summary>
		/// 白色主题
		/// </summary>
		/// <returns></returns>
		static public ThorComponentTheme Light()
		{
			ThorComponentTheme theme = new ThorComponentTheme();
			theme.Theme = ThorComponentThemes.Light;

			
			theme.ControlDarkDarkDark = GetColor("#888888");

			theme.ControlDarkDark = GetColor("#BDBBBD");

			theme.ControlDark = GetColor("#D7D7D7");

			theme.Control = GetColor("#E3E3E3");

			theme.ControlLight = GetColor("#F0F0F0");

			theme.ControlLightLight = GetColor("#F5F5F5");

			theme.ControlLightLightLight = GetColor("#FFFFFF");

			theme.ControlText = GetColor("#000000");

			theme.GrayText = GetColor("#999999");

			theme.Window = GetColor("#FFFFFF");

			theme.WindowFrame = GetColor("#888888");

			theme.WindowText = GetColor("#000000");

			theme.WindowTextShadow = GetColor("#D7D7D7");

			theme.WindowBackground = GetColor("#E3E3E3");

			theme.WindowButtonHover = GetColor("#D7D7D7");

			theme.WindowButtonPressed = GetColor("#BDBBBD");

			theme.WindowBorder = GetColor("#BDBBBD");

			theme.HighLight = GetColor("#0099FF");

			theme.HighLightText = GetColor("#000000");

			theme.Focus = GetColor("#0099FF");

			theme.PanelBorder = GetColor("#D7D7D7");

			theme.BandDot = GetColor("#BDBBBD");

			theme.SplitterForeground = GetColor("#888888");

			theme.SplitterBackground = GetColor("#E3E3E3");

			theme.ScrollBarBackground = GetColor("#F5F5F5");

			theme.ScrollBarForeground = GetColor("#D7D7D7");

			theme.ScrollBarForegroundHover = GetColor("#BDBBBD");

			theme.ScrollBarForegroundPressed = GetColor("#888888");

			theme.MenuBackground = GetColor("#F5F5F5");

			theme.GridFixedRowBackground = GetColor("#E3E3E3");

			theme.GridFixedRowForeground = GetColor("#000000");

			theme.GridFixedRowGrid = GetColor("#D7D7D7");

			theme.GridFixedRowFocusBackground = GetColor("#D7D7D7");

			theme.GridFixedColumnBackground = GetColor("#F0F0F0");

			theme.GridFixedColumnForeground = GetColor("#000000");

			theme.GridFixedColumnGrid = GetColor("#D7D7D7");

			theme.GridFixedColumnFocusBackground = GetColor("#E3E3E3");

			theme.GridGroupBackground = GetColor("#F5F5F5");

			theme.GridGroupForeground = GetColor("#000000");

			theme.GridGroupGrid = GetColor("#D7D7D7");

			theme.GridGroupFoldBorder = GetColor("#BDBBBD");

			theme.GridGroupFoldFore = GetColor("#888888");

			theme.GridNormalBackground = GetColor("#FFFFFF");

			theme.GridNormalForeground = GetColor("#000000");

			theme.GridNormalGrid = GetColor("#D7D7D7");

			theme.GridFocusBackground = GetColor("#FFFFFF");

			theme.GridFocusForeground = GetColor("#000000");

			theme.GridFocusGrid = GetColor("#888888");

			theme.ImageViewAlpha1 = GetColor("#E3E3E3");

			theme.ImageViewAlpha2 = GetColor("#E3E3E3");


			return theme;
		}

		/// <summary>
		/// 设置主题
		/// </summary>
		/// <param name="theme"></param>
		static public void SetTheme(ThorComponentThemes theme)
		{
			switch (theme)
			{
				case ThorComponentThemes.Dark:
					Current = Dark();
					break;

				case ThorComponentThemes.Light:
					Current = Light();
					break;
			}
		}

		#endregion

		#region properties

		public ThorComponentThemes Theme { get; set; }
	
		
		/// <summary>
		/// 通用控件最暗色部分的颜色
		/// </summary>
		public Color ControlDarkDarkDark { get; set; }

		/// <summary>
		/// 通用控件暗色部分的颜色
		/// </summary>
		public Color ControlDarkDark { get; set; }

		/// <summary>
		/// 通用控件浅暗色部分的颜色
		/// </summary>
		public Color ControlDark { get; set; }

		/// <summary>
		/// 通用控件的颜色
		/// </summary>
		public Color Control { get; set; }

		/// <summary>
		/// 通用控件的浅亮色部分的颜色
		/// </summary>
		public Color ControlLight { get; set; }

		/// <summary>
		/// 通用控件的高亮色部分的颜色
		/// </summary>
		public Color ControlLightLight { get; set; }

		/// <summary>
		/// 通用控件的最高亮色部分的颜色
		/// </summary>
		public Color ControlLightLightLight { get; set; }

		/// <summary>
		/// 通用控件的文本颜色
		/// </summary>
		public Color ControlText { get; set; }

		/// <summary>
		/// 通用控件的灰色文本颜色
		/// </summary>
		public Color GrayText { get; set; }

		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		public Color Window { get; set; }

		/// <summary>
		/// 窗体框架颜色
		/// </summary>
		public Color WindowFrame { get; set; }

		/// <summary>
		/// 窗体标准文本颜色
		/// </summary>
		public Color WindowText { get; set; }

		/// <summary>
		/// 窗体标准文本的阴影颜色
		/// </summary>
		public Color WindowTextShadow { get; set; }

		/// <summary>
		/// 窗体背景颜色
		/// </summary>
		public Color WindowBackground { get; set; }

		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		public Color WindowButtonHover { get; set; }

		/// <summary>
		/// 窗体按钮选中时颜色
		/// </summary>
		public Color WindowButtonPressed { get; set; }

		/// <summary>
		/// 窗口边框颜色
		/// </summary>
		public Color WindowBorder { get; set; }

		/// <summary>
		/// 高亮区域背景颜色
		/// </summary>
		public Color HighLight { get; set; }

		/// <summary>
		/// 高亮区域文本颜色
		/// </summary>
		public Color HighLightText { get; set; }

		/// <summary>
		/// 焦点颜色
		/// </summary>
		public Color Focus { get; set; }

		/// <summary>
		/// 面板边框颜色
		/// </summary>
		public Color PanelBorder { get; set; }

		/// <summary>
		/// 带区句柄颜色
		/// </summary>
		public Color BandDot { get; set; }

		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		public Color SplitterForeground { get; set; }

		/// <summary>
		/// 分隔条前景颜色
		/// </summary>
		public Color SplitterBackground { get; set; }

		/// <summary>
		/// 滚动条背景颜色
		/// </summary>
		public Color ScrollBarBackground { get; set; }

		/// <summary>
		/// 滚动条前景颜色
		/// </summary>
		public Color ScrollBarForeground { get; set; }

		/// <summary>
		/// 滚动条前景指向时颜色
		/// </summary>
		public Color ScrollBarForegroundHover { get; set; }

		/// <summary>
		/// 滚动条前景按下时颜色
		/// </summary>
		public Color ScrollBarForegroundPressed { get; set; }

		/// <summary>
		/// 菜单背景颜色
		/// </summary>
		public Color MenuBackground { get; set; }

		/// <summary>
		/// 网格固定行背景颜色
		/// </summary>
		public Color GridFixedRowBackground { get; set; }

		/// <summary>
		/// 网格固定行前景颜色
		/// </summary>
		public Color GridFixedRowForeground { get; set; }

		/// <summary>
		/// 网格固定行线条颜色
		/// </summary>
		public Color GridFixedRowGrid { get; set; }

		/// <summary>
		/// 网格固定行聚焦背景颜色
		/// </summary>
		public Color GridFixedRowFocusBackground { get; set; }

		/// <summary>
		/// 网格固定列背景颜色
		/// </summary>
		public Color GridFixedColumnBackground { get; set; }

		/// <summary>
		/// 网格固定列前景颜色
		/// </summary>
		public Color GridFixedColumnForeground { get; set; }

		/// <summary>
		/// 网格固定列线条颜色
		/// </summary>
		public Color GridFixedColumnGrid { get; set; }

		/// <summary>
		/// 网格固定列聚焦背景颜色
		/// </summary>
		public Color GridFixedColumnFocusBackground { get; set; }

		/// <summary>
		/// 网格分组单元背景颜色
		/// </summary>
		public Color GridGroupBackground { get; set; }

		/// <summary>
		/// 网格分组单元前景颜色
		/// </summary>
		public Color GridGroupForeground { get; set; }

		/// <summary>
		/// 网格分组单位线条颜色
		/// </summary>
		public Color GridGroupGrid { get; set; }

		/// <summary>
		/// 网格分组单元的折叠边框颜色
		/// </summary>
		public Color GridGroupFoldBorder { get; set; }

		/// <summary>
		/// 网格分组单元的折叠前景颜色
		/// </summary>
		public Color GridGroupFoldFore { get; set; }

		/// <summary>
		/// 网格默认单元的背景颜色
		/// </summary>
		public Color GridNormalBackground { get; set; }

		/// <summary>
		/// 网格默认单元的前景颜色
		/// </summary>
		public Color GridNormalForeground { get; set; }

		/// <summary>
		/// 网格默认单元的线条颜色
		/// </summary>
		public Color GridNormalGrid { get; set; }

		/// <summary>
		/// 网格聚焦单元的背景颜色
		/// </summary>
		public Color GridFocusBackground { get; set; }

		/// <summary>
		/// 网格聚焦单元的前景颜色
		/// </summary>
		public Color GridFocusForeground { get; set; }

		/// <summary>
		/// 网格聚焦单元的线条颜色
		/// </summary>
		public Color GridFocusGrid { get; set; }

		/// <summary>
		/// 图片透明色1
		/// </summary>
		public Color ImageViewAlpha1 { get; set; }

		/// <summary>
		/// 图片透明色2
		/// </summary>
		public Color ImageViewAlpha2 { get; set; }


		#endregion

		#region events

		#endregion
	}
}
