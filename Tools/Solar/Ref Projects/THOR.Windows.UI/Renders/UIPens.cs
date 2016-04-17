using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 界面笔触
	/// </summary>
	public class UIPens
	{
		/// <summary>
		/// 工作区笔触
		/// </summary>
		static public Pen Workspace
		{
			get
			{
				return new Pen(new SolidBrush(UIColors.DarkDark));
			}
		}

		/// <summary>
		/// 应用程序工作区笔触
		/// </summary>
		static public Pen AppWorkspace
		{
			get
			{
				return new Pen(new SolidBrush(UIColors.DarkDarkDark));
			}
		}
	}
}
