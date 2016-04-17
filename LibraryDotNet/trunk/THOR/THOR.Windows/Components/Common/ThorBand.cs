/*
 * ThorBand
 * liuqiang@2015/11/16 19:38:35
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
using THOR.Windows.Components.Drawing;
using THOR.Windows.Components.Fields;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorBand : Panel
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorBand()
			: base()
		{
			DoubleBuffered = true;
			this.ResizeRedraw = true;

			this.Dock = DockStyle.Top;
			this.Width = 100;
			this.Height = 25;
			this.Padding = new Padding(16, 1, 2, 1);
			this.TabStop = false;

		}

		#endregion

		#region methods

		protected virtual void LayoutChildren()
		{
			int x = this.Padding.Left;
			int y = this.Padding.Top;
			int h = this.Height - this.Padding.Top - this.Padding.Bottom;
			int s = 1;

			foreach (Control child in Controls)
			{
				child.Height = h;
				child.Location = new Point(x, y + (h - child.Height) / 2);
				x += s + child.Width;
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			LayoutChildren();
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			LayoutChildren();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
			LayoutChildren();
			int c = 3;
			Rectangle rect = new Rectangle(0, 0, Width, Height);
			ThorControlPaint.DrawBand(e.Graphics, rect, true, 3);
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
