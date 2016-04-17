using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 界面颜色
	/// </summary>
	public class UIColors
	{
		/// <summary>
		/// 最高亮
		/// </summary>
		static public Color LightLightLight
		{
			get
			{
				return Color.FromArgb(0xFF, Color.White);
			}
		}

		/// <summary>
		/// 高亮
		/// </summary>
		static public Color LightLight
		{
			get
			{
				return Color.FromArgb(0xDD, Color.White);
			}
		}

		/// <summary>
		/// 亮
		/// </summary>
		static public Color Light
		{
			get
			{
				return Color.FromArgb(0xBB, Color.White);
			}
		}

		/// <summary>
		/// 透明亮度
		/// </summary>
		static public Color LightAlpha
		{
			get
			{
				return Color.FromArgb(0x00, Color.White);
			}
		}

		/// <summary>
		/// 默认
		/// </summary>
		static public Color Default
		{
			get
			{
				return SystemColors.Control;
			}
		}

		/// <summary>
		/// 透明黑
		/// </summary>
		static public Color LightDark
		{
			get
			{
				return Color.FromArgb(0x00, Color.Black);
			}
		}

		/// <summary>
		/// 黑
		/// </summary>
		static public Color Dark
		{
			get
			{
				return Color.FromArgb(0x11, Color.Black);
			}
		}

		/// <summary>
		/// 很黑
		/// </summary>
		static public Color DarkDark
		{
			get
			{
				return Color.FromArgb(0x22, Color.Black);
			}
		}

		/// <summary>
		/// 最黑
		/// </summary>
		static public Color DarkDarkDark
		{
			get
			{
				return Color.FromArgb(0x33, Color.Black);
			}
		}
	}
}
