/*
 * ThorSplitter
 * liuqiang@2015/11/1 22:43:04
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


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorSplitter : Splitter
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorSplitter()
			: base()
		{
			DoubleBuffered = true;
			Width = Height = 5;
		}

		#endregion

		#region methods

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			pevent.Graphics.Clear(ThorColors.SplitterBackground);

			int m = 2;
			int l = 20;
			int x1 = 0;
			int y1 = 0;
			int x2 = 0;
			int y2 = 0;

			if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
			{
				x1 = (Width - l) / 2;
				x2 = x1 + l;
				y1 = y2 = Height / 2;
			}
			else if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				x1 = x2 = Width / 2;
				y1 = (Height - l) / 2;
				y2 = y1 + l;
			}
			else
			{
				return;
			}

			Pen pen = ThorPens.SplitterForeground;
			pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			pevent.Graphics.DrawLine(pen, x1, y1, x2, y2);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
