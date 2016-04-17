using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;

namespace THOR.Windows.UI.Components
{
	public class TContextMenu : ContextMenuStrip
	{
		public TContextMenu()
			: base()
		{
			Init();
		}

		protected void Init()
		{
			this.Font = UIRender.DefaultFont;
			this.DoubleBuffered = true;
			this.Renderer = new ThorToolStripRender();
			this.ShowItemToolTips = true;
		}
	}
}
