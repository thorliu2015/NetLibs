using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace THOR.Windows.UI.Renders
{
	/// <summary>
	/// 界面笔刷
	/// </summary>
	public class UIBrushes
	{
		/// <summary>
		/// 工作区域笔刷
		/// </summary>
		static public Brush Workspace
		{
			get
			{
				return SystemBrushes.Window;
			}
		}

		/// <summary>
		/// 应用程序工作区域笔刷
		/// </summary>
		static public Brush AppWorkspace
		{
			get
			{
				return new SolidBrush(UIColors.Dark);
			}
		}
	}
}
