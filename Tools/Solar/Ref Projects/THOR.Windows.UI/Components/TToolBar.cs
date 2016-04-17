using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;

namespace THOR.Windows.UI.Components
{
	/// <summary>
	/// 工具栏
	/// </summary>
	public class TToolBar : ToolStrip
	{
		/// <summary>
		/// 构造
		/// </summary>
		public TToolBar()
			: base()
		{
			Init();
		}

		/// <summary>
		/// 初始化
		/// </summary>
		protected virtual void Init()
		{
			DoubleBuffered = true;
			this.Renderer = new ThorToolStripRender();
			this.ShowItemToolTips = true;
			this.GripMargin = new Padding(0);

			this.Font = UIRender.DefaultFont;
			this.ForeColor = UIColors.DarkDark;
			this.GripStyle = ToolStripGripStyle.Hidden;
			this.Padding = new Padding(4, 2, 4, 2);
		}
	}
}
