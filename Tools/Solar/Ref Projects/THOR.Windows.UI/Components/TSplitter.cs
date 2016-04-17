using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THOR.Windows.UI.Components
{
	public class TSplitter : Splitter
	{
		public TSplitter()
			: base()
		{
			Width = Height = 9;
			DoubleBuffered = true;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Invalidate();
		}
		
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			pevent.Graphics.FillRectangle(SystemBrushes.Control, new Rectangle(0, 0, Width, Height));

			int lineCount = 3;
			int lineSpacing = 1;
			int lineLength = 10;

			int x = 0;
			int y = 0;

			int mode = 0;

			if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
			{
				x = (Width - lineLength) / 2;
				y = (Height - (lineSpacing * (lineCount - 1) + lineCount)) / 2;
				mode = 1;
			}
			else if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				x = (Width - (lineSpacing * (lineCount - 1) + lineCount)) / 2;
				y = (Height - lineLength) / 2;
				mode = 2;
			}

			Pen pen = SystemPens.ControlDark;

			for (int i = 0; i < lineCount; i++)
			{
				switch (mode)
				{
						//横向
					case 1:
						pevent.Graphics.DrawLine(pen, x, y + (1 + lineSpacing) * i, x + lineLength, y + (1 + lineSpacing) * i);
						break;

						//纵向
					case 2:
						pevent.Graphics.DrawLine(pen, x + (1 + lineSpacing) * i, y, x + (1 + lineSpacing) * i, y + lineLength);
						break;
				}
			}
		}
		
	}
}
