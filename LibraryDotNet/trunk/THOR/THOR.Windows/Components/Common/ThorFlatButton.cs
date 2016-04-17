/*
 * ThorFlatButton
 * liuqiang@2015/11/22 17:46:14
 * ---- 8< ------------------
 * NOTE
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THOR.Windows.Components.Drawing;


//---- 8< ------------------

namespace THOR.Windows.Components.Common
{
	public class ThorFlatButton : ThorButton
	{
		#region constants

		#endregion

		#region variables

		#endregion

		#region construct

		public ThorFlatButton()
			: base()
		{
			Width = Height = 22;
			TabStop = false;
		}

		#endregion

		#region methods

		protected override void DrawButton(System.Windows.Forms.PaintEventArgs pevent)
		{
			Color themeColor = ThorColors.GetThemeColor(this);

			Color colorFill = Color.Transparent;
			Color colorBorder = Color.Transparent;
			int imageAlpha = 0xFF;
			//----

			if (Enabled)
			{
				if (mouseDown)
				{
					colorFill = Color.FromArgb(0x80, themeColor);
					colorBorder = themeColor;
				}
				else if (mouseOver)
				{
					colorFill = Color.FromArgb(0x40, themeColor);
					colorBorder = Color.FromArgb(0x80, themeColor);
				}
			}
			else
			{
				imageAlpha = 0x30;
			}

			//----

			Rectangle rect = new Rectangle(0, 0, Width, Height);

			if (colorFill != Color.Transparent)
			{
				pevent.Graphics.FillRectangle(new SolidBrush(colorFill), rect);
			}

			if (colorBorder != Color.Transparent)
			{
				ThorControlPaint.DrawRectangle(pevent.Graphics, rect, new Pen(new SolidBrush(colorBorder)));
			}

			//if (Image == null)
			//{
			//	Image = Image.FromFile(@"Z:\Documents\ThorComponentsUI\Test\folder.png");
			//}

			if (Image != null)
			{
				ThorControlPaint.DrawIcon(pevent.Graphics, rect, Image, imageAlpha);
			}
		}

		#endregion

		#region properties

		#endregion

		#region events

		#endregion
	}
}
