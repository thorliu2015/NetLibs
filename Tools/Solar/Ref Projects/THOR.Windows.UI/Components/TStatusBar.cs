using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;
namespace THOR.Windows.UI.Components
{
	public class TStatusBar : StatusStrip
	{
		/// <summary>
		/// 构造
		/// </summary>
		public TStatusBar()
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
			this.SizingGrip = false;
			this.ShowItemToolTips = true;
			this.GripMargin = new Padding(0);

			this.Font = UIRender.DefaultFont;
			this.ForeColor = UIColors.DarkDark;
		}
	}
}
