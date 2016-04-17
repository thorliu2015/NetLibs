using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using THOR.Windows.UI.Renders;

namespace THOR.Windows.UI.Components
{
	public class TLine : Control
	{
		public TLine()
			: base()
		{
			Init();
		}

		protected void Init()
		{
			DoubleBuffered = true;
			Width = 100;
			Height = 10;
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);

			if (!Vertical)
			{
				UIRender.DrawSeparator(pevent.Graphics, 0, Height / 2, Width, false);
			}
			else
			{
				UIRender.DrawSeparator(pevent.Graphics, Width / 2, 0, Height, true);
			}
		}

		protected bool vertical;
		public bool Vertical
		{
			get
			{
				return vertical;
			}
			set
			{
				if (vertical == value) return;

				if (!Vertical)
				{
					Width = 10;
					Height = 100;
				}
				else
				{
					Width = 100;
					Height = 10;
				}

				vertical = value;
				this.Invalidate();
			}
		}
	}
}
